Imports DevExpress.XtraBars.Docking2010.Customization
Imports System.Data.SqlClient
Imports DevExpress
Imports DevExpress.XtraBars.Docking2010

Public Class ViewListaPrecios
    Private Sub ViewListaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarListadoPrecios()

    End Sub

    Private Sub btnListaPreciosExportarExcel_Click(sender As Object, e As EventArgs) Handles btnListaPreciosExportarExcel.Click
        Try
            Dim sfd As New SaveFileDialog

            sfd.ShowDialog()

            Me.GridListaPrecios.ExportToXlsx(sfd.FileName & ".xlsx")

        Catch ex As Exception
            MsgBox("La carpeta seleccionada no es válida")
        End Try
    End Sub

    Private Sub CargarListadoPrecios()

        Try

            Dim tbl As New DataTable()
            tbl.Columns.Add("ID", GetType(Integer))
            tbl.Columns.Add("CODPROD", GetType(String))
            tbl.Columns.Add("DESPROD", GetType(String))
            tbl.Columns.Add("DESPROD2", GetType(String))
            tbl.Columns.Add("DESPROD3", GetType(String))
            tbl.Columns.Add("UXC", GetType(Integer))
            tbl.Columns.Add("CODMEDIDA", GetType(String))
            tbl.Columns.Add("EQUIVALE", GetType(Integer))
            tbl.Columns.Add("COSTO", GetType(Double))
            tbl.Columns.Add("PRECIO", GetType(Double))
            tbl.Columns.Add("CODMARCA", GetType(Integer))
            tbl.Columns.Add("DESMARCA", GetType(String))
            tbl.Columns.Add("CODCLAUNO", GetType(Integer))
            tbl.Columns.Add("DESCLAUNO", GetType(String))
            tbl.Columns.Add("CODCLADOS", GetType(Integer))
            tbl.Columns.Add("DESCLADOS", GetType(String))
            tbl.Columns.Add("EXISTENCIA", GetType(Integer))
            tbl.Columns.Add("PRECIOQ", GetType(String))
            tbl.Columns.Add("MAYOREOA", GetType(Double))
            tbl.Columns.Add("MAYOREOB", GetType(Double))
            tbl.Columns.Add("MAYOREOC", GetType(Double))
            tbl.Columns.Add("EXENTO", GetType(Integer))
            Call AbrirConexionSql()

            Dim sql As String

            sql = "SELECT PRECIOS.ID, PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.CODPROD2 AS DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, 
                         PRECIOS.COSTO, PRECIOS.PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLADOS, CLASIFICACIONDOS.DESCLADOS, 
                         INVSALDO.SALDO,PRECIOS.MAYOREOA,PRECIOS.MAYOREOB,PRECIOS.MAYOREOC,PRODUCTOS.EXENTO
                    FROM            INVSALDO RIGHT OUTER JOIN
                         PRECIOS RIGHT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         CLASIFICACIONDOS RIGHT OUTER JOIN
                         PRODUCTOS ON CLASIFICACIONDOS.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONDOS.CODCLADOS = PRODUCTOS.CODCLADOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND 
                         MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND 
                         INVSALDO.CODPROD = PRODUCTOS.CODPROD
                    WHERE        (INVSALDO.ANIO = 0) AND (INVSALDO.MES = 0) AND (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI')
                    ORDER BY PRODUCTOS.DESPROD"

            Dim cmd As New System.Data.SqlClient.SqlCommand(sql, cn)
            'cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            Dim dr As System.Data.SqlClient.SqlDataReader
            dr = cmd.ExecuteReader

            Dim conteoerrores As Integer = 0

            Do While dr.Read
                Try
                    tbl.Rows.Add(New Object() {
                            Integer.Parse(dr(0).ToString),'ID -
                            dr(1).ToString,'CODPROD -
                            dr(2).ToString,'DESPROD - 
                            dr(3).ToString,'DESPROD2 -
                            dr(4).ToString,'DESPROD3 -
                            Integer.Parse(dr(5).ToString),'UXC -
                            dr(6).ToString,'CODMEDIDA -
                            Integer.Parse(dr(7).ToString),'EQUIVALE - 
                            FormatNumber(Double.Parse(dr(8).ToString), 2),'COSTO -
                            FormatNumber(Double.Parse(dr(9).ToString), 2),'PRECIO -
                            Integer.Parse(dr(10).ToString),'CODMARCA -
                            dr(11).ToString,'DESMARCA -
                            Integer.Parse(dr(12).ToString),'CODCLAUNO -
                            dr(13).ToString,'DESCLAUNO -
                            Integer.Parse(dr(14).ToString),'CODCLADOS -
                            dr(15).ToString,'DESCLADOS -
                            Math.Truncate(Integer.Parse(dr(16).ToString) / Integer.Parse(dr(7).ToString)),'SALDO -
                            FormatCurrency(dr(9)).ToString(),
                            dr(17),
                            dr(18),
                            dr(19),
                            dr(20)
                      })
                Catch ex As Exception
                    'MsgBox("Error en el código de producto: " & dr(0).ToString & " " & dr(2).ToString & " " & ex.ToString)
                    conteoerrores = conteoerrores + 1
                End Try
            Loop

            dr.Close()
            cn.Close()

            Me.GridListaPrecios.DataSource = tbl

            Call Form1.Mensaje("Errores encontrados " & conteoerrores.ToString)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnListaPreciosImprimir_Click(sender As Object, e As EventArgs) Handles btnListaPreciosImprimir.Click
        Me.GridListaPrecios.ShowRibbonPrintPreview()
    End Sub

    Dim drw As DataRow

    Private Sub GridViewListaPrecios_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewListaPrecios.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewListaPrecios.GetFocusedDataRow

            Call CargarDatosProductoNew(Me.GridViewListaPrecios.GetFocusedDataRow)

        Catch ex As Exception
            drw = Nothing
        End Try

    End Sub

    Private Sub GridViewListaPrecios_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewListaPrecios.KeyDown
        If e.KeyCode = Keys.Enter Then

            If FlyoutDialog.Show(Me.ParentForm, New ProductsEditPrices(drw.Item(1).ToString, Double.Parse(Me.txtCostoUnitario.Text), drw.Item(6).ToString)) = DialogResult.OK Then
                Call CargarListadoPrecios()
            End If

        End If

    End Sub

    Private Sub GridViewListaPrecios_DoubleClick(sender As Object, e As EventArgs) Handles GridViewListaPrecios.DoubleClick
        If FlyoutDialog.Show(Me.ParentForm, New ProductsEditPrecios(drw.Item(1).ToString, Double.Parse(Me.txtCostoUnitario.Text), drw.Item(6).ToString)) = DialogResult.OK Then
            Call CargarListadoPrecios()
        End If

    End Sub

    Private Sub getDataMedida(ByVal CODPROD As String)

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           PRECIOS.COSTO
                                           FROM             PRECIOS RIGHT OUTER JOIN
                                                            PRODUCTOS ON PRECIOS.CODPROD = PRODUCTOS.CODPROD AND PRECIOS.EMPNIT = PRODUCTOS.EMPNIT
                                           WHERE            (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.HABILITADO = 'SI') AND (PRECIOS.EQUIVALE = 1) AND (PRODUCTOS.CODPROD = @CODPROD)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODPROD", CODPROD)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    Me.txtCostoUnitario.Text = FormatNumber(Double.Parse(dr(0).ToString), 2)
                Else
                    Me.txtCostoUnitario.Text = "0"
                End If
                dr.Close()
                cmd.Dispose()

                cn.Close()

            Catch ex As Exception

            End Try

        End Using

    End Sub

    Private Sub GridViewListaPrecios_Click(sender As Object, e As EventArgs) Handles GridViewListaPrecios.Click

        Try

            Call CargarDatosProductoNew(Me.GridViewListaPrecios.GetFocusedDataRow)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CargarDatosProductoNew(ByVal SelectedRow As DataRow)

        Try

            GlobalCodProd = SelectedRow.Item(1).ToString
            Call getDataMedida(GlobalCodProd)

        Catch ex As Exception

        End Try

        Try

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnGuardarCosto_Click(sender As Object, e As EventArgs) Handles btnGuardarCosto.Click

        Call updateCosto()

    End Sub

    Private Sub updateCosto()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("UPDATE PRECIOS SET COSTO = @COSTO WHERE (EMPNIT = @EMPNIT) AND (CODPROD = @CODPROD) AND (EQUIVALE = 1)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODPROD", GlobalCodProd)
                cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtCostoUnitario.Text))

                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()
                MsgBox("COSTO UNITARIO ACTUALIZADO EXITOSAMENTE")

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using

        Call CargarListadoPrecios()

    End Sub

End Class
