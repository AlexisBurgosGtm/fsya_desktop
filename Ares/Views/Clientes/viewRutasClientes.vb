

Public Class viewRutasClientes

    Dim objEmpleados As New ClassEmpleados
    Dim objClientes As New classClientes(GlobalEmpNit)

    Dim boolEditando As Boolean

    Private Sub viewRutasClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarVendedores()
        Call CargarGrid()

    End Sub

    Private Sub CargarGrid()

        Me.GridListado.DataSource = Nothing
        Me.GridListado.DataSource = objClientes.getTblRutas()
        Me.GridListado.Refresh()

    End Sub

    Private Sub LimpiarDatos()
        Me.txtCodigo.Text = ""
        Me.txtDescripcion.Text = ""
    End Sub

    Private Sub CargarVendedores()

        With Me.cmbVendedor
            .DataSource = objEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 3)
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"
        End With
    End Sub


    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        boolEditando = False
        Call LimpiarDatos()
        Me.txtCodigo.Enabled = True
        Me.FlyoutPanelDatosCliente.ShowPopup()
        Me.btnEliminarRuta.Visible = False
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.FlyoutPanelDatosCliente.HidePopup()

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Dim codigo As Integer = Integer.Parse(Me.txtCodigo.Text)
            Dim descripcion As String = Me.txtDescripcion.Text
            Dim codemp As Integer = Integer.Parse(Me.cmbVendedor.SelectedValue)

            If boolEditando = True Then
                'EDITANDO
                If Confirmacion("¿Está seguro que desea EDITAR esta Ruta?", Me.ParentForm) = True Then
                    Me.txtCodigo.Enabled = False
                    If objClientes.editRutaCliente(codigo, descripcion, codemp) = True Then
                        MsgBox("Ruta guardada exitosamente!!")
                        Call CargarGrid()
                        Me.btnCancelar.PerformClick()
                    Else
                        MsgBox("No se pudo Guardar esta Ruta")
                    End If
                End If
            Else
                'GUARDANDO
                If objClientes.verifyCodRuta(codigo) = False Then

                    If Confirmacion("¿Está seguro que desea GUARDAR esta nueva Ruta?", Me.ParentForm) = True Then
                        If objClientes.insertRutaCliente(codigo, descripcion, codemp) = True Then
                            MsgBox("Ruta guardada exitosamente!!")
                            Call CargarGrid()
                            Me.btnCancelar.PerformClick()
                        Else
                            MsgBox("No se pudo Guardar esta Ruta")
                        End If
                    End If
                Else
                    MsgBox("Lo siento, este código ya existe, intente con otro")
                End If

            End If


        Catch ex As Exception
            MsgBox("Debe llenar todos los campos. Error: " + ex.ToString)
        End Try

    End Sub

    Private Sub GridViewListado_DoubleClick(sender As Object, e As EventArgs) Handles GridViewListado.DoubleClick

        drw = Nothing
        Try
            drw = Me.GridViewListado.GetFocusedDataRow
        Catch ex As Exception

        End Try


        If Confirmacion("¿Está seguro que desea Editar esta Ruta?", Me.ParentForm) = True Then
            Try
                boolEditando = True
                Me.txtCodigo.Text = drw.Item(0).ToString
                Me.txtDescripcion.Text = drw.Item(1).ToString
                Me.cmbVendedor.SelectedValue = CType(drw.Item(2), Integer)
                Me.FlyoutPanelDatosCliente.ShowPopup()
                Me.btnEliminarRuta.Visible = True
            Catch ex As Exception
                MsgBox("No se pudo cargar los datos para editar. Error: " + ex.ToString)
            End Try
        End If

    End Sub

    Dim drw As DataRow
    Private Sub GridViewListado_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewListado.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewListado.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEliminarRuta_Click(sender As Object, e As EventArgs) Handles btnEliminarRuta.Click
        If Confirmacion("¿Está seguro que desea ELIMINAR esta Ruta?", Me.ParentForm) = True Then
            If objClientes.deleteRutaCliente(Integer.Parse(Me.txtCodigo.Text)) = True Then
                MsgBox("Ruta Eliminada exitosamente!!")
                Call CargarGrid()
                Me.btnCancelar.PerformClick()
            Else
                MsgBox("No se pudo Eliminar. Error: " + GlobalDesError)
            End If
        End If
    End Sub

    Private Sub GridViewListado_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridViewListado.SelectionChanged
        drw = Nothing
        Try
            drw = Me.GridViewListado.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtDescripcion.select()
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbVendedor.select()
        End If
    End Sub

    Private Sub cmbVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardar.select()
        End If
    End Sub


End Class
