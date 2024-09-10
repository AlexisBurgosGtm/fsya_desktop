Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo

Public Class viewComprasEditar
    Sub New(ByVal _coddoc As String, ByVal _correlativo As Double)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        coddoc = _coddoc
        correlativo = _correlativo
        GlobalSelected_Coddoc = _coddoc
        GlobalSelected_Correlativo = _correlativo

    End Sub


    Dim coddoc As String, correlativo As Double

    Private Sub viewComprasEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtComprasCorrelativo.Text = correlativo.ToString

        Call CargarTipoProd()
        Call CargarComboConcre()
        Call CargarVendedores()

        Call CargarDatosCompra()

        Call CargarGridTempCompras()

        Call CargarDGVListaProductosCompras(1)

        GlobalSelected_FechaDocumento = Me.txtComprasFecha.DateTime

    End Sub

    'FUNCIÓN PARA ACTUALIZAR EL ENCABEZADO DEL DOCUMENTO
    Function fcn_updateDocumento() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'NOTA. NO SE PUEDE EDITAR EL CONTADO O CREDITO, SOLO SIRVE PARA SABER A QUE COLUMNA SUMARLE
                Dim sql As String = "UPDATE DOCUMENTOS SET
                    TOTALCOSTO=@TOTALCOSTO,
                    TOTALPRECIO=@TOTALPRECIO,
                    TOTALEXENTO=@TOTALEXENTO,
                    CODCLIENTE=@CODCLIE,
                    DOC_NIT=@CODCLIE,
                    DOC_NOMCLIE=@NOMCLIE,
                    CODVEN=@CODVEN,
                    DOC_SALDO=@DOC_SALDO,
                    DOC_ABONO=@DOC_ABONO,
                    TOTALIVA=@TOTALIVA,
                    TOTALSINIVA=@TOTALSINIVA
                WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N"

                Dim qry As String = "UPDATE DOCUMENTOS SET
                    SERIEFAC=@SERIEFAC, NOFAC=@NOFAC,
                    CODVEN=@CODVEN,OBS=@OBS,
                    TOTALCOSTO=@TOTALCOSTO,
                    TOTALPRECIO=@TOTALPRECIO,
                    TOTALEXENTO=@TOTALEXENTO,
                    DOC_SALDO=@DOC_SALDO,
                    DOC_ABONO=@DOC_ABONO,
                    TOTALIVA=@TOTALIVA,
                    TOTALSINIVA=@TOTALSINIVA
                WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N"

                Dim cmd As New SqlCommand(qry, cn)
                'parametros del where
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                'valores a actualizar
                cmd.Parameters.AddWithValue("@SERIEFAC", Me.txtComprasSerieFac.Text)
                cmd.Parameters.AddWithValue("@NOFAC", Me.txtComprasNoFac.Text)
                cmd.Parameters.AddWithValue("@OBS", Me.txtComprasObs.Text)
                cmd.Parameters.AddWithValue("@CODVEN", CType(Me.cmbComprasVendedor.SelectedValue, Integer))
                cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.lbTotalCompra.Text))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.lbTotalCompra.Text))
                cmd.Parameters.AddWithValue("@TOTALEXENTO", 0)
                If Me.cmbComprasConCre.SelectedValue.ToString = "CON" Then
                    cmd.Parameters.AddWithValue("@DOC_SALDO", 0)
                    cmd.Parameters.AddWithValue("@DOC_ABONO", Double.Parse(Me.lbTotalCompra.Text))
                Else
                    cmd.Parameters.AddWithValue("@DOC_SALDO", 0)
                    cmd.Parameters.AddWithValue("@DOC_ABONO", Double.Parse(Me.lbTotalCompra.Text))
                End If
                cmd.Parameters.AddWithValue("@TOTALIVA", Double.Parse(Me.lbTotalCompra.Text) * GlobalConfigIVA)
                cmd.Parameters.AddWithValue("@TOTALSINIVA", Double.Parse(Me.lbTotalCompra.Text) - (Double.Parse(Me.lbTotalCompra.Text) * GlobalConfigIVA))

                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function


    Private Sub CargarDatosCompra()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT FECHA, CODCLIENTE, DOC_NIT, DOC_NOMCLIE, 
                CONCRE, SERIEFAC, NOFAC, VENCIMIENTO, CODVEN, OBS
                FROM DOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    Me.txtComprasFecha.DateTime = Date.Parse(dr(0))
                    Me.txtComprasFechaVence.DateTime = Date.Parse(dr(7))
                    Me.cmbComprasConCre.SelectedValue = dr(4).ToString
                    Me.cmbComprasProveedor.Text = dr(1).ToString 'codigo
                    Me.txtComprasNitProveedor.Text = dr(2).ToString
                    Me.txtComprasNombreProveedor.Text = dr(3).ToString
                    Me.txtComprasSerieFac.Text = dr(5).ToString
                    Me.txtComprasNoFac.Text = dr(6).ToString
                    Me.cmbComprasVendedor.SelectedValue = Integer.Parse(dr(8))
                    Me.txtComprasObs.Text = dr(9).ToString
                Else
                    MsgBox("No se obtuvieron los datos de la Compra")
                End If


            Catch ex As Exception
                MsgBox("No se obtuvieron los datos de la Compra. Error: " + ex.ToString)
            End Try
        End Using


    End Sub


    Private Sub CargarTipoProd()
        Dim obPr As New ClassProductos

        Try

            With Me.cmbComprasTipoProd
                .DataSource = obPr.tblTipoProd("COMPRAS")
                .ValueMember = "TIPO"
                .DisplayMember = "DESC"
                .SelectedValue = GlobalTipoProd
            End With

            'Me.cmbVentasTipoProd.AutoCompleteMode = AutoCompleteMode.SuggestAppend 
            'Me.cmbVentasTipoProd.AutoCompleteSource = AutoCompleteSource.ListItems

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarVendedores()
        Dim objEmpl As New ClassEmpleados()
        With Me.cmbComprasVendedor
            .DataSource = objEmpl.tblListaEmpleadosTipo(GlobalEmpNit, 3)
            .ValueMember = "CODEMP"
            .DisplayMember = "NOMEMP"
        End With

    End Sub




    Private Sub CargarGridTempCompras()

        Dim varTotalCosto As Double = 0

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

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            'SE SELECCIONA SI CARGARÁ LA VENTA O LA COMPRA
            Dim SQL As String

            Select Case SelectedForm

                Case "LISTADOS"
                    SQL = "SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO,TOTALBONIF 
                    FROM DOCPRODUCTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & coddoc & "' AND CORRELATIVO=" & correlativo & " ORDER BY ID DESC"

            End Select

            Dim cmd As New SqlCommand(SQL, cn)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Do While dr.Read
                varTotalCosto = varTotalCosto + Double.Parse(dr(9))
                tbl.Rows.Add(New Object() {
                             Integer.Parse(dr(0).ToString),
                             dr(1).ToString,
                             dr(2).ToString,
                             dr(3).ToString,
                             Double.Parse(dr(4).ToString),
                             Double.Parse(dr(5).ToString),
                             FormatCurrency(dr(5)).ToString,
                             Double.Parse(dr(6).ToString),
                             FormatCurrency(dr(6)).ToString,
                             Double.Parse(dr(7).ToString),
                             FormatCurrency(dr(8)).ToString,
                             FormatCurrency(dr(9)).ToString,
                             Double.Parse(dr(10).ToString),
                             Double.Parse(dr(8)),
                            Double.Parse(dr(9))
                             })
            Loop
            dr.Close()
            cmd.Dispose()
            'cn.Close()
        End Using

        Select Case SelectedForm

            Case "LISTADOS"
                Me.GridTempProductosCompras.DataSource = tbl

                TryCast(Me.TileViewTempProductosCompras.TileTemplate(0), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("CODPROD")
                TryCast(Me.TileViewTempProductosCompras.TileTemplate(1), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("DESPROD")
                TryCast(Me.TileViewTempProductosCompras.TileTemplate(6), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("CODMEDIDA")
                TryCast(Me.TileViewTempProductosCompras.TileTemplate(3), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("CANTIDAD")
                TryCast(Me.TileViewTempProductosCompras.TileTemplate(7), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("StCOSTO")
                TryCast(Me.TileViewTempProductosCompras.TileTemplate(2), TileViewItemElement).Column = Me.TileViewTempProductosCompras.Columns("StTOTALCOSTO")

        End Select

        Me.lbTotalCompra.Text = FormatNumber(varTotalCosto, 2)

        If fcn_updateDocumento() = True Then
            Form1.Mensaje("Documento actualizado")
        Else
            Form1.Mensaje("No se actualizó el documento")
        End If

    End Sub

    Private Sub txtSelectedExistenciaCompra_TextChanged(sender As Object, e As EventArgs) Handles txtSelectedExistenciaCompra.TextChanged
        Try
            If Double.Parse(Me.txtSelectedExistenciaCompra.Text) <= 0 Then
                Me.txtSelectedExistenciaCompra.BackColor = Color.Yellow
            Else
                Me.txtSelectedExistenciaCompra.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TileViewTempProductosCompras_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TileViewTempProductosCompras.FocusedRowChanged
        Try
            Dim codigo As String = TileViewTempProductosCompras.GetRowCellValue(e.FocusedRowHandle, "CODPROD").ToString
            Me.txtSelectedExistenciaCompra.Text = getExistenciaProd(codigo).ToString
        Catch ex As Exception
            Me.txtSelectedExistenciaCompra.Text = "--"
        End Try
    End Sub


    Private Sub cmdComprasBuscarProveedor_Click(sender As Object, e As EventArgs) Handles cmdComprasBuscarProveedor.Click
        'Me.NavigationFrame1.SelectedPage = NP_Proveedores
        'Call CargarGridProveedores()
        'Me.GridProveedores.Focus()
    End Sub

    Private Sub cmbComprasTipoProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprasTipoProd.SelectedIndexChanged
        Try
            Call CargarDGVListaProductosCompras(1)
        Catch ex As Exception

        End Try
    End Sub



    Private Sub TileViewTempProductosCompras_DoubleClick(sender As Object, e As EventArgs) Handles TileViewTempProductosCompras.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewTempProductosCompras.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            SelectedCode = Integer.Parse(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "ID").ToString)
            If Confirmacion("¿Está seguro que desea eliminar este item de la lista?", Me.ParentForm) = True Then
                Call ObtenerDatosInventario(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString, Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue))
                Dim totalunidades, totalunidadesbonif As Double
                totalunidades = Double.Parse(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "TOTALUNIDADES").ToString)
                totalunidadesbonif = Double.Parse(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "TOTALUNIDADESBONIF").ToString)
                Call RegresarInventarioComprado(TileViewTempProductosCompras.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString, Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue), (totalunidades + totalunidadesbonif))

                Using cn As New SqlConnection(strSqlConectionString)
                    Try
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If

                        Dim cmd As New SqlCommand("DELETE FROM DOCPRODUCTOS WHERE ID=" & SelectedCode, cn)
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception

                    End Try
                End Using

                Call CargarGridTempCompras()

                Me.txtComprasCodProducto.Focus()
            End If

        End If
    End Sub

#Region " ** RUTINAS ** "

    Public Async Sub CargarDGVListaProductosCompras(ByVal NoFiltro As Integer)
        Dim strerrores As String = ""
        Dim objF As New classFunciones

        Dim tbl As New DataTable()
        tbl.Columns.Add("CODPROD", GetType(String))
        tbl.Columns.Add("CODPROD2", GetType(String))
        tbl.Columns.Add("DESPROD", GetType(String))
        tbl.Columns.Add("DESPROD2", GetType(String))
        tbl.Columns.Add("DESPROD3", GetType(String))
        tbl.Columns.Add("UXC", GetType(Integer))
        tbl.Columns.Add("CODMEDIDA", GetType(String))
        tbl.Columns.Add("EQUIVALE", GetType(Integer))
        tbl.Columns.Add("COSTO", GetType(Double))
        tbl.Columns.Add("PRECIO", GetType(Double))
        tbl.Columns.Add("CODMARCA", GetType(Integer))
        tbl.Columns.Add("DESMARCA", GetType(String))
        tbl.Columns.Add("CODCLAUNO", GetType(Integer))
        tbl.Columns.Add("DESCLAUNO", GetType(String))
        tbl.Columns.Add("CODCLADOS", GetType(Integer))
        tbl.Columns.Add("DESCLADOS", GetType(String))
        tbl.Columns.Add("EXISTENCIA", GetType(Double))
        tbl.Columns.Add("PRECIOQ", GetType(String))


        Dim sql As String = ""

        Select Case NoFiltro
            Case 1 'todos
                'sql = "ComprasCargarListaProductos"
                sql = "SELECT PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, 
                         PRECIOS.COSTO, PRECIOS.PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLADOS, CLASIFICACIONDOS.DESCLADOS, 
                         INVSALDO.SALDO, PRODUCTOS.EMPNIT
                    FROM PRECIOS RIGHT OUTER JOIN
                         INVSALDO RIGHT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         CLASIFICACIONDOS RIGHT OUTER JOIN
                         PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                         MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND 
                         PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                    WHERE (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.TIPOPROD=@TP)
                    ORDER BY PRODUCTOS.DESPROD"
            Case 2 'por descripcion
                'sql = "ComprasCargarListaProductosDescripcion"
                sql = "SELECT PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, 
                         PRECIOS.COSTO, PRECIOS.PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLADOS, CLASIFICACIONDOS.DESCLADOS, 
                         INVSALDO.SALDO
                        FROM PRECIOS RIGHT OUTER JOIN
                         INVSALDO RIGHT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         CLASIFICACIONDOS RIGHT OUTER JOIN
                         PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                         MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND 
                         PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                    WHERE (PRODUCTOS.DESPROD LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.TIPOPROD=@TP)
                    ORDER BY PRODUCTOS.DESPROD"
            Case 3 'por componente
                'sql = "ComprasCargarListaProductosDescripcion2"
                sql = "SELECT PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, 
                         PRECIOS.COSTO, PRECIOS.PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLADOS, CLASIFICACIONDOS.DESCLADOS, 
                         INVSALDO.SALDO
                    FROM  PRECIOS RIGHT OUTER JOIN
                         INVSALDO RIGHT OUTER JOIN
                         CLASIFICACIONDOS RIGHT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND 
                         CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD ON 
                         PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                    WHERE (PRODUCTOS.DESPROD2 LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.TIPOPROD=@TP)
                    ORDER BY PRODUCTOS.DESPROD"
            Case 4 'por uso
                'sql = "ComprasCargarListaProductosDescripcion3"
                sql = "SELECT PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, 
                         PRECIOS.COSTO, PRECIOS.PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLADOS, CLASIFICACIONDOS.DESCLADOS, 
                         INVSALDO.SALDO
                        FROM PRECIOS RIGHT OUTER JOIN
                         INVSALDO RIGHT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         CLASIFICACIONDOS RIGHT OUTER JOIN
                         PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                         MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND 
                         PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                    WHERE (PRODUCTOS.DESPROD3 LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.TIPOPROD=@TP)
                    ORDER BY PRODUCTOS.DESPROD"
            Case 5 'por marca
                'sql = "ComprasCargarListaProductosMarca"
                sql = "SELECT PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, 
                         PRECIOS.COSTO, PRECIOS.PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLADOS, CLASIFICACIONDOS.DESCLADOS, 
                         INVSALDO.SALDO
                    FROM PRECIOS RIGHT OUTER JOIN
                         INVSALDO RIGHT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         CLASIFICACIONDOS RIGHT OUTER JOIN
                         PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                         MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND 
                         PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                    WHERE (MARCAS.DESMARCA LIKE @FILTRO) AND (PRECIOS.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRECIOS.HABILITADO='SI') AND (PRODUCTOS.TIPOPROD=@TP)
                    ORDER BY PRODUCTOS.DESPROD"

        End Select



        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand(sql, cn)
            'cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@ANIO", GlobalAnioProceso) 'Integer.Parse(Me.cmdAnioProceso.Text))
            cmd.Parameters.AddWithValue("@MES", GlobalMesProceso) 'Integer.Parse(Me.cmdMesProceso.SelectedValue))
            cmd.Parameters.AddWithValue("@TP", Me.cmbComprasTipoProd.SelectedValue.ToString)

            If NoFiltro > 1 Then
                cmd.Parameters.AddWithValue("@FILTRO", "%" & Me.txtComprasFiltro.Text & "%")
            End If

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            Do While dr.Read
                Try
                    tbl.Rows.Add(New Object() {
                             dr(0).ToString,
                             dr(1).ToString,
                             dr(2).ToString,
                             dr(3).ToString,
                             dr(4).ToString,
                             dr(5),
                             dr(6),
                             dr(7),
                             FormatNumber(Double.Parse(dr(8).ToString), 2),
                             FormatNumber(Double.Parse(dr(9).ToString), 2),
                             dr(10), dr(11).ToString,
                             dr(12), dr(13).ToString,
                             dr(14), dr(15).ToString,
                             Double.Parse(dr(16).ToString),
                             FormatCurrency(dr(8)).ToString
                             })
                Catch ex As Exception
                    strerrores = strerrores & " // " & "El producto: " & dr(0).ToString & " " & Strings.UCase(dr(2).ToString) & " no ha sido guardado correctamente"
                End Try
            Loop

            dr.Close()
            'cn.Close()

            Me.DGV_ListadoProductosCompras.DataSource = tbl


            'BLOQUEA LA COLUMNA DE EXISTENCIAS SEGUN SEA EL PERMISO QUE TENGAN
            Call MostrarPintarColorExistenciasCompras()

            'MANEJO DE ERRORES EN PRODUCTOS
            If strerrores.Length = 0 Then
            Else
                Form1.Mensaje("Pueden haber productos mal guardados o sin precio, por favor verifica el archivo ErrorLog.exe")
            End If
        End Using

        Try
            'Dim f As Boolean = Await Task(Of Boolean).Run(Function() objF.fcnCrearLog(strerrores))

        Catch ex As Exception

        End Try


    End Sub

    ' VERIFICA EL NIVEL DE USUARIO PARA MOSTRAR LAS EXISTENCIAS
    Private Sub MostrarPintarColorExistenciasCompras()
        Try
            If NivelUsuario = 1 Then
                Me.DGV_ListadoProductosCompras.Columns.Item(5).Visible = True
                For Each Row As DataGridViewRow In Me.DGV_ListadoProductosCompras.Rows
                    If Double.Parse(Row.Cells("DGVCOMPEXISTENCIA").Value) <= 0 Then
                        Row.DefaultCellStyle.BackColor = Color.LightSalmon
                    End If
                Next
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CargarComboConcre()
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


#Region " ** EVENTOS DE LOS CONTROLES ** "

    Private Sub DGV_ListadoProductosCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_ListadoProductosCompras.KeyDown

        If e.KeyCode = Keys.Enter Then
            Try
                VentasCorrelativo = correlativo
                VentasCodProducto = Me.DGV_ListadoProductosCompras.Item(1, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DGV_ListadoProductosCompras.Item(3, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
                VentasCodMedida = Me.DGV_ListadoProductosCompras.Item(7, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
                VentasEquivale = Integer.Parse(Me.DGV_ListadoProductosCompras.Item(8, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasCostoProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(9, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasPrecioProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(10, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasExistencia = Integer.Parse(Me.DGV_ListadoProductosCompras.Item(11, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
                VentasAnio = 0 ' Integer.Parse(Me.cmdAnioProceso.Text)
                VentasMes = 0 ' Integer.Parse(Me.cmdMesProceso.SelectedValue)

                'MsgBox(String.Format("codigo: {0}, descrip: {1}, medida: {2}, eq: {3}, costo: {4}, precio: {5}, exist: {6}", VentasCodProducto, VentasDesProducto, VentasCodMedida, VentasEquivale, VentasCostoProducto, VentasPrecioProducto, VentasExistencia))
                'ABRE EL FLYOUTDIALOG CON EL USER CONTROL PARA LA CANTIDAD SELECCIONADA
                Dim control As New UserControl_VentaCantidadCompras(False)
                If FlyoutDialog.Show(Me.ParentForm, control) = DialogResult.OK Then
                    Call CargarGridTempCompras()

                    Me.txtComprasFiltro.Text = ""
                    Me.txtComprasCodProducto.Focus()
                End If

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub DGV_ListadoProductosCompras_DoubleClick(sender As Object, e As EventArgs) Handles DGV_ListadoProductosCompras.DoubleClick

        Try
            VentasCorrelativo = correlativo
            VentasCodProducto = Me.DGV_ListadoProductosCompras.Item(1, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            VentasDesProducto = Me.DGV_ListadoProductosCompras.Item(3, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            VentasCodMedida = Me.DGV_ListadoProductosCompras.Item(7, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString
            VentasEquivale = Integer.Parse(Me.DGV_ListadoProductosCompras.Item(8, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasCostoProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(9, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasPrecioProducto = Double.Parse(Me.DGV_ListadoProductosCompras.Item(10, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasExistencia = Integer.Parse(Me.DGV_ListadoProductosCompras.Item(11, Me.DGV_ListadoProductosCompras.CurrentRow.Index).Value.ToString)
            VentasAnio = 0 ' Integer.Parse(Me.cmdAnioProceso.Text)
            VentasMes = 0 ' Integer.Parse(Me.cmdMesProceso.SelectedValue)


            'MsgBox(String.Format("codigo: {0}, descrip: {1}, medida: {2}, eq: {3}, costo: {4}, precio: {5}, exist: {6}", VentasCodProducto, VentasDesProducto, VentasCodMedida, VentasEquivale, VentasCostoProducto, VentasPrecioProducto, VentasExistencia))
            'ABRE EL FLYOUTDIALOG CON EL USER CONTROL PARA LA CANTIDAD SELECCIONADA
            Dim control As New UserControl_VentaCantidadCompras(False)
            If FlyoutDialog.Show(Me.ParentForm, control) = DialogResult.OK Then
                Call CargarGridTempCompras()

                Me.txtComprasFiltro.Text = ""
                Me.txtComprasCodProducto.Focus()
            End If

        Catch ex As Exception

        End Try


    End Sub



    Private Sub cmbComprasProveedor_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.txtComprasCodProducto.Focus()
        End If
    End Sub

    Private Sub txtComprasSerieFac_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasSerieFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtComprasNoFac.Focus()
        End If
    End Sub

    Private Sub txtComprasNoFac_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasNoFac.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtComprasCodProducto.Focus()
        End If
    End Sub

    Private Sub txtComprasNitProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasNitProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtComprasNitProveedor.Text <> "" Then
                Call ObtenerProveedorCompra(Me.txtComprasNitProveedor.Text)
                Me.txtComprasSerieFac.Focus()
            Else
                Me.txtComprasSerieFac.Focus()
            End If

        End If
    End Sub

    Private Sub cnbComprasConCre_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbComprasConCre.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbComprasVendedor.Focus()
        End If
    End Sub

    Private Sub cmbComprasConCre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComprasConCre.SelectedIndexChanged
        Try
            If Me.cmbComprasConCre.SelectedValue.ToString = "CRE" Then
                'Me.txtComprasFechaVence.DateTime = Me.txtComprasFecha.DateTime.AddDays(Integer.Parse(Me.cmbComprasDiasCredito.Text))
                Me.txtComprasFechaVence.Enabled = True
            Else
                Me.txtComprasFechaVence.DateTime = Me.txtComprasFecha.DateTime
                Me.txtComprasFechaVence.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdComprasGuardar_Click(sender As Object, e As EventArgs) Handles cmdComprasGuardar.Click

        If fcn_updateDocumento() = True Then
            Form1.Mensaje("Documento actualizado")
        Else
            Form1.Mensaje("No se actualizó el documento")
        End If

        Me.btnAceptarTrue.PerformClick()

    End Sub



    Private Sub txtComprasFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComprasFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtComprasFiltro.Text <> "" Then
                Call CargarDGVListaProductosCompras(2)
                Me.DGV_ListadoProductosCompras.Focus()
            Else
                Call CargarDGVListaProductosCompras(1)
                Me.DGV_ListadoProductosCompras.Focus()
            End If

        End If
    End Sub



#End Region


End Class
