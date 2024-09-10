<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewInventariosMinimosDatos
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
        Me.lbDesprod = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMinimo = New DevExpress.XtraEditors.TextEdit()
        Me.txtMaximo = New DevExpress.XtraEditors.TextEdit()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtMinimo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaximo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(27, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(107, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Producto seleccionado"
        '
        'lbDesprod
        '
        Me.lbDesprod.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesprod.Location = New System.Drawing.Point(27, 50)
        Me.lbDesprod.Name = "lbDesprod"
        Me.lbDesprod.Size = New System.Drawing.Size(130, 16)
        Me.lbDesprod.TabIndex = 1
        Me.lbDesprod.Text = "PRODUCTO DESPROD"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(128, 118)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(87, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Mínimo inventario:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(128, 172)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "Máximo inventario:"
        '
        'txtMinimo
        '
        Me.txtMinimo.EnterMoveNextControl = True
        Me.txtMinimo.Location = New System.Drawing.Point(247, 115)
        Me.txtMinimo.Name = "txtMinimo"
        Me.txtMinimo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinimo.Properties.Appearance.Options.UseFont = True
        Me.txtMinimo.Properties.Mask.EditMask = "n0"
        Me.txtMinimo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMinimo.Size = New System.Drawing.Size(100, 26)
        Me.txtMinimo.TabIndex = 4
        '
        'txtMaximo
        '
        Me.txtMaximo.EnterMoveNextControl = True
        Me.txtMaximo.Location = New System.Drawing.Point(247, 164)
        Me.txtMaximo.Name = "txtMaximo"
        Me.txtMaximo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaximo.Properties.Appearance.Options.UseFont = True
        Me.txtMaximo.Properties.Mask.EditMask = "n0"
        Me.txtMaximo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMaximo.Size = New System.Drawing.Size(100, 26)
        Me.txtMaximo.TabIndex = 5
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
        Me.btnAceptar.Location = New System.Drawing.Point(326, 253)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(130, 49)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "ACEPTAR"
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
        Me.btnCancelar.Location = New System.Drawing.Point(163, 253)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(130, 49)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "CANCELAR"
        '
        'viewInventariosMinimosDatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtMaximo)
        Me.Controls.Add(Me.txtMinimo)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.lbDesprod)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewInventariosMinimosDatos"
        Me.Size = New System.Drawing.Size(504, 321)
        CType(Me.txtMinimo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaximo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbDesprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMinimo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMaximo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
End Class
