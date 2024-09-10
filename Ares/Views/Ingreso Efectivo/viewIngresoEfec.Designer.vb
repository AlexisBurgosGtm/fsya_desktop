<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewIngresoEfec
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
        Me.txtCoddoc = New System.Windows.Forms.TextBox()
        Me.datePickDocumento = New System.Windows.Forms.DateTimePicker()
        Me.txtCorrelativo = New System.Windows.Forms.TextBox()
        Me.txtTotalEfectivo = New System.Windows.Forms.TextBox()
        Me.cmbEmpleados = New System.Windows.Forms.ComboBox()
        Me.txtMotorista = New System.Windows.Forms.TextBox()
        Me.btnGuardarIng = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnCorteIEF = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSucursales = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.GridEFECINGRESADO = New DevExpress.XtraGrid.GridControl()
        Me.TblEFECBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSDOCUMENTOS = New Ares.DSDOCUMENTOS()
        Me.GridINGRESADO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHORA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMINUTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSUCURSAL_SAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSUCURSAL_ING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMONTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMPLEADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMOTORISTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TblEFECBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridEFECENVIADO = New DevExpress.XtraGrid.GridControl()
        Me.GridENVIADO = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODDOC1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHORA1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMINUTO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSUCURSAL_SAL1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSUCURSAL_ING1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMONTO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMPLEADO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMOTORISTA1 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridEFECINGRESADO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblEFECBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridINGRESADO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblEFECBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridEFECENVIADO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridENVIADO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl1.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LabelControl1.Location = New System.Drawing.Point(235, 11)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(803, 39)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "TRASLADO DE EFECTIVO POR PEDIDOS KEEP HEALTHY"
        '
        'txtCoddoc
        '
        Me.txtCoddoc.Enabled = False
        Me.txtCoddoc.Location = New System.Drawing.Point(161, 101)
        Me.txtCoddoc.Name = "txtCoddoc"
        Me.txtCoddoc.Size = New System.Drawing.Size(153, 21)
        Me.txtCoddoc.TabIndex = 1
        '
        'datePickDocumento
        '
        Me.datePickDocumento.CustomFormat = "yyyy-MM-d"
        Me.datePickDocumento.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.datePickDocumento.Enabled = False
        Me.datePickDocumento.Font = New System.Drawing.Font("Tahoma", 10.25!)
        Me.datePickDocumento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datePickDocumento.Location = New System.Drawing.Point(161, 71)
        Me.datePickDocumento.Name = "datePickDocumento"
        Me.datePickDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.datePickDocumento.Size = New System.Drawing.Size(153, 24)
        Me.datePickDocumento.TabIndex = 238
        '
        'txtCorrelativo
        '
        Me.txtCorrelativo.Enabled = False
        Me.txtCorrelativo.Location = New System.Drawing.Point(161, 130)
        Me.txtCorrelativo.Name = "txtCorrelativo"
        Me.txtCorrelativo.Size = New System.Drawing.Size(153, 21)
        Me.txtCorrelativo.TabIndex = 239
        '
        'txtTotalEfectivo
        '
        Me.txtTotalEfectivo.Location = New System.Drawing.Point(538, 81)
        Me.txtTotalEfectivo.Name = "txtTotalEfectivo"
        Me.txtTotalEfectivo.Size = New System.Drawing.Size(138, 21)
        Me.txtTotalEfectivo.TabIndex = 241
        '
        'cmbEmpleados
        '
        Me.cmbEmpleados.FormattingEnabled = True
        Me.cmbEmpleados.Location = New System.Drawing.Point(365, 130)
        Me.cmbEmpleados.Name = "cmbEmpleados"
        Me.cmbEmpleados.Size = New System.Drawing.Size(151, 21)
        Me.cmbEmpleados.TabIndex = 242
        '
        'txtMotorista
        '
        Me.txtMotorista.Location = New System.Drawing.Point(525, 130)
        Me.txtMotorista.Name = "txtMotorista"
        Me.txtMotorista.Size = New System.Drawing.Size(151, 21)
        Me.txtMotorista.TabIndex = 243
        '
        'btnGuardarIng
        '
        Me.btnGuardarIng.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarIng.Location = New System.Drawing.Point(411, 170)
        Me.btnGuardarIng.Name = "btnGuardarIng"
        Me.btnGuardarIng.Size = New System.Drawing.Size(472, 50)
        Me.btnGuardarIng.TabIndex = 244
        Me.btnGuardarIng.Text = "GUARDAR TRASLADO"
        Me.btnGuardarIng.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(73, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 245
        Me.Label1.Text = "CODDOC:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(73, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "CORRELATIVO:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(360, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 247
        Me.Label3.Text = "SUC. A ENVIAR:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(522, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 248
        Me.Label4.Text = "TOTAL EFECTIVO:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 249
        Me.Label5.Text = "EMPLEADO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(522, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "MOTORISTA:"
        '
        'btnCorteIEF
        '
        Me.btnCorteIEF.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCorteIEF.Location = New System.Drawing.Point(944, 170)
        Me.btnCorteIEF.Name = "btnCorteIEF"
        Me.btnCorteIEF.Size = New System.Drawing.Size(267, 50)
        Me.btnCorteIEF.TabIndex = 251
        Me.btnCorteIEF.TabStop = False
        Me.btnCorteIEF.Text = "REALIZAR CORTE"
        Me.btnCorteIEF.UseVisualStyleBackColor = True
        Me.btnCorteIEF.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 76)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 253
        Me.Label7.Text = "FECHA:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(706, 95)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(505, 56)
        Me.txtObservaciones.TabIndex = 254
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(714, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 255
        Me.Label8.Text = "OBERVACIONES:"
        '
        'cmbSucursales
        '
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.Location = New System.Drawing.Point(363, 81)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(151, 21)
        Me.cmbSucursales.TabIndex = 256
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(522, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(15, 13)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = "Q"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl2.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LabelControl2.Location = New System.Drawing.Point(26, 254)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(194, 29)
        Me.LabelControl2.TabIndex = 260
        Me.LabelControl2.Text = "Efectivo ingresado"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!)
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl3.LineLocation = DevExpress.XtraEditors.LineLocation.Center
        Me.LabelControl3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.LabelControl3.Location = New System.Drawing.Point(26, 458)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(173, 29)
        Me.LabelControl3.TabIndex = 261
        Me.LabelControl3.Text = "Efectivo enviado"
        '
        'GridEFECINGRESADO
        '
        Me.GridEFECINGRESADO.DataSource = Me.TblEFECBindingSource1
        Me.GridEFECINGRESADO.Location = New System.Drawing.Point(26, 289)
        Me.GridEFECINGRESADO.MainView = Me.GridINGRESADO
        Me.GridEFECINGRESADO.Name = "GridEFECINGRESADO"
        Me.GridEFECINGRESADO.Size = New System.Drawing.Size(1229, 140)
        Me.GridEFECINGRESADO.TabIndex = 262
        Me.GridEFECINGRESADO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridINGRESADO})
        '
        'TblEFECBindingSource1
        '
        Me.TblEFECBindingSource1.DataMember = "tblEFEC"
        Me.TblEFECBindingSource1.DataSource = Me.DSDOCUMENTOS
        '
        'DSDOCUMENTOS
        '
        Me.DSDOCUMENTOS.DataSetName = "DSDOCUMENTOS"
        Me.DSDOCUMENTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridINGRESADO
        '
        Me.GridINGRESADO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODDOC, Me.colCORRELATIVO, Me.colFECHA, Me.colHORA, Me.colMINUTO, Me.colSUCURSAL_SAL, Me.colSUCURSAL_ING, Me.colMONTO, Me.colEMPLEADO, Me.colMOTORISTA})
        Me.GridINGRESADO.GridControl = Me.GridEFECINGRESADO
        Me.GridINGRESADO.Name = "GridINGRESADO"
        Me.GridINGRESADO.OptionsBehavior.Editable = False
        Me.GridINGRESADO.OptionsView.ShowAutoFilterRow = True
        Me.GridINGRESADO.OptionsView.ShowGroupPanel = False
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 0
        Me.colCODDOC.Width = 68
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        Me.colCORRELATIVO.Width = 94
        '
        'colFECHA
        '
        Me.colFECHA.DisplayFormat.FormatString = "dd/MM/yy"
        Me.colFECHA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 2
        Me.colFECHA.Width = 152
        '
        'colHORA
        '
        Me.colHORA.FieldName = "HORA"
        Me.colHORA.Name = "colHORA"
        Me.colHORA.Visible = True
        Me.colHORA.VisibleIndex = 3
        Me.colHORA.Width = 51
        '
        'colMINUTO
        '
        Me.colMINUTO.FieldName = "MINUTO"
        Me.colMINUTO.Name = "colMINUTO"
        Me.colMINUTO.Visible = True
        Me.colMINUTO.VisibleIndex = 4
        Me.colMINUTO.Width = 57
        '
        'colSUCURSAL_SAL
        '
        Me.colSUCURSAL_SAL.FieldName = "SUCURSAL_SAL"
        Me.colSUCURSAL_SAL.Name = "colSUCURSAL_SAL"
        Me.colSUCURSAL_SAL.Visible = True
        Me.colSUCURSAL_SAL.VisibleIndex = 5
        Me.colSUCURSAL_SAL.Width = 209
        '
        'colSUCURSAL_ING
        '
        Me.colSUCURSAL_ING.FieldName = "SUCURSAL_ING"
        Me.colSUCURSAL_ING.Name = "colSUCURSAL_ING"
        Me.colSUCURSAL_ING.Visible = True
        Me.colSUCURSAL_ING.VisibleIndex = 6
        Me.colSUCURSAL_ING.Width = 226
        '
        'colMONTO
        '
        Me.colMONTO.DisplayFormat.FormatString = "Q 0.00"
        Me.colMONTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMONTO.FieldName = "MONTO"
        Me.colMONTO.Name = "colMONTO"
        Me.colMONTO.Visible = True
        Me.colMONTO.VisibleIndex = 7
        Me.colMONTO.Width = 99
        '
        'colEMPLEADO
        '
        Me.colEMPLEADO.FieldName = "EMPLEADO"
        Me.colEMPLEADO.Name = "colEMPLEADO"
        Me.colEMPLEADO.Visible = True
        Me.colEMPLEADO.VisibleIndex = 8
        Me.colEMPLEADO.Width = 105
        '
        'colMOTORISTA
        '
        Me.colMOTORISTA.FieldName = "MOTORISTA"
        Me.colMOTORISTA.Name = "colMOTORISTA"
        Me.colMOTORISTA.Visible = True
        Me.colMOTORISTA.VisibleIndex = 9
        Me.colMOTORISTA.Width = 150
        '
        'TblEFECBindingSource
        '
        Me.TblEFECBindingSource.DataMember = "tblEFEC"
        Me.TblEFECBindingSource.DataSource = Me.DSDOCUMENTOS
        '
        'GridEFECENVIADO
        '
        Me.GridEFECENVIADO.DataSource = Me.TblEFECBindingSource
        Me.GridEFECENVIADO.Location = New System.Drawing.Point(26, 493)
        Me.GridEFECENVIADO.MainView = Me.GridENVIADO
        Me.GridEFECENVIADO.Name = "GridEFECENVIADO"
        Me.GridEFECENVIADO.Size = New System.Drawing.Size(1229, 140)
        Me.GridEFECENVIADO.TabIndex = 263
        Me.GridEFECENVIADO.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridENVIADO})
        '
        'GridENVIADO
        '
        Me.GridENVIADO.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODDOC1, Me.colCORRELATIVO1, Me.colFECHA1, Me.colHORA1, Me.colMINUTO1, Me.colSUCURSAL_SAL1, Me.colSUCURSAL_ING1, Me.colMONTO1, Me.colEMPLEADO1, Me.colMOTORISTA1})
        Me.GridENVIADO.GridControl = Me.GridEFECENVIADO
        Me.GridENVIADO.Name = "GridENVIADO"
        Me.GridENVIADO.OptionsBehavior.Editable = False
        Me.GridENVIADO.OptionsView.ShowAutoFilterRow = True
        Me.GridENVIADO.OptionsView.ShowGroupPanel = False
        '
        'colCODDOC1
        '
        Me.colCODDOC1.FieldName = "CODDOC"
        Me.colCODDOC1.Name = "colCODDOC1"
        Me.colCODDOC1.Visible = True
        Me.colCODDOC1.VisibleIndex = 0
        Me.colCODDOC1.Width = 68
        '
        'colCORRELATIVO1
        '
        Me.colCORRELATIVO1.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO1.Name = "colCORRELATIVO1"
        Me.colCORRELATIVO1.Visible = True
        Me.colCORRELATIVO1.VisibleIndex = 1
        Me.colCORRELATIVO1.Width = 96
        '
        'colFECHA1
        '
        Me.colFECHA1.DisplayFormat.FormatString = "dd/MM/yy"
        Me.colFECHA1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colFECHA1.FieldName = "FECHA"
        Me.colFECHA1.Name = "colFECHA1"
        Me.colFECHA1.Visible = True
        Me.colFECHA1.VisibleIndex = 2
        Me.colFECHA1.Width = 151
        '
        'colHORA1
        '
        Me.colHORA1.FieldName = "HORA"
        Me.colHORA1.Name = "colHORA1"
        Me.colHORA1.Visible = True
        Me.colHORA1.VisibleIndex = 3
        Me.colHORA1.Width = 45
        '
        'colMINUTO1
        '
        Me.colMINUTO1.FieldName = "MINUTO"
        Me.colMINUTO1.Name = "colMINUTO1"
        Me.colMINUTO1.Visible = True
        Me.colMINUTO1.VisibleIndex = 4
        Me.colMINUTO1.Width = 55
        '
        'colSUCURSAL_SAL1
        '
        Me.colSUCURSAL_SAL1.FieldName = "SUCURSAL_SAL"
        Me.colSUCURSAL_SAL1.Name = "colSUCURSAL_SAL1"
        Me.colSUCURSAL_SAL1.Visible = True
        Me.colSUCURSAL_SAL1.VisibleIndex = 5
        Me.colSUCURSAL_SAL1.Width = 220
        '
        'colSUCURSAL_ING1
        '
        Me.colSUCURSAL_ING1.FieldName = "SUCURSAL_ING"
        Me.colSUCURSAL_ING1.Name = "colSUCURSAL_ING1"
        Me.colSUCURSAL_ING1.Visible = True
        Me.colSUCURSAL_ING1.VisibleIndex = 6
        Me.colSUCURSAL_ING1.Width = 218
        '
        'colMONTO1
        '
        Me.colMONTO1.DisplayFormat.FormatString = "Q 0.00"
        Me.colMONTO1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colMONTO1.FieldName = "MONTO"
        Me.colMONTO1.Name = "colMONTO1"
        Me.colMONTO1.Visible = True
        Me.colMONTO1.VisibleIndex = 7
        Me.colMONTO1.Width = 102
        '
        'colEMPLEADO1
        '
        Me.colEMPLEADO1.FieldName = "EMPLEADO"
        Me.colEMPLEADO1.Name = "colEMPLEADO1"
        Me.colEMPLEADO1.Visible = True
        Me.colEMPLEADO1.VisibleIndex = 8
        Me.colEMPLEADO1.Width = 108
        '
        'colMOTORISTA1
        '
        Me.colMOTORISTA1.FieldName = "MOTORISTA"
        Me.colMOTORISTA1.Name = "colMOTORISTA1"
        Me.colMOTORISTA1.Visible = True
        Me.colMOTORISTA1.VisibleIndex = 9
        Me.colMOTORISTA1.Width = 148
        '
        'viewIngresoEfec
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GridEFECENVIADO)
        Me.Controls.Add(Me.GridEFECINGRESADO)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbSucursales)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCorteIEF)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnGuardarIng)
        Me.Controls.Add(Me.txtMotorista)
        Me.Controls.Add(Me.cmbEmpleados)
        Me.Controls.Add(Me.txtTotalEfectivo)
        Me.Controls.Add(Me.txtCorrelativo)
        Me.Controls.Add(Me.datePickDocumento)
        Me.Controls.Add(Me.txtCoddoc)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewIngresoEfec"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.GridEFECINGRESADO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblEFECBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridINGRESADO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblEFECBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridEFECENVIADO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridENVIADO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCoddoc As TextBox
    Friend WithEvents datePickDocumento As DateTimePicker
    Friend WithEvents txtCorrelativo As TextBox
    Friend WithEvents txtTotalEfectivo As TextBox
    Friend WithEvents cmbEmpleados As ComboBox
    Friend WithEvents txtMotorista As TextBox
    Friend WithEvents btnGuardarIng As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnCorteIEF As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbSucursales As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridEFECINGRESADO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridINGRESADO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridEFECENVIADO As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridENVIADO As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblEFECBindingSource As BindingSource
    Friend WithEvents DSDOCUMENTOS As DSDOCUMENTOS
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHORA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMINUTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMONTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPLEADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMOTORISTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHORA1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMINUTO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSUCURSAL_ING1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMONTO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPLEADO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMOTORISTA1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TblEFECBindingSource1 As BindingSource
    Friend WithEvents colSUCURSAL_SAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSUCURSAL_ING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSUCURSAL_SAL1 As DevExpress.XtraGrid.Columns.GridColumn
End Class
