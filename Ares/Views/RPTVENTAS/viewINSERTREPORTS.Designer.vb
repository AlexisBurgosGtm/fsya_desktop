<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewINSERTREPORTS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewINSERTREPORTS))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        Me.btnINSERTTOTALEXISTENCIAS = New System.Windows.Forms.Button()
        Me.cmbSucursales = New System.Windows.Forms.ComboBox()
        Me.btnEXPORTINV = New System.Windows.Forms.Button()
        Me.gridExports1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.gridExports1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(279, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 21)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "INSERTAR REPORTES"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdRPTVatras
        '
        Me.cmdRPTVatras.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdRPTVatras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdRPTVatras.Image = CType(resources.GetObject("cmdRPTVatras.Image"), System.Drawing.Image)
        Me.cmdRPTVatras.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter
        Me.cmdRPTVatras.Location = New System.Drawing.Point(3, 3)
        Me.cmdRPTVatras.Name = "cmdRPTVatras"
        Me.cmdRPTVatras.Size = New System.Drawing.Size(44, 40)
        Me.cmdRPTVatras.TabIndex = 250
        '
        'btnINSERTTOTALEXISTENCIAS
        '
        Me.btnINSERTTOTALEXISTENCIAS.Location = New System.Drawing.Point(122, 284)
        Me.btnINSERTTOTALEXISTENCIAS.Name = "btnINSERTTOTALEXISTENCIAS"
        Me.btnINSERTTOTALEXISTENCIAS.Size = New System.Drawing.Size(90, 63)
        Me.btnINSERTTOTALEXISTENCIAS.TabIndex = 251
        Me.btnINSERTTOTALEXISTENCIAS.Text = "INSERTAR TOTAL EXISTENCIAS FSYA"
        Me.btnINSERTTOTALEXISTENCIAS.UseVisualStyleBackColor = True
        '
        'cmbSucursales
        '
        Me.cmbSucursales.FormattingEnabled = True
        Me.cmbSucursales.Location = New System.Drawing.Point(122, 22)
        Me.cmbSucursales.Name = "cmbSucursales"
        Me.cmbSucursales.Size = New System.Drawing.Size(151, 21)
        Me.cmbSucursales.TabIndex = 257
        '
        'btnEXPORTINV
        '
        Me.btnEXPORTINV.Location = New System.Drawing.Point(367, 273)
        Me.btnEXPORTINV.Name = "btnEXPORTINV"
        Me.btnEXPORTINV.Size = New System.Drawing.Size(116, 85)
        Me.btnEXPORTINV.TabIndex = 259
        Me.btnEXPORTINV.Text = "EXPORTAR INVENTARIO GENERAL FSYA"
        Me.btnEXPORTINV.UseVisualStyleBackColor = True
        '
        'gridExports1
        '
        Me.gridExports1.Location = New System.Drawing.Point(574, 284)
        Me.gridExports1.MainView = Me.GridView1
        Me.gridExports1.Name = "gridExports1"
        Me.gridExports1.Size = New System.Drawing.Size(400, 200)
        Me.gridExports1.TabIndex = 260
        Me.gridExports1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridExports1
        Me.GridView1.Name = "GridView1"
        '
        'viewINSERTREPORTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.gridExports1)
        Me.Controls.Add(Me.btnEXPORTINV)
        Me.Controls.Add(Me.cmbSucursales)
        Me.Controls.Add(Me.btnINSERTTOTALEXISTENCIAS)
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.Button1)
        Me.Name = "viewINSERTREPORTS"
        Me.Size = New System.Drawing.Size(1032, 563)
        CType(Me.gridExports1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnINSERTTOTALEXISTENCIAS As Button
    Friend WithEvents cmbSucursales As ComboBox
    Friend WithEvents btnEXPORTINV As Button
    Friend WithEvents gridExports1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
