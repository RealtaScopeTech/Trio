Public Class CommandProcessing

    Public Sub FocuserMove(vStepsToMove As Integer, ByRef vSerialCon As SerialStuff, ByRef vFocuserData As Form1.structFocuser)

        vSerialCon.SendSerialText("FOCUSER_MOVE|" + vStepsToMove.ToString)

    End Sub


    Public Sub GetFocuserStatus(ByRef vSerialCon As SerialStuff, ByRef vFocuserData As Form1.structFocuser)
        vSerialCon.SendSerialText("FOCUSER_GET_STATUS")
        UpdateFocuserStatus(vSerialCon.ReceiveText, vFocuserData)
    End Sub

    Public Function CheckFocuserMove(vMessage As String) As Integer
        Dim vMove() As String = Split(vMessage, "|")
        Return vMove(1)

    End Function

    Public Function CheckTemperature(ByRef vSerialCon As SerialStuff) As String

        Dim vTemp As String
        Dim vReturn As String

        vSerialCon.SendSerialText("GET_TEMP")

        vTemp = vSerialCon.ReceiveText

        Dim vSplitString() As String = Split(vTemp, "|")
        Dim vParams() As String = Split(vSplitString(1), ",")

        Form1.vTemp = vParams(0)

        vReturn = "Temperature: " + vParams(0) + "c, Humidity " + vParams(1) + "%"

        Return vReturn

    End Function

    Public Sub GetTempOffset(ByRef vSerialCon As SerialStuff, ByRef vFocuserData As Form1.structFocuser)
        vSerialCon.SendSerialText("GET_TEMP_OFFSET")
        UpdateTempOffset(vSerialCon.ReceiveText, vFocuserData)
    End Sub

    Public Sub UpdateTempOffset(vFocuserStatus As String, ByRef vFocuserData As Form1.structFocuser)

        Dim vSplitString() As String = Split(vFocuserStatus, "|")

        Dim vParam As String = vSplitString(1)

        vFocuserData.vTempOffset = vParam

    End Sub

    Public Sub UpdateFocuserStatus(vFocuserStatus As String, ByRef vFocuserData As Form1.structFocuser)

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

    Public Sub DewSetPower(vDewController As Byte, vPower As Byte, ByRef vSerialCon As SerialStuff, ByRef vDewData As Byte(), ByRef vLocked As Boolean)

        vSerialCon.SendSerialText("DEW_SET_POWER|" + vDewController.ToString + "," + vPower.ToString)
        UpdateDewStatus(vSerialCon.ReceiveText, vDewData, vLocked)

    End Sub

    Public Sub LockDewControllers(ByRef vSerialCon As SerialStuff, ByRef vDewData As Byte(), ByRef vLocked As Boolean)

        vSerialCon.SendSerialText("DEW_LOCK_CONTROLLERS")
        UpdateDewStatus(vSerialCon.ReceiveText, vDewData, vLocked)

    End Sub

    Public Sub UnlockDewControllers(ByRef vSerialCon As SerialStuff, ByRef vDewData As Byte(), ByRef vLocked As Boolean)

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

    Public Sub ResetToDefault(ByRef vSerialCon As SerialStuff, ByRef vFocuserData As Form1.structFocuser, ByRef vDewData As Byte(), ByRef vLocked As Boolean)
        vSerialCon.SendSerialText("RESET_TO_DEFAULT")
        UpdateDewStatus(vSerialCon.ReceiveText, vDewData, vLocked)
        UpdateFocuserStatus(vSerialCon.ReceiveText, vFocuserData)
    End Sub

    Public Sub SetFocuserData(ByRef vSerialCon As SerialStuff, ByRef vFocuserData As Form1.structFocuser)

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

    Public Sub SetTempOffset(ByRef vSerialCon As SerialStuff, ByRef vFocuserData As Form1.structFocuser)

        Dim vCOMMAND As String = ""

        vCOMMAND = "SET_TEMP_OFFSET|" + vFocuserData.vTempOffset.ToString

        vSerialCon.SendSerialText(vCOMMAND)
        UpdateTempOffset(vSerialCon.ReceiveText, vFocuserData)

    End Sub

    Public Sub Halt(ByRef vSerialCon As SerialStuff, ByRef vFocuserData As Form1.structFocuser)
        vSerialCon.SendSerialText("HALT!")
    End Sub

End Class
