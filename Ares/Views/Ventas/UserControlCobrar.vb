Imports DevExpress.XtraBars.Docking2010.Customization

Public Class UserControlCobrar

    Private Sub UserControlCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.lbPorcentajeRecargo.Text = Form1.txtConfigPorcentajeTarjeta.Text & " %"

        Me.LB_CobrarTotalVenta.Text = FormatNumber(VentasTotalVenta, 2)
        Me.lbTotalRecargo.Text = "0.00"
        Me.lbTotalAPagar.Text = FormatNumber(VentasTotalVenta, 2)


        Select Case GlobalTipoCobro
            Case 0
                Me.txtCobrarPago.Text = FormatNumber(VentasTotalVenta, 2)
                Me.txtCobrarTarjeta.Text = 0
                Me.txtCobrarTarjeta.Enabled = False
            Case 1
                Me.txtCobrarPago.Text = 0
                Me.txtCobrarTarjeta.Text = FormatNumber(VentasTotalVenta, 2)
                Me.txtCobrarPago.Enabled = False
            Case 2
                Me.txtCobrarPago.Text = FormatNumber(VentasTotalVenta, 2)
                Me.txtCobrarTarjeta.Text = 0
            Case 3
                Me.txtCobrarPago.Text = 0
                Me.txtCobrarTarjeta.Text = FormatNumber(VentasTotalVenta, 2)
                Me.txtCobrarPago.Enabled = False
                Me.LabelControl7.Text = "Visalink:"
        End Select




        Me.LB_CobrarVuelto.Text = "0.00"

        'establece la fecha de vencimiento
        Me.txtVentasFechaVence.DateTime = Form1.txtVentasFecha.DateTime
        Me.cmbDiasCredito.Text = 0

        'cambia según la forma de pago predeterminada
        If Form1.SwitchConfigConCre.IsOn = True Then
            Me.SwitchFormaPago.IsOn = False
            Me.lbFechaVencimiento.Visible = True
            Me.txtVentasFechaVence.Enabled = True
            Me.cmbDiasCredito.Enabled = True
            Me.txtVentasFechaVence.DateTime = Today.Date.AddDays(Integer.Parse(Me.cmbDiasCredito.Text))
        Else
            Me.SwitchFormaPago.IsOn = True
            Me.lbFechaVencimiento.Visible = False
            Me.txtVentasFechaVence.Enabled = False
            Me.cmbDiasCredito.Enabled = False
            Me.txtVentasFechaVence.DateTime = Form1.txtVentasFecha.DateTime
        End If

        'establece si se imprimirá por defecto según la configuración
        If Form1.SwitchImprimirTicket.IsOn = True Then
            If Form1.switchFELVentas.IsOn = True Then
                Me.SwitchImprime.IsOn = False
            Else
                Me.SwitchImprime.IsOn = True
            End If

        Else
            Me.SwitchImprime.IsOn = False
        End If

        Me.txtObs.Text = VentasObs
        Me.txtDirEntrega.Text = VentasDirEntrega
        Me.txtNoGuia.Text = "SN"
        Me.cmbRepartidor.SelectedValue = VentasCodRepartidor
        Me.txtFlete.Text = "0"

        'Pre-carga el coddoc final y correlativo final
        Call CargarComboCoddoc()
        'carga la fecha de facturación para fecha nueva
        Me.txtFechaFacturar.DateTime = Form1.txtVentasFecha.DateTime

        Me.cmbCoddocFinal.SelectedValue = Form1.cmbVentasCoddoc.SelectedValue.ToString
        Me.lbCorrelativoFinal.Text = Form1.txtVentasCorrelativo.Text

        If GlobalSelectedTipoDocumento = "FEF" Then
            Me.SwitchFormaPago.IsOn = True
            Me.SwitchFormaPago.Enabled = False
            Me.cmbCoddocFinal.Enabled = False
        End If
        If GlobalSelectedTipoDocumento = "FEC" Then
            Me.SwitchFormaPago.IsOn = False
            Me.SwitchFormaPago.Enabled = False
            Me.cmbCoddocFinal.Enabled = False
        End If

        If NivelUsuario = 1 Then
            Me.cmbCoddocFinal.Enabled = True
        Else

            Me.cmbCoddocFinal.Enabled = False

        End If
        'inicia el timer para mostrar la flyout de tipo cobro
        'verifica si está activada la opción de tipo de pago
        'If Form1.switchConfigClienteTipoCobro.IsOn = True Then
        'Me.TimerCobro.Start()
        'End If

    End Sub

    Private Sub CalculaVuelto()
        If Me.txtCobrarTarjeta.Text <> "" Then
            If Double.Parse(Me.txtCobrarTarjeta.Text) > 0 Then
                'Me.lbTotalRecargo.Text = FormatNumber((Double.Parse(Form1.txtConfigPorcentajeTarjeta.Text) / 100) * Double.Parse(Me.txtCobrarTarjeta.Text), 2)
                Me.lbTotalRecargo.Text = FormatNumber((Double.Parse(Form1.txtConfigPorcentajeTarjeta.Text) / 100) * Double.Parse(Me.LB_CobrarTotalVenta.Text), 2)
            Else
                Me.lbTotalRecargo.Text = "0.00"
            End If
        Else
            Me.lbTotalRecargo.Text = "0.00"
        End If


        Me.lbTotalAPagar.Text = FormatNumber(Double.Parse(Me.LB_CobrarTotalVenta.Text) + Double.Parse(Me.lbTotalRecargo.Text))

        'Me.LB_CobrarVuelto.Text = FormatNumber((Double.Parse(txtCobrarPago.Text) + Double.Parse(Me.txtCobrarTarjeta.Text) + Double.Parse(Me.lbTotalRecargo.Text)) - Double.Parse(Me.lbTotalAPagar.Text), 2)
        Me.LB_CobrarVuelto.Text = FormatNumber((Double.Parse(txtCobrarPago.Text) + Double.Parse(Me.txtCobrarTarjeta.Text)) - Double.Parse(Me.lbTotalAPagar.Text), 2)

        'va cambiando el color del vuelto para que el usuario tenga una guía válida
        If Double.Parse(Me.LB_CobrarVuelto.Text) = 0 Then
            Me.LB_CobrarVuelto.ForeColor = Color.DarkOrange
            Me.LbVueltoQ.ForeColor = Color.DarkOrange
        End If
        If Double.Parse(Me.LB_CobrarVuelto.Text) > 0 Then
            Me.LB_CobrarVuelto.ForeColor = Color.SkyBlue
            Me.LbVueltoQ.ForeColor = Color.SkyBlue
        End If
        If Double.Parse(Me.LB_CobrarVuelto.Text) < 0 Then
            Me.LB_CobrarVuelto.ForeColor = Color.Red
            Me.LbVueltoQ.ForeColor = Color.Red
        End If

    End Sub

    Private Sub txtCobrarPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCobrarPago.KeyDown

        If e.KeyCode = Keys.Enter Then
            Try
                Call CalculaVuelto()

            Catch ex As Exception
            End Try

            If GlobalTipoCobro = 2 Then
                Me.txtCobrarTarjeta.Text = FormatNumber(VentasTotalVenta, 2) - FormatNumber(Double.Parse(txtCobrarPago.Text), 2)
                Me.txtCobrarTarjeta.select()
                'Me.cmdCobrarAceptar.select()
            Else
                Me.cmdCobrarAceptar.select()
            End If

        End If

    End Sub

    Private Sub txtCobrarTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCobrarTarjeta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                'Me.LB_CobrarVuelto.Text = FormatNumber(Double.Parse(txtCobrarPago.Text) - Double.Parse(Me.LB_CobrarTotalVenta.Text), 2)
                Call CalculaVuelto()
            Catch ex As Exception
            End Try

            Me.cmdCobrarAceptar.select()
        End If
    End Sub

    Private Sub cmdCobrarAceptar_Click(sender As Object, e As EventArgs) Handles cmdCobrarAceptar.Click

        Me.lbCorrelativoFinal.Text = objTipoDocs.GetCorrelativoDoc(Me.cmbCoddocFinal.SelectedValue.ToString).ToString

        Call CargarGridTempVentas()

        If Double.Parse(Form1.LbTotalVenta.Text) > 0 Then

            If Me.cmbCoddocFinal.SelectedIndex >= 0 Then
            Else
                Me.cmbCoddocFinal.SelectedIndex = 0
            End If


            If Me.txtDirEntrega.Text <> "" Then
            Else
                Me.txtDirEntrega.Text = "CIUDAD"
            End If
            VentasDirEntrega = Me.txtDirEntrega.Text

            If Me.txtNoGuia.Text <> "" Then
            Else
                Me.txtNoGuia.Text = "SN"
            End If

            If Me.txtObs.Text <> "" Then
                VentasObs = Me.txtObs.Text
            Else
                VentasObs = "SN"
            End If

            VentasFechaVencimiento = Me.txtVentasFechaVence.DateTime
            VentasDiasCredito = Integer.Parse(Me.cmbDiasCredito.Text)


            If cmbRepartidor.SelectedIndex >= 0 Then
                VentasCodRepartidor = CType(Me.cmbRepartidor.SelectedValue, Integer)
            Else
                VentasCodRepartidor = 0
            End If



            'si el pago es al crédito
            If GlobalTipoCobro = 1 Then
            Else
                If Me.txtCobrarPago.Enabled = False Then
                    Form1.PagoCliente = 0
                    Form1.PagoClienteTarjeta = 0
                    Form1.PagoRecargoTarjeta = 0

                    'asigna los valores de fecha vencimiento
                    GlobalSelectedFechaVence = Me.txtVentasFechaVence.DateTime
                    GlobalSelectedCantidadCuotas = CType(Me.cmbDiasCredito.Text, Integer)

                    GoTo TerminarSiCredito
                End If
            End If



            Dim totalpagar, totalpagado As Double
            totalpagar = Double.Parse(Me.lbTotalAPagar.Text)
            totalpagado = Double.Parse(Me.txtCobrarPago.Text) + Double.Parse(Me.txtCobrarTarjeta.Text)

            If totalpagar > totalpagado Then
                MsgBox("El monto cobrado es menor al total a Pagar.. por favor, verifique")
                Exit Sub

            Else
                GoTo TerminarCobro

            End If

TerminarCobro:



            GlobalCoddocFinal = Me.cmbCoddocFinal.SelectedValue.ToString
            GlobalFechaFinal = Me.txtFechaFacturar.DateTime
            Form1.txtVentasFecha.DateTime = Me.txtFechaFacturar.DateTime

            GlobalCorrelativoFinal = Double.Parse(Me.lbCorrelativoFinal.Text)

            'asigna el total pagado en efectivo
            If Me.txtCobrarPago.Text <> "" Then
                Form1.PagoCliente = Double.Parse(Me.txtCobrarPago.Text)
            Else
                Form1.PagoCliente = 0
            End If

            'asigna el total pagado en tarjeta

            If Me.txtCobrarTarjeta.Text <> "" Then
                Form1.PagoClienteTarjeta = Double.Parse(Me.txtCobrarTarjeta.Text)
            Else
                Form1.PagoClienteTarjeta = 0
            End If

            'asigna el pago de recargo por la tarjeta
            Form1.PagoRecargoTarjeta = Double.Parse(Me.lbTotalRecargo.Text)


TerminarSiCredito:
            GlobalCoddocFinal = Me.cmbCoddocFinal.SelectedValue.ToString
            GlobalFechaFinal = Me.txtFechaFacturar.DateTime
            Form1.txtVentasFecha.DateTime = Me.txtFechaFacturar.DateTime

            GlobalCorrelativoFinal = Double.Parse(Me.lbCorrelativoFinal.Text)

            'deshabilita el botón aceptar para que no se guarde varias veces
            Me.cmdCobrarAceptar.Enabled = False

            'asigna el valor del switch de impresión al booleano global
            If Me.SwitchImprime.IsOn = True Then
                GlobalInteger = 1
            Else
                GlobalInteger = 0
            End If
            If Form1.GuardarVenta() = True Then
                'SendKeys.Send("{ESC}")

                Me.btnAceptarTrue.PerformClick()
            Else
                MsgBox("Lo siento, no se pudo guardar la venta (El servidor no respondió correctamente). Error: " & GlobalDesError)

                'lo vuelve a habilitar por si las moscas
                Me.cmdCobrarAceptar.Enabled = True

            End If

            Form1.checkMOS.Checked = True

        Else

            MsgBox("Documento en blanco, por favor coloque de nuevo los productos")
            Exit Sub

        End If

    End Sub



    Dim objTipoDocs As New ClassTipoDocumentos(GlobalEmpNit)
    'coddoc final
    Private Sub CargarComboCoddoc()
        With Me.cmbCoddocFinal
            .DataSource = objTipoDocs.tblCoddoc("FAC")
            .DisplayMember = "CODDOC"
            .ValueMember = "CODDOC"
        End With
    End Sub

    'recarga el correlativo del coddoc
    Private Sub cmbCoddocFinal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoddocFinal.SelectedIndexChanged

        Try
            Me.lbCorrelativoFinal.Text = objTipoDocs.GetCorrelativoDoc(Me.cmbCoddocFinal.SelectedValue.ToString).ToString

        Catch ex As Exception
            Me.lbCorrelativoFinal.Text = "0"
        End Try
        'GlobalSelectedTipoDocumento = objTipoDocs.getTipoDocumento(Me.cmbCoddocFinal.SelectedValue.ToString)
    End Sub


    Private Sub CargarComboRepartidores()
        Dim objReparto As New classRepartidores
        Me.cmbRepartidor.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.cmbRepartidor.AutoCompleteSource = AutoCompleteSource.ListItems

        With cmbRepartidor
            .DataSource = objReparto.tblRepartidoresActivos(GlobalEmpNit)
            .ValueMember = "CODREP"
            .DisplayMember = "DESREP"

        End With

    End Sub


    Private Sub SwitchFormaPago_KeyDown(sender As Object, e As KeyEventArgs) Handles SwitchFormaPago.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.SwitchFormaPago.IsOn = True Then
                VentasConCre = "CON"
                'Me.txtCobrarPago.Enabled = True
                'Me.txtCobrarTarjeta.Enabled = True
                'Me.txtCobrarPago.select()
                Me.SwitchImprime.select()
            Else
                VentasConCre = "CRE"
                Me.txtCobrarPago.Enabled = False
                Me.txtCobrarTarjeta.Enabled = False
                'Me.cmdCobrarAceptar.select()
                Me.SwitchImprime.select()
            End If

        End If
    End Sub

    Private Sub SwitchFormaPago_Toggled(sender As Object, e As EventArgs) Handles SwitchFormaPago.Toggled
        If Me.SwitchFormaPago.IsOn = True Then
            VentasConCre = "CON"
            'Me.txtCobrarPago.Enabled = True
            'Me.txtCobrarTarjeta.Enabled = True

            Me.txtVentasFechaVence.Enabled = False
            Me.cmbDiasCredito.Enabled = False
            Me.lbFechaVencimiento.Visible = False
        Else
            VentasConCre = "CRE"
            Me.txtCobrarPago.Enabled = False
            Me.txtCobrarTarjeta.Enabled = False

            Me.txtVentasFechaVence.Enabled = True
            Me.cmbDiasCredito.Enabled = True
            Me.lbFechaVencimiento.Visible = True
        End If
    End Sub

    Private Sub SwitchImprime_KeyDown(sender As Object, e As KeyEventArgs) Handles SwitchImprime.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtCobrarPago.Enabled = True Then
                Me.txtCobrarPago.select()
            Else
                If Me.txtCobrarTarjeta.Enabled = True Then
                    Me.txtCobrarTarjeta.select()
                Else
                    Me.cmdCobrarAceptar.select()
                End If
                Me.cmdCobrarAceptar.select()
            End If

        End If
    End Sub

    Private Sub txtCobrarPago_Leave(sender As Object, e As EventArgs) Handles txtCobrarPago.Leave
        Call CalculaVuelto()
    End Sub

    Private Sub txtCobrarTarjeta_Leave(sender As Object, e As EventArgs) Handles txtCobrarTarjeta.Leave
        Call CalculaVuelto()
    End Sub

    'para que no sea complicado para el usuario, cuando el control recibe focus se aplica el recargo,
    'en caso de no necesitarse dicho recargo, la rutina de CalcularVuelto lo corrigiría
    Private Sub txtCobrarTarjeta_Enter(sender As Object, e As EventArgs) Handles txtCobrarTarjeta.Enter
        'calcula el recargo
        Me.lbTotalRecargo.Text = FormatNumber((Double.Parse(Form1.txtConfigPorcentajeTarjeta.Text) / 100) * Double.Parse(Me.LB_CobrarTotalVenta.Text), 2)
        'suma al total de la venta
        Me.lbTotalAPagar.Text = FormatNumber(Double.Parse(Me.LB_CobrarTotalVenta.Text) + Double.Parse(Me.lbTotalRecargo.Text))
    End Sub

    Private Sub cmbRepartidor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbRepartidor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtFlete.select()
        End If
    End Sub

    Private Sub btnCerrarFlyout_Click(sender As Object, e As EventArgs) Handles btnCerrarFlyout.Click

        Me.FlyoutPanelRepartos.HidePopup()

    End Sub

    Private Sub btnDatosEntrega_Click(sender As Object, e As EventArgs) Handles btnDatosEntrega.Click
        Me.FlyoutPanelRepartos.ShowPopup()
        Me.txtObs.select()
    End Sub

    Private Sub cmbDiasCredito_TextChanged(sender As Object, e As EventArgs) Handles cmbDiasCredito.TextChanged
        Try
            Me.txtVentasFechaVence.DateTime = Form1.txtVentasFecha.DateTime.AddDays(Integer.Parse(Me.cmbDiasCredito.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUnlockSerieFinal_Click(sender As Object, e As EventArgs) Handles btnUnlockSerieFinal.Click
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
            Me.cmbCoddocFinal.Enabled = True
        End If
    End Sub

End Class
