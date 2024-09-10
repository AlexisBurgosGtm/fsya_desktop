Imports System.Data.SqlClient

Public Class UserControlEmergentes

    Dim fecha As Date = New DateTime(Today.Year, Today.Month, Today.Day)
    Dim codprod As String = VentasCodProducto
    Dim desprod As String = VentasDesProducto
    Dim med As String = VentasCodMedida

    Private Sub UserControlEmergentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Me.lbMedida.Enabled = False
        Me.lbDesProd.Visible = False
        Me.cmbTipoEmergente.Text = "NO SURTIDO"
        Me.lbCantidad.Text = 1

        Call fcnReadMedida()

        Me.lbNombreProd.Text = "¿Deseas enviar el producto " + VentasDesProducto + " a la tabla no surtidos?"

        Me.lbCantidad.select()

    End Sub

    Private Sub lbNombreProd_KeyDown(sender As Object, e As KeyEventArgs) Handles lbNombreProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.lbCantidad.select()
        End If
    End Sub

    Private Sub lbCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles lbCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.lbMedida.Enabled = True Then
                Me.lbMedida.select()
            Else
                Me.lbOBS.select()
            End If
        End If
    End Sub

    Private Sub lbOBS_KeyDown(sender As Object, e As KeyEventArgs) Handles lbOBS.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAceptar.select()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Call fcnInsertEmergente()

    End Sub

    Private Sub fcnInsertEmergente()

        Dim TIPO As String

        Select Case Me.cmbTipoEmergente.Text
            Case "NO SURTIDO"
                TIPO = "NO SURTIDO"
            Case "EXTRAORDINARIO"
                TIPO = "EXTRAORDINARIO"
            Case "NUEVO"
                TIPO = "NUEVO"
            Case "PEX"
                TIPO = "PEX"
        End Select

        If Me.cmbTipoEmergente.Text = "NUEVO" Then

            VentasExistencia = 0
            VentasCodProducto = "SN"
            VentasDesProducto = Me.lbDesProd.Text

        End If


        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        If Me.lbOBS.Text <> "" Then

            If fcnReadNSLocal() = False Then
                If objS.fcnReadNS(GlobalEmpNit, VentasDesProducto) = False Then
                    If objS.fcnInsertNS(GlobalEmpNit, GlobalNomEmpresa, VentasCodProducto, VentasDesProducto, VentasCodMedida, VentasExistencia, Integer.Parse(Me.lbCantidad.Text), Me.lbOBS.Text, TIPO) = True Then
                        MsgBox("Emergente subido exitosamente.")
                        Me.btnCancelar.PerformClick()
                    End If
                Else
                    MsgBox("Este producto ya fue cargado a la tabla no surtidos..")
                End If
            Else
                MsgBox("Este producto ira en el reporte de relleno.")
            End If

        Else
            MsgBox("Por favor coloque una observación.")

        End If

    End Sub

    Public Function fcnReadMedida() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           CODMEDIDA
                                           FROM             PRECIOS
                                           WHERE            (EMPNIT = @EMPNIT) AND (CODPROD = @CODPROD) AND (EQUIVALE = 1)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                Me.lbMedida.Text = dr(0).ToString

                If dr.HasRows Then
                    result = True
                Else
                    result = False
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                MsgBox(ex.ToString + " EN READ MEDIDA")
                result = False
            End Try

        End Using

        Return result

    End Function

    Public Function fcnReadNSLocal() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           DOCPRODUCTOS.CODPROD
                                           FROM             DOCPRODUCTOS INNER JOIN
                                                            DOCUMENTOS ON DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                                                            TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC')) AND (DOCUMENTOS.FECHA = @F1) AND (DOCPRODUCTOS.EMPNIT = @EMPNIT) AND (DOCPRODUCTOS.CODPROD = @CODPROD)
                                           GROUP BY         DOCPRODUCTOS.CODPROD", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@F1", Today.Date)
                cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    result = True
                Else
                    result = False
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                MsgBox(ex.ToString + " EN READ LOCAL")
                result = False
            End Try

        End Using

        Return result

    End Function

    Private Sub cmbTipoEmergente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoEmergente.SelectedIndexChanged

        If Me.cmbTipoEmergente.Text = "NUEVO" Then
            Me.lbNombreProd.Text = "Producto:"
            Me.lbDesProd.Visible = True
            Me.lbMedida.Enabled = True
        Else
            Me.lbNombreProd.Text = "¿Deseas enviar el producto " + VentasDesProducto + " a la tabla no surtidos?"
            Me.lbDesProd.Visible = False
            Me.lbMedida.Enabled = False
        End If


    End Sub
End Class
