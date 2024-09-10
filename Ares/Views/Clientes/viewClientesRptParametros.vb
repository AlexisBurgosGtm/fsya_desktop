
Public Class viewClientesRptParametros

    Private Sub viewClientesRptParametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtFechaInicial.DateTime = Today.Date
        Me.txtFechaFinal.DateTime = Today.Date



    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        SelectedFechaInicial = Me.txtFechaInicial.DateTime
        SelectedFechaFinal = Me.txtFechaFinal.DateTime



    End Sub


End Class
