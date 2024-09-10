<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewOrdenTrabajoEditar
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
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtValor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDetRevision = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(312, 210)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl9.TabIndex = 226
        Me.LabelControl9.Text = "Q"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(200, 210)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(101, 18)
        Me.LabelControl8.TabIndex = 225
        Me.LabelControl8.Text = "Valor Estimado:"
        '
        'txtValor
        '
        Me.txtValor.EnterMoveNextControl = True
        Me.txtValor.Location = New System.Drawing.Point(332, 211)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Properties.Appearance.Options.UseFont = True
        Me.txtValor.Properties.Mask.EditMask = "n2"
        Me.txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtValor.Size = New System.Drawing.Size(131, 24)
        Me.txtValor.TabIndex = 222
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(17, 108)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(173, 18)
        Me.LabelControl7.TabIndex = 224
        Me.LabelControl7.Text = "Observaciones adicionales:"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(17, 132)
        Me.txtObs.MaxLength = 255
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(446, 48)
        Me.txtObs.TabIndex = 221
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(17, 22)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(137, 18)
        Me.LabelControl6.TabIndex = 223
        Me.LabelControl6.Text = "Detalle de la revisión:"
        '
        'txtDetRevision
        '
        Me.txtDetRevision.Location = New System.Drawing.Point(17, 46)
        Me.txtDetRevision.MaxLength = 255
        Me.txtDetRevision.Multiline = True
        Me.txtDetRevision.Name = "txtDetRevision"
        Me.txtDetRevision.Size = New System.Drawing.Size(446, 40)
        Me.txtDetRevision.TabIndex = 220
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
        Me.btnGuardar.Location = New System.Drawing.Point(342, 262)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(135, 60)
        Me.btnGuardar.TabIndex = 227
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
        Me.btnCancelar.Location = New System.Drawing.Point(175, 262)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnCancelar.Size = New System.Drawing.Size(135, 60)
        Me.btnCancelar.TabIndex = 228
        Me.btnCancelar.Text = "CANCELAR"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(58, 391)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 229
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "SimpleButton1"
        '
        'viewOrdenTrabajoEditar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.txtValor)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.txtDetRevision)
        Me.Name = "viewOrdenTrabajoEditar"
        Me.Size = New System.Drawing.Size(515, 339)
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtValor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As TextBox
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDetRevision As TextBox
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
End Class
