<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewCxp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewCxp))
        Me.LabelControl173 = New DevExpress.XtraEditors.LabelControl()
        Me.GridFacPend = New DevExpress.XtraGrid.GridControl()
        Me.TblFacPendSaldoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewFacPend = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALVENTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colABONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CODCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHAVENCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALABONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVALIMPORTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalSaldos = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.RadialMenuCxp = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.btnMenuAbono = New DevExpress.XtraBars.BarButtonItem()
        Me.btnMenuListaAbonos = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.NavFrameCxp = New DevExpress.XtraBars.Navigation.NavigationFrame()
        Me.NP_Compras = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.NP_Proveedores = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.GridProveedores = New DevExpress.XtraGrid.GridControl()
        Me.TblProveedoresSaldosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSCxc = New Ares.DSCxc()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODIGO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMPRESA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTELEMPRESA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONTACTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTELCONTACTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.switchListado = New DevExpress.XtraEditors.ToggleSwitch()
        CType(Me.GridFacPend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblFacPendSaldoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewFacPend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadialMenuCxp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NavFrameCxp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavFrameCxp.SuspendLayout()
        Me.NP_Compras.SuspendLayout()
        Me.NP_Proveedores.SuspendLayout()
        CType(Me.GridProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProveedoresSaldosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSCxc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.switchListado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl173
        '
        Me.LabelControl173.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl173.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl173.Location = New System.Drawing.Point(76, 17)
        Me.LabelControl173.Name = "LabelControl173"
        Me.LabelControl173.Size = New System.Drawing.Size(355, 33)
        Me.LabelControl173.TabIndex = 207
        Me.LabelControl173.Text = "Compras pendientes de Pagar"
        '
        'GridFacPend
        '
        Me.GridFacPend.DataSource = Me.TblFacPendSaldoBindingSource
        Me.GridFacPend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridFacPend.Location = New System.Drawing.Point(0, 0)
        Me.GridFacPend.MainView = Me.GridViewFacPend
        Me.GridFacPend.Name = "GridFacPend"
        Me.GridFacPend.Size = New System.Drawing.Size(988, 574)
        Me.GridFacPend.TabIndex = 209
        Me.GridFacPend.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewFacPend})
        '
        'TblFacPendSaldoBindingSource
        '
        Me.TblFacPendSaldoBindingSource.DataMember = "tblFacPendSaldo"
        Me.TblFacPendSaldoBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewFacPend
        '
        Me.GridViewFacPend.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GridViewFacPend.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridViewFacPend.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNIT, Me.colCLIENTE, Me.colCODDOC, Me.colCORRELATIVO, Me.colFECHA, Me.colTOTALVENTA, Me.colSALDO, Me.colABONO, Me.CODCLIENTE, Me.colFECHAVENCE, Me.colVALABONO, Me.colVALSALDO, Me.colVALIMPORTE})
        Me.GridViewFacPend.GridControl = Me.GridFacPend
        Me.GridViewFacPend.GroupCount = 1
        Me.GridViewFacPend.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VALSALDO", Nothing, "(SALDO: Q {0:0.##})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VALABONO", Nothing, "(ABONO: Q {0:0.##})")})
        Me.GridViewFacPend.Name = "GridViewFacPend"
        Me.GridViewFacPend.OptionsBehavior.Editable = False
        Me.GridViewFacPend.OptionsFind.FindNullPrompt = "Escriba para buscar..."
        Me.GridViewFacPend.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewFacPend.OptionsView.ShowAutoFilterRow = True
        Me.GridViewFacPend.OptionsView.ShowFooter = True
        Me.GridViewFacPend.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colCLIENTE, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colNIT
        '
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 0
        Me.colNIT.Width = 83
        '
        'colCLIENTE
        '
        Me.colCLIENTE.Caption = "PROVEEDOR"
        Me.colCLIENTE.FieldName = "CLIENTE"
        Me.colCLIENTE.Name = "colCLIENTE"
        Me.colCLIENTE.Visible = True
        Me.colCLIENTE.VisibleIndex = 1
        Me.colCLIENTE.Width = 223
        '
        'colCODDOC
        '
        Me.colCODDOC.Caption = "SERIE F"
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 1
        Me.colCODDOC.Width = 72
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.Caption = "NUMERO F"
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 2
        Me.colCORRELATIVO.Width = 77
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 3
        Me.colFECHA.Width = 73
        '
        'colTOTALVENTA
        '
        Me.colTOTALVENTA.Caption = "IMPORTE"
        Me.colTOTALVENTA.FieldName = "TOTALVENTA"
        Me.colTOTALVENTA.Name = "colTOTALVENTA"
        Me.colTOTALVENTA.Visible = True
        Me.colTOTALVENTA.VisibleIndex = 4
        Me.colTOTALVENTA.Width = 115
        '
        'colSALDO
        '
        Me.colSALDO.FieldName = "SALDO"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Visible = True
        Me.colSALDO.VisibleIndex = 5
        Me.colSALDO.Width = 104
        '
        'colABONO
        '
        Me.colABONO.FieldName = "ABONO"
        Me.colABONO.Name = "colABONO"
        Me.colABONO.Visible = True
        Me.colABONO.VisibleIndex = 6
        Me.colABONO.Width = 111
        '
        'CODCLIENTE
        '
        Me.CODCLIENTE.FieldName = "CODCLIENTE"
        Me.CODCLIENTE.Name = "CODCLIENTE"
        '
        'colFECHAVENCE
        '
        Me.colFECHAVENCE.Caption = "VENCE"
        Me.colFECHAVENCE.FieldName = "FECHAVENCE"
        Me.colFECHAVENCE.Name = "colFECHAVENCE"
        Me.colFECHAVENCE.Visible = True
        Me.colFECHAVENCE.VisibleIndex = 7
        Me.colFECHAVENCE.Width = 112
        '
        'colVALABONO
        '
        Me.colVALABONO.FieldName = "VALABONO"
        Me.colVALABONO.Name = "colVALABONO"
        '
        'colVALSALDO
        '
        Me.colVALSALDO.FieldName = "VALSALDO"
        Me.colVALSALDO.Name = "colVALSALDO"
        '
        'colVALIMPORTE
        '
        Me.colVALIMPORTE.FieldName = "VALIMPORTE"
        Me.colVALIMPORTE.Name = "colVALIMPORTE"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(850, 52)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(13, 23)
        Me.LabelControl3.TabIndex = 219
        Me.LabelControl3.Text = "Q"
        '
        'lbTotalSaldos
        '
        Me.lbTotalSaldos.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalSaldos.Location = New System.Drawing.Point(884, 52)
        Me.lbTotalSaldos.Name = "lbTotalSaldos"
        Me.lbTotalSaldos.Size = New System.Drawing.Size(118, 23)
        Me.lbTotalSaldos.TabIndex = 218
        Me.lbTotalSaldos.Text = "99,999,999.99"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(850, 30)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(81, 16)
        Me.LabelControl1.TabIndex = 217
        Me.LabelControl1.Text = "Total deuda:"
        '
        'RadialMenuCxp
        '
        Me.RadialMenuCxp.AutoExpand = True
        Me.RadialMenuCxp.Glyph = CType(resources.GetObject("RadialMenuCxp.Glyph"), System.Drawing.Image)
        Me.RadialMenuCxp.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuCxp.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuAbono), New DevExpress.XtraBars.LinkPersistInfo(Me.btnMenuListaAbonos)})
        Me.RadialMenuCxp.Manager = Me.BarManager1
        Me.RadialMenuCxp.Name = "RadialMenuCxp"
        '
        'btnMenuAbono
        '
        Me.btnMenuAbono.Caption = "Realizar Abono"
        Me.btnMenuAbono.CloseRadialMenuOnItemClick = True
        Me.btnMenuAbono.Glyph = CType(resources.GetObject("btnMenuAbono.Glyph"), System.Drawing.Image)
        Me.btnMenuAbono.Id = 0
        Me.btnMenuAbono.Name = "btnMenuAbono"
        '
        'btnMenuListaAbonos
        '
        Me.btnMenuListaAbonos.Caption = "Lista de Abonos"
        Me.btnMenuListaAbonos.CloseRadialMenuOnItemClick = True
        Me.btnMenuListaAbonos.Glyph = CType(resources.GetObject("btnMenuListaAbonos.Glyph"), System.Drawing.Image)
        Me.btnMenuListaAbonos.Id = 1
        Me.btnMenuListaAbonos.Name = "btnMenuListaAbonos"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnMenuAbono, Me.btnMenuListaAbonos})
        Me.BarManager1.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1039, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 696)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1039, 0)
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
        Me.barDockControlRight.Location = New System.Drawing.Point(1039, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 696)
        '
        'NavFrameCxp
        '
        Me.NavFrameCxp.Controls.Add(Me.NP_Compras)
        Me.NavFrameCxp.Controls.Add(Me.NP_Proveedores)
        Me.NavFrameCxp.Location = New System.Drawing.Point(21, 86)
        Me.NavFrameCxp.Name = "NavFrameCxp"
        Me.NavFrameCxp.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NP_Compras, Me.NP_Proveedores})
        Me.NavFrameCxp.SelectedPage = Me.NP_Compras
        Me.NavFrameCxp.Size = New System.Drawing.Size(988, 574)
        Me.NavFrameCxp.TabIndex = 224
        Me.NavFrameCxp.Text = "NavFrameCxP"
        Me.NavFrameCxp.TransitionAnimationProperties.FrameCount = 500
        Me.NavFrameCxp.TransitionAnimationProperties.FrameInterval = 5000
        Me.NavFrameCxp.TransitionType = DevExpress.Utils.Animation.Transitions.Cover
        '
        'NP_Compras
        '
        Me.NP_Compras.Controls.Add(Me.GridFacPend)
        Me.NP_Compras.Name = "NP_Compras"
        Me.NP_Compras.Size = New System.Drawing.Size(988, 574)
        '
        'NP_Proveedores
        '
        Me.NP_Proveedores.Controls.Add(Me.GridProveedores)
        Me.NP_Proveedores.Name = "NP_Proveedores"
        Me.NP_Proveedores.Size = New System.Drawing.Size(988, 574)
        '
        'GridProveedores
        '
        Me.GridProveedores.DataSource = Me.TblProveedoresSaldosBindingSource
        Me.GridProveedores.Location = New System.Drawing.Point(19, 57)
        Me.GridProveedores.MainView = Me.GridView1
        Me.GridProveedores.MenuManager = Me.BarManager1
        Me.GridProveedores.Name = "GridProveedores"
        Me.GridProveedores.Size = New System.Drawing.Size(933, 469)
        Me.GridProveedores.TabIndex = 0
        Me.GridProveedores.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'TblProveedoresSaldosBindingSource
        '
        Me.TblProveedoresSaldosBindingSource.DataMember = "tblProveedoresSaldos"
        Me.TblProveedoresSaldosBindingSource.DataSource = Me.DSCxc
        '
        'DSCxc
        '
        Me.DSCxc.DataSetName = "DSCxc"
        Me.DSCxc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODIGO, Me.colNIT1, Me.colEMPRESA, Me.colTELEMPRESA, Me.colCONTACTO, Me.colTELCONTACTO, Me.colSALDO1})
        Me.GridView1.GridControl = Me.GridProveedores
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'colCODIGO
        '
        Me.colCODIGO.FieldName = "CODIGO"
        Me.colCODIGO.Name = "colCODIGO"
        Me.colCODIGO.Visible = True
        Me.colCODIGO.VisibleIndex = 0
        Me.colCODIGO.Width = 81
        '
        'colNIT1
        '
        Me.colNIT1.FieldName = "NIT"
        Me.colNIT1.Name = "colNIT1"
        Me.colNIT1.Visible = True
        Me.colNIT1.VisibleIndex = 1
        Me.colNIT1.Width = 114
        '
        'colEMPRESA
        '
        Me.colEMPRESA.FieldName = "EMPRESA"
        Me.colEMPRESA.Name = "colEMPRESA"
        Me.colEMPRESA.Visible = True
        Me.colEMPRESA.VisibleIndex = 2
        Me.colEMPRESA.Width = 169
        '
        'colTELEMPRESA
        '
        Me.colTELEMPRESA.FieldName = "TELEMPRESA"
        Me.colTELEMPRESA.Name = "colTELEMPRESA"
        Me.colTELEMPRESA.Visible = True
        Me.colTELEMPRESA.VisibleIndex = 3
        Me.colTELEMPRESA.Width = 111
        '
        'colCONTACTO
        '
        Me.colCONTACTO.FieldName = "CONTACTO"
        Me.colCONTACTO.Name = "colCONTACTO"
        Me.colCONTACTO.Visible = True
        Me.colCONTACTO.VisibleIndex = 4
        Me.colCONTACTO.Width = 164
        '
        'colTELCONTACTO
        '
        Me.colTELCONTACTO.FieldName = "TELCONTACTO"
        Me.colTELCONTACTO.Name = "colTELCONTACTO"
        Me.colTELCONTACTO.Visible = True
        Me.colTELCONTACTO.VisibleIndex = 5
        Me.colTELCONTACTO.Width = 133
        '
        'colSALDO1
        '
        Me.colSALDO1.DisplayFormat.FormatString = "Q"
        Me.colSALDO1.FieldName = "SALDO"
        Me.colSALDO1.Name = "colSALDO1"
        Me.colSALDO1.Visible = True
        Me.colSALDO1.VisibleIndex = 6
        Me.colSALDO1.Width = 143
        '
        'switchListado
        '
        Me.switchListado.Location = New System.Drawing.Point(632, 56)
        Me.switchListado.MenuManager = Me.BarManager1
        Me.switchListado.Name = "switchListado"
        Me.switchListado.Properties.OffText = "Listado de Compras "
        Me.switchListado.Properties.OnText = "Listado por Proveedor"
        Me.switchListado.Size = New System.Drawing.Size(200, 24)
        Me.switchListado.TabIndex = 225
        '
        'viewCxp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.switchListado)
        Me.Controls.Add(Me.NavFrameCxp)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.lbTotalSaldos)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl173)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewCxp"
        Me.Size = New System.Drawing.Size(1039, 696)
        CType(Me.GridFacPend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblFacPendSaldoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewFacPend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadialMenuCxp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NavFrameCxp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavFrameCxp.ResumeLayout(False)
        Me.NP_Compras.ResumeLayout(False)
        Me.NP_Proveedores.ResumeLayout(False)
        CType(Me.GridProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProveedoresSaldosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSCxc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.switchListado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl173 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridFacPend As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewFacPend As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALVENTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colABONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalSaldos As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblFacPendSaldoBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents RadialMenuCxp As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents btnMenuAbono As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnMenuListaAbonos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents CODCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents switchListado As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents NavFrameCxp As DevExpress.XtraBars.Navigation.NavigationFrame
    Friend WithEvents NP_Compras As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NP_Proveedores As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents GridProveedores As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblProveedoresSaldosBindingSource As BindingSource
    Friend WithEvents DSCxc As DSCxc
    Friend WithEvents colCODIGO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPRESA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTELEMPRESA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONTACTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTELCONTACTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHAVENCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALABONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVALIMPORTE As DevExpress.XtraGrid.Columns.GridColumn
End Class
