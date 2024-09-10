
Imports System.Data.SqlClient

Public Class viewOnlineClientesCenso

    Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)

    Private Sub viewOnlineClientesCenso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objHost As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)

        Call CargarGrid()




    End Sub

    Private Sub CargarGrid()

        Me.gridClientesCenso.DataSource = Nothing
        Me.gridClientesCenso.DataSource = objGen.getClientesCenso("PENDIENTE")

    End Sub


    Dim drw As DataRow
    Private Sub GridViewClientesCenso_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewClientesCenso.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewClientesCenso.GetFocusedDataRow
            Call getDataCliente(drw)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub getDataCliente(ByVal data As DataRow)

        Me.txtId.Text = data.Item(0).ToString
        Me.txtCodclie.Text = "" 'data.Item(1).ToString
        Me.txtNitClie.Text = data.Item(2).ToString
        Me.txtTipoNegocio.Text = data.Item(3).ToString
        Me.txtNegocio.Text = data.Item(4).ToString
        Me.txtNomclie.Text = data.Item(5).ToString
        Me.txtDirclie.Text = data.Item(6).ToString
        Me.txtReferencia.Text = data.Item(7).ToString
        Me.txtMunicipio.Text = data.Item(8).ToString
        Me.txtDepartamento.Text = data.Item(9).ToString
        Me.txtObs.Text = data.Item(10).ToString
        Me.txtTelefono.Text = data.Item(11).ToString
        Me.txtVisita.Text = data.Item(12).ToString
        'lat = data.Item(13).ToString
        'long = data.Item(14).ToString
        'status = data.Item(15).ToString
        Me.txtVendedor.Text = data.Item(16).ToString
        'email = data.Item(17).ToString
        'codven= data.Item(18).ToString
        'codmun= data.Item(19).ToString
        'coddepto= data.Item(20).ToString

    End Sub

    Private Sub btnGenerarCliente_Click(sender As Object, e As EventArgs) Handles btnGenerarCliente.Click

        If Me.txtCodclie.Text <> "" Then
            If Me.txtObs.Text <> "" Then
            Else
                Me.txtObs.Text = "SN"
            End If
            If Me.txtReferencia.Text <> "" Then
            Else
                Me.txtReferencia.Text = "SN"
            End If
            If Me.txtTelefono.Text <> "" Then
            Else
                Me.txtTelefono.Text = "0000"
            End If


            Dim objCli As New classClientes(GlobalEmpNit)
            'verifica si el campo codclie existe ya en la base de datos
            If objCli.verifyCodClie(Me.txtCodclie.Text) = True Then
                MsgBox("Este código de cliente ya existe, por favor, use otro")
            Else
                Dim x As Integer
                x = MsgBox("¿Está a punto de generar un cliente nuevo, desea continuar?", MsgBoxStyle.OkCancel)
                If x = MsgBoxResult.Ok Then
                    If insertarCliente() = True Then

                        Dim id As Integer = CType(Me.txtId.Text, Integer)
                        objGen.setStatusClienteCenso(id)

                        MsgBox("Cliente generado exitosamente!!")
                        Call CargarGrid()


                    Else

                        MsgBox("No se pudo generar este cliente. Error: " + GlobalDesError)

                    End If
                End If

            End If

        Else
            MsgBox("Escriba el código de cliente o genérelo automáticamente con el botón")
        End If


    End Sub


    Private Sub btnGenerarCodclie_Click(sender As Object, e As EventArgs) Handles btnGenerarCodclie.Click
        Me.txtCodclie.Text = String.Format("aut{0}-{1}-{2}h{3}:{4}", Today.Date.Day.ToString, Today.Date.Month.ToString, Today.Date.Year.ToString, Now.Hour.ToString, Now.Minute.ToString)
    End Sub

    Private Function insertarCliente() As Boolean
        Dim r As Boolean

        '---------------------------------------------------
        'INSERTA EL CLIENTE EN LA SISTEMA LOCAL
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

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
                cmd.Parameters.AddWithValue("@NIT", Me.txtNitClie.Text)
                cmd.Parameters.AddWithValue("@NOMBRECLIENTE", Me.txtNomclie.Text)
                cmd.Parameters.AddWithValue("@DIRCLIENTE", Me.txtDirclie.Text)
                cmd.Parameters.AddWithValue("@CODMUNICIPIO", CType(drw.Item(19), Integer))
                cmd.Parameters.AddWithValue("@CODDEPARTAMENTO", CType(drw.Item(20), Integer))
                cmd.Parameters.AddWithValue("@TELEFONOCLIENTE", Me.txtTelefono.Text)
                cmd.Parameters.AddWithValue("@EMAILCLIENTE", "SN")
                cmd.Parameters.AddWithValue("@ESTADOCIVIL", "SOLTERO-A")
                cmd.Parameters.AddWithValue("@SEXO", "OTROS")
                cmd.Parameters.AddWithValue("@FECHANACIMIENTOCLIENTE", Today.Date)
                cmd.Parameters.AddWithValue("@LATITUDCLIENTE", drw.Item(13).ToString)
                cmd.Parameters.AddWithValue("@LONGITUDCLIENTE", drw.Item(14).ToString)
                cmd.Parameters.AddWithValue("@CATEGORIA", "P")
                cmd.Parameters.AddWithValue("@CIUDADANIA", "SN")
                cmd.Parameters.AddWithValue("@OCUPACION", Me.txtObs.Text)
                cmd.Parameters.AddWithValue("@CODRUTA", CType(drw.Item(18), Integer))
                cmd.Parameters.AddWithValue("@CALIFICACION", "REGULAR")
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@FECHAINICIO", Today.Date)
                cmd.Parameters.AddWithValue("@DIAVISITA", Me.txtVisita.Text)
                cmd.Parameters.AddWithValue("@LIMITECREDITO", 0)
                cmd.Parameters.AddWithValue("@DIASCREDITO", 0)
                cmd.Parameters.AddWithValue("@PROVINCIA", Me.txtReferencia.Text)
                cmd.Parameters.AddWithValue("@TIPONEGOCIO", Me.txtTipoNegocio.Text)
                cmd.Parameters.AddWithValue("@NEGOCIO", Me.txtNegocio.Text)
                cmd.Parameters.AddWithValue("@CODCLIE", Me.txtCodclie.Text)
                Dim i As Integer = cmd.ExecuteNonQuery()

                If i > 0 Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                GlobalDesError = ex.ToString
                r = False
            End Try

        End Using

        Return r
    End Function



End Class
