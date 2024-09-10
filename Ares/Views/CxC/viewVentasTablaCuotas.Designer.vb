<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewVentasTablaCuotas
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
        Me.btnCuotas = New DevExpress.XtraEditors.SimpleButton()
        Me.GridCuotas = New DevExpress.XtraGrid.GridControl()
        Me.TblDocCuotasTempBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSCxc = New Ares.DSCxc()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colNOCUOTA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHAPAGO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIMPORTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQIMPORTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalFActura = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lbNit = New DevExpress.XtraEditors.LabelControl()
        Me.LbCliente = New DevExpress.XtraEditors.LabelControl()
        Me.lbFactura = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmbCantidadCuotas = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbFrecuencia = New System.Windows.Forms.ComboBox()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        CType(Me.GridCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDocCuotasTempBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSCxc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCuotas
        '
        Me.btnCuotas.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCuotas.Appearance.Options.UseFont = True
        Me.btnCuotas.Location = New System.Drawing.Point(282, 96)
        Me.btnCuotas.Name = "btnCuotas"
        Me.btnCuotas.Size = New System.Drawing.Size(99, 41)
        Me.btnCuotas.TabIndex = 2
        Me.btnCuotas.Text = "Cargar Cuotas"
        '
        'GridCuotas
        '
        Me.GridCuotas.DataSource = Me.TblDocCuotasTempBindingSource
        Me.GridCuotas.Location = New System.Drawing.Point(437, 156)
        Me.GridCuotas.MainView = Me.GridView1
        Me.GridCuotas.Name = "GridCuotas"
        Me.GridCuotas.Size = New System.Drawing.Size(405, 385)
        Me.GridCuotas.TabIndex = 3
        Me.GridCuotas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'TblDocCuotasTempBindingSource
        '
        Me.TblDocCuotasTempBindingSource.DataMember = "tblDocCuotasTemp"
        Me.TblDocCuotasTempBindingSource.DataSource = Me.DSCxc
        '
        'DSCxc
        '
        Me.DSCxc.DataSetName = "DSCxc"
        Me.DSCxc.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colNOCUOTA, Me.colFECHAPAGO, Me.colIMPORTE, Me.colQIMPORTE})
        Me.GridView1.GridControl = Me.GridCuotas
        Me.GridView1.Name = "GridView1"
        '
        'colNOCUOTA
        '
        Me.colNOCUOTA.Caption = "No Cuota"
        Me.colNOCUOTA.FieldName = "NOCUOTA"
        Me.colNOCUOTA.Name = "colNOCUOTA"
        Me.colNOCUOTA.Visible = True
        Me.colNOCUOTA.VisibleIndex = 0
        Me.colNOCUOTA.Width = 83
        '
        'colFECHAPAGO
        '
        Me.colFECHAPAGO.Caption = "Fecha"
        Me.colFECHAPAGO.FieldName = "FECHAPAGO"
        Me.colFECHAPAGO.Name = "colFECHAPAGO"
        Me.colFECHAPAGO.Visible = True
        Me.colFECHAPAGO.VisibleIndex = 1
        Me.colFECHAPAGO.Width = 117
        '
        'colIMPORTE
        '
        Me.colIMPORTE.FieldName = "IMPORTE"
        Me.colIMPORTE.Name = "colIMPORTE"
        '
        'colQIMPORTE
        '
        Me.colQIMPORTE.Caption = "A Pagar"
        Me.colQIMPORTE.FieldName = "QIMPORTE"
        Me.colQIMPORTE.Name = "colQIMPORTE"
        Me.colQIMPORTE.Visible = True
        Me.colQIMPORTE.VisibleIndex = 2
        Me.colQIMPORTE.Width = 187
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(465, 30)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(117, 23)
        Me.LabelControl2.TabIndex = 4
        Me.LabelControl2.Text = "Total Factura:"
        '
        'lbTotalFActura
        '
        Me.lbTotalFActura.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalFActura.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalFActura.Location = New System.Drawing.Point(592, 30)
        Me.lbTotalFActura.Name = "lbTotalFActura"
        Me.lbTotalFActura.Size = New System.Drawing.Size(78, 29)
        Me.lbTotalFActura.TabIndex = 5
        Me.lbTotalFActura.Text = "Q 0.00"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Location = New System.Drawing.Point(831, 4)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(32, 22)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "x"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.lbNit)
        Me.GroupControl1.Controls.Add(Me.LbCliente)
        Me.GroupControl1.Controls.Add(Me.lbFactura)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.lbTotalFActura)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Location = New System.Drawing.Point(27, 15)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(800, 117)
        Me.GroupControl1.TabIndex = 7
        Me.GroupControl1.Text = "Datos de la Factura"
        '
        'lbNit
        '
        Me.lbNit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNit.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNit.Location = New System.Drawing.Point(77, 29)
        Me.lbNit.Name = "lbNit"
        Me.lbNit.Size = New System.Drawing.Size(15, 16)
        Me.lbNit.TabIndex = 19
        Me.lbNit.Text = "CF"
        '
        'LbCliente
        '
        Me.LbCliente.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCliente.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbCliente.Location = New System.Drawing.Point(77, 51)
        Me.LbCliente.Name = "LbCliente"
        Me.LbCliente.Size = New System.Drawing.Size(99, 16)
        Me.LbCliente.TabIndex = 18
        Me.LbCliente.Text = "Consumidor Final"
        '
        'lbFactura
        '
        Me.lbFactura.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFactura.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbFactura.Location = New System.Drawing.Point(77, 74)
        Me.lbFactura.Name = "lbFactura"
        Me.lbFactura.Size = New System.Drawing.Size(100, 16)
        Me.lbFactura.TabIndex = 17
        Me.lbFactura.Text = "FACA1 - 1000000"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(14, 74)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(41, 13)
        Me.LabelControl6.TabIndex = 12
        Me.LabelControl6.Text = "Factura:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(14, 51)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(37, 13)
        Me.LabelControl4.TabIndex = 7
        Me.LabelControl4.Text = "Cliente:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(14, 29)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(21, 13)
        Me.LabelControl3.TabIndex = 6
        Me.LabelControl3.Text = "NIT:"
        '
        'btnGuardar
        '
        Me.btnGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Appearance.Options.UseFont = True
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(213, 314)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(168, 55)
        Me.btnGuardar.TabIndex = 9
        Me.btnGuardar.Text = "Guardar Cuotas"
        '
        'cmbCantidadCuotas
        '
        Me.cmbCantidadCuotas.FormattingEnabled = True
        Me.cmbCantidadCuotas.Items.AddRange(New Object() {"2", "6", "8", "10", "12", "15", "18", "20", "22", "24", "26", "28", "30", "40", "48", "72", "96", "108", "120"})
        Me.cmbCantidadCuotas.Location = New System.Drawing.Point(180, 105)
        Me.cmbCantidadCuotas.Name = "cmbCantidadCuotas"
        Me.cmbCantidadCuotas.Size = New System.Drawing.Size(80, 21)
        Me.cmbCantidadCuotas.TabIndex = 11
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(180, 84)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(80, 13)
        Me.LabelControl1.TabIndex = 10
        Me.LabelControl1.Text = "Cantidad Cuotas"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(14, 84)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(98, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Frecuencia de Pago:"
        '
        'cmbFrecuencia
        '
        Me.cmbFrecuencia.FormattingEnabled = True
        Me.cmbFrecuencia.Items.AddRange(New Object() {"TRIMESTRAL", "MENSUAL", "QUINCENAL", "SEMANAL", "DIARIO"})
        Me.cmbFrecuencia.Location = New System.Drawing.Point(14, 105)
        Me.cmbFrecuencia.Name = "cmbFrecuencia"
        Me.cmbFrecuencia.Size = New System.Drawing.Size(147, 21)
        Me.cmbFrecuencia.TabIndex = 8
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(18, 35)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(73, 13)
        Me.LabelControl7.TabIndex = 20
        Me.LabelControl7.Text = "Fecha Factura:"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.btnCancelar)
        Me.GroupControl2.Controls.Add(Me.txtFecha)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.cmbFrecuencia)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Controls.Add(Me.btnGuardar)
        Me.GroupControl2.Controls.Add(Me.cmbCantidadCuotas)
        Me.GroupControl2.Controls.Add(Me.btnCuotas)
        Me.GroupControl2.Location = New System.Drawing.Point(27, 151)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(395, 390)
        Me.GroupControl2.TabIndex = 21
        Me.GroupControl2.Text = "Detalle de las Cuotas"
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(9, 314)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(168, 55)
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.Text = "Cancelar"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(105, 34)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(106, 20)
        Me.txtFecha.TabIndex = 21
        '
        'viewVentasTablaCuotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.GridCuotas)
        Me.Name = "viewVentasTablaCuotas"
        Me.Size = New System.Drawing.Size(868, 557)
        CType(Me.GridCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDocCuotasTempBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSCxc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCuotas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridCuotas As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalFActura As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmbCantidadCuotas As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbFrecuencia As ComboBox
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TblDocCuotasTempBindingSource As BindingSource
    Friend WithEvents DSCxc As DSCxc
    Friend WithEvents colNOCUOTA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHAPAGO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIMPORTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQIMPORTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbNit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbCliente As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbFactura As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
End Class
