Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient

Public Class viewBONOSDEP

    Private Sub viewBONOSDEP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call cargarComboEmp()
        Me.dtBONOS.DateTime = Today.Date

    End Sub

    Private Sub cargarComboEmp()

        Dim ObjEmp As New ClassEmpleados
        Dim tblEmpleados As New DataTable

        tblEmpleados = ObjEmp.tblListaEmpleados(GlobalEmpNit)

        With Me.cmbEmpleado

            .DataSource = tblEmpleados
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"

        End With

    End Sub

#Region "FUNCIONES FECHA"

    Public Function getFechaMesAnterior() As Date

        'obtengo el mes y le resto 1 para que sea el mes anterior
        Dim m As Integer = Today.Month - 1

        'obtengo el año
        Dim y As Integer = Today.Year

        'si al restar el mes me da cero, (1-1=0) quiere decir que el mes es 12 o sea diciembre
        If m = 0 Then
            m = 12
        End If

        'si el mes resulta siendo 12, entonces es porque es del año pasado, así que le resto 1 al año
        If m = 12 Then
            y = y - 1
        End If

        'f va a ser la variable tipo fecha que te va a servir
        Dim f As New Date

        'armás f con el día, el mes y el año separado por guiones (-)
        f = Date.Parse("22" + "-" + m.ToString + "-" + y.ToString)

        Return f

    End Function

    Public Function getFechaPrimera() As Date

        'obtengo el mes y le resto 1 para que sea el mes anterior
        Dim m As Integer = Today.Month

        'obtengo el año
        Dim y As Integer = Today.Year

        'f va a ser la variable tipo fecha que te va a servir
        Dim f As New Date

        'armás f con el día, el mes y el año separado por guiones (-)
        f = Date.Parse("7" + "-" + m.ToString + "-" + y.ToString)

        Return f

    End Function

    Public Function getFechaSegunda() As Date

        'obtengo el mes y le resto 1 para que sea el mes anterior
        Dim m As Integer = Today.Month

        'obtengo el año
        Dim y As Integer = Today.Year

        'f va a ser la variable tipo fecha que te va a servir
        Dim f As New Date

        'armás f con el día, el mes y el año separado por guiones (-)
        f = Date.Parse("8" + "-" + m.ToString + "-" + y.ToString)

        Return f

    End Function

    Public Function getFechaSegundaF() As Date

        'obtengo el mes y le resto 1 para que sea el mes anterior
        Dim m As Integer = Today.Month

        'obtengo el año
        Dim y As Integer = Today.Year

        'f va a ser la variable tipo fecha que te va a servir
        Dim f As New Date

        'armás f con el día, el mes y el año separado por guiones (-)
        f = Date.Parse("21" + "-" + m.ToString + "-" + y.ToString)

        Return f

    End Function

#End Region

#Region "CARGAR GRID"

    Private Sub cargarGridPRIMERA()

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing

        Me.GridControlPRODUCTOS.DataSource = tblBonosProductos(1)

        Me.GridControlPRODUCTOS.RefreshDataSource()

        SplashScreenManager.CloseForm()

    End Sub

    Private Sub cargarGridSEGUNDA()

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing

        Me.GridControlPRODUCTOS.DataSource = tblTopProductosSEGUNDA()

        Me.GridControlPRODUCTOS.RefreshDataSource()

        SplashScreenManager.CloseForm()

    End Sub

#End Region

#Region "CONSULTAS"

#Region "LLENADO DE LA TABLA"

    Private Function tblBonosProductos(ByVal NoFiltro As Integer) As DataTable

        Dim tbl As New DataTable

        Dim sql As String

        Select Case NoFiltro
            Case 0
                sql = "SELECT           DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, PRODUCTOS.BONO, SUM(DOCPRODUCTOS.TOTALUNIDADES) 
                                                            * PRODUCTOS.BONO AS TOTALBONO
                                           FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            PRODUCTOS RIGHT OUTER JOIN
                                                            DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                                            DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 1 AND 7) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                                           GROUP BY         DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO
                                           HAVING           (PRODUCTOS.BONO > 0)"
            Case 1
                sql = "SELECT           DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, PRODUCTOS.BONO, SUM(DOCPRODUCTOS.TOTALUNIDADES) 
                                                            * PRODUCTOS.BONO AS TOTALBONO
                                           FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            PRODUCTOS RIGHT OUTER JOIN
                                                            DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                                            DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 8 AND 15) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                                           GROUP BY         DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO
                                           HAVING           (PRODUCTOS.BONO > 0)"
            Case 2
                sql = "SELECT           DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, PRODUCTOS.BONO, SUM(DOCPRODUCTOS.TOTALUNIDADES) 
                                                            * PRODUCTOS.BONO AS TOTALBONO
                                           FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            PRODUCTOS RIGHT OUTER JOIN
                                                            DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                                            DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 16 AND 23) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                                           GROUP BY         DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO
                                           HAVING           (PRODUCTOS.BONO > 0)"
            Case 3
                sql = "SELECT           DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, PRODUCTOS.BONO, SUM(DOCPRODUCTOS.TOTALUNIDADES) 
                                                            * PRODUCTOS.BONO AS TOTALBONO
                                           FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            PRODUCTOS RIGHT OUTER JOIN
                                                            DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                                            DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 24 AND 31) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                                           GROUP BY         DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO
                                           HAVING           (PRODUCTOS.BONO > 0)"
        End Select


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@M", Me.dtBONOS.DateTime.Month)
                cmd.Parameters.AddWithValue("@A", Me.dtBONOS.DateTime.Year)
                cmd.Parameters.AddWithValue("@EM", Integer.Parse(Me.cmbEmpleado.SelectedValue))
                cmd.CommandTimeout = 0
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox("productos: " + GlobalDesError)
            End Try

        End Using

        Return tbl
    End Function

    Private Function tblTopProductosSEGUNDA() As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           DOCPRODUCTOS.DESPROD, SUM(DOCPRODUCTOS.TOTALUNIDADES) AS UNIDADES, PRODUCTOS.BONO, SUM(DOCPRODUCTOS.TOTALUNIDADES) 
                                                            * PRODUCTOS.BONO AS TOTALBONO
                                           FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                                            DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                            PRODUCTOS RIGHT OUTER JOIN
                                                            DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                                            DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                                           WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF)
                                           GROUP BY         DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, DOCPRODUCTOS.MES, DOCPRODUCTOS.ANIO
                                           HAVING           (PRODUCTOS.BONO > 0)", cn)
                cmd.Parameters.AddWithValue("@FI", getFechaSegunda)
                cmd.Parameters.AddWithValue("@FF", getFechaSegundaF)
                cmd.Parameters.AddWithValue("@EM", Integer.Parse(Me.cmbEmpleado.SelectedValue))
                cmd.CommandTimeout = 0
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
                GlobalDesError = ex.ToString
                MsgBox("productos: " + GlobalDesError)
            End Try

        End Using

        Return tbl
    End Function

#End Region

#Region "TOTAL BONO"

    Private Sub TotalBono(ByVal NoFiltro As Integer)

        Dim sql As String

        Select Case NoFiltro
            Case 0
                sql = "SELECT           SUM(DOCPRODUCTOS.TOTALUNIDADES * PRODUCTOS.BONO) AS TOTALBONO
                       FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                        DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                        PRODUCTOS RIGHT OUTER JOIN
                                        DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                        DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                       WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 1 AND 7) AND 
                                        (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                       HAVING           (SUM(PRODUCTOS.BONO) > 0)"
            Case 1
                sql = "SELECT           SUM(DOCPRODUCTOS.TOTALUNIDADES * PRODUCTOS.BONO) AS TOTALBONO
                       FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                        DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                        PRODUCTOS RIGHT OUTER JOIN
                                        DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                        DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                       WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 8 AND 15) AND 
                                        (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                       HAVING           (SUM(PRODUCTOS.BONO) > 0)"
            Case 2
                sql = "SELECT           SUM(DOCPRODUCTOS.TOTALUNIDADES * PRODUCTOS.BONO) AS TOTALBONO
                       FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                        DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                        PRODUCTOS RIGHT OUTER JOIN
                                        DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                        DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                       WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 16 AND 23) AND 
                                        (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                       HAVING           (SUM(PRODUCTOS.BONO) > 0)"
            Case 3
                sql = "SELECT           SUM(DOCPRODUCTOS.TOTALUNIDADES * PRODUCTOS.BONO) AS TOTALBONO
                       FROM             TIPODOCUMENTOS RIGHT OUTER JOIN
                                        DOCUMENTOS ON TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT AND TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                        PRODUCTOS RIGHT OUTER JOIN
                                        DOCPRODUCTOS ON PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD AND PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                        DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                       WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 24 AND 31) AND 
                                        (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                       HAVING           (SUM(PRODUCTOS.BONO) > 0)"

        End Select


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)

                cmd.Parameters.AddWithValue("@M", Me.dtBONOS.DateTime.Month)
                cmd.Parameters.AddWithValue("@A", Me.dtBONOS.DateTime.Year)
                cmd.Parameters.AddWithValue("@EM", Integer.Parse(Me.cmbEmpleado.SelectedValue))

                Dim dr As SqlDataReader = cmd.ExecuteReader

                dr.Read()
                If dr.HasRows = True Then

                    If dr.HasRows = True Then
                        Me.txtTOTALBONO.Text = dr(0).ToString
                    Else
                        Me.txtTOTALBONO.Text = "0"
                    End If

                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString

            End Try

        End Using

    End Sub

    Private Sub TotalBonoSEGUNDA()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT           SUM(DOCPRODUCTOS.TOTALUNIDADES * PRODUCTOS.BONO) As TOTALBONO
                                 From             TIPODOCUMENTOS RIGHT OUTER Join
                                                   DOCUMENTOS On TIPODOCUMENTOS.EMPNIT = DOCUMENTOS.EMPNIT And TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER Join
                                                  PRODUCTOS RIGHT OUTER Join
                                                 DOCPRODUCTOS On PRODUCTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And PRODUCTOS.CODPROD = DOCPRODUCTOS.CODPROD And PRODUCTOS.DESPROD = DOCPRODUCTOS.DESPROD ON 
                                                DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT And DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC And DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                              WHERE            (TIPODOCUMENTOS.TIPODOC IN ('FAC', 'FEF')) AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%')) AND (DOCUMENTOS.STATUS = 'O') AND (DOCUMENTOS.CODVEN = @EM) AND (DOCUMENTOS.DIA BETWEEN 1 AND 7) AND (DOCUMENTOS.MES = @M) AND (DOCUMENTOS.ANIO = @A)
                           HAVING           (SUM(PRODUCTOS.BONO) > 0)", cn)
                cmd.Parameters.AddWithValue("@FI", getFechaSegunda)
                cmd.Parameters.AddWithValue("@FF", getFechaSegundaF)
                cmd.Parameters.AddWithValue("@EM", Integer.Parse(Me.cmbEmpleado.SelectedValue))

                Dim dr As SqlDataReader = cmd.ExecuteReader

                dr.Read()
                If dr.HasRows = True Then

                    If dr.HasRows = True Then
                        Me.txtTOTALBONO.Text = dr(0).ToString
                    Else
                        Me.txtTOTALBONO.Text = ""
                    End If

                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString

            End Try

        End Using

    End Sub

#End Region

#End Region

#Region "BTNS CARGAR"

    Private Sub btnCargarPRIMERA_Click(sender As Object, e As EventArgs) Handles btnCargarPRIMERA.Click

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing
        Me.GridControlPRODUCTOS.DataSource = tblBonosProductos(0)
        Me.GridControlPRODUCTOS.RefreshDataSource()

        Call TotalBono(0)

        SplashScreenManager.CloseForm()

    End Sub

    Private Sub btnCargarSEGUNDA_Click(sender As Object, e As EventArgs) Handles btnCargarSEGUNDA.Click

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing
        Me.GridControlPRODUCTOS.DataSource = tblBonosProductos(1)
        Me.GridControlPRODUCTOS.RefreshDataSource()

        Call TotalBono(1)

        SplashScreenManager.CloseForm()

    End Sub

    Private Sub btnCargarTERCERA_Click(sender As Object, e As EventArgs) Handles btnCargarTERCERA.Click

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing
        Me.GridControlPRODUCTOS.DataSource = tblBonosProductos(2)
        Me.GridControlPRODUCTOS.RefreshDataSource()

        Call TotalBono(2)

        SplashScreenManager.CloseForm()

    End Sub

    Private Sub btnCargarCUARTA_Click(sender As Object, e As EventArgs) Handles btnCargarcCUARTA.Click

        SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Me.GridControlPRODUCTOS.DataSource = Nothing
        Me.GridControlPRODUCTOS.DataSource = tblBonosProductos(3)
        Me.GridControlPRODUCTOS.RefreshDataSource()

        Call TotalBono(3)

        SplashScreenManager.CloseForm()

    End Sub

#End Region

End Class
