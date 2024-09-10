
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewGestionEmbarques

    Dim objEmbarques As New classEmbarques

    Private Sub viewGestionEmbarques_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'TAB GESTION PEDIDOS
        Me.txtFechaInicial.DateTime = Today.Date
        Me.txtFechaFinal.DateTime = Today.Date

        Call CargarComboboxes()
        Call CargarComboEmbarques()


        'TAB RESUMENES
        Me.TimerCargarEmbarques.Start()

        'TAB EMBARQUES


    End Sub



#Region " ** TAB GESTION PEDIDOS ** "

    Private Sub cmbCoddoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCoddoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnCargarGridFacturas.PerformClick()
        End If
    End Sub

    Private Sub txtFacInicial_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFacInicial.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtFacFinal.select()
        End If
    End Sub

    Private Sub txtFacFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFacFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbEmbarque.select()
        End If
    End Sub

    Private Sub cmbEmbarque_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEmbarque.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAsignarEmbarque.select()
        End If
    End Sub

    Private Sub cmbVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAsignarVendedor.select()
        End If
    End Sub


    Private Sub CargarComboboxes()

        'COMBO CODDOC
        Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
        With Me.cmbCoddoc
            .DataSource = objTipoDoc.tblCoddoc("FAC")
            .ValueMember = "CODDOC"
            .DisplayMember = "CODDOC"
        End With

        'COMBO VENDEDORES
        Dim objEmpleados As New ClassEmpleados
        With Me.cmbVendedor
            .DataSource = objEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 3)
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"
        End With

        'CARGAR COMBO MESES
        With Me.cmbEmbarquesMes
            .DataSource = objTipoDoc.tblMeses
            .DisplayMember = "DESMES"
            .ValueMember = "CODMES"
        End With

        Me.cmbEmbarquesMes.SelectedValue = Today.Month
        Me.cmbEmbarquesAnio.Text = Today.Year.ToString

    End Sub

    Private Sub CargarComboEmbarques()
        'COMBO EMBARQUES
        Dim objEmbarques As New classEmbarques
        With Me.cmbEmbarque
            .DataSource = objEmbarques.tblEmbarquesFechas(Me.txtFechaInicial.DateTime, Me.txtFechaFinal.DateTime)
            .ValueMember = "CODEMBARQUE"
            .DisplayMember = "CODEMBARQUE"
        End With



    End Sub

    Private Sub btnCargarGridFacturas_Click(sender As Object, e As EventArgs) Handles btnCargarGridFacturas.Click
        Call CargarGridFacturas()
        Call CargarComboEmbarques()
    End Sub

    Private Sub CargarGridFacturas()

        Dim tbl As New DataTable

        Dim inicial As Date = Me.txtFechaInicial.DateTime
        Dim final As Date = Me.txtFechaFinal.DateTime
        Dim coddoc As String = Me.cmbCoddoc.SelectedValue.ToString

        'MsgBox(String.Format("coddoc: {0}, Inicial: {1}, Final: {2}", coddoc, inicial.ToString, inicial.ToString))

        Me.gridFacturas.DataSource = Nothing
        Me.gridFacturas.DataSource = objEmbarques.tblListaFacturas(coddoc, inicial, final)

    End Sub


    Private Sub btnAsignarEmbarque_Click(sender As Object, e As EventArgs) Handles btnAsignarEmbarque.Click

        If Me.cmbEmbarque.SelectedIndex >= 0 Then
        Else
            MsgBox("Selecione un Embarque de la lista")
            Exit Sub
        End If


        If Me.txtFacInicial.Text <> "" Then
            If Me.txtFacFinal.Text <> "" Then
                If Double.Parse(Me.txtFacInicial.Text) <= Double.Parse(Me.txtFacFinal.Text) Then
                    If Confirmacion("¿Está seguro que desea Asignar este Embarque?", Me.ParentForm) Then
                        Dim objEmbarques As New classEmbarques
                        If objEmbarques.putEmbarque(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.txtFacInicial.Text), Double.Parse(Me.txtFacFinal.Text), Me.cmbEmbarque.SelectedValue.ToString) = True Then
                            MsgBox("Embarque asignado exitosamente !!")
                            Call CargarGridFacturas()
                        Else
                            MsgBox("No se pudo asignar el Embarque. Error: " + objEmbarques.DesError.ToString)
                        End If


                    End If
                Else
                    MsgBox("No puedes asignar una factura inicial mayor a la final")
                End If
            Else
                MsgBox("Indica la Factura Final (Al)")
            End If
        Else
            MsgBox("Indica la Factura Inicial (Del)")
        End If
    End Sub

    Private Sub btnAsignarVendedor_Click(sender As Object, e As EventArgs) Handles btnAsignarVendedor.Click
        If Me.cmbVendedor.SelectedIndex >= 0 Then
        Else
            MsgBox("Selecione un Vendedor de la lista")
            Exit Sub
        End If

        If Me.txtFacInicial.Text <> "" Then
            If Me.txtFacFinal.Text <> "" Then
                If Double.Parse(Me.txtFacInicial.Text) <= Double.Parse(Me.txtFacFinal.Text) Then
                    If Confirmacion("¿Está seguro que desea Asignar este Vendedor a las facturas?", Me.ParentForm) Then
                        Dim objEmbarques As New classEmbarques
                        If objEmbarques.putVendedor(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.txtFacInicial.Text), Double.Parse(Me.txtFacFinal.Text), CType(Me.cmbVendedor.SelectedValue, Integer)) = True Then
                            MsgBox("Vendedor asignado exitosamente !!")
                            Call CargarGridFacturas()
                        Else
                            MsgBox("No se pudo asignar el Vendedor. Error: " + objEmbarques.DesError.ToString)
                        End If


                    End If
                Else
                    MsgBox("No puedes asignar una factura inicial mayor a la final")
                End If
            Else
                MsgBox("Indica la Factura Final (Al)")
            End If
        Else
            MsgBox("Indica la Factura Inicial (Del)")
        End If
    End Sub



#End Region


#Region " ** TAB EMBARQUES ** "

    Private Sub btnEmbarques_Click(sender As Object, e As EventArgs) Handles btnEmbarques.Click

        Dim dr As DataRow = Nothing

        If FlyoutDialog.Show(Me.ParentForm, New viewEmbarques(False, dr)) = DialogResult.OK Then
            Call CargarComboEmbarques()
            Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
        End If

    End Sub

    Private Sub switchCompletosFinalizados_Toggled(sender As Object, e As EventArgs) Handles switchCompletosFinalizados.Toggled
        Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
    End Sub

    Private Sub cargarGridEmbarques(ByVal finalizados As Boolean, ByVal mes As Integer, ByVal anio As Integer)

        Dim objEmb As New classEmbarques
        Me.GridEmbarques.DataSource = Nothing

        If finalizados = False Then
            Me.GridEmbarques.DataSource = objEmb.tblEmbarquesPendientes(CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
        Else
            Me.GridEmbarques.DataSource = objEmb.tblEmbarquesFinalizados(CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
        End If

    End Sub

    'el timer es para evitar errores por carga inmediata antes de crear los controles necesarios
    Private Sub TimerCargarEmbarques_Tick(sender As Object, e As EventArgs) Handles TimerCargarEmbarques.Tick
        Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
        Me.TimerCargarEmbarques.Stop()
    End Sub


    Private Sub btnEmbarquesCargarGridEmbarques_Click(sender As Object, e As EventArgs) Handles btnEmbarquesCargarGridEmbarques.Click
        Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
    End Sub

    Dim drw As DataRow

    Private Sub GridViewEmbarques_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewEmbarques.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewEmbarques.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewEmbarques_DoubleClick(sender As Object, e As EventArgs) Handles GridViewEmbarques.DoubleClick
        Me.RadialMenuEmbarques.ShowPopup(MousePosition)
    End Sub

    Private Sub GridViewEmbarques_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewEmbarques.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.RadialMenuEmbarques.ShowPopup(MousePosition)
        End If
    End Sub

#End Region


#Region " ** RADIAL MENU ** "

    '********************************************
    '*******  RADIAL MENU EMBARQUES *************
    '********************************************
    Private Sub btnRadMenEmbarquesEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenEmbarquesEditar.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewEmbarques(True, drw)) = DialogResult.OK Then
            Call CargarComboEmbarques()
            Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
        End If

    End Sub

    Private Sub btnRadMenEmbarquesFinalizar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenEmbarquesFinalizar.ItemClick
        If Confirmacion("¿Está seguro que desea Finalizar este Embarque?", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New viewFinalizarEmbarque(drw.Item(0).ToString)) = DialogResult.OK Then
                Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
            End If


        End If

    End Sub

    Private Sub btnRadMenEmbarquesEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenEmbarquesEliminar.ItemClick
        If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

            If Confirmacion("¿Está seguro que desea ELIMINAR este Embarque?", Me.ParentForm) = True Then

                If objEmbarques.eliminarEmbarque(drw.Item(0).ToString) = True Then
                    MsgBox("Embarque eliminado exitosamente!!")
                    Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
                Else
                    MsgBox("No se pudo Eliminar el embarque. Error: " + objEmbarques.DesError)
                End If
            End If

        End If

    End Sub


    '********************************************
    '********************************************
    '********************************************
#End Region

#Region " ** IMPRESION DE DOCUMENTOS ** "

    Dim strCodEmbarque As String = ""

    Private Sub btnImprimirDocumentos_Click(sender As Object, e As EventArgs) Handles btnImprimirDocumentos.Click

        strCodEmbarque = Me.cmbEmbarque.SelectedValue.ToString
        Me.lbCodEmbarqueSeleccionado.Text = strCodEmbarque
        Me.FlyoutPanelImpresion.ShowPopup()

    End Sub

    Private Sub btnRadMenEmbarquesDocumentos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRadMenEmbarquesDocumentos.ItemClick

        strCodEmbarque = drw.Item(0).ToString
        Me.lbCodEmbarqueSeleccionado.Text = strCodEmbarque
        Me.FlyoutPanelImpresion.ShowPopup()

    End Sub

    Private Sub btnCerrarFlyoutImpresion_Click(sender As Object, e As EventArgs) Handles btnCerrarFlyoutImpresion.Click
        Me.FlyoutPanelImpresion.HidePopup()
    End Sub



    Private Sub btnImprimirPicking_Click(sender As Object, e As EventArgs) Handles btnImprimirPicking.Click
        objEmbarques.rptEmbarqueProductos(strCodEmbarque)
    End Sub

    Private Sub btnImprimirListaFacturas_Click(sender As Object, e As EventArgs) Handles btnImprimirListaFacturas.Click
        objEmbarques.rptEmbarqueDocumentos(strCodEmbarque)
    End Sub

    Private Sub btnImprimirBoletas_Click(sender As Object, e As EventArgs) Handles btnImprimirBoletas.Click
        objEmbarques.rptEmbarqueBoletas(strCodEmbarque, "BOLETA")
    End Sub

    Private Sub btnImprimirTickets_Click(sender As Object, e As EventArgs) Handles btnImprimirTickets.Click
        objEmbarques.rptEmbarqueBoletas(strCodEmbarque, "TICKET")
    End Sub








#End Region



End Class
