Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraBars.Docking2010.Views.WindowsUI
Imports Microsoft.Win32
'importaciones para el envio de correo
Imports System
Imports System.Collections
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports DevExpress.XtraEditors.Camera
Imports System.IO
Imports System.Xml
Imports Security
Imports System.Speech.Synthesis
Imports System.ComponentModel
Imports DevExpress.XtraSplashScreen
'**********************************

Module Funciones

    Public Function getTblEmpresasHost() As DataTable
        Dim tblEmpresashost As New DataTable
        With tblEmpresashost.Columns
            .Add("CONEXION", GetType(String))
            .Add("NOMBRE", GetType(String))
        End With

        With tblEmpresashost.Rows
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1434;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "BARCENAS I"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1454;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "BARCENAS II"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1451;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "BARCENAS III"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1435;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "CENMA"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1436;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "ZONA 7"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1437;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "ZONA 5"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1438;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "BUCARO 1"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1447;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "BUCARO 2"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1439;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "EL FRUTAL"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1440;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "VILLA HERMOSA"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1441;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "CASTAÑAS"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1442;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "CATALINA"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1448;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "CATALINA II"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1443;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "BDM"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1444;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "ZONA 6"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1445;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "ASINTAL"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1446;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "VILLA LOBOS"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1449;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "STA ISABEL"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1450;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "M VIEJO"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1452;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "PRADOS"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1453;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "LA PAZ"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1455;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "DIS GARMEN"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1458;Initial Catalog=VENCIDOS;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "VENCIDOS"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1457;Initial Catalog=CANJES;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "CANJES"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1459;Initial Catalog=COMPRAS;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "COMPRAS"})
            .Add(New Object() {"Data Source=vpn.fsyagt.com,1456;Initial Catalog=FSYA;User ID=iEx;Password=EE3xUjEvahPsU7cb;MultipleActiveResultSets=True", "BODEGA"})
        End With

        Return tblEmpresashost

    End Function

    Public Sub getLoader()
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)
    End Sub

    Public Sub closeLoader()
        SplashScreenManager.CloseForm()
    End Sub


    Public Function getTblMeses2() As DataTable
        Dim tblmeses As New DataTable
        With tblmeses.Columns
            .Add("CODMES", GetType(Integer))
            .Add("DESMES", GetType(String))
        End With

        With tblmeses.Rows
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

        Return tblmeses

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="str"></param>
    ''' <returns></returns>
    Public Function cleanString(ByVal str As String) As String

        Dim n As String = str

        'n = n.Replace("-", "")
        n = n.Replace("/", "")
        n = n.Replace("\", "")
        'n = n.Replace(".", "")
        'n = n.Replace(",", "")
        n = n.Replace("#", "")
        n = n.Replace("&", "")
        n = n.Replace("$", "")
        n = n.Replace("'", "")
        n = n.Replace(";", "")
        n = n.Replace(":", "")
        n = n.Replace("=", "")
        n = n.Replace("%", "")
        n = n.Replace("(", "")
        n = n.Replace(")", "")
        n = n.Replace("!", "")
        'n = n.Replace(" ", "")
        n = n.ToUpper

        Return n


    End Function

    Public Function ExisteNitCliente(ByVal NitClie As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("SELECT NIT, NOMBRECLIENTE FROM CLIENTES WHERE EMPNIT='" & GlobalEmpNit & "' AND NIT='" & NitClie & "'", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                Try
                    If dr.HasRows Then
                        r = True
                    End If
                Catch ex As Exception
                    r = False
                End Try
                dr.Close()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using

        Return r
    End Function


    Public Function getConfirmacion(ByVal msn As String) As Boolean
        Dim r As Boolean

        Dim x As Integer
        x = MsgBox(msn, MsgBoxStyle.OkCancel)
        If x = 1 Then
            r = True
        Else
            r = False
        End If

        Return r
    End Function


    Public NotifAsunto, NotifMsn As String

    Public Function fcn_sendNotification(ByVal Asunto As String, ByVal Mensaje As String) As Boolean
        Dim r As Boolean

        If Form1.BackgroundWorkerNotificacion.IsBusy = False Then
            NotifAsunto = Asunto
            NotifMsn = Mensaje
            Form1.BackgroundWorkerNotificacion.RunWorkerAsync()
        End If

        Return r
    End Function

    Public Function SetRegDataClient(ByVal keyname As String, valor As String) As Boolean
        Dim result As Boolean

        Try
            Dim KeyPath As String = "Software\POS\OnnePOS\Client"

            'Registry.CurrentUser.CreateSubKey(KeyPath)

            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(KeyPath, True) ' True indica que se abre para escritura
            key.SetValue(keyname, valor, RegistryValueKind.String)

            result = True

        Catch ex As Exception
            result = False
            GlobalDesError = ex.ToString
        End Try

        Return result

    End Function

    Public Function ReadRegDataClient(ByVal keyname As String) As String
        Dim dt As String
        dt = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Client", keyname, Nothing).ToString
        Return dt
    End Function


#Region " ** TOKEN ** "

    Public StrMyHostConnection As String

    Public GlobalTimerToken As Integer = 600000



    Public Function getToken() As Boolean

        Dim objToken As New classToken
        objToken.getDataToken()


        Try
            Dim data As String
            Dim MyServidor, MyUsuario, MyPass As String
            Dim Mydb As String


            data = objToken.token
            MyServidor = objToken.host
            MyUsuario = objToken.user
            MyPass = objToken.pass
            Mydb = objToken.db
            GlobalTimerToken = objToken.intervalo

            Token = data

            strHostConectionString = "Data Source=" & MyServidor & ";Initial Catalog=" & Mydb & ";User ID=" & MyUsuario & ";Password=" & MyPass & ";MultipleActiveResultSets=True"
            StrMyHostConnection = ""

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function getTokenOLD() As Boolean

        Try
            Dim data As String
            Dim MyServidor, MyUsuario, MyPass As String
            Dim Mydb As String

            Dim mySqlDb, mySqlUser, mySqlPass, mySqlServer As String

            Dim fic As String = Application.StartupPath + "\token.token"
            Dim sr As New System.IO.StreamReader(fic)
            data = sr.ReadLine()
            MyServidor = sr.ReadLine()
            MyUsuario = sr.ReadLine()
            MyPass = sr.ReadLine()
            Mydb = sr.ReadLine()
            GlobalTimerToken = Integer.Parse(sr.ReadLine())

            Dim espacio As String = sr.ReadLine()

            mySqlServer = sr.ReadLine()
            mySqlUser = sr.ReadLine()
            mySqlPass = sr.ReadLine()
            mySqlDb = sr.ReadLine()

            sr.Close()

            Dim ps As New Seguridad("razors1805")
            Token = ps.DecryptData(data)

            MyUsuario = ps.DecryptData(MyUsuario)
            MyPass = ps.DecryptData(MyPass)

            strHostConectionString = "Data Source=" & MyServidor & ";Initial Catalog=" & Mydb & ";User ID=" & MyUsuario & ";Password=" & MyPass & ";MultipleActiveResultSets=True"
            StrMyHostConnection = String.Format("server={0};user id={1};password={2};database={3};pooling=false", mySqlServer, mySqlUser, mySqlPass, mySqlDb)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


#End Region

#Region " ** NUMEROS A LETRAS ** "

    Public Function Letras(ByVal numero As String) As String
        '********Declara variables de tipo cadena************
        Dim palabras, entero, dec, flag As String

        '********Declara variables de tipo entero***********
        Dim num, x, y As Integer

        flag = "N"

        '**********Número Negativo***********
        If Mid(numero, 1, 1) = "-" Then
            numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
            palabras = "menos "
        End If

        '**********Si tiene ceros a la izquierda*************
        For x = 1 To numero.ToString.Length
            If Mid(numero, 1, 1) = "0" Then
                numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                If Trim(numero.ToString.Length) = 0 Then palabras = ""
            Else
                Exit For
            End If
        Next

        '*********Dividir parte entera y decimal************
        For y = 1 To Len(numero)
            If Mid(numero, y, 1) = "." Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, y, 1)
                Else
                    dec = dec + Mid(numero, y, 1)
                End If
            End If
        Next y

        If Len(dec) = 1 Then dec = dec & "0"

        '**********proceso de conversión***********
        flag = "N"

        If Val(numero) <= 999999999 Then
            For y = Len(entero) To 1 Step -1
                num = Len(entero) - (y - 1)
                Select Case y
                    Case 3, 6, 9
                        '**********Asigna las palabras para las centenas***********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                    palabras = palabras & "cien "
                                Else
                                    palabras = palabras & "ciento "
                                End If
                            Case "2"
                                palabras = palabras & "doscientos "
                            Case "3"
                                palabras = palabras & "trescientos "
                            Case "4"
                                palabras = palabras & "cuatrocientos "
                            Case "5"
                                palabras = palabras & "quinientos "
                            Case "6"
                                palabras = palabras & "seiscientos "
                            Case "7"
                                palabras = palabras & "setecientos "
                            Case "8"
                                palabras = palabras & "ochocientos "
                            Case "9"
                                palabras = palabras & "novecientos "
                        End Select
                    Case 2, 5, 8
                        '*********Asigna las palabras para las decenas************
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    flag = "S"
                                    palabras = palabras & "diez "
                                End If
                                If Mid(entero, num + 1, 1) = "1" Then
                                    flag = "S"
                                    palabras = palabras & "once "
                                End If
                                If Mid(entero, num + 1, 1) = "2" Then
                                    flag = "S"
                                    palabras = palabras & "doce "
                                End If
                                If Mid(entero, num + 1, 1) = "3" Then
                                    flag = "S"
                                    palabras = palabras & "trece "
                                End If
                                If Mid(entero, num + 1, 1) = "4" Then
                                    flag = "S"
                                    palabras = palabras & "catorce "
                                End If
                                If Mid(entero, num + 1, 1) = "5" Then
                                    flag = "S"
                                    palabras = palabras & "quince "
                                End If
                                If Mid(entero, num + 1, 1) > "5" Then
                                    flag = "N"
                                    palabras = palabras & "dieci"
                                End If
                            Case "2"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "veinte "
                                    flag = "S"
                                Else
                                    palabras = palabras & "veinti"
                                    flag = "N"
                                End If
                            Case "3"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "treinta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "treinta y "
                                    flag = "N"
                                End If
                            Case "4"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cuarenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cuarenta y "
                                    flag = "N"
                                End If
                            Case "5"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "cincuenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "cincuenta y "
                                    flag = "N"
                                End If
                            Case "6"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "sesenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "sesenta y "
                                    flag = "N"
                                End If
                            Case "7"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "setenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "setenta y "
                                    flag = "N"
                                End If
                            Case "8"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "ochenta "
                                    flag = "S"
                                Else
                                    palabras = palabras & "ochenta y "
                                    flag = "N"
                                End If
                            Case "9"
                                If Mid(entero, num + 1, 1) = "0" Then
                                    palabras = palabras & "noventa "
                                    flag = "S"
                                Else
                                    palabras = palabras & "noventa y "
                                    flag = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********Asigna las palabras para las unidades*********
                        Select Case Mid(entero, num, 1)
                            Case "1"
                                If flag = "N" Then
                                    If y = 1 Then
                                        palabras = palabras & "uno "
                                    Else
                                        palabras = palabras & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then palabras = palabras & "dos "
                            Case "3"
                                If flag = "N" Then palabras = palabras & "tres "
                            Case "4"
                                If flag = "N" Then palabras = palabras & "cuatro "
                            Case "5"
                                If flag = "N" Then palabras = palabras & "cinco "
                            Case "6"
                                If flag = "N" Then palabras = palabras & "seis "
                            Case "7"
                                If flag = "N" Then palabras = palabras & "siete "
                            Case "8"
                                If flag = "N" Then palabras = palabras & "ocho "
                            Case "9"
                                If flag = "N" Then palabras = palabras & "nueve "
                        End Select
                End Select

                '***********Asigna la palabra mil***************
                If y = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or
                    (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And
                    Len(entero) <= 6) Then palabras = palabras & "mil "
                End If

                '**********Asigna la palabra millón*************
                If y = 7 Then
                    If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                        palabras = palabras & " millón "
                    Else
                        palabras = palabras & " millones "
                    End If
                End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If dec <> "" Then
                Letras = palabras & "con " & dec & "/100"
            Else
                Letras = palabras
            End If
        Else
            Letras = ""
        End If

    End Function
#End Region

    Public Function VerificarClaveVendedor(ByVal Owner As Form, ByVal CodVen As Integer, ByVal Clave As String) As Boolean

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT NOMVEN FROM VENDEDORES WHERE CODVEN=" & CodVen & " AND EMPNIT='" & GlobalEmpNit & "' AND CLAVE='" & Clave & "'", cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()

    End Function


    Public Function fcn_HablarTexto(ByVal texto As String) As Boolean
        Try
            Dim Hablar As New SpeechSynthesizer
            Hablar.SpeakAsync(texto)
            'Hablar.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try


    End Function


    Public Function AbrirConexionSql() As Boolean
        If cn.State = ConnectionState.Closed Then
            cn = New SqlConnection(strSqlConectionString)
            cn.Open()
        End If

        If cn.State = ConnectionState.Connecting Then

        End If

        'Try
        'If cn.State = 0 Then
        'cn.Open()
        'End If
        'Return True
        'Catch ex As Exception
        ' Return False
        ' End Try
    End Function


    'OBTIENE LA IMAGEN DEL CAMPO BINARIO DE SQL
    Public Function ObtenerImgSql(ByVal DrField As Object) As Image
        Try
            Dim imageData As Byte()

            If DrField Is DBNull.Value Then
                Return Nothing
            Else
                imageData = DrField
                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    Return Image.FromStream(ms, True)
                End Using
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function DiaSemanaPago(ByVal fecha As Date) As Integer
        Return Weekday(fecha, 2)
    End Function


    Private Sub CargarCorrelativo()

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Dim dr As SqlDataReader
            Dim cmd As New SqlCommand
            cmd.Connection = cn
            cmd.CommandType = System.Data.CommandType.Text
            cmd.CommandText = "SELECT Correlativo FROM TipoDocumentos WHERE CodDocumento='SVC'"
            dr = cmd.ExecuteReader()
            dr.Read()

            If dr.HasRows Then
                'Me.txtCorrelativo.Text = dr(0).ToString
            End If

            dr.Close()
            dr = Nothing

            'cn.Close()
            cmd.Dispose()
        End Using

    End Sub

    Public Sub Aviso(ByVal Titulo As String, ByVal Mensaje As String, ByVal Owner As Form)
        Dim action As New FlyoutAction()
        action.Caption = Titulo
        action.Description = Mensaje
        action.Commands.Add(FlyoutCommand.OK)

        FlyoutDialog.Show(Owner, action)

    End Sub

    Public Function Confirmacion(ByVal Mensaje As String, ByVal Owner As Form) As Boolean
        Dim action As New FlyoutAction()
        action.Caption = "Confirme"
        action.Description = Mensaje
        action.Commands.Add(FlyoutCommand.OK)
        action.Commands.Add(FlyoutCommand.Cancel)

        '  action.Image = Image.FromFile("")
        Dim x As Integer
        x = FlyoutDialog.Show(Owner, action)

        If x = DialogResult.OK Then
            Return True
        Else
            Return False
        End If

    End Function


    ''' <summary>
    ''' String que contiene la cadena de conexión de la base de datos local SQl
    ''' </summary>
    Public strSqlConectionString As String

    ''' <summary>
    ''' String que contiene la cadena de conexión al host de sincronización
    ''' </summary>
    Public strHostConectionString As String 'cadena de conexión al host de sincronizacioens

    Public Sub CargarConexion()


        Try
            Dim ps As New Security.Seguridad("razors1805")

            Dim localdb = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "LocalDb", Nothing).ToString
            Dim server = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "server", Nothing).ToString
            Dim dbs = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "db", Nothing).ToString
            Dim user = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "user", Nothing).ToString
            Dim pass = ps.DecryptData(My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\POS\OnnePOS\Server", "pass", Nothing).ToString)


            strSqlConectionString = "Data Source=" & server & ";Initial Catalog=" & dbs & ";User ID=" & user & ";Password=" & pass & ";MultipleActiveResultSets=True"


            cn = New SqlConnection(strSqlConectionString)

        Catch ex As Exception
            MsgBox("No hay registro de conexión " + ex.ToString)
        End Try


    End Sub



    '*********** RUTINA TEMPORAL PARA PRE-SELECCIONAR UN CODDOC PARA LAS VENTAS EN MÚLTIPLES USUARIOS
    Public Sub CargarCoddoc()
        Try
            Dim fic As String = Application.StartupPath + "\TEMP\CODDOC.TXT"
            Dim sr As New System.IO.StreamReader(fic)

            GlobalTipoProd = sr.ReadLine() 'tipo producto
            GlobalTipoPrecio = sr.ReadLine() 'tipo precio
            GlobalCoddocENVIOS = sr.ReadLine() 'envios
            GlobalCoddoc = sr.ReadLine() 'tipo fac / fel
            GlobalCoddocCOTIZ = sr.ReadLine() 'cotizaciones
            GlobalCoddocCOMPRA = sr.ReadLine() 'compra
            GlobalCoddocORDENCOMPRA = sr.ReadLine 'orden de compra
            GlobalCoddocReciboCliente = sr.ReadLine() 'recibo
            GlobalCoddocTrasSalBodega = sr.ReadLine() 'tras salida bbodega
            GlobalCoddocTrasEntradaBodega = sr.ReadLine 'tras entrada bodega
            GlobalCoddocTrasSalSucursal = sr.ReadLine 'tras salida sucursal
            GlobalCoddocTrasEntradaSucursal = sr.ReadLine 'tras entrada sucursal
            GlobalTomarDatosTipoDoc = sr.ReadLine 'para tomar datos COT o ENV
            Try
                GlobalFELEnviaCodigoProducto = sr.ReadLine
            Catch ex As Exception
                GlobalFELEnviaCodigoProducto = "SI"
            End Try
            Try
                GlobalPathMinimos = sr.ReadLine
            Catch ex As Exception

            End Try
            GlobalCoddocIEF = sr.ReadLine 'ingreso de efectivo

            GlobalCoddocFEL = GlobalCoddoc
            sr.Close()

            GlobalTipoPrecioSucursal = GlobalTipoPrecio 'tipo precio

        Catch ex As Exception
            MessageBox.Show("No existe Temp/coddoc.txt, consulte a servicio técnico")
            End
        End Try
    End Sub
    '*********************************


    Public Sub EnviarGmail(ByVal Subject As String, ByVal Body As String, ByVal Destino As String)
        'GmailEmisor = "sistemaarespos@gmail.com"
        'GmailEmisorPass = "razors1805"
        Try

            Dim MMessage As System.Net.Mail.MailMessage = New MailMessage

            Try
                MMessage.To.Add(Destino)
            Catch ex As Exception
                'MMessage.To.Add("ralexmailreu@gmail.com")
            End Try


            MMessage.From = New MailAddress(GmailEmisor, GmailEmisor, System.Text.Encoding.UTF8)
            MMessage.Subject = Subject
            MMessage.SubjectEncoding = System.Text.Encoding.UTF8
            MMessage.Body = Body
            MMessage.BodyEncoding = System.Text.Encoding.UTF8
            MMessage.IsBodyHtml = False

            Dim sClient As New SmtpClient()
            sClient.Credentials = New System.Net.NetworkCredential(GmailEmisor, GmailEmisorPass)
            sClient.Host = "smtp.gmail.com"
            sClient.Port = 587

            sClient.EnableSsl = True


            sClient.Send(MMessage)
        Catch ex As System.Net.Mail.SmtpException
            'MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub EnviarGmailAdjunto(ByVal Subject As String, ByVal Body As String, ByVal Destino As String, ByVal RutaAdjunto As String)

        'GmailEmisor = "sistemaarespos@gmail.com"
        'GmailEmisorPass = "razors1805"

        Try

            Dim MMessage As System.Net.Mail.MailMessage = New MailMessage
            MMessage.To.Add(Destino)
            MMessage.From = New MailAddress(GmailEmisor, GmailEmisor, System.Text.Encoding.UTF8)
            MMessage.Subject = Subject
            MMessage.SubjectEncoding = System.Text.Encoding.UTF8
            MMessage.Body = Body
            MMessage.BodyEncoding = System.Text.Encoding.UTF8
            MMessage.IsBodyHtml = False
            Dim archivo As Net.Mail.Attachment = New Net.Mail.Attachment(RutaAdjunto)
            MMessage.Attachments.Add(archivo)

            Dim sClient As New SmtpClient()
            sClient.Credentials = New System.Net.NetworkCredential(GmailEmisor, GmailEmisorPass)
            sClient.Host = "smtp.gmail.com"
            sClient.Port = 587

            sClient.EnableSsl = True


            sClient.Send(MMessage)
        Catch ex As System.Net.Mail.SmtpException
            '   MsgBox(ex.ToString)
        End Try

    End Sub
    'variables globales para correo y pass del gmail
    Public GmailEmisor As String
    Public GmailEmisorPass As String


    Public Sub EnviarGmail2(ByVal Subject As String, ByVal Body As String)
        'GmailEmisor = "sistemaarespos@gmail.com"
        'GmailEmisorPass = "razors1805"

        Exit Sub

        Dim MMessage As System.Net.Mail.MailMessage = New MailMessage
        'MMessage.To.Add("ralexmailreu@gmail.com")
        MMessage.From = New MailAddress(GmailEmisor, GmailEmisor, System.Text.Encoding.UTF8)
        MMessage.Subject = Subject
        MMessage.SubjectEncoding = System.Text.Encoding.UTF8
        MMessage.Body = Body
        MMessage.BodyEncoding = System.Text.Encoding.UTF8
        MMessage.IsBodyHtml = False

        Dim sClient As New SmtpClient()
        sClient.Credentials = New System.Net.NetworkCredential(GmailEmisor, GmailEmisorPass)
        sClient.Host = "smtp.gmail.com"
        sClient.Port = 587

        sClient.EnableSsl = True

        Try
            sClient.Send(MMessage)
        Catch ex As System.Net.Mail.SmtpException
            '   MsgBox(ex.ToString)
        End Try

    End Sub


#Region " ** LICENCIA DE USO ** "

    Public Function AlexisKey() As Boolean
        Try

            Dim readValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\VB and VBA Program Settings\AresPOS\Datos PC", "PcId", Nothing)
            If readValue.ToString = "Ares" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception

            Return False

        End Try

    End Function


    Public Sub CrearValue() 'crea un registro en el registro de win para compararlo desde la app access

        Try
            Dim KeyPath As String = "Software\VB and VBA Program Settings\AresPOS\Datos PC"
            Dim ValueName As String = "PcId"

            Registry.CurrentUser.CreateSubKey(KeyPath)

            Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(KeyPath, True) ' True indica que se abre para escritura
            key.SetValue(ValueName, "Ares", RegistryValueKind.String)
            MessageBox.Show("Key agregada")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

#End Region


End Module
