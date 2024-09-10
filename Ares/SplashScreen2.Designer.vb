<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen2
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen2))
        Me.progressPanel1 = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.pictureEdit2 = New DevExpress.XtraEditors.PictureEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'progressPanel1
        '
        Me.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent
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
        Me.progressPanel1.TabIndex = 18
        Me.progressPanel1.Text = "progressPanel1"
        Me.progressPanel1.WaitAnimationType = DevExpress.Utils.Animation.WaitingAnimatorType.Line
        '
        'pictureEdit2
        '
        Me.pictureEdit2.Cursor = System.Windows.Forms.Cursors.Default
        Me.pictureEdit2.EditValue = CType(resources.GetObject("pictureEdit2.EditValue"), Object)
        Me.pictureEdit2.Location = New System.Drawing.Point(-3, 114)
        Me.pictureEdit2.Name = "pictureEdit2"
        Me.pictureEdit2.Properties.AllowFocused = False
        Me.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.pictureEdit2.Properties.Appearance.Options.UseBackColor = True
        Me.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.pictureEdit2.Properties.ShowMenu = False
        Me.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.pictureEdit2.Properties.ZoomAccelerationFactor = 1.0R
        Me.pictureEdit2.Size = New System.Drawing.Size(275, 185)
        Me.pictureEdit2.TabIndex = 14
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(29, 17)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(207, 142)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'SplashScreen2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 295)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.progressPanel1)
        Me.Controls.Add(Me.pictureEdit2)
        Me.Name = "SplashScreen2"
        Me.Opacity = 0.9R
        Me.Text = "Form1"
        CType(Me.pictureEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pictureEdit2 As DevExpress.XtraEditors.PictureEdit
    Private WithEvents progressPanel1 As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents PictureBox1 As PictureBox
End Class
