Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraSplashScreen

Public Class ViewMenu


    Dim objTiles As New ClassGeneral


    Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
    Dim objProductos As New ClassProductos()



    Private Sub ViewMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'WebBrowserMain.Navigate(New Uri(GlobalUrlFrontEnd))
        Call CargarGridShorcut()

        Try
            Dim obj As New viewTasks
            Me.GroupControlTareas.Controls.Add(obj)

        Catch ex As Exception
            MsgBox("Error al cargar tareas " + ex.ToString)
        End Try

    End Sub

    Private Sub TileNavPane1_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles TileNavPane1.ElementClick
        Dim tag As String
        Try
            tag = e.Element.Tag.ToString

        Catch ex As Exception
            tag = ""
        End Try

        Call NAVEGAR(tag)

    End Sub

    Private Sub TileView1_Click(sender As Object, e As EventArgs) Handles TileView1.Click
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = Me.TileView1.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            Dim nav As String = Me.TileView1.GetRowCellValue(hitInfo.RowHandle, "NAVEGAR").ToString
            Call NAVEGAR(nav)

        End If
    End Sub

    Private Sub CargarGridShorcut()
        Dim tbl As New DSGeneral.tblShorcutsDataTable

        Using cn As New SqlClient.SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlClient.SqlCommand("SELECT NAVEGAR,DESCRIPCION FROM NAVEGAR WHERE ACTIVO='SI'", cn)

                Dim da As New SqlClient.SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try

            Me.GridShorcuts.DataSource = Nothing
            Me.GridShorcuts.DataSource = tbl

        End Using
    End Sub

    Private Sub btnAgregarShorcut_Click(sender As Object, e As EventArgs) Handles btnAgregarShorcut.Click
        If FlyoutDialog.Show(Me.ParentForm, New viewAgregarShorcut) = DialogResult.OK Then
            Call CargarGridShorcut()
        End If
    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Confirmacion("¿Está seguro que desea borrar la lista de shorcuts?", Me.ParentForm) Then
            Using cn As New SqlClient.SqlConnection(strSqlConectionString)
                Try
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlClient.SqlCommand("UPDATE NAVEGAR SET ACTIVO='NO' WHERE ACTIVO='SI'", cn)

                    Dim i = cmd.ExecuteNonQuery()
                    If i >= 1 Then
                        Me.GridShorcuts.DataSource = Nothing
                        Me.GridShorcuts.Refresh()
                    End If

                Catch ex As Exception
                    MsgBox("No se pudo quitar este shorcut. Error: " + ex.ToString)
                End Try
            End Using
        End If

    End Sub

    Private Sub btnMenuUpdateInventory_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles btnMenuUpdateInventory.ElementClick
        If Confirmacion("Está seguro que desea Actualizar el Inventario, puede tardar unos minutos?", Me.ParentForm) = True Then

            Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

            SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Dim result As String
            If objInventarios.fcn_existencias_cero = True Then

                If objInventarios.fcn_ActualizarInventarioMes("anio") = True Then
                    result = "Actualización completada exitosamente"
                Else
                    result = "Algo salió mal. Error: " & GlobalDesError
                End If

            End If
            SplashScreenManager.CloseForm()

            MsgBox(result.ToString)

        End If
    End Sub

    Private Sub TileNavPane1_Click(sender As Object, e As EventArgs) Handles TileNavPane1.Click

    End Sub
End Class
