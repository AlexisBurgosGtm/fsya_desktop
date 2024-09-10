Public Class rptCotizacion
    Private Sub rptCotizacion_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptCotizacion_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub
End Class