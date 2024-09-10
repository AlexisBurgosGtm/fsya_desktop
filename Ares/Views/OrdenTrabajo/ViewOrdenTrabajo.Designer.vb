<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewOrdenTrabajo
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
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewOrdenTrabajo))
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridListado = New DevExpress.XtraGrid.GridControl()
        Me.TblOrdenesTrabajoPendientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewListado = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHAENTREGA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCLIENTE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMCLIENTE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODVEHICULO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESVEHICULO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTELCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colORDEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colANTICIPO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TileView1 = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.txtCorrelativo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnHistorialVehiculo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBuscarVehiculo = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar2 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCodVehiculo = New DevExpress.XtraEditors.TextEdit()
        Me.txtDesVehiculo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.btnBuscarCliente = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSaldo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAdelanto = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtValor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaEntrega = New DevExpress.XtraEditors.DateEdit()
        Me.txtDetRevision = New System.Windows.Forms.TextBox()
        Me.txtCodCliente = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNomCliente = New DevExpress.XtraEditors.TextEdit()
        Me.TblVehiculosClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NavFrame = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.NPListado = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.btnNuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.lbSelectedCorrelativo = New DevExpress.XtraEditors.LabelControl()
        Me.lbSelectedCoddoc = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.txtListadoSaldo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.txtListadoAbono = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl22 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl23 = New DevExpress.XtraEditors.LabelControl()
        Me.txtListadoValor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.txtListadoObs = New System.Windows.Forms.TextBox()
        Me.txtlistadoOrden = New System.Windows.Forms.TextBox()
        Me.NPDetalles = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.LabelControl173 = New DevExpress.XtraEditors.LabelControl()
        Me.RadMenOrdenes = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.RadMenBtnImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenBtnEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenBtnTerminar = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnClienteNuevo = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblOrdenesTrabajoPendientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCorrelativo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtCodVehiculo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesVehiculo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdelanto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEntrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEntrega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomCliente.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblVehiculosClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavFrame.SuspendLayout()
        Me.NPListado.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.txtListadoSaldo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtListadoAbono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtListadoValor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NPDetalles.SuspendLayout()
        CType(Me.RadMenOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridListado
        Me.GridView1.Name = "GridView1"
        Me.GridView1.Tag = "colORDEN"
        '
        'GridListado
        '
        Me.GridListado.DataSource = Me.TblOrdenesTrabajoPendientesBindingSource
        GridLevelNode1.LevelTemplate = Me.GridView1
        GridLevelNode1.RelationName = "Level1"
        Me.GridListado.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.GridListado.Location = New System.Drawing.Point(3, 80)
        Me.GridListado.MainView = Me.GridViewListado
        Me.GridListado.Name = "GridListado"
        Me.GridListado.Size = New System.Drawing.Size(743, 542)
        Me.GridListado.TabIndex = 0
        Me.GridListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListado, Me.TileView1, Me.GridView1})
        '
        'TblOrdenesTrabajoPendientesBindingSource
        '
        Me.TblOrdenesTrabajoPendientesBindingSource.DataMember = "tblOrdenesTrabajoPendientes"
        Me.TblOrdenesTrabajoPendientesBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewListado
        '
        Me.GridViewListado.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GridViewListado.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridViewListado.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFECHA, Me.colFECHAENTREGA, Me.colCODCLIENTE1, Me.colNOMCLIENTE1, Me.colCODVEHICULO1, Me.colDESVEHICULO1, Me.colTELCLIENTE, Me.colORDEN, Me.colOBS, Me.colVALOR, Me.colANTICIPO, Me.colSALDO, Me.colCODDOC, Me.colCORRELATIVO})
        Me.GridViewListado.GridControl = Me.GridListado
        Me.GridViewListado.Name = "GridViewListado"
        Me.GridViewListado.OptionsBehavior.Editable = False
        Me.GridViewListado.OptionsView.ShowAutoFilterRow = True
        '
        'colFECHA
        '
        Me.colFECHA.Caption = "Fecha"
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 1
        Me.colFECHA.Width = 79
        '
        'colFECHAENTREGA
        '
        Me.colFECHAENTREGA.Caption = "Entrega"
        Me.colFECHAENTREGA.FieldName = "FECHAENTREGA"
        Me.colFECHAENTREGA.Name = "colFECHAENTREGA"
        Me.colFECHAENTREGA.Visible = True
        Me.colFECHAENTREGA.VisibleIndex = 2
        Me.colFECHAENTREGA.Width = 94
        '
        'colCODCLIENTE1
        '
        Me.colCODCLIENTE1.FieldName = "CODCLIENTE"
        Me.colCODCLIENTE1.Name = "colCODCLIENTE1"
        '
        'colNOMCLIENTE1
        '
        Me.colNOMCLIENTE1.Caption = "Cliente"
        Me.colNOMCLIENTE1.FieldName = "NOMCLIENTE"
        Me.colNOMCLIENTE1.Name = "colNOMCLIENTE1"
        Me.colNOMCLIENTE1.Visible = True
        Me.colNOMCLIENTE1.VisibleIndex = 3
        Me.colNOMCLIENTE1.Width = 158
        '
        'colCODVEHICULO1
        '
        Me.colCODVEHICULO1.FieldName = "CODVEHICULO"
        Me.colCODVEHICULO1.Name = "colCODVEHICULO1"
        '
        'colDESVEHICULO1
        '
        Me.colDESVEHICULO1.Caption = "Vehiculo"
        Me.colDESVEHICULO1.FieldName = "DESVEHICULO"
        Me.colDESVEHICULO1.Name = "colDESVEHICULO1"
        Me.colDESVEHICULO1.Visible = True
        Me.colDESVEHICULO1.VisibleIndex = 4
        Me.colDESVEHICULO1.Width = 211
        '
        'colTELCLIENTE
        '
        Me.colTELCLIENTE.Caption = "Telefonos"
        Me.colTELCLIENTE.FieldName = "TELCLIENTE"
        Me.colTELCLIENTE.Name = "colTELCLIENTE"
        Me.colTELCLIENTE.Visible = True
        Me.colTELCLIENTE.VisibleIndex = 5
        Me.colTELCLIENTE.Width = 135
        '
        'colORDEN
        '
        Me.colORDEN.FieldName = "ORDEN"
        Me.colORDEN.Name = "colORDEN"
        Me.colORDEN.Width = 103
        '
        'colOBS
        '
        Me.colOBS.FieldName = "OBS"
        Me.colOBS.Name = "colOBS"
        Me.colOBS.Width = 103
        '
        'colVALOR
        '
        Me.colVALOR.FieldName = "VALOR"
        Me.colVALOR.Name = "colVALOR"
        Me.colVALOR.Width = 103
        '
        'colANTICIPO
        '
        Me.colANTICIPO.FieldName = "ANTICIPO"
        Me.colANTICIPO.Name = "colANTICIPO"
        Me.colANTICIPO.Width = 103
        '
        'colSALDO
        '
        Me.colSALDO.FieldName = "SALDO"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Width = 120
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.Caption = "No."
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 0
        Me.colCORRELATIVO.Width = 57
        '
        'TileView1
        '
        Me.TileView1.GridControl = Me.GridListado
        Me.TileView1.Name = "TileView1"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(865, 32)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Properties.Appearance.Options.UseFont = True
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(131, 24)
        Me.txtFecha.TabIndex = 200
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Enabled = False
        Me.txtCorrelativo.Location = New System.Drawing.Point(865, 62)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorrelativo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtCorrelativo.Properties.Appearance.Options.UseFont = True
        Me.txtCorrelativo.Properties.Appearance.Options.UseForeColor = True
        Me.txtCorrelativo.Size = New System.Drawing.Size(131, 24)
        Me.txtCorrelativo.TabIndex = 201
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(815, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(44, 18)
        Me.LabelControl1.TabIndex = 202
        Me.LabelControl1.Text = "Fecha:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(815, 65)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(23, 18)
        Me.LabelControl2.TabIndex = 203
        Me.LabelControl2.Text = "No."
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnClienteNuevo)
        Me.GroupControl1.Controls.Add(Me.btnHistorialVehiculo)
        Me.GroupControl1.Controls.Add(Me.btnBuscarVehiculo)
        Me.GroupControl1.Controls.Add(Me.btnCancelar2)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.btnGuardar)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.btnCancelar)
        Me.GroupControl1.Controls.Add(Me.txtCorrelativo)
        Me.GroupControl1.Controls.Add(Me.txtFecha)
        Me.GroupControl1.Controls.Add(Me.txtCodVehiculo)
        Me.GroupControl1.Controls.Add(Me.txtDesVehiculo)
        Me.GroupControl1.Controls.Add(Me.LabelControl14)
        Me.GroupControl1.Controls.Add(Me.btnBuscarCliente)
        Me.GroupControl1.Controls.Add(Me.LabelControl12)
        Me.GroupControl1.Controls.Add(Me.LabelControl13)
        Me.GroupControl1.Controls.Add(Me.txtSaldo)
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.LabelControl11)
        Me.GroupControl1.Controls.Add(Me.txtAdelanto)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.txtValor)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.txtObs)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.txtFechaEntrega)
        Me.GroupControl1.Controls.Add(Me.txtDetRevision)
        Me.GroupControl1.Controls.Add(Me.txtCodCliente)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.txtNomCliente)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1037, 625)
        Me.GroupControl1.TabIndex = 204
        Me.GroupControl1.Text = "Datos de la Orden de Trabajo"
        '
        'btnHistorialVehiculo
        '
        Me.btnHistorialVehiculo.Image = CType(resources.GetObject("btnHistorialVehiculo.Image"), System.Drawing.Image)
        Me.btnHistorialVehiculo.Location = New System.Drawing.Point(523, 68)
        Me.btnHistorialVehiculo.Name = "btnHistorialVehiculo"
        Me.btnHistorialVehiculo.Size = New System.Drawing.Size(75, 23)
        Me.btnHistorialVehiculo.TabIndex = 235
        Me.btnHistorialVehiculo.Text = "Historial"
        '
        'btnBuscarVehiculo
        '
        Me.btnBuscarVehiculo.Image = CType(resources.GetObject("btnBuscarVehiculo.Image"), System.Drawing.Image)
        Me.btnBuscarVehiculo.Location = New System.Drawing.Point(449, 67)
        Me.btnBuscarVehiculo.Name = "btnBuscarVehiculo"
        Me.btnBuscarVehiculo.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscarVehiculo.TabIndex = 234
        Me.btnBuscarVehiculo.Text = "Buscar"
        '
        'btnCancelar2
        '
        Me.btnCancelar2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.btnCancelar2.Image = CType(resources.GetObject("btnCancelar2.Image"), System.Drawing.Image)
        Me.btnCancelar2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCancelar2.Location = New System.Drawing.Point(9, 28)
        Me.btnCancelar2.Name = "btnCancelar2"
        Me.btnCancelar2.Size = New System.Drawing.Size(40, 40)
        Me.btnCancelar2.TabIndex = 233
        '
        'btnGuardar
        '
        Me.btnGuardar.Appearance.BackColor = System.Drawing.Color.White
        Me.btnGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnGuardar.Appearance.Options.UseBackColor = True
        Me.btnGuardar.Appearance.Options.UseFont = True
        Me.btnGuardar.Appearance.Options.UseForeColor = True
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(795, 449)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(135, 60)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "GUARDAR" & Global.Microsoft.VisualBasic.ChrW(13)
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
        Me.btnCancelar.Location = New System.Drawing.Point(628, 449)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnCancelar.Size = New System.Drawing.Size(135, 60)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "CANCELAR"
        '
        'txtCodVehiculo
        '
        Me.txtCodVehiculo.Location = New System.Drawing.Point(378, 96)
        Me.txtCodVehiculo.Name = "txtCodVehiculo"
        Me.txtCodVehiculo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodVehiculo.Properties.Appearance.Options.UseFont = True
        Me.txtCodVehiculo.Size = New System.Drawing.Size(20, 24)
        Me.txtCodVehiculo.TabIndex = 231
        Me.txtCodVehiculo.Visible = False
        '
        'txtDesVehiculo
        '
        Me.txtDesVehiculo.Location = New System.Drawing.Point(132, 66)
        Me.txtDesVehiculo.Name = "txtDesVehiculo"
        Me.txtDesVehiculo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesVehiculo.Properties.Appearance.Options.UseFont = True
        Me.txtDesVehiculo.Size = New System.Drawing.Size(311, 24)
        Me.txtDesVehiculo.TabIndex = 230
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Location = New System.Drawing.Point(69, 68)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(57, 18)
        Me.LabelControl14.TabIndex = 227
        Me.LabelControl14.Text = "Vehiculo:"
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(449, 32)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(68, 23)
        Me.btnBuscarCliente.TabIndex = 226
        Me.btnBuscarCliente.Text = "Buscar"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(762, 392)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl12.TabIndex = 225
        Me.LabelControl12.Text = "Q"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(632, 398)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(39, 18)
        Me.LabelControl13.TabIndex = 224
        Me.LabelControl13.Text = "Saldo:"
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.EnterMoveNextControl = True
        Me.txtSaldo.Location = New System.Drawing.Point(782, 393)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldo.Properties.Appearance.Options.UseFont = True
        Me.txtSaldo.Properties.Mask.EditMask = "n2"
        Me.txtSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSaldo.Size = New System.Drawing.Size(131, 24)
        Me.txtSaldo.TabIndex = 5
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(762, 353)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl10.TabIndex = 222
        Me.LabelControl10.Text = "Q"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(632, 359)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(61, 18)
        Me.LabelControl11.TabIndex = 221
        Me.LabelControl11.Text = "Adelanto:"
        '
        'txtAdelanto
        '
        Me.txtAdelanto.EnterMoveNextControl = True
        Me.txtAdelanto.Location = New System.Drawing.Point(782, 354)
        Me.txtAdelanto.Name = "txtAdelanto"
        Me.txtAdelanto.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdelanto.Properties.Appearance.Options.UseFont = True
        Me.txtAdelanto.Properties.Mask.EditMask = "n2"
        Me.txtAdelanto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdelanto.Size = New System.Drawing.Size(131, 24)
        Me.txtAdelanto.TabIndex = 4
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(762, 315)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl9.TabIndex = 219
        Me.LabelControl9.Text = "Q"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(592, 319)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(101, 18)
        Me.LabelControl8.TabIndex = 218
        Me.LabelControl8.Text = "Valor Estimado:"
        '
        'txtValor
        '
        Me.txtValor.EnterMoveNextControl = True
        Me.txtValor.Location = New System.Drawing.Point(782, 316)
        Me.txtValor.Name = "txtValor"
        Me.txtValor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Properties.Appearance.Options.UseFont = True
        Me.txtValor.Properties.Mask.EditMask = "n2"
        Me.txtValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtValor.Size = New System.Drawing.Size(131, 24)
        Me.txtValor.TabIndex = 3
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(32, 301)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(173, 18)
        Me.LabelControl7.TabIndex = 216
        Me.LabelControl7.Text = "Observaciones adicionales:"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(32, 325)
        Me.txtObs.MaxLength = 255
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(445, 87)
        Me.txtObs.TabIndex = 1
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(32, 156)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(137, 18)
        Me.LabelControl6.TabIndex = 214
        Me.LabelControl6.Text = "Detalle de la revisión:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(592, 273)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(184, 18)
        Me.LabelControl5.TabIndex = 213
        Me.LabelControl5.Text = "Fecha estimada de entrega:"
        '
        'txtFechaEntrega
        '
        Me.txtFechaEntrega.EditValue = Nothing
        Me.txtFechaEntrega.EnterMoveNextControl = True
        Me.txtFechaEntrega.Location = New System.Drawing.Point(782, 270)
        Me.txtFechaEntrega.Name = "txtFechaEntrega"
        Me.txtFechaEntrega.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaEntrega.Properties.Appearance.Options.UseFont = True
        Me.txtFechaEntrega.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaEntrega.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaEntrega.Size = New System.Drawing.Size(131, 24)
        Me.txtFechaEntrega.TabIndex = 2
        '
        'txtDetRevision
        '
        Me.txtDetRevision.Location = New System.Drawing.Point(32, 180)
        Me.txtDetRevision.MaxLength = 255
        Me.txtDetRevision.Multiline = True
        Me.txtDetRevision.Name = "txtDetRevision"
        Me.txtDetRevision.Size = New System.Drawing.Size(445, 79)
        Me.txtDetRevision.TabIndex = 0
        '
        'txtCodCliente
        '
        Me.txtCodCliente.Location = New System.Drawing.Point(610, 31)
        Me.txtCodCliente.Name = "txtCodCliente"
        Me.txtCodCliente.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCliente.Properties.Appearance.Options.UseFont = True
        Me.txtCodCliente.Size = New System.Drawing.Size(32, 24)
        Me.txtCodCliente.TabIndex = 206
        Me.txtCodCliente.Visible = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(69, 34)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(47, 18)
        Me.LabelControl3.TabIndex = 205
        Me.LabelControl3.Text = "Cliente:"
        '
        'txtNomCliente
        '
        Me.txtNomCliente.Location = New System.Drawing.Point(132, 31)
        Me.txtNomCliente.Name = "txtNomCliente"
        Me.txtNomCliente.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomCliente.Properties.Appearance.Options.UseFont = True
        Me.txtNomCliente.Size = New System.Drawing.Size(311, 24)
        Me.txtNomCliente.TabIndex = 204
        '
        'TblVehiculosClientesBindingSource
        '
        Me.TblVehiculosClientesBindingSource.DataMember = "tblVehiculosClientes"
        Me.TblVehiculosClientesBindingSource.DataSource = Me.DSGeneral
        '
        'NavFrame
        '
        Me.NavFrame.Controls.Add(Me.NPListado)
        Me.NavFrame.Controls.Add(Me.NPDetalles)
        Me.NavFrame.Location = New System.Drawing.Point(10, 66)
        Me.NavFrame.Name = "NavFrame"
        Me.NavFrame.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NPListado, Me.NPDetalles})
        Me.NavFrame.SelectedPage = Me.NPListado
        Me.NavFrame.Size = New System.Drawing.Size(1037, 625)
        Me.NavFrame.TabIndex = 205
        Me.NavFrame.Text = "NavigationFrame1"
        Me.NavFrame.TransitionAnimationProperties.FrameCount = 500
        Me.NavFrame.TransitionAnimationProperties.FrameInterval = 5000
        '
        'NPListado
        '
        Me.NPListado.Controls.Add(Me.btnNuevo)
        Me.NPListado.Controls.Add(Me.LabelControl15)
        Me.NPListado.Controls.Add(Me.GroupControl3)
        Me.NPListado.Controls.Add(Me.GridListado)
        Me.NPListado.Name = "NPListado"
        Me.NPListado.Size = New System.Drawing.Size(1037, 625)
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnNuevo.Location = New System.Drawing.Point(598, 14)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(143, 59)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "Nuevo"
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(14, 29)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(194, 23)
        Me.LabelControl15.TabIndex = 2
        Me.LabelControl15.Text = "Trabajos Pendientes"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.lbSelectedCorrelativo)
        Me.GroupControl3.Controls.Add(Me.lbSelectedCoddoc)
        Me.GroupControl3.Controls.Add(Me.LabelControl18)
        Me.GroupControl3.Controls.Add(Me.LabelControl19)
        Me.GroupControl3.Controls.Add(Me.txtListadoSaldo)
        Me.GroupControl3.Controls.Add(Me.LabelControl20)
        Me.GroupControl3.Controls.Add(Me.LabelControl21)
        Me.GroupControl3.Controls.Add(Me.txtListadoAbono)
        Me.GroupControl3.Controls.Add(Me.LabelControl22)
        Me.GroupControl3.Controls.Add(Me.LabelControl23)
        Me.GroupControl3.Controls.Add(Me.txtListadoValor)
        Me.GroupControl3.Controls.Add(Me.LabelControl17)
        Me.GroupControl3.Controls.Add(Me.LabelControl16)
        Me.GroupControl3.Controls.Add(Me.txtListadoObs)
        Me.GroupControl3.Controls.Add(Me.txtlistadoOrden)
        Me.GroupControl3.Location = New System.Drawing.Point(747, 15)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(283, 592)
        Me.GroupControl3.TabIndex = 1
        Me.GroupControl3.Text = "Detalle de la Orden"
        '
        'lbSelectedCorrelativo
        '
        Me.lbSelectedCorrelativo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbSelectedCorrelativo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbSelectedCorrelativo.Location = New System.Drawing.Point(115, 24)
        Me.lbSelectedCorrelativo.Name = "lbSelectedCorrelativo"
        Me.lbSelectedCorrelativo.Size = New System.Drawing.Size(147, 13)
        Me.lbSelectedCorrelativo.TabIndex = 236
        Me.lbSelectedCorrelativo.Text = "000000000000000000000"
        '
        'lbSelectedCoddoc
        '
        Me.lbSelectedCoddoc.Location = New System.Drawing.Point(17, 24)
        Me.lbSelectedCoddoc.Name = "lbSelectedCoddoc"
        Me.lbSelectedCoddoc.Size = New System.Drawing.Size(34, 13)
        Me.lbSelectedCoddoc.TabIndex = 235
        Me.lbSelectedCoddoc.Text = "coddoc"
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Location = New System.Drawing.Point(111, 445)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl18.TabIndex = 234
        Me.LabelControl18.Text = "Q"
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Location = New System.Drawing.Point(46, 451)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(39, 18)
        Me.LabelControl19.TabIndex = 233
        Me.LabelControl19.Text = "Saldo:"
        '
        'txtListadoSaldo
        '
        Me.txtListadoSaldo.EnterMoveNextControl = True
        Me.txtListadoSaldo.Location = New System.Drawing.Point(131, 446)
        Me.txtListadoSaldo.Name = "txtListadoSaldo"
        Me.txtListadoSaldo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListadoSaldo.Properties.Appearance.Options.UseFont = True
        Me.txtListadoSaldo.Properties.Mask.EditMask = "n2"
        Me.txtListadoSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtListadoSaldo.Size = New System.Drawing.Size(131, 24)
        Me.txtListadoSaldo.TabIndex = 228
        '
        'LabelControl20
        '
        Me.LabelControl20.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl20.Location = New System.Drawing.Point(111, 406)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl20.TabIndex = 232
        Me.LabelControl20.Text = "Q"
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Location = New System.Drawing.Point(46, 412)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(61, 18)
        Me.LabelControl21.TabIndex = 231
        Me.LabelControl21.Text = "Adelanto:"
        '
        'txtListadoAbono
        '
        Me.txtListadoAbono.EnterMoveNextControl = True
        Me.txtListadoAbono.Location = New System.Drawing.Point(131, 407)
        Me.txtListadoAbono.Name = "txtListadoAbono"
        Me.txtListadoAbono.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListadoAbono.Properties.Appearance.Options.UseFont = True
        Me.txtListadoAbono.Properties.Mask.EditMask = "n2"
        Me.txtListadoAbono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtListadoAbono.Size = New System.Drawing.Size(131, 24)
        Me.txtListadoAbono.TabIndex = 227
        '
        'LabelControl22
        '
        Me.LabelControl22.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl22.Location = New System.Drawing.Point(111, 368)
        Me.LabelControl22.Name = "LabelControl22"
        Me.LabelControl22.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl22.TabIndex = 230
        Me.LabelControl22.Text = "Q"
        '
        'LabelControl23
        '
        Me.LabelControl23.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl23.Location = New System.Drawing.Point(6, 372)
        Me.LabelControl23.Name = "LabelControl23"
        Me.LabelControl23.Size = New System.Drawing.Size(101, 18)
        Me.LabelControl23.TabIndex = 229
        Me.LabelControl23.Text = "Valor Estimado:"
        '
        'txtListadoValor
        '
        Me.txtListadoValor.EnterMoveNextControl = True
        Me.txtListadoValor.Location = New System.Drawing.Point(131, 369)
        Me.txtListadoValor.Name = "txtListadoValor"
        Me.txtListadoValor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtListadoValor.Properties.Appearance.Options.UseFont = True
        Me.txtListadoValor.Properties.Mask.EditMask = "n2"
        Me.txtListadoValor.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtListadoValor.Size = New System.Drawing.Size(131, 24)
        Me.txtListadoValor.TabIndex = 226
        '
        'LabelControl17
        '
        Me.LabelControl17.Location = New System.Drawing.Point(17, 209)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl17.TabIndex = 4
        Me.LabelControl17.Text = "Observaciones"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(17, 71)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl16.TabIndex = 3
        Me.LabelControl16.Text = "Detalle del Servicio"
        '
        'txtListadoObs
        '
        Me.txtListadoObs.Location = New System.Drawing.Point(17, 227)
        Me.txtListadoObs.Multiline = True
        Me.txtListadoObs.Name = "txtListadoObs"
        Me.txtListadoObs.Size = New System.Drawing.Size(247, 106)
        Me.txtListadoObs.TabIndex = 2
        '
        'txtlistadoOrden
        '
        Me.txtlistadoOrden.Location = New System.Drawing.Point(17, 90)
        Me.txtlistadoOrden.Multiline = True
        Me.txtlistadoOrden.Name = "txtlistadoOrden"
        Me.txtlistadoOrden.Size = New System.Drawing.Size(247, 106)
        Me.txtlistadoOrden.TabIndex = 1
        '
        'NPDetalles
        '
        Me.NPDetalles.Controls.Add(Me.GroupControl1)
        Me.NPDetalles.Name = "NPDetalles"
        Me.NPDetalles.Size = New System.Drawing.Size(1037, 625)
        '
        'LabelControl173
        '
        Me.LabelControl173.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl173.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl173.Location = New System.Drawing.Point(66, 12)
        Me.LabelControl173.Name = "LabelControl173"
        Me.LabelControl173.Size = New System.Drawing.Size(236, 33)
        Me.LabelControl173.TabIndex = 198
        Me.LabelControl173.Text = "Ordenes de Trabajo"
        '
        'RadMenOrdenes
        '
        Me.RadMenOrdenes.AutoExpand = True
        Me.RadMenOrdenes.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadMenOrdenes.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.RadMenBtnImprimir), New DevExpress.XtraBars.LinkPersistInfo(Me.RadMenBtnEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.RadMenBtnTerminar), New DevExpress.XtraBars.LinkPersistInfo(Me.RadMenEliminar)})
        Me.RadMenOrdenes.Manager = Me.BarManager1
        Me.RadMenOrdenes.Name = "RadMenOrdenes"
        '
        'RadMenBtnImprimir
        '
        Me.RadMenBtnImprimir.Caption = "Imprimir"
        Me.RadMenBtnImprimir.CloseRadialMenuOnItemClick = True
        Me.RadMenBtnImprimir.Glyph = CType(resources.GetObject("RadMenBtnImprimir.Glyph"), System.Drawing.Image)
        Me.RadMenBtnImprimir.Id = 0
        Me.RadMenBtnImprimir.Name = "RadMenBtnImprimir"
        '
        'RadMenBtnEditar
        '
        Me.RadMenBtnEditar.Caption = "Editar"
        Me.RadMenBtnEditar.CloseRadialMenuOnItemClick = True
        Me.RadMenBtnEditar.Glyph = CType(resources.GetObject("RadMenBtnEditar.Glyph"), System.Drawing.Image)
        Me.RadMenBtnEditar.Id = 1
        Me.RadMenBtnEditar.Name = "RadMenBtnEditar"
        '
        'RadMenBtnTerminar
        '
        Me.RadMenBtnTerminar.Caption = "Terminar"
        Me.RadMenBtnTerminar.CloseRadialMenuOnItemClick = True
        Me.RadMenBtnTerminar.Glyph = CType(resources.GetObject("RadMenBtnTerminar.Glyph"), System.Drawing.Image)
        Me.RadMenBtnTerminar.Id = 2
        Me.RadMenBtnTerminar.Name = "RadMenBtnTerminar"
        '
        'RadMenEliminar
        '
        Me.RadMenEliminar.Caption = "Eliminar"
        Me.RadMenEliminar.CloseRadialMenuOnItemClick = True
        Me.RadMenEliminar.Glyph = CType(resources.GetObject("RadMenEliminar.Glyph"), System.Drawing.Image)
        Me.RadMenEliminar.Id = 3
        Me.RadMenEliminar.Name = "RadMenEliminar"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RadMenBtnImprimir, Me.RadMenBtnEditar, Me.RadMenBtnTerminar, Me.RadMenEliminar})
        Me.BarManager1.MaxItemId = 4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1054, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 696)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1054, 0)
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
        Me.barDockControlRight.Location = New System.Drawing.Point(1054, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 696)
        '
        'btnClienteNuevo
        '
        Me.btnClienteNuevo.Image = CType(resources.GetObject("btnClienteNuevo.Image"), System.Drawing.Image)
        Me.btnClienteNuevo.Location = New System.Drawing.Point(523, 32)
        Me.btnClienteNuevo.Name = "btnClienteNuevo"
        Me.btnClienteNuevo.Size = New System.Drawing.Size(75, 23)
        Me.btnClienteNuevo.TabIndex = 236
        Me.btnClienteNuevo.Text = "Nuevo"
        '
        'ViewOrdenTrabajo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.NavFrame)
        Me.Controls.Add(Me.LabelControl173)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "ViewOrdenTrabajo"
        Me.Size = New System.Drawing.Size(1054, 696)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblOrdenesTrabajoPendientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCorrelativo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtCodVehiculo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesVehiculo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdelanto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEntrega.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEntrega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomCliente.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblVehiculosClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavFrame.ResumeLayout(False)
        Me.NPListado.ResumeLayout(False)
        Me.NPListado.PerformLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.txtListadoSaldo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtListadoAbono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtListadoValor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NPDetalles.ResumeLayout(False)
        CType(Me.RadMenOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtCorrelativo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaEntrega As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtDetRevision As TextBox
    Friend WithEvents txtCodCliente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNomCliente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As TextBox
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSaldo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAdelanto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtValor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TblVehiculosClientesBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents btnBuscarCliente As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCodVehiculo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDesVehiculo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents NavFrame As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents NPListado As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NPDetalles As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents btnNuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents TblOrdenesTrabajoPendientesBindingSource As BindingSource
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridViewListado As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHAENTREGA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODCLIENTE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMCLIENTE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODVEHICULO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESVEHICULO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTELCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colORDEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOBS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colANTICIPO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TileView1 As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents LabelControl173 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtListadoSaldo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtListadoAbono As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl22 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl23 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtListadoValor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtListadoObs As TextBox
    Friend WithEvents txtlistadoOrden As TextBox
    Friend WithEvents lbSelectedCorrelativo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbSelectedCoddoc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCancelar2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadMenOrdenes As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents RadMenBtnImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadMenBtnEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadMenBtnTerminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadMenEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnBuscarVehiculo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHistorialVehiculo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClienteNuevo As DevExpress.XtraEditors.SimpleButton
End Class
