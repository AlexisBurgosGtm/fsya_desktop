<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewCajaEfectivo
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
        Me.txtEfectivoInicial = New DevExpress.XtraEditors.TextEdit()
        Me.txtEfectivoLimite = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtEfectivoInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEfectivoLimite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEfectivoInicial
        '
        Me.txtEfectivoInicial.EnterMoveNextControl = True
        Me.txtEfectivoInicial.Location = New System.Drawing.Point(300, 96)
        Me.txtEfectivoInicial.Name = "txtEfectivoInicial"
        Me.txtEfectivoInicial.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivoInicial.Properties.Appearance.Options.UseFont = True
        Me.txtEfectivoInicial.Properties.Mask.EditMask = "n2"
        Me.txtEfectivoInicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtEfectivoInicial.Size = New System.Drawing.Size(168, 30)
        Me.txtEfectivoInicial.TabIndex = 0
        '
        'txtEfectivoLimite
        '
        Me.txtEfectivoLimite.EnterMoveNextControl = True
        Me.txtEfectivoLimite.Location = New System.Drawing.Point(300, 175)
        Me.txtEfectivoLimite.Name = "txtEfectivoLimite"
        Me.txtEfectivoLimite.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEfectivoLimite.Properties.Appearance.Options.UseFont = True
        Me.txtEfectivoLimite.Properties.Mask.EditMask = "n2"
        Me.txtEfectivoLimite.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtEfectivoLimite.Size = New System.Drawing.Size(168, 30)
        Me.txtEfectivoLimite.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(134, 78)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(127, 23)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Efectivo Inicial:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(134, 153)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(147, 23)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Aviso de Efectivo:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(281, 178)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(13, 23)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Q"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(281, 99)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(13, 23)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Q"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(381, 244)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(142, 54)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "CONFIRMAR"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton2.Location = New System.Drawing.Point(165, 244)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(142, 54)
        Me.SimpleButton2.TabIndex = 7
        Me.SimpleButton2.Text = "CANCELAR"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl5.Location = New System.Drawing.Point(199, 18)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(242, 23)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "Datos de la Apertura de Caja"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(448, 351)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 9
        Me.btnAceptarTrue.Text = "aceptar"
        '
        'viewCajaEfectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtEfectivoLimite)
        Me.Controls.Add(Me.txtEfectivoInicial)
        Me.Name = "viewCajaEfectivo"
        Me.Size = New System.Drawing.Size(674, 338)
        CType(Me.txtEfectivoInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEfectivoLimite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtEfectivoInicial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtEfectivoLimite As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
End Class
