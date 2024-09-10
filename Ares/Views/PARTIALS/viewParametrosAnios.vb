Public Class viewParametrosAnios
    Private Sub viewParametrosAnios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CargaComboAnios()
    End Sub


    Private Sub CargaComboAnios()


        Try
            Me.cmbAnioFinal.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbAnioFinal.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.cmbAnioInicial.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Me.cmbAnioInicial.AutoCompleteSource = AutoCompleteSource.ListItems
        Catch ex As Exception

        End Try

        Me.cmbAnioInicial.Text = GlobalAnioProceso.ToString
        Me.cmbAnioFinal.Text = GlobalAnioProceso.ToString

    End Sub

    Private Sub cmbAnioInicial_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbAnioInicial.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbAnioFinal.select()
        End If
    End Sub

    Private Sub cmbAnioFinal_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbAnioFinal.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAceptar.select()
        End If
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Me.cmbAnioInicial.Text <> "" Then
        Else
            Me.cmbAnioInicial.Text = GlobalAnioProceso.ToString
        End If
        If Me.cmbAnioFinal.Text <> "" Then
        Else
            Me.cmbAnioFinal.Text = GlobalAnioProceso.ToString
        End If


        GlobalParamAnioInicial = Integer.Parse(Me.cmbAnioInicial.Text)
        GlobalParamAnioFinal = Integer.Parse(Me.cmbAnioFinal.Text)
    End Sub
End Class
