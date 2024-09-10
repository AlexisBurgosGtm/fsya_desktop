Imports DevExpress.XtraSplashScreen

Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewSync

    Dim objSync As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

    Private Sub viewSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.switchEliminaFacturar.IsOn = GlobalBool

        Call CargarGridPedidos(Me.switchEntregados.IsOn)
        Call cargarComboEmbarques()

    End Sub

    Private Sub cargarComboEmbarques()

    End Sub

    Private Sub CargarGridPedidos(ByVal entregados As Boolean)
        Try


            Me.GridPedidosPendientes.DataSource = Nothing
                If entregados = False Then
                    Me.GridPedidosPendientes.DataSource = objSync.tblPedidosPendientesDocs(GlobalEmpNit)
                Else
                    Me.GridPedidosPendientes.DataSource = objSync.tblPedidosEntregadosDocs(GlobalEmpNit)
                End If

                Me.GridPedidosPendientes.RefreshDataSource()

        Catch ex As Exception

        End Try


    End Sub

    Dim drw As DataRow


    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Call CargarGridPedidos(Me.switchEntregados.IsOn)
    End Sub


    Private Sub btnRadImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadImprimir.ItemClick
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        If rptEnviosTicketHost(drw.Item(0).ToString, Double.Parse(drw.Item(1)), Date.Parse(drw.Item(9))) = True Then
        Else
            MsgBox("Error: " & GlobalDesError)
        End If

        SplashScreenManager.CloseForm()
    End Sub

    Private Sub btnRadEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadEliminar.ItemClick

        If Confirmacion("¿Está seguro que desea Eliminar este Pedido?", Me.ParentForm) = True Then
            Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)
            If objS.EliminarPedido(drw.Item(0).ToString, Double.Parse(drw.Item(1)), GlobalEmpNit) = True Then
                MsgBox("Pedido eliminado exitosamente")
                Call CargarGridPedidos(Me.switchEntregados.IsOn)
            Else
                MsgBox("No se pudo eliminar el pedido, Error: " & objS.DesError)
            End If

        End If
    End Sub

    Private Sub btnRadFacturar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadFacturar.ItemClick
        If Confirmacion("¿Está seguro de querer pasar este pedido a facturación?", Me.ParentForm) = True Then

            If CargarPedidoHost(drw.Item(0).ToString, Double.Parse(drw.Item(1)), Date.Parse(drw.Item(9))) = True Then

                If Me.switchEliminaFacturar.IsOn = True Then
                    If objSync.EliminarPedido(drw.Item(0).ToString, Double.Parse(drw.Item(1)), GlobalEmpNit) = True Then
                    End If
                Else
                    Call Form1.Mensaje("El pedido no se eliminará del Servidor")
                End If

            Else
                MsgBox("Error al cargar el pedido. " & GlobalDesError)
            End If
        End If

    End Sub

    Private Sub btnRadRepartidor_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadRepartidor.ItemClick

        'If FlyoutDialog.Show(Me.ParentForm, New viewEmbarques(False)) = DialogResult.OK Then

        'If objSync.UpdateAsignarPicking(drw.Item(0).ToString, Double.Parse(drw.Item(1)), GlobalEmpNit, SelectedDescripcion) = True Then
        'Call CargarGridPedidos(Me.switchEntregados.IsOn)
        'Call cargarComboEmbarques()
        'Else
        'MsgBox("Ha ocurrido un error al actualizar el Embarque / Reparto. Error: " & GlobalDesError)
        'End If

        'End If

        'If FlyoutDialog.Show(Me.ParentForm, New viewRepartidores) = DialogResult.OK Then
        'If objSync.UpdateAsignarRepartidor(drw.Item(0).ToString, Double.Parse(drw.Item(1)), GlobalEmpNit, GlobalInteger) = True Then
        'Call CargarGridPedidos()
        'Else
        'MsgBox("Ha ocurrido un error al actualizar el Repartidor/Mensajero. Error: " & GlobalDesError)
        'End If
        'End If


    End Sub

    Private Sub btnRadEditarPedido_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadEditarPedido.ItemClick

        Dim tbl As New DataTable
        tbl = tblEnviosTicketHost(drw.Item(0).ToString, Double.Parse(drw.Item(1)), Date.Parse(drw.Item(9)))

        If FlyoutDialog.Show(Me.ParentForm, New viewPedidosEditar(drw)) = DialogResult.OK Then
            Call CargarGridPedidos(Me.switchEntregados.IsOn)
        Else
            Call CargarGridPedidos(Me.switchEntregados.IsOn)
        End If


    End Sub



    Private Sub btnRadEntregado_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadEntregado.ItemClick

        If Confirmacion("¿Está seguro que desea Marcar como entregado/NoEntregado este pedido?", Me.ParentForm) = True Then
            If objSync.UpdateEntregado(GlobalEmpNit, drw.Item(0).ToString, Double.Parse(drw.Item(1)), drw.Item(15).ToString) = True Then
                Call CargarGridPedidos(Me.switchEntregados.IsOn)
            End If
        End If

    End Sub

    Private Sub btnRadObs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadObs.ItemClick

        MsgBox("Observaciones: " & drw.Item(16).ToString)

    End Sub


    Private Function CargarPedidoHost(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal fecha As Date) As Boolean

        Dim result As Boolean

        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        'NAVEGA A LA VENTANA DE FACTURACION PARA PREPARAR LOS CORRELATIVOS
        NAVEGAR("VENTAS")
        'SelectedForm = "VENTAS"

        GlobalBool = True  'DETERMINA QUE AL TERMINAR DE FACTURAR SE REGRESARÁ A LA VENTANA DE PEDIDOS PRE-VENTA

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd0 As New SqlCommand("DELETE FROM TEMP_VENTAS FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC
                WHERE (TEMP_VENTAS.EMPNIT = @EMPNIT) AND (TEMP_VENTAS.USUARIO = @USUARIO) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC'))", cn)
                cmd0.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd0.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd0.ExecuteNonQuery()
                cmd0.Dispose()

                'ASIGNA LOS VALORES DEL ENCABEZADO DEL PEDIDO A LA VENTANA DE FACTURACIÓN
                Form1.txtVentasCodCliente.Text = drw.Item(4).ToString
                Form1.txtVentasNitClie.Text = drw.Item(10).ToString
                Form1.txtVentasNombre.Text = drw.Item(5).ToString
                Form1.cmbVentasVendedor.SelectedValue = Integer.Parse(drw.Item(2))
                Form1.cmbVentasVendedor.Text = drw.Item(3).ToString
                'VentasCodRepartidor = CType(drw.Item(16), Integer)
                VentasObs = drw.Item(16).ToString
            End Using

            GoTo DetallePedido

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
            GlobalBool = False 'FALLO ASÍ QUE REGRESARÁ A LA VENTANA DE PEDIDOS
            Call NAVEGAR("SYNC")
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
                sql = "SELECT 
                            ISNULL(WEB_DOCPRODUCTOS.CODPROD, 'SN') AS CODPROD, 
                            ISNULL(WEB_DOCPRODUCTOS.DESPROD, 'SN') AS DESPROD, 
                            ISNULL(WEB_DOCPRODUCTOS.CODMEDIDA, 'SN') AS CODMEDIDA, 
                            ISNULL(WEB_DOCPRODUCTOS.CANTIDAD, 0) AS CANTIDAD, 
                            ISNULL(WEB_DOCPRODUCTOS.COSTO, 0) AS COSTO, 
                            ISNULL(WEB_DOCPRODUCTOS.PRECIO, 0) AS PRECIO, 
                            ISNULL(WEB_DOCPRODUCTOS.TOTALCOSTO, 0) AS TOTALCOSTO, 
                            ISNULL(WEB_DOCPRODUCTOS.TOTALPRECIO, 0) AS TOTALPRECIO, 
                            ISNULL(WEB_DOCPRODUCTOS.EQUIVALE, 0) AS EQUIVALE, 
                            ISNULL(WEB_DOCUMENTOS.CODREP,0) AS CODREP,
                            ISNULL(WEB_DOCPRODUCTOS.DESCUENTO,0) AS DESCUENTO
                       FROM MUNICIPIOS RIGHT OUTER JOIN
                         CLIENTES RIGHT OUTER JOIN
                         WEB_DOCUMENTOS ON CLIENTES.TOKEN = WEB_DOCUMENTOS.TOKEN AND CLIENTES.EMPNIT = WEB_DOCUMENTOS.EMPNIT AND CLIENTES.CODCLIENTE = WEB_DOCUMENTOS.CODCLIENTE LEFT OUTER JOIN
                         VENDEDORES ON WEB_DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT AND WEB_DOCUMENTOS.TOKEN = VENDEDORES.TOKEN AND WEB_DOCUMENTOS.CODVEN = VENDEDORES.CODVEN LEFT OUTER JOIN
                         EMPRESAS ON WEB_DOCUMENTOS.TOKEN = EMPRESAS.TOKEN AND WEB_DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                         WEB_DOCPRODUCTOS ON WEB_DOCUMENTOS.TOKEN = WEB_DOCPRODUCTOS.TOKEN AND WEB_DOCUMENTOS.EMPNIT = WEB_DOCPRODUCTOS.EMPNIT AND 
                         WEB_DOCUMENTOS.ANIO = WEB_DOCPRODUCTOS.ANIO AND WEB_DOCUMENTOS.MES = WEB_DOCPRODUCTOS.MES AND WEB_DOCUMENTOS.DIA = WEB_DOCPRODUCTOS.DIA AND 
                         WEB_DOCUMENTOS.CODDOC = WEB_DOCPRODUCTOS.CODDOC AND WEB_DOCUMENTOS.CORRELATIVO = WEB_DOCPRODUCTOS.CORRELATIVO ON MUNICIPIOS.CODMUNICIPIO = CLIENTES.CODMUNICIPIO
                       WHERE 
                        (WEB_DOCUMENTOS.TOKEN = @TOKEN) AND 
                        (WEB_DOCUMENTOS.EMPNIT = @EMPNIT) AND 
                        (WEB_DOCUMENTOS.CODDOC = @CODDOC) AND 
                        (WEB_DOCUMENTOS.CORRELATIVO = @CORRELATIVO) AND
                        (WEB_DOCUMENTOS.FECHA=@FECHA)"

                Dim cmdHost As New SqlCommand(sql, cnHost)
                cmdHost.Parameters.AddWithValue("@TOKEN", Token)
                cmdHost.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdHost.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmdHost.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                cmdHost.Parameters.AddWithValue("@FECHA", fecha)

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
                        (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALBONIF,EXENTO,USUARIO,OBS,DESCUENTO)
                    VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@TOTALBONIF,@EXENTO,@USUARIO,@OBS,@DESCUENTO)", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Form1.txtVentasCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                        cmd.Parameters.AddWithValue("@DESPROD", dr(1).ToString)
                        cmd.Parameters.AddWithValue("@CODMEDIDA", dr(2).ToString)
                        cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(dr(3)))
                        cmd.Parameters.AddWithValue("@COSTO", Double.Parse(dr(4)))
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(dr(5)))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(dr(6)))
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(dr(7)))
                        cmd.Parameters.AddWithValue("@EXENTO", 0)
                        cmd.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(dr(8)))
                        cmd.Parameters.AddWithValue("@TOTALUNIDADES", Integer.Parse(dr(8)) * Double.Parse(dr(3)))
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                        cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                        cmd.Parameters.AddWithValue("@OBS", "SN")
                        cmd.Parameters.AddWithValue("@DESCUENTO", Double.Parse(dr(10)))

                        Dim i As Integer = cmd.ExecuteNonQuery()
                        If i > 0 Then
                            Dim oInv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
                            oInv.fcn_InsertarSalidaProducto(dr(0).ToString, Double.Parse(dr(8)) * Double.Parse(dr(3)))
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
            MsgBox("Error al cargar el detalle . " & ex.ToString)
            GlobalDesError = ex.ToString
            result = False
            Call NAVEGAR("SYNC")

        End Try


Finalizar:

        SplashScreenManager.CloseForm()

        Return result

    End Function

    Private Sub switchEliminaFacturar_Toggled(sender As Object, e As EventArgs) Handles switchEliminaFacturar.Toggled
        If Me.switchEliminaFacturar.IsOn = True Then
            GlobalBool = True
        Else
            GlobalBool = False
        End If
    End Sub


    Private Sub GridViewSync_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewSync.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewSync.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewSync_DoubleClick(sender As Object, e As EventArgs) Handles GridViewSync.DoubleClick
        Me.RadialMenuSync.ShowPopup(MousePosition)
    End Sub



#Region " OPCIONES SYNC "

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        Me.FlyoutPanelOpcionesSync.ShowPopup()

    End Sub


    Private Sub btnSyncTodo_Click(sender As Object, e As EventArgs) Handles btnSyncTodo.Click
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)



        objS.EliminarClientes(GlobalEmpNit)
            objS.EnviarClientes(GlobalEmpNit)

            objS.EliminarVendedores(GlobalEmpNit)
            objS.EnviarVendedores(GlobalEmpNit)

            'objS.EliminarEmpresas()
            'objS.EnviarEmpresas()

            objS.EliminarRepartidores(GlobalEmpNit)
            objS.EnviarRepartidores(GlobalEmpNit)

            objS.EliminarPrecios(GlobalEmpNit)
            objS.EnviarPrecios(GlobalAnioProceso, GlobalMesProceso, GlobalEmpNit)



        SplashScreenManager.CloseForm()
    End Sub

    Private Sub btnSyncProductos_Click(sender As Object, e As EventArgs) Handles btnSyncProductos.Click
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)



        objS.EliminarPrecios(GlobalEmpNit)
            If objS.EnviarPrecios(GlobalAnioProceso, GlobalMesProceso, GlobalEmpNit) = True Then
                SplashScreenManager.CloseForm()
                Call Aviso("Envío exitoso", "Productos cargados exitosamente", Me.ParentForm)

            Else
                SplashScreenManager.CloseForm()
                MsgBox("Error al tratar de cargar los productos. Error: " & objS.DesError.ToString)
            End If


    End Sub

    Private Sub btnSyncClientes_Click(sender As Object, e As EventArgs) Handles btnSyncClientes.Click
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)



        objS.EliminarClientes(GlobalEmpNit)
            If objS.EnviarClientes(GlobalEmpNit) = True Then
                SplashScreenManager.CloseForm()
                MsgBox("Clientes Enviados Exitosamente")
            Else
                SplashScreenManager.CloseForm()
                MsgBox("NO se pudieron sincronizar los clientes")
            End If



    End Sub

    Private Sub btnSyncVendedores_Click(sender As Object, e As EventArgs) Handles btnSyncVendedores.Click
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)


        objS.EliminarVendedores(GlobalEmpNit)
            objS.EnviarVendedores(GlobalEmpNit)
            SplashScreenManager.CloseForm()


    End Sub

    Private Sub btnSyncRepartidores_Click(sender As Object, e As EventArgs) Handles btnSyncRepartidores.Click
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)



        objS.EliminarRepartidores(GlobalEmpNit)
            objS.EnviarRepartidores(GlobalEmpNit)



        SplashScreenManager.CloseForm()
    End Sub




    Private Sub btnCerrarFlyoutSync_Click(sender As Object, e As EventArgs) Handles btnCerrarFlyoutSync.Click
        Me.FlyoutPanelOpcionesSync.HidePopup()
    End Sub



    Private Sub btnEmbarqueGeneral_Click(sender As Object, e As EventArgs) Handles btnEmbarqueGeneral.Click



        Dim tbl As New DataTable

            Using cnh As New SqlConnection(strHostConectionString)
                Try
                    SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                    If cnh.State <> ConnectionState.Open Then
                        cnh.Open()
                    End If

                    Dim sql As String
                    sql = "SELECT       WEB_DOCUMENTOS.CODEMBARQUE, WEB_DOCUMENTOS.FECHA, CONCAT(WEB_DOCUMENTOS.CODDOC, '-', WEB_DOCUMENTOS.CORRELATIVO) AS PEDIDO, CLIENTES.NOMCLIENTE AS CLIENTE, 
                         CLIENTES.DIRCLIENTE AS DIRECCION, CLIENTES.EMAIL AS MUNICIPIO, WEB_DOCUMENTOS.LAT, WEB_DOCUMENTOS.LONG, WEB_DOCUMENTOS.OBS, WEB_DOCUMENTOS.TOTALVENTA, 
                         WEB_DOCPRODUCTOS.CODPROD, WEB_DOCPRODUCTOS.DESPROD AS PRODUCTO, WEB_DOCPRODUCTOS.CODMEDIDA, WEB_DOCPRODUCTOS.CANTIDAD, 
                         WEB_DOCPRODUCTOS.CANTIDAD * WEB_DOCPRODUCTOS.EQUIVALE AS TOTALUNIDADES, WEB_DOCPRODUCTOS.COSTO, WEB_DOCPRODUCTOS.PRECIO, WEB_DOCPRODUCTOS.TOTALCOSTO, 
                         WEB_DOCPRODUCTOS.TOTALPRECIO, PRECIOS.CODMARCA, PRECIOS.DESMARCA, PRECIOS.TIPOPROD
FROM            CLIENTES RIGHT OUTER JOIN
                         WEB_DOCUMENTOS ON CLIENTES.CODCLIENTE = WEB_DOCUMENTOS.CODCLIENTE AND CLIENTES.EMPNIT = WEB_DOCUMENTOS.EMPNIT AND CLIENTES.TOKEN = WEB_DOCUMENTOS.TOKEN LEFT OUTER JOIN
                         PRECIOS RIGHT OUTER JOIN
                         WEB_DOCPRODUCTOS ON PRECIOS.CODMEDIDA = WEB_DOCPRODUCTOS.CODMEDIDA AND PRECIOS.EMPNIT = WEB_DOCPRODUCTOS.EMPNIT AND PRECIOS.CODPROD = WEB_DOCPRODUCTOS.CODPROD AND 
                         PRECIOS.TOKEN = WEB_DOCPRODUCTOS.TOKEN ON WEB_DOCUMENTOS.CORRELATIVO = WEB_DOCPRODUCTOS.CORRELATIVO AND WEB_DOCUMENTOS.CODDOC = WEB_DOCPRODUCTOS.CODDOC AND 
                         WEB_DOCUMENTOS.ANIO = WEB_DOCPRODUCTOS.ANIO AND WEB_DOCUMENTOS.EMPNIT = WEB_DOCPRODUCTOS.EMPNIT AND WEB_DOCUMENTOS.TOKEN = WEB_DOCPRODUCTOS.TOKEN
WHERE        (WEB_DOCUMENTOS.TOKEN = @TOKEN)"

                    Dim cmd As New SqlCommand(sql, cnh)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    da.Fill(tbl)

                    SplashScreenManager.CloseForm()

                    Me.GridExports.DataSource = Nothing
                    Me.GridExports.DataSource = tbl
                Me.GridExports.ExportToXlsx(Application.StartupPath & "/EXPORTS/embarquedata.xlsx")
                Process.Start(Application.StartupPath & "/EXPORTS/embarquedata.xlsx")

            Catch ex As Exception
                    MsgBox("Error al ejecutar. Error: " & ex.ToString)
                End Try
            End Using

    End Sub

    Private Sub switchEntregados_Toggled(sender As Object, e As EventArgs) Handles switchEntregados.Toggled
        Call CargarGridPedidos(Me.switchEntregados.IsOn)
    End Sub

    Private Sub btnSyncDashboard_Click(sender As Object, e As EventArgs) Handles btnSyncDashboard.Click

        If Form1.BackgroundWorkerSync.IsBusy = False Then
            Form1.Mensaje("Iniciando sincronización")
            Form1.BackgroundWorkerSync.RunWorkerAsync()
        Else
            Form1.Mensaje("No se inició sincronización")
        End If
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


End Class
