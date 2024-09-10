<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewInventarioOnline
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
        Me.GridListado = New DevExpress.XtraGrid.GridControl()
        Me.TblInventariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSSync = New Ares.DSSync()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEMPRESA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colINICIAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colENTRADAS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALIDAS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOLOTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.timerColor = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblInventariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSSync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridListado
        '
        Me.GridListado.DataSource = Me.TblInventariosBindingSource
        Me.GridListado.Location = New System.Drawing.Point(18, 55)
        Me.GridListado.MainView = Me.GridView1
        Me.GridListado.Name = "GridListado"
        Me.GridListado.Size = New System.Drawing.Size(851, 426)
        Me.GridListado.TabIndex = 0
        Me.GridListado.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'TblInventariosBindingSource
        '
        Me.TblInventariosBindingSource.DataMember = "tblInventarios"
        Me.TblInventariosBindingSource.DataSource = Me.DSSync
        '
        'DSSync
        '
        Me.DSSync.DataSetName = "DSSync"
        Me.DSSync.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEMPRESA, Me.colCODPROD, Me.colDESPROD, Me.colINICIAL, Me.colENTRADAS, Me.colSALIDAS, Me.colSALDO, Me.colNOLOTE})
        Me.GridView1.GridControl = Me.GridListado
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colEMPRESA
        '
        Me.colEMPRESA.FieldName = "EMPRESA"
        Me.colEMPRESA.Name = "colEMPRESA"
        Me.colEMPRESA.Visible = True
        Me.colEMPRESA.VisibleIndex = 0
        Me.colEMPRESA.Width = 199
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 1
        Me.colCODPROD.Width = 86
        '
        'colDESPROD
        '
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 2
        Me.colDESPROD.Width = 325
        '
        'colINICIAL
        '
        Me.colINICIAL.FieldName = "INICIAL"
        Me.colINICIAL.Name = "colINICIAL"
        '
        'colENTRADAS
        '
        Me.colENTRADAS.FieldName = "ENTRADAS"
        Me.colENTRADAS.Name = "colENTRADAS"
        Me.colENTRADAS.Width = 76
        '
        'colSALIDAS
        '
        Me.colSALIDAS.FieldName = "SALIDAS"
        Me.colSALIDAS.Name = "colSALIDAS"
        Me.colSALIDAS.Width = 66
        '
        'colSALDO
        '
        Me.colSALDO.AppearanceCell.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.colSALDO.AppearanceCell.Options.UseFont = True
        Me.colSALDO.FieldName = "SALDO"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Visible = True
        Me.colSALDO.VisibleIndex = 3
        Me.colSALDO.Width = 61
        '
        'colNOLOTE
        '
        Me.colNOLOTE.FieldName = "NOLOTE"
        Me.colNOLOTE.Name = "colNOLOTE"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(205, 19)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(456, 19)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Inventario del producto seleccionado en otras empresas"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Location = New System.Drawing.Point(827, 13)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(53, 25)
        Me.SimpleButton1.TabIndex = 2
        Me.SimpleButton1.Text = "X"
        '
        'timerColor
        '
        '
        'viewInventarioOnline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridListado)
        Me.Name = "viewInventarioOnline"
        Me.Size = New System.Drawing.Size(883, 494)
        CType(Me.GridListado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblInventariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSSync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridListado As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblInventariosBindingSource As BindingSource
    Friend WithEvents DSSync As DSSync
    Friend WithEvents colEMPRESA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colINICIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colENTRADAS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALIDAS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOLOTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents timerColor As Timer
    Friend WithEvents Timer1 As Timer
End Class
