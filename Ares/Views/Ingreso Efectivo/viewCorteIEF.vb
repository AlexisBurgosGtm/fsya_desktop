Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class viewCorteIEF

    Private Sub viewCorteIEF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarCorrelativoCorteIEF()

        Me.txtCorteIEFFecha.DateTime = Today.Date


    End Sub

    Dim CorteTotalMovimientos As Double, CorteTotalIEF As Integer, CorteFaltante As Double, CorteSobrante As Double

    Private Sub btnRealizarCorte_Click(sender As Object, e As EventArgs) Handles btnRealizarCorte.Click

        If Me.txtTotalReportado.Text <> "" Then

            If Confirmacion("¿Está seguro que desea guardar este cuadre?", Me.ParentForm) Then
                Dim TotalCorte As Double = 0
                Dim resultado As String
                Call CargarCorrelativoCorteIEF()
                Call ObtenerTotalesCorte()


                Dim TotalIngresos As Double = CorteTotalIEF

                Dim TotalReportado As Double = Double.Parse(Me.txtTotalReportado.Text)

                If TotalIngresos = TotalReportado Then

                    CorteSobrante = 0
                    CorteFaltante = 0
                    resultado = "Cuadre Perfecto"

                Else

                    If TotalIngresos > TotalReportado Then

                        CorteSobrante = 0
                        CorteFaltante = TotalIngresos - TotalReportado
                        resultado = "Faltante de " & FormatCurrency(CorteFaltante)

                    Else

                        CorteSobrante = TotalIngresos - TotalReportado
                        CorteFaltante = 0
                        resultado = "Sobrante de " & FormatCurrency(CorteSobrante)

                    End If

                End If


                Using cn As New SqlConnection(strSqlConectionString)

                    If cn.State <> ConnectionState.Open Then

                        cn.Open()

                    End If

                    Dim cmd As New SqlCommand("INSERT INTO CORTES_IEF (EMPNIT, DIA, MES, ANIO, FECHA, HORA, MINUTO, CORRELATIVO, TOTAL_MOVIMIENTOS, TOTAL_ING, TOTAL_REPORT, FALTANTE, SOBRANTE, OBSERVACIONES, USUARIO)
                                               VALUES (@EMPNIT, @DIA, @MES, @ANIO, @FECHA, @HORA, @MINUTO, @CORRELATIVO, @TOTAL_MOVIMIENTOS, @TOTAL_ING, @TOTAL_REPORT, @FALTANTE, @SOBRANTE, @OBSERVACIONES, @USUARIO)", cn)

                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@DIA", Me.txtCorteIEFFecha.DateTime.Day)
                    cmd.Parameters.AddWithValue("@MES", Me.txtCorteIEFFecha.DateTime.Month)
                    cmd.Parameters.AddWithValue("@ANIO", Me.txtCorteIEFFecha.DateTime.Year)
                    cmd.Parameters.AddWithValue("@FECHA", Me.txtCorteIEFFecha.DateTime)
                    cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                    cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtCorrelativoCIEF.Text))
                    cmd.Parameters.AddWithValue("@TOTAL_MOVIMIENTOS", CorteTotalMovimientos)
                    cmd.Parameters.AddWithValue("@TOTAL_ING", TotalIngresos)
                    cmd.Parameters.AddWithValue("@TOTAL_REPORT", TotalReportado)
                    cmd.Parameters.AddWithValue("@FALTANTE", CorteFaltante)
                    cmd.Parameters.AddWithValue("@SOBRANTE", CorteSobrante)
                    cmd.Parameters.AddWithValue("@OBSERVACIONES", Me.txtOBSIEF.Text)
                    cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                    cmd.ExecuteNonQuery()

                    cmd.Dispose()


                End Using

                Call CORTEActualizarStatusDoc()

                Call Form1.Mensaje("Corte de IEF registrado exitosamente")

                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

                Dim varFechaCorte As Date, varCorrelativoCorte As Double
                varFechaCorte = Me.txtCorteIEFFecha.DateTime
                varCorrelativoCorte = Double.Parse(Me.txtCorrelativoCIEF.Text)


                Call ActualizarCorrelativoCorte()
                Call CargarCorrelativoCorteIEF()


                'libero las variables de su valor
                CorteTotalMovimientos = Nothing
                CorteTotalIEF = Nothing
                CorteSobrante = Nothing
                CorteFaltante = Nothing

                Call LimpiarDatosCorteCaja()

                Me.txtTotalReportado.Text = ""
                Me.txtOBSIEF.Text = ""
                Me.txtTotalReportado.select()

                SplashScreenManager.CloseForm()

                Try
                    Call AbrirReporteCorteIEF(varFechaCorte, varCorrelativoCorte)
                Catch ex As Exception
                    MsgBox("No se puede crear el resumen. Error: " + ex.ToString)
                End Try

            Else
                Exit Sub

            End If

        End If

        Dim ief As New viewIngresoEfec
        Call ief.CargarGridIEF()

    End Sub

    Private Sub ObtenerTotalesCorte()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim sql As String = "SELECT SUM(MONTO) AS MONTO, COUNT(CORRELATIVO) AS CONTEO
                                 FROM EFECTIVO_KH
                                 WHERE  (EMPNIT = @EMPNIT) 
                                    AND (CORTE = 'NO') 
                                    AND (FECHA = @F)"

            Dim recargotarjeta = 0

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteIEFFecha.DateTime))
            cmd.CommandTimeout = 0
            Dim dr As SqlDataReader = cmd.ExecuteReader

            dr.Read()
            Try
                If dr.HasRows Then
                    CorteTotalIEF = Double.Parse(dr(0).ToString)
                    CorteTotalMovimientos = Integer.Parse(dr(1).ToString)

                End If

            Catch ex As Exception
                CorteTotalIEF = 0
                CorteTotalMovimientos = 0
                'MsgBox("Error al obtener datos del corte: " + ex.ToString)
            End Try
            dr.Close()
            cmd.Dispose()

        End Using

    End Sub

    Private Sub CORTEActualizarStatusDoc()

        'actualiza documentos
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            'ACTUALIZA LAS FACTURAS
            Dim cmd As New SqlCommand("UPDATE EFECTIVO_KH SET CORTE='SI', NO_CORTE=@NOCORTE WHERE (EFECTIVO_KH.EMPNIT=@E) AND (FECHA=@F) AND (CORTE = 'NO')", cn)
            cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@NOCORTE", Double.Parse(Me.txtCorrelativoCIEF.Text))
            cmd.Parameters.AddWithValue("@F", Date.Parse(Me.txtCorteIEFFecha.DateTime))
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        End Using

    End Sub

    Private Sub CargarCorrelativoCorteIEF()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim SQL As String
            SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='CORTEIEF'"

            Dim cmd As New SqlCommand(SQL, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    Me.txtCorrelativoCIEF.Text = dr(0).ToString
                End If
            Catch ex As Exception

                Me.txtCorrelativoCIEF.Text = 0

            End Try
            dr.Close()
            cmd.Dispose()
        End Using
        'cn.Close()

    End Sub

    Private Sub ActualizarCorrelativoCorte()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim SQL As String
            SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=@N WHERE EMPNIT=@E AND CODDOC='CORTEIEF'"

            Dim cmd As New SqlCommand(SQL, cn)
            cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@N", (Double.Parse(Me.txtCorrelativoCIEF.Text) + 1))
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        End Using
        'cn.Close()
    End Sub

    Private Sub LimpiarDatosCorteCaja()
        Me.txtTotalReportado.Text = 0
        Me.txtOBSIEF.Text = "S/N"

    End Sub




End Class
