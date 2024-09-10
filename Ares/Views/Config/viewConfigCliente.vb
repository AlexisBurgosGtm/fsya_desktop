Imports Microsoft.Win32

Public Class viewConfigCliente

    Private Sub viewConfigCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub switchModoPos_Toggled(sender As Object, e As EventArgs) Handles switchModoPos.Toggled
        If Me.switchModoPos.IsOn = True Then
            SetRegDataClient("ModoPos", "SI")
            GlobalClienteModoPos = True
        Else
            SetRegDataClient("ModoPos", "NO")
            GlobalClienteModoPos = False
        End If
    End Sub



End Class
