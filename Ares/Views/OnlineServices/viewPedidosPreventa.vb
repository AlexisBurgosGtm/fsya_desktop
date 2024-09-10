Imports DevExpress.XtraSplashScreen

Public Class viewPedidosPreventa
    Private Sub viewPedidosPreventa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtFechaFacturas.DateTime = Today.Date




        Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)
        If objGen.fcnTestConection = True Then
            Call CargarCombobox()
        Else
            MsgBox("No hay una conexión estable a la nube, inténtelo más tarde o verifique su conexión a internet")
            Exit Sub
        End If



    End Sub

    Private Sub btnRecargar_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)
        If objGen.fcnTestConection = True Then
            Call CargarCombobox()
            'Call CargarGrid()
        Else
            MsgBox("No hay una conexión estable a la nube, inténtelo más tarde o verifique su conexión a internet")
            Exit Sub
        End If


    End Sub

    Private Sub CargarGrid()

        'ventana de carga
        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try

            Dim objGeneral As New classGeneralHost(strSqlConectionString, strHostConectionString)
            Me.GridPedidos.DataSource = Nothing
            Me.GridPedidos.DataSource = objGeneral.tblPedidosPicking(GlobalEmpNit, CType(Me.cmbVendedor.SelectedValue, Integer), Me.cmbEmbarque.SelectedValue.ToString)

            Me.lbEmbarqueActual.Text = Me.cmbEmbarque.SelectedValue.ToString & " - " & Me.cmbVendedor.Text

        Catch ex As Exception
            MsgBox("No se pudo cargar el listado de pedidos pendientes. Error: " & ex.ToString)
        End Try

        SplashScreenManager.CloseForm()

    End Sub

    Private Sub CargarCombobox()

        Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)

        'COMBOBOXES LOCALES
        With Me.cmbCoddocGenerar
            .DataSource = objGen.tblCoddoc("FAC")
            .ValueMember = "CORRELATIVO"
            .DisplayMember = "CODDOC"
        End With

        Try
            'COMBOBOXES HOSTING
            With Me.cmbVendedor
                .DataSource = objGen.tblVendedores(GlobalEmpNit)
                .ValueMember = "CODVEN"
                .DisplayMember = "NOMVEN"
            End With

            With Me.cmbEmbarque
                .DataSource = objGen.tblEmbarques(GlobalEmpNit)
                .ValueMember = "CODEMBARQUE"
                .DisplayMember = "DESRUTA"
            End With

        Catch ex As Exception

        End Try

    End Sub


#Region " ** MODULO FACTURADOR ** "

    Private Sub btnGenerarPedidos_Click(sender As Object, e As EventArgs) Handles btnGenerarPedidos.Click

        If Me.lbEmbarqueActual.Text = "--" Then
            MsgBox("Primero debe cargar un Embarque")
        Else
            If Confirmacion("¿Está seguro que desea generar los pedidos de este vendedor?", Me.ParentForm) = True Then

                'inicia el proceso
                Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)
                If objGen.fcnTestConection = True Then
                Else
                    MsgBox("No hay una conexión estable a la nube, inténtelo más tarde o verifique su conexión a internet")
                    Exit Sub
                End If

                'ventana de carga
                SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)




                'genera el listado de pedidos del vendedor seleccionado
                If objGen.generarPedidosVendedor(GlobalEmpNit, Integer.Parse(Me.cmbVendedor.SelectedValue), Me.cmbEmbarque.SelectedValue.ToString, Me.cmbCoddocGenerar.Text, CType(Me.cmbCoddocGenerar.SelectedValue, Integer), Me.txtFechaFacturas.DateTime) = True Then

                    'CAMBIA EL PEDIDO A FACTURACION
                    If objGen.changePedFac(Me.cmbCoddocGenerar.Text, Me.txtFechaFacturas.DateTime) = True Then
                        Form1.Mensaje("Pedidos transformados a Factura")
                    Else
                        Form1.Mensaje("No se pudo generar las facturas")
                    End If


                    'cambia el ISCENVIADO a 1 para que no aparezcan otra vez en el HOST
                    If objGen.setPedidosGenerados(GlobalEmpNit, Integer.Parse(Me.cmbVendedor.SelectedValue), Me.cmbEmbarque.SelectedValue.ToString) = True Then
                        Form1.Mensaje("Pedidos generados exitosamente!!")
                    Else
                        Form1.Mensaje("Se generaron los pedidos, pero no se pudo cambiar el status de los mismos, inténtelo manualmente")
                    End If

                Else
                    Form1.Mensaje("No se pudo generar los pedidos")
                End If
                'finaliza el proceso

                'cierra la ventana de carga
                SplashScreenManager.CloseForm()

                Me.btnCancelarGrid.PerformClick()

            End If

        End If
    End Sub

    Private Sub btnCargarGrid_Click(sender As Object, e As EventArgs) Handles btnCargarGrid.Click
        Call CargarGrid()
        Me.btnCargarGrid.Enabled = False
        Me.cmbEmbarque.Enabled = False
        Me.cmbVendedor.Enabled = False

    End Sub

    Private Sub btnCancelarGrid_Click(sender As Object, e As EventArgs) Handles btnCancelarGrid.Click
        Me.GridPedidos.DataSource = Nothing

        Me.btnCargarGrid.Enabled = True
        Me.cmbEmbarque.Enabled = True
        Me.cmbVendedor.Enabled = True

        Me.lbEmbarqueActual.Text = "--"

    End Sub





#End Region






#Region " ** SUBIDA DE DATOS ** "

    Private Sub btnGetCenso_Click(sender As Object, e As EventArgs) Handles btnGetCenso.Click

        'MsgBox("Opción no disponible de momento, pronto podrás usarla")
        'Exit Sub

        If Confirmacion("¿Está seguro que desea Crear los clientes del censo?", Me.ParentForm) = True Then
            Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)
            If objGen.getGenerarCenso() = True Then
                Call Aviso("EXITO", "Censo generado exitosamente", Me.ParentForm)
            Else
                MsgBox("No se pudo generar. Error: " + objGen.strError)
            End If

        End If
    End Sub

    Private Sub btnUploadProductosLocal_Click(sender As Object, e As EventArgs) Handles btnUploadProductosLocal.Click

        If Confirmacion("¿Está seguro que desea subir su CATÁLOGO DE PRODUCTOS Y PRECIOS ?", Me.ParentForm) = True Then
            Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)

            SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            'subiendo marcas
            If objGen.delMarcas() = True Then
                If objGen.postMarcas() = True Then
                    Form1.Mensaje("MARCAS subidas con éxito")
                Else
                    Form1.Mensaje("No se subieron las marcas")
                End If
            End If

            'subiendo productos
            If objGen.delProductosLocal = True Then
                If objGen.postProductosLocal() = True Then
                    Form1.Mensaje("PRODUCTOS subidos con éxito")
                Else
                    Form1.Mensaje("No se subieron los PRODUCTOS")
                End If
            End If

            'subiendo precios
            If objGen.delPreciosLocal = True Then
                If objGen.postPreciosLocal() = True Then
                    Form1.Mensaje("PRECIOS subidos con éxito")
                Else
                    Form1.Mensaje("No se subieron los PRECIOS")
                End If
            End If

            SplashScreenManager.CloseForm()

        End If
    End Sub

    Private Sub btnUploadEmbarques_Click(sender As Object, e As EventArgs) Handles btnUploadEmbarques.Click

        If Confirmacion("¿Está seguro que desea subir los EMBARQUES?", Me.ParentForm) = True Then
            Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)

            SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            'subiendo los embarques
            If objGen.delEmbarques() = True Then
                If objGen.postEmbarques() = True Then
                    Form1.Mensaje("EMBARQUES subidos con éxito")
                Else
                    Form1.Mensaje("No se subieron los EMBARQUES")
                End If
            End If

            SplashScreenManager.CloseForm()

        End If

    End Sub

    Private Sub btnUploadClientes_Click(sender As Object, e As EventArgs) Handles btnUploadClientes.Click

        If Confirmacion("¿Está seguro que desea subir su catálogo de clientes?", Me.ParentForm) = True Then
            Dim objGen As New classGeneralHost(strSqlConectionString, strHostConectionString)

            SplashScreenManager.ShowForm(Me.ParentForm, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

            'subiendo clientes
            If objGen.delClientes() = True Then
                If objGen.postClientes() = True Then
                    Form1.Mensaje("CLIENTES subidos con éxito")
                Else
                    Form1.Mensaje("No se subieron las CLIENTES")
                End If
            End If

            SplashScreenManager.CloseForm()

        End If

    End Sub





#End Region




End Class
