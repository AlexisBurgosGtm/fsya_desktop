Imports System.ComponentModel
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports Security

Partial Public Class Form1

    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.Skins.SkinManager.EnableFormSkins()
    End Sub

    Public Sub New()

        InitializeComponent()

        If AlexisKey() = True Then
        Else
            Call fcn_HablarTexto("Necesita una licencia válida para el uso del sistema, contáctese con su servicio técnico")

            Call Aviso("ERROR DE LICENCIA", "Necesita una licencia válida para utilizar este sistema", Me)

            End

        End If

        'Dim objtiposuc As New tipoSUC.tipoSuc
        'GlobalTipoSistema = objtiposuc.tiposuc

    End Sub

    Dim ps As New Seguridad("razors1805")
    Dim objConection As New classConection(cn)

#Region " ** CALCULA OBJETIVO DE VENTAS  ** "

    Public Async Sub CargarDGVVentaEmp() 'carga el dgv de ventas y porcentaje por empleado

        If SelectedForm = "VENTAS" Then
        Else
            Exit Sub
        End If

        Dim tbl As New DS_VENTAS2.tblPORCENTAJEVENTADataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           EMPLEADOS.NOMEMPLEADO AS EMPLEADO, ROUND (SUM(DOCUMENTOS.TOTALPRECIO / EMPRESAS.OBJETIVO_VENTAS), 2) AS OBJ1, ROUND (SUM(DOCUMENTOS.TOTALPRECIO / EMPRESAS.OBJETIVO_VENTAS2), 2) AS OBJ2
                                           FROM             DOCUMENTOS LEFT OUTER JOIN
                                                            EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                                            TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            EMPLEADOS ON DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS = 'O')
                                           GROUP BY         DOCUMENTOS.MES, DOCUMENTOS.ANIO, EMPLEADOS.NOMEMPLEADO
                                           HAVING           (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                                           ORDER BY         EMPLEADOS.NOMEMPLEADO", cn)

                cmd.Parameters.AddWithValue("@A", Me.txtVentasFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@M", Me.txtVentasFecha.DateTime.Month)

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                             dr(0).ToString,                    'NOMEMPLEADO
                             Double.Parse(dr(1).ToString),       'PORCENTAJE VENTA
                             Double.Parse(dr(2).ToString)       'PORCENTAJE VENTA 2
                        })
                Loop
                dr.Close()
                cmd.Dispose()
                cn.Close()

                Me.dgvVentasEmpOBJ.DataSource = tbl

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

    End Sub

    Dim totalventa As Double

    Public Function getObjetivoVenta() As Boolean

        Dim r As Boolean

        If SelectedForm = "VENTAS" Then
        Else
            Return False
            Exit Function
        End If

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           EMPRESAS.EMPNOMBRE, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, ISNULL(EMPRESAS.OBJETIVO_VENTAS, 0) AS OBJETIVO_VENTAS
                                           FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC RIGHT OUTER JOIN
                                                            EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT
                                           WHERE            (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.STATUS = 'O') AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF'))
                                           GROUP BY         EMPRESAS.EMPNOMBRE, EMPRESAS.OBJETIVO_VENTAS", cn)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@V", codempleado)
                cmd.Parameters.AddWithValue("@A", Me.txtVentasFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@M", Me.txtVentasFecha.DateTime.Month)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then

                    totalventa = Double.Parse(dr(2))
                    'Me.lbVentasLogroPorc.Text = FormatNumber((Double.Parse(dr(2)) / Double.Parse(dr(3))) * 100, 2) + " %"
                    Me.ProgressBarOBJ1.Position = FormatNumber((Double.Parse(dr(2)) / Double.Parse(dr(3))) * 100, 2)

                    'Me.ProgressBarOBJ3.Position = FormatNumber((Double.Parse(dr(2)) / Double.Parse(dr(5))) * 100, 2)
                    If NivelUsuario <> 2 Then
                        Me.lbVentas.Text = FormatNumber(dr(2), 2)
                        Me.lbMeta1.Text = FormatNumber(dr(3), 2)
                    Else

                    End If

                    'Me.lbMeta3.Text = FormatNumber(dr(5), 2)
                    'Me.lbDiario1.Text = FormatNumber((Double.Parse(dr(3)) - Double.Parse(dr(2))), 2)
                    'Me.lbDiario2.Text = FormatNumber((Double.Parse(dr(4)) - Double.Parse(dr(2))), 2)
                    'Me.lbFaltaMeta3.Text = FormatNumber((Double.Parse(dr(5)) - Double.Parse(dr(2))), 2)

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Return r
    End Function

    Public Function getObjetivoDiario() As Boolean

        Dim r As Boolean

        Dim objdiario As Double

        If SelectedForm = "VENTAS" Then
        Else
            Return False
            Exit Function
        End If

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           EMPRESAS.EMPNOMBRE, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, ISNULL(EMPRESAS.OBJETIVO_VENTAS, 0) AS OBJETIVO_VENTAS
                                           FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC RIGHT OUTER JOIN
                                                            EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT
                                           WHERE            (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.DIA = @D) AND (DOCUMENTOS.STATUS = 'O') AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF'))
                                           GROUP BY         EMPRESAS.EMPNOMBRE, EMPRESAS.OBJETIVO_VENTAS", cn)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@V", codempleado)
                cmd.Parameters.AddWithValue("@A", Me.txtVentasFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@M", Me.txtVentasFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@D", Me.txtVentasFecha.DateTime.Day)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then

                    objdiario = (Double.Parse(dr(3)) - totalventa) / (DateTime.DaysInMonth(Today.Year, Today.Month) - (Today.Day - 1))

                    Me.lbDiario.Text = FormatNumber(dr(2), 2)
                    Me.ProgressBarDiario1.Position = FormatNumber((Double.Parse(dr(2)) / objdiario) * 100, 2)

                    If NivelUsuario <> 2 Then
                        Me.lbDiario1.Text = FormatNumber(dr(3), 2)
                    Else

                    End If


                    'Me.lbFaltaMeta3.Text = FormatNumber((Double.Parse(dr(5)) - Double.Parse(dr(2))), 2)

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Return r

    End Function

    Public Function getRentabilidadTotalMes() As Boolean

        Dim r As Boolean
        Dim utilidad As Double

        If SelectedForm = "VENTAS" Then
        Else
            Return False
            Exit Function
        End If

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           ROUND(SUM(CAST(DOCPRODUCTOS.TOTALCOSTO AS decimal(10, 2))), 2) AS COSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS PRECIO
                                           FROM             DOCPRODUCTOS LEFT OUTER JOIN
                                                            DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                                                            TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC')) AND (DOCPRODUCTOS.ANIO = @A) AND (DOCPRODUCTOS.MES = @M) AND (DOCUMENTOS.STATUS <> 'A')", cn)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@V", codempleado)
                cmd.Parameters.AddWithValue("@A", Today.Year)
                cmd.Parameters.AddWithValue("@M", Today.Month)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then

                    utilidad = Double.Parse(dr(1)) - Double.Parse(dr(0))
                    Me.lbPorcUtilidadMes.Text = Math.Round((utilidad / Double.Parse(dr(1))) * 100, 2)

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Return r
    End Function

    Public Function getRentabilidadTotalDia() As Boolean

        Dim r As Boolean
        Dim utilidad As Double

        If SelectedForm = "VENTAS" Then
        Else
            Return False
            Exit Function
        End If

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           ROUND(SUM(CAST(DOCPRODUCTOS.TOTALCOSTO AS decimal(6, 2))), 2) AS COSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS PRECIO
                                           FROM             DOCPRODUCTOS LEFT OUTER JOIN
                                                            DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                                                            TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC')) AND (DOCPRODUCTOS.ANIO = @A) AND (DOCPRODUCTOS.MES = @M) AND (DOCPRODUCTOS.DIA = @D) AND (DOCUMENTOS.STATUS <> 'A')", cn)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@V", codempleado)
                cmd.Parameters.AddWithValue("@A", Me.txtVentasFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@M", Me.txtVentasFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@D", Me.txtVentasFecha.DateTime.Day)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then

                    utilidad = Double.Parse(dr(1)) - Double.Parse(dr(0))
                    Me.lbPorcUtilidadDia.Text = Math.Round((utilidad / Double.Parse(dr(1))) * 100, 2)

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Return r
    End Function

    Private Sub cmbVentasVendedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVentasVendedor.SelectedIndexChanged
        If SelectedForm = "VENTAS" Then

            If CType(Me.cmbVentasVendedor.SelectedValue, Integer) >= 0 Then
            Else
                Exit Sub
            End If

            Call getObjetivoVenta()
            Call getRentabilidadTotalMes()
            Call getRentabilidadTotalDia()
            Call CargarDGVVentaEmp()
            Call getObjetivoDiario()

        End If
    End Sub

    Private Sub cmbVentasVendedor_Leave(sender As Object, e As EventArgs) Handles cmbVentasVendedor.Leave

        If SelectedForm = "VENTAS" Then
            'Call getObjetivoVenta(CType(Me.cmbVentasVendedor.SelectedValue, Integer))
        End If

    End Sub

#End Region

#Region " ** SINCRONIZADOR EN BACKGROUND ** "

    Private Sub TimerSync_Tick(sender As Object, e As EventArgs) Handles TimerSync.Tick



        If Me.SwitchConfigModoCodigoVentas.IsOn = True Then
            If Me.BackgroundWorkerSync.IsBusy = False Then
                Me.BackgroundWorkerSync.RunWorkerAsync()
            End If
        End If


    End Sub

    '*******************************************************
    '****** SINCRONIZADOR EN BACKGROUND  *******************
    '*******************************************************
    Private Sub BackgroundWorkerSync_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerSync.DoWork
        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        'Call Mensaje("Sincronizando inventario...")

        'sincronizando inventario, productos y precios
        If objS.fcnDeleteBackground(GlobalEmpNit, Today.Date.Year, Today.Date.Month) = True Then

            Call Mensaje("Enviando Cortes de Caja...")

            If objS.fcnSendCortes(GlobalEmpNit) = True Then
                Dim obgen As New ClassGeneral
                obgen.updateCortesEnviados()
            Else
                Call Mensaje("No se enviaron los cortes")
            End If

            'SUBIENDO INVENTARIOS
            If objS.fcnSendBackupFInventario(GlobalEmpNit) = True Then
            Else
                Call Mensaje("Error al sincronizar " & objS.DesError.ToString)
            End If

            'SUBIENDO DOCUMENTOS
            If objS.fcnSendBackup(Today.Date.Year, Today.Date.Month, GlobalEmpNit) = True Then
            Else
                Call Mensaje("Error al sincronizar " & objS.DesError.ToString)
            End If

            'Try
            'SUBIENDO PRODUCTOS Y PRECIOS
            'If objS.fcnSendBackupFProductos(Today.Date.Year, Today.Date.Month, GlobalEmpNit) = True Then
            'Else
            'Call Mensaje("Error al sincronizar " & objS.DesError.ToString)
            'End If
            'Catch ex As Exception
            'End Try

        Else

            Call Mensaje("Error a limpiar datos anteriores")
        End If

        'sincronizando tareas
        objS.taskSync()

        Call Mensaje("Sincronización finalizada")

    End Sub

#End Region

#Region " ** INICIALIZADORES DEL SISTEMA ** "

    Private Sub btnConfigServer_Click(sender As Object, e As EventArgs) Handles btnConfigServer.Click

        MsgBox("Esta opción sirve para indicar la conexión hacia la base de datos. Úsela solamente si sabe para qué sirve")



        If FlyoutDialog.Show(Me, New viewConfigServer) = DialogResult.OK Then

            Using CN As New SqlConnection(strSqlConectionString)
                Try
                    CN.Open()
                    CN.Close()
                Catch ex As Exception
                    Call Aviso("Error de Conexión", "No se puede conectar al servidor, por favor, verifique su conexión " + ex.ToString, Me)
                    FlyoutDialog.Show(Me, New viewConfigServer)

                    Exit Sub
                End Try
            End Using

            Call CargarCoddoc() 'carga el coddoc para el usuario actual en pedidos TEMPORALMENTE

            Call CargarMesProceso()

            Call CargarEmpresas()

        End If

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim obc As New classConfig

        If Confirmacion("¿Está seguro que desea cerrar el sistema?", Me) = True Then
            obc.LiberarUsuario(GlobalNomUsuario)
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    'AL CARGAR EL FORMULARIO
    <STAThread()>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        SplashScreenManager.ShowForm(Me, SplashScreen2.GetType, True, True, ParentFormState.Locked)
        Me.btnConfigServer.Appearance.BackColor = Color.Orange
        Me.cmdIngresar.Appearance.BackColor = Color.Orange
        Me.btnLiberarUsuarios.Appearance.BackColor = Color.Orange

        Me.txtFondo.Enabled = False
        Me.txtVersion.Enabled = False

        Try
            GlobalPathFondo = Application.StartupPath + "\Src\fondo.png"
            Me.NP_Login.BackgroundImage = Image.FromFile(GlobalPathFondo)
        Catch ex As Exception
        End Try

        'pongo los datetimepicker con la fecha del día
        Call CargarFechasDocumentos()

        'datos del cliente
        Me.txtVentasNitClie.Text = "CF"

        'cargo el token
        If getToken() = True Then
            Mensaje("Token: " & Token)
        End If

        'abro las conexiones
        Call CargarConexion()

        Call CargarMesProceso()

        Call fcnCargarConfigCliente()

        'carga el coddoc para el usuario actual en pedidos TEMPORALMENTE
        Call CargarCoddoc()

        'inicializa los campos que requieren una conexión activa
        Call iniciarRutinasConConexion()

        SplashScreenManager.CloseForm()

        Me.Size = New Size(1300, 720)
        Me.FormBorderStyle = FormBorderStyle.FixedSingle

        'testego de sockets
        'Call IniciarServidorSockets()

    End Sub

    Public Sub CargarFechasDocumentos()
        Me.txtVentasFecha.DateTime = Today.Date
    End Sub

    Public Sub iniciarRutinasConConexion()
        'carga las credenciales twilio
        'Dim objTwilio As New ClassTwilio
        'If objTwilio.fcn_CargarTwilioCredentials = True Then

        'End If

        Call CargarEmpresas()

    End Sub

    'KEYDOWN DEL FORMULARIO
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'F5 equivale a Guardar
        'ESCAPE será para ir atrás en el navigation
        'F1,F2,F3,F4 será para los filtros de búsqueda

        Select Case SelectedForm

            Case "VENTAS"


                If e.KeyCode = Keys.Escape Then
                    Me.cmdVentasAtras.PerformClick()
                End If
                'If e.KeyCode = Keys.F1 Then
                'Me.cmdVentasFiltroDescripcion.PerformClick()
                'End If
                'If e.KeyCode = Keys.F2 Then
                'Me.cmdVentasFiltroDescripcion2.PerformClick()
                'End If
                'If e.KeyCode = Keys.F3 Then
                'Me.cmdVentasFiltroDescripcion3.PerformClick()
                'End If
                'If e.KeyCode = Keys.F4 Then
                ' Me.cmdVentasFiltroMarca.PerformClick()
                'End If
                If e.KeyCode = Keys.F3 Then
                    'Me.cmdVentasCobrar.PerformClick()
                    GlobalTipoCobro = 1
                    Call CobrarVentas()
                End If
                If e.KeyCode = Keys.F5 Then
                    GlobalTipoCobro = 0
                    Call CobrarVentas()
                End If
                If e.KeyCode = Keys.F7 Then
                    GlobalTipoCobro = 2
                    Call CobrarVentas()
                End If
                If e.KeyCode = Keys.F9 Then
                    GlobalTipoCobro = 3
                    Call CobrarVentas()
                End If
                '-------------------------------------------
            Case "ENVIOS"
                If e.KeyCode = Keys.F5 Then
                    Me.cmdVentasGuardar.PerformClick()
                End If

                If e.KeyCode = Keys.Escape Then
                    Me.cmdVentasAtras.PerformClick()
                End If
                If e.KeyCode = Keys.F1 Then
                    Me.cmdVentasFiltroDescripcion.PerformClick()
                End If
                If e.KeyCode = Keys.F2 Then
                    Me.cmdVentasFiltroDescripcion2.PerformClick()
                End If
                If e.KeyCode = Keys.F3 Then
                    Me.cmdVentasFiltroDescripcion3.PerformClick()
                End If
                If e.KeyCode = Keys.F4 Then
                    Me.cmdVentasFiltroMarca.PerformClick()
                End If

                '-------------------------------------------
            Case "TOMARDATOS"
                If e.KeyCode = Keys.Escape Then
                    Me.cmdTomarDatosAtras.PerformClick()
                End If
                '-------------------------------------------

            Case "CONFIG"
                If e.KeyCode = Keys.Escape Then
                    Me.cmdConfigAtras.PerformClick()
                End If

        End Select
    End Sub


#End Region

#Region " ** VARIOS ** "

    Public Sub getCajas()
        Dim objC As New classCorteCaja
        With Me.cmbVentasCaja
            .DataSource = Nothing
            .DataSource = objC.getCajas(1)
            .ValueMember = "CODCAJA"
            .DisplayMember = "DESCAJA"
        End With

    End Sub

    Private Sub TimerHora_Tick(sender As Object, e As EventArgs) Handles TimerHora.Tick
        If Now.Minute = 0 Then
            fcn_HablarTexto("Son las " & Now.Hour.ToString & " horas en punto")
        End If
    End Sub

    Public Function Mensaje(ByVal Msn As String) As Boolean
        Dim result As Boolean
        Try
            'Beep()
            Me.NotifyIcon1.BalloonTipTitle = "Aviso"
            Me.NotifyIcon1.BalloonTipText = Msn
            Me.NotifyIcon1.ShowBalloonTip(2000)
            result = True
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

#End Region

#Region " ** LOGIN ** "

    'esta variable determina si ya está logeado para bloquear el menú principal 
    'ésto para quitar el login actual

    Private Sub cmdCerrarSesion_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("LOGIN")
    End Sub

    Private Sub txtUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPass.select()
        End If
    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdIngresar.select()
        End If
    End Sub

#Region "LOGIN ANTEIOR"

    ''  Private Sub cmdIngresar_Click(sender As Object, e As EventArgs) Handles cmdIngresar.Click
    'If Me.cmbLoginEmpresa.SelectedIndex >= 0 Then
    'If Me.txtUser.Text <> "" Then
    'If Me.txtPass.Text <> "" Then
    'Dim obc As New classConfig
    'If BuscarUsuario(Me.txtUser.Text, Me.txtPass.Text) = True Then
    '                   GlobalEmpNit = Me.cmbLoginEmpresa.SelectedValue.ToString
    ''verifica si el usuario está logeado
    'If obc.VerificarUsuarioUso(Me.txtUser.Text) = 1 Then
    '                      MsgBox("Este usuario ya está siendo usado en otra pc", MsgBoxStyle.Exclamation, "AVISO")
    'Exit Sub
    'End If
    '                    GlobalTipoSucursal = obc.getTipoEmpresa(Me.cmbLoginEmpresa.SelectedValue.ToString)
    '                   GlobalNomEmpresa = Me.cmbLoginEmpresa.Text
    '                  'carga el tipo de precio predeterminado para el cliente
    '
    '                   boolLoged = True
    '
    '                   GlobalAnioProceso = 0 ' CType(Me.cmdAnioProceso.Text, Integer)
    '                  GlobalMesProceso = 0 ' CType(Me.cmdMesProceso.SelectedValue, Integer)
    '                 'muestra el formulario de espera
    '                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
    ''CARGA EL MENU PRINCIPAL
    'Call NAVEGAR("MENU")
    'CARGAR LOS VALORES INICIALES DEL LOAD DEL FORM
    '--------------------------------------------------------
    'Call CargarLabels(GlobalTipoEmpresa)
    'cargar la configuración de las notificaciones
    'Call CargarConfigNotificaciones()
    ''carga los email a notificar
    'Call CargarConfigGenerales()
    ''carga los permisos de usuario
    'Call CargarPermisosUsuario2()
    '                    GlobalNomUsuario = Me.txtUser.Text
    'Me.LbMesProceso.Text = GlobalNomUsuario + " - " + GlobalNomEmpresa
    'If NivelUsuario > 1 Then
    'Me.txtVentasFecha.Enabled = False
    'Me.txtComprasFecha.Enabled = False
    'Me.txtMovInvFecha.Enabled = False
    'Me.LbMovInvTotalCosto.Visible = False
    'Me.LabelControl167.Visible = False
    'Me.LabelControl168.Visible = False
    'End If
    'Me.txtUser.Text = ""
    'Me.txtPass.Text = ""
    ''Call NAVEGAR("MENU")
    '
    'carga el contado o credito de compras
    'Call CargarComboConcre()
    'cargo el combobox de vendedores en ventas
    'Call CargarComboboxVendedores()
    'cargo el combo tipo producto en los documentos
    'Call getComboTipoProd()
    ''carga los datos clientes documento
    'Call CargarConfigClienteDocumentos()
    'QUITO EL FONDO PARA AHORRAR MEMORIA
    'Me.NP_Login.BackgroundImage = Nothing
    'cargo el token
    'If getToken() = True Then
    'Me.TimerSync.Interval = GlobalTimerToken * 1000
    'Me.TimerSync.Enabled = True
    'Me.TimerSync.Start()
    'End If

    'ocupo el usuario
    '                   obc.OcuparUsuario(GlobalNomUsuario)
    'OCUPA EL PRIMER INDEX DE TIPO PROD
    'Me.cmbVentasTipoProd.SelectedIndex = 0
    'Me.cmbComprasTipoProd.SelectedText = 0
    '                   SplashScreenManager.CloseForm()
    'Else
    'Call Aviso("INCORRECTO", "Usuario y/o Contraseña inválido", Me)
    'End If
    'Else
    'Call Mensaje("Escribe tu Contraseña")
    'End If
    'Else
    'Call Mensaje("Escribe tu nombre de Usuario")
    'End If
    'Else
    'Call Aviso("Importante", "Debes seleccionar una Empresa", Me)
    'End If

    'End Sub

#End Region

    Private Sub cmdIngresar_Click(sender As Object, e As EventArgs) Handles cmdIngresar.Click

        If Me.cmbLoginEmpresa.SelectedIndex >= 0 Then

            If Me.txtUser.Text <> "" Then

                If Me.txtPass.Text <> "" Then

                    Dim obc As New classConfig

                    If BuscarUsuario(Me.txtUser.Text, Me.txtPass.Text) = True Then

                        GlobalEmpNit = Me.cmbLoginEmpresa.SelectedValue.ToString

                        'verifica si el usuario está logeado
                        If obc.VerificarUsuarioUso(Me.txtUser.Text) = 1 Then

                            MsgBox("Este usuario ya está siendo usado en otra pc", MsgBoxStyle.Exclamation, "AVISO")

                            Exit Sub

                        End If

                        GlobalTipoSucursal = obc.getTipoEmpresa(Me.cmbLoginEmpresa.SelectedValue.ToString)

                        GlobalNomEmpresa = Me.cmbLoginEmpresa.Text
                        'carga el tipo de precio predeterminado para el cliente
                        boolLoged = True
                        GlobalAnioProceso = 0
                        GlobalMesProceso = 0
                        'muestra el formulario de espera
                        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
                        'CARGA EL MENU PRINCIPAL
                        Call NAVEGAR("MENU")
                        'CARGAR LOS VALORES INICIALES DEL LOAD DEL FORM
                        '--------------------------------------------------------
                        Call CargarComboboxVendedores()
                        Call CargarConfigGenerales()
                        'carga los permisos de usuario
                        GlobalNomUsuario = Me.txtUser.Text
                        If NivelUsuario > 1 Then
                            Me.txtVentasFecha.Enabled = False
                        End If
                        Me.txtUser.Text = ""
                        Me.txtPass.Text = ""

                        Me.NP_Login.BackgroundImage = Nothing
                        'cargo el token
                        If getToken() = True Then
                            Me.TimerSync.Interval = GlobalTimerToken * 1000
                            Me.TimerSync.Enabled = True
                            Me.TimerSync.Start()
                        End If
                        'ocupo el usuario
                        obc.OcuparUsuario(GlobalNomUsuario)

                        SplashScreenManager.CloseForm()
                    Else
                        Call Aviso("INCORRECTO", "Usuario y/o Contraseña inválido", Me)
                    End If
                Else
                    Call Mensaje("Escribe tu Contraseña")
                End If
            Else
                Call Mensaje("Escribe tu nombre de Usuario")
            End If
        Else
            Call Aviso("Importante", "Debes seleccionar una Empresa", Me)
        End If

    End Sub

    Private Sub getComboTipoProd()
        Dim obPr As New ClassProductos

        Try

            With Me.cmbVentasTipoProd
                .DataSource = obPr.tblTipoProd("VENTAS")
                .ValueMember = "TIPO"
                .DisplayMember = "DESC"
                .SelectedValue = GlobalTipoProd
            End With

            Me.cmbVentasTipoProd.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbVentasTipoProd.AutoCompleteSource = AutoCompleteSource.ListItems

        Catch ex As Exception
            'MsgBox("Error al cargar tipo producto. Error: " + ex.ToString)
        End Try

    End Sub

    Private Sub cmbLoginEmpresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoginEmpresa.SelectedIndexChanged
        If Me.cmbLoginEmpresa.SelectedValue.ToString <> "" Then
            Call CargarMesProcesoEmpresa(Me.cmbLoginEmpresa.SelectedValue.ToString)
        End If
    End Sub

    Private Sub cmbLoginEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLoginEmpresa.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtUser.select()
        End If
    End Sub

    Private Sub cmbLoginEmpresa_Leave(sender As Object, e As EventArgs) Handles cmbLoginEmpresa.Leave
        If Me.cmbLoginEmpresa.SelectedValue <> "" Then
            Call CargarMesProcesoEmpresa(Me.cmbLoginEmpresa.SelectedValue.ToString)

        End If
    End Sub

#End Region

#Region " ** PEDIDOS/ENVIOS ** "

    Private Sub btnVentasPse_Click(sender As Object, e As EventArgs) Handles btnVentasPse.Click
        If FlyoutDialog.Show(Me, New viewItemSinExistencia(Double.Parse(Me.txtVentasCorrelativo.Text))) = DialogResult.OK Then
            Call CargarGridTempVentas()
            Select Case SelectedForm
                Case "VENTAS"
                    Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()
                Case "LISTADOS"
                    Call CargarTotalVenta(SelectedCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()
                Case "ENVIOS"
                    Call CargarTotalVenta(GlobalCoddocENVIOS, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()
                Case "COTIZACIONES"
                    Call CargarTotalVenta(GlobalCoddocCOTIZ, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()
            End Select
        End If
    End Sub

    Private Sub TileItemEnvios_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Call NAVEGAR("ENVIOS")
    End Sub

    Private Sub cmdVentasGuardar_Click(sender As Object, e As EventArgs) Handles cmdVentasGuardar.Click

        If Me.txtVentasCodCliente.Text <> "" Then

            If Double.Parse(Me.LbTotalVenta.Text) > 0 Then
                VentasTotalVenta = Double.Parse(Me.LbTotalVenta.Text)

                If SelectedForm = "COTIZACIONES" Then

                    If FlyoutDialog.Show(Me, New viewFinalizarCotizacion) = DialogResult.OK Then
                        Call GuardarVenta()
                    Else
                        Exit Sub
                    End If

                Else

                    VentasCodRepartidor = 0
                    VentasDirEntrega = "CIUDAD"
                    VentasObs = "SN"

                    If Me.SwitchConfigClaveVendedor.IsOn = True Then
                        'GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)
                        Dim control As New UserControlCLAVEVend
                        FlyoutDialog.Show(Me, control)
                    Else

                        If Me.cmbVentasVendedor.SelectedIndex >= 0 Then
                            Call GuardarVenta()
                        Else
                            Call Aviso("Importante", "Seleccione un vendedor de la lista", Me)
                        End If

                    End If
                End If

            End If
        Else
            Me.txtVentasNitClie.Text = ""
            Call Aviso("Importante", "Seleccione un Cliente o escriba el NIT del mismo", Me)
        End If

    End Sub

    'rutinas para los pedidos pendientes
    Private Sub CargarGridPedidosPendientes(ByVal tipodoc As String)

        'ENV=PEDIDOS, COT=COTIZACIONES

        Dim tbl As New DataTable()
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("CODDOC", GetType(String))
        tbl.Columns.Add("CORRELATIVO", GetType(Double))
        tbl.Columns.Add("CLIENTE", GetType(String))
        tbl.Columns.Add("TOTAL", GetType(String))
        tbl.Columns.Add("DOCUMENTO", GetType(String))
        tbl.Columns.Add("CODCLIENTE", GetType(Integer))

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim SQLOLD As String = "SELECT  DOCUMENTOS.ID, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.CORTE, DOCUMENTOS.CODCLIENTE
                            FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                            WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (DOCUMENTOS.CORTE = 'NO') AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC)"


                Dim SQL As String = "SELECT  DOCUMENTOS.ID, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.CORTE, DOCUMENTOS.CODCLIENTE
                            FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                            WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.CORTE = 'NO') AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (STATUS='O')"

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@ANIO", Me.txtVentasFecha.DateTime.Year) 'Integer.Parse(Me.cmdAnioProceso.Text))
                'cmd.Parameters.AddWithValue("@MES", Me.txtVentasFecha.DateTime.Month) 'Integer.Parse(Me.cmdMesProceso.SelectedValue))
                cmd.Parameters.AddWithValue("@TIPODOC", tipodoc)

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                         Integer.Parse(dr(0).ToString),
                         dr(1).ToString,
                         Double.Parse(dr(2)),
                         dr(3).ToString,
                         FormatCurrency(dr(4)).ToString,
                         (dr(1).ToString & " - " & dr(2).ToString),
                         Integer.Parse(dr(6))
                    })
                Loop
                dr.Close()
                cmd.Dispose()
                cn.Close()

                Me.GridPedidosPendientes.DataSource = tbl

                TryCast(TileViewPedidosPendientes.TileTemplate(0), TileViewItemElement).Column = TileViewPedidosPendientes.Columns("DOCUMENTO")
                TryCast(TileViewPedidosPendientes.TileTemplate(1), TileViewItemElement).Column = TileViewPedidosPendientes.Columns("CLIENTE")
                TryCast(TileViewPedidosPendientes.TileTemplate(4), TileViewItemElement).Column = TileViewPedidosPendientes.Columns("TOTAL")
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

    End Sub

    Dim PedidoTomado As Boolean = False
    Dim PedidoSeleccionadoCoddoc As String, PedidoSeleccionadoCorrelativo As Double


    Private Sub TileViewPedidosPendientes_DoubleClick(sender As Object, e As EventArgs) Handles TileViewPedidosPendientes.DoubleClick

        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewPedidosPendientes.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then

            SelectedCode = Integer.Parse(TileViewPedidosPendientes.GetRowCellValue(hitInfo.RowHandle, "ID").ToString)
            PedidoSeleccionadoCoddoc = TileViewPedidosPendientes.GetRowCellValue(hitInfo.RowHandle, "CODDOC").ToString
            PedidoSeleccionadoCorrelativo = Double.Parse(TileViewPedidosPendientes.GetRowCellValue(hitInfo.RowHandle, "CORRELATIVO").ToString)

            If SelectedForm = "VENTAS" Then

                aniodoc = Me.txtVentasFecha.DateTime.Year
                mesdoc = Me.txtVentasFecha.DateTime.Month

                Me.txtVentasCodCliente.Text = TileViewPedidosPendientes.GetRowCellValue(hitInfo.RowHandle, "CODCLIENTE").ToString

                Call CargarPedido(PedidoSeleccionadoCoddoc, PedidoSeleccionadoCorrelativo)
                Me.NavigationFrameMain.SelectedPage = NP_Facturacion
                SelectedForm = "VENTAS"

                Call CargarGridTempVentas()

                Call CargarTotalVenta(Me.cmbVentasCoddoc.SelectedValue.ToString, Double.Parse(Me.txtVentasCorrelativo.Text))
            End If

            PedidoTomado = True

        End If
    End Sub

    Dim aniodoc As Integer, mesdoc As Integer

    Private Sub CargarPedido(ByVal Coddoc As String, ByVal Correlativo As Double)
        Try
            Call AbrirConexionSql()
            Dim SQL As String = ""
            SQL = "DELETE FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND USUARIO='" & GlobalNomUsuario & "'"

            Dim cmd0 As New SqlCommand(SQL, cn)
            cmd0.ExecuteNonQuery()
            cmd0.Dispose()

            Dim cmd1 As New SqlCommand("SELECT      DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.CODVEN, VENDEDORES.NOMVEN, DOCUMENTOS.DIRENTREGA, DOCUMENTOS.OBS,DOCUMENTOS.CODCLIENTE
                                                    FROM DOCUMENTOS LEFT OUTER JOIN VENDEDORES ON DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT AND DOCUMENTOS.CODVEN = VENDEDORES.CODVEN
                                        WHERE       (DOCUMENTOS.EMPNIT = @EMPNIT) 
                                                    AND (DOCUMENTOS.CODDOC = @CODDOC) 
                                                    AND (DOCUMENTOS.CORRELATIVO = @CORRELATIVO) 
                                                    AND (DOCUMENTOS.ANIO = @ANIO) 
                                                    AND (DOCUMENTOS.MES = @MES)", cn)

            cmd1.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd1.Parameters.AddWithValue("@ANIO", aniodoc) 'Integer.Parse(Me.cmdAnioProceso.Text))
            cmd1.Parameters.AddWithValue("@MES", mesdoc) 'Integer.Parse(Me.cmdMesProceso.SelectedValue))
            cmd1.Parameters.AddWithValue("@CODDOC", Coddoc)
            cmd1.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
            Dim dr1 As SqlDataReader = cmd1.ExecuteReader
            dr1.Read()
            Try
                If dr1.HasRows Then
                    If SelectedForm = "VENTAS" Then
                        Me.txtVentasCodCliente.Text = dr1(6)
                        Me.txtVentasNitClie.Text = dr1(0).ToString
                        Me.txtVentasNombre.Text = dr1(1).ToString
                        If Me.cmbTomarDatosTipodoc.Text = "COTIZACIONES" Then
                        Else
                            Me.cmbVentasVendedor.SelectedValue = Integer.Parse(dr1(2))
                            Me.cmbVentasVendedor.Text = dr1(3).ToString
                        End If

                    End If

                    VentasDirEntrega = dr1(4).ToString
                    VentasObs = dr1(5).ToString
                End If
            Catch ex As Exception
                Call Mensaje("No se pudieron cargar los datos del encabezado del pedido. Error: " & ex.ToString)
            End Try
            dr1.Close()
            cmd1.Dispose()

            'CARGA EL DETALLE DEL PEDIDO A LA TABLA VENTAS TEMP
            Dim comm As New SqlCommand("SELECT          DOCPRODUCTOS.EMPNIT, 
			                                            DOCPRODUCTOS.CODDOC, 
			                                            DOCPRODUCTOS.CORRELATIVO, 
			                                            DOCPRODUCTOS.CODPROD, 
			                                            DOCPRODUCTOS.DESPROD, 
			                                            DOCPRODUCTOS.CODMEDIDA, 
			                                            DOCPRODUCTOS.CANTIDAD, 
                                                        DOCPRODUCTOS.EQUIVALE, 
			                                            DOCPRODUCTOS.TOTALUNIDADES, 
			                                            DOCPRODUCTOS.COSTO, 
			                                            DOCPRODUCTOS.PRECIO, 
			                                            DOCPRODUCTOS.TOTALCOSTO, 
			                                            DOCPRODUCTOS.TOTALPRECIO, 
			                                            DOCPRODUCTOS.ANIO, 
                                                        DOCPRODUCTOS.MES, 
			                                            ISNULL(PRODUCTOS.EXENTO,0) AS EXENTO
                                        FROM            DOCPRODUCTOS LEFT OUTER JOIN
                                                        PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT
                                        WHERE           (DOCPRODUCTOS.EMPNIT = @EMPNIT) AND (DOCPRODUCTOS.CODDOC = @CODDOC) AND (DOCPRODUCTOS.CORRELATIVO = @CORRELATIVO) ", cn)

            comm.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            'comm.Parameters.AddWithValue("@ANIO", aniodoc) 'Integer.Parse(Me.cmdAnioProceso.Text))
            'comm.Parameters.AddWithValue("@MES", mesdoc) 'Integer.Parse(Me.cmdMesProceso.SelectedValue))
            comm.Parameters.AddWithValue("@CODDOC", Coddoc)
            comm.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
            Dim dr As SqlDataReader = comm.ExecuteReader
            Do While dr.Read
                Dim cmd As New SqlCommand("INSERT INTO  Temp_Ventas 
                                                        (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALBONIF,USUARIO,NOSERIE,EXENTO,OBS,PRECIOSINIVA,TOTALPRECIOSINIVA) 
                                           VALUES       (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@TOTALBONIF,@USUARIO,@NOSERIE,@EXENTO,@OBS,@PRECIOSINIVA,@TOTALPRECIOSINIVA)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbVentasCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtVentasCorrelativo.Text))
                cmd.Parameters.AddWithValue("@OBS", "SN")
                Dim TOTALIVA As Double = 0
                If Integer.Parse(dr(15)) = 0 Then 'SI EL PRODUCTO ES AFECTO DE IVA
                    Dim totalsiniva As Double = (Double.Parse(dr(12)) / GlobalConfigIVA)
                    TOTALIVA = Double.Parse(Double.Parse(dr(12)) - totalsiniva)
                Else
                    TOTALIVA = 0
                End If
                cmd.Parameters.AddWithValue("@PRECIOSINIVA", TOTALIVA) 'TOTAL IVA
                cmd.Parameters.AddWithValue("@TOTALPRECIOSINIVA", Double.Parse(Double.Parse(dr(12)) - TOTALIVA)) 'TOTAL PRECIO SIN IVA

                If Integer.Parse(dr(15)) = 0 Then
                    cmd.Parameters.AddWithValue("@EXENTO", 0)
                Else
                    cmd.Parameters.AddWithValue("@EXENTO", Double.Parse(dr(12)))
                End If

                cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(dr(10)))
                cmd.Parameters.AddWithValue("@COSTO", Double.Parse(dr(9)))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(dr(12)))
                cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(dr(11)))
                cmd.Parameters.AddWithValue("@BONIF", 0)
                cmd.Parameters.AddWithValue("@CODPROD", dr(3).ToString)
                cmd.Parameters.AddWithValue("@DESPROD", dr(4).ToString)
                cmd.Parameters.AddWithValue("@CODMEDIDA", dr(5).ToString)
                cmd.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(dr(7)))
                cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(dr(6)))
                cmd.Parameters.AddWithValue("@TOTALUNIDADES", Double.Parse(dr(8)))
                cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                cmd.Parameters.AddWithValue("@NOSERIE", "SN")
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                If cmd.ExecuteNonQuery() > 0 Then
                    If SelectedForm = "VENTAS" Then
                        'SI SON COTIZACIONES, HACE EL DESCUENTO DEL STOCK
                        If Me.cmbTomarDatosTipodoc.Text = "COTIZACIONES" Then
                            Dim objinv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
                            objinv.fcn_InsertarSalidaProducto(dr(3).ToString, Double.Parse(dr(8)))
                        End If
                        If Me.cmbTomarDatosTipodoc.Text = "PEDIDOS" Then
                            Dim objinv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
                            objinv.fcn_InsertarSalidaProducto(dr(3).ToString, Double.Parse(dr(8)))
                        End If
                    Else
                        If Me.cmbTomarDatosTipodoc.Text = "COTIZACIONES" Then
                            Dim objinv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
                            objinv.fcn_InsertarEntradaProducto(dr(3).ToString, Double.Parse(dr(8)))
                        End If
                    End If

                End If

                cmd.Dispose()

            Loop
            dr.Close()
            comm.Dispose()
            cn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
            Call Mensaje("No se pudieron cargar los productos. Error: " & Err.ToString)
        End Try

    End Sub

#End Region

#Region " ** VENTAS / FACTURACIÓN ** "


    Private Sub switchFELVentas_Toggled(sender As Object, e As EventArgs) Handles switchFELVentas.Toggled
        Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)

        If Me.switchFELVentas.IsOn = True Then

            Me.cmbVentasCoddoc.SelectedValue = GlobalCoddocENVIOS
            Me.cmbVentasCoddoc.Text = GlobalCoddocENVIOS



            MsgBox("Modo 'B' de ventas seleccionado")

        Else
            Me.cmbVentasCoddoc.SelectedValue = GlobalCoddocFEL
            Me.cmbVentasCoddoc.Text = GlobalCoddocFEL


            MsgBox("Modo 'A' de ventas seleccionado")

        End If


        Select Case SelectedForm
            Case "VENTAS"
                GlobalCoddoc = Me.cmbVentasCoddoc.SelectedValue.ToString
                GoTo Cargar
            Case "ENVIOS"
                GlobalCoddocENVIOS = Me.cmbVentasCoddoc.SelectedValue.ToString
                GoTo Cargar
            Case "COTIZACIONES"
                GlobalCoddocCOTIZ = Me.cmbVentasCoddoc.SelectedValue.ToString
                GoTo Cargar
            Case "COMPRAS"

        End Select

        Exit Sub

Cargar:
        GlobalSelectedTipoDocumento = objTipoDoc.getTipoDocumento(Me.cmbVentasCoddoc.SelectedValue.ToString)

        Call CargarCorrelativoVentas()
        Call CargarGridTempVentas()
        Call CargarTotalVenta(SelectedCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
        Me.lbAvisoFEL.Visible = getStatusTipoFEl(GlobalSelectedTipoDocumento)

        GlobalSelectedTipoDocumento = objTipoDoc.getTipoDocumento(Me.cmbVentasCoddoc.SelectedValue.ToString)

        Call CargarCorrelativoVentas()
        Call CargarGridTempVentas()
        Call CargarTotalVenta(SelectedCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
        Me.lbAvisoFEL.Visible = getStatusTipoFEl(GlobalSelectedTipoDocumento)


    End Sub


    Private Sub cmbVentasCoddoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVentasCoddoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtVentasNitClie.select()
        End If
    End Sub

    Private Sub cmbVentasCoddoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVentasCoddoc.SelectedIndexChanged

        Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)

        Select Case SelectedForm
            Case "VENTAS"
                GoTo Cargar
            Case "ENVIOS"

                GoTo Cargar
            Case "COTIZACIONES"

                GoTo Cargar
            Case "COMPRAS"

        End Select

        Exit Sub

Cargar:
        GlobalSelectedTipoDocumento = objTipoDoc.getTipoDocumento(Me.cmbVentasCoddoc.SelectedValue.ToString)
        Me.lbAvisoFEL.Visible = getStatusTipoFEl(GlobalSelectedTipoDocumento)

    End Sub

    Private Sub cmbVentasCoddoc_Leave(sender As Object, e As EventArgs) Handles cmbVentasCoddoc.Leave

        Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)

        Select Case SelectedForm
            Case "VENTAS"
                GlobalCoddoc = Me.cmbVentasCoddoc.SelectedValue.ToString
                GoTo Cargar
            Case "ENVIOS"
                GlobalCoddocENVIOS = Me.cmbVentasCoddoc.SelectedValue.ToString
                GoTo Cargar
            Case "COTIZACIONES"
                GlobalCoddocCOTIZ = Me.cmbVentasCoddoc.SelectedValue.ToString
                GoTo Cargar
            Case "COMPRAS"

        End Select

        Exit Sub

Cargar:
        GlobalSelectedTipoDocumento = objTipoDoc.getTipoDocumento(Me.cmbVentasCoddoc.SelectedValue.ToString)

        Call CargarCorrelativoVentas()
        Call CargarGridTempVentas()
        Call CargarTotalVenta(SelectedCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
        Me.lbAvisoFEL.Visible = getStatusTipoFEl(GlobalSelectedTipoDocumento)

    End Sub

    Private Sub cmdVentasAtras_Click(sender As Object, e As EventArgs) Handles cmdVentasAtras.Click
        Me.NavigationFrameMain.SelectedPage = NP_Inicio
        SelectedForm = "INICIO"
        Me.btnVentasModoCodigo.Visible = False

    End Sub

    Private Sub TileItemVentas_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Call NAVEGAR("VENTAS")
    End Sub

    'BOTON PARA APP VENTAS
    Private Sub btnVentasAppVentas_Click(sender As Object, e As EventArgs) Handles btnVentasAppVentas.Click
        Call NAVEGAR("SYNC2")
    End Sub

    'TOMAR DATOS EN FACTURA
    Private Sub cmdVentasTomarDatos_Click(sender As Object, e As EventArgs) Handles cmdVentasTomarDatos.Click
        Me.NavigationFrameMain.SelectedPage = NP_TomarDatos
        'SelectedForm = "TOMARDATOS"

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("TIPO", GetType(String))
            .Add("DESTIPO", GetType(String))
        End With
        With tbl.Rows
            .Add(New Object() {"COT", "COTIZACIONES"})
            .Add(New Object() {"ENV", "PEDIDOS"})
        End With

        Me.cmbTomarDatosTipodoc.DataSource = Nothing
        With Me.cmbTomarDatosTipodoc
            .DataSource = tbl
            .DisplayMember = "DESTIPO"
            .ValueMember = "TIPO"
            .SelectedValue = GlobalTomarDatosTipoDoc
        End With

        Call CargarGridPedidosPendientes(Me.cmbTomarDatosTipodoc.SelectedValue.ToString)
    End Sub

    Private Sub cmbTomarDatosTipodoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTomarDatosTipodoc.SelectedIndexChanged
        Call CargarGridPedidosPendientes(Me.cmbTomarDatosTipodoc.SelectedValue.ToString)
    End Sub

    Private Sub cmdTomarDatosAtras_Click(sender As Object, e As EventArgs) Handles cmdTomarDatosAtras.Click

        Me.NavigationFrameMain.SelectedPage = NP_Facturacion
        SelectedForm = "VENTAS"

    End Sub

    'VACIA TODOS LOS ITEMS DE LA FACTURA
    Private Sub btnVentasVaciarDoc_Click(sender As Object, e As EventArgs) Handles btnVentasVaciarDoc.Click
        If Confirmacion("¿Está seguro que desea Vaciar TODOS los productos de este Documento?", Me) = True Then
            Dim objVentas As New classVentas(GlobalEmpNit, GlobalCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
            If objVentas.VaciarDocumentoTemp() = True Then
                Call CargarDGVListaProductos(1)
                Call CargarGridTempVentas()
                Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))

                Me.txtVentasCodProd.select()
            Else
                Call Aviso("No se vació el documento", "Motivo: " & GlobalDesError, Me)
            End If

        End If
    End Sub

    Dim objProducto As New ClassProductos

    Private Sub txtVentasCodProd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVentasCodProd.KeyDown

        If e.KeyCode = Keys.Enter Then

            VentasNoSerie = "SN"

            If Me.txtVentasCodProd.Text <> "" Then

                If objProducto.ProductoHabilitado(GlobalEmpNit, Me.txtVentasCodProd.Text) = False Then
                    MsgBox("Producto deshabilitado")
                    Exit Sub
                End If

                If DatosProducto(Me.txtVentasCodProd.Text) = True Then

                    GoTo Procede

                Else

                    'Dim objProducto As New ClassProductos()
                    If objProducto.CargarDatosProductoSerie(GlobalEmpNit, Me.txtVentasCodProd.Text) = True Then
                        'carga el dato de la variable que contiene el número de serie
                        VentasNoSerie = Me.txtVentasCodProd.Text

                        GoTo Procede
                    Else
                        Call Mensaje("Código de producto no existe o se encuentra deshabilitado")
                        Exit Sub
                    End If
                End If

Procede:

                If SelectedForm = "ENVIOS" Then
                    If FlyoutDialog.Show(Me, New viewEnviosCantidad(GlobalModoPOS)) = DialogResult.OK Then
                        Call CargarTotalVenta(GlobalCoddocENVIOS, Double.Parse(Me.txtVentasCorrelativo.Text))
                        Me.txtVentasFiltro.Text = ""
                        Me.txtVentasCodProd.select()
                    End If
                End If




                'ABRE EL FLYOUTDIALOG CON EL USER CONTROL PARA LA CANTIDAD SELECCIONADA

                If SelectedForm <> "ENVIOS" Then
                    If FlyoutDialog.Show(Me, New UserControl_VentaCantidad(GlobalModoPOS, GlobalTipoPrecioSucursal)) = DialogResult.OK Then

                        Call CargarGridTempVentas()

                        If SelectedForm = "VENTAS" Then
                            Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))

                            Me.txtVentasFiltro.Text = ""
                            Me.txtVentasCodProd.select()
                        End If

                        If SelectedForm = "LISTADOS" Then
                            Call CargarTotalVenta(SelectedCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
                            Me.txtVentasFiltro.Text = ""
                            Me.txtVentasCodProd.select()
                        End If

                        If SelectedForm = "COTIZACIONES" Then
                            Call CargarTotalVenta(GlobalCoddocCOTIZ, Double.Parse(Me.txtVentasCorrelativo.Text))
                            Me.txtVentasFiltro.Text = ""
                            Me.txtVentasCodProd.select()
                        End If

                    Else

                    End If
                End If

            Else
                Me.txtVentasFiltro.select()
            End If
        End If

    End Sub

    Private Sub SwitchImprimirTicket_Toggled(sender As Object, e As EventArgs) Handles SwitchImprimirTicket.Toggled
        If Me.SwitchImprimirTicket.IsOn = True Then
            Call CambiarConfigSiNo(11, "SI")
        Else
            Call CambiarConfigSiNo(11, "NO")
        End If

    End Sub

    'BUSQUEDA DEL CLIENTE
    Private Sub cmdVentasBuscarCliente_Click(sender As Object, e As EventArgs) Handles cmdVentasBuscarCliente.Click

        If FlyoutDialog.Show(Me, New viewClientesLista(GlobalEmpNit, SelectedForm)) = DialogResult.OK Then
            Me.txtVentasCodCliente.Text = SelectedCode
            Me.txtVentasNitClie.Text = SelectedNitCliente
            Me.txtVentasNombre.Text = SelectedNomCliente

        End If

    End Sub

    Private Sub cmbVentasTipoProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVentasTipoProd.SelectedIndexChanged
        Call CargarDGVListaProductos(1)
    End Sub

    Private Sub txtVentasFiltro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVentasFiltro.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtVentasFiltro.Text <> "" Then
                Call CargarDGVListaProductos(2)
                Me.DgvVentasListaProductos.select()
                'Me.cmdVentasFiltroDescripcion.select()
            Else
                Call CargarDGVListaProductos(1)
            End If
        End If
    End Sub

    Private Sub DgvVentasListaProductos_DoubleClick(sender As Object, ByVal e As MouseEventArgs) Handles DgvVentasListaProductos.CellMouseDoubleClick

        If e.Button = MouseButtons.Left Then

            Try
                VentasNoSerie = "SN"
                VentasCorrelativo = Double.Parse(Me.txtVentasCorrelativo.Text)
                VentasCodProducto = Me.DgvVentasListaProductos.Item(0, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DgvVentasListaProductos.Item(1, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
                VentasCodMedida = Me.DgvVentasListaProductos.Item(2, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
                VentasEquivale = Integer.Parse(Me.DgvVentasListaProductos.Item(3, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
                VentasExistencia = Double.Parse(Me.DgvVentasListaProductos.Item(5, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
                VentasCostoProducto = Double.Parse(Me.DgvVentasListaProductos.Item(11, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
                VentasExento = Integer.Parse(Me.DgvVentasListaProductos.Item(12, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
                If VentasExento = 1 Then
                    VentasIvaProducto = 0
                Else
                    VentasIvaProducto = GlobalConfigIVA
                End If

                VentasEquivale = Integer.Parse(Me.DgvVentasListaProductos.Item(3, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
                VentasPrecioProducto = Double.Parse(Me.DgvVentasListaProductos.Item(4, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
                VentasAnio = Me.txtVentasFecha.DateTime.Year
                VentasMes = Me.txtVentasFecha.DateTime.Month

                Call EmergenteFac(Me)
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub DgvVentasListaProductos_CellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DgvVentasListaProductos.CellMouseClick
        If e.Button = MouseButtons.Right Then
            If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False Then
                Me.DgvVentasListaProductos.ClearSelection()
                Me.DgvVentasListaProductos.CurrentCell = Me.DgvVentasListaProductos.Item(e.ColumnIndex, e.RowIndex)
            End If
        End If
    End Sub

    Dim medidas As String

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

    Private Sub DgvVentasListaProductos_RightClick(sender As Object, ByVal e As MouseEventArgs) Handles DgvVentasListaProductos.CellMouseDoubleClick

        If e.Button = MouseButtons.Right Then

            Try

                VentasCodProducto = Me.DgvVentasListaProductos.Item(0, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
                VentasDesProducto = Me.DgvVentasListaProductos.Item(1, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
                Call medida(VentasCodProducto)
                VentasExistencia = Double.Parse(Me.DgvVentasListaProductos.Item(5, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
                VentasCodMedida = medidas

                FlyoutDialog.Show(Me, New UserControlEmergentes())

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub DgvVentasListaProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvVentasListaProductos.KeyDown
        If e.KeyCode = Keys.Enter Then

            VentasNoSerie = "SN"
            VentasCorrelativo = Double.Parse(Me.txtVentasCorrelativo.Text)
            VentasCodProducto = Me.DgvVentasListaProductos.Item(0, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
            VentasDesProducto = Me.DgvVentasListaProductos.Item(1, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
            VentasCodMedida = Me.DgvVentasListaProductos.Item(2, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
            VentasExistencia = Double.Parse(Me.DgvVentasListaProductos.Item(5, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
            VentasCostoProducto = Double.Parse(Me.DgvVentasListaProductos.Item(11, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
            VentasExento = Integer.Parse(Me.DgvVentasListaProductos.Item(12, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
            If VentasExento = 1 Then
                VentasIvaProducto = 0
            Else
                VentasIvaProducto = GlobalConfigIVA
            End If

            VentasEquivale = Integer.Parse(Me.DgvVentasListaProductos.Item(3, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
            VentasPrecioProducto = Double.Parse(Me.DgvVentasListaProductos.Item(4, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString)
            VentasAnio = Me.txtVentasFecha.DateTime.Year
            VentasMes = Me.txtVentasFecha.DateTime.Month
            'GlobalSelectedColor = Integer.Parse(Me.DGVVentaListaProductos.Item(18, Me.DGVVentaListaProductos.CurrentRow.Index).Value.ToString)
            Call EmergenteFac(Me)

        End If
        If e.KeyCode = Keys.Add Then
            Dim busqueda As String
            busqueda = Me.DgvVentasListaProductos.Item(1, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
            busqueda = Strings.Replace(busqueda, " ", "+", 1, -1, CompareMethod.Text)
            Process.Start("https://www.google.com.gt/search?q=" & busqueda & "&tbm=isch&tbo=u&source=univ&sa=X&ved=0ahUKEwif8t3umsbVAhVI4yYKHXTIA3MQ7AkIMg&biw=1024&bih=652#imgrc=_")
        End If

        If e.KeyCode = Keys.P Then
            VentasCodProducto = Me.DgvVentasListaProductos.Item(0, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
            VentasDesProducto = Me.DgvVentasListaProductos.Item(1, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString

            'FlyoutDialog.Show(Me, New viewProductosPreciosCompetencia(GlobalEmpNit, VentasCodProducto, VentasDesProducto))

        End If
        If e.KeyCode = Keys.Multiply Then
            VentasCodProducto = Me.DgvVentasListaProductos.Item(0, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
            FlyoutDialog.Show(Me, New viewProductInfo(GlobalEmpNit, VentasCodProducto))
        End If

        'consulta inventario en otras empresas
        If e.KeyCode = Keys.I Then
            VentasCodProducto = Me.DgvVentasListaProductos.Item(0, Me.DgvVentasListaProductos.CurrentRow.Index).Value.ToString
            FlyoutDialog.Show(Me, New viewInventarioOnline(GlobalEmpNit, VentasCodProducto))
        End If

    End Sub

    Public Sub EmergenteFac(ByVal Owner As Form)

        Dim controlold As New UserControl_VentaCantidad(GlobalModoPOS, GlobalTipoPrecioSucursal)
        Dim control As New viewVentasCantidad(GlobalModoPOS, True)

        nitclien = Me.txtVentasNitClie.Text
        'MsgBox(nitclien)

        If FlyoutDialog.Show(Owner, control) = DialogResult.OK Then

            'esto es temporal hasta averiguar por qué no carga el total factura
            Call DobleCargarTotalFactura()

            Call CargarGridTempVentas()

            Select Case SelectedForm
                Case "VENTAS"

                    Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()
                Case "LISTADOS"
                    Call CargarTotalVenta(SelectedCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()
                Case "ENVIOS"
                    Call CargarTotalVenta(GlobalCoddocENVIOS, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()
                Case "COTIZACIONES"
                    Call CargarTotalVenta(GlobalCoddocCOTIZ, Double.Parse(Me.txtVentasCorrelativo.Text))
                    Me.txtVentasFiltro.Text = ""
                    Me.txtVentasCodProd.select()

            End Select

        End If

        Me.txtVentasCodProd.select()

    End Sub



    Private Sub DobleCargarTotalFactura()
        Exit Sub 'para evitar que se ejecute la sumatoria

        Select Case SelectedForm
            Case "VENTAS"
                Call CargarTotalVenta(GlobalCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
            Case "LISTADOS"
                Call CargarTotalVenta(SelectedCoddoc, Double.Parse(Me.txtVentasCorrelativo.Text))
            Case "ENVIOS"
                Call CargarTotalVenta(GlobalCoddocENVIOS, Double.Parse(Me.txtVentasCorrelativo.Text))
            Case "COTIZACIONES"
                Call CargarTotalVenta(GlobalCoddocCOTIZ, Double.Parse(Me.txtVentasCorrelativo.Text))
        End Select
    End Sub

    Private Sub lbVentasTipoPrecio_SelectedIndexChanged(sender As Object, e As EventArgs)
        Call CargarDGVListaProductos(1)
    End Sub

    Private Sub DgvVentasListaProductos_Sorted(sender As Object, e As EventArgs) Handles DgvVentasListaProductos.Sorted
        Call MostrarPintarColorExistencias()
    End Sub

    '12345
    Public Sub CargarDGVListaProductos(ByVal NoFiltro As Integer) 'carga el dgv tanto en ventas como en movimientos inventario

        Me.lbVentasTipoPrecio.Text = "CAT. A"
        Dim strErrores As String = ""
        Try
            Dim tbldata As New DS_VENTAS2.tblVentasListaProductosDataTable
            Dim tipoprecio As String
            'DETERMINA EL TIPO DE PRECIO SEGÚN CLIENTE


            Dim Filtro As String
            Select Case SelectedForm
                Case "VENTAS"
                    Filtro = Me.txtVentasFiltro.Text
                Case "LISTADOS"
                    Filtro = Me.txtVentasFiltro.Text
                Case "ENVIOS"
                    Filtro = Me.txtVentasFiltro.Text
                Case "COTIZACIONES"
                    Filtro = Me.txtVentasFiltro.Text
            End Select

            Dim sql As String

            Dim selectfrom As String
            selectfrom = "SELECT 
                                PRODUCTOS.CODPROD, 
                                PRODUCTOS.DESPROD, 
                                PRECIOS.CODMEDIDA AS MEDIDA,
                                PRECIOS.EQUIVALE,
                                PRECIOS.PRECIO AS PRECIO, 
                                ISNULL(PRECIOS.EQUIVALE,0) * ISNULL(PRODUCTOS.BONO,0) AS IP,
                                INVSALDO.SALDO AS SALDO,
                                (CASE WHEN INVSALDO.SALDO <= 0 THEN 'NO' ELSE 'SI' END) AS EXISTENCIA,
                                MARCAS.DESMARCA AS MARCA, 
                                PRECIOS.COSTO,
                                PRODUCTOS.EXENTO, 
                                PRODUCTOS.DESPROD2 AS COMPONENTES,
                                PRODUCTOS.DESPROD3 AS USO
                            FROM
                                INVSALDO RIGHT OUTER JOIN PRECIOS RIGHT OUTER JOIN MARCAS RIGHT OUTER JOIN CLASIFICACIONDOS RIGHT OUTER JOIN
                                PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                                CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                                MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND 
                                INVSALDO.CODPROD = PRODUCTOS.CODPROD
                            WHERE "

            Select Case NoFiltro
                Case 0 'todos
                    sql = selectfrom & "(PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') ORDER BY PRODUCTOS.DESPROD"
                Case 1 'todos
                    sql = selectfrom & "(PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') ORDER BY PRODUCTOS.DESPROD"

                Case 2 'por descripcion
                    sql = selectfrom & "(PRODUCTOS.DESPROD LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') ORDER BY PRODUCTOS.DESPROD"

                Case 3 'por componente
                    sql = selectfrom & "(PRODUCTOS.DESPROD2 LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') ORDER BY PRODUCTOS.DESPROD"

                Case 4 'por uso
                    sql = selectfrom & "(PRODUCTOS.DESPROD3 LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') ORDER BY PRODUCTOS.DESPROD"

                Case 5 'por marca
                    sql = selectfrom & "(MARCAS.DESMARCA LIKE @FILTRO) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO='SI') ORDER BY PRODUCTOS.DESPROD"
            End Select
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", GlobalAnioProceso) 'Integer.Parse(Me.cmdAnioProceso.Text))
                cmd.Parameters.AddWithValue("@MES", GlobalMesProceso) 'Integer.Parse(Me.cmdMesProceso.SelectedValue))

                If NoFiltro > 1 Then
                    cmd.Parameters.AddWithValue("@FILTRO", "%" & Filtro & "%")
                End If

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbldata)

                cn.Close()

                If strErrores.Length = 0 Then
                Else
                    Mensaje("Pueden haber productos mal guardados o sin precio, por favor verifica el archivo ErrorLog.exe")
                End If
            End Using


            Select Case SelectedForm
                Case "VENTAS"
                    Me.DgvVentasListaProductos.DataSource = tbldata
                    Me.DgvVentasListaProductos.Refresh()

                    Call MostrarPintarColorExistencias()


                ' PARA MOSTRAR LOS PRODUCTOS QUE NO SE FACTURAN
                'For Each Row As DataGridViewRow In Me.DgvVentasListaProductos.Rows
                'Select Case Integer.Parse(Row.Cells("NF").Value)
                'Case 0 'blanco normal

                'Case 1 ' amarillo
                'Row.DefaultCellStyle.BackColor = Color.Yellow
                'Case 2 'verde
                'Row.DefaultCellStyle.BackColor = Color.GreenYellow
                'Case 3 'azul
                'Row.DefaultCellStyle.BackColor = Color.CadetBlue
                'Case 4 'cafes
                'Row.DefaultCellStyle.BackColor = Color.SaddleBrown
                'Case 5 'morado
                'Row.DefaultCellStyle.BackColor = Color.MediumPurple
                'Case 6 'aqua
                'Row.DefaultCellStyle.BackColor = Color.Aqua
                'Case Else

                'End Select

                'Next


                Case "LISTADOS"
                    Me.DgvVentasListaProductos.DataSource = tbldata
                    Me.DgvVentasListaProductos.select()

                    For Each Row As DataGridViewRow In Me.DgvVentasListaProductos.Rows
                        If Double.Parse(Row.Cells("EXISTENCIA").Value) <= 0 Then
                            Row.DefaultCellStyle.BackColor = Color.LightSalmon
                        End If
                    Next

            End Select



        Catch ex As Exception
            MsgBox(ex.ToString)
            'Mensaje("Tengo problemas para cargar la lista de productos")
        End Try

        Try
            'Dim objF As New classFunciones
            'Dim f As Boolean = Await Task(Of Boolean).Run(Function() objF.fcnCrearLog(strErrores))

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

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

    ' VERIFICA EL NIVEL DE USUARIO PARA MOSTRAR LAS EXISTENCIAS / VENTAS,COTIZ,PEDIDOS
    Private Sub MostrarPintarColorExistencias()

        For Each Row As DataGridViewRow In Me.DgvVentasListaProductos.Rows
            If Double.Parse(Row.Cells("IP").Value) > 0.00 Then
                Row.DefaultCellStyle.BackColor = Color.SkyBlue
            End If
            If Row.Cells("EXISTENCIA").Value = "NO" Then
                Row.DefaultCellStyle.BackColor = Color.LightSalmon
            End If
        Next

        Call PermisoExistencia()
        Select Case NivelUsuario
            Case 1 Or 3

                For Each Row As DataGridViewRow In Me.DgvVentasListaProductos.Rows
                    If Double.Parse(Row.Cells("SALDO").Value) <= 0 Then
                        Row.DefaultCellStyle.BackColor = Color.LightSalmon
                    End If
                Next

            Case 2
                If ExisSiNo = "SI" Then
                    Me.DgvVentasListaProductos.Columns.Item(5).Visible = True
                Else
                    Me.DgvVentasListaProductos.Columns.Item(5).Visible = False
                End If
        End Select

    End Sub


    Private Sub cmdVentasFiltroDescripcion_Click(sender As Object, e As EventArgs) Handles cmdVentasFiltroDescripcion.Click
        If Me.txtVentasFiltro.Text <> "" Then
            Call CargarDGVListaProductos(2)
        End If
    End Sub

    Private Sub cmdVentasFiltroDescripcion2_Click(sender As Object, e As EventArgs) Handles cmdVentasFiltroDescripcion2.Click
        If Me.txtVentasFiltro.Text <> "" Then
            Call CargarDGVListaProductos(3)
        End If
    End Sub

    Private Sub cmdVentasDescripcion3_Click(sender As Object, e As EventArgs) Handles cmdVentasFiltroDescripcion3.Click
        If Me.txtVentasFiltro.Text <> "" Then
            Call CargarDGVListaProductos(4)
        End If
    End Sub

    Private Sub cmdVentasFiltroMarca_Click(sender As Object, e As EventArgs) Handles cmdVentasFiltroMarca.Click
        If Me.txtVentasFiltro.Text <> "" Then
            Call CargarDGVListaProductos(5)
        End If
    End Sub

    Private Sub TileViewTempProductos_DoubleClick(sender As Object, e As EventArgs) Handles TileViewTempProductos.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewTempProductos.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            SelectedCode = Integer.Parse(TileViewTempProductos.GetRowCellValue(hitInfo.RowHandle, "ID").ToString)

            If FlyoutDialog.Show(Me, New viewEditSalesItem(GlobalEmpNit, SelectedCode)) = DialogResult.OK Then

                Call CargarGridTempVentas()

                'recarga el total del documento
                Call DobleCargarTotalFactura()

                Me.txtVentasCodProd.select()

            End If

        End If
    End Sub

    ''' <summary>
    ''' Elimina un item de la tabla temporal de documentos
    ''' </summary>
    ''' <param name="idItem"></param>
    ''' <returns></returns>
    Private Function fcn_eliminar_item_documento(ByVal idItem As Integer) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'elimina el registro de la tabla temporal
                Dim SQL As String
                SQL = "DELETE FROM TEMP_VENTAS WHERE ID=" & idItem

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Private Sub cmdVentasCobrar_Click(sender As Object, e As EventArgs) Handles cmdVentasCobrar.Click
        'carga el total de las facturas

        Call CargarGridTempVentas()
        Call DobleCargarTotalFactura()

        If Me.txtVentasCodCliente.Text <> "" Then

            If Double.Parse(Me.LbTotalVenta.Text) > 0 Then

                If Double.Parse(Me.LbTotalVenta.Text) >= 2500 Then

                    If Me.txtVentasNitClie.Text <> "CF" Then

                        'asigna el monto de ventas a la variable global
                        VentasTotalVenta = Double.Parse(Me.lbVentasTotalPagar.Text)

                        'asigna el codigo de cajas
                        VentasCodCaja = CType(Me.cmbVentasCaja.SelectedValue, Integer)


                        'verifica que se haya tomado de un pedido
                        If PedidoTomado = False Then

                            If Me.SwitchConfigClaveVendedor.IsOn = True Then
                                'GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)
                                Dim control As New UserControlCLAVEVend
                                FlyoutDialog.Show(Me, control)
                            Else
                                If Me.cmbVentasVendedor.SelectedValue > 0 Then
                                    GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)

                                    Dim control As New UserControlCobrar
                                    FlyoutDialog.Show(Me, control)
                                Else
                                    Call Aviso("Importante", "Seleccione un vendedor de la lista", Me)
                                    Exit Sub
                                End If
                            End If

                            'siendo un pedido lo cobra 
                        Else

                            Dim control As New UserControlCobrar
                            FlyoutDialog.Show(Me, control)

                        End If

                    Else

                        MsgBox("Facturas mayores a Q 2,500.00 no pueden ir en CF, por favor solicite numero de nit o CUI")
                        Exit Sub

                    End If

                Else

                    'asigna el monto de ventas a la variable global
                    VentasTotalVenta = Double.Parse(Me.lbVentasTotalPagar.Text)

                    'asigna el codigo de cajas
                    VentasCodCaja = CType(Me.cmbVentasCaja.SelectedValue, Integer)


                    'verifica que se haya tomado de un pedido
                    If PedidoTomado = False Then

                        If Me.SwitchConfigClaveVendedor.IsOn = True Then
                            'GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)
                            Dim control As New UserControlCLAVEVend
                            FlyoutDialog.Show(Me, control)
                        Else
                            If Me.cmbVentasVendedor.SelectedValue > 0 Then
                                GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)

                                Dim control As New UserControlCobrar
                                FlyoutDialog.Show(Me, control)
                            Else
                                Call Aviso("Importante", "Seleccione un vendedor de la lista", Me)
                                Exit Sub
                            End If
                        End If

                        'siendo un pedido lo cobra 
                    Else

                        Dim control As New UserControlCobrar
                        FlyoutDialog.Show(Me, control)
                    End If

                End If

            End If

        Else
            Me.txtVentasNitClie.Text = ""
            Call Aviso("Importante", "Seleccione un Cliente o escriba el NIT del mismo", Me)
        End If
    End Sub

    Public Sub CobrarVentas()

        'carga el total de las facturas

        Call CargarGridTempVentas()
        Call DobleCargarTotalFactura()

        If Me.txtVentasCodCliente.Text <> "" Then

            If Double.Parse(Me.LbTotalVenta.Text) > 0 Then

                If Double.Parse(Me.LbTotalVenta.Text) >= 2500 Then

                    If Me.txtVentasNitClie.Text <> "CF" Then

                        'asigna el monto de ventas a la variable global
                        VentasTotalVenta = Double.Parse(Me.lbVentasTotalPagar.Text)

                        'asigna el codigo de cajas
                        VentasCodCaja = CType(Me.cmbVentasCaja.SelectedValue, Integer)


                        'verifica que se haya tomado de un pedido
                        If PedidoTomado = False Then

                            If Me.SwitchConfigClaveVendedor.IsOn = True Then
                                'GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)
                                Dim control As New UserControlCLAVEVend
                                FlyoutDialog.Show(Me, control)
                            Else
                                If Me.cmbVentasVendedor.SelectedValue > 0 Then
                                    GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)

                                    Dim control As New UserControlCobrar
                                    FlyoutDialog.Show(Me, control)
                                Else
                                    Call Aviso("Importante", "Seleccione un vendedor de la lista", Me)
                                    Exit Sub
                                End If
                            End If

                            'siendo un pedido lo cobra 
                        Else

                            Dim control As New UserControlCobrar
                            FlyoutDialog.Show(Me, control)
                        End If

                    Else

                        MsgBox("Facturas mayores a Q 2,500.00 no pueden ir en CF, por favor solicite numero de nit o CUI")
                        Exit Sub

                    End If

                Else

                    'asigna el monto de ventas a la variable global
                    VentasTotalVenta = Double.Parse(Me.lbVentasTotalPagar.Text)

                    'asigna el codigo de cajas
                    VentasCodCaja = CType(Me.cmbVentasCaja.SelectedValue, Integer)


                    'verifica que se haya tomado de un pedido
                    If PedidoTomado = False Then

                        If Me.SwitchConfigClaveVendedor.IsOn = True Then
                            'GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)
                            Dim control As New UserControlCLAVEVend
                            FlyoutDialog.Show(Me, control)
                        Else
                            If Me.cmbVentasVendedor.SelectedValue > 0 Then
                                GlobalCodVend = Integer.Parse(Me.cmbVentasVendedor.SelectedValue)

                                Dim control As New UserControlCobrar
                                FlyoutDialog.Show(Me, control)
                            Else
                                Call Aviso("Importante", "Seleccione un vendedor de la lista", Me)
                                Exit Sub
                            End If
                        End If

                        'siendo un pedido lo cobra 
                    Else

                        Dim control As New UserControlCobrar
                        FlyoutDialog.Show(Me, control)
                    End If

                End If

            End If

        Else
            Me.txtVentasNitClie.Text = ""
            Call Aviso("Importante", "Seleccione un Cliente o escriba el NIT del mismo", Me)
        End If

    End Sub

    Public Sub VentasAbrirCobro()
        If Me.cmbVentasCaja.SelectedIndex >= 0 Then
            If Me.cmbVentasCaja.Text <> "" Then
                Dim control As New UserControlCobrar
                FlyoutDialog.Show(Me, control)
            Else
                MsgBox("ERROR")
            End If

        Else
            MsgBox("Seleccione una caja Válida")
        End If

    End Sub

    Public PagoCliente As Double
    Public PagoClienteTarjeta As Double = 0
    Public PagoRecargoTarjeta As Double = 0

    Public Function GuardarVenta() As Boolean
        Dim result As Boolean

        'RECARGA EL CORRELATIVO DEL DOCUMENTO POR CUALQUIER COSA XD
        'CAMBIA EL CODDOC GLOBAL POR EL SELECCIONADO EN EL COMBOBOX

        Select Case SelectedForm
            Case "VENTAS"
                'GlobalCoddoc = Me.cmbVentasCoddoc.SelectedValue.ToString
                GlobalCoddoc = GlobalCoddocFinal
                Call CargarCorrelativoVentas()

            Case "ENVIOS"
                GlobalCoddocENVIOS = Me.cmbVentasCoddoc.SelectedValue.ToString
                Call CargarCorrelativoVentas()
            Case "LISTADOS"

            Case "COTIZACIONES"
                GlobalCoddocCOTIZ = Me.cmbVentasCoddoc.SelectedValue.ToString
                Call CargarCorrelativoVentas()

        End Select

        'ESPERA A VER SI HAY VENDEDOR SELECCIONADO
        If Me.cmbVentasVendedor.SelectedIndex >= 0 Then

            Dim stConCre As String
            If VentasConCre = "CON" Then
                stConCre = "CONTADO"
            Else
                stConCre = "CREDITO"
            End If

            'GUARDA EL REGISTRO EN LA TABLA DE DOCUMENTOS

            If fcn_InsertDocumentos() = True Then

                Do Until fcn_InsertDocproductos() = True
                    Call Mensaje("Reintentando guardar el detalle de productos...")
                Loop

                GoTo FINDELGUARDADO

            Else
                MsgBox(GlobalDesError)
                Return False
                MsgBox("Lo siento, deber verificar tu conexión al servidor, pues no me ha dejado guardar tu documento, inténtalo de nuevo")
                Exit Function
            End If

FINDELGUARDADO:

            'prosigue 
            Select Case SelectedForm
                Case "VENTAS"
                    Call Mensaje("Venta registrada exitosamente")
                Case "ENVIOS"
                    Call Mensaje("Venta registrada exitosamente")
                Case "COTIZACIONES"
                    If GenerarCotizacion(Me.cmbVentasCoddoc.SelectedValue.ToString, Double.Parse(Me.txtVentasCorrelativo.Text), Me.txtVentasFecha.DateTime) = True Then
                        Try

                            Call EnviarGmailAdjunto("Cotización" & GlobalNomEmpresa, "Estimado Cliente:
Es un gusto para nosotros poderle brindar la siguiente cotización de nuestros productos. 
Gracias por su preferencia !!", GlobalEmailEnviar, Application.StartupPath + "\CotizacionDelCliente.pdf")

                            MsgBox("Cotización enviada exitosamente")

                        Catch ex As Exception
                            MsgBox("Lo siento, al parecer tu email está mal escrito o quizás no tengas conexión a internet, por lo que no puedo enviar la cotización")
                        End Try
                    End If

                    Call Mensaje("Cotización registrada exitosamente")

                Case "LISTADOS"
                    Call Mensaje("Venta registrada exitosamente")
            End Select

            Me.LbTotalCosto.Text = "0"
            Me.LbTotalVenta.Text = "0.00"
            Me.lbVentasTotalIva.Text = "0.00"
            Me.lbVentasTotalExento.Text = "0.00"
            Me.GridVentasTempProductos.DataSource = Nothing


            Call getObjetivoVenta()
            Call getRentabilidadTotalMes()
            Call getRentabilidadTotalDia()
            Call CargarDGVVentaEmp()
            Call getObjetivoDiario()

            'abrir reporte

            Select Case SelectedForm
                Case "VENTAS"
                    If PedidoTomado = True Then Call PedidoCorteSi(PedidoSeleccionadoCoddoc, PedidoSeleccionadoCorrelativo)

                    Dim fechaventa As Date, correlativoventa As Double
                    fechaventa = Me.txtVentasFecha.DateTime
                    correlativoventa = Double.Parse(Me.txtVentasCorrelativo.Text)

                    Me.cmbVentasCoddoc.SelectedValue = GlobalCoddoc

                    Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
                    GlobalSelectedTipoDocumento = objTipoDoc.getTipoDocumento(Me.cmbVentasCoddoc.SelectedValue.ToString)

                    Call ActualizarCorrelativo()
                    Call CargarCorrelativoVentas()

                    Call CargarDGVListaProductos(1)

                    Me.txtVentasCodProd.select()

                    'si el switch está activado entonces integer = 2 para que lo lanze a pantalla
                    'si no, integer = 1 para que lo mande a impresora directo
                    'SI EL INTEGER VIENE EN CERO NO HAGO NADA
                    'si globalinteger viene en 1, significa que el switch de impresiòn està activado
                    'y compara si en config lo manda a pantalla o lo manda  impresora
                    If GlobalInteger = 1 Then
                        If Me.SwitchConfigFormatoCorte.IsOn = True Then
                            GlobalInteger = 2
                        Else
                            GlobalInteger = 1
                        End If
                    End If

                    'SELECCIONA EL TIPO DOCUMENTO FEL
                    If GlobalSelectedTipoDocumento = "FAC" Then

                        'SI ES UNA FACTURA NORMAL DEL SISTEMA, IMPRIME EL TICKET NORMAL
                        If AbrirReporte_Ticket(fechaventa, GlobalCoddoc, correlativoventa, GlobalInteger) = True Then
                        End If

                    Else

                        'DIRIGE A LA FUNCIÓN FEL PARA DETERMINAR QUE ONDA
                        Call fcnFEL_GenerarDocumento(fechaventa, GlobalCoddoc, correlativoventa)

                    End If

                    'VUELVE A MOSTRAR LA INFO DEL OBJETIVO
                    If CType(Me.cmbVentasVendedor.SelectedValue, Integer) >= 0 Then


                        Call getObjetivoVenta()
                        Call getRentabilidadTotalMes()
                        Call getRentabilidadTotalDia()
                        Call CargarDGVVentaEmp()
                        Call getObjetivoDiario()
                        Call NAVEGAR("ACTINV_2CORTE")

                    End If

                'Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)
                'Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
                'If objInventarios.fcn_actu_invfsya(GlobalEmpNit) = True Then
                'MsgBox("INVENTARIO ACTUALIZADO")
                'If objS.fcnDeleteInvsaldo(GlobalEmpNit) = True Then
                'MsgBox("INVSALDO EN HOST LIMPIADO")
                'If objS.fcnSendBackupFInventario(GlobalEmpNit) = True Then
                'MsgBox("INVSALDO EN HOST ACTUALIZADO")
                'Else
                'End If
                'Else
                'End If
                'Else
                'End If


                Case "ENVIOS"

                    Dim fechaventa As Date, correlativoventa As Double
                    fechaventa = Me.txtVentasFecha.DateTime
                    correlativoventa = Double.Parse(Me.txtVentasCorrelativo.Text)

                    Call ActualizarCorrelativo()
                    Call CargarCorrelativoVentas()


                    Call CargarDGVListaProductos(1)

                    Me.txtVentasCodProd.select()

                    Dim x As Integer
                    x = MsgBox("¿Desea Imprimir el Envio?", MsgBoxStyle.OkCancel)
                    If x = MsgBoxResult.Ok Then
                        If rptEnviosTicket(fechaventa, GlobalCoddocENVIOS, correlativoventa, 2) = True Then

                        End If
                    End If

                Case "COTIZACIONES"
                    Call AbrirReporte_Cotizacion(Me.txtVentasFecha.DateTime, GlobalCoddocCOTIZ, Double.Parse(Me.txtVentasCorrelativo.Text), 1)
                    Call ActualizarCorrelativo()
                    Call CargarCorrelativoVentas()


                    Call CargarDGVListaProductos(1)

                    Me.txtVentasCodProd.select()

            End Select

            Me.txtVentasNitClie.Text = "CF"
            Me.txtVentasNombre.Text = "Consumidor Final"

            Me.txtVentasFecha.DateTime = Today.Date

            result = True

        Else

            result = False

            Call Aviso("Importante", "Selecciona un vendedor para continuar", Me)
        End If

        If result = True Then 'VERIFICA SI LA VENTA YA SE EFECTUÓ
            If SelectedForm = "VENTAS" Then
                If GlobalBool = True Then 'implica que viene de la ventana de pedidos pre-venta y lo regresa allá
                    Call NAVEGAR("SYNC2")
                End If
            End If
        End If

        Return result

    End Function

    'GENERACION DE DOCUMENTOS FEL
    Private Sub fcnFEL_GenerarDocumento(ByVal fecha As Date, ByVal coddoc As String, ByVal correlativo As Double)

        '-----------------------------------
        'CERTIFICACION NORMAL 
        '-----------------------------------


        'OBTIENE LA DIRECCION DEL CLIENTE PARA ENVIARLO A LA ELECTRONICA
        Dim objclie As New classClientes(GlobalEmpNit)
        Dim direccionclie As String = objclie.getDireccionCliente(Integer.Parse(Me.txtVentasCodCliente.Text))

        '*******************************************
        'FACTURA FEL IVA NORMAL
        '*******************************************
        If GlobalSelectedTipoDocumento = "FEF" Then

            Dim f As String = DateTime.Now.ToShortDateString()
            Dim fel As New classFEL
            If fel.facturaIVA_Normal(f, GlobalCoddoc, correlativo, Me.txtVentasNitClie.Text, Me.txtVentasNombre.Text, "", direccionclie, "GUATEMALA", "GUATEMALA") = True Then

                'actualiza los datos FEL del documento
                GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                If Me.switchConfigClienteRecordatorios.IsOn = True Then
                    'abre la página con la factura
                    Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)
                End If

                'actualiza el documento interno con los datos de FEL
                If fel.updateDocumentoFEL(GlobalEmpNit, GlobalCoddoc, correlativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                    Call Mensaje("Serie FEL asignada a la factura del sistema")
                Else
                    Call Mensaje("No se logró actualizar el correlativo en el documento local")
                End If

                'abre el reporte imprimible FEL
                fel.rptFacturaFEL(GlobalCoddoc, correlativo, GlobalInteger)

            Else
                'proceso de contingencia
                MsgBox("Se enviará a factura en contingencia o intentará nuevamente, vea el mensaje de error: ")
                MsgBox(GlobalDesError)

                'abre el reporte imprimible FEL CONTINGENCIA
                fel.rptFacturaFELCONTINGENCIA(GlobalCoddoc, correlativo, GlobalInteger)

            End If

        End If
        'FIN FACTURA IVA NORMAL
        '*******************************************

        '*******************************************
        'FACTURA FEL CAMBIARIA
        '*******************************************
        If GlobalSelectedTipoDocumento = "FEC" Then

            Dim f As String = DateTime.Now.ToShortDateString()
            Dim fel As New classFEL
            If fel.facturaIVA_Cambiaria(f, GlobalCoddoc, correlativo, Me.txtVentasNitClie.Text, Me.txtVentasNombre.Text, "", direccionclie, "GUATEMALA", "GUATEMALA", GlobalSelectedFechaVence, 3) = True Then

                'actualiza los datos FEL del documento
                GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                'actualiza el documento interno con los datos de FEL
                If fel.updateDocumentoFEL(GlobalEmpNit, GlobalCoddoc, correlativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                    Call Mensaje("Serie FEL asignada a la factura del sistema")
                Else
                    Call Mensaje("No se logró actualizar el correlativo en el documento local")
                End If

                'abre la página con la factura
                Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)

                'abre el reporte imprimible FEL
                'fel.rptFacturaFEL(GlobalCoddoc, correlativo, GlobalInteger)

            Else
                'proceso de contingencia
                MsgBox("Se enviará a factura en contingencia o intentará nuevamente")
                MsgBox(GlobalDesError)

                'abre el reporte imprimible FEL CONTINGENCIA
                fel.rptFacturaFELCONTINGENCIA(GlobalCoddoc, correlativo, GlobalInteger)

            End If

        End If
        'FIN FACTURA CAMBIARIA
        '*******************************************

        '*******************************************
        'FACTURA FEL ESPECIAL
        '*******************************************
        If GlobalSelectedTipoDocumento = "FES" Then
            Dim f As String = DateTime.Now.ToShortDateString()
            Dim fel As New classFEL
            If fel.facturaIVA_Especial(f, GlobalCoddoc, correlativo, Me.txtVentasNitClie.Text, Me.txtVentasNombre.Text, "", direccionclie, "GUATEMALA", "GUATEMALA") = True Then

                'actualiza los datos FEL del documento
                GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                If Me.switchConfigClienteRecordatorios.IsOn = True Then
                    'abre la página con la factura
                    Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)
                End If

                'actualiza el documento interno con los datos de FEL
                If fel.updateDocumentoFEL(GlobalEmpNit, GlobalCoddoc, correlativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                    Call Mensaje("Serie FEL asignada a la factura del sistema")
                Else
                    Call Mensaje("No se logró actualizar el correlativo en el documento local")
                End If

                'abre el reporte imprimible FEL
                fel.rptFacturaFEL(GlobalCoddoc, correlativo, GlobalInteger)

            Else
                'proceso de contingencia
                MsgBox("Se enviará a factura en contingencia o intentará nuevamente, vea el mensaje de error: ")
                MsgBox(GlobalDesError)

                'abre el reporte imprimible FEL CONTINGENCIA
                fel.rptFacturaFELCONTINGENCIA(GlobalCoddoc, correlativo, GlobalInteger)
            End If

        End If
        'FIN FACTURA ESPECIAL
        '*******************************************



        '-----------------------------------
        '-----------------------------------


    End Sub

    Private Sub checkMOS_CheckedChanged(sender As Object, e As EventArgs) Handles checkMOS.CheckedChanged

        If Me.checkMOS.Checked = True Then

            Me.checkDOM.Checked = False

        End If

    End Sub

    Private Sub checkDOM_CheckedChanged(sender As Object, e As EventArgs) Handles checkDOM.CheckedChanged

        If Me.checkDOM.Checked = True Then

            Me.checkMOS.Checked = False

        End If

    End Sub

    Private Function objVenta()

        Dim obj As String

        If Me.checkMOS.Checked = True Then
            obj = "MOSTRADOR"

        End If

        If Me.checkDOM.Checked = True Then
            obj = "DOMICILIO"
        End If

        Return obj


    End Function


    Private Function fcn_InsertDocumentos() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim qry1 As String = "INSERT INTO DOCUMENTOS  (EMPNIT,ANIO,MES,DIA,FECHA,HORA,MINUTO,	CODDOC,CORRELATIVO,CODCLIENTE,DOC_NIT,DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,TOTALPRECIO,CODEMBARQUE,STATUS,CONCRE,USUARIO,CORTE,SERIEFAC,NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_ABONO, DOC_SALDO,TOTALTARJETA, RECARGOTARJETA,CODREP,TOTALEXENTO,DIRENTREGA,VENCIMIENTO,DIASCREDITO,CODCAJA,TOTALIVA,TOTALSINIVA,TIPOVENTA, TOTALDESCUENTO, IDENTIFICADOR)   VALUES (@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,@CODDOC,@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,@DIRECCION,@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',@CONCRE,@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,(@PAGO-@TOTALPRECIO),'NO',@OBS,@ABONO,@SALDO,@PAGOTARJETA,@RECARGOTARJETA,@CODREP,@TOTALEXENTO,@DIRENTREGA,@FECHAVENCE,@DIASCREDITO,@CODCAJA,@TOTALIVA,@TOTALSINIVA,@TIPOVENTA,@TOTALDESCUENTO, @IDENTIFICADOR)"

                Dim cmd As New SqlCommand(qry1, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Me.txtVentasFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@MES", Me.txtVentasFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@DIA", Me.txtVentasFecha.DateTime.Day)
                cmd.Parameters.AddWithValue("@FECHA", Me.txtVentasFecha.DateTime)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtVentasCorrelativo.Text))
                cmd.Parameters.AddWithValue("@CODCLIENTE", Integer.Parse(Me.txtVentasCodCliente.Text))
                cmd.Parameters.AddWithValue("@NIT", Me.txtVentasNitClie.Text)
                cmd.Parameters.AddWithValue("@NOMBRE", Me.txtVentasNombre.Text)
                cmd.Parameters.AddWithValue("@DIRECCION", VentasDirEntrega)

                cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.LbTotalCosto.Text))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.LbTotalVenta.Text))
                cmd.Parameters.AddWithValue("@TOTALEXENTO", Double.Parse(Me.lbVentasTotalExento.Text))


                cmd.Parameters.AddWithValue("@CODEMBARQUE", "GENERAL")
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@NOFAC", Me.txtVentasCorrelativo.Text)
                cmd.Parameters.AddWithValue("@CODVEN", GlobalCodVend) ' Integer.Parse(Me.cmbVentasVendedor.SelectedValue.ToString))
                cmd.Parameters.AddWithValue("@OBS", VentasObs)
                cmd.Parameters.AddWithValue("@DIRENTREGA", VentasDirEntrega)
                cmd.Parameters.AddWithValue("@TIPOVENTA", GlobalTipoVenta)
                cmd.Parameters.AddWithValue("@IDENTIFICADOR", objVenta)

                'DATOS DEL VENCIMIENTO DEL DOCUMENTO
                cmd.Parameters.AddWithValue("@FECHAVENCE", VentasFechaVencimiento)
                cmd.Parameters.AddWithValue("@DIASCREDITO", VentasDiasCredito)

                Select Case SelectedForm
                    Case "VENTAS"
                        cmd.Parameters.AddWithValue("@TOTALDESCUENTO", Double.Parse(Me.lbVentasTotalDescuento.Text))

                        cmd.Parameters.AddWithValue("@TOTALIVA", Double.Parse(Me.lbVentasTotalIva.Text))
                        cmd.Parameters.AddWithValue("@TOTALSINIVA", Double.Parse(Me.LbTotalVenta.Text) - Double.Parse(Me.lbVentasTotalIva.Text))

                        cmd.Parameters.AddWithValue("@CODCAJA", VentasCodCaja)
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@SERIEFAC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@PAGO", PagoCliente)
                        cmd.Parameters.AddWithValue("@PAGOTARJETA", PagoClienteTarjeta)
                        cmd.Parameters.AddWithValue("@RECARGOTARJETA", PagoRecargoTarjeta)
                        cmd.Parameters.AddWithValue("@CONCRE", VentasConCre)

                        Dim Saldo, Abono As Double
                        If VentasConCre = "CON" Then
                            Saldo = 0
                            Abono = Double.Parse(Me.LbTotalVenta.Text)
                        Else
                            Abono = 0
                            Saldo = Double.Parse(Me.LbTotalVenta.Text)
                        End If

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)

                    Case "LISTADOS"
                        cmd.Parameters.AddWithValue("@TOTALDESCUENTO", Double.Parse(Me.lbVentasTotalDescuento.Text))
                        cmd.Parameters.AddWithValue("@TOTALIVA", Double.Parse(Me.lbVentasTotalIva.Text))
                        cmd.Parameters.AddWithValue("@TOTALSINIVA", Double.Parse(Me.LbTotalVenta.Text) - Double.Parse(Me.lbVentasTotalIva.Text))
                        cmd.Parameters.AddWithValue("@CODCAJA", VentasCodCaja)
                        cmd.Parameters.AddWithValue("@CODDOC", SelectedCoddoc)
                        cmd.Parameters.AddWithValue("@SERIEFAC", SelectedCoddoc)
                        cmd.Parameters.AddWithValue("@PAGO", Double.Parse(Me.LbTotalVenta.Text))
                        cmd.Parameters.AddWithValue("@CONCRE", "CON")

                        Dim Saldo, Abono As Double
                        Saldo = 0
                        Abono = Double.Parse(Me.LbTotalVenta.Text)

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)
                        cmd.Parameters.AddWithValue("@PAGOTARJETA", PagoClienteTarjeta)
                        cmd.Parameters.AddWithValue("@RECARGOTARJETA", PagoRecargoTarjeta)
                    Case "ENVIOS"
                        cmd.Parameters.AddWithValue("@TOTALDESCUENTO", Double.Parse(Me.lbVentasTotalDescuento.Text))
                        cmd.Parameters.AddWithValue("@TOTALIVA", Double.Parse(Me.lbVentasTotalIva.Text))
                        cmd.Parameters.AddWithValue("@TOTALSINIVA", Double.Parse(Me.LbTotalVenta.Text) - Double.Parse(Me.lbVentasTotalIva.Text))
                        cmd.Parameters.AddWithValue("@CODCAJA", 0)
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@SERIEFAC", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@PAGO", 0)
                        cmd.Parameters.AddWithValue("@CONCRE", "CON")

                        Dim Saldo, Abono As Double
                        Saldo = 0
                        Abono = Double.Parse(Me.LbTotalVenta.Text)

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)
                        cmd.Parameters.AddWithValue("@PAGOTARJETA", 0)
                        cmd.Parameters.AddWithValue("@RECARGOTARJETA", 0)
                        VentasDirEntrega = "CIUDAD"
                        VentasObs = "SN"
                    Case "COTIZACIONES"
                        cmd.Parameters.AddWithValue("@TOTALDESCUENTO", Double.Parse(Me.lbVentasTotalDescuento.Text))
                        cmd.Parameters.AddWithValue("@TOTALIVA", Double.Parse(Me.lbVentasTotalIva.Text))
                        cmd.Parameters.AddWithValue("@TOTALSINIVA", Double.Parse(Me.LbTotalVenta.Text) - Double.Parse(Me.lbVentasTotalIva.Text))
                        cmd.Parameters.AddWithValue("@CODCAJA", 0)
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@SERIEFAC", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@PAGO", Double.Parse(Me.LbTotalVenta.Text))
                        cmd.Parameters.AddWithValue("@CONCRE", "CON")

                        Dim Saldo, Abono As Double
                        Saldo = 0
                        Abono = Double.Parse(Me.LbTotalVenta.Text)

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)
                        cmd.Parameters.AddWithValue("@PAGOTARJETA", 0)
                        cmd.Parameters.AddWithValue("@RECARGOTARJETA", 0)
                End Select

                If VentasCodRepartidor = 0 Then
                    cmd.Parameters.AddWithValue("@CODREP", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@CODREP", VentasCodRepartidor)
                End If

                cmd.ExecuteNonQuery()
                result = True

                VentasDirEntrega = "SN"
                VentasObs = "SN"
                GlobalTipoVenta = "MOSTRADOR"

            Catch ex As Exception
                GlobalDesError = ex.ToString

                result = False
            End Try

        End Using
        Return result

    End Function

    Private Function fcn_InsertDocproductos() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> 1 Then
                cn.Open()
            End If



            Try
                Dim qry As String = "INSERT INTO DOCPRODUCTOS 
                (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,
				    ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF,NOSERIE,EXENTO,OBS, TOTALIVA,TOTALSINIVA,DESCUENTO) 
	            SELECT EMPNIT,@ANIO AS ANIO, @MES AS MES,@DIA AS DIA, @CODDOC AS CODDOC,@CORRELATIVO AS CORRELATIVO, CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,
				    TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALUNIDADES,TOTALCOSTO,TOTALPRECIO,COSTO,COSTO,BONIF,TOTALBONIF,NOSERIE,EXENTO,OBS, PRECIOSINIVA AS TOTALIVA, TOTALPRECIOSINIVA AS TOTALSINIVA, DESCUENTO 
	            FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND USUARIO=@USUARIO AND CODDOC=@CODDOCI"

                'Dim cmd As New SqlCommand("INSERT_DOCUMENTOS_DOCPRODUCTOS", cn)

                Dim cmd As New SqlCommand(qry, cn)
                'cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Me.txtVentasFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@MES", Me.txtVentasFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@DIA", Me.txtVentasFecha.DateTime.Day)
                cmd.Parameters.AddWithValue("@FECHA", Me.txtVentasFecha.DateTime)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                Select Case SelectedForm
                    Case "VENTAS"
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@CODDOCI", Me.cmbVentasCoddoc.SelectedValue.ToString)
                        cmd.Parameters.AddWithValue("@SERIEFAC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@PAGO", PagoCliente)
                        cmd.Parameters.AddWithValue("@CONCRE", VentasConCre)
                        Dim Saldo, Abono As Double
                        If VentasConCre = "CON" Then
                            Saldo = 0
                            Abono = Double.Parse(Me.LbTotalVenta.Text)
                        Else
                            Abono = 0
                            Saldo = Double.Parse(Me.LbTotalVenta.Text)
                        End If

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)
                    Case "LISTADOS"
                        cmd.Parameters.AddWithValue("@CODDOC", SelectedCoddoc)
                        cmd.Parameters.AddWithValue("@CODDOCI", SelectedCoddoc)
                        cmd.Parameters.AddWithValue("@SERIEFAC", SelectedCoddoc)
                        cmd.Parameters.AddWithValue("@PAGO", Double.Parse(Me.LbTotalVenta.Text))
                        cmd.Parameters.AddWithValue("@CONCRE", "CON")

                        Dim Saldo, Abono As Double
                        Saldo = 0
                        Abono = Double.Parse(Me.LbTotalVenta.Text)

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)
                    Case "ENVIOS"
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@CODDOCI", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@SERIEFAC", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@PAGO", 0)
                        cmd.Parameters.AddWithValue("@CONCRE", "CON")

                        Dim Saldo, Abono As Double
                        Saldo = 0
                        Abono = Double.Parse(Me.LbTotalVenta.Text)

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)
                    Case "COTIZACIONES"
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@CODDOCI", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@SERIEFAC", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@PAGO", Double.Parse(Me.LbTotalVenta.Text))
                        cmd.Parameters.AddWithValue("@CONCRE", "CON")

                        Dim Saldo, Abono As Double
                        Saldo = 0
                        Abono = Double.Parse(Me.LbTotalVenta.Text)

                        cmd.Parameters.AddWithValue("@SALDO", Saldo)
                        cmd.Parameters.AddWithValue("@ABONO", Abono)
                End Select
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtVentasCorrelativo.Text))
                cmd.Parameters.AddWithValue("@CODCLIENTE", Integer.Parse(Me.txtVentasCodCliente.Text))
                cmd.Parameters.AddWithValue("@NIT", Me.txtVentasNitClie.Text)
                cmd.Parameters.AddWithValue("@NOMBRE", Me.txtVentasNombre.Text)
                cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.LbTotalCosto.Text))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.LbTotalVenta.Text))
                cmd.Parameters.AddWithValue("@CODEMBARQUE", "GENERAL")
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@NOFAC", Me.txtVentasCorrelativo.Text)
                cmd.Parameters.AddWithValue("@CODVEN", Integer.Parse(Me.cmbVentasVendedor.SelectedValue.ToString))
                cmd.Parameters.AddWithValue("@OBS", "SN")
                cmd.ExecuteNonQuery()

                result = True

                'ELIMINA LOS DATOS DE LA TABLA TEMP_VENTAS
                fcnDeleteTempVentas(GlobalEmpNit, GlobalNomUsuario)

            Catch ex As Exception
                MsgBox(ex.ToString)
                result = False
            End Try

        End Using

        Return result

    End Function

    Private Function fcnDeleteTempVentas(ByVal empnit As String, ByVal usuario As String) As Boolean
        Dim result As Boolean

        Dim sql As String = ""

        'MsgBox(GlobalSelectedTipoDocumento)

        Select Case SelectedForm
            Case "VENTAS"

                sql = "DELETE FROM TEMP_VENTAS FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC
                WHERE (TEMP_VENTAS.EMPNIT = @EMPNIT) AND (TEMP_VENTAS.USUARIO = @USUARIO) AND (TIPODOCUMENTOS.TIPODOC = '" & GlobalSelectedTipoDocumento & "')"

            Case "COTIZACIONES"
                sql = "DELETE FROM TEMP_VENTAS FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC
                WHERE (TEMP_VENTAS.EMPNIT = @EMPNIT) AND (TEMP_VENTAS.USUARIO = @USUARIO) AND (TIPODOCUMENTOS.TIPODOC = 'COT')"
            Case "ENVIOS"
                sql = "DELETE FROM TEMP_VENTAS FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC
                WHERE (TEMP_VENTAS.EMPNIT = @EMPNIT) AND (TEMP_VENTAS.USUARIO = @USUARIO) AND (TIPODOCUMENTOS.TIPODOC = 'ENV')"
        End Select

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cm As New SqlCommand(sql, cn)
                cm.Parameters.AddWithValue("@EMPNIT", empnit)
                cm.Parameters.AddWithValue("@USUARIO", usuario)
                cm.ExecuteNonQuery()
                result = True
            Catch ex As Exception
                result = False
            End Try
        End Using

        Return result

    End Function

    'rutina que verifica si ha tomado los datos de un pedido y cambia a corte=si
    Private Sub PedidoCorteSi(ByVal Coddoc As String, ByVal Correlativo As Double)
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='SI' WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & Coddoc & "' AND CORRELATIVO=" & Correlativo, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                PedidoTomado = False

            Catch ex As Exception

            End Try
        End Using

    End Sub

    Private Sub cmbVentasVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVentasVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtVentasNitClie.select()
            'Me.txtVentasCodProd.select()
        End If
    End Sub

    Private Sub txtVentasNitClie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVentasNitClie.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdVentasBuscarCliente.select()
        End If
    End Sub

    Private Sub txtVentasNitClie_Leave(sender As Object, e As EventArgs) Handles txtVentasNitClie.Leave

        If Me.txtVentasNitClie.Text <> "" Then

            Dim ojFEL As New classFEL
            Me.txtVentasNitClie.Text = ojFEL.cleanNitCliente(Me.txtVentasNitClie.Text)

            Call Mensaje("Buscando datos del cliente")

            'obtiene el valor boolean de la rutina anterior y decide si abre la ventana para crear un nuevo cliente
            If getDatosCliente(Me.txtVentasNitClie.Text) = True Then

                If ClienteNuevoCargado = False Then
                    Dim control As New UserControlClienteNuevo
                    If FlyoutDialog.Show(Me, control) = DialogResult.OK Then
                        Me.txtVentasNitClie.select()
                        Call CargarDGVListaProductos(0)
                    End If

                Else
                    Call CargarDGVListaProductos(0)
                End If
            Else
                Call CargarDGVListaProductos(0)
            End If

        End If
    End Sub

    Private Sub txtVentasNitClie_Enter(sender As Object, e As EventArgs) Handles txtVentasNitClie.Enter
        ClienteNuevoCargado = False 'esto es por si el usuario usa Escape para cancelar el ingreso del cliente nuevo
    End Sub

    Dim ClienteNuevo As Boolean = False

    Public Function getDatosCliente(ByVal NitClie As String) As Boolean
        Dim r As Boolean
        'PRIMERO BUSCA AL CLIENTE EN LA BASE DE DATOS
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Dim cmd As New SqlCommand("SELECT NombreCliente, DirCliente, CodCliente, HABILITADO,CATEGORIA FROM CLIENTES WHERE EMPNIT='" & GlobalEmpNit & "' AND NIT='" & NitClie & "'", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            Try
                'SI EL CLIENTE ESTÁ DESHABILITADO, RESPONDE FALSO
                If dr(3).ToString = "NO" Then
                    Call Aviso("IMPOSIBLE", "Este cliente está deshabilitado, por lo tanto, no puedes cargarle ventas", Me)
                    dr.Close()
                    cmd.Dispose()
                    cn.Close()
                    Return False
                    Exit Function
                End If
                'SI NO, CARGA LOS DATOS DE LECTURA
                Me.txtVentasNombre.Text = dr(0).ToString
                Me.txtVentasCodCliente.Text = dr(2).ToString

                r = False

            Catch ex As Exception
                'SI OCURRIERA ALGÚN ERROR, RETORNA FALSO
                r = True
                Me.txtVentasNombre.Text = ""
                Me.txtVentasCodCliente.Text = ""

            End Try

        End Using

        Return r
    End Function

    Public Sub ObtenerDatosCliente(ByVal NitClie As String)

        'PRIMERO BUSCA AL CLIENTE EN LA BASE DE DATOS
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Dim cmd As New SqlCommand("SELECT NombreCliente, DirCliente, CodCliente, HABILITADO,CATEGORIA FROM CLIENTES WHERE EMPNIT='" & GlobalEmpNit & "' AND NIT='" & NitClie & "'", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            Try
                'SI EL CLIENTE ESTÁ DESHABILITADO, RESPONDE FALSO
                If dr(3).ToString = "NO" Then
                    Call Aviso("IMPOSIBLE", "Este cliente está deshabilitado, por lo tanto, no puedes cargarle ventas", Me)
                    dr.Close()
                    cmd.Dispose()
                    cn.Close()
                    ClienteNuevo = False
                    Exit Sub
                End If
                'SI NO, CARGA LOS DATOS DE LECTURA
                Me.txtVentasNombre.Text = dr(0).ToString
                Me.txtVentasCodCliente.Text = dr(2).ToString

                ClienteNuevo = False

            Catch ex As Exception
                'SI OCURRIERA ALGÚN ERROR, RETORNA FALSO
                ClienteNuevo = True
                Me.txtVentasNombre.Text = ""
                Me.txtVentasCodCliente.Text = ""

            End Try

        End Using

    End Sub

    Private Sub txtVentasNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtVentasNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtVentasCodProd.select()
        End If
    End Sub


#End Region

#Region " ** COTIZACIONES ** "
    Private Sub TileItemCotizaciones_ItemClick(sender As Object, e As TileItemEventArgs)
        Call NAVEGAR("COTIZACIONES")
    End Sub

#End Region

#Region " ** CUENTAS POR COBRAR ** "
    Private Sub TileItemCxC_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Call NAVEGAR("CXC")
    End Sub

#End Region

#Region " ** CORTE DE CAJA ** "
    Private Sub TileItemCorteCaja_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Call NAVEGAR("CORTECAJA")
    End Sub


#End Region

#Region " ** CONFIGURACIONES ** "


    Private Sub switchInterfaz_Toggled(sender As Object, e As EventArgs) Handles switchInterfaz.Toggled
        If Me.switchInterfaz.IsOn = False Then
            SetRegDataClient("interface", "ORGANIZADA")
            varConfigIntefarce = "ORGANIZADA"
        Else
            SetRegDataClient("interface", "CLASICA")
            varConfigIntefarce = "CLASICA"
        End If
    End Sub

    'establece empnit de bodega principal
    Private Sub btnConfigGuardarEmpnitBodega_Click(sender As Object, e As EventArgs) Handles btnConfigGuardarEmpnitBodega.Click
        If Me.txtConfigEmpnitBodegaCentral.Text <> "" Then
            Dim objConfig As New classConfig
            If objConfig.setEmmpnitBodegaCentral(Me.txtConfigEmpnitBodegaCentral.Text) = True Then
                MsgBox("Bodega establecida exitosamente")
            Else
                MsgBox("No se pudo Cambiar el código de Bodega. Error: " + GlobalDesError)
            End If
        End If
    End Sub

    'establece la clave de operaciones
    Private Sub btnConfigGuardarClaveOp_Click(sender As Object, e As EventArgs) Handles btnConfigGuardarClaveOp.Click
        If Me.txtConfigEmpnitBodegaCentral.Text <> "" Then
            Dim objConfig As New classConfig
            If objConfig.setClaveOperador(Me.txtConfigClaveVerificaOperador.Text) = True Then
                MsgBox("Clave cambiada exitosamente")
            Else
                MsgBox("No se pudo Cambiar la clave. Error: " + GlobalDesError)
            End If
        End If
    End Sub

    Private Sub cmdConfigVerPassAutorizaOp_MouseDown(sender As Object, e As MouseEventArgs) Handles cmdConfigVerPassAutorizaOp.MouseDown
        Me.txtConfigClaveVerificaOperador.PasswordChar = ""
    End Sub

    Private Sub cmdConfigVerPassAutorizaOp_MouseUp(sender As Object, e As MouseEventArgs) Handles cmdConfigVerPassAutorizaOp.MouseUp
        Me.txtConfigClaveVerificaOperador.PasswordChar = "*"
    End Sub

    Private Sub btnGenerarPlantillaProductos_Click(sender As Object, e As EventArgs) Handles btnGenerarPlantillaProductos.Click
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Me.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If Confirmacion("¿Está perfectamente seguro que desea establecer su catálogo de productos y precios como el catálogo principal?", Me.ParentForm) = True Then

                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

                Call Mensaje("Eliminando Productos Anteriores")

                If objs.DeleteProductosPreciosInvsaldo = True Then
                    If objs.PostProductosPreciosInvsaldo(GlobalEmpNit) = True Then
                        SplashScreenManager.CloseForm()
                        Call Aviso("Operación exitosa", "Productos y precios establecidos exitosamente", Me.ParentForm)
                    Else
                        SplashScreenManager.CloseForm()
                        MsgBox("No se logró establecer el catálogo de Productos y Precios. Error: " & objs.DesError.ToString)
                    End If
                Else
                    SplashScreenManager.CloseForm()
                    MsgBox("No se pudo eliminar el catálogo actual. Error: " & objs.DesError)
                End If

            End If

        End If
    End Sub

    Private Sub btnConfigExperto_Click(sender As Object, e As EventArgs) Handles btnConfigExperto.Click
        Me.NavigationFrameConfig.SelectedPage = NPConfig_experto

    End Sub

    Private Sub btnConfigExperto_mayoreoa_Click(sender As Object, e As EventArgs) Handles btnConfigExperto_mayoreoa.Click
        If Confirmacion("¿Está seguro que desea llevar a cabo esta actualización de precios?", Me) = True Then


            Dim margen As String
            margen = InputBox("Indique el margen a aumentar según el costo de compra")

            Dim objgeneral As New ClassGeneral
            If objgeneral.fcnEstablecerPrecioMayoreo("A", Double.Parse(margen)) = True Then
                MsgBox("Se han actualizado los precios")
            Else
                MsgBox("Ha ocurrido un error. " & GlobalDesError)
            End If
        End If
    End Sub

    Private Sub btnConfigExperto_mayoreob_Click(sender As Object, e As EventArgs) Handles btnConfigExperto_mayoreob.Click
        If Confirmacion("¿Está seguro que desea llevar a cabo esta actualización de precios?", Me) = True Then

            Dim margen As String
            margen = InputBox("Indique el margen a aumentar según el costo de compra")

            Dim objgeneral As New ClassGeneral
            If objgeneral.fcnEstablecerPrecioMayoreo("B", Double.Parse(margen)) = True Then
                MsgBox("Se han actualizado los precios")
            Else
                MsgBox("Ha ocurrido un error. " & GlobalDesError)
            End If
        End If
    End Sub

    Private Sub btnConfigExperto_mayoreoc_Click(sender As Object, e As EventArgs) Handles btnConfigExperto_mayoreoc.Click
        If Confirmacion("¿Está seguro que desea llevar a cabo esta actualización de precios?", Me) = True Then

            Dim margen As String
            margen = InputBox("Indique el margen a aumentar según el costo de compra")

            Dim objgeneral As New ClassGeneral
            If objgeneral.fcnEstablecerPrecioMayoreo("C", Double.Parse(margen)) = True Then
                MsgBox("Se han actualizado los precios")
            Else
                MsgBox("Ha ocurrido un error. " & GlobalDesError)
            End If
        End If
    End Sub

    Private Sub btnConfigCredenciales_Click(sender As Object, e As EventArgs) Handles btnConfigCredenciales.Click
        Me.NavigationFrameConfig.SelectedPage = NP_CREDENCIALES

        'carga valores de documentos
        Me.cmbConfigClienteCaja.SelectedValue = GlobalSelectedCodCaja

        Me.cmbConfigClienteSerieFac.SelectedValue = GlobalSelectedCoddocFac

    End Sub

    Private Sub cmdConfigLogo_Click(sender As Object, e As EventArgs) Handles cmdConfigLogo.Click
        Me.NavigationFrameConfig.SelectedPage = NPConfig_Logo
    End Sub

    Private Sub cmdConfigGenerales_Click(sender As Object, e As EventArgs) Handles cmdConfigGenerales.Click
        Me.NavigationFrameConfig.SelectedPage = NP_GEN
    End Sub

    Private Sub cmdConfigEmpresas_Click(sender As Object, e As EventArgs) Handles cmdConfigEmpresas.Click
        Me.NavigationFrameConfig.SelectedPage = NPConfig_Empresas
    End Sub

    Private Sub cmdConfigUsuarios_Click(sender As Object, e As EventArgs) Handles cmdConfigUsuarios.Click
        Me.NavigationFrameConfig.SelectedPage = NPConfig_Usuarios
        Call CargarGridUsuarios()

    End Sub

    'habilita el modo pos para facturación
    Private Sub SwitchConfigModoPOS_Toggled(sender As Object, e As EventArgs) Handles SwitchConfigModoPOS.Toggled

        If Me.SwitchConfigModoPOS.IsOn = True Then
            Call CambiarConfigSiNo(9, "SI")
        Else
            Call CambiarConfigSiNo(9, "NO")
        End If

    End Sub

    'clave de vendedor
    Private Sub SwitchConfigClaveVendedor_Toggled(sender As Object, e As EventArgs) Handles SwitchConfigClaveVendedor.Toggled
        If Me.SwitchConfigClaveVendedor.IsOn = True Then

            Call CambiarConfigSiNo(17, "SI")
        Else
            Call CambiarConfigSiNo(17, "NO")
        End If

    End Sub
    'formato corte
    Private Sub SwitchConfigFormatoCorte_Toggled(sender As Object, e As EventArgs) Handles SwitchConfigFormatoCorte.Toggled
        If Me.SwitchConfigFormatoCorte.IsOn = True Then

            Call CambiarConfigSiNo(16, "SI")
        Else

            Call CambiarConfigSiNo(16, "NO")
        End If
    End Sub
    'producto todas las empresas
    Private Sub SwitchConfigInternet_Toggled(sender As Object, e As EventArgs) Handles SwitchConfigInternet.Toggled
        If Me.SwitchConfigInternet.IsOn = True Then

            Call CambiarConfigSiNo(10, "SI")
        Else

            Call CambiarConfigSiNo(10, "NO")
        End If
    End Sub

    Private Sub CambiarConfigSiNo(ByVal IdNotificacion As Integer, SiNo As String)
        If BolConfigGeneralesCargada = True Then
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("UPDATE CONFIG SET SINO='" & SiNo & "' WHERE ID=" & IdNotificacion, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()
        End If
    End Sub

    Private Sub cmdConfigAtras_Click(sender As Object, e As EventArgs) Handles cmdConfigAtras.Click
        Me.NavigationFrameMain.SelectedPage = NP_Inicio
        SelectedForm = "INICIO"
        Me.GridEmpresas.DataSource = Nothing
        Me.GridUsuarios.DataSource = Nothing
    End Sub

    'muestra la clave de verificaciones
    Private Sub cmdConfigVerPassAutoriza_MouseDown(sender As Object, e As MouseEventArgs) Handles cmdConfigVerPassAutoriza.MouseDown
        Me.txtConfigClaveVerificaExistencia.PasswordChar = ""
    End Sub

    Private Sub cmdConfigVerPassAutoriza_MouseUp(sender As Object, e As MouseEventArgs) Handles cmdConfigVerPassAutoriza.MouseUp
        Me.txtConfigClaveVerificaExistencia.PasswordChar = "*"
    End Sub

    'PERMITE O NO INVENTARIO EN NEGATIVO
    Private Sub SwitchConfigVerificaExistencia_Toggled(sender As Object, e As EventArgs) Handles SwitchConfigVerificaExistencia.Toggled
        If SwitchConfigVerificaExistencia.IsOn = True Then
            ConfigVerificaExistencias = False
            Call CambiarConfigSiNo(3, "SI")
        Else
            ConfigVerificaExistencias = True
            Call CambiarConfigSiNo(3, "NO")
        End If
    End Sub

    'cambia los permisos de usuario
    Private Sub CambiarPermisos(ByVal NoPermiso As Integer, ByVal SiNo As Boolean, ByVal Nivel As Integer)
        Call AbrirConexionSql()
        Dim sql As String, SN As String
        If SiNo = True Then
            SN = "SI"
        Else
            SN = "NO"
        End If
        Select Case Nivel
            Case 2
                sql = "UPDATE PERMISOS SET NIVEL2='" & SN & "' WHERE ID=" & NoPermiso
            Case 3
                sql = "UPDATE PERMISOS SET NIVEL3='" & SN & "' WHERE ID=" & NoPermiso
            Case 4
                sql = "UPDATE PERMISOS SET NIVEL4='" & SN & "' WHERE ID=" & NoPermiso
            Case 5
                sql = "UPDATE PERMISOS SET NIVEL5='" & SN & "' WHERE ID=" & NoPermiso
            Case 6
                sql = "UPDATE PERMISOS SET NIVEL6='" & SN & "' WHERE ID=" & NoPermiso
            Case 7
                sql = "UPDATE PERMISOS SET NIVEL7='" & SN & "' WHERE ID=" & NoPermiso
        End Select
        Dim cmd As New SqlCommand(sql, cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()
        'Beep()
    End Sub


    Private Sub btnConfigGuardarPorcentajeTarjeta_Click(sender As Object, e As EventArgs) Handles btnConfigGuardarPorcentajeTarjeta.Click
        If Me.txtConfigPorcentajeTarjeta.Text <> "" Then
            If Confirmacion("¿Está seguro que desea Cambiar el Porcentaje por Cobro Con Tarjeta?", Me) = True Then
                Using cn As New SqlConnection(strSqlConectionString)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlCommand("UPDATE CONFIG SET PASS=@PASS WHERE ID=18", cn)
                    cmd.Parameters.AddWithValue("@PASS", Me.txtConfigPorcentajeTarjeta.Text)
                    Try
                        cmd.ExecuteNonQuery()
                        Call Mensaje("Porcentaje Cambiado exitosamente")
                    Catch ex As Exception
                        MsgBox("No se logró cambiar el Porcentaje")
                    End Try


                    cn.Close()
                End Using
            End If
        End If

    End Sub


    'cambia la configuración del aviso en meses de vencimiento
    Private Sub btnConfigVencimientoMeses_Click(sender As Object, e As EventArgs) Handles btnConfigVencimientoMeses.Click
        If Me.txtConfigVencimientoMeses.Text <> "" Then
            If Confirmacion("¿Está seguro que desea Cambiar los meses para Aviso de Vencimiento?", Me) = True Then
                Using cn As New SqlConnection(strSqlConectionString)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlCommand("UPDATE CONFIG SET PASS=@PASS WHERE ID=19", cn)
                    cmd.Parameters.AddWithValue("@PASS", Me.txtConfigVencimientoMeses.Text)
                    GlobalConfigVencimientoMeses = Integer.Parse(Me.txtConfigVencimientoMeses.Text)
                    Try
                        cmd.ExecuteNonQuery()
                        Call Mensaje("Porcentaje Cambiado exitosamente")
                    Catch ex As Exception
                        MsgBox("No se logró actualizar la configuración")
                    End Try


                    cn.Close()
                End Using
            End If
        End If
    End Sub



    'clave de verificaciones
    Private Sub cmdConfigGuardarClave_Click(sender As Object, e As EventArgs) Handles cmdConfigGuardarClave.Click
        If Me.txtConfigClaveVerificaExistencia.Text <> "" Then
            If Confirmacion("¿Está seguro que desea guardar esta nueva clave de verificación?", Me) = True Then

                Call AbrirConexionSql()

                Dim cmd As New SqlCommand("UPDATE CONFIG SET PASS='" & Me.txtConfigClaveVerificaExistencia.Text & "' WHERE ID=2", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                Call Mensaje("Clave de verificación actualizada exitosamente")

            End If
        End If
    End Sub

    Dim BolConfigGeneralesCargada As Boolean = False

    Private Sub CargarConfigGenerales()
        BolConfigGeneralesCargada = False

        Call AbrirConexionSql()

        Dim cmd As New SqlCommand("SELECT ID, CONFIG, SINO, PASS FROM CONFIG", cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Do While dr.Read
            Select Case dr(0)

                Case 2 'clave para las existencias
                    Me.txtConfigClaveVerificaExistencia.Text = dr(3).ToString
                Case 3 'permite inventario negativo
                    Dim bolVer As Boolean = False
                    If dr(2).ToString = "SI" Then
                        bolVer = True
                        ConfigVerificaExistencias = False
                    Else
                        bolVer = False
                        ConfigVerificaExistencias = True
                    End If
                    Me.SwitchConfigVerificaExistencia.IsOn = bolVer

                Case 9 ' HABILITA DECIMALES EN CANTIDADES
                    Dim bolmodoPOS As Boolean = False
                    If dr(2).ToString = "SI" Then
                        bolmodoPOS = True
                    Else
                        bolmodoPOS = False
                    End If
                    Me.SwitchConfigModoPOS.IsOn = bolmodoPOS

                Case 10 'Producto nuevo se guarda en todas las empresas
                    Dim bolInternet As Boolean = False
                    If dr(2).ToString = "SI" Then
                        bolInternet = True
                    Else
                        bolInternet = False
                    End If
                    Me.SwitchConfigInternet.IsOn = bolInternet

                Case 11 'Imprime ticket al guardar venta
                    Dim bol As Boolean = False
                    If dr(2).ToString = "SI" Then
                        bol = True
                    Else
                        bol = False
                    End If
                    Me.SwitchImprimirTicket.IsOn = bol
                Case 15 'predeterminado contado o crédito
                    Dim bol As Boolean = False
                    If dr(2).ToString = "SI" Then
                        bol = True
                    Else
                        bol = False
                    End If
                    Me.SwitchConfigConCre.IsOn = bol
                Case 16 'formato de corte 

                    'carga el switch
                    Dim bol As Boolean = False
                    If dr(2).ToString = "SI" Then
                        bol = True
                    Else
                        bol = False
                    End If
                    Me.SwitchConfigFormatoCorte.IsOn = bol

                    'carga el combobox
                    Me.cmbConfigFormatoCorteCaja.Text = dr(3).ToString

                Case 17 'clave vendedor 
                    Dim bol As Boolean = False
                    If dr(2).ToString = "SI" Then
                        bol = True
                    Else
                        bol = False
                    End If
                    Me.SwitchConfigClaveVendedor.IsOn = bol

                Case 18 'cobro con tarjeta porcentaje
                    Me.txtConfigPorcentajeTarjeta.Text = Double.Parse(dr(3))

                Case 19 'meses de vencimiento
                    Me.txtConfigVencimientoMeses.Text = dr(3).ToString

                Case 20 'empnit para bodega central
                    Me.cmbConfigVpn.Text = dr(2).ToString
                    Me.txtConfigEmpnitBodegaCentral.Text = dr(3).ToString
                    GlobalBodegaCentralEmpnit = dr(3).ToString


                Case 21
                    Me.txtConfigClaveVerificaOperador.Text = dr(3).ToString

            End Select
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        BolConfigGeneralesCargada = True
    End Sub

    Private Sub SwitchConfigConCre_Toggled(sender As Object, e As EventArgs) Handles SwitchConfigConCre.Toggled
        If SwitchConfigConCre.IsOn = True Then
            Call CambiarConfigSiNo(15, "SI")
        Else
            Call CambiarConfigSiNo(15, "NO")
        End If
    End Sub

    Private Sub cmdConfigCargarLogo_Click(sender As Object, e As EventArgs) Handles cmdConfigCargarLogo.Click
        Dim NuevoLogo As Image
        Try
            Me.imgLogo.LoadImage()
            NuevoLogo = Me.imgLogo.Image

            If cn.State = 0 Then
                cn.Open()
            End If
            Dim cmd As New SqlCommand("UPDATE EMPRESAS SET EMPLOGO=@Logo WHERE EMPNIT='" & GlobalEmpNit & "'", cn)
            'convierte el logo en array
            Dim _memoryStream As New System.IO.MemoryStream()
            NuevoLogo.Save(_memoryStream, System.Drawing.Imaging.ImageFormat.Png)
            cmd.Parameters.Add("@Logo", SqlDbType.Image).Value = _memoryStream.ToArray
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Call Mensaje("El nuevo logo ha sido cargado exitosamente")
            cn.Close()

            'Actualizo los logos 
            LogoEmpresa = NuevoLogo
            'Me.imgLogo2.Image = NuevoLogo
            Me.imgLogoPrinc.Image = NuevoLogo

        Catch ex As Exception
            Call Mensaje("No se pudo guardar este logo")
        End Try

        'guardo el nuevo logo en la carpeta src
        Try
            NuevoLogo = Me.imgLogo.Image
            NuevoLogo.Save(Application.StartupPath + "\Src\Logo.png", Imaging.ImageFormat.Png)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cmbConfigFormatoCorteCaja_Leave(sender As Object, e As EventArgs) Handles cmbConfigFormatoCorteCaja.Leave

        Select Case Me.cmbConfigFormatoCorteCaja.Text
            Case "ORIGINAL"
            Case "URIZAR"
            Case "FARMASALUD"
        End Select


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE CONFIG SET PASS='" & Me.cmbConfigFormatoCorteCaja.Text & "' WHERE ID=16", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            Catch ex As Exception
                MsgBox("No se pudo actualizar esta configuración. Error: " + ex.ToString)
            End Try
        End Using


    End Sub


#End Region

#Region " ** CONFIGURACIONES CLIENTE ** "


    Private Sub fcnCargarConfigCliente()
        Try
            varConfigClientUrl = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "urlfront", Nothing).ToString
            GlobalUrlFrontEnd = varConfigClientUrl

            varConfigClienteModoPos = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "modopos", Nothing).ToString
            varConfigClienteTipoCobro = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "tipocobro", Nothing).ToString
            varConfigClienteHora = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "hora", Nothing).ToString
            varConfigClienteRecordatorios = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "recordatorios", Nothing).ToString
            varConfigIntefarce = "ORGANIZADA" 'My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "interface", Nothing).ToString
            varConfigModoCodigoVentas = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "modocodigoventas", Nothing).ToString

            'CARGA LOS VALORES PUBLICOS POR DEFECTO
            Dim varTipoFormatoCorteCaja = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "ticketcortecaja", Nothing).ToString

            GlobalSelectedCodCaja = CType(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "caja", Nothing), Integer)
            GlobalSelectedCoddocFac = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", "coddocfac", Nothing).ToString


            'carga los valores a los controles
            Me.txtConfigClienteUrl.Text = varConfigClientUrl

            If varConfigClienteModoPos = "SI" Then
                Me.switchConfigClienteModoPOS.IsOn = True
            Else
                Me.switchConfigClienteModoPOS.IsOn = False
            End If

            If varConfigClienteTipoCobro = "SI" Then
                Me.switchConfigClienteTipoCobro.IsOn = True
            Else
                Me.switchConfigClienteTipoCobro.IsOn = False
            End If

            If varConfigClienteHora = "SI" Then
                Me.switchConfigClienteHora.IsOn = True
            Else
                Me.switchConfigClienteHora.IsOn = False
            End If

            If varConfigClienteRecordatorios = "SI" Then
                Me.switchConfigClienteRecordatorios.IsOn = True
            Else
                Me.switchConfigClienteRecordatorios.IsOn = False
            End If

            If varConfigIntefarce = "ORGANIZADA" Then
                Me.switchInterfaz.IsOn = False
            Else 'CLASICA / ORGANIZADA
                Me.switchInterfaz.IsOn = True
            End If


            If varConfigModoCodigoVentas = "NO" Then
                Me.SwitchConfigModoCodigoVentas.IsOn = False
            Else
                Me.SwitchConfigModoCodigoVentas.IsOn = True
            End If


            'inicializa el timer de horas
            If varConfigClienteHora = "SI" Then
                Me.TimerHora.Enabled = True
                Me.TimerHora.Start()
            Else
                Me.TimerHora.Enabled = False
                Me.TimerHora.Stop()
            End If

            'switch Tipo Formato Corte Caja
            If varTipoFormatoCorteCaja = "SI" Then
                Me.switchConfigClienteTipoCorteCaja.IsOn = True
            Else
                Me.switchConfigClienteTipoCorteCaja.IsOn = False
            End If



        Catch ex As Exception
            MsgBox("No se cargaron las configuraciones de cliente. " & ex.ToString)
        End Try

    End Sub

    Private Sub CargarConfigClienteDocumentos()

        Dim objTipoDocx As New ClassTipoDocumentos(GlobalEmpNit)

        With Me.cmbConfigClienteSerieFac
            .DataSource = Nothing
            .DataSource = objTipoDocx.tblCoddoc("FAC")
            .DisplayMember = "CODDOC"
            .ValueMember = "CODDOC"
        End With



        Dim objCa As New classCorteCaja
        With Me.cmbConfigClienteCaja
            .DataSource = Nothing
            .DataSource = objCa.getCajas(3)
            .ValueMember = "CODCAJA"
            .DisplayMember = "DESCAJA"
        End With


    End Sub

    'HABILITA MODO CODIGOS AL VENDER, SOLICITA CANTIDAD Y LUEGO CÓDIGO EN TEXTBOX
    Private Sub SwitchConfigModoCodigoVentas_Toggled(sender As Object, e As EventArgs) Handles SwitchConfigModoCodigoVentas.Toggled

        If Me.SwitchConfigModoCodigoVentas.IsOn = True Then
            SetRegDataClient("modocodigoventas", "SI")
        Else
            SetRegDataClient("modocodigoventas", "NO")
        End If

    End Sub


    'SELECCIONA TIPO DE IMPRESION EN FORMATO CORTE DE CAJA /CARTA.TICKET
    Private Sub switchConfigClienteTipoCorteCaja_Toggled(sender As Object, e As EventArgs) Handles switchConfigClienteTipoCorteCaja.Toggled
        If Me.switchConfigClienteTipoCorteCaja.IsOn = True Then
            SetRegDataClient("ticketcortecaja", "SI")
            'varConfigClienteModoPos = "SI"
        Else
            SetRegDataClient("ticketcortecaja", "NO")
            'varConfigClienteModoPos = "NO"
        End If
    End Sub

    'CARGA DE DOCUMENTOS PREDETERMINADOS EN EL CLIENTE
    Private Sub cmbConfigClienteCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConfigClienteCaja.Leave
        Try
            GlobalSelectedCodCaja = CType(Me.cmbConfigClienteCaja.SelectedValue, Integer)
            SetRegDataClient("caja", GlobalSelectedCodCaja.ToString)

        Catch ex As Exception

        End Try
    End Sub

    'CARGA SERIE FACTURA PREDETERMINADA
    Private Sub cmbConfigClienteSerieFac_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConfigClienteSerieFac.Leave
        Try
            GlobalSelectedCoddocFac = Me.cmbConfigClienteSerieFac.SelectedValue.ToString
            SetRegDataClient("coddocfac", GlobalSelectedCoddocFac)

        Catch ex As Exception

        End Try
    End Sub



    'VALORES EN LOS SWITCH
    Private Sub switchConfigClienteModoPOS_Toggled(sender As Object, e As EventArgs) Handles switchConfigClienteModoPOS.Toggled

        If Me.switchConfigClienteModoPOS.IsOn = True Then
            SetRegDataClient("modopos", "SI")
            varConfigClienteModoPos = "SI"
        Else
            SetRegDataClient("modopos", "NO")
            varConfigClienteModoPos = "NO"
        End If


    End Sub

    Private Sub switchConfigClienteTipoCobro_Toggled(sender As Object, e As EventArgs) Handles switchConfigClienteTipoCobro.Toggled
        If Me.switchConfigClienteTipoCobro.IsOn = True Then
            SetRegDataClient("tipocobro", "SI")
            varConfigClienteTipoCobro = "SI"
        Else
            SetRegDataClient("tipocobro", "NO")
            varConfigClienteTipoCobro = "NO"
        End If

    End Sub

    Private Sub switchConfigClienteHora_Toggled(sender As Object, e As EventArgs) Handles switchConfigClienteHora.Toggled
        If Me.switchConfigClienteHora.IsOn = True Then
            SetRegDataClient("hora", "SI")
            varConfigClienteHora = "SI"
            Me.TimerHora.Start()
        Else
            SetRegDataClient("hora", "NO")
            varConfigClienteHora = "NO"
            Me.TimerHora.Stop()
        End If
    End Sub

    Private Sub switchConfigClienteRecordatorios_Toggled(sender As Object, e As EventArgs) Handles switchConfigClienteRecordatorios.Toggled
        If Me.switchConfigClienteRecordatorios.IsOn = True Then
            SetRegDataClient("recordatorios", "SI")
            varConfigClienteRecordatorios = "SI"
        Else
            SetRegDataClient("recordatorios", "NO")
            varConfigClienteRecordatorios = "NO"
        End If
    End Sub

    Private Sub btnConfigClienteUrlGuardar_Click(sender As Object, e As EventArgs) Handles btnConfigClienteUrlGuardar.Click
        SetRegDataClient("urlfront", Me.txtConfigClienteUrl.Text)
        varConfigClientUrl = Me.txtConfigClienteUrl.Text
        GlobalUrlFrontEnd = varConfigClientUrl
    End Sub

#End Region

#Region " ** INVENTARIOS ** "
    Private Sub cmdInventariosAtras2_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("INICIO")
    End Sub

    Private Sub TileItemInventarios_ItemClick(sender As Object, e As TileItemEventArgs)
        Call NAVEGAR("INVENTARIOS")
    End Sub

#End Region

#Region " ** USUARIOS ** "

    Private Sub txtUsuariosUsuario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuariosUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtUsuariosPass.select()
        End If
    End Sub

    Private Sub txtUsuariosPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuariosPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbUsuariosNivel.select()
        End If
    End Sub

    Private Sub cmdUsuariosVerPass_MouseDown(sender As Object, e As MouseEventArgs) Handles cmdUsuariosVerPass.MouseDown
        Me.txtUsuariosPass.PasswordChar = ""
    End Sub

    Private Sub cmdUsuariosVerPass_MouseUp(sender As Object, e As MouseEventArgs) Handles cmdUsuariosVerPass.MouseUp
        Me.txtUsuariosPass.PasswordChar = "*"
    End Sub

    Private Sub cmbUsuariosNivel_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUsuariosNivel.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtUsuariosEmail.select()
        End If
    End Sub

    Private Sub txtUsuariosEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsuariosEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdUsuariosGuardar.select()
        End If
    End Sub

    Private Sub cmdUsuariosGuardar_Click(sender As Object, e As EventArgs) Handles cmdUsuariosGuardar.Click
        If Me.txtUsuariosUsuario.Text <> "" Then
            If Me.txtUsuariosPass.Text <> "" Then
                If Me.cmbUsuariosNivel.Text <> "" Then
                    If Me.txtUsuariosEmail.Text <> "" Then
                    Else
                        Me.txtUsuariosEmail.Text = GlobalEmail
                    End If

                    If Confirmacion("¿Está seguro que desea Guardar este nuevo Usuario?", Me) = True Then
                        Dim NuevoUsuarioNivel As Integer
                        Select Case Me.cmbUsuariosNivel.Text
                            Case "ADMINISTRADOR"
                                NuevoUsuarioNivel = 1
                            Case "VENTAS"
                                NuevoUsuarioNivel = 2
                            Case "SUPERVISION"
                                NuevoUsuarioNivel = 3
                            Case "JEFE BODEGA"
                                NuevoUsuarioNivel = 4
                            Case "AUXILIAR BODEGA"
                                NuevoUsuarioNivel = 5
                            Case "INVENTARIOS"
                                NuevoUsuarioNivel = 6
                            Case "CONTABILIDAD"
                                NuevoUsuarioNivel = 7
                            Case "COMPRAS"
                                NuevoUsuarioNivel = 8
                            Case "VENCIDOS"
                                NuevoUsuarioNivel = 9
                            Case "DIGITADORES"
                                NuevoUsuarioNivel = 10
                        End Select

                        Call AbrirConexionSql()
                        Dim cmd As New SqlCommand("INSERT INTO USUARIOS (USUARIO,PASS,NIVEL,EMAIL,LOGGED) VALUES (@USUARIO,@PASS,@NIVEL,@EMAIL,0)", cn)
                        cmd.Parameters.AddWithValue("@USUARIO", Me.txtUsuariosUsuario.Text)
                        cmd.Parameters.AddWithValue("@PASS", ps.ConvertirSha1(Me.txtUsuariosPass.Text))
                        cmd.Parameters.AddWithValue("@NIVEL", NuevoUsuarioNivel)
                        cmd.Parameters.AddWithValue("@EMAIL", Me.txtUsuariosEmail.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        cn.Close()

                        Me.txtUsuariosUsuario.Text = ""
                        Me.txtUsuariosPass.Text = ""
                        Me.cmbUsuariosNivel.Text = ""
                        Me.txtUsuariosEmail.Text = ""
                        Me.txtUsuariosUsuario.select()

                        Call CargarGridUsuarios()

                        Call Mensaje("Nuevo Usuario agregado exitosamente")
                    End If
                Else
                    Call Mensaje("Indique el Nivel el Usuario")
                End If
            Else
                Call Mensaje("Escriba la contraseña de usuario")
            End If
        Else
            Call Mensaje("Escriba un nombre de Usuario")
        End If
    End Sub


    Private Sub CargarGridUsuarios()
        Dim tbl As New DataTable()
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("USUARIO", GetType(String))
        tbl.Columns.Add("DESNIVEL", GetType(String))
        tbl.Columns.Add("EMAIL", GetType(String))

        Dim DescNivel As String = ""

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT ID,USUARIO,NIVEL,EMAIL FROM USUARIOS", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        Do While dr.Read
            Select Case dr(2).ToString
                Case "1"
                    DescNivel = "ADMINISTRADOR"
                Case "2"
                    DescNivel = "Nivel 2"
                Case "3"
                    DescNivel = "Nivel 3"
                Case "4"
                    DescNivel = "Nivel 4"
                Case "5"
                    DescNivel = "Nivel 5"
                Case "6"
                    DescNivel = "Nivel 6"
            End Select
            tbl.Rows.Add(New Object() {
                         Integer.Parse(dr(0).ToString),
                         dr(1).ToString,
                         DescNivel,
                         dr(3).ToString
                         })
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        Me.GridUsuarios.DataSource = tbl

        TryCast(TileViewUsuarios.TileTemplate(0), TileViewItemElement).Column = TileViewUsuarios.Columns("USUARIO")
        TryCast(TileViewUsuarios.TileTemplate(1), TileViewItemElement).Column = TileViewUsuarios.Columns("DESNIVEL")
        TryCast(TileViewUsuarios.TileTemplate(2), TileViewItemElement).Column = TileViewUsuarios.Columns("EMAIL")

    End Sub

    Private Sub TileViewUsuarios_DoubleClick(sender As Object, e As EventArgs) Handles TileViewUsuarios.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewUsuarios.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            SelectedCode = Integer.Parse(TileViewUsuarios.GetRowCellValue(hitInfo.RowHandle, "ID").ToString)

            If Confirmacion("¿Está seguro que desea eliminar este Usuario?", Me) = True Then
                Call AbrirConexionSql()
                Dim cmd As New SqlCommand("DELETE FROM USUARIOS WHERE ID=" & SelectedCode, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                Call CargarGridUsuarios()

                Me.txtUsuariosUsuario.select()

            End If

        End If
    End Sub

#End Region

#Region " ** BUSINESS INTELLIGENCE ** "
    Private Sub TileItemReporteReposicion_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Call NAVEGAR("REPORTES")
    End Sub

#End Region

#Region " ** VENDEDORES ** "

    Private Sub CargarComboboxVendedores()


        Dim ObjEmpleados As New ClassEmpleados
        Dim tblVend As New DataTable

        'blVend = ObjEmpleados.tblListaEmpleados(GlobalEmpNit)
        tblVend = ObjEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 3)

        'VENDEDORES EN VENTAS
        With Me.cmbVentasVendedor
            .DataSource = tblVend
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"
        End With

    End Sub

#End Region

#Region " ** PROVEEDORES ** "
    Private Sub TileItemProveedores_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Call NAVEGAR("PROVEEDORES")
    End Sub



    Dim SelectedNomProveedor As String, SelectedNitProveedor As String




    Private Sub cmdRadMenProveedoresCompras_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRadMenProveedoresCompras.ItemClick

        Call AbrirReporte_ComprasProveedor(0, 0, SelectedNitProveedor)
        'Call AbrirReporte_ComprasProveedor(Integer.Parse(Me.cmdAnioProceso.Text), Integer.Parse(Me.cmdMesProceso.SelectedValue), SelectedNitProveedor)
    End Sub



#End Region

#Region " ** CONFIG EMPRESAS ** "

    Private Sub btnConfigNuevaEmpresa_Click(sender As Object, e As EventArgs) Handles btnConfigNuevaEmpresa.Click
        If FlyoutDialog.Show(Me, New viewGestionEmpresas(False, "")) = DialogResult.OK Then
            Call CargarGridEmpresas()
        End If
    End Sub

    Public Sub CargarGridEmpresas()
        Me.GridEmpresas.DataSource = Nothing

        Dim tbl As New DataTable()
        tbl.Columns.Add("EMPNIT", GetType(String))
        tbl.Columns.Add("EMPNOMBRE", GetType(String))
        tbl.Columns.Add("EMPRAZONSOCIAL", GetType(String))
        tbl.Columns.Add("EMPDIRECCION", GetType(String))
        tbl.Columns.Add("EMPTELEFONO", GetType(String))
        tbl.Columns.Add("EMPEMAIL", GetType(String))
        tbl.Columns.Add("EMPLOGO", GetType(Image))

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT EMPNIT,EMPNOMBRE,EMPRAZONSOCIAL,EMPDIRECCION,EMPTELEFONO,
                    CASE 
                        WHEN EMPEMAIL = 'PUBLICO' THEN 'CATALOGO A'
                        WHEN EMPEMAIL = 'MAYOREO A' THEN 'CATALOGO B'
                        WHEN EMPEMAIL = 'MAYOREO B' THEN 'CATALOGO C'
                        WHEN EMPEMAIL = 'MAYOREO C' THEN 'CATALOGO D'
                        ELSE EMPEMAIL END AS EMPEMAIL,
                    EMPLOGO FROM EMPRESAS", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        Do While dr.Read
            tbl.Rows.Add(New Object() {
                         dr(0).ToString,'NIT
                         dr(1).ToString,'NOMBRE
                         dr(2).ToString,'RAZON
                         dr(3).ToString,'DIRECCION
                         dr(4).ToString,'TELEFONO
                         dr(5).ToString,'EMAIL
                         ObtenerImgSql(dr(6))'LOGO
                                                  })
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        Me.GridEmpresas.DataSource = tbl

        TryCast(TileViewEmpresas.TileTemplate(0), TileViewItemElement).Column = TileViewEmpresas.Columns("EMPNIT")
        TryCast(TileViewEmpresas.TileTemplate(1), TileViewItemElement).Column = TileViewEmpresas.Columns("EMPNOMBRE")
        TryCast(TileViewEmpresas.TileTemplate(2), TileViewItemElement).Column = TileViewEmpresas.Columns("EMPRAZONSOCIAL")
        TryCast(TileViewEmpresas.TileTemplate(3), TileViewItemElement).Column = TileViewEmpresas.Columns("EMPDIRECCION")
        TryCast(TileViewEmpresas.TileTemplate(4), TileViewItemElement).Column = TileViewEmpresas.Columns("EMPTELEFONO")
        TryCast(TileViewEmpresas.TileTemplate(5), TileViewItemElement).Column = TileViewEmpresas.Columns("EMPEMAIL")
        TryCast(TileViewEmpresas.TileTemplate(9), TileViewItemElement).Column = TileViewEmpresas.Columns("EMPLOGO")
    End Sub


    Dim selectedConfigEmpnit As String, selectedConfigNomEmpresa As String
    Private Sub TileViewEmpresas_DoubleClick(sender As Object, e As EventArgs) Handles TileViewEmpresas.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewEmpresas.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            selectedConfigEmpnit = TileViewEmpresas.GetRowCellValue(hitInfo.RowHandle, "EMPNIT").ToString
            selectedConfigNomEmpresa = TileViewEmpresas.GetRowCellValue(hitInfo.RowHandle, "EMPNOMBRE").ToString
            Me.RadMenEmpresas.ShowPopup(MousePosition)
        End If

    End Sub

    '**** Radial Menu 
    Private Sub cmdRadMenEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRadMenEditar.ItemClick
        If FlyoutDialog.Show(Me, New viewGestionEmpresas(True, selectedConfigEmpnit)) = DialogResult.OK Then
            Call CargarGridEmpresas()
        End If

    End Sub

    Private Sub cmdRadMenEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRadMenEliminar.ItemClick
        If Confirmacion("¿Está seguro que desea eliminar esta Empresa?, podría encontrar fallos después", Me) = True Then
            If FlyoutDialog.Show(Me, New ViewClave(Me.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objEmp As New ClassEmpresas
                If objEmp.eliminarEmpresa(selectedConfigEmpnit) = True Then
                    Call CargarGridEmpresas()
                    MsgBox("Empresa Eliminada Exitosamente")
                Else
                    MsgBox("No se pudo eliminar la empresa. Error: " & GlobalDesError)
                End If

                SplashScreenManager.CloseForm()

            End If

        End If

    End Sub

#End Region

#Region " ** CLIENTES ** "
    Private Sub TileItemClientes_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Call NAVEGAR("CLIENTES")

    End Sub

    Public SelectedNomCliente As String, SelectedNitCliente As String

    Private Function ExisteNitCliente(ByVal NitClie As String) As Boolean
        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT NIT, NOMBRECLIENTE FROM CLIENTES WHERE EMPNIT='" & GlobalEmpNit & "' AND NIT='" & NitClie & "'", cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()
    End Function


#End Region

#Region " ** MANTENIMIENTOS: MARCAS,MEDIDAS,CATEGORIAS ** "

    Private Sub TileItemMantenimientos_ItemClick(sender As Object, e As TileItemEventArgs)
        Call NAVEGAR("MANTENIMIENTOS")
    End Sub

    Private Sub imgLogoPrinc_DoubleClick(sender As Object, e As EventArgs) Handles imgLogoPrinc.DoubleClick

        Dim int As Integer = 0

        If FlyoutDialog.Show(Me.ParentForm, New ViewClave("razors1805")) = DialogResult.OK Then
            int = 1
        Else
            int = 0
        End If

        If int = 1 Then
            FlyoutDialog.Show(Me, New viewProgramador)
        End If

    End Sub

    Private Sub imgLogoGARMEN_DoubleClick(sender As Object, e As EventArgs)

        Dim int As Integer = 0

        If FlyoutDialog.Show(Me.ParentForm, New ViewClave("razors1805")) = DialogResult.OK Then
            int = 1
        Else
            int = 0
        End If

        If int = 1 Then
            FlyoutDialog.Show(Me, New viewProgramador)
        End If

    End Sub

#End Region

#Region " ** LISTAS DE PRECIOS ** "
    Private Sub TileItemListasPrecios_ItemClick(sender As Object, e As TileItemEventArgs)
        Call NAVEGAR("LISTAPRECIOS")
    End Sub

    Private Sub LabelControl85_Click(sender As Object, e As EventArgs)
        Process.Start("https://onne.herokuapp.com/")
    End Sub


#End Region

#Region " ** ORDEN DE TRABAJO ** "

    Private Sub TileItemOrdenTrabajo_ItemClick(sender As Object, e As TileItemEventArgs)
        Call NAVEGAR("ORDENTRABAJO")
    End Sub

    Private Sub cmbConfigVpn_Leave(sender As Object, e As EventArgs) Handles cmbConfigVpn.Leave
        If Me.cmbConfigVpn.Text <> "" Then
        Else
            Me.cmbConfigVpn.Text = "NO"
        End If



        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE CONFIG SET SINO='" & Me.cmbConfigVpn.Text & "' WHERE ID=20", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            Catch ex As Exception
                MsgBox("No se pudo actualizar esta configuración. Error: " + ex.ToString)
            End Try
        End Using

    End Sub


    Private Sub btnReimpresion_Click(sender As Object, e As EventArgs) Handles btnReimpresion.Click

        If FlyoutDialog.Show(Me.ParentForm, New viewReimpresion) = DialogResult.OK Then


        End If

    End Sub

    Private Sub btnLiberarUsuarios_Click(sender As Object, e As EventArgs) Handles btnLiberarUsuarios.Click
        If Confirmacion("¿ESTÁ SEGURO QUE DESEA LIBERAR TODOS LOS USUARIOS? DEBERÁ CERRAR EL SISTEMA EN TODAS LAS COMPUTADORAS", Me) = True Then
            Dim obc As New classConfig
            If obc.LiberarUsuarios = True Then
                MsgBox("Usuarios liberados exitosamente")
            Else
                MsgBox("No se pudo liberar a los usuarios. Error: " + GlobalDesError)
            End If
        End If
    End Sub


#End Region

#Region " ** ETIQUETAS ** "
    Private Sub TileItemEtiquetas_ItemClick(sender As Object, e As TileItemEventArgs)
        Call NAVEGAR("ETIQUETAS")
    End Sub
#End Region

    Public CtrlGeneral As New Control

    Private Sub btnGeneralAtras_Click(sender As Object, e As EventArgs) Handles btnGeneralAtras.Click
        Try
            Me.NP_GENERAL.Controls.Remove(CtrlGeneral)
            CtrlGeneral = Nothing
            SelectedForm = "INICIO"
            Me.NavigationFrameMain.SelectedPage = NP_Inicio
        Catch ex As Exception

        End Try
    End Sub

    Public Function fcn_ControladoresTemporales(ByVal form As String) As Boolean
        Dim objTipoDocumentos As New ClassTipoDocumentos(GlobalEmpNit)
        Dim result As Boolean

        Select Case form
            Case "VENTAS"
                With Me.cmbVentasCoddoc
                    .DataSource = objTipoDocumentos.tblCoddoc("FAC")
                    .DisplayMember = "CODDOC"
                    .ValueMember = "CODDOC"
                End With
                Try
                    Me.cmbVentasCoddoc.SelectedValue = GlobalCoddoc
                    GlobalSelectedTipoDocumento = objTipoDocumentos.getTipoDocumento(Me.cmbVentasCoddoc.Text.ToString)
                Catch ex As Exception
                    GlobalSelectedTipoDocumento = "SN"
                End Try


                result = True

            Case "ENVIOS"
                With Me.cmbVentasCoddoc
                    .DataSource = objTipoDocumentos.tblCoddoc("ENV")
                    .DisplayMember = "CODDOC"
                    .ValueMember = "CODDOC"
                End With
                Try
                    Me.cmbVentasCoddoc.SelectedValue = GlobalCoddocENVIOS
                Catch ex As Exception

                End Try


                result = True

            Case "ORDENCOMPRA"
                GlobalCoddocORDENCOMPRA = "ORDCOM"

            Case "COTIZACIONES"
                With Me.cmbVentasCoddoc
                    .DataSource = objTipoDocumentos.tblCoddoc("COT")
                    .DisplayMember = "CODDOC"
                    .ValueMember = "CODDOC"
                End With
                Try
                    Me.cmbVentasCoddoc.SelectedValue = GlobalCoddocCOTIZ
                Catch ex As Exception

                End Try

                result = True
        End Select




        Return result

    End Function

End Class
