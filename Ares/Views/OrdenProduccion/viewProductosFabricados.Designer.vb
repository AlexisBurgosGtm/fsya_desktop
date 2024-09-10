<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewProductosFabricados
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.gridProductosFabricados = New DevExpress.XtraGrid.GridControl()
        Me.GridViewProductosFabricados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.DSPRODUCTOS = New Ares.DSPRODUCTOS()
        Me.TblProductosFabricadosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQUIVALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.gridProductosFabricados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProductosFabricados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProductosFabricadosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.gridProductosFabricados)
        Me.GroupControl1.Controls.Add(Me.btnAceptarTrue)
        Me.GroupControl1.Location = New System.Drawing.Point(13, 37)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(724, 400)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Doble Click para Agregar un Producto"
        '
        'gridProductosFabricados
        '
        Me.gridProductosFabricados.DataSource = Me.TblProductosFabricadosBindingSource
        Me.gridProductosFabricados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProductosFabricados.Location = New System.Drawing.Point(2, 20)
        Me.gridProductosFabricados.MainView = Me.GridViewProductosFabricados
        Me.gridProductosFabricados.Name = "gridProductosFabricados"
        Me.gridProductosFabricados.Size = New System.Drawing.Size(720, 378)
        Me.gridProductosFabricados.TabIndex = 3
        Me.gridProductosFabricados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProductosFabricados})
        '
        'GridViewProductosFabricados
        '
        Me.GridViewProductosFabricados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colCODMEDIDA, Me.colEQUIVALE, Me.colCOSTO, Me.colPRECIO})
        Me.GridViewProductosFabricados.GridControl = Me.gridProductosFabricados
        Me.GridViewProductosFabricados.Name = "GridViewProductosFabricados"
        Me.GridViewProductosFabricados.OptionsBehavior.Editable = False
        Me.GridViewProductosFabricados.OptionsView.ShowAutoFilterRow = True
        Me.GridViewProductosFabricados.OptionsView.ShowGroupPanel = False
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(724, 349)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 2
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "SimpleButton2"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(677, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cerrar(x)"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(26, 7)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(242, 19)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Lista de Productos Fabricados"
        '
        'DSPRODUCTOS
        '
        Me.DSPRODUCTOS.DataSetName = "DSPRODUCTOS"
        Me.DSPRODUCTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblProductosFabricadosBindingSource
        '
        Me.TblProductosFabricadosBindingSource.DataMember = "tblProductosFabricados"
        Me.TblProductosFabricadosBindingSource.DataSource = Me.DSPRODUCTOS
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "CODIGO"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 107
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "PRODUCTO"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 318
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.Caption = "MEDIDA"
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 2
        Me.colCODMEDIDA.Width = 104
        '
        'colEQUIVALE
        '
        Me.colEQUIVALE.FieldName = "EQUIVALE"
        Me.colEQUIVALE.Name = "colEQUIVALE"
        Me.colEQUIVALE.Visible = True
        Me.colEQUIVALE.VisibleIndex = 3
        Me.colEQUIVALE.Width = 59
        '
        'colCOSTO
        '
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        Me.colCOSTO.Width = 143
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 4
        Me.colPRECIO.Width = 112
        '
        'viewProductosFabricados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewProductosFabricados"
        Me.Size = New System.Drawing.Size(755, 450)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.gridProductosFabricados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProductosFabricados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProductosFabricadosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents gridProductosFabricados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProductosFabricados As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblProductosFabricadosBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOS As DSPRODUCTOS
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQUIVALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
End Class
