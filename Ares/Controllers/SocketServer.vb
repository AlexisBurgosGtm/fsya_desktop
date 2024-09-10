Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading
Imports System.Net

Namespace ChatTest.Server
    ''' <summary>
    ''' Clase para la gestión de Sockets en el servidor
    ''' </summary>
    Public Class SocketServer

#Region "Campos privados"

        ''' <summary>
        ''' Método a ejecutar cuando se reciben datos por un socket
        ''' </summary>
        Private callBackDatosRecibidos As Action(Of String, String) = Nothing

        ''' <summary>
        ''' Puerto del servidor
        ''' </summary>
        Private puerto As Integer = 8000

        ''' <summary>
        ''' Hilo de ejecución para TCPListener
        ''' </summary>
        Private tListener As Thread = Nothing

        ''' <summary>
        ''' Indica si el servidor está escuchando
        ''' </summary>
        Private escuchando As Boolean = False

        ''' <summary>
        ''' Diccionario que contiene la IP y el Socket de todos los clientes conectados
        ''' </summary>
        Private sockets As New Dictionary(Of String, Socket)()

        ''' <summary>
        ''' Objeto que se utiliza para bloquear el uso del diccionario, con el fin de
        ''' evitar errores de concurrencia
        ''' </summary>
        Private bloqueoSockets As New Object()

#End Region


#Region "Abrir"

        ''' <summary>
        ''' Inicia el servidor para que escuche en el puerto indicado
        ''' </summary>
        ''' <param name="puerto">Puerto a escuchar</param>
        ''' <param name="callBackDatosRecibidos">Método que se ejecutará al recibir datos
        ''' por alguno de los sockets</param>
        ''' <returns></returns>
        Public Function Abrir(puerto As Integer, callBackDatosRecibidos As Action(Of String, String)) As Boolean
            ' Si está escuchando, no se puede abrir
            If escuchando Then
                Return False
            End If

            ' Asigna los campos privados
            Me.puerto = puerto
            Me.callBackDatosRecibidos = callBackDatosRecibidos

            ' Inicia la escucha
            escuchando = True
            ' El TCPListerener se ejecutan en un nuevo hilo de ejecución
            tListener = New Thread(AddressOf Escuchar)
            tListener.Start()

            ' Se crea un nuevo hilo para escuchar los sockets abiertos
            Dim t As New Thread(AddressOf EscucharSockets)
            t.Start()

            Return True
        End Function

#End Region


#Region "Procesos de escucha"

        ''' <summary>
        ''' Escucha el puerto para detectar nuevas conexiones
        ''' </summary>
        Private Sub Escuchar()
            Try
                ' Se crea un TCPListener que escuchar cualquier IP local con el puerto indicado
                Dim listener As New TcpListener(IPAddress.Any, puerto)

                listener.Start()

                ' Mientras se esté escuchando...
                While escuchando
                    ' Esperar hasta que se producza una petición de conexión
                    If listener.Pending() Then
                        ' Iniciamos la conexión
                        listener.BeginAcceptSocket(New AsyncCallback(AddressOf DoAcceptSocketCallback), listener)
                    End If
                    ' Una pausa refrescante
                    Thread.Sleep(100)
                End While
                ' Si ya no se escucha, detenemos el TCPListener
                listener.[Stop]()
            Catch ex As Exception
                '  MessageBox.Show("Probablemente el puerto configurado está siendo usado por otra aplicación")
            End Try
        End Sub

        ''' <summary>
        ''' Acepta la conexión y extraemos el socket
        ''' </summary>
        ''' <param name="ar">Objeto AsyncResult</param>
        Private Sub DoAcceptSocketCallback(ar As IAsyncResult)
            ' Recuperamos el TCPListener
            Dim listener As TcpListener = DirectCast(ar.AsyncState, TcpListener)
            ' Extraemos el nuevo socket para la conexión
            Dim clientSocket As Socket = listener.EndAcceptSocket(ar)
            ' Extraemos la IP remota (cliente) del socket
            Dim IPRemota As String = clientSocket.RemoteEndPoint.ToString()

            ' Bloqueamos la escucha de todos sockets, para evitar errores de concurrencia
            SyncLock bloqueoSockets
                ' Añadimos la IP y el socket al cliente
                sockets.Add(IPRemota, clientSocket)
            End SyncLock
        End Sub

        ''' <summary>
        ''' Este método recorre todos los sockets abiertos procesando los datos recibidos
        ''' </summary>
        Private Sub EscucharSockets()
            ' Mientras se esté escuchando...
            While escuchando
                ' Interceptamos e ignoramos posibles errores de comunicación
                Try
                    ' Si el proceso está bloqueado, esperamos hasta que termine
                    SyncLock bloqueoSockets
                        ' Recorremos todos los sockets del diccionario de sockets
                        For Each socD In sockets
                            ' En soc almacenamos el Socket
                            Dim soc = socD.Value
                            ' En IPRemota la IP remota (cliente) del socket
                            Dim IPRemota = socD.Key
                            ' Si el socket está conectado
                            If soc.Connected Then
                                ' Si hay datos en el bufer
                                Dim len As Integer = soc.Available
                                If len > 0 Then
                                    ' Creamos un bufer local
                                    Dim bufer As Byte() = New Byte(len - 1) {}
                                    ' Recibimos los datos
                                    soc.Receive(bufer, len, SocketFlags.None)

                                    ' Convertimos el array de bytes a cadena de texto
                                    Dim datos As String = Encoding.UTF8.GetString(bufer)
                                    ' Invocamos el método de recepción de datos
                                    callBackDatosRecibidos(IPRemota, datos)
                                    ' Enviamos los datos a todos los sockets conectados
                                    '*****************************************************************************************************
                                    '*****************************************************************************************************

                                    '  EnviarATodos(datos)
                                    'EnviarATodos(String.Format("{0}: {1}", IPRemota, datos))
                                End If
                            Else
                                ' Si el socket no está conectado lo eliminamos del diccionario
                                sockets.Remove(IPRemota)
                                ' Desconectamos el socket, lo cerramos y liberamos los recursos
                                soc.Disconnect(False)
                                soc.Close()
                                soc.Dispose()
                                soc = Nothing
                            End If
                        Next
                    End SyncLock
                Catch
                End Try
            End While

            ' Si termina la escucha, eliminamos todos los sockets
            SyncLock bloqueoSockets
                Try
                    For Each socD In sockets
                        Dim soc = socD.Value
                        Dim IPRemota = socD.Key
                        sockets.Remove(IPRemota)
                        soc.Disconnect(False)
                        soc.Close()
                        soc.Dispose()
                        soc = Nothing
                    Next
                Catch err As Exception
                End Try
            End SyncLock
        End Sub

#End Region


#Region "Cerrar"

        ''' <summary>
        ''' Cierra el servidor
        ''' </summary>
        ''' <returns></returns>
        Public Function Cerrar() As Boolean
            ' Establecemos el campo de escucha a false, para que los métodos Escuchar y
            ' EscucharSockets finalicen
            escuchando = False
            ' Mientras queden sockets en el diccionario de sockets
            While sockets.Count > 0
                ' Esperar 100 ms
                Thread.Sleep(100)
            End While
            ' Se han cerrado todos los sockets
            Return True
        End Function

#End Region


#Region "Enviar datos"

        ''' <summary>
        ''' Envía los datos indicados a todos los sockets abiertos
        ''' </summary>
        ''' <param name="datos">Datos a enviar</param>
        ''' <returns>Devuelve true si correcto o false si error</returns>
        Public Function EnviarATodos(datos As String) As Boolean
            Try
                ' Convierte la cadena de datos en un array de bytes
                Dim bufer As Byte() = Encoding.UTF8.GetBytes(datos)
                ' Recorrer todos los sockets
                For Each soc In sockets.Values
                    ' Enviar array de bytes por el socket
                    soc.Send(bufer)
                Next
                ' Proceso completado
                Return True
            Catch
                Return False
            End Try
        End Function

#End Region
    End Class
End Namespace


