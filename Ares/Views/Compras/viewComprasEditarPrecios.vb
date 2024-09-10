Imports System.Data.SqlClient

Public Class viewComprasEditarPrecios
    Sub New(ByVal _empnit As String, ByVal _coddoc As String, ByVal _correlativo As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        empnit = _empnit
        coddoc = _coddoc
        correlativo = _correlativo

    End Sub

    Dim empnit As String
    Dim coddoc As String
    Dim correlativo As Double

    Dim objCompras As New classCompras(GlobalEmpNit)


    Private Sub viewComprasEditarPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            objCompras.GenerartblPreciosCompra(coddoc, correlativo)
            Call CargarGrid()

        Catch ex As Exception
            MsgBox("Al parecer hay un error con la tabla. Cierra y vuelva a abrir esta ventana para que yo corrija ese problema")
            Call CorregirTablaTemp()

            Me.SimpleButton1.PerformClick()

        End Try


    End Sub

    Private Sub CorregirTablaTemp()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DROP TABLE TEMP_PRECIOSCOMPRA", cn)
                cmd.ExecuteNonQuery()

                Dim cmt As New SqlCommand("CREATE TABLE [dbo].[TEMP_PRECIOSCOMPRA](
	                                        [EMPNIT] [varchar](50) NULL,
	                                        [CODDOC] [varchar](50) NULL,
	                                        [CORRELATIVO] [numeric](18, 0) NULL,
	                                        [CODPROD] [varchar](100) NULL,
	                                        [DESPROD] [varchar](255) NULL,
	                                        [CODMEDIDA] [varchar](50) NULL,
	                                        [EQUIVALE] [int] NULL,
	                                        [COSTOACTUAL] [numeric](18, 4) NULL,
	                                        [COSTONUEVO] [numeric](18, 4) NULL,
	                                        [PRECIOACTUAL] [numeric](18, 2) NULL,
	                                        [PRECIONUEVO] [numeric](18, 2) NULL,
	                                        [PRECIOACTUALMA] [numeric](18, 2) NULL,
	                                        [PRECIOACTUALMB] [numeric](18, 2) NULL,
	                                        [PRECIOACTUALMC] [numeric](18, 2) NULL,
	                                        [PRECIONUEVOMA] [numeric](18, 2) NULL,
	                                        [PRECIONUEVOMB] [numeric](18, 2) NULL,
	                                        [PRECIONUEVOMC] [numeric](18, 2) NULL
                                        ) ON [PRIMARY]", cn)
                cmt.ExecuteNonQuery()

            Catch ex As Exception

            End Try
        End Using
    End Sub
    Private Sub CargarGrid()
        Dim obj As New classCompras(GlobalEmpNit)
        Me.GridPrecios.DataSource = Nothing
        Me.GridPrecios.DataSource = obj.tblPreciosCompra(coddoc, correlativo)
        Me.GridPrecios.Columns(0).Width = 75
        Me.GridPrecios.Columns(1).Width = 160
        Me.GridPrecios.Columns(2).Width = 55
        Me.GridPrecios.Columns(3).Width = 40

        Me.GridPrecios.Update()
        'Me.GridPrecios.Refresh()
        'Me.DGVGastosTemp.Columns(1).Width = 120
    End Sub

    Dim drw As DataRow

    Dim indexrow As Integer

    Private Sub GetDataPrecio()
        Try
            Me.lbCodprod.Text = Me.GridPrecios.Item(0, Me.GridPrecios.CurrentRow.Index).Value.ToString
            Me.lbDesproducto.Text = Me.GridPrecios.Item(1, Me.GridPrecios.CurrentRow.Index).Value.ToString
            Me.lbMedida.Text = Me.GridPrecios.Item(2, Me.GridPrecios.CurrentRow.Index).Value.ToString
            Me.txtCostoActual.Text = FormatNumber(Me.GridPrecios.Item(4, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString
            Me.txtCostoNuevo.Text = FormatNumber(Me.GridPrecios.Item(5, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString

            Me.txtPrecioActual.Text = FormatNumber(Me.GridPrecios.Item(6, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString
            Me.txtPrecioNuevo.Text = FormatNumber(Me.GridPrecios.Item(7, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString

            Me.txtPrecioActualMayoreoA.Text = FormatNumber(Me.GridPrecios.Item(8, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString
            Me.txtPrecioNuevoMayoreoA.Text = FormatNumber(Me.GridPrecios.Item(9, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString

            Me.txtPrecioActualMayoreoB.Text = FormatNumber(Me.GridPrecios.Item(10, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString
            Me.txtPrecioNuevoMayoreoB.Text = FormatNumber(Me.GridPrecios.Item(11, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString

            Me.txtPrecioActualMayoreoC.Text = FormatNumber(Me.GridPrecios.Item(12, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString
            Me.txtPrecioNuevoMayoreoC.Text = FormatNumber(Me.GridPrecios.Item(13, Me.GridPrecios.CurrentRow.Index).Value.ToString, 2).ToString

            'Me.DGVGastosTemp.Item(0, Me.DGVGastosTemp.CurrentRow.Index).Value.ToString
            indexrow = Me.GridPrecios.CurrentRow.Index
        Catch ex As Exception
            '  MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnGuardarPrecio_Click(sender As Object, e As EventArgs) Handles btnGuardarPrecio.Click
        If Confirmacion("¿Está seguro que desea Actualizar este precio en el catálogo de productos?", Me.ParentForm) = True Then
            If objCompras.UpdatePrecioCompras(Me.lbCodprod.Text, Me.lbMedida.Text,
                                              CType(Me.txtPrecioNuevo.Text, Double),
                                              CType(Me.txtPrecioNuevoMayoreoA.Text, Double),
                                              CType(Me.txtPrecioNuevoMayoreoB.Text, Double),
                                              CType(Me.txtPrecioNuevoMayoreoC.Text, Double),
                                              coddoc, correlativo) = True Then


                MsgBox("El precio se ha actualizado exitosamente")

                Me.GridPrecios.DataSource = Nothing
                Call CargarGrid()

            Else
                MsgBox("El precio no se pudo actualizar " + GlobalDesError)
            End If
        End If

    End Sub



    Private Sub GridPrecios_SelectionChanged(sender As Object, e As EventArgs) Handles GridPrecios.SelectionChanged
        Call GetDataPrecio()
    End Sub

    Private Sub txtPrecioNuevo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPrecioNuevo.KeyUp
        Try
            Me.txtPrecioNuevoMayoreoA.Text = Me.txtPrecioNuevo.Text
            Me.txtPrecioNuevoMayoreoB.Text = Me.txtPrecioNuevo.Text
            Me.txtPrecioNuevoMayoreoC.Text = Me.txtPrecioNuevo.Text
            Me.txtPrecioNuevoMayoreoD.Text = Me.txtPrecioNuevo.Text
            Me.txtPrecioNuevoMayoreoE.Text = Me.txtPrecioNuevo.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPrecioNuevo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioNuevo.KeyDown

        If e.KeyCode = Keys.Enter Then
            Me.txtPrecioNuevoMayoreoA.select()
        End If

    End Sub

    Private Sub txtPrecioNuevoMayoreoA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioNuevoMayoreoA.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPrecioNuevoMayoreoB.select()
        End If
    End Sub

    Private Sub txtPrecioNuevoMayoreoB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioNuevoMayoreoB.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPrecioNuevoMayoreoC.select()
        End If
    End Sub

    Private Sub txtPrecioNuevoMayoreoC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioNuevoMayoreoC.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardarPrecio.select()
        End If
    End Sub


End Class
