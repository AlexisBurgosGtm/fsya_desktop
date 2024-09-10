<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl_VentaCantidad
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_VentaCantidad))
        Me.lbUCDesProducto = New DevExpress.XtraEditors.LabelControl()
        Me.txtUCCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.lbCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.LbPrecioUnitarioCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtUCPrecio = New System.Windows.Forms.TextBox()
        Me.txtUCTotal = New System.Windows.Forms.TextBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lbExistenciaProducto = New DevExpress.XtraEditors.LabelControl()
        Me.cmbUCMedida = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LbBonif = New DevExpress.XtraEditors.LabelControl()
        Me.txtUCBonificacion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lbNoSerie = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.lbTituloObs = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCodBodega = New DevExpress.XtraEditors.LabelControl()
        Me.btnDescuento = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRealAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdUCAceptar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUCBonificacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbUCDesProducto
        '
        Me.lbUCDesProducto.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUCDesProducto.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbUCDesProducto.Location = New System.Drawing.Point(22, 12)
        Me.lbUCDesProducto.Name = "lbUCDesProducto"
        Me.lbUCDesProducto.Size = New System.Drawing.Size(255, 29)
        Me.lbUCDesProducto.TabIndex = 24
        Me.lbUCDesProducto.Text = "Descripcion Producto"
        '
        'txtUCCantidad
        '
        Me.txtUCCantidad.Location = New System.Drawing.Point(139, 137)
        Me.txtUCCantidad.Name = "txtUCCantidad"
        Me.txtUCCantidad.Properties.Appearance.BackColor = System.Drawing.Color.OldLace
        Me.txtUCCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtUCCantidad.Properties.Appearance.Options.UseBackColor = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseForeColor = True
        Me.txtUCCantidad.Properties.Mask.EditMask = "n2"
        Me.txtUCCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtUCCantidad.Size = New System.Drawing.Size(138, 36)
        Me.txtUCCantidad.TabIndex = 1
        '
        'lbCantidad
        '
        Me.lbCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCantidad.Location = New System.Drawing.Point(23, 143)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(79, 19)
        Me.lbCantidad.TabIndex = 14
        Me.lbCantidad.Text = "Cantidad:"
        '
        'LbPrecioUnitarioCantidad
        '
        Me.LbPrecioUnitarioCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPrecioUnitarioCantidad.Location = New System.Drawing.Point(488, 99)
        Me.LbPrecioUnitarioCantidad.Name = "LbPrecioUnitarioCantidad"
        Me.LbPrecioUnitarioCantidad.Size = New System.Drawing.Size(128, 19)
        Me.LbPrecioUnitarioCantidad.TabIndex = 19
        Me.LbPrecioUnitarioCantidad.Text = "Precio Unitario:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(488, 152)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(75, 19)
        Me.LabelControl4.TabIndex = 23
        Me.LabelControl4.Text = "Subtotal:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl7.Location = New System.Drawing.Point(646, 95)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl7.TabIndex = 22
        Me.LabelControl7.Text = "Q"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl8.Location = New System.Drawing.Point(646, 148)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl8.TabIndex = 9
        Me.LabelControl8.Text = "Q"
        '
        'txtUCPrecio
        '
        Me.txtUCPrecio.BackColor = System.Drawing.Color.OldLace
        Me.txtUCPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUCPrecio.Enabled = False
        Me.txtUCPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCPrecio.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtUCPrecio.Location = New System.Drawing.Point(677, 97)
        Me.txtUCPrecio.Name = "txtUCPrecio"
        Me.txtUCPrecio.Size = New System.Drawing.Size(120, 28)
        Me.txtUCPrecio.TabIndex = 3
        '
        'txtUCTotal
        '
        Me.txtUCTotal.BackColor = System.Drawing.Color.White
        Me.txtUCTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUCTotal.Enabled = False
        Me.txtUCTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCTotal.ForeColor = System.Drawing.Color.Red
        Me.txtUCTotal.Location = New System.Drawing.Point(677, 149)
        Me.txtUCTotal.Name = "txtUCTotal"
        Me.txtUCTotal.Size = New System.Drawing.Size(120, 28)
        Me.txtUCTotal.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(16, 32)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(89, 19)
        Me.LabelControl1.TabIndex = 12
        Me.LabelControl1.Text = "Existencia:"
        '
        'lbExistenciaProducto
        '
        Me.lbExistenciaProducto.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbExistenciaProducto.Appearance.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.lbExistenciaProducto.Location = New System.Drawing.Point(115, 27)
        Me.lbExistenciaProducto.Name = "lbExistenciaProducto"
        Me.lbExistenciaProducto.Size = New System.Drawing.Size(45, 29)
        Me.lbExistenciaProducto.TabIndex = 10
        Me.lbExistenciaProducto.Text = "100"
        '
        'cmbUCMedida
        '
        Me.cmbUCMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUCMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUCMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUCMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUCMedida.FormattingEnabled = True
        Me.cmbUCMedida.Location = New System.Drawing.Point(139, 90)
        Me.cmbUCMedida.Name = "cmbUCMedida"
        Me.cmbUCMedida.Size = New System.Drawing.Size(319, 33)
        Me.cmbUCMedida.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(23, 95)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 19)
        Me.LabelControl3.TabIndex = 15
        Me.LabelControl3.Text = "Medida:"
        '
        'LbBonif
        '
        Me.LbBonif.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbBonif.Location = New System.Drawing.Point(23, 196)
        Me.LbBonif.Name = "LbBonif"
        Me.LbBonif.Size = New System.Drawing.Size(104, 19)
        Me.LbBonif.TabIndex = 18
        Me.LbBonif.Text = "Bonificación:"
        '
        'txtUCBonificacion
        '
        Me.txtUCBonificacion.Location = New System.Drawing.Point(139, 190)
        Me.txtUCBonificacion.Name = "txtUCBonificacion"
        Me.txtUCBonificacion.Properties.Appearance.BackColor = System.Drawing.Color.OldLace
        Me.txtUCBonificacion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCBonificacion.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtUCBonificacion.Properties.Appearance.Options.UseBackColor = True
        Me.txtUCBonificacion.Properties.Appearance.Options.UseFont = True
        Me.txtUCBonificacion.Properties.Appearance.Options.UseForeColor = True
        Me.txtUCBonificacion.Properties.Mask.EditMask = "n2"
        Me.txtUCBonificacion.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtUCBonificacion.Size = New System.Drawing.Size(138, 36)
        Me.txtUCBonificacion.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(23, 47)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl2.TabIndex = 27
        Me.LabelControl2.Text = "No. Serie:"
        '
        'lbNoSerie
        '
        Me.lbNoSerie.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNoSerie.Location = New System.Drawing.Point(139, 47)
        Me.lbNoSerie.Name = "lbNoSerie"
        Me.lbNoSerie.Size = New System.Drawing.Size(13, 13)
        Me.lbNoSerie.TabIndex = 28
        Me.lbNoSerie.Text = "SN"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.lbExistenciaProducto)
        Me.GroupControl1.Location = New System.Drawing.Point(22, 264)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(239, 77)
        Me.GroupControl1.TabIndex = 29
        Me.GroupControl1.Text = "Inventario"
        '
        'txtObs
        '
        Me.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObs.Location = New System.Drawing.Point(601, 229)
        Me.txtObs.MaxLength = 150
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(254, 51)
        Me.txtObs.TabIndex = 31
        Me.txtObs.Text = "SN"
        '
        'lbTituloObs
        '
        Me.lbTituloObs.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTituloObs.Location = New System.Drawing.Point(476, 229)
        Me.lbTituloObs.Name = "lbTituloObs"
        Me.lbTituloObs.Size = New System.Drawing.Size(87, 19)
        Me.lbTituloObs.TabIndex = 32
        Me.lbTituloObs.Text = "Obs/Serie:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(22, 374)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl6.TabIndex = 33
        Me.LabelControl6.Text = "Bodega:"
        '
        'lbCodBodega
        '
        Me.lbCodBodega.Appearance.Font = New System.Drawing.Font("Tahoma", 9.25!, System.Drawing.FontStyle.Bold)
        Me.lbCodBodega.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCodBodega.Location = New System.Drawing.Point(68, 375)
        Me.lbCodBodega.Name = "lbCodBodega"
        Me.lbCodBodega.Size = New System.Drawing.Size(8, 14)
        Me.lbCodBodega.TabIndex = 34
        Me.lbCodBodega.Text = "1"
        '
        'btnDescuento
        '
        Me.btnDescuento.Image = CType(resources.GetObject("btnDescuento.Image"), System.Drawing.Image)
        Me.btnDescuento.Location = New System.Drawing.Point(809, 97)
        Me.btnDescuento.Name = "btnDescuento"
        Me.btnDescuento.Size = New System.Drawing.Size(64, 28)
        Me.btnDescuento.TabIndex = 30
        Me.btnDescuento.TabStop = False
        Me.btnDescuento.Text = "Desc"
        Me.btnDescuento.Visible = False
        '
        'btnRealAceptar
        '
        Me.btnRealAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRealAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnRealAceptar.Appearance.Options.UseFont = True
        Me.btnRealAceptar.Appearance.Options.UseForeColor = True
        Me.btnRealAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRealAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnRealAceptar.Location = New System.Drawing.Point(886, 375)
        Me.btnRealAceptar.Name = "btnRealAceptar"
        Me.btnRealAceptar.Size = New System.Drawing.Size(125, 58)
        Me.btnRealAceptar.TabIndex = 26
        Me.btnRealAceptar.TabStop = False
        Me.btnRealAceptar.Text = "ACEPTAR"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(508, 325)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(158, 62)
        Me.btnCancelar.TabIndex = 25
        Me.btnCancelar.Text = "CANCELAR"
        '
        'cmdUCAceptar
        '
        Me.cmdUCAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUCAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.cmdUCAceptar.Appearance.Options.UseFont = True
        Me.cmdUCAceptar.Appearance.Options.UseForeColor = True
        Me.cmdUCAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.cmdUCAceptar.Location = New System.Drawing.Point(697, 325)
        Me.cmdUCAceptar.Name = "cmdUCAceptar"
        Me.cmdUCAceptar.Size = New System.Drawing.Size(158, 62)
        Me.cmdUCAceptar.TabIndex = 5
        Me.cmdUCAceptar.Text = "ACEPTAR"
        '
        'UserControl_VentaCantidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lbCodBodega)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.lbTituloObs)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.btnDescuento)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.lbNoSerie)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnRealAceptar)
        Me.Controls.Add(Me.lbUCDesProducto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtUCCantidad)
        Me.Controls.Add(Me.txtUCTotal)
        Me.Controls.Add(Me.LbBonif)
        Me.Controls.Add(Me.lbCantidad)
        Me.Controls.Add(Me.txtUCPrecio)
        Me.Controls.Add(Me.txtUCBonificacion)
        Me.Controls.Add(Me.LbPrecioUnitarioCantidad)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.cmdUCAceptar)
        Me.Controls.Add(Me.cmbUCMedida)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl3)
        Me.Name = "UserControl_VentaCantidad"
        Me.Size = New System.Drawing.Size(887, 405)
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUCBonificacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbUCDesProducto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUCCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbPrecioUnitarioCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUCPrecio As TextBox
    Friend WithEvents txtUCTotal As TextBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbExistenciaProducto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbUCMedida As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdUCAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LbBonif As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUCBonificacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnRealAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbNoSerie As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnDescuento As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtObs As TextBox
    Friend WithEvents lbTituloObs As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCodBodega As DevExpress.XtraEditors.LabelControl
End Class
