Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo

Public Class viewClientes

    Private Sub viewClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGridClientes()

        Call CargarMunicipiosDeptos()

        Call CargarRutasClientes()

        Call CargarComboboxesGenerales()

        'Me.txtClientesNit.select()

    End Sub


#Region " ** CLIENTES ** "

    Private Sub txtClientesNit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesNit.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtClientesCodclie.select()
            Me.txtClientesNombre.select()
        End If
    End Sub

    Private Sub txtClientesNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Me.cmbClienteDiaVisita.select()
            Me.txtClientesDireccion.select()
        End If
    End Sub

    Private Sub txtClientesDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtClientesProvincia.select()
        End If
    End Sub

    Private Sub cmbClientesMunicipio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbClientesMunicipio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbClientesDepartamento.select()
        End If
    End Sub

    Private Sub cmbClientesDepartamento_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbClientesDepartamento.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtClientesTelefonos.select()
        End If
    End Sub

    Private Sub txtClientesTelefonos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesTelefonos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtClientesEmail.select()
        End If
    End Sub

    Private Sub txtClientesEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.cmbClientesRuta.select()
            Me.cmdClientesGuardar.select()
        End If
    End Sub
    Private Sub cmbClientesRuta_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbClientesRuta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbTipoPrecio.select()
        End If

    End Sub

    Private Sub cmdClientesGuardar_Click(sender As Object, e As EventArgs) Handles cmdClientesGuardar.Click
        If Me.txtClientesCodclie.Text <> "" Then

        Else
            'genera automáticamente un código de cliente en base a la hora y fecha
            Me.txtClientesCodclie.Text = String.Format("aut{0}-{1}-{2}h{3}:{4}", Today.Date.Day.ToString, Today.Date.Month.ToString, Today.Date.Year.ToString, Now.Hour.ToString, Now.Minute.ToString)
        End If

        If Me.lbClienteLat.Text <> "" Then
        Else
            Me.lbClienteLat.Text = "0.00001"
        End If
        If Me.lbClienteLong.Text <> "" Then
        Else
            Me.lbClienteLong.Text = "0.00001"
        End If

        Dim objCli As New classClientes(GlobalEmpNit)
        'verifica si el campo codclie existe ya en la base de datos
        If objCli.verifyCodClie(Me.txtClientesCodclie.Text) = True Then
            If Me.cmdClientesCancelarEdit.Visible = True Then
                GoTo Continuar
            Else
                Call Aviso("ERROR", "Este código de cliente ya existe, por favor utilice otro", Me.ParentForm)
                Exit Sub
            End If

        Else
            GoTo Continuar
        End If


Continuar:

        'If Me.cmbClienteTipoNegocio.SelectedIndex >= 0 Then
        'Else
        ' Me.cmbClienteTipoNegocio.SelectedIndex = 0
        ' End If

        If Me.txtClienteNombreNegocio.Text <> "" Then
        Else
            Me.txtClienteNombreNegocio.Text = "SN"
        End If

        'If Me.cmbClienteDiaVisita.SelectedIndex >= 0 Then
        'Else
        ' Me.cmbClienteDiaVisita.SelectedIndex = 0
        'End If


        If Me.txtClientesNit.Text <> "" Then
        Else
            Me.txtClientesNit.Text = "CF"
        End If
        If Me.txtClientesNombre.Text <> "" Then

            If Me.cmdClientesCancelarEdit.Visible = True Then
                GoTo GuardarCliente
            End If

            If ExisteNitCliente(Me.txtClientesNit.Text) = False Then
                GoTo GuardarCliente
            Else
                Call Aviso("No Permitido", "Este NIT ya existe, por favor utilice otro", Me.ParentForm)
                Exit Sub
            End If

GuardarCliente:
            If Me.txtClientesDireccion.Text <> "" Then
                Me.txtClientesDireccion.Text = cleanString(Me.txtClientesDireccion.Text)
            Else
                Me.txtClientesDireccion.Text = "Ciudad"
            End If
            If Me.cmbClientesMunicipio.SelectedValue > 0 Then
            Else
                Me.cmbClientesMunicipio.SelectedIndex = 0
            End If
            If Me.cmbClientesDepartamento.SelectedValue > 0 Then
            Else
                Me.cmbClientesDepartamento.SelectedIndex = 0
            End If
            If Me.txtClientesTelefonos.Text <> "" Then
            Else
                Me.txtClientesTelefonos.Text = "SN"
            End If
            If Me.txtClientesEmail.Text <> "" Then
            Else
                Me.txtClientesEmail.Text = "SN"
            End If
            If Me.txtClientesProvincia.Text <> "" Then
            Else
                Me.txtClientesProvincia.Text = "SN"
            End If
            'If Me.cmbClientesRuta.SelectedIndex >= 0 Then
            'Else
            'Me.cmbClientesRuta.SelectedIndex = 0
            'End If
            'If Me.cmbTipoPrecio.SelectedIndex >= 0 Then
            'Else
            'Me.cmbTipoPrecio.SelectedIndex = 0
            'End If

            If Confirmacion("¿Está seguro que desea guardar este Cliente?", Me.ParentForm) = True Then
                Call AbrirConexionSql()

                Dim sql As String
                If Me.cmdClientesCancelarEdit.Visible = True Then
                    sql = "UPDATE CLIENTES SET DPI=@DPI,NIT=@NIT,
                        NOMBRECLIENTE=@NOMBRECLIENTE,DIRCLIENTE=@DIRCLIENTE,
                        CODMUNICIPIO=@CODMUNICIPIO,CODDEPARTAMENTO=@CODDEPARTAMENTO,
                        TELEFONOCLIENTE=@TELEFONOCLIENTE,EMAILCLIENTE=@EMAILCLIENTE,
                        ESTADOCIVIL=@ESTADOCIVIL,SEXO=@SEXO,
                        FECHANACIMIENTOCLIENTE=@FECHANACIMIENTOCLIENTE,
                        LATITUDCLIENTE=@LATITUDCLIENTE,LONGITUDCLIENTE=@LONGITUDCLIENTE,
                        CATEGORIA=@CATEGORIA,CIUDADANIA=@CIUDADANIA,
                        OCUPACION=@OCUPACION,CODRUTA=@CODRUTA,CALIFICACION=@CALIFICACION,
                        SALDO=@SALDO,FECHAINICIO=@FECHAINICIO,PROVINCIA=@PROVINCIA,
                        TIPONEGOCIO=@TIPONEGOCIO,NEGOCIO=@NEGOCIO,CODCLIE=@CODCLIE,DIAVISITA=@DIAVISITA 
                        WHERE EMPNIT=@EMPNIT AND CODCLIENTE=" & SelectedCode
                Else
                    sql = "INSERT INTO CLIENTES (
                    EMPNIT,DPI,NIT,NOMBRECLIENTE,DIRCLIENTE,CODMUNICIPIO,CODDEPARTAMENTO,TELEFONOCLIENTE,EMAILCLIENTE,ESTADOCIVIL,SEXO,
                    FECHANACIMIENTOCLIENTE,LATITUDCLIENTE,LONGITUDCLIENTE,CATEGORIA,CIUDADANIA,OCUPACION,CODRUTA,CALIFICACION,SALDO,FECHAINICIO,
                    HABILITADO,DIAVISITA,LIMITECREDITO,DIASCREDITO,PROVINCIA,TIPONEGOCIO,NEGOCIO,CODCLIE) 
                    VALUES 
                    (@EMPNIT,@DPI,@NIT,@NOMBRECLIENTE,@DIRCLIENTE,@CODMUNICIPIO,@CODDEPARTAMENTO,@TELEFONOCLIENTE,@EMAILCLIENTE,@ESTADOCIVIL,@SEXO,
                    @FECHANACIMIENTOCLIENTE,@LATITUDCLIENTE,@LONGITUDCLIENTE,@CATEGORIA,@CIUDADANIA,@OCUPACION,@CODRUTA,@CALIFICACION,@SALDO,@FECHAINICIO,
                    'SI',@DIAVISITA,@LIMITECREDITO,@DIASCREDITO,@PROVINCIA,@TIPONEGOCIO,@NEGOCIO,@CODCLIE)"
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@DPI", "SN")
                cmd.Parameters.AddWithValue("@NIT", Me.txtClientesNit.Text)
                cmd.Parameters.AddWithValue("@NOMBRECLIENTE", Me.txtClientesNombre.Text)
                cmd.Parameters.AddWithValue("@DIRCLIENTE", Me.txtClientesDireccion.Text)
                cmd.Parameters.AddWithValue("@CODMUNICIPIO", Integer.Parse(Me.cmbClientesMunicipio.SelectedValue))
                cmd.Parameters.AddWithValue("@CODDEPARTAMENTO", Integer.Parse(Me.cmbClientesDepartamento.SelectedValue))
                cmd.Parameters.AddWithValue("@TELEFONOCLIENTE", Me.txtClientesTelefonos.Text)
                cmd.Parameters.AddWithValue("@EMAILCLIENTE", Me.txtClientesEmail.Text)
                cmd.Parameters.AddWithValue("@ESTADOCIVIL", "SOLTERO-A")
                cmd.Parameters.AddWithValue("@SEXO", "OTROS")
                cmd.Parameters.AddWithValue("@FECHANACIMIENTOCLIENTE", Today.Date)
                cmd.Parameters.AddWithValue("@LATITUDCLIENTE", Me.lbClienteLat.Text)
                cmd.Parameters.AddWithValue("@LONGITUDCLIENTE", Me.lbClienteLong.Text)
                cmd.Parameters.AddWithValue("@CATEGORIA", "P") 'Me.cmbTipoPrecio.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CIUDADANIA", "SN")
                cmd.Parameters.AddWithValue("@OCUPACION", "Comerciante")
                cmd.Parameters.AddWithValue("@CODRUTA", 1) 'Integer.Parse(Me.cmbClientesRuta.SelectedValue))
                cmd.Parameters.AddWithValue("@CALIFICACION", "REGULAR")
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@FECHAINICIO", Today.Date)
                cmd.Parameters.AddWithValue("@DIAVISITA", Me.cmbClienteDiaVisita.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@LIMITECREDITO", 0)
                cmd.Parameters.AddWithValue("@DIASCREDITO", 0)
                cmd.Parameters.AddWithValue("@PROVINCIA", Me.txtClientesProvincia.Text)
                cmd.Parameters.AddWithValue("@TIPONEGOCIO", "OTROS") 'Me.cmbClienteTipoNegocio.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@NEGOCIO", Me.txtClienteNombreNegocio.Text)
                cmd.Parameters.AddWithValue("@CODCLIE", "1") 'Me.txtClientesCodclie.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                cn.Close()

                Call Form1.Mensaje("Cliente guardado exitosamente")
                Call CargarGridClientes()

                Me.txtClientesNit.Text = "CF"
                Me.txtClientesCodclie.Text = ""
                Me.cmbClienteDiaVisita.SelectedIndex = 0
                Me.cmbClienteTipoNegocio.SelectedIndex = 0
                Me.txtClienteNombreNegocio.Text = "SN"
                Me.txtClientesNombre.Text = ""
                Me.txtClientesDireccion.Text = ""
                Me.cmbClientesMunicipio.Text = ""
                Me.cmbClientesDepartamento.Text = ""
                Me.txtClientesTelefonos.Text = ""
                Me.txtClientesEmail.Text = ""
                Me.txtClientesProvincia.Text = "SN"
                Me.lbClienteLat.Text = "0"
                Me.lbClienteLong.Text = "0"
                Me.txtClientesNit.Enabled = True
                Me.cmdClientesCancelarEdit.Visible = False

                Me.txtClientesNit.select()
            End If

        Else
            Call Aviso("Importante", "Escriba el nombre del cliente", Me.ParentForm)
        End If
    End Sub

    Private Sub cmdClientesCancelarEdit_Click(sender As Object, e As EventArgs) Handles cmdClientesCancelarEdit.Click

        Me.txtClientesNit.Enabled = True
        Me.txtClienteNombreNegocio.Text = "SN"
        Me.cmbClienteTipoNegocio.SelectedIndex = 0
        Me.cmbClienteDiaVisita.SelectedIndex = 0
        Me.txtClientesProvincia.Text = "SN"

        Me.txtClientesNit.Text = ""
        Me.txtClientesNombre.Text = ""
        Me.txtClientesDireccion.Text = ""
        Me.cmbClientesMunicipio.Text = ""
        Me.cmbClientesDepartamento.Text = ""
        Me.txtClientesTelefonos.Text = ""
        Me.txtClientesEmail.Text = ""

        Me.txtClientesNit.Enabled = True

        Me.cmdClientesGuardar.Visible = True
        Me.cmdClientesCancelarEdit.Visible = False

        Me.FlyoutNuevoCliente.HidePopup()

    End Sub

    Private Sub ObtenerDatosCliente(ByVal CodClie As Integer)

        Call AbrirConexionSql()

        Dim cmd As New SqlCommand("SELECT CLIENTES.NIT, 
                                CLIENTES.NombreCliente, 
                                CLIENTES.DirCliente, 
                                CLIENTES.CodMunicipio, 
                                MUNICIPIOS.DESMUNICIPIO, 
                                CLIENTES.CodDepartamento, 
                                DEPARTAMENTOS.DESDEPARTAMENTO, 
                                CLIENTES.TelefonoCliente, 
                                CLIENTES.EmailCliente,
                                CLIENTES.PROVINCIA,
                                CLIENTES.CATEGORIA,
                                CLIENTES.TIPONEGOCIO, 
                                CLIENTES.NEGOCIO,
                                CLIENTES.DIAVISITA,
                                CLIENTES.LATITUDCLIENTE,
                                CLIENTES.LONGITUDCLIENTE,
                                CLIENTES.CODCLIE,
                                CLIENTES.CODRUTA
                        FROM CLIENTES LEFT OUTER JOIN DEPARTAMENTOS ON CLIENTES.CodDepartamento = DEPARTAMENTOS.CODDEPARTAMENTO LEFT OUTER JOIN
                        MUNICIPIOS ON CLIENTES.CodMunicipio = MUNICIPIOS.CODMUNICIPIO
                        WHERE CLIENTES.EMPNIT='" & GlobalEmpNit & "' AND CLIENTES.CodCliente = " & CodClie, cn)

        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            Me.txtClientesNit.Text = dr(0).ToString
            Me.txtClientesNombre.Text = dr(1).ToString
            Me.txtClientesDireccion.Text = dr(2).ToString
            Me.cmbClientesMunicipio.SelectedValue = Integer.Parse(dr(3).ToString)
            Me.cmbClientesMunicipio.Text = dr(4).ToString
            Me.cmbClientesDepartamento.SelectedValue = Integer.Parse(dr(5).ToString)
            Me.cmbClientesDepartamento.Text = dr(6).ToString
            Me.txtClientesTelefonos.Text = dr(7).ToString
            Me.txtClientesEmail.Text = dr(8).ToString
            Me.txtClientesProvincia.Text = dr(9).ToString
            Me.cmbTipoPrecio.SelectedValue = dr(10).ToString

            Me.cmbClienteTipoNegocio.SelectedValue = dr(11).ToString
            Me.txtClienteNombreNegocio.Text = dr(12).ToString
            Me.cmbClienteDiaVisita.SelectedValue = dr(13).ToString
            Me.lbClienteLat.Text = dr(14).ToString
            Me.lbClienteLong.Text = dr(15).ToString
            Me.txtClientesCodclie.Text = dr(16).ToString
            Me.cmbClientesRuta.SelectedValue = CType(dr(17), Integer)

        Catch ex As Exception
            MsgBox("No se pudieron cargar los datos del cliente. Error: " & ex.ToString)
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()

    End Sub

    Private Sub CargarMunicipiosDeptos()

        Call AbrirConexionSql()
        'VENDEDORES EN VENTAS
        Dim Dt6 As DataTable
        Dim Da6 As New SqlDataAdapter
        Dim Cmd6 As New SqlCommand
        With Cmd6
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODMUNICIPIO, DESMUNICIPIO FROM MUNICIPIOS"
            .Connection = cn
        End With
        Da6.SelectCommand = Cmd6
        Dt6 = New DataTable
        Da6.Fill(Dt6)

        With cmbClientesMunicipio
            .DataSource = Dt6
            .DisplayMember = "DESMUNICIPIO"
            .ValueMember = "CODMUNICIPIO"
        End With
        Cmd6.Dispose()

        'CARGA LOS DEPARTAMENTOS
        Dim Dt As DataTable
        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODDEPARTAMENTO, DESDEPARTAMENTO FROM DEPARTAMENTOS"
            .Connection = cn
        End With
        Da.SelectCommand = Cmd
        Dt = New DataTable
        Da.Fill(Dt)

        With cmbClientesDepartamento
            .DataSource = Dt
            .DisplayMember = "DESDEPARTAMENTO"
            .ValueMember = "CODDEPARTAMENTO"
        End With
        Cmd.Dispose()

        'TIPOS DE PRECIO
        Dim t As New DataTable
        t.Columns.Add("CODTIPOPRECIO", GetType(String))
        t.Columns.Add("DESTIPOPRECIO", GetType(String))

        With t.Rows
            .Add("P", "PUBLICO")
            .Add("A", "MAYOREO A")
            .Add("B", "MAYOREO B")
            .Add("C", "MAYOREO C")
        End With

        With Me.cmbTipoPrecio
            .DataSource = t
            .ValueMember = "CODTIPOPRECIO"
            .DisplayMember = "DESTIPOPRECIO"
        End With

        cn.Close()
    End Sub

    Public Sub CargarRutasClientes()
        Call AbrirConexionSql()
        'CARGA LAS RUTAS
        Dim Dt2 As DataTable
        Dim Da2 As New SqlDataAdapter
        Dim Cmd2 As New SqlCommand
        With Cmd2
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODRUTA, DESRUTA FROM RUTAS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODRUTA ASC"
            .Connection = cn
        End With
        Da2.SelectCommand = Cmd2
        Dt2 = New DataTable
        Da2.Fill(Dt2)

        With cmbClientesRuta
            .DataSource = Dt2
            .DisplayMember = "DESRUTA"
            .ValueMember = "CODRUTA"
        End With

        Cmd2.Dispose()
        cn.Close()
    End Sub

    Dim SelectedNomCliente As String, SelectedNitCliente As String


    Private Sub CargarGridClientes()
        Me.GridClientes.DataSource = Nothing

        Dim tbl As New DSGeneral.tblClientesDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim sql As String = "SELECT        CODCLIENTE, NIT, NOMBRECLIENTE, DIRCLIENTE, TELEFONOCLIENTE, EMAILCLIENTE
FROM            CLIENTES"
                Dim cmd As New SqlCommand(sql, cn)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
            End Try
        End Using

        Me.GridClientes.DataSource = tbl
        Me.GridClientes.Refresh()

    End Sub

    'RADIAL MENU CLIENTES

    Dim SelectedHabDesCliente As String


    Private Sub BarButtonItemClientesVerInfo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClientesVerInfo.ItemClick
        Call ObtenerDatosCliente(SelectedCode)
        Me.cmdClientesGuardar.Visible = False
        Me.cmdClientesCancelarEdit.Visible = True
        Me.FlyoutNuevoCliente.ShowPopup()
    End Sub

    Private Sub BarButtonItemClientesEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClientesEditar.ItemClick
        Call ObtenerDatosCliente(SelectedCode)
        'Me.txtClientesNit.Enabled = False
        Me.cmdClientesGuardar.Visible = True
        Me.cmdClientesCancelarEdit.Visible = True
        'Me.txtClientesNit.Enabled = False
        Me.FlyoutNuevoCliente.ShowPopup()
    End Sub

    Private Sub BarButtonItemClientesVentasMes_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClientesVentasMes.ItemClick

        Call AbrirReporte_VentasCliente(Today.Year, SelectedCode)

    End Sub

    Private Sub BarButtonItemClientesCalificar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClientesCalificar.ItemClick
        'EN VEZ DE CALIFICAR AL CLIENTE, CAMBIÉ ESTE EVENTO PARA HABILITAR O DESHABILITAR EL CLIENTE
        If Confirmacion("¿Está seguro que desea Habilitar/Deshabilitar este cliente?", Me.ParentForm) = True Then
            Call AbrirConexionSql()
            Dim sino As String
            If SelectedHabDesCliente = "SI" Then
                sino = "NO"
            Else
                sino = "SI"
            End If
            Dim cmd As New SqlCommand("UPDATE CLIENTES SET HABILITADO=@SINO WHERE EMPNIT=@EMPNIT AND CODCLIENTE=@CODCLIENTE", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@CODCLIENTE", SelectedCode)
            cmd.Parameters.AddWithValue("@SINO", sino)
            cmd.ExecuteNonQuery()
            Call CargarGridClientes()
            Me.GridClientes.select()
        End If
    End Sub

    Private Sub cmbTipoPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdClientesGuardar.select()
        End If

    End Sub

    Dim drw As DataRow

    Private Sub GridViewClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.RadialMenuClientes.ShowPopup(MousePosition)
        End If
    End Sub

    Private Sub GridViewClientes_DoubleClick(sender As Object, e As EventArgs) Handles GridViewClientes.DoubleClick
        Me.RadialMenuClientes.ShowPopup(MousePosition)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.txtClientesNit.Text = ""
        Me.txtClientesNombre.Text = ""
        Me.txtClientesDireccion.Text = ""
        Me.cmbClientesMunicipio.Text = ""
        Me.cmbClientesDepartamento.Text = ""
        Me.txtClientesTelefonos.Text = ""
        Me.txtClientesEmail.Text = ""
        Me.txtClientesProvincia.Text = ""
        Me.txtClientesNit.Enabled = True
        Me.cmdClientesCancelarEdit.Visible = False

        Me.FlyoutNuevoCliente.ShowPopup()
        Me.txtClientesNit.select()

    End Sub

    Private Sub viewClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.btnNuevo.PerformClick()
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.FlyoutNuevoCliente.HidePopup()
    End Sub

    Private Sub GridViewClientes_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewClientes.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewClientes.GetFocusedDataRow
            SelectedCode = CType(drw.Item(0), Integer)  'Integer.Parse(TileViewClientes.GetRowCellValue(hitInfo.RowHandle, "CODCLIENTE").ToString)
            SelectedNitCliente = drw.Item(1).ToString
            SelectedNomCliente = drw.Item(2).ToString 'TileViewClientes.GetRowCellValue(hitInfo.RowHandle, "NOMBRECLIENTE").ToString
            SelectedHabDesCliente = drw.Item(10).ToString 'TileViewClientes.GetRowCellValue(hitInfo.RowHandle, "HABILITADO").ToString
        Catch ex As Exception
            drw = Nothing
        End Try
    End Sub


    Private Sub BarButtonItemClientesEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemClientesEliminar.ItemClick
        If Confirmacion("¿Está seguro que desea eliminar este cliente?", Me.ParentForm) = True Then
            'Dim pass As String
            'pass = InputBox("Escriba la contraseña de autorizaciones", "Confirme")
            'If pass = Me.txtConfigClaveVerificaExistencia.Text Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                'Call Form1.EnviarNotificacionesEmail(0, "ARES te informa: Eliminación de cliente", "Se ha eliminado al cliente " & SelectedCode & "-" & SelectedNomCliente & " mediante el usuario= " & GlobalNomUsuario)
                Call AbrirConexionSql()
                Dim cmd As New SqlCommand("DELETE FROM CLIENTES WHERE CODCLIENTE=" & SelectedCode & " AND EMPNIT='" & GlobalEmpNit & "'", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                'elimina el registro de la tabla de saldos
                Dim cmd2 As New SqlCommand("DELETE FROM SALDOCLIENTES WHERE NITCLIENTE='" & SelectedNitCliente & "' AND EMPNIT='" & GlobalEmpNit & "'", cn)
                cmd2.ExecuteNonQuery()
                cmd2.Dispose()

                cn.Close()
                Call CargarGridClientes()
                'Call Form1.EnviarNotificacionesEmail(0, "ARES te informa: Eliminación de cliente", "El usuario " & GlobalNomUsuario & " ha eliminado al cliente " & SelectedCode & " - " & SelectedNomCliente)

            Else
                Call Aviso("No Autorizado", "Clave incorrecta, solicite autorización a su administrador", Me.ParentForm)
            End If
        End If
    End Sub


#End Region


    Private Sub BarButtonItemRptProductosRes_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemRptProductosRes.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewClientesRptParametros) = DialogResult.OK Then


            Dim objRpt As New ClassReports
            If objRpt.rptClientesProductosResumen(GlobalEmpNit, SelectedFechaInicial, SelectedFechaFinal, SelectedCode) = True Then
            Else
                MsgBox(GlobalDesError)
            End If

        End If



    End Sub

    Private Sub txtClientesCodclie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesCodclie.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbClienteTipoNegocio.select()
        End If
    End Sub

    Private Sub cmbClienteTipoNegocio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbClienteTipoNegocio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtClienteNombreNegocio.select()
        End If
    End Sub

    Private Sub txtClienteNombreNegocio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClienteNombreNegocio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtClientesNombre.select()
        End If
    End Sub

    Private Sub cmbClienteDiaVisita_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbClienteDiaVisita.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtClientesDireccion.select()
        End If
    End Sub

    Private Sub BarButtonItemRptProductosDetalle_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemRptProductosDetalle.ItemClick
        If FlyoutDialog.Show(Me.ParentForm, New viewClientesRptParametros) = DialogResult.OK Then

            Dim objRpt As New ClassReports
            If objRpt.rptClientesProductosDetalle(GlobalEmpNit, SelectedFechaInicial, SelectedFechaFinal, SelectedCode) = True Then
            Else
                MsgBox(GlobalDesError)
            End If

        End If

    End Sub

    Private Sub btnObtenerCenso_Click(sender As Object, e As EventArgs) Handles btnObtenerCenso.Click
        If FlyoutDialog.Show(Me.ParentForm, New viewOnlineClientesCenso()) = DialogResult.OK Then

        End If
    End Sub

    Private Sub txtClientesDireccion_Leave(sender As Object, e As EventArgs) Handles txtClientesDireccion.Leave
        Try
            Me.txtClientesDireccion.Text = cleanString(Me.txtClientesDireccion.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClientesProvincia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesProvincia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbClientesMunicipio.select()
        End If
    End Sub

    Private Sub CargarComboboxesGenerales()
        Dim objClie As New classClientes(GlobalEmpNit)

        With Me.cmbClienteTipoNegocio
            .DataSource = objClie.tblTipoNegocio
            .ValueMember = "COD"
            .DisplayMember = "COD"
        End With


        With Me.cmbClienteDiaVisita
            .DataSource = objClie.tblDiaSemana()
            .ValueMember = "DES"
            .DisplayMember = "DES"
        End With

    End Sub

End Class
