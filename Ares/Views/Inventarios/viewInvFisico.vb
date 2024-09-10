Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewInvFisico

    Dim objInvF As New classInvFisico(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
    Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
    Dim objEmpleados As New ClassEmpleados


    Private Sub viewInvFisico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'CARGA EL CODDOC
        With Me.cmbCoddoc
            .DataSource = objTipoDoc.tblCoddoc("INF")
            .DisplayMember = "DESDOC"
            .ValueMember = "CODDOC"
            .SelectedIndex = 0
        End With

        'CARGA EL CORRELATIVO DEL DOCUMENTO
        Me.lbCorrelativo.Text = objTipoDoc.GetCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString).ToString

        'CARGA EL COMBO DE SUPERVISORES
        With Me.cmbVendedor
            .DataSource = objEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 2)
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"
        End With

        'INDICA LA FECHA ACTUAL
        Me.txtFecha.DateTime = Today.Date

        'CARGA EL GRID
        Call CargarGridTemp()

    End Sub

    Private Sub CargarGridTemp()
        Me.GridTempVentas.DataSource = Nothing
        Me.GridTempVentas.DataSource = objInvF.tblGridTemp(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))
        Me.txtBusqueda.Text = ""
        Me.txtBusqueda.select()
    End Sub

    Private Sub cmbCoddoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoddoc.SelectedIndexChanged

        Me.lbCorrelativo.Text = objTipoDoc.GetCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString).ToString
        Call CargarGridTemp()

    End Sub


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If Me.txtBusqueda.Text <> "" Then
            Call CargarGridBusqueda(Me.txtBusqueda.Text)
        Else
            MsgBox("Escriba para buscar")
        End If


    End Sub


    Private Sub txtBusqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtBusqueda.Text <> "" Then
                Call CargarGridBusqueda(Me.txtBusqueda.Text)
            Else
                MsgBox("Escriba para buscar")
            End If
        End If
    End Sub
    Private Sub CargarGridBusqueda(ByVal desprod As String)

        Me.gridProductos.DataSource = Nothing
        Me.gridProductos.DataSource = objInvF.tblProductos(desprod)
        Me.FlyoutPanelProductos.ShowPopup()
        Me.gridProductos.select()
    End Sub

    Private Sub txtCodProd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodProd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtCodProd.Text <> "" Then
                If objInvF.existeProducto(Me.txtCodProd.Text) = True Then

                    Dim coddoc As String = Me.cmbCoddoc.SelectedValue.ToString
                    Dim correlativo As Double = Double.Parse(Me.lbCorrelativo.Text)
                    Dim codprod As String = objInvF.selected_codprod
                    Dim desprod As String = objInvF.selected_desprod
                    Dim costo As Double = objInvF.selected_codcosto

                    If objInvF.existeProductoGrid(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text), codprod) = True Then
                        MsgBox("Producto agregado en este u otro inventario físico en curso, no puedes agregarlo nuevamente")
                    Else
                        If FlyoutDialog.Show(Me.ParentForm, New viewInvFisicoConteo(coddoc, correlativo, codprod, desprod, costo)) = DialogResult.OK Then
                            Call CargarGridTemp()
                        End If
                    End If

                Else
                    MsgBox("El código de producto no existe, o se encuentra deshabilitado")
                End If

            Else
                MsgBox("Escriba un código para buscar")
            End If
        End If

    End Sub

    Private Sub btnBorrarDatos_Click(sender As Object, e As EventArgs) Handles btnBorrarDatos.Click
        If Confirmacion("¿Está seguro que desea borrar los datos de este documento?", Me.ParentForm) = True Then
            If InputBox("Escriba CONFIRMAR para continuar", "Confirme") = "CONFIRMAR" Then
                If objInvF.DeleteGridTemp(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text)) = True Then
                    Me.GridTempVentas.DataSource = Nothing
                Else
                    MsgBox("No se pudo eliminar la lista de productos. Error: " + objInvF.DesError)
                End If
            Else
                MsgBox("No se borrarán los datos agregados")
            End If

        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.GridTempVentas.DataSource IsNot Nothing Then
            If Me.txtObs.Text <> "" Then
            Else
                Me.txtObs.Text = "SN"
            End If

            If Me.txtIdentificador.Text <> "" Then
            Else
                MsgBox("Debe agregar un IDENTIFICADOR DE INVENTARIO")
                Me.txtIdentificador.select()
                Exit Sub
            End If


            If Confirmacion("¿Está seguro que desea Guardar este movimiento?", Me.ParentForm) = True Then
                If objInvF.InsertDocument(Me.txtFecha.DateTime, Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text), CType(Me.cmbVendedor.SelectedValue, Integer), Me.txtObs.Text, Me.txtIdentificador.Text) = True Then
                    'borro el temp ventas
                    If objInvF.DeleteGridTemp(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text)) = True Then
                    End If

                    'capturo el documento para abrir el reporte
                    Dim d As String = Me.cmbCoddoc.SelectedValue.ToString
                    Dim n As Double = Double.Parse(Me.lbCorrelativo.Text)

                    'actualizo el correlativo
                    Dim corr As Double = objTipoDoc.UpdateCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))
                    Me.lbCorrelativo.Text = corr.ToString

                    'limpio el grid y las obs
                    Me.GridTempVentas.DataSource = Nothing
                    Me.txtObs.Text = "SN"

                    'mando abrir el reporte
                    'objInvF.rptInvFisico(d, n)

                    MsgBox("Documento registrado exitosamente")

                    'REALIZA UNA ENTRADA DE INVENTARIO DONDE SUMA Y RESTA
                    Dim objDocto As New ClassDocumentos
                    If objDocto.DevolverInvFac(GlobalEmpNit, d, n, GlobalAnioProceso, GlobalMesProceso) = False Then
                        MsgBox("Error al generar ajustes de inventario. Error: " + GlobalDesError)
                    End If

                Else
                    MsgBox("Error: " + objInvF.DesError)
                End If
            End If
        End If
    End Sub

    Dim drw As DataRow


    Private Sub GridViewTemp_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewTemp.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewTemp.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewTemp_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewTemp.KeyDown
        If e.KeyCode = Keys.Delete Then
            Try

                If objInvF.DeleteProdGridTemp(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text), drw.Item(0).ToString) = True Then
                    Call CargarGridTemp()
                Else
                    MsgBox("No se pudo quitar este item. Error: " + objInvF.DesError)
                End If

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub GridViewTemp_DoubleClick(sender As Object, e As EventArgs) Handles GridViewTemp.DoubleClick
        Dim x As Integer
        x = MsgBox("¿Está seguro que desea Quitar este item?", MsgBoxStyle.OkCancel)
        If x = MsgBoxResult.Ok Then
            Try
                If objInvF.DeleteProdGridTemp(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text), drw.Item(0).ToString) = True Then
                    Call CargarGridTemp()
                Else
                    MsgBox("No se pudo quitar este item. Error: " + objInvF.DesError)
                End If
            Catch ex As Exception
                MsgBox("No se pudo eliminar. Error: " + ex.ToString)
            End Try


        End If
    End Sub

    '0000000000000000000000000000000

    Private Sub GridViewProductos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProductos.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewProductos.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim coddoc As String = Me.cmbCoddoc.SelectedValue.ToString
            Dim correlativo As Double = Double.Parse(Me.lbCorrelativo.Text)
            Dim codprod As String = drw.Item(0).ToString
            Dim desprod As String = drw.Item(2).ToString
            Dim costo As Double = Double.Parse(drw.Item(4))

            Me.FlyoutPanelProductos.HidePopup()

            If objInvF.existeProductoGrid(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text), codprod) = True Then
                MsgBox("Ya agregaste este producto, no puedes agregarlo nuevamente")
            Else
                If FlyoutDialog.Show(Me.ParentForm, New viewInvFisicoConteo(coddoc, correlativo, codprod, desprod, costo)) = DialogResult.OK Then
                    Call CargarGridTemp()
                End If
            End If

        End If
    End Sub

    Private Sub GridViewProductos_DoubleClick(sender As Object, e As EventArgs) Handles GridViewProductos.DoubleClick
        Dim coddoc As String = Me.cmbCoddoc.SelectedValue.ToString
        Dim correlativo As Double = Double.Parse(Me.lbCorrelativo.Text)
        Dim codprod As String = drw.Item(0).ToString
        Dim desprod As String = drw.Item(2).ToString
        Dim costo As Double = Double.Parse(drw.Item(4))

        Me.FlyoutPanelProductos.HidePopup()

        If objInvF.existeProductoGrid(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text), codprod) = True Then
            MsgBox("Ya agregaste este producto, no puedes agregarlo nuevamente")
        Else
            If FlyoutDialog.Show(Me.ParentForm, New viewInvFisicoConteo(coddoc, correlativo, codprod, desprod, costo)) = DialogResult.OK Then
                Call CargarGridTemp()
            End If
        End If

    End Sub

    Private Sub btnNoContados_Click(sender As Object, e As EventArgs) Handles btnNoContados.Click
        If Me.txtIdentificador.Text <> "" Then

            Call getLoader()

            Me.gridExportNoContados.DataSource = Nothing
            Me.gridExportNoContados.DataSource = objInvF.getNoContados(Me.txtIdentificador.Text)
            Dim filename As String = Application.StartupPath + "\EXPORTS\NOCONTADOS.XLSX"

            Call closeLoader()

            Me.gridExportNoContados.ExportToXlsx(filename)
            Process.Start(filename)


        Else
            MsgBox("Escriba un Identificador de Inventario para Comparar")
        End If

    End Sub

    Private Sub btnExportarInventarioIdentificador_Click(sender As Object, e As EventArgs) Handles btnExportarInventarioIdentificador.Click
        If Me.txtIdentificador.Text <> "" Then

            Call getLoader()

            Me.gridContados.DataSource = Nothing
            Me.gridContados.DataSource = objInvF.getContados(Me.txtIdentificador.Text)
            Dim filename As String = Application.StartupPath + "\EXPORTS\CONTADOSINVENTARIOFISICO.XLSX"

            Call closeLoader()

            Me.gridContados.ExportToXlsx(filename)
            Process.Start(filename)


        Else
            MsgBox("Escriba un Identificador de Inventario para Comparar")
        End If
    End Sub
End Class
