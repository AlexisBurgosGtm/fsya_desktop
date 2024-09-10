<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_TrasladosCantidad
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
        Me.lbUCDesProducto = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.cmdUCAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbUCMedida = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnRealAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtUCCantidad = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbNoSerie
        '
        Me.lbNoSerie.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNoSerie.Location = New System.Drawing.Point(141, 52)
        Me.lbNoSerie.Name = "lbNoSerie"
        Me.lbNoSerie.Size = New System.Drawing.Size(13, 13)
        Me.lbNoSerie.TabIndex = 51
        Me.lbNoSerie.Text = "SN"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(25, 52)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl2.TabIndex = 50
        Me.LabelControl2.Text = "No. Serie:"
        '
        'lbUCDesProducto
        '
        Me.lbUCDesProducto.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUCDesProducto.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbUCDesProducto.Location = New System.Drawing.Point(24, 17)
        Me.lbUCDesProducto.Name = "lbUCDesProducto"
        Me.lbUCDesProducto.Size = New System.Drawing.Size(255, 29)
        Me.lbUCDesProducto.TabIndex = 48
        Me.lbUCDesProducto.Text = "Descripcion Producto"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(672, 138)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(158, 42)
        Me.btnCancelar.TabIndex = 49
        Me.btnCancelar.Text = "CANCELAR"
        '
        'lbCantidad
        '
        Me.lbCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCantidad.Location = New System.Drawing.Point(25, 148)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(79, 19)
        Me.lbCantidad.TabIndex = 42
        Me.lbCantidad.Text = "Cantidad:"
        '
        'cmdUCAceptar
        '
        Me.cmdUCAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUCAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.cmdUCAceptar.Appearance.Options.UseFont = True
        Me.cmdUCAceptar.Appearance.Options.UseForeColor = True
        Me.cmdUCAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdUCAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.cmdUCAceptar.Location = New System.Drawing.Point(672, 90)
        Me.cmdUCAceptar.Name = "cmdUCAceptar"
        Me.cmdUCAceptar.Size = New System.Drawing.Size(158, 42)
        Me.cmdUCAceptar.TabIndex = 40
        Me.cmdUCAceptar.Text = "ACEPTAR"
        '
        'cmbUCMedida
        '
        Me.cmbUCMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUCMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUCMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUCMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUCMedida.FormattingEnabled = True
        Me.cmbUCMedida.Location = New System.Drawing.Point(141, 95)
        Me.cmbUCMedida.Name = "cmbUCMedida"
        Me.cmbUCMedida.Size = New System.Drawing.Size(449, 33)
        Me.cmbUCMedida.TabIndex = 35
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(25, 100)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 19)
        Me.LabelControl3.TabIndex = 43
        Me.LabelControl3.Text = "Medida:"
        '
        'btnRealAceptar
        '
        Me.btnRealAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRealAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnRealAceptar.Appearance.Options.UseFont = True
        Me.btnRealAceptar.Appearance.Options.UseForeColor = True
        Me.btnRealAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRealAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnRealAceptar.Location = New System.Drawing.Point(875, 17)
        Me.btnRealAceptar.Name = "btnRealAceptar"
        Me.btnRealAceptar.Size = New System.Drawing.Size(125, 58)
        Me.btnRealAceptar.TabIndex = 52
        Me.btnRealAceptar.TabStop = False
        Me.btnRealAceptar.Text = "ACEPTAR"
        '
        'txtUCCantidad
        '
        Me.txtUCCantidad.Location = New System.Drawing.Point(141, 142)
        Me.txtUCCantidad.Name = "txtUCCantidad"
        Me.txtUCCantidad.Properties.Appearance.BackColor = System.Drawing.Color.OldLace
        Me.txtUCCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtUCCantidad.Properties.Appearance.Options.UseBackColor = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseForeColor = True
        Me.txtUCCantidad.Properties.Mask.EditMask = "n0"
        Me.txtUCCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtUCCantidad.Size = New System.Drawing.Size(138, 36)
        Me.txtUCCantidad.TabIndex = 36
        '
        'UserControl_TrasladosCantidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnRealAceptar)
        Me.Controls.Add(Me.lbNoSerie)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.lbUCDesProducto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtUCCantidad)
        Me.Controls.Add(Me.lbCantidad)
        Me.Controls.Add(Me.cmdUCAceptar)
        Me.Controls.Add(Me.cmbUCMedida)
        Me.Controls.Add(Me.LabelControl3)
        Me.Name = "UserControl_TrasladosCantidad"
        Me.Size = New System.Drawing.Size(857, 198)
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbNoSerie As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbUCDesProducto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdUCAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbUCMedida As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRealAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUCCantidad As DevExpress.XtraEditors.TextEdit
End Class
