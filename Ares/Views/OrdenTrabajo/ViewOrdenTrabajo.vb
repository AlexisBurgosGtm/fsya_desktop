Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class ViewOrdenTrabajo

    Dim objOrdenTrab As New classOrdenTrabajo(GlobalEmpNit)
    Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
    Dim drw As DataRow


    Private Sub ViewOrdenTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtFecha.DateTime = Today.Date
        Me.txtFechaEntrega.DateTime = Today.Date

        Me.txtCorrelativo.Text = objTipoDoc.GetCorrelativoDoc("ORDTRAB").ToString

        Call CargarGridListado()

        AddHandler Me.txtValor.Leave, AddressOf CalcularSaldoOrden
        AddHandler Me.txtAdelanto.Leave, AddressOf CalcularSaldoOrden

    End Sub

    Private Sub CargarGridListado()
        Me.GridListado.DataSource = Nothing
        Me.GridListado.DataSource = objOrdenTrab.SelectOrdenesPendientes
        Me.GridListado.RefreshDataSource()
    End Sub

    Private Sub LimpiarDatos()
        Me.txtCodCliente.Text = ""
        Me.txtNomCliente.Text = ""
        Me.txtCodVehiculo.Text = ""
        Me.txtDesVehiculo.Text = ""
        Me.txtDetRevision.Text = ""
        Me.txtObs.Text = ""
        Me.txtValor.Text = 0
        Me.txtAdelanto.Text = 0
        Me.txtSaldo.Text = 0
        Me.txtFechaEntrega.DateTime = Today.Date
        Me.txtFecha.DateTime = Today.Date
    End Sub

    Private Sub btnBuscarCliente_Click(sender As Object, e As EventArgs) Handles btnBuscarCliente.Click
        If FlyoutDialog.Show(Me.ParentForm, New viewClientesLista(GlobalEmpNit, SelectedForm)) = DialogResult.OK Then
            Me.txtCodCliente.Text = SelectedCode
            Me.txtNomCliente.Text = GlobalNomCliente
            'Call CargarVehiculosCliente(CType(Me.txtCodCliente.Text, Integer))
        End If
    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Me.txtCodCliente.Text <> "" Then
            If Me.txtCodVehiculo.Text <> "" Then
                If Me.txtDetRevision.Text <> "" Then
                    If Me.txtObs.Text <> "" Then
                    Else
                        Me.txtObs.Text = "SN"
                    End If

                    If Confirmacion("¿Está seguro que desea registrar esta Orden de Trabajo?", Me.ParentForm) = True Then
                        Dim d As String = "ORDTRAB"
                        Dim c As Double = Double.Parse(Me.txtCorrelativo.Text)

                        If objOrdenTrab.InsertOrdenTrabajo(Me.txtFecha.DateTime, d, c, Integer.Parse(Me.txtCodCliente.Text), Integer.Parse(Me.txtCodVehiculo.Text), Me.txtDetRevision.Text, Me.txtObs.Text, Double.Parse(Me.txtValor.Text), Double.Parse(Me.txtAdelanto.Text), Double.Parse(Me.txtSaldo.Text), Me.txtFechaEntrega.DateTime) = True Then
                            'Form1.EnviarNotificacionesEmail(0, "ARES te informa: Nueva Orden de Trabajo", "Se ha creado la orden de trabajo número " + Me.txtCorrelativo.Text + " por un valor de " + FormatCurrency(Double.Parse(Me.txtValor.Text)))

                            Call LimpiarDatos()
                            Call Aviso("EXITO AL GUARDAR", "Orden de Trabajo registrada con Éxito", Me.ParentForm)
                            Dim correlactual As Double = Double.Parse(Me.txtCorrelativo.Text)
                            Me.txtCorrelativo.Text = objTipoDoc.UpdateCorrelativoDoc("ORDTRAB", correlactual).ToString
                            Call CargarGridListado()
                            Me.NavFrame.SelectedPage = NPListado

                            objOrdenTrab.rptOrdenTrabajo(d, c)
                        Else
                            MsgBox("Error al guardar. " & GlobalDesError)
                        End If
                    End If



                Else
                    MsgBox("Escriba el detalle de lo que se Realizará/Revisará al vehículo")
                End If

            Else
                MsgBox("Seleccione un vehículo")
            End If
        Else
            MsgBox("Seleccione un Cliente")
        End If




    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If Confirmacion("¿Está seguro que desea cancelar esta orden?", Me.ParentForm) = True Then
            Call LimpiarDatos()
            Me.NavFrame.SelectedPage = NPListado
        End If

    End Sub

    Private Sub txtDetRevision_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDetRevision.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtObs.select()
        End If
    End Sub

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtFechaEntrega.select()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarDatos()
        Me.NavFrame.SelectedPage = NPDetalles
    End Sub

    Dim drw2 As DataRow
    Private Sub GridViewListado_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewListado.FocusedRowChanged
        Try
            drw2 = Nothing
            drw2 = Me.GridViewListado.GetFocusedDataRow
            Call CargarDatosOrden()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarDatosOrden()
        Try
            Me.lbSelectedCoddoc.Text = drw2.Item(12).ToString
            Me.lbSelectedCorrelativo.Text = drw2.Item(13).ToString

            Me.txtlistadoOrden.Text = drw2.Item(7).ToString
            Me.txtListadoObs.Text = drw2.Item(8).ToString

            Me.txtListadoValor.Text = drw2.Item(9)
            Me.txtListadoAbono.Text = drw2.Item(10)
            Me.txtListadoSaldo.Text = drw2.Item(11)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CalcularSaldoOrden()
        Dim valor, adelanto, saldo As Double

        If Me.txtValor.Text <> "" Then
            valor = Double.Parse(Me.txtValor.Text)
        Else
            valor = 0
        End If
        If Me.txtAdelanto.Text <> "" Then
            adelanto = Double.Parse(Me.txtAdelanto.Text)
        Else
            adelanto = 0
        End If

        saldo = valor - adelanto
        Me.txtSaldo.Text = saldo

    End Sub

    Private Sub WindowsUIButtonPanelOrdtrab_ButtonClick(sender As Object, e As ButtonEventArgs)
        Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
        Select Case tag

            Case "IMPRIMIR"
                objOrdenTrab.rptOrdenTrabajo(Me.lbSelectedCoddoc.Text, Double.Parse(Me.lbSelectedCorrelativo.Text))

            Case "EDITAR"

            Case "TERMINAR"
                If FlyoutDialog.Show(Me.ParentForm, New viewOrdenTrabajoTerminar(Me.lbSelectedCoddoc.Text, Double.Parse(Me.lbSelectedCorrelativo.Text), Double.Parse(Me.txtListadoValor.Text), Double.Parse(Me.txtListadoAbono.Text), Double.Parse(Me.txtListadoSaldo.Text))) = DialogResult.OK Then
                    Call CargarGridListado()
                    MsgBox("Orden de Trabajo Finalizada Exitosamente")
                End If

            Case "ELIMINAR"
                If Confirmacion("¿Está seguro que desea Eliminar esta Orden de Trabajo?", Me.ParentForm) = True Then
                    If objOrdenTrab.DeleteOrdenTrabajo(Me.lbSelectedCoddoc.Text, Double.Parse(Me.lbSelectedCorrelativo.Text)) = True Then
                        Call CargarGridListado()
                    Else
                        MsgBox("No se pudo Eliminar esta orden de trabajo. Error: " & GlobalDesError)
                    End If
                End If

        End Select

    End Sub

    Private Sub GridViewListado_DoubleClick(sender As Object, e As EventArgs) Handles GridViewListado.DoubleClick
        Try
            Me.RadMenOrdenes.ShowPopup(MousePosition)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar2_Click(sender As Object, e As EventArgs) Handles btnCancelar2.Click
        Me.btnCancelar.PerformClick()
    End Sub

    Private Sub RadMenBtnImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenBtnImprimir.ItemClick
        objOrdenTrab.rptOrdenTrabajo(Me.lbSelectedCoddoc.Text, Double.Parse(Me.lbSelectedCorrelativo.Text))
    End Sub

    Private Sub RadMenBtnEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenBtnEditar.ItemClick
        If Confirmacion("¿Está seguro que desea Editar esta orden?", Me.ParentForm) = True Then
            If FlyoutDialog.Show(Me.ParentForm, New viewOrdenTrabajoEditar(
                                 drw2.Item(12).ToString,
                                 Double.Parse(drw2.Item(13).ToString),
                                 drw2.Item(7).ToString,
                                 drw2.Item(8).ToString,
                                 Double.Parse(drw2.Item(9))
                                 )) = DialogResult.OK Then
                Call CargarGridListado()

            End If
        End If
    End Sub

    Private Sub RadMenBtnTerminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenBtnTerminar.ItemClick
        If FlyoutDialog.Show(Me.ParentForm, New viewOrdenTrabajoTerminar(Me.lbSelectedCoddoc.Text, Double.Parse(Me.lbSelectedCorrelativo.Text), Double.Parse(Me.txtListadoValor.Text), Double.Parse(Me.txtListadoAbono.Text), Double.Parse(Me.txtListadoSaldo.Text))) = DialogResult.OK Then
            Call CargarGridListado()
            MsgBox("Orden de Trabajo Finalizada Exitosamente")
        End If
    End Sub

    Private Sub RadMenEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenEliminar.ItemClick
        If Confirmacion("¿Está seguro que desea Eliminar esta Orden de Trabajo?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                If objOrdenTrab.DeleteOrdenTrabajo(Me.lbSelectedCoddoc.Text, Double.Parse(Me.lbSelectedCorrelativo.Text)) = True Then
                    'Call Form1.EnviarNotificacionesEmail(0, "Ares te Informa: Eliminación de Orden de Trabajo", "El usuario " & GlobalNomUsuario & " Ha eliminado el documento " & Me.lbSelectedCoddoc.Text & "-" & Me.lbSelectedCorrelativo.Text)
                    Call CargarGridListado()
                Else
                    MsgBox("No se pudo Eliminar esta orden de trabajo. Error: " & GlobalDesError)
                End If
            End If

        End If
    End Sub

    Private Sub btnBuscarVehiculo_Click(sender As Object, e As EventArgs) Handles btnBuscarVehiculo.Click
        If FlyoutDialog.Show(Me.ParentForm, New viewClientesVehiculos("MODAL")) = DialogResult.OK Then
            Me.txtCodVehiculo.Text = SelectedCode
            Me.txtDesVehiculo.Text = SelectedDescripcion
        End If
    End Sub

    Private Sub btnHistorialVehiculo_Click(sender As Object, e As EventArgs) Handles btnHistorialVehiculo.Click
        If Me.txtCodVehiculo.Text <> "" Then
            Try
                Dim objReports As New ClassReports
                If objReports.rptServiciosVehiculo(GlobalEmpNit, CType(Me.txtCodVehiculo.Text, Integer)) = True Then

                Else
                    MsgBox("No se pudo cargar el historial del Vehículo. Error: " & GlobalDesError)
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnClienteNuevo_Click(sender As Object, e As EventArgs) Handles btnClienteNuevo.Click
        If FlyoutDialog.Show(Me.ParentForm, New UserControlClienteNuevo()) = DialogResult.OK Then
            Me.txtCodCliente.Text = SelectedCode
            Me.txtNomCliente.Text = GlobalNomCliente
        End If
    End Sub
End Class
