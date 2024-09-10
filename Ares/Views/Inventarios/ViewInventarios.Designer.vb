<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInventarios
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
        Dim TileItemElement1 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement3 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement4 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement5 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement6 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewInventarios))
        Me.LabelControl50 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl198 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbInventariosClaseTres = New System.Windows.Forms.ComboBox()
        Me.cmbInventariosMarca = New System.Windows.Forms.ComboBox()
        Me.LabelControl197 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl120 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbInventariosClaseDos = New System.Windows.Forms.ComboBox()
        Me.LabelControl181 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl118 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl192 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbInventariosClaseUno = New System.Windows.Forms.ComboBox()
        Me.SplitContainerInventarios = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.TileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TileGroup2 = New DevExpress.XtraEditors.TileGroup()
        Me.TileVencimientos = New DevExpress.XtraEditors.TileItem()
        Me.TileMinimos = New DevExpress.XtraEditors.TileItem()
        Me.cmdInventariosCerrarMes = New DevExpress.XtraEditors.TileItem()
        Me.btnActualizar = New DevExpress.XtraEditors.TileItem()
        Me.btnExistenciasCero = New DevExpress.XtraEditors.TileItem()
        Me.btnResetInventory = New DevExpress.XtraEditors.TileItem()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cmdInventariosImprimirEXCEL = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdInventariosClaseDos = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdInventariosClaseUno = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdInventariosImprimir = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdInventariosClaseTres = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdInventariosPorMarca = New DevExpress.XtraEditors.SimpleButton()
        Me.gridExports = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.SplitContainerInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerInventarios.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gridExports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl50
        '
        Me.LabelControl50.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl50.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl50.Location = New System.Drawing.Point(99, 7)
        Me.LabelControl50.Name = "LabelControl50"
        Me.LabelControl50.Size = New System.Drawing.Size(133, 33)
        Me.LabelControl50.TabIndex = 747
        Me.LabelControl50.Text = "Inventarios"
        '
        'LabelControl198
        '
        Me.LabelControl198.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl198.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl198.Location = New System.Drawing.Point(38, 289)
        Me.LabelControl198.Name = "LabelControl198"
        Me.LabelControl198.Size = New System.Drawing.Size(183, 23)
        Me.LabelControl198.TabIndex = 763
        Me.LabelControl198.Text = "por Clasificación Tres:"
        '
        'cmbInventariosClaseTres
        '
        Me.cmbInventariosClaseTres.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInventariosClaseTres.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInventariosClaseTres.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbInventariosClaseTres.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInventariosClaseTres.ForeColor = System.Drawing.Color.Black
        Me.cmbInventariosClaseTres.FormattingEnabled = True
        Me.cmbInventariosClaseTres.Location = New System.Drawing.Point(227, 292)
        Me.cmbInventariosClaseTres.Name = "cmbInventariosClaseTres"
        Me.cmbInventariosClaseTres.Size = New System.Drawing.Size(226, 24)
        Me.cmbInventariosClaseTres.TabIndex = 764
        '
        'cmbInventariosMarca
        '
        Me.cmbInventariosMarca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInventariosMarca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInventariosMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbInventariosMarca.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInventariosMarca.ForeColor = System.Drawing.Color.Black
        Me.cmbInventariosMarca.FormattingEnabled = True
        Me.cmbInventariosMarca.Location = New System.Drawing.Point(227, 123)
        Me.cmbInventariosMarca.Name = "cmbInventariosMarca"
        Me.cmbInventariosMarca.Size = New System.Drawing.Size(226, 24)
        Me.cmbInventariosMarca.TabIndex = 753
        '
        'LabelControl197
        '
        Me.LabelControl197.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl197.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl197.Location = New System.Drawing.Point(38, 229)
        Me.LabelControl197.Name = "LabelControl197"
        Me.LabelControl197.Size = New System.Drawing.Size(125, 23)
        Me.LabelControl197.TabIndex = 760
        Me.LabelControl197.Text = "por Proveedor:"
        '
        'LabelControl120
        '
        Me.LabelControl120.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl120.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl120.Location = New System.Drawing.Point(38, 123)
        Me.LabelControl120.Name = "LabelControl120"
        Me.LabelControl120.Size = New System.Drawing.Size(183, 23)
        Me.LabelControl120.TabIndex = 752
        Me.LabelControl120.Text = "Inventario por Marca:"
        '
        'cmbInventariosClaseDos
        '
        Me.cmbInventariosClaseDos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInventariosClaseDos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInventariosClaseDos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbInventariosClaseDos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInventariosClaseDos.ForeColor = System.Drawing.Color.Black
        Me.cmbInventariosClaseDos.FormattingEnabled = True
        Me.cmbInventariosClaseDos.Location = New System.Drawing.Point(227, 232)
        Me.cmbInventariosClaseDos.Name = "cmbInventariosClaseDos"
        Me.cmbInventariosClaseDos.Size = New System.Drawing.Size(226, 24)
        Me.cmbInventariosClaseDos.TabIndex = 761
        '
        'LabelControl181
        '
        Me.LabelControl181.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl181.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl181.Location = New System.Drawing.Point(38, 72)
        Me.LabelControl181.Name = "LabelControl181"
        Me.LabelControl181.Size = New System.Drawing.Size(161, 23)
        Me.LabelControl181.TabIndex = 755
        Me.LabelControl181.Text = "Inventario general:"
        '
        'LabelControl118
        '
        Me.LabelControl118.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl118.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl118.Location = New System.Drawing.Point(38, 173)
        Me.LabelControl118.Name = "LabelControl118"
        Me.LabelControl118.Size = New System.Drawing.Size(129, 23)
        Me.LabelControl118.TabIndex = 757
        Me.LabelControl118.Text = "por Fabricante:"
        '
        'LabelControl192
        '
        Me.LabelControl192.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl192.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl192.Location = New System.Drawing.Point(19, 32)
        Me.LabelControl192.Name = "LabelControl192"
        Me.LabelControl192.Size = New System.Drawing.Size(192, 23)
        Me.LabelControl192.TabIndex = 756
        Me.LabelControl192.Text = "Reportes de Inventario"
        '
        'cmbInventariosClaseUno
        '
        Me.cmbInventariosClaseUno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInventariosClaseUno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInventariosClaseUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbInventariosClaseUno.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbInventariosClaseUno.ForeColor = System.Drawing.Color.Black
        Me.cmbInventariosClaseUno.FormattingEnabled = True
        Me.cmbInventariosClaseUno.Location = New System.Drawing.Point(227, 176)
        Me.cmbInventariosClaseUno.Name = "cmbInventariosClaseUno"
        Me.cmbInventariosClaseUno.Size = New System.Drawing.Size(226, 24)
        Me.cmbInventariosClaseUno.TabIndex = 758
        '
        'SplitContainerInventarios
        '
        Me.SplitContainerInventarios.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1
        Me.SplitContainerInventarios.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2
        Me.SplitContainerInventarios.Location = New System.Drawing.Point(10, 46)
        Me.SplitContainerInventarios.Name = "SplitContainerInventarios"
        Me.SplitContainerInventarios.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SplitContainerInventarios.Panel1.Controls.Add(Me.GroupControl2)
        Me.SplitContainerInventarios.Panel1.Text = "Panel1"
        Me.SplitContainerInventarios.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SplitContainerInventarios.Panel2.Controls.Add(Me.GroupControl1)
        Me.SplitContainerInventarios.Panel2.Text = "Panel2"
        Me.SplitContainerInventarios.Size = New System.Drawing.Size(1318, 639)
        Me.SplitContainerInventarios.SplitterPosition = 1048
        Me.SplitContainerInventarios.TabIndex = 768
        Me.SplitContainerInventarios.Text = "SplitContainerControl1"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.TileControl1)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(261, 635)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Movimientos"
        '
        'TileControl1
        '
        Me.TileControl1.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TileControl1.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Gray
        Me.TileControl1.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileControl1.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TileControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.TileControl1.ColumnCount = 1
        Me.TileControl1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TileControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileControl1.DragSize = New System.Drawing.Size(0, 0)
        Me.TileControl1.Groups.Add(Me.TileGroup2)
        Me.TileControl1.IndentBetweenItems = 5
        Me.TileControl1.ItemContentAnimation = DevExpress.XtraEditors.TileItemContentAnimationType.Fade
        Me.TileControl1.ItemSize = 100
        Me.TileControl1.Location = New System.Drawing.Point(2, 20)
        Me.TileControl1.MaxId = 11
        Me.TileControl1.Name = "TileControl1"
        Me.TileControl1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileControl1.Size = New System.Drawing.Size(257, 613)
        Me.TileControl1.TabIndex = 0
        Me.TileControl1.Text = "TileControl1"
        '
        'TileGroup2
        '
        Me.TileGroup2.Items.Add(Me.TileVencimientos)
        Me.TileGroup2.Items.Add(Me.TileMinimos)
        Me.TileGroup2.Items.Add(Me.cmdInventariosCerrarMes)
        Me.TileGroup2.Items.Add(Me.btnActualizar)
        Me.TileGroup2.Items.Add(Me.btnExistenciasCero)
        Me.TileGroup2.Items.Add(Me.btnResetInventory)
        Me.TileGroup2.Name = "TileGroup2"
        '
        'TileVencimientos
        '
        Me.TileVencimientos.AppearanceItem.Normal.BackColor = System.Drawing.Color.White
        Me.TileVencimientos.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Silver
        Me.TileVencimientos.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Gray
        Me.TileVencimientos.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileVencimientos.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TileVencimientos.AppearanceItem.Normal.Options.UseForeColor = True
        TileItemElement1.Image = Global.Ares.My.Resources.Resources.btWarning
        TileItemElement1.Text = "Establecer Fechas de Vencimiento"
        Me.TileVencimientos.Elements.Add(TileItemElement1)
        Me.TileVencimientos.Id = 9
        Me.TileVencimientos.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileVencimientos.Name = "TileVencimientos"
        '
        'TileMinimos
        '
        Me.TileMinimos.AppearanceItem.Normal.BackColor = System.Drawing.Color.White
        Me.TileMinimos.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Silver
        Me.TileMinimos.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Gray
        Me.TileMinimos.AppearanceItem.Normal.Options.UseBackColor = True
        Me.TileMinimos.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.TileMinimos.AppearanceItem.Normal.Options.UseForeColor = True
        TileItemElement2.Image = Global.Ares.My.Resources.Resources.load
        TileItemElement2.Text = "Establecer Mínimos - Maximos"
        Me.TileMinimos.Elements.Add(TileItemElement2)
        Me.TileMinimos.Id = 10
        Me.TileMinimos.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileMinimos.Name = "TileMinimos"
        '
        'cmdInventariosCerrarMes
        '
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.BackColor = System.Drawing.Color.White
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Silver
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Gray
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.Options.UseBackColor = True
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.Options.UseFont = True
        Me.cmdInventariosCerrarMes.AppearanceItem.Normal.Options.UseForeColor = True
        TileItemElement3.Image = Global.Ares.My.Resources.Resources.bt161
        TileItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight
        TileItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileItemElement3.Text = "Cierre de Inventario"
        Me.cmdInventariosCerrarMes.Elements.Add(TileItemElement3)
        Me.cmdInventariosCerrarMes.Id = 4
        Me.cmdInventariosCerrarMes.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.cmdInventariosCerrarMes.Name = "cmdInventariosCerrarMes"
        '
        'btnActualizar
        '
        Me.btnActualizar.AppearanceItem.Normal.BackColor = System.Drawing.Color.CadetBlue
        Me.btnActualizar.AppearanceItem.Normal.BorderColor = System.Drawing.Color.White
        Me.btnActualizar.AppearanceItem.Normal.Options.UseBackColor = True
        Me.btnActualizar.AppearanceItem.Normal.Options.UseBorderColor = True
        TileItemElement4.Image = Global.Ares.My.Resources.Resources.sync
        TileItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight
        TileItemElement4.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileItemElement4.Text = "Actualizar Inventario"
        Me.btnActualizar.Elements.Add(TileItemElement4)
        Me.btnActualizar.Id = 5
        Me.btnActualizar.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Visible = False
        '
        'btnExistenciasCero
        '
        Me.btnExistenciasCero.AppearanceItem.Normal.BackColor = System.Drawing.Color.White
        Me.btnExistenciasCero.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Silver
        Me.btnExistenciasCero.AppearanceItem.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExistenciasCero.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Gray
        Me.btnExistenciasCero.AppearanceItem.Normal.Options.UseBackColor = True
        Me.btnExistenciasCero.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.btnExistenciasCero.AppearanceItem.Normal.Options.UseFont = True
        Me.btnExistenciasCero.AppearanceItem.Normal.Options.UseForeColor = True
        TileItemElement5.Image = Global.Ares.My.Resources.Resources.btWarning
        TileItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight
        TileItemElement5.Text = "Dejar Inventario a Cero"
        Me.btnExistenciasCero.Elements.Add(TileItemElement5)
        Me.btnExistenciasCero.Id = 6
        Me.btnExistenciasCero.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.btnExistenciasCero.Name = "btnExistenciasCero"
        '
        'btnResetInventory
        '
        Me.btnResetInventory.AppearanceItem.Normal.BackColor = System.Drawing.Color.White
        Me.btnResetInventory.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Silver
        Me.btnResetInventory.AppearanceItem.Normal.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetInventory.AppearanceItem.Normal.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnResetInventory.AppearanceItem.Normal.Options.UseBackColor = True
        Me.btnResetInventory.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.btnResetInventory.AppearanceItem.Normal.Options.UseFont = True
        Me.btnResetInventory.AppearanceItem.Normal.Options.UseForeColor = True
        TileItemElement6.Image = Global.Ares.My.Resources.Resources.btNominasGuardadas1
        TileItemElement6.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomRight
        TileItemElement6.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileItemElement6.Text = "Reset Inventory"
        Me.btnResetInventory.Elements.Add(TileItemElement6)
        Me.btnResetInventory.Id = 7
        Me.btnResetInventory.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.btnResetInventory.Name = "btnResetInventory"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.cmdInventariosImprimirEXCEL)
        Me.GroupControl1.Controls.Add(Me.LabelControl192)
        Me.GroupControl1.Controls.Add(Me.cmdInventariosClaseDos)
        Me.GroupControl1.Controls.Add(Me.cmbInventariosClaseUno)
        Me.GroupControl1.Controls.Add(Me.cmbInventariosMarca)
        Me.GroupControl1.Controls.Add(Me.LabelControl118)
        Me.GroupControl1.Controls.Add(Me.cmbInventariosClaseTres)
        Me.GroupControl1.Controls.Add(Me.LabelControl181)
        Me.GroupControl1.Controls.Add(Me.LabelControl197)
        Me.GroupControl1.Controls.Add(Me.cmdInventariosClaseUno)
        Me.GroupControl1.Controls.Add(Me.cmdInventariosImprimir)
        Me.GroupControl1.Controls.Add(Me.cmdInventariosClaseTres)
        Me.GroupControl1.Controls.Add(Me.LabelControl120)
        Me.GroupControl1.Controls.Add(Me.cmdInventariosPorMarca)
        Me.GroupControl1.Controls.Add(Me.LabelControl198)
        Me.GroupControl1.Controls.Add(Me.cmbInventariosClaseDos)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1044, 635)
        Me.GroupControl1.TabIndex = 766
        Me.GroupControl1.Text = "Reportes"
        '
        'cmdInventariosImprimirEXCEL
        '
        Me.cmdInventariosImprimirEXCEL.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdInventariosImprimirEXCEL.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInventariosImprimirEXCEL.Appearance.ForeColor = System.Drawing.Color.Green
        Me.cmdInventariosImprimirEXCEL.Appearance.Options.UseBackColor = True
        Me.cmdInventariosImprimirEXCEL.Appearance.Options.UseFont = True
        Me.cmdInventariosImprimirEXCEL.Appearance.Options.UseForeColor = True
        Me.cmdInventariosImprimirEXCEL.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdInventariosImprimirEXCEL.AppearanceHovered.Options.UseBackColor = True
        Me.cmdInventariosImprimirEXCEL.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdInventariosImprimirEXCEL.Image = CType(resources.GetObject("cmdInventariosImprimirEXCEL.Image"), System.Drawing.Image)
        Me.cmdInventariosImprimirEXCEL.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdInventariosImprimirEXCEL.Location = New System.Drawing.Point(336, 67)
        Me.cmdInventariosImprimirEXCEL.Name = "cmdInventariosImprimirEXCEL"
        Me.cmdInventariosImprimirEXCEL.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdInventariosImprimirEXCEL.Size = New System.Drawing.Size(76, 38)
        Me.cmdInventariosImprimirEXCEL.TabIndex = 766
        '
        'cmdInventariosClaseDos
        '
        Me.cmdInventariosClaseDos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdInventariosClaseDos.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInventariosClaseDos.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdInventariosClaseDos.Appearance.Options.UseBackColor = True
        Me.cmdInventariosClaseDos.Appearance.Options.UseFont = True
        Me.cmdInventariosClaseDos.Appearance.Options.UseForeColor = True
        Me.cmdInventariosClaseDos.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdInventariosClaseDos.AppearanceHovered.Options.UseBackColor = True
        Me.cmdInventariosClaseDos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdInventariosClaseDos.Image = CType(resources.GetObject("cmdInventariosClaseDos.Image"), System.Drawing.Image)
        Me.cmdInventariosClaseDos.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdInventariosClaseDos.Location = New System.Drawing.Point(478, 224)
        Me.cmdInventariosClaseDos.Name = "cmdInventariosClaseDos"
        Me.cmdInventariosClaseDos.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdInventariosClaseDos.Size = New System.Drawing.Size(92, 38)
        Me.cmdInventariosClaseDos.TabIndex = 762
        Me.cmdInventariosClaseDos.Text = "Ver"
        '
        'cmdInventariosClaseUno
        '
        Me.cmdInventariosClaseUno.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdInventariosClaseUno.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInventariosClaseUno.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdInventariosClaseUno.Appearance.Options.UseBackColor = True
        Me.cmdInventariosClaseUno.Appearance.Options.UseFont = True
        Me.cmdInventariosClaseUno.Appearance.Options.UseForeColor = True
        Me.cmdInventariosClaseUno.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdInventariosClaseUno.AppearanceHovered.Options.UseBackColor = True
        Me.cmdInventariosClaseUno.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdInventariosClaseUno.Image = CType(resources.GetObject("cmdInventariosClaseUno.Image"), System.Drawing.Image)
        Me.cmdInventariosClaseUno.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdInventariosClaseUno.Location = New System.Drawing.Point(478, 168)
        Me.cmdInventariosClaseUno.Name = "cmdInventariosClaseUno"
        Me.cmdInventariosClaseUno.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdInventariosClaseUno.Size = New System.Drawing.Size(92, 38)
        Me.cmdInventariosClaseUno.TabIndex = 759
        Me.cmdInventariosClaseUno.Text = "Ver"
        '
        'cmdInventariosImprimir
        '
        Me.cmdInventariosImprimir.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdInventariosImprimir.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInventariosImprimir.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdInventariosImprimir.Appearance.Options.UseBackColor = True
        Me.cmdInventariosImprimir.Appearance.Options.UseFont = True
        Me.cmdInventariosImprimir.Appearance.Options.UseForeColor = True
        Me.cmdInventariosImprimir.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdInventariosImprimir.AppearanceHovered.Options.UseBackColor = True
        Me.cmdInventariosImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdInventariosImprimir.Image = CType(resources.GetObject("cmdInventariosImprimir.Image"), System.Drawing.Image)
        Me.cmdInventariosImprimir.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdInventariosImprimir.Location = New System.Drawing.Point(227, 67)
        Me.cmdInventariosImprimir.Name = "cmdInventariosImprimir"
        Me.cmdInventariosImprimir.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdInventariosImprimir.Size = New System.Drawing.Size(92, 38)
        Me.cmdInventariosImprimir.TabIndex = 750
        Me.cmdInventariosImprimir.Text = "Ver"
        '
        'cmdInventariosClaseTres
        '
        Me.cmdInventariosClaseTres.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdInventariosClaseTres.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInventariosClaseTres.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdInventariosClaseTres.Appearance.Options.UseBackColor = True
        Me.cmdInventariosClaseTres.Appearance.Options.UseFont = True
        Me.cmdInventariosClaseTres.Appearance.Options.UseForeColor = True
        Me.cmdInventariosClaseTres.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdInventariosClaseTres.AppearanceHovered.Options.UseBackColor = True
        Me.cmdInventariosClaseTres.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdInventariosClaseTres.Image = CType(resources.GetObject("cmdInventariosClaseTres.Image"), System.Drawing.Image)
        Me.cmdInventariosClaseTres.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdInventariosClaseTres.Location = New System.Drawing.Point(478, 284)
        Me.cmdInventariosClaseTres.Name = "cmdInventariosClaseTres"
        Me.cmdInventariosClaseTres.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdInventariosClaseTres.Size = New System.Drawing.Size(92, 38)
        Me.cmdInventariosClaseTres.TabIndex = 765
        Me.cmdInventariosClaseTres.Text = "Ver"
        '
        'cmdInventariosPorMarca
        '
        Me.cmdInventariosPorMarca.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdInventariosPorMarca.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdInventariosPorMarca.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdInventariosPorMarca.Appearance.Options.UseBackColor = True
        Me.cmdInventariosPorMarca.Appearance.Options.UseFont = True
        Me.cmdInventariosPorMarca.Appearance.Options.UseForeColor = True
        Me.cmdInventariosPorMarca.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdInventariosPorMarca.AppearanceHovered.Options.UseBackColor = True
        Me.cmdInventariosPorMarca.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdInventariosPorMarca.Image = CType(resources.GetObject("cmdInventariosPorMarca.Image"), System.Drawing.Image)
        Me.cmdInventariosPorMarca.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdInventariosPorMarca.Location = New System.Drawing.Point(478, 115)
        Me.cmdInventariosPorMarca.Name = "cmdInventariosPorMarca"
        Me.cmdInventariosPorMarca.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdInventariosPorMarca.Size = New System.Drawing.Size(92, 38)
        Me.cmdInventariosPorMarca.TabIndex = 754
        Me.cmdInventariosPorMarca.Text = "Ver"
        '
        'gridExports
        '
        Me.gridExports.Location = New System.Drawing.Point(165, 139)
        Me.gridExports.MainView = Me.GridView1
        Me.gridExports.Name = "gridExports"
        Me.gridExports.Size = New System.Drawing.Size(1172, 208)
        Me.gridExports.TabIndex = 767
        Me.gridExports.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridExports
        Me.GridView1.Name = "GridView1"
        '
        'ViewInventarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainerInventarios)
        Me.Controls.Add(Me.LabelControl50)
        Me.Controls.Add(Me.gridExports)
        Me.Name = "ViewInventarios"
        Me.Size = New System.Drawing.Size(1340, 696)
        CType(Me.SplitContainerInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerInventarios.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.gridExports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl50 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdInventariosClaseTres As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl198 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdInventariosImprimir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbInventariosClaseTres As ComboBox
    Friend WithEvents cmdInventariosClaseDos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbInventariosMarca As ComboBox
    Friend WithEvents LabelControl197 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl120 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbInventariosClaseDos As ComboBox
    Friend WithEvents cmdInventariosPorMarca As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdInventariosClaseUno As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl181 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl118 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl192 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbInventariosClaseUno As ComboBox
    Friend WithEvents SplitContainerInventarios As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TileControl1 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TileGroup2 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents cmdInventariosCerrarMes As DevExpress.XtraEditors.TileItem
    Friend WithEvents btnActualizar As DevExpress.XtraEditors.TileItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnExistenciasCero As DevExpress.XtraEditors.TileItem
    Friend WithEvents btnResetInventory As DevExpress.XtraEditors.TileItem
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmdInventariosImprimirEXCEL As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridExports As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TileVencimientos As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileMinimos As DevExpress.XtraEditors.TileItem
End Class
