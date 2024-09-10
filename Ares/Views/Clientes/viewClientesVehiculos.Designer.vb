<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewClientesVehiculos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewClientesVehiculos))
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl150 = New DevExpress.XtraEditors.LabelControl()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GROUP = New DevExpress.XtraEditors.GroupControl()
        Me.GridVehiculos = New DevExpress.XtraGrid.GridControl()
        Me.TblVehiculosClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewVehiculos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODVEHICULO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOPLACAS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESVEHICULO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLINEA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMODELO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOLOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grou = New DevExpress.XtraEditors.GroupControl()
        Me.btnNuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMarca = New System.Windows.Forms.ComboBox()
        Me.txtColor = New DevExpress.XtraEditors.TextEdit()
        Me.txtModelo = New DevExpress.XtraEditors.TextEdit()
        Me.txtLinea = New DevExpress.XtraEditors.TextEdit()
        Me.txtDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.txtNoPlaca = New DevExpress.XtraEditors.TextEdit()
        Me.txtCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.RadMenVehiculos = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.RadMenBtnEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenBtnEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenBtnHistorial = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnCerrarVentana = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptarVentana = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GROUP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GROUP.SuspendLayout()
        CType(Me.GridVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblVehiculosClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grou, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grou.SuspendLayout()
        CType(Me.txtColor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModelo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLinea.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoPlaca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.btnGuardar.Location = New System.Drawing.Point(169, 484)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(135, 60)
        Me.btnGuardar.TabIndex = 172
        Me.btnGuardar.Text = "GUARDAR" & Global.Microsoft.VisualBasic.ChrW(13)
        '
        'LabelControl150
        '
        Me.LabelControl150.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl150.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl150.Location = New System.Drawing.Point(82, 19)
        Me.LabelControl150.Name = "LabelControl150"
        Me.LabelControl150.Size = New System.Drawing.Size(248, 33)
        Me.LabelControl150.TabIndex = 174
        Me.LabelControl150.Text = "Vehículos de Clientes"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(14, 82)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GROUP)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grou)
        Me.SplitContainer1.Size = New System.Drawing.Size(1026, 574)
        Me.SplitContainer1.SplitterDistance = 705
        Me.SplitContainer1.SplitterWidth = 7
        Me.SplitContainer1.TabIndex = 175
        '
        'GROUP
        '
        Me.GROUP.Controls.Add(Me.GridVehiculos)
        Me.GROUP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GROUP.Location = New System.Drawing.Point(0, 0)
        Me.GROUP.Name = "GROUP"
        Me.GROUP.Size = New System.Drawing.Size(705, 574)
        Me.GROUP.TabIndex = 1
        Me.GROUP.Text = "Listado de Vehiculos"
        '
        'GridVehiculos
        '
        Me.GridVehiculos.DataSource = Me.TblVehiculosClientesBindingSource
        Me.GridVehiculos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridVehiculos.Location = New System.Drawing.Point(2, 20)
        Me.GridVehiculos.MainView = Me.GridViewVehiculos
        Me.GridVehiculos.Name = "GridVehiculos"
        Me.GridVehiculos.Size = New System.Drawing.Size(701, 552)
        Me.GridVehiculos.TabIndex = 0
        Me.GridVehiculos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewVehiculos})
        '
        'TblVehiculosClientesBindingSource
        '
        Me.TblVehiculosClientesBindingSource.DataMember = "tblVehiculosClientes"
        Me.TblVehiculosClientesBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewVehiculos
        '
        Me.GridViewVehiculos.Appearance.Row.BackColor = System.Drawing.Color.White
        Me.GridViewVehiculos.Appearance.Row.Options.UseBackColor = True
        Me.GridViewVehiculos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODVEHICULO, Me.colNOPLACAS, Me.colDESVEHICULO, Me.colLINEA, Me.colMODELO, Me.colCOLOR, Me.colMARCA, Me.colCODCLIENTE, Me.colNOMCLIENTE, Me.colCODMARCA})
        Me.GridViewVehiculos.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewVehiculos.GridControl = Me.GridVehiculos
        Me.GridViewVehiculos.Name = "GridViewVehiculos"
        Me.GridViewVehiculos.OptionsBehavior.Editable = False
        Me.GridViewVehiculos.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewVehiculos.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button
        Me.GridViewVehiculos.OptionsView.ShowAutoFilterRow = True
        '
        'colCODVEHICULO
        '
        Me.colCODVEHICULO.FieldName = "CODVEHICULO"
        Me.colCODVEHICULO.Name = "colCODVEHICULO"
        '
        'colNOPLACAS
        '
        Me.colNOPLACAS.Caption = "NoPlaca"
        Me.colNOPLACAS.FieldName = "NOPLACAS"
        Me.colNOPLACAS.Name = "colNOPLACAS"
        Me.colNOPLACAS.Visible = True
        Me.colNOPLACAS.VisibleIndex = 0
        Me.colNOPLACAS.Width = 79
        '
        'colDESVEHICULO
        '
        Me.colDESVEHICULO.Caption = "Descripcion"
        Me.colDESVEHICULO.FieldName = "DESVEHICULO"
        Me.colDESVEHICULO.Name = "colDESVEHICULO"
        Me.colDESVEHICULO.Visible = True
        Me.colDESVEHICULO.VisibleIndex = 1
        Me.colDESVEHICULO.Width = 123
        '
        'colLINEA
        '
        Me.colLINEA.Caption = "Linea"
        Me.colLINEA.FieldName = "LINEA"
        Me.colLINEA.Name = "colLINEA"
        Me.colLINEA.Visible = True
        Me.colLINEA.VisibleIndex = 2
        Me.colLINEA.Width = 107
        '
        'colMODELO
        '
        Me.colMODELO.Caption = "Modelo"
        Me.colMODELO.FieldName = "MODELO"
        Me.colMODELO.Name = "colMODELO"
        Me.colMODELO.Visible = True
        Me.colMODELO.VisibleIndex = 3
        Me.colMODELO.Width = 66
        '
        'colCOLOR
        '
        Me.colCOLOR.Caption = "Color"
        Me.colCOLOR.FieldName = "COLOR"
        Me.colCOLOR.Name = "colCOLOR"
        Me.colCOLOR.Visible = True
        Me.colCOLOR.VisibleIndex = 4
        Me.colCOLOR.Width = 70
        '
        'colMARCA
        '
        Me.colMARCA.Caption = "Marca"
        Me.colMARCA.FieldName = "MARCA"
        Me.colMARCA.Name = "colMARCA"
        Me.colMARCA.Visible = True
        Me.colMARCA.VisibleIndex = 5
        Me.colMARCA.Width = 102
        '
        'colCODCLIENTE
        '
        Me.colCODCLIENTE.FieldName = "CODCLIENTE"
        Me.colCODCLIENTE.Name = "colCODCLIENTE"
        '
        'colNOMCLIENTE
        '
        Me.colNOMCLIENTE.Caption = "Cliente"
        Me.colNOMCLIENTE.FieldName = "NOMCLIENTE"
        Me.colNOMCLIENTE.Name = "colNOMCLIENTE"
        Me.colNOMCLIENTE.Width = 136
        '
        'colCODMARCA
        '
        Me.colCODMARCA.FieldName = "CODMARCA"
        Me.colCODMARCA.Name = "colCODMARCA"
        '
        'grou
        '
        Me.grou.Controls.Add(Me.btnNuevo)
        Me.grou.Controls.Add(Me.LabelControl7)
        Me.grou.Controls.Add(Me.LabelControl6)
        Me.grou.Controls.Add(Me.LabelControl5)
        Me.grou.Controls.Add(Me.LabelControl4)
        Me.grou.Controls.Add(Me.LabelControl3)
        Me.grou.Controls.Add(Me.LabelControl2)
        Me.grou.Controls.Add(Me.cmbMarca)
        Me.grou.Controls.Add(Me.txtColor)
        Me.grou.Controls.Add(Me.txtModelo)
        Me.grou.Controls.Add(Me.txtLinea)
        Me.grou.Controls.Add(Me.txtDescripcion)
        Me.grou.Controls.Add(Me.txtNoPlaca)
        Me.grou.Controls.Add(Me.txtCodigo)
        Me.grou.Controls.Add(Me.btnGuardar)
        Me.grou.Controls.Add(Me.btnCancelar)
        Me.grou.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grou.Location = New System.Drawing.Point(0, 0)
        Me.grou.Name = "grou"
        Me.grou.Size = New System.Drawing.Size(314, 574)
        Me.grou.TabIndex = 0
        Me.grou.Text = "Datos del Vehículo"
        '
        'btnNuevo
        '
        Me.btnNuevo.Appearance.BackColor = System.Drawing.Color.White
        Me.btnNuevo.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnNuevo.Appearance.Options.UseBackColor = True
        Me.btnNuevo.Appearance.Options.UseFont = True
        Me.btnNuevo.Appearance.Options.UseForeColor = True
        Me.btnNuevo.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnNuevo.Location = New System.Drawing.Point(169, 33)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(135, 62)
        Me.btnNuevo.TabIndex = 189
        Me.btnNuevo.Text = "NUEVO (F3)"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(22, 350)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl7.TabIndex = 188
        Me.LabelControl7.Text = "Marca:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(22, 301)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl6.TabIndex = 187
        Me.LabelControl6.Text = "Color:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(22, 256)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(38, 13)
        Me.LabelControl5.TabIndex = 186
        Me.LabelControl5.Text = "Modelo:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(22, 216)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(29, 13)
        Me.LabelControl4.TabIndex = 185
        Me.LabelControl4.Text = "Linea:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(22, 169)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 184
        Me.LabelControl3.Text = "Descripción:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(22, 128)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(45, 13)
        Me.LabelControl2.TabIndex = 183
        Me.LabelControl2.Text = "No Placa:"
        '
        'cmbMarca
        '
        Me.cmbMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMarca.FormattingEnabled = True
        Me.cmbMarca.Location = New System.Drawing.Point(86, 347)
        Me.cmbMarca.Name = "cmbMarca"
        Me.cmbMarca.Size = New System.Drawing.Size(165, 21)
        Me.cmbMarca.TabIndex = 181
        '
        'txtColor
        '
        Me.txtColor.EnterMoveNextControl = True
        Me.txtColor.Location = New System.Drawing.Point(86, 298)
        Me.txtColor.Name = "txtColor"
        Me.txtColor.Size = New System.Drawing.Size(165, 20)
        Me.txtColor.TabIndex = 180
        '
        'txtModelo
        '
        Me.txtModelo.EnterMoveNextControl = True
        Me.txtModelo.Location = New System.Drawing.Point(86, 253)
        Me.txtModelo.Name = "txtModelo"
        Me.txtModelo.Properties.Mask.EditMask = "n0"
        Me.txtModelo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtModelo.Size = New System.Drawing.Size(100, 20)
        Me.txtModelo.TabIndex = 179
        '
        'txtLinea
        '
        Me.txtLinea.EnterMoveNextControl = True
        Me.txtLinea.Location = New System.Drawing.Point(86, 213)
        Me.txtLinea.Name = "txtLinea"
        Me.txtLinea.Size = New System.Drawing.Size(165, 20)
        Me.txtLinea.TabIndex = 178
        '
        'txtDescripcion
        '
        Me.txtDescripcion.EnterMoveNextControl = True
        Me.txtDescripcion.Location = New System.Drawing.Point(86, 166)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(220, 20)
        Me.txtDescripcion.TabIndex = 177
        '
        'txtNoPlaca
        '
        Me.txtNoPlaca.EnterMoveNextControl = True
        Me.txtNoPlaca.Location = New System.Drawing.Point(86, 125)
        Me.txtNoPlaca.Name = "txtNoPlaca"
        Me.txtNoPlaca.Size = New System.Drawing.Size(121, 20)
        Me.txtNoPlaca.TabIndex = 176
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(10, 44)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(100, 20)
        Me.txtCodigo.TabIndex = 174
        Me.txtCodigo.Visible = False
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
        Me.btnCancelar.Location = New System.Drawing.Point(10, 484)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnCancelar.Size = New System.Drawing.Size(135, 60)
        Me.btnCancelar.TabIndex = 173
        Me.btnCancelar.Text = "CANCELAR"
        '
        'RadMenVehiculos
        '
        Me.RadMenVehiculos.AutoExpand = True
        Me.RadMenVehiculos.Glyph = CType(resources.GetObject("RadMenVehiculos.Glyph"), System.Drawing.Image)
        Me.RadMenVehiculos.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadMenVehiculos.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.RadMenBtnEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.RadMenBtnEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.RadMenBtnHistorial)})
        Me.RadMenVehiculos.Manager = Me.BarManager1
        Me.RadMenVehiculos.Name = "RadMenVehiculos"
        '
        'RadMenBtnEditar
        '
        Me.RadMenBtnEditar.Caption = "Editar"
        Me.RadMenBtnEditar.CloseRadialMenuOnItemClick = True
        Me.RadMenBtnEditar.Glyph = CType(resources.GetObject("RadMenBtnEditar.Glyph"), System.Drawing.Image)
        Me.RadMenBtnEditar.Id = 0
        Me.RadMenBtnEditar.Name = "RadMenBtnEditar"
        '
        'RadMenBtnEliminar
        '
        Me.RadMenBtnEliminar.Caption = "Eliminar"
        Me.RadMenBtnEliminar.CloseRadialMenuOnItemClick = True
        Me.RadMenBtnEliminar.Glyph = CType(resources.GetObject("RadMenBtnEliminar.Glyph"), System.Drawing.Image)
        Me.RadMenBtnEliminar.Id = 2
        Me.RadMenBtnEliminar.Name = "RadMenBtnEliminar"
        '
        'RadMenBtnHistorial
        '
        Me.RadMenBtnHistorial.Caption = "Historial"
        Me.RadMenBtnHistorial.CloseRadialMenuOnItemClick = True
        Me.RadMenBtnHistorial.Glyph = CType(resources.GetObject("RadMenBtnHistorial.Glyph"), System.Drawing.Image)
        Me.RadMenBtnHistorial.Id = 4
        Me.RadMenBtnHistorial.Name = "RadMenBtnHistorial"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RadMenBtnEditar, Me.RadMenBtnEliminar, Me.RadMenBtnHistorial})
        Me.BarManager1.MaxItemId = 5
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
        'btnCerrarVentana
        '
        Me.btnCerrarVentana.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarVentana.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnCerrarVentana.Appearance.Options.UseFont = True
        Me.btnCerrarVentana.Appearance.Options.UseForeColor = True
        Me.btnCerrarVentana.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.btnCerrarVentana.AppearanceHovered.Options.UseBackColor = True
        Me.btnCerrarVentana.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrarVentana.Image = CType(resources.GetObject("btnCerrarVentana.Image"), System.Drawing.Image)
        Me.btnCerrarVentana.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnCerrarVentana.Location = New System.Drawing.Point(998, 6)
        Me.btnCerrarVentana.Name = "btnCerrarVentana"
        Me.btnCerrarVentana.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnCerrarVentana.Size = New System.Drawing.Size(42, 36)
        Me.btnCerrarVentana.TabIndex = 180
        '
        'btnAceptarVentana
        '
        Me.btnAceptarVentana.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarVentana.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnAceptarVentana.Appearance.Options.UseFont = True
        Me.btnAceptarVentana.Appearance.Options.UseForeColor = True
        Me.btnAceptarVentana.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.btnAceptarVentana.AppearanceHovered.Options.UseBackColor = True
        Me.btnAceptarVentana.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarVentana.Image = CType(resources.GetObject("btnAceptarVentana.Image"), System.Drawing.Image)
        Me.btnAceptarVentana.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.btnAceptarVentana.Location = New System.Drawing.Point(1083, 48)
        Me.btnAceptarVentana.Name = "btnAceptarVentana"
        Me.btnAceptarVentana.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.btnAceptarVentana.Size = New System.Drawing.Size(42, 36)
        Me.btnAceptarVentana.TabIndex = 185
        '
        'viewClientesVehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAceptarVentana)
        Me.Controls.Add(Me.btnCerrarVentana)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.LabelControl150)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewClientesVehiculos"
        Me.Size = New System.Drawing.Size(1053, 681)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GROUP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GROUP.ResumeLayout(False)
        CType(Me.GridVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblVehiculosClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grou, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grou.ResumeLayout(False)
        Me.grou.PerformLayout()
        CType(Me.txtColor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModelo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLinea.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoPlaca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl150 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GROUP As DevExpress.XtraEditors.GroupControl
    Friend WithEvents grou As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbMarca As ComboBox
    Friend WithEvents txtColor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtModelo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLinea As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtNoPlaca As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridVehiculos As DevExpress.XtraGrid.GridControl
    Friend WithEvents TblVehiculosClientesBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents GridViewVehiculos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODVEHICULO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOPLACAS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESVEHICULO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLINEA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMODELO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOLOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RadMenVehiculos As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents RadMenBtnEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RadMenBtnEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnNuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colCODMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RadMenBtnHistorial As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCerrarVentana As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptarVentana As DevExpress.XtraEditors.SimpleButton
End Class
