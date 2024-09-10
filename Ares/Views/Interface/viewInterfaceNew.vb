Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewInterfaceNew

#Region "LOAD"

    Private Sub viewInterfaceNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.TileItemINV.Visible = False

        'Dim objtiposuc As New tipoSUC.tipoSuc
        'GlobalTipoSistema = objtiposuc.tiposuc

        If GlobalTipoSistema = 1 Then

        Else

            Me.TileNavPane1.BackColor = Color.Black

        End If

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

    Private Sub btnOnlineDomicilio_Click(sender As Object, e As EventArgs) Handles btnOnlineDomicilio.Click
        Call NAVEGAR("DOMICILIO")
    End Sub

    Private Sub btnOnlinePreventa_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("SYNC2")
    End Sub

    Private Sub btnOnlineGetProductos_Click(sender As Object, e As EventArgs) Handles btnOnlineGetProductos.Click
        Call NAVEGAR("SYNCPRODUCTOS")
    End Sub

    Private Sub btnOnlineGetProductosPrecios_Click(sender As Object, e As EventArgs) Handles btnOnlineGetProductosPrecios.Click
        Call NAVEGAR("SYNCPRECIOS")
    End Sub

    Private Sub btnOnlineGetInventarios_Click(sender As Object, e As EventArgs) Handles btnOnlineGetInventarios.Click
        Call NAVEGAR("INVENTARIO_ONLINE")
    End Sub

    Private Sub btnOnlineGetCortes_Click(sender As Object, e As EventArgs) Handles btnOnlineGetCortes.Click
        Call NAVEGAR("CORTES_ONLINE")
    End Sub

    Private Sub btnOnlineVentas_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("VENTAS_ONLINE")
    End Sub

    Private Sub btnOnlinePlantilla_Click(sender As Object, e As EventArgs) Handles btnOnlinePlantilla.Click

        Call NAVEGAR("PLANTILLAPRODUCTOS")

    End Sub

    Private Sub btnOnlineVentasDomicilio_Click(sender As Object, e As EventArgs) Handles btnOnlineVentasDomicilio.Click

        Call NAVEGAR("VENTAS_DOMICILIO")
    End Sub

    Private Sub btnOnlinePedidosVentas_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("ONLINE_PREVENTAS")
    End Sub

    Private Sub btnOnlineDocsConta_Click(sender As Object, e As EventArgs) Handles btnOnlineDocsConta.Click
        Call NAVEGAR("DOCUMENTOS_ONLINE")
    End Sub

    Private Sub btnNavDocumentos_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles btnNavDocumentos.ElementClick
        Call NAVEGAR("DOCUMENTOS")
    End Sub

    Private Sub btnNavReportes_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles btnNavReportes.ElementClick
        Call NAVEGAR("REPORTES")
    End Sub

    Private Sub imgEMPSYNC_DoubleClick(sender As Object, e As EventArgs) Handles imgEMPSYNC.DoubleClick
        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave("razors1805")) = DialogResult.OK Then
            Call NAVEGAR("EMPRESAS_SYNC")
        End If
    End Sub

#End Region

#Region "LOCALES"

    Private Sub btnMenuAutocertificarFEL_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles btnMenuAutocertificarFEL.ElementClick, NavButton2.ElementClick
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


    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        If NivelUsuario = 1 Then
            Me.FlyoutMenu.ShowPopup()
        Else
            MsgBox("Usted no tiene acceso al menú general")
        End If

    End Sub

    Private Sub TileItemRVTYO_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPORTS.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewRPTVO) = DialogResult.OK Then

        End If

    End Sub

    Private Sub TileItemCONT_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemCONT.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewREPCONTA) = DialogResult.OK Then

        End If

    End Sub

    Private Sub TileItemREPBONO_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPBONO.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewBONOS) = DialogResult.OK Then

        End If

    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick

        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave("razors1805")) = DialogResult.OK Then
            Call NAVEGAR("SERVIDORES")
        End If

    End Sub

    Private Sub TileItem4_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem4.ItemClick
        If FlyoutDialog.Show(Me.ParentForm, New viewINSERTREPORTS) = DialogResult.OK Then

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call NAVEGAR("SYNCPRECIOS2")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        If objS.fcnSendCortesT(GlobalEmpNit) = True Then
            'Dim obgen As New ClassGeneral
            'obgen.updateCortesEnviados()
        Else
            MsgBox("No se enviaron los cortes")
        End If

        MsgBox("Sincronización finalizada")

    End Sub

#Region ""

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    'Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

    'Dim conteo As Integer = 1

    'Do While conteo > 0

    'Me.gridExports1.DataSource = Nothing
    'Me.gridExports1.DataSource = objs.fcn_min_naxr1(GlobalEmpNit, conteo)

    'Try

    'Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\RELLENORUTA" + conteo.ToString + ".xlsx")
    'Process.Start(Application.StartupPath + "\EXPORTS\RELLENORUTA" + conteo.ToString + ".xlsx")

    'Catch ex As Exception

    'MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error: " & ex.ToString)

    'End Try

    'Me.gridExports1.DataSource = Nothing

    'conteo = conteo + 1

    'If conteo = 4 Then

    'Exit Sub

    'End If

    'Loop

    'End Sub

    'Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    'Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

    'If objS.fcnDeleteInvsaldo(GlobalEmpNit) = True Then
    'If objS.fcnSendBackupFInventario(GlobalEmpNit) = True Then
    'Else
    'Call Form1.Mensaje("Error al sincronizar " & objS.DesError.ToString)
    'End If
    'Else
    'Call Form1.Mensaje("Error al sincronizar " & objS.DesError.ToString)
    'End If


    'End Sub

    'Private Function minmaxFinalizada() As Boolean

    'Dim result As Boolean

    'Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

    'If objS.fcnActuMaxMin(GlobalEmpNit) = True Then
    'If objS.fcnSendDataVendidos(New DateTime(Today.Year, Today.Month, Today.Day)) = True Then
    'If objS.fcnUpdateMinMax(GlobalEmpNit) = True Then
    'Else
    'Call Form1.Mensaje("NO SE ESTABLECIERON LOS MAXIMOS")
    'End If

    'Else
    'Call Form1.Mensaje("ERROR EN ACTU MIN/MAX")
    'End If
    'Else
    'Form1.Mensaje("NO SE ESTABLECIO EL TOTALVENTAS MES PASADO")
    'End If
    'result = True

    'Return result

    'End Function

    ' Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    'Call minmaxFinalizada()

    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs)

    'End Sub

    'Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click

    'Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

    'If objS.fcnSendDataVendidos2(GlobalEmpNit, Me.cmbSUCURSALES.SelectedValue.ToString) = True Then

    'MsgBox("SUBIDOS A LA TABLA")

    'Else
    'Call Form1.Mensaje("ERROR EN SUBIR DATA")
    'End If

    'End Sub

#End Region
#End Region

End Class
