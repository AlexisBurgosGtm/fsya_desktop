Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class classEmbarques

    Sub New()

    End Sub

    Public Property DesError As String


    Public Function getDevolucionesPicking(ByVal codembarque As String) As Double
        Dim result As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALDEV
                                        FROM DOCUMENTOS LEFT OUTER JOIN
                                        TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                        WHERE (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODEMBARQUE = @C) AND (TIPODOCUMENTOS.TIPODOC='DEV')", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codembarque)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    result = CType(dr(0), Double)
                Else
                    result = 0
                End If

            Catch ex As Exception
                DesError = ex.ToString
                result = 0
            End Try
        End Using

        Return result

    End Function


    Public Function getPedidosPicking(ByVal codembarque As String) As Double
        Dim result As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT COUNT(DOCUMENTOS.CODDOC) AS PEDIDOS
                                        FROM DOCUMENTOS LEFT OUTER JOIN
                                        TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                        WHERE (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODEMBARQUE = @C) AND (TIPODOCUMENTOS.TIPODOC='FAC')", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codembarque)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    result = CType(dr(0), Double)
                Else
                    result = 0
                End If

            Catch ex As Exception
                DesError = ex.ToString
                result = 0
            End Try
        End Using

        Return result

    End Function


    Public Function getVentasPicking(ByVal codembarque As String) As Double
        Dim result As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALDEV
                                        FROM DOCUMENTOS LEFT OUTER JOIN
                                        TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                        WHERE (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODEMBARQUE = @C) AND (TIPODOCUMENTOS.TIPODOC='FAC')", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codembarque)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    result = CType(dr(0), Double)
                Else
                    result = 0
                End If

            Catch ex As Exception
                DesError = ex.ToString
                result = 0
            End Try
        End Using

        Return result

    End Function


    Public Function putVendedor(ByVal coddoc As String, ByVal inicial As Double, ByVal final As Double, ByVal codven As Integer) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET CODVEN=@C WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO BETWEEN @I AND @F", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codven)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@I", inicial)
                cmd.Parameters.AddWithValue("@F", final)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function


    Public Function putEmbarque(ByVal coddoc As String, ByVal inicial As Double, ByVal final As Double, ByVal codembarque As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET CODEMBARQUE=@C WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO BETWEEN @I AND @F", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codembarque)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@I", inicial)
                cmd.Parameters.AddWithValue("@F", final)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function tblListaFacturas(ByVal coddoc As String, ByVal finicial As Date, ByVal ffinal As Date) As DataTable

        Dim tbl As New DataTable


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS CLIENTE, DOCUMENTOS.DOC_DIRCLIE AS DIRECCION, 
                         DOCUMENTOS.TOTALPRECIO AS IMPORTE, DOCUMENTOS.CODVEN, EMPLEADOS.NOMEMPLEADO AS VENDEDOR, DOCUMENTOS.CODEMBARQUE AS EMBARQUE, DOCUMENTOS.STATUS AS ST
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO
                        WHERE (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODDOC = @D) AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@FI", finicial)
                cmd.Parameters.AddWithValue("@FF", ffinal)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function


    Public Function verifyEmbarque(ByVal codigo As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("SELECT CODEMBARQUE FROM EMBARQUES WHERE EMPNIT=@E AND CODEMBARQUE=@C", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codigo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    r = True
                Else
                    r = False
                End If


            Catch ex As Exception

                DesError = ex.ToString
                r = False

            End Try

        End Using

        Return r
    End Function

    Public Function insertEmbarque(ByVal codigo As String, ByVal descripcion As String, ByVal codrep As Integer, ByVal fecha As Date) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("INSERT INTO EMBARQUES (EMPNIT,CODEMBARQUE, DESCRIPCION, CODREP, FECHA, FINALIZADO, ANIO, MES, USUARIOCREADO) VALUES (@E,@COD,@DES,@R,@F,'NO',@A, @M, @USUARIO)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@COD", codigo)
                cmd.Parameters.AddWithValue("@DES", descripcion)
                cmd.Parameters.AddWithValue("@R", codrep)
                cmd.Parameters.AddWithValue("@F", fecha)
                cmd.Parameters.AddWithValue("@A", fecha.Year)
                cmd.Parameters.AddWithValue("@M", fecha.Month)
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception

                DesError = ex.ToString
                r = False

            End Try

        End Using

        Return r

    End Function

    Public Function editEmbarque(ByVal codigo As String, ByVal descripcion As String, ByVal codrep As Integer, ByVal fecha As Date) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("UPDATE EMBARQUES SET DESCRIPCION=@DES, CODREP=@R, FECHA=@F WHERE EMPNIT=@E AND CODEMBARQUE=@COD", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@COD", codigo)
                cmd.Parameters.AddWithValue("@DES", descripcion)
                cmd.Parameters.AddWithValue("@R", codrep)
                cmd.Parameters.AddWithValue("@F", fecha)
                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception

                DesError = ex.ToString
                r = False

            End Try

        End Using

        Return r

    End Function



    Public Function finalizarEmbarque(ByVal codigo As String, ByVal fecha As Date, ByVal ventas As Double, ByVal devoluciones As Double, ByVal liquidar As Double, ByVal reportado As Double) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE EMBARQUES SET 
            FINALIZADO = 'SI', FECHAFINALIZADO=@FECHAF, TOTALVENTA=@VENTAS, TOTALDEVOLUCIONES=@DEVOLUCIONES, 
            TOTALGASTOS=@GASTOS, ALIQUIDAR=@LIQUIDAR, TOTALREPORTADO=@REPORTADO, DIFERENCIA=@DIFERENCIA, USUARIOFINALIZADO=@USUARIOF
            WHERE EMPNIT=@E AND CODEMBARQUE=@COD", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@COD", codigo)

                cmd.Parameters.AddWithValue("@FECHAF", fecha)
                cmd.Parameters.AddWithValue("@VENTAS", ventas)
                cmd.Parameters.AddWithValue("@DEVOLUCIONES", devoluciones)
                cmd.Parameters.AddWithValue("@GASTOS", 0)
                cmd.Parameters.AddWithValue("@LIQUIDAR", liquidar)
                cmd.Parameters.AddWithValue("@REPORTADO", reportado)
                cmd.Parameters.AddWithValue("@DIFERENCIA", reportado - liquidar)
                cmd.Parameters.AddWithValue("@USUARIOF", GlobalNomUsuario)

                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                DesError = ex.ToString
                r = False

            End Try

        End Using

        Return r

    End Function


    Public Function eliminarEmbarque(ByVal codigo As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM EMBARQUES WHERE EMPNIT=@E AND CODEMBARQUE=@COD", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@COD", codigo)

                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                DesError = ex.ToString
                r = False

            End Try

        End Using

        Return r

    End Function


    Public Function tblEmbarquesFechas(ByVal finicial As Date, ByVal ffinal As Date) As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODEMBARQUE, DESCRIPCION FROM EMBARQUES
                                        WHERE (EMPNIT = @E) AND (FINALIZADO = 'NO') AND (FECHA BETWEEN @FI AND @FF)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@FI", finicial)
                cmd.Parameters.AddWithValue("@FF", ffinal)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                DesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function tblEmbarquesPendientes(ByVal mes As Integer, ByVal anio As Integer) As DataTable

        Dim tbl As New DataSet1.tblEmbarquesDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMBARQUES.CODEMBARQUE, EMBARQUES.DESCRIPCION, EMBARQUES.CODREP AS CODREPARTIDOR, REPARTIDORES.DESREP AS NOMEMPLEADO, EMBARQUES.FECHA, CONCAT(EMBARQUES.CODEMBARQUE, '-',EMBARQUES.DESCRIPCION) AS DESEMBARQUE
                                        FROM EMBARQUES LEFT OUTER JOIN REPARTIDORES ON EMBARQUES.CODREP = REPARTIDORES.CODREP AND EMBARQUES.EMPNIT = REPARTIDORES.EMPNIT
                                        WHERE (EMBARQUES.EMPNIT = @E) AND (EMBARQUES.FINALIZADO = 'NO') AND (EMBARQUES.MES=@M) AND (EMBARQUES.ANIO=@A)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@M", mes)
                cmd.Parameters.AddWithValue("@A", anio)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                DesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function

    Public Function tblEmbarquesFinalizados(ByVal mes As Integer, ByVal anio As Integer) As DataTable
        Dim tbl As New DataSet1.tblEmbarquesDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMBARQUES.CODEMBARQUE, EMBARQUES.DESCRIPCION, EMBARQUES.CODREP AS CODREPARTIDOR, REPARTIDORES.DESREP AS NOMEMPLEADO, EMBARQUES.FECHA, CONCAT(EMBARQUES.CODEMBARQUE, '-',EMBARQUES.DESCRIPCION) AS DESEMBARQUE
                                        FROM EMBARQUES LEFT OUTER JOIN REPARTIDORES ON EMBARQUES.CODREP = REPARTIDORES.CODREP AND EMBARQUES.EMPNIT = REPARTIDORES.EMPNIT
                                        WHERE (EMBARQUES.EMPNIT = @E) AND (EMBARQUES.FINALIZADO = 'SI') AND (EMBARQUES.MES=@M) AND (EMBARQUES.ANIO=@A)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@M", mes)
                cmd.Parameters.AddWithValue("@A", anio)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                DesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function





    Public Function rptEmbarqueProductos(ByVal codembarque As String) As Boolean
        Dim r As Boolean
        Dim tbl As New DSReports.tblRptPickingDataTable

        Dim pedidos As Double
        pedidos = getTotalesPicking(codembarque, "CONTEO")


        Using cn As New SqlConnection(strSqlConectionString)
            Try


                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'CARGA DE TOTAL DOCUMENTOS


                'CARGA DE DATOS DEL PICKING
                Dim sql As String


                sql = "SELECT        DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS TOTALUNIDADES, SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, SUM(DOCPRODUCTOS.TOTALPRECIO) 
                         AS TOTALPRECIO, DOCUMENTOS.CODEMBARQUE, PRODUCTOS.UXC, REPARTIDORES.DESREP AS REPARTIDOR, EMBARQUES.DESCRIPCION AS DESEMBARQUE
FROM            DOCUMENTOS LEFT OUTER JOIN
                         REPARTIDORES RIGHT OUTER JOIN
                         EMBARQUES ON REPARTIDORES.CODREP = EMBARQUES.CODREP AND REPARTIDORES.EMPNIT = EMBARQUES.EMPNIT ON DOCUMENTOS.EMPNIT = EMBARQUES.EMPNIT AND 
                         DOCUMENTOS.CODEMBARQUE = EMBARQUES.CODEMBARQUE LEFT OUTER JOIN
                         PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND 
                         DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.MES = DOCPRODUCTOS.MES AND DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND 
                         DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCUMENTOS.CODEMBARQUE, DOCUMENTOS.EMPNIT, PRODUCTOS.UXC, TIPODOCUMENTOS.TIPODOC, REPARTIDORES.DESREP, DOCUMENTOS.STATUS, 
                         EMBARQUES.DESCRIPCION
HAVING        (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODEMBARQUE = @C) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A')
ORDER BY DOCPRODUCTOS.CODPROD"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codembarque)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim cajas As Double = Math.Truncate(Double.Parse(dr(2)) / Double.Parse(dr(6)))
                    Dim unidades As Double = (Double.Parse(dr(2)) / Double.Parse(dr(6))) - cajas
                    Dim un As Double = CInt(Math.Ceiling(unidades * Double.Parse(dr(6))))
                    tbl.Rows.Add(New Object() {
                        dr(0), 'CODPROD
                        dr(1), 'DESPROD
                        dr(2), 'TOTALUNIDADES
                        dr(3), 'TOTALCOSTO
                        dr(4), 'TOTALPRECIO
                        dr(5), 'CODEMBARQUE
                        dr(6), 'UXC
                        cajas, 'CAJAS
                        un, 'UNIDADES
                        dr(7), 'DES-EMBARQUE
                        dr(8), 'REPARTIDOR
                        pedidos 'TOTAL PEDIDOS / DOCUMENTOS
                    })
                Loop


                r = True
            Catch ex As Exception
                tbl = Nothing
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using


        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim report As New XtraReport
        Dim Adapter As New SqlDataAdapter
        report = New rptPicking

        Try
            report.LoadLayout(Application.StartupPath + "\Reports\EMBARQUE_PRODUCTOS.repx")
        Catch ex As Exception
            report.SaveLayout(Application.StartupPath + "\Reports\EMBARQUE_PRODUCTOS.repx")
            report.LoadLayout(Application.StartupPath + "\Reports\EMBARQUE_PRODUCTOS.repx")
        End Try

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblRptPicking"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()

        SplashScreenManager.CloseForm()

        report.ShowPreview

        Return r

    End Function


    ''' <summary>
    ''' Retorna el total o el conteo de un picking (PARAM: CONTEO=TOTAL DOCS, SUMA=TOTAL VENTA 
    ''' </summary>
    ''' <param name="codembarque"></param>
    ''' <param name="Resultado"></param>
    ''' <returns></returns>
    Public Function getTotalesPicking(ByVal codembarque As String, ByVal Resultado As String) As Double

        Dim conteo, suma As Double

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cm As New SqlCommand("SELECT        COUNT(DOCUMENTOS.CODDOC) AS TOTALDOCUMENTOS, SUM(DOCUMENTOS.TOTALPRECIO) AS TOTALVENTA
                    FROM  DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                    WHERE (DOCUMENTOS.EMPNIT = @E) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.CODEMBARQUE = @C)", cn)
                cm.Parameters.AddWithValue("@E", GlobalEmpNit)
                cm.Parameters.AddWithValue("@C", codembarque)
                Dim d As SqlDataReader = cm.ExecuteReader
                d.Read()
                If d.HasRows = True Then
                    conteo = Double.Parse(d(0))
                    suma = Double.Parse(d(1))
                Else
                    conteo = 0
                    suma = 0
                End If
            Catch ex As Exception
                conteo = 0
                suma = 0

            End Try

        End Using

        If Resultado = "CONTEO" Then
            Return conteo
        End If
        If Resultado = "SUMA" Then
            Return suma
        End If

    End Function

    Public Function rptEmbarqueDocumentos(ByVal codembarque As String) As Boolean
        Dim r As Boolean
        Dim tbl As New DataSet1.tblEmbarqueDocumentosDataTable

        Using cnh As New SqlConnection(strSqlConectionString)
            Try

                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If


                Dim sql As String
                sql = "SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NIT AS NIT, 
                        CONCAT(CLIENTES.NEGOCIO, DOCUMENTOS.DOC_NOMCLIE) AS NOMCLIENTE, 
                        CLIENTES.DIRCLIENTE, CLIENTES.EMAILCLIENTE AS EMAIL, 
                         DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO AS TOTALVENTA, CLIENTES.PROVINCIA AS OBS, DOCUMENTOS.CODEMBARQUE, COUNT(DOCUMENTOS.CODDOC) AS CONTEO, 
                         EMBARQUES.DESCRIPCION AS DESEMBARQUE, CLIENTES.NEGOCIO, CLIENTES.TELEFONOCLIENTE AS TELEFONO, CLIENTES.LATITUDCLIENTE AS LATITUD, CLIENTES.LONGITUDCLIENTE AS LONGITUD
                    FROM CLIENTES RIGHT OUTER JOIN
                         TIPODOCUMENTOS RIGHT OUTER JOIN
                         EMBARQUES RIGHT OUTER JOIN
                         DOCUMENTOS ON EMBARQUES.CODEMBARQUE = DOCUMENTOS.CODEMBARQUE AND EMBARQUES.EMPNIT = DOCUMENTOS.EMPNIT ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                         TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT ON CLIENTES.CODCLIENTE = DOCUMENTOS.CODCLIENTE AND CLIENTES.EMPNIT = DOCUMENTOS.EMPNIT
                    WHERE (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF', 'FEC')) AND (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.STATUS <> 'A')
                    GROUP BY DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, CLIENTES.DIRCLIENTE, CLIENTES.EMAILCLIENTE, DOCUMENTOS.TOTALCOSTO, 
                         DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.CODEMBARQUE, EMBARQUES.DESCRIPCION, CLIENTES.PROVINCIA, CLIENTES.TELEFONOCLIENTE, CLIENTES.NEGOCIO, CLIENTES.LATITUDCLIENTE, 
                         CLIENTES.LONGITUDCLIENTE
                    HAVING (DOCUMENTOS.CODEMBARQUE = @C)"

                Dim cmd As New SqlCommand(sql, cnh)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codembarque)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim objRpt As New ClassReports
                objRpt.getReport(tbl, New rptPickingDocumentos, False, "EMBARQUE_DOCUMENTOS")

                r = True
            Catch ex As Exception
                MsgBox("ERROR: " & ex.ToString)
                r = False
            End Try
        End Using

        Return r

    End Function


    Public Function rptEmbarqueBoletas(ByVal codembarque As String, ByVal formato As String) As Boolean
        Dim r As Boolean
        Dim tbl As New DataSet1.tblEmbarquesBoletasDataTable

        Using cnh As New SqlConnection(strSqlConectionString)
            Try


                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If


                Dim qry As String = ""
                qry = "SELECT DOCUMENTOS.FECHA, 
                        DOCUMENTOS.CODDOC, 
                        DOCUMENTOS.CORRELATIVO, 
                        DOCUMENTOS.DOC_NIT AS NIT, 
                        DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                        CLIENTES.DIRCLIENTE, 
                        CLIENTES.EMAILCLIENTE AS EMAIL, 
                        DOCUMENTOS.TOTALPRECIO AS TOTALVENTA, 
                        DOCUMENTOS.OBS, 
                        DOCUMENTOS.CODEMBARQUE, 
                        CLIENTES.LATITUDCLIENTE AS LAT, 
                        CLIENTES.LONGITUDCLIENTE AS LONG, 
                        REPARTIDORES.DESREP, 
                        EMPLEADOS.NOMEMPLEADO AS NOMVEN, 
                        DOCPRODUCTOS.CODPROD, 
                        DOCPRODUCTOS.DESPROD, 
                        DOCPRODUCTOS.CODMEDIDA, 
                        DOCPRODUCTOS.CANTIDAD, 
                        DOCPRODUCTOS.PRECIO, 
                        DOCPRODUCTOS.TOTALPRECIO, 
                        PRODUCTOS.UXC, 
                        DOCPRODUCTOS.TOTALUNIDADES, 
                        CLIENTES.CODCLIENTE, 
                        CLIENTES.PROVINCIA AS REFERENCIA, 
                        CONCAT(CLIENTES.TIPONEGOCIO, ' ', CLIENTES.NEGOCIO) AS NEGOCIO
                    FROM  PRODUCTOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         EMPLEADOS RIGHT OUTER JOIN
                         DOCUMENTOS ON EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT AND EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN LEFT OUTER JOIN
                         REPARTIDORES RIGHT OUTER JOIN
                         EMBARQUES ON REPARTIDORES.CODREP = EMBARQUES.CODREP AND REPARTIDORES.EMPNIT = EMBARQUES.EMPNIT ON DOCUMENTOS.CODEMBARQUE = EMBARQUES.CODEMBARQUE AND 
                         DOCUMENTOS.EMPNIT = EMBARQUES.EMPNIT ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                         DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO LEFT OUTER JOIN
                         CLIENTES ON DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE AND DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                    WHERE  (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODEMBARQUE = @C) AND (DOCUMENTOS.STATUS <> 'A')"

                Dim cmd As New SqlCommand(qry, cnh)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codembarque)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Dim cajas As Integer = CInt(Fix(Double.Parse(dr(21)) / Double.Parse(dr(20))))
                    Dim unidades As Integer = CInt(((Double.Parse(dr(21)) / Double.Parse(dr(20))) - cajas) * Integer.Parse(dr(20)))
                    tbl.Rows.Add(New Object() {
                                dr(0),'fecha
                                dr(1),'coddoc
                                dr(2),'correlativo
                                dr(3),'nit
                                dr(4),'nomcliente
                                dr(5),'dircliente
                                dr(6),'email
                                dr(7),'totalventa
                                dr(8),'obs
                                dr(9),'codembarque
                                dr(10),'lat
                                dr(11),'long
                                dr(12),'desrep
                                dr(13),'nomven
                                dr(14),'codprod
                                dr(15),'desprod
                                dr(16),'codmedida
                                dr(17),'cantidad
                                dr(18),'precio
                                dr(19), 'totalprecio     
                                dr(20), 'uxc
                                dr(21), 'total unidades     
                                cajas,'Embarque cajas
                                unidades, 'Embarque unidades
                                dr(23), 'REFERENCIA
                                dr(24), 'NEGOCIO
                    Integer.Parse(dr(22)) 'CODCLIENTE            
                    })
                Loop

                'Dim da As New SqlDataAdapter
                'da.SelectCommand = cmd
                'da.Fill(tbl)

                Dim objRpt As New ClassReports
                Select Case formato
                    Case "BOLETA"
                        objRpt.getReport(tbl, New rptPickingBoletas, False, "EMBARQUE_BOLETAS")
                    Case "TICKET"
                        objRpt.getReport(tbl, New rptPickingTicket, False, "EMBARQUE_TICKET")
                    Case Else
                        objRpt.getReport(tbl, New rptPickingBoletas, False, "EMBARQUE_BOLETAS")
                End Select


                r = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using

        Return r

    End Function



End Class
