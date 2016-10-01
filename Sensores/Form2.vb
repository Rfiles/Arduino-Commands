Imports System
Imports System.IO.Ports


Public Class Form2

    ' Global variables
    Dim comPORT As String
    Dim receivedData As String = ""
    Dim connected As Boolean = False
    Dim count = 0


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
            If (comPORT <> "") Then
                SerialPort1.Close()
                SerialPort1.PortName = comPORT
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
            Else
                MsgBox("Select a COM port first")
            End If
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
                Debug.Print("Nothing")
                Return ""
            Else
                Return Incoming
                Debug.Print("Data RX" & Incoming)
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
        receivedData = ReceiveSerialData()
        RichTextBox1.Text &= receivedData

        'Debug.Print("timer tick")
        Dim Loop1 As Integer
        Dim rx_len As Integer

        rx_len = Len(receivedData)

        If rx_len > 0 Then
            ' Debug.Print("SIZE:" & rx_len)
            For Loop1 = 0 To rx_len - 1
                'Debug.Print(receivedData(Loop1))
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
            'Debug.Print("Loop End")
        End If
    End Sub


    Function ExecuteCommand()
        ' Debug.Print("ExecuteCommand")
        ' Debug.Print("ID: '" & id_string & "' VALUE: '" & value_string & "'")
        If content = 1 Then            'write
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
        End If

        If content = 2 Then            'read

        End If

        ResetStrings()
    End Function

    Function ResetStrings()
        parse_stat = 0
        content = 0
        value_string = ""
        id_string = ""
        isData = 0
    End Function



    'Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
    '    Debug.Print("Data received event:")
    '    Dim tmp As String
    '    tmp = SerialPort1.ReadExisting()
    '    Debug.Print(tmp)
    '    RichTextBox1.Text &= tmp


    'End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SerialPort1.WriteLine("<LED13=ON>")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SerialPort1.WriteLine("<LED13=OFF>")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SerialPort1.WriteLine("<LED13?>")
    End Sub
End Class