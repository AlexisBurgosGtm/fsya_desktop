Public Class viewClientesVehiculos
    Dim drw As DataRow
    Dim objVehiculos As New classVehiculos()
    Dim modo As String

    Sub New(ByVal _modo As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        modo = _modo

        'modos:
        '1) catalogo: para funcionar como catálogo general
        '2) modal: para seleccionar un vehículo desde la orden de trabajo

    End Sub
    Private Sub viewClientesVehiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()
        Call CargarCombobox()

        Me.btnGuardar.Visible = False
        Me.btnCancelar.Visible = False
        Me.btnNuevo.Visible = True

        If modo = "CATALOGO" Then
            Me.btnCerrarVentana.Visible = False
        End If

    End Sub
    Private Sub viewClientesVehiculos_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            Me.btnNuevo.PerformClick()
        End If

    End Sub

    Private Sub CargarGrid()
        Me.GridVehiculos.DataSource = Nothing
        Me.GridVehiculos.DataSource = objVehiculos.SelectVehiculosClientesTodos(GlobalEmpNit)
        Me.GridVehiculos.RefreshDataSource()
    End Sub

    Private Sub CargarCombobox()
        Dim objClientes As New classClientes(GlobalEmpNit)

        Dim objMantenimientos As New ClassMantenimientos(GlobalEmpNit)
        With Me.cmbMarca
            .DataSource = objMantenimientos.tblMarcas
            .ValueMember = "CODIGO"
            .DisplayMember = "DESCRIPCION"
        End With

    End Sub
    Private Sub LimpiarDatos()
        Me.txtCodigo.Text = ""
        Me.txtNoPlaca.Text = ""
        Me.txtDescripcion.Text = ""
        Me.txtModelo.Text = ""
        Me.txtLinea.Text = ""
        Me.txtColor.Text = ""
        'Me.cmbCliente.Text = ""
        Me.cmbMarca.Text = ""
    End Sub

    Private Sub GridViewVehiculos_DoubleClick(sender As Object, e As EventArgs) Handles GridViewVehiculos.DoubleClick
        If modo = "CATALOGO" Then
            Me.RadMenVehiculos.ShowPopup(MousePosition)
        End If
        If modo = "MODAL" Then
            SelectedCode = CType(drw.Item(0), Integer)
            SelectedDescripcion = drw.Item(2).ToString
            Me.btnAceptarVentana.PerformClick()
        End If
    End Sub


    Private Sub GridViewVehiculos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewVehiculos.KeyDown
        If e.KeyCode = Keys.Enter Then
            If modo = "CATALOGO" Then
                Me.RadMenVehiculos.ShowPopup(MousePosition)
            End If
            If modo = "MODAL" Then
                SelectedCode = CType(drw.Item(0), Integer)
                SelectedDescripcion = drw.Item(2).ToString
                Me.btnAceptarVentana.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridViewVehiculos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewVehiculos.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewVehiculos.GetFocusedDataRow

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Confirmacion("¿Está seguro que desea guardar estos datos?", Me.ParentForm) = True Then

            If Me.txtNoPlaca.Text <> "" Then
                If Me.txtDescripcion.Text <> "" Then
                    If Me.txtLinea.Text <> "" Then
                    Else
                        Me.txtLinea.Text = "SN"
                    End If
                    If Me.txtModelo.Text <> "" Then
                    Else
                        Me.txtModelo.Text = "0000"
                    End If
                    If Me.txtColor.Text <> "" Then
                    Else
                        Me.txtColor.Text = "SN"
                    End If
                    If Me.cmbMarca.SelectedIndex >= 0 Then
                        If Me.txtCodigo.Text <> "" Then
                            If objVehiculos.UpdateVehiculoCliente(CType(Me.txtCodigo.Text, Integer), GlobalEmpNit, Me.txtNoPlaca.Text, Me.txtDescripcion.Text, Me.txtLinea.Text, CType(Me.txtModelo.Text, Integer), Me.txtColor.Text, CType(Me.cmbMarca.SelectedValue, Integer), "SN", 0) = True Then
                                Call CargarGrid()
                                Call LimpiarDatos()
                                Me.btnGuardar.Visible = False
                                Me.btnCancelar.Visible = False
                                Me.btnNuevo.Visible = True
                                MsgBox("Vehículo actualizado con éxito")
                            Else
                                MsgBox("No se pudo guardar. Error: " & GlobalDesError)
                            End If

                        Else
                            If objVehiculos.InsertVehiculoCliente(GlobalEmpNit, Me.txtNoPlaca.Text, Me.txtDescripcion.Text, Me.txtLinea.Text, CType(Me.txtModelo.Text, Integer), Me.txtColor.Text, CType(Me.cmbMarca.SelectedValue, Integer), "SN", 0) = True Then
                                Call CargarGrid()
                                Call LimpiarDatos()
                                Me.btnGuardar.Visible = False
                                Me.btnCancelar.Visible = False
                                Me.btnNuevo.Visible = True

                                MsgBox("Vehículo agregado con éxito")
                            Else
                                MsgBox("No se pudo guardar. Error: " & GlobalDesError)
                            End If
                        End If

                    Else
                        MsgBox("Seleccione una Marca Válida")
                    End If
                Else
                    MsgBox("Escriba la descripción del producto")
                End If
            Else
                MsgBox("Escriba el Número de Placa del Vehículo")
                End If



            End If

    End Sub

    Private Sub cmdClientesCancelarEdit_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Call LimpiarDatos()
        Me.btnGuardar.Visible = False
        Me.btnCancelar.Visible = False
        Me.btnNuevo.Visible = True
    End Sub

    Private Sub RadMenBtnEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenBtnEditar.ItemClick
        Me.txtCodigo.Text = drw.Item(0).ToString
        Me.txtNoPlaca.Text = drw.Item(1).ToString
        Me.txtDescripcion.Text = drw.Item(2).ToString
        Me.txtLinea.Text = drw.Item(3).ToString
        Me.txtModelo.Text = drw.Item(4).ToString
        Me.txtColor.Text = drw.Item(5).ToString
        'Me.cmbCliente.SelectedValue = drw.Item(7)
        Me.cmbMarca.SelectedValue = drw.Item(9)

        Me.btnGuardar.Visible = True
        Me.btnCancelar.Visible = True
        Me.btnNuevo.Visible = False
    End Sub

    Private Sub RadMenBtnDeshabilitar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub
    Private Sub RadMenBtnHistorial_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenBtnHistorial.ItemClick
        Dim objReports As New ClassReports
        If objReports.rptServiciosVehiculo(GlobalEmpNit, CType(drw.Item(0), Integer)) = True Then

        Else
            MsgBox("No se pudo cargar el historial del Vehículo. Error: " & GlobalDesError)
        End If
    End Sub

    Private Sub RadMenBtnEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenBtnEliminar.ItemClick
        If Confirmacion("¿Está seguro que desea Eliminar este Vehiculo?", Me.ParentForm) = True Then
            If objVehiculos.DeleteVehiculoCliente(GlobalEmpNit, CType(drw(0), Integer)) = True Then
                MsgBox("Vehiculo Eliminado Exitosamente")
                Call CargarGrid()
            Else
                MsgBox("No se pudo eliminar este vehículo. Error: " & GlobalDesError)
            End If
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Call LimpiarDatos()

        Me.btnGuardar.Visible = True
        Me.btnCancelar.Visible = True
        Me.btnNuevo.Visible = False

        Me.txtNoPlaca.select()
        'Me.cmbCliente.select()

    End Sub

    Private Sub cmbMarca_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMarca.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardar.select()
        End If
    End Sub


End Class
