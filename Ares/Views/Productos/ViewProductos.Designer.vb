<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewProductos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewProductos))
        Me.RadialMenuProductos = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.BarButtonItemProductosCambiar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemVentas = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemCompras = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemKardex = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemInfo = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemDesactivar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadMenPreciosCompetencia = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemMenDetallesAdicionales = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemInventarioOnline = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.NavigationFrame = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.NP_Listado = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl31 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbProductosFiltroHabilitado = New System.Windows.Forms.ComboBox()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.FlyoutOpcionesAvanzadas = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl2 = New DevExpress.Utils.FlyoutPanelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnConfigEditProductosSync = New DevExpress.XtraEditors.SimpleButton()
        Me.btnConfigActualizarCostos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSincronizarTodo = New DevExpress.XtraEditors.SimpleButton()
        Me.GridProductos = New DevExpress.XtraGrid.GridControl()
        Me.TblProductosBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewProductos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHABILITADO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.dgvMedidasPrecios = New System.Windows.Forms.DataGridView()
        Me.CODMEDIDADataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQUIVALEDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAYOREOADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAYOREOBDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAYOREOCDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BONO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblPreciosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOS = New Ares.DSPRODUCTOS()
        Me.productos_WindowsUIButton = New DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel()
        Me.GridProductosKardex = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lbNewProductosDesc3 = New System.Windows.Forms.TextBox()
        Me.lbNewProductosDescripcion = New System.Windows.Forms.TextBox()
        Me.lbNewProductosCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.lbNewProductosDescripcion3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl176 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl175 = New DevExpress.XtraEditors.LabelControl()
        Me.lbNewProductosCosto = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl174 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdNewProductosNuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.NP_Detalle = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.btnAtras = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnProductoEliminarReceta = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAgregarReceta = New DevExpress.XtraEditors.SimpleButton()
        Me.DgwReceta = New System.Windows.Forms.DataGridView()
        Me.CODPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALUNIDADESDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALCOSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblRecetaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridProductoPrecios = New System.Windows.Forms.DataGridView()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQUIVALEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UTILIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MARGENDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAYOREOADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAYOREOBDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MAYOREOCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HABILITADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MARGENCONFIG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdProductoAgregarPrecio = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl180 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoCostoUnitario = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl49 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdProductoCancelarEdicion = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdProductoGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.groupproducots = New DevExpress.XtraEditors.GroupControl()
        Me.TextBON = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LbProductosDesc3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoDescripcion3 = New DevExpress.XtraEditors.TextEdit()
        Me.LbProductosDesc2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoDescripcion2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoCodigo2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.FlyoutPanelSeries = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.btnSerieCerrarPanel = New DevExpress.XtraEditors.SimpleButton()
        Me.dgvSeries = New DevExpress.XtraGrid.GridControl()
        Me.TblSeriesBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewSeries = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOSERIE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnSerieCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.btnEliminarTodos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSerieGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSerieColor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSerieNoSerie = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoProd = New System.Windows.Forms.ComboBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.SwitchExento = New DevExpress.XtraEditors.ToggleSwitch()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoInvMinimo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSeries = New DevExpress.XtraEditors.SimpleButton()
        Me.SwitchSeries = New DevExpress.XtraEditors.ToggleSwitch()
        Me.lbProductoSerie = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoFechaVence = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl50 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl32 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductosUxc = New DevExpress.XtraEditors.TextEdit()
        Me.cmdProductosQuitarFoto = New DevExpress.XtraEditors.SimpleButton()
        Me.txtProductosRutaFoto = New DevExpress.XtraEditors.TextEdit()
        Me.cmdProductoTomarFoto = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdProductoBuscarFoto = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl30 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbProductoClaseTres = New System.Windows.Forms.ComboBox()
        Me.LabelControl29 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbProductoClaseDos = New System.Windows.Forms.ComboBox()
        Me.LabelControl28 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbProductoClaseUno = New System.Windows.Forms.ComboBox()
        Me.LabelControl27 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbProductoMarca = New System.Windows.Forms.ComboBox()
        Me.imgProductosFotoProducto = New DevExpress.XtraEditors.PictureEdit()
        Me.NP_SyncProductos = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GridDetallesProductos = New DevExpress.XtraGrid.GridControl()
        Me.TblDatosAdicionalesProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSSync = New Ares.DSSync()
        Me.GridViewDetallesProductos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEMPNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMPNOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODPROD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINVMINIMO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINVMAXIMO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHABILITADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TblProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TblSeriesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadialMenu1 = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.BarManager2 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl3 = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl4 = New DevExpress.XtraBars.BarDockControl()
        Me.TblRecetaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimerLoader = New System.Windows.Forms.Timer(Me.components)
        Me.TblProductosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.RadialMenuProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavigationFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationFrame.SuspendLayout()
        Me.NP_Listado.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.FlyoutOpcionesAvanzadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutOpcionesAvanzadas.SuspendLayout()
        CType(Me.FlyoutPanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl2.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProductosBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.dgvMedidasPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblPreciosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.productos_WindowsUIButton.SuspendLayout()
        CType(Me.GridProductosKardex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbNewProductosCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NP_Detalle.SuspendLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.DgwReceta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblRecetaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridProductoPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoCostoUnitario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.groupproducots, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupproducots.SuspendLayout()
        CType(Me.TextBON.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoDescripcion3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoDescripcion2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoCodigo2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutPanelSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelSeries.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.dgvSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblSeriesBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerieColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSerieNoSerie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwitchExento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoInvMinimo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwitchSeries.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoFechaVence.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductosUxc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductosRutaFoto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgProductosFotoProducto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NP_SyncProductos.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GridDetallesProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDatosAdicionalesProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSSync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetallesProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblSeriesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadialMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblRecetaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProductosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadialMenuProductos
        '
        Me.RadialMenuProductos.AutoExpand = True
        Me.RadialMenuProductos.Glyph = CType(resources.GetObject("RadialMenuProductos.Glyph"), System.Drawing.Image)
        Me.RadialMenuProductos.InnerRadius = 20
        Me.RadialMenuProductos.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuProductos.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemProductosCambiar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemVentas), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemCompras), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemKardex), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemInfo), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemDesactivar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenPreciosCompetencia), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemMenDetallesAdicionales), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemInventarioOnline)})
        Me.RadialMenuProductos.Manager = Me.BarManager1
        Me.RadialMenuProductos.MenuRadius = 220
        Me.RadialMenuProductos.Name = "RadialMenuProductos"
        '
        'BarButtonItemProductosCambiar
        '
        Me.BarButtonItemProductosCambiar.Caption = "Cambiar Código"
        Me.BarButtonItemProductosCambiar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemProductosCambiar.Glyph = CType(resources.GetObject("BarButtonItemProductosCambiar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemProductosCambiar.GroupIndex = 7
        Me.BarButtonItemProductosCambiar.Id = 0
        Me.BarButtonItemProductosCambiar.Name = "BarButtonItemProductosCambiar"
        '
        'BarButtonItemVentas
        '
        Me.BarButtonItemVentas.Caption = "Ventas del Mes"
        Me.BarButtonItemVentas.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemVentas.Glyph = CType(resources.GetObject("BarButtonItemVentas.Glyph"), System.Drawing.Image)
        Me.BarButtonItemVentas.GroupIndex = 3
        Me.BarButtonItemVentas.Id = 1
        Me.BarButtonItemVentas.Name = "BarButtonItemVentas"
        '
        'BarButtonItemCompras
        '
        Me.BarButtonItemCompras.Caption = "Compras del Año"
        Me.BarButtonItemCompras.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemCompras.Glyph = CType(resources.GetObject("BarButtonItemCompras.Glyph"), System.Drawing.Image)
        Me.BarButtonItemCompras.GroupIndex = 4
        Me.BarButtonItemCompras.Id = 2
        Me.BarButtonItemCompras.Name = "BarButtonItemCompras"
        '
        'BarButtonItemKardex
        '
        Me.BarButtonItemKardex.Caption = "Kardex del Año"
        Me.BarButtonItemKardex.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemKardex.Glyph = CType(resources.GetObject("BarButtonItemKardex.Glyph"), System.Drawing.Image)
        Me.BarButtonItemKardex.GroupIndex = 5
        Me.BarButtonItemKardex.Id = 3
        Me.BarButtonItemKardex.Name = "BarButtonItemKardex"
        '
        'BarButtonItemInfo
        '
        Me.BarButtonItemInfo.Caption = "Ver Información"
        Me.BarButtonItemInfo.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemInfo.Glyph = CType(resources.GetObject("BarButtonItemInfo.Glyph"), System.Drawing.Image)
        Me.BarButtonItemInfo.Id = 4
        Me.BarButtonItemInfo.Name = "BarButtonItemInfo"
        '
        'BarButtonItemEditar
        '
        Me.BarButtonItemEditar.Caption = "Editar"
        Me.BarButtonItemEditar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemEditar.Glyph = CType(resources.GetObject("BarButtonItemEditar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemEditar.GroupIndex = 1
        Me.BarButtonItemEditar.Id = 5
        Me.BarButtonItemEditar.Name = "BarButtonItemEditar"
        '
        'BarButtonItemDesactivar
        '
        Me.BarButtonItemDesactivar.Caption = "Desactivar/Activar"
        Me.BarButtonItemDesactivar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemDesactivar.Glyph = CType(resources.GetObject("BarButtonItemDesactivar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemDesactivar.GroupIndex = 2
        Me.BarButtonItemDesactivar.Id = 6
        Me.BarButtonItemDesactivar.Name = "BarButtonItemDesactivar"
        '
        'BarButtonItemEliminar
        '
        Me.BarButtonItemEliminar.Caption = "Eliminar"
        Me.BarButtonItemEliminar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemEliminar.Glyph = CType(resources.GetObject("BarButtonItemEliminar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemEliminar.GroupIndex = 6
        Me.BarButtonItemEliminar.Id = 7
        Me.BarButtonItemEliminar.Name = "BarButtonItemEliminar"
        '
        'btnRadMenPreciosCompetencia
        '
        Me.btnRadMenPreciosCompetencia.Caption = "Otros Proveedores"
        Me.btnRadMenPreciosCompetencia.CloseRadialMenuOnItemClick = True
        Me.btnRadMenPreciosCompetencia.Glyph = CType(resources.GetObject("btnRadMenPreciosCompetencia.Glyph"), System.Drawing.Image)
        Me.btnRadMenPreciosCompetencia.Id = 8
        Me.btnRadMenPreciosCompetencia.Name = "btnRadMenPreciosCompetencia"
        '
        'BarButtonItemMenDetallesAdicionales
        '
        Me.BarButtonItemMenDetallesAdicionales.Caption = "Detalles Sync"
        Me.BarButtonItemMenDetallesAdicionales.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemMenDetallesAdicionales.Glyph = CType(resources.GetObject("BarButtonItemMenDetallesAdicionales.Glyph"), System.Drawing.Image)
        Me.BarButtonItemMenDetallesAdicionales.Id = 9
        Me.BarButtonItemMenDetallesAdicionales.Name = "BarButtonItemMenDetallesAdicionales"
        '
        'BarButtonItemInventarioOnline
        '
        Me.BarButtonItemInventarioOnline.Caption = "Inventario Online"
        Me.BarButtonItemInventarioOnline.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemInventarioOnline.Glyph = CType(resources.GetObject("BarButtonItemInventarioOnline.Glyph"), System.Drawing.Image)
        Me.BarButtonItemInventarioOnline.Id = 10
        Me.BarButtonItemInventarioOnline.Name = "BarButtonItemInventarioOnline"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItemInfo, Me.BarButtonItemEditar, Me.BarButtonItemDesactivar, Me.BarButtonItemVentas, Me.BarButtonItemCompras, Me.BarButtonItemKardex, Me.BarButtonItemEliminar, Me.BarButtonItemProductosCambiar, Me.btnRadMenPreciosCompetencia, Me.BarButtonItemMenDetallesAdicionales, Me.BarButtonItemInventarioOnline})
        Me.BarManager1.MaxItemId = 11
        Me.BarManager1.UseAltKeyForMenu = False
        Me.BarManager1.UseF10KeyForMenu = False
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1280, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 677)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1280, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 677)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1280, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 677)
        '
        'NavigationFrame
        '
        Me.NavigationFrame.Controls.Add(Me.NP_Listado)
        Me.NavigationFrame.Controls.Add(Me.NP_Detalle)
        Me.NavigationFrame.Controls.Add(Me.NP_SyncProductos)
        Me.NavigationFrame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationFrame.Location = New System.Drawing.Point(0, 0)
        Me.NavigationFrame.Name = "NavigationFrame"
        Me.NavigationFrame.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NP_Listado, Me.NP_Detalle, Me.NP_SyncProductos})
        Me.NavigationFrame.SelectedPage = Me.NP_Listado
        Me.NavigationFrame.Size = New System.Drawing.Size(1280, 677)
        Me.NavigationFrame.TabIndex = 211
        Me.NavigationFrame.Text = "NavigationFrame1"
        Me.NavigationFrame.TransitionAnimationProperties.FrameCount = 500
        Me.NavigationFrame.TransitionAnimationProperties.FrameInterval = 5000
        '
        'NP_Listado
        '
        Me.NP_Listado.Controls.Add(Me.SimpleButton1)
        Me.NP_Listado.Controls.Add(Me.LabelControl31)
        Me.NP_Listado.Controls.Add(Me.cmbProductosFiltroHabilitado)
        Me.NP_Listado.Controls.Add(Me.SplitContainerControl1)
        Me.NP_Listado.Controls.Add(Me.cmdNewProductosNuevo)
        Me.NP_Listado.Controls.Add(Me.LabelControl3)
        Me.NP_Listado.Name = "NP_Listado"
        Me.NP_Listado.Size = New System.Drawing.Size(1280, 677)
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = CType(resources.GetObject("SimpleButton1.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(893, 11)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(152, 50)
        Me.SimpleButton1.TabIndex = 210
        Me.SimpleButton1.Text = "Opciones Avanzadas"
        '
        'LabelControl31
        '
        Me.LabelControl31.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl31.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl31.Location = New System.Drawing.Point(312, 34)
        Me.LabelControl31.Name = "LabelControl31"
        Me.LabelControl31.Size = New System.Drawing.Size(82, 16)
        Me.LabelControl31.TabIndex = 207
        Me.LabelControl31.Text = "Filtro General:"
        '
        'cmbProductosFiltroHabilitado
        '
        Me.cmbProductosFiltroHabilitado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProductosFiltroHabilitado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProductosFiltroHabilitado.FormattingEnabled = True
        Me.cmbProductosFiltroHabilitado.Items.AddRange(New Object() {"HABILITADOS", "DESHABILITADOS", "TODOS"})
        Me.cmbProductosFiltroHabilitado.Location = New System.Drawing.Point(403, 32)
        Me.cmbProductosFiltroHabilitado.Name = "cmbProductosFiltroHabilitado"
        Me.cmbProductosFiltroHabilitado.Size = New System.Drawing.Size(135, 21)
        Me.cmbProductosFiltroHabilitado.TabIndex = 206
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2
        Me.SplitContainerControl1.Location = New System.Drawing.Point(8, 79)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.FlyoutOpcionesAvanzadas)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GridProductos)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1259, 595)
        Me.SplitContainerControl1.SplitterPosition = 840
        Me.SplitContainerControl1.TabIndex = 205
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'FlyoutOpcionesAvanzadas
        '
        Me.FlyoutOpcionesAvanzadas.Controls.Add(Me.FlyoutPanelControl2)
        Me.FlyoutOpcionesAvanzadas.Location = New System.Drawing.Point(701, 505)
        Me.FlyoutOpcionesAvanzadas.Name = "FlyoutOpcionesAvanzadas"
        Me.FlyoutOpcionesAvanzadas.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutOpcionesAvanzadas.Options.CloseOnOuterClick = True
        Me.FlyoutOpcionesAvanzadas.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Right
        Me.FlyoutOpcionesAvanzadas.OptionsBeakPanel.Opacity = 0.9R
        Me.FlyoutOpcionesAvanzadas.OwnerControl = Me
        Me.FlyoutOpcionesAvanzadas.Size = New System.Drawing.Size(358, 372)
        Me.FlyoutOpcionesAvanzadas.TabIndex = 209
        '
        'FlyoutPanelControl2
        '
        Me.FlyoutPanelControl2.Controls.Add(Me.GroupControl2)
        Me.FlyoutPanelControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl2.FlyoutPanel = Me.FlyoutOpcionesAvanzadas
        Me.FlyoutPanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl2.Name = "FlyoutPanelControl2"
        Me.FlyoutPanelControl2.Size = New System.Drawing.Size(358, 372)
        Me.FlyoutPanelControl2.TabIndex = 0
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.btnConfigEditProductosSync)
        Me.GroupControl2.Controls.Add(Me.btnConfigActualizarCostos)
        Me.GroupControl2.Controls.Add(Me.btnSincronizarTodo)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(354, 368)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = "Opciones Avanzadas"
        '
        'btnConfigEditProductosSync
        '
        Me.btnConfigEditProductosSync.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConfigEditProductosSync.Image = CType(resources.GetObject("btnConfigEditProductosSync.Image"), System.Drawing.Image)
        Me.btnConfigEditProductosSync.Location = New System.Drawing.Point(10, 44)
        Me.btnConfigEditProductosSync.Name = "btnConfigEditProductosSync"
        Me.btnConfigEditProductosSync.Size = New System.Drawing.Size(239, 45)
        Me.btnConfigEditProductosSync.TabIndex = 210
        Me.btnConfigEditProductosSync.Text = "Edición de mínimos y máximos"
        '
        'btnConfigActualizarCostos
        '
        Me.btnConfigActualizarCostos.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnConfigActualizarCostos.Appearance.Options.UseFont = True
        Me.btnConfigActualizarCostos.Image = CType(resources.GetObject("btnConfigActualizarCostos.Image"), System.Drawing.Image)
        Me.btnConfigActualizarCostos.Location = New System.Drawing.Point(21, 226)
        Me.btnConfigActualizarCostos.Name = "btnConfigActualizarCostos"
        Me.btnConfigActualizarCostos.Size = New System.Drawing.Size(313, 54)
        Me.btnConfigActualizarCostos.TabIndex = 209
        Me.btnConfigActualizarCostos.Text = "Actualizar Costos en Medidas Precio"
        '
        'btnSincronizarTodo
        '
        Me.btnSincronizarTodo.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSincronizarTodo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSincronizarTodo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSincronizarTodo.Appearance.Options.UseBackColor = True
        Me.btnSincronizarTodo.Appearance.Options.UseFont = True
        Me.btnSincronizarTodo.Appearance.Options.UseForeColor = True
        Me.btnSincronizarTodo.Image = CType(resources.GetObject("btnSincronizarTodo.Image"), System.Drawing.Image)
        Me.btnSincronizarTodo.Location = New System.Drawing.Point(21, 298)
        Me.btnSincronizarTodo.Name = "btnSincronizarTodo"
        Me.btnSincronizarTodo.Size = New System.Drawing.Size(313, 54)
        Me.btnSincronizarTodo.TabIndex = 208
        Me.btnSincronizarTodo.Text = "Sincronizar Catálogo en Todas las Empresas"
        Me.btnSincronizarTodo.Visible = False
        '
        'GridProductos
        '
        Me.GridProductos.DataSource = Me.TblProductosBindingSource2
        Me.GridProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProductos.Location = New System.Drawing.Point(0, 0)
        Me.GridProductos.MainView = Me.GridViewProductos
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.Size = New System.Drawing.Size(836, 591)
        Me.GridProductos.TabIndex = 1
        Me.GridProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProductos})
        '
        'TblProductosBindingSource2
        '
        Me.TblProductosBindingSource2.DataMember = "tblProductos"
        Me.TblProductosBindingSource2.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewProductos
        '
        Me.GridViewProductos.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.Empty.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridViewProductos.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FixedLine.BackColor = System.Drawing.Color.Gray
        Me.GridViewProductos.Appearance.FixedLine.ForeColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FixedLine.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue
        Me.GridViewProductos.Appearance.FocusedCell.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.DimGray
        Me.GridViewProductos.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FocusedCell.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue
        Me.GridViewProductos.Appearance.FocusedRow.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.DimGray
        Me.GridViewProductos.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.GroupPanel.BackColor = System.Drawing.Color.DarkOrange
        Me.GridViewProductos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.GroupRow.BackColor = System.Drawing.Color.Gray
        Me.GridViewProductos.Appearance.GroupRow.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue
        Me.GridViewProductos.Appearance.SelectedRow.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.DimGray
        Me.GridViewProductos.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.SelectedRow.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridViewProductos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colCOSTO, Me.colDESMARCA, Me.colEXENTO, Me.colBONO, Me.colHABILITADO1})
        Me.GridViewProductos.GridControl = Me.GridProductos
        Me.GridViewProductos.Name = "GridViewProductos"
        Me.GridViewProductos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewProductos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewProductos.OptionsBehavior.Editable = False
        Me.GridViewProductos.OptionsBehavior.ReadOnly = True
        Me.GridViewProductos.OptionsView.ShowAutoFilterRow = True
        Me.GridViewProductos.OptionsView.ShowGroupPanel = False
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "Código"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 149
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "Descripción"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 350
        '
        'colCOSTO
        '
        Me.colCOSTO.Caption = "Costo"
        Me.colCOSTO.DisplayFormat.FormatString = "Q 0.00"
        Me.colCOSTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        Me.colCOSTO.Visible = True
        Me.colCOSTO.VisibleIndex = 2
        Me.colCOSTO.Width = 91
        '
        'colDESMARCA
        '
        Me.colDESMARCA.Caption = "Marca"
        Me.colDESMARCA.FieldName = "DESMARCA"
        Me.colDESMARCA.Name = "colDESMARCA"
        Me.colDESMARCA.Visible = True
        Me.colDESMARCA.VisibleIndex = 3
        Me.colDESMARCA.Width = 174
        '
        'colEXENTO
        '
        Me.colEXENTO.FieldName = "EXENTO"
        Me.colEXENTO.Name = "colEXENTO"
        '
        'colBONO
        '
        Me.colBONO.Caption = "Bono"
        Me.colBONO.DisplayFormat.FormatString = "Q 0.00"
        Me.colBONO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.colBONO.FieldName = "BONO"
        Me.colBONO.Name = "colBONO"
        Me.colBONO.Visible = True
        Me.colBONO.VisibleIndex = 4
        Me.colBONO.Width = 54
        '
        'colHABILITADO1
        '
        Me.colHABILITADO1.FieldName = "HABILITADO"
        Me.colHABILITADO1.Name = "colHABILITADO1"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl11)
        Me.GroupControl1.Controls.Add(Me.dgvMedidasPrecios)
        Me.GroupControl1.Controls.Add(Me.productos_WindowsUIButton)
        Me.GroupControl1.Controls.Add(Me.lbNewProductosDesc3)
        Me.GroupControl1.Controls.Add(Me.lbNewProductosDescripcion)
        Me.GroupControl1.Controls.Add(Me.lbNewProductosCodigo)
        Me.GroupControl1.Controls.Add(Me.lbNewProductosDescripcion3)
        Me.GroupControl1.Controls.Add(Me.LabelControl176)
        Me.GroupControl1.Controls.Add(Me.LabelControl175)
        Me.GroupControl1.Controls.Add(Me.lbNewProductosCosto)
        Me.GroupControl1.Controls.Add(Me.LabelControl174)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(410, 591)
        Me.GroupControl1.TabIndex = 12
        Me.GroupControl1.Text = "Producto Seleccionado"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl11.Location = New System.Drawing.Point(9, 387)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(117, 16)
        Me.LabelControl11.TabIndex = 18
        Me.LabelControl11.Text = "Medidas de Precio"
        '
        'dgvMedidasPrecios
        '
        Me.dgvMedidasPrecios.AllowUserToAddRows = False
        Me.dgvMedidasPrecios.AllowUserToDeleteRows = False
        Me.dgvMedidasPrecios.AutoGenerateColumns = False
        Me.dgvMedidasPrecios.BackgroundColor = System.Drawing.Color.White
        Me.dgvMedidasPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMedidasPrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODMEDIDADataGridViewTextBoxColumn2, Me.EQUIVALEDataGridViewTextBoxColumn1, Me.COSTODataGridViewTextBoxColumn2, Me.PRECIODataGridViewTextBoxColumn1, Me.MAYOREOADataGridViewTextBoxColumn1, Me.MAYOREOBDataGridViewTextBoxColumn1, Me.MAYOREOCDataGridViewTextBoxColumn1, Me.BONO})
        Me.dgvMedidasPrecios.DataSource = Me.TblPreciosBindingSource
        Me.dgvMedidasPrecios.Location = New System.Drawing.Point(5, 406)
        Me.dgvMedidasPrecios.MultiSelect = False
        Me.dgvMedidasPrecios.Name = "dgvMedidasPrecios"
        Me.dgvMedidasPrecios.RowHeadersVisible = False
        Me.dgvMedidasPrecios.Size = New System.Drawing.Size(398, 180)
        Me.dgvMedidasPrecios.TabIndex = 17
        '
        'CODMEDIDADataGridViewTextBoxColumn2
        '
        Me.CODMEDIDADataGridViewTextBoxColumn2.DataPropertyName = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn2.FillWeight = 130.0!
        Me.CODMEDIDADataGridViewTextBoxColumn2.HeaderText = "MEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn2.Name = "CODMEDIDADataGridViewTextBoxColumn2"
        Me.CODMEDIDADataGridViewTextBoxColumn2.Width = 130
        '
        'EQUIVALEDataGridViewTextBoxColumn1
        '
        Me.EQUIVALEDataGridViewTextBoxColumn1.DataPropertyName = "EQUIVALE"
        Me.EQUIVALEDataGridViewTextBoxColumn1.HeaderText = "EQ"
        Me.EQUIVALEDataGridViewTextBoxColumn1.Name = "EQUIVALEDataGridViewTextBoxColumn1"
        Me.EQUIVALEDataGridViewTextBoxColumn1.Width = 30
        '
        'COSTODataGridViewTextBoxColumn2
        '
        Me.COSTODataGridViewTextBoxColumn2.DataPropertyName = "COSTO"
        Me.COSTODataGridViewTextBoxColumn2.HeaderText = "COSTO"
        Me.COSTODataGridViewTextBoxColumn2.Name = "COSTODataGridViewTextBoxColumn2"
        Me.COSTODataGridViewTextBoxColumn2.Width = 70
        '
        'PRECIODataGridViewTextBoxColumn1
        '
        Me.PRECIODataGridViewTextBoxColumn1.DataPropertyName = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn1.HeaderText = "PUBLICO"
        Me.PRECIODataGridViewTextBoxColumn1.Name = "PRECIODataGridViewTextBoxColumn1"
        Me.PRECIODataGridViewTextBoxColumn1.Width = 70
        '
        'MAYOREOADataGridViewTextBoxColumn1
        '
        Me.MAYOREOADataGridViewTextBoxColumn1.DataPropertyName = "MAYOREOA"
        Me.MAYOREOADataGridViewTextBoxColumn1.HeaderText = "MAYOREO"
        Me.MAYOREOADataGridViewTextBoxColumn1.Name = "MAYOREOADataGridViewTextBoxColumn1"
        Me.MAYOREOADataGridViewTextBoxColumn1.Width = 70
        '
        'MAYOREOBDataGridViewTextBoxColumn1
        '
        Me.MAYOREOBDataGridViewTextBoxColumn1.DataPropertyName = "MAYOREOB"
        Me.MAYOREOBDataGridViewTextBoxColumn1.HeaderText = "PRECIOA"
        Me.MAYOREOBDataGridViewTextBoxColumn1.Name = "MAYOREOBDataGridViewTextBoxColumn1"
        Me.MAYOREOBDataGridViewTextBoxColumn1.Width = 70
        '
        'MAYOREOCDataGridViewTextBoxColumn1
        '
        Me.MAYOREOCDataGridViewTextBoxColumn1.DataPropertyName = "MAYOREOC"
        Me.MAYOREOCDataGridViewTextBoxColumn1.HeaderText = "PRECIOB"
        Me.MAYOREOCDataGridViewTextBoxColumn1.Name = "MAYOREOCDataGridViewTextBoxColumn1"
        Me.MAYOREOCDataGridViewTextBoxColumn1.Width = 70
        '
        'BONO
        '
        Me.BONO.DataPropertyName = "BONO"
        Me.BONO.FillWeight = 50.0!
        Me.BONO.HeaderText = "BONO"
        Me.BONO.Name = "BONO"
        Me.BONO.Width = 50
        '
        'TblPreciosBindingSource
        '
        Me.TblPreciosBindingSource.DataMember = "tblPrecios"
        Me.TblPreciosBindingSource.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'DSPRODUCTOSBindingSource
        '
        Me.DSPRODUCTOSBindingSource.DataSource = Me.DSPRODUCTOS
        Me.DSPRODUCTOSBindingSource.Position = 0
        '
        'DSPRODUCTOS
        '
        Me.DSPRODUCTOS.DataSetName = "DSPRODUCTOS"
        Me.DSPRODUCTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'productos_WindowsUIButton
        '
        Me.productos_WindowsUIButton.AllowGlyphSkinning = False
        Me.productos_WindowsUIButton.Buttons.AddRange(New DevExpress.XtraEditors.ButtonPanel.IBaseButton() {New DevExpress.XtraBars.Docking2010.WindowsUIButton("Imprimir", CType(resources.GetObject("productos_WindowsUIButton.Buttons"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", True, -1, True, Nothing, True, False, True, Nothing, "IMPRIMIRK", -1, False, False), New DevExpress.XtraBars.Docking2010.WindowsUIButton("Exportar(xls)", CType(resources.GetObject("productos_WindowsUIButton.Buttons1"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ImageLocation.[Default], DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", True, -1, True, Nothing, True, False, True, Nothing, "EXPORTARK", -1, False, False)})
        Me.productos_WindowsUIButton.ContentAlignment = System.Drawing.ContentAlignment.TopLeft
        Me.productos_WindowsUIButton.Controls.Add(Me.GridProductosKardex)
        Me.productos_WindowsUIButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.productos_WindowsUIButton.Location = New System.Drawing.Point(11, 195)
        Me.productos_WindowsUIButton.Name = "productos_WindowsUIButton"
        Me.productos_WindowsUIButton.Size = New System.Drawing.Size(191, 74)
        Me.productos_WindowsUIButton.TabIndex = 16
        Me.productos_WindowsUIButton.Text = "WindowsUIButtonPanel1"
        '
        'GridProductosKardex
        '
        Me.GridProductosKardex.Location = New System.Drawing.Point(50, 82)
        Me.GridProductosKardex.MainView = Me.GridView1
        Me.GridProductosKardex.Name = "GridProductosKardex"
        Me.GridProductosKardex.Size = New System.Drawing.Size(199, 140)
        Me.GridProductosKardex.TabIndex = 17
        Me.GridProductosKardex.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridProductosKardex.Visible = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridProductosKardex
        Me.GridView1.Name = "GridView1"
        '
        'lbNewProductosDesc3
        '
        Me.lbNewProductosDesc3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNewProductosDesc3.Location = New System.Drawing.Point(104, 104)
        Me.lbNewProductosDesc3.Multiline = True
        Me.lbNewProductosDesc3.Name = "lbNewProductosDesc3"
        Me.lbNewProductosDesc3.Size = New System.Drawing.Size(91, 13)
        Me.lbNewProductosDesc3.TabIndex = 15
        Me.lbNewProductosDesc3.Visible = False
        '
        'lbNewProductosDescripcion
        '
        Me.lbNewProductosDescripcion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNewProductosDescripcion.Location = New System.Drawing.Point(11, 100)
        Me.lbNewProductosDescripcion.Multiline = True
        Me.lbNewProductosDescripcion.Name = "lbNewProductosDescripcion"
        Me.lbNewProductosDescripcion.Size = New System.Drawing.Size(277, 52)
        Me.lbNewProductosDescripcion.TabIndex = 13
        '
        'lbNewProductosCodigo
        '
        Me.lbNewProductosCodigo.Location = New System.Drawing.Point(65, 38)
        Me.lbNewProductosCodigo.Name = "lbNewProductosCodigo"
        Me.lbNewProductosCodigo.Size = New System.Drawing.Size(187, 20)
        Me.lbNewProductosCodigo.TabIndex = 12
        '
        'lbNewProductosDescripcion3
        '
        Me.lbNewProductosDescripcion3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNewProductosDescripcion3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.lbNewProductosDescripcion3.Location = New System.Drawing.Point(104, 92)
        Me.lbNewProductosDescripcion3.Name = "lbNewProductosDescripcion3"
        Me.lbNewProductosDescripcion3.Size = New System.Drawing.Size(91, 16)
        Me.lbNewProductosDescripcion3.TabIndex = 11
        Me.lbNewProductosDescripcion3.Text = "Descripción 3:"
        Me.lbNewProductosDescripcion3.Visible = False
        '
        'LabelControl176
        '
        Me.LabelControl176.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl176.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl176.Location = New System.Drawing.Point(11, 81)
        Me.LabelControl176.Name = "LabelControl176"
        Me.LabelControl176.Size = New System.Drawing.Size(79, 16)
        Me.LabelControl176.TabIndex = 2
        Me.LabelControl176.Text = "Descripción:"
        '
        'LabelControl175
        '
        Me.LabelControl175.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl175.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl175.Location = New System.Drawing.Point(11, 167)
        Me.LabelControl175.Name = "LabelControl175"
        Me.LabelControl175.Size = New System.Drawing.Size(96, 16)
        Me.LabelControl175.TabIndex = 3
        Me.LabelControl175.Text = "Costo Unitario:"
        '
        'lbNewProductosCosto
        '
        Me.lbNewProductosCosto.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNewProductosCosto.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.lbNewProductosCosto.Location = New System.Drawing.Point(113, 167)
        Me.lbNewProductosCosto.Name = "lbNewProductosCosto"
        Me.lbNewProductosCosto.Size = New System.Drawing.Size(34, 16)
        Me.lbNewProductosCosto.TabIndex = 4
        Me.lbNewProductosCosto.Text = "Q0.00"
        '
        'LabelControl174
        '
        Me.LabelControl174.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl174.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal
        Me.LabelControl174.Location = New System.Drawing.Point(11, 39)
        Me.LabelControl174.Name = "LabelControl174"
        Me.LabelControl174.Size = New System.Drawing.Size(48, 16)
        Me.LabelControl174.TabIndex = 5
        Me.LabelControl174.Text = "Código:"
        '
        'cmdNewProductosNuevo
        '
        Me.cmdNewProductosNuevo.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdNewProductosNuevo.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNewProductosNuevo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdNewProductosNuevo.Appearance.Options.UseBackColor = True
        Me.cmdNewProductosNuevo.Appearance.Options.UseFont = True
        Me.cmdNewProductosNuevo.Appearance.Options.UseForeColor = True
        Me.cmdNewProductosNuevo.AppearanceHovered.BackColor = System.Drawing.Color.Linen
        Me.cmdNewProductosNuevo.AppearanceHovered.Options.UseBackColor = True
        Me.cmdNewProductosNuevo.Image = Global.Ares.My.Resources.Resources.bt21
        Me.cmdNewProductosNuevo.Location = New System.Drawing.Point(692, 11)
        Me.cmdNewProductosNuevo.Name = "cmdNewProductosNuevo"
        Me.cmdNewProductosNuevo.Size = New System.Drawing.Size(128, 62)
        Me.cmdNewProductosNuevo.TabIndex = 204
        Me.cmdNewProductosNuevo.Text = "NUEVO"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl3.Location = New System.Drawing.Point(59, 12)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(118, 33)
        Me.LabelControl3.TabIndex = 203
        Me.LabelControl3.Text = "Productos"
        '
        'NP_Detalle
        '
        Me.NP_Detalle.Controls.Add(Me.btnAtras)
        Me.NP_Detalle.Controls.Add(Me.GroupControl6)
        Me.NP_Detalle.Controls.Add(Me.LabelControl49)
        Me.NP_Detalle.Controls.Add(Me.cmdProductoCancelarEdicion)
        Me.NP_Detalle.Controls.Add(Me.cmdProductoGuardar)
        Me.NP_Detalle.Controls.Add(Me.groupproducots)
        Me.NP_Detalle.Controls.Add(Me.imgProductosFotoProducto)
        Me.NP_Detalle.Name = "NP_Detalle"
        Me.NP_Detalle.Size = New System.Drawing.Size(1280, 677)
        '
        'btnAtras
        '
        Me.btnAtras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAtras.Image = CType(resources.GetObject("btnAtras.Image"), System.Drawing.Image)
        Me.btnAtras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAtras.Location = New System.Drawing.Point(29, 14)
        Me.btnAtras.Name = "btnAtras"
        Me.btnAtras.Size = New System.Drawing.Size(64, 42)
        Me.btnAtras.TabIndex = 737
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.LabelControl10)
        Me.GroupControl6.Controls.Add(Me.btnProductoEliminarReceta)
        Me.GroupControl6.Controls.Add(Me.LabelControl9)
        Me.GroupControl6.Controls.Add(Me.btnAgregarReceta)
        Me.GroupControl6.Controls.Add(Me.DgwReceta)
        Me.GroupControl6.Controls.Add(Me.GridProductoPrecios)
        Me.GroupControl6.Controls.Add(Me.cmdProductoAgregarPrecio)
        Me.GroupControl6.Controls.Add(Me.LabelControl180)
        Me.GroupControl6.Controls.Add(Me.txtProductoCostoUnitario)
        Me.GroupControl6.Controls.Add(Me.LabelControl19)
        Me.GroupControl6.Location = New System.Drawing.Point(21, 432)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(1244, 231)
        Me.GroupControl6.TabIndex = 736
        Me.GroupControl6.Text = "Precios del Producto"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(11, 274)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(387, 11)
        Me.LabelControl10.TabIndex = 744
        Me.LabelControl10.Text = "¨Por cada unidad mínima que se genere, se moverán los productos tal cual los haya" &
    " agregado"
        '
        'btnProductoEliminarReceta
        '
        Me.btnProductoEliminarReceta.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnProductoEliminarReceta.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnProductoEliminarReceta.Appearance.Options.UseBackColor = True
        Me.btnProductoEliminarReceta.Appearance.Options.UseForeColor = True
        Me.btnProductoEliminarReceta.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnProductoEliminarReceta.Image = CType(resources.GetObject("btnProductoEliminarReceta.Image"), System.Drawing.Image)
        Me.btnProductoEliminarReceta.Location = New System.Drawing.Point(878, 354)
        Me.btnProductoEliminarReceta.Name = "btnProductoEliminarReceta"
        Me.btnProductoEliminarReceta.Size = New System.Drawing.Size(123, 30)
        Me.btnProductoEliminarReceta.TabIndex = 733
        Me.btnProductoEliminarReceta.Text = "Eliminar Receta"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl9.Location = New System.Drawing.Point(11, 252)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(137, 16)
        Me.LabelControl9.TabIndex = 732
        Me.LabelControl9.Text = "Receta del Producto:"
        '
        'btnAgregarReceta
        '
        Me.btnAgregarReceta.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAgregarReceta.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.btnAgregarReceta.Appearance.Options.UseBackColor = True
        Me.btnAgregarReceta.Appearance.Options.UseForeColor = True
        Me.btnAgregarReceta.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAgregarReceta.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnAgregarReceta.Location = New System.Drawing.Point(876, 291)
        Me.btnAgregarReceta.Name = "btnAgregarReceta"
        Me.btnAgregarReceta.Size = New System.Drawing.Size(125, 50)
        Me.btnAgregarReceta.TabIndex = 731
        Me.btnAgregarReceta.Text = "AGREGAR"
        '
        'DgwReceta
        '
        Me.DgwReceta.AllowUserToAddRows = False
        Me.DgwReceta.AllowUserToDeleteRows = False
        Me.DgwReceta.AutoGenerateColumns = False
        Me.DgwReceta.BackgroundColor = System.Drawing.Color.White
        Me.DgwReceta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DgwReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgwReceta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPRODDataGridViewTextBoxColumn, Me.DESPRODDataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn1, Me.CANTIDADDataGridViewTextBoxColumn, Me.TOTALUNIDADESDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn1, Me.TOTALCOSTODataGridViewTextBoxColumn})
        Me.DgwReceta.DataSource = Me.TblRecetaBindingSource1
        Me.DgwReceta.GridColor = System.Drawing.Color.AliceBlue
        Me.DgwReceta.Location = New System.Drawing.Point(11, 291)
        Me.DgwReceta.MultiSelect = False
        Me.DgwReceta.Name = "DgwReceta"
        Me.DgwReceta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgwReceta.Size = New System.Drawing.Size(859, 93)
        Me.DgwReceta.TabIndex = 730
        '
        'CODPRODDataGridViewTextBoxColumn
        '
        Me.CODPRODDataGridViewTextBoxColumn.DataPropertyName = "CODPROD"
        Me.CODPRODDataGridViewTextBoxColumn.HeaderText = "CODPROD"
        Me.CODPRODDataGridViewTextBoxColumn.Name = "CODPRODDataGridViewTextBoxColumn"
        '
        'DESPRODDataGridViewTextBoxColumn
        '
        Me.DESPRODDataGridViewTextBoxColumn.DataPropertyName = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.HeaderText = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.Name = "DESPRODDataGridViewTextBoxColumn"
        '
        'CODMEDIDADataGridViewTextBoxColumn1
        '
        Me.CODMEDIDADataGridViewTextBoxColumn1.DataPropertyName = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn1.HeaderText = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn1.Name = "CODMEDIDADataGridViewTextBoxColumn1"
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        '
        'TOTALUNIDADESDataGridViewTextBoxColumn
        '
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.DataPropertyName = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.HeaderText = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.Name = "TOTALUNIDADESDataGridViewTextBoxColumn"
        '
        'COSTODataGridViewTextBoxColumn1
        '
        Me.COSTODataGridViewTextBoxColumn1.DataPropertyName = "COSTO"
        Me.COSTODataGridViewTextBoxColumn1.HeaderText = "COSTO"
        Me.COSTODataGridViewTextBoxColumn1.Name = "COSTODataGridViewTextBoxColumn1"
        '
        'TOTALCOSTODataGridViewTextBoxColumn
        '
        Me.TOTALCOSTODataGridViewTextBoxColumn.DataPropertyName = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.HeaderText = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.Name = "TOTALCOSTODataGridViewTextBoxColumn"
        '
        'TblRecetaBindingSource1
        '
        Me.TblRecetaBindingSource1.DataMember = "tblReceta"
        Me.TblRecetaBindingSource1.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'GridProductoPrecios
        '
        Me.GridProductoPrecios.AllowUserToAddRows = False
        Me.GridProductoPrecios.AllowUserToDeleteRows = False
        Me.GridProductoPrecios.AutoGenerateColumns = False
        Me.GridProductoPrecios.BackgroundColor = System.Drawing.Color.White
        Me.GridProductoPrecios.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.GridProductoPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridProductoPrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn, Me.EQUIVALEDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn, Me.PRECIODataGridViewTextBoxColumn, Me.UTILIDADDataGridViewTextBoxColumn, Me.MARGENDataGridViewTextBoxColumn, Me.MAYOREOADataGridViewTextBoxColumn, Me.MAYOREOBDataGridViewTextBoxColumn, Me.MAYOREOCDataGridViewTextBoxColumn, Me.HABILITADODataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn1, Me.MARGENCONFIG})
        Me.GridProductoPrecios.DataSource = Me.TblPreciosBindingSource
        Me.GridProductoPrecios.GridColor = System.Drawing.Color.AliceBlue
        Me.GridProductoPrecios.Location = New System.Drawing.Point(11, 66)
        Me.GridProductoPrecios.MultiSelect = False
        Me.GridProductoPrecios.Name = "GridProductoPrecios"
        Me.GridProductoPrecios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridProductoPrecios.Size = New System.Drawing.Size(920, 150)
        Me.GridProductoPrecios.TabIndex = 719
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'CODMEDIDADataGridViewTextBoxColumn
        '
        Me.CODMEDIDADataGridViewTextBoxColumn.DataPropertyName = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.HeaderText = "MEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.Name = "CODMEDIDADataGridViewTextBoxColumn"
        '
        'EQUIVALEDataGridViewTextBoxColumn
        '
        Me.EQUIVALEDataGridViewTextBoxColumn.DataPropertyName = "EQUIVALE"
        Me.EQUIVALEDataGridViewTextBoxColumn.HeaderText = "EQV"
        Me.EQUIVALEDataGridViewTextBoxColumn.Name = "EQUIVALEDataGridViewTextBoxColumn"
        Me.EQUIVALEDataGridViewTextBoxColumn.Width = 50
        '
        'COSTODataGridViewTextBoxColumn
        '
        Me.COSTODataGridViewTextBoxColumn.DataPropertyName = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.HeaderText = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.Name = "COSTODataGridViewTextBoxColumn"
        '
        'PRECIODataGridViewTextBoxColumn
        '
        Me.PRECIODataGridViewTextBoxColumn.DataPropertyName = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn.HeaderText = "CATALOGO A"
        Me.PRECIODataGridViewTextBoxColumn.Name = "PRECIODataGridViewTextBoxColumn"
        '
        'UTILIDADDataGridViewTextBoxColumn
        '
        Me.UTILIDADDataGridViewTextBoxColumn.DataPropertyName = "UTILIDAD"
        Me.UTILIDADDataGridViewTextBoxColumn.HeaderText = "UTILIDAD"
        Me.UTILIDADDataGridViewTextBoxColumn.Name = "UTILIDADDataGridViewTextBoxColumn"
        Me.UTILIDADDataGridViewTextBoxColumn.Visible = False
        '
        'MARGENDataGridViewTextBoxColumn
        '
        Me.MARGENDataGridViewTextBoxColumn.DataPropertyName = "MARGEN"
        Me.MARGENDataGridViewTextBoxColumn.HeaderText = "MARGEN"
        Me.MARGENDataGridViewTextBoxColumn.Name = "MARGENDataGridViewTextBoxColumn"
        Me.MARGENDataGridViewTextBoxColumn.Visible = False
        '
        'MAYOREOADataGridViewTextBoxColumn
        '
        Me.MAYOREOADataGridViewTextBoxColumn.DataPropertyName = "MAYOREOA"
        Me.MAYOREOADataGridViewTextBoxColumn.HeaderText = "CATALOGO B"
        Me.MAYOREOADataGridViewTextBoxColumn.Name = "MAYOREOADataGridViewTextBoxColumn"
        '
        'MAYOREOBDataGridViewTextBoxColumn
        '
        Me.MAYOREOBDataGridViewTextBoxColumn.DataPropertyName = "MAYOREOB"
        Me.MAYOREOBDataGridViewTextBoxColumn.HeaderText = "CATALOGO C"
        Me.MAYOREOBDataGridViewTextBoxColumn.Name = "MAYOREOBDataGridViewTextBoxColumn"
        '
        'MAYOREOCDataGridViewTextBoxColumn
        '
        Me.MAYOREOCDataGridViewTextBoxColumn.DataPropertyName = "MAYOREOC"
        Me.MAYOREOCDataGridViewTextBoxColumn.HeaderText = "CATALOGO D"
        Me.MAYOREOCDataGridViewTextBoxColumn.Name = "MAYOREOCDataGridViewTextBoxColumn"
        '
        'HABILITADODataGridViewTextBoxColumn
        '
        Me.HABILITADODataGridViewTextBoxColumn.DataPropertyName = "HABILITADO"
        Me.HABILITADODataGridViewTextBoxColumn.HeaderText = "Hb"
        Me.HABILITADODataGridViewTextBoxColumn.Name = "HABILITADODataGridViewTextBoxColumn"
        Me.HABILITADODataGridViewTextBoxColumn.Width = 25
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "BONO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "BONO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'MARGENCONFIG
        '
        Me.MARGENCONFIG.HeaderText = "CONFIG%"
        Me.MARGENCONFIG.Name = "MARGENCONFIG"
        '
        'cmdProductoAgregarPrecio
        '
        Me.cmdProductoAgregarPrecio.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdProductoAgregarPrecio.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cmdProductoAgregarPrecio.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.cmdProductoAgregarPrecio.Appearance.Options.UseBackColor = True
        Me.cmdProductoAgregarPrecio.Appearance.Options.UseFont = True
        Me.cmdProductoAgregarPrecio.Appearance.Options.UseForeColor = True
        Me.cmdProductoAgregarPrecio.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdProductoAgregarPrecio.Image = CType(resources.GetObject("cmdProductoAgregarPrecio.Image"), System.Drawing.Image)
        Me.cmdProductoAgregarPrecio.Location = New System.Drawing.Point(256, 26)
        Me.cmdProductoAgregarPrecio.Name = "cmdProductoAgregarPrecio"
        Me.cmdProductoAgregarPrecio.Size = New System.Drawing.Size(102, 36)
        Me.cmdProductoAgregarPrecio.TabIndex = 718
        Me.cmdProductoAgregarPrecio.Text = "AGREGAR"
        '
        'LabelControl180
        '
        Me.LabelControl180.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl180.Location = New System.Drawing.Point(21, 33)
        Me.LabelControl180.Name = "LabelControl180"
        Me.LabelControl180.Size = New System.Drawing.Size(95, 18)
        Me.LabelControl180.TabIndex = 727
        Me.LabelControl180.Text = "Costo Unitario:"
        '
        'txtProductoCostoUnitario
        '
        Me.txtProductoCostoUnitario.Location = New System.Drawing.Point(147, 30)
        Me.txtProductoCostoUnitario.Name = "txtProductoCostoUnitario"
        Me.txtProductoCostoUnitario.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProductoCostoUnitario.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoCostoUnitario.Properties.Appearance.Options.UseBackColor = True
        Me.txtProductoCostoUnitario.Properties.Appearance.Options.UseFont = True
        Me.txtProductoCostoUnitario.Properties.Mask.EditMask = "n3"
        Me.txtProductoCostoUnitario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtProductoCostoUnitario.Size = New System.Drawing.Size(95, 30)
        Me.txtProductoCostoUnitario.TabIndex = 729
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Location = New System.Drawing.Point(126, 32)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(15, 23)
        Me.LabelControl19.TabIndex = 728
        Me.LabelControl19.Text = "Q"
        '
        'LabelControl49
        '
        Me.LabelControl49.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl49.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl49.Location = New System.Drawing.Point(101, 17)
        Me.LabelControl49.Name = "LabelControl49"
        Me.LabelControl49.Size = New System.Drawing.Size(118, 33)
        Me.LabelControl49.TabIndex = 734
        Me.LabelControl49.Text = "Productos"
        '
        'cmdProductoCancelarEdicion
        '
        Me.cmdProductoCancelarEdicion.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdProductoCancelarEdicion.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProductoCancelarEdicion.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdProductoCancelarEdicion.Appearance.Options.UseBackColor = True
        Me.cmdProductoCancelarEdicion.Appearance.Options.UseFont = True
        Me.cmdProductoCancelarEdicion.Appearance.Options.UseForeColor = True
        Me.cmdProductoCancelarEdicion.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdProductoCancelarEdicion.AppearanceHovered.Options.UseBackColor = True
        Me.cmdProductoCancelarEdicion.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdProductoCancelarEdicion.Image = Global.Ares.My.Resources.Resources.bt20
        Me.cmdProductoCancelarEdicion.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdProductoCancelarEdicion.Location = New System.Drawing.Point(667, 11)
        Me.cmdProductoCancelarEdicion.Name = "cmdProductoCancelarEdicion"
        Me.cmdProductoCancelarEdicion.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdProductoCancelarEdicion.Size = New System.Drawing.Size(164, 57)
        Me.cmdProductoCancelarEdicion.TabIndex = 733
        Me.cmdProductoCancelarEdicion.Text = "CANCELAR" & Global.Microsoft.VisualBasic.ChrW(13) & " (F2)"
        Me.cmdProductoCancelarEdicion.Visible = False
        '
        'cmdProductoGuardar
        '
        Me.cmdProductoGuardar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdProductoGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProductoGuardar.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdProductoGuardar.Appearance.Options.UseBackColor = True
        Me.cmdProductoGuardar.Appearance.Options.UseFont = True
        Me.cmdProductoGuardar.Appearance.Options.UseForeColor = True
        Me.cmdProductoGuardar.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdProductoGuardar.AppearanceHovered.Options.UseBackColor = True
        Me.cmdProductoGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdProductoGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.cmdProductoGuardar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdProductoGuardar.Location = New System.Drawing.Point(881, 11)
        Me.cmdProductoGuardar.Name = "cmdProductoGuardar"
        Me.cmdProductoGuardar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdProductoGuardar.Size = New System.Drawing.Size(164, 57)
        Me.cmdProductoGuardar.TabIndex = 732
        Me.cmdProductoGuardar.Text = "GUARDAR"
        '
        'groupproducots
        '
        Me.groupproducots.Controls.Add(Me.TextBON)
        Me.groupproducots.Controls.Add(Me.LabelControl12)
        Me.groupproducots.Controls.Add(Me.LbProductosDesc3)
        Me.groupproducots.Controls.Add(Me.txtProductoDescripcion3)
        Me.groupproducots.Controls.Add(Me.LbProductosDesc2)
        Me.groupproducots.Controls.Add(Me.txtProductoDescripcion2)
        Me.groupproducots.Controls.Add(Me.LabelControl18)
        Me.groupproducots.Controls.Add(Me.txtProductoDescripcion)
        Me.groupproducots.Controls.Add(Me.LabelControl16)
        Me.groupproducots.Controls.Add(Me.txtProductoCodigo2)
        Me.groupproducots.Controls.Add(Me.LabelControl15)
        Me.groupproducots.Controls.Add(Me.txtProductoCodigo)
        Me.groupproducots.Controls.Add(Me.cmbColor)
        Me.groupproducots.Controls.Add(Me.FlyoutPanelSeries)
        Me.groupproducots.Controls.Add(Me.LabelControl8)
        Me.groupproducots.Controls.Add(Me.cmbTipoProd)
        Me.groupproducots.Controls.Add(Me.LabelControl7)
        Me.groupproducots.Controls.Add(Me.SwitchExento)
        Me.groupproducots.Controls.Add(Me.LabelControl6)
        Me.groupproducots.Controls.Add(Me.txtProductoInvMinimo)
        Me.groupproducots.Controls.Add(Me.LabelControl1)
        Me.groupproducots.Controls.Add(Me.btnSeries)
        Me.groupproducots.Controls.Add(Me.SwitchSeries)
        Me.groupproducots.Controls.Add(Me.lbProductoSerie)
        Me.groupproducots.Controls.Add(Me.txtProductoFechaVence)
        Me.groupproducots.Controls.Add(Me.LabelControl50)
        Me.groupproducots.Controls.Add(Me.LabelControl32)
        Me.groupproducots.Controls.Add(Me.txtProductosUxc)
        Me.groupproducots.Controls.Add(Me.cmdProductosQuitarFoto)
        Me.groupproducots.Controls.Add(Me.txtProductosRutaFoto)
        Me.groupproducots.Controls.Add(Me.cmdProductoTomarFoto)
        Me.groupproducots.Controls.Add(Me.cmdProductoBuscarFoto)
        Me.groupproducots.Controls.Add(Me.LabelControl30)
        Me.groupproducots.Controls.Add(Me.cmbProductoClaseTres)
        Me.groupproducots.Controls.Add(Me.LabelControl29)
        Me.groupproducots.Controls.Add(Me.cmbProductoClaseDos)
        Me.groupproducots.Controls.Add(Me.LabelControl28)
        Me.groupproducots.Controls.Add(Me.cmbProductoClaseUno)
        Me.groupproducots.Controls.Add(Me.LabelControl27)
        Me.groupproducots.Controls.Add(Me.cmbProductoMarca)
        Me.groupproducots.Location = New System.Drawing.Point(21, 74)
        Me.groupproducots.Name = "groupproducots"
        Me.groupproducots.Size = New System.Drawing.Size(1244, 352)
        Me.groupproducots.TabIndex = 731
        Me.groupproducots.Text = "Datos del Nuevo Producto"
        '
        'TextBON
        '
        Me.TextBON.AllowHtmlTextInToolTip = DevExpress.Utils.DefaultBoolean.[True]
        Me.TextBON.Location = New System.Drawing.Point(620, 187)
        Me.TextBON.MenuManager = Me.BarManager1
        Me.TextBON.Name = "TextBON"
        Me.TextBON.Properties.Mask.EditMask = "n2"
        Me.TextBON.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.TextBON.Size = New System.Drawing.Size(99, 20)
        Me.TextBON.TabIndex = 746
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(573, 188)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(38, 18)
        Me.LabelControl12.TabIndex = 745
        Me.LabelControl12.Text = "Bono:"
        '
        'LbProductosDesc3
        '
        Me.LbProductosDesc3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbProductosDesc3.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LbProductosDesc3.Location = New System.Drawing.Point(11, 160)
        Me.LbProductosDesc3.Name = "LbProductosDesc3"
        Me.LbProductosDesc3.Size = New System.Drawing.Size(70, 18)
        Me.LbProductosDesc3.TabIndex = 9
        Me.LbProductosDesc3.Text = "Uso/Dosis:"
        '
        'txtProductoDescripcion3
        '
        Me.txtProductoDescripcion3.Enabled = False
        Me.txtProductoDescripcion3.Location = New System.Drawing.Point(124, 157)
        Me.txtProductoDescripcion3.Name = "txtProductoDescripcion3"
        Me.txtProductoDescripcion3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDescripcion3.Properties.Appearance.Options.UseFont = True
        Me.txtProductoDescripcion3.Size = New System.Drawing.Size(877, 24)
        Me.txtProductoDescripcion3.TabIndex = 704
        '
        'LbProductosDesc2
        '
        Me.LbProductosDesc2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbProductosDesc2.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LbProductosDesc2.Location = New System.Drawing.Point(11, 129)
        Me.LbProductosDesc2.Name = "LbProductosDesc2"
        Me.LbProductosDesc2.Size = New System.Drawing.Size(88, 18)
        Me.LbProductosDesc2.TabIndex = 7
        Me.LbProductosDesc2.Text = "Componente:"
        '
        'txtProductoDescripcion2
        '
        Me.txtProductoDescripcion2.Enabled = False
        Me.txtProductoDescripcion2.Location = New System.Drawing.Point(124, 127)
        Me.txtProductoDescripcion2.Name = "txtProductoDescripcion2"
        Me.txtProductoDescripcion2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDescripcion2.Properties.Appearance.Options.UseFont = True
        Me.txtProductoDescripcion2.Size = New System.Drawing.Size(877, 24)
        Me.txtProductoDescripcion2.TabIndex = 703
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl18.Location = New System.Drawing.Point(11, 100)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(77, 18)
        Me.LabelControl18.TabIndex = 5
        Me.LabelControl18.Text = "Descripción:"
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.Enabled = False
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(124, 97)
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDescripcion.Properties.Appearance.Options.UseFont = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(877, 24)
        Me.txtProductoDescripcion.TabIndex = 702
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl16.Location = New System.Drawing.Point(11, 69)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(98, 18)
        Me.LabelControl16.TabIndex = 3
        Me.LabelControl16.Text = "Código Alterno:"
        '
        'txtProductoCodigo2
        '
        Me.txtProductoCodigo2.Enabled = False
        Me.txtProductoCodigo2.Location = New System.Drawing.Point(124, 67)
        Me.txtProductoCodigo2.Name = "txtProductoCodigo2"
        Me.txtProductoCodigo2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoCodigo2.Properties.Appearance.Options.UseFont = True
        Me.txtProductoCodigo2.Size = New System.Drawing.Size(368, 24)
        Me.txtProductoCodigo2.TabIndex = 701
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl15.Location = New System.Drawing.Point(11, 40)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(48, 18)
        Me.LabelControl15.TabIndex = 1
        Me.LabelControl15.Text = "Código:"
        '
        'txtProductoCodigo
        '
        Me.txtProductoCodigo.Enabled = False
        Me.txtProductoCodigo.Location = New System.Drawing.Point(124, 37)
        Me.txtProductoCodigo.Name = "txtProductoCodigo"
        Me.txtProductoCodigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoCodigo.Properties.Appearance.Options.UseFont = True
        Me.txtProductoCodigo.Size = New System.Drawing.Size(368, 24)
        Me.txtProductoCodigo.TabIndex = 700
        '
        'cmbColor
        '
        Me.cmbColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbColor.Enabled = False
        Me.cmbColor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(671, 261)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(124, 21)
        Me.cmbColor.TabIndex = 744
        '
        'FlyoutPanelSeries
        '
        Me.FlyoutPanelSeries.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelSeries.Location = New System.Drawing.Point(553, 595)
        Me.FlyoutPanelSeries.Name = "FlyoutPanelSeries"
        Me.FlyoutPanelSeries.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutPanelSeries.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Right
        Me.FlyoutPanelSeries.OptionsBeakPanel.CloseOnOuterClick = False
        Me.FlyoutPanelSeries.OwnerControl = Me
        Me.FlyoutPanelSeries.Size = New System.Drawing.Size(388, 674)
        Me.FlyoutPanelSeries.TabIndex = 738
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.btnSerieCerrarPanel)
        Me.FlyoutPanelControl1.Controls.Add(Me.dgvSeries)
        Me.FlyoutPanelControl1.Controls.Add(Me.btnSerieCancelar)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl5)
        Me.FlyoutPanelControl1.Controls.Add(Me.btnEliminarTodos)
        Me.FlyoutPanelControl1.Controls.Add(Me.btnSerieGuardar)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl4)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtSerieColor)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl2)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtSerieNoSerie)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelSeries
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(388, 674)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'btnSerieCerrarPanel
        '
        Me.btnSerieCerrarPanel.Location = New System.Drawing.Point(8, 6)
        Me.btnSerieCerrarPanel.Name = "btnSerieCerrarPanel"
        Me.btnSerieCerrarPanel.Size = New System.Drawing.Size(36, 22)
        Me.btnSerieCerrarPanel.TabIndex = 32
        Me.btnSerieCerrarPanel.Text = "x"
        '
        'dgvSeries
        '
        Me.dgvSeries.DataSource = Me.TblSeriesBindingSource1
        Me.dgvSeries.Location = New System.Drawing.Point(8, 165)
        Me.dgvSeries.MainView = Me.GridViewSeries
        Me.dgvSeries.MenuManager = Me.BarManager1
        Me.dgvSeries.Name = "dgvSeries"
        Me.dgvSeries.Size = New System.Drawing.Size(373, 468)
        Me.dgvSeries.TabIndex = 31
        Me.dgvSeries.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSeries})
        '
        'TblSeriesBindingSource1
        '
        Me.TblSeriesBindingSource1.DataMember = "tblSeries"
        Me.TblSeriesBindingSource1.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'GridViewSeries
        '
        Me.GridViewSeries.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colNOSERIE, Me.colCOLOR})
        Me.GridViewSeries.GridControl = Me.dgvSeries
        Me.GridViewSeries.Name = "GridViewSeries"
        Me.GridViewSeries.OptionsBehavior.Editable = False
        Me.GridViewSeries.OptionsFind.AlwaysVisible = True
        Me.GridViewSeries.OptionsFind.FindNullPrompt = "Escriba para buscar..."
        Me.GridViewSeries.OptionsFind.ShowClearButton = False
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colNOSERIE
        '
        Me.colNOSERIE.Caption = "No Serie"
        Me.colNOSERIE.FieldName = "NOSERIE"
        Me.colNOSERIE.Name = "colNOSERIE"
        Me.colNOSERIE.Visible = True
        Me.colNOSERIE.VisibleIndex = 0
        '
        'colCOLOR
        '
        Me.colCOLOR.Caption = "Color"
        Me.colCOLOR.FieldName = "COLOR"
        Me.colCOLOR.Name = "colCOLOR"
        Me.colCOLOR.Visible = True
        Me.colCOLOR.VisibleIndex = 1
        '
        'btnSerieCancelar
        '
        Me.btnSerieCancelar.Image = CType(resources.GetObject("btnSerieCancelar.Image"), System.Drawing.Image)
        Me.btnSerieCancelar.Location = New System.Drawing.Point(120, 112)
        Me.btnSerieCancelar.Name = "btnSerieCancelar"
        Me.btnSerieCancelar.Size = New System.Drawing.Size(106, 35)
        Me.btnSerieCancelar.TabIndex = 30
        Me.btnSerieCancelar.Text = "Cancelar"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(94, 12)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(213, 16)
        Me.LabelControl5.TabIndex = 29
        Me.LabelControl5.Text = "Agregar Nuevo Número de Serie:"
        '
        'btnEliminarTodos
        '
        Me.btnEliminarTodos.Image = CType(resources.GetObject("btnEliminarTodos.Image"), System.Drawing.Image)
        Me.btnEliminarTodos.Location = New System.Drawing.Point(267, 639)
        Me.btnEliminarTodos.Name = "btnEliminarTodos"
        Me.btnEliminarTodos.Size = New System.Drawing.Size(111, 30)
        Me.btnEliminarTodos.TabIndex = 27
        Me.btnEliminarTodos.Text = "Eliminar Todos"
        '
        'btnSerieGuardar
        '
        Me.btnSerieGuardar.Image = CType(resources.GetObject("btnSerieGuardar.Image"), System.Drawing.Image)
        Me.btnSerieGuardar.Location = New System.Drawing.Point(254, 112)
        Me.btnSerieGuardar.Name = "btnSerieGuardar"
        Me.btnSerieGuardar.Size = New System.Drawing.Size(106, 35)
        Me.btnSerieGuardar.TabIndex = 26
        Me.btnSerieGuardar.Text = "Guardar"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(32, 78)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(35, 16)
        Me.LabelControl4.TabIndex = 25
        Me.LabelControl4.Text = "Color:"
        '
        'txtSerieColor
        '
        Me.txtSerieColor.EnterMoveNextControl = True
        Me.txtSerieColor.Location = New System.Drawing.Point(100, 77)
        Me.txtSerieColor.MenuManager = Me.BarManager1
        Me.txtSerieColor.Name = "txtSerieColor"
        Me.txtSerieColor.Size = New System.Drawing.Size(260, 20)
        Me.txtSerieColor.TabIndex = 24
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(32, 47)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(54, 16)
        Me.LabelControl2.TabIndex = 23
        Me.LabelControl2.Text = "No Serie:"
        '
        'txtSerieNoSerie
        '
        Me.txtSerieNoSerie.EnterMoveNextControl = True
        Me.txtSerieNoSerie.Location = New System.Drawing.Point(100, 46)
        Me.txtSerieNoSerie.MenuManager = Me.BarManager1
        Me.txtSerieNoSerie.Name = "txtSerieNoSerie"
        Me.txtSerieNoSerie.Size = New System.Drawing.Size(260, 20)
        Me.txtSerieNoSerie.TabIndex = 0
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(808, 264)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(32, 14)
        Me.LabelControl8.TabIndex = 743
        Me.LabelControl8.Text = "TIPO:"
        '
        'cmbTipoProd
        '
        Me.cmbTipoProd.Enabled = False
        Me.cmbTipoProd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoProd.FormattingEnabled = True
        Me.cmbTipoProd.Location = New System.Drawing.Point(846, 262)
        Me.cmbTipoProd.Name = "cmbTipoProd"
        Me.cmbTipoProd.Size = New System.Drawing.Size(124, 21)
        Me.cmbTipoProd.TabIndex = 742
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(585, 262)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(80, 14)
        Me.LabelControl7.TabIndex = 740
        Me.LabelControl7.Text = "TIPO ALERTA:"
        '
        'SwitchExento
        '
        Me.SwitchExento.Location = New System.Drawing.Point(816, 187)
        Me.SwitchExento.MenuManager = Me.BarManager1
        Me.SwitchExento.Name = "SwitchExento"
        Me.SwitchExento.Properties.OffText = "NO"
        Me.SwitchExento.Properties.OnText = "SI"
        Me.SwitchExento.Size = New System.Drawing.Size(99, 24)
        Me.SwitchExento.TabIndex = 739
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(725, 191)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(85, 14)
        Me.LabelControl6.TabIndex = 738
        Me.LabelControl6.Text = "Exento de IVA:"
        '
        'txtProductoInvMinimo
        '
        Me.txtProductoInvMinimo.Location = New System.Drawing.Point(443, 188)
        Me.txtProductoInvMinimo.MenuManager = Me.BarManager1
        Me.txtProductoInvMinimo.Name = "txtProductoInvMinimo"
        Me.txtProductoInvMinimo.Properties.Mask.EditMask = "n"
        Me.txtProductoInvMinimo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtProductoInvMinimo.Size = New System.Drawing.Size(124, 20)
        Me.txtProductoInvMinimo.TabIndex = 737
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(328, 191)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(108, 16)
        Me.LabelControl1.TabIndex = 736
        Me.LabelControl1.Text = "Inventario mínimo:"
        '
        'btnSeries
        '
        Me.btnSeries.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeries.Appearance.Options.UseFont = True
        Me.btnSeries.Image = CType(resources.GetObject("btnSeries.Image"), System.Drawing.Image)
        Me.btnSeries.Location = New System.Drawing.Point(949, 324)
        Me.btnSeries.Name = "btnSeries"
        Me.btnSeries.Size = New System.Drawing.Size(59, 23)
        Me.btnSeries.TabIndex = 735
        Me.btnSeries.Text = "Editar"
        Me.btnSeries.Visible = False
        '
        'SwitchSeries
        '
        Me.SwitchSeries.Location = New System.Drawing.Point(132, 377)
        Me.SwitchSeries.MenuManager = Me.BarManager1
        Me.SwitchSeries.Name = "SwitchSeries"
        Me.SwitchSeries.Properties.OffText = "NO"
        Me.SwitchSeries.Properties.OnText = "SI"
        Me.SwitchSeries.Size = New System.Drawing.Size(99, 24)
        Me.SwitchSeries.TabIndex = 734
        Me.SwitchSeries.Visible = False
        '
        'lbProductoSerie
        '
        Me.lbProductoSerie.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbProductoSerie.Location = New System.Drawing.Point(34, 381)
        Me.lbProductoSerie.Name = "lbProductoSerie"
        Me.lbProductoSerie.Size = New System.Drawing.Size(92, 14)
        Me.lbProductoSerie.TabIndex = 733
        Me.lbProductoSerie.Text = "Utiliza No. Serie :"
        Me.lbProductoSerie.Visible = False
        '
        'txtProductoFechaVence
        '
        Me.txtProductoFechaVence.EditValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txtProductoFechaVence.EnterMoveNextControl = True
        Me.txtProductoFechaVence.Location = New System.Drawing.Point(808, 289)
        Me.txtProductoFechaVence.Name = "txtProductoFechaVence"
        Me.txtProductoFechaVence.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoFechaVence.Properties.Appearance.Options.UseFont = True
        Me.txtProductoFechaVence.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtProductoFechaVence.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtProductoFechaVence.Size = New System.Drawing.Size(99, 22)
        Me.txtProductoFechaVence.TabIndex = 732
        '
        'LabelControl50
        '
        Me.LabelControl50.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl50.Location = New System.Drawing.Point(672, 291)
        Me.LabelControl50.Name = "LabelControl50"
        Me.LabelControl50.Size = New System.Drawing.Size(127, 18)
        Me.LabelControl50.TabIndex = 731
        Me.LabelControl50.Text = "Fecha Vencimiento:"
        '
        'LabelControl32
        '
        Me.LabelControl32.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl32.Location = New System.Drawing.Point(34, 190)
        Me.LabelControl32.Name = "LabelControl32"
        Me.LabelControl32.Size = New System.Drawing.Size(168, 18)
        Me.LabelControl32.TabIndex = 730
        Me.LabelControl32.Text = "Unidades por Caja (UxC):"
        '
        'txtProductosUxc
        '
        Me.txtProductosUxc.Location = New System.Drawing.Point(214, 187)
        Me.txtProductosUxc.Name = "txtProductosUxc"
        Me.txtProductosUxc.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
        Me.txtProductosUxc.Properties.Appearance.Options.UseFont = True
        Me.txtProductosUxc.Properties.Mask.EditMask = "n0"
        Me.txtProductosUxc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtProductosUxc.Size = New System.Drawing.Size(110, 24)
        Me.txtProductosUxc.TabIndex = 705
        '
        'cmdProductosQuitarFoto
        '
        Me.cmdProductosQuitarFoto.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdProductosQuitarFoto.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProductosQuitarFoto.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdProductosQuitarFoto.Appearance.Options.UseBackColor = True
        Me.cmdProductosQuitarFoto.Appearance.Options.UseFont = True
        Me.cmdProductosQuitarFoto.Appearance.Options.UseForeColor = True
        Me.cmdProductosQuitarFoto.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdProductosQuitarFoto.Image = CType(resources.GetObject("cmdProductosQuitarFoto.Image"), System.Drawing.Image)
        Me.cmdProductosQuitarFoto.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdProductosQuitarFoto.Location = New System.Drawing.Point(139, 35)
        Me.cmdProductosQuitarFoto.Name = "cmdProductosQuitarFoto"
        Me.cmdProductosQuitarFoto.Size = New System.Drawing.Size(29, 26)
        Me.cmdProductosQuitarFoto.TabIndex = 726
        Me.cmdProductosQuitarFoto.Visible = False
        '
        'txtProductosRutaFoto
        '
        Me.txtProductosRutaFoto.Enabled = False
        Me.txtProductosRutaFoto.Location = New System.Drawing.Point(108, 373)
        Me.txtProductosRutaFoto.Name = "txtProductosRutaFoto"
        Me.txtProductosRutaFoto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductosRutaFoto.Properties.Appearance.Options.UseFont = True
        Me.txtProductosRutaFoto.Size = New System.Drawing.Size(31, 24)
        Me.txtProductosRutaFoto.TabIndex = 725
        Me.txtProductosRutaFoto.Visible = False
        '
        'cmdProductoTomarFoto
        '
        Me.cmdProductoTomarFoto.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdProductoTomarFoto.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProductoTomarFoto.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdProductoTomarFoto.Appearance.Options.UseBackColor = True
        Me.cmdProductoTomarFoto.Appearance.Options.UseFont = True
        Me.cmdProductoTomarFoto.Appearance.Options.UseForeColor = True
        Me.cmdProductoTomarFoto.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdProductoTomarFoto.Image = CType(resources.GetObject("cmdProductoTomarFoto.Image"), System.Drawing.Image)
        Me.cmdProductoTomarFoto.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdProductoTomarFoto.Location = New System.Drawing.Point(208, 33)
        Me.cmdProductoTomarFoto.Name = "cmdProductoTomarFoto"
        Me.cmdProductoTomarFoto.Size = New System.Drawing.Size(28, 27)
        Me.cmdProductoTomarFoto.TabIndex = 716
        Me.cmdProductoTomarFoto.Visible = False
        '
        'cmdProductoBuscarFoto
        '
        Me.cmdProductoBuscarFoto.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdProductoBuscarFoto.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdProductoBuscarFoto.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdProductoBuscarFoto.Appearance.Options.UseBackColor = True
        Me.cmdProductoBuscarFoto.Appearance.Options.UseFont = True
        Me.cmdProductoBuscarFoto.Appearance.Options.UseForeColor = True
        Me.cmdProductoBuscarFoto.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdProductoBuscarFoto.Image = CType(resources.GetObject("cmdProductoBuscarFoto.Image"), System.Drawing.Image)
        Me.cmdProductoBuscarFoto.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdProductoBuscarFoto.Location = New System.Drawing.Point(174, 34)
        Me.cmdProductoBuscarFoto.Name = "cmdProductoBuscarFoto"
        Me.cmdProductoBuscarFoto.Size = New System.Drawing.Size(28, 27)
        Me.cmdProductoBuscarFoto.TabIndex = 715
        Me.cmdProductoBuscarFoto.Visible = False
        '
        'LabelControl30
        '
        Me.LabelControl30.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl30.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl30.Location = New System.Drawing.Point(16, 310)
        Me.LabelControl30.Name = "LabelControl30"
        Me.LabelControl30.Size = New System.Drawing.Size(100, 16)
        Me.LabelControl30.TabIndex = 28
        Me.LabelControl30.Text = "Clasificación Dos:"
        '
        'cmbProductoClaseTres
        '
        Me.cmbProductoClaseTres.Enabled = False
        Me.cmbProductoClaseTres.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbProductoClaseTres.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProductoClaseTres.FormattingEnabled = True
        Me.cmbProductoClaseTres.Location = New System.Drawing.Point(124, 307)
        Me.cmbProductoClaseTres.Name = "cmbProductoClaseTres"
        Me.cmbProductoClaseTres.Size = New System.Drawing.Size(368, 24)
        Me.cmbProductoClaseTres.TabIndex = 712
        '
        'LabelControl29
        '
        Me.LabelControl29.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl29.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl29.Location = New System.Drawing.Point(18, 282)
        Me.LabelControl29.Name = "LabelControl29"
        Me.LabelControl29.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl29.TabIndex = 26
        Me.LabelControl29.Text = "Proveedor:"
        '
        'cmbProductoClaseDos
        '
        Me.cmbProductoClaseDos.Enabled = False
        Me.cmbProductoClaseDos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbProductoClaseDos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProductoClaseDos.FormattingEnabled = True
        Me.cmbProductoClaseDos.Location = New System.Drawing.Point(124, 277)
        Me.cmbProductoClaseDos.Name = "cmbProductoClaseDos"
        Me.cmbProductoClaseDos.Size = New System.Drawing.Size(368, 24)
        Me.cmbProductoClaseDos.TabIndex = 711
        '
        'LabelControl28
        '
        Me.LabelControl28.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl28.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl28.Location = New System.Drawing.Point(18, 250)
        Me.LabelControl28.Name = "LabelControl28"
        Me.LabelControl28.Size = New System.Drawing.Size(30, 16)
        Me.LabelControl28.TabIndex = 24
        Me.LabelControl28.Text = "Tipo:"
        '
        'cmbProductoClaseUno
        '
        Me.cmbProductoClaseUno.Enabled = False
        Me.cmbProductoClaseUno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbProductoClaseUno.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProductoClaseUno.FormattingEnabled = True
        Me.cmbProductoClaseUno.Location = New System.Drawing.Point(124, 247)
        Me.cmbProductoClaseUno.Name = "cmbProductoClaseUno"
        Me.cmbProductoClaseUno.Size = New System.Drawing.Size(368, 24)
        Me.cmbProductoClaseUno.TabIndex = 710
        '
        'LabelControl27
        '
        Me.LabelControl27.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl27.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl27.Location = New System.Drawing.Point(18, 220)
        Me.LabelControl27.Name = "LabelControl27"
        Me.LabelControl27.Size = New System.Drawing.Size(40, 16)
        Me.LabelControl27.TabIndex = 22
        Me.LabelControl27.Text = "Marca:"
        '
        'cmbProductoMarca
        '
        Me.cmbProductoMarca.Enabled = False
        Me.cmbProductoMarca.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbProductoMarca.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProductoMarca.FormattingEnabled = True
        Me.cmbProductoMarca.Location = New System.Drawing.Point(124, 217)
        Me.cmbProductoMarca.Name = "cmbProductoMarca"
        Me.cmbProductoMarca.Size = New System.Drawing.Size(368, 24)
        Me.cmbProductoMarca.TabIndex = 709
        '
        'imgProductosFotoProducto
        '
        Me.imgProductosFotoProducto.EditValue = Global.Ares.My.Resources.Resources._11_percent
        Me.imgProductosFotoProducto.Location = New System.Drawing.Point(28, 96)
        Me.imgProductosFotoProducto.Name = "imgProductosFotoProducto"
        Me.imgProductosFotoProducto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.imgProductosFotoProducto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.imgProductosFotoProducto.Properties.ZoomAccelerationFactor = 1.0R
        Me.imgProductosFotoProducto.Size = New System.Drawing.Size(126, 27)
        Me.imgProductosFotoProducto.TabIndex = 735
        Me.imgProductosFotoProducto.Visible = False
        '
        'NP_SyncProductos
        '
        Me.NP_SyncProductos.Controls.Add(Me.GroupControl3)
        Me.NP_SyncProductos.Name = "NP_SyncProductos"
        Me.NP_SyncProductos.Size = New System.Drawing.Size(1280, 677)
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.GridDetallesProductos)
        Me.GroupControl3.Location = New System.Drawing.Point(18, 152)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(1019, 517)
        Me.GroupControl3.TabIndex = 0
        Me.GroupControl3.Text = "Datos adicionales de productos a sincronizar"
        '
        'GridDetallesProductos
        '
        Me.GridDetallesProductos.DataSource = Me.TblDatosAdicionalesProductosBindingSource
        Me.GridDetallesProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDetallesProductos.Location = New System.Drawing.Point(2, 20)
        Me.GridDetallesProductos.MainView = Me.GridViewDetallesProductos
        Me.GridDetallesProductos.MenuManager = Me.BarManager1
        Me.GridDetallesProductos.Name = "GridDetallesProductos"
        Me.GridDetallesProductos.Size = New System.Drawing.Size(1015, 495)
        Me.GridDetallesProductos.TabIndex = 0
        Me.GridDetallesProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetallesProductos})
        '
        'TblDatosAdicionalesProductosBindingSource
        '
        Me.TblDatosAdicionalesProductosBindingSource.DataMember = "tblDatosAdicionalesProductos"
        Me.TblDatosAdicionalesProductosBindingSource.DataSource = Me.DSSync
        '
        'DSSync
        '
        Me.DSSync.DataSetName = "DSSync"
        Me.DSSync.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewDetallesProductos
        '
        Me.GridViewDetallesProductos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEMPNIT, Me.colEMPNOMBRE, Me.colCODPROD1, Me.colDESPROD1, Me.colINVMINIMO, Me.colINVMAXIMO, Me.colHABILITADO})
        Me.GridViewDetallesProductos.GridControl = Me.GridDetallesProductos
        Me.GridViewDetallesProductos.Name = "GridViewDetallesProductos"
        Me.GridViewDetallesProductos.OptionsBehavior.Editable = False
        Me.GridViewDetallesProductos.OptionsView.ShowAutoFilterRow = True
        '
        'colEMPNIT
        '
        Me.colEMPNIT.FieldName = "EMPNIT"
        Me.colEMPNIT.Name = "colEMPNIT"
        Me.colEMPNIT.Visible = True
        Me.colEMPNIT.VisibleIndex = 0
        Me.colEMPNIT.Width = 99
        '
        'colEMPNOMBRE
        '
        Me.colEMPNOMBRE.Caption = "EMPRESA"
        Me.colEMPNOMBRE.FieldName = "EMPNOMBRE"
        Me.colEMPNOMBRE.Name = "colEMPNOMBRE"
        Me.colEMPNOMBRE.Visible = True
        Me.colEMPNOMBRE.VisibleIndex = 1
        Me.colEMPNOMBRE.Width = 178
        '
        'colCODPROD1
        '
        Me.colCODPROD1.FieldName = "CODPROD"
        Me.colCODPROD1.Name = "colCODPROD1"
        Me.colCODPROD1.Visible = True
        Me.colCODPROD1.VisibleIndex = 2
        Me.colCODPROD1.Width = 119
        '
        'colDESPROD1
        '
        Me.colDESPROD1.Caption = "PRODUCTO"
        Me.colDESPROD1.FieldName = "DESPROD"
        Me.colDESPROD1.Name = "colDESPROD1"
        Me.colDESPROD1.Visible = True
        Me.colDESPROD1.VisibleIndex = 3
        Me.colDESPROD1.Width = 326
        '
        'colINVMINIMO
        '
        Me.colINVMINIMO.Caption = "MINIMO"
        Me.colINVMINIMO.FieldName = "INVMINIMO"
        Me.colINVMINIMO.Name = "colINVMINIMO"
        Me.colINVMINIMO.Visible = True
        Me.colINVMINIMO.VisibleIndex = 4
        Me.colINVMINIMO.Width = 84
        '
        'colINVMAXIMO
        '
        Me.colINVMAXIMO.Caption = "MAXIMO"
        Me.colINVMAXIMO.FieldName = "INVMAXIMO"
        Me.colINVMAXIMO.Name = "colINVMAXIMO"
        Me.colINVMAXIMO.Visible = True
        Me.colINVMAXIMO.VisibleIndex = 5
        Me.colINVMAXIMO.Width = 81
        '
        'colHABILITADO
        '
        Me.colHABILITADO.FieldName = "HABILITADO"
        Me.colHABILITADO.Name = "colHABILITADO"
        Me.colHABILITADO.Visible = True
        Me.colHABILITADO.VisibleIndex = 6
        Me.colHABILITADO.Width = 95
        '
        'TblProductosBindingSource
        '
        Me.TblProductosBindingSource.DataMember = "tblProductos"
        Me.TblProductosBindingSource.DataSource = Me.DSGeneral
        '
        'TblSeriesBindingSource
        '
        Me.TblSeriesBindingSource.DataMember = "tblSeries"
        Me.TblSeriesBindingSource.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'RadialMenu1
        '
        Me.RadialMenu1.AllowGlyphSkinning = True
        Me.RadialMenu1.AutoExpand = True
        Me.RadialMenu1.Glyph = CType(resources.GetObject("RadialMenu1.Glyph"), System.Drawing.Image)
        Me.RadialMenu1.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenu1.Manager = Me.BarManager2
        Me.RadialMenu1.Name = "RadialMenu1"
        '
        'BarManager2
        '
        Me.BarManager2.DockControls.Add(Me.BarDockControl1)
        Me.BarManager2.DockControls.Add(Me.BarDockControl2)
        Me.BarManager2.DockControls.Add(Me.BarDockControl3)
        Me.BarManager2.DockControls.Add(Me.BarDockControl4)
        Me.BarManager2.Form = Me
        Me.BarManager2.MaxItemId = 0
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl1.Size = New System.Drawing.Size(1280, 0)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl2.Location = New System.Drawing.Point(0, 677)
        Me.BarDockControl2.Size = New System.Drawing.Size(1280, 0)
        '
        'BarDockControl3
        '
        Me.BarDockControl3.CausesValidation = False
        Me.BarDockControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.BarDockControl3.Location = New System.Drawing.Point(0, 0)
        Me.BarDockControl3.Size = New System.Drawing.Size(0, 677)
        '
        'BarDockControl4
        '
        Me.BarDockControl4.CausesValidation = False
        Me.BarDockControl4.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl4.Location = New System.Drawing.Point(1280, 0)
        Me.BarDockControl4.Size = New System.Drawing.Size(0, 677)
        '
        'TblRecetaBindingSource
        '
        Me.TblRecetaBindingSource.DataMember = "tblReceta"
        Me.TblRecetaBindingSource.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'TimerLoader
        '
        Me.TimerLoader.Interval = 2000
        '
        'TblProductosBindingSource1
        '
        Me.TblProductosBindingSource1.DataMember = "tblProductos"
        Me.TblProductosBindingSource1.DataSource = Me.DSGeneral
        '
        'ViewProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NavigationFrame)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Controls.Add(Me.BarDockControl3)
        Me.Controls.Add(Me.BarDockControl4)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Name = "ViewProductos"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.RadialMenuProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavigationFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationFrame.ResumeLayout(False)
        Me.NP_Listado.ResumeLayout(False)
        Me.NP_Listado.PerformLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.FlyoutOpcionesAvanzadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutOpcionesAvanzadas.ResumeLayout(False)
        CType(Me.FlyoutPanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl2.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProductosBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.dgvMedidasPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblPreciosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.productos_WindowsUIButton.ResumeLayout(False)
        CType(Me.GridProductosKardex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbNewProductosCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NP_Detalle.ResumeLayout(False)
        Me.NP_Detalle.PerformLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        Me.GroupControl6.PerformLayout()
        CType(Me.DgwReceta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblRecetaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridProductoPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoCostoUnitario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.groupproducots, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupproducots.ResumeLayout(False)
        Me.groupproducots.PerformLayout()
        CType(Me.TextBON.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoDescripcion3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoDescripcion2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoCodigo2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutPanelSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelSeries.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.FlyoutPanelControl1.PerformLayout()
        CType(Me.dgvSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblSeriesBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerieColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSerieNoSerie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwitchExento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoInvMinimo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwitchSeries.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoFechaVence.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductosUxc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductosRutaFoto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgProductosFotoProducto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NP_SyncProductos.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GridDetallesProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDatosAdicionalesProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSSync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetallesProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblSeriesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadialMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblRecetaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProductosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadialMenuProductos As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents NavigationFrame As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents NP_Listado As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NP_Detalle As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents LabelControl31 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbProductosFiltroHabilitado As ComboBox
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProductos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmdNewProductosNuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdProductoAgregarPrecio As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents imgProductosFotoProducto As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl49 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdProductoCancelarEdicion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdProductoGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents groupproducots As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtProductoFechaVence As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl50 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl32 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductosUxc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl180 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoCostoUnitario As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdProductosQuitarFoto As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtProductosRutaFoto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdProductoTomarFoto As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdProductoBuscarFoto As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl30 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbProductoClaseTres As ComboBox
    Friend WithEvents LabelControl29 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbProductoClaseDos As ComboBox
    Friend WithEvents LabelControl28 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbProductoClaseUno As ComboBox
    Friend WithEvents LabelControl27 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbProductoMarca As ComboBox
    Friend WithEvents LbProductosDesc3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoDescripcion3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LbProductosDesc2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoDescripcion2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoCodigo2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnAtras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadialMenu1 As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarButtonItemProductosCambiar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemVentas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemCompras As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemKardex As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemInfo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemDesactivar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SwitchSeries As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents lbProductoSerie As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSeries As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FlyoutPanelSeries As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents btnEliminarTodos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSerieGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSerieColor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSerieNoSerie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnSerieCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblSeriesBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOSBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOS As DSPRODUCTOS
    Friend WithEvents dgvSeries As DevExpress.XtraGrid.GridControl
    Friend WithEvents TblSeriesBindingSource1 As BindingSource
    Friend WithEvents GridViewSeries As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOSERIE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSerieCerrarPanel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtProductoInvMinimo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRadMenPreciosCompetencia As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridProductoPrecios As DataGridView
    Friend WithEvents SwitchExento As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblPreciosBindingSource As BindingSource
    Private WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoProd As ComboBox
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblProductosBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAgregarReceta As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DgwReceta As DataGridView
    Friend WithEvents TblRecetaBindingSource As BindingSource
    Friend WithEvents CODPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALUNIDADESDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents TOTALCOSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TblRecetaBindingSource1 As BindingSource
    Friend WithEvents btnProductoEliminarReceta As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSincronizarTodo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TimerLoader As Timer
    Friend WithEvents cmbColor As ComboBox
    Friend WithEvents FlyoutOpcionesAvanzadas As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl2 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnConfigActualizarCostos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnConfigEditProductosSync As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NP_SyncProductos As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridDetallesProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetallesProductos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblDatosAdicionalesProductosBindingSource As BindingSource
    Friend WithEvents DSSync As DSSync
    Friend WithEvents colEMPNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPNOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODPROD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINVMINIMO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINVMAXIMO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHABILITADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonItemMenDetallesAdicionales As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemInventarioOnline As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents IDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EQUIVALEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UTILIDADDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MARGENDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MAYOREOADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MAYOREOBDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MAYOREOCDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HABILITADODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents MARGENCONFIG As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dgvMedidasPrecios As DataGridView
    Friend WithEvents productos_WindowsUIButton As DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel
    Friend WithEvents GridProductosKardex As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lbNewProductosDesc3 As TextBox
    Friend WithEvents lbNewProductosDescripcion As TextBox
    Friend WithEvents lbNewProductosCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbNewProductosDescripcion3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl176 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl175 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbNewProductosCosto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl174 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TextBON As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents EQUIVALEDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents MAYOREOADataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents MAYOREOBDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents MAYOREOCDataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents BONO As DataGridViewTextBoxColumn
    Friend WithEvents TblProductosBindingSource1 As BindingSource
    Friend WithEvents TblProductosBindingSource2 As BindingSource
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colBONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHABILITADO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarDockControl3 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl4 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager2 As DevExpress.XtraBars.BarManager
End Class
