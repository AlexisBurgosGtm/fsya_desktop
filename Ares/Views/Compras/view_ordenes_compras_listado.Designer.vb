<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class view_ordenes_compras_listado
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim colOBS As DevExpress.XtraGrid.Columns.GridColumn
        Me.gridOrdenes = New DevExpress.XtraGrid.GridControl()
        Me.TblOrdenesCompraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewProductos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPROVEEDOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colIMPORTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdComprasGuardar = New DevExpress.XtraEditors.SimpleButton()
        colOBS = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.gridOrdenes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblOrdenesCompraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'colOBS
        '
        colOBS.FieldName = "OBS"
        colOBS.Name = "colOBS"
        colOBS.Visible = True
        colOBS.VisibleIndex = 6
        colOBS.Width = 316
        '
        'gridOrdenes
        '
        Me.gridOrdenes.DataSource = Me.TblOrdenesCompraBindingSource
        Me.gridOrdenes.Location = New System.Drawing.Point(18, 109)
        Me.gridOrdenes.MainView = Me.GridViewProductos
        Me.gridOrdenes.Name = "gridOrdenes"
        Me.gridOrdenes.Size = New System.Drawing.Size(1157, 525)
        Me.gridOrdenes.TabIndex = 2
        Me.gridOrdenes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProductos})
        '
        'TblOrdenesCompraBindingSource
        '
        Me.TblOrdenesCompraBindingSource.DataMember = "tblOrdenesCompra"
        Me.TblOrdenesCompraBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewProductos
        '
        Me.GridViewProductos.Appearance.Empty.BackColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.Empty.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GridViewProductos.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FixedLine.BackColor = System.Drawing.Color.Gray
        Me.GridViewProductos.Appearance.FixedLine.ForeColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.FixedLine.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FixedLine.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue
        Me.GridViewProductos.Appearance.FocusedCell.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.FocusedCell.ForeColor = System.Drawing.Color.DimGray
        Me.GridViewProductos.Appearance.FocusedCell.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FocusedCell.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.FocusedCell.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue
        Me.GridViewProductos.Appearance.FocusedRow.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.FocusedRow.ForeColor = System.Drawing.Color.DimGray
        Me.GridViewProductos.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.FocusedRow.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.FocusedRow.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.GroupPanel.BackColor = System.Drawing.Color.DarkOrange
        Me.GridViewProductos.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.GroupPanel.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.GroupPanel.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.GroupRow.BackColor = System.Drawing.Color.Gray
        Me.GridViewProductos.Appearance.GroupRow.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.GroupRow.ForeColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.GroupRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.GroupRow.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.GroupRow.Options.UseForeColor = True
        Me.GridViewProductos.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue
        Me.GridViewProductos.Appearance.SelectedRow.BorderColor = System.Drawing.Color.White
        Me.GridViewProductos.Appearance.SelectedRow.ForeColor = System.Drawing.Color.DimGray
        Me.GridViewProductos.Appearance.SelectedRow.Options.UseBackColor = True
        Me.GridViewProductos.Appearance.SelectedRow.Options.UseBorderColor = True
        Me.GridViewProductos.Appearance.SelectedRow.Options.UseForeColor = True
        Me.GridViewProductos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFECHA, Me.colCODDOC, Me.colCORRELATIVO, Me.colNIT, Me.colPROVEEDOR, Me.colIMPORTE, colOBS})
        Me.GridViewProductos.GridControl = Me.gridOrdenes
        Me.GridViewProductos.Name = "GridViewProductos"
        Me.GridViewProductos.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewProductos.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewProductos.OptionsBehavior.Editable = False
        Me.GridViewProductos.OptionsBehavior.ReadOnly = True
        Me.GridViewProductos.OptionsView.ShowAutoFilterRow = True
        Me.GridViewProductos.OptionsView.ShowGroupPanel = False
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 0
        Me.colFECHA.Width = 106
        '
        'colCODDOC
        '
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 1
        Me.colCODDOC.Width = 90
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 2
        Me.colCORRELATIVO.Width = 94
        '
        'colNIT
        '
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 3
        Me.colNIT.Width = 125
        '
        'colPROVEEDOR
        '
        Me.colPROVEEDOR.FieldName = "PROVEEDOR"
        Me.colPROVEEDOR.Name = "colPROVEEDOR"
        Me.colPROVEEDOR.Visible = True
        Me.colPROVEEDOR.VisibleIndex = 4
        Me.colPROVEEDOR.Width = 273
        '
        'colIMPORTE
        '
        Me.colIMPORTE.FieldName = "IMPORTE"
        Me.colIMPORTE.Name = "colIMPORTE"
        Me.colIMPORTE.Visible = True
        Me.colIMPORTE.VisibleIndex = 5
        Me.colIMPORTE.Width = 135
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl3.Location = New System.Drawing.Point(18, 29)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(382, 33)
        Me.LabelControl3.TabIndex = 204
        Me.LabelControl3.Text = "Ordenes de  Compra Pendientes"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAceptarTrue.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarTrue.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.btnAceptarTrue.Appearance.Options.UseBackColor = True
        Me.btnAceptarTrue.Appearance.Options.UseFont = True
        Me.btnAceptarTrue.Appearance.Options.UseForeColor = True
        Me.btnAceptarTrue.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(735, 122)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(82, 57)
        Me.btnAceptarTrue.TabIndex = 205
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "aceptar"
        '
        'cmdComprasGuardar
        '
        Me.cmdComprasGuardar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdComprasGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdComprasGuardar.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.cmdComprasGuardar.Appearance.Options.UseBackColor = True
        Me.cmdComprasGuardar.Appearance.Options.UseFont = True
        Me.cmdComprasGuardar.Appearance.Options.UseForeColor = True
        Me.cmdComprasGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdComprasGuardar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdComprasGuardar.Location = New System.Drawing.Point(1075, 23)
        Me.cmdComprasGuardar.Name = "cmdComprasGuardar"
        Me.cmdComprasGuardar.Size = New System.Drawing.Size(100, 57)
        Me.cmdComprasGuardar.TabIndex = 206
        Me.cmdComprasGuardar.Text = "CERRAR (X)"
        '
        'view_ordenes_compras_listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdComprasGuardar)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.gridOrdenes)
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Name = "view_ordenes_compras_listado"
        Me.Size = New System.Drawing.Size(1220, 665)
        CType(Me.gridOrdenes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblOrdenesCompraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gridOrdenes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProductos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblOrdenesCompraBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPROVEEDOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colIMPORTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdComprasGuardar As DevExpress.XtraEditors.SimpleButton
End Class
