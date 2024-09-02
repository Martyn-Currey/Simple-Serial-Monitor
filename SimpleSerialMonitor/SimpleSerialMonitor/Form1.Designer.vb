<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SimpleSerial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MAIN_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.comPort_ComboBox = New System.Windows.Forms.ComboBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.CONNECT_BTN = New System.Windows.Forms.Button()
        Me.Timer_checkSerialIn = New System.Windows.Forms.Timer(Me.components)
        Me.LE_ComboBox = New System.Windows.Forms.ComboBox()
        Me.BAUD_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Timer_updateComPorts = New System.Windows.Forms.Timer(Me.components)
        Me.serialProperties_GroupBox = New System.Windows.Forms.GroupBox()
        Me.encode_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.serialPropertiesClose_BTN = New System.Windows.Forms.Button()
        Me.message1_LBL = New System.Windows.Forms.Label()
        Me.stopBits_ComboBox = New System.Windows.Forms.ComboBox()
        Me.parityBit_ComboBox = New System.Windows.Forms.ComboBox()
        Me.dataBits_ComboBox = New System.Windows.Forms.ComboBox()
        Me.stopBits_LBL = New System.Windows.Forms.Label()
        Me.parityBit_LBL = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer_slide = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.setting_BTN = New System.Windows.Forms.Button()
        Me.showSent_checkBox = New System.Windows.Forms.CheckBox()
        Me.SYS_MSG_CheckBox = New System.Windows.Forms.CheckBox()
        Me.clear_BTN = New System.Windows.Forms.Button()
        Me.TEXT_SMALL_BUTTON = New System.Windows.Forms.Button()
        Me.SCROLL_CheckBox = New System.Windows.Forms.CheckBox()
        Me.TEXT_BIG_BUTTON = New System.Windows.Forms.Button()
        Me.SEND_Button = New System.Windows.Forms.Button()
        Me.scrollHandle = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.file_ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.fonSize_LBL = New System.Windows.Forms.Label()
        Me.SEND_RichTextBox = New System.Windows.Forms.RichTextBox()
        Me.serialProperties_GroupBox.SuspendLayout()
        CType(Me.scrollHandle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MAIN_RichTextBox
        '
        Me.MAIN_RichTextBox.BackColor = System.Drawing.Color.White
        Me.MAIN_RichTextBox.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MAIN_RichTextBox.Location = New System.Drawing.Point(10, 23)
        Me.MAIN_RichTextBox.Name = "MAIN_RichTextBox"
        Me.MAIN_RichTextBox.ReadOnly = True
        Me.MAIN_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.MAIN_RichTextBox.Size = New System.Drawing.Size(480, 236)
        Me.MAIN_RichTextBox.TabIndex = 5
        Me.MAIN_RichTextBox.Text = ""
        Me.MAIN_RichTextBox.WordWrap = False
        '
        'comPort_ComboBox
        '
        Me.comPort_ComboBox.BackColor = System.Drawing.Color.White
        Me.comPort_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comPort_ComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comPort_ComboBox.FormattingEnabled = True
        Me.comPort_ComboBox.Location = New System.Drawing.Point(225, 338)
        Me.comPort_ComboBox.Name = "comPort_ComboBox"
        Me.comPort_ComboBox.Size = New System.Drawing.Size(76, 25)
        Me.comPort_ComboBox.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.comPort_ComboBox, "COM Port list")
        '
        'CONNECT_BTN
        '
        Me.CONNECT_BTN.BackColor = System.Drawing.Color.Tomato
        Me.CONNECT_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CONNECT_BTN.Location = New System.Drawing.Point(308, 338)
        Me.CONNECT_BTN.Name = "CONNECT_BTN"
        Me.CONNECT_BTN.Size = New System.Drawing.Size(30, 26)
        Me.CONNECT_BTN.TabIndex = 34
        Me.ToolTip1.SetToolTip(Me.CONNECT_BTN, "Connect/Disconnect")
        Me.CONNECT_BTN.UseVisualStyleBackColor = False
        '
        'Timer_checkSerialIn
        '
        '
        'LE_ComboBox
        '
        Me.LE_ComboBox.BackColor = System.Drawing.Color.White
        Me.LE_ComboBox.DisplayMember = " "
        Me.LE_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LE_ComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LE_ComboBox.FormattingEnabled = True
        Me.LE_ComboBox.Location = New System.Drawing.Point(91, 338)
        Me.LE_ComboBox.Name = "LE_ComboBox"
        Me.LE_ComboBox.Size = New System.Drawing.Size(120, 25)
        Me.LE_ComboBox.TabIndex = 32
        Me.ToolTip1.SetToolTip(Me.LE_ComboBox, "Line end characters")
        '
        'BAUD_ComboBox
        '
        Me.BAUD_ComboBox.BackColor = System.Drawing.Color.White
        Me.BAUD_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BAUD_ComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BAUD_ComboBox.FormattingEnabled = True
        Me.BAUD_ComboBox.Location = New System.Drawing.Point(10, 338)
        Me.BAUD_ComboBox.Name = "BAUD_ComboBox"
        Me.BAUD_ComboBox.Size = New System.Drawing.Size(68, 25)
        Me.BAUD_ComboBox.TabIndex = 31
        Me.ToolTip1.SetToolTip(Me.BAUD_ComboBox, "Baud rate")
        '
        'Timer_updateComPorts
        '
        Me.Timer_updateComPorts.Interval = 500
        '
        'serialProperties_GroupBox
        '
        Me.serialProperties_GroupBox.BackColor = System.Drawing.Color.LightGray
        Me.serialProperties_GroupBox.Controls.Add(Me.encode_ComboBox)
        Me.serialProperties_GroupBox.Controls.Add(Me.Label1)
        Me.serialProperties_GroupBox.Controls.Add(Me.serialPropertiesClose_BTN)
        Me.serialProperties_GroupBox.Controls.Add(Me.message1_LBL)
        Me.serialProperties_GroupBox.Controls.Add(Me.stopBits_ComboBox)
        Me.serialProperties_GroupBox.Controls.Add(Me.parityBit_ComboBox)
        Me.serialProperties_GroupBox.Controls.Add(Me.dataBits_ComboBox)
        Me.serialProperties_GroupBox.Controls.Add(Me.stopBits_LBL)
        Me.serialProperties_GroupBox.Controls.Add(Me.parityBit_LBL)
        Me.serialProperties_GroupBox.Controls.Add(Me.Label2)
        Me.serialProperties_GroupBox.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialProperties_GroupBox.Location = New System.Drawing.Point(269, 30)
        Me.serialProperties_GroupBox.Name = "serialProperties_GroupBox"
        Me.serialProperties_GroupBox.Size = New System.Drawing.Size(217, 236)
        Me.serialProperties_GroupBox.TabIndex = 53
        Me.serialProperties_GroupBox.TabStop = False
        Me.serialProperties_GroupBox.Text = "Serial Properties"
        '
        'encode_ComboBox
        '
        Me.encode_ComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.encode_ComboBox.FormattingEnabled = True
        Me.encode_ComboBox.Location = New System.Drawing.Point(106, 127)
        Me.encode_ComboBox.Name = "encode_ComboBox"
        Me.encode_ComboBox.Size = New System.Drawing.Size(94, 25)
        Me.encode_ComboBox.TabIndex = 55
        Me.ToolTip1.SetToolTip(Me.encode_ComboBox, "Number of stop bits")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Encoding:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'serialPropertiesClose_BTN
        '
        Me.serialPropertiesClose_BTN.BackColor = System.Drawing.Color.LightSteelBlue
        Me.serialPropertiesClose_BTN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.serialPropertiesClose_BTN.Location = New System.Drawing.Point(129, 198)
        Me.serialPropertiesClose_BTN.Name = "serialPropertiesClose_BTN"
        Me.serialPropertiesClose_BTN.Size = New System.Drawing.Size(72, 30)
        Me.serialPropertiesClose_BTN.TabIndex = 53
        Me.serialPropertiesClose_BTN.Text = "CLOSE"
        Me.ToolTip1.SetToolTip(Me.serialPropertiesClose_BTN, "Close")
        Me.serialPropertiesClose_BTN.UseVisualStyleBackColor = False
        '
        'message1_LBL
        '
        Me.message1_LBL.AutoSize = True
        Me.message1_LBL.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.message1_LBL.Location = New System.Drawing.Point(17, 159)
        Me.message1_LBL.Name = "message1_LBL"
        Me.message1_LBL.Size = New System.Drawing.Size(159, 34)
        Me.message1_LBL.TabIndex = 16
        Me.message1_LBL.Text = "Changes will update when" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a new connection is made"
        '
        'stopBits_ComboBox
        '
        Me.stopBits_ComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stopBits_ComboBox.FormattingEnabled = True
        Me.stopBits_ComboBox.Location = New System.Drawing.Point(106, 87)
        Me.stopBits_ComboBox.Name = "stopBits_ComboBox"
        Me.stopBits_ComboBox.Size = New System.Drawing.Size(94, 25)
        Me.stopBits_ComboBox.TabIndex = 52
        Me.ToolTip1.SetToolTip(Me.stopBits_ComboBox, "Number of stop bits")
        '
        'parityBit_ComboBox
        '
        Me.parityBit_ComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.parityBit_ComboBox.FormattingEnabled = True
        Me.parityBit_ComboBox.Location = New System.Drawing.Point(106, 57)
        Me.parityBit_ComboBox.Name = "parityBit_ComboBox"
        Me.parityBit_ComboBox.Size = New System.Drawing.Size(94, 25)
        Me.parityBit_ComboBox.TabIndex = 51
        Me.ToolTip1.SetToolTip(Me.parityBit_ComboBox, "Type of parity bit")
        '
        'dataBits_ComboBox
        '
        Me.dataBits_ComboBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataBits_ComboBox.FormattingEnabled = True
        Me.dataBits_ComboBox.Location = New System.Drawing.Point(106, 27)
        Me.dataBits_ComboBox.Name = "dataBits_ComboBox"
        Me.dataBits_ComboBox.Size = New System.Drawing.Size(94, 25)
        Me.dataBits_ComboBox.TabIndex = 50
        Me.ToolTip1.SetToolTip(Me.dataBits_ComboBox, "The number of data bits")
        '
        'stopBits_LBL
        '
        Me.stopBits_LBL.AutoSize = True
        Me.stopBits_LBL.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stopBits_LBL.Location = New System.Drawing.Point(18, 93)
        Me.stopBits_LBL.Name = "stopBits_LBL"
        Me.stopBits_LBL.Size = New System.Drawing.Size(59, 17)
        Me.stopBits_LBL.TabIndex = 12
        Me.stopBits_LBL.Text = "Stop Bits"
        Me.stopBits_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'parityBit_LBL
        '
        Me.parityBit_LBL.AutoSize = True
        Me.parityBit_LBL.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.parityBit_LBL.Location = New System.Drawing.Point(18, 62)
        Me.parityBit_LBL.Name = "parityBit_LBL"
        Me.parityBit_LBL.Size = New System.Drawing.Size(62, 17)
        Me.parityBit_LBL.TabIndex = 11
        Me.parityBit_LBL.Text = "Parity bit:"
        Me.parityBit_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Data Bits:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer_slide
        '
        Me.Timer_slide.Interval = 5
        '
        'setting_BTN
        '
        Me.setting_BTN.BackColor = System.Drawing.SystemColors.Control
        Me.setting_BTN.BackgroundImage = Global.SimpleSerialMonitor.My.Resources.Resources.settings_icon_grey_36x36
        Me.setting_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.setting_BTN.Location = New System.Drawing.Point(463, 338)
        Me.setting_BTN.Name = "setting_BTN"
        Me.setting_BTN.Size = New System.Drawing.Size(26, 26)
        Me.setting_BTN.TabIndex = 40
        Me.ToolTip1.SetToolTip(Me.setting_BTN, "Open/close the serial properties tab")
        Me.setting_BTN.UseVisualStyleBackColor = False
        '
        'showSent_checkBox
        '
        Me.showSent_checkBox.AutoSize = True
        Me.showSent_checkBox.Checked = True
        Me.showSent_checkBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.showSent_checkBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.showSent_checkBox.Location = New System.Drawing.Point(322, 272)
        Me.showSent_checkBox.Name = "showSent_checkBox"
        Me.showSent_checkBox.Size = New System.Drawing.Size(87, 21)
        Me.showSent_checkBox.TabIndex = 58
        Me.showSent_checkBox.Text = "Show Sent"
        Me.ToolTip1.SetToolTip(Me.showSent_checkBox, "Copy sent text to the main window")
        Me.showSent_checkBox.UseVisualStyleBackColor = True
        '
        'SYS_MSG_CheckBox
        '
        Me.SYS_MSG_CheckBox.AutoSize = True
        Me.SYS_MSG_CheckBox.Checked = True
        Me.SYS_MSG_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SYS_MSG_CheckBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SYS_MSG_CheckBox.Location = New System.Drawing.Point(186, 272)
        Me.SYS_MSG_CheckBox.Name = "SYS_MSG_CheckBox"
        Me.SYS_MSG_CheckBox.Size = New System.Drawing.Size(131, 21)
        Me.SYS_MSG_CheckBox.TabIndex = 57
        Me.SYS_MSG_CheckBox.Text = "System Messages"
        Me.ToolTip1.SetToolTip(Me.SYS_MSG_CheckBox, "Show system messages in the main window")
        Me.SYS_MSG_CheckBox.UseVisualStyleBackColor = True
        '
        'clear_BTN
        '
        Me.clear_BTN.BackColor = System.Drawing.Color.LightSteelBlue
        Me.clear_BTN.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clear_BTN.Location = New System.Drawing.Point(415, 268)
        Me.clear_BTN.Name = "clear_BTN"
        Me.clear_BTN.Size = New System.Drawing.Size(72, 30)
        Me.clear_BTN.TabIndex = 59
        Me.clear_BTN.Text = "CLEAR"
        Me.ToolTip1.SetToolTip(Me.clear_BTN, "Clear the main window")
        Me.clear_BTN.UseVisualStyleBackColor = False
        '
        'TEXT_SMALL_BUTTON
        '
        Me.TEXT_SMALL_BUTTON.BackgroundImage = Global.SimpleSerialMonitor.My.Resources.Resources.font_black_small2
        Me.TEXT_SMALL_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TEXT_SMALL_BUTTON.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEXT_SMALL_BUTTON.Location = New System.Drawing.Point(72, 270)
        Me.TEXT_SMALL_BUTTON.Margin = New System.Windows.Forms.Padding(0)
        Me.TEXT_SMALL_BUTTON.Name = "TEXT_SMALL_BUTTON"
        Me.TEXT_SMALL_BUTTON.Size = New System.Drawing.Size(24, 24)
        Me.TEXT_SMALL_BUTTON.TabIndex = 55
        Me.TEXT_SMALL_BUTTON.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.TEXT_SMALL_BUTTON, "Make text smaller")
        Me.TEXT_SMALL_BUTTON.UseVisualStyleBackColor = True
        '
        'SCROLL_CheckBox
        '
        Me.SCROLL_CheckBox.AutoSize = True
        Me.SCROLL_CheckBox.Checked = True
        Me.SCROLL_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SCROLL_CheckBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SCROLL_CheckBox.Location = New System.Drawing.Point(10, 272)
        Me.SCROLL_CheckBox.Name = "SCROLL_CheckBox"
        Me.SCROLL_CheckBox.Size = New System.Drawing.Size(59, 21)
        Me.SCROLL_CheckBox.TabIndex = 54
        Me.SCROLL_CheckBox.Text = "Scroll"
        Me.ToolTip1.SetToolTip(Me.SCROLL_CheckBox, "Auto scroll on/off")
        Me.SCROLL_CheckBox.UseVisualStyleBackColor = True
        '
        'TEXT_BIG_BUTTON
        '
        Me.TEXT_BIG_BUTTON.BackgroundImage = Global.SimpleSerialMonitor.My.Resources.Resources.font_black_large
        Me.TEXT_BIG_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TEXT_BIG_BUTTON.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEXT_BIG_BUTTON.Location = New System.Drawing.Point(144, 270)
        Me.TEXT_BIG_BUTTON.Margin = New System.Windows.Forms.Padding(0)
        Me.TEXT_BIG_BUTTON.Name = "TEXT_BIG_BUTTON"
        Me.TEXT_BIG_BUTTON.Size = New System.Drawing.Size(24, 24)
        Me.TEXT_BIG_BUTTON.TabIndex = 56
        Me.TEXT_BIG_BUTTON.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.TEXT_BIG_BUTTON, "Make text larger")
        Me.TEXT_BIG_BUTTON.UseVisualStyleBackColor = True
        '
        'SEND_Button
        '
        Me.SEND_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SEND_Button.BackColor = System.Drawing.Color.LightSteelBlue
        Me.SEND_Button.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SEND_Button.Location = New System.Drawing.Point(415, 302)
        Me.SEND_Button.Name = "SEND_Button"
        Me.SEND_Button.Size = New System.Drawing.Size(72, 30)
        Me.SEND_Button.TabIndex = 61
        Me.SEND_Button.Text = "SEND"
        Me.ToolTip1.SetToolTip(Me.SEND_Button, "Send text")
        Me.SEND_Button.UseVisualStyleBackColor = False
        '
        'scrollHandle
        '
        Me.scrollHandle.BackColor = System.Drawing.Color.Transparent
        Me.scrollHandle.BackgroundImage = Global.SimpleSerialMonitor.My.Resources.Resources.scroll_handle
        Me.scrollHandle.Location = New System.Drawing.Point(489, 366)
        Me.scrollHandle.Name = "scrollHandle"
        Me.scrollHandle.Size = New System.Drawing.Size(8, 8)
        Me.scrollHandle.TabIndex = 50
        Me.scrollHandle.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.file_ToolStripMenuItem1, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(498, 24)
        Me.MenuStrip1.TabIndex = 52
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'file_ToolStripMenuItem1
        '
        Me.file_ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.file_ToolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.file_ToolStripMenuItem1.Name = "file_ToolStripMenuItem1"
        Me.file_ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.file_ToolStripMenuItem1.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'fonSize_LBL
        '
        Me.fonSize_LBL.AutoSize = True
        Me.fonSize_LBL.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fonSize_LBL.Location = New System.Drawing.Point(96, 273)
        Me.fonSize_LBL.Name = "fonSize_LBL"
        Me.fonSize_LBL.Size = New System.Drawing.Size(47, 16)
        Me.fonSize_LBL.TabIndex = 60
        Me.fonSize_LBL.Text = "--|--"
        Me.fonSize_LBL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SEND_RichTextBox
        '
        Me.SEND_RichTextBox.BackColor = System.Drawing.Color.White
        Me.SEND_RichTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SEND_RichTextBox.Location = New System.Drawing.Point(10, 301)
        Me.SEND_RichTextBox.Name = "SEND_RichTextBox"
        Me.SEND_RichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.SEND_RichTextBox.Size = New System.Drawing.Size(390, 31)
        Me.SEND_RichTextBox.TabIndex = 62
        Me.SEND_RichTextBox.Text = ""
        '
        'SimpleSerial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 375)
        Me.Controls.Add(Me.SEND_RichTextBox)
        Me.Controls.Add(Me.SEND_Button)
        Me.Controls.Add(Me.showSent_checkBox)
        Me.Controls.Add(Me.fonSize_LBL)
        Me.Controls.Add(Me.SYS_MSG_CheckBox)
        Me.Controls.Add(Me.clear_BTN)
        Me.Controls.Add(Me.TEXT_SMALL_BUTTON)
        Me.Controls.Add(Me.SCROLL_CheckBox)
        Me.Controls.Add(Me.TEXT_BIG_BUTTON)
        Me.Controls.Add(Me.serialProperties_GroupBox)
        Me.Controls.Add(Me.setting_BTN)
        Me.Controls.Add(Me.MAIN_RichTextBox)
        Me.Controls.Add(Me.scrollHandle)
        Me.Controls.Add(Me.comPort_ComboBox)
        Me.Controls.Add(Me.CONNECT_BTN)
        Me.Controls.Add(Me.LE_ComboBox)
        Me.Controls.Add(Me.BAUD_ComboBox)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "SimpleSerial"
        Me.Text = "Simple Serial Monitor"
        Me.serialProperties_GroupBox.ResumeLayout(False)
        Me.serialProperties_GroupBox.PerformLayout()
        CType(Me.scrollHandle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MAIN_RichTextBox As RichTextBox
    Friend WithEvents comPort_ComboBox As ComboBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents CONNECT_BTN As Button
    Friend WithEvents Timer_checkSerialIn As Timer
    Friend WithEvents LE_ComboBox As ComboBox
    Friend WithEvents BAUD_ComboBox As ComboBox
    Friend WithEvents Timer_updateComPorts As Timer
    Friend WithEvents scrollHandle As PictureBox
    Friend WithEvents setting_BTN As Button
    Friend WithEvents serialProperties_GroupBox As GroupBox
    Friend WithEvents message1_LBL As Label
    Friend WithEvents stopBits_ComboBox As ComboBox
    Friend WithEvents parityBit_ComboBox As ComboBox
    Friend WithEvents dataBits_ComboBox As ComboBox
    Friend WithEvents stopBits_LBL As Label
    Friend WithEvents parityBit_LBL As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents serialPropertiesClose_BTN As Button
    Friend WithEvents Timer_slide As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents file_ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents showSent_checkBox As CheckBox
    Friend WithEvents fonSize_LBL As Label
    Friend WithEvents SYS_MSG_CheckBox As CheckBox
    Friend WithEvents clear_BTN As Button
    Friend WithEvents TEXT_SMALL_BUTTON As Button
    Friend WithEvents SCROLL_CheckBox As CheckBox
    Friend WithEvents TEXT_BIG_BUTTON As Button
    Friend WithEvents SEND_Button As Button
    Friend WithEvents SEND_RichTextBox As RichTextBox
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents encode_ComboBox As ComboBox
    Friend WithEvents Label1 As Label
End Class
