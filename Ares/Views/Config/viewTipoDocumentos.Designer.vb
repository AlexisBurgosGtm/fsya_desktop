<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewTipoDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewTipoDocumentos))
        Me.NavigationFrame = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.NP_Listado = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.btnNuevo = New DevExpress.XtraEditors.SimpleButton()
        Me.GridListado = New DevExpress.XtraGrid.GridControl()
        Me.TblTipoDocumentosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewListado = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTIPODOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colRESOLUCION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colAUTORIZACION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFRASE1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFRASE2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFORMATO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NP_Edicion = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFormato = New DevExpress.XtraEditors.TextEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItemEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemDeshabilitar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemHabilitar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFrase2 = New DevExpress.XtraEditors.TextEdit()
        Me.txtFrase1 = New DevExpress.XtraEditors.TextEdit()
        Me.txtAutorizacion = New DevExpress.XtraEditors.TextEdit()
        Me.txtResolucion = New DevExpress.XtraEditors.TextEdit()
        Me.txtDesdoc = New DevExpress.XtraEditors.TextEdit()
        Me.txtCorrelativo = New DevExpress.XtraEditors.TextEdit()
        Me.txtCoddoc = New DevExpress.XtraEditors.TextEdit()
        Me.txtId = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.RadialMenu = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.colACTIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.NavigationFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigationFrame.SuspendLayout()
        Me.NP_Listado.SuspendLayout()
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTipoDocumentosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NP_Edicion.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtFormato.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFrase2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFrase1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAutorizacion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtResolucion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesdoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCorrelativo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCoddoc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadialMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NavigationFrame
        '
        Me.NavigationFrame.Controls.Add(Me.NP_Listado)
        Me.NavigationFrame.Controls.Add(Me.NP_Edicion)
        Me.NavigationFrame.Location = New System.Drawing.Point(15, 39)
        Me.NavigationFrame.Name = "NavigationFrame"
        Me.NavigationFrame.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NP_Listado, Me.NP_Edicion})
        Me.NavigationFrame.SelectedPage = Me.NP_Listado
        Me.NavigationFrame.Size = New System.Drawing.Size(1008, 620)
        Me.NavigationFrame.TabIndex = 0
        Me.NavigationFrame.Text = "NavigationFrame1"
        Me.NavigationFrame.TransitionAnimationProperties.FrameCount = 500
        Me.NavigationFrame.TransitionAnimationProperties.FrameInterval = 5000
        '
        'NP_Listado
        '
        Me.NP_Listado.Controls.Add(Me.btnNuevo)
        Me.NP_Listado.Controls.Add(Me.GridListado)
        Me.NP_Listado.Name = "NP_Listado"
        Me.NP_Listado.Size = New System.Drawing.Size(1008, 620)
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnNuevo.Location = New System.Drawing.Point(857, 8)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(137, 59)
        Me.btnNuevo.TabIndex = 1
        Me.btnNuevo.Text = "Nuevo"
        '
        'GridListado
        '
        Me.GridListado.DataSource = Me.TblTipoDocumentosBindingSource
        Me.GridListado.Location = New System.Drawing.Point(5, 76)
        Me.GridListado.MainView = Me.GridViewListado
        Me.GridListado.Name = "GridListado"
        Me.GridListado.Size = New System.Drawing.Size(990, 524)
        Me.GridListado.TabIndex = 0
        Me.GridListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListado})
        '
        'TblTipoDocumentosBindingSource
        '
        Me.TblTipoDocumentosBindingSource.DataMember = "tblTipoDocumentos"
        Me.TblTipoDocumentosBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewListado
        '
        Me.GridViewListado.Appearance.GroupPanel.BackColor = System.Drawing.Color.Gray
        Me.GridViewListado.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridViewListado.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridViewListado.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridViewListado.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID, Me.colCODDOC, Me.colCORRELATIVO, Me.colDESDOC, Me.colTIPODOC, Me.colRESOLUCION, Me.colAUTORIZACION, Me.colFRASE1, Me.colFRASE2, Me.colFORMATO, Me.colACTIVO})
        Me.GridViewListado.GridControl = Me.GridListado
        Me.GridViewListado.Name = "GridViewListado"
        Me.GridViewListado.OptionsBehavior.AutoExpandAllGroups = True
        Me.GridViewListado.OptionsBehavior.Editable = False
        Me.GridViewListado.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewListado.OptionsView.ShowAutoFilterRow = True
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 1
        Me.colCODDOC.Width = 98
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 2
        Me.colCORRELATIVO.Width = 122
        '
        'colDESDOC
        '
        Me.colDESDOC.Caption = "DESCRIPCION"
        Me.colDESDOC.FieldName = "DESDOC"
        Me.colDESDOC.Name = "colDESDOC"
        Me.colDESDOC.Visible = True
        Me.colDESDOC.VisibleIndex = 3
        Me.colDESDOC.Width = 224
        '
        'colTIPODOC
        '
        Me.colTIPODOC.Caption = "TIPO"
        Me.colTIPODOC.FieldName = "TIPODOC"
        Me.colTIPODOC.Name = "colTIPODOC"
        Me.colTIPODOC.Visible = True
        Me.colTIPODOC.VisibleIndex = 0
        Me.colTIPODOC.Width = 78
        '
        'colRESOLUCION
        '
        Me.colRESOLUCION.FieldName = "RESOLUCION"
        Me.colRESOLUCION.Name = "colRESOLUCION"
        Me.colRESOLUCION.Visible = True
        Me.colRESOLUCION.VisibleIndex = 4
        Me.colRESOLUCION.Width = 142
        '
        'colAUTORIZACION
        '
        Me.colAUTORIZACION.FieldName = "AUTORIZACION"
        Me.colAUTORIZACION.Name = "colAUTORIZACION"
        Me.colAUTORIZACION.Visible = True
        Me.colAUTORIZACION.VisibleIndex = 5
        Me.colAUTORIZACION.Width = 142
        '
        'colFRASE1
        '
        Me.colFRASE1.Caption = "CORRELATIVO AUTORIZ"
        Me.colFRASE1.FieldName = "FRASE1"
        Me.colFRASE1.Name = "colFRASE1"
        Me.colFRASE1.Visible = True
        Me.colFRASE1.VisibleIndex = 6
        Me.colFRASE1.Width = 166
        '
        'colFRASE2
        '
        Me.colFRASE2.FieldName = "FRASE2"
        Me.colFRASE2.Name = "colFRASE2"
        Me.colFRASE2.Width = 137
        '
        'colFORMATO
        '
        Me.colFORMATO.Caption = "GridColumn1"
        Me.colFORMATO.FieldName = "FORMATO"
        Me.colFORMATO.Name = "colFORMATO"
        '
        'NP_Edicion
        '
        Me.NP_Edicion.Controls.Add(Me.GroupControl1)
        Me.NP_Edicion.Name = "NP_Edicion"
        Me.NP_Edicion.Size = New System.Drawing.Size(1008, 620)
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.txtFormato)
        Me.GroupControl1.Controls.Add(Me.btnCancelar)
        Me.GroupControl1.Controls.Add(Me.btnGuardar)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.cmbTipoDoc)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.txtFrase2)
        Me.GroupControl1.Controls.Add(Me.txtFrase1)
        Me.GroupControl1.Controls.Add(Me.txtAutorizacion)
        Me.GroupControl1.Controls.Add(Me.txtResolucion)
        Me.GroupControl1.Controls.Add(Me.txtDesdoc)
        Me.GroupControl1.Controls.Add(Me.txtCorrelativo)
        Me.GroupControl1.Controls.Add(Me.txtCoddoc)
        Me.GroupControl1.Controls.Add(Me.txtId)
        Me.GroupControl1.Location = New System.Drawing.Point(14, 19)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(979, 579)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Detalle del Producto"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(60, 400)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl10.TabIndex = 22
        Me.LabelControl10.Text = "Formato:"
        '
        'txtFormato
        '
        Me.txtFormato.EnterMoveNextControl = True
        Me.txtFormato.Location = New System.Drawing.Point(123, 397)
        Me.txtFormato.MenuManager = Me.BarManager1
        Me.txtFormato.Name = "txtFormato"
        Me.txtFormato.Size = New System.Drawing.Size(191, 20)
        Me.txtFormato.TabIndex = 8
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItemEditar, Me.BarButtonItemEliminar, Me.BarButtonItemDeshabilitar, Me.BarButtonItemHabilitar})
        Me.BarManager1.MaxItemId = 4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1037, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 665)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1037, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 665)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1037, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 665)
        '
        'BarButtonItemEditar
        '
        Me.BarButtonItemEditar.Caption = "Editar"
        Me.BarButtonItemEditar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemEditar.Glyph = CType(resources.GetObject("BarButtonItemEditar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemEditar.Id = 0
        Me.BarButtonItemEditar.Name = "BarButtonItemEditar"
        '
        'BarButtonItemEliminar
        '
        Me.BarButtonItemEliminar.Caption = "Eliminar"
        Me.BarButtonItemEliminar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemEliminar.Glyph = CType(resources.GetObject("BarButtonItemEliminar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemEliminar.Id = 1
        Me.BarButtonItemEliminar.Name = "BarButtonItemEliminar"
        '
        'BarButtonItemDeshabilitar
        '
        Me.BarButtonItemDeshabilitar.Caption = "DESHABILITAR"
        Me.BarButtonItemDeshabilitar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemDeshabilitar.Glyph = CType(resources.GetObject("BarButtonItemDeshabilitar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemDeshabilitar.Id = 2
        Me.BarButtonItemDeshabilitar.Name = "BarButtonItemDeshabilitar"
        '
        'BarButtonItemHabilitar
        '
        Me.BarButtonItemHabilitar.Caption = "HABILITAR"
        Me.BarButtonItemHabilitar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemHabilitar.Glyph = CType(resources.GetObject("BarButtonItemHabilitar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemHabilitar.Id = 3
        Me.BarButtonItemHabilitar.Name = "BarButtonItemHabilitar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(129, 460)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(156, 58)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(318, 460)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(156, 58)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(59, 71)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl9.TabIndex = 18
        Me.LabelControl9.Text = "Tipo de transacción:"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.Location = New System.Drawing.Point(59, 90)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(274, 21)
        Me.cmbTipoDoc.TabIndex = 0
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(60, 361)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(31, 13)
        Me.LabelControl8.TabIndex = 16
        Me.LabelControl8.Text = "Frase:"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(60, 326)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(112, 13)
        Me.LabelControl7.TabIndex = 15
        Me.LabelControl7.Text = "Correlativo Autorizado:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(59, 290)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl6.TabIndex = 14
        Me.LabelControl6.Text = "No. Autorización:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(59, 255)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl5.TabIndex = 13
        Me.LabelControl5.Text = "Resolución Fiscal:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(60, 208)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl4.TabIndex = 12
        Me.LabelControl4.Text = "Descripción:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(60, 172)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl3.TabIndex = 11
        Me.LabelControl3.Text = "Correlativo:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(60, 134)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl2.TabIndex = 10
        Me.LabelControl2.Text = "Serie:"
        '
        'txtFrase2
        '
        Me.txtFrase2.EnterMoveNextControl = True
        Me.txtFrase2.Location = New System.Drawing.Point(123, 358)
        Me.txtFrase2.MenuManager = Me.BarManager1
        Me.txtFrase2.Name = "txtFrase2"
        Me.txtFrase2.Size = New System.Drawing.Size(351, 20)
        Me.txtFrase2.TabIndex = 7
        '
        'txtFrase1
        '
        Me.txtFrase1.EnterMoveNextControl = True
        Me.txtFrase1.Location = New System.Drawing.Point(178, 323)
        Me.txtFrase1.MenuManager = Me.BarManager1
        Me.txtFrase1.Name = "txtFrase1"
        Me.txtFrase1.Size = New System.Drawing.Size(296, 20)
        Me.txtFrase1.TabIndex = 6
        '
        'txtAutorizacion
        '
        Me.txtAutorizacion.EnterMoveNextControl = True
        Me.txtAutorizacion.Location = New System.Drawing.Point(149, 287)
        Me.txtAutorizacion.MenuManager = Me.BarManager1
        Me.txtAutorizacion.Name = "txtAutorizacion"
        Me.txtAutorizacion.Size = New System.Drawing.Size(325, 20)
        Me.txtAutorizacion.TabIndex = 5
        '
        'txtResolucion
        '
        Me.txtResolucion.EnterMoveNextControl = True
        Me.txtResolucion.Location = New System.Drawing.Point(149, 252)
        Me.txtResolucion.MenuManager = Me.BarManager1
        Me.txtResolucion.Name = "txtResolucion"
        Me.txtResolucion.Size = New System.Drawing.Size(325, 20)
        Me.txtResolucion.TabIndex = 4
        '
        'txtDesdoc
        '
        Me.txtDesdoc.EnterMoveNextControl = True
        Me.txtDesdoc.Location = New System.Drawing.Point(123, 205)
        Me.txtDesdoc.MenuManager = Me.BarManager1
        Me.txtDesdoc.Name = "txtDesdoc"
        Me.txtDesdoc.Size = New System.Drawing.Size(351, 20)
        Me.txtDesdoc.TabIndex = 3
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.EnterMoveNextControl = True
        Me.txtCorrelativo.Location = New System.Drawing.Point(123, 169)
        Me.txtCorrelativo.MenuManager = Me.BarManager1
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(169, 20)
        Me.txtCorrelativo.TabIndex = 2
        '
        'txtCoddoc
        '
        Me.txtCoddoc.EnterMoveNextControl = True
        Me.txtCoddoc.Location = New System.Drawing.Point(123, 131)
        Me.txtCoddoc.MenuManager = Me.BarManager1
        Me.txtCoddoc.Name = "txtCoddoc"
        Me.txtCoddoc.Size = New System.Drawing.Size(169, 20)
        Me.txtCoddoc.TabIndex = 1
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(8, 23)
        Me.txtId.MenuManager = Me.BarManager1
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(100, 20)
        Me.txtId.TabIndex = 0
        Me.txtId.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(79, 10)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(314, 23)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Gestión de Tipos de Documentos"
        '
        'RadialMenu
        '
        Me.RadialMenu.AutoExpand = True
        Me.RadialMenu.Glyph = CType(resources.GetObject("RadialMenu.Glyph"), System.Drawing.Image)
        Me.RadialMenu.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenu.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemDeshabilitar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemHabilitar)})
        Me.RadialMenu.Manager = Me.BarManager1
        Me.RadialMenu.Name = "RadialMenu"
        '
        'colACTIVO
        '
        Me.colACTIVO.Caption = "ACTIVO"
        Me.colACTIVO.FieldName = "ACTIVO"
        Me.colACTIVO.Name = "colACTIVO"
        Me.colACTIVO.Visible = True
        Me.colACTIVO.VisibleIndex = 7
        '
        'viewTipoDocumentos
        '
        Me.Appearance.BackColor = System.Drawing.SystemColors.Control
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.NavigationFrame)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewTipoDocumentos"
        Me.Size = New System.Drawing.Size(1037, 665)
        CType(Me.NavigationFrame, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigationFrame.ResumeLayout(False)
        Me.NP_Listado.ResumeLayout(False)
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTipoDocumentosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NP_Edicion.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtFormato.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFrase2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFrase1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAutorizacion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtResolucion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesdoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCorrelativo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCoddoc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadialMenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents NavigationFrame As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents NP_Listado As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NP_Edicion As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnNuevo As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewListado As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblTipoDocumentosBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTIPODOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colRESOLUCION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colAUTORIZACION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFRASE1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFRASE2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RadialMenu As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarButtonItemEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFrase2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFrase1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAutorizacion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtResolucion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDesdoc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCorrelativo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtCoddoc As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoDoc As ComboBox
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFormato As DevExpress.XtraEditors.TextEdit
    Friend WithEvents colFORMATO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BarButtonItemDeshabilitar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemHabilitar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents colACTIVO As DevExpress.XtraGrid.Columns.GridColumn
End Class
