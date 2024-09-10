Imports System.Data.SqlClient
Imports System.Net

Public Class ClassGeneral
    Sub New()

    End Sub


    ''' <summary>
    ''' OBTIENE EL DATATABLE DE LA QRY QUE SE LE ESPECIFIQUE, LA QRY DEBE LLEVAR LOS PARAMETROS EN EL STRING
    ''' </summary>
    ''' <param name="qry"></param>
    ''' <returns></returns>
    Public Function getTblQry(ByVal qry As String) As DataTable
        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(qry, cn)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                GlobalDesError = ex.ToString
            End Try
        End Using


        Return tbl

    End Function
    Public Function updateCortesEnviados() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE CORTES SET ENVIADO=1 WHERE EMPNIT=@E AND ENVIADO=0", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
            End Try
        End Using
        Return r
    End Function

    Public Function fcnEstablecerPrecioMayoreo(ByVal categoria As String, ByVal margen As Double) As Boolean
        Dim result As Boolean
        Dim cat As String
        Select Case categoria
            Case "A"
                cat = "MAYOREOA"
            Case "B"
                cat = "MAYOREOB"
            Case "C"
                cat = "MAYOREOC"
        End Select

        Dim contador As Integer = 0

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT EMPNIT,CODPROD,CODMEDIDA,COSTO,PRECIO FROM PRECIOS WHERE EMPNIT=@EMPNIT", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    Try
                        Dim qry As String = "UPDATE PRECIOS SET " & cat & "=@NUEVOPRECIO WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA"
                        Dim nuevoprecio As Double = (Double.Parse(dr(3)) * (margen / 100)) + Double.Parse(dr(3))
                        Dim cm As New SqlCommand(qry, cn)
                        cm.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cm.Parameters.AddWithValue("@NUEVOPRECIO", nuevoprecio)
                        cm.Parameters.AddWithValue("@CODPROD", dr(1).ToString)
                        cm.Parameters.AddWithValue("@CODMEDIDA", dr(2).ToString)
                        cm.ExecuteNonQuery()
                    Catch ex As Exception
                        contador = contador + 1
                    End Try
                Loop

                dr.Close()
                If contador > 0 Then
                    MsgBox("Se han encontrado " & contador.ToString & " errores")
                End If

                result = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
        End Using

        Return result
    End Function
    Public Function fcn_Request(ByVal mensaje As String, ByVal contacto As String) As Boolean




    End Function

    Public Function fcnObtenerCorrelativo(ByVal empnit As String, ByVal coddoc As String) As Double

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                Return Double.Parse(dr(0))
            End If
            dr.Close()
            cmd.Dispose()

        Catch ex As Exception
            GlobalDesError = ex.ToString
            Return 0

        End Try

        cn.Close()

    End Function

    Public Function fcnActualizarCorrelativo(ByVal empnit As String, ByVal coddoc As String, ByVal CorrelativoActual As Double) As Boolean

        Call AbrirConexionSql()

        Try

            Dim cmd As New SqlCommand("UPDATE TIPODOCUMENTOS SET CORRELATIVO=@CORRELATIVO WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", CorrelativoActual + 1)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            Return True

        Catch ex As Exception

            GlobalDesError = ex.ToString
            Return False

        End Try

        cn.Close()

    End Function

#Region " ** TILES / DASHBOARDS **"

    Public Function tblDashBoards(ByVal empnit As String, ByVal fecha As Date) As DataTable

        Dim tbl, tblErr As New DataTable
        With tbl.Columns
            .Add("VENTAS", GetType(String))
            .Add("COMPRAS", GetType(String))
            .Add("GASTOS", GetType(String))
        End With

        With tblErr.Columns
            .Add("VENTAS", GetType(String))
            .Add("COMPRAS", GetType(String))
            .Add("GASTOS", GetType(String))
        End With

        Call AbrirConexionSql()

        Try

            Dim cmd As New SqlCommand("sp_tiles_today", cn)
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@anio", fecha.Year)
            cmd.Parameters.AddWithValue("@mes", fecha.Month)
            cmd.Parameters.AddWithValue("@dia", fecha.Day)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                tbl.Rows.Add(New Object() {
                                FormatCurrency(dr(0)),
                                 FormatCurrency(dr(1)),
                                 FormatCurrency(dr(2))
                            })
            Loop
            dr.Close()
            cmd.Dispose()
            Return tbl

        Catch ex As Exception

            GlobalDesError = ex.ToString

            With tblErr.Rows
                .Add(New Object() {"Q 0.00"})
                .Add(New Object() {"Q 0.00"})
                .Add(New Object() {"Q 0.00"})
            End With

            Return tblErr

        End Try

        cn.Close()

    End Function


    Public Function TilesTodayFacturas(ByVal empnit As String, ByVal fecha As Date) As Integer

        Call AbrirConexionSql()

        Try
            Dim importe As Double
            Dim cmd As New SqlCommand("sp_tiles_today_facturas", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@anio", fecha.Year)
            cmd.Parameters.AddWithValue("@mes", fecha.Month)
            cmd.Parameters.AddWithValue("@dia", fecha.Day)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                importe = Integer.Parse(dr(0))
            End If
            dr.Close()
            cmd.Dispose()
            Return importe

        Catch ex As Exception

            GlobalDesError = ex.ToString
            ' MsgBox(ex.ToString)
            Return 0

        End Try

        cn.Close()

    End Function

    Public Function TilesTodayVentas(ByVal empnit As String, ByVal fecha As Date) As Double

        Call AbrirConexionSql()

        Try
            Dim importe As Double
            Dim cmd As New SqlCommand("sp_tiles_today_ventas", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@anio", fecha.Year)
            cmd.Parameters.AddWithValue("@mes", fecha.Month)
            cmd.Parameters.AddWithValue("@dia", fecha.Day)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                importe = Double.Parse(dr(0))
            End If
            dr.Close()
            cmd.Dispose()
            Return importe

        Catch ex As Exception

            GlobalDesError = ex.ToString
            'MsgBox(ex.ToString)
            Return 0

        End Try

        cn.Close()

    End Function


    Public Function TilesTodayCompras(ByVal empnit As String, ByVal fecha As Date) As Double

        Call AbrirConexionSql()

        Try
            Dim importe As Double
            Dim cmd As New SqlCommand("sp_tiles_today_compras", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@anio", fecha.Year)
            cmd.Parameters.AddWithValue("@mes", fecha.Month)
            cmd.Parameters.AddWithValue("@dia", fecha.Day)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                importe = Double.Parse(dr(0))
            End If
            dr.Close()
            cmd.Dispose()
            Return importe

        Catch ex As Exception

            GlobalDesError = ex.ToString
            ' MsgBox(ex.ToString)
            Return 0

        End Try

        cn.Close()

    End Function


    Public Function TilesTodayGastos(ByVal empnit As String, ByVal fecha As Date) As Double

        Call AbrirConexionSql()

        Try
            Dim importe As Double
            Dim cmd As New SqlCommand("sp_tiles_today_gastos", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@anio", fecha.Year)
            cmd.Parameters.AddWithValue("@mes", fecha.Month)
            cmd.Parameters.AddWithValue("@dia", fecha.Day)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                importe = Double.Parse(dr(0))
            End If
            dr.Close()
            cmd.Dispose()
            Return importe

        Catch ex As Exception

            GlobalDesError = ex.ToString
            ' MsgBox(ex.ToString)
            Return 0

        End Try

        cn.Close()

    End Function

    Public Function TilesCreditos(ByVal empnit As String) As Double

        Call AbrirConexionSql()

        Try
            Dim importe As Double
            Dim cmd As New SqlCommand("sp_sel_documentos_totalsaldo", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@empnit", empnit)

            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                importe = Double.Parse(dr(0))
            End If
            dr.Close()
            cmd.Dispose()
            Return importe

        Catch ex As Exception

            GlobalDesError = ex.ToString
            ' MsgBox(ex.ToString)
            Return 0

        End Try

        cn.Close()

    End Function

#End Region




End Class
