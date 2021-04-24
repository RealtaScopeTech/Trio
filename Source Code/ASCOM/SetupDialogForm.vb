Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports ASCOM.RealtaTrio
Imports ASCOM.Utilities

<ComVisible(False)> _
Public Class SetupDialogForm

    Dim MyDewSurpressOnChange As Boolean = False
    Public MyDewPower(3) As Byte
    Public MyDewLocked As Boolean = True

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click ' OK button event handler
        ' Persist new values of user settings to the ASCOM profile
        'Focuser.comPort = ComboBoxComPort.SelectedItem ' Update the state variables with results from the dialogue
        'Focuser.traceState = chkTrace.Checked
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click 'Cancel button event handler
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ShowAscomWebPage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick, PictureBox1.Click
        ' Click on ASCOM logo event handler
        Try
            System.Diagnostics.Process.Start("https://ascom-standards.org/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub SetupDialogForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load ' Form load event handler
        ' Retrieve current values of user settings from the ASCOM Profile
        InitUI()
    End Sub

    Private Sub InitUI()
        PopulateComboCOMPorts()
        CheckConnectStatus()
        UpdateSettings()
    End Sub

    Sub PopulateComboCOMPorts()
        ComboComPorts.Items.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            Dim vCOMPORTLONG As String
            vCOMPORTLONG = sp + "(" + Focuser.vMyTrioSerial.CheckCOMPort(sp) + ")"
            ComboComPorts.Items.Add(vCOMPORTLONG)
        Next
    End Sub

    Private Sub ButtonConnect_Click(sender As Object, e As EventArgs) Handles ButtonConnect.Click
        Dim vComport() As String = Split(ComboComPorts.Text, "(")
        Focuser.comPort = vComport(0)
        Focuser.vMyTrioSerial.OpenSerialPort(Focuser.comPort)
        CheckConnectStatus()
        UpdateSettings()
    End Sub

    Private Sub CheckConnectStatus()
        If Focuser.vMyTrioSerial.ComIsFocuser = True And Focuser.vMyTrioSerial.ComIsConnected = True Then
            GroupDew.Enabled = True
            GroupFocuser.Enabled = True
            GroupTemp.Enabled = True
            ButtonSave.Enabled = True
            ButtonConnect.Visible = False
            ComboComPorts.Visible = False
            ButtonDisconnect.Visible = True
            ButtonDisconnect.Enabled = True
        Else
            GroupDew.Enabled = False
            GroupFocuser.Enabled = False
            GroupTemp.Enabled = False
            ButtonSave.Enabled = False
            ButtonConnect.Visible = True
            ComboComPorts.Visible = True
            ButtonDisconnect.Visible = False
            ButtonDisconnect.Enabled = False
        End If
    End Sub

    Private Sub UpdateSettings()
        If Focuser.vMyTrioSerial.ComIsFocuser = True And Focuser.vMyTrioSerial.ComIsConnected = True Then
            Focuser.MyCommandProcessing.GetFocuserStatus(Focuser.vMyTrioSerial, Focuser.MyFocuserData)
            Focuser.MyCommandProcessing.GetTempOffset(Focuser.vMyTrioSerial, Focuser.MyFocuserData)

            ' Will change this to check focuser name 
            If Focuser.MyCommandProcessing.GetStepperDriver(Focuser.vMyTrioSerial) = "TMC_2208_2209" Then
                ComboBoxStepMode.Items.Add("1/2 Stepping")
                ComboBoxStepMode.Items.Add("1/4 Stepping")
                ComboBoxStepMode.Items.Add("1/8 Stepping")
                ComboBoxStepMode.Items.Add("1/16 Stepping")
            End If

            If Focuser.MyCommandProcessing.GetStepperDriver(Focuser.vMyTrioSerial) = "DRV8825" Then
                ComboBoxStepMode.Items.Add("Full stepping")
                ComboBoxStepMode.Items.Add("Half stepping")
                ComboBoxStepMode.Items.Add("1/4 stepping")
                ComboBoxStepMode.Items.Add("1/8 stepping")
                ComboBoxStepMode.Items.Add("1/16 stepping")
                ComboBoxStepMode.Items.Add("1/32 stepping")
            End If



            ComboBoxStepMode.SelectedIndex = Focuser.MyFocuserData.V_STEP_MODE

                NumericUpDownMaxSteps.Value = Focuser.MyFocuserData.V_MAX_STEPS

                If Focuser.MyFocuserData.V_POWER_HOLD = 0 Then
                    CheckBoxPowerHold.Checked = True
                Else
                    CheckBoxPowerHold.Checked = False
                End If

                If Focuser.MyFocuserData.V_DIRECTTION = 1 Then
                    CheckBoxReverse.Checked = False
                Else
                    CheckBoxReverse.Checked = True
                End If

                TrackBarSpeed.Value = Focuser.MyFocuserData.V_STEPPER_SPEED

                NumericUpDownCurrentPosition.Maximum = NumericUpDownMaxSteps.Value

                NumericUpDownCurrentPosition.Value = Focuser.MyFocuserData.V_CURRENT_POSITION

            NumericUpDownTempOffset.Value = Focuser.MyFocuserData.vTempOffset


            CheckBoxLogActions.Checked = Focuser.TRIO_LOG.Enabled

        End If



    End Sub

    Private Sub ComboComPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboComPorts.SelectedIndexChanged
        If ComboComPorts.Text <> "" Then
            ButtonConnect.Enabled = True
        End If
    End Sub

    Private Sub ButtonDisconnect_Click(sender As Object, e As EventArgs) Handles ButtonDisconnect.Click
        Focuser.vMyTrioSerial.CloseSerialPort()
        CheckConnectStatus()
        UpdateSettings()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        Dim WarningMsg As Integer
        WarningMsg = MsgBox("Confirm update!", vbOKCancel + vbExclamation, "Are you sure you want to update the devices settings?")
        If WarningMsg = 1 Then

            Focuser.MyFocuserData.V_CURRENT_POSITION = NumericUpDownCurrentPosition.Value
            Focuser.MyFocuserData.V_STEP_MODE = ComboBoxStepMode.SelectedIndex
            Focuser.MyFocuserData.V_MAX_STEPS = NumericUpDownMaxSteps.Value


            If CheckBoxPowerHold.Checked = True Then
                Focuser.MyFocuserData.V_POWER_HOLD = 0
            Else
                Focuser.MyFocuserData.V_POWER_HOLD = 1
            End If

            If CheckBoxReverse.Checked = False Then
                Focuser.MyFocuserData.V_DIRECTTION = 1
            Else
                Focuser.MyFocuserData.V_DIRECTTION = 0
            End If

            Focuser.MyFocuserData.vTempOffset = NumericUpDownTempOffset.Value

            Focuser.MyFocuserData.V_STEPPER_SPEED = TrackBarSpeed.Value

            Focuser.MyCommandProcessing.SetTempOffset(Focuser.vMyTrioSerial, Focuser.MyFocuserData)

            Focuser.MyCommandProcessing.SetFocuserData(Focuser.vMyTrioSerial, Focuser.MyFocuserData)

            MsgBox("Settings saved")

        End If

        UpdateSettings()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLockDew.CheckedChanged
        If CheckBoxLockDew.Checked = True Then
            If Focuser.vMyTrioSerial.ComIsConnected = True And Focuser.vMyTrioSerial.ComIsFocuser = True And MyDewSurpressOnChange = False Then
                Focuser.MyCommandProcessing.LockDewControllers(Focuser.vMyTrioSerial, MyDewPower, MyDewLocked)
                SubUpdateDewStatus()
            End If
        End If

        If CheckBoxLockDew.Checked = False Then
            If Focuser.vMyTrioSerial.ComIsConnected = True And Focuser.vMyTrioSerial.ComIsFocuser = True And MyDewSurpressOnChange = False Then
                Focuser.MyCommandProcessing.UnlockDewControllers(Focuser.vMyTrioSerial, MyDewPower, MyDewLocked)
                SubUpdateDewStatus()
            End If
        End If
    End Sub

    Public Sub SubUpdateDewStatus()

        MyDewSurpressOnChange = True

        If MyDewLocked = True Then
            CheckBoxLockDew.Checked = True
            TrackBarDew1.Enabled = False
            TrackBarDew2.Enabled = False
            TrackBarDew3.Enabled = False
        End If

        If MyDewLocked = False Then
            CheckBoxLockDew.Checked = False
            TrackBarDew1.Enabled = True
            TrackBarDew2.Enabled = True
            TrackBarDew3.Enabled = True
        End If

        TrackBarDew1.Value = MyDewPower(0)
        TrackBarDew2.Value = MyDewPower(1)
        TrackBarDew3.Value = MyDewPower(2)

        MyDewSurpressOnChange = False

    End Sub

    Private Sub TrackBarDew1_Scroll(sender As Object, e As EventArgs) Handles TrackBarDew1.MouseUp

        Dim vPower As Byte = TrackBarDew1.Value

        If MyDewSurpressOnChange = False Then
            Focuser.MyCommandProcessing.DewSetPower(0, vPower, Focuser.vMyTrioSerial, MyDewPower, MyDewLocked)
        End If

    End Sub

    Private Sub TrackBarDew2_Scroll(sender As Object, e As EventArgs) Handles TrackBarDew2.MouseUp

        Dim vPower As Byte = TrackBarDew2.Value

        If MyDewSurpressOnChange = False Then
            Focuser.MyCommandProcessing.DewSetPower(1, vPower, Focuser.vMyTrioSerial, MyDewPower, MyDewLocked)
        End If

    End Sub

    Private Sub TrackBarDew3_Scroll(sender As Object, e As EventArgs) Handles TrackBarDew3.MouseUp

        Dim vPower As Byte = TrackBarDew3.Value

        If MyDewSurpressOnChange = False Then
            Focuser.MyCommandProcessing.DewSetPower(2, vPower, Focuser.vMyTrioSerial, MyDewPower, MyDewLocked)
        End If
    End Sub

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click


        Dim WarningMsg As Integer
        WarningMsg = MsgBox("Confirm Reset!", vbOKCancel + vbExclamation, "Are you sure you want to set the trio back to default settings?")
        If WarningMsg = 1 Then

            Focuser.MyCommandProcessing.ResetToDefault(Focuser.vMyTrioSerial, Focuser.MyFocuserData, MyDewPower, MyDewLocked)
            UpdateSettings()
            SubUpdateDewStatus()

        End If

    End Sub

    Private Sub CheckBoxLogActions_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLogActions.CheckedChanged
        Focuser.TRIO_LOG.Enabled = CheckBoxLogActions.Checked
    End Sub
End Class
