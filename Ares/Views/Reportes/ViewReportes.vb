Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen

Public Class ViewReportes

    Private Sub sock()
        Dim socket As New SocketIOClient.Client("http://192.168.0.100:7777")
        socket.Connect()

        socket.Emit("orden nueva", "hola mundo")

        socket.On("orden nueva", Function(data) msg(data.MessageText))

    End Sub

    Private Function msg(ByVal datos As String) As Boolean
        Dim result As Boolean
        MsgBox("hola socket " & datos)
        Return result
    End Function


    Dim objReports As New ClassReports

    Private Sub ViewReportes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSUCURSALES
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

        Me.txtReportesFechaInicial.DateTime = Today.Date
        Me.txtReportesFechaFinal.DateTime = Today.Date

    End Sub


    Private Sub cmdBiVentasDocumento_Click(sender As Object, e As EventArgs) Handles cmdBiVentasDocumento.Click
        Call AbrirReporte_VentasDocumento(Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime)
    End Sub

    Private Sub cmdBiVentasClaseDos_Click(sender As Object, e As EventArgs)
        If Me.txtReportesFechaInicial.DateTime.Year = Me.txtReportesFechaFinal.DateTime.Year Then
            If Me.txtReportesFechaInicial.DateTime.Month <= Me.txtReportesFechaFinal.DateTime.Month Then

                Call AbrirReporte_VentaClaseDos(Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime, 2)

            Else
                Call Aviso("Imposible", "No es posible seleccionar una fecha final menor a la fecha inicial", Me.ParentForm)
            End If
        Else
            Call Aviso("No Recomendado", "Para garantizar la eficiencia de los reportes, solo se pueden operar en el mismo año", Me.ParentForm)
        End If
    End Sub

    Private Sub cmdBiVentasVendedor_Click(sender As Object, e As EventArgs)
        If Me.txtReportesFechaInicial.DateTime.Year = Me.txtReportesFechaFinal.DateTime.Year Then
            If Me.txtReportesFechaInicial.DateTime.Month <= Me.txtReportesFechaFinal.DateTime.Month Then

                Call AbrirReporte_VentasVendedor(Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime, 2)

            Else
                Call Aviso("Imposible", "No es posible seleccionar una fecha final menor a la fecha inicial", Me.ParentForm)
            End If
        Else
            Call Aviso("No Recomendado", "Para garantizar la eficiencia de los reportes, solo se pueden operar en el mismo año", Me.ParentForm)
        End If
    End Sub

    Private Sub cmdBiComprasFechas_Click(sender As Object, e As EventArgs) Handles cmdBiComprasFechas.Click
        If Me.txtReportesFechaInicial.DateTime.Year = Me.txtReportesFechaFinal.DateTime.Year Then
            If Me.txtReportesFechaInicial.DateTime.Month <= Me.txtReportesFechaFinal.DateTime.Month Then

                Call AbrirReporte_ComprasFechas(Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime)

            Else
                Call Aviso("Imposible", "No es posible seleccionar una fecha final menor a la fecha inicial", Me.ParentForm)
            End If
        Else
            Call Aviso("No Recomendado", "Para garantizar la eficiencia de los reportes, solo se pueden operar en el mismo año", Me.ParentForm)
        End If

    End Sub

    Private Sub cmdBiVentasProducto_Click(sender As Object, e As EventArgs) Handles btnVentasProducto.Click
        If Me.txtReportesFechaInicial.DateTime.Year = Me.txtReportesFechaFinal.DateTime.Year Then
            If Me.txtReportesFechaInicial.DateTime.Month <= Me.txtReportesFechaFinal.DateTime.Month Then

                Call AbrirReporte_VentasProductos(Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime)

            Else
                Call Aviso("Imposible", "No es posible seleccionar una fecha final menor a la fecha inicial", Me.ParentForm)
            End If
        Else
            Call Aviso("No Recomendado", "Para garantizar la eficiencia de los reportes, solo se pueden operar en el mismo año", Me.ParentForm)
        End If

    End Sub

    Private Sub cmdBiVentasMarca_Click(sender As Object, e As EventArgs) Handles cmdBiVentasMarca.Click
        If Me.txtReportesFechaInicial.DateTime.Year = Me.txtReportesFechaFinal.DateTime.Year Then
            If Me.txtReportesFechaInicial.DateTime.Month <= Me.txtReportesFechaFinal.DateTime.Month Then

                Call AbrirReporte_VentasMarcas(Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime)

            Else
                Call Aviso("Imposible", "No es posible seleccionar una fecha final menor a la fecha inicial", Me.ParentForm)
            End If
        Else
            Call Aviso("No Recomendado", "Para garantizar la eficiencia de los reportes, solo se pueden operar en el mismo año", Me.ParentForm)
        End If


    End Sub

    Private Sub TileReportesDesign_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileReportesDesign.ItemClick
        ReportDesigner.Show()

    End Sub

    Private Sub TileReportesVarios_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileReportesVarios.ItemClick
        Me.NavFrameReports.SelectedPage = NP_varios
    End Sub



    Private Sub btnVentasVendedorCarta_Click(sender As Object, e As EventArgs) Handles btnVentasVendedorCarta.Click
        Dim objReportes As New ClassReports()
        If objReportes.rptVentasVendedor(GlobalEmpNit, Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime) = True Then
        Else
            MsgBox(GlobalDesError)
        End If

    End Sub

    Private Sub btnSync_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        Dim objSync As New classSync

        SplashScreenManager.ShowForm(Me, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        If objSync.JsonClientes(GlobalEmpNit, True) = True Then
            Call Form1.Mensaje("Clientes generados existosamente")
        End If

        If objSync.JSONProductos(GlobalAnioProceso, GlobalMesProceso, GlobalEmpNit, True) = True Then
            Call Form1.Mensaje("Productos generados existosamente")
        End If

        If objSync.JSONVentasMes(GlobalAnioProceso, GlobalMesProceso, GlobalEmpNit, True) = True Then
            Call Form1.Mensaje("Ventas generadas existosamente")
        End If

        If objSync.JSONVentasVendedor(GlobalAnioProceso, GlobalMesProceso, GlobalEmpNit, True) = True Then
            Call Form1.Mensaje("Ventas por vendedor generadas existosamente")
        End If

        SplashScreenManager.CloseForm()
    End Sub

    Private Sub btnRptVtaClientes_Click(sender As Object, e As EventArgs) Handles btnRptVtaClientes.Click
        Dim objReportes As New ClassReports()
        If objReportes.rptVentasClientes(GlobalEmpNit, Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime) = True Then
        Else
            MsgBox("Error al cargar reporte. " & GlobalDesError)
        End If

    End Sub

    Private Sub btnRptVentasRepartidor_Click(sender As Object, e As EventArgs) Handles btnRptVentasRepartidor.Click
        Dim objReportes As New ClassReports()


    End Sub

    Private Sub btnReporteGeneral_Click(sender As Object, e As EventArgs) Handles btnReporteGeneral.Click
        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try

            Dim objReportes As New ClassReports
            Me.GridReportes.DataSource = Nothing
            Me.GridReportes.DataSource = objReportes.ReporteGeneral(GlobalEmpNit, Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime)
            Dim path As String = Application.StartupPath + "\EXPORTS\ReporteVentasGeneral.xlsx"
            Me.GridReportes.ExportToXlsx(path)
            Process.Start(path)

        Catch ex As Exception
            MsgBox("No se pudo generar el Reporte: " & GlobalDesError)
        End Try

        SplashScreenManager.CloseForm()

    End Sub

    Private Sub btnDocumentosExentos_Click(sender As Object, e As EventArgs) Handles btnDocumentosExentos.Click

        SplashScreenManager.ShowForm(Form1, GeneralWaitForm.GetType, True, True, ParentFormState.Locked)

        Try

            Dim objReportes As New ClassReports
            Me.GridReportes.DataSource = Nothing
            Me.GridReportes.DataSource = objReportes.tblRptExentos(GlobalEmpNit, Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime)
            Dim path As String = Application.StartupPath + "\EXPORTS\ReporteDeFacturacion.xlsx"
            Me.GridReportes.ExportToXlsx(path)
            Process.Start(path)

        Catch ex As Exception
            MsgBox("No se pudo generar el Reporte: " & GlobalDesError)
        End Try

        SplashScreenManager.CloseForm()
    End Sub

    Private Sub btnRptGastos_Click(sender As Object, e As EventArgs) Handles btnRptGastos.Click
        Dim objReportes As New ClassReports()
        If objReportes.rptGastosFechas(GlobalEmpNit, Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime) = True Then
        Else
            MsgBox("Error al cargar reporte. " & GlobalDesError)
        End If
    End Sub
    Private Sub TileReportesQry_ItemClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs) Handles TileReportesQry.ItemClick
        Me.NavFrameReports.SelectedPage = NP_Pivot
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        If Me.txtQry.Text <> "" Then
            'Me.GridDocumentosExports.DataSource = Nothing
            Dim tbl As New DataTable

            Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
                Try

                    If cn.State <> ConnectionState.Open Then
                        cn.Open()
                    End If

                    Dim cmd As New SqlCommand(Me.txtQry.Text, cn)
                    Dim da As New SqlDataAdapter
                    da.SelectCommand = cmd
                    da.Fill(tbl)

                    Me.GridDocumentosExports.DataSource = tbl
                    'Me.GridDocumentosExports.Refresh()

                Catch ex As Exception
                    MsgBox("Error al generar consulta. Error: " & ex.ToString)
                End Try
            End Using
        Else
            Call Aviso("NO PERMITIDO", "Debe escribir una consulta válida", Form1)
        End If
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        Try
            Dim archivo As String = Application.StartupPath + "\EXPORTS\" + "consulta.xlsx"
            Me.GridDocumentosExports.ExportToXlsx(archivo)
            Process.Start(archivo)
        Catch ex As Exception
            MsgBox("No se pudo exportar. Error: " + ex.ToString)
        End Try
    End Sub

    Private Sub btnRptVentasProductoVendedor_Click(sender As Object, e As EventArgs) Handles btnRptVentasProductoVendedor.Click
        MsgBox("Reporte aún No disponible")
    End Sub

    Private Sub btnRptVentasVendedorProductoExcel_Click(sender As Object, e As EventArgs) Handles btnRptVentasVendedorProductoExcel.Click
        MsgBox("Reporte aún No disponible")
    End Sub

    Private Sub btnRptFEL_Click(sender As Object, e As EventArgs) Handles btnRptFEL.Click

        If Me.txtReportesFechaInicial.DateTime.Year = Me.txtReportesFechaFinal.DateTime.Year Then
            If Me.txtReportesFechaInicial.DateTime.Month <= Me.txtReportesFechaFinal.DateTime.Month Then
                Dim objReportes As New ClassReports
                Me.GridExportarFEL.DataSource = objReportes.tblFacturasElectronicas(GlobalEmpNit, Me.txtReportesFechaInicial.DateTime, Me.txtReportesFechaFinal.DateTime)
                Dim path As String = Application.StartupPath + "\EXPORTS\ReporteDeFacturacionElectronica.xlsx"
                Me.GridExportarFEL.ExportToXlsx(path)
                Process.Start(path)

            Else
                Call Aviso("Imposible", "No es posible seleccionar una fecha final menor a la fecha inicial", Me.ParentForm)
            End If
        Else
            Call Aviso("No Recomendado", "Para garantizar la eficiencia de los reportes, solo se pueden operar en el mismo año", Me.ParentForm)
        End If

    End Sub

    Private Sub btnRptVVendedor_Click(sender As Object, e As EventArgs) Handles btnRptVVendedor.Click

        If Me.txtReportesFechaInicial.DateTime.Year = Me.txtReportesFechaFinal.DateTime.Year Then
            If Me.txtReportesFechaInicial.DateTime.Month <= Me.txtReportesFechaFinal.DateTime.Month Then

                'Call rptvendedor()




            Else
                Call Aviso("Imposible", "No es posible seleccionar una fecha final menor a la fecha inicial", Me.ParentForm)
            End If
        Else
            Call Aviso("No Recomendado", "Para garantizar la eficiencia de los reportes, solo se pueden operar en el mismo año", Me.ParentForm)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim objS As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token)
        Call objS.fcnSendDataVendidosVPN(Me.cmbSUCURSALES.SelectedValue.ToString, Integer.Parse(Me.TextBox1.Text), Integer.Parse(Me.TextBox2.Text))


    End Sub

    'Private Sub rptvendedor()
    'Dim tblvendedor As New DataTable
    'Using cn As New SqlConnection(strSqlConectionString) 'cn es el objeto de conexion a sql server, strsqlconecction es la cadena de conexion
    'If cn.State <> ConnectionState.Open Then 'primero verifica si el estado de conexion esta abierto y si no lo abre
    'cn.Open()
    'End If
    'Dim cmd As New SqlCommand(Me.txtSQL.Text, cn) 'cmd es el objeto de comando sql que entre comillas va la query y luego llamamos a la conexion 
    'Dim da As New SqlDataAdapter
    'da.SelectCommand = cmd
    'da.Fill(tblvendedor)
    'Me.DGvPRUEBA.DataSource = tblvendedor
    'Me.DGvPRUEBA.Refresh()
    'End Usin
    'End Sub

End Class
