Imports DevExpress.XtraBars.Docking2010.Customization
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class viewInventariosMinimos

    Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

    Dim drw As DataRow

    Private Sub viewInventariosMinimos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid(True)

    End Sub

    Private Sub CargarGrid(ByVal SoloAgotados As Boolean)
        Me.GridMinimos.DataSource = Nothing

        If SoloAgotados = True Then
            Me.GridMinimos.DataSource = objInventarios.tblProductosAgotados
        Else
            Me.GridMinimos.DataSource = objInventarios.tblProductosAgotadosTodos
        End If

        Me.GridMinimos.RefreshDataSource()
    End Sub

    Private Sub GridViewMinimos_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridViewMinimos.SelectionChanged
        Try
            drw = Nothing
            drw = Me.GridViewMinimos.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewMinimos_DoubleClick(sender As Object, e As EventArgs) Handles GridViewMinimos.DoubleClick
        Try
            If FlyoutDialog.Show(Me.ParentForm, New viewInventariosMinimosDatos(drw)) = DialogResult.OK Then
                Call CargarGrid(Me.SwitchTodosMinimos.IsOn)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewMinimos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewMinimos.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewMinimos.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SwitchTodosMinimos_Toggled(sender As Object, e As EventArgs) Handles SwitchTodosMinimos.Toggled
        Call CargarGrid(Me.SwitchTodosMinimos.IsOn)

    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Dim Adapter As New SqlDataAdapter
            Dim report As New rptProductosMinimo

            'CARGO PRIMERO EL REPORTE
            report.DataSource = objInventarios.tblProductosAgotados
            report.DataAdapter = Adapter
            report.DataMember = "tblMinimos"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            SplashScreenManager.CloseForm()

            report.ShowPreview



        Catch ex As Exception
            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()

            MsgBox("Ha ocurrido un error al cargar el reporte de inventarios mínimos. Error: " & GlobalDesError)
        End Try

    End Sub
End Class
