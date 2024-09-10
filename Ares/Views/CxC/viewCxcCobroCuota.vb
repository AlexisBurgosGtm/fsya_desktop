Public Class viewCxcCobroCuota

    Sub New(ByVal DatosFactura As DataRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        datos = DatosFactura
    End Sub

    Dim datos As DataRow

    Dim ObjCxc As New ClassCxc()
    Dim ObjEmpleados As New ClassEmpleados()
    Dim ObjGeneral As New ClassGeneral()

    Dim CorrelativoRecibo As Double



    Private Sub viewCxcCobroCuota_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CorrelativoRecibo = ObjGeneral.fcnObtenerCorrelativo(GlobalEmpNit, GlobalCoddocReciboCliente)

        Me.lbNoRecibo.Text = GlobalCoddocReciboCliente & " - " & CorrelativoRecibo.ToString

        CodCliente = CType(datos.Item(8), Integer)

        Me.txtFechaAbono.DateTime = Today.Date
        Me.lbFactura.Text = datos.Item(6).ToString & " - " & datos.Item(7).ToString

        Me.lbNit.Text = datos.Item(0).ToString

        Me.LbCliente.Text = datos.Item(1).ToString

        Me.LbFecha.Text = datos.Item(4).ToString

        Me.txtAbono.Text = datos.Item(5).ToString 'Strings.Mid(datos.Item(5).ToString, 2)

        Me.txtFechaAbono.select()

        'vendedor que cobró
        With cmbEmpleado
            .DataSource = ObjEmpleados.tblListaEmpleados(GlobalEmpNit)
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"
        End With
    End Sub


    Dim CodCliente As Integer
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        MsgBox("Opción aún no disponible")

        Exit Sub

        If Me.txtObs.Text <> "" Then
        Else
            Me.txtObs.Text = "SN"
        End If

        If Me.txtAbono.Text <> "" Then

            If Confirmacion("¿Está seguro que desea crear este recibo/cobro?", Me.ParentForm) = True Then


                Dim Saldo As Double = 0 'Double.Parse(Me.LbSaldo.Text) - Double.Parse(Me.txtAbono.Text)
                Dim AbonoActual As Double = 0 'Double.Parse(Me.LbAbonos.Text) + Double.Parse(Me.txtAbono.Text)

                If ObjCxc.GuardarNuevoCobro(
                    GlobalEmpNit,
                    1,
                    CodCliente,
                    GlobalCoddocReciboCliente,
                    CorrelativoRecibo,
                    Double.Parse(Me.txtAbono.Text),
                    Me.txtFechaAbono.DateTime,
                    Me.txtObs.Text,
                    CType(Me.cmbEmpleado.SelectedValue, Integer),
                    datos.Item(0).ToString,
                    Me.LbCliente.Text,
                    Saldo,
                    AbonoActual,
                    datos.Item(6).ToString,
                    Double.Parse(datos.Item(7)),
                    Integer.Parse(datos.Item(3))
                    ) = True Then

                    'Call Form1.EnviarNotificacionesEmail(0, "Ares te informa: Abono a factura No. " & Me.lbFactura.Text, "Se ingresó el recibo de cobro No. " & GlobalCoddocReciboCliente & " " & CorrelativoRecibo & " extendida al cliente " & Me.LbCliente.Text & " por un valor de " & FormatCurrency(Me.txtAbono.Text) & " usando el usuario " & GlobalNomUsuario)

                    ObjGeneral.fcnActualizarCorrelativo(GlobalEmpNit, GlobalCoddocReciboCliente, CorrelativoRecibo)
                    'disminuye el saldo del cliente
                    If ObjCxc.DisminuirSaldoCliente(GlobalEmpNit, Me.lbNit.Text, Double.Parse(Me.txtAbono.Text)) = True Then
                    End If
                    'abre el reporte
                    Dim ObjReports As New ClassReports
                    If ObjReports.rptReciboCliente(GlobalEmpNit, Me.txtFechaAbono.DateTime, GlobalCoddocReciboCliente, CorrelativoRecibo) = True Then
                    Else
                        MsgBox(GlobalDesError)
                    End If

                    'Call Aviso("Éxito", "Cobro registrado exitosamente", Me.ParentForm)
                Else
                    MsgBox(GlobalDesError)
                    Call Aviso("Error", "No se pudo registrar el cobro", Me.ParentForm)
                End If







            End If



        Else
            MsgBox("No indicó el monto a abonar")
        End If
    End Sub

    Private Sub cmbEmpleado_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEmpleado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtAbono.select()
        End If
    End Sub

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardar.select()
        End If
    End Sub






End Class
