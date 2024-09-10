Public Class viewClientesLista
    Sub New(ByVal _empnit As String, ByVal _form As String)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        empnit = _empnit
        form = _form

    End Sub

    Dim empnit, form As String

    Dim objClientes As New classClientes(GlobalEmpNit)

    Private Sub viewClientesLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.GridClientes.DataSource = objClientes.tbl_clientesall()

    End Sub


    Dim drw As DataRow

    Private Sub GridViewClientes_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewClientes.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewClientes.GetFocusedDataRow

        Catch ex As Exception
            drw = Nothing
        End Try
    End Sub

    Private Sub GridViewClientes_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewClientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call SeleccionarCliente()
        End If
    End Sub

    Private Sub GridViewClientes_DoubleClick(sender As Object, e As EventArgs) Handles GridViewClientes.DoubleClick

        Call SeleccionarCliente()

    End Sub

    Private Sub SeleccionarCliente()
        Try



            Select Case form
                Case "VENTAS"
                    SelectedCode = CType(drw.Item(0), Integer)
                    Form1.SelectedNitCliente = drw.Item(1).ToString
                    Form1.SelectedNomCliente = drw.Item(2).ToString
                    Select Case drw.Item(7).ToString
                        Case "P"
                            Form1.lbVentasTipoPrecio.Text = "PUBLICO"
                        Case "A"
                            Form1.lbVentasTipoPrecio.Text = "MAYOREO A"
                        Case "B"
                            Form1.lbVentasTipoPrecio.Text = "MAYOREO B"
                        Case "C"
                            Form1.lbVentasTipoPrecio.Text = "MAYOREO C"
                    End Select
                    Me.btnAceptar.PerformClick()
                Case "LISTADOS"

                    SelectedCode = CType(drw.Item(0), Integer)
                    GlobalSelectedNitCliente = drw.Item(1).ToString
                    GlobalSelectedNomCliente = drw.Item(2).ToString
                    GlobalSelectedDirCliente = drw.Item(3).ToString

                    Me.btnAceptar.PerformClick()

                Case "ENVIOS"
                    SelectedCode = CType(drw.Item(0), Integer)
                    Form1.SelectedNitCliente = drw.Item(1).ToString
                    Form1.SelectedNomCliente = drw.Item(2).ToString
                    Select Case drw.Item(7).ToString
                        Case "P"
                            Form1.lbVentasTipoPrecio.Text = "PUBLICO"
                        Case "A"
                            Form1.lbVentasTipoPrecio.Text = "MAYOREO A"
                        Case "B"
                            Form1.lbVentasTipoPrecio.Text = "MAYOREO B"
                        Case "C"
                            Form1.lbVentasTipoPrecio.Text = "MAYOREO C"
                    End Select

                    Me.btnAceptar.PerformClick()
                Case "COTIZACIONES"
                    SelectedCode = CType(drw.Item(0), Integer)
                    Form1.SelectedNitCliente = drw.Item(1).ToString
                    Form1.SelectedNomCliente = drw.Item(2).ToString
                    Me.btnAceptar.PerformClick()
                Case "ORDENTRABAJO"
                    SelectedCode = CType(drw.Item(0), Integer)
                    GlobalNomCliente = drw.Item(2).ToString
                    Me.btnAceptar.PerformClick()
            End Select

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class
