<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewCxcAbonos
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
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.GridAbonos = New DevExpress.XtraGrid.GridControl()
        Me.TblAbonosFacturaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSGeneral = New Ares.DSGeneral()
        Me.GridViewAbonos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colFECHA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCODDOC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCORRELATIVO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTOTALPRECIO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNOMVEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lbNit = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LbAbonos = New DevExpress.XtraEditors.LabelControl()
        Me.LbSaldo = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalFactura = New DevExpress.XtraEditors.LabelControl()
        Me.LbCliente = New DevExpress.XtraEditors.LabelControl()
        Me.lbFactura = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblAbonosFacturaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Image = Global.Ares.My.Resources.Resources.btExito
        Me.btnAceptar.Location = New System.Drawing.Point(560, 343)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(132, 52)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        '
        'GridAbonos
        '
        Me.GridAbonos.DataSource = Me.TblAbonosFacturaBindingSource
        Me.GridAbonos.Location = New System.Drawing.Point(232, 97)
        Me.GridAbonos.MainView = Me.GridViewAbonos
        Me.GridAbonos.Name = "GridAbonos"
        Me.GridAbonos.Size = New System.Drawing.Size(460, 229)
        Me.GridAbonos.TabIndex = 7
        Me.GridAbonos.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAbonos})
        '
        'TblAbonosFacturaBindingSource
        '
        Me.TblAbonosFacturaBindingSource.DataMember = "tblAbonosFactura"
        Me.TblAbonosFacturaBindingSource.DataSource = Me.DSGeneral
        '
        'DSGeneral
        '
        Me.DSGeneral.DataSetName = "DSGeneral"
        Me.DSGeneral.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridViewAbonos
        '
        Me.GridViewAbonos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colFECHA, Me.colCODDOC, Me.colCORRELATIVO, Me.colTOTALPRECIO, Me.colNOMVEN})
        Me.GridViewAbonos.GridControl = Me.GridAbonos
        Me.GridViewAbonos.Name = "GridViewAbonos"
        Me.GridViewAbonos.OptionsBehavior.Editable = False
        Me.GridViewAbonos.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewAbonos.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewAbonos.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridViewAbonos.OptionsSelection.EnableAppearanceFocusedCell = False
        '
        'colFECHA
        '
        Me.colFECHA.FieldName = "FECHA"
        Me.colFECHA.Name = "colFECHA"
        Me.colFECHA.Visible = True
        Me.colFECHA.VisibleIndex = 0
        Me.colFECHA.Width = 84
        '
        'colCODDOC
        '
        Me.colCODDOC.Caption = "DOCUMENTO"
        Me.colCODDOC.FieldName = "CODDOC"
        Me.colCODDOC.Name = "colCODDOC"
        Me.colCODDOC.Visible = True
        Me.colCODDOC.VisibleIndex = 1
        Me.colCODDOC.Width = 84
        '
        'colCORRELATIVO
        '
        Me.colCORRELATIVO.Caption = "NÚMERO"
        Me.colCORRELATIVO.FieldName = "CORRELATIVO"
        Me.colCORRELATIVO.Name = "colCORRELATIVO"
        Me.colCORRELATIVO.Visible = True
        Me.colCORRELATIVO.VisibleIndex = 2
        Me.colCORRELATIVO.Width = 82
        '
        'colTOTALPRECIO
        '
        Me.colTOTALPRECIO.Caption = "VALOR"
        Me.colTOTALPRECIO.FieldName = "TOTALPRECIO"
        Me.colTOTALPRECIO.Name = "colTOTALPRECIO"
        Me.colTOTALPRECIO.Visible = True
        Me.colTOTALPRECIO.VisibleIndex = 3
        Me.colTOTALPRECIO.Width = 92
        '
        'colNOMVEN
        '
        Me.colNOMVEN.Caption = "VENDEDOR"
        Me.colNOMVEN.FieldName = "NOMVEN"
        Me.colNOMVEN.Name = "colNOMVEN"
        Me.colNOMVEN.Visible = True
        Me.colNOMVEN.VisibleIndex = 4
        Me.colNOMVEN.Width = 100
        '
        'lbNit
        '
        Me.lbNit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNit.Location = New System.Drawing.Point(93, 64)
        Me.lbNit.Name = "lbNit"
        Me.lbNit.Size = New System.Drawing.Size(15, 16)
        Me.lbNit.TabIndex = 30
        Me.lbNit.Text = "CF"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(14, 64)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(25, 16)
        Me.LabelControl11.TabIndex = 29
        Me.LabelControl11.Text = "NIT:"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl8.Location = New System.Drawing.Point(73, 288)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(12, 19)
        Me.LabelControl8.TabIndex = 28
        Me.LabelControl8.Text = "Q"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl7.Location = New System.Drawing.Point(73, 225)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(12, 19)
        Me.LabelControl7.TabIndex = 27
        Me.LabelControl7.Text = "Q"
        '
        'LbAbonos
        '
        Me.LbAbonos.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbAbonos.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbAbonos.Location = New System.Drawing.Point(90, 288)
        Me.LbAbonos.Name = "LbAbonos"
        Me.LbAbonos.Size = New System.Drawing.Size(105, 19)
        Me.LbAbonos.TabIndex = 26
        Me.LbAbonos.Text = "9,999,999.99"
        '
        'LbSaldo
        '
        Me.LbSaldo.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSaldo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbSaldo.Location = New System.Drawing.Point(90, 225)
        Me.LbSaldo.Name = "LbSaldo"
        Me.LbSaldo.Size = New System.Drawing.Size(105, 19)
        Me.LbSaldo.TabIndex = 25
        Me.LbSaldo.Text = "9,999,999.99"
        '
        'lbTotalFactura
        '
        Me.lbTotalFactura.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalFactura.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbTotalFactura.Location = New System.Drawing.Point(73, 158)
        Me.lbTotalFactura.Name = "lbTotalFactura"
        Me.lbTotalFactura.Size = New System.Drawing.Size(122, 19)
        Me.lbTotalFactura.TabIndex = 24
        Me.lbTotalFactura.Text = "Q 9,999,999.99"
        '
        'LbCliente
        '
        Me.LbCliente.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCliente.Location = New System.Drawing.Point(93, 40)
        Me.LbCliente.Name = "LbCliente"
        Me.LbCliente.Size = New System.Drawing.Size(99, 16)
        Me.LbCliente.TabIndex = 23
        Me.LbCliente.Text = "Consumidor Final"
        '
        'lbFactura
        '
        Me.lbFactura.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFactura.Location = New System.Drawing.Point(93, 13)
        Me.lbFactura.Name = "lbFactura"
        Me.lbFactura.Size = New System.Drawing.Size(100, 16)
        Me.lbFactura.TabIndex = 22
        Me.lbFactura.Text = "FACA1 - 1000000"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(28, 261)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(90, 16)
        Me.LabelControl5.TabIndex = 21
        Me.LabelControl5.Text = "Total Abonos:"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(14, 13)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 16)
        Me.LabelControl1.TabIndex = 17
        Me.LabelControl1.Text = "Factura:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(28, 198)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(86, 16)
        Me.LabelControl4.TabIndex = 20
        Me.LabelControl4.Text = "Saldo Actual:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(14, 40)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(49, 16)
        Me.LabelControl2.TabIndex = 18
        Me.LabelControl2.Text = "Cliente:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(28, 134)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(80, 16)
        Me.LabelControl3.TabIndex = 19
        Me.LabelControl3.Text = "Total Venta:"
        '
        'ViewCxcAbonos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbNit)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl7)
        Me.Controls.Add(Me.LbAbonos)
        Me.Controls.Add(Me.LbSaldo)
        Me.Controls.Add(Me.lbTotalFactura)
        Me.Controls.Add(Me.LbCliente)
        Me.Controls.Add(Me.lbFactura)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.GridAbonos)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "ViewCxcAbonos"
        Me.Size = New System.Drawing.Size(710, 407)
        CType(Me.GridAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblAbonosFacturaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridAbonos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAbonos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lbNit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbAbonos As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbSaldo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalFactura As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbCliente As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbFactura As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents TblAbonosFacturaBindingSource As BindingSource
    Friend WithEvents DSGeneral As DSGeneral
    Friend WithEvents colFECHA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCODDOC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCORRELATIVO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTOTALPRECIO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNOMVEN As DevExpress.XtraGrid.Columns.GridColumn
End Class
