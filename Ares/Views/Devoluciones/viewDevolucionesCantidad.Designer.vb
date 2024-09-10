<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewDevolucionesCantidad
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
        Me.lbDesprod = New DevExpress.XtraEditors.LabelControl()
        Me.cmbMedidas = New System.Windows.Forms.ComboBox()
        Me.txtCantidad = New DevExpress.XtraEditors.TextEdit()
        Me.lbCodprod = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalUnidades = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalUnidades = New DevExpress.XtraEditors.LabelControl()
        Me.btnAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnAgregarTrue = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalUnidades.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbDesprod
        '
        Me.lbDesprod.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDesprod.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDesprod.Location = New System.Drawing.Point(34, 15)
        Me.lbDesprod.Name = "lbDesprod"
        Me.lbDesprod.Size = New System.Drawing.Size(74, 23)
        Me.lbDesprod.TabIndex = 0
        Me.lbDesprod.Text = "Producto"
        '
        'cmbMedidas
        '
        Me.cmbMedidas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMedidas.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMedidas.FormattingEnabled = True
        Me.cmbMedidas.Location = New System.Drawing.Point(34, 121)
        Me.cmbMedidas.Name = "cmbMedidas"
        Me.cmbMedidas.Size = New System.Drawing.Size(198, 31)
        Me.cmbMedidas.TabIndex = 1
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(265, 121)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCantidad.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Properties.Appearance.Options.UseBackColor = True
        Me.txtCantidad.Properties.Appearance.Options.UseFont = True
        Me.txtCantidad.Properties.Mask.EditMask = "n2"
        Me.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCantidad.Size = New System.Drawing.Size(91, 30)
        Me.txtCantidad.TabIndex = 2
        '
        'lbCodprod
        '
        Me.lbCodprod.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodprod.Location = New System.Drawing.Point(34, 41)
        Me.lbCodprod.Name = "lbCodprod"
        Me.lbCodprod.Size = New System.Drawing.Size(39, 16)
        Me.lbCodprod.TabIndex = 3
        Me.lbCodprod.Text = "Codigo"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(265, 99)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "Cantidad"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(34, 196)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(111, 16)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Unidades vendidas:"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(401, 96)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(85, 16)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "Total Unidades"
        '
        'txtTotalUnidades
        '
        Me.txtTotalUnidades.Enabled = False
        Me.txtTotalUnidades.Location = New System.Drawing.Point(401, 118)
        Me.txtTotalUnidades.Name = "txtTotalUnidades"
        Me.txtTotalUnidades.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalUnidades.Properties.Appearance.Options.UseFont = True
        Me.txtTotalUnidades.Properties.Mask.EditMask = "n2"
        Me.txtTotalUnidades.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTotalUnidades.Size = New System.Drawing.Size(91, 30)
        Me.txtTotalUnidades.TabIndex = 6
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(34, 82)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(132, 16)
        Me.LabelControl6.TabIndex = 8
        Me.LabelControl6.Text = "Unidades a Devolver"
        '
        'lbTotalUnidades
        '
        Me.lbTotalUnidades.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalUnidades.Location = New System.Drawing.Point(154, 194)
        Me.lbTotalUnidades.Name = "lbTotalUnidades"
        Me.lbTotalUnidades.Size = New System.Drawing.Size(40, 23)
        Me.lbTotalUnidades.TabIndex = 9
        Me.lbTotalUnidades.Text = "0000"
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Ares.My.Resources.Resources.btExito1
        Me.btnAgregar.Location = New System.Drawing.Point(532, 196)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(137, 49)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "ACEPTAR"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton2.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton2.Location = New System.Drawing.Point(371, 196)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(137, 49)
        Me.SimpleButton2.TabIndex = 11
        Me.SimpleButton2.Text = "CANCELAR"
        '
        'btnAgregarTrue
        '
        Me.btnAgregarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAgregarTrue.Location = New System.Drawing.Point(281, 275)
        Me.btnAgregarTrue.Name = "btnAgregarTrue"
        Me.btnAgregarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarTrue.TabIndex = 12
        Me.btnAgregarTrue.TabStop = False
        Me.btnAgregarTrue.Text = "AGREGAR"
        '
        'viewDevolucionesCantidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnAgregarTrue)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.lbTotalUnidades)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtTotalUnidades)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.lbCodprod)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.cmbMedidas)
        Me.Controls.Add(Me.lbDesprod)
        Me.Name = "viewDevolucionesCantidad"
        Me.Size = New System.Drawing.Size(683, 260)
        CType(Me.txtCantidad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalUnidades.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbDesprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbMedidas As ComboBox
    Friend WithEvents txtCantidad As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbCodprod As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalUnidades As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalUnidades As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAgregarTrue As DevExpress.XtraEditors.SimpleButton
End Class
