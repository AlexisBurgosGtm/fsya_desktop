<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminChangeCode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminChangeCode))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNuevoCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCodigoActual = New DevExpress.XtraEditors.TextEdit()
        Me.lbDesProd = New DevExpress.XtraEditors.LabelControl()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmdCambiarCodigo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtNuevoCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoActual.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(123, 158)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(83, 16)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Nuevo Código:"
        '
        'txtNuevoCodigo
        '
        Me.txtNuevoCodigo.Location = New System.Drawing.Point(223, 155)
        Me.txtNuevoCodigo.Name = "txtNuevoCodigo"
        Me.txtNuevoCodigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNuevoCodigo.Properties.Appearance.Options.UseFont = True
        Me.txtNuevoCodigo.Size = New System.Drawing.Size(268, 26)
        Me.txtNuevoCodigo.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(123, 15)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(250, 19)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Cambio de Código de Producto"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(123, 109)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(83, 16)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Código Actual:"
        '
        'txtCodigoActual
        '
        Me.txtCodigoActual.Enabled = False
        Me.txtCodigoActual.Location = New System.Drawing.Point(223, 104)
        Me.txtCodigoActual.Name = "txtCodigoActual"
        Me.txtCodigoActual.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoActual.Properties.Appearance.Options.UseFont = True
        Me.txtCodigoActual.Size = New System.Drawing.Size(268, 26)
        Me.txtCodigoActual.TabIndex = 4
        '
        'lbDesProd
        '
        Me.lbDesProd.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesProd.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDesProd.Location = New System.Drawing.Point(223, 64)
        Me.lbDesProd.Name = "lbDesProd"
        Me.lbDesProd.Size = New System.Drawing.Size(74, 16)
        Me.lbDesProd.TabIndex = 6
        Me.lbDesProd.Text = "Descripcion"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(6, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(99, 85)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'cmdCambiarCodigo
        '
        Me.cmdCambiarCodigo.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdCambiarCodigo.Image = CType(resources.GetObject("cmdCambiarCodigo.Image"), System.Drawing.Image)
        Me.cmdCambiarCodigo.Location = New System.Drawing.Point(371, 214)
        Me.cmdCambiarCodigo.Name = "cmdCambiarCodigo"
        Me.cmdCambiarCodigo.Size = New System.Drawing.Size(120, 51)
        Me.cmdCambiarCodigo.TabIndex = 5
        Me.cmdCambiarCodigo.Text = "Cambiar"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(213, 214)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(120, 51)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(123, 64)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(55, 16)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Producto:"
        '
        'AdminChangeCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbDesProd)
        Me.Controls.Add(Me.cmdCambiarCodigo)
        Me.Controls.Add(Me.txtCodigoActual)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtNuevoCodigo)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "AdminChangeCode"
        Me.Size = New System.Drawing.Size(675, 294)
        CType(Me.txtNuevoCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoActual.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNuevoCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCodigoActual As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdCambiarCodigo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbDesProd As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class
