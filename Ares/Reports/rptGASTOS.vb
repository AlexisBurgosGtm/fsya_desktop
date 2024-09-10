Public Class rptGASTOS
    Sub New(ByVal _fechainicial As Date, ByVal _fechafinal As Date)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        fechai = _fechainicial
        fechaf = _fechafinal

    End Sub

    Dim fechai As Date, fechaf As Date

    Private Sub rptGASTOS_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.lbRangoFechas.Text = "Del " & fechai & " Al " & fechaf
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rptGASTOS_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.lbRangoFechas.Text = "Del " & fechai & " Al " & fechaf
        Catch ex As Exception

        End Try
    End Sub
End Class