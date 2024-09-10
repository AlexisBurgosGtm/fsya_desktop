<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewDocumentosEditCaja
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
        Me.cmbCajas = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCambiar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'cmbCajas
        '
        Me.cmbCajas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCajas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCajas.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Location = New System.Drawing.Point(62, 60)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(352, 31)
        Me.cmbCajas.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(62, 31)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(282, 23)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "CAMBIAR CAJA DEL DOCUMENTO"
        '
        'btnCambiar
        '
        Me.btnCambiar.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiar.Appearance.Options.UseFont = True
        Me.btnCambiar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnCambiar.Location = New System.Drawing.Point(260, 140)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(154, 59)
        Me.btnCambiar.TabIndex = 2
        Me.btnCambiar.Text = "CAMBIAR"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(62, 140)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(154, 59)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "CANCELAR"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(305, 260)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 4
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "aceptar"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton1.Image = Global.Ares.My.Resources.Resources.btExito
        Me.SimpleButton1.Location = New System.Drawing.Point(260, 140)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(154, 59)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "CAMBIAR"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseForeColor = True
        Me.SimpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton2.Location = New System.Drawing.Point(62, 140)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(154, 59)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "CANCELAR"
        '
        'viewDocumentosEditCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCambiar)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmbCajas)
        Me.Name = "viewDocumentosEditCaja"
        Me.Size = New System.Drawing.Size(477, 229)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbCajas As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCambiar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
