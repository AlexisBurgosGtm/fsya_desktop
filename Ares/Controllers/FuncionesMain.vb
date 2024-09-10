Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Tile

Module FuncionesMain

    '---------------------------------------------
    ' FUNCION PARA EXPORTAR A EXCEL UN DATAGRID
    '---------------------------------------------

    Public Sub fcn_exportDgvToExcel(ByVal DataGridView1 As DataGridView, ByVal filePath As String)

        Dim sheetIndex As Integer
        Dim Ex As Object
        Dim Wb As Object
        Dim Ws As Object
        Ex = CreateObject("Excel.Application")
        Wb = Ex.workbooks.add

        ' Copy each DataTable as a new Sheet

        'On Error Resume Next
        Dim col, row As Integer
        ' Copy the DataTable to an object array
        Dim rawData(DataGridView1.Rows.Count, DataGridView1.Columns.Count - 1) As Object

        ' Copy the column names to the first row of the object array

        For col = 0 To DataGridView1.Columns.Count - 1
            rawData(0, col) = DataGridView1.Columns(col).HeaderText.ToUpper

        Next

        For col = 0 To DataGridView1.Columns.Count - 1
            For row = 0 To DataGridView1.Rows.Count - 1
                rawData(row + 1, col) = DataGridView1.Rows(row).Cells(col).Value

            Next
        Next
        ' Calculate the final column letter
        Dim finalColLetter As String = String.Empty
        finalColLetter = ExcelColName(DataGridView1.Columns.Count) 'Generate Excel Column Name (Column ID)


        sheetIndex += 1
        Ws = Wb.Worksheets(sheetIndex)
        'Ws.name = "Test10"
        Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, DataGridView1.Rows.Count + 1)

        Ws.Range(excelRange, Type.Missing).Value2 = rawData
        Ws = Nothing


        Wb.SaveAs(filePath, Type.Missing, Type.Missing,
     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
     Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
        Wb.Close(True, Type.Missing, Type.Missing)
        Wb = Nothing
        ' Release the Application object
        Ex.Quit()
        Ex = Nothing
        ' Collect the unreferenced objects
        GC.Collect()
        'MsgBox("Exported Successfully.", MsgBoxStyle.Information)

    End Sub

    Public Function ExcelColName(ByVal Col As Integer) As String
        If Col < 0 And Col > 256 Then
            'MsgBox("Invalid Argument", MsgBoxStyle.Critical)
            Return Nothing
            Exit Function
        End If
        Dim i As Int16
        Dim r As Int16
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S
    End Function

    '---------------------------------------------
    ' FIN - FUNCION PARA EXPORTAR A EXCEL UN DATAGRID
    '---------------------------------------------


    Public Function DatosProducto(ByVal CodProducto As String) As Boolean 'OBTIENE LOS DATOS DEL CÓDIGO DE PRODUCTO SELECCIONADO

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim tipoprecio As String
            Select Case Form1.lbVentasTipoPrecio.Text
                Case "PUBLICO"
                    tipoprecio = "PRECIOS.PRECIO"
                Case "MAYOREO A"
                    tipoprecio = "PRECIOS.MAYOREOA"
                Case "MAYOREO B"
                    tipoprecio = "PRECIOS.MAYOREOB"
                Case "MAYOREO C"
                    tipoprecio = "PRECIOS.MAYOREOC"
                Case Else
                    tipoprecio = "PRECIOS.PRECIO"
            End Select


            Dim cmd As New SqlCommand("SELECT 
                                PRECIOS.CODPROD, 
                                PRODUCTOS.DESPROD, 
                                PRECIOS.CODMEDIDA, 
                                PRECIOS.EQUIVALE, 
                                PRECIOS.COSTO, 
                                " & tipoprecio & ", 
                                INVSALDO.SALDO,
                                PRODUCTOS.EXENTO,
                                PRODUCTOS.NF
                                    FROM PRECIOS LEFT OUTER JOIN PRODUCTOS ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT LEFT OUTER JOIN
                                    INVSALDO ON PRECIOS.CODPROD = INVSALDO.CODPROD AND PRECIOS.EMPNIT = INVSALDO.EMPNIT
                                    WHERE (PRECIOS.EMPNIT = @EMPNIT) AND (PRECIOS.CODPROD = @CODPROD OR PRODUCTOS.CODPROD2=@CODPROD) AND (PRODUCTOS.HABILITADO = 'SI')", cn)

            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@CODPROD", CodProducto)
            cmd.Parameters.AddWithValue("@ANIO", Integer.Parse(Form1.cmdAnioProceso.Text))
            cmd.Parameters.AddWithValue("@MES", Integer.Parse(Form1.cmdMesProceso.SelectedValue))
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows = True Then
                    Try
                        Select Case SelectedForm
                            Case "VENTAS"
                                VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                            Case "ENVIOS"
                                VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                            Case "COTIZACIONES"
                                VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                        End Select
                        VentasCodProducto = dr(0).ToString
                        VentasDesProducto = dr(1).ToString
                        VentasCodMedida = dr(2).ToString
                        VentasEquivale = Integer.Parse(dr(3).ToString)
                        VentasCostoProducto = Double.Parse(dr(4).ToString)
                        VentasPrecioProducto = Double.Parse(dr(5).ToString)
                        VentasExistencia = Double.Parse(dr(6).ToString)
                        VentasExento = Integer.Parse(dr(7).ToString)
                        GlobalSelectedColor = Integer.Parse(dr(8).ToString)

                        If VentasExento = 1 Then
                            VentasIvaProducto = 0
                        Else
                            VentasIvaProducto = GlobalConfigIVA
                        End If

                    Catch ex As Exception
                    End Try

                    result = True

                End If

            Catch ex As Exception

                result = False
            End Try

            dr.Close()
            cmd.Dispose()
            cn.Close()
        End Using

        Return result

    End Function

    Public Function DatosProducto_backup(ByVal CodProducto As String) As Boolean 'OBTIENE LOS DATOS DEL CÓDIGO DE PRODUCTO SELECCIONADO

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("ObtenerDetalleProducto", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@CODPROD", CodProducto)
            cmd.Parameters.AddWithValue("@ANIO", Integer.Parse(Form1.cmdAnioProceso.Text))
            cmd.Parameters.AddWithValue("@MES", Integer.Parse(Form1.cmdMesProceso.SelectedValue))
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows = True Then
                    Try
                        Select Case SelectedForm
                            Case "VENTAS"
                                VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                            Case "ENVIOS"
                                VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                            Case "COTIZACIONES"
                                VentasCorrelativo = Double.Parse(Form1.txtVentasCorrelativo.Text)
                        End Select
                        VentasAnio = Integer.Parse(Form1.cmdAnioProceso.Text)
                        VentasMes = Integer.Parse(Form1.cmdMesProceso.SelectedValue)
                        VentasCodProducto = dr(0).ToString
                        VentasDesProducto = dr(1).ToString
                        VentasCodMedida = dr(2).ToString
                        VentasEquivale = Integer.Parse(dr(3).ToString)
                        VentasCostoProducto = Double.Parse(dr(4).ToString)
                        VentasPrecioProducto = Double.Parse(dr(5).ToString)
                        VentasExistencia = Double.Parse(dr(6).ToString)
                    Catch ex As Exception
                    End Try

                    result = True

                End If

            Catch ex As Exception

                result = False
            End Try

            dr.Close()
            cmd.Dispose()
            cn.Close()
        End Using

        Return result

    End Function

    Public Sub CargarGridTempVentas()


        Dim tbl As New DataTable()
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("CODPROD", GetType(String))
        tbl.Columns.Add("DESPROD", GetType(String))
        tbl.Columns.Add("CODMEDIDA", GetType(String))
        tbl.Columns.Add("CANTIDAD", GetType(Double))
        tbl.Columns.Add("PRECIO", GetType(Double))
        tbl.Columns.Add("StPRECIO", GetType(String))
        tbl.Columns.Add("TOTALPRECIO", GetType(Double))
        tbl.Columns.Add("StTOTALPRECIO", GetType(String))
        tbl.Columns.Add("TOTALUNIDADES", GetType(Double))
        tbl.Columns.Add("StCOSTO", GetType(String))
        tbl.Columns.Add("StTOTALCOSTO", GetType(String))
        tbl.Columns.Add("TOTALUNIDADESBONIF", GetType(Double))
        tbl.Columns.Add("ValTotalCosto", GetType(Double))
        tbl.Columns.Add("ValTotalPrecio", GetType(Double))
        tbl.Columns.Add("TOTALDESCUENTO", GetType(Double))
        tbl.Columns.Add("stPAGAR", GetType(String))

        Dim varTotalCosto As Double = 0
        Dim varTotalPrecio As Double = 0
        Dim varTotalExento As Double = 0
        Dim varTotalIva As Double = 0
        Dim varTotalDescuento As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try



                'SE SELECCIONA SI CARGARÁ LA VENTA O LA COMPRA
                Dim SQL As String

                Select Case SelectedForm
                    Case "VENTAS"

                        If GlobalSelectedTipoDocumento = "FEF" Then
                            SQL = "SELECT TEMP_VENTAS.ID, TEMP_VENTAS.CODPROD, 
                                        TEMP_VENTAS.DESPROD, TEMP_VENTAS.CODMEDIDA, 
                                        TEMP_VENTAS.CANTIDAD, TEMP_VENTAS.PRECIO, 
                                        TEMP_VENTAS.TOTALPRECIO, TEMP_VENTAS.TOTALUNIDADES, 
                                        TEMP_VENTAS.COSTO, TEMP_VENTAS.TOTALCOSTO, 
                                        TEMP_VENTAS.TOTALBONIF, 
                                        ISNULL(TEMP_VENTAS.EXENTO,0) AS EXENTO,
                                        isnull(TEMP_VENTAS.PRECIOSINIVA,0) AS PRECIOSINIVA, ISNULL(TEMP_VENTAS.DESCUENTO,0) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT 
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "') AND (TIPODOCUMENTOS.TIPODOC = 'FEF' )
                            ORDER BY TEMP_VENTAS.ID DESC"
                        End If
                        If GlobalSelectedTipoDocumento = "FEC" Then
                            SQL = "SELECT TEMP_VENTAS.ID, TEMP_VENTAS.CODPROD, TEMP_VENTAS.DESPROD, TEMP_VENTAS.CODMEDIDA, TEMP_VENTAS.CANTIDAD, TEMP_VENTAS.PRECIO, TEMP_VENTAS.TOTALPRECIO, TEMP_VENTAS.TOTALUNIDADES, TEMP_VENTAS.COSTO, TEMP_VENTAS.TOTALCOSTO, TEMP_VENTAS.TOTALBONIF,ISNULL(TEMP_VENTAS.EXENTO,0) AS EXENTO,
                                        isnull(TEMP_VENTAS.PRECIOSINIVA,0) AS PRECIOSINIVA,ISNULL(TEMP_VENTAS.DESCUENTO,0) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT 
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "') AND (TIPODOCUMENTOS.TIPODOC = 'FEC' )
                            ORDER BY TEMP_VENTAS.ID DESC"
                        End If
                        If GlobalSelectedTipoDocumento = "FES" Then
                            SQL = "SELECT TEMP_VENTAS.ID, TEMP_VENTAS.CODPROD, TEMP_VENTAS.DESPROD, TEMP_VENTAS.CODMEDIDA, TEMP_VENTAS.CANTIDAD, TEMP_VENTAS.PRECIO, TEMP_VENTAS.TOTALPRECIO, TEMP_VENTAS.TOTALUNIDADES, TEMP_VENTAS.COSTO, TEMP_VENTAS.TOTALCOSTO, TEMP_VENTAS.TOTALBONIF,
                                        ISNULL(TEMP_VENTAS.EXENTO,0) AS EXENTO,
                                        isnull(TEMP_VENTAS.PRECIOSINIVA,0) AS PRECIOSINIVA, ISNULL(TEMP_VENTAS.DESCUENTO,0) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT 
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "') AND (TIPODOCUMENTOS.TIPODOC = 'FES' )
                            ORDER BY TEMP_VENTAS.ID DESC"
                        End If
                        If GlobalSelectedTipoDocumento = "FAC" Then
                            SQL = "SELECT TEMP_VENTAS.ID, TEMP_VENTAS.CODPROD, TEMP_VENTAS.DESPROD, TEMP_VENTAS.CODMEDIDA, TEMP_VENTAS.CANTIDAD, TEMP_VENTAS.PRECIO, TEMP_VENTAS.TOTALPRECIO, TEMP_VENTAS.TOTALUNIDADES, TEMP_VENTAS.COSTO, TEMP_VENTAS.TOTALCOSTO, TEMP_VENTAS.TOTALBONIF,
                                        ISNULL(TEMP_VENTAS.EXENTO,0) AS EXENTO,
                                        isnull(TEMP_VENTAS.PRECIOSINIVA,0) AS PRECIOSINIVA, ISNULL(TEMP_VENTAS.DESCUENTO,0) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT 
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "') AND (TIPODOCUMENTOS.TIPODOC = 'FAC' )
                            ORDER BY TEMP_VENTAS.ID DESC"
                        End If


                    Case "ENVIOS"
                        SQL = "SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO,TOTALBONIF, ISNULL(EXENTO,0) AS EXENTO, ISNULL(PRECIOSINIVA,0) AS PRECIOSINIVA, ISNULL(DESCUENTO,0) AS DESCUENTO FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocENVIOS & "' AND CORRELATIVO=" & Form1.txtVentasCorrelativo.Text & " ORDER BY ID DESC"
                    Case "COTIZACIONES"
                        SQL = "SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO,TOTALBONIF, ISNULL(EXENTO,0) AS EXENTO, ISNULL(PRECIOSINIVA,0) AS PRECIOSINIVA, ISNULL(DESCUENTO,0) AS DESCUENTO FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocCOTIZ & "' AND CORRELATIVO=" & Form1.txtVentasCorrelativo.Text & " ORDER BY ID DESC"
                    Case "LISTADOS"
                        SQL = "SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO,TOTALBONIF, ISNULL(EXENTO,0) AS EXENTO, ISNULL(PRECIOSINIVA,0) AS PRECIOSINIVA, ISNULL(DESCUENTO,0) AS DESCUENTO FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddoc & "' AND CORRELATIVO=" & Form1.txtVentasCorrelativo.Text & " ORDER BY ID DESC"
                End Select

                Dim cmd As New SqlCommand(SQL, cn)

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                             Integer.Parse(dr(0).ToString), 'ID
                             dr(1).ToString, 'CODPROD
                             dr(2).ToString, 'DESPROD
                             dr(3).ToString, 'CODMEDIDA
                             Double.Parse(dr(4).ToString), 'CANTIDAD
                             Double.Parse(dr(5).ToString), 'PRECIO
                             FormatCurrency(dr(5)).ToString,
                             Double.Parse(dr(6).ToString),'TOTALPRECIO
                             FormatCurrency(dr(6)).ToString,
                             Double.Parse(dr(7).ToString), 'TOTAL UNIDADES
                             FormatCurrency(dr(8)).ToString, 'COSTO
                             FormatCurrency(dr(9)).ToString, 'TOTALCOSTO
                             Double.Parse(dr(10).ToString), 'TOTALBONIF
                             Double.Parse(dr(8)), 'COSTO
                            Double.Parse(dr(9)), 'TOTALCOSTO
                            Double.Parse(dr(13)),   'DESCUENTO
                            FormatCurrency(Double.Parse(dr(6)) - Double.Parse(dr(13))) 'TOTAL A PAGAR
                             })
                    varTotalPrecio = varTotalPrecio + Double.Parse(dr(6))
                    varTotalCosto = varTotalCosto + Double.Parse(dr(9))
                    varTotalExento = varTotalExento + Double.Parse(dr(11))
                    varTotalIva = varTotalIva + Double.Parse(dr(12))
                    varTotalDescuento = varTotalDescuento + +Double.Parse(dr(13))
                Loop


                dr.Close()
                cmd.Dispose()
                'cn.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using

        Select Case SelectedForm
            Case "VENTAS"
                Form1.GridVentasTempProductos.DataSource = tbl

                TryCast(Form1.TileViewTempProductos.TileTemplate(0), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(1), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("DESPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(6), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODMEDIDA")
                TryCast(Form1.TileViewTempProductos.TileTemplate(3), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CANTIDAD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(7), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StPRECIO")
                TryCast(Form1.TileViewTempProductos.TileTemplate(2), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StTOTALPRECIO")

                TryCast(Form1.TileViewTempProductos.TileTemplate(9), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("TOTALDESCUENTO")
                TryCast(Form1.TileViewTempProductos.TileTemplate(11), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("stPAGAR")


                Form1.LbTotalVenta.Text = varTotalPrecio
                Form1.LbTotalCosto.Text = varTotalCosto
                Form1.lbVentasTotalExento.Text = varTotalExento
                Form1.lbVentasTotalIva.Text = varTotalIva
                Form1.lbVentasTotalDescuento.Text = varTotalDescuento
                Form1.lbVentasTotalPagar.Text = varTotalPrecio - varTotalDescuento

            Case "ENVIOS"
                Form1.GridVentasTempProductos.DataSource = tbl

                TryCast(Form1.TileViewTempProductos.TileTemplate(0), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(1), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("DESPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(6), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODMEDIDA")
                TryCast(Form1.TileViewTempProductos.TileTemplate(3), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CANTIDAD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(7), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StPRECIO")
                TryCast(Form1.TileViewTempProductos.TileTemplate(2), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StTOTALPRECIO")


            Case "COTIZACIONES"
                Form1.GridVentasTempProductos.DataSource = tbl

                TryCast(Form1.TileViewTempProductos.TileTemplate(0), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(1), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("DESPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(6), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODMEDIDA")
                TryCast(Form1.TileViewTempProductos.TileTemplate(3), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CANTIDAD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(7), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StPRECIO")
                TryCast(Form1.TileViewTempProductos.TileTemplate(2), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StTOTALPRECIO")


            Case "LISTADOS"
                Form1.GridVentasTempProductos.DataSource = tbl

                TryCast(Form1.TileViewTempProductos.TileTemplate(0), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(1), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("DESPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(6), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODMEDIDA")
                TryCast(Form1.TileViewTempProductos.TileTemplate(3), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CANTIDAD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(7), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StPRECIO")
                TryCast(Form1.TileViewTempProductos.TileTemplate(2), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StTOTALPRECIO")

        End Select

    End Sub

    Public Sub CargarGridTempVentas_movinv()


        Dim tbl As New DataTable()
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("CODPROD", GetType(String))
        tbl.Columns.Add("DESPROD", GetType(String))
        tbl.Columns.Add("CODMEDIDA", GetType(String))
        tbl.Columns.Add("CANTIDAD", GetType(Double))
        tbl.Columns.Add("PRECIO", GetType(Double))
        tbl.Columns.Add("StPRECIO", GetType(String))
        tbl.Columns.Add("TOTALPRECIO", GetType(Double))
        tbl.Columns.Add("StTOTALPRECIO", GetType(String))
        tbl.Columns.Add("TOTALUNIDADES", GetType(Double))
        tbl.Columns.Add("StCOSTO", GetType(String))
        tbl.Columns.Add("StTOTALCOSTO", GetType(String))
        tbl.Columns.Add("TOTALUNIDADESBONIF", GetType(Double))
        tbl.Columns.Add("ValTotalCosto", GetType(Double))
        tbl.Columns.Add("ValTotalPrecio", GetType(Double))
        tbl.Columns.Add("TOTALDESCUENTO", GetType(Double))
        tbl.Columns.Add("stPAGAR", GetType(String))

        Dim varTotalCosto As Double = 0
        Dim varTotalPrecio As Double = 0
        Dim varTotalExento As Double = 0
        Dim varTotalIva As Double = 0
        Dim varTotalDescuento As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            'SE SELECCIONA SI CARGARÁ LA VENTA O LA COMPRA
            Dim SQL As String

            Select Case SelectedForm

                Case "LISTADOS"
                    SQL = "SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO,TOTALBONIF, ISNULL(EXENTO,0) AS EXENTO, ISNULL(PRECIOSINIVA,0) AS PRECIOSINIVA, ISNULL(DESCUENTO,0) AS DESCUENTO FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddoc & "' AND CORRELATIVO=" & Form1.txtVentasCorrelativo.Text & " ORDER BY ID DESC"
            End Select

            Dim cmd As New SqlCommand(SQL, cn)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                             Integer.Parse(dr(0).ToString), 'ID
                             dr(1).ToString, 'CODPROD
                             dr(2).ToString, 'DESPROD
                             dr(3).ToString, 'CODMEDIDA
                             Double.Parse(dr(4).ToString), 'CANTIDAD
                             Double.Parse(dr(5).ToString), 'PRECIO
                             FormatCurrency(dr(5)).ToString,
                             Double.Parse(dr(6).ToString),'TOTALPRECIO
                             FormatCurrency(dr(6)).ToString,
                             Double.Parse(dr(7).ToString), 'TOTAL UNIDADES
                             FormatCurrency(dr(8)).ToString, 'COSTO
                             FormatCurrency(dr(9)).ToString, 'TOTALCOSTO
                             Double.Parse(dr(10).ToString), 'TOTALBONIF
                             Double.Parse(dr(8)), 'COSTO
                            Double.Parse(dr(9)), 'TOTALCOSTO
                            Double.Parse(dr(13)),   'DESCUENTO
                            FormatCurrency(Double.Parse(dr(6)) - Double.Parse(dr(13))) 'TOTAL A PAGAR
                             })
                varTotalPrecio = varTotalPrecio + Double.Parse(dr(6))
                varTotalCosto = varTotalCosto + Double.Parse(dr(9))
                varTotalExento = varTotalExento + Double.Parse(dr(11))
                varTotalIva = varTotalIva + Double.Parse(dr(12))
                varTotalDescuento = varTotalDescuento + +Double.Parse(dr(13))
            Loop
            dr.Close()
            cmd.Dispose()
            'cn.Close()
        End Using

        Select Case SelectedForm

            Case "LISTADOS"
                Form1.GridVentasTempProductos.DataSource = tbl

                TryCast(Form1.TileViewTempProductos.TileTemplate(0), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(1), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("DESPROD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(6), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CODMEDIDA")
                TryCast(Form1.TileViewTempProductos.TileTemplate(3), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("CANTIDAD")
                TryCast(Form1.TileViewTempProductos.TileTemplate(7), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StPRECIO")
                TryCast(Form1.TileViewTempProductos.TileTemplate(2), TileViewItemElement).Column = Form1.TileViewTempProductos.Columns("StTOTALPRECIO")

        End Select

    End Sub

    Public Sub ActualizarCorrelativo()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Dim SQL As String
            Select Case SelectedForm
                Case "VENTAS"
                    SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=" & (Double.Parse(Form1.txtVentasCorrelativo.Text) + 1) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddoc & "'"

                Case "ENVIOS"
                    SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=" & (Double.Parse(Form1.txtVentasCorrelativo.Text) + 1) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocENVIOS & "'"
                Case "COTIZACIONES"
                    SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=" & (Double.Parse(Form1.txtVentasCorrelativo.Text) + 1) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocCOTIZ & "'"

            End Select

            Dim cmd As New SqlCommand(SQL, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        End Using

        'cn.Close()
    End Sub

    Dim objConection As New classConection(cn)

    Public Sub CargarCorrelativoVentas()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim SQL As String
            Select Case SelectedForm
                Case "VENTAS"
                    SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddoc & "'"
                Case "ENVIOS"
                    SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocENVIOS & "'"
                Case "COTIZACIONES"
                    SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocCOTIZ & "'"
                Case "COMPRAS"
                    SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocCOMPRA & "'"
                Case "ORDENCOMPRA"
                    SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocORDENCOMPRA & "'"
                Case "CORTECAJA"
                    SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='CAJA'"



            End Select
            Dim cmd As New SqlCommand(SQL, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()

            Try
                If dr.HasRows Then
                    Select Case SelectedForm
                        Case "VENTAS"
                            Form1.txtVentasCorrelativo.Text = dr(0).ToString
                        Case "ENVIOS"
                            Form1.txtVentasCorrelativo.Text = dr(0).ToString
                        Case "COTIZACIONES"
                            Form1.txtVentasCorrelativo.Text = dr(0).ToString

                    End Select
                End If
            Catch ex As Exception
                Select Case SelectedForm
                    Case "VENTAS"
                        Form1.txtVentasCorrelativo.Text = 0
                    Case "ENVIOS"
                        Form1.txtVentasCorrelativo.Text = 0
                    Case "COTIZACIONES"
                        Form1.txtVentasCorrelativo.Text = 0

                End Select
            End Try
            dr.Close()
            cmd.Dispose()
        End Using
        'cn.Close()

    End Sub


    Public Sub CargarTotalVenta(ByVal CODDOC As String, ByVal CORRELATIVO As Double)



        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            'variables para almacenar los totales
            Dim stCosto, stVenta, stIVA, stDescuento As String
            stCosto = "0.00"
            stVenta = "0.00"
            stIVA = "0.00"
            stDescuento = "0.00"
            Dim stExento As Double = 0

            Try

                Dim SQL As String
                If SelectedForm = "VENTAS" Then

                    If GlobalSelectedTipoDocumento = "FEF" Then

                        SQL = "SELECT SUM(TEMP_VENTAS.TOTALPRECIO) AS TOTAL, SUM(TEMP_VENTAS.TOTALCOSTO) AS COSTOT, SUM(isnull(TEMP_VENTAS.EXENTO,0)) AS TOTALEXENTO, SUM(isnull(TEMP_VENTAS.PRECIOSINIVA,0)) AS PRECIOSINIVA, SUM(ISNULL(TEMP_VENTAS.DESCUENTO,0)) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "')
                            GROUP BY TIPODOCUMENTOS.TIPODOC
                            HAVING (TIPODOCUMENTOS.TIPODOC = 'FEF')"
                    End If

                    If GlobalSelectedTipoDocumento = "FEC" Then

                        SQL = "SELECT SUM(TEMP_VENTAS.TOTALPRECIO) AS TOTAL, SUM(TEMP_VENTAS.TOTALCOSTO) AS COSTOT, SUM(isnull(TEMP_VENTAS.EXENTO,0)) AS TOTALEXENTO, SUM(isnull(TEMP_VENTAS.PRECIOSINIVA,0)) AS PRECIOSINIVA, SUM(ISNULL(TEMP_VENTAS.DESCUENTO,0)) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "')
                            GROUP BY TIPODOCUMENTOS.TIPODOC
                            HAVING (TIPODOCUMENTOS.TIPODOC = 'FEC')"
                    End If

                    If GlobalSelectedTipoDocumento = "FES" Then

                        SQL = "SELECT SUM(TEMP_VENTAS.TOTALPRECIO) AS TOTAL, SUM(TEMP_VENTAS.TOTALCOSTO) AS COSTOT, SUM(isnull(TEMP_VENTAS.EXENTO,0)) AS TOTALEXENTO, SUM(isnull(TEMP_VENTAS.PRECIOSINIVA,0)) AS PRECIOSINIVA, SUM(ISNULL(TEMP_VENTAS.DESCUENTO,0)) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "')
                            GROUP BY TIPODOCUMENTOS.TIPODOC
                            HAVING (TIPODOCUMENTOS.TIPODOC = 'FES')"
                    End If

                    If GlobalSelectedTipoDocumento = "FAC" Then
                        SQL = "SELECT SUM(TEMP_VENTAS.TOTALPRECIO) AS TOTAL, SUM(TEMP_VENTAS.TOTALCOSTO) AS COSTOT, SUM(isnull(TEMP_VENTAS.EXENTO,0)) AS TOTALEXENTO, SUM(isnull(TEMP_VENTAS.PRECIOSINIVA,0)) AS PRECIOSINIVA, SUM(ISNULL(TEMP_VENTAS.DESCUENTO,0)) AS DESCUENTO
                            FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC AND TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                            WHERE (TEMP_VENTAS.EMPNIT = '" & GlobalEmpNit & "') AND (TEMP_VENTAS.USUARIO = '" & GlobalNomUsuario & "')
                            GROUP BY TIPODOCUMENTOS.TIPODOC
                            HAVING (TIPODOCUMENTOS.TIPODOC = 'fac')"
                    End If


                Else
                    SQL = "SELECT SUM(TOTALPRECIO) AS TOTAL, SUM(TOTALCOSTO) AS COSTOT, SUM(ISNULL(EXENTO,0)) AS TOTALEXENTO, SUM(ISNULL(PRECIOSINIVA,0)) AS PRECIOSINIVA
                        FROM TEMP_VENTAS 
                        WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & CODDOC & "' AND CORRELATIVO=" & CORRELATIVO
                End If

                Dim cmd As New SqlCommand(SQL, cn)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                dr.Read()
                Try
                    If dr.HasRows Then
                        stCosto = FormatNumber(dr(1), 2).ToString
                        stVenta = FormatNumber(dr(0), 2).ToString
                        stExento = Double.Parse(dr(2))
                        stIVA = FormatNumber(dr(3), 2).ToString
                        stDescuento = FormatNumber(dr(4), 2)
                    End If
                Catch ex As Exception

                    stCosto = "0.00"
                    stVenta = "0.00"
                    stIVA = "0.00"
                    stExento = 0
                    stDescuento = "0.00"
                End Try


                dr.Close()
                cmd.Dispose()


            Catch ex As Exception
                MsgBox(ex.ToString)
                Call Form1.Mensaje("No se pudo cargar el total del documento")

            End Try

            'cn.Close()

            Select Case SelectedForm
                Case "VENTAS"
                    'Form1.LbTotalVenta.Text = stVenta
                    'Form1.LbTotalCosto.Text = stCosto
                    'Form1.lbVentasTotalExento.Text = stExento
                    'Form1.lbVentasTotalIva.Text = stIVA

                Case "LISTADOS"
                    'Form1.LbTotalVenta.Text = stVenta
                    'Form1.LbTotalCosto.Text = stCosto
                    'Form1.lbVentasTotalExento.Text = stExento
                    'Form1.lbVentasTotalIva.Text = stIVA

                Case "ENVIOS"
                    Form1.LbTotalVenta.Text = stVenta
                    Form1.LbTotalCosto.Text = stCosto
                    Form1.lbVentasTotalExento.Text = stExento
                    Form1.lbVentasTotalIva.Text = stIVA
                    Form1.lbVentasTotalDescuento.Text = stDescuento
                Case "COTIZACIONES"
                    Form1.LbTotalVenta.Text = stVenta
                    Form1.LbTotalCosto.Text = stCosto
                    Form1.lbVentasTotalExento.Text = stExento
                    Form1.lbVentasTotalIva.Text = stIVA
                    Form1.lbVentasTotalDescuento.Text = stDescuento


            End Select

            'bloquea o desbloquea la fecha del documento según sea el caso
            If Double.Parse(Form1.LbTotalVenta.Text) > 0 Then
                Form1.txtVentasFecha.Enabled = False
                Form1.cmbVentasCoddoc.Enabled = False
            Else
                Form1.txtVentasFecha.Enabled = True
                Form1.cmbVentasCoddoc.Enabled = True
            End If

        End Using
    End Sub

    Public Hablar As New Speech.Synthesis.SpeechSynthesizer

End Module
