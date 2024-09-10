Imports System.Data.SqlClient
Imports Ares.Form1
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewEnviosCantidad
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
                        If NivelUsuario < 3 Then
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
        If Double.Parse(Me.txtUCCantidad.Text) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function InsertarProductoTemp() As Boolean

        If fcn_CrearMovimientoInventario() = True Then

            Dim result As Boolean


            'Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO) VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO)", cn)
            Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,NOSERIE) VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@NOSERIE)", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

            cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocENVIOS)
                cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
            cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
            cmd.Parameters.AddWithValue("@BONIF", Double.Parse(Me.txtUCBonificacion.Text))
            cmd.Parameters.AddWithValue("@TOTALBONIF", Double.Parse(Me.txtUCBonificacion.Text) * VentasEquivale)


            cmd.Parameters.AddWithValue("@NOSERIE", VentasNoSerie)
            cmd.Parameters.AddWithValue("@CORRELATIVO", VentasCorrelativo)
            cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)
            cmd.Parameters.AddWithValue("@DESPROD", VentasDesProducto)
            cmd.Parameters.AddWithValue("@CODMEDIDA", VentasCodMedida)
            cmd.Parameters.AddWithValue("@EQUIVALE", VentasEquivale)
            cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text))
            cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale))

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Try
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    result = True
                Catch ex As Exception
                    GlobalDesError = ex.ToString
                    result = False
                End Try

            End Using

            'If Double.Parse(Me.txtUCCantidad.Text) > Double.Parse(Me.lbExistenciaProducto.Text) Then
            'Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
            'End If
            Form1.txtVentasCodProd.Text = ""
            Form1.txtVentasCodProd.select()

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


            If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
            End If
            If VentasNoSerie = "SN" Then
            Else
                Dim objSeries As New classSeries
                If objSeries.Update_SerieStatus(GlobalEmpNit, VentasCodProducto, VentasNoSerie, 1) = True Then
                End If
            End If

            Return True

        Catch ex As Exception
            MsgBox("Error al crear el movimiento de inventario: " & ex.ToString)
            Return False

        End Try
    End Function


    Private Sub txtUCCantidad_Leave(sender As Object, e As EventArgs) Handles txtUCCantidad.Leave
        If Me.txtUCCantidad.Text <> "" Then

            'SI ESTOY VENDIENDO COMPARO LAS EXISTENCIAS
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
                        Me.txtUCCantidad.select()
                    End If
                Else
                    Try
                        Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
                    Catch ex As Exception
                    End Try
                    'Me.cmdUCAceptar.DialogResult = DialogResult.OK
                    If NivelUsuario < 3 Then
                        Me.txtUCPrecio.select()
                    Else
                        Me.cmdUCAceptar.select()
                    End If
                End If
            End If
        End If

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

        'DEPENDIENDO DEL FORMULARIO DEL QUE SE LLAME, HABILITO O DESHABILITO EL PRECIO


        Me.LbPrecioUnitarioCantidad.Text = "Precio Medida:"
                Me.txtUCPrecio.Enabled = False

                Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                Me.txtUCTotal.Text = FormatNumber(VentasPrecioProducto, 2)

                'la bonificación es invisible en ventas
                Me.LbBonif.Visible = False
                Me.txtUCBonificacion.Visible = False

                'permite editar el precio si es nivel 2 o 1
                If NivelUsuario < 3 Then Me.txtUCPrecio.Enabled = True



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




        Me.cmbUCMedida.SelectedValue = VentasEquivale
        Me.cmbUCMedida.Text = VentasCodMedida
        Me.cmbUCMedida.select()

    End Sub

    Private Sub txtUCPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCPrecio.Text <> "" Then
                If Double.Parse(Me.txtUCPrecio.Text) > 0 Then
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

        Call AbrirConexionSql()

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
            cn.Close()
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
                    VentasCostoProducto = Double.Parse(dr(0))
                    VentasPrecioProducto = Double.Parse(dr(1))
                    Me.txtUCPrecio.Text = FormatNumber(VentasPrecioProducto, 2)
                    Me.txtUCTotal.Text = FormatNumber((VentasPrecioProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)
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

                    Call CargarGridTempVentas()

                    'SendKeys.Send("{ESC}")
                    Me.btnRealAceptar.PerformClick()
                Else

                    MsgBox("Lo siento, No se pudo agregar este producto.. inténtalo de nuevo!! (Seguramente el servidor no me permitió conectarme). " & GlobalDesError)
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
End Class
