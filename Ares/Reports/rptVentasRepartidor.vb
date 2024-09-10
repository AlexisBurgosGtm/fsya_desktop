Public Class rptVentasRepartidor
    Sub New(ByVal _fechainicial As Date, ByVal _fechafinal As Date)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtFechaInicial.Text = _fechainicial.ToString
        Me.txtFechaFinal.Text = _fechafinal.ToString
    End Sub
    Private Sub rptVentasRepartidor_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptVentasRepartidor_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class