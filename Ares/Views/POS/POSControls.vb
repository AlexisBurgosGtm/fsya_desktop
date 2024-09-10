Imports System.Data.SqlClient
Module POSControls

    'carga la tabla con código de vendedor y nombre
    Public Function tblVendedores(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable
        tbl.Columns.Add("CODVEN", GetType(Integer))
        tbl.Columns.Add("NOMVEN", GetType(String))
        tbl.Columns.Add("CLAVE", GetType(String))

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT CODVEN, NOMVEN, CLAVE FROM VENDEDORES WHERE EMPNIT=@EMPNIT", cn)
        cmd.Parameters.AddWithValue("@EMPNIT", empnit)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Do While dr.Read
            Try
                tbl.Rows.Add(New Object() {
                        Integer.Parse(dr(0)),
                        dr(1).ToString,
                        dr(2).ToString
                })
            Catch ex As Exception

            End Try
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        Return tbl

    End Function

    'correlativo de factura
    Public Function CorrelativoPOS(ByVal empnit As String, ByVal Coddoc As String) As Double
        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE CODDOC=@CODDOC AND EMPNIT=@EMPNIT", cn)
        cmd.Parameters.AddWithValue("@EMPNIT", empnit)
        cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                Return Double.Parse(dr(0))
            End If
        Catch ex As Exception
            Return 0
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()

    End Function

    'total de venta
    Public ValTotalVentaPOS As Double, ValTotalCostoPOS As Double
    Public ValTotalItems As Integer

    Public Function CargarTotalVentaPOS(ByVal empnit As String, Coddoc As String, Correlativo As Double) As Boolean
        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT SUM(TOTALPRECIO) AS VENTA, SUM(TOTALCOSTO) AS COSTO, COUNT(CANTIDAD) AS ITEMS FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
        cmd.Parameters.AddWithValue("@EMPNIT", empnit)
        cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
        cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                ValTotalVentaPOS = Double.Parse(dr(0))
                ValTotalCostoPOS = Double.Parse(dr(1))
                ValTotalItems = Integer.Parse(dr(2))
                Return True
            End If
        Catch ex As Exception
            ValTotalCostoPOS = 0
            ValTotalVentaPOS = 0
            ValTotalItems = 0
            Return False
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()
    End Function


    'lista de productos en la venta (temporal)
    Public Function POStblListaProductosVendidos(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double) As DataTable

        Try
            Dim tbl As New VENTASDataSet.tblTempVentaDataTable

            Call AbrirConexionSql()

            'SE SELECCIONA SI CARGARÁ LA VENTA O LA COMPRA
            Dim SQL As String
            SQL = "SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO,TOTALBONIF FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO ORDER BY ID DESC"

            Dim cmd As New SqlCommand(SQL, cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                             Integer.Parse(dr(0)),'id
                             dr(1).ToString,'codprod
                             dr(2).ToString,'desprod
                             dr(3).ToString,'codmedida
                             Integer.Parse(0),'equivale
                             Integer.Parse(dr(4)),'cantidad
                             Integer.Parse(dr(7)),'totalunidades
                             Double.Parse(dr(8)),'costo
                             Double.Parse(dr(5)),'precio
                             Double.Parse(0),'utilidad
                             Double.Parse(dr(9)),'totalcosto
                             Double.Parse(dr(6)),'totalprecio
                             Integer.Parse(0),'bonif
                             Integer.Parse(dr(10))'totalbonif
                                             })
            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

            Return tbl

        Catch ex As Exception

            Return Nothing

        End Try
    End Function


    'obtiene los datos del producto mediante el código

    Public Function POSInsertarProducto(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As String, ByVal codprod As String, ByVal codmedida As String, ByVal cantidad As Integer, ByVal AnioProceso As Integer, ByVal MesProceso As Integer) As Boolean
        Call AbrirConexionSql()

        Dim desp As String, equiv As Integer, cost As Double, pre As Double


        Dim cmd0 As New SqlCommand("SELECT PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, PRECIOS.PRECIO
                                    FROM PRODUCTOS LEFT OUTER JOIN PRECIOS ON PRODUCTOS.ID = PRECIOS.ID
                                    WHERE (PRECIOS.CODMEDIDA = @CODMEDIDA) AND (PRODUCTOS.CODPROD = @CODPROD) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.EMPNIT = @EMPNIT)", cn)
        cmd0.Parameters.AddWithValue("@EMPNIT", empnit)
        cmd0.Parameters.AddWithValue("@CODPROD", codprod)
        cmd0.Parameters.AddWithValue("@CODMEDIDA", codmedida)
        Dim dr0 As SqlDataReader = cmd0.ExecuteReader
        dr0.Read()
        Try
            ' If dr0.HasRows Then
            desp = dr0(1).ToString
                equiv = Integer.Parse(dr0(3))
                cost = Double.Parse(dr0(4))
                pre = Double.Parse(dr0(5))
                GoTo Procede
            ' End If
        Catch ex As Exception
            MsgBox("Producto no existe o está deshabilitado")
            Return False
            Exit Function
        End Try

        dr0.Close()
        cmd0.Dispose()

Procede:

        Try
            'obtiene el inventario
            Call ObtenerDatosInventario(codprod, AnioProceso, MesProceso)

            'luego hace una salida de inventario
            Call SalidaInventario(codprod, AnioProceso, MesProceso, (cantidad * VentasEquivale))

            Call AbrirConexionSql()

            'inserta los valores en la tabla inicial
            Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO) VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO)", CN)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            cmd.Parameters.AddWithValue("@PRECIO", pre)
            cmd.Parameters.AddWithValue("@COSTO", cost)
            cmd.Parameters.AddWithValue("@TOTALPRECIO", pre * cantidad)
            cmd.Parameters.AddWithValue("@TOTALCOSTO", cost * cantidad)
            cmd.Parameters.AddWithValue("@BONIF", 0)
            cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
            cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            cmd.Parameters.AddWithValue("@DESPROD", desp)
            cmd.Parameters.AddWithValue("@CODMEDIDA", codmedida)
            cmd.Parameters.AddWithValue("@EQUIVALE", equiv)
            cmd.Parameters.AddWithValue("@CANTIDAD", cantidad)
            cmd.Parameters.AddWithValue("@TOTALUNIDADES", cantidad * equiv)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            cn.Close()

            'If (cantidad * equiv) > INVSaldo Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & codprod & " " & desp & ", existen " & INVSaldo.ToString & " y se solicitan " & (cantidad * equiv).ToString & " mediante el usuario " & GlobalNomUsuario)

            Return True

        Catch ex As Exception
            MsgBox("No se pudo agregar el producto. Error: " & Err.ToString, MsgBoxStyle.Critical, "Error")
            Return False
            Exit Function
        End Try

    End Function

End Module
