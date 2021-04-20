Public Class SettingsForm
    Private Sub bttnReset_Click(sender As Object, e As EventArgs) Handles bttnReset.Click

        Dim WarningMsg As Integer
        WarningMsg = MsgBox("Confirm Reset!", vbOKCancel + vbExclamation, "Are you sure you want to set the trio back to default settings?")
        If WarningMsg = 1 Then

            Form1.MyCommandProcessing.ResetToDefault(Form1.MySerialStuff, Form1.MyFocuserData, Form1.MyDewPower, Form1.MyDewLocked)
            Form1.SubUpdateDewStatus()
            Form1.SubUpdateFocuserStatus()

            NumericCurrentPosition.Value = Convert.ToInt32(Form1.lblFocuserCurrentPosition.Text)

            ComboStepModes.SelectedIndex = Form1.MyFocuserData.V_STEP_MODE

            NumericMaxSteps.Value = Form1.MyFocuserData.V_MAX_STEPS

            If Form1.MyFocuserData.V_POWER_HOLD = 0 Then
                CheckPowerHold.Checked = True
            Else
                CheckPowerHold.Checked = False
            End If

            If Form1.MyFocuserData.V_DIRECTTION = 1 Then
                CheckReverseDirection.Checked = False
            Else
                CheckReverseDirection.Checked = True
            End If

            TrackFocuserSpeed.Value = Form1.MyFocuserData.V_STEPPER_SPEED

            Form1.MyFocuserData.vSmallSteps = 10
            Form1.MyFocuserData.vMediumSteps = 100
            Form1.MyFocuserData.vLargeSteps = 1000

            NumericSmall.Value = Form1.MyFocuserData.vSmallSteps
            NumericMedium.Value = Form1.MyFocuserData.vMediumSteps
            NumericLarge.Value = Form1.MyFocuserData.vLargeSteps

            Close()

        End If

    End Sub

    Private Sub NumericMaxSteps_ValueChanged(sender As Object, e As EventArgs) Handles NumericMaxSteps.ValueChanged
        If NumericCurrentPosition.Value > NumericMaxSteps.Value Then
            NumericCurrentPosition.Value = NumericMaxSteps.Value
        End If
        NumericCurrentPosition.Maximum = NumericMaxSteps.Value
    End Sub

    Private Sub bttnSaveStepbttns_Click(sender As Object, e As EventArgs) Handles bttnSaveStepbttns.Click
        My.Settings.SetSmallStep = NumericSmall.Value
        My.Settings.SetMediumStep = NumericMedium.Value
        My.Settings.SetLargeStep = NumericLarge.Value

        MsgBox("Settings saved")
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim WarningMsg As Integer
        WarningMsg = MsgBox("Confirm update!", vbOKCancel + vbExclamation, "Are you sure you want to update the devices settings?")
        If WarningMsg = 1 Then

            Form1.MyFocuserData.V_CURRENT_POSITION = NumericCurrentPosition.Value
            Form1.MyFocuserData.V_STEP_MODE = ComboStepModes.SelectedIndex
            Form1.MyFocuserData.V_MAX_STEPS = NumericMaxSteps.Value


            If CheckPowerHold.Checked = True Then
                Form1.MyFocuserData.V_POWER_HOLD = 0
            Else
                Form1.MyFocuserData.V_POWER_HOLD = 1
            End If

            If CheckReverseDirection.Checked = False Then
                Form1.MyFocuserData.V_DIRECTTION = 1
            Else
                Form1.MyFocuserData.V_DIRECTTION = 0
            End If

            Form1.MyFocuserData.vTempOffset = NumericTempOffset.Value

            'Public V_STEPPER_SPEED As Byte

            Form1.MyFocuserData.V_STEPPER_SPEED = TrackFocuserSpeed.Value

            Form1.MyCommandProcessing.SetTempOffset(Form1.MySerialStuff, Form1.MyFocuserData)

            Form1.MyCommandProcessing.SetFocuserData(Form1.MySerialStuff, Form1.MyFocuserData)
            Form1.SubUpdateFocuserStatus()

            MsgBox("Settings saved")

            Close()

        End If
    End Sub

End Class