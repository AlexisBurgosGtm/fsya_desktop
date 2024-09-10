Public Class ViewClave
    Sub New(ByVal ClaveActual As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        Clave = ClaveActual

    End Sub

    Dim Clave As String

    Private Sub ViewClave_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click


    End Sub

    Private Sub txtPass_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPass.KeyDown
        If e.KeyCode = Keys.Enter Then


            If Me.txtPass.Text <> "1" Then

                If Me.txtPass.Text = Clave Then
                    Me.btnAceptar.PerformClick()
                Else
                    Call Aviso("NO AUTORIZADO", "La clave es incorrecta", Me.ParentForm)
                End If

            Else
                MsgBox("Escriba una contraseña para verificar")
            End If
        End If
    End Sub

    Private Sub txtPass_Leave(sender As Object, e As EventArgs) Handles txtPass.Leave

        Me.txtPass.select()

    End Sub

    Private Sub txtPass_EditValueChanged(sender As Object, e As EventArgs) Handles txtPass.EditValueChanged

    End Sub
End Class
