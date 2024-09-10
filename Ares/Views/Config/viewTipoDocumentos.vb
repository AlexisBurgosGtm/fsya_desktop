Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewTipoDocumentos
    Private Sub viewTipoDocumentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()

        With Me.cmbTipoDoc
            .DataSource = objTipoDocumentos.tblTipos()
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "TIPO"
        End With

    End Sub


    Dim objTipoDocumentos As New ClassTipoDocumentos(GlobalEmpNit)

    Private Sub CargarGrid()

        Me.GridListado.DataSource = Nothing
        Me.GridListado.DataSource = objTipoDocumentos.tblTipoDocumentos

    End Sub

    Dim drw As DataRow

    Private Sub GridViewListado_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewListado.FocusedRowChanged
        Try

            drw = Nothing
            drw = Me.GridViewListado.GetFocusedDataRow

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridViewListado_DoubleClick(sender As Object, e As EventArgs) Handles GridViewListado.DoubleClick
        Me.RadialMenu.ShowPopup(MousePosition)
    End Sub

    Private Sub GridViewListado_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewListado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.RadialMenu.ShowPopup(MousePosition)
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarCampos()
        Me.NavigationFrame.SelectedPage = NP_Edicion
        Me.cmbTipoDoc.select()

    End Sub

    Private Sub LimpiarCampos()
        Me.txtId.Text = ""
        Me.txtCoddoc.Text = ""
        Me.txtCorrelativo.Text = ""
        Me.txtDesdoc.Text = ""

        Me.txtResolucion.Text = ""
        Me.txtAutorizacion.Text = ""
        Me.txtFrase1.Text = ""
        Me.txtFrase2.Text = ""
        Me.txtFormato.Text = ""

        Me.cmbTipoDoc.Enabled = True
        Me.txtCoddoc.Enabled = True

    End Sub

    Private Sub BarButtonItemEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEditar.ItemClick
        Try
            Me.cmbTipoDoc.Enabled = False
            Me.txtCoddoc.Enabled = False

            Me.txtId.Text = drw.Item(0).ToString
            Me.txtCoddoc.Text = drw.Item(1).ToString
            Me.txtCorrelativo.Text = drw.Item(2).ToString()
            Me.txtDesdoc.Text = drw.Item(3).ToString()
            Me.cmbTipoDoc.SelectedValue = drw.Item(4).ToString
            Me.txtResolucion.Text = drw.Item(5).ToString
            Me.txtAutorizacion.Text = drw.Item(6).ToString
            Me.txtFrase1.Text = drw.Item(7).ToString
            Me.txtFrase2.Text = drw.Item(8).ToString
            Me.txtFormato.Text = drw.Item(9).ToString

            Me.NavigationFrame.SelectedPage = NP_Edicion

        Catch ex As Exception
            'MsgBox("No pude cargar los datos para editarlos: " & ex.ToString)
        End Try

    End Sub

    Private Sub BarButtonItemEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemEliminar.ItemClick
        If Confirmacion("¿Está seguro que desea Eliminar este tipo de documento?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
                If objTipoDocumentos.fcn_DeleteTipoDocumento(Integer.Parse(drw(0)), drw.Item(1).ToString) = True Then
                    Call Aviso("Éxito al Eliminar", "Tipo de Documento eliminado exitosamente", Me.ParentForm)
                    Call CargarGrid()
                Else
                    Call Aviso("No se pudo Eliminar", "Si tiene documentos asociados a este Documento, no podrá Eliminarlo", Me.ParentForm)
                End If
            End If

        End If

    End Sub

    Private Sub cmbTipoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCoddoc.select()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Call LimpiarCampos()
        Me.NavigationFrame.SelectedPage = NP_Listado

    End Sub


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If Me.txtCoddoc.Text <> "" Then
        Else
            MsgBox("Escriba la Serie del Documento")
            GoTo NoProcede
        End If
        If Me.txtDesdoc.Text <> "" Then
        Else
            MsgBox("Escriba la descripción del Documento")
            GoTo NoProcede
        End If
        If Me.cmbTipoDoc.SelectedIndex >= 0 Then
        Else
            MsgBox("Seleccione el Tipo de Documento")
            GoTo NoProcede
        End If

        If Me.txtResolucion.Text <> "" Then
        Else
            Me.txtResolucion.Text = "SN"
        End If
        If Me.txtAutorizacion.Text <> "" Then
        Else
            Me.txtAutorizacion.Text = "SN"
        End If
        If Me.txtFrase1.Text <> "" Then
        Else
            Me.txtFrase1.Text = "SN"
        End If
        If Me.txtFrase2.Text <> "" Then
        Else
            Me.txtFrase2.Text = "SN"
        End If
        If Me.txtFormato.Text <> "" Then
        Else
            Me.txtFormato.Text = "SN"
        End If

Procede:

        If Me.txtId.Text <> "" Then

            If Me.txtCorrelativo.Text <> "" Then
            Else
                MsgBox("Escriba el número de Correlativo")
                GoTo NoProcede
            End If

            'edita si existe el id
            If objTipoDocumentos.fcn_UpdateTipoDocumento(Integer.Parse(Me.txtId.Text), Me.txtCoddoc.Text, Double.Parse(Me.txtCorrelativo.Text), Me.txtDesdoc.Text, Me.txtResolucion.Text, Me.txtAutorizacion.Text, Me.txtFrase1.Text, Me.txtFrase2.Text, Me.txtFormato.Text) = True Then
                Call Aviso("Actualización exitosa", "El tipo de documento se ha actualizado exitosamente", Me.ParentForm)
                Call LimpiarCampos()
                Me.NavigationFrame.SelectedPage = NP_Listado
                Call CargarGrid()

            Else
                MsgBox("Ha ocurrido un error y no se pudo actualizar. Este es el error: " & GlobalDesError)
            End If

        Else
            'guarda nuevo si no
            If objTipoDocumentos.fcn_SaveTipoDocumento(Me.cmbTipoDoc.SelectedValue.ToString, Me.txtCoddoc.Text, Me.txtDesdoc.Text, Me.txtResolucion.Text, Me.txtAutorizacion.Text, Me.txtFrase1.Text, Me.txtFrase2.Text, Me.txtFormato.Text) = True Then
                Call Aviso("Éxito al Guardar", "El tipo de documento se ha guardado exitosamente", Me.ParentForm)
                Call LimpiarCampos()
                Me.NavigationFrame.SelectedPage = NP_Listado
                Call CargarGrid()
            Else
                MsgBox("Ha ocurrido un error y no se pudo Guardar. Este es el error: " & GlobalDesError)
            End If

        End If

NoProcede:
        Exit Sub

    End Sub

    Private Sub txtFrase2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFrase2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtFormato.select()
        End If
    End Sub

    Private Sub BarButtonItemHabilitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemHabilitar.ItemClick

        If objTipoDocumentos.enabledDisableCoddoc(drw.Item(1).ToString, "SI") = True Then
            Call CargarGrid()
        End If
    End Sub

    Private Sub BarButtonItemDeshabilitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemDeshabilitar.ItemClick
        If objTipoDocumentos.enabledDisableCoddoc(drw.Item(1).ToString, "NO") = True Then
            Call CargarGrid()
        End If
    End Sub

End Class
