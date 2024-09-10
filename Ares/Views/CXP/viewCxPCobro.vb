Imports System.Data.SqlClient

Public Class viewCxPCobro
    Sub New(ByVal _coddoc As String, ByVal _correlativo As Double, ByVal _codcliente As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        coddoc = _coddoc
        correlativo = _correlativo
        codcliente = _codcliente
    End Sub

    Dim coddoc As String, correlativo As Double, codcliente As Integer
    Dim objDocs As New ClassTipoDocumentos(GlobalEmpNit)
    Dim coddocRecP As String, correlativoRecP As Double

    Private Sub cmbCoddoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoddoc.SelectedIndexChanged
        Me.lbNoRecibo.Text = objDocs.GetCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString).ToString
    End Sub

    Private Sub viewCxPCobro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtFechaAbono.DateTime = Today.Date
        Me.lbFactura.Text = coddoc & "-" & correlativo.ToString

        Call getDataCompra(coddoc, correlativo)

        With Me.cmbCoddoc
            .DataSource = objDocs.tblCoddoc("RCP")
            .DisplayMember = "CODDOC"
            .ValueMember = "CODDOC"
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

        Me.lbNoRecibo.Text = objDocs.GetCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString).ToString

        Me.cmbTipoPago.SelectedIndex = 0

    End Sub

    Private Function getDataCompra(ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODDOC,CORRELATIVO, FECHA, DOC_NIT, DOC_NOMCLIE, DOC_DIRCLIE,TOTALPRECIO,DOC_SALDO,DOC_ABONO,OBS FROM DOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@C AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.lbNit.Text = dr(3).ToString
                    Me.LbCliente.Text = dr(4).ToString
                    Me.lbTotalFactura.Text = FormatNumber(dr(6).ToString, 2)
                    Me.LbSaldo.Text = FormatNumber(dr(7).ToString, 2)
                    Me.LbAbonos.Text = FormatNumber(dr(8).ToString, 2)
                    Me.LbFecha.Text = Date.Parse(dr(2))
                End If
                dr.Close()

                r = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try

        End Using

        Return r
    End Function

    Private Sub txtAbono_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAbono.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbTipoPago.select()
        End If
    End Sub

    Private Sub cmbTipoPago_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoPago.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtNoDocPago.select()
        End If
    End Sub

    Private Sub txtNoDocPago_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoDocPago.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtObs.select()
        End If
    End Sub

    Private Sub cmbCoddoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCoddoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtAbono.select()
        End If
    End Sub

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardar.select()
        End If
    End Sub

    Dim objQry As New classQuerys

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Me.txtAbono.Text <> "" Then
        Else
            MsgBox("Cantidad abonada inválida")
            Exit Sub
        End If

        If Me.cmbTipoPago.SelectedIndex >= 0 Then
        Else
            Me.cmbTipoPago.SelectedIndex = 0
        End If

        If Me.txtNoDocPago.Text <> "" Then
        Else
            Me.txtNoDocPago.Text = "SN"
        End If



        If Confirmacion("¿Está seguro que desea registrar este pago?", Me.ParentForm) = True Then

            Dim Saldo As Double = Double.Parse(Me.LbSaldo.Text) - Double.Parse(Me.txtAbono.Text)
            Dim AbonoActual As Double = Double.Parse(Me.LbAbonos.Text) + Double.Parse(Me.txtAbono.Text)


            Dim objCxp As New classCxp
            If objCxp.GuardarNuevoPago(GlobalEmpNit, codcliente, Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbNoRecibo.Text), Double.Parse(Me.txtAbono.Text), Me.txtFechaAbono.DateTime, Me.txtObs.Text, 0, Me.lbNit.Text, Me.LbCliente.Text, Saldo, AbonoActual, coddoc, correlativo, 0, Me.cmbTipoPago.Text, Me.txtNoDocPago.Text) = True Then
                If objCxp.DisminuirSaldoProveedor(GlobalEmpNit, codcliente, Double.Parse(Me.txtAbono.Text)) Then
                Else
                    MsgBox("No se disminuyó el saldo del proveedor por favor haga una rectificación manual")
                End If
                'envia la notificacion
                'Call Form1.EnviarNotificacionesEmail(0, "Ares te informa: Pago a proveedor. Factura No. " & Me.lbFactura.Text, "Se ingresó el recibo de pago No. " & coddoc & " " & correlativo & " extendida al proveedor " & Me.LbCliente.Text & " por un valor de " & FormatCurrency(Me.txtAbono.Text) & " usando el usuario " & GlobalNomUsuario)
                'actualiza el correlativo
                Dim ObjGeneral As New ClassGeneral
                ObjGeneral.fcnActualizarCorrelativo(GlobalEmpNit, Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbNoRecibo.Text))

                'imprime a pantalla el recibo d pago
                Dim ObjReports As New ClassReports
                If ObjReports.rptReciboProveedor(GlobalEmpNit, Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbNoRecibo.Text)) = True Then
                Else
                    MsgBox("Error al cargar comprobante. Error: " + GlobalDesError)
                End If

                Me.btnAceptarTrue.PerformClick()
            Else
                MsgBox("No se logró gurdar el recibo. Error: " & GlobalDesError)
            End If

        End If

    End Sub

End Class
