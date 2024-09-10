
Imports System.Data.SqlClient

Public Class viewProductosFabricados

    Private Sub viewProductosFabricados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()

    End Sub

    Private Sub CargarGrid()
        Dim tbl As New DSPRODUCTOS.tblProductosFabricadosDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT PRECIOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, PRECIOS.PRECIO
                                        FROM PRODUCTOS RIGHT OUTER JOIN
                                        PRECIOS ON PRODUCTOS.CODPROD = PRECIOS.CODPROD AND PRODUCTOS.EMPNIT = PRECIOS.EMPNIT
                                        WHERE (PRECIOS.EMPNIT = @E) AND (PRODUCTOS.TIPOPROD = 'F')", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using


        Me.gridProductosFabricados.DataSource = tbl

    End Sub

    Dim drw As DataRow

    Private Sub GridViewProductosFabricados_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProductosFabricados.KeyDown
        If e.KeyCode = Keys.Enter Then

            Try
                Call getDataProducto()
                Me.btnAceptarTrue.PerformClick()
            Catch ex As Exception
                MsgBox("No se seleccinó ningún producto")
            End Try

        End If
    End Sub

    Private Sub GridViewProductosFabricados_DoubleClick(sender As Object, e As EventArgs) Handles GridViewProductosFabricados.DoubleClick
        Try
            Call getDataProducto()
            Me.btnAceptarTrue.PerformClick()
        Catch ex As Exception
            MsgBox("No se seleccinó ningún producto")
        End Try
    End Sub

    Private Sub GridViewProductosFabricados_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProductosFabricados.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewProductosFabricados.GetFocusedDataRow
        Catch ex As Exception
            drw = Nothing
        End Try
    End Sub

    Private Sub getDataProducto()

        ProductosCodprod = drw.Item(0).ToString
        ProductosDesProd = drw.Item(1).ToString
        ProductosCodmedida = drw.Item(2).ToString
        ProductosNF = CType(drw.Item(3), Integer)
        ProductosCosto = CType(drw.Item(4), Double)
        ProductosPrecio = CType(drw.Item(5), Double)

    End Sub


End Class
