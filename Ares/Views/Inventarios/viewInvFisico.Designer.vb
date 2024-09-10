<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewInvFisico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewInvFisico))
        Me.txtCodProd = New DevExpress.XtraEditors.TextEdit()
        Me.txtBusqueda = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnBuscar = New DevExpress.XtraEditors.SimpleButton()
        Me.FlyoutPanelProductos = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.gridProductos = New DevExpress.XtraGrid.GridControl()
        Me.TblProductosInvFisicoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetInventarios = New Ares.DataSetInventarios()
        Me.GridViewProductos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODPROD2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCLAUNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridTempVentas = New DevExpress.XtraGrid.GridControl()
        Me.TblTempInvFisicoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewTemp = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONTEO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAJUSTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCorrelativo = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCoddoc = New System.Windows.Forms.ComboBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnExportarInventarioIdentificador = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNoContados = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtIdentificador = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.btnBorrarDatos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.gridExportNoContados = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gridContados = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.txtCodProd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBusqueda.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutPanelProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelProductos.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProductosInvFisicoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridTempVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTempInvFisicoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtIdentificador.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridExportNoContados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridContados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCodProd
        '
        Me.txtCodProd.Location = New System.Drawing.Point(131, 75)
        Me.txtCodProd.Name = "txtCodProd"
        Me.txtCodProd.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCodProd.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodProd.Properties.Appearance.Options.UseBackColor = True
        Me.txtCodProd.Properties.Appearance.Options.UseFont = True
        Me.txtCodProd.Size = New System.Drawing.Size(381, 26)
        Me.txtCodProd.TabIndex = 0
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(131, 114)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBusqueda.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusqueda.Properties.Appearance.Options.UseBackColor = True
        Me.txtBusqueda.Properties.Appearance.Options.UseFont = True
        Me.txtBusqueda.Size = New System.Drawing.Size(300, 26)
        Me.txtBusqueda.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl1.Location = New System.Drawing.Point(34, 78)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(56, 19)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Código:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl2.Location = New System.Drawing.Point(34, 117)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(87, 19)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Descripción:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl3.Location = New System.Drawing.Point(111, 26)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(218, 25)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "INVENTARIO FÍSICO"
        '
        'btnBuscar
        '
        Me.btnBuscar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnBuscar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnBuscar.Appearance.Options.UseBackColor = True
        Me.btnBuscar.Appearance.Options.UseForeColor = True
        Me.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(437, 112)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 27)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        '
        'FlyoutPanelProductos
        '
        Me.FlyoutPanelProductos.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelProductos.Location = New System.Drawing.Point(17, 254)
        Me.FlyoutPanelProductos.Name = "FlyoutPanelProductos"
        Me.FlyoutPanelProductos.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Bottom
        Me.FlyoutPanelProductos.Options.CloseOnOuterClick = True
        Me.FlyoutPanelProductos.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Bottom
        Me.FlyoutPanelProductos.OwnerControl = Me
        Me.FlyoutPanelProductos.Size = New System.Drawing.Size(1251, 378)
        Me.FlyoutPanelProductos.TabIndex = 6
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl4)
        Me.FlyoutPanelControl1.Controls.Add(Me.gridProductos)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelProductos
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(1251, 378)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(12, 11)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(362, 13)
        Me.LabelControl4.TabIndex = 1
        Me.LabelControl4.Text = "Enter o doble clic para seleccionar un producto e indicar el conteo del mismo"
        '
        'gridProductos
        '
        Me.gridProductos.DataSource = Me.TblProductosInvFisicoBindingSource
        Me.gridProductos.Location = New System.Drawing.Point(12, 32)
        Me.gridProductos.MainView = Me.GridViewProductos
        Me.gridProductos.Name = "gridProductos"
        Me.gridProductos.Size = New System.Drawing.Size(1234, 334)
        Me.gridProductos.TabIndex = 0
        Me.gridProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProductos})
        '
        'TblProductosInvFisicoBindingSource
        '
        Me.TblProductosInvFisicoBindingSource.DataMember = "tblProductosInvFisico"
        Me.TblProductosInvFisicoBindingSource.DataSource = Me.DataSetInventarios
        '
        'DataSetInventarios
        '
        Me.DataSetInventarios.DataSetName = "DataSetInventarios"
        Me.DataSetInventarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewProductos
        '
        Me.GridViewProductos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colCODPROD2, Me.colDESPROD, Me.colDESPROD2, Me.colCOSTO, Me.colDESMARCA, Me.colDESCLAUNO, Me.colSALDO})
        Me.GridViewProductos.GridControl = Me.gridProductos
        Me.GridViewProductos.Name = "GridViewProductos"
        Me.GridViewProductos.OptionsBehavior.Editable = False
        Me.GridViewProductos.OptionsCustomization.AllowGroup = False
        Me.GridViewProductos.OptionsView.ShowGroupPanel = False
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "CODIGO"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 115
        '
        'colCODPROD2
        '
        Me.colCODPROD2.FieldName = "CODPROD2"
        Me.colCODPROD2.Name = "colCODPROD2"
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "DESCRIPCION"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 313
        '
        'colDESPROD2
        '
        Me.colDESPROD2.FieldName = "DESPROD2"
        Me.colDESPROD2.Name = "colDESPROD2"
        '
        'colCOSTO
        '
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        Me.colCOSTO.Visible = True
        Me.colCOSTO.VisibleIndex = 2
        Me.colCOSTO.Width = 84
        '
        'colDESMARCA
        '
        Me.colDESMARCA.Caption = "MARCA"
        Me.colDESMARCA.FieldName = "DESMARCA"
        Me.colDESMARCA.Name = "colDESMARCA"
        Me.colDESMARCA.Visible = True
        Me.colDESMARCA.VisibleIndex = 3
        Me.colDESMARCA.Width = 171
        '
        'colDESCLAUNO
        '
        Me.colDESCLAUNO.Caption = "FABRICANTE"
        Me.colDESCLAUNO.FieldName = "DESCLAUNO"
        Me.colDESCLAUNO.Name = "colDESCLAUNO"
        Me.colDESCLAUNO.Visible = True
        Me.colDESCLAUNO.VisibleIndex = 4
        Me.colDESCLAUNO.Width = 173
        '
        'colSALDO
        '
        Me.colSALDO.Caption = "EXISTENCIA"
        Me.colSALDO.FieldName = "SALDO"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Visible = True
        Me.colSALDO.VisibleIndex = 5
        Me.colSALDO.Width = 120
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridTempVentas)
        Me.GroupControl1.Location = New System.Drawing.Point(17, 194)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1253, 471)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "Productos Contados"
        '
        'GridTempVentas
        '
        Me.GridTempVentas.DataSource = Me.TblTempInvFisicoBindingSource
        Me.GridTempVentas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTempVentas.Location = New System.Drawing.Point(2, 20)
        Me.GridTempVentas.MainView = Me.GridViewTemp
        Me.GridTempVentas.Name = "GridTempVentas"
        Me.GridTempVentas.Size = New System.Drawing.Size(1249, 449)
        Me.GridTempVentas.TabIndex = 0
        Me.GridTempVentas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTemp})
        '
        'TblTempInvFisicoBindingSource
        '
        Me.TblTempInvFisicoBindingSource.DataMember = "tblTempInvFisico"
        Me.TblTempInvFisicoBindingSource.DataSource = Me.DataSetInventarios
        '
        'GridViewTemp
        '
        Me.GridViewTemp.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD1, Me.colDESPROD1, Me.colCODMEDIDA, Me.colCONTEO, Me.colCOSTO1, Me.colTOTALPRECIO, Me.colAJUSTE, Me.colTOTALCOSTO, Me.colPRECIO, Me.colOBS})
        Me.GridViewTemp.GridControl = Me.GridTempVentas
        Me.GridViewTemp.Name = "GridViewTemp"
        Me.GridViewTemp.OptionsBehavior.Editable = False
        Me.GridViewTemp.OptionsView.ShowAutoFilterRow = True
        Me.GridViewTemp.OptionsView.ShowGroupPanel = False
        '
        'colCODPROD1
        '
        Me.colCODPROD1.Caption = "CODIGO"
        Me.colCODPROD1.FieldName = "CODPROD"
        Me.colCODPROD1.Name = "colCODPROD1"
        Me.colCODPROD1.Visible = True
        Me.colCODPROD1.VisibleIndex = 0
        Me.colCODPROD1.Width = 83
        '
        'colDESPROD1
        '
        Me.colDESPROD1.Caption = "DESCRIPCION"
        Me.colDESPROD1.FieldName = "DESPROD"
        Me.colDESPROD1.Name = "colDESPROD1"
        Me.colDESPROD1.Visible = True
        Me.colDESPROD1.VisibleIndex = 1
        Me.colDESPROD1.Width = 219
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.Caption = "MEDIDA"
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 2
        Me.colCODMEDIDA.Width = 68
        '
        'colCONTEO
        '
        Me.colCONTEO.FieldName = "CONTEO"
        Me.colCONTEO.Name = "colCONTEO"
        Me.colCONTEO.Visible = True
        Me.colCONTEO.VisibleIndex = 3
        Me.colCONTEO.Width = 79
        '
        'colCOSTO1
        '
        Me.colCOSTO1.FieldName = "COSTO"
        Me.colCOSTO1.Name = "colCOSTO1"
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.Caption = "COSTOCONTEO"
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 4
        Me.colTOTALPRECIO.Width = 101
        '
        'colAJUSTE
        '
        Me.colAJUSTE.FieldName = "AJUSTE"
        Me.colAJUSTE.Name = "colAJUSTE"
        Me.colAJUSTE.Visible = True
        Me.colAJUSTE.VisibleIndex = 5
        Me.colAJUSTE.Width = 57
        '
        'colTOTALCOSTO
        '
        Me.colTOTALCOSTO.Caption = "COSTOAJUSTE"
        Me.colTOTALCOSTO.FieldName = "TOTALCOSTO"
        Me.colTOTALCOSTO.Name = "colTOTALCOSTO"
        Me.colTOTALCOSTO.Visible = True
        Me.colTOTALCOSTO.VisibleIndex = 6
        Me.colTOTALCOSTO.Width = 99
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        '
        'colOBS
        '
        Me.colOBS.Caption = "OBSERVACIONES"
        Me.colOBS.FieldName = "OBS"
        Me.colOBS.Name = "colOBS"
        Me.colOBS.Visible = True
        Me.colOBS.VisibleIndex = 7
        Me.colOBS.Width = 288
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl5.Location = New System.Drawing.Point(16, 30)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(68, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "DOCUMENTO:"
        '
        'lbCorrelativo
        '
        Me.lbCorrelativo.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrelativo.Location = New System.Drawing.Point(287, 39)
        Me.lbCorrelativo.Name = "lbCorrelativo"
        Me.lbCorrelativo.Size = New System.Drawing.Size(132, 23)
        Me.lbCorrelativo.TabIndex = 9
        Me.lbCorrelativo.Text = "00000000000"
        '
        'cmbCoddoc
        '
        Me.cmbCoddoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCoddoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCoddoc.FormattingEnabled = True
        Me.cmbCoddoc.Location = New System.Drawing.Point(110, 27)
        Me.cmbCoddoc.Name = "cmbCoddoc"
        Me.cmbCoddoc.Size = New System.Drawing.Size(138, 21)
        Me.cmbCoddoc.TabIndex = 10
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl7.Location = New System.Drawing.Point(16, 57)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl7.TabIndex = 11
        Me.LabelControl7.Text = "FECHA:"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(110, 54)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(138, 20)
        Me.txtFecha.TabIndex = 12
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.btnExportarInventarioIdentificador)
        Me.GroupControl2.Controls.Add(Me.btnNoContados)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.txtIdentificador)
        Me.GroupControl2.Controls.Add(Me.LabelControl9)
        Me.GroupControl2.Controls.Add(Me.txtObs)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.cmbVendedor)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.txtFecha)
        Me.GroupControl2.Controls.Add(Me.lbCorrelativo)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.cmbCoddoc)
        Me.GroupControl2.Location = New System.Drawing.Point(550, 14)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(720, 174)
        Me.GroupControl2.TabIndex = 13
        Me.GroupControl2.Text = "Datos el Documento"
        '
        'btnExportarInventarioIdentificador
        '
        Me.btnExportarInventarioIdentificador.Image = CType(resources.GetObject("btnExportarInventarioIdentificador.Image"), System.Drawing.Image)
        Me.btnExportarInventarioIdentificador.Location = New System.Drawing.Point(493, 125)
        Me.btnExportarInventarioIdentificador.Name = "btnExportarInventarioIdentificador"
        Me.btnExportarInventarioIdentificador.Size = New System.Drawing.Size(184, 23)
        Me.btnExportarInventarioIdentificador.TabIndex = 20
        Me.btnExportarInventarioIdentificador.Text = "Exportar Inventario"
        '
        'btnNoContados
        '
        Me.btnNoContados.Image = CType(resources.GetObject("btnNoContados.Image"), System.Drawing.Image)
        Me.btnNoContados.Location = New System.Drawing.Point(493, 96)
        Me.btnNoContados.Name = "btnNoContados"
        Me.btnNoContados.Size = New System.Drawing.Size(184, 23)
        Me.btnNoContados.TabIndex = 19
        Me.btnNoContados.Text = "Exportar No Contados"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl6.Location = New System.Drawing.Point(493, 51)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(179, 13)
        Me.LabelControl6.TabIndex = 18
        Me.LabelControl6.Text = "IDENTIFICADOR DE INVENTARIO:"
        '
        'txtIdentificador
        '
        Me.txtIdentificador.Location = New System.Drawing.Point(493, 70)
        Me.txtIdentificador.Name = "txtIdentificador"
        Me.txtIdentificador.Size = New System.Drawing.Size(184, 20)
        Me.txtIdentificador.TabIndex = 17
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl9.Location = New System.Drawing.Point(16, 110)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(88, 13)
        Me.LabelControl9.TabIndex = 16
        Me.LabelControl9.Text = "OBSERVACIONES:"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(110, 110)
        Me.txtObs.MaxLength = 255
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(320, 38)
        Me.txtObs.TabIndex = 15
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl8.Location = New System.Drawing.Point(16, 83)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl8.TabIndex = 13
        Me.LabelControl8.Text = "REALIZADO:"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(110, 80)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(320, 21)
        Me.cmbVendedor.TabIndex = 14
        '
        'btnBorrarDatos
        '
        Me.btnBorrarDatos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnBorrarDatos.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnBorrarDatos.Appearance.Options.UseBackColor = True
        Me.btnBorrarDatos.Appearance.Options.UseForeColor = True
        Me.btnBorrarDatos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnBorrarDatos.Image = CType(resources.GetObject("btnBorrarDatos.Image"), System.Drawing.Image)
        Me.btnBorrarDatos.Location = New System.Drawing.Point(204, 154)
        Me.btnBorrarDatos.Name = "btnBorrarDatos"
        Me.btnBorrarDatos.Size = New System.Drawing.Size(151, 34)
        Me.btnBorrarDatos.TabIndex = 14
        Me.btnBorrarDatos.Text = "BORRAR DATOS"
        '
        'btnGuardar
        '
        Me.btnGuardar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardar.Appearance.Options.UseBackColor = True
        Me.btnGuardar.Appearance.Options.UseForeColor = True
        Me.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(361, 154)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(151, 34)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.Text = "GUARDAR"
        '
        'gridExportNoContados
        '
        Me.gridExportNoContados.Location = New System.Drawing.Point(34, 272)
        Me.gridExportNoContados.MainView = Me.GridView1
        Me.gridExportNoContados.Name = "gridExportNoContados"
        Me.gridExportNoContados.Size = New System.Drawing.Size(986, 200)
        Me.gridExportNoContados.TabIndex = 16
        Me.gridExportNoContados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridExportNoContados
        Me.GridView1.Name = "GridView1"
        '
        'gridContados
        '
        Me.gridContados.Location = New System.Drawing.Point(34, 275)
        Me.gridContados.MainView = Me.GridView2
        Me.gridContados.Name = "gridContados"
        Me.gridContados.Size = New System.Drawing.Size(975, 200)
        Me.gridContados.TabIndex = 17
        Me.gridContados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridContados
        Me.GridView2.Name = "GridView2"
        '
        'viewInvFisico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.FlyoutPanelProductos)
        Me.Controls.Add(Me.btnBorrarDatos)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.txtCodProd)
        Me.Controls.Add(Me.gridExportNoContados)
        Me.Controls.Add(Me.gridContados)
        Me.Name = "viewInvFisico"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.txtCodProd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBusqueda.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutPanelProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelProductos.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.FlyoutPanelControl1.PerformLayout()
        CType(Me.gridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProductosInvFisicoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridTempVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTempInvFisicoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtIdentificador.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridExportNoContados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridContados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCodProd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtBusqueda As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnBuscar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FlyoutPanelProductos As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents gridProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProductos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblProductosInvFisicoBindingSource As BindingSource
    Friend WithEvents DataSetInventarios As DataSetInventarios
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODPROD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCLAUNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridTempVentas As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTemp As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lbCorrelativo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCoddoc As ComboBox
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbVendedor As ComboBox
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As TextBox
    Friend WithEvents TblTempInvFisicoBindingSource As BindingSource
    Friend WithEvents colCODPROD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONTEO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAJUSTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOBS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnBorrarDatos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtIdentificador As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnNoContados As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridExportNoContados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExportarInventarioIdentificador As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridContados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
