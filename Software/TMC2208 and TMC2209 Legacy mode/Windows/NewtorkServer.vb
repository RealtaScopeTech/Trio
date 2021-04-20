Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.ComponentModel

Public Class NewtorkServer


    ' This is what the server listens to
    Dim vListenPORT As Integer = 45342
    ' This is the servers IP address
    Dim vLocalAddr As Net.IPAddress = Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList(0)
    Dim vListener As New TcpListener(vLocalAddr, vListenPORT)

    Dim vASCOM As TcpClient
    Dim vASCOMAddress As Net.IPAddress = Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList(0)
    Dim vASCOMPort = 45343

    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    Dim components As System.ComponentModel.IContainer

    Public ListenerThread As New Thread(New ThreadStart(AddressOf Listening))

    Private Sub Listening()
        vListener.Start()
    End Sub

    Sub Initialise()

        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles Timer1.Tick

        Dim vMessage As String = ""
        Dim vIncommingPort As Integer
        Dim vIncommingAddress As String
        Dim vClientIsOnCorrectPort As Boolean = True
        Application.DoEvents()

        If vListener.Pending = True Then
            Debug.WriteLine("Networking: Message coming through")

            vASCOM = New TcpClient
            vASCOM = vListener.AcceptTcpClient()

            'We will check vClient is on the right fricken port.
            vIncommingPort = CType(vASCOM.Client.RemoteEndPoint, Net.IPEndPoint).Port
            vIncommingAddress = CType(vASCOM.Client.RemoteEndPoint, Net.IPEndPoint).Address.ToString
            'vASCOMAddress = CType(vASCOM.Client.RemoteEndPoint, Net.IPEndPoint).Address
            'Message is on port
            Debug.WriteLine("Networking: they are ip address " + vIncommingAddress)
            Debug.WriteLine("Networking: they are using port " + vIncommingPort.ToString)

                If vClientIsOnCorrectPort = True Then
                Dim Reader As New StreamReader(vASCOM.GetStream())
                vMessage = Reader.ReadLine()
                    vMessage = vMessage.Replace(vbCr, "").Replace(vbLf, "")
                    Reader.DiscardBufferedData()
                    NetworkMessageHandler(vMessage)
                End If

            End If
    End Sub

    Public Sub SendMessage(vMessage As String)

        Debug.WriteLine("Networking: Sending => " + vMessage)

        Dim vASCOM As New TcpClient(vASCOMAddress.ToString, vASCOMPort)
        Dim vWriter As New StreamWriter(vASCOM.GetStream())

        vWriter.WriteLine(vMessage)
        vWriter.Flush()

    End Sub

    Private Sub NetworkMessageHandler(vMessage As String)

        Debug.WriteLine("Networking: Received => " + vMessage)

        Dim vMessageComplete As Boolean = False
        Dim vSplitString() As String
        Dim vCommand As String = ""
        Dim vParams() As String

        'We will attempt to split data into commands and parameters, they should be seperated by a "|"
        'Multiple Params are comma seperated

        If vMessage.Contains("|") Then
            Debug.WriteLine("Networking: Contains parameters!")
            vSplitString = Split(vMessage, "|")
            vCommand = vSplitString(0)
            vParams = Split(vSplitString(1), ",")
        Else
            Debug.WriteLine("Networking: No parameters!")
            vCommand = vMessage
        End If

        If vCommand = "CONNECT_ME" And vMessageComplete = False Then
            DoConnected()
            vMessageComplete = True
        End If

        If vCommand = "ARE_YOU_CONNECTED?" And vMessageComplete = False Then
            DoAreYouConnected()
            vMessageComplete = True
        End If

        If vCommand = "FOCUSER_GET_STATUS" And vMessageComplete = False Then
            If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
                'Do FOCUSER_GET_STATUS
                Debug.WriteLine("Networking Command: Asked to send focuser status")
                DoGetFocuserStatus()
                vMessageComplete = True
            Else
                DoNotConnected()
            End If

        End If

        If vCommand = "HALT!" And vMessageComplete = False Then
            If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
                'Do FOCUSER_GET_STATUS
                DoHalt()
                DoGetFocuserStatus()
                vMessageComplete = True
            Else
                DoNotConnected()
            End If
        End If

        If vCommand = "FOCUSER_GO_TO_POSITION" And vMessageComplete = False Then
            If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
                Debug.WriteLine("Networking Command: Asked to move => " + vParams(0))
                DoGotToPosition(Convert.ToInt32(vParams(0)))
                DoGetFocuserStatus()
                vMessageComplete = True
            Else
                DoNotConnected()
            End If
        End If

        If vCommand = "GET_TEMP" And vMessageComplete = False Then
            If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
                'Do FOCUSER_GET_STATUS
                Debug.WriteLine("Networking Command: Asked to send Temperature")
                DoGetTemp()
                vMessageComplete = True
            Else
                DoNotConnected()
            End If

        End If


    End Sub

    Private Sub DoConnected()
        vASCOMAddress = CType(vASCOM.Client.RemoteEndPoint, Net.IPEndPoint).Address
        Form1.NetworkIsConnected = True
        Debug.WriteLine("Networking: Connected!")
        Debug.WriteLine(Form1.NetworkIsConnected)
    End Sub

    Private Sub DoAreYouConnected()
        If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
            SendMessage("Yes")
        Else
            SendMessage("No")
        End If
    End Sub

    Private Sub DoGetTemp()
        If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
            SendMessage("TEMP|" + Form1.vTemp.ToString())
        Else
            Debug.WriteLine("Networking: Not Connected?")
        End If
    End Sub

    Public Sub DoSimpleASCOMUpdate(vRawSerial As String)
        If Form1.NetworkIsConnected = True Then
            SendMessage(Form1.MyFocuserData.vRawSerial)
        Else
            Debug.WriteLine("Networking: Not Connected?")
        End If
    End Sub

    Private Sub DoGotToPosition(vNewPosition As Integer)
        Dim vStepsToMove As Integer = vNewPosition - Form1.MyFocuserData.V_CURRENT_POSITION
        Dim vOktoMove As Boolean = True

        If Form1.MyFocuserData.V_CURRENT_POSITION = 0 And vStepsToMove < 0 Then
            vOktoMove = False
        End If

        If Form1.MyFocuserData.V_CURRENT_POSITION = Form1.MyFocuserData.V_MAX_STEPS And vStepsToMove > 0 Then
            vOktoMove = False
        End If

        If vStepsToMove = 0 Then
            vOktoMove = False
        End If

        If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True And vOktoMove = True Then
            Form1.MyCommandProcessing.FocuserMove(vStepsToMove, Form1.MySerialStuff, Form1.MyFocuserData)
            Form1.animateFocuserMoveProgress(Math.Abs(vStepsToMove))
            Form1.MyCommandProcessing.UpdateFocuserStatus(Form1.MySerialStuff.ReceiveText, Form1.MyFocuserData)
            Form1.SubUpdateFocuserStatus()
        End If

    End Sub


    Private Sub DoGetFocuserStatus()
        If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
            Form1.MyCommandProcessing.GetFocuserStatus(Form1.MySerialStuff, Form1.MyFocuserData)
            Form1.SubUpdateFocuserStatus()
            SendMessage(Form1.MyFocuserData.vRawSerial)
        End If
    End Sub

    Private Sub DoHalt()
        If Form1.MySerialStuff.ComIsConnected = True And Form1.MySerialStuff.ComIsFocuser = True Then
            Form1.vHaltPressed = True
            Form1.MyCommandProcessing.Halt(Form1.MySerialStuff, Form1.MyFocuserData)
        End If
    End Sub

    Private Sub DoNotConnected()
        SendMessage("Error|Focuser not connected in app")
    End Sub

    Public Sub testButton(vMessage As String)

        Debug.WriteLine("Test button: => I was clicked")

        Dim vASCOM As New TcpClient(vLocalAddr.ToString, vListenPORT)
        Dim vWriter As New StreamWriter(vASCOM.GetStream())

        vWriter.WriteLine(vMessage)
        vWriter.Flush()

        Debug.WriteLine("Test button: => Message sent")

    End Sub


End Class
