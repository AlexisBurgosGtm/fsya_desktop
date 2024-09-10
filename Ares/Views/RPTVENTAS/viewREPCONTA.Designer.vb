<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewREPCONTA
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewREPCONTA))
        Dim TileItemElement1 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement2 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Dim TileItemElement3 As DevExpress.XtraEditors.TileItemElement = New DevExpress.XtraEditors.TileItemElement()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbSUCURSALES = New System.Windows.Forms.ComboBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.tileControl1 = New DevExpress.XtraEditors.TileControl()
        Me.TileGroup2 = New DevExpress.XtraEditors.TileGroup()
        Me.TileItemFEL = New DevExpress.XtraEditors.TileItem()
        Me.TileItemEXAFEC = New DevExpress.XtraEditors.TileItem()
        Me.TileItemFAC = New DevExpress.XtraEditors.TileItem()
        Me.gridExports = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gridExports1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gridExports2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.gridExports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridExports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridExports2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRPTVatras
        '
        Me.cmdRPTVatras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdRPTVatras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRPTVatras.Image = CType(resources.GetObject("cmdRPTVatras.Image"), System.Drawing.Image)
        Me.cmdRPTVatras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdRPTVatras.Location = New System.Drawing.Point(0, 0)
        Me.cmdRPTVatras.Name = "cmdRPTVatras"
        Me.cmdRPTVatras.Size = New System.Drawing.Size(44, 40)
        Me.cmdRPTVatras.TabIndex = 249
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl4.Location = New System.Drawing.Point(149, 13)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(401, 24)
        Me.LabelControl4.TabIndex = 250
        Me.LabelControl4.Text = "SECCION DE REPORTES CONTABILIDAD"
        '
        'cmbSUCURSALES
        '
        Me.cmbSUCURSALES.FormattingEnabled = True
        Me.cmbSUCURSALES.Location = New System.Drawing.Point(219, 43)
        Me.cmbSUCURSALES.Name = "cmbSUCURSALES"
        Me.cmbSUCURSALES.Size = New System.Drawing.Size(121, 21)
        Me.cmbSUCURSALES.TabIndex = 247
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl7.Location = New System.Drawing.Point(13, 46)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(200, 16)
        Me.LabelControl7.TabIndex = 248
        Me.LabelControl7.Text = "Seleccione la Sucursal a consultar:"
        '
        'tileControl1
        '
        Me.tileControl1.AppearanceGroupText.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tileControl1.AppearanceGroupText.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.tileControl1.AppearanceGroupText.Options.UseFont = True
        Me.tileControl1.AppearanceGroupText.Options.UseForeColor = True
        Me.tileControl1.AppearanceItem.Normal.BackColor = System.Drawing.Color.White
        Me.tileControl1.AppearanceItem.Normal.BorderColor = System.Drawing.Color.DarkGray
        Me.tileControl1.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Gray
        Me.tileControl1.AppearanceItem.Normal.Options.UseBackColor = True
        Me.tileControl1.AppearanceItem.Normal.Options.UseBorderColor = True
        Me.tileControl1.AppearanceItem.Normal.Options.UseForeColor = True
        Me.tileControl1.DragSize = New System.Drawing.Size(0, 0)
        Me.tileControl1.Groups.Add(Me.TileGroup2)
        Me.tileControl1.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.tileControl1.IndentBetweenGroups = 30
        Me.tileControl1.IndentBetweenItems = 5
        Me.tileControl1.ItemSize = 100
        Me.tileControl1.Location = New System.Drawing.Point(18, 72)
        Me.tileControl1.MaxId = 46
        Me.tileControl1.Name = "tileControl1"
        Me.tileControl1.Size = New System.Drawing.Size(662, 178)
        Me.tileControl1.TabIndex = 251
        Me.tileControl1.Text = "TileMenuOperador"
        '
        'TileGroup2
        '
        Me.TileGroup2.Items.Add(Me.TileItemFEL)
        Me.TileGroup2.Items.Add(Me.TileItemEXAFEC)
        Me.TileGroup2.Items.Add(Me.TileItemFAC)
        Me.TileGroup2.Name = "TileGroup2"
        Me.TileGroup2.Text = "SUCURSAL"
        '
        'TileItemFEL
        '
        TileItemElement1.Image = CType(resources.GetObject("TileItemElement1.Image"), System.Drawing.Image)
        TileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight
        TileItemElement1.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileItemElement1.Text = "EXPORTAR                                                     REPORTE FEL"
        TileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        Me.TileItemFEL.Elements.Add(TileItemElement1)
        Me.TileItemFEL.Id = 43
        Me.TileItemFEL.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItemFEL.Name = "TileItemFEL"
        '
        'TileItemEXAFEC
        '
        TileItemElement2.Image = CType(resources.GetObject("TileItemElement2.Image"), System.Drawing.Image)
        TileItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight
        TileItemElement2.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileItemElement2.Text = "REPORTE                                              EXENTOS Y                   " &
    "                                  AFECTOS"
        TileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        Me.TileItemEXAFEC.Elements.Add(TileItemElement2)
        Me.TileItemEXAFEC.Id = 39
        Me.TileItemEXAFEC.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItemEXAFEC.Name = "TileItemEXAFEC"
        '
        'TileItemFAC
        '
        TileItemElement3.Image = CType(resources.GetObject("TileItemElement3.Image"), System.Drawing.Image)
        TileItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleRight
        TileItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside
        TileItemElement3.Text = "EXPORTAR                                                     REPORTE FAC"
        TileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleLeft
        Me.TileItemFAC.Elements.Add(TileItemElement3)
        Me.TileItemFAC.Id = 44
        Me.TileItemFAC.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
        Me.TileItemFAC.Name = "TileItemFAC"
        '
        'gridExports
        '
        Me.gridExports.Location = New System.Drawing.Point(650, 267)
        Me.gridExports.MainView = Me.GridView2
        Me.gridExports.Name = "gridExports"
        Me.gridExports.Size = New System.Drawing.Size(86, 60)
        Me.gridExports.TabIndex = 252
        Me.gridExports.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        Me.gridExports.Visible = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridExports
        Me.GridView2.Name = "GridView2"
        '
        'gridExports1
        '
        Me.gridExports1.Location = New System.Drawing.Point(650, 262)
        Me.gridExports1.MainView = Me.GridView1
        Me.gridExports1.Name = "gridExports1"
        Me.gridExports1.Size = New System.Drawing.Size(86, 60)
        Me.gridExports1.TabIndex = 253
        Me.gridExports1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.gridExports1.Visible = False
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridExports1
        Me.GridView1.Name = "GridView1"
        '
        'gridExports2
        '
        Me.gridExports2.Location = New System.Drawing.Point(650, 257)
        Me.gridExports2.MainView = Me.GridView3
        Me.gridExports2.Name = "gridExports2"
        Me.gridExports2.Size = New System.Drawing.Size(86, 60)
        Me.gridExports2.TabIndex = 254
        Me.gridExports2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        Me.gridExports2.Visible = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridExports2
        Me.GridView3.Name = "GridView3"
        '
        'viewREPCONTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.Controls.Add(Me.gridExports)
        Me.Controls.Add(Me.gridExports1)
        Me.Controls.Add(Me.gridExports2)
        Me.Controls.Add(Me.tileControl1)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.cmbSUCURSALES)
        Me.Name = "viewREPCONTA"
        Me.Size = New System.Drawing.Size(693, 272)
        CType(Me.gridExports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridExports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridExports2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbSUCURSALES As ComboBox
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents tileControl1 As DevExpress.XtraEditors.TileControl
    Friend WithEvents TileGroup2 As DevExpress.XtraEditors.TileGroup
    Friend WithEvents TileItemFEL As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItemEXAFEC As DevExpress.XtraEditors.TileItem
    Friend WithEvents TileItemFAC As DevExpress.XtraEditors.TileItem
    Friend WithEvents gridExports As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridExports1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridExports2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
