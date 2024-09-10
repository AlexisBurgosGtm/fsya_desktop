<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewInvFisicoConteo
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
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtConteo = New DevExpress.XtraEditors.TextEdit()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.lbDesprod = New DevExpress.XtraEditors.LabelControl()
        Me.lbCodprod = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMedida = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lbEquivale = New DevExpress.XtraEditors.LabelControl()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtConteo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(54, 181)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(116, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "CONTEO EN UNIDADES:"
        '
        'txtConteo
        '
        Me.txtConteo.Enabled = False
        Me.txtConteo.Location = New System.Drawing.Point(183, 174)
        Me.txtConteo.Name = "txtConteo"
        Me.txtConteo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConteo.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.txtConteo.Properties.Appearance.Options.UseFont = True
        Me.txtConteo.Properties.Appearance.Options.UseForeColor = True
        Me.txtConteo.Properties.Mask.EditMask = "n0"
        Me.txtConteo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtConteo.Size = New System.Drawing.Size(127, 30)
        Me.txtConteo.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(652, 181)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(187, 60)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "AGREGAR"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(434, 66)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(88, 13)
        Me.LabelControl9.TabIndex = 18
        Me.LabelControl9.Text = "OBSERVACIONES:"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(434, 88)
        Me.txtObs.MaxLength = 100
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(405, 60)
        Me.txtObs.TabIndex = 2
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
        Me.btnCancelar.Location = New System.Drawing.Point(420, 181)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(187, 60)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "CANCELAR"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(496, 321)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 19
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "aceptar"
        '
        'lbDesprod
        '
        Me.lbDesprod.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesprod.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDesprod.Location = New System.Drawing.Point(25, 14)
        Me.lbDesprod.Name = "lbDesprod"
        Me.lbDesprod.Size = New System.Drawing.Size(249, 19)
        Me.lbDesprod.TabIndex = 20
        Me.lbDesprod.Text = "DESCRIPCION DEL PRODUCTO"
        '
        'lbCodprod
        '
        Me.lbCodprod.Location = New System.Drawing.Point(25, 39)
        Me.lbCodprod.Name = "lbCodprod"
        Me.lbCodprod.Size = New System.Drawing.Size(150, 13)
        Me.lbCodprod.TabIndex = 21
        Me.lbCodprod.Text = "9999999999999999999999999"
        '
        'cmbMedida
        '
        Me.cmbMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMedida.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedida.FormattingEnabled = True
        Me.cmbMedida.Location = New System.Drawing.Point(54, 92)
        Me.cmbMedida.Name = "cmbMedida"
        Me.cmbMedida.Size = New System.Drawing.Size(205, 27)
        Me.cmbMedida.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(54, 125)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl1.TabIndex = 22
        Me.LabelControl1.Text = "EQUIVALE:"
        '
        'lbEquivale
        '
        Me.lbEquivale.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEquivale.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbEquivale.Location = New System.Drawing.Point(114, 124)
        Me.lbEquivale.Name = "lbEquivale"
        Me.lbEquivale.Size = New System.Drawing.Size(7, 19)
        Me.lbEquivale.TabIndex = 23
        Me.lbEquivale.Text = "-"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(271, 89)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.txtCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtCantidad.Properties.Appearance.Options.UseForeColor = True
        Me.txtCantidad.Properties.Mask.EditMask = "n2"
        Me.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCantidad.Size = New System.Drawing.Size(127, 30)
        Me.txtCantidad.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(271, 70)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 13)
        Me.LabelControl2.TabIndex = 25
        Me.LabelControl2.Text = "CANTIDAD:"
        '
        'viewInvFisicoConteo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lbEquivale)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmbMedida)
        Me.Controls.Add(Me.lbCodprod)
        Me.Controls.Add(Me.lbDesprod)
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtConteo)
        Me.Name = "viewInvFisicoConteo"
        Me.Size = New System.Drawing.Size(945, 273)
        CType(Me.txtConteo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtConteo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As TextBox
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbDesprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCodprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbMedida As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbEquivale As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
End Class
