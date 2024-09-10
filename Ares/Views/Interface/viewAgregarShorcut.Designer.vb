<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewAgregarShorcut
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
        Me.cmbShorcuts = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'cmbShorcuts
        '
        Me.cmbShorcuts.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShorcuts.FormattingEnabled = True
        Me.cmbShorcuts.Location = New System.Drawing.Point(44, 47)
        Me.cmbShorcuts.Name = "cmbShorcuts"
        Me.cmbShorcuts.Size = New System.Drawing.Size(541, 31)
        Me.cmbShorcuts.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(44, 28)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(107, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Seleccione una Opción"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.SimpleButton1.Image = Global.Ares.My.Resources.Resources.btExito
        Me.SimpleButton1.Location = New System.Drawing.Point(416, 102)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(153, 54)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "Agregar"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton2.Location = New System.Drawing.Point(217, 102)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(153, 54)
        Me.SimpleButton2.TabIndex = 3
        Me.SimpleButton2.Text = "CANCELAR"
        '
        'viewAgregarShorcut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmbShorcuts)
        Me.Name = "viewAgregarShorcut"
        Me.Size = New System.Drawing.Size(616, 183)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbShorcuts As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
