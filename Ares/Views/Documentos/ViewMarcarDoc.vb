Imports System.Data.SqlClient

Public Class ViewMarcarDoc
    Sub New(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal Vista As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        empresa = empnit
        serie = coddoc
        nodoc = correlativo
        view = Vista
    End Sub

    Dim empresa, serie, view As String
    Dim nodoc As Double

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAceptar.select()
        End If
    End Sub



    Private Sub ViewMarcarDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbDocumento.Text = serie & " - " & nodoc.ToString

        If view = "SI" Then
            Call CargarObs()
        Else
            Me.txtObs.select()
        End If
    End Sub

    Private Sub CargarObs()
        Call AbrirConexionSql()
        Dim cmd As New System.Data.SqlClient.SqlCommand("SELECT OBSMARCA FROM DOCUMENTOS WHERE ID=" & SelectedCode & " AND EMPNIT='" & empresa & "'", cn)
        Dim dr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                Me.txtObs.Text = dr(0).ToString
            End If
        Catch ex As Exception
            Me.txtObs.Text = ""
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()
        Me.txtObs.Enabled = False

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If view = "NO" Then

            If Me.txtObs.Text <> "" Then
            Else
                Me.txtObs.Text = "SN"
            End If

            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET MARCA='SI', OBSMARCA='" & Me.txtObs.Text & "' WHERE EMPNIT='" & empresa & "' AND ID=" & SelectedCode, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()

        End If
    End Sub

End Class
