﻿Public Class XtraReportVentasCliente
    Private Sub XtraReportVentasCliente_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.imgLogo.Image = LogoEmpresa
            Me.lbEmpresa.Text = GlobalNomEmpresa
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraReportVentasCliente_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.imgLogo.Image = LogoEmpresa
            Me.lbEmpresa.Text = GlobalNomEmpresa
        Catch ex As Exception

        End Try
    End Sub
End Class