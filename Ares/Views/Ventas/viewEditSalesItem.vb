
Imports System.Data.SqlClient


Public Class viewEditSalesItem
    Sub New(ByVal _empnit As String, ByVal _item As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        empnit = _empnit
        item = _item

    End Sub

    Dim empnit As String
    Dim item As Integer


    Private Sub viewEditSalesItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'VERIFICA SI EL SWITCH ESTÁ ACTIVADO PARA PERMITIR
        'DECIMALES EN CANTIDADES
        If Form1.SwitchConfigModoPOS.IsOn = False Then
            Me.txtUCCantidad.Properties.Mask.EditMask = "n0"
        End If

        If fcn_ObtenerDatosItem(item) = True Then

            If fcn_CargarMedidas() = True Then

            End If

            Me.lbUCDesProducto.Text = desprod
            Me.cmbUCMedida.Text = codmedida
            Me.txtUCCantidad.Text = cantidad
            Me.txtUCPrecio.Text = precio
            Me.txtUCTotal.Text = totalPrecio

        End If

        Me.txtUCPrecio.Text = FormatNumber(precio, 2)

    End Sub

    Private Sub viewEditSalesItem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F2 Then
            Me.btnEditar.PerformClick()
        End If

        If e.KeyCode = Keys.F3 Then
            Me.btnEliminar.PerformClick()
        End If

    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.NavFrameEdit.SelectedPage = NP_Editar
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Me.NavFrameEdit.SelectedPage = NP_Eliminar
    End Sub



#Region " ** EDITAR ITEM ** "

    Private Sub cmbUCMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUCMedida.KeyDown
        If e.KeyCode = Keys.Enter Then

            If fcn_CargarCostoPrecioMed() = True Then
            End If

            Call CalcularTotalPrecio()

            Me.txtUCCantidad.select()

        End If
    End Sub

    Private Sub cmbUCMedida_Leave(sender As Object, e As EventArgs) Handles cmbUCMedida.Leave
        Try

            Me.txtUCTotal.Text = FormatNumber(CType(Me.txtUCCantidad.Text, Double) * CType(Me.txtUCPrecio.Text, Double), 2)

            If fcn_CargarCostoPrecioMed() = True Then
            End If

            Call CalcularTotalPrecio()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtUCCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Me.txtUCPrecio.Enabled = True Then


                Call CalcularTotalPrecio()
                Me.txtUCPrecio.select()
            Else
                Call CalcularTotalPrecio()
                Me.cmdUCAceptar.select()
            End If
        End If
    End Sub

    Private Sub txtUCPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUCPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then

            Call CalcularTotalPrecio()

            Me.cmdUCAceptar.select()
        End If
    End Sub

    Private Sub CalcularTotalPrecio()
        Try
            Dim cant As Double, prec As Double, cost As Double
            cant = CType(Me.txtUCCantidad.Text, Double)
            prec = varPrecio
            cost = varCosto
            Me.txtUCTotal.Text = FormatNumber(cant * prec, 2)

        Catch ex As Exception

        End Try
    End Sub


#End Region


#Region " ** QUITAR ITEM ** "
    Private Sub btnDelAceptar_Click(sender As Object, e As EventArgs) Handles btnDelAceptar.Click
        Dim objSeries As New classSeries
        If objSeries.Select_SerieItemVenta(item) = True Then
            If fcn_eliminar_item_documento(item) = True Then
            Else
                MsgBox("No se pudo quitar el Item Seleccionado. Error: " & GlobalDesError.ToString)
            End If
        End If
    End Sub



#End Region


#Region " ** FUNCIONES ** "

    Dim varCosto, varPrecio As Double
    Dim codprod As String, desprod As String, codmedida As String, cantidad As Double, costo As Double, precio As Double, totalCosto As Double, totalPrecio As Double, equivale As Integer

    Private Sub GroupControl1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles GroupControl1.PreviewKeyDown
        If e.KeyCode = Keys.F2 Then
            Me.btnEditar.PerformClick()
        End If

        If e.KeyCode = Keys.F3 Then
            Me.btnEliminar.PerformClick()
        End If
    End Sub

    Dim constTotalUnidades As Double 'almacena el total a sumar al inventario

    Private Sub NP_Editar_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles NP_Editar.PreviewKeyDown
        If e.KeyCode = Keys.F2 Then
            Me.btnEditar.PerformClick()
        End If

        If e.KeyCode = Keys.F3 Then
            Me.btnEliminar.PerformClick()
        End If
    End Sub

    Private Sub cmdUCAceptar_Click(sender As Object, e As EventArgs) Handles cmdUCAceptar.Click



        Call CalcularTotalPrecio()

        If Me.cmbUCMedida.SelectedIndex >= 0 Then


            If Me.txtUCCantidad.Text <> "" Then
            Else
                Me.txtUCCantidad.Text = 1
            End If

            If fcn_GuardarItem() = True Then

                If fcn_eliminar_item_documento(item) = True Then
                Else
                    Form1.Mensaje("Se editó el item pero no se logró regresar el stock")
                End If

                Me.btnEditTrueSave.PerformClick()
            Else
                MsgBox("Lo siento, no pude guardar los cambios. Error: " & GlobalDesError)
            End If

        Else
            MsgBox("Seleccione una medida de Precios")
        End If

    End Sub


    Private Function fcn_GuardarItem() As Boolean
        Dim result As Boolean


        Dim totalexentovalue As Double
        If VentasExento = 1 Then
            totalexentovalue = Double.Parse(Me.txtUCTotal.Text)
        Else
            totalexentovalue = 0
        End If

        If fcn_CrearMovimientoInventario(codprod, CType(Me.cmbUCMedida.SelectedValue, Integer)) = True Then


            Using cn As New SqlConnection(strSqlConectionString)

                Try

                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim sql As String = ""
                    If SelectedForm = "LISTADOS" Then
                        sql = "UPDATE DOCPRODUCTOS SET 
                        CODMEDIDA=@CODMEDIDA,
                        EQUIVALE=@EQUIVALE,
                        CANTIDAD=@CANTIDAD,
                        TOTALUNIDADES=@TOTALUNIDADES,
                        ENTREGADOS_TOTALUNIDADES=@TOTALUNIDADES,
                        COSTO=@COSTO,
                        COSTOANTERIOR=@COSTO,
                        COSTOPROMEDIO=@COSTO,
                        PRECIO=@PRECIO,
                        TOTALCOSTO=@TOTALCOSTO,
                        ENTREGADOS_TOTALCOSTO=@TOTALCOSTO,
                        TOTALPRECIO=@TOTALPRECIO,
                        ENTREGADOS_TOTALPRECIO=@TOTALPRECIO,
                        EXENTO=@EXENTO
                        WHERE ID=@ID AND EMPNIT=@EMPNIT AND CODDOC=@CODDOC AND CORRELATIVO=@CORRELATIVO"
                    Else
                        sql = "INSERT INTO Temp_Ventas 
                        (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,USUARIO,EXENTO) 
                        VALUES 
                        (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@USUARIO,@EXENTO)"
                    End If


                    Dim cmd As New SqlCommand(sql, cn)
                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                    cmd.Parameters.AddWithValue("@EXENTO", totalexentovalue)
                    'VERIFICO QUE SEA UNA COMPRA O UNA VENTA
                    If SelectedForm = "ENVIOS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Form1.txtVentasCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", varCosto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * varCosto)
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    End If
                    If SelectedForm = "VENTAS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Form1.txtVentasCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", varCosto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * varCosto)
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    End If
                    If SelectedForm = "LISTADOS" Then
                        cmd.Parameters.AddWithValue("@ID", item)
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalSelected_Coddoc)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", GlobalSelected_Correlativo)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", varCosto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * varCosto)
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    End If
                    If SelectedForm = "COTIZACIONES" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Form1.txtVentasCorrelativo.Text))
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", varCosto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * varCosto)
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    End If

                    cmd.Parameters.AddWithValue("@CODPROD", codprod)
                    cmd.Parameters.AddWithValue("@DESPROD", desprod)
                    cmd.Parameters.AddWithValue("@CODMEDIDA", Me.cmbUCMedida.Text)
                    cmd.Parameters.AddWithValue("@EQUIVALE", CType(Me.cmbUCMedida.SelectedValue, Integer))
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text))
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * CType(Me.cmbUCMedida.SelectedValue, Integer)))

                    cmd.ExecuteNonQuery()
                    cmd.Dispose()


                    'VERIFICO QUE SEA UNA COMPRA O UNA VENTA
                    If SelectedForm = "ENVIOS" Then
                        'If Integer.Parse(Me.txtUCCantidad.Text) > Integer.Parse(Me.lbExistenciaProducto.Text) Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Integer.Parse(Me.txtUCCantidad.Text) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
                        Form1.txtVentasCodProd.Text = ""
                        Form1.txtVentasCodProd.select()
                    End If
                    If SelectedForm = "VENTAS" Then
                        'If Integer.Parse(Me.txtUCCantidad.Text) > Integer.Parse(Me.lbExistenciaProducto.Text) Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Integer.Parse(Me.txtUCCantidad.Text) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
                        Form1.txtVentasCodProd.Text = ""
                        Form1.txtVentasCodProd.select()
                    End If
                    If SelectedForm = "COTIZACIONES" Then
                        Form1.txtVentasCodProd.Text = ""
                        Form1.txtVentasCodProd.select()
                    End If

                    result = True

                Catch ex As Exception
                    GlobalDesError = ex.ToString
                    result = False

                End Try
            End Using
        End If

        Return result

    End Function


    Private Function fcn_GuardarItem_OLD() As Boolean
        Dim result As Boolean

        Dim totalexentovalue As Double
        If VentasExento = 1 Then
            totalexentovalue = Double.Parse(Me.txtUCTotal.Text)
        Else
            totalexentovalue = 0
        End If

        If fcn_CrearMovimientoInventario(codprod, CType(Me.cmbUCMedida.SelectedValue, Integer)) = True Then

            Using cn As New SqlConnection(strSqlConectionString)

                Try

                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlCommand("INSERT INTO Temp_Ventas (EMPNIT,CODDOC,CORRELATIVO,CODPROD,DESPROD,CODMEDIDA,EQUIVALE,CANTIDAD,BONIF,TOTALBONIF,TOTALUNIDADES,COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,USUARIO,EXENTO) VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@CODPROD,@DESPROD,@CODMEDIDA,@EQUIVALE,@CANTIDAD,@BONIF,@TOTALBONIF,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@USUARIO,@EXENTO)", cn)
                    cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                    cmd.Parameters.AddWithValue("@EXENTO", totalexentovalue)
                    'VERIFICO QUE SEA UNA COMPRA O UNA VENTA
                    If SelectedForm = "ENVIOS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocENVIOS)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", varCosto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * varCosto)
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)

                    End If
                    If SelectedForm = "VENTAS" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddoc)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", varCosto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * varCosto)
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    End If
                    If SelectedForm = "COTIZACIONES" Then
                        cmd.Parameters.AddWithValue("@CODDOC", GlobalCoddocCOTIZ)
                        cmd.Parameters.AddWithValue("@PRECIO", Double.Parse(Me.txtUCPrecio.Text)) 'VentasPrecioProducto)
                        cmd.Parameters.AddWithValue("@COSTO", varCosto)
                        cmd.Parameters.AddWithValue("@TOTALPRECIO", Double.Parse(Me.txtUCTotal.Text))
                        cmd.Parameters.AddWithValue("@TOTALCOSTO", Double.Parse(Me.txtUCCantidad.Text) * varCosto)
                        cmd.Parameters.AddWithValue("@BONIF", 0)
                        cmd.Parameters.AddWithValue("@TOTALBONIF", 0)
                    End If

                    cmd.Parameters.AddWithValue("@CORRELATIVO", Double.Parse(Form1.txtVentasCorrelativo.Text))
                    cmd.Parameters.AddWithValue("@CODPROD", codprod)
                    cmd.Parameters.AddWithValue("@DESPROD", desprod)
                    cmd.Parameters.AddWithValue("@CODMEDIDA", Me.cmbUCMedida.Text)
                    cmd.Parameters.AddWithValue("@EQUIVALE", CType(Me.cmbUCMedida.SelectedValue, Integer))
                    cmd.Parameters.AddWithValue("@CANTIDAD", Double.Parse(Me.txtUCCantidad.Text))
                    cmd.Parameters.AddWithValue("@TOTALUNIDADES", (Double.Parse(Me.txtUCCantidad.Text) * CType(Me.cmbUCMedida.SelectedValue, Integer)))

                    cmd.ExecuteNonQuery()
                    cmd.Dispose()


                    'VERIFICO QUE SEA UNA COMPRA O UNA VENTA
                    If SelectedForm = "ENVIOS" Then
                        'If Integer.Parse(Me.txtUCCantidad.Text) > Integer.Parse(Me.lbExistenciaProducto.Text) Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Integer.Parse(Me.txtUCCantidad.Text) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
                        Form1.txtVentasCodProd.Text = ""
                        Form1.txtVentasCodProd.select()
                    End If
                    If SelectedForm = "VENTAS" Then
                        'If Integer.Parse(Me.txtUCCantidad.Text) > Integer.Parse(Me.lbExistenciaProducto.Text) Then Call Form1.EnviarNotificacionesEmail(4, "Ares te informa: Venta sin existencia", "Se intentó vender el producto " & VentasCodProducto & " " & Me.lbUCDesProducto.Text & ", existen " & Me.lbExistenciaProducto.Text & " y se solicitan " & (Integer.Parse(Me.txtUCCantidad.Text) * VentasEquivale).ToString & " mediante el usuario " & GlobalNomUsuario)
                        Form1.txtVentasCodProd.Text = ""
                        Form1.txtVentasCodProd.select()
                    End If
                    If SelectedForm = "COTIZACIONES" Then
                        Form1.txtVentasCodProd.Text = ""
                        Form1.txtVentasCodProd.select()
                    End If

                    result = True

                Catch ex As Exception
                    GlobalDesError = ex.ToString
                    result = False

                End Try
            End Using
        End If

        Return result

    End Function




    Dim objInventario As New classInventario(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)


    Private Function fcn_CrearMovimientoInventario(ByVal VentasCodProducto As String, ByVal VentasEquivale As Integer) As Boolean

        Dim result As Boolean

        Try

            Select Case SelectedForm
                Case "VENTAS" 'SI ES UNA VENTA CREO UNA SALIDA DE INVENTARIO 
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                        result = True
                    Else
                        result = False
                    End If

                Case "LISTADOS"
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                        result = True
                    Else
                        result = False
                    End If


                Case "ENVIOS" 'SI SON PEDIDOS ACTUAN COMO LAS VENTAS
                    If objInventario.fcn_InsertarSalidaProducto(VentasCodProducto, (Double.Parse(Me.txtUCCantidad.Text) * VentasEquivale)) = True Then
                        result = True
                    Else
                        result = False
                    End If
                Case "COTIZACIONES"
                    result = True
            End Select

        Catch ex As Exception
            MsgBox("Error al crear el movimiento de inventario: " & ex.ToString)
            result = False
        End Try

        Return result

    End Function


    Private Function fcn_ObtenerDatosItem(ByVal item As Integer) As Boolean
        Dim result As Boolean

        Call AbrirConexionSql()

        Try
            Dim cmd As New SqlCommand("SELECT CODPROD, DESPROD, CODMEDIDA, CANTIDAD, COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO, EQUIVALE, TOTALUNIDADES FROM TEMP_VENTAS WHERE ID=@ID", cn)
            cmd.Parameters.AddWithValue("@ID", item)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()

            If dr.HasRows Then
                codprod = dr(0).ToString
                desprod = dr(1).ToString
                codmedida = dr(2).ToString
                cantidad = CType(dr(3), Double)
                costo = CType(dr(4), Double)
                precio = CType(dr(5), Double)
                totalCosto = CType(dr(6), Double)
                totalPrecio = CType(dr(7), Double)
                equivale = CType(dr(8), Integer)
                constTotalUnidades = CType(dr(9), Double)
            End If

            dr.Close()
            cmd.Dispose()

            Dim cmde As New SqlCommand("select exento from productos where empnit=@EMPNIT AND CODPROD=@CODPROD", cn)
            cmde.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmde.Parameters.AddWithValue("@CODPROD", codprod)
            Dim dre As SqlDataReader = cmde.ExecuteReader
            dre.Read()

            If dre.HasRows Then
                VentasExento = Integer.Parse(dre(0).ToString)
            End If

            dre.Close()
            cmde.Dispose()

            result = True

        Catch ex As Exception
            result = False
            'MsgBox("Datos no cargados.. " & ex.ToString)
        End Try

        cn.Close()

        Return result

    End Function


    Private Function fcn_ObtenerPrecioCosto(ByVal varcodmedida As String) As Boolean
        Dim result As Boolean

        Call AbrirConexionSql()
        'DETERMINA EL TIPO DE PRECIO SEGÚN CLIENTE
        Dim tipoprecio As String
        Select Case Form1.lbVentasTipoPrecio.Text
            Case "PUBLICO"
                tipoprecio = "PRECIOS.PRECIO"
            Case "MAYOREO A"
                tipoprecio = "PRECIOS.MAYOREOA"
            Case "MAYOREO B"
                tipoprecio = "PRECIOS.MAYOREOB"
            Case "MAYOREO C"
                tipoprecio = "PRECIOS.MAYOREOC"
            Case Else
                tipoprecio = "PRECIOS.PRECIO"

        End Select

        Try
            Dim cmd As New SqlCommand("SELECT COSTO, " & tipoprecio & " FROM PRECIOS WHERE CODPROD=@CODPROD AND EMPNIT=@EMPNIT AND CODMEDIDA=@CODMEDIDA", cn)
            cmd.Parameters.AddWithValue("@CODMEDIDA", varcodmedida)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                varCosto = CType(dr(0), Double)
                varPrecio = CType(dr(1), Double)
            End If
            dr.Close()
            cmd.Dispose()

            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False

        End Try

        cn.Close()

        Return result

    End Function


    Private Function fcn_CargarMedidas() As Boolean

        Dim result As Boolean
        Call AbrirConexionSql()

        Try

            Dim cmd As New SqlCommand("SELECT CODMEDIDA,EQUIVALE FROM PRECIOS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD", cn)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            cmd.Parameters.AddWithValue("@EMPNIT", empnit)

            Dim Dt As DataTable
            Dim Da As New SqlDataAdapter
            Da.SelectCommand = cmd
            Dt = New DataTable
            Da.Fill(Dt)

            With cmbUCMedida
                .DataSource = Dt
                .DisplayMember = "CODMEDIDA"
                .ValueMember = "EQUIVALE"
            End With
            cmd.Dispose()

            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        cn.Close()

        Return result

    End Function


    ''' <summary>
    ''' Elimina un item de la tabla temporal de documentos
    ''' </summary>
    ''' <param name="idItem"></param>
    ''' <returns></returns>
    Private Function fcn_eliminar_item_documento(ByVal idItem As Integer) As Boolean

        Call AbrirConexionSql()
        Dim result As Boolean



        Try

            If SelectedForm = "COTIZACIONES" Then
                'elimina el registro de la tabla temporal
                Dim SQL As String
                SQL = "DELETE FROM TEMP_VENTAS WHERE ID=" & idItem

                Dim cmd As New SqlCommand(SQL, cn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()

                result = True

            Else

                If objInventario.fcn_RegresarSalidaProducto(codprod, constTotalUnidades) = True Then

                    'elimina el registro de la tabla temporal
                    Dim SQL As String
                    SQL = "DELETE FROM TEMP_VENTAS WHERE ID=" & idItem

                    Dim cmd As New SqlCommand(SQL, cn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    result = True

                Else
                    result = False
                End If
            End If



        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        cn.Close()

        Return result

    End Function


    Private Function fcn_CargarCostoPrecioMed() As Boolean

        Call AbrirConexionSql()

        Dim result As Boolean

        'DETERMINA EL TIPO DE PRECIO SEGÚN CLIENTE
        Dim tipoprecio As String
        Select Case Form1.lbVentasTipoPrecio.Text
            Case "PUBLICO"
                tipoprecio = "PRECIOS.PRECIO"
            Case "MAYOREO A"
                tipoprecio = "PRECIOS.MAYOREOA"
            Case "MAYOREO B"
                tipoprecio = "PRECIOS.MAYOREOB"
            Case "MAYOREO C"
                tipoprecio = "PRECIOS.MAYOREOC"
            Case Else
                tipoprecio = "PRECIOS.PRECIO"

        End Select

        Try
            Dim cmd As New SqlCommand("SELECT COSTO," & tipoprecio & " FROM PRECIOS WHERE EMPNIT=@EMPNIT AND CODPROD=@CODPROD AND CODMEDIDA=@CODMEDIDA", cn)
            cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
            cmd.Parameters.AddWithValue("@CODPROD", codprod)
            cmd.Parameters.AddWithValue("@CODMEDIDA", Me.cmbUCMedida.Text)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader
            dr.Read()
            Try
                If dr.HasRows Then
                    equivale = Integer.Parse(Me.cmbUCMedida.SelectedValue)
                    codmedida = Me.cmbUCMedida.Text
                    varCosto = Double.Parse(dr(0))
                    varPrecio = Double.Parse(dr(1))
                    Me.txtUCPrecio.Text = FormatNumber(varPrecio, 2)
                    Me.txtUCTotal.Text = FormatNumber(varPrecio * Double.Parse(Me.txtUCCantidad.Text), 2)
                End If
            Catch ex As Exception
            End Try
            dr.Close()
            cmd.Dispose()

            result = True

        Catch ex As Exception
            GlobalDesError = ex.ToString
            result = False
        End Try

        cn.Close()

        Return result

    End Function

#End Region



End Class
