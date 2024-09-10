Imports Twilio
Imports Twilio.Rest.Api.V2010.Account
Imports Twilio.Types
Imports System.Data.SqlClient

Public Class ClassTwilio
    Sub New()

    End Sub


    Public Function fcn_CargarTwilioCredentials() As Boolean
        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim cmdtwilio As New SqlCommand("SELECT ID,TOKEN,NUMBER FROM TWILIO", cn)
                Dim drtwilio As SqlDataReader = cmdtwilio.ExecuteReader
                drtwilio.Read()
                If drtwilio.HasRows Then
                    twilioSId = drtwilio(0).ToString
                    twilioToken = drtwilio(1).ToString
                    twilioNumber = drtwilio(2).ToString
                End If
                drtwilio.Close()
                cmdtwilio.Dispose()

                result = True

            Catch ex As Exception
                result = False
            End Try

        End Using

        Return result

    End Function


    Public Function fcn_enviarWhatsapp(ByVal msn As String, ByVal telefono As String) As Boolean
        Dim result As Boolean

        If fcn_CargarTwilioCredentials() = True Then

            Try

                TwilioClient.Init(twilioSId, twilioToken)
                Dim message = MessageResource.Create(
                    body:=msn,
                    from:=New Twilio.Types.PhoneNumber("whatsapp:" & twilioNumber),
                    [to]:=New Twilio.Types.PhoneNumber("whatsapp:" & telefono))

                Console.WriteLine(message.Sid)

                result = True

            Catch ex As Exception
                result = False
                'Form1.Mensaje("Twilio Error: " & ex.ToString)
            End Try

        Else
            result = False
        End If

        Return result

    End Function


End Class
