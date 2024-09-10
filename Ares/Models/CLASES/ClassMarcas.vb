Imports System.Data.SqlClient

Public Class ClassMarcas
    Sub New()

    End Sub

    Public Function tblListaMarcas(ByVal Empnit As String) As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODMARCA", GetType(Integer))
            .Add("DESMARCA", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT CODMARCA, DESMARCA FROM MARCAS WHERE (EMPNIT = @empnit)
                                           ORDER BY MARCAS.DESMARCA", cn)
                cmd.Parameters.AddWithValue("@empnit", Empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    Integer.Parse(dr(0)), 'codmarca
                                    dr(1).ToString 'desmarca
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
End Class