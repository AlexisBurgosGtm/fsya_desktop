<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewGestionPreciosSucursal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewGestionPreciosSucursal))
        Me.btnSubirPlantillaProductos = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl50 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridProductos = New DevExpress.XtraGrid.GridControl()
        Me.TblProdsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOS = New Ares.DSPRODUCTOS()
        Me.GridViewProductos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GridPreciosSucursal = New DevExpress.XtraGrid.GridControl()
        Me.TblPreBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewPreciosSucursal = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQUIVALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCOSTO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMAYOREOA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMAYOREOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMAYOREOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPESO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPORCUTILIDAD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.cmbSucursales = New System.Windows.Forms.ComboBox()
        Me.VENTASDataSet = New Ares.VENTASDataSet()
        Me.TblListaProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProdsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GridPreciosSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblPreBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPreciosSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblListaProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSubirPlantillaProductos
        '
        Me.btnSubirPlantillaProductos.Image = CType(resources.GetObject("btnSubirPlantillaProductos.Image"), System.Drawing.Image)
        Me.btnSubirPlantillaProductos.Location = New System.Drawing.Point(875, 28)
        Me.btnSubirPlantillaProductos.Name = "btnSubirPlantillaProductos"
        Me.btnSubirPlantillaProductos.Size = New System.Drawing.Size(183, 56)
        Me.btnSubirPlantillaProductos.TabIndex = 0
        Me.btnSubirPlantillaProductos.Text = "Subir Productos y Precios"
        '
        'LabelControl50
        '
        Me.LabelControl50.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl50.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl50.Location = New System.Drawing.Point(78, 28)
        Me.LabelControl50.Name = "LabelControl50"
        Me.LabelControl50.Size = New System.Drawing.Size(388, 33)
        Me.LabelControl50.TabIndex = 748
        Me.LabelControl50.Text = "Gestión de Precios en Sucursales"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl1.Location = New System.Drawing.Point(84, 65)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(230, 13)
        Me.LabelControl1.TabIndex = 749
        Me.LabelControl1.Text = "Esta sección solo funcionará con internet"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridProductos)
        Me.GroupControl1.Location = New System.Drawing.Point(14, 139)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(490, 531)
        Me.GroupControl1.TabIndex = 750
        Me.GroupControl1.Text = "Seleccione un producto de la lista"
        '
        'GridProductos
        '
        Me.GridProductos.DataSource = Me.TblProdsBindingSource
        Me.GridProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProductos.Location = New System.Drawing.Point(2, 20)
        Me.GridProductos.MainView = Me.GridViewProductos
        Me.GridProductos.Name = "GridProductos"
        Me.GridProductos.Size = New System.Drawing.Size(486, 509)
        Me.GridProductos.TabIndex = 0
        Me.GridProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewProductos})
        '
        'TblProdsBindingSource
        '
        Me.TblProdsBindingSource.DataMember = "tblProds"
        Me.TblProdsBindingSource.DataSource = Me.DSPRODUCTOS
        '
        'DSPRODUCTOS
        '
        Me.DSPRODUCTOS.DataSetName = "DSPRODUCTOS"
        Me.DSPRODUCTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewProductos
        '
        Me.GridViewProductos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colCOSTO})
        Me.GridViewProductos.GridControl = Me.GridProductos
        Me.GridViewProductos.Name = "GridViewProductos"
        Me.GridViewProductos.OptionsBehavior.Editable = False
        Me.GridViewProductos.OptionsView.ShowAutoFilterRow = True
        Me.GridViewProductos.OptionsView.ShowGroupPanel = False
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 92
        '
        'colDESPROD
        '
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 316
        '
        'colCOSTO
        '
        Me.colCOSTO.Caption = "COSTO UN"
        Me.colCOSTO.FieldName = "COSTO"
        Me.colCOSTO.Name = "colCOSTO"
        Me.colCOSTO.Visible = True
        Me.colCOSTO.VisibleIndex = 2
        Me.colCOSTO.Width = 79
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GridPreciosSucursal)
        Me.GroupControl2.Location = New System.Drawing.Point(510, 239)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(568, 229)
        Me.GroupControl2.TabIndex = 751
        Me.GroupControl2.Text = "Precios de la Sucursal"
        '
        'GridPreciosSucursal
        '
        Me.GridPreciosSucursal.DataSource = Me.TblPreBindingSource
        Me.GridPreciosSucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPreciosSucursal.Location = New System.Drawing.Point(2, 20)
        Me.GridPreciosSucursal.MainView = Me.GridViewPreciosSucursal
        Me.GridPreciosSucursal.Name = "GridPreciosSucursal"
        Me.GridPreciosSucursal.Size = New System.Drawing.Size(564, 207)
        Me.GridPreciosSucursal.TabIndex = 0
        Me.GridPreciosSucursal.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPreciosSucursal})
        '
        'TblPreBindingSource
        '
        Me.TblPreBindingSource.DataMember = "tblPre"
        Me.TblPreBindingSource.DataSource = Me.DSPRODUCTOS
        '
        'GridViewPreciosSucursal
        '
        Me.GridViewPreciosSucursal.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODMEDIDA, Me.colEQUIVALE, Me.colCOSTO1, Me.colPRECIO, Me.colMAYOREOA, Me.colMAYOREOB, Me.colMAYOREOC, Me.colPESO, Me.colPORCUTILIDAD})
        Me.GridViewPreciosSucursal.GridControl = Me.GridPreciosSucursal
        Me.GridViewPreciosSucursal.Name = "GridViewPreciosSucursal"
        Me.GridViewPreciosSucursal.OptionsBehavior.Editable = False
        Me.GridViewPreciosSucursal.OptionsView.ShowGroupPanel = False
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 0
        Me.colCODMEDIDA.Width = 71
        '
        'colEQUIVALE
        '
        Me.colEQUIVALE.FieldName = "EQUIVALE"
        Me.colEQUIVALE.Name = "colEQUIVALE"
        Me.colEQUIVALE.Visible = True
        Me.colEQUIVALE.VisibleIndex = 1
        Me.colEQUIVALE.Width = 37
        '
        'colCOSTO1
        '
        Me.colCOSTO1.FieldName = "COSTO"
        Me.colCOSTO1.Name = "colCOSTO1"
        Me.colCOSTO1.Visible = True
        Me.colCOSTO1.VisibleIndex = 2
        Me.colCOSTO1.Width = 56
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 3
        Me.colPRECIO.Width = 61
        '
        'colMAYOREOA
        '
        Me.colMAYOREOA.FieldName = "MAYOREOA"
        Me.colMAYOREOA.Name = "colMAYOREOA"
        Me.colMAYOREOA.Visible = True
        Me.colMAYOREOA.VisibleIndex = 4
        Me.colMAYOREOA.Width = 65
        '
        'colMAYOREOB
        '
        Me.colMAYOREOB.FieldName = "MAYOREOB"
        Me.colMAYOREOB.Name = "colMAYOREOB"
        Me.colMAYOREOB.Visible = True
        Me.colMAYOREOB.VisibleIndex = 5
        Me.colMAYOREOB.Width = 67
        '
        'colMAYOREOC
        '
        Me.colMAYOREOC.FieldName = "MAYOREOC"
        Me.colMAYOREOC.Name = "colMAYOREOC"
        Me.colMAYOREOC.Visible = True
        Me.colMAYOREOC.VisibleIndex = 6
        Me.colMAYOREOC.Width = 72
        '
        'colPESO
        '
        Me.colPESO.FieldName = "PESO"
        Me.colPESO.Name = "colPESO"
        Me.colPESO.Visible = True
        Me.colPESO.VisibleIndex = 7
        Me.colPESO.Width = 41
        '
        'colPORCUTILIDAD
        '
        Me.colPORCUTILIDAD.FieldName = "PORCUTILIDAD"
        Me.colPORCUTILIDAD.Name = "colPORCUTILIDAD"
        Me.colPORCUTILIDAD.Visible = True
        Me.colPORCUTILIDAD.VisibleIndex = 8
        Me.colPORCUTILIDAD.Width = 43
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.cmbSucursales)
        Me.GroupControl3.Location = New System.Drawing.Point(510, 139)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(568, 93)
        Me.GroupControl3.TabIndex = 752
        Me.GroupControl3.Text = "Seleccione una Sucursal"
        '
        'cmbSucursales
        '
        Me.cmbSucursales.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbSucursales.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSucursales.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.Location = New System.Drawing.Point(35, 40)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(466, 31)
        Me.cmbSucursales.TabIndex = 0
        '
        'VENTASDataSet
        '
        Me.VENTASDataSet.DataSetName = "VENTASDataSet"
        Me.VENTASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblListaProductosBindingSource
        '
        Me.TblListaProductosBindingSource.DataMember = "tblListaProductos"
        Me.TblListaProductosBindingSource.DataSource = Me.VENTASDataSet
        '
        'viewGestionPreciosSucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl50)
        Me.Controls.Add(Me.btnSubirPlantillaProductos)
        Me.Name = "viewGestionPreciosSucursal"
        Me.Size = New System.Drawing.Size(1090, 696)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProdsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GridPreciosSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblPreBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPreciosSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblListaProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSubirPlantillaProductos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl50 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewProductos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridPreciosSucursal As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPreciosSucursal As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents cmbSucursales As ComboBox
    Friend WithEvents TblListaProductosBindingSource As BindingSource
    Friend WithEvents VENTASDataSet As VENTASDataSet
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TblProdsBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOS As DSPRODUCTOS
    Friend WithEvents colCOSTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TblPreBindingSource As BindingSource
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQUIVALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCOSTO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMAYOREOA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMAYOREOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMAYOREOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPESO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPORCUTILIDAD As DevExpress.XtraGrid.Columns.GridColumn
End Class
