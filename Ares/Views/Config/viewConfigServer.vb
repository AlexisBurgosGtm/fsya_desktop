Imports Microsoft.Win32
Imports Security.Seguridad
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewConfigServer
    Private Sub viewConfigServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call LeerDatosServer()
        Call getDataFEL()
        Call CargarDatosToken()

    End Sub

    'FEL
    '-----------------
    Private Sub getDataFEL()
        Dim objFel As New classFEL
        'objFel.CargarDatosClienteFEL()

        Me.txtFELCertificacionUsuario.Text = objFel.GlobalCertificacionUsuario
        Me.txtFELCertificacionLlave.Text = objFel.GlobalCertificacionLlave
        Me.txtFELFirmaAlias.Text = objFel.GlobalFirmaAlias
        Me.txtFELFirmaLlave.Text = objFel.GlobalFirmaLlave
        Me.txtFELEmisorCodigoEstablecimiento.Text = objFel.GlobalCodigoEstablecimientoEmisor.ToString
        Me.txtFELEmisorCodigoPostal.Text = objFel.GlobalCodigoPostalEmmisor
        Me.txtFELEmisorDepartamento.Text = objFel.GlobalDepartamentoEmisor
        Me.txtFELEmisorMunicipio.Text = objFel.GlobalMunicipioEmisor
        Me.txtFELEmisorDireccion.Text = objFel.GlobalDireccionEmisor
        Me.txtFELEmisorNombre.Text = objFel.GlobalNombreEmisor
        Me.txtFELEmisorNombreComercial.Text = objFel.GlobalNombreComercialEmisor
        Me.txtFELEmisorNit.Text = objFel.GlobalNitEmisor
        Me.txtFELEmisorFrase.Text = objFel.GlobalFraseFEL.ToString
        Me.txtFELEmisorEscenario.Text = objFel.GlobalEscenarioFEL.ToString
        Me.txtFELEmisorFrase2.Text = objFel.GlobalFraseFEL2.ToString
        Me.txtFELEmisorEscenario2.Text = objFel.GlobalEscenarioFEL2.ToString

    End Sub

    'SERVER
    '-----------------------
    Dim sc As New Security.Seguridad("razors1805")

    Private Sub LeerDatosServer()

        Try
            Dim localdb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "LocalDb", Nothing).ToString
            Dim server = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "server", Nothing).ToString
            Dim db = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "db", Nothing).ToString
            Dim user = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "user", Nothing).ToString
            Dim pass = sc.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "pass", Nothing).ToString)

            Me.txtServer.Text = server
            Me.txtDb.Text = db
            Me.txtUser.Text = user
            Me.txtPass.Text = pass

            If localdb = "SI" Then
                Me.SwitchLocalDb.IsOn = True
                strSqlConectionString = "Server=(localdb)\v11.0;Integrated Security=true;attachDbFileName=" + Application.StartupPath + "\SYNC\ARES.mdf;MultipleActiveResultSets=True"
            Else
                Me.SwitchLocalDb.IsOn = False
                strSqlConectionString = "Data Source=" & server & ";Initial Catalog=" & db & ";User ID=" & user & ";Password=" & pass & ";MultipleActiveResultSets=True"
            End If

        Catch ex As Exception
            If MsgBox("¿Desea crear la conexión al servidor?", MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                If fcnCreateConnection() = True Then
                    MsgBox("Path creada exitosamente, por favor, cierre y vuelva a abrir el sistema")
                Else
                    MsgBox("No se pudo crear el path")
                End If
            Else
                Me.txtServer.Text = ""
                Me.txtDb.Text = ""
                Me.txtUser.Text = ""
                Me.txtPass.Text = ""
            End If

        End Try

    End Sub

    Private Function fcnCreateConnection() As Boolean
        Dim result As Boolean

        Try
            Dim server = "Software\POS\OnnePOS\Server"
            Dim cliente = "Software\POS\OnnePOS\Client"

            Registry.CurrentUser.CreateSubKey(server)
            Registry.CurrentUser.CreateSubKey(cliente)

            Dim keyS As RegistryKey = Registry.CurrentUser.OpenSubKey(server, True) ' True indica que se abre para escritura
            keyS.SetValue("server", ".\SQLEXPRESS", RegistryValueKind.String)
            keyS.SetValue("LocalDb", "NO", RegistryValueKind.String)
            keyS.SetValue("db", "ONNE", RegistryValueKind.String)
            keyS.SetValue("user", "iEx", RegistryValueKind.String)
            keyS.SetValue("pass", "P5IzDpvfgus=", RegistryValueKind.String)
            keyS.Close()

            Dim keyC As RegistryKey = Registry.CurrentUser.OpenSubKey(cliente, True) ' True indica que se abre para escritura

            keyC.SetValue("modopos", "NO", RegistryValueKind.String)
            keyC.SetValue("hora", "SI", RegistryValueKind.String)
            keyC.SetValue("recordatorios", "NO", RegistryValueKind.String)
            keyC.SetValue("urlfront", "C:\\CommunityMarket\\web\\index.html", RegistryValueKind.String)
            keyC.Close()

            result = True

        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim KeyPath As String = "Software\POS\OnnePOS\Server"

            Dim server As String = "server"
            Dim db As String = "db"
            Dim user As String = "user"
            Dim pass As String = "pass"

            Dim dblocal As String
            If Me.SwitchLocalDb.IsOn = True Then
                dblocal = "SI"
            Else
                dblocal = "NO"
            End If

            Registry.CurrentUser.CreateSubKey(KeyPath)

            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(KeyPath, True) ' True indica que se abre para escritura

            key.SetValue("LocalDb", dblocal, RegistryValueKind.String)

            key.SetValue(server, Me.txtServer.Text, RegistryValueKind.String)
            key.SetValue(db, Me.txtDb.Text, RegistryValueKind.String)
            key.SetValue(user, Me.txtUser.Text, RegistryValueKind.String)
            key.SetValue(pass, sc.EncryptData(Me.txtPass.Text), RegistryValueKind.String)

            If dblocal = "SI" Then
                strSqlConectionString = "Server=(localdb)\v11.0;Integrated Security=true;attachDbFileName=" + Application.StartupPath + "\SYNC\ARES.mdf;MultipleActiveResultSets=True"
            Else
                strSqlConectionString = "Data Source=" & Me.txtServer.Text & ";Initial Catalog=" & Me.txtDb.Text & ";User ID=" & Me.txtUser.Text & ";Password=" & Me.txtPass.Text & ";MultipleActiveResultSets=True"
            End If

            MessageBox.Show("Datos Actualizados Exitosamente")

        Catch ex As Exception
            MessageBox.Show("No se pudo actualizar los datos del servidor" & ex.ToString)
        End Try

    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim server = Me.txtServer.Text
        Dim db = Me.txtDb.Text
        Dim user = Me.txtUser.Text
        Dim pass = Me.txtPass.Text

        Dim str As String = "Data Source=" & server & ";Initial Catalog=" & db & ";User ID=" & user & ";Password=" & pass & ";MultipleActiveResultSets=True"
        Using cn As New SqlClient.SqlConnection(str)
            Try
                cn.Open()
                cn.Close()
                MsgBox("Conexión realizada con éxito")
            Catch ex As Exception
                MsgBox("La conexión falló. Error: " & ex.ToString)
            End Try
        End Using

    End Sub

    Private Sub SwitchLocalDb_Toggled(sender As Object, e As EventArgs) Handles SwitchLocalDb.Toggled
        If Me.SwitchLocalDb.IsOn = True Then
            Call BloquearControles(False)
        Else
            Call BloquearControles(True)
        End If
    End Sub

    Private Sub BloquearControles(ByVal sino As Boolean)
        Me.txtServer.Enabled = sino
        Me.txtDb.Enabled = sino
        Me.txtUser.Enabled = sino
        Me.txtPass.Enabled = sino
        Me.btnTest.Enabled = sino
    End Sub

    Private Sub btnCrearPath_Click(sender As Object, e As EventArgs) Handles btnCrearPath.Click
        If fcnCreateConnection() = True Then
            MsgBox("Path creada exitosamente, por favor, cierre y vuelva a abrir el sistema")
        Else
            MsgBox("No se pudo crear el path")
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Form1.iniciarRutinasConConexion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnFELGuardar_Click(sender As Object, e As EventArgs) Handles btnFELGuardar.Click
        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave("razors1805")) = DialogResult.OK Then
            If Confirmacion("¿Está seguro que desea actualizar las credenciales FEL?", Me.ParentForm) = True Then
                Dim objf As New classFEL()
                If objf.editCredenciales(
                        Me.txtFELCertificacionUsuario.Text, Me.txtFELCertificacionLlave.Text,
                        Me.txtFELFirmaAlias.Text, Me.txtFELFirmaLlave.Text,
                        Me.txtFELEmisorCodigoEstablecimiento.Text, Me.txtFELEmisorCodigoPostal.Text,
                        Me.txtFELEmisorDepartamento.Text, Me.txtFELEmisorDireccion.Text, Me.txtFELEmisorMunicipio.Text,
                        Me.txtFELEmisorNombre.Text, Me.txtFELEmisorNombreComercial.Text, Me.txtFELEmisorNit.Text,
                        Integer.Parse(Me.txtFELEmisorFrase.Text), Integer.Parse(Me.txtFELEmisorEscenario.Text),
                        Integer.Parse(Me.txtFELEmisorFrase2.Text), Integer.Parse(Me.txtFELEmisorEscenario2.Text)
                    ) = True Then
                    MsgBox("Datos actualizados exitosamente !!")
                Else
                    MsgBox("No se pudieron actualizar las credenciales, por favor rectifique")
                End If
            End If
        End If

    End Sub




    Dim objToken As New classToken

    Private Sub CargarDatosToken()

        objToken.getDataToken()

        Me.txtTokenToken.Text = objToken.token
        Me.txtTokenHost.Text = objToken.host
        Me.txtTokenDb.Text = objToken.db
        Me.txtTokenUser.Text = objToken.user
        Me.txtTokenPass.Text = objToken.pass
        Me.txtTokenIntervalo.Text = objToken.intervalo.ToString

    End Sub

    Private Sub btnTokenGuardar_Click(sender As Object, e As EventArgs) Handles btnTokenGuardar.Click

        If Me.txtTokenToken.Text <> "" Then
        Else
            Me.txtTokenToken.Text = "SN"
        End If

        If Me.txtTokenHost.Text <> "" Then
        Else
            Me.txtTokenHost.Text = "SN"
        End If

        If Me.txtTokenDb.Text <> "" Then
        Else
            Me.txtTokenDb.Text = "SN"
        End If

        If Me.txtTokenUser.Text <> "" Then
        Else
            Me.txtTokenUser.Text = "SN"
        End If

        If Me.txtTokenPass.Text <> "" Then
        Else
            Me.txtTokenPass.Text = "SN"
        End If

        If Me.txtTokenIntervalo.Text <> "" Then
        Else
            Me.txtTokenIntervalo.Text = "0"
        End If

        If objToken.update_dataToken(Me.txtTokenToken.Text, Me.txtTokenHost.Text, Me.txtTokenDb.Text, Me.txtTokenUser.Text, Me.txtTokenPass.Text, Integer.Parse(Me.txtTokenIntervalo.Text)) = True Then
            MsgBox("Token actualizado con éxito")
            If getToken() = True Then

            End If
        End If



    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        If getConfirmacion("¿Está seguro que desea crear la tabla TOKEN?") = True Then

            objToken.create_dataToken()

            MsgBox("Tabla creada con éxito")

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub txtServer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtServer.SelectedIndexChanged

    End Sub
End Class
