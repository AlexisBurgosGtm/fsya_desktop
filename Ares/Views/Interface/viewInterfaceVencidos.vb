Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewInterfaceVencidos

    Private Sub viewInterfaceVencidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
                Me.FlyoutPanelOnline.ShowPopup()

            Case Else
                Call NAVEGAR(tag)

        End Select

    End Sub

    Private Sub AccordionControlMenuGeneral_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.ElementClickEventArgs)

        Dim tag As String
        Try
            tag = e.Element.Tag.ToString
        Catch ex As Exception
            tag = ""
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

    Private Sub btnOnlineGetProductosPrecios_Click(sender As Object, e As EventArgs) Handles btnOnlineGetProductosPrecios.Click
        Call NAVEGAR("SYNCPRECIOS")
    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Me.gridExports1.DataSource = Nothing
            Me.gridExports1.DataSource = TBLReportVENC()

            Try
                Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\MOV-VENC.xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\MOV-VENC.xlsx")

            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports1.DataSource = Nothing

        End If

    End Sub

    Private Function TBLReportVENC() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try

                Dim cmd As New SqlCommand("SELECT           DOCUMENTOS.FECHA, DOCPRODUCTOS.CODDOC AS DOCUMENTO, DOCPRODUCTOS.CORRELATIVO AS [NO.], DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD AS PRODUCTO, SUM(DOCPRODUCTOS.ENTREGADOS_TOTALUNIDADES) AS UNIDADES,
                                                            DOCPRODUCTOS.COSTO, SUM(DOCPRODUCTOS.TOTALCOSTO) AS [T.COSTO], ISNULL(DOCUMENTOS.OBSMARCA, 'SALIDA PROVEEDORES') AS [SUC. ENTRADA]
                                           FROM             DOCUMENTOS LEFT OUTER JOIN
                                                            TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('TES', 'TIN', 'TSS', 'TSL', 'COM'))
                                           GROUP BY         DOCUMENTOS.FECHA, DOCPRODUCTOS.CODDOC, DOCPRODUCTOS.CORRELATIVO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.COSTO, DOCUMENTOS.OBSMARCA
                                           HAVING           (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (NOT (DOCPRODUCTOS.DESPROD LIKE 'NULL'))
                                           ORDER BY         PRODUCTO, DOCUMENTOS.FECHA", cn)
                cmd.Parameters.AddWithValue("@FI", GlobalParamDatePickI)
                cmd.Parameters.AddWithValue("@FF", GlobalParamDatePickF)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        SplashScreenManager.CloseForm()

        Return tbl

    End Function

End Class
