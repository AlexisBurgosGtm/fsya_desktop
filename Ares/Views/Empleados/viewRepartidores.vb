Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewRepartidores

    Dim drw As DataRow
    Dim objRepartidores As New classRepartidores

    Private Sub viewRepartidores_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If SelectedForm = "SYNC" Then
            Me.btnNuevo.Visible = False
            Me.btnCancelarDialog.Visible = True
            Call CargarGrid(False)
        Else
            Me.btnNuevo.Visible = True
            Me.btnCancelarDialog.Visible = False
            Call CargarGrid(True)
        End If

    End Sub

    Private Sub TileViewRepartidores_DoubleClick(sender As Object, e As EventArgs) Handles TileViewRepartidores.DoubleClick
        If SelectedForm = "SYNC" Then
            'CODIGO data.Item(0).ToString
            'DESCRIPCION data.Item(2).ToString
            GlobalInteger = CType(drw.Item(0), Integer)
            Me.btnAceptarDialog.PerformClick()

        Else
            Me.RadMenRepartidores.ShowPopup(MousePosition)
        End If

    End Sub

    Private Sub TileViewRepartidores_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TileViewRepartidores.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.TileViewRepartidores.GetFocusedDataRow

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TileViewRepartidores_ItemCustomize(sender As Object, e As DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs) Handles TileViewRepartidores.ItemCustomize
        Try
            If TileViewRepartidores.GetRowCellValue(e.RowHandle, TileViewRepartidores.Columns("ACTIVO")).ToString = "1" Then
                e.Item.AppearanceItem.Normal.BackColor = Color.LightSalmon
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub CargarGrid(ByVal MostrarDeshabilitados As Boolean)
        Me.GridRepartidores.DataSource = Nothing
        Me.GridRepartidores.DataSource = objRepartidores.tblRepartidores(GlobalEmpNit, MostrarDeshabilitados)
        Me.GridRepartidores.RefreshDataSource()
    End Sub




#Region " ** DETALLES ** "
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarCampos()
        Me.btnGuardar.Visible = True

        Me.NavFrameRepartidores.SelectedPage = NP_Detalles
    End Sub

    Private Sub CargarDatosRepartidor(ByVal edit As Boolean, ByVal data As DataRow)

        If edit = True Then
            Me.txtCodigo.Text = data.Item(0).ToString
            Me.btnGuardar.Visible = True
        Else
            Me.txtCodigo.Text = ""
            Me.btnGuardar.Visible = False
        End If

        Me.txtNit.Text = data.Item(1).ToString
        Me.txtDescripcion.Text = data.Item(2).ToString
        Me.txtDireccion.Text = data.Item(3).ToString
        Me.txtTelefono.Text = data.Item(4).ToString
        Me.txtContacto.Text = data.Item(5).ToString
        Me.txtContactoTel.Text = data.Item(6).ToString
        Me.txtWhatsapp.Text = data.Item(8).ToString
        Me.txtEmail.Text = data.Item(7).ToString
        Me.txtClave.Text = data.Item(10).ToString
    End Sub

    Private Sub LimpiarCampos()
        Me.txtCodigo.Text = ""
        Me.txtNit.Text = ""
        Me.txtDescripcion.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtContacto.Text = ""
        Me.txtContactoTel.Text = ""
        Me.txtWhatsapp.Text = ""
        Me.txtEmail.Text = ""
        Me.txtClave.Text = ""
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call LimpiarCampos()
        Me.NavFrameRepartidores.SelectedPage = NP_Listado
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.txtNit.Text <> "" Then
            If Me.txtDescripcion.Text <> "" Then
                If Me.txtDireccion.Text <> "" Then
                Else
                    Me.txtDireccion.Text = "Ciudad"
                End If
                If Me.txtTelefono.Text <> "" Then
                Else
                    Me.txtTelefono.Text = "SN"
                End If
                If Me.txtContacto.Text <> "" Then
                Else
                    Me.txtContacto.Text = "SN"
                End If
                If Me.txtContactoTel.Text <> "" Then
                Else
                    Me.txtContactoTel.Text = "SN"
                End If
                If Me.txtWhatsapp.Text <> "" Then
                Else
                    Me.txtWhatsapp.Text = "SN"
                End If
                If Me.txtEmail.Text <> "" Then
                Else
                    Me.txtEmail.Text = "SN"
                End If
                If Me.txtClave.Text <> "" Then
                Else
                    Me.txtClave.Text = "123"
                End If

                If Confirmacion("¿Está seguro que desea Guardar este Repartidor?", Me.ParentForm) = True Then

                    If Me.txtCodigo.Text <> "" Then
                        If objRepartidores.EditRepartidor(GlobalEmpNit, CType(Me.txtCodigo.Text, Integer), Me.txtNit.Text, Me.txtDescripcion.Text, Me.txtDireccion.Text, Me.txtTelefono.Text, Me.txtContacto.Text, Me.txtContactoTel.Text, Me.txtWhatsapp.Text, Me.txtEmail.Text, Me.txtClave.Text) = True Then
                            Call CargarGrid(True)
                            Me.NavFrameRepartidores.SelectedPage = NP_Listado
                            'Call Form1.EnviarNotificacionesEmail(3, "Ares te Informa: Actualización de datos de Repartidor/Mensajero", "Se actualizó los datos del repartidor " & Me.txtDescripcion.Text)
                            Call LimpiarCampos()
                            Call Aviso("Confirmación", "Repartidor Actualizado exitosamente", Me.ParentForm)

                        Else
                            'MsgBox(GlobalDesError)
                            Call Aviso("ERROR", "No se pudo guardar", Me.ParentForm)
                        End If
                    Else
                        If objRepartidores.InsertNuevoRepartidor(GlobalEmpNit, Me.txtNit.Text, Me.txtDescripcion.Text, Me.txtDireccion.Text, Me.txtTelefono.Text, Me.txtContacto.Text, Me.txtContactoTel.Text, Me.txtWhatsapp.Text, Me.txtEmail.Text, Me.txtClave.Text) = True Then
                            Call CargarGrid(True)
                            Me.NavFrameRepartidores.SelectedPage = NP_Listado
                            'Call Form1.EnviarNotificacionesEmail(3, "Ares te Informa: Creación de nuevo Repartidor/Mensajero", "Creó el repartidor " & Me.txtDescripcion.Text)
                            Call LimpiarCampos()
                            Call Aviso("Confirmación", "Repartidor guardado exitosamente", Me.ParentForm)

                        Else
                            'MsgBox(GlobalDesError)
                            Call Aviso("ERROR", "No se pudo guardar", Me.ParentForm)
                        End If
                    End If





                End If


            Else
                MsgBox("Escriba un Nombre o Descripción del Repartidor")
            End If
        Else
            MsgBox("Indique un NIT o Identificación para el Repartidor")
        End If

    End Sub

    Private Sub viewRepartidores_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            Me.btnNuevo.PerformClick()
        End If
    End Sub



    Private Sub btnRadialDetalles_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadialDetalles.ItemClick

        Call CargarDatosRepartidor(False, drw)
        Me.NavFrameRepartidores.SelectedPage = NP_Detalles
    End Sub

    Private Sub btnRadialEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadialEditar.ItemClick
        Call CargarDatosRepartidor(True, drw)
        Me.NavFrameRepartidores.SelectedPage = NP_Detalles
    End Sub

    Private Sub btnRadialDeshabilitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadialDeshabilitar.ItemClick
        If Confirmacion("¿Está seguro que desea DESHABILITAR/HABILITAR este Repartidor/Mensajero?", Me.ParentForm) = True Then
            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                Dim codrep As Integer = CType(drw.Item(0), Integer)
                Dim st As Integer = CType(drw.Item(9), Integer)
                If objRepartidores.DeshabRepartidor(GlobalEmpNit, codrep, st) = True Then
                    Call CargarGrid(True)
                Else
                    MsgBox("Ha ocurrido un Error al Deshabilitar/Habilitar este Item. Error: " & GlobalDesError)
                End If



            End If
        End If
    End Sub

    Private Sub btnRadialEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadialEliminar.ItemClick

        If Confirmacion("¿Está seguro que desea eliminar este Repartidor/Mensajero?", Me.ParentForm) = True Then
            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
                Dim codrep As Integer = CType(drw.Item(0), Integer)
                If objRepartidores.DeleteRepartidor(GlobalEmpNit, codrep) = True Then
                    Call CargarGrid(True)
                Else
                    MsgBox("Ha ocurrido un Error al Eliminar este Item. Error: " & GlobalDesError)
                End If
            End If
        End If
    End Sub

    Private Sub btnRadialRepEntregas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadialRepEntregas.ItemClick
        Dim objRep As New ClassReports()
        If FlyoutDialog.Show(Me.ParentForm, New viewFechaInicialFinal) = DialogResult.OK Then
            If objRep.rptVentasRepartidor(GlobalEmpNit, GlobalParamFechaInicial, GlobalParamFechaFinal, CType(drw.Item(0), Integer)) = True Then
            Else
                MsgBox("No se logró cargar el reporte. Error: " & GlobalDesError)
            End If
        End If

    End Sub

    Private Sub SimpleButton1_MouseDown(sender As Object, e As MouseEventArgs) Handles SimpleButton1.MouseDown
        Me.txtClave.Properties.PasswordChar = ""
    End Sub

    Private Sub SimpleButton1_MouseUp(sender As Object, e As MouseEventArgs) Handles SimpleButton1.MouseUp
        Me.txtClave.Properties.PasswordChar = "*"
    End Sub


#End Region


End Class
