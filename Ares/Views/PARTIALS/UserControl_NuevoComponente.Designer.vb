<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_NuevoComponente
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtComponentesComponente = New System.Windows.Forms.TextBox()
        Me.txtComponentesUso = New System.Windows.Forms.TextBox()
        Me.cmdComponentesGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'txtComponentesComponente
        '
        Me.txtComponentesComponente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComponentesComponente.Location = New System.Drawing.Point(14, 46)
        Me.txtComponentesComponente.Name = "txtComponentesComponente"
        Me.txtComponentesComponente.Size = New System.Drawing.Size(446, 31)
        Me.txtComponentesComponente.TabIndex = 0
        '
        'txtComponentesUso
        '
        Me.txtComponentesUso.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComponentesUso.Location = New System.Drawing.Point(14, 119)
        Me.txtComponentesUso.Name = "txtComponentesUso"
        Me.txtComponentesUso.Size = New System.Drawing.Size(589, 31)
        Me.txtComponentesUso.TabIndex = 1
        '
        'cmdComponentesGuardar
        '
        Me.cmdComponentesGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdComponentesGuardar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdComponentesGuardar.Appearance.Options.UseFont = True
        Me.cmdComponentesGuardar.Appearance.Options.UseForeColor = True
        Me.cmdComponentesGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.cmdComponentesGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdComponentesGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.cmdComponentesGuardar.Location = New System.Drawing.Point(454, 182)
        Me.cmdComponentesGuardar.Name = "cmdComponentesGuardar"
        Me.cmdComponentesGuardar.Size = New System.Drawing.Size(136, 61)
        Me.cmdComponentesGuardar.TabIndex = 2
        Me.cmdComponentesGuardar.Text = "Guardar"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(14, 15)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(113, 23)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Componente:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(14, 88)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(37, 23)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Uso:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(253, 182)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(136, 61)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        '
        'UserControl_NuevoComponente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmdComponentesGuardar)
        Me.Controls.Add(Me.txtComponentesUso)
        Me.Controls.Add(Me.txtComponentesComponente)
        Me.Name = "UserControl_NuevoComponente"
        Me.Size = New System.Drawing.Size(622, 268)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtComponentesComponente As TextBox
    Friend WithEvents txtComponentesUso As TextBox
    Friend WithEvents cmdComponentesGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
End Class
