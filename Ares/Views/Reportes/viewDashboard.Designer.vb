<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewDashboard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewDashboard))
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim LineSeriesView1 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Me.LabelControl170 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.btnCargar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalInventario = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalVenta = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalUtilidad = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.ChartControlVentas = New DevExpress.XtraCharts.ChartControl()
        Me.TblVentasDiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSDASHBOARD = New Ares.DSDASHBOARD()
        Me.GridControlProductos = New DevExpress.XtraGrid.GridControl()
        Me.TblVentasVendedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewProductos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUNIDADES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVENTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUTILIDAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TblTopProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnExportarDataProductos = New DevExpress.XtraEditors.SimpleButton()
        Me.GridControlVendedores = New DevExpress.XtraGrid.GridControl()
        Me.GridViewVendedores = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUTILIDAD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnExportarDatosVendedores = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.ChartControlVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblVentasDiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSDASHBOARD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblVentasVendedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTopProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewVendedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl170
        '
        Me.LabelControl170.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl170.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl170.Location = New System.Drawing.Point(96, 13)
        Me.LabelControl170.Name = "LabelControl170"
        Me.LabelControl170.Size = New System.Drawing.Size(227, 33)
        Me.LabelControl170.TabIndex = 216
        Me.LabelControl170.Text = "Dashboard General"
        '
        'cmbMes
        '
        Me.cmbMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(357, 26)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(135, 21)
        Me.cmbMes.TabIndex = 217
        '
        'cmbAnio
        '
        Me.cmbAnio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAnio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAnio.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Items.AddRange(New Object() {"2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040"})
        Me.cmbAnio.Location = New System.Drawing.Point(498, 26)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(87, 21)
        Me.cmbAnio.TabIndex = 218
        '
        'btnCargar
        '
        Me.btnCargar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCargar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCargar.Appearance.Options.UseBackColor = True
        Me.btnCargar.Appearance.Options.UseForeColor = True
        Me.btnCargar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
        Me.btnCargar.Location = New System.Drawing.Point(591, 18)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(78, 35)
        Me.btnCargar.TabIndex = 221
        Me.btnCargar.Text = "Cargar"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(775, 76)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl1.TabIndex = 225
        Me.LabelControl1.Text = "Total Inventario:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl2.Location = New System.Drawing.Point(875, 68)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl2.TabIndex = 226
        Me.LabelControl2.Text = "Q"
        '
        'lbTotalInventario
        '
        Me.lbTotalInventario.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalInventario.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalInventario.Location = New System.Drawing.Point(901, 68)
        Me.lbTotalInventario.Name = "lbTotalInventario"
        Me.lbTotalInventario.Size = New System.Drawing.Size(163, 25)
        Me.lbTotalInventario.TabIndex = 227
        Me.lbTotalInventario.Text = "9999999999.99"
        '
        'lbTotalVenta
        '
        Me.lbTotalVenta.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalVenta.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTotalVenta.Location = New System.Drawing.Point(901, 10)
        Me.lbTotalVenta.Name = "lbTotalVenta"
        Me.lbTotalVenta.Size = New System.Drawing.Size(163, 25)
        Me.lbTotalVenta.TabIndex = 230
        Me.lbTotalVenta.Text = "9999999999.99"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(875, 10)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl4.TabIndex = 229
        Me.LabelControl4.Text = "Q"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(775, 18)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(69, 13)
        Me.LabelControl5.TabIndex = 228
        Me.LabelControl5.Text = "Total Vendido:"
        '
        'lbTotalUtilidad
        '
        Me.lbTotalUtilidad.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalUtilidad.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalUtilidad.Location = New System.Drawing.Point(901, 39)
        Me.lbTotalUtilidad.Name = "lbTotalUtilidad"
        Me.lbTotalUtilidad.Size = New System.Drawing.Size(163, 25)
        Me.lbTotalUtilidad.TabIndex = 233
        Me.lbTotalUtilidad.Text = "9999999999.99"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl7.Location = New System.Drawing.Point(875, 39)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl7.TabIndex = 232
        Me.LabelControl7.Text = "Q"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(775, 47)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(66, 13)
        Me.LabelControl8.TabIndex = 231
        Me.LabelControl8.Text = "Total Utilidad:"
        '
        'ChartControlVentas
        '
        Me.ChartControlVentas.DataSource = Me.TblVentasDiaBindingSource
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControlVentas.Diagram = XyDiagram1
        Me.ChartControlVentas.Legend.Name = "Default Legend"
        Me.ChartControlVentas.Location = New System.Drawing.Point(18, 100)
        Me.ChartControlVentas.Name = "ChartControlVentas"
        Series1.ArgumentDataMember = "FECHA"
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.LegendText = "Ventas"
        Series1.Name = "Series 1"
        Series1.ValueDataMembersSerializable = "PRECIO"
        Series1.View = LineSeriesView1
        Me.ChartControlVentas.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.ChartControlVentas.Size = New System.Drawing.Size(1046, 212)
        Me.ChartControlVentas.TabIndex = 234
        '
        'TblVentasDiaBindingSource
        '
        Me.TblVentasDiaBindingSource.DataMember = "tblVentasDia"
        Me.TblVentasDiaBindingSource.DataSource = Me.DSDASHBOARD
        '
        'DSDASHBOARD
        '
        Me.DSDASHBOARD.DataSetName = "DSDASHBOARD"
        Me.DSDASHBOARD.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridControlProductos
        '
        Me.GridControlProductos.DataSource = Me.TblVentasVendedorBindingSource
        Me.GridControlProductos.Location = New System.Drawing.Point(18, 347)
        Me.GridControlProductos.MainView = Me.GridViewProductos
        Me.GridControlProductos.Name = "GridControlProductos"
        Me.GridControlProductos.Size = New System.Drawing.Size(678, 339)
        Me.GridControlProductos.TabIndex = 235
        Me.GridControlProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProductos})
        '
        'TblVentasVendedorBindingSource
        '
        Me.TblVentasVendedorBindingSource.DataMember = "tblVentasVendedor"
        Me.TblVentasVendedorBindingSource.DataSource = Me.DSDASHBOARD
        '
        'GridViewProductos
        '
        Me.GridViewProductos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colUNIDADES, Me.colCOSTO, Me.colVENTA, Me.colUTILIDAD})
        Me.GridViewProductos.GridControl = Me.GridControlProductos
        Me.GridViewProductos.Name = "GridViewProductos"
        Me.GridViewProductos.OptionsBehavior.Editable = False
        Me.GridViewProductos.OptionsView.ShowAutoFilterRow = True
        Me.GridViewProductos.OptionsView.ShowFooter = True
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "CODIGO"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VENTA", "SUM={0:0.##}")})
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "PRODUCTO"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 280
        '
        'colUNIDADES
        '
        Me.colUNIDADES.FieldName = "UNIDADES"
        Me.colUNIDADES.Name = "colUNIDADES"
        Me.colUNIDADES.Visible = True
        Me.colUNIDADES.VisibleIndex = 2
        Me.colUNIDADES.Width = 63
        '
        'colCOSTO
        '
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        Me.colCOSTO.Visible = True
        Me.colCOSTO.VisibleIndex = 3
        Me.colCOSTO.Width = 77
        '
        'colVENTA
        '
        Me.colVENTA.FieldName = "VENTA"
        Me.colVENTA.Name = "colVENTA"
        Me.colVENTA.Visible = True
        Me.colVENTA.VisibleIndex = 4
        Me.colVENTA.Width = 78
        '
        'colUTILIDAD
        '
        Me.colUTILIDAD.FieldName = "UTILIDAD"
        Me.colUTILIDAD.Name = "colUTILIDAD"
        Me.colUTILIDAD.Visible = True
        Me.colUTILIDAD.VisibleIndex = 5
        Me.colUTILIDAD.Width = 77
        '
        'TblTopProductosBindingSource
        '
        Me.TblTopProductosBindingSource.DataSource = Me.DSDASHBOARD
        Me.TblTopProductosBindingSource.Position = 0
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(18, 322)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(166, 19)
        Me.LabelControl3.TabIndex = 236
        Me.LabelControl3.Text = "Ventas por Producto"
        '
        'btnExportarDataProductos
        '
        Me.btnExportarDataProductos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExportarDataProductos.Appearance.ForeColor = System.Drawing.Color.Green
        Me.btnExportarDataProductos.Appearance.Options.UseBackColor = True
        Me.btnExportarDataProductos.Appearance.Options.UseForeColor = True
        Me.btnExportarDataProductos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnExportarDataProductos.Image = CType(resources.GetObject("btnExportarDataProductos.Image"), System.Drawing.Image)
        Me.btnExportarDataProductos.Location = New System.Drawing.Point(621, 320)
        Me.btnExportarDataProductos.Name = "btnExportarDataProductos"
        Me.btnExportarDataProductos.Size = New System.Drawing.Size(75, 23)
        Me.btnExportarDataProductos.TabIndex = 237
        Me.btnExportarDataProductos.Text = "Exportar"
        '
        'GridControlVendedores
        '
        Me.GridControlVendedores.DataSource = Me.TblVentasVendedorBindingSource
        Me.GridControlVendedores.Location = New System.Drawing.Point(702, 347)
        Me.GridControlVendedores.MainView = Me.GridViewVendedores
        Me.GridControlVendedores.Name = "GridControlVendedores"
        Me.GridControlVendedores.Size = New System.Drawing.Size(362, 339)
        Me.GridControlVendedores.TabIndex = 238
        Me.GridControlVendedores.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewVendedores})
        '
        'GridViewVendedores
        '
        Me.GridViewVendedores.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GridViewVendedores.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridViewVendedores.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNOMBRE, Me.colCOSTO1, Me.colPRECIO, Me.colUTILIDAD1})
        Me.GridViewVendedores.GridControl = Me.GridControlVendedores
        Me.GridViewVendedores.Name = "GridViewVendedores"
        Me.GridViewVendedores.OptionsBehavior.Editable = False
        Me.GridViewVendedores.OptionsView.ShowGroupPanel = False
        '
        'colNOMBRE
        '
        Me.colNOMBRE.FieldName = "NOMBRE"
        Me.colNOMBRE.Name = "colNOMBRE"
        Me.colNOMBRE.Visible = True
        Me.colNOMBRE.VisibleIndex = 0
        Me.colNOMBRE.Width = 129
        '
        'colCOSTO1
        '
        Me.colCOSTO1.FieldName = "COSTO"
        Me.colCOSTO1.Name = "colCOSTO1"
        Me.colCOSTO1.Visible = True
        Me.colCOSTO1.VisibleIndex = 1
        Me.colCOSTO1.Width = 72
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 2
        Me.colPRECIO.Width = 78
        '
        'colUTILIDAD1
        '
        Me.colUTILIDAD1.FieldName = "UTILIDAD"
        Me.colUTILIDAD1.Name = "colUTILIDAD1"
        Me.colUTILIDAD1.Visible = True
        Me.colUTILIDAD1.VisibleIndex = 3
        Me.colUTILIDAD1.Width = 65
        '
        'btnExportarDatosVendedores
        '
        Me.btnExportarDatosVendedores.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExportarDatosVendedores.Appearance.ForeColor = System.Drawing.Color.Green
        Me.btnExportarDatosVendedores.Appearance.Options.UseBackColor = True
        Me.btnExportarDatosVendedores.Appearance.Options.UseForeColor = True
        Me.btnExportarDatosVendedores.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnExportarDatosVendedores.Image = CType(resources.GetObject("btnExportarDatosVendedores.Image"), System.Drawing.Image)
        Me.btnExportarDatosVendedores.Location = New System.Drawing.Point(989, 322)
        Me.btnExportarDatosVendedores.Name = "btnExportarDatosVendedores"
        Me.btnExportarDatosVendedores.Size = New System.Drawing.Size(75, 23)
        Me.btnExportarDatosVendedores.TabIndex = 239
        Me.btnExportarDatosVendedores.Text = "Exportar"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(702, 322)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(171, 19)
        Me.LabelControl6.TabIndex = 240
        Me.LabelControl6.Text = "Ventas por Vendedor"
        '
        'viewDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.btnExportarDatosVendedores)
        Me.Controls.Add(Me.GridControlVendedores)
        Me.Controls.Add(Me.btnExportarDataProductos)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.GridControlProductos)
        Me.Controls.Add(Me.ChartControlVentas)
        Me.Controls.Add(Me.lbTotalUtilidad)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.lbTotalVenta)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.lbTotalInventario)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.cmbAnio)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.LabelControl170)
        Me.Name = "viewDashboard"
        Me.Size = New System.Drawing.Size(1090, 696)
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControlVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblVentasDiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSDASHBOARD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblVentasVendedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTopProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewVendedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl170 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents cmbAnio As ComboBox
    Friend WithEvents btnCargar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalInventario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalVenta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalUtilidad As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ChartControlVentas As DevExpress.XtraCharts.ChartControl
    Friend WithEvents TblVentasDiaBindingSource As BindingSource
    Friend WithEvents DSDASHBOARD As DSDASHBOARD
    Friend WithEvents GridControlProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProductos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblTopProductosBindingSource As BindingSource
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUNIDADES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVENTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUTILIDAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnExportarDataProductos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridControlVendedores As DevExpress.XtraGrid.GridControl
    Friend WithEvents TblVentasVendedorBindingSource As BindingSource
    Friend WithEvents GridViewVendedores As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colNOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUTILIDAD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnExportarDatosVendedores As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
End Class
