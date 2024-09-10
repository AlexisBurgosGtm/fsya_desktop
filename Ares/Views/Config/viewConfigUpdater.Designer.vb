<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewConfigUpdater
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
        Me.btnTblProveedores = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTblTempVentas = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTblDocumentos = New DevExpress.XtraEditors.SimpleButton()
        Me.btnTipoDocs = New DevExpress.XtraEditors.SimpleButton()
        Me.btnNavegar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPRODUCTOS = New DevExpress.XtraEditors.SimpleButton()
        Me.btnCortes = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'btnTblProveedores
        '
        Me.btnTblProveedores.Location = New System.Drawing.Point(63, 80)
        Me.btnTblProveedores.Name = "btnTblProveedores"
        Me.btnTblProveedores.Size = New System.Drawing.Size(170, 49)
        Me.btnTblProveedores.TabIndex = 0
        Me.btnTblProveedores.Text = "Tabla PROVEEDORES"
        '
        'btnTblTempVentas
        '
        Me.btnTblTempVentas.Location = New System.Drawing.Point(63, 158)
        Me.btnTblTempVentas.Name = "btnTblTempVentas"
        Me.btnTblTempVentas.Size = New System.Drawing.Size(170, 49)
        Me.btnTblTempVentas.TabIndex = 1
        Me.btnTblTempVentas.Text = "Tabla TEMP_VENTAS"
        '
        'btnTblDocumentos
        '
        Me.btnTblDocumentos.Location = New System.Drawing.Point(63, 236)
        Me.btnTblDocumentos.Name = "btnTblDocumentos"
        Me.btnTblDocumentos.Size = New System.Drawing.Size(170, 49)
        Me.btnTblDocumentos.TabIndex = 2
        Me.btnTblDocumentos.Text = "Tabla DOCUMENTOS"
        '
        'btnTipoDocs
        '
        Me.btnTipoDocs.Location = New System.Drawing.Point(257, 80)
        Me.btnTipoDocs.Name = "btnTipoDocs"
        Me.btnTipoDocs.Size = New System.Drawing.Size(170, 49)
        Me.btnTipoDocs.TabIndex = 3
        Me.btnTipoDocs.Text = "Tabla TIPODOCUMENTOS"
        '
        'btnNavegar
        '
        Me.btnNavegar.Location = New System.Drawing.Point(257, 158)
        Me.btnNavegar.Name = "btnNavegar"
        Me.btnNavegar.Size = New System.Drawing.Size(170, 49)
        Me.btnNavegar.TabIndex = 4
        Me.btnNavegar.Text = "Tabla NAVEGAR"
        '
        'btnPRODUCTOS
        '
        Me.btnPRODUCTOS.Location = New System.Drawing.Point(257, 236)
        Me.btnPRODUCTOS.Name = "btnPRODUCTOS"
        Me.btnPRODUCTOS.Size = New System.Drawing.Size(170, 49)
        Me.btnPRODUCTOS.TabIndex = 5
        Me.btnPRODUCTOS.Text = "Tabla PRODUCTOS"
        '
        'btnCortes
        '
        Me.btnCortes.Location = New System.Drawing.Point(451, 80)
        Me.btnCortes.Name = "btnCortes"
        Me.btnCortes.Size = New System.Drawing.Size(170, 49)
        Me.btnCortes.TabIndex = 6
        Me.btnCortes.Text = "Tabla CORTES"
        '
        'viewConfigUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnCortes)
        Me.Controls.Add(Me.btnPRODUCTOS)
        Me.Controls.Add(Me.btnNavegar)
        Me.Controls.Add(Me.btnTipoDocs)
        Me.Controls.Add(Me.btnTblDocumentos)
        Me.Controls.Add(Me.btnTblTempVentas)
        Me.Controls.Add(Me.btnTblProveedores)
        Me.Name = "viewConfigUpdater"
        Me.Size = New System.Drawing.Size(731, 365)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnTblProveedores As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTblTempVentas As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTblDocumentos As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnTipoDocs As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnNavegar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPRODUCTOS As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnCortes As DevExpress.XtraEditors.SimpleButton
End Class
