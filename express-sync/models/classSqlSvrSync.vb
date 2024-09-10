Imports System.Data.SqlClient
Imports System.Threading
Imports MySql.Data.MySqlClient


Public Class classSqlSvrSync

    Sub New(ByVal _StrServerConection As String, ByVal _StrHostConnection As String, ByVal _token As String, Optional mysqlstr As String = "")
        StrServerConection = _StrServerConection
        StrHostConnection = _StrHostConnection
        Token = _token
        StrMyHostConnection = mysqlstr
    End Sub

    Public Property DesError As String = ""

    Dim StrServerConection As String
    Dim StrHostConnection As String
    Dim StrMyHostConnection As String

    Dim Token As String

    'funcion para agregar un producto con todas las empresas en la tabla sync productos

    'funcion para poblar toda la tabla copiando el catálogo de la pc actual

    Public Function getTblEmpresasHost() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("EMPNIT", GetType(String))
            .Add("EMPNOMBRE", GetType(String))
        End With

        Using cnhost As New SqlConnection(StrHostConnection)

            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT EMPNIT, EMPNOMBRE FROM COMMUNITY_EMPRESAS_SYNC", cnhost)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try

            cnhost.Close()
        End Using

        Return tbl

    End Function

    'Public Function VerificarPagoToken() As Boolean

    'Dim result As Boolean

    'Using cnhost As New SqlConnection(StrHostConnection)

    'If cnhost.State <> ConnectionState.Open Then
    'cnhost.Open()
    'End If

    'Try
    'Dim cmd As New SqlCommand("SELECT ACTIVO FROM TOKENS WHERE TOKEN=@TOKEN AND ACTIVO='SI'", cnhost)
    '           cmd.Parameters.AddWithValue("@TOKEN", Token)
    'Dim dr As SqlDataReader = cmd.ExecuteReader
    '            dr.Read()
    'If dr.HasRows Then
    '               result = True
    'Else
    '               result = False
    'End If

    '           dr.Close()

    'Catch ex As Exception
    '           'mensaje("verifica pago token: " & ex.ToString)
    '          result = False
    'End Try

    '       cnhost.Close()
    'End Using

    'Return result

    'End Function

    Public Function taskSync() As Boolean
        Return True
    End Function

#Region " ** TRANSFERENCIAS DE INVENTARIO ** "
    Public Function DeleteTraslado(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal token As String) As Boolean
        Dim result As Boolean

        Using cnh As New SqlConnection(StrHostConnection)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM COMMUNITY_DOCUMENTOS WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnh)
                cmd.Parameters.AddWithValue("@TOKEN", token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.ExecuteNonQuery()

                Dim cmdD As New SqlCommand("DELETE FROM COMMUNITY_DOCPRODUCTOS WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnh)
                cmdD.Parameters.AddWithValue("@TOKEN", token)
                cmdD.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdD.Parameters.AddWithValue("@CODDOC", coddoc)
                cmdD.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmdD.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                result = False
            End Try

        End Using

        Return result

    End Function

    'OBTIENE LO DATOS DE UN TRASLADO Y LOS GENERA EN UN DOCUMENTO LOCAL
    Public Function GetTraslado(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal destEmpnit As String, ByVal destcoddoc As String, ByVal destcorrelativo As Double, ByVal empnitorigen As String) As Boolean
        Dim result As Boolean

        Dim tblDocumentos As New DataTable
        Dim tblDocproductos As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                'INSERTA DOCUMENTOS
                Dim cmdh As New SqlCommand("SELECT ID, @DESTEMPNIT AS EMPNIT, ANIO, MES, DIA, FECHA, HORA, MINUTO, @DESTCODDOC  AS CODDOC, @DESTCORRELATIVO  AS CORRELATIVO, CODCLIENTE, DOC_NIT, DOC_NOMCLIE, DOC_DIRCLIE, TOTALCOSTO, TOTALPRECIO, CODEMBARQUE, STATUS, USUARIO, 
                                            CONCRE, CORTE, CODDOC AS SERIEFAC, CONCAT(CORRELATIVO,'-') AS NOFAC, CODVEN, NOCORTE, PAGO, VUELTO, MARCA, OBS, DOC_SALDO, DOC_ABONO, OBSMARCA, TOTALDESCUENTO, CODCAJA, TOTALTARJETA, RECARGOTARJETA, CODREP, DIRENTREGA, NOGUIA, VALORENTREGA,TOTALEXENTO
                                        FROM COMMUNITY_DOCUMENTOS
                                        WHERE (TOKEN = @TOKEN) AND (EMPNIT=@EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO)", cnh)

                cmdh.Parameters.AddWithValue("@DESTEMPNIT", destEmpnit)
                cmdh.Parameters.AddWithValue("@DESTCODDOC", destcoddoc)
                cmdh.Parameters.AddWithValue("@DESTCORRELATIVO", destcorrelativo)

                cmdh.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh.Parameters.AddWithValue("@CODDOC", coddoc)
                cmdh.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)

                'Dim drh As SqlDataReader = cmdh.ExecuteReader 
                Dim dah As New SqlDataAdapter
                dah.SelectCommand = cmdh
                dah.Fill(tblDocumentos)

                'INSERTA DOCPRODUCTOS
                Dim qr = "SELECT ID, @DESTEMPNIT AS EMPNIT, ANIO, MES, DIA, @DESTCODDOC AS CODDOC, @DESTCORRELATIVO AS CORRELATIVO, CODPROD, DESPROD, CODMEDIDA, CANTIDAD, CANTIDADBONIF, EQUIVALE, TOTALUNIDADES, TOTALBONIF, COSTO, PRECIO, TOTALCOSTO, 
                                            TOTALPRECIO, ENTREGADOS_TOTALUNIDADES, ENTREGADOS_TOTALCOSTO, ENTREGADOS_TOTALPRECIO, COSTOANTERIOR, COSTOPROMEDIO, CODBODEGAENTRADA, CODBODEGASALIDA, DESCUENTO, PORCDESCUENTO, NOSERIE, EXENTO
                                        FROM COMMUNITY_DOCPRODUCTOS
                                        WHERE (TOKEN = @TOKEN) AND (EMPNIT = @EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO)"

                Dim cmd As New SqlCommand("SELECT       COMMUNITY_DOCPRODUCTOS.ID, @DESTEMPNIT AS EMPNIT, COMMUNITY_DOCPRODUCTOS.ANIO, COMMUNITY_DOCPRODUCTOS.MES, COMMUNITY_DOCPRODUCTOS.DIA, @DESTCODDOC AS CODDOC, 
                         @DESTCORRELATIVO AS CORRELATIVO, COMMUNITY_DOCPRODUCTOS.CODPROD, COMMUNITY_DOCPRODUCTOS.DESPROD, COMMUNITY_DOCPRODUCTOS.CODMEDIDA, COMMUNITY_DOCPRODUCTOS.CANTIDAD, 
                         COMMUNITY_DOCPRODUCTOS.CANTIDADBONIF, COMMUNITY_DOCPRODUCTOS.EQUIVALE, COMMUNITY_DOCPRODUCTOS.TOTALUNIDADES, COMMUNITY_DOCPRODUCTOS.TOTALBONIF, 
                         COMMUNITY_DOCPRODUCTOS.COSTO, COMMUNITY_DOCPRODUCTOS.PRECIO, COMMUNITY_DOCPRODUCTOS.TOTALCOSTO, COMMUNITY_DOCPRODUCTOS.TOTALPRECIO, 
                         COMMUNITY_DOCPRODUCTOS.ENTREGADOS_TOTALUNIDADES, COMMUNITY_DOCPRODUCTOS.ENTREGADOS_TOTALCOSTO, COMMUNITY_DOCPRODUCTOS.ENTREGADOS_TOTALPRECIO, 
                         COMMUNITY_DOCPRODUCTOS.COSTOANTERIOR, COMMUNITY_DOCPRODUCTOS.COSTOPROMEDIO, COMMUNITY_DOCPRODUCTOS.CODBODEGAENTRADA, COMMUNITY_DOCPRODUCTOS.CODBODEGASALIDA, 
                         COMMUNITY_DOCPRODUCTOS.DESCUENTO, COMMUNITY_DOCPRODUCTOS.PORCDESCUENTO, COMMUNITY_DOCPRODUCTOS.NOSERIE, COMMUNITY_DOCPRODUCTOS.EXENTO
FROM            COMMUNITY_DOCPRODUCTOS RIGHT OUTER JOIN
                         COMMUNITY_DOCUMENTOS ON COMMUNITY_DOCPRODUCTOS.TOKEN = COMMUNITY_DOCUMENTOS.TOKEN AND COMMUNITY_DOCPRODUCTOS.EMPNIT = COMMUNITY_DOCUMENTOS.EMPNIT AND 
                         COMMUNITY_DOCPRODUCTOS.CODDOC = COMMUNITY_DOCUMENTOS.CODDOC AND COMMUNITY_DOCPRODUCTOS.CORRELATIVO = COMMUNITY_DOCUMENTOS.CORRELATIVO
WHERE        (COMMUNITY_DOCUMENTOS.TOKEN = @TOKEN) AND (COMMUNITY_DOCUMENTOS.EMPNIT = @EMPNIT) AND (COMMUNITY_DOCUMENTOS.CODDOC = @CODDOC) AND 
                         (COMMUNITY_DOCUMENTOS.CORRELATIVO = @CORRELATIVO) ", cnh)

                cmd.Parameters.AddWithValue("@DESTEMPNIT", destEmpnit)
                cmd.Parameters.AddWithValue("@DESTCODDOC", destcoddoc)
                cmd.Parameters.AddWithValue("@DESTCORRELATIVO", destcorrelativo)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                'Dim drp As SqlDataReader = cmd.ExecuteReader
                Dim dap As New SqlDataAdapter
                dap.SelectCommand = cmd
                dap.Fill(tblDocproductos)

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        'comprueba si la datatable se llenó, de lo contrario lanza error
        If tblDocumentos.Rows.Count > 0 Then
            'comprobación de docproductos para descartar meter datos vacíos
            If tblDocproductos.Rows.Count > 0 Then
                'continua con la inserción de datos local
            Else
                MsgBox("No se obtuvo el detalle del documento o el mismo está vacío por lo que no podré generar el documento, puede ser que su señal de internet no esté estable. Inténtelo de nuevo")
                Return False
                Exit Function
            End If
        Else
            MsgBox("No se logró obtener el documento, posiblemente haya problemas con la señal del internet, inténtelo de nuevo")
            Return False
            Exit Function
        End If

        'inserta los datos obtenidos en documentos
        Dim bcCopy As New SqlBulkCopy(StrServerConection)
        Dim cn As New SqlConnection(StrServerConection)
        cn.Open()
        bcCopy.DestinationTableName = "DOCUMENTOS"
        bcCopy.WriteToServer(tblDocumentos)
        cn.Close()

        'inserta los datos en docproductos
        Dim bcCopyp As New SqlBulkCopy(StrServerConection)
        Dim chp As New SqlConnection(StrServerConection)
        chp.Open()
        bcCopyp.DestinationTableName = "DOCPRODUCTOS"
        bcCopyp.WriteToServer(tblDocproductos)
        chp.Close()

        Return result

    End Function

    'BACKUP DE LA RUTINA GETTRASLADO QUE OBTIENE EL DOCUMENTO DE TRASLADO
    Public Function GetTrasladoOLD(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal destEmpnit As String, ByVal destcoddoc As String, ByVal destcorrelativo As Double, ByVal empnitorigen As String) As Boolean
        Dim result As Boolean

        Dim tblDocumentos As New DataTable
        Dim tblDocproductos As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                'INSERTA DOCUMENTOS
                Dim cmdh As New SqlCommand("SELECT ID, @DESTEMPNIT AS EMPNIT, ANIO, MES, DIA, FECHA, HORA, MINUTO, @DESTCODDOC  AS CODDOC, @DESTCORRELATIVO  AS CORRELATIVO, CODCLIENTE, DOC_NIT, DOC_NOMCLIE, DOC_DIRCLIE, TOTALCOSTO, TOTALPRECIO, CODEMBARQUE, STATUS, USUARIO, 
                                            CONCRE, CORTE, CODDOC AS SERIEFAC, CONCAT(CORRELATIVO,'-') AS NOFAC, CODVEN, NOCORTE, PAGO, VUELTO, MARCA, OBS, DOC_SALDO, DOC_ABONO, OBSMARCA, TOTALDESCUENTO, CODCAJA, TOTALTARJETA, RECARGOTARJETA, CODREP, DIRENTREGA, NOGUIA, VALORENTREGA,TOTALEXENTO
                                        FROM COMMUNITY_DOCUMENTOS
                                        WHERE (TOKEN = @TOKEN) AND (EMPNIT=@EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO)", cnh)

                cmdh.Parameters.AddWithValue("@DESTEMPNIT", destEmpnit)
                cmdh.Parameters.AddWithValue("@DESTCODDOC", destcoddoc)
                cmdh.Parameters.AddWithValue("@DESTCORRELATIVO", destcorrelativo)

                cmdh.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh.Parameters.AddWithValue("@CODDOC", coddoc)
                cmdh.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)

                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)

                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()

                bcCopy.DestinationTableName = "DOCUMENTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

                'INSERTA DOCPRODUCTOS
                Dim qr = "SELECT ID, @DESTEMPNIT AS EMPNIT, ANIO, MES, DIA, @DESTCODDOC AS CODDOC, @DESTCORRELATIVO AS CORRELATIVO, CODPROD, DESPROD, CODMEDIDA, CANTIDAD, CANTIDADBONIF, EQUIVALE, TOTALUNIDADES, TOTALBONIF, COSTO, PRECIO, TOTALCOSTO, 
                                            TOTALPRECIO, ENTREGADOS_TOTALUNIDADES, ENTREGADOS_TOTALCOSTO, ENTREGADOS_TOTALPRECIO, COSTOANTERIOR, COSTOPROMEDIO, CODBODEGAENTRADA, CODBODEGASALIDA, DESCUENTO, PORCDESCUENTO, NOSERIE, EXENTO
                                        FROM COMMUNITY_DOCPRODUCTOS
                                        WHERE (TOKEN = @TOKEN) AND (EMPNIT = @EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO)"

                Dim cmd As New SqlCommand("SELECT       COMMUNITY_DOCPRODUCTOS.ID, @DESTEMPNIT AS EMPNIT, COMMUNITY_DOCPRODUCTOS.ANIO, COMMUNITY_DOCPRODUCTOS.MES, COMMUNITY_DOCPRODUCTOS.DIA, @DESTCODDOC AS CODDOC, 
                         @DESTCORRELATIVO AS CORRELATIVO, COMMUNITY_DOCPRODUCTOS.CODPROD, COMMUNITY_DOCPRODUCTOS.DESPROD, COMMUNITY_DOCPRODUCTOS.CODMEDIDA, COMMUNITY_DOCPRODUCTOS.CANTIDAD, 
                         COMMUNITY_DOCPRODUCTOS.CANTIDADBONIF, COMMUNITY_DOCPRODUCTOS.EQUIVALE, COMMUNITY_DOCPRODUCTOS.TOTALUNIDADES, COMMUNITY_DOCPRODUCTOS.TOTALBONIF, 
                         COMMUNITY_DOCPRODUCTOS.COSTO, COMMUNITY_DOCPRODUCTOS.PRECIO, COMMUNITY_DOCPRODUCTOS.TOTALCOSTO, COMMUNITY_DOCPRODUCTOS.TOTALPRECIO, 
                         COMMUNITY_DOCPRODUCTOS.ENTREGADOS_TOTALUNIDADES, COMMUNITY_DOCPRODUCTOS.ENTREGADOS_TOTALCOSTO, COMMUNITY_DOCPRODUCTOS.ENTREGADOS_TOTALPRECIO, 
                         COMMUNITY_DOCPRODUCTOS.COSTOANTERIOR, COMMUNITY_DOCPRODUCTOS.COSTOPROMEDIO, COMMUNITY_DOCPRODUCTOS.CODBODEGAENTRADA, COMMUNITY_DOCPRODUCTOS.CODBODEGASALIDA, 
                         COMMUNITY_DOCPRODUCTOS.DESCUENTO, COMMUNITY_DOCPRODUCTOS.PORCDESCUENTO, COMMUNITY_DOCPRODUCTOS.NOSERIE, COMMUNITY_DOCPRODUCTOS.EXENTO
FROM            COMMUNITY_DOCPRODUCTOS RIGHT OUTER JOIN
                         COMMUNITY_DOCUMENTOS ON COMMUNITY_DOCPRODUCTOS.TOKEN = COMMUNITY_DOCUMENTOS.TOKEN AND COMMUNITY_DOCPRODUCTOS.EMPNIT = COMMUNITY_DOCUMENTOS.EMPNIT AND 
                         COMMUNITY_DOCPRODUCTOS.CODDOC = COMMUNITY_DOCUMENTOS.CODDOC AND COMMUNITY_DOCPRODUCTOS.CORRELATIVO = COMMUNITY_DOCUMENTOS.CORRELATIVO
WHERE        (COMMUNITY_DOCUMENTOS.TOKEN = @TOKEN) AND (COMMUNITY_DOCUMENTOS.EMPNIT = @EMPNIT) AND (COMMUNITY_DOCUMENTOS.CODDOC = @CODDOC) AND 
                         (COMMUNITY_DOCUMENTOS.CORRELATIVO = @CORRELATIVO) ", cnh)

                cmd.Parameters.AddWithValue("@DESTEMPNIT", destEmpnit)
                'cmd.Parameters.AddWithValue("@EMPNITORIGEN", empnitorigen)
                cmd.Parameters.AddWithValue("@DESTCODDOC", destcoddoc)
                cmd.Parameters.AddWithValue("@DESTCORRELATIVO", destcorrelativo)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim drp As SqlDataReader = cmd.ExecuteReader

                Dim bcCopyp As New SqlBulkCopy(StrServerConection)
                Dim chp As New SqlConnection(StrServerConection)
                chp.Open()

                bcCopyp.DestinationTableName = "DOCPRODUCTOS"
                bcCopyp.WriteToServer(drp)
                drp.Close()
                chp.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function getTrasladosPendientesTodos(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                'Dim cmd As New SqlCommand("SELECT CODDOC,CORRELATIVO,FECHA,TOTALCOSTO,TOTALPRECIO,OBS,EMPNIT FROM COMMUNITY_DOCUMENTOS WHERE TOKEN=@TOKEN AND CODDOC=@CODDOC", cnhost)

                Dim sql, sql2 As String

                sql2 = "SELECT COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO, 
                                COMMUNITY_DOCUMENTOS.FECHA, 
                                COMMUNITY_DOCUMENTOS.TOTALCOSTO, COMMUNITY_DOCUMENTOS.TOTALPRECIO, 
                                COMMUNITY_DOCUMENTOS.OBS, COMMUNITY_DOCUMENTOS.EMPNIT, 
                            COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE, COMMUNITY_DOCUMENTOS.OBSMARCA, COMMUNITY_DOCUMENTOS.CODEMBARQUE 
                            FROM COMMUNITY_DOCUMENTOS LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT AND COMMUNITY_DOCUMENTOS.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN
                            WHERE (COMMUNITY_DOCUMENTOS.TOKEN = @TOKEN) AND (COMMUNITY_DOCUMENTOS.EMPNIT=@E) AND (COMMUNITY_DOCUMENTOS.CODEMBARQUE<>@EB)
                            ORDER BY COMMUNITY_DOCUMENTOS.FECHA, COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO"

                sql = "SELECT COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO, COMMUNITY_DOCUMENTOS.FECHA, 
                        COMMUNITY_DOCUMENTOS.TOTALCOSTO, COMMUNITY_DOCUMENTOS.TOTALPRECIO, 
                         COMMUNITY_DOCUMENTOS.OBS, COMMUNITY_DOCUMENTOS.EMPNIT, COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE, COMMUNITY_DOCUMENTOS.OBSMARCA, COMMUNITY_DOCUMENTOS.CODEMBARQUE 
                            FROM COMMUNITY_DOCUMENTOS LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT AND COMMUNITY_DOCUMENTOS.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN
                            WHERE (COMMUNITY_DOCUMENTOS.TOKEN = @TOKEN) 
                           ORDER BY COMMUNITY_DOCUMENTOS.FECHA, COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO"

                Dim cmd As New SqlCommand(sql, cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox("Error al cargar listado: " + ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function getTrasladosPendientes(ByVal empnit As String, ByVal empbod As String, ByVal empnitbodega As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                'Dim cmd As New SqlCommand("SELECT CODDOC,CORRELATIVO,FECHA,TOTALCOSTO,TOTALPRECIO,OBS,EMPNIT FROM COMMUNITY_DOCUMENTOS WHERE TOKEN=@TOKEN AND CODDOC=@CODDOC", cnhost)

                Dim sql As String

                If empnitbodega = "NO" Then

                    sql = "SELECT COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO, 
                                COMMUNITY_DOCUMENTOS.FECHA, 
                                COMMUNITY_DOCUMENTOS.TOTALCOSTO, COMMUNITY_DOCUMENTOS.TOTALPRECIO, 
                                COMMUNITY_DOCUMENTOS.OBS, COMMUNITY_DOCUMENTOS.EMPNIT, 
                            COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE, COMMUNITY_DOCUMENTOS.OBSMARCA, COMMUNITY_DOCUMENTOS.CODEMBARQUE 
                            FROM COMMUNITY_DOCUMENTOS LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT AND COMMUNITY_DOCUMENTOS.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN
                            WHERE (COMMUNITY_DOCUMENTOS.TOKEN = @TOKEN) AND (COMMUNITY_DOCUMENTOS.EMPNIT=@E) AND (COMMUNITY_DOCUMENTOS.CODEMBARQUE<>@EB)
                            ORDER BY COMMUNITY_DOCUMENTOS.FECHA, COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO"

                Else
                    sql = "SELECT COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO, COMMUNITY_DOCUMENTOS.FECHA, 
                        COMMUNITY_DOCUMENTOS.TOTALCOSTO, COMMUNITY_DOCUMENTOS.TOTALPRECIO, 
                         COMMUNITY_DOCUMENTOS.OBS, COMMUNITY_DOCUMENTOS.EMPNIT, COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE, COMMUNITY_DOCUMENTOS.OBSMARCA, COMMUNITY_DOCUMENTOS.CODEMBARQUE 
                            FROM COMMUNITY_DOCUMENTOS LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT AND COMMUNITY_DOCUMENTOS.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN
                            WHERE (COMMUNITY_DOCUMENTOS.TOKEN = @TOKEN) AND (COMMUNITY_DOCUMENTOS.EMPNIT=@E) AND (COMMUNITY_DOCUMENTOS.CODEMBARQUE=@EB)
                            ORDER BY COMMUNITY_DOCUMENTOS.FECHA, COMMUNITY_DOCUMENTOS.CODDOC, COMMUNITY_DOCUMENTOS.CORRELATIVO"
                End If

                Dim cmd As New SqlCommand(sql, cnhost)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@EB", empbod)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox("Error al cargar listado: " + ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function getDataTrasladoPendiente(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, CODMEDIDA, CANTIDAD, TOTALUNIDADES, COSTO, PRECIO, TOTALCOSTO, TOTALPRECIO
                                            FROM COMMUNITY_DOCPRODUCTOS
                                            WHERE (EMPNIT = @EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO) AND (TOKEN = @TOKEN)", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function deleteTrasladoSubido(ByVal empnitdestino As String, ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim r As Boolean
        Using cnh As New SqlConnection(StrHostConnection)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If
                Dim cmd As New SqlCommand("DELETE FROM COMMUNITY_DOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N;
                                            DELETE FROM COMMUNITY_DOCPRODUCTOS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N;", cnh)
                cmd.Parameters.AddWithValue("@E", empnitdestino)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
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

    Public Function SendSalidaInventarioTitulo(ByVal empnitdestino As String, ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal origen As String) As Boolean
        Dim result As Boolean

        If deleteTrasladoSubido(empnitdestino, coddoc, correlativo) = True Then

        End If

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                'EMPNITDESTINO=EMPNIT, EMPNIT=CODEMBARQUE // LA COLUMNA CODEMBARQUE ES EL ORIGEN

                'INSERTA DOCUMENTOS
                Dim sqldocs As String
                sqldocs = "SELECT ID,@EMPNITDESTINO AS EMPNIT,ANIO,MES,DIA,FECHA,HORA,MINUTO,CODDOC,CORRELATIVO,CODCLIENTE,DOC_NIT,DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,TOTALPRECIO,
                        @EMPNIT AS CODEMBARQUE,STATUS,USUARIO,CONCRE,CORTE,SERIEFAC,NOFAC,CODVEN,NOCORTE,PAGO,VUELTO,MARCA,OBS,DOC_SALDO,DOC_ABONO,@ORIGEN AS OBSMARCA,
                        TOTALDESCUENTO,CODCAJA,TOTALTARJETA,RECARGOTARJETA,CODREP,DIRENTREGA,NOGUIA,VALORENTREGA,TOTALEXENTO,@TOKEN AS TOKEN 
                        FROM DOCUMENTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO"

                Dim cmd As New SqlCommand(sqldocs, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ORIGEN", origen)

                cmd.Parameters.AddWithValue("@EMPNITDESTINO", empnitdestino)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrHostConnection)
                Dim ch As New SqlConnection(StrHostConnection)
                ch.Open()
                bcCopy.DestinationTableName = "COMMUNITY_DOCUMENTOS"
                bcCopy.WriteToServer(dr)
                dr.Close()
                ch.Close()

                'INSERTA DOCPRODUCTOS
                Dim sqldocprod As String '= "SELECT *, @TOKEN AS TOKEN FROM DOCPRODUCTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO"
                sqldocprod = "SELECT ID,@EMPNITDESTINO AS EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,CANTIDADBONIF,EQUIVALE,
	                            TOTALUNIDADES,TOTALBONIF,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,
	                            ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CODBODEGAENTRADA,
	                            CODBODEGASALIDA,DESCUENTO,PORCDESCUENTO,NOSERIE,EXENTO,@TOKEN AS TOKEN
                                FROM DOCPRODUCTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO"

                Dim cmddc As New SqlCommand(sqldocprod, cn)
                cmddc.Parameters.AddWithValue("@EMPNIT", empnit)
                cmddc.Parameters.AddWithValue("@EMPNITDESTINO", empnitdestino)
                cmddc.Parameters.AddWithValue("@CODDOC", coddoc)
                cmddc.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmddc.Parameters.AddWithValue("@TOKEN", Token)
                Dim drp As SqlDataReader = cmddc.ExecuteReader

                Dim bcCopyp As New SqlBulkCopy(StrHostConnection)
                Dim chp As New SqlConnection(StrHostConnection)
                chp.Open()
                bcCopyp.DestinationTableName = "COMMUNITY_DOCPRODUCTOS"
                bcCopyp.WriteToServer(drp)
                drp.Close()
                chp.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

#End Region

#Region " ** OBTIENE LA DATA DE LOS PRODUCTOS Y PRECIOS ** "

    'ACTUALIZA LAS EXISTENCIAS A LAS QUE QUEDARON EN EL BACKUP EVITANDO ASÍ QUE HAYAN PRODUCTOS QUE NO POSEAN REGISTROS EN LA TABLA INVSALDO
    Public Function UpdateProductosInvsaldo(ByVal empnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal backupname As String) As Boolean

        Dim result As Boolean
        Dim contador As Integer = 0
        Dim strError As String = ""
        Dim SQL As String = "SELECT CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO FROM INVSALDO WHERE EMPNIT='" & backupname & "'"

        Using cn As New SqlConnection(StrServerConection)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(SQL, cn)


                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Try
                        Dim upd As New SqlCommand("UPDATE INVSALDO SET SALDOINICIAL=@SALDOINICIAL,ENTRADAS=@ENTRADAS,SALIDAS=@SALIDAS,SALDO=@SALDO WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
                        upd.Parameters.AddWithValue("@SALDOINICIAL", Double.Parse(dr(1)))
                        upd.Parameters.AddWithValue("@ENTRADAS", Double.Parse(dr(2)))
                        upd.Parameters.AddWithValue("@SALIDAS", Double.Parse(dr(3)))
                        upd.Parameters.AddWithValue("@SALDO", Double.Parse(dr(4)))
                        upd.Parameters.AddWithValue("@EMPNIT", empnit)
                        upd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                        upd.ExecuteNonQuery()

                    Catch ex As Exception
                        contador = contador + 1
                        strError = strError & ";" & dr(0).ToString
                    End Try
                Loop
                If contador > 0 Then
                    MsgBox("Errores encontrados: " & contador.ToString & ", códigos con conflicto: " & strError)
                End If
                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'ACTUALIZA LOS PRECIOS A LOS QUE QUEDARON EN EL BACKUP EVITANDO ASÍ QUE HAYAN PRODUCTOS QUE NO POSEAN REGISTROS EN LA TABLA PRECIOS
    Public Function UpdateProductosPrecios(ByVal empnit As String) As Boolean

        Dim result As Boolean
        Dim contador As Integer = 0
        Dim strError As String = ""

        '------------------------------
        'borrar de aqui para la marca
        '------------------------------
        Using cn As New SqlConnection(StrServerConection)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd0 As New SqlCommand("UPDATE PRECIOS SET EMPNIT='XX' WHERE EMPNIT=@EMPNIT", cn)
                cmd0.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd0.ExecuteNonQuery()

                Dim cmd1 As New SqlCommand("UPDATE PRECIOS SET EMPNIT=@EMPNIT WHERE EMPNIT='BACKUP'", cn)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

        Exit Function
        '------------------------------
        'borrar de aqui para arriba 
        '------------------------------


        Using cn As New SqlConnection(StrServerConection)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD,CODMEDIDA,COSTO,PRECIO,MAYOREOA,MAYOREOB,MAYOREOC FROM PRECIOS WHERE EMPNIT='BACKUP'", cn)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Try
                        Dim upd As New SqlCommand("UPDATE PRECIOS SET COSTO=@COSTO,PRECIO=@PRECIO,MAYOREOA=@MAYOREOA,MAYOREOB=@MAYOREOB,MAYOREOC=@MAYOREOC WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA", cn)
                        'VALORES A ACTUALIZAR
                        upd.Parameters.AddWithValue("@COSTO", Double.Parse(dr(2)))
                        upd.Parameters.AddWithValue("@PRECIO", Double.Parse(dr(3)))
                        upd.Parameters.AddWithValue("@MAYOREOA", Double.Parse(dr(4)))
                        upd.Parameters.AddWithValue("@MAYOREOB", Double.Parse(dr(5)))
                        upd.Parameters.AddWithValue("@MAYOREOC", Double.Parse(dr(6)))

                        'PARAMETROS PARA LOS WHERE
                        upd.Parameters.AddWithValue("@EMPNIT", empnit)
                        upd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                        upd.Parameters.AddWithValue("@CODMEDIDA", dr(1).ToString)

                        upd.ExecuteNonQuery()
                    Catch ex As Exception
                        contador = contador + 1
                        strError = strError & ";" & dr(0).ToString
                    End Try
                Loop
                If contador > 0 Then
                    MsgBox("Errores encontrados: " & contador.ToString & ", códigos con conflicto: " & strError)
                End If
                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using





        Return result

    End Function



    'ELIMINA EL CATÀLOGO EN EL BACKUP PARA GENERAR UNO NUEVO
    Public Function DeleteBackupProductosPreciosInvsaldo() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM PRODUCTOS WHERE EMPNIT='BACKUP';
                                        DELETE FROM PRECIOS WHERE EMPNIT='BACKUP';
                                        DELETE FROM INVSALDO WHERE EMPNIT='BACKUP';
                                        DELETE FROM MEDIDAS WHERE EMPNIT='BACKUP';
                                        DELETE FROM MARCAS WHERE EMPNIT='BACKUP';
                                        DELETE FROM CLASIFICACIONUNO WHERE EMPNIT='BACKUP';
                                        DELETE FROM CLASIFICACIONDOS WHERE EMPNIT='BACKUP';
                                        DELETE FROM CLASIFICACIONTRES WHERE EMPNIT='BACKUP'", cn)
                cmd.ExecuteNonQuery()
                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function


    'ELIMINA EL CATÀLOGO PRE ESTABLECIDO
    Public Function delete_productos_ads() As Boolean

        Dim result As Boolean

        Using cnh As New SqlConnection(StrHostConnection)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("TRUNCATE TABLE PRODUCTOS_ADS", cnh)
                cmd.ExecuteNonQuery()
                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'ESTABLECE LOS DETALLES ADICIONALES DE PRODUCTOS
    Public Function post_productos_ads() As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRODUCTOS
                Dim cmd As New SqlCommand("SELECT EMPNIT,EMPNOMBRE,CODPROD,DESPROD,INVMINIMO,INVMAXIMO,HABILITADO FROM PRODUCTOS_ADS", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy.DestinationTableName = "PRODUCTOS_ADS"
                bcCopy.WriteToServer(dr)
                dr.Close()
                cnh.Close()


                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function





    'ELIMINA EL CATÀLOGO PRE ESTABLECIDO
    Public Function DeleteProductosPreciosInvsaldo() As Boolean

        Dim result As Boolean

        Using cnh As New SqlConnection(StrHostConnection)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM COMMUNITY_PRODUCTOS WHERE TOKEN=@TOKEN;
                                            DELETE FROM COMMUNITY_PRECIOS WHERE TOKEN=@TOKEN;
                                            DELETE FROM COMMUNITY_INVSALDO WHERE TOKEN=@TOKEN;
                                            DELETE FROM COMMUNITY_MEDIDAS WHERE TOKEN=@TOKEN;
                                            DELETE FROM COMMUNITY_MARCAS WHERE TOKEN=@TOKEN;
                                            DELETE FROM COMMUNITY_CLASIFICACIONUNO WHERE TOKEN=@TOKEN;
                                            DELETE FROM COMMUNITY_CLASIFICACIONDOS WHERE TOKEN=@TOKEN;
                                            DELETE FROM COMMUNITY_CLASIFICACIONTRES WHERE TOKEN=@TOKEN", cnh)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.ExecuteNonQuery()
                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function


    'ESTABLECE EL LISTADO GENERAL DE PRODUCTOS EN EL HOSTING
    Public Function PostProductosPreciosInvsaldo(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRODUCTOS
                Dim cmd As New SqlCommand("SELECT ID,
                                            'GENERAL' AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,
                                            BONO,INVMINIMO,INVMAXIMO,EXENTO,@TOKEN AS TOKEN,NF,@FECHA AS LASTSALE,TIPOPROD FROM PRODUCTOS WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                cmd.CommandTimeout = 60000

                Dim dr As SqlDataReader = cmd.ExecuteReader



                Dim bcCopy As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy.DestinationTableName = "COMMUNITY_PRODUCTOS"
                bcCopy.WriteToServer(dr)
                dr.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRECIOS
                Dim cmd2 As New SqlCommand("SELECT ID,'GENERAL' AS EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO,MAYOREOA,MAYOREOB,MAYOREOC,ISNULL(PESO,0) AS PESO, @TOKEN AS TOKEN, BONO FROM PRECIOS WHERE EMPNIT=@EMPNIT", cn)
                cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd2.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr2 As SqlDataReader = cmd2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy2.DestinationTableName = "COMMUNITY_PRECIOS"
                bcCopy2.WriteToServer(dr2)
                dr2.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_INVSALDO
                Dim cmd3 As New SqlCommand("SELECT ID,'GENERAL' AS EMPNIT, ANIO, MES,CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO,CODBODEGA,NOLOTE,@TOKEN AS TOKEN FROM INVSALDO WHERE EMPNIT=@EMPNIT AND ANIO=0 AND MES=0", cn)
                cmd3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd3.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr3 As SqlDataReader = cmd3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy3.DestinationTableName = "COMMUNITY_INVSALDO"
                bcCopy3.WriteToServer(dr3)
                dr3.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_MEDIDAS
                Dim cmd4 As New SqlCommand("SELECT 'GENERAL' AS EMPNIT, CODMEDIDA,TIPOPRECIO,@TOKEN AS TOKEN FROM MEDIDAS WHERE EMPNIT=@EMPNIT", cn)
                cmd4.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd4.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr4 As SqlDataReader = cmd4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy4.DestinationTableName = "COMMUNITY_MEDIDAS"
                bcCopy4.WriteToServer(dr4)
                dr4.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_MARCAS
                Dim cmd5 As New SqlCommand("SELECT 'GENERAL' AS EMPNIT, CODMARCA,DESMARCA,@TOKEN AS TOKEN FROM MARCAS WHERE EMPNIT=@EMPNIT", cn)
                cmd5.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd5.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr5 As SqlDataReader = cmd5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy5.DestinationTableName = "COMMUNITY_MARCAS"
                bcCopy5.WriteToServer(dr5)
                dr5.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_CLASIFICACIONUNO
                Dim cmd6 As New SqlCommand("SELECT 'GENERAL' AS EMPNIT, CODCLAUNO,DESCLAUNO,@TOKEN AS TOKEN FROM CLASIFICACIONUNO WHERE EMPNIT=@EMPNIT", cn)
                cmd6.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd6.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr6 As SqlDataReader = cmd6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy6.DestinationTableName = "COMMUNITY_CLASIFICACIONUNO"
                bcCopy6.WriteToServer(dr6)
                dr6.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_CLASIFICACIONDOS
                Dim cmd7 As New SqlCommand("SELECT 'GENERAL' AS EMPNIT, CODCLADOS,DESCLADOS,@TOKEN AS TOKEN FROM CLASIFICACIONDOS WHERE EMPNIT=@EMPNIT", cn)
                cmd7.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd7.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr7 As SqlDataReader = cmd7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy7.DestinationTableName = "COMMUNITY_CLASIFICACIONDOS"
                bcCopy7.WriteToServer(dr7)
                dr7.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_CLASIFICACIONTRES
                Dim cmd8 As New SqlCommand("SELECT 'GENERAL' AS EMPNIT, CODCLATRES,DESCLATRES,@TOKEN AS TOKEN FROM CLASIFICACIONTRES WHERE EMPNIT=@EMPNIT", cn)
                cmd8.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd8.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr8 As SqlDataReader = cmd8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy8.DestinationTableName = "COMMUNITY_CLASIFICACIONTRES"
                bcCopy8.WriteToServer(dr8)
                dr8.Close()
                cnh.Close()


                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'OBTIENE EL INVENTARIO DE TODAS LAS SUCURSALES
    Public Function getInventarioSucursales(ByVal anioproceso As Integer, ByVal mesproceso As Integer) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS SUCURSAL, COMMUNITY_INVSALDO_SYNC.CODPROD AS CODIGO, COMMUNITY_PRODUCTOS_SYNC.DESPROD AS PRODUCTO, 
                         COMMUNITY_MARCAS.DESMARCA AS MARCA, COMMUNITY_INVSALDO_SYNC.ENTRADAS, COMMUNITY_INVSALDO_SYNC.SALIDAS, COMMUNITY_INVSALDO_SYNC.SALDO AS EXISTENCIA, 
                         COMMUNITY_PRODUCTOS_SYNC.COSTO AS COSTOUNITARIO, COMMUNITY_PRODUCTOS_SYNC.COSTO * COMMUNITY_INVSALDO_SYNC.SALDO AS TOTALCOSTO, 
                         COMMUNITY_PRODUCTOS_SYNC.TIPOPROD AS TIPO
                        FROM COMMUNITY_EMPRESAS_SYNC RIGHT OUTER JOIN
                         COMMUNITY_INVSALDO_SYNC ON COMMUNITY_EMPRESAS_SYNC.TOKEN = COMMUNITY_INVSALDO_SYNC.TOKEN AND COMMUNITY_EMPRESAS_SYNC.EMPNIT = COMMUNITY_INVSALDO_SYNC.EMPNIT LEFT OUTER JOIN
                         COMMUNITY_MARCAS RIGHT OUTER JOIN
                         COMMUNITY_PRODUCTOS_SYNC ON COMMUNITY_MARCAS.TOKEN = COMMUNITY_PRODUCTOS_SYNC.TOKEN AND COMMUNITY_MARCAS.CODMARCA = COMMUNITY_PRODUCTOS_SYNC.CODMARCA AND 
                         COMMUNITY_MARCAS.EMPNIT = COMMUNITY_PRODUCTOS_SYNC.EMPNIT ON COMMUNITY_INVSALDO_SYNC.EMPNIT = COMMUNITY_PRODUCTOS_SYNC.EMPNIT AND 
                         COMMUNITY_INVSALDO_SYNC.CODPROD = COMMUNITY_PRODUCTOS_SYNC.CODPROD AND COMMUNITY_INVSALDO_SYNC.TOKEN = COMMUNITY_PRODUCTOS_SYNC.TOKEN
                        WHERE (COMMUNITY_INVSALDO_SYNC.TOKEN = @TOKEN) AND (COMMUNITY_INVSALDO_SYNC.ANIO = @ANIO) AND (COMMUNITY_INVSALDO_SYNC.MES = @MES)", cnh)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@ANIO", anioproceso)
                cmd.Parameters.AddWithValue("@MES", mesproceso)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function

    'DESCARGA LOS CORTES DEL HOSTING
    Public Function getCortesSucursales(ByVal anioproceso As Integer, ByVal mesproceso As Integer) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS EMPRESA, COMMUNITY_CORTES_SYNC.FECHA, COMMUNITY_CORTES_SYNC.HORA, COMMUNITY_CORTES_SYNC.MINUTO, 
                         COMMUNITY_CORTES_SYNC.CODCAJA AS CAJA, COMMUNITY_CORTES_SYNC.CORRELATIVO, COMMUNITY_CORTES_SYNC.TOTALVENTA AS VENTACONTADO, 
                         COMMUNITY_CORTES_SYNC.TOTALREPORTADO AS EFECTIVOREPORTADO, COMMUNITY_CORTES_SYNC.TOTALTARJETA, COMMUNITY_CORTES_SYNC.REPORTADOTARJETA, COMMUNITY_CORTES_SYNC.TOTALGASTOS,
                          COMMUNITY_CORTES_SYNC.TOTALRECIBOS, COMMUNITY_CORTES_SYNC.FALTANTE, COMMUNITY_CORTES_SYNC.SOBRANTE, COMMUNITY_CORTES_SYNC.OBS, COMMUNITY_CORTES_SYNC.USUARIO, 
                        (ISNULL(COMMUNITY_CORTES_SYNC.REPORTADOTARJETA,0) + ISNULL(COMMUNITY_CORTES_SYNC.TOTALREPORTADO,0) + ISNULL(COMMUNITY_CORTES_SYNC.TOTALGASTOS,0)) AS TOTALCORTE
                        FROM COMMUNITY_CORTES_SYNC LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_CORTES_SYNC.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT AND COMMUNITY_CORTES_SYNC.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN
                        WHERE (COMMUNITY_CORTES_SYNC.ANIO = @A) AND (COMMUNITY_CORTES_SYNC.MES = @M) AND (COMMUNITY_CORTES_SYNC.TOKEN = @T)", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@A", anioproceso)
                cmd.Parameters.AddWithValue("@M", mesproceso)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function


    'DESCARGA LOS CORTES DEL HOSTING FECHA
    Public Function getCortesSucursalesFechas(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS EMPRESA, COMMUNITY_CORTES_SYNC.FECHA, COMMUNITY_CORTES_SYNC.HORA, COMMUNITY_CORTES_SYNC.MINUTO, 
                         COMMUNITY_CORTES_SYNC.CODCAJA AS CAJA, COMMUNITY_CORTES_SYNC.CORRELATIVO, COMMUNITY_CORTES_SYNC.TOTALVENTA AS VENTACONTADO, 
                         COMMUNITY_CORTES_SYNC.TOTALREPORTADO AS EFECTIVOREPORTADO, COMMUNITY_CORTES_SYNC.TOTALTARJETA, COMMUNITY_CORTES_SYNC.REPORTADOTARJETA, COMMUNITY_CORTES_SYNC.TOTALGASTOS,
                          COMMUNITY_CORTES_SYNC.TOTALRECIBOS, COMMUNITY_CORTES_SYNC.FALTANTE, COMMUNITY_CORTES_SYNC.SOBRANTE, COMMUNITY_CORTES_SYNC.OBS, COMMUNITY_CORTES_SYNC.USUARIO, 
                        (ISNULL(COMMUNITY_CORTES_SYNC.REPORTADOTARJETA,0) + ISNULL(COMMUNITY_CORTES_SYNC.TOTALREPORTADO,0) + ISNULL(COMMUNITY_CORTES_SYNC.TOTALGASTOS,0)) AS TOTALCORTE
                        FROM COMMUNITY_CORTES_SYNC LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_CORTES_SYNC.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT AND COMMUNITY_CORTES_SYNC.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN
                        WHERE (COMMUNITY_CORTES_SYNC.FECHA BETWEEN @FI AND @FF) AND (COMMUNITY_CORTES_SYNC.TOKEN = @T)", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@FI", fechainicial)
                cmd.Parameters.AddWithValue("@FF", fechafinal)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function


    'DESCARGA LAS VENTAS DE LAS SUCURSALES
    Public Function getDocumentosSucursales(ByVal anioproceso As Integer, ByVal mesproceso As Integer) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT * FROM SERVICES_DOCUMENTOS_CONTA WHERE TOKEN=@T AND ANIO=@A AND MES=@M", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@A", anioproceso)
                cmd.Parameters.AddWithValue("@M", mesproceso)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function



    'DESCARGA LAS VENTAS DE LAS SUCURSALES
    Public Function getVentasSucursales(ByVal anioproceso As Integer, ByVal mesproceso As Integer) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT  COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS SUCURSAL, COMMUNITY_DOCUMENTOS_SYNC.NOGUIA AS DEPENDIENTE,COMMUNITY_DOCUMENTOS_SYNC.FECHA, COMMUNITY_DOCUMENTOS_SYNC.HORA, COMMUNITY_DOCUMENTOS_SYNC.MINUTO, 
                         COMMUNITY_DOCUMENTOS_SYNC.CODDOC AS SERIE, COMMUNITY_DOCUMENTOS_SYNC.CORRELATIVO AS NUMERO, COMMUNITY_DOCUMENTOS_SYNC.DOC_NIT AS NIT, 
                         COMMUNITY_DOCUMENTOS_SYNC.DOC_NOMCLIE AS CLIENTE, COMMUNITY_DOCUMENTOS_SYNC.TOTALCOSTO AS COSTO, COMMUNITY_DOCUMENTOS_SYNC.TOTALPRECIO AS IMPORTE, 
                         ISNULL(COMMUNITY_DOCUMENTOS_SYNC.RECARGOTARJETA, 0) AS RECARGOTARJETA, ISNULL(COMMUNITY_DOCUMENTOS_SYNC.RECARGOTARJETA, 0) + ISNULL(COMMUNITY_DOCUMENTOS_SYNC.TOTALPRECIO, 0) 
                         AS TOTALDOCUMENTO, COMMUNITY_DOCUMENTOS_SYNC.TOTALPRECIO - COMMUNITY_DOCUMENTOS_SYNC.TOTALCOSTO + ISNULL(COMMUNITY_DOCUMENTOS_SYNC.RECARGOTARJETA,0) AS UTILIDAD, 
                         COMMUNITY_DOCUMENTOS_SYNC.STATUS AS ST, COMMUNITY_DOCUMENTOS_SYNC.CONCRE AS CONTADOCREDITO, COMMUNITY_DOCUMENTOS_SYNC.DOC_SALDO AS SALDO, 
                         COMMUNITY_DOCUMENTOS_SYNC.DOC_ABONO AS ABONOS
FROM            COMMUNITY_DOCUMENTOS_SYNC LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS_SYNC.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN AND COMMUNITY_DOCUMENTOS_SYNC.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT
                WHERE (COMMUNITY_DOCUMENTOS_SYNC.TOKEN = @T) AND (COMMUNITY_DOCUMENTOS_SYNC.ANIO = @A) AND (COMMUNITY_DOCUMENTOS_SYNC.MES = @M)", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@A", anioproceso)
                cmd.Parameters.AddWithValue("@M", mesproceso)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function

    'DESCARGA LAS VENTAS DE LAS SUCURSALES FECHA
    Public Function getVentasSucursalesFECHA(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT  COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS SUCURSAL, COMMUNITY_DOCUMENTOS_SYNC.NOGUIA AS DEPENDIENTE,COMMUNITY_DOCUMENTOS_SYNC.FECHA, COMMUNITY_DOCUMENTOS_SYNC.HORA, COMMUNITY_DOCUMENTOS_SYNC.MINUTO, 
                         COMMUNITY_DOCUMENTOS_SYNC.CODDOC AS SERIE, COMMUNITY_DOCUMENTOS_SYNC.CORRELATIVO AS NUMERO, COMMUNITY_DOCUMENTOS_SYNC.DOC_NIT AS NIT, 
                         COMMUNITY_DOCUMENTOS_SYNC.DOC_NOMCLIE AS CLIENTE, COMMUNITY_DOCUMENTOS_SYNC.TOTALCOSTO AS COSTO, COMMUNITY_DOCUMENTOS_SYNC.TOTALPRECIO AS IMPORTE, 
                         ISNULL(COMMUNITY_DOCUMENTOS_SYNC.RECARGOTARJETA, 0) AS RECARGOTARJETA, ISNULL(COMMUNITY_DOCUMENTOS_SYNC.RECARGOTARJETA, 0) + ISNULL(COMMUNITY_DOCUMENTOS_SYNC.TOTALPRECIO, 0) 
                         AS TOTALDOCUMENTO, COMMUNITY_DOCUMENTOS_SYNC.TOTALPRECIO - COMMUNITY_DOCUMENTOS_SYNC.TOTALCOSTO + ISNULL(COMMUNITY_DOCUMENTOS_SYNC.RECARGOTARJETA,0) AS UTILIDAD, 
                         COMMUNITY_DOCUMENTOS_SYNC.STATUS AS ST, COMMUNITY_DOCUMENTOS_SYNC.CONCRE AS CONTADOCREDITO, COMMUNITY_DOCUMENTOS_SYNC.DOC_SALDO AS SALDO, 
                         COMMUNITY_DOCUMENTOS_SYNC.DOC_ABONO AS ABONOS
FROM            COMMUNITY_DOCUMENTOS_SYNC LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS_SYNC.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN AND COMMUNITY_DOCUMENTOS_SYNC.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT
                WHERE (COMMUNITY_DOCUMENTOS_SYNC.TOKEN = @T) AND (COMMUNITY_DOCUMENTOS_SYNC.FECHA BETWEEN @FI AND @FF)", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@FI", fechainicial)
                cmd.Parameters.AddWithValue("@FF", fechafinal)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function

    'DESCARGA LAS VENTAS DE SERVICIO A DOMICILIO
    Public Function getVentasDomicilio(ByVal anioproceso As Integer, ByVal mesproceso As Integer) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS SUCURSAL, COMMUNITY_DOCUMENTOS_DOMICILIO.FECHA, COMMUNITY_DOCUMENTOS_DOMICILIO.HORA, COMMUNITY_DOCUMENTOS_DOMICILIO.MINUTO, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.CODDOC AS SERIE, COMMUNITY_DOCUMENTOS_DOMICILIO.CORRELATIVO AS NUMERO, COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_NIT AS NIT, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_NOMCLIE AS CLIENTE, COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALCOSTO AS COSTO, COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALPRECIO AS IMPORTE, 
                         ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.RECARGOTARJETA, 0) AS RECARGOTARJETA, ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.RECARGOTARJETA, 0) + ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALPRECIO, 0) 
                         AS TOTALDOCUMENTO, COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALPRECIO - COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALCOSTO + ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.RECARGOTARJETA,0) AS UTILIDAD, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.STATUS AS ST, COMMUNITY_DOCUMENTOS_DOMICILIO.CONCRE AS CONTADOCREDITO, COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_SALDO AS SALDO, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_ABONO AS ABONOS
                        FROM COMMUNITY_DOCUMENTOS_DOMICILIO LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS_DOMICILIO.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN AND COMMUNITY_DOCUMENTOS_DOMICILIO.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT
                        WHERE (COMMUNITY_DOCUMENTOS_DOMICILIO.TOKEN = @T) AND (COMMUNITY_DOCUMENTOS_DOMICILIO.ANIO = @A) AND (COMMUNITY_DOCUMENTOS_DOMICILIO.MES = @M)", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@A", anioproceso)
                cmd.Parameters.AddWithValue("@M", mesproceso)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function

    'DESCARGA LAS VENTAS DE SERVICIO A DOMICILIO

    Public Function getVentasDomicilioFECHA(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS SUCURSAL, COMMUNITY_DOCUMENTOS_DOMICILIO.FECHA, COMMUNITY_DOCUMENTOS_DOMICILIO.HORA, COMMUNITY_DOCUMENTOS_DOMICILIO.MINUTO, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.CODDOC AS SERIE, COMMUNITY_DOCUMENTOS_DOMICILIO.CORRELATIVO AS NUMERO, COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_NIT AS NIT, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_NOMCLIE AS CLIENTE, COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALCOSTO AS COSTO, COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALPRECIO AS IMPORTE, 
                         ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.RECARGOTARJETA, 0) AS RECARGOTARJETA, ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.RECARGOTARJETA, 0) + ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALPRECIO, 0) 
                         AS TOTALDOCUMENTO, COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALPRECIO - COMMUNITY_DOCUMENTOS_DOMICILIO.TOTALCOSTO + ISNULL(COMMUNITY_DOCUMENTOS_DOMICILIO.RECARGOTARJETA,0) AS UTILIDAD, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.STATUS AS ST, COMMUNITY_DOCUMENTOS_DOMICILIO.CONCRE AS CONTADOCREDITO, COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_SALDO AS SALDO, 
                         COMMUNITY_DOCUMENTOS_DOMICILIO.DOC_ABONO AS ABONOS
                        FROM COMMUNITY_DOCUMENTOS_DOMICILIO LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_DOCUMENTOS_DOMICILIO.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN AND COMMUNITY_DOCUMENTOS_DOMICILIO.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT
                        WHERE (COMMUNITY_DOCUMENTOS_DOMICILIO.TOKEN = @T) AND (COMMUNITY_DOCUMENTOS_DOMICILIO.FECHA BETWEEN @FI AND @FF)", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@FI", fechainicial)
                cmd.Parameters.AddWithValue("@FF", fechafinal)
                cmd.CommandTimeout = 60000

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                Me.DesError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function

    'Dim strBackUpName As String

    'CREA UN BACKUP DE LAS TABLAS DE PRODUCTOS EXISTENTES
    Public Function SetBackupProductosPreciosInvsaldo(ByVal empnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal backupname As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                'TABLA PRODUCTOS
                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()

                'TABLA PRECIOS
                Dim cmdP As New SqlCommand("UPDATE PRECIOS SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT", cn)
                cmdP.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdP.ExecuteNonQuery()

                'TABLA INVSALDO
                Dim cmdI As New SqlCommand("UPDATE INVSALDO SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES", cn)
                cmdI.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdI.Parameters.AddWithValue("@ANIO", anioproceso)
                cmdI.Parameters.AddWithValue("@MES", mesproceso)
                cmdI.ExecuteNonQuery()

                'TABLA MEDIDAS
                Dim cmdM As New SqlCommand("UPDATE MEDIDAS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdM.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdM.ExecuteNonQuery()

                'TABLA MARCAS
                Dim cmdMA As New SqlCommand("UPDATE MARCAS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdMA.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdMA.ExecuteNonQuery()

                'TABLA CLASIFICACION UNO
                Dim cmdCU As New SqlCommand("UPDATE CLASIFICACIONUNO SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCU.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCU.ExecuteNonQuery()


                'TABLA CLASIFICACION DOS
                Dim cmdCD As New SqlCommand("UPDATE CLASIFICACIONDOS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCD.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCD.ExecuteNonQuery()

                'TABLA CLASIFICACION TRES
                Dim cmdCT As New SqlCommand("UPDATE CLASIFICACIONTRES SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCT.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCT.ExecuteNonQuery()


                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Property strBackUpName As String


    'CREA UN BACKUP DE LAS TABLAS DE PRODUCTOS EXISTENTES
    Public Function SetBackupProductosPreciosInvsaldo2(ByVal empnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal backupname As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                strBackUpName = "BACKUP" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

                'MsgBox(strBackUpName)

                'TABLA PRODUCTOS
                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()

                'TABLA PRECIOS
                Dim cmdp As New SqlCommand("UPDATE PRECIOS SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT", cn)
                cmdp.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdp.ExecuteNonQuery()


                'TABLA INVSALDO
                Dim cmdI As New SqlCommand("UPDATE INVSALDO SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES", cn)
                cmdI.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdI.Parameters.AddWithValue("@ANIO", anioproceso)
                cmdI.Parameters.AddWithValue("@MES", mesproceso)
                cmdI.ExecuteNonQuery()

                'TABLA MEDIDAS
                Dim cmdM As New SqlCommand("UPDATE MEDIDAS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdM.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdM.ExecuteNonQuery()

                'TABLA MARCAS
                Dim cmdMA As New SqlCommand("UPDATE MARCAS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdMA.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdMA.ExecuteNonQuery()

                'TABLA CLASIFICACION UNO
                Dim cmdCU As New SqlCommand("UPDATE CLASIFICACIONUNO SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCU.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCU.ExecuteNonQuery()


                'TABLA CLASIFICACION DOS
                Dim cmdCD As New SqlCommand("UPDATE CLASIFICACIONDOS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCD.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCD.ExecuteNonQuery()

                'TABLA CLASIFICACION TRES
                Dim cmdCT As New SqlCommand("UPDATE CLASIFICACIONTRES SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCT.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCT.ExecuteNonQuery()


                result = True

            Catch ex As Exception
                MsgBox("NO SE PUEDE ESTABLECER EL BACKUP " + ex.ToString)
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'CREA UN BACKUP DE LAS TABLAS DE PRODUCTOS EXISTENTES - SIN PRECIOS
    Public Function SetBackupProductosPreciosInvsaldo3(ByVal empnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal backupname As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                strBackUpName = "BACKUP" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

                'MsgBox(strBackUpName)

                'TABLA PRODUCTOS
                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()


                'TABLA INVSALDO
                Dim cmdI As New SqlCommand("UPDATE INVSALDO SET EMPNIT='" & backupname & "' WHERE EMPNIT=@EMPNIT AND ANIO=@ANIO AND MES=@MES", cn)
                cmdI.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdI.Parameters.AddWithValue("@ANIO", anioproceso)
                cmdI.Parameters.AddWithValue("@MES", mesproceso)
                cmdI.ExecuteNonQuery()

                'TABLA MEDIDAS
                Dim cmdM As New SqlCommand("UPDATE MEDIDAS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdM.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdM.ExecuteNonQuery()

                'TABLA MARCAS
                Dim cmdMA As New SqlCommand("UPDATE MARCAS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdMA.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdMA.ExecuteNonQuery()

                'TABLA CLASIFICACION UNO
                Dim cmdCU As New SqlCommand("UPDATE CLASIFICACIONUNO SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCU.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCU.ExecuteNonQuery()


                'TABLA CLASIFICACION DOS
                Dim cmdCD As New SqlCommand("UPDATE CLASIFICACIONDOS SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCD.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCD.ExecuteNonQuery()

                'TABLA CLASIFICACION TRES
                Dim cmdCT As New SqlCommand("UPDATE CLASIFICACIONTRES SET EMPNIT='BACKUP' WHERE EMPNIT=@EMPNIT", cn)
                cmdCT.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdCT.ExecuteNonQuery()


                result = True

            Catch ex As Exception
                MsgBox("NO SE PUEDE ESTABLECER EL BACKUP " + ex.ToString)
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function getTipoPrecioSucursal(ByVal empnit As String) As String

        Dim tipo As String = "A"
        Using cnh As New SqlConnection(StrHostConnection)


            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT TIPOPRECIO FROM COMMUNITY_EMPRESAS_SYNC WHERE EMPNIT=@E", cnh)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    tipo = dr(0).ToString
                Else

                End If
                dr.Close()

            Catch ex As Exception
                tipo = "A"
            End Try
        End Using

        Return tipo

    End Function

    'OBTIENE E INSERTA EL CATALOGO GENERAL DE PRODUCTOS DESDE EL HOSTING
    Public Function GetProductosPreciosInvsaldo(ByVal empnit As String, ByVal destEmpnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal tipoprecio As String) As Boolean

        Dim result As Boolean

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,
                                            BONO,INVMINIMO,INVMAXIMO,EXENTO,NF,ISNULL(TIPOPROD,'P') AS TIPOPROD FROM COMMUNITY_PRODUCTOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                'cmdh.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)
                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()
                bcCopy.DestinationTableName = "PRODUCTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

                Dim sqltipo As String = "PRECIO"
                Select Case tipoprecio
                    Case "A"
                        sqltipo = "PRECIO"
                    Case "B"
                        sqltipo = "MAYOREOA"
                    Case "C"
                        sqltipo = "MAYOREOB"
                    Case "D"
                        sqltipo = "MAYOREOC"

                End Select

                Dim sqlPRODUCTOS As String

                If destEmpnit = "COMPRAS" Then

                    sqlPRODUCTOS = "SELECT ID,@EMPNITDEST AS EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO,MAYOREOA,MAYOREOB,MAYOREOC, PESO FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN"
                Else

                    sqlPRODUCTOS = "SELECT ID,@EMPNITDEST AS EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO," + sqltipo + " AS PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO," + sqltipo + " AS MAYOREOA," + sqltipo + " AS MAYOREOB," + sqltipo + " AS MAYOREOC,PESO FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN"

                End If

                'INSERTA LOS DATOS A LA TABLA PRECIOS
                Dim cmdh2 As New SqlCommand(sqlPRODUCTOS, cnh)
                'cmdh2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh2.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh2.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh2 As SqlDataReader = cmdh2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrServerConection)
                Dim cn2 As New SqlConnection(StrServerConection)
                cn2.Open()
                bcCopy2.DestinationTableName = "PRECIOS"
                bcCopy2.WriteToServer(drh2)
                drh2.Close()
                cn2.Close()

                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT ID,@EMPNITDEST AS EMPNIT,@ANIO AS ANIO,@MES AS MES,CODPROD,0 AS SALDOINICIAL,0 AS ENTRADAS,0 AS SALIDAS,0 AS SALDO,CODBODEGA,NOLOTE FROM COMMUNITY_INVSALDO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh3.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh3.Parameters.AddWithValue("@TOKEN", Token)
                cmdh3.Parameters.AddWithValue("@ANIO", anioproceso)
                cmdh3.Parameters.AddWithValue("@MES", mesproceso)
                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                Dim cn3 As New SqlConnection(StrServerConection)
                cn3.Open()
                bcCopy3.DestinationTableName = "INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()
                cn3.Close()

                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMEDIDA,TIPOPRECIO FROM COMMUNITY_MEDIDAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh4.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh4.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                Dim cn4 As New SqlConnection(StrServerConection)
                cn4.Open()
                bcCopy4.DestinationTableName = "MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()
                cn4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMARCA,DESMARCA FROM COMMUNITY_MARCAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh5.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh5.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                Dim cn5 As New SqlConnection(StrServerConection)
                cn5.Open()
                bcCopy5.DestinationTableName = "MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()
                cn5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLAUNO,DESCLAUNO FROM COMMUNITY_CLASIFICACIONUNO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh6.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh6.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                Dim cn6 As New SqlConnection(StrServerConection)
                cn6.Open()
                bcCopy6.DestinationTableName = "CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()
                cn6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLADOS,DESCLADOS FROM COMMUNITY_CLASIFICACIONDOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh7.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh7.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                Dim cn7 As New SqlConnection(StrServerConection)
                cn7.Open()
                bcCopy7.DestinationTableName = "CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()
                cn7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLATRES,DESCLATRES FROM COMMUNITY_CLASIFICACIONTRES WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh8.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh8.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                Dim cn8 As New SqlConnection(StrServerConection)
                cn8.Open()
                bcCopy8.DestinationTableName = "CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()
                cn8.Close()



                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'OBTIENE E INSERTA EL CATALOGO GENERAL DE PRODUCTOS DESDE EL HOSTING - SIN PRECIOS
    Public Function GetProductosPreciosInvsaldo2(ByVal empnit As String, ByVal destEmpnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer) As Boolean
        Dim result As Boolean

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,
                                            BONO,INVMINIMO,INVMAXIMO,EXENTO,NF,ISNULL(TIPOPROD,'P') AS TIPOPROD FROM COMMUNITY_PRODUCTOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                cmdh.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)
                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()
                bcCopy.DestinationTableName = "PRODUCTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT ID,@EMPNITDEST AS EMPNIT,@ANIO AS ANIO,@MES AS MES,CODPROD,0 AS SALDOINICIAL,0 AS ENTRADAS,0 AS SALIDAS,0 AS SALDO,CODBODEGA,NOLOTE FROM COMMUNITY_INVSALDO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh3.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh3.Parameters.AddWithValue("@TOKEN", Token)
                cmdh3.Parameters.AddWithValue("@ANIO", anioproceso)
                cmdh3.Parameters.AddWithValue("@MES", mesproceso)
                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                Dim cn3 As New SqlConnection(StrServerConection)
                cn3.Open()
                bcCopy3.DestinationTableName = "INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()
                cn3.Close()

                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMEDIDA,TIPOPRECIO FROM COMMUNITY_MEDIDAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh4.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh4.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                Dim cn4 As New SqlConnection(StrServerConection)
                cn4.Open()
                bcCopy4.DestinationTableName = "MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()
                cn4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMARCA,DESMARCA FROM COMMUNITY_MARCAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh5.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh5.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                Dim cn5 As New SqlConnection(StrServerConection)
                cn5.Open()
                bcCopy5.DestinationTableName = "MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()
                cn5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLAUNO,DESCLAUNO FROM COMMUNITY_CLASIFICACIONUNO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh6.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh6.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                Dim cn6 As New SqlConnection(StrServerConection)
                cn6.Open()
                bcCopy6.DestinationTableName = "CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()
                cn6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLADOS,DESCLADOS FROM COMMUNITY_CLASIFICACIONDOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh7.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh7.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                Dim cn7 As New SqlConnection(StrServerConection)
                cn7.Open()
                bcCopy7.DestinationTableName = "CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()
                cn7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLATRES,DESCLATRES FROM COMMUNITY_CLASIFICACIONTRES WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh8.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh8.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                Dim cn8 As New SqlConnection(StrServerConection)
                cn8.Open()
                bcCopy8.DestinationTableName = "CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()
                cn8.Close()



                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function


    'OBTIENE E INSERTA EL CATALOGO GENERAL DE PRODUCTOS DESDE EL HOSTING - SIN PRECIOS TEMP
    Public Function GetProductosInvsaldoTemp(ByVal empnit As String, ByVal destEmpnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cd As New SqlCommand("DELETE FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_INVSALDO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MEDIDAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MARCAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONUNO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONDOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONTRES WHERE EMPNIT=@E;", cn)
                cd.Parameters.AddWithValue("@E", destEmpnit)
                cd.ExecuteNonQuery()

            Catch ex As Exception

            End Try

        End Using

        Using cnh As New SqlConnection(StrHostConnection)


            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,
                                            BONO,INVMINIMO,INVMAXIMO,EXENTO,NF,ISNULL(TIPOPROD,'P') AS TIPOPROD FROM COMMUNITY_PRODUCTOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                cmdh.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)
                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()
                bcCopy.DestinationTableName = "TEMPSYNC_PRODUCTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT ID,@EMPNITDEST AS EMPNIT,@ANIO AS ANIO,@MES AS MES,CODPROD,0 AS SALDOINICIAL,0 AS ENTRADAS,0 AS SALIDAS,0 AS SALDO,CODBODEGA,NOLOTE FROM COMMUNITY_INVSALDO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh3.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh3.Parameters.AddWithValue("@TOKEN", Token)
                cmdh3.Parameters.AddWithValue("@ANIO", anioproceso)
                cmdh3.Parameters.AddWithValue("@MES", mesproceso)
                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                Dim cn3 As New SqlConnection(StrServerConection)
                cn3.Open()
                bcCopy3.DestinationTableName = "TEMPSYNC_INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()
                cn3.Close()

                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMEDIDA,TIPOPRECIO FROM COMMUNITY_MEDIDAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh4.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh4.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                Dim cn4 As New SqlConnection(StrServerConection)
                cn4.Open()
                bcCopy4.DestinationTableName = "TEMPSYNC_MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()
                cn4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMARCA,DESMARCA FROM COMMUNITY_MARCAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh5.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh5.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                Dim cn5 As New SqlConnection(StrServerConection)
                cn5.Open()
                bcCopy5.DestinationTableName = "TEMPSYNC_MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()
                cn5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLAUNO,DESCLAUNO FROM COMMUNITY_CLASIFICACIONUNO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh6.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh6.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                Dim cn6 As New SqlConnection(StrServerConection)
                cn6.Open()
                bcCopy6.DestinationTableName = "TEMPSYNC_CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()
                cn6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLADOS,DESCLADOS FROM COMMUNITY_CLASIFICACIONDOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh7.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh7.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                Dim cn7 As New SqlConnection(StrServerConection)
                cn7.Open()
                bcCopy7.DestinationTableName = "TEMPSYNC_CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()
                cn7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLATRES,DESCLATRES FROM COMMUNITY_CLASIFICACIONTRES WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh8.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh8.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                Dim cn8 As New SqlConnection(StrServerConection)
                cn8.Open()
                bcCopy8.DestinationTableName = "TEMPSYNC_CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()
                cn8.Close()

                'VERIFICA SI EXISTEN ROWS EN LA TABLA PRODUCTOS
                Using cn0 As New SqlConnection(StrServerConection)
                    Try
                        If cn0.State <> ConnectionState.Open Then
                            cn0.Open()
                        End If
                        Dim tbl As New DataTable
                        Dim cmdverificar As New SqlCommand("SELECT COUNT(CODPROD) AS C FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E", cn0)
                        cmdverificar.Parameters.AddWithValue("@E", empnit)
                        Dim da As New SqlDataAdapter
                        da.SelectCommand = cmdverificar
                        da.Fill(tbl)
                        If tbl.Rows.Count > 0 Then
                            result = True
                        Else
                            result = False
                        End If

                    Catch ex As Exception
                        result = False
                    End Try
                End Using


            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function



    Public Function getTipoPrecioHosting(ByVal empnit As String) As String

        Dim tipo As String = ""

        Using cnh As New SqlConnection(StrHostConnection)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT TIPOPRECIO FROM COMMUNITY_EMPRESAS_SYNC WHERE EMPNIT=@E", cnh)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                dr.Read()
                If dr.HasRows = True Then
                    tipo = dr(0).ToString
                Else
                    tipo = "A"
                End If

            Catch ex As Exception

            End Try
        End Using

        Return tipo

    End Function

    'OBTIENE E INSERTA EL CATALOGO GENERAL DE PRODUCTOS Y PRECIOS DESDE EL HOSTING 
    Public Function GetProductosInvsaldoPreciosTemp(ByVal empnit As String, ByVal destEmpnit As String) As Boolean
        Dim result As Boolean

        Dim tipoprecio As String = getTipoPrecioHosting(destEmpnit)

        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cd As New SqlCommand("DELETE FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_PRECIOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_INVSALDO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MEDIDAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MARCAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONUNO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONDOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONTRES WHERE EMPNIT=@E;", cn)
                cd.Parameters.AddWithValue("@E", destEmpnit)
                cd.ExecuteNonQuery()

            Catch ex As Exception

            End Try

        End Using

        Using cnh As New SqlConnection(StrHostConnection)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If


                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,BONO,
                                            INVMINIMO,INVMAXIMO,EXENTO,NF,ISNULL(TIPOPROD,'P') AS TIPOPROD FROM COMMUNITY_PRODUCTOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                cmdh.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)
                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()
                bcCopy.DestinationTableName = "TEMPSYNC_PRODUCTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

                'INSERTA LOS DATOS A LA TABLA PRECIOS
                Dim sqlpreOLD As String = "SELECT 0 AS ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD, CODMEDIDA, EQUIVALE,
                                            COSTO, PRECIO, UTILIDAD, PORCUTILIDAD,
                                            HABILITADO, MAYOREOA, MAYOREOB, MAYOREOC, PESO, BONO
                                            FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN"

                Dim sqlpre As String = ""
                Dim precio As String = ""
                Select Case tipoprecio
                    Case "A"
                        precio = "PRECIO"
                    Case "B"
                        precio = "MAYOREOA"
                    Case "C"
                        precio = "MAYOREOB"
                    Case "D"
                        precio = "MAYOREOC"
                End Select

                If destEmpnit = "COMPRAS" Then

                    sqlpre = "SELECT 0 AS ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD, CODMEDIDA, EQUIVALE,
                                            COSTO, 
                                            PRECIO, 
                                            UTILIDAD, PORCUTILIDAD,
                                            HABILITADO, 
                                            MAYOREOA, 
                                            MAYOREOB, 
                                            MAYOREOC, 
                                            PESO, BONO
                                            FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN"


                Else

                    sqlpre = "SELECT 0 AS ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD, CODMEDIDA, EQUIVALE,
                                            COSTO, 
                                            " + precio + " AS PRECIO, 
                                            UTILIDAD, PORCUTILIDAD,
                                            HABILITADO, 
                                            " + precio + " AS MAYOREOA, 
                                            " + precio + " AS MAYOREOB, 
                                            " + precio + " AS MAYOREOC, 
                                            PESO, BONO
                                            FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN"

                End If

                Dim cmdh2 As New SqlCommand(sqlpre, cnh)
                cmdh2.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh2.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh2 As SqlDataReader = cmdh2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrServerConection)
                Dim cn2 As New SqlConnection(StrServerConection)
                cn2.Open()
                bcCopy2.DestinationTableName = "TEMPSYNC_PRECIOS"
                bcCopy2.WriteToServer(drh2)
                drh2.Close()
                cn2.Close()

                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT ID,@EMPNITDEST AS EMPNIT,0 AS ANIO,0 AS MES,CODPROD,0 AS SALDOINICIAL,0 AS ENTRADAS,0 AS SALIDAS,0 AS SALDO,CODBODEGA,NOLOTE FROM COMMUNITY_INVSALDO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh3.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh3.Parameters.AddWithValue("@TOKEN", Token)

                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                Dim cn3 As New SqlConnection(StrServerConection)
                cn3.Open()
                bcCopy3.DestinationTableName = "TEMPSYNC_INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()
                cn3.Close()

                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMEDIDA,TIPOPRECIO FROM COMMUNITY_MEDIDAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh4.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh4.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                Dim cn4 As New SqlConnection(StrServerConection)
                cn4.Open()
                bcCopy4.DestinationTableName = "TEMPSYNC_MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()
                cn4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMARCA,DESMARCA FROM COMMUNITY_MARCAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh5.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh5.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                Dim cn5 As New SqlConnection(StrServerConection)
                cn5.Open()
                bcCopy5.DestinationTableName = "TEMPSYNC_MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()
                cn5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLAUNO,DESCLAUNO FROM COMMUNITY_CLASIFICACIONUNO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh6.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh6.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                Dim cn6 As New SqlConnection(StrServerConection)
                cn6.Open()
                bcCopy6.DestinationTableName = "TEMPSYNC_CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()
                cn6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLADOS,DESCLADOS FROM COMMUNITY_CLASIFICACIONDOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh7.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh7.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                Dim cn7 As New SqlConnection(StrServerConection)
                cn7.Open()
                bcCopy7.DestinationTableName = "TEMPSYNC_CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()
                cn7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLATRES,DESCLATRES FROM COMMUNITY_CLASIFICACIONTRES WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh8.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh8.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                Dim cn8 As New SqlConnection(StrServerConection)
                cn8.Open()
                bcCopy8.DestinationTableName = "TEMPSYNC_CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()
                cn8.Close()


                Using cn0 As New SqlConnection(StrServerConection)
                    Try
                        If cn0.State <> ConnectionState.Open Then
                            cn0.Open()
                        End If
                        Dim tbl As New DataTable
                        Dim cmdverificar As New SqlCommand("SELECT COUNT(CODPROD) AS C FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E", cn0)
                        cmdverificar.Parameters.AddWithValue("@E", empnit)
                        Dim da As New SqlDataAdapter
                        da.SelectCommand = cmdverificar
                        da.Fill(tbl)
                        If tbl.Rows.Count > 0 Then
                            result = True
                        Else
                            result = False
                        End If

                    Catch ex As Exception
                        result = False
                    End Try
                End Using


            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function GetProductosInvsaldoPreciosTemp2(ByVal empnit As String, ByVal destEmpnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cd As New SqlCommand("DELETE FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_PRECIOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_INVSALDO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MEDIDAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MARCAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONUNO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONDOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONTRES WHERE EMPNIT=@E;", cn)
                cd.Parameters.AddWithValue("@E", destEmpnit)
                cd.ExecuteNonQuery()

            Catch ex As Exception

            End Try

        End Using

        Using cnh As New SqlConnection(StrHostConnection)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If


                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,BONO,
                                            INVMINIMO,INVMAXIMO,EXENTO,NF,ISNULL(TIPOPROD,'P') AS TIPOPROD FROM COMMUNITY_PRODUCTOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                cmdh.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)
                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()
                bcCopy.DestinationTableName = "TEMPSYNC_PRODUCTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

                Dim cmdh2 As New SqlCommand("SELECT 0 AS ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD, CODMEDIDA, EQUIVALE,
                                            COSTO, 
                                            PRECIO, 
                                            UTILIDAD, PORCUTILIDAD,
                                            HABILITADO, 
                                            MAYOREOA, 
                                            MAYOREOB, 
                                            MAYOREOC, 
                                            PESO, 
                                            BONO
                                            FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                cmdh2.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh2.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh2 As SqlDataReader = cmdh2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrServerConection)
                Dim cn2 As New SqlConnection(StrServerConection)
                cn2.Open()
                bcCopy2.DestinationTableName = "TEMPSYNC_PRECIOS"
                bcCopy2.WriteToServer(drh2)
                drh2.Close()
                cn2.Close()

                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT ID,@EMPNITDEST AS EMPNIT,0 AS ANIO,0 AS MES,CODPROD,0 AS SALDOINICIAL,0 AS ENTRADAS,0 AS SALIDAS,0 AS SALDO,CODBODEGA,NOLOTE FROM COMMUNITY_INVSALDO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh3.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh3.Parameters.AddWithValue("@TOKEN", Token)

                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                Dim cn3 As New SqlConnection(StrServerConection)
                cn3.Open()
                bcCopy3.DestinationTableName = "TEMPSYNC_INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()
                cn3.Close()

                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMEDIDA,TIPOPRECIO FROM COMMUNITY_MEDIDAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh4.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh4.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                Dim cn4 As New SqlConnection(StrServerConection)
                cn4.Open()
                bcCopy4.DestinationTableName = "TEMPSYNC_MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()
                cn4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMARCA,DESMARCA FROM COMMUNITY_MARCAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh5.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh5.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                Dim cn5 As New SqlConnection(StrServerConection)
                cn5.Open()
                bcCopy5.DestinationTableName = "TEMPSYNC_MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()
                cn5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLAUNO,DESCLAUNO FROM COMMUNITY_CLASIFICACIONUNO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh6.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh6.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                Dim cn6 As New SqlConnection(StrServerConection)
                cn6.Open()
                bcCopy6.DestinationTableName = "TEMPSYNC_CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()
                cn6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLADOS,DESCLADOS FROM COMMUNITY_CLASIFICACIONDOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh7.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh7.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                Dim cn7 As New SqlConnection(StrServerConection)
                cn7.Open()
                bcCopy7.DestinationTableName = "TEMPSYNC_CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()
                cn7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLATRES,DESCLATRES FROM COMMUNITY_CLASIFICACIONTRES WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh8.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh8.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                Dim cn8 As New SqlConnection(StrServerConection)
                cn8.Open()
                bcCopy8.DestinationTableName = "TEMPSYNC_CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()
                cn8.Close()


                Using cn0 As New SqlConnection(StrServerConection)
                    Try
                        If cn0.State <> ConnectionState.Open Then
                            cn0.Open()
                        End If
                        Dim tbl As New DataTable
                        Dim cmdverificar As New SqlCommand("SELECT COUNT(CODPROD) AS C FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E", cn0)
                        cmdverificar.Parameters.AddWithValue("@E", empnit)
                        Dim da As New SqlDataAdapter
                        da.SelectCommand = cmdverificar
                        da.Fill(tbl)
                        If tbl.Rows.Count > 0 Then
                            result = True
                        Else
                            result = False
                        End If

                    Catch ex As Exception
                        result = False
                    End Try
                End Using


            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function GetProductosInvsaldoPreciosTempCC(ByVal empnit As String, ByVal destEmpnit As String, ByVal anioproceso As Integer, ByVal mesproceso As Integer) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cd As New SqlCommand("DELETE FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_PRECIOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_INVSALDO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MEDIDAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_MARCAS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONUNO WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONDOS WHERE EMPNIT=@E;
                                        DELETE FROM TEMPSYNC_CLASIFICACIONTRES WHERE EMPNIT=@E;", cn)
                cd.Parameters.AddWithValue("@E", destEmpnit)
                cd.ExecuteNonQuery()

            Catch ex As Exception

            End Try

        End Using

        Using cnh As New SqlConnection(StrHostConnection)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If


            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using

        Using cnh As New SqlConnection(StrHostConnection)


            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,BONO,
                                            INVMINIMO,INVMAXIMO,EXENTO,NF,ISNULL(TIPOPROD,'P') AS TIPOPROD FROM COMMUNITY_PRODUCTOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                cmdh.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)
                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()
                bcCopy.DestinationTableName = "TEMPSYNC_PRODUCTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()



                'INSERTA LOS DATOS A LA TABLA PRECIOS
                Dim sqlpreOLD As String = "SELECT 0 AS ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD, CODMEDIDA, EQUIVALE,
                                            COSTO, PRECIO, UTILIDAD, PORCUTILIDAD,
                                            HABILITADO, MAYOREOA, MAYOREOB, MAYOREOC, PESO, BONO
                                            FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN"

                Dim cmdh2 As New SqlCommand("SELECT 0 AS ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD, CODMEDIDA, EQUIVALE,
                                            COSTO, 
                                            PRECIO, 
                                            UTILIDAD, PORCUTILIDAD,
                                            HABILITADO, 
                                            MAYOREOA, 
                                            MAYOREOB, 
                                            MAYOREOC, 
                                            PESO, BONO
                                            FROM COMMUNITY_PRECIOS WHERE EMPNIT='GENERAL' AND TOKEN = @TOKEN", cnh)
                cmdh2.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh2.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh2 As SqlDataReader = cmdh2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrServerConection)
                Dim cn2 As New SqlConnection(StrServerConection)
                cn2.Open()
                bcCopy2.DestinationTableName = "TEMPSYNC_PRECIOS"
                bcCopy2.WriteToServer(drh2)
                drh2.Close()
                cn2.Close()

                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT ID,@EMPNITDEST AS EMPNIT,@ANIO AS ANIO,@MES AS MES,CODPROD,0 AS SALDOINICIAL,0 AS ENTRADAS,0 AS SALIDAS,0 AS SALDO,CODBODEGA,NOLOTE FROM COMMUNITY_INVSALDO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh3.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh3.Parameters.AddWithValue("@TOKEN", Token)
                cmdh3.Parameters.AddWithValue("@ANIO", anioproceso)
                cmdh3.Parameters.AddWithValue("@MES", mesproceso)
                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                Dim cn3 As New SqlConnection(StrServerConection)
                cn3.Open()
                bcCopy3.DestinationTableName = "TEMPSYNC_INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()
                cn3.Close()

                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMEDIDA,TIPOPRECIO FROM COMMUNITY_MEDIDAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh4.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh4.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                Dim cn4 As New SqlConnection(StrServerConection)
                cn4.Open()
                bcCopy4.DestinationTableName = "TEMPSYNC_MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()
                cn4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMARCA,DESMARCA FROM COMMUNITY_MARCAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh5.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh5.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                Dim cn5 As New SqlConnection(StrServerConection)
                cn5.Open()
                bcCopy5.DestinationTableName = "TEMPSYNC_MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()
                cn5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLAUNO,DESCLAUNO FROM COMMUNITY_CLASIFICACIONUNO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh6.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh6.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                Dim cn6 As New SqlConnection(StrServerConection)
                cn6.Open()
                bcCopy6.DestinationTableName = "TEMPSYNC_CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()
                cn6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLADOS,DESCLADOS FROM COMMUNITY_CLASIFICACIONDOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh7.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh7.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                Dim cn7 As New SqlConnection(StrServerConection)
                cn7.Open()
                bcCopy7.DestinationTableName = "TEMPSYNC_CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()
                cn7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLATRES,DESCLATRES FROM COMMUNITY_CLASIFICACIONTRES WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh8.Parameters.AddWithValue("@EMPNITDEST", destEmpnit)
                cmdh8.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                Dim cn8 As New SqlConnection(StrServerConection)
                cn8.Open()
                bcCopy8.DestinationTableName = "TEMPSYNC_CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()
                cn8.Close()


                Using cn0 As New SqlConnection(StrServerConection)
                    Try
                        If cn0.State <> ConnectionState.Open Then
                            cn0.Open()
                        End If
                        Dim tbl As New DataTable
                        Dim cmdverificar As New SqlCommand("SELECT COUNT(CODPROD) AS C FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E", cn0)
                        cmdverificar.Parameters.AddWithValue("@E", empnit)
                        Dim da As New SqlDataAdapter
                        da.SelectCommand = cmdverificar
                        da.Fill(tbl)
                        If tbl.Rows.Count > 0 Then
                            result = True
                        Else
                            result = False
                        End If

                    Catch ex As Exception
                        result = False
                    End Try
                End Using


            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'CARGA LOS DATOS DE LAS TABLAS TEMPORALES HACIA LAS TABLAS NORMALES LUEGO DE HABER SIDO REEMPLAZADOS EN EMPNIT
    'PRODUCTOS, INVSALDO
    Public Function replaceProductosInvsaldoTemp(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmd As New SqlCommand("SELECT * FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)

                bcCopy.DestinationTableName = "PRODUCTOS"
                bcCopy.WriteToServer(dr)
                dr.Close()


                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT * FROM TEMPSYNC_INVSALDO WHERE EMPNIT=@E", cn)
                cmdh3.Parameters.AddWithValue("@E", empnit)
                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                bcCopy3.DestinationTableName = "INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()


                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT * FROM TEMPSYNC_MEDIDAS WHERE EMPNIT=@E", cn)
                cmdh4.Parameters.AddWithValue("@E", empnit)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                bcCopy4.DestinationTableName = "MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT * FROM TEMPSYNC_MARCAS WHERE EMPNIT=@E", cn)
                cmdh5.Parameters.AddWithValue("@E", empnit)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                bcCopy5.DestinationTableName = "MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT * FROM TEMPSYNC_CLASIFICACIONUNO WHERE EMPNIT=@E", cn)
                cmdh6.Parameters.AddWithValue("@E", empnit)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                bcCopy6.DestinationTableName = "CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT * FROM TEMPSYNC_CLASIFICACIONDOS WHERE EMPNIT=@E", cn)
                cmdh7.Parameters.AddWithValue("@E", empnit)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                bcCopy7.DestinationTableName = "CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT * FROM TEMPSYNC_CLASIFICACIONTRES WHERE EMPNIT=@E", cn)
                cmdh8.Parameters.AddWithValue("@E", empnit)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                bcCopy8.DestinationTableName = "CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()

                result = True

            Catch ex As Exception
                MsgBox("replace: " + ex.ToString)
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function


    'CARGA LOS DATOS DE LAS TABLAS TEMPORALES HACIA LAS TABLAS NORMALES LUEGO DE HABER SIDO REEMPLAZADOS EN EMPNIT
    'PRODUCTOS,PRECIOS,INVSALDO
    Public Function replaceProductosInvsaldoPreciosTemp(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmd As New SqlCommand("SELECT * FROM TEMPSYNC_PRODUCTOS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)

                bcCopy.DestinationTableName = "PRODUCTOS"
                bcCopy.WriteToServer(dr)
                dr.Close()

                'INSERTA LOS DATOS A LA TABLA PRECIOS
                Dim cmd2 As New SqlCommand("SELECT ID, EMPNIT, CODPROD,CODMEDIDA,EQUIVALE, COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO, MAYOREOA,MAYOREOB,MAYOREOC,PESO,BONO, 0 AS MAYOREOE FROM TEMPSYNC_PRECIOS WHERE EMPNIT=@E", cn)
                cmd2.Parameters.AddWithValue("@E", empnit)
                Dim dr2 As SqlDataReader = cmd2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrServerConection)

                bcCopy2.DestinationTableName = "PRECIOS"
                bcCopy2.WriteToServer(dr2)
                dr2.Close()


                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT * FROM TEMPSYNC_INVSALDO WHERE EMPNIT=@E", cn)
                cmdh3.Parameters.AddWithValue("@E", empnit)
                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                bcCopy3.DestinationTableName = "INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()


                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT * FROM TEMPSYNC_MEDIDAS WHERE EMPNIT=@E", cn)
                cmdh4.Parameters.AddWithValue("@E", empnit)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                bcCopy4.DestinationTableName = "MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT * FROM TEMPSYNC_MARCAS WHERE EMPNIT=@E", cn)
                cmdh5.Parameters.AddWithValue("@E", empnit)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                bcCopy5.DestinationTableName = "MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT * FROM TEMPSYNC_CLASIFICACIONUNO WHERE EMPNIT=@E", cn)
                cmdh6.Parameters.AddWithValue("@E", empnit)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                bcCopy6.DestinationTableName = "CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT * FROM TEMPSYNC_CLASIFICACIONDOS WHERE EMPNIT=@E", cn)
                cmdh7.Parameters.AddWithValue("@E", empnit)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                bcCopy7.DestinationTableName = "CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT * FROM TEMPSYNC_CLASIFICACIONTRES WHERE EMPNIT=@E", cn)
                cmdh8.Parameters.AddWithValue("@E", empnit)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                bcCopy8.DestinationTableName = "CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()

                result = True

            Catch ex As Exception
                MsgBox("replace: " + ex.ToString)
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function



    'OBTIENE E INSERTA EL CATALOGO GENERAL DE PRODUCTOS DESDE EL HOSTING - SIN PRECIOS TEMP
    Public Function GetProductosInvsaldoFromTemp(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cnh As New SqlConnection(StrHostConnection)
            If cnh.State <> ConnectionState.Open Then
                cnh.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT ID,
                                            @EMPNITDEST AS EMPNIT,
                                            CODPROD,CODPROD2,   
                                            DESPROD,DESPROD2,DESPROD3, 
                                            UXC,CODMEDIDACOMPRA,COSTO,
                                            CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                                            HABILITADO,FOTO,VENCIMIENTO,SERIE,
                                            BONO,INVMINIMO,INVMAXIMO,EXENTO,NF,ISNULL(TIPOPROD,'P') AS TIPOPROD FROM TEMPSYNC_PRODUCTOS", cnh)
                cmdh.Parameters.AddWithValue("@EMPNITDEST", empnit)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrServerConection)
                Dim cn As New SqlConnection(StrServerConection)
                cn.Open()
                bcCopy.DestinationTableName = "PRODUCTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

                'INSERTA LOS DATOS A LA TABLA INVSALDO
                Dim cmdh3 As New SqlCommand("SELECT ID,@EMPNITDEST AS EMPNIT,@ANIO AS ANIO,@MES AS MES,CODPROD,0 AS SALDOINICIAL,0 AS ENTRADAS,0 AS SALIDAS,0 AS SALDO,CODBODEGA,NOLOTE FROM TEMPSYNC_INVSALDO", cnh)
                cmdh3.Parameters.AddWithValue("@EMPNITDEST", empnit)
                Dim drh3 As SqlDataReader = cmdh3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrServerConection)
                Dim cn3 As New SqlConnection(StrServerConection)
                cn3.Open()
                bcCopy3.DestinationTableName = "INVSALDO"
                bcCopy3.WriteToServer(drh3)
                drh3.Close()
                cn3.Close()

                'INSERTA LOS DATOS A LA TABLA MEDIDAS
                Dim cmdh4 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMEDIDA,TIPOPRECIO FROM TEMPSYNC_MEDIDAS", cnh)
                cmdh4.Parameters.AddWithValue("@EMPNITDEST", empnit)
                cmdh4.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh4 As SqlDataReader = cmdh4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrServerConection)
                Dim cn4 As New SqlConnection(StrServerConection)
                cn4.Open()
                bcCopy4.DestinationTableName = "MEDIDAS"
                bcCopy4.WriteToServer(drh4)
                drh4.Close()
                cn4.Close()

                'INSERTA LOS DATOS A LA TABLA MARCAS
                Dim cmdh5 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODMARCA,DESMARCA FROM COMMUNITY_MARCAS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh5.Parameters.AddWithValue("@EMPNITDEST", empnit)
                cmdh5.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh5 As SqlDataReader = cmdh5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrServerConection)
                Dim cn5 As New SqlConnection(StrServerConection)
                cn5.Open()
                bcCopy5.DestinationTableName = "MARCAS"
                bcCopy5.WriteToServer(drh5)
                drh5.Close()
                cn5.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION UNO
                Dim cmdh6 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLAUNO,DESCLAUNO FROM COMMUNITY_CLASIFICACIONUNO WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh6.Parameters.AddWithValue("@EMPNITDEST", empnit)
                cmdh6.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh6 As SqlDataReader = cmdh6.ExecuteReader

                Dim bcCopy6 As New SqlBulkCopy(StrServerConection)
                Dim cn6 As New SqlConnection(StrServerConection)
                cn6.Open()
                bcCopy6.DestinationTableName = "CLASIFICACIONUNO"
                bcCopy6.WriteToServer(drh6)
                drh6.Close()
                cn6.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION DOS
                Dim cmdh7 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLADOS,DESCLADOS FROM COMMUNITY_CLASIFICACIONDOS WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh7.Parameters.AddWithValue("@EMPNITDEST", empnit)
                cmdh7.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh7 As SqlDataReader = cmdh7.ExecuteReader

                Dim bcCopy7 As New SqlBulkCopy(StrServerConection)
                Dim cn7 As New SqlConnection(StrServerConection)
                cn7.Open()
                bcCopy7.DestinationTableName = "CLASIFICACIONDOS"
                bcCopy7.WriteToServer(drh7)
                drh7.Close()
                cn7.Close()

                'INSERTA LOS DATOS A LA TABLA CLASIFICACION TRES
                Dim cmdh8 As New SqlCommand("SELECT @EMPNITDEST AS EMPNIT,CODCLATRES,DESCLATRES FROM COMMUNITY_CLASIFICACIONTRES WHERE EMPNIT='GENERAL' AND TOKEN=@TOKEN", cnh)
                'cmdh3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh8.Parameters.AddWithValue("@EMPNITDEST", empnit)
                cmdh8.Parameters.AddWithValue("@TOKEN", Token)
                Dim drh8 As SqlDataReader = cmdh8.ExecuteReader

                Dim bcCopy8 As New SqlBulkCopy(StrServerConection)
                Dim cn8 As New SqlConnection(StrServerConection)
                cn8.Open()
                bcCopy8.DestinationTableName = "CLASIFICACIONTRES"
                bcCopy8.WriteToServer(drh8)
                drh8.Close()
                cn8.Close()



                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'ACTUALIZA EL COSTO DE LOS PRECIOS EN BASE AL COSTO DE LOS PRODUCTOS - APLICA PARA SINCRONIZACION SIN PRECIOS
    Public Function UpdCostoProductos(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            Try

                If cn.State = ConnectionState.Open Then
                Else
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE       PRECIOS SET PRECIOS.COSTO = T.COSTO * PRECIOS.EQUIVALE
                                           FROM         PRECIOS INNER JOIN (SELECT CODPROD, COSTO FROM PRODUCTOS WHERE EMPNIT= @EMPNIT) T ON PRECIOS.CODPROD = T.CODPROD
                                           WHERE        PRECIOS.EMPNIT = @EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True
            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using
        Return result
    End Function

#End Region


#Region " ** CATALOGOS ** "

    'OBTIENE LA LISTA DE EMPRESAS DEL TOKEN
    Public Function tblEmpresas(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                'ISNULL(WEB_DOCUMENTOS.FECHAENVIADO, '01/01/2018') AS FECHAENVIADO
                'ISNULL(WEB_DOCUMENTOS.FECHA, '01/01/2018') AS FECHA, 

                Dim SQL As String = "SELECT EMPNIT,EMPNOMBRE FROM COMMUNITY_EMPRESAS_SYNC WHERE TOKEN=@TOKEN AND EMPNIT<>@EMPNIT"

                Dim cmd As New SqlCommand(SQL, cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function

    'OBTIENE LA LISTA DE DOCUMENTOS PENDIENTES
    Public Function tblPedidosPendientesDocs(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                'ISNULL(WEB_DOCUMENTOS.FECHAENVIADO, '01/01/2018') AS FECHAENVIADO
                'ISNULL(WEB_DOCUMENTOS.FECHA, '01/01/2018') AS FECHA, 

                Dim SQL As String = "SELECT WEB_DOCUMENTOS.CODDOC, 
                                                  WEB_DOCUMENTOS.CORRELATIVO, 
                                                  WEB_DOCUMENTOS.CODVEN, 
                                                  VENDEDORES.NOMVEN, 
                                                  WEB_DOCUMENTOS.CODCLIENTE, 
                                                  CLIENTES.NOMCLIENTE,
                                                  ISNULL(WEB_DOCUMENTOS.TOTALCOSTO, 0) AS TOTALCOSTO, 
                                                  WEB_DOCUMENTOS.TOTALVENTA, 
                                                  ISNULL(WEB_DOCUMENTOS.FECHAENVIADO, '01/01/2018') AS FECHAENVIADO,
                                                  CONCAT(WEB_DOCUMENTOS.ANIO, '-',WEB_DOCUMENTOS.MES,'-',WEB_DOCUMENTOS.DIA) AS FECHA,
                                                  ISNULL(CLIENTES.NIT, 'SN') AS NITCLIE, 
                                                  ISNULL(WEB_DOCUMENTOS.CODEMBARQUE, 'SN') AS DESREP, 
                                                  WEB_DOCUMENTOS.CODST, 
                                                  PARAM_STATUS.DESST,
                                                  ISNULL(WEB_DOCUMENTOS.CODREP,0) AS CODREP,
                                                  ISNULL(WEB_DOCUMENTOS.ENTREGADO,'NO') AS ENTREGADO,
                                                  ISNULL(WEB_DOCUMENTOS.OBS,'SN') AS OBS
                                        FROM WEB_DOCUMENTOS LEFT OUTER JOIN
                         PARAM_STATUS ON WEB_DOCUMENTOS.CODST = PARAM_STATUS.CODST LEFT OUTER JOIN
                         REPARTIDORES ON WEB_DOCUMENTOS.CODREP = REPARTIDORES.CODREP AND WEB_DOCUMENTOS.EMPNIT = REPARTIDORES.EMPNIT AND 
                         WEB_DOCUMENTOS.TOKEN = REPARTIDORES.TOKEN LEFT OUTER JOIN
                         CLIENTES ON WEB_DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE AND WEB_DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND WEB_DOCUMENTOS.TOKEN = CLIENTES.TOKEN LEFT OUTER JOIN
                         VENDEDORES ON WEB_DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND WEB_DOCUMENTOS.TOKEN = VENDEDORES.TOKEN AND WEB_DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT
                         WHERE (WEB_DOCUMENTOS.TOKEN = @TOKEN) 
                            AND (WEB_DOCUMENTOS.EMPNIT = @EMPNIT)
                            AND (WEB_DOCUMENTOS.ENTREGADO='NO')"

                Dim cmd As New SqlCommand(SQL, cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function

    'OBTIENE LA LISTA DE DOCUMENTOS PENDIENTES DOMICILIO
    Public Function tblPedidosPendientesDomicilio(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                'ISNULL(WEB_DOCUMENTOS.FECHAENVIADO, '01/01/2018') AS FECHAENVIADO
                'ISNULL(WEB_DOCUMENTOS.FECHA, '01/01/2018') AS FECHA, 

                Dim SQL As String = "SELECT     CODDOC, 
                                                CORRELATIVO, 
                                                OPERADOR,
                                                DOC_NIT, 
                                                DOC_NOMCLIE,
                                                TOTALCOSTO, 
                                                TOTALPRECIO, 
                                                FECHA, 
                                                @F AS [F. ACTUAL], 
                                                DIR_ENTREGA, 
                                                ENTREGADO, 
                                                OBS
                        FROM COMMUNITY_DOCUMENTOS_DOMICILIO
                        WHERE (EMPNIT = @E) AND ENTREGADO='NO'"

                Dim cmd As New SqlCommand(SQL, cnhost)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@F", Today.Date)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function

    'OBTIENE LA LISTA DE DOCUMENTOS ENTREGADOS
    Public Function tblPedidosEntregadosDocs(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                'ISNULL(WEB_DOCUMENTOS.FECHAENVIADO, '01/01/2018') AS FECHAENVIADO
                'ISNULL(WEB_DOCUMENTOS.FECHA, '01/01/2018') AS FECHA, 

                Dim SQL As String = "SELECT WEB_DOCUMENTOS.CODDOC, 
                                                  WEB_DOCUMENTOS.CORRELATIVO, 
                                                  WEB_DOCUMENTOS.CODVEN, 
                                                  VENDEDORES.NOMVEN, 
                                                  WEB_DOCUMENTOS.CODCLIENTE, 
                                                  CLIENTES.NOMCLIENTE,
                                                  ISNULL(WEB_DOCUMENTOS.TOTALCOSTO, 0) AS TOTALCOSTO, 
                                                  WEB_DOCUMENTOS.TOTALVENTA, 
                                                  ISNULL(WEB_DOCUMENTOS.FECHAENVIADO, '01/01/2018') AS FECHAENVIADO,
                                                  CONCAT(WEB_DOCUMENTOS.ANIO, '-',WEB_DOCUMENTOS.MES,'-',WEB_DOCUMENTOS.DIA) AS FECHA,
                                                  ISNULL(CLIENTES.NIT, 'SN') AS NITCLIE, 
                                                  ISNULL(WEB_DOCUMENTOS.CODEMBARQUE, 'SN') AS DESREP, 
                                                  WEB_DOCUMENTOS.CODST, 
                                                  PARAM_STATUS.DESST,
                                                  ISNULL(WEB_DOCUMENTOS.CODREP,0) AS CODREP,
                                                  ISNULL(WEB_DOCUMENTOS.ENTREGADO,'NO') AS ENTREGADO,
                                                  ISNULL(WEB_DOCUMENTOS.OBS,'SN') AS OBS
                                        FROM WEB_DOCUMENTOS LEFT OUTER JOIN
                         PARAM_STATUS ON WEB_DOCUMENTOS.CODST = PARAM_STATUS.CODST LEFT OUTER JOIN
                         REPARTIDORES ON WEB_DOCUMENTOS.CODREP = REPARTIDORES.CODREP AND WEB_DOCUMENTOS.EMPNIT = REPARTIDORES.EMPNIT AND 
                         WEB_DOCUMENTOS.TOKEN = REPARTIDORES.TOKEN LEFT OUTER JOIN
                         CLIENTES ON WEB_DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE AND WEB_DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND WEB_DOCUMENTOS.TOKEN = CLIENTES.TOKEN LEFT OUTER JOIN
                         VENDEDORES ON WEB_DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND WEB_DOCUMENTOS.TOKEN = VENDEDORES.TOKEN AND WEB_DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT
                        WHERE (WEB_DOCUMENTOS.TOKEN = @TOKEN) 
                        AND (WEB_DOCUMENTOS.EMPNIT = @EMPNIT)
                        AND (WEB_DOCUMENTOS.ENTREGADO='SI')"

                Dim cmd As New SqlCommand(SQL, cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function

    'OBTIENE LA LISTA DE DOCUMENTOS ENTREGADOS DOMICILIO
    Public Function tblPedidosEntregadosDomicilio(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                'ISNULL(WEB_DOCUMENTOS.FECHAENVIADO, '01/01/2018') AS FECHAENVIADO
                'ISNULL(WEB_DOCUMENTOS.FECHA, '01/01/2018') AS FECHA, 

                Dim SQL As String = "SELECT CODDOC, CORRELATIVO, CODVEN, 'DOMICILIO' AS NOMVEN, CODCLIENTE, DOC_NOMCLIE AS NOMCLIENTE, TOTALCOSTO, TOTALPRECIO AS TOTALVENTA, FECHA AS FECHAENVIADO,FECHA AS FECHA, DOC_NIT AS NITCLIE, 
                         DOC_DIRCLIE AS DESREP, STATUS AS CODST, 'SN' AS DESST, CODREP, CORTE AS ENTREGADO, OBS
                        FROM COMMUNITY_DOCUMENTOS_DOMICILIO
                        WHERE (EMPNIT = @E) AND (TOKEN = @T) AND CORTE='SI'"

                Dim cmd As New SqlCommand(SQL, cnhost)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@T", Token)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl
    End Function



    Public Function EnviarPrecios(ByVal anio As Integer, ByVal mes As Integer, ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT 0 AS ID,PRECIOS.EMPNIT, PRECIOS.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, 
                                            MARCAS.DESMARCA, PRODUCTOS.COSTO AS COSTOUNITARIO,PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, PRECIOS.PRECIO, INVSALDO.SALDO AS EXISTENCIA, @FECHA AS LASTUPDATE,
                                            @TOKEN AS TOKEN,'0' AS CODMARCA, PRODUCTOS.TIPOPROD, PRECIOS.MAYOREOA, PRECIOS.MAYOREOB, PRECIOS.MAYOREOC
                                        FROM MARCAS RIGHT OUTER JOIN
                                        PRODUCTOS ON MARCAS.CODMARCA = PRODUCTOS.CODMARCA AND MARCAS.EMPNIT = PRODUCTOS.EMPNIT RIGHT OUTER JOIN
                                        PRECIOS LEFT OUTER JOIN
                                        INVSALDO ON PRECIOS.CODPROD = INVSALDO.CODPROD AND PRECIOS.EMPNIT = INVSALDO.EMPNIT ON PRODUCTOS.EMPNIT = PRECIOS.EMPNIT AND PRODUCTOS.CODPROD = PRECIOS.CODPROD
                                        WHERE (PRODUCTOS.EMPNIT=@EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@MES", mes)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                'cmd.CommandTimeout = 0 'pone a cero el timeout para que no caduque
                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(StrHostConnection)
                Dim bcCopy As New SqlBulkCopy(StrHostConnection)
                cnh.Open()

                bcCopy.DestinationTableName = "PRECIOS"
                'bcCopy.BulkCopyTimeout = 0 'pone a cero el timeout para que no caduque
                bcCopy.WriteToServer(tbl)

                cnh.Close()
                cn.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                result = False

            End Try

        End Using

        Return result
    End Function

    ''' <summary>
    ''' Inserta precios y existencia al host
    ''' </summary>
    ''' <param name="anio">año de proceso del inventario</param>
    ''' <param name="mes">mes de proceso del inventario</param>
    ''' <returns></returns>
    Public Function EnviarPrecios2(ByVal anio As Integer, ByVal mes As Integer) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT PRECIOS.EMPNIT, PRECIOS.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRODUCTOS.CODMARCA, 
                                            MARCAS.DESMARCA, PRODUCTOS.COSTO AS COSTOUNITARIO,PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, PRECIOS.COSTO, PRECIOS.PRECIO, INVSALDO.SALDO AS EXISTENCIA
                                        FROM MARCAS RIGHT OUTER JOIN
                                        PRODUCTOS ON MARCAS.CODMARCA = PRODUCTOS.CODMARCA AND MARCAS.EMPNIT = PRODUCTOS.EMPNIT RIGHT OUTER JOIN
                                        PRECIOS LEFT OUTER JOIN
                                        INVSALDO ON PRECIOS.CODPROD = INVSALDO.CODPROD AND PRECIOS.EMPNIT = INVSALDO.EMPNIT ON PRODUCTOS.EMPNIT = PRECIOS.EMPNIT AND PRODUCTOS.CODPROD = PRECIOS.CODPROD
                                        WHERE (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)", cn)
                'cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    If InsertarPrecioHost(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), dr(10), dr(11), dr(12), dr(13)) = True Then
                    End If
                Loop

                cn.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                result = False

            End Try

        End Using

        Return result
    End Function


    Private Function InsertarPrecioHost(ByVal empnit As String,
                                        ByVal codprod As String,
                                        ByVal desprod As String,
                                        ByVal desprod2 As String,
                                        ByVal desprod3 As String,
                                        ByVal uxc As Integer,
                                        ByVal codmarca As Integer,
                                        ByVal desmarca As String,
                                        ByVal costounitario As Double,
                                        ByVal codmedida As String,
                                        ByVal equivale As Integer,
                                        ByVal costo As Double,
                                        ByVal precio As Double,
                                        ByVal existencia As Double) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO PRECIOS (TOKEN,EMPNIT,CODPROD,DESPROD,DESPROD2,DESPROD3,UXC,CODMARCA,DESMARCA,COSTOUNITARIO,CODMEDIDA,EQUIVALE,COSTO,PRECIO,EXISTENCIA,LASTUPDATE) VALUES (@TOKEN,@EMPNIT,@CODPROD,@DESPROD,@DESPROD2,@DESPROD3,@UXC,@CODMARCA,@DESMARCA,@COSTOUNITARIO,@CODMEDIDA,@EQUIVALE,@COSTO,@PRECIO,@EXISTENCIA,@LASTUPDATE)", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@DESPROD", desprod)
                cmd.Parameters.AddWithValue("@DESPROD2", desprod2)
                cmd.Parameters.AddWithValue("@DESPROD3", desprod3)
                cmd.Parameters.AddWithValue("@UXC", uxc)
                cmd.Parameters.AddWithValue("@CODMARCA", codmarca)
                cmd.Parameters.AddWithValue("@DESMARCA", desmarca)
                cmd.Parameters.AddWithValue("@COSTOUNITARIO", costounitario)
                cmd.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                cmd.Parameters.AddWithValue("@EQUIVALE", equivale)
                cmd.Parameters.AddWithValue("@COSTO", costo)
                cmd.Parameters.AddWithValue("@PRECIO", precio)
                cmd.Parameters.AddWithValue("@EXISTENCIA", existencia)
                cmd.Parameters.AddWithValue("@LASTUPDATE", Today.Date)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True
            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try



        End Using

        Return result
    End Function

    ''' <summary>
    ''' Envia el catálogo de clientes al host
    ''' </summary>
    ''' <returns></returns>
    Public Function EnviarClientes(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT CLIENTES.EMPNIT, CLIENTES.CODCLIENTE, CLIENTES.NIT, CONCAT(ISNULL(CLIENTES.CIUDADANIA,'SN'),' - ',CLIENTES.NOMBRECLIENTE) AS NOMBRECLIENTE, CLIENTES.DIRCLIENTE, CLIENTES.CODMUNICIPIO, CLIENTES.CODDEPARTAMENTO, CLIENTES.TELEFONOCLIENTE, 
                         MUNICIPIOS.DESMUNICIPIO AS EMAILCLIENTE, ISNULL(SALDOCLIENTES.SALDOFINAL, 0) AS SALDO, LATITUDCLIENTE,LONGITUDCLIENTE,PROVINCIA
                            FROM CLIENTES LEFT OUTER JOIN
                         MUNICIPIOS ON CLIENTES.CODMUNICIPIO = MUNICIPIOS.CODMUNICIPIO LEFT OUTER JOIN
                         SALDOCLIENTES ON CLIENTES.EMPNIT = SALDOCLIENTES.EMPNIT AND CLIENTES.NIT = SALDOCLIENTES.NITCLIENTE WHERE CLIENTES.EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    If InsertarClientesHost(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6), dr(7), dr(8), dr(9), Today.Date, dr(10), dr(11), dr(12)) = True Then
                    End If
                Loop

                cn.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

    Private Function InsertarClientesHost(ByVal empnit As String,
                                        ByVal codcliente As Integer,
                                        ByVal nit As String,
                                        ByVal nomcliente As String,
                                        ByVal dircliente As String,
                                        ByVal codmunicipio As Integer,
                                        ByVal coddepto As Integer,
                                        ByVal telefonos As String,
                                        ByVal email As String,
                                        ByVal saldo As Double,
                                        ByVal lastupdate As Date,
                                        ByVal latitud As String,
                                        ByVal longitud As String,
                                        ByVal obs As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO CLIENTES 
                                           (TOKEN,EMPNIT,CODCLIENTE,NIT,NOMCLIENTE,DIRCLIENTE,CODMUNICIPIO,CODDEPTO,TELEFONOS,EMAIL,SALDO,LASTUPDATE,LAT,LONG,OBS) 
                                    VALUES (@TOKEN,@EMPNIT,@CODCLIENTE,@NIT,@NOMCLIENTE,@DIRCLIENTE,@CODMUNICIPIO,@CODDEPTO,@TELEFONOS,@EMAIL,@SALDO,@LASTUPDATE,@LAT,@LONG,@OBS)", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                cmd.Parameters.AddWithValue("@NIT", nit)
                cmd.Parameters.AddWithValue("@NOMCLIENTE", nomcliente)
                cmd.Parameters.AddWithValue("@DIRCLIENTE", dircliente)
                cmd.Parameters.AddWithValue("@CODMUNICIPIO", codmunicipio)
                cmd.Parameters.AddWithValue("@CODDEPTO", coddepto)
                cmd.Parameters.AddWithValue("@TELEFONOS", telefonos)
                cmd.Parameters.AddWithValue("@EMAIL", email)
                cmd.Parameters.AddWithValue("@SALDO", saldo)
                cmd.Parameters.AddWithValue("@LASTUPDATE", lastupdate)
                cmd.Parameters.AddWithValue("@LAT", latitud)
                cmd.Parameters.AddWithValue("@LONG", longitud)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.ExecuteNonQuery()
                cnhost.Close()
                result = True
            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try



        End Using

        Return result
    End Function

    ''' <summary>
    ''' Envia el catálogo de vendedores al host
    ''' </summary>
    ''' <returns></returns>
    Public Function EnviarVendedores(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT EMPNIT,CODEMPLEADO,NOMEMPLEADO,CLAVE,ACTIVO,CODEMPLEADO AS CODDOC FROM EMPLEADOS WHERE CODTIPOEMPLEADO=3 AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    If InsertarVendedoresHost(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5)) = True Then
                    End If
                Loop

                cn.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                result = False
            End Try

        End Using

        Return result
    End Function

    Private Function InsertarVendedoresHost(ByVal empnit As String,
                                        ByVal codven As Integer,
                                        ByVal nomven As String,
                                        ByVal clave As String,
                                        ByVal habilitado As String,
                                        ByVal coddoc As String
                                        ) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If
                Dim cmd As New SqlCommand("INSERT INTO VENDEDORES
                                           (TOKEN,EMPNIT,CODVEN,NOMVEN,CLAVE,HABILITADO,LASTUPDATE, CODDOC) 
                                    VALUES (@TOKEN,@EMPNIT,@CODVEN,@NOMVEN,@CLAVE,@HABILITADO,@LASTUPDATE,@CODDOC)", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODVEN", codven)
                cmd.Parameters.AddWithValue("@NOMVEN", nomven)
                cmd.Parameters.AddWithValue("@CLAVE", clave)
                cmd.Parameters.AddWithValue("@HABILITADO", habilitado)
                cmd.Parameters.AddWithValue("@LASTUPDATE", Today.Date)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.ExecuteNonQuery()
                cnhost.Close()
                result = True
            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try



        End Using

        Return result
    End Function


    Public Function EnviarEmpresas() As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT EMPNIT,EMPNOMBRE FROM EMPRESAS", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    If InsertarEmpresasHost(dr(0), dr(1)) = True Then
                    End If
                Loop

                cn.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    Private Function InsertarEmpresasHost(ByVal empnit As String, ByVal empnombre As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If
                Dim cmd As New SqlCommand("INSERT INTO EMPRESAS (EMPNIT,EMPNOMBRE,TOKEN) VALUES (@EMPNIT,@EMPNOMBRE,@TOKEN)", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@EMPNOMBRE", empnombre)
                cmd.ExecuteNonQuery()
                cnhost.Close()
                result = True
            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try



        End Using

        Return result
    End Function


    Public Function EnviarRepartidores(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT EMPNIT,CODREP,NITREP,DESREP,ISNULL(DIRREP,'SN') AS DIRREP,ISNULL(TELREP,'SN') AS TELREP,ISNULL(CLAVE,'SN') AS CLAVE FROM REPARTIDORES WHERE ACTIVO=0 AND EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    If InsertarRepartidorHost(dr(0), dr(1), dr(2), dr(3), dr(4), dr(5), dr(6)) = True Then
                    End If
                Loop

                cn.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
                MsgBox("STEP 1: " & ex.ToString)
            End Try

        End Using

        Return result
    End Function


    Private Function InsertarRepartidorHost(ByVal empnit As String,
                                        ByVal codigo As Integer,
                                        ByVal nit As String,
                                        ByVal descripcion As String,
                                        ByVal direccion As String,
                                        ByVal telefono As String,
                                        ByVal clave As String
                                        ) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If
                Dim cmd As New SqlCommand("INSERT INTO REPARTIDORES (TOKEN,EMPNIT,CODREP,NITREP,DESREP,DIRREP,TELREP,LASTUPDATE,CLAVE) VALUES (@TOKEN,@EMPNIT,@CODREP,@NITREP,@DESREP,@DIRREP,@TELREP,@LASTUPDATE,@CLAVE)", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODREP", codigo)
                cmd.Parameters.AddWithValue("@NITREP", nit)
                cmd.Parameters.AddWithValue("@DESREP", descripcion)
                cmd.Parameters.AddWithValue("@DIRREP", direccion)
                cmd.Parameters.AddWithValue("@TELREP", telefono)
                cmd.Parameters.AddWithValue("@LASTUPDATE", Today.Date)
                cmd.Parameters.AddWithValue("@CLAVE", clave)
                cmd.ExecuteNonQuery()
                cnhost.Close()
                result = True
            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
                MsgBox("STEP 2: " & ex.ToString)
            End Try

        End Using

        Return result
    End Function


#End Region


#Region " ** CENSO ** "

    Public Function getCenso(ByVal empnit As String) As Boolean

        Dim result As Boolean

        Using cnh As New SqlConnection(StrHostConnection)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                                NIT,NEGOCIO,NOMCLIE,DIRCLIE,
                                CODMUN,CODDEPTO,TELEFONOS,
                                EMAIL,OBS,CONCRE,
                                CODVEN,LAT,LONG
                                FROM CENSO_CLIENTES WHERE TOKEN=@T AND EMPNIT=@E", cnh)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@T", Token)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    Call insertClienteCenso(empnit, dr(0).ToString, "SN", dr(1).ToString, dr(2).ToString, dr(3).ToString, CType(dr(4), Integer), CType(dr(5), Integer), dr(6).ToString, dr(7).ToString, dr(8).ToString, dr(9).ToString, dr(11).ToString, dr(12).ToString, 1, "P")
                Loop
                dr.Close()

                result = True

            Catch ex As Exception
                MsgBox("PRIMER PROCESO: " & ex.ToString)
                result = False

            End Try

        End Using

        Return result
    End Function

    Public Function insertClienteCenso(ByVal empnit As String,
                                       ByVal nit As String,
                                       ByVal dpi As String,
                                       ByVal negocio As String,
                                       ByVal nomclie As String,
                                       ByVal dirclie As String,
                                       ByVal codmuni As Integer,
                                       ByVal coddepto As Integer,
                                       ByVal telefono As String,
                                       ByVal email As String,
                                       ByVal obs As String,
                                       ByVal concre As String,
                                       ByVal lat As String,
                                       ByVal longi As String,
                                       ByVal codruta As Integer,
                                       ByVal tipoprecio As String
                                       ) As Boolean
        Dim r As Boolean


        Using cn As New SqlConnection(StrServerConection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmdi As New SqlCommand("SELECT TOP 1 NIT FROM CLIENTES WHERE EMPNIT=@E AND NIT=@N", cn)
                cmdi.Parameters.AddWithValue("@E", empnit)
                cmdi.Parameters.AddWithValue("@N", nit)
                Dim dr As SqlDataReader = cmdi.ExecuteReader

                If dr.Read() = True Then
                    MsgBox("El nit: " & nit & " a nombre de " & nomclie & " ya existe, no lo puedo agregar")
                Else

                    Dim cmds As New SqlCommand("INSERT INTO CLIENTES 
                        (EMPNIT,DPI,NIT,NOMBRECLIENTE,DIRCLIENTE,
                        CODMUNICIPIO,CODDEPARTAMENTO,TELEFONOCLIENTE,EMAILCLIENTE,
                        ESTADOCIVIL,SEXO,LATITUDCLIENTE,LONGITUDCLIENTE,CATEGORIA,
                        OCUPACION,CIUDADANIA,CODRUTA,CALIFICACION,SALDO,FECHAINICIO,
                        HABILITADO,PROVINCIA) VALUES (
                        @EMPNIT,@DPI,@NIT,@NOMBRECLIENTE,@DIRCLIENTE,
                        @CODMUNICIPIO,@CODDEPARTAMENTO,@TELEFONOCLIENTE,@EMAILCLIENTE,
                        'SOLTERO-A','OTROS',@LAT,@LONG,@CATEGORIA,
                        'SN',@CIUDADANIA ,@CODRUTA,@CALIFICACION,0,@FECHAINICIO,
                        'SI',@PROVINCIA)", cn)
                    cmds.Parameters.AddWithValue("@EMPNIT", empnit)
                    cmds.Parameters.AddWithValue("@DPI", dpi)
                    cmds.Parameters.AddWithValue("@NIT", nit)
                    cmds.Parameters.AddWithValue("@NOMBRECLIENTE", nomclie)
                    cmds.Parameters.AddWithValue("@DIRCLIENTE", dirclie)
                    cmds.Parameters.AddWithValue("@CODMUNICIPIO", codmuni)
                    cmds.Parameters.AddWithValue("@CODDEPARTAMENTO", coddepto)
                    cmds.Parameters.AddWithValue("@TELEFONOCLIENTE", telefono)
                    cmds.Parameters.AddWithValue("@EMAILCLIENTE", email)
                    cmds.Parameters.AddWithValue("@LAT", lat)
                    cmds.Parameters.AddWithValue("@LONG", longi)
                    cmds.Parameters.AddWithValue("@CATEGORIA", tipoprecio)
                    cmds.Parameters.AddWithValue("@CODRUTA", codruta)
                    cmds.Parameters.AddWithValue("@FECHAINICIO", Today.Date)
                    cmds.Parameters.AddWithValue("@PROVINCIA", obs)
                    cmds.Parameters.AddWithValue("@CALIFICACION", concre)
                    cmds.Parameters.AddWithValue("@CIUDADANIA", negocio)
                    cmds.ExecuteNonQuery()

                    MsgBox("CLIENTE AGREGADO: " & nit & " - " & nomclie & ", " & dirclie)

                End If

                dr.Close()

                r = True

            Catch ex As Exception
                MsgBox("SEGUNDO PROCESO: " & ex.ToString)
                r = False
            End Try

        End Using

        Return r

    End Function

    Public Function deleteCenso(ByVal empnit As String) As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(StrHostConnection)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM CENSO_CLIENTES WHERE TOKEN=@T AND EMPNIT=@E", cnh)
                cmd.Parameters.AddWithValue("@T", Token)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.ExecuteNonQuery()

                r = True
            Catch ex As Exception
                r = False
            End Try
        End Using

        Return r
    End Function

#End Region


#Region " ** ELIMINACIONES ** "

    Public Function EliminarPedido(ByVal coddoc As String, ByVal correlativo As Double, ByVal empnit As String) As Boolean

        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM WEB_DOCUMENTOS WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.ExecuteNonQuery()

                Dim cmd1 As New SqlCommand("DELETE FROM WEB_DOCPRODUCTOS WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnhost)
                cmd1.Parameters.AddWithValue("@TOKEN", Token)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd1.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd1.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    Public Function EliminarRepartidores(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM REPARTIDORES WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    ''' <summary>
    ''' Elimina la lista de vendedores para dejar paso a los nuevos datos
    ''' </summary>
    ''' <returns></returns>
    Public Function EliminarVendedores(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM VENDEDORES WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

    ''' <summary>
    ''' Elimina la lista de clientes para dejar paso a los nuevos datos
    ''' </summary>
    ''' <returns></returns>
    Public Function EliminarClientes(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If
                Dim cmd As New SqlCommand("DELETE FROM CLIENTES WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    ''' <summary>
    ''' Elimina la lista de precios para dejar paso a los nuevos datos
    ''' </summary>
    ''' <returns></returns>
    Public Function EliminarPrecios(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM PRECIOS WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    ''' <summary>
    ''' Elimina la lista de Empresas para dejar paso a los nuevos datos
    ''' </summary>
    ''' <returns></returns>
    Public Function EliminarEmpresas() As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM EMPRESAS WHERE TOKEN=@TOKEN", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

#End Region

#Region " ** VARIOS ** "
    Public Function UpdateAsignarPicking(ByVal coddoc As String, ByVal correlativo As Double, ByVal empnit As String, ByVal codembarque As String) As Boolean

        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)
            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try

                Dim cmd As New SqlCommand("UPDATE WEB_DOCUMENTOS SET CODEMBARQUE=@CODEMBARQUE WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@CODEMBARQUE", codembarque)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function


    Public Function UpdateAsignarRepartidor(ByVal coddoc As String, ByVal correlativo As Double, ByVal empnit As String, ByVal codrep As Integer) As Boolean

        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)
            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try

                Dim cmd As New SqlCommand("UPDATE WEB_DOCUMENTOS SET CODREP=@CODREP WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@CODREP", codrep)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

    'PEDIDOS PRE-VENTA
    Public Function UpdateEntregado(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal EntregadoSiNo As String) As Boolean

        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)
            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try
                Dim SiNo As String
                If EntregadoSiNo = "SI" Then
                    SiNo = "NO"
                Else
                    SiNo = "SI"
                End If

                Dim cmd As New SqlCommand("UPDATE WEB_DOCUMENTOS SET ENTREGADO=@SINO WHERE TOKEN=@TOKEN AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnhost)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@SINO", SiNo)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

    'PEDIDOS DOMICILIO
    Public Function UpdateEntregadoDomicilio(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal EntregadoSiNo As String) As Boolean

        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)
            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try
                Dim SiNo As String
                If EntregadoSiNo = "SI" Then
                    SiNo = "NO"
                Else
                    SiNo = "SI"
                End If

                Dim cmd As New SqlCommand("UPDATE COMMUNITY_DOCUMENTOS_DOMICILIO SET ENTREGADO = @SINO WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@SINO", SiNo)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

#End Region

#Region " ** SINCRONIZADOR EN BACKGROUND"

    Public Function tblInventarioProductoEmpresas(ByVal empnit As String, ByVal codprod As String) As DataTable
        Dim tbl As New DataTable

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim SQL As String = "SELECT         COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE AS EMPRESA, COMMUNITY_INVSALDO_SYNC.CODPROD, COMMUNITY_PRODUCTOS_SYNC.DESPROD, COMMUNITY_INVSALDO_SYNC.SALDOINICIAL AS INICIAL, 
                                                    COMMUNITY_INVSALDO_SYNC.ENTRADAS, COMMUNITY_INVSALDO_SYNC.SALIDAS, COMMUNITY_INVSALDO_SYNC.SALDO
                                     FROM           COMMUNITY_PRODUCTOS_SYNC RIGHT OUTER JOIN
                                                    COMMUNITY_INVSALDO_SYNC ON COMMUNITY_PRODUCTOS_SYNC.TOKEN = COMMUNITY_INVSALDO_SYNC.TOKEN AND 
                                                    COMMUNITY_PRODUCTOS_SYNC.CODPROD = COMMUNITY_INVSALDO_SYNC.CODPROD RIGHT OUTER JOIN
                                                    COMMUNITY_EMPRESAS_SYNC ON COMMUNITY_INVSALDO_SYNC.TOKEN = COMMUNITY_EMPRESAS_SYNC.TOKEN AND COMMUNITY_INVSALDO_SYNC.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT
                                     WHERE          (COMMUNITY_INVSALDO_SYNC.TOKEN = @TOKEN) AND (COMMUNITY_INVSALDO_SYNC.EMPNIT <> @EMPNIT) AND (COMMUNITY_INVSALDO_SYNC.EMPNIT NOT IN ('BACKU%', 'distgarmen001'))
                                     GROUP BY       COMMUNITY_EMPRESAS_SYNC.EMPNIT, COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE, COMMUNITY_INVSALDO_SYNC.CODPROD, COMMUNITY_PRODUCTOS_SYNC.DESPROD, 
                                                    COMMUNITY_INVSALDO_SYNC.SALDOINICIAL, COMMUNITY_INVSALDO_SYNC.ENTRADAS, COMMUNITY_INVSALDO_SYNC.SALIDAS, COMMUNITY_INVSALDO_SYNC.SALDO, COMMUNITY_INVSALDO_SYNC.ANIO, 
                                                    COMMUNITY_INVSALDO_SYNC.MES
                                     HAVING         (COMMUNITY_INVSALDO_SYNC.CODPROD = @CODPROD) AND (COMMUNITY_INVSALDO_SYNC.ANIO = 0) AND (COMMUNITY_INVSALDO_SYNC.MES = 0)
                                     ORDER BY       COMMUNITY_INVSALDO_SYNC.SALDO DESC"

                Dim cmd As New SqlCommand(SQL, cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cnhost.Close()

            Catch ex As Exception
                Me.DesError = ex.ToString
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function fcnDeleteBackground(ByVal empnit As String, ByVal anio As Integer, ByVal mes As Integer) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM COMMUNITY_PRODUCTOS_SYNC WHERE EMPNIT=@EMPNIT AND TOKEN=@TOKEN;
                                        DELETE FROM COMMUNITY_PRECIOS_SYNC WHERE EMPNIT=@EMPNIT AND TOKEN=@TOKEN;
                DELETE From COMMUNITY_INVSALDO_SYNC Where empnit =@EMPNIT AND TOKEN=@TOKEN", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                cmd.ExecuteNonQuery()

                Dim cmd1 As New SqlCommand("DELETE FROM COMMUNITY_DOCUMENTOS_SYNC WHERE EMPNIT=@EMPNIT AND TOKEN=@TOKEN AND MES=@MES AND ANIO=@ANIO", cnhost)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.Parameters.AddWithValue("@TOKEN", Token)
                cmd1.Parameters.AddWithValue("@ANIO", anio)
                cmd1.Parameters.AddWithValue("@MES", mes)
                cmd1.ExecuteNonQuery()


                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

    Public Function fcndeleteDocProds(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)


            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM DOCPRODUCTOS_CORTES WHERE EMPNIT=@EMPNIT AND FECHA <> @FECHA", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + "EN DELETE")
                result = False
            End Try

        End Using

        Return result
    End Function
    Dim productoCorte As String
    Dim productoNS As String
    Public Function fcnDeleteNSRepetidos(ByVal empnit As String, ByVal codprod As String) As Boolean

        Dim result As Boolean

        Return result


    End Function

    Public Function fcnSendDocProds(ByVal empnit As String, ByVal nocorte As Double) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_CORTES_SYNC
                Dim cmd5 As New SqlCommand("SELECT        DOCUMENTOS.EMPNIT, EMPRESAS.EMPNOMBRE, DOCUMENTOS.FECHA, DOCUMENTOS.NOCORTE, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, 0.00 AS TPRECIO, 
                         PRECIOS.CODMEDIDA AS MEDIDA, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, INVSALDO.SALDO, '' AS DESPACHO, 'CORTE' AS OBS, 'VENTA' AS TIPO
FROM            PRECIOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRECIOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRECIOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         EMPRESAS ON DOCPRODUCTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                         INVSALDO ON DOCPRODUCTOS.CODPROD = INVSALDO.CODPROD AND DOCPRODUCTOS.EMPNIT = INVSALDO.EMPNIT RIGHT OUTER JOIN
                         TIPODOCUMENTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC AND TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND 
                         DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCUMENTOS.NOCORTE, DOCUMENTOS.EMPNIT, TIPODOCUMENTOS.TIPODOC, INVSALDO.SALDO, DOCUMENTOS.FECHA, EMPRESAS.EMPNOMBRE, 
                         PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE
HAVING        (DOCUMENTOS.NOCORTE = @NOCORTE) AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (PRECIOS.EQUIVALE = 1)
ORDER BY DOCPRODUCTOS.DESPROD", cn)
                cmd5.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd5.Parameters.AddWithValue("@NOCORTE", nocorte)

                Dim dr5 As SqlDataReader = cmd5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy5.DestinationTableName = "DOCPRODUCTOS_CORTES"
                bcCopy5.WriteToServer(dr5)

                dr5.Close()
                cnh.Close()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + "EN INSERT")
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function TblMovinCorte() As DataTable

        Dim tbl As New DataTable

        Using cn As New SqlConnection(StrHostConnection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT           COMMUNITY_EMPRESAS_SYNC.RUTA, COMMUNITY_EMPRESAS_SYNC.SUBRUTA, REPLACE(DOCPRODUCTOS_CORTES.EMPNOMBRE, 'FARMACIA_SALUD_', '') AS EMPNOMBRE, 
                                                            DOCPRODUCTOS_CORTES.DESPROD, DOCPRODUCTOS_CORTES.MEDIDA, SUM(DOCPRODUCTOS_CORTES.UNIDADES) AS UNIDADES, MIN(DOCPRODUCTOS_CORTES.SALDO) AS EXISTENCIA, 
                                                            ISNULL(DOCPRODUCTOS_CORTES.DESPACHO, '') AS DESPACHO, SUM(DOCPRODUCTOS_CORTES.TPRECIO) AS TPRECIO, REPLACE(DOCPRODUCTOS_CORTES.OBS, 'CORTE', 'VENTA') AS OBS, DOCPRODUCTOS_CORTES.TIPO
                                           FROM             DOCPRODUCTOS_CORTES LEFT OUTER JOIN
                                                            COMMUNITY_EMPRESAS_SYNC ON DOCPRODUCTOS_CORTES.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT
                                           GROUP BY         DOCPRODUCTOS_CORTES.EMPNOMBRE, DOCPRODUCTOS_CORTES.CODPROD, DOCPRODUCTOS_CORTES.DESPROD, DOCPRODUCTOS_CORTES.MEDIDA, DOCPRODUCTOS_CORTES.DESPACHO, 
                                                            COMMUNITY_EMPRESAS_SYNC.RUTA, COMMUNITY_EMPRESAS_SYNC.SUBRUTA, DOCPRODUCTOS_CORTES.OBS, DOCPRODUCTOS_CORTES.TIPO
                                           ORDER BY         COMMUNITY_EMPRESAS_SYNC.RUTA, COMMUNITY_EMPRESAS_SYNC.SUBRUTA, EMPNOMBRE, DOCPRODUCTOS_CORTES.DESPROD", cn)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function TblAuditCortes() As DataTable

        Dim tbl As New DataTable

        Using cn As New SqlConnection(StrHostConnection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT        REPLACE(DOCPRODUCTOS_CORTES.EMPNOMBRE, 'FARMACIA_SALUD_', '') AS EMPNOMBRE, DOCPRODUCTOS_CORTES.FECHA, DOCPRODUCTOS_CORTES.NOCORTE, COMMUNITY_EMPRESAS_SYNC.RUTA, 
                         COMMUNITY_EMPRESAS_SYNC.SUBRUTA
FROM            DOCPRODUCTOS_CORTES LEFT OUTER JOIN
                         COMMUNITY_EMPRESAS_SYNC ON DOCPRODUCTOS_CORTES.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT
GROUP BY DOCPRODUCTOS_CORTES.EMPNOMBRE, DOCPRODUCTOS_CORTES.FECHA, DOCPRODUCTOS_CORTES.NOCORTE, COMMUNITY_EMPRESAS_SYNC.RUTA, COMMUNITY_EMPRESAS_SYNC.SUBRUTA
HAVING        (DOCPRODUCTOS_CORTES.NOCORTE <> 0)
ORDER BY COMMUNITY_EMPRESAS_SYNC.RUTA, COMMUNITY_EMPRESAS_SYNC.SUBRUTA, EMPNOMBRE, DOCPRODUCTOS_CORTES.NOCORTE", cn)


                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function fcnInsertPS(ByVal empnit As String, empnombre As String, codprod As String, desprod As String, medida As String, cantidad As Integer, obs As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO PRODUCTOS_NUEVOS (EMPNIT, SUCURSAL, FECHA, HORA, MINUTO, CODPROD, DESPROD, PRESENTACION, CANTIDAD, OBS, CONSEGUIDO)
                                                                    VALUES (@EMPNIT, @SUCURSAL, @FECHA, @HORA, @MINUTO, @CODPROD, @DESPROD, @PRESENTACION, @CANTIDAD, @OBS, 'NO') ", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@SUCURSAL", empnombre)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@DESPROD", desprod)
                cmd.Parameters.AddWithValue("@PRESENTACION", medida)
                cmd.Parameters.AddWithValue("@CANTIDAD", cantidad)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + "EN INSERT PRODUCTO NUEVO")
                result = False
            End Try

        End Using

        Return result
    End Function

    Public Function fcnInsertNS(ByVal empnit As String, sucursal As String, codprod As String, desprod As String, medida As String, saldo As Integer, unidades As Integer, obs As String, tipo As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO DOCPRODUCTOS_CORTES (EMPNIT, EMPNOMBRE, FECHA, NOCORTE, CODPROD, DESPROD, TPRECIO, MEDIDA, UNIDADES, SALDO, OBS, TIPO)
                                                                    VALUES (@EMPNIT, @EMPNOMBRE, @FECHA, 0, @CODPROD, @DESPROD, 0.00, @MEDIDA, @UNIDADES, @SALDO, @OBS, @TIPO) ", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@EMPNOMBRE", sucursal)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@DESPROD", desprod)
                cmd.Parameters.AddWithValue("@MEDIDA", medida)
                cmd.Parameters.AddWithValue("@UNIDADES", unidades)
                cmd.Parameters.AddWithValue("@SALDO", saldo)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.Parameters.AddWithValue("@TIPO", tipo)
                cmd.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + "EN INSERT NO SURTIDOS")
                result = False
            End Try

        End Using

        Return result
    End Function

    Public Function fcnReadNS(ByVal empnit As String, ByVal desprod As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD FROM DOCPRODUCTOS_CORTES WHERE EMPNIT = @EMPNIT AND DESPROD = @DESPROD", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@DESPROD", desprod)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    result = True
                Else
                    result = False
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                MsgBox(ex.ToString + " EN COMPARACION DE NO SURTIDOS INSERTADOS")
                result = False
            End Try

        End Using

        Return result
    End Function

    '------------------------------------------------------------
    '------------------------------------------------------------

    'SUBE LA INFORMACION DE DOCUMENTOS / ELIMINAR
    Public Function fcnDeleteDocumentosContables(ByVal empnit As String, ByVal anio As Integer, ByVal mes As Integer) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd1 As New SqlCommand("DELETE FROM SERVICES_DOCUMENTOS_CONTA WHERE EMPNIT=@EMPNIT AND TOKEN=@TOKEN AND MES=@MES AND ANIO=@ANIO", cnhost)
                cmd1.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd1.Parameters.AddWithValue("@TOKEN", Token)
                cmd1.Parameters.AddWithValue("@ANIO", anio)
                cmd1.Parameters.AddWithValue("@MES", mes)
                cmd1.ExecuteNonQuery()

                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function

    'SUBE LA INFORMACION DE DOCUMENTOS / SUBE
    Public Function fcnSendDocumentosContables(ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                '*******************************************************************
                '*******************************************************************

                Dim cmd4 As New SqlCommand("SELECT @TOKEN AS TOKEN, 
                                                    DOCUMENTOS.ID, 
                                                    DOCUMENTOS.EMPNIT, 
                                                    EMPRESAS.EMPNOMBRE, 
                                                    DOCUMENTOS.ANIO, 
                                                    DOCUMENTOS.MES, 
                                                    DOCUMENTOS.DIA, 
                                                    DOCUMENTOS.FECHA, 
                                                    DOCUMENTOS.HORA, 
                                                    DOCUMENTOS.MINUTO,
                                                    TIPODOCUMENTOS.TIPODOC AS TIPODOCUMENTO,
                                                    DOCUMENTOS.CODDOC, 
                                                    DOCUMENTOS.CORRELATIVO, 
                                                    DOCUMENTOS.CODCLIENTE, 
                                                    DOCUMENTOS.DOC_NIT, 
                                                    DOCUMENTOS.DOC_NOMCLIE, 
                                                    DOCUMENTOS.DOC_DIRCLIE, 
                                                    DOCUMENTOS.TOTALCOSTO, 
                                                    DOCUMENTOS.TOTALPRECIO, 
                                                    DOCUMENTOS.CODEMBARQUE, 
                                                    DOCUMENTOS.STATUS, 
                                                    DOCUMENTOS.USUARIO, 
                                                    DOCUMENTOS.CONCRE, 
                                                    DOCUMENTOS.CORTE, 
                                                    DOCUMENTOS.SERIEFAC, 
                                                    DOCUMENTOS.NOFAC, 
                                                    DOCUMENTOS.CODVEN, 
                                                    DOCUMENTOS.NOCORTE, 
                                                    DOCUMENTOS.PAGO, 
                                                    DOCUMENTOS.VUELTO, 
                                                    DOCUMENTOS.MARCA, 
                                                    DOCUMENTOS.OBS, 
                                                    DOCUMENTOS.DOC_SALDO, 
                                                    DOCUMENTOS.DOC_ABONO, 
                                                    DOCUMENTOS.OBSMARCA, 
                                                    DOCUMENTOS.TOTALDESCUENTO, 
                                                    DOCUMENTOS.CODCAJA, 
                                                    DOCUMENTOS.TOTALTARJETA, 
                                                    DOCUMENTOS.RECARGOTARJETA, 
                                                    DOCUMENTOS.CODREP, 
                                                    DOCUMENTOS.DIRENTREGA, 
                                                    DOCUMENTOS.NOGUIA, 
                                                    DOCUMENTOS.VALORENTREGA, 
                                                    DOCUMENTOS.TOTALEXENTO,
                                                    DOCUMENTOS.LAT,
                                                    DOCUMENTOS.LONG,
                                                    DOCUMENTOS.TIPOPAGO, 
                                                    DOCUMENTOS.NODOCPAGO, 
                                                    DOCUMENTOS.VENCIMIENTO,
                                                    DOCUMENTOS.DIASCREDITO, 
                                                    DOCUMENTOS.TOTALIVA, 
                                                    DOCUMENTOS.TOTALSINIVA,  
                                                    DOCUMENTOS.FEL_UUDI, 
                                                    DOCUMENTOS.FEL_SERIE, 
                                                    DOCUMENTOS.FEL_NUMERO, 
                                                    DOCUMENTOS.FEL_FECHA
                                                FROM DOCUMENTOS LEFT OUTER JOIN
                                                    EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                                    TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                                WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) 
                                                    AND (DOCUMENTOS.ANIO = @ANIO) 
                                                    AND (DOCUMENTOS.MES = @MES) 
                                                    AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FEC','FES','FNC', 'DEV') )", cn)
                cmd4.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd4.Parameters.AddWithValue("@TOKEN", Token)
                cmd4.Parameters.AddWithValue("@ANIO", anioproceso)
                cmd4.Parameters.AddWithValue("@MES", mesproceso)
                Dim dr4 As SqlDataReader = cmd4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy4.DestinationTableName = "SERVICES_DOCUMENTOS_CONTA"
                bcCopy4.WriteToServer(dr4)
                dr4.Close()
                cnh.Close()

                '*******************************************************************
                '*******************************************************************
                '*******************************************************************

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result

    End Function

    '------------------------------------------------------------
    '------------------------------------------------------------

    'SUBE LA INFORMACION DE DOCUMENTOS
    Public Function fcnSendBackup(ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                '*******************************************************************
                '*******************************************************************

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_DOCUMENTOS

                Dim cmd4 As New SqlCommand("SELECT        DOCUMENTOS.ID, DOCUMENTOS.EMPNIT, DOCUMENTOS.ANIO, DOCUMENTOS.MES, DOCUMENTOS.DIA, DOCUMENTOS.FECHA, DOCUMENTOS.HORA, DOCUMENTOS.MINUTO, DOCUMENTOS.CODDOC, 
                         DOCUMENTOS.CORRELATIVO, DOCUMENTOS.CODCLIENTE, DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.DOC_DIRCLIE, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, 
                         DOCUMENTOS.CODEMBARQUE, DOCUMENTOS.STATUS, DOCUMENTOS.USUARIO, DOCUMENTOS.CONCRE, DOCUMENTOS.CORTE, DOCUMENTOS.SERIEFAC, DOCUMENTOS.NOFAC, DOCUMENTOS.CODVEN, 
                         DOCUMENTOS.NOCORTE, DOCUMENTOS.PAGO, DOCUMENTOS.VUELTO, DOCUMENTOS.MARCA, DOCUMENTOS.OBS, DOCUMENTOS.DOC_SALDO, DOCUMENTOS.DOC_ABONO, DOCUMENTOS.OBSMARCA, 
                         DOCUMENTOS.TOTALDESCUENTO, DOCUMENTOS.CODCAJA, DOCUMENTOS.TOTALTARJETA, DOCUMENTOS.RECARGOTARJETA, DOCUMENTOS.CODREP, DOCUMENTOS.DIRENTREGA, 
                         EMPLEADOS.NOMEMPLEADO AS NOGUIA, DOCUMENTOS.VALORENTREGA, DOCUMENTOS.TOTALEXENTO, @TOKEN AS TOKEN
                    FROM            DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                    WHERE        (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF', 'FEC', 'FES'))", cn)
                cmd4.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd4.Parameters.AddWithValue("@TOKEN", Token)
                cmd4.Parameters.AddWithValue("@ANIO", anioproceso)
                cmd4.Parameters.AddWithValue("@MES", mesproceso)
                Dim dr4 As SqlDataReader = cmd4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy4.DestinationTableName = "COMMUNITY_DOCUMENTOS_SYNC"
                bcCopy4.WriteToServer(dr4)
                dr4.Close()
                cnh.Close()

                '*******************************************************************
                '*******************************************************************
                '*******************************************************************

                result = True

            Catch ex As Exception

                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'SUBE LOS PRODUCTOS Y PRECIOS
    Public Function fcnSendBackupFProductos(ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal empnit As String) As Boolean

        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRODUCTOS
                Dim cmd As New SqlCommand("SELECT ID,
                                           @EMPNIT AS EMPNIT,
                CODPROD,CODPROD2,   
                DESPROD,DESPROD2,DESPROD3, 
                UXC,CODMEDIDACOMPRA,ISNULL(COSTO,0.001) AS COSTO,
                CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                HABILITADO,FOTO,VENCIMIENTO,SERIE,
                BONO,INVMINIMO,INVMAXIMO,EXENTO,@TOKEN AS TOKEN,NF, @LASTSALE AS LASTSALE, TIPOPROD FROM PRODUCTOS WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@LASTSALE", Today.Date)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy.DestinationTableName = "COMMUNITY_PRODUCTOS_SYNC"
                bcCopy.WriteToServer(dr)
                dr.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRECIOS
                Dim cmd2 As New SqlCommand("SELECT 0 AS ID,@EMPNIT AS EMPNIT,CODPROD,CODMEDIDA,
                ISNULL(EQUIVALE,1) AS EQUIVALE,
                ISNULL(COSTO,0.001) AS COSTO,
                ISNULL(PRECIO,0.01) AS PRECIO,
                ISNULL(UTILIDAD,0) AS UTILIDAD,
                ISNULL(PORCUTILIDAD,0) AS PORCUTILIDAD,
                HABILITADO,
                ISNULL(MAYOREOA,0.01) AS MAYOREOA,
                ISNULL(MAYOREOB,0.01) AS MAYOREOB,
                ISNULL(MAYOREOC, 0) AS MAYOREOC,
                0 AS PESO,@TOKEN AS TOKEN 
                FROM PRECIOS WHERE EMPNIT=@EMPNIT", cn)
                cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd2.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr2 As SqlDataReader = cmd2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy2.DestinationTableName = "COMMUNITY_PRECIOS_SYNC"
                bcCopy2.WriteToServer(dr2)
                dr2.Close()
                cnh.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'SUBE LOS INVENTARIOS
    Public Function fcnSendBackupFInventario(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_INVSALDO
                Dim cmd3 As New SqlCommand("SELECT ID, @EMPNIT AS EMPNIT, ANIO, MES,CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO,CODBODEGA,NOLOTE,@TOKEN AS TOKEN FROM INVSALDO WHERE EMPNIT=@EMPNIT", cn)
                cmd3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd3.Parameters.AddWithValue("@TOKEN", Token)

                Dim dr3 As SqlDataReader = cmd3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy3.DestinationTableName = "COMMUNITY_INVSALDO_SYNC"
                bcCopy3.WriteToServer(dr3)
                dr3.Close()
                cnh.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function


    'FUNCION ORIGINAL LA GUARDO COMO BACKUP SOLAMENTE
    Public Function fcnSendBackupORIGINAL(ByVal anioproceso As Integer, ByVal mesproceso As Integer, ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRODUCTOS
                Dim cmd As New SqlCommand("SELECT ID,
                                           @EMPNIT AS EMPNIT,
                CODPROD,CODPROD2,   
                DESPROD,DESPROD2,DESPROD3, 
                UXC,CODMEDIDACOMPRA,COSTO,
                CODMARCA,CODCLAUNO,CODCLADOS,CODCLATRES,
                HABILITADO,FOTO,VENCIMIENTO,SERIE,
                BONO,INVMINIMO,INVMAXIMO,EXENTO,@TOKEN AS TOKEN,NF, @LASTSALE AS LASTSALE, TIPOPROD FROM PRODUCTOS WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@LASTSALE", Today.Date)
                cmd.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy.DestinationTableName = "COMMUNITY_PRODUCTOS_SYNC"
                bcCopy.WriteToServer(dr)
                dr.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_PRECIOS
                Dim cmd2 As New SqlCommand("SELECT 0 AS ID,@EMPNIT AS EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO,MAYOREOA,MAYOREOB,MAYOREOC,0 AS PESO,@TOKEN AS TOKEN FROM PRECIOS WHERE EMPNIT=@EMPNIT", cn)
                cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd2.Parameters.AddWithValue("@TOKEN", Token)
                Dim dr2 As SqlDataReader = cmd2.ExecuteReader

                Dim bcCopy2 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy2.DestinationTableName = "COMMUNITY_PRECIOS_SYNC"
                bcCopy2.WriteToServer(dr2)
                dr2.Close()
                cnh.Close()

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_INVSALDO
                Dim cmd3 As New SqlCommand("SELECT ID,@EMPNIT AS EMPNIT, ANIO, MES,CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO,CODBODEGA,NOLOTE,@TOKEN AS TOKEN FROM INVSALDO WHERE EMPNIT=@EMPNIT", cn)
                cmd3.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd3.Parameters.AddWithValue("@TOKEN", Token)

                Dim dr3 As SqlDataReader = cmd3.ExecuteReader

                Dim bcCopy3 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy3.DestinationTableName = "COMMUNITY_INVSALDO_SYNC"
                bcCopy3.WriteToServer(dr3)
                dr3.Close()
                cnh.Close()

                '*******************************************************************
                '*******************************************************************
                '*******************************************************************

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_DOCUMENTOS
                Dim cmd4 As New SqlCommand("SELECT DOCUMENTOS.ID, DOCUMENTOS.EMPNIT, DOCUMENTOS.ANIO, DOCUMENTOS.MES, DOCUMENTOS.DIA, DOCUMENTOS.FECHA, DOCUMENTOS.HORA, DOCUMENTOS.MINUTO, DOCUMENTOS.CODDOC, 
                DOCUMENTOS.CORRELATIVO, DOCUMENTOS.CODCLIENTE, DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.DOC_DIRCLIE, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, 
                DOCUMENTOS.CODEMBARQUE, DOCUMENTOS.STATUS, DOCUMENTOS.USUARIO, DOCUMENTOS.CONCRE, DOCUMENTOS.CORTE, DOCUMENTOS.SERIEFAC, DOCUMENTOS.NOFAC, DOCUMENTOS.CODVEN, 
                DOCUMENTOS.NOCORTE, DOCUMENTOS.PAGO, DOCUMENTOS.VUELTO, DOCUMENTOS.MARCA, DOCUMENTOS.OBS, DOCUMENTOS.DOC_SALDO, DOCUMENTOS.DOC_ABONO, DOCUMENTOS.OBSMARCA, 
                DOCUMENTOS.TOTALDESCUENTO, DOCUMENTOS.CODCAJA, DOCUMENTOS.TOTALTARJETA, DOCUMENTOS.RECARGOTARJETA, DOCUMENTOS.CODREP, DOCUMENTOS.DIRENTREGA, DOCUMENTOS.NOGUIA, 
                DOCUMENTOS.VALORENTREGA, DOCUMENTOS.TOTALEXENTO, @TOKEN AS TOKEN
                From DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                WHERE (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS<>'A') AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (TIPODOCUMENTOS.TIPODOC = 'FAC')", cn)
                cmd4.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd4.Parameters.AddWithValue("@TOKEN", Token)
                cmd4.Parameters.AddWithValue("@ANIO", anioproceso)
                cmd4.Parameters.AddWithValue("@MES", mesproceso)
                Dim dr4 As SqlDataReader = cmd4.ExecuteReader

                Dim bcCopy4 As New SqlBulkCopy(StrHostConnection)

                cnh.Open()
                bcCopy4.DestinationTableName = "COMMUNITY_DOCUMENTOS_SYNC"
                bcCopy4.WriteToServer(dr4)
                dr4.Close()
                cnh.Close()

                '*******************************************************************
                '*******************************************************************
                '*******************************************************************

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'SUBE LOS CORTES DE CAJA
    Public Function fcnSendCortes(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_CORTES_SYNC
                Dim cmd5 As New SqlCommand("SELECT ID, EMPNIT, ANIO, MES, DIA, FECHA, HORA, MINUTO, CORRELATIVO, IDINICIAL, CODDOCINICIAL, CORRELATIVOINICIAL, HORAINICIAL, MINUTOINICIAL, IDFINAL, CODDOCFINAL, CORRELATIVOFINAL, HORAFINAL, MINUTOFINAL, 
                         TOTALMOVIMIENTOS, TOTALCOSTO, TOTALVENTA, TOTALUTILIDAD, MARGEN, USUARIO, TOTALREPORTADO, FALTANTE, SOBRANTE, OBS, TOTALGASTOS, TOTALRECIBOS, CODCAJA, TOTALTARJETA, REPORTADOTARJETA, 
                         TOTALCHEQUES, REPORTADOCHEQUES, @TOKEN AS TOKEN, TOTALDEVOLUCIONES
                        FROM CORTES WHERE EMPNIT=@EMPNIT AND ENVIADO=0", cn)
                cmd5.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd5.Parameters.AddWithValue("@TOKEN", Token)

                Dim dr5 As SqlDataReader = cmd5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy5.DestinationTableName = "COMMUNITY_CORTES_SYNC"
                bcCopy5.WriteToServer(dr5)

                dr5.Close()
                cnh.Close()

                '*******************************************************************
                '*******************************************************************
                '*******************************************************************

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function

    'SUBE LOS CORTES DE CAJA
    Public Function fcnSendCortesT(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                'INSERTA LOS DATOS A LA TABLA COMMUNITY_CORTES_SYNC
                Dim cmd5 As New SqlCommand("SELECT ID, EMPNIT, ANIO, MES, DIA, FECHA, HORA, MINUTO, CORRELATIVO, IDINICIAL, CODDOCINICIAL, CORRELATIVOINICIAL, HORAINICIAL, MINUTOINICIAL, IDFINAL, CODDOCFINAL, CORRELATIVOFINAL, HORAFINAL, MINUTOFINAL, 
                         TOTALMOVIMIENTOS, TOTALCOSTO, TOTALVENTA, TOTALUTILIDAD, MARGEN, USUARIO, TOTALREPORTADO, FALTANTE, SOBRANTE, OBS, TOTALGASTOS, TOTALRECIBOS, CODCAJA, TOTALTARJETA, REPORTADOTARJETA, 
                         TOTALCHEQUES, REPORTADOCHEQUES, @TOKEN AS TOKEN, TOTALDEVOLUCIONES
                        FROM CORTES WHERE EMPNIT=@EMPNIT", cn)
                cmd5.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd5.Parameters.AddWithValue("@TOKEN", "FARMASALUD")

                Dim dr5 As SqlDataReader = cmd5.ExecuteReader

                Dim bcCopy5 As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy5.DestinationTableName = "COMMUNITY_CORTES_SYNC"
                bcCopy5.WriteToServer(dr5)

                dr5.Close()
                cnh.Close()

                MsgBox("cortes enviados")
                '*******************************************************************
                '*******************************************************************
                '*******************************************************************

                result = True

            Catch ex As Exception

                MsgBox(ex.ToString)
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function fcnSendDataVendidosVPN(ByVal conexion As String, ByVal year As Integer, ByVal month As Integer) As Boolean
        Dim result As Boolean

        Dim cnh As New SqlConnection(StrHostConnection)

        Using cn As New SqlConnection(conexion)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT           DOCPRODUCTOS.EMPNIT, DOCPRODUCTOS.CODPROD, PRECIOS.CODMEDIDA AS MEDIDA, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, INVSALDO.SALDO
                                           FROM             DOCUMENTOS RIGHT OUTER JOIN
                                                            TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCPRODUCTOS LEFT OUTER JOIN
                                                            PRECIOS ON DOCPRODUCTOS.CODPROD = PRECIOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRECIOS.EMPNIT LEFT OUTER JOIN
                                                            INVSALDO ON DOCPRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND DOCPRODUCTOS.CODPROD = INVSALDO.CODPROD ON TIPODOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                                                            TIPODOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                                                            DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT
                                           WHERE            (DOCUMENTOS.STATUS <> 'A') AND (DOCPRODUCTOS.ANIO = @A) AND (DOCPRODUCTOS.MES = @M) AND (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC')) AND (PRECIOS.EQUIVALE = 1)
                                           GROUP BY         DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.EMPNIT, INVSALDO.SALDO, PRECIOS.CODMEDIDA
                                           HAVING           (NOT (DOCPRODUCTOS.EMPNIT LIKE 'BAKCU%'))", cn)
                cmd.Parameters.AddWithValue("@A", year)
                cmd.Parameters.AddWithValue("@M", month)

                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(StrHostConnection)
                cnh.Open()
                bcCopy.DestinationTableName = "TOTAL_VENDIDOS"
                bcCopy.WriteToServer(dr)

                dr.Close()
                cnh.Close()


                '*******************************************************************
                '*******************************************************************
                '*******************************************************************

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + " EN SUBIDA DE DATA VENTAS")
            End Try
        End Using

        Return result

    End Function

#End Region

    Public Function fcnDeleteCR(ByVal empnit As String) As Boolean

        Dim result As Boolean

        Dim conteo As Integer = 0

        Using cnhost As New SqlConnection(StrHostConnection)
            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try

                Dim cmd As New SqlCommand("DELETE FROM COMMUNITY_RELLENO WHERE EMPNIT = @EMPNIT", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + " EN DELETE RELLENO")
            End Try
        End Using

        Return result

    End Function

    Dim NITSUC As String

    Public Function fcnSendDataVendidos2(ByVal empnit As String, StrServerConectionVPN As String) As Boolean

        Dim result As Boolean

        Dim cnh As New SqlConnection("Data Source=35.239.213.75;Initial Catalog=FSYA;User ID=sqlserver;Password=farmacia123;MultipleActiveResultSets=True")

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT SUCURSAL, CODPROD, DESPROD, CODMEDIDA, SALDO, VENTA, DESMARCA, 'SN' AS PROVEEDOR, MIN, MAX, MAXB, (C.MAX - C.SALDO) AS SURTIR, (C.SALDO - C.MAX) AS EXCESO, @F2 AS FECHA 
FROM (SELECT        REPLACE(REPLACE(EMPRESAS.EMPNOMBRE, 'FARMACIA_SALUD_', ''), '_VILLANUEVA', '') AS SUCURSAL, PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, PRECIOS.CODMEDIDA, INVSALDO.SALDO, ISNULL(T.VENDIDOS, 0) 
                         AS VENTA, MARCAS.DESMARCA, ISNULL(CEILING(T.VENDIDOS * 0.25) + 1, 0) AS MIN, ISNULL(CEILING(T.VENDIDOS * 0.50) + 1, 0) AS MAX, ISNULL(CEILING(T.VENDIDOS * 0.75) + 1, 0) AS MAXB
FROM            PRODUCTOS LEFT OUTER JOIN
                         EMPRESAS ON PRODUCTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                         PRECIOS ON PRODUCTOS.CODPROD = PRECIOS.CODPROD AND PRODUCTOS.EMPNIT = PRECIOS.EMPNIT LEFT OUTER JOIN
                         INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD LEFT OUTER JOIN
                         MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA LEFT OUTER JOIN
                             (SELECT        CODPROD, SUM(VENDIDOS) / COUNT(MES) + 1 AS VENDIDOS
                               FROM            (SELECT        DOCPRODUCTOS.CODPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS VENDIDOS, DOCPRODUCTOS.MES
                                                         FROM            PRODUCTOS AS PRODUCTOS_1 RIGHT OUTER JOIN
                                                                                   DOCPRODUCTOS ON PRODUCTOS_1.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS_1.CODPROD = DOCPRODUCTOS.CODPROD LEFT OUTER JOIN
                                                                                   TIPODOCUMENTOS ON DOCPRODUCTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                                                   DOCUMENTOS ON DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO
                                                         WHERE        (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC', 'TSS')) AND (DOCUMENTOS.FECHA BETWEEN @F1 AND @F2)
                                                         GROUP BY DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.MES) AS A
                               GROUP BY CODPROD) AS T ON PRODUCTOS.CODPROD = T.CODPROD
WHERE        (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRECIOS.EQUIVALE = 1) AND (PRODUCTOS.HABILITADO = 'SI')
GROUP BY PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, MARCAS.DESMARCA, T.VENDIDOS, INVSALDO.SALDO, PRECIOS.CODMEDIDA, EMPRESAS.EMPNOMBRE) C
ORDER BY C.DESPROD", cn)
                cmd.Parameters.AddWithValue("@F1", Today.Date.AddDays(-90))
                cmd.Parameters.AddWithValue("@F2", Today.Date)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)

                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim bcCopy As New SqlBulkCopy("Data Source=35.239.213.75;Initial Catalog=FSYA;User ID=sqlserver;Password=farmacia123;MultipleActiveResultSets=True")

                cnh.Open()
                bcCopy.DestinationTableName = "COMMUNITY_RELLENO"
                bcCopy.WriteToServer(dr)

                dr.Close()
                cnh.Close()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + " EN SUBIDA DE DATA VENTAS")
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function empnitsuc(ByVal conexion As String) As Boolean
        Dim result As Boolean

        Using cnhost As New SqlConnection(conexion)

            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT EMPNIT FROM EMPRESAS", cnhost)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    NITSUC = dr(1).ToString
                    result = True
                Else
                    result = False
                End If

                dr.Close()

            Catch ex As Exception
                'mensaje("verifica pago token: " & ex.ToString)
                result = False
            End Try

            cnhost.Close()
        End Using

        Return result

    End Function

    Public Function fcnActuMaxMin(ByVal empnit As String) As Boolean

        Dim result As Boolean

        Dim conteo As Integer = 0

        Using cnhost As New SqlConnection(StrHostConnection)
            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try

                Dim cmd As New SqlCommand("DELETE From TOTAL_VENDIDOS Where EMPNIT = @EMPNIT;
                                           UPDATE MAXIMOS SET " + empnit + "= 0;
                                           UPDATE MINIMOS SET " + empnit + "= 0", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + " EN SET 0 MAX/MIN")
            End Try
        End Using

        Return result

    End Function



    Public Function fcnSendDataVendidos(ByVal f1 As Date) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(StrServerConection)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT           DOCPRODUCTOS.EMPNIT, DOCPRODUCTOS.CODPROD, PRECIOS.CODMEDIDA AS MEDIDA, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, INVSALDO.SALDO, @FECHA AS FECHA
                                           FROM             DOCUMENTOS RIGHT OUTER JOIN
                                                            TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCPRODUCTOS LEFT OUTER JOIN
                                                            PRECIOS ON DOCPRODUCTOS.CODPROD = PRECIOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRECIOS.EMPNIT LEFT OUTER JOIN
                                                            INVSALDO ON DOCPRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND DOCPRODUCTOS.CODPROD = INVSALDO.CODPROD ON TIPODOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                                                            TIPODOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                                                            DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT
                                           WHERE            (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.FECHA BETWEEN @F1 AND @F2) AND (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC')) AND (PRECIOS.EQUIVALE = 1)
                                           GROUP BY         DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.EMPNIT, INVSALDO.SALDO, PRECIOS.CODMEDIDA
                                           HAVING (DOCPRODUCTOS.EMPNIT NOT LIKE 'BACKU%')", cn)

                cmd.Parameters.AddWithValue("@F1", f1.AddDays(-31))
                cmd.Parameters.AddWithValue("@F2", f1.AddDays(-1))
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Dim bcCopy As New SqlBulkCopy(StrHostConnection)

                Dim cnh As New SqlConnection(StrHostConnection)
                cnh.Open()
                bcCopy.DestinationTableName = "TOTAL_VENDIDOS"
                bcCopy.WriteToServer(dr)

                dr.Close()
                cnh.Close()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + " EN SUBIDA DE DATA VENTAS")
                result = False
            End Try
        End Using

        Return result

    End Function

    Public Function fcnUpdateMinMax(ByVal empnit As String) As Boolean
        Dim result As Boolean

        Dim conteo As Integer = 0

        Using cnhost As New SqlConnection(StrHostConnection)
            If cnhost.State <> ConnectionState.Open Then
                cnhost.Open()
            End If

            Try

                Dim cmd As New SqlCommand("UPDATE          MINIMOS
                                            SET " + empnit + "= ISNULL(CEILING(TOTAL_VENDIDOS.UNIIDADES / 4), 1)
	                                        FROM            MINIMOS
	                                        INNER JOIN      TOTAL_VENDIDOS ON MINIMOS.CODPROD = TOTAL_VENDIDOS.CODPROD
                                            WHERE           TOTAL_VENDIDOS.EMPNIT = @EMPNIT AND TOTAL_VENDIDOS.FECHA = @FECHA;
                                            UPDATE          MAXIMOS
                                            SET " + empnit + "= ISNULL(CEILING(TOTAL_VENDIDOS.UNIIDADES / 2), 1)
	                                        FROM            MAXIMOS
	                                        INNER JOIN      TOTAL_VENDIDOS ON MAXIMOS.CODPROD = TOTAL_VENDIDOS.CODPROD
                                            WHERE           TOTAL_VENDIDOS.EMPNIT = @EMPNIT AND TOTAL_VENDIDOS.FECHA = @FECHA", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Catch ex As Exception
                MsgBox(ex.ToString + " EN UPDATE MINIMOS")
            End Try
        End Using

        Return result
    End Function

    Public Function fcn_min_naxr1(ByVal empnit As String, ruta As Integer) As DataTable

        Dim tbl As New DataTable

        Dim conteo As Integer = 0

        Using cn As New SqlConnection(StrHostConnection)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPNIT FROM COMMUNITY_EMPRESAS_SYNC WHERE RUTA = @RUTA ORDER BY EMPNOMBRE", cn)
                cmd.Parameters.AddWithValue("@RUTA", ruta)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Do While dr.Read
                    conteo = conteo + 1
                    Try
                        Using cnvpn As New SqlConnection(StrHostConnection)
                            If cnvpn.State <> ConnectionState.Open Then
                                cnvpn.Open()
                            End If
                            Dim cmdvpn As New SqlCommand("SELECT            REPLACE(REPLACE(COMMUNITY_EMPRESAS_SYNC.EMPNOMBRE, 'FARMACIA_SALUD_', ''), '_VILLANUEVA', '') AS SUCURSAL,
                                                                            MAXIMOS.CODPROD, 
                                                                            MAXIMOS.DESPROD, 
                                                                            MINIMOS." + dr(0) + " AS MIN,
                                                                            MAXIMOS." + dr(0) + " AS MAX, 
                                                                            TOTAL_VENDIDOS.MEDIDA, 
                                                                            TOTAL_VENDIDOS.SALDO, 
                                                                            REPLACE(TOTAL_VENDIDOS.SALDO - MAXIMOS." + dr(0) + ", '-','') AS SURTIR
                                                          FROM              TOTAL_VENDIDOS INNER JOIN
                                                                            COMMUNITY_EMPRESAS_SYNC ON TOTAL_VENDIDOS.EMPNIT = COMMUNITY_EMPRESAS_SYNC.EMPNIT LEFT OUTER JOIN
                                                                            MINIMOS ON TOTAL_VENDIDOS.CODPROD = MINIMOS.CODPROD RIGHT OUTER JOIN
                                                                            MAXIMOS ON TOTAL_VENDIDOS.CODPROD = MAXIMOS.CODPROD
                                                          WHERE             (MINIMOS." + dr(0) + " > TOTAL_VENDIDOS.SALDO) AND (TOTAL_VENDIDOS.EMPNIT = @EMPNIT)
                                                          ORDER BY          MAXIMOS.DESPROD", cnvpn)
                            cmdvpn.Parameters.AddWithValue("@EMPNIT", dr(0))
                            Dim drvpn As New SqlDataAdapter
                            drvpn.SelectCommand = cmdvpn
                            drvpn.Fill(tbl)

                        End Using
                    Catch ex As Exception
                        'GlobalDesError = ex.ToString
                        MsgBox("ERROR EN DO WHILE DE LA SUC: " + dr(0))
                    End Try
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString + " ERROR EN SACAR EMPNITS")
                tbl = Nothing
            End Try

        End Using

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function

    Public Function fcnDeleteInvsaldo(ByVal empnit As String) As Boolean

        Dim result As Boolean

        Using cnhost As New SqlConnection(StrHostConnection)

            Try
                If cnhost.State <> ConnectionState.Open Then
                    cnhost.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM COMMUNITY_INVSALDO_SYNC WHERE EMPNIT=@EMPNIT", cnhost)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.ExecuteNonQuery()
                cnhost.Close()

                result = True

            Catch ex As Exception
                Me.DesError = ex.ToString
                result = False
            End Try

        End Using

        Return result

    End Function

End Class
