
Imports System.Data.SqlClient

Public Class viewPedidosEditar

    Sub New(ByVal _drw As DataRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        drw = _drw

    End Sub

    'data
    Dim drw As DataRow


    Private Sub viewPedidosEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.lbCoddoc.Text = drw.Item(0).ToString
        Me.lbCorrelativo.Text = drw.Item(1).ToString
        Me.txtFecha.DateTime = Date.Parse(drw.Item(9))

        Me.txtNit.Text = drw.Item(10).ToString
        Me.txtNomclie.Text = drw.Item(5).ToString
        Me.txtDirclie.Text = drw.Item(3).ToString

        Me.lbTotaVenta.Text = FormatCurrency(drw.Item(7))
        Me.lbTotalPrecio.Text = FormatNumber(drw.Item(7)).ToString
        Me.lbTotalCosto.Text = FormatNumber(drw.Item(6)).ToString

        Call CargarGrid()

    End Sub

    Private Sub CargarGrid()
        Dim tbl As New DataTable
        tbl = tblEnviosTicketHost(Me.lbCoddoc.Text, Double.Parse(Me.lbCorrelativo.Text), Date.Parse(Me.txtFecha.DateTime))

        Me.GridDetallePedido.DataSource = tbl
    End Sub


    Private Sub GridViewDetallePedido_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetallePedido.FocusedRowChanged
        Try
            drwselected = Nothing
            drwselected = Me.GridViewDetallePedido.GetFocusedDataRow
        Catch ex As Exception
            drwselected = Nothing
        End Try
    End Sub

    Dim drwselected As DataRow
    Private Sub GridViewDetallePedido_DoubleClick(sender As Object, e As EventArgs) Handles GridViewDetallePedido.DoubleClick

        If Confirmacion("¿Está seguro que desea ELIMINAR este ITEM ?", Me.ParentForm) = True Then
            If deleteProducto(Token,
                              GlobalEmpNit,
                              Me.lbCoddoc.Text,
                              Double.Parse(Me.lbCorrelativo.Text),
                              Integer.Parse(drwselected.Item(13)),
                              Integer.Parse(Me.txtCantidad.Text),
                              Double.Parse(Me.lbTotalCosto.Text),
                              Double.Parse(Me.lbTotalPrecio.Text),
                              Double.Parse(drwselected.Item(7)),
                              Double.Parse(drwselected.Item(8))
                              ) = True Then



                Me.btnEditarCancelar.PerformClick()
                Call CargarGrid()

            End If
        End If

        Exit Sub

        Me.lbCodprod.Text = drwselected.Item(3).ToString
        Me.lbDesprod.Text = drwselected.Item(4).ToString
        '5, codmedida, 7 costo, 8 precio
        Me.txtCantidad.Text = drwselected.Item(6)
        Me.txtPrecio.Text = drwselected.Item(8).ToString
        Me.txtSubtotal.Text = (Integer.Parse(drwselected.Item(6)) * Double.Parse(drwselected.Item(8))).ToString

        Me.FlyoutPanelEditProducto.ShowPopup()
    End Sub

    Private Sub btnEditarCancelar_Click(sender As Object, e As EventArgs) Handles btnEditarCancelar.Click

        Me.FlyoutPanelEditProducto.HidePopup()

    End Sub

    Private Sub btnEditQuitarItem_Click(sender As Object, e As EventArgs) Handles btnEditQuitarItem.Click
        ' Exit Sub
        If Confirmacion("¿Está seguro que desea ELIMINAR este ITEM ?", Me.ParentForm) = True Then
            If deleteProducto(Token,
                              GlobalEmpNit,
                              Me.lbCoddoc.Text,
                              Double.Parse(Me.lbCorrelativo.Text),
                              Integer.Parse(drwselected.Item(13)),
                              Integer.Parse(Me.txtCantidad.Text),
                              Double.Parse(Me.lbTotalCosto.Text),
                              Double.Parse(Me.lbTotalPrecio.Text),
                              Double.Parse(drwselected.Item(7)),
                              Double.Parse(drwselected.Item(8))
                              ) = True Then



                Me.btnEditarCancelar.PerformClick()
                Call CargarGrid()

            End If
        End If
    End Sub


#Region " OPERACIONES EN EL HOST"

    Private Function setProducto(ByVal token As String, ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal item As Integer, ByVal cantidad As Integer, ByVal totalcosto As Double, ByVal totalprecio As Double) As Boolean
        Dim r As Boolean
        Using cnh As New SqlClient.SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE WEB_DOCPRODUCTOS SET 
                CANTIDAD=@C, TOTALCOSTO=@TC, TOTALPRECIO=@TP WHERE ID=@ITEM", cnh)
                cmd.Parameters.AddWithValue("@ITEM", item)
                cmd.Parameters.AddWithValue("@C", item)
                cmd.Parameters.AddWithValue("@TC", item)
                cmd.Parameters.AddWithValue("@TP", item)

                cmd.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try

        End Using

        Return r
    End Function

    Private Function deleteProducto(ByVal token As String,
                                    ByVal empnit As String,
                                    ByVal coddoc As String,
                                    ByVal correlativo As Double,
                                    ByVal item As Integer,
                                    ByVal cantidad As Integer,
                                    ByVal totalcosto As Double,
                                    ByVal totalprecio As Double,
                                    ByVal selectedcosto As Double,
                                    ByVal selectedprecio As Double
                                    ) As Boolean

        Dim r As Boolean


        Using cnh As New SqlClient.SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM WEB_DOCPRODUCTOS WHERE ID=@ITEM", cnh)
                cmd.Parameters.AddWithValue("@ITEM", item)

                cmd.ExecuteNonQuery()
                'MsgBox(totalcosto.ToString & " " & selectedcosto.ToString & " // " & totalprecio.ToString & " " & selectedprecio.ToString)

                If updateTotalsDocto(token, empnit, coddoc, correlativo, (totalcosto - selectedcosto), (totalprecio - selectedprecio)) = True Then

                End If

                Me.lbTotaVenta.Text = FormatCurrency(totalprecio - selectedprecio).ToString
                Me.lbTotalPrecio.Text = FormatNumber(totalprecio - selectedprecio)
                Me.lbTotalCosto.Text = FormatNumber(totalcosto - selectedcosto)

                r = True

            Catch ex As Exception
                MsgBox("Error al eliminar: " & ex.ToString)
                GlobalDesError = ex.ToString
                r = False
            End Try

        End Using

        Return r
    End Function

    Private Function updateTotalsDocto(ByVal token As String, ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal nuevocosto As Double, ByVal nuevoprecio As Double) As Boolean

        Dim r As Boolean


        Using cnh As New SqlClient.SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE WEB_DOCUMENTOS SET TOTALCOSTO=@NC, TOTALVENTA=@NP WHERE TOKEN=@T AND EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cnh)
                cmd.Parameters.AddWithValue("@T", token)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                cmd.Parameters.AddWithValue("@NC", nuevocosto)
                cmd.Parameters.AddWithValue("@NP", nuevoprecio)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                MsgBox("Error al actualizar: " & ex.ToString)
                GlobalDesError = ex.ToString
                r = False
            End Try

        End Using

        Return r


    End Function

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

    End Sub

    Private Sub btnEditarAceptar_Click(sender As Object, e As EventArgs) Handles btnEditarAceptar.Click

    End Sub

#End Region


End Class
