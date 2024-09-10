<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewProductInfo
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
        Me.imgProducto = New DevExpress.XtraEditors.PictureEdit()
        Me.txtProductoFechaVence = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl50 = New DevExpress.XtraEditors.LabelControl()
        Me.LbProductosDesc3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoDescripcion3 = New DevExpress.XtraEditors.TextEdit()
        Me.LbProductosDesc2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoDescripcion2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoDescripcion = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoCodigo2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.txtProductoCodigo = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtMarca = New DevExpress.XtraEditors.TextEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.imgProducto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoFechaVence.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoDescripcion3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoDescripcion2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoCodigo2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProductoCodigo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMarca.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgProducto
        '
        Me.imgProducto.Location = New System.Drawing.Point(18, 21)
        Me.imgProducto.Name = "imgProducto"
        Me.imgProducto.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.imgProducto.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.imgProducto.Properties.ZoomAccelerationFactor = 1.0R
        Me.imgProducto.Size = New System.Drawing.Size(416, 432)
        Me.imgProducto.TabIndex = 0
        '
        'txtProductoFechaVence
        '
        Me.txtProductoFechaVence.EditValue = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.txtProductoFechaVence.EnterMoveNextControl = True
        Me.txtProductoFechaVence.Location = New System.Drawing.Point(389, 281)
        Me.txtProductoFechaVence.Name = "txtProductoFechaVence"
        Me.txtProductoFechaVence.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoFechaVence.Properties.Appearance.Options.UseFont = True
        Me.txtProductoFechaVence.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtProductoFechaVence.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtProductoFechaVence.Size = New System.Drawing.Size(110, 22)
        Me.txtProductoFechaVence.TabIndex = 745
        '
        'LabelControl50
        '
        Me.LabelControl50.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl50.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl50.Location = New System.Drawing.Point(253, 282)
        Me.LabelControl50.Name = "LabelControl50"
        Me.LabelControl50.Size = New System.Drawing.Size(127, 18)
        Me.LabelControl50.TabIndex = 744
        Me.LabelControl50.Text = "Fecha Vencimiento:"
        '
        'LbProductosDesc3
        '
        Me.LbProductosDesc3.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbProductosDesc3.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LbProductosDesc3.Location = New System.Drawing.Point(13, 176)
        Me.LbProductosDesc3.Name = "LbProductosDesc3"
        Me.LbProductosDesc3.Size = New System.Drawing.Size(90, 18)
        Me.LbProductosDesc3.TabIndex = 737
        Me.LbProductosDesc3.Text = "Descripción 3:"
        '
        'txtProductoDescripcion3
        '
        Me.txtProductoDescripcion3.Location = New System.Drawing.Point(118, 173)
        Me.txtProductoDescripcion3.Name = "txtProductoDescripcion3"
        Me.txtProductoDescripcion3.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDescripcion3.Properties.Appearance.Options.UseFont = True
        Me.txtProductoDescripcion3.Size = New System.Drawing.Size(381, 24)
        Me.txtProductoDescripcion3.TabIndex = 743
        '
        'LbProductosDesc2
        '
        Me.LbProductosDesc2.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbProductosDesc2.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LbProductosDesc2.Location = New System.Drawing.Point(13, 139)
        Me.LbProductosDesc2.Name = "LbProductosDesc2"
        Me.LbProductosDesc2.Size = New System.Drawing.Size(90, 18)
        Me.LbProductosDesc2.TabIndex = 736
        Me.LbProductosDesc2.Text = "Descripción 2:"
        '
        'txtProductoDescripcion2
        '
        Me.txtProductoDescripcion2.Location = New System.Drawing.Point(118, 136)
        Me.txtProductoDescripcion2.Name = "txtProductoDescripcion2"
        Me.txtProductoDescripcion2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDescripcion2.Properties.Appearance.Options.UseFont = True
        Me.txtProductoDescripcion2.Size = New System.Drawing.Size(381, 24)
        Me.txtProductoDescripcion2.TabIndex = 742
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl18.Location = New System.Drawing.Point(13, 105)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(77, 18)
        Me.LabelControl18.TabIndex = 735
        Me.LabelControl18.Text = "Descripción:"
        '
        'txtProductoDescripcion
        '
        Me.txtProductoDescripcion.Location = New System.Drawing.Point(118, 102)
        Me.txtProductoDescripcion.Name = "txtProductoDescripcion"
        Me.txtProductoDescripcion.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoDescripcion.Properties.Appearance.Options.UseFont = True
        Me.txtProductoDescripcion.Size = New System.Drawing.Size(381, 24)
        Me.txtProductoDescripcion.TabIndex = 741
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl16.Location = New System.Drawing.Point(13, 66)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(98, 18)
        Me.LabelControl16.TabIndex = 734
        Me.LabelControl16.Text = "Código Alterno:"
        '
        'txtProductoCodigo2
        '
        Me.txtProductoCodigo2.Location = New System.Drawing.Point(118, 63)
        Me.txtProductoCodigo2.Name = "txtProductoCodigo2"
        Me.txtProductoCodigo2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoCodigo2.Properties.Appearance.Options.UseFont = True
        Me.txtProductoCodigo2.Size = New System.Drawing.Size(238, 24)
        Me.txtProductoCodigo2.TabIndex = 740
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl15.Location = New System.Drawing.Point(13, 32)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(48, 18)
        Me.LabelControl15.TabIndex = 733
        Me.LabelControl15.Text = "Código:"
        '
        'txtProductoCodigo
        '
        Me.txtProductoCodigo.Location = New System.Drawing.Point(118, 29)
        Me.txtProductoCodigo.Name = "txtProductoCodigo"
        Me.txtProductoCodigo.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductoCodigo.Properties.Appearance.Options.UseFont = True
        Me.txtProductoCodigo.Size = New System.Drawing.Size(238, 24)
        Me.txtProductoCodigo.TabIndex = 739
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LabelControl1.Location = New System.Drawing.Point(13, 229)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(45, 18)
        Me.LabelControl1.TabIndex = 746
        Me.LabelControl1.Text = "Marca:"
        '
        'txtMarca
        '
        Me.txtMarca.Location = New System.Drawing.Point(118, 226)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMarca.Properties.Appearance.Options.UseFont = True
        Me.txtMarca.Size = New System.Drawing.Size(381, 24)
        Me.txtMarca.TabIndex = 747
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SimpleButton1.Appearance.Options.UseBackColor = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.SimpleButton1.Image = Global.Ares.My.Resources.Resources.btExito
        Me.SimpleButton1.Location = New System.Drawing.Point(342, 363)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(157, 53)
        Me.SimpleButton1.TabIndex = 748
        Me.SimpleButton1.Text = "Aceptar"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl15)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.txtProductoCodigo)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.txtProductoCodigo2)
        Me.GroupControl1.Controls.Add(Me.txtMarca)
        Me.GroupControl1.Controls.Add(Me.LabelControl16)
        Me.GroupControl1.Controls.Add(Me.txtProductoFechaVence)
        Me.GroupControl1.Controls.Add(Me.txtProductoDescripcion)
        Me.GroupControl1.Controls.Add(Me.LabelControl50)
        Me.GroupControl1.Controls.Add(Me.LabelControl18)
        Me.GroupControl1.Controls.Add(Me.LbProductosDesc3)
        Me.GroupControl1.Controls.Add(Me.txtProductoDescripcion2)
        Me.GroupControl1.Controls.Add(Me.txtProductoDescripcion3)
        Me.GroupControl1.Controls.Add(Me.LbProductosDesc2)
        Me.GroupControl1.Location = New System.Drawing.Point(449, 21)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(514, 432)
        Me.GroupControl1.TabIndex = 749
        Me.GroupControl1.Text = "Detalles del Producto"
        '
        'viewProductInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.imgProducto)
        Me.Name = "viewProductInfo"
        Me.Size = New System.Drawing.Size(976, 458)
        CType(Me.imgProducto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoFechaVence.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoDescripcion3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoDescripcion2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoCodigo2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProductoCodigo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMarca.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents imgProducto As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents txtProductoFechaVence As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl50 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbProductosDesc3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoDescripcion3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LbProductosDesc2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoDescripcion2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoDescripcion As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoCodigo2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtProductoCodigo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtMarca As DevExpress.XtraEditors.TextEdit
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
End Class
