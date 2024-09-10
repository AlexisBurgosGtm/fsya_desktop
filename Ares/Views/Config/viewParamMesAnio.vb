Public Class viewParamMesAnio


    Private Sub viewParamMesAnio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
        With Me.cmbMes
            .DataSource = objTipoDoc.tblMeses()
            .ValueMember = "CODMES"
            .DisplayMember = "DESMES"
        End With

        With Me.cmbAnio
            .DataSource = objTipoDoc.tblAnios()
            .ValueMember = "CODANIO"
            .DisplayMember = "CODANIO"
        End With


        Me.cmbMes.SelectedValue = CType(Today.Month, Integer)
        Me.cmbAnio.Text = Today.Year.ToString


    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Me.cmbMes.SelectedIndex >= 0 Then
            If Me.cmbAnio.Text <> "" Then

                GlobalParamMes = CType(Me.cmbMes.SelectedValue, Integer)
                GlobalParamAnio = CType(Me.cmbAnio.Text, Integer)

                Me.btnAceptarTrue.PerformClick()

            Else
                MsgBox("Seleccione un año de la lista")
            End If
        Else
            MsgBox("Seleccione un Mes de la Lista")
        End If
    End Sub


End Class
