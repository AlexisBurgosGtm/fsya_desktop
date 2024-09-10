<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewCxcCobroCuota
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.lbNit = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.lbNoRecibo = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbEmpleado = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnGuardar = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObs = New System.Windows.Forms.TextBox()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaAbono = New DevExpress.XtraEditors.DateEdit()
        Me.txtAbono = New DevExpress.XtraEditors.TextEdit()
        Me.LbCliente = New DevExpress.XtraEditors.LabelControl()
        Me.LbFecha = New DevExpress.XtraEditors.LabelControl()
        Me.lbFactura = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.txtFechaAbono.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaAbono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbono.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.lbNit)
        Me.GroupControl1.Controls.Add(Me.LabelControl11)
        Me.GroupControl1.Controls.Add(Me.GroupControl2)
        Me.GroupControl1.Controls.Add(Me.LbCliente)
        Me.GroupControl1.Controls.Add(Me.LbFecha)
        Me.GroupControl1.Controls.Add(Me.lbFactura)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Location = New System.Drawing.Point(6, 8)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(639, 487)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "Cobro de Cuota"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(17, 111)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(98, 16)
        Me.LabelControl3.TabIndex = 17
        Me.LabelControl3.Text = "Fecha de Pago:"
        '
        'lbNit
        '
        Me.lbNit.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNit.Location = New System.Drawing.Point(96, 85)
        Me.lbNit.Name = "lbNit"
        Me.lbNit.Size = New System.Drawing.Size(15, 16)
        Me.lbNit.TabIndex = 16
        Me.lbNit.Text = "CF"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(17, 85)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(25, 16)
        Me.LabelControl11.TabIndex = 15
        Me.LabelControl11.Text = "NIT:"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.LabelControl19)
        Me.GroupControl2.Controls.Add(Me.cmbCaja)
        Me.GroupControl2.Controls.Add(Me.lbNoRecibo)
        Me.GroupControl2.Controls.Add(Me.LabelControl9)
        Me.GroupControl2.Controls.Add(Me.LabelControl6)
        Me.GroupControl2.Controls.Add(Me.cmbEmpleado)
        Me.GroupControl2.Controls.Add(Me.btnCancelar)
        Me.GroupControl2.Controls.Add(Me.btnGuardar)
        Me.GroupControl2.Controls.Add(Me.LabelControl15)
        Me.GroupControl2.Controls.Add(Me.LabelControl14)
        Me.GroupControl2.Controls.Add(Me.LabelControl12)
        Me.GroupControl2.Controls.Add(Me.txtObs)
        Me.GroupControl2.Controls.Add(Me.LabelControl13)
        Me.GroupControl2.Controls.Add(Me.txtFechaAbono)
        Me.GroupControl2.Controls.Add(Me.txtAbono)
        Me.GroupControl2.Location = New System.Drawing.Point(18, 154)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(601, 297)
        Me.GroupControl2.TabIndex = 12
        Me.GroupControl2.Text = "Detalle dle Abono"
        '
        'lbNoRecibo
        '
        Me.lbNoRecibo.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbNoRecibo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbNoRecibo.Location = New System.Drawing.Point(81, 31)
        Me.lbNoRecibo.Name = "lbNoRecibo"
        Me.lbNoRecibo.Size = New System.Drawing.Size(144, 18)
        Me.lbNoRecibo.TabIndex = 17
        Me.lbNoRecibo.Text = "RECCLIE - 999,999"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(24, 32)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(47, 16)
        Me.LabelControl9.TabIndex = 16
        Me.LabelControl9.Text = "Recibo: "
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(25, 110)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(46, 16)
        Me.LabelControl6.TabIndex = 15
        Me.LabelControl6.Text = "Recibió:"
        '
        'cmbEmpleado
        '
        Me.cmbEmpleado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbEmpleado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbEmpleado.FormattingEnabled = True
        Me.cmbEmpleado.Location = New System.Drawing.Point(82, 110)
        Me.cmbEmpleado.Name = "cmbEmpleado"
        Me.cmbEmpleado.Size = New System.Drawing.Size(223, 21)
        Me.cmbEmpleado.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.Ares.My.Resources.Resources.bt20
        Me.btnCancelar.Location = New System.Drawing.Point(328, 180)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(117, 54)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnGuardar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.btnGuardar.Location = New System.Drawing.Point(469, 180)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(117, 54)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(368, 95)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(15, 23)
        Me.LabelControl15.TabIndex = 11
        Me.LabelControl15.Text = "Q"
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Location = New System.Drawing.Point(34, 147)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(88, 16)
        Me.LabelControl14.TabIndex = 10
        Me.LabelControl14.Text = "Observaciones:"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(24, 59)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(39, 16)
        Me.LabelControl12.TabIndex = 8
        Me.LabelControl12.Text = "Fecha:"
        '
        'txtObs
        '
        Me.txtObs.Location = New System.Drawing.Point(34, 169)
        Me.txtObs.Multiline = True
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Size = New System.Drawing.Size(267, 99)
        Me.txtObs.TabIndex = 3
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Location = New System.Drawing.Point(373, 59)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(33, 16)
        Me.LabelControl13.TabIndex = 9
        Me.LabelControl13.Text = "Pago:"
        '
        'txtFechaAbono
        '
        Me.txtFechaAbono.EditValue = Nothing
        Me.txtFechaAbono.Enabled = False
        Me.txtFechaAbono.EnterMoveNextControl = True
        Me.txtFechaAbono.Location = New System.Drawing.Point(81, 58)
        Me.txtFechaAbono.Name = "txtFechaAbono"
        Me.txtFechaAbono.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaAbono.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaAbono.Size = New System.Drawing.Size(115, 20)
        Me.txtFechaAbono.TabIndex = 0
        '
        'txtAbono
        '
        Me.txtAbono.Enabled = False
        Me.txtAbono.EnterMoveNextControl = True
        Me.txtAbono.Location = New System.Drawing.Point(388, 95)
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbono.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtAbono.Properties.Appearance.Options.UseFont = True
        Me.txtAbono.Properties.Appearance.Options.UseForeColor = True
        Me.txtAbono.Properties.Mask.EditMask = "n2"
        Me.txtAbono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAbono.Size = New System.Drawing.Size(132, 26)
        Me.txtAbono.TabIndex = 2
        '
        'LbCliente
        '
        Me.LbCliente.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCliente.Location = New System.Drawing.Point(96, 60)
        Me.LbCliente.Name = "LbCliente"
        Me.LbCliente.Size = New System.Drawing.Size(99, 16)
        Me.LbCliente.TabIndex = 8
        Me.LbCliente.Text = "Consumidor Final"
        '
        'LbFecha
        '
        Me.LbFecha.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbFecha.Location = New System.Drawing.Point(125, 111)
        Me.LbFecha.Name = "LbFecha"
        Me.LbFecha.Size = New System.Drawing.Size(66, 16)
        Me.LbFecha.TabIndex = 7
        Me.LbFecha.Text = "01/01/2018"
        '
        'lbFactura
        '
        Me.lbFactura.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFactura.Location = New System.Drawing.Point(96, 33)
        Me.lbFactura.Name = "lbFactura"
        Me.lbFactura.Size = New System.Drawing.Size(100, 16)
        Me.lbFactura.TabIndex = 6
        Me.lbFactura.Text = "FACA1 - 1000000"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(17, 33)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(54, 16)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Factura:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(17, 60)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(49, 16)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Cliente:"
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Location = New System.Drawing.Point(25, 83)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(31, 16)
        Me.LabelControl19.TabIndex = 27
        Me.LabelControl19.Text = "Caja:"
        '
        'cmbCaja
        '
        Me.cmbCaja.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCaja.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.Location = New System.Drawing.Point(82, 83)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(158, 21)
        Me.cmbCaja.TabIndex = 26
        '
        'viewCxcCobroCuota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "viewCxcCobroCuota"
        Me.Size = New System.Drawing.Size(652, 504)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.txtFechaAbono.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaAbono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbono.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbNit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lbNoRecibo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbEmpleado As ComboBox
    Friend WithEvents btnCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnGuardar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As TextBox
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaAbono As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtAbono As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LbCliente As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbFecha As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbFactura As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCaja As ComboBox
End Class
