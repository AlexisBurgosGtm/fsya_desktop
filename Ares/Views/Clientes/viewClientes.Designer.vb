<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewClientes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewClientes))
        Me.GridClientes = New DevExpress.XtraGrid.GridControl()
        Me.TblClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewClientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMBRECLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDIRCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESMUNICIPIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESDEPARTAMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCATEGORIA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTELEFONOCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMAILCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHABILITADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHAINICIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODRUTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESRUTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNEGOCIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDIAVISITA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLASTSALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl8 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.lbClienteLong = New DevExpress.XtraEditors.TextEdit()
        Me.lbClienteLat = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClienteNombreNegocio = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbClienteTipoNegocio = New System.Windows.Forms.ComboBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbClienteDiaVisita = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClientesCodclie = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoPrecio = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClientesProvincia = New DevExpress.XtraEditors.TextEdit()
        Me.lbClientesRuta = New DevExpress.XtraEditors.LabelControl()
        Me.cmbClientesRuta = New System.Windows.Forms.ComboBox()
        Me.cmdClientesCancelarEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl159 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl158 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbClientesDepartamento = New System.Windows.Forms.ComboBox()
        Me.cmdClientesGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbClientesMunicipio = New System.Windows.Forms.ComboBox()
        Me.LabelControl152 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClientesEmail = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl153 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClientesTelefonos = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl155 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClientesDireccion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl156 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClientesNombre = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl157 = New DevExpress.XtraEditors.LabelControl()
        Me.txtClientesNit = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl150 = New DevExpress.XtraEditors.LabelControl()
        Me.RadialMenuClientes = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.BarButtonItemClientesVerInfo = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemClientesEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemClientesVentasMes = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemClientesCalificar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemClientesEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemRptProductosRes = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemRptProductosDetalle = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.FlyoutNuevoCliente = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnObtenerCenso = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl8.SuspendLayout()
        CType(Me.lbClienteLong.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lbClienteLat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClienteNombreNegocio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientesCodclie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientesProvincia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientesEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientesTelefonos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientesDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientesNombre.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtClientesNit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadialMenuClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutNuevoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutNuevoCliente.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridClientes
        '
        Me.GridClientes.DataSource = Me.TblClientesBindingSource
        Me.GridClientes.Location = New System.Drawing.Point(16, 103)
        Me.GridClientes.MainView = Me.GridViewClientes
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.Size = New System.Drawing.Size(1025, 523)
        Me.GridClientes.TabIndex = 173
        Me.GridClientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewClientes})
        '
        'TblClientesBindingSource
        '
        Me.TblClientesBindingSource.DataMember = "tblClientes"
        Me.TblClientesBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewClientes
        '
        Me.GridViewClientes.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODCLIENTE, Me.colNIT, Me.colNOMBRECLIENTE, Me.colDIRCLIENTE, Me.colDESMUNICIPIO, Me.colDESDEPARTAMENTO, Me.colSALDO, Me.colCATEGORIA, Me.colTELEFONOCLIENTE, Me.colEMAILCLIENTE, Me.colHABILITADO, Me.colFECHAINICIO, Me.colCODRUTA, Me.colDESRUTA, Me.colNEGOCIO, Me.colDIAVISITA, Me.colLASTSALE})
        Me.GridViewClientes.GridControl = Me.GridClientes
        Me.GridViewClientes.Name = "GridViewClientes"
        Me.GridViewClientes.OptionsBehavior.Editable = False
        Me.GridViewClientes.OptionsFind.FindNullPrompt = "Escriba para buscar en Clientes..."
        Me.GridViewClientes.OptionsView.ShowAutoFilterRow = True
        '
        'colCODCLIENTE
        '
        Me.colCODCLIENTE.Caption = "Código"
        Me.colCODCLIENTE.FieldName = "CODCLIENTE"
        Me.colCODCLIENTE.Name = "colCODCLIENTE"
        Me.colCODCLIENTE.Width = 89
        '
        'colNIT
        '
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 0
        Me.colNIT.Width = 78
        '
        'colNOMBRECLIENTE
        '
        Me.colNOMBRECLIENTE.Caption = "Nombre"
        Me.colNOMBRECLIENTE.FieldName = "NOMBRECLIENTE"
        Me.colNOMBRECLIENTE.Name = "colNOMBRECLIENTE"
        Me.colNOMBRECLIENTE.Visible = True
        Me.colNOMBRECLIENTE.VisibleIndex = 1
        Me.colNOMBRECLIENTE.Width = 131
        '
        'colDIRCLIENTE
        '
        Me.colDIRCLIENTE.Caption = "Dirección"
        Me.colDIRCLIENTE.FieldName = "DIRCLIENTE"
        Me.colDIRCLIENTE.Name = "colDIRCLIENTE"
        Me.colDIRCLIENTE.Visible = True
        Me.colDIRCLIENTE.VisibleIndex = 2
        Me.colDIRCLIENTE.Width = 148
        '
        'colDESMUNICIPIO
        '
        Me.colDESMUNICIPIO.Caption = "Municipio"
        Me.colDESMUNICIPIO.FieldName = "DESMUNICIPIO"
        Me.colDESMUNICIPIO.Name = "colDESMUNICIPIO"
        Me.colDESMUNICIPIO.Visible = True
        Me.colDESMUNICIPIO.VisibleIndex = 3
        Me.colDESMUNICIPIO.Width = 95
        '
        'colDESDEPARTAMENTO
        '
        Me.colDESDEPARTAMENTO.Caption = "Departamento"
        Me.colDESDEPARTAMENTO.FieldName = "DESDEPARTAMENTO"
        Me.colDESDEPARTAMENTO.Name = "colDESDEPARTAMENTO"
        Me.colDESDEPARTAMENTO.Width = 86
        '
        'colSALDO
        '
        Me.colSALDO.Caption = "Codigo"
        Me.colSALDO.FieldName = "CODCLIE"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Visible = True
        Me.colSALDO.VisibleIndex = 7
        '
        'colCATEGORIA
        '
        Me.colCATEGORIA.Caption = "Pr"
        Me.colCATEGORIA.FieldName = "CATEGORIA"
        Me.colCATEGORIA.Name = "colCATEGORIA"
        Me.colCATEGORIA.Width = 21
        '
        'colTELEFONOCLIENTE
        '
        Me.colTELEFONOCLIENTE.Caption = "Telefono"
        Me.colTELEFONOCLIENTE.FieldName = "TELEFONOCLIENTE"
        Me.colTELEFONOCLIENTE.Name = "colTELEFONOCLIENTE"
        Me.colTELEFONOCLIENTE.Visible = True
        Me.colTELEFONOCLIENTE.VisibleIndex = 4
        Me.colTELEFONOCLIENTE.Width = 110
        '
        'colEMAILCLIENTE
        '
        Me.colEMAILCLIENTE.Caption = "Email"
        Me.colEMAILCLIENTE.FieldName = "EMAILCLIENTE"
        Me.colEMAILCLIENTE.Name = "colEMAILCLIENTE"
        Me.colEMAILCLIENTE.Width = 118
        '
        'colHABILITADO
        '
        Me.colHABILITADO.Caption = "Activo"
        Me.colHABILITADO.FieldName = "HABILITADO"
        Me.colHABILITADO.Name = "colHABILITADO"
        Me.colHABILITADO.Visible = True
        Me.colHABILITADO.VisibleIndex = 5
        Me.colHABILITADO.Width = 52
        '
        'colFECHAINICIO
        '
        Me.colFECHAINICIO.Caption = "Inicio"
        Me.colFECHAINICIO.FieldName = "FECHAINICIO"
        Me.colFECHAINICIO.Name = "colFECHAINICIO"
        Me.colFECHAINICIO.Visible = True
        Me.colFECHAINICIO.VisibleIndex = 6
        Me.colFECHAINICIO.Width = 83
        '
        'colCODRUTA
        '
        Me.colCODRUTA.FieldName = "CODRUTA"
        Me.colCODRUTA.Name = "colCODRUTA"
        '
        'colDESRUTA
        '
        Me.colDESRUTA.Caption = "Ruta"
        Me.colDESRUTA.FieldName = "DESRUTA"
        Me.colDESRUTA.Name = "colDESRUTA"
        Me.colDESRUTA.Width = 89
        '
        'colNEGOCIO
        '
        Me.colNEGOCIO.Caption = "Negocio"
        Me.colNEGOCIO.FieldName = "NEGOCIO"
        Me.colNEGOCIO.Name = "colNEGOCIO"
        Me.colNEGOCIO.Width = 114
        '
        'colDIAVISITA
        '
        Me.colDIAVISITA.Caption = "Visita"
        Me.colDIAVISITA.FieldName = "DIAVISITA"
        Me.colDIAVISITA.Name = "colDIAVISITA"
        '
        'colLASTSALE
        '
        Me.colLASTSALE.Caption = "UltimaV"
        Me.colLASTSALE.FieldName = "LASTSALE"
        Me.colLASTSALE.Name = "colLASTSALE"
        Me.colLASTSALE.Visible = True
        Me.colLASTSALE.VisibleIndex = 8
        '
        'GroupControl8
        '
        Me.GroupControl8.Controls.Add(Me.LabelControl8)
        Me.GroupControl8.Controls.Add(Me.lbClienteLong)
        Me.GroupControl8.Controls.Add(Me.lbClienteLat)
        Me.GroupControl8.Controls.Add(Me.LabelControl7)
        Me.GroupControl8.Controls.Add(Me.LabelControl6)
        Me.GroupControl8.Controls.Add(Me.txtClienteNombreNegocio)
        Me.GroupControl8.Controls.Add(Me.LabelControl5)
        Me.GroupControl8.Controls.Add(Me.cmbClienteTipoNegocio)
        Me.GroupControl8.Controls.Add(Me.LabelControl4)
        Me.GroupControl8.Controls.Add(Me.cmbClienteDiaVisita)
        Me.GroupControl8.Controls.Add(Me.LabelControl3)
        Me.GroupControl8.Controls.Add(Me.txtClientesCodclie)
        Me.GroupControl8.Controls.Add(Me.LabelControl2)
        Me.GroupControl8.Controls.Add(Me.cmbTipoPrecio)
        Me.GroupControl8.Controls.Add(Me.LabelControl1)
        Me.GroupControl8.Controls.Add(Me.txtClientesProvincia)
        Me.GroupControl8.Controls.Add(Me.lbClientesRuta)
        Me.GroupControl8.Controls.Add(Me.cmbClientesRuta)
        Me.GroupControl8.Controls.Add(Me.cmdClientesCancelarEdit)
        Me.GroupControl8.Controls.Add(Me.LabelControl159)
        Me.GroupControl8.Controls.Add(Me.LabelControl158)
        Me.GroupControl8.Controls.Add(Me.cmbClientesDepartamento)
        Me.GroupControl8.Controls.Add(Me.cmdClientesGuardar)
        Me.GroupControl8.Controls.Add(Me.cmbClientesMunicipio)
        Me.GroupControl8.Controls.Add(Me.LabelControl152)
        Me.GroupControl8.Controls.Add(Me.txtClientesEmail)
        Me.GroupControl8.Controls.Add(Me.LabelControl153)
        Me.GroupControl8.Controls.Add(Me.txtClientesTelefonos)
        Me.GroupControl8.Controls.Add(Me.LabelControl155)
        Me.GroupControl8.Controls.Add(Me.txtClientesDireccion)
        Me.GroupControl8.Controls.Add(Me.LabelControl156)
        Me.GroupControl8.Controls.Add(Me.txtClientesNombre)
        Me.GroupControl8.Controls.Add(Me.LabelControl157)
        Me.GroupControl8.Controls.Add(Me.txtClientesNit)
        Me.GroupControl8.Location = New System.Drawing.Point(7, 26)
        Me.GroupControl8.Name = "GroupControl8"
        Me.GroupControl8.Size = New System.Drawing.Size(486, 596)
        Me.GroupControl8.TabIndex = 172
        Me.GroupControl8.Text = "Nuevo Cliente"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(498, 478)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(53, 16)
        Me.LabelControl8.TabIndex = 188
        Me.LabelControl8.Text = "Longitud:"
        '
        'lbClienteLong
        '
        Me.lbClienteLong.Location = New System.Drawing.Point(577, 476)
        Me.lbClienteLong.Name = "lbClienteLong"
        Me.lbClienteLong.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClienteLong.Properties.Appearance.Options.UseFont = True
        Me.lbClienteLong.Properties.Mask.EditMask = "n12"
        Me.lbClienteLong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.lbClienteLong.Size = New System.Drawing.Size(210, 20)
        Me.lbClienteLong.TabIndex = 187
        Me.lbClienteLong.TabStop = False
        '
        'lbClienteLat
        '
        Me.lbClienteLat.Location = New System.Drawing.Point(577, 450)
        Me.lbClienteLat.Name = "lbClienteLat"
        Me.lbClienteLat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClienteLat.Properties.Appearance.Options.UseFont = True
        Me.lbClienteLat.Properties.Mask.EditMask = "n12"
        Me.lbClienteLat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.lbClienteLat.Size = New System.Drawing.Size(210, 20)
        Me.lbClienteLat.TabIndex = 186
        Me.lbClienteLat.TabStop = False
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(498, 451)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(43, 16)
        Me.LabelControl7.TabIndex = 183
        Me.LabelControl7.Text = "Latitud:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(691, 83)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(120, 16)
        Me.LabelControl6.TabIndex = 182
        Me.LabelControl6.Text = "Nombre del Negocio:"
        '
        'txtClienteNombreNegocio
        '
        Me.txtClienteNombreNegocio.Location = New System.Drawing.Point(691, 105)
        Me.txtClienteNombreNegocio.Name = "txtClienteNombreNegocio"
        Me.txtClienteNombreNegocio.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClienteNombreNegocio.Properties.Appearance.Options.UseFont = True
        Me.txtClienteNombreNegocio.Size = New System.Drawing.Size(284, 26)
        Me.txtClienteNombreNegocio.TabIndex = 3
        Me.txtClienteNombreNegocio.TabStop = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(510, 83)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(79, 16)
        Me.LabelControl5.TabIndex = 180
        Me.LabelControl5.Text = "Tipo Negocio:"
        '
        'cmbClienteTipoNegocio
        '
        Me.cmbClienteTipoNegocio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbClienteTipoNegocio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClienteTipoNegocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClienteTipoNegocio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClienteTipoNegocio.FormattingEnabled = True
        Me.cmbClienteTipoNegocio.Location = New System.Drawing.Point(510, 105)
        Me.cmbClienteTipoNegocio.Name = "cmbClienteTipoNegocio"
        Me.cmbClienteTipoNegocio.Size = New System.Drawing.Size(167, 27)
        Me.cmbClienteTipoNegocio.TabIndex = 2
        Me.cmbClienteTipoNegocio.TabStop = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(510, 130)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(58, 16)
        Me.LabelControl4.TabIndex = 178
        Me.LabelControl4.Text = "Día Visita:"
        '
        'cmbClienteDiaVisita
        '
        Me.cmbClienteDiaVisita.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbClienteDiaVisita.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClienteDiaVisita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClienteDiaVisita.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClienteDiaVisita.FormattingEnabled = True
        Me.cmbClienteDiaVisita.Location = New System.Drawing.Point(510, 152)
        Me.cmbClienteDiaVisita.Name = "cmbClienteDiaVisita"
        Me.cmbClienteDiaVisita.Size = New System.Drawing.Size(167, 27)
        Me.cmbClienteDiaVisita.TabIndex = 5
        Me.cmbClienteDiaVisita.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(501, 35)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(44, 16)
        Me.LabelControl3.TabIndex = 176
        Me.LabelControl3.Text = "Código:"
        '
        'txtClientesCodclie
        '
        Me.txtClientesCodclie.Location = New System.Drawing.Point(552, 32)
        Me.txtClientesCodclie.Name = "txtClientesCodclie"
        Me.txtClientesCodclie.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientesCodclie.Properties.Appearance.Options.UseFont = True
        Me.txtClientesCodclie.Properties.Mask.EditMask = "n0"
        Me.txtClientesCodclie.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtClientesCodclie.Size = New System.Drawing.Size(177, 26)
        Me.txtClientesCodclie.TabIndex = 1
        Me.txtClientesCodclie.TabStop = False
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(721, 418)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(87, 16)
        Me.LabelControl2.TabIndex = 174
        Me.LabelControl2.Text = "Tipo de Precio:"
        '
        'cmbTipoPrecio
        '
        Me.cmbTipoPrecio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoPrecio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrecio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPrecio.FormattingEnabled = True
        Me.cmbTipoPrecio.Location = New System.Drawing.Point(722, 440)
        Me.cmbTipoPrecio.Name = "cmbTipoPrecio"
        Me.cmbTipoPrecio.Size = New System.Drawing.Size(181, 27)
        Me.cmbTipoPrecio.TabIndex = 13
        Me.cmbTipoPrecio.TabStop = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(18, 226)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(66, 16)
        Me.LabelControl1.TabIndex = 172
        Me.LabelControl1.Text = "Referencia:"
        '
        'txtClientesProvincia
        '
        Me.txtClientesProvincia.EnterMoveNextControl = True
        Me.txtClientesProvincia.Location = New System.Drawing.Point(18, 245)
        Me.txtClientesProvincia.Name = "txtClientesProvincia"
        Me.txtClientesProvincia.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientesProvincia.Properties.Appearance.Options.UseFont = True
        Me.txtClientesProvincia.Size = New System.Drawing.Size(396, 26)
        Me.txtClientesProvincia.TabIndex = 7
        '
        'lbClientesRuta
        '
        Me.lbClientesRuta.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClientesRuta.Location = New System.Drawing.Point(493, 418)
        Me.lbClientesRuta.Name = "lbClientesRuta"
        Me.lbClientesRuta.Size = New System.Drawing.Size(70, 16)
        Me.lbClientesRuta.TabIndex = 170
        Me.lbClientesRuta.Text = "Grupo/Ruta:"
        '
        'cmbClientesRuta
        '
        Me.cmbClientesRuta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbClientesRuta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientesRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientesRuta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClientesRuta.FormattingEnabled = True
        Me.cmbClientesRuta.Location = New System.Drawing.Point(493, 440)
        Me.cmbClientesRuta.Name = "cmbClientesRuta"
        Me.cmbClientesRuta.Size = New System.Drawing.Size(210, 27)
        Me.cmbClientesRuta.TabIndex = 12
        Me.cmbClientesRuta.TabStop = False
        '
        'cmdClientesCancelarEdit
        '
        Me.cmdClientesCancelarEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClientesCancelarEdit.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdClientesCancelarEdit.Appearance.Options.UseFont = True
        Me.cmdClientesCancelarEdit.Appearance.Options.UseForeColor = True
        Me.cmdClientesCancelarEdit.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdClientesCancelarEdit.AppearanceHovered.Options.UseBackColor = True
        Me.cmdClientesCancelarEdit.Image = Global.Ares.My.Resources.Resources.bt20
        Me.cmdClientesCancelarEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdClientesCancelarEdit.Location = New System.Drawing.Point(122, 453)
        Me.cmdClientesCancelarEdit.Name = "cmdClientesCancelarEdit"
        Me.cmdClientesCancelarEdit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdClientesCancelarEdit.Size = New System.Drawing.Size(135, 60)
        Me.cmdClientesCancelarEdit.TabIndex = 15
        Me.cmdClientesCancelarEdit.Text = "CANCELAR"
        Me.cmdClientesCancelarEdit.Visible = False
        '
        'LabelControl159
        '
        Me.LabelControl159.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl159.Location = New System.Drawing.Point(247, 277)
        Me.LabelControl159.Name = "LabelControl159"
        Me.LabelControl159.Size = New System.Drawing.Size(86, 16)
        Me.LabelControl159.TabIndex = 165
        Me.LabelControl159.Text = "Departamento:"
        '
        'LabelControl158
        '
        Me.LabelControl158.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl158.Location = New System.Drawing.Point(18, 277)
        Me.LabelControl158.Name = "LabelControl158"
        Me.LabelControl158.Size = New System.Drawing.Size(58, 16)
        Me.LabelControl158.TabIndex = 164
        Me.LabelControl158.Text = "Municipio:"
        '
        'cmbClientesDepartamento
        '
        Me.cmbClientesDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbClientesDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientesDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientesDepartamento.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClientesDepartamento.FormattingEnabled = True
        Me.cmbClientesDepartamento.Location = New System.Drawing.Point(247, 299)
        Me.cmbClientesDepartamento.Name = "cmbClientesDepartamento"
        Me.cmbClientesDepartamento.Size = New System.Drawing.Size(192, 27)
        Me.cmbClientesDepartamento.TabIndex = 9
        '
        'cmdClientesGuardar
        '
        Me.cmdClientesGuardar.Appearance.BackColor = System.Drawing.Color.White
        Me.cmdClientesGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClientesGuardar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdClientesGuardar.Appearance.Options.UseBackColor = True
        Me.cmdClientesGuardar.Appearance.Options.UseFont = True
        Me.cmdClientesGuardar.Appearance.Options.UseForeColor = True
        Me.cmdClientesGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.cmdClientesGuardar.Location = New System.Drawing.Point(322, 453)
        Me.cmdClientesGuardar.Name = "cmdClientesGuardar"
        Me.cmdClientesGuardar.Size = New System.Drawing.Size(135, 60)
        Me.cmdClientesGuardar.TabIndex = 14
        Me.cmdClientesGuardar.Text = "GUARDAR" & Global.Microsoft.VisualBasic.ChrW(13)
        '
        'cmbClientesMunicipio
        '
        Me.cmbClientesMunicipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbClientesMunicipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbClientesMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbClientesMunicipio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClientesMunicipio.FormattingEnabled = True
        Me.cmbClientesMunicipio.Location = New System.Drawing.Point(18, 299)
        Me.cmbClientesMunicipio.Name = "cmbClientesMunicipio"
        Me.cmbClientesMunicipio.Size = New System.Drawing.Size(192, 27)
        Me.cmbClientesMunicipio.TabIndex = 8
        '
        'LabelControl152
        '
        Me.LabelControl152.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl152.Location = New System.Drawing.Point(247, 345)
        Me.LabelControl152.Name = "LabelControl152"
        Me.LabelControl152.Size = New System.Drawing.Size(36, 16)
        Me.LabelControl152.TabIndex = 113
        Me.LabelControl152.Text = "Email:"
        '
        'txtClientesEmail
        '
        Me.txtClientesEmail.Location = New System.Drawing.Point(247, 367)
        Me.txtClientesEmail.Name = "txtClientesEmail"
        Me.txtClientesEmail.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientesEmail.Properties.Appearance.Options.UseFont = True
        Me.txtClientesEmail.Size = New System.Drawing.Size(210, 26)
        Me.txtClientesEmail.TabIndex = 11
        '
        'LabelControl153
        '
        Me.LabelControl153.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl153.Location = New System.Drawing.Point(18, 345)
        Me.LabelControl153.Name = "LabelControl153"
        Me.LabelControl153.Size = New System.Drawing.Size(61, 16)
        Me.LabelControl153.TabIndex = 111
        Me.LabelControl153.Text = "Teléfonos:"
        '
        'txtClientesTelefonos
        '
        Me.txtClientesTelefonos.Location = New System.Drawing.Point(18, 367)
        Me.txtClientesTelefonos.Name = "txtClientesTelefonos"
        Me.txtClientesTelefonos.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientesTelefonos.Properties.Appearance.Options.UseFont = True
        Me.txtClientesTelefonos.Size = New System.Drawing.Size(210, 26)
        Me.txtClientesTelefonos.TabIndex = 10
        '
        'LabelControl155
        '
        Me.LabelControl155.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl155.Location = New System.Drawing.Point(18, 174)
        Me.LabelControl155.Name = "LabelControl155"
        Me.LabelControl155.Size = New System.Drawing.Size(57, 16)
        Me.LabelControl155.TabIndex = 107
        Me.LabelControl155.Text = "Dirección:"
        '
        'txtClientesDireccion
        '
        Me.txtClientesDireccion.Location = New System.Drawing.Point(18, 193)
        Me.txtClientesDireccion.Name = "txtClientesDireccion"
        Me.txtClientesDireccion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientesDireccion.Properties.Appearance.Options.UseFont = True
        Me.txtClientesDireccion.Properties.MaxLength = 250
        Me.txtClientesDireccion.Size = New System.Drawing.Size(396, 26)
        Me.txtClientesDireccion.TabIndex = 6
        '
        'LabelControl156
        '
        Me.LabelControl156.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl156.Location = New System.Drawing.Point(18, 119)
        Me.LabelControl156.Name = "LabelControl156"
        Me.LabelControl156.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl156.TabIndex = 105
        Me.LabelControl156.Text = "Nombre:"
        '
        'txtClientesNombre
        '
        Me.txtClientesNombre.Location = New System.Drawing.Point(18, 141)
        Me.txtClientesNombre.Name = "txtClientesNombre"
        Me.txtClientesNombre.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientesNombre.Properties.Appearance.Options.UseFont = True
        Me.txtClientesNombre.Size = New System.Drawing.Size(284, 26)
        Me.txtClientesNombre.TabIndex = 4
        '
        'LabelControl157
        '
        Me.LabelControl157.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl157.Location = New System.Drawing.Point(18, 79)
        Me.LabelControl157.Name = "LabelControl157"
        Me.LabelControl157.Size = New System.Drawing.Size(25, 16)
        Me.LabelControl157.TabIndex = 1
        Me.LabelControl157.Text = "NIT:"
        '
        'txtClientesNit
        '
        Me.txtClientesNit.Location = New System.Drawing.Point(55, 76)
        Me.txtClientesNit.Name = "txtClientesNit"
        Me.txtClientesNit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientesNit.Properties.Appearance.Options.UseFont = True
        Me.txtClientesNit.Size = New System.Drawing.Size(176, 26)
        Me.txtClientesNit.TabIndex = 0
        '
        'LabelControl150
        '
        Me.LabelControl150.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl150.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl150.Location = New System.Drawing.Point(98, 26)
        Me.LabelControl150.Name = "LabelControl150"
        Me.LabelControl150.Size = New System.Drawing.Size(92, 33)
        Me.LabelControl150.TabIndex = 171
        Me.LabelControl150.Text = "Clientes"
        '
        'RadialMenuClientes
        '
        Me.RadialMenuClientes.AutoExpand = True
        Me.RadialMenuClientes.Glyph = CType(resources.GetObject("RadialMenuClientes.Glyph"), System.Drawing.Image)
        Me.RadialMenuClientes.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuClientes.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemClientesVerInfo), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemClientesEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemClientesVentasMes), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemClientesCalificar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemClientesEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemRptProductosRes), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemRptProductosDetalle)})
        Me.RadialMenuClientes.Manager = Me.BarManager1
        Me.RadialMenuClientes.Name = "RadialMenuClientes"
        '
        'BarButtonItemClientesVerInfo
        '
        Me.BarButtonItemClientesVerInfo.Caption = "Ver Información"
        Me.BarButtonItemClientesVerInfo.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemClientesVerInfo.Glyph = CType(resources.GetObject("BarButtonItemClientesVerInfo.Glyph"), System.Drawing.Image)
        Me.BarButtonItemClientesVerInfo.Id = 0
        Me.BarButtonItemClientesVerInfo.Name = "BarButtonItemClientesVerInfo"
        '
        'BarButtonItemClientesEditar
        '
        Me.BarButtonItemClientesEditar.Caption = "Editar"
        Me.BarButtonItemClientesEditar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemClientesEditar.Glyph = CType(resources.GetObject("BarButtonItemClientesEditar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemClientesEditar.Id = 1
        Me.BarButtonItemClientesEditar.Name = "BarButtonItemClientesEditar"
        '
        'BarButtonItemClientesVentasMes
        '
        Me.BarButtonItemClientesVentasMes.Caption = "Ventas del Mes"
        Me.BarButtonItemClientesVentasMes.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemClientesVentasMes.Glyph = CType(resources.GetObject("BarButtonItemClientesVentasMes.Glyph"), System.Drawing.Image)
        Me.BarButtonItemClientesVentasMes.Id = 2
        Me.BarButtonItemClientesVentasMes.Name = "BarButtonItemClientesVentasMes"
        '
        'BarButtonItemClientesCalificar
        '
        Me.BarButtonItemClientesCalificar.Caption = "Deshabilitar"
        Me.BarButtonItemClientesCalificar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemClientesCalificar.Glyph = CType(resources.GetObject("BarButtonItemClientesCalificar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemClientesCalificar.Id = 3
        Me.BarButtonItemClientesCalificar.Name = "BarButtonItemClientesCalificar"
        '
        'BarButtonItemClientesEliminar
        '
        Me.BarButtonItemClientesEliminar.Caption = "Eliminar"
        Me.BarButtonItemClientesEliminar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemClientesEliminar.Glyph = CType(resources.GetObject("BarButtonItemClientesEliminar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemClientesEliminar.Id = 4
        Me.BarButtonItemClientesEliminar.Name = "BarButtonItemClientesEliminar"
        '
        'BarButtonItemRptProductosRes
        '
        Me.BarButtonItemRptProductosRes.Caption = "Productos Comprados (Res)"
        Me.BarButtonItemRptProductosRes.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemRptProductosRes.Glyph = CType(resources.GetObject("BarButtonItemRptProductosRes.Glyph"), System.Drawing.Image)
        Me.BarButtonItemRptProductosRes.Id = 6
        Me.BarButtonItemRptProductosRes.Name = "BarButtonItemRptProductosRes"
        '
        'BarButtonItemRptProductosDetalle
        '
        Me.BarButtonItemRptProductosDetalle.Caption = "Productos Comprados (Docs)"
        Me.BarButtonItemRptProductosDetalle.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemRptProductosDetalle.Glyph = CType(resources.GetObject("BarButtonItemRptProductosDetalle.Glyph"), System.Drawing.Image)
        Me.BarButtonItemRptProductosDetalle.Id = 7
        Me.BarButtonItemRptProductosDetalle.Name = "BarButtonItemRptProductosDetalle"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItemClientesVerInfo, Me.BarButtonItemClientesEditar, Me.BarButtonItemClientesVentasMes, Me.BarButtonItemClientesCalificar, Me.BarButtonItemClientesEliminar, Me.BarButtonItem1, Me.BarButtonItemRptProductosRes, Me.BarButtonItemRptProductosDetalle})
        Me.BarManager1.MaxItemId = 8
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1053, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 681)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1053, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 681)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1053, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 681)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "BarButtonItem1"
        Me.BarButtonItem1.Id = 5
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'FlyoutNuevoCliente
        '
        Me.FlyoutNuevoCliente.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutNuevoCliente.Location = New System.Drawing.Point(145, 3)
        Me.FlyoutNuevoCliente.Name = "FlyoutNuevoCliente"
        Me.FlyoutNuevoCliente.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutNuevoCliente.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade
        Me.FlyoutNuevoCliente.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Right
        Me.FlyoutNuevoCliente.OptionsBeakPanel.CloseOnOuterClick = False
        Me.FlyoutNuevoCliente.OwnerControl = Me
        Me.FlyoutNuevoCliente.Size = New System.Drawing.Size(498, 627)
        Me.FlyoutNuevoCliente.TabIndex = 182
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.SimpleButton1)
        Me.FlyoutPanelControl1.Controls.Add(Me.GroupControl8)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutNuevoCliente
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(498, 627)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.Red
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton1.Location = New System.Drawing.Point(8, 5)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 173
        Me.SimpleButton1.Text = "Cerrar(x)"
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnNuevo.Location = New System.Drawing.Point(880, 41)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(138, 56)
        Me.btnNuevo.TabIndex = 187
        Me.btnNuevo.Text = "NUEVO"
        '
        'btnObtenerCenso
        '
        Me.btnObtenerCenso.Image = CType(resources.GetObject("btnObtenerCenso.Image"), System.Drawing.Image)
        Me.btnObtenerCenso.Location = New System.Drawing.Point(665, 41)
        Me.btnObtenerCenso.Name = "btnObtenerCenso"
        Me.btnObtenerCenso.Size = New System.Drawing.Size(138, 56)
        Me.btnObtenerCenso.TabIndex = 192
        Me.btnObtenerCenso.Text = "CENSO"
        '
        'viewClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnObtenerCenso)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.FlyoutNuevoCliente)
        Me.Controls.Add(Me.GridClientes)
        Me.Controls.Add(Me.LabelControl150)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewClientes"
        Me.Size = New System.Drawing.Size(1053, 681)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl8.ResumeLayout(False)
        Me.GroupControl8.PerformLayout()
        CType(Me.lbClienteLong.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lbClienteLat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClienteNombreNegocio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientesCodclie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientesProvincia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientesEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientesTelefonos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientesDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientesNombre.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtClientesNit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadialMenuClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutNuevoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutNuevoCliente.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GridClientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GroupControl8 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbClientesRuta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbClientesRuta As ComboBox
    Friend WithEvents cmdClientesCancelarEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl159 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl158 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbClientesDepartamento As ComboBox
    Friend WithEvents cmdClientesGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbClientesMunicipio As ComboBox
    Friend WithEvents LabelControl152 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClientesEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl153 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClientesTelefonos As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl155 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClientesDireccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl157 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClientesNit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl150 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RadialMenuClientes As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarButtonItemClientesVerInfo As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItemClientesEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemClientesVentasMes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemClientesCalificar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemClientesEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClientesProvincia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoPrecio As ComboBox
    Friend WithEvents FlyoutNuevoCliente As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents GridViewClientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblClientesBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents colCODCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMBRECLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDIRCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESMUNICIPIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESDEPARTAMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCATEGORIA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTELEFONOCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMAILCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHABILITADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHAINICIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnNuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colCODRUTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESRUTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonItemRptProductosRes As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemRptProductosDetalle As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbClienteDiaVisita As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClientesCodclie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClienteNombreNegocio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbClienteTipoNegocio As ComboBox
    Friend WithEvents LabelControl156 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtClientesNombre As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colNEGOCIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDIAVISITA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbClienteLong As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbClienteLat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnObtenerCenso As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colLASTSALE As DevExpress.XtraGrid.Columns.GridColumn
End Class
