Imports System.Data.SqlClient

Public Class ClassDocumentos
    Sub New()

    End Sub


    Public Function verifyCorteDocumento(ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim r As Boolean

        Dim res As String = "NO"

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CORTE FROM DOCUMENTOS 
                                            WHERE EMPNIT=@E 
                                            AND CODDOC=@D 
                                            AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    res = dr(0).ToString
                Else
                    res = "NO"
                End If

            Catch ex As Exception
                res = "NO"
            End Try
        End Using

        If res = "SI" Then
            r = True
        Else
            r = False
        End If

        Return r
    End Function


    Public Function getTblCajas() As DataTable
        Dim tbl As New DataTable
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("SELECT CODCAJA AS CODIGO, DESCAJA AS DESCRIPCION FROM CAJAS WHERE EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function


    'CAMBIA EL CÓDIGO DE CAJA DE UN DOCUMENTO QUE NO TIENE CORTE DE CAJA
    Public Function setCodCaja(ByVal coddoc As String, ByVal correlativo As Double, ByVal codcajan As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET CODCAJA=@C WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N AND CORTE='NO'; ", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                cmd.Parameters.AddWithValue("@C", codcajan)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i >= 1 Then
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


    '*** CAMBIA EL NIT CODIGO NOMBRE Y DIRECCION DE CLIENTE EN EL DOCUMENTO
    Public Function setCodClienteDocumento(ByVal coddoc As String, ByVal correlativo As Double, ByVal codclie As Integer, ByVal nit As String, ByVal nomclie As String, ByVal dirclie As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET
                CODCLIENTE=@CODCLIE, DOC_NIT=@NITCLIE, DOC_NOMCLIE=@NOMCLIE, DOC_DIRCLIE=@DIRCLIE
                WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N ", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                cmd.Parameters.AddWithValue("@CODCLIE", codclie)
                cmd.Parameters.AddWithValue("@NITCLIE", nit)
                cmd.Parameters.AddWithValue("@NOMCLIE", nomclie)
                cmd.Parameters.AddWithValue("@DIRCLIE", dirclie)
                Dim i As Integer = cmd.ExecuteNonQuery()
                If i >= 1 Then
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



    ''' <summary>
    ''' AUMENTA EL INVENTARIO DE UN PRODUCTO EN ENTRADA DE INVENTARIO
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <param name="anio"></param>
    ''' <param name="mes"></param>
    ''' <returns></returns>
    Public Function cargarEntradaInventario(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal anio As Integer, ByVal mes As Integer) As Boolean
        Dim result As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT CODPROD, TOTALUNIDADES  FROM DOCPRODUCTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    'OBTIENE LAS VARIABLES (entradas, salidas, saldo) DEL INVENTARIO DEL PRODUCTO
                    Call fcn_CargarinvsaldoProducto(empnit, dr(0).ToString, anio, mes)

                    'ACTUALIZA EL INVENTARIO DEL PRODUCTO
                    Dim cmdupd As New SqlCommand("UPDATE INVSALDO SET SALDO=@SALDO, ENTRADAS=@E WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND ANIO=@ANIO AND MES=@MES", cn)
                    cmdupd.Parameters.AddWithValue("@EMPNIT", empnit)
                    cmdupd.Parameters.AddWithValue("@ANIO", anio)
                    cmdupd.Parameters.AddWithValue("@MES", mes)
                    cmdupd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                    cmdupd.Parameters.AddWithValue("@SALDO", Double.Parse(dr(1)) + Saldo)
                    cmdupd.Parameters.AddWithValue("@E", Entradas + Double.Parse(dr(1)))
                    cmdupd.ExecuteNonQuery()
                    cmdupd.Dispose()
                Loop
                dr.Close()
                cmd.Dispose()
                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
            'cn.Close()
        End Using

        Return result

    End Function


    ''' <summary>
    ''' SUMA EL INVENTARIO DE UN DOCUMENTO ESPECÍFICO
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <param name="anio"></param>
    ''' <param name="mes"></param>
    ''' <returns></returns>
    Public Function DevolverInvFac(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal anio As Integer, ByVal mes As Integer) As Boolean
        Dim result As Boolean
        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmd As New SqlCommand("SELECT CODPROD, TOTALUNIDADES  FROM DOCPRODUCTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    'OBTIENE LAS VARIABLES (entradas, salidas, saldo) DEL INVENTARIO DEL PRODUCTO
                    Call fcn_CargarinvsaldoProducto(empnit, dr(0).ToString, anio, mes)

                    Dim cmdupd As New SqlCommand("UPDATE INVSALDO SET SALDO=@SALDO, SALIDAS=@SALIDAS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND ANIO=@ANIO AND MES=@MES", cn)
                    cmdupd.Parameters.AddWithValue("@EMPNIT", empnit)
                    cmdupd.Parameters.AddWithValue("@ANIO", anio)
                    cmdupd.Parameters.AddWithValue("@MES", mes)
                    cmdupd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)
                    cmdupd.Parameters.AddWithValue("@SALDO", Double.Parse(dr(1)) + Saldo)
                    cmdupd.Parameters.AddWithValue("@SALIDAS", Salidas - Double.Parse(dr(1)))
                    cmdupd.ExecuteNonQuery()
                    cmdupd.Dispose()
                Loop
                dr.Close()
                cmd.Dispose()
                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
            'cn.Close()
        End Using

        Return result

    End Function


    ''' <summary>
    ''' RESTA EL INVENTARIO DE UN DOCUMENTO ESPECÍFICO
    ''' </summary>
    ''' <param name="empnit"></param>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <param name="anio"></param>
    ''' <param name="mes"></param>
    ''' <returns></returns>
    Public Function SacarInvFac(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double, ByVal anio As Integer, ByVal mes As Integer) As Boolean

        Call AbrirConexionSql()

        Try

            Dim cmd As New SqlCommand("SELECT CODPROD, TOTALUNIDADES FROM DOCPRODUCTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            cmd.Parameters.AddWithValue("@CODDOC", coddoc)
            cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                Dim cmdupd As New SqlCommand("UPDATE INVSALDO SET SALDO=@SALDO, SALIDAS=@SALIDAS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND ANIO=@ANIO AND MES=@MES", cn)
                cmdupd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdupd.Parameters.AddWithValue("@ANIO", anio)
                cmdupd.Parameters.AddWithValue("@MES", mes)
                cmdupd.Parameters.AddWithValue("@CODPROD", dr(0).ToString)

                Call fcn_CargarinvsaldoProducto(empnit, dr(0).ToString, anio, mes)

                cmdupd.Parameters.AddWithValue("@SALDO", Saldo - Double.Parse(dr(1)))
                cmdupd.Parameters.AddWithValue("@SALIDAS", Salidas + Double.Parse(dr(1)))
                cmdupd.ExecuteNonQuery()
                cmdupd.Dispose()
            Loop
            dr.Close()
            cmd.Dispose()
            Return True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            Return False
        End Try

        cn.Close()

    End Function

    Dim Entradas, Salidas, Saldo As Double
    Private Function fcn_CargarinvsaldoProducto(ByVal empnit As String, ByVal codprod As String, ByVal anio As Integer, ByVal mes As Integer) As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try

                Dim cmdSaldo As New SqlCommand("SELECT ENTRADAS, SALIDAS, SALDO FROM INVSALDO WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND ANIO=@ANIO AND MES=@MES", cn)
                cmdSaldo.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdSaldo.Parameters.AddWithValue("@CODPROD", codprod)
                cmdSaldo.Parameters.AddWithValue("@ANIO", anio)
                cmdSaldo.Parameters.AddWithValue("@MES", mes)
                Dim dr As SqlDataReader = cmdSaldo.ExecuteReader
                Do While dr.Read
                    'tblExistencias.Rows.Add(New Object() {Integer.Parse(dr(0)), Integer.Parse(dr(1)), Integer.Parse(dr(2))})
                    Entradas = CType(dr(0), Double)
                    Salidas = CType(dr(1), Double)
                    Saldo = CType(dr(2), Double)
                Loop

                dr.Close()
                cmdSaldo.Dispose()

                Return True
            Catch ex As Exception
                MsgBox("no cargo invsaldo - " & ex.ToString)
                GlobalDesError = ex.ToString
                Return False
            End Try
        End Using
    End Function


    Private Function fcn_invsaldoProducto(ByVal empnit As String, ByVal codprod As String, ByVal anio As Integer, ByVal mes As Integer) As DataRow
        Try
            Dim tblExistencias As New DataTable


            With tblExistencias.Columns
                .Add("Entradas", GetType(Double))
                .Add("Salidas", GetType(Double))
                .Add("Saldo", GetType(Double))
            End With

            Dim drw As DataRow

            Dim cmdSaldo As New SqlCommand("SELECT ENTRADAS, SALIDAS, SALDO FROM INVSALDO WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND ANIO=@ANIO AND MES=@MES", cn)
            cmdSaldo.Parameters.AddWithValue("@EMPNIT", empnit)
            cmdSaldo.Parameters.AddWithValue("@CODPROD", codprod)
            cmdSaldo.Parameters.AddWithValue("@ANIO", anio)
            cmdSaldo.Parameters.AddWithValue("@MES", mes)
            Dim dr As SqlDataReader = cmdSaldo.ExecuteReader
            Do While dr.Read
                MsgBox(dr(0).ToString & " - " & dr(1).ToString & " - " & dr(2).ToString)
                'tblExistencias.Rows.Add(New Object() {Integer.Parse(dr(0)), Integer.Parse(dr(1)), Integer.Parse(dr(2))})
                drw.Item(0) = dr(0).ToString
                drw.Item(1) = dr(1).ToString
                drw.Item(2) = dr(2).ToString
            Loop

            Return drw 'tblExistencias.Rows.Item(0)

            dr.Close()
            cmdSaldo.Dispose()
        Catch ex As Exception
            MsgBox("invsaldo fcn _ " & ex.ToString)
            GlobalDesError = ex.ToString
            Return Nothing
        End Try

    End Function


    Public Function updateCorrelativoDocumento(ByVal empnit As String, ByVal coddoc As String, ByVal correlativo As Double) As Boolean
        Dim result As Boolean

        Try

            Using cn As New SqlConnection(strSqlConectionString)
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim SQL As String

                SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=@CORRELATIVO WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC"

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo + 1)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                result = True
            End Using
        Catch ex As Exception
            result = False
        End Try

    End Function


End Class
