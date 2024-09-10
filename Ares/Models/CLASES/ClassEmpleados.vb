Imports System.Data.SqlClient

Public Class ClassEmpleados
    Sub New()

    End Sub

    Public Function tblListaEmpleados(ByVal Empnit As String) As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODEMP", GetType(Integer))
            .Add("NOMEMP", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT CODEMPLEADO, NOMEMPLEADO FROM EMPLEADOS WHERE EMPNIT=@empnit AND ACTIVO='SI' AND CODTIPOEMPLEADO=3", cn)
                cmd.Parameters.AddWithValue("@empnit", Empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    Integer.Parse(dr(0)), 'codven
                                    dr(1).ToString'nomven
                                          })
                Loop
                dr.Close()
                cmd.Dispose()
                Return tbl

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
                Return Nothing
            End Try

            cn.Close()
        End Using
    End Function


    Public Function tblTiposEmpleado() As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODTIPOEMPLEADO", GetType(Integer))
            .Add("DESTIPOEMPLEADO", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODTIPOEMPLEADO, DESTIPOEMPLEADO FROM TIPOEMPLEADO", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cn.Close()

            Catch ex As Exception

                GlobalDesError = ex.ToString
                tbl = Nothing

            End Try

        End Using

        Return tbl

    End Function

    Public Function tblListaEmpleadosTodos(ByVal Empnit As String) As DataTable

        Dim tbl As New DsEmpleados.tblListaEmpleadosDataTable

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPLEADOS.CODEMPLEADO, 
                                                EMPLEADOS.CODTIPOEMPLEADO, 
                                                EMPLEADOS.DPI, 
                                                EMPLEADOS.IGSS, 
                                                EMPLEADOS.NOMEMPLEADO, 
                                                EMPLEADOS.DIRECCION, 
                                                EMPLEADOS.CODMUNICIPIO, 
                                                EMPLEADOS.CODDEPTO, 
                                                EMPLEADOS.TELEFONOS, 
                                                EMPLEADOS.WHATSAPP, 
                                                EMPLEADOS.EMAIL, 
                                                EMPLEADOS.OBS, 
                                                EMPLEADOS.ACTIVO, 
                                                TIPOEMPLEADO.DESTIPOEMPLEADO, 
                                                EMPLEADOS.CLAVE
                                            FROM EMPLEADOS LEFT OUTER JOIN TIPOEMPLEADO ON EMPLEADOS.CODTIPOEMPLEADO = TIPOEMPLEADO.CODTIPOEMPLEADO
                                            WHERE (EMPLEADOS.EMPNIT = @EMPNIT)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", Empnit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cn.Close()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function tblListaEmpleadosTipo(ByVal Empnit As String, ByVal CodTipoEmpleado As Integer) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODEMP", GetType(Integer))
            .Add("NOMEMP", GetType(String))
        End With
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT CODEMPLEADO, NOMEMPLEADO FROM EMPLEADOS WHERE EMPNIT=@empnit AND ACTIVO='SI' AND CODTIPOEMPLEADO=@CODTIPO", cn)
                cmd.Parameters.AddWithValue("@empnit", Empnit)
                cmd.Parameters.AddWithValue("@CODTIPO", CodTipoEmpleado)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    Integer.Parse(dr(0)),
                                    dr(1).ToString
                                          })
                Loop
                dr.Close()
                cmd.Dispose()
                Return tbl

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
                Return Nothing
            End Try

            cn.Close()
        End Using
    End Function

    Public Function InsertEmpleado(ByVal empnit As String,
                                   ByVal codtipoempleado As Integer,
                                   ByVal dpi As String,
                                   ByVal igss As String,
                                   ByVal nombre As String,
                                   ByVal direccion As String,
                                   ByVal codmun As Integer,
                                   ByVal coddepto As Integer,
                                   ByVal telefono As String,
                                   ByVal whatsapp As String,
                                   ByVal email As String,
                                   ByVal obs As String,
                                   ByVal clave As String) As Boolean

        Dim result As Boolean


        If VerificarClaveEmpleado(empnit, clave) = True Then

            MsgBox("Clave de Empleado ya existe, por favor, escriba otra")
            Return False
            Exit Function
        End If


        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO EMPLEADOS 
        (EMPNIT,CODTIPOEMPLEADO,DPI,IGSS,NOMEMPLEADO,DIRECCION,CODMUNICIPIO,CODDEPTO,TELEFONOS,WHATSAPP,EMAIL,OBS,ACTIVO,CLAVE) VALUES 
        (@EMPNIT,@CODTIPOEMPLEADO,@DPI,@IGSS,@NOMEMPLEADO,@DIRECCION,@CODMUNICIPIO,@CODDEPTO,@TELEFONOS,@WHATSAPP,@EMAIL,@OBS,'SI',@CLAVE)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODTIPOEMPLEADO", codtipoempleado)
                cmd.Parameters.AddWithValue("@DPI", dpi)
                cmd.Parameters.AddWithValue("@IGSS", igss)
                cmd.Parameters.AddWithValue("@NOMEMPLEADO", nombre)
                cmd.Parameters.AddWithValue("@DIRECCION", direccion)
                cmd.Parameters.AddWithValue("@CODMUNICIPIO", codmun)
                cmd.Parameters.AddWithValue("@CODDEPTO", coddepto)
                cmd.Parameters.AddWithValue("@TELEFONOS", telefono)
                cmd.Parameters.AddWithValue("@WHATSAPP", whatsapp)
                cmd.Parameters.AddWithValue("@EMAIL", email)
                cmd.Parameters.AddWithValue("@OBS", obs)
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


    Public Function EditEmpleado(ByVal codempleado As Integer, ByVal empnit As String,
                                   ByVal codtipoempleado As Integer,
                                   ByVal dpi As String,
                                   ByVal igss As String,
                                   ByVal nombre As String,
                                   ByVal direccion As String,
                                   ByVal codmun As Integer,
                                   ByVal coddepto As Integer,
                                   ByVal telefono As String,
                                   ByVal whatsapp As String,
                                   ByVal email As String,
                                   ByVal obs As String,
                                   ByVal clave As String, ByVal claveactual As String) As Boolean

        Dim result As Boolean

        If claveactual <> clave Then
            If VerificarClaveEmpleado(empnit, clave) = True Then

                MsgBox("Clave de Empleado ya existe, por favor, escriba otra")
                Return False
                Exit Function
            End If
        End If


        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE EMPLEADOS SET CODTIPOEMPLEADO=@CODTIPOEMPLEADO,DPI=@DPI,IGSS=@IGSS,NOMEMPLEADO=@NOMEMPLEADO,DIRECCION=@DIRECCION,CODMUNICIPIO=@CODMUNICIPIO,CODDEPTO=@CODDEPTO,TELEFONOS=@TELEFONOS,WHATSAPP=@WHATSAPP,EMAIL=@EMAIL,OBS=@OBS,CLAVE=@CLAVE WHERE EMPNIT=@EMPNIT AND CODEMPLEADO=@CODEMPLEADO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODEMPLEADO", codempleado)
                cmd.Parameters.AddWithValue("@CODTIPOEMPLEADO", codtipoempleado)
                cmd.Parameters.AddWithValue("@DPI", dpi)
                cmd.Parameters.AddWithValue("@IGSS", igss)
                cmd.Parameters.AddWithValue("@NOMEMPLEADO", nombre)
                cmd.Parameters.AddWithValue("@DIRECCION", direccion)
                cmd.Parameters.AddWithValue("@CODMUNICIPIO", codmun)
                cmd.Parameters.AddWithValue("@CODDEPTO", coddepto)
                cmd.Parameters.AddWithValue("@TELEFONOS", telefono)
                cmd.Parameters.AddWithValue("@WHATSAPP", whatsapp)
                cmd.Parameters.AddWithValue("@EMAIL", email)
                cmd.Parameters.AddWithValue("@OBS", obs)
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


    Public Function EliminarEmpleado(ByVal empnit As String, ByVal codempleado As Integer) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM EMPLEADOS WHERE CODEMPLEADO=@CODEMPLEADO AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODEMPLEADO", codempleado)
                cmd.ExecuteNonQuery()
                result = True
                cn.Close()
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False

            End Try
        End Using

        Return result
    End Function


    Public Function habdesEmpleado(ByVal empnit As String, ByVal codempleado As Integer, ByVal status As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE EMPLEADOS
                                            SET ACTIVO=@ST 
                                            WHERE CODEMPLEADO=@CODEMPLEADO AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODEMPLEADO", codempleado)
                cmd.Parameters.AddWithValue("@ST", status)
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False

            End Try
        End Using

        Return result

    End Function


    Private Function VerificarClaveEmpleado(ByVal empnit As String, ByVal clave As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CLAVE FROM EMPLEADOS WHERE EMPNIT=@EMPNIT AND CLAVE=@CLAVE", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CLAVE", clave)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    result = True
                Else
                    result = False
                End If

                cn.Close()
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False

            End Try
        End Using

        Return result
    End Function


End Class
