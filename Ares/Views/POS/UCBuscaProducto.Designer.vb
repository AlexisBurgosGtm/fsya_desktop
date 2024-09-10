<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCBuscaProducto
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
        Me.DGVListaProductos = New System.Windows.Forms.DataGridView()
        Me.txtFiltroDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.DGVListaProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFiltroDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGVListaProductos
        '
        Me.DGVListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVListaProductos.Location = New System.Drawing.Point(24, 121)
        Me.DGVListaProductos.Name = "DGVListaProductos"
        Me.DGVListaProductos.Size = New System.Drawing.Size(776, 271)
        Me.DGVListaProductos.TabIndex = 0
        '
        'txtFiltroDescripcion
        '
        Me.txtFiltroDescripcion.Location = New System.Drawing.Point(237, 61)
        Me.txtFiltroDescripcion.Name = "txtFiltroDescripcion"
        Me.txtFiltroDescripcion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFiltroDescripcion.Properties.Appearance.Options.UseFont = True
        Me.txtFiltroDescripcion.Size = New System.Drawing.Size(343, 26)
        Me.txtFiltroDescripcion.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(53, 63)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(166, 19)
        Me.LabelControl1.TabIndex = 2
        Me.LabelControl1.Text = "Busca por Descripción: "
        '
        'UCBuscaProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtFiltroDescripcion)
        Me.Controls.Add(Me.DGVListaProductos)
        Me.Name = "UCBuscaProducto"
        Me.Size = New System.Drawing.Size(824, 413)
        CType(Me.DGVListaProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFiltroDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGVListaProductos As DataGridView
    Friend WithEvents txtFiltroDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
End Class
