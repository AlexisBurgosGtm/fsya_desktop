Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewFechaCAL

    Private Sub viewFechaCAL_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtDatePickInicial.Value = Today.Date
        Me.txtDatePickFinal.Value = Today.Date

    End Sub

    'Private Sub dateTimePD_load(sender As Object, e As EventArgs) Handles MyBase.Load
    'Me.txtDatePickInicial.Value = Today.Date
    'Me.txtDatePickFinal.Value = Today.Date

    'End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        GlobalParamDatePickI = Date.Parse(Me.txtDatePickInicial.Value)
        GlobalParamDatePickF = Date.Parse(Me.txtDatePickFinal.Value)


        Me.btnAceptarReal.PerformClick()

    End Sub

End Class
