Imports System.Data.SqlClient

Public Class ClassProveedores
    Sub New()

    End Sub

    Public Function tblListaProveedores(ByVal Empnit As String) As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODPROV", GetType(Integer))
            .Add("EMPRESA", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT CODPROV, EMPRESA, EMPNIT FROM PROVEEDORES WHERE (EMPNIT = @empnit) AND (NOT (EMPRESA LIKE 'NULL'))", cn)
                cmd.Parameters.AddWithValue("@empnit", Empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    Integer.Parse(dr(0)), 'codprov
                                    dr(1).ToString'empresa
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