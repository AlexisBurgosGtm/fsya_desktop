Public Class XtraReportCorteCaja
    Private Sub XtraReportCorteCaja_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.imgLogo.Image = LogoEmpresa
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa
            'Me.lbTotalGastos.Text = FormatCurrency(CorteTotalGastos, 2).ToString

        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraReportCorteCaja_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.imgLogo.Image = LogoEmpresa
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa
            'Me.lbTotalGastos.Text = FormatCurrency(CorteTotalGastos, 2).ToString

        Catch ex As Exception

        End Try
    End Sub
End Class