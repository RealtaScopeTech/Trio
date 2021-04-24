Imports System
Imports System.IO.Ports
Imports System.Management

Public Class TrioSerial
    'Define the serial port variable
    Public MyComPort As IO.Ports.SerialPort
    Public ComIsConnected As Boolean = False
    Public ComIsFocuser As Boolean

    Public Sub OpenSerialPort(vComPort As String)

        'MyComPort = My.Computer.Ports.OpenSerialPort(vComPort, 9600, Parity.None, 8, StopBits.One)
        Dim vReceived As String = ""

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "Attempting serial connection")

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

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "COM port " + vComPort + " opened waiting 2000ms")

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
            Focuser.MyCommandProcessing.GetFocuserStatus(Focuser.vMyTrioSerial, Focuser.MyFocuserData)
            Focuser.MyCommandProcessing.CheckTemperature(Focuser.vMyTrioSerial)
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
                Focuser.MyCommandProcessing.GetFocuserStatus(Focuser.vMyTrioSerial, Focuser.MyFocuserData)
                Focuser.MyCommandProcessing.CheckTemperature(Focuser.vMyTrioSerial)
            Else
                MsgBox("The device on this COM port is not a Trio!")
                MyComPort.DiscardInBuffer()
                CloseSerialPort()
            End If
        End If



    End Sub

    Public Sub SendSerialText(vText As String)
        ' Send strings to a serial port.
        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "Serial Port: Sending =>" + vText)
        MyComPort.DiscardOutBuffer()
        MyComPort.DiscardInBuffer()
        MyComPort.WriteLine(vText)

    End Sub

    Public Function ReceiveText() As String

        Dim vReturn As String = ""

        vReturn = MyComPort.ReadLine().Replace(vbCr, "").Replace(vbLf, "")

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "Serial Port: Received =>" + vReturn)

        Return vReturn

    End Function

    Public Sub CloseSerialPort()

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "Closing serial port")

        MyComPort.Close()
        MyComPort.Dispose()
        ComIsConnected = False
        ComIsFocuser = False

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "Serial port closed")

    End Sub

    Public Function CheckCOMPort(vPortName As String) As String

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "Getting fancy names for serial devices")

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

