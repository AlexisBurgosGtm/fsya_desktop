Imports System.Data.SqlClient
Imports Ares.Form1
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class UserControl_VentaCantidadCompras


    Sub New(ByVal _ModoPos As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ModoPOS = _ModoPos

    End Sub

    Dim ModoPOS As Boolean

    Private Sub txtUCCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCCantidad.Text <> "" Then

                'SI ESTOY COMPRANDO NO COMPARO NADA
                Try
                    Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                Catch ex As Exception
                End Try
                Me.txtUCBonificacion.select()
                'Me.txtUCPrecio.select()

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

    Private Function InsertarProductoTemp() As Boolean
        Dim nolote As String = "SN"
        If Me.cmbNoLote.Text <> "" Then
            nolote = Me.cmbNoLote.Text
        Else
            nolote = "SN"
        End If

        If fcn_CrearMovimientoInventario() = True Then

            Dim result As Boolean

            Using cn As New SqlConnection(strSqlConectionString)
                Try
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,NOSERIE,OBS)
                    VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@NOSERIE,@OBS)", cn)

                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

                    'If SelectedForm = "COMPRAS" Then
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOMPRA)
                    'Else 'ORDEN DE COMPRA8
                    ''cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocORDENCOMPRA)
                    'End If

                    cmd.Parameters.AddWithValue("@CORRELATIVO", VentasCorrelativo)
                    cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)
                    cmd.Parameters.AddWithValue("@DESPROD", VentasDesProducto)
                    cmd.Parameters.AddWithValue("@CODMEDIDA", VentasCodMedida)
                    cmd.Parameters.AddWithValue("@EQUIVALE", VentasEquivale)
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text))
                    cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
                    cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtUCPrecio.Text))
                    cmd.Parameters.AddWithValue("@PRECIO", VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text))
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", (Double.Parse(Me.txtUCCantidad.Text) * VentasPrecioProducto))
                    cmd.Parameters.AddWithValue("@NOSERIE", VentasNoSerie)
                    cmd.Parameters.AddWithValue("@OBS", nolote)

                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    result = True

                Catch ex As Exception
                    MsgBox(ex.ToString)
                    GlobalDesError = ex.ToString
                    result = False
                End Try

            End Using

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
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If

                Case "INGINV"
                    If objInventario.fcn_InsertarEntradaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                    End If

                Case "SALINV"
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
                    'NO HAY MOVIMIENTO DE INVENTARIO
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
        'If e.KeyCode = Keys.Enter Then
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
                            'Me.cmdUCAceptar.DialogResult = DialogResult.OK
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
                Case "INVFISICO"
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    Me.cmdUCAceptar.select()
            End Select
        End If
        'End If

    End Sub

    <STAThread()>
    Private Sub UserControl_VentaCantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'VERIFICA SI EL SWITCH ESTÁ ACTIVADO PARA PERMITIR
        'DECIMALES EN CANTIDADES
        If Form1.SwitchConfigModoPOS.IsOn = False Then
            Me.txtUCCantidad.Properties.Mask.EditMask = "n0"
            Me.txtUCBonificacion.Properties.Mask.EditMask = "n0"
        End If

        If VentasNoSerie <> "" Then
        Else
            VentasNoSerie = "SN"
        End If

        Me.LbPrecioUnitarioCantidad.Text = "Costo Medida:"
        Me.txtUCPrecio.Enabled = True
        Me.txtUCTotal.Enabled = True

        Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
        Me.txtUCTotal.Text = FormatNumber(VentasCostoProducto, 2)

        'la bonificación es visible en compras
        Me.LbBonif.Visible = True
        Me.txtUCBonificacion.Visible = True

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

        Call CargarMedidas()
        Call CargarComboLotes()

        Me.cmbUCMedida.SelectedValue = VentasEquivale
        Me.cmbUCMedida.Text = VentasCodMedida
        Me.cmbUCMedida.select()

    End Sub


    Private Sub CargarComboLotes()

        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT NOLOTE FROM LOTES WHERE ACTIVO='SI' ", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        With Me.cmbNoLote
            .DataSource = tbl
            .ValueMember = "NOLOTE"
            .DisplayMember = "NOLOTE"
        End With


    End Sub
    Private Sub txtUCPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCPrecio.Text <> "" Then

                If Double.Parse(Me.txtUCPrecio.Text) > 0 Then

                    If VentasCostoProducto >= Double.Parse(Me.txtUCPrecio.Text) Then
                        If SelectedForm = "VENTAS" Or SelectedForm = "ENVIOS" Then

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

        End Using

    End Sub

    Private Sub CargarCostoPrecioMed()
        Call AbrirConexionSql()

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT COSTO,PRECIO FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & VentasCodProducto & "' AND CODMEDIDA='" & Me.cmbUCMedida.Text & "'", cn)
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
            cn.Close()

        End Using

    End Sub

    Private Sub cmdUCAceptar_Click_1(sender As Object, e As EventArgs) Handles cmdUCAceptar.Click

        If Me.txtUCCantidad.Text <> "" Then

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

                If InsertarProductoTemp() = True Then


                    Me.btnRealAceptar.PerformClick()
                Else

                    MsgBox("Lo siento, No se pudo agregar este producto.. inténtalo de nuevo!! (Seguramente el servidor no me permitió conectarme). " & GlobalDesError)
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


    Private Sub txtUCTotal_Leave(sender As Object, e As EventArgs) Handles txtUCTotal.Leave

        Try
                Me.txtUCPrecio.Text = Double.Parse(Me.txtUCTotal.Text) / Double.Parse(Me.txtUCCantidad.Text)
            Catch ex As Exception

            End Try

    End Sub

    Private Sub txtUCTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdUCAceptar.select()
        End If
    End Sub


#Region " ** edicion de precios **"
    Private Sub btnEditarPrecios_Click(sender As Object, e As EventArgs) Handles btnEditarPrecios.Click
        Call CargarGridEditarprecios(VentasCodProducto)
        Me.FlyoutPanelEditarPrecio.ShowPopup()

    End Sub


    Private Sub CargarGridEditarprecios(ByVal codprod As String)
        Dim objProd As New ClassProductos
        Me.GridEditarPrecios.DataSource = objProd.SelectPreciosProducto(GlobalEmpNit, VentasCodProducto)
    End Sub

    Dim drw As DataRow
    Private Sub GridViewEditarPrecios_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewEditarPrecios.FocusedRowChanged

        Try
            drw = Nothing
            drw = Me.GridViewEditarPrecios.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub



#End Region

End Class
