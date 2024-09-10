Imports System.Data.SqlClient

Public Class UserControl_NuevoComponente
    Private Sub txtComponentesComponente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComponentesComponente.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtComponentesUso.select()
        End If
    End Sub

    Private Sub txtComponentesUso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtComponentesUso.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtComponentesComponente.Text <> "" Then
                If Me.txtComponentesUso.Text <> "" Then
                    Me.cmdComponentesGuardar.DialogResult = DialogResult.OK
                End If
            End If
            Me.cmdComponentesGuardar.select()
        End If
    End Sub

    Private Sub cmdComponentesGuardar_Click(sender As Object, e As EventArgs) Handles cmdComponentesGuardar.Click
        If Me.txtComponentesComponente.Text <> "" Then
            If Me.txtComponentesUso.Text <> "" Then

                Call AbrirConexionSql()
                Dim cmd As New SqlCommand("INSERT INTO COMPONENTES (COMPONENTE,USO) VALUES (@COMPONENTE,@USO)", cn)
                cmd.Parameters.AddWithValue("@COMPONENTE", Me.txtComponentesComponente.Text)
                cmd.Parameters.AddWithValue("@USO", Me.txtComponentesUso.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()
                'Call Form1.CargarGridComponentes()

            Else
                MessageBox.Show("Describa el Uso del Componente")
            End If
        Else
            MessageBox.Show("Escriba el Componente")
        End If
    End Sub
End Class
