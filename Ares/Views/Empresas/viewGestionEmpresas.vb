Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewGestionEmpresas


    Sub New(ByVal _editar As Boolean, ByVal _empnit As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bolEditar = _editar
        emp = _empnit

    End Sub

    Dim bolEditar As Boolean = False
    Dim emp As String

    Dim objFEL As New classFEL

    Private Sub viewGestionEmpresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Call CargarTiposEmpresas()


        'With Me.cmbEmpresasRegimen
        '.DataSource = objFEL.tblTipoRegimen
        '.ValueMember = "CODIGO"
        '.DisplayMember = "DESCRIPCION"
        'End With

        Call getComboCatalogoPrecios()

        If bolEditar = True Then
            Call ObtenerDatosEmpresa()
            Me.txtEmpresasNit.Enabled = False
        End If

    End Sub

    Private Sub getComboCatalogoPrecios()
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("PRECIO", GetType(String))
            .Add("NOMBRE", GetType(String))
        End With

        With tbl.Rows
            .Add(New Object() {"PUBLICO", "CATALOGO A"})
            .Add(New Object() {"MAYOREO A", "CATALOGO B"})
            .Add(New Object() {"MAYOREO B", "CATALOGO C"})
            .Add(New Object() {"MAYOREO C", "CATALOGO D"})
        End With


        With Me.cmbEmpresaTipoPrecio
            .DataSource = tbl
            .ValueMember = "PRECIO"
            .DisplayMember = "NOMBRE"
        End With

    End Sub

    Private Sub txtEmpresasNit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpresasNit.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtEmpresasNombre.select()
        End If
    End Sub
    Private Sub txtEmpresasNombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpresasNombre.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtEmpresasRazon.select()
        End If
    End Sub
    Private Sub txtEmpresasRazon_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpresasRazon.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtEmpresasDireccion.select()
        End If
    End Sub
    Private Sub txtEmpresasDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpresasDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbEmpresasTipo.select()
        End If
    End Sub
    Private Sub cmbEmpresasTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEmpresasTipo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtEmpresasTelefonos.select()
        End If
    End Sub
    Private Sub txtEmpresasTelefonos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpresasTelefonos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbEmpresaTipoPrecio.select()
        End If
    End Sub

    Private Sub cmdEmpresasGuardar_Click(sender As Object, e As EventArgs) Handles cmdEmpresasGuardar.Click
        If Me.txtEmpresasNit.Text <> "" Then
            If Me.txtEmpresasNombre.Text <> "" Then
                If Me.txtEmpresasRazon.Text <> "" Then
                Else
                    Me.txtEmpresasRazon.Text = Me.txtEmpresasNombre.Text
                End If
                If Me.txtEmpresasDireccion.Text <> "" Then
                Else
                    Me.txtEmpresasDireccion.Text = "Ciudad"
                End If
                If Me.txtEmpresasTelefonos.Text <> "" Then
                Else
                    Me.txtEmpresasTelefonos.Text = "SN"
                End If

                If Me.cmbEmpresaTipoPrecio.Text <> "" Then
                Else
                    Me.cmbEmpresaTipoPrecio.SelectedValue = "PUBLICO"
                End If

                If Me.cmbEmpresasTipo.Text <> "" Then
                Else
                    MsgBox("SELECCIONE UN TIPO DE LA LISTA")
                    Exit Sub
                End If

                Dim tipo As Integer = 0

                If Me.cmbEmpresasTipo.Text = "CENTRAL" Then
                    tipo = 1
                End If
                If Me.cmbEmpresasTipo.Text = "SUCURSAL" Then
                    tipo = 2
                End If

                If Me.txtObjetivoVentas.Text <> "" Then
                Else
                    Me.txtObjetivoVentas.Text = "1"
                End If

                If ExisteCodEmpresa(Me.txtEmpresasNit.Text) = False Then

                    If Confirmacion("¿Está seguro que desea Guardar esta Nueva Empresa?", Me.ParentForm) = True Then

                        Call AbrirConexionSql()

                        Dim sql As String
                        If bolEditar = True Then
                            sql = "UPDATE EMPRESAS SET EMPNOMBRE=@EMPNOMBRE,EMPRAZONSOCIAL=@EMPRAZONSOCIAL,EMPDIRECCION=@EMPDIRECCION,EMPTELEFONO=@EMPTELEFONO,
                                    EMPEMAIL=@EMPEMAIL,CODTIPOEMPRESA=@CODTIPOEMPRESA,OBJETIVO_VENTAS=@OV
                                    WHERE EMPNIT=@EMPNIT"
                            Dim cmd As New SqlCommand(sql, cn)
                            cmd.Parameters.AddWithValue("@EMPNIT", Me.txtEmpresasNit.Text)
                            cmd.Parameters.AddWithValue("@EMPNOMBRE", Me.txtEmpresasNombre.Text)
                            cmd.Parameters.AddWithValue("@EMPRAZONSOCIAL", Me.txtEmpresasRazon.Text)
                            cmd.Parameters.AddWithValue("@EMPDIRECCION", Me.txtEmpresasDireccion.Text)
                            cmd.Parameters.AddWithValue("@EMPTELEFONO", Me.txtEmpresasTelefonos.Text)
                            cmd.Parameters.AddWithValue("@EMPEMAIL", Me.cmbEmpresaTipoPrecio.SelectedValue.ToString)
                            cmd.Parameters.AddWithValue("@CODTIPOEMPRESA", tipo) 'Integer.Parse(Me.cmbEmpresasTipo.SelectedValue))
                            cmd.Parameters.AddWithValue("@OV", Double.Parse(Me.txtObjetivoVentas.Text))
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            If Me.txtEmpresasNit.Text = GlobalEmpNit Then
                                'carga el tipo de precio predeterminado para el cliente
                                GlobalTipoPrecio = Me.cmbEmpresaTipoPrecio.SelectedValue.ToString
                                Form1.lbVentasTipoPrecio.Text = GlobalTipoPrecio
                            End If


                        Else

                            If FlyoutDialog.Show(Me.ParentForm, New ViewClave("2410201415082017")) = DialogResult.OK Then
                                sql = "INSERT INTO EMPRESAS (EMPNIT,EMPNOMBRE,EMPRAZONSOCIAL,EMPDIRECCION,EMPTELEFONO,EMPEMAIL,EMPMESPROCESO,EMPANIOPROCESO,CODTIPOEMPRESA,OBJETIVO_VENTAS)
                        VALUES (@EMPNIT,@EMPNOMBRE,@EMPRAZONSOCIAL,@EMPDIRECCION,@EMPTELEFONO,@EMPEMAIL,@EMPMESPROCESO,@EMPANIOPROCESO,@CODTIPOEMPRESA, @OV)"
                                Dim cmd As New SqlCommand(sql, cn)
                                cmd.Parameters.AddWithValue("@EMPNIT", Me.txtEmpresasNit.Text)
                                cmd.Parameters.AddWithValue("@EMPNOMBRE", Me.txtEmpresasNombre.Text)
                                cmd.Parameters.AddWithValue("@EMPRAZONSOCIAL", Me.txtEmpresasRazon.Text)
                                cmd.Parameters.AddWithValue("@EMPDIRECCION", Me.txtEmpresasDireccion.Text)
                                cmd.Parameters.AddWithValue("@EMPTELEFONO", Me.txtEmpresasTelefonos.Text)
                                cmd.Parameters.AddWithValue("@EMPEMAIL", Me.cmbEmpresaTipoPrecio.SelectedValue.ToString)
                                cmd.Parameters.AddWithValue("@EMPMESPROCESO", 0) 'Integer.Parse(Me.cmdMesProceso.SelectedValue))
                                cmd.Parameters.AddWithValue("@EMPANIOPROCESO", 0) 'Integer.Parse(Me.cmdAnioProceso.Text))
                                cmd.Parameters.AddWithValue("@CODTIPOEMPRESA", tipo) 'Integer.Parse(Me.cmbEmpresasTipo.SelectedValue))
                                cmd.Parameters.AddWithValue("@OV", Double.Parse(Me.txtObjetivoVentas.Text))
                                cmd.ExecuteNonQuery()
                                cmd.Dispose()

                                Dim objqryinicial As New classQuerys

                                Dim cmd2 As New SqlCommand(objqryinicial.querySqlNuevaEmpresa, cn)

                                cmd2.Parameters.AddWithValue("@EMPNIT", Me.txtEmpresasNit.Text)
                                cmd2.ExecuteNonQuery()
                                cmd2.Dispose()

                                Call CargarEmpresas()

                            Else
                                Call Aviso("NO AUTORIZADO", "No se le permite crear empresas, contacte a servicio técnico", Form1)
                                Exit Sub
                            End If



                        End If


                        cn.Close()

                        Call Form1.Mensaje("Empresa Guardada Exitosamente")

                        Me.btnAceptarTrue.PerformClick()

                    End If
                Else
                    If bolEditar = True Then
                        If Confirmacion("¿Está seguro que desea Editar esta Empresa?", Me.ParentForm) = True Then

                            Call AbrirConexionSql()

                            Dim sql As String

                            sql = "UPDATE EMPRESAS SET EMPNOMBRE=@EMPNOMBRE,EMPRAZONSOCIAL=@EMPRAZONSOCIAL,EMPDIRECCION=@EMPDIRECCION,EMPTELEFONO=@EMPTELEFONO,
                            EMPEMAIL=@EMPEMAIL,CODTIPOEMPRESA=@CODTIPOEMPRESA,OBJETIVO_VENTAS=@OV
                            WHERE EMPNIT=@EMPNIT"
                            Dim cmd As New SqlCommand(sql, cn)
                            cmd.Parameters.AddWithValue("@EMPNIT", Me.txtEmpresasNit.Text)
                            cmd.Parameters.AddWithValue("@EMPNOMBRE", Me.txtEmpresasNombre.Text)
                            cmd.Parameters.AddWithValue("@EMPRAZONSOCIAL", Me.txtEmpresasRazon.Text)
                            cmd.Parameters.AddWithValue("@EMPDIRECCION", Me.txtEmpresasDireccion.Text)
                            cmd.Parameters.AddWithValue("@EMPTELEFONO", Me.txtEmpresasTelefonos.Text)
                            cmd.Parameters.AddWithValue("@EMPEMAIL", Me.cmbEmpresaTipoPrecio.SelectedValue.ToString)
                            cmd.Parameters.AddWithValue("@CODTIPOEMPRESA", tipo) 'Integer.Parse(Me.cmbEmpresasTipo.SelectedValue))
                            cmd.Parameters.AddWithValue("@OV", Double.Parse(Me.txtObjetivoVentas.Text))
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()

                            If Me.txtEmpresasNit.Text = GlobalEmpNit Then
                                'carga el tipo de precio predeterminado para el cliente
                                GlobalTipoPrecio = Me.cmbEmpresaTipoPrecio.SelectedValue.ToString
                                Form1.lbVentasTipoPrecio.Text = GlobalTipoPrecio
                            End If

                            cn.Close()
                            Call Form1.Mensaje("Empresa Editada Exitosamente")


                            Me.btnAceptarTrue.PerformClick()

                        End If


                    Else
                        Call Aviso("No Permitido", "Ya existe una empresa con este NIT / Código", Me.ParentForm)
                    End If

                End If
            Else
                Call Aviso("Importante", "Escriba el nombre de la Empresa", Me.ParentForm)
            End If
        Else
            Call Aviso("Importante", "Escriba el NI o Código de la Empresa", Me.ParentForm)
        End If
    End Sub

    Private Function ExisteCodEmpresa(ByVal Empnit As String) As Boolean
        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT EMPNIT FROM EMPRESAS WHERE EMPNIT='" & Empnit & "'", cn)
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
    End Function

    Private Sub cmdEmpresasCancelarEdit_Click(sender As Object, e As EventArgs) Handles cmdEmpresasCancelarEdit.Click
        Me.txtEmpresasNit.Enabled = True
        Me.txtEmpresasNit.Text = ""
        Me.txtEmpresasNombre.Text = ""
        Me.txtEmpresasRazon.Text = ""
        Me.txtEmpresasDireccion.Text = ""
        Me.cmbEmpresasTipo.Text = ""
        Me.txtEmpresasTelefonos.Text = ""
        Me.txtObjetivoVentas.Text = "1"

        Me.cmdEmpresasGuardar.Visible = True
        Me.cmdEmpresasCancelarEdit.Visible = False

    End Sub


    Private Sub ObtenerDatosEmpresa()

        Using cn As New SqlConnection(strSqlConectionString)

            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT EMPNIT,EMPNOMBRE,EMPRAZONSOCIAL,EMPDIRECCION,
                                        EMPTELEFONO,EMPEMAIL,EMPCONTACTO,EMPTELCONTACTO,EMPEMAILCONTACTO,
                                        CODTIPOEMPRESA,ISNULL(OBJETIVO_VENTAS,0) AS OBJETIVO_VENTAS
                                        FROM EMPRESAS WHERE EMPNIT=@E ", cn)
                cmd.Parameters.AddWithValue("@E", emp)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                Try
                    Me.txtEmpresasNit.Text = dr(0).ToString
                    Me.txtEmpresasNombre.Text = dr(1).ToString
                    Me.txtEmpresasRazon.Text = dr(2).ToString
                    Me.txtEmpresasDireccion.Text = dr(3).ToString

                    Dim tipo As String = ""
                    If dr(9).ToString = "1" Then
                        tipo = "CENTRAL"
                    Else
                        tipo = "SUCURSAL"
                    End If
                    Me.cmbEmpresasTipo.Text = tipo
                    Me.txtEmpresasTelefonos.Text = dr(4).ToString
                    Me.cmbEmpresaTipoPrecio.SelectedValue = dr(5).ToString
                    Me.txtObjetivoVentas.Text = dr(10).ToString
                Catch ex As Exception


                End Try
                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                'MsgBox(ex.ToString)
            End Try


        End Using



    End Sub

    Private Sub CargarTiposEmpresas()

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                'TIPO DE EMPRESAS
                Dim Dt6 As DataTable
                Dim Da6 As New SqlDataAdapter
                Dim Cmd6 As New SqlCommand
                With Cmd6
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT CODTIPOEMPRESA, TIPOEMPRESA FROM TIPOEMPRESA"
                    .Connection = cn
                End With
                Da6.SelectCommand = Cmd6
                Dt6 = New DataTable
                Da6.Fill(Dt6)


                With Me.cmbEmpresasTipo
                    .DataSource = Dt6
                    .DisplayMember = "TIPOEMPRESA"
                    .ValueMember = "CODTIPOEMPRESA"
                End With


            Catch ex As Exception

            End Try
        End Using

    End Sub



End Class
