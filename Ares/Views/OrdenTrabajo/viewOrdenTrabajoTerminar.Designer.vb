<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewOrdenTrabajoTerminar
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
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnGuardarAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDiagnostico = New System.Windows.Forms.TextBox()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSaldo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCorrelativo = New DevExpress.XtraEditors.LabelControl()
        Me.lbCoddoc = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAnticipo = New DevExpress.XtraEditors.TextEdit()
        Me.txtValor = New DevExpress.XtraEditors.TextEdit()
        Me.txtFechaFinalizado = New DevExpress.XtraEditors.DateEdit()
        Me.cmbTecnico = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtSaldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAnticipo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinalizado.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinalizado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.cmbTecnico)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.btnGuardarAceptar)
        Me.GroupControl1.Controls.Add(Me.btnGuardar)
        Me.GroupControl1.Controls.Add(Me.btnCancelar)
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.txtDiagnostico)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.txtSaldo)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.lbCorrelativo)
        Me.GroupControl1.Controls.Add(Me.lbCoddoc)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtAnticipo)
        Me.GroupControl1.Controls.Add(Me.txtValor)
        Me.GroupControl1.Controls.Add(Me.txtFechaFinalizado)
        Me.GroupControl1.Location = New System.Drawing.Point(11, 6)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(685, 352)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Finalización de Orden de Trabajo"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl2.Location = New System.Drawing.Point(418, 119)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl2.TabIndex = 18
        Me.LabelControl2.Text = "Entregado el:"
        '
        'btnGuardarAceptar
        '
        Me.btnGuardarAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardarAceptar.Location = New System.Drawing.Point(177, 367)
        Me.btnGuardarAceptar.Name = "btnGuardarAceptar"
        Me.btnGuardarAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardarAceptar.TabIndex = 16
        Me.btnGuardarAceptar.TabStop = False
        Me.btnGuardarAceptar.Text = "Aceptar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Appearance.BackColor = System.Drawing.Color.White
        Me.btnGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnGuardar.Appearance.Options.UseBackColor = True
        Me.btnGuardar.Appearance.Options.UseFont = True
        Me.btnGuardar.Appearance.Options.UseForeColor = True
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(536, 273)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(135, 60)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "GUARDAR" & Global.Microsoft.VisualBasic.ChrW(13)
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancelar.AppearanceHovered.Options.UseBackColor = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(369, 273)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnCancelar.Size = New System.Drawing.Size(135, 60)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "CANCELAR"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl10.Location = New System.Drawing.Point(16, 115)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl10.TabIndex = 13
        Me.LabelControl10.Text = "Diagnóstico Final:"
        '
        'txtDiagnostico
        '
        Me.txtDiagnostico.Location = New System.Drawing.Point(16, 134)
        Me.txtDiagnostico.MaxLength = 255
        Me.txtDiagnostico.Multiline = True
        Me.txtDiagnostico.Name = "txtDiagnostico"
        Me.txtDiagnostico.Size = New System.Drawing.Size(344, 88)
        Me.txtDiagnostico.TabIndex = 0
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(518, 209)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(12, 18)
        Me.LabelControl9.TabIndex = 11
        Me.LabelControl9.Text = "Q"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(518, 177)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(12, 18)
        Me.LabelControl8.TabIndex = 10
        Me.LabelControl8.Text = "Q"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(518, 146)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(12, 18)
        Me.LabelControl7.TabIndex = 9
        Me.LabelControl7.Text = "Q"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Location = New System.Drawing.Point(418, 213)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl6.TabIndex = 8
        Me.LabelControl6.Text = "Saldo:"
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.EnterMoveNextControl = True
        Me.txtSaldo.Location = New System.Drawing.Point(536, 210)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Properties.Mask.EditMask = "n2"
        Me.txtSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSaldo.Size = New System.Drawing.Size(109, 20)
        Me.txtSaldo.TabIndex = 4
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl5.Location = New System.Drawing.Point(418, 181)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(91, 13)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Anticipo/Abono:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Location = New System.Drawing.Point(418, 149)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Total a Pagar:"
        '
        'lbCorrelativo
        '
        Me.lbCorrelativo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCorrelativo.Location = New System.Drawing.Point(168, 27)
        Me.lbCorrelativo.Name = "lbCorrelativo"
        Me.lbCorrelativo.Size = New System.Drawing.Size(84, 13)
        Me.lbCorrelativo.TabIndex = 4
        Me.lbCorrelativo.Text = "00000000000000"
        '
        'lbCoddoc
        '
        Me.lbCoddoc.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCoddoc.Location = New System.Drawing.Point(90, 27)
        Me.lbCoddoc.Name = "lbCoddoc"
        Me.lbCoddoc.Size = New System.Drawing.Size(36, 13)
        Me.lbCoddoc.TabIndex = 3
        Me.lbCoddoc.Text = "ordtrab"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Location = New System.Drawing.Point(16, 27)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(60, 13)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Orden No. :"
        '
        'txtAnticipo
        '
        Me.txtAnticipo.Enabled = False
        Me.txtAnticipo.EnterMoveNextControl = True
        Me.txtAnticipo.Location = New System.Drawing.Point(536, 178)
        Me.txtAnticipo.Name = "txtAnticipo"
        Me.txtAnticipo.Properties.Mask.EditMask = "n2"
        Me.txtAnticipo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAnticipo.Size = New System.Drawing.Size(109, 20)
        Me.txtAnticipo.TabIndex = 3
        '
        'txtValor
        '
        Me.txtValor.EnterMoveNextControl = True
        Me.txtValor.Location = New System.Drawing.Point(536, 146)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Properties.Mask.EditMask = "n2"
        Me.txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtValor.Size = New System.Drawing.Size(109, 20)
        Me.txtValor.TabIndex = 2
        '
        'txtFechaFinalizado
        '
        Me.txtFechaFinalizado.EditValue = Nothing
        Me.txtFechaFinalizado.Location = New System.Drawing.Point(536, 116)
        Me.txtFechaFinalizado.Name = "txtFechaFinalizado"
        Me.txtFechaFinalizado.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinalizado.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinalizado.Properties.DisplayFormat.FormatString = ""
        Me.txtFechaFinalizado.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFechaFinalizado.Properties.EditFormat.FormatString = ""
        Me.txtFechaFinalizado.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtFechaFinalizado.Properties.Mask.EditMask = ""
        Me.txtFechaFinalizado.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.txtFechaFinalizado.Size = New System.Drawing.Size(109, 20)
        Me.txtFechaFinalizado.TabIndex = 1
        '
        'cmbTecnico
        '
        Me.cmbTecnico.FormattingEnabled = True
        Me.cmbTecnico.Location = New System.Drawing.Point(16, 81)
        Me.cmbTecnico.Name = "cmbTecnico"
        Me.cmbTecnico.Size = New System.Drawing.Size(344, 21)
        Me.cmbTecnico.TabIndex = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Location = New System.Drawing.Point(16, 62)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(147, 13)
        Me.LabelControl3.TabIndex = 20
        Me.LabelControl3.Text = "Realizado por (mecánico):"
        '
        'viewOrdenTrabajoTerminar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewOrdenTrabajoTerminar"
        Me.Size = New System.Drawing.Size(712, 361)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtSaldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAnticipo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinalizado.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinalizado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDiagnostico As TextBox
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSaldo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCorrelativo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCoddoc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAnticipo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtValor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardarAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaFinalizado As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTecnico As ComboBox
End Class
