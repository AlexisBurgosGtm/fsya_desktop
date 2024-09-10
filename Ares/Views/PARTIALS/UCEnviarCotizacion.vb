Public Class UCEnviarCotizacion
    Private Sub cmdEnviar_Click(sender As Object, e As EventArgs) Handles cmdEnviar.Click
        If Me.txtMail.Text <> "" Then
            If GenerarCotizacion(SelectedCoddoc, SelectedCorrelativo, SelectedFecha) = True Then
                Try

                    Call EnviarGmailAdjunto("Cotización de Productos " & GlobalNomEmpresa, "Estimado Cliente:
Es un gusto para nosotros poderle brindar la siguiente cotización de nuestros productos. 
Gracias por su preferencia !!", Me.txtMail.Text, Application.StartupPath + "\CotizacionDelCliente.pdf")

                    MsgBox("Cotización enviada exitosamente")

                Catch ex As Exception
                    MsgBox("Lo siento, al parecer tu email está mal escrito o quizás no tengas conexión a internet, por lo que no puedo enviar la cotización")
                End Try
            End If
        End If
    End Sub

End Class
