Imports System.Data.SqlClient

Public Class ClassBitacora

    Sub New(ByVal Anio_ As Integer, ByVal mes_ As Integer)

        anio = Anio_
        mes = mes_
    End Sub
    Dim anio, mes As Integer

    Public Function tblBitacoraMes() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("TITULO", GetType(String))
            .Add("DESCRIPCION", GetType(String))
            .Add("USUARIO", GetType(String))
            .Add("DIA", GetType(Integer))
            .Add("HORA", GetType(Integer))
            .Add("MINUTO", GetType(Integer))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT TITULO,DESCRIPCION,USUARIO, DIA,HORA,MINUTO FROM NOTIFICACIONES WHERE MES=@MES AND ANIO=@ANIO AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@MES", mes)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                        dr(0),
                       dr(1),
                        dr(2),
                        dr(3),
                        dr(4),
                        dr(5)
                                        })
                Loop
                dr.Close()
                cmd.Dispose()

                cn.Close()

                Return tbl

            Catch ex As Exception
                GlobalDesError = ex.ToString
                Return Nothing
            End Try
        End Using

    End Function


End Class
