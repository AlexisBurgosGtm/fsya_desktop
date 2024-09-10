Imports System.Data.SqlClient

Public Class viewGastos

    Dim coddocGasto As String = "GASTOS"

    Private Sub viewGastos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtGastosFecha.DateTime = Today.Date
        Call CargarCombobox()

        Call CargarCorrelativoGastos()

        Call CargarTempGastos()

        'Call CargarTotalGasto()

        Me.cmbGastosTipo.select()

    End Sub

    Private Sub CargarCombobox()
        'TIPOS DE GASTO
        Dim Dt5 As DataTable
        Dim Da5 As New SqlDataAdapter
        Dim Cmd5 As New SqlCommand
        With Cmd5
            .CommandType = CommandType.Text
            .CommandText = "SELECT CODMEDIDA, DESTIPOGASTO FROM TIPOGASTOS"
            .Connection = cn
        End With
        Da5.SelectCommand = Cmd5
        Dt5 = New DataTable
        Da5.Fill(Dt5)

        With cmbGastosTipo
            .DataSource = Dt5
            .DisplayMember = "DESTIPOGASTO"
            .ValueMember = "CODMEDIDA"
        End With




        Dim objC As New classCorteCaja
        Dim tbc As DataTable = objC.getCajas(1)
        With Me.cmbCajas
            .DataSource = tbc
            .ValueMember = "CODCAJA"
            .DisplayMember = "DESCAJA"
        End With

        If tbc.Rows.Count > 0 Then
            Me.cmbCajas.SelectedValue = GlobalSelectedCodCaja
        End If

    End Sub

    Private Sub CargarTempGastos()
        Dim tbl As New DataTable()
        tbl.Columns.Add("ID", GetType(Integer))
        tbl.Columns.Add("TIPOGASTO", GetType(String))
        tbl.Columns.Add("DESCRIPCION", GetType(String))
        tbl.Columns.Add("IMPORTE", GetType(String))

        Dim varTotalGasto As Double = 0

        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT TEMP_VENTAS.ID, TIPOGASTOS.DESTIPOGASTO AS TIPOGASTO, TEMP_VENTAS.DESPROD AS DESGASTO, TEMP_VENTAS.TOTALCOSTO AS IMPORTE
                                   FROM TEMP_VENTAS LEFT OUTER JOIN TIPOGASTOS ON TEMP_VENTAS.CODMEDIDA = TIPOGASTOS.CODMEDIDA
                                   WHERE (TEMP_VENTAS.EMPNIT = @E) AND (TEMP_VENTAS.CODDOC = @D) AND (TEMP_VENTAS.CORRELATIVO =@N)", cn)
        cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
        cmd.Parameters.AddWithValue("@D", coddocGasto)
        cmd.Parameters.AddWithValue("@N", Double.Parse(Me.txtGastosCorrelativo.Text))
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        Do While dr.Read
            varTotalGasto = varTotalGasto + Double.Parse(dr(3))
            tbl.Rows.Add(New Object() {
                         Integer.Parse(dr(0).ToString),
                         dr(1).ToString,
                         dr(2).ToString,
                         FormatCurrency(dr(3)).ToString
                         })
        Loop
        cmd.Dispose()
        dr.Close()
        cn.Close()


        Me.DGVGastosTemp.DataSource = tbl
        Me.DGVGastosTemp.Columns(0).Visible = False
        Me.DGVGastosTemp.Columns(1).Width = 120
        Me.DGVGastosTemp.Columns(2).Width = 210
        Me.DGVGastosTemp.Columns(3).Width = 85

        'Call CargarTotalGasto()
        Me.LbGastosTotalGasto.Text = FormatNumber(varTotalGasto, 2)

    End Sub

    Private Sub cmbGastosTipo_Leave(sender As Object, e As EventArgs) Handles cmbGastosTipo.Leave

        If Me.cmbGastosTipo.Text = "GASTOS NARANJA" Then
            Me.txtGastosDescripcion.Text = "SN"
            Me.txtGastosDescripcion.Enabled = False
        Else
            Me.txtGastosDescripcion.Enabled = True
        End If


    End Sub

    Private Sub cmbGastosTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbGastosTipo.KeyDown
        If e.KeyCode = Keys.Enter Then

            If Me.cmbGastosTipo.Text = "GASTOS NARANJA" Then
                Me.txtGastosDescripcion.Enabled = False
            Else
                Me.txtGastosDescripcion.Enabled = True
                Me.txtGastosDescripcion.select()
            End If

            Me.txtGastosDescripcion.Enabled = True
            Me.txtGastosDescripcion.select()
        End If
    End Sub

    Private Sub txtGastosDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGastosDescripcion.KeyDown

        If Me.cmbGastosTipo.Text = "GASTOS NARANJA" Then
            Me.txtGastosDescripcion.Enabled = False
        Else
            Me.txtGastosDescripcion.Enabled = True
            If e.KeyCode = Keys.Enter Then
                Me.txtGastosImporte.select()
            End If

        End If

    End Sub

    Private Sub DGVGastosTemp_DoubleClick(sender As Object, e As EventArgs) Handles DGVGastosTemp.DoubleClick
        If Confirmacion("¿Está seguro que desea eliminar este item de la lista?", Me.ParentForm) = True Then
            Dim id As Integer
            id = Integer.Parse(Me.DGVGastosTemp.Item(0, Me.DGVGastosTemp.CurrentRow.Index).Value.ToString)
            Call AbrirConexionSql()
            Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE ID=" & id, cn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Close()
            Call CargarTempGastos()
        End If


    End Sub

    Private Sub txtGastosImporte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGastosImporte.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdGastosAgregar.select()
        End If
    End Sub

    Private Sub cmdGastosAgregar_Click(sender As Object, e As EventArgs) Handles cmdGastosAgregar.Click
        If Me.cmbGastosTipo.SelectedIndex >= 0 Then
        Else
            MsgBox("Seleccione el tipo de gasto")
            Exit Sub
        End If

        If Me.cmbGastosTipo.Text <> "" Then
            If Me.txtGastosDescripcion.Text <> "" Then
                If Me.txtGastosImporte.Text <> "" Then

                    Dim x As Integer
                    x = MsgBox("¿Está seguro que desea agregar este item?", MsgBoxStyle.OkCancel, "Confirme")
                    If x = MsgBoxResult.Ok Then
                        Call AbrirConexionSql()
                        Dim cmd As New SqlCommand("INSERT INTO TEMP_VENTAS (EMPNIT,CODDOC,CORRELATIVO,CODMEDIDA,DESPROD,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,CODPROD,EQUIVALE,CANTIDAD,USUARIO) VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODMEDIDA,@DESPROD,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@CODPROD,@EQUIVALE,@CANTIDAD,@USUARIO)", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@CODDOC", coddocGasto)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtGastosCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@CODMEDIDA", Me.cmbGastosTipo.SelectedValue.ToString)
                        cmd.Parameters.AddWithValue("@DESPROD", Me.txtGastosDescripcion.Text)
                        cmd.Parameters.AddWithValue("@COSTO", Double.Parse(Me.txtGastosImporte.Text))
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtGastosImporte.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtGastosImporte.Text))
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtGastosImporte.Text))
                        cmd.Parameters.AddWithValue("@CODPROD", "0")
                        cmd.Parameters.AddWithValue("@EQUIVALE", 0)
                        cmd.Parameters.AddWithValue("@CANTIDAD", 0)
                        cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()

                        Call CargarTempGastos()

                        Me.txtGastosDescripcion.Text = ""
                        Me.txtGastosImporte.Text = "0.00"
                        Me.cmbGastosTipo.select()
                    End If

                Else
                    Call Form1.Mensaje("Escriba el monto del gasto")
                End If
            Else
                Call Form1.Mensaje("Escriba la descripción del gasto")
            End If
        Else
            Call Form1.Mensaje("Debe seleccionar un Tipo de Gasto para continuar")
        End If
    End Sub


    Private Sub cmdGastosGuardar_Click(sender As Object, e As EventArgs) Handles cmdGastosGuardar.Click

        If Me.cmbCajas.SelectedIndex >= 0 Then
        Else
            MsgBox("Seleccione una caja")
            Exit Sub
        End If

        If Double.Parse(Me.LbGastosTotalGasto.Text) = 0 Then
            MsgBox("Debe agregar al menos un gasto para poder guardar este vale")
            Exit Sub
        End If


        If Confirmacion("¿Está seguro que desea guardar este vale de gasto?", Me.ParentForm) = True Then

            Call CargarCorrelativoGastos()

            Dim SQL As String

            Using cn As New SqlConnection(strSqlConectionString)
                Try
                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    SQL = "INSERT INTO DOCUMENTOS (EMPNIT,CODCAJA,ANIO,MES,DIA,FECHA,HORA,MINUTO,
							CODDOC,CORRELATIVO,CODCLIENTE,DOC_NIT,
							DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,TOTALPRECIO,
							CODEMBARQUE,STATUS,CONCRE,USUARIO,CORTE,SERIEFAC,
							NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_ABONO, DOC_SALDO
							) 
							VALUES
							(
							@EMPNIT,@CODCAJA,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,@CODDOC,
							@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,@DIRECCION,
							@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',@CONCRE,
							@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,
							(@PAGO-@TOTALPRECIO),'NO',@OBS,@ABONO,@SALDO
							);
	                        INSERT INTO DOCPRODUCTOS 
                                (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF) 
                            SELECT EMPNIT,@ANIO AS ANIO, @MES AS MES,@DIA AS DIA, CODDOC, CORRELATIVO, CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALUNIDADES,TOTALCOSTO,TOTALPRECIO,COSTO,COSTO,BONIF,TOTALBONIF FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO"

                    Dim cmd As New SqlCommand(SQL, cn)

                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@CODCAJA", CType(Me.cmbCajas.SelectedValue, Integer))
                    cmd.Parameters.AddWithValue("@ANIO", Me.txtGastosFecha.DateTime.Year)
                    cmd.Parameters.AddWithValue("@MES", Me.txtGastosFecha.DateTime.Month)
                    cmd.Parameters.AddWithValue("@DIA", Me.txtGastosFecha.DateTime.Day)
                    cmd.Parameters.AddWithValue("@FECHA", Me.txtGastosFecha.DateTime)
                    cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                    cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                    cmd.Parameters.AddWithValue("@CODDOC", coddocGasto)
                    cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtGastosCorrelativo.Text))
                    cmd.Parameters.AddWithValue("@CODCLIENTE", 1)
                    cmd.Parameters.AddWithValue("@NIT", "CF")
                    cmd.Parameters.AddWithValue("@NOMBRE", "CONSUMIDOR FINAL")
                    cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                    cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.LbGastosTotalGasto.Text))
                    cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.LbGastosTotalGasto.Text))
                    cmd.Parameters.AddWithValue("@PAGO", Double.Parse(Me.LbGastosTotalGasto.Text))
                    cmd.Parameters.AddWithValue("@CODEMBARQUE", "GENERAL")
                    cmd.Parameters.AddWithValue("@CONCRE", "CON")
                    cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                    cmd.Parameters.AddWithValue("@SERIEFAC", "GASTOS")
                    cmd.Parameters.AddWithValue("@NOFAC", Me.txtGastosCorrelativo.Text)
                    cmd.Parameters.AddWithValue("@CODVEN", 0)
                    cmd.Parameters.AddWithValue("@OBS", "SN")
                    cmd.Parameters.AddWithValue("@SALDO", 0)
                    cmd.Parameters.AddWithValue("@ABONO", Double.Parse(Me.LbGastosTotalGasto.Text))
                    Dim i As Integer = cmd.ExecuteNonQuery()

                    If i > 0 Then
                        Dim cmdD As New SqlCommand("DELETE FROM TEMP_VENTAS 
                                    WHERE EMPNIT=@EMPNIT AND 
                                    CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                        cmdD.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmdD.Parameters.AddWithValue("@CODDOC", coddocGasto)
                        cmdD.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtGastosCorrelativo.Text))
                        cmdD.ExecuteNonQuery()
                        cn.Close()


                        Call Form1.Mensaje("Gasto registrado exitosamente")

                        Call AbrirReporte_ValeGasto(Me.txtGastosFecha.DateTime, Double.Parse(Me.txtGastosCorrelativo.Text))

                        Call ActualizarCorrelativoGastos()

                        Call CargarCorrelativoGastos()

                        Me.DGVGastosTemp.DataSource = Nothing

                        Me.cmbGastosTipo.Text = ""
                        Me.txtGastosDescripcion.Text = ""
                        Me.txtGastosImporte.Text = 0
                        Me.LbGastosTotalGasto.Text = "0.00"
                    Else
                        MsgBox("Error al guardar este Vale")
                    End If

                Catch ex As Exception
                    MsgBox("Error al guardar este Vale. Error: " + ex.ToString)
                End Try
            End Using

        End If
    End Sub


    Private Sub CargarTotalGasto()
        Call AbrirConexionSql()
        Dim cmd As New SqlCommand("SELECT SUM(TOTALCOSTO) AS IMPORTE FROM TEMP_VENTAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & coddocGasto & "' AND CORRELATIVO=" & Double.Parse(Me.txtGastosCorrelativo.Text), cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                Me.LbGastosTotalGasto.Text = FormatNumber(dr(0), 2)
            End If
        Catch ex As Exception
            Me.LbGastosTotalGasto.Text = "0.00"
        End Try
        dr.Close()
        cmd.Dispose()
        cn.Close()


    End Sub


    Private Sub ActualizarCorrelativoGastos()
        Call AbrirConexionSql()
        Dim SQL As String

        SQL = "UPDATE TIPODOCUMENTOS SET CORRELATIVO=" & (Double.Parse(Me.txtGastosCorrelativo.Text) + 1) & " WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & coddocGasto & "'"

        Dim cmd As New SqlCommand(SQL, cn)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        cn.Close()
    End Sub

    Private Sub CargarCorrelativoGastos()

        Call AbrirConexionSql()

        Dim SQL As String

        SQL = "SELECT CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODDOC='" & coddocGasto & "'"

        Dim cmd As New SqlCommand(SQL, cn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader
        dr.Read()
        Try
            If dr.HasRows Then
                Me.txtGastosCorrelativo.Text = dr(0).ToString
            End If
        Catch ex As Exception

            Me.txtGastosCorrelativo.Text = 0

        End Try
        dr.Close()
        cmd.Dispose()

        cn.Close()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If Confirmacion("¿Está seguro que desea Eliminar los items agregados a la lista?", Me.ParentForm) = True Then
            If deleteGridGastos() = True Then
                Me.DGVGastosTemp.DataSource = Nothing
                Me.LbGastosTotalGasto.Text = "0.00"
            End If
        End If
    End Sub

    Private Function deleteGridGastos() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmdD As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO", cn)
                cmdD.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdD.Parameters.AddWithValue("@CODDOC", coddocGasto)
                cmdD.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.txtGastosCorrelativo.Text))
                cmdD.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                r = False
            End Try
        End Using

        Return r
    End Function

    Private Sub txtGastosDescripcion_TextChanged(sender As Object, e As EventArgs) Handles txtGastosDescripcion.TextChanged

    End Sub
End Class
