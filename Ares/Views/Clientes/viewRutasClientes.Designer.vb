<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewRutasClientes
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewRutasClientes))
        Me.txtCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.lbMantenimientosDescripcion = New DevExpress.XtraEditors.LabelControl()
        Me.lbMantenimientosCodigo = New DevExpress.XtraEditors.LabelControl()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnEliminarRuta = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GridListado = New DevExpress.XtraGrid.GridControl()
        Me.TblRutasClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewListado = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODRUTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESRUTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODEMPLEADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMEMPLEADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FlyoutPanelDatosCliente = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.btnNuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl150 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblRutasClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutPanelDatosCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelDatosCliente.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(81, 41)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Properties.Appearance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Properties.Appearance.Options.UseFont = True
        Me.txtCodigo.Properties.Mask.EditMask = "n0"
        Me.txtCodigo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCodigo.Size = New System.Drawing.Size(102, 26)
        Me.txtCodigo.TabIndex = 2
        '
        'lbMantenimientosDescripcion
        '
        Me.lbMantenimientosDescripcion.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMantenimientosDescripcion.Location = New System.Drawing.Point(18, 90)
        Me.lbMantenimientosDescripcion.Name = "lbMantenimientosDescripcion"
        Me.lbMantenimientosDescripcion.Size = New System.Drawing.Size(79, 16)
        Me.lbMantenimientosDescripcion.TabIndex = 198
        Me.lbMantenimientosDescripcion.Text = "Descripción:"
        '
        'lbMantenimientosCodigo
        '
        Me.lbMantenimientosCodigo.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMantenimientosCodigo.Location = New System.Drawing.Point(18, 44)
        Me.lbMantenimientosCodigo.Name = "lbMantenimientosCodigo"
        Me.lbMantenimientosCodigo.Size = New System.Drawing.Size(48, 16)
        Me.lbMantenimientosCodigo.TabIndex = 197
        Me.lbMantenimientosCodigo.Text = "Código:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(18, 112)
        Me.txtDescripcion.MaxLength = 250
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(283, 84)
        Me.txtDescripcion.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCancelar.AppearanceHovered.Options.UseBackColor = True
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(18, 334)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnCancelar.Size = New System.Drawing.Size(128, 55)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "CANCELAR" & Global.Microsoft.VisualBasic.ChrW(13) & " "
        '
        'btnGuardar
        '
        Me.btnGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Appearance.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.btnGuardar.Appearance.Options.UseFont = True
        Me.btnGuardar.Appearance.Options.UseForeColor = True
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(173, 334)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(128, 55)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "GUARDAR"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(18, 251)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(283, 28)
        Me.cmbVendedor.TabIndex = 4
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(18, 229)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(68, 16)
        Me.LabelControl1.TabIndex = 203
        Me.LabelControl1.Text = "Vendedor:"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnEliminarRuta)
        Me.GroupControl1.Controls.Add(Me.lbMantenimientosCodigo)
        Me.GroupControl1.Controls.Add(Me.btnCancelar)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.btnGuardar)
        Me.GroupControl1.Controls.Add(Me.txtDescripcion)
        Me.GroupControl1.Controls.Add(Me.cmbVendedor)
        Me.GroupControl1.Controls.Add(Me.lbMantenimientosDescripcion)
        Me.GroupControl1.Controls.Add(Me.txtCodigo)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(317, 591)
        Me.GroupControl1.TabIndex = 204
        Me.GroupControl1.Text = "Datos de la Ruta"
        '
        'btnEliminarRuta
        '
        Me.btnEliminarRuta.Appearance.BackColor = System.Drawing.Color.Red
        Me.btnEliminarRuta.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminarRuta.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEliminarRuta.Appearance.Options.UseBackColor = True
        Me.btnEliminarRuta.Appearance.Options.UseFont = True
        Me.btnEliminarRuta.Appearance.Options.UseForeColor = True
        Me.btnEliminarRuta.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.btnEliminarRuta.AppearanceHovered.Options.UseBackColor = True
        Me.btnEliminarRuta.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEliminarRuta.Image = CType(resources.GetObject("btnEliminarRuta.Image"), System.Drawing.Image)
        Me.btnEliminarRuta.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.btnEliminarRuta.Location = New System.Drawing.Point(11, 542)
        Me.btnEliminarRuta.Name = "btnEliminarRuta"
        Me.btnEliminarRuta.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnEliminarRuta.Size = New System.Drawing.Size(296, 42)
        Me.btnEliminarRuta.TabIndex = 204
        Me.btnEliminarRuta.Text = "ELIMINAR RUTA"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GridListado)
        Me.GroupControl2.Location = New System.Drawing.Point(33, 127)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(980, 490)
        Me.GroupControl2.TabIndex = 205
        Me.GroupControl2.Text = "Listado de Rutas"
        '
        'GridListado
        '
        Me.GridListado.DataSource = Me.TblRutasClientesBindingSource
        Me.GridListado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridListado.Location = New System.Drawing.Point(2, 20)
        Me.GridListado.MainView = Me.GridViewListado
        Me.GridListado.Name = "GridListado"
        Me.GridListado.Size = New System.Drawing.Size(976, 468)
        Me.GridListado.TabIndex = 0
        Me.GridListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListado})
        '
        'TblRutasClientesBindingSource
        '
        Me.TblRutasClientesBindingSource.DataMember = "tblRutasClientes"
        Me.TblRutasClientesBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewListado
        '
        Me.GridViewListado.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODRUTA, Me.colDESRUTA, Me.colCODEMPLEADO, Me.colNOMEMPLEADO})
        Me.GridViewListado.GridControl = Me.GridListado
        Me.GridViewListado.Name = "GridViewListado"
        Me.GridViewListado.OptionsBehavior.Editable = False
        '
        'colCODRUTA
        '
        Me.colCODRUTA.FieldName = "CODRUTA"
        Me.colCODRUTA.Name = "colCODRUTA"
        Me.colCODRUTA.Visible = True
        Me.colCODRUTA.VisibleIndex = 0
        Me.colCODRUTA.Width = 78
        '
        'colDESRUTA
        '
        Me.colDESRUTA.Caption = "DESCRIPCION"
        Me.colDESRUTA.FieldName = "DESRUTA"
        Me.colDESRUTA.Name = "colDESRUTA"
        Me.colDESRUTA.Visible = True
        Me.colDESRUTA.VisibleIndex = 1
        Me.colDESRUTA.Width = 591
        '
        'colCODEMPLEADO
        '
        Me.colCODEMPLEADO.FieldName = "CODEMPLEADO"
        Me.colCODEMPLEADO.Name = "colCODEMPLEADO"
        Me.colCODEMPLEADO.Width = 265
        '
        'colNOMEMPLEADO
        '
        Me.colNOMEMPLEADO.Caption = "VENDEDOR"
        Me.colNOMEMPLEADO.FieldName = "NOMEMPLEADO"
        Me.colNOMEMPLEADO.Name = "colNOMEMPLEADO"
        Me.colNOMEMPLEADO.Visible = True
        Me.colNOMEMPLEADO.VisibleIndex = 2
        Me.colNOMEMPLEADO.Width = 289
        '
        'FlyoutPanelDatosCliente
        '
        Me.FlyoutPanelDatosCliente.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelDatosCliente.Location = New System.Drawing.Point(678, 20)
        Me.FlyoutPanelDatosCliente.Name = "FlyoutPanelDatosCliente"
        Me.FlyoutPanelDatosCliente.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutPanelDatosCliente.OptionsBeakPanel.CloseOnOuterClick = False
        Me.FlyoutPanelDatosCliente.OwnerControl = Me
        Me.FlyoutPanelDatosCliente.Size = New System.Drawing.Size(321, 595)
        Me.FlyoutPanelDatosCliente.TabIndex = 206
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.GroupControl1)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelDatosCliente
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(321, 595)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnNuevo.Location = New System.Drawing.Point(877, 50)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(138, 56)
        Me.btnNuevo.TabIndex = 208
        Me.btnNuevo.Text = "Nuevo"
        '
        'LabelControl150
        '
        Me.LabelControl150.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl150.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl150.Location = New System.Drawing.Point(111, 35)
        Me.LabelControl150.Name = "LabelControl150"
        Me.LabelControl150.Size = New System.Drawing.Size(204, 33)
        Me.LabelControl150.TabIndex = 207
        Me.LabelControl150.Text = "Rutas de Clientes"
        '
        'viewRutasClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.FlyoutPanelDatosCliente)
        Me.Controls.Add(Me.LabelControl150)
        Me.Controls.Add(Me.GroupControl2)
        Me.Name = "viewRutasClientes"
        Me.Size = New System.Drawing.Size(1053, 681)
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblRutasClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutPanelDatosCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelDatosCliente.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbMantenimientosDescripcion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbMantenimientosCodigo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbVendedor As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents FlyoutPanelDatosCliente As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents btnNuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl150 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents TblRutasClientesBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents GridViewListado As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODRUTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESRUTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODEMPLEADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMEMPLEADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnEliminarRuta As DevExpress.XtraEditors.SimpleButton
End Class
