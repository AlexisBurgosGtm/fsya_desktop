Public Class XtraReportVentaDocumento
    Private Sub XtraReportVentaDocumento_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.imgLogo.Image = LogoEmpresa
            Me.lbEmpresa.Text = GlobalNomEmpresa
            Me.LbTituloReporte.Text = GlobalTituloReporte
            Me.lbNomDoc.Text = GlobalNomFac
            'Me.lbNomVend.Text = GlobalVendFac
        Catch ex As Exception

        End Try
    End Sub
End Class