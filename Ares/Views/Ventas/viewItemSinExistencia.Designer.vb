<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewItemSinExistencia
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtCosto = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.txtTotalPrecio = New System.Windows.Forms.TextBox()
        Me.lbCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.LbPrecioUnitarioCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbMedida = New System.Windows.Forms.ComboBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtCosto)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtDescripcion)
        Me.GroupControl1.Controls.Add(Me.btnCancelar)
        Me.GroupControl1.Controls.Add(Me.txtCantidad)
        Me.GroupControl1.Controls.Add(Me.txtTotalPrecio)
        Me.GroupControl1.Controls.Add(Me.lbCantidad)
        Me.GroupControl1.Controls.Add(Me.txtPrecio)
        Me.GroupControl1.Controls.Add(Me.LbPrecioUnitarioCantidad)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.btnAceptar)
        Me.GroupControl1.Controls.Add(Me.cmbMedida)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Location = New System.Drawing.Point(5, 5)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(893, 412)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Producto sin Ingreso a Catálogo"
        '
        'txtCosto
        '
        Me.txtCosto.BackColor = System.Drawing.Color.OldLace
        Me.txtCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCosto.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtCosto.Location = New System.Drawing.Point(698, 153)
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(120, 35)
        Me.txtCosto.TabIndex = 3
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(509, 155)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(123, 19)
        Me.LabelControl2.TabIndex = 50
        Me.LabelControl2.Text = "Costo Unitario:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl5.Location = New System.Drawing.Point(667, 151)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl5.TabIndex = 51
        Me.LabelControl5.Text = "Q"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(36, 62)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(285, 19)
        Me.LabelControl1.TabIndex = 48
        Me.LabelControl1.Text = "Descripción del Producto o Servicio"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(36, 92)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Properties.Appearance.Options.UseFont = True
        Me.txtDescripcion.Size = New System.Drawing.Size(782, 30)
        Me.txtDescripcion.TabIndex = 0
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(518, 332)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(158, 62)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "CANCELAR"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(152, 194)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Appearance.BackColor = System.Drawing.Color.OldLace
        Me.txtCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtCantidad.Properties.Appearance.Options.UseBackColor = True
        Me.txtCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtCantidad.Properties.Appearance.Options.UseForeColor = True
        Me.txtCantidad.Size = New System.Drawing.Size(105, 36)
        Me.txtCantidad.TabIndex = 2
        '
        'txtTotalPrecio
        '
        Me.txtTotalPrecio.BackColor = System.Drawing.Color.White
        Me.txtTotalPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPrecio.Enabled = False
        Me.txtTotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrecio.ForeColor = System.Drawing.Color.Red
        Me.txtTotalPrecio.Location = New System.Drawing.Point(698, 266)
        Me.txtTotalPrecio.Name = "txtTotalPrecio"
        Me.txtTotalPrecio.Size = New System.Drawing.Size(120, 28)
        Me.txtTotalPrecio.TabIndex = 36
        '
        'lbCantidad
        '
        Me.lbCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCantidad.Location = New System.Drawing.Point(36, 200)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(79, 19)
        Me.lbCantidad.TabIndex = 39
        Me.lbCantidad.Text = "Cantidad:"
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.OldLace
        Me.txtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtPrecio.Location = New System.Drawing.Point(698, 207)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(120, 35)
        Me.txtPrecio.TabIndex = 4
        '
        'LbPrecioUnitarioCantidad
        '
        Me.LbPrecioUnitarioCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPrecioUnitarioCantidad.Location = New System.Drawing.Point(509, 213)
        Me.LbPrecioUnitarioCantidad.Name = "LbPrecioUnitarioCantidad"
        Me.LbPrecioUnitarioCantidad.Size = New System.Drawing.Size(128, 19)
        Me.LbPrecioUnitarioCantidad.TabIndex = 42
        Me.LbPrecioUnitarioCantidad.Text = "Precio Unitario:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl8.Location = New System.Drawing.Point(667, 265)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl8.TabIndex = 38
        Me.LabelControl8.Text = "Q"
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnAceptar.Appearance.Options.UseFont = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(707, 332)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(158, 62)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "ACEPTAR"
        '
        'cmbMedida
        '
        Me.cmbMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedida.FormattingEnabled = True
        Me.cmbMedida.Location = New System.Drawing.Point(152, 148)
        Me.cmbMedida.Name = "cmbMedida"
        Me.cmbMedida.Size = New System.Drawing.Size(319, 33)
        Me.cmbMedida.TabIndex = 1
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(509, 269)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(75, 19)
        Me.LabelControl4.TabIndex = 44
        Me.LabelControl4.Text = "Subtotal:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl7.Location = New System.Drawing.Point(667, 205)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl7.TabIndex = 43
        Me.LabelControl7.Text = "Q"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(36, 153)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 19)
        Me.LabelControl3.TabIndex = 40
        Me.LabelControl3.Text = "Medida:"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(402, 474)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 52
        Me.btnAceptarTrue.Text = "Aceptar"
        '
        'viewItemSinExistencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewItemSinExistencia"
        Me.Size = New System.Drawing.Size(902, 422)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtCosto As TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTotalPrecio As TextBox
    Friend WithEvents lbCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents LbPrecioUnitarioCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbMedida As ComboBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
End Class
