<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewDocumentos))
        Me.LabelControl161 = New DevExpress.XtraEditors.LabelControl()
        Me.RadialMenuListados = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.BarButRadMenListadosImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosAnular = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosMarcar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosObsMarca = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosEmail = New DevExpress.XtraBars.BarButtonItem()
        Me.BatButRadMenExportar = New DevExpress.XtraBars.BarButtonItem()
        Me.batButRadMenCambiarCaja = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuCertificar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuCambiarCliente = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.cmbAnioDocumento = New System.Windows.Forms.ComboBox()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMesDocumento = New System.Windows.Forms.ComboBox()
        Me.GridListados = New DevExpress.XtraGrid.GridControl()
        Me.TblDocumentosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSDOCUMENTOS = New Ares.DSDOCUMENTOS()
        Me.GridViewListados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEMPNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDIRCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALTARJETA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHORAMINUTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONCRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCodcliente = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCAJA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridExports = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnExportarExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExportarDetalle = New DevExpress.XtraEditors.SimpleButton()
        Me.gridExports1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.RadialMenuListados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridListados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDocumentosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridExports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridExports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl161
        '
        Me.LabelControl161.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl161.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl161.Location = New System.Drawing.Point(114, 19)
        Me.LabelControl161.Name = "LabelControl161"
        Me.LabelControl161.Size = New System.Drawing.Size(277, 33)
        Me.LabelControl161.TabIndex = 176
        Me.LabelControl161.Text = "Listado de Documentos"
        '
        'RadialMenuListados
        '
        Me.RadialMenuListados.AutoExpand = True
        Me.RadialMenuListados.Glyph = CType(resources.GetObject("RadialMenuListados.Glyph"), System.Drawing.Image)
        Me.RadialMenuListados.InnerRadius = 150
        Me.RadialMenuListados.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuListados.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosImprimir), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosAnular), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosMarcar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosObsMarca), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosEmail), New DevExpress.XtraBars.LinkPersistInfo(Me.BatButRadMenExportar), New DevExpress.XtraBars.LinkPersistInfo(Me.batButRadMenCambiarCaja), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuCertificar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuCambiarCliente)})
        Me.RadialMenuListados.Manager = Me.BarManager1
        Me.RadialMenuListados.MenuRadius = 220
        Me.RadialMenuListados.Name = "RadialMenuListados"
        '
        'BarButRadMenListadosImprimir
        '
        Me.BarButRadMenListadosImprimir.Caption = "Re-Imprimir"
        Me.BarButRadMenListadosImprimir.CloseRadialMenuOnItemClick = True
        Me.BarButRadMenListadosImprimir.Glyph = CType(resources.GetObject("BarButRadMenListadosImprimir.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosImprimir.Id = 0
        Me.BarButRadMenListadosImprimir.Name = "BarButRadMenListadosImprimir"
        '
        'BarButRadMenListadosAnular
        '
        Me.BarButRadMenListadosAnular.Caption = "Anular"
        Me.BarButRadMenListadosAnular.CloseRadialMenuOnItemClick = True
        Me.BarButRadMenListadosAnular.Glyph = CType(resources.GetObject("BarButRadMenListadosAnular.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosAnular.Id = 1
        Me.BarButRadMenListadosAnular.Name = "BarButRadMenListadosAnular"
        '
        'BarButRadMenListadosEditar
        '
        Me.BarButRadMenListadosEditar.Caption = "Editar"
        Me.BarButRadMenListadosEditar.Glyph = CType(resources.GetObject("BarButRadMenListadosEditar.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosEditar.Id = 2
        Me.BarButRadMenListadosEditar.Name = "BarButRadMenListadosEditar"
        '
        'BarButRadMenListadosEliminar
        '
        Me.BarButRadMenListadosEliminar.Caption = "Eliminar"
        Me.BarButRadMenListadosEliminar.CloseRadialMenuOnItemClick = True
        Me.BarButRadMenListadosEliminar.Glyph = CType(resources.GetObject("BarButRadMenListadosEliminar.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosEliminar.Id = 3
        Me.BarButRadMenListadosEliminar.Name = "BarButRadMenListadosEliminar"
        '
        'BarButRadMenListadosMarcar
        '
        Me.BarButRadMenListadosMarcar.Caption = "Marcar"
        Me.BarButRadMenListadosMarcar.CloseRadialMenuOnItemClick = True
        Me.BarButRadMenListadosMarcar.Glyph = CType(resources.GetObject("BarButRadMenListadosMarcar.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosMarcar.Id = 4
        Me.BarButRadMenListadosMarcar.Name = "BarButRadMenListadosMarcar"
        '
        'BarButRadMenListadosObsMarca
        '
        Me.BarButRadMenListadosObsMarca.Caption = "Nota de la Marca"
        Me.BarButRadMenListadosObsMarca.CloseRadialMenuOnItemClick = True
        Me.BarButRadMenListadosObsMarca.Glyph = CType(resources.GetObject("BarButRadMenListadosObsMarca.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosObsMarca.Id = 5
        Me.BarButRadMenListadosObsMarca.Name = "BarButRadMenListadosObsMarca"
        '
        'BarButRadMenListadosEmail
        '
        Me.BarButRadMenListadosEmail.Caption = "Enviar por Email"
        Me.BarButRadMenListadosEmail.CloseRadialMenuOnItemClick = True
        Me.BarButRadMenListadosEmail.Enabled = False
        Me.BarButRadMenListadosEmail.Glyph = CType(resources.GetObject("BarButRadMenListadosEmail.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosEmail.Id = 6
        Me.BarButRadMenListadosEmail.Name = "BarButRadMenListadosEmail"
        '
        'BatButRadMenExportar
        '
        Me.BatButRadMenExportar.Caption = "Exportar Excel"
        Me.BatButRadMenExportar.Glyph = CType(resources.GetObject("BatButRadMenExportar.Glyph"), System.Drawing.Image)
        Me.BatButRadMenExportar.Id = 7
        Me.BatButRadMenExportar.Name = "BatButRadMenExportar"
        '
        'batButRadMenCambiarCaja
        '
        Me.batButRadMenCambiarCaja.Caption = "Cambiar Caja"
        Me.batButRadMenCambiarCaja.Glyph = CType(resources.GetObject("batButRadMenCambiarCaja.Glyph"), System.Drawing.Image)
        Me.batButRadMenCambiarCaja.Id = 8
        Me.batButRadMenCambiarCaja.Name = "batButRadMenCambiarCaja"
        '
        'btnMenuCertificar
        '
        Me.btnMenuCertificar.Caption = "CERTIFICAR"
        Me.btnMenuCertificar.Glyph = CType(resources.GetObject("btnMenuCertificar.Glyph"), System.Drawing.Image)
        Me.btnMenuCertificar.Id = 9
        Me.btnMenuCertificar.Name = "btnMenuCertificar"
        '
        'btnMenuCambiarCliente
        '
        Me.btnMenuCambiarCliente.Caption = "Cambiar Cliente"
        Me.btnMenuCambiarCliente.CloseRadialMenuOnItemClick = True
        Me.btnMenuCambiarCliente.Glyph = CType(resources.GetObject("btnMenuCambiarCliente.Glyph"), System.Drawing.Image)
        Me.btnMenuCambiarCliente.Id = 10
        Me.btnMenuCambiarCliente.Name = "btnMenuCambiarCliente"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButRadMenListadosImprimir, Me.BarButRadMenListadosAnular, Me.BarButRadMenListadosEditar, Me.BarButRadMenListadosEliminar, Me.BarButRadMenListadosMarcar, Me.BarButRadMenListadosObsMarca, Me.BarButRadMenListadosEmail, Me.BatButRadMenExportar, Me.batButRadMenCambiarCaja, Me.btnMenuCertificar, Me.btnMenuCambiarCliente, Me.BarButtonItem1})
        Me.BarManager1.MaxItemId = 12
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
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 11
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'cmbAnioDocumento
        '
        Me.cmbAnioDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAnioDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAnioDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAnioDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbAnioDocumento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnioDocumento.ForeColor = System.Drawing.Color.Black
        Me.cmbAnioDocumento.FormattingEnabled = True
        Me.cmbAnioDocumento.Items.AddRange(New Object() {"2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbAnioDocumento.Location = New System.Drawing.Point(279, 79)
        Me.cmbAnioDocumento.Name = "cmbAnioDocumento"
        Me.cmbAnioDocumento.Size = New System.Drawing.Size(121, 24)
        Me.cmbAnioDocumento.TabIndex = 195
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl13.Location = New System.Drawing.Point(15, 80)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(104, 16)
        Me.LabelControl13.TabIndex = 194
        Me.LabelControl13.Text = "Mes de Trabajo:"
        '
        'cmbMesDocumento
        '
        Me.cmbMesDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMesDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMesDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbMesDocumento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesDocumento.ForeColor = System.Drawing.Color.Black
        Me.cmbMesDocumento.FormattingEnabled = True
        Me.cmbMesDocumento.Location = New System.Drawing.Point(125, 78)
        Me.cmbMesDocumento.Name = "cmbMesDocumento"
        Me.cmbMesDocumento.Size = New System.Drawing.Size(148, 24)
        Me.cmbMesDocumento.TabIndex = 193
        '
        'GridListados
        '
        Me.GridListados.DataSource = Me.TblDocumentosBindingSource
        Me.GridListados.Location = New System.Drawing.Point(12, 124)
        Me.GridListados.MainView = Me.GridViewListados
        Me.GridListados.MenuManager = Me.BarManager1
        Me.GridListados.Name = "GridListados"
        Me.GridListados.Size = New System.Drawing.Size(1254, 542)
        Me.GridListados.TabIndex = 200
        Me.GridListados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListados})
        '
        'TblDocumentosBindingSource
        '
        Me.TblDocumentosBindingSource.DataMember = "tblDocumentos"
        Me.TblDocumentosBindingSource.DataSource = Me.DSDOCUMENTOS
        '
        'DSDOCUMENTOS
        '
        Me.DSDOCUMENTOS.DataSetName = "DSDOCUMENTOS"
        Me.DSDOCUMENTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewListados
        '
        Me.GridViewListados.Appearance.EvenRow.BackColor = System.Drawing.Color.Silver
        Me.GridViewListados.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridViewListados.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridViewListados.Appearance.Row.Options.UseBackColor = True
        Me.GridViewListados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEMPNIT, Me.colCODDOC, Me.colCORRELATIVO, Me.colFECHA, Me.colNIT, Me.colNOMCLIENTE, Me.colDIRCLIENTE, Me.colMARCA, Me.colTOTALCOSTO, Me.colTOTALPRECIO, Me.colTOTALTARJETA, Me.colHORAMINUTO, Me.colCONCRE, Me.colST, Me.colCodcliente, Me.GridColumn1, Me.colCODCAJA})
        Me.GridViewListados.GridControl = Me.GridListados
        Me.GridViewListados.Name = "GridViewListados"
        Me.GridViewListados.OptionsBehavior.Editable = False
        Me.GridViewListados.OptionsView.ShowAutoFilterRow = True
        Me.GridViewListados.OptionsView.ShowGroupPanel = False
        '
        'colEMPNIT
        '
        Me.colEMPNIT.FieldName = "EMPNIT"
        Me.colEMPNIT.Name = "colEMPNIT"
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 0
        Me.colCODDOC.Width = 100
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        Me.colCORRELATIVO.Width = 103
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 2
        Me.colFECHA.Width = 106
        '
        'colNIT
        '
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 3
        Me.colNIT.Width = 98
        '
        'colNOMCLIENTE
        '
        Me.colNOMCLIENTE.Caption = "NOMBRE"
        Me.colNOMCLIENTE.FieldName = "NOMCLIENTE"
        Me.colNOMCLIENTE.Name = "colNOMCLIENTE"
        Me.colNOMCLIENTE.Visible = True
        Me.colNOMCLIENTE.VisibleIndex = 4
        Me.colNOMCLIENTE.Width = 200
        '
        'colDIRCLIENTE
        '
        Me.colDIRCLIENTE.Caption = "DIRECCION"
        Me.colDIRCLIENTE.FieldName = "DIRCLIENTE"
        Me.colDIRCLIENTE.Name = "colDIRCLIENTE"
        Me.colDIRCLIENTE.Visible = True
        Me.colDIRCLIENTE.VisibleIndex = 5
        Me.colDIRCLIENTE.Width = 96
        '
        'colMARCA
        '
        Me.colMARCA.FieldName = "MARCA"
        Me.colMARCA.Name = "colMARCA"
        Me.colMARCA.Width = 49
        '
        'colTOTALCOSTO
        '
        Me.colTOTALCOSTO.FieldName = "TOTALCOSTO"
        Me.colTOTALCOSTO.Name = "colTOTALCOSTO"
        Me.colTOTALCOSTO.Width = 87
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.Caption = "IMPORTE"
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 6
        '
        'colTOTALTARJETA
        '
        Me.colTOTALTARJETA.Caption = "TARJETA"
        Me.colTOTALTARJETA.FieldName = "TOTALTARJETA"
        Me.colTOTALTARJETA.Name = "colTOTALTARJETA"
        Me.colTOTALTARJETA.Width = 77
        '
        'colHORAMINUTO
        '
        Me.colHORAMINUTO.Caption = "HORA"
        Me.colHORAMINUTO.FieldName = "HORAMINUTO"
        Me.colHORAMINUTO.Name = "colHORAMINUTO"
        Me.colHORAMINUTO.Visible = True
        Me.colHORAMINUTO.VisibleIndex = 7
        Me.colHORAMINUTO.Width = 109
        '
        'colCONCRE
        '
        Me.colCONCRE.FieldName = "CONCRE"
        Me.colCONCRE.Name = "colCONCRE"
        Me.colCONCRE.Visible = True
        Me.colCONCRE.VisibleIndex = 8
        Me.colCONCRE.Width = 65
        '
        'colST
        '
        Me.colST.FieldName = "ST"
        Me.colST.Name = "colST"
        Me.colST.Visible = True
        Me.colST.VisibleIndex = 9
        Me.colST.Width = 42
        '
        'colCodcliente
        '
        Me.colCodcliente.Caption = "GridColumn1"
        Me.colCodcliente.FieldName = "CODCLIENTE"
        Me.colCodcliente.Name = "colCodcliente"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "REF/CERTIF/ORIG/DEST"
        Me.GridColumn1.FieldName = "DOCREF"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 10
        Me.GridColumn1.Width = 212
        '
        'colCODCAJA
        '
        Me.colCODCAJA.Caption = "CAJA"
        Me.colCODCAJA.FieldName = "CODCAJA"
        Me.colCODCAJA.Name = "colCODCAJA"
        Me.colCODCAJA.Visible = True
        Me.colCODCAJA.VisibleIndex = 11
        Me.colCODCAJA.Width = 93
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(615, 83)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(432, 24)
        Me.cmbTipoDocumento.TabIndex = 201
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Location = New System.Drawing.Point(481, 86)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(128, 16)
        Me.LabelControl1.TabIndex = 202
        Me.LabelControl1.Text = "Tipo de Documento:"
        '
        'GridExports
        '
        Me.GridExports.Location = New System.Drawing.Point(0, 209)
        Me.GridExports.MainView = Me.GridView1
        Me.GridExports.MenuManager = Me.BarManager1
        Me.GridExports.Name = "GridExports"
        Me.GridExports.Size = New System.Drawing.Size(1040, 200)
        Me.GridExports.TabIndex = 207
        Me.GridExports.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridExports.Visible = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridExports
        Me.GridView1.Name = "GridView1"
        '
        'btnExportarExcel
        '
        Me.btnExportarExcel.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExportarExcel.Appearance.ForeColor = System.Drawing.Color.Green
        Me.btnExportarExcel.Appearance.Options.UseBackColor = True
        Me.btnExportarExcel.Appearance.Options.UseForeColor = True
        Me.btnExportarExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnExportarExcel.Image = CType(resources.GetObject("btnExportarExcel.Image"), System.Drawing.Image)
        Me.btnExportarExcel.Location = New System.Drawing.Point(1053, 79)
        Me.btnExportarExcel.Name = "btnExportarExcel"
        Me.btnExportarExcel.Size = New System.Drawing.Size(109, 31)
        Me.btnExportarExcel.TabIndex = 212
        Me.btnExportarExcel.Text = "Exportar Lista"
        '
        'btnExportarDetalle
        '
        Me.btnExportarDetalle.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExportarDetalle.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnExportarDetalle.Appearance.Options.UseBackColor = True
        Me.btnExportarDetalle.Appearance.Options.UseForeColor = True
        Me.btnExportarDetalle.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnExportarDetalle.Image = CType(resources.GetObject("btnExportarDetalle.Image"), System.Drawing.Image)
        Me.btnExportarDetalle.Location = New System.Drawing.Point(1168, 79)
        Me.btnExportarDetalle.Name = "btnExportarDetalle"
        Me.btnExportarDetalle.Size = New System.Drawing.Size(109, 31)
        Me.btnExportarDetalle.TabIndex = 217
        Me.btnExportarDetalle.Text = "Exportar Detalle"
        '
        'gridExports1
        '
        Me.gridExports1.Location = New System.Drawing.Point(920, 19)
        Me.gridExports1.MainView = Me.GridView2
        Me.gridExports1.Name = "gridExports1"
        Me.gridExports1.Size = New System.Drawing.Size(82, 52)
        Me.gridExports1.TabIndex = 745
        Me.gridExports1.TabStop = False
        Me.gridExports1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        Me.gridExports1.Visible = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridExports1
        Me.GridView2.Name = "GridView2"
        '
        'ViewDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gridExports1)
        Me.Controls.Add(Me.btnExportarDetalle)
        Me.Controls.Add(Me.btnExportarExcel)
        Me.Controls.Add(Me.GridExports)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmbTipoDocumento)
        Me.Controls.Add(Me.GridListados)
        Me.Controls.Add(Me.cmbAnioDocumento)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.cmbMesDocumento)
        Me.Controls.Add(Me.LabelControl161)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ViewDocumentos"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.RadialMenuListados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridListados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDocumentosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridExports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridExports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl161 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RadialMenuListados As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButRadMenListadosImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosAnular As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosMarcar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosObsMarca As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents cmbAnioDocumento As ComboBox
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbMesDocumento As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoDocumento As ComboBox
    Friend WithEvents GridListados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewListados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblDocumentosBindingSource As BindingSource
    Friend WithEvents DSDOCUMENTOS As DSDOCUMENTOS
    Friend WithEvents colEMPNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDIRCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALTARJETA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHORAMINUTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONCRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCodcliente As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BatButRadMenExportar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridExports As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExportarExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colCODCAJA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents batButRadMenCambiarCaja As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuCertificar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnExportarDetalle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnMenuCambiarCliente As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents gridExports1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
