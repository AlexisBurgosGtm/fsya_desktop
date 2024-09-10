Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports Security

Public Class viewTras

    Dim objProducto As New ClassProductos
    Dim medidas As String

    Private Sub viewTras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call cargarCoddocTras()
        Call cargarCoddoc()
        Call CargarCorrelativoTras()
        Me.txtMovInvFecha.DateTime = Today.Date
        Call fcnSelectedForm()
        Call CargarDGVListaProductosTras(0)
        TimerColor.Start()
        Call CargarGridTempTras()
        Me.CheckBoxOBJ2.Checked = True

    End Sub

#Region "TIMER COLOR"

    Private Sub DGVMovInvListado_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles DGVMovInvListado.Sorted

        TimerColor.Start()

    End Sub

    Private Sub TimerColor_Tick(sender As Object, e As EventArgs) Handles TimerColor.Tick

        For Each Row As DataGridViewRow In Me.DGVMovInvListado.Rows
            If Double.Parse(Row.Cells("EXISTENCIA").Value) <= 0 Then
                Row.DefaultCellStyle.BackColor = Color.LightSalmon
            End If
        Next

        TimerColor.Stop()

    End Sub

#End Region
    Private Function fcnSelectedForm() As Boolean

        Select Case SelectedForm
            Case "TRASSAL"
                Me.txtMovInvTipo.Text = "SALIDA HACIA SUCURSALES"
                Me.LabelControl130.Visible = False
                Me.CheckBoxOBJ1.Visible = False
                Me.CheckBoxOBJ2.Visible = False
                Me.cmbtipovencidos.Visible = False
                Me.LabelControl10.Visible = False
            Case "TRASSALSUC"
                Me.txtMovInvTipo.Text = "SALIDA HACIA SUCURSAL"
                Me.LabelControl130.Location = New Point(401, 60)
                Me.CheckBoxOBJ1.Location = New Point(401, 82)
                Me.CheckBoxOBJ2.Location = New Point(531, 83)
                Me.cmbtipovencidos.Visible = False
                Me.LabelControl10.Visible = False
            Case "TRASSALVENC"
                Me.txtMovInvTipo.Text = "SALIDA A VENCIDOS"
                Me.cmbtipovencidos.Text = "VENCIDOS"
                Me.LabelControl130.Visible = False
                Me.CheckBoxOBJ1.Visible = False
                Me.CheckBoxOBJ2.Visible = False
                Me.cmbtipovencidos.Visible = True
                Me.LabelControl10.Visible = True
            Case "TRASSALPROV"
                Me.txtMovInvTipo.Text = "SALIDA A PROVEEDORES"
                Me.LabelControl130.Visible = False
                Me.CheckBoxOBJ1.Visible = False
                Me.CheckBoxOBJ2.Visible = False
                Me.cmbtipovencidos.Visible = False
                Me.LabelControl10.Visible = False
        End Select

    End Function

#Region "CHECKBOXES TRASLADOS"

    Private Sub CheckBoxOBJ1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOBJ1.CheckedChanged

        If Me.CheckBoxOBJ1.Checked = True Then
            Me.CheckBoxOBJ2.Checked = False
        End If

    End Sub

    Private Sub CheckBoxOBJ2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOBJ2.CheckedChanged

        If Me.CheckBoxOBJ2.Checked = True Then
            Me.CheckBoxOBJ1.Checked = False
        End If

    End Sub


#End Region

    Private Function objTraslado() As String

        Dim obj As String

        If Me.CheckBoxOBJ1.Checked = True Then
            obj = "COMPLEMENTO"

        End If

        If Me.CheckBoxOBJ2.Checked = True Then
            obj = "TRASLADO"
        End If

        Return obj

    End Function


    Private Sub cmdMovInvGuardar_Click(sender As Object, e As EventArgs) Handles cmdMovInvGuardar.Click

        Call GuardarMovInv()

        Me.CheckBoxOBJ1.Checked = False
        Me.CheckBoxOBJ2.Checked = True

    End Sub

    Private Function GuardarMovInv() As Boolean

        Dim result As Boolean

        If Me.txtMovInvObs.Text <> "" Then
        Else
            Me.txtMovInvObs.Text = "SN"
        End If

        If insertMovinvDocumentos() = True Then
            'If deleteTempMovinv() = True Then
            'Else
            'MsgBox("No se pudo eliminar los datos temporales. Error: " + GlobalDesError)
            'End If4
        Else
            MsgBox("No se pudo guardar el documento. Error: " + GlobalDesError)
        End If

FINALIZAR:

        'abre el reporte antes de recargar todo
        Call AbrirReporte_MovInv(Me.txtMovInvFecha.DateTime, Me.cmbSerieMovInv.SelectedValue.ToString, Double.Parse(Me.txtMovInvCorrelativo.Text))
        Me.GridTempMovInv.DataSource = Nothing
        Call ActualizarCorrTras()
        Call CargarCorrelativoTras()
        Call CargarDGVListaProductosTras(0)
        Me.txtMovInvFiltro.Text = ""
        Me.LbMovInvTotalCosto.Text = "0.00"
        Me.LbMovInvTotalPrecio.Text = "0.00"
        Me.txtMovInvObs.Text = ""
        Me.CheckBoxOBJ2.Checked = True
        Call Form1.Mensaje("Movimiento registrado con éxito")

        Return result

    End Function

    'inserta el movimiento de inventario
    Private Function insertMovinvDocumentos() As Boolean
        Dim r As Boolean

        If createDocument() = True Then
            If updateDocprods() = True Then
                r = True
            Else
                r = False
            End If
        Else
            r = False
        End If

        Return r

    End Function

    Private Function createDocument() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim sql As String
                sql = "INSERT INTO DOCUMENTOS (EMPNIT,ANIO,MES,DIA,FECHA,HORA,MINUTO,
							CODDOC,CORRELATIVO,CODCLIENTE,DOC_NIT,
							DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,TOTALPRECIO,
							CODEMBARQUE,STATUS,CONCRE,USUARIO,CORTE,SERIEFAC,
							NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_ABONO, DOC_SALDO, IDENTIFICADOR, TIPOVENTA
							) 
							VALUES
							(
							@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,@CODDOC,
							@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,@DIRECCION,
							@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',@CONCRE,
							@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,
							(@PAGO-@TOTALPRECIO),'NO',@OBS,@ABONO,@SALDO, @IDENTIFICADOR, @TIPOVENTA
							);"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Today.Year)
                cmd.Parameters.AddWithValue("@MES", Today.Month)
                cmd.Parameters.AddWithValue("@DIA", Today.Day)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbSerieMovInv.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtMovInvCorrelativo.Text))
                cmd.Parameters.AddWithValue("@CODCLIENTE", 0)
                cmd.Parameters.AddWithValue("@NIT", "CF")
                cmd.Parameters.AddWithValue("@NOMBRE", "BODEGA")
                cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.LbMovInvTotalCosto.Text))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.LbMovInvTotalPrecio.Text))
                cmd.Parameters.AddWithValue("@PAGO", 0)
                cmd.Parameters.AddWithValue("@CODEMBARQUE", "GENERAL")
                cmd.Parameters.AddWithValue("@CONCRE", "CON") 'VentasConCre)
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@SERIEFAC", Me.cmbSerieMovInv.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@NOFAC", Me.txtMovInvCorrelativo.Text)
                cmd.Parameters.AddWithValue("@CODVEN", 1)
                cmd.Parameters.AddWithValue("@OBS", Me.txtMovInvObs.Text)
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@ABONO", Double.Parse(Me.LbMovInvTotalPrecio.Text))
                If SelectedForm = "TRASSALVENC" Then
                    cmd.Parameters.AddWithValue("@IDENTIFICADOR", Me.cmbtipovencidos.Text)
                Else
                    cmd.Parameters.AddWithValue("@IDENTIFICADOR", "S/N")
                End If
                If GlobalEmpNit = "COMPRAS" Or GlobalEmpNit = "002" Or GlobalCoddocTras = "TRASSALPROV" Then
                    cmd.Parameters.AddWithValue("@TIPOVENTA", "S/N")
                Else
                    cmd.Parameters.AddWithValue("@TIPOVENTA", objTraslado)
                End If
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                r = True

            Catch ex As Exception
                MsgBox(ex.ToString & " EN CREATEDOCUMENT")
                r = False
            End Try

        End Using

        Return r

    End Function

    Private Function updateDocprods() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim sqlDocprod As String
                sqlDocprod = "INSERT INTO DOCPRODUCTOS (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF) 
                            SELECT EMPNIT,@ANIO AS ANIO, @MES AS MES,@DIA AS DIA, CODDOC, CORRELATIVO, CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALUNIDADES,TOTALCOSTO,TOTALPRECIO,COSTO,COSTO,BONIF,TOTALBONIF FROM TEMP_VENTAS 
                            WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO; "

                Dim sqlDocprod2 As String
                sqlDocprod2 = "UPDATE DOCPRODUCTOS SET EMPNIT = @EMPNIT WHERE EMPNIT = 'TEMPTRAS' AND CODDOC = @CODDOC AND CORRELATIVO = @CORRELATIVO"

                Dim cmd As New SqlCommand(sqlDocprod2, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Me.txtMovInvFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@MES", Me.txtMovInvFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@DIA", Me.txtMovInvFecha.DateTime.Day)
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbSerieMovInv.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtMovInvCorrelativo.Text))
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                r = True

            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try

        End Using

        Return r

    End Function
    Private Function deleteTempMovinv() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim sql As String
                sql = "DELETE FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO;"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbSerieMovInv.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtMovInvCorrelativo.Text))
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

    Private Sub cmbSerieMovInv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSerieMovInv.SelectedIndexChanged
        Try
            Me.GridTempMovInv.DataSource = Nothing
            Call CargarCorrelativoVentas()
            Call CargarDGVListaProductosTras(0)
            'Call CargarTotalVenta(Me.cmbSerieMovInv.SelectedValue.ToString, Double.Parse(Me.txtMovInvCorrelativo.Text))

            Call CargarGridTempTras()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtMovInvFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMovInvFecha.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtMovInvCodProd.select()
        End If
    End Sub

    Private Sub TileViewTempMovInv_DoubleClick(sender As Object, e As EventArgs) Handles TileViewTempMovInv.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewTempMovInv.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            SelectedCode = Integer.Parse(TileViewTempMovInv.GetRowCellValue(hitInfo.RowHandle, "ID").ToString)
            If Confirmacion("¿Está seguro que desea eliminar este item de la lista?", Form1) = True Then
                Call ObtenerDatosInventario(TileViewTempMovInv.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString, 0, 0)
                Call RegresarInventario(TileViewTempMovInv.GetRowCellValue(hitInfo.RowHandle, "CODPROD").ToString, 0, 0, Double.Parse(TileViewTempMovInv.GetRowCellValue(hitInfo.RowHandle, "TOTALUNIDADES").ToString))
                Call AbrirConexionSql()
                Dim cmd As New SqlCommand("DELETE FROM DOCPRODUCTOS WHERE ID = " & SelectedCode, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                Call CargarDGVListaProductosTras(0)
                TimerColor.Start()
                Call CargarGridTempTras()

                Me.txtMovInvCodProd.select()
                'Call CargarTotalVenta(Me.cmbSerieMovInv.SelectedValue.ToString, Double.Parse(Me.txtMovInvCorrelativo.Text))
            End If

        End If
    End Sub

    Private Sub txtMovInvCodProd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMovInvCodProd.KeyDown

        If e.KeyCode = Keys.Enter Then

            If Me.txtMovInvCodProd.Text <> "" Then

                If objProducto.ProductoHabilitado(GlobalEmpNit, Me.txtMovInvCodProd.Text) = False Then
                    MsgBox("Producto deshabilitado")
                    Exit Sub
                End If

                If DatosProductoTRas(Me.txtMovInvCodProd.Text) = True Then

                    'ABRE EL FLYOUTDIALOG CON EL USER CONTROL PARA LA CANTIDAD SELECCIONADA
                    Dim control As New UserControl_TrasladosCantidad()
                    If FlyoutDialog.Show(Form1, control) = DialogResult.OK Then
                        Me.txtMovInvCodProd.Text = ""
                        Call CargarGridTempTras()

                    End If

                Else
                    Call Form1.Mensaje("Código de producto no existe o se encuentra deshabilitado")
                End If
            Else
                Me.txtMovInvFiltro.select()
            End If
        End If

    End Sub

    Private Sub txtMovInvFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMovInvFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarDGVListaProductosTras(1)
        End If
    End Sub

    Private Sub cmdMovInvFiltroMarca_Click(sender As Object, e As EventArgs) Handles cmdMovInvFiltroMarca.Click
        If Me.txtMovInvFiltro.Text <> "" Then
            Call CargarDGVListaProductosTras(2)
        End If
    End Sub

    Private Sub DGVMovInvListado_KeyDown(sender As Object, e As KeyEventArgs) Handles DGVMovInvListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                VentasCorrelativo = Double.Parse(Me.txtMovInvCorrelativo.Text)
                VentasCodProducto = Me.DGVMovInvListado.Item(0, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DGVMovInvListado.Item(1, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                VentasCodMedida = Me.DGVMovInvListado.Item(2, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                VentasEquivale = Integer.Parse(Me.DGVMovInvListado.Item(3, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasCostoProducto = Double.Parse(Me.DGVMovInvListado.Item(5, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasPrecioProducto = Double.Parse(Me.DGVMovInvListado.Item(6, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasExistencia = Double.Parse(Me.DGVMovInvListado.Item(4, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasAnio = Me.txtMovInvFecha.DateTime.Year
                VentasMes = Me.txtMovInvFecha.DateTime.Month

                Dim control As New UserControl_TrasladosCantidad()

                If FlyoutDialog.Show(Form1, control) = DialogResult.OK Then

                    TimerColor.Start()
                    Call CargarGridTempTras()

                    Me.txtMovInvCodProd.Text = ""
                    Me.txtMovInvFiltro.Text = ""
                    Me.txtMovInvCodProd.select()

                End If

                Me.txtMovInvCodProd.select()

            Catch ex As Exception
            End Try
        End If

        If e.KeyCode = Keys.I Then
            VentasCodProducto = Me.DGVMovInvListado.Item(0, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
            FlyoutDialog.Show(Form1, New viewInventarioOnline(GlobalEmpNit, VentasCodProducto))
        End If

    End Sub

    Private Sub DGVMovInvListado_DoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles DGVMovInvListado.CellMouseDoubleClick

        If e.Button = MouseButtons.Left Then
            Try
                VentasCorrelativo = Double.Parse(Me.txtMovInvCorrelativo.Text)
                VentasCodProducto = Me.DGVMovInvListado.Item(0, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DGVMovInvListado.Item(1, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                VentasCodMedida = Me.DGVMovInvListado.Item(2, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                VentasEquivale = Integer.Parse(Me.DGVMovInvListado.Item(3, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasCostoProducto = Double.Parse(Me.DGVMovInvListado.Item(5, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasPrecioProducto = Double.Parse(Me.DGVMovInvListado.Item(6, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasExistencia = Double.Parse(Me.DGVMovInvListado.Item(4, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasAnio = Me.txtMovInvFecha.DateTime.Year
                VentasMes = Me.txtMovInvFecha.DateTime.Month

                Dim control As New UserControl_TrasladosCantidad()

                If FlyoutDialog.Show(Form1, control) = DialogResult.OK Then

                    TimerColor.Start()
                    Call CargarGridTempTras()

                    Me.txtMovInvFiltro.Text = ""
                    Me.txtMovInvCodProd.select()

                End If

                Me.txtMovInvCodProd.select()

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub DGVMovInvListado_CellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DGVMovInvListado.CellMouseClick
        If e.Button = MouseButtons.Right Then
            If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False Then
                Me.DGVMovInvListado.ClearSelection()
                Me.DGVMovInvListado.CurrentCell = Me.DGVMovInvListado.Item(e.ColumnIndex, e.RowIndex)
            End If
        End If
    End Sub

    Private Sub DGVMovInvListado_RightClick(sender As Object, ByVal e As MouseEventArgs) Handles DGVMovInvListado.CellMouseDoubleClick

        If e.Button = MouseButtons.Right Then

            Try

                VentasCodProducto = Me.DGVMovInvListado.Item(0, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DGVMovInvListado.Item(1, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString
                Call medida(VentasCodProducto)
                VentasExistencia = Double.Parse(Me.DGVMovInvListado.Item(4, Me.DGVMovInvListado.CurrentRow.Index).Value.ToString)
                VentasCodMedida = medidas

                FlyoutDialog.Show(Form1, New UserControlEmergentes())

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub medida(ByVal codprod As String)

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT        CODMEDIDA
                                           FROM            PRECIOS
                                           WHERE        (EQUIVALE = 1) AND (EMPNIT = @EMPNIT) AND (CODPROD = @CODPROD)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    medidas = dr(0).ToString
                Else
                    MsgBox("Medida no cargada")
                    Exit Sub
                End If
                dr.Close()
                cmd.Dispose()

                cn.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

    End Sub

    Private Sub CargarDGVListaProductosTras(ByVal NoFiltro As Integer)

        Dim Filtro As String = Me.txtMovInvFiltro.Text
        Dim sql As String
        Dim strErrores As String = ""
        Dim selectfrom As String

        Try
            Dim tbl As New DS_VENTAS2.tblTrasladosDataTable

            selectfrom = "SELECT            PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, PRECIOS.PRECIO, MARCAS.DESMARCA, INVSALDO.SALDO AS EXISTENCIA
                          FROM              INVSALDO RIGHT OUTER JOIN
                                            PRECIOS RIGHT OUTER JOIN
                                            MARCAS RIGHT OUTER JOIN
                                            CLASIFICACIONDOS RIGHT OUTER JOIN
                                            PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                                            CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                                            MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND 
                                            INVSALDO.CODPROD = PRODUCTOS.CODPROD
                          WHERE "

            Select Case NoFiltro
                Case 0 'todos
                    sql = selectfrom & "(PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') ORDER BY PRODUCTOS.DESPROD"

                Case 1 'por descripcion
                    sql = selectfrom & "(PRODUCTOS.DESPROD LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') ORDER BY PRODUCTOS.DESPROD"

                Case 2 'por marca
                    sql = selectfrom & "(MARCAS.DESMARCA LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO='SI') ORDER BY PRODUCTOS.DESPROD"
            End Select

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

                If NoFiltro > 0 Then
                    cmd.Parameters.AddWithValue("@FILTRO", "%" & Filtro & "%")
                End If

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Do While dr.Read
                    Try
                        tbl.Rows.Add(New Object() {
                                dr(0).ToString,                                 'CODPROD -
                                dr(1).ToString,                                 'DESPROD - 
                                dr(2).ToString,                                 'CODMEDIDA -
                                Integer.Parse(dr(3).ToString),                  'EQUIVALE - 
                                FormatNumber(Double.Parse(dr(4).ToString), 2),  'COSTO -
                                FormatNumber(Double.Parse(dr(5).ToString), 2),  'PRECIO -
                                dr(6).ToString,                                 'DESMARCA -
                                Double.Parse(dr(7).ToString)                    'SALDO -
                          })
                    Catch ex As Exception

                        strErrores = strErrores & " // " & "El producto: " & dr(0).ToString & " " & Strings.UCase(dr(2).ToString) & " no ha sido guardado correctamente"
                    End Try
                Loop

                cn.Close()

                If strErrores.Length = 0 Then
                Else
                    Form1.Mensaje("Pueden haber productos mal guardados o sin precio, por favor verifica el archivo ErrorLog.exe")
                End If
            End Using

            Me.DGVMovInvListado.DataSource = tbl
            Me.DGVMovInvListado.select()


            Call fcnNiveldeUsuario()

        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try


    End Sub

    Private Sub fcnNiveldeUsuario()

        Call PermisoExistencia()
        If NivelUsuario = 2 Then
            Me.DGVMovInvListado.Columns.Item("COSTO").Visible = False
            If ExisSiNo = "SI" Then
                Me.DGVMovInvListado.Columns.Item(4).Visible = True
            Else
                Me.DGVMovInvListado.Columns.Item(4).Visible = False
            End If
        Else
        End If

    End Sub

    Dim ExisSiNo As String

    Private Sub PermisoExistencia()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           NIVEL2
                                           FROM             PERMISOS
                                           WHERE            (ID = 29)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    ExisSiNo = dr(0).ToString
                Else
                    ExisSiNo = "NO"
                End If
                dr.Close()
                cmd.Dispose()

                cn.Close()

            Catch ex As Exception

            End Try

        End Using

    End Sub

    Private Function cargarCoddocTras() As Boolean
        Dim objTipoDocumentos As New ClassTipoDocumentos(GlobalEmpNit)
        Dim result As Boolean

        Select Case SelectedForm


            Case "TRASSAL"
                With Me.cmbSerieMovInv
                    .DataSource = objTipoDocumentos.tblCoddoc("TSL")
                    .DisplayMember = "CODDOC"
                    .ValueMember = "CODDOC"

                End With
                Try
                    Me.cmbSerieMovInv.SelectedValue = GlobalCoddocTrasSalBodega
                    GlobalCoddocTras = GlobalCoddocTrasSalBodega
                Catch ex As Exception

                End Try

                'verifica si el selector está vacío y selecciona el primer index
                If Me.cmbSerieMovInv.Text <> "" Then
                Else
                    Me.cmbSerieMovInv.SelectedIndex = 0
                End If

                result = True

            Case "TRASSALSUC"
                With Me.cmbSerieMovInv
                    .DataSource = objTipoDocumentos.tblCoddoc("TSS")
                    .DisplayMember = "CODDOC"
                    .ValueMember = "CODDOC"
                End With

                Try
                    Me.cmbSerieMovInv.SelectedValue = GlobalCoddocTrasSalSucursal
                    GlobalCoddocTras = GlobalCoddocTrasSalSucursal
                Catch ex As Exception

                End Try

                'verifica si el selector está vacío y selecciona el primer index
                If Me.cmbSerieMovInv.Text <> "" Then
                Else
                    Me.cmbSerieMovInv.SelectedIndex = 0
                End If

                result = True

            Case "TRASSALVENC"
                With Me.cmbSerieMovInv
                    .DataSource = objTipoDocumentos.tblCoddoc("TSS")
                    .DisplayMember = "CODDOC"
                    .ValueMember = "CODDOC"
                End With

                Try
                    Me.cmbSerieMovInv.SelectedValue = GlobalCoddocTrasSalSucursal
                    GlobalCoddocTras = GlobalCoddocTrasSalSucursal
                Catch ex As Exception

                End Try

                'verifica si el selector está vacío y selecciona el primer index
                If Me.cmbSerieMovInv.Text <> "" Then
                Else
                    Me.cmbSerieMovInv.SelectedIndex = 0
                End If

                result = True


            Case "TRASSALPROV"
                With Me.cmbSerieMovInv
                    .DataSource = objTipoDocumentos.tblCoddoc("TSL")
                    .DisplayMember = "CODDOC"
                    .ValueMember = "CODDOC"

                End With
                Try
                    Me.cmbSerieMovInv.SelectedValue = GlobalCoddocTrasSalBodega
                    GlobalCoddocTras = GlobalCoddocTrasSalBodega
                Catch ex As Exception

                End Try

                'verifica si el selector está vacío y selecciona el primer index
                If Me.cmbSerieMovInv.Text <> "" Then
                Else
                    Me.cmbSerieMovInv.SelectedIndex = 0
                End If

                result = True


        End Select

        Return result

    End Function

    Private Sub CargarCorrelativoTras()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & Me.cmbSerieMovInv.SelectedValue.ToString & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()

            Try

                Me.txtMovInvCorrelativo.Text = dr(0).ToString

            Catch ex As Exception
                MsgBox(ex.ToString)
                Me.txtMovInvCorrelativo.Text = 0

            End Try
            dr.Close()
            cmd.Dispose()
        End Using
        'cn.Close()

    End Sub

    Private Sub CargarGridTempTras()

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

            Dim cmd As New SqlCommand("SELECT ID,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,PRECIO,TOTALPRECIO,TOTALUNIDADES,COSTO,TOTALCOSTO FROM DOCPRODUCTOS WHERE EMPNIT='TEMPTRAS' AND CODDOC='" + GlobalCoddocTras + "' AND CORRELATIVO=" + Me.txtMovInvCorrelativo.Text + " ORDER BY ID DESC", cn)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            Try
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
                            FormatCurrency(Double.Parse(dr(6))) 'TOTAL A PAGAR
                             })
                    varTotalPrecio = varTotalPrecio + Double.Parse(dr(6))
                    varTotalCosto = varTotalCosto + Double.Parse(dr(9))
                Loop
                dr.Close()
                cmd.Dispose()
                'cn.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using

        Me.GridTempMovInv.DataSource = tbl

        TryCast(Me.TileViewTempMovInv.TileTemplate(0), TileViewItemElement).Column = Me.TileViewTempMovInv.Columns("CODPROD")
        TryCast(Me.TileViewTempMovInv.TileTemplate(1), TileViewItemElement).Column = Me.TileViewTempMovInv.Columns("DESPROD")
        TryCast(Me.TileViewTempMovInv.TileTemplate(6), TileViewItemElement).Column = Me.TileViewTempMovInv.Columns("CODMEDIDA")
        TryCast(Me.TileViewTempMovInv.TileTemplate(3), TileViewItemElement).Column = Me.TileViewTempMovInv.Columns("CANTIDAD")
        TryCast(Me.TileViewTempMovInv.TileTemplate(7), TileViewItemElement).Column = Me.TileViewTempMovInv.Columns("StPRECIO")
        TryCast(Me.TileViewTempMovInv.TileTemplate(2), TileViewItemElement).Column = Me.TileViewTempMovInv.Columns("StTOTALPRECIO")

        Me.LbMovInvTotalCosto.Text = FormatNumber(varTotalCosto, 2)
        Me.LbMovInvTotalPrecio.Text = FormatNumber(varTotalPrecio, 2)

    End Sub

    Private Sub ActualizarCorrTras()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("UPDATE TIPODOCUMENTOS SET CORRELATIVO=" & (Double.Parse(Me.txtMovInvCorrelativo.Text) + 1) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & Me.cmbSerieMovInv.SelectedValue.ToString & "'", cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        End Using

        'cn.Close()
    End Sub

    Private Function DatosProductoTRas(ByVal CodProducto As String) As Boolean 'OBTIENE LOS DATOS DEL CÓDIGO DE PRODUCTO SELECCIONADO

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

                        VentasCorrelativo = Double.Parse(Me.txtMovInvCorrelativo.Text)
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

End Class
