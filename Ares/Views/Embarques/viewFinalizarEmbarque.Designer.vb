<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewFinalizarEmbarque
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
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.lbCodembarque = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalVentas = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalDevoluciones = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.txtFechaCreado = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.lbDiferencia = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.cmdClientesCancelarEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFecha = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDineroReportado = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.lbLiquidar = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.lbDiferenciaLiquidar = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.lbPedidos = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.lbDescripcion = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtFechaCreado.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDineroReportado.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(73, 20)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(103, 23)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Embarque:"
        '
        'lbCodembarque
        '
        Me.lbCodembarque.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCodembarque.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lbCodembarque.Location = New System.Drawing.Point(234, 18)
        Me.lbCodembarque.Name = "lbCodembarque"
        Me.lbCodembarque.Size = New System.Drawing.Size(39, 25)
        Me.lbCodembarque.TabIndex = 1
        Me.lbCodembarque.Text = "000"
        '
        'lbTotalVentas
        '
        Me.lbTotalVentas.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalVentas.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.lbTotalVentas.Location = New System.Drawing.Point(248, 82)
        Me.lbTotalVentas.Name = "lbTotalVentas"
        Me.lbTotalVentas.Size = New System.Drawing.Size(36, 23)
        Me.lbTotalVentas.TabIndex = 3
        Me.lbTotalVentas.Text = "000"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(14, 82)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(158, 23)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Total Embarque:"
        '
        'lbTotalDevoluciones
        '
        Me.lbTotalDevoluciones.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalDevoluciones.Appearance.ForeColor = System.Drawing.Color.Goldenrod
        Me.lbTotalDevoluciones.Location = New System.Drawing.Point(248, 126)
        Me.lbTotalDevoluciones.Name = "lbTotalDevoluciones"
        Me.lbTotalDevoluciones.Size = New System.Drawing.Size(36, 23)
        Me.lbTotalDevoluciones.TabIndex = 5
        Me.lbTotalDevoluciones.Text = "000"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(14, 126)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(189, 23)
        Me.LabelControl5.TabIndex = 4
        Me.LabelControl5.Text = "Total Devoluciones:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Appearance.ForeColor = System.Drawing.Color.Blue
        Me.LabelControl6.Location = New System.Drawing.Point(222, 82)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(15, 23)
        Me.LabelControl6.TabIndex = 6
        Me.LabelControl6.Text = "Q"
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Appearance.ForeColor = System.Drawing.Color.Goldenrod
        Me.LabelControl7.Location = New System.Drawing.Point(222, 126)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(15, 23)
        Me.LabelControl7.TabIndex = 7
        Me.LabelControl7.Text = "Q"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.txtFechaCreado)
        Me.GroupControl1.Controls.Add(Me.LabelControl11)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.lbDiferencia)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.lbTotalVentas)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.lbTotalDevoluciones)
        Me.GroupControl1.Location = New System.Drawing.Point(15, 143)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(404, 325)
        Me.GroupControl1.TabIndex = 8
        Me.GroupControl1.Text = "Resumen del Embarque"
        '
        'txtFechaCreado
        '
        Me.txtFechaCreado.EditValue = Nothing
        Me.txtFechaCreado.Location = New System.Drawing.Point(192, 40)
        Me.txtFechaCreado.Name = "txtFechaCreado"
        Me.txtFechaCreado.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCreado.Properties.Appearance.Options.UseFont = True
        Me.txtFechaCreado.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaCreado.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaCreado.Size = New System.Drawing.Size(129, 22)
        Me.txtFechaCreado.TabIndex = 18
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(14, 42)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(135, 23)
        Me.LabelControl11.TabIndex = 17
        Me.LabelControl11.Text = "Fecha Creado:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl4.Location = New System.Drawing.Point(222, 189)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(15, 23)
        Me.LabelControl4.TabIndex = 11
        Me.LabelControl4.Text = "Q"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(14, 189)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(200, 23)
        Me.LabelControl8.TabIndex = 9
        Me.LabelControl8.Text = "Diferencia (liquidar):"
        '
        'lbDiferencia
        '
        Me.lbDiferencia.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDiferencia.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDiferencia.Location = New System.Drawing.Point(248, 189)
        Me.lbDiferencia.Name = "lbDiferencia"
        Me.lbDiferencia.Size = New System.Drawing.Size(36, 23)
        Me.lbDiferencia.TabIndex = 10
        Me.lbDiferencia.Text = "000"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl2.Location = New System.Drawing.Point(12, 154)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(376, 23)
        Me.LabelControl2.TabIndex = 8
        Me.LabelControl2.Text = "-----------------------------------------------"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.cmdClientesCancelarEdit)
        Me.GroupControl2.Controls.Add(Me.btnGuardar)
        Me.GroupControl2.Controls.Add(Me.txtFecha)
        Me.GroupControl2.Controls.Add(Me.LabelControl16)
        Me.GroupControl2.Controls.Add(Me.txtDineroReportado)
        Me.GroupControl2.Controls.Add(Me.LabelControl15)
        Me.GroupControl2.Controls.Add(Me.lbLiquidar)
        Me.GroupControl2.Controls.Add(Me.LabelControl9)
        Me.GroupControl2.Controls.Add(Me.LabelControl10)
        Me.GroupControl2.Controls.Add(Me.lbDiferenciaLiquidar)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Controls.Add(Me.LabelControl17)
        Me.GroupControl2.Location = New System.Drawing.Point(426, 143)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(413, 325)
        Me.GroupControl2.TabIndex = 12
        Me.GroupControl2.Text = "Finalización del Embarque"
        '
        'cmdClientesCancelarEdit
        '
        Me.cmdClientesCancelarEdit.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClientesCancelarEdit.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.cmdClientesCancelarEdit.Appearance.Options.UseFont = True
        Me.cmdClientesCancelarEdit.Appearance.Options.UseForeColor = True
        Me.cmdClientesCancelarEdit.AppearanceHovered.BackColor = System.Drawing.Color.AliceBlue
        Me.cmdClientesCancelarEdit.AppearanceHovered.Options.UseBackColor = True
        Me.cmdClientesCancelarEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClientesCancelarEdit.Image = Global.Ares.My.Resources.Resources.bt20
        Me.cmdClientesCancelarEdit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft
        Me.cmdClientesCancelarEdit.Location = New System.Drawing.Point(77, 247)
        Me.cmdClientesCancelarEdit.Name = "cmdClientesCancelarEdit"
        Me.cmdClientesCancelarEdit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[False]
        Me.cmdClientesCancelarEdit.Size = New System.Drawing.Size(135, 60)
        Me.cmdClientesCancelarEdit.TabIndex = 18
        Me.cmdClientesCancelarEdit.Text = "CANCELAR"
        '
        'btnGuardar
        '
        Me.btnGuardar.Appearance.BackColor = System.Drawing.Color.White
        Me.btnGuardar.Appearance.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Appearance.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnGuardar.Appearance.Options.UseBackColor = True
        Me.btnGuardar.Appearance.Options.UseFont = True
        Me.btnGuardar.Appearance.Options.UseForeColor = True
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(248, 247)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(135, 60)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "FINALIZAR"
        '
        'txtFecha
        '
        Me.txtFecha.EditValue = Nothing
        Me.txtFecha.Location = New System.Drawing.Point(93, 39)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Properties.Appearance.Options.UseFont = True
        Me.txtFecha.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFecha.Size = New System.Drawing.Size(129, 22)
        Me.txtFecha.TabIndex = 16
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Location = New System.Drawing.Point(17, 37)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(62, 23)
        Me.LabelControl16.TabIndex = 15
        Me.LabelControl16.Text = "Fecha:"
        '
        'txtDineroReportado
        '
        Me.txtDineroReportado.Location = New System.Drawing.Point(236, 126)
        Me.txtDineroReportado.Name = "txtDineroReportado"
        Me.txtDineroReportado.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDineroReportado.Properties.Appearance.Options.UseFont = True
        Me.txtDineroReportado.Properties.Mask.EditMask = "n2"
        Me.txtDineroReportado.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtDineroReportado.Size = New System.Drawing.Size(147, 26)
        Me.txtDineroReportado.TabIndex = 14
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl15.Location = New System.Drawing.Point(207, 82)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(15, 23)
        Me.LabelControl15.TabIndex = 13
        Me.LabelControl15.Text = "Q"
        '
        'lbLiquidar
        '
        Me.lbLiquidar.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLiquidar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbLiquidar.Location = New System.Drawing.Point(239, 82)
        Me.lbLiquidar.Name = "lbLiquidar"
        Me.lbLiquidar.Size = New System.Drawing.Size(36, 23)
        Me.lbLiquidar.TabIndex = 12
        Me.lbLiquidar.Text = "000"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl9.Location = New System.Drawing.Point(209, 189)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl9.TabIndex = 11
        Me.LabelControl9.Text = "Q"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(17, 189)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(103, 23)
        Me.LabelControl10.TabIndex = 9
        Me.LabelControl10.Text = "Diferencia:"
        '
        'lbDiferenciaLiquidar
        '
        Me.lbDiferenciaLiquidar.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDiferenciaLiquidar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbDiferenciaLiquidar.Location = New System.Drawing.Point(239, 189)
        Me.lbDiferenciaLiquidar.Name = "lbDiferenciaLiquidar"
        Me.lbDiferenciaLiquidar.Size = New System.Drawing.Size(39, 25)
        Me.lbDiferenciaLiquidar.TabIndex = 10
        Me.lbDiferenciaLiquidar.Text = "000"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.LabelControl12.Location = New System.Drawing.Point(15, 154)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(368, 23)
        Me.LabelControl12.TabIndex = 8
        Me.LabelControl12.Text = "----------------------------------------------"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(17, 82)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(99, 23)
        Me.LabelControl13.TabIndex = 2
        Me.LabelControl13.Text = "A liquidar:"
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelControl14.Location = New System.Drawing.Point(207, 126)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(15, 23)
        Me.LabelControl14.TabIndex = 7
        Me.LabelControl14.Text = "Q"
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl17.Location = New System.Drawing.Point(17, 126)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(176, 23)
        Me.LabelControl17.TabIndex = 4
        Me.LabelControl17.Text = "Dinero Reportado:"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(747, 149)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 13
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "Aceptar"
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Location = New System.Drawing.Point(73, 91)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(137, 23)
        Me.LabelControl18.TabIndex = 14
        Me.LabelControl18.Text = "Total Pedidos:"
        '
        'lbPedidos
        '
        Me.lbPedidos.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPedidos.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbPedidos.Location = New System.Drawing.Point(237, 91)
        Me.lbPedidos.Name = "lbPedidos"
        Me.lbPedidos.Size = New System.Drawing.Size(36, 23)
        Me.lbPedidos.TabIndex = 15
        Me.lbPedidos.Text = "000"
        '
        'LabelControl20
        '
        Me.LabelControl20.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl20.Location = New System.Drawing.Point(73, 50)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(137, 23)
        Me.LabelControl20.TabIndex = 16
        Me.LabelControl20.Text = "Total Pedidos:"
        '
        'lbDescripcion
        '
        Me.lbDescripcion.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDescripcion.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lbDescripcion.Location = New System.Drawing.Point(234, 55)
        Me.lbDescripcion.Name = "lbDescripcion"
        Me.lbDescripcion.Size = New System.Drawing.Size(84, 16)
        Me.lbDescripcion.TabIndex = 17
        Me.lbDescripcion.Text = "DESCRIPCION"
        '
        'viewFinalizarEmbarque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lbDescripcion)
        Me.Controls.Add(Me.LabelControl20)
        Me.Controls.Add(Me.lbPedidos)
        Me.Controls.Add(Me.LabelControl18)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.lbCodembarque)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.btnAceptarTrue)
        Me.Name = "viewFinalizarEmbarque"
        Me.Size = New System.Drawing.Size(892, 497)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtFechaCreado.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCreado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtFecha.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDineroReportado.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbCodembarque As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalVentas As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalDevoluciones As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbDiferencia As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents txtFecha As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDineroReportado As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbLiquidar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbDiferenciaLiquidar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdClientesCancelarEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtFechaCreado As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbPedidos As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbDescripcion As DevExpress.XtraEditors.LabelControl
End Class
