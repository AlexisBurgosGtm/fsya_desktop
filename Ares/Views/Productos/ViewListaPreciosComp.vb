Imports DevExpress.XtraBars.Docking2010.Customization
Imports System.Data.SqlClient
Imports DevExpress
Imports DevExpress.XtraBars.Docking2010

Public Class ViewListaPreciosComp
    Private Sub ViewListaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarListadoPrecios()

    End Sub

    Private Sub btnListaPreciosExportarExcel_Click(sender As Object, e As EventArgs) Handles btnListaPreciosExportarExcel.Click
        Try
            Dim archivo As String = Application.StartupPath + "\EXPORTS\" + "precios.xlsx"
            Me.GridListaPrecios.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox("No se pudo exportar. Error: " + ex.ToString)
        End Try
    End Sub

    Private Sub CargarListadoPrecios()

        Try

            Dim tbl As New DS_VENTAS2.tblPreciosCDataTable

            Call AbrirConexionSql()

            Dim cmd As New SqlCommand("SELECT           PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, PRECIOS.PRECIO, MARCAS.DESMARCA AS MARCA, ISNULL(T.PROVEEDORES, '---') AS PROVEEDOR, 
                                                        ISNULL(CLASIFICACIONUNO.DESCLAUNO, '---') AS DESCLAUNO, INVSALDO.SALDO
                                       FROM             CLASIFICACIONUNO RIGHT OUTER JOIN
                                                        PRODUCTOS ON CLASIFICACIONUNO.CODCLAUNO = PRODUCTOS.CODCLAUNO AND CLASIFICACIONUNO.EMPNIT = PRODUCTOS.EMPNIT LEFT OUTER JOIN
                                                        MARCAS ON PRODUCTOS.CODMARCA = MARCAS.CODMARCA AND PRODUCTOS.EMPNIT = MARCAS.EMPNIT LEFT OUTER JOIN
                                                        (SELECT             DOCUMENTOS.DOC_NOMCLIE AS PROVEEDORES, DOCPRODUCTOS.CODPROD
                                                         FROM               DOCPRODUCTOS LEFT OUTER JOIN
                                                                            DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                                                                            DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                                                                            TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                                         WHERE              (TIPODOCUMENTOS.TIPODOC = 'COM')
                                                         GROUP BY           DOCUMENTOS.DOC_NOMCLIE, DOCPRODUCTOS.CODPROD) AS T ON PRODUCTOS.CODPROD = T.CODPROD LEFT OUTER JOIN
                                                        PRECIOS ON PRODUCTOS.CODPROD = PRECIOS.CODPROD AND PRODUCTOS.EMPNIT = PRECIOS.EMPNIT LEFT OUTER JOIN
                                                        INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                                       WHERE            (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI')
                                       ORDER BY         PRODUCTOS.DESPROD, PRECIOS.EQUIVALE", cn)
            'cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            Dim conteoerrores As Integer = 0

            Do While dr.Read
                Try
                    tbl.Rows.Add(New Object() {
                            dr(0).ToString,'CODPROD -
                            dr(1).ToString,'DESPROD - 
                            dr(2).ToString,'CODMEDIDA -
                            Integer.Parse(dr(3).ToString),'EQUIVALE -
                            FormatNumber(Double.Parse(dr(4).ToString), 2),'COSTO -
                            FormatNumber(Double.Parse(dr(5).ToString), 2),'PRECIO -
                            dr(6).ToString,'MARCA - 
                            dr(7).ToString,'PROVEEDOR -
                            dr(8).ToString,'DESCLAUNO -
                            Integer.Parse(dr(9).ToString) 'SALDO -
                      })
                Catch ex As Exception
                    'MsgBox("Error en el código de producto: " & dr(0).ToString & " " & dr(2).ToString & " " & ex.ToString)
                    conteoerrores = conteoerrores + 1
                End Try
            Loop

            dr.Close()
            cn.Close()

            Me.GridListaPrecios.DataSource = tbl

            Call Form1.Mensaje("Errores encontrados " & conteoerrores.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

End Class
