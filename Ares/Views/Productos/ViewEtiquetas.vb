Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class ViewEtiquetas

    Dim objProductos As New ClassProductos

    Private Sub ViewEtiquetas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrids(3)

    End Sub

    Private Sub CargarGrids(ByVal NoGrid As Integer)
        Select Case NoGrid
            Case 1
                Me.GridListaProductos.DataSource = Nothing
                Me.GridListaProductos.DataSource = objProductos.tblListaProductos(GlobalEmpNit)

            Case 2
                Me.GridSeleccionados.DataSource = Nothing
                Me.GridSeleccionados.DataSource = objProductos.tblListaEtiquetas(GlobalEmpNit, GlobalCoddoc)

            Case 3
                Me.GridListaProductos.DataSource = Nothing
                Me.GridListaProductos.DataSource = objProductos.tblListaProductos(GlobalEmpNit)

                Me.GridSeleccionados.DataSource = Nothing
                Me.GridSeleccionados.DataSource = objProductos.tblListaEtiquetas(GlobalEmpNit, GlobalCoddoc)

        End Select


    End Sub

    Dim drwLista As DataRow
    Private Sub GridViewLista_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewLista.FocusedRowChanged
        drwLista = Nothing
        drwLista = Me.GridViewLista.GetFocusedDataRow
    End Sub

    Private Sub GridViewLista_DoubleClick(sender As Object, e As EventArgs) Handles GridViewLista.DoubleClick

        If FlyoutDialog.Show(Me.ParentForm, New ViewEtiquetasCantidad(drwLista.Item(0).ToString, drwLista.Item(3).ToString)) = DialogResult.OK Then
            If GlobalCantidad > 0 Then
                If objProductos.AgregarEtiquetas(drwLista, GlobalCantidad, SelectedCodMedida, SelectedPrecio) = True Then
                    Call CargarGrids(2)
                End If
            Else
                MsgBox("No seleccionó la cantidad correcta de etiquetas")
            End If
        Else
            Call Aviso("Importante", "Debe indicar la cantidad de etiquetas a imprimir", Me.ParentForm)
        End If

    End Sub



    Dim drwEtiqueta As DataRow
    Private Sub GridViewEtiquetas_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewEtiquetas.FocusedRowChanged
        drwEtiqueta = Nothing
        drwEtiqueta = Me.GridViewEtiquetas.GetFocusedDataRow
    End Sub
    Private Sub GridSeleccionados_DoubleClick(sender As Object, e As EventArgs) Handles GridSeleccionados.DoubleClick
        If Confirmacion("¿Está seguro que desea Quitar este precio de la Lista?", Me.ParentForm) = True Then

            If objProductos.EliminarPrecioEtiqueta(CType(drwEtiqueta.Item(0), Integer)) = True Then
                Call CargarGrids(2)
            End If
        End If
    End Sub

    Private Sub GridViewLista_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewLista.KeyDown
        If e.KeyCode = Keys.Enter Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewEtiquetasCantidad(drwLista.Item(0).ToString, drwLista.Item(3).ToString)) = DialogResult.OK Then
                If GlobalCantidad > 0 Then
                    If objProductos.AgregarEtiquetas(drwLista, GlobalCantidad, SelectedCodMedida, SelectedPrecio) = True Then
                        Call CargarGrids(2)
                    End If
                Else
                    MsgBox("No seleccionó la cantidad correcta de etiquetas")
                End If
            Else
                Call Aviso("Importante", "Debe indicar la cantidad de etiquetas a imprimir", Me.ParentForm)
            End If

        End If
    End Sub

    Private Sub btnImprimirListado_Click(sender As Object, e As EventArgs) Handles btnImprimirListado.Click

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim Adapter As New SqlDataAdapter
        Dim report As New rptEtiquetasIndividual

        report.LoadLayout(Application.StartupPath + "\Reports\rptEtiquetasIndividual.repx")

        report.DataSource = objProductos.tblListaEtiquetas(GlobalEmpNit, GlobalCoddoc)
        report.DataAdapter = Adapter
        report.DataMember = "tblTempEtiquetas"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview



    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If Confirmacion("¿Está seguro que desea Eliminar toda la lista de Etiquetas?", Me.ParentForm) = True Then
            If objProductos.EliminarEtiquetasTodas(GlobalEmpNit, GlobalCoddoc) = True Then
                Call CargarGrids(2)
            Else
                Call Aviso("Error", "No se pudo eliminar la lista", Me.ParentForm)
            End If
        End If
    End Sub

    Private Sub btnImprimirListadoOfertas_Click(sender As Object, e As EventArgs) Handles btnImprimirListadoOfertas.Click

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim Adapter As New SqlDataAdapter
        Dim report As New rptEtiquetas

        report.LoadLayout(Application.StartupPath + "\Reports\rptEtiquetas.repx")

        report.DataSource = objProductos.tblListaEtiquetas(GlobalEmpNit, GlobalCoddoc)
        report.DataAdapter = Adapter
        report.DataMember = "tblTempEtiquetas"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview

    End Sub

    Private Sub btnImprimirBarcode_Click(sender As Object, e As EventArgs) Handles btnImprimirBarcode.Click
        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim Adapter As New SqlDataAdapter
        Dim report As New rptEtiquetasBarCode

        report.LoadLayout(Application.StartupPath + "\Reports\rptEtiquetasBarCode.repx")

        report.DataSource = objProductos.tblListaEtiquetas(GlobalEmpNit, GlobalCoddoc)
        report.DataAdapter = Adapter
        report.DataMember = "tblTempEtiquetas"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview
    End Sub
End Class
