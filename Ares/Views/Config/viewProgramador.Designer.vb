<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewProgramador
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewProgramador))
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.txtQuery = New System.Windows.Forms.TextBox()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton4 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton5 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton6 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton7 = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbSUCURSALES = New System.Windows.Forms.ComboBox()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Location = New System.Drawing.Point(22, 168)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(865, 277)
        Me.grid.TabIndex = 0
        '
        'txtQuery
        '
        Me.txtQuery.Location = New System.Drawing.Point(37, 23)
        Me.txtQuery.Multiline = True
        Me.txtQuery.Name = "txtQuery"
        Me.txtQuery.Size = New System.Drawing.Size(661, 130)
        Me.txtQuery.TabIndex = 1
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(709, 65)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(121, 34)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "run"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(709, 119)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(121, 34)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "select"
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Location = New System.Drawing.Point(737, 460)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(150, 34)
        Me.SimpleButton3.TabIndex = 4
        Me.SimpleButton3.Text = "INDEXAR DB"
        '
        'SimpleButton4
        '
        Me.SimpleButton4.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.SimpleButton4.Appearance.Options.UseBackColor = True
        Me.SimpleButton4.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton4.Location = New System.Drawing.Point(836, 65)
        Me.SimpleButton4.Name = "SimpleButton4"
        Me.SimpleButton4.Size = New System.Drawing.Size(56, 34)
        Me.SimpleButton4.TabIndex = 5
        Me.SimpleButton4.Text = "NEW"
        '
        'SimpleButton5
        '
        Me.SimpleButton5.Location = New System.Drawing.Point(541, 460)
        Me.SimpleButton5.Name = "SimpleButton5"
        Me.SimpleButton5.Size = New System.Drawing.Size(170, 34)
        Me.SimpleButton5.TabIndex = 6
        Me.SimpleButton5.Text = "ACTUALIZAR ESTADISTICAS"
        '
        'SimpleButton6
        '
        Me.SimpleButton6.Location = New System.Drawing.Point(350, 460)
        Me.SimpleButton6.Name = "SimpleButton6"
        Me.SimpleButton6.Size = New System.Drawing.Size(170, 34)
        Me.SimpleButton6.TabIndex = 7
        Me.SimpleButton6.Text = "REDUCIR LOG"
        '
        'SimpleButton7
        '
        Me.SimpleButton7.Location = New System.Drawing.Point(22, 460)
        Me.SimpleButton7.Name = "SimpleButton7"
        Me.SimpleButton7.Size = New System.Drawing.Size(170, 34)
        Me.SimpleButton7.TabIndex = 8
        Me.SimpleButton7.Text = "CAMBIAR EMPNIT EMP"
        '
        'cmbSUCURSALES
        '
        Me.cmbSUCURSALES.FormattingEnabled = True
        Me.cmbSUCURSALES.Location = New System.Drawing.Point(709, 23)
        Me.cmbSUCURSALES.Name = "cmbSUCURSALES"
        Me.cmbSUCURSALES.Size = New System.Drawing.Size(121, 21)
        Me.cmbSUCURSALES.TabIndex = 241
        '
        'viewProgramador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmbSUCURSALES)
        Me.Controls.Add(Me.SimpleButton7)
        Me.Controls.Add(Me.SimpleButton6)
        Me.Controls.Add(Me.SimpleButton5)
        Me.Controls.Add(Me.SimpleButton4)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.txtQuery)
        Me.Controls.Add(Me.grid)
        Me.Name = "viewProgramador"
        Me.Size = New System.Drawing.Size(913, 507)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grid As DataGridView
    Friend WithEvents txtQuery As TextBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton4 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton5 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton6 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton7 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbSUCURSALES As ComboBox
End Class
