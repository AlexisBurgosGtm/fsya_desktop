<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewTrasladoInventario
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
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement3 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement4 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement5 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement6 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.GridTransferirDisponibles = New DevExpress.XtraGrid.GridControl()
        Me.TileViewTransferirDisponible = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.lbTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.SwitchTipoTraslado = New DevExpress.XtraEditors.ToggleSwitch()
        Me.cmbAnioDocumento = New System.Windows.Forms.ComboBox()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMesDocumento = New System.Windows.Forms.ComboBox()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridTrasladosPendientes = New DevExpress.XtraGrid.GridControl()
        Me.TblTrasladosPendientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetInventarios = New Ares.DataSetInventarios()
        Me.GridViewTrasladosPendientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMPNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMPNOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBSMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODEMBARQUE = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GridTransferirDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileViewTransferirDisponible, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwitchTipoTraslado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GridTrasladosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTrasladosPendientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTrasladosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.GridTransferirDisponibles)
        Me.GroupControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl4.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(1297, 538)
        Me.GroupControl4.TabIndex = 57
        Me.GroupControl4.Text = "Doble clic para enviar una salida"
        '
        'GridTransferirDisponibles
        '
        Me.GridTransferirDisponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTransferirDisponibles.Location = New System.Drawing.Point(2, 20)
        Me.GridTransferirDisponibles.MainView = Me.TileViewTransferirDisponible
        Me.GridTransferirDisponibles.Name = "GridTransferirDisponibles"
        Me.GridTransferirDisponibles.Size = New System.Drawing.Size(1293, 516)
        Me.GridTransferirDisponibles.TabIndex = 52
        Me.GridTransferirDisponibles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TileViewTransferirDisponible})
        '
        'TileViewTransferirDisponible
        '
        Me.TileViewTransferirDisponible.GridControl = Me.GridTransferirDisponibles
        Me.TileViewTransferirDisponible.Name = "TileViewTransferirDisponible"
        Me.TileViewTransferirDisponible.OptionsFind.AlwaysVisible = True
        Me.TileViewTransferirDisponible.OptionsTiles.ColumnCount = 3
        Me.TileViewTransferirDisponible.OptionsTiles.HighlightFocusedTileOnGridLoad = True
        Me.TileViewTransferirDisponible.OptionsTiles.IndentBetweenItems = 10
        Me.TileViewTransferirDisponible.OptionsTiles.ItemSize = New System.Drawing.Size(250, 120)
        Me.TileViewTransferirDisponible.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileViewTransferirDisponible.OptionsTiles.RowCount = 100
        Me.TileViewTransferirDisponible.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways
        TileViewItemElement1.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement1.Appearance.Normal.Options.UseFont = True
        TileViewItemElement1.Text = "001"
        TileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopRight
        TileViewItemElement2.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement2.Appearance.Normal.Options.UseFont = True
        TileViewItemElement2.Text = "Q 999,999.00"
        TileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight
        TileViewItemElement3.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        TileViewItemElement3.Appearance.Normal.Options.UseFont = True
        TileViewItemElement3.Text = "01/01/2017"
        TileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement3.TextLocation = New System.Drawing.Point(50, 20)
        TileViewItemElement4.Text = "Anotaciones disponibles"
        TileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement4.TextLocation = New System.Drawing.Point(0, 40)
        TileViewItemElement5.Text = "Salida No. : "
        TileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement6.Text = "Fecha:"
        TileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement6.TextLocation = New System.Drawing.Point(0, 20)
        Me.TileViewTransferirDisponible.TileTemplate.Add(TileViewItemElement1)
        Me.TileViewTransferirDisponible.TileTemplate.Add(TileViewItemElement2)
        Me.TileViewTransferirDisponible.TileTemplate.Add(TileViewItemElement3)
        Me.TileViewTransferirDisponible.TileTemplate.Add(TileViewItemElement4)
        Me.TileViewTransferirDisponible.TileTemplate.Add(TileViewItemElement5)
        Me.TileViewTransferirDisponible.TileTemplate.Add(TileViewItemElement6)
        '
        'lbTitulo
        '
        Me.lbTitulo.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitulo.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbTitulo.Location = New System.Drawing.Point(128, 39)
        Me.lbTitulo.Name = "lbTitulo"
        Me.lbTitulo.Size = New System.Drawing.Size(202, 33)
        Me.lbTitulo.TabIndex = 55
        Me.lbTitulo.Text = "Transferir Salida "
        '
        'SwitchTipoTraslado
        '
        Me.SwitchTipoTraslado.Location = New System.Drawing.Point(1077, 81)
        Me.SwitchTipoTraslado.Name = "SwitchTipoTraslado"
        Me.SwitchTipoTraslado.Properties.OffText = "TRASLADO ONLINE"
        Me.SwitchTipoTraslado.Properties.OnText = "TRASLADO ENTRE EMPRESAS"
        Me.SwitchTipoTraslado.Size = New System.Drawing.Size(235, 24)
        Me.SwitchTipoTraslado.TabIndex = 59
        '
        'cmbAnioDocumento
        '
        Me.cmbAnioDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAnioDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAnioDocumento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnioDocumento.ForeColor = System.Drawing.Color.Black
        Me.cmbAnioDocumento.FormattingEnabled = True
        Me.cmbAnioDocumento.Items.AddRange(New Object() {"2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbAnioDocumento.Location = New System.Drawing.Point(985, 81)
        Me.cmbAnioDocumento.Name = "cmbAnioDocumento"
        Me.cmbAnioDocumento.Size = New System.Drawing.Size(86, 24)
        Me.cmbAnioDocumento.TabIndex = 198
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl13.Location = New System.Drawing.Point(745, 83)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(104, 16)
        Me.LabelControl13.TabIndex = 197
        Me.LabelControl13.Text = "Mes de Trabajo:"
        '
        'cmbMesDocumento
        '
        Me.cmbMesDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMesDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMesDocumento.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesDocumento.ForeColor = System.Drawing.Color.Black
        Me.cmbMesDocumento.FormattingEnabled = True
        Me.cmbMesDocumento.Location = New System.Drawing.Point(855, 81)
        Me.cmbMesDocumento.Name = "cmbMesDocumento"
        Me.cmbMesDocumento.Size = New System.Drawing.Size(124, 24)
        Me.cmbMesDocumento.TabIndex = 196
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Location = New System.Drawing.Point(16, 111)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1303, 566)
        Me.XtraTabControl1.TabIndex = 199
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.GroupControl4)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1297, 538)
        Me.XtraTabPage1.Text = "Salidas Disponibles"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.LabelControl1)
        Me.XtraTabPage2.Controls.Add(Me.GridTrasladosPendientes)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1297, 538)
        Me.XtraTabPage2.Text = "Traslados Actuales en la Nube"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Location = New System.Drawing.Point(15, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(935, 14)
        Me.LabelControl1.TabIndex = 198
        Me.LabelControl1.Text = "Traslados cargados en la nube (pendientes de generar)   //    Doble clic para ELI" &
    "MINAR  (Solo se eliminará de la nube, permanecerá en el lugar de origen)"
        '
        'GridTrasladosPendientes
        '
        Me.GridTrasladosPendientes.DataSource = Me.TblTrasladosPendientesBindingSource
        Me.GridTrasladosPendientes.Location = New System.Drawing.Point(18, 52)
        Me.GridTrasladosPendientes.MainView = Me.GridViewTrasladosPendientes
        Me.GridTrasladosPendientes.Name = "GridTrasladosPendientes"
        Me.GridTrasladosPendientes.Size = New System.Drawing.Size(1263, 468)
        Me.GridTrasladosPendientes.TabIndex = 0
        Me.GridTrasladosPendientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTrasladosPendientes})
        '
        'TblTrasladosPendientesBindingSource
        '
        Me.TblTrasladosPendientesBindingSource.DataMember = "tblTrasladosPendientes"
        Me.TblTrasladosPendientesBindingSource.DataSource = Me.DataSetInventarios
        '
        'DataSetInventarios
        '
        Me.DataSetInventarios.DataSetName = "DataSetInventarios"
        Me.DataSetInventarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewTrasladosPendientes
        '
        Me.GridViewTrasladosPendientes.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODDOC, Me.colCORRELATIVO, Me.colFECHA, Me.colTOTALCOSTO, Me.colTOTALPRECIO, Me.colOBS, Me.colEMPNIT, Me.colEMPNOMBRE, Me.colOBSMARCA, Me.colCODEMBARQUE})
        Me.GridViewTrasladosPendientes.GridControl = Me.GridTrasladosPendientes
        Me.GridViewTrasladosPendientes.Name = "GridViewTrasladosPendientes"
        Me.GridViewTrasladosPendientes.OptionsBehavior.Editable = False
        Me.GridViewTrasladosPendientes.OptionsView.ShowAutoFilterRow = True
        Me.GridViewTrasladosPendientes.OptionsView.ShowGroupPanel = False
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 0
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 2
        '
        'colTOTALCOSTO
        '
        Me.colTOTALCOSTO.FieldName = "TOTALCOSTO"
        Me.colTOTALCOSTO.Name = "colTOTALCOSTO"
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.Caption = "IMPORTE"
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 3
        Me.colTOTALPRECIO.Width = 104
        '
        'colOBS
        '
        Me.colOBS.FieldName = "OBS"
        Me.colOBS.Name = "colOBS"
        Me.colOBS.Visible = True
        Me.colOBS.VisibleIndex = 4
        '
        'colEMPNIT
        '
        Me.colEMPNIT.FieldName = "EMPNIT"
        Me.colEMPNIT.Name = "colEMPNIT"
        '
        'colEMPNOMBRE
        '
        Me.colEMPNOMBRE.Caption = "DESTINO"
        Me.colEMPNOMBRE.FieldName = "EMPNOMBRE"
        Me.colEMPNOMBRE.Name = "colEMPNOMBRE"
        Me.colEMPNOMBRE.Visible = True
        Me.colEMPNOMBRE.VisibleIndex = 5
        Me.colEMPNOMBRE.Width = 186
        '
        'colOBSMARCA
        '
        Me.colOBSMARCA.Caption = "ORIGEN"
        Me.colOBSMARCA.FieldName = "OBSMARCA"
        Me.colOBSMARCA.Name = "colOBSMARCA"
        Me.colOBSMARCA.Visible = True
        Me.colOBSMARCA.VisibleIndex = 6
        Me.colOBSMARCA.Width = 204
        '
        'colCODEMBARQUE
        '
        Me.colCODEMBARQUE.FieldName = "CODEMBARQUE"
        Me.colCODEMBARQUE.Name = "colCODEMBARQUE"
        '
        'viewTrasladoInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.cmbAnioDocumento)
        Me.Controls.Add(Me.LabelControl13)
        Me.Controls.Add(Me.cmbMesDocumento)
        Me.Controls.Add(Me.SwitchTipoTraslado)
        Me.Controls.Add(Me.lbTitulo)
        Me.Name = "viewTrasladoInventario"
        Me.Size = New System.Drawing.Size(1340, 696)
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.GridTransferirDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileViewTransferirDisponible, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwitchTipoTraslado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage2.PerformLayout()
        CType(Me.GridTrasladosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTrasladosPendientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTrasladosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridTransferirDisponibles As DevExpress.XtraGrid.GridControl
    Friend WithEvents TileViewTransferirDisponible As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents lbTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SwitchTipoTraslado As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents cmbAnioDocumento As ComboBox
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbMesDocumento As ComboBox
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridTrasladosPendientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTrasladosPendientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblTrasladosPendientesBindingSource As BindingSource
    Friend WithEvents DataSetInventarios As DataSetInventarios
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOBS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPNOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOBSMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODEMBARQUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
