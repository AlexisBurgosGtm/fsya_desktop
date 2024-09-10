Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class viewInterfaceDIG

#Region "LOAD"

    Private Sub viewInterfaceDigitadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GlobalNomEmpresa = Form1.cmbLoginEmpresa.Text

        Me.lbEMPRESA.Text = GlobalNomEmpresa

    End Sub

    Private Sub TileNavPaneMain_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles TileNavPane1.ElementClick

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

    Private Sub TileControl1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileControl1.ItemClick
        Dim tag As String = ""
        Try
            tag = e.Item.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)

    End Sub

#End Region

    Private Sub btnOnlineGetProductosPrecios_Click(sender As Object, e As EventArgs) Handles btnOnlineGetProductosPrecios.Click
        Call NAVEGAR("SYNCPRECIOS")
    End Sub

    Private Sub btnOnlinePlantilla_Click(sender As Object, e As EventArgs) Handles btnOnlinePlantilla.Click

        Call NAVEGAR("PLANTILLAPRODUCTOS")

    End Sub


    Private Sub TileItemORDENCOMPRA_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemORDENCOMPRA.ItemClick

    End Sub


End Class
