<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POS))
        Me.cmdPOSBuscarProd = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl176 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbPOSVendedor = New System.Windows.Forms.ComboBox()
        Me.txtPOSNomClie = New DevExpress.XtraEditors.TextEdit()
        Me.txtPOSCodClie = New DevExpress.XtraEditors.TextEdit()
        Me.txtPOSNit = New DevExpress.XtraEditors.TextEdit()
        Me.cmdPOSBuscarCliente = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl175 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl174 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdPOSTomarDatos = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl223 = New DevExpress.XtraEditors.LabelControl()
        Me.DgvPOStempVenta = New System.Windows.Forms.DataGridView()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EQUIVALEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALUNIDADESDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UTILIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALCOSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALPRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BONIFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALBONIFDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblTempVentaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASDataSet = New Ares.VENTASDataSet()
        Me.cmdPOSGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LbPOSTotalCosto = New DevExpress.XtraEditors.LabelControl()
        Me.LbPOSTotalVenta = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl219 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl222 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl220 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPOSCorrelativo = New DevExpress.XtraEditors.TextEdit()
        Me.txtPOSCodprod = New System.Windows.Forms.TextBox()
        Me.txtPOSFecha = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl221 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.txtPOSNomClie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOSCodClie.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOSNit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPOStempVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTempVentaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOSCorrelativo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOSFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPOSFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPOSBuscarProd
        '
        Me.cmdPOSBuscarProd.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPOSBuscarProd.Appearance.Options.UseFont = True
        Me.cmdPOSBuscarProd.Image = CType(resources.GetObject("cmdPOSBuscarProd.Image"), System.Drawing.Image)
        Me.cmdPOSBuscarProd.Location = New System.Drawing.Point(666, 189)
        Me.cmdPOSBuscarProd.Name = "cmdPOSBuscarProd"
        Me.cmdPOSBuscarProd.Size = New System.Drawing.Size(66, 44)
        Me.cmdPOSBuscarProd.TabIndex = 210
        Me.cmdPOSBuscarProd.Text = "Buscar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "F1"
        '
        'GroupControl6
        '
        Me.GroupControl6.AppearanceCaption.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupControl6.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.GroupControl6.AppearanceCaption.Options.UseFont = True
        Me.GroupControl6.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl6.Controls.Add(Me.LabelControl176)
        Me.GroupControl6.Controls.Add(Me.cmbPOSVendedor)
        Me.GroupControl6.Controls.Add(Me.txtPOSNomClie)
        Me.GroupControl6.Controls.Add(Me.txtPOSCodClie)
        Me.GroupControl6.Controls.Add(Me.txtPOSNit)
        Me.GroupControl6.Controls.Add(Me.cmdPOSBuscarCliente)
        Me.GroupControl6.Controls.Add(Me.LabelControl175)
        Me.GroupControl6.Controls.Add(Me.LabelControl174)
        Me.GroupControl6.Controls.Add(Me.cmdPOSTomarDatos)
        Me.GroupControl6.Location = New System.Drawing.Point(39, 83)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(334, 168)
        Me.GroupControl6.TabIndex = 209
        Me.GroupControl6.Text = "Datos de la Venta"
        '
        'LabelControl176
        '
        Me.LabelControl176.Location = New System.Drawing.Point(21, 36)
        Me.LabelControl176.Name = "LabelControl176"
        Me.LabelControl176.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl176.TabIndex = 182
        Me.LabelControl176.Text = "Vendedor:"
        '
        'cmbPOSVendedor
        '
        Me.cmbPOSVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPOSVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPOSVendedor.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPOSVendedor.FormattingEnabled = True
        Me.cmbPOSVendedor.Location = New System.Drawing.Point(77, 34)
        Me.cmbPOSVendedor.Name = "cmbPOSVendedor"
        Me.cmbPOSVendedor.Size = New System.Drawing.Size(227, 24)
        Me.cmbPOSVendedor.TabIndex = 175
        '
        'txtPOSNomClie
        '
        Me.txtPOSNomClie.Location = New System.Drawing.Point(77, 97)
        Me.txtPOSNomClie.Name = "txtPOSNomClie"
        Me.txtPOSNomClie.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSNomClie.Properties.Appearance.Options.UseFont = True
        Me.txtPOSNomClie.Size = New System.Drawing.Size(227, 22)
        Me.txtPOSNomClie.TabIndex = 183
        '
        'txtPOSCodClie
        '
        Me.txtPOSCodClie.Location = New System.Drawing.Point(8, 73)
        Me.txtPOSCodClie.Name = "txtPOSCodClie"
        Me.txtPOSCodClie.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSCodClie.Properties.Appearance.Options.UseFont = True
        Me.txtPOSCodClie.Size = New System.Drawing.Size(19, 22)
        Me.txtPOSCodClie.TabIndex = 190
        Me.txtPOSCodClie.Visible = False
        '
        'txtPOSNit
        '
        Me.txtPOSNit.Location = New System.Drawing.Point(77, 66)
        Me.txtPOSNit.Name = "txtPOSNit"
        Me.txtPOSNit.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSNit.Properties.Appearance.Options.UseFont = True
        Me.txtPOSNit.Size = New System.Drawing.Size(154, 22)
        Me.txtPOSNit.TabIndex = 184
        '
        'cmdPOSBuscarCliente
        '
        Me.cmdPOSBuscarCliente.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPOSBuscarCliente.Appearance.Options.UseFont = True
        Me.cmdPOSBuscarCliente.Image = CType(resources.GetObject("cmdPOSBuscarCliente.Image"), System.Drawing.Image)
        Me.cmdPOSBuscarCliente.Location = New System.Drawing.Point(246, 65)
        Me.cmdPOSBuscarCliente.Name = "cmdPOSBuscarCliente"
        Me.cmdPOSBuscarCliente.Size = New System.Drawing.Size(58, 23)
        Me.cmdPOSBuscarCliente.TabIndex = 189
        Me.cmdPOSBuscarCliente.Text = "Buscar"
        '
        'LabelControl175
        '
        Me.LabelControl175.Location = New System.Drawing.Point(32, 69)
        Me.LabelControl175.Name = "LabelControl175"
        Me.LabelControl175.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl175.TabIndex = 185
        Me.LabelControl175.Text = "NIT:"
        '
        'LabelControl174
        '
        Me.LabelControl174.Location = New System.Drawing.Point(32, 101)
        Me.LabelControl174.Name = "LabelControl174"
        Me.LabelControl174.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl174.TabIndex = 186
        Me.LabelControl174.Text = "Cliente:"
        '
        'cmdPOSTomarDatos
        '
        Me.cmdPOSTomarDatos.Appearance.BackColor = System.Drawing.Color.Peru
        Me.cmdPOSTomarDatos.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPOSTomarDatos.Appearance.ForeColor = System.Drawing.Color.DimGray
        Me.cmdPOSTomarDatos.Appearance.Options.UseBackColor = True
        Me.cmdPOSTomarDatos.Appearance.Options.UseFont = True
        Me.cmdPOSTomarDatos.Appearance.Options.UseForeColor = True
        Me.cmdPOSTomarDatos.Image = CType(resources.GetObject("cmdPOSTomarDatos.Image"), System.Drawing.Image)
        Me.cmdPOSTomarDatos.Location = New System.Drawing.Point(213, 130)
        Me.cmdPOSTomarDatos.Name = "cmdPOSTomarDatos"
        Me.cmdPOSTomarDatos.Size = New System.Drawing.Size(108, 28)
        Me.cmdPOSTomarDatos.TabIndex = 206
        Me.cmdPOSTomarDatos.TabStop = False
        Me.cmdPOSTomarDatos.Text = "Tomar Datos F7"
        '
        'LabelControl223
        '
        Me.LabelControl223.Appearance.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl223.Location = New System.Drawing.Point(751, 10)
        Me.LabelControl223.Name = "LabelControl223"
        Me.LabelControl223.Size = New System.Drawing.Size(28, 45)
        Me.LabelControl223.TabIndex = 208
        Me.LabelControl223.Text = "Q"
        '
        'DgvPOStempVenta
        '
        Me.DgvPOStempVenta.AllowUserToAddRows = False
        Me.DgvPOStempVenta.AllowUserToDeleteRows = False
        Me.DgvPOStempVenta.AllowUserToOrderColumns = True
        Me.DgvPOStempVenta.AutoGenerateColumns = False
        Me.DgvPOStempVenta.BackgroundColor = System.Drawing.Color.White
        Me.DgvPOStempVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvPOStempVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPOStempVenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.CODPRODDataGridViewTextBoxColumn, Me.DESPRODDataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn, Me.EQUIVALEDataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.TOTALUNIDADESDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn, Me.PRECIODataGridViewTextBoxColumn, Me.UTILIDADDataGridViewTextBoxColumn, Me.TOTALCOSTODataGridViewTextBoxColumn, Me.TOTALPRECIODataGridViewTextBoxColumn, Me.BONIFDataGridViewTextBoxColumn, Me.TOTALBONIFDataGridViewTextBoxColumn})
        Me.DgvPOStempVenta.DataSource = Me.TblTempVentaBindingSource
        Me.DgvPOStempVenta.GridColor = System.Drawing.Color.LightSkyBlue
        Me.DgvPOStempVenta.Location = New System.Drawing.Point(33, 260)
        Me.DgvPOStempVenta.Name = "DgvPOStempVenta"
        Me.DgvPOStempVenta.ReadOnly = True
        Me.DgvPOStempVenta.RowTemplate.Height = 25
        Me.DgvPOStempVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPOStempVenta.Size = New System.Drawing.Size(951, 393)
        Me.DgvPOStempVenta.TabIndex = 207
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'CODPRODDataGridViewTextBoxColumn
        '
        Me.CODPRODDataGridViewTextBoxColumn.DataPropertyName = "CODPROD"
        Me.CODPRODDataGridViewTextBoxColumn.HeaderText = "CODIGO"
        Me.CODPRODDataGridViewTextBoxColumn.Name = "CODPRODDataGridViewTextBoxColumn"
        Me.CODPRODDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPRODDataGridViewTextBoxColumn.Width = 140
        '
        'DESPRODDataGridViewTextBoxColumn
        '
        Me.DESPRODDataGridViewTextBoxColumn.DataPropertyName = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION"
        Me.DESPRODDataGridViewTextBoxColumn.Name = "DESPRODDataGridViewTextBoxColumn"
        Me.DESPRODDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPRODDataGridViewTextBoxColumn.Width = 300
        '
        'CODMEDIDADataGridViewTextBoxColumn
        '
        Me.CODMEDIDADataGridViewTextBoxColumn.DataPropertyName = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.HeaderText = "MEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.Name = "CODMEDIDADataGridViewTextBoxColumn"
        Me.CODMEDIDADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODMEDIDADataGridViewTextBoxColumn.Width = 110
        '
        'EQUIVALEDataGridViewTextBoxColumn
        '
        Me.EQUIVALEDataGridViewTextBoxColumn.DataPropertyName = "EQUIVALE"
        Me.EQUIVALEDataGridViewTextBoxColumn.HeaderText = "EQUIVALE"
        Me.EQUIVALEDataGridViewTextBoxColumn.Name = "EQUIVALEDataGridViewTextBoxColumn"
        Me.EQUIVALEDataGridViewTextBoxColumn.ReadOnly = True
        Me.EQUIVALEDataGridViewTextBoxColumn.Visible = False
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TOTALUNIDADESDataGridViewTextBoxColumn
        '
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.DataPropertyName = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.HeaderText = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.Name = "TOTALUNIDADESDataGridViewTextBoxColumn"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.Visible = False
        '
        'COSTODataGridViewTextBoxColumn
        '
        Me.COSTODataGridViewTextBoxColumn.DataPropertyName = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.HeaderText = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.Name = "COSTODataGridViewTextBoxColumn"
        Me.COSTODataGridViewTextBoxColumn.ReadOnly = True
        Me.COSTODataGridViewTextBoxColumn.Visible = False
        '
        'PRECIODataGridViewTextBoxColumn
        '
        Me.PRECIODataGridViewTextBoxColumn.DataPropertyName = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn.HeaderText = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn.Name = "PRECIODataGridViewTextBoxColumn"
        Me.PRECIODataGridViewTextBoxColumn.ReadOnly = True
        Me.PRECIODataGridViewTextBoxColumn.Width = 120
        '
        'UTILIDADDataGridViewTextBoxColumn
        '
        Me.UTILIDADDataGridViewTextBoxColumn.DataPropertyName = "UTILIDAD"
        Me.UTILIDADDataGridViewTextBoxColumn.HeaderText = "UTILIDAD"
        Me.UTILIDADDataGridViewTextBoxColumn.Name = "UTILIDADDataGridViewTextBoxColumn"
        Me.UTILIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.UTILIDADDataGridViewTextBoxColumn.Visible = False
        '
        'TOTALCOSTODataGridViewTextBoxColumn
        '
        Me.TOTALCOSTODataGridViewTextBoxColumn.DataPropertyName = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.HeaderText = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.Name = "TOTALCOSTODataGridViewTextBoxColumn"
        Me.TOTALCOSTODataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALCOSTODataGridViewTextBoxColumn.Visible = False
        '
        'TOTALPRECIODataGridViewTextBoxColumn
        '
        Me.TOTALPRECIODataGridViewTextBoxColumn.DataPropertyName = "TOTALPRECIO"
        Me.TOTALPRECIODataGridViewTextBoxColumn.HeaderText = "IMPORTE"
        Me.TOTALPRECIODataGridViewTextBoxColumn.Name = "TOTALPRECIODataGridViewTextBoxColumn"
        Me.TOTALPRECIODataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALPRECIODataGridViewTextBoxColumn.Width = 120
        '
        'BONIFDataGridViewTextBoxColumn
        '
        Me.BONIFDataGridViewTextBoxColumn.DataPropertyName = "BONIF"
        Me.BONIFDataGridViewTextBoxColumn.HeaderText = "BONIF"
        Me.BONIFDataGridViewTextBoxColumn.Name = "BONIFDataGridViewTextBoxColumn"
        Me.BONIFDataGridViewTextBoxColumn.ReadOnly = True
        Me.BONIFDataGridViewTextBoxColumn.Visible = False
        '
        'TOTALBONIFDataGridViewTextBoxColumn
        '
        Me.TOTALBONIFDataGridViewTextBoxColumn.DataPropertyName = "TOTALBONIF"
        Me.TOTALBONIFDataGridViewTextBoxColumn.HeaderText = "TOTALBONIF"
        Me.TOTALBONIFDataGridViewTextBoxColumn.Name = "TOTALBONIFDataGridViewTextBoxColumn"
        Me.TOTALBONIFDataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALBONIFDataGridViewTextBoxColumn.Visible = False
        '
        'TblTempVentaBindingSource
        '
        Me.TblTempVentaBindingSource.DataMember = "tblTempVenta"
        Me.TblTempVentaBindingSource.DataSource = Me.VENTASDataSetBindingSource
        '
        'VENTASDataSetBindingSource
        '
        Me.VENTASDataSetBindingSource.DataSource = Me.VENTASDataSet
        Me.VENTASDataSetBindingSource.Position = 0
        '
        'VENTASDataSet
        '
        Me.VENTASDataSet.DataSetName = "VENTASDataSet"
        Me.VENTASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdPOSGuardar
        '
        Me.cmdPOSGuardar.Appearance.BackColor = System.Drawing.Color.White
        Me.cmdPOSGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPOSGuardar.Appearance.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.cmdPOSGuardar.Appearance.Options.UseBackColor = True
        Me.cmdPOSGuardar.Appearance.Options.UseFont = True
        Me.cmdPOSGuardar.Appearance.Options.UseForeColor = True
        Me.cmdPOSGuardar.Image = Global.Ares.My.Resources.Resources.btsave1
        Me.cmdPOSGuardar.Location = New System.Drawing.Point(802, 145)
        Me.cmdPOSGuardar.Name = "cmdPOSGuardar"
        Me.cmdPOSGuardar.Size = New System.Drawing.Size(182, 83)
        Me.cmdPOSGuardar.TabIndex = 205
        Me.cmdPOSGuardar.Text = "COBRAR" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "F5"
        '
        'LbPOSTotalCosto
        '
        Me.LbPOSTotalCosto.Appearance.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPOSTotalCosto.Location = New System.Drawing.Point(683, 35)
        Me.LbPOSTotalCosto.Name = "LbPOSTotalCosto"
        Me.LbPOSTotalCosto.Size = New System.Drawing.Size(18, 35)
        Me.LbPOSTotalCosto.TabIndex = 204
        Me.LbPOSTotalCosto.Text = "0"
        Me.LbPOSTotalCosto.Visible = False
        '
        'LbPOSTotalVenta
        '
        Me.LbPOSTotalVenta.Appearance.Font = New System.Drawing.Font("Tahoma", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbPOSTotalVenta.Location = New System.Drawing.Point(785, 11)
        Me.LbPOSTotalVenta.Name = "LbPOSTotalVenta"
        Me.LbPOSTotalVenta.Size = New System.Drawing.Size(216, 45)
        Me.LbPOSTotalVenta.TabIndex = 203
        Me.LbPOSTotalVenta.Text = "100,000.00"
        '
        'LabelControl219
        '
        Me.LabelControl219.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl219.Location = New System.Drawing.Point(661, 19)
        Me.LabelControl219.Name = "LabelControl219"
        Me.LabelControl219.Size = New System.Drawing.Size(71, 16)
        Me.LabelControl219.TabIndex = 202
        Me.LabelControl219.Text = "Total Venta:"
        '
        'LabelControl222
        '
        Me.LabelControl222.Location = New System.Drawing.Point(163, 54)
        Me.LabelControl222.Name = "LabelControl222"
        Me.LabelControl222.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl222.TabIndex = 198
        Me.LabelControl222.Text = "Fecha:"
        '
        'LabelControl220
        '
        Me.LabelControl220.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl220.Location = New System.Drawing.Point(389, 173)
        Me.LabelControl220.Name = "LabelControl220"
        Me.LabelControl220.Size = New System.Drawing.Size(119, 16)
        Me.LabelControl220.TabIndex = 201
        Me.LabelControl220.Text = "Código del Producto:"
        '
        'txtPOSCorrelativo
        '
        Me.txtPOSCorrelativo.Enabled = False
        Me.txtPOSCorrelativo.Location = New System.Drawing.Point(224, 14)
        Me.txtPOSCorrelativo.Name = "txtPOSCorrelativo"
        Me.txtPOSCorrelativo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSCorrelativo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPOSCorrelativo.Properties.Appearance.Options.UseFont = True
        Me.txtPOSCorrelativo.Properties.Appearance.Options.UseForeColor = True
        Me.txtPOSCorrelativo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.txtPOSCorrelativo.Size = New System.Drawing.Size(149, 28)
        Me.txtPOSCorrelativo.TabIndex = 196
        '
        'txtPOSCodprod
        '
        Me.txtPOSCodprod.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtPOSCodprod.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSCodprod.Location = New System.Drawing.Point(389, 198)
        Me.txtPOSCodprod.Name = "txtPOSCodprod"
        Me.txtPOSCodprod.Size = New System.Drawing.Size(271, 30)
        Me.txtPOSCodprod.TabIndex = 200
        '
        'txtPOSFecha
        '
        Me.txtPOSFecha.EditValue = Nothing
        Me.txtPOSFecha.Location = New System.Drawing.Point(224, 51)
        Me.txtPOSFecha.Name = "txtPOSFecha"
        Me.txtPOSFecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOSFecha.Properties.Appearance.Options.UseFont = True
        Me.txtPOSFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPOSFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPOSFecha.Size = New System.Drawing.Size(139, 22)
        Me.txtPOSFecha.TabIndex = 197
        '
        'LabelControl221
        '
        Me.LabelControl221.Location = New System.Drawing.Point(163, 19)
        Me.LabelControl221.Name = "LabelControl221"
        Me.LabelControl221.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl221.TabIndex = 199
        Me.LabelControl221.Text = "Venta No."
        '
        'POS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdPOSBuscarProd)
        Me.Controls.Add(Me.GroupControl6)
        Me.Controls.Add(Me.LabelControl223)
        Me.Controls.Add(Me.DgvPOStempVenta)
        Me.Controls.Add(Me.cmdPOSGuardar)
        Me.Controls.Add(Me.LbPOSTotalCosto)
        Me.Controls.Add(Me.LbPOSTotalVenta)
        Me.Controls.Add(Me.LabelControl219)
        Me.Controls.Add(Me.LabelControl222)
        Me.Controls.Add(Me.LabelControl220)
        Me.Controls.Add(Me.txtPOSCorrelativo)
        Me.Controls.Add(Me.txtPOSCodprod)
        Me.Controls.Add(Me.txtPOSFecha)
        Me.Controls.Add(Me.LabelControl221)
        Me.Name = "POS"
        Me.Size = New System.Drawing.Size(1024, 672)
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        Me.GroupControl6.PerformLayout()
        CType(Me.txtPOSNomClie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOSCodClie.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOSNit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPOStempVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTempVentaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOSCorrelativo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOSFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPOSFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdPOSBuscarProd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl176 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbPOSVendedor As ComboBox
    Friend WithEvents txtPOSNomClie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPOSCodClie As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPOSNit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdPOSBuscarCliente As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl175 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl174 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl223 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DgvPOStempVenta As DataGridView
    Friend WithEvents cmdPOSGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LbPOSTotalCosto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbPOSTotalVenta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl219 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdPOSTomarDatos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl222 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl220 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPOSCorrelativo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPOSCodprod As TextBox
    Friend WithEvents txtPOSFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl221 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblTempVentaBindingSource As BindingSource
    Friend WithEvents VENTASDataSetBindingSource As BindingSource
    Friend WithEvents VENTASDataSet As VENTASDataSet
    Friend WithEvents IDDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EQUIVALEDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALUNIDADESDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UTILIDADDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALCOSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALPRECIODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BONIFDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALBONIFDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
