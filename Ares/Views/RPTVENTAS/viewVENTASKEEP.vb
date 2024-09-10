Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewVENTASKEEP
    Private Sub viewVENTASKEEP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSUCURSALES
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

        Me.txtDatePickInicial.Value = Today.Date
        Me.txtDatePickFinal.Value = Today.Date

    End Sub

#Region "GRID KEEP"

    Private Sub cargarGrid()

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing
        Me.GridControlPRODUCTOS.DataSource = tblKEEP()
        Me.GridControlPRODUCTOS.RefreshDataSource()

        SplashScreenManager.CloseForm()

    End Sub

    Private Function tblKEEP() As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS [TOTAL VENDIDOS], SUM(DOCPRODUCTOS.TOTALCOSTO) AS [TOTAL COSTO], 
                                                            SUM(DOCPRODUCTOS.TOTALPRECIO) AS [TOTAL PRECIO]
                                           FROM             DOCPRODUCTOS LEFT OUTER JOIN
                                                            DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                                                            EMPRESAS ON DOCPRODUCTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                                            TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY         DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, EMPRESAS.EMPNIT, DOCUMENTOS.FECHA
                                           HAVING           (DOCPRODUCTOS.CODPROD = '3874') AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF)
                                           ORDER BY         DOCPRODUCTOS.DESPROD", cn)
                cmd.Parameters.AddWithValue("@FI", Date.Parse(Me.txtDatePickInicial.Value))
                cmd.Parameters.AddWithValue("@FF", Date.Parse(Me.txtDatePickFinal.Value))
                cmd.CommandTimeout = 0
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox("productos: " + GlobalDesError)
            End Try

        End Using

        Return tbl
    End Function

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        Call cargarGrid()

    End Sub
    Private Sub btnExportarDataProductos_Click(sender As Object, e As EventArgs) Handles btnExportarDataProductos.Click

        Try
            Dim archivo As String = Application.StartupPath + "/EXPORTS/VENTAS KEEP - " + Me.cmbSUCURSALES.Text + ".xlsx"
            Me.GridControlPRODUCTOS.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

End Class
