Imports System.Data.SqlClient
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo

Public Class viewProveedores

    Dim SelectedNomProveedor As String, SelectedNitProveedor As String



    Private Sub viewProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.btnCerrarVentana.Visible = False

        Call CargarGridProveedores()

        Me.txtProveedoresNit.select()

    End Sub

    Private Sub cmdProveedoresCancelarEdit_Click(sender As Object, e As EventArgs) Handles cmdProveedoresCancelarEdit.Click
        Me.txtProveedoresNit.Text = ""
        Me.txtProveedoresEmpresa.Text = ""
        Me.txtProveedoresRazon.Text = ""
        Me.txtProveedoresDireccion.Text = ""
        Me.txtProveedoresTelefonos.Text = ""
        Me.txtProveedoresContacto.Text = ""
        Me.txtProveedoresTelContacto.Text = ""
        Me.txtProveedoresNit.select()
        Me.cmdProveedoresCancelarEdit.Visible = False
        Me.lbProveedoresEditando.Visible = False
        Me.cmdProveedoresGuardar.Visible = True

    End Sub

    Public Sub CargarGridProveedores()
        Me.GridProveedores.DataSource = Nothing

        Dim tbl As New DataTable()
        tbl.Columns.Add("CODPROV", GetType(Integer))
        tbl.Columns.Add("NIT", GetType(String))
        tbl.Columns.Add("EMPRESA", GetType(String))
        tbl.Columns.Add("RAZON", GetType(String))
        tbl.Columns.Add("DIRECCION", GetType(String))
        tbl.Columns.Add("TELEMPRESA", GetType(String))
        tbl.Columns.Add("CONTACTO", GetType(String))
        tbl.Columns.Add("TELCONTACTO", GetType(String))

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT CODPROV,NIT,EMPRESA,RAZONSOCIAL,DIRECCION,TELEMPRESA,CONTACTO,TELCONTACTO FROM PROVEEDORES WHERE EMPNIT='" & GlobalEmpNit & "' ORDER BY CODPROV DESC", cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        Do While dr.Read
            tbl.Rows.Add(New Object() {
                         Integer.Parse(dr(0)),'codprov
                         dr(1).ToString,'nit
                         dr(2).ToString,'empresa
                         dr(3).ToString,'razon
                         dr(4).ToString,'direccion
                         dr(5).ToString,'tel emp
                         dr(6).ToString,'contacto
                         dr(7).ToString'tel contacto
                         })
        Loop
        dr.Close()
        cmd.Dispose()
        cn.Close()

        Me.GridProveedores.DataSource = tbl

        TryCast(TileViewProveedores.TileTemplate(0), TileViewItemElement).Column = TileViewProveedores.Columns("NIT")
        TryCast(TileViewProveedores.TileTemplate(1), TileViewItemElement).Column = TileViewProveedores.Columns("EMPRESA")
        TryCast(TileViewProveedores.TileTemplate(2), TileViewItemElement).Column = TileViewProveedores.Columns("RAZON")
        TryCast(TileViewProveedores.TileTemplate(3), TileViewItemElement).Column = TileViewProveedores.Columns("DIRECCION")
        TryCast(TileViewProveedores.TileTemplate(4), TileViewItemElement).Column = TileViewProveedores.Columns("TELEMPRESA")
        TryCast(TileViewProveedores.TileTemplate(5), TileViewItemElement).Column = TileViewProveedores.Columns("CONTACTO")
        TryCast(TileViewProveedores.TileTemplate(6), TileViewItemElement).Column = TileViewProveedores.Columns("TELCONTACTO")

    End Sub

    Private Sub TileViewProveedores_DoubleClick(sender As Object, e As EventArgs) Handles TileViewProveedores.DoubleClick
        Dim mouseArgs As MouseEventArgs = TryCast(e, MouseEventArgs)
        Dim hitInfo As TileViewHitInfo = TileViewProveedores.CalcHitInfo(mouseArgs.Location)
        Dim vc As New viewCompras

        If hitInfo.InItem Then
            SelectedCode = Integer.Parse(TileViewProveedores.GetRowCellValue(hitInfo.RowHandle, "CODPROV").ToString)
            SelectedNomProveedor = TileViewProveedores.GetRowCellValue(hitInfo.RowHandle, "EMPRESA").ToString
            SelectedNitProveedor = TileViewProveedores.GetRowCellValue(hitInfo.RowHandle, "NIT").ToString

            If SelectedForm = "PROVEEDORES" Then
                Me.RadMenProveedores.ShowPopup(MousePosition)
            Else
                vc.cmbComprasProveedor.Text = SelectedCode.ToString
                vc.txtComprasNitProveedor.Text = SelectedNitProveedor.ToString
                vc.txtComprasNombreProveedor.Text = SelectedNomProveedor.ToString

                globalProv = SelectedCode.ToString
                globalNitProv = SelectedNitProveedor.ToString
                globalDesProv = SelectedNomProveedor.ToString

                Me.btnAceptarTrue.PerformClick()
            End If

        End If

    End Sub

    Private Sub txtProveedoresNit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedoresNit.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProveedoresEmpresa.select()
        End If
    End Sub

    Private Sub txtProveedoresEmpresa_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedoresEmpresa.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtProveedoresRazon.Text <> "" Then
            Else
                Me.txtProveedoresRazon.Text = Me.txtProveedoresEmpresa.Text
            End If

            Me.txtProveedoresRazon.select()
        End If
    End Sub

    Private Sub txtProveedoresRazon_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedoresRazon.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProveedoresDireccion.select()
        End If
    End Sub

    Private Sub txtProveedoresDireccion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedoresDireccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProveedoresTelefonos.select()
        End If
    End Sub

    Private Sub txtProveedoresTelefonos_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedoresTelefonos.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProveedoresContacto.select()
        End If
    End Sub

    Private Sub txtProveedoresContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedoresContacto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtProveedoresTelContacto.select()
        End If
    End Sub

    Private Sub txtProveedoresTelContacto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedoresTelContacto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdProveedoresGuardar.select()
        End If
    End Sub

    Private Sub cmdProveedoresGuardar_Click(sender As Object, e As EventArgs) Handles cmdProveedoresGuardar.Click
        If Me.txtProveedoresNit.Text <> "" Then
        Else
            Me.txtProveedoresNit.Text = "CF"
        End If
        If Me.txtProveedoresEmpresa.Text <> "" Then
            If Me.txtProveedoresRazon.Text <> "" Then
            Else
                Me.txtProveedoresRazon.Text = Me.txtProveedoresEmpresa.Text
            End If
            If Me.txtProveedoresDireccion.Text <> "" Then
            Else
                Me.txtProveedoresDireccion.Text = "Ciudad"
            End If
            If Me.txtProveedoresTelefonos.Text <> "" Then
            Else
                Me.txtProveedoresTelefonos.Text = "SN"
            End If
            If Me.txtProveedoresContacto.Text <> "" Then
            Else
                Me.txtProveedoresContacto.Text = "SN"
            End If
            If Me.txtProveedoresTelContacto.Text <> "" Then
            Else
                Me.txtProveedoresTelContacto.Text = "SN"
            End If

            If Confirmacion("¿Está seguro que desea guardar este Proveedor?", Me.ParentForm) = True Then

                Call AbrirConexionSql()

                Dim sql As String
                If Me.cmdProveedoresCancelarEdit.Visible = True Then
                    sql = "UPDATE PROVEEDORES SET NIT=@NIT,EMPRESA=@EMPRESA,RAZONSOCIAL=@RAZONSOCIAL,DIRECCION=@DIRECCION,TELEMPRESA=@TELEMPRESA,CONTACTO=@CONTACTO,TELCONTACTO=@TELCONTACTO WHERE EMPNIT=@EMPNIT AND CODPROV=" & SelectedCode
                Else
                    sql = "INSERT INTO PROVEEDORES (EMPNIT,NIT,EMPRESA,RAZONSOCIAL,DIRECCION,TELEMPRESA,CONTACTO,TELCONTACTO,SALDO) VALUES (@EMPNIT,@NIT,@EMPRESA,@RAZONSOCIAL,@DIRECCION,@TELEMPRESA,@CONTACTO,@TELCONTACTO,0)"
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@NIT", Me.txtProveedoresNit.Text)
                cmd.Parameters.AddWithValue("@EMPRESA", Me.txtProveedoresEmpresa.Text)
                cmd.Parameters.AddWithValue("@RAZONSOCIAL", Me.txtProveedoresRazon.Text)
                cmd.Parameters.AddWithValue("@DIRECCION", Me.txtProveedoresDireccion.Text)
                cmd.Parameters.AddWithValue("@TELEMPRESA", Me.txtProveedoresTelefonos.Text)
                cmd.Parameters.AddWithValue("@CONTACTO", Me.txtProveedoresContacto.Text)
                cmd.Parameters.AddWithValue("@TELCONTACTO", Me.txtProveedoresTelContacto.Text)
                cmd.ExecuteNonQuery()

                cmd.Dispose()
                cn.Close()

                Me.txtProveedoresNit.Text = ""
                Me.txtProveedoresEmpresa.Text = ""
                Me.txtProveedoresRazon.Text = ""
                Me.txtProveedoresDireccion.Text = ""
                Me.txtProveedoresTelefonos.Text = ""
                Me.txtProveedoresContacto.Text = ""
                Me.txtProveedoresTelContacto.Text = ""
                Me.txtProveedoresNit.select()
                Me.cmdProveedoresCancelarEdit.Visible = False
                Me.lbProveedoresEditando.Visible = False

                Call CargarGridProveedores()



                Call Form1.Mensaje("Proveedor guardado exitosamente")

            End If
        Else
            Call Aviso("Incompleto", "Es necesario escribir el nombre de la Empresa", Me.ParentForm)
        End If

    End Sub



    Private Sub cmdRadMenProveedoresEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Me.lbProveedoresEditando.Visible = True
        Me.cmdProveedoresCancelarEdit.Visible = True
        Me.cmdProveedoresGuardar.Visible = True
        Call ObtenerDatosProveedor(SelectedCode)
        Me.txtProveedoresNit.select()
    End Sub



    Private Sub ObtenerDatosProveedor(ByVal CodProv As Integer)
        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT CODPROV,NIT,EMPRESA,RAZONSOCIAL,DIRECCION,TELEMPRESA,CONTACTO,TELCONTACTO FROM PROVEEDORES WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROV=" & SelectedCode, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            Me.txtProveedoresNit.Text = dr(1).ToString
            Me.txtProveedoresEmpresa.Text = dr(2).ToString
            Me.txtProveedoresRazon.Text = dr(3).ToString
            Me.txtProveedoresDireccion.Text = dr(4).ToString
            Me.txtProveedoresTelefonos.Text = dr(5).ToString
            Me.txtProveedoresContacto.Text = dr(6).ToString
            Me.txtProveedoresTelContacto.Text = dr(7).ToString
        Catch ex As Exception

        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()

    End Sub


    Private Sub cmdRadMenProveedoresCompras_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick

        Call AbrirReporte_ComprasProveedor(0, 0, SelectedNitProveedor)
        'Call AbrirReporte_ComprasProveedor(Integer.Parse(Me.cmdAnioProceso.Text), Integer.Parse(Me.cmdMesProceso.SelectedValue), SelectedNitProveedor)
    End Sub

    Private Sub btnAceptarTrue_Click(sender As Object, e As EventArgs) Handles btnAceptarTrue.Click

    End Sub

    Private Sub cmdRadMenProveedoresEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        If Confirmacion("¿Está seguro que desea eliminar este proveedor?", Me.ParentForm) = True Then
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("DELETE FROM PROVEEDORES WHERE EMPNIT='" & GlobalEmpNit & "' AND CODPROV=" & SelectedCode, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            'Call Form1.EnviarNotificacionesEmail(0, "ARES te informa: Eliminación de Proveedor", "Se ha eliminado al proveedor " & SelectedCode & " - " & SelectedNomProveedor)

            Call CargarGridProveedores()
            Me.txtProveedoresNit.select()
        End If

    End Sub

End Class
