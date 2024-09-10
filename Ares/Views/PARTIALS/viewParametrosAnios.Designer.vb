<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewParametrosAnios
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
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbAnioInicial = New System.Windows.Forms.ComboBox()
        Me.cmbAnioFinal = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(57, 36)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(239, 19)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Seleccione un rango de Años:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(57, 78)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Del:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(185, 78)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(12, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "al:"
        '
        'cmbAnioInicial
        '
        Me.cmbAnioInicial.FormattingEnabled = True
        Me.cmbAnioInicial.Items.AddRange(New Object() {"2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbAnioInicial.Location = New System.Drawing.Point(82, 78)
        Me.cmbAnioInicial.Name = "cmbAnioInicial"
        Me.cmbAnioInicial.Size = New System.Drawing.Size(68, 21)
        Me.cmbAnioInicial.TabIndex = 3
        '
        'cmbAnioFinal
        '
        Me.cmbAnioFinal.FormattingEnabled = True
        Me.cmbAnioFinal.Items.AddRange(New Object() {"2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbAnioFinal.Location = New System.Drawing.Point(203, 78)
        Me.cmbAnioFinal.Name = "cmbAnioFinal"
        Me.cmbAnioFinal.Size = New System.Drawing.Size(68, 21)
        Me.cmbAnioFinal.TabIndex = 4
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(179, 147)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(140, 50)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        '
        'viewParametrosAnios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cmbAnioFinal)
        Me.Controls.Add(Me.cmbAnioInicial)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewParametrosAnios"
        Me.Size = New System.Drawing.Size(350, 216)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbAnioInicial As ComboBox
    Friend WithEvents cmbAnioFinal As ComboBox
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
End Class
