
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports System.Data.SqlClient

Public Class ViewCxc
    Dim ObjCxc As New ClassCxc()
    Dim ObjReports As New ClassReports

    Private Sub ViewFactPend_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CargarGrid()
    End Sub

    Private Sub CargarGrid()
        Me.GridFacPend.DataSource = Nothing
        Me.GridFacPend.DataSource = ObjCxc.tblListaFacturasPendientes(GlobalEmpNit)

        Me.lbTotalSaldos.Text = FormatNumber(ObjCxc.tblTotalSaldo(GlobalEmpNit), 2)

    End Sub


    Private Sub btnFacturas_Click(sender As Object, e As EventArgs) Handles btnFacturas.Click
        Me.NavigationFrame.SelectedPage = NP_Facturas

    End Sub

    Private Sub btnCuotas_Click(sender As Object, e As EventArgs) Handles btnCuotas.Click
        Me.NavigationFrame.SelectedPage = NP_CuotasPendientes
        Call CargarCuotasPendientes()
    End Sub



#Region " ** RADIAL MENU **"

    Dim drw As DataRow

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Me.RadMenFacPend.ShowPopup(MousePosition)

    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridView1.GetFocusedDataRow

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.RadMenFacPend.ShowPopup(MousePosition)
        End If
    End Sub

    Private Sub RadMenFacPendBtnCobrar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenFacPendBtnCobrar.ItemClick
        'If FlyoutDialog.Show(Me.ParentForm, New ViewCxcCobro(Me.TileViewFacPend.GetFocusedDataRow)) = DialogResult.OK Then
        If FlyoutDialog.Show(Me.ParentForm, New ViewCxcCobro(drw)) = DialogResult.OK Then
            Call CargarGrid()

        End If
    End Sub

    Private Sub RadMenFacPendBtnVerPagos_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenFacPendBtnVerPagos.ItemClick
        'If FlyoutDialog.Show(Me.ParentForm, New ViewCxcAbonos(Me.TileViewFacPend.GetFocusedDataRow)) = DialogResult.OK Then

        If FlyoutDialog.Show(Me.ParentForm, New ViewCxcAbonos(drw)) = DialogResult.OK Then
        End If
    End Sub

    Private Sub RadMenPendEstablecerCuotas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RadMenPendEstablecerCuotas.ItemClick
        'If FlyoutDialog.Show(Me.ParentForm, New viewVentasTablaCuotas(Me.TileViewFacPend.GetFocusedDataRow)) = DialogResult.OK Then

        If fcnExistenCuotas(drw.Item(4).ToString, Double.Parse(drw.Item(5))) = False Then

            If FlyoutDialog.Show(Me.ParentForm, New viewVentasTablaCuotas(drw)) = DialogResult.OK Then

            End If

        Else

            If ObjReports.rptFicheroCuotasFactura(GlobalEmpNit, drw.Item(4).ToString, Double.Parse(drw.Item(5))) = True Then
            End If

        End If
    End Sub

#End Region

#Region " ** MANEJO DE CUOTAS ** "
    Private Sub CargarCuotasPendientes()
        Me.GridCuotasPendientes.DataSource = Nothing
        Me.GridCuotasPendientes.DataSource = ObjCxc.tblListaCuotasPendientes(GlobalEmpNit)

    End Sub



    Private Function fcnExistenCuotas(ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Dim cmd As New SqlCommand("SELECT CODDOC, CORRELATIVO FROM DOCCUOTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Try
                dr.Read()
                If dr.HasRows Then
                    result = True
                End If
                cmd.Dispose()
            Catch ex As Exception
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function


    Dim drwCuotas As DataRow


    Private Sub GridViewCuotasPendientes_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewCuotasPendientes.FocusedRowChanged
        Try
            drwCuotas = Nothing
            drwCuotas = Me.GridViewCuotasPendientes.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewCuotasPendientes_DoubleClick(sender As Object, e As EventArgs) Handles GridViewCuotasPendientes.DoubleClick
        'drwCuotas.Item(0).ToString    // NITCLIE 
        'drwCuotas.Item(1).ToString  // NOMBRE CLIENTE
        'drwCuotas.Item(2).ToString  // TELEFONO
        'drwCuotas.Item(3).ToString // NO CUOTA
        'drwCuotas.Item(4).ToString // FECHAPAGO
        'drwCuotas.Item(5).ToString // CUOTA DOUBLE
        'drwCuotas.Item(6).ToString // CODDOC
        'drwCuotas.Item(7).ToString // CORERELATIVO
        'drwCuotas.Item(8).ToString // COCLIENTE
        'drwCuotas.Item(9).ToString // CUOTA Q STRING

        If FlyoutDialog.Show(Me.ParentForm, New viewCxcCobroCuota(drwCuotas)) = DialogResult.OK Then
            Call CargarCuotasPendientes()

        End If


    End Sub

#End Region




End Class
