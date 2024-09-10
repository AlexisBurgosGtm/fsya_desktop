Public Class rptOrdenTrabajo
    Private Sub rptOrdenTrabajo_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.lbTitulo.Text = "Orden de Trabajo " + GlobalNomEmpresa
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptOrdenTrabajo_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.lbTitulo.Text = "Orden de Trabajo " + GlobalNomEmpresa
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub
End Class