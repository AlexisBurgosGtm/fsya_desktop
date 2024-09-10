
Imports System.Data.SqlClient


Public Class viewAgregarShorcut


    Private Sub viewAgregarShorcut_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarCombobox()

    End Sub


    Private Sub CargarCombobox()
        Dim tbl As New DataTable


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT NAVEGAR, DESCRIPCION FROM NAVEGAR WHERE ACTIVO='NO' ORDER BY DESCRIPCION", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        With Me.cmbShorcuts
            .DataSource = tbl
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "NAVEGAR"
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
        End With

    End Sub


    Private Function getTblNavegar() As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("NAVEGAR", GetType(String))
            .Add("DESCRIPCION", GetType(String))
        End With

        With tbl.Rows
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
            .Add("", "")
        End With



    End Function

    'boton aceptar
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If Me.cmbShorcuts.SelectedIndex >= 0 Then
            Using cn As New SqlConnection(strSqlConectionString)
                Try
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If
                    Dim cmd As New SqlCommand("UPDATE NAVEGAR SET ACTIVO='SI' WHERE NAVEGAR=@N", cn)
                    cmd.Parameters.AddWithValue("@N", Me.cmbShorcuts.SelectedValue.ToString)
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox("No se logró agregar el item. Error: " + ex.ToString)
                End Try
            End Using
        Else
            MsgBox("No seleccionaste ningún shorcut para agregar")
        End If
    End Sub

End Class
