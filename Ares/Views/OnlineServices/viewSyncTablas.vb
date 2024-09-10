Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen

Public Class viewSyncTablas
    Sub New(ByVal TIPODOCENT As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        tipodoc = TIPODOCENT

    End Sub

    Dim tipodoc As String
    'TIN = TRASLADOS ENTRADA BODEGA
    'TES = TRASLADOS ENTRADA SUCURSAL


    Private Sub viewSyncTablas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()

        'ESTABLECE LOS DATOS DEL DOCUMENTO DE ENTRADA
        Dim objDoc As New ClassTipoDocumentos(GlobalEmpNit)
        With Me.cmbGenCoddoc
            .DataSource = objDoc.tblCoddoc(tipodoc)
            .DisplayMember = "CODDOC"
            .ValueMember = "CODDOC"
        End With

        'selecciona el index cero
        Try
            'obtiene el correlativo del documento para cargarlo al label
            If tipodoc = "TIN" Then
                Me.cmbGenCoddoc.SelectedValue = GlobalCoddocTrasEntradaBodega
            End If
            If tipodoc = "TES" Then
                Me.cmbGenCoddoc.SelectedValue = GlobalCoddocTrasEntradaSucursal
            End If

            If Me.cmbGenCoddoc.Text <> "" Then
            Else
                Me.cmbGenCoddoc.SelectedIndex = 0
            End If

            Dim corr As String
            corr = objDoc.GetCorrelativoDoc(Me.cmbGenCoddoc.SelectedValue.ToString).ToString
            Me.lbGenCorrelativo.Text = corr

        Catch ex As Exception
            Me.cmbGenCoddoc.SelectedIndex = 0
        End Try



    End Sub

    Private Sub CargarGrid()
        Try
            Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

            Me.GridTraslados.DataSource = Nothing
                If tipodoc = "TIN" Then
                    Me.GridTraslados.DataSource = objS.getTrasladosPendientes(GlobalEmpNit, GlobalBodegaCentralEmpnit, "SI")
                Else
                    Me.GridTraslados.DataSource = objS.getTrasladosPendientes(GlobalEmpNit, GlobalBodegaCentralEmpnit, "NO")
                End If

        Catch ex As Exception
            MsgBox("Por lo visto no hay conexión a internet, verifique o inténtelo más tarde")
        End Try


    End Sub

    Dim drw As DataRow

    Private Sub GridViewTraslados_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewTraslados.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewTraslados.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewTraslados_DoubleClick(sender As Object, e As EventArgs) Handles GridViewTraslados.DoubleClick
        Me.RadMenTraslados.ShowPopup(MousePosition)
    End Sub


    Private Sub BarButtonItemDetalle_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemDetalle.ItemClick
        Try
            Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
            Me.GridDetalle.DataSource = Nothing
            Me.txtDataTrasladoObs.Text = drw.Item(5).ToString
            Me.GridDetalle.DataSource = objS.getDataTrasladoPendiente(drw.Item(6).ToString, drw.Item(0).ToString, Double.Parse(drw.Item(1)))
            Me.FlyoutPanelDetalleTraslado.ShowPopup()
        Catch ex As Exception
            MsgBox("Error. " & ex.ToString)
        End Try

    End Sub

    Private Sub BarButtonItemGenerar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemGenerar.ItemClick

        If Me.cmbGenCoddoc.SelectedIndex >= 0 Then
        Else
            MsgBox("Error al generar el documento, debe seleccionar una serie para generar el documento")
            Exit Sub
        End If

        'obtiene el empnit del registro seleccionado
        Dim enit As String = drw.Item(6).ToString

        If enit = GlobalEmpNit Then

            If Confirmacion("¿Está seguro que desea Cargar este Traslado a su Empresa?", Me.ParentForm) = True Then

                Using c As New SqlClient.SqlConnection(strSqlConectionString)
                    Try
                        Dim docto As String, correl As Double

                        If c.State <> ConnectionState.Open Then
                            c.Open()
                        End If

                        'OBTIENE EL DOCUMENTO A GENERAR
                        docto = Me.cmbGenCoddoc.SelectedValue.ToString
                        correl = Double.Parse(Me.lbGenCorrelativo.Text)

                        'GENERA EL DOCUMENTO
                        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
                        If objS.GetTraslado(drw.Item(6).ToString, drw.Item(0).ToString, Double.Parse(drw.Item(1)), GlobalEmpNit, docto, correl, "") = True Then

                            Dim objDocto As New ClassDocumentos
                            'carga la existencias
                            If objDocto.cargarEntradaInventario(GlobalEmpNit, docto, correl, GlobalAnioProceso, GlobalMesProceso) = True Then
                            Else
                                MsgBox("El inventario no se cargó.. deberá realizar una actualización de inventario para que se cargue.")
                            End If

                            'elimina el traslado recien generado
                            objS.DeleteTraslado(drw.Item(6).ToString, drw.Item(0).ToString, Double.Parse(drw.Item(1)), Token)


                            'actualiza el correlativo
                            objDocto.updateCorrelativoDocumento(GlobalEmpNit, docto, correl)

                            'actualiza el correlativo del documento en el combobox
                            Dim objDoc As New ClassTipoDocumentos(GlobalEmpNit)
                            Dim corr As String
                            corr = objDoc.GetCorrelativoDoc(Me.cmbGenCoddoc.SelectedValue.ToString).ToString
                            Me.lbGenCorrelativo.Text = corr

                            MsgBox("Ingreso generado exitosamente con el número " & docto & "-" & correl.ToString)

                            'recarga el listado
                            Call CargarGrid()

                            Call AbrirReporte_MovInv(Today.Date, docto, correl, "TRANSFERENCIA ONLINE")
                        Else
                            MsgBox("Error al generar el Ingreso de inventario, se produjo en el proceso final. Error: " & objS.DesError)
                        End If

                        c.Close()

                    Catch ex As Exception
                        MsgBox("Error general de proceso. Error: " & ex.ToString)
                    End Try


                End Using
            End If

        Else
            Call Aviso("NO PERMITIDO", "Usted no puede cargar un traslado de otra empresa", Me.ParentForm)
        End If

    End Sub

    Private Sub btnGenerarPlantillaProductos_Click(sender As Object, e As EventArgs) Handles btnGenerarPlantillaProductos.Click
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If Confirmacion("¿Está perfectamente seguro que desea establecer su catálogo de productos y precios como el catálogo principal?", Me.ParentForm) = True Then

                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

                Call Form1.Mensaje("Eliminando Productos Anteriores")

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

    Private Sub btnRestaurarBackup_Click(sender As Object, e As EventArgs) Handles btnRestaurarBackup.Click

    End Sub

    Private Sub BarButtonItemEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEliminar.ItemClick

        If Confirmacion("¿Está seguro que desea Eliminar este Traslado?", Me.ParentForm) = True Then
            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                'elimina el traslado recien generado
                Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
                If objs.DeleteTraslado(drw.Item(6).ToString, drw.Item(0).ToString, Double.Parse(drw.Item(1)), Token) = True Then
                    Call CargarGrid()

                    MsgBox("Traslado eliminado exitosamente")
                Else
                    MsgBox("Error al eliminar el traslado. Error: " & objs.DesError)
                End If

            End If

        End If

    End Sub

    Private Sub cmbGenCoddoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGenCoddoc.SelectedIndexChanged
        Try
            'actualiza el correlativo
            Dim objDocto As New ClassTipoDocumentos(GlobalEmpNit)
            Me.lbGenCorrelativo.Text = objDocto.GetCorrelativoDoc(Me.cmbGenCoddoc.SelectedValue.ToString).ToString

        Catch ex As Exception

        End Try
    End Sub
End Class
