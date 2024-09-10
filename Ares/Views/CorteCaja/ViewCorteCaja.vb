Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class ViewCorteCaja

    Dim objCorte As New classCorteCaja
    Dim coddocGasto As String = "GASTOS"

    Private Sub ViewCorteCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarCorrelativoCortes()
        Me.txtCorteCajaFecha.DateTime = Today.Date
        Call getCajas()

    End Sub

    Public Sub open_cashdrawer()

        Dim intFileNo As Integer = FreeFile()
        FileOpen(1, "c:\escapes.txt", OpenMode.Output)
        PrintLine(1, Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250))
        FileClose(1)
        Shell("print /d:lpt1 c:\escapes.txt", vbNormalFocus)

    End Sub

    Private Sub getCajas()

        Dim objC As New classCorteCaja
        Dim tblC As DataTable = objC.getCajas(1)
        'carga el combobox
        With Me.cmbCajas
            .DataSource = Nothing
            .DataSource = tblC
            .ValueMember = "CODCAJA"
            .DisplayMember = "DESCAJA"
        End With

        If tblC.Rows.Count > 0 Then
            Me.cmbCajas.SelectedValue = GlobalSelectedCodCaja
        End If

        'carga el grid de las cajas
        Me.GridCajas.DataSource = Nothing
        Me.GridCajas.DataSource = objC.getCajas(3)
        Me.GridCajas.Refresh()

    End Sub

    Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
        Try

            Call getEfectivoInicial()
            Call getTotalGastos()
            Call getTotalDevoluciones()
            Call getTotalRecibosClientes()
            Call getTotalVentasCredito()
            Call getTotalIEF()

        Catch ex As Exception
            Me.lbCorteEfectivoInicial.Text = "0"
            Me.txtCorteCajaGastos.Text = "0"
            Me.txtCorteCajaDevoluciones.Text = "0"
            Me.txtCorteCajaRecibosClientes.Text = "0"
            Me.txtCorteVentasCredito.Text = "0"
            Me.txtCorteCajaIEF.Text = "0"
        End Try
    End Sub

    Private Sub getTotalGastos()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String = "Select SUM(DOCUMENTOS.TOTALPRECIO) As TOTAL
                        From DOCUMENTOS LEFT OUTER Join
                         TIPODOCUMENTOS On DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC And DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        Where (DOCUMENTOS.EMPNIT = @E) And (DOCUMENTOS.CODCAJA = @CC) And (DOCUMENTOS.CORTE = 'NO') AND (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC = 'GAS')  AND (DOCUMENTOS.FECHA=@F)"

                Dim sqlold As String = "SELECT SUM(DOCUMENTOS.TOTALPRECIO) AS TOTAL, ISNULL(CAJAS.EFECTIVOINICIAL,0) AS INICIAL
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         CAJAS ON DOCUMENTOS.CODCAJA = CAJAS.CODCAJA AND DOCUMENTOS.EMPNIT = CAJAS.EMPNIT
                    WHERE (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODDOC = @CODDOC) AND (DOCUMENTOS.CODCAJA = @CODCAJA) AND (DOCUMENTOS.CORTE = 'NO')
                    GROUP BY CAJAS.EFECTIVOINICIAL"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CC", CType(Me.cmbCajas.SelectedValue, Integer))
                cmd.Parameters.AddWithValue("@F", Me.txtCorteCajaFecha.DateTime)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.txtCorteCajaGastos.Text = dr(0).ToString
                Else
                    Me.txtCorteCajaGastos.Text = "0"
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                Me.txtCorteCajaGastos.Text = "0"
            End Try
        End Using

    End Sub

    Private Sub getTotalIEF()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT       ISNULL(SUM(MONTO),0) 
                                           FROM         EFECTIVO_KH 
                                           WHERE        (CORTE = 'LOCAL') AND (FECHA = @F)", cn)

                cmd.Parameters.AddWithValue("@F", Me.txtCorteCajaFecha.DateTime)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.txtCorteCajaIEF.Text = dr(0).ToString
                Else
                    Me.txtCorteCajaIEF.Text = "0"
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                Me.txtCorteCajaIEF.Text = "0"
            End Try
        End Using


    End Sub

    Private Sub getTotalDevoluciones()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String = "SELECT SUM(DOCUMENTOS.TOTALPRECIO) AS TOTAL
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODCAJA = @CC) AND (DOCUMENTOS.CORTE = 'NO') AND (DOCUMENTOS.STATUS <> 'A') 
                    AND (TIPODOCUMENTOS.TIPODOC IN('DEV','FNC') ) AND (DOCUMENTOS.FECHA=@F)"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CC", CType(Me.cmbCajas.SelectedValue, Integer))
                cmd.Parameters.AddWithValue("@F", Me.txtCorteCajaFecha.DateTime)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.txtCorteCajaDevoluciones.Text = dr(0).ToString
                Else
                    Me.txtCorteCajaDevoluciones.Text = "0"
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                Me.txtCorteCajaDevoluciones.Text = "0"
            End Try
        End Using

    End Sub

    Private Sub getTotalVentasCredito()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String = "SELECT SUM(DOCUMENTOS.TOTALPRECIO) AS TOTAL
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @E) 
                            AND (DOCUMENTOS.CODCAJA = @CC) 
                            AND (DOCUMENTOS.CORTE = 'NO') 
                            AND (DOCUMENTOS.STATUS <> 'A') 
                            AND (TIPODOCUMENTOS.TIPODOC in('FAC','FEC')) 
                            AND (DOCUMENTOS.FECHA=@F) AND (DOCUMENTOS.CONCRE='CRE')"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CC", CType(Me.cmbCajas.SelectedValue, Integer))
                cmd.Parameters.AddWithValue("@F", Me.txtCorteCajaFecha.DateTime)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.txtCorteVentasCredito.Text = dr(0).ToString
                Else
                    Me.txtCorteVentasCredito.Text = "0"
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                Me.txtCorteVentasCredito.Text = "0"
            End Try
        End Using

    End Sub


    Private Sub getTotalRecibosClientes()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String = "SELECT SUM(DOCUMENTOS.TOTALPRECIO) AS TOTAL
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        WHERE (DOCUMENTOS.EMPNIT = @E) AND (DOCUMENTOS.CODCAJA = @CC) AND (DOCUMENTOS.CORTE = 'NO') AND (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC = 'RCC')  AND (DOCUMENTOS.FECHA=@F)"
                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CC", CType(Me.cmbCajas.SelectedValue, Integer))
                cmd.Parameters.AddWithValue("@F", Me.txtCorteCajaFecha.DateTime)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.txtCorteCajaRecibosClientes.Text = dr(0).ToString
                Else
                    Me.txtCorteCajaRecibosClientes.Text = "0"
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                Me.txtCorteCajaRecibosClientes.Text = "0"
            End Try
        End Using

    End Sub

    Private Sub getEfectivoInicial()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim sql As String = "SELECT ISNULL(CAJAS.EFECTIVOINICIAL,0) AS INICIAL
                        FROM CAJAS WHERE EMPNIT = @E AND CODCAJA = @CODCAJA"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.lbCorteEfectivoInicial.Text = dr(0).ToString
                Else
                    Me.lbCorteEfectivoInicial.Text = "0.00"
                End If
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                Me.lbCorteEfectivoInicial.Text = "0.00"
            End Try
        End Using
    End Sub

    Private Sub txtCorteCajaTotalDinero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaTotalDinero.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCorteCajaReportadoTarjeta.select()
        End If
    End Sub

    Private Sub txtCorteCajaReportadoTarjeta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaReportadoTarjeta.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCorteCajaCheques.select()
        End If
    End Sub

    Private Sub txtCorteCajaObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdCorteCajaGuardar.select()
        End If
    End Sub

    Public varFechaCorte As Date, varCorrelativoCorte As Double


    Private Sub cmdCorteCajaGuardar_Click(sender As Object, e As EventArgs) Handles cmdCorteCajaGuardar.Click
        '....

        Call NAVEGAR("ACTINV_2CORTE")

        If Me.txtCorteCajaTotalDinero.Text <> "" Then

            If Me.txtCorteCajaReportadoTarjeta.Text <> "" Then
            Else
                Me.txtCorteCajaReportadoTarjeta.Text = 0
            End If
            If Me.txtCorteCajaCheques.Text <> "" Then
            Else
                Me.txtCorteCajaCheques.Text = 0
            End If

            If Me.txtCorteCajaGastos.Text <> "" Then
            Else
                Me.txtCorteCajaGastos.Text = 0
            End If

            If Me.txtCorteCajaIEF.Text <> "" Then
            Else
                Me.txtCorteCajaIEF.Text = 0
            End If

            If Me.txtCorteCajaDevoluciones.Text <> "" Then
            Else
                Me.txtCorteCajaDevoluciones.Text = "0"
            End If

            If Me.txtCorteCajaRecibosClientes.Text <> "" Then
            Else
                Me.txtCorteCajaRecibosClientes.Text = "0"
            End If

            If Me.txtCorteVentasCredito.Text <> "" Then
            Else
                Me.txtCorteVentasCredito.Text = "0"
            End If

            If Me.txtCorteCajaObs.Text <> "" Then
            Else
                Me.txtCorteCajaObs.Text = "S/N"
            End If

            If Confirmacion("¿Está seguro que desea guardar este cuadre?", Me.ParentForm) = True Then

                'esto englobará el total de ventas + los recibos de clientes
                Dim TotalCorte As Double = 0

                Dim resultado As String
                'actualiza el correlativo
                Call CargarCorrelativoCortes()

                '********************************
                'OBTIENE LOS TOTALES DEL CORTE
                '********************************
                Call ObtenerTotalesCorte()

                'Dim corteTotalEF As Double = Double.Parse(Me.txtCorteCajaIEF.Text)
                Dim CorteTotalGastosIEF As Double = Double.Parse(Me.txtCorteCajaGastos.Text) + Double.Parse(Me.txtCorteCajaIEF.Text)
                Dim CorteTotalCheques As Double = Double.Parse(Me.txtCorteCajaCheques.Text)
                Dim CorteEfectivoInicial As Double = Double.Parse(Me.lbCorteEfectivoInicial.Text)
                Dim CorteTotalDevoluciones As Double = Double.Parse(Me.txtCorteCajaDevoluciones.Text)
                CorteTotalRecibos = Double.Parse(Me.txtCorteCajaRecibosClientes.Text)

                'total de valores a ingresar como positivo o sea lo que debería haber
                Dim CorteTotalIngresos As Double = CorteTotalVenta + CorteTotalRecibos + CorteEfectivoInicial

                'total de valores a ingresar como negativo para solventar
                Dim CorteTotalEgresos As Double = CorteTotalGastosIEF + Double.Parse(Me.txtCorteCajaTotalDinero.Text) + CorteTotalCheques + CorteTotalDevoluciones

                If (CorteTotalVenta + CorteTotalTarjeta + CorteTotalRecibos + CorteEfectivoInicial) > 0 Then

                    'asigno los valores de resutado en el corte
                    CorteTotalUtilidad = 0 '(CorteTotalVenta + CorteTotalTarjeta) - CorteTotalCosto
                    CorteMargenUtilidad = 0 ' CorteTotalUtilidad / CorteTotalCosto

                    If CorteTotalIngresos = CorteTotalEgresos Then

                        CorteSobrante = 0
                        CorteFaltante = 0
                        resultado = "Cuadre perfecto"

                    Else

                        If CorteTotalIngresos > CorteTotalEgresos Then
                            CorteSobrante = 0
                            CorteFaltante = CorteTotalIngresos - CorteTotalEgresos
                            resultado = "Faltante de " & FormatCurrency(CorteFaltante)
                        Else
                            CorteSobrante = CorteTotalEgresos - CorteTotalIngresos
                            CorteFaltante = 0
                            resultado = "Extra de " & FormatCurrency(CorteSobrante)
                        End If


                    End If

                    'recupera los datos de documentos del corte para ver el inicial y el final
                    Call ObtenerDatosDocumentosCorte()

                    '--------------------------------------------------

                    'envia la notificación
                    '-------------------------------

                    Using cn As New SqlConnection(strSqlConectionString)
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If


                        Dim cmd As New SqlCommand("INSERT INTO CORTES (EMPNIT,CODCAJA,ANIO,MES,DIA,FECHA,CORRELATIVO,IDINICIAL,CODDOCINICIAL,CORRELATIVOINICIAL,HORAINICIAL,MINUTOINICIAL,IDFINAL,CODDOCFINAL,CORRELATIVOFINAL,HORAFINAL,MINUTOFINAL,TOTALMOVIMIENTOS,TOTALCOSTO,TOTALVENTA,TOTALUTILIDAD,MARGEN,USUARIO,TOTALREPORTADO,FALTANTE,SOBRANTE,OBS,HORA,MINUTO,TOTALRECIBOS,TOTALTARJETA,REPORTADOTARJETA,TOTALGASTOS,TOTALCHEQUES,REPORTADOCHEQUES,TOTALDEVOLUCIONES,ENVIADO, TOTALVENTASCREDITO)
                                                    VALUES (@EMPNIT,@CODCAJA,@ANIO,@MES,@DIA,@FECHA,@CORRELATIVO,@IDINICIAL,@CODDOCINICIAL,@CORRELATIVOINICIAL,@HORAINICIAL,@MINUTOINICIAL,@IDFINAL,@CODDOCFINAL,@CORRELATIVOFINAL,@HORAFINAL,@MINUTOFINAL,@TOTALMOVIMIENTOS,@TOTALCOSTO,@TOTALVENTA,@TOTALUTILIDAD,@MARGEN,@USUARIO,@TOTALREPORTADO,@FALTANTE,@SOBRANTE,@OBS,@HORA,@MINUTO,@TOTALRECIBOS,@TOTALTARJETA,@REPORTADOTARJETA,@TOTALGASTOS,@TOTALCHEQUES,@REPORTADOCHEQUES,@TOTALDEVOLUCIONES,0,@TOTALVENTASCREDITO);
                                                UPDATE CAJAS SET STATUS=0,EFECTIVOINICIAL=0,EFECTIVOLIMITE=0,LASTUPDATE=@FECHA WHERE EMPNIT=@EMPNIT AND CODCAJA=@CODCAJA", cn)

                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
                        cmd.Parameters.AddWithValue("@ANIO", Me.txtCorteCajaFecha.DateTime.Year)
                        cmd.Parameters.AddWithValue("@MES", Me.txtCorteCajaFecha.DateTime.Month)
                        cmd.Parameters.AddWithValue("@DIA", Me.txtCorteCajaFecha.DateTime.Day)
                        cmd.Parameters.AddWithValue("@FECHA", Me.txtCorteCajaFecha.DateTime)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtCorteCajaCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@IDINICIAL", CorteIdInicial)
                        cmd.Parameters.AddWithValue("@CODDOCINICIAL", CorteCoddocInicial)
                        cmd.Parameters.AddWithValue("@CORRELATIVOINICIAL", CorteCorrelativoInicial)
                        cmd.Parameters.AddWithValue("@HORAINICIAL", 0) 'CorteHoraInicial)
                        cmd.Parameters.AddWithValue("@MINUTOINICIAL", 0) ' CorteMinutoInicial)
                        cmd.Parameters.AddWithValue("@IDFINAL", CorteIdFinal)
                        cmd.Parameters.AddWithValue("@CODDOCFINAL", CorteCoddocFinal)
                        cmd.Parameters.AddWithValue("@CORRELATIVOFINAL", CorteCorrelativoFinal)
                        cmd.Parameters.AddWithValue("@HORAFINAL", 0) 'CorteHoraFinal)
                        cmd.Parameters.AddWithValue("@MINUTOFINAL", 0) 'CorteMinutoFinal)
                        cmd.Parameters.AddWithValue("@TOTALMOVIMIENTOS", CorteTotalMovimientos)
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", CorteTotalCosto)
                        cmd.Parameters.AddWithValue("@TOTALVENTA", CorteTotalVenta)
                        cmd.Parameters.AddWithValue("@TOTALUTILIDAD", CorteTotalUtilidad)
                        cmd.Parameters.AddWithValue("@MARGEN", CorteMargenUtilidad)
                        cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                        cmd.Parameters.AddWithValue("@TOTALREPORTADO", Double.Parse(Me.txtCorteCajaTotalDinero.Text))
                        cmd.Parameters.AddWithValue("@FALTANTE", CorteFaltante)
                        cmd.Parameters.AddWithValue("@SOBRANTE", CorteSobrante)
                        cmd.Parameters.AddWithValue("@OBS", Me.txtCorteCajaObs.Text)
                        cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                        cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                        cmd.Parameters.AddWithValue("@TOTALRECIBOS", CorteTotalRecibos)
                        cmd.Parameters.AddWithValue("@TOTALTARJETA", CorteTotalTarjeta)
                        cmd.Parameters.AddWithValue("@TOTALCHEQUES", Double.Parse(Me.txtCorteCajaIEF.Text))
                        cmd.Parameters.AddWithValue("@REPORTADOCHEQUES", Double.Parse(Me.lbCorteEfectivoInicial.Text)) 'LO USARÉ PARA EMULAR EL EFECTIVO INICIAL
                        cmd.Parameters.AddWithValue("@TOTALGASTOS", Double.Parse(Me.txtCorteCajaGastos.Text)) 'CorteTotalGastos)
                        cmd.Parameters.AddWithValue("@REPORTADOTARJETA", Double.Parse(Me.txtCorteCajaReportadoTarjeta.Text))
                        cmd.Parameters.AddWithValue("@TOTALDEVOLUCIONES", Double.Parse(Me.txtCorteCajaDevoluciones.Text))
                        cmd.Parameters.AddWithValue("@TOTALVENTASCREDITO", Double.Parse(Me.txtCorteVentasCredito.Text))
                        cmd.ExecuteNonQuery()

                        'Call Form1.EnviarNotificacionesEmail(5, "Ares te informa: Ingreso de Corte de Caja", "Se creó el Corte de Caja No. " & Me.txtCorteCajaCorrelativo.Text & " el total de la venta es de " & FormatCurrency(CorteTotalVenta).ToString & " con un " & resultado & ". Se reportó un efectivo en caja de " & FormatCurrency(Me.txtCorteCajaTotalDinero.Text) & ", se anotó en observaciones: " & Me.txtCorteCajaObs.Text & ". Efectuado por el usuario " & GlobalNomUsuario)

                        cmd.Dispose()

                    End Using


                    'Cambia a SI el status del corte en la tabla documentos para todas las facturas activas
                    Call CORTEActualizarStatusDoc()

                    'refresca el combobox y el grid de cajas
                    Call getCajas()


                    Call Form1.Mensaje("Corte de caja registrado exitosamente")
                    'Call Aviso("Exito al Guardar", "Corte de caja registrado exitosamente", Me.ParentForm)

                    'cn.Close()

                    SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)


                    varFechaCorte = Me.txtCorteCajaFecha.DateTime
                    varCorrelativoCorte = Double.Parse(Me.txtCorteCajaCorrelativo.Text)
                    globalcorrelativocorte = Double.Parse(Me.txtCorteCajaCorrelativo.Text)
                    SelectedCorrelativo = Double.Parse(Me.txtCorteCajaCorrelativo.Text)

                    Call ActualizarCorrelativoCorte()
                    Call CargarCorrelativoCortes()

                    'libero las variables de su valor
                    CorteTotalCosto = Nothing
                    CorteTotalMovimientos = Nothing
                    CorteTotalUtilidad = Nothing
                    CorteTotalVenta = Nothing
                    CorteMargenUtilidad = Nothing
                    CorteSobrante = Nothing
                    CorteFaltante = Nothing
                    CorteIdInicial = Nothing
                    CorteIdFinal = Nothing
                    CorteCoddocFinal = Nothing
                    CorteCoddocInicial = Nothing
                    CorteCorrelativoFinal = Nothing
                    CorteCorrelativoInicial = Nothing
                    CorteFechaDocInicial = Nothing
                    CorteFechaDocFinal = Nothing
                    CorteHoraFinal = Nothing
                    CorteHoraInicial = Nothing
                    CorteMinutoFinal = Nothing
                    CorteMinutoInicial = Nothing

                    Call LimpiarDatosCorteCaja()

                    Me.txtCorteCajaTotalDinero.Text = ""
                    Me.txtCorteCajaReportadoTarjeta.Text = ""
                    Me.txtCorteCajaCheques.Text = ""
                    Me.txtCorteCajaDevoluciones.Text = ""
                    Me.txtCorteCajaRecibosClientes.Text = ""
                    Me.txtCorteCajaObs.Text = ""
                    Me.txtCorteCajaTotalDinero.select()

                    SplashScreenManager.CloseForm()

                    'llamo al reporte de corte dependiendo del valor en configuraciones
                    '  If Form1.SwitchConfigFormatoCorte.IsOn = True Then
                    'formato dos
                    'Try
                    'Form1.Mensaje("Generando inventarios en mínimo...")
                    'Call exportarInventariosMinimos()
                    'Catch ex As Exception
                    'MsgBox("Error al cargar el listado de vencidos. Error: " + ex.ToString)
                    'End Try
                    Try
                        Call AbrirReporteCuadre(varFechaCorte, varCorrelativoCorte)
                    Catch ex As Exception
                        MsgBox("No se puede crear el resumen. Error: " + ex.ToString)
                    End Try

                    Try
                        Call Report_DocumentosCorte(GlobalEmpNit, varCorrelativoCorte)
                        Call Report_ProductosCorte(GlobalEmpNit, varCorrelativoCorte)
                        Call exportarProdsCorte()

                    Catch ex As Exception
                        MsgBox("No se puede crear lista de documentos. Error: " + ex.ToString)
                    End Try

                Else
                    Call Aviso("Aviso", "No hay ventas pendientes para realizar corte", Me.ParentForm)
                End If
            End If
        Else
            Call Form1.Mensaje("Debe escribir el monto del dinero de las ventas del día")
        End If

    End Sub

    Private Function minmaxFinalizada() As Boolean

        Dim result As Boolean

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        If objS.fcnActuMaxMin(GlobalEmpNit) = True Then
            If objS.fcnSendDataVendidos(New DateTime(Today.Year, Today.Month, 1)) = True Then
                If objS.fcnUpdateMinMax(GlobalEmpNit) = True Then
                Else
                    Call Form1.Mensaje("NO SE ESTABLECIERON LOS MAXIMOS")
                End If

            Else
                Call Form1.Mensaje("ERROR EN ACTU MIN/MAX")
            End If
        Else
            Form1.Mensaje("NO SE ESTABLECIO EL TOTALVENTAS MES PASADO")
        End If
        result = True

        Return result


    End Function

    Private Sub exportarProdsCorte()

        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        If objS.fcnSendDocProds(GlobalEmpNit, varCorrelativoCorte) = True Then

            MsgBox("Productos del corte subidos exitosamente.")

        End If

    End Sub

    Dim CorteTotalVenta As Double, CorteTotalCosto As Double, CorteTotalUtilidad As Double, CorteMargenUtilidad As Double, CorteTotalMovimientos As Integer, CorteFaltante As Double, CorteSobrante As Double, CorteTotalTarjeta As Double
    Dim CorteTotalVentaCredito As Double = 0
    Dim CorteTotalRecibos As Double, CorteMovimientosRecibos As Integer
    Dim CorteMovimientosGastos As Integer

    Private Sub ActualizarCorrelativoCorte()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim SQL As String
            SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=@N WHERE EMPNIT=@E AND CODDOC=@D"

            Dim cmd As New SqlCommand(SQL, cn)
            cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@D", GlobalCoddocCorteCaja)
            cmd.Parameters.AddWithValue("@N", (Double.Parse(Me.txtCorteCajaCorrelativo.Text) + 1))
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        End Using
        'cn.Close()
    End Sub

    Private Sub ObtenerTotalesCorte()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim sql As String = "SELECT SUM(DOCUMENTOS.TOTALPRECIO) AS PRECIO, SUM(DOCUMENTOS.TOTALCOSTO) AS COSTO, COUNT(DOCUMENTOS.CORRELATIVO) AS CONTEO,(SUM(DOCUMENTOS.TOTALTARJETA)) AS TOTALTARJETA, SUM(ISNULL(RECARGOTARJETA,0)) AS RECARGOTARJETA
                                 FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                 WHERE (DOCUMENTOS.STATUS <> 'A') 
                                    AND (DOCUMENTOS.EMPNIT = @EMPNIT) 
                                    AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FES') ) 
                                    AND (DOCUMENTOS.CORTE = 'NO') 
                                    AND (DOCUMENTOS.CONCRE = 'CON')     
                                    AND (DOCUMENTOS.CODCAJA = @CODCAJA) 
                                    AND (DOCUMENTOS.FECHA = @F)"

            Dim recargotarjeta = 0

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
            cmd.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteCajaFecha.DateTime))
            cmd.CommandTimeout = 0
            Dim dr As SqlDataReader = cmd.ExecuteReader

            dr.Read()
            Try
                If dr.HasRows Then
                    CorteTotalVenta = Double.Parse(dr(0).ToString)
                    CorteTotalCosto = Double.Parse(dr(1).ToString)
                    CorteTotalMovimientos = Integer.Parse(dr(2).ToString)
                    CorteTotalTarjeta = Double.Parse(dr(3).ToString)
                    recargotarjeta = Double.Parse(dr(4))
                End If

                CorteTotalVenta = CorteTotalVenta + recargotarjeta
                CorteTotalVenta = CorteTotalVenta - CorteTotalTarjeta

            Catch ex As Exception
                CorteTotalVenta = 0
                CorteTotalCosto = 0
                CorteTotalMovimientos = 0
                CorteTotalTarjeta = 0
                'MsgBox("Error al obtener datos del corte: " + ex.ToString)
            End Try
            dr.Close()
            cmd.Dispose()

        End Using

    End Sub

    Private Sub ViewCorteCaja_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F5 Then
            Me.cmdCorteCajaGuardar.PerformClick()
        End If

    End Sub

    Dim CorteIdInicial As Double, CorteCoddocInicial As String, CorteCorrelativoInicial As Double, CorteFechaDocInicial As Date, CorteHoraInicial As Integer, CorteMinutoInicial As Integer
    Dim CorteIdFinal As Double, CorteCoddocFinal As String, CorteCorrelativoFinal As Double, CorteFechaDocFinal As Date, CorteHoraFinal As Integer, CorteMinutoFinal As Integer

    Private Sub ObtenerDatosDocumentosCorte()

        CorteIdInicial = 0
        CorteCoddocInicial = "SN"
        CorteCorrelativoInicial = 0
        CorteIdFinal = 0
        CorteCoddocFinal = "SN"
        CorteCorrelativoFinal = 0

    End Sub

    Private Sub CORTEActualizarStatusDoc()

        'actualiza documentos
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            'ACTUALIZA LAS FACTURAS
            Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='SI', NOCORTE=@NOCORTE FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                   WHERE (DOCUMENTOS.EMPNIT=@E) 
                                    AND (TIPODOCUMENTOS.TIPODOC IN('FAC','FEF','FES')) 
                                    AND (DOCUMENTOS.CORTE='NO') 
                                    AND (DOCUMENTOS.CONCRE='CON') 
                                    AND (DOCUMENTOS.CODCAJA=@CODCAJA)
                                    AND (DOCUMENTOS.FECHA=@F)", cn)
            cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@NOCORTE", Double.Parse(Me.txtCorteCajaCorrelativo.Text))
            cmd.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
            cmd.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteCajaFecha.DateTime))
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            'actualiza gastos
            Dim cmdG As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='SI', NOCORTE=@NOCORTE FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
            WHERE (DOCUMENTOS.EMPNIT=@E) AND (TIPODOCUMENTOS.TIPODOC = 'GAS') 
            AND (DOCUMENTOS.CORTE='NO')  AND (DOCUMENTOS.CODCAJA=@CODCAJA)
            AND (DOCUMENTOS.FECHA=@F)", cn)
            cmdG.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmdG.Parameters.AddWithValue("@NOCORTE", Double.Parse(Me.txtCorteCajaCorrelativo.Text))
            cmdG.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
            cmdG.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteCajaFecha.DateTime))
            cmdG.ExecuteNonQuery()
            cmdG.Dispose()

            'actualiza recibos
            Dim cmdR As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='SI', NOCORTE=@NOCORTE FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                   WHERE (DOCUMENTOS.EMPNIT='" & GlobalEmpNit & "') 
                                    AND (TIPODOCUMENTOS.TIPODOC = 'RCC') 
                                    AND (DOCUMENTOS.CORTE='NO') 
                                    AND (DOCUMENTOS.CODCAJA=@CODCAJA)
                                    AND (DOCUMENTOS.FECHA=@F)", cn)
            cmdR.Parameters.AddWithValue("@NOCORTE", Double.Parse(Me.txtCorteCajaCorrelativo.Text))
            cmdR.Parameters.AddWithValue("@CODCAJA", Integer.Parse(Me.cmbCajas.SelectedValue.ToString))
            cmdR.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteCajaFecha.DateTime))
            cmdR.ExecuteNonQuery()
            cmdR.Dispose()

            'ACTUALIZA LAS DEVOLUCIONES
            Dim cmdD As New SqlCommand("UPDATE DOCUMENTOS SET CORTE='SI', NOCORTE=@NOCORTE FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                WHERE(DOCUMENTOS.EMPNIT =@E)
                                    And (TIPODOCUMENTOS.TIPODOC IN('DEV','FNC') )
                                    And (DOCUMENTOS.CORTE='NO') 
                                    And (DOCUMENTOS.CONCRE='CON') 
                                    And (DOCUMENTOS.CODCAJA=@CODCAJA)
                                    And (DOCUMENTOS.FECHA=@F)", cn)
            cmdD.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmdD.Parameters.AddWithValue("@NOCORTE", Double.Parse(Me.txtCorteCajaCorrelativo.Text))
            cmdD.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
            cmdD.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteCajaFecha.DateTime))
            cmdD.ExecuteNonQuery()
            cmdD.Dispose()

            Dim cmdIEF As New SqlCommand("UPDATE EFECTIVO_KH SET CORTE='SILOCAL', NO_CORTE=@NO_CORTE 
                                          WHERE  (EMPNIT =@E)
                                                 And (CORTE='LOCAL') 
                                                 And (FECHA=@F)", cn)
            cmdIEF.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmdIEF.Parameters.AddWithValue("@NO_CORTE", Double.Parse(Me.txtCorteCajaCorrelativo.Text))
            cmdIEF.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteCajaFecha.DateTime))
            cmdIEF.ExecuteNonQuery()
            cmdIEF.Dispose()

            Dim cmdIEF2 As New SqlCommand("UPDATE EFECTIVO_KH SET CORTE='SI', NO_CORTE=@NO_CORTE 
                                          WHERE  (EMPNIT NOT LIKE @E)
                                                 And (CORTE='NO') 
                                                 And (FECHA=@F)", cn)
            cmdIEF2.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmdIEF2.Parameters.AddWithValue("@NO_CORTE", Double.Parse(Me.txtCorteCajaCorrelativo.Text))
            cmdIEF2.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteCajaFecha.DateTime))
            cmdIEF2.ExecuteNonQuery()
            cmdIEF2.Dispose()



        End Using

    End Sub

    Private Sub LimpiarDatosCorteCaja()
        Me.txtCorteCajaTotalDinero.Text = 0
        Me.txtCorteCajaReportadoTarjeta.Text = 0
        Me.txtCorteCajaObs.Text = "S/N"
        Me.txtCorteCajaB200.Text = ""
        Me.txtCorteCajaB100.Text = ""
        Me.txtCorteCajaB50.Text = ""
        Me.txtCorteCajaB20.Text = ""
        Me.txtCorteCajaB10.Text = ""
        Me.txtCorteCajaB5.Text = ""
        Me.txtCorteCajaB1.Text = ""
        Me.txtCorteCajaM100.Text = ""
        Me.txtCorteCajaM50.Text = ""
        Me.txtCorteCajaM25.Text = ""
        Me.txtCorteCajaM10.Text = ""
        Me.txtCorteCajaM5.Text = ""
        Me.txtCorteCajaM1.Text = ""
        Me.txtCorteCajaMOtros.Text = ""
        Me.txtCorteCajaBTotal.Text = "0.00"
        Me.txtCorteCajaBTotal.Text = "0.00"

    End Sub


    Private Sub exportarInventariosMinimos()

        Me.gridExportMinimos.DataSource = Nothing

        Dim objInventarios As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

        Me.gridExportMinimos.DataSource = objInventarios.tblProductosAgotados

        Dim path As String = GlobalPathMinimos + "minimos" + Today.Day.ToString + "-" + Today.Month.ToString + "-" + Today.Year.ToString + ".xlsx"
        Me.gridExportMinimos.ExportToXlsx(path)
        Me.gridExportMinimos.DataSource = Nothing

    End Sub



    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.NavigationFrame.SelectedPage = NP_NuevoCorte
    End Sub

    Private Sub btnGestion_Click(sender As Object, e As EventArgs) Handles btnGestion.Click

        Me.NavigationFrame.SelectedPage = NP_Cajas

    End Sub

    Dim drw As DataRow
    Private Sub TileViewCajas_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TileViewCajas.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.TileViewCajas.GetFocusedDataRow

        Catch ex As Exception
            drw = Nothing
        End Try
    End Sub

    Private Sub TileViewCajas_DoubleClick(sender As Object, e As EventArgs) Handles TileViewCajas.DoubleClick

        'drw.Item(4) - STATUS

        If Integer.Parse(drw.Item(4)) = 0 Then 'caja cerrada
            If DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog.Show(Me.ParentForm, New viewCajaEfectivo(Integer.Parse(drw.Item(0)))) = DialogResult.OK Then

                'carga el grid de las cajas
                Call getCajas()

            End If

        Else 'caja abierta

            If Confirmacion("¿Está seguro que desea Cerrar esta Caja?", Me.ParentForm) = True Then
                Using cn As New SqlConnection(strSqlConectionString)
                    Try
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If

                        Dim cmd As New SqlCommand("UPDATE CAJAS SET STATUS=0,EFECTIVOINICIAL=0,EFECTIVOLIMITE=0,LASTUPDATE=@FECHA 
                        WHERE EMPNIT=@EMPNIT AND CODCAJA=@CODCAJA", cn)
                        cmd.Parameters.AddWithValue("@FECHA", Date.Parse(Me.txtCorteCajaFecha.DateTime))
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
                        cmd.ExecuteNonQuery()
                        Call getCajas()
                    Catch ex As Exception
                        MsgBox("No se pudo cerrar esta caja")
                    End Try

                End Using
            End If

        End If

    End Sub

    Private Sub TileViewCajas_ItemCustomize(sender As Object, e As DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs) Handles TileViewCajas.ItemCustomize
        Try
            If TileViewCajas.GetRowCellValue(e.RowHandle, TileViewCajas.Columns("STATUS")).ToString = "1" Then
                e.Item.AppearanceItem.Normal.BackColor = Color.LightSalmon
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCorteCajaCheques_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaCheques.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCorteCajaObs.select()
        End If
    End Sub

    Private Sub btnCerrarHerramienta_Click(sender As Object, e As EventArgs) Handles btnCerrarHerramienta.Click
        Me.FlyoutPanelHerramienta.HidePopup()
    End Sub

    Private Sub btnHerramientaConteo_Click(sender As Object, e As EventArgs)
        Me.FlyoutPanelHerramienta.ShowPopup()
    End Sub

    Private Sub CargarCorrelativoCortes()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim SQL As String
            SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & GlobalCoddocCorteCaja & "'"

            Dim cmd As New SqlCommand(SQL, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    Me.txtCorteCajaCorrelativo.Text = dr(0).ToString
                End If
            Catch ex As Exception

                Me.txtCorteCajaCorrelativo.Text = 0

            End Try
            dr.Close()
            cmd.Dispose()
        End Using
        'cn.Close()

    End Sub


#Region " TOOL PARA CONTEO "
    Private Sub CargarTotalesCorteCaja()
        Dim TotalBilletes As Double

        'CAMBIO LOS VALORES A CERO
        'billetes
        If Me.txtCorteCajaB200.Text <> "" Then
        Else
            Me.txtCorteCajaB200.Text = 0
        End If
        If Me.txtCorteCajaB100.Text <> "" Then
        Else
            Me.txtCorteCajaB100.Text = 0
        End If
        If Me.txtCorteCajaB50.Text <> "" Then
        Else
            Me.txtCorteCajaB50.Text = 0
        End If
        If Me.txtCorteCajaB20.Text <> "" Then
        Else
            Me.txtCorteCajaB20.Text = 0
        End If
        If Me.txtCorteCajaB10.Text <> "" Then
        Else
            Me.txtCorteCajaB10.Text = 0
        End If
        If Me.txtCorteCajaB5.Text <> "" Then
        Else
            Me.txtCorteCajaB5.Text = 0
        End If
        If Me.txtCorteCajaB1.Text <> "" Then
        Else
            Me.txtCorteCajaB1.Text = 0
        End If
        'monedas
        If Me.txtCorteCajaM100.Text <> "" Then
        Else
            Me.txtCorteCajaM100.Text = 0
        End If
        If Me.txtCorteCajaM50.Text <> "" Then
        Else
            Me.txtCorteCajaM50.Text = 0
        End If
        If Me.txtCorteCajaM25.Text <> "" Then
        Else
            Me.txtCorteCajaM25.Text = 0
        End If
        If Me.txtCorteCajaM10.Text <> "" Then
        Else
            Me.txtCorteCajaM10.Text = 0
        End If
        If Me.txtCorteCajaM5.Text <> "" Then
        Else
            Me.txtCorteCajaM5.Text = 0
        End If
        If Me.txtCorteCajaM1.Text <> "" Then
        Else
            Me.txtCorteCajaM1.Text = 0
        End If
        If Me.txtCorteCajaMOtros.Text <> "" Then
        Else
            Me.txtCorteCajaMOtros.Text = 0
        End If

        Me.txtCorteCajaBTotal.Text = FCTotalBilletes(Double.Parse(Me.txtCorteCajaB200.Text), Double.Parse(Me.txtCorteCajaB100.Text), Double.Parse(Me.txtCorteCajaB50.Text), Double.Parse(Me.txtCorteCajaB20.Text), Double.Parse(Me.txtCorteCajaB10.Text), Double.Parse(Me.txtCorteCajaB5.Text), Double.Parse(Me.txtCorteCajaB1.Text))
        Me.txtCorteCajaMTotal.Text = FCTotalMonedas(Double.Parse(Me.txtCorteCajaM100.Text), Double.Parse(Me.txtCorteCajaM50.Text), Double.Parse(Me.txtCorteCajaM25.Text), Double.Parse(Me.txtCorteCajaM10.Text), Double.Parse(Me.txtCorteCajaM5.Text), Double.Parse(Me.txtCorteCajaM1.Text))

        Me.txtCorteCajaTotalDinero.Text = Double.Parse(Me.txtCorteCajaBTotal.Text) + Double.Parse(Me.txtCorteCajaMTotal.Text + Double.Parse(Me.txtCorteCajaMOtros.Text))


    End Sub
    Private Function FCTotalBilletes(ByVal B200 As Integer, B100 As Integer, B50 As Integer, B20 As Integer, B10 As Integer, B5 As Integer, B1 As Integer) As Double
        Return ((B200 * 200) + (B100 * 100) + (B50 * 50) + (B20 * 20) + (B10 * 10) + (B5 * 5) + B1)
    End Function
    Private Function FCTotalMonedas(ByVal M100 As Integer, M50 As Integer, M25 As Integer, M10 As Integer, M5 As Integer, M1 As Integer) As Double
        Return ((M100 * 1) + (M50 * 0.5) + (M25 * 0.25) + (M10 * 0.1) + (M5 * 0.05) + (M1 * 0.01))
    End Function

    Private Sub txtCorteCajaB200_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaB200.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaB100.select()
        End If
    End Sub
    Private Sub txtCorteCajaB100_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaB100.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaB50.select()
        End If
    End Sub
    Private Sub txtCorteCajaB50_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaB50.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaB20.select()
        End If
    End Sub
    Private Sub txtCorteCajaB20_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaB20.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaB10.select()
        End If
    End Sub
    Private Sub txtCorteCajaB10_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaB10.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaB5.select()
        End If
    End Sub
    Private Sub txtCorteCajaB5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaB5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaB1.select()
        End If
    End Sub
    Private Sub txtCorteCajaB1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaB1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaM100.select()
        End If
    End Sub
    Private Sub txtCorteCajaM100_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaM100.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaM50.select()
        End If
    End Sub
    Private Sub txtCorteCajaM50_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaM50.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaM25.select()
        End If
    End Sub
    Private Sub txtCorteCajaM25_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaM25.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaM10.select()
        End If
    End Sub
    Private Sub txtCorteCajaM10_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaM10.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaM5.select()
        End If
    End Sub
    Private Sub txtCorteCajaM5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaM5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaM1.select()
        End If
    End Sub
    Private Sub txtCorteCajaM1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaM1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaMOtros.select()
        End If
    End Sub
    Private Sub txtCorteCajaMOtros_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCorteCajaMOtros.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call CargarTotalesCorteCaja()
            Me.txtCorteCajaTotalDinero.select()
        End If
    End Sub
#End Region


End Class
