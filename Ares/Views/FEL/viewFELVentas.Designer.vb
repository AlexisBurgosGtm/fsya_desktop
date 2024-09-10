<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewFELVentas
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gridDetalleFactura = New DevExpress.XtraGrid.GridControl()
        Me.TblTempVentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSFEL = New Ares.DSFEL()
        Me.GridViewDetalleFactura = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQUIVALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCANTIDAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALUNIDADES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTOUNITARIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIVA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIOSINIVA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIOSINIVA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTIPOPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.txtBuscarDesprod = New DevExpress.XtraEditors.TextEdit()
        Me.txtBuscarCodprod = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoFactura = New System.Windows.Forms.ComboBox()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCoddoc = New System.Windows.Forms.ComboBox()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbConCre = New System.Windows.Forms.ComboBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipProd = New System.Windows.Forms.ComboBox()
        Me.cmbTipoPrecio = New System.Windows.Forms.ComboBox()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.TextEdit5 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit4 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit3 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gridDetalleFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTempVentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSFEL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetalleFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtBuscarDesprod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBuscarCodprod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(96, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(202, 25)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Factura Electrónica"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.gridDetalleFactura)
        Me.GroupControl1.Location = New System.Drawing.Point(15, 310)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1012, 357)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Detalle de Productos Agregados a la Factura"
        '
        'gridDetalleFactura
        '
        Me.gridDetalleFactura.DataSource = Me.TblTempVentasBindingSource
        Me.gridDetalleFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDetalleFactura.Location = New System.Drawing.Point(2, 20)
        Me.gridDetalleFactura.MainView = Me.GridViewDetalleFactura
        Me.gridDetalleFactura.Name = "gridDetalleFactura"
        Me.gridDetalleFactura.Size = New System.Drawing.Size(1008, 335)
        Me.gridDetalleFactura.TabIndex = 4
        Me.gridDetalleFactura.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetalleFactura})
        '
        'TblTempVentasBindingSource
        '
        Me.TblTempVentasBindingSource.DataMember = "tblTempVentas"
        Me.TblTempVentasBindingSource.DataSource = Me.DSFEL
        '
        'DSFEL
        '
        Me.DSFEL.DataSetName = "DSFEL"
        Me.DSFEL.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewDetalleFactura
        '
        Me.GridViewDetalleFactura.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colCODMEDIDA, Me.colEQUIVALE, Me.colCANTIDAD, Me.colTOTALUNIDADES, Me.colCOSTOUNITARIO, Me.colCOSTO, Me.colTOTALCOSTO, Me.colPRECIO, Me.colTOTALPRECIO, Me.colIVA, Me.colPRECIOSINIVA, Me.colTOTALPRECIOSINIVA, Me.colTIPOPROD, Me.colEXENTO})
        Me.GridViewDetalleFactura.GridControl = Me.gridDetalleFactura
        Me.GridViewDetalleFactura.Name = "GridViewDetalleFactura"
        Me.GridViewDetalleFactura.OptionsBehavior.Editable = False
        Me.GridViewDetalleFactura.OptionsView.ShowAutoFilterRow = True
        Me.GridViewDetalleFactura.OptionsView.ShowGroupPanel = False
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 175
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "PRODUCTO"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 331
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.Caption = "MEDIDA"
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 2
        Me.colCODMEDIDA.Width = 112
        '
        'colEQUIVALE
        '
        Me.colEQUIVALE.FieldName = "EQUIVALE"
        Me.colEQUIVALE.Name = "colEQUIVALE"
        '
        'colCANTIDAD
        '
        Me.colCANTIDAD.FieldName = "CANTIDAD"
        Me.colCANTIDAD.Name = "colCANTIDAD"
        Me.colCANTIDAD.Visible = True
        Me.colCANTIDAD.VisibleIndex = 3
        Me.colCANTIDAD.Width = 88
        '
        'colTOTALUNIDADES
        '
        Me.colTOTALUNIDADES.FieldName = "TOTALUNIDADES"
        Me.colTOTALUNIDADES.Name = "colTOTALUNIDADES"
        '
        'colCOSTOUNITARIO
        '
        Me.colCOSTOUNITARIO.FieldName = "COSTOUNITARIO"
        Me.colCOSTOUNITARIO.Name = "colCOSTOUNITARIO"
        '
        'colCOSTO
        '
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        '
        'colTOTALCOSTO
        '
        Me.colTOTALCOSTO.FieldName = "TOTALCOSTO"
        Me.colTOTALCOSTO.Name = "colTOTALCOSTO"
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 4
        Me.colPRECIO.Width = 80
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 5
        Me.colTOTALPRECIO.Width = 107
        '
        'colIVA
        '
        Me.colIVA.FieldName = "IVA"
        Me.colIVA.Name = "colIVA"
        '
        'colPRECIOSINIVA
        '
        Me.colPRECIOSINIVA.FieldName = "PRECIOSINIVA"
        Me.colPRECIOSINIVA.Name = "colPRECIOSINIVA"
        '
        'colTOTALPRECIOSINIVA
        '
        Me.colTOTALPRECIOSINIVA.FieldName = "TOTALPRECIOSINIVA"
        Me.colTOTALPRECIOSINIVA.Name = "colTOTALPRECIOSINIVA"
        '
        'colTIPOPROD
        '
        Me.colTIPOPROD.Caption = "TIPO"
        Me.colTIPOPROD.FieldName = "TIPOPROD"
        Me.colTIPOPROD.Name = "colTIPOPROD"
        Me.colTIPOPROD.Visible = True
        Me.colTIPOPROD.VisibleIndex = 6
        Me.colTIPOPROD.Width = 97
        '
        'colEXENTO
        '
        Me.colEXENTO.FieldName = "EXENTO"
        Me.colEXENTO.Name = "colEXENTO"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.LabelControl11)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.LabelControl10)
        Me.GroupControl2.Controls.Add(Me.LabelControl9)
        Me.GroupControl2.Location = New System.Drawing.Point(702, 79)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(325, 145)
        Me.GroupControl2.TabIndex = 3
        Me.GroupControl2.Text = "Totales del Documento"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl11.Location = New System.Drawing.Point(132, 66)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(180, 18)
        Me.LabelControl11.TabIndex = 18
        Me.LabelControl11.Text = "000000000000000000"
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl14.Location = New System.Drawing.Point(110, 66)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(12, 18)
        Me.LabelControl14.TabIndex = 17
        Me.LabelControl14.Text = "Q"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl13.Location = New System.Drawing.Point(110, 34)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(12, 18)
        Me.LabelControl13.TabIndex = 16
        Me.LabelControl13.Text = "Q"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(5, 68)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(80, 16)
        Me.LabelControl12.TabIndex = 15
        Me.LabelControl12.Text = "Total Sin IVA:"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl10.Location = New System.Drawing.Point(132, 35)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(180, 18)
        Me.LabelControl10.TabIndex = 14
        Me.LabelControl10.Text = "000000000000000000"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(5, 34)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(81, 16)
        Me.LabelControl9.TabIndex = 13
        Me.LabelControl9.Text = "Total Factura:"
        '
        'txtBuscarDesprod
        '
        Me.txtBuscarDesprod.Location = New System.Drawing.Point(399, 30)
        Me.txtBuscarDesprod.Name = "txtBuscarDesprod"
        Me.txtBuscarDesprod.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscarDesprod.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarDesprod.Properties.Appearance.Options.UseBackColor = True
        Me.txtBuscarDesprod.Properties.Appearance.Options.UseFont = True
        Me.txtBuscarDesprod.Size = New System.Drawing.Size(246, 30)
        Me.txtBuscarDesprod.TabIndex = 4
        '
        'txtBuscarCodprod
        '
        Me.txtBuscarCodprod.Location = New System.Drawing.Point(79, 30)
        Me.txtBuscarCodprod.Name = "txtBuscarCodprod"
        Me.txtBuscarCodprod.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscarCodprod.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarCodprod.Properties.Appearance.Options.UseBackColor = True
        Me.txtBuscarCodprod.Properties.Appearance.Options.UseFont = True
        Me.txtBuscarCodprod.Size = New System.Drawing.Size(198, 30)
        Me.txtBuscarCodprod.TabIndex = 5
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(17, 33)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(56, 19)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Código:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(295, 33)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(87, 19)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Descripción:"
        '
        'cmbTipoFactura
        '
        Me.cmbTipoFactura.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoFactura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoFactura.FormattingEnabled = True
        Me.cmbTipoFactura.Items.AddRange(New Object() {"NORMAL", "CAMBIARIA", "ESPECIAL"})
        Me.cmbTipoFactura.Location = New System.Drawing.Point(200, 53)
        Me.cmbTipoFactura.Name = "cmbTipoFactura"
        Me.cmbTipoFactura.Size = New System.Drawing.Size(136, 21)
        Me.cmbTipoFactura.TabIndex = 8
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(96, 51)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(94, 19)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Tipo Factura:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(14, 28)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(39, 16)
        Me.LabelControl5.TabIndex = 11
        Me.LabelControl5.Text = "Serie: "
        '
        'cmbCoddoc
        '
        Me.cmbCoddoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCoddoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCoddoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCoddoc.FormattingEnabled = True
        Me.cmbCoddoc.Location = New System.Drawing.Point(75, 27)
        Me.cmbCoddoc.Name = "cmbCoddoc"
        Me.cmbCoddoc.Size = New System.Drawing.Size(210, 21)
        Me.cmbCoddoc.TabIndex = 10
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.LabelControl8)
        Me.GroupControl3.Controls.Add(Me.cmbConCre)
        Me.GroupControl3.Controls.Add(Me.LabelControl7)
        Me.GroupControl3.Controls.Add(Me.LabelControl6)
        Me.GroupControl3.Controls.Add(Me.LabelControl5)
        Me.GroupControl3.Controls.Add(Me.cmbCoddoc)
        Me.GroupControl3.Location = New System.Drawing.Point(377, 79)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(319, 145)
        Me.GroupControl3.TabIndex = 12
        Me.GroupControl3.Text = "Datos del Documento"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(14, 87)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(92, 16)
        Me.LabelControl8.TabIndex = 15
        Me.LabelControl8.Text = "Condición pago:"
        '
        'cmbConCre
        '
        Me.cmbConCre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbConCre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbConCre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConCre.FormattingEnabled = True
        Me.cmbConCre.Location = New System.Drawing.Point(123, 86)
        Me.cmbConCre.Name = "cmbConCre"
        Me.cmbConCre.Size = New System.Drawing.Size(162, 21)
        Me.cmbConCre.TabIndex = 14
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl7.Location = New System.Drawing.Point(75, 56)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(210, 18)
        Me.LabelControl7.TabIndex = 13
        Me.LabelControl7.Text = "000000000000000000000"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(14, 56)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Número:"
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.LabelControl19)
        Me.GroupControl4.Controls.Add(Me.LabelControl18)
        Me.GroupControl4.Controls.Add(Me.cmbTipProd)
        Me.GroupControl4.Controls.Add(Me.cmbTipoPrecio)
        Me.GroupControl4.Controls.Add(Me.LabelControl2)
        Me.GroupControl4.Controls.Add(Me.txtBuscarDesprod)
        Me.GroupControl4.Controls.Add(Me.txtBuscarCodprod)
        Me.GroupControl4.Controls.Add(Me.LabelControl3)
        Me.GroupControl4.Location = New System.Drawing.Point(15, 232)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(1012, 70)
        Me.GroupControl4.TabIndex = 13
        Me.GroupControl4.Text = "Búsqueda de Productos:"
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Location = New System.Drawing.Point(865, 22)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(79, 16)
        Me.LabelControl19.TabIndex = 15
        Me.LabelControl19.Text = "Tipo Producto"
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Location = New System.Drawing.Point(718, 22)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(64, 16)
        Me.LabelControl18.TabIndex = 14
        Me.LabelControl18.Text = "Tipo Precio"
        '
        'cmbTipProd
        '
        Me.cmbTipProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipProd.FormattingEnabled = True
        Me.cmbTipProd.Location = New System.Drawing.Point(865, 43)
        Me.cmbTipProd.Name = "cmbTipProd"
        Me.cmbTipProd.Size = New System.Drawing.Size(118, 21)
        Me.cmbTipProd.TabIndex = 12
        '
        'cmbTipoPrecio
        '
        Me.cmbTipoPrecio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoPrecio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPrecio.FormattingEnabled = True
        Me.cmbTipoPrecio.Location = New System.Drawing.Point(718, 43)
        Me.cmbTipoPrecio.Name = "cmbTipoPrecio"
        Me.cmbTipoPrecio.Size = New System.Drawing.Size(132, 21)
        Me.cmbTipoPrecio.TabIndex = 10
        '
        'GroupControl5
        '
        Me.GroupControl5.Controls.Add(Me.TextEdit5)
        Me.GroupControl5.Controls.Add(Me.TextEdit4)
        Me.GroupControl5.Controls.Add(Me.TextEdit3)
        Me.GroupControl5.Controls.Add(Me.LabelControl17)
        Me.GroupControl5.Controls.Add(Me.LabelControl16)
        Me.GroupControl5.Controls.Add(Me.LabelControl15)
        Me.GroupControl5.Location = New System.Drawing.Point(17, 79)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(354, 145)
        Me.GroupControl5.TabIndex = 14
        Me.GroupControl5.Text = "Datos del Cliente"
        '
        'TextEdit5
        '
        Me.TextEdit5.Location = New System.Drawing.Point(81, 103)
        Me.TextEdit5.Name = "TextEdit5"
        Me.TextEdit5.Size = New System.Drawing.Size(243, 20)
        Me.TextEdit5.TabIndex = 17
        '
        'TextEdit4
        '
        Me.TextEdit4.Location = New System.Drawing.Point(79, 67)
        Me.TextEdit4.Name = "TextEdit4"
        Me.TextEdit4.Size = New System.Drawing.Size(243, 20)
        Me.TextEdit4.TabIndex = 16
        '
        'TextEdit3
        '
        Me.TextEdit3.Location = New System.Drawing.Point(81, 30)
        Me.TextEdit3.Name = "TextEdit3"
        Me.TextEdit3.Size = New System.Drawing.Size(241, 20)
        Me.TextEdit3.TabIndex = 15
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl17.Location = New System.Drawing.Point(15, 104)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(57, 16)
        Me.LabelControl17.TabIndex = 14
        Me.LabelControl17.Text = "Dirección:"
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Location = New System.Drawing.Point(15, 68)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl16.TabIndex = 13
        Me.LabelControl16.Text = "Nombre:"
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(15, 28)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(25, 16)
        Me.LabelControl15.TabIndex = 12
        Me.LabelControl15.Text = "NIT:"
        '
        'viewFELVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl5)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmbTipoFactura)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewFELVentas"
        Me.Size = New System.Drawing.Size(1053, 681)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gridDetalleFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTempVentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSFEL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetalleFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtBuscarDesprod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBuscarCodprod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        Me.GroupControl4.PerformLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        Me.GroupControl5.PerformLayout()
        CType(Me.TextEdit5.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit4.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents gridDetalleFactura As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetalleFactura As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtBuscarDesprod As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtBuscarCodprod As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoFactura As ComboBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCoddoc As ComboBox
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbConCre As ComboBox
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TextEdit5 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit4 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipProd As ComboBox
    Friend WithEvents cmbTipoPrecio As ComboBox
    Friend WithEvents TblTempVentasBindingSource As BindingSource
    Friend WithEvents DSFEL As DSFEL
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQUIVALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCANTIDAD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALUNIDADES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTOUNITARIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIVA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIOSINIVA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIOSINIVA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTIPOPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXENTO As DevExpress.XtraGrid.Columns.GridColumn
End Class
