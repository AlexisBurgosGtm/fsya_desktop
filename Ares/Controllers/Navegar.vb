Imports System.Net
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Module NavegarModule

#Region " ** NAVEGAR ** "

    Public Sub NAVEGAR(ByVal VIEW As String)
        If boolLoged = True Then

            'If VIEW = "VENTAS" Then
            'Form1.groupObjetivoVentas.Visible = True
            'Else
            'Form1.groupObjetivoVentas.Visible = False
            'End If


            Select Case VIEW
                Case "EMPRESAS_SYNC"
                    Call NavEmpresasSync()

                Case "FEL_VENTAS"
                    Call NavFELVentas()
                Case "DASHBOARD"
                    Call NavDashboard()

                Case "DOMICILIO"
                    Call NavPedidosDomicilio()

                Case "ORDENPROD"
                    Call NavOrdenProduccion()

                Case "ONLINE_PRECIOS_SUCURSALES"
                    Call NavGestionPreciosSucursales()

                Case "INVENTARIO_ONLINE"
                    Call NavGetInventarioOnline()

                Case "DOCUMENTOS_ONLINE"
                    Call NavGetDocumentosContaOnline()

                Case "CORTES_ONLINE"
                    Call NavGetCortesOnline()

                Case "CORTES_ONLINE2"
                    Call NavGetCortesOnline2()

                Case "VENTAS_ONLINE"
                    Call NavGetVentasOnline()

                Case "VENTAS_ONLINE2"
                    Call NavGetVentasOnline2()

                Case "VENTAS_DOMICILIO"
                    Call NavGetVentasDomicilio()

                Case "VENTAS_DOMICILIO2"
                    Call NavGetVentasDomicilio2()

                Case "INVFISICO"
                    Call NavInvFisico()

                Case "INVENTARIOS"
                    Call NavInventarios()

                Case "TRASSAL"
                    Call NavTrasSalBod()

                Case "TRASSALSUC"
                    Call NavTrasSalSuc()
                Case "TRASSALPROV"
                    Call NavTrasSalProv()
                Case "TRASSALVENC"
                    Call NavTrasSalVenc()
                Case "PLANTILLAPRODUCTOS"
                    Call NavPlantillaProd()

                Case "INVMINIMOS"
                    Call NavInventariosMinimos()

                Case "CXP"
                    Call NavCxp()

                Case "RUTASCLIENTES"
                    Call NavRutasClientes()

                Case "REPARTIDORES"
                    Call NavMantenimientosRepartidores()

                Case "INVVENCIDOS"
                    Call NavInventariosVencidos()


                Case "SYNC"
                    Call NavSyncTraslados("TIN")

                Case "SYNC_2"
                    Call NavSyncTraslados("TES")

                Case "SYNC2"
                    Call NavSyncPedidos()

                Case "ONLINE_PREVENTAS"
                    Call NavOnlinePreventas()

                Case "CLIENTES_VEHICULOS"
                    Call NavMantenimientosVehiculos()

                Case "DEVOLUCIONES"
                    Call NavDevoluciones()

                Case "EMBARQUES"
                    Call NavEmbarques()

                Case "BITACORA"
                    Call NavBitacora()

                Case "LOGIN"
                    Call NavLogin()

                Case "MENU"
                    Call NavMenu()

                Case "INICIO"
                    Call NavInicio()

                Case "CONFIG"
                    Call NavConfig()

                Case "VENTAS"
                    Call NavVentas()

                Case "ENVIOS"
                    Call NavEnvios()

                Case "COTIZACIONES"
                    Call NavCotizaciones()

                Case "CXC"
                    Call NavCxc()

                Case "CATALOGO"
                    Call NavCatalogoProductos()

                Case "COMPRAS"
                    Call NavCompras()

                Case "ORDEN_COMPRA"
                    Call NavOrdenCompra()

                Case "CORTECAJA"
                    Call NavCorteCaja()

                Case "REPORTES"
                    Call NavReportes()

                Case "GASTOS"
                    Call NavGastos()

                Case "EMPLEADOS"
                    Call NavMantenimientosEmpleados()

                Case "PROVEEDORES"
                    'Call NavMantenimientosProveedores()
                    Call NavProveedores()

                Case "CLIENTES"
                    Call NavMantenimientosClientes()

                Case "DOCUMENTOS"
                    Call NavDocumentos()

                Case "DOCUMENTOSSUC"
                    Call NavDocumentosSUC()

                Case "LISTAPRECIOS"
                    Call NavInventariosListaPrecios()

                Case "LISTAPRECIOSCOMP"
                    Call NavInventariosListaPreciosComp()

                Case "ORDENTRABAJO"
                    Call NavOrdenTrabajo()

                Case "ETIQUETAS"
                    Call NavInventariosEtiquetas()

                Case "TRANSFERIRBOD"
                    Call NavInventariosTransferir("BODEGA")

                Case "TRANSFERIRSUC"
                    Call NavInventariosTransferir("SUCURSAL")

                Case "MANTENIMIENTOS"
                    Call NavMantenimientos()

                Case "TIPODOCUMENTOS"
                    Call NavTipoDocumentos()

                Case "SYNCPRECIOS"
                    Call NavSyncPrecios()

                Case "SYNCPRECIOS2"
                    Call NavSyncPrecios2()

                Case "SYNCPRODUCTOS"
                    Call NavSyncProductos()
                Case "SYNCRO"
                    Call NavSYNC()
                Case "SERVIDORES"
                    Call NavSERV()
                Case "TRASLADOS"
                    Call NavTRASLADOS()
                Case "PROGRAMAS"
                    Call NavPROGRAMAS()
                Case "IEF"
                    Call NavIEF()
                Case "ACTINV"
                    Call NavACTINV()
                Case "ACTINV_2CORTE"
                    Call NavACTINV_2CORTE()

            End Select

            Form1.Text = "Onne Business - " & SelectedForm
        End If

    End Sub

#End Region

    Private Function NavACTINV() As Boolean

        If Confirmacion("Está seguro que desea Actualizar el Inventario, puede tardar unos minutos?", Form1.ParentForm) = True Then

            Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

            SplashScreenManager.ShowForm(Form1.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim result As String

            If objInventarios.fcn_actu_invfsya(GlobalEmpNit) = True Then

                result = "Actualización completada exitosamente"

            Else
                result = "Algo salió mal. Error: " & GlobalDesError

                SplashScreenManager.CloseForm()

            End If

            SplashScreenManager.CloseForm()

            Form1.Mensaje(result.ToString)

        End If

    End Function

    Private Function NavACTINV_2CORTE() As Boolean

        Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

        Dim result As String

        If objInventarios.fcn_actu_invfsya(GlobalEmpNit) = True Then

            result = "Actualización completada exitosamente"

        Else
            result = "Algo salió mal. Error: " & GlobalDesError

        End If

        Form1.Mensaje(result.ToString)


    End Function

#Region " ** INVENTARIOS ** "

    'CATALOGO DE PRODUCTOS
    Private Function NavSYNC() As Boolean
        Dim result As Boolean
        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewSync
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "SYNCRO"


        Return result
    End Function

#End Region


#Region " ** FEL ** "
    Private Function NavFELVentas()

        Dim result As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewFELVentas
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "FEL_VENTAS"


        Return result

    End Function

#End Region

    'RUTAS CLIENTES
    Private Function NavEmpresasSync() As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewEmpresasHost
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "EMPRESASHOST"

        Return r
    End Function


    'RUTAS CLIENTES
    Private Function NavRutasClientes() As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewRutasClientes
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "RUTASCLIENTES"

        Return r
    End Function


    'PROVEEDORES
    Private Function NavProveedores() As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewProveedores
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "PROVEEDORES"

        Return r
    End Function

    'DOCUMENTOS
    Private Function NavDocumentos() As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewDocumentos
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "LISTADOS"

        Return r
    End Function

    'DOCUMENTOSSUC
    Private Function NavDocumentosSUC() As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewDocumentosSUC
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "LISTADOSSUC"

        Return r
    End Function

#Region " ** CONFIGURACIONES ** "


    'INICIO
    Private Function NavInicio() As Boolean
        Try
            cn.Close()
        Catch ex As Exception

        End Try

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_Inicio
        SelectedForm = "INICIO"


        Return True
    End Function

    'MENU

    Private Function NavMenu() As Boolean
        Form1.NP_Inicio.Controls.Remove(Form1.CtrlGeneral)
        Form1.CtrlGeneral = Nothing
        Form1.NP_Inicio.Controls.Clear()

        Select Case NivelUsuario
            Case 1
                Form1.CtrlGeneral = New viewInterfaceNew
            Case 2
                Form1.CtrlGeneral = New viewInterfaceVentas
            Case 3
                Form1.CtrlGeneral = New viewInterfaceSUP
            Case 4
                Form1.CtrlGeneral = New viewInterfaceBod
            Case 5
                Form1.CtrlGeneral = New viewInterfaceBod2
            Case 6
                Form1.CtrlGeneral = New viewInterfaceINV
            Case 7
                Form1.CtrlGeneral = New viewInterfaceConta
            Case 8
                Form1.CtrlGeneral = New viewInterfaceCompras
            Case 9
                Form1.CtrlGeneral = New viewInterfaceVencidos
            Case 10
                Form1.CtrlGeneral = New viewInterfaceDIG

        End Select

        Form1.NP_Inicio.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_Inicio
        SelectedForm = "INICIO"

        Return True
    End Function

    'LOGIN
    Private Function NavLogin() As Boolean
        boolLoged = False
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_Login

        Dim obc As New classConfig
        obc.LiberarUsuario(GlobalNomUsuario)

        GlobalNomUsuario = ""
        NivelUsuario = 100
        SelectedForm = "LOGIN"
        Try
            Form1.NP_Login.BackgroundImage = Image.FromFile(GlobalPathFondo)
        Catch ex As Exception
        End Try

        'DETIENE EL TIMER DE AUTOCERTIFICACION FEL
        Form1.TimerFEL.Enabled = False
        Form1.TimerFEL.Stop()

        Return True
    End Function

    'BITACORA
    Private Function NavBitacora() As Boolean
        Dim r As Boolean

        If NivelUsuario = 1 Then
            Try
                Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
            Catch ex As Exception

            End Try

            Form1.CtrlGeneral = Nothing

            Form1.CtrlGeneral = New ViewBitacora

            Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
            Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
            SelectedForm = "BITACORA"

        Else
            Call Aviso("NO AUTORIZADO", "Debe ser Administrador usar esta opción", Form1)
        End If

        Return r
    End Function

    'REPORTES
    Private Function NavReportes() As Boolean
        Dim r As Boolean

        If NivelUsuario = 1 Then
            Try
                Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
            Catch ex As Exception

            End Try
            Form1.CtrlGeneral = Nothing

            Form1.CtrlGeneral = New ViewReportes
            Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
            Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
            SelectedForm = "REPORTES"

        Else
            Call Aviso("No Autorizado", "Solo los Usuarios Administradores puede acceder a esta sección", Form1)
        End If

        Return r

    End Function

    'TIPO DOCUMENTOS
    Private Function NavTipoDocumentos() As Boolean
        Dim r As Boolean

        If NivelUsuario = 1 Then
            Try
                Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
            Catch ex As Exception

            End Try
            Form1.CtrlGeneral = Nothing
            Form1.CtrlGeneral = New viewTipoDocumentos
            Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
            Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
            SelectedForm = "TIPODOCUMENTOS"
            r = True
        Else
            Call Aviso("NO AUTORIZADO", "Usted no puede ingresar a esta sección", Form1)
            Return False
            Exit Function
        End If

        Return r
    End Function

    'CONFIGURACIONES
    Private Function NavConfig() As Boolean
        Dim result As Boolean

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_Config
        SelectedForm = "CONFIG"

        Form1.imgLogo.Image = LogoEmpresa


        Call Form1.CargarGridEmpresas()


        Return result

    End Function

#End Region

#Region " ** OPERACIONES **"

    'ORDEN DE PRODUCCION
    Private Function NavOrdenProduccion() As Boolean

        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewOrdenProduccion
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "ORDENPROD"

        r = True
        Return r

    End Function

    'VENTAS
    Private Function NavVentas() As Boolean

        If NivelUsuario <> 2 Then

            Form1.dgvVentasEmpOBJ.Size = New Size(245, 253)
            Form1.btnVentasVaciarDoc.Size = New Size(78, 23)
            Form1.dgvVentasEmpOBJ.Location = New Point(333, 55)
            Form1.btnVentasVaciarDoc.Location = New Point(623, 48)
            Form1.cmdVentasGuardar.Location = New Point(608, 9)
            Form1.cmdVentasCobrar.Location = New Point(608, 9)

        Else

            Form1.dgvVentasEmpOBJ.Size = New Size(400, 257)
            Form1.btnVentasVaciarDoc.Size = New Size(78, 33)
            Form1.dgvVentasEmpOBJ.Location = New Point(333, 51)
            Form1.btnVentasVaciarDoc.Location = New Point(642, 11)
            Form1.cmdVentasGuardar.Location = New Point(528, 11)
            Form1.cmdVentasCobrar.Location = New Point(528, 11)

        End If

        GlobalBool = False ' DETERMINA SI VIENE DE LA VENTANA DE PEDIDOS PRE-VENTA
        GlobalModoPOS = False

        'verifica el modo código para mostrar el botón de modo código
        Form1.btnVentasModoCodigo.Visible = Form1.SwitchConfigModoCodigoVentas.IsOn

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_Facturacion
        Call Form1.CargarFechasDocumentos()

        SelectedForm = "VENTAS"

        'carga el coddoc en ventas
        If Form1.fcn_ControladoresTemporales(SelectedForm) = True Then

        End If

        Form1.txtVentasFecha.DateTime = Today.Date

        Call CargarCorrelativoVentas()

        Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Form1.txtVentasCorrelativo.Text))

        Call CargarGridTempVentas()
        Call Form1.CargarDGVListaProductos(1)
        Form1.LbVentasTitulo.Text = "Facturación"
        Form1.cmdVentasCobrar.Visible = True 'OCULTO EL BOTÓN DE COBRAR PORQUE NO APLICA EN ESTE CASO
        Form1.cmdVentasGuardar.Visible = False 'MUESTRO EL BOTON GUARDAR O TERMINAR
        Form1.cmdVentasTomarDatos.Visible = True
        Form1.cmbVentasVendedor.select()
        Form1.lbventasImprime.Visible = True
        Form1.SwitchImprimirTicket.Visible = True
        Form1.btnVentasPse.Visible = False 'OCULTA EL BOTON PARA EVITAR QUE EN FACTURACION SE VEA EL BOTON DE PRODUCTOS SIN EXISTENCIA

        Call Form1.getObjetivoVenta()
        Call Form1.getRentabilidadTotalMes()
        Call Form1.getRentabilidadTotalDia()
        Call Form1.CargarDGVVentaEmp()
        Call Form1.getObjetivoDiario()

        'OBTIENE LAS CAJAS ABIERTAS
        Call Form1.getCajas()
        If Form1.cmbVentasCaja.SelectedIndex >= 0 Then


            Dim objDoc As New classCorteCaja()
            If objDoc.comprobarCajaAbierta(GlobalSelectedCodCaja) = True Then
                Form1.cmbVentasCaja.SelectedValue = GlobalSelectedCodCaja
            Else
                MsgBox("AVISO IMPORTANTE, POR FAVOR VERIFIQUE")
                MsgBox("SU CAJA PREDETERMINADA NO ESTÁ ABIERTA, POR FAVOR ÁBRALA SI FUERA NECESARIO")
                fcn_HablarTexto("SU CAJA PREDETERMINADA NO ESTÁ ABIERTA, POR FAVOR ÁBRALA SI FUERA NECESARIO")
            End If
        Else

            MsgBox("Importante, esta venta no se registrará en ninguna caja, primero debe abrir una caja para poder operar")
            Call NAVEGAR("CORTECAJA")
        End If

        Form1.checkMOS.Checked = True

    End Function

    'Private Function NavVentasNEW() As Boolean

    'Try
    '       Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
    'Catch ex As Exception
    'End Try
    '   Form1.CtrlGeneral = Nothing
    '  Form1.CtrlGeneral = New viewPOS
    ' Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
    'Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
    'SelectedForm = "VENTAS"

    'End Function

    'COTIZACIONES
    Private Function NavCotizaciones() As Boolean

        SelectedForm = "COTIZACIONES"
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_Facturacion
        'carga el coddoc en ventas
        If Form1.fcn_ControladoresTemporales(SelectedForm) = True Then

        End If

        Call CargarCorrelativoVentas()

        Call CargarTotalVenta(GlobalCoddocCOTIZ, Double.Parse(Form1.txtVentasCorrelativo.Text))

        Call CargarGridTempVentas()
        Call Form1.CargarDGVListaProductos(1)

        Form1.LbVentasTitulo.Text = "Cotización"
        Form1.cmdVentasCobrar.Visible = False 'OCULTO EL BOTÓN DE COBRAR PORQUE NO APLICA EN ESTE CASO
        Form1.cmdVentasGuardar.Visible = True 'MUESTRO EL BOTON GUARDAR O TERMINAR
        Form1.cmdVentasTomarDatos.Visible = False
        Form1.cmbVentasVendedor.select()
        Form1.lbventasImprime.Visible = False
        Form1.SwitchImprimirTicket.Visible = False
        Form1.btnVentasPse.Visible = True 'muestra el boton de productos sin existencia

    End Function

    'ENVIOS O PEDIDOS
    Private Function NavEnvios() As Boolean

        GlobalModoPOS = False
        SelectedForm = "ENVIOS"
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_Facturacion
        'carga el coddoc en ventas
        If Form1.fcn_ControladoresTemporales(SelectedForm) = True Then

        End If

        Call CargarCorrelativoVentas()

        Call CargarTotalVenta(GlobalCoddocENVIOS, Double.Parse(Form1.txtVentasCorrelativo.Text))

        Call CargarGridTempVentas()
        Call Form1.CargarDGVListaProductos(1)
        Form1.LbVentasTitulo.Text = "Pedidos"
        Form1.cmdVentasCobrar.Visible = False 'OCULTO EL BOTÓN DE COBRAR PORQUE NO APLICA EN ESTE CASO
        Form1.cmdVentasGuardar.Visible = True 'MUESTRO EL BOTON GUARDAR O TERMINAR
        Form1.cmdVentasTomarDatos.Visible = False
        Form1.cmbVentasVendedor.select()
        Form1.lbventasImprime.Visible = False
        Form1.SwitchImprimirTicket.Visible = False
        Form1.btnVentasPse.Visible = True 'muestra el boton de productos sin existencia

    End Function

    'COMPRAS
    Private Function NavComprasold() As Boolean

        'SelectedForm = "COMPRAS"
        'Form1.NavigationFrameMain.SelectedPage = Form1.NP_Compras

        'Form1.lbTituloCompras.Text = "COMPRASold"
        'Form1.btnComprasEditarPrecios.Visible = True
        'Form1.btnComprasTomarDatos.Visible = True

        'carga el coddoc en ventas
        'If Form1.fcn_ControladoresTemporales(SelectedForm) = True Then

        'End If

        'Call Form1.CargarFechasDocumentos()

        'Call CargarCorrelativoVentas()
        'Call Form1.CargarTotalCompra(GlobalCoddocCOMPRA, Double.Parse(Form1.txtComprasCorrelativo.Text))
        'Call CargarGridTempVentas()
        'Call Form1.CargarDGVListaProductosCompras(1)

        'Form1.txtComprasCodProducto.select()

    End Function

    Private Function NavCompras() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception
        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewCompras
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "COMPRAS"

    End Function

    'ORDEN COMPRA
    Private Function NavOrdenCompra() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception
        End Try
        SelectedForm = "ORDEN_COMPRA"

        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewCompras
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL


        'SelectedForm = "ORDENCOMPRA"
        'Form1.NavigationFrameMain.SelectedPage = Form1.NP_Compras

        'Form1.lbTituloCompras.Text = "ORDEN DE COMPRA"
        'Form1.btnComprasEditarPrecios.Visible = False
        'Form1.btnComprasTomarDatos.Visible = False

        'carga el coddoc en ventas
        'If Form1.fcn_ControladoresTemporales(SelectedForm) = True Then

        'End If

        'Call Form1.CargarFechasDocumentos()

        'Call CargarCorrelativoVentas()
        'Call Form1.CargarTotalCompra(GlobalCoddocORDENCOMPRA, Double.Parse(Form1.txtComprasCorrelativo.Text))
        'Call CargarGridTempVentas()
        'Call Form1.CargarDGVListaProductosCompras(1)

        'Form1.txtComprasCodProducto.select()

    End Function

    'GASTOS
    Private Function NavGastos() As Boolean

        If FlyoutDialog.Show(Form1.ParentForm, New viewGastos) = DialogResult.OK Then

        End If

    End Function

    'CORTE DE CAJA
    Private Function NavCorteCaja() As Boolean

#Region "ANTERIOR"

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception
        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewCorteCaja
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "CORTECAJA"

#End Region


    End Function

    'IEF

    Private Function NavIEF() As Boolean

        'If FlyoutDialog.Show(Form1.ParentForm, New viewIngresoEfec) = DialogResult.OK Then

        'End If

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception
        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewIngresoEfec
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "IEF"

    End Function

    'CXC CUENTAS POR COBRAR
    Private Function NavCxc() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New ViewCxc
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "CXC"

    End Function

    'CXP
    Private Function NavCxp() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewCxp

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)


        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "CXP"

    End Function

    'ORDEN TRABAJO
    Private Function NavOrdenTrabajo() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewOrdenTrabajo
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "ORDENTRABAJO"

    End Function

    'DEVOLUCIONES
    Private Function NavDevoluciones() As Boolean

        If FlyoutDialog.Show(Form1.ParentForm, New viewDevoluciones) = DialogResult.OK Then

        End If

    End Function

    'EMBARQUES
    Private Function NavEmbarques() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception
            MsgBox("error: " + ex.ToString)
        End Try


        Form1.CtrlGeneral = Nothing

        SelectedForm = "EMBARQUES"

        'Form1.CtrlGeneral = New expresso_embarques.view_facturacion(GlobalEmpNit, cn)
        Form1.CtrlGeneral = New viewGestionEmbarques

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL


    End Function

#End Region

#Region " ** INVENTARIOS ** "

    'CATALOGO DE PRODUCTOS
    Private Function NavCatalogoProductos() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New ViewProductos
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "CATALOGO"

    End Function

    'ETIQUETAS
    Private Function NavInventariosEtiquetas() As Boolean
        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewEtiquetas
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "ETIQUETAS"
        Return True
    End Function

    'LISTADO DE PRECIOS
    Private Function NavInventariosListaPrecios() As Boolean
        Dim r As Boolean

        'If NivelUsuario = 1 Then

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewListaPrecios
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "LISTAPRECIOS"
        'Else
        'Call Aviso("NO AUTORIZADO", "Debe ser Administrador para ingresar a esta sección", Form1)
        'End If

        Return r
    End Function

    Private Function NavInventariosListaPreciosComp() As Boolean
        Dim r As Boolean

        'If NivelUsuario = 1 Then

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewListaPreciosComp
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "LISTAPRECIOSCOMP"
        'Else
        'Call Aviso("NO AUTORIZADO", "Debe ser Administrador para ingresar a esta sección", Form1)
        'End If

        Return r
    End Function

    'INVENTARIOS
    Private Function NavInventarios() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New ViewInventarios
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "INVENTARIOS"

    End Function

    'TRANSFERIR 
    Private Function NavInventariosTransferir(ByVal desde As String) As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New viewTrasladoInventario(desde)
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "TRANSFERIR"

    End Function

    'INV MINIMOS
    Private Function NavInventariosMinimos() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewInventariosMinimos

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "INVMINIMOS"

    End Function

    'INV VENCIDOS
    Private Function NavInventariosVencidos() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewProductosVencimiento(True)

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "INVVENCIDOS"

    End Function

    'TRASLADOS SALIDA BODEGA
    Private Function NavTrasSalBod() As Boolean

        SelectedForm = "TRASSAL"
        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewTras
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "TRASSAL"

    End Function


    'TRASLADOS SALIDA SUCURSAL
    Private Function NavTrasSalSuc() As Boolean

        'Form1.NavigationFrameMain.SelectedPage = Form1.NP_MovInv
        SelectedForm = "TRASSALSUC"
        'Form1.txtMovInvTipo.Text = "SALIDA HACIA SUCURSAL"
        'Form1.cmbtipovencidos.Visible = False
        'Form1.LabelControl10.Visible = False

        'If GlobalEmpNit = "COMPRAS" Then
        'Form1.CheckBoxOBJ1.Visible = False
        'Form1.CheckBoxOBJ2.Visible = False
        'Form1.LabelControl130.Visible = False
        'Else

        'End If

        'carga el coddoc en INVENTARIOS
        'If Form1.fcn_ControladoresTemporales(SelectedForm) = True Then
        'End If

        'Call Form1.CargarFechasDocumentos()

        'Call Form1.CargarDGVListaProductos_MOVINV(1)
        'Call CargarCorrelativoVentas()
        'Call CargarGridTempVentas_movinv()
        'Call CargarTotalVenta(Form1.cmbSerieMovInv.SelectedValue.ToString, Double.Parse(Form1.txtMovInvCorrelativo.Text))


        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewTras
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "TRASSALSUC"

    End Function

    'TRASLADOS SALIDA VENCIDOS
    Private Function NavTrasSalProv() As Boolean

        SelectedForm = "TRASSALPROV"

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewTras
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "TRASSALPROV"

    End Function


    'TRASLADOS SALIDA VENCIDOS
    Private Function NavTrasSalVenc() As Boolean

        SelectedForm = "TRASSALVENC"

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewTras
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "TRASSALVENC"

    End Function

    'INVENTARIO FISICO
    Private Function NavInvFisico() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewInvFisico
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "INVFISICO"

    End Function

#End Region

#Region " ** MANTENIMIENTOS  ** "

    'MANTENIMIENTOS
    Private Function NavMantenimientos() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing
        Form1.CtrlGeneral = New ViewMantenimientos
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "MANTENIMIENTOS"

    End Function

    'EMPLEADOS
    Private Function NavMantenimientosEmpleados() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New ViewEmpleados

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "VENDEDORES"

    End Function

    'CLIENTES
    Private Function NavMantenimientosClientes() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewClientes
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "CLIENTES"

    End Function

    'PROVEEDORES
    Private Function NavMantenimientosProveedores() As Boolean

        'Form1.NavigationFrameMain.SelectedPage = Form1.NP_Proveedores
        'SelectedForm = "PROVEEDORES"
        'Call Form1.CargarGridProveedores()
        'Form1.txtProveedoresNit.select()

    End Function

    'REPARTIDORES
    Private Function NavMantenimientosRepartidores() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewRepartidores

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "REPARTIDORES"

    End Function

    'VEHICULOS CLIENTES
    Private Function NavMantenimientosVehiculos() As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewClientesVehiculos("CATALOGO")
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "CLIENTES_VEHICULOS"

    End Function

#End Region

#Region " ** HOST ** "

    Private Function NavGestionPreciosSucursales() As Boolean
        If NivelUsuario = 1 Then
            Try
                Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
            Catch ex As Exception
                MsgBox("error: " + ex.ToString)
            End Try


            Form1.CtrlGeneral = Nothing

            SelectedForm = "ONLINE_PRECIOS_SUCURSALES"

            Form1.CtrlGeneral = New viewGestionPreciosSucursal

            Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
            Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        Else
            Call Aviso("NO AUTORIZADO", "Debe ser Administrador usar esta opción", Form1)
        End If

        Return True
    End Function

    'PEDIDOS DOMICILIO
    Private Function NavPedidosDomicilio() As Boolean

#Region "ANTERIOR"

        'Dim r As Boolean
        'Try
        'Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        'Catch ex As Exception
        'End Try
        'Form1.CtrlGeneral = Nothing
        'Form1.CtrlGeneral = New viewPedidosDomicilio
        'Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        'Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        'SelectedForm = "DOMICILIO"
        'Return r

#End Region

        If FlyoutDialog.Show(Form1.ParentForm, New viewPedidosDomicilio) = DialogResult.OK Then

        End If

    End Function

    'OBTIENE LAS VENTAS DOMICILIO ALOJADOS EN EL HOST
    Private Function NavGetVentasDomicilio() As Boolean

        If Confirmacion("¿Está seguro que desea descargar las VENTAS de SERVICIO A DOMICILIO?", Form1.ParentForm) = True Then

            SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
            'If objs.VerificarPagoToken() = True Then


            Call Form1.Mensaje("Obteniendo ventas")
            Try

                Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/VENTAS-DOMICILIO" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"

                Dim anio As Integer = CType(Today.Date.Year, Integer)
                Dim mes As Integer = CType(Today.Date.Month, Integer)

                Dim tbl As New DataTable
                Form1.GridExportsGeneral.DataSource = tbl
                Form1.GridExportsGeneral.Refresh()

                Form1.GridExportsGeneral.DataSource = objs.getVentasDomicilio(anio, mes)
                Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                Form1.GridExportsGeneral.DataSource = Nothing
                SplashScreenManager.CloseForm()

                Process.Start(strNombreAchivo)

                Call Form1.Mensaje("DOMICILIO descargado exitosamente")
            Catch ex As Exception
                SplashScreenManager.CloseForm()
                MsgBox(ex.ToString)
            End Try

            'Else
            'SplashScreenManager.CloseForm()
            'MsgBox("Mala conexión a internet o token deshabilitado, revise su conexión a internet e inténtelo nuevamente")
            'End If

        End If

    End Function

    'OBTIENE LAS VENTAS DOMICILIO ALOJADOS EN EL HOST FECHA

    Private Function NavGetVentasDomicilio2() As Boolean

        If Confirmacion("¿Está seguro que desea descargar las VENTAS de SERVICIO A DOMICILIO?", Form1.ParentForm) = True Then

            SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
            'If objs.VerificarPagoToken() = True Then


            Call Form1.Mensaje("Obteniendo ventas")
            Try

                Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/VENTAS-DOMICILIO" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"

                Dim anio As Integer = CType(Today.Date.Year, Integer)
                Dim mes As Integer = CType(Today.Date.Month, Integer)

                Dim tbl As New DataTable
                Form1.GridExportsGeneral.DataSource = tbl
                Form1.GridExportsGeneral.Refresh()

                Form1.GridExportsGeneral.DataSource = objs.getVentasDomicilioFECHA(GlobalParamDatePickI, GlobalParamDatePickF)
                Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                Form1.GridExportsGeneral.DataSource = Nothing
                SplashScreenManager.CloseForm()

                Process.Start(strNombreAchivo)

                Call Form1.Mensaje("DOMICILIO descargado exitosamente")
            Catch ex As Exception
                SplashScreenManager.CloseForm()
                MsgBox(ex.ToString)
            End Try

            'Else
            'SplashScreenManager.CloseForm()
            'MsgBox("Mala conexión a internet o token deshabilitado, revise su conexión a internet e inténtelo nuevamente")
            'End If

        End If

    End Function

    'OBTIENE LAS VENTAS ALOJADOS EN EL HOST
    Private Function NavGetVentasOnline() As Boolean

        If Confirmacion("¿Está seguro que desea descargar las VENTAS de todas las sucursales?", Form1.ParentForm) = True Then

            SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
            'If objs.VerificarPagoToken() = True Then

            Call Form1.Mensaje("Obteniendo inventarios")
            Try

                Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/VENTAS-SUCURSALES" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"

                Dim anio As Integer = CType(Today.Date.Year, Integer)
                Dim mes As Integer = CType(Today.Date.Month, Integer)

                Dim tbl As New DataTable
                Form1.GridExportsGeneral.DataSource = tbl
                Form1.GridExportsGeneral.Refresh()

                Form1.GridExportsGeneral.DataSource = objs.getVentasSucursales(anio, mes)
                Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                Form1.GridExportsGeneral.DataSource = Nothing
                SplashScreenManager.CloseForm()

                Process.Start(strNombreAchivo)

                Call Form1.Mensaje("CORTES descargados exitosamente")
            Catch ex As Exception
                SplashScreenManager.CloseForm()
                MsgBox(ex.ToString)
            End Try

            'Else
            'SplashScreenManager.CloseForm()
            'MsgBox("Mala conexión a internet o token deshabilitado, revise su conexión a internet e inténtelo nuevamente")
            'End If
        End If

    End Function

    'OBTIENE LAS VENTAS ALOJADOS EN EL HOST FECHA

    Private Function NavGetVentasOnline2() As Boolean

        If Confirmacion("¿Está seguro que desea descargar las VENTAS de todas las sucursales?", Form1.ParentForm) = True Then

            SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)



            Call Form1.Mensaje("Obteniendo inventarios")
            Try


                Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/VENTAS-SUCURSALES" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"

                Dim anio As Integer = CType(Today.Date.Year, Integer)
                Dim mes As Integer = CType(Today.Date.Month, Integer)

                Dim tbl As New DataTable
                Form1.GridExportsGeneral.DataSource = tbl
                Form1.GridExportsGeneral.Refresh()

                Form1.GridExportsGeneral.DataSource = objs.getVentasSucursalesFECHA(GlobalParamDatePickI, GlobalParamDatePickF)
                Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                Form1.GridExportsGeneral.DataSource = Nothing
                SplashScreenManager.CloseForm()

                Process.Start(strNombreAchivo)

                Call Form1.Mensaje("CORTES descargados exitosamente")
            Catch ex As Exception
                SplashScreenManager.CloseForm()
                MsgBox(ex.ToString)
            End Try



        End If

    End Function


    'OBTIENE LOS DOCUMENTOS CONTA ONLINE
    Private Function NavGetDocumentosContaOnline() As Boolean

        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If Confirmacion("¿Está seguro que desea descargar la lista de DOCUMENTOS CONTABLES de todas las sucursales?", Form1.ParentForm) = True Then

                If FlyoutDialog.Show(Form1, New viewParamMesAnio) = DialogResult.OK Then
                    SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                    Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)


                    Call Form1.Mensaje("Obteniendo documentos")

                    Try


                        Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/DOCUMENTOSCONTA-SUCURSALES" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"

                        Dim anio As Integer = CType(Today.Date.Year, Integer)
                        Dim mes As Integer = CType(Today.Date.Month, Integer)

                        Dim tbl As New DataTable
                        'Form1.GridExportsGeneral.DataSource = tbl
                        'Form1.GridExportsGeneral.Refresh()

                        Form1.dgvGeneralExports.DataSource = Nothing
                        Form1.dgvGeneralExports.DataSource = objs.getDocumentosSucursales(GlobalParamAnio, GlobalParamMes)
                        Form1.dgvGeneralExports.Refresh()

                        Call fcn_exportDgvToExcel(Form1.dgvGeneralExports, strNombreAchivo)

                        Form1.dgvGeneralExports.DataSource = Nothing

                        'Form1.GridExportsGeneral.DataSource = objs.getVentasSucursales(anio, mes)
                        'Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                        'Form1.GridExportsGeneral.DataSource = Nothing


                        SplashScreenManager.CloseForm()

                        Process.Start(strNombreAchivo)

                        Call Form1.Mensaje("Documentos descargados exitosamente")

                    Catch ex As Exception
                        SplashScreenManager.CloseForm()
                        MsgBox(ex.ToString)
                    End Try
                End If

            End If

        End If

    End Function

    'OBTIENE EL INVENTARIO DE TODAS LAS SUCURSALES
    Private Function NavGetInventarioOnline() As Boolean

        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If Confirmacion("¿Está seguro que desea descargar el inventario de todas las sucursales?", Form1.ParentForm) = True Then

                SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

                Call Form1.Mensaje("Obteniendo inventarios")
                Try

                    Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/INVENTARIOSUCURSALES" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"

                    Dim tbl As New DataTable
                    Form1.GridExportsGeneral.DataSource = tbl
                    Form1.GridExportsGeneral.Refresh()

                    Form1.GridExportsGeneral.DataSource = objs.getInventarioSucursales(GlobalAnioProceso, GlobalMesProceso)
                    Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                    Form1.GridExportsGeneral.DataSource = Nothing
                    SplashScreenManager.CloseForm()

                    Process.Start(strNombreAchivo)

                    Call Form1.Mensaje("Inventario descargado exitosamente")
                Catch ex As Exception
                    SplashScreenManager.CloseForm()
                    MsgBox(ex.ToString)
                End Try

            End If

        End If

    End Function

    'OBTIENE LOS CORTES ALOJADOS EN EL HOST
    Private Function NavGetCortesOnline() As Boolean

        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If Confirmacion("¿Está seguro que desea descargar los CORTES DE CAJA de todas las sucursales?", Form1.ParentForm) = True Then

                SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

                Call Form1.Mensaje("Obteniendo cortes")
                Try

                    Form1.GridExportsGeneral.DataSource = Nothing
                    Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/CORTES-SUCURSALES" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"

                    Dim anio As Integer = CType(Today.Date.Year, Integer)
                    Dim mes As Integer = CType(Today.Date.Month, Integer)

                    Dim tbl As New DataTable
                    Form1.GridExportsGeneral.DataSource = tbl
                    Form1.GridExportsGeneral.Refresh()

                    Form1.GridExportsGeneral.DataSource = objs.getCortesSucursales(anio, mes)
                    Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                    Form1.GridExportsGeneral.DataSource = Nothing
                    SplashScreenManager.CloseForm()

                    Process.Start(strNombreAchivo)

                    Call Form1.Mensaje("CORTES descargados exitosamente")
                Catch ex As Exception
                    SplashScreenManager.CloseForm()
                    MsgBox(ex.ToString)
                End Try

            End If

        End If

    End Function


    'OBTIENE LOS CORTES ALOJADOS EN EL HOST CON SELECCION DE FECHAS
    Private Function NavGetCortesOnline2() As Boolean

        If Confirmacion("¿Está seguro que desea descargar los CORTES DE CAJA de todas las sucursales?", Form1.ParentForm) = True Then

            SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)


            Call Form1.Mensaje("Obteniendo cortes")
            Try

                Form1.GridExportsGeneral.DataSource = Nothing
                Dim strNombreAchivo As String = Application.StartupPath + "/EXPORTS/CORTES-SUCURSALES" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".XLSX"


                Dim tbl As New DataTable
                Form1.GridExportsGeneral.DataSource = tbl
                Form1.GridExportsGeneral.Refresh()

                Form1.GridExportsGeneral.DataSource = objs.getCortesSucursalesFechas(GlobalParamDatePickI, GlobalParamDatePickF)
                Form1.GridExportsGeneral.ExportToXlsx(strNombreAchivo)
                Form1.GridExportsGeneral.DataSource = Nothing
                SplashScreenManager.CloseForm()

                Process.Start(strNombreAchivo)

                Call Form1.Mensaje("CORTES descargados exitosamente")
            Catch ex As Exception
                SplashScreenManager.CloseForm()
                MsgBox(ex.ToString)
            End Try

        End If

    End Function

    Dim codsuc As Integer

    Private Function getTipoEmpresa()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODTIPOEMPRESA
                                        FROM EMPRESAS  where EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                codsuc = Integer.Parse(dr(0).ToString)
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using

    End Function

    'SYNCRONIZAR PRODUCTOS Y PRECIOS
    Private Function NavSyncPrecios() As Boolean
        'fgdfdgfdg
        Dim r As Boolean

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

        'If objS.VerificarPagoToken() = True Then

        If Confirmacion("¿Está seguro que desea llevar a cabo la sincronización?, se borrarán todos sus productos y precios", Form1.ParentForm) = True Then

            Dim objProd As New ClassProductos
            objProd.deleteBackupProductosSync(GlobalEmpNit)

            Dim strBackupdata As String = "BACKUP" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

            SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            '1) descarga los productos a la tabla TEMP_PRODUCTOS, 
            'descarga la tabla TEMP_INVSALDO
            'descarga TEMP_PRECIOS

            If objS.GetProductosInvsaldoPreciosTemp(GlobalEmpNit, GlobalEmpNit) = True Then

                '2) cambia el empnit de las tablas principales
                If objS.SetBackupProductosPreciosInvsaldo2(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then

                    '3) finalmente reemplaza el catàlogo principal por los que se encuentran en la tabla temp
                    If objS.replaceProductosInvsaldoPreciosTemp(GlobalEmpNit) = True Then

                        'actualiza el costo de los precios
                        If objS.UpdCostoProductos(GlobalEmpNit) = True Then
                        Else
                            Call Form1.Mensaje("Error al actualizar costos de precios. " & objS.DesError)
                        End If

                        'actualiza el inventario
                        'If objS.UpdateProductosInvsaldo(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then

                        'Else
                        'Call Form1.Mensaje("No se pudo actualizar las existencias, por favor inténtelo manualmente")
                        'End If

                        Call NavACTINV_2CORTE()

                        'Call Aviso("EXITO", "Se ha descargado el catálogo de productos y precios", Form1)
                    End If
                    'MsgBox(objS.DesError)
                Else
                    'NO SE ESTABLECIÒ EL BACKUP
                End If
            End If

            SplashScreenManager.CloseForm()
            Call Form1.Mensaje("Proceso finalizado exitosamente")
        End If

        'Else
        'MsgBox("Token deshabilitado o falló la conexión al host")
        'End If

        Return r



    End Function

    Private Function NavSyncPrecios2() As Boolean
        'fgdfdgfdg
        Dim r As Boolean

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

        'If objS.VerificarPagoToken() = True Then

        If Confirmacion("¿Está seguro que desea llevar a cabo la sincronización?, se borrarán todos sus productos y precios", Form1.ParentForm) = True Then

            Dim objProd As New ClassProductos
            objProd.deleteBackupProductosSync(GlobalEmpNit)

            Dim strBackupdata As String = "BACKUP" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

            SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            '1) descarga los productos a la tabla TEMP_PRODUCTOS, 
            'descarga la tabla TEMP_INVSALDO
            'descarga TEMP_PRECIOS

            If objS.GetProductosInvsaldoPreciosTemp2(GlobalEmpNit, GlobalEmpNit) = True Then

                '2) cambia el empnit de las tablas principales
                If objS.SetBackupProductosPreciosInvsaldo2(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then

                    '3) finalmente reemplaza el catàlogo principal por los que se encuentran en la tabla temp
                    If objS.replaceProductosInvsaldoPreciosTemp(GlobalEmpNit) = True Then

                        'actualiza el costo de los precios
                        If objS.UpdCostoProductos(GlobalEmpNit) = True Then
                        Else
                            Call Form1.Mensaje("Error al actualizar costos de precios. " & objS.DesError)
                        End If

                        'actualiza el inventario
                        'If objS.UpdateProductosInvsaldo(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then

                        'Else
                        'Call Form1.Mensaje("No se pudo actualizar las existencias, por favor inténtelo manualmente")
                        'End If

                        Call NavACTINV_2CORTE()

                        'Call Aviso("EXITO", "Se ha descargado el catálogo de productos y precios", Form1)
                    End If
                    'MsgBox(objS.DesError)
                Else
                    'NO SE ESTABLECIÒ EL BACKUP
                End If
            End If

            SplashScreenManager.CloseForm()
            Call Form1.Mensaje("Proceso finalizado exitosamente")
        End If

        'Else
        'MsgBox("Token deshabilitado o falló la conexión al host")
        'End If

        Return r



    End Function


    'SYNCRONIZAR PRODUCTOS Y PRECIOS
    Private Function NavSyncPrecios_old() As Boolean

        Dim r As Boolean

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)



        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
            If Confirmacion("¿Está seguro que desea llevar a cabo la sincronización?, se borrarán todos sus productos y precios", Form1.ParentForm) = True Then

                Dim objProd As New ClassProductos
                objProd.deleteBackupProductosSync(GlobalEmpNit)

                Dim strBackupdata As String = "BACKUP" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

                SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                '1) descarga los productos a la tabla TEMP_PRODUCTOS, 
                'descarga la tabla TEMP_INVSALDO
                'descarga TEMP_PRECIOS
                If objS.GetProductosInvsaldoPreciosTemp(GlobalEmpNit, GlobalEmpNit) = True Then

                    '2) cambia el empnit de las tablas principales
                    If objS.SetBackupProductosPreciosInvsaldo2(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then

                        '3) finalmente reemplaza el catàlogo principal por los que se encuentran en la tabla temp
                        If objS.replaceProductosInvsaldoPreciosTemp(GlobalEmpNit) = True Then

                            'actualiza el costo de los precios
                            If objS.UpdCostoProductos(GlobalEmpNit) = True Then
                            Else
                                Call Form1.Mensaje("Error al actualizar costos de precios. " & objS.DesError)
                            End If

                            'actualiza el inventario
                            If objS.UpdateProductosInvsaldo(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then
                            Else
                                Call Form1.Mensaje("No se pudo actualizar las existencias, por favor inténtelo manualmente")
                            End If

                            'Call Aviso("EXITO", "Se ha descargado el catálogo de productos y precios", Form1)
                        End If
                        'MsgBox(objS.DesError)
                    Else
                        'NO SE ESTABLECIÒ EL BACKUP
                    End If
                End If

                SplashScreenManager.CloseForm()
                Call Form1.Mensaje("Proceso finalizado exitosamente")
            End If

        Else
            MsgBox("Debe escribir la palabra AUTORIZADO para poder obtener los productos")
        End If


        Return r



    End Function




    Private Function NavSyncPreciosBackup() As Boolean
        Dim r As Boolean

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
            If Confirmacion("¿Está seguro que desea llevar a cabo la sincronización?, se borrarán todos sus productos y precios", Form1.ParentForm) = True Then

                Dim strBackupdata As String = "BACKUP" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

                SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Call Form1.Mensaje("Eliminando backup anterior")
                'ELIMINA EL BACKUP DE PRODUCTOS Y PRECIOS GUARDADO PREVIAMENTE
                If objS.DeleteBackupProductosPreciosInvsaldo() = True Then
                    Call Form1.Mensaje("Intentando crear un backup de los productos y precios actuales")

                    'CAMBIA EL EMPNIT=BACKUP A LOS PRODUCTOS Y PRECIOS EXISTENTES POR CUALQUIER COSA
                    If objS.SetBackupProductosPreciosInvsaldo(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = False Then

                        SplashScreenManager.CloseForm()
                        MsgBox("Ha ocurido un error al generar el backup del catálogo actual. Error " & objS.DesError.ToString)

                        'OBTIENE EL TIPO PRECIO DE LA SUCURSAL
                        Dim tipo As String = objS.getTipoPrecioSucursal(GlobalEmpNit)

                        Call Form1.Mensaje("Obteniendo productos y precios del servidor principal")
                        'OBTIENE LOS PRODUCTOS, PRECIOS E INVENTARIO DEL HOST
                        If objS.GetProductosPreciosInvsaldo(GlobalEmpNit, GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, tipo) = True Then


                            If objS.UpdateProductosInvsaldo(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then

                            Else
                                Call Form1.Mensaje("No se pudo actualizar las existencias, por favor inténtelo manualmente")
                            End If

                            SplashScreenManager.CloseForm()
                            Call Aviso("Operación Exitosa", "Se cargado el catálogo de productos y precios", Form1.ParentForm)

                        Else
                            SplashScreenManager.CloseForm()
                            MsgBox("Error al cargar el catálogo principal. Error: " & objS.DesError)
                        End If
                    End If

                Else
                    MsgBox("No se puede proceder ya que no se a logrado eliminar el backup de productos y precios guardados previamente")
                End If


            End If
        End If


        Return r
    End Function


    'SYNCRONIZAR PRODUCTOS EXCEPTUANDO LOS PRECIOS
    Private Function NavSyncProductos() As Boolean
        Dim r As Boolean

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

        If InputBox("Escriba AUTORIZADO para continuar") = "AUTORIZADO" Then
            If Confirmacion("¿Está seguro que desea llevar a cabo la sincronización?, se borrarán todos sus productos y mantendrá sus precios", Form1.ParentForm) = True Then

                Dim strBackupdata As String = "BACKUP" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

                SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                '1) descarga los productos a la tabla TEMP_PRODUCTOS, descarga la tabla TEMP_INVSALDO
                If objS.GetProductosInvsaldoTemp(GlobalEmpNit, GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso) = True Then

                    '2) cambia el empnit de las tablas principales
                    If objS.SetBackupProductosPreciosInvsaldo3(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then

                        '3) finalmente reemplaza el catàlogo principal por los que se encuentran en la tabla temp
                        If objS.replaceProductosInvsaldoTemp(GlobalEmpNit) = True Then

                            'actualiza el costo de los precios
                            If objS.UpdCostoProductos(GlobalEmpNit) = True Then
                            Else
                                Call Form1.Mensaje("Error al actualizar costos de precios. " & objS.DesError)
                            End If

                            'actualiza el inventario
                            If objS.UpdateProductosInvsaldo(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso, strBackupdata) = True Then
                            Else
                                Call Form1.Mensaje("No se pudo actualizar las existencias, por favor inténtelo manualmente")
                            End If

                            'Call Aviso("EXITO", "Se ha descargado el catálogo de productos", Form1)

                        End If
                        'MsgBox(objS.DesError)
                    Else
                        'NO SE ESTABLECIÒ EL BACKUP
                    End If
                End If

                SplashScreenManager.CloseForm()
                Call Form1.Mensaje("Proceso finalizado exitosamente")
            End If

        Else
            MsgBox("Debe escribir la palabra AUTORIZADO para poder obtener los productos")
        End If

        Return r
    End Function

    'PLANTILLA DE PRODUCTOS
    Private Function NavPlantillaProd() As Boolean

        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If Confirmacion("¿Está perfectamente seguro que desea establecer su catálogo de productos y precios como el catálogo principal?", Form1.ParentForm) = True Then

                SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

                Call Form1.Mensaje("Eliminando Productos Anteriores")

                If objs.DeleteProductosPreciosInvsaldo = True Then
                    If objs.PostProductosPreciosInvsaldo(GlobalEmpNit) = True Then
                        SplashScreenManager.CloseForm()
                        Call Aviso("Operación exitosa", "Productos y precios establecidos exitosamente", Form1.ParentForm)
                    Else
                        SplashScreenManager.CloseForm()
                        MsgBox("No se logró establecer el catálogo de Productos TRASSALSUCy Precios. Error: " & objs.DesError.ToString)
                    End If
                Else
                    SplashScreenManager.CloseForm()
                    MsgBox("No se pudo eliminar el catálogo actual. Error: " & objs.DesError)
                End If

                SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
                'SUBIDA DE DATOS ADICIONALES DE PRODUCTOS
                If objs.delete_productos_ads = True Then

                End If
                If objs.post_productos_ads = True Then
                    Form1.Mensaje("Detalles adicionales subidos exitosamente!!")
                    SplashScreenManager.CloseForm()
                Else
                    Form1.Mensaje("No se pudieron subir los detalles adicionales de productos")
                    SplashScreenManager.CloseForm()
                End If
            End If

        End If

    End Function


    'TRASLADOS EN EL HOST
    Private Function NavSyncTraslados(ByVal tipodoc As String) As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewSyncTablas(tipodoc)

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL

        SelectedForm = "SYNC"

        Return r
    End Function


    'PEDIDOS EN EL ONLINE - MEREFECT
    Private Function NavOnlinePreventas() As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewPedidosPreventa

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "ONLINE_PREVENTAS"

        Return r
    End Function


    'PEDIDOS EN EL HOST
    Private Function NavSyncPedidos() As Boolean
        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewSync

        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)

        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "SYNC"

        Return r
    End Function



#End Region

    Private Function NavDashboard() As Boolean
        Dim r As Boolean

        If NivelUsuario = 1 Then
            Try
                Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
            Catch ex As Exception

            End Try


            Form1.CtrlGeneral = Nothing

            Form1.CtrlGeneral = New viewDashboard

            Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
            Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
            SelectedForm = "DASHBOARD"

        Else
            Call Aviso("NO AUTORIZADO", "Debe ser Administrador usar esta opción", Form1)
        End If

        Return r
    End Function

    'SERVIDORES VPN

    Private Function NavSERV() As Boolean


        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewServidores
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "SERVIDORES"

        Return r


    End Function

    'TRASLADOS VPM

    Private Function NavTRASLADOS() As Boolean


        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewENTRADAS
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "TRASLADOS"

        Return r


    End Function

    'PROGRAMAS VPM

    Private Function NavPROGRAMAS() As Boolean


        Dim r As Boolean

        Try
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
        Catch ex As Exception

        End Try
        Form1.CtrlGeneral = Nothing

        Form1.CtrlGeneral = New viewPROGRAMAS
        Form1.NP_GENERAL.Controls.Add(Form1.CtrlGeneral)
        Form1.NavigationFrameMain.SelectedPage = Form1.NP_GENERAL
        SelectedForm = "PROGRAMAS"

        Return r


    End Function

End Module
