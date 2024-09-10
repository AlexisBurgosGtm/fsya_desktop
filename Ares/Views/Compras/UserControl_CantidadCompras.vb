Imports System.Data.SqlClient
Imports Ares.Form1
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class UserControl_CantidadCompras

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
                    cmd.Parameters.AddWithValue("@CODDOC", strCoddoc) 'GlobalCoddocCOMPRA)
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

            If GlobalEmpNit = "COMPRAS" Then

                If SelectedForm = "COMPRAS" Then
                    Call fcninsertTempTras()

                End If

            End If


            Return result

        Else
            MsgBox("Lo lamento, no pude realizar el descuento del Stock, inténtalo de nuevo !! (Lo más seguro es que perdiste conexión al servidor)")
            Return False
        End If

    End Function

    Dim corrSalComp As Integer

    Private Function fcninsertTempTras() As Boolean

        Call CargarCorrelativoTras()
        MsgBox(GlobalCoddocTrasSalSucursal + " " + GlobalCorrTras.ToString)

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
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocTrasSalSucursal)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", GlobalCorrTras)
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

    Private Sub CargarCorrelativoTras()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocTrasSalSucursal & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()

            Try

                GlobalCorrTras = dr(0).ToString

            Catch ex As Exception
                MsgBox(ex.ToString + " EN CORRELATIVO TRAS")
                GlobalCorrTras = 0

            End Try
            dr.Close()
            cmd.Dispose()
        End Using
        'cn.Close()

    End Sub

    Private Sub correlativosalidasComp()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT        CORRELATIVO
                                           FROM            TIPODOCUMENTOS
                                           WHERE        (CODDOC = @SALIDASUC)", cn)
                cmd.Parameters.AddWithValue("@SALIDASUC", GlobalCoddocTrasSalSucursal)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    corrSalComp = dr(0)
                Else
                    MsgBox("Correlativo de salida no cargado")
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

    Dim AJUSTE As Double

    Dim objInventario As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

    Private Function fcn_CrearMovimientoInventario() As Boolean
        If SelectedForm = "ORDEN_COMPRA" Then
            Return True
            Exit Function
        End If
        Try

            Call ObtenerDatosInventario(VentasCodProducto, VentasAnio, VentasMes)

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

            Return True

        Catch ex As Exception
            MsgBox("Error al crear el movimiento de inventario: " & ex.ToString)
            Return False

        End Try
    End Function

    Private Sub txtUCCantidad_Leave(sender As Object, e As EventArgs) Handles txtUCCantidad.Leave
        'If e.KeyCode = Keys.Enter Then
        If Me.txtUCCantidad.Text <> "" Then

            'SI ESTOY COMPRANDO NO COMPARO NADA
            Try
                Me.txtUCTotal.Text = FormatNumber((Double.Parse(Me.txtUCCantidad.Text) * Double.Parse(Me.txtUCPrecio.Text)), 2)
            Catch ex As Exception
            End Try
            Me.txtUCBonificacion.select()
            'Me.txtUCPrecio.select()

        End If
        'End If

    End Sub

    Dim strCoddoc As String = ""

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

        If SelectedForm = "COMPRAS" Then
            strCoddoc = GlobalCoddocCOMPRA
        Else
            strCoddoc = GlobalCoddocORDENCOMPRA
        End If

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

                    VentasCostoProducto = Double.Parse(dr(0))
                    VentasPrecioProducto = Double.Parse(dr(1))
                    Me.txtUCPrecio.Text = FormatNumber(VentasCostoProducto, 2)
                    Me.txtUCTotal.Text = FormatNumber((VentasCostoProducto * Double.Parse(Me.txtUCCantidad.Text)), 2)

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
