Public Class FACTURA
    Private Sub FACTURA_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.txtLetras.Text = Strings.UCase(Letras(TotalVentaFAC.ToString))
        Catch ex As Exception

        End Try
        Try
            Me.txtLetras2.Text = Strings.UCase(Letras(TotalVentaFAC.ToString))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FACTURA_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.txtLetras.Text = Strings.UCase(Letras(TotalVentaFAC.ToString)) & " QUETZALES"
        Catch ex As Exception

        End Try
        Try
            Me.txtLetras2.Text = Strings.UCase(Letras(TotalVentaFAC.ToString)) & " QUETZALES"
        Catch ex As Exception

        End Try
    End Sub
End Class