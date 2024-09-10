Imports System.Data.SqlClient

Public Class viewItemSinExistencia
    Sub New(ByVal correlativo As Double)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        VentasCorrelativo = correlativo
    End Sub

    Dim varTotalCosto As Double = 0
    Dim varCodprod As String = "EXT" 'PRODUCTO EXTERNO

    Private Sub viewItemSinExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call fcnCargarMedidas()
        Me.txtCantidad.Text = 1
        Me.txtCosto.Text = 0.01
        Me.txtPrecio.Text = 1
        Me.txtDescripcion.select()
    End Sub

    Private Function InsertarProductoTemp() As Boolean

        Dim result As Boolean

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas 
                (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,NOSERIE,USUARIO,EXENTO,OBS,PRECIOSINIVA,TOTALPRECIOSINIVA) 
                VALUES 
                (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@NOSERIE,@USUARIO,@EXENTO,@OBS,@PRECIOSINIVA,@TOTALPRECIOSINIVA)", cn)

                'VERIFICO QUE SEA UNA COMPRA O UNA VENTA
                If SelectedForm = "ENVIOS" Then
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocENVIOS)
                    cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtPrecio.Text)) 'VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtCosto.Text))
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtTotalPrecio.Text))
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Integer.Parse(Me.txtCantidad.Text) * Double.Parse(Me.txtCosto.Text))
                    cmd.Parameters.AddWithValue("@BONIF", 0)
                    cmd.Parameters.AddWithValue("@TOTALBONIF", 0)

                End If
                If SelectedForm = "VENTAS" Then
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                    cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtPrecio.Text)) 'VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtCosto.Text))
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtTotalPrecio.Text))
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Integer.Parse(Me.txtCantidad.Text) * Double.Parse(Me.txtCosto.Text))
                    cmd.Parameters.AddWithValue("@BONIF", 0)
                    cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                End If
                If SelectedForm = "COTIZACIONES" Then
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOTIZ)
                    cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtPrecio.Text)) 'VentasPrecioProducto)
                    cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtCosto.Text))
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtTotalPrecio.Text))
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Integer.Parse(Me.txtCantidad.Text) * Double.Parse(Me.txtCosto.Text))
                    cmd.Parameters.AddWithValue("@BONIF", 0)
                    cmd.Parameters.AddWithValue("@TOTALBONIF", 0)

                End If


                'calcula el iva parejo
                Dim TOTALIVA As Double = 0
                Dim totalsiniva As Double = (Double.Parse(Me.txtTotalPrecio.Text) / GlobalConfigIVA)
                TOTALIVA = Double.Parse(Me.txtTotalPrecio.Text) - totalsiniva
                cmd.Parameters.AddWithValue("@OBS", "PRODUCTO SIN INVENTARIO")
                cmd.Parameters.AddWithValue("@PRECIOSINIVA", TOTALIVA) 'TOTAL IVA
                cmd.Parameters.AddWithValue("@TOTALPRECIOSINIVA", Double.Parse(Me.txtTotalPrecio.Text) - TOTALIVA) 'TOTAL PRECIO SIN IVA

                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@EXENTO", 0)
                cmd.Parameters.AddWithValue("@NOSERIE", "SN")
                cmd.Parameters.AddWithValue("@CORRELATIVO", VentasCorrelativo)
                cmd.Parameters.AddWithValue("@CODPROD", varCodprod)
                cmd.Parameters.AddWithValue("@DESPROD", Me.txtDescripcion.Text)
                cmd.Parameters.AddWithValue("@CODMEDIDA", Me.cmbMedida.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@EQUIVALE", 1)
                cmd.Parameters.AddWithValue("@CANTIDAD", Integer.Parse(Me.txtCantidad.Text))
                cmd.Parameters.AddWithValue("@TOTALUNIDADES", Integer.Parse(Me.txtCantidad.Text))
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                result = True
            End Using
        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        'VERIFICO QUE SEA UNA COMPRA O UNA VENTA
        If SelectedForm = "ENVIOS" Then
            Form1.txtVentasCodProd.Text = ""
            Form1.txtVentasCodProd.select()
        End If
        If SelectedForm = "VENTAS" Then
            Form1.txtVentasCodProd.Text = ""
            Form1.txtVentasCodProd.select()
        End If
        If SelectedForm = "COTIZACIONES" Then
            Form1.txtVentasCodProd.Text = ""
            Form1.txtVentasCodProd.select()
        End If


        Return result

    End Function


    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbMedida.select()
        End If
    End Sub

    Private Sub cmbMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCantidad.select()
        End If
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown

        If e.KeyCode = Keys.Enter Then
            Me.txtCosto.select()
        End If

    End Sub

    Private Sub txtCosto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCosto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPrecio.select()
        End If
    End Sub

    Private Sub txtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAceptar.select()
        End If
    End Sub

    Private Sub txtPrecio_Leave(sender As Object, e As EventArgs) Handles txtPrecio.Leave
        If fcnVerificarUtilidad() = True Then
            Call fcnCalcularSubtotal()
        Else
            Me.txtPrecio.select()
        End If
    End Sub

    Private Sub cmdUCAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Call fcnCalcularSubtotal()
        If fcnVerifyEmptyFields() = True Then

            If InsertarProductoTemp() = True Then
                Me.btnAceptarTrue.PerformClick()
                Call CargarGridTempVentas()
            Else
                MsgBox("Error al guardar el producto. Error: " & GlobalDesError)
            End If

        Else
            MsgBox("Al parecer usted no ha llenado todas las casillas, por favor verifique")
        End If
    End Sub

    'VERIFICA SI EL PRECIO DE VENTAS ES MAYOR QUE EL COSTO 
    Private Function fcnVerificarUtilidad() As Boolean
        Dim result As Boolean

        Try

            Dim p As Double = Double.Parse(Me.txtPrecio.Text)
            Dim c As Double = Double.Parse(Me.txtCosto.Text)

            If c < p Then
                Result = True
            Else
                Result = False
            End If
        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function

    'CALCULA EL SUBTOTAL DEL IMPORTE
    Private Sub fcnCalcularSubtotal()
        Try
            Dim cant As Integer = Integer.Parse(Me.txtCantidad.Text)
            Dim p As Double = Double.Parse(Me.txtPrecio.Text)
            Dim c As Double = Double.Parse(Me.txtCosto.Text)

            Me.txtTotalPrecio.Text = (p * cant).ToString
            varTotalCosto = c * cant
        Catch ex As Exception
            Me.txtTotalPrecio.Text = 0
            varTotalCosto = 0
        End Try

    End Sub

    'VERIFICA QUE TODOS LOS ESPACIOS ESTÉN LLENOS
    Private Function fcnVerifyEmptyFields() As Boolean
        Dim result As Boolean

        If Me.txtDescripcion.Text <> "" Then
            If Me.cmbMedida.SelectedIndex >= 0 Then
                If Me.txtCantidad.Text <> "" Then
                    If Me.txtCosto.Text <> "" Then
                        If Me.txtPrecio.Text <> "" Then

                            result = True

                        Else
                            result = False
                        End If
                    Else
                        result = False
                    End If
                Else
                    Me.txtCantidad.Text = "1"
                End If
            Else
                result = False
            End If
        Else
            result = False
        End If

        Return result
    End Function

    'CARGA TODAS LAS MEIDAS DEL SISTEMA
    Private Sub fcnCargarMedidas()

        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODMEDIDA,TIPOPRECIO FROM MEDIDAS WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try
        End Using

        Try
            With Me.cmbMedida
                .DataSource = tbl
                .DisplayMember = "CODMEDIDA"
                .ValueMember = "CODMEDIDA"
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
        If Me.txtCantidad.Text <> "" Then
            Call fcnCalcularSubtotal()
        Else
            Me.txtCantidad.Text = 1
            Call fcnCalcularSubtotal()
        End If
    End Sub
End Class
