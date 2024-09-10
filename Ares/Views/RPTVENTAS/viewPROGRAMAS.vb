Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraSplashScreen

Public Class viewPROGRAMAS

    Private Sub viewPROGRAMAS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call cargarGrid()

    End Sub

    Private Sub cargarGrid()

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim objvpn As New classServers
            Me.gridENTRADAS.DataSource = Nothing
            Me.gridENTRADAS.DataSource = objvpn.getTblPrograVPN(GlobalParamDatePickI, GlobalParamDatePickF)

            SplashScreenManager.CloseForm()

        End If


    End Sub

    Private Sub btnExportarDataProductos_Click(sender As Object, e As EventArgs) Handles btnExportarDataProductos.Click

        Try
            Dim archivo As String = Application.StartupPath + "/EXPORTS/PROGRAMAS" + Today.Month.ToString + ".xlsx"
            Me.gridENTRADAS.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub btnRECARGAR_Click(sender As Object, e As EventArgs) Handles btnRECARGAR.Click

        Call cargarGrid()


    End Sub

End Class