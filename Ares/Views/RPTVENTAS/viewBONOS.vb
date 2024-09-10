Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewBONOS
    Private Sub viewBONOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSUCURSALES
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

        Me.txtDatePickInicial.Value = Today.Date
        Me.txtDatePickFinal.Value = Today.Date

    End Sub

#Region "GRID BONOS"

    Private Sub cargarGrid()

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing
        Me.GridControlPRODUCTOS.DataSource = tblTopProductos()
        Me.GridControlPRODUCTOS.RefreshDataSource()

        SplashScreenManager.CloseForm()

    End Sub

    Private Function tblTopProductos() As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS [T COSTO], 
                                                            SUM(DOCPRODUCTOS.TOTALPRECIO) AS [T PRECIO], PRODUCTOS.BONO, SUM(DOCPRODUCTOS.TOTALUNIDADES) * (PRODUCTOS.BONO) AS TOTALBONO, EMPLEADOS.NOMEMPLEADO
                                           FROM             EMPLEADOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN AND EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT RIGHT OUTER JOIN
                                                            DOCPRODUCTOS ON DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                                            TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            PRODUCTOS ON DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT AND DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.DESPROD = PRODUCTOS.DESPROD
                                           WHERE            (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF)
                                           GROUP BY         DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, EMPLEADOS.NOMEMPLEADO
                                           HAVING           (PRODUCTOS.BONO > 0)", cn)
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
            Dim archivo As String = Application.StartupPath + "/EXPORTS/BONOS - " + Me.cmbSUCURSALES.Text + ".xlsx"
            Me.GridControlPRODUCTOS.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

End Class
