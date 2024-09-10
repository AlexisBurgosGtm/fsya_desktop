<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewTras
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TileViewItemElement1 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement2 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement3 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement4 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement5 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement6 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement7 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Dim TileViewItemElement8 As DevExpress.XtraGrid.Views.Tile.TileViewItemElement = New DevExpress.XtraGrid.Views.Tile.TileViewItemElement()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbtipovencidos = New System.Windows.Forms.ComboBox()
        Me.LabelControl130 = New DevExpress.XtraEditors.LabelControl()
        Me.CheckBoxOBJ2 = New System.Windows.Forms.CheckBox()
        Me.CheckBoxOBJ1 = New System.Windows.Forms.CheckBox()
        Me.DGVMovInvListado = New System.Windows.Forms.DataGridView()
        Me.CODPROD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQUIVALEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXISTENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMARCADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblTrasladosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DS_VENTAS2 = New Ares.DS_VENTAS2()
        Me.LabelControl84 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMovinvBodega = New System.Windows.Forms.ComboBox()
        Me.LabelControl27 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbSerieMovInv = New System.Windows.Forms.ComboBox()
        Me.LabelControl179 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMovInvObs = New System.Windows.Forms.TextBox()
        Me.LabelControl169 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl166 = New DevExpress.XtraEditors.LabelControl()
        Me.LbMovInvTotalPrecio = New DevExpress.XtraEditors.LabelControl()
        Me.LbMovInvTotalCosto = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl167 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl168 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMovInvTipo = New DevExpress.XtraEditors.LabelControl()
        Me.cmdMovInvGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdMovInvFiltroMarca = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl137 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMovInvCodProd = New System.Windows.Forms.TextBox()
        Me.LabelControl138 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl140 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMovInvFecha = New DevExpress.XtraEditors.DateEdit()
        Me.txtMovInvCorrelativo = New DevExpress.XtraEditors.TextEdit()
        Me.txtMovInvFiltro = New System.Windows.Forms.TextBox()
        Me.GridTempMovInv = New DevExpress.XtraGrid.GridControl()
        Me.TileViewTempMovInv = New DevExpress.XtraGrid.Views.Tile.TileView()
        Me.TimerColor = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DGVMovInvListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTrasladosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_VENTAS2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMovInvFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMovInvFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMovInvCorrelativo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTempMovInv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TileViewTempMovInv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LabelControl10.Location = New System.Drawing.Point(401, 78)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(161, 16)
        Me.LabelControl10.TabIndex = 217
        Me.LabelControl10.Text = "Razon de salida a Vencidos:"
        '
        'cmbtipovencidos
        '
        Me.cmbtipovencidos.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.cmbtipovencidos.FormattingEnabled = True
        Me.cmbtipovencidos.Items.AddRange(New Object() {"VENCIDOS", "COMPRA HÉCTOR GARCIA", "COMPRA SERGIO GARCIA", "COMPRA FRANCISCO DIAZ", "USO DE SUCURSAL", "MAL ESTADO", "PRECIO ELEVADO", "SOBRANTE PROVEEDOR"})
        Me.cmbtipovencidos.Location = New System.Drawing.Point(401, 101)
        Me.cmbtipovencidos.Name = "cmbtipovencidos"
        Me.cmbtipovencidos.Size = New System.Drawing.Size(235, 24)
        Me.cmbtipovencidos.TabIndex = 216
        '
        'LabelControl130
        '
        Me.LabelControl130.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.LabelControl130.Location = New System.Drawing.Point(401, 29)
        Me.LabelControl130.Name = "LabelControl130"
        Me.LabelControl130.Size = New System.Drawing.Size(52, 16)
        Me.LabelControl130.TabIndex = 215
        Me.LabelControl130.Text = "Objetivo:"
        '
        'CheckBoxOBJ2
        '
        Me.CheckBoxOBJ2.AutoSize = True
        Me.CheckBoxOBJ2.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.CheckBoxOBJ2.Location = New System.Drawing.Point(531, 52)
        Me.CheckBoxOBJ2.Name = "CheckBoxOBJ2"
        Me.CheckBoxOBJ2.Size = New System.Drawing.Size(95, 21)
        Me.CheckBoxOBJ2.TabIndex = 214
        Me.CheckBoxOBJ2.Text = "TRASLADO"
        Me.CheckBoxOBJ2.UseVisualStyleBackColor = True
        '
        'CheckBoxOBJ1
        '
        Me.CheckBoxOBJ1.AutoSize = True
        Me.CheckBoxOBJ1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.CheckBoxOBJ1.Location = New System.Drawing.Point(401, 51)
        Me.CheckBoxOBJ1.Name = "CheckBoxOBJ1"
        Me.CheckBoxOBJ1.Size = New System.Drawing.Size(124, 21)
        Me.CheckBoxOBJ1.TabIndex = 213
        Me.CheckBoxOBJ1.Text = "COMPLEMENTO"
        Me.CheckBoxOBJ1.UseVisualStyleBackColor = True
        '
        'DGVMovInvListado
        '
        Me.DGVMovInvListado.AllowUserToAddRows = False
        Me.DGVMovInvListado.AllowUserToDeleteRows = False
        Me.DGVMovInvListado.AllowUserToOrderColumns = True
        Me.DGVMovInvListado.AutoGenerateColumns = False
        Me.DGVMovInvListado.BackgroundColor = System.Drawing.Color.White
        Me.DGVMovInvListado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVMovInvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVMovInvListado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPROD, Me.DESPRODDataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn, Me.EQUIVALEDataGridViewTextBoxColumn, Me.EXISTENCIA, Me.COSTO, Me.PRECIODataGridViewTextBoxColumn, Me.DESMARCADataGridViewTextBoxColumn})
        Me.DGVMovInvListado.DataSource = Me.TblTrasladosBindingSource
        Me.DGVMovInvListado.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DGVMovInvListado.Location = New System.Drawing.Point(3, 231)
        Me.DGVMovInvListado.MultiSelect = False
        Me.DGVMovInvListado.Name = "DGVMovInvListado"
        Me.DGVMovInvListado.ReadOnly = True
        Me.DGVMovInvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVMovInvListado.Size = New System.Drawing.Size(909, 443)
        Me.DGVMovInvListado.TabIndex = 212
        '
        'CODPROD
        '
        Me.CODPROD.DataPropertyName = "CODPROD"
        Me.CODPROD.HeaderText = "CodProd"
        Me.CODPROD.Name = "CODPROD"
        Me.CODPROD.ReadOnly = True
        '
        'DESPRODDataGridViewTextBoxColumn
        '
        Me.DESPRODDataGridViewTextBoxColumn.DataPropertyName = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.FillWeight = 320.0!
        Me.DESPRODDataGridViewTextBoxColumn.HeaderText = "DesProd"
        Me.DESPRODDataGridViewTextBoxColumn.Name = "DESPRODDataGridViewTextBoxColumn"
        Me.DESPRODDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPRODDataGridViewTextBoxColumn.Width = 320
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
        Me.EQUIVALEDataGridViewTextBoxColumn.FillWeight = 60.0!
        Me.EQUIVALEDataGridViewTextBoxColumn.HeaderText = "EQ"
        Me.EQUIVALEDataGridViewTextBoxColumn.Name = "EQUIVALEDataGridViewTextBoxColumn"
        Me.EQUIVALEDataGridViewTextBoxColumn.ReadOnly = True
        Me.EQUIVALEDataGridViewTextBoxColumn.Width = 60
        '
        'EXISTENCIA
        '
        Me.EXISTENCIA.DataPropertyName = "EXISTENCIA"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.EXISTENCIA.DefaultCellStyle = DataGridViewCellStyle1
        Me.EXISTENCIA.FillWeight = 60.0!
        Me.EXISTENCIA.HeaderText = "Saldo"
        Me.EXISTENCIA.Name = "EXISTENCIA"
        Me.EXISTENCIA.ReadOnly = True
        Me.EXISTENCIA.Width = 60
        '
        'COSTO
        '
        Me.COSTO.DataPropertyName = "COSTO"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "Q 0.00"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.COSTO.DefaultCellStyle = DataGridViewCellStyle2
        Me.COSTO.FillWeight = 70.0!
        Me.COSTO.HeaderText = "Costo"
        Me.COSTO.Name = "COSTO"
        Me.COSTO.ReadOnly = True
        Me.COSTO.Width = 70
        '
        'PRECIODataGridViewTextBoxColumn
        '
        Me.PRECIODataGridViewTextBoxColumn.DataPropertyName = "PRECIO"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle3.Format = "Q 0.00"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.PRECIODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.PRECIODataGridViewTextBoxColumn.FillWeight = 70.0!
        Me.PRECIODataGridViewTextBoxColumn.HeaderText = "Precio"
        Me.PRECIODataGridViewTextBoxColumn.Name = "PRECIODataGridViewTextBoxColumn"
        Me.PRECIODataGridViewTextBoxColumn.ReadOnly = True
        Me.PRECIODataGridViewTextBoxColumn.Width = 70
        '
        'DESMARCADataGridViewTextBoxColumn
        '
        Me.DESMARCADataGridViewTextBoxColumn.DataPropertyName = "DESMARCA"
        Me.DESMARCADataGridViewTextBoxColumn.FillWeight = 200.0!
        Me.DESMARCADataGridViewTextBoxColumn.HeaderText = "Marca"
        Me.DESMARCADataGridViewTextBoxColumn.Name = "DESMARCADataGridViewTextBoxColumn"
        Me.DESMARCADataGridViewTextBoxColumn.ReadOnly = True
        Me.DESMARCADataGridViewTextBoxColumn.Width = 200
        '
        'TblTrasladosBindingSource
        '
        Me.TblTrasladosBindingSource.DataMember = "tblTraslados"
        Me.TblTrasladosBindingSource.DataSource = Me.DS_VENTAS2
        '
        'DS_VENTAS2
        '
        Me.DS_VENTAS2.DataSetName = "DS_VENTAS2"
        Me.DS_VENTAS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LabelControl84
        '
        Me.LabelControl84.Location = New System.Drawing.Point(651, 708)
        Me.LabelControl84.Name = "LabelControl84"
        Me.LabelControl84.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl84.TabIndex = 211
        Me.LabelControl84.Text = "Bodega:"
        Me.LabelControl84.Visible = False
        '
        'cmbMovinvBodega
        '
        Me.cmbMovinvBodega.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMovinvBodega.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMovinvBodega.FormattingEnabled = True
        Me.cmbMovinvBodega.Location = New System.Drawing.Point(698, 705)
        Me.cmbMovinvBodega.Name = "cmbMovinvBodega"
        Me.cmbMovinvBodega.Size = New System.Drawing.Size(131, 21)
        Me.cmbMovinvBodega.TabIndex = 210
        Me.cmbMovinvBodega.Visible = False
        '
        'LabelControl27
        '
        Me.LabelControl27.Location = New System.Drawing.Point(34, 101)
        Me.LabelControl27.Name = "LabelControl27"
        Me.LabelControl27.Size = New System.Drawing.Size(28, 13)
        Me.LabelControl27.TabIndex = 209
        Me.LabelControl27.Text = "Serie:"
        '
        'cmbSerieMovInv
        '
        Me.cmbSerieMovInv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSerieMovInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbSerieMovInv.FormattingEnabled = True
        Me.cmbSerieMovInv.Location = New System.Drawing.Point(85, 98)
        Me.cmbSerieMovInv.Name = "cmbSerieMovInv"
        Me.cmbSerieMovInv.Size = New System.Drawing.Size(132, 21)
        Me.cmbSerieMovInv.TabIndex = 208
        '
        'LabelControl179
        '
        Me.LabelControl179.Location = New System.Drawing.Point(349, 138)
        Me.LabelControl179.Name = "LabelControl179"
        Me.LabelControl179.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl179.TabIndex = 205
        Me.LabelControl179.Text = "Observaciones:"
        '
        'txtMovInvObs
        '
        Me.txtMovInvObs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovInvObs.Location = New System.Drawing.Point(349, 157)
        Me.txtMovInvObs.MaxLength = 250
        Me.txtMovInvObs.Multiline = True
        Me.txtMovInvObs.Name = "txtMovInvObs"
        Me.txtMovInvObs.Size = New System.Drawing.Size(452, 41)
        Me.txtMovInvObs.TabIndex = 206
        '
        'LabelControl169
        '
        Me.LabelControl169.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl169.Location = New System.Drawing.Point(1065, 22)
        Me.LabelControl169.Name = "LabelControl169"
        Me.LabelControl169.Size = New System.Drawing.Size(73, 16)
        Me.LabelControl169.TabIndex = 204
        Me.LabelControl169.Text = "Total Precio:"
        '
        'LabelControl166
        '
        Me.LabelControl166.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl166.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl166.Location = New System.Drawing.Point(1144, 16)
        Me.LabelControl166.Name = "LabelControl166"
        Me.LabelControl166.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl166.TabIndex = 203
        Me.LabelControl166.Text = "Q"
        '
        'LbMovInvTotalPrecio
        '
        Me.LbMovInvTotalPrecio.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbMovInvTotalPrecio.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbMovInvTotalPrecio.Location = New System.Drawing.Point(1166, 16)
        Me.LbMovInvTotalPrecio.Name = "LbMovInvTotalPrecio"
        Me.LbMovInvTotalPrecio.Size = New System.Drawing.Size(105, 25)
        Me.LbMovInvTotalPrecio.TabIndex = 202
        Me.LbMovInvTotalPrecio.Text = "10,000.00"
        '
        'LbMovInvTotalCosto
        '
        Me.LbMovInvTotalCosto.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbMovInvTotalCosto.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbMovInvTotalCosto.Location = New System.Drawing.Point(926, 16)
        Me.LbMovInvTotalCosto.Name = "LbMovInvTotalCosto"
        Me.LbMovInvTotalCosto.Size = New System.Drawing.Size(105, 25)
        Me.LbMovInvTotalCosto.TabIndex = 201
        Me.LbMovInvTotalCosto.Text = "10,000.00"
        Me.LbMovInvTotalCosto.Visible = False
        '
        'LabelControl167
        '
        Me.LabelControl167.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl167.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl167.Location = New System.Drawing.Point(904, 16)
        Me.LabelControl167.Name = "LabelControl167"
        Me.LabelControl167.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl167.TabIndex = 200
        Me.LabelControl167.Text = "Q"
        Me.LabelControl167.Visible = False
        '
        'LabelControl168
        '
        Me.LabelControl168.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl168.Location = New System.Drawing.Point(828, 22)
        Me.LabelControl168.Name = "LabelControl168"
        Me.LabelControl168.Size = New System.Drawing.Size(70, 16)
        Me.LabelControl168.TabIndex = 199
        Me.LabelControl168.Text = "Total Costo:"
        Me.LabelControl168.Visible = False
        '
        'txtMovInvTipo
        '
        Me.txtMovInvTipo.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovInvTipo.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.txtMovInvTipo.Location = New System.Drawing.Point(63, 8)
        Me.txtMovInvTipo.Name = "txtMovInvTipo"
        Me.txtMovInvTipo.Size = New System.Drawing.Size(257, 33)
        Me.txtMovInvTipo.TabIndex = 188
        Me.txtMovInvTipo.Text = "Ingreso de Inventario"
        '
        'cmdMovInvGuardar
        '
        Me.cmdMovInvGuardar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdMovInvGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMovInvGuardar.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdMovInvGuardar.Appearance.Options.UseBackColor = True
        Me.cmdMovInvGuardar.Appearance.Options.UseFont = True
        Me.cmdMovInvGuardar.Appearance.Options.UseForeColor = True
        Me.cmdMovInvGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdMovInvGuardar.Location = New System.Drawing.Point(743, 64)
        Me.cmdMovInvGuardar.Name = "cmdMovInvGuardar"
        Me.cmdMovInvGuardar.Size = New System.Drawing.Size(84, 31)
        Me.cmdMovInvGuardar.TabIndex = 198
        Me.cmdMovInvGuardar.Text = "Guardar "
        '
        'cmdMovInvFiltroMarca
        '
        Me.cmdMovInvFiltroMarca.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdMovInvFiltroMarca.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMovInvFiltroMarca.Appearance.ForeColor = System.Drawing.Color.White
        Me.cmdMovInvFiltroMarca.Appearance.Options.UseBackColor = True
        Me.cmdMovInvFiltroMarca.Appearance.Options.UseFont = True
        Me.cmdMovInvFiltroMarca.Appearance.Options.UseForeColor = True
        Me.cmdMovInvFiltroMarca.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdMovInvFiltroMarca.Location = New System.Drawing.Point(349, 203)
        Me.cmdMovInvFiltroMarca.Name = "cmdMovInvFiltroMarca"
        Me.cmdMovInvFiltroMarca.Size = New System.Drawing.Size(89, 21)
        Me.cmdMovInvFiltroMarca.TabIndex = 197
        Me.cmdMovInvFiltroMarca.Text = "Por Marca F1"
        '
        'LabelControl137
        '
        Me.LabelControl137.Location = New System.Drawing.Point(22, 161)
        Me.LabelControl137.Name = "LabelControl137"
        Me.LabelControl137.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl137.TabIndex = 187
        Me.LabelControl137.Text = "Código:"
        '
        'txtMovInvCodProd
        '
        Me.txtMovInvCodProd.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtMovInvCodProd.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovInvCodProd.Location = New System.Drawing.Point(63, 156)
        Me.txtMovInvCodProd.Name = "txtMovInvCodProd"
        Me.txtMovInvCodProd.Size = New System.Drawing.Size(261, 27)
        Me.txtMovInvCodProd.TabIndex = 192
        '
        'LabelControl138
        '
        Me.LabelControl138.Location = New System.Drawing.Point(22, 206)
        Me.LabelControl138.Name = "LabelControl138"
        Me.LabelControl138.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl138.TabIndex = 186
        Me.LabelControl138.Text = "Buscar:"
        '
        'LabelControl140
        '
        Me.LabelControl140.Location = New System.Drawing.Point(34, 74)
        Me.LabelControl140.Name = "LabelControl140"
        Me.LabelControl140.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl140.TabIndex = 185
        Me.LabelControl140.Text = "Fecha:"
        '
        'txtMovInvFecha
        '
        Me.txtMovInvFecha.EditValue = Nothing
        Me.txtMovInvFecha.Location = New System.Drawing.Point(85, 69)
        Me.txtMovInvFecha.Name = "txtMovInvFecha"
        Me.txtMovInvFecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovInvFecha.Properties.Appearance.Options.UseFont = True
        Me.txtMovInvFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtMovInvFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtMovInvFecha.Size = New System.Drawing.Size(223, 22)
        Me.txtMovInvFecha.TabIndex = 190
        '
        'txtMovInvCorrelativo
        '
        Me.txtMovInvCorrelativo.Enabled = False
        Me.txtMovInvCorrelativo.Location = New System.Drawing.Point(223, 99)
        Me.txtMovInvCorrelativo.Name = "txtMovInvCorrelativo"
        Me.txtMovInvCorrelativo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovInvCorrelativo.Properties.Appearance.Options.UseFont = True
        Me.txtMovInvCorrelativo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtMovInvCorrelativo.Size = New System.Drawing.Size(85, 20)
        Me.txtMovInvCorrelativo.TabIndex = 191
        '
        'txtMovInvFiltro
        '
        Me.txtMovInvFiltro.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMovInvFiltro.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMovInvFiltro.Location = New System.Drawing.Point(64, 197)
        Me.txtMovInvFiltro.Name = "txtMovInvFiltro"
        Me.txtMovInvFiltro.Size = New System.Drawing.Size(260, 27)
        Me.txtMovInvFiltro.TabIndex = 193
        '
        'GridTempMovInv
        '
        Me.GridTempMovInv.Location = New System.Drawing.Point(918, 52)
        Me.GridTempMovInv.MainView = Me.TileViewTempMovInv
        Me.GridTempMovInv.Name = "GridTempMovInv"
        Me.GridTempMovInv.Size = New System.Drawing.Size(353, 622)
        Me.GridTempMovInv.TabIndex = 184
        Me.GridTempMovInv.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.TileViewTempMovInv})
        '
        'TileViewTempMovInv
        '
        Me.TileViewTempMovInv.GridControl = Me.GridTempMovInv
        Me.TileViewTempMovInv.Name = "TileViewTempMovInv"
        Me.TileViewTempMovInv.OptionsFind.AlwaysVisible = True
        Me.TileViewTempMovInv.OptionsFind.FindNullPrompt = "Escriba para buscar..."
        Me.TileViewTempMovInv.OptionsTiles.ColumnCount = 1
        Me.TileViewTempMovInv.OptionsTiles.ItemSize = New System.Drawing.Size(248, 130)
        Me.TileViewTempMovInv.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileViewTempMovInv.OptionsTiles.RowCount = 50
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
        TileViewItemElement3.TextLocation = New System.Drawing.Point(130, 80)
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
        TileViewItemElement7.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement7.Appearance.Normal.Options.UseFont = True
        TileViewItemElement7.Text = "MEDIA DOCENA"
        TileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement7.TextLocation = New System.Drawing.Point(0, 95)
        TileViewItemElement8.Appearance.Normal.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TileViewItemElement8.Appearance.Normal.Options.UseFont = True
        TileViewItemElement8.Text = "Q 100.00"
        TileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual
        TileViewItemElement8.TextLocation = New System.Drawing.Point(145, 60)
        TileViewItemElement8.UseImageInTransition = False
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement1)
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement2)
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement3)
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement4)
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement5)
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement6)
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement7)
        Me.TileViewTempMovInv.TileTemplate.Add(TileViewItemElement8)
        '
        'TimerColor
        '
        '
        'viewTras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.cmbtipovencidos)
        Me.Controls.Add(Me.LabelControl130)
        Me.Controls.Add(Me.CheckBoxOBJ2)
        Me.Controls.Add(Me.CheckBoxOBJ1)
        Me.Controls.Add(Me.DGVMovInvListado)
        Me.Controls.Add(Me.LabelControl84)
        Me.Controls.Add(Me.cmbMovinvBodega)
        Me.Controls.Add(Me.LabelControl27)
        Me.Controls.Add(Me.cmbSerieMovInv)
        Me.Controls.Add(Me.LabelControl179)
        Me.Controls.Add(Me.txtMovInvObs)
        Me.Controls.Add(Me.LabelControl169)
        Me.Controls.Add(Me.LabelControl166)
        Me.Controls.Add(Me.LbMovInvTotalPrecio)
        Me.Controls.Add(Me.LbMovInvTotalCosto)
        Me.Controls.Add(Me.LabelControl167)
        Me.Controls.Add(Me.LabelControl168)
        Me.Controls.Add(Me.txtMovInvTipo)
        Me.Controls.Add(Me.cmdMovInvGuardar)
        Me.Controls.Add(Me.cmdMovInvFiltroMarca)
        Me.Controls.Add(Me.LabelControl137)
        Me.Controls.Add(Me.txtMovInvCodProd)
        Me.Controls.Add(Me.LabelControl138)
        Me.Controls.Add(Me.LabelControl140)
        Me.Controls.Add(Me.txtMovInvFecha)
        Me.Controls.Add(Me.txtMovInvCorrelativo)
        Me.Controls.Add(Me.txtMovInvFiltro)
        Me.Controls.Add(Me.GridTempMovInv)
        Me.Name = "viewTras"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.DGVMovInvListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTrasladosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_VENTAS2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMovInvFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMovInvFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMovInvCorrelativo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTempMovInv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TileViewTempMovInv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbtipovencidos As ComboBox
    Friend WithEvents LabelControl130 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CheckBoxOBJ2 As CheckBox
    Friend WithEvents CheckBoxOBJ1 As CheckBox
    Friend WithEvents DGVMovInvListado As DataGridView
    Friend WithEvents LabelControl84 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbMovinvBodega As ComboBox
    Friend WithEvents LabelControl27 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbSerieMovInv As ComboBox
    Friend WithEvents LabelControl179 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMovInvObs As TextBox
    Friend WithEvents LabelControl169 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl166 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbMovInvTotalPrecio As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbMovInvTotalCosto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl167 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl168 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMovInvTipo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdMovInvGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdMovInvFiltroMarca As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl137 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMovInvCodProd As TextBox
    Friend WithEvents LabelControl138 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl140 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMovInvFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtMovInvCorrelativo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMovInvFiltro As TextBox
    Friend WithEvents GridTempMovInv As DevExpress.XtraGrid.GridControl
    Friend WithEvents TileViewTempMovInv As DevExpress.XtraGrid.Views.Tile.TileView
    Friend WithEvents TblTrasladosBindingSource As BindingSource
    Friend WithEvents DS_VENTAS2 As DS_VENTAS2
    Friend WithEvents TimerColor As Timer
    Friend WithEvents CODPROD As DataGridViewTextBoxColumn
    Friend WithEvents DESPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EQUIVALEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EXISTENCIA As DataGridViewTextBoxColumn
    Friend WithEvents COSTO As DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESMARCADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
