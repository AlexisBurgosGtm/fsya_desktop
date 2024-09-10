<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControlCobrar
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControlCobrar))
        Me.SwitchFormaPago = New DevExpress.XtraEditors.ToggleSwitch()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCobrarPago = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LB_CobrarTotalVenta = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LbVueltoQ = New DevExpress.XtraEditors.LabelControl()
        Me.LB_CobrarVuelto = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.cmdCobrarAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnUnlockSerieFinal = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl21 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFechaFacturar = New DevExpress.XtraEditors.DateEdit()
        Me.lbCorrelativoFinal = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl20 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbCoddocFinal = New System.Windows.Forms.ComboBox()
        Me.cmbDiasCredito = New System.Windows.Forms.ComboBox()
        Me.lbFechaVencimiento = New DevExpress.XtraEditors.LabelControl()
        Me.txtVentasFechaVence = New DevExpress.XtraEditors.DateEdit()
        Me.btnDatosEntrega = New DevExpress.XtraEditors.SimpleButton()
        Me.FlyoutPanelRepartos = New DevExpress.Utils.FlyoutPanel()
        Me.FlyoutPanelControl1 = New DevExpress.Utils.FlyoutPanelControl()
        Me.LabelControl19 = New DevExpress.XtraEditors.LabelControl()
        Me.txtObs = New DevExpress.XtraEditors.TextEdit()
        Me.btnCerrarFlyout = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl18 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl17 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl15 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl12 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFlete = New DevExpress.XtraEditors.TextEdit()
        Me.cmbRepartidor = New System.Windows.Forms.ComboBox()
        Me.txtNoGuia = New DevExpress.XtraEditors.TextEdit()
        Me.txtDirEntrega = New DevExpress.XtraEditors.TextEdit()
        Me.lbPorcentajeRecargo = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl14 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalAPagar = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl16 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.lbTotalRecargo = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl13 = New DevExpress.XtraEditors.LabelControl()
        Me.txtCobrarTarjeta = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.btnAceptarTrue = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.SwitchImprime = New DevExpress.XtraEditors.ToggleSwitch()
        Me.TimerCobro = New System.Windows.Forms.Timer(Me.components)
        CType(Me.SwitchFormaPago.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCobrarPago.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtFechaFacturar.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFacturar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVentasFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVentasFechaVence.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlyoutPanelRepartos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelRepartos.SuspendLayout()
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlyoutPanelControl1.SuspendLayout()
        CType(Me.txtObs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFlete.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoGuia.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDirEntrega.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCobrarTarjeta.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SwitchImprime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SwitchFormaPago
        '
        Me.SwitchFormaPago.EditValue = True
        Me.SwitchFormaPago.Location = New System.Drawing.Point(123, 37)
        Me.SwitchFormaPago.Name = "SwitchFormaPago"
        Me.SwitchFormaPago.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwitchFormaPago.Properties.Appearance.Options.UseFont = True
        Me.SwitchFormaPago.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.SwitchFormaPago.Properties.OffText = "CRÉDITO"
        Me.SwitchFormaPago.Properties.OnText = "CONTADO"
        Me.SwitchFormaPago.Size = New System.Drawing.Size(158, 26)
        Me.SwitchFormaPago.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(24, 42)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(92, 16)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Forma de Pago:"
        '
        'txtCobrarPago
        '
        Me.txtCobrarPago.Location = New System.Drawing.Point(481, 160)
        Me.txtCobrarPago.Name = "txtCobrarPago"
        Me.txtCobrarPago.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCobrarPago.Properties.Appearance.Options.UseFont = True
        Me.txtCobrarPago.Properties.Mask.EditMask = "n2"
        Me.txtCobrarPago.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCobrarPago.Size = New System.Drawing.Size(176, 46)
        Me.txtCobrarPago.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(24, 165)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(71, 16)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Total Venta:"
        '
        'LB_CobrarTotalVenta
        '
        Me.LB_CobrarTotalVenta.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_CobrarTotalVenta.Location = New System.Drawing.Point(138, 157)
        Me.LB_CobrarTotalVenta.Name = "LB_CobrarTotalVenta"
        Me.LB_CobrarTotalVenta.Size = New System.Drawing.Size(176, 42)
        Me.LB_CobrarTotalVenta.TabIndex = 4
        Me.LB_CobrarTotalVenta.Text = "10,000.00"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(101, 156)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(27, 42)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Q"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl5.Location = New System.Drawing.Point(444, 157)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(27, 42)
        Me.LabelControl5.TabIndex = 6
        Me.LabelControl5.Text = "Q"
        '
        'LbVueltoQ
        '
        Me.LbVueltoQ.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbVueltoQ.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LbVueltoQ.Location = New System.Drawing.Point(444, 303)
        Me.LbVueltoQ.Name = "LbVueltoQ"
        Me.LbVueltoQ.Size = New System.Drawing.Size(27, 42)
        Me.LbVueltoQ.TabIndex = 8
        Me.LbVueltoQ.Text = "Q"
        '
        'LB_CobrarVuelto
        '
        Me.LB_CobrarVuelto.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB_CobrarVuelto.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LB_CobrarVuelto.Location = New System.Drawing.Point(481, 303)
        Me.LB_CobrarVuelto.Name = "LB_CobrarVuelto"
        Me.LB_CobrarVuelto.Size = New System.Drawing.Size(176, 42)
        Me.LB_CobrarVuelto.TabIndex = 7
        Me.LB_CobrarVuelto.Text = "10,000.00"
        '
        'LabelControl8
        '
        Me.LabelControl8.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl8.Location = New System.Drawing.Point(369, 306)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(41, 16)
        Me.LabelControl8.TabIndex = 9
        Me.LabelControl8.Text = "Vuelto:"
        '
        'LabelControl9
        '
        Me.LabelControl9.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl9.Location = New System.Drawing.Point(369, 165)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(49, 16)
        Me.LabelControl9.TabIndex = 10
        Me.LabelControl9.Text = "Efectivo:"
        '
        'cmdCobrarAceptar
        '
        Me.cmdCobrarAceptar.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCobrarAceptar.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdCobrarAceptar.Appearance.Options.UseFont = True
        Me.cmdCobrarAceptar.Appearance.Options.UseForeColor = True
        Me.cmdCobrarAceptar.Image = Global.Ares.My.Resources.Resources.bt19
        Me.cmdCobrarAceptar.Location = New System.Drawing.Point(544, 399)
        Me.cmdCobrarAceptar.Name = "cmdCobrarAceptar"
        Me.cmdCobrarAceptar.Size = New System.Drawing.Size(161, 67)
        Me.cmdCobrarAceptar.TabIndex = 4
        Me.cmdCobrarAceptar.Text = "COBRAR"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SimpleButton1.Image = Global.Ares.My.Resources.Resources.bt20
        Me.SimpleButton1.Location = New System.Drawing.Point(339, 399)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(161, 67)
        Me.SimpleButton1.TabIndex = 13
        Me.SimpleButton1.TabStop = False
        Me.SimpleButton1.Text = "Cancelar"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnUnlockSerieFinal)
        Me.GroupControl1.Controls.Add(Me.LabelControl21)
        Me.GroupControl1.Controls.Add(Me.txtFechaFacturar)
        Me.GroupControl1.Controls.Add(Me.lbCorrelativoFinal)
        Me.GroupControl1.Controls.Add(Me.LabelControl20)
        Me.GroupControl1.Controls.Add(Me.cmbCoddocFinal)
        Me.GroupControl1.Controls.Add(Me.cmbDiasCredito)
        Me.GroupControl1.Controls.Add(Me.lbFechaVencimiento)
        Me.GroupControl1.Controls.Add(Me.txtVentasFechaVence)
        Me.GroupControl1.Controls.Add(Me.btnDatosEntrega)
        Me.GroupControl1.Controls.Add(Me.FlyoutPanelRepartos)
        Me.GroupControl1.Controls.Add(Me.lbPorcentajeRecargo)
        Me.GroupControl1.Controls.Add(Me.LabelControl14)
        Me.GroupControl1.Controls.Add(Me.lbTotalAPagar)
        Me.GroupControl1.Controls.Add(Me.LabelControl16)
        Me.GroupControl1.Controls.Add(Me.LabelControl11)
        Me.GroupControl1.Controls.Add(Me.lbTotalRecargo)
        Me.GroupControl1.Controls.Add(Me.LabelControl13)
        Me.GroupControl1.Controls.Add(Me.txtCobrarTarjeta)
        Me.GroupControl1.Controls.Add(Me.LabelControl7)
        Me.GroupControl1.Controls.Add(Me.LabelControl10)
        Me.GroupControl1.Controls.Add(Me.btnAceptarTrue)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.SwitchImprime)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Controls.Add(Me.SwitchFormaPago)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.txtCobrarPago)
        Me.GroupControl1.Controls.Add(Me.cmdCobrarAceptar)
        Me.GroupControl1.Controls.Add(Me.LB_CobrarTotalVenta)
        Me.GroupControl1.Controls.Add(Me.LabelControl9)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl8)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LbVueltoQ)
        Me.GroupControl1.Controls.Add(Me.LB_CobrarVuelto)
        Me.GroupControl1.Location = New System.Drawing.Point(9, 8)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(774, 476)
        Me.GroupControl1.TabIndex = 14
        Me.GroupControl1.Text = "Detalle del Cobro"
        '
        'btnUnlockSerieFinal
        '
        Me.btnUnlockSerieFinal.Image = CType(resources.GetObject("btnUnlockSerieFinal.Image"), System.Drawing.Image)
        Me.btnUnlockSerieFinal.Location = New System.Drawing.Point(622, 106)
        Me.btnUnlockSerieFinal.Name = "btnUnlockSerieFinal"
        Me.btnUnlockSerieFinal.Size = New System.Drawing.Size(35, 23)
        Me.btnUnlockSerieFinal.TabIndex = 38
        Me.btnUnlockSerieFinal.TabStop = False
        '
        'LabelControl21
        '
        Me.LabelControl21.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl21.Location = New System.Drawing.Point(380, 109)
        Me.LabelControl21.Name = "LabelControl21"
        Me.LabelControl21.Size = New System.Drawing.Size(102, 16)
        Me.LabelControl21.TabIndex = 36
        Me.LabelControl21.Text = "Facturar a Fecha:"
        '
        'txtFechaFacturar
        '
        Me.txtFechaFacturar.EditValue = Nothing
        Me.txtFechaFacturar.Location = New System.Drawing.Point(503, 106)
        Me.txtFechaFacturar.Name = "txtFechaFacturar"
        Me.txtFechaFacturar.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFacturar.Properties.Appearance.Options.UseFont = True
        Me.txtFechaFacturar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFacturar.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtFechaFacturar.Size = New System.Drawing.Size(114, 22)
        Me.txtFechaFacturar.TabIndex = 35
        '
        'lbCorrelativoFinal
        '
        Me.lbCorrelativoFinal.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbCorrelativoFinal.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbCorrelativoFinal.Location = New System.Drawing.Point(617, 80)
        Me.lbCorrelativoFinal.Name = "lbCorrelativoFinal"
        Me.lbCorrelativoFinal.Size = New System.Drawing.Size(110, 19)
        Me.lbCorrelativoFinal.TabIndex = 34
        Me.lbCorrelativoFinal.Text = "00000000000"
        '
        'LabelControl20
        '
        Me.LabelControl20.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl20.Location = New System.Drawing.Point(380, 79)
        Me.LabelControl20.Name = "LabelControl20"
        Me.LabelControl20.Size = New System.Drawing.Size(105, 16)
        Me.LabelControl20.TabIndex = 33
        Me.LabelControl20.Text = "Facturar en Serie:"
        '
        'cmbCoddocFinal
        '
        Me.cmbCoddocFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCoddocFinal.FormattingEnabled = True
        Me.cmbCoddocFinal.Location = New System.Drawing.Point(503, 79)
        Me.cmbCoddocFinal.Name = "cmbCoddocFinal"
        Me.cmbCoddocFinal.Size = New System.Drawing.Size(108, 21)
        Me.cmbCoddocFinal.TabIndex = 32
        '
        'cmbDiasCredito
        '
        Me.cmbDiasCredito.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDiasCredito.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDiasCredito.FormattingEnabled = True
        Me.cmbDiasCredito.Items.AddRange(New Object() {"1", "7", "15", "30", "45", "60", "90"})
        Me.cmbDiasCredito.Location = New System.Drawing.Point(289, 79)
        Me.cmbDiasCredito.Name = "cmbDiasCredito"
        Me.cmbDiasCredito.Size = New System.Drawing.Size(71, 21)
        Me.cmbDiasCredito.TabIndex = 31
        '
        'lbFechaVencimiento
        '
        Me.lbFechaVencimiento.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaVencimiento.Location = New System.Drawing.Point(23, 79)
        Me.lbFechaVencimiento.Name = "lbFechaVencimiento"
        Me.lbFechaVencimiento.Size = New System.Drawing.Size(113, 16)
        Me.lbFechaVencimiento.TabIndex = 30
        Me.lbFechaVencimiento.Text = "Fecha Vencimiento:"
        '
        'txtVentasFechaVence
        '
        Me.txtVentasFechaVence.EditValue = Nothing
        Me.txtVentasFechaVence.Location = New System.Drawing.Point(167, 79)
        Me.txtVentasFechaVence.Name = "txtVentasFechaVence"
        Me.txtVentasFechaVence.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVentasFechaVence.Properties.Appearance.Options.UseFont = True
        Me.txtVentasFechaVence.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtVentasFechaVence.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtVentasFechaVence.Size = New System.Drawing.Size(114, 22)
        Me.txtVentasFechaVence.TabIndex = 29
        '
        'btnDatosEntrega
        '
        Me.btnDatosEntrega.Image = CType(resources.GetObject("btnDatosEntrega.Image"), System.Drawing.Image)
        Me.btnDatosEntrega.Location = New System.Drawing.Point(627, 33)
        Me.btnDatosEntrega.Name = "btnDatosEntrega"
        Me.btnDatosEntrega.Size = New System.Drawing.Size(129, 26)
        Me.btnDatosEntrega.TabIndex = 28
        Me.btnDatosEntrega.Text = "Datos Adicionales ->"
        '
        'FlyoutPanelRepartos
        '
        Me.FlyoutPanelRepartos.Controls.Add(Me.FlyoutPanelControl1)
        Me.FlyoutPanelRepartos.Location = New System.Drawing.Point(711, 278)
        Me.FlyoutPanelRepartos.Name = "FlyoutPanelRepartos"
        Me.FlyoutPanelRepartos.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right
        Me.FlyoutPanelRepartos.Options.CloseOnOuterClick = True
        Me.FlyoutPanelRepartos.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Right
        Me.FlyoutPanelRepartos.OptionsBeakPanel.Opacity = 0.9R
        Me.FlyoutPanelRepartos.OwnerControl = Me
        Me.FlyoutPanelRepartos.Size = New System.Drawing.Size(399, 420)
        Me.FlyoutPanelRepartos.TabIndex = 27
        '
        'FlyoutPanelControl1
        '
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl19)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtObs)
        Me.FlyoutPanelControl1.Controls.Add(Me.btnCerrarFlyout)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl18)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl17)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl15)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl12)
        Me.FlyoutPanelControl1.Controls.Add(Me.LabelControl6)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtFlete)
        Me.FlyoutPanelControl1.Controls.Add(Me.cmbRepartidor)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtNoGuia)
        Me.FlyoutPanelControl1.Controls.Add(Me.txtDirEntrega)
        Me.FlyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlyoutPanelControl1.FlyoutPanel = Me.FlyoutPanelRepartos
        Me.FlyoutPanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.FlyoutPanelControl1.Name = "FlyoutPanelControl1"
        Me.FlyoutPanelControl1.Size = New System.Drawing.Size(399, 420)
        Me.FlyoutPanelControl1.TabIndex = 0
        '
        'LabelControl19
        '
        Me.LabelControl19.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl19.Location = New System.Drawing.Point(27, 53)
        Me.LabelControl19.Name = "LabelControl19"
        Me.LabelControl19.Size = New System.Drawing.Size(100, 18)
        Me.LabelControl19.TabIndex = 11
        Me.LabelControl19.Text = "Observaciones:"
        '
        'txtObs
        '
        Me.txtObs.EnterMoveNextControl = True
        Me.txtObs.Location = New System.Drawing.Point(27, 77)
        Me.txtObs.Name = "txtObs"
        Me.txtObs.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObs.Properties.Appearance.Options.UseFont = True
        Me.txtObs.Size = New System.Drawing.Size(342, 24)
        Me.txtObs.TabIndex = 0
        '
        'btnCerrarFlyout
        '
        Me.btnCerrarFlyout.Location = New System.Drawing.Point(5, 5)
        Me.btnCerrarFlyout.Name = "btnCerrarFlyout"
        Me.btnCerrarFlyout.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrarFlyout.TabIndex = 9
        Me.btnCerrarFlyout.Text = "Cerrar (x)"
        '
        'LabelControl18
        '
        Me.LabelControl18.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl18.Location = New System.Drawing.Point(224, 343)
        Me.LabelControl18.Name = "LabelControl18"
        Me.LabelControl18.Size = New System.Drawing.Size(16, 25)
        Me.LabelControl18.TabIndex = 8
        Me.LabelControl18.Text = "Q"
        '
        'LabelControl17
        '
        Me.LabelControl17.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl17.Location = New System.Drawing.Point(59, 343)
        Me.LabelControl17.Name = "LabelControl17"
        Me.LabelControl17.Size = New System.Drawing.Size(152, 18)
        Me.LabelControl17.TabIndex = 7
        Me.LabelControl17.Text = "Valor del Flete/Entrega:"
        '
        'LabelControl15
        '
        Me.LabelControl15.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl15.Location = New System.Drawing.Point(27, 261)
        Me.LabelControl15.Name = "LabelControl15"
        Me.LabelControl15.Size = New System.Drawing.Size(145, 18)
        Me.LabelControl15.TabIndex = 6
        Me.LabelControl15.Text = "Repartidor/Mensajero:"
        '
        'LabelControl12
        '
        Me.LabelControl12.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl12.Location = New System.Drawing.Point(27, 206)
        Me.LabelControl12.Name = "LabelControl12"
        Me.LabelControl12.Size = New System.Drawing.Size(142, 18)
        Me.LabelControl12.TabIndex = 5
        Me.LabelControl12.Text = "No. Guia/Documento:"
        '
        'LabelControl6
        '
        Me.LabelControl6.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl6.Location = New System.Drawing.Point(27, 130)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(138, 18)
        Me.LabelControl6.TabIndex = 4
        Me.LabelControl6.Text = "Dirección de Entrega:"
        '
        'txtFlete
        '
        Me.txtFlete.EnterMoveNextControl = True
        Me.txtFlete.Location = New System.Drawing.Point(246, 342)
        Me.txtFlete.Name = "txtFlete"
        Me.txtFlete.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFlete.Properties.Appearance.Options.UseFont = True
        Me.txtFlete.Properties.Mask.EditMask = "n2"
        Me.txtFlete.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtFlete.Size = New System.Drawing.Size(123, 30)
        Me.txtFlete.TabIndex = 4
        '
        'cmbRepartidor
        '
        Me.cmbRepartidor.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRepartidor.FormattingEnabled = True
        Me.cmbRepartidor.Location = New System.Drawing.Point(27, 291)
        Me.cmbRepartidor.Name = "cmbRepartidor"
        Me.cmbRepartidor.Size = New System.Drawing.Size(342, 26)
        Me.cmbRepartidor.TabIndex = 3
        '
        'txtNoGuia
        '
        Me.txtNoGuia.EnterMoveNextControl = True
        Me.txtNoGuia.Location = New System.Drawing.Point(186, 203)
        Me.txtNoGuia.Name = "txtNoGuia"
        Me.txtNoGuia.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoGuia.Properties.Appearance.Options.UseFont = True
        Me.txtNoGuia.Size = New System.Drawing.Size(183, 24)
        Me.txtNoGuia.TabIndex = 2
        '
        'txtDirEntrega
        '
        Me.txtDirEntrega.EnterMoveNextControl = True
        Me.txtDirEntrega.Location = New System.Drawing.Point(27, 154)
        Me.txtDirEntrega.Name = "txtDirEntrega"
        Me.txtDirEntrega.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirEntrega.Properties.Appearance.Options.UseFont = True
        Me.txtDirEntrega.Size = New System.Drawing.Size(342, 24)
        Me.txtDirEntrega.TabIndex = 1
        '
        'lbPorcentajeRecargo
        '
        Me.lbPorcentajeRecargo.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPorcentajeRecargo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbPorcentajeRecargo.Location = New System.Drawing.Point(24, 254)
        Me.lbPorcentajeRecargo.Name = "lbPorcentajeRecargo"
        Me.lbPorcentajeRecargo.Size = New System.Drawing.Size(41, 16)
        Me.lbPorcentajeRecargo.TabIndex = 26
        Me.lbPorcentajeRecargo.Text = "+ 5% "
        '
        'LabelControl14
        '
        Me.LabelControl14.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl14.Location = New System.Drawing.Point(24, 306)
        Me.LabelControl14.Name = "LabelControl14"
        Me.LabelControl14.Size = New System.Drawing.Size(50, 16)
        Me.LabelControl14.TabIndex = 23
        Me.LabelControl14.Text = "A pagar:"
        '
        'lbTotalAPagar
        '
        Me.lbTotalAPagar.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalAPagar.Appearance.ForeColor = System.Drawing.Color.Red
        Me.lbTotalAPagar.Location = New System.Drawing.Point(138, 304)
        Me.lbTotalAPagar.Name = "lbTotalAPagar"
        Me.lbTotalAPagar.Size = New System.Drawing.Size(176, 42)
        Me.lbTotalAPagar.TabIndex = 24
        Me.lbTotalAPagar.Text = "10,000.00"
        '
        'LabelControl16
        '
        Me.LabelControl16.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl16.Appearance.ForeColor = System.Drawing.Color.Red
        Me.LabelControl16.Location = New System.Drawing.Point(101, 303)
        Me.LabelControl16.Name = "LabelControl16"
        Me.LabelControl16.Size = New System.Drawing.Size(27, 42)
        Me.LabelControl16.TabIndex = 25
        Me.LabelControl16.Text = "Q"
        '
        'LabelControl11
        '
        Me.LabelControl11.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl11.Location = New System.Drawing.Point(24, 236)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(52, 16)
        Me.LabelControl11.TabIndex = 20
        Me.LabelControl11.Text = "Recargo:"
        '
        'lbTotalRecargo
        '
        Me.lbTotalRecargo.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotalRecargo.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbTotalRecargo.Location = New System.Drawing.Point(138, 229)
        Me.lbTotalRecargo.Name = "lbTotalRecargo"
        Me.lbTotalRecargo.Size = New System.Drawing.Size(176, 42)
        Me.lbTotalRecargo.TabIndex = 21
        Me.lbTotalRecargo.Text = "10,000.00"
        '
        'LabelControl13
        '
        Me.LabelControl13.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl13.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LabelControl13.Location = New System.Drawing.Point(101, 228)
        Me.LabelControl13.Name = "LabelControl13"
        Me.LabelControl13.Size = New System.Drawing.Size(27, 42)
        Me.LabelControl13.TabIndex = 22
        Me.LabelControl13.Text = "Q"
        '
        'txtCobrarTarjeta
        '
        Me.txtCobrarTarjeta.Location = New System.Drawing.Point(481, 231)
        Me.txtCobrarTarjeta.Name = "txtCobrarTarjeta"
        Me.txtCobrarTarjeta.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCobrarTarjeta.Properties.Appearance.Options.UseFont = True
        Me.txtCobrarTarjeta.Properties.Mask.EditMask = "n2"
        Me.txtCobrarTarjeta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtCobrarTarjeta.Size = New System.Drawing.Size(176, 46)
        Me.txtCobrarTarjeta.TabIndex = 3
        '
        'LabelControl7
        '
        Me.LabelControl7.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl7.Location = New System.Drawing.Point(369, 236)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(47, 16)
        Me.LabelControl7.TabIndex = 19
        Me.LabelControl7.Text = "Tarjeta:"
        '
        'LabelControl10
        '
        Me.LabelControl10.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl10.Location = New System.Drawing.Point(444, 228)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(27, 42)
        Me.LabelControl10.TabIndex = 18
        Me.LabelControl10.Text = "Q"
        '
        'btnAceptarTrue
        '
        Me.btnAceptarTrue.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptarTrue.Location = New System.Drawing.Point(357, 508)
        Me.btnAceptarTrue.Name = "btnAceptarTrue"
        Me.btnAceptarTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptarTrue.TabIndex = 16
        Me.btnAceptarTrue.TabStop = False
        Me.btnAceptarTrue.Text = "Aceptar"
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(380, 37)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(116, 16)
        Me.LabelControl3.TabIndex = 15
        Me.LabelControl3.Text = "Imprime al guardar:"
        '
        'SwitchImprime
        '
        Me.SwitchImprime.EditValue = True
        Me.SwitchImprime.Location = New System.Drawing.Point(511, 32)
        Me.SwitchImprime.Name = "SwitchImprime"
        Me.SwitchImprime.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SwitchImprime.Properties.Appearance.Options.UseFont = True
        Me.SwitchImprime.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.SwitchImprime.Properties.OffText = "NO"
        Me.SwitchImprime.Properties.OnText = "SI"
        Me.SwitchImprime.Size = New System.Drawing.Size(100, 26)
        Me.SwitchImprime.TabIndex = 1
        '
        'TimerCobro
        '
        Me.TimerCobro.Interval = 1000
        '
        'UserControlCobrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "UserControlCobrar"
        Me.Size = New System.Drawing.Size(796, 496)
        CType(Me.SwitchFormaPago.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCobrarPago.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtFechaFacturar.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFacturar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVentasFechaVence.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVentasFechaVence.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlyoutPanelRepartos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelRepartos.ResumeLayout(False)
        CType(Me.FlyoutPanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlyoutPanelControl1.ResumeLayout(False)
        Me.FlyoutPanelControl1.PerformLayout()
        CType(Me.txtObs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFlete.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoGuia.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDirEntrega.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCobrarTarjeta.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SwitchImprime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SwitchFormaPago As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtCobrarPago As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LB_CobrarTotalVenta As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LbVueltoQ As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LB_CobrarVuelto As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCobrarAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SwitchImprime As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents btnAceptarTrue As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtCobrarTarjeta As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl14 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalAPagar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl16 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbTotalRecargo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl13 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lbPorcentajeRecargo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents FlyoutPanelRepartos As DevExpress.Utils.FlyoutPanel
    Friend WithEvents FlyoutPanelControl1 As DevExpress.Utils.FlyoutPanelControl
    Friend WithEvents LabelControl18 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl17 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl15 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl12 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFlete As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmbRepartidor As ComboBox
    Friend WithEvents txtNoGuia As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtDirEntrega As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnCerrarFlyout As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnDatosEntrega As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl19 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtObs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lbFechaVencimiento As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtVentasFechaVence As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmbDiasCredito As ComboBox
    Friend WithEvents LabelControl20 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbCoddocFinal As ComboBox
    Friend WithEvents lbCorrelativoFinal As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl21 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFechaFacturar As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TimerCobro As Timer
    Friend WithEvents btnUnlockSerieFinal As DevExpress.XtraEditors.SimpleButton
End Class
