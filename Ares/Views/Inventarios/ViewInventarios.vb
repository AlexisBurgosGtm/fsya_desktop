Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen

Public Class ViewInventarios

    Private Sub cmdInventariosImprimir_Click(sender As Object, e As EventArgs) Handles cmdInventariosImprimir.Click
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
            Call AbrirReportINVENTARIO(Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue))
        End If
    End Sub

    Private Sub cmdInventariosPorMarca_Click(sender As Object, e As EventArgs) Handles cmdInventariosPorMarca.Click
        If Me.cmbInventariosMarca.SelectedIndex >= 0 Then
            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
                Call AbrirReportInventarioMarca(Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue), Me.cmbInventariosMarca.SelectedValue)
            End If
        Else
            Call Aviso("Importante", "Debe seleccionar una marca para ver su inventario", Me.ParentForm)
        End If
    End Sub

    Private Sub cmdInventariosClaseUno_Click(sender As Object, e As EventArgs) Handles cmdInventariosClaseUno.Click
        If Me.cmbInventariosClaseUno.SelectedIndex >= 0 Then
            Call AbrirReporte_InventarioClasificacion(Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue), 1, Me.cmbInventariosClaseUno.SelectedValue)
        Else
            Call Aviso("Importante", "Debe seleccionar una Clasificación Uno para ver su inventario", Me.ParentForm)
        End If

    End Sub

    Private Sub cmdInventariosClaseDos_Click(sender As Object, e As EventArgs) Handles cmdInventariosClaseDos.Click
        If Me.cmbInventariosClaseDos.SelectedIndex >= 0 Then
            Call AbrirReporte_InventarioClasificacion(Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue), 2, Me.cmbInventariosClaseDos.SelectedValue)
        Else
            Call Aviso("Importante", "Debe seleccionar una Clasificación Dos para ver su inventario", Me.ParentForm)
        End If
    End Sub

    Private Sub cmdInventariosClaseTres_Click(sender As Object, e As EventArgs) Handles cmdInventariosClaseTres.Click
        If Me.cmbInventariosClaseTres.SelectedIndex >= 0 Then
            Call AbrirReporte_InventarioClasificacion(Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue), 3, Me.cmbInventariosClaseTres.SelectedValue)
        Else
            Call Aviso("Importante", "Debe seleccionar una Clasificación Tres para ver su inventario", Me.ParentForm)
        End If

    End Sub

    Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
    Private Sub cmdInventariosCerrarMes_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles cmdInventariosCerrarMes.ItemClick

        Call Aviso("AVISO", "Estamos remodelando esta opción, esperela en una próxima actualización", Me.ParentForm)

        Exit Sub


        If objInventarios.fcn_VerificarCierreInventario = 2 Then

            If Confirmacion("¿Está seguro que desea cerrar el mes en proceso, esto podría perjudicar su inventario si no se realiza adecuadamente?", Me.ParentForm) = True Then

                If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then


                    If CerrarMesProceso() = True Then
                        'si se cierra el mes, inserto el registro para que no se pueda repetir
                        objInventarios.fcn_InsertarCierreInventario()

                        Call Form1.Mensaje("Mes cerrado exitosamente")
                    Else
                        Call Form1.Mensaje("No se pudo cerrar el mes")
                    End If

                End If



            End If
        Else
            Call Aviso("NO PERMITIDO", "Ya se realizó un cierre con estos parámetros (Empresa, mes y año)", Me.ParentForm)
        End If
    End Sub


    Private Function CerrarMesProceso() As Boolean

        Try
            SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim NuevoMesInt As Integer, NuevoAnioInt As Integer

            NuevoAnioInt = Integer.Parse(Form1.cmdAnioProceso.Text)
            NuevoMesInt = Integer.Parse(Form1.cmdMesProceso.SelectedValue)

            Dim ViejoAnio, ViejoMes As Integer
            ViejoAnio = Integer.Parse(Form1.cmdAnioProceso.Text)
            ViejoMes = Integer.Parse(Form1.cmdMesProceso.SelectedValue)

            If NuevoMesInt = 12 Then
                NuevoMesInt = 1
                NuevoAnioInt = NuevoAnioInt + 1
            Else
                NuevoMesInt = NuevoMesInt + 1
            End If

            'Actualiza el registro en la tabla de empresas
            Call AbrirConexionSql()

            Dim cmd As New SqlCommand("UPDATE EMPRESAS SET EMPMESPROCESO=@NUEVOMES, EMPANIOPROCESO=@NUEVOANIO WHERE EMPNIT='" & GlobalEmpNit & "'", cn)
            cmd.Parameters.AddWithValue("@NUEVOMES", NuevoMesInt)
            cmd.Parameters.AddWithValue("@NUEVOANIO", NuevoAnioInt)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            'regreso al login
            NAVEGAR("LOGIN")
            Form1.NP_GENERAL.Controls.Remove(Form1.CtrlGeneral)
            Form1.CtrlGeneral = Nothing

            Try
                Form1.NP_Login.BackgroundImage = Image.FromFile(GlobalPathFondo)
            Catch ex As Exception
            End Try

            Form1.cmdAnioProceso.Text = NuevoAnioInt.ToString
            Form1.cmdMesProceso.SelectedIndex = NuevoMesInt - 1

            'Cargo los nuevos registros en la tabla de INVSALDO
            Dim cmdInvSaldo As New SqlCommand("SELECT CODPROD, SALDO FROM INVSALDO WHERE EMPNIT='" & GlobalEmpNit & "' AND ANIO=" & ViejoAnio & " AND MES=" & ViejoMes, cn)
            Dim dr As SqlDataReader
            dr = cmdInvSaldo.ExecuteReader

            Do While dr.Read
                Dim cmdNuevoInventario As New SqlCommand("INSERT INTO INVSALDO (EMPNIT,ANIO,MES,CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO) VALUES (@EMPNIT,@ANIO,@MES,@CODPROD,@SALDOINICIAL,0,0,@SALDO)", cn)
                cmdNuevoInventario.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdNuevoInventario.Parameters.AddWithValue("@ANIO", NuevoAnioInt)
                cmdNuevoInventario.Parameters.AddWithValue("@MES", NuevoMesInt)
                cmdNuevoInventario.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                cmdNuevoInventario.Parameters.AddWithValue("@SALDOINICIAL", Integer.Parse(dr(1)))
                cmdNuevoInventario.Parameters.AddWithValue("@SALDO", Integer.Parse(dr(1)))
                cmdNuevoInventario.ExecuteNonQuery()
                cmdNuevoInventario.Dispose()
            Loop
            dr.Close()
            cmdInvSaldo.Dispose()
            cn.Close()
            'faltaria la rutina para cerrar el saldo de las cuentas por cobrar y pagar


            SplashScreenManager.CloseForm()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function



    '  Private Sub TileInventarioFisico_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileInventarioFisico.ItemClick

    'Call Aviso("NO DISPONIBLE", "Esta opción está deshabilitada por el momento", Me.ParentForm)
    'Exit Sub

    '   Form1.NavigationFrame1.SelectedPage = Form1.NP_MovInv
    '  SelectedForm = "INVFISICO"
    ' Form1.txtMovInvTipo.Text = "Inventario Físico"
    'Call Form1.CargarDGVListaProductos(1)
    'Call CargarCorrelativoVentas()
    'Call CargarGridTempVentas()
    'Call CargarTotalVenta("INVFISICO", Double.Parse(Form1.txtMovInvCorrelativo.Text))

    'End Sub



    Private Sub ViewInventarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CargarCombobox()
    End Sub

    Private Sub CargarCombobox()

        Call AbrirConexionSql()

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

        With cmbInventariosMarca
            .DataSource = Dt
            .DisplayMember = "DESMARCA"
            .ValueMember = "CODMARCA"
        End With

        'CLASIFICACION UNO
        Dim Dt1 As DataTable
        Dim Da1 As New SqlDataAdapter
        Dim Cmd1 As New SqlCommand
        With Cmd1
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODCLAUNO, DESCLAUNO FROM CLASIFICACIONUNO  WHERE EMPNIT='" & GlobalEmpNit & "'"
            .Connection = cn
        End With
        Da1.SelectCommand = Cmd1
        Dt1 = New DataTable
        Da1.Fill(Dt1)

        With cmbInventariosClaseUno
            .DataSource = Dt1
            .DisplayMember = "DESCLAUNO"
            .ValueMember = "CODCLAUNO"
        End With

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

        With cmbInventariosClaseDos
            .DataSource = Dt2
            '.DisplayMember = "DESCLADOS"
            '.ValueMember = "CODCLADOS"
            .DisplayMember = "EMPRESA"
            .ValueMember = "CODPROV"
        End With

        'CLASIFICACION TRES
        Dim Dt3 As DataTable
        Dim Da3 As New SqlDataAdapter
        Dim Cmd3 As New SqlCommand
        With Cmd3
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODCLATRES, DESCLATRES FROM CLASIFICACIONTRES  WHERE EMPNIT='" & GlobalEmpNit & "'"
            .Connection = cn
        End With
        Da3.SelectCommand = Cmd3
        Dt3 = New DataTable
        Da3.Fill(Dt3)

        With cmbInventariosClaseTres
            .DataSource = Dt3
            .DisplayMember = "DESCLATRES"
            .ValueMember = "CODCLATRES"
        End With


        cn.Close()

    End Sub


    Private Sub btnActualizar_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles btnActualizar.ItemClick

        If Confirmacion("¿Está seguro que desea Actualizar el inventario del mes Actual?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                Dim result As String

                SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                If objInventarios.fcn_ActualizarInventarioMes("mes") = True Then
                    Call Form1.Mensaje("Existencias actualizadas exitosamente")
                    result = "Existencias actualizadas exitosamente"
                Else
                    result = "Lo siento, sucedió algo y no pude actualizar el inventario. Error: " & GlobalDesError
                End If

                SplashScreenManager.CloseForm()

                MsgBox(result)

            End If

        End If

    End Sub

    Private Sub btnExistenciasCero_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles btnExistenciasCero.ItemClick
        If Confirmacion("¿Está seguro que desea dejar las existencias a CERO?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                If objInventarios.fcn_existencias_cero = True Then
                    Call Form1.Mensaje("Existencias actualizadas exitosamente")
                End If

                SplashScreenManager.CloseForm()

            End If

        End If


    End Sub

    Private Sub btnResetInventory_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles btnResetInventory.ItemClick
        If Confirmacion("Se realizará un recuento de inventario desde el inicio. ¿Desea continuar?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim result As String
                If objInventarios.fcn_existencias_cero = True Then

                    If objInventarios.fcn_ActualizarInventarioMes("anio") = True Then
                        result = "Actualización completada exitosamente"
                    Else
                        result = "Algo salió mal. Error: " & GlobalDesError
                    End If

                End If
                SplashScreenManager.CloseForm()

                MsgBox(result.ToString)

            End If

        End If

    End Sub

    Private Sub cmdInventariosImprimirEXCEL_Click(sender As Object, e As EventArgs) Handles cmdInventariosImprimirEXCEL.Click
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            Me.gridExports.DataSource = Nothing
            Me.gridExports.DataSource = TBLReportINVENTARIO(GlobalAnioProceso, GlobalMesProceso)
            Try
                Me.gridExports.ExportToXlsx(Application.StartupPath + "\EXPORTS\InventarioGeneral.xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\InventarioGeneral.xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error: " & ex.ToString)
            End Try

        End If
    End Sub

    Private Sub TileVencimientos_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileVencimientos.ItemClick
        Call NAVEGAR("INVVENCIDOS")
    End Sub

    Private Sub TileMinimos_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileMinimos.ItemClick
        Call NAVEGAR("INVMINIMOS")
    End Sub
End Class
