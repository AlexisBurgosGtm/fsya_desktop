Imports System.Data.SqlClient

Public Class viewProductosOnlineAdicionales
    Sub New(ByVal _codprod As String, ByVal _desprod As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        codprod = _codprod
        desprod = _desprod

        Try
            Call CrearTabla()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub CrearTabla()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("CREATE TABLE [dbo].[PRODUCTOS_ADS](
	[EMPNIT] [varchar](50) NULL,
	[EMPNOMBRE] [varchar](255) NULL,
	[CODPROD] [varchar](50) NULL,
	[DESPROD] [varchar](250) NULL,
	[INVMINIMO] [int] NULL,
	[INVMAXIMO] [int] NULL,
	[HABILITADO] [varchar](2) NULL
) ON [PRIMARY]", cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            End Try
        End Using
    End Sub

    Dim desprod, codprod As String

    Private Sub viewProductosOnlineAdicionales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbCodprod.Text = codprod
        Me.lbDesprod.Text = desprod

        Call CargarComboSucursales()
        Call CargarGrid()

        Me.cmbHabilitado.Text = "SI"

        Me.cmbSucursal.select()



    End Sub

    Private Sub CargarComboSucursales()
        With Me.cmbSucursal
            .DataSource = getTblEmpresasHost()
            .ValueMember = "EMPNIT"
            .DisplayMember = "NOMBRE"
        End With
    End Sub

    Private Sub cmbSucursal_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSucursal.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtMaximo.select()
        End If
    End Sub

    Private Sub txtMaximo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMaximo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtMinimo.select()
        End If
    End Sub

    Private Sub txtMinimo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMinimo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbHabilitado.select()
        End If
    End Sub

    Private Sub cmbHabilitado_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbHabilitado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAgregar.select()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

        If Me.cmbSucursal.SelectedIndex >= 0 Then
        Else
            MsgBox("Seleccione una sucursal de la lista")
            Exit Sub
        End If

        If Me.txtMinimo.Text <> "" Then
        Else
            MsgBox("Indique el inventario mínimo de la sucursal")
            Exit Sub
        End If

        If Me.txtMaximo.Text <> "" Then
        Else
            MsgBox("Indique el inventario máximo del producto")
        End If

        If Me.cmbHabilitado.Text <> "" Then
        Else
            Me.cmbHabilitado.Text = "SI"
        End If


        If getConfirmacion("¿Está seguro que desea agregar estos datos?") = True Then
        Else
            Exit Sub
        End If

        If verifyCodprod(Me.cmbSucursal.SelectedValue.ToString, codprod) = True Then
            MsgBox("Este código y esta Sucursal ya fué agregado previamente, utilice otro")
            Exit Sub
        End If

        If insert_Producto(Me.cmbSucursal.SelectedValue.ToString, Me.cmbSucursal.Text, codprod, desprod, Integer.Parse(Me.txtMinimo.Text), Integer.Parse(Me.txtMaximo.Text), Me.cmbHabilitado.Text) = True Then
            MsgBox("Producto agregado exitosamente!!")
            Call CargarGrid()
            Me.cmbSucursal.select()

        Else
            MsgBox("No se pudo Agregar este producto")
        End If


    End Sub


    Private Function insert_Producto(ByVal empnit As String, ByVal empnombre As String, ByVal codprod As String,
                                      ByVal desprod As String, ByVal invminimo As Integer, ByVal invmaximo As Integer, ByVal habilitado As String) As Boolean
        Dim r As Boolean


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("INSERT INTO PRODUCTOS_ADS (EMPNIT,EMPNOMBRE,CODPROD,DESPROD,INVMINIMO,INVMAXIMO,HABILITADO) VALUES (@E,@EN,@C,@D,@MIN,@MAX,@HAB)", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@EN", empnombre)
                cmd.Parameters.AddWithValue("@C", codprod)
                cmd.Parameters.AddWithValue("@D", desprod)
                cmd.Parameters.AddWithValue("@MIN", invminimo)
                cmd.Parameters.AddWithValue("@MAX", invmaximo)
                cmd.Parameters.AddWithValue("@HAB", habilitado)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                r = False
            End Try
        End Using


        Return r

    End Function



    Private Function delete_Producto(ByVal empnit As String, ByVal codprod As String) As Boolean
        Dim r As Boolean


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("DELETE FROM PRODUCTOS_ADS WHERE EMPNIT=@E AND CODPROD=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codprod)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                r = False
            End Try
        End Using


        Return r

    End Function





    Private Sub CargarGrid()
        Dim tbl As New DSPRODUCTOS.tblProductosAdicionalDataTable
        Me.gridDetalles.DataSource = Nothing

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("SELECT EMPNIT,EMPNOMBRE,CODPROD,DESPROD,INVMINIMO,INVMAXIMO,HABILITADO FROM PRODUCTOS_ADS", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        Me.gridDetalles.DataSource = tbl


    End Sub



    Dim drw As DataRow
    Private Sub GridViewDetalles_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalles.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewDetalles.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewDetalles_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewDetalles.KeyDown
        If e.KeyCode = Keys.Enter Then
            If getConfirmacion("¿Está seguro que desea ELIMINAR el detalle seleccionado?") = True Then
                If delete_Producto(drw.Item(0).ToString, drw.Item(2).ToString) = True Then
                    MsgBox("Detalle eliminado exitosamente!!")
                    Call CargarGrid()
                Else
                    MsgBox("No se pudo eliminar esta fila")
                End If
            End If
        End If
    End Sub

    Private Sub GridViewDetalles_DoubleClick(sender As Object, e As EventArgs) Handles GridViewDetalles.DoubleClick
        If getConfirmacion("¿Está seguro que desea ELIMINAR el detalle seleccionado?") = True Then
            If delete_Producto(drw.Item(0).ToString, drw.Item(2).ToString) = True Then
                MsgBox("Detalle eliminado exitosamente!!")
                Call CargarGrid()
            Else
                MsgBox("No se pudo eliminar esta fila")
            End If
        End If
    End Sub



    Private Function verifyCodprod(ByVal empnit As String, ByVal codprod As String) As Boolean
        Dim r As Boolean


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("SELECT EMPNIT,CODPROD FROM PRODUCTOS_ADS WHERE EMPNIT=@E AND CODPROD=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                r = False
            End Try
        End Using


        Return r

    End Function


End Class
