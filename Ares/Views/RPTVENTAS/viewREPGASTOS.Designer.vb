<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewREPGASTOS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewREPGASTOS))
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.gridENTRADAS = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnRECARGAR = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExportarDataProductos = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.gridENTRADAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(332, 43)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(151, 19)
        Me.LabelControl1.TabIndex = 245
        Me.LabelControl1.Text = "Reporte de Gastos"
        '
        'gridENTRADAS
        '
        Me.gridENTRADAS.Location = New System.Drawing.Point(19, 110)
        Me.gridENTRADAS.MainView = Me.GridView1
        Me.gridENTRADAS.Name = "gridENTRADAS"
        Me.gridENTRADAS.Size = New System.Drawing.Size(1038, 566)
        Me.gridENTRADAS.TabIndex = 242
        Me.gridENTRADAS.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridENTRADAS
        Me.GridView1.Name = "GridView1"
        '
        'btnRECARGAR
        '
        Me.btnRECARGAR.Appearance.BackColor = System.Drawing.Color.Gainsboro
        Me.btnRECARGAR.Appearance.BorderColor = System.Drawing.Color.Black
        Me.btnRECARGAR.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btnRECARGAR.Appearance.Options.UseBackColor = True
        Me.btnRECARGAR.Appearance.Options.UseBorderColor = True
        Me.btnRECARGAR.Appearance.Options.UseForeColor = True
        Me.btnRECARGAR.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnRECARGAR.Image = Global.Ares.XRDesignRibbonControllerResources.RibbonUserDesigner_HtmlFindLarge
        Me.btnRECARGAR.Location = New System.Drawing.Point(726, 24)
        Me.btnRECARGAR.Name = "btnRECARGAR"
        Me.btnRECARGAR.Size = New System.Drawing.Size(185, 62)
        Me.btnRECARGAR.TabIndex = 244
        Me.btnRECARGAR.Text = "Consultar otra Fecha"
        '
        'btnExportarDataProductos
        '
        Me.btnExportarDataProductos.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExportarDataProductos.Appearance.ForeColor = System.Drawing.Color.Green
        Me.btnExportarDataProductos.Appearance.Options.UseBackColor = True
        Me.btnExportarDataProductos.Appearance.Options.UseForeColor = True
        Me.btnExportarDataProductos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.btnExportarDataProductos.Image = CType(resources.GetObject("btnExportarDataProductos.Image"), System.Drawing.Image)
        Me.btnExportarDataProductos.Location = New System.Drawing.Point(917, 24)
        Me.btnExportarDataProductos.Name = "btnExportarDataProductos"
        Me.btnExportarDataProductos.Size = New System.Drawing.Size(140, 62)
        Me.btnExportarDataProductos.TabIndex = 243
        Me.btnExportarDataProductos.Text = "Exportar a Excel"
        '
        'viewREPGASTOS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnRECARGAR)
        Me.Controls.Add(Me.btnExportarDataProductos)
        Me.Controls.Add(Me.gridENTRADAS)
        Me.Name = "viewREPGASTOS"
        Me.Size = New System.Drawing.Size(1077, 696)
        CType(Me.gridENTRADAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnRECARGAR As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExportarDataProductos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents gridENTRADAS As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
