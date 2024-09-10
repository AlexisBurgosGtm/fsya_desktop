
Public Class rptCorteUrizar

    Private Sub rptCorteUrizar_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptCorteUrizar_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub



End Class