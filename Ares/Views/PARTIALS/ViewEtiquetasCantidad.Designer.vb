<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEtiquetasCantidad
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCantidad = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbCodMedOferta = New System.Windows.Forms.ComboBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lbPrimerMedida = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbPrecioMedOf = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(56, 94)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(250, 19)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "¿Cuántas etiquetas imprimirá?"
        '
        'cmbCantidad
        '
        Me.cmbCantidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCantidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCantidad.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCantidad.FormattingEnabled = True
        Me.cmbCantidad.Location = New System.Drawing.Point(349, 90)
        Me.cmbCantidad.Name = "cmbCantidad"
        Me.cmbCantidad.Size = New System.Drawing.Size(121, 33)
        Me.cmbCantidad.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(396, 228)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(132, 52)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(569, 228)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(132, 52)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        '
        'cmbCodMedOferta
        '
        Me.cmbCodMedOferta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCodMedOferta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCodMedOferta.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCodMedOferta.FormattingEnabled = True
        Me.cmbCodMedOferta.Location = New System.Drawing.Point(314, 153)
        Me.cmbCodMedOferta.Name = "cmbCodMedOferta"
        Me.cmbCodMedOferta.Size = New System.Drawing.Size(156, 33)
        Me.cmbCodMedOferta.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(56, 161)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(225, 19)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Indique el precio de Oferta:"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lbPrimerMedida)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.lbPrecioMedOf)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.cmbCantidad)
        Me.GroupControl1.Controls.Add(Me.cmbCodMedOferta)
        Me.GroupControl1.Controls.Add(Me.btnAceptar)
        Me.GroupControl1.Controls.Add(Me.btnCancelar)
        Me.GroupControl1.Location = New System.Drawing.Point(8, 4)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(726, 298)
        Me.GroupControl1.TabIndex = 6
        Me.GroupControl1.Text = "Opciones"
        '
        'lbPrimerMedida
        '
        Me.lbPrimerMedida.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrimerMedida.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbPrimerMedida.Location = New System.Drawing.Point(152, 33)
        Me.lbPrimerMedida.Name = "lbPrimerMedida"
        Me.lbPrimerMedida.Size = New System.Drawing.Size(79, 23)
        Me.lbPrimerMedida.TabIndex = 8
        Me.lbPrimerMedida.Text = "UNIDAD"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(20, 33)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(116, 19)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Primer precio:"
        '
        'lbPrecioMedOf
        '
        Me.lbPrecioMedOf.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrecioMedOf.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbPrecioMedOf.Location = New System.Drawing.Point(483, 157)
        Me.lbPrecioMedOf.Name = "lbPrecioMedOf"
        Me.lbPrecioMedOf.Size = New System.Drawing.Size(129, 23)
        Me.lbPrecioMedOf.TabIndex = 6
        Me.lbPrecioMedOf.Text = "Q 999,999.99"
        '
        'ViewEtiquetasCantidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "ViewEtiquetasCantidad"
        Me.Size = New System.Drawing.Size(742, 304)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCantidad As ComboBox
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbCodMedOferta As ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbPrecioMedOf As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbPrimerMedida As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
End Class
