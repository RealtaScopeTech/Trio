Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.ComponentModel

Public Class NewtorkServer

    ' This is what the server listens to
    Dim vListenPORT As Integer = 45343
    ' This is the servers IP address
    Dim vLocalAddr As Net.IPAddress = Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList(0)
    Dim vListener As New TcpListener(vLocalAddr, vListenPORT)

    Dim vTrio As TcpClient
    Dim vTrioAddress As Net.IPAddress = Net.Dns.GetHostEntry(Net.Dns.GetHostName()).AddressList(0)
    Dim vTrioPort = 45342

    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    Dim components As System.ComponentModel.IContainer

    Public ListenerThread As New Thread(New ThreadStart(AddressOf Listening))

    Private Sub Listening()
        vListener.Start()
        Focuser.vIsListening = True
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

            vTrio = New TcpClient
            vTrio = vListener.AcceptTcpClient()

            'We will check vClient is on the right fricken port.
            vIncommingPort = CType(vTrio.Client.RemoteEndPoint, Net.IPEndPoint).Port
            vIncommingAddress = CType(vTrio.Client.RemoteEndPoint, Net.IPEndPoint).Address.ToString
            vTrioAddress = CType(vTrio.Client.RemoteEndPoint, Net.IPEndPoint).Address
            'Message is on port
            Debug.WriteLine("Networking: they are ip address " + vIncommingAddress)
            Debug.WriteLine("Networking: they are using port " + vIncommingPort.ToString)

            If vClientIsOnCorrectPort = True Then
                Dim Reader As New StreamReader(vTrio.GetStream())
                vMessage = Reader.ReadLine()
                vMessage = vMessage.Replace(vbCr, "").Replace(vbLf, "")
                Reader.DiscardBufferedData()
                NetworkMessageHandler(vMessage)
            End If

        End If
    End Sub

    Private Sub SendMessage(vMessage As String)

        Debug.WriteLine("Networking: Sending => " + vMessage)

        Dim vTrio As New TcpClient(vTrioAddress.ToString, vTrioPort)
        Dim vWriter As New StreamWriter(vTrio.GetStream())

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

        If vMessageComplete = "false" And vCommand = "FOCUSER_STATUS" Then
            DoFocuserStatus(vParams)
        End If

        If vMessageComplete = "false" And vCommand = "TEMP" Then
            DoTemp(vSplitString(1))
        End If

    End Sub

    Public Sub GetGonnected()
        SendMessage("CONNECT_ME")
    End Sub

    Public Sub Halt()
        SendMessage("HALT!")
    End Sub


    Public Sub GetFocuserSettings()
        SendMessage("FOCUSER_GET_STATUS")
    End Sub

    Public Sub GetTemp()
        SendMessage("GET_TEMP")
    End Sub

    Public Sub MoveFocuser(vPosition As Integer)
        SendMessage("FOCUSER_GO_TO_POSITION|" + vPosition.ToString)
        Focuser.MyFocuserIsMoving = True
    End Sub

    Public Sub DoFocuserStatus(vParams() As String)
        Focuser.MyFocuserData.V_CURRENT_POSITION = vParams(0)
        Focuser.MyFocuserData.V_STEP_MODE = vParams(1)
        Focuser.MyFocuserData.V_MAX_STEPS = vParams(2)
        Focuser.MyFocuserData.V_POWER_HOLD = vParams(3)
        Focuser.MyFocuserData.V_DIRECTTION = vParams(4)
        Focuser.MyFocuserData.V_STEPPER_SPEED = vParams(5)
        Focuser.MyFocuserData.V_STEPPER_WAIT = vParams(6)
        Focuser.MyFocuserIsMoving = False
    End Sub

    Public Sub DoTemp(TextTemp As String)
        Focuser.vTemp = TextTemp
    End Sub


End Class
