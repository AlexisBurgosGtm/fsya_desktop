<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewListaPreciosComp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewListaPreciosComp))
        Me.btnListaPreciosExportarExcel = New DevExpress.XtraEditors.SimpleButton()
        Me.LbVentasTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.GridListaPrecios = New DevExpress.XtraGrid.GridControl()
        Me.GridViewListaPrecios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQUIVALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPROVEEDOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESCLAUNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DS_VENTAS2 = New Ares.DS_VENTAS2()
        CType(Me.GridListaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListaPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DS_VENTAS2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnListaPreciosExportarExcel
        '
        Me.btnListaPreciosExportarExcel.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnListaPreciosExportarExcel.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnListaPreciosExportarExcel.Appearance.Options.UseBackColor = True
        Me.btnListaPreciosExportarExcel.Appearance.Options.UseForeColor = True
        Me.btnListaPreciosExportarExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnListaPreciosExportarExcel.Image = CType(resources.GetObject("btnListaPreciosExportarExcel.Image"), System.Drawing.Image)
        Me.btnListaPreciosExportarExcel.Location = New System.Drawing.Point(1144, 20)
        Me.btnListaPreciosExportarExcel.Name = "btnListaPreciosExportarExcel"
        Me.btnListaPreciosExportarExcel.Size = New System.Drawing.Size(121, 51)
        Me.btnListaPreciosExportarExcel.TabIndex = 35
        Me.btnListaPreciosExportarExcel.Text = "Exportar Excel"
        '
        'LbVentasTitulo
        '
        Me.LbVentasTitulo.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbVentasTitulo.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LbVentasTitulo.Location = New System.Drawing.Point(80, 20)
        Me.LbVentasTitulo.Name = "LbVentasTitulo"
        Me.LbVentasTitulo.Size = New System.Drawing.Size(213, 33)
        Me.LbVentasTitulo.TabIndex = 34
        Me.LbVentasTitulo.Text = "Listado de Precios"
        '
        'GridListaPrecios
        '
        Me.GridListaPrecios.Location = New System.Drawing.Point(16, 85)
        Me.GridListaPrecios.MainView = Me.GridViewListaPrecios
        Me.GridListaPrecios.Name = "GridListaPrecios"
        Me.GridListaPrecios.Size = New System.Drawing.Size(1249, 571)
        Me.GridListaPrecios.TabIndex = 33
        Me.GridListaPrecios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListaPrecios})
        '
        'GridViewListaPrecios
        '
        Me.GridViewListaPrecios.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colCODMEDIDA, Me.colEQUIVALE, Me.colCOSTO, Me.colPRECIO, Me.colMARCA, Me.colPROVEEDOR, Me.colDESCLAUNO, Me.colSALDO})
        Me.GridViewListaPrecios.GridControl = Me.GridListaPrecios
        Me.GridViewListaPrecios.Name = "GridViewListaPrecios"
        Me.GridViewListaPrecios.OptionsBehavior.Editable = False
        Me.GridViewListaPrecios.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewListaPrecios.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Office
        Me.GridViewListaPrecios.OptionsView.ShowAutoFilterRow = True
        Me.GridViewListaPrecios.OptionsView.ShowGroupPanel = False
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 115
        '
        'colDESPROD
        '
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 292
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 2
        Me.colCODMEDIDA.Width = 123
        '
        'colEQUIVALE
        '
        Me.colEQUIVALE.Caption = "EQ"
        Me.colEQUIVALE.FieldName = "EQUIVALE"
        Me.colEQUIVALE.Name = "colEQUIVALE"
        Me.colEQUIVALE.Visible = True
        Me.colEQUIVALE.VisibleIndex = 3
        Me.colEQUIVALE.Width = 51
        '
        'colCOSTO
        '
        Me.colCOSTO.DisplayFormat.FormatString = "Q 0.00"
        Me.colCOSTO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        Me.colCOSTO.Visible = True
        Me.colCOSTO.VisibleIndex = 4
        Me.colCOSTO.Width = 65
        '
        'colPRECIO
        '
        Me.colPRECIO.DisplayFormat.FormatString = "Q 0.00"
        Me.colPRECIO.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 5
        Me.colPRECIO.Width = 63
        '
        'colMARCA
        '
        Me.colMARCA.FieldName = "MARCA"
        Me.colMARCA.Name = "colMARCA"
        Me.colMARCA.Visible = True
        Me.colMARCA.VisibleIndex = 6
        Me.colMARCA.Width = 161
        '
        'colPROVEEDOR
        '
        Me.colPROVEEDOR.FieldName = "PROVEEDOR"
        Me.colPROVEEDOR.Name = "colPROVEEDOR"
        Me.colPROVEEDOR.Visible = True
        Me.colPROVEEDOR.VisibleIndex = 7
        Me.colPROVEEDOR.Width = 196
        '
        'colDESCLAUNO
        '
        Me.colDESCLAUNO.FieldName = "DESCLAUNO"
        Me.colDESCLAUNO.Name = "colDESCLAUNO"
        Me.colDESCLAUNO.Visible = True
        Me.colDESCLAUNO.VisibleIndex = 8
        Me.colDESCLAUNO.Width = 97
        '
        'colSALDO
        '
        Me.colSALDO.FieldName = "SALDO"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Visible = True
        Me.colSALDO.VisibleIndex = 9
        Me.colSALDO.Width = 68
        '
        'DS_VENTAS2
        '
        Me.DS_VENTAS2.DataSetName = "DS_VENTAS2"
        Me.DS_VENTAS2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ViewListaPreciosComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnListaPreciosExportarExcel)
        Me.Controls.Add(Me.LbVentasTitulo)
        Me.Controls.Add(Me.GridListaPrecios)
        Me.Name = "ViewListaPreciosComp"
        Me.Size = New System.Drawing.Size(1280, 677)
        CType(Me.GridListaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListaPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DS_VENTAS2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnListaPreciosExportarExcel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LbVentasTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridListaPrecios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewListaPrecios As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DS_VENTAS2 As DS_VENTAS2
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQUIVALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPROVEEDOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESCLAUNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
End Class
