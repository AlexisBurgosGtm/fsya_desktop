Public Class viewCxpAbonos
    Sub New(ByVal DatosFactura As DataRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        datos = DatosFactura
    End Sub
    Dim datos As DataRow
    Dim ObjCxp As New classCxp

    Private Sub viewCxpAbonos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbFactura.Text = datos.Item(4).ToString & " - " & datos.Item(5).ToString
        Me.lbNit.Text = datos.Item(0).ToString
        Me.LbCliente.Text = datos.Item(1).ToString

        Me.lbTotalFactura.Text = datos.Item(6).ToString
        Me.LbAbonos.Text = Strings.Mid(datos.Item(8).ToString, 2)
        Me.LbSaldo.Text = Strings.Mid(datos.Item(7).ToString, 2)

        Me.GridAbonos.DataSource = ObjCxp.tblAbonosFactura(GlobalEmpNit, datos.Item(4).ToString, Double.Parse(datos.Item(5)))

    End Sub
End Class
