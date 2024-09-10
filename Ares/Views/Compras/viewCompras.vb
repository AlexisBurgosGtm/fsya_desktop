Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class viewCompras

    Dim strcoddoc As String = ""

#Region "LOAD"


    Private Sub viewCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If SelectedForm = "ORDEN_COMPRA" Then
            Me.lbTituloCompras.Text = "ORDEN COMPRA"
            Me.btnComprasTomarDatos.Visible = False
            strcoddoc = GlobalCoddocORDENCOMPRA
        Else
            Me.lbTituloCompras.Text = "COMPRAS"
            Me.btnComprasTomarDatos.Visible = True
            strcoddoc = GlobalCoddocCOMPRA
        End If

        Call CargarCoddoc()
        Call CargarCorrelativoCompras()
        GlobalCorrelComp = Me.txtComprasCorrelativo.Text
        Call CargarComboConCre()

        Me.txtComprasFecha.DateTime = Today.Date
        Me.txtComprasFechaVence.DateTime = Today.Date

        'VENDEDORES EN COMPRAS
        Dim ObjEmpleados As New ClassEmpleados
        Dim tblVend As New DataTable
        tblVend = ObjEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 3)
        Try
            With Me.cmbComprasVendedor
                .DataSource = tblVend
                .DisplayMember = "NOMEMP"
                .ValueMember = "CODEMP"
            End With
        Catch ex As Exception
        End Try

        Call CargarDGVListaProductosCompras(1)
        TimerColor.Start()

        Me.lbTotalCompra.Text = "0.00"
        Call CargarGridTempComp()


        Call CargarTotalCompra(strcoddoc, Double.Parse(Me.txtComprasCorrelativo.Text))


        If SelectedForm = "ORDEN_COMPRA" Then
        Else
            MsgBox(GlobalCoddocTrasSalSucursal)
        End If

    End Sub

    Private Sub CargarCorrelativoCompras()

        Dim coddoc As String = ""
        If SelectedForm = "COMPRAS" Then
            coddoc = GlobalCoddocCOMPRA
        Else
            coddoc = GlobalCoddocORDENCOMPRA
        End If

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Dim cmd As New SqlCommand("SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & strcoddoc & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    Me.txtComprasCorrelativo.Text = dr(0).ToString
                Else
                    Me.txtComprasCorrelativo.Text = 0
                End If
            Catch ex As Exception
            End Try
            dr.Close()
            cmd.Dispose()
        End Using
    End Sub

#End Region

#Region "CMBS CONT/CRE"

    Private Sub CargarComboConCre()
        Dim tb As New DataTable
        With tb.Columns
            .Add("COD", GetType(String))
            .Add("DES", GetType(String))
        End With
        With tb.Rows
            .Add(New Object() {"CON", "CONTADO"})
            .Add(New Object() {"CRE", "CREDITO"})
        End With
        With Me.cmbComprasConCre
            .DataSource = tb
            .ValueMember = "COD"
            .DisplayMember = "DES"
        End With
    End Sub

    Private Sub cmbComprasConCre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprasConCre.SelectedIndexChanged
        Try
            If Me.cmbComprasConCre.SelectedValue.ToString = "CRE" Then
                Me.txtComprasFechaVence.DateTime = Me.txtComprasFecha.DateTime.AddDays(Integer.Parse(Me.cmbComprasDiasCredito.Text))
                Me.txtComprasFechaVence.Enabled = True
            Else
                Me.txtComprasFechaVence.DateTime = Me.txtComprasFecha.DateTime
                Me.txtComprasFechaVence.Enabled = False
                Me.cmbComprasDiasCredito.Text = "0"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbComprasDiasCredito_TextChanged(sender As Object, e As EventArgs) Handles cmbComprasDiasCredito.TextChanged
        If Me.cmbComprasDiasCredito.Text <> "" Then
            Try
                Me.txtComprasFechaVence.DateTime = Me.txtComprasFecha.DateTime.AddDays(Integer.Parse(Me.cmbComprasDiasCredito.Text))
            Catch ex As Exception
            End Try
        End If
    End Sub

#End Region

#Region "TIMER COLOR"

    Private Sub DGV_ListadoProductosCompras_Sorted(ByVal sender As Object,
    ByVal e As System.EventArgs) Handles DGV_ListadoProductosCompras.Sorted

        TimerColor.Start()

    End Sub

    Private Sub TimerColor_Tick(sender As Object, e As EventArgs) Handles TimerColor.Tick
        For Each Row As DataGridViewRow In Me.DGV_ListadoProductosCompras.Rows

            If CType(Row.Cells(5).Value, Double) = 0 Then
                Row.DefaultCellStyle.BackColor = Color.LightSalmon
            End If

            If CType(Row.Cells(5).Value, Double) < 0 Then
                Row.DefaultCellStyle.BackColor = Color.LightSkyBlue
            End If

        Next

        TimerColor.Stop()

    End Sub

#End Region

#Region "FOCUSES CHANGES"

    Private Sub txtComprasSerieFac_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasSerieFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtComprasNoFac.select()
        End If
    End Sub

    Private Sub txtComprasNoFac_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasNoFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtComprasObs.select()
        End If
    End Sub

    Private Sub txtComprasObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdComprasGuardar.select()
        End If
    End Sub

#End Region

#Region "PROVEEDORES"

    Private Sub cmdComprasBuscarProveedor_Click(sender As Object, e As EventArgs) Handles cmdComprasBuscarProveedor.Click

        If FlyoutDialog.Show(Form1, New viewProveedores) = DialogResult.OK Then

            Me.cmbComprasProveedor.Text = globalProv
            Me.txtComprasNitProveedor.Text = globalNitProv
            Me.txtComprasNombreProveedor.Text = globalDesProv

        End If

    End Sub

    Private Sub txtComprasNitProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasNitProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtComprasNitProveedor.Text <> "" Then
                Call ObtenerProveedorCompra(Me.txtComprasNitProveedor.Text)
                Me.txtComprasSerieFac.select()
            Else
                Me.txtComprasSerieFac.select()
            End If

        End If
    End Sub

    Private Sub ObtenerProveedorCompra(ByVal NitProveedor As String)

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT CODPROV,EMPRESA FROM PROVEEDORES WHERE EMPNIT=@EMPNIT AND NIT=@NIT", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@NIT", NitProveedor)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    Me.txtComprasNombreProveedor.Text = dr(1).ToString
                    Me.cmbComprasProveedor.Text = dr(0).ToString
                End If
            Catch ex As Exception

            End Try
            dr.Close()
            cmd.Dispose()
            cn.Close()

        End Using

    End Sub

#End Region

#Region "GRID COMPRAS"

    Dim objProducto As New ClassProductos

    Private Sub txtComprasCodProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasCodProducto.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtComprasCodProducto.Text <> "" Then
                If objProducto.ProductoHabilitado(GlobalEmpNit, Me.txtComprasCodProducto.Text) = False Then
                    MsgBox("Producto deshabilitado")
                    Exit Sub
                End If
                If DatosProducto(Me.txtComprasCodProducto.Text) = True Then

                    Dim control As New UserControl_CantidadCompras(Form1.SwitchConfigModoPOS.IsOn)

                    If FlyoutDialog.Show(Form1, control) = DialogResult.OK Then
                        Call CargarGridTempComp()

                        Call CargarTotalCompra(strcoddoc, Double.Parse(Me.txtComprasCorrelativo.Text))
                        Me.txtComprasFiltro.Text = ""
                        Me.txtComprasCodProducto.select()
                    End If
                Else
                    MsgBox("Código de producto no existe o se encuentra deshabilitado")
                End If
            Else
                Me.txtComprasFiltro.select()
            End If
        End If
    End Sub

    Private Sub txtComprasFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarDGVListaProductosCompras(2)
            Me.DGV_ListadoProductosCompras.select()
            Call CargarGridTempComp()
            TimerColor.Start()
        End If
    End Sub

    Public Sub CargarDGVListaProductosCompras(ByVal NoFiltro As Integer)

        Dim strerrores As String = ""
        Dim tbl As New DS_VENTAS2.tblGridComprasDataTable

        Dim sql As String = ""

        Select Case NoFiltro
            Case 1
                sql = "SELECT           PRODUCTOS.CODPROD, 
                                        PRODUCTOS.CODPROD2, 
                                        PRODUCTOS.DESPROD, 
                                        PRODUCTOS.DESPROD2, 
                                        PRODUCTOS.DESPROD3, 
                                        PRECIOS.CODMEDIDA, 
                                        PRECIOS.EQUIVALE, 
                                        PRECIOS.COSTO, 
                                        PRECIOS.PRECIO, 
                                        PRODUCTOS.CODMARCA, 
                                        MARCAS.DESMARCA, 
                                        INVSALDO.SALDO
                       FROM             PRECIOS RIGHT OUTER JOIN
                                        INVSALDO RIGHT OUTER JOIN
                                        MARCAS RIGHT OUTER JOIN
                                        PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD ON 
                                        PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                       WHERE            (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI')
                       ORDER BY         PRODUCTOS.DESPROD"
            Case 2
                sql = "SELECT           PRODUCTOS.CODPROD, 
                                        PRODUCTOS.CODPROD2, 
                                        PRODUCTOS.DESPROD, 
                                        PRODUCTOS.DESPROD2, 
                                        PRODUCTOS.DESPROD3, 
                                        PRECIOS.CODMEDIDA, 
                                        PRECIOS.EQUIVALE, 
                                        PRECIOS.COSTO, 
                                        PRECIOS.PRECIO, 
                                        PRODUCTOS.CODMARCA, 
                                        MARCAS.DESMARCA, 
                                        ISNULL((INVSALDO.SALDO / PRECIOS.EQUIVALE), 0) AS SALDO
                       FROM             PRECIOS RIGHT OUTER JOIN
                                        INVSALDO RIGHT OUTER JOIN
                                        MARCAS RIGHT OUTER JOIN
                                        PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD ON 
                                        PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                       WHERE            (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.DESPROD LIKE @FILTRO)
                       ORDER BY         PRODUCTOS.DESPROD"
        End Select

        Try

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", GlobalAnioProceso)
                cmd.Parameters.AddWithValue("@MES", GlobalMesProceso)
                cmd.Parameters.AddWithValue("@FILTRO", "%" & Me.txtComprasFiltro.Text & "%")

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    Try
                        tbl.Rows.Add(New Object() {
                             dr(0).ToString,                'CODPROD
                             dr(1).ToString,                'CODPROD2
                             dr(2).ToString,                'DESPROD
                             dr(3).ToString,                'DESPROD2
                             dr(4).ToString,                'DESPROD3
                             dr(5).ToString,                'CODMEDIDA
                             dr(6),                         'EQUIVALE
                             FormatNumber(Double.Parse(dr(7).ToString), 2),     'COSTO
                             FormatNumber(Double.Parse(dr(8).ToString), 2),     'PRECIO
                             dr(9),                         'CODMARCA
                             dr(10).ToString,               'DESMARCA 
                             dr(11)                         'SALDO
                             })
                    Catch ex As Exception
                        strerrores = strerrores & " // " & "El producto: " & dr(0).ToString & " " & Strings.UCase(dr(2).ToString) & " no ha sido guardado correctamente"
                    End Try
                Loop

                dr.Close()

                Me.DGV_ListadoProductosCompras.DataSource = tbl

            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try

    End Sub

    Private Sub DGV_ListadoProductosCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_ListadoProductosCompras.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                VentasCorrelativo = Double.Parse(Me.txtComprasCorrelativo.Text)
                VentasCodProducto = Me.DGV_ListadoProductosCompras.Item(0, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DGV_ListadoProductosCompras.Item(2, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
                VentasCodMedida = Me.DGV_ListadoProductosCompras.Item(6, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
                VentasEquivale = Integer.Parse(Me.DGV_ListadoProductosCompras.Item(7, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasCostoProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(8, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasPrecioProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(9, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasExistencia = Double.Parse(Me.DGV_ListadoProductosCompras.Item(5, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasAnio = 0
                VentasMes = 0

                'ABRE EL FLYOUTDIALOG CON EL USER CONTROL PARA LA CANTIDAD SELECCIONADA
                Dim control As New UserControl_CantidadCompras(Form1.SwitchConfigModoPOS.IsOn)
                If FlyoutDialog.Show(Form1, control) = DialogResult.OK Then
                    Call CargarGridTempComp()

                    Call CargarTotalCompra(strcoddoc, Double.Parse(Me.txtComprasCorrelativo.Text))

                    Me.txtComprasFiltro.Text = ""
                    Me.txtComprasCodProducto.select()

                    Call CargarDGVListaProductosCompras(1)

                    TimerColor.Start()

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

        If e.KeyCode = Keys.Add Then
            Dim busqueda As String
            busqueda = Me.DGV_ListadoProductosCompras.Item(1, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            busqueda = Strings.Replace(busqueda, " ", "+", 1, -1, CompareMethod.Text)
            Process.Start("https://www.google.com.gt/search?q=" & busqueda & "&tbm=isch&tbo=u&source=univ&sa=X&ved=0ahUKEwif8t3umsbVAhVI4yYKHXTIA3MQ7AkIMg&biw=1024&bih=652#imgrc=_")
        End If

        If e.KeyCode = Keys.I Then
            VentasCodProducto = Me.DGV_ListadoProductosCompras.Item(0, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            FlyoutDialog.Show(Form1, New viewInventarioOnline(GlobalEmpNit, VentasCodProducto))
        End If
        Call CargarGridTempComp()
    End Sub

    Private Sub DGV_ListadoProductosCompras_DoubleClick(sender As Object, e As EventArgs) Handles DGV_ListadoProductosCompras.DoubleClick
        Try
            VentasCorrelativo = Double.Parse(Me.txtComprasCorrelativo.Text)
            VentasCodProducto = Me.DGV_ListadoProductosCompras.Item(0, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            VentasDesProducto = Me.DGV_ListadoProductosCompras.Item(2, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            VentasCodMedida = Me.DGV_ListadoProductosCompras.Item(6, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            VentasEquivale = Integer.Parse(Me.DGV_ListadoProductosCompras.Item(7, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasCostoProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(8, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasPrecioProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(9, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasExistencia = Double.Parse(Me.DGV_ListadoProductosCompras.Item(5, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasAnio = 0
            VentasMes = 0

            'ABRE EL FLYOUTDIALOG CON EL USER CONTROL PARA LA CANTIDAD SELECCIONADA
            Dim control As New UserControl_CantidadCompras(Form1.SwitchConfigModoPOS.IsOn)
            If FlyoutDialog.Show(Form1, control) = DialogResult.OK Then
                Call CargarGridTempComp()

                Call CargarTotalCompra(strcoddoc, Double.Parse(Me.txtComprasCorrelativo.Text))

                Me.txtComprasFiltro.Text = ""
                Me.txtComprasCodProducto.select()

                Call CargarDGVListaProductosCompras(1)

                TimerColor.Start()

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Call CargarGridTempComp()
    End Sub

#End Region

#Region "GRID TEMP PRODUCTOS"

    Public Sub CargarGridTempComp()

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
            Try

                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String = "SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO,TOTALBONIF, ISNULL(EXENTO,0) AS EXENTO, ISNULL(PRECIOSINIVA,0) AS PRECIOSINIVA,ISNULL(DESCUENTO,0) AS DESCUENTO FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & strcoddoc & "' ORDER BY ID DESC"

                Dim cmd As New SqlCommand(sql, cn)

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

            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try

        End Using

        Me.GridTempProductosCompras.DataSource = tbl

        TryCast(Me.TileViewTempProductosCompras.TileTemplate(0), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("CODPROD")
        TryCast(Me.TileViewTempProductosCompras.TileTemplate(1), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("DESPROD")
        TryCast(Me.TileViewTempProductosCompras.TileTemplate(6), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("CODMEDIDA")
        TryCast(Me.TileViewTempProductosCompras.TileTemplate(3), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("CANTIDAD")
        TryCast(Me.TileViewTempProductosCompras.TileTemplate(7), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("StCOSTO")
        TryCast(Me.TileViewTempProductosCompras.TileTemplate(2), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("StTOTALCOSTO")


        Me.lbTotalCompra.Text = varTotalCosto  'FormatNumber(dr(1), 2).ToString
        ComprasTotalCosto = varTotalCosto 'Double.Parse(dr(1))
        ComprasTotalPrecio = varTotalPrecio 'Double.Parse(dr(0))


    End Sub
    Dim totalunidades, totalunidadesbonif As Double

    Private Sub TileViewTempProductosCompras_DoubleClick(sender As Object, e As EventArgs) Handles TileViewTempProductosCompras.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewTempProductosCompras.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            SelectedCode = Integer.Parse(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "ID").ToString)
            SelectedCordprod = Double.Parse(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString)
            If Confirmacion("¿Está seguro que desea eliminar este item de la lista?", Form1) = True Then
                Call ObtenerDatosInventario(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString, 0, 0)

                totalunidades = Double.Parse(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "TOTALUNIDADES").ToString)
                totalunidadesbonif = Double.Parse(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "TOTALUNIDADESBONIF").ToString)

                Call RegresarInventarioComprado(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString, 0, 0, (totalunidades + totalunidadesbonif))

                Call AbrirConexionSql()

                Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE ID=" & SelectedCode, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                Call CargarTotalCompra(strcoddoc, Double.Parse(Me.txtComprasCorrelativo.Text))
                Call CargarGridTempComp()
                Call CargarDGVListaProductosCompras(1)
                Me.txtComprasCodProducto.select()

                TimerColor.Start()

            End If


        End If
    End Sub

#End Region

#Region "TOTAL COMPRA"

    Dim ComprasTotalCosto, ComprasTotalPrecio As Double

    Public Sub CargarTotalCompra(ByVal CODDOC_COMPRA As String, ByVal CORRELATIVO As Double)

        Exit Sub

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT SUM(TOTALPRECIO) AS TOTAL, SUM(TOTALCOSTO) AS COSTOT FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & CODDOC_COMPRA & "' AND CORRELATIVO=" & CORRELATIVO, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    Me.lbTotalCompra.Text = FormatNumber(dr(1), 2).ToString
                    ComprasTotalCosto = Double.Parse(dr(1))
                    ComprasTotalPrecio = Double.Parse(dr(0))
                End If
            Catch ex As Exception
                Me.lbTotalCompra.Text = "0.00"
            End Try

            cn.Close()
        End Using

        If Double.Parse(Me.lbTotalCompra.Text) > 0 Then
            Me.txtComprasFecha.Enabled = False
        Else
            Me.txtComprasFecha.Enabled = True
        End If

    End Sub

#End Region

#Region "GUARDAR COMPRA"

    Private Sub cmdComprasGuardar_Click(sender As Object, e As EventArgs) Handles cmdComprasGuardar.Click

        If Double.Parse(Me.lbTotalCompra.Text) > 0 Then
            If Confirmacion("¿Está seguro que desea Guardar este Compra?", Form1) = True Then

                If Me.txtComprasSerieFac.Text <> "" Then
                Else
                    Me.txtComprasSerieFac.Text = strcoddoc
                End If

                If Me.txtComprasNoFac.Text <> "" Then
                Else
                    Me.txtComprasNoFac.Text = Me.txtComprasCorrelativo.Text
                End If

                If Me.cmbComprasProveedor.Text <> "" Then

                    If Me.cmbComprasVendedor.SelectedIndex >= 0 Then
                        GlobalCodVend = CType(Me.cmbComprasVendedor.SelectedValue, Integer)
                        If fcn_GuardarComp() = True Then
                        Else
                            MsgBox("La compra no se pudo guardar. Intenta guardarla de nuevo. Error: " & GlobalDesError)
                        End If

                    Else
                        MsgBox("Seleccione un vendedor de la lista")
                    End If

                Else
                    MsgBox("Importante, Seleccione un Proveedor")
                End If
            End If
        Else
            MsgBox("No se puede guardar una compra sin productos agregados")
        End If

        TimerColor.Start()

    End Sub

    Private Function copyTemp_x() As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(strSqlConectionString)

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRODUCTOS
                Dim cmd As New SqlCommand("SELECT * FROM TEMP_VENTAS_X", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(strSqlConectionString)
                cnh.Open()
                bcCopy.DestinationTableName = "TEMP_VENTAS"
                bcCopy.WriteToServer(dr)
                dr.Close()
                cnh.Close()


                result = True

            Catch ex As Exception
                MsgBox(ex.ToString)
                result = False
            End Try
        End Using

        Return result

    End Function

    Private Function deleteTempx() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim sql As String
                sql = "DELETE FROM TEMP_VENTAS_X;"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try

        End Using

        Return r

    End Function

    Private Function fcn_GuardarComp() As Boolean

        VentasFechaVencimiento = Me.txtComprasFechaVence.DateTime
        If Me.cmbComprasDiasCredito.Text <> "" Then
            Try
                Integer.Parse(Me.cmbComprasDiasCredito.Text)
                VentasDiasCredito = Integer.Parse(Me.cmbComprasDiasCredito.Text)
            Catch ex As Exception
                VentasDiasCredito = 0
            End Try
        End If

        Dim result As Boolean

        Call CargarCorrelativoCompras()

        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        '*** DETERMINA SI ES CONTADO O CREDITO
        If Me.cmbComprasConCre.SelectedIndex >= 0 Then
        Else
            Me.cmbComprasConCre.SelectedIndex = 0
        End If

        '** PROCESO PARA ACTUALIZAR LOS COSTOS

        Dim CostoMedida As Double = 0
        Dim PrecioMedida As Double = 0

        'MANEJA LAS OBSERVACIONES   
        If Me.txtComprasObs.Text <> "" Then
        Else
            Me.txtComprasObs.Text = "SN"
        End If

        If SelectedForm = "COMPRAS" Then

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'Este dr selecciona los datos de la tabla temporal 
                'y los inserta en la temporal de costos antes de actualizarlos
                Dim cmd2 As New SqlCommand("UPDATE PRODUCTOS SET COSTO = T.COSTO 
            From PRODUCTOS INNER Join (Select EMPNIT, CODPROD, CAST((COSTO / EQUIVALE) As NUMERIC(18, 2)) As COSTO From TEMP_VENTAS Where CODDOC = '" & strcoddoc & "' AND CORRELATIVO=" & Double.Parse(Me.txtComprasCorrelativo.Text) & ") T On PRODUCTOS.CODPROD = T.CODPROD AND T.EMPNIT = PRODUCTOS.EMPNIT
            WHERE PRODUCTOS.EMPNIT = '" & GlobalEmpNit & "'", cn)
                Dim DR2 As SqlDataReader
                DR2 = cmd2.ExecuteReader
                DR2.Close()
                cmd2.Dispose()
            End Using

        End If


        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            '---------------------------------------------
            '
            Dim cmd As New SqlCommand("INSERT INTO DOCUMENTOS (EMPNIT, ANIO, MES, DIA, FECHA, HORA, MINUTO,
                            CODDOC, CORRELATIVO, CODCLIENTE, DOC_NIT,
                            DOC_NOMCLIE, DOC_DIRCLIE, TOTALCOSTO, TOTALPRECIO,
                            CODEMBARQUE, STATUS, CONCRE, USUARIO, CORTE, SERIEFAC,
                            NOFAC, CODVEN, PAGO, VUELTO, MARCA, OBS, DOC_ABONO, DOC_SALDO, VENCIMIENTO, DIASCREDITO
							) 
							VALUES
							(
							@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,@CODDOC,
							@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,@DIRECCION,
							@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',@CONCRE,
							@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,
							(@PAGO-@TOTALPRECIO),'NO',@OBS,@ABONO,@SALDO,@VENCIMIENTO,@DIASCREDITO
							);
	                        INSERT INTO DOCPRODUCTOS 
                            (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF,OBS) 
                            SELECT EMPNIT,@ANIO AS ANIO, @MES AS MES,@DIA AS DIA, CODDOC, CORRELATIVO, CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALUNIDADES,TOTALCOSTO,TOTALPRECIO,COSTO,COSTO,BONIF,TOTALBONIF,OBS FROM TEMP_VENTAS
                            WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO;
	                        DELETE FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn) '"INSERT_Ventas

            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@ANIO", Me.txtComprasFecha.DateTime.Year)
            cmd.Parameters.AddWithValue("@MES", Me.txtComprasFecha.DateTime.Month)
            cmd.Parameters.AddWithValue("@DIA", Me.txtComprasFecha.DateTime.Day)
            cmd.Parameters.AddWithValue("@FECHA", Me.txtComprasFecha.DateTime)
            cmd.Parameters.AddWithValue("@HORA", Now.Hour)
            cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
            cmd.Parameters.AddWithValue("@CODDOC", strcoddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtComprasCorrelativo.Text))
            cmd.Parameters.AddWithValue("@CODCLIENTE", Integer.Parse(Me.cmbComprasProveedor.Text))
            cmd.Parameters.AddWithValue("@NIT", Me.txtComprasNitProveedor.Text)
            cmd.Parameters.AddWithValue("@NOMBRE", Me.txtComprasNombreProveedor.Text)
            cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
            cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.lbTotalCompra.Text))
            cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.lbTotalCompra.Text))
            cmd.Parameters.AddWithValue("@PAGO", Double.Parse(Me.lbTotalCompra.Text))
            cmd.Parameters.AddWithValue("@CODEMBARQUE", "GENERAL")
            cmd.Parameters.AddWithValue("@CONCRE", Me.cmbComprasConCre.SelectedValue.ToString) 'VentasConCre)
            cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
            cmd.Parameters.AddWithValue("@SERIEFAC", Me.txtComprasSerieFac.Text)
            cmd.Parameters.AddWithValue("@NOFAC", Me.txtComprasNoFac.Text)
            cmd.Parameters.AddWithValue("@CODVEN", GlobalCodVend)
            cmd.Parameters.AddWithValue("@OBS", Me.txtComprasObs.Text)
            cmd.Parameters.AddWithValue("@VENCIMIENTO", VentasFechaVencimiento)
            cmd.Parameters.AddWithValue("@DIASCREDITO", VentasDiasCredito)

            If Me.cmbComprasConCre.SelectedValue.ToString = "CRE" Then
                cmd.Parameters.AddWithValue("@SALDO", Double.Parse(Me.lbTotalCompra.Text))
                cmd.Parameters.AddWithValue("@ABONO", 0)
            Else
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@ABONO", Double.Parse(Me.lbTotalCompra.Text))
            End If

            Try
                cmd.ExecuteNonQuery()
                result = True

            Catch ex As Exception
                result = False
            End Try

            If result = True Then
                cmd.Dispose()

                GoTo FINALIZAR


            Else
                SplashScreenManager.CloseForm()

                Return result
                Exit Function
            End If
        End Using

FINALIZAR:

        Form1.Mensaje("COMPRA registrada con éxito")

        Me.lbTotalCompra.Text = "0.00"

        SplashScreenManager.CloseForm()

        'carga las variables para el reporte de compras
        Dim rptFecha As Date, rptCorrelativo As Double
        rptFecha = Me.txtComprasFecha.DateTime
        rptCorrelativo = Double.Parse(Me.txtComprasCorrelativo.Text)

        Me.GridTempProductosCompras.DataSource = Nothing

        Call ActualizarCorrelativoComp()

        Call CargarCorrelativoCompras()

        Call CargarDGVListaProductosCompras(1)

        Call CargarGridTempComp()

        Me.txtComprasFiltro.Text = ""
        Me.txtComprasSerieFac.Text = ""
        Me.txtComprasNoFac.Text = ""
        Me.cmbComprasProveedor.Text = ""
        Me.txtComprasNitProveedor.Text = ""
        Me.txtComprasNombreProveedor.Text = ""
        Me.txtComprasObs.Text = "SN"
        Me.txtComprasCodProducto.select()

        'abre el reporte de compra al final
        If AbrirReporteCompra(rptFecha, strcoddoc, rptCorrelativo, "COMPRAS") = True Then
        Else
            MsgBox("La compra se guardó, pero no se generó el formato. Motivo: " & GlobalDesError)
        End If

        Return result

    End Function



    Public Sub ActualizarCorrelativoComp()

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("UPDATE TIPODOCUMENTOS Set CORRELATIVO=" & (Double.Parse(Me.txtComprasCorrelativo.Text) + 1) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & strcoddoc & "'", cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        End Using

    End Sub

    Private Function fcn_UpdateCostosProducto(ByVal empnit As String, ByVal codprod As String, ByVal codmedida As String, ByVal costo As Double, ByVal utilidad As Double) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd1 As New SqlCommand("UPDATE PRECIOS SET COSTO=@COSTO, UTILIDAD=@UTILIDAD, PORCUTILIDAD=@PORCUTILIDAD WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA", cn)
                cmd1.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd1.Parameters.AddWithValue("@CODPROD", codprod)
                cmd1.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                cmd1.Parameters.AddWithValue("@COSTO", costo)
                cmd1.Parameters.AddWithValue("@UTILIDAD", utilidad)
                cmd1.Parameters.AddWithValue("@PORCUTILIDAD", 0)

                cmd1.ExecuteNonQuery()
                cmd1.Dispose()

                result = True

            Catch ex As Exception
                GlobalDesError = "Error al actualizar costos de producto. " & ex.ToString
                MsgBox(GlobalDesError)
                result = False
            End Try

        End Using

        Return result

    End Function

#End Region



    Private Sub btnComprasTomarDatos_Click(sender As Object, e As EventArgs) Handles btnComprasTomarDatos.Click

        If FlyoutDialog.Show(Me.ParentForm, New view_ordenes_compras_listado) = DialogResult.OK Then

            Call CargarGridTempComp()
            Call CargarTotalCompra(strcoddoc, Double.Parse(Me.txtComprasCorrelativo.Text))


        End If

    End Sub




End Class
