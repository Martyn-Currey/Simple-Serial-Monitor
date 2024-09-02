'
' Simple Serial Monitor V1.0.0.1
' A stand alone replacement for the Arduino Serial Monitor
' © Martyn Currey 2024
' www.martyncurrey.com
'
' Visual Studio 2022
' Visual Basic.Net (Framework).NET V4.8. The version with the drag & drop serial port :-)
' 



Imports System
Imports System.IO.Ports
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip



Public Class SimpleSerial

    ' global variables. Sometimes bad, sometimes good, sometimes just what you need.

    Dim comPORT As String
    Dim serialPropertiesBoxOpen = False

    Dim MAIN_RichTextBox_textSize As Integer = 1

    ' colours used fir the text in the main text box
    ' Black = received text
    ' Blue = sent text
    ' red = system message
    Dim colBlack As Color = Color.Black
    Dim colBlue As Color = Color.Blue
    Dim colRed As Color = Color.Red
    Dim colGreen As Color = Color.Green
    Dim lastMessageType As String = ""


    ' comPortListLength and oldComPortListLength are used to determine is the number of available com ports has changed
    ' when the new list length <> the old list length something has changed and the com port drop down list can be updated
    Dim comPortListLength As Integer = 0
    Dim oldComPortListLength As Integer = 0


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Form1_Load(~) runs once when the app first loads

        ' minimum size for the app window
        Me.MinimumSize = New Size(520, 420)

        ' populate the combobox drop down lists

        Dim baudRatesArray() As Integer = {300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880, 115200, 230400, 250000, 500000, 1000000, 2000000}
        BAUD_ComboBox.MaxDropDownItems = baudRatesArray.Length
        For Each baudRate As Integer In baudRatesArray
            BAUD_ComboBox.Items.Add(baudRate)
        Next
        BAUD_ComboBox.SelectedIndex = 4

        ' items.add also works. I prefer this way when there are not too many items.
        LE_ComboBox.Items.Clear()
        LE_ComboBox.Items.Add("Both NL & CR")
        LE_ComboBox.Items.Add("No Line Ending")
        LE_ComboBox.Items.Add("Carriage Return")
        LE_ComboBox.Items.Add("New Line")
        LE_ComboBox.SelectedIndex = 0

        ' the SEND button is enabled only when there is an active connection
        SEND_Button.Enabled = False
        CONNECT_BTN.BackColor = Color.FromArgb(255, 50, 50)

        Dim dataBitsArray() As String = {"5 bits", "6 bits", "7 bits", "8 bits"}
        dataBits_ComboBox.MaxDropDownItems = dataBitsArray.Length
        For Each dataBit As String In dataBitsArray
            dataBits_ComboBox.Items.Add(dataBit)
        Next
        dataBits_ComboBox.SelectedIndex = 3

        Dim parityOptionsArray() As String = {"None", "Odd", "Even"}
        parityBit_ComboBox.MaxDropDownItems = dataBitsArray.Length
        For Each parity As String In parityOptionsArray
            parityBit_ComboBox.Items.Add(parity)
        Next
        parityBit_ComboBox.SelectedIndex = 0

        Dim stopBitsArray As String() = {"1 bit", "2 bits"}
        stopBits_ComboBox.MaxDropDownItems = stopBitsArray.Length
        For Each stopBit As String In stopBitsArray
            stopBits_ComboBox.Items.Add(stopBit)
        Next
        stopBits_ComboBox.SelectedIndex = 0

        Dim charEncodesArray() As String = {"Default", "UTF8", "Unicode", "ASCII", "UTF7", "UTF32"}
        encode_ComboBox.MaxDropDownItems = charEncodesArray.Length
        For Each charEncode As String In charEncodesArray
            encode_ComboBox.Items.Add(charEncode)
        Next
        encode_ComboBox.SelectedIndex = 0

        ' timers
        ' - Timer_checkSerialIn. used to check if there is any new data on the serial port
        ' - Timer_slide. used to slide the serial port settings port panel in and out
        ' - Timer_updateComPorts. used to check if the number of available com ports has changed
        Timer_checkSerialIn.Enabled = False
        Timer_slide.Enabled = False
        Timer_updateComPorts.Enabled = True

        ' load the settings that were saved the last time the app was used
        LoadSettings()

        ' serialProperties_GroupBox contains the serial port settings.
        ' it is hidden to one side when not in use.
        serialProperties_GroupBox.Left = Me.Width + 10
        serialProperties_GroupBox.Top = 30
        message1_LBL.Text = " "


    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' when the form closes save the settings
        saveSettings()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' if File > Exit is clicked, close the program.
        ' calling me.close() will call MainForm_FormClosing(~)
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        ' show the about form
        AboutBox1.Show()
    End Sub







    '   _____  ______  _____   _____            _          _____    ____   _____  _______ 
    '  / ____||  ____||  __ \ |_   _|    /\    | |        |  __ \  / __ \ |  __ \|__   __|
    ' | (___  | |__   | |__) |  | |     /  \   | |        | |__) || |  | || |__) |  | |   
    '  \___ \ |  __|  |  _  /   | |    / /\ \  | |        |  ___/ | |  | ||  _  /   | |   
    '  ____) || |____ | | \ \  _| |_  / ____ \ | |____    | |     | |__| || | \ \   | |   
    ' |_____/ |______||_|  \_\|_____|/_/    \_\|______|   |_|      \____/ |_|  \_\  |_|   
    ' and related
    '
    Private Sub connect_BTN_Click(sender As Object, e As EventArgs) Handles CONNECT_BTN.Click
        ' the connect button is used to connect and disconnect
        If (SerialPort1.IsOpen) Then
            DISCONNECT()
        Else
            CONNECT()
        End If
    End Sub


    Private Sub BAUD_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BAUD_ComboBox.SelectedIndexChanged
        ' if a different com port is selected when there is an active serial connection the app will close the current connection
        ' and try to make a new one using the new com port
        ' if there isn't an active connection nothing happens
        If (SerialPort1.IsOpen) Then
            DISCONNECT()
            CONNECT()
        End If
    End Sub


    Private Sub CONNECT()

        ' baud rate is taken from selected item value.
        ' parity and stop bits are derived from the list index value of the selected item.

        ' Serial Parity
        '   index 0 = None
        '   index 1 = odd
        '   index 2 = even
        '
        ' Serial Stop Bits
        '   index 0 = One
        '   index 1 = Two

        ' com port is taken from the user selected item value
        comPORT = comPort_ComboBox.SelectedItem

        ' for the baud rate and com port I want the value of the item that is selected in the drop down list
        ' for data bits, parity and stops bits, VB uses an integer, SerialPort1.DataBits is an integer, this means
        ' as long as the drop down lists use the same order that VB serialport1.~ uses I can use the list index (also an integer). 
        ' sometimes the list index matches exactly what VB expects, for example SerialPort1.Parity = parityBit_ComboBox.SelectedIndex
        ' sometimes you need to change the index slightly, for example SerialPort1.DataBits = dataBits_ComboBox.SelectedIndex + 5

        'if a com port has been selected, try to open a channel
        If (comPORT <> "") Then

            SerialPort1.Close()
            SerialPort1.PortName = comPORT
            SerialPort1.BaudRate = BAUD_ComboBox.SelectedItem

            SerialPort1.DataBits = dataBits_ComboBox.SelectedIndex + 5
            SerialPort1.Parity = parityBit_ComboBox.SelectedIndex
            SerialPort1.StopBits = stopBits_ComboBox.SelectedIndex + 1

            SerialPort1.Handshake = Handshake.None

            If (encode_ComboBox.SelectedIndex = 0) Then
                SerialPort1.Encoding = System.Text.Encoding.Default
            ElseIf (encode_ComboBox.SelectedIndex = 1) Then
                SerialPort1.Encoding = System.Text.Encoding.UTF8

            ElseIf (encode_ComboBox.SelectedIndex = 2) Then
                SerialPort1.Encoding = System.Text.Encoding.Unicode

            ElseIf (encode_ComboBox.SelectedIndex = 3) Then
                SerialPort1.Encoding = System.Text.Encoding.ASCII

            ElseIf (encode_ComboBox.SelectedIndex = 4) Then
                SerialPort1.Encoding = System.Text.Encoding.UTF7

            ElseIf (encode_ComboBox.SelectedIndex = 5) Then
                SerialPort1.Encoding = System.Text.Encoding.UTF32
            Else
                SerialPort1.Encoding = System.Text.Encoding.Default
            End If

            SerialPort1.ReadTimeout = 500
            SerialPort1.WriteTimeout = 500
            SerialPort1.RtsEnable = True
            SerialPort1.DtrEnable = True

            ' SerialPort1.Open() may fail and if it fails without the try/catch the program will crash.
            Try
                SerialPort1.Open()
            Catch ex As Exception
                MsgBox("Failed to open  " & comPORT)
            End Try

            ' the serial port may or may not be open
            ' if it is open, update the sreen and the timers
            ' if it is not open, print a system message in the main text box.
            If (SerialPort1.IsOpen) Then
                ' serial_connected = True
                CONNECT_BTN.BackColor = Color.FromArgb(128, 225, 128)
                SEND_Button.Enabled = True
                Timer_checkSerialIn.Enabled = True
                Timer_updateComPorts.Enabled = False
                AddSysMsgToMainTextBox("Serial port open" + vbCrLf, colRed, "yes")
            Else
                AddSysMsgToMainTextBox("Failed to open " & comPORT & vbCrLf, colRed, "yes")
            End If
        Else
            MsgBox("No COM port selected")
        End If
    End Sub


    Private Sub DISCONNECT()
        Timer_checkSerialIn.Enabled = False
        Timer_updateComPorts.Enabled = True
        SEND_Button.Enabled = False

        Try
            SerialPort1.Close()
        Catch ex As Exception
            MsgBox("Serial port already closed")
        End Try

        '  serial_connected = False
        CONNECT_BTN.BackColor = Color.FromArgb(255, 50, 50)

        AddSysMsgToMainTextBox("Serial port closed" + vbCrLf, colRed, "yes")

    End Sub


    Private Sub Timer_checkSerialIn_Tick(sender As Object, e As EventArgs) Handles Timer_checkSerialIn.Tick
        ' timer used to check for incoming serial data
        ' could be replaced with the serial received event.

        ' first things first, turn the timer off.
        ' can't have Timer_checkSerialIn_Tick(~) being called while we are still here
        ' otherwise we never get out - serious case of check serial inception 
        Timer_checkSerialIn.Enabled = False

        ' if you try to read from a serial port that is not open all sorts of bad things hapen and the program crashes.
        ' so use a try/catch
        Dim tmpDataIn As String = ""
        If (SerialPort1.IsOpen) Then
            If (SerialPort1.BytesToRead > 0) Then
                Try
                    tmpDataIn = SerialPort1.ReadExisting()
                Catch ex As Exception
                    MsgBox("Error reading from the serial port")
                End Try
            End If

            ' if there is new received data add it to the main text box
            If (tmpDataIn <> "") Then
                addReceivedTextToMainTextBox(tmpDataIn, colBlack)
            End If

            ' and finally start the timer again.
            Timer_checkSerialIn.Enabled = True

        Else
            ' no serial port
            DISCONNECT()
            MsgBox("The serial port has unexpectedly closed")
        End If

    End Sub



    Private Sub Timer_updateComPorts_Tick(sender As Object, e As EventArgs) Handles Timer_updateComPorts.Tick
        ' Timer_updateComPorts is active only when there isn't an active serial port
        ' it is used to see if there are any changes to the available com ports list

        updateCOMlist()
    End Sub

    Private Sub updateCOMlist()

        ' the previous number of available com ports Is stored in oldComPortListLength
        ' the current number of available com ports is put in to comPortListLength
        ' if they are not equal then the com port list has changed and should be updated.

        comPortListLength = My.Computer.Ports.SerialPortNames.Count

        ' The com port drop down list is only updated if the number of available com ports has changed
        If (comPortListLength <> oldComPortListLength) Then

            oldComPortListLength = comPortListLength
            comPORT = comPort_ComboBox.SelectedItem
            comPort_ComboBox.Items.Clear()

            For Each sp As String In My.Computer.Ports.SerialPortNames
                comPort_ComboBox.Items.Add(sp)
            Next

            If (My.Computer.Ports.SerialPortNames.Contains(comPORT)) Then
                comPort_ComboBox.SelectedItem = comPORT
            Else
                comPORT = ""
                comPort_ComboBox.Text = "COM Port"
            End If

            ' AddSysMsgToMainTextBox("Updated COM port list" + vbCrLf, colRed,"yes")
        End If

    End Sub







    '  __  __            _____  _   _     _______  ______ __   __ _______     ____    ____ __   __
    ' |  \/  |    /\    |_   _|| \ | |   |__   __||  ____|\ \ / /|__   __|   |  _ \  / __ \\ \ / /
    ' | \  / |   /  \     | |  |  \| |      | |   | |__    \ V /    | |      | |_) || |  | |\ V / 
    ' | |\/| |  / /\ \    | |  | . ` |      | |   |  __|    > <     | |      |  _ < | |  | | > <  
    ' | |  | | / ____ \  _| |_ | |\  |      | |   | |____  / . \    | |      | |_) || |__| |/ . \ 
    ' |_|  |_|/_/    \_\|_____||_| \_|      |_|   |______|/_/ \_\   |_|      |____/  \____//_/ \_\
    '

    Private Sub addReceivedTextToMainTextBox(text As String, c As Color)

        ' if the previous text/data was a system message without line end characters then print a newline before adding the new received data

        If (lastMessageType = "system") Then
            Dim currentPos As Integer = MAIN_RichTextBox.SelectionStart()
            If (currentPos > 0) Then
                If (MAIN_RichTextBox.Text.Chars(currentPos - 1) <> vbLf) Then
                    MAIN_RichTextBox.AppendText(vbLf)
                End If
            End If
        End If

        MAIN_RichTextBox.SelectionStart = MAIN_RichTextBox.Text.Length
        MAIN_RichTextBox.SelectionColor = c
        MAIN_RichTextBox.AppendText(text)
        scrollTextBox()
        lastMessageType = "received"
    End Sub


    Private Sub AddSysMsgToMainTextBox(Text As String, c As Color, NL As String)
        ' NL is used as a flag to say if the system message is to be displayed on a new line
        ' however, we don't want a new line if there is already one there. This would result in a blank line
        ' so only add the new line if the last character is not a new line.

        If (SYS_MSG_CheckBox.CheckState = 1) Then

            If (NL.ToUpper = "YES") Then
                Dim currentPos As Integer = MAIN_RichTextBox.SelectionStart()
                If (currentPos > 0) Then
                    If (MAIN_RichTextBox.Text.Chars(currentPos - 1) <> vbLf) Then
                        MAIN_RichTextBox.AppendText(vbLf)
                    End If
                End If
            End If

            MAIN_RichTextBox.SelectionStart = MAIN_RichTextBox.Text.Length
            ' change the text colour
            MAIN_RichTextBox.SelectionColor = c
            MAIN_RichTextBox.AppendText(Text)

            scrollTextBox()
            lastMessageType = "system"
        End If

    End Sub


    Private Sub scrollTextBox()
        ' scroll the text box the end
        If (SCROLL_CheckBox.CheckState = 1) Then
            MAIN_RichTextBox.SelectionStart = MAIN_RichTextBox.TextLength
            MAIN_RichTextBox.ScrollToCaret()
        End If
    End Sub


    Private Sub clear_BTN_Click_1(sender As Object, e As EventArgs) Handles clear_BTN.Click
        ' clear the main text box
        MAIN_RichTextBox.Text = ""
    End Sub


    Private Sub TEXT_SMALL_BUTTON_Click(sender As Object, e As EventArgs) Handles TEXT_SMALL_BUTTON.Click
        ' reduce the main text box font size
        If (MAIN_RichTextBox_textSize > 1) Then
            MAIN_RichTextBox_textSize = MAIN_RichTextBox_textSize - 1
        End If
        updateTextSize()
    End Sub

    Private Sub TEXT_BIG_BUTTON_Click(sender As Object, e As EventArgs) Handles TEXT_BIG_BUTTON.Click
        ' increase the main text box font size
        If (MAIN_RichTextBox_textSize < 5) Then
            MAIN_RichTextBox_textSize = MAIN_RichTextBox_textSize + 1
        End If
        updateTextSize()
    End Sub


    Private Sub updateTextSize()

        ' there are 5 sizes; 1 to 5.
        ' 1 is whatever the default size is (if you haven't changed anything it is courier new size 10)
        ' 5 is the largest

        Dim zoomFactor As Single = 0

        If (MAIN_RichTextBox_textSize = 1) Then
            fonSize_LBL.Text = "|----"
            zoomFactor = 1
        ElseIf (MAIN_RichTextBox_textSize = 2) Then
            fonSize_LBL.Text = "-|---"
            zoomFactor = 1.2
        ElseIf (MAIN_RichTextBox_textSize = 3) Then
            fonSize_LBL.Text = "--|--"
            zoomFactor = 1.4
        ElseIf (MAIN_RichTextBox_textSize = 4) Then
            fonSize_LBL.Text = "---|-"
            zoomFactor = 1.6
        ElseIf (MAIN_RichTextBox_textSize = 5) Then
            fonSize_LBL.Text = "----|"
            zoomFactor = 1.8

        End If

        ' using zoom, rather than changing the font, keeps the original formating (ie the coloured text)
        MAIN_RichTextBox.SelectAll()
        MAIN_RichTextBox.ZoomFactor = zoomFactor

    End Sub









    ''  _____  ______  _   _  _____  
    '' / ____||  ____|| \ | ||  __ \ 
    ''| (___  | |__   |  \| || |  | |
    '' \___ \ |  __|  | . ` || |  | |
    '' ____) || |____ | |\  || |__| |
    ''|_____/ |______||_| \_||_____/ 
    '

    Private Sub SEND_Button_Click(sender As Object, e As EventArgs) Handles SEND_Button.Click
        ProcessSendText(SEND_RichTextBox.Text)
        SEND_RichTextBox.Text = ""
        SEND_RichTextBox.Select()
    End Sub

    Private Sub SEND_RichTextBox_KeyPress(sender As Object, e As KeyEventArgs) Handles SEND_RichTextBox.KeyUp

        ' TO STOP THE ANOYING BEEP SOUND WHEN THE ENTER KEY IS PRESSED I AM USING A MULTLINE TEXTBOX FOR SEND
        ' TO STOP THE SCROLL BARS FLASHING WHEN THE ENTER KEY IS PRESSED THEY HAVE BEEN DISABLED
        ' CAVEAT: THE ENTER KEY IS ADDED TO THE TEXTBOX CONTENTS AND NEEDS TO BE REMOVED

        ' has the enter key been pressed?
        If (e.KeyCode = Keys.Enter) Then

            ' when using a multiline rich-textbox, if the content length = 1 it means the content is a
            ' new line character only and it can be ignored. It means the user has pressed enter without
            ' entering anything in the SEND text box.
            ' you can see this is you uncomment the below

            ' however, if the content length > 1 it means there is actual content
            If (SEND_RichTextBox.Text.Length() > 1) Then

                ' Dim lastChar As String = SEND_RichTextBox.Text(SEND_RichTextBox.Text.Length - 1)
                ' Dim lastCharInAscii = Asc(lastChar)
                ' AddSysMsgToMainTextBox("length = " & SEND_RichTextBox.Text.Length(), colRed, "yes")
                ' AddSysMsgToMainTextBox("last char = " & lastChar, colRed, "yes")
                ' AddSysMsgToMainTextBox("last ASCII = " & lastCharInAscii, colRed, "yes")

                ' remove the last character (don't uncomment this)
                SEND_RichTextBox.Text = SEND_RichTextBox.Text.Substring(0, SEND_RichTextBox.Text.Length() - 1)
                ProcessSendText(SEND_RichTextBox.Text)

            Else
                Beep()
            End If

            ' we have finished with the key event and can now pretend it never happened.
            e.Handled = True
            e.SuppressKeyPress = True

            SEND_RichTextBox.Text = ""
            SEND_RichTextBox.Select()

        End If

    End Sub


    Private Sub ProcessSendText(textToSend As String)
        ' send only. Does not clear text box

        ' textToSend should never be blank but you never know. better to have a check.
        If (textToSend <> "") Then

            ' line end characters are based on the user selected preference
            ' index 0 = Both NL & CR
            ' index 1 = No Line Ending
            ' index 2 = Carriage Return
            ' index 3 = New Line

            Dim EOL As String = ""
            If (LE_ComboBox.SelectedIndex = 0) Then
                EOL = vbCrLf
            ElseIf (LE_ComboBox.SelectedIndex = 2) Then
                EOL = vbCr
            ElseIf (LE_ComboBox.SelectedIndex = 3) Then
                EOL = vbLf
            End If

            If (showSent_checkBox.CheckState = 1) Then
                AddSysMsgToMainTextBox(textToSend, colBlue, "yes")
            End If

            sendSerial(textToSend & EOL)

        End If

    End Sub


    Private Sub sendSerial(data As String)
        ' the part that actual sends the data is in it's own subroutine incase I expand the app later
        ' this could be converted to a function with a success/failure return

        ' anything serialport should be wrapped in a try/catch
        If (SerialPort1.IsOpen) Then
            Try
                SerialPort1.Write(data)
            Catch ex As Exception
                DISCONNECT()
                MsgBox("Error: failed to write to the serial port")
            End Try

        End If
    End Sub







    '  _       ____            _____         __    _____      __      __ ______ 
    ' | |     / __ \    /\    |  __ \       / /   / ____|   /\\ \    / /|  ____|
    ' | |    | |  | |  /  \   | |  | |     / /   | (___    /  \\ \  / / | |__   
    ' | |    | |  | | / /\ \  | |  | |    / /     \___ \  / /\ \\ \/ /  |  __|  
    ' | |____| |__| |/ ____ \ | |__| |   / /      ____) |/ ____ \\  /   | |____ 
    ' |______|\____//_/    \_\|_____/   /_/      |_____//_/    \_\\/    |______|
    '

    Private Sub resetSettings()
        comPort_ComboBox.SelectedItem = ""
        BAUD_ComboBox.SelectedItem = "9600"
        LE_ComboBox.SelectedItem = "Both NL & CR"
        comPort_ComboBox.SelectedItem = ""
        MAIN_RichTextBox_textSize = 2
        SYS_MSG_CheckBox.CheckState = 0
        SCROLL_CheckBox.CheckState = 1

        ' other things, like the window size already have defaults written in to the app, and do not need to be reset
    End Sub

    Private Sub LoadSettings()
        ' App settings are saved in a text file

        Dim filename As String = "simpleSerial.ini"
        Dim tmpInputLine As String = ""
        Dim foundPos As Integer = 0

        ' kind of wasteful.
        ' if the settings file does not exist, create it, then read from it.
        ' if all the settings have just been reset why bother reading them from the file

        If Not System.IO.File.Exists(filename) Then
            ' file does not exist,  use default values,  create a new settings file
            resetSettings()
            saveSettings()
        End If


        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(filename)

        tmpInputLine = fileReader.ReadLine()

        While tmpInputLine <> "END"
            tmpInputLine = fileReader.ReadLine()

            foundPos = InStr(1, tmpInputLine, "=", CompareMethod.Text)

            If (foundPos > 0) Then
                Dim tmpInputLineSplit() As String = Split(tmpInputLine, "=", -1, CompareMethod.Text)

                ' tmpInputLineSplit
                ' form size
                ' all the local variables aren't really needed but they make the code easier to read.
                ' and at least i didn't use global variables!

                If (tmpInputLineSplit(0) = "size") Then
                    If (tmpInputLineSplit(1) <> "") Then
                        Dim tmpSize() As String = Split(tmpInputLineSplit(1), ",", -1, CompareMethod.Text)
                        Dim tmpWidth As Integer = Val(tmpSize(0))
                        Dim tmpHeight As Integer = Val(tmpSize(1))

                        If (tmpWidth >= 520 And tmpHeight >= 420) Then
                            Me.Width = tmpWidth
                            Me.Height = tmpHeight
                        End If
                    Else
                        ' this is not really required, 520x420 is the default start size.
                        Me.Width = 520
                        Me.Height = 420
                    End If
                End If


                ' baudrate
                ' if baudrate is not found the default 9600 is still there
                If (tmpInputLineSplit(0) = "baudrate") Then
                    If (tmpInputLineSplit(1) <> "" And BAUD_ComboBox.Items.Contains(tmpInputLineSplit(1))) Then
                        BAUD_ComboBox.SelectedItem = tmpInputLineSplit(1)
                    End If
                End If


                ' line end characters
                If (tmpInputLineSplit(0) = "eol") Then
                    If (tmpInputLineSplit(1) <> "" And LE_ComboBox.Items.Contains(tmpInputLineSplit(1))) Then
                        LE_ComboBox.SelectedItem = tmpInputLineSplit(1)
                    Else
                        LE_ComboBox.SelectedItem = ""
                    End If
                End If


                ' COM port is not saved


                If (tmpInputLineSplit(0) = "textsize") Then
                    If (tmpInputLineSplit(1) <> "") Then
                        If (Val(tmpInputLineSplit(1)) >= 1 And Val(tmpInputLineSplit(1) <= 5)) Then
                            MAIN_RichTextBox_textSize = Val(tmpInputLineSplit(1))
                        Else
                            MAIN_RichTextBox_textSize = 2
                        End If
                    End If
                    updateTextSize()

                End If


                If (tmpInputLineSplit(0) = "sysmsg") Then
                    If (tmpInputLineSplit(1) = "yes") Then
                        SYS_MSG_CheckBox.CheckState = 1
                    ElseIf (tmpInputLineSplit(1) = "no") Then
                        SYS_MSG_CheckBox.CheckState = 0
                    Else
                        SYS_MSG_CheckBox.CheckState = 1
                    End If
                End If

                If (tmpInputLineSplit(0) = "scroll") Then
                    If (tmpInputLineSplit(1) = "yes") Then
                        SCROLL_CheckBox.CheckState = 1
                    ElseIf (tmpInputLineSplit(1) = "no") Then
                        SCROLL_CheckBox.CheckState = 0
                    Else
                        SCROLL_CheckBox.CheckState = 1
                    End If
                End If

                If (tmpInputLineSplit(0) = "showsent") Then
                    If (tmpInputLineSplit(1) = "yes") Then
                        showSent_checkBox.CheckState = 1
                    ElseIf (tmpInputLineSplit(1) = "no") Then
                        showSent_checkBox.CheckState = 0
                    Else
                        showSent_checkBox.CheckState = 1
                    End If
                End If

                If (tmpInputLineSplit(0) = "databits") Then
                    If (tmpInputLineSplit(1) <> "") Then
                        dataBits_ComboBox.SelectedItem = tmpInputLineSplit(1)
                    End If
                End If

                If (tmpInputLineSplit(0) = "parity") Then
                    If (tmpInputLineSplit(1) <> "") Then
                        parityBit_ComboBox.SelectedItem = tmpInputLineSplit(1)
                    End If
                End If

                If (tmpInputLineSplit(0) = "stopbits") Then
                    If (tmpInputLineSplit(1) <> "") Then
                        stopBits_ComboBox.SelectedItem = tmpInputLineSplit(1)
                    End If
                End If


            End If
        End While
        fileReader.Close()

        AddSysMsgToMainTextBox("Previous settings loaded", colRed, "yes")

    End Sub


    Private Sub saveSettings()

        Dim tmpString As String = ""

        Dim filename As String = "simpleSerial.ini"
        If (System.IO.File.Exists(filename) = False) Then
            System.IO.File.Create(filename).Dispose()
        End If

        Dim objWriter As New System.IO.StreamWriter(filename, False)

        objWriter.WriteLine("Simple Serial Monitor Settings")

        objWriter.WriteLine("size=" & Me.Width & "," & Me.Height)

        ' baud rate
        tmpString = BAUD_ComboBox.SelectedItem
        If (tmpString = "") Then
            tmpString = "9600"
        End If
        objWriter.WriteLine("baudrate=" & tmpString)

        'eol
        tmpString = LE_ComboBox.SelectedItem
        objWriter.WriteLine("eol=" & tmpString)


        'main text box text size
        objWriter.WriteLine("textsize=" & MAIN_RichTextBox_textSize)

        If (SCROLL_CheckBox.CheckState = 1) Then
            objWriter.WriteLine("scroll=yes")
        Else
            objWriter.WriteLine("scroll=no")
        End If

        If (SYS_MSG_CheckBox.CheckState = 1) Then
            objWriter.WriteLine("sysmsg=yes")
        Else
            objWriter.WriteLine("sysmsg=no")
        End If

        If (showSent_checkBox.CheckState = 1) Then
            objWriter.WriteLine("showsent=yes")
        Else
            objWriter.WriteLine("showsent=no")
        End If

        tmpString = dataBits_ComboBox.SelectedItem
        objWriter.WriteLine("databits=" & tmpString)

        tmpString = parityBit_ComboBox.SelectedItem
        objWriter.WriteLine("parity=" & tmpString)

        tmpString = stopBits_ComboBox.SelectedItem
        objWriter.WriteLine("stopbits=" & tmpString)

        objWriter.WriteLine("END")
        objWriter.Close()


    End Sub

    Private Sub SCROLL_CheckBox_CheckedChanged(sender As Object, e As EventArgs)
        If (SCROLL_CheckBox.CheckState = 1) Then
            scrollTextBox()
        End If

    End Sub








    '   _____  ______  _______  _______  _____  _   _   _____   _____      _____          _   _  ______  _      
    '  / ____||  ____||__   __||__   __||_   _|| \ | | / ____| / ____|    |  __ \  /\    | \ | ||  ____|| |     
    ' | (___  | |__      | |      | |     | |  |  \| || |  __ | (___      | |__) |/  \   |  \| || |__   | |     
    '  \___ \ |  __|     | |      | |     | |  | . ` || | |_ | \___ \     |  ___// /\ \  | . ` ||  __|  | |     
    '  ____) || |____    | |      | |    _| |_ | |\  || |__| | ____) |    | |   / ____ \ | |\  || |____ | |____ 
    ' |_____/ |______|   |_|      |_|   |_____||_| \_| \_____||_____/     |_|  /_/    \_\|_| \_||______||______|
    ' 
    ' 

    ' clicking the settings button enables a timer
    ' the timer is used to slide the serial port settings panel in and out
    Private Sub Setting_BTN_Click(sender As Object, e As EventArgs) Handles setting_BTN.Click
        If (SerialPort1.IsOpen) Then
            message1_LBL.Text = "Changes will update when" & vbCrLf & "a new connection is made"
        Else
            message1_LBL.Text = " "
        End If

        Timer_slide.Enabled = True
    End Sub


    Private Sub SerialPropertiesClose_BTN_Click(sender As Object, e As EventArgs) Handles serialPropertiesClose_BTN.Click
        ' the CLOSE button is the settings panel has patent pending InstaClose functionality :-)
        serialProperties_GroupBox.Left = Me.Width + 10
        serialPropertiesBoxOpen = False
    End Sub


    Private Sub Timer_slide_Tick(sender As Object, e As EventArgs) Handles Timer_slide.Tick

        ' if the settings panel is not open, open it,  else close it.

        ' you could get rid of all this and just open and close the panel but where is the fun in that.

        ' living dangerously, I don't disable the timer while moving the settings panel.
        ' I am trusting that the windows PC/VB can move the panel 20 pixels before the timer fires again.
        ' of course, once the panel is in the fully opened or fully closed position I stop the timer so
        ' the panel doesn't move anymore.

        If (serialPropertiesBoxOpen = False) Then

            If (serialProperties_GroupBox.Left > (Me.Width - 280)) Then
                serialProperties_GroupBox.Left = serialProperties_GroupBox.Left - 20
            Else
                Timer_slide.Enabled = False
                serialPropertiesBoxOpen = True
                serialProperties_GroupBox.Left = Me.Width - 300
            End If

        Else

            If (serialProperties_GroupBox.Left < (Me.Width + 10)) Then
                serialProperties_GroupBox.Left = serialProperties_GroupBox.Left + 20
            Else
                Timer_slide.Enabled = False
                serialPropertiesBoxOpen = False
            End If

        End If

    End Sub






    '  _____   ______   _____  _____  ______ ______    __          __ _____  _   _  _____    ____ __          __
    ' |  __ \ |  ____| / ____||_   _||___  /|  ____|   \ \        / /|_   _|| \ | ||  __ \  / __ \\ \        / /
    ' | |__) || |__   | (___    | |     / / | |__       \ \  /\  / /   | |  |  \| || |  | || |  | |\ \  /\  / / 
    ' |  _  / |  __|   \___ \   | |    / /  |  __|       \ \/  \/ /    | |  | . ` || |  | || |  | | \ \/  \/ /  
    ' | | \ \ | |____  ____) | _| |_  / /__ | |____       \  /\  /    _| |_ | |\  || |__| || |__| |  \  /\  /   
    ' |_|  \_\|______||_____/ |_____|/_____||______|       \/  \/    |_____||_| \_||_____/  \____/    \/  \/    
    '

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        ' not an elegant solution, everything is manually placed,  but it works.
        ' Might have been better to use one of the layout tools

        '  serialProperties_GroupBox
        If (serialPropertiesBoxOpen = True) Then
            serialProperties_GroupBox.Left = Me.Width - 300
        Else
            serialProperties_GroupBox.Left = Me.Width + 20
        End If


        MAIN_RichTextBox.Width = Me.Width - 40
        MAIN_RichTextBox.Height = Me.Height - 180
        MAIN_RichTextBox.Left = 10

        Dim baseOffset As Integer = 152

        SCROLL_CheckBox.Top = Me.Height - baseOffset
        TEXT_SMALL_BUTTON.Top = Me.Height - (baseOffset + 2)
        fonSize_LBL.Top = Me.Height - (baseOffset - 2)
        TEXT_BIG_BUTTON.Top = Me.Height - (baseOffset + 2)
        SYS_MSG_CheckBox.Top = Me.Height - baseOffset
        showSent_checkBox.Top = Me.Height - baseOffset

        clear_BTN.Left = Me.Width - 30 - clear_BTN.Width
        clear_BTN.Top = Me.Height - (baseOffset + 4)

        SEND_RichTextBox.Width = Me.Width - 124
        SEND_RichTextBox.Top = Me.Height - (baseOffset - 32)

        SEND_Button.Left = Me.Width - 30 - SEND_Button.Width
        SEND_Button.Top = Me.Height - (baseOffset - 31) ' 133

        baseOffset = 82
        BAUD_ComboBox.Top = Me.Height - baseOffset
        LE_ComboBox.Top = Me.Height - baseOffset
        comPort_ComboBox.Top = Me.Height - baseOffset
        CONNECT_BTN.Top = Me.Height - baseOffset

        setting_BTN.Top = Me.Height - baseOffset
        setting_BTN.Left = Me.Width - 30 - setting_BTN.Width

        scrollHandle.Left = Me.Width - 31
        scrollHandle.Top = Me.Height - 54

    End Sub


End Class

