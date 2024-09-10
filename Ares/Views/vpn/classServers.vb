Imports Security
Imports System.Data.SqlClient

Public Class classServers

    Dim sc As New Security.Seguridad("razors1805")


    Sub New()
        Call createTable()
    End Sub

    Public Function createTable() As Boolean
        Dim r As Boolean

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("CREATE TABLE [dbo].[SERVIDORES](
	                                        [ID] [int] IDENTITY(1,1) NOT NULL,
                                            [EMPNIT] [varchar](255) NULL,
                                            [SUCURSAL] [varchar](255) NULL,
	                                        [SERVER] [varchar](255) NULL,
	                                        [DB] [varchar](255) NULL,
	                                        [USUARIO] [varchar](255) NULL,
	                                        [CLAVE] [varchar](255) NULL
                                        ) ON [PRIMARY]", cn)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If


            End Using
        Catch ex As Exception
            r = False
        End Try

        Return r

    End Function

    Public Function insert_server(ByVal sucursal As String, ByVal server As String, ByVal db As String, ByVal usuario As String, ByVal pass As String) As Boolean
        Dim r As Boolean

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("INSERT INTO SERVIDORES (SERVER,DB,USUARIO,CLAVE,SUCURSAL) VALUES (@S,@D,@U,@P,@SUC)", cn)
            cmd.Parameters.AddWithValue("@S", server)
            cmd.Parameters.AddWithValue("@D", db)
            cmd.Parameters.AddWithValue("@U", usuario)
            cmd.Parameters.AddWithValue("@P", pass)
            cmd.Parameters.AddWithValue("@SUC", sucursal)

            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                r = True
            Else
                r = False
            End If

        Catch ex As Exception
            r = False
        End Try

        Return r
    End Function


    Public Function edit_server(ByVal id As Integer, ByVal sucursal As String, ByVal server As String, ByVal db As String, ByVal usuario As String, ByVal pass As String) As Boolean
        Dim r As Boolean

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("UPDATE SERVIDORES SET SUCURSAL=@SUC,SERVER=@S,DB=@D,USUARIO=@U,CLAVE=@P WHERE ID=@ID", cn)
            cmd.Parameters.AddWithValue("@S", server)
            cmd.Parameters.AddWithValue("@D", db)
            cmd.Parameters.AddWithValue("@U", usuario)
            cmd.Parameters.AddWithValue("@P", pass)
            cmd.Parameters.AddWithValue("@ID", id)
            cmd.Parameters.AddWithValue("@SUC", sucursal)

            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                r = True
            Else
                r = False
            End If

        Catch ex As Exception
            r = False
        End Try

        Return r
    End Function

    Public Function getTblServers() As DataTable
        Dim tbl As New DataTable

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES", cn)
            Dim da As New SqlDataAdapter
            da.SelectCommand = cmd
            da.Fill(tbl)

        Catch ex As Exception
            tbl = Nothing
        End Try

        Return tbl


    End Function


    Public Function delete_server(ByVal id As Integer) As Boolean
        Dim r As Boolean

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("DELETE FROM SERVIDORES WHERE ID=@ID", cn)
            cmd.Parameters.AddWithValue("@ID", id)

            Dim i As Integer = cmd.ExecuteNonQuery
            If i > 0 Then
                r = True
            Else
                r = False
            End If

        Catch ex As Exception
            r = False
        End Try

        Return r

    End Function


    Public Function getTblInventarioOnline(ByVal codprod As String) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("EMPRESA", GetType(String))
            .Add("CODPROD", GetType(String))
            .Add("DESPROD", GetType(String))
            .Add("ENTRADAS", GetType(Double))
            .Add("SALIDAS", GetType(Double))
            .Add("EXISTENCIA", GetType(Double))
        End With

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If

                        Dim cmdvpn As New SqlCommand("SELECT EMPRESAS.EMPNOMBRE AS EMPRESA, INVSALDO.CODPROD, PRODUCTOS.DESPROD, INVSALDO.ENTRADAS, INVSALDO.SALIDAS, INVSALDO.SALDO AS EXISTENCIA
                                            FROM INVSALDO LEFT OUTER JOIN
                                                 PRODUCTOS ON INVSALDO.CODPROD = PRODUCTOS.CODPROD AND INVSALDO.EMPNIT = PRODUCTOS.EMPNIT LEFT OUTER JOIN
                                                 EMPRESAS ON INVSALDO.EMPNIT = EMPRESAS.EMPNIT
                                            WHERE (INVSALDO.CODPROD = @CODPROD)", cnvpn)
                        cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)
                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        dr.Read()
                        If dr.HasRows = True Then
                            tbl.Rows.Add(New Object() {
                                         drvpn(0).ToString, 'EMPRESA
                                         drvpn(1).ToString, 'CODPROD
                                         drvpn(2).ToString, 'DESPROD
                                         CType(drvpn(3), Double), 'ENTRADAS
                                         CType(drvpn(4), Double), 'SALIDAS
                                         CType(drvpn(5), Double) 'EXISTENCIA
                                         })
                        Else

                        End If
                        cnvpn.Close()
                    End Using
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            Loop


        Catch ex As Exception
            tbl = Nothing
        End Try

        Return tbl


    End Function



    Public Function getConectionString(ByVal server As String, ByVal db As String, ByVal user As String, ByVal pass As String) As String
        Dim str As String = ""

        str = "Data Source=" & server & ";Initial Catalog=" & db & ";User ID=" & user & ";Password=" & pass & ";MultipleActiveResultSets=True"

        Return str

    End Function


    Public Function getTblInventarioProductoVpn(ByVal codprod As String) As DataTable

        Dim tbl As New DataTable

        With tbl.Columns
            .Add("EMPRESA", GetType(String))
            .Add("CODPROD", GetType(String))
            .Add("DESPROD", GetType(String))
            .Add("INICIAL", GetType(Double))
            .Add("ENTRADAS", GetType(Double))
            .Add("SALIDAS", GetType(Double))
            .Add("SALDO", GetType(Double))
            .Add("NOLOTE", GetType(String))
        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT LIKE 'distgarmen001'", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT EMPRESAS.EMPNOMBRE AS EMPRESA, 
                                                            INVSALDO.CODPROD, 
                                                            PRODUCTOS.DESPROD, 
                                                            INVSALDO.ENTRADAS, 
                                                            INVSALDO.SALIDAS, 
                                                            INVSALDO.SALDO
                                                        FROM INVSALDO LEFT OUTER JOIN
                                                            PRODUCTOS ON INVSALDO.CODPROD = PRODUCTOS.CODPROD AND INVSALDO.EMPNIT = PRODUCTOS.EMPNIT LEFT OUTER JOIN
                                                            EMPRESAS ON INVSALDO.EMPNIT = EMPRESAS.EMPNIT
                                                        WHERE (INVSALDO.CODPROD = @CODPROD) AND (INVSALDO.ANIO=0) AND (INVSALDO.MES=0)", cnvpn)
                        cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)
                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        drvpn.Read()

                        If drvpn.HasRows = True Then
                                tbl.Rows.Add(New Object() {
                                                 dr(1).ToString, 'drvpn(0).ToString, 'EMPRESA
                                                 drvpn(1).ToString, 'CODPROD
                                                 drvpn(2).ToString, 'DESPROD
                                                 0, 'INICIAL
                                                 CType(drvpn(3), Double), 'ENTRADAS
                                                 CType(drvpn(4), Double), 'SALIDAS
                                                 CType(drvpn(5), Double), 'EXISTENCIA
                                                 "" 'NOLOTE
                                             })
                            End If

                    End Using
                Catch ex As Exception
                    'MsgBox("Error al conectar con sucursal " + dr(1).ToString)
                End Try
            Loop


        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl


    End Function

    Public Function getTblSalidasVpn(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("FECHA", GetType(Date))
            .Add("PRODUCTO", GetType(String))
            .Add("UNIDADES", GetType(Double))
            .Add("SUC. SALIDA", GetType(String))
            .Add("NO. SALIDA", GetType(String))
            .Add("SUC. ENTRADA", GetType(String))
            .Add("NO. ENTRADA", GetType(Double))
        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT            DOCUMENTOS.FECHA, DOCPRODUCTOS.DESPROD AS PRODUCTO, DOCPRODUCTOS.TOTALUNIDADES AS UNIDADES, DOCUMENTOS.OBSMARCA AS [SUC. SALIDA], DOCUMENTOS.NOFAC AS [NO. SALIDA], EMPRESAS.EMPNOMBRE AS [SUC. ENTRADA], 
                                                                        DOCUMENTOS.CORRELATIVO AS [NO. ENTRADA]
                                                      FROM              DOCUMENTOS LEFT OUTER JOIN
                                                                        EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                                                        DOCPRODUCTOS ON DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                                                        TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                                      WHERE             (TIPODOCUMENTOS.TIPODOC IN ('TES', 'TIN')) AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (DOCUMENTOS.OBSMARCA NOT LIKE 'Farmacia Salud y Ahorro BODEGA')
                                                      ORDER BY          DOCUMENTOS.FECHA, DOCUMENTOS.OBSMARCA, DOCUMENTOS.NOFAC", cnvpn)
                        'cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)
                        cmdvpn.Parameters.AddWithValue("@FI", fechainicial)
                        cmdvpn.Parameters.AddWithValue("@FF", fechafinal)
                        'cmdvpn.CommandTimeout = 2

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             CType(drvpn(0), Date), 'drvpn(0).ToString, 'FECHA
                                             drvpn(1).ToString, 'PRODUCTO
                                             CType(drvpn(2), Double), 'UNIDADES
                                             drvpn(3).ToString, 'SUC. SALIDA
                                             drvpn(4).ToString.Replace("-", ""), 'NO. SALIDA
                                             drvpn(5).ToString, 'SUC. ENTRADA
                                             CType(drvpn(6), Double) 'NO. ENTRADA
                                        })
                        Loop

                    End Using
                Catch ex As Exception
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing



        Return tbl


    End Function

    Public Function getTblPrograVPN(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns

            .Add("SUCURSAL", GetType(String))
            .Add("FECHA", GetType(Date))
            .Add("CODPROD", GetType(String))
            .Add("DESPROD", GetType(String))
            .Add("CODMEDIDA", GetType(String))
            .Add("UNIDADES", GetType(Double))

        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT            EMPRESAS.EMPNOMBRE AS SUCURSAL, DOCUMENTOS.FECHA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.CODMEDIDA, DOCPRODUCTOS.CANTIDAD
                                                      FROM              DOCUMENTOS LEFT OUTER JOIN
                                                                        TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                                        EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                                                        DOCPRODUCTOS ON DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO
                                                      WHERE             (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (DOCPRODUCTOS.CODMEDIDA LIKE '%PROGRA%') AND (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC'))
                                                      ORDER BY          DOCUMENTOS.FECHA", cnvpn)
                        'cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)
                        cmdvpn.Parameters.AddWithValue("@FI", fechainicial)
                        cmdvpn.Parameters.AddWithValue("@FF", fechafinal)
                        'cmdvpn.CommandTimeout = 2

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             drvpn(0).ToString, 'SUCURSAL
                                             CType(drvpn(1), Date), 'drvpn(0).ToString, 'FECHA
                                             drvpn(2).ToString, 'CODPROD
                                             drvpn(3).ToString, 'DESPROD
                                             drvpn(4).ToString, 'CODMEDIDA
                                             CType(drvpn(5), Double) 'UNIDADES
                                        })
                        Loop

                    End Using
                Catch ex As Exception
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                    'MsgBox(ex.ToString)
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function


    Public Function getTblTRASVPN(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("FECHA", GetType(Date))
            .Add("SUC. SALIDA", GetType(String))
            .Add("SUC. ENTRADA", GetType(String))
            .Add("TOTAL COSTO", GetType(Double))

        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT            DOCUMENTOS.FECHA, DOCUMENTOS.OBSMARCA AS [SUC. SALIDA], EMPRESAS.EMPNOMBRE AS [SUC. ENTRADA], SUM(DOCPRODUCTOS.TOTALCOSTO) AS [TOTAL COSTO]
                                                      FROM              DOCUMENTOS LEFT OUTER JOIN
                                                                        EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT LEFT OUTER JOIN
                                                                        DOCPRODUCTOS ON DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                                                        TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                                       WHERE            (TIPODOCUMENTOS.TIPODOC IN ('TES', 'TIN'))
                                                       GROUP BY         DOCUMENTOS.FECHA, DOCUMENTOS.OBSMARCA, EMPRESAS.EMPNOMBRE
                                                       HAVING           (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (DOCUMENTOS.OBSMARCA LIKE 'Farmacia Salud y Ahorro BODEGA')
                                                       ORDER BY         DOCUMENTOS.FECHA, DOCUMENTOS.OBSMARCA", cnvpn)
                        'cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)
                        cmdvpn.Parameters.AddWithValue("@FI", fechainicial)
                        cmdvpn.Parameters.AddWithValue("@FF", fechafinal)
                        'cmdvpn.CommandTimeout = 2

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             CType(drvpn(0), Date), 'drvpn(0).ToString, 'FECHA
                                             drvpn(1).ToString, 'SUC. SALIDA
                                             drvpn(2).ToString.Replace("-", ""), 'SUC. ENTRADA
                                             CType(drvpn(3), Double) 'TOTAL COSTO
                                        })
                        Loop

                    End Using
                Catch ex As Exception
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function


    Public Function getTblGASTOSVPN(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("FECHA", GetType(Date))
            .Add("SUCURSAL", GetType(String))
            .Add("DOCUMENTO", GetType(String))
            .Add("CORRELATIVO", GetType(String))
            .Add("JUSTIFICACION", GetType(String))
            .Add("TOTAL GASTO", GetType(Double))
            .Add("TIPO", GetType(String))

        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT            DOCUMENTOS.FECHA, EMPRESAS.EMPNOMBRE AS SUCURSAL, DOCPRODUCTOS.CODDOC AS DOCUMENTO, DOCPRODUCTOS.CORRELATIVO, DOCPRODUCTOS.DESPROD AS JUSTIFICACION, 
                                                                        DOCPRODUCTOS.TOTALPRECIO AS [TOTAL GASTO], TIPOGASTOS.DESTIPOGASTO AS TIPO
                                                      FROM              TIPOGASTOS RIGHT OUTER JOIN
                                                                        DOCPRODUCTOS ON TIPOGASTOS.CODMEDIDA = DOCPRODUCTOS.CODMEDIDA RIGHT OUTER JOIN
                                                                        DOCUMENTOS LEFT OUTER JOIN
                                                                        EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT ON DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND 
                                                                        DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO
                                                      WHERE             (DOCPRODUCTOS.CODDOC = 'GASTOS') AND (DOCUMENTOS.FECHA BETWEEN @FI AND @FF)", cnvpn)
                        'cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)
                        cmdvpn.Parameters.AddWithValue("@FI", fechainicial)
                        cmdvpn.Parameters.AddWithValue("@FF", fechafinal)
                        'cmdvpn.CommandTimeout = 2

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             CType(drvpn(0), Date), 'drvpn(0).ToString, 'FECHA
                                             drvpn(1).ToString, 'SUCURSASL
                                             drvpn(2).ToString, 'DOCUMENTO
                                             drvpn(3).ToString, 'CORRELATIVO
                                             drvpn(4).ToString, 'JUSTIFICACION
                                             CType(drvpn(5), Double), 'TOTAL GASTO
                                             drvpn(6).ToString
                                                                    })
                        Loop

                    End Using
                Catch ex As Exception
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function

    Public Function getTblBONOSVPN(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("SUCURSAL", GetType(String))
            .Add("FECHA", GetType(Date))
            .Add("CODDCOC", GetType(String))
            .Add("CORRELATIVO", GetType(String))
            .Add("CODPROD", GetType(String))
            .Add("PRODUCTO", GetType(String))
            .Add("VENDIDOS", GetType(Double))
            .Add("BONO", GetType(Double))
            .Add("TOTAL_BONO", GetType(Double))
            .Add("PRECIO", GetType(Double))
            .Add("TOTAL_PRECIO", GetType(Double))
            .Add("MEDIDA", GetType(String))
            .Add("EMPLEADO", GetType(String))
        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT            EMPRESAS.EMPNOMBRE AS SUCURSAL, DOCUMENTOS.FECHA, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD AS PRODUCTO, 
                                                                        ISNULL(SUM(DOCPRODUCTOS.TOTALUNIDADES), 0) AS VENDIDOS, ISNULL(PRODUCTOS.BONO, 0) AS BONO, ISNULL(DOCPRODUCTOS.PRECIO,0) AS PRECIO, DOCPRODUCTOS.CODMEDIDA, EMPLEADOS.NOMEMPLEADO
                                                      FROM              TIPODOCUMENTOS RIGHT OUTER JOIN
                                                                        EMPLEADOS RIGHT OUTER JOIN
                                                                        DOCUMENTOS ON EMPLEADOS.CODEMPLEADO = DOCUMENTOS.CODVEN ON TIPODOCUMENTOS.CODDOC = DOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                                        DOCPRODUCTOS LEFT OUTER JOIN
                                                                        PRODUCTOS ON DOCPRODUCTOS.CODPROD = PRODUCTOS.CODPROD AND DOCPRODUCTOS.DESPROD = PRODUCTOS.DESPROD ON DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND 
                                                                        DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO LEFT OUTER JOIN
                                                                        EMPRESAS ON DOCUMENTOS.EMPNIT = EMPRESAS.EMPNIT
                                                      WHERE             (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC')) AND (DOCUMENTOS.STATUS = 'O') AND (NOT (PRODUCTOS.EMPNIT LIKE '%BACKU%'))
                                                      GROUP BY          EMPRESAS.EMPNOMBRE, DOCUMENTOS.FECHA, DOCUMENTOS.CORRELATIVO, DOCPRODUCTOS.DESPROD, PRODUCTOS.BONO, DOCPRODUCTOS.PRECIO, DOCUMENTOS.CODDOC, DOCPRODUCTOS.CODMEDIDA, EMPLEADOS.NOMEMPLEADO, 
                                                                        PRODUCTOS.CODMARCA, DOCPRODUCTOS.CODPROD
                                                      HAVING            (DOCUMENTOS.FECHA BETWEEN @FI AND @FF) AND (PRODUCTOS.BONO > 0)
                                                      ORDER BY          DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, EMPLEADOS.NOMEMPLEADO, PRODUCTOS.CODMARCA, PRODUCTO", cnvpn)
                        'cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)
                        cmdvpn.Parameters.AddWithValue("@FI", fechainicial)
                        cmdvpn.Parameters.AddWithValue("@FF", fechafinal)
                        'cmdvpn.CommandTimeout = 2

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             drvpn(0).ToString, 'SUCURSAL
                                             CType(drvpn(1), Date), 'FECHA
                                             drvpn(2).ToString, 'CODDOC
                                             drvpn(3).ToString, 'CORRELATIVO
                                             drvpn(4).ToString,
                                             drvpn(5).ToString, 'PRODUCTO
                                             CType(drvpn(6), Double), 'VENDIDOS
                                             CType(drvpn(7), Double),
                                             Double.Parse(drvpn(6)) * Double.Parse(drvpn(7)),
                                             CType(drvpn(8), Double),
                                             Double.Parse(drvpn(6)) * Double.Parse(drvpn(8)),
                                             drvpn(9).ToString,
                                             drvpn(10).ToString
                                                                                                })
                        Loop

                    End Using
                Catch ex As Exception
                    'GlobalDesError = ex.ToString
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function


    Public Function getTblGENERALES() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("SUCURSAL", GetType(String))
            .Add("CODPROD", GetType(String))
            .Add("DESPROD", GetType(String))
            .Add("SALDO", GetType(Double))
            .Add("COSTO", GetType(Double))
            .Add("DESMARCA", GetType(String))
        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT            EMPRESAS.EMPNOMBRE AS SUCURSAL, INVSALDO.CODPROD, PRODUCTOS.DESPROD, INVSALDO.SALDO, PRODUCTOS.COSTO, MARCAS.DESMARCA
                                                      FROM              PRODUCTOS LEFT OUTER JOIN
                                                                        MARCAS ON PRODUCTOS.EMPNIT = MARCAS.EMPNIT AND PRODUCTOS.CODMARCA = MARCAS.CODMARCA RIGHT OUTER JOIN
                                                                        EMPRESAS RIGHT OUTER JOIN
                                                                        INVSALDO ON EMPRESAS.EMPNIT = INVSALDO.EMPNIT ON PRODUCTOS.EMPNIT = INVSALDO.EMPNIT AND PRODUCTOS.CODPROD = INVSALDO.CODPROD
                                                      WHERE             (NOT (INVSALDO.EMPNIT LIKE 'BACK%%')) AND (PRODUCTOS.HABILITADO = 'SI')
                                                      GROUP BY          EMPRESAS.EMPNOMBRE, INVSALDO.CODPROD, PRODUCTOS.DESPROD, INVSALDO.SALDO, PRODUCTOS.COSTO, MARCAS.DESMARCA
                                                      ORDER BY          PRODUCTOS.DESPROD", cnvpn)
                        'cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)

                        'cmdvpn.CommandTimeout = 2

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             drvpn(0).ToString, 'SUCURSAL
                                             drvpn(1).ToString, 'FECHA
                                             drvpn(2).ToString, 'CODDOC
                                             Double.Parse(drvpn(3).ToString), 'CORRELATIVO
                                             Double.Parse(drvpn(4).ToString),
                                             drvpn(5).ToString 'PRODUCTO
                                                                                                })
                        Loop

                    End Using
                Catch ex As Exception
                    'GlobalDesError = ex.ToString
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function

    Public Function getTblVENTASVPN() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("SUCURSAL", GetType(String))
            .Add("ANIO", GetType(Integer))
            .Add("MES", GetType(Integer))
            .Add("DIA", GetType(Integer))
            .Add("CODPROD", GetType(String))
            .Add("DESPROD", GetType(String))
            .Add("VENDIDAS", GetType(Integer))
            .Add("COSTO", GetType(Double))
            .Add("TOTALCOSTO", GetType(Double))
            .Add("PRECIO", GetType(Double))
            .Add("TOTALPRECIO", GetType(Double))
        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT            EMPRESAS.EMPNOMBRE, DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, DOCPRODUCTOS.DIA, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, 
                                                                        SUM(DOCPRODUCTOS.TOTALUNIDADES) AS VENDIDAS, DOCPRODUCTOS.COSTO, SUM(DOCPRODUCTOS.TOTALCOSTO) AS TOTALCOSTO, DOCPRODUCTOS.PRECIO, SUM(DOCPRODUCTOS.TOTALPRECIO) 
                                                                        AS TOTALPRECIO
                                                      FROM              DOCUMENTOS RIGHT OUTER JOIN
                                                                        DOCPRODUCTOS ON DOCUMENTOS.CORRELATIVO = DOCPRODUCTOS.CORRELATIVO AND DOCUMENTOS.CODDOC = DOCPRODUCTOS.CODDOC AND DOCUMENTOS.EMPNIT = DOCPRODUCTOS.EMPNIT LEFT OUTER JOIN
                                                                        TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                                                                        EMPRESAS ON DOCPRODUCTOS.EMPNIT = EMPRESAS.EMPNIT
                                                      WHERE             (DOCUMENTOS.STATUS <> 'A') AND (TIPODOCUMENTOS.TIPODOC IN ('FEF', 'FAC'))
                                                      GROUP BY          EMPRESAS.EMPNOMBRE, DOCPRODUCTOS.ANIO, DOCPRODUCTOS.MES, DOCPRODUCTOS.CODPROD, DOCPRODUCTOS.DESPROD, DOCPRODUCTOS.DIA, DOCPRODUCTOS.COSTO, 
                                                                        DOCPRODUCTOS.PRECIO
                                                      HAVING            (DOCPRODUCTOS.ANIO = 2022) AND (DOCPRODUCTOS.MES BETWEEN 5 AND 7)
                                                      ORDER BY          DOCPRODUCTOS.MES, DOCPRODUCTOS.DIA, DOCPRODUCTOS.DESPROD", cnvpn)
                        'cmdvpn.Parameters.AddWithValue("@CODPROD", codprod)

                        'cmdvpn.CommandTimeout = 2

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             drvpn(0).ToString, 'SUCURSAL
                                             Integer.Parse(drvpn(1).ToString), 'FECHA
                                             Integer.Parse(drvpn(2).ToString), 'CODDOC
                                             Integer.Parse(drvpn(3).ToString), 'CORRELATIVO
                                             drvpn(4).ToString,
                                             drvpn(5).ToString, 'PRODUCTO
                                             Integer.Parse(drvpn(6).ToString), 'FECHA
                                             Double.Parse(drvpn(7).ToString), 'CODDOC
                                             Double.Parse(drvpn(8).ToString), 'CORRELATIVO
                                             Double.Parse(drvpn(9).ToString),
                                             Double.Parse(drvpn(10).ToString) 'PRODUCTO
                                                                                                })
                        Loop

                    End Using
                Catch ex As Exception
                    'GlobalDesError = ex.ToString
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function


    Public Function getTblIEF(ByVal fechainicial As Date, ByVal fechafinal As Date) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("SUCURSAL", GetType(String))
            .Add("CODDOC", GetType(String))
            .Add("CORRELATIVO", GetType(Integer))
            .Add("FECHA", GetType(Date))
            .Add("SUCURSAL_SAL", GetType(String))
            .Add("SUCURSAL_ING", GetType(String))
            .Add("MONTO", GetType(Double))
            .Add("EMPLEADO", GetType(String))
            .Add("MOTORISTA", GetType(String))
            .Add("CORTE", GetType(String))
            .Add("NO_CORTE", GetType(Integer))
            .Add("OBSERVACIONES", GetType(String))
        End With

        Dim conteo As Integer = 0

        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmd As New SqlCommand("SELECT ID, SUCURSAL, EMPNIT, SERVER, DB, USUARIO, CLAVE FROM SERVIDORES
                                       WHERE EMPNIT NOT IN ('distgarmen001', '002')", cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Do While dr.Read
                conteo = conteo + 1
                Try
                    Using cnvpn As New SqlConnection(getConectionString(dr(3).ToString, dr(4).ToString, dr(5).ToString, dr(6).ToString))
                        If cnvpn.State <> ConnectionState.Open Then
                            cnvpn.Open()
                        End If
                        Dim cmdvpn As New SqlCommand("SELECT        EMPRESAS.EMPNOMBRE, EFECTIVO_KH.CODDOC, EFECTIVO_KH.CORRELATIVO, EFECTIVO_KH.FECHA, EFECTIVO_KH.SUCURSAL_SAL, EFECTIVO_KH.SUCURSAL_ING, EFECTIVO_KH.MONTO, EFECTIVO_KH.EMPLEADO, 
                                                                    EFECTIVO_KH.MOTORISTA, EFECTIVO_KH.CORTE, EFECTIVO_KH.NO_CORTE, EFECTIVO_KH.OBSERVACIONES
                                                      FROM          EFECTIVO_KH LEFT OUTER JOIN
                                                                    EMPRESAS ON EFECTIVO_KH.EMPNIT = EMPRESAS.EMPNIT
                                                      WHERE         EFECTIVO_KH.FECHA BETWEEN @FI AND @FF", cnvpn)
                        cmdvpn.Parameters.AddWithValue("@FI", fechainicial)
                        cmdvpn.Parameters.AddWithValue("@FF", fechafinal)

                        Dim drvpn As SqlDataReader = cmdvpn.ExecuteReader
                        Do While drvpn.Read()
                            tbl.Rows.Add(New Object() {
                                             drvpn(0).ToString, 'SUCURSAL
                                             Integer.Parse(drvpn(1).ToString), 'FECHA
                                             Integer.Parse(drvpn(2).ToString), 'CODDOC
                                             Integer.Parse(drvpn(3).ToString), 'CORRELATIVO
                                             drvpn(4).ToString,
                                             drvpn(5).ToString, 'PRODUCTO
                                             Integer.Parse(drvpn(6).ToString), 'FECHA
                                             Double.Parse(drvpn(7).ToString), 'CODDOC
                                             Double.Parse(drvpn(8).ToString), 'CORRELATIVO
                                             Double.Parse(drvpn(9).ToString),
                                             Double.Parse(drvpn(10).ToString) 'PRODUCTO
                                                                                                })
                        Loop

                    End Using
                Catch ex As Exception
                    'GlobalDesError = ex.ToString
                    MsgBox("Error en la sucursal: " + dr(1).ToString + " - FUERA DE LINEA")
                End Try
            Loop

        Catch ex As Exception

            tbl = Nothing
        End Try

        If conteo = 0 Then tbl = Nothing

        Return tbl

    End Function

End Class
