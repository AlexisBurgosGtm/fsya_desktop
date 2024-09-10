
Imports System.Data.SqlClient

Public Class classClientes
    Sub New(ByVal _empnit As String)

        empnit = _empnit
    End Sub


    Dim empnit As String









    Public Function getDireccionCliente(ByVal codclie As Integer) As String
        Dim resp As String = "CIUDAD"

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT DIRCLIENTE FROM CLIENTES WHERE EMPNIT=@E AND CODCLIENTE=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codclie)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    resp = dr(0).ToString
                End If

            Catch ex As Exception

            End Try
        End Using

        Return resp

    End Function


    Public Function tblTipoNegocio() As DataTable
        Dim tbl As New DataTable

        With tbl.Columns
            .Add("COD", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {"TIENDITA"})
            .Add(New Object() {"ABARROTERIA"})
            .Add(New Object() {"FARMACIA"})
            .Add(New Object() {"LIBRERIA"})
            .Add(New Object() {"PIÑATERIA"})
            .Add(New Object() {"MUNDO DE 3"})
            .Add(New Object() {"RESTAURANTE"})
            .Add(New Object() {"COMEDOR"})
            .Add(New Object() {"PAPEROS"})
            .Add(New Object() {"HOTEL"})
            .Add(New Object() {"AUTOHOTEL"})
            .Add(New Object() {"CARNICERIA"})
            .Add(New Object() {"MERCERIA"})
            .Add(New Object() {"BAR"})
            .Add(New Object() {"BARBERIA"})
            .Add(New Object() {"SALON DE BELLEZA"})
            .Add(New Object() {"COLEGIO"})
            .Add(New Object() {"MINISUPER"})
            .Add(New Object() {"SUPERMERCADO"})
            .Add(New Object() {"OTROS"})
        End With

        Return tbl
    End Function


    Public Function tblDiaSemana() As DataTable
        Dim tbl As New DataTable

        With tbl.Columns
            .Add("COD", GetType(Integer))
            .Add("DES", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {1, "LUNES"})
            .Add(New Object() {2, "MARTES"})
            .Add(New Object() {3, "MIERCOLES"})
            .Add(New Object() {4, "JUEVES"})
            .Add(New Object() {5, "VIERNES"})
            .Add(New Object() {6, "SABADO"})
            .Add(New Object() {7, "DOMINGO"})
            .Add(New Object() {0, "OTROS"})
        End With

        Return tbl
    End Function

    Public Function verifyCodClie(ByVal codigo As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODCLIE FROM CLIENTES WHERE EMPNIT= @E AND CODCLIE=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codigo)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim i As Integer = 0
                Do While dr.Read
                    i = i + 1
                Loop

                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function verifyCodRuta(ByVal codruta As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODRUTA FROM RUTAS WHERE EMPNIT= @E AND CODRUTA=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codruta)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                Dim i As Integer = 0
                Do While dr.Read
                    i = i + 1
                Loop

                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function deleteRutaCliente(ByVal codigo As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM RUTAS WHERE EMPNIT=@E AND CODRUTA=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codigo)

                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

                r = True


            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function editRutaCliente(ByVal codigo As Integer, ByVal descripcion As String, ByVal codemp As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE RUTAS SET DESRUTA=@DESCRIPCION, CODEMPLEADO=@CODEMP WHERE EMPNIT=@E AND CODRUTA=@C", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@C", codigo)
                cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion)
                cmd.Parameters.AddWithValue("@CODEMP", codemp)

                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

                r = True


            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function


    Public Function insertRutaCliente(ByVal codigo As Integer, ByVal descripcion As String, ByVal codemp As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO RUTAS (EMPNIT,CODRUTA,DESRUTA,CODEMPLEADO) VALUES (@E,@CODIGO,@DESCRIPCION,@CODEMP)", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@CODIGO", codigo)
                cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion)
                cmd.Parameters.AddWithValue("@CODEMP", codemp)

                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

                r = True


            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function getTblRutas() As DataTable
        Dim tbl As New DSGeneral.tblRutasClientesDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT RUTAS.CODRUTA, RUTAS.DESRUTA, RUTAS.CODEMPLEADO, ISNULL(EMPLEADOS.NOMEMPLEADO, 'SN') AS NOMEMPLEADO
                        FROM RUTAS LEFT OUTER JOIN
                         EMPLEADOS ON RUTAS.CODEMPLEADO = EMPLEADOS.CODEMPLEADO AND RUTAS.EMPNIT = EMPLEADOS.EMPNIT
                        WHERE (RUTAS.EMPNIT = @E)", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                Dim da As New SqlDataAdapter
                With da
                    .SelectCommand = cmd
                    .Fill(tbl)
                End With


            Catch ex As Exception
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try
        End Using


        Return tbl

    End Function

    Public Function tbl_clientesall() As DataTable

        Dim tbl As New DSGeneral.tblClientesListaDataTable

        Call AbrirConexionSql()
        Try
            Dim cmd As New SqlCommand("SELECT CLIENTES.CODCLIENTE, CLIENTES.NIT, CLIENTES.NOMBRECLIENTE, 
                       CLIENTES.DIRCLIENTE, MUNICIPIOS.DESMUNICIPIO, DEPARTAMENTOS.DESDEPARTAMENTO, 
                        CLIENTES.CODCLIE,CLIENTES.CATEGORIA, CLIENTES.DIAVISITA, CLIENTES.HABILITADO, ISNULL(CLIENTES.NEGOCIO,'SN') AS NEGOCIO
                                        FROM CLIENTES LEFT OUTER JOIN DEPARTAMENTOS ON CLIENTES.CODDEPARTAMENTO = DEPARTAMENTOS.CODDEPARTAMENTO LEFT OUTER JOIN
                                        MUNICIPIOS ON CLIENTES.CODMUNICIPIO = MUNICIPIOS.CODMUNICIPIO
                                        WHERE (CLIENTES.HABILITADO = 'SI') AND (CLIENTES.EMPNIT = @EMPNIT)", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
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
                        dr(9),
                        dr(10)
                })
            Loop
            dr.Close()
            cmd.Dispose()


        Catch ex As Exception
            GlobalDesError = ex.ToString
            tbl = Nothing
        End Try

        cn.Close()

        Return tbl

    End Function


    Public Function GetTblMunicipios() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODMUNICIPIO", GetType(Integer))
            .Add("DESMUNICIPIO", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODMUNICIPIO, DESMUNICIPIO FROM MUNICIPIOS", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cn.Close()

            Catch ex As Exception

                GlobalDesError = ex.ToString
                tbl = Nothing

            End Try

        End Using

        Return tbl

    End Function


    Public Function GetTblDepartamentos() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODDEPARTAMENTO", GetType(Integer))
            .Add("DESDEPARTAMENTO", GetType(String))
        End With

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODDEPARTAMENTO, DESDEPARTAMENTO FROM DEPARTAMENTOS", cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

                cn.Close()

            Catch ex As Exception

                GlobalDesError = ex.ToString
                tbl = Nothing

            End Try

        End Using

        Return tbl

    End Function

    Public Function insert_mundepto(ByVal codigo As Integer, ByVal descripcion As String, ByVal mundep As String) As Boolean

        Dim r As Boolean

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String = ""

                If mundep = "M" Then
                    sql = "INSERT INTO MUNICIPIOS (CODMUNICIPIO, DESMUNICIPIO) VALUES (@C, @D)"
                Else
                    sql = "INSERT INTO DEPARTAMENTOS (CODDEPARTAMENTO, DESDEPARTAMENTO) VALUES (@C, @D)"
                End If


                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@C", codigo)
                cmd.Parameters.AddWithValue("@D", descripcion)
                Dim i As Integer = cmd.ExecuteNonQuery()
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



    Public Function delete_mundepto(ByVal codigo As Integer, ByVal mundep As String) As Boolean

        Dim r As Boolean

        Try
            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim sql As String = ""

                If mundep = "M" Then
                    sql = "DELETE FROM MUNICIPIOS WHERE CODMUNICIPIO=@C"
                Else
                    sql = "DELETE FROM DEPARTAMENTOS WHERE CODDEPARTAMENTO=@C"
                End If


                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@C", codigo)
                Dim i As Integer = cmd.ExecuteNonQuery()
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

End Class
