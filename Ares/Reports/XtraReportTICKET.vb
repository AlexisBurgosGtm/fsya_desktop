Public Class XtraReportTICKET
    Private Sub XtraReportTICKET_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.txtLetras.Text = Strings.UCase(Letras(TotalVentaFAC.ToString))
        Catch ex As Exception

        End Try



    End Sub

    Private Sub XtraReportTICKET_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.txtLetras.Text = Strings.UCase(Letras(TotalVentaFAC.ToString))
        Catch ex As Exception

        End Try




    End Sub
End Class