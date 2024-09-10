Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress

Public Class viewIngresoEfec

    Private Sub viewIngresoEfec_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'MsgBox(GlobalCoddocIEF)

        Dim ObjEmpleados As New ClassEmpleados
        Dim tblVend As New DataTable

        Me.cmbSucursales.select()
        'blVend = ObjEmpleados.tblListaEmpleados(GlobalEmpNit)
        tblVend = ObjEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 3)

        Me.datePickDocumento.Value = Today.Date

        With Me.cmbSucursales
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

        'Call EmpNITVPN()

        'MsgBox(sucEMPNIT)

        'Call CargarCorrelativoIEF()

        With Me.cmbEmpleados
            .DataSource = tblVend
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"
        End With

        GlobalCoddocIEF = "ING_EFEC"

        Me.txtCoddoc.Text = GlobalCoddocIEF


        Me.txtMotorista.Text = "S/N"
        Me.txtObservaciones.Text = "S/N"

        Call CargarGridIEF()

    End Sub

    Dim sucEMPNIT As String, sucNOMEMP As String

    Public Function EmpNITVPN()

        'Call AbrirConexionSql()
        Using cn As New SqlConnection(Me.cmbSucursales.SelectedValue.ToString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPNIT FROM EMPRESAS", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    sucEMPNIT = dr(0).ToString

                Else

                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
            End Try
        End Using
        'cn.Close()

    End Function

    Public Function nomempVPN()

        'Call AbrirConexionSql()
        Using cn As New SqlConnection(Me.cmbSucursales.SelectedValue.ToString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPNOMBRE FROM EMPRESAS", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    sucNOMEMP = dr(0).ToString

                Else

                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
            End Try
        End Using
        'cn.Close()

    End Function



    Public Function tblListaEmpresas() As DataTable
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("EMPNIT", GetType(String))
            .Add("SUCURSAL", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT EMPNIT, SUCURSAL FROM SERVIDORES", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                                    dr(0).ToString, 'EMPNIT
                                    dr(1).ToString  'SUCURSAL
                                          })
                Loop
                dr.Close()
                cmd.Dispose()
                Return tbl

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(GlobalDesError)
                Return Nothing
            End Try

            cn.Close()
        End Using
    End Function



    Private Sub btnGuardarIng_Click(sender As Object, e As EventArgs) Handles btnGuardarIng.Click


        'MsgBox(Me.txtCorrelativo.Text)
        Dim correl As Double = CType(Me.txtCorrelativo.Text, Double)

        If Confirmacion("¿Está seguro que desea guardar este traslado de efectivo?", Me.ParentForm) = True Then

            Using cn As New SqlConnection(Me.cmbSucursales.SelectedValue.ToString)
                Try


                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If


                    Dim cmd As New SqlCommand("INSERT INTO EFECTIVO_KH (EMPNIT, CODDOC, CORRELATIVO, DIA, MES, ANIO, FECHA, HORA, MINUTO, SUCURSAL_SAL, SUCURSAL_ING, MONTO, EMPLEADO, MOTORISTA, CORTE, OBSERVACIONES)
                                                               VALUES (@EMPNIT, @CODDOC, @CORRELATIVO, @DIA, @MES, @ANIO, @FECHA, @HORA, @MINUTO, @SUCURSAL_SAL, @SUCURSAL_ING, @MONTO, @EMPLEADO, @MOTORISTA, 'NO', @OBSERVACIONES)", cn)

                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocIEF)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtCorrelativo.Text))
                    cmd.Parameters.AddWithValue("@DIA", Me.datePickDocumento.Value.Year)
                    cmd.Parameters.AddWithValue("@MES", Me.datePickDocumento.Value.Month)
                    cmd.Parameters.AddWithValue("@ANIO", Me.datePickDocumento.Value.Day)
                    cmd.Parameters.AddWithValue("@FECHA", Me.datePickDocumento.Value)
                    cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                    cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                    cmd.Parameters.AddWithValue("@SUCURSAL_SAL", GlobalNomEmpresa)
                    cmd.Parameters.AddWithValue("@SUCURSAL_ING", sucNOMEMP)
                    cmd.Parameters.AddWithValue("@MONTO", Double.Parse(Me.txtTotalEfectivo.Text))
                    cmd.Parameters.AddWithValue("@EMPLEADO", Me.cmbEmpleados.Text)
                    cmd.Parameters.AddWithValue("@MOTORISTA", Me.txtMotorista.Text)
                    cmd.Parameters.AddWithValue("@OBSERVACIONES", Me.txtObservaciones.Text)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                Catch ex As Exception
                    GlobalDesError = ex.ToString
                    MsgBox(ex.ToString)

                End Try

            End Using

            Dim varFechaIEF As Date, varCorrelativoIEF As Double
            varFechaIEF = Me.datePickDocumento.Value
            varCorrelativoIEF = Double.Parse(Me.txtCorrelativo.Text)

            SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            Call insertDatosLocal()

            Call ActualizarCorrelativoIEF()

            Call CargarCorrelativoIEF()

            Call LimpiarDatosIEF()


            SplashScreenManager.CloseForm()

            MsgBox("Ingreso guardado exitosamente")

            Call AbrirReporte_IEF(correl)

            Me.cmbSucursales.select()

        End If

        Call CargarGridIEF()

    End Sub


    Private Sub insertDatosLocal()


        Using cn As New SqlConnection(strSqlConectionString)
            Try


                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("INSERT INTO EFECTIVO_KH (EMPNIT, CODDOC, CORRELATIVO, DIA, MES, ANIO, FECHA, HORA, MINUTO, SUCURSAL_SAL, SUCURSAL_ING, MONTO, EMPLEADO, MOTORISTA, CORTE, OBSERVACIONES)
                                                               VALUES (@EMPNIT, @CODDOC, @CORRELATIVO, @DIA, @MES, @ANIO, @FECHA, @HORA, @MINUTO, @SUCURSAL_SAL, @SUCURSAL_ING, @MONTO, @EMPLEADO, @MOTORISTA, 'LOCAL', @OBSERVACIONES)", cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocIEF)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtCorrelativo.Text))
                cmd.Parameters.AddWithValue("@DIA", Me.datePickDocumento.Value.Year)
                cmd.Parameters.AddWithValue("@MES", Me.datePickDocumento.Value.Month)
                cmd.Parameters.AddWithValue("@ANIO", Me.datePickDocumento.Value.Day)
                cmd.Parameters.AddWithValue("@FECHA", Me.datePickDocumento.Value)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@SUCURSAL_SAL", GlobalNomEmpresa)
                cmd.Parameters.AddWithValue("@SUCURSAL_ING", sucNOMEMP)
                cmd.Parameters.AddWithValue("@MONTO", Double.Parse(Me.txtTotalEfectivo.Text))
                cmd.Parameters.AddWithValue("@EMPLEADO", Me.cmbEmpleados.Text)
                cmd.Parameters.AddWithValue("@MOTORISTA", Me.txtMotorista.Text)
                cmd.Parameters.AddWithValue("@OBSERVACIONES", Me.txtObservaciones.Text)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox("Error al ejecutar: " + ex.ToString)

            End Try

        End Using


    End Sub

    Private Sub cmbSucursales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursales.Leave

        Call EmpNITVPN()
        Call nomempVPN()
        Call CargarCorrelativoIEF()

    End Sub

    Private Sub cmbEmpleados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEmpleados.Leave

        Call EmpNITVPN()
        Call nomempVPN()
        Call CargarCorrelativoIEF()

    End Sub

    Private Sub txtTotalEfectivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtTotalEfectivo.Leave

        Call EmpNITVPN()
        Call nomempVPN()
        Call CargarCorrelativoIEF()

    End Sub


    Private Sub cmbSucursales_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSucursales.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtCorteCajaObs.select()
            Me.txtTotalEfectivo.select()
        End If
    End Sub

    Private Sub txtTotalEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTotalEfectivo.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtCorteCajaObs.select()
            Me.cmbEmpleados.select()
        End If
    End Sub

    Private Sub cmbEmpleados_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEmpleados.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtCorteCajaObs.select()
            Me.txtMotorista.select()
        End If
    End Sub

    Private Sub txtMotorista_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMotorista.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtCorteCajaObs.select()
            Me.txtObservaciones.select()
        End If
    End Sub

    Private Sub txtObservaciones_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObservaciones.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtCorteCajaObs.select()
            Me.btnGuardarIng.select()
        End If
    End Sub

    Private Sub CargarCorrelativoIEF()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(Me.cmbSucursales.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & sucEMPNIT & "' AND CODDOC='ING_EFEC'", cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    Me.txtCorrelativo.Text = dr(0).ToString
                End If
            Catch ex As Exception

                Me.txtCorrelativo.Text = 0

            End Try
            dr.Close()
            cmd.Dispose()
        End Using
        'cn.Close()

    End Sub

    Private Sub ActualizarCorrelativoIEF()
        'Call AbrirConexionSql()
        Using cn As New SqlConnection(Me.cmbSucursales.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim SQL As String
            SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=@N WHERE EMPNIT=@E AND CODDOC=@D"

            Dim cmd As New SqlCommand(SQL, cn)
            cmd.Parameters.AddWithValue("@E", sucEMPNIT)
            cmd.Parameters.AddWithValue("@D", GlobalCoddocIEF)
            cmd.Parameters.AddWithValue("@N", (Double.Parse(Me.txtCorrelativo.Text) + 1))
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        End Using
        'cn.Close()
    End Sub

    Private Sub LimpiarDatosIEF()
        Me.txtTotalEfectivo.Text = "0.00"
        Me.txtMotorista.Text = "S/N"
        Me.txtObservaciones.Text = "S/N"

    End Sub

    Public Function AbrirReporte_IEF(ByVal Correlativo As Double) As Boolean
        'SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim result As Boolean


        'MsgBox(Correlativo.ToString)


        Dim tbl As New DataTable("tblDocsIEF")

        With tbl
            .Columns.Add("EMPNOMBRE", GetType(String))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("SUCURSAL_SAL", GetType(String))
            .Columns.Add("SUCURSAL_ING", GetType(String))
            .Columns.Add("MONTO", GetType(Double))
            .Columns.Add("EMPLEADO", GetType(String))
            .Columns.Add("MOTORISTA", GetType(String))
            .Columns.Add("OBSERVACIONES", GetType(String))

        End With

        Using cn As New SqlConnection(Me.cmbSucursales.SelectedValue.ToString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim sql As String
                sql = "SELECT           EMPRESAS.EMPNOMBRE, 
                                        EFECTIVO_KH.CODDOC, 
                                        EFECTIVO_KH.CORRELATIVO, 
                                        EFECTIVO_KH.FECHA, 
                                        EFECTIVO_KH.SUCURSAL_SAL,
                                        EFECTIVO_KH.SUCURSAL_ING, 
                                        EFECTIVO_KH.MONTO, 
                                        EFECTIVO_KH.EMPLEADO, 
                                        EFECTIVO_KH.MOTORISTA, 
                                        EFECTIVO_KH.OBSERVACIONES
                       FROM             EMPRESAS RIGHT OUTER JOIN
                                        EFECTIVO_KH ON EMPRESAS.EMPNIT = EFECTIVO_KH.EMPNIT
                       WHERE            (EFECTIVO_KH.CORRELATIVO = @CORRELATIVO)"

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", sucEMPNIT)
                'cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                          dr(0).ToString,'EMPRESA
                          dr(1).ToString,'CODDOC
                          Double.Parse(dr(2).ToString),'CORRELATIVO
                          Date.Parse(dr(3)),'FECHA
                          dr(4).ToString,'SUC_SAL
                          dr(5).ToString,'SUC_ING
                          Double.Parse(dr(6)),'MONTO
                          dr(7).ToString,'EMPLEADO
                          dr(8).ToString,'MOTORISTA
                          dr(9).ToString  'OBSERVACIONES
                                                })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()
                result = True

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception

                MsgBox(ex.ToString)

                GlobalDesError = ex.ToString
                SplashScreenManager.CloseForm()
                Return False

            End Try


        End Using


        Dim Adapter As New SqlDataAdapter
        Dim report As New rptIEF

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblDocsIEF"



        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        'report.Print

        'SplashScreenManager.CloseForm()

        report.ShowPreview

        Return result

    End Function

    Public Function AbrirReporte_IEFLOCAL(ByVal Correlativo As Double, tipo As String) As Boolean
        'SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
        Dim result As Boolean


        'MsgBox(Correlativo.ToString)


        Dim tbl As New DataTable("tblDocsIEF")

        With tbl
            .Columns.Add("EMPNOMBRE", GetType(String))
            .Columns.Add("CODDOC", GetType(String))
            .Columns.Add("CORRELATIVO", GetType(Double))
            .Columns.Add("FECHA", GetType(Date))
            .Columns.Add("SUCURSAL_SAL", GetType(String))
            .Columns.Add("SUCURSAL_ING", GetType(String))
            .Columns.Add("MONTO", GetType(Double))
            .Columns.Add("EMPLEADO", GetType(String))
            .Columns.Add("MOTORISTA", GetType(String))
            .Columns.Add("OBSERVACIONES", GetType(String))

        End With

        Dim sql As String

        Select Case tipo

            Case "NO"
                sql = "SELECT           EMPRESAS.EMPNOMBRE, 
                                        EFECTIVO_KH.CODDOC, 
                                        EFECTIVO_KH.CORRELATIVO, 
                                        EFECTIVO_KH.FECHA, 
                                        EFECTIVO_KH.SUCURSAL_SAL,
                                        EFECTIVO_KH.SUCURSAL_ING, 
                                        EFECTIVO_KH.MONTO, 
                                        EFECTIVO_KH.EMPLEADO, 
                                        EFECTIVO_KH.MOTORISTA, 
                                        EFECTIVO_KH.OBSERVACIONES
                       FROM             EMPRESAS RIGHT OUTER JOIN
                                        EFECTIVO_KH ON EMPRESAS.EMPNIT = EFECTIVO_KH.EMPNIT
                       WHERE            (EFECTIVO_KH.CORRELATIVO = @CORRELATIVO) AND (EFECTIVO_KH.CORTE = 'NO')"

            Case "LOCAL"
                sql = "SELECT           EMPRESAS.EMPNOMBRE, 
                                        EFECTIVO_KH.CODDOC, 
                                        EFECTIVO_KH.CORRELATIVO, 
                                        EFECTIVO_KH.FECHA, 
                                        EFECTIVO_KH.SUCURSAL_SAL,
                                        EFECTIVO_KH.SUCURSAL_ING, 
                                        EFECTIVO_KH.MONTO, 
                                        EFECTIVO_KH.EMPLEADO, 
                                        EFECTIVO_KH.MOTORISTA, 
                                        EFECTIVO_KH.OBSERVACIONES
                       FROM             EMPRESAS RIGHT OUTER JOIN
                                        EFECTIVO_KH ON EMPRESAS.EMPNIT = EFECTIVO_KH.EMPNIT
                       WHERE            (EFECTIVO_KH.CORRELATIVO = @CORRELATIVO) AND (EFECTIVO_KH.CORTE = 'LOCAL')"
        End Select

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand(sql, cn)
                'cmd.Parameters.AddWithValue("@CODDOC", Coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Correlativo)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader

                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                          dr(0).ToString,'EMPRESA
                          dr(1).ToString,'CODDOC
                          Double.Parse(dr(2).ToString),'CORRELATIVO
                          Date.Parse(dr(3)),'FECHA
                          dr(4).ToString,'SUC_ING
                          dr(5).ToString,'SUC_ING
                          Double.Parse(dr(6)),'MONTO
                          dr(7).ToString,'EMPLEADO
                          dr(8).ToString,'MOTORISTA
                          dr(9).ToString  'OBSERVACIONES
                                                })
                Loop

                dr.Close()
                dr = Nothing
                cmd.Dispose()

                cn.Close()
                result = True

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception

                MsgBox(ex.ToString)

                GlobalDesError = ex.ToString
                SplashScreenManager.CloseForm()
                Return False

            End Try


        End Using


        Dim Adapter As New SqlDataAdapter
        Dim report As New rptIEF

        report.DataSource = tbl
        report.DataAdapter = Adapter
        report.DataMember = "tblDocsIEF"


        Dim tool As ReportPrintTool = New ReportPrintTool(report)
        report.CreateDocument()
        'report.Print

        'SplashScreenManager.CloseForm()

        report.ShowPreview

        Return result

    End Function

    Private Sub btnCorteIEF_Click(sender As Object, e As EventArgs) Handles btnCorteIEF.Click

        If FlyoutDialog.Show(Me.ParentForm, New viewCorteIEF) = DialogResult.OK Then

        End If

    End Sub

    Public Sub CargarGridIEF()

        Me.GridEFECINGRESADO.DataSource = Nothing
        Me.GridEFECINGRESADO.DataSource = tblEFEC("INGRESADO")

        Me.GridEFECENVIADO.DataSource = Nothing
        Me.GridEFECENVIADO.DataSource = tblEFEC("ENVIADO")
    End Sub

    Private Function tblEFEC(ByVal tipodoc As String) As DataTable
        Dim tbl As New DSDOCUMENTOS.tblEFECDataTable

        Dim sql As String

        Select Case tipodoc

            Case "INGRESADO"
                sql = "SELECT           CODDOC, CORRELATIVO, FECHA, HORA, MINUTO, SUCURSAL_SAL, SUCURSAL_ING, MONTO, EMPLEADO, MOTORISTA
                       FROM             EFECTIVO_KH
                       WHERE            (CORTE = 'NO') AND (FECHA = @F) AND (EMPNIT = @EMPNIT)"

            Case "ENVIADO"
                sql = "SELECT           CODDOC, CORRELATIVO, FECHA, HORA, MINUTO, SUCURSAL_SAL, SUCURSAL_ING, MONTO, EMPLEADO, MOTORISTA
                       FROM             EFECTIVO_KH
                       WHERE            (CORTE = 'LOCAL') AND (FECHA = @F) AND (EMPNIT = @EMPNIT)"
        End Select

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@F", Date.Parse(Me.datePickDocumento.Value))

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception

                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function

    Dim drw As DataRow

    Private Sub GridINGRESADO_FocusedRowChanged(sender As Object, e As XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridINGRESADO.FocusedRowChanged
        Try

            drw = Nothing
            drw = Me.GridINGRESADO.GetFocusedDataRow

            Call CargarDatos(drw)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridENVIADO_FocusedRowChanged(sender As Object, e As XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridENVIADO.FocusedRowChanged
        Try

            drw = Nothing
            drw = Me.GridENVIADO.GetFocusedDataRow

            Call CargarDatos(drw)

        Catch ex As Exception

        End Try
    End Sub

    Dim correl As Integer

    Private Sub CargarDatos(ByVal dr As DataRow)
        correl = CType(dr.Item(1), Integer)

        Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub GridEFECINGRESADO_DoubleClick(sender As Object, e As EventArgs) Handles GridEFECINGRESADO.DoubleClick

        If Confirmacion("¿Está seguro que desea reimprimir este ingreso de efectivo?", Me.ParentForm) = True Then

            AbrirReporte_IEFLOCAL(correl, "NO")

        End If

    End Sub

    Private Sub GridEFECENVIADO_DoubleClick(sender As Object, e As EventArgs) Handles GridEFECENVIADO.DoubleClick

        If Confirmacion("¿Está seguro que desea reimprimir este traslado de efectivo?", Me.ParentForm) = True Then

            AbrirReporte_IEFLOCAL(correl, "LOCAL")

        End If

    End Sub

End Class
