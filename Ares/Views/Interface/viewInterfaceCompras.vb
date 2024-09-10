Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors


Public Class viewInterfaceCompras

    Private Sub viewInterfaceCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GlobalNomEmpresa = Form1.cmbLoginEmpresa.Text
        GlobalNomUsuario = Form1.txtUser.Text

        Me.lbUSUARIO.Text = GlobalNomUsuario
        Me.lbEMPRESA.Text = GlobalNomEmpresa

    End Sub

    Private Sub TileNavPaneMain_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles TileNavPane1.ElementClick, TileNavPane2.ElementClick

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

    Private Sub btnOnlinePreventa_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("SYNC2")
    End Sub

    Private Sub btnOnlinePedidosVentas_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("ONLINE_PREVENTAS")
    End Sub

    Private Sub TileControl1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileControl1.ItemClick
        Dim tag As String = ""
        Try
            tag = e.Item.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If FlyoutDialog.Show(Form1.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
            Call NAVEGAR("EMPRESAS_SYNC")
        End If
    End Sub

    Private Sub AccordionControlElement2_Click(sender As Object, e As EventArgs) Handles AccordionControlElement2.Click

    End Sub

    Private Sub AccordionControlMenuGeneral_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.ElementClickEventArgs) Handles AccordionControlMenuGeneral.ElementClick

        Dim tag As String = ""
        Try
            tag = e.Element.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)

    End Sub

    Private Sub TileItemEXPGEN_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemEXPGEN.ItemClick

        Me.gridExports.DataSource = Nothing
        Me.gridExports.DataSource = TBLReportINVENTARIO(GlobalAnioProceso, GlobalMesProceso)
        Try
            Me.gridExports.ExportToXlsx(Application.StartupPath + "\EXPORTS\InventarioGeneral.xlsx")
            Process.Start(Application.StartupPath + "\EXPORTS\InventarioGeneral.xlsx")

        Catch ex As Exception
            MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error: " & ex.ToString)
        End Try
        Me.gridExports.DataSource = Nothing

    End Sub

    Private Function TBLReportCG() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try

                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.ANIO, DOCUMENTOS.MES, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) As UNIDADES, PROVEEDORES.CODPROV,
                                           PROVEEDORES.RAZONSOCIAL AS [NOM PROV]
                                           From DOCUMENTOS LEFT OUTER Join
                                           DOCPRODUCTOS On DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC And DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER Join
                                           PROVEEDORES On DOCUMENTOS.EMPNIT = PROVEEDORES.EMPNIT And DOCUMENTOS.DOC_NOMCLIE = PROVEEDORES.EMPRESA
                                           Where (DOCUMENTOS.CODDOC Like '%COM%')
                                           GROUP BY DOCUMENTOS.ANIO, DOCUMENTOS.MES, PROVEEDORES.CODPROV, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PROVEEDORES.RAZONSOCIAL
                                           HAVING(DOCUMENTOS.ANIO = @A) And (DOCUMENTOS.MES BETWEEN @MI AND @MF) And (PROVEEDORES.CODPROV In (1159, 4208, 1187, 4209, 4211))
                                           ORDER BY UNIDADES DESC", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)


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

    Private Sub TileItemREPG_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPG.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaMES) = DialogResult.OK Then

            Me.gridExports1.DataSource = Nothing
            Me.gridExports1.DataSource = TBLReportCG()

            Try
                Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTG.xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTG.xlsx")

            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports1.DataSource = Nothing

        End If

    End Sub

End Class
