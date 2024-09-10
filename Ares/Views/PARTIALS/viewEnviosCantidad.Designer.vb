<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewEnviosCantidad
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
        Me.lbNoSerie = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnRealAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbUCDesProducto = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtUCCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.txtUCTotal = New System.Windows.Forms.TextBox()
        Me.LbBonif = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.txtUCPrecio = New System.Windows.Forms.TextBox()
        Me.txtUCBonificacion = New DevExpress.XtraEditors.TextEdit()
        Me.lbExistenciaProducto = New DevExpress.XtraEditors.LabelControl()
        Me.LbPrecioUnitarioCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdUCAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbUCMedida = New System.Windows.Forms.ComboBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUCBonificacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbNoSerie
        '
        Me.lbNoSerie.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNoSerie.Location = New System.Drawing.Point(149, 52)
        Me.lbNoSerie.Name = "lbNoSerie"
        Me.lbNoSerie.Size = New System.Drawing.Size(13, 13)
        Me.lbNoSerie.TabIndex = 48
        Me.lbNoSerie.Text = "SN"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(33, 52)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl2.TabIndex = 47
        Me.LabelControl2.Text = "No. Serie:"
        '
        'btnRealAceptar
        '
        Me.btnRealAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRealAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnRealAceptar.Appearance.Options.UseFont = True
        Me.btnRealAceptar.Appearance.Options.UseForeColor = True
        Me.btnRealAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRealAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnRealAceptar.Location = New System.Drawing.Point(896, 380)
        Me.btnRealAceptar.Name = "btnRealAceptar"
        Me.btnRealAceptar.Size = New System.Drawing.Size(125, 58)
        Me.btnRealAceptar.TabIndex = 46
        Me.btnRealAceptar.TabStop = False
        Me.btnRealAceptar.Text = "ACEPTAR"
        '
        'lbUCDesProducto
        '
        Me.lbUCDesProducto.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUCDesProducto.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbUCDesProducto.Location = New System.Drawing.Point(32, 17)
        Me.lbUCDesProducto.Name = "lbUCDesProducto"
        Me.lbUCDesProducto.Size = New System.Drawing.Size(255, 29)
        Me.lbUCDesProducto.TabIndex = 44
        Me.lbUCDesProducto.Text = "Descripcion Producto"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(491, 226)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 58)
        Me.btnCancelar.TabIndex = 45
        Me.btnCancelar.Text = "CANCELAR"
        '
        'txtUCCantidad
        '
        Me.txtUCCantidad.Location = New System.Drawing.Point(149, 129)
        Me.txtUCCantidad.Name = "txtUCCantidad"
        Me.txtUCCantidad.Properties.Appearance.BackColor = System.Drawing.Color.OldLace
        Me.txtUCCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtUCCantidad.Properties.Appearance.Options.UseBackColor = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseForeColor = True
        Me.txtUCCantidad.Properties.Mask.EditMask = "n2"
        Me.txtUCCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtUCCantidad.Size = New System.Drawing.Size(105, 36)
        Me.txtUCCantidad.TabIndex = 30
        '
        'txtUCTotal
        '
        Me.txtUCTotal.BackColor = System.Drawing.Color.White
        Me.txtUCTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUCTotal.Enabled = False
        Me.txtUCTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCTotal.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtUCTotal.Location = New System.Drawing.Point(687, 139)
        Me.txtUCTotal.Name = "txtUCTotal"
        Me.txtUCTotal.Size = New System.Drawing.Size(120, 28)
        Me.txtUCTotal.TabIndex = 33
        '
        'LbBonif
        '
        Me.LbBonif.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbBonif.Location = New System.Drawing.Point(33, 188)
        Me.LbBonif.Name = "LbBonif"
        Me.LbBonif.Size = New System.Drawing.Size(104, 19)
        Me.LbBonif.TabIndex = 40
        Me.LbBonif.Text = "Bonificación:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(33, 256)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(89, 19)
        Me.LabelControl1.TabIndex = 37
        Me.LabelControl1.Text = "Existencia:"
        '
        'lbCantidad
        '
        Me.lbCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCantidad.Location = New System.Drawing.Point(33, 135)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(79, 19)
        Me.lbCantidad.TabIndex = 38
        Me.lbCantidad.Text = "Cantidad:"
        '
        'txtUCPrecio
        '
        Me.txtUCPrecio.BackColor = System.Drawing.Color.OldLace
        Me.txtUCPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUCPrecio.Enabled = False
        Me.txtUCPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCPrecio.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtUCPrecio.Location = New System.Drawing.Point(687, 89)
        Me.txtUCPrecio.Name = "txtUCPrecio"
        Me.txtUCPrecio.Size = New System.Drawing.Size(120, 28)
        Me.txtUCPrecio.TabIndex = 32
        '
        'txtUCBonificacion
        '
        Me.txtUCBonificacion.Location = New System.Drawing.Point(149, 182)
        Me.txtUCBonificacion.Name = "txtUCBonificacion"
        Me.txtUCBonificacion.Properties.Appearance.BackColor = System.Drawing.Color.OldLace
        Me.txtUCBonificacion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCBonificacion.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtUCBonificacion.Properties.Appearance.Options.UseBackColor = True
        Me.txtUCBonificacion.Properties.Appearance.Options.UseFont = True
        Me.txtUCBonificacion.Properties.Appearance.Options.UseForeColor = True
        Me.txtUCBonificacion.Properties.Mask.EditMask = "n2"
        Me.txtUCBonificacion.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtUCBonificacion.Size = New System.Drawing.Size(105, 36)
        Me.txtUCBonificacion.TabIndex = 31
        '
        'lbExistenciaProducto
        '
        Me.lbExistenciaProducto.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbExistenciaProducto.Appearance.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.lbExistenciaProducto.Location = New System.Drawing.Point(132, 252)
        Me.lbExistenciaProducto.Name = "lbExistenciaProducto"
        Me.lbExistenciaProducto.Size = New System.Drawing.Size(45, 29)
        Me.lbExistenciaProducto.TabIndex = 36
        Me.lbExistenciaProducto.Text = "100"
        '
        'LbPrecioUnitarioCantidad
        '
        Me.LbPrecioUnitarioCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPrecioUnitarioCantidad.Location = New System.Drawing.Point(498, 91)
        Me.LbPrecioUnitarioCantidad.Name = "LbPrecioUnitarioCantidad"
        Me.LbPrecioUnitarioCantidad.Size = New System.Drawing.Size(128, 19)
        Me.LbPrecioUnitarioCantidad.TabIndex = 41
        Me.LbPrecioUnitarioCantidad.Text = "Precio Unitario:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl8.Location = New System.Drawing.Point(656, 138)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl8.TabIndex = 35
        Me.LabelControl8.Text = "Q"
        '
        'cmdUCAceptar
        '
        Me.cmdUCAceptar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdUCAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUCAceptar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdUCAceptar.Appearance.Options.UseBackColor = True
        Me.cmdUCAceptar.Appearance.Options.UseFont = True
        Me.cmdUCAceptar.Appearance.Options.UseForeColor = True
        Me.cmdUCAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdUCAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.cmdUCAceptar.Location = New System.Drawing.Point(680, 226)
        Me.cmdUCAceptar.Name = "cmdUCAceptar"
        Me.cmdUCAceptar.Size = New System.Drawing.Size(150, 58)
        Me.cmdUCAceptar.TabIndex = 34
        Me.cmdUCAceptar.Text = "ACEPTAR"
        '
        'cmbUCMedida
        '
        Me.cmbUCMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUCMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUCMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUCMedida.FormattingEnabled = True
        Me.cmbUCMedida.Location = New System.Drawing.Point(149, 82)
        Me.cmbUCMedida.Name = "cmbUCMedida"
        Me.cmbUCMedida.Size = New System.Drawing.Size(319, 33)
        Me.cmbUCMedida.TabIndex = 29
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(498, 142)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(75, 19)
        Me.LabelControl4.TabIndex = 43
        Me.LabelControl4.Text = "Subtotal:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl7.Location = New System.Drawing.Point(656, 87)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl7.TabIndex = 42
        Me.LabelControl7.Text = "Q"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(33, 87)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 19)
        Me.LabelControl3.TabIndex = 39
        Me.LabelControl3.Text = "Medida:"
        '
        'viewEnviosCantidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbNoSerie)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnRealAceptar)
        Me.Controls.Add(Me.lbUCDesProducto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtUCCantidad)
        Me.Controls.Add(Me.txtUCTotal)
        Me.Controls.Add(Me.LbBonif)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.lbCantidad)
        Me.Controls.Add(Me.txtUCPrecio)
        Me.Controls.Add(Me.txtUCBonificacion)
        Me.Controls.Add(Me.lbExistenciaProducto)
        Me.Controls.Add(Me.LbPrecioUnitarioCantidad)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.cmdUCAceptar)
        Me.Controls.Add(Me.cmbUCMedida)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl3)
        Me.Name = "viewEnviosCantidad"
        Me.Size = New System.Drawing.Size(849, 318)
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUCBonificacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbNoSerie As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRealAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbUCDesProducto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUCCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUCTotal As TextBox
    Friend WithEvents LbBonif As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUCPrecio As TextBox
    Friend WithEvents txtUCBonificacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbExistenciaProducto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbPrecioUnitarioCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdUCAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbUCMedida As ComboBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
