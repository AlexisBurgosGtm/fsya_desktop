<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SplashScreenDIST
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreenDIST))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.progressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.pictureEdit2 = New DevExpress.XtraEditors.PictureEdit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(-2, -2)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(274, 295)
        Me.TextBox1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Black
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(29, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 142)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'progressPanel1
        '
        Me.progressPanel1.Appearance.BackColor = System.Drawing.Color.Black
        Me.progressPanel1.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.progressPanel1.Appearance.Options.UseBackColor = True
        Me.progressPanel1.Appearance.Options.UseForeColor = True
        Me.progressPanel1.AppearanceCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.progressPanel1.AppearanceCaption.ForeColor = System.Drawing.Color.Gray
        Me.progressPanel1.AppearanceCaption.Options.UseFont = True
        Me.progressPanel1.AppearanceCaption.Options.UseForeColor = True
        Me.progressPanel1.AppearanceDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.progressPanel1.AppearanceDescription.ForeColor = System.Drawing.Color.Silver
        Me.progressPanel1.AppearanceDescription.Options.UseFont = True
        Me.progressPanel1.AppearanceDescription.Options.UseForeColor = True
        Me.progressPanel1.Caption = ""
        Me.progressPanel1.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.progressPanel1.Description = "Iniciando..."
        Me.progressPanel1.ImageHorzOffset = 20
        Me.progressPanel1.Location = New System.Drawing.Point(9, 244)
        Me.progressPanel1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.progressPanel1.Name = "progressPanel1"
        Me.progressPanel1.RingAnimationDiameter = 80
        Me.progressPanel1.Size = New System.Drawing.Size(251, 34)
        Me.progressPanel1.TabIndex = 21
        Me.progressPanel1.Text = "progressPanel1"
        Me.progressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Line
        '
        'pictureEdit2
        '
        Me.pictureEdit2.Cursor = System.Windows.Forms.Cursors.Default
        Me.pictureEdit2.EditValue = CType(resources.GetObject("pictureEdit2.EditValue"), Object)
        Me.pictureEdit2.Location = New System.Drawing.Point(0, 112)
        Me.pictureEdit2.Name = "pictureEdit2"
        Me.pictureEdit2.Properties.AllowFocused = False
        Me.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Black
        Me.pictureEdit2.Properties.Appearance.Options.UseBackColor = True
        Me.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pictureEdit2.Properties.ShowMenu = False
        Me.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.pictureEdit2.Properties.ZoomAccelerationFactor = 1.0R
        Me.pictureEdit2.Size = New System.Drawing.Size(266, 185)
        Me.pictureEdit2.TabIndex = 20
        '
        'SplashScreenDIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 295)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.progressPanel1)
        Me.Controls.Add(Me.pictureEdit2)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "SplashScreenDIST"
        Me.Opacity = 0.9R
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Private WithEvents progressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Private WithEvents pictureEdit2 As DevExpress.XtraEditors.PictureEdit
End Class
