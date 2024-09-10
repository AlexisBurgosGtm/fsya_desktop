Imports System.Data.SqlClient
Public Class classVehiculos
    Sub New()

    End Sub

    Public Property CodVehiculo As Integer
    Public Property DesVehiculo As String


    Public Function InsertVehiculoCliente(ByVal empnit As String,
                                  ByVal noplacas As String,
                                  ByVal desvehiculo As String,
                                  ByVal linea As String,
                                  ByVal modelo As Integer,
                                  ByVal color As String,
                                  ByVal codmarca As Integer,
                                  ByVal nochasis As String,
                                   ByVal codcliente As Integer
                                  ) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("INSERT INTO CLIENTES_VEHICULOS (EMPNIT,NOPLACAS,DESVEHICULO,LINEA,MODELO,COLOR,CODMARCA,NOCHASIS,CODCLIENTE) VALUES (@EMPNIT,@NOPLACAS,@DESVEHICULO,@LINEA,@MODELO,@COLOR,@CODMARCA,@NOCHASIS,@CODCLIENTE)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@NOPLACAS", noplacas)
                cmd.Parameters.AddWithValue("@DESVEHICULO", desvehiculo)
                cmd.Parameters.AddWithValue("@LINEA", linea)
                cmd.Parameters.AddWithValue("@MODELO", modelo)
                cmd.Parameters.AddWithValue("@COLOR", color)
                cmd.Parameters.AddWithValue("@CODMARCA", codmarca)
                cmd.Parameters.AddWithValue("@NOCHASIS", nochasis)
                cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                cmd.ExecuteNonQuery()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function UpdateVehiculoCliente(ByVal codvehiculo As Integer,
                                          ByVal empnit As String,
                                  ByVal noplacas As String,
                                  ByVal desvehiculo As String,
                                  ByVal linea As String,
                                  ByVal modelo As Integer,
                                  ByVal color As String,
                                  ByVal codmarca As Integer,
                                  ByVal nochasis As String,
                                   ByVal codcliente As Integer
                                  ) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("UPDATE CLIENTES_VEHICULOS SET NOPLACAS=@NOPLACAS,DESVEHICULO=@DESVEHICULO,LINEA=@LINEA,MODELO=@MODELO,COLOR=@COLOR,CODMARCA=@CODMARCA,NOCHASIS=@NOCHASIS WHERE CODCLIENTE=@CODCLIENTE AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@CODVEHICULO", codvehiculo)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@NOPLACAS", noplacas)
                cmd.Parameters.AddWithValue("@DESVEHICULO", desvehiculo)
                cmd.Parameters.AddWithValue("@LINEA", linea)
                cmd.Parameters.AddWithValue("@MODELO", modelo)
                cmd.Parameters.AddWithValue("@COLOR", color)
                cmd.Parameters.AddWithValue("@CODMARCA", codmarca)
                cmd.Parameters.AddWithValue("@NOCHASIS", nochasis)
                cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                cmd.ExecuteNonQuery()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function SelectVehiculosClientesTodos(ByVal empnit As String) As DataTable

        Dim result As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT CLIENTES_VEHICULOS.CODVEHICULO, CLIENTES_VEHICULOS.NOPLACAS, CLIENTES_VEHICULOS.DESVEHICULO, CLIENTES_VEHICULOS.LINEA, CLIENTES_VEHICULOS.MODELO, 
                                            CLIENTES_VEHICULOS.COLOR, MARCAS.DESMARCA AS MARCA, ISNULL(CLIENTES_VEHICULOS.CODCLIENTE, 0) AS CODCLIENTE, ISNULL(CLIENTES.NOMBRECLIENTE,'SN') AS NOMCLIENTE, CLIENTES_VEHICULOS.CODMARCA
                                            FROM CLIENTES_VEHICULOS LEFT OUTER JOIN MARCAS ON CLIENTES_VEHICULOS.EMPNIT = MARCAS.EMPNIT AND CLIENTES_VEHICULOS.CODMARCA = MARCAS.CODMARCA LEFT OUTER JOIN
                                            CLIENTES ON CLIENTES_VEHICULOS.EMPNIT = CLIENTES.EMPNIT AND CLIENTES_VEHICULOS.CODCLIENTE = CLIENTES.CODCLIENTE
                                            WHERE (CLIENTES_VEHICULOS.EMPNIT = @EMPNIT)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(result)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = Nothing
            End Try

            cn.Close()
        End Using

        Return result

    End Function


    Public Function SelectVehiculosCliente(ByVal empnit As String, ByVal codcliente As Integer) As DataTable

        Dim result As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT CLIENTES_VEHICULOS.CODVEHICULO, CLIENTES_VEHICULOS.NOPLACAS, CLIENTES_VEHICULOS.DESVEHICULO, CLIENTES_VEHICULOS.LINEA, CLIENTES_VEHICULOS.MODELO, 
                                            CLIENTES_VEHICULOS.COLOR, MARCAS.DESMARCA AS MARCA, CLIENTES_VEHICULOS.CODCLIENTE, CLIENTES.NOMBRECLIENTE AS NOMCLIENTE, CLIENTES_VEHICULOS.CODMARCA
                                            FROM CLIENTES_VEHICULOS LEFT OUTER JOIN MARCAS ON CLIENTES_VEHICULOS.EMPNIT = MARCAS.EMPNIT AND CLIENTES_VEHICULOS.CODMARCA = MARCAS.CODMARCA LEFT OUTER JOIN
                                            CLIENTES ON CLIENTES_VEHICULOS.EMPNIT = CLIENTES.EMPNIT AND CLIENTES_VEHICULOS.CODCLIENTE = CLIENTES.CODCLIENTE
                                            WHERE (CLIENTES_VEHICULOS.EMPNIT = @EMPNIT) AND (CLIENTES_VEHICULOS.CODCLIENTE=@CODCLIENTE)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(result)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = Nothing
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function DeleteVehiculoCliente(ByVal empnit As String, ByVal codvehiculo As Integer) As Boolean

        Dim result As Boolean


        If VerificaMovimientos(empnit, codvehiculo) = True Then
            GlobalDesError = "Ya existen movimientos con este auto, por lo tanto, no se puede eliminar"
            Return False

            Exit Function
        End If


        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("DELETE FROM CLIENTES_VEHICULOS WHERE EMPNIT=@EMPNIT AND CODVEHICULO=@CODVEHICULO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODVEHICULO", codvehiculo)
                cmd.ExecuteNonQuery()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Private Function VerificaMovimientos(ByVal empnit As String, ByVal codvehiculo As Integer) As Boolean
        Return False
    End Function

End Class
