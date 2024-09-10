Public Class viewProductosPreciosCompetencia

    Sub New(ByVal _empnit As String, ByVal _codprod As String, ByVal _desprod As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        empnit = _empnit
        codprod = _codprod
        Me.lbDesprod.Text = _desprod
    End Sub

    Dim empnit, codprod As String
    Dim objproductos As New ClassProductos


    Private Sub viewProductosPreciosCompetencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtFecha.DateTime = Today.Date


        Call CargarGrid()

        Call CargarComboProveedores()

    End Sub
    Private Sub CargarComboProveedores()
        Dim tbl As New DataTable

        Using cn As New SqlClient.SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlClient.SqlCommand("SELECT CODPROV, EMPRESA FROM PROVEEDORES WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlClient.SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        With Me.txtProveedor
            .DataSource = tbl
            .DisplayMember = "EMPRESA"
            .ValueMember = "CODPROV"
        End With

    End Sub

    Private Sub CargarGrid()
        Me.GridPrecios.DataSource = Nothing
        Me.GridPrecios.DataSource = objproductos.GetPreciosCompetencia(empnit, codprod)
        Me.GridPrecios.RefreshDataSource()
    End Sub

    Private Sub GridViewPrecios_DoubleClick(sender As Object, e As EventArgs) Handles GridViewPrecios.DoubleClick
        If Confirmacion("¿Está seguro que desea ELIMINAR este precio?", Me.ParentForm) = True Then
            If objproductos.DeletePrecioCompetencia(empnit, codprod) = True Then
                Call CargarGrid()
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If ValidarCampos() = True Then
            If objproductos.InsertPrecioCompetencia(empnit, codprod, Me.txtProveedor.Text, Me.txtDireccion.Text, Me.txtTels.Text, Me.txtObs.Text, Double.Parse(Me.txtPrecio.Text), Today.Date) = True Then
                Call CargarGrid()
                Call limpiarCampos()
            End If

        End If
    End Sub

    Private Sub limpiarCampos()
        'Me.txtProveedor.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtTels.Text = ""
        Me.txtObs.Text = ""
        Me.txtPrecio.Text = 0
    End Sub

    Private Function ValidarCampos() As Boolean
        Dim result As Boolean

        If Me.txtProveedor.Text <> "" Then
            If Me.txtDireccion.Text = "" Then
            Else
                Me.txtDireccion.Text = "CIUDAD"
            End If
            If Me.txtTels.Text <> "" Then
            Else
                Me.txtTels.Text = "0000"
            End If
            If Me.txtObs.Text <> "" Then
            Else
                Me.txtObs.Text = "SN"
            End If

            If Me.txtPrecio.Text <> "" Then

                result = True

            Else
                result = False
                MsgBox("Escriba el precio al que la competencia vende")
            End If

        Else
            result = False
            MsgBox("Escriba el nombre del Proveedor")
        End If

        Return result
    End Function



End Class
