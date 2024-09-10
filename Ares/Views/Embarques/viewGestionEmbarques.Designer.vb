<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewGestionEmbarques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewGestionEmbarques))
        Me.LabelControl161 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.FlyoutPanelImpresion = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.btnCerrarFlyoutImpresion = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimirTickets = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimirBoletas = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimirListaFacturas = New DevExpress.XtraEditors.SimpleButton()
        Me.lbCodEmbarqueSeleccionado = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.btnImprimirPicking = New DevExpress.XtraEditors.SimpleButton()
        Me.tabContenedor = New DevExpress.XtraTab.XtraTabControl()
        Me.tabPageFacturas = New DevExpress.XtraTab.XtraTabPage()
        Me.btnImprimirDocumentos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCargarGridFacturas = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaFinal = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaInicial = New DevExpress.XtraEditors.DateEdit()
        Me.btnAsignarVendedor = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAsignarEmbarque = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbEmbarque = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFacFinal = New DevExpress.XtraEditors.TextEdit()
        Me.txtFacInicial = New DevExpress.XtraEditors.TextEdit()
        Me.cmbCoddoc = New System.Windows.Forms.ComboBox()
        Me.gridFacturas = New DevExpress.XtraGrid.GridControl()
        Me.TblFacturasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New Ares.DataSet1()
        Me.GridViewFacturas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDIRECCION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIMPORTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODVEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colVENDEDOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMBARQUE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tabPageEmbarques = New DevExpress.XtraTab.XtraTabPage()
        Me.btnEmbarquesCargarGridEmbarques = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEmbarques = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbEmbarquesAnio = New System.Windows.Forms.ComboBox()
        Me.cmbEmbarquesMes = New System.Windows.Forms.ComboBox()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.switchCompletosFinalizados = New DevExpress.XtraEditors.ToggleSwitch()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GridEmbarques = New DevExpress.XtraGrid.GridControl()
        Me.GridViewEmbarques = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODEMBARQUE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCRIPCION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODREPARTIDOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMEMPLEADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RadialMenuEmbarques = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.btnRadMenEmbarquesEditar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadMenEmbarquesFinalizar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadMenEmbarquesEliminar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadMenEmbarquesDocumentos = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.TimerCargarEmbarques = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.FlyoutPanelImpresion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelImpresion.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.tabContenedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabContenedor.SuspendLayout()
        Me.tabPageFacturas.SuspendLayout()
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFacFinal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFacInicial.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblFacturasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPageEmbarques.SuspendLayout()
        CType(Me.switchCompletosFinalizados.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GridEmbarques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewEmbarques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadialMenuEmbarques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl161
        '
        Me.LabelControl161.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl161.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl161.Location = New System.Drawing.Point(114, 22)
        Me.LabelControl161.Name = "LabelControl161"
        Me.LabelControl161.Size = New System.Drawing.Size(423, 33)
        Me.LabelControl161.TabIndex = 180
        Me.LabelControl161.Text = "Módulo para Gestión de Embarques"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.FlyoutPanelImpresion)
        Me.GroupControl1.Controls.Add(Me.tabContenedor)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 73)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1015, 590)
        Me.GroupControl1.TabIndex = 178
        '
        'FlyoutPanelImpresion
        '
        Me.FlyoutPanelImpresion.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelImpresion.Location = New System.Drawing.Point(857, 3)
        Me.FlyoutPanelImpresion.Name = "FlyoutPanelImpresion"
        Me.FlyoutPanelImpresion.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutPanelImpresion.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Right
        Me.FlyoutPanelImpresion.OwnerControl = Me
        Me.FlyoutPanelImpresion.Size = New System.Drawing.Size(378, 608)
        Me.FlyoutPanelImpresion.TabIndex = 185
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.GroupControl3)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelImpresion
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(378, 608)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.btnCerrarFlyoutImpresion)
        Me.GroupControl3.Controls.Add(Me.btnImprimirTickets)
        Me.GroupControl3.Controls.Add(Me.btnImprimirBoletas)
        Me.GroupControl3.Controls.Add(Me.btnImprimirListaFacturas)
        Me.GroupControl3.Controls.Add(Me.lbCodEmbarqueSeleccionado)
        Me.GroupControl3.Controls.Add(Me.LabelControl12)
        Me.GroupControl3.Controls.Add(Me.btnImprimirPicking)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(374, 604)
        Me.GroupControl3.TabIndex = 0
        Me.GroupControl3.Text = "Opciones de Impresión"
        '
        'btnCerrarFlyoutImpresion
        '
        Me.btnCerrarFlyoutImpresion.Appearance.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.btnCerrarFlyoutImpresion.Appearance.Options.UseForeColor = True
        Me.btnCerrarFlyoutImpresion.Image = CType(resources.GetObject("btnCerrarFlyoutImpresion.Image"), System.Drawing.Image)
        Me.btnCerrarFlyoutImpresion.Location = New System.Drawing.Point(9, 24)
        Me.btnCerrarFlyoutImpresion.Name = "btnCerrarFlyoutImpresion"
        Me.btnCerrarFlyoutImpresion.Size = New System.Drawing.Size(97, 36)
        Me.btnCerrarFlyoutImpresion.TabIndex = 6
        Me.btnCerrarFlyoutImpresion.Text = "Cerrar(x)"
        '
        'btnImprimirTickets
        '
        Me.btnImprimirTickets.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirTickets.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.btnImprimirTickets.Appearance.Options.UseFont = True
        Me.btnImprimirTickets.Appearance.Options.UseForeColor = True
        Me.btnImprimirTickets.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimirTickets.Image = CType(resources.GetObject("btnImprimirTickets.Image"), System.Drawing.Image)
        Me.btnImprimirTickets.Location = New System.Drawing.Point(32, 412)
        Me.btnImprimirTickets.Name = "btnImprimirTickets"
        Me.btnImprimirTickets.Size = New System.Drawing.Size(253, 59)
        Me.btnImprimirTickets.TabIndex = 5
        Me.btnImprimirTickets.Text = "TICKETS"
        '
        'btnImprimirBoletas
        '
        Me.btnImprimirBoletas.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirBoletas.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.btnImprimirBoletas.Appearance.Options.UseFont = True
        Me.btnImprimirBoletas.Appearance.Options.UseForeColor = True
        Me.btnImprimirBoletas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimirBoletas.Image = CType(resources.GetObject("btnImprimirBoletas.Image"), System.Drawing.Image)
        Me.btnImprimirBoletas.Location = New System.Drawing.Point(32, 334)
        Me.btnImprimirBoletas.Name = "btnImprimirBoletas"
        Me.btnImprimirBoletas.Size = New System.Drawing.Size(253, 59)
        Me.btnImprimirBoletas.TabIndex = 4
        Me.btnImprimirBoletas.Text = "BOLETAS"
        '
        'btnImprimirListaFacturas
        '
        Me.btnImprimirListaFacturas.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirListaFacturas.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.btnImprimirListaFacturas.Appearance.Options.UseFont = True
        Me.btnImprimirListaFacturas.Appearance.Options.UseForeColor = True
        Me.btnImprimirListaFacturas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimirListaFacturas.Image = CType(resources.GetObject("btnImprimirListaFacturas.Image"), System.Drawing.Image)
        Me.btnImprimirListaFacturas.Location = New System.Drawing.Point(32, 225)
        Me.btnImprimirListaFacturas.Name = "btnImprimirListaFacturas"
        Me.btnImprimirListaFacturas.Size = New System.Drawing.Size(253, 59)
        Me.btnImprimirListaFacturas.TabIndex = 3
        Me.btnImprimirListaFacturas.Text = "RESUMEN DE FACTURAS"
        '
        'lbCodEmbarqueSeleccionado
        '
        Me.lbCodEmbarqueSeleccionado.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodEmbarqueSeleccionado.Location = New System.Drawing.Point(14, 95)
        Me.lbCodEmbarqueSeleccionado.Name = "lbCodEmbarqueSeleccionado"
        Me.lbCodEmbarqueSeleccionado.Size = New System.Drawing.Size(181, 16)
        Me.lbCodEmbarqueSeleccionado.TabIndex = 2
        Me.lbCodEmbarqueSeleccionado.Text = "00-00-0000-RUTA-A-LUGAR"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl12.Location = New System.Drawing.Point(14, 78)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(137, 13)
        Me.LabelControl12.TabIndex = 1
        Me.LabelControl12.Text = "Embarque Seleccionado:"
        '
        'btnImprimirPicking
        '
        Me.btnImprimirPicking.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimirPicking.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.btnImprimirPicking.Appearance.Options.UseFont = True
        Me.btnImprimirPicking.Appearance.Options.UseForeColor = True
        Me.btnImprimirPicking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnImprimirPicking.Image = CType(resources.GetObject("btnImprimirPicking.Image"), System.Drawing.Image)
        Me.btnImprimirPicking.Location = New System.Drawing.Point(32, 141)
        Me.btnImprimirPicking.Name = "btnImprimirPicking"
        Me.btnImprimirPicking.Size = New System.Drawing.Size(253, 59)
        Me.btnImprimirPicking.TabIndex = 0
        Me.btnImprimirPicking.Text = "PICKING PRODUCTOS"
        '
        'tabContenedor
        '
        Me.tabContenedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabContenedor.Location = New System.Drawing.Point(2, 20)
        Me.tabContenedor.Name = "tabContenedor"
        Me.tabContenedor.SelectedTabPage = Me.tabPageFacturas
        Me.tabContenedor.ShowHeaderFocus = DevExpress.Utils.DefaultBoolean.[True]
        Me.tabContenedor.Size = New System.Drawing.Size(1011, 568)
        Me.tabContenedor.TabIndex = 0
        Me.tabContenedor.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabPageFacturas, Me.tabPageEmbarques})
        '
        'tabPageFacturas
        '
        Me.tabPageFacturas.Controls.Add(Me.btnImprimirDocumentos)
        Me.tabPageFacturas.Controls.Add(Me.btnCargarGridFacturas)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl9)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl8)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl7)
        Me.tabPageFacturas.Controls.Add(Me.txtFechaFinal)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl6)
        Me.tabPageFacturas.Controls.Add(Me.txtFechaInicial)
        Me.tabPageFacturas.Controls.Add(Me.btnAsignarVendedor)
        Me.tabPageFacturas.Controls.Add(Me.btnAsignarEmbarque)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl5)
        Me.tabPageFacturas.Controls.Add(Me.cmbVendedor)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl4)
        Me.tabPageFacturas.Controls.Add(Me.cmbEmbarque)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl3)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl2)
        Me.tabPageFacturas.Controls.Add(Me.LabelControl1)
        Me.tabPageFacturas.Controls.Add(Me.txtFacFinal)
        Me.tabPageFacturas.Controls.Add(Me.txtFacInicial)
        Me.tabPageFacturas.Controls.Add(Me.cmbCoddoc)
        Me.tabPageFacturas.Controls.Add(Me.gridFacturas)
        Me.tabPageFacturas.Name = "tabPageFacturas"
        Me.tabPageFacturas.Size = New System.Drawing.Size(1005, 540)
        Me.tabPageFacturas.Text = "Gestión de Facturas"
        '
        'btnImprimirDocumentos
        '
        Me.btnImprimirDocumentos.Image = CType(resources.GetObject("btnImprimirDocumentos.Image"), System.Drawing.Image)
        Me.btnImprimirDocumentos.Location = New System.Drawing.Point(827, 45)
        Me.btnImprimirDocumentos.Name = "btnImprimirDocumentos"
        Me.btnImprimirDocumentos.Size = New System.Drawing.Size(152, 23)
        Me.btnImprimirDocumentos.TabIndex = 20
        Me.btnImprimirDocumentos.Text = "Imprimir Documentos"
        '
        'btnCargarGridFacturas
        '
        Me.btnCargarGridFacturas.Image = CType(resources.GetObject("btnCargarGridFacturas.Image"), System.Drawing.Image)
        Me.btnCargarGridFacturas.Location = New System.Drawing.Point(198, 79)
        Me.btnCargarGridFacturas.Name = "btnCargarGridFacturas"
        Me.btnCargarGridFacturas.Size = New System.Drawing.Size(81, 31)
        Me.btnCargarGridFacturas.TabIndex = 19
        Me.btnCargarGridFacturas.Text = "Cargar"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl9.Location = New System.Drawing.Point(25, 18)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(67, 13)
        Me.LabelControl9.TabIndex = 18
        Me.LabelControl9.Text = "Parámetros"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl8.Location = New System.Drawing.Point(326, 18)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(205, 13)
        Me.LabelControl8.TabIndex = 17
        Me.LabelControl8.Text = "Asignación de Embarque y Vendedor"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(25, 82)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(13, 13)
        Me.LabelControl7.TabIndex = 16
        Me.LabelControl7.Text = "Al:"
        '
        'txtFechaFinal
        '
        Me.txtFechaFinal.EditValue = Nothing
        Me.txtFechaFinal.Location = New System.Drawing.Point(50, 79)
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinal.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaFinal.TabIndex = 15
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(25, 51)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl6.TabIndex = 14
        Me.LabelControl6.Text = "Del:"
        '
        'txtFechaInicial
        '
        Me.txtFechaInicial.EditValue = Nothing
        Me.txtFechaInicial.Location = New System.Drawing.Point(50, 48)
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaInicial.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaInicial.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaInicial.TabIndex = 13
        '
        'btnAsignarVendedor
        '
        Me.btnAsignarVendedor.Image = CType(resources.GetObject("btnAsignarVendedor.Image"), System.Drawing.Image)
        Me.btnAsignarVendedor.Location = New System.Drawing.Point(735, 80)
        Me.btnAsignarVendedor.Name = "btnAsignarVendedor"
        Me.btnAsignarVendedor.Size = New System.Drawing.Size(75, 23)
        Me.btnAsignarVendedor.TabIndex = 12
        Me.btnAsignarVendedor.Text = "Asignar"
        '
        'btnAsignarEmbarque
        '
        Me.btnAsignarEmbarque.Image = CType(resources.GetObject("btnAsignarEmbarque.Image"), System.Drawing.Image)
        Me.btnAsignarEmbarque.Location = New System.Drawing.Point(735, 45)
        Me.btnAsignarEmbarque.Name = "btnAsignarEmbarque"
        Me.btnAsignarEmbarque.Size = New System.Drawing.Size(75, 23)
        Me.btnAsignarEmbarque.TabIndex = 11
        Me.btnAsignarEmbarque.Text = "Asignar"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(454, 85)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "Vendedor:"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(510, 82)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(213, 21)
        Me.cmbVendedor.TabIndex = 9
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(454, 50)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Embarque:"
        '
        'cmbEmbarque
        '
        Me.cmbEmbarque.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmbarque.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmbarque.FormattingEnabled = True
        Me.cmbEmbarque.Location = New System.Drawing.Point(510, 47)
        Me.cmbEmbarque.Name = "cmbEmbarque"
        Me.cmbEmbarque.Size = New System.Drawing.Size(213, 21)
        Me.cmbEmbarque.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(169, 31)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "Serie de Factura:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(317, 85)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(13, 13)
        Me.LabelControl2.TabIndex = 5
        Me.LabelControl2.Text = "Al:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(317, 51)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Del:"
        '
        'txtFacFinal
        '
        Me.txtFacFinal.Location = New System.Drawing.Point(342, 83)
        Me.txtFacFinal.Name = "txtFacFinal"
        Me.txtFacFinal.Properties.Mask.EditMask = "n0"
        Me.txtFacFinal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtFacFinal.Size = New System.Drawing.Size(100, 20)
        Me.txtFacFinal.TabIndex = 3
        '
        'txtFacInicial
        '
        Me.txtFacInicial.Location = New System.Drawing.Point(342, 48)
        Me.txtFacInicial.Name = "txtFacInicial"
        Me.txtFacInicial.Properties.Mask.EditMask = "n0"
        Me.txtFacInicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtFacInicial.Size = New System.Drawing.Size(100, 20)
        Me.txtFacInicial.TabIndex = 2
        '
        'cmbCoddoc
        '
        Me.cmbCoddoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCoddoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCoddoc.FormattingEnabled = True
        Me.cmbCoddoc.Location = New System.Drawing.Point(169, 48)
        Me.cmbCoddoc.Name = "cmbCoddoc"
        Me.cmbCoddoc.Size = New System.Drawing.Size(110, 21)
        Me.cmbCoddoc.TabIndex = 1
        '
        'gridFacturas
        '
        Me.gridFacturas.DataSource = Me.TblFacturasBindingSource
        Me.gridFacturas.Location = New System.Drawing.Point(12, 128)
        Me.gridFacturas.MainView = Me.GridViewFacturas
        Me.gridFacturas.Name = "gridFacturas"
        Me.gridFacturas.Size = New System.Drawing.Size(987, 389)
        Me.gridFacturas.TabIndex = 0
        Me.gridFacturas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewFacturas, Me.GridView2})
        '
        'TblFacturasBindingSource
        '
        Me.TblFacturasBindingSource.DataMember = "tblFacturas"
        Me.TblFacturasBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewFacturas
        '
        Me.GridViewFacturas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFECHA, Me.colCODDOC, Me.colCORRELATIVO, Me.colNIT, Me.colCLIENTE, Me.colDIRECCION, Me.colIMPORTE, Me.colCODVEN, Me.colVENDEDOR, Me.colEMBARQUE, Me.colST})
        Me.GridViewFacturas.GridControl = Me.gridFacturas
        Me.GridViewFacturas.Name = "GridViewFacturas"
        Me.GridViewFacturas.OptionsBehavior.Editable = False
        Me.GridViewFacturas.OptionsView.ShowAutoFilterRow = True
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 0
        Me.colFECHA.Width = 81
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 1
        Me.colCODDOC.Width = 80
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 2
        Me.colCORRELATIVO.Width = 95
        '
        'colNIT
        '
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 3
        Me.colNIT.Width = 95
        '
        'colCLIENTE
        '
        Me.colCLIENTE.FieldName = "CLIENTE"
        Me.colCLIENTE.Name = "colCLIENTE"
        Me.colCLIENTE.Visible = True
        Me.colCLIENTE.VisibleIndex = 4
        Me.colCLIENTE.Width = 124
        '
        'colDIRECCION
        '
        Me.colDIRECCION.FieldName = "DIRECCION"
        Me.colDIRECCION.Name = "colDIRECCION"
        Me.colDIRECCION.Visible = True
        Me.colDIRECCION.VisibleIndex = 5
        Me.colDIRECCION.Width = 117
        '
        'colIMPORTE
        '
        Me.colIMPORTE.FieldName = "IMPORTE"
        Me.colIMPORTE.Name = "colIMPORTE"
        Me.colIMPORTE.Visible = True
        Me.colIMPORTE.VisibleIndex = 6
        Me.colIMPORTE.Width = 91
        '
        'colCODVEN
        '
        Me.colCODVEN.FieldName = "CODVEN"
        Me.colCODVEN.Name = "colCODVEN"
        '
        'colVENDEDOR
        '
        Me.colVENDEDOR.FieldName = "VENDEDOR"
        Me.colVENDEDOR.Name = "colVENDEDOR"
        Me.colVENDEDOR.Visible = True
        Me.colVENDEDOR.VisibleIndex = 7
        Me.colVENDEDOR.Width = 96
        '
        'colEMBARQUE
        '
        Me.colEMBARQUE.FieldName = "EMBARQUE"
        Me.colEMBARQUE.Name = "colEMBARQUE"
        Me.colEMBARQUE.Visible = True
        Me.colEMBARQUE.VisibleIndex = 8
        Me.colEMBARQUE.Width = 152
        '
        'colST
        '
        Me.colST.FieldName = "ST"
        Me.colST.Name = "colST"
        Me.colST.Visible = True
        Me.colST.VisibleIndex = 9
        Me.colST.Width = 38
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridFacturas
        Me.GridView2.Name = "GridView2"
        '
        'tabPageEmbarques
        '
        Me.tabPageEmbarques.Controls.Add(Me.btnEmbarquesCargarGridEmbarques)
        Me.tabPageEmbarques.Controls.Add(Me.btnEmbarques)
        Me.tabPageEmbarques.Controls.Add(Me.LabelControl11)
        Me.tabPageEmbarques.Controls.Add(Me.cmbEmbarquesAnio)
        Me.tabPageEmbarques.Controls.Add(Me.cmbEmbarquesMes)
        Me.tabPageEmbarques.Controls.Add(Me.LabelControl10)
        Me.tabPageEmbarques.Controls.Add(Me.switchCompletosFinalizados)
        Me.tabPageEmbarques.Controls.Add(Me.GroupControl2)
        Me.tabPageEmbarques.Name = "tabPageEmbarques"
        Me.tabPageEmbarques.Size = New System.Drawing.Size(1005, 540)
        Me.tabPageEmbarques.Text = "Gestión de Embarques"
        '
        'btnEmbarquesCargarGridEmbarques
        '
        Me.btnEmbarquesCargarGridEmbarques.Image = CType(resources.GetObject("btnEmbarquesCargarGridEmbarques.Image"), System.Drawing.Image)
        Me.btnEmbarquesCargarGridEmbarques.Location = New System.Drawing.Point(503, 72)
        Me.btnEmbarquesCargarGridEmbarques.Name = "btnEmbarquesCargarGridEmbarques"
        Me.btnEmbarquesCargarGridEmbarques.Size = New System.Drawing.Size(102, 31)
        Me.btnEmbarquesCargarGridEmbarques.TabIndex = 20
        Me.btnEmbarquesCargarGridEmbarques.Text = "Cargar"
        '
        'btnEmbarques
        '
        Me.btnEmbarques.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnEmbarques.Location = New System.Drawing.Point(820, 45)
        Me.btnEmbarques.Name = "btnEmbarques"
        Me.btnEmbarques.Size = New System.Drawing.Size(154, 67)
        Me.btnEmbarques.TabIndex = 179
        Me.btnEmbarques.Text = "Nuevo Embarque"
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(34, 79)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl11.TabIndex = 15
        Me.LabelControl11.Text = "Filtrar por:"
        '
        'cmbEmbarquesAnio
        '
        Me.cmbEmbarquesAnio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmbarquesAnio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmbarquesAnio.FormattingEnabled = True
        Me.cmbEmbarquesAnio.Items.AddRange(New Object() {"2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbEmbarquesAnio.Location = New System.Drawing.Point(228, 77)
        Me.cmbEmbarquesAnio.Name = "cmbEmbarquesAnio"
        Me.cmbEmbarquesAnio.Size = New System.Drawing.Size(91, 21)
        Me.cmbEmbarquesAnio.TabIndex = 14
        '
        'cmbEmbarquesMes
        '
        Me.cmbEmbarquesMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmbarquesMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmbarquesMes.FormattingEnabled = True
        Me.cmbEmbarquesMes.Location = New System.Drawing.Point(98, 77)
        Me.cmbEmbarquesMes.Name = "cmbEmbarquesMes"
        Me.cmbEmbarquesMes.Size = New System.Drawing.Size(124, 21)
        Me.cmbEmbarquesMes.TabIndex = 13
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl10.Location = New System.Drawing.Point(34, 36)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(182, 19)
        Me.LabelControl10.TabIndex = 12
        Me.LabelControl10.Text = "Gestion de Embarques"
        '
        'switchCompletosFinalizados
        '
        Me.switchCompletosFinalizados.Location = New System.Drawing.Point(330, 76)
        Me.switchCompletosFinalizados.Name = "switchCompletosFinalizados"
        Me.switchCompletosFinalizados.Properties.OffText = "Pendientes"
        Me.switchCompletosFinalizados.Properties.OnText = "Finalizados"
        Me.switchCompletosFinalizados.Size = New System.Drawing.Size(156, 24)
        Me.switchCompletosFinalizados.TabIndex = 11
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GridEmbarques)
        Me.GroupControl2.Location = New System.Drawing.Point(32, 121)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(944, 379)
        Me.GroupControl2.TabIndex = 10
        Me.GroupControl2.Text = "Embarques Disponibles / Doble clic o Enter para Ver Opciones"
        '
        'GridEmbarques
        '
        Me.GridEmbarques.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridEmbarques.Location = New System.Drawing.Point(2, 20)
        Me.GridEmbarques.MainView = Me.GridViewEmbarques
        Me.GridEmbarques.Name = "GridEmbarques"
        Me.GridEmbarques.Size = New System.Drawing.Size(940, 357)
        Me.GridEmbarques.TabIndex = 0
        Me.GridEmbarques.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewEmbarques, Me.GridView1})
        '
        'GridViewEmbarques
        '
        Me.GridViewEmbarques.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODEMBARQUE, Me.colDESCRIPCION, Me.colCODREPARTIDOR, Me.colNOMEMPLEADO, Me.GridColumn1})
        Me.GridViewEmbarques.GridControl = Me.GridEmbarques
        Me.GridViewEmbarques.Name = "GridViewEmbarques"
        Me.GridViewEmbarques.OptionsBehavior.Editable = False
        Me.GridViewEmbarques.OptionsView.ShowAutoFilterRow = True
        '
        'colCODEMBARQUE
        '
        Me.colCODEMBARQUE.Caption = "EMBARQUE"
        Me.colCODEMBARQUE.FieldName = "CODEMBARQUE"
        Me.colCODEMBARQUE.Name = "colCODEMBARQUE"
        Me.colCODEMBARQUE.Visible = True
        Me.colCODEMBARQUE.VisibleIndex = 0
        Me.colCODEMBARQUE.Width = 163
        '
        'colDESCRIPCION
        '
        Me.colDESCRIPCION.FieldName = "DESCRIPCION"
        Me.colDESCRIPCION.Name = "colDESCRIPCION"
        Me.colDESCRIPCION.Visible = True
        Me.colDESCRIPCION.VisibleIndex = 1
        Me.colDESCRIPCION.Width = 396
        '
        'colCODREPARTIDOR
        '
        Me.colCODREPARTIDOR.FieldName = "CODREPARTIDOR"
        Me.colCODREPARTIDOR.Name = "colCODREPARTIDOR"
        '
        'colNOMEMPLEADO
        '
        Me.colNOMEMPLEADO.Caption = "REPARTIDOR"
        Me.colNOMEMPLEADO.FieldName = "NOMEMPLEADO"
        Me.colNOMEMPLEADO.Name = "colNOMEMPLEADO"
        Me.colNOMEMPLEADO.Visible = True
        Me.colNOMEMPLEADO.VisibleIndex = 2
        Me.colNOMEMPLEADO.Width = 252
        '
        'GridColumn1
        '
        Me.GridColumn1.FieldName = "FECHA"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 3
        Me.GridColumn1.Width = 111
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridEmbarques
        Me.GridView1.Name = "GridView1"
        '
        'RadialMenuEmbarques
        '
        Me.RadialMenuEmbarques.AutoExpand = True
        Me.RadialMenuEmbarques.Glyph = CType(resources.GetObject("RadialMenuEmbarques.Glyph"), System.Drawing.Image)
        Me.RadialMenuEmbarques.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuEmbarques.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenEmbarquesEditar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenEmbarquesFinalizar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenEmbarquesEliminar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenEmbarquesDocumentos)})
        Me.RadialMenuEmbarques.Manager = Me.BarManager1
        Me.RadialMenuEmbarques.Name = "RadialMenuEmbarques"
        '
        'btnRadMenEmbarquesEditar
        '
        Me.btnRadMenEmbarquesEditar.Caption = "Editar"
        Me.btnRadMenEmbarquesEditar.CloseRadialMenuOnItemClick = True
        Me.btnRadMenEmbarquesEditar.Glyph = CType(resources.GetObject("btnRadMenEmbarquesEditar.Glyph"), System.Drawing.Image)
        Me.btnRadMenEmbarquesEditar.Id = 0
        Me.btnRadMenEmbarquesEditar.Name = "btnRadMenEmbarquesEditar"
        '
        'btnRadMenEmbarquesFinalizar
        '
        Me.btnRadMenEmbarquesFinalizar.Caption = "Finalizar"
        Me.btnRadMenEmbarquesFinalizar.CloseRadialMenuOnItemClick = True
        Me.btnRadMenEmbarquesFinalizar.Glyph = CType(resources.GetObject("btnRadMenEmbarquesFinalizar.Glyph"), System.Drawing.Image)
        Me.btnRadMenEmbarquesFinalizar.Id = 1
        Me.btnRadMenEmbarquesFinalizar.Name = "btnRadMenEmbarquesFinalizar"
        '
        'btnRadMenEmbarquesEliminar
        '
        Me.btnRadMenEmbarquesEliminar.Caption = "Eliminar"
        Me.btnRadMenEmbarquesEliminar.CloseRadialMenuOnItemClick = True
        Me.btnRadMenEmbarquesEliminar.Glyph = CType(resources.GetObject("btnRadMenEmbarquesEliminar.Glyph"), System.Drawing.Image)
        Me.btnRadMenEmbarquesEliminar.Id = 2
        Me.btnRadMenEmbarquesEliminar.Name = "btnRadMenEmbarquesEliminar"
        '
        'btnRadMenEmbarquesDocumentos
        '
        Me.btnRadMenEmbarquesDocumentos.Caption = "Impresión de Documentos"
        Me.btnRadMenEmbarquesDocumentos.CloseRadialMenuOnItemClick = True
        Me.btnRadMenEmbarquesDocumentos.Glyph = CType(resources.GetObject("btnRadMenEmbarquesDocumentos.Glyph"), System.Drawing.Image)
        Me.btnRadMenEmbarquesDocumentos.Id = 3
        Me.btnRadMenEmbarquesDocumentos.Name = "btnRadMenEmbarquesDocumentos"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRadMenEmbarquesEditar, Me.btnRadMenEmbarquesFinalizar, Me.btnRadMenEmbarquesEliminar, Me.btnRadMenEmbarquesDocumentos})
        Me.BarManager1.MaxItemId = 4
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1063, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 687)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1063, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 687)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1063, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 687)
        '
        'TimerCargarEmbarques
        '
        Me.TimerCargarEmbarques.Interval = 4000
        '
        'viewGestionEmbarques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl161)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewGestionEmbarques"
        Me.Size = New System.Drawing.Size(1063, 687)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.FlyoutPanelImpresion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelImpresion.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.tabContenedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabContenedor.ResumeLayout(False)
        Me.tabPageFacturas.ResumeLayout(False)
        Me.tabPageFacturas.PerformLayout()
        CType(Me.txtFechaFinal.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicial.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFacFinal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFacInicial.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblFacturasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPageEmbarques.ResumeLayout(False)
        Me.tabPageEmbarques.PerformLayout()
        CType(Me.switchCompletosFinalizados.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GridEmbarques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewEmbarques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadialMenuEmbarques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl161 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TblFacturasBindingSource As BindingSource
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents RadialMenuEmbarques As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents btnRadMenEmbarquesEditar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadMenEmbarquesFinalizar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadMenEmbarquesEliminar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnRadMenEmbarquesDocumentos As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents tabContenedor As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabPageFacturas As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnCargarGridFacturas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaInicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnAsignarVendedor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAsignarEmbarque As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbVendedor As ComboBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbEmbarque As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFacFinal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFacInicial As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbCoddoc As ComboBox
    Friend WithEvents gridFacturas As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewFacturas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDIRECCION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIMPORTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODVEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colVENDEDOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMBARQUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents tabPageEmbarques As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents btnEmbarquesCargarGridEmbarques As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEmbarques As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbEmbarquesAnio As ComboBox
    Friend WithEvents cmbEmbarquesMes As ComboBox
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents switchCompletosFinalizados As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridEmbarques As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewEmbarques As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODEMBARQUE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCRIPCION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODREPARTIDOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMEMPLEADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnImprimirDocumentos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents FlyoutPanelImpresion As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnImprimirTickets As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnImprimirBoletas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnImprimirListaFacturas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbCodEmbarqueSeleccionado As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnImprimirPicking As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCerrarFlyoutImpresion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TimerCargarEmbarques As Timer
End Class
