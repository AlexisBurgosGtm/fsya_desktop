
Imports conectorfelv2

Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports System.IO
Imports System.Net



Public Class classFEL

    Sub New()

        Call CargarDatosClienteFEL()

    End Sub


    Public Property GlobalCodigoEstablecimientoEmisor As Integer = 1
    Public Property GlobalCorreoEmisor As String = ""
    Public Property GlobalNitEmisor As String = ""
    Public Property GlobalNombreEmisor As String = ""
    Public Property GlobalNombreComercialEmisor As String = ""
    Public Property GlobalDepartamentoEmisor As String = ""
    Public Property GlobalMunicipioEmisor As String = ""
    Public Property GlobalDireccionEmisor As String = ""
    Public Property GlobalCodigoPostalEmmisor As String = ""

    Public Property GlobalCertificacionUsuario As String = ""
    Public Property GlobalCertificacionLlave As String = ""
    Public Property GlobalFirmaAlias As String = ""
    Public Property GlobalFirmaLlave As String = ""
    Public Property GlobalFraseFEL As Integer = 1
    Public Property GlobalEscenarioFEL As Integer = 1


    Private Sub CargarDatosClienteFEL()

        Try

            GlobalCodigoEstablecimientoEmisor = Integer.Parse(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_CODIGOESTABLECIMIENTO", Nothing))
            GlobalCorreoEmisor = ""
            GlobalNitEmisor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_NIT", Nothing).ToString
            GlobalNombreEmisor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_NOMBRE", Nothing).ToString
            GlobalNombreComercialEmisor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_NOMBRECOMECIAL", Nothing).ToString
            GlobalDepartamentoEmisor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_DEPARTAMENTO", Nothing).ToString
            GlobalMunicipioEmisor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_MUNICIPIO", Nothing).ToString
            GlobalDireccionEmisor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_DIRECCION", Nothing).ToString
            GlobalCodigoPostalEmmisor = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_CODIGOPOSTAL", Nothing).ToString
            GlobalCertificacionUsuario = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "CERTIFICACION_USUARIO", Nothing).ToString
            GlobalCertificacionLlave = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "CERTIFICACION_LLAVE", Nothing).ToString
            GlobalFirmaAlias = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "FIRMA_ALIAS", Nothing).ToString
            GlobalFirmaLlave = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "FIRMA_LLAVE", Nothing).ToString

            GlobalFraseFEL = CType(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_FRASE", Nothing).ToString, Integer)
            GlobalEscenarioFEL = CType(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_ESCENARIO", Nothing).ToString, Integer)

        Catch ex As Exception
            Form1.Mensaje("No hay credenciales de facturación electronica")
        End Try

        Exit Sub


    End Sub

    Public Function getDataNIT(ByVal nit As String) As Boolean

        Dim r As Boolean

        Dim wc As WebClient
        wc = New WebClient

        Try
            Dim res As Boolean

            res = wc.DownloadString("http://localhost:56590/Home/ValidName?LastName=Vogel")
            If res Then
                '...work with result...
            End If
        Catch ex As Exception
            '...handle error...
        End Try


        Return r

    End Function




    Public Function cleanNitCliente(ByVal nit As String) As String
        Dim n As String = ""

        n = Strings.Replace(nit, "-", "")
        n = Strings.Replace(nit, " ", "")
        n = n.ToUpper

        Return n

    End Function


    'FACTURA IVA NORMAL
    Public Function facturaIVA_Normal(ByVal fechahora As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal NitCliente As String, ByVal NombreCliente As String, ByVal EmailCliente As String,
                                         ByVal DireccionCliente As String, ByVal DepartamentoCliente As String, ByVal MunicipioCliente As String) As Boolean

        Dim r As Boolean

        Dim CodigoUnicoDocumento As String = String.Format("{0}-{1}-{2}", GlobalEmpNit, coddoc, correlativo.ToString)

        Dim NIT As String = cleanNitCliente(NitCliente)


        Dim request As RequestCertificacionFel
        request = New RequestCertificacionFel

        'ENCABEZADO DE LA FACTURA
        request.Datos_generales("GTQ", fechahora, "FACT", "", "", "")
        request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, GlobalNombreEmisor, GlobalNombreComercialEmisor)


        request.Datos_receptor(NIT, NombreCliente, getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, DireccionCliente, "")

        'FRASES QUE LLEVA LA FACTURA / SUJETO A PAGOS TRIMESTRALES
        request.Frases(1, 1, "", "")
        'request.Frases(GlobalFraseFEL, GlobalEscenarioFEL, "", "")

        Dim varTotalVenta As Double = 0
        Dim varTotalIva As Double = 0
        Dim varItem As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                                            DOCPRODUCTOS.CODPROD, 
                                            DOCPRODUCTOS.DESPROD, 
                                            DOCPRODUCTOS.CODMEDIDA, 
                                            DOCPRODUCTOS.CANTIDAD, 
                                            DOCPRODUCTOS.EQUIVALE, 
                                            DOCPRODUCTOS.TOTALUNIDADES, 
                                            DOCPRODUCTOS.COSTO, 
                                            DOCPRODUCTOS.PRECIO, 
                                            DOCPRODUCTOS.TOTALCOSTO, 
                                            DOCPRODUCTOS.TOTALPRECIO, 
                                            CASE PRODUCTOS.TIPOPROD WHEN 'S' THEN 'S' ELSE 'B' END AS TIPOPROD, 
                                            DOCPRODUCTOS.TOTALIVA, 
                                            DOCPRODUCTOS.TOTALSINIVA,
                                            PRODUCTOS.EXENTO
                                        FROM  DOCPRODUCTOS LEFT OUTER JOIN
                                        PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT
                                        WHERE (DOCPRODUCTOS.EMPNIT = @E) AND (DOCPRODUCTOS.CODDOC = @D) AND (DOCPRODUCTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    varTotalVenta = varTotalVenta + CType(dr(9), Double)
                    varItem = varItem + 1

                    Dim tipoprod As String = dr(10).ToString
                    Dim medida As String = "UND" 'dr(2).ToString // EL FORMATO NO PERMITE LAS CODMEDIDAS
                    Dim cantidad As String = dr(3).ToString
                    Dim desprod As String = dr(1).ToString
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)
                    Dim descuento As Double = 0
                    Dim iva As Double = 0

                    'SI EL PRODUCTO ES EXENTO (1) o AFECTO (0)

                    If CType(dr(13), Integer) = 0 Then

                        iva = totalprecio - (totalprecio / GlobalConfigIVA) '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)
                        'MsgBox(String.Format("precio: {0}, total precio: {1}, cantidad: {2}", precio.ToString, totalprecio.ToString, cantidad.ToString))
                    Else
                        iva = 0 '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM // EXENTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 2, "", totalsiniva.ToString, iva.ToString)
                        'MsgBox(String.Format("precio: {0}, total precio: {1}", precio.ToString, totalprecio.ToString))

                    End If

                    varTotalIva = varTotalIva + iva
                Loop


                'MsgBox(String.Format("totalventa: {0}, iva: {1}", varTotalVenta, varTotalIva))

                'TOTALES DE LA FACTURA
                request.total_impuestos("IVA", varTotalIva.ToString)
                request.Totales(varTotalVenta.ToString)

                r = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using

        If r = True Then
            'DATOS FRASES ADICIONALES DE LA FACTURA / VENDEDOR, FRASES, ETC
            request.Adendas("Perso1", "abc1")
            'request.Adendas("Perso2", "abc2")
            'request.Adendas("Perso3", "abc3")
            request.Agregar_adendas()


            Dim response As String = ""

            Try
                response = request.enviar_peticion_fel(GlobalCertificacionUsuario, GlobalCertificacionLlave,
                                                   CodigoUnicoDocumento, GlobalCorreoEmisor, GlobalFirmaAlias, GlobalFirmaLlave, True)

            Catch ex As Exception
                MsgBox("error response: " + ex.ToString)
                response = ""
            End Try

            'MsgBox(response)

            Return LeerRespuesta(response, coddoc, correlativo)

        Else
            Return False
        End If


    End Function

    'FACTURA CAMBIARIA IVA
    Public Function facturaIVA_Cambiaria(ByVal fechahora As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal NitCliente As String, ByVal NombreCliente As String, ByVal EmailCliente As String,
                                         ByVal DireccionCliente As String, ByVal DepartamentoCliente As String, ByVal MunicipioCliente As String, ByVal fechaVence As Date, ByVal cantidadCuotas As Integer) As Boolean
        Dim r As Boolean

        Dim CodigoUnicoDocumento As String = String.Format("{0}-{1}-{2}", GlobalEmpNit, coddoc, correlativo.ToString)

        Dim NIT As String = cleanNitCliente(NitCliente)


        Dim request As RequestCertificacionFel
        request = New RequestCertificacionFel

        'ENCABEZADO DE LA FACTURA
        request.Datos_generales("GTQ", fechahora, "FCAM", "", "", "")
        request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, GlobalNombreEmisor, GlobalNombreComercialEmisor)


        request.Datos_receptor(NIT, NombreCliente, getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, DireccionCliente, "")

        'FRASES QUE LLEVA LA FACTURA
        request.Frases(1, 1, "", "")
        'request.Frases(GlobalFraseFEL, GlobalEscenarioFEL, "", "")

        Dim varTotalVenta As Double = 0
        Dim varTotalIva As Double = 0
        Dim varItem As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                                            DOCPRODUCTOS.CODPROD, 
                                            DOCPRODUCTOS.DESPROD, 
                                            DOCPRODUCTOS.CODMEDIDA, 
                                            DOCPRODUCTOS.CANTIDAD, 
                                            DOCPRODUCTOS.EQUIVALE, 
                                            DOCPRODUCTOS.TOTALUNIDADES, 
                                            DOCPRODUCTOS.COSTO, 
                                            DOCPRODUCTOS.PRECIO, 
                                            DOCPRODUCTOS.TOTALCOSTO, 
                                            DOCPRODUCTOS.TOTALPRECIO, 
                                            CASE PRODUCTOS.TIPOPROD WHEN 'S' THEN 'S' ELSE 'B' END AS TIPOPROD, 
                                            DOCPRODUCTOS.TOTALIVA, 
                                            DOCPRODUCTOS.TOTALSINIVA,
                                            PRODUCTOS.EXENTO
                                        FROM  DOCPRODUCTOS LEFT OUTER JOIN
                                        PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT
                                        WHERE (DOCPRODUCTOS.EMPNIT = @E) AND (DOCPRODUCTOS.CODDOC = @D) AND (DOCPRODUCTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    varTotalVenta = varTotalVenta + CType(dr(9), Double)
                    varItem = varItem + 1

                    Dim tipoprod As String = dr(10).ToString
                    Dim medida As String = "UND" 'dr(2).ToString // EL FORMATO NO PERMITE LAS CODMEDIDAS
                    Dim cantidad As String = dr(3).ToString
                    Dim desprod As String = dr(1).ToString
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)
                    Dim descuento As Double = 0
                    Dim iva As Double = 0

                    'SI EL PRODUCTO ES EXENTO (1) o AFECTO (0)

                    If CType(dr(13), Integer) = 0 Then

                        iva = totalprecio - (totalprecio / GlobalConfigIVA) '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)

                    Else
                        iva = 0 '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM // EXENTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 2, "", totalsiniva.ToString, iva.ToString)

                    End If

                    varTotalIva = varTotalIva + iva
                Loop


                'TOTALES DE LA FACTURA
                request.total_impuestos("IVA", varTotalIva.ToString)
                request.Totales(varTotalVenta.ToString)

                'AGREGADO PARA LA FACTURA CAMBIARIA
                request.Abonos_factura_cambiaria(fechaVence.Date.ToShortDateString, cantidadCuotas, FormatNumber(varTotalVenta / cantidadCuotas))
                request.Complemento_cambiaria("Cambiaria", "Cambiaria", "http://www.sat.gob.gt/fel/cambiaria.xsd")

                request.Adendas("Codigo_cliente", NitCliente) 'Información Adicional
                request.Adendas("Observaciones", "SN") 'observaciones
                request.Agregar_adendas()

                r = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using

        If r = True Then
            'DATOS FRASES ADICIONALES DE LA FACTURA / VENDEDOR, FRASES, ETC
            'request.Adendas("Perso1", "abc1")
            'request.Adendas("Perso2", "abc2")
            'request.Adendas("Perso3", "abc3")
            'request.Agregar_adendas()


            Dim response As String = ""

            Try
                response = request.enviar_peticion_fel(GlobalCertificacionUsuario, GlobalCertificacionLlave,
                                                   CodigoUnicoDocumento, GlobalCorreoEmisor, GlobalFirmaAlias, GlobalFirmaLlave, True)

                'MsgBox(response)

            Catch ex As Exception
                response = ""
            End Try



            Return LeerRespuesta(response, coddoc, correlativo)

        Else
            Return False
        End If


    End Function

    'FACTURA ESPECIAL IVA
    Public Function facturaIVA_Especial(ByVal fechahora As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal NitCliente As String, ByVal NombreCliente As String, ByVal EmailCliente As String,
                                         ByVal DireccionCliente As String, ByVal DepartamentoCliente As String, ByVal MunicipioCliente As String) As Boolean

        Dim r As Boolean

        'fechahora = "2020-03-01T18:41:05-06:00"
        'tipoFactura = 12% ("FACT","FACAM"), 5%(FPEQ,FCAP)

        Dim CodigoUnicoDocumento As String = String.Format("{0}-{1}-{2}", GlobalEmpNit, coddoc, correlativo.ToString)

        Dim NIT As String = cleanNitCliente(NitCliente)


        Dim request As RequestCertificacionFel
        request = New RequestCertificacionFel

        'ENCABEZADO DE LA FACTURA
        request.Datos_generales("GTQ", fechahora, "FACT", "", "", "")
        request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, GlobalNombreEmisor, GlobalNombreComercialEmisor)


        request.Datos_receptor(NIT, NombreCliente, getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, DireccionCliente, "")

        'FRASES QUE LLEVA LA FACTURA
        request.Frases(1, 1, "", "")
        'request.Frases(GlobalFraseFEL, GlobalEscenarioFEL, "", "")

        Dim varTotalVenta As Double = 0
        Dim varTotalIva As Double = 0
        Dim varItem As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                                            DOCPRODUCTOS.CODPROD, 
                                            DOCPRODUCTOS.DESPROD, 
                                            DOCPRODUCTOS.CODMEDIDA, 
                                            DOCPRODUCTOS.CANTIDAD, 
                                            DOCPRODUCTOS.EQUIVALE, 
                                            DOCPRODUCTOS.TOTALUNIDADES, 
                                            DOCPRODUCTOS.COSTO, 
                                            DOCPRODUCTOS.PRECIO, 
                                            DOCPRODUCTOS.TOTALCOSTO, 
                                            DOCPRODUCTOS.TOTALPRECIO, 
                                            CASE PRODUCTOS.TIPOPROD WHEN 'S' THEN 'S' ELSE 'B' END AS TIPOPROD, 
                                            DOCPRODUCTOS.TOTALIVA, 
                                            DOCPRODUCTOS.TOTALSINIVA,
                                            PRODUCTOS.EXENTO
                                        FROM  DOCPRODUCTOS LEFT OUTER JOIN
                                        PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT
                                        WHERE (DOCPRODUCTOS.EMPNIT = @E) AND (DOCPRODUCTOS.CODDOC = @D) AND (DOCPRODUCTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    varTotalVenta = varTotalVenta + CType(dr(9), Double)
                    varItem = varItem + 1

                    Dim tipoprod As String = dr(10).ToString
                    Dim medida As String = "UND" 'dr(2).ToString // EL FORMATO NO PERMITE LAS CODMEDIDAS
                    Dim cantidad As String = dr(3).ToString
                    Dim desprod As String = dr(1).ToString
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)
                    Dim descuento As Double = 0
                    Dim iva As Double = 0

                    'SI EL PRODUCTO ES EXENTO (1) o AFECTO (0)

                    If CType(dr(13), Integer) = 0 Then

                        iva = totalprecio - (totalprecio / GlobalConfigIVA) '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)
                        'MsgBox(String.Format("precio: {0}, total precio: {1}, cantidad: {2}", precio.ToString, totalprecio.ToString, cantidad.ToString))
                    Else
                        iva = 0 '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM // EXENTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 2, "", totalsiniva.ToString, iva.ToString)
                        'MsgBox(String.Format("precio: {0}, total precio: {1}", precio.ToString, totalprecio.ToString))

                    End If

                    varTotalIva = varTotalIva + iva
                Loop


                'MsgBox(String.Format("totalventa: {0}, iva: {1}", varTotalVenta, varTotalIva))

                'TOTALES DE LA FACTURA
                request.total_impuestos("IVA", varTotalIva.ToString)
                request.Totales(varTotalVenta.ToString)


                Dim varRetencionISR As Double = 0
                Dim varRetencionIVA As Double = 0
                Dim varTotalMenosRetenciones As Double = varTotalVenta - (varRetencionISR + varRetencionIVA)

                'COMPLEMENTO PARA FACTURA ESPECIAL
                request.Complemento_especial("Especial", "Especial", "http://www.sat.gob.gt/fel/especial.xsd", varRetencionISR.ToString, varRetencionIVA.ToString, varTotalMenosRetenciones.ToString)

                r = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using

        If r = True Then
            'DATOS FRASES ADICIONALES DE LA FACTURA / VENDEDOR, FRASES, ETC
            request.Adendas("Perso1", "abc1")
            'request.Adendas("Perso2", "abc2")
            'request.Adendas("Perso3", "abc3")
            request.Agregar_adendas()


            Dim response As String = ""

            Try
                response = request.enviar_peticion_fel(GlobalCertificacionUsuario, GlobalCertificacionLlave,
                                                   CodigoUnicoDocumento, GlobalCorreoEmisor, GlobalFirmaAlias, GlobalFirmaLlave, True)

            Catch ex As Exception
                MsgBox("error response: " + ex.ToString)
                response = ""
            End Try

            'MsgBox(response)

            Return LeerRespuesta(response, coddoc, correlativo)

        Else
            Return False
        End If


    End Function


    'nota de crédito IVA
    Public Function notacreditoIVA(ByVal fechahora As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal NitCliente As String, ByVal NombreCliente As String, ByVal EmailCliente As String,
                                         ByVal DireccionCliente As String, ByVal DepartamentoCliente As String, ByVal MunicipioCliente As String, ByVal MotivoDevolucion As String) As Boolean
        Dim r As Boolean

        Dim CodigoUnicoDocumento As String = String.Format("{0}-{1}-{2}", GlobalEmpNit, coddoc, correlativo.ToString)

        Dim NIT As String = cleanNitCliente(NitCliente)


        Dim request As RequestCertificacionFel
        request = New RequestCertificacionFel

        'ENCABEZADO DE LA FACTURA
        request.Datos_generales("GTQ", fechahora, "NCRE", "", "", "")
        request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, GlobalNombreEmisor, GlobalNombreComercialEmisor)
        request.Datos_receptor(NIT, NombreCliente, getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, DireccionCliente, "")

        'FRASES QUE LLEVA LA FACTURA
        'request.Frases(1, 1, "", "") 'original


        Dim varTotalVenta As Double = 0
        Dim varTotalIva As Double = 0
        Dim varItem As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT 
                                    DOCPRODUCTOS.CODPROD, 
                                    DOCPRODUCTOS.DESPROD, 
                                    DOCPRODUCTOS.CODMEDIDA, 
                                    DOCPRODUCTOS.CANTIDAD, 
                                    DOCPRODUCTOS.EQUIVALE, 
                                    DOCPRODUCTOS.TOTALUNIDADES, 
                                    DOCPRODUCTOS.COSTO, 
                                    DOCPRODUCTOS.PRECIO, 
                                    DOCPRODUCTOS.TOTALCOSTO, 
                                    DOCPRODUCTOS.TOTALPRECIO, 
                                    CASE PRODUCTOS.TIPOPROD WHEN 'S' THEN 'S' ELSE 'B' END AS TIPOPROD, 
                                    DOCPRODUCTOS.TOTALIVA, 
                                    DOCPRODUCTOS.TOTALSINIVA, 
                                    PRODUCTOS.EXENTO, 
                                    DOCUMENTOS.SERIEFAC,
                                    DOCUMENTOS.NOFAC
FROM            DOCPRODUCTOS RIGHT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.ANIO = DOCUMENTOS.ANIO AND DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                         DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER JOIN
                         PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT
WHERE        (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODDOC = @D) AND (DOCUMENTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                'datos de la factura asociada a la devolución
                Dim doc As String, corr As Double

                Do While dr.Read
                    varTotalVenta = varTotalVenta + CType(dr(9), Double)
                    varItem = varItem + 1

                    doc = dr(14).ToString
                    corr = CType(dr(15), Double)

                    Dim tipoprod As String = dr(10).ToString
                    Dim medida As String = "UND" 'dr(2).ToString // EL FORMATO NO PERMITE LAS CODMEDIDAS
                    Dim cantidad As String = dr(3).ToString
                    Dim desprod As String = dr(1).ToString
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)
                    Dim descuento As Double = 0
                    Dim iva As Double = 0

                    'SI EL PRODUCTO ES EXENTO (1) o AFECTO (0)

                    If CType(dr(13), Integer) = 0 Then

                        iva = totalprecio - (totalprecio / GlobalConfigIVA) '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)

                    Else
                        iva = 0 '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva

                        'AGREGA ITEM // EXENTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 2, "", totalsiniva.ToString, iva.ToString)

                    End If

                    varTotalIva = varTotalIva + iva
                Loop

                'obtiene los datos de la factura
                Call getFELDocumento(GlobalEmpNit, doc, corr)


                'TOTALES DE LA FACTURA
                request.total_impuestos("IVA", varTotalIva.ToString)
                request.Totales(varTotalVenta.ToString)


                'Complemento nota de crédito
                request.Complemento_notas("Notas", "Notas",
                                          "http://www.sat.gob.gt/fel/notas.xsd",
                                          varSelectedFECHA,
                                          MotivoDevolucion,
                                          varSelectedUUDI,
                                          "",
                                          varSelectedSERIE,
                                          varSelectedNUMERO)

                request.Adendas("Codigo_cliente", NIT)
                request.Adendas("Observaciones", MotivoDevolucion)

                request.Agregar_adendas()

                r = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using



        If r = True Then

            Dim response As String = ""

            Try

                response = request.enviar_peticion_fel(GlobalCertificacionUsuario, GlobalCertificacionLlave,
                                                   CodigoUnicoDocumento, GlobalCorreoEmisor, GlobalFirmaAlias, GlobalFirmaLlave, True)
                'MsgBox(response)

            Catch ex As Exception
                response = ""
            End Try

            Return LeerRespuesta(response, coddoc, correlativo)

        Else
            Return False
        End If


    End Function

    'anulación de factura electrónica normal
    Public Function AnularFacturaFEL(ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Dim r As Boolean

        Dim request As New conectorfelv2.RequestAnulacionFel
        'request = New RequestAnulacionFel()
        Dim response As String


        Dim fechaEmision As String = ""
        Dim fechaAnulacion As String = ""
        Dim nitCliente As String = ""
        Dim motivoAnulacion As String = ""
        Dim uudiFactura As String = ""


        'buscar los datos del documento según serie y factura
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT FECHA, FEL_FECHA, FEL_UUDI, FEL_SERIE, FEL_NUMERO, DOC_NIT   
                                    FROM DOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    fechaEmision = dr(1).ToString
                    fechaAnulacion = Today.Date.ToShortDateString
                    nitCliente = dr(5).ToString
                    uudiFactura = dr(2).ToString
                    GlobalSelectedFEL_UUDI = uudiFactura
                End If
                'comprueba el largo de la fecha para verificar que esté certificada
                If fechaEmision.Length > 1 Then
                    r = request.Datos_anulacion(fechaAnulacion, fechaEmision, nitCliente, GlobalNitEmisor, "PRUEBA DE ANULACIÓN", uudiFactura)

                    response = request.enviar_anulacion_fel(GlobalCertificacionUsuario, GlobalCertificacionLlave, "ANULACION", "", GlobalFirmaAlias, GlobalFirmaLlave, True)

                    If obtenerResultado(response) = True Then
                        r = True
                    Else
                        r = False
                    End If

                Else
                    r = False
                End If


            Catch ex As Exception
                MsgBox("Error en anulacion: " + ex.ToString)
                r = False
            End Try
        End Using




        Return r

    End Function

    'certificar documento
    Public Function certificarDocumento(ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim r As Boolean

        If getFELDocumento(GlobalEmpNit, coddoc, correlativo) = True Then



        Else
            MsgBox("No puedo obtener los datos del documento. Error: " + GlobalDesError)
        End If

        Return r
    End Function


    Dim varSelectedUUDI, varSelectedSERIE, varSelectedNUMERO, varSelectedFECHA As String

    'OBTIENE LOS DATOS FEL DE UN DOCUMENTO ESTABLECIDO
    Public Function getFELDocumento(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT FEL_UUDI, FEL_SERIE, FEL_NUMERO, FEL_FECHA 
                                            FROM DOCUMENTOS 
                                            WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    varSelectedUUDI = dr(0).ToString
                    varSelectedSERIE = dr(1).ToString
                    varSelectedNUMERO = dr(2).ToString
                    varSelectedFECHA = dr(3).ToString
                Loop

                dr.Close()


            Catch ex As Exception
                GlobalDesError = ex.ToString
                varSelectedUUDI = ""
                varSelectedSERIE = ""
                varSelectedNUMERO = ""
                varSelectedFECHA = ""
                r = False
            End Try
        End Using

        'MsgBox(String.Format("{0},{1},{2},{3}", varSelectedUUDI, varSelectedSERIE, varSelectedNUMERO, varSelectedFECHA))

        Return r

    End Function

    Private Function LeerRespuesta(ByVal respuesta As String,
                                   ByVal coddoc As String,
                                   ByVal correlativo As Double) As Boolean

        Dim res As Boolean

        Dim cadena As String
        Dim subcadena As String = ""

        Dim conteo As Integer = 1

        Dim resultado, uuid, serie, numero, fecha As String


        cadena = respuesta
        Dim nc As Integer
        Dim i As Integer
        Dim tcn As String
        nc = Len(cadena)
        For i = 1 To nc
            tcn = Mid(cadena, i, 1)
            If tcn = "," Then
                If conteo < 10 Then
                    Select Case conteo
                        Case 1
                            resultado = subcadena
                        Case 5
                            uuid = subcadena
                        Case 6
                            serie = subcadena
                        Case 7
                            numero = subcadena
                        Case 9
                            fecha = subcadena
                    End Select
                Else

                End If

                conteo = conteo + 1
                'MsgBox(subcadena)
                subcadena = ""
            Else
                subcadena = (subcadena & tcn)
            End If
        Next i


        GlobalSelectedFEL_UUDI = uuid
        GlobalSelectedFEL_SERIE = serie
        GlobalSelectedFEL_NUMERO = numero
        GlobalSelectedFEL_FECHA = fecha


        If resultado = "respuesta:true" Then
            res = True
        Else
            GlobalDesError = respuesta
            res = False
        End If

        Return res

    End Function

    Private Function obtenerResultado(ByVal respuesta As String) As Boolean

        Dim r As Boolean

        Dim resultado As String = ""

        Dim cadena As String
        Dim subcadena As String = ""

        Dim conteo As Integer = 1

        cadena = respuesta

        Dim nc As Integer
        Dim i As Integer
        Dim tcn As String
        nc = Len(cadena)
        For i = 1 To nc
            tcn = Mid(cadena, i, 1)
            If tcn = "," Then
                If conteo = 1 Then
                    resultado = subcadena
                End If
                conteo = conteo + 1
                subcadena = ""
            Else
                subcadena = (subcadena & tcn)
            End If
        Next i


        If resultado = "respuesta:true" Then
            r = True
        Else
            r = False
        End If

        Return r

    End Function


    Public Function updateDocumentoFEL(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double,
                                       ByVal FELuuid As String, ByVal FELserie As String, ByVal FELcorrelativo As String, ByVal FELfecha As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS 
                        SET FEL_UUDI=@FU,   
                        FEL_SERIE=@FS, 
                        FEL_NUMERO=@FN, 
                        FEL_FECHA=@FF 
                        WHERE EMPNIT=@E 
                            AND CODDOC=@D 
                            AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)

                cmd.Parameters.AddWithValue("@FU", FELuuid)
                cmd.Parameters.AddWithValue("@FS", FELserie)
                cmd.Parameters.AddWithValue("@FN", FELcorrelativo)
                cmd.Parameters.AddWithValue("@FF", FELfecha)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
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

    Public Function getCodigoPostal(ByVal Municipio As String, ByVal Departamento As String) As String

        Dim r As String = ""

        Select Case Municipio & "," & Departamento
            Case "GUATEMALA,GUATEMALA"
                r = "01000"

            Case "RETALHULEU,RETALHULEU"
                r = "11001"

            Case "SANTA CRUZ DEL QUICHE,QUICHE"
                r = "14001"

            Case Else
                'GUATEMALA CIUDAD
                r = "01000"

        End Select

        Return r

    End Function

    Public Function tblTipoRegimen() As DataTable
        Dim tbl As New DataTable

        With tbl.Columns
            .Add("IMPUESTO", GetType(Double))
            .Add("CODIGO", GetType(String))
            .Add("DESCRIPCION", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {12, "GEN", "GENERAL"})
            .Add(New Object() {5, "PQC", "PEQUEÑO CONTRIBUYENTE (5%)"})
            .Add(New Object() {5, "PQE", "PEQUEÑO CONTRIBUYENTE ELECTRONICO"})
            .Add(New Object() {5, "CAG", "CONTRIBUYENTE AGROPECUARIO"})
            .Add(New Object() {5, "CAE", "CONTRIBUYENTE AGROPECUARIO ELECTRONICO"})
        End With

        Return tbl

    End Function

    Public Function tblTiposPersoneria() As DataTable
        Dim tbl As New DataTable

        With tbl.Columns
            .Add("CODIGO", GetType(String))
            .Add("TIPO", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {"719", "ASOCIACIÓN CIVIL"})
            .Add(New Object() {"720", "ASOCIACIÓN COMUNITARIA Y DE DESARROLLO"})
            .Add(New Object() {"721", "OTRO TIPO DE ASOCIACIÓN"})
            .Add(New Object() {"723", "ASOCIACIÓN DE TRANSPORTE"})
            .Add(New Object() {"724", "ASOCIACIÓN DE VECINOS"})
            .Add(New Object() {"725", "ASOCIACIÓN EDUCATIVA, CULTURAL O DEPORTIVA"})
            .Add(New Object() {"726", "ASOCIACIÓN EMPRESARIAL, AGRÍCOLA, ARTESANAL, INDUSTRIAL Y OTRAS"})
            .Add(New Object() {"727", "ASOCIACIÓN MÉDICA Y DE SALUD"})
            .Add(New Object() {"728", "ASOCIACIÓN SOLIDARISTA DE EMPLEADOS"})
            .Add(New Object() {"729", "CÁMARA"})
            .Add(New Object() {"730", "GREMIAL"})
            .Add(New Object() {"731", "COMITÉ"})
            .Add(New Object() {"732", "SINDICATO"})
            .Add(New Object() {"733", "ORGANIZACIÓN NO GUBERNAMENTAL"})
            .Add(New Object() {"734", "PARTIDO POLÍTICO"})
            .Add(New Object() {"735", "IGLESIA CATÓLICA"})
            .Add(New Object() {"736", "OTRA ENTIDAD RELIGIOSA"})
            .Add(New Object() {"737", "COLEGIO DE PROFESIONALES"})
            .Add(New Object() {"739", "CENTRO EDUCATIVO POR COOPERATIVA"})
            .Add(New Object() {"740", "UNIVERSIDADES"})

        End With

        Return tbl
    End Function

    ''' <summary>
    ''' TICKET / FACTURA / FACTURACION ELECTRONICA
    ''' </summary>
    ''' <param name="Coddoc"></param>
    ''' <param name="Correlativo"></param>
    ''' <param name="imp"></param>
    ''' <returns>true o false</returns>
    Public Function rptFacturaFEL(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal imp As Integer) As Boolean

        Dim result As Boolean

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

                Dim qry As String = "Select DOCUMENTOS.FEL_FECHA AS FECHA, 
                                    DOCUMENTOS.FEL_SERIE AS CODDOC, 
                                    DOCUMENTOS.FEL_NUMERO AS CORRELATIVO, 
                                    DOCPRODUCTOS.CODPROD, 
                                    DOCPRODUCTOS.DESPROD,
                                    DOCPRODUCTOS.CODMEDIDA, 
                                    DOCPRODUCTOS.CANTIDAD,
                                    DOCPRODUCTOS.COSTO, 
                                    DOCPRODUCTOS.PRECIO,
                                    DOCUMENTOS.CODCLIENTE, 
                                    DOCUMENTOS.DOC_NIT, 
                                    DOCUMENTOS.DOC_NOMCLIE, 
                                    CLIENTES.DIRCLIENTE As DOC_DIRCLIE, 
                                    DOCUMENTOS.CODVEN, 
                                    EMPLEADOS.NOMEMPLEADO As NOMVEN, 
                                    DOCPRODUCTOS.TOTALCOSTO, 
                                    DOCPRODUCTOS.TOTALPRECIO,
                                    EMPRESAS.EMPNOMBRE, 
                                    DOCUMENTOS.PAGO, 
                                    DOCUMENTOS.VUELTO,
                                    DOCUMENTOS.HORA, 
                                    DOCUMENTOS.MINUTO, 
                                    DOCUMENTOS.CONCRE,
                                    DOCUMENTOS.FEL_UUDI AS AUTORIZACION, 
                                    ISNULL(TIPODOCUMENTOS.RESOLUCION, 'SN') AS RESOLUCION, 
                                    ISNULL(TIPODOCUMENTOS.FRASE1, 'SN') AS FRASE1, 
                                    ISNULL(DOCPRODUCTOS.OBS, ' ') AS NOSERIE, 
                                    MUNICIPIOS.DESMUNICIPIO, ISNULL(CLIENTES.TELEFONOCLIENTE, 'SN') AS TELCLIENTE, 
                                    ISNULL(DOCUMENTOS.TOTALTARJETA, 0) As TOTALTARJETA,
                                    ISNULL(DOCUMENTOS.RECARGOTARJETA, 0) As RECARGOTARJETA, 
                                    ISNULL(DOCUMENTOS.DIRENTREGA,'SN') AS DIRENTREGA, 
                                    ISNULL(DOCPRODUCTOS.EXENTO, 0) As EXENTO, 
                                    DOCUMENTOS.FEL_FECHA AS OBS,
                                    DOCUMENTOS.VENCIMIENTO,
                                    DOCUMENTOS.DIASCREDITO
                            From EMPLEADOS RIGHT OUTER Join
                            DOCUMENTOS On EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN And EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER Join
                            MUNICIPIOS RIGHT OUTER Join
                            CLIENTES On MUNICIPIOS.CODMUNICIPIO = CLIENTES.CODMUNICIPIO ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT And DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER Join
                            EMPRESAS On DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER Join
                            TIPODOCUMENTOS On DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC And DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER Join
                            DOCPRODUCTOS On DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO And DOCUMENTOS.MES = DOCPRODUCTOS.MES And
                            DOCUMENTOS.DIA = DOCPRODUCTOS.DIA And DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC And DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                            Where (DOCUMENTOS.EMPNIT = @E)  And (DOCUMENTOS.CODDOC = @D) And 
                            (DOCUMENTOS.CORRELATIVO = @N)"
                Dim cmd As New SqlCommand(qry, cn)

                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", Coddoc)
                cmd.Parameters.AddWithValue("@N", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    GlobalSelectedFEL_UUDI = dr(23).ToString
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
                                  dr(23).ToString, 'AUTORIZACION / FEL UUDI
                                  dr(24).ToString, 'RESOLUCION
                                  Letras(Double.Parse(dr(16)).ToString).ToUpper & "QUETZALES", 'dr(25).ToString, 'FRASE1
                                  dr(26).ToString, 'noserie
                                  dr(27), 'DESMUNICIPIO
                                  dr(28),  'TELCLIENTE
                                  Double.Parse(dr(29)), 'TOTALTARJETA
                                  Double.Parse(dr(30)), 'RECARGOTARJETA
                                  dr(31).ToString, 'DIRECCION DE ENTREGA
                                  Double.Parse(dr(32)), 'MONTO EXENTO EN DOCPRODUCTOS
                                  dr(33).ToString(),    'OBSERVACIONES
                                  Today.Day.ToString,'FECHA DD 
                                  Today.Month.ToString, 'FECHA MM
                                  Today.Year.ToString, 'FECHA YY
                                  Date.Parse(dr(34)), 'FECHA VENCE
                                  Integer.Parse(dr(35)) 'DIAS CREDITO
                                                                     })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmd.Dispose()
                'cn.Close()
            End Using

            Dim Adapter As New SqlDataAdapter
            Dim report As New rptFacturaFEL

            Try
                'INTENTA ABRIR UN FORMATO LLAMADO FACTURA, SI NO EXISTE, LO CREA EN BASE AL TEMPLATE INTERNO
                report.LoadLayout(Application.StartupPath + "\Reports\FACTURAFEL.repx")
            Catch exs As Exception
                'GUARDA EL TEMPLATE CON EL NOMBRE FACTURA
                report.SaveLayout(Application.StartupPath + "\Reports\FACTURAFEL.repx")
            End Try

            report.DataSource = tblTicket
            report.DataAdapter = Adapter
            report.DataMember = "tblTicket"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            Select Case imp
                Case 1
                    report.Print
                Case 2
                    report.ShowPreview
            End Select

            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            MsgBox(ex.ToString)
        End Try

        Return result

    End Function


    ''' <summary>
    ''' TICKET / FACTURA / FACTURACION ELECTRONICA
    ''' </summary>
    ''' <param name="Coddoc"></param>
    ''' <param name="Correlativo"></param>
    ''' <param name="imp"></param>
    ''' <returns>true o false</returns>
    Public Function rptFacturaFELCONTINGENCIA(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal imp As Integer) As Boolean

        Dim result As Boolean

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

                Dim qry As String = "Select DOCUMENTOS.FECHA, 
                                    DOCUMENTOS.CODDOC, 
                                    DOCUMENTOS.CORRELATIVO, 
                                    DOCPRODUCTOS.CODPROD, 
                                    DOCPRODUCTOS.DESPROD,
                                    DOCPRODUCTOS.CODMEDIDA, 
                                    DOCPRODUCTOS.CANTIDAD,
                                    DOCPRODUCTOS.COSTO, 
                                    DOCPRODUCTOS.PRECIO,
                                    DOCUMENTOS.CODCLIENTE, 
                                    DOCUMENTOS.DOC_NIT, 
                                    DOCUMENTOS.DOC_NOMCLIE, 
                                    CLIENTES.DIRCLIENTE As DOC_DIRCLIE, 
                                    DOCUMENTOS.CODVEN, 
                                    EMPLEADOS.NOMEMPLEADO As NOMVEN, 
                                    DOCPRODUCTOS.TOTALCOSTO, 
                                    DOCPRODUCTOS.TOTALPRECIO,
                                    EMPRESAS.EMPNOMBRE, 
                                    DOCUMENTOS.PAGO, 
                                    DOCUMENTOS.VUELTO,
                                    DOCUMENTOS.HORA, 
                                    DOCUMENTOS.MINUTO, 
                                    DOCUMENTOS.CONCRE,
                                    (DOCUMENTOS.CORRELATIVO + 100000) AS AUTORIZACION, 
                                    ISNULL(TIPODOCUMENTOS.RESOLUCION, 'SN') AS RESOLUCION, 
                                    ISNULL(TIPODOCUMENTOS.FRASE1, 'SN') AS FRASE1, 
                                    ISNULL(DOCPRODUCTOS.OBS, ' ') AS NOSERIE, 
                                    MUNICIPIOS.DESMUNICIPIO, ISNULL(CLIENTES.TELEFONOCLIENTE, 'SN') AS TELCLIENTE, 
                                    ISNULL(DOCUMENTOS.TOTALTARJETA, 0) As TOTALTARJETA, ISNULL(DOCUMENTOS.RECARGOTARJETA, 0) As RECARGOTARJETA, 
                                    ISNULL(DOCUMENTOS.DIRENTREGA,'SN') AS DIRENTREGA, 
                                    ISNULL(DOCPRODUCTOS.EXENTO, 0) As EXENTO, 
                                    DOCUMENTOS.OBS AS OBS,
                                    DOCUMENTOS.VENCIMIENTO,
                                    DOCUMENTOS.DIASCREDITO
                            From EMPLEADOS RIGHT OUTER Join
                            DOCUMENTOS On EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN And EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER Join
                            MUNICIPIOS RIGHT OUTER Join
                            CLIENTES On MUNICIPIOS.CODMUNICIPIO = CLIENTES.CODMUNICIPIO ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT And DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER Join
                            EMPRESAS On DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER Join
                            TIPODOCUMENTOS On DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC And DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER Join
                            DOCPRODUCTOS On DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO And DOCUMENTOS.MES = DOCPRODUCTOS.MES And
                            DOCUMENTOS.DIA = DOCPRODUCTOS.DIA And DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC And DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                            Where (DOCUMENTOS.EMPNIT = @E)  And (DOCUMENTOS.CODDOC = @D) And 
                            (DOCUMENTOS.CORRELATIVO = @N)"
                Dim cmd As New SqlCommand(qry, cn)

                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", Coddoc)
                cmd.Parameters.AddWithValue("@N", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    GlobalSelectedFEL_UUDI = dr(23).ToString
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
                                  dr(23).ToString, 'AUTORIZACION / FEL UUDI
                                  dr(24).ToString, 'RESOLUCION
                                  Letras(Double.Parse(dr(16)).ToString).ToUpper & "QUETZALES", 'dr(25).ToString, 'FRASE1
                                  dr(26).ToString, 'noserie
                                  dr(27), 'DESMUNICIPIO
                                  dr(28),  'TELCLIENTE
                                  Double.Parse(dr(29)), 'TOTALTARJETA
                                  Double.Parse(dr(30)), 'RECARGOTARJETA
                                  dr(31).ToString, 'DIRECCION DE ENTREGA
                                  Double.Parse(dr(32)), 'MONTO EXENTO EN DOCPRODUCTOS
                                  dr(33).ToString(),    'OBSERVACIONES
                                  Today.Day.ToString,'FECHA DD 
                                  Today.Month.ToString, 'FECHA MM
                                  Today.Year.ToString, 'FECHA YY
                                  Date.Parse(dr(34)), 'FECHA VENCE
                                  Integer.Parse(dr(35)) 'DIAS CREDITO
                                                                     })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmd.Dispose()
                'cn.Close()
            End Using

            Dim Adapter As New SqlDataAdapter
            Dim report As New rptFacturaFELContingencia

            'CARGO PRIMERO EL REPORTE

            Try
                'INTENTA ABRIR UN FORMATO LLAMADO FACTURA, SI NO EXISTE, LO CREA EN BASE AL TEMPLATE INTERNO
                report.LoadLayout(Application.StartupPath + "\Reports\FACTURAFELCONTINGENCIA.repx")
            Catch exs As Exception
                'GUARDA EL TEMPLATE CON EL NOMBRE FACTURA
                report.SaveLayout(Application.StartupPath + "\Reports\FACTURAFELCONTINGENCIA.repx")
                'INTENTA ABRIR UN FORMATO
                report.LoadLayout(Application.StartupPath + "\Reports\FACTURAFELCONTINGENCIA.repx")
            End Try

            report.DataSource = tblTicket
            report.DataAdapter = Adapter
            report.DataMember = "tblTicket"

            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            Select Case imp
                Case 1
                    report.Print
                Case 2
                    report.ShowPreview
            End Select

            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            MsgBox(ex.ToString)
        End Try

        Return result

    End Function



End Class
