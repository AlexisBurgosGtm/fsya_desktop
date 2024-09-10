Imports System.Data.SqlClient
Imports Ares.Form1
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class UserControl_VentaCantidad


    Sub New(ByVal _ModoPos As Boolean, ByVal _tipoprecio As String, Optional _Bodega As Integer = 1)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ModoPOS = _ModoPos
        Bodega = _Bodega
        TipoPrecio = _tipoprecio

    End Sub

    Dim ModoPOS As Boolean
    Dim Bodega As Integer
    Dim TipoPrecio As String

    <STAThread()>
    Private Sub UserControl_VentaCantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'VERIFICA SI EL SWITCH ESTÁ ACTIVADO PARA PERMITIR
        'DECIMALES EN CANTIDADES
        If Form1.SwitchConfigModoPOS.IsOn = False Then
            Me.txtUCCantidad.Properties.Mask.EditMask = "n0"
            Me.txtUCBonificacion.Properties.Mask.EditMask = "n0"
        End If

        Me.lbCodBodega.Text = Bodega.ToString

        If VentasNoSerie <> "" Then
        Else
            VentasNoSerie = "SN"
        End If

        'DEPENDIENDO DEL FORMULARIO DEL QUE SE LLAME, HABILITO O DESHABILITO EL PRECIO
        Select Case SelectedForm
            Case "VENTAS"

                Me.lbNoSerie.Text = VentasNoSerie

                Me.LbPrecioUnitarioCantidad.Text = "Precio Medida:"
                Me.txtUCPrecio.Enabled = False

                Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasPrecioProducto, 2)

                'la bonificación es invisible en ventas
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                'permite editar el precio si es nivel  1
                If NivelUsuario = 1 Then Me.txtUCPrecio.Enabled = True
                Me.btnDescuento.Visible = True

            Case "LISTADOS"
                Me.lbNoSerie.Text = VentasNoSerie

                Me.LbPrecioUnitarioCantidad.Text = "Precio Medida:"
                Me.txtUCPrecio.Enabled = False

                Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasPrecioProducto, 2)

                'la bonificación es invisible en ventas
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                'permite editar el precio si es nivel 2 o 1
                If NivelUsuario = 1 Then Me.txtUCPrecio.Enabled = True
                Me.btnDescuento.Visible = True


            Case "ENVIOS"
                If NivelUsuario = 1 Then
                Else
                    Me.lbExistenciaProducto.ForeColor = Color.White
                    Me.lbExistenciaProducto.BackColor = Color.White
                End If

                Me.LbPrecioUnitarioCantidad.Text = "Precio Medida:"
                Me.txtUCPrecio.Enabled = False

                Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasPrecioProducto, 2)

                'la bonificación es invisible en ventas
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                'permite editar el precio si es nivel 2 o 1
                If NivelUsuario = 1 Then Me.txtUCPrecio.Enabled = True
                Me.btnDescuento.Visible = True

            Case "COTIZACIONES"
                Me.LbPrecioUnitarioCantidad.Text = "Precio Medida:"
                Me.txtUCPrecio.Enabled = False

                Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasPrecioProducto, 2)

                'la bonificación es invisible en ventas
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                'permite editar el precio si es nivel 2 o 1
                If NivelUsuario = 1 Then Me.txtUCPrecio.Enabled = True
                Me.btnDescuento.Visible = True

            Case "COMPRAS"
                Me.lbTituloObs.Text = "No. Lote:"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'la bonificación es visible en compras
                Me.LbBonif.Visible = True
                Me.txtUCBonificacion.Visible = True

            Case "ORDENCOMPRA"
                Me.lbTituloObs.Text = "No. Lote:"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'la bonificación es visible en compras
                Me.LbBonif.Visible = True
                Me.txtUCBonificacion.Visible = True

            Case "INGINV"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False

            Case "SALINV"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False

            Case "TRASENT"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False

            Case "TRASSAL"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False

            Case "TRASENTSUC"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False

            Case "TRASSALSUC"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False
            Case "TRASSALVENC"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False


            Case "INVFISICO"
                Me.lbCantidad.Text = "Conteo:"
                Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
                Me.txtUCPrecio.Enabled = True

                Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

                'pongo invisibles todos los controles irrelevantes
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                Me.txtUCPrecio.Visible = False
                Me.txtUCTotal.Visible = False
                Me.LbPrecioUnitarioCantidad.Visible = False
                Me.LabelControl4.Visible = False
                Me.LabelControl7.Visible = False
                Me.LabelControl8.Visible = False


        End Select


        Me.lbUCDesProducto.Text = VentasDesProducto
        Me.txtUCCantidad.Text = 1
        Me.txtUCBonificacion.Text = 0

        Me.lbExistenciaProducto.Text = VentasExistencia.ToString

        Select Case VentasExistencia
            Case 0
                Me.lbExistenciaProducto.ForeColor = Color.Gray
            Case > 0
                Me.lbExistenciaProducto.ForeColor = Color.MediumSeaGreen
            Case < 0
                Me.lbExistenciaProducto.ForeColor = Color.OrangeRed
        End Select


        Call MostrarPintarColorExistencias()

        Call CargarMedidas()



        If SelectedForm = "VENTAS" Then
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
                Me.cmbUCMedida.SelectedValue = 1

                'carga los costos de la medida
                Call CargarCostoPrecioMed()

                Me.txtUCCantidad.Text = GlobalVentasModoCodigoCantidad.ToString
                Me.txtUCPrecio.Text = GlobalVentasModoCodigoPrecio.ToString

                'pone el foco en la cantidad para que se dispare el evento leave focus
                Me.txtUCCantidad.select()

                GlobalVentasModoCodigoCantidad = 0
                GlobalVentasModoCodigoCodprod = ""
                GlobalVentasModoCodigoPrecio = 0
                'presiona el botón aceptar
                Me.cmdUCAceptar.PerformClick()
                Exit Sub
            End If
            '----------------------------------------

        End If


        Me.cmbUCMedida.SelectedValue = VentasEquivale
        Me.cmbUCMedida.Text = VentasCodMedida
        Me.cmbUCMedida.select()


    End Sub



    Private Sub txtUCCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCCantidad.Text <> "" Then
                Select Case SelectedForm
                    Case "VENTAS"
                        'SI ESTOY VENDIENDO COMPARO LAS EXISTENCIAS
                        If VerificarCantidad() = True Then
                            If ConfigVerificaExistencias = True Then
                                If Double.Parse(Me.txtUCCantidad.Text) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                                    Try
                                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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
                                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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
                    Case "LISTADOS"
                        'SI ESTOY ACTUALIZANDO UNA FACTURA COMPARO LAS EXISTENCIAS
                        If VerificarCantidad() = True Then
                            If ConfigVerificaExistencias = True Then
                                If Double.Parse(Me.txtUCCantidad.Text) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                                    Try
                                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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
                                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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

                    Case "ENVIOS"
                        'SI ESTOY HACIENDO PEDIDOS O ENVIOS
                        If VerificarCantidad() = True Then
                            If ConfigVerificaExistencias = True Then
                                If Double.Parse(Me.txtUCCantidad.Text) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                                    Try
                                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                                    Catch ex As Exception
                                    End Try
                                    'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                                    Me.cmdUCAceptar.select()
                                Else
                                    MessageBox.Show("Existencia menor a la cantidad solicitada")
                                End If
                            Else
                                Try
                                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                                Catch ex As Exception
                                End Try
                                'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                                'revisar despues
                                If NivelUsuario = 1 Then
                                    Me.txtUCPrecio.select()
                                Else
                                    Me.cmdUCAceptar.select()
                                End If
                            End If
                        End If
                    Case "COTIZACIONES"
                        'SI ESTOY HACIENDO COTIZACIONES
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                        'revisar despues
                        If NivelUsuario = 1 Then
                            Me.txtUCPrecio.select()
                        Else
                            Me.cmdUCAceptar.select()
                        End If

                    Case "COMPRAS"
                        'SI ESTOY COMPRANDO NO COMPARO NADA
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.txtUCBonificacion.select()
                    'Me.txtUCPrecio.select()
                    Case "ORDENCOMPRA"
                        'SI ESTOY COMPRANDO NO COMPARO NADA
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.txtUCBonificacion.select()

                    Case "INGINV"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()
                    Case "SALINV"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()
                    Case "TRASSAL"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()
                    Case "TRASENT"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()

                    Case "TRASSALSUC"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()
                    Case "TRASSALVENC"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()
                    Case "TRASENTSUC"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()

                    Case "INVFISICO"
                        Try
                            Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                        Catch ex As Exception
                        End Try
                        Me.cmdUCAceptar.select()
                End Select
            End If
        End If
    End Sub

    Private Function VerificarCantidad() As Boolean
        If Double.Parse(Me.txtUCCantidad.Text) > 0 Then
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
                (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,NOSERIE,USUARIO,EXENTO,OBS,PRECIOSINIVA,TOTALPRECIOSINIVA) 
                VALUES 
                (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@NOSERIE,@USUARIO,@EXENTO,@OBS,@PRECIOSINIVA,@TOTALPRECIOSINIVA)", cn)

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
                    If SelectedForm = "ENVIOS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
                        cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)

                    End If
                    If SelectedForm = "VENTAS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
                        cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)
                    End If
                    If SelectedForm = "COTIZACIONES" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
                        cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)

                    End If
                    If SelectedForm = "LISTADOS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                        cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
                        cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)
                    End If

                    If SelectedForm = "COMPRAS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOMPRA)
                        cmd.Parameters.AddWithValue("@PRECIO", VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtUCPrecio.Text))
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", (Double.Parse(Me.txtUCCantidad.Text) * VentasPrecioProducto))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text))
                        cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
                        cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)
                    End If
                    If SelectedForm = "ORDENCOMPRA" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocORDENCOMPRA)
                        cmd.Parameters.AddWithValue("@PRECIO", VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtUCPrecio.Text))
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", (Double.Parse(Me.txtUCCantidad.Text) * VentasPrecioProducto))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text))
                        cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
                        cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)
                    End If

                    cmd.Parameters.AddWithValue("@NOSERIE", VentasNoSerie)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", VentasCorrelativo)
                    cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)
                    cmd.Parameters.AddWithValue("@DESPROD", VentasDesProducto)
                    cmd.Parameters.AddWithValue("@CODMEDIDA", VentasCodMedida)
                    cmd.Parameters.AddWithValue("@EQUIVALE", VentasEquivale)
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text))
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale))
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
            If SelectedForm = "ENVIOS" Then
                'If Double.Parse(Me.txtUCCantidad.Text) > Double.Parse(Me.lbExistenciaProducto.Text) Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
                Form1.txtVentasCodProd.Text = ""
                Form1.txtVentasCodProd.select()
            End If
            If SelectedForm = "VENTAS" Then
                'If Double.Parse(Me.txtUCCantidad.Text) > Double.Parse(Me.lbExistenciaProducto.Text) Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
                Form1.txtVentasCodProd.Text = ""
                Form1.txtVentasCodProd.select()
            End If
            If SelectedForm = "COTIZACIONES" Then
                Form1.txtVentasCodProd.Text = ""
                Form1.txtVentasCodProd.select()
            End If
            If SelectedForm = "LISTADOS" Then
                Form1.txtVentasCodProd.Text = ""
                Form1.txtVentasCodProd.select()
            End If

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
				    ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF,NOSERIE,EXENTO,OBS,TOTALIVA,TOTALSINIVA)
                    VALUES
                (@EMPNIT,@ANIO,@MES,@DIA,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@CANTIDAD,@EQUIVALE,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@ENTREGADOS_TOTALUNIDADES,
				    @ENTREGADOS_TOTALCOSTO,@ENTREGADOS_TOTALPRECIO,@COSTOANTERIOR,@COSTOPROMEDIO,@CANTIDADBONIF,@TOTALBONIF,@NOSERIE,@EXENTO,@OBS,@PRECIOSINIVA,@TOTALPRECIOSINIVA)"

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
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text))
                    cmd.Parameters.AddWithValue("@EQUIVALE", VentasEquivale)
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                    cmd.Parameters.AddWithValue("@COSTOANTERIOR", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@COSTOPROMEDIO", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@CANTIDADBONIF", Double.Parse(Me.txtUCBonificacion.Text))
                    cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)
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

                Case "VENTAS" 'SI ES UNA VENTA CREO UNA SALIDA DE INVENTARIO 
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If
                    If VentasNoSerie = "SN" Then
                    Else
                        Dim objSeries As New classSeries
                        If objSeries.Update_SerieStatus(GlobalEmpNit, VentasCodProducto, VentasNoSerie, 1) = True Then
                        End If
                    End If

                Case "ENVIOS" 'SI SON PEDIDOS ACTUAN COMO LAS VENTAS
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If

                Case "LISTADOS"
                    'If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    'End If

                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If
                    If VentasNoSerie = "SN" Then
                    Else
                        Dim objSeries As New classSeries
                        If objSeries.Update_SerieStatus(GlobalEmpNit, VentasCodProducto, VentasNoSerie, 1) = True Then
                        End If
                    End If


                Case "INGINV"
                    If objInventario.fcn_InsertarEntradaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If

                Case "SALINV"
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If

                Case "TRASENT"
                    If objInventario.fcn_InsertarEntradaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If

                Case "TRASSAL"
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If
                Case "TRASENTSUC"
                    If objInventario.fcn_InsertarEntradaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If

                Case "TRASSALSUC"
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If
                Case "TRASSALVENC"
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If
                Case "COMPRAS"
                    'comparo la casilla de bonif para ponerla a cero si no tuviera nada o si estuviera en negativo
                    If Me.txtUCBonificacion.Text <> "" Then
                    Else
                        Me.txtUCBonificacion.Text = 0
                    End If
                    If Double.Parse(Me.txtUCBonificacion.Text) > 0 Then
                    Else
                        Me.txtUCBonificacion.Text = 0
                    End If

                    Dim TotalUnidadesCompra As Double
                    TotalUnidadesCompra = ((Double.Parse(Me.txtUCCantidad.Text) + Double.Parse(Me.txtUCBonificacion.Text)) * VentasEquivale)

                    If objInventario.fcn_InsertarEntradaProducto(VentasCodProducto, TotalUnidadesCompra) = True Then
                    End If
                Case "ORDENCOMPRA"
                    'comparo la casilla de bonif para ponerla a cero si no tuviera nada o si estuviera en negativo
                    If Me.txtUCBonificacion.Text <> "" Then
                    Else
                        Me.txtUCBonificacion.Text = 0
                    End If
                    If Double.Parse(Me.txtUCBonificacion.Text) > 0 Then
                    Else
                        Me.txtUCBonificacion.Text = 0
                    End If

                    Dim TotalUnidadesCompra As Double
                    TotalUnidadesCompra = ((Double.Parse(Me.txtUCCantidad.Text) + Double.Parse(Me.txtUCBonificacion.Text)) * VentasEquivale)

                    'AL SER ORDEN DE COMPRA NO AFECTA INVENTARIOS
                    'If objInventario.fcn_InsertarEntradaProducto(VentasCodProducto, TotalUnidadesCompra) = True Then
                    'End If

                Case "INVFISICO" 'INVENTARIO FISICO

                    AJUSTE = 0
                    'primero defino las unidades a ajustar, restando el saldo actual al total de unidades contadas
                    AJUSTE = (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale) - INVSaldo

                    'dependiendo de si el ajuste es positivo o negativo, decido si hacer una entrada o salida de inventario
                    If AJUSTE > 0 Then
                        If objInventario.fcn_InsertarEntradaProducto(VentasCodProducto, AJUSTE) = True Then
                        End If
                    Else
                        'por último, en background db, asigno la columna Bonif de DocProductos como inventario actual y TotalBonif como ajuste
                        If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, AJUSTE) = True Then
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
                Case "VENTAS"
                    'SI ESTOY VENDIENDO COMPARO LAS EXISTENCIAS
                    If VerificarCantidad() = True Then
                        If ConfigVerificaExistencias = True Then
                            If Double.Parse(Me.txtUCCantidad.Text) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                                Try
                                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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
                                Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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
                Case "LISTADOS"
                    'SI ESTOY ACTUALIZANDO UNA FACTURA COMPARO LAS EXISTENCIAS
                    If VerificarCantidad() = True Then
                        If ConfigVerificaExistencias = True Then
                            If Double.Parse(Me.txtUCCantidad.Text) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                                Try
                                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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
                                Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
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

                Case "ENVIOS"
                    'SI ESTOY HACIENDO PEDIDOS O ENVIOS
                    If VerificarCantidad() = True Then
                        If ConfigVerificaExistencias = True Then
                            If Double.Parse(Me.txtUCCantidad.Text) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                                Try
                                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                                Catch ex As Exception
                                End Try
                                'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                                Me.cmdUCAceptar.select()
                            Else
                                MessageBox.Show("Existencia menor a la cantidad solicitada")
                            End If
                        Else
                            Try
                                Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                            Catch ex As Exception
                            End Try
                            'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                            'revisar despues
                            If NivelUsuario = 1 Then
                                Me.txtUCPrecio.select()
                            Else
                                Me.cmdUCAceptar.select()
                            End If
                        End If
                    End If
                Case "COTIZACIONES"
                    'SI ESTOY HACIENDO COTIZACIONES
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                    'revisar despues
                    If NivelUsuario = 1 Then
                        Me.txtUCPrecio.select()
                    Else
                        Me.cmdUCAceptar.select()
                    End If

                Case "COMPRAS"
                    'SI ESTOY COMPRANDO NO COMPARO NADA
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.txtUCBonificacion.select()
                'Me.txtUCPrecio.select()

                Case "ORDENCOMPRA"
                    'SI ESTOY COMPRANDO NO COMPARO NADA
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.txtUCBonificacion.select()
                'Me.txtUCPrecio.select()

                Case "INGINV"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()
                Case "SALINV"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()
                Case "TRASENT"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()
                Case "TRASSAL"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()

                Case "TRASENTSUC"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()
                Case "TRASSALSUC"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()
                Case "TRASSALVENC"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()

                Case "INVFISICO"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()
            End Select
        End If
    End Sub

    Private Sub MostrarPintarColorExistencias()

        Me.lbExistenciaProducto.ForeColor = Color.White
            Me.lbExistenciaProducto.BackColor = Color.White

    End Sub


    Private Sub txtUCPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCPrecio.Text <> "" Then

                If Double.Parse(Me.txtUCPrecio.Text) > 0 Then

                    If VentasCostoProducto >= Double.Parse(Me.txtUCPrecio.Text) Then
                        If SelectedForm = "VENTAS" Or SelectedForm = "ENVIOS" Or SelectedForm = "LISTADOS" Then

                            MsgBox("Precio menor o igual que el Costo, por favor rectifique")

                            Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto)

                            Exit Sub
                        End If
                    End If


                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try

                    'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                    Me.cmdUCAceptar.select()

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
            'Dim tipoprecio As String

            Select Case TipoPrecio 'Form1.lbVentasTipoPrecio.Text
                Case "PUBLICO"
                    TipoPrecio = "PRECIOS.PRECIO"
                Case "MAYOREO A"
                    TipoPrecio = "PRECIOS.MAYOREOA"
                Case "MAYOREO B"
                    TipoPrecio = "PRECIOS.MAYOREOB"
                Case "MAYOREO C"
                    TipoPrecio = "PRECIOS.MAYOREOC"
                Case Else
                    TipoPrecio = "PRECIOS.PRECIO"

            End Select

            Dim cmd As New SqlCommand("SELECT COSTO," & tipoprecio & " FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & VentasCodProducto & "' AND CODMEDIDA='" & Me.cmbUCMedida.Text & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    VentasEquivale = Integer.Parse(Me.cmbUCMedida.SelectedValue)
                    VentasCodMedida = Me.cmbUCMedida.Text
                    Select Case SelectedForm
                        Case "COMPRAS"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "ORDENCOMPRA"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "VENTAS"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasPrecioProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "LISTADOS"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasPrecioProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "ENVIOS"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasPrecioProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "COTIZACIONES"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasPrecioProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "INGINV"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "SALINV"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "TRASENT"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "TRASSAL"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "TRASENTSUC"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "TRASSALSUC"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "TRASSALVENC"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                        Case "INVFISICO"
                            VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))
                            Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                            Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
                    End Select
                End If
            Catch ex As Exception
            End Try
            cmd.Dispose()
            'cn.Close()

        End Using

    End Sub


    Private Sub cmdUCAceptar_Click_1(sender As Object, e As EventArgs) Handles cmdUCAceptar.Click

        Call VerificarCantidadVacios()

        If ConfigVerificaExistencias = True Then

            If SelectedForm = "VENTAS" Or SelectedForm = "ENVIOS" Or SelectedForm = "SALINV" Or SelectedForm = "LISTADOS" Or SelectedForm = "TRASSAL" Or SelectedForm = "TRASSALSUC" Or SelectedForm = "TRASSALVENC" Then
                If Double.Parse(Me.txtUCCantidad.Text) <= Double.Parse(Me.lbExistenciaProducto.Text) Then
                    GoTo Terminar
                Else
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

            If Double.Parse(Me.txtUCCantidad.Text) > 0 Then

                If SelectedForm = "LISTADOS" Then
                    'EDICION DE FACTURAS
                    If InsertarProductoEdicionFactura() = True Then
                        'NO LLAMA AL GRID TEMP VENTAS PUESTO QUE NO ESTÁ EN EL FORMULARIO PRINCIPAL
                        Me.btnRealAceptar.PerformClick()
                    Else
                        MsgBox("Lo siento, No se pudo agregar este producto.. inténtalo de nuevo!! (Seguramente el servidor no me permitió conectarme). " & GlobalDesError)
                    End If
                Else
                    'TODAS LAS OPCIONES
                    If InsertarProductoTemp() = True Then
                        Call CargarGridTempVentas()
                        Me.btnRealAceptar.PerformClick()
                    Else
                        MsgBox("Lo siento, No se pudo agregar este producto.. inténtalo de nuevo!! (Seguramente el servidor no me permitió conectarme). " & GlobalDesError)
                    End If
                End If

            Else

                If SelectedForm = "INVFISICO" Then
                    Me.txtUCCantidad.Text = 0
                Else
                    MessageBox.Show("La cantidad solicitada debe ser mayor que cero")
                End If

            End If


        End If
    End Sub

    Private Sub txtUCBonificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCBonificacion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtUCPrecio.select()
        End If
    End Sub

    Private Sub txtUCBonificacion_Leave(sender As Object, e As EventArgs) Handles txtUCBonificacion.Leave
        If Me.txtUCBonificacion.Text <> "" Then
        Else
            Me.txtUCBonificacion.Text = 0
        End If
        If Double.Parse(Me.txtUCBonificacion.Text) > 0 Then
        Else
            Me.txtUCBonificacion.Text = 0
        End If
    End Sub


    Private Sub btnDescuento_Click(sender As Object, e As EventArgs) Handles btnDescuento.Click
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaOperador.Text)) = DialogResult.OK Then
            Me.txtUCPrecio.Enabled = True
            Me.txtUCPrecio.select()
        End If
    End Sub

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdUCAceptar.select()
        End If
    End Sub

End Class
