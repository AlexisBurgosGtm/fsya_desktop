<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewTrasladoBodegas
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
        Me.cmbBodegas = New System.Windows.Forms.ComboBox()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbCoddocDestino = New System.Windows.Forms.ComboBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCorrelativoDestino = New DevExpress.XtraEditors.LabelControl()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(65, 38)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(435, 23)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Empresa hacia donde se realizará el Traslado."
        '
        'cmbBodegas
        '
        Me.cmbBodegas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBodegas.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBodegas.FormattingEnabled = True
        Me.cmbBodegas.Location = New System.Drawing.Point(65, 80)
        Me.cmbBodegas.Name = "cmbBodegas"
        Me.cmbBodegas.Size = New System.Drawing.Size(612, 31)
        Me.cmbBodegas.TabIndex = 1
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(242, 307)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 3
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "Aceptar"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton1.Location = New System.Drawing.Point(336, 221)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(149, 59)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "CANCELAR"
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAceptar.Appearance.Options.UseBackColor = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito1
        Me.btnAceptar.Location = New System.Drawing.Point(528, 221)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(149, 59)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "CONFIRMAR"
        '
        'cmbCoddocDestino
        '
        Me.cmbCoddocDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCoddocDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCoddocDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCoddocDestino.FormattingEnabled = True
        Me.cmbCoddocDestino.Location = New System.Drawing.Point(65, 157)
        Me.cmbCoddocDestino.Name = "cmbCoddocDestino"
        Me.cmbCoddocDestino.Size = New System.Drawing.Size(211, 21)
        Me.cmbCoddocDestino.TabIndex = 4
        Me.cmbCoddocDestino.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(65, 138)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(109, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Documento a Generar:"
        '
        'lbCorrelativoDestino
        '
        Me.lbCorrelativoDestino.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrelativoDestino.Location = New System.Drawing.Point(282, 155)
        Me.lbCorrelativoDestino.Name = "lbCorrelativoDestino"
        Me.lbCorrelativoDestino.Size = New System.Drawing.Size(60, 23)
        Me.lbCorrelativoDestino.TabIndex = 6
        Me.lbCorrelativoDestino.Text = "00000"
        '
        'viewTrasladoBodegas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbCorrelativoDestino)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.cmbCoddocDestino)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.cmbBodegas)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewTrasladoBodegas"
        Me.Size = New System.Drawing.Size(742, 306)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbBodegas As ComboBox
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbCoddocDestino As ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCorrelativoDestino As DevExpress.XtraEditors.LabelControl
End Class
