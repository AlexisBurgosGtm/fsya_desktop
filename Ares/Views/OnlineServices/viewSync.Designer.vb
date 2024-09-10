<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewSync
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewSync))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridPedidosPendientes = New DevExpress.XtraGrid.GridControl()
        Me.TblSyncPedidosBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneralBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewSync = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODVEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMVEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALVENTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHAENVIADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESREP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colENTREGADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TblSyncPedidosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblSyncPedidosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.FlyoutPanelOpcionesSync = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.btnSyncDashboard = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCerrarFlyoutSync = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSyncVendedores = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSyncRepartidores = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSyncClientes = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSyncProductos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSyncTodo = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.RadialMenuSync = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.btnRadImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadFacturar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadRepartidor = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadEntregado = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadObs = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadEditarPedido = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.switchEliminaFacturar = New DevExpress.XtraEditors.ToggleSwitch()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnSyncObtenerCenso = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEmbarqueGeneral = New DevExpress.XtraEditors.SimpleButton()
        Me.GridExports = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.switchEntregados = New DevExpress.XtraEditors.ToggleSwitch()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.GridPedidosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblSyncPedidosBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblSyncPedidosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblSyncPedidosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.FlyoutPanelOpcionesSync, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelOpcionesSync.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.RadialMenuSync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.switchEliminaFacturar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GridExports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.switchEntregados.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(76, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(251, 23)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Gestión de Pedidos Online"
        '
        'GridPedidosPendientes
        '
        Me.GridPedidosPendientes.DataSource = Me.TblSyncPedidosBindingSource2
        Me.GridPedidosPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPedidosPendientes.Location = New System.Drawing.Point(2, 20)
        Me.GridPedidosPendientes.MainView = Me.GridViewSync
        Me.GridPedidosPendientes.Name = "GridPedidosPendientes"
        Me.GridPedidosPendientes.Size = New System.Drawing.Size(1076, 513)
        Me.GridPedidosPendientes.TabIndex = 3
        Me.GridPedidosPendientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSync})
        '
        'TblSyncPedidosBindingSource2
        '
        Me.TblSyncPedidosBindingSource2.DataMember = "tblSyncPedidos"
        Me.TblSyncPedidosBindingSource2.DataSource = Me.DSGeneralBindingSource
        '
        'DSGeneralBindingSource
        '
        Me.DSGeneralBindingSource.DataSource = Me.DSGeneral
        Me.DSGeneralBindingSource.Position = 0
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewSync
        '
        Me.GridViewSync.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODDOC, Me.colCORRELATIVO, Me.colCODVEN, Me.colNOMVEN, Me.colTOTALCOSTO, Me.colTOTALVENTA, Me.colFECHAENVIADO, Me.colFECHA, Me.colNOMCLIENTE, Me.colCODCLIENTE, Me.colDESREP, Me.colCODST, Me.colDESST, Me.colENTREGADO, Me.colOBS})
        Me.GridViewSync.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewSync.GridControl = Me.GridPedidosPendientes
        Me.GridViewSync.Name = "GridViewSync"
        Me.GridViewSync.OptionsBehavior.Editable = False
        Me.GridViewSync.OptionsFind.FindNullPrompt = "Escriba para buscar...."
        Me.GridViewSync.OptionsView.ShowAutoFilterRow = True
        Me.GridViewSync.OptionsView.ShowFooter = True
        '
        'colCODDOC
        '
        Me.colCODDOC.Caption = "DOC"
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOTALVENTA", "SUM={0:0.##}")})
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 0
        Me.colCODDOC.Width = 53
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.Caption = "NO."
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        Me.colCORRELATIVO.Width = 71
        '
        'colCODVEN
        '
        Me.colCODVEN.FieldName = "CODVEN"
        Me.colCODVEN.Name = "colCODVEN"
        Me.colCODVEN.Width = 96
        '
        'colNOMVEN
        '
        Me.colNOMVEN.Caption = "VENDEDOR"
        Me.colNOMVEN.FieldName = "NOMVEN"
        Me.colNOMVEN.Name = "colNOMVEN"
        Me.colNOMVEN.Visible = True
        Me.colNOMVEN.VisibleIndex = 3
        Me.colNOMVEN.Width = 114
        '
        'colTOTALCOSTO
        '
        Me.colTOTALCOSTO.FieldName = "TOTALCOSTO"
        Me.colTOTALCOSTO.Name = "colTOTALCOSTO"
        Me.colTOTALCOSTO.Width = 96
        '
        'colTOTALVENTA
        '
        Me.colTOTALVENTA.Caption = "IMPORTE"
        Me.colTOTALVENTA.FieldName = "TOTALVENTA"
        Me.colTOTALVENTA.Name = "colTOTALVENTA"
        Me.colTOTALVENTA.Visible = True
        Me.colTOTALVENTA.VisibleIndex = 5
        Me.colTOTALVENTA.Width = 89
        '
        'colFECHAENVIADO
        '
        Me.colFECHAENVIADO.FieldName = "FECHAENVIADO"
        Me.colFECHAENVIADO.Name = "colFECHAENVIADO"
        Me.colFECHAENVIADO.Width = 96
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 2
        Me.colFECHA.Width = 82
        '
        'colNOMCLIENTE
        '
        Me.colNOMCLIENTE.Caption = "CLIENTE"
        Me.colNOMCLIENTE.FieldName = "NOMCLIENTE"
        Me.colNOMCLIENTE.Name = "colNOMCLIENTE"
        Me.colNOMCLIENTE.Visible = True
        Me.colNOMCLIENTE.VisibleIndex = 4
        Me.colNOMCLIENTE.Width = 184
        '
        'colCODCLIENTE
        '
        Me.colCODCLIENTE.FieldName = "CODCLIENTE"
        Me.colCODCLIENTE.Name = "colCODCLIENTE"
        Me.colCODCLIENTE.Width = 116
        '
        'colDESREP
        '
        Me.colDESREP.Caption = "EMBARQUE /REPARTO"
        Me.colDESREP.FieldName = "DESREP"
        Me.colDESREP.Name = "colDESREP"
        Me.colDESREP.Visible = True
        Me.colDESREP.VisibleIndex = 7
        Me.colDESREP.Width = 210
        '
        'colCODST
        '
        Me.colCODST.FieldName = "CODST"
        Me.colCODST.Name = "colCODST"
        '
        'colDESST
        '
        Me.colDESST.Caption = "TIPO ENVIO"
        Me.colDESST.FieldName = "DESST"
        Me.colDESST.Name = "colDESST"
        Me.colDESST.Visible = True
        Me.colDESST.VisibleIndex = 6
        Me.colDESST.Width = 100
        '
        'colENTREGADO
        '
        Me.colENTREGADO.FieldName = "ENTREGADO"
        Me.colENTREGADO.Name = "colENTREGADO"
        Me.colENTREGADO.Visible = True
        Me.colENTREGADO.VisibleIndex = 8
        Me.colENTREGADO.Width = 77
        '
        'colOBS
        '
        Me.colOBS.FieldName = "OBS"
        Me.colOBS.Name = "colOBS"
        '
        'TblSyncPedidosBindingSource
        '
        Me.TblSyncPedidosBindingSource.DataMember = "tblSyncPedidos"
        Me.TblSyncPedidosBindingSource.DataSource = Me.DSGeneralBindingSource
        '
        'TblSyncPedidosBindingSource1
        '
        Me.TblSyncPedidosBindingSource1.DataMember = "tblSyncPedidos"
        Me.TblSyncPedidosBindingSource1.DataSource = Me.DSGeneralBindingSource
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.FlyoutPanelOpcionesSync)
        Me.GroupControl1.Controls.Add(Me.GridPedidosPendientes)
        Me.GroupControl1.Location = New System.Drawing.Point(3, 158)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1080, 535)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "Pedidos - DOBLE CLIC PARA IMPRIMIR"
        '
        'FlyoutPanelOpcionesSync
        '
        Me.FlyoutPanelOpcionesSync.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelOpcionesSync.Location = New System.Drawing.Point(513, 42)
        Me.FlyoutPanelOpcionesSync.Name = "FlyoutPanelOpcionesSync"
        Me.FlyoutPanelOpcionesSync.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutPanelOpcionesSync.Options.CloseOnOuterClick = True
        Me.FlyoutPanelOpcionesSync.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Right
        Me.FlyoutPanelOpcionesSync.OptionsBeakPanel.Opacity = 0.9R
        Me.FlyoutPanelOpcionesSync.OwnerControl = Me
        Me.FlyoutPanelOpcionesSync.Size = New System.Drawing.Size(274, 647)
        Me.FlyoutPanelOpcionesSync.TabIndex = 4
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.btnSyncDashboard)
        Me.FlyoutPanelControl1.Controls.Add(Me.btnCerrarFlyoutSync)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelOpcionesSync
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(274, 647)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'btnSyncDashboard
        '
        Me.btnSyncDashboard.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSyncDashboard.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSyncDashboard.Appearance.Options.UseBackColor = True
        Me.btnSyncDashboard.Appearance.Options.UseForeColor = True
        Me.btnSyncDashboard.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSyncDashboard.Image = CType(resources.GetObject("btnSyncDashboard.Image"), System.Drawing.Image)
        Me.btnSyncDashboard.Location = New System.Drawing.Point(24, 101)
        Me.btnSyncDashboard.Name = "btnSyncDashboard"
        Me.btnSyncDashboard.Size = New System.Drawing.Size(211, 43)
        Me.btnSyncDashboard.TabIndex = 6
        Me.btnSyncDashboard.Text = "Sincronizar Dashboard Mes"
        '
        'btnCerrarFlyoutSync
        '
        Me.btnCerrarFlyoutSync.Location = New System.Drawing.Point(8, 6)
        Me.btnCerrarFlyoutSync.Name = "btnCerrarFlyoutSync"
        Me.btnCerrarFlyoutSync.Size = New System.Drawing.Size(30, 21)
        Me.btnCerrarFlyoutSync.TabIndex = 1
        Me.btnCerrarFlyoutSync.Text = "x"
        '
        'btnSyncVendedores
        '
        Me.btnSyncVendedores.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSyncVendedores.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSyncVendedores.Appearance.Options.UseBackColor = True
        Me.btnSyncVendedores.Appearance.Options.UseForeColor = True
        Me.btnSyncVendedores.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSyncVendedores.Image = CType(resources.GetObject("btnSyncVendedores.Image"), System.Drawing.Image)
        Me.btnSyncVendedores.Location = New System.Drawing.Point(403, 26)
        Me.btnSyncVendedores.Name = "btnSyncVendedores"
        Me.btnSyncVendedores.Size = New System.Drawing.Size(118, 43)
        Me.btnSyncVendedores.TabIndex = 5
        Me.btnSyncVendedores.Text = "Vendedores"
        '
        'btnSyncRepartidores
        '
        Me.btnSyncRepartidores.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSyncRepartidores.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSyncRepartidores.Appearance.Options.UseBackColor = True
        Me.btnSyncRepartidores.Appearance.Options.UseForeColor = True
        Me.btnSyncRepartidores.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSyncRepartidores.Image = CType(resources.GetObject("btnSyncRepartidores.Image"), System.Drawing.Image)
        Me.btnSyncRepartidores.Location = New System.Drawing.Point(527, 26)
        Me.btnSyncRepartidores.Name = "btnSyncRepartidores"
        Me.btnSyncRepartidores.Size = New System.Drawing.Size(106, 43)
        Me.btnSyncRepartidores.TabIndex = 4
        Me.btnSyncRepartidores.Text = "Repartidores"
        '
        'btnSyncClientes
        '
        Me.btnSyncClientes.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSyncClientes.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSyncClientes.Appearance.Options.UseBackColor = True
        Me.btnSyncClientes.Appearance.Options.UseForeColor = True
        Me.btnSyncClientes.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSyncClientes.Image = CType(resources.GetObject("btnSyncClientes.Image"), System.Drawing.Image)
        Me.btnSyncClientes.Location = New System.Drawing.Point(281, 26)
        Me.btnSyncClientes.Name = "btnSyncClientes"
        Me.btnSyncClientes.Size = New System.Drawing.Size(107, 43)
        Me.btnSyncClientes.TabIndex = 3
        Me.btnSyncClientes.Text = "Clientes"
        '
        'btnSyncProductos
        '
        Me.btnSyncProductos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSyncProductos.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSyncProductos.Appearance.Options.UseBackColor = True
        Me.btnSyncProductos.Appearance.Options.UseForeColor = True
        Me.btnSyncProductos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSyncProductos.Image = CType(resources.GetObject("btnSyncProductos.Image"), System.Drawing.Image)
        Me.btnSyncProductos.Location = New System.Drawing.Point(155, 26)
        Me.btnSyncProductos.Name = "btnSyncProductos"
        Me.btnSyncProductos.Size = New System.Drawing.Size(111, 43)
        Me.btnSyncProductos.TabIndex = 2
        Me.btnSyncProductos.Text = "Productos"
        '
        'btnSyncTodo
        '
        Me.btnSyncTodo.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSyncTodo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSyncTodo.Appearance.Options.UseBackColor = True
        Me.btnSyncTodo.Appearance.Options.UseForeColor = True
        Me.btnSyncTodo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnSyncTodo.Image = CType(resources.GetObject("btnSyncTodo.Image"), System.Drawing.Image)
        Me.btnSyncTodo.Location = New System.Drawing.Point(24, 26)
        Me.btnSyncTodo.Name = "btnSyncTodo"
        Me.btnSyncTodo.Size = New System.Drawing.Size(103, 50)
        Me.btnSyncTodo.TabIndex = 0
        Me.btnSyncTodo.Text = "TODO"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(336, 14)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(139, 35)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "Actualizar catálogos"
        Me.SimpleButton1.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SimpleButton2.Appearance.Options.UseBackColor = True
        Me.SimpleButton2.Appearance.Options.UseForeColor = True
        Me.SimpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(281, 34)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(44, 35)
        Me.SimpleButton2.TabIndex = 7
        '
        'RadialMenuSync
        '
        Me.RadialMenuSync.AutoExpand = True
        Me.RadialMenuSync.Glyph = CType(resources.GetObject("RadialMenuSync.Glyph"), System.Drawing.Image)
        Me.RadialMenuSync.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuSync.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadImprimir), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadFacturar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadRepartidor), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadEntregado), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadObs), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadEditarPedido)})
        Me.RadialMenuSync.Manager = Me.BarManager1
        Me.RadialMenuSync.Name = "RadialMenuSync"
        '
        'btnRadImprimir
        '
        Me.btnRadImprimir.Caption = "IMPRIMIR"
        Me.btnRadImprimir.CloseRadialMenuOnItemClick = True
        Me.btnRadImprimir.Glyph = CType(resources.GetObject("btnRadImprimir.Glyph"), System.Drawing.Image)
        Me.btnRadImprimir.Id = 0
        Me.btnRadImprimir.Name = "btnRadImprimir"
        '
        'btnRadEliminar
        '
        Me.btnRadEliminar.Caption = "ELIMINAR"
        Me.btnRadEliminar.CloseRadialMenuOnItemClick = True
        Me.btnRadEliminar.Glyph = CType(resources.GetObject("btnRadEliminar.Glyph"), System.Drawing.Image)
        Me.btnRadEliminar.Id = 1
        Me.btnRadEliminar.Name = "btnRadEliminar"
        '
        'btnRadFacturar
        '
        Me.btnRadFacturar.Caption = "FACTURAR"
        Me.btnRadFacturar.CloseRadialMenuOnItemClick = True
        Me.btnRadFacturar.Glyph = CType(resources.GetObject("btnRadFacturar.Glyph"), System.Drawing.Image)
        Me.btnRadFacturar.Id = 2
        Me.btnRadFacturar.Name = "btnRadFacturar"
        '
        'btnRadRepartidor
        '
        Me.btnRadRepartidor.Caption = "ASIGNAR EMBARQUE"
        Me.btnRadRepartidor.CloseRadialMenuOnItemClick = True
        Me.btnRadRepartidor.Enabled = False
        Me.btnRadRepartidor.Glyph = CType(resources.GetObject("btnRadRepartidor.Glyph"), System.Drawing.Image)
        Me.btnRadRepartidor.Id = 3
        Me.btnRadRepartidor.Name = "btnRadRepartidor"
        '
        'btnRadEntregado
        '
        Me.btnRadEntregado.Caption = "ENTREGADO/PEND"
        Me.btnRadEntregado.CloseRadialMenuOnItemClick = True
        Me.btnRadEntregado.Glyph = CType(resources.GetObject("btnRadEntregado.Glyph"), System.Drawing.Image)
        Me.btnRadEntregado.Id = 4
        Me.btnRadEntregado.Name = "btnRadEntregado"
        '
        'btnRadObs
        '
        Me.btnRadObs.Caption = "OBSERVACIONES"
        Me.btnRadObs.CloseRadialMenuOnItemClick = True
        Me.btnRadObs.Glyph = CType(resources.GetObject("btnRadObs.Glyph"), System.Drawing.Image)
        Me.btnRadObs.Id = 5
        Me.btnRadObs.Name = "btnRadObs"
        '
        'btnRadEditarPedido
        '
        Me.btnRadEditarPedido.Caption = "EDITAR"
        Me.btnRadEditarPedido.CloseRadialMenuOnItemClick = True
        Me.btnRadEditarPedido.Enabled = False
        Me.btnRadEditarPedido.Glyph = CType(resources.GetObject("btnRadEditarPedido.Glyph"), System.Drawing.Image)
        Me.btnRadEditarPedido.Id = 6
        Me.btnRadEditarPedido.Name = "btnRadEditarPedido"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRadImprimir, Me.btnRadEliminar, Me.btnRadFacturar, Me.btnRadRepartidor, Me.btnRadEntregado, Me.btnRadObs, Me.btnRadEditarPedido})
        Me.BarManager1.MaxItemId = 7
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1086, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 696)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1086, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 696)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1086, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 696)
        '
        'switchEliminaFacturar
        '
        Me.switchEliminaFacturar.Location = New System.Drawing.Point(641, 21)
        Me.switchEliminaFacturar.MenuManager = Me.BarManager1
        Me.switchEliminaFacturar.Name = "switchEliminaFacturar"
        Me.switchEliminaFacturar.Properties.OffText = "NO"
        Me.switchEliminaFacturar.Properties.OnText = "SI"
        Me.switchEliminaFacturar.Size = New System.Drawing.Size(95, 24)
        Me.switchEliminaFacturar.TabIndex = 12
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(490, 26)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(132, 13)
        Me.LabelControl3.TabIndex = 13
        Me.LabelControl3.Text = "¿Elimina pedido al Facturar?"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.btnSyncObtenerCenso)
        Me.GroupControl2.Controls.Add(Me.SimpleButton2)
        Me.GroupControl2.Controls.Add(Me.btnEmbarqueGeneral)
        Me.GroupControl2.Location = New System.Drawing.Point(41, 55)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(348, 87)
        Me.GroupControl2.TabIndex = 20
        Me.GroupControl2.Text = "Obtención de Datos"
        '
        'btnSyncObtenerCenso
        '
        Me.btnSyncObtenerCenso.Image = CType(resources.GetObject("btnSyncObtenerCenso.Image"), System.Drawing.Image)
        Me.btnSyncObtenerCenso.Location = New System.Drawing.Point(10, 34)
        Me.btnSyncObtenerCenso.Name = "btnSyncObtenerCenso"
        Me.btnSyncObtenerCenso.Size = New System.Drawing.Size(119, 35)
        Me.btnSyncObtenerCenso.TabIndex = 32
        Me.btnSyncObtenerCenso.Text = "Obtener Censo"
        '
        'btnEmbarqueGeneral
        '
        Me.btnEmbarqueGeneral.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnEmbarqueGeneral.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmbarqueGeneral.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnEmbarqueGeneral.Appearance.Options.UseBackColor = True
        Me.btnEmbarqueGeneral.Appearance.Options.UseFont = True
        Me.btnEmbarqueGeneral.Appearance.Options.UseForeColor = True
        Me.btnEmbarqueGeneral.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnEmbarqueGeneral.Image = CType(resources.GetObject("btnEmbarqueGeneral.Image"), System.Drawing.Image)
        Me.btnEmbarqueGeneral.Location = New System.Drawing.Point(154, 34)
        Me.btnEmbarqueGeneral.Name = "btnEmbarqueGeneral"
        Me.btnEmbarqueGeneral.Size = New System.Drawing.Size(99, 35)
        Me.btnEmbarqueGeneral.TabIndex = 22
        Me.btnEmbarqueGeneral.Text = "General"
        '
        'GridExports
        '
        Me.GridExports.Location = New System.Drawing.Point(13, 161)
        Me.GridExports.MainView = Me.GridView1
        Me.GridExports.MenuManager = Me.BarManager1
        Me.GridExports.Name = "GridExports"
        Me.GridExports.Size = New System.Drawing.Size(960, 200)
        Me.GridExports.TabIndex = 21
        Me.GridExports.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridExports
        Me.GridView1.Name = "GridView1"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(755, 25)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl2.TabIndex = 27
        Me.LabelControl2.Text = "Filtrar por:"
        '
        'switchEntregados
        '
        Me.switchEntregados.Location = New System.Drawing.Point(839, 21)
        Me.switchEntregados.MenuManager = Me.BarManager1
        Me.switchEntregados.Name = "switchEntregados"
        Me.switchEntregados.Properties.OffText = "NO ENTREGADOS"
        Me.switchEntregados.Properties.OnText = "ENTREGADOS"
        Me.switchEntregados.Size = New System.Drawing.Size(162, 24)
        Me.switchEntregados.TabIndex = 26
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.btnSyncTodo)
        Me.GroupControl3.Controls.Add(Me.btnSyncRepartidores)
        Me.GroupControl3.Controls.Add(Me.btnSyncVendedores)
        Me.GroupControl3.Controls.Add(Me.btnSyncProductos)
        Me.GroupControl3.Controls.Add(Me.btnSyncClientes)
        Me.GroupControl3.Location = New System.Drawing.Point(395, 55)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(638, 87)
        Me.GroupControl3.TabIndex = 37
        Me.GroupControl3.Text = "Sincronización de Datos / Subida de datos"
        '
        'viewSync
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.switchEntregados)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.switchEliminaFacturar)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridExports)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewSync"
        Me.Size = New System.Drawing.Size(1086, 696)
        CType(Me.GridPedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblSyncPedidosBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblSyncPedidosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblSyncPedidosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.FlyoutPanelOpcionesSync, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelOpcionesSync.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        CType(Me.RadialMenuSync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.switchEliminaFacturar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GridExports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.switchEntregados.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridPedidosPendientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents TblSyncPedidosBindingSource As BindingSource
    Friend WithEvents DSGeneralBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents TblSyncPedidosBindingSource1 As BindingSource
    Friend WithEvents TblSyncPedidosBindingSource2 As BindingSource
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadialMenuSync As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents btnRadImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadFacturar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents switchEliminaFacturar As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents GridViewSync As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODVEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMVEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALVENTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHAENVIADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnRadRepartidor As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colDESREP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FlyoutPanelOpcionesSync As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents btnSyncRepartidores As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSyncClientes As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSyncProductos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCerrarFlyoutSync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSyncTodo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSyncVendedores As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colENTREGADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnRadEntregado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadObs As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colOBS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnEmbarqueGeneral As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridExports As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents switchEntregados As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents btnRadEditarPedido As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnSyncDashboard As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSyncObtenerCenso As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
End Class
