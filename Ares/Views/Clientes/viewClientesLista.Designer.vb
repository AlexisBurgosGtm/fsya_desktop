<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewClientesLista
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
        Me.GridClientes = New DevExpress.XtraGrid.GridControl()
        Me.TblClientesListaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewClientes = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCODCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMBRECLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDIRCLIENTE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESMUNICIPIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDESDEPARTAMENTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODCLIE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCATEGORIA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.codDIAVISITA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.codHABILITADO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNEGOCIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TblClientesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblClientesListaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblClientesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridClientes
        '
        Me.GridClientes.DataSource = Me.TblClientesListaBindingSource
        Me.GridClientes.Location = New System.Drawing.Point(9, 35)
        Me.GridClientes.MainView = Me.GridViewClientes
        Me.GridClientes.Name = "GridClientes"
        Me.GridClientes.Size = New System.Drawing.Size(888, 417)
        Me.GridClientes.TabIndex = 0
        Me.GridClientes.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewClientes})
        '
        'TblClientesListaBindingSource
        '
        Me.TblClientesListaBindingSource.DataMember = "tblClientesLista"
        Me.TblClientesListaBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewClientes
        '
        Me.GridViewClientes.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCODCLIENTE, Me.colNIT, Me.colNOMBRECLIENTE, Me.colDIRCLIENTE, Me.colDESMUNICIPIO, Me.colDESDEPARTAMENTO, Me.colCODCLIE, Me.colCATEGORIA, Me.codDIAVISITA, Me.codHABILITADO, Me.colNEGOCIO})
        Me.GridViewClientes.GridControl = Me.GridClientes
        Me.GridViewClientes.Name = "GridViewClientes"
        Me.GridViewClientes.OptionsBehavior.Editable = False
        Me.GridViewClientes.OptionsView.ShowAutoFilterRow = True
        '
        'colCODCLIENTE
        '
        Me.colCODCLIENTE.FieldName = "CODCLIENTE"
        Me.colCODCLIENTE.Name = "colCODCLIENTE"
        '
        'colNIT
        '
        Me.colNIT.Caption = "NIT"
        Me.colNIT.FieldName = "NIT"
        Me.colNIT.Name = "colNIT"
        Me.colNIT.Visible = True
        Me.colNIT.VisibleIndex = 0
        Me.colNIT.Width = 82
        '
        'colNOMBRECLIENTE
        '
        Me.colNOMBRECLIENTE.Caption = "CLIENTE"
        Me.colNOMBRECLIENTE.FieldName = "NOMBRECLIENTE"
        Me.colNOMBRECLIENTE.Name = "colNOMBRECLIENTE"
        Me.colNOMBRECLIENTE.Visible = True
        Me.colNOMBRECLIENTE.VisibleIndex = 1
        Me.colNOMBRECLIENTE.Width = 138
        '
        'colDIRCLIENTE
        '
        Me.colDIRCLIENTE.Caption = "DIRECCION"
        Me.colDIRCLIENTE.FieldName = "DIRCLIENTE"
        Me.colDIRCLIENTE.Name = "colDIRCLIENTE"
        Me.colDIRCLIENTE.Visible = True
        Me.colDIRCLIENTE.VisibleIndex = 2
        Me.colDIRCLIENTE.Width = 113
        '
        'colDESMUNICIPIO
        '
        Me.colDESMUNICIPIO.Caption = "MUNICIPIO"
        Me.colDESMUNICIPIO.FieldName = "DESMUNICIPIO"
        Me.colDESMUNICIPIO.Name = "colDESMUNICIPIO"
        Me.colDESMUNICIPIO.Visible = True
        Me.colDESMUNICIPIO.VisibleIndex = 3
        Me.colDESMUNICIPIO.Width = 80
        '
        'colDESDEPARTAMENTO
        '
        Me.colDESDEPARTAMENTO.Caption = "DEPARTAMENTO"
        Me.colDESDEPARTAMENTO.FieldName = "DESDEPARTAMENTO"
        Me.colDESDEPARTAMENTO.Name = "colDESDEPARTAMENTO"
        Me.colDESDEPARTAMENTO.Visible = True
        Me.colDESDEPARTAMENTO.VisibleIndex = 4
        Me.colDESDEPARTAMENTO.Width = 87
        '
        'colCODCLIE
        '
        Me.colCODCLIE.Caption = "CODIGO"
        Me.colCODCLIE.FieldName = "CODCLIE"
        Me.colCODCLIE.Name = "colCODCLIE"
        Me.colCODCLIE.Width = 92
        '
        'colCATEGORIA
        '
        Me.colCATEGORIA.Caption = "PRECIO"
        Me.colCATEGORIA.FieldName = "CATEGORIA"
        Me.colCATEGORIA.Name = "colCATEGORIA"
        Me.colCATEGORIA.Width = 58
        '
        'codDIAVISITA
        '
        Me.codDIAVISITA.Caption = "DIAVISITA"
        Me.codDIAVISITA.FieldName = "DIAVISITA"
        Me.codDIAVISITA.Name = "codDIAVISITA"
        Me.codDIAVISITA.Width = 73
        '
        'codHABILITADO
        '
        Me.codHABILITADO.Caption = "HABILITADO"
        Me.codHABILITADO.FieldName = "HABILITADO"
        Me.codHABILITADO.Name = "codHABILITADO"
        Me.codHABILITADO.Width = 52
        '
        'colNEGOCIO
        '
        Me.colNEGOCIO.Caption = "NEGOCIO"
        Me.colNEGOCIO.FieldName = "NEGOCIO"
        Me.colNEGOCIO.Name = "colNEGOCIO"
        Me.colNEGOCIO.Width = 147
        '
        'TblClientesBindingSource
        '
        Me.TblClientesBindingSource.DataMember = "tblClientes"
        Me.TblClientesBindingSource.DataSource = Me.DSGeneral
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(287, 477)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(802, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(47, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "x"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(16, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(246, 18)
        Me.LabelControl1.TabIndex = 3
        Me.LabelControl1.Text = "Doble Click para Seleccionar un Cliente"
        '
        'viewClientesLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GridClientes)
        Me.Name = "viewClientesLista"
        Me.Size = New System.Drawing.Size(900, 470)
        CType(Me.GridClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblClientesListaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblClientesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridClientes As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewClientes As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TblClientesBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents colCODCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMBRECLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDIRCLIENTE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESMUNICIPIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDESDEPARTAMENTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODCLIE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents colCATEGORIA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TblClientesListaBindingSource As BindingSource
    Friend WithEvents codDIAVISITA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents codHABILITADO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNEGOCIO As DevExpress.XtraGrid.Columns.GridColumn
End Class
