Imports System.Data.SqlClient

Public Class UserControl_TrasladosCantidad

    Private Sub UserControl_VentaCantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'VERIFICA SI EL SWITCH ESTÁ ACTIVADO PARA PERMITIR
        'DECIMALES EN CANTIDADES
        If Form1.SwitchConfigModoPOS.IsOn = False Then
            Me.txtUCCantidad.Properties.Mask.EditMask = "n0"
        End If

        If VentasNoSerie <> "" Then
        Else
            VentasNoSerie = "SN"
        End If

        Me.lbUCDesProducto.Text = VentasDesProducto
        Me.txtUCCantidad.Text = 1

        Call CargarMedidas()

        Me.cmbUCMedida.SelectedValue = VentasEquivale
        Me.cmbUCMedida.Text = VentasCodMedida
        Me.cmbUCMedida.select()


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

        If fcn_CrearMovimientoInventario() = True Then

            Dim result As Boolean

            Try
                Using cn As New SqlConnection(strSqlConectionString)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If
                    Dim cmd As New SqlCommand("INSERT INTO DOCPRODUCTOS 
                (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,CANTIDADBONIF,EQUIVALE,TOTALUNIDADES,TOTALBONIF,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,
                 ENTREGADOS_TOTALUNIDADES,ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO) 
                VALUES 
                ('TEMPTRAS',@ANIO,@MES,@DIA,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@CANTIDAD,0,@EQUIVALE,@TOTALUNIDADES,0,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,
                @ENTREGADOS_TOTALUNIDADES,@ENTREGADOS_TOTALCOSTO,@ENTREGADOS_TOTALPRECIO,@COSTOANTERIOR,@COSTOPROMEDIO)", cn)

                    'cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@ANIO", Today.Year)
                    cmd.Parameters.AddWithValue("@MES", Today.Month)
                    cmd.Parameters.AddWithValue("@DIA", Today.Day)
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocTras)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", VentasCorrelativo)
                    cmd.Parameters.AddWithValue("@CODPROD", VentasCodProducto)
                    cmd.Parameters.AddWithValue("@DESPROD", VentasDesProducto)
                    cmd.Parameters.AddWithValue("@CODMEDIDA", VentasCodMedida)
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text))
                    cmd.Parameters.AddWithValue("@EQUIVALE", VentasEquivale)
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@COSTO", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@PRECIO", VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", (Double.Parse(Me.txtUCCantidad.Text) * VentasPrecioProducto))
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale))
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@ENTREGADOS_TOTALPRECIO", (Double.Parse(Me.txtUCCantidad.Text) * VentasPrecioProducto))
                    cmd.Parameters.AddWithValue("@COSTOANTERIOR", VentasCostoProducto)
                    cmd.Parameters.AddWithValue("@COSTOPROMEDIO", VentasCostoProducto)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    result = True
                End Using
            Catch ex As Exception
                MsgBox(ex.ToString)
                result = False
            End Try

            Return result

        Else
            MsgBox("Lo lamento, no pude realizar el descuento del Stock, inténtalo de nuevo !! (Lo más seguro es que perdiste conexión al servidor)")
            Return False

        End If


    End Function

    Dim objInventario As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

    Private Function fcn_CrearMovimientoInventario() As Boolean

        Try

            Call ObtenerDatosInventario(VentasCodProducto, VentasAnio, VentasMes)
            If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
            End If

            Return True

        Catch ex As Exception
            MsgBox("Error al crear el movimiento de inventario: " & ex.ToString)
            Return False

        End Try

    End Function

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

    Private Sub txtUCCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCCantidad.Text > "0" Then

                Me.cmdUCAceptar.select()
            Else
                Me.txtUCCantidad.Text = "1"
                Me.cmdUCAceptar.select()
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

            Dim cmd As New SqlCommand("SELECT COSTO, PRECIOS.PRECIO FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & VentasCodProducto & "' AND CODMEDIDA='" & Me.cmbUCMedida.Text & "'", cn)
            Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                dr.Read()
                Try
                    If dr.HasRows Then
                        VentasEquivale = Integer.Parse(Me.cmbUCMedida.SelectedValue)
                        VentasCodMedida = Me.cmbUCMedida.Text

                    VentasCostoProducto = Double.Parse(dr(0))
                            VentasPrecioProducto = Double.Parse(dr(1))

                End If
                Catch ex As Exception
                End Try
                cmd.Dispose()
                'cn.Close()

            End Using

        End Sub


    Private Sub cmdUCAceptar_Click(sender As Object, e As EventArgs) Handles cmdUCAceptar.Click

        'If ConfigVerificaExistencias = True Then


        'If Double.Parse(Me.txtUCCantidad.Text) <= VentasExistencia Then
        'GoTo Terminar
        'Else
        'MessageBox.Show("Existencia menor a la cantidad solicitada")
        'Exit Sub
        'End If

        'Else
        'GoTo Terminar
        'End If


        'Terminar:
        '***********************************************************
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

End Class
