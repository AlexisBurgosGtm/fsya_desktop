Imports System.Data.SqlClient

Imports DevExpress.Data.Mask
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class ViewMantenimientos
    Private Sub ViewMantenimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.GridMantenimientos.DataSource = Nothing
        Me.GroupMantenientos.Text = "Seleccione un Catálogo"
        Me.txtMantenimientosCodigo.select()
    End Sub


    Private Sub cmdMantenimientosCajas_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosCajas.Click
        Me.GroupMantenientos.Text = "Cajas"
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.Numeric 'cambia las propiedades del control textedit para que acepte solo numeros
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub

    Private Sub cmdMantenimientosBodegas_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosBodegas.Click
        Me.GroupMantenientos.Text = "Bodegas"
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.Numeric 'cambia las propiedades del control textedit para que acepte solo numeros
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub

    Private Sub cmdMantenimientosMarcas_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosMarcas.Click
        Me.GroupMantenientos.Text = "Marcas"
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.Numeric 'cambia las propiedades del control textedit para que acepte solo numeros
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub

    Private Sub cmdMantenimientosMedidas_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosMedidas.Click
        Me.GroupMantenientos.Text = "Medidas"
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.None
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub



    Private Sub cmdMantenimientosClaseUno_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosClaseUno.Click
        Me.GroupMantenientos.Text = "Clasificación Uno"
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.Numeric
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub

    Private Sub cmdMantenimientosClaseDos_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosClaseDos.Click
        Me.GroupMantenientos.Text = "Clasificación Dos"
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.Numeric
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub



    Private Sub cmdMantenimientosClaseTres_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosClaseTres.Click
        Me.GroupMantenientos.Text = "Clasificación Dos" ' clasificacion 3
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.Numeric
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub



    Private Sub cmdMantenimientosRutas_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosRutas.Click
        Me.GroupMantenientos.Text = "Grupos"
        Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

        Me.txtMantenimientosCodigo.Properties.Mask.MaskType = Mask.MaskType.Numeric
        Me.txtMantenimientosCodigo.Properties.Mask.EditMask = "n0"
        Me.txtMantenimientosCodigo.Text = ""

        Me.txtMantenimientosCodigo.select()
    End Sub


    Private Sub txtMantenimientosCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMantenimientosCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtMantenimientosDescripcion.select()
        End If
    End Sub



    Private Sub txtMantenimientosDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMantenimientosDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdMantenimientosGuardar.select()
        End If
    End Sub



    Private Sub cmdMantenimientosGuardar_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosGuardar.Click

        If Me.GroupMantenientos.Text = "Seleccione un Catálogo" Then
            Call Form1.Mensaje("Seleccione una Categoría antes de intentar guardar")
            Exit Sub
        End If

        If Me.txtMantenimientosCodigo.Text <> "" Then
            If Me.txtMantenimientosDescripcion.Text <> "" Then

                If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                    GoTo PROCEDE
                Else
                    If ExisteCodigoMantenimientos(Me.txtMantenimientosCodigo.Text) = True Then
                        Call Aviso("IMPOSIBLE", "Este código ya existe, utilice otro", Me.ParentForm)
                        Exit Sub
                    Else
                        GoTo PROCEDE
                    End If
                End If
                'VERIFICA SI YA EXISTE EL CODIGO DEL CATALOGO


PROCEDE:

                If Confirmacion("¿Está seguro que desea guardar este Item?", Me.ParentForm) = True Then
                    Dim sql As String
                    Dim codigo As Object
                    Select Case Me.GroupMantenientos.Text

                        Case "Cajas"
                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE CAJAS SET DESCAJA=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODCAJA=@CODIGO"
                            Else
                                sql = "INSERT INTO CAJAS (EMPNIT,CODCAJA,DESCAJA,STATUS,LASTUPDATE) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION,0,@LU)"
                            End If

                            codigo = Integer.Parse(Me.txtMantenimientosCodigo.Text)

                        Case "Bodegas"
                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE BODEGAS SET DESBODEGA=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODBODEGA=@CODIGO"
                            Else
                                sql = "INSERT INTO BODEGAS (EMPNIT,CODBODEGA,DESBODEGA) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION)"
                            End If

                            codigo = Integer.Parse(Me.txtMantenimientosCodigo.Text)

                        Case "Marcas"
                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE MARCAS SET DESMARCA=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODMARCA=@CODIGO"
                            Else
                                sql = "INSERT INTO MARCAS (EMPNIT,CODMARCA,DESMARCA) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION)"
                            End If

                            codigo = Integer.Parse(Me.txtMantenimientosCodigo.Text)

                        Case "Medidas"

                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE MEDIDAS SET TIPOPRECIO=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODMEDIDA=@CODIGO"
                            Else
                                sql = "INSERT INTO MEDIDAS (EMPNIT,CODMEDIDA,TIPOPRECIO) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION)"
                            End If

                            codigo = Me.txtMantenimientosCodigo.Text

                        Case "Clasificación Uno"
                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE CLASIFICACIONUNO SET DESCLAUNO=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODCLAUNO=@CODIGO"
                            Else
                                sql = "INSERT INTO CLASIFICACIONUNO (EMPNIT,CODCLAUNO,DESCLAUNO) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION)"
                            End If

                            codigo = Integer.Parse(Me.txtMantenimientosCodigo.Text)

                        Case "Clasificación Dos"
                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE CLASIFICACIONDOS SET DESCLADOS=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODCLADOS=@CODIGO"
                            Else
                                sql = "INSERT INTO CLASIFICACIONDOS (EMPNIT,CODCLADOS,DESCLADOS) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION)"
                            End If

                            codigo = Integer.Parse(Me.txtMantenimientosCodigo.Text)

                        Case "Clasificación Tres"
                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE CLASIFICACIONTRES SET DESCLATRES=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODCLATRES=@CODIGO"
                            Else
                                sql = "INSERT INTO CLASIFICACIONTRES (EMPNIT,CODCLATRES,DESCLATRES) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION)"
                            End If
                            codigo = Integer.Parse(Me.txtMantenimientosCodigo.Text)

                        Case "Grupos"
                            If Me.cmdMantenimientosCancelarEdit.Visible = True Then
                                sql = "UPDATE RUTAS SET DESRUTA=@DESCRIPCION WHERE EMPNIT=@EMPNIT AND CODRUTA=@CODIGO"
                            Else
                                sql = "INSERT INTO RUTAS (EMPNIT,CODRUTA,DESRUTA) VALUES (@EMPNIT,@CODIGO,@DESCRIPCION)"
                            End If

                            codigo = Integer.Parse(Me.txtMantenimientosCodigo.Text)
                    End Select

                    Call AbrirConexionSql()

                    If Form1.SwitchConfigInternet.IsOn = True Then
                        'si el switch está activado se ejecuta la rutina en todas las empresas
                        Dim cmdEmp As New SqlCommand("SELECT EMPNIT FROM EMPRESAS", cn)
                        Dim drEmp As SqlDataReader = cmdEmp.ExecuteReader

                        Do While drEmp.Read
                            Dim cmd As New SqlCommand(sql, cn)
                            cmd.Parameters.AddWithValue("@EMPNIT", drEmp(0).ToString)
                            cmd.Parameters.AddWithValue("@CODIGO", codigo)
                            cmd.Parameters.AddWithValue("@DESCRIPCION", Me.txtMantenimientosDescripcion.Text)
                            If Me.GroupMantenientos.Text = "Cajas" Then
                                cmd.Parameters.AddWithValue("@LU", Today.Date)
                            End If
                            cmd.ExecuteNonQuery()
                            cmd.Dispose()
                        Loop
                        drEmp.Close()
                        cmdEmp.Dispose()

                        'Call CargarRutasClientes()
                    Else
                        'de lo contrario, lo ejecuta en la empresa seleccionada
                        Dim cmd As New SqlCommand(sql, cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODIGO", codigo)
                        cmd.Parameters.AddWithValue("@DESCRIPCION", Me.txtMantenimientosDescripcion.Text)
                        If Me.GroupMantenientos.Text = "Cajas" Then
                            cmd.Parameters.AddWithValue("@LU", Today.Date)
                        End If
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()


                        'Call Form1.CargarRutasClientes()
                    End If

                    Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

                    'If Me.GroupMantenientos.Text = "Grupos" Then Call Form1.CargarRutasClientes()

                    Me.txtMantenimientosCodigo.Text = ""
                    Me.txtMantenimientosDescripcion.Text = ""

                    Me.cmdMantenimientosCancelarEdit.Visible = False
                    Me.txtMantenimientosCodigo.Enabled = True

                    Me.txtMantenimientosCodigo.select()

                End If

                'termina el procede

            Else
                Call Aviso("IMPORTANTE", "Debe escribir una Descripción", Me.ParentForm)
            End If
        Else
            Call Aviso("IMPORTANTE", "Debe escribir un código", Me.ParentForm)
        End If

    End Sub

    Private Sub cmdMantenimientosCancelarEdit_Click(sender As Object, e As EventArgs) Handles cmdMantenimientosCancelarEdit.Click

        Me.GridMantenimientos.DataSource = Nothing

        Me.txtMantenimientosCodigo.Text = ""
        Me.txtMantenimientosDescripcion.Text = ""
        Me.txtMantenimientosCodigo.Enabled = True

        Me.cmdMantenimientosGuardar.Visible = True
        Me.cmdMantenimientosCancelarEdit.Visible = False

        Me.txtMantenimientosCodigo.select()
    End Sub

    Private Sub CargarGridMantenimientos(ByVal Tipo As String)
        Dim tbl As New DataTable
        With tbl.Columns
            .Add("CODIGO", GetType(String))
            .Add("DESCRIPCION", GetType(String))
        End With

        Me.GridMantenimientos.DataSource = Nothing

        Dim sql As String

        Select Case Tipo
            Case "Cajas"
                sql = "SELECT CODCAJA, DESCAJA FROM CAJAS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODCAJA ASC"
            Case "Bodegas"
                sql = "SELECT CODBODEGA, DESBODEGA FROM BODEGAS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODBODEGA ASC"
            Case "Marcas"
                sql = "SELECT CODMARCA, DESMARCA FROM MARCAS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODMARCA ASC"
            Case "Medidas"
                sql = "SELECT CODMEDIDA, TIPOPRECIO FROM MEDIDAS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODMEDIDA ASC"
            Case "Clasificación Uno"
                sql = "SELECT CODCLAUNO, DESCLAUNO FROM CLASIFICACIONUNO WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODCLAUNO ASC"
            Case "Clasificación Dos"
                sql = "SELECT CODCLADOS, DESCLADOS FROM CLASIFICACIONDOS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODCLADOS ASC"
            Case "Clasificación Tres"
                sql = "SELECT CODCLATRES, DESCLATRES FROM CLASIFICACIONTRES WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODCLATRES ASC"
            Case "Grupos"
                sql = "SELECT CODRUTA, DESRUTA FROM RUTAS WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODRUTA ASC"
        End Select

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand(sql, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Do While dr.Read
            Try
                tbl.Rows.Add(New Object() {
                dr(0), 'codigo
                dr(1).ToString 'descripcion             
            })

            Catch ex As Exception

            End Try
        Loop
        dr.Close()
        cmd.Dispose()

        cn.Close()

        Me.GridMantenimientos.DataSource = tbl

        TryCast(TileViewMantenimientos.TileTemplate(0), TileViewItemElement).Column = TileViewMantenimientos.Columns("CODIGO")
        TryCast(TileViewMantenimientos.TileTemplate(1), TileViewItemElement).Column = TileViewMantenimientos.Columns("DESCRIPCION")

        If Tipo = "Medidas" Then
            TryCast(TileViewMantenimientos.TileTemplate(2), TileViewItemElement).Text = "Medida:"
            TryCast(TileViewMantenimientos.TileTemplate(3), TileViewItemElement).Text = "Tipo:"
        Else
            TryCast(TileViewMantenimientos.TileTemplate(2), TileViewItemElement).Text = "Código:"
            TryCast(TileViewMantenimientos.TileTemplate(3), TileViewItemElement).Text = "Descripción:"
        End If

    End Sub


    'radial menu mantenimientos
    Dim SelectedCodMedida As String



    Private Sub TileViewMantenimientos_DoubleClick(sender As Object, e As EventArgs) Handles TileViewMantenimientos.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewMantenimientos.CalcHitInfo(mouseArgs.Location)

        If hitInfo.InItem Then
            If Me.GroupMantenientos.Text = "Medidas" Then
                SelectedCodMedida = TileViewMantenimientos.GetRowCellValue(hitInfo.RowHandle, "CODIGO").ToString
            Else
                SelectedCode = Integer.Parse(TileViewMantenimientos.GetRowCellValue(hitInfo.RowHandle, "CODIGO").ToString)
            End If

            Me.RadMenMantenimientos.ShowPopup(MousePosition)
        End If
    End Sub

    Private Sub cmdRadMenMantenimientosEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRadMenMantenimientosEditar.ItemClick

        If Me.GroupMantenientos.Text = "Medidas" Then
            Call ObtenerDatosMantenimiento(SelectedCodMedida)
        Else
            Call ObtenerDatosMantenimiento(SelectedCode)
        End If

        Me.cmdMantenimientosCancelarEdit.Visible = True
        Me.txtMantenimientosCodigo.Enabled = False
        Me.txtMantenimientosDescripcion.select()

    End Sub

    Private Sub cmdRadMenMantenimientosEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles cmdRadMenMantenimientosEliminar.ItemClick
        If Confirmacion("¿Está seguro que desea Eliminar este Item", Me.ParentForm) = True Then

            If FlyoutDialog.Show(Me.ParentForm, New ViewClave(Form1.txtConfigClaveVerificaExistencia.Text)) = DialogResult.OK Then

                Dim sql As String

                If Form1.SwitchConfigInternet.IsOn = True Then
                    Select Case Me.GroupMantenientos.Text
                        Case "Cajas"
                            sql = "DELETE FROM CAJAS WHERE CODCAJA='" & SelectedCodMedida & "'"
                        Case "Bodegas"
                            sql = "DELETE FROM BODEGAS WHERE CODBODEGA=" & SelectedCode
                        Case "Medidas"
                            sql = "DELETE FROM MEDIDAS WHERE CODMEDIDA='" & SelectedCodMedida & "'"
                        Case "Marcas"
                            sql = "DELETE FROM MARCAS WHERE CODMARCA=" & SelectedCode
                        Case "Clasificación Uno"
                            sql = "DELETE FROM CLASIFICACIONUNO WHERE CODCLAUNO=" & SelectedCode
                        Case "Clasificación Dos"
                            sql = "DELETE FROM CLASIFICACIONDOS WHERE CODCLADOS=" & SelectedCode
                        Case "Clasificación Tres"
                            sql = "DELETE FROM CLASIFICACIONTRES WHERE CODCLATRES=" & SelectedCode
                        Case "Grupos"
                            sql = "DELETE FROM RUTAS WHERE CODRUTA=" & SelectedCode
                    End Select
                Else
                    Select Case Me.GroupMantenientos.Text
                        Case "Cajas"
                            sql = "DELETE FROM CAJAS WHERE CODCAJA=" & SelectedCode & " AND EMPNIT='" & GlobalEmpNit & "'"
                        Case "Bodegas"
                            sql = "DELETE FROM BODEGAS WHERE CODBODEGA=" & SelectedCode & " AND EMPNIT='" & GlobalEmpNit & "'"
                        Case "Medidas"
                            sql = "DELETE FROM MEDIDAS WHERE CODMEDIDA='" & SelectedCodMedida & "' AND EMPNIT='" & GlobalEmpNit & "'"
                        Case "Marcas"
                            sql = "DELETE FROM MARCAS WHERE CODMARCA=" & SelectedCode & " AND EMPNIT='" & GlobalEmpNit & "'"
                        Case "Clasificación Uno"
                            sql = "DELETE FROM CLASIFICACIONUNO WHERE CODCLAUNO=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
                        Case "Clasificación Dos"
                            sql = "DELETE FROM CLASIFICACIONDOS WHERE CODCLADOS=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
                        Case "Clasificación Tres"
                            sql = "DELETE FROM CLASIFICACIONTRES WHERE CODCLATRES=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
                        Case "Grupos"
                            sql = "DELETE FROM RUTAS WHERE CODRUTA=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
                    End Select
                End If


                Call AbrirConexionSql()
                Dim cmd As New SqlCommand(sql, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                cn.Close()

                Call CargarGridMantenimientos(Me.GroupMantenientos.Text)

            End If

        End If


    End Sub

    Private Sub ObtenerDatosMantenimiento(ByVal Codigo As Object)

        Dim sql As String

        Select Case Me.GroupMantenientos.Text
            Case "Cajas"
                sql = "SELECT CODCAJA, DESCAJA FROM CAJAS WHERE CODCAJA=" & SelectedCode & " AND EMPNIT='" & GlobalEmpNit & "'"
            Case "Bodegas"
                sql = "SELECT CODBODEGA, DESBODEGA FROM BODEGAS WHERE CODBODEGA=" & SelectedCode & " AND EMPNIT='" & GlobalEmpNit & "'"
            Case "Medidas"
                sql = "SELECT CODMEDIDA, TIPOPRECIO FROM MEDIDAS WHERE CODMEDIDA='" & SelectedCodMedida & "' AND EMPNIT='" & GlobalEmpNit & "'"
            Case "Marcas"
                sql = "SELECT CODMARCA, DESMARCA FROM MARCAS WHERE CODMARCA=" & SelectedCode & " AND EMPNIT='" & GlobalEmpNit & "'"
            Case "Clasificación Uno"
                sql = "SELECT CODCLAUNO, DESCLAUNO FROM CLASIFICACIONUNO WHERE CODCLAUNO=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
            Case "Clasificación Dos"
                sql = "SELECT CODCLADOS, DESCLADOS FROM CLASIFICACIONDOS WHERE CODCLADOS=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
            Case "Clasificación Tres"
                sql = "SELECT CODCLATRES, DESCLATRES FROM CLASIFICACIONTRES WHERE CODCLATRES=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
            Case "Grupos"
                sql = "SELECT CODRUTA, DESRUTA FROM RUTAS WHERE CODRUTA=" & SelectedCode & " AND  EMPNIT='" & GlobalEmpNit & "'"
        End Select


        Call AbrirConexionSql()
        Dim cmd As New SqlCommand(sql, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                Me.txtMantenimientosCodigo.Text = dr(0)
                Me.txtMantenimientosDescripcion.Text = dr(1).ToString
            End If
        Catch ex As Exception

        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()

    End Sub

    Private Function ExisteCodigoMantenimientos(ByVal Codigo As Object) As Boolean

        Dim sql As String

        Select Case Me.GroupMantenientos.Text

            Case "Cajas"

                sql = "SELECT CODCAJA FROM CAJAS WHERE CODCAJA=" & Integer.Parse(Codigo) & " AND EMPNIT='" & GlobalEmpNit & "'"

            Case "Bodegas"

                sql = "SELECT CODBODEGA FROM BODEGAS WHERE CODBODEGA=" & Integer.Parse(Codigo) & " AND EMPNIT='" & GlobalEmpNit & "'"

            Case "Medidas"
                sql = "SELECT CODMEDIDA FROM MEDIDAS WHERE CODMEDIDA='" & Codigo.ToString & "' AND EMPNIT='" & GlobalEmpNit & "'"

            Case "Marcas"

                sql = "SELECT CODMARCA FROM MARCAS WHERE CODMARCA=" & Integer.Parse(Codigo) & " AND EMPNIT='" & GlobalEmpNit & "'"

            Case "Clasificación Uno"

                sql = "SELECT CODCLAUNO FROM CLASIFICACIONUNO WHERE CODCLAUNO=" & Integer.Parse(Codigo) & " AND  EMPNIT='" & GlobalEmpNit & "'"

            Case "Clasificación Dos"

                sql = "SELECT CODCLADOS FROM CLASIFICACIONDOS WHERE CODCLADOS=" & Integer.Parse(Codigo) & " AND  EMPNIT='" & GlobalEmpNit & "'"

            Case "Clasificación Tres"

                sql = "SELECT CODCLATRES FROM CLASIFICACIONTRES WHERE CODCLATRES=" & Integer.Parse(Codigo) & " AND  EMPNIT='" & GlobalEmpNit & "'"

            Case "Grupos"

                sql = "SELECT CODRUTA FROM RUTAS WHERE CODRUTA=" & Integer.Parse(Codigo) & " AND  EMPNIT='" & GlobalEmpNit & "'"
        End Select

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand(sql, cn)
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



End Class
