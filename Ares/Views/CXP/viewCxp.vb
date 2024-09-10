Imports DevExpress.XtraBars.Docking2010.Customization
Public Class viewCxp

    Dim objCxp As New classCxp


    Private Sub viewCxp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGrid()

    End Sub

    Private Sub CargarGrid()
        Me.GridFacPend.DataSource = Nothing
        Me.GridFacPend.DataSource = objCxp.tblListaFacturasPendientes(GlobalEmpNit)

        Me.GridProveedores.DataSource = Nothing
        Me.GridProveedores.DataSource = objCxp.tblProveedoresSaldo(GlobalEmpNit)

        Me.lbTotalSaldos.Text = FormatNumber(objCxp.tblTotalSaldo(GlobalEmpNit), 2)

    End Sub


    Dim drw As DataRow
    Private Sub GridViewFacPend_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewFacPend.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewFacPend.GetFocusedDataRow

        Catch ex As Exception

        End Try
    End Sub


    Private Sub GridViewFacPend_DoubleClick(sender As Object, e As EventArgs) Handles GridViewFacPend.DoubleClick
        Me.RadialMenuCxp.ShowPopup(MousePosition)
    End Sub

    Private Sub btnMenuAbono_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuAbono.ItemClick
        Dim coddoc As String = ""
        Dim correlativo As Double
        Dim codprov As Integer

        Try
            Dim fecha As Date = drw.Item(3)
            coddoc = drw.Item(4).ToString
            correlativo = CType(drw.Item(5), Double)
            codprov = CType(drw.Item(9), Integer)
        Catch ex As Exception

        End Try

        If FlyoutDialog.Show(Me.ParentForm, New viewCxPCobro(coddoc, correlativo, codprov)) = DialogResult.OK Then
            Call CargarGrid()
        End If
    End Sub

    Private Sub btnMenuListaAbonos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuListaAbonos.ItemClick
        FlyoutDialog.Show(Me.ParentForm, New viewCxpAbonos(drw))
    End Sub

    Private Sub switchListado_Toggled(sender As Object, e As EventArgs) Handles switchListado.Toggled
        If Me.switchListado.IsOn = True Then
            Me.NavFrameCxp.SelectedPage = NP_Proveedores
        Else
            Me.NavFrameCxp.SelectedPage = NP_Compras
        End If
    End Sub


End Class
