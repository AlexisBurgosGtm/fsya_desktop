
Imports System.Data.SqlClient

Public Class classBodegas
    Sub New()

    End Sub

    Public strError As String = ""

    Public Function tblBodegas() As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODBODEGA, DESBODEGA FROM BODEGAS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function

End Class
