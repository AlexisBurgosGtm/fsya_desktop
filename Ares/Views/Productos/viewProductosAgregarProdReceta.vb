Imports System.Data.SqlClient

Public Class viewProductosAgregarProdReceta
    Sub New(ByVal _codprod As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        codprod = _codprod

    End Sub

    Dim codprod As String

    Private Sub viewProductosAgregarProdReceta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarProductos()

    End Sub

    Private Sub CargarProductos()

        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, COSTO FROM PRODUCTOS WHERE EMPNIT=@E AND TIPOPROD='P' ", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
                cn.Close()
            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try
        End Using

        Me.GridProductosAgregar.DataSource = tbl

    End Sub

    Private Sub CargarMedidas(ByVal codigoprod As String)
        Dim tbl As New DSPRODUCTOS.tblProdsDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODMEDIDA, EQUIVALE FROM PRECIOS WHERE EMPNIT=@E AND CODPROD=@C ", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codigoprod)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
                cn.Close()
            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        With Me.cmbMedidas
            .DataSource = Nothing
            .DataSource = tbl
            .ValueMember = "EQUIVALE"
            .DisplayMember = "CODMEDIDA"
        End With


    End Sub
    Dim drw As DataRow
    Private Sub GridViewProductos_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProductos.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewProductos.GetFocusedDataRow

            Call CargarMedidas(drw.Item(0).ToString)
        Catch ex As Exception
            drw = Nothing
        End Try

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Me.cmbMedidas.SelectedIndex >= 0 Then
            If Me.txtCantidad.Text <> "" Then
                If Me.txtCantidad.Text = "0" Then
                    Me.txtCantidad.Text = "1"
                End If

                If insertProdReceta(codprod, drw.Item(0).ToString, drw.Item(1).ToString, Me.cmbMedidas.Text, CType(Me.cmbMedidas.SelectedValue, Integer), CType(Me.txtCantidad.Text, Double), CType(drw.Item(2), Double)) = True Then
                    Me.btnAceptarTrue.PerformClick()
                Else
                    MsgBox("No se pudo agregar el producto a la receta")
                End If



            Else
                MsgBox("Indique la cantidad de producto a usar")
            End If
        Else
            MsgBox("Seleccione una Medida de Precio")
        End If


    End Sub

    Private Sub cmbMedidas_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMedidas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCantidad.select()
        End If

    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAgregar.select()
        End If
    End Sub

    Private Function insertProdReceta(ByVal maincodprod As String, ByVal codprodr As String, ByVal desprod As String, ByVal codmedida As String, ByVal equivale As Integer, ByVal cantidad As Double, ByVal costo As Double) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO PRODUCTOS_RECETAS 
            (EMPNIT,MAINCODPROD,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,TOTALUNIDADES,COSTO,TOTALCOSTO) 
            VALUES (@E,@MAINCODPROD,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@TOTALUNIDADES,@COSTO,@TOTALCOSTO)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@MAINCODPROD", maincodprod)
                cmd.Parameters.AddWithValue("@CODPROD", codprodr)
                cmd.Parameters.AddWithValue("@DESPROD", desprod)
                cmd.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                cmd.Parameters.AddWithValue("@EQUIVALE", equivale)
                cmd.Parameters.AddWithValue("@CANTIDAD", cantidad)
                cmd.Parameters.AddWithValue("@TOTALUNIDADES", (equivale * cantidad))
                cmd.Parameters.AddWithValue("@COSTO", costo)
                cmd.Parameters.AddWithValue("@TOTALCOSTO", (costo * cantidad))
                cmd.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                r = False
            End Try
        End Using

        Return r
    End Function

    Private Sub GridViewProductos_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProductos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbMedidas.select()
        End If

    End Sub


End Class
