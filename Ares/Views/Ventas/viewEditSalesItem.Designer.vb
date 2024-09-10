<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewEditSalesItem
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
        Me.NavFrameEdit = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.NP_Editar = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.btnEditTrueSave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnRealAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.lbUCDesProducto = New DevExpress.XtraEditors.LabelControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtUCCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.txtUCTotal = New System.Windows.Forms.TextBox()
        Me.lbCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.txtUCPrecio = New System.Windows.Forms.TextBox()
        Me.LbPrecioUnitarioCantidad = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdUCAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbUCMedida = New System.Windows.Forms.ComboBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.NP_Eliminar = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.btnDelCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnDelAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEditar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.NavFrameEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavFrameEdit.SuspendLayout()
        Me.NP_Editar.SuspendLayout()
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NP_Eliminar.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NavFrameEdit
        '
        Me.NavFrameEdit.Controls.Add(Me.NP_Editar)
        Me.NavFrameEdit.Controls.Add(Me.NP_Eliminar)
        Me.NavFrameEdit.Location = New System.Drawing.Point(174, 23)
        Me.NavFrameEdit.Name = "NavFrameEdit"
        Me.NavFrameEdit.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NP_Editar, Me.NP_Eliminar})
        Me.NavFrameEdit.SelectedPage = Me.NP_Editar
        Me.NavFrameEdit.Size = New System.Drawing.Size(855, 256)
        Me.NavFrameEdit.TabIndex = 0
        Me.NavFrameEdit.Text = "NavigationFrame1"
        Me.NavFrameEdit.TransitionAnimationProperties.FrameCount = 500
        Me.NavFrameEdit.TransitionAnimationProperties.FrameInterval = 5000
        '
        'NP_Editar
        '
        Me.NP_Editar.Caption = "NP_Editar"
        Me.NP_Editar.Controls.Add(Me.btnEditTrueSave)
        Me.NP_Editar.Controls.Add(Me.btnRealAceptar)
        Me.NP_Editar.Controls.Add(Me.lbUCDesProducto)
        Me.NP_Editar.Controls.Add(Me.btnCancelar)
        Me.NP_Editar.Controls.Add(Me.txtUCCantidad)
        Me.NP_Editar.Controls.Add(Me.txtUCTotal)
        Me.NP_Editar.Controls.Add(Me.lbCantidad)
        Me.NP_Editar.Controls.Add(Me.txtUCPrecio)
        Me.NP_Editar.Controls.Add(Me.LbPrecioUnitarioCantidad)
        Me.NP_Editar.Controls.Add(Me.LabelControl8)
        Me.NP_Editar.Controls.Add(Me.cmdUCAceptar)
        Me.NP_Editar.Controls.Add(Me.cmbUCMedida)
        Me.NP_Editar.Controls.Add(Me.LabelControl4)
        Me.NP_Editar.Controls.Add(Me.LabelControl7)
        Me.NP_Editar.Controls.Add(Me.LabelControl3)
        Me.NP_Editar.Name = "NP_Editar"
        Me.NP_Editar.Size = New System.Drawing.Size(855, 256)
        '
        'btnEditTrueSave
        '
        Me.btnEditTrueSave.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditTrueSave.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnEditTrueSave.Appearance.Options.UseFont = True
        Me.btnEditTrueSave.Appearance.Options.UseForeColor = True
        Me.btnEditTrueSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEditTrueSave.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnEditTrueSave.Location = New System.Drawing.Point(526, 276)
        Me.btnEditTrueSave.Name = "btnEditTrueSave"
        Me.btnEditTrueSave.Size = New System.Drawing.Size(150, 58)
        Me.btnEditTrueSave.TabIndex = 45
        Me.btnEditTrueSave.Text = "ACEPTAR"
        '
        'btnRealAceptar
        '
        Me.btnRealAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRealAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnRealAceptar.Appearance.Options.UseFont = True
        Me.btnRealAceptar.Appearance.Options.UseForeColor = True
        Me.btnRealAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnRealAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnRealAceptar.Location = New System.Drawing.Point(909, 383)
        Me.btnRealAceptar.Name = "btnRealAceptar"
        Me.btnRealAceptar.Size = New System.Drawing.Size(125, 58)
        Me.btnRealAceptar.TabIndex = 44
        Me.btnRealAceptar.TabStop = False
        Me.btnRealAceptar.Text = "ACEPTAR"
        '
        'lbUCDesProducto
        '
        Me.lbUCDesProducto.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUCDesProducto.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbUCDesProducto.Location = New System.Drawing.Point(45, 23)
        Me.lbUCDesProducto.Name = "lbUCDesProducto"
        Me.lbUCDesProducto.Size = New System.Drawing.Size(255, 29)
        Me.lbUCDesProducto.TabIndex = 42
        Me.lbUCDesProducto.Text = "Descripcion Producto"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(511, 187)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 58)
        Me.btnCancelar.TabIndex = 43
        Me.btnCancelar.Text = "CANCELAR"
        '
        'txtUCCantidad
        '
        Me.txtUCCantidad.Location = New System.Drawing.Point(162, 128)
        Me.txtUCCantidad.Name = "txtUCCantidad"
        Me.txtUCCantidad.Properties.Appearance.BackColor = System.Drawing.Color.OldLace
        Me.txtUCCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCCantidad.Properties.Appearance.ForeColor = System.Drawing.Color.DarkOrange
        Me.txtUCCantidad.Properties.Appearance.Options.UseBackColor = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtUCCantidad.Properties.Appearance.Options.UseForeColor = True
        Me.txtUCCantidad.Properties.Mask.BeepOnError = True
        Me.txtUCCantidad.Properties.Mask.EditMask = "n2"
        Me.txtUCCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtUCCantidad.Size = New System.Drawing.Size(128, 36)
        Me.txtUCCantidad.TabIndex = 28
        '
        'txtUCTotal
        '
        Me.txtUCTotal.BackColor = System.Drawing.Color.White
        Me.txtUCTotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUCTotal.Enabled = False
        Me.txtUCTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCTotal.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtUCTotal.Location = New System.Drawing.Point(700, 138)
        Me.txtUCTotal.Name = "txtUCTotal"
        Me.txtUCTotal.Size = New System.Drawing.Size(120, 28)
        Me.txtUCTotal.TabIndex = 31
        '
        'lbCantidad
        '
        Me.lbCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCantidad.Location = New System.Drawing.Point(46, 134)
        Me.lbCantidad.Name = "lbCantidad"
        Me.lbCantidad.Size = New System.Drawing.Size(79, 19)
        Me.lbCantidad.TabIndex = 36
        Me.lbCantidad.Text = "Cantidad:"
        '
        'txtUCPrecio
        '
        Me.txtUCPrecio.BackColor = System.Drawing.Color.OldLace
        Me.txtUCPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUCPrecio.Enabled = False
        Me.txtUCPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUCPrecio.ForeColor = System.Drawing.Color.OrangeRed
        Me.txtUCPrecio.Location = New System.Drawing.Point(700, 88)
        Me.txtUCPrecio.Name = "txtUCPrecio"
        Me.txtUCPrecio.Size = New System.Drawing.Size(120, 28)
        Me.txtUCPrecio.TabIndex = 30
        '
        'LbPrecioUnitarioCantidad
        '
        Me.LbPrecioUnitarioCantidad.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPrecioUnitarioCantidad.Location = New System.Drawing.Point(511, 90)
        Me.LbPrecioUnitarioCantidad.Name = "LbPrecioUnitarioCantidad"
        Me.LbPrecioUnitarioCantidad.Size = New System.Drawing.Size(128, 19)
        Me.LbPrecioUnitarioCantidad.TabIndex = 39
        Me.LbPrecioUnitarioCantidad.Text = "Precio Unitario:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl8.Location = New System.Drawing.Point(669, 137)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl8.TabIndex = 33
        Me.LabelControl8.Text = "Q"
        '
        'cmdUCAceptar
        '
        Me.cmdUCAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUCAceptar.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.cmdUCAceptar.Appearance.Options.UseFont = True
        Me.cmdUCAceptar.Appearance.Options.UseForeColor = True
        Me.cmdUCAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.cmdUCAceptar.Location = New System.Drawing.Point(700, 187)
        Me.cmdUCAceptar.Name = "cmdUCAceptar"
        Me.cmdUCAceptar.Size = New System.Drawing.Size(150, 58)
        Me.cmdUCAceptar.TabIndex = 32
        Me.cmdUCAceptar.Text = "ACEPTAR"
        '
        'cmbUCMedida
        '
        Me.cmbUCMedida.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbUCMedida.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUCMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUCMedida.FormattingEnabled = True
        Me.cmbUCMedida.Location = New System.Drawing.Point(162, 81)
        Me.cmbUCMedida.Name = "cmbUCMedida"
        Me.cmbUCMedida.Size = New System.Drawing.Size(319, 33)
        Me.cmbUCMedida.TabIndex = 27
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(511, 141)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(75, 19)
        Me.LabelControl4.TabIndex = 41
        Me.LabelControl4.Text = "Subtotal:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.LabelControl7.Location = New System.Drawing.Point(669, 86)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(18, 29)
        Me.LabelControl7.TabIndex = 40
        Me.LabelControl7.Text = "Q"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(46, 86)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(65, 19)
        Me.LabelControl3.TabIndex = 37
        Me.LabelControl3.Text = "Medida:"
        '
        'NP_Eliminar
        '
        Me.NP_Eliminar.Caption = "NP_Eliminar"
        Me.NP_Eliminar.Controls.Add(Me.btnDelCancelar)
        Me.NP_Eliminar.Controls.Add(Me.btnDelAceptar)
        Me.NP_Eliminar.Controls.Add(Me.LabelControl2)
        Me.NP_Eliminar.Name = "NP_Eliminar"
        Me.NP_Eliminar.Size = New System.Drawing.Size(855, 256)
        '
        'btnDelCancelar
        '
        Me.btnDelCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDelCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnDelCancelar.Location = New System.Drawing.Point(250, 105)
        Me.btnDelCancelar.Name = "btnDelCancelar"
        Me.btnDelCancelar.Size = New System.Drawing.Size(182, 77)
        Me.btnDelCancelar.TabIndex = 3
        Me.btnDelCancelar.Text = "CANCELAR"
        '
        'btnDelAceptar
        '
        Me.btnDelAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDelAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnDelAceptar.Location = New System.Drawing.Point(479, 105)
        Me.btnDelAceptar.Name = "btnDelAceptar"
        Me.btnDelAceptar.Size = New System.Drawing.Size(182, 77)
        Me.btnDelAceptar.TabIndex = 2
        Me.btnDelAceptar.Text = "SI, ELIMÍNALO"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl2.Location = New System.Drawing.Point(220, 40)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(457, 25)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "¿Está seguro que desea Eliminar este Item?"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnEliminar)
        Me.GroupControl1.Controls.Add(Me.btnEditar)
        Me.GroupControl1.Controls.Add(Me.NavFrameEdit)
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1035, 282)
        Me.GroupControl1.TabIndex = 1
        '
        'btnEliminar
        '
        Me.btnEliminar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEliminar.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminar.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnEliminar.Appearance.Options.UseBackColor = True
        Me.btnEliminar.Appearance.Options.UseBorderColor = True
        Me.btnEliminar.Appearance.Options.UseFont = True
        Me.btnEliminar.Appearance.Options.UseForeColor = True
        Me.btnEliminar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminar.Image = Global.Ares.My.Resources.Resources.btWarning
        Me.btnEliminar.Location = New System.Drawing.Point(5, 110)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(162, 77)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Quitar Item"
        '
        'btnEditar
        '
        Me.btnEditar.Appearance.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnEditar.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnEditar.Appearance.Options.UseBackColor = True
        Me.btnEditar.Appearance.Options.UseFont = True
        Me.btnEditar.Appearance.Options.UseForeColor = True
        Me.btnEditar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEditar.Image = Global.Ares.My.Resources.Resources.btNuevo
        Me.btnEditar.Location = New System.Drawing.Point(5, 23)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(162, 77)
        Me.btnEditar.TabIndex = 1
        Me.btnEditar.Text = "Editar"
        '
        'viewEditSalesItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewEditSalesItem"
        Me.Size = New System.Drawing.Size(1035, 286)
        CType(Me.NavFrameEdit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavFrameEdit.ResumeLayout(False)
        Me.NP_Editar.ResumeLayout(False)
        Me.NP_Editar.PerformLayout()
        CType(Me.txtUCCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NP_Eliminar.ResumeLayout(False)
        Me.NP_Eliminar.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NavFrameEdit As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents NP_Editar As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NP_Eliminar As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnEditar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDelAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRealAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbUCDesProducto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtUCCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUCTotal As TextBox
    Friend WithEvents lbCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtUCPrecio As TextBox
    Friend WithEvents LbPrecioUnitarioCantidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdUCAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbUCMedida As ComboBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnEditTrueSave As DevExpress.XtraEditors.SimpleButton
End Class
