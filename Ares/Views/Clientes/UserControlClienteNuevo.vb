Imports System.Data.SqlClient

Public Class UserControlClienteNuevo

    Dim objClientes As New classClientes(GlobalEmpNit)


    Private Sub UserControlClienteNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ClienteNuevoCargado = False


        Call CargarMunicipiosDeptos()

        Call CargarRutasClientes()

        Call CargarComboboxesGenerales()

        Me.txtClientesNit.Text = Form1.txtVentasNitClie.Text
        Me.txtClientesCodclie.Text = Form1.txtVentasNitClie.Text


        Me.cmbClienteTipoNegocio.SelectedValue = "OTROS"
        Me.txtClienteNombreNegocio.Text = "SN"
        Me.cmbClienteDiaVisita.SelectedValue = "OTROS"
        Me.txtClientesNombre.Text = ""
        Me.txtClientesDireccion.Text = ""
        Me.txtClientesProvincia.Text = "SN"
        Me.txtClientesEmail.Text = "SN"


        'AL FINAL INTENTA ENCONTRAR LOS DATOS EN LA API FEL
        Dim objFEL As New classFEL
        If objFEL.getDataNIT(Me.txtClientesNit.Text) = True Then

            Me.txtClientesNombre.Text = GlobalSelectedNomCliente
            Me.txtClientesDireccion.Text = GlobalSelectedDirCliente
        Else
            MsgBox("Número de NIT inválido, no está registrado en la SAT o no se pudo hacer la comprobación en línea")
            Me.txtClientesNombre.Text = ""
            Me.txtClientesDireccion.Text = ""
        End If


        Dim tipopre As String = "P"
        Select Case GlobalTipoPrecio
            Case "PUBLICO"
                tipopre = "P"
            Case "MAYOREO A"
                tipopre = "A"
            Case "MAYOREO B"
                tipopre = "B"
            Case "MAYOREO C"
                tipopre = "C"
        End Select
        Me.cmbTipoPrecio.SelectedValue = tipopre

        'Me.txtClientesCodclie.select()
        Me.txtClientesNombre.Select()

    End Sub


#Region " KEYDOWNS "

    Private Sub txtClientesNit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientesNit.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.txtClientesCodclie.select()
            Me.cmdClientesGuardar.Select()
        End If
    End Sub



#End Region

    Private Sub CargarMunicipiosDeptos()

        Call AbrirConexionSql()
        'VENDEDORES EN VENTAS
        Dim Dt6 As DataTable
        Dim Da6 As New SqlDataAdapter
        Dim Cmd6 As New SqlCommand
        With Cmd6
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODMUNICIPIO, DESMUNICIPIO FROM MUNICIPIOS"
            .Connection = cn
        End With
        Da6.SelectCommand = Cmd6
        Dt6 = New DataTable
        Da6.Fill(Dt6)

        With cmbClientesMunicipio
            .DataSource = Dt6
            .DisplayMember = "DESMUNICIPIO"
            .ValueMember = "CODMUNICIPIO"
        End With
        Cmd6.Dispose()

        'CARGA LOS DEPARTAMENTOS
        Dim Dt As DataTable
        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODDEPARTAMENTO, DESDEPARTAMENTO FROM DEPARTAMENTOS"
            .Connection = cn
        End With
        Da.SelectCommand = Cmd
        Dt = New DataTable
        Da.Fill(Dt)

        With cmbClientesDepartamento
            .DataSource = Dt
            .DisplayMember = "DESDEPARTAMENTO"
            .ValueMember = "CODDEPARTAMENTO"
        End With
        Cmd.Dispose()

        'TIPOS DE PRECIO
        Dim t As New DataTable
        t.Columns.Add("CODTIPOPRECIO", GetType(String))
        t.Columns.Add("DESTIPOPRECIO", GetType(String))

        With t.Rows
            .Add("P", "PUBLICO")
            .Add("A", "MAYOREO A")
            .Add("B", "MAYOREO B")
            .Add("C", "MAYOREO C")
        End With

        With Me.cmbTipoPrecio
            .DataSource = t
            .ValueMember = "CODTIPOPRECIO"
            .DisplayMember = "DESTIPOPRECIO"
        End With

        cn.Close()
    End Sub

    Public Sub CargarRutasClientes()
        Call AbrirConexionSql()
        'CARGA LAS RUTAS
        Dim Dt2 As DataTable
        Dim Da2 As New SqlDataAdapter
        Dim Cmd2 As New SqlCommand
        With Cmd2
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODRUTA, DESRUTA FROM RUTAS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODRUTA ASC"
            .Connection = cn
        End With
        Da2.SelectCommand = Cmd2
        Dt2 = New DataTable
        Da2.Fill(Dt2)

        With cmbClientesRuta
            .DataSource = Dt2
            .DisplayMember = "DESRUTA"
            .ValueMember = "CODRUTA"
        End With

        Cmd2.Dispose()
        cn.Close()
    End Sub

    Dim SelectedNomCliente As String, SelectedNitCliente As String

    Private Sub CargarComboboxesGenerales()
        Dim objClie As New classClientes(GlobalEmpNit)

        With Me.cmbClienteTipoNegocio
            .DataSource = objClie.tblTipoNegocio
            .ValueMember = "COD"
            .DisplayMember = "COD"
        End With


        With Me.cmbClienteDiaVisita
            .DataSource = objClie.tblDiaSemana()
            .ValueMember = "DES"
            .DisplayMember = "DES"
        End With

    End Sub


    Private Sub CargarTipoPrecio()
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODIGO", GetType(String))
            .Add("DESCRIPCION", GetType(String))
        End With
        With tbl.Rows
            .Add(New Object() {"P", "PUBLICO"})
            .Add(New Object() {"A", "MAYOREO A"})
            .Add(New Object() {"B", "MAYOREO B"})
            .Add(New Object() {"C", "MAYOREO C"})
        End With
        With Me.cmbTipoPrecio
            .DataSource = tbl
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "CODIGO"
        End With

    End Sub

    Private Function GuardarClienteNuevo() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                If Me.txtClientesCodclie.Text <> "" Then

                Else
                    'genera automáticamente un código de cliente en base a la hora y fecha
                    Me.txtClientesCodclie.Text = String.Format("aut{0}-{1}-{2}h{3}:{4}", Today.Date.Day.ToString, Today.Date.Month.ToString, Today.Date.Year.ToString, Now.Hour.ToString, Now.Minute.ToString)
                End If



                Dim objCli As New classClientes(GlobalEmpNit)
                'verifica si el campo codclie existe ya en la base de datos
                If objCli.verifyCodClie(Me.txtClientesCodclie.Text) = True Then
                    If Me.cmdClientesCancelarEdit.Visible = True Then
                        GoTo Continuar
                    Else
                        Call Aviso("ERROR", "Este código de cliente ya existe, por favor utilice otro", Me.ParentForm)
                        Exit Function
                    End If

                Else
                    GoTo Continuar
                End If


Continuar:

                'If Me.cmbClienteTipoNegocio.SelectedIndex >= 0 Then
                'Else
                'Me.cmbClienteTipoNegocio.SelectedIndex = 0
                'End If

                If Me.txtClienteNombreNegocio.Text <> "" Then
                Else
                    Me.txtClienteNombreNegocio.Text = "SN"
                End If

                'If Me.cmbClienteDiaVisita.SelectedIndex >= 0 Then
                'Else
                'Me.cmbClienteDiaVisita.SelectedIndex = 0
                'End If

                If Me.lbClienteLat.Text <> "" Then
                Else
                    Me.lbClienteLat.Text = "0"
                End If
                If Me.lbClienteLong.Text <> "" Then
                Else
                    Me.lbClienteLong.Text = "0"
                End If

                If Me.txtClientesNit.Text <> "" Then
                Else
                    Me.txtClientesNit.Text = "CF"
                End If
                If Me.txtClientesNombre.Text <> "" Then

                    If Me.cmdClientesCancelarEdit.Visible = True Then
                        GoTo GuardarCliente
                    End If

                    If ExisteNitCliente(Me.txtClientesNit.Text) = False Then
                        GoTo GuardarCliente
                    Else
                        Call Aviso("No Permitido", "Este NIT ya existe, por favor utilice otro", Me.ParentForm)
                        Return False
                    End If

GuardarCliente:
                    If Me.txtClientesDireccion.Text <> "" Then
                        Me.txtClientesDireccion.Text = cleanString(Me.txtClientesDireccion.Text)
                    Else
                        Me.txtClientesDireccion.Text = "CIUDAD"
                    End If

                    If Me.cmbClientesMunicipio.SelectedValue > 0 Then
                    Else
                        Me.cmbClientesMunicipio.SelectedIndex = 0
                    End If
                    If Me.cmbClientesDepartamento.SelectedValue > 0 Then
                    Else
                        Me.cmbClientesDepartamento.SelectedIndex = 0
                    End If
                    If Me.txtClientesTelefonos.Text <> "" Then
                    Else
                        Me.txtClientesTelefonos.Text = "SN"
                    End If
                    If Me.txtClientesEmail.Text <> "" Then
                    Else
                        Me.txtClientesEmail.Text = "SN"
                    End If
                    If Me.txtClientesProvincia.Text <> "" Then
                    Else
                        Me.txtClientesProvincia.Text = "SN"
                    End If
                    'If Me.cmbClientesRuta.SelectedIndex >= 0 Then
                    'Else
                    'Me.cmbClientesRuta.SelectedIndex = 0
                    'End If
                    'If Me.cmbTipoPrecio.SelectedIndex >= 0 Then
                    'Else
                    'Me.cmbTipoPrecio.SelectedIndex = 0
                    'End If

                    If Confirmacion("¿Está seguro que desea guardar este Cliente?", Me.ParentForm) = True Then
                        Call AbrirConexionSql()

                        Dim sql As String

                        sql = "INSERT INTO CLIENTES (
                    EMPNIT,DPI,NIT,NOMBRECLIENTE,DIRCLIENTE,CODMUNICIPIO,CODDEPARTAMENTO,TELEFONOCLIENTE,EMAILCLIENTE,ESTADOCIVIL,SEXO,
                    FECHANACIMIENTOCLIENTE,LATITUDCLIENTE,LONGITUDCLIENTE,CATEGORIA,CIUDADANIA,OCUPACION,CODRUTA,CALIFICACION,SALDO,FECHAINICIO,
                    HABILITADO,DIAVISITA,LIMITECREDITO,DIASCREDITO,PROVINCIA,TIPONEGOCIO,NEGOCIO,CODCLIE) 
                    VALUES 
                    (@EMPNIT,@DPI,@NIT,@NOMBRECLIENTE,@DIRCLIENTE,@CODMUNICIPIO,@CODDEPARTAMENTO,@TELEFONOCLIENTE,@EMAILCLIENTE,@ESTADOCIVIL,@SEXO,
                    @FECHANACIMIENTOCLIENTE,@LATITUDCLIENTE,@LONGITUDCLIENTE,@CATEGORIA,@CIUDADANIA,@OCUPACION,@CODRUTA,@CALIFICACION,@SALDO,@FECHAINICIO,
                    'SI',@DIAVISITA,@LIMITECREDITO,@DIASCREDITO,@PROVINCIA,@TIPONEGOCIO,@NEGOCIO,@CODCLIE)"


                        Dim cmd As New SqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@DPI", "SN")
                        cmd.Parameters.AddWithValue("@NIT", Me.txtClientesNit.Text)
                        cmd.Parameters.AddWithValue("@NOMBRECLIENTE", Me.txtClientesNombre.Text)
                        cmd.Parameters.AddWithValue("@DIRCLIENTE", Me.txtClientesDireccion.Text)
                        cmd.Parameters.AddWithValue("@CODMUNICIPIO", Integer.Parse(Me.cmbClientesMunicipio.SelectedValue))
                        cmd.Parameters.AddWithValue("@CODDEPARTAMENTO", Integer.Parse(Me.cmbClientesDepartamento.SelectedValue))
                        cmd.Parameters.AddWithValue("@TELEFONOCLIENTE", Me.txtClientesTelefonos.Text)
                        cmd.Parameters.AddWithValue("@EMAILCLIENTE", Me.txtClientesEmail.Text)
                        cmd.Parameters.AddWithValue("@ESTADOCIVIL", "SOLTERO-A")
                        cmd.Parameters.AddWithValue("@SEXO", "OTROS")
                        cmd.Parameters.AddWithValue("@FECHANACIMIENTOCLIENTE", Today.Date)
                        cmd.Parameters.AddWithValue("@LATITUDCLIENTE", Me.lbClienteLat.Text)
                        cmd.Parameters.AddWithValue("@LONGITUDCLIENTE", Me.lbClienteLong.Text)
                        cmd.Parameters.AddWithValue("@CATEGORIA", "P") 'Me.cmbTipoPrecio.SelectedValue.ToString)
                        cmd.Parameters.AddWithValue("@CIUDADANIA", "SN")
                        cmd.Parameters.AddWithValue("@OCUPACION", "Comerciante")
                        cmd.Parameters.AddWithValue("@CODRUTA", 1) 'Integer.Parse(Me.cmbClientesRuta.SelectedValue))
                        cmd.Parameters.AddWithValue("@CALIFICACION", "REGULAR")
                        cmd.Parameters.AddWithValue("@SALDO", 0)
                        cmd.Parameters.AddWithValue("@FECHAINICIO", Today.Date)
                        cmd.Parameters.AddWithValue("@DIAVISITA", Me.cmbClienteDiaVisita.SelectedValue.ToString)
                        cmd.Parameters.AddWithValue("@LIMITECREDITO", 0)
                        cmd.Parameters.AddWithValue("@DIASCREDITO", 0)
                        cmd.Parameters.AddWithValue("@PROVINCIA", Me.txtClientesProvincia.Text)
                        cmd.Parameters.AddWithValue("@TIPONEGOCIO", "OTROS") 'Me.cmbClienteTipoNegocio.SelectedValue.ToString)
                        cmd.Parameters.AddWithValue("@NEGOCIO", Me.txtClienteNombreNegocio.Text)
                        cmd.Parameters.AddWithValue("@CODCLIE", "0") 'Me.txtClientesCodclie.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()


                        Call Form1.Mensaje("Cliente guardado exitosamente")
                        r = True

                    End If

                Else
                    Call Aviso("Importante", "Escriba el nombre del cliente", Me.ParentForm)
                    r = False
                End If


            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox(ex.ToString)
                r = False
            End Try
        End Using


        Return r

    End Function


    Private Sub cmdClientesGuardar_Click(sender As Object, e As EventArgs) Handles cmdClientesGuardar.Click
        If GuardarClienteNuevo() = True Then
            If SelectedForm = "VENTAS" Then
                Call Form1.ObtenerDatosCliente(Form1.txtVentasNitClie.Text)

                Form1.txtVentasCodProd.Select()
                ClienteNuevoCargado = False

                GlobalSelectedNomCliente = ""
                GlobalSelectedDirCliente = ""

                Me.btnAceptarTrue.PerformClick()

            End If

            If SelectedForm = "ORDENTRABAJO" Then

                SelectedCode = getLastCustomerCode()
                GlobalNomCliente = Me.txtClientesNombre.Text

                Me.btnAceptarTrue.PerformClick()

            End If
        Else
            MsgBox("No se pudo guardar el cliente, verifique")
        End If


    End Sub

    Private Sub cmbTipoPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipoPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Me.lbClienteLat.select()
            Me.cmdClientesGuardar.Select()
        End If
    End Sub

    'Private Sub lbClienteLat_KeyDown(sender As Object, e As KeyEventArgs) Handles lbClienteLat.KeyDown
    'If e.KeyCode = Keys.Enter Then
    'Me.lbClienteLong.select()
    'End If
    'End Sub

    'Private Sub lbClienteLong_KeyDown(sender As Object, e As KeyEventArgs) Handles lbClienteLong.KeyDown
    'If e.KeyCode = Keys.Enter Then
    'Me.cmdClientesGuardar.select()
    'End If
    'End Sub

    Private Sub txtClientesDireccion_Leave(sender As Object, e As EventArgs) Handles txtClientesDireccion.Leave
        Try
            Me.txtClientesDireccion.Text = cleanString(Me.txtClientesDireccion.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbTipoPrecio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPrecio.SelectedIndexChanged

    End Sub

    Private Function getLastCustomerCode() As Integer
        Dim i As Integer = 0
        Using cn As New SqlConnection(strSqlConectionString)
            Try

                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT MAX(CODCLIENTE) AS CODCLIENTE FROM CLIENTES", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                i = CType(dr(0), Integer)
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                i = 0
                MsgBox("Error al obtener código de cliente. " & ex.ToString)
            End Try

        End Using


        Return i
    End Function



End Class
