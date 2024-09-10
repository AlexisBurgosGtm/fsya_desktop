<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewPedidosPreventa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewPedidosPreventa))
        Me.GridPedidos = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPedidos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIMPORTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaFacturas = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCoddocGenerar = New System.Windows.Forms.ComboBox()
        Me.btnCancelarGrid = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGenerarPedidos = New DevExpress.XtraEditors.SimpleButton()
        Me.lbEmbarqueActual = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCargarGrid = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbVendedor = New System.Windows.Forms.ComboBox()
        Me.cmbEmbarque = New System.Windows.Forms.ComboBox()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.btnGetCenso = New System.Windows.Forms.Button()
        Me.btnUploadProductosLocal = New System.Windows.Forms.Button()
        Me.btnUploadClientes = New System.Windows.Forms.Button()
        Me.btnUploadEmbarques = New System.Windows.Forms.Button()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnRecargar = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtFechaFacturas.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFacturas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridPedidos
        '
        Me.GridPedidos.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPedidos.Location = New System.Drawing.Point(14, 278)
        Me.GridPedidos.MainView = Me.GridViewPedidos
        Me.GridPedidos.Name = "GridPedidos"
        Me.GridPedidos.Size = New System.Drawing.Size(980, 369)
        Me.GridPedidos.TabIndex = 22
        Me.GridPedidos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPedidos})
        '
        'GridViewPedidos
        '
        Me.GridViewPedidos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODDOC, Me.colCORRELATIVO, Me.colCLIENTE, Me.colIMPORTE, Me.colFECHA})
        Me.GridViewPedidos.GridControl = Me.GridPedidos
        Me.GridViewPedidos.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IMPORTE", Nothing, "(IMPORTE: SUM={0:0.##})"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "CODDOC", Nothing, "(CODDOC: Count={0})")})
        Me.GridViewPedidos.Name = "GridViewPedidos"
        Me.GridViewPedidos.OptionsBehavior.Editable = False
        Me.GridViewPedidos.OptionsView.ShowFooter = True
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "CODDOC", "{0}")})
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 0
        Me.colCODDOC.Width = 72
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        Me.colCORRELATIVO.Width = 87
        '
        'colCLIENTE
        '
        Me.colCLIENTE.FieldName = "CLIENTE"
        Me.colCLIENTE.Name = "colCLIENTE"
        Me.colCLIENTE.Visible = True
        Me.colCLIENTE.VisibleIndex = 2
        Me.colCLIENTE.Width = 432
        '
        'colIMPORTE
        '
        Me.colIMPORTE.FieldName = "IMPORTE"
        Me.colIMPORTE.Name = "colIMPORTE"
        Me.colIMPORTE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IMPORTE", "SUM={0:0.##}")})
        Me.colIMPORTE.Visible = True
        Me.colIMPORTE.VisibleIndex = 3
        Me.colIMPORTE.Width = 146
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 4
        Me.colFECHA.Width = 135
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.LabelControl16)
        Me.GroupControl2.Controls.Add(Me.txtFechaFacturas)
        Me.GroupControl2.Controls.Add(Me.LabelControl15)
        Me.GroupControl2.Controls.Add(Me.cmbCoddocGenerar)
        Me.GroupControl2.Controls.Add(Me.btnCancelarGrid)
        Me.GroupControl2.Controls.Add(Me.btnGenerarPedidos)
        Me.GroupControl2.Controls.Add(Me.lbEmbarqueActual)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Controls.Add(Me.btnCargarGrid)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.cmbVendedor)
        Me.GroupControl2.Controls.Add(Me.cmbEmbarque)
        Me.GroupControl2.Location = New System.Drawing.Point(15, 87)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(979, 185)
        Me.GroupControl2.TabIndex = 23
        Me.GroupControl2.Text = "Generación de Pedidos"
        '
        'LabelControl16
        '
        Me.LabelControl16.Location = New System.Drawing.Point(427, 114)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(78, 13)
        Me.LabelControl16.TabIndex = 28
        Me.LabelControl16.Text = "Fecha Facturas:"
        '
        'txtFechaFacturas
        '
        Me.txtFechaFacturas.EditValue = Nothing
        Me.txtFechaFacturas.Location = New System.Drawing.Point(516, 111)
        Me.txtFechaFacturas.Name = "txtFechaFacturas"
        Me.txtFechaFacturas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFacturas.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFacturas.Size = New System.Drawing.Size(131, 20)
        Me.txtFechaFacturas.TabIndex = 27
        '
        'LabelControl15
        '
        Me.LabelControl15.Location = New System.Drawing.Point(427, 80)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(83, 13)
        Me.LabelControl15.TabIndex = 26
        Me.LabelControl15.Text = "Generar Factura:"
        '
        'cmbCoddocGenerar
        '
        Me.cmbCoddocGenerar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCoddocGenerar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCoddocGenerar.FormattingEnabled = True
        Me.cmbCoddocGenerar.Location = New System.Drawing.Point(516, 77)
        Me.cmbCoddocGenerar.Name = "cmbCoddocGenerar"
        Me.cmbCoddocGenerar.Size = New System.Drawing.Size(131, 21)
        Me.cmbCoddocGenerar.TabIndex = 25
        '
        'btnCancelarGrid
        '
        Me.btnCancelarGrid.Image = CType(resources.GetObject("btnCancelarGrid.Image"), System.Drawing.Image)
        Me.btnCancelarGrid.Location = New System.Drawing.Point(657, 88)
        Me.btnCancelarGrid.Name = "btnCancelarGrid"
        Me.btnCancelarGrid.Size = New System.Drawing.Size(81, 27)
        Me.btnCancelarGrid.TabIndex = 22
        Me.btnCancelarGrid.Text = "Cancelar"
        '
        'btnGenerarPedidos
        '
        Me.btnGenerarPedidos.Image = CType(resources.GetObject("btnGenerarPedidos.Image"), System.Drawing.Image)
        Me.btnGenerarPedidos.Location = New System.Drawing.Point(752, 40)
        Me.btnGenerarPedidos.Name = "btnGenerarPedidos"
        Me.btnGenerarPedidos.Size = New System.Drawing.Size(94, 75)
        Me.btnGenerarPedidos.TabIndex = 21
        Me.btnGenerarPedidos.Text = "Generar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Vendedor"
        '
        'lbEmbarqueActual
        '
        Me.lbEmbarqueActual.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEmbarqueActual.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lbEmbarqueActual.Location = New System.Drawing.Point(16, 102)
        Me.lbEmbarqueActual.Name = "lbEmbarqueActual"
        Me.lbEmbarqueActual.Size = New System.Drawing.Size(10, 14)
        Me.lbEmbarqueActual.TabIndex = 20
        Me.lbEmbarqueActual.Text = "--"
        '
        'LabelControl14
        '
        Me.LabelControl14.Location = New System.Drawing.Point(16, 84)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(85, 13)
        Me.LabelControl14.TabIndex = 19
        Me.LabelControl14.Text = "Embarque Actual:"
        '
        'btnCargarGrid
        '
        Me.btnCargarGrid.Image = CType(resources.GetObject("btnCargarGrid.Image"), System.Drawing.Image)
        Me.btnCargarGrid.Location = New System.Drawing.Point(657, 40)
        Me.btnCargarGrid.Name = "btnCargarGrid"
        Me.btnCargarGrid.Size = New System.Drawing.Size(81, 37)
        Me.btnCargarGrid.TabIndex = 17
        Me.btnCargarGrid.Text = "Cargar"
        '
        'LabelControl13
        '
        Me.LabelControl13.Location = New System.Drawing.Point(371, 47)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl13.TabIndex = 16
        Me.LabelControl13.Text = "Vendedor:"
        '
        'LabelControl12
        '
        Me.LabelControl12.Location = New System.Drawing.Point(16, 25)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(52, 13)
        Me.LabelControl12.TabIndex = 15
        Me.LabelControl12.Text = "Embarque:"
        '
        'cmbVendedor
        '
        Me.cmbVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(427, 44)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(220, 21)
        Me.cmbVendedor.TabIndex = 14
        '
        'cmbEmbarque
        '
        Me.cmbEmbarque.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmbarque.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmbarque.FormattingEnabled = True
        Me.cmbEmbarque.Location = New System.Drawing.Point(16, 43)
        Me.cmbEmbarque.Name = "cmbEmbarque"
        Me.cmbEmbarque.Size = New System.Drawing.Size(333, 21)
        Me.cmbEmbarque.TabIndex = 13
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.btnGetCenso)
        Me.GroupControl3.Controls.Add(Me.btnUploadProductosLocal)
        Me.GroupControl3.Controls.Add(Me.btnUploadClientes)
        Me.GroupControl3.Controls.Add(Me.btnUploadEmbarques)
        Me.GroupControl3.Location = New System.Drawing.Point(466, 12)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(528, 69)
        Me.GroupControl3.TabIndex = 26
        Me.GroupControl3.Text = "Subida de Datos"
        '
        'btnGetCenso
        '
        Me.btnGetCenso.BackColor = System.Drawing.Color.White
        Me.btnGetCenso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGetCenso.ForeColor = System.Drawing.Color.Gray
        Me.btnGetCenso.Location = New System.Drawing.Point(5, 23)
        Me.btnGetCenso.Name = "btnGetCenso"
        Me.btnGetCenso.Size = New System.Drawing.Size(104, 35)
        Me.btnGetCenso.TabIndex = 9
        Me.btnGetCenso.Text = "Bajar Censo"
        Me.btnGetCenso.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnGetCenso.UseVisualStyleBackColor = False
        '
        'btnUploadProductosLocal
        '
        Me.btnUploadProductosLocal.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnUploadProductosLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadProductosLocal.ForeColor = System.Drawing.Color.White
        Me.btnUploadProductosLocal.Location = New System.Drawing.Point(419, 23)
        Me.btnUploadProductosLocal.Name = "btnUploadProductosLocal"
        Me.btnUploadProductosLocal.Size = New System.Drawing.Size(104, 35)
        Me.btnUploadProductosLocal.TabIndex = 8
        Me.btnUploadProductosLocal.Text = "Subir Productos"
        Me.btnUploadProductosLocal.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnUploadProductosLocal.UseVisualStyleBackColor = False
        '
        'btnUploadClientes
        '
        Me.btnUploadClientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnUploadClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadClientes.ForeColor = System.Drawing.Color.White
        Me.btnUploadClientes.Location = New System.Drawing.Point(199, 23)
        Me.btnUploadClientes.Name = "btnUploadClientes"
        Me.btnUploadClientes.Size = New System.Drawing.Size(104, 35)
        Me.btnUploadClientes.TabIndex = 2
        Me.btnUploadClientes.Text = "Subir Clientes"
        Me.btnUploadClientes.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnUploadClientes.UseVisualStyleBackColor = False
        '
        'btnUploadEmbarques
        '
        Me.btnUploadEmbarques.BackColor = System.Drawing.Color.Teal
        Me.btnUploadEmbarques.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUploadEmbarques.ForeColor = System.Drawing.Color.White
        Me.btnUploadEmbarques.Location = New System.Drawing.Point(309, 23)
        Me.btnUploadEmbarques.Name = "btnUploadEmbarques"
        Me.btnUploadEmbarques.Size = New System.Drawing.Size(104, 35)
        Me.btnUploadEmbarques.TabIndex = 7
        Me.btnUploadEmbarques.Text = "Subir Embarques"
        Me.btnUploadEmbarques.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnUploadEmbarques.UseVisualStyleBackColor = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.LabelControl1.Location = New System.Drawing.Point(93, 21)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(156, 19)
        Me.LabelControl1.TabIndex = 27
        Me.LabelControl1.Text = "Gestión de Pedidos"
        '
        'btnRecargar
        '
        Me.btnRecargar.Image = CType(resources.GetObject("btnRecargar.Image"), System.Drawing.Image)
        Me.btnRecargar.Location = New System.Drawing.Point(327, 47)
        Me.btnRecargar.Name = "btnRecargar"
        Me.btnRecargar.Size = New System.Drawing.Size(109, 23)
        Me.btnRecargar.TabIndex = 28
        Me.btnRecargar.Text = "Recargar Info"
        '
        'viewPedidosPreventa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnRecargar)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GridPedidos)
        Me.Controls.Add(Me.GroupControl2)
        Me.Name = "viewPedidosPreventa"
        Me.Size = New System.Drawing.Size(1008, 700)
        CType(Me.GridPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtFechaFacturas.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFacturas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridPedidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPedidos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIMPORTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaFacturas As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCoddocGenerar As ComboBox
    Friend WithEvents btnCancelarGrid As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGenerarPedidos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lbEmbarqueActual As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCargarGrid As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbVendedor As ComboBox
    Friend WithEvents cmbEmbarque As ComboBox
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnUploadProductosLocal As Button
    Friend WithEvents btnUploadClientes As Button
    Friend WithEvents btnUploadEmbarques As Button
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGetCenso As Button
    Friend WithEvents btnRecargar As DevExpress.XtraEditors.SimpleButton
End Class
