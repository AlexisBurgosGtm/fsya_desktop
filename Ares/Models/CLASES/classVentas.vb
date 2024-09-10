Imports System.Data.SqlClient

Public Class classVentas
    Sub New(ByVal _empnit As String, ByVal _coddoc As String, ByVal _correlativo As Double)

        empnit = _empnit
        coddoc = _coddoc
        correlativo = _correlativo

    End Sub

    Public StCosto, StVenta As String

    Dim empnit, coddoc As String
    Dim correlativo As Double




    Public Function VaciarDocumentoTemp() As Boolean
        Dim result As Boolean
        Dim objInv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cm As New SqlCommand("SELECT ID, CODPROD, TOTALUNIDADES FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND USUARIO=@USUARIO", cn)
                cm.Parameters.AddWithValue("@EMPNIT", empnit)
                cm.Parameters.AddWithValue("@CODDOC", coddoc)
                cm.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                Dim dr As SqlDataReader = cm.ExecuteReader
                Do While dr.Read
                    'RUTINA PARA REGRESAR EL INVENTARIO AL PRODUCTO
                    objInv.fcn_RegresarSalidaProducto(dr(1).ToString, Double.Parse(dr(2)))

                    'ELIMINACIÓN DEL ID
                    Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE ID=@ID", cn)
                    cmd.Parameters.AddWithValue("@ID", CType(dr(0), Integer))
                    cmd.ExecuteNonQuery()
                Loop

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()

        End Using

        Return result

    End Function


    Public Function fcn_totalventa() As Boolean

        Call AbrirConexionSql()

        'variables para almacenar los totales
        'Dim stCosto, stVenta As String

        StCosto = "0.00"
        StVenta = "0.00"

        Try
            Dim SQL As String

            SQL = "SELECT SUM(TOTALPRECIO) AS TOTAL, SUM(TOTALCOSTO) AS COSTOT FROM TEMP_VENTAS WHERE EMPNIT='" & empnit & "' AND CODDOC='" & coddoc & "' AND CORRELATIVO=" & correlativo

            Dim cmd As New SqlCommand(SQL, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()

            If dr.HasRows Then
                stCosto = FormatNumber(dr(1), 2).ToString
                stVenta = FormatNumber(dr(0), 2).ToString
            End If

            dr.Close()
            cmd.Dispose()

            cn.Close()

            Return True

        Catch ex As Exception
            Try
                cn.Close()
            Catch exs As Exception

            End Try

            StCosto = "0.00"
            stVenta = "0.00"

        End Try

    End Function



End Class
