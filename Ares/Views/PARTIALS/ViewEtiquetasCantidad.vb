Public Class ViewEtiquetasCantidad

    Sub New(ByVal CodProd As String, ByVal CodMedidaSelect As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CodProducto = CodProd
        Me.lbPrimerMedida.Text = CodMedidaSelect
    End Sub
    Dim CodProducto As String
    Dim objProductos As New ClassProductos

    Private Sub ViewEtiquetasCantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For x = 1 To 100
            Me.cmbCantidad.Items.Add(x)
        Next

        'carga los datos de la medida de precios de oferta
        With Me.cmbCodMedOferta
            .DataSource = objProductos.tblPreciosProducto(GlobalEmpNit, CodProducto)
            .ValueMember = "PRECIO"
            .DisplayMember = "CODMEDIDA"
        End With

        'intenta mover el foco de la medida de precio de oferta hacia la primer fila
        Try
            Me.cmbCodMedOferta.SelectedIndex = 0
        Catch ex As Exception

        End Try


        Me.cmbCantidad.Text = 1
        Me.cmbCantidad.select()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Me.cmbCantidad.Text <> "" Then
            If Integer.Parse(Me.cmbCantidad.Text) > 0 Then

                GlobalCantidad = Integer.Parse(Me.cmbCantidad.Text)
            Else
                GlobalCantidad = 0
            End If
        Else
            GlobalCantidad = 0
        End If


        If Me.cmbCodMedOferta.SelectedIndex >= 0 Then

            Try
                SelectedCodMedida = Me.cmbCodMedOferta.Text
                SelectedPrecio = Me.cmbCodMedOferta.SelectedValue.ToString
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub cmbCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then

            Me.cmbCodMedOferta.select()
        End If
    End Sub

    Private Sub cmbCodMedOferta_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCodMedOferta.KeyDown

        If e.KeyCode = Keys.Enter Then
            Me.btnAceptar.select()
        End If

    End Sub

    Private Sub cmbCodMedOferta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCodMedOferta.SelectedIndexChanged
        Try
            Me.lbPrecioMedOf.Text = Me.cmbCodMedOferta.SelectedValue.ToString
        Catch ex As Exception

        End Try

    End Sub
End Class
