Imports System.Data.SqlClient


Public Class ProductsNewPrices

    Sub New(ByVal _codprod As String, ByVal _costounitario As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        codprod = _codprod
        varCostoUnitario = _costounitario

    End Sub

    Dim codprod As String
    Dim varCostoUnitario As Double

    Private Sub ProductsNewPrices_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtProductoEquivale.Text = 1
        Me.txtProductoPeso.Text = 0

        Me.txtCostoUnitario.Text = FormatNumber(varCostoUnitario, 2)
        Me.txtCostoMedida.Text = FormatNumber(varCostoUnitario, 2)
        Me.txtMargenConfig.Text = "0.01"

        Me.cmbProductoMedida.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.cmbProductoMedida.AutoCompleteSource = AutoCompleteSource.ListItems

        Call CargarMedidas()

    End Sub

    Public Sub CargarMedidas()

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Try
                'MEDIDAS PRECIO
                Dim Dt4 As DataTable
                Dim Da4 As New SqlDataAdapter
                Dim Cmd4 As New SqlCommand
                With Cmd4
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT CODMEDIDA FROM MEDIDAS WHERE EMPNIT='" & GlobalEmpNit & "'"
                    .Connection = cn
                End With
                Da4.SelectCommand = Cmd4
                Dt4 = New DataTable
                Da4.Fill(Dt4)

                With Me.cmbProductoMedida
                    .DataSource = Dt4
                    .DisplayMember = "CODMEDIDA"
                    '.ValueMember = "EQUIVALE"
                End With

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

    Private Sub cmbProductoMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbProductoMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProductoEquivale.select()
        End If
    End Sub

    Private Sub txtProductoEquivale_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductoEquivale.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CalcularCostoMedida()

            Me.txtProductoPeso.select()

        End If
    End Sub

    Private Sub txtProductoEquivale_Leave(sender As Object, e As EventArgs) Handles txtProductoEquivale.Leave
        Call CalcularCostoMedida()
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
        If Me.txtMargenConfig.Text <> "" Then
        Else
            Me.txtMargenConfig.Text = "0.01"
        End If
        If Me.txtProductosBONO.Text <> "" Then
        Else
            Me.txtProductosBONO.Text = "0.00"
        End If


        '*** PROCEDIMIENTO PARA GUARDAR PRECIO ******

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim sql As String
            If EditarProducto = False Then
                'si se está creando un producto nuevo los datos se insertan en la tabla temporal
                sql = "INSERT INTO TEMP_PRECIOS (EMPNIT,USUARIO,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,MARGEN,MAYOREOA,MAYOREOB,MAYOREOC,PESO,BONO) VALUES (@EMPNIT,@USUARIO,@CODMEDIDA,@EQUIVALE,@COSTO,@PRECIO,@UTILIDAD,@MARGEN,@MAYOREOA,@MAYOREOB,@MAYOREOC,@PESO,@BONO)"
                Dim CMD As New SqlCommand(sql, cn)
                CMD.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                CMD.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                CMD.Parameters.AddWithValue("@CODMEDIDA", Me.cmbProductoMedida.Text)
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
                'cn.Close()

            Else 'de lo contrario se insertan en la tabla de precios

                If Form1.SwitchConfigInternet.IsOn = True Then

                    Dim cmdEmpresas As New SqlCommand("SELECT EMPNIT FROM EMPRESAS", cn)
                    Dim drEmpresas As SqlDataReader = cmdEmpresas.ExecuteReader
                    Do While drEmpresas.Read
                        sql = "INSERT INTO PRECIOS (EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO,MARGEN,MAYOREOA,MAYOREOB,MAYOREOC,PESO,BONO) VALUES (@EMPNIT,@CODPROD,@CODMEDIDA,@EQUIVALE,@COSTO,@PRECIO,@UTILIDAD,@PORCUTILIDAD,@HABILITADO,@MARGEN,@MAYOREOA,@MAYOREOB,@MAYOREOC,@PESO,@BONO)"
                        Dim CMD As New SqlCommand(sql, cn)
                        CMD.Parameters.AddWithValue("@EMPNIT", drEmpresas(0).ToString)
                        CMD.Parameters.AddWithValue("@CODPROD", codprod)
                        CMD.Parameters.AddWithValue("@CODMEDIDA", Me.cmbProductoMedida.Text)
                        CMD.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(Me.txtProductoEquivale.Text))
                        CMD.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtCostoMedida.Text))
                        CMD.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtPrecioP.Text))
                        CMD.Parameters.AddWithValue("@UTILIDAD", 0)
                        CMD.Parameters.AddWithValue("@PORCUTILIDAD", 0)
                        CMD.Parameters.AddWithValue("@HABILITADO", "SI")
                        CMD.Parameters.AddWithValue("@MARGEN", 0)
                        CMD.Parameters.AddWithValue("@MAYOREOA", Double.Parse(Me.txtPrecioA.Text))
                        CMD.Parameters.AddWithValue("@MAYOREOB", Double.Parse(Me.txtPrecioB.Text))
                        CMD.Parameters.AddWithValue("@MAYOREOC", Double.Parse(Me.txtPrecioC.Text))
                        CMD.Parameters.AddWithValue("@PESO", Double.Parse(Me.txtProductoPeso.Text))
                        CMD.Parameters.AddWithValue("@BONO", Double.Parse(Me.txtProductosBONO.Text))
                        CMD.ExecuteNonQuery()
                        CMD.Dispose()
                    Loop
                    drEmpresas.Close()
                    cmdEmpresas.Dispose()

                Else
                    sql = "INSERT INTO PRECIOS (EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO,MAYOREOA,MAYOREOB,MAYOREOC,PESO,BONO) VALUES (@EMPNIT,@CODPROD,@CODMEDIDA,@EQUIVALE,@COSTO,@PRECIO,@UTILIDAD,@PORCUTILIDAD,@HABILITADO,@MAYOREOA,@MAYOREOB,@MAYOREOC,@PESO,@BONO)"
                    Dim CMD As New SqlCommand(sql, cn)
                    CMD.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    CMD.Parameters.AddWithValue("@CODPROD", codprod)
                    CMD.Parameters.AddWithValue("@CODMEDIDA", Me.cmbProductoMedida.Text)
                    CMD.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(Me.txtProductoEquivale.Text))
                    CMD.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtCostoMedida.Text))
                    CMD.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtPrecioP.Text))
                    CMD.Parameters.AddWithValue("@UTILIDAD", 0)
                    CMD.Parameters.AddWithValue("@PORCUTILIDAD", 0)
                    CMD.Parameters.AddWithValue("@HABILITADO", "SI")
                    CMD.Parameters.AddWithValue("@MARGEN", 0)
                    CMD.Parameters.AddWithValue("@MAYOREOA", Double.Parse(Me.txtPrecioA.Text))
                    CMD.Parameters.AddWithValue("@MAYOREOB", Double.Parse(Me.txtPrecioB.Text))
                    CMD.Parameters.AddWithValue("@MAYOREOC", Double.Parse(Me.txtPrecioC.Text))
                    CMD.Parameters.AddWithValue("@PESO", Double.Parse(Me.txtProductoPeso.Text))
                    CMD.Parameters.AddWithValue("@BONO", Double.Parse(Me.txtProductosBONO.Text))
                    CMD.ExecuteNonQuery()
                    CMD.Dispose()
                End If
                cn.Close()
            End If

        End Using
        Me.btnAceptarTrue.PerformClick()
    End Sub

    Private Sub txtMargenConfig_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMargenConfig.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtMargenConfig.Text <> "" Then

                Dim mc As Double = Double.Parse(Me.txtMargenConfig.Text) / 100
                Dim co As Double = Double.Parse(Me.txtCostoMedida.Text)
                Dim p As String = FormatNumber((mc * co) + co, 2)

                Me.txtPrecioP.Text = p
                Me.txtPrecioA.Text = p
                Me.txtPrecioB.Text = p
                Me.txtPrecioC.Text = p

                Call CalcularUtilidadProducto()
                Me.txtPrecioP.select()

            End If
        End If
    End Sub

End Class
