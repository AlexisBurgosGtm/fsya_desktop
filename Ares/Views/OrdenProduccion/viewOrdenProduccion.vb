Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewOrdenProduccion
    Private Sub viewOrdenProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objTd As New ClassTipoDocumentos(GlobalEmpNit)
        With Me.cmbCoddoc
            .DataSource = objTd.tblCoddoc("ORP")
            .ValueMember = "CODDOC"
            .DisplayMember = "CODDOC"
        End With

        Dim objE As New ClassEmpleados
        With Me.cmbEmpleado
            .DataSource = objE.tblListaEmpleadosTipo(GlobalEmpNit, 2)
            .ValueMember = "CODEMP"
            .DisplayMember = "NOMEMP"
        End With

        Call Cargarcorrelativo()

        Me.txtFecha.DateTime = Today.Date

        Call CargarGridProduccion()


    End Sub

    Private Sub CargarTotales(ByVal CODDOC As String)
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT SUM(TOTALCOSTO) AS TOTALCOSTO, SUM(TOTALPRECIO) AS TOTALPRECIO FROM TEMP_VENTAS WHERE EMPNIT=@E AND CODDOC=@D", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", CODDOC)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    Me.lbTotalCosto.Text = FormatNumber(dr(0), 2)
                    Me.lbTotalVenta.Text = FormatNumber(dr(1), 2)
                Else
                    Me.lbTotalCosto.Text = "0.00"
                    Me.lbTotalVenta.Text = "0.00"
                End If

            Catch ex As Exception
                Me.lbTotalCosto.Text = "0.00"
                Me.lbTotalVenta.Text = "0.00"
            End Try

        End Using

    End Sub

    Private Sub Cargarcorrelativo()
        Dim objT As New ClassTipoDocumentos(GlobalEmpNit)
        Try
            Me.lbCorrelativo.Text = objT.GetCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString).ToString
        Catch ex As Exception
            Me.lbCorrelativo.Text = "0"
        End Try

    End Sub

    Private Sub viewOrdenProduccion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F3 Then
            Me.btnAgregarProduccion.PerformClick()
        End If

        If e.KeyCode = Keys.F5 Then
            Me.btnGuardar.select()
        End If

    End Sub

    Private Sub btnAgregarProduccion_Click(sender As Object, e As EventArgs) Handles btnAgregarProduccion.Click

        If FlyoutDialog.Show(Me.ParentForm, New viewProductosFabricados) = DialogResult.OK Then
            Me.lbDesprod.Text = ProductosDesProd
            Me.lbCodmedida.Text = ProductosCodmedida
            Me.txtCantidad.Text = "1"
            Me.txtCantidad.select()
        End If

    End Sub

    Private Sub btnAgregarProductoProducir_Click(sender As Object, e As EventArgs) Handles btnAgregarProductoProducir.Click

        If Me.txtCantidad.Text <> "" Then
            If insertDataProducir(ProductosCodprod, ProductosDesProd, ProductosCodmedida, ProductosNF, CType(Me.txtCantidad.Text, Integer), ProductosCosto, ProductosPrecio) = True Then
                Me.lbDesprod.Text = "--"
                Me.lbCodmedida.Text = "--"
                Call CargarGridProduccion()
                Me.txtCantidad.Text = "1"
                Me.btnAgregarProduccion.select()

            Else
                MsgBox("No se pudo agregar el producto")
            End If

        Else
            Me.txtCantidad.select()
            MsgBox("Indique la cantidad a producir")
        End If

    End Sub

    Private Function insertDataProducir(ByVal codprod As String, ByVal desprod As String, ByVal codmedida As String, ByVal equivale As Integer, ByVal cantidad As Integer, ByVal costo As Double, ByVal precio As Double) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("INSERT INTO TEMP_COMANDA (EMPNIT,CODDOC,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO)
                            VALUES (@EMPNIT,@CODDOC,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO)", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CODPROD", codprod)
                cmd.Parameters.AddWithValue("@DESPROD", desprod)
                cmd.Parameters.AddWithValue("@CODMEDIDA", codmedida)
                cmd.Parameters.AddWithValue("@EQUIVALE", equivale)
                cmd.Parameters.AddWithValue("@CANTIDAD", cantidad)
                cmd.Parameters.AddWithValue("@TOTALUNIDADES", (equivale * cantidad))
                cmd.Parameters.AddWithValue("@COSTO", costo)
                cmd.Parameters.AddWithValue("@PRECIO", precio)
                cmd.Parameters.AddWithValue("@TOTALCOSTO", (costo * cantidad))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", (precio * cantidad))
                cmd.ExecuteNonQuery()

                r = True

            Catch ex As Exception
                r = False
            End Try
        End Using



        Return r
    End Function

    Private Sub CargarGridProduccion()
        Dim tblProducir As New DSPRODUCTOS.tblProductosFabricadosDataTable
        Dim tblReceta As New DSPRODUCTOS.tblRecetaDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODPROD,DESPROD,CODMEDIDA,CANTIDAD AS EQUIVALE FROM TEMP_COMANDA WHERE EMPNIT=@E AND CODDOC=@D", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", Me.cmbCoddoc.SelectedValue.ToString)
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tblProducir)

                Dim cma As New SqlCommand("SELECT PRODUCTOS_RECETAS.CODPROD, PRODUCTOS_RECETAS.DESPROD, PRODUCTOS_RECETAS.CODMEDIDA, SUM(PRODUCTOS_RECETAS.CANTIDAD * TEMP_COMANDA.TOTALUNIDADES) AS CANTIDAD, 
                         SUM(PRODUCTOS_RECETAS.TOTALUNIDADES * TEMP_COMANDA.TOTALUNIDADES) AS TOTALUNIDADES, PRODUCTOS_RECETAS.COSTO, SUM(PRODUCTOS_RECETAS.TOTALCOSTO * TEMP_COMANDA.TOTALUNIDADES) AS TOTALCOSTO
                        FROM TEMP_COMANDA LEFT OUTER JOIN
                         PRODUCTOS_RECETAS ON TEMP_COMANDA.CODPROD = PRODUCTOS_RECETAS.MAINCODPROD AND TEMP_COMANDA.EMPNIT = PRODUCTOS_RECETAS.EMPNIT
                        WHERE (TEMP_COMANDA.EMPNIT = @E) AND (TEMP_COMANDA.CODDOC = @D)
                        GROUP BY PRODUCTOS_RECETAS.CODPROD, PRODUCTOS_RECETAS.DESPROD, PRODUCTOS_RECETAS.CODMEDIDA, PRODUCTOS_RECETAS.COSTO", cn)
                cma.Parameters.AddWithValue("@E", GlobalEmpNit)
                cma.Parameters.AddWithValue("@D", Me.cmbCoddoc.SelectedValue.ToString)
                Dim de As New SqlDataAdapter
                de.SelectCommand = cma
                de.Fill(tblReceta)

                Dim cmdi As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE EMPNIT=@E AND CODDOC=@D; 
            INSERT INTO TEMP_VENTAS (EMPNIT,CODDOC,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,USUARIO,EXENTO) SELECT 
                PRODUCTOS_RECETAS.EMPNIT,@D AS CODDOC,PRODUCTOS_RECETAS.CODPROD, PRODUCTOS_RECETAS.DESPROD, PRODUCTOS_RECETAS.CODMEDIDA, PRODUCTOS_RECETAS.EQUIVALE, SUM(PRODUCTOS_RECETAS.CANTIDAD * TEMP_COMANDA.TOTALUNIDADES) AS CANTIDAD, 
                         SUM(PRODUCTOS_RECETAS.TOTALUNIDADES * TEMP_COMANDA.TOTALUNIDADES)*-1 AS TOTALUNIDADES, PRODUCTOS_RECETAS.COSTO, PRODUCTOS_RECETAS.COSTO AS PRECIO, SUM(PRODUCTOS_RECETAS.TOTALCOSTO * TEMP_COMANDA.TOTALUNIDADES) AS TOTALCOSTO,SUM(PRODUCTOS_RECETAS.TOTALCOSTO * TEMP_COMANDA.TOTALUNIDADES) AS TOTALPRECIO,
                        @USUARIO AS USUARIO, 0 AS EXENTO
                        FROM TEMP_COMANDA LEFT OUTER JOIN
                         PRODUCTOS_RECETAS ON TEMP_COMANDA.CODPROD = PRODUCTOS_RECETAS.MAINCODPROD AND TEMP_COMANDA.EMPNIT = PRODUCTOS_RECETAS.EMPNIT
                        WHERE (TEMP_COMANDA.EMPNIT = @E) AND (TEMP_COMANDA.CODDOC = @D)
                        GROUP BY PRODUCTOS_RECETAS.EMPNIT,PRODUCTOS_RECETAS.CODPROD, PRODUCTOS_RECETAS.DESPROD, PRODUCTOS_RECETAS.CODMEDIDA, PRODUCTOS_RECETAS.EQUIVALE,PRODUCTOS_RECETAS.COSTO;
            INSERT INTO TEMP_VENTAS (EMPNIT,CODDOC,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,USUARIO,EXENTO) SELECT 
            EMPNIT, CODDOC, CODPROD, DESPROD, CODMEDIDA, EQUIVALE, CANTIDAD, TOTALUNIDADES, COSTO,PRECIO, TOTALCOSTO,TOTALPRECIO, @USUARIO, 0 AS EXENTO FROM TEMP_COMANDA WHERE EMPNIT=@E AND CODDOC=@D;
               ", cn)
                cmdi.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmdi.Parameters.AddWithValue("@D", Me.cmbCoddoc.SelectedValue.ToString)
                cmdi.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmdi.ExecuteNonQuery()

            Catch ex As Exception
                'MsgBox(ex.ToString)
                'tblProducir = Nothing
            End Try
        End Using

        Me.gridProducir.DataSource = Nothing
        Me.gridProducir.DataSource = tblProducir

        Me.DgwMateriaPrima.DataSource = Nothing
        Me.DgwMateriaPrima.DataSource = tblReceta

        Call CargarTotales(Me.cmbCoddoc.SelectedValue.ToString)

    End Sub

    Private Sub GridViewProducir_DoubleClick(sender As Object, e As EventArgs) Handles GridViewProducir.DoubleClick
        If Confirmacion("¿Está seguro que desea Eliminar este item?", Me.ParentForm) = True Then
            If deleteItemProducir(drw.Item(0).ToString) = True Then
                Call CargarGridProduccion()
            End If
        End If
    End Sub

    Private Sub GridViewProducir_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProducir.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Confirmacion("¿Está seguro que desea Eliminar este item?", Me.ParentForm) = True Then
                If deleteItemProducir(drw.Item(0).ToString) = True Then
                    Call CargarGridProduccion()
                End If
            End If
        End If
    End Sub

    Dim drw As DataRow
    Private Sub GridViewProducir_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProducir.FocusedRowChanged
        Try
            drw = Nothing
            drw = Me.GridViewProducir.GetFocusedDataRow
        Catch ex As Exception
            drw = Nothing
        End Try
    End Sub

    Private Function deleteItemProducir(ByVal codprod As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_COMANDA WHERE EMPNIT=@E AND CODPROD=@C", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", codprod)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
            End Try
        End Using

        Return r
    End Function

    Private Sub cmbCoddoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoddoc.SelectedIndexChanged
        Call Cargarcorrelativo()
        Call CargarGridProduccion()
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAgregarProductoProducir.select()
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If Confirmacion("¿Está seguro que desea ELIMINAR esta orden?, perderá todos los datos agregados", Me.ParentForm) = True Then
            If deleteTempProduccion(Me.cmbCoddoc.SelectedValue.ToString) = True Then
                Call CargarGridProduccion()
                MsgBox("Datos borrados exitosamente")
            Else
                MsgBox("No se pudo eliminar la lista")
            End If
        End If
    End Sub

    Private Function deleteTempProduccion(ByVal coddoc As String) As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_COMANDA WHERE CODDOC=@D AND EMPNIT=@E; DELETE FROM TEMP_VENTAS WHERE CODDOC=@D AND EMPNIT=@E", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                r = False
            End Try
        End Using

        Return r
    End Function


    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.txtObs.Text <> "" Then
        Else
            Me.txtObs.Text = "SN"
        End If

        If Me.cmbEmpleado.SelectedIndex >= 0 Then
            If Me.lbTotalCosto.Text = "0" Then
                MsgBox("No se puede guardar un documento sin agregar productos")
            Else

                If Confirmacion("¿Está seguro que desea GUARDAR esta Orden de Trabajo?", Me.ParentForm) = True Then
                    If fcn_InsertDocumentos() = True Then
                        If fcn_InsertDocproductos() = True Then
                            Aviso("EXITO", "Documento guardado exitosamente!!", Me.ParentForm)
                            Call CargarGridProduccion()

                            'carga el inventario del documento
                            Dim objDoctos As New ClassDocumentos
                            objDoctos.DevolverInvFac(GlobalEmpNit, Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text), GlobalAnioProceso, GlobalMesProceso)

                            Dim objTD As New ClassTipoDocumentos(GlobalEmpNit)
                            'actualiza el correlativo
                            If objTD.UpdateCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text)) = True Then
                            Else
                                Call Form1.Mensaje("No se agregó el stock de este producto")
                            End If
                            'recarga el correlativo
                            Call Cargarcorrelativo()

                        Else
                            MsgBox("Se ingresó el documento pero no el detalle del mismo. Error: " + GlobalDesError)
                        End If
                    Else
                        MsgBox("No se pudo guardar el documento. Error: " + GlobalDesError)
                    End If


                End If

            End If

        Else
            MsgBox("Seleccione un Empleado")
        End If


    End Sub


    Private Function fcn_InsertDocumentos() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                Dim qry1 As String = "INSERT INTO DOCUMENTOS 
                (EMPNIT,ANIO,MES,DIA,FECHA,HORA,MINUTO,	CODDOC,CORRELATIVO,CODCLIENTE,DOC_NIT,DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,TOTALPRECIO,CODEMBARQUE,STATUS,CONCRE,USUARIO,CORTE,SERIEFAC,NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_ABONO, DOC_SALDO,TOTALTARJETA, RECARGOTARJETA,TOTALEXENTO,DIRENTREGA,VENCIMIENTO,DIASCREDITO,CODCAJA) 
				    VALUES
				(@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,@CODDOC,@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,@DIRECCION,@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',@CONCRE,@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,(@PAGO-@TOTALPRECIO),'NO',@OBS,@ABONO,@SALDO,@PAGOTARJETA,@RECARGOTARJETA,@TOTALEXENTO,@DIRENTREGA,@FECHAVENCE,@DIASCREDITO,@CODCAJA)"

                Dim cmd As New SqlCommand(qry1, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Me.txtFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@MES", Me.txtFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@DIA", Me.txtFecha.DateTime.Day)
                cmd.Parameters.AddWithValue("@FECHA", Me.txtFecha.DateTime)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.lbCorrelativo.Text))
                cmd.Parameters.AddWithValue("@CODCLIENTE", 0)
                cmd.Parameters.AddWithValue("@NIT", "SN")
                cmd.Parameters.AddWithValue("@NOMBRE", "ORDEN PARA PRODUCCION")
                cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.LbTotalCosto.Text))
                cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.LbTotalVenta.Text))
                cmd.Parameters.AddWithValue("@TOTALEXENTO", 0)
                cmd.Parameters.AddWithValue("@CODEMBARQUE", "PRODUCCION")
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@NOFAC", Me.lbCorrelativo.Text)
                cmd.Parameters.AddWithValue("@CODVEN", Integer.Parse(Me.cmbEmpleado.SelectedValue.ToString))
                cmd.Parameters.AddWithValue("@OBS", Me.txtObs.Text)
                cmd.Parameters.AddWithValue("@DIRENTREGA", "SN")
                cmd.Parameters.AddWithValue("@FECHAVENCE", Me.txtFecha.DateTime)
                cmd.Parameters.AddWithValue("@DIASCREDITO", 0)
                cmd.Parameters.AddWithValue("@CODCAJA", VentasCodCaja)
                cmd.Parameters.AddWithValue("@SERIEFAC", Me.cmbCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@PAGO", Double.Parse(Me.lbTotalVenta.Text))
                cmd.Parameters.AddWithValue("@PAGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@RECARGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@CONCRE", "CON")
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@ABONO", Double.Parse(Me.lbTotalVenta.Text))
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                GlobalDesError = ex.ToString
                MsgBox("documentos: " + ex.ToString)
                result = False
            End Try

        End Using
        Return result

    End Function

    Private Function fcn_InsertDocproductos() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If


            Try
                Dim qry As String = "INSERT INTO DOCPRODUCTOS 
                (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,
				    ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF,NOSERIE,EXENTO,OBS) 
	            SELECT EMPNIT,@ANIO AS ANIO, @MES AS MES,@DIA AS DIA, @CODDOC AS CODDOC,@CORRELATIVO AS CORRELATIVO, CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,
				    TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALUNIDADES,TOTALCOSTO,TOTALPRECIO,COSTO,COSTO,BONIF,TOTALBONIF,NOSERIE,EXENTO,OBS 
	            FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC;"

                Dim qryDelete As String = "DELETE FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC;DELETE FROM TEMP_COMANDA WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC;"

                Dim cmd As New SqlCommand(qry, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Me.txtFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@MES", Me.txtFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@DIA", Me.txtFecha.DateTime.Day)
                cmd.Parameters.AddWithValue("@FECHA", Me.txtFecha.DateTime)
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.lbCorrelativo.Text))
                cmd.ExecuteNonQuery()

                Dim cmdD As New SqlCommand(qryDelete, cn)
                cmdD.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmdD.Parameters.AddWithValue("@CODDOC", Me.cmbCoddoc.SelectedValue.ToString)
                cmdD.ExecuteNonQuery()

                result = True

            Catch ex As Exception

                result = False
            End Try


        End Using

        Return result

    End Function

End Class
