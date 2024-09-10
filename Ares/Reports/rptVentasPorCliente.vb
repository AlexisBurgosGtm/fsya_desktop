Public Class rptVentasPorCliente
    Sub New(ByVal _fechainicial As Date, ByVal _fechafinal As Date)

        ' This call is required by the designer.
        InitializeComponent()

        fechaInicial = _fechainicial
        fechaFinal = _fechafinal

    End Sub

    Dim fechaInicial, fechaFinal As Date

    Private Sub rptVentasPorCliente_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint

    End Sub

    Private Sub rptVentasPorCliente_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint

    End Sub
End Class