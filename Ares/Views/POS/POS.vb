Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class POS
    Private Sub POS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPOSFecha.DateTime = Today.Date

        'carga el combobox de vendedores
        With Me.cmbPOSVendedor
            .DataSource = tblVendedores(GlobalEmpNit)
            .DisplayMember = "NOMVEN"
            .ValueMember = "CODVEN"
        End With

        'carga el correlativo
        Me.txtPOSCorrelativo.Text = FormatNumber(CorrelativoPOS(GlobalEmpNit, GlobalCoddoc), 0).ToString

        Call CargarTotalVenta()


        Me.txtPOSCodprod.select()

    End Sub

    Private Sub txtPOSCodprod_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPOSCodprod.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtPOSCodprod.Text <> "" Then

                If POSInsertarProducto(GlobalEmpNit, GlobalCoddoc, Double.Parse(Me.txtPOSCorrelativo.Text), Me.txtPOSCodprod.Text, "UNIDAD", 1, Integer.Parse(Form1.cmdAnioProceso.Text), Integer.Parse(Form1.cmdMesProceso.SelectedValue)) = True Then
                    Call CargarTotalVenta()
                    Me.txtPOSCodprod.Text = ""
                End If

            End If
        End If

        If e.KeyCode = Keys.F1 Then
            Me.cmdPOSBuscarProd.PerformClick()
        End If

    End Sub

    Private Sub CargarTotalVenta()
        'CARGA EL TOTAL DE LA VENTA
        Call CargarTotalVentaPOS(GlobalEmpNit, GlobalCoddoc, Double.Parse(Me.txtPOSCorrelativo.Text))
        Me.LbPOSTotalCosto.Text = ValTotalCostoPOS
        Me.LbPOSTotalVenta.Text = FormatNumber(ValTotalVentaPOS, 2).ToString

        Me.DgvPOStempVenta.DataSource = POStblListaProductosVendidos(GlobalEmpNit, GlobalCoddoc, Double.Parse(Me.txtPOSCorrelativo.Text))

    End Sub

    Private Sub cmdPOSBuscarProd_Click(sender As Object, e As EventArgs) Handles cmdPOSBuscarProd.Click
        Dim Buscar As New UCBuscaProducto
        FlyoutDialog.Show(Form1, Buscar)

    End Sub

    Private Sub DgvPOStempVenta_DoubleClick(sender As Object, e As EventArgs) Handles DgvPOStempVenta.DoubleClick
        If Confirmacion("¿Está seguro que desea eliminar este Item?", Form1) = True Then
            Dim id As Integer = Integer.Parse(Me.DgvPOStempVenta.Item(0, Me.DgvPOStempVenta.CurrentRow.Index).Value.ToString)
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE ID=@ID", cn)
            cmd.Parameters.AddWithValue("@ID", id)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()

            Call CargarTotalVenta()

        End If
    End Sub

    Private Sub DgvPOStempVenta_KeyDown(sender As Object, e As KeyEventArgs) Handles DgvPOStempVenta.KeyDown
        If e.KeyCode = Keys.Subtract Then
            If Confirmacion("¿Está seguro que desea eliminar este Item?", Form1) = True Then
                Dim id As Integer = Integer.Parse(Me.DgvPOStempVenta.Item(0, Me.DgvPOStempVenta.CurrentRow.Index).Value.ToString)
                Call AbrirConexionSql()
                Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE ID=@ID", cn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                Call CargarTotalVenta()

            End If
        End If
    End Sub

    Private Sub POS_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            Me.cmdPOSBuscarProd.PerformClick()
        End If
    End Sub
End Class
