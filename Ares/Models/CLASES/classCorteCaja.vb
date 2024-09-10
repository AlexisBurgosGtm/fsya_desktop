Imports System.Data.SqlClient

Public Class classCorteCaja

    Sub New()

    End Sub

    Public Function comprobarCajaAbierta(ByVal codcaja As Integer) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT STATUS FROM CAJAS WHERE CODCAJA=@C AND EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codcaja)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    If Integer.Parse(dr(0)) = 0 Then
                        r = False
                    Else
                        r = True
                    End If
                End If
            Catch ex As Exception
                r = False
            End Try
        End Using

        Return r

    End Function

    Public Function abrirCaja(ByVal codcaja As Integer, ByVal inicial As Double, ByVal limite As Double) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE CAJAS SET STATUS=1, EFECTIVOINICIAL=@EI, EFECTIVOLIMITE=@EL, LASTUPDATE=@LU WHERE EMPNIT=@E AND CODCAJA=@C", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codcaja)
                cmd.Parameters.AddWithValue("@LU", Today.Date)
                cmd.Parameters.AddWithValue("@EI", inicial)
                cmd.Parameters.AddWithValue("@EL", limite)
                cmd.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try
        End Using

        Return r
    End Function

    ''' <summary>
    ''' tipo: 1 abiertas, 0 cerradas, 3 todas
    ''' </summary>
    ''' <param name="tipo"></param>
    ''' <returns></returns>
    Public Function getCajas(ByVal tipo As Integer) As DataTable

        Dim sql As String = ""
        Select Case tipo
            Case 1 'ABIERTAS
                sql = "SELECT CODCAJA, DESCAJA, EFECTIVOINICIAL,EFECTIVOLIMITE,STATUS,LASTUPDATE FROM CAJAS WHERE EMPNIT=@E AND STATUS=1 ORDER BY CODCAJA"
            Case 0 'CERRADAS
                sql = "SELECT CODCAJA, DESCAJA, EFECTIVOINICIAL,EFECTIVOLIMITE,STATUS,LASTUPDATE FROM CAJAS WHERE EMPNIT=@E AND STATUS=0 ORDER BY CODCAJA"
            Case 3 'TODAS
                sql = "SELECT CODCAJA, DESCAJA, EFECTIVOINICIAL,EFECTIVOLIMITE,STATUS,LASTUPDATE FROM CAJAS WHERE EMPNIT=@E  ORDER BY CODCAJA"
        End Select


        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                tbl = Nothing

                GlobalDesError = ex.ToString
            End Try

        End Using

        Return tbl

    End Function


    Public Function getTotalGastos(ByVal codcaja As Integer) As Double
        Dim r As Double = 0
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("SELECT DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO
                                FROM DOCUMENTOS LEFT OUTER JOIN
                                TIPODOCUMENTOS ON DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT AND DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC
                                WHERE (DOCUMENTOS.STATUS <> 'A') AND (DOCUMENTOS.CODCAJA = @CODCAJA) AND (DOCUMENTOS.CORTE = 'NO') AND (TIPODOCUMENTOS.TIPODOC = 'GAS') AND (DOCUMENTOS.EMPNIT = @EMPNIT)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODCAJA", codcaja)

                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    r = Double.Parse(dr(1))
                End If
            Catch ex As Exception
                r = 0
                GlobalDesError = ex.ToString
            End Try
        End Using

        Return r

    End Function

End Class
