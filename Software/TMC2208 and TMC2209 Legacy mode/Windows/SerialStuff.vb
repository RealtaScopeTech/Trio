Imports System
Imports System.IO.Ports
Imports System.Management

Public Class SerialStuff

    Public MyComPort As IO.Ports.SerialPort
    Public ComIsConnected As Boolean = False
    Public ComIsFocuser As Boolean

    Public Sub OpenSerialPort(vComPort As String)

        'MyComPort = My.Computer.Ports.OpenSerialPort(vComPort, 9600, Parity.None, 8, StopBits.One)
        Dim vReceived As String = ""

        MyComPort = My.Computer.Ports.OpenSerialPort(vComPort)
        MyComPort.BaudRate = 9600
        MyComPort.Parity = Parity.None
        MyComPort.DataBits = 8
        MyComPort.StopBits = StopBits.One
        MyComPort.Handshake = Handshake.None
        MyComPort.Encoding = System.Text.Encoding.Default
        MyComPort.DtrEnable = False
        MyComPort.RtsEnable = False
        MyComPort.ReadTimeout = 5000

        ComIsConnected = True

        MyComPort.DiscardInBuffer()
        MyComPort.DiscardOutBuffer()

        ' Let the damn thing wake up
        Threading.Thread.Sleep(2000)

        'Send message to find out if this is genuine trio focuser
        SendSerialText("GET_DEVICE_NAME")

        vReceived = ReceiveText()

        On Error Resume Next

        If vReceived = "DEVICE_NAME|Realta: Focuser Three" Then
            ComIsFocuser = True
            MyComPort.DiscardInBuffer()
            MyComPort.ReadTimeout = 10000
        End If

        ' Weird timeout of first ReceiveText()
        ' Try again if didn't work.
        If ComIsFocuser = False Then

            MsgBox("Timeout connecting trying again!")

            SendSerialText("GET_DEVICE_NAME")

            vReceived = ReceiveText()

            If vReceived = "DEVICE_NAME|Realta: Focuser Three" Then
                ComIsFocuser = True
                MyComPort.DiscardInBuffer()
                MyComPort.ReadTimeout = 10000
            Else
                MsgBox("The device on this COM port is not a Trio!")
                MyComPort.DiscardInBuffer()
                CloseSerialPort()
            End If
        End If



    End Sub

    Public Sub SendSerialText(vText As String)
        ' Send strings to a serial port.
        Debug.WriteLine("Serial Port: Sending =>" + vText)
        MyComPort.DiscardOutBuffer()
        MyComPort.DiscardInBuffer()
        MyComPort.WriteLine(vText)

    End Sub

    Public Function ReceiveText() As String

        Dim vReturn As String = ""

        vReturn = MyComPort.ReadLine().Replace(vbCr, "").Replace(vbLf, "")

        Debug.WriteLine("Serial Port: Received =>" + vReturn)

        Return vReturn

    End Function

    Public Sub CloseSerialPort()

        MyComPort.Close()
        MyComPort.Dispose()
        ComIsConnected = False
        ComIsFocuser = False

    End Sub

    Public Function CheckCOMPort(vPortName As String) As String

        Dim Scope As New ManagementScope("\\.\ROOT\CIMV2")

        Dim vDescription As String = ""

        'Get a result of WML query 
        Dim Query As New ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE Name Like '%" + vPortName + "%' AND PNPClass = 'Ports'")

        'Create object searcher
        Dim Searcher As New ManagementObjectSearcher(Scope, Query)

        'Get a collection of WMI objects
        Dim queryCollection As ManagementObjectCollection = Searcher.Get

        'Enumerate wmi object 
        For Each mObject As ManagementObject In queryCollection
            vDescription = mObject("Description")

        Next

        Return vDescription

    End Function

End Class

