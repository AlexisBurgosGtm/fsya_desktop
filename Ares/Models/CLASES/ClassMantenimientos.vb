
Imports System.Data.SqlClient
Public Class ClassMantenimientos
    Sub New(ByVal _empnit As String)

        empnit = _empnit
    End Sub

    Dim empnit As String


    Public Function tblMarcas() As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODIGO", GetType(Integer))
            .Add("DESCRIPCION", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT CODMARCA AS CODIGO, DESMARCA AS DESCRIPCION FROM MARCAS WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try


            cn.Close()
        End Using

        Return tbl
    End Function


End Class
