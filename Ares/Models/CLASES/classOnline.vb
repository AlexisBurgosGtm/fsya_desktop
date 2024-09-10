
Imports System.Data.SqlClient

Public Class classOnline

    Sub New(ByVal _token As String)
        tokenc = _token
    End Sub

    Dim tokenc As String

    Public Function getEmpresas() As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPNIT, EMPNOMBRE FROM COMMUNITY_EMPRESAS_SYNC WHERE TOKEN=@T", cnh)
                cmd.Parameters.AddWithValue("@T", tokenc)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function getProductos() As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, COSTO FROM COMMUNITY_PRODUCTOS_SYNC WHERE TOKEN=@T AND EMPNIT='GENERAL' ", cnh)
                cmd.Parameters.AddWithValue("@T", tokenc)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function


    Public Function getPreciosProducto(ByVal codprod As String, ByVal nitsucursal As String) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODMEDIDA, EQUIVALE, COSTO, PRECIO, MAYOREOA, MAYOREOB, MAYOREOC, PESO,PORCUTILIDAD FROM COMMUNITY_PRECIOS_SUCURSALES_SYNC WHERE TOKEN=@T AND EMPNIT=@E AND CODPROD=@C ", cnh)
                cmd.Parameters.AddWithValue("@T", tokenc)
                cmd.Parameters.AddWithValue("@E", nitsucursal)
                cmd.Parameters.AddWithValue("@C", codprod)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

End Class
