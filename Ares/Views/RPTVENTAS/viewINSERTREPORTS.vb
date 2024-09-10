Imports DevExpress.XtraSplashScreen
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization


Public Class viewINSERTREPORTS

    Private Sub viewINSERTREPORTS_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSucursales
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

    End Sub

    Public Function getConectionString(ByVal server As String, ByVal db As String, ByVal user As String, ByVal pass As String) As String
        Dim str As String = ""

        str = "Data Source=" & server & ";Initial Catalog=" & db & ";User ID=" & user & ";Password=" & pass & ";MultipleActiveResultSets=True"

        Return str

    End Function

    Public Function insertDatosINDIVIDUALES() As Boolean

        Dim result As Boolean

        Using cnh As New SqlConnection(Me.cmbSucursales.ToString)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT          INVSALDO.CODPROD, PRODUCTOS.DESPROD, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, PRODUCTOS.COSTO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, INVSALDO.EMPNIT, 
                                                            EMPRESAS.EMPNOMBRE
                                            FROM            EMPRESAS RIGHT OUTER JOIN
                                                            INVSALDO ON EMPRESAS.EMPNIT = INVSALDO.EMPNIT LEFT OUTER JOIN
                                                            MARCAS RIGHT OUTER JOIN
                                                            PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                                            WHERE           (NOT (INVSALDO.EMPNIT LIKE 'BACK%%'))
                                            ORDER BY        PRODUCTOS.DESPROD", cnh)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(strSqlConectionString)
                Dim cn As New SqlConnection(strSqlConectionString)
                cn.Open()
                bcCopy.DestinationTableName = "REPORT_GENERALES"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
                result = False
            End Try
        End Using

        Return result


    End Function

    Public Function insertDatosTotales() As Boolean

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim result As Boolean

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If

                        Dim cmdvpn As New SqlCommand("SELECT        INVSALDO.CODPROD, PRODUCTOS.DESPROD, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, PRODUCTOS.COSTO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, INVSALDO.EMPNIT, 
                                                    EMPRESAS.EMPNOMBRE
                                            FROM            EMPRESAS RIGHT OUTER JOIN
                                                    INVSALDO ON EMPRESAS.EMPNIT = INVSALDO.EMPNIT LEFT OUTER JOIN
                                                    MARCAS RIGHT OUTER JOIN
                                                        PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                                                WHERE        (NOT (INVSALDO.EMPNIT LIKE 'BACK%%'))
                                            ORDER BY PRODUCTOS.DESPROD", cnvpn)

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader

                        Dim bcCopy As New SqlBulkCopy(strSqlConectionString)
                        Dim cn As New SqlConnection(strSqlConectionString)
                        cn.Open()
                        bcCopy.DestinationTableName = "REPORT_GENERALES"
                        bcCopy.WriteToServer(drvpn)
                        drvpn.Close()
                        cn.Close()
                    End Using
                Catch ex As Exception
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception
            result = False
        End Try

        SplashScreenManager.CloseForm()

        Return result



    End Function

    Private Function exportTotales()

        Dim result As Boolean

        Using cnh As New SqlConnection(Me.cmbSucursales.ToString)

            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If

                'INSERTA LOS DATOS A LA TABLA PRODUCTOS
                Dim cmdh As New SqlCommand("SELECT          INVSALDO.CODPROD, PRODUCTOS.DESPROD, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO, PRODUCTOS.COSTO, PRODUCTOS.CODMARCA, MARCAS.DESMARCA, INVSALDO.EMPNIT, 
                                                            EMPRESAS.EMPNOMBRE
                                            FROM            EMPRESAS RIGHT OUTER JOIN
                                                            INVSALDO ON EMPRESAS.EMPNIT = INVSALDO.EMPNIT LEFT OUTER JOIN
                                                            MARCAS RIGHT OUTER JOIN
                                                            PRODUCTOS ON MARCAS.EMPNIT = PRODUCTOS.EMPNIT AND MARCAS.CODMARCA = PRODUCTOS.CODMARCA ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                                            WHERE           (NOT (INVSALDO.EMPNIT LIKE 'BACK%%'))
                                            ORDER BY        PRODUCTOS.DESPROD", cnh)
                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(strSqlConectionString)
                Dim cn As New SqlConnection(strSqlConectionString)
                cn.Open()
                bcCopy.DestinationTableName = "REPORT_GENERALES"
                bcCopy.WriteToServer(drh)
                drh.Close()
                cn.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
                result = False
            End Try
        End Using

        Return result

    End Function

    Private Sub btnINSERTTOTALEXISTENCIAS_Click(sender As Object, e As EventArgs) Handles btnINSERTTOTALEXISTENCIAS.Click

        Call insertDatosTotales()

    End Sub

    Private Function TBLGENERALTOTAL() As DataTable

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("SELECT           CODPROD, DESPROD, SUM(ENTRADAS) AS ENTRADAS, SUM(SALIDAS) AS SALIDAS, SUM(SALDO) AS SALDO, COSTO, DESMARCA
                                           FROM             REPORT_GENERALES
                                           GROUP BY         CODPROD, DESPROD, COSTO, DESMARCA
                                           ORDER BY         DESPROD", cn)

                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                'MsgBox(tbl.Rows.Count.ToString)

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using

        SplashScreenManager.CloseForm()

        Return tbl

    End Function

    Private Function cleanGENERAL()

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If
            Try
                Dim cmd As New SqlCommand("DELETE FROM REPORT_GENERALES", cn)
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
            End Try

        End Using

        SplashScreenManager.CloseForm()

        Return result

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


    End Sub

    Private Function cargargrid()

        Me.gridExports1.DataSource = Nothing
        Me.gridExports1.DataSource = TBLGENERALTOTAL()
        Me.gridExports1.RefreshDataSource()

    End Function

    Private Sub btnEXPORTINV_Click(sender As Object, e As EventArgs) Handles btnEXPORTINV.Click


        'Call cargargrid()

        Try
            Me.gridExports1.ExportToXlsx(Application.StartupPath + "\EXPORTS\InventarioGeneralTOTAL.xlsx")
            Process.Start(Application.StartupPath + "\EXPORTS\InventarioGeneralTOTAL.xlsx")

        Catch ex As Exception
            MsgBox("Ha ocurrido un error y no se pudo cargar el Listado. Error: " & ex.ToString)
        End Try
        Me.gridExports1.DataSource = Nothing

        'Call cleanGENERAL()

    End Sub
End Class
