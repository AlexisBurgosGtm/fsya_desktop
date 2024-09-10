Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class viewInterfaceGARMEN
#Region "LOAD"

    Private Sub viewInterfaceNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GlobalNomEmpresa = Form1.cmbLoginEmpresa.Text

        Me.lbEMPRESA.Text = GlobalNomEmpresa

    End Sub

    Private Sub TileNavPaneMain_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles TileNavPane1.ElementClick

        Dim tag As String
        Try
            tag = e.Element.Tag.ToString
        Catch ex As Exception
            tag = ""
        End Try

        Select Case tag


            Case "ONLINE"
                Me.FlyoutPanelOnline.ShowPopup()

            Case Else
                Call NAVEGAR(tag)

        End Select

    End Sub

    Private Sub btnSyncDashboardVentas_Click(sender As Object, e As EventArgs) Handles btnSyncDashboardVentas.Click
        If Confirmacion("Está seguro que desea iniciar la sincronización?", Me.ParentForm) = True Then
            If Form1.BackgroundWorkerSync.IsBusy = False Then
                Form1.BackgroundWorkerSync.RunWorkerAsync()
            End If
        End If

    End Sub

    Private Sub AccordionControlMenuGeneral_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.ElementClickEventArgs) Handles AccordionControlMenuGeneral.ElementClick
        Dim tag As String = ""
        Try
            tag = e.Element.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)
    End Sub

    Private Sub TileControl1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileControl1.ItemClick
        Dim tag As String = ""
        Try
            tag = e.Item.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)

    End Sub

#End Region

#Region "NAVEGAR"

    Private Sub btnOnlineDomicilio_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("DOMICILIO")
    End Sub

#End Region

#Region "LOCALES"

    Private Sub btnMenuUpdateInventario_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        If Confirmacion("Está seguro que desea Actualizar el Inventario, puede tardar unos minutos?", Me.ParentForm) = True Then

            Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

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
    End Sub

    Private Sub btnCERTIFICAR_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles btnCERTIFICAR.ItemClick

        If Confirmacion("Esta a punto de certificar las facturas que quedaron en contingencia, ¿desea continuar?", Me.ParentForm) = True Then

            Dim FEL As New classFEL
            Form1.Mensaje("Iniciando auto certificación FEL")

            FEL.autoCertificacionFEL()

            Form1.Mensaje("Finalizando auto certificación FEL")

        End If

    End Sub

    Private Sub btnSubirVentasConta_Click(sender As Object, e As EventArgs) Handles btnSubirVentasConta.Click

        If Confirmacion("¿Está seguro que desea Subir los Documentos?", Me.ParentForm) = True Then
            If FlyoutDialog.Show(Me.ParentForm, New viewParamMesAnio) = DialogResult.OK Then
                Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

                SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                    'sincronizando inventario, productos y precios
                    If objS.fcnDeleteDocumentosContables(GlobalEmpNit, GlobalParamAnio, GlobalParamMes) = True Then
                        'SUBIENDO DOCUMENTOS
                        If objS.fcnSendDocumentosContables(GlobalParamAnio, GlobalParamMes, GlobalEmpNit) = True Then
                        Else
                            Call Form1.Mensaje("Error al sincronizar " & objS.DesError.ToString)
                        End If
                    Else
                        Call Form1.Mensaje("Error a limpiar datos anteriores")
                    End If
                    Call Form1.Mensaje("Sincronización finalizada")

                    SplashScreenManager.CloseForm()

            End If

        End If

    End Sub


    Private Sub btnMenu_Click(sender As Object, e As EventArgs)
        If NivelUsuario = 1 Then
            Me.FlyoutMenu.ShowPopup()
        Else
            MsgBox("Usted no tiene acceso al menú general")
        End If

    End Sub

#End Region
End Class
