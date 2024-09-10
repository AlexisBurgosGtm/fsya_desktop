Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen

Public Class AdminChangeCode
    Sub New(ByVal CodigoActual As String, ByVal DesProd As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.txtCodigoActual.Text = CodigoActual
        Me.lbDesProd.Text = DesProd
    End Sub
    Private Sub AdminChangeCode_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub txtNuevoCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNuevoCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdCambiarCodigo.select()
        End If
    End Sub

    Private Sub txtNuevoCodigo_Leave(sender As Object, e As EventArgs) Handles txtNuevoCodigo.Leave
        If VerificarCodProd(Me.txtNuevoCodigo.Text) = True Then
            Me.txtNuevoCodigo.select()
            MsgBox("Este código ya existe, por favor, escriba otro")
        End If
    End Sub

    Private Sub cmdCambiarCodigo_Click(sender As Object, e As EventArgs) Handles cmdCambiarCodigo.Click
        If Me.txtNuevoCodigo.Text <> "" Then


            If VerificarCodProd(Me.txtNuevoCodigo.Text) = True Then
                MsgBox("Este código ya existe, por favor, escriba otro")
                Exit Sub

            Else
                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
                Call AbrirConexionSql()
                Dim cmd As New SqlClient.SqlCommand("CambiarCodProd", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandTimeout = 0
                cmd.Parameters.AddWithValue("@CODPROD", Me.txtCodigoActual.Text)
                cmd.Parameters.AddWithValue("@CODPRODNEW", Me.txtNuevoCodigo.Text)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                SplashScreenManager.CloseForm()
                'Call Form1.EnviarNotificacionesEmail(0, "Ares POS te Informa: Cambio de Código de producto", "Se ha cambiado el código de producto " & Me.txtCodigoActual.Text & " - " & Me.lbDesProd.Text & " por el código " & Me.txtNuevoCodigo.Text & ", mediante el usuario " & GlobalNomUsuario)

            End If
        Else
            MsgBox("No se especificó el nuevo código de producto")
        End If
    End Sub

    Public Function VerificarCodProd(ByVal Codigo As String) As Boolean
        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("Select CodProd From Precios Where Empnit='" & GlobalEmpNit & "' and Codprod='" & Codigo & "'", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                If EditarProducto = False Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function 'VERIFICO SI EL CÒDIGO EXISTE O NO
End Class
