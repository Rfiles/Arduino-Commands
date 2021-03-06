﻿Imports System
Imports System.IO.Ports


Public Class Form2

    ' Global variables
    Dim comPORT As String
    Dim receivedData As String = ""
    Dim connected As Boolean = False
    Dim count = 0
    Dim parse_loop As Boolean = False


    Dim id_string As String
    Dim value_string As String
    Dim parse_stat As Single
    Dim content As Single
    Dim isData As Single
    Dim byterx As String


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = False
        populateCOMport()
        Label17.BackColor = Color.Blue

    End Sub

    Private Sub refreshCOM_BTN_Click(sender As Object, e As EventArgs) Handles refreshCOM_CB_BTN.Click
        SerialPort1.Close()
        populateCOMport()
    End Sub

    Private Sub populateCOMport()
        comPORT = ""
        comPort_ComboBox.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            comPort_ComboBox.Items.Add(sp)
        Next
    End Sub

    Private Sub comPort_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comPort_ComboBox.SelectedIndexChanged
        If (comPort_ComboBox.SelectedItem <> "") Then
            comPORT = comPort_ComboBox.SelectedItem
        End If
    End Sub

    Private Sub connect_BTN_Click(sender As Object, e As EventArgs) Handles connect_BTN.Click
        comPORT = comPort_ComboBox.SelectedItem
        If (connect_BTN.Text = "Connect") Then
            If (comPORT = "") Then
                comPORT = "COM3"
            End If
            SerialPort1.Close()
            SerialPort1.PortName = comPORT
            'Debug.Print("COM: " & comPORT)
            SerialPort1.BaudRate = 115200
            SerialPort1.DataBits = 8
            SerialPort1.Parity = Parity.None
            SerialPort1.StopBits = StopBits.One
            SerialPort1.Handshake = Handshake.None
            SerialPort1.Encoding = System.Text.Encoding.Default
            SerialPort1.ReadTimeout = 10000

            SerialPort1.Open()

            'See if the Arduino is there
            count = 0
                'SerialPort1.WriteLine("<HELLO>")
                connect_BTN.Text = "Connecting..."
                connecting_Timer.Enabled = True
                'Else
                '    MsgBox("Select a COM port first")
                'End If
            Else
            'connect_BTN.Text = "Dis-connect"
            'close the connection a reset the button and timer label
            Timer1.Enabled = False
            Timer_LBL.Text = "Timer: OFF"
            SerialPort1.Close()
            connected = False
            connect_BTN.Text = "Connect"
            populateCOMport()
        End If
    End Sub

    Private Sub connecting_Timer_Tick(sender As Object, e As EventArgs) Handles connecting_Timer.Tick
        connecting_Timer.Enabled = False
        count = count + 1

        If (count <= 8) Then
            'receivedData = receivedData & ReceiveSerialData()

            'If receivedData = "<BOOT=DONE>" Then
            'if we get an HELLO from the Arduino then we are connected
            connected = True
                connect_BTN.Text = "Disconnect"
                Timer1.Enabled = True
                Timer_LBL.Text = "Timer: ON"
            'receivedData = ReceiveSerialData()
            'receivedData = ""
            SerialPort1.WriteLine("<var1=123>")
            'Else
            'start the timer again And keep waiting for a signal from the Arduino
            'connecting_Timer.Enabled = True
            'End If


        Else
            'time out (8 * 250 = 2 seconds)
            RichTextBox1.Text &= vbCrLf & "ERROR" & vbCrLf & "Can not connect" & vbCrLf
            connect_BTN.Text = "Connect"
            populateCOMport()
        End If



    End Sub


    'Add the start and end markers to the contents of the text box and then send to the Arduino.
    'Does not clear the contents
    Private Sub send_BTN_Click(sender As Object, e As EventArgs) Handles send_BTN.Click
        If (connected) Then
            Dim tmp As String
            tmp = "<" & send_TB.Text & ">"
            SerialPort1.WriteLine(tmp)
        End If
    End Sub

    Function ReceiveSerialData() As String
        Dim Incoming As String
        Try
            Incoming = SerialPort1.ReadExisting()
            If Incoming Is Nothing Then
                'Debug.Print("Nothing")
                Return ""
            Else
                Return Incoming
                ' Debug.Print("Data RX" & Incoming)
            End If
        Catch ex As TimeoutException
            Debug.Print("Error: Serial Port read timed out.")
        End Try

    End Function

    'Clear the RecievedData test box
    Private Sub clear_BTN_Click(sender As Object, e As EventArgs) Handles clear_BTN.Click
        RichTextBox1.Text = ""
    End Sub

    'After a connection is made the main timer waits for data from the Arduino
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim Loop1 As Integer
        Dim rx_len As Integer
        'Debug.Print("timer tick")
        If parse_loop = False Then
            receivedData = ReceiveSerialData()
            rx_len = Len(receivedData)
        End If

        'Debug.Print("1:" & receivedData)
        If receivedData <> "" Then
            parse_loop = True
            RichTextBox1.ForeColor = Color.DarkGreen
            RichTextBox1.Text &= vbCrLf & "RX: " & receivedData

            For Loop1 = 0 To rx_len - 1
                Debug.Print(receivedData(Loop1) & " <- " & Loop1)
                Select Case (receivedData(Loop1))
                    Case "<"
                        parse_stat = 1   'command start
                        isData = 0
                      '  Debug.Print("START")
                    Case "="
                        content = 1 ' Write()
                        isData = 0
                      '  Debug.Print("WRITE")
                    Case "?"
                        content = 2 ' read
                        isData = 0
                      '  Debug.Print("READ")
                    Case ">"
                        If parse_stat = 1 Then
                            parse_stat = 2   ' command End; execute
                            '     Debug.Print("STOP")
                        Else
                            ResetStrings()   ' command didnt start; abort
                        End If
                        isData = 0
                    Case vbCr                'ignore
                    Case vbLf                'ignore
                    Case Else
                        isData = 1 ' its data
                        'Debug.Print("DATA")
                End Select

                If parse_stat = 1 And content = 0 And isData = 1 Then id_string &= receivedData(Loop1)     'its ID
                If parse_stat = 1 And content > 0 And isData = 1 Then value_string &= receivedData(Loop1)  'its Value
                If parse_stat = 2 And content = 0 Then ResetStrings()                         'bad command (sem read ou write)
                If parse_stat = 2 And content > 0 And isData = 0 Then ExecuteCommand()        'command done
            Next
            parse_loop = False
            receivedData = ""
            rx_len = 0
            'Debug.Print("Loop End")
        End If
    End Sub

    Function ResetStrings()
        parse_stat = 0
        content = 0
        value_string = ""
        id_string = ""
        isData = 0
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Send_Data("<LED13=ON>")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Send_Data("<LED13=OFF>")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Send_Data("<LED13?>")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Send_Data("<COLOR?>")
    End Sub

    Function ExecuteCommand()
        ' Debug.Print("ExecuteCommand")
        ' Debug.Print("ID: '" & id_string & "' VALUE: '" & value_string & "'")

        If content = 1 Then            'write (envio de info para o computador)
            '##########################################################################
            If id_string = "LED13" Then
                If value_string = "ON" Then
                    Debug.Print("ARDUINO REPORTED LED 13 IS: ON")
                    Label17.BackColor = Color.Chartreuse
                    Label17.Text = "ON"
                End If
                If (value_string = "OFF") Then
                    Debug.Print("ARDUINO REPORTED LED 13 IS: OFF")
                    Label17.BackColor = Color.Red
                    Label17.Text = "OFF"
                End If
            End If
            '##########################################################################
            If id_string = "BOOT" Then
                Debug.Print("Arduino Reeniciou")
                TextBox16.Text = "VALID!"
            End If
            '##########################################################################
            If id_string = "COLOR_R_RAW" Then
                'If ProgressBar1.Maximum < Val(value_string) Then ProgressBar1.Maximum = Val(value_string)
                ProgressBar1.Value = Val(value_string)
                Debug.Print("Raw Color R: " & Val(value_string))
            End If
            If id_string = "COLOR_G_RAW" Then
                'If ProgressBar2.Maximum < Val(value_string) Then ProgressBar2.Maximum = Val(value_string)
                ProgressBar2.Value = Val(value_string)
                Debug.Print("Raw Color G: " & Val(value_string))
            End If
            If id_string = "COLOR_B_RAW" Then
                'If ProgressBar3.Maximum < Val(value_string) Then ProgressBar3.Maximum = Val(value_string)
                ProgressBar3.Value = Val(value_string)
                Debug.Print("Raw Color B: " & Val(value_string))
            End If
            If id_string = "COLOR_C_RAW" Then
                'If ProgressBar4.Maximum < Val(value_string) Then ProgressBar4.Maximum = Val(value_string)
                ProgressBar4.Value = Val(value_string)
                Debug.Print("Raw Color C: " & Val(value_string))
            End If
            If id_string = "COLOR_R_COMP" Then
                'If ProgressBar1.Maximum < Val(value_string) Then ProgressBar1.Maximum = Val(value_string)
                ProgressBar6.Value = Val(value_string)
                Debug.Print("Comp Color R: " & Val(value_string))
            End If
            If id_string = "COLOR_G_COMP" Then
                'If ProgressBar2.Maximum < Val(value_string) Then ProgressBar2.Maximum = Val(value_string)
                ProgressBar5.Value = Val(value_string)
                Debug.Print("Comp Color G: " & Val(value_string))
            End If
            If id_string = "COLOR_B_COMP" Then
                'If ProgressBar3.Maximum < Val(value_string) Then ProgressBar3.Maximum = Val(value_string)
                ProgressBar7.Value = Val(value_string)
                Debug.Print("Comp Color B: " & Val(value_string))
            End If
            If id_string = "COLOR_C_COMP" Then
                'If ProgressBar4.Maximum < Val(value_string) Then ProgressBar4.Maximum = Val(value_string)
                ProgressBar8.Value = Val(value_string)
                Debug.Print("Comp Color C: " & Val(value_string))
            End If
            '##########################################################################
            If id_string = "RTC_H" Then
                TextBox3.Text = Val(value_string)
            End If
            If id_string = "RTC_N" Then
                TextBox4.Text = Val(value_string)
            End If
            If id_string = "RTC_S" Then
                TextBox5.Text = Val(value_string)
            End If
            If id_string = "RTC_Y" Then
                TextBox8.Text = Val(value_string)
            End If
            If id_string = "RTC_M" Then
                TextBox7.Text = Val(value_string)
            End If
            If id_string = "RTC_D" Then
                TextBox6.Text = Val(value_string)
            End If
            If id_string = "RTC_W" Then
                TextBox9.Text = value_string
            End If

            '##########################################################################
            If id_string = "UV_L" Then
                TextBox10.Text = Val(value_string)
            End If
            '##########################################################################
            If id_string = "BME_PRESS" Then
                TextBox11.Text = Val(value_string)
            End If
            If id_string = "BME_TEMP" Then
                TextBox12.Text = Val(value_string)
            End If
            If id_string = "BME_HUM" Then
                TextBox13.Text = Val(value_string)
            End If
            If id_string = "BME_CALT" Then
                TextBox14.Text = Val(value_string)
            End If
            If id_string = "BME_DEWP" Then
                TextBox15.Text = Val(value_string)
            End If

            '##########################################################################
            If id_string = "ACC_X" Then
                TextBox17.Text = Val(value_string)
            End If
            If id_string = "ACC_Y" Then
                TextBox18.Text = Val(value_string)
            End If
            If id_string = "ACC_Z" Then
                TextBox19.Text = Val(value_string)
            End If
            If id_string = "GRA_X" Then
                TextBox22.Text = Val(value_string)
            End If
            If id_string = "GRA_Y" Then
                TextBox21.Text = Val(value_string)
            End If
            If id_string = "GRA_Z" Then
                TextBox20.Text = Val(value_string)
            End If

            '##########################################################################
            If id_string = "LIGHT_LUX" Then
                TextBox23.Text = Val(value_string)
            End If
            '##########################################################################





        End If

        If content = 2 Then            'read (Pedidos de info ao computador)

        End If

        ResetStrings()
    End Function

    Function Send_Data(Comando As String)
        If connected = True Then
            SerialPort1.WriteLine(Comando)
            RichTextBox1.ForeColor = Color.Red
            RichTextBox1.Text &= vbCrLf & "TX: " & Comando
        End If

    End Function

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.SelectionStart = RichTextBox1.Text.Length
        RichTextBox1.ScrollToCaret()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.DtrEnable = True
        SerialPort1.DtrEnable = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Send_Data("<RTC?>")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Send_Data("<UV?>")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Send_Data("<BME?>")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Send_Data("<MPU?>")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Send_Data("<LIGHT?>")
    End Sub
End Class