Public Class rptEtiquetasIndividual
    Private Sub rptEtiquetasIndividual_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptEtiquetasIndividual_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub
End Class