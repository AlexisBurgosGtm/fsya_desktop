<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewPedidosDomicilio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewPedidosDomicilio))
        Me.btnSyncObtenerCenso = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.switchEntregados = New DevExpress.XtraEditors.ToggleSwitch()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridPedidosPendientes = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSync = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.RadialMenuPedidos = New DevExpress.XtraBars.Ribbon.RadialMenu(Me.components)
        Me.btnRadMenFacturar = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadMenEntregado = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRadMenImprimir = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.switchEntregados.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridPedidosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadialMenuPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSyncObtenerCenso
        '
        Me.btnSyncObtenerCenso.Image = CType(resources.GetObject("btnSyncObtenerCenso.Image"), System.Drawing.Image)
        Me.btnSyncObtenerCenso.Location = New System.Drawing.Point(867, 29)
        Me.btnSyncObtenerCenso.Name = "btnSyncObtenerCenso"
        Me.btnSyncObtenerCenso.Size = New System.Drawing.Size(132, 35)
        Me.btnSyncObtenerCenso.TabIndex = 36
        Me.btnSyncObtenerCenso.Text = "Obtener Censo"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(620, 39)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl2.TabIndex = 35
        Me.LabelControl2.Text = "Filtrar por:"
        '
        'switchEntregados
        '
        Me.switchEntregados.Location = New System.Drawing.Point(682, 35)
        Me.switchEntregados.Name = "switchEntregados"
        Me.switchEntregados.Properties.OffText = "NO ENTREGADOS"
        Me.switchEntregados.Properties.OnText = "ENTREGADOS"
        Me.switchEntregados.Size = New System.Drawing.Size(162, 24)
        Me.switchEntregados.TabIndex = 34
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridPedidosPendientes)
        Me.GroupControl1.Location = New System.Drawing.Point(6, 71)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(998, 360)
        Me.GroupControl1.TabIndex = 33
        Me.GroupControl1.Text = "Pedidos - DOBLE CLIC PARA IMPRIMIR"
        '
        'GridPedidosPendientes
        '
        Me.GridPedidosPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPedidosPendientes.Location = New System.Drawing.Point(2, 20)
        Me.GridPedidosPendientes.MainView = Me.GridViewSync
        Me.GridPedidosPendientes.Name = "GridPedidosPendientes"
        Me.GridPedidosPendientes.Size = New System.Drawing.Size(994, 338)
        Me.GridPedidosPendientes.TabIndex = 3
        Me.GridPedidosPendientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSync})
        '
        'GridViewSync
        '
        Me.GridViewSync.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridViewSync.GridControl = Me.GridPedidosPendientes
        Me.GridViewSync.Name = "GridViewSync"
        Me.GridViewSync.OptionsBehavior.Editable = False
        Me.GridViewSync.OptionsFind.FindNullPrompt = "Escriba para buscar...."
        Me.GridViewSync.OptionsView.ShowAutoFilterRow = True
        Me.GridViewSync.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(113, 32)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(296, 23)
        Me.LabelControl1.TabIndex = 37
        Me.LabelControl1.Text = "Gestión de Pedidos a Domicilio"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = CType(resources.GetObject("SimpleButton2.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(552, 29)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(53, 30)
        Me.SimpleButton2.TabIndex = 38
        '
        'RadialMenuPedidos
        '
        Me.RadialMenuPedidos.AutoExpand = True
        Me.RadialMenuPedidos.Glyph = CType(resources.GetObject("RadialMenuPedidos.Glyph"), System.Drawing.Image)
        Me.RadialMenuPedidos.ItemAutoSize = DevExpress.XtraBars.Ribbon.RadialMenuItemAutoSize.Spring
        Me.RadialMenuPedidos.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenFacturar), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenEntregado), New DevExpress.XtraBars.LinkPersistInfo(Me.btnRadMenImprimir)})
        Me.RadialMenuPedidos.Manager = Me.BarManager1
        Me.RadialMenuPedidos.Name = "RadialMenuPedidos"
        '
        'btnRadMenFacturar
        '
        Me.btnRadMenFacturar.Caption = "FACTURAR"
        Me.btnRadMenFacturar.CloseRadialMenuOnItemClick = True
        Me.btnRadMenFacturar.Glyph = CType(resources.GetObject("btnRadMenFacturar.Glyph"), System.Drawing.Image)
        Me.btnRadMenFacturar.Id = 0
        Me.btnRadMenFacturar.Name = "btnRadMenFacturar"
        '
        'btnRadMenEntregado
        '
        Me.btnRadMenEntregado.Caption = "MARCAR ENTREGADO"
        Me.btnRadMenEntregado.CloseRadialMenuOnItemClick = True
        Me.btnRadMenEntregado.Glyph = CType(resources.GetObject("btnRadMenEntregado.Glyph"), System.Drawing.Image)
        Me.btnRadMenEntregado.Id = 1
        Me.btnRadMenEntregado.Name = "btnRadMenEntregado"
        '
        'btnRadMenImprimir
        '
        Me.btnRadMenImprimir.Caption = "SOLO IMPRIMIR"
        Me.btnRadMenImprimir.CloseRadialMenuOnItemClick = True
        Me.btnRadMenImprimir.Glyph = CType(resources.GetObject("btnRadMenImprimir.Glyph"), System.Drawing.Image)
        Me.btnRadMenImprimir.Id = 2
        Me.btnRadMenImprimir.Name = "btnRadMenImprimir"
        '
        'BarManager1
        '
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnRadMenFacturar, Me.btnRadMenEntregado, Me.btnRadMenImprimir})
        Me.BarManager1.MaxItemId = 3
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1010, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 440)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1010, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 440)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1010, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 440)
        '
        'cmdRPTVatras
        '
        Me.cmdRPTVatras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdRPTVatras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRPTVatras.Image = CType(resources.GetObject("cmdRPTVatras.Image"), System.Drawing.Image)
        Me.cmdRPTVatras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdRPTVatras.Location = New System.Drawing.Point(3, 3)
        Me.cmdRPTVatras.Name = "cmdRPTVatras"
        Me.cmdRPTVatras.Size = New System.Drawing.Size(44, 40)
        Me.cmdRPTVatras.TabIndex = 250
        '
        'viewPedidosDomicilio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnSyncObtenerCenso)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.switchEntregados)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "viewPedidosDomicilio"
        Me.Size = New System.Drawing.Size(1010, 440)
        CType(Me.switchEntregados.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridPedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadialMenuPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSyncObtenerCenso As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents switchEntregados As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridPedidosPendientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSync As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents RadialMenuPedidos As DevExpress.XtraBars.Ribbon.RadialMenu
    Friend WithEvents btnRadMenFacturar As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadMenEntregado As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRadMenImprimir As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
End Class
