Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewInterfaceINV

    Private Sub viewInterfaceInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GlobalNomEmpresa = Form1.cmbLoginEmpresa.Text
        GlobalNomUsuario = Form1.txtUser.Text

        Call ColorExistencias()
        Me.lbUSUARIO.Text = GlobalNomUsuario
        Me.lbEMPRESA.Text = GlobalNomEmpresa

    End Sub

    Private Sub ColorExistencias()

        Call PermisoExistencia()

        If ExisSiNo = "SI" Then
            Me.tbVisExistencias.BackColor = Color.Green
        Else
            Me.tbVisExistencias.BackColor = Color.Red
        End If

    End Sub

    Private Sub TileNavPane2_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles TileNavPane1.ElementClick

        Dim tag As String
        Try
            tag = e.Element.Tag.ToString
        Catch ex As Exception
            tag = ""
        End Try


        Select Case tag


            Case "ONLINE"

            Case Else
                Call NAVEGAR(tag)

        End Select

    End Sub

    Private Sub btnOnlineDomicilio_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("DOMICILIO")
    End Sub

    Private Sub btnOnlinePreventa_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("SYNC2")
    End Sub

    Private Sub btnOnlinePlantilla_Click(sender As Object, e As EventArgs)

        Call NAVEGAR("PLANTILLAPRODUCTOS")
        'Call NAVEGAR("ONLINE_PRECIOS_SUCURSALES")
    End Sub

    Private Sub btnOnlinePedidosVentas_Click(sender As Object, e As EventArgs)
        Call NAVEGAR("ONLINE_PREVENTAS")
    End Sub

    Private Sub TileControl1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileControl1.ItemClick
        Dim tag As String = ""
        Try
            tag = e.Item.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)

    End Sub

    Private Sub TileItemRVTYO_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)

        If FlyoutDialog.Show(Me.ParentForm, New viewRPTVO) = DialogResult.OK Then

        End If

    End Sub

    Dim ExisSiNo As String

    Private Sub PermisoExistencia()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           NIVEL2
                                           FROM             PERMISOS
                                           WHERE            (ID = 29)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    ExisSiNo = dr(0).ToString
                Else
                    ExisSiNo = "NO"
                End If
                dr.Close()
                cmd.Dispose()

                cn.Close()

            Catch ex As Exception

            End Try

        End Using

    End Sub

    Private Sub TileItemDEBHABExis_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemDEBHABExis.ItemClick

        Dim SN As String

        Call PermisoExistencia()

        If ExisSiNo = "SI" Then
            SN = "NO"
        Else
            SN = "SI"
        End If

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("UPDATE PERMISOS SET NIVEL2 = @SN WHERE (ID = 29)", cn)
                cmd.Parameters.AddWithValue("@SN", SN)

                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                If ExisSiNo = "SI" Then
                    MsgBox("EXISTENCIA DESHABILITADA")
                Else
                    MsgBox("EXISTENCIA HABILITADA")
                End If


            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Call ColorExistencias()

    End Sub

End Class
