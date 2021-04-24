Public Class CommandProcessing


    Public Sub GetFocuserStatus(ByRef vSerialCon As TrioSerial, ByRef vFocuserData As Focuser.structFocuser)
        vSerialCon.SendSerialText("FOCUSER_GET_STATUS")
        UpdateFocuserStatus(vSerialCon.ReceiveText, vFocuserData)
    End Sub

    Public Function GetStepperDriver(ByRef vSerialCon As TrioSerial)
        Dim vMessage() As String
        vSerialCon.SendSerialText("GET_STEPPER_DRIVER")
        vMessage = Split(vSerialCon.ReceiveText(), "|")
        Return vMessage(1)
    End Function


    Public Function CheckFocuserMove(vMessage As String) As Integer
        Dim vMove() As String = Split(vMessage, "|")
        Return vMove(1)

    End Function

    Public Function CheckTemperature(ByRef vSerialCon As TrioSerial) As String

        Dim vTemp As String
        Dim vReturn As String

        vSerialCon.SendSerialText("GET_TEMP")

        vTemp = vSerialCon.ReceiveText

        Dim vSplitString() As String = Split(vTemp, "|")
        Dim vParams() As String = Split(vSplitString(1), ",")

        Focuser.vTemp = vParams(0)
        Focuser.vHumid = vParams(1)

        vReturn = "Temperature: " + Math.Round(Focuser.vTemp).ToString() + "c, Humidity " + Math.Round(Focuser.vHumid).ToString() + "%"

        Return vReturn

    End Function

    Public Sub GetTempOffset(ByRef vSerialCon As TrioSerial, ByRef vFocuserData As Focuser.structFocuser)
        vSerialCon.SendSerialText("GET_TEMP_OFFSET")
        UpdateTempOffset(vSerialCon.ReceiveText, vFocuserData)
    End Sub

    Public Sub UpdateTempOffset(vFocuserStatus As String, ByRef vFocuserData As Focuser.structFocuser)

        Dim vSplitString() As String = Split(vFocuserStatus, "|")

        Dim vParam As String = vSplitString(1)

        vFocuserData.vTempOffset = vParam

    End Sub

    Public Sub UpdateFocuserStatus(vFocuserStatus As String, ByRef vFocuserData As Focuser.structFocuser)

        Dim vSplitString() As String = Split(vFocuserStatus, "|")

        Dim vParams() As String = Split(vSplitString(1), ",")

        vFocuserData.V_CURRENT_POSITION = vParams(0)
        vFocuserData.V_STEP_MODE = vParams(1)
        vFocuserData.V_MAX_STEPS = vParams(2)
        vFocuserData.V_POWER_HOLD = vParams(3)
        vFocuserData.V_DIRECTTION = vParams(4)
        vFocuserData.V_STEPPER_SPEED = vParams(5)
        vFocuserData.V_STEPPER_WAIT = vParams(6)
        vFocuserData.vRawSerial = vFocuserStatus

        'Form1.MyNetworkServer.DoSimpleASCOMUpdate(vFocuserData.vRawSerial)

    End Sub

    Public Sub DewSetPower(vDewController As Byte, vPower As Byte, ByRef vSerialCon As TrioSerial, ByRef vDewData As Byte(), ByRef vLocked As Boolean)

        vSerialCon.SendSerialText("DEW_SET_POWER|" + vDewController.ToString + "," + vPower.ToString)
        UpdateDewStatus(vSerialCon.ReceiveText, vDewData, vLocked)

    End Sub

    Public Sub LockDewControllers(ByRef vSerialCon As TrioSerial, ByRef vDewData As Byte(), ByRef vLocked As Boolean)

        vSerialCon.SendSerialText("DEW_LOCK_CONTROLLERS")
        UpdateDewStatus(vSerialCon.ReceiveText, vDewData, vLocked)

    End Sub

    Public Sub UnlockDewControllers(ByRef vSerialCon As TrioSerial, ByRef vDewData As Byte(), ByRef vLocked As Boolean)

        vSerialCon.SendSerialText("DEW_UNLOCK_CONTROLLERS")
        UpdateDewStatus(vSerialCon.ReceiveText, vDewData, vLocked)

    End Sub

    Public Sub UpdateDewStatus(vDewStatus As String, ByRef vDewData As Byte(), ByRef vLocked As Boolean)

        'Hack values out of dew data
        Dim vSplitString() As String = Split(vDewStatus, "|")
        Dim vSplitInt() As String

        ' vSplitString(0) = MESSAGE = DEW_STATUS
        ' vSplitString(1) = 0 unlocked 1 = locked
        If vSplitString(1) = "0" Then
            vLocked = False
        End If

        If vSplitString(1) = "1" Then
            vLocked = True
        End If

        vSplitInt = Split(vSplitString(2), ",")
        vDewData(vSplitInt(0)) = vSplitInt(1)

        vSplitInt = Split(vSplitString(3), ",")
        vDewData(vSplitInt(0)) = vSplitInt(1)

        vSplitInt = Split(vSplitString(4), ",")
        vDewData(vSplitInt(0)) = vSplitInt(1)

    End Sub

    Public Sub ResetToDefault(ByRef vSerialCon As TrioSerial, ByRef vFocuserData As Focuser.structFocuser, ByRef vDewData As Byte(), ByRef vLocked As Boolean)
        vSerialCon.SendSerialText("RESET_TO_DEFAULT")
        UpdateDewStatus(vSerialCon.ReceiveText, vDewData, vLocked)
        UpdateFocuserStatus(vSerialCon.ReceiveText, vFocuserData)
    End Sub

    Public Sub SetFocuserData(ByRef vSerialCon As TrioSerial, ByRef vFocuserData As Focuser.structFocuser)

        Dim vCOMMAND As String = ""

        vCOMMAND = "FOCUSER_SET_PARAM|" _
                    + vFocuserData.V_CURRENT_POSITION.ToString _
                    + "," + vFocuserData.V_STEP_MODE.ToString _
                    + "," + vCOMMAND + vFocuserData.V_MAX_STEPS.ToString _
                    + "," + vCOMMAND + vFocuserData.V_POWER_HOLD.ToString _
                    + "," + vCOMMAND + vFocuserData.V_DIRECTTION.ToString _
                    + "," + vCOMMAND + vFocuserData.V_STEPPER_SPEED.ToString _
                    + "," + vCOMMAND + vFocuserData.V_STEPPER_WAIT.ToString

        vSerialCon.SendSerialText(vCOMMAND)
        UpdateFocuserStatus(vSerialCon.ReceiveText, vFocuserData)

    End Sub

    Public Sub SetTempOffset(ByRef vSerialCon As TrioSerial, ByRef vFocuserData As Focuser.structFocuser)

        Dim vCOMMAND As String = ""

        vCOMMAND = "SET_TEMP_OFFSET|" + vFocuserData.vTempOffset.ToString

        vSerialCon.SendSerialText(vCOMMAND)
        UpdateTempOffset(vSerialCon.ReceiveText, vFocuserData)

    End Sub

    Public Sub Halt(ByRef vSerialCon As TrioSerial, ByRef vFocuserData As Focuser.structFocuser)
        vSerialCon.SendSerialText("HALT!")
        Focuser.MyFocuserIsMoving = False
        'might want to deal with auto focuser status that gets sent back.
        'UpdateFocuserStatus(vSerialCon.ReceiveText, vFocuserData)
    End Sub

    Public Sub MoveFocuser(ByRef vSerialCon As TrioSerial, ByRef vFocuserData As Focuser.structFocuser, vPosition As Integer)

        Dim vCOMMAND As String = ""
        Dim vSanePosition As Integer
        Dim vStepsToMove As Integer

        Dim vZeroReached As Boolean = False
        Dim vFocuserMoveValue As Integer

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "***************** GO TO POSITION: " + vPosition.ToString() + " **********************")

        vSanePosition = vPosition

        ' We have been told to move to a position but the focuser just needs to know how many steps to make
        If vPosition < 0 Then
            vSanePosition = 0
            Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "***************** New position is less than zero! **********************")
        End If

        If vPosition > vFocuserData.V_MAX_STEPS Then
            vSanePosition = vFocuserData.V_MAX_STEPS
            Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "***************** New position is greater than max steps! **********************")
        End If

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "***************** Asked for position " + vPosition.ToString() + " **********************")
        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "***************** Going to go to " + vSanePosition.ToString() + " **********************")

        vStepsToMove = vSanePosition - vFocuserData.V_CURRENT_POSITION

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "***************** Current position " + vFocuserData.V_CURRENT_POSITION.ToString() + " **********************")

        Focuser.TRIO_LOG.LogMessage(Focuser.TRIO_LOG_NAME, "***************** Steps to move caluclated at " + vStepsToMove.ToString() + " **********************")

        vCOMMAND = "FOCUSER_MOVE|" + vStepsToMove.ToString

        If vStepsToMove <> 0 Then
            Focuser.MyFocuserIsMoving = True
            vSerialCon.SendSerialText(vCOMMAND)
        End If

        ' We get back a message of steps made, one message per 100 steps
        Focuser.vHaltPressed = False

        While vZeroReached = False

            If Focuser.vHaltPressed = False Then
                vFocuserMoveValue = CheckFocuserMove(vSerialCon.ReceiveText)

                vFocuserData.V_CURRENT_POSITION = vSanePosition - vFocuserMoveValue

                If vFocuserMoveValue = 0 Then
                    vZeroReached = True
                    Focuser.MyFocuserIsMoving = False
                End If
            Else
                Exit While
            End If

            Application.DoEvents()

        End While

        UpdateFocuserStatus(vSerialCon.ReceiveText, vFocuserData)

    End Sub


End Class
