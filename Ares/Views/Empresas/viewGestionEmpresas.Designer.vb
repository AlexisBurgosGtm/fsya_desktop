<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewGestionEmpresas
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
        Me.GroupControl7 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObjetivoVentas = New DevExpress.XtraEditors.TextEdit()
        Me.cmbEmpresaTipoPrecio = New System.Windows.Forms.ComboBox()
        Me.cmdEmpresasCancelarEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbEmpresasTipo = New System.Windows.Forms.ComboBox()
        Me.LabelControl142 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl143 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmpresasTelefonos = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl144 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmpresasDireccion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl145 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmpresasRazon = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl146 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmpresasNombre = New DevExpress.XtraEditors.TextEdit()
        Me.cmdEmpresasGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl147 = New DevExpress.XtraEditors.LabelControl()
        Me.txtEmpresasNit = New DevExpress.XtraEditors.TextEdit()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl7.SuspendLayout()
        CType(Me.txtObjetivoVentas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpresasTelefonos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpresasDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpresasRazon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpresasNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmpresasNit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl7
        '
        Me.GroupControl7.Controls.Add(Me.LabelControl2)
        Me.GroupControl7.Controls.Add(Me.LabelControl1)
        Me.GroupControl7.Controls.Add(Me.txtObjetivoVentas)
        Me.GroupControl7.Controls.Add(Me.cmbEmpresaTipoPrecio)
        Me.GroupControl7.Controls.Add(Me.cmdEmpresasCancelarEdit)
        Me.GroupControl7.Controls.Add(Me.LabelControl17)
        Me.GroupControl7.Controls.Add(Me.cmbEmpresasTipo)
        Me.GroupControl7.Controls.Add(Me.LabelControl142)
        Me.GroupControl7.Controls.Add(Me.LabelControl143)
        Me.GroupControl7.Controls.Add(Me.txtEmpresasTelefonos)
        Me.GroupControl7.Controls.Add(Me.LabelControl144)
        Me.GroupControl7.Controls.Add(Me.txtEmpresasDireccion)
        Me.GroupControl7.Controls.Add(Me.LabelControl145)
        Me.GroupControl7.Controls.Add(Me.txtEmpresasRazon)
        Me.GroupControl7.Controls.Add(Me.LabelControl146)
        Me.GroupControl7.Controls.Add(Me.txtEmpresasNombre)
        Me.GroupControl7.Controls.Add(Me.cmdEmpresasGuardar)
        Me.GroupControl7.Controls.Add(Me.LabelControl147)
        Me.GroupControl7.Controls.Add(Me.txtEmpresasNit)
        Me.GroupControl7.Controls.Add(Me.btnAceptarTrue)
        Me.GroupControl7.Location = New System.Drawing.Point(14, 9)
        Me.GroupControl7.Name = "GroupControl7"
        Me.GroupControl7.Size = New System.Drawing.Size(737, 491)
        Me.GroupControl7.TabIndex = 144
        Me.GroupControl7.Text = "Nueva Empresa"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(355, 251)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl2.TabIndex = 693
        Me.LabelControl2.Text = "Q"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(374, 230)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(95, 16)
        Me.LabelControl1.TabIndex = 691
        Me.LabelControl1.Text = "Objetivo Ventas:"
        '
        'txtObjetivoVentas
        '
        Me.txtObjetivoVentas.Location = New System.Drawing.Point(374, 252)
        Me.txtObjetivoVentas.Name = "txtObjetivoVentas"
        Me.txtObjetivoVentas.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObjetivoVentas.Properties.Appearance.Options.UseFont = True
        Me.txtObjetivoVentas.Properties.Mask.EditMask = "n2"
        Me.txtObjetivoVentas.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtObjetivoVentas.Size = New System.Drawing.Size(168, 32)
        Me.txtObjetivoVentas.TabIndex = 692
        '
        'cmbEmpresaTipoPrecio
        '
        Me.cmbEmpresaTipoPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresaTipoPrecio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpresaTipoPrecio.FormattingEnabled = True
        Me.cmbEmpresaTipoPrecio.Location = New System.Drawing.Point(17, 329)
        Me.cmbEmpresaTipoPrecio.Name = "cmbEmpresaTipoPrecio"
        Me.cmbEmpresaTipoPrecio.Size = New System.Drawing.Size(247, 27)
        Me.cmbEmpresaTipoPrecio.TabIndex = 690
        '
        'cmdEmpresasCancelarEdit
        '
        Me.cmdEmpresasCancelarEdit.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdEmpresasCancelarEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEmpresasCancelarEdit.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdEmpresasCancelarEdit.Appearance.Options.UseBackColor = True
        Me.cmdEmpresasCancelarEdit.Appearance.Options.UseFont = True
        Me.cmdEmpresasCancelarEdit.Appearance.Options.UseForeColor = True
        Me.cmdEmpresasCancelarEdit.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdEmpresasCancelarEdit.AppearanceHovered.Options.UseBackColor = True
        Me.cmdEmpresasCancelarEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdEmpresasCancelarEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdEmpresasCancelarEdit.Image = Global.Ares.My.Resources.Resources.bt20
        Me.cmdEmpresasCancelarEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdEmpresasCancelarEdit.Location = New System.Drawing.Point(356, 399)
        Me.cmdEmpresasCancelarEdit.Name = "cmdEmpresasCancelarEdit"
        Me.cmdEmpresasCancelarEdit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdEmpresasCancelarEdit.Size = New System.Drawing.Size(139, 56)
        Me.cmdEmpresasCancelarEdit.TabIndex = 689
        Me.cmdEmpresasCancelarEdit.Text = "CANCELAR"
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl17.Location = New System.Drawing.Point(17, 231)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(30, 16)
        Me.LabelControl17.TabIndex = 688
        Me.LabelControl17.Text = "Tipo:"
        '
        'cmbEmpresasTipo
        '
        Me.cmbEmpresasTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresasTipo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpresasTipo.FormattingEnabled = True
        Me.cmbEmpresasTipo.Items.AddRange(New Object() {"CENTRAL", "SUCURSAL"})
        Me.cmbEmpresasTipo.Location = New System.Drawing.Point(17, 251)
        Me.cmbEmpresasTipo.Name = "cmbEmpresasTipo"
        Me.cmbEmpresasTipo.Size = New System.Drawing.Size(247, 27)
        Me.cmbEmpresasTipo.TabIndex = 687
        '
        'LabelControl142
        '
        Me.LabelControl142.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl142.Location = New System.Drawing.Point(17, 307)
        Me.LabelControl142.Name = "LabelControl142"
        Me.LabelControl142.Size = New System.Drawing.Size(118, 16)
        Me.LabelControl142.TabIndex = 113
        Me.LabelControl142.Text = "Catálogo de Precios:"
        '
        'LabelControl143
        '
        Me.LabelControl143.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl143.Location = New System.Drawing.Point(374, 160)
        Me.LabelControl143.Name = "LabelControl143"
        Me.LabelControl143.Size = New System.Drawing.Size(61, 16)
        Me.LabelControl143.TabIndex = 111
        Me.LabelControl143.Text = "Teléfonos:"
        '
        'txtEmpresasTelefonos
        '
        Me.txtEmpresasTelefonos.Location = New System.Drawing.Point(374, 182)
        Me.txtEmpresasTelefonos.Name = "txtEmpresasTelefonos"
        Me.txtEmpresasTelefonos.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresasTelefonos.Properties.Appearance.Options.UseFont = True
        Me.txtEmpresasTelefonos.Size = New System.Drawing.Size(168, 26)
        Me.txtEmpresasTelefonos.TabIndex = 684
        '
        'LabelControl144
        '
        Me.LabelControl144.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl144.Location = New System.Drawing.Point(17, 161)
        Me.LabelControl144.Name = "LabelControl144"
        Me.LabelControl144.Size = New System.Drawing.Size(93, 16)
        Me.LabelControl144.TabIndex = 109
        Me.LabelControl144.Text = "Dirección Fiscal:"
        '
        'txtEmpresasDireccion
        '
        Me.txtEmpresasDireccion.Location = New System.Drawing.Point(17, 182)
        Me.txtEmpresasDireccion.Name = "txtEmpresasDireccion"
        Me.txtEmpresasDireccion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresasDireccion.Properties.Appearance.Options.UseFont = True
        Me.txtEmpresasDireccion.Size = New System.Drawing.Size(329, 26)
        Me.txtEmpresasDireccion.TabIndex = 683
        '
        'LabelControl145
        '
        Me.LabelControl145.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl145.Location = New System.Drawing.Point(380, 95)
        Me.LabelControl145.Name = "LabelControl145"
        Me.LabelControl145.Size = New System.Drawing.Size(78, 16)
        Me.LabelControl145.TabIndex = 107
        Me.LabelControl145.Text = "Razón Social:"
        '
        'txtEmpresasRazon
        '
        Me.txtEmpresasRazon.Location = New System.Drawing.Point(380, 117)
        Me.txtEmpresasRazon.Name = "txtEmpresasRazon"
        Me.txtEmpresasRazon.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresasRazon.Properties.Appearance.Options.UseFont = True
        Me.txtEmpresasRazon.Size = New System.Drawing.Size(331, 26)
        Me.txtEmpresasRazon.TabIndex = 682
        '
        'LabelControl146
        '
        Me.LabelControl146.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl146.Location = New System.Drawing.Point(17, 95)
        Me.LabelControl146.Name = "LabelControl146"
        Me.LabelControl146.Size = New System.Drawing.Size(55, 16)
        Me.LabelControl146.TabIndex = 105
        Me.LabelControl146.Text = "Empresa:"
        '
        'txtEmpresasNombre
        '
        Me.txtEmpresasNombre.Location = New System.Drawing.Point(17, 117)
        Me.txtEmpresasNombre.Name = "txtEmpresasNombre"
        Me.txtEmpresasNombre.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresasNombre.Properties.Appearance.Options.UseFont = True
        Me.txtEmpresasNombre.Size = New System.Drawing.Size(329, 26)
        Me.txtEmpresasNombre.TabIndex = 681
        '
        'cmdEmpresasGuardar
        '
        Me.cmdEmpresasGuardar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdEmpresasGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEmpresasGuardar.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdEmpresasGuardar.Appearance.Options.UseBackColor = True
        Me.cmdEmpresasGuardar.Appearance.Options.UseFont = True
        Me.cmdEmpresasGuardar.Appearance.Options.UseForeColor = True
        Me.cmdEmpresasGuardar.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdEmpresasGuardar.AppearanceHovered.Options.UseBackColor = True
        Me.cmdEmpresasGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdEmpresasGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.cmdEmpresasGuardar.Location = New System.Drawing.Point(540, 396)
        Me.cmdEmpresasGuardar.Name = "cmdEmpresasGuardar"
        Me.cmdEmpresasGuardar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdEmpresasGuardar.Size = New System.Drawing.Size(139, 62)
        Me.cmdEmpresasGuardar.TabIndex = 686
        Me.cmdEmpresasGuardar.Text = "GUARDAR"
        '
        'LabelControl147
        '
        Me.LabelControl147.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl147.Location = New System.Drawing.Point(17, 56)
        Me.LabelControl147.Name = "LabelControl147"
        Me.LabelControl147.Size = New System.Drawing.Size(78, 16)
        Me.LabelControl147.TabIndex = 1
        Me.LabelControl147.Text = "Código Onne:"
        '
        'txtEmpresasNit
        '
        Me.txtEmpresasNit.Location = New System.Drawing.Point(101, 53)
        Me.txtEmpresasNit.Name = "txtEmpresasNit"
        Me.txtEmpresasNit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresasNit.Properties.Appearance.Options.UseFont = True
        Me.txtEmpresasNit.Size = New System.Drawing.Size(233, 26)
        Me.txtEmpresasNit.TabIndex = 680
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(737, 146)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 145
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "Aceptar"
        '
        'viewGestionEmpresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl7)
        Me.Name = "viewGestionEmpresas"
        Me.Size = New System.Drawing.Size(766, 509)
        CType(Me.GroupControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl7.ResumeLayout(False)
        Me.GroupControl7.PerformLayout()
        CType(Me.txtObjetivoVentas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpresasTelefonos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpresasDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpresasRazon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpresasNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmpresasNit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl7 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdEmpresasCancelarEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbEmpresasTipo As ComboBox
    Friend WithEvents LabelControl142 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl143 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmpresasTelefonos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl144 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmpresasDireccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl145 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmpresasRazon As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl146 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmpresasNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdEmpresasGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl147 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtEmpresasNit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbEmpresaTipoPrecio As ComboBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObjetivoVentas As DevExpress.XtraEditors.TextEdit
End Class
