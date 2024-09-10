Imports System.Data.SqlClient

Public Class classCxp

    Sub New()

    End Sub

    Dim objQry As New classQuerys

    Public Function InsertarTablaCuotas(
                                       ByVal empnit As String,
                                       ByVal codclie As Integer,
                                       ByVal nitclie As String,
                                       ByVal fecha As Date,
                                       ByVal coddoc As String,
                                       ByVal correlativo As Double,
                                       ByVal nocuota As Integer,
                                       ByVal cuota As Double,
                                       ByVal fechapago As Date
                                       ) As Integer

        Dim result As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("INSERT INTO DOCCUOTAS (EMPNIT,CODCLIE,NITCLIE,FECHA,CODDOC,CORRELATIVO,NOCUOTA,CUOTA,FECHAPAGO,INTERES,TOTALPAGAR,ABONO,PAGADO) 
                                        VALUES (@EMPNIT,@CODCLIE,@NITCLIE,@FECHA,@CODDOC,@CORRELATIVO,@NOCUOTA,@CUOTA,@FECHAPAGO,0,0,0,0)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODCLIE", codclie)
                cmd.Parameters.AddWithValue("@NITCLIE", nitclie)
                cmd.Parameters.AddWithValue("@FECHA", fecha)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@NOCUOTA", nocuota)
                cmd.Parameters.AddWithValue("@CUOTA", cuota)
                cmd.Parameters.AddWithValue("@FECHAPAGO ", fechapago)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = 1

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = 0
            End Try

        End Using

        Return result

    End Function

    'establece las cuotas pendientes de pago en facturas en cuotas
    Public Function tblListaCuotasPendientes(ByVal Empnit As String) As DataTable
        Dim tbl As New DSCxc.tblDocCuotasPendientesDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT DOCCUOTAS.NITCLIE, 
                                              CLIENTES.NOMBRECLIENTE, 
                                              CLIENTES.TELEFONOCLIENTE, 
                                              DOCCUOTAS.NOCUOTA, 
                                              DOCCUOTAS.FECHAPAGO, 
                                              DOCCUOTAS.CUOTA, 
                                              DOCCUOTAS.CODDOC, 
                                              DOCCUOTAS.CORRELATIVO, 
                                              DOCCUOTAS.CODCLIE
                                        FROM DOCCUOTAS LEFT OUTER JOIN CLIENTES ON DOCCUOTAS.CODCLIE = CLIENTES.CODCLIENTE AND DOCCUOTAS.EMPNIT = CLIENTES.EMPNIT
                                        WHERE (DOCCUOTAS.EMPNIT = @EMPNIT) AND (DOCCUOTAS.PAGADO = 0)", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", Empnit)

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
                        FormatCurrency(dr(5)).ToString
                })
            Loop
            dr.Close()
            dr.Dispose()

            cn.Close()
        End Using

        Return tbl
    End Function


    'carga la lista de facturas pendientes de cobro
    Public Function tblListaFacturasPendientes(ByVal Empnit As String) As DataTable
        tblListaFacturasPendientes = New DSGeneral.tblFacPendSaldoDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT DOCUMENTOS.DOC_NIT, DOCUMENTOS.DOC_NOMCLIE, DOCUMENTOS.DOC_DIRCLIE, DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, 
                                                DOCUMENTOS.CORRELATIVO, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.DOC_SALDO, DOCUMENTOS.DOC_ABONO, DOCUMENTOS.CODCLIENTE, DOCUMENTOS.VENCIMIENTO
                            FROM DOCUMENTOS LEFT OUTER JOIN
                            TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                            WHERE (TIPODOCUMENTOS.TIPODOC = 'COM') 
                                AND (DOCUMENTOS.CONCRE = 'CRE') 
                                AND (DOCUMENTOS.DOC_SALDO > 0) 
                                AND (DOCUMENTOS.EMPNIT = @empnit) 
                                AND (DOCUMENTOS.STATUS <> 'A')
                            ORDER BY DOCUMENTOS.FECHA ASC", cn)

                cmd.Parameters.AddWithValue("@empnit", Empnit)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tblListaFacturasPendientes.Rows.Add(New Object() {
                                    dr(0).ToString,'NIT
                                    dr(1).ToString,'CLIENTE
                                    dr(2).ToString,'DIRECCIÓN
                                    dr(3).ToString,'FECHA
                                    dr(4).ToString,'CODDOC
                                    dr(5).ToString,'CORRELATIVO
                                    FormatCurrency(dr(6)).ToString,'TOTAL VENTA
                                    FormatCurrency(dr(7)).ToString,'SALDO
                                    FormatCurrency(dr(8)).ToString,'ABONOS
                                    CType(dr(9), Integer), ' COD CLIENTE
                                    dr(10), 'FECHA VENCIMIENTO
                                    Double.Parse(dr(7)), 'VAL SALDO
                                    Double.Parse(dr(8)), 'VAL ABONOS
                                    Double.Parse(dr(6)) 'VAL IMPORTE
                                    })
                Loop
                dr.Close()
                cmd.Dispose()
                cn.Close()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                Return Nothing
            End Try

        End Using


    End Function

    'carga la lista de proveedores con saldo
    Public Function tblProveedoresSaldo(ByVal empnit As String) As DataTable
        Dim tbl As New DataTable
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROV as CODIGO,NIT,EMPRESA,TELEMPRESA,CONTACTO,TELCONTACTO, SALDO FROM PROVEEDORES WHERE EMPNIT=@E AND SALDO > 0", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
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
    'obtiene el total del saldo pendiente
    Public Function tblTotalSaldo(ByVal Empnit As String) As Double

        Dim saldo As Double = 0

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT SUM(DOCUMENTOS.DOC_SALDO) AS TOTAL
                                        FROM DOCUMENTOS LEFT OUTER JOIN
                                        TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                        WHERE (DOCUMENTOS.EMPNIT = @empnit) 
                                            AND (TIPODOCUMENTOS.TIPODOC = 'COM') 
                                            AND (DOCUMENTOS.STATUS <> 'A')
                                            AND (DOCUMENTOS.DOC_SALDO > 0)
                                            AND (DOCUMENTOS.CONCRE = 'CRE')", cn)
                cmd.Parameters.AddWithValue("@empnit", Empnit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    saldo = Double.Parse(dr(0))
                End If
                dr.Close()
                cmd.Dispose()
                cn.Close()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                saldo = 0
            End Try
        End Using

        Return saldo


    End Function

    'guarda un nuevo pago
    Public Function GuardarNuevoPago(
                     ByVal Empnit As String,
                     ByVal CodCliente As Integer,
                     ByVal Coddoc As String,
                     ByVal Correlativo As Double,
                     ByVal Abono As Double,
                     ByVal FechaCobro As Date,
                     ByVal Obs As String,
                     ByVal CodVen As Integer,
                     ByVal NitClie As String,
                     ByVal NomClie As String,
                     ByVal Saldo As Double,
                     ByVal AbonoActual As Double,
                     ByVal CoddocFac As String,
                     ByVal CorrelativoFac As Double,
                     Optional NoCuota As Integer = 0,
                     Optional tipopago As String = "",
                     Optional nodocpago As String = ""
                                ) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try

                Dim cmd As New SqlCommand(objQry.queryReciboPagoProveedor, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", FechaCobro.Year)
                cmd.Parameters.AddWithValue("@MES", FechaCobro.Month)
                cmd.Parameters.AddWithValue("@DIA", FechaCobro.Day)
                cmd.Parameters.AddWithValue("@FECHA", FechaCobro)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@PAGO", Abono)
                cmd.Parameters.AddWithValue("@CONCRE", "CON")
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                cmd.Parameters.AddWithValue("@CODCLIENTE", CodCliente)
                cmd.Parameters.AddWithValue("@NIT", NitClie)
                cmd.Parameters.AddWithValue("@NOMBRE", NomClie)
                cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                cmd.Parameters.AddWithValue("@TOTALCOSTO", 0)
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Abono)
                cmd.Parameters.AddWithValue("@CODEMBARQUE", "GENERAL")
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@SERIEFAC", CoddocFac)
                cmd.Parameters.AddWithValue("@NOFAC", CorrelativoFac)
                cmd.Parameters.AddWithValue("@CODVEN", CodVen)
                cmd.Parameters.AddWithValue("@OBS", Obs)
                cmd.Parameters.AddWithValue("@SALDO", Saldo)
                cmd.Parameters.AddWithValue("@ABONO", AbonoActual)
                cmd.Parameters.AddWithValue("@TIPOPAGO", tipopago)
                cmd.Parameters.AddWithValue("@NODOCPAGO", nodocpago)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                If NoCuota > 0 Then
                    Dim cmdcuota As New SqlCommand("UPDATE DOCCUOTAS SET ABONO=@ABONO, PAGADO=@PAGADO, FECHAPAGADO=@FECHAPAGADO WHERE EMPNIT=@EMPNIT AND CODCLIE=@CODCLIE AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO AND NOCUOTA=@NOCUOTA", cn)
                    cmdcuota.Parameters.AddWithValue("@ABONO", Abono)
                    cmdcuota.Parameters.AddWithValue("@PAGADO", Abono)
                    cmdcuota.Parameters.AddWithValue("@FECHAPAGADO", FechaCobro)
                    cmdcuota.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmdcuota.Parameters.AddWithValue("@CODCLIE", CodCliente)
                    cmdcuota.Parameters.AddWithValue("@CODDOC", CoddocFac)
                    cmdcuota.Parameters.AddWithValue("@CORRELATIVO", CorrelativoFac)
                    cmdcuota.Parameters.AddWithValue("@NOCUOTA", NoCuota)
                    cmdcuota.ExecuteNonQuery()

                End If




                cn.Close()
                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

        End Using

        Return result

    End Function


    'carga los datos de un recibo de pago de proveedor
    Public Function tblRecibo(ByVal Empnit As String, ByVal Coddoc As String, ByVal Correlativo As Double, ByVal Fecha As Date) As DataTable
        Dim tbl As New DSGeneral.tblReciboAbonoDataTable

        Try
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("sp_sel_documentos_recibo", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", Empnit)
            cmd.Parameters.AddWithValue("@coddoc", Coddoc)
            cmd.Parameters.AddWithValue("@correlativo", Correlativo)
            cmd.Parameters.AddWithValue("@anio", Fecha.Year)
            cmd.Parameters.AddWithValue("@mes", Fecha.Month)
            cmd.Parameters.AddWithValue("@dia", Fecha.Day)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                                dr(0).ToString,'NIT
                                dr(1).ToString,'CLIENTE
                                dr(2).ToString,'DIRECCIÓN
                                dr(3).ToString,'FECHA
                                dr(4).ToString,'CODDOC
                                dr(5).ToString,'CORRELATIVO
                                FormatCurrency(dr(6)).ToString,'TOTAL VENTA
                                FormatCurrency(dr(7)).ToString,'SALDO
                                FormatCurrency(dr(8)).ToString,'ABONOS
                                CType(dr(9), Integer) ' COD CLIENTE
                                })
            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

            Return tbl

        Catch ex As Exception
            GlobalDesError = ex.ToString
            Return Nothing
        End Try

    End Function

    'aumenta el saldo de un proveedor
    Public Function AumentarSaldoProveedor(ByVal Empnit As String, ByVal codprov As Integer, ByVal Importe As Double) As Boolean
        Try
            Call AbrirConexionSql()

            Dim saldoactual As Double

            Dim cmd As New SqlCommand("SELECT SALDO FROM PROVEEDORES WHERE EMPNIT='" & Empnit & "' AND CODPROV=" & codprov, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    saldoactual = Double.Parse(dr(0))
                End If
            Catch ex As Exception
                saldoactual = 0
            End Try
            dr.Close()
            cmd.Dispose()


            Dim cmdUp As New SqlCommand("UPDATE PROVEEDORES SET SALDO=@SALDOFINAL WHERE EMPNIT='" & Empnit & "' AND CODPROV=" & codprov, cn)
            cmdUp.Parameters.AddWithValue("@SALDOFINAL", saldoactual + Importe)
            cmdUp.ExecuteNonQuery()
            cmdUp.Dispose()
            Return True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            Return False
        End Try

    End Function

    'disminuye el saldo de un cliente
    Public Function DisminuirSaldoProveedor(ByVal Empnit As String, ByVal codprov As Integer, ByVal Importe As Double) As Boolean
        Try

            Call AbrirConexionSql()

            Dim saldoactual As Double

            Dim cmd As New SqlCommand("SELECT isnull(SALDO,0) AS SALDO FROM PROVEEDORES WHERE EMPNIT='" & Empnit & "' AND CODPROV=" & codprov, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    saldoactual = Double.Parse(dr(0))
                End If
            Catch ex As Exception
                saldoactual = 0
            End Try
            dr.Close()
            cmd.Dispose()

            Dim cmdUp As New SqlCommand("UPDATE PROVEEDORES SET SALDO=@SALDOFINAL WHERE EMPNIT='" & Empnit & "' AND CODPROV=" & codprov, cn)
            cmdUp.Parameters.AddWithValue("@SALDOFINAL", saldoactual - Importe)
            cmdUp.ExecuteNonQuery()
            cmdUp.Dispose()
            Return True

        Catch ex As Exception

            Return False
        End Try

    End Function

    'listado de abonos a una factura dada
    Public Function tblAbonosFactura(ByVal Empnit As String, ByVal Coddoc As String, ByVal Correlativo As Double) As DataTable
        Dim tbl As New DSGeneral.tblAbonosFacturaDataTable

        Try
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("SELECT DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.TOTALPRECIO, VENDEDORES.NOMVEN
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         VENDEDORES ON DOCUMENTOS.CODVEN = VENDEDORES.CODVEN AND DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                        WHERE (TIPODOCUMENTOS.TIPODOC = 'RCP') AND (DOCUMENTOS.SERIEFAC = @coddoc) AND (DOCUMENTOS.NOFAC = @correlativo) AND (DOCUMENTOS.EMPNIT = @empnit) ", cn)

            cmd.Parameters.AddWithValue("@empnit", Empnit)
            cmd.Parameters.AddWithValue("@coddoc", Coddoc)
            cmd.Parameters.AddWithValue("@correlativo", Correlativo)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                                Date.Parse(dr(0)),'FECHA
                                dr(1).ToString,'CODDOC
                                dr(2).ToString,'CORRELATIVO
                                FormatCurrency(dr(3)).ToString,'TOTAL PRECIO
                                dr(4).ToString'VENDEDOR
                                     })
            Loop
            dr.Close()
            cmd.Dispose()
            cn.Close()

            Return tbl

        Catch ex As Exception
            GlobalDesError = ex.ToString

            Return Nothing
        End Try

    End Function


    'elimina un recibo
    Public Function EliminarRecibo(ByVal Empnit As String, ByVal codprov As Integer, ByVal Coddoc As String, ByVal Correlativo As Double, ByVal Importe As Double) As Boolean
        Dim nitclie As Integer = codprov

        Call AbrirConexionSql()
        Dim SerieFac As String, NoFac As Double

        '1) OBTENER LOS DATOS DE LA FACTURA ASOCIADA AL RECIBO
        Try
            Dim cmddf As New SqlCommand("SELECT SERIEFAC, NOFAC FROM DOCUMENTOS WHERE EMPNIT=@empnit AND CODDOC=@coddoc AND CORRELATIVO=@correlativo", cn)
            cmddf.Parameters.AddWithValue("@empnit", Empnit)
            cmddf.Parameters.AddWithValue("@coddoc", Coddoc)
            cmddf.Parameters.AddWithValue("@correlativo", Correlativo)
            Dim drdf As SqlDataReader = cmddf.ExecuteReader
            drdf.Read()
            If drdf.HasRows Then
                SerieFac = drdf(0).ToString
                NoFac = Double.Parse(drdf(1))
            End If
            drdf.Close()
            cmddf.Dispose()

            GoTo 2

        Catch ex As Exception
            GoTo FINALIZAR
        End Try

2:
        Dim SaldoFac, AbonoFac As Double

        Try

            '2) QUITAR EL ABONO ASOCIADO A LA FACTURA
            '2.1) obtiene el saldo y abonos de la factura
            Dim cmdsalab As New SqlCommand("SELECT DOC_SALDO, DOC_ABONO FROM DOCUMENTOS WHERE EMPNIT=@empnit AND CODDOC=@coddoc AND CORRELATIVO=@correlativo", cn)
            cmdsalab.Parameters.AddWithValue("@empnit", Empnit)
            cmdsalab.Parameters.AddWithValue("@coddoc", SerieFac)
            cmdsalab.Parameters.AddWithValue("@correlativo", NoFac)
            Dim drSalAb As SqlDataReader = cmdsalab.ExecuteReader
            drSalAb.Read()
            If drSalAb.HasRows Then
                SaldoFac = Double.Parse(drSalAb(0))
                AbonoFac = Double.Parse(drSalAb(1))
            End If
            drSalAb.Close()
            cmdsalab.Dispose()

            '2.2) actualiza el saldo al quitar el abono
            Dim SaldoNuevo, AbonoNuevo As Double
            SaldoNuevo = SaldoFac + Importe
            AbonoNuevo = AbonoFac - Importe

            Dim cmdupdsaldo As New SqlCommand("UPDATE DOCUMENTOS SET DOC_SALDO=@saldo, DOC_ABONO=@abono WHERE EMPNIT=@empnit AND CODDOC=@coddoc AND CORRELATIVO=@correlativo", cn)
            cmdupdsaldo.Parameters.AddWithValue("@empnit", Empnit)
            cmdupdsaldo.Parameters.AddWithValue("@coddoc", SerieFac)
            cmdupdsaldo.Parameters.AddWithValue("@correlativo", NoFac)
            cmdupdsaldo.Parameters.AddWithValue("@saldo", SaldoNuevo)
            cmdupdsaldo.Parameters.AddWithValue("@abono", AbonoNuevo)
            cmdupdsaldo.ExecuteNonQuery()
            cmdupdsaldo.Dispose()

        Catch ex As Exception

        End Try

        '3) AJUSTAR EL SALDO DEL PROVEEDOR
        Dim obcxp As New classCxp
        obcxp.AumentarSaldoProveedor(GlobalEmpNit, nitclie, Importe)
        'Call AumentarSaldoCliente(Empnit, NitClie, Importe)

        '4) ELIMINAR EL RECIBO

        Try
            Call AbrirConexionSql()

            Dim cmd As New SqlCommand("DELETE FROM DOCUMENTOS WHERE EMPNIT=@empnit AND CODDOC=@coddoc AND CORRELATIVO=@correlativo", cn)
            cmd.Parameters.AddWithValue("@empnit", Empnit)
            cmd.Parameters.AddWithValue("@coddoc", Coddoc)
            cmd.Parameters.AddWithValue("@correlativo", Correlativo)

            cmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception

        End Try


FINALIZAR:
        Return False
        cn.Close()
        Exit Function

    End Function

End Class
