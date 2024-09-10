<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEtiquetas
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
        Me.LabelControl173 = New DevExpress.XtraEditors.LabelControl()
        Me.GridListaProductos = New DevExpress.XtraGrid.GridControl()
        Me.TblListaProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASDataSet = New Ares.VENTASDataSet()
        Me.GridViewLista = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEQUIVALE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SplitContainerMain = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GridSeleccionados = New DevExpress.XtraGrid.GridControl()
        Me.TblTempEtiquetasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewEtiquetas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colID1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODPROD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDA1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODMEDIDAANTES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIOANTES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnImprimirListado = New DevExpress.XtraEditors.SimpleButton()
        Me.btnEliminar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimirListadoOfertas = New DevExpress.XtraEditors.SimpleButton()
        Me.btnImprimirBarcode = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridListaProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblListaProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerMain.SuspendLayout()
        CType(Me.GridSeleccionados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblTempEtiquetasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl173
        '
        Me.LabelControl173.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl173.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl173.Location = New System.Drawing.Point(87, 17)
        Me.LabelControl173.Name = "LabelControl173"
        Me.LabelControl173.Size = New System.Drawing.Size(256, 33)
        Me.LabelControl173.TabIndex = 199
        Me.LabelControl173.Text = "Creación de Etiquetas"
        '
        'GridListaProductos
        '
        Me.GridListaProductos.DataSource = Me.TblListaProductosBindingSource
        Me.GridListaProductos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridListaProductos.Location = New System.Drawing.Point(0, 0)
        Me.GridListaProductos.MainView = Me.GridViewLista
        Me.GridListaProductos.Name = "GridListaProductos"
        Me.GridListaProductos.Size = New System.Drawing.Size(537, 534)
        Me.GridListaProductos.TabIndex = 200
        Me.GridListaProductos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewLista})
        '
        'TblListaProductosBindingSource
        '
        Me.TblListaProductosBindingSource.DataMember = "tblListaProductos"
        Me.TblListaProductosBindingSource.DataSource = Me.VENTASDataSet
        '
        'VENTASDataSet
        '
        Me.VENTASDataSet.DataSetName = "VENTASDataSet"
        Me.VENTASDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewLista
        '
        Me.GridViewLista.Appearance.EvenRow.BackColor = System.Drawing.Color.LightGray
        Me.GridViewLista.Appearance.EvenRow.Options.UseBackColor = True
        Me.GridViewLista.Appearance.FocusedRow.BackColor = System.Drawing.Color.LightSkyBlue
        Me.GridViewLista.Appearance.FocusedRow.Options.UseBackColor = True
        Me.GridViewLista.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colDESPROD2, Me.colCODMEDIDA, Me.colEQUIVALE, Me.colPRECIO, Me.colDESMARCA})
        Me.GridViewLista.GridControl = Me.GridListaProductos
        Me.GridViewLista.Name = "GridViewLista"
        Me.GridViewLista.OptionsBehavior.Editable = False
        Me.GridViewLista.OptionsView.ShowAutoFilterRow = True
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "Código"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "Descripción"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        '
        'colDESPROD2
        '
        Me.colDESPROD2.Caption = "Descripción 2"
        Me.colDESPROD2.FieldName = "DESPROD2"
        Me.colDESPROD2.Name = "colDESPROD2"
        Me.colDESPROD2.Visible = True
        Me.colDESPROD2.VisibleIndex = 2
        '
        'colCODMEDIDA
        '
        Me.colCODMEDIDA.Caption = "Medida"
        Me.colCODMEDIDA.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA.Name = "colCODMEDIDA"
        Me.colCODMEDIDA.Visible = True
        Me.colCODMEDIDA.VisibleIndex = 3
        '
        'colEQUIVALE
        '
        Me.colEQUIVALE.Caption = "Equivale"
        Me.colEQUIVALE.FieldName = "EQUIVALE"
        Me.colEQUIVALE.Name = "colEQUIVALE"
        Me.colEQUIVALE.Visible = True
        Me.colEQUIVALE.VisibleIndex = 4
        '
        'colPRECIO
        '
        Me.colPRECIO.Caption = "Precio"
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 5
        '
        'colDESMARCA
        '
        Me.colDESMARCA.Caption = "Marca"
        Me.colDESMARCA.FieldName = "DESMARCA"
        Me.colDESMARCA.Name = "colDESMARCA"
        Me.colDESMARCA.Visible = True
        Me.colDESMARCA.VisibleIndex = 6
        '
        'TblBindingSource
        '
        Me.TblBindingSource.DataMember = "tbl"
        Me.TblBindingSource.DataSource = Me.VENTASDataSet
        '
        'SplitContainerMain
        '
        Me.SplitContainerMain.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2
        Me.SplitContainerMain.Location = New System.Drawing.Point(8, 126)
        Me.SplitContainerMain.Name = "SplitContainerMain"
        Me.SplitContainerMain.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SplitContainerMain.Panel1.Controls.Add(Me.GridListaProductos)
        Me.SplitContainerMain.Panel1.ShowCaption = True
        Me.SplitContainerMain.Panel1.Text = "Listado de Productos"
        Me.SplitContainerMain.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SplitContainerMain.Panel2.Controls.Add(Me.GridSeleccionados)
        Me.SplitContainerMain.Panel2.ShowCaption = True
        Me.SplitContainerMain.Panel2.Text = "Productos para imprimir etiquetas"
        Me.SplitContainerMain.Size = New System.Drawing.Size(1071, 556)
        Me.SplitContainerMain.SplitterPosition = 541
        Me.SplitContainerMain.TabIndex = 201
        Me.SplitContainerMain.Text = "SplitContainerControl1"
        '
        'GridSeleccionados
        '
        Me.GridSeleccionados.DataSource = Me.TblTempEtiquetasBindingSource
        Me.GridSeleccionados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridSeleccionados.Location = New System.Drawing.Point(0, 0)
        Me.GridSeleccionados.MainView = Me.GridViewEtiquetas
        Me.GridSeleccionados.Name = "GridSeleccionados"
        Me.GridSeleccionados.Size = New System.Drawing.Size(521, 534)
        Me.GridSeleccionados.TabIndex = 201
        Me.GridSeleccionados.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewEtiquetas})
        '
        'TblTempEtiquetasBindingSource
        '
        Me.TblTempEtiquetasBindingSource.DataMember = "tblTempEtiquetas"
        Me.TblTempEtiquetasBindingSource.DataSource = Me.VENTASDataSet
        '
        'GridViewEtiquetas
        '
        Me.GridViewEtiquetas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colID1, Me.colCODPROD1, Me.colDESPROD1, Me.colCODMEDIDA1, Me.colPRECIO1, Me.colCODMEDIDAANTES, Me.colPRECIOANTES})
        Me.GridViewEtiquetas.GridControl = Me.GridSeleccionados
        Me.GridViewEtiquetas.Name = "GridViewEtiquetas"
        Me.GridViewEtiquetas.OptionsBehavior.Editable = False
        '
        'colID1
        '
        Me.colID1.FieldName = "ID"
        Me.colID1.Name = "colID1"
        '
        'colCODPROD1
        '
        Me.colCODPROD1.Caption = "Código"
        Me.colCODPROD1.FieldName = "CODPROD"
        Me.colCODPROD1.Name = "colCODPROD1"
        Me.colCODPROD1.Visible = True
        Me.colCODPROD1.VisibleIndex = 0
        Me.colCODPROD1.Width = 71
        '
        'colDESPROD1
        '
        Me.colDESPROD1.Caption = "Descripción"
        Me.colDESPROD1.FieldName = "DESPROD"
        Me.colDESPROD1.Name = "colDESPROD1"
        Me.colDESPROD1.Visible = True
        Me.colDESPROD1.VisibleIndex = 1
        Me.colDESPROD1.Width = 115
        '
        'colCODMEDIDA1
        '
        Me.colCODMEDIDA1.Caption = "Medida"
        Me.colCODMEDIDA1.FieldName = "CODMEDIDA"
        Me.colCODMEDIDA1.Name = "colCODMEDIDA1"
        Me.colCODMEDIDA1.Visible = True
        Me.colCODMEDIDA1.VisibleIndex = 2
        Me.colCODMEDIDA1.Width = 90
        '
        'colPRECIO1
        '
        Me.colPRECIO1.Caption = "Precio"
        Me.colPRECIO1.FieldName = "PRECIO"
        Me.colPRECIO1.Name = "colPRECIO1"
        Me.colPRECIO1.Visible = True
        Me.colPRECIO1.VisibleIndex = 3
        Me.colPRECIO1.Width = 68
        '
        'colCODMEDIDAANTES
        '
        Me.colCODMEDIDAANTES.Caption = "Med Oferta"
        Me.colCODMEDIDAANTES.FieldName = "CODMEDIDAANTES"
        Me.colCODMEDIDAANTES.Name = "colCODMEDIDAANTES"
        Me.colCODMEDIDAANTES.Visible = True
        Me.colCODMEDIDAANTES.VisibleIndex = 4
        Me.colCODMEDIDAANTES.Width = 80
        '
        'colPRECIOANTES
        '
        Me.colPRECIOANTES.Caption = "Precio Of"
        Me.colPRECIOANTES.FieldName = "PRECIOANTES"
        Me.colPRECIOANTES.Name = "colPRECIOANTES"
        Me.colPRECIOANTES.Visible = True
        Me.colPRECIOANTES.VisibleIndex = 5
        Me.colPRECIOANTES.Width = 79
        '
        'btnImprimirListado
        '
        Me.btnImprimirListado.Image = Global.Ares.My.Resources.Resources.btPrint
        Me.btnImprimirListado.Location = New System.Drawing.Point(901, 56)
        Me.btnImprimirListado.Name = "btnImprimirListado"
        Me.btnImprimirListado.Size = New System.Drawing.Size(157, 63)
        Me.btnImprimirListado.TabIndex = 202
        Me.btnImprimirListado.Text = "Listado un Precio"
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Ares.My.Resources.Resources.btWarning
        Me.btnEliminar.Location = New System.Drawing.Point(87, 56)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(145, 63)
        Me.btnEliminar.TabIndex = 203
        Me.btnEliminar.Text = "Eliminar Lista"
        '
        'btnImprimirListadoOfertas
        '
        Me.btnImprimirListadoOfertas.Image = Global.Ares.My.Resources.Resources.btExito1
        Me.btnImprimirListadoOfertas.Location = New System.Drawing.Point(726, 56)
        Me.btnImprimirListadoOfertas.Name = "btnImprimirListadoOfertas"
        Me.btnImprimirListadoOfertas.Size = New System.Drawing.Size(157, 63)
        Me.btnImprimirListadoOfertas.TabIndex = 204
        Me.btnImprimirListadoOfertas.Text = "Listado Ofertas"
        '
        'btnImprimirBarcode
        '
        Me.btnImprimirBarcode.Image = Global.Ares.My.Resources.Resources.B0
        Me.btnImprimirBarcode.Location = New System.Drawing.Point(553, 56)
        Me.btnImprimirBarcode.Name = "btnImprimirBarcode"
        Me.btnImprimirBarcode.Size = New System.Drawing.Size(157, 63)
        Me.btnImprimirBarcode.TabIndex = 205
        Me.btnImprimirBarcode.Text = "Códigos de Barra"
        '
        'ViewEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnImprimirBarcode)
        Me.Controls.Add(Me.btnImprimirListadoOfertas)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnImprimirListado)
        Me.Controls.Add(Me.SplitContainerMain)
        Me.Controls.Add(Me.LabelControl173)
        Me.Name = "ViewEtiquetas"
        Me.Size = New System.Drawing.Size(1090, 696)
        CType(Me.GridListaProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblListaProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerMain.ResumeLayout(False)
        CType(Me.GridSeleccionados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblTempEtiquetasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl173 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridListaProductos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewLista As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerMain As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridSeleccionados As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewEtiquetas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblBindingSource As BindingSource
    Friend WithEvents VENTASDataSet As VENTASDataSet
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEQUIVALE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TblTempEtiquetasBindingSource As BindingSource
    Friend WithEvents colID1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODPROD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODMEDIDA1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIOANTES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TblListaProductosBindingSource As BindingSource
    Friend WithEvents btnImprimirListado As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnEliminar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnImprimirListadoOfertas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents colCODMEDIDAANTES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnImprimirBarcode As DevExpress.XtraEditors.SimpleButton
End Class
