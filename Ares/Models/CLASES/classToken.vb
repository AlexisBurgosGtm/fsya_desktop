
Imports System.Data.SqlClient
Imports Security

Public Class classToken


    Dim sc As New Security.Seguridad("razors1805")

    Public Property token As String = "SN"
    Public Property host As String = "SN"
    Public Property db As String = "SN"
    Public Property user As String = "SN"
    Public Property pass As String = "SN"
    Public Property intervalo As Integer = 999999

    Public Function getDataToken() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT TOKEN, HOST, DB, U, P, T FROM TOKEN", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    token = dr(0).ToString
                    host = sc.DecryptData(dr(1).ToString)
                    db = sc.DecryptData(dr(2).ToString)
                    user = sc.DecryptData(dr(3).ToString)
                    pass = sc.DecryptData(dr(4).ToString)
                    intervalo = Integer.Parse(dr(5))
                    r = True
                Else
                    token = "SN"
                    host = "SN"
                    db = "SN"
                    user = "SN"
                    pass = "SN"
                    intervalo = 0
                    r = False
                End If

            Catch ex As Exception
                token = "SN"
                host = "SN"
                db = "SN"
                user = "SN"
                pass = "SN"
                intervalo = 999999
                r = False
            End Try
        End Using

        Return r


    End Function


    Public Function update_dataToken(ByVal token As String, ByVal host As String, ByVal db As String, ByVal u As String, ByVal p As String, ByVal t As Integer) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE TOKEN SET TOKEN=@TOKEN, HOST=@HOST, DB=@DB, U=@U, P=@P, T=@T", cn)
                cmd.Parameters.AddWithValue("@TOKEN", token)
                cmd.Parameters.AddWithValue("@HOST", sc.EncryptData(host))
                cmd.Parameters.AddWithValue("@DB", sc.EncryptData(db))
                cmd.Parameters.AddWithValue("@U", sc.EncryptData(u))
                cmd.Parameters.AddWithValue("@P", sc.EncryptData(p))
                cmd.Parameters.AddWithValue("@T", t)
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




    Public Function create_dataToken() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmdcreate As New SqlCommand("CREATE TABLE [dbo].[TOKEN](
	                                        [TOKEN] [varchar](255) NULL,
	                                        [HOST] [varchar](255) NULL,
	                                        [DB] [varchar](255) NULL,
	                                        [U] [varchar](255) NULL,
	                                        [P] [varchar](255) NULL,
	                                        [T] [int] NULL
                                        ) ON [PRIMARY]", cn)
                Dim ic As Integer = cmdcreate.ExecuteNonQuery

                If ic > 0 Then
                    r = False
                Else
                    r = True
                End If


                Dim cmd As New SqlCommand("INSERT INTO TOKEN (TOKEN, HOST, DB, U, P, T) 
                                                                    VALUES 
                                                            ('SN','SN','SN','SN','SN',999999)", cn)

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





End Class
