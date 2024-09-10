Public Class viewServidores

    Dim objServidores As New classServers
    Dim drw As DataRow

    Private Sub viewServidores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()

    End Sub


    Private Sub CargarGrid()

        Me.GridListado.DataSource = Nothing
        Me.GridListado.DataSource = objServidores.getTblServers()

    End Sub

    Private Sub GridViewListado_DoubleClick(sender As Object, e As EventArgs) Handles GridViewListado.DoubleClick
        If getConfirmacion("¿Está seguro que desea Eliminar este servidor?") = True Then
            If getConfirmacion("¿Está completamente seguro que desea Eliminar este servidor?") = True Then

                If objServidores.delete_server(CType(drw.Item(0), Integer)) = True Then
                    Call CargarGrid()
                Else
                    MsgBox("No se pudo eliminar")
                End If

            End If
            End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If getConfirmacion("¿Está seguro que quiere crear este nuevo Servidor?") = True Then
            If objServidores.insert_server(Me.txtSucursal.Text, Me.txtServer.Text, Me.txtDb.Text, Me.txtUser.Text, Me.txtPass.Text) = True Then
                Me.txtSucursal.Text = ""
                Me.txtServer.Text = ""
                Me.txtUser.Text = ""
                Me.txtPass.Text = ""
                Call CargarGrid()
            Else
                MsgBox("No se pudo guardar")
            End If
        End If
    End Sub

    Private Sub GridViewListado_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewListado.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewListado.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

End Class
