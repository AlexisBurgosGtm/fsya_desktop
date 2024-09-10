<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewProductosPreciosCompetencia
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
        Me.lbDesprod = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridPrecios = New DevExpress.XtraGrid.GridControl()
        Me.TblPreciosCompetenciaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOS = New Ares.DSPRODUCTOS()
        Me.GridViewPrecios = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPROVEEDOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDIRECCION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTELEFONOS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOBS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TblPreciosCompetenciaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.txtProveedor = New System.Windows.Forms.ComboBox()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPrecio = New DevExpress.XtraEditors.TextEdit()
        Me.txtObs = New DevExpress.XtraEditors.TextEdit()
        Me.txtTels = New DevExpress.XtraEditors.TextEdit()
        Me.txtDireccion = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblPreciosCompetenciaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblPreciosCompetenciaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTels.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbDesprod
        '
        Me.lbDesprod.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesprod.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDesprod.Location = New System.Drawing.Point(16, 13)
        Me.lbDesprod.Name = "lbDesprod"
        Me.lbDesprod.Size = New System.Drawing.Size(86, 23)
        Me.lbDesprod.TabIndex = 0
        Me.lbDesprod.Text = "Producto"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridPrecios)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(610, 384)
        Me.GroupControl1.TabIndex = 2
        Me.GroupControl1.Text = "Precios de la Competencia"
        '
        'GridPrecios
        '
        Me.GridPrecios.DataSource = Me.TblPreciosCompetenciaBindingSource1
        Me.GridPrecios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPrecios.Location = New System.Drawing.Point(2, 20)
        Me.GridPrecios.MainView = Me.GridViewPrecios
        Me.GridPrecios.Name = "GridPrecios"
        Me.GridPrecios.Size = New System.Drawing.Size(606, 362)
        Me.GridPrecios.TabIndex = 0
        Me.GridPrecios.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPrecios})
        '
        'TblPreciosCompetenciaBindingSource1
        '
        Me.TblPreciosCompetenciaBindingSource1.DataMember = "tblPreciosCompetencia"
        Me.TblPreciosCompetenciaBindingSource1.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'DSPRODUCTOSBindingSource
        '
        Me.DSPRODUCTOSBindingSource.DataSource = Me.DSPRODUCTOS
        Me.DSPRODUCTOSBindingSource.Position = 0
        '
        'DSPRODUCTOS
        '
        Me.DSPRODUCTOS.DataSetName = "DSPRODUCTOS"
        Me.DSPRODUCTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewPrecios
        '
        Me.GridViewPrecios.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colPROVEEDOR, Me.colDIRECCION, Me.colTELEFONOS, Me.colPRECIO, Me.colFECHA, Me.colOBS})
        Me.GridViewPrecios.GridControl = Me.GridPrecios
        Me.GridViewPrecios.Name = "GridViewPrecios"
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        '
        'colPROVEEDOR
        '
        Me.colPROVEEDOR.FieldName = "PROVEEDOR"
        Me.colPROVEEDOR.Name = "colPROVEEDOR"
        Me.colPROVEEDOR.Visible = True
        Me.colPROVEEDOR.VisibleIndex = 0
        Me.colPROVEEDOR.Width = 166
        '
        'colDIRECCION
        '
        Me.colDIRECCION.FieldName = "DIRECCION"
        Me.colDIRECCION.Name = "colDIRECCION"
        Me.colDIRECCION.Visible = True
        Me.colDIRECCION.VisibleIndex = 1
        Me.colDIRECCION.Width = 145
        '
        'colTELEFONOS
        '
        Me.colTELEFONOS.FieldName = "TELEFONOS"
        Me.colTELEFONOS.Name = "colTELEFONOS"
        Me.colTELEFONOS.Visible = True
        Me.colTELEFONOS.VisibleIndex = 2
        Me.colTELEFONOS.Width = 93
        '
        'colPRECIO
        '
        Me.colPRECIO.FieldName = "PRECIO"
        Me.colPRECIO.Name = "colPRECIO"
        Me.colPRECIO.Visible = True
        Me.colPRECIO.VisibleIndex = 3
        Me.colPRECIO.Width = 92
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 4
        Me.colFECHA.Width = 92
        '
        'colOBS
        '
        Me.colOBS.FieldName = "OBS"
        Me.colOBS.Name = "colOBS"
        Me.colOBS.Visible = True
        Me.colOBS.VisibleIndex = 5
        '
        'TblPreciosCompetenciaBindingSource
        '
        Me.TblPreciosCompetenciaBindingSource.DataMember = "tblPreciosCompetencia"
        Me.TblPreciosCompetenciaBindingSource.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.txtProveedor)
        Me.GroupControl2.Controls.Add(Me.txtFecha)
        Me.GroupControl2.Controls.Add(Me.btnAgregar)
        Me.GroupControl2.Controls.Add(Me.LabelControl8)
        Me.GroupControl2.Controls.Add(Me.LabelControl7)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.LabelControl5)
        Me.GroupControl2.Controls.Add(Me.LabelControl4)
        Me.GroupControl2.Controls.Add(Me.LabelControl3)
        Me.GroupControl2.Controls.Add(Me.txtPrecio)
        Me.GroupControl2.Controls.Add(Me.txtObs)
        Me.GroupControl2.Controls.Add(Me.txtTels)
        Me.GroupControl2.Controls.Add(Me.txtDireccion)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(273, 384)
        Me.GroupControl2.TabIndex = 3
        Me.GroupControl2.Text = "Nuevo Registro"
        '
        'txtProveedor
        '
        Me.txtProveedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtProveedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtProveedor.FormattingEnabled = True
        Me.txtProveedor.Location = New System.Drawing.Point(17, 66)
        Me.txtProveedor.Name = "txtProveedor"
        Me.txtProveedor.Size = New System.Drawing.Size(242, 21)
        Me.txtProveedor.TabIndex = 13
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Enabled = False
        Me.txtFecha.Location = New System.Drawing.Point(159, 23)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Properties.Appearance.Options.UseFont = True
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(100, 18)
        Me.txtFecha.TabIndex = 12
        '
        'btnAgregar
        '
        Me.btnAgregar.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnAgregar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnAgregar.Appearance.Options.UseBackColor = True
        Me.btnAgregar.Appearance.Options.UseForeColor = True
        Me.btnAgregar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnAgregar.Image = Global.Ares.My.Resources.Resources.bt21
        Me.btnAgregar.Location = New System.Drawing.Point(128, 307)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(131, 58)
        Me.btnAgregar.TabIndex = 11
        Me.btnAgregar.Text = "Agregar"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(122, 259)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl8.TabIndex = 10
        Me.LabelControl8.Text = "Q"
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(77, 261)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl7.TabIndex = 9
        Me.LabelControl7.Text = "Precio:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(17, 197)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(75, 13)
        Me.LabelControl6.TabIndex = 8
        Me.LabelControl6.Text = "Observaciones;"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 148)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(51, 13)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "Teléfonos:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 100)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(47, 13)
        Me.LabelControl4.TabIndex = 6
        Me.LabelControl4.Text = "Dirección:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 51)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(54, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Proveedor:"
        '
        'txtPrecio
        '
        Me.txtPrecio.EnterMoveNextControl = True
        Me.txtPrecio.Location = New System.Drawing.Point(142, 258)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.Properties.Appearance.Options.UseFont = True
        Me.txtPrecio.Properties.Mask.EditMask = "n2"
        Me.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPrecio.Size = New System.Drawing.Size(117, 30)
        Me.txtPrecio.TabIndex = 4
        '
        'txtObs
        '
        Me.txtObs.EnterMoveNextControl = True
        Me.txtObs.Location = New System.Drawing.Point(17, 216)
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(242, 20)
        Me.txtObs.TabIndex = 3
        '
        'txtTels
        '
        Me.txtTels.EnterMoveNextControl = True
        Me.txtTels.Location = New System.Drawing.Point(17, 167)
        Me.txtTels.Name = "txtTels"
        Me.txtTels.Size = New System.Drawing.Size(242, 20)
        Me.txtTels.TabIndex = 2
        '
        'txtDireccion
        '
        Me.txtDireccion.EnterMoveNextControl = True
        Me.txtDireccion.Location = New System.Drawing.Point(17, 119)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(242, 20)
        Me.txtDireccion.TabIndex = 1
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Location = New System.Drawing.Point(821, 7)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(77, 35)
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Text = "Cerrar(x)"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(14, 54)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupControl2)
        Me.SplitContainer1.Size = New System.Drawing.Size(890, 384)
        Me.SplitContainer1.SplitterDistance = 610
        Me.SplitContainer1.SplitterWidth = 7
        Me.SplitContainer1.TabIndex = 5
        '
        'viewProductosPreciosCompetencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.lbDesprod)
        Me.Name = "viewProductosPreciosCompetencia"
        Me.Size = New System.Drawing.Size(922, 450)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblPreciosCompetenciaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblPreciosCompetenciaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrecio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTels.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbDesprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridPrecios As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPrecios As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPrecio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtObs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTels As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDireccion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TblPreciosCompetenciaBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOSBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOS As DSPRODUCTOS
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPROVEEDOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDIRECCION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTELEFONOS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents TblPreciosCompetenciaBindingSource1 As BindingSource
    Friend WithEvents colOBS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtProveedor As ComboBox
End Class
