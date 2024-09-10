<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewGastos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(viewGastos))
        Me.LbGastosTotalGasto = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl112 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl111 = New DevExpress.XtraEditors.LabelControl()
        Me.txtGastosImporte = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl107 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbGastosTipo = New System.Windows.Forms.ComboBox()
        Me.txtGastosDescripcion = New System.Windows.Forms.TextBox()
        Me.cmdGastosAgregar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl108 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdGastosGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.DGVGastosTemp = New System.Windows.Forms.DataGridView()
        Me.LabelControl106 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl105 = New DevExpress.XtraEditors.LabelControl()
        Me.txtGastosFecha = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl109 = New DevExpress.XtraEditors.LabelControl()
        Me.txtGastosCorrelativo = New System.Windows.Forms.TextBox()
        Me.LabelControl104 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl113 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCajas = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdRPTVatras = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.txtGastosImporte.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVGastosTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGastosFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGastosFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LbGastosTotalGasto
        '
        Me.LbGastosTotalGasto.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbGastosTotalGasto.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LbGastosTotalGasto.Location = New System.Drawing.Point(831, 16)
        Me.LbGastosTotalGasto.Name = "LbGastosTotalGasto"
        Me.LbGastosTotalGasto.Size = New System.Drawing.Size(121, 29)
        Me.LbGastosTotalGasto.TabIndex = 1117
        Me.LbGastosTotalGasto.Text = "10,000.00"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.LabelControl112)
        Me.GroupControl3.Controls.Add(Me.LabelControl111)
        Me.GroupControl3.Controls.Add(Me.txtGastosImporte)
        Me.GroupControl3.Controls.Add(Me.LabelControl107)
        Me.GroupControl3.Controls.Add(Me.cmbGastosTipo)
        Me.GroupControl3.Controls.Add(Me.txtGastosDescripcion)
        Me.GroupControl3.Controls.Add(Me.cmdGastosAgregar)
        Me.GroupControl3.Controls.Add(Me.LabelControl108)
        Me.GroupControl3.Location = New System.Drawing.Point(19, 173)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(933, 153)
        Me.GroupControl3.TabIndex = 1114
        Me.GroupControl3.Text = "Agregue un gasto al vale de gastos"
        '
        'LabelControl112
        '
        Me.LabelControl112.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl112.Location = New System.Drawing.Point(758, 60)
        Me.LabelControl112.Name = "LabelControl112"
        Me.LabelControl112.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl112.TabIndex = 1108
        Me.LabelControl112.Text = "Q"
        '
        'LabelControl111
        '
        Me.LabelControl111.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl111.Location = New System.Drawing.Point(778, 43)
        Me.LabelControl111.Name = "LabelControl111"
        Me.LabelControl111.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl111.TabIndex = 1107
        Me.LabelControl111.Text = "Importe:"
        '
        'txtGastosImporte
        '
        Me.txtGastosImporte.Location = New System.Drawing.Point(778, 60)
        Me.txtGastosImporte.Name = "txtGastosImporte"
        Me.txtGastosImporte.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGastosImporte.Properties.Appearance.Options.UseFont = True
        Me.txtGastosImporte.Properties.Mask.EditMask = "n2"
        Me.txtGastosImporte.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtGastosImporte.Size = New System.Drawing.Size(135, 30)
        Me.txtGastosImporte.TabIndex = 1104
        '
        'LabelControl107
        '
        Me.LabelControl107.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl107.Location = New System.Drawing.Point(8, 38)
        Me.LabelControl107.Name = "LabelControl107"
        Me.LabelControl107.Size = New System.Drawing.Size(84, 16)
        Me.LabelControl107.TabIndex = 56
        Me.LabelControl107.Text = "Tipo de Gasto:"
        '
        'cmbGastosTipo
        '
        Me.cmbGastosTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGastosTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGastosTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGastosTipo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGastosTipo.FormattingEnabled = True
        Me.cmbGastosTipo.Location = New System.Drawing.Point(8, 60)
        Me.cmbGastosTipo.Name = "cmbGastosTipo"
        Me.cmbGastosTipo.Size = New System.Drawing.Size(273, 24)
        Me.cmbGastosTipo.TabIndex = 1102
        '
        'txtGastosDescripcion
        '
        Me.txtGastosDescripcion.Location = New System.Drawing.Point(293, 61)
        Me.txtGastosDescripcion.Multiline = True
        Me.txtGastosDescripcion.Name = "txtGastosDescripcion"
        Me.txtGastosDescripcion.Size = New System.Drawing.Size(445, 41)
        Me.txtGastosDescripcion.TabIndex = 1103
        '
        'cmdGastosAgregar
        '
        Me.cmdGastosAgregar.Image = CType(resources.GetObject("cmdGastosAgregar.Image"), System.Drawing.Image)
        Me.cmdGastosAgregar.Location = New System.Drawing.Point(778, 96)
        Me.cmdGastosAgregar.Name = "cmdGastosAgregar"
        Me.cmdGastosAgregar.Size = New System.Drawing.Size(140, 44)
        Me.cmdGastosAgregar.TabIndex = 1105
        Me.cmdGastosAgregar.Text = "Agregar"
        '
        'LabelControl108
        '
        Me.LabelControl108.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl108.Location = New System.Drawing.Point(293, 36)
        Me.LabelControl108.Name = "LabelControl108"
        Me.LabelControl108.Size = New System.Drawing.Size(70, 16)
        Me.LabelControl108.TabIndex = 58
        Me.LabelControl108.Text = "Descripción:"
        '
        'cmdGastosGuardar
        '
        Me.cmdGastosGuardar.Appearance.BackColor = System.Drawing.Color.White
        Me.cmdGastosGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGastosGuardar.Appearance.ForeColor = System.Drawing.Color.CadetBlue
        Me.cmdGastosGuardar.Appearance.Options.UseBackColor = True
        Me.cmdGastosGuardar.Appearance.Options.UseFont = True
        Me.cmdGastosGuardar.Appearance.Options.UseForeColor = True
        Me.cmdGastosGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.cmdGastosGuardar.Location = New System.Drawing.Point(797, 86)
        Me.cmdGastosGuardar.Name = "cmdGastosGuardar"
        Me.cmdGastosGuardar.Size = New System.Drawing.Size(157, 52)
        Me.cmdGastosGuardar.TabIndex = 1108
        Me.cmdGastosGuardar.Text = "GUARDAR "
        '
        'DGVGastosTemp
        '
        Me.DGVGastosTemp.AllowUserToAddRows = False
        Me.DGVGastosTemp.AllowUserToDeleteRows = False
        Me.DGVGastosTemp.AllowUserToOrderColumns = True
        Me.DGVGastosTemp.BackgroundColor = System.Drawing.Color.White
        Me.DGVGastosTemp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGVGastosTemp.GridColor = System.Drawing.Color.Azure
        Me.DGVGastosTemp.Location = New System.Drawing.Point(19, 335)
        Me.DGVGastosTemp.MultiSelect = False
        Me.DGVGastosTemp.Name = "DGVGastosTemp"
        Me.DGVGastosTemp.ReadOnly = True
        Me.DGVGastosTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVGastosTemp.Size = New System.Drawing.Size(933, 287)
        Me.DGVGastosTemp.StandardTab = True
        Me.DGVGastosTemp.TabIndex = 1106
        '
        'LabelControl106
        '
        Me.LabelControl106.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl106.Location = New System.Drawing.Point(225, 119)
        Me.LabelControl106.Name = "LabelControl106"
        Me.LabelControl106.Size = New System.Drawing.Size(64, 16)
        Me.LabelControl106.TabIndex = 1112
        Me.LabelControl106.Text = "Gasto No. :"
        '
        'LabelControl105
        '
        Me.LabelControl105.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl105.Location = New System.Drawing.Point(28, 119)
        Me.LabelControl105.Name = "LabelControl105"
        Me.LabelControl105.Size = New System.Drawing.Size(39, 16)
        Me.LabelControl105.TabIndex = 1111
        Me.LabelControl105.Text = "Fecha:"
        '
        'txtGastosFecha
        '
        Me.txtGastosFecha.EditValue = Nothing
        Me.txtGastosFecha.Location = New System.Drawing.Point(73, 118)
        Me.txtGastosFecha.Name = "txtGastosFecha"
        Me.txtGastosFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtGastosFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtGastosFecha.Size = New System.Drawing.Size(146, 20)
        Me.txtGastosFecha.TabIndex = 1115
        '
        'LabelControl109
        '
        Me.LabelControl109.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl109.Location = New System.Drawing.Point(733, 16)
        Me.LabelControl109.Name = "LabelControl109"
        Me.LabelControl109.Size = New System.Drawing.Size(63, 16)
        Me.LabelControl109.TabIndex = 1113
        Me.LabelControl109.Text = "Total Vale:"
        '
        'txtGastosCorrelativo
        '
        Me.txtGastosCorrelativo.Enabled = False
        Me.txtGastosCorrelativo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGastosCorrelativo.Location = New System.Drawing.Point(295, 119)
        Me.txtGastosCorrelativo.Name = "txtGastosCorrelativo"
        Me.txtGastosCorrelativo.Size = New System.Drawing.Size(167, 22)
        Me.txtGastosCorrelativo.TabIndex = 1116
        '
        'LabelControl104
        '
        Me.LabelControl104.Appearance.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl104.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.LabelControl104.Location = New System.Drawing.Point(73, 10)
        Me.LabelControl104.Name = "LabelControl104"
        Me.LabelControl104.Size = New System.Drawing.Size(175, 33)
        Me.LabelControl104.TabIndex = 1110
        Me.LabelControl104.Text = "Vales de Gasto"
        '
        'LabelControl113
        '
        Me.LabelControl113.Appearance.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl113.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl113.Location = New System.Drawing.Point(801, 15)
        Me.LabelControl113.Name = "LabelControl113"
        Me.LabelControl113.Size = New System.Drawing.Size(25, 29)
        Me.LabelControl113.TabIndex = 1118
        Me.LabelControl113.Text = "Q "
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(28, 83)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(155, 16)
        Me.LabelControl1.TabIndex = 1109
        Me.LabelControl1.Text = "Seleccione la Caja/Cuenta:"
        '
        'cmbCajas
        '
        Me.cmbCajas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCajas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.Location = New System.Drawing.Point(189, 83)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(273, 24)
        Me.cmbCajas.TabIndex = 1110
        '
        'btnCancelar
        '
        Me.btnCancelar.Appearance.BackColor = System.Drawing.Color.White
        Me.btnCancelar.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnCancelar.Appearance.Options.UseBackColor = True
        Me.btnCancelar.Appearance.Options.UseFont = True
        Me.btnCancelar.Appearance.Options.UseForeColor = True
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(586, 88)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(157, 52)
        Me.btnCancelar.TabIndex = 1119
        Me.btnCancelar.Text = "CANCELAR"
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
        Me.cmdRPTVatras.TabIndex = 1120
        '
        'viewGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdRPTVatras)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.cmbCajas)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.LabelControl113)
        Me.Controls.Add(Me.LbGastosTotalGasto)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.cmdGastosGuardar)
        Me.Controls.Add(Me.LabelControl106)
        Me.Controls.Add(Me.LabelControl105)
        Me.Controls.Add(Me.txtGastosFecha)
        Me.Controls.Add(Me.LabelControl109)
        Me.Controls.Add(Me.txtGastosCorrelativo)
        Me.Controls.Add(Me.DGVGastosTemp)
        Me.Controls.Add(Me.LabelControl104)
        Me.Name = "viewGastos"
        Me.Size = New System.Drawing.Size(971, 642)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        Me.GroupControl3.PerformLayout()
        CType(Me.txtGastosImporte.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVGastosTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGastosFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGastosFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LbGastosTotalGasto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl112 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdGastosGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl111 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGastosImporte As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl107 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbGastosTipo As ComboBox
    Friend WithEvents DGVGastosTemp As DataGridView
    Friend WithEvents txtGastosDescripcion As TextBox
    Friend WithEvents cmdGastosAgregar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl108 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl106 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl105 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGastosFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl109 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGastosCorrelativo As TextBox
    Friend WithEvents LabelControl104 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl113 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCajas As ComboBox
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdRPTVatras As DevExpress.XtraEditors.SimpleButton
End Class
