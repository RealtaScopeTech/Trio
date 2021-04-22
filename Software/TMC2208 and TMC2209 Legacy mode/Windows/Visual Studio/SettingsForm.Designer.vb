<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SettingsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bttnReset = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NumericTempOffset = New System.Windows.Forms.NumericUpDown()
        Me.NumericCurrentPosition = New System.Windows.Forms.NumericUpDown()
        Me.NumericMaxSteps = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TrackFocuserSpeed = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckReverseDirection = New System.Windows.Forms.CheckBox()
        Me.CheckPowerHold = New System.Windows.Forms.CheckBox()
        Me.ComboStepModes = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.NumericLarge = New System.Windows.Forms.NumericUpDown()
        Me.NumericMedium = New System.Windows.Forms.NumericUpDown()
        Me.NumericSmall = New System.Windows.Forms.NumericUpDown()
        Me.bttnSaveStepbttns = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericTempOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericCurrentPosition, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericMaxSteps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrackFocuserSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.NumericLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericMedium, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericSmall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bttnReset
        '
        Me.bttnReset.BackColor = System.Drawing.Color.Firebrick
        Me.bttnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnReset.ForeColor = System.Drawing.Color.MistyRose
        Me.bttnReset.Location = New System.Drawing.Point(22, 735)
        Me.bttnReset.Name = "bttnReset"
        Me.bttnReset.Size = New System.Drawing.Size(307, 61)
        Me.bttnReset.TabIndex = 0
        Me.bttnReset.Text = "Reset to factory defaults"
        Me.bttnReset.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.NumericTempOffset)
        Me.GroupBox1.Controls.Add(Me.NumericCurrentPosition)
        Me.GroupBox1.Controls.Add(Me.NumericMaxSteps)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CheckReverseDirection)
        Me.GroupBox1.Controls.Add(Me.CheckPowerHold)
        Me.GroupBox1.Controls.Add(Me.ComboStepModes)
        Me.GroupBox1.ForeColor = System.Drawing.Color.MistyRose
        Me.GroupBox1.Location = New System.Drawing.Point(13, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(326, 393)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "On device settings"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.MistyRose
        Me.Label8.Location = New System.Drawing.Point(137, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Temp Offset"
        '
        'NumericTempOffset
        '
        Me.NumericTempOffset.Location = New System.Drawing.Point(11, 193)
        Me.NumericTempOffset.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.NumericTempOffset.Name = "NumericTempOffset"
        Me.NumericTempOffset.Size = New System.Drawing.Size(120, 22)
        Me.NumericTempOffset.TabIndex = 29
        '
        'NumericCurrentPosition
        '
        Me.NumericCurrentPosition.Location = New System.Drawing.Point(10, 165)
        Me.NumericCurrentPosition.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericCurrentPosition.Name = "NumericCurrentPosition"
        Me.NumericCurrentPosition.Size = New System.Drawing.Size(120, 22)
        Me.NumericCurrentPosition.TabIndex = 28
        '
        'NumericMaxSteps
        '
        Me.NumericMaxSteps.Location = New System.Drawing.Point(10, 66)
        Me.NumericMaxSteps.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericMaxSteps.Name = "NumericMaxSteps"
        Me.NumericMaxSteps.Size = New System.Drawing.Size(120, 22)
        Me.NumericMaxSteps.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MistyRose
        Me.Label4.Location = New System.Drawing.Point(136, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 17)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Change current position"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Firebrick
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.MistyRose
        Me.Button2.Location = New System.Drawing.Point(9, 314)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(307, 61)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Save settings to trio"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TrackFocuserSpeed)
        Me.GroupBox2.ForeColor = System.Drawing.Color.MistyRose
        Me.GroupBox2.Location = New System.Drawing.Point(10, 234)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 74)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Focuser Speed"
        '
        'TrackFocuserSpeed
        '
        Me.TrackFocuserSpeed.Location = New System.Drawing.Point(6, 33)
        Me.TrackFocuserSpeed.Maximum = 5
        Me.TrackFocuserSpeed.Name = "TrackFocuserSpeed"
        Me.TrackFocuserSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TrackFocuserSpeed.Size = New System.Drawing.Size(295, 56)
        Me.TrackFocuserSpeed.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.MistyRose
        Me.Label2.Location = New System.Drawing.Point(137, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Max steps"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MistyRose
        Me.Label1.Location = New System.Drawing.Point(137, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Step mode"
        '
        'CheckReverseDirection
        '
        Me.CheckReverseDirection.AutoSize = True
        Me.CheckReverseDirection.ForeColor = System.Drawing.Color.MistyRose
        Me.CheckReverseDirection.Location = New System.Drawing.Point(25, 131)
        Me.CheckReverseDirection.Name = "CheckReverseDirection"
        Me.CheckReverseDirection.Size = New System.Drawing.Size(192, 21)
        Me.CheckReverseDirection.TabIndex = 20
        Me.CheckReverseDirection.Text = "Reverse focuser direction"
        Me.CheckReverseDirection.UseVisualStyleBackColor = True
        '
        'CheckPowerHold
        '
        Me.CheckPowerHold.AutoSize = True
        Me.CheckPowerHold.ForeColor = System.Drawing.Color.MistyRose
        Me.CheckPowerHold.Location = New System.Drawing.Point(25, 105)
        Me.CheckPowerHold.Name = "CheckPowerHold"
        Me.CheckPowerHold.Size = New System.Drawing.Size(248, 21)
        Me.CheckPowerHold.TabIndex = 19
        Me.CheckPowerHold.Text = "Use power to hold focuser in place"
        Me.CheckPowerHold.UseVisualStyleBackColor = True
        '
        'ComboStepModes
        '
        Me.ComboStepModes.FormattingEnabled = True
        Me.ComboStepModes.Location = New System.Drawing.Point(10, 33)
        Me.ComboStepModes.Name = "ComboStepModes"
        Me.ComboStepModes.Size = New System.Drawing.Size(121, 24)
        Me.ComboStepModes.TabIndex = 18
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.NumericLarge)
        Me.GroupBox3.Controls.Add(Me.NumericMedium)
        Me.GroupBox3.Controls.Add(Me.NumericSmall)
        Me.GroupBox3.Controls.Add(Me.bttnSaveStepbttns)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.ForeColor = System.Drawing.Color.MistyRose
        Me.GroupBox3.Location = New System.Drawing.Point(12, 415)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(326, 293)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "App settings: Step buttons"
        '
        'NumericLarge
        '
        Me.NumericLarge.Location = New System.Drawing.Point(10, 168)
        Me.NumericLarge.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericLarge.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericLarge.Name = "NumericLarge"
        Me.NumericLarge.Size = New System.Drawing.Size(120, 22)
        Me.NumericLarge.TabIndex = 28
        Me.NumericLarge.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericMedium
        '
        Me.NumericMedium.Location = New System.Drawing.Point(10, 123)
        Me.NumericMedium.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericMedium.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericMedium.Name = "NumericMedium"
        Me.NumericMedium.Size = New System.Drawing.Size(120, 22)
        Me.NumericMedium.TabIndex = 27
        Me.NumericMedium.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumericSmall
        '
        Me.NumericSmall.Location = New System.Drawing.Point(11, 72)
        Me.NumericSmall.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.NumericSmall.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericSmall.Name = "NumericSmall"
        Me.NumericSmall.Size = New System.Drawing.Size(120, 22)
        Me.NumericSmall.TabIndex = 26
        Me.NumericSmall.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'bttnSaveStepbttns
        '
        Me.bttnSaveStepbttns.BackColor = System.Drawing.Color.Firebrick
        Me.bttnSaveStepbttns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnSaveStepbttns.ForeColor = System.Drawing.Color.MistyRose
        Me.bttnSaveStepbttns.Location = New System.Drawing.Point(10, 210)
        Me.bttnSaveStepbttns.Name = "bttnSaveStepbttns"
        Me.bttnSaveStepbttns.Size = New System.Drawing.Size(307, 61)
        Me.bttnSaveStepbttns.TabIndex = 25
        Me.bttnSaveStepbttns.Text = "Save app settings"
        Me.bttnSaveStepbttns.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(142, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(120, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Large step button"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(142, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Medium step button"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Small step button"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(210, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Click to change number of steps"
        '
        'SettingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(356, 824)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.bttnReset)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SettingsForm"
        Me.Text = "Réalta: Trio Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericTempOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericCurrentPosition, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericMaxSteps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TrackFocuserSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.NumericLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericMedium, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericSmall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bttnReset As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TrackFocuserSpeed As TrackBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckReverseDirection As CheckBox
    Friend WithEvents CheckPowerHold As CheckBox
    Friend WithEvents ComboStepModes As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents bttnSaveStepbttns As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NumericCurrentPosition As NumericUpDown
    Friend WithEvents NumericMaxSteps As NumericUpDown
    Friend WithEvents NumericLarge As NumericUpDown
    Friend WithEvents NumericMedium As NumericUpDown
    Friend WithEvents NumericSmall As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents NumericTempOffset As NumericUpDown
End Class
