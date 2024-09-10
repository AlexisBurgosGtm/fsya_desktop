
Imports System.Data.SqlClient

Public Class classGeneralHost


    Sub New(ByVal _local As String, ByVal _host As String)
        local = _local
        host = _host
    End Sub

    Dim local As String, host As String
    Public Property strError As String = ""

    Dim nitMercados As String = "1034261-3"

    Public Function fcnTestConection() As Boolean

        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            If cnh.State <> ConnectionState.Open Then
                Try
                    cnh.Open()
                    r = True
                    cnh.Close()

                Catch ex As Exception
                    r = False
                End Try
            Else
                r = True
            End If
        End Using

        Return r

    End Function



#Region " ** REPARTO ** "

    'OBTIENE LISTA DE EMBARQUES DEL HOSTING
    Public Function getTblEmbarquesHost(ByVal sucursal As String) As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(host)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT ID, CODEMBARQUE, RUTA AS DESRUTA, FECHA
                                        FROM ME_REPARTO_EMBARQUES
                                        WHERE (CODSUCURSAL = @S)", cn)
                cmd.Parameters.AddWithValue("@S", sucursal)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl
    End Function

    'OBTIENE LOS PEDIDOS EN UN EMBARQUE DETERMINADO HOSTING
    Public Function tblHostPedidosPicking(ByVal sucursal As String, ByVal codembarque As String) As DataTable

        Dim tbl As New DataTable

        Using cn As New SqlConnection(host)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT ID, FECHA, CODDOC, CORRELATIVO, CLIENTE, IMPORTE
                                           FROM ME_REPARTO_DOCUMENTOS
                                            WHERE (CODEMBARQUE = @E) AND (CODSUCURSAL = @S)", cn)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@E", codembarque)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing

            End Try
        End Using

        Return tbl
    End Function

    Public Function postEmbarqueToHost(ByVal sucursal As String, ByVal codembarque As String) As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If
                Dim cm As New SqlCommand("DELETE FROM ME_REPARTO_EMBARQUES WHERE CODEMBARQUE=@E AND CODSUCURSAL=@S;
                                        DELETE FROM ME_REPARTO_DOCUMENTOS WHERE CODEMBARQUE=@E AND CODSUCURSAL=@S;
                                        DELETE FROM ME_REPARTO_DOCPRODUCTOS WHERE CODEMBARQUE=@E AND CODSUCURSAL=@S;", cnh)
                cm.Parameters.AddWithValue("@S", sucursal)
                cm.Parameters.AddWithValue("@E", codembarque)
                cm.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("no se pudo eliminar. " + ex.ToString)
            End Try
        End Using



        Using cn As New SqlConnection(strHostConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                '** SUBIDA DE EMBARQUES
                Dim cmd As New SqlCommand("SELECT 0 AS ID, Codigo AS CODEMBARQUE, NomRuta AS RUTA, FechaCreado AS FECHA, CODCHOFER AS CODEMPLEADO, @S AS SUCURSAL FROM Embarques WHERE Codigo=@E", cn)
                cmd.Parameters.AddWithValue("@E", codembarque)
                cmd.Parameters.AddWithValue("@S", sucursal)
                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                cmd.CommandTimeout = 0
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(strHostConectionString)
                Dim bcCopy As New SqlBulkCopy(strHostConectionString)
                cnh.Open()
                bcCopy.BulkCopyTimeout = 0
                bcCopy.DestinationTableName = "ME_REPARTO_EMBARQUES"
                bcCopy.WriteToServer(tbl)
                cnh.Close()

                '*****************************************************************************
                '*** SUBIDA DE DOCUMENTOS **********
                Dim cmdM As New SqlCommand("SELECT 0 AS ID, @S AS CODSUCURSAL, Documentos.DOC_FECHA AS FECHA, Documentos.CODDOC, Documentos.DOC_NUMERO AS CORRELATIVO, Documentos.NITCLIE AS NIT, Documentos.DOC_NOMREF AS CLIENTE, 
                         Clientes.DIRCLIE AS DIRECCION, Municipios.DESMUNI AS MUNICIPIO, Clientes.LATITUD AS LAT, Clientes.LONGITUD AS LONG, Documentos.DOC_TOTALVENTA, Documentos.DOC_NUMORDEN AS CODEMBARQUE, 
                         Documentos.DOC_MATSOLI AS DIRENTREGA, Documentos.DOC_OBS AS OBS, Documentos.CODVEN, Vendedores.NOMVEN AS VENDEDOR, 'A' AS ST
                            FROM  Vendedores RIGHT OUTER JOIN
                         Documentos ON Vendedores.CODVEN = Documentos.CODVEN AND Vendedores.EMP_NIT = Documentos.EMP_NIT LEFT OUTER JOIN
                         Municipios RIGHT OUTER JOIN
                         Clientes ON Municipios.CODMUNI = Clientes.CODMUNI AND Municipios.EMP_NIT = Clientes.EMP_NIT ON Documentos.NITCLIE = Clientes.NITCLIE AND Documentos.EMP_NIT = Clientes.EMP_NIT LEFT OUTER JOIN
                         Tipodocumentos ON Documentos.CODDOC = Tipodocumentos.CODDOC AND Documentos.EMP_NIT = Tipodocumentos.EMP_NIT
                        WHERE (Documentos.DOC_NUMORDEN = @E) AND (Tipodocumentos.TIPODOC = 'FAC')", cn)
                cmdM.Parameters.AddWithValue("@E", codembarque)
                cmdM.Parameters.AddWithValue("@S", sucursal)
                Dim tblM As New DataTable
                Dim daM As New SqlDataAdapter
                cmdM.CommandTimeout = 0
                daM.SelectCommand = cmdM
                daM.Fill(tblM)

                Dim bcCopyM As New SqlBulkCopy(strHostConectionString)
                cnh.Open()
                bcCopyM.BulkCopyTimeout = 0
                bcCopyM.DestinationTableName = "ME_REPARTO_DOCUMENTOS"
                bcCopyM.WriteToServer(tblM)
                cnh.Close()

                '*****************************************************************************
                '*** SUBIDA DE DOCPRODUCTOS **********
                Dim cmdD As New SqlCommand("SELECT 1 AS ID,
                                            @S AS CODSUCURSAL, 
                                            @E AS CODEMBARQUE, 
                                            Documentos.CODDOC, 
                                            Documentos.DOC_NUMERO AS CORRELATIVO, 
                                            Docproductos.CODPROD, 
                                            Docproductos.DESCRIPCION AS DESPROD, 
                                            Docproductos.CODMEDIDA, 
                                            Docproductos.CANTIDAD, 
                                            Docproductos.EQUIVALE, 
                                            Docproductos.CANTIDADINV AS TOTALUNIDADES, 
                                            Docproductos.COSTO, 
                                            Docproductos.PRECIO, 
                                            Docproductos.TOTALCOSTO, 
                                            Docproductos.TOTALPRECIO
                        FROM Documentos LEFT OUTER JOIN
                         Docproductos ON Documentos.DOC_NUMERO = Docproductos.DOC_NUMERO AND Documentos.CODDOC = Docproductos.CODDOC AND Documentos.EMP_NIT = Docproductos.EMP_NIT LEFT OUTER JOIN
                         Tipodocumentos ON Documentos.CODDOC = Tipodocumentos.CODDOC AND Documentos.EMP_NIT = Tipodocumentos.EMP_NIT
                        WHERE (Documentos.DOC_NUMORDEN = @E) AND (Tipodocumentos.TIPODOC = 'FAC')", cn)
                cmdD.Parameters.AddWithValue("@E", codembarque)
                cmdD.Parameters.AddWithValue("@S", sucursal)
                Dim tblD As New DataTable
                Dim daD As New SqlDataAdapter
                cmdD.CommandTimeout = 0
                daD.SelectCommand = cmdD
                daD.Fill(tblD)


                Dim bcCopyD As New SqlBulkCopy(strHostConectionString)
                cnh.Open()
                bcCopyD.BulkCopyTimeout = 0
                bcCopyD.DestinationTableName = "ME_REPARTO_DOCPRODUCTOS"
                bcCopyD.WriteToServer(tblD)
                cnh.Close()
                '*************************************************

                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                strError = ex.ToString
            End Try
        End Using

        Return r
    End Function

    Public Function deleteEmbarquesRepartoHost(ByVal sucursal As String) As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_REPARTO_EMBARQUES WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                strError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function

    'OBTIENE LA LISTA DE REPARTIDORES
    Public Function tblRepartidores(ByVal sucursal As String) As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(host)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODUSUARIO AS CODIGO, NOMBRE, CONCAT(NOMBRE, ' - Tel. ', TELEFONO) AS EMPLEADO, TELEFONO
                                        FROM ME_USUARIOS
                                        WHERE (TIPO = 'REPARTIDOR') AND (CODSUCURSAL = @S)", cn)
                cmd.Parameters.AddWithValue("@S", sucursal)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing

            End Try
        End Using

        Return tbl

    End Function

#End Region

#Region " ** CENSO ** "


    Public Function getClientesCenso(ByVal status As String) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'INSERTADO DE LA TABLA PRODUCTOS
                Dim sql As String
                sql = "SELECT ME_CENSO.ID, 
                                ME_CENSO.CODCLIE, 
                                ME_CENSO.NITCLIE, 
                                ME_CENSO.TIPONEGOCIO, 
                                ME_CENSO.NEGOCIO, 
                                ME_CENSO.NOMCLIE, 
                                ME_CENSO.DIRCLIE, 
                                ME_CENSO.REFERENCIA, 
                                ME_Municipios.DESMUNI AS MUNICIPIO, 
                                ME_Departamentos.DESDEPTO AS DEPARTAMENTO, 
                                ME_CENSO.OBS, 
                                ME_CENSO.TELEFONO, 
                                ME_CENSO.VISITA, 
                                ME_CENSO.LAT, 
                                ME_CENSO.LONG, 
                                ME_CENSO.STATUS, 
                                ME_Vendedores.NOMVEN AS VENDEDOR,
                                ME_CENSO.OBS AS EMAIL, 
                                ME_CENSO.CODVEN, 
                                ME_CENSO.CODMUN, 
                                ME_CENSO.CODDEPTO
                    FROM   ME_CENSO LEFT OUTER JOIN
                         ME_Vendedores ON ME_CENSO.CODVEN = ME_Vendedores.CODVEN AND ME_CENSO.CODSUCURSAL = ME_Vendedores.CODSUCURSAL LEFT OUTER JOIN
                         ME_Departamentos ON ME_CENSO.CODDEPTO = ME_Departamentos.CODDEPTO AND ME_CENSO.CODSUCURSAL = ME_Departamentos.CODSUCURSAL LEFT OUTER JOIN
                         ME_Municipios ON ME_CENSO.CODMUN = ME_Municipios.CODMUNI AND ME_CENSO.CODSUCURSAL = ME_Municipios.CODSUCURSAL
                    WHERE  (ME_CENSO.CODSUCURSAL = @E) AND (ME_CENSO.STATUS = @ST)"

                Dim cmd As New SqlCommand(sql, cnh)
                cmd.Parameters.AddWithValue("@E", Token)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ST", status)
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

    Public Function setStatusClienteCenso(ByVal id As Integer) As Boolean

        Dim r As Boolean

        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE ME_CENSO SET STATUS='GENERADO' WHERE CODSUCURSAL=@E AND ID=@ID", cnh)
                'cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@E", Token)
                cmd.Parameters.AddWithValue("@ID", id)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

                r = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function



    Public Function getGenerarCenso() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmh As New SqlCommand("SELECT ID,NITCLIE,TIPONEGOCIO,NEGOCIO,NOMCLIE,DIRCLIE,REFERENCIA,CODMUNI,CODDEPTO,OBS,TELEFONO,VISITA,LAT,LONG,CODVEN 
                FROM ME_CENSO WHERE CODSUCURSAL=@S", cnh)
                cmh.Parameters.AddWithValue("@S", GlobalEmpNit)
                Dim dr As SqlDataReader = cmh.ExecuteReader
                Do While dr.Read
                    Using cn As New SqlConnection(local)
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If

                        Dim cmd As New SqlCommand("INSERT INTO CLIENTES (
                    EMPNIT,DPI,NIT,NOMBRECLIENTE,DIRCLIENTE,CODMUNICIPIO,CODDEPARTAMENTO,TELEFONOCLIENTE,EMAILCLIENTE,ESTADOCIVIL,SEXO,
                    FECHANACIMIENTOCLIENTE,LATITUDCLIENTE,LONGITUDCLIENTE,CATEGORIA,CIUDADANIA,OCUPACION,CODRUTA,CALIFICACION,SALDO,FECHAINICIO,
                    HABILITADO,DIAVISITA,LIMITECREDITO,DIASCREDITO,PROVINCIA,TIPONEGOCIO,NEGOCIO,CODCLIE) 
                    VALUES 
                    (@EMPNIT,@DPI,@NIT,@NOMBRECLIENTE,@DIRCLIENTE,@CODMUNICIPIO,@CODDEPARTAMENTO,@TELEFONOCLIENTE,@EMAILCLIENTE,@ESTADOCIVIL,@SEXO,
                    @FECHANACIMIENTOCLIENTE,@LATITUDCLIENTE,@LONGITUDCLIENTE,@CATEGORIA,@CIUDADANIA,@OCUPACION,@CODRUTA,@CALIFICACION,@SALDO,@FECHAINICIO,
                    'SI',@DIAVISITA,@LIMITECREDITO,@DIASCREDITO,@PROVINCIA,@TIPONEGOCIO,@NEGOCIO,@CODCLIE)", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@DPI", "SN")
                        cmd.Parameters.AddWithValue("@NIT", dr(1).ToString)
                        cmd.Parameters.AddWithValue("@NOMBRECLIENTE", dr(4).ToString)
                        cmd.Parameters.AddWithValue("@DIRCLIENTE", dr(5).ToString)
                        cmd.Parameters.AddWithValue("@CODMUNICIPIO", Integer.Parse(dr(7)))
                        cmd.Parameters.AddWithValue("@CODDEPARTAMENTO", Integer.Parse(dr(8)))
                        cmd.Parameters.AddWithValue("@TELEFONOCLIENTE", dr(10).ToString)
                        cmd.Parameters.AddWithValue("@EMAILCLIENTE", "SN")
                        cmd.Parameters.AddWithValue("@ESTADOCIVIL", "SOLTERO-A")
                        cmd.Parameters.AddWithValue("@SEXO", "OTROS")
                        cmd.Parameters.AddWithValue("@FECHANACIMIENTOCLIENTE", Today.Date)
                        cmd.Parameters.AddWithValue("@LATITUDCLIENTE", dr(12).ToString)
                        cmd.Parameters.AddWithValue("@LONGITUDCLIENTE", dr(13).ToString)
                        cmd.Parameters.AddWithValue("@CATEGORIA", "P")
                        cmd.Parameters.AddWithValue("@CIUDADANIA", "SN")
                        cmd.Parameters.AddWithValue("@OCUPACION", "Comerciante")
                        cmd.Parameters.AddWithValue("@CODRUTA", Integer.Parse(dr(14)))
                        cmd.Parameters.AddWithValue("@CALIFICACION", "REGULAR")
                        cmd.Parameters.AddWithValue("@SALDO", 0)
                        cmd.Parameters.AddWithValue("@FECHAINICIO", Today.Date)
                        cmd.Parameters.AddWithValue("@DIAVISITA", dr(11).ToString)
                        cmd.Parameters.AddWithValue("@LIMITECREDITO", 0)
                        cmd.Parameters.AddWithValue("@DIASCREDITO", 0)
                        cmd.Parameters.AddWithValue("@PROVINCIA", dr(6).ToString)
                        cmd.Parameters.AddWithValue("@TIPONEGOCIO", dr(2).ToString)
                        cmd.Parameters.AddWithValue("@NEGOCIO", dr(3).ToString)
                        cmd.Parameters.AddWithValue("@CODCLIE", dr(0).ToString)
                        cmd.ExecuteNonQuery()

                    End Using
                Loop

                r = True

            Catch ex As Exception
                strError = ex.ToString
                r = False
            End Try

        End Using


        Return r
    End Function

    ''' <summary>
    ''' DESCARGA LA TABLA DEL CENSO
    ''' </summary>
    ''' <returns></returns>
    Public Function getGeneralCenso() As DataTable

        'OBTIENE LOS CLIENTES DEL CENSO

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'INSERTADO DE LA TABLA PRODUCTOS
                Dim sql As String
                sql = "SELECT ME_CENSO.CODSUCURSAL AS SUCURSAL, ME_Vendedores.NOMVEN AS VENDEDOR, ME_CENSO.VISITA, ME_CENSO.ID, ME_CENSO.FECHA, ME_CENSO.NITCLIE AS NIT, ME_CENSO.TIPONEGOCIO, ME_CENSO.NEGOCIO, 
                         ME_CENSO.NOMCLIE AS CLIENTE, ME_CENSO.DIRCLIE AS DIRECCION, ISNULL(ME_CENSO.REFERENCIA, 'SN') AS REFERENCIA, ME_Municipios.DESMUNI AS MUNICIPIO, ME_Departamentos.DESDEPTO AS DEPARTAMENTO, 
                         ISNULL(ME_CENSO.OBS, 'SN') AS OBSERVACIONES, ISNULL(ME_CENSO.TELEFONO, 'SN') AS TELEFONO, ME_CENSO.LAT AS LATITUD, ME_CENSO.LONG AS LONGITUD
                        FROM ME_CENSO LEFT OUTER JOIN
                         ME_Vendedores ON ME_CENSO.CODVEN = ME_Vendedores.CODVEN AND ME_CENSO.CODSUCURSAL = ME_Vendedores.CODSUCURSAL LEFT OUTER JOIN
                         ME_Departamentos ON ME_CENSO.CODDEPTO = ME_Departamentos.CODDEPTO AND ME_CENSO.CODSUCURSAL = ME_Departamentos.CODSUCURSAL LEFT OUTER JOIN
                         ME_Municipios ON ME_CENSO.CODMUN = ME_Municipios.CODMUNI AND ME_CENSO.CODSUCURSAL = ME_Municipios.CODSUCURSAL
					    ORDER BY ME_CENSO.CODVEN, ME_CENSO.ID"

                Dim cmd As New SqlCommand(sql, cnh)
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


    Public Function getTblProductos() As DataTable
        Dim tbl As New DSGeneral.tblProductosDataTable

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, CODPRODALTERNO, CODPRODPROV AS DESPROD3 FROM PRODUCTOS", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl
    End Function

    Public Function setMarcarProductosCero() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET CODPRODPROV='0' ", cn)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                GlobalDesError = ex.ToString
            End Try
        End Using

        Return r

    End Function


    ''' <summary>
    ''' VERIFICA QUE EXISTA ESE CODIGO NUEVO PARA NO DUPLICARLO CON UNO EXISTENTE
    ''' </summary>
    ''' <param name="codigo"></param>
    ''' <returns></returns>
    Public Function verificarCodigo(ByVal codigo As String) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(local)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD FROM PRODUCTOS WHERE EMP_NIT=@E AND CODPROD=@C ", cn)
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
                r = False
            End Try

        End Using

        Return r

    End Function

    Public Function setMarcarProducto(ByVal codactual As String, ByVal codnuevo As String) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE PRODUCTOS SET CODPRODPROV=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL ", cn)
                cmd.Parameters.AddWithValue("@E", "1034261-3")
                cmd.Parameters.AddWithValue("@ACTUAL", codactual)
                cmd.Parameters.AddWithValue("@NUEVO", codnuevo)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                GlobalDesError = ex.ToString
            End Try
        End Using

        Return r

    End Function

    ''' <summary>
    ''' CAMBIA EL CODIGO DE UN PRODUCTO
    ''' </summary>
    ''' <param name="codactual"></param>
    ''' <param name="codnuevo"></param>
    ''' <returns></returns>
    Public Function setCambiarCodigoProducto(ByVal codactual As String, ByVal codnuevo As String) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'tablas 1034261-3
                ' x DetalleProveedores
                ' x DOCPRODUCTOS
                ' x PRECIOS
                ' x PRODUCTOS
                ' 
                Dim qryDETALLEPROVEEDORES As String = "UPDATE DetalleProveedores SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL;"
                Dim qryDOCPRODUCTOS As String = "UPDATE DOCPRODUCTOS SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL;"
                Dim qryPRECIOS As String = "UPDATE PRECIOS SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL;"
                Dim qryPRODUCTOS As String = "UPDATE PRODUCTOS SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL;"
                Dim qryINVSALDO As String = "UPDATE INVSALDO SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL;"

                Dim cmd As New SqlCommand(qryDETALLEPROVEEDORES & qryDOCPRODUCTOS & qryPRECIOS & qryPRODUCTOS & qryINVSALDO, cn)
                cmd.Parameters.AddWithValue("@E", "1034261-3")
                cmd.Parameters.AddWithValue("@ACTUAL", codactual)
                cmd.Parameters.AddWithValue("@NUEVO", codnuevo)
                cmd.CommandTimeout = 999999
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                GlobalDesError = ex.ToString
            End Try
        End Using

        Return r

    End Function

    Public Function setCambiarCodigoProductoOnline(ByVal codactual As String, ByVal codnuevo As String, ByVal codsucursal As String) As Boolean

        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'tablas 1034261-3
                ' x DOCPRODUCTOS
                ' x PRECIOS
                ' x PRODUCTOS
                'ME_TEMP_VENTAS
                ' 
                'Dim qryDETALLEPROVEEDORES As String = "UPDATE DetalleProveedores SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL;"
                Dim qryDOCPRODUCTOS As String = "UPDATE ME_DOCPRODUCTOS SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL AND CODSUCURSAL=@CODSUCURSAL;"
                Dim qryPRECIOS As String = "UPDATE ME_PRECIOS SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL AND CODSUCURSAL=@CODSUCURSAL;"
                Dim qryPRODUCTOS As String = "UPDATE ME_PRODUCTOS SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL AND CODSUCURSAL=@CODSUCURSAL;"
                Dim qryINVSALDO As String = "UPDATE ME_INVSALDO SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL AND CODSUCURSAL=@CODSUCURSAL;"
                Dim qryTEMPVENTAS As String = "UPDATE ME_TEMP_VENTAS SET CODPROD=@NUEVO WHERE EMP_NIT=@E AND CODPROD=@ACTUAL AND CODSUCURSAL=@CODSUCURSAL;"

                Dim cmd As New SqlCommand(qryDOCPRODUCTOS & qryPRECIOS & qryPRODUCTOS & qryINVSALDO, cnh)
                cmd.Parameters.AddWithValue("@E", "1034261-3")
                cmd.Parameters.AddWithValue("@ACTUAL", codactual)
                cmd.Parameters.AddWithValue("@NUEVO", codnuevo)
                cmd.Parameters.AddWithValue("@CODSUCURSAL", codsucursal)
                cmd.CommandTimeout = 999999
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                GlobalDesError = ex.ToString
            End Try
        End Using

        Return r

    End Function

    Public Function getTblProductosCatalogoLocal() As DataTable
        Dim tbl As New DSGeneral.tblProductosDataTable

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, CODPRODV AS CODPRODALTERNO, DESPROD FROM PRODUCTOS", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl
    End Function

    ''' <summary>
    ''' OBTIENE EL CATÁOGO DE PRODUCTOS DESDE EL HOSTING
    ''' </summary>
    ''' <returns></returns>
    Public Function getGeneralProductos() As Boolean
        Dim r As Boolean

        'PRIMERO ELIMINA LA TABLA TEMPORAL CON LOS DATOS
        Using cn As New SqlConnection(strHostConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmdd As New SqlCommand("TRUNCATE TABLE TEMP_PRODUCTOS_SYNC;TRUNCATE TABLE TEMP_PRECIOS_SYNC;", cn)
                cmdd.ExecuteNonQuery()
            Catch ex As Exception

            End Try

        End Using


        'LUEGO OBTIENE LOS PRODUCTOS Y LOS PEGA EN LA TABLA TEMPORAL

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'INSERTADO DE LA TABLA PRODUCTOS
                Dim sql As String
                sql = "SELECT EMP_NIT, CODPROD, DESPROD, CODMEDIDAINV, CODMEDIDACOM, CODCLAUNO, CODCLADOS, CODCLATRES,
      CODMARCA, CODPRODPROV, TIPOPROD, PORCENTAJEARANCEL, FECHAINIOFERTA, FECHAFINOFERTA,
      PORCENTAJEMAYORISTA, ESCALA, PORCENTAJEESCALA, CODMONEDA, PRECIOMONEDA, VALORCIF, VALORFOB,
      COSTODOLAR, COSTOQUETZAL, UTILIDAD, EQUIVALEINV, PORDESCUMAXIMO, PRODTIPOCAMBIO, DESPROD2,
      VENCIMIENTO, CLASEPROD, NOHABILITADO, DESPROD3, PORCENTAJEESPECIAL,PORCENTAJEIVA, TECLA,
      FORMULAESPECIAL, FORMULAMAYORISTA, FORMULAESCALA, UTILIZASERIE, UTILIZACHASIS, PRODCANTBONI,
      FILEICONO, DESICONO, FORMULAPRECIO, FACTORGANANCIA, PORCENTAJEPRECIO, PRODEXENTO,
      CODPRODALTERNO, PORCENTAJEOFERTA, FORMULAOFERTA, PRODSERIETIPO, PORCENTAJEPROPINA,
      UTILIZABALANZA, CANTIDADDECIMAL, NONEGATIVOS, COLORPROD, CALCULOESPECIAL, PORCENTAJETPRENSA,
      PRECIOTPRENSA, PRODTIPOLOTE, PRODDIAS, CONVERSION, CODARANCEL, VALORFOBINI, FRONTERAVISIBLE,
      LASTSALE FROM ME_Productos where CODSUCURSAL='GENERAL'"

                Dim cmd As New SqlCommand(sql, cnh)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cn As New SqlConnection(strHostConectionString)
                Dim bcCopy As New SqlBulkCopy(strHostConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                bcCopy.DestinationTableName = "TEMP_PRODUCTOS_SYNC"
                bcCopy.WriteToServer(tbl)
                tbl = Nothing

                'INSERTADO DE LA TABLA PRECIOS
                Dim sqlp As String = "SELECT EMP_NIT, CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,MAYORISTA,ESCALA,OFERTA,
	            VENTAMEDIDA,UTILIDAD,ESPECIAL,PESO,PRECIOFIN,CODBARRAMEDIDA,ALTO,ANCHO,
	            LARGO,CONSUMOAGUA,PRECIOEXCESOAGUA,CODBONI,PUNTOS,CALCULOPUNTOS,FILEICONO,DESICONO,ACTIVO
                FROM ME_PRECIOS WHERE CODSUCURSAL='GENERAL'"
                Dim tblP As New DataTable
                Dim cmdP As New SqlCommand(sqlp, cnh)
                Dim daP As New SqlDataAdapter
                daP.SelectCommand = cmdP
                daP.Fill(tblP)

                Dim bcCopyP As New SqlBulkCopy(strHostConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                bcCopyP.DestinationTableName = "TEMP_PRECIOS_SYNC"
                bcCopyP.WriteToServer(tblP)
                tblP = Nothing

                r = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function


    Dim backupname As String
    Public Function updateCatalogoProductos() As Boolean
        Dim r As Boolean
        backupname = "B" & Today.Day.ToString & "-" & Today.Month.ToString & "-" & Today.Year.ToString & "-" & Now.Hour.ToString & "-" & Now.Minute.ToString

        Using cn As New SqlConnection(strHostConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                'PRODUCTOS
                'primero quito los productos que están 
                'cambiandole el nit
                Dim qry As String = "UPDATE PRODUCTOS SET EMP_NIT='" & backupname & "' WHERE EMP_NIT='1034261-3' "
                Dim cmd As New SqlCommand(qry, cn)
                cmd.ExecuteNonQuery()

                'luego copio el catálogo contenido en la tabla temporal
                Dim tbl As New DataTable
                Dim cmdr As New SqlCommand("SELECT * FROM TEMP_PRODUCTOS_SYNC", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmdr
                da.Fill(tbl)

                Dim bcCopy As New SqlBulkCopy(strHostConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                bcCopy.DestinationTableName = "PRODUCTOS"
                bcCopy.WriteToServer(tbl)
                tbl = Nothing

                'PRECIOS
                'primero quito los precios que están 
                'cambiandole el nit
                Dim qryP As String = "UPDATE PRECIOS SET EMP_NIT='" & backupname & "' WHERE EMP_NIT='1034261-3' "
                Dim cmdP As New SqlCommand(qryP, cn)
                cmdP.ExecuteNonQuery()

                'luego copio el catálogo contenido en la tabla temporal
                Dim tblP As New DataTable
                Dim cmdrP As New SqlCommand("SELECT * FROM TEMP_PRECIOS_SYNC", cn)
                Dim daP As New SqlDataAdapter
                daP.SelectCommand = cmdrP
                daP.Fill(tblP)

                Dim bcCopyP As New SqlBulkCopy(strHostConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                bcCopyP.DestinationTableName = "PRECIOS"
                bcCopyP.WriteToServer(tblP)
                tblP = Nothing


                'INVSALDO
                'cambio los productos existentes y los dejo como backup
                Dim qryE As String = "UPDATE INVSALDO SET EMP_NIT='" & backupname & "' WHERE EMP_NIT='1034261-3' "
                Dim cmdE As New SqlCommand(qryE, cn)
                cmdP.ExecuteNonQuery()

                Dim qryI As String = "INSERT INTO INVSALDO (EMP_NIT,INV_ANO,INV_MES,CODBODEGA,CODPROD,SALDOINICIAL,SALDOFINAL,MINIMO,MAXIMO,COSTOINICIAL,COSTOFINAL,ENTRADAS,SALIDAS,NOLOTE,PORMINIMO,PORMAXIMO,VEREXISTENCIA) 
                        SELECT EMP_NIT,@ANIO AS INV_ANO,@MES AS INV_MES,'01' AS CODBODEGA,CODPROD,0 AS SALDOINICIAL,0 AS SALDOFINAL,0 AS MINIMO,0 AS MAXIMO,0 AS COSTOINICIAL,0 AS COSTOFINAL,0 AS ENTRADAS,0 AS SALIDAS,'SN' AS NOLOTE,0 AS PORMINIMO,0 AS PORMAXIMO,0 AS VEREXISTENCIA FROM TEMP_PRODUCTOS_SYNC"
                Dim cmdI As New SqlCommand(qryI, cn)
                cmdI.Parameters.AddWithValue("@ANIO", GlobalAnioProceso)
                cmdI.Parameters.AddWithValue("@MES", GlobalMesProceso)
                cmdI.ExecuteNonQuery()

                r = True
            Catch ex As Exception
                GlobalDesError = ex.ToString

                r = False
            End Try

        End Using

        Return r

    End Function


    Public Function tblReporteGeneral(ByVal anio As Integer, ByVal mes As Integer) As DataTable

        Dim tbl As New DataTable

        Using cn As New SqlConnection(local)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT Tipodocumentos.TIPODOC AS TRANSACCION, Vendedores.NOMVEN AS VENDEDOR, Documentos.DOC_FECHA AS FECHA, Documentos.NITCLIE, Documentos.DOC_NOMREF AS NOMCLIE, Docproductos.CODPROD, 
                         Productos.DESPROD, Docproductos.CODMEDIDA, Medidas.ESPECIFICACION AS TIPOPRECIO, (CASE WHEN TIPODOCUMENTOS.TIPODOC = 'NCR' THEN SUM(Docproductos.CANTIDADINV * - 1) 
                         ELSE SUM(Docproductos.CANTIDADINV) END) AS TOTALUNIDADES, (CASE WHEN TIPODOCUMENTOS.TIPODOC = 'NCR' THEN SUM(Docproductos.TOTALCOSTO * - 1) ELSE SUM(Docproductos.TOTALCOSTO) END) 
                         AS TOTALCOSTO, (CASE WHEN TIPODOCUMENTOS.TIPODOC = 'NCR' THEN SUM(Docproductos.TOTALPRECIO * - 1) ELSE SUM(Docproductos.TOTALPRECIO) END) AS TOTALPRECIO, Productos.EQUIVALEINV AS UXC, 
                         Marcas.DESMARCA AS MARCA, Claseuno.DESCLAUNO AS CLASIFUNO
                    FROM  Productos LEFT OUTER JOIN
                         Claseuno ON Productos.EMP_NIT = Claseuno.EMP_NIT AND Productos.CODCLAUNO = Claseuno.CODCLAUNO LEFT OUTER JOIN
                         Marcas ON Productos.EMP_NIT = Marcas.EMP_NIT AND Productos.CODMARCA = Marcas.CODMARCA RIGHT OUTER JOIN
                         Medidas RIGHT OUTER JOIN
                         Docproductos ON Medidas.EMP_NIT = Docproductos.EMP_NIT AND Medidas.CODMEDIDA = Docproductos.CODMEDIDA ON Productos.CODPROD = Docproductos.CODPROD AND 
                         Productos.EMP_NIT = Docproductos.EMP_NIT RIGHT OUTER JOIN
                         Vendedores RIGHT OUTER JOIN
                         Documentos ON Vendedores.CODVEN = Documentos.CODVEN AND Vendedores.EMP_NIT = Documentos.EMP_NIT ON Docproductos.DOC_NUMERO = Documentos.DOC_NUMERO AND 
                         Docproductos.CODDOC = Documentos.CODDOC AND Docproductos.EMP_NIT = Documentos.EMP_NIT AND Docproductos.DOC_ANO = Documentos.DOC_ANO AND 
                         Docproductos.DOC_MES = Documentos.DOC_MES LEFT OUTER JOIN
                         Tipodocumentos ON Documentos.CODDOC = Tipodocumentos.CODDOC AND Documentos.EMP_NIT = Tipodocumentos.EMP_NIT
                WHERE (Documentos.DOC_ESTATUS <> 'A') AND (Documentos.DOC_ANO = @ANIO) AND (Documentos.DOC_MES =  @MES) AND (Tipodocumentos.TIPODOC = 'FAC' OR
                         Tipodocumentos.TIPODOC = 'NCR')
                GROUP BY Tipodocumentos.TIPODOC, Documentos.DOC_FECHA, Documentos.NITCLIE, Documentos.DOC_NOMREF, Docproductos.CODPROD, Productos.DESPROD, Productos.EQUIVALEINV, Marcas.DESMARCA, Claseuno.DESCLAUNO, 
                         Vendedores.NOMVEN, Docproductos.CODMEDIDA, Medidas.ESPECIFICACION", cn)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        Return tbl

    End Function

    Public Function tblCoddoc(ByVal tipodoc As String) As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODDOC,CORRELATIVO,DESDOC FROM TIPODOCUMENTOS WHERE EMPNIT=@E AND TIPODOC=@T", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@T", tipodoc)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                strError = ex.ToString
                MsgBox(strError)
            End Try
        End Using

        Return tbl

    End Function

    Public Function tblPedidosPicking(ByVal sucursal As String, ByVal codven As Integer, ByVal embarque As String) As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(host)
            Try

                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODDOC, DOC_NUMERO AS CORRELATIVO, DOC_NOMREF AS CLIENTE, DOC_TOTALVENTA AS IMPORTE, DOC_FECHA AS FECHA FROM ME_DOCUMENTOS WHERE CODSUCURSAL=@S AND CODVEN=@V AND DOC_NUMORDEN=@E AND ISCENVIADO=0", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@V", codven)
                cmd.Parameters.AddWithValue("@E", embarque)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                strError = ex.ToString

            End Try
        End Using

        Return tbl

    End Function


    Public Function tblVendedores(ByVal sucursal As String) As DataTable
        Dim tbl As New DataTable

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODVEN,NOMVEN,TELEFONO FROM ME_VENDEDORES WHERE CODSUCURSAL=@S AND ACTIVO='SI' ORDER BY NOMVEN ", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString

            End Try
        End Using

        Return tbl
    End Function


    Public Function tblEmbarques(ByVal sucursal As String) As DataTable
        Dim tbl As New DataTable

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODIGO AS CODEMBARQUE, NOMRUTA AS RUTA, CONCAT(CODIGO, ' - ', NOMRUTA) AS DESRUTA FROM ME_EMBARQUES WHERE CODSUCURSAL=@S AND STATUS='PENDIENTE'", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString

            End Try
        End Using

        Return tbl
    End Function


    'genera los pedidos en base a las tablas
    Public Function generarPedidosVendedor(ByVal sucursal As String, ByVal codven As Integer, ByVal embarque As String, ByVal coddoc As String, ByVal correlativo As Integer, ByVal fecha As Date) As Boolean

        Dim r As Boolean

        Dim iva As Double = 0.12

        'GENERACION TABAL DOCUMENTOS
        'INDICO LA TABLA NUM_DOCTO (FLOAT) CAMBIADO A CERO PARA INDICAR QUE NO SE HA GENERADO LA
        'FACTURA EN EL PEDIDO. LUEGO TOMO UN PROCESO PARA CAMBIARLOS A FACTURA DE UNO A UNO YA EN EL SISTEMA
        'PARA EVITAR QUE LA CARGA DESDE EL HOST SE DETENGA
        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim sql As String
                sql = "SELECT 
                0 AS ID,
                @S AS EMPNIT,
                @ANIO AS ANIO,
                @MES AS MES,
                @DIA AS DIA,
                @FECHA AS FECHA,
                @HORA AS HORA,
                @MINUTO AS MINUTO,
                CODDOC,
                CAST(DOC_NUMERO AS FLOAT) AS CORRELATIVO,
                0 AS CODCLIENTE,
                DOC_NIT AS DOC_NIT,
                DOC_NOMREF AS DOC_NOMCLIE,
                DOC_DIRENTREGA  AS DOC_DIRCLIE,
                DOC_TOTALCOSTO AS TOTALCOSTO,
                DOC_TOTALVENTA AS TOTALPRECIO,
                DOC_NUMORDEN AS CODEMBARQUE,
                'O' AS STATUS,
                @USUARIO AS USUARIO,
                'CON' AS CONCRE,
                'NO' AS CORTE,
                CODDOC AS SERIEFAC,
                CAST(DOC_NUMERO AS FLOAT) AS NOFAC,
                CODVEN AS CODVEN,
                0 AS NOCORTE,
                DOC_TOTALVENTA AS PAGO,
                0 AS VUELTO,
                'SN' AS MARCA,
                DOC_OBS AS OBS,
                0 AS DOC_SALDO,
                DOC_TOTALVENTA AS DOC_ABONO,
                'SN' AS OBSMARCA,
                0 AS TOTALDESCUENTO,
                @CODCAJA AS CODCAJA,
                0 AS TOTALTARJETA,
                0 AS RECARGOTARJETA,
                0 AS CODREP,
                DOC_MATSOLI AS DIRENTREGA,
                'SN' AS NOGUIA,
                0  AS VALORENTREGA,
                0 AS TOTALEXENTO,
                LAT AS LAT,
                LONG AS LONG,
                'SN' AS TIPOPAGO,
                'SN'  AS NODOCPAGO,
                 @FECHA AS VENCIMIENTO,
                 0 AS DIASCREDITO,
                 (DOC_TOTALVENTA * @IVA) AS TOTALIVA,
                 (DOC_TOTALVENTA - (DOC_TOTALVENTA * @IVA)) AS TOTALSINIVA
                FROM ME_Documentos 
                WHERE 
                    CODSUCURSAL=@S 
                    AND CODVEN=@V 
                    AND DOC_NUMORDEN=@E 
                    AND DOC_ESTATUS='I' 
                    AND ISCENVIADO=0"

                Dim cmd As New SqlCommand(sql, cnh)

                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@V", codven)
                cmd.Parameters.AddWithValue("@E", embarque)
                cmd.Parameters.AddWithValue("@CODCAJA", 1)
                cmd.Parameters.AddWithValue("@IVA", iva)
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)

                cmd.Parameters.AddWithValue("@FECHA", fecha)
                cmd.Parameters.AddWithValue("@DIA", fecha.Day)
                cmd.Parameters.AddWithValue("@ANIO", fecha.Year)
                cmd.Parameters.AddWithValue("@MES", fecha.Month)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cn As New SqlConnection(local)
                Dim bcCopy As New SqlBulkCopy(local)
                cn.Open()
                bcCopy.DestinationTableName = "TEMP_DOCUMENTOS"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using


        'GENERACIÓN DE DOCPRODUCTOS
        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                        0 AS ID,
                        @S AS EMPNIT,
                        @ANIO AS ANIO,
                        @MES AS MES,
                        @DIA AS DIA,
                        ME_Docproductos.CODDOC AS CODDOC,
                        ME_Docproductos.DOC_NUMERO AS CORRELATIVO,
                        ME_Docproductos.CODPROD AS CODPROD,
                        ME_Docproductos.DESCRIPCION AS DESPROD,
                        ME_Docproductos.CODMEDIDA AS CODMEDIDA,
                        ME_Docproductos.CANTIDAD AS CANTIDAD,
                        0 AS CANTIDADBONIF,
                        ME_Docproductos.EQUIVALE AS EQUIVALE,
                        ME_Docproductos.CANTIDADINV AS TOTALUNIDADES,
                        0 AS TOTALBONIF,
                        ME_Docproductos.COSTO AS COSTO,
                        ME_Docproductos.PRECIO AS PRECIO,
                        ME_Docproductos.TOTALCOSTO AS TOTALCOSTO,
                        ME_Docproductos.TOTALPRECIO AS TOTALPRECIO,
                        ME_Docproductos.CANTIDADINV AS ENTREGADOS_TOTALUNIDADES,
                        ME_Docproductos.TOTALCOSTO AS ENTREGADOS_TOTALCOSTO,
                        ME_Docproductos.TOTALPRECIO AS ENTREGADOS_TOTALPRECIO,
                        0 AS COSTOANTERIOR,
                        0 AS COSTOPROMEDIO,
                        1 AS CODBODEGAENTRADA,
                        1 AS CODBODEGASALIDA,
                        0 AS DESCUENTO,
                        0 AS PORCDESCUENTO,
                        'SN' AS NOSERIE,
                        0 AS EXENTO,
                        'SN' AS OBS,
                        (ME_Docproductos.TOTALPRECIO * @IVA) AS TOTALIVA,
                        (ME_Docproductos.TOTALPRECIO - (ME_Docproductos.TOTALPRECIO * @IVA)) AS TOTALSINIVA
                        FROM ME_Docproductos RIGHT OUTER JOIN
                         ME_Documentos ON ME_Docproductos.CODSUCURSAL = ME_Documentos.CODSUCURSAL AND ME_Docproductos.DOC_ANO = ME_Documentos.DOC_ANO AND 
                         ME_Docproductos.DOC_NUMERO = ME_Documentos.DOC_NUMERO AND ME_Docproductos.CODDOC = ME_Documentos.CODDOC AND ME_Docproductos.EMP_NIT = ME_Documentos.EMP_NIT
                        WHERE (ME_Documentos.CODVEN = @V) AND (ME_Documentos.DOC_NUMORDEN = @E) AND (ME_Documentos.CODSUCURSAL = @S) AND (ME_Documentos.DOC_ESTATUS = 'I') AND (ME_Documentos.ISCENVIADO=0)", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@V", codven)
                cmd.Parameters.AddWithValue("@E", embarque)
                cmd.Parameters.AddWithValue("@ANIO", fecha.Year)
                cmd.Parameters.AddWithValue("@MES", fecha.Month)
                cmd.Parameters.AddWithValue("@DIA", fecha.Day)
                cmd.Parameters.AddWithValue("@IVA", iva)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cn As New SqlConnection(local)
                Dim bcCopy As New SqlBulkCopy(local)
                cn.Open()
                bcCopy.DestinationTableName = "TEMP_DOCPRODUCTOS"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r

    End Function


    'genera los pedidos en base a las tablas PICKING
    Public Function generarPedidosPicking(ByVal sucursal As String, ByVal embarque As String, ByVal coddoc As String, ByVal correlativo As Integer, ByVal fecha As Date) As Boolean

        Dim r As Boolean

        'GENERACION TABAL DOCUMENTOS
        'INDICO LA TABLA NUM_DOCTO (FLOAT) CAMBIADO A CERO PARA INDICAR QUE NO SE HA GENERADO LA
        'FACTURA EN EL PEDIDO. LUEGO TOMO UN PROCESO PARA CAMBIARLOS A FACTURA DE UNO A UNO YA EN EL SISTEMA
        'PARA EVITAR QUE LA CARGA DESDE EL HOST SE DETENGA
        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMP_NIT,
                @ANIO AS DOC_ANO,
                @MES AS DOC_MES,
                CODDOC,DOC_NUMERO,
                @CODCAJA AS CODCAJA,
                @FECHA AS DOC_FECHA,
                DOC_NUMREF,DOC_NOMREF,BODEGAENTRADA,BODEGASALIDA,USUARIO,
                DOC_ESTATUS,DOC_TOTALCOSTO,DOC_TOTALVENTA,DOC_HORA,DOC_FVENCE,DOC_DIASCREDITO,
                @CONCRE AS DOC_CONTADOCREDITO,
                DOC_DESCUENTOTOTAL,DOC_DESCUENTOPROD,DOC_PORDESCUTOTAL,DOC_IVA,
                DOC_SUBTOTALIVA,DOC_SUBTOTAL,NITCLIE,DOC_PORDESCUFAC,CODVEN,DOC_ABONOS,DOC_SALDO,
                DOC_VUELTO,DOC_NIT,DOC_PAGO,DOC_CODREF,DOC_TIPOCAMBIO,DOC_PARCIAL,DOC_ANTICIPO,
                ANT_CODDOC,ANT_DOCNUMERO,DOC_OBS,DOC_PORCENTAJEIVA,DOC_ENVIO,DOC_CUOTAS,DOC_TIPOCUOTA,
                DOC_FMODIFICA,DIVA_NUMINT,FRT_CODIGO,TRANSPORTE,DOC_REFPEDIDO,DOC_REFFACTURA,CODPROV,
                DOC_TOTALOTROS,DOC_RECIBO,DOC_MATSOLI,DOC_REFERENCIA,DOC_LUGAR,
                DOC_ANOMBREDE,DOC_IVAEXO,DOC_VALOREXO,DOC_SECTOR,DOC_DIRENTREGA,
                DOC_CANTENV,
                'B' AS DOC_EXP,
                DOC_FECHAENT,TIPOPRODUCCION,DOC_TOTCOSINV,
                DOC_TOTALFIN,USUARIOENUSO,DOC_IMPUESTO1,DOC_TOTALIMPU1,DOC_PORCOMI,
                DOC_DOLARES,CODMESA,DOC_TIPOOPE,USUARIOAUTORIZA,NUMAUTORIZA,FECHAAUTORIZA,
                HORAAUTORIZA,DOC_TEMPORADA,DOC_INGUAT,FECHAINGBOD,HORAINGBOD,FECHASALBOD,
                HORASALBOD,CODVENBOD,CODHABI,
                CODDOC AS DOC_SERIE,
                DOC_FECHAFAC,DOC_IVARETENIDO,FECHARECBOD,
                HORARECBOD,CTABAN,NUMINTBAN,FECHARECEMP,HORARECEMP,FECHAINGEMP,HORAINGEMP,
                FECHASALEMP,HORASALEMP,CODVENEMP,FECHARECFAC,HORARECFAC,FECHAINGFAC,HORAINGFAC,
                FECHASALFAC,HORASALFAC,FECHARECENT,HORARECENT,FECHAINGENT,HORAINGENT,FECHASALENT,
                HORASALENT,
                DOC_TOTALCOSTO AS DOC_TOTCOSDOL,
                DOC_TOTALCOSTO AS DOC_TOTCOSINVDOL,
                CODUNIDAD,TOTCOMBUSTIBLE,DOC_CODCONTRA,
                DOC_NUMCONTRA,INTERES,ABONOINTERES,SALDOINTERES,NUMEROCORTE,DOC_PORLOCAL,DOC_NUMORDEN,
                DOC_FENTREGA,DOC_INTERESADO,DOC_RECIBE,NUMEROROLLO,COD_CENTRO,GENCUOTA,DOC_PORINGUAT,
                DOC_INGUATEXENTO,
                'C' AS DOC_TIPOTRANIVA,
                DOC_PORTIMBREPRE,DOC_TIMBREPRENSA,ABONOSANTICIPO,
                SALDOANTICIPO,DOC_PRODEXENTO,PUNTOSGANADOS,PUNTOSUSADOS,APL_ANTICIPO,COD_DEPARTA,
                FIRMAELECTRONICA,DOC_CODDOCRETENCION,DOC_SERIERETENCION,DOC_NUMRETENCION,FIRMAISC,
                ISCENVIADO,
                1 AS Num_docto,LAT,LONG
                FROM ME_Documentos 
                WHERE CODSUCURSAL=@S AND DOC_NUMORDEN=@E AND DOC_ESTATUS='I' AND ISCENVIADO=0 ORDER BY CODVEN,CODDOC,DOC_NUMERO", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@E", embarque)
                cmd.Parameters.AddWithValue("@CODCAJA", "01")
                cmd.Parameters.AddWithValue("@CONCRE", "CRE")
                cmd.Parameters.AddWithValue("@FECHA", fecha)
                cmd.Parameters.AddWithValue("@ANIO", fecha.Year)
                cmd.Parameters.AddWithValue("@MES", fecha.Month)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cn As New SqlConnection(strHostConectionString)
                Dim bcCopy As New SqlBulkCopy(strHostConectionString)
                cn.Open()
                bcCopy.DestinationTableName = "DOCUMENTOS"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        'GENERACIÓN DE DOCPRODUCTOS
        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT ME_Docproductos.EMP_NIT, 
                        @ANIO AS DOC_ANO,
                        @MES AS DOC_MES, 
                         ME_Docproductos.CODDOC, ME_Docproductos.DOC_NUMERO, ME_Docproductos.DOC_ITEM, ME_Docproductos.CODPROD, 
                         ME_Docproductos.CODMEDIDA, ME_Docproductos.CANTIDAD, ME_Docproductos.EQUIVALE, ME_Docproductos.CANTIDADINV, ME_Docproductos.COSTO, ME_Docproductos.PRECIO, ME_Docproductos.TOTALCOSTO, 
                         ME_Docproductos.TOTALPRECIO, ME_Docproductos.BODEGAENTRADA, ME_Docproductos.BODEGASALIDA, ME_Docproductos.SUBTOTAL, ME_Docproductos.DESCUENTOPROD, ME_Docproductos.PORDESCUPROD, 
                         ME_Docproductos.DESCUENTOFAC, ME_Docproductos.PORDESCUFAC, ME_Docproductos.TOTALDESCUENTO, ME_Docproductos.DESCRIPCION, ME_Docproductos.SUBTOTALPROD, ME_Docproductos.TIPOCAMBIO, 
                         ME_Docproductos.PRODPRECIO, ME_Docproductos.CANTIDADENVIADA, 
                         '' AS CODFAC, 
                         '' AS NUMFAC, 
                         ME_Docproductos.ITEMFAC, ME_Docproductos.NOAFECTAINV, 
                         ME_Docproductos.PRODFVENCE, ME_Docproductos.DOCPESO, ME_Docproductos.COSTOINV, ME_Docproductos.FLETE, ME_Docproductos.TOTALPRECIOFIN, ME_Docproductos.PRECIOFIN, ME_Docproductos.TOTALCOSTOINV, 
                         ME_Docproductos.CANTIDADBONI, ME_Docproductos.CODOPR, ME_Docproductos.NUMOPR, ME_Docproductos.ITEMOPR, ME_Docproductos.CODINV, ME_Docproductos.NUMINV, ME_Docproductos.ITEMINV, 
                         ME_Docproductos.TIPOCLIE, ME_Docproductos.LISTA, ME_Docproductos.PORIVA, ME_Docproductos.VALORIVA, ME_Docproductos.NOLOTE, ME_Docproductos.VALORIMPU1, ME_Docproductos.DESEMPAQUE, 
                         ME_Docproductos.SALDOINVANTCOM, ME_Docproductos.NCUENTAMESA, ME_Docproductos.CUENTACERRADA, ME_Docproductos.COSTODOL, ME_Docproductos.COSTOINVDOL, ME_Docproductos.TOTALCOSTODOL, 
                         ME_Docproductos.TOTALCOSTOINVDOL, ME_Docproductos.IMPCOMBUSTIBLE, ME_Docproductos.CODVENPROD, ME_Docproductos.COMIVEN, ME_Docproductos.SOBREPRECIO, ME_Docproductos.CODREG, 
                         ME_Docproductos.NUMREG, ME_Docproductos.ITEMREG, ME_Docproductos.CANTIDADORIGINAL, ME_Docproductos.CANTIDADMODIFICADA, ME_Docproductos.NSERIETARJETA, ME_Docproductos.CODOC, 
                         ME_Docproductos.NUMOC, ME_Docproductos.PORTIMBREPRENSA, ME_Docproductos.VALORTIMBREPRENSA, ME_Docproductos.CODTIPODESCU, ME_Docproductos.TOTALPUNTOS, ME_Docproductos.ITEMOC, 
                         ME_Docproductos.CODPRODORIGEN, ME_Docproductos.CODMEDIDAORIGEN, ME_Docproductos.CANTIDADDEVUELTA, ME_Docproductos.CODARANCEL, ME_Docproductos.CODPRODLEECODIGO, 
                         ME_Docproductos.CANTIDADPIEZAS, ME_Docproductos.TIPOPRECIO
                        FROM ME_Docproductos RIGHT OUTER JOIN
                         ME_Documentos ON ME_Docproductos.CODSUCURSAL = ME_Documentos.CODSUCURSAL AND ME_Docproductos.DOC_ANO = ME_Documentos.DOC_ANO AND 
                         ME_Docproductos.DOC_NUMERO = ME_Documentos.DOC_NUMERO AND ME_Docproductos.CODDOC = ME_Documentos.CODDOC AND ME_Docproductos.EMP_NIT = ME_Documentos.EMP_NIT
                        WHERE (ME_Documentos.DOC_NUMORDEN = @E) AND (ME_Documentos.CODSUCURSAL = @S) AND (ME_Documentos.DOC_ESTATUS = 'I') AND (ME_Documentos.ISCENVIADO=0)
                        ORDER BY ME_Documentos.CODVEN, ME_Documentos.CODDOC,ME_Documentos.DOC_NUMERO", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@E", embarque)
                cmd.Parameters.AddWithValue("@ANIO", fecha.Year)
                cmd.Parameters.AddWithValue("@MES", fecha.Month)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cn As New SqlConnection(strHostConectionString)
                Dim bcCopy As New SqlBulkCopy(strHostConectionString)
                cn.Open()
                bcCopy.DestinationTableName = "DOCPRODUCTOS"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r



    End Function


    'actualiza el campo ISCENVIADO a valor 1 para señalar que ya se han generado estos pedidos
    Public Function setPedidosGenerados(ByVal sucursal As String, ByVal codven As Integer, ByVal embarque As String) As Boolean
        Dim r As Boolean
        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE ME_DOCUMENTOS SET ISCENVIADO=1 WHERE CODSUCURSAL=@S AND CODVEN=@V AND DOC_NUMORDEN=@E", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@V", codven)
                cmd.Parameters.AddWithValue("@E", embarque)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function


    'actualiza el campo ISCENVIADO a valor 1 para señalar que ya se han generado estos pedidos
    Public Function setPedidosGeneradosPicking(ByVal sucursal As String, ByVal embarque As String) As Boolean
        Dim r As Boolean
        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE ME_DOCUMENTOS SET ISCENVIADO=1 WHERE CODSUCURSAL=@S AND DOC_NUMORDEN=@E", cnh)
                cmd.Parameters.AddWithValue("@S", sucursal)
                cmd.Parameters.AddWithValue("@E", embarque)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function


    'GENERA FACTURA A PARTIR DEL PEDIDO
    Public Function changePedFac(ByVal coddoc As String, ByVal fechadoc As Date) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'primero recorre todos los pedidos pendientes de volver factura
                Dim cmds As New SqlCommand("SELECT CODDOC, CORRELATIVO 
                FROM TEMP_DOCUMENTOS 
                WHERE EMPNIT=@E  
                ORDER BY CORRELATIVO", cn)
                cmds.Parameters.AddWithValue("@E", GlobalEmpNit)

                Dim dr As SqlDataReader = cmds.ExecuteReader
                Do While dr.Read
                    'LUEGO VA CAMBIANDO DE UNO EN UNO
                    If setPedToFact(dr(0).ToString, Double.Parse(dr(1)), coddoc) = True Then
                        Form1.Mensaje(String.Format("Pedido Generado {0} - {1} ", dr(0).ToString, dr(1).ToString))
                    Else
                        Form1.Mensaje(String.Format("Error al generar {0} - {1} ", dr(0).ToString, dr(1).ToString))
                    End If
                Loop

                r = True

            Catch ex As Exception
                r = False
            End Try

        End Using


        Return r

    End Function



    Public Function getCorrelativoStr(ByVal correlativo As Double) As Double

        Return Double.Parse(correlativo)

        Exit Function

        Dim strcorrelativo As String = ""
        'MsgBox("total carateres: " & Strings.Len(correlativo.ToString))

        Select Case Strings.Len(correlativo.ToString)
            Case 1
                strcorrelativo = "         " & correlativo.ToString
            Case 2
                strcorrelativo = "        " & correlativo.ToString
            Case 3
                strcorrelativo = "       " & correlativo.ToString
            Case 4
                strcorrelativo = "      " & correlativo.ToString
            Case 5
                strcorrelativo = "     " & correlativo.ToString
            Case 6
                strcorrelativo = "    " & correlativo.ToString
            Case 7
                strcorrelativo = "   " & correlativo.ToString
            Case 8
                strcorrelativo = "  " & correlativo.ToString
            Case 9
                strcorrelativo = " " & correlativo.ToString
        End Select

        Return strcorrelativo

    End Function


    Public Function getCorrelativoStrISC(ByVal correlativo As Integer) As String

        Dim strcorrelativo As String = ""
        'MsgBox("total carateres: " & Strings.Len(correlativo.ToString))

        Select Case Strings.Len(correlativo.ToString)
            Case 1
                strcorrelativo = "         " & correlativo.ToString
            Case 2
                strcorrelativo = "        " & correlativo.ToString
            Case 3
                strcorrelativo = "       " & correlativo.ToString
            Case 4
                strcorrelativo = "      " & correlativo.ToString
            Case 5
                strcorrelativo = "     " & correlativo.ToString
            Case 6
                strcorrelativo = "    " & correlativo.ToString
            Case 7
                strcorrelativo = "   " & correlativo.ToString
            Case 8
                strcorrelativo = "  " & correlativo.ToString
            Case 9
                strcorrelativo = " " & correlativo.ToString
        End Select

        Return strcorrelativo

    End Function



    'CONVIERTE PEDIDOS EN FACTURAS
    Private Function setPedToFact(ByVal coddoc As String, ByVal correlativo As Double, ByVal codfac As String) As Boolean

        Dim r As Boolean
        Dim d As String
        Dim n As Double

        d = codfac

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'OBTIENE EL CORRELATIVO ACTUAL DE LA FACTURA
                Dim cmddoc As New SqlCommand("SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE CODDOC=@CODDOC", cn)
                cmddoc.Parameters.AddWithValue("@CODDOC", codfac)
                Dim dr As SqlDataReader = cmddoc.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    n = Double.Parse(dr(0))
                Else
                    n = 0
                End If
                dr.Close()


                If n = 0 Then
                    Return False
                End If

                'CAMBIA EL CORRELATIVO DE LA FACTURA ALOJADA EN LAS TABLAS TEMP
                Dim cmu As New SqlCommand("UPDATE TEMP_DOCUMENTOS 
                                            SET CODDOC=@D, CORRELATIVO=@N, STATUS='O' 
                                            WHERE EMPNIT=@E AND CODDOC=@PD AND CORRELATIVO=@PN; 
                                           
                                            UPDATE TEMP_DOCPRODUCTOS 
                                            SET CODDOC=@D, CORRELATIVO=@N 
                                            WHERE EMPNIT=@E AND CODDOC=@PD AND CORRELATIVO=@PN", cn)

                cmu.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmu.Parameters.AddWithValue("@D", d)
                cmu.Parameters.AddWithValue("@N", n)
                cmu.Parameters.AddWithValue("@PD", coddoc)
                cmu.Parameters.AddWithValue("@PN", correlativo)

                Dim i As Integer = cmu.ExecuteNonQuery

                '---------------------------------------------------------------------------
                'POR ULTIMO PASA EL DOCUMENTO A LA TABLA DOCUMENTOS-DOCPRODUCTOS
                '---------------------------------------------------------------------------

                'DE TABLA TEMP_DOCUMENTOS A TABLA DOCUMENTOS
                Dim cmfDoc As New SqlCommand("SELECT * FROM TEMP_DOCUMENTOS 
                            WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cn)
                cmfDoc.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmfDoc.Parameters.AddWithValue("@D", d)
                cmfDoc.Parameters.AddWithValue("@N", n)

                Dim tblD As New DataTable
                Dim daD As New SqlDataAdapter
                daD.SelectCommand = cmfDoc
                daD.Fill(tblD)

                Dim cnh As New SqlConnection(local)
                Dim bcCopy As New SqlBulkCopy(local)
                cnh.Open()
                bcCopy.DestinationTableName = "DOCUMENTOS"
                bcCopy.WriteToServer(tblD)

                'DE TABLA TEMP_DOCPRODUCTOS A TABLA DOCPRODUCTOS
                Dim cmfDocprod As New SqlCommand("SELECT * FROM TEMP_DOCPRODUCTOS 
                            WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cn)
                cmfDocprod.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmfDocprod.Parameters.AddWithValue("@D", d)
                cmfDocprod.Parameters.AddWithValue("@N", n)

                Dim tblDprod As New DataTable
                Dim daDprod As New SqlDataAdapter
                daDprod.SelectCommand = cmfDocprod
                daDprod.Fill(tblDprod)

                Dim bcCopyprod As New SqlBulkCopy(local)
                bcCopyprod.DestinationTableName = "DOCPRODUCTOS"
                bcCopyprod.WriteToServer(tblDprod)


                'ELIMINA EL DOCUMENTO DE LA TABLA TEMP_DOCUMENTOS/DOCPRODUCTOS
                Dim cmdel As New SqlCommand("DELETE FROM TEMP_DOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N;
                                            DELETE FROM TEMP_DOCPRODUCTOS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N;", cn)
                cmdel.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmdel.Parameters.AddWithValue("@D", d)
                cmdel.Parameters.AddWithValue("@N", n)

                cmdel.ExecuteNonQuery()

                '---------------------------------------------------------------------------
                '---------------------------------------------------------------------------

                r = True

            Catch ex As Exception
                MsgBox("ERROR AL CAMBIAR EL DOCUMENTO A FACTURA. " & ex.ToString)
                r = False
            End Try
        End Using

        If r = True Then
            'si el resultado es positivo, actualiza el correlativo del documento
            setCorrelativo(codfac, n)
        End If

        Return r
    End Function


    Private Function setCorrelativo(ByVal coddoc As String, ByVal correlativoactual As Double) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim c As New SqlCommand("UPDATE TIPODOCUMENTOS SET CORRELATIVO=@N WHERE CODDOC=@D", cn)
                c.Parameters.AddWithValue("@D", coddoc)
                c.Parameters.AddWithValue("@N", correlativoactual + 1)
                c.ExecuteNonQuery()

                r = True
            Catch ex As Exception
                r = False
            End Try
        End Using


        Return r
    End Function


#Region " ** LOCALES ** "

    Public Function tblEmbarquesLocales() As DataTable

        Dim tbl As New DataTable

        Using cnh As New SqlConnection(local)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODIGO AS CODEMBARQUE, NOMRUTA AS RUTA, CONCAT(CODIGO, ' - ', NOMRUTA) AS DESRUTA FROM EMBARQUES WHERE STATUS='PENDIENTE'", cnh)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                strError = ex.ToString
                tbl = Nothing
            End Try
        End Using

        Return tbl
    End Function

#End Region


#Region "*** MERCADOS EFECTIVOS APP *** "


#End Region



#Region " METODOS "


    Public Function delMarcas() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_MARCAS WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)
                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Public Function postMarcas() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPNIT AS EMP_NIT, CAST(CODMARCA AS VARCHAR) AS CODMARCA, DESMARCA, EMPNIT AS CODSUCURSAL FROM MARCAS WHERE EMPNIT=@S", cn)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.DestinationTableName = "ME_MARCAS"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Private Function delClaseUno() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_CLASEUNO WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)

                cmd.ExecuteNonQuery()
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Private Function postClaseUno() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT '1034261-3' AS EMP_NIT, CODCLAUNO, DESCLAUNO,  @S AS CODSUCURSAL FROM CLASIFICACIONUNO WHERE EMPNIT=@S", cn)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.DestinationTableName = "ME_CLASEUNO"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Private Function delClaseDos() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_CLASEDOS WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)

                cmd.ExecuteNonQuery()
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Private Function postClaseDos() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT '1034261-3' AS EMP_NIT, CODCLADOS, DESCLADOS,  @S AS CODSUCURSAL FROM CLASIFICACIONDOS WHERE EMPNIT=@S", cn)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.DestinationTableName = "ME_CLASEDOS"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Private Function delClaseTres() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_CLASETRES WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)
                cmd.ExecuteNonQuery()
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Private Function postClaseTres() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT '1034261-3' AS EMP_NIT, CODCLATRES, DESCLATRES,  @S AS CODSUCURSAL FROM CLASIFICACIONTRES WHERE EMPNIT=@S", cn)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.DestinationTableName = "ME_CLASETRES"
                bcCopy.WriteToServer(tbl)


                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function


    Public Function delProductosLocal() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_PRODUCTOS WHERE CODSUCURSAL=@S; 
                                            DELETE FROM ME_MARCAS WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)
                cmd.ExecuteNonQuery()
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Public Function postProductosLocal() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim qry As String

                qry = "SELECT 
                        PRODUCTOS.EMPNIT AS EMP_NIT, 
                        PRODUCTOS.CODPROD,
                        PRODUCTOS.DESPROD, 
                        'UNIDAD' AS CODMEDIDAINV, 
                        'UNIDAD' AS CODMEDIDACOM, 
                        CAST(PRODUCTOS.CODCLAUNO AS VARCHAR) AS CODCLAUNO, 
                        CAST(PRODUCTOS.CODCLADOS AS VARCHAR) AS CODCLADOS, 
                        CAST(PRODUCTOS.CODCLATRES AS VARCHAR) AS CODCLATRES,
                        CAST(PRODUCTOS.CODMARCA AS VARCHAR) AS CODMARCA,
                        PRODUCTOS.TIPOPROD, 
                        ISNULL(PRODUCTOS.COSTO,0) AS PRECIOMONEDA, 
                        PRODUCTOS.UXC AS EQUIVALEINV, 
                        PRODUCTOS.DESPROD2, 
                        PRODUCTOS.DESPROD3, 
                        PRODUCTOS.CODPROD2 AS CODPRODALTERNO, 
                        @F AS LASTSALE, 
                        @S AS CODSUCURSAL, 
                        @F AS LASTUPDATE, 
                        ISNULL(INVSALDO.SALDO,0) AS EXISTENCIA
                        FROM  PRODUCTOS LEFT OUTER JOIN
                        INVSALDO ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                        WHERE PRODUCTOS.EMPNIT=@S"

                Dim cmd As New SqlCommand(qry, cn)
                cmd.Parameters.AddWithValue("@F", Today.Date)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.DestinationTableName = "ME_PRODUCTOS"
                bcCopy.WriteToServer(tbl)
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Public Function delPreciosLocal() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_PRECIOS WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)
                cmd.ExecuteNonQuery()
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Public Function postPreciosLocal() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                                        EMPNIT AS EMP_NIT, 
                                        CODPROD, 
                                        CODMEDIDA, 
                                        EQUIVALE, 
                                        COSTO, 
                                        PRECIO, 
                                        MAYOREOC AS MAYORISTA, 
                                        MAYOREOB AS ESCALA, 
                                        MAYOREOA AS OFERTA, 
                                        PESO,  
                                        @S AS CODSUCURSAL, 
                                        @LU AS LASTUPDATE 
                                        FROM PRECIOS WHERE EMPNIT=@S", cn)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@LU", Today.Date)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.DestinationTableName = "ME_PRECIOS"
                bcCopy.WriteToServer(tbl)

                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function



    Public Function delClientes() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_CLIENTES WHERE CODSUCURSAL=@SUCURSAL; 
                                        DELETE FROM ME_MUNICIPIOS WHERE CODSUCURSAL=@SUCURSAL;
                                        DELETE FROM ME_DEPARTAMENTOS WHERE CODSUCURSAL=@SUCURSAL", cnh)
                cmd.Parameters.AddWithValue("@SUCURSAL", GlobalEmpNit)
                cmd.ExecuteNonQuery()
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Public Function postClientes() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CLIENTES.EMPNIT AS EMP_NIT, CLIENTES.CODCLIENTE AS NITCLIE, 0 AS CODCLIE, CONCAT(CLIENTES.TIPONEGOCIO, ' ', CLIENTES.NEGOCIO, ' - ', CLIENTES.NOMBRECLIENTE) AS NOMCLIE, CLIENTES.DIRCLIENTE AS DIRCLIE, ' ' AS ZONACLIE, 
                         CLIENTES.CODDEPARTAMENTO AS CODDEPTO, CLIENTES.CODMUNICIPIO AS CODMUNI, '' AS FAXCLIE, CLIENTES.TELEFONOCLIENTE AS TELCLIE, CLIENTES.EMAILCLIENTE AS EMAILCLIE, 
                         CLIENTES.CATEGORIA AS TIPOCLIE, @LU AS FECHAINGRESO, CLIENTES.NIT AS NITFACTURA, RUTAS.CODEMPLEADO AS CODVEN, CLIENTES.NEGOCIO AS NOMFAC, CLIENTES.LATITUDCLIENTE AS LATITUD, 
                         CLIENTES.LONGITUDCLIENTE AS LONGITUD, CLIENTES.DIAVISITA AS DAY, 0 AS noorden, CLIENTES.DIAVISITA AS VISITA, CLIENTES.LATITUDCLIENTE AS LATITUDCLIE, CLIENTES.LONGITUDCLIENTE AS LONGITUDCLIE, 
                         @E AS CODSUCURSAL, @LU AS LASTUPDATE
                    FROM CLIENTES LEFT OUTER JOIN
                         RUTAS ON CLIENTES.CODRUTA = RUTAS.CODRUTA AND CLIENTES.EMPNIT = RUTAS.EMPNIT
                    WHERE (CLIENTES.EMPNIT = @E)", cn)
                Dim f As Date = Today.Date.AddDays(-1)
                cmd.Parameters.AddWithValue("@LU", f) 'Date.Parse(f.Year.ToString + "-" + f.Month.ToString + "-" + (f.Day - 1)))
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)

                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                cmd.CommandTimeout = 0
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.BulkCopyTimeout = 0
                bcCopy.DestinationTableName = "ME_CLIENTES"
                bcCopy.WriteToServer(tbl)
                cnh.Close()
                '*****************************************************************************
                '*** MUNICIPIOS **********
                Dim cmdM As New SqlCommand("SELECT @E AS EMP_NIT, CAST(CODMUNICIPIO AS VARCHAR) AS CODMUNI, DESMUNICIPIO AS DESMUNI,0 AS PRIMERO, @E AS CODSUCURSAL FROM MUNICIPIOS ", cn)
                cmdM.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim tblM As New DataTable
                Dim daM As New SqlDataAdapter
                cmdM.CommandTimeout = 0
                daM.SelectCommand = cmdM
                daM.Fill(tblM)


                Dim bcCopyM As New SqlBulkCopy(host)
                cnh.Open()
                bcCopyM.BulkCopyTimeout = 0
                bcCopyM.DestinationTableName = "ME_MUNICIPIOS"
                bcCopyM.WriteToServer(tblM)
                cnh.Close()
                '*****************************************************************************
                '*** DEPARTAMENTOS **********
                Dim cmdD As New SqlCommand("SELECT @E AS EMP_NIT, CAST(CODDEPARTAMENTO AS VARCHAR) AS CODDEPTO, DESDEPARTAMENTO AS DESDEPTO,0 AS PRIMERO, @E AS CODSUCURSAL FROM DEPARTAMENTOS", cn)
                cmdD.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim tblD As New DataTable
                Dim daD As New SqlDataAdapter
                cmdD.CommandTimeout = 0
                daD.SelectCommand = cmdD
                daD.Fill(tblD)


                Dim bcCopyD As New SqlBulkCopy(host)
                cnh.Open()
                bcCopyD.BulkCopyTimeout = 0
                bcCopyD.DestinationTableName = "ME_DEPARTAMENTOS"
                bcCopyD.WriteToServer(tblD)
                cnh.Close()
                '*************************************************

                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function



    Public Function delEmbarques() As Boolean
        Dim r As Boolean

        Using cnh As New SqlConnection(host)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM ME_EMBARQUES WHERE CODSUCURSAL=@S", cnh)
                cmd.Parameters.AddWithValue("@S", GlobalEmpNit)
                cmd.ExecuteNonQuery()
                cnh.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function

    Public Function postEmbarques() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(local)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String
                sql = "SELECT 
                        0 AS NoEmbarque, 
                        EMPNIT AS EmpNit,
                        CODEMBARQUE AS Codigo,
                        ANIO AS Anio, 
                        MES AS Mes,
                        FECHA AS FechaCreado,
                        0 AS CodCamion, 
                        CODREP AS CodChofer, 
                        0 AS CodRuta,
                        DESCRIPCION AS NomRuta, 
                        'PENDIENTE' AS Status,
                        @E AS CODSUCURSAL, 
                        @LU AS LASTUPDATE 
                        FROM Embarques 
                        WHERE EMPNIT=@E AND FINALIZADO='NO' "

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@LU", Today.Date)
                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim cnh As New SqlConnection(host)
                Dim bcCopy As New SqlBulkCopy(host)
                cnh.Open()
                bcCopy.DestinationTableName = "ME_EMBARQUES"
                bcCopy.WriteToServer(tbl)

                cnh.Close()
                cn.Close()

                r = True

            Catch ex As Exception
                r = False
                MsgBox(ex.ToString)
            End Try
        End Using

        Return r
    End Function



#End Region



End Class
