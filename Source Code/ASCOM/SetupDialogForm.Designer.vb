<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupDialogForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ComboComPorts = New System.Windows.Forms.ComboBox()
        Me.GroupDew = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TrackBarDew3 = New System.Windows.Forms.TrackBar()
        Me.TrackBarDew2 = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrackBarDew1 = New System.Windows.Forms.TrackBar()
        Me.CheckBoxLockDew = New System.Windows.Forms.CheckBox()
        Me.ComboBoxStepMode = New System.Windows.Forms.ComboBox()
        Me.NumericUpDownMaxSteps = New System.Windows.Forms.NumericUpDown()
        Me.CheckBoxReverse = New System.Windows.Forms.CheckBox()
        Me.CheckBoxPowerHold = New System.Windows.Forms.CheckBox()
        Me.NumericUpDownCurrentPosition = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownTempOffset = New System.Windows.Forms.NumericUpDown()
        Me.TrackBarSpeed = New System.Windows.Forms.TrackBar()
        Me.GroupFocuser = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupTemp = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ButtonDisconnect = New System.Windows.Forms.Button()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.CheckBoxLogActions = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupDew.SuspendLayout()
        CType(Me.TrackBarDew3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarDew2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarDew1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMaxSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownCurrentPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownTempOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupFocuser.SuspendLayout()
        Me.GroupTemp.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(422, 685)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 36)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ASCOM.RealtaTrio.My.Resources.Resources.ASCOM
        Me.PictureBox1.Location = New System.Drawing.Point(572, 6)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 56)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'ComboComPorts
        '
        Me.ComboComPorts.FormattingEnabled = True
        Me.ComboComPorts.Location = New System.Drawing.Point(26, 47)
        Me.ComboComPorts.Name = "ComboComPorts"
        Me.ComboComPorts.Size = New System.Drawing.Size(226, 24)
        Me.ComboComPorts.TabIndex = 3
        '
        'GroupDew
        '
        Me.GroupDew.Controls.Add(Me.Label3)
        Me.GroupDew.Controls.Add(Me.Label2)
        Me.GroupDew.Controls.Add(Me.TrackBarDew3)
        Me.GroupDew.Controls.Add(Me.TrackBarDew2)
        Me.GroupDew.Controls.Add(Me.Label1)
        Me.GroupDew.Controls.Add(Me.TrackBarDew1)
        Me.GroupDew.Controls.Add(Me.CheckBoxLockDew)
        Me.GroupDew.Enabled = False
        Me.GroupDew.Location = New System.Drawing.Point(26, 90)
        Me.GroupDew.Name = "GroupDew"
        Me.GroupDew.Size = New System.Drawing.Size(410, 322)
        Me.GroupDew.TabIndex = 6
        Me.GroupDew.TabStop = False
        Me.GroupDew.Text = "Dew Controllers"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 215)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Controller 3"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Controller 2"
        '
        'TrackBarDew3
        '
        Me.TrackBarDew3.Enabled = False
        Me.TrackBarDew3.Location = New System.Drawing.Point(23, 235)
        Me.TrackBarDew3.Maximum = 255
        Me.TrackBarDew3.Name = "TrackBarDew3"
        Me.TrackBarDew3.Size = New System.Drawing.Size(359, 56)
        Me.TrackBarDew3.TabIndex = 7
        Me.TrackBarDew3.TickFrequency = 16
        '
        'TrackBarDew2
        '
        Me.TrackBarDew2.Enabled = False
        Me.TrackBarDew2.Location = New System.Drawing.Point(23, 156)
        Me.TrackBarDew2.Maximum = 255
        Me.TrackBarDew2.Name = "TrackBarDew2"
        Me.TrackBarDew2.Size = New System.Drawing.Size(359, 56)
        Me.TrackBarDew2.TabIndex = 3
        Me.TrackBarDew2.TickFrequency = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Controller 1"
        '
        'TrackBarDew1
        '
        Me.TrackBarDew1.Enabled = False
        Me.TrackBarDew1.Location = New System.Drawing.Point(23, 77)
        Me.TrackBarDew1.Maximum = 255
        Me.TrackBarDew1.Name = "TrackBarDew1"
        Me.TrackBarDew1.Size = New System.Drawing.Size(359, 56)
        Me.TrackBarDew1.TabIndex = 1
        Me.TrackBarDew1.TickFrequency = 16
        '
        'CheckBoxLockDew
        '
        Me.CheckBoxLockDew.AutoSize = True
        Me.CheckBoxLockDew.Checked = True
        Me.CheckBoxLockDew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxLockDew.Location = New System.Drawing.Point(7, 22)
        Me.CheckBoxLockDew.Name = "CheckBoxLockDew"
        Me.CheckBoxLockDew.Size = New System.Drawing.Size(163, 21)
        Me.CheckBoxLockDew.TabIndex = 0
        Me.CheckBoxLockDew.Text = "Lock Dew Controllers"
        Me.CheckBoxLockDew.UseVisualStyleBackColor = True
        '
        'ComboBoxStepMode
        '
        Me.ComboBoxStepMode.FormattingEnabled = True
        Me.ComboBoxStepMode.Location = New System.Drawing.Point(8, 47)
        Me.ComboBoxStepMode.Name = "ComboBoxStepMode"
        Me.ComboBoxStepMode.Size = New System.Drawing.Size(163, 24)
        Me.ComboBoxStepMode.TabIndex = 7
        '
        'NumericUpDownMaxSteps
        '
        Me.NumericUpDownMaxSteps.Location = New System.Drawing.Point(194, 47)
        Me.NumericUpDownMaxSteps.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDownMaxSteps.Name = "NumericUpDownMaxSteps"
        Me.NumericUpDownMaxSteps.Size = New System.Drawing.Size(169, 22)
        Me.NumericUpDownMaxSteps.TabIndex = 8
        '
        'CheckBoxReverse
        '
        Me.CheckBoxReverse.AutoSize = True
        Me.CheckBoxReverse.Location = New System.Drawing.Point(412, 49)
        Me.CheckBoxReverse.Name = "CheckBoxReverse"
        Me.CheckBoxReverse.Size = New System.Drawing.Size(143, 21)
        Me.CheckBoxReverse.TabIndex = 9
        Me.CheckBoxReverse.Text = "Reverse Direction"
        Me.CheckBoxReverse.UseVisualStyleBackColor = True
        '
        'CheckBoxPowerHold
        '
        Me.CheckBoxPowerHold.AutoSize = True
        Me.CheckBoxPowerHold.Location = New System.Drawing.Point(412, 94)
        Me.CheckBoxPowerHold.Name = "CheckBoxPowerHold"
        Me.CheckBoxPowerHold.Size = New System.Drawing.Size(128, 21)
        Me.CheckBoxPowerHold.TabIndex = 10
        Me.CheckBoxPowerHold.Text = "Use power hold"
        Me.CheckBoxPowerHold.UseVisualStyleBackColor = True
        '
        'NumericUpDownCurrentPosition
        '
        Me.NumericUpDownCurrentPosition.Location = New System.Drawing.Point(8, 113)
        Me.NumericUpDownCurrentPosition.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericUpDownCurrentPosition.Name = "NumericUpDownCurrentPosition"
        Me.NumericUpDownCurrentPosition.Size = New System.Drawing.Size(163, 22)
        Me.NumericUpDownCurrentPosition.TabIndex = 11
        '
        'NumericUpDownTempOffset
        '
        Me.NumericUpDownTempOffset.Location = New System.Drawing.Point(8, 49)
        Me.NumericUpDownTempOffset.Name = "NumericUpDownTempOffset"
        Me.NumericUpDownTempOffset.Size = New System.Drawing.Size(129, 22)
        Me.NumericUpDownTempOffset.TabIndex = 12
        '
        'TrackBarSpeed
        '
        Me.TrackBarSpeed.Location = New System.Drawing.Point(194, 107)
        Me.TrackBarSpeed.Maximum = 5
        Me.TrackBarSpeed.Name = "TrackBarSpeed"
        Me.TrackBarSpeed.Size = New System.Drawing.Size(186, 56)
        Me.TrackBarSpeed.TabIndex = 13
        '
        'GroupFocuser
        '
        Me.GroupFocuser.Controls.Add(Me.Label7)
        Me.GroupFocuser.Controls.Add(Me.Label6)
        Me.GroupFocuser.Controls.Add(Me.Label5)
        Me.GroupFocuser.Controls.Add(Me.Label4)
        Me.GroupFocuser.Controls.Add(Me.NumericUpDownMaxSteps)
        Me.GroupFocuser.Controls.Add(Me.ComboBoxStepMode)
        Me.GroupFocuser.Controls.Add(Me.CheckBoxReverse)
        Me.GroupFocuser.Controls.Add(Me.NumericUpDownCurrentPosition)
        Me.GroupFocuser.Controls.Add(Me.CheckBoxPowerHold)
        Me.GroupFocuser.Controls.Add(Me.TrackBarSpeed)
        Me.GroupFocuser.Enabled = False
        Me.GroupFocuser.Location = New System.Drawing.Point(28, 418)
        Me.GroupFocuser.Name = "GroupFocuser"
        Me.GroupFocuser.Size = New System.Drawing.Size(584, 169)
        Me.GroupFocuser.TabIndex = 14
        Me.GroupFocuser.TabStop = False
        Me.GroupFocuser.Text = "Focuser Settings"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(197, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Focuser Speed"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(194, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 17)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Max Steps"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 17)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Step Mode"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 17)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Current position"
        '
        'GroupTemp
        '
        Me.GroupTemp.Controls.Add(Me.Label8)
        Me.GroupTemp.Controls.Add(Me.NumericUpDownTempOffset)
        Me.GroupTemp.Enabled = False
        Me.GroupTemp.Location = New System.Drawing.Point(442, 90)
        Me.GroupTemp.Name = "GroupTemp"
        Me.GroupTemp.Size = New System.Drawing.Size(170, 322)
        Me.GroupTemp.TabIndex = 15
        Me.GroupTemp.TabStop = False
        Me.GroupTemp.Text = "Temp and Humidity"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(129, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Temperature offset"
        '
        'ButtonSave
        '
        Me.ButtonSave.Enabled = False
        Me.ButtonSave.Location = New System.Drawing.Point(422, 595)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(195, 83)
        Me.ButtonSave.TabIndex = 16
        Me.ButtonSave.Text = "Save settings to Trio"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'ButtonConnect
        '
        Me.ButtonConnect.Enabled = False
        Me.ButtonConnect.Location = New System.Drawing.Point(319, 18)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(196, 53)
        Me.ButtonConnect.TabIndex = 17
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 17)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Select COM port"
        '
        'ButtonDisconnect
        '
        Me.ButtonDisconnect.Enabled = False
        Me.ButtonDisconnect.Location = New System.Drawing.Point(26, 6)
        Me.ButtonDisconnect.Name = "ButtonDisconnect"
        Me.ButtonDisconnect.Size = New System.Drawing.Size(539, 76)
        Me.ButtonDisconnect.TabIndex = 19
        Me.ButtonDisconnect.Text = "Disconnect"
        Me.ButtonDisconnect.UseVisualStyleBackColor = True
        Me.ButtonDisconnect.Visible = False
        '
        'ButtonReset
        '
        Me.ButtonReset.Location = New System.Drawing.Point(26, 635)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(146, 82)
        Me.ButtonReset.TabIndex = 20
        Me.ButtonReset.Text = "Reset"
        Me.ButtonReset.UseVisualStyleBackColor = True
        '
        'CheckBoxLogActions
        '
        Me.CheckBoxLogActions.AutoSize = True
        Me.CheckBoxLogActions.Location = New System.Drawing.Point(299, 595)
        Me.CheckBoxLogActions.Name = "CheckBoxLogActions"
        Me.CheckBoxLogActions.Size = New System.Drawing.Size(103, 21)
        Me.CheckBoxLogActions.TabIndex = 21
        Me.CheckBoxLogActions.Text = "Log actions"
        Me.CheckBoxLogActions.UseVisualStyleBackColor = True
        '
        'SetupDialogForm
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(633, 736)
        Me.Controls.Add(Me.CheckBoxLogActions)
        Me.Controls.Add(Me.ButtonReset)
        Me.Controls.Add(Me.ButtonDisconnect)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ButtonConnect)
        Me.Controls.Add(Me.GroupFocuser)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.GroupTemp)
        Me.Controls.Add(Me.GroupDew)
        Me.Controls.Add(Me.ComboComPorts)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupDialogForm"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DeviceName Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupDew.ResumeLayout(False)
        Me.GroupDew.PerformLayout()
        CType(Me.TrackBarDew3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarDew2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarDew1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMaxSteps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownCurrentPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownTempOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupFocuser.ResumeLayout(False)
        Me.GroupFocuser.PerformLayout()
        Me.GroupTemp.ResumeLayout(False)
        Me.GroupTemp.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ComboComPorts As ComboBox
    Friend WithEvents GroupDew As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TrackBarDew3 As TrackBar
    Friend WithEvents TrackBarDew2 As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents TrackBarDew1 As TrackBar
    Friend WithEvents CheckBoxLockDew As CheckBox
    Friend WithEvents ComboBoxStepMode As ComboBox
    Friend WithEvents NumericUpDownMaxSteps As NumericUpDown
    Friend WithEvents CheckBoxReverse As CheckBox
    Friend WithEvents CheckBoxPowerHold As CheckBox
    Friend WithEvents NumericUpDownCurrentPosition As NumericUpDown
    Friend WithEvents NumericUpDownTempOffset As NumericUpDown
    Friend WithEvents TrackBarSpeed As TrackBar
    Friend WithEvents GroupFocuser As GroupBox
    Friend WithEvents GroupTemp As GroupBox
    Friend WithEvents ButtonSave As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents ButtonConnect As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents ButtonDisconnect As Button
    Friend WithEvents ButtonReset As Button
    Friend WithEvents CheckBoxLogActions As CheckBox
End Class
