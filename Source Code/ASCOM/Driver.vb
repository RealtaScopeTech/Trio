'tabs=4
' --------------------------------------------------------------------------------
' TODO fill in this information for your driver, then remove this line!
'
' ASCOM Focuser driver for RealtaTrio
'
' Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
'				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
'				erat, sed diam voluptua. At vero eos et accusam et justo duo 
'				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
'				sanctus est Lorem ipsum dolor sit amet.
'
' Implements:	ASCOM Focuser interface version: 1.0
' Author:		(XXX) Your N. Here <your@email.here>
'
' Edit Log:
'
' Date			Who	Vers	Description
' -----------	---	-----	-------------------------------------------------------
' dd-mmm-yyyy	XXX	1.0.0	Initial edit, from Focuser template
' ---------------------------------------------------------------------------------
'
'
' Your driver's ID is ASCOM.RealtaTrio.Focuser
'
' The Guid attribute sets the CLSID for ASCOM.DeviceName.Focuser
' The ClassInterface/None attribute prevents an empty interface called
' _Focuser from being created and used as the [default] interface
'

' This definition is used to select code that's only applicable for one device type
#Const Device = "Focuser"

Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Text
Imports ASCOM
Imports ASCOM.Astrometry
Imports ASCOM.Astrometry.AstroUtils
Imports ASCOM.DeviceInterface
Imports ASCOM.Utilities

<Guid("7be30cc3-ebbf-4d3a-aba7-4da0843d592f")>
<ClassInterface(ClassInterfaceType.None)>
Public Class Focuser

    ' The Guid attribute sets the CLSID for ASCOM.RealtaTrio.Focuser
    ' The ClassInterface/None attribute prevents an empty interface called
    ' _RealtaTrio from being created and used as the [default] interface

    ' TODO Replace the not implemented exceptions with code to implement the function or
    ' throw the appropriate ASCOM exception.
    '
    Implements IFocuserV3

    '
    ' Driver ID and descriptive string that shows in the Chooser
    '
    Friend Shared driverID As String = "ASCOM.RealtaTrio.Focuser"
    Private Shared driverDescription As String = "RealtaTrio Focuser"

    Friend Shared comPortProfileName As String = "COM Port" 'Constants used for Profile persistence
    Friend Shared traceStateProfileName As String = "Trace Level"
    Friend Shared comPortDefault As String = "XXXX"
    Friend Shared traceStateDefault As String = "False"

    Friend Shared comPort As String = "XXXX" ' Variables to hold the current device configuration
    Friend Shared traceState As Boolean

    Private connectedState As Boolean ' Private variable to hold the connected state
    Private utilities As Util ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)

    Friend Shared vMyTrioSerial As TrioSerial

    Friend Shared TRIO_LOG As ASCOM.Utilities.TraceLogger 'Define cariable as type ILogger
    Friend Shared TRIO_LOG_NAME As String = "TRIO_LOG"

    Public Structure structFocuser
        Public V_CURRENT_POSITION As Integer
        Public V_STEP_MODE As Byte
        Public V_MAX_STEPS As Integer
        Public V_POWER_HOLD As Byte
        Public V_DIRECTTION As Byte
        Public V_STEPPER_SPEED As Byte
        Public V_STEPPER_WAIT As Byte
        Public vSmallSteps As Integer
        Public vMediumSteps As Integer
        Public vLargeSteps As Integer
        Public vRawSerial As String
        Public vTempOffset As Integer
    End Structure

    Friend Shared vTemp As Double = 20.0
    Friend Shared vHumid As Double = 40.0
    'Friend Shared vMoving As Boolean = False
    Friend Shared vHaltPressed As Boolean = False

    Friend Shared MyFocuserData As structFocuser
    Friend Shared MyFocuserIsMoving As Boolean = False
    Friend Shared vIsListening = False
    Friend Shared MyCommandProcessing As New CommandProcessing
    Friend WithEvents tempTimer As System.Windows.Forms.Timer

    Private components As System.ComponentModel.IContainer

    ' Constructor - Must be public for COM registration!
    '
    Public Sub New()

        ReadProfile() ' Read device configuration from the ASCOM Profile store
        TL = New TraceLogger("Focuser", "RealtaTrio")
        TL.Enabled = traceState
        TL.LogMessage("Focuser", "Starting initialisation")

        utilities = New Util() ' Initialise util object
        astroUtilities = New AstroUtils 'Initialise new astro utilities object
        vMyTrioSerial = New TrioSerial

        TRIO_LOG = New ASCOM.Utilities.TraceLogger("", "TestLogger")
        TRIO_LOG.Enabled = False
        TRIO_LOG.LogMessage(TRIO_LOG_NAME, "TRIO LOG STARTED")

        MyFocuserData.V_CURRENT_POSITION = 5000
        MyFocuserData.V_MAX_STEPS = 10000
        vTemp = 20.0

        connectedState = False

        Me.components = New System.ComponentModel.Container
        Me.tempTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tempTimer.Enabled = True
        Me.tempTimer.Interval = TimeSpan.FromSeconds(30).TotalMilliseconds


    End Sub

    Private Sub tempTimer_Tick(sender As Object, e As EventArgs) Handles tempTimer.Tick
        Dim vVerboseTempHumid As String

        If vMyTrioSerial.ComIsConnected = True And vMyTrioSerial.ComIsFocuser = True And MyFocuserIsMoving = False Then
            vVerboseTempHumid = MyCommandProcessing.CheckTemperature(vMyTrioSerial)
        End If
    End Sub

    '
    ' PUBLIC COM INTERFACE IFocuserV3 IMPLEMENTATION
    '

#Region "Common properties and methods"
    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements IFocuserV3.SetupDialog

        TRIO_LOG.LogMessage(TRIO_LOG_NAME, "Setup dialog opened")

        Using F As SetupDialogForm = New SetupDialogForm()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                WriteProfile() ' Persist device configuration values to the ASCOM Profile store
            End If
        End Using

    End Sub

    Public ReadOnly Property SupportedActions() As ArrayList Implements IFocuserV3.SupportedActions
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for supported custom actions")
            Return New ArrayList()
        End Get
    End Property

    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements IFocuserV3.Action
        Throw New ActionNotImplementedException("Action " & ActionName & " is not supported by this driver")
    End Function

    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements IFocuserV3.CommandBlind
        CheckConnected("CommandBlind")
        ' TODO The optional CommandBlind method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBlind must send the supplied command to the mount And return immediately without waiting for a response

        Throw New MethodNotImplementedException("CommandBlind")
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements IFocuserV3.CommandBool
        CheckConnected("CommandBool")
        ' TODO The optional CommandBool method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandBool must send the supplied command to the mount, wait for a response and parse this to return a True Or False value

        ' Dim retString as String = CommandString(command, raw) ' Send the command And wait for the response
        ' Dim retBool as Boolean = XXXXXXXXXXXXX ' Parse the returned string And create a boolean True / False value
        ' Return retBool ' Return the boolean value to the client

        Throw New MethodNotImplementedException("CommandBool")
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String _
        Implements IFocuserV3.CommandString
        CheckConnected("CommandString")
        ' TODO The optional CommandString method should either be implemented OR throw a MethodNotImplementedException
        ' If implemented, CommandString must send the supplied command to the mount and wait for a response before returning this to the client

        Throw New MethodNotImplementedException("CommandString")
    End Function

    Public Property Connected() As Boolean Implements IFocuserV3.Connected
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for Connected")
            Return IsConnected
        End Get
        Set(value As Boolean)
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked to do something connecty")
            If value = IsConnected Then
                Return
            End If

            If value Then
                connectedState = True
                TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked to connect to focuser")
                MsgBox("Please connect to focuser")
                Using F As SetupDialogForm = New SetupDialogForm()
                    Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
                    If result = DialogResult.OK Then
                        WriteProfile()
                    End If
                End Using
            Else
                connectedState = False
                TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked to disconnect")
                If vMyTrioSerial.ComIsConnected = True Then
                    Focuser.vMyTrioSerial.CloseSerialPort()
                End If
            End If
        End Set
    End Property

    Public ReadOnly Property Description As String Implements IFocuserV3.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for driver description")
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverInfo As String Implements IFocuserV3.DriverInfo
        Get
            Dim m_version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
            ' TODO customise this driver description
            Dim s_driverInfo As String = "Information about the driver itself. Version: " + m_version.Major.ToString() + "." + m_version.Minor.ToString()
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for driver info")
            Return s_driverInfo
        End Get
    End Property

    Public ReadOnly Property DriverVersion() As String Implements IFocuserV3.DriverVersion
        Get
            ' Get our own assembly and report its version number
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for driver version")
            Return Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2)
        End Get
    End Property

    Public ReadOnly Property InterfaceVersion() As Short Implements IFocuserV3.InterfaceVersion
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for Interface version")
            Return 3
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IFocuserV3.Name
        Get
            Dim s_name As String = "Realta Trio"
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for device name")
            Return s_name
        End Get
    End Property

    Public Sub Dispose() Implements IFocuserV3.Dispose

        TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for device to close")

        If vMyTrioSerial.ComIsConnected = True Then
            Focuser.vMyTrioSerial.CloseSerialPort()
        End If


        ' Clean up the trace logger and util objects
        TL.Enabled = False
        TL.Dispose()
        TL = Nothing
        utilities.Dispose()
        utilities = Nothing
        astroUtilities.Dispose()
        astroUtilities = Nothing
    End Sub

#End Region

#Region "IFocuser Implementation"

    Private focuserPosition As Integer = 0 ' Class level variable to hold the current focuser position
    Private Const focuserSteps As Integer = 1000000

    Public ReadOnly Property Absolute() As Boolean Implements IFocuserV3.Absolute
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked if device is absolute: It is")
            Return True ' This is an absolute focuser
        End Get
    End Property

    Public Sub Halt() Implements IFocuserV3.Halt
        TRIO_LOG.LogMessage(TRIO_LOG_NAME, "HALT!")
        vHaltPressed = True
        MyCommandProcessing.Halt(vMyTrioSerial, MyFocuserData)
        MyFocuserIsMoving = False
    End Sub

    Public ReadOnly Property IsMoving() As Boolean Implements IFocuserV3.IsMoving
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked if device is moving")
            Return MyFocuserIsMoving
        End Get
    End Property

    Public Property Link() As Boolean Implements IFocuserV3.Link
        Get
            TL.LogMessage("Link Get", Me.Connected.ToString())
            Return Me.Connected ' Direct function to the connected method, the Link method is just here for backwards compatibility
        End Get
        Set(value As Boolean)
            TL.LogMessage("Link Set", value.ToString())
            Me.Connected = value ' Direct function to the connected method, the Link method is just here for backwards compatibility
        End Set
    End Property

    Public ReadOnly Property MaxIncrement() As Integer Implements IFocuserV3.MaxIncrement
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for max increment")
            Return 1000
        End Get
    End Property

    Public ReadOnly Property MaxStep() As Integer Implements IFocuserV3.MaxStep
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked for max steps")
            Return MyFocuserData.V_MAX_STEPS
        End Get
    End Property

    Public Sub Move(Position As Integer) Implements IFocuserV3.Move
        TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked focuser to move")
        MyCommandProcessing.MoveFocuser(vMyTrioSerial, MyFocuserData, Position)
        focuserPosition = MyFocuserData.V_CURRENT_POSITION  ' Set the focuser position
    End Sub

    Public ReadOnly Property Position() As Integer Implements IFocuserV3.Position
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked focuser position")
            Return MyFocuserData.V_CURRENT_POSITION ' Return the focuser position
        End Get
    End Property

    Public ReadOnly Property StepSize() As Double Implements IFocuserV3.StepSize
        Get
            TL.LogMessage("StepSize Get", "Not implemented")
            Throw New ASCOM.PropertyNotImplementedException("StepSize", False)
        End Get
    End Property

    Public Property TempComp() As Boolean Implements IFocuserV3.TempComp
        Get
            TL.LogMessage("TempComp Get", False.ToString())
            Return False
        End Get
        Set(value As Boolean)
            TL.LogMessage("TempComp Set", "Not implemented")
            Throw New ASCOM.PropertyNotImplementedException("TempComp", True)
        End Set
    End Property

    Public ReadOnly Property TempCompAvailable() As Boolean Implements IFocuserV3.TempCompAvailable
        Get
            TL.LogMessage("TempCompAvailable Get", False.ToString())
            Return False ' Temperature compensation is not available in this driver
        End Get
    End Property

    Public ReadOnly Property Temperature() As Double Implements IFocuserV3.Temperature
        Get
            TRIO_LOG.LogMessage(TRIO_LOG_NAME, "ASCOM app asked temperature")
            Return vTemp
        End Get
    End Property

#End Region

#Region "Private properties and methods"
    ' here are some useful properties and methods that can be used as required
    ' to help with

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Focuser"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()>
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()>
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected As Boolean
        Get
            ' TODO check that the driver hardware connection exists and is connected to the hardware
            If vMyTrioSerial.ComIsFocuser = True And vMyTrioSerial.ComIsConnected = True Then
                connectedState = True
            Else
                connectedState = False
            End If

            Return connectedState

        End Get
    End Property

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

    ''' <summary>
    ''' Read the device configuration from the ASCOM Profile store
    ''' </summary>
    Friend Sub ReadProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Focuser"
            traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, String.Empty, traceStateDefault))
            comPort = driverProfile.GetValue(driverID, comPortProfileName, String.Empty, comPortDefault)
        End Using
    End Sub

    ''' <summary>
    ''' Write the device configuration to the  ASCOM  Profile store
    ''' </summary>
    Friend Sub WriteProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Focuser"
            driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString())
            driverProfile.WriteValue(driverID, comPortProfileName, comPort.ToString())
        End Using

    End Sub

#End Region

End Class
