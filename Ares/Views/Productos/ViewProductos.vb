Imports System.Data.SqlClient
Imports System.Threading
Imports System.Threading.Tasks
Imports DevExpress
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen

Public Class ViewProductos

    Dim objProductos As New ClassProductos

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub ViewProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TimerLoader.Start()

        If GlobalTipoSucursal = 1 Then
            Me.SimpleButton1.Visible = True
        Else
            Me.SimpleButton1.Visible = False
        End If

        Me.btnConfigEditProductosSync.Visible = False

    End Sub

    Private Sub CargarTablaColores()
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODIGO", GetType(Integer))
            .Add("DESCRIPCION", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {0, "NINGUNO"})
            .Add(New Object() {1, "ALTA ROTACION"})
            .Add(New Object() {2, "MEDIANA ROTACION"})
            .Add(New Object() {3, "POCA ROTACION"})
            .Add(New Object() {4, "NULA ROTACION"})
        End With


        With Me.cmbColor
            .DataSource = tbl
            .ValueMember = "CODIGO"
            .DisplayMember = "DESCRIPCION"
        End With
    End Sub

    Private Sub TimerLoader_Tick(sender As Object, e As EventArgs) Handles TimerLoader.Tick
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Me.txtProductosUxc.Text = 1
            Me.cmbProductosFiltroHabilitado.SelectedIndex = 0
            'Call CargarLabels(GlobalTipoEmpresa)

        Catch ex As Exception

        End Try

        SplashScreenManager.CloseForm()


        Try

            Me.cmbProductoClaseUno.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbProductoClaseUno.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.cmbProductoClaseDos.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbProductoClaseDos.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.cmbProductoClaseTres.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbProductoClaseTres.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.cmbProductoMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbProductoMarca.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.cmbTipoProd.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbTipoProd.AutoCompleteSource = AutoCompleteSource.ListItems

        Catch ex As Exception

        End Try

        'carga el combo de tipo productos


        Try
            'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
            Call getComboTipoProductos()
            Call CargarTablaColores()

            Call cargarGridProductos()
        Catch ex As Exception
            MsgBox("Error en las cargas. " + ex.ToString)
        End Try

        TimerLoader.Stop()
        TimerLoader.Enabled = False

    End Sub

    Private Sub getComboTipoProductos()
        Try
            Dim objProd As New ClassProductos

            With Me.cmbTipoProd
                .DataSource = objProd.tblTipoProd("")
                .ValueMember = "TIPO"
                .DisplayMember = "DESC"
            End With

            Me.cmbTipoProd.SelectedIndex = 0

        Catch ex As Exception

        End Try

    End Sub


#Region " ** PRODUCTOS ** "

    'NEW PRODUCTS
    Private Sub cmbtNewProductosNuevo_Click(sender As Object, e As EventArgs) Handles cmdNewProductosNuevo.Click
        'hace invisible el botón atrás de la pantalla principal
        Form1.btnGeneralAtras.Visible = False

        Call CargarCombProductosLocal()

        Me.NavigationFrame.SelectedPage = NP_Detalle

        SelectedForm = "PRODUCTOS"

        Call HabilitarCamposProducto(True)
        Call LimpiarCamposProducto()

        EditarProducto = False

        'oculta los controles de la Serie
        Me.lbProductoSerie.Visible = False

        Me.SwitchSeries.Visible = False
        Me.btnSeries.Visible = False
        Me.SwitchExento.IsOn = False


        Me.txtProductosUxc.Text = 1
        Me.txtProductoInvMinimo.Text = 1
        Me.txtProductoFechaVence.DateTime = Date.Parse("01/01/2000")
        Me.TextBON.Text = 0

        Call BorrarTempPrecios()

        Call CargarReceta()

        Me.cmdProductoCancelarEdicion.Visible = True
        Me.txtProductoCodigo.select()

    End Sub

    Public Sub HabilitarCamposProducto(ByVal SiNo As Boolean)
        Me.txtProductoCodigo.Enabled = SiNo
        Me.txtProductoCodigo2.Enabled = SiNo
        Me.txtProductoDescripcion.Enabled = SiNo
        Me.txtProductoDescripcion2.Enabled = SiNo
        Me.txtProductoDescripcion3.Enabled = SiNo


        Me.cmbProductoMarca.Enabled = SiNo
        Me.cmbProductoClaseUno.Enabled = SiNo
        Me.cmbProductoClaseDos.Enabled = SiNo
        Me.cmbProductoClaseTres.Enabled = SiNo

        Me.cmdProductoAgregarPrecio.Enabled = SiNo

        Me.cmdProductoGuardar.Visible = SiNo


        Me.cmdProductoTomarFoto.Enabled = SiNo
        Me.cmdProductoBuscarFoto.Enabled = SiNo
        Me.cmdProductosQuitarFoto.Enabled = SiNo

        Me.txtProductoCostoUnitario.Enabled = SiNo
        Me.txtProductoFechaVence.Enabled = SiNo

        Me.SwitchSeries.Enabled = SiNo
        Me.SwitchExento.Enabled = SiNo
        Me.cmbColor.Enabled = SiNo
        Me.cmbTipoProd.Enabled = SiNo

        Me.txtProductoInvMinimo.Enabled = SiNo

        Me.cmdProductoAgregarPrecio.Enabled = SiNo

    End Sub

    Private Sub LimpiarCamposProducto()
        Me.txtProductoCodigo.Text = ""
        Me.txtProductoCodigo2.Text = ""
        Me.txtProductoDescripcion.Text = ""
        Me.txtProductoDescripcion2.Text = ""
        Me.txtProductoDescripcion3.Text = ""

        Me.cmbProductoMarca.Text = ""
        Me.cmbProductoClaseUno.Text = ""
        Me.cmbProductoClaseDos.Text = ""
        Me.cmbProductoClaseTres.Text = ""
        Me.txtProductoInvMinimo.Text = 1
        Me.txtProductoCostoUnitario.Text = "0.01"

        Me.imgProductosFotoProducto.Image = My.Resources.attach_2_icon
        Me.txtProductosRutaFoto.Text = ""

        Me.txtProductoFechaVence.DateTime = Date.Parse("01/01/2000")
        Me.TextBON.Text = "0"

    End Sub


    Private Sub cmdProductoGuardar_Click(sender As Object, e As EventArgs) Handles cmdProductoGuardar.Click
        If Me.txtProductoCodigo.Text <> "" Then

            If VerificarCodProd(Me.txtProductoCodigo.Text) = False Then


                If VerificarCodProd(Me.txtProductoCodigo2.Text) = True Then
                    MsgBox("Lo siento, este código alterno ya existe, por favor, escriba otro")
                    Me.txtProductoCodigo2.Text = Me.txtProductoCodigo.Text

                End If



                If Me.txtProductoCodigo2.Text <> "" Then
                Else
                    Me.txtProductoCodigo2.Text = Me.txtProductoCodigo.Text
                End If
                If Me.txtProductosUxc.Text <> "" Then

                Else
                    Me.txtProductosUxc.Text = "1"
                End If
                If Me.TextBON.Text <> "" Then
                Else
                    Me.TextBON.Text = "0"
                End If
                If Me.txtProductoDescripcion.Text <> "" Then
                    If Me.txtProductoDescripcion2.Text <> "" Then
                    Else
                        Me.txtProductoDescripcion2.Text = Me.txtProductoDescripcion.Text
                    End If
                    If Me.txtProductoDescripcion3.Text <> "" Then
                    Else
                        Me.txtProductoDescripcion3.Text = Me.txtProductoDescripcion.Text
                    End If

                    'Selecciona el valor del NF para el color
                    If Me.cmbColor.SelectedIndex >= 0 Then
                    Else
                        Me.cmbColor.SelectedIndex = 0
                    End If
                    'asigna el valor del color NF
                    isNF = CType(Me.cmbColor.SelectedValue, Integer)


                    If Me.cmbProductoMarca.SelectedIndex >= 0 Then
                        If Me.cmbProductoClaseUno.SelectedIndex >= 0 Then


                            If Me.cmbProductoClaseDos.SelectedIndex >= 0 Then

                                If Me.cmbProductoClaseTres.SelectedIndex >= 0 Then
                                Else
                                    Me.cmbProductoClaseTres.SelectedIndex = 0
                                End If
                                If Me.txtProductoCostoUnitario.Text <> "" Then
                                Else
                                    Me.txtProductoCostoUnitario.Text = "0.01"
                                End If

                                If Me.txtProductoInvMinimo.Text <> "" Then
                                Else
                                    Me.txtProductoInvMinimo.Text = 1
                                End If

                                '--------------------------------
                                'Alerta de tipo de productos
                                '--------------------------------
                                If Me.cmbTipoProd.SelectedValue.ToString = "S" Then MsgBox("Este tipo de producto no registrará existencias, si lo cambia más adelante, se generará la existencia de todos los movimientos desde su creación")
                                '--------------------------------


                                'ahora intento guardar el registro
                                If Confirmacion("¿Está seguro que desea guardar este producto?", Me.ParentForm) = True Then
                                    '  Try

                                    Dim sql As String

                                    If Me.txtProductosRutaFoto.Text <> "" Then
                                        If EditarProducto = True Then
                                            'Call Form1.EnviarNotificacionesEmail(3, "Ares te Informa: Actualización de Datos de Producto", "Se actualizó los datos del producto código " & Me.txtProductoCodigo.Text & " " & Me.txtProductoDescripcion.Text)
                                            sql = "UPDATE PRODUCTOS SET CODPROD2=@CODPROD2,DESPROD=@DESPROD,DESPROD2=@DESPROD2,DESPROD3=@DESPROD3, UXC=@UXC, COSTO=@COSTO,CODMARCA=@CODMARCA,CODCLAUNO=@CODCLAUNO,CODCLADOS=@CODCLADOS,CODCLATRES=@CODCLATRES,VENCIMIENTO=@VENCIMIENTO, BONO=@BONO, INVMINIMO=@INVMINIMO,EXENTO=@EXENTO,NF=@NF,TIPOPROD=@TIPOPROD WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD;
                                                UPDATE PRODUCTOS_FOTOS SET FOTO=@FOTO WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD "
                                        Else
                                            'Call Form1.EnviarNotificacionesEmail(3, "Ares te Informa: Creación de Nuevo Producto", "Se actualizó los datos del producto código " & Me.txtProductoCodigo.Text & " " & Me.txtProductoDescripcion.Text)
                                            sql = "INSERT INTO PRODUCTOS (EMPNIT,CODPROD,CODPROD2,DESPROD,DESPROD2,DESPROD3,UXC,CODMEDIDACOMPRA,COSTO,CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,HABILITADO,VENCIMIENTO,BONO,INVMINIMO,EXENTO,NF,TIPOPROD) VALUES (@EMPNIT,@CODPROD,@CODPROD2,@DESPROD,@DESPROD2,@DESPROD3,@UXC,@CODMEDIDACOMPRA,@COSTO,@CODMARCA,@CODCLAUNO,@CODCLADOS,@CODCLATRES,'SI',@VENCIMIENTO,@BONO,@INVMINIMO,@EXENTO,@NF,@TIPOPROD);
                                                INSERT INTO PRODUCTOS_FOTOS (EMPNIT,CODPROD,FOTO) VALUES (@EMPNIT,@CODPROD, @FOTO);
                                                "
                                        End If

                                    Else

                                        If EditarProducto = True Then
                                            'Call Form1.EnviarNotificacionesEmail(3, "Ares te Informa: Actualización de Datos de Producto", "Se actualizó los datos del producto código " & Me.txtProductoCodigo.Text & " " & Me.txtProductoDescripcion.Text & " mediante el usuario " & GlobalNomUsuario)
                                            sql = "UPDATE PRODUCTOS SET CODPROD2=@CODPROD2,DESPROD=@DESPROD,DESPROD2=@DESPROD2,DESPROD3=@DESPROD3,UXC=@UXC,COSTO=@COSTO,CODMARCA=@CODMARCA,CODCLAUNO=@CODCLAUNO,CODCLADOS=@CODCLADOS,CODCLATRES=@CODCLATRES,VENCIMIENTO=@VENCIMIENTO,BONO=@BONO,INVMINIMO=@INVMINIMO,EXENTO=@EXENTO,NF=@NF,TIPOPROD=@TIPOPROD WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD"
                                        Else
                                            'Call Form1.EnviarNotificacionesEmail(3, "Ares te Informa: Creación de Nuevo Producto", "Se creó un nuevo producto con código " & Me.txtProductoCodigo.Text & " " & Me.txtProductoDescripcion.Text & " mediante el usuario " & GlobalNomUsuario)
                                            sql = "INSERT INTO PRODUCTOS (EMPNIT,CODPROD,CODPROD2,DESPROD,DESPROD2,DESPROD3,UXC,CODMEDIDACOMPRA,COSTO,CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,HABILITADO,VENCIMIENTO,BONO,INVMINIMO,EXENTO,NF,TIPOPROD) VALUES (@EMPNIT,@CODPROD,@CODPROD2,@DESPROD,@DESPROD2,@DESPROD3,@UXC,@CODMEDIDACOMPRA,@COSTO,@CODMARCA,@CODCLAUNO,@CODCLADOS,@CODCLATRES,'SI',@VENCIMIENTO,@BONO,@INVMINIMO,@EXENTO,@NF,@TIPOPROD)"
                                        End If
                                    End If

                                    Using cn As New SqlConnection(strSqlConectionString)
                                        If cn.State <> ConnectionState.Open Then
                                            cn.Open()
                                        End If

                                        'busco todas las empresas y los guardo ahi
                                        If Form1.SwitchConfigInternet.IsOn = True Then
                                            Dim cmdEmpresas As New SqlCommand("SELECT EMPNIT FROM EMPRESAS", cn)
                                            Dim drEmpresas As SqlDataReader = cmdEmpresas.ExecuteReader
                                            Do While drEmpresas.Read
                                                'INSERTO/ACTUALIZO DATOS EN LA TABLA PRODUCTOS
                                                Dim cmd As New SqlCommand(sql, cn)
                                                cmd.Parameters.AddWithValue("@EMPNIT", drEmpresas(0).ToString)
                                                cmd.Parameters.AddWithValue("@CODPROD", Me.txtProductoCodigo.Text)
                                                cmd.Parameters.AddWithValue("@CODPROD2", Me.txtProductoCodigo2.Text)
                                                cmd.Parameters.AddWithValue("@DESPROD", Me.txtProductoDescripcion.Text)
                                                cmd.Parameters.AddWithValue("@DESPROD2", Me.txtProductoDescripcion2.Text)
                                                cmd.Parameters.AddWithValue("@DESPROD3", Me.txtProductoDescripcion3.Text)
                                                cmd.Parameters.AddWithValue("@UXC", CType(Me.txtProductosUxc.Text, Integer))
                                                cmd.Parameters.AddWithValue("@CODMEDIDACOMPRA", "UNIDAD")
                                                cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtProductoCostoUnitario.Text))
                                                cmd.Parameters.AddWithValue("@CODMARCA", Me.cmbProductoMarca.SelectedValue)
                                                cmd.Parameters.AddWithValue("@CODCLAUNO", Me.cmbProductoClaseUno.SelectedValue)
                                                cmd.Parameters.AddWithValue("@CODCLADOS", Me.cmbProductoClaseDos.SelectedValue)
                                                cmd.Parameters.AddWithValue("@CODCLATRES", Me.cmbProductoClaseTres.SelectedValue)
                                                cmd.Parameters.AddWithValue("@VENCIMIENTO", Me.txtProductoFechaVence.DateTime)
                                                cmd.Parameters.AddWithValue("@BONO", Me.TextBON.SelectedText)
                                                cmd.Parameters.AddWithValue("@INVMINIMO", Integer.Parse(Me.txtProductoInvMinimo.Text))
                                                cmd.Parameters.AddWithValue("@EXENTO", isExento)
                                                cmd.Parameters.AddWithValue("@NF", isNF)
                                                cmd.Parameters.AddWithValue("@TIPOPROD", Me.cmbTipoProd.SelectedValue.ToString)


                                                If Me.txtProductosRutaFoto.Text <> "" Then
                                                    Try
                                                        Dim _memoryStream As New System.IO.MemoryStream()
                                                        Dim img As Image = Me.imgProductosFotoProducto.Image.Clone
                                                        img.Save(_memoryStream, System.Drawing.Imaging.ImageFormat.Png)
                                                        cmd.Parameters.Add("@FOTO", SqlDbType.Image).Value = _memoryStream.ToArray
                                                    Catch ex As Exception
                                                    End Try
                                                End If
                                                cmd.ExecuteNonQuery()
                                                cmd.Dispose()

                                                '**********************************************************************************
                                                'INSERTO LOS DATOS EN INVENTARIO EN CASO QUE NO SE ESTÉ EDITANDO
                                                If EditarProducto = False Then
                                                    Dim cmd1 As New SqlCommand("INSERT INTO INVSALDO(EMPNIT,ANIO,MES,CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO) VALUES (@EMPNIT,@ANIO,@MES,@CODPROD,@SALDOINICIAL,@ENTRADAS,@SALIDAS,@SALDO)", cn)
                                                    cmd1.Parameters.AddWithValue("@EMPNIT", drEmpresas(0).ToString)
                                                    cmd1.Parameters.AddWithValue("@ANIO", GlobalAnioProceso)
                                                    cmd1.Parameters.AddWithValue("@MES", GlobalMesProceso)
                                                    cmd1.Parameters.AddWithValue("@CODPROD", Me.txtProductoCodigo.Text)
                                                    cmd1.Parameters.AddWithValue("@SALDOINICIAL", 0)
                                                    cmd1.Parameters.AddWithValue("@ENTRADAS", 0)
                                                    cmd1.Parameters.AddWithValue("@SALIDAS", 0)
                                                    cmd1.Parameters.AddWithValue("@SALDO", 0)
                                                    cmd1.ExecuteNonQuery()
                                                    cmd1.Dispose()

                                                    'INSERTO LOS DATOS EN PRECIOS, YA QUE ES PRIMERA VEZ QUE SE INSERTAN
                                                    Dim cmd2 As New SqlCommand("INSERT INTO PRECIOS(EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,
                                                                            HABILITADO,MAYOREOA,MAYOREOB,MAYOREOC,PESO,BONO) SELECT '" & drEmpresas(0).ToString & "' as Empresa,'" & Me.txtProductoCodigo.Text & "' AS CODIGO, CODMEDIDA, EQUIVALE, COSTO, PRECIO, UTILIDAD, MARGEN, 'SI',MAYOREOA,MAYOREOB,MAYOREOC,PESO,ISNULL(BONO,0) AS BONO FROM TEMP_PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND USUARIO='" & GlobalNomUsuario & "'", cn)
                                                    cmd2.ExecuteNonQuery()
                                                    cmd2.Dispose()
                                                End If
                                            Loop
                                            drEmpresas.Close()
                                            cmdEmpresas.Dispose()

                                        Else
                                            'INSERTO/ACTUALIZO DATOS EN LA TABLA PRODUCTOS
                                            Dim cmd As New SqlCommand(sql, cn)
                                            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                                            cmd.Parameters.AddWithValue("@CODPROD", Me.txtProductoCodigo.Text)
                                            cmd.Parameters.AddWithValue("@CODPROD2", Me.txtProductoCodigo2.Text)
                                            cmd.Parameters.AddWithValue("@DESPROD", Me.txtProductoDescripcion.Text)
                                            cmd.Parameters.AddWithValue("@DESPROD2", Me.txtProductoDescripcion2.Text)
                                            cmd.Parameters.AddWithValue("@DESPROD3", Me.txtProductoDescripcion3.Text)
                                            cmd.Parameters.AddWithValue("@UXC", CType(Me.txtProductosUxc.Text, Integer))
                                            cmd.Parameters.AddWithValue("@CODMEDIDACOMPRA", "UNIDAD")
                                            cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtProductoCostoUnitario.Text))
                                            cmd.Parameters.AddWithValue("@CODMARCA", Me.cmbProductoMarca.SelectedValue)
                                            cmd.Parameters.AddWithValue("@CODCLAUNO", Me.cmbProductoClaseUno.SelectedValue)
                                            cmd.Parameters.AddWithValue("@CODCLADOS", Me.cmbProductoClaseDos.SelectedValue)
                                            cmd.Parameters.AddWithValue("@CODCLATRES", Me.cmbProductoClaseTres.SelectedValue)
                                            cmd.Parameters.AddWithValue("@VENCIMIENTO", Me.txtProductoFechaVence.DateTime)
                                            cmd.Parameters.AddWithValue("@BONO", Me.TextBON.Text)
                                            cmd.Parameters.AddWithValue("@INVMINIMO", Integer.Parse(Me.txtProductoInvMinimo.Text))
                                            cmd.Parameters.AddWithValue("@EXENTO", isExento)
                                            cmd.Parameters.AddWithValue("@NF", isNF)
                                            cmd.Parameters.AddWithValue("@TIPOPROD", Me.cmbTipoProd.SelectedValue.ToString)


                                            If Me.txtProductosRutaFoto.Text <> "" Then
                                                Try
                                                    Dim _memoryStream As New System.IO.MemoryStream()
                                                    Dim img As Image = Me.imgProductosFotoProducto.Image.Clone
                                                    img.Save(_memoryStream, System.Drawing.Imaging.ImageFormat.Png)
                                                    cmd.Parameters.Add("@FOTO", SqlDbType.Image).Value = _memoryStream.ToArray
                                                Catch ex As Exception
                                                End Try
                                            End If
                                            cmd.ExecuteNonQuery()
                                            cmd.Dispose()

                                            '**********************************************************************************
                                            'INSERTO LOS DATOS EN INVENTARIO EN CASO QUE NO SE ESTÉ EDITANDO
                                            If EditarProducto = False Then
                                                Dim cmd1 As New SqlCommand("INSERT INTO INVSALDO(EMPNIT,ANIO,MES,CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO) VALUES (@EMPNIT,@ANIO,@MES,@CODPROD,@SALDOINICIAL,@ENTRADAS,@SALIDAS,@SALDO)", cn)
                                                cmd1.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                                                cmd1.Parameters.AddWithValue("@ANIO", GlobalAnioProceso)
                                                cmd1.Parameters.AddWithValue("@MES", GlobalMesProceso)
                                                cmd1.Parameters.AddWithValue("@CODPROD", Me.txtProductoCodigo.Text)
                                                cmd1.Parameters.AddWithValue("@SALDOINICIAL", 0)
                                                cmd1.Parameters.AddWithValue("@ENTRADAS", 0)
                                                cmd1.Parameters.AddWithValue("@SALIDAS", 0)
                                                cmd1.Parameters.AddWithValue("@SALDO", 0)
                                                cmd1.ExecuteNonQuery()
                                                cmd1.Dispose()

                                                'INSERTO LOS DATOS EN PRECIOS, YA QUE ES PRIMERA VEZ QUE SE INSERTAN
                                                Dim cmd2 As New SqlCommand("INSERT INTO PRECIOS(EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO,MAYOREOA,MAYOREOB,MAYOREOC,PESO,BONO) SELECT EMPNIT,'" & Me.txtProductoCodigo.Text & "' AS CODIGO, CODMEDIDA, EQUIVALE, COSTO, PRECIO, UTILIDAD, MARGEN, 'SI', MAYOREOA, MAYOREOB, MAYOREOC,PESO,ISNULL(BONO,0) AS BONO FROM TEMP_PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND USUARIO='" & GlobalNomUsuario & "'", cn)
                                                cmd2.ExecuteNonQuery()
                                                cmd2.Dispose()
                                            End If
                                        End If

                                    End Using


                                    '**********************************************************************************

                                    Call HabilitarCamposProducto(False)

                                    Call LimpiarCamposProducto()

                                    If Form1.SwitchConfigInternet.IsOn = True Then
                                        Call Form1.Mensaje("Producto guardado exitosamente en todas las empresas")
                                    Else
                                        Call Form1.Mensaje("Producto guardado exitosamente")
                                    End If




                                    Call BorrarTempPrecios()

                                    Me.cmdProductoCancelarEdicion.Visible = False
                                    EditarProducto = False


                                    Me.NavigationFrame.SelectedPage = NP_Listado
                                    Form1.btnGeneralAtras.Visible = True

                                    Call cargarGridProductos()
                                    'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())

                                End If

                            Else
                                Call Aviso("Importante", "Seleccione una Clasificación Dos de la Lista por favor", Me.ParentForm)
                            End If
                        Else
                            Call Aviso("Importante", "Seleccione una Clasificación Uno de la Lista por favor", Me.ParentForm)
                        End If
                    Else
                        Call Aviso("Importante", "Seleccione una Marca de la Lista por favor", Me.ParentForm)
                    End If
                Else
                    Call Aviso("Importante", "Escriba la descripción del producto", Me.ParentForm)
                End If
            Else
                Call Aviso("Importante", "Este código de producto ya existe, por favor rectifique", Me.ParentForm)
            End If
        Else
            Call Aviso("Importante", "Escriba un código de producto", Me.ParentForm)
        End If

    End Sub

    Private Sub txtProductoCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoCodigo2.select()
        End If
    End Sub

    Private Sub txtProductoCodigo2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoCodigo2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoDescripcion.select()
            'Me.txtProductoCostoUnitario.select()
        End If
    End Sub

    Private Sub txtProductoCostoUnitario_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoCostoUnitario.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtProductoDescripcion.select()
            Me.cmdProductoAgregarPrecio.select()
        End If
    End Sub

    Private Sub txtProductoDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoDescripcion2.select()
        End If
    End Sub

    Private Sub txtProductoDescripcion2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoDescripcion2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoDescripcion3.select()
        End If
    End Sub

    Private Sub txtProductoDescripcion3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoDescripcion3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductosUxc.select()
        End If
    End Sub

    Private Sub txtProductosUxc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductosUxc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoInvMinimo.select()
        End If

    End Sub

    Private Sub txtProductoInvMinimo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoInvMinimo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextBON.select()
        End If

    End Sub

    Private Sub TextBONo_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBON.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbProductoMarca.select()
        End If

    End Sub

    Private Sub cmbProductoMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductoMarca.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbProductoClaseUno.select()
        End If
    End Sub

    Private Sub cmbProductoClaseUno_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductoClaseUno.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbProductoClaseDos.select()
        End If
    End Sub

    Private Sub cmbProductoClaseDos_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductoClaseDos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbProductoClaseTres.select()
            'Me.cmbProductoMedida.select()
        End If
    End Sub

    Private Sub cmbProductoClaseTres_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductoClaseTres.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoCostoUnitario.select()
        End If
    End Sub

    Private Sub txtProductoCostoUnitario_Leave(sender As Object, e As EventArgs) Handles txtProductoCostoUnitario.Leave
        If Me.txtProductoCostoUnitario.Text <> "" Then
        Else
            Me.txtProductoCostoUnitario.Text = "0.01"
        End If
    End Sub

    Private Sub cmdProductoCancelarEdicion_Click(sender As Object, e As EventArgs) Handles cmdProductoCancelarEdicion.Click
        If EditarProducto = False Then
            If Me.cmdProductoCancelarEdicion.Visible = True Then
                Call HabilitarCamposProducto(False)
                EditarProducto = False
                Me.cmdProductoCancelarEdicion.Visible = False
                Call LimpiarCamposProducto()
                Call BorrarTempPrecios()

                Me.NavigationFrame.SelectedPage = NP_Listado
                SelectedForm = "CATALOGO"
            End If
        Else
            If Me.cmdProductoCancelarEdicion.Visible = True Then
                Call HabilitarCamposProducto(False)
                EditarProducto = False
                Me.cmdProductoCancelarEdicion.Visible = False
                Call LimpiarCamposProducto()
                Call BorrarTempPrecios()

                Me.NavigationFrame.SelectedPage = NP_Listado
                SelectedForm = "CATALOGO"
            End If

        End If

        Form1.btnGeneralAtras.Visible = True

    End Sub

    Private Sub BorrarTempPrecios()

        'SI NO SE ESTÁ EDITANDO EL PRODUCTO SE BORRAN ESTOS TEMP
        If EditarProducto = False Then
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND USUARIO='" & GlobalNomUsuario & "'", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            End Using
        End If

        Call CargarTempPrecios()
    End Sub


    'carga la lista de productos a partir del datagrid
    Dim cancelToken As New CancellationTokenSource

    Private Sub CargarDatosProductoNew(ByVal SelectedRow As DataRow)

        Try

            GlobalCodProd = SelectedRow.Item(0).ToString
            GlobalDesProd = SelectedRow.Item(1).ToString
            Me.lbNewProductosDescripcion.Text = SelectedRow.Item(1).ToString
            GlobalDesProd = SelectedRow.Item(1).ToString
            ProductosHabilitado = SelectedRow.Item(6).ToString

            Me.lbNewProductosDesc3.Text = SelectedRow.Item(3).ToString
            Me.lbNewProductosCodigo.Text = SelectedRow.Item(0).ToString
            Me.lbNewProductosCosto.Text = FormatCurrency(SelectedRow.Item(5)).ToString

            CargarPreciosProducto(GlobalCodProd)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbProductosFiltroHabilitado_Leave(sender As Object, e As EventArgs) Handles cmbProductosFiltroHabilitado.Leave
        If Me.cmbProductosFiltroHabilitado.SelectedIndex <= 0 Then

            'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
            Call cargarGridProductos()
        End If

    End Sub

    Private Sub cmbProductosFiltroHabilitado_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductosFiltroHabilitado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.GridProductos.select()
        End If
    End Sub

    Private Sub cmbProductosFiltroHabilitado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductosFiltroHabilitado.SelectedIndexChanged

        'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
        Call cargarGridProductos()
    End Sub



    '*************************************************
    '******* RADIAL PRODUCTOS ******************
    Private Sub productos_WindowsUIButton_ButtonClick(sender As Object, e As XtraBars.Docking2010.ButtonEventArgs) Handles productos_WindowsUIButton.ButtonClick
        Try

            Dim tag As String = CType(e.Button, WindowsUIButton).Tag.ToString()
            Select Case tag


                Case "IMPRIMIRK"
                    Call AbrirReporte_Kardex(GlobalCodProd, Today.Date.Year)

                Case "EXPORTARK"


                    If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then
                        Me.GridProductosKardex.DataSource = Nothing


                        Try

                            Dim ruta As String
                            ruta = Application.StartupPath + "/EXPORTS/" & GlobalCodProd.ToString & "-kardex.xlsx"

                            Me.GridProductosKardex.DataSource = ExportarReporte_Kardex(GlobalCodProd, GlobalParamDatePickI, GlobalParamDatePickF)

                            Me.GridProductosKardex.ExportToXlsx(ruta)
                            Process.Start(ruta)
                        Catch ex As Exception
                            MsgBox("La carpeta de Exportación no existe, por favor Cree la carpeta " + Application.StartupPath + "/EXPORTS para poder realizar esta operación, o puede ser que tengas abierto un archivo con el mismo nombre.")
                        End Try
                    End If


            End Select

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridViewProductos_Click(sender As Object, e As EventArgs) Handles GridViewProductos.Click
        Try

            Call CargarDatosProductoNew(Me.GridViewProductos.GetFocusedDataRow)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewProductos_DoubleClick(sender As Object, e As EventArgs) Handles GridViewProductos.DoubleClick
        Try

            'Call CargarDatosProductoNew(Me.GridViewProductos.GetFocusedDataRow)
            GlobalCodProd = Me.GridViewProductos.GetFocusedDataRow.Item(0).ToString
            'ProductosHabilitado = Me.GridViewProductos.GetFocusedDataRow.Item(11).ToString
            Me.RadialMenuProductos.ShowPopup(MousePosition)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewProductos_FocusedRowChanged(sender As Object, e As XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProductos.FocusedRowChanged
        Try
            Call CargarDatosProductoNew(Me.GridViewProductos.GetFocusedDataRow)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarPreciosProducto(ByVal codprod As String)
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                CODMEDIDA, EQUIVALE, COSTO, PRECIO, MAYOREOA, MAYOREOB, MAYOREOC,BONO 
                FROM PRECIOS 
                WHERE EMPNIT=@E AND CODPROD=@C", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codprod)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Me.dgvMedidasPrecios.DataSource = Nothing
        Me.dgvMedidasPrecios.DataSource = tbl
        Me.dgvMedidasPrecios.Refresh()

    End Sub

    Private Sub BarButtonItemProductosVerInfo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemInfo.ItemClick
        Call HabilitarCamposProducto(False)
        EditarProducto = False
        'NEW PRODUCTS
        If CargarVariablesDatosProducto(GlobalCodProd) = True Then

            Form1.btnGeneralAtras.Visible = False

            Call CargarDatosproducto()
            Me.NavigationFrame.SelectedPage = NP_Detalle
            'Me.NavigationFrame1.SelectedPage = NP_NEWPRODUCTOS
            Call CargarReceta()
            SelectedForm = "PRODUCTOS"

            Me.txtProductoCostoUnitario.Text = FormatNumber(ProductosCosto, 3)
        Else

            MsgBox("No se pudieron cargar los datos del producto" & " - " & GlobalDesError)
        End If

    End Sub

    Private Sub BarButtonItemProductosEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEditar.ItemClick

        'NEW PRODUCTS
        If CargarVariablesDatosProducto(GlobalCodProd) = True Then


            Form1.btnGeneralAtras.Visible = False

            Call HabilitarCamposProducto(True)

            Me.cmdProductoCancelarEdicion.Visible = True

            EditarProducto = True

            'muestra los controles de la Serie
            Me.lbProductoSerie.Visible = True
            Me.SwitchSeries.Visible = True
            Me.btnSeries.Visible = True


            Me.txtProductoCodigo.Enabled = False

            Call CargarCombProductosLocal()

            Call CargarDatosproducto()

            Me.NavigationFrame.SelectedPage = NP_Detalle

            SelectedForm = "PRODUCTOS"
            Call CargarReceta()

            Me.txtProductoCostoUnitario.Text = FormatNumber(ProductosCosto, 3)

        Else
            MsgBox("No se pudieron cargar los datos del producto")
        End If
    End Sub
    Private Sub BarButtonItemProductosDeshabilitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemDesactivar.ItemClick
        If Confirmacion("¿Está seguro que desea HABILITAR/DESHABILITAR este producto?", Me.ParentForm) = True Then
            Call AbrirConexionSql()
            Try

                Dim SiNo As String
                If ProductosHabilitado = "SI" Then
                    SiNo = "NO"
                Else
                    SiNo = "SI"
                End If
                'new products

                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET HABILITADO='" & SiNo & "' WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & GlobalCodProd & "'", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Call cargarGridProductos()
        End If '
    End Sub
    Private Sub BarButtonItemProductosVentas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemVentas.ItemClick

        Call AbrirReporte_VentasMes(GlobalCodProd, Today.Date.Year, Today.Date.Month)

    End Sub

    Private Sub BarButtonItemCompras_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemCompras.ItemClick
        If Report_CostosProducto(GlobalEmpNit, Today.Date.Year, GlobalCodProd) = True Then
        Else
            MsgBox("Error al cargar reporte: " & GlobalDesError)
        End If

    End Sub

    Private Sub BarButtonItemProductosKardex_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemKardex.ItemClick
        Call AbrirReporte_Kardex(GlobalCodProd, Today.Date.Year)

    End Sub

    Private Sub BarButtonItemProductosEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEliminar.ItemDoubleClick
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If VerificarMovimientosProducto(GlobalCodProd) = True Then
                Call Aviso("Imposible", "No se puede eliminar un producto que tiene movimientos, elimine los movimientos de este producto para eliminarlo. Lo deshabilitaré sin eliminar.", Me.ParentForm)
                Call AbrirConexionSql()

                Dim SiNo As String

                If ProductosHabilitado = "SI" Then
                    SiNo = "NO"
                Else
                    SiNo = "SI"
                End If

                'Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET HABILITADO='" & SiNo & "' WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & ProductosCodprod & "'", cn)
                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET HABILITADO='" & SiNo & "' WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & GlobalCodProd & "'", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                'Call Form1.EnviarNotificacionesEmail(0, "ARES te informa: Se ha Deshabilitado un producto", "El usuario " & GlobalNomUsuario & " ha deshabilitado el producto " & GlobalCodProd & " - " & GlobalDesProd)

                'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
                Call cargarGridProductos()
            Else
                If Confirmacion("¿Está seguro que desea eliminar este producto?", Me.ParentForm) = True Then

                    Call AbrirConexionSql()
                    Dim cmd As New SqlCommand("ELIMINAR_PRODUCTO", cn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    'cmd.Parameters.AddWithValue("@CODPROD", ProductosCodprod)
                    cmd.Parameters.AddWithValue("@CODPROD", GlobalCodProd)
                    cmd.ExecuteNonQuery()

                    cmd.Dispose()

                    cn.Close()

                    'Call Form1.EnviarNotificacionesEmail(0, "ARES te informa: Eliminación de producto", "El usuario " & GlobalNomUsuario & " ha eliminado el producto " & GlobalCodProd & " - " & GlobalDesProd)

                    Call cargarGridProductos()
                    'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
                End If
            End If


        End If

    End Sub

    Private Sub BarButtonItemProductosCambiar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemProductosCambiar.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            Dim ct As New AdminChangeCode(GlobalCodProd, GlobalDesProd)
            If FlyoutDialog.Show(Me.ParentForm, ct) = DialogResult.OK Then

                'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
                Call cargarGridProductos()
            End If


        End If
    End Sub

    '**********************************************
    '**********************************************
    Public Sub CargarDatosproducto()

        Me.txtProductoCodigo.Text = ProductosCodprod
        Me.txtProductoCodigo2.Text = ProductosCodprod2
        Me.txtProductoDescripcion.Text = ProductosDesProd
        Me.txtProductoDescripcion2.Text = ProductosDesProd2
        Me.txtProductoDescripcion3.Text = ProductosDesProd3
        Me.txtProductosUxc.Text = ProductosUxC.ToString


        Me.txtProductoCostoUnitario.Text = FormatNumber(ProductosCosto, 3)

        'ProductosHabilitado
        Me.cmbProductoMarca.SelectedValue = ProductosCodMarca
        Me.cmbProductoMarca.Text = ProductosDesMarca

        Me.cmbProductoClaseUno.SelectedValue = ProductosCodClaUno
        Me.cmbProductoClaseUno.Text = ProductosDesClaUno

        Me.cmbProductoClaseDos.SelectedValue = ProductosCodClaDos
        Me.cmbProductoClaseDos.Text = ProductosDesClaDos

        Me.cmbProductoClaseTres.SelectedValue = ProductosCodClaTres
        Me.cmbProductoClaseTres.Text = ProductosDesClaTres


        Me.txtProductoFechaVence.DateTime = ProductosVencimiento
        Me.txtProductoInvMinimo.Text = ProductosInvMinimo
        Me.TextBON.Text = ProductosBONO

        If ProductosSerie = 0 Then
            Me.btnSeries.Visible = False
            Me.SwitchSeries.IsOn = False
        Else
            Me.btnSeries.Visible = True
            Me.SwitchSeries.IsOn = True
        End If

        If ProductosExento = 0 Then
            Me.SwitchExento.IsOn = False
        Else
            Me.SwitchExento.IsOn = True
        End If


        'asigna el valor del color
        Me.cmbColor.SelectedValue = ProductosNF


        Me.cmbTipoProd.SelectedValue = ProductosTipoProd


        Call CargarTempPreciosEDIT()

    End Sub


    Private Sub cmdProductoAgregarPrecio_Click(sender As Object, e As EventArgs) Handles cmdProductoAgregarPrecio.Click
        If Me.txtProductoCostoUnitario.Text <> "" Then
            If FlyoutDialog.Show(Me.ParentForm, New ProductsNewPrices(Me.txtProductoCodigo.Text, Double.Parse(Me.txtProductoCostoUnitario.Text))) = DialogResult.OK Then
                Call CargarTempPrecios()
            End If
        Else
            MsgBox("Primero debe indicar el costo unitario de este producto (Costo de compra de su unidad mínima de venta)")
            Me.txtProductoCostoUnitario.select()
        End If

    End Sub


    Private Sub CargarTempPreciosEDIT()
        Dim tbl As New DataTable()
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("CODMEDIDA", GetType(String))
        tbl.Columns.Add("EQUIVALE", GetType(Integer))
        tbl.Columns.Add("COSTO", GetType(String))
        tbl.Columns.Add("PRECIO", GetType(String))
        tbl.Columns.Add("UTILIDAD", GetType(String))
        tbl.Columns.Add("MARGEN", GetType(String))
        tbl.Columns.Add("MAYOREOA", GetType(String))
        tbl.Columns.Add("MAYOREOB", GetType(String))
        tbl.Columns.Add("MAYOREOC", GetType(String))
        tbl.Columns.Add("HABILITADO", GetType(String))
        tbl.Columns.Add("MARGENCONFIG", GetType(Double))
        tbl.Columns.Add("BONO", GetType(Double))

        Dim sql As String

        'SI SE ESTÁ EDITANDO, SE CARGAN DESDE PRECIOS
        sql = "SELECT ID,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,MAYOREOA,MAYOREOB,MAYOREOC,HABILITADO, BONO FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & Me.txtProductoCodigo.Text & "'"

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Do While dr.Read
                Try
                    tbl.Rows.Add(New Object() {
                          Integer.Parse(dr(0).ToString),'id
                          dr(1).ToString,'medida
                          Integer.Parse(dr(2)),'equivale
                          FormatCurrency(dr(3)).ToString,'costo
                          FormatCurrency(dr(4)).ToString,'precio
                          FormatCurrency(dr(4) - dr(3)).ToString,'utilidad
                          ConvierteMargen(Double.Parse(dr(3)), Double.Parse(dr(4))),'margen
                          FormatCurrency(dr(7)).ToString,'precio a
                          FormatCurrency(dr(8)).ToString,'precio b 
                          FormatCurrency(dr(9)).ToString,'precio c
                          dr(10),
                          dr(6),
                          dr(11) 'BONO
                          })
                Catch ex As Exception
                    MsgBox("No se pudo cargar el precio de la medida " & dr(1).ToString & " debido al siguiente error: " & ex.ToString)
                End Try
            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()
        End Using

        Me.GridProductoPrecios.DataSource = tbl

    End Sub

    Private Function ConvierteMargen(ByVal Costo As Double, ByVal Precio As Double) As String
        Try
            Dim utilidad As Double = Precio - Costo
            Dim Margen As Double = utilidad / Costo
            Margen = Margen * 100
            Return FormatNumber(Margen, 2).ToString & " %"
        Catch ex As Exception
            Return 0.ToString & " %"
        End Try
    End Function

    Private Sub CargarTempPrecios()
        Dim tbl As New DataTable()
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("CODMEDIDA", GetType(String))
        tbl.Columns.Add("EQUIVALE", GetType(Integer))
        tbl.Columns.Add("COSTO", GetType(String))
        tbl.Columns.Add("PRECIO", GetType(String))
        tbl.Columns.Add("UTILIDAD", GetType(String))
        tbl.Columns.Add("MARGEN", GetType(String))
        tbl.Columns.Add("MAYOREOA", GetType(String))
        tbl.Columns.Add("MAYOREOB", GetType(String))
        tbl.Columns.Add("MAYOREOC", GetType(String))
        tbl.Columns.Add("HABILITADO", GetType(String))
        tbl.Columns.Add("MARGENCONFIG", GetType(Double))
        tbl.Columns.Add("BONO", GetType(Double))

        Dim sql As String

        If EditarProducto = False Then
            'SI ES UN PRODUCTO NUEVO, SE CARGAN DE LA TABLA TEMPORAL
            sql = "SELECT ID,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,MARGEN,MAYOREOA,MAYOREOB,MAYOREOC,HABILITADO,BONO FROM TEMP_PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND USUARIO='" & GlobalNomUsuario & "'"
        Else
            'SI SE ESTÁ EDITANDO, SE CARGAN DESDE PRECIOS
            sql = "SELECT ID,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,MAYOREOA,MAYOREOB,MAYOREOC,HABILITADO,BONO FROM PRECIOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & Me.txtProductoCodigo.Text & "'"
        End If

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            Do While dr.Read
                Try
                    tbl.Rows.Add(New Object() {
                             Integer.Parse(dr(0).ToString),'id
                             dr(1).ToString,'medida
                             Integer.Parse(dr(2)),'equivale
                             FormatCurrency(dr(3)).ToString,'costo
                             FormatCurrency(dr(4)).ToString,'precio
                             FormatCurrency(dr(4) - dr(3)).ToString,'utilidad
                             ConvierteMargen(Double.Parse(dr(3)), Double.Parse(dr(4))),'margen
                             FormatCurrency(dr(7)).ToString,'precio A
                             FormatCurrency(dr(8)).ToString,'precio B
                             FormatCurrency(dr(9)).ToString,'precio C
                             dr(10),
                             dr(6),
                             dr(11) 'bono
                             })
                Catch ex As Exception
                    MsgBox("No se pudo cargar el precio de la medida " & dr(1).ToString & " debido al siguiente error: " & ex.ToString)
                End Try
            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

        End Using

        Me.GridProductoPrecios.DataSource = tbl


    End Sub


    Private Sub cmdProductoBuscarFoto_Click(sender As Object, e As EventArgs) Handles cmdProductoBuscarFoto.Click
        Me.imgProductosFotoProducto.LoadImage()
        Me.txtProductosRutaFoto.Text = Me.imgProductosFotoProducto.GetLoadedImageLocation()
    End Sub

    Private Sub cmdProductoTomarFoto_Click(sender As Object, e As EventArgs) Handles cmdProductoTomarFoto.Click
        If d.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            FotoCapturada = d.Image
            FotoCapturada.Save(Application.StartupPath + "\Temp.png", Imaging.ImageFormat.Png)
            Me.txtProductosRutaFoto.Text = Application.StartupPath + "\Temp.png"
            Me.imgProductosFotoProducto.Image = FotoCapturada
        Else
        End If
    End Sub

    Private Sub cmdProductosQuitarFoto_Click(sender As Object, e As EventArgs) Handles cmdProductosQuitarFoto.Click
        Me.imgProductosFotoProducto.Image = My.Resources.attach_2_icon
        Me.txtProductosRutaFoto.Text = ""
    End Sub

    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        Form1.btnGeneralAtras.Visible = True

        Call HabilitarCamposProducto(False)
        EditarProducto = False
        Me.cmdProductoCancelarEdicion.Visible = False
        Call LimpiarCamposProducto()
        Call BorrarTempPrecios()

        Me.NavigationFrame.SelectedPage = NP_Listado
        SelectedForm = "CATALOGO"
    End Sub

#End Region


    Public Sub CargarCombProductosLocal()

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Try

                'CARGAR LAS MARCAS
                Dim Dt As DataTable
                Dim Da As New SqlDataAdapter
                Dim Cmd As New SqlCommand
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT CODMARCA, DESMARCA FROM MARCAS WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .Connection = cn
                End With
                Da.SelectCommand = Cmd
                Dt = New DataTable
                Da.Fill(Dt)

                With Me.cmbProductoMarca
                    .DataSource = Dt
                    .DisplayMember = "DESMARCA"
                    .ValueMember = "CODMARCA"
                End With

            Catch ex As Exception

            End Try

            Try

                'CLASIFICACION UNO
                Dim Dt1 As DataTable
                Dim Da1 As New SqlDataAdapter
                Dim Cmd1 As New SqlCommand
                With Cmd1
                    .CommandType = CommandType.Text
                    '.CommandText = "SELECT CODPROV, EMPRESA FROM PROVEEDORES  WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .CommandText = "SELECT CODCLAUNO, DESCLAUNO FROM CLASIFICACIONUNO  WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .Connection = cn
                End With
                Da1.SelectCommand = Cmd1
                Dt1 = New DataTable
                Da1.Fill(Dt1)

                With Me.cmbProductoClaseUno
                    .DataSource = Dt1
                    .DisplayMember = "DESCLAUNO"
                    .ValueMember = "CODCLAUNO"
                    '.DisplayMember = "EMPRESA"
                    '.ValueMember = "CODPROV"
                End With

            Catch ex As Exception

            End Try

            Try
                'CLASIFICACION DOS
                Dim Dt2 As DataTable
                Dim Da2 As New SqlDataAdapter
                Dim Cmd2 As New SqlCommand
                With Cmd2
                    .CommandType = CommandType.Text
                    '.CommandText = "SELECT CODCLADOS, DESCLADOS FROM CLASIFICACIONDOS  WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .CommandText = "SELECT CODPROV, EMPRESA FROM PROVEEDORES  WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .Connection = cn
                End With
                Da2.SelectCommand = Cmd2
                Dt2 = New DataTable
                Da2.Fill(Dt2)

                With Me.cmbProductoClaseDos
                    .DataSource = Dt2
                    '.DisplayMember = "DESCLADOS"
                    '.ValueMember = "CODCLADOS"
                    .DisplayMember = "EMPRESA"
                    .ValueMember = "CODPROV"
                End With

            Catch ex As Exception

            End Try


            Try

                'CLASIFICACION TRES
                Dim Dt3 As DataTable
                Dim Da3 As New SqlDataAdapter
                Dim Cmd3 As New SqlCommand
                With Cmd3
                    .CommandType = CommandType.Text
                    '.CommandText = "SELECT CODCLATRES, DESCLATRES FROM CLASIFICACIONTRES  WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .CommandText = "SELECT CODCLADOS, DESCLADOS FROM CLASIFICACIONDOS  WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .Connection = cn
                End With
                Da3.SelectCommand = Cmd3
                Dt3 = New DataTable
                Da3.Fill(Dt3)

                With Me.cmbProductoClaseTres
                    .DataSource = Dt3
                    .DisplayMember = "DESCLADOS"
                    .ValueMember = "CODCLADOS"
                    '.DisplayMember = "DESCLATRES"
                    '.ValueMember = "CODCLATRES"
                End With

            Catch ex As Exception

            End Try


        End Using

    End Sub


    Public Function CargarVariablesDatosProducto(ByVal CodProd As String) As Boolean

        Try

            Dim SQL, SQL2 As String

            Dim SQL22 As String
            SQL22 = "SELECT       PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRODUCTOS.COSTO, PRODUCTOS.CODMARCA, 
                         PRODUCTOS.CODCLAUNO, PRODUCTOS.CODCLADOS, PRODUCTOS.CODCLATRES, MARCAS.DESMARCA, PROVEEDORES.EMPRESA AS DESCLAUNO, CLASIFICACIONDOS.DESCLADOS, 
                         CLASIFICACIONTRES.DESCLATRES, PRODUCTOS_FOTOS.FOTO, PRODUCTOS.HABILITADO, ISNULL(PRODUCTOS.VENCIMIENTO, '01/01/2000') AS VENCIMIENTO, ISNULL(PRODUCTOS.SERIE, 0) AS SERIE, 
                         ISNULL(PRODUCTOS.INVMINIMO, 1) AS INVMINIMO, ISNULL(PRODUCTOS.EXENTO, 0) AS EXENTO, ISNULL(PRODUCTOS.NF, 0) AS NF, ISNULL(PRODUCTOS.TIPOPROD, 'P') AS TIPOPROD, PRODUCTOS.BONO
                    FROM            PRODUCTOS LEFT OUTER JOIN
                         PROVEEDORES ON PRODUCTOS.CODCLAUNO = PROVEEDORES.CODPROV AND PRODUCTOS.EMPNIT = PROVEEDORES.EMPNIT LEFT OUTER JOIN
                         PRODUCTOS_FOTOS ON PRODUCTOS.CODPROD = PRODUCTOS_FOTOS.CODPROD AND PRODUCTOS.EMPNIT = PRODUCTOS_FOTOS.EMPNIT LEFT OUTER JOIN
                         CLASIFICACIONTRES ON PRODUCTOS.EMPNIT = CLASIFICACIONTRES.EMPNIT AND PRODUCTOS.CODCLATRES = CLASIFICACIONTRES.CODCLATRES LEFT OUTER JOIN
                         CLASIFICACIONDOS ON PRODUCTOS.EMPNIT = CLASIFICACIONDOS.EMPNIT AND PRODUCTOS.CODCLADOS = CLASIFICACIONDOS.CODCLADOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO LEFT OUTER JOIN
                         MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA
                    WHERE (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.CODPROD = @CODPROD)"

            SQL = "SELECT        PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRODUCTOS.COSTO, PRODUCTOS.CODMARCA, PRODUCTOS.CODCLAUNO, 
                         PRODUCTOS.CODCLADOS, PRODUCTOS.CODCLATRES, MARCAS.DESMARCA, CLASIFICACIONUNO.DESCLAUNO, PROVEEDORES.EMPRESA AS DESCLADOS, CLASIFICACIONDOS.DESCLADOS AS DESCLATRES, 
                         PRODUCTOS_FOTOS.FOTO, PRODUCTOS.HABILITADO, ISNULL(PRODUCTOS.VENCIMIENTO, '01/01/2000') AS VENCIMIENTO, ISNULL(PRODUCTOS.SERIE, 0) AS SERIE, ISNULL(PRODUCTOS.INVMINIMO, 1) AS INVMINIMO, 
                         ISNULL(PRODUCTOS.EXENTO, 0) AS EXENTO, ISNULL(PRODUCTOS.NF, 0) AS NF, ISNULL(PRODUCTOS.TIPOPROD, 'P') AS TIPOPROD, PRODUCTOS.BONO
FROM            PRODUCTOS LEFT OUTER JOIN
                         CLASIFICACIONDOS ON PRODUCTOS.CODCLATRES = CLASIFICACIONDOS.CODCLADOS AND PRODUCTOS.EMPNIT = CLASIFICACIONDOS.EMPNIT LEFT OUTER JOIN
                         PROVEEDORES ON PRODUCTOS.CODCLADOS = PROVEEDORES.CODPROV AND PRODUCTOS.EMPNIT = PROVEEDORES.EMPNIT LEFT OUTER JOIN
                         PRODUCTOS_FOTOS ON PRODUCTOS.CODPROD = PRODUCTOS_FOTOS.CODPROD AND PRODUCTOS.EMPNIT = PRODUCTOS_FOTOS.EMPNIT LEFT OUTER JOIN
                         CLASIFICACIONTRES ON PRODUCTOS.EMPNIT = CLASIFICACIONTRES.EMPNIT AND PRODUCTOS.CODCLATRES = CLASIFICACIONTRES.CODCLATRES LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO LEFT OUTER JOIN
                         MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA
            WHERE        (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.CODPROD = @CODPROD)"

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODPROD", CodProd)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                ProductosCodprod = dr(0).ToString
                ProductosCodprod2 = dr(1).ToString
                ProductosDesProd = dr(2).ToString
                ProductosDesProd2 = dr(3).ToString
                ProductosDesProd3 = dr(4).ToString

                ProductosUxC = CType(dr(5), Integer)

                ProductosCosto = Double.Parse(dr(6))

                ProductosPrecio = 0
                'ProductosHabilitado = dr(16).ToString

                ProductosCodMarca = Integer.Parse(dr(7))
                ProductosCodClaUno = Integer.Parse(dr(8))
                ProductosCodClaDos = Integer.Parse(dr(9))
                ProductosCodClaTres = Integer.Parse(dr(10))

                ProductosDesMarca = dr(11).ToString
                ProductosDesClaUno = dr(12).ToString
                ProductosDesClaDos = dr(13).ToString
                ProductosDesClaTres = dr(14).ToString

                ProductosVencimiento = Date.Parse(dr(17))
                ProductosSerie = CType(dr(18), Integer)
                ProductosInvMinimo = CType(dr(19), Integer)

                ProductosExento = CType(dr(20), Integer)
                ProductosNF = CType(dr(21), Integer)
                ProductosTipoProd = dr(22).ToString
                ProductosBONO = CType(dr(23), Double)

                If dr(15) Is DBNull.Value Then
                    ProductosFoto = My.Resources.attach_2_icon
                Else
                    ProductosFoto = ObtenerImgSql(dr(15))
                End If

                dr.Close()
                cmd.Dispose()
                cn.Close()

            End Using

            Return True

        Catch ex As Exception
            MsgBox(ex.ToString)
            GlobalDesError = ex.ToString
            Return False
        End Try

    End Function

    Public Function VerificarCodProd(ByVal Codigo As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'VERIFICA PRIMERO SI EXISTE EN EL CÓDIGO PRINCIPAL
                Dim cmd As New SqlCommand("Select CodProd From PRODUCTOS Where Empnit='" & GlobalEmpNit & "' and Codprod='" & Codigo & "'", cn)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                dr.Read()
                Try
                    If dr.HasRows Then
                        If EditarProducto = False Then
                            result = True
                        Else
                            result = False
                        End If
                    End If
                Catch ex As Exception
                    result = False
                End Try
                dr.Close()

                If result = False Then

                    'LUEGO VERIFICA SI EXISTE EN EL CÓDIGO ALTERNO
                    Dim cmd2 As New SqlCommand("Select CodProd2 From PRODUCTOS Where Empnit='" & GlobalEmpNit & "' and Codprod2='" & Codigo & "'", cn)
                    Dim dr2 As SqlDataReader
                    dr2 = cmd.ExecuteReader
                    dr2.Read()
                    Try
                        If dr2.HasRows Then
                            If EditarProducto = False Then
                                result = True
                            Else
                                result = False
                            End If
                        End If
                    Catch ex As Exception
                        result = False
                    End Try
                    dr2.Close()
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try


        End Using

        Return result

    End Function    'VERIFICO SI EL CÒDIGO EXISTE O NO

    Public Function VerificarMovimientosProducto(ByVal Codigo As String) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Dim cmd As New SqlCommand("Select TOP 1 CodProd From Docproductos Where Empnit='" & GlobalEmpNit & "' and Codprod='" & Codigo & "'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    result = True
                End If
            Catch ex As Exception
                result = False
            End Try

        End Using

        Return result

    End Function 'VERIFICA SI EL PRODUCTO YA TIENE MOVIMIENTOS


    'personaliza la empresa dependiendo del tipo
    Public Sub CargarLabels(ByVal TipoEmpresa As String)
        Select Case TipoEmpresa
            Case "POS"


                LbProductosDesc2.Text = "Descripción 2:"
                LbProductosDesc3.Text = "Descripción 3:"

                GridViewProductos.Columns.Item(2).Caption = "Descripción 2"

                GridViewProductos.Columns.Item(3).Caption = "Descripción 3"


            Case "FAR"

                LbProductosDesc2.Text = "Componente:"
                LbProductosDesc3.Text = "Uso:"

                GridViewProductos.Columns.Item(2).Caption = "Componente"

                GridViewProductos.Columns.Item(3).Caption = "Uso"


            Case "RES"

                LbProductosDesc2.Text = "Descripción 2:"
                LbProductosDesc3.Text = "Descripción 3:"

            Case "DIS"

                LbProductosDesc2.Text = "Descripción 2:"
                LbProductosDesc3.Text = "Descripción 3:"

        End Select
    End Sub

    Private Sub SwitchSeries_Toggled(sender As Object, e As EventArgs) Handles SwitchSeries.Toggled
        If Me.SwitchSeries.IsOn = True Then
            If objProductos.update_serieStatus(GlobalEmpNit, Me.txtProductoCodigo.Text, True) = True Then
                Me.btnSeries.Visible = True
            End If
        Else
            If objProductos.update_serieStatus(GlobalEmpNit, Me.txtProductoCodigo.Text, False) = True Then
                Me.btnSeries.Visible = False
            End If

        End If
    End Sub

    Private Sub btnSeries_Click(sender As Object, e As EventArgs) Handles btnSeries.Click

        Me.FlyoutPanelSeries.ShowPopup()

        Call CargarGridSeries()

    End Sub

    Private Sub btnSerieGuardar_Click(sender As Object, e As EventArgs) Handles btnSerieGuardar.Click
        If Me.txtSerieNoSerie.Text <> "" Then

            If Me.txtSerieColor.Text <> "" Then
            Else
                Me.txtSerieColor.Text = "SN"
            End If


            If objProductos.ComprobarNoSerie(GlobalEmpNit, Me.txtSerieNoSerie.Text) = True Then
                Call Aviso("NO PERMITIDO", "Este número de serie ya existe, por favor, utilice otro o elimine el anterior", Me.ParentForm)

            Else

                If objProductos.insert_Serie(GlobalEmpNit, Me.txtProductoCodigo.Text, Me.txtSerieNoSerie.Text, Me.txtSerieColor.Text) = True Then
                    Call CargarGridSeries()

                    Me.txtSerieNoSerie.Text = ""
                    Me.txtSerieColor.Text = ""
                    Me.txtSerieNoSerie.select()

                Else

                    MsgBox("No pude guardar el registro. Error: " & GlobalDesError)
                End If

            End If

        Else
            MsgBox("Escriba un número de Serie")
        End If
    End Sub

    Private Sub btnSerieCancelar_Click(sender As Object, e As EventArgs) Handles btnSerieCancelar.Click
        Me.txtSerieNoSerie.Text = ""
        Me.txtSerieColor.Text = ""
        Me.txtSerieNoSerie.select()
    End Sub

    Private Sub CargarGridSeries()
        Me.dgvSeries.DataSource = Nothing
        Me.dgvSeries.DataSource = objProductos.tbl_Series(GlobalEmpNit, Me.txtProductoCodigo.Text)
    End Sub

    Private Sub btnEliminarTodos_Click(sender As Object, e As EventArgs) Handles btnEliminarTodos.Click
        If Confirmacion("¿Está seguro que desea Eliminar todas las Series asociadas a este Producto?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = True Then
                If objProductos.deleteall_Series(GlobalEmpNit, Me.txtProductoCodigo.Text) = True Then
                    Call CargarGridSeries()
                Else
                    MsgBox("No pude Eliminar los números de Serie. Error: " & GlobalDesError)
                End If
            End If

        End If
    End Sub

    Private Sub GridViewSeries_DoubleClick(sender As Object, e As EventArgs) Handles GridViewSeries.DoubleClick
        If Confirmacion("¿Está seguro que quiere Eliminar este número de serie?", Me.ParentForm) = True Then
            If objProductos.delete_Serie(CType(Me.GridViewSeries.GetFocusedDataRow.Item(0), Integer)) = True Then
                Call CargarGridSeries()
            Else
                MsgBox("No se pudo Eliminar este Item. Error: " & GlobalDesError)
            End If
        End If
    End Sub

    Private Sub btnSerieCerrarPanel_Click(sender As Object, e As EventArgs) Handles btnSerieCerrarPanel.Click
        Me.FlyoutPanelSeries.HidePopup()
    End Sub

    Private Sub BarButtonItemEliminar_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItemEliminar.ItemClick
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If VerificarMovimientosProducto(GlobalCodProd) = True Then

                Call Aviso("Imposible", "No se puede eliminar un producto que tiene movimientos, elimine los movimientos de este producto para eliminarlo. Lo deshabilitaré sin eliminar.", Me.ParentForm)

                Dim SiNo As String

                If ProductosHabilitado = "SI" Then
                    SiNo = "NO"
                Else
                    SiNo = "SI"
                End If


                Using cn As New SqlConnection(strSqlConectionString)
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET HABILITADO='" & SiNo & "' WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & GlobalCodProd & "'", cn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()
                    cn.Close()

                End Using

                'Call Form1.EnviarNotificacionesEmail(0, "ARES te informa: Se ha Deshabilitado un producto", "El usuario " & GlobalNomUsuario & " ha deshabilitado el producto " & GlobalCodProd & " - " & GlobalDesProd)


                'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())

            Else
                If Confirmacion("¿Está seguro que desea eliminar este producto?", Me.ParentForm) = True Then

                    Using cn As New SqlConnection(strSqlConectionString)
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If

                        Dim cmd As New SqlCommand("ELIMINAR_PRODUCTO", cn)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODPROD", GlobalCodProd)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        cn.Close()
                    End Using

                    'Call Form1.EnviarNotificacionesEmail(0, "ARES te informa: Eliminación de producto", "El usuario " & GlobalNomUsuario & " ha eliminado el producto " & GlobalCodProd & " - " & GlobalDesProd)

                    'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
                    Call cargarGridProductos()
                End If
            End If

        End If
    End Sub

    Private Sub btnRadMenPreciosCompetencia_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnRadMenPreciosCompetencia.ItemClick
        FlyoutDialog.Show(Me.ParentForm, New viewProductosPreciosCompetencia(GlobalEmpNit, GlobalCodProd, GlobalDesProd))
    End Sub

#Region "PRUEBAS ASYNC"

    ''' <summary>
    ''' carga la lista de productos con un método asyncrono
    ''' </summary>
    Private Async Sub cargarGridProductos()

        'Me.GridProductos.DataSource = Await Task(Of DataTable).Run(Function() CargarListadoProductos())
        Me.GridProductos.DataSource = CargarListadoProductos()

    End Sub

    'carga la lista de productos a partir del datagrid
    Private Function CargarListadoProductos() As DataTable

        Dim result As New DataTable

        Dim tbl As New DSGeneral.tblProductosDataTable

        Dim filtroHabilitado As String
        Select Case Me.cmbProductosFiltroHabilitado.Text
            Case "HABILITADOS"
                filtroHabilitado = "SI"
            Case "DESHABILITADOS"
                filtroHabilitado = "NO"
            Case "TODOS"
                filtroHabilitado = ""
        End Select

        Dim SQL As String
        SQL = "SELECT           PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.COSTO, MARCAS.DESMARCA, PRODUCTOS.EXENTO, PRODUCTOS.BONO, PRODUCTOS.HABILITADO
               FROM             PRODUCTOS LEFT OUTER JOIN
                                CLASIFICACIONUNO ON PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO AND PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT LEFT OUTER JOIN
                                CLASIFICACIONTRES ON PRODUCTOS.CODCLATRES = CLASIFICACIONTRES.CODCLATRES AND PRODUCTOS.EMPNIT = CLASIFICACIONTRES.EMPNIT LEFT OUTER JOIN
                                CLASIFICACIONDOS ON PRODUCTOS.CODCLADOS = CLASIFICACIONDOS.CODCLADOS AND PRODUCTOS.EMPNIT = CLASIFICACIONDOS.EMPNIT LEFT OUTER JOIN
                                MARCAS ON PRODUCTOS.CODMARCA = MARCAS.CODMARCA AND PRODUCTOS.EMPNIT = MARCAS.EMPNIT
               WHERE            (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO LIKE @HABILITADO)
               ORDER BY         PRODUCTOS.DESPROD"


        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@HABILITADO", "%" & filtroHabilitado & "%")
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                    dr(0).ToString,'codigo
                    dr(1).ToString,'descripcion
                    Double.Parse(dr(2)),'costo
                    dr(3).ToString,
                    dr(4).ToString,
                    Double.Parse(dr(5)),'costo
                    dr(6).ToString
                                                 })
                Loop

                Me.GridProductos.DataSource = Nothing

                'Me.GridViewProductos.OptionsView.ShowPreview = False 'con true muestra una linea abajo para ver un preview del contenido
                'Me.GridViewProductos.FocusRectStyle = XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus

                result = tbl
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = Nothing
                MsgBox("El listado de productos no se cargo por lo siguiente: " & GlobalDesError)
            End Try

            cn.Close()
        End Using

        Return result
    End Function

    Private Function getTipoProd(ByVal tipo As String) As String
        Dim st As String = ""

        Select Case tipo
            Case "P"
                st = "PROPIO"
            Case "E"
                st = "EXTERNO"
            Case "S"
                st = "SERVICIO"
            Case "F"
                st = "FABRICADO"
        End Select

        Return st

    End Function

    Dim isExento As Integer = 0
    Private Sub SwitchExento_Toggled(sender As Object, e As EventArgs) Handles SwitchExento.Toggled
        If Me.SwitchExento.IsOn = True Then
            isExento = 1
        Else
            isExento = 0
        End If
    End Sub

    Dim isNF As Integer = 0


    Private Sub GridProductoPrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles GridProductoPrecios.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Me.txtProductoDescripcion.Enabled = True Then
                If Confirmacion("¿Desea editar este precio?", Me.ParentForm) = True Then
                    SelectedCode = CType(Me.GridProductoPrecios.Item(0, Me.GridProductoPrecios.CurrentRow.Index).Value, Integer)
                    Dim CODMED As String = Me.GridProductoPrecios.Item(1, Me.GridProductoPrecios.CurrentRow.Index).Value.ToString

                    Dim SQL As String
                    If EditarProducto = False Then
                        SQL = "DELETE FROM TEMP_PRECIOS WHERE ID=" & SelectedCode

                        Using cn As New SqlConnection(strSqlConectionString)
                            If cn.State <> ConnectionState.Open Then
                                cn.Open()
                            End If
                            Dim cmd As New SqlCommand(SQL, cn)
                            cmd.ExecuteNonQuery()
                        End Using
                        Call CargarTempPrecios()
                    Else

                        If FlyoutDialog.Show(Me.ParentForm, New ProductsEditPrices(Me.txtProductoCodigo.Text, Double.Parse(Me.txtProductoCostoUnitario.Text), CODMED)) = DialogResult.OK Then
                            Call CargarTempPrecios()
                        End If

                    End If


                End If
            End If


        End If
    End Sub

    Private Sub GridProductoPrecios_DoubleClick(sender As Object, e As EventArgs) Handles GridProductoPrecios.DoubleClick
        If Me.txtProductoDescripcion.Enabled = True Then
            If Confirmacion("¿Desea editar este precio?", Me.ParentForm) = True Then
                SelectedCode = CType(Me.GridProductoPrecios.Item(0, Me.GridProductoPrecios.CurrentRow.Index).Value, Integer)
                Dim CODMED As String = Me.GridProductoPrecios.Item(1, Me.GridProductoPrecios.CurrentRow.Index).Value.ToString

                Dim SQL As String
                If EditarProducto = False Then
                    SQL = "DELETE FROM TEMP_PRECIOS WHERE ID=" & SelectedCode

                    Using cn As New SqlConnection(strSqlConectionString)
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If
                        Dim cmd As New SqlCommand(SQL, cn)
                        cmd.ExecuteNonQuery()
                    End Using
                    Call CargarTempPrecios()
                Else

                    If FlyoutDialog.Show(Me.ParentForm, New ProductsEditPrices(Me.txtProductoCodigo.Text, Double.Parse(Me.txtProductoCostoUnitario.Text), CODMED)) = DialogResult.OK Then
                        Call CargarTempPrecios()
                    End If

                End If


            End If
        End If
    End Sub

    Private Sub GridViewProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.RadialMenuProductos.ShowPopup(MousePosition)
        End If
    End Sub

    Dim SelectedPage As String

    Private Sub ViewProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If SelectedForm = "CATALOGO" Then
            Select Case e.KeyCode
                Case Keys.F3

                    Me.cmdNewProductosNuevo.PerformClick()
            End Select

        Else
            Select Case e.KeyCode
                Case Keys.F5

                    Me.cmdProductoGuardar.PerformClick()

                Case Keys.F2
                    Me.cmdProductoCancelarEdicion.PerformClick()

            End Select
        End If

    End Sub

#End Region

#Region " ** RECETA ** "
    Private Sub cmbTipoProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoProd.SelectedIndexChanged
        If Me.cmbTipoProd.SelectedValue.ToString = "F" Then
            Me.DgwReceta.Visible = True
            Me.btnAgregarReceta.Visible = True
        Else
            Me.DgwReceta.Visible = False
            Me.btnAgregarReceta.Visible = False
        End If
    End Sub

    Private Sub btnAgregarReceta_Click(sender As Object, e As EventArgs) Handles btnAgregarReceta.Click
        If FlyoutDialog.Show(Me.ParentForm, New viewProductosAgregarProdReceta(Me.txtProductoCodigo.Text)) = DialogResult.OK Then
            Call CargarReceta()
        End If
    End Sub

    Private Sub CargarReceta()
        Dim totalcostor As Double = 0
        Dim tbl As New DSPRODUCTOS.tblRecetaDataTable
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("SELECT CODPROD,DESPROD,CODMEDIDA,CANTIDAD,TOTALUNIDADES,COSTO,TOTALCOSTO FROM PRODUCTOS_RECETAS WHERE EMPNIT=@E AND MAINCODPROD=@C", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", Me.txtProductoCodigo.Text)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    totalcostor = totalcostor + CType(dr(6), Double)
                    tbl.Rows.Add(New Object() {
                                       dr(0),
                                       dr(1),
                                       dr(2),
                                       dr(3),
                                       dr(4),
                                       dr(5),
                                       dr(6)  'totalcosto
                    })
                Loop
            Catch ex As Exception
                tbl = Nothing
            End Try

        End Using

        Me.DgwReceta.DataSource = Nothing
        Me.DgwReceta.DataSource = tbl

        Me.txtProductoCostoUnitario.Text = totalcostor

    End Sub

    Private Sub btnProductoEliminarReceta_Click(sender As Object, e As EventArgs) Handles btnProductoEliminarReceta.Click
        If Confirmacion("¿Está seguro que desea Eliminar la Receta del Producto?", Me.ParentForm) = True Then
            Using cn As New SqlConnection(strSqlConectionString)
                Try
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlCommand("DELETE FROM PRODUCTOS_RECETAS WHERE EMPNIT=@E AND MAINCODPROD=@C", cn)
                    cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@C", Me.txtProductoCodigo.Text)
                    cmd.ExecuteNonQuery()

                    Call CargarReceta()

                Catch ex As Exception
                    MsgBox("Error al eliminar la receta. Error: " + ex.ToString)
                End Try

            End Using
        End If
    End Sub

#End Region

#Region " ** FLYOT OPCIONES AVANZADAS ** "

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.FlyoutOpcionesAvanzadas.ShowPopup()
    End Sub


    Private Sub btnConfigActualizarCostos_Click(sender As Object, e As EventArgs) Handles btnConfigActualizarCostos.Click
        If Confirmacion("¿Está seguro que desea actualizar todos el costo de las medidas de precio?", Me.ParentForm) = True Then
            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
                Dim r As Boolean

                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objprod As New ClassProductos
                r = objprod.setCostosProductos()

                SplashScreenManager.CloseForm()

                If r = True Then
                    MsgBox("Catálogo de Costos Actualizado exitosamente!!")
                Else
                    MsgBox("Ha ocurrido un error. Error: " + GlobalDesError)
                End If

            End If
        End If
    End Sub

    Private Sub btnSincronizarTodo_Click(sender As Object, e As EventArgs) Handles btnSincronizarTodo.Click

        Call fcn_HablarTexto("Está a punto de reemplazar el catálogo de productos de las otras empresas con el catálogo de la empresa actual, está seguro que es lo que quiere hacer?")

        MsgBox("Está a punto de reemplazar el catálogo de productos de las otras empresas con el catálogo de la empresa actual, está seguro que es lo que quiere hacer?")
        If Confirmacion("¿Está seguro que desea establecer este catálogo en todas las Empresas del Sistema?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then


                Dim r As Boolean

                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objprod As New ClassProductos
                r = objprod.setCatalogoProductosTodasEmpresas(GlobalEmpNit)



                SplashScreenManager.CloseForm()

                If r = True Then
                    MsgBox("Catálogo cargado a todas las Empresas")
                Else
                    MsgBox("Ha ocurrido un error. Error: " + GlobalDesError)
                End If

            End If
        End If


    End Sub

    Private Sub BarButtonItemInventarioOnline_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItemInventarioOnline.ItemClick
        FlyoutDialog.Show(Me.ParentForm, New viewInventarioOnline(GlobalEmpNit, GlobalCodProd))

    End Sub

    Private Sub BarButtonItemMenDetallesAdicionales_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles BarButtonItemMenDetallesAdicionales.ItemClick

        If GlobalTipoSucursal = 1 Then
            FlyoutDialog.Show(Me.ParentForm, New viewProductosOnlineAdicionales(GlobalCodProd, GlobalDesProd))
        Else
            MsgBox("Lo siento, no puedes hacer esto en una Sucursal, solamente en una Central")
        End If
    End Sub

    Private Sub TblProductosBindingSource1_CurrentChanged(sender As Object, e As EventArgs) Handles TblProductosBindingSource1.CurrentChanged

    End Sub

    Private Sub TblDatosAdicionalesProductosBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles TblDatosAdicionalesProductosBindingSource.CurrentChanged

    End Sub

    Private Sub TblRecetaBindingSource1_CurrentChanged(sender As Object, e As EventArgs) Handles TblRecetaBindingSource1.CurrentChanged

    End Sub

    Private Sub TblProductosBindingSource2_CurrentChanged(sender As Object, e As EventArgs) Handles TblProductosBindingSource2.CurrentChanged

    End Sub

#End Region

End Class
