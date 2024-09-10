
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI

Public Class classInvFisico

    Sub New(ByVal _empnit As String, ByVal _anioproceso As Integer, ByVal _mesproceso As Integer)

        empnit = _empnit
        anioproceso = _anioproceso
        mesproceso = _mesproceso

    End Sub

    Private empnit As String, anioproceso As Integer, mesproceso As Integer
    Public DesError As String = ""

    Public selected_codprod As String, selected_desprod As String, selected_codcosto As Double

    Public Function getContados(ByVal identificador As String) As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT        DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.NOSERIE AS MEDIDA, 
                         DOCPRODUCTOS.TOTALBONIF + DOCPRODUCTOS.TOTALUNIDADES * - 1 AS EXISTENCIA, DOCPRODUCTOS.TOTALBONIF AS TOTALUNSCONTADAS, DOCPRODUCTOS.CANTIDAD AS AJUSTE, DOCPRODUCTOS.OBS, 
                         PRECIOS.COSTO, PRECIOS.PRECIO
                    FROM            PRECIOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRECIOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRECIOS.CODMEDIDA = DOCPRODUCTOS.NOSERIE AND PRECIOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                         DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                    WHERE        (TIPODOCUMENTOS.TIPODOC = 'INF') AND (DOCUMENTOS.CODEMBARQUE = @ID)", cn)
                cmd.Parameters.AddWithValue("@ID", identificador)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using


        Return tbl

    End Function


    Public Function getNoContados(ByVal identificador As String) As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODIGO", GetType(String))
            .Add("PRODUCTO", GetType(String))
            .Add("EXISTENCIA", GetType(Double))
            .Add("HABILITADO", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT        PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, INVSALDO.SALDO AS EXISTENCIA, PRODUCTOS.HABILITADO 
                                FROM            PRODUCTOS LEFT OUTER JOIN
                                        INVSALDO ON PRODUCTOS.CODPROD = INVSALDO.CODPROD AND PRODUCTOS.EMPNIT = INVSALDO.EMPNIT
                                WHERE        (PRODUCTOS.EMPNIT = @E) AND (INVSALDO.SALDO <> 0)", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    If getCodprodInvfisico(dr(0).ToString, identificador) = True Then

                    Else
                        tbl.Rows.Add(New Object() {dr(0).ToString, dr(1).ToString, Double.Parse(dr(2)), dr(3).ToString})
                    End If

                Loop


            Catch ex As Exception
                MsgBox("Error al cargar NO CONTADOS. Error: " + ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using


        Return tbl
    End Function


    Private Function getCodprodInvfisico(ByVal codprod As String, ByVal identificador As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT  DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, 
                         DOCPRODUCTOS.TOTALBONIF + DOCPRODUCTOS.TOTALUNIDADES * - 1 AS EXISTENCIA, DOCPRODUCTOS.TOTALBONIF AS TOTALUNSCONTADAS, DOCPRODUCTOS.CANTIDAD AS AJUSTE, DOCPRODUCTOS.OBS
                FROM            DOCPRODUCTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND 
                         DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                WHERE        (DOCUMENTOS.EMPNIT=@E) AND (TIPODOCUMENTOS.TIPODOC = 'INF') AND (DOCUMENTOS.CODEMBARQUE = @ID) AND (DOCPRODUCTOS.CODPROD = @CODPROD)", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@ID", identificador)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using


        Return r
    End Function

    Public Function InsertDocument(ByVal fecha As Date, ByVal coddoc As String, ByVal correlativo As Double, ByVal codven As Integer, ByVal obs As String, ByVal identificador As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'INSERTA EL REGISTRO EN LA TABLA DOCUMENTOS

                'EL CAMPO CODEMBARQUE, SERÁ UTILIZADO PARA INSERTAR EL IDENTIFICADOR DE INVENTARIO
                'EL IDENTIFICADOR SERVIRÁ PARA PODER AGRUPAR TODOS LOS DOCUMENTOS DE INVENTARIO FÍSICO
                'RELATIVOS A UN INVENTARIO EN EL NEGOCIO
                Dim qry1 As String = "INSERT INTO DOCUMENTOS 
                (EMPNIT,ANIO,MES,DIA,FECHA,HORA,MINUTO,	CODDOC,CORRELATIVO,CODCLIENTE,DOC_NIT,DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,TOTALPRECIO,CODEMBARQUE,STATUS,CONCRE,USUARIO,CORTE,SERIEFAC,NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_ABONO, DOC_SALDO,TOTALTARJETA, RECARGOTARJETA,CODREP,TOTALEXENTO,DIRENTREGA) 
				    VALUES
				(@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,@CODDOC,@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,@DIRECCION,@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',@CONCRE,@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,(@PAGO-@TOTALPRECIO),'NO',@OBS,@ABONO,@SALDO,@PAGOTARJETA,@RECARGOTARJETA,@CODREP,@TOTALEXENTO,@DIRENTREGA)"

                Dim cmd As New SqlCommand(qry1, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", fecha.Year)
                cmd.Parameters.AddWithValue("@MES", fecha.Month)
                cmd.Parameters.AddWithValue("@DIA", fecha.Day)
                cmd.Parameters.AddWithValue("@FECHA", fecha)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@CODCLIENTE", 0)
                cmd.Parameters.AddWithValue("@NIT", "SN")
                cmd.Parameters.AddWithValue("@NOMBRE", "INVENTARIO FISICO")
                cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                cmd.Parameters.AddWithValue("@TOTALCOSTO", 0)
                cmd.Parameters.AddWithValue("@TOTALPRECIO", 0)
                cmd.Parameters.AddWithValue("@TOTALEXENTO", 0)
                cmd.Parameters.AddWithValue("@CODEMBARQUE", identificador)
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@NOFAC", correlativo)
                cmd.Parameters.AddWithValue("@CODVEN", codven)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.Parameters.AddWithValue("@DIRENTREGA", "CIUDAD")
                cmd.Parameters.AddWithValue("@SERIEFAC", coddoc)
                cmd.Parameters.AddWithValue("@PAGO", 0)
                cmd.Parameters.AddWithValue("@PAGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@RECARGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@CONCRE", "CON")
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@ABONO", 0)
                cmd.Parameters.AddWithValue("@CODREP", DBNull.Value)
                Dim i = cmd.ExecuteNonQuery()
                If i = 1 Then
                    'INSERTA EL REGISTRO EN LA TABLA DOCPRODUCTOS

                    Dim qry As String = "INSERT INTO DOCPRODUCTOS 
                (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,
				    ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF,NOSERIE,EXENTO,OBS) 
	            SELECT EMPNIT,@ANIO AS ANIO, @MES AS MES,@DIA AS DIA, CODDOC,CORRELATIVO, CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,
				    TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALUNIDADES,TOTALCOSTO,TOTALPRECIO,COSTO,COSTO,BONIF,TOTALBONIF,NOSERIE,EXENTO,OBS 
	            FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND USUARIO=@USUARIO AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO"

                    Dim cmd2 As New SqlCommand(qry, cn)
                    cmd2.Parameters.AddWithValue("@EMPNIT", empnit)
                    cmd2.Parameters.AddWithValue("@ANIO", fecha.Year)
                    cmd2.Parameters.AddWithValue("@MES", fecha.Month)
                    cmd2.Parameters.AddWithValue("@DIA", fecha.Day)
                    cmd2.Parameters.AddWithValue("@CODDOC", coddoc)
                    cmd2.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                    cmd2.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                    Dim b = cmd2.ExecuteNonQuery()
                    If b > 0 Then
                        r = True
                    Else
                        MsgBox("No se logró guardar el detalle del documento, inténtelo de nuevo")
                    End If
                Else
                    r = False
                End If


            Catch ex As Exception
                r = False
                DesError = ex.ToString
            End Try
        End Using

        Return r

    End Function


    ''' <summary>
    ''' OBTIENE LOS DATOS DE TEMP VENTAS PARA EL GRID DE PRODUCTOS AGREGADOS
    ''' </summary>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <returns></returns>
    Public Function tblGridTemp(ByVal coddoc As String, ByVal correlativo As Double) As DataTable
        Dim tbl As New DataSetInventarios.tblTempInvFisicoDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD,DESPROD,CODMEDIDA,BONIF AS CONTEO, COSTO, TOTALCOSTO, CANTIDAD AS AJUSTE,PRECIO,TOTALPRECIO,OBS FROM TEMP_VENTAS WHERE EMPNIT=@E AND CODDOC=@C AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        Return tbl
    End Function

    ''' <summary>
    ''' BORRA EL GRID DE UN DOCUMENTO ESPECIFICO
    ''' </summary>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <returns></returns>
    Public Function DeleteGridTemp(ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim r As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE EMPNIT=@E AND CODDOC=@C AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                DesError = ex.ToString
            End Try
        End Using

        Return r
    End Function


    ''' <summary>
    ''' BORRA UN PRODUCTO DE TEMP VENTAS
    ''' </summary>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <param name="codprod"></param>
    ''' <returns></returns>
    Public Function DeleteProdGridTemp(ByVal coddoc As String, ByVal correlativo As Double, ByVal codprod As String) As Boolean
        Dim r As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N AND CODPROD=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                cmd.Parameters.AddWithValue("@C", codprod)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                DesError = ex.ToString
            End Try
        End Using

        Return r
    End Function

    ''' <summary>
    ''' VERIFICA SI EXISTE EL CODIGO DE PRODUCTO
    ''' </summary>
    ''' <param name="codprod"></param>
    ''' <returns></returns>
    Public Function existeProducto(ByVal codprod As String) As Boolean
        selected_codprod = ""
        selected_desprod = ""
        selected_codcosto = 0

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, COSTO FROM PRODUCTOS WHERE EMPNIT=@E AND CODPROD=@C AND HABILITADO='SI' OR EMPNIT=@E AND CODPROD2=@C AND HABILITADO='SI'", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    r = True
                    selected_codprod = dr(0).ToString
                    selected_desprod = dr(1).ToString
                    selected_codcosto = CType(dr(2), Double)
                Else
                    r = False
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                DesError = ex.ToString
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using

        Return r
    End Function

    ''' <summary>
    ''' VERIFICA SI EXISTE EL PRODUCTO EN EL GRID
    ''' </summary>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <param name="codprod"></param>
    ''' <returns></returns>
    Public Function existeProductoGrid(ByVal coddoc As String, ByVal correlativo As Double, ByVal codprod As String) As Boolean

        Dim r As Boolean
        'Return False

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT TEMP_VENTAS.CODPROD
                                    FROM TEMP_VENTAS LEFT OUTER JOIN TIPODOCUMENTOS ON TEMP_VENTAS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND TEMP_VENTAS.CODDOC = TIPODOCUMENTOS.CODDOC
                                    WHERE (TEMP_VENTAS.CODPROD = @C) AND (TIPODOCUMENTOS.TIPODOC = 'INF') AND (TEMP_VENTAS.EMPNIT = @E)", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codprod)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    r = True
                Else
                    r = False
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                DesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function


    ''' <summary>
    ''' OBTIENE LA TABLA DE PRODUCTOS CON INVENTARIO SEGUN BUSQUEDA
    ''' </summary>
    ''' <param name="descripcion"></param>
    ''' <returns>DATATABLE</returns>
    Public Function tblProductos(ByVal descripcion As String) As DataTable
        Dim tbl As New DataSetInventarios.tblProductosInvFisicoDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT        PRODUCTOS.CODPROD, PRODUCTOS.CODPROD2, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.COSTO, MARCAS.DESMARCA, CLASIFICACIONUNO.DESCLAUNO, INVSALDO.SALDO
FROM            PRODUCTOS LEFT OUTER JOIN
                         CLASIFICACIONUNO ON PRODUCTOS.CODCLAUNO = CLASIFICACIONUNO.CODCLAUNO AND PRODUCTOS.EMPNIT = CLASIFICACIONUNO.EMPNIT LEFT OUTER JOIN
                         MARCAS ON PRODUCTOS.CODMARCA = MARCAS.CODMARCA AND PRODUCTOS.EMPNIT = MARCAS.EMPNIT LEFT OUTER JOIN
                         INVSALDO ON PRODUCTOS.CODPROD = INVSALDO.CODPROD AND PRODUCTOS.EMPNIT = INVSALDO.EMPNIT
WHERE        (PRODUCTOS.EMPNIT = @EMPNIT) AND (PRODUCTOS.DESPROD LIKE @F) AND (PRODUCTOS.HABILITADO = 'SI')  AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES) ", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anioproceso)
                cmd.Parameters.AddWithValue("@MES", mesproceso)
                cmd.Parameters.AddWithValue("@F", "%" + descripcion + "%")

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                DesError = ex.ToString
                MsgBox(ex.ToString)
            End Try

        End Using

        Return tbl

    End Function

    ''' <summary>
    ''' INSERTA EL REGISTRO EN LA TABLA TEMP VENTAS PARA LUEGO HACER LOS AJUSTES
    ''' </summary>
    ''' <param name="codprod"></param>
    ''' <param name="conteo"></param>
    ''' <returns></returns>
    Public Function insertConteo(ByVal coddoc As String, ByVal correlativo As Double, ByVal codprod As String, ByVal desprod As String, ByVal codmedida As String, ByVal conteo As Double, ByVal costoun As Double, ByVal obs As String, ByVal codmedidareal As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim existencia As Double = 0
                Dim ajuste As Double = 0

                'OBTENGO LA EXISTENCIA DEL PRODUCTO EN CUESTION
                Dim c As New SqlCommand("SELECT SALDO FROM INVSALDO WHERE EMPNIT=@E AND CODPROD=@C AND ANIO=@A AND MES=@M", cn)
                c.Parameters.AddWithValue("@E", empnit)
                c.Parameters.AddWithValue("@C", codprod)
                c.Parameters.AddWithValue("@A", anioproceso)
                c.Parameters.AddWithValue("@M", mesproceso)
                Dim d As SqlDataReader = c.ExecuteReader
                d.Read()
                If d.HasRows Then
                    existencia = CType(d(0), Double)
                End If
                d.Close()
                c.Dispose()

                'calcula el ajuste a realizar según la existencia actual en sistema
                ajuste = conteo - existencia


                'INSERTA EL REGISTRO EN TEMP-VENTAS
                Dim sql As String
                sql = "INSERT INTO TEMP_VENTAS 
                (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,BONIF,TOTALBONIF,USUARIO,OBS,NOSERIE)
         VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,1,@CANTIDAD,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@BONIF,@TOTALBONIF,@USUARIO,@OBS,@MEDIDAREAL)"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@DESPROD", desprod)
                cmd.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                cmd.Parameters.AddWithValue("@CANTIDAD", ajuste) 'valor a ajustar
                cmd.Parameters.AddWithValue("@TOTALUNIDADES", ajuste) 'valor a ajustar
                cmd.Parameters.AddWithValue("@COSTO", costoun)
                cmd.Parameters.AddWithValue("@PRECIO", costoun)
                cmd.Parameters.AddWithValue("@TOTALCOSTO", costoun * ajuste)
                cmd.Parameters.AddWithValue("@TOTALPRECIO", costoun * conteo)
                cmd.Parameters.AddWithValue("@BONIF", conteo) 'conteo
                cmd.Parameters.AddWithValue("@TOTALBONIF", conteo) 'conteo
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.Parameters.AddWithValue("@MEDIDAREAL", codmedidareal)


                Dim i As Integer = cmd.ExecuteNonQuery
                If i = 1 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                r = False
                DesError = ex.ToString
            End Try
        End Using

        Return r

    End Function


    Public Function rptInvFisico(ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim r As Boolean

        Dim tbl As New DataSetInventarios.tblTempInvFisicoDataTable


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql2 As String = "SELECT DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, DOCPRODUCTOS.CANTIDADBONIF AS CONTEO, DOCPRODUCTOS.COSTO, DOCPRODUCTOS.TOTALCOSTO, 
                            DOCPRODUCTOS.CANTIDAD AS AJUSTE, DOCPRODUCTOS.PRECIO, DOCPRODUCTOS.TOTALPRECIO, DOCPRODUCTOS.OBS, DOCUMENTOS.OBS AS OBSDOC, EMPLEADOS.NOMEMPLEADO AS NOMEMP, 
                            DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, (DOCPRODUCTOS.CANTIDADBONIF - DOCPRODUCTOS.CANTIDAD) AS SALDO
                        FROM DOCUMENTOS LEFT OUTER JOIN
                            EMPLEADOS ON DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO AND DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT LEFT OUTER JOIN
                            DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.DIA = DOCPRODUCTOS.DIA AND 
                            DOCUMENTOS.MES = DOCPRODUCTOS.MES AND DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODDOC = @D) AND (DOCUMENTOS.CORRELATIVO = @N)"

                Dim sql As String = "SELECT        PRODUCTOS.CODPROD, PRODUCTOS.DESPROD, ISNULL(DOCPRODUCTOS.CODMEDIDA, 'NOINV') AS CODMEDIDA, DOCPRODUCTOS.CANTIDADBONIF AS CONTEO, DOCPRODUCTOS.COSTO, DOCPRODUCTOS.TOTALCOSTO, 
                         DOCPRODUCTOS.CANTIDAD AS AJUSTE, DOCPRODUCTOS.PRECIO, DOCPRODUCTOS.TOTALPRECIO, DOCPRODUCTOS.OBS, DOCUMENTOS.OBS AS OBSDOC, EMPLEADOS.NOMEMPLEADO AS NOMEMP, 
                         DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCPRODUCTOS.CANTIDADBONIF - DOCPRODUCTOS.CANTIDAD AS SALDO
FROM            PRODUCTOS LEFT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO AND DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND 
                         DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.DIA = DOCUMENTOS.DIA AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND 
                         DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
WHERE        (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODDOC = @D) AND (DOCUMENTOS.CORRELATIVO = @N)"

                Dim cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception

                tbl = Nothing

            End Try
        End Using




        Dim Adapter As New SqlDataAdapter
        Dim report As New rptInvFisico

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblTempInvFisico"

        Dim tool As ReportPrintTool = New ReportPrintTool(report)

        report.CreateDocument()

        report.ShowPreview

        Return r

    End Function

End Class
