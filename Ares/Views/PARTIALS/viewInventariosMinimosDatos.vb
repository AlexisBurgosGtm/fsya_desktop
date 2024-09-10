Public Class viewInventariosMinimosDatos
    Sub New(ByVal _data As DataRow)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        data = _data
    End Sub


    Dim data As DataRow

    Dim objInv As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

    Private Sub viewInventariosMinimosDatos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbDesprod.Text = data.Item(1).ToString
        Me.txtMinimo.Text = data.Item(2).ToString
        Me.txtMaximo.Text = data.Item(3).ToString

        Me.txtMinimo.select()

    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Me.txtMinimo.Text <> "" Then
        Else
            Me.txtMinimo.Text = 1
        End If
        If Me.txtMaximo.Text <> "" Then
        Else
            Me.txtMaximo.Text = 1
        End If
        Dim cod As String, min, max As Integer
        cod = data.Item(0).ToString
        min = Integer.Parse(Me.txtMinimo.Text)
        max = Integer.Parse(Me.txtMaximo.Text)

        If objInv.UpdateMinimoMaximo(cod, min, max) = True Then
            MsgBox("MINIMOS Y MAXIMOS ACTUALIZADOS EXITOSAMENTE")
        Else
            MsgBox("NO SE LOGRÓ ACTUALIZAR LOS MÍNIMOS Y MAXIMOS. ERROR: " & GlobalDesError)
        End If

    End Sub


End Class
