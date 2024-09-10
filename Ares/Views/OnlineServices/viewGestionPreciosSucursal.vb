Public Class viewGestionPreciosSucursal

    Dim objProductos As New ClassProductos
    Dim objOnline As New classOnline(Token)

    Private Sub viewGestionPreciosSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call CargarGridProductos()

    End Sub


    Private Sub CargarGridProductos()

        With Me.cmbSucursales
            .DataSource = objOnline.getEmpresas
            .DisplayMember = "EMPNOMBRE"
            .ValueMember = "EMPNIT"
        End With

        Me.GridProductos.DataSource = objOnline.getProductos

    End Sub


    Private Sub CargarPreciosProducto()

        Me.GridPreciosSucursal.DataSource = Nothing
        Me.GridPreciosSucursal.DataSource = objOnline.getPreciosProducto(drw.Item(0).ToString, Me.cmbSucursales.SelectedValue.ToString)

    End Sub

    Private Sub btnSubirPlantillaProductos_Click(sender As Object, e As EventArgs) Handles btnSubirPlantillaProductos.Click
        Call NAVEGAR("PLANTILLAPRODUCTOS")
    End Sub

    Dim drw As DataRow
    Private Sub GridViewProductos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProductos.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewProductos.GetFocusedDataRow
            Call CargarPreciosProducto()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbSucursales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursales.SelectedIndexChanged
        Call CargarPreciosProducto()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) 
        Call CargarGridProductos()
    End Sub
End Class
