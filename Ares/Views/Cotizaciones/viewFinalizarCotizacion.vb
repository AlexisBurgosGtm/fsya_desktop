Public Class viewFinalizarCotizacion
    Private Sub txtDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtEmail.select()
        End If
    End Sub

    Private Sub txtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtObs.select()
        End If
    End Sub

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardar.select()
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.txtDireccion.Text <> "" Then

        Else
            Me.txtDireccion.Text = "SN"
        End If
        If Me.txtObs.Text <> "" Then

        Else
            Me.txtObs.Text = "SN"
        End If

        If Me.txtEmail.Text <> "" Then
            GlobalEmailEnviar = Me.txtEmail.Text

        End If

        VentasDirEntrega = Me.txtDireccion.Text
        VentasObs = Me.txtObs.Text
        VentasCodRepartidor = 0

        Me.btnAceptar.PerformClick()
    End Sub

    Private Sub viewFinalizarCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtDireccion.select()
    End Sub

End Class
