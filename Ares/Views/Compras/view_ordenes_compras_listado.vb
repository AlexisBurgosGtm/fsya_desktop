Imports System.Data.SqlClient

Public Class view_ordenes_compras_listado
    Private Sub view_ordenes_compras_listado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CargarGrid()

    End Sub


    Private Sub CargarGrid()


        Dim tbl As New DSGeneral.tblOrdenesCompraDataTable

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS PROVEEDOR, DOCUMENTOS.TOTALPRECIO AS IMPORTE, 
                         DOCUMENTOS.OBS, TIPODOCUMENTOS.TIPODOC
FROM            DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
WHERE        (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CORTE = 'NO') AND (TIPODOCUMENTOS.TIPODOC = 'OCM');", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            End Using
        Catch ex As Exception
            tbl = Nothing
        End Try


        Me.gridOrdenes.DataSource = tbl

    End Sub

    Dim drw As DataRow
    Private Sub GridViewProductos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProductos.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewProductos.GetFocusedDataRow

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewProductos_DoubleClick(sender As Object, e As EventArgs) Handles GridViewProductos.DoubleClick
        Try
            If Confirmacion("¿Está seguro que desea cargar esta orden de compra?", Me.ParentForm) = True Then
                Call CargarOrdenCompra(drw.Item(1).ToString, CType(drw.Item(2), Double))
                'Me.btnAceptarTrue.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GridViewProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Confirmacion("¿Está seguro que desea cargar esta orden de compra?", Me.ParentForm) = True Then
                    Call CargarOrdenCompra(drw.Item(1).ToString, CType(drw.Item(2), Double))
                    'Me.btnAceptarTrue.PerformClick()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub CargarOrdenCompra(ByVal coddoc As String, ByVal correlativo As Double)


        'MsgBox(coddoc + " " + correlativo.ToString)

        Try

            Using cn As New SqlConnection(strSqlConectionString)
                Try
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmdDel As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE CODDOC=@CODDOC_COMP AND CORRELATIVO=@CORRELATIVO_COMP AND EMPNIT=@E", cn)
                    cmdDel.Parameters.AddWithValue("@E", GlobalEmpNit)
                    cmdDel.Parameters.AddWithValue("@CODDOC_COMP", GlobalCoddocCOMPRA)
                    cmdDel.Parameters.AddWithValue("@CORRELATIVO_COMP", VentasCorrelativo)
                    cmdDel.ExecuteNonQuery()

                    'LEE LA ORDEN DE COMPRA ITEM POR ITEM.. LA INSERTA EN TEMP_VENTAS PARA LA COMPRA Y EN EL TRASLADO DE UNA
                    Dim cmd As New SqlCommand("
                    INSERT INTO Temp_Ventas (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,NOSERIE,OBS)
                    SELECT EMPNIT,@CODDOC_COMP AS CODDOC,@CORRELATIVO_COMP AS CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,TOTALBONIF AS BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,NOSERIE,OBS
                        FROM DOCPRODUCTOS WHERE EMPNIT=@E AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)




                    cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)

                    cmd.Parameters.AddWithValue("@CODDOC_COMP", GlobalCoddocCOMPRA)
                    cmd.Parameters.AddWithValue("@CORRELATIVO_COMP", VentasCorrelativo)


                    cmd.ExecuteNonQuery()
                    cmd.Dispose()



                    MsgBox("Documento cargado exitosamente!!")
                    Me.btnAceptarTrue.PerformClick()

                Catch ex As Exception
                    MsgBox("Error: " + ex.ToString)
                    GlobalDesError = ex.ToString

                End Try

            End Using


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


End Class
