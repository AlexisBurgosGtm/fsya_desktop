Imports System.Data.SqlClient
Public Class classRepartidores
    Sub New()

    End Sub

    Public Function InsertNuevoRepartidor(ByVal empnit As String,
                                          ByVal nit As String,
                                          ByVal descripcion As String,
                                          ByVal direccion As String,
                                          ByVal telefono As String,
                                          ByVal contacto As String,
                                          ByVal telcontacto As String,
                                          ByVal telwhatsapp As String,
                                          ByVal email As String, ByVal clave As String
                                          ) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("INSERT INTO REPARTIDORES (EMPNIT,NITREP,DESREP,DIRREP,TELREP,CONTACTO,TELCONTACTO,EMAIL,WHATSAPP,CLAVE) VALUES (@EMPNIT,@NITREP,@DESREP,@DIRREP,@TELREP,@CONTACTO,@TELCONTACTO,@EMAIL,@WHATSAPP,@CLAVE)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@NITREP", nit)
                cmd.Parameters.AddWithValue("@DESREP", descripcion)
                cmd.Parameters.AddWithValue("@DIRREP", direccion)
                cmd.Parameters.AddWithValue("@TELREP", telefono)
                cmd.Parameters.AddWithValue("@CONTACTO", contacto)
                cmd.Parameters.AddWithValue("@TELCONTACTO", telcontacto)
                cmd.Parameters.AddWithValue("@EMAIL", email)
                cmd.Parameters.AddWithValue("@WHATSAPP", telwhatsapp)
                cmd.Parameters.AddWithValue("@CLAVE", clave)
                cmd.ExecuteNonQuery()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    Public Function EditRepartidor(ByVal empnit As String,
                                   ByVal codrep As Integer,
                                          ByVal nit As String,
                                          ByVal descripcion As String,
                                          ByVal direccion As String,
                                          ByVal telefono As String,
                                          ByVal contacto As String,
                                          ByVal telcontacto As String,
                                          ByVal telwhatsapp As String,
                                          ByVal email As String,
                                          ByVal clave As String
                                          ) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE REPARTIDORES SET NITREP=@NITREP,DESREP=@DESREP,DIRREP=@DIRREP,TELREP=@TELREP,CONTACTO=@CONTACTO,TELCONTACTO=@TELCONTACTO,EMAIL=@EMAIL,WHATSAPP=@WHATSAPP,CLAVE=@CLAVE WHERE CODREP=@CODREP AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODREP", codrep)
                cmd.Parameters.AddWithValue("@NITREP", nit)
                cmd.Parameters.AddWithValue("@DESREP", descripcion)
                cmd.Parameters.AddWithValue("@DIRREP", direccion)
                cmd.Parameters.AddWithValue("@TELREP", telefono)
                cmd.Parameters.AddWithValue("@CONTACTO", contacto)
                cmd.Parameters.AddWithValue("@TELCONTACTO", telcontacto)
                cmd.Parameters.AddWithValue("@EMAIL", email)
                cmd.Parameters.AddWithValue("@WHATSAPP", telwhatsapp)
                cmd.Parameters.AddWithValue("@CLAVE", clave)
                cmd.ExecuteNonQuery()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    Public Function tblRepartidoresActivos(ByVal empnit As String) As DataTable
        Dim tbl As New DSGeneral.tblRepartidoresDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim sql As String = "SELECT CODREP,NITREP,DESREP,DIRREP,TELREP,CONTACTO,TELCONTACTO,EMAIL,WHATSAPP,ACTIVO,CLAVE FROM REPARTIDORES WHERE EMPNIT=@EMPNIT AND ACTIVO=0"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function



    Public Function tblRepartidores(ByVal empnit As String, ByVal MostrarDeshabilitados As Boolean) As DataTable
        Dim tbl As New DSGeneral.tblRepartidoresDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim sql As String
                If MostrarDeshabilitados = True Then
                    sql = "SELECT CODREP,NITREP,DESREP,DIRREP,TELREP,CONTACTO,TELCONTACTO,EMAIL,WHATSAPP,ACTIVO,CLAVE FROM REPARTIDORES WHERE EMPNIT=@EMPNIT"
                Else
                    sql = "SELECT CODREP,NITREP,DESREP,DIRREP,TELREP,CONTACTO,TELCONTACTO,EMAIL,WHATSAPP,ACTIVO,CLAVE FROM REPARTIDORES WHERE EMPNIT=@EMPNIT AND ACTIVO=0"
                End If


                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function DeshabRepartidor(ByVal empnit As String, ByVal codrep As Integer, ByVal st As Integer) As Boolean
        Dim result As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim habilitado As Integer '0) esta habilitado,1) está deshabilitado
                If st = 0 Then
                    habilitado = 1
                Else
                    habilitado = 0
                End If

                Dim cmd As New SqlCommand("UPDATE REPARTIDORES SET ACTIVO=@ST WHERE CODREP=@CODREP AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODREP", codrep)
                cmd.Parameters.AddWithValue("@ST", habilitado)
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


    Public Function DeleteRepartidor(ByVal empnit As String, ByVal codrep As Integer) As Boolean
        Dim result As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("DELETE FROM REPARTIDORES WHERE CODREP=@CODREP AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODREP", codrep)
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

End Class
