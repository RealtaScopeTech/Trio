Public Class Form1

    ' TODO: Implement local variable saving.

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

    Public MyDewPower(3) As Byte

    Public MyDewLocked As Boolean = True
    Dim MyDewSurpressOnChange = False
    Dim vSavePosition As Integer = 5000
    Dim vMyNetworkServer As New NewtorkServer
    Public vHaltPressed As Boolean
    Public vMoving As Boolean = False

    Public NetworkIsConnected As Boolean = False

    Public MySerialStuff As New SerialStuff
    Public MyNetworkServer As New NewtorkServer
    Public MyCommandProcessing As New CommandProcessing
    Public MyFocuserData As structFocuser

    Public vTemp As Double

    Friend WithEvents tempTimer As System.Windows.Forms.Timer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateComboCOMPorts()

        vMyNetworkServer.ListenerThread.Start()
        vMyNetworkServer.Initialise()

        'Change this when settings introduced
        MyFocuserData.vSmallSteps = 10
        MyFocuserData.vMediumSteps = 100
        MyFocuserData.vLargeSteps = 1000

        Me.components = New System.ComponentModel.Container
        Me.tempTimer = New System.Windows.Forms.Timer(Me.components)
        Me.tempTimer.Enabled = True
        Me.tempTimer.Interval = TimeSpan.FromSeconds(30).TotalMilliseconds

    End Sub

    Private Sub tempTimer_Tick(sender As Object, e As EventArgs) Handles tempTimer.Tick
        If MySerialStuff.ComIsConnected = True And MySerialStuff.ComIsFocuser = True And vMoving = False Then
            TemperatureLabel.Text = MyCommandProcessing.CheckTemperature(MySerialStuff)
        End If
    End Sub

    Sub PopulateComboCOMPorts()

        ComboCOMPorts.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Dim vCOMPORTLONG As String
            vCOMPORTLONG = sp + "(" + MySerialStuff.CheckCOMPort(sp) + ")"
            ComboCOMPorts.Items.Add(vCOMPORTLONG)
        Next
    End Sub

    Private Sub ComboCOMPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCOMPorts.SelectedIndexChanged
        If ComboCOMPorts.Text <> "" Then
            bttnConnect.Enabled = True
        End If
    End Sub

    Private Sub bttnConnect_Click(sender As Object, e As EventArgs) Handles bttnConnect.Click
        Dim vComport() As String = Split(ComboCOMPorts.Text, "(")
        MySerialStuff.OpenSerialPort(vComport(0))
        If MySerialStuff.ComIsConnected = True And MySerialStuff.ComIsFocuser = True Then
            panelControl.Enabled = True
            bttnConnect.Enabled = False
            bttnConnect.Visible = False
            ComboCOMPorts.Enabled = False
            ComboCOMPorts.Visible = False
            bttnDisconnect.Enabled = True
            bttnDisconnect.Visible = True
            bttnSettings.Enabled = True
            MyCommandProcessing.GetFocuserStatus(MySerialStuff, MyFocuserData)
            SubUpdateFocuserStatus()
            MyCommandProcessing.GetTempOffset(MySerialStuff, MyFocuserData)
            TemperatureLabel.Text = MyCommandProcessing.CheckTemperature(MySerialStuff)
        End If
    End Sub

    Public Sub SubUpdateFocuserStatus()
        lblFocuserCurrentPosition.Text = MyFocuserData.V_CURRENT_POSITION.ToString
    End Sub

    Public Sub SubUpdateDewStatus()

        MyDewSurpressOnChange = True

        If MyDewLocked = True Then
            chkBoxLockDew.Checked = True
            DewController1.Enabled = False
            DewController2.Enabled = False
            DewController3.Enabled = False
        End If

        If MyDewLocked = False Then
            chkBoxLockDew.Checked = False
            DewController1.Enabled = True
            DewController2.Enabled = True
            DewController3.Enabled = True
        End If

        DewController1.Value = MyDewPower(0)
        DewController2.Value = MyDewPower(1)
        DewController3.Value = MyDewPower(2)

        MyDewSurpressOnChange = False

    End Sub

    Public Sub animateFocuserMoveProgress(vNumberOfStep As Integer)
        'Set Progress to zero and show it.
        ProgressFocuserMove.Enabled = True
        ProgressFocuserMove.Visible = True
        bttnHalt.Visible = True
        bttnHalt.Enabled = True
        lblFocuserCurrentPosition.Visible = False
        GroupDew.Enabled = False
        bttnMoveHome.Enabled = False
        bttnMoveInLarge.Enabled = False
        bttnMoveInMedium.Enabled = False
        bttnMoveInSmall.Enabled = False
        bttnMoveOutLarge.Enabled = False
        bttnMoveOutMedium.Enabled = False
        bttnMoveOutSmall.Enabled = False
        bttnMoveSaved.Enabled = False
        bttnSaveMove.Enabled = False
        bttnMoveMax.Enabled = False
        bttnSettings.Enabled = False
        vMoving = True



        Dim vloopWaitTime As Integer = (MyFocuserData.V_STEPPER_SPEED + MyFocuserData.V_STEPPER_WAIT)
        Dim vZeroReached As Boolean = False
        Dim vFocuserMoveValue As Integer
        ProgressFocuserMove.Value = 0
        ProgressFocuserMove.Minimum = 0
        ProgressFocuserMove.Step = 1
        ProgressFocuserMove.Maximum = vNumberOfStep

        bttnHalt.Select()

        vHaltPressed = False

        While vZeroReached = False

                If vHaltPressed = False Then
                    vFocuserMoveValue = MyCommandProcessing.CheckFocuserMove(MySerialStuff.ReceiveText)

                    If vFocuserMoveValue > 0 Then
                        ProgressFocuserMove.Value = vNumberOfStep - vFocuserMoveValue
                    End If

                    If vFocuserMoveValue < 0 Then
                        ProgressFocuserMove.Value = vNumberOfStep + vFocuserMoveValue
                    End If

                    If vFocuserMoveValue = 0 Then
                        vZeroReached = True
                    End If
                Else
                    Exit While
                End If

                Application.DoEvents()

        End While

        ProgressFocuserMove.Enabled = False
        ProgressFocuserMove.Visible = False
        lblFocuserCurrentPosition.Visible = True
        bttnHalt.Visible = False
        bttnHalt.Enabled = False
        vHaltPressed = False
        GroupDew.Enabled = True

        bttnMoveHome.Enabled = True
        bttnMoveInLarge.Enabled = True
        bttnMoveInMedium.Enabled = True
        bttnMoveInSmall.Enabled = True
        bttnMoveOutLarge.Enabled = True
        bttnMoveOutMedium.Enabled = True
        bttnMoveOutSmall.Enabled = True
        bttnMoveSaved.Enabled = True
        bttnSaveMove.Enabled = True
        bttnMoveMax.Enabled = True
        bttnSettings.Enabled = True

        vMoving = False

    End Sub

    Private Sub bttnMoveOutSmall_Click(sender As Object, e As EventArgs) Handles bttnMoveOutSmall.Click
        If MyFocuserData.V_CURRENT_POSITION < MyFocuserData.V_MAX_STEPS Then
            MyCommandProcessing.FocuserMove(My.Settings.SetSmallStep, MySerialStuff, MyFocuserData)
            animateFocuserMoveProgress(My.Settings.SetSmallStep)
            MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
            SubUpdateFocuserStatus()
        End If
    End Sub

    Private Sub bttnMoveOutMedium_Click(sender As Object, e As EventArgs) Handles bttnMoveOutMedium.Click
        If MyFocuserData.V_CURRENT_POSITION < MyFocuserData.V_MAX_STEPS Then
            MyCommandProcessing.FocuserMove(My.Settings.SetMediumStep, MySerialStuff, MyFocuserData)
            animateFocuserMoveProgress(My.Settings.SetMediumStep)
            MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
            SubUpdateFocuserStatus()
        End If
    End Sub

    Private Sub bttnMoveOutLarge_Click(sender As Object, e As EventArgs) Handles bttnMoveOutLarge.Click
        If MyFocuserData.V_CURRENT_POSITION < MyFocuserData.V_MAX_STEPS Then
            MyCommandProcessing.FocuserMove(My.Settings.SetLargeStep, MySerialStuff, MyFocuserData)
            animateFocuserMoveProgress(My.Settings.SetLargeStep)
            MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
            SubUpdateFocuserStatus()
        End If

    End Sub

    Private Sub bttnMoveInSmall_Click(sender As Object, e As EventArgs) Handles bttnMoveInSmall.Click
        If MyFocuserData.V_CURRENT_POSITION > 0 Then
            MyCommandProcessing.FocuserMove(My.Settings.SetSmallStep * -1, MySerialStuff, MyFocuserData)
            animateFocuserMoveProgress(My.Settings.SetSmallStep)
            MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
            SubUpdateFocuserStatus()
        End If

    End Sub

    Private Sub bttnMoveInMedium_Click(sender As Object, e As EventArgs) Handles bttnMoveInMedium.Click
        If MyFocuserData.V_CURRENT_POSITION > 0 Then
            MyCommandProcessing.FocuserMove(My.Settings.SetMediumStep * -1, MySerialStuff, MyFocuserData)
            animateFocuserMoveProgress(My.Settings.SetMediumStep)
            MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
            SubUpdateFocuserStatus()
        End If
    End Sub

    Private Sub bttnMoveInLarge_Click(sender As Object, e As EventArgs) Handles bttnMoveInLarge.Click
        If MyFocuserData.V_CURRENT_POSITION > 0 Then
            MyCommandProcessing.FocuserMove(My.Settings.SetLargeStep * -1, MySerialStuff, MyFocuserData)
            animateFocuserMoveProgress(My.Settings.SetLargeStep)
            MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
            SubUpdateFocuserStatus()
        End If
    End Sub

    Private Sub chkBoxLockDew_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxLockDew.CheckedChanged
        If chkBoxLockDew.Checked = True Then
            If MySerialStuff.ComIsConnected = True And MySerialStuff.ComIsFocuser = True And MyDewSurpressOnChange = False Then
                MyCommandProcessing.LockDewControllers(MySerialStuff, MyDewPower, MyDewLocked)
                SubUpdateDewStatus()
            End If
        End If

        If chkBoxLockDew.Checked = False Then
            If MySerialStuff.ComIsConnected = True And MySerialStuff.ComIsFocuser = True And MyDewSurpressOnChange = False Then
                MyCommandProcessing.UnlockDewControllers(MySerialStuff, MyDewPower, MyDewLocked)
                SubUpdateDewStatus()
            End If
        End If
    End Sub

    Private Sub DewController1_Scroll(sender As Object, e As EventArgs) Handles DewController1.MouseUp


        Dim vPower As Byte = DewController1.Value

        If MyDewSurpressOnChange = False Then
            MyCommandProcessing.DewSetPower(0, vPower, MySerialStuff, MyDewPower, MyDewLocked)
        End If

    End Sub

    Private Sub DewController2_Scroll(sender As Object, e As EventArgs) Handles DewController2.MouseUp

        Dim vPower As Byte = DewController2.Value

        If MyDewSurpressOnChange = False Then
            MyCommandProcessing.DewSetPower(1, vPower, MySerialStuff, MyDewPower, MyDewLocked)
        End If

    End Sub

    Private Sub DewController3_Scroll(sender As Object, e As EventArgs) Handles DewController3.MouseUp

        Dim vPower As Byte = DewController3.Value

        If MyDewSurpressOnChange = False Then
            MyCommandProcessing.DewSetPower(2, vPower, MySerialStuff, MyDewPower, MyDewLocked)
        End If

    End Sub

    Private Sub bttnSettings_Click(sender As Object, e As EventArgs) Handles bttnSettings.Click
        Dim mySettingsForm As New SettingsForm

        mySettingsForm.NumericCurrentPosition.Value = Convert.ToInt32(lblFocuserCurrentPosition.Text)

        mySettingsForm.ComboStepModes.Items.Add("1/1 Stepping")
        mySettingsForm.ComboStepModes.Items.Add("1/2 Stepping")
        mySettingsForm.ComboStepModes.Items.Add("1/4 Stepping")
        mySettingsForm.ComboStepModes.Items.Add("1/8 Stepping")
        mySettingsForm.ComboStepModes.Items.Add("1/16 Stepping")
        mySettingsForm.ComboStepModes.Items.Add("1/32 Stepping")

        mySettingsForm.ComboStepModes.SelectedIndex = MyFocuserData.V_STEP_MODE

        mySettingsForm.NumericMaxSteps.Value = MyFocuserData.V_MAX_STEPS
        If MyFocuserData.V_POWER_HOLD = 0 Then
            mySettingsForm.CheckPowerHold.Checked = True
        Else
            mySettingsForm.CheckPowerHold.Checked = False
        End If

        If MyFocuserData.V_DIRECTTION = 1 Then
            mySettingsForm.CheckReverseDirection.Checked = False
        Else
            mySettingsForm.CheckReverseDirection.Checked = True
        End If

        mySettingsForm.TrackFocuserSpeed.Value = MyFocuserData.V_STEPPER_SPEED

        mySettingsForm.NumericSmall.Value = My.Settings.SetSmallStep
        mySettingsForm.NumericMedium.Value = My.Settings.SetMediumStep
        mySettingsForm.NumericLarge.Value = My.Settings.SetLargeStep

        mySettingsForm.NumericCurrentPosition.Maximum = mySettingsForm.NumericMaxSteps.Value

        mySettingsForm.NumericTempOffset.Value = MyFocuserData.vTempOffset

        mySettingsForm.Show()
    End Sub

    Private Sub bttnDisconnect_Click(sender As Object, e As EventArgs) Handles bttnDisconnect.Click
        MySerialStuff.CloseSerialPort()
        panelControl.Enabled = False
        bttnConnect.Enabled = False
        bttnConnect.Visible = True
        ComboCOMPorts.Enabled = True
        ComboCOMPorts.Visible = True
        bttnDisconnect.Enabled = False
        bttnDisconnect.Visible = False
        bttnSettings.Enabled = False
        PopulateComboCOMPorts()
        ComboCOMPorts.ResetText()
    End Sub

    Private Sub bttnSaveMove_Click(sender As Object, e As EventArgs) Handles bttnSaveMove.Click
        My.Settings.setSavePosition = Convert.ToInt32(lblFocuserCurrentPosition.Text)
        MsgBox("Position saved")
    End Sub

    Private Sub bttnMoveSaved_Click(sender As Object, e As EventArgs) Handles bttnMoveSaved.Click
        Dim vCurrent As Integer = Convert.ToInt32(lblFocuserCurrentPosition.Text)
        Dim vStepsToMove As Integer = My.Settings.setSavePosition - vCurrent

        If vStepsToMove <> 0 Then
            MyCommandProcessing.FocuserMove(vStepsToMove, MySerialStuff, MyFocuserData)
            animateFocuserMoveProgress(Math.Abs(vStepsToMove))
            MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
            SubUpdateFocuserStatus()
        End If

    End Sub

    Private Sub bttnMoveHome_Click(sender As Object, e As EventArgs) Handles bttnMoveHome.Click
        Dim vCurrent As Integer = Convert.ToInt32(lblFocuserCurrentPosition.Text)
        MyCommandProcessing.FocuserMove(vCurrent * -1, MySerialStuff, MyFocuserData)
        animateFocuserMoveProgress(vCurrent)
        MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
        SubUpdateFocuserStatus()
    End Sub

    Private Sub bttnMoveMax_Click(sender As Object, e As EventArgs) Handles bttnMoveMax.Click
        Dim vCurrent As Integer = Convert.ToInt32(lblFocuserCurrentPosition.Text)
        Dim vStepsToMove As Integer = MyFocuserData.V_MAX_STEPS - vCurrent
        MyCommandProcessing.FocuserMove(vStepsToMove, MySerialStuff, MyFocuserData)
        animateFocuserMoveProgress(vStepsToMove)
        MyCommandProcessing.UpdateFocuserStatus(MySerialStuff.ReceiveText, MyFocuserData)
        SubUpdateFocuserStatus()
    End Sub

    Private Sub bttnHalt_Click(sender As Object, e As EventArgs) Handles bttnHalt.Click
        vHaltPressed = True
        MyCommandProcessing.Halt(MySerialStuff, MyFocuserData)
    End Sub


End Class
