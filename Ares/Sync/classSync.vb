Imports Newtonsoft.Json
Imports System.Data
Imports System.Data.SqlClient


Public Class classSync

    Sub New()

    End Sub




#Region " ** OTHERS ** "

    Public Function JsonClientes(ByVal empnit As String, ByVal ToJson As Boolean) As Boolean

        Dim result As Boolean

        Dim tbl As New DataTable
        tbl.TableName = "Clientes"

        Dim SQL As String
        SQL = "SELECT CLIENTES.CODCLIENTE, CLIENTES.NIT, CLIENTES.NOMBRECLIENTE, CLIENTES.DIRCLIENTE, MUNICIPIOS.DESMUNICIPIO, DEPARTAMENTOS.DESDEPARTAMENTO, CLIENTES.TELEFONOCLIENTE, 
                         CLIENTES.LATITUDCLIENTE, CLIENTES.LONGITUDCLIENTE, CLIENTES.SALDO
                FROM     CLIENTES LEFT OUTER JOIN
                         DEPARTAMENTOS ON CLIENTES.CODDEPARTAMENTO = DEPARTAMENTOS.CODDEPARTAMENTO LEFT OUTER JOIN
                         MUNICIPIOS ON CLIENTES.CODMUNICIPIO = MUNICIPIOS.CODMUNICIPIO
                WHERE   (CLIENTES.HABILITADO = 'SI') AND (CLIENTES.EMPNIT = @EMPNIT)"

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim dataSet As DataSet = New DataSet("dataSet")
                dataSet.Tables.Add(tbl)

                Dim json As String = JsonConvert.SerializeObject(dataSet, Formatting.Indented)


                Try
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\SYNC\clientes.json")
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\clientes.js")
                Catch ex As Exception
                End Try

                Dim sw As System.IO.StreamWriter


                Const fic As String = "C:\xampp\htdocs\AresPOS-online\data\clientes.json"
                sw = New System.IO.StreamWriter(fic, True)
                sw.WriteLine(json)
                sw.Close()

                json = "const listaclientes =" & json
                Const fic2 As String = "C:\xampp\htdocs\AresPOS-online\data\clientes.js"
                sw = New System.IO.StreamWriter(fic2, True)
                sw.WriteLine(json)
                sw.Close()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False

            End Try

            Return result
        End Using


    End Function


    Public Function JSONProductos(ByVal anio As Integer, ByVal mes As Integer, ByVal empnit As String, ByVal ToJson As Boolean) As Boolean

        Dim result As Boolean

        Dim tbl As New DataTable
        tbl.TableName = "Articles"


        Dim SQL As String
        SQL = "SELECT INVSALDO.CODPROD, PRODUCTOS.DESPROD, PRODUCTOS.DESPROD2, PRODUCTOS.DESPROD3, PRODUCTOS.UXC, PRECIOS.CODMEDIDA, PRECIOS.EQUIVALE, CONCAT('Q', CAST(PRECIOS.COSTO AS MONEY)) AS COSTO, CONCAT('Q', CAST(PRECIOS.PRECIO AS MONEY)) AS PRECIO, 
                         INVSALDO.SALDO, PRODUCTOS.HABILITADO
                FROM            PRECIOS RIGHT OUTER JOIN
                         INVSALDO ON PRECIOS.EMPNIT = INVSALDO.EMPNIT AND PRECIOS.CODPROD = INVSALDO.CODPROD LEFT OUTER JOIN
                         PRODUCTOS ON INVSALDO.EMPNIT = PRODUCTOS.EMPNIT AND INVSALDO.CODPROD = PRODUCTOS.CODPROD
                WHERE  (INVSALDO.EMPNIT = @EMPNIT) AND (INVSALDO.ANIO = @ANIO) AND (INVSALDO.MES = @MES)"

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim dataSet As DataSet = New DataSet("dataSet")
                dataSet.Tables.Add(tbl)

                Dim json As String = JsonConvert.SerializeObject(dataSet, Formatting.Indented)


                'QUITA LOS ESPACIOS DEL TBL
                'json = Strings.Mid(json, 16)
                'json = Strings.Left(json, Strings.Len(json) - 3)


                Try
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\productos.json")
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\productos.js")
                Catch ex As Exception
                End Try

                Dim sw As System.IO.StreamWriter

                Const fic As String = "C:\xampp\htdocs\AresPOS-online\data\productos.json"
                sw = New System.IO.StreamWriter(fic, True)
                sw.WriteLine(json)
                sw.Close()

                json = "const listaproductos =" & json
                Const fic1 As String = "C:\xampp\htdocs\AresPOS-online\data\productos.js"
                sw = New System.IO.StreamWriter(fic1, True)

                sw.WriteLine(json)
                sw.Close()


                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False

            End Try

            Return result
        End Using


    End Function


    Public Function JSONVentasMes(ByVal anio As Integer, ByVal mes As Integer, ByVal empnit As String, ByVal ToJson As Boolean) As Boolean

        Dim result As Boolean

        Dim tbl As New DataTable
        tbl.TableName = "VentasMes"

        Dim SQL As String
        SQL = "SELECT DOCUMENTOS.DIA, CONCAT('Q', CAST(SUM(DOCUMENTOS.TOTALCOSTO) AS MONEY)) AS TOTALCOSTO, CONCAT('Q', CAST(SUM(DOCUMENTOS.TOTALPRECIO) AS MONEY)) AS TOTALPRECIO, DOCUMENTOS.CONCRE
                    FROM            DOCUMENTOS LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                         VENDEDORES ON DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT AND DOCUMENTOS.CODVEN = VENDEDORES.CODVEN
                    WHERE        (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES)
                    GROUP BY DOCUMENTOS.DIA, DOCUMENTOS.CONCRE"

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim dataSet As DataSet = New DataSet("dataSet")
                dataSet.Tables.Add(tbl)

                Dim json As String = JsonConvert.SerializeObject(dataSet, Formatting.Indented)

                'QUITA LOS ESPACIOS DEL TBL
                'json = Strings.Mid(json, 16)
                'json = Strings.Left(json, Strings.Len(json) - 3)


                Try
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\ventames.json")
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\ventames.js")
                Catch ex As Exception
                End Try

                Dim sw As System.IO.StreamWriter

                Const fic As String = "C:\xampp\htdocs\AresPOS-online\data\ventames.json"
                sw = New System.IO.StreamWriter(fic, True)
                sw.WriteLine(json)
                sw.Close()

                json = "const listaventas =" & json
                Const fic1 As String = "C:\xampp\htdocs\AresPOS-online\data\ventames.js"
                sw = New System.IO.StreamWriter(fic1, True)
                sw.WriteLine(json)
                sw.Close()


                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False

            End Try

            Return result
        End Using


    End Function


    Public Function JSONVentasVendedor(ByVal anio As Integer, ByVal mes As Integer, ByVal empnit As String, ByVal ToJson As Boolean) As Boolean

        Dim result As Boolean

        Dim tbl As New DataTable

        Dim SQL As String
        SQL = "SELECT VENDEDORES.NOMVEN, DOCUMENTOS.DIA, CONCAT('Q', CAST(SUM(DOCUMENTOS.TOTALCOSTO) AS MONEY)) AS TOTALCOSTO, CONCAT('Q', CAST(SUM(DOCUMENTOS.TOTALPRECIO) AS MONEY)) AS TOTALPRECIO, DOCUMENTOS.CONCRE
                FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC LEFT OUTER JOIN
                VENDEDORES ON DOCUMENTOS.EMPNIT = VENDEDORES.EMPNIT AND DOCUMENTOS.CODVEN = VENDEDORES.CODVEN
                WHERE (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES)
                GROUP BY DOCUMENTOS.DIA, DOCUMENTOS.CONCRE, VENDEDORES.NOMVEN"

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@ANIO", anio)
                cmd.Parameters.AddWithValue("@MES", mes)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                Dim dataSet As DataSet = New DataSet("dataSet")
                dataSet.Tables.Add(tbl)

                Dim json As String = JsonConvert.SerializeObject(dataSet, Formatting.Indented)

                'QUITA LOS ESPACIOS DEL TBL
                json = Strings.Mid(json, 16)
                json = Strings.Left(json, Strings.Len(json) - 3)

                Dim sw As System.IO.StreamWriter


                Const fic As String = "C:\xampp\htdocs\AresPOS-online\data\ventavendedormes.json"
                sw = New System.IO.StreamWriter(fic, True)
                sw.WriteLine(json)
                sw.Close()

                json = "const listaventasvendedor =" & json
                Const fic1 As String = "C:\xampp\htdocs\AresPOS-online\data\ventavendedormes.js"
                sw = New System.IO.StreamWriter(fic1, True)
                sw.WriteLine(json)
                sw.Close()

                Try
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\ventavendedormes.json")
                    FileSystem.Kill("C:\xampp\htdocs\AresPOS-online\data\ventavendedormes.js")
                Catch ex As Exception
                End Try

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False

            End Try

            Return result
        End Using


    End Function

#End Region

End Class
