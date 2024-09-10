Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewRPTVO

#Region "LOAD"

    Private Sub viewRPTVO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSUCURSALES
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

        With Me.cmbMEs
            .DataSource = getTblMeses()
            .ValueMember = "CODMES"
            .DisplayMember = "DESMES"
        End With

        Me.cmbMEs.SelectedValue = Integer.Parse(Today.Month)
        Me.cmbAnio.Text = Today.Year.ToString
        Call cargarGrid()


    End Sub

#End Region

#Region "VENTAS POR PRODUCTO"

    Private Function TBLVentasPProducto() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS [TOTAL VENDIDOS], SUM(DOCPRODUCTOS.TOTALCOSTO) 
                                            AS [TOTAL COSTO], SUM(DOCPRODUCTOS.TOTALPRECIO) AS [TOTAL PRECIO]
                                           FROM            DOCPRODUCTOS LEFT OUTER JOIN
                                            DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                                            EMPRESAS ON DOCPRODUCTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                            TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                           WHERE        (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, EMPRESAS.EMPNIT, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO
                                           HAVING        (DOCPRODUCTOS.MES BETWEEN @MI AND @MF) AND (DOCPRODUCTOS.ANIO = @A)
                                           ORDER BY DOCPRODUCTOS.DESPROD", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using


        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Public Sub TileItemVentasPProducto_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemVentasPProducto.ItemClick

        'If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
        If FlyoutDialog.Show(Me.ParentForm, New viewFechaMES) = DialogResult.OK Then

            Me.gridExports1.DataSource = Nothing
            Me.gridExports1.DataSource = TBLVentasPProducto()
            Try
                Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\ReporteVentaPP - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\ReporteVentaPP - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:   " & ex.ToString)
            End Try
            Me.gridExports1.DataSource = Nothing

        End If
        'End If
    End Sub

#End Region

#Region "INVENTARIO GENERAL"

    Private Function TBLGENERAL(ByVal ANIO As Integer, ByVal MES As Integer) As DataTable
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim tbl As New DataTable

        With tbl
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("CODPROD2", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("UXC", GetType(Integer))
            .Columns.Add("SALDOINICIAL", GetType(Double))
            .Columns.Add("TOTALENTRADAS", GetType(Double))
            .Columns.Add("TOTALSALIDAS", GetType(Double))
            .Columns.Add("SALDO", GetType(Double))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("DESMARCA", GetType(String))
        End With

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, INVSALDO.SALDOINICIAL, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, 
                         PRODUCTOS.COSTO, 0 AS PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, 'SN' AS CODMEDIDA, PRODUCTOS.CODPROD2, INVSALDO.EMPNIT, EMPRESAS.EMPNOMBRE
                        FROM EMPRESAS RIGHT OUTER JOIN
                         INVSALDO ON EMPRESAS.EMPNIT = INVSALDO.EMPNIT LEFT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                        WHERE (NOT (INVSALDO.EMPNIT LIKE 'BACK%%'))
                        ORDER BY PRODUCTOS.DESPROD", cn)

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    Try
                        tbl.Rows.Add(New Object() {
                        dr(0).ToString,'codprod
                        dr(14).ToString,'codprod2
                        dr(1).ToString,'desprod
                        Integer.Parse(dr(4).ToString),'uxc
                        Double.Parse(dr(5).ToString),'saldo inicial
                        Double.Parse(dr(6).ToString),'total entradas
                        Double.Parse(dr(7).ToString),'total salidas
                        Double.Parse(dr(8).ToString),'saldo
                        Double.Parse(dr(9).ToString),'costo
                                       (Double.Parse(dr(9).ToString) * Double.Parse(dr(8).ToString)),'totalcosto
                        Double.Parse(dr(10).ToString),'precio
                               (Double.Parse(dr(10).ToString) * Double.Parse(dr(8).ToString)),'totalprecio
                dr(12).ToString() 'desmarca
                                            })
                    Catch ex As Exception
                        'sgBox("El producto " & dr(0).ToString & " " & dr(1).ToString & " tiene problemas de formato por lo que no se cargará en la lista")
                    End Try
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()
                'Dim da As New SqlDataAdapter
                'da.SelectCommand = cmd
                'da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Private Sub TileItemEXPGEN_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemEXPGEN.ItemClick

        'If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

        Me.gridExports2.DataSource = Nothing
        Me.gridExports2.DataSource = TBLGENERAL(0, 0)
        Try
            Me.gridExports2.ExportToXlsx(Application.StartupPath + "\EXPORTS\InventarioGeneral" + Me.cmbSUCURSALES.Text + ".xlsx")
            Process.Start(Application.StartupPath + "\EXPORTS\InventarioGeneral" + Me.cmbSUCURSALES.Text + ".xlsx")

        Catch ex As Exception
            MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error: " & ex.ToString)
        End Try
        Me.gridExports2.DataSource = Nothing
        'End If

    End Sub

#End Region

#Region "MOVIMIENTOS BODEGA"

    Private Function TBLReportBOD(ByVal ANIO As Integer, ByVal MES As Integer) As DataTable
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection("Data Source=10.243.0.20\SQLEXPRESS;Initial Catalog=FSYA;User ID=iEx;Password=iEx;MultipleActiveResultSets=True")
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS SALIDAS, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, 
                                           SUM(DOCPRODUCTOS.TOTALPRECIO) AS PRECIO, SUM(INVSALDO.SALDO) AS EXISTENCIA
                                           FROM            DOCPRODUCTOS LEFT OUTER JOIN
                                           INVSALDO ON DOCPRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND DOCPRODUCTOS.CODPROD = INVSALDO.CODPROD
                                           WHERE        (DOCPRODUCTOS.CODDOC LIKE '%ENVIO%')
                                           GROUP BY DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD
                                           HAVING        (DOCPRODUCTOS.ANIO = @A) AND (DOCPRODUCTOS.MES BETWEEN @MI AND @MF)
                                           ORDER BY DOCPRODUCTOS.DESPROD", cn)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using


        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Private Sub TileItemMOVBODEGA_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemMOVBODEGA.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaMES) = DialogResult.OK Then

            Me.gridExports3.DataSource = Nothing
            Me.gridExports3.DataSource = TBLReportBOD(0, 0)
            Try
                Me.gridExports3.ExportToXlsx(Application.StartupPath + "\EXPORTS\ReporteMOVBODEGA.xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\ReporteMOVBODEGA.xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports1.DataSource = Nothing

        End If

    End Sub

#End Region

#Region "VENTAS POR MARCA"

    Private Function TBLVentasPMarca() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, MARCAS.CODMARCA, MARCAS.DESMARCA, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS [TOTAL VENDIDOS], SUM(DOCPRODUCTOS.TOTALCOSTO) AS [TOTAL COSTO], 
                                            SUM(DOCPRODUCTOS.TOTALPRECIO) AS [TOTAL PRECIO]
                                           FROM            DOCUMENTOS RIGHT OUTER JOIN
                                            DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                            MARCAS RIGHT OUTER JOIN
                                            PRODUCTOS ON MARCAS.CODMARCA = PRODUCTOS.CODMARCA AND MARCAS.EMPNIT = PRODUCTOS.EMPNIT ON DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT AND 
                                            DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD RIGHT OUTER JOIN
                                            EMPRESAS ON DOCPRODUCTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                            TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                           WHERE        (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY EMPRESAS.EMPNIT, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO, MARCAS.DESMARCA, MARCAS.CODMARCA
                                           HAVING        (DOCPRODUCTOS.MES BETWEEN @MI AND @MF) AND (DOCPRODUCTOS.ANIO = @A)
                                           ORDER BY MARCAS.DESMARCA", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using


        SplashScreenManager.CloseForm()

        Return tbl

    End Function


    Private Sub TileItemVentasPMarca_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemVentasPMarca.ItemClick

        'If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then
        If FlyoutDialog.Show(Me.ParentForm, New viewFechaMES) = DialogResult.OK Then

            Me.gridExports4.DataSource = Nothing
            Me.gridExports4.DataSource = TBLVentasPMarca()
            Try
                Me.gridExports4.ExportToXlsx(Application.StartupPath + "\EXPORTS\ReporteVentaMARCAS - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\ReporteVentaMARCAS - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:   " & ex.ToString)
            End Try
            Me.gridExports4.DataSource = Nothing

        End If
    End Sub

#End Region

#Region "VENTAS POR MARCA INDIVIDUAL"

    Private Function TBLVentasPMarcaIND() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS [TOTAL VENDIDOS], SUM(DOCPRODUCTOS.TOTALCOSTO) 
                                            AS [TOTAL COSTO], SUM(DOCPRODUCTOS.TOTALPRECIO) AS [TOTAL PRECIO]
                                           FROM            DOCUMENTOS RIGHT OUTER JOIN
                                            DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                            MARCAS RIGHT OUTER JOIN
                                            PRODUCTOS ON MARCAS.CODMARCA = PRODUCTOS.CODMARCA AND MARCAS.EMPNIT = PRODUCTOS.EMPNIT ON DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT AND 
                                            DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD RIGHT OUTER JOIN
                                            EMPRESAS ON DOCPRODUCTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                            TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                           WHERE        (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (MARCAS.CODMARCA = @MA) AND (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY EMPRESAS.EMPNIT, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD
                                           HAVING        (DOCPRODUCTOS.MES BETWEEN @MI AND @MF) AND (DOCPRODUCTOS.ANIO = @A)
                                           ORDER BY DOCPRODUCTOS.ANIO", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)
                cmd.Parameters.AddWithValue("@MA", GlobalParamMarca)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using


        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Private Sub TileItemREPMARCAIND_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPMARCAIND.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaMarca) = DialogResult.OK Then

            Me.gridExports5.DataSource = Nothing
            Me.gridExports5.DataSource = TBLVentasPMarcaIND()
            Try
                Me.gridExports5.ExportToXlsx(Application.StartupPath + "\EXPORTS\ReporteVenta - " + GlobalParamMarca.ToString + " - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\ReporteVenta - " + GlobalParamMarca.ToString + " - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:   " & ex.ToString)
            End Try
            Me.gridExports5.DataSource = Nothing

        End If

    End Sub


#End Region

#Region "VENTAS POR VENDEDOR"

    Private Function TBLVentasPVendedores() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS [TOTAL COSTO], SUM(DOCPRODUCTOS.TOTALPRECIO) AS [TOTAL PRECIO], DOCUMENTOS_1.CODVEN, 
                                            EMPLEADOS.NOMEMPLEADO
                                           FROM            DOCUMENTOS RIGHT OUTER JOIN
                                            DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                            DOCUMENTOS AS DOCUMENTOS_1 LEFT OUTER JOIN
                                            EMPLEADOS ON DOCUMENTOS_1.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS_1.CODVEN = EMPLEADOS.CODEMPLEADO ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS_1.EMPNIT AND 
                                            DOCPRODUCTOS.CODDOC = DOCUMENTOS_1.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS_1.CORRELATIVO LEFT OUTER JOIN
                                            TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                           WHERE        (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, DOCUMENTOS_1.CODVEN, EMPLEADOS.NOMEMPLEADO
                                           HAVING        (DOCPRODUCTOS.ANIO = @A) AND (DOCPRODUCTOS.MES BETWEEN @MI AND @MF)", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        SplashScreenManager.CloseForm()

        Return tbl

    End Function


    Private Sub TileItemREPVEND_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPVEN.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaMES) = DialogResult.OK Then

            Me.gridExports6.DataSource = Nothing
            Me.gridExports6.DataSource = TBLVentasPVendedores()
            Try
                Me.gridExports6.ExportToXlsx(Application.StartupPath + "\EXPORTS\RepVentaVendedor - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\RepVentaVendedor - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:   " & ex.ToString)
            End Try
            Me.gridExports6.DataSource = Nothing

        End If

    End Sub

#End Region

#Region "VENTAS POR VENDEDOR INDIVIDUAL"

    Private Function TBLVentasPVendIND() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, DOCUMENTOS_1.CODVEN AS [COD EMP], EMPLEADOS.NOMEMPLEADO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) 
                                            AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS [TOTAL COSTO], SUM(DOCPRODUCTOS.TOTALPRECIO) AS [TOTAL PRECIO]
                                           FROM            DOCUMENTOS RIGHT OUTER JOIN
                                            DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                            DOCUMENTOS AS DOCUMENTOS_1 LEFT OUTER JOIN
                                            EMPLEADOS ON DOCUMENTOS_1.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS_1.CODVEN = EMPLEADOS.CODEMPLEADO ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS_1.EMPNIT AND 
                                            DOCPRODUCTOS.CODDOC = DOCUMENTOS_1.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS_1.CORRELATIVO LEFT OUTER JOIN
                                            TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                           WHERE        (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, DOCUMENTOS_1.CODVEN, EMPLEADOS.NOMEMPLEADO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD
                                           HAVING        (DOCPRODUCTOS.ANIO = @A) AND (DOCPRODUCTOS.MES BETWEEN @MI AND @MF) AND (DOCUMENTOS_1.CODVEN = @EM)
                                           ORDER BY DOCPRODUCTOS.CODPROD", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)
                cmd.Parameters.AddWithValue("@EM", GlobalNomEmpleado)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using


        SplashScreenManager.CloseForm()

        Return tbl

    End Function


    Private Sub TileItemREPVENDI_ItemClick_1(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPVENDI.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaEmp) = DialogResult.OK Then

            Me.gridExports7.DataSource = Nothing
            Me.gridExports7.DataSource = TBLVentasPVendIND()
            Try
                Me.gridExports7.ExportToXlsx(Application.StartupPath + "\EXPORTS\RepVentaVendIND - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\RepVentaVendIND - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:   " & ex.ToString)
            End Try
            Me.gridExports7.DataSource = Nothing

        End If

    End Sub

#End Region

#Region "GRID VENTAS PRODUCTOS META"

    Private Sub cargarGrid()

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing
        Me.GridControlPRODUCTOS.DataSource = tblTopProductos()
        Me.GridControlPRODUCTOS.RefreshDataSource()

        SplashScreenManager.CloseForm()

    End Sub

    Private Function tblTopProductos() As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, EMPLEADOS.NOMEMPLEADO, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, 
                                           SUM(DOCPRODUCTOS.TOTALPRECIO) AS VENTA, SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD
                                           FROM            DOCUMENTOS LEFT OUTER JOIN
                                           EMPLEADOS ON DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO LEFT OUTER JOIN
                                           DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                                           TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                           WHERE        (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.ANIO = @A) AND (DOCUMENTOS.MES = @M) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND 
										   (DOCPRODUCTOS.CODPROD IN ('769229004540', '7406076100430', '1501', '7401151800106', '1861', '7406137000792', '7401108842531', '2040', '2054', '7460347603129', '7460347608988'))
                                           GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, EMPLEADOS.NOMEMPLEADO
                                           ORDER BY DOCPRODUCTOS.DESPROD", cn)
                cmd.Parameters.AddWithValue("@A", Integer.Parse(Me.cmbAnio.Text))
                cmd.Parameters.AddWithValue("@M", Integer.Parse(Me.cmbMEs.SelectedValue))
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

    Private Sub cmbMes_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMEs.KeyDown
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
            Dim archivo As String = Application.StartupPath + "/EXPORTS/VentasProductosMeta" + Me.cmbMEs.Text + Me.cmbAnio.Text + "-" + Me.cmbSUCURSALES.Text + ".xlsx"
            Me.GridControlPRODUCTOS.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

#Region "REPORTERIA ONLINE"

    Private Sub TileItemVENTASFACTURA_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemVENTASFACTURA.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Call NAVEGAR("VENTAS_ONLINE2")

        End If

    End Sub

    Private Sub TileItemVENTASDOMICILIO_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemVENTASDOMICILIO.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Call NAVEGAR("VENTAS_DOMICILIO2")

        End If

    End Sub

    Private Sub TileItemCORONL_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemCORONL.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Call NAVEGAR("CORTES_ONLINE2")

        End If

    End Sub

#End Region

#Region "REPORTE COMPRAS PROVEEDOR EXTRAORDINARIO"

    Private Function TBLReportCG() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection("Data Source=10.243.0.20\SQLEXPRESS;Initial Catalog=FSYA;User ID=iEx;Password=iEx;MultipleActiveResultSets=True")
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try

                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.ANIO, DOCUMENTOS.MES, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) As UNIDADES, PROVEEDORES.CODPROV,
                                           PROVEEDORES.RAZONSOCIAL AS [NOM PROV]
                                           From DOCUMENTOS LEFT OUTER Join
                                           DOCPRODUCTOS On DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC And DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER Join
                                           PROVEEDORES On DOCUMENTOS.EMPNIT = PROVEEDORES.EMPNIT And DOCUMENTOS.DOC_NOMCLIE = PROVEEDORES.EMPRESA
                                           Where (DOCUMENTOS.CODDOC Like '%COM%')
                                           GROUP BY DOCUMENTOS.ANIO, DOCUMENTOS.MES, PROVEEDORES.CODPROV, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PROVEEDORES.RAZONSOCIAL
                                           HAVING(DOCUMENTOS.ANIO = @A) And (DOCUMENTOS.MES BETWEEN @MI AND @MF) And (PROVEEDORES.CODPROV In (1159, 4208, 1187, 4209, 4211))
                                           ORDER BY UNIDADES DESC", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamMesInicial)
                cmd.Parameters.AddWithValue("@MF", GlobalParamMesFinal)
                cmd.Parameters.AddWithValue("@A", GlobalParamAnioCurso)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using


        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Private Sub TileItemREPG_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPG.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaMES) = DialogResult.OK Then

            Me.gridExports8.DataSource = Nothing
            Me.gridExports8.DataSource = TBLReportCG()

            Try
                Me.gridExports8.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTG.xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTG.xlsx")

            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports8.DataSource = Nothing

        End If

    End Sub

    Private Sub cargarGridVPN()

        Dim objvpn As New classServers

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Me.GridControl1.DataSource = Nothing
            Me.GridControl1.DataSource = objvpn.getTblGENERALES()
            Me.GridControl1.RefreshDataSource()

            SplashScreenManager.CloseForm()


    End Sub

    Private Sub TileItem1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem1.ItemClick

        Call cargarGridVPN()

        Try
            Dim archivo As String = Application.StartupPath + "/EXPORTS/Ventas.xlsx"
            Me.GridControl1.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cargarGridVPNVENTAS()

        Dim objvpn As New classServers

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControl1.DataSource = Nothing
        Me.GridControl1.DataSource = objvpn.getTblVENTASVPN()
        Me.GridControl1.RefreshDataSource()

        SplashScreenManager.CloseForm()


    End Sub

    Private Sub TileItem5_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItem5.ItemClick

        Call cargarGridVPN()

        Try
            Dim archivo As String = Application.StartupPath + "/EXPORTS/VentasVPN.xlsx"
            Me.GridControl2.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#End Region

End Class
