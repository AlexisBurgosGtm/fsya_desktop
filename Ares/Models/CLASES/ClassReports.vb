
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class ClassReports
    Sub New()

    End Sub

    Public Function getReport(ByVal tbl As DataTable, ByVal rep As XtraReport, ByVal print As Boolean, ByVal nombre As String) As Boolean
        Dim r As Boolean

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim report As New XtraReport

        Try

            Dim Adapter As New SqlDataAdapter

            report = rep


            If nombre = "SN" Then

            Else
                Try
                    report.LoadLayout(Application.StartupPath + "\Reports\" & nombre & ".repx")
                Catch ex As Exception
                    report.SaveLayout(Application.StartupPath + "\Reports\" & nombre & ".repx")
                    report.LoadLayout(Application.StartupPath + "\Reports\" & nombre & ".repx")
                End Try

            End If

            report.DataSource = tbl
            report.DataAdapter = Adapter
            report.DataMember = tbl.TableName '"tblRptVentasCliente"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)

            report.CreateDocument()
            r = True

        Catch ex As Exception
            MsgBox(ex.ToString)
            r = False
        End Try

        SplashScreenManager.CloseForm()

        If r = True Then
            If print = True Then
                report.Print()
            Else
                report.ShowPreview()
            End If
        End If

        Return r

    End Function


    Public Function rptClientesProductosResumen(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date, ByVal codcliente As Integer) As Boolean

        Dim r As Boolean

        Dim tbl As New DSGeneral.tblRptClienteProductosResDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim qry As String = "SELECT        DOCUMENTOS.CODCLIENTE, CLIENTES.NIT, CLIENTES.NOMBRECLIENTE AS NOMCLIE, CLIENTES.DIRCLIENTE AS DIRCLIE, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, 
                         SUM(DOCPRODUCTOS.TOTALUNIDADES) AS TOTALUNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS TOTALPRECIO, (SUM(DOCPRODUCTOS.TOTALPRECIO)-SUM(DOCPRODUCTOS.TOTALCOSTO)) AS UTILIDAD, 0 AS MARGEN
FROM            DOCUMENTOS LEFT OUTER JOIN
                         CLIENTES ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND 
                         DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
WHERE        (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (DOCUMENTOS.EMPNIT = @E) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A')
GROUP BY DOCUMENTOS.CODCLIENTE, CLIENTES.NIT, CLIENTES.NOMBRECLIENTE, CLIENTES.DIRCLIENTE, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD
HAVING        (DOCUMENTOS.CODCLIENTE = @CODCLIE)"

                Dim cmd As New SqlCommand(qry, cn)

                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@FI", fechainicial)
                cmd.Parameters.AddWithValue("@FF", fechafinal)
                cmd.Parameters.AddWithValue("@CODCLIE", codcliente)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
                r = False
            End Try


        End Using

        Dim Adapter As New SqlDataAdapter

        Dim report As XtraReport
        report = New rptClientesProductos

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblRptClienteProductosRes"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()


        SplashScreenManager.CloseForm()
        report.ShowPreview

        Return r

    End Function


    Public Function rptClientesProductosDetalle(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date, ByVal codcliente As Integer) As Boolean

        Dim r As Boolean

        Dim tbl As New DSGeneral.tblRptClienteProductosResDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim qry As String = "SELECT        DOCUMENTOS.CODCLIENTE, CLIENTES.NIT, CLIENTES.NOMBRECLIENTE AS NOMCLIE, CLIENTES.DIRCLIENTE AS DIRCLIE, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, 
                         SUM(DOCPRODUCTOS.TOTALUNIDADES) AS TOTALUNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) 
                         - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD, 0 AS MARGEN, DOCUMENTOS.FECHA, CONCAT(DOCUMENTOS.CODDOC,'-',DOCUMENTOS.CORRELATIVO) AS CODDOC, DOCUMENTOS.CORRELATIVO
FROM            DOCUMENTOS LEFT OUTER JOIN
                         CLIENTES ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND 
                         DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
WHERE        (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (DOCUMENTOS.EMPNIT = @E) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A')
GROUP BY DOCUMENTOS.CODCLIENTE, CLIENTES.NIT, CLIENTES.NOMBRECLIENTE, CLIENTES.DIRCLIENTE, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, 
                         DOCUMENTOS.CORRELATIVO
HAVING        (DOCUMENTOS.CODCLIENTE = @CODCLIE)"

                Dim cmd As New SqlCommand(qry, cn)

                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@FI", fechainicial)
                cmd.Parameters.AddWithValue("@FF", fechafinal)
                cmd.Parameters.AddWithValue("@CODCLIE", codcliente)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
                r = False
            End Try


        End Using

        Dim Adapter As New SqlDataAdapter

        Dim report As XtraReport
        report = New rptClienteVentasProductosDoc

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblRptClienteProductosRes"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()


        SplashScreenManager.CloseForm()
        report.ShowPreview

        Return r

    End Function




    Public Function rptVentasClasificacion(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date, ByVal clasif As Integer, ByVal codclas As Integer) As Boolean

        Dim tbl As New DataTable

        Dim objQuery As New classQuerys
        Dim sql As String

        Select Case clasif
            Case 1
                sql = objQuery.queryRptClaseUno
            Case 2

            Case 3

        End Select

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@FI", fechainicial)
                cmd.Parameters.AddWithValue("@FF", fechafinal)
                cmd.Parameters.AddWithValue("@C", codclas)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    dr(0),'NIT
                                    dr(1),'NOMBRE
                                    dr(2),'DIRECCION
                                    dr(3),'CODMUN
                                    dr(4),'DESMUN
                                    dr(5),'CODDEP
                                    dr(6),'DESDEP
                                    dr(7),'CODDOC
                                    dr(8),'CORRELATIVO
                                    dr(9),'FECHA
                                    dr(10),'TOTALCOSTO
                                    dr(11),'TOTALVENTA
                                    dr(12) 'CONCRE
                                    })
                Loop

                dr.Close()
                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter

                Dim report As XtraReport
                report = New rptVentasPorCliente(fechainicial, fechafinal)

                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblRptVentasCliente"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()
                cn.Close()

                SplashScreenManager.CloseForm()
                report.ShowPreview

            End Using

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()

            Return False

        End Try

    End Function


    Public Function ReporteGeneral(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim objQryReport = New classQuerys
                Dim sql As String = objQryReport.queryRptGeneral

                Dim cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("FECHAINICIAL", fechainicial)
                cmd.Parameters.AddWithValue("FECHAFINAL", fechafinal)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
                tbl = Nothing
            End Try


        End Using

        Return tbl

    End Function

    Public Function tblFacturasElectronicas(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable


        Dim tblVtaDoc As New DataTable("tblVtaDoc")
        With tblVtaDoc
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("NIT", GetType(String))
            .Columns.Add("NOMCLIE", GetType(String))
            .Columns.Add("DIRCLIE", GetType(String))
            .Columns.Add("CONCRE", GetType(String))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALVENTA", GetType(Double))
            .Columns.Add("VENDEDOR", GetType(String))
            .Columns.Add("TOTALEXENTO", GetType(Double))
            .Columns.Add("TOTALAFECTO", GetType(Double))
            .Columns.Add("TOTALIVA", GetType(Double))
            .Columns.Add("ST", GetType(String))
        End With


        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                'Dim cmd As New SqlCommand("REPORTES_BI_VENTADOC", cn)
                Dim qryrpt As String = "Select DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.DOC_DIRCLIE, DOCUMENTOS.CONCRE, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, VENDEDORES.NOMVEN, 
						ISNULL(DOCUMENTOS.TOTALEXENTO, 0) AS TOTALEXENTO,
						ISNULL(DOCUMENTOS.TOTALIVA,0) AS TOTALIVA, 
						DOCUMENTOS.STATUS
                        From DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER JOIN VENDEDORES ON DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO BETWEEN @ANIOINICIAL AND @ANIOFINAL) AND (TIPODOCUMENTOS.TIPODOC IN('FEF','FEC','FES')) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) 
                        ORDER BY DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC,DOCUMENTOS.CORRELATIVO ASC"

                Dim cmd As New SqlCommand(qryrpt, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIOINICIAL", fechainicial.Year)
                cmd.Parameters.AddWithValue("@ANIOFINAL", fechafinal.Year)
                cmd.Parameters.AddWithValue("@FECHAINICIAL", fechainicial)
                cmd.Parameters.AddWithValue("@FECHAFINAL", fechafinal)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tblVtaDoc.Rows.Add(New Object() {
                          Date.Parse(dr(0)),'FECHA
                          dr(1).ToString,'CODDOC
                          Double.Parse(dr(2).ToString),'CORRELATIVO
                          dr(3).ToString,'NIT
                          dr(4).ToString,'NOMCLIE
                          dr(5).ToString,'DIRCLIE
                          dr(6).ToString,'CONCRE
                          Double.Parse(dr(7)),'TOTALCOSTO
                          Double.Parse(dr(8)),'TOTALVENTA
                          dr(9).ToString,'VENDEDOR,
                          Double.Parse(dr(10)),'TOTALEXENTO
                          Double.Parse(dr(8)) - Double.Parse(dr(10)),   'TOTALAFECTO
                          Double.Parse(dr(11)), 'TOTAL IVA 
                          dr(11).ToString 'STATUS
                          })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tblVtaDoc = Nothing
            End Try


        End Using

        Return tblVtaDoc

    End Function


    Public Function tblRptExentos(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable


        Dim tblVtaDoc As New DataTable("tblVtaDoc")
        With tblVtaDoc
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("NIT", GetType(String))
            .Columns.Add("NOMCLIE", GetType(String))
            .Columns.Add("DIRCLIE", GetType(String))
            .Columns.Add("CONCRE", GetType(String))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALVENTA", GetType(Double))
            .Columns.Add("VENDEDOR", GetType(String))
            .Columns.Add("TOTALEXENTO", GetType(Double))
            .Columns.Add("TOTALAFECTO", GetType(Double))
            .Columns.Add("ST", GetType(String))
        End With


        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                'Dim cmd As New SqlCommand("REPORTES_BI_VENTADOC", cn)
                Dim qryrpt As String = "Select DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.DOC_DIRCLIE, DOCUMENTOS.CONCRE, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, VENDEDORES.NOMVEN, ISNULL(DOCUMENTOS.TOTALEXENTO, 0) AS TOTALEXENTO, DOCUMENTOS.STATUS
                        From DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER JOIN VENDEDORES ON DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO BETWEEN @ANIOINICIAL AND @ANIOFINAL) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES')) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) 
                        ORDER BY DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC,DOCUMENTOS.CORRELATIVO ASC"

                Dim cmd As New SqlCommand(qryrpt, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIOINICIAL", fechainicial.Year)
                cmd.Parameters.AddWithValue("@ANIOFINAL", fechafinal.Year)
                cmd.Parameters.AddWithValue("@FECHAINICIAL", fechainicial)
                cmd.Parameters.AddWithValue("@FECHAFINAL", fechafinal)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tblVtaDoc.Rows.Add(New Object() {
                          Date.Parse(dr(0)),'FECHA
                          dr(1).ToString,'CODDOC
                          Double.Parse(dr(2).ToString),'CORRELATIVO
                          dr(3).ToString,'NIT
                          dr(4).ToString,'NOMCLIE
                          dr(5).ToString,'DIRCLIE
                          dr(6).ToString,'CONCRE
                          Double.Parse(dr(7)),'TOTALCOSTO
                          Double.Parse(dr(8)),'TOTALVENTA
                          dr(9).ToString,'VENDEDOR,
                          Double.Parse(dr(10)),'TOTALEXENTO
                          Double.Parse(dr(8)) - Double.Parse(dr(10)),   'TOTALAFECTO
                          dr(11).ToString 'STATUS
                          })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tblVtaDoc = Nothing
            End Try


        End Using

        Return tblVtaDoc

    End Function

    Public Function rptServiciosVehiculo(ByVal empnit As String, ByVal CodVehiculo As Integer) As Boolean

        Dim tbl As New DSReports.tblRptVentasRepartidorDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CLIENTES_VEHICULOS.EMPNIT, CLIENTES_VEHICULOS.CODVEHICULO, CLIENTES_VEHICULOS.CODCLIENTE, CLIENTES.NOMBRECLIENTE AS NOMCLIENTE, CLIENTES.DIRCLIENTE, 
                         CLIENTES.TELEFONOCLIENTE AS TELCLIENTE, DOCUMENTOS_ORDENTRABAJO.FECHA, DOCUMENTOS_ORDENTRABAJO.HORA, DOCUMENTOS_ORDENTRABAJO.MINUTO, 
                         DOCUMENTOS_ORDENTRABAJO.FECHAENTREGA, DOCUMENTOS_ORDENTRABAJO.CODDOC, DOCUMENTOS_ORDENTRABAJO.CORRELATIVO, DOCUMENTOS_ORDENTRABAJO.ORDEN, 
                         DOCUMENTOS_ORDENTRABAJO.OBS, DOCUMENTOS_ORDENTRABAJO.DIAGNOSTICO, DOCUMENTOS_ORDENTRABAJO.IMPORTE, DOCUMENTOS_ORDENTRABAJO.ADELANTO, 
                         DOCUMENTOS_ORDENTRABAJO.FINALIZADO, CLIENTES_VEHICULOS.DESVEHICULO, EMPLEADOS.NOMEMPLEADO
                        FROM            EMPLEADOS RIGHT OUTER JOIN
                         DOCUMENTOS_ORDENTRABAJO ON EMPLEADOS.EMPNIT = DOCUMENTOS_ORDENTRABAJO.EMPNIT AND EMPLEADOS.CODEMPLEADO = DOCUMENTOS_ORDENTRABAJO.CODEMPLEADO RIGHT OUTER JOIN
                         CLIENTES_VEHICULOS LEFT OUTER JOIN
                         CLIENTES ON CLIENTES_VEHICULOS.CODCLIENTE = CLIENTES.CODCLIENTE AND CLIENTES_VEHICULOS.EMPNIT = CLIENTES.EMPNIT ON 
                         DOCUMENTOS_ORDENTRABAJO.EMPNIT = CLIENTES_VEHICULOS.EMPNIT AND DOCUMENTOS_ORDENTRABAJO.CODVEHICULO = CLIENTES_VEHICULOS.CODVEHICULO
                        WHERE        (CLIENTES_VEHICULOS.EMPNIT = @EMPNIT) AND (CLIENTES_VEHICULOS.CODVEHICULO = @CODVEHICULO) AND (DOCUMENTOS_ORDENTRABAJO.FINALIZADO = 'SI')", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODVEHICULO", CodVehiculo)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter

                Dim report As XtraReport
                report = New rptHistorialVehiculo

                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblHistorialVehiculo"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()
                cn.Close()

                SplashScreenManager.CloseForm()
                report.ShowPreview

            End Using

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()
            MsgBox(GlobalDesError)
            Return False

        End Try

    End Function

    Public Function rptVentasRepartidor(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date, ByVal CodRepartidor As Integer) As Boolean

        Dim tbl As New DSReports.tblRptVentasRepartidorDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT DOCUMENTOS.CODREP, REPARTIDORES.DESREP, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NOMCLIE AS CLIENTE, DOCUMENTOS.TOTALCOSTO AS COSTO, DOCUMENTOS.TOTALPRECIO AS IMPORTE
                                            FROM DOCUMENTOS LEFT OUTER JOIN VENDEDORES ON DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT LEFT OUTER JOIN REPARTIDORES ON DOCUMENTOS.CODREP = REPARTIDORES.CODREP AND DOCUMENTOS.EMPNIT = REPARTIDORES.EMPNIT
                                            WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.CODREP = @CODREP) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@FECHAINICIAL", fechainicial)
                cmd.Parameters.AddWithValue("@FECHAFINAL", fechafinal)
                cmd.Parameters.AddWithValue("@CODREP", CodRepartidor)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter

                Dim report As XtraReport
                report = New rptVentasRepartidor(fechainicial, fechafinal)

                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblRptVentasRepartidor"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()
                cn.Close()

                SplashScreenManager.CloseForm()
                report.ShowPreview

            End Using

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()

            Return False

        End Try

    End Function

    Public Function rptFicheroCuotasFactura(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As String) As Boolean

        Dim tbl As New DSCxc.tblDocCuotasPendientesDataTable
        Dim result As Boolean

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("Select DOCCUOTAS.NITCLIE, CLIENTES.NOMBRECLIENTE, CLIENTES.TELEFONOCLIENTE, DOCCUOTAS.NOCUOTA, DOCCUOTAS.FECHAPAGO, DOCCUOTAS.CUOTA, DOCCUOTAS.CODDOC, DOCCUOTAS.CORRELATIVO, DOCCUOTAS.CODCLIE
                                        From DOCCUOTAS LEFT OUTER Join CLIENTES On DOCCUOTAS.CODCLIE = CLIENTES.CODCLIENTE And DOCCUOTAS.EMPNIT = CLIENTES.EMPNIT
                                        Where (DOCCUOTAS.EMPNIT = @EMPNIT) AND (DOCCUOTAS.CODDOC=@CODDOC) AND (DOCCUOTAS.CORRELATIVO=@CORRELATIVO)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter

                Dim report As XtraReport
                report = New rptFicheroFactura

                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblDocCuotasPendientes"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()
                cn.Close()

                SplashScreenManager.CloseForm()

                report.ShowPreview

            End Using

            result = True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()

            result = False

        End Try

        Return result

    End Function

    Public Function rptVentasClientes(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date) As Boolean

        Dim tbl As New DataSetReportes.tblRptVentasClienteDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("sp_rpt_ventasporcliente", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@FECHAINICIAL", fechainicial)
                cmd.Parameters.AddWithValue("@FECHAFINAL", fechafinal)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    dr(0),'NIT
                                    dr(1),'NOMBRE
                                    dr(2),'DIRECCION
                                    dr(3),'CODMUN
                                    dr(4),'DESMUN
                                    dr(5),'CODDEP
                                    dr(6),'DESDEP
                                    dr(7),'CODDOC
                                    dr(8),'CORRELATIVO
                                    dr(9),'FECHA
                                    dr(10),'TOTALCOSTO
                                    dr(11),'TOTALVENTA
                                    dr(12) 'CONCRE
                                    })
                Loop

                dr.Close()
                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter

                Dim report As XtraReport
                report = New rptVentasPorCliente(fechainicial, fechafinal)

                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblRptVentasCliente"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()
                cn.Close()

                SplashScreenManager.CloseForm()
                report.ShowPreview

            End Using

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()

            Return False

        End Try

    End Function

    Public Function fcn_CargarReporte(ByVal Reporte As Object, ByVal Path As String, ByVal DataMember As String, ByVal DataSource As DataTable) As Boolean
        Dim Adapter As New SqlDataAdapter

        Dim report As XtraReport
        report = Reporte

        'CARGO PRIMERO EL REPORTE
        If Path <> "NO" Then
            report.LoadLayout(Path)
        End If
        report.DataSource = DataSource
        report.DataAdapter = Adapter
        report.DataMember = DataMember

        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        report.ShowPreview

    End Function

    Public Function fcn_CargarReporteExis(ByVal Reporte As Object, ByVal Path As String, ByVal DataMember As String, ByVal DataSource As DataTable) As Boolean
        Dim Adapter As New SqlDataAdapter

        Dim report As XtraReport
        report = Reporte

        'CARGO PRIMERO EL REPORTE
        If Path <> "NO" Then
            report.LoadLayout(Path)
        End If
        report.DataSource = DataSource
        report.DataAdapter = Adapter
        report.DataMember = DataMember

        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        report.ShowPreview


    End Function

    Public Function fcn_ExportarReporte(ByVal Reporte As Object, ByVal Path As String, ByVal DataMember As String, ByVal DataSource As DataTable) As Boolean
        Dim Adapter As New SqlDataAdapter

        Dim report As XtraReport
        report = Reporte

        'CARGO PRIMERO EL REPORTE
        If Path <> "NO" Then
            report.LoadLayout(Path)
        End If
        report.DataSource = DataSource
        report.DataAdapter = Adapter
        report.DataMember = DataMember

        report.CreateDocument()

        report.ExportToXlsx("\\10.243.0.19\cortes\" + "CORTE_" + globalcorrelativocorte.ToString + "_DE_" + GlobalNomEmpresa.ToString + ".xlsx")


    End Function

    'pivot general
    Public Function tblPivotGeneral(ByVal empnit As String, ByVal FechaInicial As Date, ByVal FechaFinal As Date) As DataTable
        Dim tbl As New DSReports.tblPivotGeneralDataTable


        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("sp_rpt_pivotgeneral", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@fechainicial", FechaInicial)
            cmd.Parameters.AddWithValue("@fechafinal", FechaFinal)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                    dr(0),
                    dr(1),
                    dr(2),
                    dr(3),
                    dr(4),
                    dr(5),
                    dr(6),
                    dr(7),
                    dr(8),
                    dr(9),
                    dr(10),
                    dr(11),
                    dr(12),
                    dr(13),
                    dr(14),
                    dr(15),
                    dr(16),
                    dr(17),
                    dr(18),
                    dr(19),
                    dr(20),
                    dr(21),
                    dr(22),
                    dr(23),
                    Date.Parse(dr(24))
                })
            Loop
            dr.Close()
            cmd.Dispose()

            Return tbl

        Catch ex As Exception
            GlobalDesError = ex.ToString
            MsgBox(GlobalDesError)
            Return Nothing
        End Try

        cn.Close()

    End Function

    Public Function rptReciboCliente(ByVal empnit As String, ByVal fecha As Date, ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Call AbrirConexionSql()

        Dim tbl As New DSGeneral.tblReciboAbonoDataTable


        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim objQry As New classQuerys

        Try
            Dim cmd As New SqlCommand(objQry.queryTempReciboPago, cn)

            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()

            Do While dr.Read
                tbl.Rows.Add(New Object() {
                                        dr(0).ToString,'empresa
                                        dr(1).ToString,'coddoc
                                        dr(2).ToString,'correlativo
                                        Date.Parse(dr(3)),'fecha
                                        dr(4).ToString,'vendedor
                                       dr(5).ToString,'usuario
                                        dr(6).ToString,'serie fac
                                        dr(7).ToString,'numero fac
                                        Double.Parse(dr(8)),'abono
                                        dr(9).ToString, 'obs
                                        dr(10).ToString,  'tipo pago
                                        dr(11).ToString,    'no doc pago
                                        dr(12).ToString,    'NOMCLIE
                                        Double.Parse(dr(13)),   'SALDO DOCUMENTO
                                        Double.Parse(dr(14)),   'PAGADO
                                        Double.Parse(dr(15))   'VUELTO
                                        })
            Loop

            dr.Close()
            cmd.Dispose()
            cn.Close()

            Dim Adapter As New SqlDataAdapter

            Dim report As XtraReport

            report = New rptReciboAbono

            Try
                report.LoadLayout(Application.StartupPath + "\Reports\RECIBO_CLIENTES.repx")
            Catch ex As Exception
                report.SaveLayout(Application.StartupPath + "\Reports\RECIBO_CLIENTES.repx")
                report.LoadLayout(Application.StartupPath + "\Reports\RECIBO_CLIENTES.repx")
            End Try


            report.DataSource = tbl
            report.DataAdapter = Adapter
            report.DataMember = "tblReciboAbono"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)

            report.CreateDocument()

            SplashScreenManager.CloseForm()
            report.ShowPreview

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()
            cn.Close()
            Return False

        End Try

    End Function

    Public Function rptReciboProveedor(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Call AbrirConexionSql()

        Dim tbl As New DSGeneral.tblReciboAbonoDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim objQry As New classQuerys

        Try
            Dim cmd As New SqlCommand(objQry.queryTempReciboPago, cn)

            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()

            Do While dr.Read
                tbl.Rows.Add(New Object() {
                                        dr(0).ToString,'empresa
                                        dr(1).ToString,'coddoc
                                        dr(2).ToString,'correlativo
                                        Date.Parse(dr(3)),'fecha
                                        "0",'vendedor
                                       dr(5).ToString,'usuario
                                        dr(6).ToString,'serie fac
                                        dr(7).ToString,'numero fac
                                        Double.Parse(dr(8)),'abono
                                        dr(9).ToString, 'obs
                                        dr(10).ToString, ' tipo pago
                                        dr(11).ToString  ' no doc pago
                                        })
            Loop

            dr.Close()
            cmd.Dispose()
            cn.Close()

            Dim Adapter As New SqlDataAdapter

            Dim report As XtraReport

            report = New rptReciboAbono
            Try
                report.LoadLayout(Application.StartupPath + "\Reports\RECIBO_PROVEEDOR.repx")
            Catch ex As Exception
                report.SaveLayout(Application.StartupPath + "\Reports\RECIBO_PROVEEDOR.repx")
                report.LoadLayout(Application.StartupPath + "\Reports\RECIBO_PROVEEDOR.repx")
            End Try


            report.DataSource = tbl
            report.DataAdapter = Adapter
            report.DataMember = "tblReciboAbono"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)

            report.CreateDocument()

            SplashScreenManager.CloseForm()
            report.ShowPreview

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()
            cn.Close()
            Return False

        End Try

    End Function

    Public Function rptVentasVendedor(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date) As Boolean


        Dim tbl As New DataSetReportes.tblVentasVendedorDataTable


        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If



            Try

                Dim SQL As String
                SQL = "SELECT EMPRESAS.EMPNOMBRE, VENDEDORES.NOMVEN, DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS TOTALUNIDADES, 
                         SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS TOTALPRECIO
                    FROM  DOCUMENTOS LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND 
                         DOCUMENTOS.MES = DOCPRODUCTOS.MES AND DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                         VENDEDORES ON DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                    WHERE (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) AND (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.EMPNIT=@EMPNIT)
                    GROUP BY EMPRESAS.EMPNOMBRE, VENDEDORES.NOMVEN, DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD"

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@FECHAINICIAL", fechainicial)
                cmd.Parameters.AddWithValue("@FECHAFINAL", fechafinal)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim Adapter As New SqlDataAdapter
                Dim report As New rptVentasVendedor

                report.LoadLayout(Application.StartupPath + "\Reports\rptVentasVendedor.repx")

                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblVentasVendedor"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()

                SplashScreenManager.CloseForm()
                report.ShowPreview

                Return True

            Catch ex As Exception

                GlobalDesError = ex.ToString
                SplashScreenManager.CloseForm()

                Return False

            End Try

        End Using

    End Function

    Public Function rptGastosFechas(ByVal empnit As String, ByVal fechainicial As Date, ByVal fechafinal As Date) As Boolean

        Dim tbl As New DSReports.tblRptGastosDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.USUARIO, TIPOGASTOS.DESTIPOGASTO, DOCPRODUCTOS.DESPROD AS DESCRIPCION, DOCPRODUCTOS.TOTALPRECIO
                    FROM TIPOGASTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON TIPOGASTOS.CODMEDIDA = DOCPRODUCTOS.CODMEDIDA RIGHT OUTER JOIN
                         DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND 
                         DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
                    WHERE        (TIPODOCUMENTOS.TIPODOC = 'GAS') AND (DOCUMENTOS.EMPNIT=@EMPNIT) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) ORDER BY DOCUMENTOS.FECHA, DOCUMENTOS.CORRELATIVO", cn)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@FECHAINICIAL", fechainicial)
                cmd.Parameters.AddWithValue("@FECHAFINAL", fechafinal)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter

                Dim report As XtraReport
                report = New rptGASTOS(fechainicial, fechafinal)

                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblRptGastos"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()
                cn.Close()

                SplashScreenManager.CloseForm()
                report.ShowPreview

            End Using

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()

            Return False

        End Try

    End Function

End Class
