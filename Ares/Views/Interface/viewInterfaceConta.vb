Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewInterfaceConta

#Region "EVENTOS LOAD"

    Private Sub viewInterfaceConta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSUCURSALES
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

        GlobalNomEmpresa = Form1.cmbLoginEmpresa.Text
        GlobalNomUsuario = Form1.txtUser.Text

        Me.lbUSUARIO.Text = GlobalNomUsuario
        Me.lbEMPRESA.Text = GlobalNomEmpresa

    End Sub

    Private Sub TileNavPaneMain_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles TileNavPane1.ElementClick

        Dim tag As String
        Try
            tag = e.Element.Tag.ToString
        Catch ex As Exception
            tag = ""
        End Try

        Select Case tag

            Case "ONLINE"
                Me.FlyoutPanelOnline.ShowPopup()

            Case Else
                Call NAVEGAR(tag)

        End Select

    End Sub


    Private Sub TileControl1_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles tileControl1.ItemClick
        Dim tag As String = ""
        Try
            tag = e.Item.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)

    End Sub

    Private Sub AccordionControlMenuGeneral_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.ElementClickEventArgs) Handles AccordionControlMenuGeneral.ElementClick
        Dim tag As String = ""
        Try
            tag = e.Element.Tag.ToString
        Catch ex As Exception

        End Try

        Call NAVEGAR(tag)
    End Sub

    Private Sub TileItemREPC_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemREPC.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Call NAVEGAR("CORTES_ONLINE2")

        End If

    End Sub

    Private Sub TileItemRepPFacturas_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemRepPFacturas.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Call NAVEGAR("VENTAS_ONLINE2")

        End If

    End Sub

#End Region

#Region "REPORTE DE VENTAS FAC"

    Private Function TBLReportVFAC() As DataTable
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim tbl As New DataTable
        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.FECHA, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALEXENTO, SUM(DOCUMENTOS.TOTALPRECIO) 
                                                         - SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALAFECTO, TIPODOCUMENTOS.TIPODOC
                                           FROM            DOCUMENTOS LEFT OUTER JOIN
                                                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE        (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCUMENTOS.FECHA, TIPODOCUMENTOS.TIPODOC
                                           HAVING        (DOCUMENTOS.FECHA BETWEEN @MI AND @MF) AND (TIPODOCUMENTOS.TIPODOC = 'FAC')
                                           ORDER BY DOCUMENTOS.FECHA", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamDatePickI)
                cmd.Parameters.AddWithValue("@MF", GlobalParamDatePickF)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using
        SplashScreenManager.CloseForm()
        Return tbl
    End Function

    Private Sub TileItemFAC_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemFAC.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then
            Me.gridExports.DataSource = Nothing
            Me.gridExports.DataSource = TBLReportVFAC()
            Try
                Me.gridExports.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTFAC - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTFAC - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports.DataSource = Nothing
        End If

    End Sub

#End Region

#Region "REPORTE DE VENTAS FEL"

    Private Function TBLReportVFEL() As DataTable
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim tbl As New DataTable
        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.FECHA, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALEXENTO, SUM(DOCUMENTOS.TOTALPRECIO) 
                                                         - SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALAFECTO, TIPODOCUMENTOS.TIPODOC
                                           FROM            DOCUMENTOS LEFT OUTER JOIN
                                                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE        (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCUMENTOS.FECHA, TIPODOCUMENTOS.TIPODOC
                                           HAVING        (DOCUMENTOS.FECHA BETWEEN @MI AND @MF) AND (TIPODOCUMENTOS.TIPODOC = 'FEF')
                                           ORDER BY DOCUMENTOS.FECHA", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamDatePickI)
                cmd.Parameters.AddWithValue("@MF", GlobalParamDatePickF)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using
        SplashScreenManager.CloseForm()
        Return tbl
    End Function

    Private Sub TileItemFEL_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemFEL.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then
            Me.gridExports1.DataSource = Nothing
            Me.gridExports1.DataSource = TBLReportVFEL()
            Try
                Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTFEL - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTFEL - " + Me.cmbSUCURSALES.Text + ".xlsx")
            Catch ex As Exception
                MsgBox("Ha ocurrido un Error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports1.DataSource = Nothing
        End If

    End Sub

#End Region

#Region "REPORTE DE VENTAS EX/AFEC"

    Private Function TBLReportVEXAFEC() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tbl As New DataTable

        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try

                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.FECHA, SUM(DOCUMENTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALEXENTO, SUM(DOCUMENTOS.TOTALPRECIO) 
                                                         - SUM(DOCUMENTOS.TOTALEXENTO) AS TOTALAFECTO, TIPODOCUMENTOS.TIPODOC
                                           FROM            DOCUMENTOS LEFT OUTER JOIN
                                                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                           WHERE        (DOCUMENTOS.STATUS <> 'A')
                                           GROUP BY DOCUMENTOS.FECHA, TIPODOCUMENTOS.TIPODOC
                                           HAVING        (DOCUMENTOS.FECHA BETWEEN @MI AND @MF) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF'))
                                           ORDER BY DOCUMENTOS.FECHA", cn)
                cmd.Parameters.AddWithValue("@MI", GlobalParamDatePickI)
                cmd.Parameters.AddWithValue("@MF", GlobalParamDatePickF)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                '(DOCUMENTOS.EMPNIT = 'farma001') AND 

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Private Sub TileItemEXAFEC_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemEXAFEC.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewFechaCAL) = DialogResult.OK Then

            Me.gridExports2.DataSource = Nothing
            Me.gridExports2.DataSource = TBLReportVEXAFEC()

            Try
                Me.gridExports2.ExportToXlsx(Application.StartupPath + "\EXPORTS\REPORTEXAFEC - " + Me.cmbSUCURSALES.Text + ".xlsx")
                Process.Start(Application.StartupPath + "\EXPORTS\REPORTEXAFEC - " + Me.cmbSUCURSALES.Text + ".xlsx")

            Catch ex As Exception
                MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error:  " & ex.ToString)
            End Try
            Me.gridExports2.DataSource = Nothing

        End If

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

        Me.gridExports3.DataSource = Nothing
        Me.gridExports3.DataSource = TBLGENERAL(0, 0)
        Try
            Me.gridExports3.ExportToXlsx(Application.StartupPath + "\EXPORTS\InventarioGeneral-" + Me.cmbSUCURSALES.Text + ".xlsx")
            Process.Start(Application.StartupPath + "\EXPORTS\InventarioGeneral-" + Me.cmbSUCURSALES.Text + ".xlsx")

        Catch ex As Exception
            MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error: " & ex.ToString)
        End Try
        Me.gridExports3.DataSource = Nothing

    End Sub

#End Region

#Region "REPORTE BONOS"

    'Private Function TBLReportBONOS() As DataTable
    '   SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
    'Dim tbl As New DataTable
    'Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
    'If cn.State <> ConnectionState.Open Then
    '           cn.Open()
    'End If
    'Try
    'Dim cmd As New SqlCommand("SELECT           DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS [T COSTO], 
    '                                                       SUM(DOCPRODUCTOS.TOTALPRECIO) AS [T PRECIO], PRODUCTOS.BONO, SUM(DOCPRODUCTOS.TOTALUNIDADES) * (PRODUCTOS.BONO) AS TOTALBONO, EMPLEADOS.NOMEMPLEADO
    '                                     FROM             EMPLEADOS RIGHT OUTER JOIN
    '                                                     DOCUMENTOS ON EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN AND EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT RIGHT OUTER JOIN
    '                                                    DOCPRODUCTOS ON DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
    '                                                   TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
    '                                                  PRODUCTOS ON DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT AND DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.DESPROD = PRODUCTOS.DESPROD
    '                                WHERE            (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF)
    '                               GROUP BY         DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, EMPLEADOS.NOMEMPLEADO
    '                              HAVING           (PRODUCTOS.BONO > 0)", cn)
    '  cmd.Parameters.AddWithValue("@FI", GlobalParamDatePickI)
    ' cmd.Parameters.AddWithValue("@FF", GlobalParamDatePickF)
    'Dim da As New SqlDataAdapter
    '           da.SelectCommand = cmd
    '          da.Fill(tbl)
    'Catch ex As Exception
    '           MsgBox(ex.ToString)
    '          GlobalDesError = ex.ToString
    '         tbl = Nothing
    'End Try
    'End Using
    '   SplashScreenManager.CloseForm()
    'Return tbl
    'End Function

    Private Sub TileItemBONOS_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemBONOS.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewBONOSC) = DialogResult.OK Then

        End If

    End Sub

    Private Sub TileItemKEEP_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemKEEP.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewVENTASKEEP) = DialogResult.OK Then

        End If

    End Sub

    Private Sub TileItemTRASBOD_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemTRASBOD.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewTRASBOD) = DialogResult.OK Then

        End If

    End Sub

    Private Sub TileItemGASTOS_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileItemGASTOS.ItemClick

        If FlyoutDialog.Show(Me.ParentForm, New viewREPGASTOS) = DialogResult.OK Then

        End If

    End Sub

#End Region

End Class
