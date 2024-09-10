Public Class XtraReportVentasMarcas
    Private Sub XtraReportVentasMarcas_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.lbEmpresa.Text = GlobalNomEmpresa
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraReportVentasMarcas_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.lbEmpresa.Text = GlobalNomEmpresa
            Me.imgLogo.Image = LogoEmpresa
        Catch ex As Exception

        End Try
    End Sub
End Class