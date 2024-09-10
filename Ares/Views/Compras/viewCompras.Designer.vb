<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewCompras))
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement3 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement4 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement5 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement6 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement7 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement8 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.LabelControl83 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbComprasBodega = New System.Windows.Forms.ComboBox()
        Me.cmbComprasTipoProd = New System.Windows.Forms.ComboBox()
        Me.cmbComprasDiasCredito = New System.Windows.Forms.ComboBox()
        Me.lbComprasVencimiento = New DevExpress.XtraEditors.LabelControl()
        Me.txtComprasFechaVence = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl57 = New DevExpress.XtraEditors.LabelControl()
        Me.txtComprasObs = New System.Windows.Forms.TextBox()
        Me.btnComprasTomarDatos = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl25 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbComprasConCre = New System.Windows.Forms.ComboBox()
        Me.LabelControl24 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbComprasVendedor = New System.Windows.Forms.ComboBox()
        Me.cmdComprasBuscarProveedor = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbComprasProveedor = New DevExpress.XtraEditors.TextEdit()
        Me.txtComprasNitProveedor = New DevExpress.XtraEditors.TextEdit()
        Me.txtComprasNombreProveedor = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl56 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl46 = New DevExpress.XtraEditors.LabelControl()
        Me.txtComprasNoFac = New System.Windows.Forms.TextBox()
        Me.LabelControl45 = New DevExpress.XtraEditors.LabelControl()
        Me.txtComprasSerieFac = New System.Windows.Forms.TextBox()
        Me.LabelControl37 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalCompra = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl36 = New DevExpress.XtraEditors.LabelControl()
        Me.GridTempProductosCompras = New DevExpress.XtraGrid.GridControl()
        Me.TileViewTempProductosCompras = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.DS_VENTAS2 = New Ares.DS_VENTAS2()
        Me.lbTituloCompras = New DevExpress.XtraEditors.LabelControl()
        Me.cmdComprasGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtComprasCodProducto = New System.Windows.Forms.TextBox()
        Me.txtComprasFiltro = New System.Windows.Forms.TextBox()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtComprasFecha = New DevExpress.XtraEditors.DateEdit()
        Me.txtComprasCorrelativo = New DevExpress.XtraEditors.TextEdit()
        Me.DGV_ListadoProductosCompras = New System.Windows.Forms.DataGridView()
        Me.CODPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPROD2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPROD2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPROD3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQUIVALEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMARCADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMARCADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblGridComprasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TimerColor = New System.Windows.Forms.Timer(Me.components)
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtComprasFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprasFechaVence.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbComprasProveedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprasNitProveedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprasNombreProveedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTempProductosCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileViewTempProductosCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_VENTAS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprasFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprasFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtComprasCorrelativo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_ListadoProductosCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblGridComprasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "FarmaSalud"
        Me.NotifyIcon1.Visible = True
        '
        'LabelControl83
        '
        Me.LabelControl83.Location = New System.Drawing.Point(1295, 857)
        Me.LabelControl83.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl83.Name = "LabelControl83"
        Me.LabelControl83.Size = New System.Drawing.Size(47, 16)
        Me.LabelControl83.TabIndex = 304
        Me.LabelControl83.Text = "Bodega:"
        Me.LabelControl83.Visible = False
        '
        'cmbComprasBodega
        '
        Me.cmbComprasBodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComprasBodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprasBodega.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprasBodega.FormattingEnabled = True
        Me.cmbComprasBodega.Location = New System.Drawing.Point(1267, 916)
        Me.cmbComprasBodega.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbComprasBodega.Name = "cmbComprasBodega"
        Me.cmbComprasBodega.Size = New System.Drawing.Size(152, 25)
        Me.cmbComprasBodega.TabIndex = 303
        Me.cmbComprasBodega.Visible = False
        '
        'cmbComprasTipoProd
        '
        Me.cmbComprasTipoProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComprasTipoProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprasTipoProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprasTipoProd.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprasTipoProd.FormattingEnabled = True
        Me.cmbComprasTipoProd.Location = New System.Drawing.Point(1470, 859)
        Me.cmbComprasTipoProd.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbComprasTipoProd.Name = "cmbComprasTipoProd"
        Me.cmbComprasTipoProd.Size = New System.Drawing.Size(88, 21)
        Me.cmbComprasTipoProd.TabIndex = 302
        Me.cmbComprasTipoProd.Visible = False
        '
        'cmbComprasDiasCredito
        '
        Me.cmbComprasDiasCredito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComprasDiasCredito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprasDiasCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprasDiasCredito.FormattingEnabled = True
        Me.cmbComprasDiasCredito.Items.AddRange(New Object() {"0", "7", "15", "30", "45", "60", "90"})
        Me.cmbComprasDiasCredito.Location = New System.Drawing.Point(931, 134)
        Me.cmbComprasDiasCredito.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbComprasDiasCredito.Name = "cmbComprasDiasCredito"
        Me.cmbComprasDiasCredito.Size = New System.Drawing.Size(53, 25)
        Me.cmbComprasDiasCredito.TabIndex = 10
        '
        'lbComprasVencimiento
        '
        Me.lbComprasVencimiento.Location = New System.Drawing.Point(790, 111)
        Me.lbComprasVencimiento.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lbComprasVencimiento.Name = "lbComprasVencimiento"
        Me.lbComprasVencimiento.Size = New System.Drawing.Size(78, 16)
        Me.lbComprasVencimiento.TabIndex = 300
        Me.lbComprasVencimiento.Text = "Fecha Vence:"
        '
        'txtComprasFechaVence
        '
        Me.txtComprasFechaVence.EditValue = Nothing
        Me.txtComprasFechaVence.Location = New System.Drawing.Point(790, 134)
        Me.txtComprasFechaVence.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasFechaVence.Name = "txtComprasFechaVence"
        Me.txtComprasFechaVence.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasFechaVence.Properties.Appearance.Options.UseFont = True
        Me.txtComprasFechaVence.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtComprasFechaVence.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtComprasFechaVence.Size = New System.Drawing.Size(138, 24)
        Me.txtComprasFechaVence.TabIndex = 9
        '
        'LabelControl57
        '
        Me.LabelControl57.Location = New System.Drawing.Point(509, 162)
        Me.LabelControl57.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl57.Name = "LabelControl57"
        Me.LabelControl57.Size = New System.Drawing.Size(88, 16)
        Me.LabelControl57.TabIndex = 297
        Me.LabelControl57.Text = "Observaciones:"
        '
        'txtComprasObs
        '
        Me.txtComprasObs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasObs.Location = New System.Drawing.Point(506, 186)
        Me.txtComprasObs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasObs.Multiline = True
        Me.txtComprasObs.Name = "txtComprasObs"
        Me.txtComprasObs.Size = New System.Drawing.Size(592, 66)
        Me.txtComprasObs.TabIndex = 11
        '
        'btnComprasTomarDatos
        '
        Me.btnComprasTomarDatos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnComprasTomarDatos.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnComprasTomarDatos.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnComprasTomarDatos.Appearance.Options.UseBackColor = True
        Me.btnComprasTomarDatos.Appearance.Options.UseFont = True
        Me.btnComprasTomarDatos.Appearance.Options.UseForeColor = True
        Me.btnComprasTomarDatos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnComprasTomarDatos.Location = New System.Drawing.Point(897, 22)
        Me.btnComprasTomarDatos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnComprasTomarDatos.Name = "btnComprasTomarDatos"
        Me.btnComprasTomarDatos.Size = New System.Drawing.Size(152, 62)
        Me.btnComprasTomarDatos.TabIndex = 296
        Me.btnComprasTomarDatos.Text = "Cargar Orden " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de Compra"
        '
        'LabelControl25
        '
        Me.LabelControl25.Location = New System.Drawing.Point(636, 111)
        Me.LabelControl25.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl25.Name = "LabelControl25"
        Me.LabelControl25.Size = New System.Drawing.Size(33, 16)
        Me.LabelControl25.TabIndex = 294
        Me.LabelControl25.Text = "Pago:"
        '
        'cmbComprasConCre
        '
        Me.cmbComprasConCre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComprasConCre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprasConCre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprasConCre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprasConCre.FormattingEnabled = True
        Me.cmbComprasConCre.Location = New System.Drawing.Point(636, 134)
        Me.cmbComprasConCre.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbComprasConCre.Name = "cmbComprasConCre"
        Me.cmbComprasConCre.Size = New System.Drawing.Size(150, 25)
        Me.cmbComprasConCre.TabIndex = 8
        '
        'LabelControl24
        '
        Me.LabelControl24.Location = New System.Drawing.Point(509, 111)
        Me.LabelControl24.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl24.Name = "LabelControl24"
        Me.LabelControl24.Size = New System.Drawing.Size(48, 16)
        Me.LabelControl24.TabIndex = 292
        Me.LabelControl24.Text = "Usuario:"
        '
        'cmbComprasVendedor
        '
        Me.cmbComprasVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbComprasVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbComprasVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComprasVendedor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprasVendedor.FormattingEnabled = True
        Me.cmbComprasVendedor.Location = New System.Drawing.Point(506, 134)
        Me.cmbComprasVendedor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbComprasVendedor.Name = "cmbComprasVendedor"
        Me.cmbComprasVendedor.Size = New System.Drawing.Size(122, 25)
        Me.cmbComprasVendedor.TabIndex = 7
        '
        'cmdComprasBuscarProveedor
        '
        Me.cmdComprasBuscarProveedor.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdComprasBuscarProveedor.Appearance.Options.UseFont = True
        Me.cmdComprasBuscarProveedor.ImageOptions.Image = CType(resources.GetObject("cmdComprasBuscarProveedor.ImageOptions.Image"), System.Drawing.Image)
        Me.cmdComprasBuscarProveedor.Location = New System.Drawing.Point(346, 130)
        Me.cmdComprasBuscarProveedor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdComprasBuscarProveedor.Name = "cmdComprasBuscarProveedor"
        Me.cmdComprasBuscarProveedor.Size = New System.Drawing.Size(68, 28)
        Me.cmdComprasBuscarProveedor.TabIndex = 2
        Me.cmdComprasBuscarProveedor.Text = "Buscar"
        '
        'cmbComprasProveedor
        '
        Me.cmbComprasProveedor.Location = New System.Drawing.Point(1428, 855)
        Me.cmbComprasProveedor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbComprasProveedor.Name = "cmbComprasProveedor"
        Me.cmbComprasProveedor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprasProveedor.Properties.Appearance.Options.UseFont = True
        Me.cmbComprasProveedor.Size = New System.Drawing.Size(35, 26)
        Me.cmbComprasProveedor.TabIndex = 289
        Me.cmbComprasProveedor.Visible = False
        '
        'txtComprasNitProveedor
        '
        Me.txtComprasNitProveedor.Location = New System.Drawing.Point(91, 132)
        Me.txtComprasNitProveedor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasNitProveedor.Name = "txtComprasNitProveedor"
        Me.txtComprasNitProveedor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasNitProveedor.Properties.Appearance.Options.UseFont = True
        Me.txtComprasNitProveedor.Size = New System.Drawing.Size(247, 24)
        Me.txtComprasNitProveedor.TabIndex = 1
        '
        'txtComprasNombreProveedor
        '
        Me.txtComprasNombreProveedor.Enabled = False
        Me.txtComprasNombreProveedor.Location = New System.Drawing.Point(91, 166)
        Me.txtComprasNombreProveedor.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasNombreProveedor.Name = "txtComprasNombreProveedor"
        Me.txtComprasNombreProveedor.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasNombreProveedor.Properties.Appearance.Options.UseFont = True
        Me.txtComprasNombreProveedor.Size = New System.Drawing.Size(323, 24)
        Me.txtComprasNombreProveedor.TabIndex = 287
        '
        'LabelControl56
        '
        Me.LabelControl56.Location = New System.Drawing.Point(91, 108)
        Me.LabelControl56.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl56.Name = "LabelControl56"
        Me.LabelControl56.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl56.TabIndex = 286
        Me.LabelControl56.Text = "Proveedor:"
        '
        'LabelControl46
        '
        Me.LabelControl46.Location = New System.Drawing.Point(630, 63)
        Me.LabelControl46.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl46.Name = "LabelControl46"
        Me.LabelControl46.Size = New System.Drawing.Size(71, 16)
        Me.LabelControl46.TabIndex = 284
        Me.LabelControl46.Text = "No. Factura:"
        '
        'txtComprasNoFac
        '
        Me.txtComprasNoFac.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasNoFac.Location = New System.Drawing.Point(716, 58)
        Me.txtComprasNoFac.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasNoFac.Name = "txtComprasNoFac"
        Me.txtComprasNoFac.Size = New System.Drawing.Size(139, 24)
        Me.txtComprasNoFac.TabIndex = 6
        '
        'LabelControl45
        '
        Me.LabelControl45.Location = New System.Drawing.Point(629, 25)
        Me.LabelControl45.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl45.Name = "LabelControl45"
        Me.LabelControl45.Size = New System.Drawing.Size(82, 16)
        Me.LabelControl45.TabIndex = 281
        Me.LabelControl45.Text = "Serie Factura:"
        '
        'txtComprasSerieFac
        '
        Me.txtComprasSerieFac.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasSerieFac.Location = New System.Drawing.Point(716, 22)
        Me.txtComprasSerieFac.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasSerieFac.Name = "txtComprasSerieFac"
        Me.txtComprasSerieFac.Size = New System.Drawing.Size(139, 24)
        Me.txtComprasSerieFac.TabIndex = 5
        '
        'LabelControl37
        '
        Me.LabelControl37.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl37.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl37.Appearance.Options.UseFont = True
        Me.LabelControl37.Appearance.Options.UseForeColor = True
        Me.LabelControl37.Location = New System.Drawing.Point(1225, 41)
        Me.LabelControl37.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl37.Name = "LabelControl37"
        Me.LabelControl37.Size = New System.Drawing.Size(26, 41)
        Me.LabelControl37.TabIndex = 279
        Me.LabelControl37.Text = "Q"
        '
        'lbTotalCompra
        '
        Me.lbTotalCompra.Appearance.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalCompra.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalCompra.Appearance.Options.UseFont = True
        Me.lbTotalCompra.Appearance.Options.UseForeColor = True
        Me.lbTotalCompra.Location = New System.Drawing.Point(1256, 38)
        Me.lbTotalCompra.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lbTotalCompra.Name = "lbTotalCompra"
        Me.lbTotalCompra.Size = New System.Drawing.Size(229, 43)
        Me.lbTotalCompra.TabIndex = 276
        Me.lbTotalCompra.Text = "9990,000.00"
        '
        'LabelControl36
        '
        Me.LabelControl36.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl36.Appearance.Options.UseFont = True
        Me.LabelControl36.Location = New System.Drawing.Point(1256, 15)
        Me.LabelControl36.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl36.Name = "LabelControl36"
        Me.LabelControl36.Size = New System.Drawing.Size(103, 19)
        Me.LabelControl36.TabIndex = 275
        Me.LabelControl36.Text = "Total Compra:"
        '
        'GridTempProductosCompras
        '
        Me.GridTempProductosCompras.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridTempProductosCompras.Location = New System.Drawing.Point(1104, 92)
        Me.GridTempProductosCompras.MainView = Me.TileViewTempProductosCompras
        Me.GridTempProductosCompras.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridTempProductosCompras.Name = "GridTempProductosCompras"
        Me.GridTempProductosCompras.Size = New System.Drawing.Size(377, 734)
        Me.GridTempProductosCompras.TabIndex = 271
        Me.GridTempProductosCompras.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TileViewTempProductosCompras})
        '
        'TileViewTempProductosCompras
        '
        Me.TileViewTempProductosCompras.DetailHeight = 431
        Me.TileViewTempProductosCompras.GridControl = Me.GridTempProductosCompras
        Me.TileViewTempProductosCompras.Name = "TileViewTempProductosCompras"
        Me.TileViewTempProductosCompras.OptionsFind.AlwaysVisible = True
        Me.TileViewTempProductosCompras.OptionsTiles.ColumnCount = 1
        Me.TileViewTempProductosCompras.OptionsTiles.ItemSize = New System.Drawing.Size(350, 130)
        Me.TileViewTempProductosCompras.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileViewTempProductosCompras.OptionsTiles.RowCount = 50
        TileViewItemElement1.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement1.Appearance.Normal.Options.UseFont = True
        TileViewItemElement1.Text = "001"
        TileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement1.TextLocation = New System.Drawing.Point(80, 0)
        TileViewItemElement2.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement2.Appearance.Normal.Options.UseFont = True
        TileViewItemElement2.Text = "ACETAMINOFEN"
        TileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement2.TextLocation = New System.Drawing.Point(0, 20)
        TileViewItemElement3.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement3.Appearance.Normal.Options.UseFont = True
        TileViewItemElement3.Text = "Q 200.00"
        TileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement3.TextLocation = New System.Drawing.Point(120, 80)
        TileViewItemElement4.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement4.Appearance.Normal.Options.UseFont = True
        TileViewItemElement4.Text = "100"
        TileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement4.TextLocation = New System.Drawing.Point(0, 75)
        TileViewItemElement5.Text = "Cantidad:"
        TileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement5.TextLocation = New System.Drawing.Point(0, 60)
        TileViewItemElement6.Text = "Código:"
        TileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement7.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement7.Appearance.Normal.Options.UseFont = True
        TileViewItemElement7.Text = "UNIDAD"
        TileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement7.TextLocation = New System.Drawing.Point(0, 95)
        TileViewItemElement8.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement8.Appearance.Normal.Options.UseFont = True
        TileViewItemElement8.Text = "Q 100.00"
        TileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement8.TextLocation = New System.Drawing.Point(130, 60)
        TileViewItemElement8.UseImageInTransition = False
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement1)
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement2)
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement3)
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement4)
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement5)
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement6)
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement7)
        Me.TileViewTempProductosCompras.TileTemplate.Add(TileViewItemElement8)
        '
        'DS_VENTAS2
        '
        Me.DS_VENTAS2.DataSetName = "DS_VENTAS2"
        Me.DS_VENTAS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbTituloCompras
        '
        Me.lbTituloCompras.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTituloCompras.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.lbTituloCompras.Appearance.Options.UseFont = True
        Me.lbTituloCompras.Appearance.Options.UseForeColor = True
        Me.lbTituloCompras.Location = New System.Drawing.Point(85, 15)
        Me.lbTituloCompras.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lbTituloCompras.Name = "lbTituloCompras"
        Me.lbTituloCompras.Size = New System.Drawing.Size(131, 41)
        Me.lbTituloCompras.TabIndex = 269
        Me.lbTituloCompras.Text = "Compras"
        '
        'cmdComprasGuardar
        '
        Me.cmdComprasGuardar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdComprasGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdComprasGuardar.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdComprasGuardar.Appearance.Options.UseBackColor = True
        Me.cmdComprasGuardar.Appearance.Options.UseFont = True
        Me.cmdComprasGuardar.Appearance.Options.UseForeColor = True
        Me.cmdComprasGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdComprasGuardar.Location = New System.Drawing.Point(1122, 14)
        Me.cmdComprasGuardar.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmdComprasGuardar.Name = "cmdComprasGuardar"
        Me.cmdComprasGuardar.Size = New System.Drawing.Size(96, 70)
        Me.cmdComprasGuardar.TabIndex = 12
        Me.cmdComprasGuardar.Text = "GUARDAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "F5"
        '
        'txtComprasCodProducto
        '
        Me.txtComprasCodProducto.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtComprasCodProducto.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasCodProducto.Location = New System.Drawing.Point(90, 197)
        Me.txtComprasCodProducto.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasCodProducto.Name = "txtComprasCodProducto"
        Me.txtComprasCodProducto.Size = New System.Drawing.Size(324, 32)
        Me.txtComprasCodProducto.TabIndex = 3
        '
        'txtComprasFiltro
        '
        Me.txtComprasFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtComprasFiltro.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasFiltro.Location = New System.Drawing.Point(90, 238)
        Me.txtComprasFiltro.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasFiltro.Name = "txtComprasFiltro"
        Me.txtComprasFiltro.Size = New System.Drawing.Size(324, 32)
        Me.txtComprasFiltro.TabIndex = 4
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(347, 25)
        Me.LabelControl10.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(68, 16)
        Me.LabelControl10.TabIndex = 266
        Me.LabelControl10.Text = "Compra No."
        '
        'LabelControl11
        '
        Me.LabelControl11.Location = New System.Drawing.Point(347, 55)
        Me.LabelControl11.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(39, 16)
        Me.LabelControl11.TabIndex = 265
        Me.LabelControl11.Text = "Fecha:"
        '
        'txtComprasFecha
        '
        Me.txtComprasFecha.EditValue = Nothing
        Me.txtComprasFecha.Enabled = False
        Me.txtComprasFecha.Location = New System.Drawing.Point(434, 57)
        Me.txtComprasFecha.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasFecha.Name = "txtComprasFecha"
        Me.txtComprasFecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasFecha.Properties.Appearance.Options.UseFont = True
        Me.txtComprasFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtComprasFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtComprasFecha.Size = New System.Drawing.Size(156, 24)
        Me.txtComprasFecha.TabIndex = 267
        '
        'txtComprasCorrelativo
        '
        Me.txtComprasCorrelativo.Enabled = False
        Me.txtComprasCorrelativo.Location = New System.Drawing.Point(434, 23)
        Me.txtComprasCorrelativo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtComprasCorrelativo.Name = "txtComprasCorrelativo"
        Me.txtComprasCorrelativo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComprasCorrelativo.Properties.Appearance.Options.UseFont = True
        Me.txtComprasCorrelativo.Size = New System.Drawing.Size(156, 24)
        Me.txtComprasCorrelativo.TabIndex = 268
        '
        'DGV_ListadoProductosCompras
        '
        Me.DGV_ListadoProductosCompras.AllowUserToAddRows = False
        Me.DGV_ListadoProductosCompras.AllowUserToDeleteRows = False
        Me.DGV_ListadoProductosCompras.AutoGenerateColumns = False
        Me.DGV_ListadoProductosCompras.BackgroundColor = System.Drawing.Color.White
        Me.DGV_ListadoProductosCompras.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV_ListadoProductosCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_ListadoProductosCompras.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPRODDataGridViewTextBoxColumn, Me.CODPROD2DataGridViewTextBoxColumn, Me.DESPRODDataGridViewTextBoxColumn, Me.DESPROD2DataGridViewTextBoxColumn, Me.DESPROD3DataGridViewTextBoxColumn, Me.SALDODataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn, Me.EQUIVALEDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn, Me.PRECIODataGridViewTextBoxColumn, Me.CODMARCADataGridViewTextBoxColumn, Me.DESMARCADataGridViewTextBoxColumn})
        Me.DGV_ListadoProductosCompras.DataSource = Me.TblGridComprasBindingSource
        Me.DGV_ListadoProductosCompras.Location = New System.Drawing.Point(3, 295)
        Me.DGV_ListadoProductosCompras.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DGV_ListadoProductosCompras.Name = "DGV_ListadoProductosCompras"
        Me.DGV_ListadoProductosCompras.ReadOnly = True
        Me.DGV_ListadoProductosCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV_ListadoProductosCompras.Size = New System.Drawing.Size(1095, 530)
        Me.DGV_ListadoProductosCompras.TabIndex = 305
        '
        'CODPRODDataGridViewTextBoxColumn
        '
        Me.CODPRODDataGridViewTextBoxColumn.DataPropertyName = "CODPROD"
        Me.CODPRODDataGridViewTextBoxColumn.HeaderText = "CodProd"
        Me.CODPRODDataGridViewTextBoxColumn.Name = "CODPRODDataGridViewTextBoxColumn"
        Me.CODPRODDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPRODDataGridViewTextBoxColumn.Width = 150
        '
        'CODPROD2DataGridViewTextBoxColumn
        '
        Me.CODPROD2DataGridViewTextBoxColumn.DataPropertyName = "CODPROD2"
        Me.CODPROD2DataGridViewTextBoxColumn.HeaderText = "CODPROD2"
        Me.CODPROD2DataGridViewTextBoxColumn.Name = "CODPROD2DataGridViewTextBoxColumn"
        Me.CODPROD2DataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPROD2DataGridViewTextBoxColumn.Visible = False
        '
        'DESPRODDataGridViewTextBoxColumn
        '
        Me.DESPRODDataGridViewTextBoxColumn.DataPropertyName = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.DESPRODDataGridViewTextBoxColumn.Name = "DESPRODDataGridViewTextBoxColumn"
        Me.DESPRODDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPRODDataGridViewTextBoxColumn.Width = 300
        '
        'DESPROD2DataGridViewTextBoxColumn
        '
        Me.DESPROD2DataGridViewTextBoxColumn.DataPropertyName = "DESPROD2"
        Me.DESPROD2DataGridViewTextBoxColumn.HeaderText = "Componentes"
        Me.DESPROD2DataGridViewTextBoxColumn.Name = "DESPROD2DataGridViewTextBoxColumn"
        Me.DESPROD2DataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPROD2DataGridViewTextBoxColumn.Visible = False
        '
        'DESPROD3DataGridViewTextBoxColumn
        '
        Me.DESPROD3DataGridViewTextBoxColumn.DataPropertyName = "DESPROD3"
        Me.DESPROD3DataGridViewTextBoxColumn.HeaderText = "Uso"
        Me.DESPROD3DataGridViewTextBoxColumn.Name = "DESPROD3DataGridViewTextBoxColumn"
        Me.DESPROD3DataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPROD3DataGridViewTextBoxColumn.Visible = False
        '
        'SALDODataGridViewTextBoxColumn
        '
        Me.SALDODataGridViewTextBoxColumn.DataPropertyName = "SALDO"
        Me.SALDODataGridViewTextBoxColumn.HeaderText = "Saldo"
        Me.SALDODataGridViewTextBoxColumn.Name = "SALDODataGridViewTextBoxColumn"
        Me.SALDODataGridViewTextBoxColumn.ReadOnly = True
        Me.SALDODataGridViewTextBoxColumn.Width = 60
        '
        'CODMEDIDADataGridViewTextBoxColumn
        '
        Me.CODMEDIDADataGridViewTextBoxColumn.DataPropertyName = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.HeaderText = "Medida"
        Me.CODMEDIDADataGridViewTextBoxColumn.Name = "CODMEDIDADataGridViewTextBoxColumn"
        Me.CODMEDIDADataGridViewTextBoxColumn.ReadOnly = True
        '
        'EQUIVALEDataGridViewTextBoxColumn
        '
        Me.EQUIVALEDataGridViewTextBoxColumn.DataPropertyName = "EQUIVALE"
        Me.EQUIVALEDataGridViewTextBoxColumn.HeaderText = "EQ"
        Me.EQUIVALEDataGridViewTextBoxColumn.Name = "EQUIVALEDataGridViewTextBoxColumn"
        Me.EQUIVALEDataGridViewTextBoxColumn.ReadOnly = True
        Me.EQUIVALEDataGridViewTextBoxColumn.Width = 30
        '
        'COSTODataGridViewTextBoxColumn
        '
        Me.COSTODataGridViewTextBoxColumn.DataPropertyName = "COSTO"
        DataGridViewCellStyle1.Format = "Q 0.00"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.COSTODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.COSTODataGridViewTextBoxColumn.HeaderText = "Costo"
        Me.COSTODataGridViewTextBoxColumn.Name = "COSTODataGridViewTextBoxColumn"
        Me.COSTODataGridViewTextBoxColumn.ReadOnly = True
        Me.COSTODataGridViewTextBoxColumn.Width = 60
        '
        'PRECIODataGridViewTextBoxColumn
        '
        Me.PRECIODataGridViewTextBoxColumn.DataPropertyName = "PRECIO"
        DataGridViewCellStyle2.Format = "Q 0.00"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PRECIODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.PRECIODataGridViewTextBoxColumn.HeaderText = "Precio"
        Me.PRECIODataGridViewTextBoxColumn.Name = "PRECIODataGridViewTextBoxColumn"
        Me.PRECIODataGridViewTextBoxColumn.ReadOnly = True
        Me.PRECIODataGridViewTextBoxColumn.Width = 60
        '
        'CODMARCADataGridViewTextBoxColumn
        '
        Me.CODMARCADataGridViewTextBoxColumn.DataPropertyName = "CODMARCA"
        Me.CODMARCADataGridViewTextBoxColumn.HeaderText = "CODMARCA"
        Me.CODMARCADataGridViewTextBoxColumn.Name = "CODMARCADataGridViewTextBoxColumn"
        Me.CODMARCADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODMARCADataGridViewTextBoxColumn.Visible = False
        '
        'DESMARCADataGridViewTextBoxColumn
        '
        Me.DESMARCADataGridViewTextBoxColumn.DataPropertyName = "DESMARCA"
        Me.DESMARCADataGridViewTextBoxColumn.HeaderText = "Marca"
        Me.DESMARCADataGridViewTextBoxColumn.Name = "DESMARCADataGridViewTextBoxColumn"
        Me.DESMARCADataGridViewTextBoxColumn.ReadOnly = True
        Me.DESMARCADataGridViewTextBoxColumn.Width = 150
        '
        'TblGridComprasBindingSource
        '
        Me.TblGridComprasBindingSource.DataMember = "tblGridCompras"
        Me.TblGridComprasBindingSource.DataSource = Me.DS_VENTAS2
        '
        'TimerColor
        '
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(15, 204)
        Me.LabelControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(44, 16)
        Me.LabelControl1.TabIndex = 306
        Me.LabelControl1.Text = "Código:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(15, 247)
        Me.LabelControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(70, 16)
        Me.LabelControl2.TabIndex = 307
        Me.LabelControl2.Text = "Descripción:"
        '
        'viewCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.DGV_ListadoProductosCompras)
        Me.Controls.Add(Me.LabelControl83)
        Me.Controls.Add(Me.cmbComprasBodega)
        Me.Controls.Add(Me.cmbComprasTipoProd)
        Me.Controls.Add(Me.cmbComprasDiasCredito)
        Me.Controls.Add(Me.lbComprasVencimiento)
        Me.Controls.Add(Me.txtComprasFechaVence)
        Me.Controls.Add(Me.LabelControl57)
        Me.Controls.Add(Me.txtComprasObs)
        Me.Controls.Add(Me.btnComprasTomarDatos)
        Me.Controls.Add(Me.LabelControl25)
        Me.Controls.Add(Me.cmbComprasConCre)
        Me.Controls.Add(Me.LabelControl24)
        Me.Controls.Add(Me.cmbComprasVendedor)
        Me.Controls.Add(Me.cmdComprasBuscarProveedor)
        Me.Controls.Add(Me.cmbComprasProveedor)
        Me.Controls.Add(Me.txtComprasNitProveedor)
        Me.Controls.Add(Me.txtComprasNombreProveedor)
        Me.Controls.Add(Me.LabelControl56)
        Me.Controls.Add(Me.LabelControl46)
        Me.Controls.Add(Me.txtComprasNoFac)
        Me.Controls.Add(Me.LabelControl45)
        Me.Controls.Add(Me.txtComprasSerieFac)
        Me.Controls.Add(Me.LabelControl37)
        Me.Controls.Add(Me.lbTotalCompra)
        Me.Controls.Add(Me.LabelControl36)
        Me.Controls.Add(Me.GridTempProductosCompras)
        Me.Controls.Add(Me.lbTituloCompras)
        Me.Controls.Add(Me.cmdComprasGuardar)
        Me.Controls.Add(Me.txtComprasCodProducto)
        Me.Controls.Add(Me.txtComprasFiltro)
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.txtComprasFecha)
        Me.Controls.Add(Me.txtComprasCorrelativo)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "viewCompras"
        Me.Size = New System.Drawing.Size(1493, 833)
        CType(Me.txtComprasFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprasFechaVence.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbComprasProveedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprasNitProveedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprasNombreProveedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTempProductosCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileViewTempProductosCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_VENTAS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprasFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprasFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtComprasCorrelativo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_ListadoProductosCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblGridComprasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents LabelControl83 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbComprasBodega As ComboBox
    Friend WithEvents cmbComprasTipoProd As ComboBox
    Friend WithEvents cmbComprasDiasCredito As ComboBox
    Friend WithEvents lbComprasVencimiento As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComprasFechaVence As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl57 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComprasObs As TextBox
    Friend WithEvents btnComprasTomarDatos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl25 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbComprasConCre As ComboBox
    Friend WithEvents LabelControl24 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbComprasVendedor As ComboBox
    Friend WithEvents cmdComprasBuscarProveedor As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmbComprasProveedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtComprasNitProveedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtComprasNombreProveedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl56 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl46 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComprasNoFac As TextBox
    Friend WithEvents LabelControl45 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComprasSerieFac As TextBox
    Friend WithEvents LabelControl37 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalCompra As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl36 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridTempProductosCompras As DevExpress.XtraGrid.GridControl
    Friend WithEvents TileViewTempProductosCompras As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents lbTituloCompras As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdComprasGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtComprasCodProducto As TextBox
    Friend WithEvents txtComprasFiltro As TextBox
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtComprasFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtComprasCorrelativo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DS_VENTAS2 As DS_VENTAS2
    Friend WithEvents DGV_ListadoProductosCompras As DataGridView
    Friend WithEvents TimerColor As Timer
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CODCLAUNODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESCLAUNODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODCLADOSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESCLADOSDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EXISTENCIADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PRECIOQDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TblGridComprasBindingSource As BindingSource
    Friend WithEvents CODPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODPROD2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESPROD2DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESPROD3DataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SALDODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EQUIVALEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMARCADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESMARCADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
