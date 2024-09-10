Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class classOrdenTrabajo
    Sub New(ByVal _empnit As String)
        empnit = _empnit
    End Sub

    Dim empnit As String

    Public Function rptOrdenTrabajo(ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Dim result As Boolean
        Dim tbl As New DSGeneral.tblOrdenesTrabajoPendientesDataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT DOCUMENTOS_ORDENTRABAJO.FECHA, DOCUMENTOS_ORDENTRABAJO.FECHAENTREGA, DOCUMENTOS_ORDENTRABAJO.CODCLIENTE, CLIENTES.NOMBRECLIENTE AS NOMCLIENTE, 
                         CLIENTES.TELEFONOCLIENTE AS TELCLIENTE, DOCUMENTOS_ORDENTRABAJO.CODVEHICULO, CLIENTES_VEHICULOS.DESVEHICULO, CLIENTES.TELEFONOCLIENTE AS TELCLIENTE, 
                         DOCUMENTOS_ORDENTRABAJO.ORDEN, DOCUMENTOS_ORDENTRABAJO.OBS, DOCUMENTOS_ORDENTRABAJO.IMPORTE AS VALOR, DOCUMENTOS_ORDENTRABAJO.ADELANTO AS ANTICIPO, 
                         DOCUMENTOS_ORDENTRABAJO.SALDO, DOCUMENTOS_ORDENTRABAJO.CODDOC, DOCUMENTOS_ORDENTRABAJO.CORRELATIVO, ISNULL(DOCUMENTOS_ORDENTRABAJO.DIAGNOSTICO, 'PENDIENTE') AS DIAGNOSTICO, 
                         EMPLEADOS.NOMEMPLEADO
                        FROM DOCUMENTOS_ORDENTRABAJO LEFT OUTER JOIN
                         EMPLEADOS ON DOCUMENTOS_ORDENTRABAJO.EMPNIT = EMPLEADOS.EMPNIT AND DOCUMENTOS_ORDENTRABAJO.CODEMPLEADO = EMPLEADOS.CODEMPLEADO LEFT OUTER JOIN
                         CLIENTES_VEHICULOS ON DOCUMENTOS_ORDENTRABAJO.CODVEHICULO = CLIENTES_VEHICULOS.CODVEHICULO AND DOCUMENTOS_ORDENTRABAJO.EMPNIT = CLIENTES_VEHICULOS.EMPNIT LEFT OUTER JOIN
                         CLIENTES ON DOCUMENTOS_ORDENTRABAJO.CODCLIENTE = CLIENTES.CODCLIENTE AND DOCUMENTOS_ORDENTRABAJO.EMPNIT = CLIENTES.EMPNIT
                        WHERE (DOCUMENTOS_ORDENTRABAJO.CODDOC = @CODDOC) AND (DOCUMENTOS_ORDENTRABAJO.CORRELATIVO = @CORRELATIVO) AND (DOCUMENTOS_ORDENTRABAJO.EMPNIT = @EMPNIT)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cmd.Dispose()

                Dim Adapter As New SqlDataAdapter

                Dim report As XtraReport
                report = New rptOrdenTrabajo

                Try
                    report.LoadLayout(Application.StartupPath + "\Reports\ORDENTRABAJO.repx")
                Catch ex As Exception
                    report.SaveLayout(Application.StartupPath + "\Reports\ORDENTRABAJO.repx")
                End Try


                report.DataSource = tbl
                report.DataAdapter = Adapter
                report.DataMember = tbl.TableName.ToString '"tblOrdenesTrabajoPendientes"


                Dim tool As ReportPrintTool = New ReportPrintTool(report)

                report.CreateDocument()
                cn.Close()

                SplashScreenManager.CloseForm()
                report.ShowPreview

            End Using

            result = True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            SplashScreenManager.CloseForm()

            result = False

        End Try
        Return result
    End Function


    Public Function rptHistorialVehiculo() As Boolean


    End Function


    Public Function SelectOrdenesPendientes() As DataTable

        Dim tbl As New DSGeneral.tblOrdenesTrabajoPendientesDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim da As New SqlDataAdapter
                da.SelectCommand = New SqlCommand("SELECT   DOCUMENTOS_ORDENTRABAJO.FECHA, 
                                                            DOCUMENTOS_ORDENTRABAJO.FECHAENTREGA, 
                                                            DOCUMENTOS_ORDENTRABAJO.CODCLIENTE, 
                                                            CLIENTES.NOMBRECLIENTE AS NOMCLIENTE, 
                                                            CLIENTES.TELEFONOCLIENTE AS TELCLIENTE, 
                                                            DOCUMENTOS_ORDENTRABAJO.CODVEHICULO, 
                                                            CLIENTES_VEHICULOS.DESVEHICULO, 
                                                            CLIENTES.TELEFONOCLIENTE AS TELCLIENTE, 
                                                            DOCUMENTOS_ORDENTRABAJO.ORDEN,
                                                            DOCUMENTOS_ORDENTRABAJO.OBS, 
                                                            DOCUMENTOS_ORDENTRABAJO.IMPORTE AS VALOR, 
                                                            DOCUMENTOS_ORDENTRABAJO.ADELANTO as ANTICIPO, 
                                                            DOCUMENTOS_ORDENTRABAJO.SALDO, 
                                                            DOCUMENTOS_ORDENTRABAJO.CODDOC, 
                                                            DOCUMENTOS_ORDENTRABAJO.CORRELATIVO
                                                FROM DOCUMENTOS_ORDENTRABAJO LEFT OUTER JOIN
                                                    CLIENTES_VEHICULOS ON DOCUMENTOS_ORDENTRABAJO.CODVEHICULO = CLIENTES_VEHICULOS.CODVEHICULO AND 
                                                    DOCUMENTOS_ORDENTRABAJO.EMPNIT = CLIENTES_VEHICULOS.EMPNIT LEFT OUTER JOIN
                                                    CLIENTES ON DOCUMENTOS_ORDENTRABAJO.CODCLIENTE = CLIENTES.CODCLIENTE AND DOCUMENTOS_ORDENTRABAJO.EMPNIT = CLIENTES.EMPNIT
                                                WHERE (DOCUMENTOS_ORDENTRABAJO.FINALIZADO = 'NO') AND (DOCUMENTOS_ORDENTRABAJO.EMPNIT = @EMPNIT)", cn)
                da.SelectCommand.Parameters.AddWithValue("@EMPNIT", empnit)
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
            End Try


            cn.Close()
        End Using

        Return tbl

    End Function


    Public Function EditOrdenTrabajo(ByVal coddoc As String,
                                      ByVal correlativo As Double,
                                      ByVal orden As String,
                                      ByVal obs As String,
                                      ByVal importe As Double
                                                             ) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS_ORDENTRABAJO SET ORDEN=@ORDEN,OBS=@OBS,IMPORTE=@IMPORTE WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@ORDEN", orden)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.Parameters.AddWithValue("@IMPORTE", importe)
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function InsertOrdenTrabajo(
                                      ByVal fecha As Date,
                                      ByVal coddoc As String,
                                      ByVal correlativo As Double,
                                      ByVal codcliente As Integer,
                                      ByVal codvehiculo As Integer,
                                      ByVal orden As String,
                                      ByVal obs As String,
                                      ByVal importe As Double,
                                      ByVal adelanto As Double,
                                      ByVal saldo As Double,
                                      ByVal fechaentrega As Date
                                    ) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("INSERT INTO DOCUMENTOS_ORDENTRABAJO 
                                            (EMPNIT,ANIO,MES,DIA,FECHA,CODDOC,CORRELATIVO,CODCLIENTE,CODVEHICULO,ORDEN,OBS,IMPORTE,ADELANTO,SALDO,FECHAENTREGA,FINALIZADO,ST) VALUES
                            (@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@CODDOC,@CORRELATIVO,@CODCLIENTE,@CODVEHICULO,@ORDEN,@OBS,@IMPORTE,@ADELANTO,@SALDO,@FECHAENTREGA,@FINALIZADO,@ST)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", fecha.Year)
                cmd.Parameters.AddWithValue("@MES", fecha.Month)
                cmd.Parameters.AddWithValue("@DIA", fecha.Day)
                cmd.Parameters.AddWithValue("@FECHA", fecha)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@CODCLIENTE", codcliente)
                cmd.Parameters.AddWithValue("@CODVEHICULO", codvehiculo)
                cmd.Parameters.AddWithValue("@ORDEN", orden)
                cmd.Parameters.AddWithValue("@OBS", obs)
                cmd.Parameters.AddWithValue("@IMPORTE", importe)
                cmd.Parameters.AddWithValue("@ADELANTO", adelanto)
                cmd.Parameters.AddWithValue("@SALDO", saldo)
                cmd.Parameters.AddWithValue("@FECHAENTREGA", fechaentrega)
                cmd.Parameters.AddWithValue("@FINALIZADO", "NO")
                cmd.Parameters.AddWithValue("@ST", "O")
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function TerminarOrdenTrabajo(ByVal coddoc As String, ByVal correlativo As Double, ByVal diagnostico As String, ByVal valor As Double, ByVal fechaentrega As Date, ByVal codempleado As Integer) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS_ORDENTRABAJO SET CODEMPLEADO=@CODEMPLEADO, FECHAENTREGA=@FECHAENTREGA, DIAGNOSTICO=@DIAGNOSTICO, IMPORTE=@VALOR, SALDO=0, FINALIZADO='SI', ST='T' WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@DIAGNOSTICO", diagnostico)
                cmd.Parameters.AddWithValue("@VALOR", valor)
                cmd.Parameters.AddWithValue("@FECHAENTREGA", fechaentrega)
                cmd.Parameters.AddWithValue("@CODEMPLEADO", codempleado)
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function DeleteOrdenTrabajo(ByVal coddoc As String, ByVal correlativo As Double) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("DELETE FROM DOCUMENTOS_ORDENTRABAJO  WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try

            cn.Close()
        End Using

        Return result

    End Function





End Class
