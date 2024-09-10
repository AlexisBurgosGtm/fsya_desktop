<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class viewProductosOnlineAdicionales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewProductosOnlineAdicionales))
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.gridDetalles = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetalles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lbCodprod = New DevExpress.XtraEditors.LabelControl()
        Me.lbDesprod = New DevExpress.XtraEditors.LabelControl()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.txtMaximo = New DevExpress.XtraEditors.TextEdit()
        Me.txtMinimo = New DevExpress.XtraEditors.TextEdit()
        Me.cmbHabilitado = New System.Windows.Forms.ComboBox()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCerrar = New DevExpress.XtraEditors.SimpleButton()
        Me.DSPRODUCTOS = New Ares.DSPRODUCTOS()
        Me.TblProductosAdicionalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colEMPNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colEMPNOMBRE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINVMINIMO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINVMAXIMO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colHABILITADO = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.gridDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaximo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMinimo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblProductosAdicionalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.gridDetalles)
        Me.GroupControl2.Location = New System.Drawing.Point(15, 128)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(876, 369)
        Me.GroupControl2.TabIndex = 1
        Me.GroupControl2.Text = "Detalles adicionales del producto"
        '
        'gridDetalles
        '
        Me.gridDetalles.DataSource = Me.TblProductosAdicionalBindingSource
        Me.gridDetalles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDetalles.Location = New System.Drawing.Point(2, 20)
        Me.gridDetalles.MainView = Me.GridViewDetalles
        Me.gridDetalles.Name = "gridDetalles"
        Me.gridDetalles.Size = New System.Drawing.Size(872, 347)
        Me.gridDetalles.TabIndex = 0
        Me.gridDetalles.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetalles})
        '
        'GridViewDetalles
        '
        Me.GridViewDetalles.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEMPNIT, Me.colEMPNOMBRE, Me.colCODPROD, Me.colDESPROD, Me.colINVMINIMO, Me.colINVMAXIMO, Me.colHABILITADO})
        Me.GridViewDetalles.GridControl = Me.gridDetalles
        Me.GridViewDetalles.Name = "GridViewDetalles"
        Me.GridViewDetalles.OptionsBehavior.Editable = False
        Me.GridViewDetalles.OptionsView.ShowAutoFilterRow = True
        '
        'lbCodprod
        '
        Me.lbCodprod.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lbCodprod.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCodprod.Location = New System.Drawing.Point(29, 43)
        Me.lbCodprod.Name = "lbCodprod"
        Me.lbCodprod.Size = New System.Drawing.Size(112, 13)
        Me.lbCodprod.TabIndex = 2
        Me.lbCodprod.Text = "Codigo del Producto"
        '
        'lbDesprod
        '
        Me.lbDesprod.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesprod.Location = New System.Drawing.Point(29, 17)
        Me.lbDesprod.Name = "lbDesprod"
        Me.lbDesprod.Size = New System.Drawing.Size(172, 19)
        Me.lbDesprod.TabIndex = 3
        Me.lbDesprod.Text = "Nombre del Producto"
        '
        'cmbSucursal
        '
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(15, 87)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(345, 21)
        Me.cmbSucursal.TabIndex = 4
        '
        'txtMaximo
        '
        Me.txtMaximo.Location = New System.Drawing.Point(367, 87)
        Me.txtMaximo.Name = "txtMaximo"
        Me.txtMaximo.Properties.Mask.EditMask = "n0"
        Me.txtMaximo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMaximo.Size = New System.Drawing.Size(90, 20)
        Me.txtMaximo.TabIndex = 5
        '
        'txtMinimo
        '
        Me.txtMinimo.Location = New System.Drawing.Point(473, 87)
        Me.txtMinimo.Name = "txtMinimo"
        Me.txtMinimo.Properties.Mask.EditMask = "n0"
        Me.txtMinimo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMinimo.Size = New System.Drawing.Size(90, 20)
        Me.txtMinimo.TabIndex = 6
        '
        'cmbHabilitado
        '
        Me.cmbHabilitado.FormattingEnabled = True
        Me.cmbHabilitado.Items.AddRange(New Object() {"SI", "NO"})
        Me.cmbHabilitado.Location = New System.Drawing.Point(578, 86)
        Me.cmbHabilitado.MaxLength = 2
        Me.cmbHabilitado.Name = "cmbHabilitado"
        Me.cmbHabilitado.Size = New System.Drawing.Size(58, 21)
        Me.cmbHabilitado.TabIndex = 7
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl3.Location = New System.Drawing.Point(15, 72)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(48, 13)
        Me.LabelControl3.TabIndex = 8
        Me.LabelControl3.Text = "Sucursal"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(366, 72)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(76, 13)
        Me.LabelControl4.TabIndex = 9
        Me.LabelControl4.Text = "Máximo(Uns)"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl5.Location = New System.Drawing.Point(472, 72)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(72, 13)
        Me.LabelControl5.TabIndex = 10
        Me.LabelControl5.Text = "Mínimo(Uns)"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl6.Location = New System.Drawing.Point(578, 72)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl6.TabIndex = 11
        Me.LabelControl6.Text = "Habilitado"
        '
        'btnAgregar
        '
        Me.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.Location = New System.Drawing.Point(658, 75)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(88, 38)
        Me.btnAgregar.TabIndex = 12
        Me.btnAgregar.Text = "Agregar"
        '
        'btnCerrar
        '
        Me.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.Location = New System.Drawing.Point(743, 503)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(148, 38)
        Me.btnCerrar.TabIndex = 13
        Me.btnCerrar.Text = "CERRAR (X)"
        '
        'DSPRODUCTOS
        '
        Me.DSPRODUCTOS.DataSetName = "DSPRODUCTOS"
        Me.DSPRODUCTOS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TblProductosAdicionalBindingSource
        '
        Me.TblProductosAdicionalBindingSource.DataMember = "tblProductosAdicional"
        Me.TblProductosAdicionalBindingSource.DataSource = Me.DSPRODUCTOS
        '
        'colEMPNIT
        '
        Me.colEMPNIT.FieldName = "EMPNIT"
        Me.colEMPNIT.Name = "colEMPNIT"
        Me.colEMPNIT.Visible = True
        Me.colEMPNIT.VisibleIndex = 0
        Me.colEMPNIT.Width = 62
        '
        'colEMPNOMBRE
        '
        Me.colEMPNOMBRE.FieldName = "EMPNOMBRE"
        Me.colEMPNOMBRE.Name = "colEMPNOMBRE"
        Me.colEMPNOMBRE.Visible = True
        Me.colEMPNOMBRE.VisibleIndex = 1
        Me.colEMPNOMBRE.Width = 163
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 2
        Me.colCODPROD.Width = 94
        '
        'colDESPROD
        '
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 3
        Me.colDESPROD.Width = 222
        '
        'colINVMINIMO
        '
        Me.colINVMINIMO.FieldName = "INVMINIMO"
        Me.colINVMINIMO.Name = "colINVMINIMO"
        Me.colINVMINIMO.Visible = True
        Me.colINVMINIMO.VisibleIndex = 4
        Me.colINVMINIMO.Width = 67
        '
        'colINVMAXIMO
        '
        Me.colINVMAXIMO.FieldName = "INVMAXIMO"
        Me.colINVMAXIMO.Name = "colINVMAXIMO"
        Me.colINVMAXIMO.Visible = True
        Me.colINVMAXIMO.VisibleIndex = 5
        Me.colINVMAXIMO.Width = 76
        '
        'colHABILITADO
        '
        Me.colHABILITADO.FieldName = "HABILITADO"
        Me.colHABILITADO.Name = "colHABILITADO"
        Me.colHABILITADO.Visible = True
        Me.colHABILITADO.VisibleIndex = 6
        Me.colHABILITADO.Width = 82
        '
        'viewProductosOnlineAdicionales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cmbHabilitado)
        Me.Controls.Add(Me.txtMinimo)
        Me.Controls.Add(Me.txtMaximo)
        Me.Controls.Add(Me.cmbSucursal)
        Me.Controls.Add(Me.lbDesprod)
        Me.Controls.Add(Me.lbCodprod)
        Me.Controls.Add(Me.GroupControl2)
        Me.Name = "viewProductosOnlineAdicionales"
        Me.Size = New System.Drawing.Size(916, 544)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.gridDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaximo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMinimo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblProductosAdicionalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbCodprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbDesprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbSucursal As ComboBox
    Friend WithEvents txtMaximo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMinimo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbHabilitado As ComboBox
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Private WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridDetalles As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetalles As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents btnCerrar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TblProductosAdicionalBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOS As DSPRODUCTOS
    Friend WithEvents colEMPNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colEMPNOMBRE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINVMINIMO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINVMAXIMO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colHABILITADO As DevExpress.XtraGrid.Columns.GridColumn
End Class
