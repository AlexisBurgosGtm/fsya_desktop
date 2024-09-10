Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Module BusinessIntelligence

    Dim objReports As New ClassReports
    Dim objQuerys As New classQuerys

    'REPORTE DE DEVOLUCION
    Public Function rptDevolucionVenta(ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim result As Boolean

        Dim tbl As New DSReports.tblDevolucionDataTable


        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try

                Dim cmd As New SqlCommand("SELECT       EMPRESAS.EMPNOMBRE, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, 
                         DOCPRODUCTOS.CANTIDAD, DOCPRODUCTOS.EQUIVALE, DOCPRODUCTOS.TOTALUNIDADES, DOCPRODUCTOS.COSTO, DOCPRODUCTOS.PRECIO, DOCPRODUCTOS.TOTALCOSTO, DOCPRODUCTOS.TOTALPRECIO, 
                         DOCPRODUCTOS.OBS, DOCUMENTOS.CODCLIENTE, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIE, DOCUMENTOS.DOC_DIRCLIE AS DIRCLIE, DOCUMENTOS.SERIEFAC, 
                         DOCUMENTOS.NOFAC
                    FROM DOCUMENTOS LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                         DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                         EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT
                    WHERE (TIPODOCUMENTOS.TIPODOC = 'DEV') AND (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODDOC = @D) AND (DOCUMENTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
                result = False
            End Try

        End Using


        SplashScreenManager.CloseForm()

        If result = True Then
            Dim Adapter As New SqlDataAdapter
            Dim report As New rptDevolucion

            Try
                report.LoadLayout(Application.StartupPath + "\Reports\DEVOLUCION.repx")
            Catch ex As Exception
                report.SaveLayout(Application.StartupPath + "\Reports\DEVOLUCION.repx")
                report.LoadLayout(Application.StartupPath + "\Reports\DEVOLUCION.repx")
            End Try



            report.DataSource = tbl
            report.DataAdapter = Adapter
            report.DataMember = "tblDevolucion"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            report.ShowPreview
        End If

        Return result

    End Function

    'REPORTE DE TICKET DE PREVENTA

    Public Function rptCredencialesFel() As Boolean

        Dim result As Boolean
        Dim tblFel As New VENTASDataSet.tblFelDataTable

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmdHost As New SqlCommand("SELECT        EMISOR_NOMBRECOMECIAL, EMISOR_DIRECCION
                                               FROM            FEL_CREDENCIALES", cn)

                Dim dr As SqlDataReader
                dr = cmdHost.ExecuteReader

                Do While dr.Read
                    tblFel.Rows.Add(New Object() {
                                      dr(0).ToString, 'NOMEMPRESA
                                      dr(1).ToString  'DIRECCION
                                                     })
                Loop
                dr.Close()
                dr = Nothing
                cmdHost.Dispose()
                'cnHost.Close()
            End Using

        Catch ex As Exception
            GlobalDesError = ex.ToString

        End Try

    End Function

    Public Function rptEnviosTicketHost(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal fecha As Date) As Boolean

        Dim result As Boolean

        Dim tblTicket As New VENTASDataSet.tblTicketDataTable

        TotalVentaFAC = 0

        Try
            Using cnHost As New SqlConnection(strHostConectionString)
                If cnHost.State <> ConnectionState.Open Then
                    cnHost.Open()
                End If


                Dim sql As String
                'sql = "REPORTES_TEMP_TICKET"
                sql = "SELECT CONCAT(WEB_DOCUMENTOS.ANIO, '-',WEB_DOCUMENTOS.MES,'-',WEB_DOCUMENTOS.DIA) AS FECHA, WEB_DOCUMENTOS.CODDOC, WEB_DOCUMENTOS.CORRELATIVO, ISNULL(WEB_DOCPRODUCTOS.CODPROD, 'SN') AS CODPROD, 
                         ISNULL(WEB_DOCPRODUCTOS.DESPROD, 'SN') AS DESPROD, ISNULL(WEB_DOCPRODUCTOS.CODMEDIDA, 'SN') AS CODMEDIDA, ISNULL(WEB_DOCPRODUCTOS.CANTIDAD, 0) AS CANTIDAD, 
                         ISNULL(WEB_DOCPRODUCTOS.COSTO, 0) AS COSTO, ISNULL(WEB_DOCPRODUCTOS.PRECIO, 0) AS PRECIO, WEB_DOCUMENTOS.CODCLIENTE, CLIENTES.NIT AS DOC_NIT, CLIENTES.NOMCLIENTE AS DOC_NOMCLIE, 
                         CLIENTES.DIRCLIENTE AS DOC_DIRCLIE, WEB_DOCUMENTOS.CODVEN, VENDEDORES.NOMVEN, ISNULL(WEB_DOCPRODUCTOS.TOTALCOSTO, 0) AS TOTALCOSTO, ISNULL(WEB_DOCPRODUCTOS.TOTALPRECIO, 0) 
                         AS TOTALPRECIO, EMPRESAS.EMPNOMBRE, 0 AS PAGO, 0 AS VUELTO, 0 AS HORA, 0 AS MINUTO, 'CRE' AS CONCRE, 'SN' AS AUTORIZACION, 'SN' AS RESOLUCION, 'SN' AS FRASE1, ' ' AS NOSERIE, 
                         MUNICIPIOS.DESMUNICIPIO, CLIENTES.TELEFONOS AS TELCLIENTE, 0 AS TOTALTARJETA, 0 AS RECARGOTARJETA
                            FROM VENDEDORES RIGHT OUTER JOIN
                         WEB_DOCPRODUCTOS RIGHT OUTER JOIN
                         WEB_DOCUMENTOS ON WEB_DOCPRODUCTOS.DIA = WEB_DOCUMENTOS.DIA AND WEB_DOCPRODUCTOS.MES = WEB_DOCUMENTOS.MES AND WEB_DOCPRODUCTOS.ANIO = WEB_DOCUMENTOS.ANIO AND 
                         WEB_DOCPRODUCTOS.TOKEN = WEB_DOCUMENTOS.TOKEN AND WEB_DOCPRODUCTOS.EMPNIT = WEB_DOCUMENTOS.EMPNIT AND WEB_DOCPRODUCTOS.CODDOC = WEB_DOCUMENTOS.CODDOC AND 
                         WEB_DOCPRODUCTOS.CORRELATIVO = WEB_DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                         EMPRESAS ON WEB_DOCUMENTOS.TOKEN = EMPRESAS.TOKEN AND WEB_DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT ON VENDEDORES.TOKEN = WEB_DOCUMENTOS.TOKEN AND 
                         VENDEDORES.EMPNIT = WEB_DOCUMENTOS.EMPNIT AND VENDEDORES.CODVEN = WEB_DOCUMENTOS.CODVEN LEFT OUTER JOIN
                         CLIENTES ON WEB_DOCUMENTOS.TOKEN = CLIENTES.TOKEN AND WEB_DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND WEB_DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         MUNICIPIOS ON CLIENTES.CODMUNICIPIO = MUNICIPIOS.CODMUNICIPIO
                        WHERE 
                            (WEB_DOCUMENTOS.EMPNIT = @EMPNIT) 
                        AND (WEB_DOCUMENTOS.TOKEN = @TOKEN) 
                        AND (WEB_DOCUMENTOS.CODDOC = @CODDOC) 
                        AND (WEB_DOCUMENTOS.CORRELATIVO = @CORRELATIVO) 
                        AND (WEB_DOCUMENTOS.ANIO = @ANIO) 
                        AND (WEB_DOCUMENTOS.MES = @MES) 
                        AND (WEB_DOCUMENTOS.DIA = @DIA)"

                Dim cmdHost As New SqlCommand(sql, cnHost)
                cmdHost.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdHost.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmdHost.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                cmdHost.Parameters.AddWithValue("@TOKEN", Token)
                cmdHost.Parameters.AddWithValue("@DIA", fecha.Day)
                cmdHost.Parameters.AddWithValue("@MES", fecha.Month)
                cmdHost.Parameters.AddWithValue("@ANIO", fecha.Year)


                Dim dr As SqlDataReader
                dr = cmdHost.ExecuteReader

                Do While dr.Read
                    tblTicket.Rows.Add(New Object() {
                                      Date.Parse(dr(0).ToString), 'FECHA
                                      dr(1).ToString,'coddoc
                                      Double.Parse(dr(2).ToString),'correlativo
                                      dr(3).ToString,'codprod
                                      dr(4).ToString,'desprod
                                      dr(5).ToString,'codmedida
                                      Double.Parse(dr(6)),'cantidad
                                      Double.Parse(dr(7)),'costo
                                      Double.Parse(dr(8)),'precio
                                      Integer.Parse(dr(9)),'codcliente
                                      dr(10).ToString,'nit
                                      dr(11).ToString,'nombrecliente
                                      dr(12).ToString,'dircliente
                                      Integer.Parse(dr(13)),'codven
                                      dr(14).ToString,'nomven
                                      Double.Parse(dr(15)),'totalcosto
                                      Double.Parse(dr(16)),'totalprecio
                                      dr(17).ToString,'empnombre
                                      Double.Parse(dr(18)),'pago
                                      Double.Parse(dr(19)),'vuelto
                                      Integer.Parse(dr(20)),'hora
                                      Integer.Parse(dr(21)),'minuto
                                      dr(22).ToString,  'CONCRE
                                      dr(23).ToString, 'AUTORIZACION
                                      dr(24).ToString, 'RESOLUCION
                                      dr(25).ToString, 'FRASE1
                                      fcn_verificanoserie(dr(26).ToString), 'noserie
                                      dr(27), 'DESMUNICIPIO
                                      dr(28)  'TELCLIENTE
                                                     })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmdHost.Dispose()
                'cnHost.Close()
            End Using


            Dim Adapter As New SqlDataAdapter
            Dim report As New rptEnvioCarta

            'CARGO PRIMERO EL REPORTE
            report.LoadLayout(Application.StartupPath + "\Reports\rptEnvioTicket.repx")

            report.DataSource = tblTicket
            report.DataAdapter = Adapter
            report.DataMember = "tblTicket"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            report.ShowPreview
            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        Return result

    End Function

    'TICKET DE DOMICILIO
    Public Function rptEnviosTicketHostDomicilio(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal fecha As Date) As Boolean

        Dim result As Boolean

        Dim tblTicket As New VENTASDataSet.tblTicketDataTable

        TotalVentaFAC = 0

        Try
            Using cnHost As New SqlConnection(strHostConectionString)
                If cnHost.State <> ConnectionState.Open Then
                    cnHost.Open()
                End If


                Dim sql As String
                'sql = "REPORTES_TEMP_TICKET"
                sql = "SELECT COMMUNITY_DOCUMENTOS_DOMICILIO.FECHA, COMMUNITY_DOCUMENTOS_DOMICILIO.CODDOC, COMMUNITY_DOCUMENTOS_DOMICILIO.CORRELATIVO, COMMUNITY_DOCPRODUCTOS_DOMICILIO.CODPROD, 
                         COMMUNITY_DOCPRODUCTOS_DOMICILIO.DESPROD, COMMUNITY_DOCPRODUCTOS_DOMICILIO.CODMEDIDA, COMMUNITY_DOCPRODUCTOS_DOMICILIO.CANTIDAD, COMMUNITY_DOCPRODUCTOS_DOMICILIO.COSTO, 
                         COMMUNITY_DOCPRODUCTOS_DOMICILIO.PRECIO, COMMUNITY_DOCUMENTOS_DOMICILIO.CODCLIENTE, COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_NIT, COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_NOMCLIE, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_DIRCLIE, COMMUNITY_DOCUMENTOS_DOMICILIO.CODVEN, 'DOMICILIO' AS NOMVEN, COMMUNITY_DOCPRODUCTOS_DOMICILIO.TOTALCOSTO, 
                         COMMUNITY_DOCPRODUCTOS_DOMICILIO.TOTALPRECIO, 'DOMICILIO' AS EMPNOMBRE, 0 AS PAGO, 0 AS VUELTO, COMMUNITY_DOCUMENTOS_DOMICILIO.HORA, COMMUNITY_DOCUMENTOS_DOMICILIO.MINUTO, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.CONCRE, 'SN' AS AUTORIZACION, 'SN' AS RESOLUCION, 'SN' AS FRASE1, ' ' AS NOSERIE, 'GUATEMALA' AS DESMUNICIPIO, 
                         COMMUNITY_CLIENTES_DOMICILIO.TELEFONOCLIENTE AS TELCLIENTE, 0 AS TOTALTARJETA, 0 AS RECARGOTARJETA
                        FROM COMMUNITY_DOCUMENTOS_DOMICILIO LEFT OUTER JOIN
                         COMMUNITY_DOCPRODUCTOS_DOMICILIO ON COMMUNITY_DOCUMENTOS_DOMICILIO.TOKEN = COMMUNITY_DOCPRODUCTOS_DOMICILIO.TOKEN AND 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.CORRELATIVO = COMMUNITY_DOCPRODUCTOS_DOMICILIO.CORRELATIVO AND 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.CODDOC = COMMUNITY_DOCPRODUCTOS_DOMICILIO.CODDOC AND COMMUNITY_DOCUMENTOS_DOMICILIO.ANIO = COMMUNITY_DOCPRODUCTOS_DOMICILIO.ANIO AND 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.EMPNIT = COMMUNITY_DOCPRODUCTOS_DOMICILIO.EMPNIT LEFT OUTER JOIN
                         COMMUNITY_CLIENTES_DOMICILIO ON COMMUNITY_DOCUMENTOS_DOMICILIO.TOKEN = COMMUNITY_CLIENTES_DOMICILIO.TOKEN AND 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.CODCLIENTE = COMMUNITY_CLIENTES_DOMICILIO.CODCLIENTE AND COMMUNITY_DOCUMENTOS_DOMICILIO.EMPNIT = COMMUNITY_CLIENTES_DOMICILIO.EMPNIT
                        WHERE (COMMUNITY_DOCUMENTOS_DOMICILIO.EMPNIT = @EMPNIT) AND (COMMUNITY_DOCUMENTOS_DOMICILIO.CODDOC = @CODDOC) AND (COMMUNITY_DOCUMENTOS_DOMICILIO.CORRELATIVO = @CORRELATIVO) AND 
                         (COMMUNITY_DOCUMENTOS_DOMICILIO.TOKEN = @TOKEN)"

                Dim cmdHost As New SqlCommand(sql, cnHost)
                cmdHost.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdHost.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmdHost.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                cmdHost.Parameters.AddWithValue("@TOKEN", Token)
                'cmdHost.Parameters.AddWithValue("@DIA", fecha.Day)
                'cmdHost.Parameters.AddWithValue("@MES", fecha.Month)
                'cmdHost.Parameters.AddWithValue("@ANIO", fecha.Year)


                Dim dr As SqlDataReader
                dr = cmdHost.ExecuteReader

                Do While dr.Read
                    tblTicket.Rows.Add(New Object() {
                                      Date.Parse(dr(0).ToString), 'FECHA
                                      dr(1).ToString,'coddoc
                                      Double.Parse(dr(2).ToString),'correlativo
                                      dr(3).ToString,'codprod
                                      dr(4).ToString,'desprod
                                      dr(5).ToString,'codmedida
                                      Double.Parse(dr(6)),'cantidad
                                      Double.Parse(dr(7)),'costo
                                      Double.Parse(dr(8)),'precio
                                      Integer.Parse(dr(9)),'codcliente
                                      dr(10).ToString,'nit
                                      dr(11).ToString,'nombrecliente
                                      dr(12).ToString,'dircliente
                                      Integer.Parse(dr(13)),'codven
                                      dr(14).ToString,'nomven
                                      Double.Parse(dr(15)),'totalcosto
                                      Double.Parse(dr(16)),'totalprecio
                                      dr(17).ToString,'empnombre
                                      Double.Parse(dr(18)),'pago
                                      Double.Parse(dr(19)),'vuelto
                                      Integer.Parse(dr(20)),'hora
                                      Integer.Parse(dr(21)),'minuto
                                      dr(22).ToString,  'CONCRE
                                      dr(23).ToString, 'AUTORIZACION
                                      dr(24).ToString, 'RESOLUCION
                                      dr(25).ToString, 'FRASE1
                                      fcn_verificanoserie(dr(26).ToString), 'noserie
                                      dr(27), 'DESMUNICIPIO
                                      dr(28)  'TELCLIENTE
                                                     })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmdHost.Dispose()
                'cnHost.Close()
            End Using


            Dim Adapter As New SqlDataAdapter
            Dim report As New rptEnvioCarta

            'CARGO PRIMERO EL REPORTE
            report.LoadLayout(Application.StartupPath + "\Reports\rptEnvioTicket.repx")

            report.DataSource = tblTicket
            report.DataAdapter = Adapter
            report.DataMember = "tblTicket"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            report.ShowPreview
            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        Return result

    End Function


    'REGRESA EL DATATABLE  DEL PEDIDO
    Public Function tblEnviosTicketHost(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal fecha As Date) As DataTable

        Dim tblTicket As New VENTASDataSet.tblTicketDataTable

        Try
            Using cnHost As New SqlConnection(strHostConectionString)
                If cnHost.State <> ConnectionState.Open Then
                    cnHost.Open()
                End If


                Dim sql As String
                'sql = "REPORTES_TEMP_TICKET"
                sql = "SELECT 
                        CONCAT(WEB_DOCUMENTOS.ANIO, '-',WEB_DOCUMENTOS.MES,'-',WEB_DOCUMENTOS.DIA) AS FECHA, 
                        WEB_DOCUMENTOS.CODDOC, 
                        WEB_DOCUMENTOS.CORRELATIVO, 
                        ISNULL(WEB_DOCPRODUCTOS.CODPROD, 'SN') AS CODPROD, 
                         ISNULL(WEB_DOCPRODUCTOS.DESPROD, 'SN') AS DESPROD, 
                        ISNULL(WEB_DOCPRODUCTOS.CODMEDIDA, 'SN') AS CODMEDIDA, 
                        ISNULL(WEB_DOCPRODUCTOS.CANTIDAD, 0) AS CANTIDAD, 
                         ISNULL(WEB_DOCPRODUCTOS.COSTO, 0) AS COSTO, 
                        ISNULL(WEB_DOCPRODUCTOS.PRECIO, 0) AS PRECIO, 
                        WEB_DOCUMENTOS.CODCLIENTE, 
                        CLIENTES.NIT AS DOC_NIT, 
                        CLIENTES.NOMCLIENTE AS DOC_NOMCLIE, 
                         CLIENTES.DIRCLIENTE AS DOC_DIRCLIE, 
                        WEB_DOCUMENTOS.CODVEN, 
                        VENDEDORES.NOMVEN, 
                        ISNULL(WEB_DOCPRODUCTOS.TOTALCOSTO, 0) AS TOTALCOSTO, 
                        ISNULL(WEB_DOCPRODUCTOS.TOTALPRECIO, 0) AS TOTALPRECIO, 
                        EMPRESAS.EMPNOMBRE, 
                        0 AS PAGO, 0 AS VUELTO, 
                        0 AS HORA, 0 AS MINUTO, 'CRE' AS CONCRE, 
                        'SN' AS AUTORIZACION, 'SN' AS RESOLUCION, 
                        'SN' AS FRASE1, ' ' AS NOSERIE, 
                         MUNICIPIOS.DESMUNICIPIO, 
                        CLIENTES.TELEFONOS AS TELCLIENTE, 
                        0 AS TOTALTARJETA, 0 AS RECARGOTARJETA, 
                        WEB_DOCPRODUCTOS.ID
                            FROM VENDEDORES RIGHT OUTER JOIN
                         WEB_DOCPRODUCTOS RIGHT OUTER JOIN
                         WEB_DOCUMENTOS ON WEB_DOCPRODUCTOS.DIA = WEB_DOCUMENTOS.DIA AND WEB_DOCPRODUCTOS.MES = WEB_DOCUMENTOS.MES AND WEB_DOCPRODUCTOS.ANIO = WEB_DOCUMENTOS.ANIO AND 
                         WEB_DOCPRODUCTOS.TOKEN = WEB_DOCUMENTOS.TOKEN AND WEB_DOCPRODUCTOS.EMPNIT = WEB_DOCUMENTOS.EMPNIT AND WEB_DOCPRODUCTOS.CODDOC = WEB_DOCUMENTOS.CODDOC AND 
                         WEB_DOCPRODUCTOS.CORRELATIVO = WEB_DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                         EMPRESAS ON WEB_DOCUMENTOS.TOKEN = EMPRESAS.TOKEN AND WEB_DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT ON VENDEDORES.TOKEN = WEB_DOCUMENTOS.TOKEN AND 
                         VENDEDORES.EMPNIT = WEB_DOCUMENTOS.EMPNIT AND VENDEDORES.CODVEN = WEB_DOCUMENTOS.CODVEN LEFT OUTER JOIN
                         CLIENTES ON WEB_DOCUMENTOS.TOKEN = CLIENTES.TOKEN AND WEB_DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND WEB_DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         MUNICIPIOS ON CLIENTES.CODMUNICIPIO = MUNICIPIOS.CODMUNICIPIO
                        WHERE 
                            (WEB_DOCUMENTOS.EMPNIT = @EMPNIT) 
                        AND (WEB_DOCUMENTOS.TOKEN = @TOKEN) 
                        AND (WEB_DOCUMENTOS.CODDOC = @CODDOC) 
                        AND (WEB_DOCUMENTOS.CORRELATIVO = @CORRELATIVO) 
                        AND (WEB_DOCUMENTOS.ANIO = @ANIO) 
                        AND (WEB_DOCUMENTOS.MES = @MES) 
                        AND (WEB_DOCUMENTOS.DIA = @DIA)"

                Dim cmdHost As New SqlCommand(sql, cnHost)
                cmdHost.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdHost.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmdHost.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                cmdHost.Parameters.AddWithValue("@TOKEN", Token)
                cmdHost.Parameters.AddWithValue("@DIA", fecha.Day)
                cmdHost.Parameters.AddWithValue("@MES", fecha.Month)
                cmdHost.Parameters.AddWithValue("@ANIO", fecha.Year)

                Dim dr As SqlDataReader
                dr = cmdHost.ExecuteReader

                Do While dr.Read
                    tblTicket.Rows.Add(New Object() {
                                      Date.Parse(dr(0).ToString), 'FECHA
                                      dr(1).ToString,'coddoc
                                      Double.Parse(dr(2).ToString),'correlativo
                                      dr(3).ToString,'codprod
                                      dr(4).ToString,'desprod
                                      dr(5).ToString,'codmedida
                                      Double.Parse(dr(6)),'cantidad
                                      Double.Parse(dr(7)),'costo
                                      Double.Parse(dr(8)),'precio
                                      Integer.Parse(dr(9)),'codcliente
                                      dr(10).ToString,'nit
                                      dr(11).ToString,'nombrecliente
                                      dr(12).ToString,'dircliente
                                      Integer.Parse(dr(31)),'codven -  ITEM ID
                                      dr(14).ToString,'nomven
                                      Double.Parse(dr(15)),'totalcosto
                                      Double.Parse(dr(16)),'totalprecio
                                      dr(17).ToString,'empnombre
                                      Double.Parse(dr(18)),'pago
                                      Double.Parse(dr(19)),'vuelto
                                      Integer.Parse(dr(20)),'hora
                                      Integer.Parse(dr(21)),'minuto
                                      dr(22).ToString,  'CONCRE
                                      dr(23).ToString, 'AUTORIZACION
                                      dr(24).ToString, 'RESOLUCION
                                      dr(25).ToString, 'FRASE1
                                      fcn_verificanoserie(dr(26).ToString), 'noserie
                                      dr(27), 'DESMUNICIPIO
                                      dr(28)  'TELCLIENTE
                                                     })
                Loop
                dr.Close()
                dr = Nothing
                cmdHost.Dispose()
                'cnHost.Close()
            End Using


        Catch ex As Exception
            GlobalDesError = ex.ToString
            tblTicket = Nothing
        End Try

        Return tblTicket

    End Function



    Public Sub Report_DocumentosCorte(ByVal empnit As String, ByVal NoCorte As Double)
        Try
            Call AbrirConexionSql()
            Dim tbl As New DataSetReportes.tblDocsCorteDataTable

            Dim cmd As New SqlCommand("SELECT EMPRESAS.EMPNOMBRE, CORTES.CORRELATIVO AS CORTENO, CORTES.FECHA, CORTES.FALTANTE, CORTES.SOBRANTE, CORTES.OBS, TIPODOCUMENTOS.TIPODOC, DOCUMENTOS.CODDOC, 
                         DOCUMENTOS.CORRELATIVO AS NOFACTURA, DOCUMENTOS.FECHA AS FECHADOC, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS CLIENTE,
                               CASE 
                                  WHEN TIPODOCUMENTOS.TIPODOC='FNC' THEN (DOCUMENTOS.TOTALPRECIO * -1)
                                  WHEN TIPODOCUMENTOS.TIPODOC='DEV' THEN (DOCUMENTOS.TOTALPRECIO * -1)  
                               ELSE DOCUMENTOS.TOTALPRECIO
                               END AS IMPORTE, 
                        DOCUMENTOS.USUARIO, 
                        DOCUMENTOS.PAGO, 
                        DOCUMENTOS.VUELTO, 
                        DOCUMENTOS.RECARGOTARJETA, 
                        (DOCUMENTOS.TOTALPRECIO + ISNULL(DOCUMENTOS.RECARGOTARJETA,0)) AS TOTALPAGADO
                            FROM TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT RIGHT OUTER JOIN
                         CORTES LEFT OUTER JOIN
                         EMPRESAS ON CORTES.EMPNIT = EMPRESAS.EMPNIT ON DOCUMENTOS.NOCORTE = CORTES.CORRELATIVO AND DOCUMENTOS.EMPNIT = CORTES.EMPNIT
                    WHERE        (CORTES.EMPNIT = @empnit) AND (CORTES.CORRELATIVO = @nocorte)
                    ORDER BY DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO", cn)
            'cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@nocorte", NoCorte)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(tbl)
            da.Dispose()

            objReports.fcn_CargarReporte(New rpt_DocumentosCorte, "NO", "tblDocsCorte", tbl)

            cn.Close()
        Catch ex As Exception
            'MsgBox(ex.ToString)
            Exit Sub
        End Try

    End Sub

    Public Sub Report_ProductosCorte(ByVal empnit As String, ByVal NoCorte As Double)
        Try
            Call AbrirConexionSql()

            Dim tbl As New DS_CorteCaja.tblProductosCorteDataTable

            Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS TOTALUNIDADES, 
                         SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) TOTALPRECIO, DOCUMENTOS.NOCORTE, DOCUMENTOS.FECHA
FROM            TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT
GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCUMENTOS.NOCORTE, DOCUMENTOS.EMPNIT, TIPODOCUMENTOS.TIPODOC, DOCUMENTOS.CONCRE, DOCUMENTOS.FECHA
HAVING        (DOCUMENTOS.NOCORTE = @NOCORTE) AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF', 'FEC', 'FNC', 'DEV')) AND (DOCUMENTOS.CONCRE = 'CON')
ORDER BY DOCPRODUCTOS.DESPROD", cn)

            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@NOCORTE", NoCorte)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(tbl)
            da.Dispose()

            objReports.fcn_CargarReporte(New rptCorteProductos, "NO", "tblProductosCorte", tbl)

            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

    End Sub


    Public Function TblMovinCorte(ByVal empnit As String, ByVal NoCorte As Double) As DataTable

        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        '' AS RUTA, '' AS SUBRUTA, REPLACE(REPLACE(EMPRESAS.EMPNOMBRE, 'FARMACIA_SALUD_', ''), '_VILLANUEVA', '') AS EMPNOMBRE, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRECIOS.CODMEDIDA AS MEDIDA, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, 
                         INVSALDO.SALDO AS EXISTENCIA, '' AS DESPACHO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS TPRECIO
FROM            PRECIOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRECIOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRECIOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         EMPRESAS ON DOCPRODUCTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                         INVSALDO ON DOCPRODUCTOS.CODPROD = INVSALDO.CODPROD AND DOCPRODUCTOS.EMPNIT = INVSALDO.EMPNIT RIGHT OUTER JOIN
                         TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND 
                         DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
WHERE        (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (PRECIOS.EQUIVALE = 1) AND (DOCUMENTOS.NOCORTE = @NOCORTE) AND NOT(EMPRESAS.EMPNIT LIKE 'BACKU%')
GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, INVSALDO.SALDO, EMPRESAS.EMPNOMBRE, PRECIOS.CODMEDIDA
ORDER BY DOCPRODUCTOS.DESPROD", cn)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@NOCORTE", NoCorte)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Sub Report_ProductosCorteEXISTENCIAS(ByVal empnit As String, ByVal NoCorte As Double, ByVal reimp As Double)
        Try
            Call AbrirConexionSql()

            Dim tbl As New DS_CorteCaja.tblProductosCorteEXISTENCIADataTable

            Dim cmd As New SqlCommand("SELECT        DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS TOTALUNIDADES, 
                        SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS TOTALPRECIO, INVSALDO.SALDO, DOCUMENTOS.NOCORTE, 
                         DOCUMENTOS.FECHA
FROM            INVSALDO RIGHT OUTER JOIN
                         DOCPRODUCTOS ON INVSALDO.CODPROD = DOCPRODUCTOS.CODPROD AND INVSALDO.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND 
                         DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCUMENTOS.NOCORTE, DOCUMENTOS.EMPNIT, TIPODOCUMENTOS.TIPODOC, DOCUMENTOS.CONCRE, INVSALDO.SALDO, DOCUMENTOS.FECHA
HAVING        (DOCUMENTOS.NOCORTE = @NOCORTE) AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF', 'FEC', 'FNC', 'DEV')) AND (DOCUMENTOS.CONCRE = 'CON')", cn)

            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@NOCORTE", NoCorte)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(tbl)
            da.Dispose()


            If reimp = 1 Then

                objReports.fcn_CargarReporteExis(New rptCorteProductosExis, "NO", "tblProductosCorte", tbl)
            Else

                objReports.fcn_ExportarReporte(New rptCorteProductosExis, "NO", "tblProductosCorte", tbl)

            End If

            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
            Exit Sub
        End Try

    End Sub

    'TICKET / FACTURA

    ''' <summary>
    ''' Imprime el ticket de compra o formato de impresión de factura
    ''' </summary>
    ''' <param name="Fecha"></param>
    ''' <param name="Coddoc"></param>
    ''' <param name="Correlativo"></param>
    ''' <param name="Imp"></param>
    ''' <returns>true o false</returns>
    Public Function AbrirReporte_Ticket(ByVal Fecha As Date, ByVal Coddoc As String, ByVal Correlativo As Double, ByVal Imp As Integer, Optional anulado As Boolean = False) As Boolean

        Dim result As Boolean

        If SelectedForm = "VENTAS" Or SelectedForm = "LISTADOS" Then
            If Imp <> 0 Then
                GoTo PROCEDE
            Else
                Return True
                Exit Function
            End If
        End If


PROCEDE:
        Dim formato As String = "SN"

        Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
        formato = objTipoDoc.getFormatoDocumento(Coddoc)

        Dim tblTicket As New VENTASDataSet.tblTicketDataTable

        Try

            TotalVentaFAC = 0

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim qry As String = "SELECT 
                        DOCUMENTOS.FECHA, 
                        DOCUMENTOS.CODDOC, 
                        DOCUMENTOS.CORRELATIVO, 
						DOCPRODUCTOS.CODPROD, 
						CASE PRODUCTOS.EXENTO WHEN 0 THEN DOCPRODUCTOS.DESPROD ELSE CONCAT('*',DOCPRODUCTOS.DESPROD) END AS DESPROD, 
						DOCPRODUCTOS.CODMEDIDA, 
                        DOCPRODUCTOS.CANTIDAD, 
                        DOCPRODUCTOS.COSTO, 
                        DOCPRODUCTOS.PRECIO, 
                        DOCUMENTOS.CODCLIENTE, 
                        DOCUMENTOS.DOC_NIT, 
                        DOCUMENTOS.DOC_NOMCLIE, 
                        CLIENTES.DIRCLIENTE AS DOC_DIRCLIE, 
                        DOCUMENTOS.CODVEN, 
                        EMPLEADOS.NOMEMPLEADO AS NOMVEN, 
                        DOCPRODUCTOS.TOTALCOSTO,    
                        DOCPRODUCTOS.TOTALPRECIO, 
                        EMPRESAS.EMPNOMBRE, 
                        DOCUMENTOS.PAGO, 
                        DOCUMENTOS.VUELTO, 
                        DOCUMENTOS.HORA, DOCUMENTOS.MINUTO, DOCUMENTOS.CONCRE, 
                        ISNULL(TIPODOCUMENTOS.AUTORIZACION, 'SN') AS AUTORIZACION, 
                        ISNULL(TIPODOCUMENTOS.RESOLUCION, 'SN') AS RESOLUCION, 
                        ISNULL(TIPODOCUMENTOS.FRASE1, 'SN') AS FRASE1, 
                        ISNULL(DOCPRODUCTOS.OBS, ' ') AS NOSERIE, 
                        MUNICIPIOS.DESMUNICIPIO, 
                        ISNULL(CLIENTES.TELEFONOCLIENTE, 'SN') AS TELCLIENTE, 
                        ISNULL(DOCUMENTOS.TOTALTARJETA, 0) AS TOTALTARJETA, 
                        ISNULL(DOCUMENTOS.RECARGOTARJETA, 0) AS RECARGOTARJETA, 
                        ISNULL(DOCUMENTOS.DIRENTREGA, 'SN') AS DIRENTREGA, 
                        ISNULL(DOCPRODUCTOS.EXENTO, 0) AS EXENTO, 
                        ISNULL(DOCUMENTOS.OBS, 'SN') AS OBS, 
                        DOCUMENTOS.VENCIMIENTO, 
                        DOCUMENTOS.DIASCREDITO, 
                        ISNULL(DOCPRODUCTOS.DESCUENTO,0) AS DESCUENTO,
                        ISNULL(DOCUMENTOS.TIPOVENTA, 'SN') AS TIPOVENTA,
                        ISNULL(DOCUMENTOS.IDENTIFICADOR, 'SN') AS IDENTIFICADOR
                    FROM PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         EMPLEADOS RIGHT OUTER JOIN
                         DOCUMENTOS ON EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN AND EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         MUNICIPIOS RIGHT OUTER JOIN
                         CLIENTES ON MUNICIPIOS.CODMUNICIPIO = CLIENTES.CODMUNICIPIO ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND 
                         DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                         DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO
                    WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (DOCUMENTOS.DIA = @DIA) AND (DOCUMENTOS.CODDOC = @CODDOC) AND 
                         (DOCUMENTOS.CORRELATIVO = @CORRELATIVO)"
                Dim cmd As New SqlCommand(qry, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Fecha.Year)
                cmd.Parameters.AddWithValue("@MES", Fecha.Month)
                cmd.Parameters.AddWithValue("@DIA", Fecha.Day)
                cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tblTicket.Rows.Add(New Object() {
                                     Date.Parse(dr(0).ToString),'fecha
                                  dr(1).ToString,'coddoc
                                  Double.Parse(dr(2).ToString),'correlativo
                                  dr(3).ToString,'codprod
                                  dr(4).ToString,'desprod
                                  dr(5).ToString,'codmedida
                                  Double.Parse(dr(6)),'cantidad
                                  Double.Parse(dr(7)),'costo
                                  Double.Parse(dr(8)),'precio
                                  Integer.Parse(dr(9)),'codcliente
                                  dr(10).ToString,'nit
                                  dr(11).ToString,'nombrecliente
                                  dr(12).ToString,'dircliente
                                  Integer.Parse(dr(13)),'codven
                                  dr(14).ToString,'nomven
                                  Double.Parse(dr(15)),'totalcosto
                                  Double.Parse(dr(16)),'totalprecio
                                  dr(17).ToString,'empnombre
                                  Double.Parse(dr(18)),'pago
                                  Double.Parse(dr(19)),'vuelto
                                  Integer.Parse(dr(20)),'hora
                                  Integer.Parse(dr(21)),'minuto
                                  dr(22).ToString,  'CONCRE
                                 GlobalSelectedFEL_SERIE,'  dr(23).ToString, 'AUTORIZACION
                                 GlobalSelectedFEL_NUMERO, 'dr(24).ToString, 'RESOLUCION
                                 GlobalSelectedFEL_UUDI,' dr(25).ToString, 'FRASE1
                                  fcn_verificanoserie(dr(26).ToString), 'noserie
                                  dr(27), 'DESMUNICIPIO
                                  dr(28),  'TELCLIENTE
                                  Double.Parse(dr(29)), 'TOTALTARJETA
                                  Double.Parse(dr(30)), 'RECARGOTARJETA
                                  dr(31).ToString, 'DIRECCION DE ENTREGA
                                  Double.Parse(dr(32)), 'MONTO EXENTO EN DOCPRODUCTOS
                                  dr(33).ToString(),    'OBSERVACIONES
                                  Fecha.Day.ToString,'FECHA DD 
                                  Fecha.Month.ToString, 'FECHA MM
                                  Fecha.Year.ToString, 'FECHA YY
                                  Date.Parse(dr(34)), 'FECHA VENCE
                                  Integer.Parse(dr(35)), 'DIAS CREDITO
                                  "SN",   'DOCUMENTO
                                  Double.Parse(dr(36)),  'DESCUENTO
                                  dr(37), 'TIPOVENTA
                                  dr(38)  'IDENTIFICADOR
                                                                     })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmd.Dispose()
                'cn.Close()
            End Using

            Dim Adapter As New SqlDataAdapter
            Dim report As New XtraReportTICKET

            report.LoadLayout(Application.StartupPath + "\Reports\" + formato + ".repx")

            report.DataSource = tblTicket
            report.DataAdapter = Adapter
            report.DataMember = "tblTicket"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()


            Select Case Imp
                Case 1
                    report.Print
                Case 2
                    report.ShowPreview
            End Select

            result = True


        Catch ex As Exception
            GlobalDesError = ex.ToString

        End Try

        Return result

    End Function



    'FORMATO PARA LOS ENVIOS

    ''' <summary>
    ''' Imprime el ticket de compra o formato de impresión de factura
    ''' </summary>
    ''' <param name="Fecha"></param>
    ''' <param name="Coddoc"></param>
    ''' <param name="Correlativo"></param>
    ''' <param name="Imp"></param>
    ''' <returns>true o false</returns>
    Public Function rptEnviosTicket(ByVal Fecha As Date, ByVal Coddoc As String, ByVal Correlativo As Double, ByVal Imp As Integer) As Boolean

        Dim result As Boolean

        If Imp <> 0 Then
            GoTo PROCEDE
        Else
            Return True
                Exit Function
            End If


PROCEDE:


        Dim tblTicket As New VENTASDataSet.tblTicketDataTable

        Try


            TotalVentaFAC = 0

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(objQuerys.queryTicket, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Fecha.Year)
                cmd.Parameters.AddWithValue("@MES", Fecha.Month)
                cmd.Parameters.AddWithValue("@DIA", Fecha.Day)
                cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tblTicket.Rows.Add(New Object() {
                                     Date.Parse(dr(0).ToString),'fecha
                                  dr(1).ToString,'coddoc
                                  Double.Parse(dr(2).ToString),'correlativo
                                  dr(3).ToString,'codprod
                                  dr(4).ToString,'desprod
                                  dr(5).ToString,'codmedida
                                  Double.Parse(dr(6)),'cantidad
                                  Double.Parse(dr(7)),'costo
                                  Double.Parse(dr(8)),'precio
                                  Integer.Parse(dr(9)),'codcliente
                                  dr(10).ToString,'nit
                                  dr(11).ToString,'nombrecliente
                                  dr(12).ToString,'dircliente
                                  Integer.Parse(dr(13)),'codven
                                  dr(14).ToString,'nomven
                                  Double.Parse(dr(15)),'totalcosto
                                  Double.Parse(dr(16)),'totalprecio
                                  dr(17).ToString,'empnombre
                                  Double.Parse(dr(18)),'pago
                                  Double.Parse(dr(19)),'vuelto
                                  Integer.Parse(dr(20)),'hora
                                  Integer.Parse(dr(21)),'minuto
                                  dr(22).ToString,  'CONCRE
                                  dr(23).ToString, 'AUTORIZACION
                                  dr(24).ToString, 'RESOLUCION
                                  dr(25).ToString, 'FRASE1
                                  fcn_verificanoserie(dr(26).ToString), 'noserie
                                  dr(27), 'DESMUNICIPIO
                                  dr(28)  'TELCLIENTE
                                                 })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmd.Dispose()
                'cn.Close()
            End Using

            If Form1.SwitchConfigFormatoCorte.IsOn = True Then
                Dim Adapter As New SqlDataAdapter
                Dim report As New rptEnvio

                'CARGO PRIMERO EL REPORTE
                report.LoadLayout(Application.StartupPath + "\Reports\rptEnvioTicket.repx")

                report.DataSource = tblTicket
                report.DataAdapter = Adapter
                report.DataMember = "tblTicket"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()


                Select Case Imp
                    Case 1
                        report.Print
                    Case 2
                        report.ShowPreview
                End Select

                result = True

            Else

                Dim Adapter As New SqlDataAdapter
                Dim report As New rptEnvioCarta

                report.LoadLayout(Application.StartupPath + "\Reports\rptEnvioTicket.repx")

                report.DataSource = tblTicket
                report.DataAdapter = Adapter
                report.DataMember = "tblTicket"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()


                Select Case Imp
                        Case 1
                            report.Print
                        Case 2
                            report.ShowPreview
                    End Select
                End If

                result = True


        Catch ex As Exception
            GlobalDesError = ex.ToString

        End Try

        Return result

    End Function

    Private Function fcn_verificanoserie(ByVal noserie As String) As String
        If noserie = "SN" Then
            Return " "
        Else
            Return noserie
        End If
    End Function

    'VALE DE GASTOS
    Public Sub AbrirReporte_ValeGasto(ByVal Fecha As Date, ByVal Correlativo As Double)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblValeGasto As New DataTable("tblValeGasto")

        With tblValeGasto
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("TIPOGASTO", GetType(String))
            .Columns.Add("DESGASTO", GetType(String))
            .Columns.Add("IMPORTE", GetType(Double))
            .Columns.Add("USUARIO", GetType(String))
        End With

        Dim cmd As New SqlCommand("SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CORRELATIVO, TIPOGASTOS.DESTIPOGASTO, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.TOTALPRECIO,DOCUMENTOS.USUARIO
                            FROM DOCUMENTOS LEFT OUTER JOIN
                            DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.MES = DOCPRODUCTOS.MES AND 
                            DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                            TIPOGASTOS ON DOCPRODUCTOS.CODMEDIDA = TIPOGASTOS.CODMEDIDA
                            WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.CODDOC=@CODDOC) AND (DOCUMENTOS.CORRELATIVO = @CORRELATIVO)", cn)

        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
        cmd.Parameters.AddWithValue("@CODDOC", "GASTOS")

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            tblValeGasto.Rows.Add(New Object() {
                          Date.Parse(dr(0)),'FECHA
                          Double.Parse(dr(1).ToString),'CORRELATIVO
                          dr(2).ToString,'TIPOGASTO
                          dr(3).ToString,'DESGASTO
                          Double.Parse(dr(4)),'IMPORTE
                          dr(5).ToString'USUARIO
                          })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New xtraReportValeGasto

        report.DataSource = tblValeGasto
        report.DataAdapter = Adapter
        report.DataMember = "tblValeGasto"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        ' report.XrChart1.DataSource = tblVtaDoc
        'report.XrChart1.DataMember = "tblVtaDoc"

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview
    End Sub

    'Listado de Saldos de Clientes por Grupo
    Public Sub AbrirReporte_SaldosGrupo(ByVal Anio As Integer, ByVal Mes As Integer, ByVal CODRUTA As Integer)

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tblCxC As New DataTable
        With tblCxC.Columns
            .Add("GRUPO", GetType(String))
            .Add("MES", GetType(Integer))
            .Add("ANIO", GetType(Integer))
            .Add("NITCLIE", GetType(String))
            .Add("NOMCLIE", GetType(String))
            .Add("CREDITOS", GetType(Double))
            .Add("ABONOS", GetType(Double))
            .Add("SALDO", GetType(Double))
        End With

        Call AbrirConexionSql()

        Dim cmd As New SqlCommand("REPORTES_BI_SALDOSGRUPO", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", Anio)
        cmd.Parameters.AddWithValue("@MES", Mes)
        cmd.Parameters.AddWithValue("@CODRUTA", CODRUTA)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Do While dr.Read
            Try
                tblCxC.Rows.Add(New Object() {
                    dr(0).ToString,'grupo
                    Integer.Parse(dr(1)),'anio
                    Integer.Parse(dr(2)),'mes
                    dr(3).ToString,'nitclie
                    dr(4).ToString,'nomclie
                    Double.Parse(dr(5)),'creditos
                    Double.Parse(dr(6)),'abonos
                    Double.Parse(dr(7))'saldo
                                          })
            Catch ex As Exception
            End Try
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportSaldoClientes

        report.DataSource = tblCxC
        report.DataAdapter = Adapter
        report.DataMember = "tblCxC"
        'report.LoadLayout(Application.StartupPath + "\Reports\VENTADIACLASEDOS.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview

    End Sub

    'kardex
    Public Sub AbrirReporte_Kardex(ByVal Codprod As String, ByVal Anio As Integer)

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        'Call ObtenerDatosInventario(Codprod, Anio, Integer.Parse(Form1.cmdMesProceso.SelectedValue))
        Call ObtenerDatosInventario(Codprod, GlobalAnioProceso, GlobalMesProceso)
        Dim tblKardex As New DataTable
        With tblKardex.Columns
            .Add("CODPROD", GetType(String))
            .Add("DESPROD", GetType(String))
            .Add("DESMARCA", GetType(String))
            .Add("CODDOC", GetType(String))
            .Add("CORRELATIVO", GetType(Double))
            .Add("ENTRADAS", GetType(Double))
            .Add("SALIDAS", GetType(Double))
            .Add("FECHA", GetType(Date))
            .Add("MES", GetType(Integer))
            .Add("ANIO", GetType(Integer))
            .Add("USUARIO", GetType(String))
            .Add("EXISTENCIA", GetType(Double))
        End With

        Call AbrirConexionSql()

        Dim qry As String
        qry = "SELECT DOCPRODUCTOS.CODPROD, PRODUCTOS.DESPROD, MARCAS.DESMARCA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCPRODUCTOS.TOTALUNIDADES, DOCUMENTOS.FECHA, 
                         DOCUMENTOS.MES, DOCUMENTOS.ANIO, EMPLEADOS.NOMEMPLEADO AS USUARIO, TIPODOCUMENTOS.TIPODOC, ISNULL(DOCPRODUCTOS.TOTALBONIF,0) AS TOTALBONIF
               FROM PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD LEFT OUTER JOIN
                         MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA LEFT OUTER JOIN
                         DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND 
                         DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                         DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC <> 'ENV') AND (DOCPRODUCTOS.CODPROD = @CODPROD) AND (DOCUMENTOS.ANIO BETWEEN 
                         @ANIOINICIAL AND @ANIOFINAL)
                ORDER BY DOCUMENTOS.ID"

        Dim cmd As New SqlCommand(qry, cn)

        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIOINICIAL", Anio)
        cmd.Parameters.AddWithValue("@ANIOFINAL", Anio)
        cmd.Parameters.AddWithValue("@CODPROD", Codprod)

        Dim dr As SqlDataReader = cmd.ExecuteReader
        Do While dr.Read
            Try
                tblKardex.Rows.Add(New Object() {
                dr(0).ToString,'codprod
                dr(1).ToString,'desprod
                dr(2).ToString,'desmarca
                getTipoDocumento(dr(3).ToString, dr(10).ToString, CType(dr(11), Double), CType(dr(5), Double)), 'coddoc
                Double.Parse(dr(4)),'correlativo
                ObtenerEntrada(dr(10).ToString, Double.Parse(dr(5))),'entradas
                ObtenerSalida(dr(10).ToString, Double.Parse(dr(5))),'salidas
                Date.Parse(dr(6)),'fecha
                Integer.Parse(dr(7)),'mes
                Integer.Parse(dr(8)), 'anio  
                dr(9).ToString,'usuario               
                INVSaldo 'existencia actual
                                })
            Catch ex As Exception
            End Try
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportKardex

        report.DataSource = tblKardex
        report.DataAdapter = Adapter
        report.DataMember = "tblkardex"
        ' report.LoadLayout(Application.StartupPath + "\Reports\VENTADIACLASEDOS.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        SplashScreenManager.CloseForm()

        report.ShowPreview

    End Sub


    Public Function ExportarReporte_Kardex(ByVal Codprod As String, ByVal fechaInicial As Date, ByVal fechaFinal As Date) As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try

            Call ObtenerDatosInventario(Codprod, GlobalAnioProceso, GlobalMesProceso)

            Dim tblKardex As New DataTable
            With tblKardex.Columns
                .Add("FECHA", GetType(Date))
                .Add("CODPROD", GetType(String))
                .Add("NOMBRE DEL PRODUCTO", GetType(String))
                .Add("MARCA", GetType(String))
                .Add("DOCUMENTO", GetType(String))
                .Add("CORRELATIVO", GetType(Double))
                .Add("ENTRADAS", GetType(Double))
                .Add("SALIDAS", GetType(Double))
                .Add("VENDEDOR", GetType(String))
                .Add("EXISTENCIA", GetType(Double))
            End With

            Call AbrirConexionSql()

            Dim qry As String
            qry = "SELECT           DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, PRODUCTOS.DESPROD AS [NOMBRE DEL PRODUCTO], MARCAS.DESMARCA AS MARCA, DOCUMENTOS.CODDOC AS DOCUMENTO, DOCUMENTOS.CORRELATIVO, 
                                    DOCPRODUCTOS.TOTALUNIDADES, EMPLEADOS.NOMEMPLEADO AS USUARIO, TIPODOCUMENTOS.TIPODOC, ISNULL(DOCPRODUCTOS.TOTALBONIF, 0) AS TOTALBONIF
                   FROM             PRODUCTOS RIGHT OUTER JOIN
                                    DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD LEFT OUTER JOIN
                                    MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA LEFT OUTER JOIN
                                    DOCUMENTOS LEFT OUTER JOIN
                                    EMPLEADOS ON DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND 
                                    DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                                    DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                                    TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                   WHERE            (DOCUMENTOS.EMPNIT = @EM) AND (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC <> 'ENV') AND (DOCPRODUCTOS.CODPROD = @COD) AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF)
                   ORDER BY         DOCUMENTOS.FECHA"

            Dim cmd As New SqlCommand(qry, cn)
            cmd.Parameters.AddWithValue("@EM", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@FI", GlobalParamDatePickI)
            cmd.Parameters.AddWithValue("@FF", GlobalParamDatePickF)
            cmd.Parameters.AddWithValue("@COD", Codprod)

            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                Try
                    tblKardex.Rows.Add(New Object() {
                    Date.Parse(dr(0)),'fecha
                    dr(1).ToString,'codprod
                    dr(2).ToString,'nombre del producto
                    dr(3).ToString,'marca
                    getTipoDocumento(dr(4).ToString, dr(8).ToString, CType(dr(9), Double), CType(dr(6), Double)), 'documento
                    Double.Parse(dr(5)),'correlativo
                    ObtenerEntrada(dr(8).ToString, Double.Parse(dr(6))),'entradas
                    ObtenerSalida(dr(8).ToString, Double.Parse(dr(6))),'salidas  
                    dr(7).ToString,'usuario               
                    INVSaldo 'existencia actual
                                    })
                Catch ex As Exception
                End Try
            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

            SplashScreenManager.CloseForm()

            Return tblKardex


        Catch ex As Exception
            SplashScreenManager.CloseForm()
            GlobalDesError = ex.ToString
            MsgBox(GlobalDesError)
            Return Nothing

        End Try



    End Function

    'determina si fue inventario físico para agregar al coddoc el conteo
    Private Function getTipoDocumento(ByVal doc As String, ByVal tipodoc As String, ByVal conteo As Double, ByVal totalunidades As Double) As String
        If tipodoc = "INF" Then
            Dim sistema As Double = conteo - totalunidades
            Return doc + " Cont: " + conteo.ToString + " // Sist: " + sistema.ToString
        Else
            Return doc
        End If
    End Function

    Private Function ObtenerEntrada(ByVal TipoDoc As String, ByVal TotalUnidades As Double) As Double
        Select Case TipoDoc
            Case "INF"
                If TotalUnidades > 0 Then
                    Return TotalUnidades
                Else
                    Return 0
                End If
            Case "DEV"
                Return TotalUnidades
            Case "FAC"
                Return 0
            Case "FEF"
                Return 0
            Case "FEC"
                Return 0
            Case "FES"
                Return 0
            Case "FNC"
                Return TotalUnidades
            Case "COM"
                Return TotalUnidades
            Case "ENT"
                Return TotalUnidades
            Case "SAL"
                Return 0
            Case "TSL"
                Return 0
            Case "TIN"
                Return TotalUnidades
            Case "TES"
                Return TotalUnidades
            Case "TSS"
                Return 0
            Case "ORP"
                If TotalUnidades > 0 Then
                    Return TotalUnidades
                Else
                    Return 0
                End If

        End Select
    End Function

    Private Function ObtenerSalida(ByVal TipoDoc As String, ByVal TotalUnidades As Double) As Double
        Select Case TipoDoc
            Case "INF"
                If TotalUnidades > 0 Then
                    Return 0
                Else
                    Return TotalUnidades * -1
                End If
            Case "DEV"
                Return 0
            Case "FAC"
                Return TotalUnidades
            Case "FEF"
                Return TotalUnidades
            Case "FEC"
                Return TotalUnidades
            Case "FES"
                Return TotalUnidades
            Case "FNC"
                Return 0
            Case "COM"
                Return 0
            Case "ENT"
                Return 0
            Case "SAL"
                Return TotalUnidades
            Case "TIN"
                Return 0
            Case "TSL"
                Return TotalUnidades
            Case "TES"
                Return 0
            Case "TSS"
                Return TotalUnidades
            Case "ORP"
                If TotalUnidades < 0 Then
                    Return TotalUnidades * -1
                Else
                    Return 0
                End If
        End Select

    End Function

    'COSTOS POR PROVEEDOR - PRODUCTO

    ''' <summary>
    ''' Reporte de costos por producto
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="anio"></param>
    ''' <param name="codprod"></param>
    ''' <returns></returns>
    Public Function Report_CostosProducto(ByVal empnit As String, ByVal anio As Integer, ByVal codprod As String) As Boolean

        Dim result As Boolean

        Dim tbl As New DataSetReportes.tblRptCostosProveedorDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT       DOCPRODUCTOS.CODPROD, PRODUCTOS.DESPROD, DOCUMENTOS.FECHA, ISNULL(PROVEEDORES.CODPROV, 0) AS CODPROV, ISNULL(PROVEEDORES.EMPRESA, 'VARIOS') AS EMPRESA, PROVEEDORES.DIRECCION, 
                         DOCPRODUCTOS.CODMEDIDA, DOCPRODUCTOS.CANTIDAD, DOCPRODUCTOS.COSTO, DOCPRODUCTOS.TOTALCOSTO
                        FROM            TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         PROVEEDORES ON DOCUMENTOS.CODCLIENTE = PROVEEDORES.CODPROV AND DOCUMENTOS.EMPNIT = PROVEEDORES.EMPNIT LEFT OUTER JOIN
                         PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND 
                         DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.MES = DOCPRODUCTOS.MES AND DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                         DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                WHERE        (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS <> 'A') AND (DOCPRODUCTOS.CODPROD = @CODPROD) AND (DOCUMENTOS.ANIO = @ANIO) AND (TIPODOCUMENTOS.TIPODOC = 'COM')", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
                result = True

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()

        End Using

        Dim Adapter As New SqlDataAdapter
        Dim report As New rpt_costos_proveedor

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "RptCostosProveedor"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

        Return result
    End Function

    'VENTAS POR DOCUMENTO
    Public Sub AbrirReporte_VentasDocumento(ByVal FechaInicial As Date, ByVal FechaFinal As Date)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        GlobalNomFac = "Cliente"
        GlobalVendFac = "Vendedor"
        GlobalTituloReporte = "Listado de Ventas por Fechas"

        Call AbrirConexionSql()

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
        End With

        'Dim cmd As New SqlCommand("REPORTES_BI_VENTADOC", cn)
        Dim qryrpt As String = "SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.DOC_DIRCLIE, DOCUMENTOS.CONCRE, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, VENDEDORES.NOMVEN, ISNULL(DOCUMENTOS.TOTALEXENTO,0) AS TOTALEXENTO
                        FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER JOIN VENDEDORES ON DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO BETWEEN @ANIOINICIAL AND @ANIOFINAL) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FES','FEC')) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) and (DOCUMENTOS.STATUS<>'A')
                        ORDER BY DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC,DOCUMENTOS.CORRELATIVO ASC"

        Dim cmd As New SqlCommand(qryrpt, cn)
        'cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIOINICIAL", FechaInicial.Year)
        cmd.Parameters.AddWithValue("@ANIOFINAL", FechaFinal.Year)
        cmd.Parameters.AddWithValue("@FECHAINICIAL", FechaInicial)
        cmd.Parameters.AddWithValue("@FECHAFINAL", FechaFinal)
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
                          Double.Parse(dr(8)) - Double.Parse(dr(10))   'TOTALAFECTO
                          })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportVentaDocumento

        report.DataSource = tblVtaDoc
        report.DataAdapter = Adapter
        report.DataMember = "tblVtaDoc"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        ' report.XrChart1.DataSource = tblVtaDoc
        'report.XrChart1.DataMember = "tblVtaDoc"

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'VENTAS DEL CLIENTE
    Public Sub AbrirReporte_VentasCliente(ByVal Anio As Integer, ByVal CodClie As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblVtaClie As New DataTable("tblVtaDoc")

        With tblVtaClie
            .Columns.Add("ANIO", GetType(Integer))
            .Columns.Add("NIT", GetType(String))
            .Columns.Add("NOMCLIE", GetType(String))
            .Columns.Add("DIRCLIE", GetType(String))
            .Columns.Add("TELCLIE", GetType(String))
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("CONCRE", GetType(String))
            .Columns.Add("VENDEDOR", GetType(String))
        End With

        Dim cmd As New SqlCommand("REPORTES_BI_VENTACLIE", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", Anio)
        cmd.Parameters.AddWithValue("@CODCLIE", CodClie)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            tblVtaClie.Rows.Add(New Object() {
                          Integer.Parse(dr(0)),'ANIO
                          dr(1).ToString,'NIT
                          dr(2).ToString,'NOMCLIE
                          dr(3).ToString,'DIRCLIE
                          dr(4).ToString,'TELCLIE
                          Date.Parse(dr(5)),'FECHA
                          dr(6).ToString,'CODDOC
                          Double.Parse(dr(7).ToString),'CORRELATIVO
                          Double.Parse(dr(8)),'TOTALVENTA
                          dr(9).ToString,'CONCRE
                          dr(10).ToString'VENDEDOR
                          })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportVentasCliente

        report.DataSource = tblVtaClie
        report.DataAdapter = Adapter
        report.DataMember = "tblVtaClie"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        ' report.XrChart1.DataSource = tblVtaDoc
        'report.XrChart1.DataMember = "tblVtaDoc"

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'VENTAS POR PRODUCTO
    Public Sub AbrirReporte_VentasProductos(ByVal FechaInicial As Date, ByVal FechaFinal As Date)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblVtaProductos As New DataTable("tblVtaProductos")

        With tblVtaProductos
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("UXC", GetType(Integer))
            .Columns.Add("TOTALUNIDADES", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("UTILIDAD", GetType(Double))
            .Columns.Add("MARGEN", GetType(Double))
        End With

        'Dim cmd As New SqlCommand("REPORTES_BI_VENTAPRODUCTOS", cn)
        Dim cmd As New SqlCommand("SELECT  DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, 
                         SUM(DOCPRODUCTOS.TOTALPRECIO) AS PRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD, (SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO)) / SUM(DOCPRODUCTOS.TOTALCOSTO) AS MARGEN
                        FROM PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                         DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                        WHERE (DOCUMENTOS.ANIO BETWEEN @ANIOINICIAL AND @ANIOFINAL) AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.MES BETWEEN @MESINICIAL AND @MESFINAL) AND 
                         (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES') ) AND (DOCUMENTOS.STATUS<>'A')
                        GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC
                        ORDER BY DOCPRODUCTOS.DESPROD", cn)
        'cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIOINICIAL", FechaInicial.Year)
        cmd.Parameters.AddWithValue("@MESINICIAL", FechaInicial.Month)
        cmd.Parameters.AddWithValue("@ANIOFINAL", FechaFinal.Year)
        cmd.Parameters.AddWithValue("@MESFINAL", FechaFinal.Month)
        cmd.Parameters.AddWithValue("@FECHAINICIAL", FechaInicial)
        cmd.Parameters.AddWithValue("@FECHAFINAL", FechaFinal)

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            Try
                tblVtaProductos.Rows.Add(New Object() {
                            dr(0).ToString, 'CODPROD
                            dr(1).ToString, 'DESPROD
                            Integer.Parse(dr(2)), 'UXC
                            Double.Parse(dr(3)), 'TOTALCOSTO
                            Double.Parse(dr(4)), 'TOTALPRECIO
                            Double.Parse(dr(5)), 'UTILIDAD
                            Double.Parse(dr(6))  'MARGEN          
                          })
            Catch ex As Exception

            End Try
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportVentasProductos

        report.DataSource = tblVtaProductos
        report.DataAdapter = Adapter
        report.DataMember = "tblVtaProductos"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'VENTAS POR CLASIFICACION UNO DOS TRES
    Public Sub AbrirReporte_VentasClasificacion(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal Clase As Integer, ByVal CodClasificacion As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblVtaProductos As New DataTable("tblVtaProductos")

        With tblVtaProductos
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("UXC", GetType(Integer))
            .Columns.Add("TOTALUNIDADES", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("UTILIDAD", GetType(Double))
            .Columns.Add("MARGEN", GetType(Double))
            .Columns.Add("CLASIFICACION", GetType(String))
        End With

        Dim sql As String
        Select Case Clase
            Case 1
                sql = "SELECT DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, 
                         SUM(DOCPRODUCTOS.TOTALPRECIO) AS PRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD, (SUM(DOCPRODUCTOS.TOTALPRECIO) 
                         - SUM(DOCPRODUCTOS.TOTALCOSTO)) / SUM(DOCPRODUCTOS.TOTALCOSTO) AS MARGEN, CLASIFICACIONUNO.DESCLAUNO
                        FROM            PRODUCTOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT AND PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                         DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES')) AND (DOCUMENTOS.STATUS <> 'A') AND (CLASIFICACIONUNO.CODCLAUNO = @CODCLASE)
                        GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, CLASIFICACIONUNO.DESCLAUNO
                        ORDER BY DOCPRODUCTOS.DESPROD"
            Case 2
                sql = "SELECT DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, 
                         SUM(DOCPRODUCTOS.TOTALPRECIO) AS PRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD, (SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO)) / SUM(DOCPRODUCTOS.TOTALCOSTO) AS MARGEN, CLASIFICACIONDOS.DESCLADOS
                    FROM PRODUCTOS LEFT OUTER JOIN
                         CLASIFICACIONDOS ON PRODUCTOS.EMPNIT = CLASIFICACIONDOS.EMPNIT AND PRODUCTOS.CODCLADOS = CLASIFICACIONDOS.CODCLADOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                         DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                    WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A') AND (CLASIFICACIONDOS.CODCLADOS = @CODCLASE)
                    GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, CLASIFICACIONDOS.DESCLADOS
                    ORDER BY DOCPRODUCTOS.DESPROD"
            Case 3
                sql = "SELECT        DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, 
                         SUM(DOCPRODUCTOS.TOTALPRECIO) AS PRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD, (SUM(DOCPRODUCTOS.TOTALPRECIO) 
                         - SUM(DOCPRODUCTOS.TOTALCOSTO)) / SUM(DOCPRODUCTOS.TOTALCOSTO) AS MARGEN, CLASIFICACIONTRES.DESCLATRES
                        FROM            PRODUCTOS LEFT OUTER JOIN
                         CLASIFICACIONTRES ON PRODUCTOS.EMPNIT = CLASIFICACIONTRES.EMPNIT AND PRODUCTOS.CODCLADOS = CLASIFICACIONTRES.CODCLATRES RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                         DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND 
                         (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A') AND (CLASIFICACIONTRES.CODCLATRES = @CODCLASE)
                        GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, CLASIFICACIONTRES.DESCLATRES
                        ORDER BY DOCPRODUCTOS.DESPROD"

                sql = ""
                sql = "SELECT        DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS COSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) 
                         AS PRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD, (SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO)) / SUM(DOCPRODUCTOS.TOTALCOSTO) 
                         AS MARGEN, CLASIFICACIONDOS.DESCLADOS AS DESCLATRES
                        FROM  PRODUCTOS LEFT OUTER JOIN
                           CLASIFICACIONDOS ON PRODUCTOS.EMPNIT = CLASIFICACIONDOS.EMPNIT AND PRODUCTOS.CODCLATRES = CLASIFICACIONDOS.CODCLADOS LEFT OUTER JOIN
                           CLASIFICACIONTRES ON PRODUCTOS.EMPNIT = CLASIFICACIONTRES.EMPNIT AND PRODUCTOS.CODCLADOS = CLASIFICACIONTRES.CODCLATRES RIGHT OUTER JOIN
                           DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                           DOCUMENTOS ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND
                           DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO LEFT OUTER JOIN
                           TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A') AND 
                             (CLASIFICACIONTRES.CODCLATRES = @CODCLASE)
                        GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, PRODUCTOS.UXC, CLASIFICACIONDOS.DESCLADOS
                        ORDER BY DOCPRODUCTOS.DESPROD"

        End Select


        Dim cmd As New SqlCommand(sql, cn)

        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@FECHAINICIAL", FechaInicial)
        cmd.Parameters.AddWithValue("@FECHAFINAL", FechaFinal)
        cmd.Parameters.AddWithValue("@CODCLASE", CodClasificacion)

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            tblVtaProductos.Rows.Add(New Object() {
                            dr(0).ToString, 'CODPROD
                            dr(1).ToString, 'DESPROD
                            Integer.Parse(dr(2)), 'UXC
                            Double.Parse(dr(3)), 'TOTALCOSTO
                            Double.Parse(dr(4)), 'TOTALPRECIO
                            Double.Parse(dr(5)), 'UTILIDAD
                            Double.Parse(dr(6)),  'MARGEN
                            dr(7).ToString 'CLASIFICACION          
                          })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportCLASIFICACION

        report.DataSource = tblVtaProductos
        report.DataAdapter = Adapter
        report.DataMember = "tblVtaProductos"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview

    End Sub

    'VENTAS POR MARCA
    Public Sub AbrirReporte_VentasMarcas(ByVal FechaInicial As Date, ByVal FechaFinal As Date)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblVtaMarcas As New DataTable("tblVtaMarcas")

        With tblVtaMarcas
            .Columns.Add("DESMARCA", GetType(String))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("UTILIDAD", GetType(Double))
            .Columns.Add("MARGEN", GetType(Double))
        End With

        Dim cmd As New SqlCommand("SELECT        MARCAS.DESMARCA, SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) AS TOTALPRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) 
                         - SUM(DOCPRODUCTOS.TOTALCOSTO) AS UTILIDAD, (SUM(DOCPRODUCTOS.TOTALPRECIO) - SUM(DOCPRODUCTOS.TOTALCOSTO)) / SUM(DOCPRODUCTOS.TOTALCOSTO) AS MARGEN
FROM            TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCUMENTOS LEFT OUTER JOIN
                         PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND 
                         DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.MES = DOCPRODUCTOS.MES AND DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                         DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA
WHERE        (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO BETWEEN @ANIOINICIAL AND @ANIOFINAL) AND (DOCUMENTOS.MES BETWEEN @MESINICIAL AND @MESFINAL) AND 
                         (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL) AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES')) AND (DOCUMENTOS.STATUS <> 'A')
GROUP BY MARCAS.DESMARCA", cn)
        '}cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIOINICIAL", FechaInicial.Year)
        cmd.Parameters.AddWithValue("@MESINICIAL", FechaInicial.Month)
        cmd.Parameters.AddWithValue("@ANIOFINAL", FechaFinal.Year)
        cmd.Parameters.AddWithValue("@MESFINAL", FechaFinal.Month)
        cmd.Parameters.AddWithValue("@FECHAINICIAL", FechaInicial)
        cmd.Parameters.AddWithValue("@FECHAFINAL", FechaFinal)

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            tblVtaMarcas.Rows.Add(New Object() {
                            dr(0).ToString, 'DESMARCA
                            Double.Parse(dr(1)), 'TOTALCOSTO
                            Double.Parse(dr(2)), 'TOTALPRECIO
                            Double.Parse(dr(3)), 'UTILIDAD
                            Double.Parse(dr(4))  'MARGEN          
                          })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportVentasMarcas

        report.DataSource = tblVtaMarcas
        report.DataAdapter = Adapter
        report.DataMember = "tblVtaMarcas"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'Listado general de Saldos de Clientes
    Public Sub AbrirReporte_SaldosClientes(ByVal Anio As Integer, ByVal Mes As Integer)

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim tblCxC As New DataTable
        With tblCxC.Columns
            .Add("GRUPO", GetType(String))
            .Add("MES", GetType(Integer))
            .Add("ANIO", GetType(Integer))
            .Add("NITCLIE", GetType(String))
            .Add("NOMCLIE", GetType(String))
            .Add("CREDITOS", GetType(Double))
            .Add("ABONOS", GetType(Double))
            .Add("SALDO", GetType(Double))
        End With

        Call AbrirConexionSql()

        Dim cmd As New SqlCommand("REPORTES_BI_SALDOSCLIENTES", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", Anio)
        cmd.Parameters.AddWithValue("@MES", Mes)

        Dim dr As SqlDataReader = cmd.ExecuteReader
        Do While dr.Read
            Try
                tblCxC.Rows.Add(New Object() {
                    dr(0).ToString,'grupo
                    Integer.Parse(dr(1)),'anio
                    Integer.Parse(dr(2)),'mes
                    dr(3).ToString,'nitclie
                    dr(4).ToString,'nomclie
                    Double.Parse(dr(5)),'creditos
                    Double.Parse(dr(6)),'abonos
                    Double.Parse(dr(7))'saldo
                                          })
            Catch ex As Exception
            End Try
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportSaldoClientes

        report.DataSource = tblCxC
        report.DataAdapter = Adapter
        report.DataMember = "tblCxC"
        ' report.LoadLayout(Application.StartupPath + "\Reports\VENTADIACLASEDOS.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview

    End Sub

    'ventas por vendedor
    Public Sub AbrirReporte_VentasVendedor(ByVal FechaInicial As Date, ByVal FechaFinal As Date, ByVal Imp As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblVentaVendedor As New DataTable("tblVentaVendedor")

        With tblVentaVendedor
            .Columns.Add("VENDEDOR", GetType(String))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("VENTA", GetType(Double))
        End With

        Dim cmd As New SqlCommand("REPORT_VENTASVENDEDOR", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIOINICIAL", FechaInicial.Year)
        cmd.Parameters.AddWithValue("@MESINICIAL", FechaInicial.Month)
        cmd.Parameters.AddWithValue("@ANIOFINAL", FechaFinal.Year)
        cmd.Parameters.AddWithValue("@MESFINAL", FechaFinal.Month)
        cmd.Parameters.AddWithValue("@FECHAINICIAL", FechaInicial)
        cmd.Parameters.AddWithValue("@FECHAFINAL", FechaFinal)

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            tblVentaVendedor.Rows.Add(New Object() {
                            dr(0).ToString,'VENDEDOR
                            Double.Parse(dr(1)),'COSTO
                            Double.Parse(dr(2))'VENTA
                            })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New ReporteVentasVendedor

        report.DataSource = tblVentaVendedor
        report.DataAdapter = Adapter
        report.DataMember = "tblVentaVendedor"
        ' report.LoadLayout(Application.StartupPath + "\Reports\VENTADIACLASEDOS.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        SplashScreenManager.CloseForm()
        Select Case Imp
            Case 1
                report.Print
            Case 2
                report.ShowPreview
        End Select

    End Sub

    'REPORTE DE SALIDAS E INGRESOS DE INVENTARIOS
    Public Function AbrirReporte_MovInv(ByVal Fecha As Date, ByVal Coddoc As String, ByVal Correlativo As Double, Optional obs As String = "") As Boolean
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim result As Boolean


        Dim tbl As New DataTable("tblTicket")

        With tbl
            .Columns.Add("EMPNOMBRE", GetType(String))
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("CODMEDIDA", GetType(String))
            .Columns.Add("CANTIDAD", GetType(Double))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("USUARIO", GetType(String))
            .Columns.Add("DESDOC", GetType(String))
            .Columns.Add("OBS", GetType(String))
            .Columns.Add("OBSMARCA", GetType(String))
            .Columns.Add("TIPOVENTA", GetType(String))
            .Columns.Add("IDENTIFICADOR", GetType(String))
        End With


        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim sql As String
                sql = "SELECT   EMPRESAS.EMPNOMBRE, 
                                DOCUMENTOS.FECHA, 
                                DOCUMENTOS.CODDOC, 
                                DOCUMENTOS.CORRELATIVO, 
                                DOCPRODUCTOS.CODPROD, 
                                DOCPRODUCTOS.DESPROD, 
                                DOCPRODUCTOS.CODMEDIDA, 
                                DOCPRODUCTOS.CANTIDAD, 
                                DOCPRODUCTOS.COSTO, 
                                DOCPRODUCTOS.PRECIO, 
                                DOCPRODUCTOS.TOTALCOSTO, 
                                DOCPRODUCTOS.TOTALPRECIO, 
                                DOCUMENTOS.USUARIO, 
                                TIPODOCUMENTOS.DESDOC, 
                                DOCUMENTOS.OBS, 
                                DOCUMENTOS.OBSMARCA, 
                                DOCPRODUCTOS.CANTIDADBONIF,
                                DOCPRODUCTOS.TOTALBONIF,
                                DOCPRODUCTOS.TOTALUNIDADES, 
                                ISNULL(DOCUMENTOS.TIPOVENTA, 'SN') AS TIPOVENTA, 
                                ISNULL(DOCUMENTOS.IDENTIFICADOR, 'SN') AS IDENTIFICADOR
                       FROM     DOCUMENTOS LEFT OUTER JOIN
                                TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER JOIN
                                DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.MES = DOCPRODUCTOS.MES AND 
                                DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT
                       WHERE    (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.CODDOC = @CODDOC) AND (DOCUMENTOS.CORRELATIVO = @CORRELATIVO)"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                          dr(0).ToString,'EMPRESA
                          Date.Parse(dr(1)),'FECHA
                          dr(2).ToString,'CODDOC
                          Double.Parse(dr(3).ToString),'CORRELATIVO
                          dr(4).ToString,'CODPROD
                          dr(5).ToString,'DESPROD
                          dr(6).ToString,'CODMEDIDA
                          Double.Parse(dr(7)),'CANTIDAD
                          Double.Parse(dr(8)),'COSTO
                          Double.Parse(dr(9)),'PRECIO
                          Double.Parse(dr(10)),'TOTALCOSTO
                          Double.Parse(dr(11)),'TOTALPRECIO
                          dr(12).ToString,'USUARIO
                          dr(13).ToString,'DESDOC
                          dr(14).ToString & " - " & obs,  'OBS
                          dr(15).ToString,  'OBS MARCA / ORIGEN
                          dr(19).ToString, 'TIPOVENTA
                          dr(20).ToString  'IDENTIFICADOR
                                                })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()
                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                SplashScreenManager.CloseForm()
                Return False

            End Try


        End Using


        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportMOVINV

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblTicket"
        Try
            report.LoadLayout(Application.StartupPath + "\Reports\MOVINV.repx")
        Catch ex As Exception
            report.SaveLayout(Application.StartupPath + "\Reports\MOVINV.repx")
        End Try


        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        'report.Print

        SplashScreenManager.CloseForm()

        report.ShowPreview

        Return result

    End Function

    'REPORTE INVENTARIOS FISICOS
    Public Function AbrirReporte_InvFisico(ByVal Fecha As Date, ByVal Coddoc As String, ByVal Correlativo As Double) As Boolean
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim result As Boolean

        Dim tbl As New DataTable("tbl")

        With tbl
            .Columns.Add("EMPNOMBRE", GetType(String))
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("CODMEDIDA", GetType(String))
            .Columns.Add("CANTIDAD", GetType(Double))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("USUARIO", GetType(String))
            .Columns.Add("DESDOC", GetType(String))
            .Columns.Add("OBS", GetType(String))
            .Columns.Add("BONIF", GetType(Double))
            .Columns.Add("TOTALBONIF", GetType(Double))
            .Columns.Add("TOTALUNIDADES", GetType(Double))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("REPORTES_TEMP_MOVINV", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Fecha.Year)
                cmd.Parameters.AddWithValue("@MES", Fecha.Month)
                cmd.Parameters.AddWithValue("@DIA", Fecha.Day)
                cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                  dr(0).ToString,'EMPRESA
                                  Date.Parse(dr(1)),'FECHA
                                  dr(2).ToString,'CODDOC
                                  Double.Parse(dr(3).ToString),'CORRELATIVO
                                  dr(4).ToString,'CODPROD
                                  dr(5).ToString,'DESPROD
                                  dr(6).ToString,'CODMEDIDA
                                  Double.Parse(dr(7)),'CANTIDAD
                                  Double.Parse(dr(8)),'COSTO
                                  Double.Parse(dr(9)),'PRECIO
                                  Double.Parse(dr(10)),'TOTALCOSTO
                                  Double.Parse(dr(11)),'TOTALPRECIO
                                  dr(12).ToString,'USUARIO
                                  dr(13).ToString,'DESDOC
                                  dr(14).ToString, 'OBS
                                  Double.Parse(dr(15)), 'INVENTARIO SISTEMA
                                  Double.Parse(dr(16)),'AJUSTE
                                  Double.Parse(dr(17)) 'TOTALUNIDADES
                                     })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()
                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                SplashScreenManager.CloseForm()
                Return False
            End Try

        End Using

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportINVFISICO

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tbl"
        'report.LoadLayout(Application.StartupPath + "\Reports\MOVINV.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        'report.Print
        SplashScreenManager.CloseForm()
        report.ShowPreview

        Return result

    End Function

    'Compra
    Public Function AbrirReporteCompra(ByVal FechaCompra As Date, ByVal Coddoc As String, ByVal Correlativo As Double, ByVal TIPO As String) As Boolean
        Dim result As Boolean

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


        Dim report As New XtraReportCompra

        Dim tblCOMPRA As New DataTable("tblCompra")
        With tblCOMPRA
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("HORA", GetType(Integer))
            .Columns.Add("MINUTO", GetType(Integer))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("PROVEEDOR", GetType(String))
            .Columns.Add("TELPROVEEDOR", GetType(String))
            .Columns.Add("CONTACTO", GetType(String))
            .Columns.Add("TELCONTACTO", GetType(String))
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("CODMEDIDA", GetType(String))
            .Columns.Add("CANTIDAD", GetType(Double))
            .Columns.Add("COSTO", GetType(String))
            .Columns.Add("TOTALCOSTO", GetType(String))
            .Columns.Add("SERIEFAC", GetType(String))
            .Columns.Add("NOFAC", GetType(String))
            .Columns.Add("TOTALCOSTO2", GetType(Double))
            .Columns.Add("USUARIO", GetType(String))
            .Columns.Add("CANTIDADBONIF", GetType(Double))
            .Columns.Add("OBS", GetType(String))
        End With



        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT DOCUMENTOS.FECHA, DOCUMENTOS.HORA, DOCUMENTOS.MINUTO, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, PROVEEDORES.EMPRESA, PROVEEDORES.TELEMPRESA, 
                         PROVEEDORES.CONTACTO, PROVEEDORES.TELCONTACTO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, DOCPRODUCTOS.CANTIDAD, DOCPRODUCTOS.COSTO, 
                         DOCPRODUCTOS.TOTALCOSTO,DOCUMENTOS.SERIEFAC,DOCUMENTOS.NOFAC, DOCUMENTOS.USUARIO, DOCPRODUCTOS.CANTIDADBONIF, DOCUMENTOS.OBS
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND 
                         DOCUMENTOS.MES = DOCPRODUCTOS.MES AND DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         PROVEEDORES ON DOCUMENTOS.EMPNIT = PROVEEDORES.EMPNIT AND DOCUMENTOS.CODCLIENTE = PROVEEDORES.CODPROV LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.CODDOC=@CODDOC) AND (DOCUMENTOS.CORRELATIVO=@CORRELATIVO) AND (TIPODOCUMENTOS.TIPODOC IN ('COM','OCM'))", cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tblCOMPRA.Rows.Add(New Object() {
                                 Date.Parse(dr(0).ToString),'fecha
                                Integer.Parse(dr(1).ToString),'hora
                                Integer.Parse(dr(2).ToString),'minuto
                                dr(3).ToString,'coddoc
                                Double.Parse(dr(4).ToString),'correlativo
                                dr(5).ToString,'proveedor
                                dr(6).ToString,'tel proveedor
                                dr(7).ToString,'contacto
                                dr(8).ToString,'tel contacto
                                dr(9).ToString,'codprod
                                dr(10).ToString,'desprod
                                dr(11).ToString,'medida
                                Double.Parse(dr(12).ToString),'cantidad
                                FormatCurrency(dr(13)).ToString,'costo
                                FormatCurrency(dr(14)).ToString,'total costo
                                dr(15).ToString,'serie
                                dr(16).ToString,'no fac
                                Double.Parse(dr(14).ToString),'TOTAL COSTO 2
                                dr(17).ToString, 'usuario
                                Double.Parse(dr(18)), 'cantidadbonif
                                dr(19).ToString  'obs
                                 })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using

        SplashScreenManager.CloseForm()

        If result = True Then
            Dim Adapter As New SqlDataAdapter
            report.DataSource = tblCOMPRA
            report.DataAdapter = Adapter
            report.DataMember = "tblCOMPRA"

            If TIPO = "COMPRAS" Then
                report.LoadLayout(Application.StartupPath + "\Reports\COMPRA.repx")
            Else 'ORDEN DE COMPRA
                report.LoadLayout(Application.StartupPath + "\Reports\ORDENCOMPRA.repx")
            End If


            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            report.ShowPreview
        End If

        Return result

    End Function

    'INVENTARIO GENERAL
    Public Function AbrirReportINVENTARIO(ByVal ANIO As Integer, ByVal MES As Integer) As Boolean
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim result As Boolean

        Dim tbl As New DataTable("tblInventarios")

        With tbl
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("DESPROD2", GetType(String))
            .Columns.Add("DESPROD3", GetType(String))
            .Columns.Add("UXC", GetType(Integer))
            .Columns.Add("SALDOINICIAL", GetType(Double))
            .Columns.Add("TOTALENTRADAS", GetType(Double))
            .Columns.Add("TOTALSALIDAS", GetType(Double))
            .Columns.Add("SALDO", GetType(Double))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("CODMARCA", GetType(Integer))
            .Columns.Add("DESMARCA", GetType(String))
            .Columns.Add("EMPNIT", GetType(String))
            .Columns.Add("EMPNOMBRE", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                'Dim cmd As New SqlCommand("REPORTES_TEMP_INVENTARIO", cn)
                'cmd.CommandType = CommandType.StoredProcedure
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, INVSALDO.SALDOINICIAL, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, 
                         PRODUCTOS.COSTO, 0 AS PRECIO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, 'SN' AS CODMEDIDA, PRODUCTOS.CODPROD2, INVSALDO.EMPNIT, EMPRESAS.EMPNOMBRE
                        FROM EMPRESAS RIGHT OUTER JOIN
                         INVSALDO ON EMPRESAS.EMPNIT = INVSALDO.EMPNIT LEFT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                        WHERE (NOT (INVSALDO.EMPNIT LIKE 'BACK%%'))
                        ORDER BY INVSALDO.EMPNIT, PRODUCTOS.DESPROD", cn)

                'cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                'cmd.Parameters.AddWithValue("@ANIO", ANIO)
                'cmd.Parameters.AddWithValue("@MES", MES)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    Try
                        tbl.Rows.Add(New Object() {
                                dr(0).ToString,'codprod
                                dr(1).ToString,'desprod
                                dr(2).ToString,'desprod2
                                dr(3).ToString,'desprod3
                                Integer.Parse(dr(4).ToString),'uxc
                                Double.Parse(dr(5).ToString),'saldo inicial
                                Double.Parse(dr(6).ToString),'total entradas
                                Double.Parse(dr(7).ToString),'total salidas
                                Double.Parse(dr(8).ToString),'saldo
                                Double.Parse(dr(9).ToString),'costo
                                (Double.Parse(dr(9).ToString) * Double.Parse(dr(8).ToString)),'totalcosto
                                Double.Parse(dr(10).ToString),'precio
                                (Double.Parse(dr(10).ToString) * Double.Parse(dr(8).ToString)),'totalprecio
                                Integer.Parse(dr(11).ToString),'codmarca
                                dr(12).ToString(), 'desmarca
                                dr(15).ToString(), 'empnit
                                dr(16).ToString()  'empnombre
                                             })
                    Catch ex As Exception
                        MsgBox("El producto " & dr(0).ToString & " " & dr(1).ToString & " tiene problemas de formato por lo que no se cargará en la lista")
                    End Try
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()
                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using


        SplashScreenManager.CloseForm()

        If result = True Then
            Dim Adapter As New SqlDataAdapter
            Dim report As New XtraReportInventario

            'report.LoadLayout(Application.StartupPath + "\Reports\INVENTARIO.repx")

            report.DataSource = tbl
            report.DataAdapter = Adapter
            report.DataMember = "tblInventarios"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            report.ShowPreview
        End If

        Return result

    End Function


    'INVENTARIO GENERAL
    Public Function TBLReportINVENTARIO(ByVal ANIO As Integer, ByVal MES As Integer) As DataTable
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim tbl As New DataTable("tblInventarios")

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

        Using cn As New SqlConnection(strSqlConectionString)
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

    'INVENTARIO POR MARCA
    Public Sub AbrirReportInventarioMarca(ByVal ANIO As Integer, ByVal MES As Integer, ByVal CodMarca As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tbl As New DataTable("tblInventarios")

        With tbl
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("DESPROD2", GetType(String))
            .Columns.Add("DESPROD3", GetType(String))
            .Columns.Add("UXC", GetType(Integer))
            .Columns.Add("SALDOINICIAL", GetType(Double))
            .Columns.Add("TOTALENTRADAS", GetType(Double))
            .Columns.Add("TOTALSALIDAS", GetType(Double))
            .Columns.Add("SALDO", GetType(Double))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("CODMARCA", GetType(Integer))
            .Columns.Add("DESMARCA", GetType(String))
        End With


        Dim cmd As New SqlCommand("REPORTES_TEMP_INVENTARIOMARCA", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", ANIO)
        cmd.Parameters.AddWithValue("@MES", MES)
        cmd.Parameters.AddWithValue("@CODMARCA", CodMarca)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            Try
                tbl.Rows.Add(New Object() {
                        dr(0).ToString,'codprod
                        dr(1).ToString,'desprod
                        dr(2).ToString,'desprod2
                        dr(3).ToString,'desprod3
                        Integer.Parse(dr(4).ToString),'uxc
                        Double.Parse(dr(5).ToString),'saldo inicial
                        Double.Parse(dr(6).ToString),'total entradas
                        Double.Parse(dr(7).ToString),'total salidas
                        Double.Parse(dr(8).ToString),'saldo
                        Double.Parse(dr(9).ToString),'costo
                        (Double.Parse(dr(9).ToString) * Double.Parse(dr(8).ToString)),'totalcosto
                        Double.Parse(dr(10).ToString),'precio
                        (Double.Parse(dr(10).ToString) * Double.Parse(dr(8).ToString)),'totalprecio
                        Integer.Parse(dr(11).ToString),'codmarca
                        dr(12).ToString() 'desmarca
                                     })
            Catch ex As Exception
                MsgBox("El producto " & dr(0).ToString & "-" & dr(1).ToString & " tiene problemas de formato por lo que no se cargará en la lista")
            End Try
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()


        GlobalTituloReporte = "Inventario por MARCA"
        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportInventario
        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblInventarios"
        ' report.LoadLayout(Application.StartupPath + "\Reports\INVENTARIO.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'VENTAS DEL MES
    Public Sub AbrirReporte_VentasMes(ByVal CodProd As String, ByVal ANIO As Integer, ByVal MES As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Call AbrirConexionSql()

        Dim tblProductoVentas As New DataTable("tblProductoVentas")

        With tblProductoVentas
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("MARCA", GetType(String))
            .Columns.Add("DIA", GetType(Integer))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("MEDIDA", GetType(String))
            .Columns.Add("CANTIDAD", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
        End With

        Dim cmd As New SqlCommand("Select        DOCPRODUCTOS.CODPROD, PRODUCTOS.DESPROD, MARCAS.DESMARCA, DOCPRODUCTOS.DIA, DOCPRODUCTOS.CODDOC, DOCPRODUCTOS.CORRELATIVO, DOCPRODUCTOS.CODMEDIDA,
                         DOCPRODUCTOS.CANTIDAD, DOCPRODUCTOS.PRECIO, DOCPRODUCTOS.TOTALPRECIO
                        From            TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON TIPODOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT AND 
                         DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD
                        WHERE        (DOCPRODUCTOS.EMPNIT = @EMPNIT) AND (DOCPRODUCTOS.ANIO = @ANIO) AND (DOCPRODUCTOS.MES = @MES) AND (DOCPRODUCTOS.CODPROD = @CODPROD) AND 
                            (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC'))", cn)

        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@CODPROD", CodProd)
        cmd.Parameters.AddWithValue("@ANIO", ANIO)
        cmd.Parameters.AddWithValue("@MES", MES)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            tblProductoVentas.Rows.Add(New Object() {
            dr(0).ToString,'codprod
            dr(1).ToString,'desprod
            dr(2).ToString,'marca
            Integer.Parse(dr(3)),'dia
            dr(4).ToString,'coddoc
            Double.Parse(dr(5)),'correlativo
            dr(6).ToString,'medida
            Double.Parse(dr(7)),'cantidad
            Double.Parse(dr(8)),'precio
            Double.Parse(dr(9))'totalprecio
                                    })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportProductoVentas
        report.DataSource = tblProductoVentas
        report.DataAdapter = Adapter
        report.DataMember = "tblProductoVentas"
        'report.LoadLayout(Application.StartupPath + "\Reports\INVENTARIO.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'VENTAS CLASE DOS
    Public Sub AbrirReporte_VentaClaseDos(ByVal Fecha As Date, ByVal FechaF As Date, ByVal Imp As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblVentaClaseDos As New DataTable("tblVentaClaseDos")

        With tblVentaClaseDos
            .Columns.Add("EMPRESA", GetType(String))
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CLASIFICACIONDOS", GetType(String))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("VENTA", GetType(Double))
        End With

        Dim cmd As New SqlCommand("REPORTES_TEMP_VENTASCLASEDOS", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIOINICIAL", Fecha.Year)
        cmd.Parameters.AddWithValue("@MESINICIAL", Fecha.Month)
        cmd.Parameters.AddWithValue("@ANIOFINAL", FechaF.Year)
        cmd.Parameters.AddWithValue("@MESFINAL", FechaF.Month)
        cmd.Parameters.AddWithValue("@FECHAINICIAL", Fecha)
        cmd.Parameters.AddWithValue("@FECHAFINAL", FechaF)

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            Try
                tblVentaClaseDos.Rows.Add(New Object() {
                                dr(0).ToString,'EMPRESA
                                Date.Parse(dr(1).ToString),'FECHA
                                dr(2).ToString,'DESCLADOS
                                Double.Parse(dr(3)),'COSTO
                                Double.Parse(dr(4))'VENTA
                                })
            Catch ex As Exception

            End Try
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportTICKET

        report.DataSource = tblVentaClaseDos
        report.DataAdapter = Adapter
        report.DataMember = "tblVentaClaseDos"
        report.LoadLayout(Application.StartupPath + "\Reports\VENTADIACLASEDOS.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()
        Select Case Imp
            Case 1
                report.Print
            Case 2
                report.ShowPreview
        End Select

    End Sub

    'INVENTARIO POR CLASIFICACION
    Public Sub AbrirReporte_InventarioClasificacion(ByVal ANIO As Integer, ByVal MES As Integer, ByVal CodNo As Integer, ByVal CodClase As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tbl As New DataTable("tblInventarios")

        With tbl
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("DESPROD2", GetType(String))
            .Columns.Add("DESPROD3", GetType(String))
            .Columns.Add("UXC", GetType(Integer))
            .Columns.Add("SALDOINICIAL", GetType(Double))
            .Columns.Add("TOTALENTRADAS", GetType(Double))
            .Columns.Add("TOTALSALIDAS", GetType(Double))
            .Columns.Add("SALDO", GetType(Double))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("CODMARCA", GetType(Integer))
            .Columns.Add("DESMARCA", GetType(String))
        End With
        Dim sql As String
        Select Case CodNo
            Case 1
                GlobalTituloReporte = "Inventario por Clasificación UNO"
                'sql = "REPORTES_TEMP_INVENTARIOCLASEUNO"
                sql = "SELECT        INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, INVSALDO.SALDOINICIAL, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, 
                         PRODUCTOS.COSTO, 0 AS PRECIO, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, 'SN' AS CODMEDIDA
                    FROM            CLASIFICACIONUNO RIGHT OUTER JOIN
                                             PRODUCTOS ON CLASIFICACIONUNO.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONUNO.CODCLAUNO = PRODUCTOS.CODCLAUNO RIGHT OUTER JOIN
                                             INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                    WHERE        (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.CODCLAUNO = @CODCLASE)
                    ORDER BY PRODUCTOS.DESPROD"
            Case 2
                GlobalTituloReporte = "Inventario por Clasificación DOS"
                'sql = "REPORTES_TEMP_INVENTARIOCLASEDOS"
                sql = "SELECT       INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, INVSALDO.SALDOINICIAL, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, 
                         PRODUCTOS.COSTO, 0 AS PRECIO, PRODUCTOS.CODCLADOS, PROVEEDORES.EMPRESA AS DESCLADOS, 'SN' AS CODMEDIDA
                FROM            PROVEEDORES RIGHT OUTER JOIN
                                         PRODUCTOS ON PROVEEDORES.CODPROV = PRODUCTOS.CODCLADOS AND PROVEEDORES.EMPNIT = PRODUCTOS.EMPNIT LEFT OUTER JOIN
                                         CLASIFICACIONDOS ON PRODUCTOS.EMPNIT = CLASIFICACIONDOS.EMPNIT AND PRODUCTOS.CODCLADOS = CLASIFICACIONDOS.CODCLADOS RIGHT OUTER JOIN
                                         INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                WHERE        (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.CODCLADOS = @CODCLASE)ORDER BY PRODUCTOS.DESPROD"
            Case 3
                GlobalTituloReporte = "Inventario por Clasificación TRES"
                'sql = "REPORTES_TEMP_INVENTARIOCLASETRES"
                sql = "SELECT        INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, INVSALDO.SALDOINICIAL, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, 
                         PRODUCTOS.COSTO, 0 AS PRECIO, PRODUCTOS.CODCLADOS, CLASIFICACIONTRES.DESCLATRES, 'SN' AS CODMEDIDA
                FROM            CLASIFICACIONTRES RIGHT OUTER JOIN
                                         PRODUCTOS ON CLASIFICACIONTRES.EMPNIT = PRODUCTOS.EMPNIT AND CLASIFICACIONTRES.CODCLATRES = PRODUCTOS.CODCLATRES RIGHT OUTER JOIN
                                         INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                WHERE        (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (PRODUCTOS.CODCLATRES = @CODCLASE) AND ('SN' = 'UNIDAD')"
            Case 4
                GlobalTituloReporte = "Inventario por Clasificación CUATRO"
                sql = "REPORTES_TEMP_INVENTARIOCLASECUATRO"

        End Select

        Dim cmd As New SqlCommand(sql, cn)
        'cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", ANIO)
        cmd.Parameters.AddWithValue("@MES", MES)
        cmd.Parameters.AddWithValue("@CODCLASE", CodClase)

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            Try
                tbl.Rows.Add(New Object() {
                        dr(0).ToString,'codprod
                        dr(1).ToString,'desprod
                        dr(2).ToString,'desprod2
                        dr(3).ToString,'desprod3
                        Integer.Parse(dr(4).ToString),'uxc
                        Double.Parse(dr(5).ToString),'saldo inicial
                        Double.Parse(dr(6).ToString),'total entradas
                        Double.Parse(dr(7).ToString),'total salidas
                        Double.Parse(dr(8).ToString),'saldo
                        Double.Parse(dr(9).ToString),'costo
                        (Double.Parse(dr(9).ToString) * Double.Parse(dr(8).ToString)),'totalcosto
                        Double.Parse(dr(10).ToString),'precio
                        (Double.Parse(dr(10).ToString) * Double.Parse(dr(8).ToString)),'totalprecio
                        Integer.Parse(dr(11).ToString),'codmarca
                        dr(12).ToString() 'desmarca
                                     })
            Catch ex As Exception
                MsgBox("El producto " & dr(0).ToString & "-" & dr(1).ToString & " tiene problemas de formato por lo que no se cargará en la lista")
            End Try
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportInventario
        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblInventarios"
        'report.LoadLayout(Application.StartupPath + "\Reports\INVENTARIO.repx")
        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'LISTADO DE COMPRAS POR FECHAS
    Public Sub AbrirReporte_ComprasFechas(ByVal FechaInicial As Date, ByVal FechaFinal As Date)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        GlobalNomFac = "Proveedor"
        GlobalVendFac = "Usuario"
        GlobalTituloReporte = "Listado de Compras por Fechas"

        Call AbrirConexionSql()


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
        End With

        Dim cmd As New SqlCommand("REPORTES_BI_COMPRASFECHAS", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIOINICIAL", FechaInicial.Year)
        cmd.Parameters.AddWithValue("@ANIOFINAL", FechaFinal.Year)
        cmd.Parameters.AddWithValue("@FECHAINICIAL", FechaInicial)
        cmd.Parameters.AddWithValue("@FECHAFINAL", FechaFinal)
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
                          dr(9).ToString'USUARIO
                          })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportVentaDocumento

        report.DataSource = tblVtaDoc
        report.DataAdapter = Adapter
        report.DataMember = "tblVtaDoc"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        ' report.XrChart1.DataSource = tblVtaDoc
        'report.XrChart1.DataMember = "tblVtaDoc"

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview

    End Sub

    'COMPRAS DEL MES DEL PROVEEDOR
    Public Sub AbrirReporte_ComprasProveedor(ByVal Anio As Integer, ByVal Mes As Integer, ByVal NitProv As String)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        GlobalNomFac = "Proveedor"
        GlobalVendFac = "Usuario"
        GlobalTituloReporte = "Listado de Compras por Proveedor"

        Call AbrirConexionSql()

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
        End With

        Dim cmd As New SqlCommand("REPORTES_BI_COMPRASPROV", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", Anio)
        cmd.Parameters.AddWithValue("@MES", Mes)
        cmd.Parameters.AddWithValue("@NITPROV", NitProv)
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
                          dr(9).ToString'USUARIO
                          })
        Loop

        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportVentaDocumento

        report.DataSource = tblVtaDoc
        report.DataAdapter = Adapter
        report.DataMember = "tblVtaDoc"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()

        SplashScreenManager.CloseForm()
        report.ShowPreview


    End Sub

    'GENERA PDF A PARTIR DE UNA COTIZACIÓN
    Public Function GenerarCotizacion(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal Fecha As Date) As Boolean

        Try
            'SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Call AbrirConexionSql()

            Dim tblTicket As New DataTable("tblTicket")

            With tblTicket
                .Columns.Add("FECHA", GetType(Date))
                .Columns.Add("CODDOC", GetType(String))
                .Columns.Add("CORRELATIVO", GetType(Double))
                .Columns.Add("CODPROD", GetType(String))
                .Columns.Add("DESPROD", GetType(String))
                .Columns.Add("CODMEDIDA", GetType(String))
                .Columns.Add("CANTIDAD", GetType(Double))
                .Columns.Add("COSTO", GetType(Double))
                .Columns.Add("PRECIO", GetType(Double))
                .Columns.Add("CODCLIENTE", GetType(Integer))
                .Columns.Add("NIT", GetType(String))
                .Columns.Add("NOMBRECLIENTE", GetType(String))
                .Columns.Add("DIRCLIENTE", GetType(String))
                .Columns.Add("CODVEN", GetType(Integer))
                .Columns.Add("NOMVEN", GetType(String))
                .Columns.Add("TOTALCOSTO", GetType(Double))
                .Columns.Add("TOTALPRECIO", GetType(Double))
                .Columns.Add("EMPNOMBRE", GetType(String))
                .Columns.Add("PAGO", GetType(Double))
                .Columns.Add("VUELTO", GetType(Double))
                .Columns.Add("HORA", GetType(Integer))
                .Columns.Add("MINUTO", GetType(Integer))
                .Columns.Add("CONCRE", GetType(String))
            End With

            TotalVentaFAC = 0

            Dim cmd As New SqlCommand(objQuerys.queryTicket, cn)

            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@ANIO", Fecha.Year)
            cmd.Parameters.AddWithValue("@MES", Fecha.Month)
            cmd.Parameters.AddWithValue("@DIA", Fecha.Day)
            cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            Do While dr.Read
                tblTicket.Rows.Add(New Object() {
                                 Date.Parse(dr(0).ToString),'fecha
                              dr(1).ToString,'coddoc
                              Double.Parse(dr(2).ToString),'correlativo
                              dr(3).ToString,'codprod
                              dr(4).ToString,'desprod
                              dr(5).ToString,'codmedida
                              Double.Parse(dr(6)),'cantidad
                              Double.Parse(dr(7)),'costo
                              Double.Parse(dr(8)),'precio
                              Integer.Parse(dr(9)),'codcliente
                              dr(10).ToString,'nit
                              dr(11).ToString,'nombrecliente
                              dr(12).ToString,'dircliente
                              Integer.Parse(dr(13)),'codven
                              dr(14).ToString,'nomven
                              Double.Parse(dr(15)),'totalcosto
                              Double.Parse(dr(16)),'totalprecio
                              dr(17).ToString,'empnombre
                              Double.Parse(dr(18)),'pago
                              Double.Parse(dr(19)),'vuelto
                              Integer.Parse(dr(20)),'hora
                              Integer.Parse(dr(21)),'minuto
                              dr(22).ToString  'CONCRE
                                 })
                TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
            Loop
            dr.Close()
            dr = Nothing
            cmd.Dispose()

            cn.Close()


            Dim Adapter As New SqlDataAdapter
            Dim report As New rptCotizacion

            report.DataSource = tblTicket
            report.DataAdapter = Adapter
            report.DataMember = "tblTicket"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()
            report.ExportToPdf(Application.StartupPath + "\CotizacionDelCliente.pdf")
            'SplashScreenManager.CloseForm()
            Return True

        Catch ex As Exception
            MsgBox("No se genero la cotizacion pdf " + ex.ToString)
            Return False
        End Try

    End Function

    'COTIZACION
    Public Sub AbrirReporte_Cotizacion(ByVal Fecha As Date, ByVal Coddoc As String, ByVal Correlativo As Double, ByVal Imp As Integer)
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Call AbrirConexionSql()

        Dim tblTicket As New DataTable("tblTicket")

        With tblTicket
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("CODPROD", GetType(String))
            .Columns.Add("DESPROD", GetType(String))
            .Columns.Add("CODMEDIDA", GetType(String))
            .Columns.Add("CANTIDAD", GetType(Double))
            .Columns.Add("COSTO", GetType(Double))
            .Columns.Add("PRECIO", GetType(Double))
            .Columns.Add("CODCLIENTE", GetType(Integer))
            .Columns.Add("NIT", GetType(String))
            .Columns.Add("NOMBRECLIENTE", GetType(String))
            .Columns.Add("DIRCLIENTE", GetType(String))
            .Columns.Add("CODVEN", GetType(Integer))
            .Columns.Add("NOMVEN", GetType(String))
            .Columns.Add("TOTALCOSTO", GetType(Double))
            .Columns.Add("TOTALPRECIO", GetType(Double))
            .Columns.Add("EMPNOMBRE", GetType(String))
            .Columns.Add("PAGO", GetType(Double))
            .Columns.Add("VUELTO", GetType(Double))
            .Columns.Add("HORA", GetType(Integer))
            .Columns.Add("MINUTO", GetType(Integer))
            .Columns.Add("CONCRE", GetType(String))
        End With

        TotalVentaFAC = 0
        Dim cmd As New SqlCommand("SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, 
						DOCPRODUCTOS.CODPROD, 
						CASE PRODUCTOS.EXENTO WHEN 0 THEN DOCPRODUCTOS.DESPROD ELSE CONCAT('*',DOCPRODUCTOS.DESPROD) END AS DESPROD, 
						DOCPRODUCTOS.CODMEDIDA, DOCPRODUCTOS.CANTIDAD, 
                         DOCPRODUCTOS.COSTO, DOCPRODUCTOS.PRECIO, DOCUMENTOS.CODCLIENTE, DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, CLIENTES.DIRCLIENTE AS DOC_DIRCLIE, DOCUMENTOS.CODVEN, 
                         EMPLEADOS.NOMEMPLEADO AS NOMVEN, DOCPRODUCTOS.TOTALCOSTO, DOCPRODUCTOS.TOTALPRECIO, EMPRESAS.EMPNOMBRE, DOCUMENTOS.PAGO, DOCUMENTOS.VUELTO, DOCUMENTOS.HORA, 
                         DOCUMENTOS.MINUTO, DOCUMENTOS.CONCRE, ISNULL(TIPODOCUMENTOS.AUTORIZACION, 'SN') AS AUTORIZACION, ISNULL(TIPODOCUMENTOS.RESOLUCION, 'SN') AS RESOLUCION, ISNULL(TIPODOCUMENTOS.FRASE1, 
                         'SN') AS FRASE1, ISNULL(DOCPRODUCTOS.OBS, ' ') AS NOSERIE, MUNICIPIOS.DESMUNICIPIO, ISNULL(CLIENTES.TELEFONOCLIENTE, 'SN') AS TELCLIENTE, ISNULL(DOCUMENTOS.TOTALTARJETA, 0) AS TOTALTARJETA, 
                         ISNULL(DOCUMENTOS.RECARGOTARJETA, 0) AS RECARGOTARJETA, ISNULL(DOCUMENTOS.DIRENTREGA, 'SN') AS DIRENTREGA, ISNULL(DOCPRODUCTOS.EXENTO, 0) AS EXENTO, ISNULL(DOCUMENTOS.OBS, 'SN') AS OBS, 
                         DOCUMENTOS.VENCIMIENTO, DOCUMENTOS.DIASCREDITO
                    FROM PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         EMPLEADOS RIGHT OUTER JOIN
                         DOCUMENTOS ON EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN AND EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         MUNICIPIOS RIGHT OUTER JOIN
                         CLIENTES ON MUNICIPIOS.CODMUNICIPIO = CLIENTES.CODMUNICIPIO ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND 
                         DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                         DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO
                    WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (DOCUMENTOS.DIA = @DIA) AND (DOCUMENTOS.CODDOC = @CODDOC) AND 
                         (DOCUMENTOS.CORRELATIVO = @CORRELATIVO)", cn)

        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", Fecha.Year)
        cmd.Parameters.AddWithValue("@MES", Fecha.Month)
        cmd.Parameters.AddWithValue("@DIA", Fecha.Day)
        cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
        cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        Do While dr.Read
            tblTicket.Rows.Add(New Object() {
                             Date.Parse(dr(0).ToString),'fecha
                          dr(1).ToString,'coddoc
                          Double.Parse(dr(2).ToString),'correlativo
                          dr(3).ToString,'codprod
                          dr(4).ToString,'desprod
                          dr(5).ToString,'codmedida
                          Double.Parse(dr(6)),'cantidad
                          Double.Parse(dr(7)),'costo
                          Double.Parse(dr(8)),'precio
                          Integer.Parse(dr(9)),'codcliente
                          dr(10).ToString,'nit
                          dr(11).ToString,'nombrecliente
                          dr(12).ToString,'dircliente
                          Integer.Parse(dr(13)),'codven
                          dr(14).ToString,'nomven 
                          Double.Parse(dr(15)),'totalcosto
                          Double.Parse(dr(16)),'totalprecio
                          dr(17).ToString,'empnombre
                          Double.Parse(dr(18)),'pago
                          Double.Parse(dr(19)),'vuelto
                          Integer.Parse(dr(20)),'hora
                          Integer.Parse(dr(21)),'minuto
                          dr(22).ToString  'CONCRE
                             })
            TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
        Loop
        dr.Close()
        dr = Nothing
        cmd.Dispose()

        cn.Close()


        Dim Adapter As New SqlDataAdapter
        Dim report As New rptCotizacion

        Try
            report.LoadLayout(Application.StartupPath + "\Reports\COTIZACION.repx")
        Catch ex As Exception
            report.SaveLayout(Application.StartupPath + "\Reports\COTIZACION.repx")
            report.LoadLayout(Application.StartupPath + "\Reports\COTIZACION.repx")
        End Try

        report.DataSource = tblTicket
        report.DataAdapter = Adapter
        report.DataMember = "tblTicket"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview

    End Sub


    Public Sub AbrirReporteCuadre(ByVal Fecha As Date, ByVal CORRELATIVO As Double)

        Call Form1.Mensaje("Cargando Comprobante")

        'SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim ds As New DS_CorteCaja
        'ds.Clear()

        Call AbrirConexionSql()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim report As New XtraReport
                Dim qry As String = ""

                Select Case Form1.cmbConfigFormatoCorteCaja.Text
                    Case "ORIGINAL"
                        qry = "SELECT 
                                CORRELATIVO, 
                                FECHA, 
                                USUARIO, 
                                TOTALMOVIMIENTOS, 
                                TOTALREPORTADO, 
                                TOTALVENTA as TOTALVENTAS, 
                                SOBRANTE, 
                                FALTANTE, 
                                MARGEN, 
                                HORAINICIAL AS HORAINICIO, 
                                (((TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0)) - (TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0))) - REPORTADOCHEQUES) AS MINUTOINICIO, 
                                HORAFINAL AS HORAFIN, 
                                ( (TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0)) - (TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0)) ) AS MINUTOFIN, 
                                OBS, 
                                TOTALRECIBOS, 
                                TOTALTARJETA, 
                                (TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0) ) AS TOTALVTATARJETARECIBOS, 
                                ISNULL(REPORTADOTARJETA,0) AS REPORTADOTARJETA, 
                                ISNULL(TOTALGASTOS,0) AS TOTALGASTOS,  
                                (TOTALREPORTADO + TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0) ) - (TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0) )  AS TOTALFINAL, 
                                ISNULL(TOTALCHEQUES,0) AS TOTALCHEQUES, 
                                ISNULL(REPORTADOCHEQUES,0) AS EFECTIVOINICIAL,
                                ISNULL(TOTALDEVOLUCIONES,0) AS DEVOLUCIONES,
                                ISNULL(TOTALVENTASCREDITO,0) AS TOTALVENTASCREDITO,
                                (ISNULL(TOTALDEVOLUCIONES,0) + ISNULL(TOTALGASTOS,0) + ISNULL(REPORTADOCHEQUES,0) + ISNULL(REPORTADOTARJETA,0) + ISNULL(TOTALREPORTADO,0)) AS TOTALCOSTO
                                FROM CORTES
                                WHERE (EMPNIT = @EMPNIT) AND (CORRELATIVO = @CORRELATIVO)"
                        If Form1.switchConfigClienteTipoCorteCaja.IsOn = True Then
                            report = New XtraReportCorteCajaClaseDos 'version ticket
                        Else
                            report = New XtraReportCorteCaja 'version carta
                        End If
                    Case "MODELO 2" 'PARA FARMACIA URIZAR
                        qry = "SELECT 
                                CORRELATIVO, 
                                FECHA, 
                                USUARIO, 
                                TOTALMOVIMIENTOS, 
                                TOTALREPORTADO, 
                                TOTALVENTA as TOTALVENTAS, 
                                SOBRANTE, 
                                FALTANTE, 
                                MARGEN, 
                                HORAINICIAL AS HORAINICIO, 
                                (((TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0)) - (TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0))) - REPORTADOCHEQUES) AS MINUTOINICIO, 
                                HORAFINAL AS HORAFIN, 
                                ( (TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0)) - (TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0)) ) AS MINUTOFIN, 
                                OBS, 
                                TOTALRECIBOS, 
                                TOTALTARJETA, 
                                (TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0) ) AS TOTALVTATARJETARECIBOS, 
                                ISNULL(REPORTADOTARJETA,0) AS REPORTADOTARJETA, 
                                ISNULL(TOTALGASTOS,0) AS TOTALGASTOS,  
                                (TOTALREPORTADO + TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0) ) - (TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0) )  AS TOTALFINAL, 
                                ISNULL(TOTALCHEQUES,0) AS TOTALCHEQUES, 
                                ISNULL(REPORTADOCHEQUES,0) AS EFECTIVOINICIAL,
                                ISNULL(TOTALDEVOLUCIONES,0) AS DEVOLUCIONES,
                                ISNULL(TOTALVENTASCREDITO,0) AS TOTALVENTASCREDITO,
                                (ISNULL(TOTALDEVOLUCIONES,0) + ISNULL(TOTALGASTOS,0) + ISNULL(REPORTADOCHEQUES,0) + ISNULL(REPORTADOTARJETA,0) + ISNULL(TOTALREPORTADO,0)) AS TOTALCOSTO
                                FROM CORTES
                                WHERE (EMPNIT = @EMPNIT) AND (CORRELATIVO = @CORRELATIVO)"

                        report = New rptCorteUrizar

                    Case "MODELO 3" 'PARA FARMASALUD
                        report = New rptCorteFarmasalud
                        'en esta query sumo la tarjeta y reportado tarjeta a los totales respectivos
                        qry = "SELECT 
                                CORRELATIVO, 
                                FECHA, 
                                USUARIO, 
                                TOTALMOVIMIENTOS, 
                                TOTALREPORTADO, 
                                TOTALVENTA as TOTALVENTAS, 
                                SOBRANTE, 
                                FALTANTE, 
                                MARGEN, 
                                HORAINICIAL AS HORAINICIO, 
                                (((TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0)) - (TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0))) - REPORTADOCHEQUES) AS MINUTOINICIO, 
                                HORAFINAL AS HORAFIN, 
                                ((TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0)) - (TOTALGASTOS + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0))) AS MINUTOFIN, 
                                OBS, 
                                TOTALRECIBOS, 
                                TOTALTARJETA, 
                                (TOTALVENTA +  TOTALRECIBOS + ISNULL(TOTALTARJETA,0) + ISNULL(REPORTADOCHEQUES,0) ) AS TOTALVTATARJETARECIBOS, 
                                ISNULL(REPORTADOTARJETA,0) AS REPORTADOTARJETA, 
                                ISNULL(TOTALGASTOS,0) AS TOTALGASTOS,  
                                (TOTALREPORTADO + TOTALGASTOS + ISNULL(REPORTADOTARJETA,0) + ISNULL(TOTALCHEQUES,0) + ISNULL(TOTALDEVOLUCIONES,0) ) - (TOTALVENTA +  TOTALRECIBOS + ISNULL(REPORTADOCHEQUES,0) + ISNULL(TOTALTARJETA,0) )  AS TOTALFINAL, 
                                ISNULL(TOTALCHEQUES,0) AS TOTALCHEQUES, 
                                ISNULL(REPORTADOCHEQUES,0) AS EFECTIVOINICIAL,
                                ISNULL(TOTALDEVOLUCIONES,0) AS DEVOLUCIONES,
                                ISNULL(TOTALVENTASCREDITO,0) AS TOTALVENTASCREDITO,
                                (ISNULL(TOTALDEVOLUCIONES,0) + ISNULL(TOTALGASTOS,0) + ISNULL(TOTALCHEQUES,0) + ISNULL(REPORTADOTARJETA,0) + ISNULL(TOTALREPORTADO,0)) AS TOTALCOSTO
                                FROM CORTES
                                WHERE (EMPNIT = @EMPNIT) AND (CORRELATIVO = @CORRELATIVO)"
                End Select

                Dim TotalVentasDetalle As Double = 0
                'relleno la tabla tbl donde están los datos del encabezado
                Dim cmd As New SqlCommand(qry, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CORRELATIVO", CORRELATIVO)
                Dim DA As New SqlDataAdapter
                DA.SelectCommand = cmd

                DA.Fill(ds, "tbl")

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    TotalVentasDetalle = Double.Parse(dr(5)) + Double.Parse(dr(15))
                Else
                    TotalVentasDetalle = 0
                End If
                dr.Close()
                cmd.Dispose()

                Try

                    'relleno la tabla tblDetalleVentas donde están los datos por vendedor
                    Dim cmd2 As New SqlCommand("SELECT ISNULL(EMPLEADOS.NOMEMPLEADO, 'SN') AS VENDEDOR, 
                    ISNULL( SUM(DOCUMENTOS.TOTALPRECIO) + SUM(ISNULL(DOCUMENTOS.RECARGOTARJETA, 0)) ,0) AS VENTAS, 
                    ISNULL( SUM(DOCUMENTOS.TOTALPRECIO)/@TOTALVENTAS ,0) AS PARTICIPACION, 
                    ISNULL(COUNT(DOCUMENTOS.CORRELATIVO) ,0) AS NOTRANS
                    FROM DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO AND DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                    WHERE (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC') )
                    GROUP BY DOCUMENTOS.EMPNIT, DOCUMENTOS.NOCORTE, EMPLEADOS.NOMEMPLEADO
                    HAVING (DOCUMENTOS.NOCORTE = @NOCORTE) AND (DOCUMENTOS.EMPNIT = @EMPNIT)", cn)
                    'cmd2.CommandType = CommandType.StoredProcedure
                    cmd2.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd2.Parameters.AddWithValue("@NOCORTE", CORRELATIVO)
                    cmd2.Parameters.AddWithValue("@TOTALVENTAS", TotalVentasDetalle)
                    Dim DA2 As New SqlDataAdapter
                    DA2.SelectCommand = cmd2
                    DA2.Fill(ds, "tblDetalleVentas")

                    cmd2.Dispose()

                    'carga el total de gastos
                    CorteTotalGastos = 0

                    'cn.Close()

                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                Dim Adapter As New SqlDataAdapter

                report.DataSource = ds
                report.DataAdapter = Adapter
                report.DataMember = "tblDetalleVentas"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()
                'SplashScreenManager.CloseForm()

                report.ShowPreview

            Catch ex As Exception
                GlobalDesError = ex.ToString
            End Try
        End Using

    End Sub

    Public Sub AbrirReporteCorteIEF(ByVal Fecha As Date, ByVal CORRELATIVO As Double)

        Call Form1.Mensaje("Cargando Comprobante")

        'SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim ds As New DS_CorteCaja
        'ds.Clear()

        Call AbrirConexionSql()



        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim report As New XtraReport


                Dim TotalVentasDetalle As Double = 0
                'relleno la tabla tbl donde están los datos del encabezado
                Dim cmd As New SqlCommand("SELECT       DIA,
                                                        MES,
                                                        ANIO,
                                                        FECHA,
                                                        HORA,
                                                        MINUTO,
                                                        CORRELATIVO,
                                                        TOTAL_MOVIMIENTOS,
                                                        TOTAL_ING,
                                                        TOTAL_REPORT,
                                                        FALTANTE,
                                                        SOBRANTE,
                                                        OBSERVACIONES,
                                                        USUARIO,
                                                        ISNULL(TOTAL_REPORT - TOTAL_ING, 0) AS DIFERENCIA                                                    
                                           FROM CORTES_IEF
                                           WHERE (EMPNIT = @EMPNIT) AND (CORRELATIVO = @CORRELATIVO)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CORRELATIVO", CORRELATIVO)
                Dim DA As New SqlDataAdapter
                DA.SelectCommand = cmd

                DA.Fill(ds, "tblCorte")


                'relleno la tabla tblDetalleVentas donde están los datos por vendedor
                Dim cmd2 As New SqlCommand("SELECT          ISNULL(SUCURSAL_ING, 'SN') AS SUCURSAL_ING, 
                                                            ISNULL(SUM(MONTO), 0) AS MONTO, 
                                                            ISNULL(MOTORISTA, 'SN') AS MOTORISTA, 
                                                            ISNULL(NO_CORTE, 'SN') AS NO_CORTE, 
                                                            ISNULL(EMPLEADO, 'SN') AS EMPLEADO
                                            FROM            EFECTIVO_KH
                                            WHERE (EMPNIT = @EMPNIT) AND (NO_CORTE = @NO_CORTE)
                                            GROUP BY SUCURSAL_ING, MOTORISTA, NO_CORTE, EMPLEADO", cn)
                'cmd2.CommandType = CommandType.StoredProcedure
                cmd2.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd2.Parameters.AddWithValue("@NO_CORTE", CORRELATIVO)
                Dim DA2 As New SqlDataAdapter
                DA2.SelectCommand = cmd2
                DA2.Fill(ds, "tblCorteIEF")

                cmd2.Dispose()

                report = New rptCorteIEF

                Dim Adapter As New SqlDataAdapter

                report.DataSource = ds
                report.DataAdapter = Adapter
                report.DataMember = "tblCorteIEF"

                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()
                'SplashScreenManager.CloseForm()

                report.ShowPreview

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
            End Try
        End Using

    End Sub

    Public Function AbrirReporteMovIEF(ByVal CORRELATIVO As Double) As DataTable

        Dim tbl As New DataTable
        'ds.Clear()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'relleno la tabla tbl donde están los datos del encabezado
                Dim cmd As New SqlCommand("SELECT          SUCURSAL_SAL, EMPLEADO, MONTO, OBSERVACIONES
                                           FROM            EFECTIVO_KH
                                           WHERE           (EMPNIT NOT LIKE @EMPNIT) AND (NO_CORTE = @NO_CORTE)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@NO_CORTE", CORRELATIVO)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
            End Try
        End Using

        Return tbl

    End Function

    Public Sub AbrirReporte_CuadreClaseDos(ByVal Fecha As Date, ByVal CORRELATIVO As Double)
        Call Form1.Mensaje("Cargando Comprobante")
        Dim ds As New DS_CorteCaja
        ds.Clear()

        'If cn.State = 0 Then
        'cn.Open()
        'End If
        Call AbrirConexionSql()


        Dim TotalVentasDetalle As Double = 0
        'relleno la tabla tbl donde están los datos del encabezado
        Dim cmd As New SqlCommand("REPORTES_TEM_CORTECAJA", cn)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@ANIO", Fecha.Year)
        cmd.Parameters.AddWithValue("@MES", Fecha.Month)
        cmd.Parameters.AddWithValue("@DIA", Fecha.Day)
        cmd.Parameters.AddWithValue("@CORRELATIVO", CORRELATIVO)
        Dim DA As New SqlDataAdapter
        DA.SelectCommand = cmd
        DA.Fill(ds, "tbl")
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TotalVentasDetalle = Double.Parse(dr(5))
        End If
        dr.Close()
        cmd.Dispose()

        'relleno la tabla tblDetalleVentas donde están los datos por vendedor
        Dim cmd2 As New SqlCommand("REPORTES_TEMP_CORTECAJA_CLASEDOS", cn)
        cmd2.CommandType = CommandType.StoredProcedure
        cmd2.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
        cmd2.Parameters.AddWithValue("@NOCORTE", CORRELATIVO)
        Dim DA2 As New SqlDataAdapter
        DA2.SelectCommand = cmd2
        DA2.Fill(ds, "tblClaseDos")
        cmd2.Dispose()

        cn.Close()

        Dim Adapter As New SqlDataAdapter
        Dim report As New XtraReportCorteCaja

        report.LoadLayout(Application.StartupPath + "\Reports\CorteClaseDos.repx")

        report.DataSource = ds
        report.DataAdapter = Adapter
        report.DataMember = "tblClaseDos"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        report.ShowPreview

    End Sub


End Module
