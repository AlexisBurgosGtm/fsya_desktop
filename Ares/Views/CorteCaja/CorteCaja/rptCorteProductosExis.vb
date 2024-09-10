Public Class rptCorteProductosExis

    Private Sub rptCorteProductosExis_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptCorteProductosExis_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa

        Catch ex As Exception

        End Try
    End Sub

End Class