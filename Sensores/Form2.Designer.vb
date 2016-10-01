<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.send_BTN = New System.Windows.Forms.Button()
        Me.send_TB = New System.Windows.Forms.TextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.receivedData_head_LBL = New System.Windows.Forms.Label()
        Me.clear_BTN = New System.Windows.Forms.Button()
        Me.Timer_LBL = New System.Windows.Forms.Label()
        Me.COMport_LBL = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ProgressBar14 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar13 = New System.Windows.Forms.ProgressBar()
        Me.ProgressBar9 = New System.Windows.Forms.ProgressBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ProgressBar10 = New System.Windows.Forms.ProgressBar()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ProgressBar11 = New System.Windows.Forms.ProgressBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ProgressBar12 = New System.Windows.Forms.ProgressBar()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar5 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ProgressBar6 = New System.Windows.Forms.ProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ProgressBar7 = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ProgressBar8 = New System.Windows.Forms.ProgressBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.refreshCOM_CB_BTN = New System.Windows.Forms.Button()
        Me.comPort_ComboBox = New System.Windows.Forms.ComboBox()
        Me.connect_BTN = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.connecting_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 18)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(745, 597)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.send_BTN)
        Me.TabPage1.Controls.Add(Me.send_TB)
        Me.TabPage1.Controls.Add(Me.RichTextBox1)
        Me.TabPage1.Controls.Add(Me.receivedData_head_LBL)
        Me.TabPage1.Controls.Add(Me.clear_BTN)
        Me.TabPage1.Controls.Add(Me.Timer_LBL)
        Me.TabPage1.Controls.Add(Me.COMport_LBL)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(737, 571)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Connection"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'send_BTN
        '
        Me.send_BTN.Location = New System.Drawing.Point(576, 521)
        Me.send_BTN.Name = "send_BTN"
        Me.send_BTN.Size = New System.Drawing.Size(75, 23)
        Me.send_BTN.TabIndex = 78
        Me.send_BTN.Text = "Send"
        Me.send_BTN.UseVisualStyleBackColor = True
        '
        'send_TB
        '
        Me.send_TB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.send_TB.Location = New System.Drawing.Point(258, 521)
        Me.send_TB.Name = "send_TB"
        Me.send_TB.Size = New System.Drawing.Size(312, 22)
        Me.send_TB.TabIndex = 77
        Me.send_TB.Text = "<ALL?>"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(41, 135)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(659, 355)
        Me.RichTextBox1.TabIndex = 60
        Me.RichTextBox1.Text = ""
        '
        'receivedData_head_LBL
        '
        Me.receivedData_head_LBL.AutoSize = True
        Me.receivedData_head_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.receivedData_head_LBL.Location = New System.Drawing.Point(38, 114)
        Me.receivedData_head_LBL.Name = "receivedData_head_LBL"
        Me.receivedData_head_LBL.Size = New System.Drawing.Size(104, 18)
        Me.receivedData_head_LBL.TabIndex = 59
        Me.receivedData_head_LBL.Text = "Received Data"
        '
        'clear_BTN
        '
        Me.clear_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clear_BTN.Location = New System.Drawing.Point(111, 524)
        Me.clear_BTN.Name = "clear_BTN"
        Me.clear_BTN.Size = New System.Drawing.Size(75, 30)
        Me.clear_BTN.TabIndex = 56
        Me.clear_BTN.Text = "Clear"
        Me.clear_BTN.UseVisualStyleBackColor = True
        '
        'Timer_LBL
        '
        Me.Timer_LBL.AutoSize = True
        Me.Timer_LBL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Timer_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Timer_LBL.Location = New System.Drawing.Point(179, 22)
        Me.Timer_LBL.Name = "Timer_LBL"
        Me.Timer_LBL.Size = New System.Drawing.Size(86, 20)
        Me.Timer_LBL.TabIndex = 29
        Me.Timer_LBL.Text = "Timer: OFF"
        '
        'COMport_LBL
        '
        Me.COMport_LBL.AutoSize = True
        Me.COMport_LBL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.COMport_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COMport_LBL.Location = New System.Drawing.Point(38, 22)
        Me.COMport_LBL.Name = "COMport_LBL"
        Me.COMport_LBL.Size = New System.Drawing.Size(78, 20)
        Me.COMport_LBL.TabIndex = 28
        Me.COMport_LBL.Text = "COM Port"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TextBox2)
        Me.TabPage2.Controls.Add(Me.TextBox1)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(737, 571)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Color Sensor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBox2.Location = New System.Drawing.Point(477, 299)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(103, 20)
        Me.TextBox2.TabIndex = 21
        '
        'TextBox1
        '
        Me.TextBox1.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBox1.Location = New System.Drawing.Point(477, 270)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(103, 20)
        Me.TextBox1.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(387, 302)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 13)
        Me.Label16.TabIndex = 19
        Me.Label16.Text = "Aquisition Time"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(387, 277)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Gain"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.ProgressBar14)
        Me.GroupBox3.Controls.Add(Me.ProgressBar13)
        Me.GroupBox3.Controls.Add(Me.ProgressBar9)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.ProgressBar10)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.ProgressBar11)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.ProgressBar12)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(60, 262)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(305, 218)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "RAW"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 178)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Saturation 75"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(7, 149)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Saturation"
        '
        'ProgressBar14
        '
        Me.ProgressBar14.Location = New System.Drawing.Point(79, 178)
        Me.ProgressBar14.Name = "ProgressBar14"
        Me.ProgressBar14.Size = New System.Drawing.Size(210, 24)
        Me.ProgressBar14.TabIndex = 9
        '
        'ProgressBar13
        '
        Me.ProgressBar13.Location = New System.Drawing.Point(79, 149)
        Me.ProgressBar13.Name = "ProgressBar13"
        Me.ProgressBar13.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar13.TabIndex = 8
        '
        'ProgressBar9
        '
        Me.ProgressBar9.Location = New System.Drawing.Point(79, 60)
        Me.ProgressBar9.Name = "ProgressBar9"
        Me.ProgressBar9.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar9.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "CPL"
        '
        'ProgressBar10
        '
        Me.ProgressBar10.Location = New System.Drawing.Point(79, 30)
        Me.ProgressBar10.Name = "ProgressBar10"
        Me.ProgressBar10.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar10.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Color Temp"
        '
        'ProgressBar11
        '
        Me.ProgressBar11.Location = New System.Drawing.Point(79, 89)
        Me.ProgressBar11.Name = "ProgressBar11"
        Me.ProgressBar11.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar11.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(21, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Max Lux"
        '
        'ProgressBar12
        '
        Me.ProgressBar12.Location = New System.Drawing.Point(79, 119)
        Me.ProgressBar12.Name = "ProgressBar12"
        Me.ProgressBar12.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar12.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(21, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Lux"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ProgressBar5)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.ProgressBar6)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ProgressBar7)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.ProgressBar8)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(371, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(305, 166)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "COMPENSATED"
        '
        'ProgressBar5
        '
        Me.ProgressBar5.Location = New System.Drawing.Point(79, 60)
        Me.ProgressBar5.Name = "ProgressBar5"
        Me.ProgressBar5.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar5.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Clear"
        '
        'ProgressBar6
        '
        Me.ProgressBar6.Location = New System.Drawing.Point(79, 30)
        Me.ProgressBar6.Name = "ProgressBar6"
        Me.ProgressBar6.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar6.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Blue"
        '
        'ProgressBar7
        '
        Me.ProgressBar7.Location = New System.Drawing.Point(79, 89)
        Me.ProgressBar7.Name = "ProgressBar7"
        Me.ProgressBar7.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar7.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Green"
        '
        'ProgressBar8
        '
        Me.ProgressBar8.Location = New System.Drawing.Point(79, 119)
        Me.ProgressBar8.Name = "ProgressBar8"
        Me.ProgressBar8.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar8.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Red"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ProgressBar3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ProgressBar4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(60, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 166)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RAW"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(79, 60)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Clear"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(79, 30)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Blue"
        '
        'ProgressBar3
        '
        Me.ProgressBar3.Location = New System.Drawing.Point(79, 89)
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar3.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Green"
        '
        'ProgressBar4
        '
        Me.ProgressBar4.Location = New System.Drawing.Point(79, 119)
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(210, 23)
        Me.ProgressBar4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Red"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button7)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Button6)
        Me.TabPage3.Controls.Add(Me.Button5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(737, 571)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Led13"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(303, 92)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(119, 42)
        Me.Button7.TabIndex = 3
        Me.Button7.Text = "Check LED13 Status"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.DimGray
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(304, 140)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 37)
        Me.Label17.TabIndex = 2
        Me.Label17.Text = "LED13"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Red
        Me.Button6.Location = New System.Drawing.Point(61, 140)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(93, 42)
        Me.Button6.TabIndex = 1
        Me.Button6.Text = "LED OFF"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Chartreuse
        Me.Button5.Location = New System.Drawing.Point(61, 92)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(93, 42)
        Me.Button5.TabIndex = 0
        Me.Button5.Text = "LED ON"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'refreshCOM_CB_BTN
        '
        Me.refreshCOM_CB_BTN.Location = New System.Drawing.Point(57, 621)
        Me.refreshCOM_CB_BTN.Name = "refreshCOM_CB_BTN"
        Me.refreshCOM_CB_BTN.Size = New System.Drawing.Size(25, 25)
        Me.refreshCOM_CB_BTN.TabIndex = 26
        Me.refreshCOM_CB_BTN.Text = "R"
        Me.refreshCOM_CB_BTN.UseVisualStyleBackColor = True
        '
        'comPort_ComboBox
        '
        Me.comPort_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comPort_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comPort_ComboBox.FormattingEnabled = True
        Me.comPort_ComboBox.Location = New System.Drawing.Point(97, 624)
        Me.comPort_ComboBox.Name = "comPort_ComboBox"
        Me.comPort_ComboBox.Size = New System.Drawing.Size(121, 21)
        Me.comPort_ComboBox.TabIndex = 25
        '
        'connect_BTN
        '
        Me.connect_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.connect_BTN.Location = New System.Drawing.Point(233, 621)
        Me.connect_BTN.Name = "connect_BTN"
        Me.connect_BTN.Size = New System.Drawing.Size(120, 25)
        Me.connect_BTN.TabIndex = 27
        Me.connect_BTN.Text = "Connect"
        Me.connect_BTN.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        '
        'Timer1
        '
        '
        'connecting_Timer
        '
        Me.connecting_Timer.Interval = 250
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 653)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.refreshCOM_CB_BTN)
        Me.Controls.Add(Me.comPort_ComboBox)
        Me.Controls.Add(Me.connect_BTN)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents ProgressBar14 As ProgressBar
    Friend WithEvents ProgressBar13 As ProgressBar
    Friend WithEvents ProgressBar9 As ProgressBar
    Friend WithEvents Label9 As Label
    Friend WithEvents ProgressBar10 As ProgressBar
    Friend WithEvents Label10 As Label
    Friend WithEvents ProgressBar11 As ProgressBar
    Friend WithEvents Label11 As Label
    Friend WithEvents ProgressBar12 As ProgressBar
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ProgressBar5 As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents ProgressBar6 As ProgressBar
    Friend WithEvents Label6 As Label
    Friend WithEvents ProgressBar7 As ProgressBar
    Friend WithEvents Label7 As Label
    Friend WithEvents ProgressBar8 As ProgressBar
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label3 As Label
    Friend WithEvents ProgressBar3 As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents ProgressBar4 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Button7 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents refreshCOM_CB_BTN As Button
    Friend WithEvents Timer_LBL As Label
    Friend WithEvents comPort_ComboBox As ComboBox
    Friend WithEvents COMport_LBL As Label
    Friend WithEvents connect_BTN As Button
    Friend WithEvents connecting_Timer As Timer
    Friend WithEvents send_BTN As Button
    Friend WithEvents send_TB As TextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents receivedData_head_LBL As Label
    Friend WithEvents clear_BTN As Button
End Class
