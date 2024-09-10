Imports System.Data.SqlClient

Public Class viewDevolucionesCantidad

    Sub New(ByVal _codprod As String, ByVal _desprod As String, ByVal _cantidad As Double, ByVal _unidadesvendidas As Double, ByVal _id As Integer, ByVal _costoun As Double, ByVal _precioun As Double, ByVal _unidadesfacturadas As Double)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        codprod = _codprod
        desprod = _desprod
        unidadesvendidas = _unidadesvendidas
        cantidad = _cantidad
        equivale = Integer.Parse(_unidadesvendidas / _cantidad)
        id = _id
        costoun = _costoun
        precioun = _precioun
        unidadesfacturadas = _unidadesfacturadas

    End Sub

    Dim precioUnitario As Double
    Dim costoUnitario As Double


    Dim codprod, desprod, codmedida As String
    Dim cantidad, unidadesvendidas, costoun, precioun, unidadesfacturadas As Double
    Dim equivale, id As Integer

    Private Sub viewDevolucionesCantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'VERIFICA SI EL SWITCH ESTÁ ACTIVADO PARA PERMITIR
        'DECIMALES EN CANTIDADES
        If Form1.SwitchConfigModoPOS.IsOn = False Then
            Me.txtCantidad.Properties.Mask.EditMask = "n0"
        End If

        Me.lbCodprod.Text = codprod
        Me.lbDesprod.Text = desprod

        'unidades facturadas es para el total facturado originalmente
        Me.lbTotalUnidades.Text = unidadesfacturadas.ToString 'unidadesvendidas.ToString
        Me.txtCantidad.Text = cantidad.ToString
        Me.cmbMedidas.SelectedValue = equivale

        Call CargarMedidas()

        precioUnitario = precioun / equivale
        costoUnitario = costoun / equivale

        Me.txtCantidad.select()

    End Sub

    Private Sub cmbMedidas_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMedidas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCantidad.select()
        End If
    End Sub

    Private Sub cmbMedidas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedidas.SelectedIndexChanged
        Call CalcularTotalUnidades()
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CalcularTotalUnidades()
            Me.btnAgregar.select()
        End If
    End Sub

    Private Sub CalcularTotalUnidades()
        Try
            Me.txtTotalUnidades.Text = (CType(Me.cmbMedidas.SelectedValue, Integer) * Double.Parse(Me.txtCantidad.Text)).ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarMedidas()
        Dim tbl As New DataTable
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EQUIVALE, CODMEDIDA FROM PRECIOS WHERE EMPNIT=@E AND CODPROD=@C", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codprod)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        With Me.cmbMedidas
            .DataSource = tbl
            .ValueMember = "EQUIVALE"
            .DisplayMember = "CODMEDIDA"
        End With

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If Double.Parse(Me.txtTotalUnidades.Text) > Double.Parse(Me.lbTotalUnidades.Text) Then
            MsgBox("No se puede devolver una cantidad mayor a la vendida, por favor rectifique")
            Exit Sub
        End If

        If Me.cmbMedidas.SelectedIndex >= 0 Then
            If Me.txtCantidad.Text <> "" Then

                Using cn As New SqlConnection(strSqlConectionString)
                    Try
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If
                        Dim unidadesdevolver As Double = CType(Me.txtTotalUnidades.Text, Double)

                        Dim cmd As New SqlCommand("UPDATE TEMP_VENTAS SET 
                        CODMEDIDA=@CODMEDIDA, CANTIDAD=@CANTIDAD, EQUIVALE=@EQUIVALE, TOTALUNIDADES=@TOTALUNIDADES,COSTO=@COSTO, TOTALCOSTO=@TOTALCOSTO, PRECIO= @PRECIO, TOTALPRECIO=@TOTALPRECIO 
                        WHERE ID=@ID", cn)

                        cmd.Parameters.AddWithValue("@ID", id)
                        cmd.Parameters.AddWithValue("@CODMEDIDA", Me.cmbMedidas.Text)
                        cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtCantidad.Text))
                        cmd.Parameters.AddWithValue("@TOTALUNIDADES", unidadesdevolver)
                        cmd.Parameters.AddWithValue("@EQUIVALE", CType(Me.cmbMedidas.SelectedValue, Integer))
                        cmd.Parameters.AddWithValue("@COSTO", costoUnitario)
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", costoUnitario * (Double.Parse(Me.txtCantidad.Text) * CType(Me.cmbMedidas.SelectedValue, Integer)))
                        cmd.Parameters.AddWithValue("@PRECIO", precioUnitario)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", precioUnitario * (Double.Parse(Me.txtCantidad.Text) * CType(Me.cmbMedidas.SelectedValue, Integer)))
                        cmd.ExecuteNonQuery()

                        Call Form1.Mensaje("Producto agregado con éxito")

                        Me.btnAgregarTrue.PerformClick()

                    Catch ex As Exception

                        MsgBox("Error al tratar de agregar el producto. Error: " + ex.ToString)
                    End Try
                End Using

            Else
                MsgBox("Indique una cantida válida")
            End If
        Else
            MsgBox("Seleccione una medida de precio válida")
        End If


    End Sub



End Class
