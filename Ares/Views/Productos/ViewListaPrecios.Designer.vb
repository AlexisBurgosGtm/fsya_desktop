<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewListaPrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewListaPrecios))
        Me.GridListaPrecios = New DevExpress.XtraGrid.GridControl()
        Me.TblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASDataSet = New Ares.VENTASDataSet()
        Me.GridViewListaPrecios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colUXC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQUIVALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCLAUNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCLADOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIOQ = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMAYOREOA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMAYOREOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMAYOREOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXISTENCIA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEXENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LbVentasTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.btnListaPreciosExportarExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.btnListaPreciosImprimir = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCostoUnitario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnGuardarCosto = New System.Windows.Forms.Button()
        CType(Me.GridListaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridListaPrecios
        '
        Me.GridListaPrecios.DataSource = Me.TblBindingSource
        Me.GridListaPrecios.Location = New System.Drawing.Point(13, 88)
        Me.GridListaPrecios.MainView = Me.GridViewListaPrecios
        Me.GridListaPrecios.Name = "GridListaPrecios"
        Me.GridListaPrecios.Size = New System.Drawing.Size(1249, 571)
        Me.GridListaPrecios.TabIndex = 0
        Me.GridListaPrecios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListaPrecios})
        '
        'TblBindingSource
        '
        Me.TblBindingSource.DataMember = "tbl"
        Me.TblBindingSource.DataSource = Me.VENTASDataSet
        '
        'VENTASDataSet
        '
        Me.VENTASDataSet.DataSetName = "VENTASDataSet"
        Me.VENTASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewListaPrecios
        '
        Me.GridViewListaPrecios.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colId, Me.colCODPROD, Me.colDESPROD, Me.colDESPROD2, Me.colDESPROD3, Me.colUXC, Me.colCODMEDIDA, Me.colEQUIVALE, Me.colCOSTO, Me.colPRECIO, Me.colDESMARCA, Me.colDESCLAUNO, Me.colDESCLADOS, Me.colPRECIOQ, Me.colMAYOREOA, Me.colMAYOREOB, Me.colMAYOREOC, Me.colEXISTENCIA, Me.colEXENTO})
        Me.GridViewListaPrecios.GridControl = Me.GridListaPrecios
        Me.GridViewListaPrecios.Name = "GridViewListaPrecios"
        Me.GridViewListaPrecios.OptionsBehavior.Editable = False
        Me.GridViewListaPrecios.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewListaPrecios.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office
        Me.GridViewListaPrecios.OptionsView.ShowAutoFilterRow = True
        Me.GridViewListaPrecios.OptionsView.ShowGroupPanel = False
        Me.GridViewListaPrecios.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colDESPROD3, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colId
        '
        Me.colId.FieldName = "Id"
        Me.colId.Name = "colId"
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "Código"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 60
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "Descripción"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 2
        Me.colDESPROD.Width = 142
        '
        'colDESPROD2
        '
        Me.colDESPROD2.Caption = "Barras"
        Me.colDESPROD2.FieldName = "DESPROD2"
        Me.colDESPROD2.Name = "colDESPROD2"
        Me.colDESPROD2.Visible = True
        Me.colDESPROD2.VisibleIndex = 1
        Me.colDESPROD2.Width = 88
        '
        'colDESPROD3
        '
        Me.colDESPROD3.Caption = "Descripción 3"
        Me.colDESPROD3.FieldName = "DESPROD3"
        Me.colDESPROD3.Name = "colDESPROD3"
        Me.colDESPROD3.Width = 67
        '
        'colUXC
        '
        Me.colUXC.Caption = "UxC"
        Me.colUXC.FieldName = "UXC"
        Me.colUXC.Name = "colUXC"
        Me.colUXC.Width = 41
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.Caption = "Medida"
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 3
        Me.colCODMEDIDA.Width = 66
        '
        'colEQUIVALE
        '
        Me.colEQUIVALE.Caption = "Equivale"
        Me.colEQUIVALE.FieldName = "EQUIVALE"
        Me.colEQUIVALE.Name = "colEQUIVALE"
        Me.colEQUIVALE.Visible = True
        Me.colEQUIVALE.VisibleIndex = 4
        Me.colEQUIVALE.Width = 47
        '
        'colCOSTO
        '
        Me.colCOSTO.Caption = "Costo"
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        Me.colCOSTO.Visible = True
        Me.colCOSTO.VisibleIndex = 5
        Me.colCOSTO.Width = 56
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        '
        'colDESMARCA
        '
        Me.colDESMARCA.Caption = "Marca"
        Me.colDESMARCA.FieldName = "DESMARCA"
        Me.colDESMARCA.Name = "colDESMARCA"
        Me.colDESMARCA.Visible = True
        Me.colDESMARCA.VisibleIndex = 7
        Me.colDESMARCA.Width = 79
        '
        'colDESCLAUNO
        '
        Me.colDESCLAUNO.Caption = "Fabricante"
        Me.colDESCLAUNO.FieldName = "DESCLAUNO"
        Me.colDESCLAUNO.Name = "colDESCLAUNO"
        Me.colDESCLAUNO.Visible = True
        Me.colDESCLAUNO.VisibleIndex = 8
        '
        'colDESCLADOS
        '
        Me.colDESCLADOS.Caption = "ClasifDos"
        Me.colDESCLADOS.FieldName = "DESCLADOS"
        Me.colDESCLADOS.Name = "colDESCLADOS"
        Me.colDESCLADOS.Width = 77
        '
        'colPRECIOQ
        '
        Me.colPRECIOQ.Caption = "CAT A"
        Me.colPRECIOQ.FieldName = "PRECIOQ"
        Me.colPRECIOQ.Name = "colPRECIOQ"
        Me.colPRECIOQ.Visible = True
        Me.colPRECIOQ.VisibleIndex = 6
        Me.colPRECIOQ.Width = 56
        '
        'colMAYOREOA
        '
        Me.colMAYOREOA.Caption = "CAT B"
        Me.colMAYOREOA.FieldName = "MAYOREOA"
        Me.colMAYOREOA.Name = "colMAYOREOA"
        Me.colMAYOREOA.Visible = True
        Me.colMAYOREOA.VisibleIndex = 9
        Me.colMAYOREOA.Width = 69
        '
        'colMAYOREOB
        '
        Me.colMAYOREOB.Caption = "CAT C"
        Me.colMAYOREOB.FieldName = "MAYOREOB"
        Me.colMAYOREOB.Name = "colMAYOREOB"
        Me.colMAYOREOB.Visible = True
        Me.colMAYOREOB.VisibleIndex = 10
        Me.colMAYOREOB.Width = 69
        '
        'colMAYOREOC
        '
        Me.colMAYOREOC.Caption = "CAT D"
        Me.colMAYOREOC.FieldName = "MAYOREOC"
        Me.colMAYOREOC.Name = "colMAYOREOC"
        Me.colMAYOREOC.Visible = True
        Me.colMAYOREOC.VisibleIndex = 11
        Me.colMAYOREOC.Width = 69
        '
        'colEXISTENCIA
        '
        Me.colEXISTENCIA.Caption = "Existencia"
        Me.colEXISTENCIA.FieldName = "EXISTENCIA"
        Me.colEXISTENCIA.Name = "colEXISTENCIA"
        Me.colEXISTENCIA.Visible = True
        Me.colEXISTENCIA.VisibleIndex = 13
        Me.colEXISTENCIA.Width = 73
        '
        'colEXENTO
        '
        Me.colEXENTO.Caption = "Exent"
        Me.colEXENTO.FieldName = "EXENTO"
        Me.colEXENTO.Name = "colEXENTO"
        Me.colEXENTO.Visible = True
        Me.colEXENTO.VisibleIndex = 12
        '
        'LbVentasTitulo
        '
        Me.LbVentasTitulo.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbVentasTitulo.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LbVentasTitulo.Location = New System.Drawing.Point(77, 23)
        Me.LbVentasTitulo.Name = "LbVentasTitulo"
        Me.LbVentasTitulo.Size = New System.Drawing.Size(213, 33)
        Me.LbVentasTitulo.TabIndex = 25
        Me.LbVentasTitulo.Text = "Listado de Precios"
        '
        'btnListaPreciosExportarExcel
        '
        Me.btnListaPreciosExportarExcel.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnListaPreciosExportarExcel.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnListaPreciosExportarExcel.Appearance.Options.UseBackColor = True
        Me.btnListaPreciosExportarExcel.Appearance.Options.UseForeColor = True
        Me.btnListaPreciosExportarExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnListaPreciosExportarExcel.Image = CType(resources.GetObject("btnListaPreciosExportarExcel.Image"), System.Drawing.Image)
        Me.btnListaPreciosExportarExcel.Location = New System.Drawing.Point(1014, 23)
        Me.btnListaPreciosExportarExcel.Name = "btnListaPreciosExportarExcel"
        Me.btnListaPreciosExportarExcel.Size = New System.Drawing.Size(121, 51)
        Me.btnListaPreciosExportarExcel.TabIndex = 26
        Me.btnListaPreciosExportarExcel.Text = "Exportar Excel"
        '
        'btnListaPreciosImprimir
        '
        Me.btnListaPreciosImprimir.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnListaPreciosImprimir.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnListaPreciosImprimir.Appearance.Options.UseBackColor = True
        Me.btnListaPreciosImprimir.Appearance.Options.UseForeColor = True
        Me.btnListaPreciosImprimir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnListaPreciosImprimir.Image = CType(resources.GetObject("btnListaPreciosImprimir.Image"), System.Drawing.Image)
        Me.btnListaPreciosImprimir.Location = New System.Drawing.Point(1141, 23)
        Me.btnListaPreciosImprimir.Name = "btnListaPreciosImprimir"
        Me.btnListaPreciosImprimir.Size = New System.Drawing.Size(121, 51)
        Me.btnListaPreciosImprimir.TabIndex = 27
        Me.btnListaPreciosImprimir.Text = "Imprimir"
        '
        'txtCostoUnitario
        '
        Me.txtCostoUnitario.BackColor = System.Drawing.SystemColors.Info
        Me.txtCostoUnitario.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCostoUnitario.Location = New System.Drawing.Point(792, 28)
        Me.txtCostoUnitario.Name = "txtCostoUnitario"
        Me.txtCostoUnitario.Size = New System.Drawing.Size(100, 39)
        Me.txtCostoUnitario.TabIndex = 0
        Me.txtCostoUnitario.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(580, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 32)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Costo Unitario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(758, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 32)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Q"
        '
        'btnGuardarCosto
        '
        Me.btnGuardarCosto.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardarCosto.Location = New System.Drawing.Point(898, 27)
        Me.btnGuardarCosto.Name = "btnGuardarCosto"
        Me.btnGuardarCosto.Size = New System.Drawing.Size(108, 42)
        Me.btnGuardarCosto.TabIndex = 31
        Me.btnGuardarCosto.Text = "GUARDAR"
        Me.btnGuardarCosto.UseVisualStyleBackColor = True
        '
        'ViewListaPrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnGuardarCosto)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCostoUnitario)
        Me.Controls.Add(Me.btnListaPreciosImprimir)
        Me.Controls.Add(Me.btnListaPreciosExportarExcel)
        Me.Controls.Add(Me.LbVentasTitulo)
        Me.Controls.Add(Me.GridListaPrecios)
        Me.Name = "ViewListaPrecios"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.GridListaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridListaPrecios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewListaPrecios As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LbVentasTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnListaPreciosExportarExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnListaPreciosImprimir As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TblBindingSource As BindingSource
    Friend WithEvents VENTASDataSet As VENTASDataSet
    Friend WithEvents colId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUXC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQUIVALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIOQ As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCLAUNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCLADOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXISTENCIA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMAYOREOA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMAYOREOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMAYOREOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEXENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCostoUnitario As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnGuardarCosto As Button
End Class
