Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewREPCONTA
    Private Sub viewREPCONTA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSUCURSALES
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"

        End With
    End Sub

#Region "REPORTE DE VENTAS FAC"

    Private Function TBLReportVFAC() As DataTable
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim tbl As New DataTable
        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.FECHA, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALEXENTO, SUM(DOCUMENTOS.TOTALPRECIO) 
                                                         - SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALAFECTO, TIPODOCUMENTOS.TIPODOC
                                           FROM            DOCUMENTOS LEFT OUTER JOIN
                                                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE        (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCUMENTOS.FECHA, TIPODOCUMENTOS.TIPODOC
                                           HAVING        (DOCUMENTOS.FECHA BETWEEN @MI AND @MF) AND (TIPODOCUMENTOS.TIPODOC = 'FAC')
                                           ORDER BY DOCUMENTOS.FECHA", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamDatePickI)
                cmd.Parameters.AddWithValue("@MF", GlobalParamDatePickF)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using
        SplashScreenManager.CloseForm()
        Return tbl
    End Function

    Private Sub TileItemFAC_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemFAC.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then
            Me.gridExports.DataSource = Nothing
            Me.gridExports.DataSource = TBLReportVFAC()
            Try
                Me.gridExports.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTFAC - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTFAC - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports.DataSource = Nothing
        End If

    End Sub

#End Region

#Region "REPORTE DE VENTAS FEL"

    Private Function TBLReportVFEL() As DataTable
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim tbl As New DataTable
        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.FECHA, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALEXENTO, SUM(DOCUMENTOS.TOTALPRECIO) 
                                                         - SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALAFECTO, TIPODOCUMENTOS.TIPODOC
                                           FROM            DOCUMENTOS LEFT OUTER JOIN
                                                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE        (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCUMENTOS.FECHA, TIPODOCUMENTOS.TIPODOC
                                           HAVING        (DOCUMENTOS.FECHA BETWEEN @MI AND @MF) AND (TIPODOCUMENTOS.TIPODOC = 'FEF')
                                           ORDER BY DOCUMENTOS.FECHA", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamDatePickI)
                cmd.Parameters.AddWithValue("@MF", GlobalParamDatePickF)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using
        SplashScreenManager.CloseForm()
        Return tbl
    End Function

    Private Sub TileItemFEL_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemFEL.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then
            Me.gridExports1.DataSource = Nothing
            Me.gridExports1.DataSource = TBLReportVFEL()
            Try
                Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTFEL - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTFEL - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports1.DataSource = Nothing
        End If

    End Sub

#End Region

#Region "REPORTE DE VENTAS EX/AFEC"

    Private Function TBLReportVEXAFEC() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try

                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.FECHA, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALEXENTO, SUM(DOCUMENTOS.TOTALPRECIO) 
                                                         - SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALAFECTO, TIPODOCUMENTOS.TIPODOC
                                           FROM            DOCUMENTOS LEFT OUTER JOIN
                                                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE        (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCUMENTOS.FECHA, TIPODOCUMENTOS.TIPODOC
                                           HAVING        (DOCUMENTOS.FECHA BETWEEN @MI AND @MF) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF'))
                                           ORDER BY DOCUMENTOS.FECHA", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamDatePickI)
                cmd.Parameters.AddWithValue("@MF", GlobalParamDatePickF)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                '(DOCUMENTOS.EMPNIT = 'farma001') AND 

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Private Sub TileItemEXAFEC_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemEXAFEC.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Me.gridExports2.DataSource = Nothing
            Me.gridExports2.DataSource = TBLReportVEXAFEC()

            Try
                Me.gridExports2.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTEXAFEC - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTEXAFEC - " + Me.cmbSUCURSALES.Text + ".xlsx")

            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports2.DataSource = Nothing

        End If

    End Sub

#End Region

End Class
