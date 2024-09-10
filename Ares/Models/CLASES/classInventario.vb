
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class classInventario

    Sub New(ByVal _empnit As String, ByVal _aniocurso As Integer, ByVal _mescurso As Integer)
        empnit = _empnit
        anio = _aniocurso
        mes = _mescurso
    End Sub

    Dim empnit As String, anio As Integer, mes As Integer

#Region " ** CATALOGOS ** "
    Public Function getTblBodegas() As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODBODEGA AS CODIGO, DESBODEGA AS DESCRIPCION FROM BODEGAS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl
    End Function
#End Region


#Region " ** VENCIDOS ** "

    Public Function ObtenerTotalProductos(ByVal _fechacontrol As Date) As Double
        Dim result As Double = 0
        Dim fechaControl, fechavencimiento As Date
        fechaControl = _fechacontrol

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.VENCIMIENTO, INVSALDO.SALDO
                                            FROM INVSALDO LEFT OUTER JOIN PRODUCTOS ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                                            WHERE (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                Do While dr.Read
                    fechavencimiento = Date.Parse(dr(2))
                    If fechavencimiento <= fechaControl Then
                        result = result + 1
                    End If
                Loop

                cmd.Dispose()

                'MsgBox("lectura ejecutada: " & result)
            Catch ex As Exception
                GlobalDesError = ex.ToString
                'MsgBox(GlobalDesError)

                result = 0
            End Try

            Return result

        End Using

    End Function


    Public Function tblProductosVencidos(ByVal _fechacontrol As Date) As DataTable
        Dim tbl As New DataSetInventarios.tblVencidosDataTable
        Dim fechavencimiento, fechaControl As Date
        fechaControl = _fechacontrol

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.VENCIMIENTO, INVSALDO.SALDO
                                            FROM INVSALDO LEFT OUTER JOIN PRODUCTOS ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                                            WHERE (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                Do While dr.Read
                    fechavencimiento = Date.Parse(dr(2))
                    If fechavencimiento <= fechaControl Then
                        tbl.Rows.Add(New Object() {
                                     dr(0),
                                     dr(1),
                                     dr(3),
                                     dr(4)
                                     })
                    End If
                Loop

                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

            cn.Close()

        End Using

        Return tbl


    End Function


    Public Function tblProductosVencidosTodos() As DataTable
        Dim tbl As New DataSetInventarios.tblVencidosDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.VENCIMIENTO, INVSALDO.SALDO
                                            FROM INVSALDO LEFT OUTER JOIN PRODUCTOS ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                                            WHERE (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                         dr(0),
                         dr(1),
                         dr(3),
                         dr(4)
                         })
                Loop

                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

            cn.Close()

        End Using

        Return tbl
    End Function
#End Region

#Region " ** MINIMOS Y MAXIMOS ** "


    Public Function UpdateMinimoMaximo(ByVal codprod As String, ByVal invminimo As Double, ByVal invmaximo As Double) As Boolean
        Dim result As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET INVMINIMO=@INVMINIMO, INVMAXIMO=@INVMAXIMO WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@INVMINIMO", invminimo)
                cmd.Parameters.AddWithValue("@INVMAXIMO", invmaximo)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using


        Return result
    End Function
    Public Function ObtenerTotalMinimos() As Double
        Dim result As Double = 0
        'Dim saldo, minimo As Integer

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, INVSALDO.SALDO, PRODUCTOS.INVMINIMO, INVSALDO.EMPNIT, INVSALDO.ANIO, INVSALDO.MES
                                            FROM INVSALDO LEFT OUTER JOIN PRODUCTOS ON INVSALDO.CODPROD = PRODUCTOS.CODPROD AND INVSALDO.EMPNIT = PRODUCTOS.EMPNIT
                                            WHERE (INVSALDO.SALDO<=PRODUCTOS.INVMINIMO) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) AND (INVSALDO.EMPNIT = @EMPNIT)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                Do While dr.Read
                    'saldo = Integer.Parse(dr(1))
                    'minimo = Integer.Parse(dr(2))
                    'If saldo <= minimo Then
                    result = result + 1
                    'End If
                Loop

                cmd.Dispose()

                'MsgBox("lectura ejecutada: " & result)
            Catch ex As Exception
                GlobalDesError = ex.ToString
                'MsgBox(GlobalDesError)

                result = 0
            End Try

            Return result

        End Using

    End Function


    Public Function tblProductosAgotados() As DataTable
        Dim tbl As New DataSetInventarios.tblMinimosDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.INVMINIMO AS MINIMO, PRODUCTOS.INVMAXIMO AS MAXIMO, INVSALDO.SALDO, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.EMPNIT, INVSALDO.ANIO, INVSALDO.MES
                                            FROM INVSALDO LEFT OUTER JOIN PRODUCTOS ON INVSALDO.CODPROD = PRODUCTOS.CODPROD AND INVSALDO.EMPNIT = PRODUCTOS.EMPNIT
                                            WHERE (INVSALDO.SALDO<=PRODUCTOS.INVMINIMO) AND (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

            cn.Close()

        End Using

        Return tbl
    End Function

    Public Function tblProductosAgotadosTodos() As DataTable
        Dim tbl As New DataSetInventarios.tblMinimosDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.INVMINIMO AS MINIMO, PRODUCTOS.INVMAXIMO AS MAXIMO, INVSALDO.SALDO, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.EMPNIT, INVSALDO.ANIO, INVSALDO.MES
                                            FROM INVSALDO LEFT OUTER JOIN PRODUCTOS ON INVSALDO.CODPROD = PRODUCTOS.CODPROD AND INVSALDO.EMPNIT = PRODUCTOS.EMPNIT
                                            WHERE (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

            cn.Close()

        End Using

        Return tbl
    End Function

#End Region

    ''' <summary>
    ''' Deja las existencias a cero en el mes y año seleccionados
    ''' </summary>
    ''' <returns>boolean</returns>
    Public Function fcn_existencias_cero() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE INVSALDO SET SALDOINICIAL=0, ENTRADAS=0, SALIDAS=0, SALDO=0", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function fcn_deletebakcu_invsaldo() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("DELETE FROM INVSALDO WHERE EMPNIT LIKE 'BAKCU%'", cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function fcn_actu_invfsya(ByVal empnit As String) As Boolean

        Dim result As Boolean

        Call fcn_deletebakcu_invsaldo()
        Call fcn_existencias_cero()

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE           INVSALDO
                                           SET              SALDO = T.SALDO, ENTRADAS = T.ENTRADAS, SALIDAS = T.SALIDAS
                                           FROM             INVSALDO INNER JOIN (SELECT  		DOCPRODUCTOS.CODPROD,
                                                            isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				                                                   WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                                                                   WHEN 'FEF' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                                                                   WHEN 'FEC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                                                                   WHEN 'FES' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
				                                                   WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
                                                                   WHEN 'TSL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
                                                                   WHEN 'TSS' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
                                                                   WHEN 'DEV' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'FNC' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'INF' THEN DOCPRODUCTOS.TOTALUNIDADES 
				                                                   WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				                                                   WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'TIN' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'TES' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'ORP' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                                                      END),0) AS SALDO,

                                                            isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC
                                                                   WHEN 'INF' THEN DOCPRODUCTOS.TOTALUNIDADES  
				                                                   WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				                                                   WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES 
                                                                   WHEN 'TIN' THEN DOCPRODUCTOS.TOTALUNIDADES 
                                                                   WHEN 'TES' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'ORP' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'DEV' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'FNC' THEN DOCPRODUCTOS.TOTALUNIDADES   
                                                                                                      END),0) AS ENTRADAS, 

                                                            isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				                                                   WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'FEF' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'FEC' THEN DOCPRODUCTOS.TOTALUNIDADES
                                                                   WHEN 'FES' THEN DOCPRODUCTOS.TOTALUNIDADES
				                                                   WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES 
                                                                   WHEN 'TSL' THEN DOCPRODUCTOS.TOTALUNIDADES 
                                                                   WHEN 'TSS' THEN DOCPRODUCTOS.TOTALUNIDADES 
                                                                                                      END),0) AS SALIDAS

				                                            FROM   DOCPRODUCTOS LEFT OUTER JOIN
                                                                   DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                                                                   DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                                                                   TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                                            WHERE  (DOCPRODUCTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS <> 'A')
				                                            GROUP BY DOCPRODUCTOS.CODPROD) T ON INVSALDO.CODPROD = T.CODPROD", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    '******************************************************************
    '** CARGA UN REPORTE CON LA TABLA TEMP DEL MOVIMIENTO DE INVENTARIO
    '******************************************************************
    Public Function rpt_temp_movinv(ByVal coddoc As String, ByVal correlativo As Double, ByVal fecha As Date) As Boolean
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim result As Boolean
        Dim report As New XtraReportMOVINV


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
        End With


        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("REPORTES_TEMP_MOVINV_PREVIEW", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                'cmd.Parameters.AddWithValue("@ANIO", anio)
                'cmd.Parameters.AddWithValue("@MES", mes)
                'cmd.Parameters.AddWithValue("@FECHA", fecha)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                  dr(0).ToString,'EMPRESA
                                  fecha,'Date.Parse(dr(1)),'FECHA
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
                                  GlobalNomUsuario,'dr(12).ToString,'USUARIO
                                  dr(13).ToString,'DESDOC
                                  dr(14).ToString 'OBS
                                    })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter
                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblTicket"
                'report.LoadLayout(Application.StartupPath + "\Reports\MOVINV.repx")
                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()

        End Using

        SplashScreenManager.CloseForm()
        If result = True Then
            report.ShowPreview
        End If

        Return result

    End Function


    '******************************************************************
    '   MOVIMIENTO DE INVENTARIO DEL HOST   ------      NO FUNCIONA
    '******************************************************************
    Public Function rpt_temp_movinvHost(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim result As Boolean
        Dim report As New XtraReportMOVINV


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
        End With


        Using cnh As New SqlConnection(strHostConectionString)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT EMPRESAS.EMPNOMBRE, DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, 
                         DOCPRODUCTOS.CANTIDAD, DOCPRODUCTOS.COSTO, DOCPRODUCTOS.PRECIO, DOCPRODUCTOS.TOTALCOSTO, DOCPRODUCTOS.TOTALPRECIO, DOCUMENTOS.USUARIO, 
                         TIPODOCUMENTOS.DESDOC, DOCUMENTOS.OBS, DOCPRODUCTOS.CANTIDADBONIF,DOCPRODUCTOS.TOTALBONIF,DOCPRODUCTOS.TOTALUNIDADES
                        FROM            DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         DOCPRODUCTOS ON DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.MES = DOCPRODUCTOS.MES AND 
                         DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                         EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (DOCUMENTOS.DIA = @DIA) AND (DOCUMENTOS.CODDOC = @CODDOC) AND 
                         (DOCUMENTOS.CORRELATIVO = @CORRELATIVO)", cnh)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@TOKEN", Token)

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
                                  GlobalNomUsuario,'dr(12).ToString,'USUARIO
                                  dr(13).ToString,'DESDOC
                                  "Pendiente de Cargar. " & dr(14).ToString 'OBS
                                    })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter
                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = "tblTicket"
                'report.LoadLayout(Application.StartupPath + "\Reports\MOVINV.repx")
                Dim tool As ReportPrintTool = New ReportPrintTool(report)
                report.CreateDocument()

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()

        End Using

        SplashScreenManager.CloseForm()
        If result = True Then
            report.ShowPreview
        End If

        Return result

    End Function



    '******************************************************************
    '** VERIFICACION DE INVENTARIO CERRADO
    '******************************************************************

    Public Function fcn_VerificarCierreInventario() As Integer

        'si retorna 0 = ERROR
        'si retorna 1 = EXISTE EL REGISTRO
        'si retorna 2 = NO EXISTE EL REGISTRO
        Dim result As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmdVerficar As New SqlCommand("SELECT EMPNIT, ANIO, MES FROM INVCIERRES WHERE EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES", cn)
                cmdVerficar.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdVerficar.Parameters.AddWithValue("@ANIO", anio)
                cmdVerficar.Parameters.AddWithValue("@MES", mes)
                Dim drVerificar As SqlDataReader = cmdVerficar.ExecuteReader
                drVerificar.Read()
                If drVerificar.HasRows Then
                    result = 1
                Else
                    result = 2
                End If

                drVerificar.Close()
                drVerificar.Dispose()
                cmdVerficar.Dispose()


            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = 0

            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function fcn_InsertarCierreInventario() As Boolean

        Dim result As Boolean

        Call AbrirConexionSql()

        Try
            Dim cmdInsertCierre As New SqlCommand("INSERT INTO INVCIERRES (EMPNIT,ANIO,MES) VALUES (@EMPNIT,@ANIO,@MES)", cn)
            cmdInsertCierre.Parameters.AddWithValue("@EMPNIT", empnit)
            cmdInsertCierre.Parameters.AddWithValue("@ANIO", anio)
            cmdInsertCierre.Parameters.AddWithValue("@MES", mes)
            cmdInsertCierre.ExecuteNonQuery()
            cmdInsertCierre.Dispose()

            result = True

        Catch ex As Exception

            result = False

        End Try

        cn.Close()

        Return result

    End Function



    '******************************************************************
    '** ACTUALIZACION DE INVENTARIO 
    '******************************************************************


    '******* ACTUALIZAR MES *****************
    '****************************************

    Dim invSaldoInicial As Double = 0


    ''' <summary>
    ''' Actualiza el inventario según entradas y salidas = opciones=mes (para actualizar solo mes) anio (para todo el año)
    ''' </summary>
    ''' <param name="mesanio"></param>
    ''' <returns></returns>
    Public Function fcn_ActualizarInventarioMes(ByVal mesanio As String) As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmdleerproductos As New SqlCommand("SELECT CODPROD, SALDOINICIAL FROM INVSALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT", cn)
                cmdleerproductos.Parameters.AddWithValue("@ANIO", anio)
                cmdleerproductos.Parameters.AddWithValue("@MES", mes)
                cmdleerproductos.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdleerproductos.CommandTimeout = 0
                Dim drleerproductos As SqlDataReader = cmdleerproductos.ExecuteReader

                Do While drleerproductos.Read

                    invSaldoInicial = Double.Parse(drleerproductos(1))
                    'obtengo los datos del saldo del inventario
                    If ObtenerInventarioProducto(drleerproductos(0).ToString, mesanio) = True Then
                        'creo la actualizacion
                        If ActualizarTablaInventario(drleerproductos(0).ToString, invSalidas, invEntradas, invSaldo) = True Then

                        End If
                    End If

                Loop

                Return True

            Catch ex As Exception

                MsgBox(ex.ToString)
                Return False

            End Try


        End Using
    End Function


    Dim invEntradas As Double = 0
    Dim invSalidas As Double = 0
    Dim invSaldo As Double = 0


    'OBTIENE EL INVENTARIO ACTUAL DEL PRODUCTO EN BASE A UNA OPERACION BASTANTE COMPLEJA
    Private Function ObtenerInventarioProducto(ByVal codprod As String, ByVal mesanio As String) As Boolean

        Call AbrirConexionSql()

        Dim result As Boolean

        Dim Existencia As Double = 0

        Try

            Dim SQL As String

            If mesanio = "mes" Then
                SQL = "SELECT  	
                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'FEF' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'FEC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'FES' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'TSL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'TSS' THEN DOCPRODUCTOS.TOTALUNIDADES *-1

                WHEN 'DEV' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FNC' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'INF' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TIN' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TES THEN DOCPRODUCTOS.TOTALUNIDADES 
                END),0) AS SALDO,

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
                WHEN 'INF' THEN DOCPRODUCTOS.TOTALUNIDADES
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TIN' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'TES' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'DEV' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FNC' THEN DOCPRODUCTOS.TOTALUNIDADES  
                END),0) AS ENTRADAS, 

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FEF' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FEC' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FES' THEN DOCPRODUCTOS.TOTALUNIDADES
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TSL' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TSS' THEN DOCPRODUCTOS.TOTALUNIDADES 
                END),0) AS SALIDAS

					FROM  DOCPRODUCTOS LEFT OUTER JOIN
                      DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                      DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                      TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                WHERE (DOCPRODUCTOS.EMPNIT = @EMPNIT) AND (DOCPRODUCTOS.CODPROD = @CODPROD) AND (DOCUMENTOS.STATUS <> 'A')"
            End If

            If mesanio = "anio" Then
                SQL = "SELECT  	
                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'FEF' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'FEC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
                WHEN 'FES' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
                WHEN 'TSL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
                WHEN 'TSS' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
                WHEN 'DEV' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FNC' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'INF' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'TIN' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'TES' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'ORP' THEN DOCPRODUCTOS.TOTALUNIDADES
                END),0) AS SALDO,

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC
                WHEN 'INF' THEN DOCPRODUCTOS.TOTALUNIDADES  
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TIN' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TES' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'ORP' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'DEV' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FNC' THEN DOCPRODUCTOS.TOTALUNIDADES   
                END),0) AS ENTRADAS, 

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FEF' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FEC' THEN DOCPRODUCTOS.TOTALUNIDADES
                WHEN 'FES' THEN DOCPRODUCTOS.TOTALUNIDADES
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TSL' THEN DOCPRODUCTOS.TOTALUNIDADES 
                WHEN 'TSS' THEN DOCPRODUCTOS.TOTALUNIDADES 
                END),0) AS SALIDAS

				FROM  DOCPRODUCTOS LEFT OUTER JOIN
                      DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                      DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                      TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                WHERE (DOCPRODUCTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS <> 'A')"


            End If



            Dim cmdObtenerInventarioProducto As New SqlCommand(SQL, cn)
            cmdObtenerInventarioProducto.Parameters.AddWithValue("@EMPNIT", empnit)
            cmdObtenerInventarioProducto.Parameters.AddWithValue("@ANIO", anio)
            cmdObtenerInventarioProducto.Parameters.AddWithValue("@MES", mes)
            cmdObtenerInventarioProducto.Parameters.AddWithValue("@CODPROD", codprod)
            Dim drObtenerInventarioProducto As SqlDataReader = cmdObtenerInventarioProducto.ExecuteReader
            drObtenerInventarioProducto.Read()

            If drObtenerInventarioProducto.HasRows Then
                invSaldo = Double.Parse(drObtenerInventarioProducto(0)) + invSaldoInicial
                invEntradas = Double.Parse(drObtenerInventarioProducto(1))
                invSalidas = Double.Parse(drObtenerInventarioProducto(2))
            End If
            drObtenerInventarioProducto.Close()
            cmdObtenerInventarioProducto.Dispose()

            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            ' MsgBox(GlobalDesError)
            result = False

        End Try

        Return result

    End Function

    'ACTUALIZA LA TABLA DE INVENTARIOS CON EL SALDO ACTUAL
    Private Function ActualizarTablaInventario(ByVal codprod As String, ByVal salidas As Double, ByVal entradas As Double, ByVal saldo As Double) As Boolean
        Call AbrirConexionSql()

        Try
            'Dim cmdUpdateInvsaldo As New SqlCommand("UPDATE INVSALDO SET SALDO=@SALDO WHERE EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES AND CODPROD=@CODPROD", cn)
            Dim cmdUpdateInvsaldo As New SqlCommand("UPDATE INVSALDO SET SALDO=@SALDO,ENTRADAS=@ENTRADAS,SALIDAS=@SALIDAS WHERE EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES AND CODPROD=@CODPROD", cn)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@EMPNIT", empnit)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@ANIO", anio)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@MES", mes)

            cmdUpdateInvsaldo.Parameters.AddWithValue("@CODPROD", codprod)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@SALDO", saldo)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@ENTRADAS", entradas)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@SALIDAS", salidas)
            cmdUpdateInvsaldo.ExecuteNonQuery()
            cmdUpdateInvsaldo.Dispose()

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            Return False
        End Try

    End Function


    '****************************************
    '****************************************


    '******** ACTUALIZAR COMPLETO **************
    '*******************************************

    Public Function fcn_ActualizarInventarioTotal() As Boolean

        Call AbrirConexionSql()

        Try


            Dim cmdleerproductos As New SqlCommand("SELECT CODPROD FROM INVSALDO WHERE EMPNIT=@EMPNIT", cn)
            'cmdleerproductos.Parameters.AddWithValue("@ANIO", anio)
            'cmdleerproductos.Parameters.AddWithValue("@MES", mes)
            cmdleerproductos.Parameters.AddWithValue("@EMPNIT", empnit)
            Dim drleerproductos As SqlDataReader = cmdleerproductos.ExecuteReader
            Do While drleerproductos.Read
                'obtengo los datos del saldo del inventario
                If ObtenerInventarioProductoTotal(drleerproductos(0).ToString) = True Then
                    'creo la actualizacion
                    If ActualizarTablaInventarioTotal(drleerproductos(0).ToString, invSalidas, invEntradas, invSaldo) = True Then

                    End If
                End If

            Loop

            Return True

        Catch ex As Exception

            MsgBox(ex.ToString)
            Return False

        End Try

        cn.Close()

    End Function




    'OBTIENE EL INVENTARIO ACTUAL DEL PRODUCTO EN BASE A UNA OPERACION BASTANTE COMPLEJA
    Private Function ObtenerInventarioProductoTotal(ByVal codprod As String) As Boolean

        Call AbrirConexionSql()
        Dim Existencia As Double = 0

        Try

            Dim SQLold As String
            SQLold = "SELECT  	
                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES END),0) AS SALDO,

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES END),0) AS ENTRADAS, 

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES END),0) AS SALIDAS

				FROM DOCPRODUCTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
				WHERE DOCPRODUCTOS.EMPNIT=@EMPNIT AND DOCPRODUCTOS.CODPROD=@CODPROD"


            Dim SQL As String
            SQL = "SELECT  	
                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES *-1
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES *-1 
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES END),0) AS SALDO,

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'COM' THEN DOCPRODUCTOS.TOTALUNIDADES 
				WHEN 'ENT' THEN DOCPRODUCTOS.TOTALUNIDADES END),0) AS ENTRADAS, 

                isnull(SUM(CASE TIPODOCUMENTOS.TIPODOC 
				WHEN 'FAC' THEN DOCPRODUCTOS.TOTALUNIDADES
				WHEN 'SAL' THEN DOCPRODUCTOS.TOTALUNIDADES END),0) AS SALIDAS

				FROM  DOCPRODUCTOS LEFT OUTER JOIN
                      DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                      DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                      TIPODOCUMENTOS ON DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                WHERE (DOCPRODUCTOS.EMPNIT = @EMPNIT) AND (DOCPRODUCTOS.CODPROD = @CODPROD) AND (DOCUMENTOS.STATUS <> 'A')"

            Dim cmdObtenerInventarioProducto As New SqlCommand(SQL, cn)
            cmdObtenerInventarioProducto.Parameters.AddWithValue("@EMPNIT", empnit)
            cmdObtenerInventarioProducto.Parameters.AddWithValue("@CODPROD", codprod)
            Dim drObtenerInventarioProducto As SqlDataReader = cmdObtenerInventarioProducto.ExecuteReader
            drObtenerInventarioProducto.Read()

            If drObtenerInventarioProducto.HasRows Then
                invSaldo = Double.Parse(drObtenerInventarioProducto(0))
                invEntradas = Double.Parse(drObtenerInventarioProducto(1))
                invSalidas = Double.Parse(drObtenerInventarioProducto(2))
            End If
            drObtenerInventarioProducto.Close()
            cmdObtenerInventarioProducto.Dispose()

            Return True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            ' MsgBox(GlobalDesError)

            Return False

        End Try

    End Function

    'ACTUALIZA LA TABLA DE INVENTARIOS CON EL SALDO ACTUAL
    Private Function ActualizarTablaInventarioTotal(ByVal codprod As String, ByVal salidas As Double, ByVal entradas As Double, ByVal saldo As Double) As Boolean
        Call AbrirConexionSql()

        Try
            'Dim cmdUpdateInvsaldo As New SqlCommand("UPDATE INVSALDO SET SALDO=@SALDO WHERE EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES AND CODPROD=@CODPROD", cn)
            Dim cmdUpdateInvsaldo As New SqlCommand("UPDATE INVSALDO SET SALDO=@SALDO,ENTRADAS=@ENTRADAS,SALIDAS=@SALIDAS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@EMPNIT", empnit)

            cmdUpdateInvsaldo.Parameters.AddWithValue("@CODPROD", codprod)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@SALDO", saldo)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@ENTRADAS", entradas)
            cmdUpdateInvsaldo.Parameters.AddWithValue("@SALIDAS", salidas)
            cmdUpdateInvsaldo.ExecuteNonQuery()
            cmdUpdateInvsaldo.Dispose()

            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            Return False
        End Try



    End Function





    '**********************************************************************
    '** RUTINAS PARA TRATAR LAS SALIDAS DE INVENTARIO
    '**********************************************************************

    ''' <summary>
    ''' Crea una salida de inventario en base al codigo de producto
    ''' </summary>
    ''' <param name="codprod"></param>
    ''' <param name="unidadesdescontar"></param>
    ''' <returns>boolean</returns>
    Public Function fcn_InsertarSalidaProducto(ByVal codprod As String, ByVal unidadesdescontar As Double, Optional codbodega As Integer = 1) As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'variables
                Dim valSaldo, valSalidas As Double

                'obtener datos del inventario (salidas y saldo)
                Dim cmd1 As New SqlCommand("SELECT SALDO, SALIDAS FROM INVSALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.Parameters.AddWithValue("@ANIO", anio)
                cmd1.Parameters.AddWithValue("@MES", mes)
                cmd1.Parameters.AddWithValue("@CODPROD", codprod)

                Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                dr1.Read()
                If dr1.HasRows Then
                    valSaldo = Double.Parse(dr1(0))
                    valSalidas = Double.Parse(dr1(1))
                End If

                cmd1.Dispose()

                'ejecutar la actualización
                Dim cmd2 As New SqlCommand("UPDATE INVSALDO SET SALIDAS=@SALIDAS, SALDO=@SALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd2.Parameters.AddWithValue("@ANIO", anio)
                cmd2.Parameters.AddWithValue("@MES", mes)
                cmd2.Parameters.AddWithValue("@CODPROD", codprod)
                cmd2.Parameters.AddWithValue("@SALDO", valSaldo - unidadesdescontar)
                cmd2.Parameters.AddWithValue("@SALIDAS", valSalidas + unidadesdescontar)
                cmd2.ExecuteNonQuery()
                cmd2.Dispose()

                Return True

            Catch ex As Exception

                MsgBox("Error al crear salida de inventario. Error: " & ex.ToString)
                Return False

            End Try

        End Using

    End Function


    ''' <summary>
    ''' Retorna una salida de inventario, sirve cuando se elimina un movimiento que haya creado una salida de inventario
    ''' </summary>
    ''' <param name="codprod"></param>
    ''' <param name="unidadesintegrar"></param>
    ''' <returns>boolean</returns>
    Public Function fcn_RegresarSalidaProducto(ByVal codprod As String, ByVal unidadesintegrar As Double) As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'variables
                Dim valSaldo, valSalidas As Double

                'obtener datos del inventario (salidas y saldo)
                Dim cmd1 As New SqlCommand("SELECT SALDO, SALIDAS FROM INVSALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.Parameters.AddWithValue("@ANIO", anio)
                cmd1.Parameters.AddWithValue("@MES", mes)
                cmd1.Parameters.AddWithValue("@CODPROD", codprod)

                Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                dr1.Read()
                If dr1.HasRows Then
                    valSaldo = Double.Parse(dr1(0))
                    valSalidas = Double.Parse(dr1(1))
                End If
                dr1.Close()
                cmd1.Dispose()

                'ejecutar la actualización
                Dim cmd2 As New SqlCommand("UPDATE INVSALDO SET SALIDAS=@SALIDAS, SALDO=@SALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd2.Parameters.AddWithValue("@ANIO", anio)
                cmd2.Parameters.AddWithValue("@MES", mes)
                cmd2.Parameters.AddWithValue("@CODPROD", codprod)
                cmd2.Parameters.AddWithValue("@SALDO", valSaldo + unidadesintegrar)
                cmd2.Parameters.AddWithValue("@SALIDAS", valSalidas - unidadesintegrar)
                cmd2.ExecuteNonQuery()
                cmd2.Dispose()

                Return True
            Catch ex As Exception
                MsgBox("Error al regresar salida de inventario. Error: " & ex.ToString)
                Return False

            End Try

        End Using
    End Function


    '**********************************************************************
    '** RUTINAS PARA TRATAR LOS INGRESOS DE INVENTARIO
    '**********************************************************************


    ''' <summary>
    ''' Crea un ingreso de inventario
    ''' </summary>
    ''' <param name="codprod"></param>
    ''' <param name="unidadesentrada"></param>
    ''' <returns>boolean</returns>
    Public Function fcn_InsertarEntradaProducto(ByVal codprod As String, ByVal unidadesentrada As Double) As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                'variables
                Dim valSaldo, valEntradas As Double

                'obtener datos del inventario (entradas y saldo)
                Dim cmd1 As New SqlCommand("SELECT SALDO, ENTRADAS FROM INVSALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.Parameters.AddWithValue("@ANIO", anio)
                cmd1.Parameters.AddWithValue("@MES", mes)
                cmd1.Parameters.AddWithValue("@CODPROD", codprod)

                Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                dr1.Read()
                If dr1.HasRows Then
                    valSaldo = Double.Parse(dr1(0))
                    valEntradas = Double.Parse(dr1(1))
                End If

                cmd1.Dispose()

                'ejecutar la actualización
                Dim cmd2 As New SqlCommand("UPDATE INVSALDO SET ENTRADAS=@ENTRADAS, SALDO=@SALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd2.Parameters.AddWithValue("@ANIO", anio)
                cmd2.Parameters.AddWithValue("@MES", mes)
                cmd2.Parameters.AddWithValue("@CODPROD", codprod)
                cmd2.Parameters.AddWithValue("@SALDO", valSaldo + unidadesentrada)
                cmd2.Parameters.AddWithValue("@ENTRADAS", valEntradas + unidadesentrada)
                cmd2.ExecuteNonQuery()
                cmd2.Dispose()

                Return True
            Catch ex As Exception
                MsgBox("Error al insertar entrada de inventario. Error: " & ex.ToString)
                Return False

            End Try
        End Using

    End Function


    ''' <summary>
    ''' Reintegra un ingreso de inventario que se haya creado
    ''' </summary>
    ''' <param name="codprod"></param>
    ''' <param name="unidadesentrada"></param>
    ''' <returns>boolean</returns>
    Public Function fcn_RegresarEntradaProducto(ByVal codprod As String, ByVal unidadesentrada As Double) As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                'variables
                Dim valSaldo, valEntradas As Double

                'obtener datos del inventario (salidas y saldo)
                Dim cmd1 As New SqlCommand("SELECT SALDO, ENTRADAS FROM INVSALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.Parameters.AddWithValue("@ANIO", anio)
                cmd1.Parameters.AddWithValue("@MES", mes)
                cmd1.Parameters.AddWithValue("@CODPROD", codprod)

                Dim dr1 As SqlDataReader = cmd1.ExecuteReader
                dr1.Read()
                If dr1.HasRows Then
                    valSaldo = Double.Parse(dr1(0))
                    valEntradas = Double.Parse(dr1(1))
                End If
                dr1.Close()
                cmd1.Dispose()

                'ejecutar la actualización
                Dim cmd2 As New SqlCommand("UPDATE INVSALDO SET ENTRADAS=@ENTRADAS, SALDO=@SALDO WHERE ANIO=@ANIO AND MES=@MES AND EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd2.Parameters.AddWithValue("@ANIO", anio)
                cmd2.Parameters.AddWithValue("@MES", mes)
                cmd2.Parameters.AddWithValue("@CODPROD", codprod)
                cmd2.Parameters.AddWithValue("@SALDO", valSaldo - unidadesentrada)
                cmd2.Parameters.AddWithValue("@ENTRADAS", valEntradas - unidadesentrada)
                cmd2.ExecuteNonQuery()
                cmd2.Dispose()

                Return True
            Catch ex As Exception
                MsgBox("Error al regresar entrada de inventario. Error: " & ex.ToString)
                Return False

            End Try

        End Using

    End Function

End Class
