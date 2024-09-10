<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewSyncTablas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewSyncTablas))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.groupcontrol = New DevExpress.XtraEditors.GroupControl()
        Me.btnRestaurarBackup = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGenerarPlantillaProductos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnObtenerProductosPrecios = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.FlyoutPanelDetalleTraslado = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.txtDataTrasladoObs = New System.Windows.Forms.TextBox()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GridDetalle = New System.Windows.Forms.DataGridView()
        Me.CODPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALUNIDADESDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALCOSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALPRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblDetalleTrasladoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetInventarios = New Ares.DataSetInventarios()
        Me.GridTraslados = New DevExpress.XtraGrid.GridControl()
        Me.TblTrasladosPendientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewTraslados = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItemDetalle = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemGenerar = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItemEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.RadMenTraslados = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.cmbGenCoddoc = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbGenCorrelativo = New DevExpress.XtraEditors.LabelControl()
        CType(Me.groupcontrol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupcontrol.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.FlyoutPanelDetalleTraslado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelDetalleTraslado.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDetalleTrasladoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTraslados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTrasladosPendientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTraslados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenTraslados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(89, 22)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(292, 25)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Traslados de Otras Bodegas"
        '
        'groupcontrol
        '
        Me.groupcontrol.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.groupcontrol.Appearance.Options.UseBackColor = True
        Me.groupcontrol.Controls.Add(Me.btnRestaurarBackup)
        Me.groupcontrol.Controls.Add(Me.btnGenerarPlantillaProductos)
        Me.groupcontrol.Controls.Add(Me.btnObtenerProductosPrecios)
        Me.groupcontrol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupcontrol.Location = New System.Drawing.Point(0, 0)
        Me.groupcontrol.Name = "groupcontrol"
        Me.groupcontrol.Size = New System.Drawing.Size(0, 0)
        Me.groupcontrol.TabIndex = 1
        Me.groupcontrol.Text = "Acciones"
        '
        'btnRestaurarBackup
        '
        Me.btnRestaurarBackup.Appearance.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.btnRestaurarBackup.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnRestaurarBackup.Appearance.Options.UseBackColor = True
        Me.btnRestaurarBackup.Appearance.Options.UseForeColor = True
        Me.btnRestaurarBackup.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnRestaurarBackup.Image = CType(resources.GetObject("btnRestaurarBackup.Image"), System.Drawing.Image)
        Me.btnRestaurarBackup.Location = New System.Drawing.Point(7, 151)
        Me.btnRestaurarBackup.Name = "btnRestaurarBackup"
        Me.btnRestaurarBackup.Size = New System.Drawing.Size(181, 67)
        Me.btnRestaurarBackup.TabIndex = 4
        Me.btnRestaurarBackup.Text = "Restaurar Productos Precios"
        Me.btnRestaurarBackup.Visible = False
        '
        'btnGenerarPlantillaProductos
        '
        Me.btnGenerarPlantillaProductos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnGenerarPlantillaProductos.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnGenerarPlantillaProductos.Appearance.Options.UseBackColor = True
        Me.btnGenerarPlantillaProductos.Appearance.Options.UseForeColor = True
        Me.btnGenerarPlantillaProductos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnGenerarPlantillaProductos.Image = CType(resources.GetObject("btnGenerarPlantillaProductos.Image"), System.Drawing.Image)
        Me.btnGenerarPlantillaProductos.Location = New System.Drawing.Point(7, 308)
        Me.btnGenerarPlantillaProductos.Name = "btnGenerarPlantillaProductos"
        Me.btnGenerarPlantillaProductos.Size = New System.Drawing.Size(181, 73)
        Me.btnGenerarPlantillaProductos.TabIndex = 3
        Me.btnGenerarPlantillaProductos.Text = "Generar Plantilla Precios"
        Me.btnGenerarPlantillaProductos.Visible = False
        '
        'btnObtenerProductosPrecios
        '
        Me.btnObtenerProductosPrecios.Image = CType(resources.GetObject("btnObtenerProductosPrecios.Image"), System.Drawing.Image)
        Me.btnObtenerProductosPrecios.Location = New System.Drawing.Point(7, 37)
        Me.btnObtenerProductosPrecios.Name = "btnObtenerProductosPrecios"
        Me.btnObtenerProductosPrecios.Size = New System.Drawing.Size(181, 67)
        Me.btnObtenerProductosPrecios.TabIndex = 2
        Me.btnObtenerProductosPrecios.Text = "Obtener Productos y Precios"
        Me.btnObtenerProductosPrecios.Visible = False
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2
        Me.SplitContainerControl1.Location = New System.Drawing.Point(11, 65)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GroupControl2)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.groupcontrol)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1258, 604)
        Me.SplitContainerControl1.SplitterPosition = 1300
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.FlyoutPanelDetalleTraslado)
        Me.GroupControl2.Controls.Add(Me.GridTraslados)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1253, 604)
        Me.GroupControl2.TabIndex = 0
        Me.GroupControl2.Text = "Traslados Pendientes"
        '
        'FlyoutPanelDetalleTraslado
        '
        Me.FlyoutPanelDetalleTraslado.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelDetalleTraslado.Location = New System.Drawing.Point(88, 428)
        Me.FlyoutPanelDetalleTraslado.Name = "FlyoutPanelDetalleTraslado"
        Me.FlyoutPanelDetalleTraslado.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Left
        Me.FlyoutPanelDetalleTraslado.Options.CloseOnOuterClick = True
        Me.FlyoutPanelDetalleTraslado.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Left
        Me.FlyoutPanelDetalleTraslado.OwnerControl = Me
        Me.FlyoutPanelDetalleTraslado.Size = New System.Drawing.Size(567, 651)
        Me.FlyoutPanelDetalleTraslado.TabIndex = 1
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.txtDataTrasladoObs)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl2)
        Me.FlyoutPanelControl1.Controls.Add(Me.GridDetalle)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelDetalleTraslado
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(567, 651)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'txtDataTrasladoObs
        '
        Me.txtDataTrasladoObs.Location = New System.Drawing.Point(99, 11)
        Me.txtDataTrasladoObs.Multiline = True
        Me.txtDataTrasladoObs.Name = "txtDataTrasladoObs"
        Me.txtDataTrasladoObs.Size = New System.Drawing.Size(416, 54)
        Me.txtDataTrasladoObs.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(16, 16)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Observaciones:"
        '
        'GridDetalle
        '
        Me.GridDetalle.AllowUserToAddRows = False
        Me.GridDetalle.AllowUserToDeleteRows = False
        Me.GridDetalle.AutoGenerateColumns = False
        Me.GridDetalle.BackgroundColor = System.Drawing.Color.White
        Me.GridDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPRODDataGridViewTextBoxColumn, Me.DESPRODDataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.TOTALUNIDADESDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn, Me.PRECIODataGridViewTextBoxColumn, Me.TOTALCOSTODataGridViewTextBoxColumn, Me.TOTALPRECIODataGridViewTextBoxColumn})
        Me.GridDetalle.DataSource = Me.TblDetalleTrasladoBindingSource
        Me.GridDetalle.GridColor = System.Drawing.Color.LightBlue
        Me.GridDetalle.Location = New System.Drawing.Point(5, 72)
        Me.GridDetalle.Name = "GridDetalle"
        Me.GridDetalle.ReadOnly = True
        Me.GridDetalle.Size = New System.Drawing.Size(559, 574)
        Me.GridDetalle.TabIndex = 0
        '
        'CODPRODDataGridViewTextBoxColumn
        '
        Me.CODPRODDataGridViewTextBoxColumn.DataPropertyName = "CODPROD"
        Me.CODPRODDataGridViewTextBoxColumn.HeaderText = "CODPROD"
        Me.CODPRODDataGridViewTextBoxColumn.Name = "CODPRODDataGridViewTextBoxColumn"
        Me.CODPRODDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPRODDataGridViewTextBoxColumn.Width = 80
        '
        'DESPRODDataGridViewTextBoxColumn
        '
        Me.DESPRODDataGridViewTextBoxColumn.DataPropertyName = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.HeaderText = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.Name = "DESPRODDataGridViewTextBoxColumn"
        Me.DESPRODDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPRODDataGridViewTextBoxColumn.Width = 200
        '
        'CODMEDIDADataGridViewTextBoxColumn
        '
        Me.CODMEDIDADataGridViewTextBoxColumn.DataPropertyName = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.HeaderText = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.Name = "CODMEDIDADataGridViewTextBoxColumn"
        Me.CODMEDIDADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODMEDIDADataGridViewTextBoxColumn.Width = 75
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.CANTIDADDataGridViewTextBoxColumn.Width = 50
        '
        'TOTALUNIDADESDataGridViewTextBoxColumn
        '
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.DataPropertyName = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.HeaderText = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.Name = "TOTALUNIDADESDataGridViewTextBoxColumn"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.ReadOnly = True
        '
        'COSTODataGridViewTextBoxColumn
        '
        Me.COSTODataGridViewTextBoxColumn.DataPropertyName = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.HeaderText = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.Name = "COSTODataGridViewTextBoxColumn"
        Me.COSTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRECIODataGridViewTextBoxColumn
        '
        Me.PRECIODataGridViewTextBoxColumn.DataPropertyName = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn.HeaderText = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn.Name = "PRECIODataGridViewTextBoxColumn"
        Me.PRECIODataGridViewTextBoxColumn.ReadOnly = True
        '
        'TOTALCOSTODataGridViewTextBoxColumn
        '
        Me.TOTALCOSTODataGridViewTextBoxColumn.DataPropertyName = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.HeaderText = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.Name = "TOTALCOSTODataGridViewTextBoxColumn"
        Me.TOTALCOSTODataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALCOSTODataGridViewTextBoxColumn.Width = 120
        '
        'TOTALPRECIODataGridViewTextBoxColumn
        '
        Me.TOTALPRECIODataGridViewTextBoxColumn.DataPropertyName = "TOTALPRECIO"
        Me.TOTALPRECIODataGridViewTextBoxColumn.HeaderText = "TOTALPRECIO"
        Me.TOTALPRECIODataGridViewTextBoxColumn.Name = "TOTALPRECIODataGridViewTextBoxColumn"
        Me.TOTALPRECIODataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALPRECIODataGridViewTextBoxColumn.Width = 120
        '
        'TblDetalleTrasladoBindingSource
        '
        Me.TblDetalleTrasladoBindingSource.DataMember = "tblDetalleTraslado"
        Me.TblDetalleTrasladoBindingSource.DataSource = Me.DataSetInventarios
        '
        'DataSetInventarios
        '
        Me.DataSetInventarios.DataSetName = "DataSetInventarios"
        Me.DataSetInventarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridTraslados
        '
        Me.GridTraslados.DataSource = Me.TblTrasladosPendientesBindingSource
        Me.GridTraslados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTraslados.Location = New System.Drawing.Point(2, 20)
        Me.GridTraslados.MainView = Me.GridViewTraslados
        Me.GridTraslados.Name = "GridTraslados"
        Me.GridTraslados.Size = New System.Drawing.Size(1249, 582)
        Me.GridTraslados.TabIndex = 0
        Me.GridTraslados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTraslados})
        '
        'TblTrasladosPendientesBindingSource
        '
        Me.TblTrasladosPendientesBindingSource.DataMember = "tblTrasladosPendientes"
        Me.TblTrasladosPendientesBindingSource.DataSource = Me.DataSetInventarios
        '
        'GridViewTraslados
        '
        Me.GridViewTraslados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODDOC, Me.colCORRELATIVO, Me.colFECHA, Me.colTOTALCOSTO, Me.colTOTALPRECIO, Me.colOBS, Me.colEMPNIT, Me.colEMPNOMBRE, Me.colOBSMARCA, Me.colCODEMBARQUE})
        Me.GridViewTraslados.GridControl = Me.GridTraslados
        Me.GridViewTraslados.Name = "GridViewTraslados"
        Me.GridViewTraslados.OptionsBehavior.Editable = False
        Me.GridViewTraslados.OptionsView.ShowGroupPanel = False
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 0
        Me.colCODDOC.Width = 72
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        Me.colCORRELATIVO.Width = 90
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 2
        Me.colFECHA.Width = 95
        '
        'colTOTALCOSTO
        '
        Me.colTOTALCOSTO.FieldName = "TOTALCOSTO"
        Me.colTOTALCOSTO.Name = "colTOTALCOSTO"
        Me.colTOTALCOSTO.Visible = True
        Me.colTOTALCOSTO.VisibleIndex = 3
        Me.colTOTALCOSTO.Width = 102
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 4
        Me.colTOTALPRECIO.Width = 114
        '
        'colOBS
        '
        Me.colOBS.FieldName = "OBS"
        Me.colOBS.Name = "colOBS"
        Me.colOBS.Visible = True
        Me.colOBS.VisibleIndex = 5
        Me.colOBS.Width = 231
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
        Me.colEMPNOMBRE.VisibleIndex = 6
        Me.colEMPNOMBRE.Width = 20
        '
        'colOBSMARCA
        '
        Me.colOBSMARCA.Caption = "ORIGEN"
        Me.colOBSMARCA.FieldName = "OBSMARCA"
        Me.colOBSMARCA.Name = "colOBSMARCA"
        Me.colOBSMARCA.Visible = True
        Me.colOBSMARCA.VisibleIndex = 7
        Me.colOBSMARCA.Width = 225
        '
        'colCODEMBARQUE
        '
        Me.colCODEMBARQUE.FieldName = "CODEMBARQUE"
        Me.colCODEMBARQUE.Name = "colCODEMBARQUE"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItemDetalle, Me.BarButtonItemGenerar, Me.BarButtonItemEliminar})
        Me.BarManager1.MaxItemId = 3
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
        'BarButtonItemDetalle
        '
        Me.BarButtonItemDetalle.Caption = "Ver Detalle"
        Me.BarButtonItemDetalle.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemDetalle.Glyph = CType(resources.GetObject("BarButtonItemDetalle.Glyph"), System.Drawing.Image)
        Me.BarButtonItemDetalle.Id = 0
        Me.BarButtonItemDetalle.Name = "BarButtonItemDetalle"
        '
        'BarButtonItemGenerar
        '
        Me.BarButtonItemGenerar.Caption = "Generar"
        Me.BarButtonItemGenerar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemGenerar.Glyph = CType(resources.GetObject("BarButtonItemGenerar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemGenerar.Id = 1
        Me.BarButtonItemGenerar.Name = "BarButtonItemGenerar"
        '
        'BarButtonItemEliminar
        '
        Me.BarButtonItemEliminar.Caption = "Eliminar"
        Me.BarButtonItemEliminar.CloseRadialMenuOnItemClick = True
        Me.BarButtonItemEliminar.Glyph = CType(resources.GetObject("BarButtonItemEliminar.Glyph"), System.Drawing.Image)
        Me.BarButtonItemEliminar.Id = 2
        Me.BarButtonItemEliminar.Name = "BarButtonItemEliminar"
        '
        'RadMenTraslados
        '
        Me.RadMenTraslados.AutoExpand = True
        Me.RadMenTraslados.Glyph = CType(resources.GetObject("RadMenTraslados.Glyph"), System.Drawing.Image)
        Me.RadMenTraslados.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadMenTraslados.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemDetalle), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemGenerar), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItemEliminar)})
        Me.RadMenTraslados.Manager = Me.BarManager1
        Me.RadMenTraslados.Name = "RadMenTraslados"
        '
        'cmbGenCoddoc
        '
        Me.cmbGenCoddoc.FormattingEnabled = True
        Me.cmbGenCoddoc.Location = New System.Drawing.Point(1072, 29)
        Me.cmbGenCoddoc.Name = "cmbGenCoddoc"
        Me.cmbGenCoddoc.Size = New System.Drawing.Size(110, 21)
        Me.cmbGenCoddoc.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(932, 32)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(134, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "DOCUMENTO DE ENTRADA:"
        '
        'lbGenCorrelativo
        '
        Me.lbGenCorrelativo.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbGenCorrelativo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbGenCorrelativo.Location = New System.Drawing.Point(1189, 34)
        Me.lbGenCorrelativo.Name = "lbGenCorrelativo"
        Me.lbGenCorrelativo.Size = New System.Drawing.Size(77, 13)
        Me.lbGenCorrelativo.TabIndex = 9
        Me.lbGenCorrelativo.Text = "00000000000"
        '
        'viewSyncTablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbGenCorrelativo)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cmbGenCoddoc)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewSyncTablas"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.groupcontrol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupcontrol.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.FlyoutPanelDetalleTraslado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelDetalleTraslado.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.FlyoutPanelControl1.PerformLayout()
        CType(Me.GridDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDetalleTrasladoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTraslados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTrasladosPendientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTraslados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenTraslados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents groupcontrol As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnObtenerProductosPrecios As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridTraslados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTraslados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnGenerarPlantillaProductos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TblTrasladosPendientesBindingSource As BindingSource
    Friend WithEvents DataSetInventarios As DataSetInventarios
    Friend WithEvents RadMenTraslados As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents BarButtonItemDetalle As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemGenerar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItemEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents FlyoutPanelDetalleTraslado As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents GridDetalle As DataGridView
    Friend WithEvents CODPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALUNIDADESDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALCOSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALPRECIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TblDetalleTrasladoBindingSource As BindingSource
    Friend WithEvents txtDataTrasladoObs As TextBox
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRestaurarBackup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOBS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPNOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lbGenCorrelativo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbGenCoddoc As ComboBox
    Friend WithEvents colOBSMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODEMBARQUE As DevExpress.XtraGrid.Columns.GridColumn
End Class
