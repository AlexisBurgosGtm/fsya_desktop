<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewReimpresion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewReimpresion))
        Me.GridExports = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.GridListados = New DevExpress.XtraGrid.GridControl()
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
        Me.LabelControl161 = New DevExpress.XtraEditors.LabelControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.BarButRadMenListadosImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl1 = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.BarDockControl2 = New DevExpress.XtraBars.BarDockControl()
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
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosImp = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButRadMenListadosImpr = New DevExpress.XtraBars.BarButtonItem()
        Me.btnNC = New DevExpress.XtraBars.BarButtonItem()
        Me.btnToken = New DevExpress.XtraBars.BarButtonItem()
        Me.TblDocumentosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSDOCUMENTOS = New Ares.DSDOCUMENTOS()
        Me.txtDatePickInicial = New System.Windows.Forms.DateTimePicker()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.RadialMenuListados = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        CType(Me.GridExports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridListados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDocumentosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadialMenuListados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridExports
        '
        Me.GridExports.Location = New System.Drawing.Point(-32, 139)
        Me.GridExports.MainView = Me.GridView1
        Me.GridExports.Name = "GridExports"
        Me.GridExports.Size = New System.Drawing.Size(1040, 200)
        Me.GridExports.TabIndex = 227
        Me.GridExports.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.GridExports.Visible = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridExports
        Me.GridView1.Name = "GridView1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Location = New System.Drawing.Point(381, 17)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(128, 16)
        Me.LabelControl1.TabIndex = 226
        Me.LabelControl1.Text = "Tipo de Documento:"
        '
        'cmbTipoDocumento
        '
        Me.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDocumento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDocumento.FormattingEnabled = True
        Me.cmbTipoDocumento.Location = New System.Drawing.Point(515, 13)
        Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
        Me.cmbTipoDocumento.Size = New System.Drawing.Size(376, 24)
        Me.cmbTipoDocumento.TabIndex = 225
        '
        'GridListados
        '
        Me.GridListados.Location = New System.Drawing.Point(12, 61)
        Me.GridListados.MainView = Me.GridViewListados
        Me.GridListados.Name = "GridListados"
        Me.GridListados.Size = New System.Drawing.Size(982, 423)
        Me.GridListados.TabIndex = 224
        Me.GridListados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListados})
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
        Me.colCODDOC.Width = 56
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        Me.colCORRELATIVO.Width = 87
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 2
        Me.colFECHA.Width = 89
        '
        'colNIT
        '
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 3
        Me.colNIT.Width = 83
        '
        'colNOMCLIENTE
        '
        Me.colNOMCLIENTE.Caption = "NOMBRE"
        Me.colNOMCLIENTE.FieldName = "NOMCLIENTE"
        Me.colNOMCLIENTE.Name = "colNOMCLIENTE"
        Me.colNOMCLIENTE.Visible = True
        Me.colNOMCLIENTE.VisibleIndex = 4
        Me.colNOMCLIENTE.Width = 136
        '
        'colDIRCLIENTE
        '
        Me.colDIRCLIENTE.Caption = "DIRECCION"
        Me.colDIRCLIENTE.FieldName = "DIRCLIENTE"
        Me.colDIRCLIENTE.Name = "colDIRCLIENTE"
        Me.colDIRCLIENTE.Visible = True
        Me.colDIRCLIENTE.VisibleIndex = 5
        Me.colDIRCLIENTE.Width = 86
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
        Me.colTOTALPRECIO.Width = 103
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
        Me.colHORAMINUTO.Width = 90
        '
        'colCONCRE
        '
        Me.colCONCRE.FieldName = "CONCRE"
        Me.colCONCRE.Name = "colCONCRE"
        Me.colCONCRE.Visible = True
        Me.colCONCRE.VisibleIndex = 8
        Me.colCONCRE.Width = 55
        '
        'colST
        '
        Me.colST.FieldName = "ST"
        Me.colST.Name = "colST"
        Me.colST.Visible = True
        Me.colST.VisibleIndex = 9
        Me.colST.Width = 37
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
        Me.GridColumn1.Width = 174
        '
        'colCODCAJA
        '
        Me.colCODCAJA.Caption = "CAJA"
        Me.colCODCAJA.FieldName = "CODCAJA"
        Me.colCODCAJA.Name = "colCODCAJA"
        Me.colCODCAJA.Visible = True
        Me.colCODCAJA.VisibleIndex = 11
        Me.colCODCAJA.Width = 51
        '
        'LabelControl161
        '
        Me.LabelControl161.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl161.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl161.Location = New System.Drawing.Point(62, 12)
        Me.LabelControl161.Name = "LabelControl161"
        Me.LabelControl161.Size = New System.Drawing.Size(292, 33)
        Me.LabelControl161.TabIndex = 220
        Me.LabelControl161.Text = "Reimpresion de Facturas"
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1011, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 497)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 497)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1011, 0)
        '
        'BarButRadMenListadosImprimir
        '
        Me.BarButRadMenListadosImprimir.Caption = "Re-Imprimir"
        Me.BarButRadMenListadosImprimir.CloseRadialMenuOnItemClick = True
        Me.BarButRadMenListadosImprimir.Glyph = CType(resources.GetObject("BarButRadMenListadosImprimir.Glyph"), System.Drawing.Image)
        Me.BarButRadMenListadosImprimir.Id = 0
        Me.BarButRadMenListadosImprimir.Name = "BarButRadMenListadosImprimir"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.BarDockControl1)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.BarDockControl2)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButRadMenListadosImprimir, Me.BarButRadMenListadosAnular, Me.BarButRadMenListadosEditar, Me.BarButRadMenListadosEliminar, Me.BarButRadMenListadosMarcar, Me.BarButRadMenListadosObsMarca, Me.BarButRadMenListadosEmail, Me.BatButRadMenExportar, Me.batButRadMenCambiarCaja, Me.btnMenuCertificar, Me.btnMenuCambiarCliente, Me.BarButtonItem1, Me.BarButRadMenListadosImp, Me.BarButtonItem2, Me.BarButRadMenListadosImpr, Me.btnNC, Me.btnToken})
        Me.BarManager1.MaxItemId = 17
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1011, 0)
        '
        'BarDockControl1
        '
        Me.BarDockControl1.CausesValidation = False
        Me.BarDockControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarDockControl1.Location = New System.Drawing.Point(0, 497)
        Me.BarDockControl1.Size = New System.Drawing.Size(1011, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 497)
        '
        'BarDockControl2
        '
        Me.BarDockControl2.CausesValidation = False
        Me.BarDockControl2.Dock = System.Windows.Forms.DockStyle.Right
        Me.BarDockControl2.Location = New System.Drawing.Point(1011, 0)
        Me.BarDockControl2.Size = New System.Drawing.Size(0, 497)
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
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 11
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButRadMenListadosImp
        '
        Me.BarButRadMenListadosImp.Caption = "IMPRIMIR FACTURA"
        Me.BarButRadMenListadosImp.Id = 12
        Me.BarButRadMenListadosImp.Name = "BarButRadMenListadosImp"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "BarButtonItem2"
        Me.BarButtonItem2.Id = 13
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButRadMenListadosImpr
        '
        Me.BarButRadMenListadosImpr.Caption = "BarButtonItem3"
        Me.BarButRadMenListadosImpr.Id = 14
        Me.BarButRadMenListadosImpr.Name = "BarButRadMenListadosImpr"
        '
        'btnNC
        '
        Me.btnNC.Caption = "NOTA DE CREDITO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNC.CloseRadialMenuOnItemClick = True
        Me.btnNC.Glyph = CType(resources.GetObject("btnNC.Glyph"), System.Drawing.Image)
        Me.btnNC.Id = 15
        Me.btnNC.Name = "btnNC"
        '
        'btnToken
        '
        Me.btnToken.Caption = "GENERAR TOKEN"
        Me.btnToken.CloseRadialMenuOnItemClick = True
        Me.btnToken.Glyph = CType(resources.GetObject("btnToken.Glyph"), System.Drawing.Image)
        Me.btnToken.Id = 16
        Me.btnToken.Name = "btnToken"
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
        'txtDatePickInicial
        '
        Me.txtDatePickInicial.CustomFormat = "yyyy-MM-d"
        Me.txtDatePickInicial.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.txtDatePickInicial.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.txtDatePickInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtDatePickInicial.Location = New System.Drawing.Point(897, 13)
        Me.txtDatePickInicial.Name = "txtDatePickInicial"
        Me.txtDatePickInicial.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDatePickInicial.Size = New System.Drawing.Size(97, 24)
        Me.txtDatePickInicial.TabIndex = 241
        '
        'cmdRPTVatras
        '
        Me.cmdRPTVatras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdRPTVatras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRPTVatras.Image = CType(resources.GetObject("cmdRPTVatras.Image"), System.Drawing.Image)
        Me.cmdRPTVatras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdRPTVatras.Location = New System.Drawing.Point(6, 6)
        Me.cmdRPTVatras.Name = "cmdRPTVatras"
        Me.cmdRPTVatras.Size = New System.Drawing.Size(44, 40)
        Me.cmdRPTVatras.TabIndex = 242
        '
        'RadialMenuListados
        '
        Me.RadialMenuListados.AutoExpand = True
        Me.RadialMenuListados.Glyph = CType(resources.GetObject("RadialMenuListados.Glyph"), System.Drawing.Image)
        Me.RadialMenuListados.InnerRadius = 150
        Me.RadialMenuListados.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuListados.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButRadMenListadosImprimir), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuCertificar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnNC), New DevExpress.XtraBars.LinkPersistInfo(Me.btnToken)})
        Me.RadialMenuListados.Manager = Me.BarManager1
        Me.RadialMenuListados.MenuRadius = 220
        Me.RadialMenuListados.Name = "RadialMenuListados"
        '
        'viewReimpresion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.txtDatePickInicial)
        Me.Controls.Add(Me.GridExports)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmbTipoDocumento)
        Me.Controls.Add(Me.GridListados)
        Me.Controls.Add(Me.LabelControl161)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.BarDockControl2)
        Me.Controls.Add(Me.BarDockControl1)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewReimpresion"
        Me.Size = New System.Drawing.Size(1011, 497)
        CType(Me.GridExports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridListados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDocumentosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadialMenuListados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridExports As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoDocumento As ComboBox
    Friend WithEvents GridListados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewListados As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents colCODCAJA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl161 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButRadMenListadosImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosAnular As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosMarcar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosObsMarca As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosEmail As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BatButRadMenExportar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents batButRadMenCambiarCaja As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuCertificar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuCambiarCliente As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl1 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarDockControl2 As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents TblDocumentosBindingSource As BindingSource
    Friend WithEvents DSDOCUMENTOS As DSDOCUMENTOS
    Friend WithEvents txtDatePickInicial As DateTimePicker
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BarButRadMenListadosImp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadialMenuListados As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButRadMenListadosImpr As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnNC As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnToken As DevExpress.XtraBars.BarButtonItem
End Class
