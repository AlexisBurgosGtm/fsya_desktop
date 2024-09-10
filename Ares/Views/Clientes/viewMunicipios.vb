Public Class viewMunicipios


    Private Sub viewMunicipios_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call CargarGridDepartamentos()
        Call CargarGridMunicipios()

    End Sub

    Dim objclie As New classClientes(GlobalEmpNit)

    Private Sub CargarGridMunicipios()

        Me.gridMunicipios.DataSource = Nothing
        Me.gridMunicipios.DataSource = objclie.GetTblMunicipios()


    End Sub


    Private Sub CargarGridDepartamentos()
        Me.gridDepartamentos.DataSource = Nothing
        Me.gridDepartamentos.DataSource = objclie.GetTblDepartamentos

    End Sub

    Private Sub btnGuardarDepto_Click(sender As Object, e As EventArgs) Handles btnGuardarDepto.Click
        If getConfirmacion("¿Está seguro que desea Guardar el Nuevo Departamento?") = True Then

            If objclie.insert_mundepto(CType(Me.txtCodDepto.Text, Integer), Me.txtDesDepto.Text, "D") = True Then
                Call CargarGridDepartamentos()
            Else
                MsgBox("No se pudo guardar el Departamento")
            End If

        End If
    End Sub

    Private Sub btnGuardarMunicipio_Click(sender As Object, e As EventArgs) Handles btnGuardarMunicipio.Click
        If getConfirmacion("¿Está seguro que desea Guardar el Nuevo Municipio?") = True Then

            If objclie.insert_mundepto(CType(Me.txtCodMun.Text, Integer), Me.txtDesMun.Text, "M") = True Then
                Call CargarGridMunicipios()
            Else
                MsgBox("No se pudo guardar el Municipio")
            End If

        End If
    End Sub


    Dim drwd As DataRow

    Private Sub GridViewDepartamentos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDepartamentos.FocusedRowChanged
        drwd = Nothing

        Try
            drwd = Me.GridViewDepartamentos.GetFocusedDataRow
        Catch ex As Exception

        End Try

    End Sub





    Dim drwm As DataRow

    Private Sub GridViewMunicipios_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewMunicipios.FocusedRowChanged
        drwm = Nothing
        Try
            drwm = Me.GridViewMunicipios.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewMunicipios_DoubleClick(sender As Object, e As EventArgs) Handles GridViewMunicipios.DoubleClick

        If getConfirmacion("¿Está seguro que desea ELIMINAR este Municipio?") = True Then

            If objclie.delete_mundepto(CType(drwm.Item(0), Integer), "M") = True Then
                Call CargarGridMunicipios()
            Else
                MsgBox("No se pudo Eliminar este Municipio")
            End If

        End If


    End Sub


    Private Sub GridViewDepartamentos_DoubleClick(sender As Object, e As EventArgs) Handles GridViewDepartamentos.DoubleClick

        If getConfirmacion("¿Está seguro que desea ELIMINAR este Departamento?") = True Then

            If objclie.delete_mundepto(CType(drwd.Item(0), Integer), "D") = True Then
                Call CargarGridDepartamentos()
            Else
                MsgBox("No se pudo Eliminar este Departamento")
            End If

        End If


    End Sub




End Class
