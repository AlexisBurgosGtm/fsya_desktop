<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewInventariosMinimos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewInventariosMinimos))
        Me.LabelControl35 = New DevExpress.XtraEditors.LabelControl()
        Me.GridMinimos = New DevExpress.XtraGrid.GridControl()
        Me.TblMinimosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSetInventarios = New Ares.DataSetInventarios()
        Me.GridViewMinimos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESPROD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMINIMO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colMAXIMO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALDO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colENTRADAS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colSALIDAS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.SwitchTodosMinimos = New DevExpress.XtraEditors.ToggleSwitch()
        Me.btnImprimir = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridMinimos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblMinimosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewMinimos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.SwitchTodosMinimos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl35
        '
        Me.LabelControl35.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl35.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl35.Location = New System.Drawing.Point(92, 23)
        Me.LabelControl35.Name = "LabelControl35"
        Me.LabelControl35.Size = New System.Drawing.Size(448, 33)
        Me.LabelControl35.TabIndex = 722
        Me.LabelControl35.Text = "Productos sin existencia y en mínimos"
        '
        'GridMinimos
        '
        Me.GridMinimos.DataSource = Me.TblMinimosBindingSource
        Me.GridMinimos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridMinimos.Location = New System.Drawing.Point(2, 20)
        Me.GridMinimos.MainView = Me.GridViewMinimos
        Me.GridMinimos.Name = "GridMinimos"
        Me.GridMinimos.Size = New System.Drawing.Size(1012, 539)
        Me.GridMinimos.TabIndex = 723
        Me.GridMinimos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewMinimos})
        '
        'TblMinimosBindingSource
        '
        Me.TblMinimosBindingSource.DataMember = "tblMinimos"
        Me.TblMinimosBindingSource.DataSource = Me.DataSetInventarios
        '
        'DataSetInventarios
        '
        Me.DataSetInventarios.DataSetName = "DataSetInventarios"
        Me.DataSetInventarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewMinimos
        '
        Me.GridViewMinimos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODPROD, Me.colDESPROD, Me.colMINIMO, Me.colMAXIMO, Me.colSALDO, Me.colENTRADAS, Me.colSALIDAS})
        Me.GridViewMinimos.GridControl = Me.GridMinimos
        Me.GridViewMinimos.Name = "GridViewMinimos"
        Me.GridViewMinimos.OptionsBehavior.Editable = False
        Me.GridViewMinimos.OptionsView.EnableAppearanceEvenRow = True
        Me.GridViewMinimos.OptionsView.ShowAutoFilterRow = True
        '
        'colCODPROD
        '
        Me.colCODPROD.FieldName = "CODPROD"
        Me.colCODPROD.Name = "colCODPROD"
        Me.colCODPROD.Visible = True
        Me.colCODPROD.VisibleIndex = 0
        Me.colCODPROD.Width = 126
        '
        'colDESPROD
        '
        Me.colDESPROD.FieldName = "DESPROD"
        Me.colDESPROD.Name = "colDESPROD"
        Me.colDESPROD.Visible = True
        Me.colDESPROD.VisibleIndex = 1
        Me.colDESPROD.Width = 352
        '
        'colMINIMO
        '
        Me.colMINIMO.FieldName = "MINIMO"
        Me.colMINIMO.Name = "colMINIMO"
        Me.colMINIMO.Visible = True
        Me.colMINIMO.VisibleIndex = 2
        Me.colMINIMO.Width = 94
        '
        'colMAXIMO
        '
        Me.colMAXIMO.FieldName = "MAXIMO"
        Me.colMAXIMO.Name = "colMAXIMO"
        Me.colMAXIMO.Width = 90
        '
        'colSALDO
        '
        Me.colSALDO.Caption = "EXISTENCIA"
        Me.colSALDO.FieldName = "SALDO"
        Me.colSALDO.Name = "colSALDO"
        Me.colSALDO.Visible = True
        Me.colSALDO.VisibleIndex = 3
        Me.colSALDO.Width = 101
        '
        'colENTRADAS
        '
        Me.colENTRADAS.FieldName = "ENTRADAS"
        Me.colENTRADAS.Name = "colENTRADAS"
        Me.colENTRADAS.Visible = True
        Me.colENTRADAS.VisibleIndex = 4
        Me.colENTRADAS.Width = 101
        '
        'colSALIDAS
        '
        Me.colSALIDAS.FieldName = "SALIDAS"
        Me.colSALIDAS.Name = "colSALIDAS"
        Me.colSALIDAS.Visible = True
        Me.colSALIDAS.VisibleIndex = 5
        Me.colSALIDAS.Width = 130
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridMinimos)
        Me.GroupControl1.Location = New System.Drawing.Point(27, 99)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1016, 561)
        Me.GroupControl1.TabIndex = 724
        Me.GroupControl1.Text = "Lista de productos agotados y por agotarse"
        '
        'SwitchTodosMinimos
        '
        Me.SwitchTodosMinimos.EditValue = True
        Me.SwitchTodosMinimos.Location = New System.Drawing.Point(377, 69)
        Me.SwitchTodosMinimos.Name = "SwitchTodosMinimos"
        Me.SwitchTodosMinimos.Properties.OffText = "VER TODOS"
        Me.SwitchTodosMinimos.Properties.OnText = "VER MINIMOS"
        Me.SwitchTodosMinimos.Size = New System.Drawing.Size(163, 24)
        Me.SwitchTodosMinimos.TabIndex = 725
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
        Me.btnImprimir.Location = New System.Drawing.Point(909, 52)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(132, 41)
        Me.btnImprimir.TabIndex = 726
        Me.btnImprimir.Text = "Imprimir"
        '
        'viewInventariosMinimos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.SwitchTodosMinimos)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.LabelControl35)
        Me.Name = "viewInventariosMinimos"
        Me.Size = New System.Drawing.Size(1090, 696)
        CType(Me.GridMinimos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblMinimosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewMinimos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.SwitchTodosMinimos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl35 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridMinimos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewMinimos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TblMinimosBindingSource As BindingSource
    Friend WithEvents DataSetInventarios As DataSetInventarios
    Friend WithEvents colCODPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESPROD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMINIMO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colMAXIMO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALDO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colENTRADAS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colSALIDAS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SwitchTodosMinimos As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents btnImprimir As DevExpress.XtraEditors.SimpleButton
End Class
