
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
    Public Property GlobalSelectedNomven As String = ""

    Public Property GlobalFraseFEL As Integer = 1
    Public Property GlobalEscenarioFEL As Integer = 1

    Public Property GlobalFraseFEL2 As Integer = 1
    Public Property GlobalEscenarioFEL2 As Integer = 1

    Private Sub CargarDatosClienteFEL()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("SELECT CERTIFICACION_USUARIO
                                                  ,CERTIFICACION_LLAVE
                                                  ,FIRMA_ALIAS
                                                  ,FIRMA_LLAVE
                                                  ,EMISOR_CODIGOESTABLECIMIENTO
                                                  ,EMISOR_CODIGOPOSTAL
                                                  ,EMISOR_DEPARTAMENTO
                                                  ,EMISOR_DIRECCION
                                                  ,EMISOR_MUNICIPIO
                                                  ,EMISOR_NOMBRE
                                                  ,EMISOR_NOMBRECOMECIAL
                                                  ,EMISOR_NIT
                                                  ,EMISOR_FRASE
                                                  ,EMISOR_ESCENARIO
                                                  ,EMISOR_FRASE2
                                                  ,EMISOR_ESCENARIO2
                                              FROM FEL_CREDENCIALES", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    GlobalCodigoEstablecimientoEmisor = Integer.Parse(dr(4))
                    GlobalCorreoEmisor = ""
                    GlobalNitEmisor = dr(11).ToString
                    GlobalNombreEmisor = dr(9).ToString
                    GlobalNombreComercialEmisor = dr(10).ToString
                    GlobalDepartamentoEmisor = dr(6).ToString
                    GlobalMunicipioEmisor = dr(8).ToString
                    GlobalDireccionEmisor = dr(7).ToString
                    GlobalCodigoPostalEmmisor = dr(5).ToString
                    GlobalCertificacionUsuario = dr(0).ToString
                    GlobalCertificacionLlave = dr(1).ToString
                    GlobalFirmaAlias = dr(2).ToString
                    GlobalFirmaLlave = dr(3).ToString
                    GlobalFraseFEL = CType(dr(12), Integer)
                    GlobalEscenarioFEL = CType(dr(13), Integer)
                    GlobalFraseFEL2 = CType(dr(14), Integer)
                    GlobalEscenarioFEL2 = CType(dr(15), Integer)
                    GlobalFELEnviaCodigoProducto = "SI"
                Else
                    Form1.Mensaje("No hay credenciales FEL")
                End If

            Catch ex As Exception
                'MsgBox("CARGA CREDENCIALES: " + ex.ToString)
            End Try
        End Using


        Exit Sub


    End Sub

    Private Sub CargarDatosClienteFEL_old()

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

            GlobalFraseFEL2 = CType(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_FRASE2", Nothing).ToString, Integer)
            GlobalEscenarioFEL2 = CType(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\FEL", "EMISOR_ESCENARIO2", Nothing).ToString, Integer)

            GlobalFELEnviaCodigoProducto = "SI"

            If GlobalFELActivo = 1 Then
                GlobalNitEmisor = ""
            End If

        Catch ex As Exception
            Form1.Mensaje("No hay credenciales de facturación electronica")
        End Try

        Exit Sub


    End Sub


    Public Function insertCredenciales(ByVal cert_usuario As String,
                                       ByVal cert_llave As String,
                                       ByVal firm_alias As String,
                                       ByVal firm_llave As String,
                                       ByVal cod_establecimiento As String,
                                       ByVal cod_postal As String,
                                       ByVal emi_depto As String,
                                       ByVal emi_direccion As String,
                                       ByVal emi_municipio As String,
                                       ByVal emi_nombre As String,
                                       ByVal emi_nombrecomercial As String,
                                       ByVal emi_nit As String,
                                       ByVal frase1 As Integer,
                                       ByVal escenario1 As Integer,
                                       ByVal frase2 As Integer,
                                       ByVal escenario2 As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand(" INSERT INTO FEL_CREDENCIALES (CERTIFICACION_USUARIO
                                                  ,CERTIFICACION_LLAVE
                                                  ,FIRMA_ALIAS
                                                  ,FIRMA_LLAVE
                                                  ,EMISOR_CODIGOESTABLECIMIENTO
                                                  ,EMISOR_CODIGOPOSTAL
                                                  ,EMISOR_DEPARTAMENTO
                                                  ,EMISOR_DIRECCION
                                                  ,EMISOR_MUNICIPIO
                                                  ,EMISOR_NOMBRE
                                                  ,EMISOR_NOMBRECOMECIAL
                                                  ,EMISOR_NIT
                                                  ,EMISOR_FRASE
                                                  ,EMISOR_ESCENARIO
                                                  ,EMISOR_FRASE2
                                                  ,EMISOR_ESCENARIO2) VALUES 
                                                (@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16)", cn)
                cmd.Parameters.AddWithValue("@1", cert_usuario)
                cmd.Parameters.AddWithValue("@2", cert_llave)
                cmd.Parameters.AddWithValue("@3", firm_alias)
                cmd.Parameters.AddWithValue("@4", firm_llave)
                cmd.Parameters.AddWithValue("@5", cod_establecimiento)
                cmd.Parameters.AddWithValue("@6", cod_postal)
                cmd.Parameters.AddWithValue("@7", emi_depto)
                cmd.Parameters.AddWithValue("@8", emi_direccion)
                cmd.Parameters.AddWithValue("@9", emi_municipio)
                cmd.Parameters.AddWithValue("@10", emi_nombre)
                cmd.Parameters.AddWithValue("@11", emi_nombrecomercial)
                cmd.Parameters.AddWithValue("@12", emi_nit)
                cmd.Parameters.AddWithValue("@13", frase1)
                cmd.Parameters.AddWithValue("@14", escenario1)
                cmd.Parameters.AddWithValue("@15", frase2)
                cmd.Parameters.AddWithValue("@16", escenario2)
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


    Public Function editCredenciales(ByVal cert_usuario As String,
                                       ByVal cert_llave As String,
                                       ByVal firm_alias As String,
                                       ByVal firm_llave As String,
                                       ByVal cod_establecimiento As String,
                                       ByVal cod_postal As String,
                                       ByVal emi_depto As String,
                                       ByVal emi_direccion As String,
                                       ByVal emi_municipio As String,
                                       ByVal emi_nombre As String,
                                       ByVal emi_nombrecomercial As String,
                                       ByVal emi_nit As String,
                                       ByVal frase1 As Integer,
                                       ByVal escenario1 As Integer,
                                       ByVal frase2 As Integer,
                                       ByVal escenario2 As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand(" UPDATE FEL_CREDENCIALES SET 
                                                   CERTIFICACION_USUARIO=@1
                                                  ,CERTIFICACION_LLAVE=@2
                                                  ,FIRMA_ALIAS=@3
                                                  ,FIRMA_LLAVE=@4
                                                  ,EMISOR_CODIGOESTABLECIMIENTO=@5
                                                  ,EMISOR_CODIGOPOSTAL=@6
                                                  ,EMISOR_DEPARTAMENTO=@7
                                                  ,EMISOR_DIRECCION=@8
                                                  ,EMISOR_MUNICIPIO=@9
                                                  ,EMISOR_NOMBRE=@10
                                                  ,EMISOR_NOMBRECOMECIAL=@11
                                                  ,EMISOR_NIT=@12
                                                  ,EMISOR_FRASE=@13
                                                  ,EMISOR_ESCENARIO=@14
                                                  ,EMISOR_FRASE2=@15
                                                  ,EMISOR_ESCENARIO2=@16", cn)
                cmd.Parameters.AddWithValue("@1", cert_usuario)
                cmd.Parameters.AddWithValue("@2", cert_llave)
                cmd.Parameters.AddWithValue("@3", firm_alias)
                cmd.Parameters.AddWithValue("@4", firm_llave)
                cmd.Parameters.AddWithValue("@5", cod_establecimiento)
                cmd.Parameters.AddWithValue("@6", cod_postal)
                cmd.Parameters.AddWithValue("@7", emi_depto)
                cmd.Parameters.AddWithValue("@8", emi_direccion)
                cmd.Parameters.AddWithValue("@9", emi_municipio)
                cmd.Parameters.AddWithValue("@10", emi_nombre)
                cmd.Parameters.AddWithValue("@11", emi_nombrecomercial)
                cmd.Parameters.AddWithValue("@12", emi_nit)
                cmd.Parameters.AddWithValue("@13", frase1)
                cmd.Parameters.AddWithValue("@14", escenario1)
                cmd.Parameters.AddWithValue("@15", frase2)
                cmd.Parameters.AddWithValue("@16", escenario2)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = insertCredenciales(cert_usuario, cert_llave, firm_alias, firm_llave, cod_establecimiento, cod_postal, emi_depto, emi_direccion, emi_municipio, emi_nombre, emi_nombrecomercial, emi_nit, frase1, escenario1, frase2, escenario2)
                    'r = False
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using


        Return r
    End Function


    Public Function getDataNIT(ByVal nit As String) As Boolean

        Dim r As Boolean

        Dim nitcli As String = cleanNitCliente(nit)


        Dim wc As WebClient
        wc = New WebClient

        Try
            If nitcli.Length = 13 Then
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim resp As String = (New WebClient).DownloadString(New Uri("https://apifel.vercel.app/api/datoscui?cui=" + nitcli))
                Dim bytes As Byte() = System.Text.Encoding.Default.GetBytes(resp)
                Dim a As String = System.Text.Encoding.UTF8.GetString(bytes)

                GlobalSelectedNitCliente = nitcli
                GlobalSelectedNomCliente = a
            Else
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                Dim resp As String = (New WebClient).DownloadString(New Uri("https://apifel.vercel.app/api/datosnit?nit=" + nitcli))
                Dim bytes As Byte() = System.Text.Encoding.Default.GetBytes(resp)
                Dim a As String = System.Text.Encoding.UTF8.GetString(bytes)

                GlobalSelectedNitCliente = nitcli
                GlobalSelectedNomCliente = a
            End If


            r = True

        Catch ex As Exception
            MsgBox(ex.ToString)
            r = False
        End Try

        Return r

    End Function

    Private Function LeerRespuestaCliente(ByVal respuesta As String) As Boolean

        Dim res As Boolean = True

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
            If tcn = ";" Then
                If conteo < 3 Then
                    Select Case conteo
                        Case 1
                            GlobalSelectedNomCliente = subcadena
                        Case 2
                            GlobalSelectedDirCliente = subcadena
                    End Select
                Else
                    'no hace nada
                End If
                conteo = conteo + 1
                subcadena = ""
            Else
                subcadena = (subcadena & tcn)
            End If
        Next i

        Return res

    End Function


    Public Function cleanNitCliente(ByVal nit As String) As String

        Dim n As String = nit

        n = n.Replace("-", "")
        n = n.Replace("/", "")
        n = n.Replace("\", "")
        n = n.Replace(".", "")
        n = n.Replace(",", "")
        n = n.Replace("#", "")
        n = n.Replace("$", "")
        n = n.Replace("'", "")
        n = n.Replace(";", "")
        n = n.Replace(":", "")
        n = n.Replace("=", "")
        n = n.Replace("%", "")
        n = n.Replace("(", "")
        n = n.Replace(")", "")
        n = n.Replace("!", "")
        n = n.Replace(" ", "")
        n = n.ToUpper

        Return n


    End Function


    Public Function cleanDataFEL(ByVal data As String) As String
        Dim r As String

        Dim tempBytes As Byte()
        tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(data)
        r = System.Text.Encoding.UTF8.GetString(tempBytes)
        r = r.Replace("-", "")
        r = r.Replace("/", "")
        r = r.Replace("\", "")
        r = r.Replace(".", "")
        r = r.Replace(",", "")
        r = r.Replace("#", "")
        r = r.Replace("$", "")
        r = r.Replace("'", "")
        r = r.Replace(";", "")
        r = r.Replace(":", "")
        r = r.Replace("=", "")
        r = r.Replace("%", "")
        r = r.Replace("(", "")
        r = r.Replace(")", "")
        r = r.Replace("!", "")
        r = r.Replace("_", "")
        r = r.Replace("Ü", "")
        r = r.Replace("ü", "")
        r = r.Replace("ñ", "n")
        r = r.Replace("Ñ", "N")
        r = r.Replace("&", "")
        r = r.Replace(Chr(34), "")

        Return r

    End Function

    'VALIDA NIT
    Public Function ValidaNit(ByVal NIT As String) As Boolean

        Dim POS As Integer
        Dim Correlativo As String
        Dim DigitoVerificador As String
        Dim Factor As Integer
        Dim Suma As Integer = 0
        Dim Valor As Integer = 0
        Dim X As Integer
        Dim xMOD11 As Double = 0
        Dim S As String = Nothing

        ValidaNit = False

        Try
            POS = NIT.IndexOf("-")

            If POS = 0 Then Exit Function

            Correlativo = NIT.Substring(0, POS)

            DigitoVerificador = NIT.Substring(POS + 1)
            Factor = Correlativo.Length + 1

            For X = 0 To (NIT.IndexOf("-") - 1)

                Valor = Convert.ToInt32(NIT.Substring(X, 1))

                Suma += (Valor * Factor)

                Factor -= 1

            Next

            xMOD11 = (11 - (Suma Mod 11)) Mod 11

            S = Convert.ToString(xMOD11)

            If (xMOD11 = 10 And DigitoVerificador = "K") Or (S = DigitoVerificador) Then
                ValidaNit = True
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "NIT INVÁLIDO", MessageBoxButtons.OK,
            'MessageBoxIcon.Exclamation)
        End Try

    End Function

    'FACTURA IVA NORMAL
    Public Function facturaIVA_Normal(ByVal fechahora As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal NitCliente As String, ByVal NombreCliente As String, ByVal EmailCliente As String,
                                         ByVal DireccionCliente As String, ByVal DepartamentoCliente As String, ByVal MunicipioCliente As String, Optional obs As String = "SN") As Boolean





        Dim r As Boolean

        Dim CodigoUnicoDocumento As String = String.Format("{0}-{1}-{2}", GlobalEmpNit, coddoc, correlativo.ToString)

        Dim NIT As String = cleanNitCliente(NitCliente)


        Dim request As RequestCertificacionFel
        request = New RequestCertificacionFel

        'ENCABEZADO DE LA FACTURA
        request.Datos_generales("GTQ", fechahora, "FACT", "", "", "")
        request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, GlobalNombreEmisor, GlobalNombreComercialEmisor)

        If NIT.Length = 13 Then
            request.Datos_receptor(NIT, cleanDataFEL(NombreCliente), getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, cleanDataFEL(DireccionCliente), "CUI")
        Else
            request.Datos_receptor(NIT, cleanDataFEL(NombreCliente), getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, cleanDataFEL(DireccionCliente), "")
        End If

        'request.Datos_receptor(NIT, cleanDataFEL(NombreCliente), getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, cleanDataFEL(DireccionCliente), "")


        Dim varTotalVenta As Double = 0
        Dim varTotalIva As Double = 0
        Dim varTotalDescuento As Double = 0
        Dim varItem As Integer = 0
        Dim varFraseExentos As Integer = 0

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
                                            ISNULL(PRODUCTOS.EXENTO,0) AS EXENTO,
                                            ISNULL(DOCPRODUCTOS.DESCUENTO,0) AS DESCUENTO
                                        FROM  DOCPRODUCTOS LEFT OUTER JOIN
                                        PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT
                                        WHERE (DOCPRODUCTOS.EMPNIT = @E) AND (DOCPRODUCTOS.CODDOC = @D) AND (DOCPRODUCTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    'varTotalVenta = varTotalVenta + CType(dr(9), Double)
                    varItem = varItem + 1

                    Dim tipoprod As String = dr(10).ToString
                    Dim medida As String = "UND" 'dr(2).ToString // EL FORMATO NO PERMITE LAS CODMEDIDAS
                    Dim cantidad As String = dr(3).ToString
                    Dim desprod As String = cleanDataFEL(dr(1).ToString)
                    If GlobalFELEnviaCodigoProducto = "SI" Then
                        desprod = dr(0).ToString & " || " & dr(1).ToString
                    Else
                        desprod = dr(1).ToString
                    End If
                    'MsgBox(GlobalFELEnviaCodigoProducto & " " & desprod)
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)


                    Dim descuento As Double = Double.Parse(dr(14))
                    Dim iva As Double = 0


                    varTotalVenta = varTotalVenta + (totalprecio - descuento)

                    'SI EL PRODUCTO ES EXENTO (1) o AFECTO (0)

                    If CType(dr(13), Integer) = 0 Then

                        iva = (totalprecio - descuento) - ((totalprecio - descuento) / GlobalConfigIVA) '// 0 = si el producto es exento
                        Dim totalsiniva As Double = (totalprecio - descuento) - iva
                        'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, (totalprecio - descuento).ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)
                    Else
                        varFraseExentos = 1
                        iva = 0 '// 0 = si el producto es exento
                        Dim totalsiniva As Double = (totalprecio - descuento) - iva
                        'AGREGA ITEM // EXENTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, "*" & desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, (totalprecio - descuento).ToString, "IVA", 2, "", totalsiniva.ToString, iva.ToString)
                    End If

                    varTotalIva = varTotalIva + iva
                Loop


                'FRASES QUE LLEVA LA FACTURA / FRASE 1
                'request.Frases(1, 1, "", "")
                request.Frases(GlobalFraseFEL, GlobalEscenarioFEL, "", "")

                'si hay productos exentos, se incluye la frase 4,9
                If varFraseExentos = 0 Then
                Else
                    request.Frases(4, 9, "", "")
                End If


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
            request.Adendas("SERIEINTERNO", coddoc)
            request.Adendas("NUMEROINTERNO", correlativo.ToString)
            request.Adendas("VENDEDOR", GlobalSelectedNomven.Replace("&", ""))
            request.Adendas("NOTAS", cleanDataFEL(obs))

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
        'request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, "SONIA JUDITH DE PAZ GORDILLO DE DIAZ", "FARMACIA EL ROSARIO")


        request.Datos_receptor(NIT, cleanDataFEL(NombreCliente), getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, cleanDataFEL(DireccionCliente), "")


        Dim varTotalVenta As Double = 0
        Dim varTotalIva As Double = 0
        Dim varItem As Integer = 0
        Dim varFraseExentos As Integer = 0

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
                                            ISNULL(PRODUCTOS.EXENTO,0) AS EXENTO,
                                            ISNULL(DOCPRODUCTOS.DESCUENTO,0) AS DESCUENTO
                                        FROM  DOCPRODUCTOS LEFT OUTER JOIN
                                        PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.EMPNIT = PRODUCTOS.EMPNIT
                                        WHERE (DOCPRODUCTOS.EMPNIT = @E) AND (DOCPRODUCTOS.CODDOC = @D) AND (DOCPRODUCTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    'varTotalVenta = varTotalVenta + CType(dr(9), Double)
                    varItem = varItem + 1

                    Dim tipoprod As String = dr(10).ToString
                    Dim medida As String = "UND" 'dr(2).ToString // EL FORMATO NO PERMITE LAS CODMEDIDAS
                    Dim cantidad As String = dr(3).ToString
                    'Dim desprod As String = dr(1).ToString
                    Dim desprod As String = cleanDataFEL(dr(1).ToString)
                    If GlobalFELEnviaCodigoProducto = "SI" Then
                        desprod = dr(0).ToString & " || " & dr(1).ToString
                    Else
                        desprod = dr(1).ToString
                    End If
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)
                    Dim descuento As Double = Double.Parse(dr(14))
                    Dim iva As Double = 0


                    varTotalVenta = varTotalVenta + (totalprecio - descuento)

                    'SI EL PRODUCTO ES EXENTO (1) o AFECTO (0)

                    If CType(dr(13), Integer) = 0 Then

                        iva = (totalprecio - descuento) - ((totalprecio - descuento) / GlobalConfigIVA) '// 0 = si el producto es exento
                        Dim totalsiniva As Double = (totalprecio - descuento) - iva
                        'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, (totalprecio - descuento).ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)
                    Else
                        varFraseExentos = 1
                        iva = 0 '// 0 = si el producto es exento
                        Dim totalsiniva As Double = (totalprecio - descuento) - iva
                        'AGREGA ITEM // EXENTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, "*" & desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, (totalprecio - descuento).ToString, "IVA", 2, "", totalsiniva.ToString, iva.ToString)
                    End If

                    varTotalIva = varTotalIva + iva
                Loop

                'FRASES QUE LLEVA LA FACTURA
                'request.Frases(1, 1, "", "")
                request.Frases(GlobalFraseFEL, GlobalEscenarioFEL, "", "")


                'si hay productos exentos, se incluye la frase 4,9
                If varFraseExentos = 0 Then
                Else
                    request.Frases(4, 9, "", "")
                End If



                'TOTALES DE LA FACTURA
                request.total_impuestos("IVA", varTotalIva.ToString)
                request.Totales(varTotalVenta.ToString)

                'AGREGADO PARA LA FACTURA CAMBIARIA
                request.Abonos_factura_cambiaria(fechaVence.Date.ToShortDateString, cantidadCuotas, FormatNumber(varTotalVenta / cantidadCuotas))
                request.Complemento_cambiaria("Cambiaria", "Cambiaria", "http://www.sat.gob.gt/fel/cambiaria.xsd")


                request.Adendas("SERIEINTERNO", coddoc)
                request.Adendas("NUMEROINTERNO", correlativo.ToString)
                request.Adendas("VENDEDOR", GlobalSelectedNomven.Replace("&", ""))
                request.Adendas("NOTAS", NitCliente)
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


    'FACTURA ESPECIAL IVA
    Public Function facturaIVA_Especial(ByVal fechahora As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal NitCliente As String, ByVal NombreCliente As String, ByVal EmailCliente As String,
                                         ByVal DireccionCliente As String, ByVal DepartamentoCliente As String, ByVal MunicipioCliente As String, Optional obs As String = "SN") As Boolean

        Dim r As Boolean

        Dim CodigoUnicoDocumento As String = String.Format("{0}-{1}-{2}", GlobalEmpNit, coddoc, correlativo.ToString)

        Dim NIT As String = cleanNitCliente(NitCliente)

        Dim request As RequestCertificacionFel
        request = New RequestCertificacionFel

        'ENCABEZADO DE LA FACTURA
        request.Datos_generales("GTQ", fechahora, "FESP", "", "", "")
        request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, GlobalNombreEmisor, GlobalNombreComercialEmisor)
        request.Datos_receptor(NIT, NombreCliente.Replace("&", ""), getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, DireccionCliente.Replace("&", ""), "")


        Dim varTotalVenta As Double = 0
        Dim varTotalIva As Double = 0
        Dim varItem As Integer = 0
        Dim varFraseExentos As Integer = 0

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
                                            ISNULL(PRODUCTOS.EXENTO,0) AS EXENTO
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
                    Dim desprod As String = cleanDataFEL(dr(1).ToString)
                    If GlobalFELEnviaCodigoProducto = "SI" Then
                        desprod = dr(0).ToString & " || " & dr(1).ToString.Replace("&", "")
                    Else
                        desprod = dr(1).ToString
                    End If
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)
                    Dim descuento As Double = 0
                    Dim iva As Double = 0

                    iva = totalprecio - (totalprecio / GlobalConfigIVA) '// 0 = si el producto es exento
                    Dim totalsiniva As Double = totalprecio - iva
                    'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                    request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)

                    varTotalIva = varTotalIva + iva
                Loop

                'FRASES QUE LLEVA LA FACTURA // FACTURA ESPECIAL NO LLEVA FRASES ADICIONALES A LA DEL ISR
                'request.Frases(1, 1, "", "")
                'request.Frases(GlobalFraseFEL, GlobalEscenarioFEL, "", "")
                'If GlobalFraseFEL2 = 0 Then
                'Else
                'request.Frases(GlobalFraseFEL2, GlobalEscenarioFEL2, "", "")
                'End If

                'FACTURA ESPECIAL NO PERMITE EXENTOS Y AFECTOS


                'TOTALES DE LA FACTURA
                request.total_impuestos("IVA", varTotalIva.ToString)
                request.Totales(varTotalVenta.ToString)


                Dim varRetencionISR As String = ((varTotalVenta / 1.12) * 0.05).ToString
                Dim varRetencionIVA As String = varTotalIva.ToString
                Dim varTotalMenosRetenciones As String = ((varTotalVenta / 1.12) * 0.95).ToString

                'COMPLEMENTO PARA FACTURA ESPECIAL
                request.Complemento_especial("Especial", "Especial", "http://www.sat.gob.gt/fel/especial.xsd", varRetencionISR.ToString, varRetencionIVA, varTotalMenosRetenciones.ToString)

                r = True
            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using

        If r = True Then
            'DATOS FRASES ADICIONALES DE LA FACTURA / VENDEDOR, FRASES, ETC
            request.Adendas("SERIEINTERNO", coddoc)
            request.Adendas("NUMEROINTERNO", correlativo.ToString)
            request.Adendas("VENDEDOR", GlobalSelectedNomven.Replace("&", ""))
            request.Adendas("NOTAS", obs.Replace("&", ""))
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
                                         ByVal DireccionCliente As String, ByVal DepartamentoCliente As String, ByVal MunicipioCliente As String, ByVal MotivoDevolucion As String, Optional obs As String = "SN") As Boolean
        Dim r As Boolean

        Dim CodigoUnicoDocumento As String = String.Format("{0}-{1}-{2}", GlobalEmpNit, coddoc, correlativo.ToString)

        Dim NIT As String = cleanNitCliente(NitCliente)

        Dim varFraseExentos As Integer = 0

        Dim request As RequestCertificacionFel
        request = New RequestCertificacionFel

        'ENCABEZADO DE LA FACTURA
        request.Datos_generales("GTQ", fechahora, "NCRE", "", "", "")
        request.Datos_emisor("GEN", GlobalCodigoEstablecimientoEmisor, GlobalCodigoPostalEmmisor, GlobalCorreoEmisor, "GT", GlobalDepartamentoEmisor, GlobalMunicipioEmisor, GlobalDireccionEmisor, GlobalNitEmisor, GlobalNombreEmisor, GlobalNombreComercialEmisor)
        If NIT.Length = 13 Then
            request.Datos_receptor(NIT, cleanDataFEL(NombreCliente), getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, cleanDataFEL(DireccionCliente), "CUI")
        Else
            request.Datos_receptor(NIT, cleanDataFEL(NombreCliente), getCodigoPostal(MunicipioCliente, DepartamentoCliente), EmailCliente, "GT", DepartamentoCliente, MunicipioCliente, cleanDataFEL(DireccionCliente), "")
        End If

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
                                    ISNULL(PRODUCTOS.EXENTO,0) AS EXENTO,
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
                    ' varTotalVenta = varTotalVenta + CType(dr(9), Double)
                    varItem = varItem + 1

                    doc = dr(14).ToString
                    corr = CType(dr(15), Double)

                    Dim tipoprod As String = dr(10).ToString
                    Dim medida As String = "UND" 'dr(2).ToString // EL FORMATO NO PERMITE LAS CODMEDIDAS
                    Dim cantidad As String = dr(3).ToString
                    Dim desprod As String = cleanDataFEL(dr(1).ToString)
                    If GlobalFELEnviaCodigoProducto = "SI" Then
                        desprod = dr(0).ToString & " || " & dr(1).ToString
                    Else
                        desprod = dr(1).ToString
                    End If
                    Dim precio As Double = CType(dr(7), Double)
                    Dim totalprecio As Double = precio * Double.Parse(cantidad)
                    varTotalVenta = varTotalVenta + totalprecio

                    Dim descuento As Double = 0
                    Dim iva As Double = 0

                    'SI EL PRODUCTO ES EXENTO (1) o AFECTO (0)

                    If CType(dr(13), Integer) = 0 Then

                        iva = totalprecio - (totalprecio / GlobalConfigIVA) '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva
                        'AGREGA ITEM POR ITEM A LA FACTURA // AFECTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 1, "", totalsiniva.ToString, iva.ToString)
                    Else
                        varFraseExentos = 1
                        iva = 0 '// 0 = si el producto es exento
                        Dim totalsiniva As Double = totalprecio - iva
                        'AGREGA ITEM // EXENTO DE IVA
                        request.Item_un_impuesto(tipoprod, medida, cantidad, "*" & desprod, varItem, precio.ToString, totalprecio.ToString, descuento.ToString, totalprecio.ToString, "IVA", 2, "", totalsiniva.ToString, iva.ToString)
                    End If

                    varTotalIva = varTotalIva + iva
                Loop


                request.Frases(GlobalFraseFEL, GlobalEscenarioFEL, "", "")

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

                'DATOS FRASES ADICIONALES DE LA FACTURA / VENDEDOR, FRASES, ETC
                request.Adendas("SERIEINTERNO", coddoc)
                request.Adendas("NUMEROINTERNO", correlativo.ToString)
                request.Adendas("VENDEDOR", GlobalSelectedNomven.Replace("&", ""))
                request.Adendas("NOTAS", obs)
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
                    r = request.Datos_anulacion(fechaEmision, fechaAnulacion, nitCliente, GlobalNitEmisor, "ANULACION", uudiFactura)

                    response = request.enviar_anulacion_fel(GlobalCertificacionUsuario, GlobalCertificacionLlave, "ANULACION", "", GlobalFirmaAlias, GlobalFirmaLlave, True)

                    If obtenerResultado(response) = True Then
                        r = True
                    Else
                        MsgBox("Error anulacion: " & response)
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
        Dim ST As String = "O"

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
                                    DOCUMENTOS.TOTALPRECIO AS FRASE1, 
                                    ISNULL(DOCPRODUCTOS.OBS, ' ') AS NOSERIE, 
                                    MUNICIPIOS.DESMUNICIPIO, 
                                    ISNULL(CLIENTES.TELEFONOCLIENTE, 'SN') AS TELCLIENTE, 
                                    ISNULL(DOCUMENTOS.TOTALTARJETA, 0) As TOTALTARJETA,
                                    ISNULL(DOCUMENTOS.RECARGOTARJETA, 0) As RECARGOTARJETA, 
                                    concat(ISNULL(DOCUMENTOS.DIRENTREGA,'SN'), ' // OBS:' , ISNULL(DOCUMENTOS.OBS,'SN')) AS DIRENTREGA, 
                                    ISNULL(DOCPRODUCTOS.EXENTO, 0) As EXENTO, 
                                    DOCUMENTOS.FEL_FECHA AS OBS,
                                    DOCUMENTOS.VENCIMIENTO,
                                    DOCUMENTOS.DIASCREDITO,
                                    CONCAT(DOCUMENTOS.CODDOC,'-',DOCUMENTOS.CORRELATIVO) AS DOCUMENTO,
                                    ISNULL(DOCPRODUCTOS.DESCUENTO,0) AS DESCUENTO, 
                                    ISNULL(FEL_CREDENCIALES.EMISOR_NOMBRECOMECIAL,'') AS NOMBRECORMERCIAL,
									ISNULL(FEL_CREDENCIALES.EMISOR_DIRECCION,'') AS DIRECCION,
                                    DOCUMENTOS.STATUS                                   
                            From EMPLEADOS RIGHT OUTER Join
                            DOCUMENTOS On EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN And EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER Join
                            MUNICIPIOS RIGHT OUTER Join
                            CLIENTES On MUNICIPIOS.CODMUNICIPIO = CLIENTES.CODMUNICIPIO ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT And DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER Join
                            EMPRESAS On DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER Join
                            TIPODOCUMENTOS On DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC And DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER Join
                            DOCPRODUCTOS On DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO And DOCUMENTOS.MES = DOCPRODUCTOS.MES And
                            DOCUMENTOS.DIA = DOCPRODUCTOS.DIA And DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC And DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO CROSS JOIN FEL_CREDENCIALES
							FEL_CREDENCIALES
                            Where (DOCUMENTOS.EMPNIT = @E)  And (DOCUMENTOS.CODDOC = @D) And 
                            (DOCUMENTOS.CORRELATIVO = @N)"
                Dim cmd As New SqlCommand(qry, cn)

                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", Coddoc)
                cmd.Parameters.AddWithValue("@N", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    Dim exento As Double = Double.Parse(dr(32))
                    Dim desprod As String = dr(4).ToString
                    If exento > 0 Then
                        desprod = "* " & dr(4).ToString
                    End If
                    ST = dr(40).ToString  'STATUS
                    GlobalSelectedFEL_UUDI = dr(23).ToString
                    tblTicket.Rows.Add(New Object() {
                                     Date.Parse(dr(0).ToString),'fecha
                                  dr(1).ToString,'coddoc
                                  Double.Parse(dr(2).ToString),'correlativo
                                  dr(3).ToString,'codprod
                                  desprod,'desprod
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
                                  Letras(Double.Parse(dr(25)).ToString).ToUpper & "QUETZALES", 'dr(25).ToString, 'FRASE1
                                  dr(26).ToString, 'noserie
                                  dr(27), 'DESMUNICIPIO
                                  dr(28),  'TELCLIENTE
                                  Double.Parse(dr(29)), 'TOTALTARJETA
                                  Double.Parse(dr(30)), 'RECARGOTARJETA
                                  dr(31).ToString, 'DIRECCION DE ENTREGA
                                  exento, 'MONTO EXENTO EN DOCPRODUCTOS
                                  dr(33).ToString(),    'OBSERVACIONES
                                  Today.Day.ToString,'FECHA DD 
                                  Today.Month.ToString, 'FECHA MM
                                  Today.Year.ToString, 'FECHA YY
                                  Date.Parse(dr(34)), 'FECHA VENCE
                                  Integer.Parse(dr(35)), 'DIAS CREDITO
                                  dr(36).ToString,     'DOCUMENTO
                                  Double.Parse(dr(37)),  'DESCUENTO
                                  dr(38).ToString,  'DIRECCION FEL
                                  dr(39).ToString   'NOMBRE COMERCIAL FEL
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

            ' MsgBox(ST)

            If ST = "A" Then


                Try
                    'INTENTA ABRIR UN FORMATO LLAMADO FACTURA, SI NO EXISTE, LO CREA EN BASE AL TEMPLATE INTERNO
                    report.LoadLayout(Application.StartupPath + "\Reports\FACTURAFEL_ANULADA.repx")
                Catch exs As Exception
                    'GUARDA EL TEMPLATE CON EL NOMBRE FACTURA
                    report.SaveLayout(Application.StartupPath + "\Reports\FACTURAFEL_ANULADA.repx")
                End Try
            Else
                Try
                    'INTENTA ABRIR UN FORMATO LLAMADO FACTURA, SI NO EXISTE, LO CREA EN BASE AL TEMPLATE INTERNO
                    report.LoadLayout(Application.StartupPath + "\Reports\FACTURAFEL.repx")
                Catch exs As Exception
                    'GUARDA EL TEMPLATE CON EL NOMBRE FACTURA
                    report.SaveLayout(Application.StartupPath + "\Reports\FACTURAFEL.repx")
                End Try
            End If


            report.DataSource = tblTicket
            report.DataAdapter = Adapter
            report.DataMember = "tblTicket"


            Dim tool As ReportPrintTool = New ReportPrintTool(report)
            report.CreateDocument()

            If Form1.checkDOM.Checked = True Then

                'Dim controlcobrar As New UserControlCobrar

                If CHBOXZ7 = True Then
                    report.ExportToPdf("\\10.243.0.4\fac_dom\" + Coddoc + "-" + Correlativo.ToString + ".pdf")
                Else
                    report.ExportToPdf("\\10.243.0.17\fac_dom\" + Coddoc + "-" + Correlativo.ToString + ".pdf")
                End If

            End If



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

        'Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
        'formato = objTipoDoc.getFormatoDocumento(Coddoc)

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
                                    (DOCUMENTOS.CORRELATIVO + 100000000) AS AUTORIZACION, 
                                    ISNULL(TIPODOCUMENTOS.RESOLUCION, 'SN') AS RESOLUCION, 
                                    DOCUMENTOS.TOTALPRECIO AS FRASE1, 
                                    ISNULL(DOCPRODUCTOS.OBS, ' ') AS NOSERIE, 
                                    MUNICIPIOS.DESMUNICIPIO, ISNULL(CLIENTES.TELEFONOCLIENTE, 'SN') AS TELCLIENTE, 
                                    ISNULL(DOCUMENTOS.TOTALTARJETA, 0) As TOTALTARJETA, ISNULL(DOCUMENTOS.RECARGOTARJETA, 0) As RECARGOTARJETA, 
                                    concat(ISNULL(DOCUMENTOS.DIRENTREGA,'SN'), ' // OBS:' , ISNULL(DOCUMENTOS.OBS,'SN')) AS DIRENTREGA, 
                                    ISNULL(DOCPRODUCTOS.EXENTO, 0) As EXENTO, 
                                    DOCUMENTOS.OBS AS OBS,
                                    DOCUMENTOS.VENCIMIENTO,
                                    DOCUMENTOS.DIASCREDITO,
                                    ISNULL(DOCPRODUCTOS.DESCUENTO,0) AS DESCUENTO
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
                    Dim exento As Double = Double.Parse(dr(32))
                    Dim desprod As String = dr(4).ToString
                    If exento > 0 Then
                        desprod = "* " & dr(4).ToString
                    End If
                    GlobalSelectedFEL_UUDI = dr(23).ToString
                    tblTicket.Rows.Add(New Object() {
                                     Date.Parse(dr(0).ToString),'fecha
                                  dr(1).ToString,'coddoc
                                  Double.Parse(dr(2).ToString),'correlativo
                                  dr(3).ToString,'codprod
                                  desprod,'desprod
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
                                  Letras(Double.Parse(dr(25)).ToString).ToUpper & "QUETZALES", 'dr(25).ToString, 'FRASE1
                                  dr(26).ToString, 'noserie
                                  dr(27), 'DESMUNICIPIO
                                  dr(28),  'TELCLIENTE
                                  Double.Parse(dr(29)), 'TOTALTARJETA
                                  Double.Parse(dr(30)), 'RECARGOTARJETA
                                  dr(31).ToString, 'DIRECCION DE ENTREGA
                                  exento, 'MONTO EXENTO EN DOCPRODUCTOS
                                  dr(33).ToString(),    'OBSERVACIONES
                                  Today.Day.ToString,'FECHA DD 
                                  Today.Month.ToString, 'FECHA MM
                                  Today.Year.ToString, 'FECHA YY
                                  Date.Parse(dr(34)), 'FECHA VENCE
                                  Integer.Parse(dr(35)), 'DIAS CREDITO
                                  "SN",    'DOCUMENTO
                                  Double.Parse(dr(36))  'DESCUENTO
                                                                     })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmd.Dispose()
                'cn.Close()
            End Using

            'MsgBox("CONSULTA LEIDA")

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


    Public Function rptDevolucionFEL(ByVal Coddoc As String, ByVal Correlativo As Double, ByVal imp As Integer) As Boolean

        Dim result As Boolean

        Dim formato As String = "SN"

        Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
        formato = objTipoDoc.getFormatoDocumento(Coddoc)

        Dim tblTicket As New VENTASDataSet.tblTicketNCDataTable

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
                                    DOCUMENTOS.TOTALPRECIO AS FRASE1, 
                                    ISNULL(DOCPRODUCTOS.OBS, ' ') AS NOSERIE, 
                                    MUNICIPIOS.DESMUNICIPIO, ISNULL(CLIENTES.TELEFONOCLIENTE, 'SN') AS TELCLIENTE, 
                                    ISNULL(DOCUMENTOS.TOTALTARJETA, 0) As TOTALTARJETA,
                                    ISNULL(DOCUMENTOS.RECARGOTARJETA, 0) As RECARGOTARJETA, 
                                    concat(ISNULL(DOCUMENTOS.DIRENTREGA,'SN'), ' // OBS:' , ISNULL(DOCUMENTOS.OBS,'SN')) AS DIRENTREGA, 
                                    ISNULL(DOCPRODUCTOS.EXENTO, 0) As EXENTO, 
                                    DOCUMENTOS.FEL_FECHA AS OBS,
                                    DOCUMENTOS.VENCIMIENTO,
                                    DOCUMENTOS.DIASCREDITO,
                                    CONCAT(DOCUMENTOS.CODDOC,'-',DOCUMENTOS.CORRELATIVO) AS DOCUMENTO,
									ISNULL(FEL_CREDENCIALES.EMISOR_NOMBRECOMECIAL,'') AS NOMBRECOMERCIAL,
									ISNULL(FEL_CREDENCIALES.EMISOR_DIRECCION,'') AS DIRECCION
                            From EMPLEADOS RIGHT OUTER Join
                            DOCUMENTOS On EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN And EMPLEADOS.EMPNIT = DOCUMENTOS.EMPNIT LEFT OUTER Join
                            MUNICIPIOS RIGHT OUTER Join
                            CLIENTES On MUNICIPIOS.CODMUNICIPIO = CLIENTES.CODMUNICIPIO ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT And DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER Join
                            EMPRESAS On DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER Join
                            TIPODOCUMENTOS On DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC And DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT LEFT OUTER Join
                            DOCPRODUCTOS On DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And DOCUMENTOS.ANIO = DOCPRODUCTOS.ANIO And DOCUMENTOS.MES = DOCPRODUCTOS.MES And
                            DOCUMENTOS.DIA = DOCPRODUCTOS.DIA And DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC And DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO CROSS JOIN FEL_CREDENCIALES
							FEL_CREDENCIALES
                            Where (DOCUMENTOS.EMPNIT = @E)  And (DOCUMENTOS.CODDOC = @D) And 
                            (DOCUMENTOS.CORRELATIVO = @N)"
                Dim cmd As New SqlCommand(qry, cn)

                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", Coddoc)
                cmd.Parameters.AddWithValue("@N", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    Dim exento As Double = Double.Parse(dr(32))
                    Dim desprod As String = dr(4).ToString
                    If exento > 0 Then
                        desprod = "* " & dr(4).ToString
                    End If
                    GlobalSelectedFEL_UUDI = dr(23).ToString
                    tblTicket.Rows.Add(New Object() {
                                     Date.Parse(dr(0).ToString),'fecha
                                  dr(1).ToString,'coddoc
                                  Double.Parse(dr(2).ToString),'correlativo
                                  dr(3).ToString,'codprod
                                  desprod,'desprod
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
                                  Letras(Double.Parse(dr(25)).ToString).ToUpper & "QUETZALES", 'dr(25).ToString, 'FRASE1
                                  dr(26).ToString, 'noserie
                                  dr(27), 'DESMUNICIPIO
                                  dr(28),  'TELCLIENTE
                                  Double.Parse(dr(29)), 'TOTALTARJETA
                                  Double.Parse(dr(30)), 'RECARGOTARJETA
                                  dr(31).ToString, 'DIRECCION DE ENTREGA
                                  exento, 'MONTO EXENTO EN DOCPRODUCTOS
                                  dr(33).ToString(),    'OBSERVACIONES
                                  Today.Day.ToString,'FECHA DD 
                                  Today.Month.ToString, 'FECHA MM
                                  Today.Year.ToString, 'FECHA YY
                                  Date.Parse(dr(34)), 'FECHA VENCE
                                  Integer.Parse(dr(35)), 'DIAS CREDITO
                                  dr(36).ToString,
                                  dr(37).ToString,
                                  dr(38).ToString
                                       })
                    TotalVentaFAC = TotalVentaFAC + Double.Parse(dr(16)) 'SUMA EL TOTAL VENTA PARA LEER LA CANTIDAD EN LETRAS
                Loop
                dr.Close()
                dr = Nothing
                cmd.Dispose()
                'cn.Close()
            End Using

            Dim Adapter As New SqlDataAdapter
            Dim report As New rptDevolucionFEL

            Try
                'INTENTA ABRIR UN FORMATO LLAMADO FACTURA, SI NO EXISTE, LO CREA EN BASE AL TEMPLATE INTERNO
                report.LoadLayout(Application.StartupPath + "\Reports\NOTACREDITO_FEL.repx")
            Catch exs As Exception
                'GUARDA EL TEMPLATE CON EL NOMBRE FACTURA
                report.SaveLayout(Application.StartupPath + "\Reports\NOTACREDITO_FEL.repx")
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



    Public Function getTblFacturacionFEL(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable




        Return tbl

    End Function



    Public Function autoCertificacionFEL() As Boolean
        Dim r As Boolean

        Dim objFel As New classFEL

        'INICIO LEYENDO LOS DOCUMENTOS NO CERTIFICADOS
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                SelectedCoddoc = ""
                SelectedCorrelativo = 0
                Dim SelectedNitCliente As String = ""
                Dim SelectedNomCliente As String = ""


                Dim cmd As New SqlCommand("SELECT 
                        TIPODOCUMENTOS.TIPODOC, 
                        DOCUMENTOS.EMPNIT, 
                        DOCUMENTOS.CODDOC, 
                        DOCUMENTOS.CORRELATIVO, 
                        DOCUMENTOS.DOC_NIT, 
                        DOCUMENTOS.DOC_NOMCLIE, 
                        DOCUMENTOS.DOC_DIRCLIE, 
                        DOCUMENTOS.FEL_UUDI, 
                        DOCUMENTOS.STATUS, 
                        TIPODOCUMENTOS.TIPODOC
                            FROM DOCUMENTOS LEFT OUTER JOIN
                            TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                            WHERE (DOCUMENTOS.EMPNIT = @E) 
                            AND (DOCUMENTOS.STATUS <> 'A') 
                            AND (TIPODOCUMENTOS.TIPODOC IN ('FEF','FEC','FES')) 
                            AND (DOCUMENTOS.FEL_UUDI IS NULL)", cn)

                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    'OBTIENE LOS VALORES DEL DOCUMENTO LEIDO
                    SelectedCoddoc = dr(2).ToString
                    SelectedCorrelativo = Double.Parse(dr(3).ToString)
                    SelectedNitCliente = dr(4).ToString
                    SelectedNomCliente = dr(5).ToString
                    '***************************************************************************
                    '***************************************************************************
                    'VERIFICA EL TIPO DE DOCUMENTO
                    Select Case dr(0).ToString

                        'CERTIFICA LAS FACTURAS NORMALES
                        Case "FEF"
                            Dim f As String = DateTime.Now.ToShortDateString()
                            Dim fel As New classFEL
                            If fel.facturaIVA_Normal(f, SelectedCoddoc, SelectedCorrelativo, SelectedNitCliente, SelectedNomCliente, "", "CIUDAD", "GUATEMALA", "GUATEMALA") = True Then

                                'actualiza los datos FEL del documento
                                GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                                GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                                GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                                'actualiza el documento interno con los datos de FEL
                                If fel.updateDocumentoFEL(GlobalEmpNit, SelectedCoddoc, SelectedCorrelativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                                    Call Form1.Mensaje("Serie FEL asignada a la factura del sistema" + dr(2).ToString & "-" & dr(3).ToString)
                                Else
                                    Call Form1.Mensaje("No se logró actualizar el correlativo en el documento local")
                                End If
                            Else
                                Form1.Mensaje("Error al certificar: " + dr(2).ToString & "-" & dr(3).ToString)
                            End If

                        'CERTIFICA LAS FACTURAS CAMBIARIAS
                        Case "FEC"
                            Dim f As String = DateTime.Now.ToShortDateString()
                            Dim fvence As Date = Date.Now.AddMonths(2)

                            Dim fel As New classFEL
                            If fel.facturaIVA_Cambiaria(f, SelectedCoddoc, SelectedCorrelativo, SelectedNitCliente, SelectedNomCliente, "", "CIUDAD", "GUATEMALA", "GUATEMALA", fvence, 3) = True Then

                                'actualiza los datos FEL del documento
                                GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                                GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                                GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                                'actualiza el documento interno con los datos de FEL
                                If fel.updateDocumentoFEL(GlobalEmpNit, SelectedCoddoc, SelectedCorrelativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                                    Call Form1.Mensaje("Serie FEL asignada a la factura del sistema" + dr(2).ToString & "-" & dr(3).ToString)
                                Else
                                    Call Form1.Mensaje("No se logró actualizar el correlativo en el documento local")
                                End If
                            Else
                                Form1.Mensaje("Error al certificar: " + GlobalDesError)
                            End If
                    End Select

                    '***************************************************************************
                    '***************************************************************************
                Loop

            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try

        End Using

        Return r
    End Function


End Class
