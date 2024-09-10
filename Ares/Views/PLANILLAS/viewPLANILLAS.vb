Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo

Public Class UserControl1

    Dim objEmpleados As New ClassEmpleados()
    Dim drw As DataRow


    Private Sub ViewEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()
        Call CargarCombobox()

    End Sub


    Private Sub CargarGrid()

        Me.GridEmpleados.DataSource = Nothing
        Me.GridEmpleados.DataSource = objEmpleados.tblListaEmpleadosTodos(GlobalEmpNit)
        Me.GridEmpleados.RefreshDataSource()

    End Sub

    Private Sub CargarCombobox()
        Dim objClientes As New classClientes(GlobalEmpNit)

        With Me.cmbTipoEmpleado
            .DataSource = objEmpleados.tblTiposEmpleado
            .ValueMember = "CODTIPOEMPLEADO"
            .DisplayMember = "DESTIPOEMPLEADO"
        End With

        With Me.cmbMunicipio
            .DataSource = objClientes.GetTblMunicipios
            .ValueMember = "CODMUNICIPIO"
            .DisplayMember = "DESMUNICIPIO"
        End With


        With Me.cmbDepto
            .DataSource = objClientes.GetTblDepartamentos
            .ValueMember = "CODDEPARTAMENTO"
            .DisplayMember = "DESDEPARTAMENTO"
        End With

    End Sub

    Private Sub LimpiarDatos()
        Me.txtCodEmpleado.Text = ""
        Me.txtNomEmpleado.Text = ""
        Me.txtDpi.Text = ""
        Me.txtIgss.Text = ""
        Me.txtDirEmpleado.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtWhatsapp.Text = ""
        Me.txtClave.Text = ""
        Me.txtObs.Text = ""
    End Sub

    Private Sub GridViewEmpleados_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewEmpleados.FocusedRowChanged
        Try

            drw = Nothing
            drw = Me.GridViewEmpleados.GetFocusedDataRow

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarDatosEmpleado()
        Try
            Me.txtCodEmpleado.Text = drw.Item(0).ToString
            Me.cmbTipoEmpleado.SelectedValue = drw.Item(1)
            Me.txtDpi.Text = drw.Item(2).ToString
            Me.txtIgss.Text = drw.Item(3).ToString
            Me.txtNomEmpleado.Text = drw.Item(4).ToString
            Me.txtDirEmpleado.Text = drw.Item(5)
            Me.cmbMunicipio.SelectedValue = drw.Item(6)
            Me.cmbDepto.SelectedValue = drw.Item(7)
            Me.txtTelefono.Text = drw.Item(8).ToString
            Me.txtWhatsapp.Text = drw.Item(9).ToString
            Me.txtObs.Text = drw.Item(11).ToString
            Me.txtClave.Text = drw.Item(14).ToString
            EmpClaveActual = drw.Item(14).ToString
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub GridViewEmpleados_DoubleClick(sender As Object, e As EventArgs) Handles GridViewEmpleados.DoubleClick
        Try
            Me.RadMenEmpleados.ShowPopup(MousePosition)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmbTipoEmpleado_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoEmpleado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtDpi.select()
        End If
    End Sub

    Private Sub cmbMunicipio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMunicipio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbDepto.select()
        End If
    End Sub

    Private Sub cmbDepto_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDepto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtTelefono.select()
        End If
    End Sub

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub btnRadMenDetalle_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenDetalle.ItemClick

        Call CargarDatosEmpleado()
        Me.btnGuardar.Visible = False
        Me.btnCancelar.Visible = True

    End Sub

    Private Sub btnRadMenEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenEditar.ItemClick
        Call CargarDatosEmpleado()
        Me.btnGuardar.Visible = True
        Me.btnCancelar.Visible = True
    End Sub

    'BOTON DESHABILITAR
    Private Sub btnRadMenDeshabilitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenDeshabilitar.ItemClick

        If Confirmacion("¿Está seguro que desea DESHABILITAR este Empleado?", Me.ParentForm) = True Then
            If objEmpleados.habdesEmpleado(GlobalEmpNit, CType(drw.Item(0), Integer), "NO") = True Then
                MsgBox("Empleado DESHABILITADO exitosamente")
                Call CargarGrid()
            Else
                MsgBox("No se pudo DESHABILITAR. Error: " & GlobalDesError)
            End If

        End If

    End Sub

    'BOTON HABILITAR
    Private Sub btnMenuHabilitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuHabilitar.ItemClick
        If Confirmacion("¿Está seguro que desea HABILITAR este Empleado?", Me.ParentForm) = True Then
            If objEmpleados.habdesEmpleado(GlobalEmpNit, CType(drw.Item(0), Integer), "SI") = True Then
                MsgBox("Empleado HABILITADO exitosamente")
                Call CargarGrid()
            Else
                MsgBox("No se pudo HABILITAR. Error: " & GlobalDesError)
            End If

        End If
    End Sub

    Private Sub btnRadMenEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenEliminar.ItemClick
        If Confirmacion("¿Está seguro que desea Eliminar este Empleado?", Me.ParentForm) = True Then
            If objEmpleados.EliminarEmpleado(GlobalEmpNit, CType(drw.Item(0), Integer)) = True Then
                MsgBox("Empleado Eliminado exitosamente")
                Call CargarGrid()
            Else
                MsgBox("No se pudo eliminar. Error: " & GlobalDesError)
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.btnGuardar.Visible = True
        Me.btnCancelar.Visible = False
        Call LimpiarDatos()
    End Sub

    Dim EmpClaveActual As String = "" 'string privada para establecer la clave actual y evadir la verificacion


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        'EL CAMPO TELÉFONO SERÁ USADO PARA INDICAR EL MONTO DE 
        'OBJETIVO DE VENTAS DEL EMPLEADO

        If ValidarCampos() = True Then
            If Confirmacion("¿Está seguro que desea guardar este Empleado", Me.ParentForm) = True Then


                If Me.txtCodEmpleado.Text <> "" Then
                    If objEmpleados.EditEmpleado(CType(Me.txtCodEmpleado.Text, Integer), GlobalEmpNit, CType(Me.cmbTipoEmpleado.SelectedValue, Integer), Me.txtDpi.Text, Me.txtIgss.Text, Me.txtNomEmpleado.Text, Me.txtDirEmpleado.Text, CType(Me.cmbMunicipio.SelectedValue, Integer), CType(Me.cmbDepto.SelectedValue, Integer), Me.txtTelefono.Text, Me.txtWhatsapp.Text, "SN", Me.txtObs.Text, Me.txtClave.Text, EmpClaveActual) = True Then
                        MsgBox("Empleado guardado exitosamente")
                        Call CargarGrid()
                        Call LimpiarDatos()
                        Me.btnCancelar.Visible = False
                    Else
                        MsgBox("No se pudo guardar el Empleado. Error: " & GlobalDesError)
                    End If
                Else
                    If objEmpleados.InsertEmpleado(GlobalEmpNit, CType(Me.cmbTipoEmpleado.SelectedValue, Integer), Me.txtDpi.Text, Me.txtIgss.Text, Me.txtNomEmpleado.Text, Me.txtDirEmpleado.Text, CType(Me.cmbMunicipio.SelectedValue, Integer), CType(Me.cmbDepto.SelectedValue, Integer), Me.txtTelefono.Text, Me.txtWhatsapp.Text, "SN", Me.txtObs.Text, Me.txtClave.Text) = True Then
                        MsgBox("Empleado guardado exitosamente")
                        Call CargarGrid()
                        Call LimpiarDatos()
                        Me.btnCancelar.Visible = False
                    Else
                        MsgBox("No se pudo guardar el Empleado. Error: " & GlobalDesError)
                    End If
                End If
            End If
        End If

    End Sub


    Private Function ValidarCampos() As Boolean

        Dim result As Boolean

        If Me.txtDpi.Text <> "" Then
        Else
            Me.txtDpi.Text = "SN"
        End If

        If Me.txtIgss.Text <> "" Then
        Else
            Me.txtIgss.Text = "SN"
        End If

        If Me.txtNomEmpleado.Text <> "" Then
            If Me.txtDirEmpleado.Text <> "" Then
            Else
                Me.txtDirEmpleado.Text = "Ciudad"
            End If
            If Me.txtTelefono.Text <> "" Then
            Else
                Me.txtTelefono.Text = "1"
            End If
            If Me.txtWhatsapp.Text <> "" Then
            Else
                Me.txtWhatsapp.Text = "ENVIOS01"
            End If
            If Me.txtObs.Text <> "" Then
            Else
                Me.txtObs.Text = "SN"
            End If

            If Me.txtClave.Text <> "" Then

                result = True

            Else
                result = False
                MsgBox("Escriba la clave del empleado")
            End If
        Else
            result = False
            MsgBox("Escriba el nombre del Empleado")
        End If

        Return result

    End Function

End Class
