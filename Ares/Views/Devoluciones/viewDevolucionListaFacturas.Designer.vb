<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewDevolucionListaFacturas
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
        Me.GridControlFacturas = New DevExpress.XtraGrid.GridControl()
        Me.TblDocumentosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSDOCUMENTOS = New Ares.DSDOCUMENTOS()
        Me.GridViewFacturas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEMPNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDIRCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALTARJETA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHORAMINUTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCONCRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colST = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDOCREF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCAJA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCLIE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbAnio = New System.Windows.Forms.ComboBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.colCODEMBARQUE = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControlFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblDocumentosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControlFacturas
        '
        Me.GridControlFacturas.DataSource = Me.TblDocumentosBindingSource
        Me.GridControlFacturas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlFacturas.Location = New System.Drawing.Point(2, 20)
        Me.GridControlFacturas.MainView = Me.GridViewFacturas
        Me.GridControlFacturas.Name = "GridControlFacturas"
        Me.GridControlFacturas.Size = New System.Drawing.Size(954, 351)
        Me.GridControlFacturas.TabIndex = 0
        Me.GridControlFacturas.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewFacturas})
        '
        'TblDocumentosBindingSource
        '
        Me.TblDocumentosBindingSource.DataMember = "tblDocumentos"
        Me.TblDocumentosBindingSource.DataSource = Me.DSDOCUMENTOS
        '
        'DSDOCUMENTOS
        '
        Me.DSDOCUMENTOS.DataSetName = "DSDOCUMENTOS"
        Me.DSDOCUMENTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewFacturas
        '
        Me.GridViewFacturas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEMPNIT, Me.colCODDOC, Me.colCORRELATIVO, Me.colFECHA, Me.colNIT, Me.colNOMCLIENTE, Me.colDIRCLIENTE, Me.colMARCA, Me.colTOTALCOSTO, Me.colTOTALPRECIO, Me.colTOTALTARJETA, Me.colHORAMINUTO, Me.colCONCRE, Me.colST, Me.colID, Me.colCODCLIENTE, Me.colDOCREF, Me.colCODCAJA, Me.colCODCLIE, Me.colCODEMBARQUE})
        Me.GridViewFacturas.GridControl = Me.GridControlFacturas
        Me.GridViewFacturas.Name = "GridViewFacturas"
        Me.GridViewFacturas.OptionsBehavior.Editable = False
        Me.GridViewFacturas.OptionsView.ShowAutoFilterRow = True
        Me.GridViewFacturas.OptionsView.ShowGroupPanel = False
        '
        'colEMPNIT
        '
        Me.colEMPNIT.FieldName = "EMPNIT"
        Me.colEMPNIT.Name = "colEMPNIT"
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 0
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 1
        Me.colCORRELATIVO.Width = 96
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 2
        Me.colFECHA.Width = 78
        '
        'colNIT
        '
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 3
        Me.colNIT.Width = 70
        '
        'colNOMCLIENTE
        '
        Me.colNOMCLIENTE.FieldName = "NOMCLIENTE"
        Me.colNOMCLIENTE.Name = "colNOMCLIENTE"
        Me.colNOMCLIENTE.Visible = True
        Me.colNOMCLIENTE.VisibleIndex = 4
        Me.colNOMCLIENTE.Width = 163
        '
        'colDIRCLIENTE
        '
        Me.colDIRCLIENTE.FieldName = "DIRCLIENTE"
        Me.colDIRCLIENTE.Name = "colDIRCLIENTE"
        '
        'colMARCA
        '
        Me.colMARCA.FieldName = "MARCA"
        Me.colMARCA.Name = "colMARCA"
        '
        'colTOTALCOSTO
        '
        Me.colTOTALCOSTO.FieldName = "TOTALCOSTO"
        Me.colTOTALCOSTO.Name = "colTOTALCOSTO"
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 5
        Me.colTOTALPRECIO.Width = 104
        '
        'colTOTALTARJETA
        '
        Me.colTOTALTARJETA.FieldName = "TOTALTARJETA"
        Me.colTOTALTARJETA.Name = "colTOTALTARJETA"
        '
        'colHORAMINUTO
        '
        Me.colHORAMINUTO.FieldName = "HORAMINUTO"
        Me.colHORAMINUTO.Name = "colHORAMINUTO"
        Me.colHORAMINUTO.Visible = True
        Me.colHORAMINUTO.VisibleIndex = 6
        Me.colHORAMINUTO.Width = 89
        '
        'colCONCRE
        '
        Me.colCONCRE.FieldName = "CONCRE"
        Me.colCONCRE.Name = "colCONCRE"
        Me.colCONCRE.Visible = True
        Me.colCONCRE.VisibleIndex = 7
        Me.colCONCRE.Width = 80
        '
        'colST
        '
        Me.colST.FieldName = "ST"
        Me.colST.Name = "colST"
        '
        'colID
        '
        Me.colID.FieldName = "ID"
        Me.colID.Name = "colID"
        '
        'colCODCLIENTE
        '
        Me.colCODCLIENTE.FieldName = "CODCLIENTE"
        Me.colCODCLIENTE.Name = "colCODCLIENTE"
        '
        'colDOCREF
        '
        Me.colDOCREF.FieldName = "DOCREF"
        Me.colDOCREF.Name = "colDOCREF"
        '
        'colCODCAJA
        '
        Me.colCODCAJA.FieldName = "CODCAJA"
        Me.colCODCAJA.Name = "colCODCAJA"
        '
        'colCODCLIE
        '
        Me.colCODCLIE.Caption = "CODIGOCLIE"
        Me.colCODCLIE.FieldName = "CODCLIE"
        Me.colCODCLIE.Name = "colCODCLIE"
        Me.colCODCLIE.Visible = True
        Me.colCODCLIE.VisibleIndex = 8
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridControlFacturas)
        Me.GroupControl1.Location = New System.Drawing.Point(4, 62)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(958, 373)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Lista de Facturas    /    Doble clic o Enter para seleccionar una Factura"
        '
        'cmbMes
        '
        Me.cmbMes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbMes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMes.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(169, 29)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(193, 27)
        Me.cmbMes.TabIndex = 2
        '
        'cmbAnio
        '
        Me.cmbAnio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbAnio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbAnio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnio.FormattingEnabled = True
        Me.cmbAnio.Items.AddRange(New Object() {"2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040"})
        Me.cmbAnio.Location = New System.Drawing.Point(377, 29)
        Me.cmbAnio.Name = "cmbAnio"
        Me.cmbAnio.Size = New System.Drawing.Size(121, 27)
        Me.cmbAnio.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(69, 30)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(89, 19)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Mes y Año:"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Location = New System.Drawing.Point(865, 16)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(85, 33)
        Me.SimpleButton1.TabIndex = 5
        Me.SimpleButton1.Text = "Cancelar (x)"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(684, 90)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 6
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "aceptar"
        '
        'colCODEMBARQUE
        '
        Me.colCODEMBARQUE.Caption = "EMBARQUE"
        Me.colCODEMBARQUE.FieldName = "CODEMBARQUE"
        Me.colCODEMBARQUE.Name = "colCODEMBARQUE"
        Me.colCODEMBARQUE.Visible = True
        Me.colCODEMBARQUE.VisibleIndex = 9
        '
        'viewDevolucionListaFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cmbAnio)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Name = "viewDevolucionListaFacturas"
        Me.Size = New System.Drawing.Size(965, 454)
        CType(Me.GridControlFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblDocumentosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSDOCUMENTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControlFacturas As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewFacturas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents cmbAnio As ComboBox
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblDocumentosBindingSource As BindingSource
    Friend WithEvents DSDOCUMENTOS As DSDOCUMENTOS
    Friend WithEvents colEMPNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDIRCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALTARJETA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHORAMINUTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCONCRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colST As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDOCREF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODCAJA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colCODCLIE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODEMBARQUE As DevExpress.XtraGrid.Columns.GridColumn
End Class
