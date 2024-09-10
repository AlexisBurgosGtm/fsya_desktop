Public Class viewFechaInicialFinal
    Private Sub viewFechaInicialFinal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtFechaInicial.DateTime = Today.Date
        Me.txtFechaFinal.DateTime = Today.Date
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        GlobalParamFechaInicial = Me.txtFechaInicial.DateTime.Date
        GlobalParamFechaFinal = Me.txtFechaFinal.DateTime.Date
    End Sub
End Class
