Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen

Public Class viewInterfaceSUP

    Private Sub viewInterfaceSUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GlobalNomEmpresa = Form1.cmbLoginEmpresa.Text
        GlobalNomUsuario = Form1.txtUser.Text

        Me.lbUSUARIO.Text = GlobalNomUsuario
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
            Case Else
                Call NAVEGAR(tag)

        End Select

    End Sub

    Private Sub btnOnlineDomicilio_Click(sender As Object, e As EventArgs) Handles btnOnlineDomicilio.Click
        Call NAVEGAR("DOMICILIO")
    End Sub

    Private Sub btnOnlinePlantilla_Click(sender As Object, e As EventArgs)

        Call NAVEGAR("PLANTILLAPRODUCTOS")
        'Call NAVEGAR("ONLINE_PRECIOS_SUCURSALES")
    End Sub

    Private Sub btnMenuUpdateInventario_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs)
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

    Private Sub btnOnlinePedidosVentas_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("ONLINE_PREVENTAS")
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

    Private Sub TileControl1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileControl1.ItemClick
        Dim tag As String = ""
        Try
            tag = e.Item.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)

    End Sub

    Private Sub btnNavDocumentos_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs)
        Call NAVEGAR("DOCUMENTOS")
    End Sub

    Private Sub btnNavReportes_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs)
        Call NAVEGAR("REPORTES")
    End Sub

    Private Sub TileItemRVTYO_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPORTS.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewRPTVO) = DialogResult.OK Then
        End If

    End Sub

    Private Sub TileItemBONOS_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemBONOS.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewBONOS) = DialogResult.OK Then
        End If

    End Sub

    Private Sub btnMenuAutocertificarFEL_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs)

        If Confirmacion("Esta a punto de certificar las facturas que quedaron en contingencia, ¿desea continuar?", Me.ParentForm) = True Then

            Dim FEL As New classFEL
            Form1.Mensaje("Iniciando auto certificación FEL")

            FEL.autoCertificacionFEL()

            Form1.Mensaje("Finalizando auto certificación FEL")

        End If

    End Sub

    Private Sub TileItemCERTIFICAR_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemCERTIFICAR.ItemClick

        If Confirmacion("Esta a punto de certificar las facturas que quedaron en contingencia, ¿desea continuar?", Me.ParentForm) = True Then

            Dim FEL As New classFEL
            Form1.Mensaje("Iniciando auto certificación FEL")

            FEL.autoCertificacionFEL()

            Form1.Mensaje("Finalizando auto certificación FEL")

        End If

    End Sub

    Private Sub cargardgvDocprodsCorte()

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        Me.gridExports1.DataSource = Nothing
        Me.gridExports1.DataSource = objS.TblMovinCorte()
        Try
            Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\DOCPRODUCTOS_CORTES.xlsx")
            Process.Start(Application.StartupPath + "\EXPORTS\DOCPRODUCTOS_CORTES.xlsx")

        Catch ex As Exception
            MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:  " & ex.ToString)
        End Try
        Me.gridExports1.DataSource = Nothing

    End Sub

    Private Sub cargardgvAuditCortes()

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        Me.gridExports2.DataSource = Nothing
        Me.gridExports2.DataSource = objS.TblAuditCortes()
        Try
            Me.gridExports2.ExportToXlsx(Application.StartupPath + "\EXPORTS\AUDITCORTES.xlsx")
            Process.Start(Application.StartupPath + "\EXPORTS\AUDITCORTES.xlsx")

        Catch ex As Exception
            MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error: " & ex.ToString)
        End Try
        Me.gridExports2.DataSource = Nothing

    End Sub

    Private Sub TileItemRepCortes_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemRepCortes.ItemClick

        Call cargardgvDocprodsCorte()
        Call cargardgvAuditCortes()

    End Sub

    Private Sub btnOnlineGetProductosPrecio_Click(sender As Object, e As EventArgs) Handles btnOnlineGetProductosPrecio.Click
        Call NAVEGAR("SYNCPRECIOS")
    End Sub

    Private Sub btnACTINV_Click(sender As Object, e As EventArgs) Handles btnACTINV.Click
        Call NAVEGAR("ACTINV")
    End Sub

    Private Sub TileItem9_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem9.ItemClick

    End Sub

    Private Sub TileControl1_Click(sender As Object, e As EventArgs) Handles TileControl1.Click

    End Sub
End Class
