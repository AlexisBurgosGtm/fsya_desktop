<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCEnviarCotizacion
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
        Me.txtMail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdEnviar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdCancelar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtMail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMail
        '
        Me.txtMail.EnterMoveNextControl = True
        Me.txtMail.Location = New System.Drawing.Point(192, 51)
        Me.txtMail.Name = "txtMail"
        Me.txtMail.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMail.Properties.Appearance.Options.UseFont = True
        Me.txtMail.Size = New System.Drawing.Size(414, 32)
        Me.txtMail.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(30, 54)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(142, 25)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "E-mail Destino:"
        '
        'cmdEnviar
        '
        Me.cmdEnviar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdEnviar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdEnviar.Appearance.Options.UseBackColor = True
        Me.cmdEnviar.Appearance.Options.UseForeColor = True
        Me.cmdEnviar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdEnviar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdEnviar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.cmdEnviar.Location = New System.Drawing.Point(456, 128)
        Me.cmdEnviar.Name = "cmdEnviar"
        Me.cmdEnviar.Size = New System.Drawing.Size(150, 65)
        Me.cmdEnviar.TabIndex = 2
        Me.cmdEnviar.Text = "Enviar Cotización"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdCancelar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCancelar.Appearance.Options.UseBackColor = True
        Me.cmdCancelar.Appearance.Options.UseForeColor = True
        Me.cmdCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.cmdCancelar.Location = New System.Drawing.Point(233, 128)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(150, 65)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cancelar"
        '
        'UCEnviarCotizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdEnviar)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtMail)
        Me.Name = "UCEnviarCotizacion"
        Me.Size = New System.Drawing.Size(679, 237)
        CType(Me.txtMail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtMail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdEnviar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdCancelar As DevExpress.XtraEditors.SimpleButton
End Class
