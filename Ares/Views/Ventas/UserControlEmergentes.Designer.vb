<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControlEmergentes
    Inherits DevExpress.XtraEditors.XtraUserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbOBS = New System.Windows.Forms.TextBox()
        Me.lbNombreProd = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.lbDesProd = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbTipoEmergente = New System.Windows.Forms.ComboBox()
        Me.lbMedida = New DevExpress.XtraEditors.TextEdit()
        Me.lbTipoEmergente = New System.Windows.Forms.Label()
        CType(Me.lbCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbMedida.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbOBS
        '
        Me.lbOBS.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbOBS.Location = New System.Drawing.Point(192, 103)
        Me.lbOBS.Multiline = True
        Me.lbOBS.Name = "lbOBS"
        Me.lbOBS.Size = New System.Drawing.Size(670, 73)
        Me.lbOBS.TabIndex = 2
        '
        'lbNombreProd
        '
        Me.lbNombreProd.AutoSize = True
        Me.lbNombreProd.Enabled = False
        Me.lbNombreProd.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNombreProd.Location = New System.Drawing.Point(31, 31)
        Me.lbNombreProd.Name = "lbNombreProd"
        Me.lbNombreProd.Size = New System.Drawing.Size(91, 23)
        Me.lbNombreProd.TabIndex = 0
        Me.lbNombreProd.Text = "Producto:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cantidad:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 23)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Observaciones:"
        '
        'lbCantidad
        '
        Me.lbCantidad.Location = New System.Drawing.Point(192, 67)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.lbCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.lbCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbCantidad.Properties.Appearance.Options.UseBackColor = True
        Me.lbCantidad.Properties.Appearance.Options.UseFont = True
        Me.lbCantidad.Properties.Appearance.Options.UseForeColor = True
        Me.lbCantidad.Properties.Mask.EditMask = "n0"
        Me.lbCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.lbCantidad.Size = New System.Drawing.Size(155, 30)
        Me.lbCantidad.TabIndex = 1
        '
        'lbDesProd
        '
        Me.lbDesProd.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.lbDesProd.Location = New System.Drawing.Point(192, 31)
        Me.lbDesProd.Name = "lbDesProd"
        Me.lbDesProd.Size = New System.Drawing.Size(670, 30)
        Me.lbDesProd.TabIndex = 14
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(879, 129)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(158, 50)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "CANCELAR"
        '
        'btnAceptar
        '
        Me.btnAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnAceptar.Appearance.Options.UseFont = True
        Me.btnAceptar.Appearance.Options.UseForeColor = True
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(879, 67)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(158, 50)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "ACEPTAR"
        '
        'cmbTipoEmergente
        '
        Me.cmbTipoEmergente.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.cmbTipoEmergente.FormattingEnabled = True
        Me.cmbTipoEmergente.Items.AddRange(New Object() {"NO SURTIDO", "EXTRAORDINARIO", "NUEVO", "PEX"})
        Me.cmbTipoEmergente.Location = New System.Drawing.Point(685, 66)
        Me.cmbTipoEmergente.Name = "cmbTipoEmergente"
        Me.cmbTipoEmergente.Size = New System.Drawing.Size(177, 31)
        Me.cmbTipoEmergente.TabIndex = 15
        '
        'lbMedida
        '
        Me.lbMedida.EditValue = "UNIDAD"
        Me.lbMedida.Location = New System.Drawing.Point(353, 67)
        Me.lbMedida.Name = "lbMedida"
        Me.lbMedida.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
        Me.lbMedida.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.lbMedida.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbMedida.Properties.Appearance.Options.UseBackColor = True
        Me.lbMedida.Properties.Appearance.Options.UseFont = True
        Me.lbMedida.Properties.Appearance.Options.UseForeColor = True
        Me.lbMedida.Size = New System.Drawing.Size(141, 30)
        Me.lbMedida.TabIndex = 16
        '
        'lbTipoEmergente
        '
        Me.lbTipoEmergente.AutoSize = True
        Me.lbTipoEmergente.Enabled = False
        Me.lbTipoEmergente.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipoEmergente.Location = New System.Drawing.Point(528, 70)
        Me.lbTipoEmergente.Name = "lbTipoEmergente"
        Me.lbTipoEmergente.Size = New System.Drawing.Size(151, 23)
        Me.lbTipoEmergente.TabIndex = 17
        Me.lbTipoEmergente.Text = "Tipo Emergente:"
        '
        'UserControlEmergentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbTipoEmergente)
        Me.Controls.Add(Me.lbMedida)
        Me.Controls.Add(Me.cmbTipoEmergente)
        Me.Controls.Add(Me.lbDesProd)
        Me.Controls.Add(Me.lbCantidad)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lbNombreProd)
        Me.Controls.Add(Me.lbOBS)
        Me.Name = "UserControlEmergentes"
        Me.Size = New System.Drawing.Size(1138, 203)
        CType(Me.lbCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbMedida.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbOBS As TextBox
    Friend WithEvents lbNombreProd As Label
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lbCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbDesProd As TextBox
    Friend WithEvents cmbTipoEmergente As ComboBox
    Friend WithEvents lbMedida As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbTipoEmergente As Label
End Class
