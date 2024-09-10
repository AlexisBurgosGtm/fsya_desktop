Public Class viewOrdenTrabajoEditar
    Sub New(ByVal _coddoc As String, ByVal _correlativo As Double, ByVal _detalle As String, ByVal _obs As String, ByVal _valor As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        coddoc = _coddoc
        correlativo = _correlativo
        detalle = _detalle
        obs = _obs
        valor = _valor
    End Sub

    Dim coddoc, detalle, obs As String
    Dim correlativo, valor As Double

    Private Sub viewOrdenTrabajoEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtDetRevision.Text = detalle
        Me.txtObs.Text = obs
        Me.txtValor.Text = valor
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.txtDetRevision.Text <> "" Then
            If Me.txtObs.Text <> "" Then
            Else
                Me.txtObs.Text = "SN"
            End If

            If Me.txtValor.Text <> "" Then
                Dim objOrden As New classOrdenTrabajo(GlobalEmpNit)
                If objOrden.EditOrdenTrabajo(coddoc, correlativo, Me.txtDetRevision.Text, Me.txtObs.Text, Double.Parse(Me.txtValor.Text)) = True Then
                    Form1.Mensaje("Orden editada exitosamente")
                    Me.btnAceptarTrue.PerformClick()
                Else
                    MsgBox("No se pudo Editar la Orden. Error: " + GlobalDesError)
                End If
            Else
                MsgBox("Escriba el valor estimado a cobrar")
            End If
        Else
            MsgBox("Escriba la descripción o detalle de la orden")

        End If
    End Sub

End Class
