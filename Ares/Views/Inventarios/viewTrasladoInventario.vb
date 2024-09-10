Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class viewTrasladoInventario
    Sub New(ByVal _desde As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        desde = _desde
    End Sub

    Dim desde As String

    Private Sub viewTrasladoInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call CargarMesProceso()

        Me.cmbMesDocumento.SelectedValue = CType(Today.Month, Integer)
        Me.cmbAnioDocumento.Text = Today.Year.ToString

        Call Cargargrid(desde)

        Me.lbTitulo.Text = "TRANSFERIR DESDE " + desde

        Call CargarGridTodos()

    End Sub

    Public Sub CargarMesProceso()
        Dim tblmeses As New DataTable
        With tblmeses.Columns
            .Add("CODMES", GetType(Integer))
            .Add("DESMES", GetType(String))
        End With

        With tblmeses.Rows
            .Add(New Object() {1, "ENERO"})
            .Add(New Object() {2, "FEBRERO"})
            .Add(New Object() {3, "MARZO"})
            .Add(New Object() {4, "ABRIL"})
            .Add(New Object() {5, "MAYO"})
            .Add(New Object() {6, "JUNIO"})
            .Add(New Object() {7, "JULIO"})
            .Add(New Object() {8, "AGOSTO"})
            .Add(New Object() {9, "SEPTIEMBRE"})
            .Add(New Object() {10, "OCTUBRE"})
            .Add(New Object() {11, "NOVIEMBRE"})
            .Add(New Object() {12, "DICIEMBRE"})
        End With

        With Me.cmbMesDocumento
            .DataSource = tblmeses
            .DisplayMember = "DESMES"
            .ValueMember = "CODMES"
        End With


    End Sub


#Region " ** TRANSFERIR SALIDA INVENTARIO ** "



    Private Sub cmdTransferirAtras_Click(sender As Object, e As EventArgs)
        'Me.NavigationFrame1.SelectedPage = NP_GENERAL
        'SelectedForm = "INVENTARIOS"
        Me.GridTransferirDisponibles.DataSource = Nothing
        Call NAVEGAR("MENU")
    End Sub


    Private Sub TileViewTransferirDisponible_DoubleClick(sender As Object, e As EventArgs) Handles TileViewTransferirDisponible.DoubleClick


        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewTransferirDisponible.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            Dim CORRELATIVO As Double
            CORRELATIVO = Double.Parse(TileViewTransferirDisponible.GetRowCellValue(hitInfo.RowHandle, "CORRELATIVO").ToString)
            Dim CODDOC As String = TileViewTransferirDisponible.GetRowCellValue(hitInfo.RowHandle, "CODDOC").ToString

            If TileViewTransferirDisponible.GetRowCellValue(hitInfo.RowHandle, "CORTE").ToString = "NO" Then

                If Me.SwitchTipoTraslado.IsOn = False Then
                    If Confirmacion("¿Está seguro que desea Enviar este documento a la nube?", Me.ParentForm) = True Then

                        'INTENTANDO CONEXION AL HOSTING
                        'Form1.Mensaje("Intentando conectar con el hosting")
                        Dim objSn As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
                        'If objSn.testHostConection = True Then
                        'Form1.Mensaje("Conexión exitosa... enviando el traslado")

                        'Else
                        'MsgBox("No se pudo conectar con el hosting. Revise su conexión a internet")
                        'Exit Sub
                        'End If


                        If FlyoutDialog.Show(Me.ParentForm, New viewEmpresas()) = DialogResult.OK Then
                                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                                If objSn.SendSalidaInventarioTitulo(SelectedDescripcion, GlobalEmpNit, CODDOC, CORRELATIVO, GlobalNomEmpresa) = True Then
                                    '5) ACTUALIZA EL STATUS DEL CORTE A SI, EN LA SALIDA DE INVENTARIO SELECCIONADA
                                    Call AbrirConexionSql()

                                    Dim cmd5 As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='SI',CODEMBARQUE=@DESTINO, DIRENTREGA=@ENT WHERE CODDOC='" & CODDOC & "' AND CORRELATIVO=" & CORRELATIVO & " AND EMPNIT='" & GlobalEmpNit & "'", cn)
                                    cmd5.Parameters.AddWithValue("@DESTINO", SelectedDescripcion)
                                    cmd5.Parameters.AddWithValue("@ENT", SelectedNomSucursal)
                                    cmd5.ExecuteNonQuery()
                                    cmd5.Dispose()

                                    '6) ENVIO LA NOTIFICACION
                                    'Call Form1.EnviarNotificacionesEmail(6, "ARES te informa: Ingreso de Inventario por Transferencia", "El usuario " & GlobalNomUsuario & " transfirió la salida de inventario No. " & CORRELATIVO & " desde la empresa " & GlobalNomEmpresa)

                                    Call Cargargrid(desde)
                                    SplashScreenManager.CloseForm()

                                    Call Aviso("TRANSFERENCIA EXITOSA", "Se ha creado un nuevo traslado en la nube.. notifique a su sucursal para que lo descargue", Me.ParentForm)
                                Else
                                    SplashScreenManager.CloseForm()
                                    MsgBox("ERROR AL ENVIAR TRASLADO " + objSn.DesError.ToString)
                                End If

                            Else
                                MsgBox("NO SE SELECCIONÓ UNA EMPRESA DE DESTINO")
                            End If
                        End If

                    Else
                    'traslado entre bodegas
                    If FlyoutDialog.Show(Me.ParentForm, New viewTrasladoBodegas(CODDOC, CORRELATIVO, 1)) = DialogResult.OK Then
                        'ACTUALIZA EL STATUS DEL CORTE A SI, EN LA SALIDA DE INVENTARIO SELECCIONADA
                        Call AbrirConexionSql()

                        Dim cmd5 As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='SI',CODEMBARQUE=@DESTINO, DIRENTREGA=@ENT WHERE CODDOC='" & CODDOC & "' AND CORRELATIVO=" & CORRELATIVO & " AND EMPNIT='" & GlobalEmpNit & "'", cn)
                        cmd5.Parameters.AddWithValue("@DESTINO", "LOCAL")
                        cmd5.Parameters.AddWithValue("@ENT", "EMPRESA LOCAL")
                        cmd5.ExecuteNonQuery()
                        cmd5.Dispose()

                        'ENVIO LA NOTIFICACION
                        'Call Form1.EnviarNotificacionesEmail(6, "ARES te informa: Ingreso de Inventario por Transferencia", "El usuario " & GlobalNomUsuario & " transfirió la salida de inventario No. " & CORRELATIVO & " desde la empresa " & GlobalNomEmpresa)

                        Call Cargargrid(desde)
                    End If




                End If
            Else
                If Me.SwitchTipoTraslado.IsOn = False Then
                    If Confirmacion("Esta salida ya fué enviada, está seguro que desea enviarla de nuevo?", Me.ParentForm) = True Then
                        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
                            Using cn As New SqlConnection(strSqlConectionString)
                                Try
                                    If cn.State <> ConnectionState.Open Then
                                        cn.Open()
                                    End If

                                    Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='NO' WHERE CODDOC='" & CODDOC & "' AND CORRELATIVO=" & CORRELATIVO & " AND EMPNIT='" & GlobalEmpNit & "'", cn)
                                    cmd.ExecuteNonQuery()
                                    MsgBox("Movimiento liberado exitosamente")
                                    Call Cargargrid(desde)
                                Catch ex As Exception
                                    MsgBox("Documento no liberado. Error: " & ex.ToString)
                                End Try
                            End Using
                        End If
                    End If
                Else
                    MsgBox("No se puede volver a trasladar un Traslado entre bodegas")
                End If

            End If
        End If

    End Sub


    Private Sub TileViewTransferirDisponible_ItemCustomize(sender As Object, e As TileViewItemCustomizeEventArgs) Handles TileViewTransferirDisponible.ItemCustomize
        Try
            If TileViewTransferirDisponible.GetRowCellValue(e.RowHandle, TileViewTransferirDisponible.Columns("CORTE")).ToString = "SI" Then
                e.Item.AppearanceItem.Normal.BackColor = Color.LightSalmon
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub Cargargrid(ByVal desde As String)

        Dim anio As Integer = CType(Me.cmbAnioDocumento.Text, Integer)
        Dim mes As Integer = CType(Me.cmbMesDocumento.SelectedValue, Integer)


        Dim tipodoc As String

        Select Case desde
            Case "BODEGA"
                tipodoc = "TSL"
            Case "SUCURSAL"
                tipodoc = "TSS"
        End Select

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CORRELATIVO", GetType(Double))
            .Add("FECHA", GetType(Date))
            .Add("OBS", GetType(String))
            .Add("TOTALPRECIO", GetType(String))
            .Add("CORTE", GetType(String))
            .Add("CODDOC", GetType(String))
        End With
        Call AbrirConexionSql()
        'Dim cmd As New SqlCommand("SELECT CORRELATIVO, FECHA, OBS, TOTALPRECIO, CORTE,CODDOC FROM DOCUMENTOS WHERE CODDOC='SALINV' AND EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES ORDER BY CORTE ASC", cn)
        Dim cmd As New SqlCommand("SELECT DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.OBS, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.CORTE, DOCUMENTOS.CODDOC
                                    FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                    WHERE (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) 
                                    ORDER BY DOCUMENTOS.CORTE", cn)

        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", anio)
        cmd.Parameters.AddWithValue("@MES", mes)
        cmd.Parameters.AddWithValue("@TIPODOC", tipodoc)
        Dim da As New SqlDataAdapter
        da.SelectCommand = cmd
        da.Fill(tbl)


        cmd.Dispose()
        cn.Close()

        Me.GridTransferirDisponibles.DataSource = tbl

        TryCast(TileViewTransferirDisponible.TileTemplate(0), TileViewItemElement).Column = TileViewTransferirDisponible.Columns("CORRELATIVO")
        TryCast(TileViewTransferirDisponible.TileTemplate(2), TileViewItemElement).Column = TileViewTransferirDisponible.Columns("FECHA")
        TryCast(TileViewTransferirDisponible.TileTemplate(3), TileViewItemElement).Column = TileViewTransferirDisponible.Columns("OBS")
        TryCast(TileViewTransferirDisponible.TileTemplate(1), TileViewItemElement).Column = TileViewTransferirDisponible.Columns("TOTALPRECIO")

    End Sub

    Private Sub cmbMesDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMesDocumento.SelectedIndexChanged
        Try
            Call Cargargrid(desde)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAnioDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnioDocumento.SelectedIndexChanged
        Try
            Call Cargargrid(desde)
        Catch ex As Exception

        End Try
    End Sub

#End Region



    Private Sub CargarGridTodos()
        Try
            Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

            Me.GridTrasladosPendientes.DataSource = Nothing

                Me.GridTrasladosPendientes.DataSource = objS.getTrasladosPendientesTodos(GlobalEmpNit)


        Catch ex As Exception
            MsgBox("Por lo visto no hay conexión a internet, verifique o inténtelo más tarde")
        End Try


    End Sub

    Private Sub GridViewTrasladosPendientes_DoubleClick(sender As Object, e As EventArgs) Handles GridViewTrasladosPendientes.DoubleClick

        If Confirmacion("¿Está seguro que desea ELIMINAR este traslado en la nube?", Me.ParentForm) = True Then
            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then


                'elimina el traslado recien generado
                Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)
                If objs.DeleteTraslado(drwTp.Item(6).ToString, drwTp.Item(0).ToString, Double.Parse(drwTp.Item(1)), Token) = True Then

                    Call CargarGridTodos()

                    MsgBox("Traslado eliminado exitosamente")
                Else
                    MsgBox("Error al eliminar el traslado. Error: " & objs.DesError)
                End If


            End If
        End If

    End Sub

    Dim drwTp As DataRow
    Private Sub GridViewTrasladosPendientes_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewTrasladosPendientes.FocusedRowChanged
        drwTp = Nothing
        Try
            drwTp = Me.GridViewTrasladosPendientes.GetFocusedDataRow
        Catch ex As Exception

        End Try

    End Sub



End Class
