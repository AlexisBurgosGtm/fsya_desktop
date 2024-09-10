Public Class XtraReportINVFISICO
    Private Sub XtraReportINVFISICO_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.imgLogo.Image = LogoEmpresa

            If Double.Parse(Me.XrLabel2.Text) >= 0 Then
            Else
                Me.XrLabel2.ForeColor = Color.Salmon
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraReportINVFISICO_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.imgLogo.Image = LogoEmpresa

            If Double.Parse(Me.XrLabel2.Text) >= 0 Then
            Else
                Me.XrLabel2.ForeColor = Color.Salmon
            End If
        Catch ex As Exception

        End Try
    End Sub


End Class