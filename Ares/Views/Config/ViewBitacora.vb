Public Class ViewBitacora

    Dim objBitacora As New ClassBitacora(CType(Today.Year, Integer), CType(Today.Month, Integer))
    Private Sub ViewBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.GridBitacora.DataSource = objBitacora.tblBitacoraMes()

    End Sub

End Class
