Public Class rptCorteFarmasalud

    Private Sub rptCorteFarmasalud_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        Try
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa
            Call CargarIEF()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CargarIEF()

        Dim adapter As New SqlClient.SqlDataAdapter
        Dim rpM As New rptMovIEF
        rpM.DataSource = AbrirReporteMovIEF(SelectedCorrelativo)
        rpM.DataAdapter = adapter
        rpM.DataMember = "tblMovIEF"
        rpM.CreateDocument()

        Me.XrSubreport1.ReportSource = rpM


    End Sub


    Private Sub rptCorteFarmasalud_AfterPrint(sender As Object, e As EventArgs) Handles MyBase.AfterPrint
        Try
            Me.LBNOMEMPRESA.Text = GlobalNomEmpresa

        Catch ex As Exception

        End Try
    End Sub

End Class