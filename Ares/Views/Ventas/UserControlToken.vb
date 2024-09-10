Imports System.Data.SqlClient

Public Class UserControlToken

    Private Sub txtTOKEN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTOKEN.KeyDown

        Call ConsultToken()

        If ConsultToken() = True Then

            Me.btnAceptar.PerformClick()

        Else

            MsgBox("Token inexistente.")

        End If

    End Sub

    Private Function ConsultToken() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strHostConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT REPLACE(TOKEN, @TOKEN, 1) AS TOKEN FROM FSYA_SYNC.dbo.TOKEN_NC WHERE TOKEN = @TOKEN", cn)
                cmd.Parameters.AddWithValue("@TOKEN", Me.txtTOKEN.Text)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                MsgBox(ex.ToString + " En consulta de token SYNC.")
                r = True
            End Try
        End Using

        Return r

    End Function

End Class
