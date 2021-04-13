<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.bttnConnect = New System.Windows.Forms.Button()
        Me.panelControl = New System.Windows.Forms.Panel()
        Me.GroupDew = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DewController2 = New System.Windows.Forms.TrackBar()
        Me.DewController3 = New System.Windows.Forms.TrackBar()
        Me.chkBoxLockDew = New System.Windows.Forms.CheckBox()
        Me.DewController1 = New System.Windows.Forms.TrackBar()
        Me.bttnSaveMove = New System.Windows.Forms.Button()
        Me.bttnMoveMax = New System.Windows.Forms.Button()
        Me.bttnMoveHome = New System.Windows.Forms.Button()
        Me.bttnMoveInLarge = New System.Windows.Forms.Button()
        Me.bttnMoveInMedium = New System.Windows.Forms.Button()
        Me.bttnMoveInSmall = New System.Windows.Forms.Button()
        Me.bttnMoveOutLarge = New System.Windows.Forms.Button()
        Me.bttnMoveOutMedium = New System.Windows.Forms.Button()
        Me.bttnMoveOutSmall = New System.Windows.Forms.Button()
        Me.bttnMoveSaved = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bttnHalt = New System.Windows.Forms.Button()
        Me.ProgressFocuserMove = New System.Windows.Forms.ProgressBar()
        Me.lblFocuserCurrentPosition = New System.Windows.Forms.Label()
        Me.LabelCurrentFocuserPosition = New System.Windows.Forms.Label()
        Me.bttnSettings = New System.Windows.Forms.Button()
        Me.bttnDisconnect = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtTest = New System.Windows.Forms.TextBox()
        Me.ComboCOMPorts = New System.Windows.Forms.ComboBox()
        Me.TemperatureLabel = New System.Windows.Forms.Label()
        Me.panelControl.SuspendLayout()
        Me.GroupDew.SuspendLayout()
        CType(Me.DewController2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DewController3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DewController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'bttnConnect
        '
        Me.bttnConnect.BackColor = System.Drawing.Color.Firebrick
        Me.bttnConnect.Cursor = System.Windows.Forms.Cursors.Default
        Me.bttnConnect.Enabled = False
        Me.bttnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnConnect.ForeColor = System.Drawing.Color.MistyRose
        Me.bttnConnect.Location = New System.Drawing.Point(12, 9)
        Me.bttnConnect.Name = "bttnConnect"
        Me.bttnConnect.Size = New System.Drawing.Size(213, 34)
        Me.bttnConnect.TabIndex = 1
        Me.bttnConnect.Text = "Connect"
        Me.bttnConnect.UseVisualStyleBackColor = False
        '
        'panelControl
        '
        Me.panelControl.Controls.Add(Me.GroupDew)
        Me.panelControl.Controls.Add(Me.bttnSaveMove)
        Me.panelControl.Controls.Add(Me.bttnMoveMax)
        Me.panelControl.Controls.Add(Me.bttnMoveHome)
        Me.panelControl.Controls.Add(Me.bttnMoveInLarge)
        Me.panelControl.Controls.Add(Me.bttnMoveInMedium)
        Me.panelControl.Controls.Add(Me.bttnMoveInSmall)
        Me.panelControl.Controls.Add(Me.bttnMoveOutLarge)
        Me.panelControl.Controls.Add(Me.bttnMoveOutMedium)
        Me.panelControl.Controls.Add(Me.bttnMoveOutSmall)
        Me.panelControl.Controls.Add(Me.bttnMoveSaved)
        Me.panelControl.Controls.Add(Me.GroupBox1)
        Me.panelControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.panelControl.Enabled = False
        Me.panelControl.Location = New System.Drawing.Point(10, 52)
        Me.panelControl.Name = "panelControl"
        Me.panelControl.Size = New System.Drawing.Size(440, 560)
        Me.panelControl.TabIndex = 20
        '
        'GroupDew
        '
        Me.GroupDew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupDew.Controls.Add(Me.Label3)
        Me.GroupDew.Controls.Add(Me.Label2)
        Me.GroupDew.Controls.Add(Me.Label1)
        Me.GroupDew.Controls.Add(Me.DewController2)
        Me.GroupDew.Controls.Add(Me.DewController3)
        Me.GroupDew.Controls.Add(Me.chkBoxLockDew)
        Me.GroupDew.Controls.Add(Me.DewController1)
        Me.GroupDew.ForeColor = System.Drawing.Color.MistyRose
        Me.GroupDew.Location = New System.Drawing.Point(12, 252)
        Me.GroupDew.Name = "GroupDew"
        Me.GroupDew.Size = New System.Drawing.Size(418, 305)
        Me.GroupDew.TabIndex = 31
        Me.GroupDew.TabStop = False
        Me.GroupDew.Text = "Dew Controllers"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Controller 2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Controller 2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Controller 1"
        '
        'DewController2
        '
        Me.DewController2.Enabled = False
        Me.DewController2.Location = New System.Drawing.Point(7, 146)
        Me.DewController2.Maximum = 255
        Me.DewController2.Name = "DewController2"
        Me.DewController2.Size = New System.Drawing.Size(405, 56)
        Me.DewController2.TabIndex = 3
        Me.DewController2.TickFrequency = 16
        Me.DewController2.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'DewController3
        '
        Me.DewController3.Enabled = False
        Me.DewController3.Location = New System.Drawing.Point(7, 225)
        Me.DewController3.Maximum = 255
        Me.DewController3.Name = "DewController3"
        Me.DewController3.Size = New System.Drawing.Size(405, 56)
        Me.DewController3.TabIndex = 2
        Me.DewController3.TickFrequency = 16
        Me.DewController3.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'chkBoxLockDew
        '
        Me.chkBoxLockDew.AutoSize = True
        Me.chkBoxLockDew.Checked = True
        Me.chkBoxLockDew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBoxLockDew.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkBoxLockDew.Location = New System.Drawing.Point(7, 22)
        Me.chkBoxLockDew.Name = "chkBoxLockDew"
        Me.chkBoxLockDew.Size = New System.Drawing.Size(163, 21)
        Me.chkBoxLockDew.TabIndex = 1
        Me.chkBoxLockDew.Text = "Lock Dew Controllers"
        Me.chkBoxLockDew.UseVisualStyleBackColor = True
        '
        'DewController1
        '
        Me.DewController1.Enabled = False
        Me.DewController1.Location = New System.Drawing.Point(7, 76)
        Me.DewController1.Maximum = 255
        Me.DewController1.Name = "DewController1"
        Me.DewController1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DewController1.Size = New System.Drawing.Size(405, 56)
        Me.DewController1.TabIndex = 0
        Me.DewController1.TickFrequency = 16
        Me.DewController1.TickStyle = System.Windows.Forms.TickStyle.Both
        '
        'bttnSaveMove
        '
        Me.bttnSaveMove.BackColor = System.Drawing.Color.Firebrick
        Me.bttnSaveMove.Cursor = System.Windows.Forms.Cursors.Default
        Me.bttnSaveMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnSaveMove.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnSaveMove.Location = New System.Drawing.Point(170, 186)
        Me.bttnSaveMove.Name = "bttnSaveMove"
        Me.bttnSaveMove.Size = New System.Drawing.Size(100, 60)
        Me.bttnSaveMove.TabIndex = 30
        Me.bttnSaveMove.Text = "Save Current Position"
        Me.bttnSaveMove.UseVisualStyleBackColor = False
        '
        'bttnMoveMax
        '
        Me.bttnMoveMax.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveMax.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveMax.Location = New System.Drawing.Point(276, 186)
        Me.bttnMoveMax.Name = "bttnMoveMax"
        Me.bttnMoveMax.Size = New System.Drawing.Size(154, 60)
        Me.bttnMoveMax.TabIndex = 29
        Me.bttnMoveMax.Text = "Fully Extend (max)"
        Me.bttnMoveMax.UseVisualStyleBackColor = False
        '
        'bttnMoveHome
        '
        Me.bttnMoveHome.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveHome.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveHome.Location = New System.Drawing.Point(12, 186)
        Me.bttnMoveHome.Name = "bttnMoveHome"
        Me.bttnMoveHome.Size = New System.Drawing.Size(152, 60)
        Me.bttnMoveHome.TabIndex = 28
        Me.bttnMoveHome.Text = "Go Home (0)"
        Me.bttnMoveHome.UseVisualStyleBackColor = False
        '
        'bttnMoveInLarge
        '
        Me.bttnMoveInLarge.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveInLarge.Cursor = System.Windows.Forms.Cursors.Default
        Me.bttnMoveInLarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveInLarge.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveInLarge.Image = CType(resources.GetObject("bttnMoveInLarge.Image"), System.Drawing.Image)
        Me.bttnMoveInLarge.Location = New System.Drawing.Point(10, 120)
        Me.bttnMoveInLarge.Name = "bttnMoveInLarge"
        Me.bttnMoveInLarge.Size = New System.Drawing.Size(58, 60)
        Me.bttnMoveInLarge.TabIndex = 27
        Me.bttnMoveInLarge.UseVisualStyleBackColor = False
        '
        'bttnMoveInMedium
        '
        Me.bttnMoveInMedium.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveInMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveInMedium.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveInMedium.Image = CType(resources.GetObject("bttnMoveInMedium.Image"), System.Drawing.Image)
        Me.bttnMoveInMedium.Location = New System.Drawing.Point(74, 120)
        Me.bttnMoveInMedium.Name = "bttnMoveInMedium"
        Me.bttnMoveInMedium.Size = New System.Drawing.Size(42, 60)
        Me.bttnMoveInMedium.TabIndex = 26
        Me.bttnMoveInMedium.UseVisualStyleBackColor = False
        '
        'bttnMoveInSmall
        '
        Me.bttnMoveInSmall.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveInSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveInSmall.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveInSmall.Image = CType(resources.GetObject("bttnMoveInSmall.Image"), System.Drawing.Image)
        Me.bttnMoveInSmall.Location = New System.Drawing.Point(122, 120)
        Me.bttnMoveInSmall.Name = "bttnMoveInSmall"
        Me.bttnMoveInSmall.Size = New System.Drawing.Size(42, 60)
        Me.bttnMoveInSmall.TabIndex = 25
        Me.bttnMoveInSmall.UseVisualStyleBackColor = False
        '
        'bttnMoveOutLarge
        '
        Me.bttnMoveOutLarge.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveOutLarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveOutLarge.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveOutLarge.Image = CType(resources.GetObject("bttnMoveOutLarge.Image"), System.Drawing.Image)
        Me.bttnMoveOutLarge.Location = New System.Drawing.Point(372, 120)
        Me.bttnMoveOutLarge.Name = "bttnMoveOutLarge"
        Me.bttnMoveOutLarge.Size = New System.Drawing.Size(58, 60)
        Me.bttnMoveOutLarge.TabIndex = 24
        Me.bttnMoveOutLarge.UseVisualStyleBackColor = False
        '
        'bttnMoveOutMedium
        '
        Me.bttnMoveOutMedium.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveOutMedium.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveOutMedium.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveOutMedium.Image = CType(resources.GetObject("bttnMoveOutMedium.Image"), System.Drawing.Image)
        Me.bttnMoveOutMedium.Location = New System.Drawing.Point(324, 120)
        Me.bttnMoveOutMedium.Name = "bttnMoveOutMedium"
        Me.bttnMoveOutMedium.Size = New System.Drawing.Size(42, 60)
        Me.bttnMoveOutMedium.TabIndex = 23
        Me.bttnMoveOutMedium.UseVisualStyleBackColor = False
        '
        'bttnMoveOutSmall
        '
        Me.bttnMoveOutSmall.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveOutSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveOutSmall.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveOutSmall.Image = CType(resources.GetObject("bttnMoveOutSmall.Image"), System.Drawing.Image)
        Me.bttnMoveOutSmall.Location = New System.Drawing.Point(276, 120)
        Me.bttnMoveOutSmall.Name = "bttnMoveOutSmall"
        Me.bttnMoveOutSmall.Size = New System.Drawing.Size(42, 60)
        Me.bttnMoveOutSmall.TabIndex = 22
        Me.bttnMoveOutSmall.UseVisualStyleBackColor = False
        '
        'bttnMoveSaved
        '
        Me.bttnMoveSaved.BackColor = System.Drawing.Color.Firebrick
        Me.bttnMoveSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnMoveSaved.ForeColor = System.Drawing.Color.SeaShell
        Me.bttnMoveSaved.Location = New System.Drawing.Point(170, 120)
        Me.bttnMoveSaved.Name = "bttnMoveSaved"
        Me.bttnMoveSaved.Size = New System.Drawing.Size(100, 60)
        Me.bttnMoveSaved.TabIndex = 21
        Me.bttnMoveSaved.Text = "Go To Saved Position"
        Me.bttnMoveSaved.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bttnHalt)
        Me.GroupBox1.Controls.Add(Me.ProgressFocuserMove)
        Me.GroupBox1.Controls.Add(Me.lblFocuserCurrentPosition)
        Me.GroupBox1.Controls.Add(Me.LabelCurrentFocuserPosition)
        Me.GroupBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox1.ForeColor = System.Drawing.Color.MistyRose
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 100)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Focuser Position"
        '
        'bttnHalt
        '
        Me.bttnHalt.BackColor = System.Drawing.Color.Maroon
        Me.bttnHalt.Enabled = False
        Me.bttnHalt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnHalt.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttnHalt.ForeColor = System.Drawing.Color.Red
        Me.bttnHalt.Location = New System.Drawing.Point(331, 20)
        Me.bttnHalt.Name = "bttnHalt"
        Me.bttnHalt.Size = New System.Drawing.Size(83, 74)
        Me.bttnHalt.TabIndex = 32
        Me.bttnHalt.Text = "Halt!"
        Me.bttnHalt.UseVisualStyleBackColor = False
        Me.bttnHalt.Visible = False
        '
        'ProgressFocuserMove
        '
        Me.ProgressFocuserMove.Enabled = False
        Me.ProgressFocuserMove.Location = New System.Drawing.Point(9, 22)
        Me.ProgressFocuserMove.Name = "ProgressFocuserMove"
        Me.ProgressFocuserMove.Size = New System.Drawing.Size(316, 72)
        Me.ProgressFocuserMove.Step = 1
        Me.ProgressFocuserMove.TabIndex = 2
        Me.ProgressFocuserMove.Visible = False
        '
        'lblFocuserCurrentPosition
        '
        Me.lblFocuserCurrentPosition.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFocuserCurrentPosition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFocuserCurrentPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFocuserCurrentPosition.Location = New System.Drawing.Point(3, 18)
        Me.lblFocuserCurrentPosition.Name = "lblFocuserCurrentPosition"
        Me.lblFocuserCurrentPosition.Size = New System.Drawing.Size(414, 79)
        Me.lblFocuserCurrentPosition.TabIndex = 1
        Me.lblFocuserCurrentPosition.Text = "1000"
        Me.lblFocuserCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelCurrentFocuserPosition
        '
        Me.LabelCurrentFocuserPosition.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelCurrentFocuserPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCurrentFocuserPosition.ForeColor = System.Drawing.Color.MistyRose
        Me.LabelCurrentFocuserPosition.Location = New System.Drawing.Point(24, 18)
        Me.LabelCurrentFocuserPosition.Name = "LabelCurrentFocuserPosition"
        Me.LabelCurrentFocuserPosition.Size = New System.Drawing.Size(349, 0)
        Me.LabelCurrentFocuserPosition.TabIndex = 0
        Me.LabelCurrentFocuserPosition.Text = "5000"
        Me.LabelCurrentFocuserPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bttnSettings
        '
        Me.bttnSettings.BackColor = System.Drawing.Color.Maroon
        Me.bttnSettings.Cursor = System.Windows.Forms.Cursors.Default
        Me.bttnSettings.Enabled = False
        Me.bttnSettings.ForeColor = System.Drawing.Color.Salmon
        Me.bttnSettings.Image = CType(resources.GetObject("bttnSettings.Image"), System.Drawing.Image)
        Me.bttnSettings.Location = New System.Drawing.Point(368, 615)
        Me.bttnSettings.Name = "bttnSettings"
        Me.bttnSettings.Size = New System.Drawing.Size(72, 71)
        Me.bttnSettings.TabIndex = 33
        Me.bttnSettings.UseVisualStyleBackColor = False
        '
        'bttnDisconnect
        '
        Me.bttnDisconnect.BackColor = System.Drawing.Color.Black
        Me.bttnDisconnect.Enabled = False
        Me.bttnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttnDisconnect.Location = New System.Drawing.Point(9, 7)
        Me.bttnDisconnect.Name = "bttnDisconnect"
        Me.bttnDisconnect.Size = New System.Drawing.Size(440, 39)
        Me.bttnDisconnect.TabIndex = 35
        Me.bttnDisconnect.Text = "Disconnect"
        Me.bttnDisconnect.UseVisualStyleBackColor = False
        Me.bttnDisconnect.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(279, 619)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 62)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "TestMe"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtTest
        '
        Me.txtTest.Location = New System.Drawing.Point(29, 619)
        Me.txtTest.Name = "txtTest"
        Me.txtTest.Size = New System.Drawing.Size(226, 22)
        Me.txtTest.TabIndex = 38
        '
        'ComboCOMPorts
        '
        Me.ComboCOMPorts.FormattingEnabled = True
        Me.ComboCOMPorts.Location = New System.Drawing.Point(232, 9)
        Me.ComboCOMPorts.Name = "ComboCOMPorts"
        Me.ComboCOMPorts.Size = New System.Drawing.Size(217, 24)
        Me.ComboCOMPorts.TabIndex = 39
        '
        'TemperatureLabel
        '
        Me.TemperatureLabel.AutoSize = True
        Me.TemperatureLabel.ForeColor = System.Drawing.Color.White
        Me.TemperatureLabel.Location = New System.Drawing.Point(27, 654)
        Me.TemperatureLabel.Name = "TemperatureLabel"
        Me.TemperatureLabel.Size = New System.Drawing.Size(211, 17)
        Me.TemperatureLabel.TabIndex = 40
        Me.TemperatureLabel.Text = "Temperature 40c: Humidity 40%"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(462, 693)
        Me.Controls.Add(Me.TemperatureLabel)
        Me.Controls.Add(Me.ComboCOMPorts)
        Me.Controls.Add(Me.txtTest)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.bttnSettings)
        Me.Controls.Add(Me.panelControl)
        Me.Controls.Add(Me.bttnConnect)
        Me.Controls.Add(Me.bttnDisconnect)
        Me.ForeColor = System.Drawing.Color.Red
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Réalta: Trio"
        Me.panelControl.ResumeLayout(False)
        Me.GroupDew.ResumeLayout(False)
        Me.GroupDew.PerformLayout()
        CType(Me.DewController2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DewController3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DewController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bttnConnect As Button
    Friend WithEvents panelControl As Panel
    Friend WithEvents bttnMoveMax As Button
    Friend WithEvents bttnMoveHome As Button
    Friend WithEvents bttnMoveInLarge As Button
    Friend WithEvents bttnMoveInMedium As Button
    Friend WithEvents bttnMoveInSmall As Button
    Friend WithEvents bttnMoveOutLarge As Button
    Friend WithEvents bttnMoveOutMedium As Button
    Friend WithEvents bttnMoveOutSmall As Button
    Friend WithEvents bttnMoveSaved As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelCurrentFocuserPosition As Label
    Friend WithEvents bttnSaveMove As Button
    Friend WithEvents GroupDew As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DewController2 As TrackBar
    Friend WithEvents DewController3 As TrackBar
    Friend WithEvents chkBoxLockDew As CheckBox
    Friend WithEvents DewController1 As TrackBar
    Friend WithEvents bttnSettings As Button
    Friend WithEvents lblFocuserCurrentPosition As Label
    Friend WithEvents bttnDisconnect As Button
    Protected WithEvents ProgressFocuserMove As ProgressBar
    Friend WithEvents bttnHalt As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents txtTest As TextBox
    Friend WithEvents ComboCOMPorts As ComboBox
    Friend WithEvents TemperatureLabel As Label
End Class
