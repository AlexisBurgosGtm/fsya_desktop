Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewFechaMES

    Private Sub viewFechaBetween_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbMesDocumento
            .DataSource = getTblMeses()
            .ValueMember = "CODMES"
            .DisplayMember = "CODMES"
        End With
        With Me.cmbMesDocumento2
            .DataSource = getTblMeses()
            .ValueMember = "CODMES"
            .DisplayMember = "CODMES"
        End With

        Me.cmbMesDocumento.SelectedValue = Integer.Parse(Today.Month)
        Me.cmbMesDocumento2.SelectedValue = Integer.Parse(Today.Month)
        Me.cmbAnioDocumento.Text = Today.Year.ToString

    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'If Me.cmbMesDocumento.SelectedIndex >= 0 Then
        'Else
        'MsgBox("Seleccione un mes inicial de la lista")
        'Exit Sub
        'End If

        'If Me.cmbMesDocumento2.SelectedIndex >= 0 Then
        'Else
        'MsgBox("Seleccione un mes final de la lista")
        'Exit Sub
        'End If
        'If Me.cmbAnioDocumento.Text <> "" Then
        'Else
        'MsgBox("Seleccione un año de la lista")
        'Exit Sub
        'End If

        GlobalParamMesInicial = Integer.Parse(Me.cmbMesDocumento.SelectedValue)
        GlobalParamMesFinal = Integer.Parse(Me.cmbMesDocumento2.SelectedValue)
        GlobalParamAnioCurso = Integer.Parse(Me.cmbAnioDocumento.Text)
        Me.btnAceptarReal.PerformClick()

    End Sub



End Class
