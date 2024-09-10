Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports SocketIOClient.Client
Imports Quobject.SocketIoClientDotNet.Client
Imports System.Net

Public Class viewPedidosDomicilio

    Dim objSync As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

    Private Sub viewPedidosDomicilio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGridPedidos(Me.switchEntregados.IsOn)

    End Sub



#Region " socket "

    Private Sub enviarSocket()

        Dim url As String
        url = Trim("https://onne-domicilio.herokuapp.com/reload?sucursal=" & GlobalEmpNit & "&msg=" & "nueva%20venta")

        'MsgBox(url)

        Dim cliente As WebClient = New WebClient()
        Dim r As String = cliente.DownloadString(url)
        'MsgBox(r)

        Exit Sub


    End Sub

#End Region


    Private Sub btnSyncObtenerCenso_Click(sender As Object, e As EventArgs) Handles btnSyncObtenerCenso.Click

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        If Confirmacion("¿Está seguro que desea Obtener los clientes del Censo en la nube?", Me.ParentForm) = True Then
            ' SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


            objS.getCenso(GlobalEmpNit)
                objS.deleteCenso(GlobalEmpNit)

                'SplashScreenManager.CloseForm()
            End If

    End Sub


    Private Sub CargarGridPedidos(ByVal entregados As Boolean)




        Me.GridPedidosPendientes.DataSource = Nothing
            If entregados = False Then
                Me.GridPedidosPendientes.DataSource = objSync.tblPedidosPendientesDomicilio(GlobalEmpNit)
            Else
                Me.GridPedidosPendientes.DataSource = objSync.tblPedidosEntregadosDomicilio(GlobalEmpNit)
            End If

            Me.GridPedidosPendientes.RefreshDataSource()

    End Sub


    Dim drw As DataRow


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Call CargarGridPedidos(Me.switchEntregados.IsOn)
    End Sub

    Private Sub switchEntregados_Toggled(sender As Object, e As EventArgs) Handles switchEntregados.Toggled
        Call CargarGridPedidos(Me.switchEntregados.IsOn)
    End Sub

    Private Sub GridViewSync_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewSync.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewSync.GetFocusedDataRow
        Catch ex As Exception
            drw = Nothing
        End Try
    End Sub

    Private Sub GridViewSync_DoubleClick(sender As Object, e As EventArgs) Handles GridViewSync.DoubleClick
        Me.RadialMenuPedidos.ShowPopup(MousePosition)
    End Sub

    Private Sub GridViewSync_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewSync.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.RadialMenuPedidos.ShowPopup(MousePosition)
        End If
    End Sub


    Private Sub btnRadMenEntregado_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenEntregado.ItemClick

        If Confirmacion("¿Está seguro que desea Marcar como entregado/NoEntregado este pedido?", Me.ParentForm) = True Then
            If objSync.UpdateEntregadoDomicilio(GlobalEmpNit, drw.Item(0).ToString, Double.Parse(drw.Item(1)), drw.Item(15).ToString) = True Then
                Call CargarGridPedidos(Me.switchEntregados.IsOn)
                Call enviarSocket()
            End If
        End If

    End Sub

    Private Sub btnRadMenImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenImprimir.ItemClick

        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        If rptEnviosTicketHostDomicilio(drw.Item(0).ToString, Double.Parse(drw.Item(1)), Date.Parse(drw.Item(9))) = True Then
        Else
            Form1.Mensaje("Error: " & GlobalDesError)
        End If

        SplashScreenManager.CloseForm()

    End Sub

    Private Function CargarPedidoHost(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal fecha As Date) As Boolean

        Dim result As Boolean

        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        'NAVEGA A LA VENTANA DE FACTURACION PARA PREPARAR LOS CORRELATIVOS
        NAVEGAR("VENTAS")
        'SelectedForm = "VENTAS"

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd0 As New SqlCommand("DELETE FROM TEMP_VENTAS FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC
                WHERE (TEMP_VENTAS.EMPNIT = @EMPNIT) AND (TEMP_VENTAS.USUARIO = @USUARIO) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF'))", cn)
                cmd0.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd0.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd0.ExecuteNonQuery()
                cmd0.Dispose()

                'ASIGNA LOS VALORES DEL ENCABEZADO DEL PEDIDO A LA VENTANA DE FACTURACIÓN
                Form1.txtVentasCodCliente.Text = drw.Item(3).ToString
                Form1.txtVentasNitClie.Text = drw.Item(3).ToString
                Form1.txtVentasNombre.Text = drw.Item(4).ToString
                VentasDirEntrega = drw.Item(9).ToString

                VentasObs = drw.Item(11).ToString

            End Using

            GoTo DetallePedido

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
            Call NAVEGAR("DOMICILIO")
            GoTo Finalizar
        End Try

DetallePedido:

        'CARGA LOS DATOS DEL DETALLE A LA TABLA TEMP_VENTAS
        Try
            Using cnHost As New SqlConnection(strHostConectionString)
                If cnHost.State <> ConnectionState.Open Then
                    cnHost.Open()
                End If

                Dim sql As String
                sql = "SELECT       CODPROD, DESPROD, CODMEDIDA, EQUIVALE, CANTIDAD, TOTALUNIDADES, COSTO, PRECIO, TOTALCOSTO, TOTALPRECIO, EXENTO FROM COMMUNITY_DOCPRODUCTOS_DOMICILIO
                       WHERE        (EMPNIT = @EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO)"

                Dim cmdHost As New SqlCommand(sql, cnHost)
                cmdHost.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdHost.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmdHost.Parameters.AddWithValue("@CORRELATIVO", Correlativo)

                Dim dr As SqlDataReader
                dr = cmdHost.ExecuteReader

                Do While dr.Read
                    Using cn As New SqlConnection(strSqlConectionString)
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If
                        'ASIGNA EL CODIGO DEL REPARTIDOR SI EXISTE
                        VentasCodRepartidor = CType(dr(9), Integer)

                        Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas 
                        (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALBONIF,EXENTO,USUARIO,OBS) VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@TOTALBONIF,@EXENTO,@USUARIO,@OBS)", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Form1.txtVentasCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                        cmd.Parameters.AddWithValue("@DESPROD", dr(1).ToString)
                        cmd.Parameters.AddWithValue("@CODMEDIDA", dr(2).ToString)
                        cmd.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(dr(3)))
                        cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(dr(4)))
                        cmd.Parameters.AddWithValue("@TOTALUNIDADES", Double.Parse(dr(5)))
                        cmd.Parameters.AddWithValue("@COSTO", Double.Parse(dr(6)))
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(dr(7)))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(dr(8)))
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(dr(9)))
                        cmd.Parameters.AddWithValue("@EXENTO", Double.Parse(dr(10)))
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                        cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                        cmd.Parameters.AddWithValue("@OBS", "SN")

                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If i > 0 Then
                            Dim oInv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
                            oInv.fcn_InsertarSalidaProducto(dr(0).ToString, Double.Parse(dr(5)) * Double.Parse(dr(3)))
                        End If
                        cmd.Dispose()
                    End Using
                Loop

                dr.Close()
                dr = Nothing
                cmdHost.Dispose()
                cnHost.Close()
            End Using

            Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Form1.txtVentasCorrelativo.Text))
            Call CargarGridTempVentas()

            result = True

        Catch ex As Exception
            SplashScreenManager.CloseForm()
            MsgBox("Error al cargar el detalle . " & ex.ToString)
            GlobalDesError = ex.ToString
            result = False
            Call NAVEGAR("DOMICILIO")

        End Try

Finalizar:

        SplashScreenManager.CloseForm()
        Me.cmdRPTVatras.PerformClick()
        Return result

    End Function

    Private Sub btnRadMenFacturar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenFacturar.ItemClick

        If Confirmacion("¿Está seguro de querer pasar este pedido a facturación?", Me.ParentForm) = True Then

            If CargarPedidoHost(drw.Item(0).ToString, Double.Parse(drw.Item(1)), Date.Parse(drw.Item(8))) = True Then

                'USA ESTA VARIABLE PARA INDICAR SI EL PEDIDO VIENE DEL DOMICILIO
                GlobalTipoVenta = "DOMICILIO"

                If objSync.UpdateEntregadoDomicilio(GlobalEmpNit, drw.Item(0).ToString, Double.Parse(drw.Item(1)), drw.Item(10).ToString) = True Then
                    'Call enviarSocket()
                End If

                Call Form1.Mensaje("El pedido no se eliminará del Servidor")

            Else
                MsgBox("Error al cargar el pedido. " & GlobalDesError)
            End If
        End If

    End Sub

End Class
