
Imports System.Data.SqlClient

Public Class classConection
    Sub New(ByVal _cn As SqlConnection)
        conection = _cn
    End Sub

    Dim conection As SqlConnection

    ''' <summary>
    ''' Ejecuta un comando sqlcommand con el comando executenonquery
    ''' </summary>
    ''' <param name="comando"></param>
    ''' <returns></returns>
    Public Function EjecutarComandoSql(ByVal comando As SqlCommand) As Boolean
        Dim result As Boolean

        Using conection As New SqlConnection(strSqlConectionString)
            If conection.State <> ConnectionState.Open Then
                conection.Open()
            End If

            Try
                comando.ExecuteNonQuery()
                result = True
            Catch ex As Exception
                GlobalDesError = "CLASE CONEXION: " & ex.ToString
                result = False
            End Try

        End Using

        Return result
    End Function



End Class
