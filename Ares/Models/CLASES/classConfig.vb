
Imports System.Data.SqlClient

Public Class classConfig
    Sub New()

    End Sub

    Public Function setEmmpnitBodegaCentral(ByVal empnitbod As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE CONFIG SET PASS=@E WHERE ID=20", cn)
                cmd.Parameters.AddWithValue("@E", empnitbod)
                cmd.ExecuteNonQuery()

                GlobalBodegaCentralEmpnit = empnitbod

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function

    Public Function setClaveOperador(ByVal nuevaclave As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE CONFIG SET PASS=@E WHERE ID=21", cn)
                cmd.Parameters.AddWithValue("@E", nuevaclave)
                cmd.ExecuteNonQuery()


                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function

    Public Function LiberarUsuarios() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE USUARIOS SET LOGGED=0", cn)
                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using


        Return r
    End Function

    Public Function OcuparUsuario(ByVal usuario As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE USUARIOS SET LOGGED=1 where USUARIO=@U", cn)
                cmd.Parameters.AddWithValue("@U", usuario)
                cmd.ExecuteNonQuery()

                r = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function LiberarUsuario(ByVal usuario As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE USUARIOS SET LOGGED=0 where USUARIO=@U", cn)
                cmd.Parameters.AddWithValue("@U", usuario)
                cmd.ExecuteNonQuery()

                r = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function VerificarUsuarioUso(ByVal usuario As String) As Integer
        Dim r As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT LOGGED FROM USUARIOS  where USUARIO=@U", cn)
                cmd.Parameters.AddWithValue("@U", usuario)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    r = Integer.Parse(dr(0))
                Else
                    r = 1
                End If

                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = 1
            End Try
        End Using

        If usuario = "soporte" Then r = 0

        Return r
    End Function

    Public Function getTipoEmpresa(ByVal empnit As String) As Integer
        Dim r As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODTIPOEMPRESA, 
                                                    EMPEMAIL AS TIPOPRECIO, 
                                                    SISNULL(OBJETIVO_VENTAS,0) AS OBJETIVO_VENTAS
                                        FROM EMPRESAS  where EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    r = Integer.Parse(dr(0))
                    GlobalTipoPrecio = dr(1).ToString
                    GlobalObjetivoSucursal = Double.Parse(dr(2))
                Else
                    r = 1
                    GlobalTipoPrecio = "PUBLICO"
                    GlobalObjetivoSucursal = 0
                End If

                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = 1
            End Try
        End Using


        Return r
    End Function

End Class
