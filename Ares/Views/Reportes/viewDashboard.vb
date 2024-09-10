
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen

Public Class viewDashboard

    Private Sub viewDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbMes
            .DataSource = getTblMeses()
            .ValueMember = "CODMES"
            .DisplayMember = "DESMES"
        End With

        Me.cmbMes.SelectedValue = Integer.Parse(Today.Month)
        Me.cmbAnio.Text = Today.Year.ToString

        Call cargarGrid()
        Me.cmbMes.select()

    End Sub

    Private Sub cargarGrid()


        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        'CARGA EL CHART DE VENTAS POR DIA
        Me.ChartControlVentas.DataSource = Nothing
        Me.ChartControlVentas.DataSource = tblVentasDia()
        Me.ChartControlVentas.RefreshData()

        'CARGA EL GRID DE VENTAS POR PRODUCTOS
        Me.GridControlProductos.DataSource = Nothing
        Me.GridControlProductos.DataSource = tblTopProductos()
        Me.GridControlProductos.RefreshDataSource()

        'CARGA EL GRID DE VENTAS POR VENDEDOR
        Me.GridControlVendedores.DataSource = Nothing
        Me.GridControlVendedores.DataSource = tblVentasVendedores()
        Me.GridControlVendedores.RefreshDataSource()


        Me.lbTotalInventario.Text = FormatNumber(getTotalInventario(), 2).ToString

        Call setTotalesVentas()

        SplashScreenManager.CloseForm()

    End Sub

    'tabla ventas día
    Private Function tblVentasDia() As DataTable

        Dim tbl As New DSDASHBOARD.tblVentasDiaDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT DOCUMENTOS.FECHA, SUM(DOCUMENTOS.TOTALCOSTO) AS COSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS PRECIO, (SUM(DOCUMENTOS.TOTALPRECIO) - SUM(DOCUMENTOS.TOTALCOSTO)) AS UTILIDAD
                            FROM DOCUMENTOS LEFT OUTER JOIN
                            TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                            WHERE (DOCUMENTOS.STATUS <> 'A')
                            GROUP BY DOCUMENTOS.FECHA, DOCUMENTOS.EMPNIT, TIPODOCUMENTOS.TIPODOC, DOCUMENTOS.ANIO, DOCUMENTOS.MES
                            HAVING (DOCUMENTOS.EMPNIT = @E) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES')) AND (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@A", Integer.Parse(Me.cmbAnio.Text))
                cmd.Parameters.AddWithValue("@M", Integer.Parse(Me.cmbMes.SelectedValue))
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox("venta: " + GlobalDesError)
            End Try

        End Using


        Return tbl
    End Function

    'tabla top 20 de productos
    Private Function tblTopProductos() As DataTable
        Dim tbl As New DSDASHBOARD.tblTopProductosDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS VENTA, (SUM(DOCPRODUCTOS.TOTALPRECIO)-SUM(DOCPRODUCTOS.TOTALCOSTO)) AS UTILIDAD
                                FROM DOCUMENTOS LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                        WHERE (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES'))
                        GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD
                        ORDER BY DOCPRODUCTOS.DESPROD", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@A", Integer.Parse(Me.cmbAnio.Text))
                cmd.Parameters.AddWithValue("@M", Integer.Parse(Me.cmbMes.SelectedValue))
                cmd.CommandTimeout = 0
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox("productos: " + GlobalDesError)
            End Try

        End Using


        Return tbl
    End Function

    'tabla vendedores
    Private Function tblVentasVendedores() As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPLEADOS.NOMEMPLEADO AS NOMBRE, SUM(DOCUMENTOS.TOTALCOSTO) AS COSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS PRECIO, SUM(DOCUMENTOS.TOTALPRECIO) - SUM(DOCUMENTOS.TOTALCOSTO) AS UTILIDAD
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO AND DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                        GROUP BY EMPLEADOS.NOMEMPLEADO, DOCUMENTOS.ANIO, DOCUMENTOS.MES, DOCUMENTOS.STATUS, TIPODOCUMENTOS.TIPODOC, DOCUMENTOS.EMPNIT
                        HAVING (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES'))", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@A", Integer.Parse(Me.cmbAnio.Text))
                cmd.Parameters.AddWithValue("@M", Integer.Parse(Me.cmbMes.SelectedValue))
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString

            End Try

        End Using

        Return tbl
    End Function

    'total inventario
    Private Function getTotalInventario() As Double

        Dim r As Double = 0

        Dim total As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT        INVSALDO.CODPROD, INVSALDO.SALDO, ISNULL(PRODUCTOS.COSTO, 0) AS COSTO, ISNULL(PRODUCTOS.COSTO, 0) * INVSALDO.SALDO AS TOTALCOSTO
FROM            INVSALDO LEFT OUTER JOIN
                         PRODUCTOS ON INVSALDO.CODPROD = PRODUCTOS.CODPROD AND INVSALDO.EMPNIT = PRODUCTOS.EMPNIT
WHERE        (INVSALDO.EMPNIT = @E) AND (INVSALDO.MES = 0) AND (PRODUCTOS.HABILITADO = 'SI')", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@A", Integer.Parse(Me.cmbAnio.Text))
                'cmd.Parameters.AddWithValue("@M", Integer.Parse(Me.cmbMes.SelectedValue))
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    total = total + Double.Parse(dr(3))
                Loop
                r = total

            Catch ex As Exception
                r = 0
                GlobalDesError = ex.ToString
                MsgBox("Error al cargar el inventario. Error: " + ex.ToString)
            End Try

        End Using

        Return r

    End Function

    'totales de ventas
    Private Function setTotalesVentas() As Boolean

        Dim r As Boolean

        Dim total As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT SUM(DOCUMENTOS.TOTALCOSTO) AS COSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS PRECIO, SUM(DOCUMENTOS.TOTALPRECIO) - SUM(DOCUMENTOS.TOTALCOSTO) AS UTILIDAD
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        GROUP BY DOCUMENTOS.EMPNIT, DOCUMENTOS.ANIO, DOCUMENTOS.MES, DOCUMENTOS.STATUS, TIPODOCUMENTOS.TIPODOC
                        HAVING (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES'))", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@A", Integer.Parse(Me.cmbAnio.Text))
                cmd.Parameters.AddWithValue("@M", Integer.Parse(Me.cmbMes.SelectedValue))
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    Me.lbTotalVenta.Text = FormatNumber(Double.Parse(dr(1)), 2).ToString
                    Me.lbTotalUtilidad.Text = FormatNumber(Double.Parse(dr(2)), 2).ToString
                Else
                    Me.lbTotalVenta.Text = "0.00"
                    Me.lbTotalUtilidad.Text = "0.00"
                End If

                r = True

            Catch ex As Exception
                r = False
                GlobalDesError = ex.ToString
                Me.lbTotalVenta.Text = "0.00"
                Me.lbTotalUtilidad.Text = "0.00"
            End Try

        End Using

        Return r

    End Function


    Private Sub cmbMes_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMes.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbAnio.select()
        End If
    End Sub

    Private Sub cmbAnio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbAnio.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnCargar.select()
        End If
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click

        Call cargarGrid()

    End Sub

    Private Sub btnExportarDataProductos_Click(sender As Object, e As EventArgs) Handles btnExportarDataProductos.Click
        Try
            Dim archivo As String = Application.StartupPath + "/EXPORTS/VentasProductos" + Me.cmbMes.Text + Me.cmbAnio.Text + ".xlsx"
            Me.GridControlProductos.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnExportarDatosVendedores_Click(sender As Object, e As EventArgs) Handles btnExportarDatosVendedores.Click
        Try
            Dim archivo As String = Application.StartupPath + "/EXPORTS/VentasVendedor" + Me.cmbMes.Text + Me.cmbAnio.Text + ".xlsx"
            Me.GridControlVendedores.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Class
