Imports System.Data.SqlClient

Public Class ClassTipoDocumentos
    Sub New(ByVal _empnit As String)

        empnit = _empnit
    End Sub

    Dim empnit As String

    Public Function tblMeses() As DataTable
        Dim tbl As New DataTable

        With tbl.Columns
            .Add("CODMES", GetType(Integer))
            .Add("DESMES", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {1, "ENERO"})
            .Add(New Object() {2, "FEBRERO"})
            .Add(New Object() {3, "MARZO"})
            .Add(New Object() {4, "ABRIL"})
            .Add(New Object() {5, "MAYO"})
            .Add(New Object() {6, "JUNIO"})
            .Add(New Object() {7, "JULIO"})
            .Add(New Object() {8, "AGOSTO"})
            .Add(New Object() {9, "SEPTIEMBRE"})
            .Add(New Object() {10, "OCTUBRE"})
            .Add(New Object() {11, "NOVIEMBRE"})
            .Add(New Object() {12, "DICIEMBRE"})
        End With

        Return tbl

    End Function

    Public Function tblAnios() As DataTable
        Dim tbl As New DataTable

        With tbl.Columns
            .Add("CODANIO", GetType(Integer))
        End With

        With tbl.Rows
            .Add(New Object() {2018})
            .Add(New Object() {2019})
            .Add(New Object() {2020})
            .Add(New Object() {2021})
            .Add(New Object() {2022})
            .Add(New Object() {2023})
            .Add(New Object() {2024})
            .Add(New Object() {2025})
            .Add(New Object() {2026})
            .Add(New Object() {2027})
            .Add(New Object() {2028})
            .Add(New Object() {2029})
            .Add(New Object() {2030})
            .Add(New Object() {2031})
            .Add(New Object() {2032})
            .Add(New Object() {2033})
            .Add(New Object() {2034})
            .Add(New Object() {2035})
            .Add(New Object() {2036})
            .Add(New Object() {2037})
            .Add(New Object() {2038})
            .Add(New Object() {2039})
            .Add(New Object() {2040})
        End With

        Return tbl

    End Function


    Public Function enabledDisableCoddoc(ByVal coddoc As String, ByVal act As String) As Boolean

        Dim r As Boolean
        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE TIPODOCUMENTOS SET ACTIVO=@ST WHERE EMPNIT=@E AND CODDOC=@D", cn)
                cmd.Parameters.AddWithValue("@E", empnit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@ST", act)
                Dim i As Integer = cmd.ExecuteNonQuery
                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                r = False
            End Try


        End Using


        Return r
    End Function
    Public Function UpdateCorrelativoDoc(ByVal coddoc As String, ByVal correlativoactual As Double) As Double
        Dim result As Double

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE TIPODOCUMENTOS SET CORRELATIVO=@CORRELATIVO WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativoactual + 1)
                cmd.ExecuteNonQuery()

                result = correlativoactual + 1

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = 0
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    Public Function getTipoDocumento(ByVal coddoc As String) As String

        Dim str As String = ""

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT TIPODOC FROM TIPODOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@D", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    str = dr(0).ToString
                Else
                    str = "SN"
                End If

            Catch ex As Exception
                str = "SN"
            End Try
        End Using

        Return str

    End Function

    Public Function getDocumentoStatus(ByVal coddoc As String, ByVal correlativo As Double) As String
        Dim r As String = "O"

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("SELECT STATUS FROM DOCUMENTOS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    r = dr(0).ToString
                Else
                    r = "O"
                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = "O"
            End Try

        End Using

        Return r

    End Function

    Public Function UpdateDocumentoStatus(ByVal coddoc As String, ByVal correlativo As Double, ByVal status As String) As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET STATUS=@ST WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmd.Parameters.AddWithValue("@ST", status)
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try


        End Using

        Return result

    End Function

    Public Function GetCorrelativoDoc(ByVal coddoc As String) As Double
        Dim result As Double

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmd As New SqlCommand("select correlativo from tipodocumentos where empnit=@EMPNIT AND coddoc=@CODDOC", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    result = Double.Parse(dr(0))
                Else
                    result = 0
                End If
            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = 0
            End Try

            cn.Close()
        End Using

        Return result

    End Function

    ''' <summary>
    ''' Actualiza un registro existente
    ''' </summary>
    ''' <param name="id"></param>
    ''' <param name="coddoc"></param>
    ''' <param name="correlativo"></param>
    ''' <param name="desdoc"></param>
    ''' <param name="resolucion"></param>
    ''' <param name="autorizacion"></param>
    ''' <param name="frase1"></param>
    ''' <param name="frase2"></param>
    ''' <returns>boolean</returns>
    Public Function fcn_UpdateTipoDocumento(ByVal id As Integer, ByVal coddoc As String, ByVal correlativo As Double, ByVal desdoc As String, ByVal resolucion As String, ByVal autorizacion As String, ByVal frase1 As String, ByVal frase2 As String, ByVal formato As String) As Boolean
        Dim updated As Boolean

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("UPDATE TIPODOCUMENTOS SET CORRELATIVO=@correlativo,DESDOC=@desdoc,RESOLUCION=@resolucion,AUTORIZACION=@autorizacion,FRASE1=@frase1,FRASE2=@frase2,FORMATO=@formato WHERE EMPNIT=@empnit AND CODDOC=@coddoc AND ID=@id", cn)
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@coddoc", coddoc)
            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@correlativo", correlativo)
            cmd.Parameters.AddWithValue("@desdoc", desdoc)
            cmd.Parameters.AddWithValue("@resolucion", resolucion)
            cmd.Parameters.AddWithValue("@autorizacion", autorizacion)
            cmd.Parameters.AddWithValue("@frase1", frase1)
            cmd.Parameters.AddWithValue("@frase2", frase2)
            cmd.Parameters.AddWithValue("@formato", formato)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            updated = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            updated = False
        End Try

        cn.Close()

        Return updated

    End Function


    ''' <summary>
    ''' Guarda un nuevo registro en la tabla TipoDocumentos
    ''' </summary>
    ''' <param name="tipodoc"></param>
    ''' <param name="coddoc"></param>
    ''' <param name="desdoc"></param>
    ''' <param name="resolucion"></param>
    ''' <param name="autorizacion"></param>
    ''' <param name="frase1"></param>
    ''' <param name="frase2"></param>
    ''' <returns>boolean</returns>
    Public Function fcn_SaveTipoDocumento(ByVal tipodoc As String, ByVal coddoc As String, ByVal desdoc As String, ByVal resolucion As String, ByVal autorizacion As String, ByVal frase1 As String, ByVal frase2 As String, ByVal formato As String) As Boolean
        Dim updated As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim c As New SqlCommand("SELECT CODDOC FROM TIPODOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@COD", cn)
                c.Parameters.AddWithValue("@E", GlobalEmpNit)
                c.Parameters.AddWithValue("@COD", coddoc)
                Dim dr As SqlDataReader = c.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    updated = False
                    MsgBox("YA EXISTE UN DOCUMENTO CON ESTA SERIE, POR FAVOR, ESCRIBE OTRO")
                    GoTo FINALIZA
                Else
                    GoTo PROCEDE
                End If
            Catch ex As Exception

            End Try
        End Using


PROCEDE:

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("INSERT INTO TIPODOCUMENTOS (EMPNIT,TIPODOC,CODDOC,CORRELATIVO,DESDOC,RESOLUCION,AUTORIZACION,FRASE1,FRASE2,FORMATO,ACTIVO) VALUES (@empnit,@tipodoc,@coddoc,1,@desdoc,@resolucion,@autorizacion,@frase1,@frase2,@formato,'SI')", cn)
            cmd.Parameters.AddWithValue("@empnit", empnit)
            cmd.Parameters.AddWithValue("@coddoc", coddoc)
            cmd.Parameters.AddWithValue("@tipodoc", tipodoc)
            cmd.Parameters.AddWithValue("@desdoc", desdoc)
            cmd.Parameters.AddWithValue("@resolucion", resolucion)
            cmd.Parameters.AddWithValue("@autorizacion", autorizacion)
            cmd.Parameters.AddWithValue("@frase1", frase1)
            cmd.Parameters.AddWithValue("@frase2", frase2)
            cmd.Parameters.AddWithValue("@formato", formato)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            updated = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            updated = False
        End Try

        cn.Close()

FINALIZA:


        Return updated

    End Function


    ''' <summary>
    ''' Elimina un documento de la tabla Tipo Documentos
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    Public Function fcn_DeleteTipoDocumento(ByVal ID As Integer, ByVal coddoc As String) As Boolean
        Dim updated As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Dim cmdv As New SqlCommand("SELECT TOP 1 CODDOC FROM DOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@D", cn)
            cmdv.Parameters.AddWithValue("@E", GlobalEmpNit)
            cmdv.Parameters.AddWithValue("@D", coddoc)
            Dim dr As SqlDataReader = cmdv.ExecuteReader
            Dim i As Integer = 0
            Do While dr.Read
                i = i + 1
            Loop

            If i = 0 Then
                Try
                    Dim cmd As New SqlCommand("DELETE FROM TIPODOCUMENTOS WHERE ID=@ID", cn)
                    cmd.Parameters.AddWithValue("@ID", ID)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    updated = True

                Catch ex As Exception
                    GlobalDesError = ex.ToString
                    updated = False
                End Try
            Else
                updated = False
            End If

        End Using

        Return updated

    End Function


    Public Function tblTipoDocumentos() As DataTable
        Call AbrirConexionSql()

        Dim tbl As New DSGeneral.tblTipoDocumentosDataTable

        Try
            Dim cmd As New SqlCommand("SELECT ID, CODDOC, CORRELATIVO, DESDOC, TIPODOC, RESOLUCION, AUTORIZACION, FRASE1,FRASE2,FORMATO, ISNULL(ACTIVO,'SI') AS ACTIVO FROM TIPODOCUMENTOS WHERE EMPNIT=@empnit", cn)
            cmd.Parameters.AddWithValue("@empnit", empnit)
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

            cn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)

            Try
                cn.Close()
            Catch exs As Exception

            End Try

            tbl = Nothing

        End Try

        Return tbl

    End Function



    Public Function tblTipos() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("TIPO", GetType(String))
            .Add("DESCRIPCION", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {"FAC", "FACTURAS-VENTAS"})
            .Add(New Object() {"DEV", "DEVOLUCIONES DE VENTAS"})
            .Add(New Object() {"ENV", "PEDIDOS/ENVIOS"})
            .Add(New Object() {"COM", "COMPRAS"})
            .Add(New Object() {"OCM", "ORDEN DE COMPRA"})
            .Add(New Object() {"COT", "COTIZACIONES"})
            .Add(New Object() {"COR", "CORTES DE CAJA"})
            .Add(New Object() {"GAS", "GASTOS"})
            .Add(New Object() {"ENT", "ENTRADAS DE INVENTARIO"})
            .Add(New Object() {"SAL", "SALIDAS DE INVENTARIO"})
            .Add(New Object() {"TIN", "TRASLADOS DE ENTRADA BODEDA"})
            .Add(New Object() {"TSL", "TRASLADOS DE SALIDA BODEGA"})
            .Add(New Object() {"TES", "TRASLADOS DE ENTRADA SUCURSAL"})
            .Add(New Object() {"TSS", "TRASLADOS DE SALIDA SUCURSAL"})
            .Add(New Object() {"ORT", "ORDENES DE TRABAJO"})
            .Add(New Object() {"RCC", "PAGOS DE CLIENTES"})
            .Add(New Object() {"RCP", "PAGOS A PROVEEDORES"})
            .Add(New Object() {"ORT", "ORDEN DE TRABAJO"})
            .Add(New Object() {"INF", "INVENTARIO FISICO"})
            .Add(New Object() {"ORP", "ORDEN DE PRODUCCIÓN"})
            .Add(New Object() {"FEF", "(FEL) FACTURA NORMAL ELECTRÓNICA IVA(12)"})
            .Add(New Object() {"FEC", "(FEL) FACTURA CAMBIARIA ELECTRÓNICA IVA(12)"})
            .Add(New Object() {"FES", "(FEL) FACTURA ESPECIAL ELECTRÓNICA IVA(12)"})
            .Add(New Object() {"FNC", "(FEL) NOTA DE CREDITO ELECTRÓNICA"})
            .Add(New Object() {"IEF", "INGRESO DE EFECTIVO"})
        End With

        Return tbl

    End Function

    Public Function tblTipos2() As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("TIPO", GetType(String))
            .Add("DESCRIPCION", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {"FEF", "(FEL) FACTURA NORMAL ELECTRÓNICA IVA(12)"})
            .Add(New Object() {"FNC", "(FEL) NOTA DE CREDITO ELECTRÓNICA"})
            .Add(New Object() {"FAC", "FACTURAS-VENTAS"})
            .Add(New Object() {"DEV", "DEVOLUCIONES DE VENTAS"})
            .Add(New Object() {"COR", "CORTES DE CAJA"})
            .Add(New Object() {"GAS", "GASTOS"})
            .Add(New Object() {"TIN", "TRASLADOS DE ENTRADA BODEDA"})
            .Add(New Object() {"TES", "TRASLADOS DE ENTRADA SUCURSAL"})
            .Add(New Object() {"TSS", "TRASLADOS DE SALIDA SUCURSAL"})
        End With

        Return tbl

    End Function


    ''' <summary>
    ''' Carga coddoc y desdoc de los documentos tipo factura
    ''' </summary>
    ''' <returns></returns>
    Public Function tblCoddoc(ByVal tipodoc As String) As DataTable

        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODDOC", GetType(String))
            .Add("DESDOC", GetType(String))
        End With

        Dim qry As String = ""

        Select Case tipodoc
            Case "DEV"
                qry = "SELECT CODDOC, DESDOC FROM TIPODOCUMENTOS WHERE EMPNIT=@EMPNIT AND TIPODOC IN('DEV', 'FNC') AND (ACTIVO='SI') "
            Case "SOLOFAC"
                qry = "SELECT CODDOC, DESDOC FROM TIPODOCUMENTOS WHERE EMPNIT=@EMPNIT AND TIPODOC='FAC' AND (ACTIVO='SI')"
            Case "FAC"
                qry = "SELECT CODDOC, DESDOC FROM TIPODOCUMENTOS WHERE EMPNIT=@EMPNIT AND TIPODOC IN ('FAC','FEF','FEC','FES') AND (ACTIVO='SI')"
            Case "FEL"
                qry = "SELECT CODDOC, DESDOC FROM TIPODOCUMENTOS WHERE EMPNIT=@EMPNIT AND TIPODOC IN ('FEF','FEC','FES')  AND (ACTIVO='SI')"
            Case Else
                qry = "SELECT CODDOC, DESDOC FROM TIPODOCUMENTOS WHERE EMPNIT=@EMPNIT AND TIPODOC='" & tipodoc & "' AND (ACTIVO='SI') "
        End Select


        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand(qry, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                        dr(0),
                        dr(1)
                    })
                Loop
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                MsgBox(ex.ToString)
                GlobalDesError = ex.ToString
                tbl = Nothing
            End Try

        End Using


        Return tbl

    End Function


    ''' <summary>
    ''' Retorna el nombre del formato de impresión del documento
    ''' </summary>
    ''' <param name="coddoc"></param>
    ''' <returns></returns>
    Public Function getFormatoDocumento(ByVal coddoc As String) As String
        Dim formato As String = "SN"

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim c As New SqlCommand("SELECT FORMATO FROM TIPODOCUMENTOS WHERE EMPNIT=@E AND CODDOC=@C", cn)
                c.Parameters.AddWithValue("@E", empnit)
                c.Parameters.AddWithValue("@C", coddoc)
                Dim d As SqlDataReader = c.ExecuteReader
                d.Read()
                If d.HasRows Then
                    formato = d(0).ToString
                End If
                d.Close()
                c.Dispose()

            Catch ex As Exception
                formato = "SN"
            End Try
        End Using

        Return formato

    End Function
End Class
