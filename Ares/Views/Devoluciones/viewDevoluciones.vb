
Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewDevoluciones

    Dim objT As New ClassTipoDocumentos(GlobalEmpNit)

    Private Sub viewDevoluciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtFecha.DateTime = Today.Date

        With Me.cmbCoddoc
            .DataSource = objT.tblCoddoc("DEV")
            .DisplayMember = "DESDOC"
            .ValueMember = "CODDOC"
        End With

        If Me.cmbCoddoc.Text <> "" Then
            Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
            GlobalSelectedTipoDocumento = objTipoDoc.getTipoDocumento(Me.cmbCoddoc.SelectedValue.ToString)
        End If

        Call CargarCorrelativoDev()

        Call CargarSeriesFacturacion()

        Call CargarVendedores()
        Call cargarCajas()

        'verifica si el tipo de documento es fel para mostrar el status
        Me.lbAvisoFEL.Visible = getStatusTipoFEl(GlobalSelectedTipoDocumento)

    End Sub

    Private Sub cargarCajas()
        Dim objC As New classCorteCaja
        With Me.cmbCaja
            .DataSource = objC.getCajas(1)
            .ValueMember = "CODCAJA"
            .DisplayMember = "DESCAJA"
        End With

        If Me.cmbCaja.Text <> "" Then
            Me.cmbCaja.SelectedValue = GlobalSelectedCodCaja
        End If

    End Sub

    Private Sub CargarCorrelativoDev()

        Dim coddoc As String = Me.cmbCoddoc.SelectedValue.ToString
        Me.lbCorrelativo.Text = objT.GetCorrelativoDoc(coddoc).ToString

    End Sub

    Private Sub CargarSeriesFacturacion()

        Dim objD As New ClassTipoDocumentos(GlobalEmpNit)

        If GlobalSelectedTipoDocumento = "DEV" Then
            With Me.cmbSerieFac
                .DataSource = objD.tblCoddoc("SOLOFAC")
                .ValueMember = "CODDOC"
                .DisplayMember = "CODDOC"
            End With
        End If

        If GlobalSelectedTipoDocumento = "FNC" Then
            With Me.cmbSerieFac
                .DataSource = objD.tblCoddoc("FEL")
                .ValueMember = "CODDOC"
                .DisplayMember = "CODDOC"
            End With
        End If

    End Sub

    Private Sub CargarVendedores()
        Dim objE As New ClassEmpleados
        With Me.cmbVendedor
            .DataSource = objE.tblListaEmpleadosTipo(GlobalEmpNit, 3)
            .ValueMember = "CODEMP"
            .DisplayMember = "NOMEMP"
        End With
    End Sub

    Private Sub btnCargarFactura_Click(sender As Object, e As EventArgs) Handles btnCargarFactura.Click

        If Me.txtCorrelativoFac.Text <> "" Then

            Dim objD As New ClassTipoDocumentos(GlobalEmpNit)
            Dim st As String = objD.getDocumentoStatus(Me.cmbSerieFac.SelectedValue.ToString, Double.Parse(Me.txtCorrelativoFac.Text))

            If st = "D" Or st = "A" Then
                MsgBox("Ya se ha operado una devolución sobre esta factura o factura anulada, por favor, rectifique")
            Else

                Call deleteTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))

                Call CargarTempFactura(Me.cmbSerieFac.SelectedValue.ToString, Double.Parse(Me.txtCorrelativoFac.Text))

                Me.cmbVendedor.select()

                Me.cmbSerieFac.Enabled = False
                Me.btnCargarFactura.Enabled = False
                Me.btnBuscarFactura.Enabled = False
                Me.txtCorrelativoFac.Enabled = False

                Call CargarTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))

            End If
        Else
            Call Aviso("ERROR", "Debe ingresar un número de factura para cargar", Me.ParentForm)
        End If


    End Sub


    Private Sub deleteTempDevolucion(ByVal coddoc As String, ByVal correlativo As Double)
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE EMPNIT=@E AND CODDOC=@D AND CORRELATIVO=@N", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", Me.cmbCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@N", Double.Parse(Me.lbCorrelativo.Text))
                cmd.ExecuteNonQuery()
                Me.GridProductosFactura.DataSource = Nothing
                Me.lbTotalDevolucion.Text = "0.00"
                devTotalcosto = 0
                devTotalprecio = 0
                devTotalExento = 0
            Catch ex As Exception

            End Try
        End Using
    End Sub

    'carga inicial de la factura
    Private Sub CargarTempFactura(ByVal coddoc As String, ByVal correlativo As Double)


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("SELECT DOCPRODUCTOS.CODPROD, 
                                DOCPRODUCTOS.DESPROD, 
                                DOCPRODUCTOS.CODMEDIDA, 
                                DOCPRODUCTOS.CANTIDAD, 
                                DOCPRODUCTOS.TOTALUNIDADES, 
                                DOCPRODUCTOS.TOTALPRECIO, 
                                DOCUMENTOS.CODCLIENTE, 
                                DOCUMENTOS.DOC_NIT AS NIT, 
                                DOCUMENTOS.DOC_NOMCLIE AS NOMCLIE,
                                DOCPRODUCTOS.EQUIVALE,
                                DOCPRODUCTOS.EXENTO,
                                DOCPRODUCTOS.COSTO,
                                DOCPRODUCTOS.PRECIO,
                                DOCPRODUCTOS.TOTALCOSTO,
                                DOCUMENTOS.TOTALPRECIO,
                                DOCUMENTOS.DOC_NIT
                        FROM DOCPRODUCTOS LEFT OUTER JOIN
                         DOCUMENTOS ON DOCPRODUCTOS.CORRELATIVO = DOCUMENTOS.CORRELATIVO AND DOCPRODUCTOS.CODDOC = DOCUMENTOS.CODDOC AND DOCPRODUCTOS.EMPNIT = DOCUMENTOS.EMPNIT
                        WHERE (DOCPRODUCTOS.EMPNIT = @E) AND (DOCPRODUCTOS.CODDOC = @D) AND (DOCPRODUCTOS.CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dra As SqlDataReader = cmd.ExecuteReader
                Dim totalfac As Double = 0
                Do While dra.Read
                    totalfac = Double.Parse(dra(14))
                    GlobalCodCliente = Integer.Parse(dra(6))
                    Me.txtNitClie.Text = dra(15).ToString
                    Me.txtCodClie.Text = dra(7).ToString
                    Me.txtNomClie.Text = dra(8).ToString

                    Dim cmi As New SqlCommand("INSERT INTO TEMP_VENTAS (EMPNIT,CODDOC,CORRELATIVO,USUARIO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES, COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,EXENTO,TOTALBONIF) 
                    VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@USUARIO,@CODPROD,@DESPROD,@CODMEDIDA,@CANTIDAD,@EQUIVALE,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@EXENTO,@TOTALBONIF)", cn)
                    cmi.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmi.Parameters.AddWithValue("@CODDOC", Me.cmbCoddoc.SelectedValue.ToString)
                    cmi.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.lbCorrelativo.Text))
                    cmi.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                    cmi.Parameters.AddWithValue("@CODPROD", dra(0).ToString)
                    cmi.Parameters.AddWithValue("@DESPROD", dra(1).ToString)
                    cmi.Parameters.AddWithValue("@CODMEDIDA", dra(2).ToString)
                    cmi.Parameters.AddWithValue("@CANTIDAD", dra(3).ToString)
                    cmi.Parameters.AddWithValue("@EQUIVALE", Integer.Parse(dra(9)))
                    cmi.Parameters.AddWithValue("@TOTALUNIDADES", dra(4).ToString)
                    cmi.Parameters.AddWithValue("@TOTALBONIF", dra(4).ToString) 'EN ESTE CAMPO ESTABLECERÉ EL MÁXIMO DE UNIDADES PARA QUE EL USUARIO NO INGRESE MÁS DE LA CUENTA
                    cmi.Parameters.AddWithValue("@COSTO", Double.Parse(dra(11)))
                    cmi.Parameters.AddWithValue("@PRECIO", Double.Parse(dra(12)))
                    cmi.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(dra(13)))
                    cmi.Parameters.AddWithValue("@TOTALPRECIO", dra(5).ToString)
                    cmi.Parameters.AddWithValue("@EXENTO", Double.Parse(dra(10)))
                    cmi.ExecuteNonQuery()

                Loop

                Me.lbTotalFacturaOriginal.Text = FormatNumber(totalfac, 2)

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using

    End Sub

    Dim devTotalcosto, devTotalprecio, devTotalExento As Double

    Private Sub CargarTempDevolucion(ByVal coddoc As String, ByVal correlativo As Double)
        devTotalcosto = 0
        devTotalprecio = 0
        devTotalExento = 0
        Dim tbl As New DS_DEVOLUCIONES.tblProductosFacDataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If
                Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, CODMEDIDA, 
                                CANTIDAD, TOTALUNIDADES, TOTALPRECIO, 
                                ID, COSTO, PRECIO, 
                                EQUIVALE, TOTALCOSTO, TOTALBONIF
                        FROM TEMP_VENTAS
                        WHERE (EMPNIT = @E) AND (CODDOC = @D) AND (CORRELATIVO = @N)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@D", coddoc)
                cmd.Parameters.AddWithValue("@N", correlativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                Do While dr.Read
                    tbl.Rows.Add(New Object() {
                    dr(0),'codprod
                    dr(1),'desprod
                    dr(2),'codmedida
                    dr(3),'cantidad
                    dr(4),'totalunidades
                    dr(5),'totalprecio
                    dr(6),'id
                    dr(7),'costo
                    dr(8),'precio
                    dr(9), 'equivale
                    dr(11) 'total bonif // usado para establecer la cantidad máxima de unidades a ingresar como devolución
                    })
                    devTotalcosto = devTotalcosto + Double.Parse(dr(10))
                    devTotalprecio = devTotalprecio + Double.Parse(dr(5))
                Loop


            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try
        End Using

        Me.GridProductosFactura.DataSource = Nothing
        Me.GridProductosFactura.DataSource = tbl
        Me.lbTotalDevolucion.Text = FormatNumber(devTotalprecio, 2)

    End Sub


    ' ********* MANEJO DEL GRID *******
    Dim drw As DataRow
    Private Sub GridViewProductosFac_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewProductosFac.FocusedRowChanged

        Try

            drw = Nothing
            drw = Me.GridViewProductosFac.GetFocusedDataRow

        Catch ex As Exception

            drw = Nothing

        End Try

    End Sub

    Private Sub GridViewProductosFac_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewProductosFac.KeyDown

        'abre el radial menu
        If e.KeyCode = Keys.Enter Then
            Me.RadialMenuDevs.ShowPopup(MousePosition)
        End If

        'eliminar item al presionar delete
        If e.KeyCode = Keys.Delete Then
            'If Confirmacion("¿Está seguro que desea REMOVER este item de la devolución?", Me.ParentForm) = True Then

            If getConfirmacion("¿Está seguro que desea REMOVER este item de la devolución?") = True Then
                If deleteItemDevolucion(CType(drw.Item(6), Integer)) = True Then
                    Call CargarTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))
                Else
                    MsgBox("Error al quitar el ITEM. Error: " + GlobalDesError)
                End If
            End If
        End If

        'abre la ventana de editar
        If e.KeyCode = Keys.E Then
            Try
                Dim cod, des As String, un, cant, costu, preu, unidadesfacturadas As Double, id, equ As Integer
                cod = drw.Item(0).ToString
                des = drw.Item(1).ToString
                cant = Double.Parse(drw.Item(3))
                un = Double.Parse(drw.Item(4))
                id = Integer.Parse(drw.Item(6))
                costu = Double.Parse(drw.Item(7))
                preu = Double.Parse(drw.Item(8))
                equ = Integer.Parse(drw.Item(9))
                unidadesfacturadas = Double.Parse(drw.Item(10))

                If FlyoutDialog.Show(Me.ParentForm, New viewDevolucionesCantidad(cod, des, cant, un, id, costu, preu, unidadesfacturadas)) = DialogResult.OK Then

                    Call CargarTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))

                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub GridViewProductosFac_DoubleClick(sender As Object, e As EventArgs) Handles GridViewProductosFac.DoubleClick
        Try

            Me.RadialMenuDevs.ShowPopup(MousePosition)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        If Confirmacion("¿Está seguro que desea Eliminar esta Devolución?", Me.ParentForm) = True Then
            Me.cmbSerieFac.Enabled = True
            Me.btnCargarFactura.Enabled = True
            Me.btnBuscarFactura.Enabled = True
            Me.txtCorrelativoFac.Enabled = True

            Call deleteTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))
            Me.GridProductosFactura.DataSource = Nothing

        End If

    End Sub

    Private Function ClaveSup() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If


                'Dim cmd As New SqlCommand("SELECT NOMVEN, CLAVE, CODVEN FROM VENDEDORES WHERE EMPNIT='" & GlobalEmpNit & "' AND CLAVE='" & Me.txtPassVendedor.Text & "'", cn)
                Dim cmd As New SqlCommand("SELECT NOMEMPLEADO, CLAVE, CODEMPLEADO FROM EMPLEADOS WHERE EMPNIT='" & GlobalEmpNit & "' AND CLAVE='" & Me.txtPass.Text & "'", cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then

                    GlobalNomEmpleado = CType(dr(0), Integer)
                    r = True

                Else
                    r = False

                End If

                dr.Close()
                cmd.Dispose()

            Catch ex As Exception
                Call Form1.Mensaje("La clave indicada es incorrecta")
                r = False
            End Try


        End Using

        Return r

    End Function

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click



        If Confirmacion("¿Está seguro que desea Guardar esta Nota de Crédito / Devolución?", Me.ParentForm) = True Then

            If Me.btnCargarFactura.Enabled = False Then

                If Me.cmbCaja.SelectedIndex >= 0 Then
                Else
                    MsgBox("Debe seleccionar una caja")
                    Exit Sub
                End If

                If Me.cmbVendedor.SelectedIndex >= 0 Then
                Else
                    MsgBox("Debe seleccionar un Vendedor")
                    Exit Sub
                End If

                If Me.txtMotivo.Text <> "" Then
                Else
                    Me.txtMotivo.Text = "SN"
                End If

                Dim docCoddoc As String = Me.cmbCoddoc.SelectedValue.ToString
                Dim docCorrelativo As Double = Double.Parse(Me.lbCorrelativo.Text)

                If insertDocumentos() = True Then
                    Do Until fcn_InsertDocproductos() = True
                        Call Form1.Mensaje("Reintentando guardar el detalle de productos...")
                    Loop
                    Call Form1.Mensaje("Devolución ingresada Exitosamente")

                    '----------------------------------------------------------------
                    'DESCUENTA EL SALDO DE LA FACTURA SI ES UNA FACTURA AL CRÉDITO
                    Dim objCxc As New ClassCxc
                    If objCxc.disminuirSaldoFactura(Me.cmbSerieFac.SelectedValue.ToString, Double.Parse(Me.txtCorrelativoFac.Text), devTotalprecio) = True Then
                    Else
                    End If
                    '----------------------------------------------------------------

                    Dim docto As String, correl As Double
                    docto = Me.cmbCoddoc.SelectedValue.ToString
                    correl = Double.Parse(Me.lbCorrelativo.Text)

                    'elimina el grid
                    Call deleteTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))

                    'actualiza el correlativo
                    Dim objTipodoc As New ClassTipoDocumentos(GlobalEmpNit)
                    objTipodoc.UpdateCorrelativoDoc(docto, correl)

                    'Cambia el status del documento a D que significa Devolución
                    objTipodoc.UpdateDocumentoStatus(Me.cmbSerieFac.SelectedValue.ToString, Double.Parse(Me.txtCorrelativoFac.Text), "D")

                    'actualiza el correlativo
                    Call CargarCorrelativoDev()

                    Dim objInv As New ClassDocumentos
                    If objInv.DevolverInvFac(GlobalEmpNit, docto, correl, GlobalAnioProceso, GlobalMesProceso) = True Then
                    Else
                        Call Form1.Mensaje("No se agregó el stock, por favor realice una actualización de inventario")
                    End If




                    Me.cmbSerieFac.Enabled = True
                    Me.btnCargarFactura.Enabled = True
                    Me.txtCorrelativoFac.Enabled = True
                    Me.btnBuscarFactura.Enabled = True






                    'SI ES UNA NOTA DE CREDITO FEL
                    If GlobalSelectedTipoDocumento = "FNC" Then

                        Dim objclie As New classClientes(GlobalEmpNit)
                        Dim dirclie As String = "CIUDAD" 'objclie.getDireccionCliente(CType(Me.txtCodClie.Text, Integer))

                        Dim f As String = DateTime.Now.ToShortDateString()
                        Dim fel As New classFEL
                        If fel.notacreditoIVA(f, docto, correl, Me.txtNitClie.Text, Me.txtNomClie.Text, "", dirclie, "GUATEMALA", "GUATEMALA", Me.txtMotivo.Text) = True Then

                            'actualiza los datos FEL del documento
                            GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                            GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                            GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                            GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                            GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                            'abre la página con la factura
                            'Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)

                            'actualiza el documento interno con los datos de FEL
                            If fel.updateDocumentoFEL(GlobalEmpNit, docto, correl, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                                Call Form1.Mensaje("Serie FEL asignada a la factura del sistema")
                            Else
                                Call Form1.Mensaje("No se logró actualizar el correlativo en el documento local")
                            End If

                            'abre el reporte imprimible FEL
                            fel.rptDevolucionFEL(docto, correl, 2)

                        Else
                            'proceso de contingencia
                            MsgBox("Lo siento, no pude certificar la Nota de crédito, debe hacerlo manualmente o esperar a que el sistema lo haga automáticamente y usted pueda reimprimirla")

                        End If

                    Else
                        'NOTA CREDITO NORMAL
                        If rptDevolucionVenta(docto, correl) = True Then
                        End If

                    End If



                Else
                    MsgBox("No se pudo Guardar la Devolución")
                End If


            Else
                MsgBox("Debe agregar una Factura")
            End If

        Else
        End If

    End Sub


    Private Function insertDocumentos() As Boolean
        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim qry1 As String = "INSERT INTO DOCUMENTOS 
                (EMPNIT,ANIO,MES,DIA,FECHA,HORA,MINUTO,	CODDOC,CORRELATIVO,CODCLIENTE,DOC_NIT,DOC_NOMCLIE,DOC_DIRCLIE,TOTALCOSTO,TOTALPRECIO,CODEMBARQUE,STATUS,CONCRE,USUARIO,CORTE,SERIEFAC,NOFAC,CODVEN,PAGO,VUELTO,MARCA,OBS, DOC_ABONO, DOC_SALDO,TOTALTARJETA, RECARGOTARJETA,CODREP,TOTALEXENTO,DIRENTREGA,VENCIMIENTO,DIASCREDITO,CODCAJA) 
				    VALUES
				(@EMPNIT,@ANIO,@MES,@DIA,@FECHA,@HORA,@MINUTO,@CODDOC,@CORRELATIVO,@CODCLIENTE,@NIT,@NOMBRE,@DIRECCION,@TOTALCOSTO,@TOTALPRECIO,@CODEMBARQUE,'O',@CONCRE,@USUARIO,'NO',@SERIEFAC,@NOFAC,@CODVEN,@PAGO,(@PAGO-@TOTALPRECIO),'NO',@OBS,@ABONO,@SALDO,@PAGOTARJETA,@RECARGOTARJETA,@CODREP,@TOTALEXENTO,@DIRENTREGA,@FECHAVENCE,@DIASCREDITO,@CODCAJA)"

                Dim cmd As New SqlCommand(qry1, cn)

                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Me.txtFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@MES", Me.txtFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@DIA", Me.txtFecha.DateTime.Day)
                cmd.Parameters.AddWithValue("@FECHA", Me.txtFecha.DateTime)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.lbCorrelativo.Text))
                cmd.Parameters.AddWithValue("@CODCLIENTE", GlobalCodCliente)
                cmd.Parameters.AddWithValue("@NIT", Me.txtCodClie.Text)
                cmd.Parameters.AddWithValue("@NOMBRE", Me.txtNomClie.Text)
                cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                cmd.Parameters.AddWithValue("@TOTALCOSTO", devTotalcosto)
                cmd.Parameters.AddWithValue("@TOTALPRECIO", devTotalprecio)
                cmd.Parameters.AddWithValue("@TOTALEXENTO", devTotalExento)
                cmd.Parameters.AddWithValue("@CODEMBARQUE", GlobalSelectedCodEmbarque)
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@CODVEN", Integer.Parse(Me.cmbVendedor.SelectedValue.ToString))
                cmd.Parameters.AddWithValue("@OBS", "DEVOLUCION DE VENTAS")
                cmd.Parameters.AddWithValue("@DIRENTREGA", "CIUDAD")
                cmd.Parameters.AddWithValue("@FECHAVENCE", Me.txtFecha.DateTime)
                cmd.Parameters.AddWithValue("@DIASCREDITO", 0)
                cmd.Parameters.AddWithValue("@CODCAJA", Integer.Parse(Me.cmbCaja.SelectedValue))
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@SERIEFAC", Me.cmbSerieFac.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@NOFAC", Me.txtCorrelativoFac.Text)
                cmd.Parameters.AddWithValue("@PAGO", 0)
                cmd.Parameters.AddWithValue("@PAGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@RECARGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@CONCRE", "CON")
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@ABONO", devTotalprecio)
                cmd.Parameters.AddWithValue("@CODREP", DBNull.Value)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                MsgBox("error en documentos. Error: " + ex.ToString)
            End Try
        End Using

        Return r

    End Function

    Private Function fcn_InsertDocproductos() As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> 1 Then
                cn.Open()
            End If


            Try
                Dim qry As String = "INSERT INTO DOCPRODUCTOS 
                (EMPNIT,ANIO,MES,DIA,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,ENTREGADOS_TOTALUNIDADES,
				    ENTREGADOS_TOTALCOSTO,ENTREGADOS_TOTALPRECIO,COSTOANTERIOR,COSTOPROMEDIO,CANTIDADBONIF,TOTALBONIF,NOSERIE,EXENTO,OBS) 
	            SELECT EMPNIT,@ANIO AS ANIO, @MES AS MES,@DIA AS DIA, @CODDOC AS CODDOC,@CORRELATIVO AS CORRELATIVO, CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,
				    TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,TOTALUNIDADES,TOTALCOSTO,TOTALPRECIO,COSTO,COSTO,0 AS BONIF,0 AS TOTALBONIF,NOSERIE,EXENTO,OBS 
	            FROM TEMP_VENTAS WHERE EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO"

                Dim cmd As New SqlCommand(qry, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", Me.txtFecha.DateTime.Year)
                cmd.Parameters.AddWithValue("@MES", Me.txtFecha.DateTime.Month)
                cmd.Parameters.AddWithValue("@DIA", Me.txtFecha.DateTime.Day)
                cmd.Parameters.AddWithValue("@CODDOC", Me.cmbCoddoc.SelectedValue.ToString)
                cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Me.lbCorrelativo.Text))
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                MsgBox("error en docproductos: " + ex.ToString)
                result = False
            End Try


        End Using

        Return result

    End Function


    Private Sub btnMenuEditar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuEditar.ItemClick

        Try
            Dim cod, des As String, un, cant, costu, preu, unidadesfacturadas As Double, id, equ As Integer
            cod = drw.Item(0).ToString
            des = drw.Item(1).ToString
            cant = Double.Parse(drw.Item(3))
            un = Double.Parse(drw.Item(4))
            id = Integer.Parse(drw.Item(6))
            costu = Double.Parse(drw.Item(7))
            preu = Double.Parse(drw.Item(8))
            equ = Integer.Parse(drw.Item(9))
            unidadesfacturadas = Double.Parse(drw.Item(10))

            If FlyoutDialog.Show(Me.ParentForm, New viewDevolucionesCantidad(cod, des, cant, un, id, costu, preu, unidadesfacturadas)) = DialogResult.OK Then

                Call CargarTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub btnBuscarFactura_Click(sender As Object, e As EventArgs) Handles btnBuscarFactura.Click
        If FlyoutDialog.Show(Me.ParentForm, New viewDevolucionListaFacturas) = DialogResult.OK Then
            Me.cmbSerieFac.SelectedValue = SelectedCoddoc
            Me.txtCorrelativoFac.Text = SelectedCorrelativo.ToString
            If SelectedCorrelativo > 0 Then
                Me.btnCargarFactura.PerformClick()
            End If
        End If
    End Sub

    Private Sub cmbCoddoc_Leave(sender As Object, e As EventArgs) Handles cmbCoddoc.Leave

        Try
            Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
            GlobalSelectedTipoDocumento = objTipoDoc.getTipoDocumento(Me.cmbCoddoc.SelectedValue.ToString)

            Call CargarSeriesFacturacion()

            'verifica si el tipo de documento es fel para mostrar el status
            Me.lbAvisoFEL.Visible = getStatusTipoFEl(GlobalSelectedTipoDocumento)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbCoddoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoddoc.SelectedIndexChanged
        Try
            Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
            Me.lbCorrelativo.Text = objTipoDoc.GetCorrelativoDoc(Me.cmbCoddoc.SelectedValue.ToString)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMenuEliminar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMenuEliminar.ItemClick
        'If Confirmacion("¿Está seguro que desea REMOVER este item de la devolución?", Me.ParentForm) = True Then

        If getConfirmacion("¿Está seguro que desea REMOVER este item de la devolución?") = True Then
            If deleteItemDevolucion(CType(drw.Item(6), Integer)) = True Then
                Call CargarTempDevolucion(Me.cmbCoddoc.SelectedValue.ToString, Double.Parse(Me.lbCorrelativo.Text))
            Else
                MsgBox("Error al quitar el ITEM. Error: " + GlobalDesError)
            End If
        End If


    End Sub

    Private Function deleteItemDevolucion(ByVal id As Integer) As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("DELETE FROM TEMP_VENTAS WHERE ID=@ID", cn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
                r = True
            Catch ex As Exception
                r = False
            End Try
        End Using

        Return r

    End Function


End Class
