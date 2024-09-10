<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewOrdenProduccion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewOrdenProduccion))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DgwMateriaPrima = New System.Windows.Forms.DataGridView()
        Me.CODPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALUNIDADESDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALCOSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblRecetaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOS = New Ares.DSPRODUCTOS()
        Me.gridProducir = New DevExpress.XtraGrid.GridControl()
        Me.TblProductosFabricadosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewProducir = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQUIVALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.lbDesprod = New DevExpress.XtraEditors.LabelControl()
        Me.lbCodmedida = New DevExpress.XtraEditors.LabelControl()
        Me.btnAgregarProduccion = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAgregarProductoProducir = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCoddoc = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCorrelativo = New DevExpress.XtraEditors.LabelControl()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalCosto = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalVenta = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbEmpleado = New System.Windows.Forms.ComboBox()
        CType(Me.DgwMateriaPrima, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblRecetaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridProducir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProductosFabricadosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProducir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(88, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(199, 23)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Orden de Producción"
        '
        'DgwMateriaPrima
        '
        Me.DgwMateriaPrima.AutoGenerateColumns = False
        Me.DgwMateriaPrima.BackgroundColor = System.Drawing.Color.White
        Me.DgwMateriaPrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgwMateriaPrima.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPRODDataGridViewTextBoxColumn, Me.DESPRODDataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.TOTALUNIDADESDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn, Me.TOTALCOSTODataGridViewTextBoxColumn})
        Me.DgwMateriaPrima.DataSource = Me.TblRecetaBindingSource
        Me.DgwMateriaPrima.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgwMateriaPrima.Location = New System.Drawing.Point(2, 20)
        Me.DgwMateriaPrima.Name = "DgwMateriaPrima"
        Me.DgwMateriaPrima.Size = New System.Drawing.Size(524, 394)
        Me.DgwMateriaPrima.TabIndex = 5
        '
        'CODPRODDataGridViewTextBoxColumn
        '
        Me.CODPRODDataGridViewTextBoxColumn.DataPropertyName = "CODPROD"
        Me.CODPRODDataGridViewTextBoxColumn.HeaderText = "CODIGO"
        Me.CODPRODDataGridViewTextBoxColumn.Name = "CODPRODDataGridViewTextBoxColumn"
        '
        'DESPRODDataGridViewTextBoxColumn
        '
        Me.DESPRODDataGridViewTextBoxColumn.DataPropertyName = "DESPROD"
        Me.DESPRODDataGridViewTextBoxColumn.HeaderText = "PRODUCTO"
        Me.DESPRODDataGridViewTextBoxColumn.Name = "DESPRODDataGridViewTextBoxColumn"
        Me.DESPRODDataGridViewTextBoxColumn.Width = 200
        '
        'CODMEDIDADataGridViewTextBoxColumn
        '
        Me.CODMEDIDADataGridViewTextBoxColumn.DataPropertyName = "CODMEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.HeaderText = "MEDIDA"
        Me.CODMEDIDADataGridViewTextBoxColumn.Name = "CODMEDIDADataGridViewTextBoxColumn"
        Me.CODMEDIDADataGridViewTextBoxColumn.Width = 70
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.Width = 60
        '
        'TOTALUNIDADESDataGridViewTextBoxColumn
        '
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.DataPropertyName = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.HeaderText = "TOTALUNIDADES"
        Me.TOTALUNIDADESDataGridViewTextBoxColumn.Name = "TOTALUNIDADESDataGridViewTextBoxColumn"
        '
        'COSTODataGridViewTextBoxColumn
        '
        Me.COSTODataGridViewTextBoxColumn.DataPropertyName = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.HeaderText = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.Name = "COSTODataGridViewTextBoxColumn"
        Me.COSTODataGridViewTextBoxColumn.Visible = False
        '
        'TOTALCOSTODataGridViewTextBoxColumn
        '
        Me.TOTALCOSTODataGridViewTextBoxColumn.DataPropertyName = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.HeaderText = "TOTALCOSTO"
        Me.TOTALCOSTODataGridViewTextBoxColumn.Name = "TOTALCOSTODataGridViewTextBoxColumn"
        Me.TOTALCOSTODataGridViewTextBoxColumn.Visible = False
        '
        'TblRecetaBindingSource
        '
        Me.TblRecetaBindingSource.DataMember = "tblReceta"
        Me.TblRecetaBindingSource.DataSource = Me.DSPRODUCTOS
        '
        'DSPRODUCTOS
        '
        Me.DSPRODUCTOS.DataSetName = "DSPRODUCTOS"
        Me.DSPRODUCTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'gridProducir
        '
        Me.gridProducir.DataSource = Me.TblProductosFabricadosBindingSource
        Me.gridProducir.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProducir.Location = New System.Drawing.Point(2, 20)
        Me.gridProducir.MainView = Me.GridViewProducir
        Me.gridProducir.Name = "gridProducir"
        Me.gridProducir.Size = New System.Drawing.Size(485, 394)
        Me.gridProducir.TabIndex = 6
        Me.gridProducir.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProducir})
        '
        'TblProductosFabricadosBindingSource
        '
        Me.TblProductosFabricadosBindingSource.DataMember = "tblProductosFabricados"
        Me.TblProductosFabricadosBindingSource.DataSource = Me.DSPRODUCTOS
        '
        'GridViewProducir
        '
        Me.GridViewProducir.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colCODMEDIDA, Me.colEQUIVALE, Me.colCOSTO, Me.colPRECIO})
        Me.GridViewProducir.GridControl = Me.gridProducir
        Me.GridViewProducir.Name = "GridViewProducir"
        Me.GridViewProducir.OptionsBehavior.Editable = False
        Me.GridViewProducir.OptionsView.ShowGroupPanel = False
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "CODIGO"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 74
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "PRODUCTO"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 228
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.Caption = "MEDIDA"
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 2
        Me.colCODMEDIDA.Width = 68
        '
        'colEQUIVALE
        '
        Me.colEQUIVALE.Caption = "CANT"
        Me.colEQUIVALE.FieldName = "EQUIVALE"
        Me.colEQUIVALE.Name = "colEQUIVALE"
        Me.colEQUIVALE.Visible = True
        Me.colEQUIVALE.VisibleIndex = 3
        Me.colEQUIVALE.Width = 61
        '
        'colCOSTO
        '
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.DgwMateriaPrima)
        Me.GroupControl1.Location = New System.Drawing.Point(13, 192)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(528, 416)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "Materiales a usarse para la Producción"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.gridProducir)
        Me.GroupControl2.Location = New System.Drawing.Point(549, 193)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(489, 416)
        Me.GroupControl2.TabIndex = 8
        Me.GroupControl2.Text = "Productos a Producir // Doble clic para eliminar un item"
        '
        'btnGuardar
        '
        Me.btnGuardar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnGuardar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnGuardar.Appearance.Options.UseBackColor = True
        Me.btnGuardar.Appearance.Options.UseForeColor = True
        Me.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(885, 38)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(136, 52)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "GUARDAR"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(721, 38)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(136, 52)
        Me.btnCancelar.TabIndex = 11
        Me.btnCancelar.Text = "CANCELAR"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(875, 150)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtCantidad.Properties.Mask.EditMask = "n0"
        Me.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCantidad.Size = New System.Drawing.Size(80, 30)
        Me.txtCantidad.TabIndex = 12
        '
        'lbDesprod
        '
        Me.lbDesprod.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesprod.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbDesprod.Location = New System.Drawing.Point(581, 147)
        Me.lbDesprod.Name = "lbDesprod"
        Me.lbDesprod.Size = New System.Drawing.Size(10, 14)
        Me.lbDesprod.TabIndex = 13
        Me.lbDesprod.Text = "--"
        '
        'lbCodmedida
        '
        Me.lbCodmedida.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodmedida.Appearance.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbCodmedida.Location = New System.Drawing.Point(581, 173)
        Me.lbCodmedida.Name = "lbCodmedida"
        Me.lbCodmedida.Size = New System.Drawing.Size(10, 14)
        Me.lbCodmedida.TabIndex = 14
        Me.lbCodmedida.Text = "--"
        '
        'btnAgregarProduccion
        '
        Me.btnAgregarProduccion.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAgregarProduccion.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAgregarProduccion.Appearance.Options.UseBackColor = True
        Me.btnAgregarProduccion.Appearance.Options.UseForeColor = True
        Me.btnAgregarProduccion.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAgregarProduccion.Image = CType(resources.GetObject("btnAgregarProduccion.Image"), System.Drawing.Image)
        Me.btnAgregarProduccion.Location = New System.Drawing.Point(484, 146)
        Me.btnAgregarProduccion.Name = "btnAgregarProduccion"
        Me.btnAgregarProduccion.Size = New System.Drawing.Size(81, 41)
        Me.btnAgregarProduccion.TabIndex = 9
        Me.btnAgregarProduccion.Text = "Buscar(F3)"
        '
        'btnAgregarProductoProducir
        '
        Me.btnAgregarProductoProducir.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAgregarProductoProducir.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAgregarProductoProducir.Appearance.Options.UseBackColor = True
        Me.btnAgregarProductoProducir.Appearance.Options.UseForeColor = True
        Me.btnAgregarProductoProducir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAgregarProductoProducir.Image = CType(resources.GetObject("btnAgregarProductoProducir.Image"), System.Drawing.Image)
        Me.btnAgregarProductoProducir.Location = New System.Drawing.Point(961, 148)
        Me.btnAgregarProductoProducir.Name = "btnAgregarProductoProducir"
        Me.btnAgregarProductoProducir.Size = New System.Drawing.Size(77, 33)
        Me.btnAgregarProductoProducir.TabIndex = 15
        Me.btnAgregarProductoProducir.Text = "Agregar"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(877, 133)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl2.TabIndex = 16
        Me.LabelControl2.Text = "Cantidad"
        '
        'cmbCoddoc
        '
        Me.cmbCoddoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCoddoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCoddoc.FormattingEnabled = True
        Me.cmbCoddoc.Location = New System.Drawing.Point(168, 42)
        Me.cmbCoddoc.Name = "cmbCoddoc"
        Me.cmbCoddoc.Size = New System.Drawing.Size(136, 21)
        Me.cmbCoddoc.TabIndex = 17
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(101, 44)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl3.TabIndex = 18
        Me.LabelControl3.Text = "Documento:"
        '
        'lbCorrelativo
        '
        Me.lbCorrelativo.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrelativo.Location = New System.Drawing.Point(315, 43)
        Me.lbCorrelativo.Name = "lbCorrelativo"
        Me.lbCorrelativo.Size = New System.Drawing.Size(30, 19)
        Me.lbCorrelativo.TabIndex = 19
        Me.lbCorrelativo.Text = "000"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(168, 68)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(121, 20)
        Me.txtFecha.TabIndex = 20
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(104, 71)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl4.TabIndex = 21
        Me.LabelControl4.Text = "Fecha:"
        '
        'lbTotalCosto
        '
        Me.lbTotalCosto.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalCosto.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalCosto.Location = New System.Drawing.Point(283, 146)
        Me.lbTotalCosto.Name = "lbTotalCosto"
        Me.lbTotalCosto.Size = New System.Drawing.Size(156, 25)
        Me.lbTotalCosto.TabIndex = 22
        Me.lbTotalCosto.Text = "000000000000"
        Me.lbTotalCosto.Visible = False
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl6.Location = New System.Drawing.Point(261, 146)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl6.TabIndex = 23
        Me.LabelControl6.Text = "Q"
        Me.LabelControl6.Visible = False
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl5.Location = New System.Drawing.Point(51, 146)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl5.TabIndex = 25
        Me.LabelControl5.Text = "Q"
        Me.LabelControl5.Visible = False
        '
        'lbTotalVenta
        '
        Me.lbTotalVenta.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalVenta.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalVenta.Location = New System.Drawing.Point(73, 146)
        Me.lbTotalVenta.Name = "lbTotalVenta"
        Me.lbTotalVenta.Size = New System.Drawing.Size(156, 25)
        Me.lbTotalVenta.TabIndex = 24
        Me.lbTotalVenta.Text = "000000000000"
        Me.lbTotalVenta.Visible = False
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(51, 129)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(71, 13)
        Me.LabelControl8.TabIndex = 26
        Me.LabelControl8.Text = "TOTAL VENTA:"
        Me.LabelControl8.Visible = False
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(261, 129)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(74, 13)
        Me.LabelControl9.TabIndex = 27
        Me.LabelControl9.Text = "TOTAL COSTO:"
        Me.LabelControl9.Visible = False
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(419, 54)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(209, 41)
        Me.txtObs.TabIndex = 28
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(419, 38)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl7.TabIndex = 29
        Me.LabelControl7.Text = "Observaciones:"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(101, 96)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl10.TabIndex = 31
        Me.LabelControl10.Text = "Empleado:"
        '
        'cmbEmpleado
        '
        Me.cmbEmpleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmpleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmpleado.FormattingEnabled = True
        Me.cmbEmpleado.Location = New System.Drawing.Point(168, 94)
        Me.cmbEmpleado.Name = "cmbEmpleado"
        Me.cmbEmpleado.Size = New System.Drawing.Size(209, 21)
        Me.cmbEmpleado.TabIndex = 30
        '
        'viewOrdenProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl10)
        Me.Controls.Add(Me.cmbEmpleado)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.txtObs)
        Me.Controls.Add(Me.LabelControl9)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.lbTotalVenta)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.lbTotalCosto)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtFecha)
        Me.Controls.Add(Me.lbCorrelativo)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cmbCoddoc)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnAgregarProductoProducir)
        Me.Controls.Add(Me.lbCodmedida)
        Me.Controls.Add(Me.lbDesprod)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnAgregarProduccion)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewOrdenProduccion"
        Me.Size = New System.Drawing.Size(1047, 665)
        CType(Me.DgwMateriaPrima, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblRecetaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridProducir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProductosFabricadosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProducir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents DgwMateriaPrima As DataGridView
    Friend WithEvents gridProducir As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProducir As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbDesprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCodmedida As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAgregarProduccion As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAgregarProductoProducir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblProductosFabricadosBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOS As DSPRODUCTOS
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQUIVALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbCoddoc As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCorrelativo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents CODPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents DESPRODDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALUNIDADESDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TOTALCOSTODataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TblRecetaBindingSource As BindingSource
    Friend WithEvents lbTotalCosto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalVenta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As TextBox
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbEmpleado As ComboBox
End Class
