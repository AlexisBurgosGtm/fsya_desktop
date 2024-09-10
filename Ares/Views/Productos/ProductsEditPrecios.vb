Imports System.Data
Imports System.Data.SqlClient

Public Class ProductsEditPrecios

    Sub New(ByVal _codprod As String, ByVal _costounitario As Double, ByVal _codmedida As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        codprod = _codprod
        codmedida = _codmedida
        varCostoUnitario = _costounitario

    End Sub

    Dim codprod As String
    Dim varCostoUnitario As Double
    Dim codmedida As String

    Private Sub ProductsNewPrices_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Call getDataMedida()
        Call CalcularCostoMedida()
        Call CalcularUtilidadProducto()

    End Sub



    Private Sub getDataMedida()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODMEDIDA, COSTO, EQUIVALE, PRECIO, MAYOREOA, MAYOREOB, MAYOREOC,PESO, PORCUTILIDAD, BONO FROM PRECIOS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.cmbProductoMedida.Text = dr(0).ToString

                    'Me.txtCostoUnitario.Text = Double.Parse(dr(1)) / Double.Parse(dr(2))
                    'Me.txtCostoMedida.Text = FormatNumber(dr(1), 2).ToString

                    Me.txtCostoUnitario.Text = FormatNumber(varCostoUnitario, 2)
                    Me.txtCostoMedida.Text = FormatNumber((varCostoUnitario * Double.Parse(dr(2))), 2).ToString

                    Me.txtProductoEquivale.Text = Double.Parse(dr(2))

                    Me.txtPrecioP.Text = FormatNumber(dr(3), 2).ToString
                    Me.txtPrecioA.Text = FormatNumber(dr(4), 2).ToString
                    Me.txtPrecioB.Text = FormatNumber(dr(5), 2).ToString
                    Me.txtPrecioC.Text = FormatNumber(dr(6), 2).ToString
                    Me.txtProductoPeso.Text = dr(7)
                    Me.txtMargenConfig.Text = dr(8)
                    Me.txtProductosBONO.Text = FormatNumber(dr(9), 2).ToString
                End If
                dr.Close()
                cmd.Dispose()


                cn.Close()

            Catch ex As Exception

            End Try

        End Using

    End Sub

    Private Sub CalcularUtilidadProducto()
        'precio publico
        Try
            Me.txtUtilidad.Text = FormatNumber((Double.Parse(Me.txtPrecioP.Text) - Double.Parse(Me.txtCostoMedida.Text)), 2).ToString
            Me.txtMargen.Text = FormatNumber(((Double.Parse(Me.txtUtilidad.Text) / Double.Parse(Me.txtCostoMedida.Text)) * 100), 2).ToString
        Catch ex As Exception
        End Try

        'precio mayoreo a
        Try
            Me.txtUtilidadA.Text = FormatNumber((Double.Parse(Me.txtPrecioA.Text) - Double.Parse(Me.txtCostoMedida.Text)), 2).ToString
            Me.txtMargenA.Text = FormatNumber(((Double.Parse(Me.txtUtilidadA.Text) / Double.Parse(Me.txtCostoMedida.Text)) * 100), 2).ToString
        Catch ex As Exception
        End Try

        'precio mayoreo b
        Try
            Me.txtUtilidadB.Text = FormatNumber((Double.Parse(Me.txtPrecioB.Text) - Double.Parse(Me.txtCostoMedida.Text)), 2).ToString
            Me.txtMargenB.Text = FormatNumber(((Double.Parse(Me.txtUtilidadB.Text) / Double.Parse(Me.txtCostoMedida.Text)) * 100), 2).ToString
        Catch ex As Exception
        End Try

        'precio mayoreo c
        Try
            Me.txtUtilidadC.Text = FormatNumber((Double.Parse(Me.txtPrecioC.Text) - Double.Parse(Me.txtCostoMedida.Text)), 2).ToString
            Me.txtMargenC.Text = FormatNumber(((Double.Parse(Me.txtUtilidadC.Text) / Double.Parse(Me.txtCostoMedida.Text)) * 100), 2).ToString
        Catch ex As Exception
        End Try


    End Sub


    Private Sub CalcularCostoMedida()

        varCostoUnitario = Double.Parse(Me.txtCostoUnitario.Text)

        If Me.txtProductoEquivale.Text <> "" Then
            Try
                If varCostoUnitario > 0 Then Me.txtCostoMedida.Text = Integer.Parse(Me.txtProductoEquivale.Text) * varCostoUnitario
            Catch ex As Exception

            End Try
        Else
            Me.txtProductoEquivale.Text = 1
            Try
                If varCostoUnitario > 0 Then Me.txtCostoMedida.Text = Integer.Parse(Me.txtProductoEquivale.Text) * varCostoUnitario
            Catch ex As Exception
            End Try
        End If

    End Sub



    Private Sub cmbProductoMedida_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoEquivale.select()
        End If
    End Sub

    Private Sub txtProductoEquivale_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoEquivale.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CalcularCostoMedida()
            Call CalcularUtilidadProducto()
            Me.txtProductoPeso.select()

        End If
    End Sub

    Private Sub txtProductoEquivale_Leave(sender As Object, e As EventArgs) Handles txtProductoEquivale.Leave
        Call CalcularCostoMedida()
        Call CalcularUtilidadProducto()
    End Sub


    Private Sub txtProductoPeso_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoPeso.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtPrecioP.select()
        End If
    End Sub

    Private Sub txtProductoPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioP.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Me.txtPrecioP.Text <> "" Then
                Me.txtPrecioA.Text = Me.txtPrecioP.Text
                Me.txtPrecioB.Text = Me.txtPrecioP.Text
                Me.txtPrecioC.Text = Me.txtPrecioP.Text
            End If

            Call CalcularUtilidadProducto()

            Me.txtPrecioA.select()
        End If

    End Sub


    Private Sub txtPrecioA_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioA.KeyDown
        If e.KeyCode = Keys.Enter Then

            Call CalcularUtilidadProducto()

            Me.txtPrecioB.select()

        End If
    End Sub

    Private Sub txtPrecioB_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioB.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CalcularUtilidadProducto()
            Me.txtPrecioC.select()
        End If
    End Sub

    Private Sub txtPrecioC_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrecioC.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CalcularUtilidadProducto()
            Me.btnAceptar.select()
        End If
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If Me.txtProductoPeso.Text <> "" Then
        Else
            Me.txtProductoPeso.Text = "0.01"
        End If

        If Me.txtPrecioA.Text <> "" Then
        Else
            Me.txtPrecioA.Text = Me.txtPrecioP.Text
        End If
        If Me.txtPrecioB.Text <> "" Then
        Else
            Me.txtPrecioB.Text = Me.txtPrecioA.Text
        End If
        If Me.txtPrecioC.Text <> "" Then
        Else
            Me.txtPrecioC.Text = Me.txtPrecioB.Text
        End If

        If Me.txtMargenConfig.Text <> "" Then
        Else
            Me.txtMargenConfig.Text = "0.01"
        End If


        Using cn As New SqlConnection(strSqlConectionString)
            Try


                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String
                sql = "UPDATE PRECIOS SET EQUIVALE=@EQUIVALE, COSTO=@COSTO, PRECIO=@PRECIO, UTILIDAD=@UTILIDAD, PORCUTILIDAD=@MARGEN, MAYOREOA=@MAYOREOA, MAYOREOB=@MAYOREOB, MAYOREOC=@MAYOREOC, PESO=@PESO, BONO=@BONO 
                    WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA"

                Dim CMD As New SqlCommand(sql, cn)
                CMD.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                CMD.Parameters.AddWithValue("@CODMEDIDA", Me.cmbProductoMedida.Text)
                CMD.Parameters.AddWithValue("@CODPROD", codprod)
                CMD.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(Me.txtProductoEquivale.Text))
                CMD.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtCostoMedida.Text))
                CMD.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtPrecioP.Text))
                CMD.Parameters.AddWithValue("@UTILIDAD", 0)
                CMD.Parameters.AddWithValue("@MARGEN", Double.Parse(Me.txtMargenConfig.Text))
                CMD.Parameters.AddWithValue("@MAYOREOA", Double.Parse(Me.txtPrecioA.Text))
                CMD.Parameters.AddWithValue("@MAYOREOB", Double.Parse(Me.txtPrecioB.Text))
                CMD.Parameters.AddWithValue("@MAYOREOC", Double.Parse(Me.txtPrecioC.Text))
                CMD.Parameters.AddWithValue("@PESO", Double.Parse(Me.txtProductoPeso.Text))
                CMD.Parameters.AddWithValue("@BONO", Double.Parse(Me.txtProductosBONO.Text))

                CMD.ExecuteNonQuery()
                CMD.Dispose()
                cn.Close()
                MsgBox("PRECIO ACTUALIZADO EXITOSAMENTE")

                Me.btnAceptarTrue.PerformClick()

            Catch ex As Exception
                MsgBox("No se pudo actualizar el precio. Error: " & ex.ToString)
            End Try

        End Using
    End Sub

    Private Sub btnEliminarPrecio_Click(sender As Object, e As EventArgs) Handles btnEliminarPrecio.Click
        If Confirmacion("¿Está seguro que desea eliminar esta medida de precio?", Me.ParentForm) = True Then
            Using cn As New SqlConnection(strSqlConectionString)
                Try

                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim sql As String
                    sql = "DELETE FROM PRECIOS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA"

                    Dim CMD As New SqlCommand(sql, cn)
                    CMD.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    CMD.Parameters.AddWithValue("@CODMEDIDA", Me.cmbProductoMedida.Text)
                    CMD.Parameters.AddWithValue("@CODPROD", codprod)
                    CMD.ExecuteNonQuery()
                    CMD.Dispose()
                    cn.Close()
                    MsgBox("PRECIO ELIMINADO EXITOSAMENTE")

                    Me.btnAceptarTrue.PerformClick()

                Catch ex As Exception
                    MsgBox("No se pudo ELIMINAR el precio. Error: " & ex.ToString)
                End Try
            End Using
        End If
    End Sub

End Class
