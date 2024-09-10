<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewParamMesAnio
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
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.btnAceptar)
        Me.GroupControl1.Controls.Add(Me.cmbAnio)
        Me.GroupControl1.Controls.Add(Me.cmbMes)
        Me.GroupControl1.Location = New System.Drawing.Point(18, 3)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(496, 219)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Seleccione Mes y Año para Generar los Datos"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton2.Location = New System.Drawing.Point(100, 142)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(137, 51)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "CANCELAR"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(287, 142)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(137, 51)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "ACEPTAR"
        '
        'cmbAnio
        '
        Me.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Location = New System.Drawing.Point(292, 66)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(121, 27)
        Me.cmbAnio.TabIndex = 1
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(86, 66)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(187, 27)
        Me.cmbMes.TabIndex = 0
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(494, 231)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 1
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "SimpleButton3"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(86, 47)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Mes:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(292, 47)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Año:"
        '
        'viewParamMesAnio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewParamMesAnio"
        Me.Size = New System.Drawing.Size(538, 225)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbAnio As ComboBox
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
