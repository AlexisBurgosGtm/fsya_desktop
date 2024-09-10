
Imports System.Data.SqlClient

Public Class classSeries

    Sub New()

    End Sub
    Public Function Select_SerieItemVenta(ByVal item As Integer) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT EMPNIT, CODPROD, NOSERIE FROM TEMP_VENTAS WHERE ID=@ID", cn)
                cmd.Parameters.AddWithValue("@ID", item)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then

                    If Update_SerieStatus(dr(0).ToString, dr(1).ToString, dr(2).ToString, 0) = True Then
                    End If

                End If

                result = True

            Catch ex As Exception
                result = False
            End Try

        End Using

        Return result

    End Function

    ''' <summary>
    ''' Actualiza el status de un número de serie a 0 cuando está habilitado o a 1 cuando ya se vendió
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="codprod"></param>
    ''' <param name="noserie"></param>
    ''' <param name="Status"></param>
    ''' <returns></returns>
    Public Function Update_SerieStatus(ByVal empnit As String, ByVal codprod As String, ByVal noserie As String, ByVal Status As Integer) As Boolean
        Dim result As Boolean


        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE SERIES SET ST=@ST WHERE CODPROD=@CODPROD AND NOSERIE=@NOSERIE", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@NOSERIE", noserie)
                cmd.Parameters.AddWithValue("@ST", Status)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
        End Using

        'cn.Close()

        Return result

    End Function







End Class
