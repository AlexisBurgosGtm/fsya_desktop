Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewVentasCantidad

    Sub New(ByVal _ModoPos As Boolean, Optional _descuentaStock As Boolean = True, Optional _Bodega As Integer = 1)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ModoPOS = _ModoPos
        Bodega = _Bodega
        descuentaStock = _descuentaStock

    End Sub

    Dim ModoPOS As Boolean
    Dim Bodega As Integer
    Dim descuentaStock As Boolean
    Dim totalvend As Double

    Public Function Totalvendido()

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT  COUNT      (ISNULL (DOCPRODUCTOS.DESPROD, 0)) AS TOTALDOCUMENTOS
                                        FROM            DOCPRODUCTOS LEFT OUTER JOIN
                                                    DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO
                                        WHERE        (DOCUMENTOS.DOC_NIT = @NIT) AND (DOCPRODUCTOS.CODPROD = '3874')", cn)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@V", codempleado)
                cmd.Parameters.AddWithValue("@NIT", nitclien)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then

                    totalvend = dr(0)


                End If
                'MsgBox(nitclien.ToString)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Return r

    End Function

    <STAThread()>
    Private Sub viewVentasCantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Call Totalvendido()
        'MsgBox(totalvend.ToString)


        'VERIFICA SI EL SWITCH ESTÁ ACTIVADO PARA PERMITIR
        'DECIMALES EN CANTIDADES
        If Form1.SwitchConfigModoPOS.IsOn = False Then
            Me.txtUCCantidad.Properties.Mask.EditMask = "n0"
        End If
        'verifica si permite descuento o no
        If Form1.SwitchConfigInternet.IsOn = True Then
            'Me.txtDescuento.Enabled = True
        Else
            'Me.txtDescuento.Enabled = False
        End If


        If VentasNoSerie <> "" Then
        Else
            VentasNoSerie = "SN"
        End If


        Me.lbNoSerie.Text = VentasNoSerie

        Me.LbPrecioUnitarioCantidad.Text = "Precio Medida: "
        Me.txtUCPrecio.Enabled = False

        Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
        Me.txtUCTotal.Text = FormatNumber(VentasPrecioProducto, 2)


        'permite editar el precio si es nivel  1
        If NivelUsuario = 1 Then Me.txtUCPrecio.Enabled = True


        Me.lbUCDesProducto.Text = VentasDesProducto
        Me.txtUCCantidad.Text = 1


        Me.lbExistenciaProducto.Text = VentasExistencia.ToString

        Select Case VentasExistencia
            Case 0
                Me.lbExistenciaProducto.ForeColor = Color.Gray
            Case > 0
                Me.lbExistenciaProducto.ForeColor = Color.MediumSeaGreen
            Case < 0
                Me.lbExistenciaProducto.ForeColor = Color.OrangeRed
        End Select


        'Call MostrarPintarColorExistencias()

        Call CargarMedidas()



        If SelectedForm = "VENTAS" Or SelectedForm = "LISTADOS" Or SelectedForm = "EMBARQUES" Then
            If varConfigClienteModoPos = "SI" Then

                Me.cmbUCMedida.SelectedValue = 1

                'carga los costos de la medida
                Call CargarCostoPrecioMed()

                'pone el foco en la cantidad para que se dispare el evento leave focus
                Me.txtUCCantidad.select()

                'presiona el botón aceptar
                Me.cmdUCAceptar.PerformClick()
                Exit Sub

            End If

            '----------------------------------------


            If Form1.SwitchConfigModoCodigoVentas.IsOn = True Then

                'Me.cmbUCMedida.SelectedValue = 1

                'carga los costos de la medida
                'Call CargarCostoPrecioMed()

                'Me.txtUCCantidad.Text = GlobalVentasModoCodigoCantidad.ToString
                'Me.txtUCPrecio.Text = GlobalVentasModoCodigoPrecio.ToString

                'pone el foco en la cantidad para que se dispare el evento leave focus
                'Me.txtUCCantidad.select()

                'GlobalVentasModoCodigoCantidad = 0
                'GlobalVentasModoCodigoCodprod = ""
                'GlobalVentasModoCodigoPrecio = 0
                'presiona el botón aceptar
                'Me.cmdUCAceptar.PerformClick()
                'Exit Sub
            End If
            '----------------------------------------

        End If
        If Me.lbUCDesProducto.Text = "TARJETA KEEP HEALTHY (ASISTENCIA MEDICA CON MEDICAMENTOS)" Then
            If totalvend = 0 Then

                Me.txtDescuento.Text = (Double.Parse(Me.txtUCTotal.Text) / 2).ToString
            Else

                Me.txtDescuento.Text = "0"
            End If
        Else
            Me.txtDescuento.Text = "0"
        End If


        Me.cmbUCMedida.SelectedValue = VentasEquivale
        Me.cmbUCMedida.Text = VentasCodMedida
        Me.cmbUCMedida.select()


    End Sub

    Private Sub txtUCCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCCantidad.Text <> "" Then

                'SI ESTOY VENDIENDO COMPARO LAS EXISTENCIAS
                If VerificarCantidad() = True Then
                    If ConfigVerificaExistencias = True Then
                        If Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                            Try
                                Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                            Catch ex As Exception
                            End Try
                            'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                            'revisar despues
                            If NivelUsuario = 1 Then
                                Me.txtUCPrecio.select()
                            Else
                                Me.cmdUCAceptar.select()
                            End If
                        Else
                            MessageBox.Show("Existencia menor a la cantidad solicitada")
                        End If
                    Else
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        ' Me.cmdUCAceptar.DialogResult = DialogResult.OK
                        If NivelUsuario = 1 Then
                            Me.txtUCPrecio.select()
                        Else
                            Me.cmdUCAceptar.select()
                        End If
                    End If
                End If



            End If
        End If
    End Sub

    Private Function VerificarCantidad() As Boolean
        If Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    'INSERTA EL ITEM EN LA TABLA TEMP O DOCPRODUCTOS

    Private Function InsertarProductoTemp() As Boolean

        Dim totalexentovalue As Double = Double.Parse(Me.txtUCTotal.Text) * VentasExento


        If fcn_CrearMovimientoInventario() = True Then

            Dim result As Boolean

            Try
                Using cn As New SqlConnection(strSqlConectionString)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If
                    Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas 
                (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,NOSERIE,USUARIO,EXENTO,OBS,PRECIOSINIVA,TOTALPRECIOSINIVA,DESCUENTO) 
                VALUES 
                (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@NOSERIE,@USUARIO,@EXENTO,@OBS,@PRECIOSINIVA,@TOTALPRECIOSINIVA,@DESCUENTO)", cn)

                    cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@EXENTO", totalexentovalue)
                    cmd.Parameters.AddWithValue("@OBS", Me.txtObs.Text)

                    'si el iva del producto es cero, se deja en cero (exento)
                    Dim TOTALIVA As Double = 0
                    If VentasIvaProducto > 0 Then
                        Dim totalsiniva As Double = (Double.Parse(Me.txtUCTotal.Text) / VentasIvaProducto)
                        TOTALIVA = Double.Parse(Me.txtUCTotal.Text) - totalsiniva
                    End If
                    cmd.Parameters.AddWithValue("@PRECIOSINIVA", TOTALIVA) 'TOTAL IVA
                    cmd.Parameters.AddWithValue("@TOTALPRECIOSINIVA", Double.Parse(Me.txtUCTotal.Text) - TOTALIVA) 'TOTAL PRECIO SIN IVA

                    'VERIFICO QUE SEA UNA COMPRA O UNA VENTA

                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                    cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@BONIF", 0)
                    cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    cmd.Parameters.AddWithValue("@NOSERIE", VentasNoSerie)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", VentasCorrelativo)
                    cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)
                    cmd.Parameters.AddWithValue("@DESPROD", VentasDesProducto)
                    cmd.Parameters.AddWithValue("@CODMEDIDA", VentasCodMedida)
                    cmd.Parameters.AddWithValue("@EQUIVALE", VentasEquivale)
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")))
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@DESCUENTO", Double.Parse(Me.txtDescuento.Text.Replace(",", "")))

                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    result = True
                End Using
            Catch ex As Exception
                MsgBox("INSERT TEMP: " & ex.ToString)
                GlobalDesError = ex.ToString
                result = False
            End Try





            'VERIFICO QUE SEA UNA COMPRA O UNA VENTA

            'If SelectedForm = "VENTAS" Then
            'If Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) > Double.Parse(Me.lbExistenciaProducto.Text) Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
            'Form1.txtVentasCodProd.Text = ""
            'Form1.txtVentasCodProd.select()
            'End If


            Return result

        Else
            MsgBox("Lo lamento, no pude realizar el descuento del Stock, inténtalo de nuevo !! (Lo más seguro es que perdiste conexión al servidor)")
            Return False

        End If


    End Function


    Private Function InsertarProductoEdicionFactura() As Boolean

        Dim totalexentovalue As Double = Double.Parse(Me.txtUCTotal.Text) * VentasExento

        If fcn_CrearMovimientoInventario() = True Then

            Dim result As Boolean

            Try
                Using cn As New SqlConnection(strSqlConectionString)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim qry As String = "INSERT INTO DOCPRODUCTOS 
                (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,
				    ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF,NOSERIE,EXENTO,OBS,TOTALIVA,TOTALSINIVA,DESCUENTO)
                    VALUES
                (@EMPNIT,@ANIO,@MES,@DIA,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@CANTIDAD,@EQUIVALE,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@ENTREGADOS_TOTALUNIDADES,
				    @ENTREGADOS_TOTALCOSTO,@ENTREGADOS_TOTALPRECIO,@COSTOANTERIOR,@COSTOPROMEDIO,@CANTIDADBONIF,@TOTALBONIF,@NOSERIE,@EXENTO,@OBS,@PRECIOSINIVA,@TOTALPRECIOSINIVA,@DESCUENTO)"

                    Dim cmd As New SqlCommand(qry, cn)

                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@ANIO", GlobalSelected_FechaDocumento.Year)
                    cmd.Parameters.AddWithValue("@MES", GlobalSelected_FechaDocumento.Month)
                    cmd.Parameters.AddWithValue("@DIA", GlobalSelected_FechaDocumento.Day)
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalSelected_Coddoc)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", GlobalSelected_Correlativo)
                    cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)
                    cmd.Parameters.AddWithValue("@DESPROD", VentasDesProducto)
                    cmd.Parameters.AddWithValue("@CODMEDIDA", VentasCodMedida)
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")))
                    cmd.Parameters.AddWithValue("@EQUIVALE", VentasEquivale)
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                    cmd.Parameters.AddWithValue("@COSTOANTERIOR", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@COSTOPROMEDIO", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@CANTIDADBONIF", 0)
                    cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    cmd.Parameters.AddWithValue("@NOSERIE", VentasNoSerie)
                    cmd.Parameters.AddWithValue("@EXENTO", totalexentovalue)
                    cmd.Parameters.AddWithValue("@OBS", Me.txtObs.Text)
                    'si el iva del producto es cero, se deja en cero (exento)
                    Dim TOTALIVA As Double = 0
                    If VentasIvaProducto > 0 Then
                        Dim totalsiniva As Double = (Double.Parse(Me.txtUCTotal.Text) / VentasIvaProducto)
                        TOTALIVA = Double.Parse(Me.txtUCTotal.Text) - totalsiniva
                    End If
                    cmd.Parameters.AddWithValue("@PRECIOSINIVA", TOTALIVA) 'TOTAL IVA
                    cmd.Parameters.AddWithValue("@TOTALPRECIOSINIVA", Double.Parse(Me.txtUCTotal.Text) - TOTALIVA) 'TOTAL PRECIO SIN IVA
                    cmd.Parameters.AddWithValue("@DESCUENTO", Double.Parse(Me.txtDescuento.Text.Replace(",", "")))


                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    result = True

                End Using
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            Return result

        Else
            MsgBox("Lo lamento, no pude realizar el descuento del Stock, inténtalo de nuevo !! (Lo más seguro es que perdiste conexión al servidor)")
            Return False

        End If

    End Function



    Dim AJUSTE As Double

    Dim objInventario As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

    Private Function fcn_CrearMovimientoInventario() As Boolean

        Try

            Call ObtenerDatosInventario(VentasCodProducto, VentasAnio, VentasMes)

            Select Case SelectedForm

                Case "COTIZACIONES" 'SI ES UNA VENTA CREO UNA SALIDA DE INVENTARIO 


                    If VentasNoSerie = "SN" Then
                    Else
                        Dim objSeries As New classSeries
                        If objSeries.Update_SerieStatus(GlobalEmpNit, VentasCodProducto, VentasNoSerie, 1) = True Then
                        End If
                    End If


                Case Else
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasEquivale)) = True Then
                    End If
                    If VentasNoSerie = "SN" Then
                    Else
                        Dim objSeries As New classSeries
                        If objSeries.Update_SerieStatus(GlobalEmpNit, VentasCodProducto, VentasNoSerie, 1) = True Then
                        End If
                    End If

            End Select

            Return True

        Catch ex As Exception
            MsgBox("Error al crear el movimiento de inventario: " & ex.ToString)
            Return False

        End Try
    End Function


    Private Sub txtUCCantidad_Leave(sender As Object, e As EventArgs) Handles txtUCCantidad.Leave
        Call VerificarCantidadVacios()

    End Sub

    Private Sub VerificarCantidadVacios()

        If Me.txtUCCantidad.Text <> "" Then

            Select Case SelectedForm
                Case "COTIZACIONES"
                    'SI ESTOY COTIZANDO 

                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    ' Me.cmdUCAceptar.DialogResult = DialogResult.OK
                    If NivelUsuario = 1 Then
                        Me.txtUCPrecio.select()
                    Else
                        Me.cmdUCAceptar.select()
                    End If

                Case Else
                    'SI ESTOY VENDIENDO COMPARO LAS EXISTENCIAS
                    If VerificarCantidad() = True Then
                        If ConfigVerificaExistencias = True Then
                            If Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                                Try
                                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                                Catch ex As Exception
                                End Try
                                'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                                'revisar despues
                                If NivelUsuario = 1 Then
                                    Me.txtUCPrecio.select()
                                Else
                                    Me.cmdUCAceptar.select()
                                End If
                            Else
                                MessageBox.Show("Existencia menor a la cantidad solicitada")
                            End If
                        Else
                            Try
                                Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                            Catch ex As Exception
                            End Try
                            ' Me.cmdUCAceptar.DialogResult = DialogResult.OK
                            If NivelUsuario = 1 Then
                                Me.txtUCPrecio.select()
                            Else
                                Me.cmdUCAceptar.select()
                            End If
                        End If
                    End If


            End Select
        End If
    End Sub

    'Private Sub MostrarPintarColorExistencias()
    'If NivelUsuario = 1 Then
    'si es administrador no hay problema
    'End If
    'If NivelUsuario = 2 Then
    'If Form1.SwitchPermisoSup18.IsOn = True Then
    'Me.lbExistenciaProducto.ForeColor = Color.White
    'Me.lbExistenciaProducto.BackColor = Color.White
    'End If
    'End If
    'If NivelUsuario = 3 Then
    'If Form1.SwitchPermisoOp18.IsOn = True Then
    'Me.lbExistenciaProducto.ForeColor = Color.White
    'Me.lbExistenciaProducto.BackColor = Color.White
    'End If
    'End If
    'If NivelUsuario = 4 Then
    'If Form1.SwitchPermisoN418.IsOn = True Then
    'Me.lbExistenciaProducto.ForeColor = Color.White
    'Me.lbExistenciaProducto.BackColor = Color.White
    'End If
    'End If
    'If NivelUsuario = 5 Then
    'If Form1.SwitchPermisoN518.IsOn = True Then
    'Me.lbExistenciaProducto.ForeColor = Color.White
    'Me.lbExistenciaProducto.BackColor = Color.White
    'End If
    'End If
    'If NivelUsuario = 6 Then
    'If Form1.SwitchPermisoN618.IsOn = True Then
    'Me.lbExistenciaProducto.ForeColor = Color.White
    'Me.lbExistenciaProducto.BackColor = Color.White
    'End If
    'End If
    'End Sub



    Private Sub txtUCPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCPrecio.Text <> "" Then

                If Double.Parse(Me.txtUCPrecio.Text) > 0 Then

                    If VentasCostoProducto >= Double.Parse(Me.txtUCPrecio.Text) Then
                        If SelectedForm = "VENTAS" Or SelectedForm = "ENVIOS" Or SelectedForm = "LISTADOS" Or SelectedForm = "EMBARQUES" Then

                            MsgBox("Precio menor o igual que el Costo, por favor rectifique")

                            Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto)

                            Exit Sub
                        End If
                    End If


                    Try
                        Dim cantidad As Double = Double.Parse(Me.txtUCCantidad.Text.Replace(",", ""))
                        Dim precio As Double = Double.Parse(Me.txtUCPrecio.Text)

                        Me.txtUCTotal.Text = FormatNumber((cantidad * precio), 2)

                    Catch ex As Exception
                    End Try

                    'Me.cmdUCAceptar.DialogResult = DialogResult.OK


                    If Me.txtDescuento.Enabled = True Then
                        Me.txtDescuento.select()
                    Else
                        Me.cmdUCAceptar.select()
                    End If

                End If
            End If
        End If
    End Sub

    Private Sub cmbUCMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUCMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.cmbUCMedida.Text <> "" Then
                Call CargarCostoPrecioMed()
                Me.txtUCCantidad.select()
            Else
                Me.cmbUCMedida.SelectedIndex = 0
                Call CargarCostoPrecioMed()
                Me.txtUCCantidad.select()
            End If

        End If
    End Sub

    Private Sub CargarMedidas()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT CODMEDIDA,EQUIVALE FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & VentasCodProducto & "'", cn)
            Dim Dt As DataTable
            Dim Da As New SqlDataAdapter
            Da.SelectCommand = cmd
            Dt = New DataTable
            Da.Fill(Dt)

            With cmbUCMedida
                .DataSource = Dt
                .DisplayMember = "CODMEDIDA"
                .ValueMember = "EQUIVALE"
            End With
            cmd.Dispose()
            'cn.Close()
        End Using

    End Sub

    Private Sub CargarCostoPrecioMed()
        Call AbrirConexionSql()

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            'DETERMINA EL TIPO DE PRECIO SEGÚN CLIENTE
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

            Dim cmd As New SqlCommand("SELECT COSTO," & tipoprecio & " FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & VentasCodProducto & "' AND CODMEDIDA='" & Me.cmbUCMedida.Text & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    VentasEquivale = Integer.Parse(Me.cmbUCMedida.SelectedValue)
                    VentasCodMedida = Me.cmbUCMedida.Text

                    VentasCostoProducto = Double.Parse(dr(0))
                    VentasPrecioProducto = Double.Parse(dr(1))
                    Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                    Me.txtUCTotal.Text = FormatNumber((VentasPrecioProducto * Double.Parse(Me.txtUCCantidad.Text.Replace(",", ""))), 2)
                End If
            Catch ex As Exception
            End Try
            cmd.Dispose()

        End Using

    End Sub


    Private Sub cmdUCAceptar_Click_1(sender As Object, e As EventArgs) Handles cmdUCAceptar.Click

        If Me.txtDescuento.Text <> "" Then
        Else
            Me.txtDescuento.Text = "0"
        End If

        Call VerificarCantidadVacios()

        If ConfigVerificaExistencias = True Then

            If SelectedForm = "VENTAS" Or SelectedForm = "LISTADOS" Or SelectedForm = "EMBARQUES" Then
                If Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * VentasEquivale <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                    GoTo Terminar
                Else

                    If descuentaStock = False Then
                        GoTo Terminar
                    End If
                    MessageBox.Show("Existencia menor a la cantidad solicitada")
                    Exit Sub

                End If
            Else
                GoTo Terminar
            End If

        Else
            GoTo Terminar
        End If


Terminar:
        '***********************************************************
        If Me.txtUCCantidad.Text <> "" Then
            If Me.txtObs.Text <> "" Then
            Else
                Me.txtObs.Text = "SN"
            End If
            'verifica que todo esté lleno
            If Me.cmbUCMedida.SelectedIndex >= 0 Then
            Else
                Me.cmbUCMedida.SelectedIndex = 0
            End If
            If Me.txtUCCantidad.Text <> "" Then
            Else
                Me.txtUCCantidad.Text = 1
            End If

            If Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) > 0 Then

                If SelectedForm = "VENTAS" Or SelectedForm = "COTIZACIONES" Then
                    'ESTA INSERTANDO DATOS
                    If InsertarProductoTemp() = True Then
                        Call CargarGridTempVentas()
                        Me.btnAceptarTrue.PerformClick()
                    Else
                        MsgBox("Lo siento, No se pudo agregar este producto.. inténtalo de nuevo!! (Seguramente el servidor no me permitió conectarme). " & GlobalDesError)
                    End If

                Else
                    'ESTA EDITANDO DATOS
                    If InsertarProductoEdicionFactura() = True Then
                        'Call CargarGridTempVentas()
                        Me.btnAceptarTrue.PerformClick()
                    Else
                        MsgBox("Lo siento, No se pudo agregar este producto.. inténtalo de nuevo!! (Seguramente el servidor no me permitió conectarme). " & GlobalDesError)
                    End If

                End If


            End If

        End If
    End Sub




    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdUCAceptar.select()
        End If
    End Sub


    Private Sub txtDescuento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescuento.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdUCAceptar.select()
        End If
    End Sub

    Private Sub txtDescuento_Leave(sender As Object, e As EventArgs) Handles txtDescuento.Leave

        If Me.txtDescuento.Text <> "" Then
        Else
            Me.txtDescuento.Text = "0"
        End If

        Dim totcostoprod As Double = VentasCostoProducto
        Dim totalcosto As Double = Double.Parse(Me.txtUCCantidad.Text.Replace(",", "")) * totcostoprod
        Dim totalpagar As Double = 0

        Try
            Dim cantidad As Double = Double.Parse(Me.txtUCCantidad.Text.Replace(",", ""))
            Dim precio As Double = Double.Parse(Me.txtUCPrecio.Text.Replace(",", ""))
            Dim descuento As Double = Double.Parse(Me.txtDescuento.Text.Replace(",", ""))


            Me.txtAPagar.Text = FormatNumber((cantidad * precio) - descuento, 2)

            totalpagar = (cantidad * precio) - descuento

        Catch ex As Exception
            Me.txtAPagar.Text = Me.txtUCTotal.Text
        End Try



        If totalcosto > Double.Parse(Me.txtAPagar.Text) Then
            MsgBox("Total con descuento menor al costo. Por favor verifique")
            Me.txtDescuento.select()
        End If


    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaOperador.Text)) = DialogResult.OK Then
            Me.txtDescuento.Enabled = True
            Me.txtDescuento.select()

        End If
    End Sub

    Private Sub txtUCPrecio_Leave(sender As Object, e As EventArgs) Handles txtUCPrecio.Leave
        If VentasCostoProducto > Double.Parse(Me.txtUCPrecio.Text) Then
            MsgBox("Total con descuento menor al costo. Por favor verifique")
            Me.txtDescuento.select()
        End If

    End Sub

    Private Sub txtDescuento_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged

    End Sub

    Private Sub GroupControl2_Paint(sender As Object, e As PaintEventArgs) Handles GroupControl2.Paint

    End Sub
End Class
