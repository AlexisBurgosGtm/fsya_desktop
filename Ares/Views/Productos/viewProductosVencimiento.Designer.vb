<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewProductosVencimiento
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
        Me.TblVencimientosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSPRODUCTOS = New Ares.DSPRODUCTOS()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GridVencidos = New DevExpress.XtraGrid.GridControl()
        Me.TblVencimientosBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GridViewVence = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESMARCA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFECHAVENCE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.btnCerrar = New DevExpress.XtraEditors.SimpleButton()
        Me.SwitchFiltro = New DevExpress.XtraEditors.ToggleSwitch()
        CType(Me.TblVencimientosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridVencidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblVencimientosBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewVence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwitchFiltro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TblVencimientosBindingSource
        '
        Me.TblVencimientosBindingSource.DataMember = "tblVencimientos"
        Me.TblVencimientosBindingSource.DataSource = Me.DSPRODUCTOSBindingSource
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
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(88, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(388, 19)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Indique la fecha de Vencimiento de su Producto"
        '
        'GridVencidos
        '
        Me.GridVencidos.DataSource = Me.TblVencimientosBindingSource1
        Me.GridVencidos.Location = New System.Drawing.Point(41, 109)
        Me.GridVencidos.MainView = Me.GridViewVence
        Me.GridVencidos.Name = "GridVencidos"
        Me.GridVencidos.Size = New System.Drawing.Size(1011, 539)
        Me.GridVencidos.TabIndex = 2
        Me.GridVencidos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewVence})
        '
        'TblVencimientosBindingSource1
        '
        Me.TblVencimientosBindingSource1.DataMember = "tblVencimientos"
        Me.TblVencimientosBindingSource1.DataSource = Me.DSPRODUCTOSBindingSource
        '
        'GridViewVence
        '
        Me.GridViewVence.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colDESMARCA, Me.colSALDO, Me.colFECHAVENCE})
        Me.GridViewVence.GridControl = Me.GridVencidos
        Me.GridViewVence.Name = "GridViewVence"
        Me.GridViewVence.OptionsView.ShowAutoFilterRow = True
        '
        'colCODPROD
        '
        Me.colCODPROD.Caption = "CODIGO"
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 179
        '
        'colDESPROD
        '
        Me.colDESPROD.Caption = "PRODUCTO"
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 371
        '
        'colDESMARCA
        '
        Me.colDESMARCA.Caption = "MARCA"
        Me.colDESMARCA.FieldName = "DESMARCA"
        Me.colDESMARCA.Name = "colDESMARCA"
        Me.colDESMARCA.Visible = True
        Me.colDESMARCA.VisibleIndex = 2
        Me.colDESMARCA.Width = 153
        '
        'colSALDO
        '
        Me.colSALDO.Caption = "EXISTENCIA"
        Me.colSALDO.FieldName = "SALDO"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Visible = True
        Me.colSALDO.VisibleIndex = 3
        Me.colSALDO.Width = 131
        '
        'colFECHAVENCE
        '
        Me.colFECHAVENCE.Caption = "VENCE"
        Me.colFECHAVENCE.FieldName = "FECHAVENCE"
        Me.colFECHAVENCE.Name = "colFECHAVENCE"
        Me.colFECHAVENCE.Visible = True
        Me.colFECHAVENCE.VisibleIndex = 4
        Me.colFECHAVENCE.Width = 150
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(88, 45)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(442, 13)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Cambie la fecha de Vencimiento en la columna ""vence"" y  luego indique si desdea a" &
    "ctualizarla"
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(916, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(28, 21)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "x"
        Me.btnCerrar.Visible = False
        '
        'SwitchFiltro
        '
        Me.SwitchFiltro.EditValue = True
        Me.SwitchFiltro.Location = New System.Drawing.Point(881, 79)
        Me.SwitchFiltro.Name = "SwitchFiltro"
        Me.SwitchFiltro.Properties.OffText = "TODOS"
        Me.SwitchFiltro.Properties.OnText = "POR VENCER"
        Me.SwitchFiltro.Size = New System.Drawing.Size(160, 24)
        Me.SwitchFiltro.TabIndex = 7
        '
        'viewProductosVencimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SwitchFiltro)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.GridVencidos)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "viewProductosVencimiento"
        Me.Size = New System.Drawing.Size(1090, 696)
        CType(Me.TblVencimientosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSPRODUCTOS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridVencidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblVencimientosBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewVence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwitchFiltro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblVencimientosBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOSBindingSource As BindingSource
    Friend WithEvents DSPRODUCTOS As DSPRODUCTOS
    Friend WithEvents GridVencidos As DevExpress.XtraGrid.GridControl
    Friend WithEvents TblVencimientosBindingSource1 As BindingSource
    Friend WithEvents GridViewVence As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESMARCA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFECHAVENCE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnCerrar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SwitchFiltro As DevExpress.XtraEditors.ToggleSwitch
End Class
