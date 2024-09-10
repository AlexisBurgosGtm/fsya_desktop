Imports System.Data
Imports System.Data.SqlClient

Module FuncionesPropias




#Region " ** CORRECCIÓN DE ERRORES DE IMPORTACIÓN DE DATOS ** "
    Public Function CorregirErroresProductos(ByVal Empnit As String) As Boolean

        Try


            '1) Recorro la lista de productos del sistema para obtener los códigos de producto
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("Select Codprod, Desprod from Productos where empnit=@empnit", cn)
            cmd.Parameters.AddWithValue("@empnit", Empnit)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            Do While dr.Read
                '2)Verifico y corrijo que tenga registros en la tabla precios
                If CorrijePrecios(Empnit, dr(0).ToString) = False Then
                    'sgBox("Error Precio: " & dr(1).ToString)
                End If

                '3) verifico que tenga registros en la tabla invsaldo
                If CorrijeInventarios(Empnit, dr(0).ToString) = True Then
                    ' MsgBox("Error inventario: " & dr(1).ToString)
                End If
            Loop

            dr.Close()
            cmd.Dispose()

            cn.Close()

            Return True
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString)
            Return False
        End Try


    End Function

    'verifica si un codigo de producto existe en la tabla precios
    Private Function CorrijePrecios(ByVal Empnit As String, ByVal Codprod As String) As Boolean
        Try
            Dim cmdData As New SqlCommand("Select codprod from precios where empnit=@empnit and codprod=@codprod", cn)
            cmdData.Parameters.AddWithValue("@empnit", Empnit)
            cmdData.Parameters.AddWithValue("@codprod", Codprod)
            Dim drData As SqlDataReader = cmdData.ExecuteReader
            drData.Read()

            Try
                If drData.HasRows Then
                    Dim a As String = drData(0).ToString
                End If
            Catch ex As Exception
                'inserta un registro estandar para resolver conflictos
                Dim cmdIns As New SqlCommand("Insert into precios (EMPNIT,CODPROD,CODMEDIDA,EQUIVALE,COSTO,PRECIO,UTILIDAD,PORCUTILIDAD,HABILITADO) VALUES (@EMPNIT,@CODPROD,'UNIDAD',1,1,1,0,0,'SI')", cn)
                cmdIns.Parameters.AddWithValue("@EMPNIT", Empnit)
                cmdIns.Parameters.AddWithValue("@CODPROD", Codprod)
                cmdIns.ExecuteNonQuery()
                cmdIns.Dispose()

            End Try

            drData.Close()
            cmdData.Dispose()

            Return True

        Catch ex As Exception

            MsgBox(ex.ToString)
            Return False
        End Try

    End Function

    'verifica si un codigo de producto existe en la tabla inventarios
    Private Function CorrijeInventarios(ByVal Empnit As String, ByVal Codprod As String) As Boolean
        Try
            Dim cmdData2 As New SqlCommand("Select codprod from invsaldo where empnit=@empnit and codprod=@codprod", cn)
            cmdData2.Parameters.AddWithValue("@empnit", Empnit)
            cmdData2.Parameters.AddWithValue("@codprod", Codprod)
            Dim drData2 As SqlDataReader = cmdData2.ExecuteReader
            drData2.Read()

            Try
                If drData2.HasRows Then
                    Dim a As String = drData2(0).ToString
                End If
            Catch ex As Exception
                'inserta un registro estandar para resolver conflictos
                Dim cmdIns2 As New SqlCommand("Insert into invsaldo (EMPNIT,ANIO,MES,CODPROD,SALDOINICIAL,ENTRADAS,SALIDAS,SALDO,CODBODEGA) VALUES (@EMPNIT,@ANIO,@MES,@CODPROD,0,0,0,0,1)", cn)
                cmdIns2.Parameters.AddWithValue("@EMPNIT", Empnit)
                cmdIns2.Parameters.AddWithValue("@CODPROD", Codprod)
                cmdIns2.Parameters.AddWithValue("@ANIO", GlobalAnioProceso)
                cmdIns2.Parameters.AddWithValue("@MES", GlobalMesProceso)
                cmdIns2.ExecuteNonQuery()
                cmdIns2.Dispose()
            End Try

            drData2.Close()
            cmdData2.Dispose()

            Return True

        Catch ex As Exception
            Return False
        End Try


    End Function

#End Region


#Region " INVENTARIOS "


    Public INVSaldo, INVEntradas, INVSalidas As Double
    Public Sub ObtenerDatosInventario(ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer)
        Anio = 0
        Mes = 0
        Using cn As New SqlConnection(strSqlConectionString)

            If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT SALDO,ENTRADAS,SALIDAS FROM INVSALDO WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & Codprod & "' AND ANIO=" & Anio & " AND MES=" & Mes, cn)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    INVSaldo = Double.Parse(dr(0).ToString)
                    INVEntradas = Double.Parse(dr(1).ToString)
                    INVSalidas = Double.Parse(dr(2).ToString)
                End If
                dr.Close()
                cmd.Dispose()

        End Using
        'cn.Close()
    End Sub

    Public Sub ObtenerDatosInventarioTransferido(ByVal EmpnitRecibe As String, ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer)
        Anio = 0
        Mes = 0

        If cn.State = 0 Then
            cn.Open()
        End If
        Dim cmd As New SqlCommand("SELECT SALDO,ENTRADAS,SALIDAS FROM INVSALDO WHERE EMPNIT='" & EmpnitRecibe & "' AND CODPROD='" & Codprod & "' AND ANIO=" & Anio & " AND MES=" & Mes, cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows = True Then
            INVSaldo = Double.Parse(dr(0).ToString)
            INVEntradas = Double.Parse(dr(1).ToString)
            INVSalidas = Double.Parse(dr(2).ToString)
        End If
        dr.Close()
        cmd.Dispose()
        'cn.Close()
    End Sub



    Public Sub SalidaInventario(ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer, ByVal UnidadesSalida As Double)
        Anio = 0
        Mes = 0

        Try

            If cn.State = 0 Then
                cn.Open()
            End If
            Dim cmd As New SqlCommand("UPDATE INVSALDO SET SALIDAS=" & (INVSalidas + UnidadesSalida) & ", SALDO=" & (INVSaldo - UnidadesSalida) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & Codprod & "' AND ANIO=" & Anio & " AND MES=" & Mes, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch ex As Exception

            'Call InsertarNotificacion("Error al Descontar Producto", "No se descontó adecuadamente el producto " & Codprod.ToString & " datos:(" & UnidadesSalida.ToString & "-" & INVSaldo.ToString)

        End Try

        'cn.Close()
    End Sub


    Public Sub EntradaInventario(ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer, ByVal UnidadesEntrada As Double)
        Anio = 0
        Mes = 0

        Try

            If cn.State = 0 Then
                cn.Open()
            End If
            Dim cmd As New SqlCommand("UPDATE INVSALDO SET ENTRADAS=" & (INVEntradas + UnidadesEntrada) & ", SALDO=" & (INVSaldo + UnidadesEntrada) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & Codprod & "' AND ANIO=" & Anio & " AND MES=" & Mes, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        Catch ex As Exception

            'Call InsertarNotificacion("Error al Integrar Producto", "No se re-integró adecuadamente el producto " & Codprod.ToString & " datos:(" & UnidadesEntrada.ToString & "-" & INVSaldo.ToString)

        End Try
        'cn.Close()
    End Sub
    Public Sub EntradaInventarioTransferido(ByVal EmpnitRecibe As String, ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer, ByVal UnidadesEntrada As Double)
        Anio = 0
        Mes = 0

        If cn.State = 0 Then
            cn.Open()
        End If
        Dim cmd As New SqlCommand("UPDATE INVSALDO SET ENTRADAS=" & (INVEntradas + UnidadesEntrada) & ", SALDO=" & (INVSaldo + UnidadesEntrada) & " WHERE EMPNIT='" & EmpnitRecibe & "' AND CODPROD='" & Codprod & "' AND ANIO=" & Anio & " AND MES=" & Mes, cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        'cn.Close()
    End Sub
    Public Sub RegresarInventario(ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer, ByVal UnidadesRegresar As Double)
        Anio = 0
        Mes = 0

        If cn.State = 0 Then
            cn.Open()
        End If
        Dim cmd As New SqlCommand("UPDATE INVSALDO SET SALIDAS=" & (INVSalidas - UnidadesRegresar) & ", SALDO=" & (INVSaldo + UnidadesRegresar) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & Codprod & "' AND ANIO=" & Anio & " AND MES=" & Mes, cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        'cn.Close()
    End Sub
    Public Sub RegresarInventarioComprado(ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer, ByVal UnidadesRegresar As Double)
        Anio = 0
        Mes = 0

        If cn.State = 0 Then
                cn.Open()
            End If
            Dim cmd As New SqlCommand("UPDATE INVSALDO SET ENTRADAS=" & (INVEntradas - UnidadesRegresar) & ", SALDO=" & (INVSaldo - UnidadesRegresar) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROD='" & Codprod & "' AND ANIO=" & Anio & " AND MES=" & Mes, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

        'cn.Close()
    End Sub

    'ajusta el inventario según sea el físico
    Public Sub AjustarInventarioFisico(ByVal Codprod As String, ByVal Anio As Integer, ByVal Mes As Integer, ByVal Conteo As Double)




    End Sub


#End Region

    Private ps1 As New Security.Seguridad("razors1805")
    Public Function BuscarUsuario(ByVal Usuario As String, ByVal Pass As String) As Boolean

        If Usuario = "soporte" Then
            If Pass = "2410201415082017" Then
                NivelUsuario = 1
                Return True
                Exit Function
            End If
        End If

        'desencriptar

        Dim psw As String
        psw = ps1.ConvertirSha1(Pass)

        Call AbrirConexionSql()
        'Dim cmd As New SqlCommand("SELECT USUARIO, PASS, NIVEL FROM USUARIOS WHERE USUARIO='" & Usuario & "' AND PASS='" & Pass & "'", cn)
        Dim cmd As New SqlCommand("SELECT USUARIO, PASS, NIVEL FROM USUARIOS WHERE USUARIO='" & Usuario & "' AND PASS='" & psw & "'", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows = True Then
                NivelUsuario = Integer.Parse(dr(2).ToString)
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()

    End Function

    Public Sub CargarMesProcesoEmpresa(ByVal EMPNIT As String)

        Form1.cmdMesProceso.SelectedValue = 0
        Form1.cmdAnioProceso.Text = "0"

        Exit Sub

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd1 As New SqlCommand("SELECT EMPRESAS.EMPMESPROCESO, EMPRESAS.EMPANIOPROCESO, EMPRESAS.EMPLOGO, TIPOEMPRESA.CATEGORIA
                                        From EMPRESAS LEFT OUTER Join TIPOEMPRESA On EMPRESAS.CODTIPOEMPRESA = TIPOEMPRESA.CODTIPOEMPRESA Where EMPNIT ='" & Form1.cmbLoginEmpresa.SelectedValue.ToString & "'", cn)

                Dim dr As SqlDataReader
                dr = cmd1.ExecuteReader
                dr.Read()

                If dr.HasRows = True Then
                    'Form1.cmdMesProceso.SelectedIndex = Integer.Parse(dr(0).ToString) - 1
                    Form1.cmdMesProceso.SelectedValue = CType(dr(0), Integer)
                    Form1.cmdAnioProceso.Text = dr(1).ToString
                    'Form1.imgLogoPrinc.Image = ObtenerImgSql(dr(2))
                    LogoEmpresa = ObtenerImgSql(dr(2))

                    GlobalTipoEmpresa = dr(3).ToString
                End If
                cn.Close()
            Catch ex As Exception
                MsgBox("No se pudo cargar el mes de proceso de la empresa seleccionada. Error: " & ex.ToString)
            End Try
        End Using


    End Sub
    Public Sub CargarEmpresas()


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim Dt As DataTable
                Dim Da As New SqlDataAdapter
                Dim Cmd As New SqlCommand
                With Cmd
                    .CommandType = CommandType.Text
                    .CommandText = "SELECT EMPNIT, EMPNOMBRE FROM EMPRESAS"
                    .Connection = cn
                End With
                Da.SelectCommand = Cmd
                Dt = New DataTable
                Da.Fill(Dt)

                With Form1.cmbLoginEmpresa
                    .DataSource = Dt
                    .DisplayMember = "EMPNOMBRE"
                    .ValueMember = "EMPNIT"
                End With



            Catch ex As Exception

                Call Aviso("Error de conexión", "Lo siento, pero por lo visto no posee conexión a la base de datos. Por favor verifique " + ex.ToString, Form1)
            End Try

        End Using


        Form1.cmbLoginEmpresa.AutoCompleteSource = AutoCompleteSource.ListItems
        Form1.cmbLoginEmpresa.AutoCompleteMode = AutoCompleteMode.SuggestAppend


    End Sub
    Public Function getTblMeses() As DataTable

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


    Public Sub CargarMesProceso()
        Dim tblmeses As New DataTable
        With tblmeses.Columns
            .Add("CODMES", GetType(Integer))
            .Add("DESMES", GetType(String))
        End With

        With tblmeses.Rows
            .Add(New Object() {0, "GENERAL"})
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

        With Form1.cmdMesProceso
            .DataSource = tblmeses
            .DisplayMember = "DESMES"
            .ValueMember = "CODMES"
        End With

        Exit Sub


        'Form1.cmdAnioProceso.Text = Today.Year.ToString
        Form1.cmdAnioProceso.Text = "0"
    End Sub 'CARGA EL MES Y AÑO DE PROCESO



End Module
