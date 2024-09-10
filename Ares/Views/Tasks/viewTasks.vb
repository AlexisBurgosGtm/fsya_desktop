
Imports System.Data.SqlClient

Public Class viewTasks

    Private Sub viewTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtFecha.DateTime = Today.Date
        Me.cmbHora.Text = Now.Hour.ToString
        Me.cmbMinuto.Text = Now.Minute.ToString

        Call CargarGrid()


        Dim objEmpleados As New ClassEmpleados
        With Me.cmbResponsable
            .DataSource = objEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 3)
            .ValueMember = "CODEMP"
            .DisplayMember = "NOMEMP"
        End With

        Me.cmbPrioridad.SelectedIndex = 0

    End Sub


    Private Sub CargarGrid()

        Dim tbl As New DSGeneral.tblTasksDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT ID, FECHA, TAREA, RESPONSABLE, PRIORIDAD FROM TASKS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        Me.GridTareas.DataSource = Nothing
        Me.GridTareas.DataSource = tbl
        Me.GridTareas.RefreshDataSource()

    End Sub



    Private Sub btnGuardarTarea_Click(sender As Object, e As EventArgs) Handles btnGuardarTarea.Click
        If Me.txtTarea.Text <> "" Then
            If Me.cmbResponsable.Text <> "" Then
            Else
                Me.cmbResponsable.Text = "SN"
            End If
            If Me.cmbPrioridad.Text <> "" Then
            Else
                Me.cmbPrioridad.SelectedIndex = 0
            End If

            If postTarea(Me.txtFecha.DateTime, Me.txtTarea.Text, Me.cmbResponsable.Text, Me.cmbPrioridad.Text, Integer.Parse(Me.cmbHora.Text), Integer.Parse(Me.cmbMinuto.Text)) = True Then
                Call CargarGrid()
                Call LimpiarTarea()
                MsgBox("Tarea agregada exitosamente")
            Else
                MsgBox("No se pudo agregar la tarea. Error: " + GlobalDesError)
            End If


        Else
            MsgBox("Escriba la descripción de la tarea")
        End If


    End Sub

    Private Function postTarea(ByVal fecha As Date, ByVal tarea As String, ByVal responsable As String, ByVal prioridad As String, ByVal hora As Integer, ByVal minuto As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO TASKS (EMPNIT,FECHA,TAREA,RESPONSABLE,PRIORIDAD,SYNC,HORA,MINUTO) VALUES (@E,@F,@T,@R,@P,0,@H,@M)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@F", fecha)
                cmd.Parameters.AddWithValue("@T", tarea)
                cmd.Parameters.AddWithValue("@R", responsable)
                cmd.Parameters.AddWithValue("@P", prioridad)
                cmd.Parameters.AddWithValue("@H", hora)
                cmd.Parameters.AddWithValue("@M", minuto)

                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function


    Private Function deleteTarea(ByVal id As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TASKS WHERE ID=@I", cn)
                cmd.Parameters.AddWithValue("@I", id)
                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Private Sub LimpiarTarea()
        Me.txtFecha.DateTime = Today.Date
        Me.txtTarea.Text = ""
        Me.cmbPrioridad.SelectedIndex = 0
    End Sub

    Dim drw As DataRow

    Private Sub txtTarea_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarea.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbResponsable.select()
        End If
    End Sub

    Private Sub cmbResponsable_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbResponsable.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbPrioridad.select()
        End If
    End Sub

    Private Sub cmbPrioridad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPrioridad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardarTarea.select()
        End If
    End Sub

    Private Sub btnCancelarTarea_Click(sender As Object, e As EventArgs) Handles btnCancelarTarea.Click
        Me.FlyoutPanelNuevaTarea.Hide()
    End Sub

    Private Sub btnNuevaTarea_Click(sender As Object, e As EventArgs) Handles btnNuevaTarea.Click

        Me.FlyoutPanelNuevaTarea.ShowPopup()
    End Sub

    Private Sub TileViewTareas_DoubleClick(sender As Object, e As EventArgs) Handles TileViewTareas.DoubleClick
        If Confirmacion("¿Está seguro que desea Eliminar esta Tarea?", Me.ParentForm) = True Then
            If deleteTarea(Integer.Parse(drw.Item(0))) = True Then
                Call CargarGrid()
            Else
                MsgBox("No se pudo eliminar la tarea. Error: " + GlobalDesError)
            End If
        End If
    End Sub

    Private Sub TileViewTareas_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TileViewTareas.FocusedRowChanged
        Try

            drw = Nothing
            drw = Me.TileViewTareas.GetFocusedDataRow

        Catch ex As Exception
            drw = Nothing
        End Try
    End Sub
End Class
