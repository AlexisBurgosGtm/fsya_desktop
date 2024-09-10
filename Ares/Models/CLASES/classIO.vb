Imports SocketIOClient
Imports WebSocket4Net

Public Class classIO


    Dim iphost As String, token As String, usuario As String
    Public DesError As String


    Sub New(ByVal _ipHost As String, ByVal _token As String, Optional _usuario As String = "")
        iphost = _ipHost
        token = _token
        usuario = _usuario
        Call Main()
    End Sub


    Public Sub Main()
        Dim io As New Client(iphost)
        io.On("orden nueva", Sub() MsgBox("nueva"))
    End Sub

    Public Function SendMsn(ByVal msn As String) As Boolean

        Dim io As New Client(iphost)

        Dim result As Boolean

        Try
            io.Connect()
            io.Emit("orden nueva", msn)

            result = True
        Catch ex As Exception
            DesError = ex.ToString
            result = False
        End Try

        Return result

    End Function




End Class
