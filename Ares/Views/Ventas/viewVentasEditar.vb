
Imports System.Data
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo

Public Class viewVentasEditar

    'selectedform =  "LISTADOS"

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
    Dim objProducto As New ClassProductos

    Private Sub viewVentasEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.cmbVentasCoddoc.Text = coddoc
        Me.txtVentasCorrelativo.Text = correlativo.ToString
        Me.lbVentasTipoPrecio.SelectedIndex = 0

        Call CargarTipoProd()
        Call CargarConCre()
        Call CargarVendedores()


        Call getDataPedido()

        Call CargarDGVListaProductos(0)

        GlobalSelected_FechaDocumento = Me.txtVentasFecha.DateTime


    End Sub


    Private Sub getMenuUsuario()

        Me.lbVentasTipoPrecio.Enabled = False

    End Sub

#Region " ** RUTINAS ** "

    Private Sub CargarConCre()
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("COD", GetType(String))
            .Add("DES", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {"CON", "CONTADO"})
            .Add(New Object() {"CRE", "CREDITO"})
        End With

        With Me.cmbConcre
            .DataSource = tbl
            .DisplayMember = "DES"
            .ValueMember = "COD"
        End With

        Try
            If Me.cmbConcre.SelectedValue.ToString = "CON" Then
                Me.txtFechaVencimiento.Visible = False
            Else
                Me.txtFechaVencimiento.Visible = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarTipoProd()
        Dim obPr As New ClassProductos

        Try

            With Me.cmbVentasTipoProd
                .DataSource = obPr.tblTipoProd("VENTAS")
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
        With Me.cmbVentasVendedor
            .DataSource = objEmpl.tblListaEmpleadosTipo(GlobalEmpNit, 3)
            .ValueMember = "CODEMP"
            .DisplayMember = "NOMEMP"
        End With

    End Sub

    Private Function getDataPedido() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'OBTENGO LOS ENCABEZADOS DEL DOCUMENTO
                Dim cmd As New SqlCommand("SELECT 
                        FECHA, CODCLIENTE, DOC_NIT, 
                        DOC_NOMCLIE, DOC_DIRCLIE, CODEMBARQUE,
                        CONCRE, CODVEN, OBS, 
                        CODCAJA, DIRENTREGA, LAT, 
                        LONG, VENCIMIENTO, DIASCREDITO 
                        FROM DOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cn)

                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)


                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.txtVentasFecha.DateTime = Date.Parse(dr(0))
                    Me.cmbVentasCaja.Text = dr(9).ToString
                    Me.txtVentasCodCliente.Text = dr(1).ToString
                    Me.txtVentasNitClie.Text = dr(2).ToString
                    Me.txtVentasNombre.Text = dr(3).ToString
                    Me.cmbConcre.SelectedValue = dr(6).ToString
                    Me.cmbVentasVendedor.SelectedValue = dr(7)
                Else
                    MsgBox("No se cargó el documento")
                End If

                'OBTIENE EL DETALLE DE PRODUCTOS DEL DOCUMENTO
                Call CargarGridTemporal()


                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using


        Return r

    End Function

    Private Sub cmbConcre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbConcre.SelectedValueChanged
        Try
            If Me.cmbConcre.SelectedValue.ToString = "CON" Then
                Me.txtFechaVencimiento.Visible = False
            Else
                Me.txtFechaVencimiento.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Async Sub CargarDGVListaProductos(ByVal NoFiltro As Integer) 'carga el dgv tanto en ventas como en movimientos inventario

        Dim strErrores As String = ""
        Try
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
            tbl.Columns.Add("NF", GetType(Integer))
            tbl.Columns.Add("EXENTO", GetType(Integer))

            'DETERMINA EL TIPO DE PRECIO SEGÚN CLIENTE
            Dim tipoprecio As String
            Select Case Me.lbVentasTipoPrecio.Text
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

            Dim Filtro As String
            Filtro = Me.txtVentasFiltro.Text

            Dim sql As String

            Dim selectfrom As String
            selectfrom = "SELECT 
                                PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, 
                                PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, " + tipoprecio + ", 
                                PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLADOS, CLASIFICACIONDOS.DESCLADOS, 
                                CASE WHEN PRODUCTOS.TIPOPROD='S'THEN 0 ELSE INVSALDO.SALDO END AS SALDO, 
                                isnull(PRODUCTOS.NF,0) AS NF, PRODUCTOS.EXENTO
                            FROM
                                INVSALDO RIGHT OUTER JOIN PRECIOS RIGHT OUTER JOIN MARCAS RIGHT OUTER JOIN CLASIFICACIONDOS RIGHT OUTER JOIN
                                PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                                CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                                MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND 
                                INVSALDO.CODPROD = PRODUCTOS.CODPROD
                            WHERE "


            Select Case NoFiltro
                Case 0 'todos
                    sql = selectfrom & "(INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.TIPOPROD=@TP) ORDER BY PRODUCTOS.DESPROD"
                Case 1 'todos
                    sql = selectfrom & "(INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.TIPOPROD=@TP) ORDER BY PRODUCTOS.DESPROD"

                Case 2 'por descripcion
                    sql = selectfrom & "(PRODUCTOS.DESPROD LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRODUCTOS.TIPOPROD=@TP) ORDER BY PRODUCTOS.DESPROD"


            End Select

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", GlobalAnioProceso) 'Integer.Parse(Me.cmdAnioProceso.Text))
                cmd.Parameters.AddWithValue("@MES", GlobalMesProceso) 'Integer.Parse(Me.cmdMesProceso.SelectedValue))
                cmd.Parameters.AddWithValue("@TP", Me.cmbVentasTipoProd.SelectedValue.ToString)

                If NoFiltro > 1 Then
                    cmd.Parameters.AddWithValue("@FILTRO", "%" & Filtro & "%")
                End If

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    Try
                        tbl.Rows.Add(New Object() {
                                dr(0).ToString,'CODPROD -
                                dr(1).ToString,'CODPROD2 -
                                dr(2).ToString,'DESPROD - 
                                dr(3).ToString,'DESPROD2 -
                                dr(4).ToString,'DESPROD3 -
                                Integer.Parse(dr(5).ToString),'UXC -
                                dr(6).ToString,'CODMEDIDA -
                                Integer.Parse(dr(7).ToString),'EQUIVALE - 
                                FormatNumber(Double.Parse(dr(8).ToString), 2),'COSTO -
                                FormatNumber(Double.Parse(dr(9).ToString), 2),'PRECIO -
                                Integer.Parse(dr(10).ToString),'CODMARCA -
                                dr(11).ToString,'DESMARCA -
                                Integer.Parse(dr(12).ToString),'CODCLAUNO -
                                dr(13).ToString,'DESCLAUNO -
                                Integer.Parse(dr(14).ToString),'CODCLADOS -
                                dr(15).ToString,'DESCLADOS -
                                Double.Parse(dr(16).ToString),'SALDO -
                                FormatCurrency(dr(9)).ToString(),
                                Integer.Parse(dr(17)),  'NF
                                Integer.Parse(dr(18))  'EXENTO
                          })
                    Catch ex As Exception
                        'Mensaje("El producto: " & dr(0).ToString & " " & Strings.UCase(dr(2).ToString) & " no ha sido guardado correctamente, vé al catálogo de productos y corrígelo")
                        strErrores = strErrores & " // " & "El producto: " & dr(0).ToString & " " & Strings.UCase(dr(2).ToString) & " no ha sido guardado correctamente"
                    End Try
                Loop

                cn.Close()

                If strErrores.Length = 0 Then
                Else
                    Form1.Mensaje("Pueden haber productos mal guardados o sin precio, por favor verifica el archivo ErrorLog.exe")
                End If
            End Using

            Me.DGVVentaListaProductos.DataSource = tbl

            If Me.cmbVentasTipoProd.SelectedValue.ToString = "S" Then

            Else
                'Call MostrarPintarColorExistencias()

                ' PARA MOSTRAR LOS PRODUCTOS QUE NO SE FACTURAN
                For Each Row As DataGridViewRow In Me.DGVVentaListaProductos.Rows
                    Select Case Integer.Parse(Row.Cells("NF").Value)
                        Case 0 'blanco normal

                        Case 1 ' amarillo
                            Row.DefaultCellStyle.BackColor = Color.Yellow
                        Case 2 'verde
                            Row.DefaultCellStyle.BackColor = Color.GreenYellow
                        Case 3 'azul
                            Row.DefaultCellStyle.BackColor = Color.CadetBlue
                        Case 4 'cafes
                            Row.DefaultCellStyle.BackColor = Color.SaddleBrown
                        Case 5 'morado
                            Row.DefaultCellStyle.BackColor = Color.MediumPurple
                        Case Else

                    End Select
                    'If Integer.Parse(Row.Cells("NF").Value) = 1 Then
                    'Row.DefaultCellStyle.BackColor = Color.Yellow
                    'End If
                Next
            End If

            Me.DGVVentaListaProductos.select()

        Catch ex As Exception
            GlobalDesError = ex.ToString
            'MsgBox(ex.ToString)
            Form1.Mensaje("Tengo problemas para cargar la lista de productos")
        End Try

        Try
            Dim objF As New classFunciones
            Dim f As Boolean = Await Task(Of Boolean).Run(Function() objF.fcnCrearLog(strErrores))

        Catch ex As Exception

        End Try

    End Sub

    'CARGA EL GRID TEMPORAL, TAMBIÉN ACTUALIZA EL ENCABEZADO DEL DOCUMENTO
    Private Sub CargarGridTemporal()

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

            SQL = "SELECT ID, CODPROD, DESPROD, CODMEDIDA, CANTIDAD, PRECIO, TOTALPRECIO, TOTALUNIDADES, COSTO, TOTALCOSTO, TOTALBONIF 
            FROM DOCPRODUCTOS 
            WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N 
            ORDER BY ID"
            Dim cmd As New SqlCommand(SQL, cn)
            cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@D", coddoc)
            cmd.Parameters.AddWithValue("@N", correlativo)

            Dim varTotalCosto As Double = 0
            Dim varTotalPrecio As Double = 0

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Do While dr.Read
                varTotalCosto = varTotalCosto + Double.Parse(dr(9)) 'total costo
                varTotalPrecio = varTotalPrecio + Double.Parse(dr(6)) 'total precio
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

            Me.LbTotalCosto.Text = varTotalCosto
            Me.LbTotalVenta.Text = FormatNumber(varTotalPrecio, 2)


        End Using



        Me.GridVentasTempProductos.DataSource = tbl

        TryCast(Me.TileViewTempProductos.TileTemplate(0), TileViewItemElement).Column = Me.TileViewTempProductos.Columns("CODPROD")
        TryCast(Me.TileViewTempProductos.TileTemplate(1), TileViewItemElement).Column = Me.TileViewTempProductos.Columns("DESPROD")
        TryCast(Me.TileViewTempProductos.TileTemplate(6), TileViewItemElement).Column = Me.TileViewTempProductos.Columns("CODMEDIDA")
        TryCast(Me.TileViewTempProductos.TileTemplate(3), TileViewItemElement).Column = Me.TileViewTempProductos.Columns("CANTIDAD")
        TryCast(Me.TileViewTempProductos.TileTemplate(7), TileViewItemElement).Column = Me.TileViewTempProductos.Columns("StPRECIO")
        TryCast(Me.TileViewTempProductos.TileTemplate(2), TileViewItemElement).Column = Me.TileViewTempProductos.Columns("StTOTALPRECIO")


    End Sub

    ''' <summary>
    ''' Elimina un item de la tabla temporal de documentos
    ''' </summary>
    ''' <param name="idItem"></param>
    ''' <returns></returns>
    Private Function fcn_eliminar_item_documento(ByVal idItem As Integer) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Try
                'elimina el registro de la tabla temporal
                Dim SQL As String
                SQL = "DELETE FROM TEMP_VENTAS WHERE ID=" & idItem

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

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

                Dim cmd As New SqlCommand(sql, cn)
                'parametros del where
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", GlobalSelected_Coddoc)
                cmd.Parameters.AddWithValue("@N", GlobalSelected_Correlativo)
                'valores a actualizar
                cmd.Parameters.AddWithValue("@CODCLIE", CType(Me.txtVentasCodCliente.Text, Integer))
                cmd.Parameters.AddWithValue("@NOMCLIE", Me.txtVentasNombre.Text)
                cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.LbTotalCosto.Text))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.LbTotalVenta.Text))
                cmd.Parameters.AddWithValue("@TOTALEXENTO", 0)

                If Me.cmbConcre.SelectedValue.ToString = "CON" Then
                    cmd.Parameters.AddWithValue("@DOC_SALDO", 0)
                    cmd.Parameters.AddWithValue("@DOC_ABONO", Double.Parse(Me.LbTotalVenta.Text))
                Else
                    cmd.Parameters.AddWithValue("@DOC_SALDO", 0)
                    cmd.Parameters.AddWithValue("@DOC_ABONO", Double.Parse(Me.LbTotalVenta.Text))
                End If

                cmd.Parameters.AddWithValue("@CODVEN", CType(Me.cmbVentasVendedor.SelectedValue, Integer))
                cmd.Parameters.AddWithValue("@TOTALIVA", Double.Parse(Me.LbTotalVenta.Text) * GlobalConfigIVA)
                cmd.Parameters.AddWithValue("@TOTALSINIVA", Double.Parse(Me.LbTotalVenta.Text) - (Double.Parse(Me.LbTotalVenta.Text) * GlobalConfigIVA))

                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function


    Private Function DatosProductoEditar(ByVal CodProducto As String) As Boolean 'OBTIENE LOS DATOS DEL CÓDIGO DE PRODUCTO SELECCIONADO

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


            Dim cmd As New SqlCommand("SELECT PRECIOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, " & tipoprecio & ", INVSALDO.SALDO, PRODUCTOS.EXENTO
                                    FROM PRECIOS LEFT OUTER JOIN PRODUCTOS ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT LEFT OUTER JOIN
                                    INVSALDO ON PRECIOS.CODPROD = INVSALDO.CODPROD AND PRECIOS.EMPNIT = INVSALDO.EMPNIT
                                    WHERE (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRECIOS.EMPNIT = @EMPNIT) AND (PRECIOS.CODPROD = @CODPROD OR PRODUCTOS.CODPROD2=@CODPROD) AND (PRODUCTOS.HABILITADO = 'SI')", cn)

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
                        VentasCorrelativo = Double.Parse(Me.txtVentasCorrelativo.Text)
                        VentasAnio = Integer.Parse(Form1.cmdAnioProceso.Text)
                        VentasMes = Integer.Parse(Form1.cmdMesProceso.SelectedValue)
                        VentasCodProducto = dr(0).ToString
                        VentasDesProducto = dr(1).ToString
                        VentasCodMedida = dr(2).ToString
                        VentasEquivale = Integer.Parse(dr(3).ToString)
                        VentasCostoProducto = Double.Parse(dr(4).ToString)
                        VentasPrecioProducto = Double.Parse(dr(5).ToString)
                        VentasExistencia = Double.Parse(dr(6).ToString)
                        VentasExento = Integer.Parse(dr(7))
                    Catch ex As Exception
                        MsgBox("Datos productos error: " + ex.ToString)
                    End Try

                    result = True

                End If

            Catch ex As Exception
                MsgBox("Datos produtos 2 error: " + ex.ToString)
                result = False
            End Try

            dr.Close()
            cmd.Dispose()

        End Using

        Return result

    End Function

#End Region


#Region " ** EVENTOS DE LOS CONTROLES ** "

    Private Sub TileViewTempProductos_DoubleClick(sender As Object, e As EventArgs) Handles TileViewTempProductos.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewTempProductos.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            SelectedCode = Integer.Parse(TileViewTempProductos.GetRowCellValue(hitInfo.RowHandle, "ID").ToString)

            If FlyoutDialog.Show(Me.ParentForm, New viewEditSalesItem(GlobalEmpNit, SelectedCode)) = DialogResult.OK Then

                Call CargarGridTemporal()

                If fcn_updateDocumento() = True Then
                    Form1.Mensaje("Totales Actualizados")
                Else
                    Form1.Mensaje("No se actualizó el total")
                End If


                Me.txtVentasCodProd.select()

            End If

        End If
    End Sub


    Private Sub txtVentasCodProd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVentasCodProd.KeyDown
        If e.KeyCode = Keys.Enter Then

            VentasNoSerie = "SN"

            If Me.txtVentasCodProd.Text <> "" Then

                If objProducto.ProductoHabilitado(GlobalEmpNit, Me.txtVentasCodProd.Text) = False Then
                    MsgBox("Producto deshabilitado")
                    Exit Sub
                End If

                If DatosProductoEditar(Me.txtVentasCodProd.Text) = True Then
                    'ABRE EL FLYOUTDIALOG CON EL USER CONTROL PARA LA CANTIDAD SELECCIONADA
                    If FlyoutDialog.Show(Me.ParentForm, New UserControl_VentaCantidad(GlobalModoPOS, Me.lbVentasTipoPrecio.Text)) = DialogResult.OK Then

                        Call CargarGridTemporal()

                        Me.txtVentasCodProd.Text = ""
                        Me.txtVentasFiltro.Text = ""
                        Me.txtVentasCodProd.select()

                    End If
                Else
                    MsgBox("Error.. intente con otro código")
                    Exit Sub
                End If

            Else
                Me.txtVentasFiltro.select()
            End If

        End If

    End Sub

    Private Sub cmdVentasBuscarCliente_Click(sender As Object, e As EventArgs) Handles cmdVentasBuscarCliente.Click

        If FlyoutDialog.Show(Me.ParentForm, New viewClientesLista(GlobalEmpNit, SelectedForm)) = DialogResult.OK Then

            Me.txtVentasCodCliente.Text = SelectedCode
            Me.txtVentasNitClie.Text = GlobalSelectedNitCliente
            Me.txtVentasNombre.Text = GlobalSelectedNomCliente

        End If

    End Sub

    Private Sub cmbVentasTipoProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVentasTipoProd.SelectedIndexChanged
        Call CargarDGVListaProductos(1)
    End Sub

    Private Sub cmdVentasGuardar_Click(sender As Object, e As EventArgs) Handles cmdVentasGuardar.Click
        If fcn_updateDocumento() = True Then
            Me.btnCerrar.PerformClick()
        Else
            MsgBox("No se actualizó el encabezado del documento. Error: " & GlobalDesError)
        End If
    End Sub

    Private Sub txtVentasFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVentasFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtVentasFiltro.Text <> "" Then
                Call CargarDGVListaProductos(2)
                'Me.cmdVentasFiltroDescripcion.select()
            Else
                Call CargarDGVListaProductos(1)
            End If
        End If
    End Sub


#End Region


    Private Sub DGVVentaListaProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVVentaListaProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                VentasNoSerie = "SN"

                VentasCorrelativo = Double.Parse(Me.txtVentasCorrelativo.Text)
                VentasCodProducto = Me.DGVVentaListaProductos.Item(1, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DGVVentaListaProductos.Item(3, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString
                VentasCodMedida = Me.DGVVentaListaProductos.Item(7, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString

                VentasExistencia = Double.Parse(Me.DGVVentaListaProductos.Item(17, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
                VentasCostoProducto = Double.Parse(Me.DGVVentaListaProductos.Item(9, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
                VentasEquivale = Integer.Parse(Me.DGVVentaListaProductos.Item(8, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
                VentasPrecioProducto = Double.Parse(Me.DGVVentaListaProductos.Item(10, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
                VentasExento = Integer.Parse(Me.DGVVentaListaProductos.Item(22, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)

                VentasAnio = Me.txtVentasFecha.DateTime.Year
                VentasMes = Me.txtVentasFecha.DateTime.Month


                'MsgBox(String.Format("COD: {0} DESPROD: {1} MED: {2} EXIST: {3} COSTO: {4} PRECIO: {5} EQ: {6} EXENTO: {7}", VentasCodProducto, VentasDesProducto, VentasCodMedida, VentasExistencia, VentasCostoProducto, VentasPrecioProducto, VentasEquivale, VentasExento))

                If FlyoutDialog.Show(Me.ParentForm, New UserControl_VentaCantidad(GlobalModoPOS, Me.lbVentasTipoPrecio.Text)) = DialogResult.OK Then

                    Call CargarGridTemporal()
                    If fcn_updateDocumento() = True Then
                        Form1.Mensaje("Totales actualizados exitosamente!!")
                    Else
                        Form1.Mensaje("No se actualizaron los totales")
                    End If

                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()

                End If

                Me.txtVentasCodProd.select()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If


        If e.KeyCode = Keys.Multiply Then
            VentasCodProducto = Me.DGVVentaListaProductos.Item(1, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString
            FlyoutDialog.Show(Me.ParentForm, New viewProductInfo(GlobalEmpNit, VentasCodProducto))
        End If

        'consulta inventario en otras empresas
        If e.KeyCode = Keys.I Then
            VentasCodProducto = Me.DGVVentaListaProductos.Item(1, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString
            FlyoutDialog.Show(Me.ParentForm, New viewInventarioOnline(GlobalEmpNit, VentasCodProducto))
        End If

    End Sub

    Private Sub TileViewTempProductos_Click(sender As Object, e As EventArgs) Handles TileViewTempProductos.Click
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewTempProductos.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            Dim codigo As String = TileViewTempProductos.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString
            Try
                Me.txtSelectedExistencia.Text = getExistenciaProd(codigo).ToString
            Catch ex As Exception
                Me.txtSelectedExistencia.Text = "--"
            End Try
        End If

    End Sub

    Private Function getExistenciaProd(ByVal codprod As String) As Double
        Dim r As Double

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT SALDO 
                                FROM INVSALDO 
                                WHERE EMPNIT=@E AND CODPROD=@C AND MES=0 AND ANIO=0", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    r = Double.Parse(dr(0))
                Else
                    r = 0
                End If

            Catch ex As Exception
                r = 0
            End Try
        End Using

        Return r

    End Function

    Private Sub TileViewTempProductos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TileViewTempProductos.FocusedRowChanged

        Try
            Dim codigo As String = TileViewTempProductos.GetRowCellValue(e.FocusedRowHandle, "CODPROD").ToString
            Me.txtSelectedExistencia.Text = getExistenciaProd(codigo).ToString
        Catch ex As Exception
            Me.txtSelectedExistencia.Text = "--"
        End Try

    End Sub

    Private Sub txtSelectedExistencia_TextChanged(sender As Object, e As EventArgs) Handles txtSelectedExistencia.TextChanged
        Try
            If Double.Parse(Me.txtSelectedExistencia.Text) <= 0 Then
                Me.txtSelectedExistencia.BackColor = Color.Yellow
            Else
                Me.txtSelectedExistencia.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGVVentaListaProductos_DoubleClick(sender As Object, e As EventArgs) Handles DGVVentaListaProductos.DoubleClick
        Try
            VentasNoSerie = "SN"

            VentasCorrelativo = Double.Parse(Me.txtVentasCorrelativo.Text)
            VentasCodProducto = Me.DGVVentaListaProductos.Item(1, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString
            VentasDesProducto = Me.DGVVentaListaProductos.Item(3, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString
            VentasCodMedida = Me.DGVVentaListaProductos.Item(7, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString

            VentasExistencia = Double.Parse(Me.DGVVentaListaProductos.Item(17, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
            VentasCostoProducto = Double.Parse(Me.DGVVentaListaProductos.Item(9, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
            VentasEquivale = Integer.Parse(Me.DGVVentaListaProductos.Item(8, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
            VentasPrecioProducto = Double.Parse(Me.DGVVentaListaProductos.Item(10, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
            VentasExento = Integer.Parse(Me.DGVVentaListaProductos.Item(22, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)

            VentasAnio = Me.txtVentasFecha.DateTime.Year
            VentasMes = Me.txtVentasFecha.DateTime.Month

            MsgBox(String.Format("COD: {0} DESPROD: {1} MED: {2} EXIST: {3} COSTO: {4} PRECIO: {5} EQ: {6} EXENTO: {7}", VentasCodProducto, VentasDesProducto, VentasCodMedida, VentasExistencia, VentasCostoProducto, VentasPrecioProducto, VentasEquivale, VentasExento))

            If FlyoutDialog.Show(Me.ParentForm, New UserControl_VentaCantidad(GlobalModoPOS, Me.lbVentasTipoPrecio.Text)) = DialogResult.OK Then

                Call CargarGridTemporal()
                If fcn_updateDocumento() = True Then
                    Form1.Mensaje("Totales actualizados exitosamente!!")
                Else
                    Form1.Mensaje("No se actualizaron los totales")
                End If

                Me.txtVentasFiltro.Text = ""
                Me.txtVentasCodProd.select()

            End If

            Me.txtVentasCodProd.select()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



End Class
