Public Class ReporteVentasVendedor
    Private Sub ReporteVentasVendedorvb_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Me.LbReporteEmpresa.Text = GlobalNomEmpresa
    End Sub
End Class