﻿Public Class classQuerys

    Public Function queryTicket() As String

        Dim sql As String = "SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, 
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
                         (DOCUMENTOS.CORRELATIVO = @CORRELATIVO)"

        Return sql

    End Function

    Public Function queryRptClaseUno() As String
        Return "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.FECHA, DOCUMENTOS.STATUS, DOCPRODUCTOS.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, 
                         DOCPRODUCTOS.TOTALUNIDADES, DOCPRODUCTOS.TOTALCOSTO, DOCPRODUCTOS.TOTALPRECIO
                FROM    CLASIFICACIONUNO RIGHT OUTER JOIN
                         PRODUCTOS ON CLASIFICACIONUNO.CODCLAUNO = PRODUCTOS.CODCLAUNO AND CLASIFICACIONUNO.EMPNIT = PRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
                WHERE (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (DOCUMENTOS.STATUS <> 'A') AND (PRODUCTOS.CODCLAUNO = @C)"

    End Function

    Public Function queryTempReciboPago() As String

        Return "SELECT EMPRESAS.EMPNOMBRE, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, VENDEDORES.NOMVEN, DOCUMENTOS.USUARIO, DOCUMENTOS.SERIEFAC, DOCUMENTOS.NOFAC, 
                         DOCUMENTOS.TOTALPRECIO, ISNULL(DOCUMENTOS.OBS,'SN') AS OBS, ISNULL(DOCUMENTOS.TIPOPAGO,'SN') AS TIPOPAGO, ISNULL(DOCUMENTOS.NODOCPAGO,'SN') AS NODOCPAGO, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIE, DOC_SALDO AS SALDO, PAGO, VUELTO
                FROM     DOCUMENTOS LEFT OUTER JOIN
                         VENDEDORES ON DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT AND DOCUMENTOS.CODVEN = VENDEDORES.CODVEN LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                         EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT    
                WHERE   (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.CODDOC = @CODDOC) AND (DOCUMENTOS.CORRELATIVO = @CORRELATIVO)"

    End Function

    Public Function queryReciboPago() As String
        Dim sql As String
        sql = "INSERT INTO DOCUMENTOS 
	            (EMPNIT,ANIO,MES,DIA,FECHA,HORA,
	            MINUTO,CODDOC,CORRELATIVO,CODCLIENTE,
	            DOC_NIT,DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,
	            TOTALPRECIO,CODEMBARQUE,STATUS,CONCRE,USUARIO,
	            CORTE,SERIEFAC,NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_SALDO,DOC_ABONO,TIPOPAGO,NODOCPAGO) 
	        VALUES
	            (@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,
	            @CODDOC,@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,
	            @DIRECCION,@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',
	            @CONCRE,@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,(@PAGO-@TOTALPRECIO),'NO',@OBS,@SALDO,@ABONO,@TIPOPAGO,@NODOCPAGO);
            UPDATE DOCUMENTOS SET DOC_SALDO=@SALDO, DOC_ABONO=@ABONO,'SN','SN' WHERE EMPNIT=@EMPNIT AND CODDOC=@SERIEFAC AND CORRELATIVO=@NOFAC"

        Return sql

    End Function

    Public Function queryReciboPagoProveedor() As String
        Dim sql As String
        sql = "INSERT INTO DOCUMENTOS 
	            (EMPNIT,ANIO,MES,DIA,FECHA,HORA,
	            MINUTO,CODDOC,CORRELATIVO,CODCLIENTE,
	            DOC_NIT,DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,
	            TOTALPRECIO,CODEMBARQUE,STATUS,CONCRE,USUARIO,
	            CORTE,SERIEFAC,NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_SALDO,DOC_ABONO,TIPOPAGO,NODOCPAGO) 
	        VALUES
	            (@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,
	            @CODDOC,@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,
	            @DIRECCION,@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',
	            @CONCRE,@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,(@PAGO-@TOTALPRECIO),'NO',@OBS,@SALDO,@ABONO,@TIPOPAGO,@NODOCPAGO);
            UPDATE DOCUMENTOS SET DOC_SALDO=@SALDO, DOC_ABONO=@ABONO WHERE EMPNIT=@EMPNIT AND CODDOC=@SERIEFAC AND CORRELATIVO=@NOFAC"

        Return sql

    End Function

    Public Function querySqlNuevaEmpresa() As String
        Dim sql As String

        sql = "INSERT INTO TIPODOCUMENTOS (EMPNIT,CODDOC,CORRELATIVO,DESDOC,TIPODOC,ACTIVO) 
                SELECT @EMPNIT,CODDOC,CORRELATIVO,DESDOC,TIPODOC,'SI' AS ACTIVO FROM PLANTILLA_TIPODOCUMENTOS;
	                                            INSERT INTO MEDIDAS(EMPNIT,CODMEDIDA,TIPOPRECIO) VALUES (@EMPNIT,'UNIDAD','DETALLE');
	                                            INSERT INTO MARCAS(EMPNIT,CODMARCA,DESMARCA) VALUES (@EMPNIT,1,'NO DEFINIDO');
	                                            INSERT INTO CLASIFICACIONUNO(EMPNIT,CODCLAUNO,DESCLAUNO) VALUES (@EMPNIT,1,'NO DEFINIDO');
	                                            INSERT INTO CLASIFICACIONDOS(EMPNIT,CODCLADOS,DESCLADOS) VALUES (@EMPNIT,1,'NO DEFINIDO');
	                                            INSERT INTO CLASIFICACIONTRES(EMPNIT,CODCLATRES,DESCLATRES) VALUES (@EMPNIT,1,'NO DEFINIDO');
	                                            INSERT INTO CAJAS (EMPNIT,CODCAJA,DESCAJA,EFECTIVOLIMITE,EFECTIVOINICIAL) VALUES (@EMPNIT,1,'CAJA GENERAL',0,0);
	                                            INSERT INTO BODEGAS (EMPNIT,CODBODEGA,DESBODEGA,ENCARGADO,DIRBODEGA) VALUES (@EMPNIT,1,'BODEGA GENERAL','SN','CIUDAD');
	                                            INSERT INTO RUTAS (EMPNIT,CODRUTA,DESRUTA,RUTEO) VALUES (@EMPNIT,1,'GENERAL','GENERAL');
                                                INSERT INTO EMPLEADOS (EMPNIT,CODTIPOEMPLEADO,NOMEMPLEADO,DIRECCION,CODMUNICIPIO,CODDEPTO,ACTIVO,CLAVE) VALUES (@EMPNIT,3,'TIENDA','CIUDAD',1,1,'SI','123');"
        Return sql
    End Function



    Public Function queryRptGeneral() As String
        Dim sql, sql2 As String

        sql = "SELECT        TIPODOCUMENTOS.TIPODOC, DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.HORA, DOCUMENTOS.CODCLIENTE, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                         DOCUMENTOS.MINUTO, DOCPRODUCTOS.CODPROD, PRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, DOCPRODUCTOS.CANTIDAD, DOCPRODUCTOS.TOTALUNIDADES, DOCPRODUCTOS.COSTO, 
                         DOCPRODUCTOS.PRECIO, DOCPRODUCTOS.TOTALCOSTO, DOCPRODUCTOS.TOTALPRECIO, DOCPRODUCTOS.TOTALPRECIO - DOCPRODUCTOS.TOTALCOSTO AS UTILIDADQ, 
                         CASE DOCPRODUCTOS.TOTALCOSTO WHEN 0 THEN 0 ELSE ((DOCPRODUCTOS.TOTALPRECIO - DOCPRODUCTOS.TOTALCOSTO) / DOCPRODUCTOS.TOTALCOSTO) * 100 END AS UTILIDADPOC, 
						 PRECIOS.PESO, (ISNULL(PRECIOS.PESO,0) * DOCPRODUCTOS.CANTIDAD) AS TOTALPESO,
                         PRODUCTOS.CODMARCA, MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLATRES, CLASIFICACIONTRES.DESCLATRES, EMPLEADOS.NOMEMPLEADO, 
                         DOCUMENTOS.OBS, DOCUMENTOS.CONCRE
                FROM            PRECIOS RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRECIOS.CODMEDIDA = DOCPRODUCTOS.CODMEDIDA AND PRECIOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRECIOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                         MARCAS RIGHT OUTER JOIN
                         CLASIFICACIONUNO RIGHT OUTER JOIN
                         PRODUCTOS LEFT OUTER JOIN
                         CLASIFICACIONTRES ON PRODUCTOS.CODCLATRES = CLASIFICACIONTRES.CODCLATRES AND PRODUCTOS.EMPNIT = CLASIFICACIONTRES.EMPNIT ON CLASIFICACIONUNO.CODCLAUNO = PRODUCTOS.CODCLAUNO AND 
                         CLASIFICACIONUNO.EMPNIT = PRODUCTOS.EMPNIT ON MARCAS.CODMARCA = PRODUCTOS.CODMARCA AND MARCAS.EMPNIT = PRODUCTOS.EMPNIT ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND 
                         DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND 
                         DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
                WHERE        (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC','FEF','FEC','FES', 'DEV','FNC')) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL)"


        sql2 = "SELECT        TIPODOCUMENTOS.TIPODOC, DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.HORA, DOCUMENTOS.CODCLIENTE, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                         DOCUMENTOS.MINUTO, DOCPRODUCTOS.CODPROD, PRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, DOCPRODUCTOS.CANTIDAD, DOCPRODUCTOS.TOTALUNIDADES, DOCPRODUCTOS.COSTO, 
                         DOCPRODUCTOS.PRECIO, DOCPRODUCTOS.TOTALCOSTO, DOCPRODUCTOS.TOTALPRECIO, DOCPRODUCTOS.TOTALPRECIO - DOCPRODUCTOS.TOTALCOSTO AS UTILIDADQ, 
                         CASE DOCPRODUCTOS.TOTALCOSTO WHEN 0 THEN 0 ELSE ((DOCPRODUCTOS.TOTALPRECIO - DOCPRODUCTOS.TOTALCOSTO) / DOCPRODUCTOS.TOTALCOSTO) * 100 END AS UTILIDADPOC, PRODUCTOS.CODMARCA, 
                         MARCAS.DESMARCA, PRODUCTOS.CODCLAUNO, CLASIFICACIONUNO.DESCLAUNO, PRODUCTOS.CODCLATRES, 
                         CLASIFICACIONTRES.DESCLATRES,EMPLEADOS.NOMEMPLEADO, DOCUMENTOS.OBS, DOCUMENTOS.CONCRE 
FROM            MARCAS RIGHT OUTER JOIN
                         CLASIFICACIONUNO RIGHT OUTER JOIN
                         PRODUCTOS LEFT OUTER JOIN
                         CLASIFICACIONTRES ON PRODUCTOS.CODCLATRES = CLASIFICACIONTRES.CODCLATRES AND PRODUCTOS.EMPNIT = CLASIFICACIONTRES.EMPNIT ON CLASIFICACIONUNO.CODCLAUNO = PRODUCTOS.CODCLAUNO AND 
                         CLASIFICACIONUNO.EMPNIT = PRODUCTOS.EMPNIT ON MARCAS.CODMARCA = PRODUCTOS.CODMARCA AND MARCAS.EMPNIT = PRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCPRODUCTOS ON PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT RIGHT OUTER JOIN
                         DOCUMENTOS LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS.CODVEN = EMPLEADOS.CODEMPLEADO LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND 
                         DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.MES = DOCUMENTOS.MES AND DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
WHERE        (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'DEV')) AND (DOCUMENTOS.FECHA BETWEEN @FECHAINICIAL AND @FECHAFINAL)"




        Return sql

    End Function


End Class
