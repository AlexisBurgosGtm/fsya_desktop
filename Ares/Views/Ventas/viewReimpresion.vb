Imports System.Data.SqlClient
Imports DevExpress
Imports DevExpress.XtraBars.Docking2010.Customization
Imports DevExpress.XtraGrid.Views.Tile
Imports DevExpress.XtraGrid.Views.Tile.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class viewReimpresion

    Private Sub ViewReimpresionas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarMesProceso()
        Call CargarTipoDocumentos()

        Me.txtDatePickInicial.Value = Today.Date

        Call CargarGrid()

    End Sub

    Private Sub CargarGrid()
        Me.GridListados.DataSource = Nothing
        Me.GridListados.DataSource = tblDocumentos(Me.cmbTipoDocumento.SelectedValue.ToString)
    End Sub

    Private Sub CargarTipoDocumentos()

        Dim objtTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
        With Me.cmbTipoDocumento
            .DataSource = objtTipoDoc.tblTipos2()
            .ValueMember = "TIPO"
            .DisplayMember = "DESCRIPCION"
        End With

    End Sub

    Dim GlobalTipoDoc As String

    Private Function tblDocumentos(ByVal tipodoc As String) As DataTable
        Dim tbl As New DSDOCUMENTOS.tblDocumentosDataTable

        Dim sql As String

        Select Case tipodoc

            Case "FEF"
                sql = "SELECT DOCUMENTOS.EMPNIT, 
DOCUMENTOS.CODDOC, 
DOCUMENTOS.CORRELATIVO, 
                        DOCUMENTOS.FECHA,
DOCUMENTOS.DOC_NIT AS NIT,
DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                        DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE,
DOCUMENTOS.MARCA AS MARCA, 
DOCUMENTOS.TOTALCOSTO, 
                        DOCUMENTOS.TOTALPRECIO, 
DOCUMENTOS.TOTALTARJETA,
CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, 
                        DOCUMENTOS.CONCRE,
DOCUMENTOS.STATUS AS ST, 
DOCUMENTOS.ID, 
                        DOCUMENTOS.CODCLIENTE, 
FEL_UUDI AS DOCREF,
CODCAJA
                                            FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                            WHERE (DOCUMENTOS.FECHA = @DP) AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT)"

            Case "FAC"
                sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                                            DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA AS MARCA, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, DOCUMENTOS.CODCLIENTE,
                                            CONCAT(DOCUMENTOS.SERIEFAC,'-',DOCUMENTOS.NOFAC) AS DOCREF, CODCAJA
                                            FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                            WHERE (DOCUMENTOS.FECHA = @DP)  AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT)"

            Case "TSS" 'TRASLADOS SALIDA SUCURSAL / AGREGADO DESTINO
                sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, 
                        DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                        DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA AS MARCA, DOCUMENTOS.TOTALCOSTO, 
                        DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, 
                        DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, 
                        DOCUMENTOS.CODCLIENTE, DOCUMENTOS.CODEMBARQUE AS DOCREF, CODCAJA
                       FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                       WHERE (DOCUMENTOS.FECHA = @DP)  AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT)"
            Case "TIN" 'TRASLADOS ENTRADA BODEGA / AGREGADO ORIGEN /CODEMBARQUE
                sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, 
                        DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                        DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA AS MARCA, DOCUMENTOS.TOTALCOSTO, 
                        DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, 
                        DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, 
                        DOCUMENTOS.CODCLIENTE, DOCUMENTOS.CODEMBARQUE AS DOCREF, CODCAJA
                       FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                       WHERE (DOCUMENTOS.FECHA = @DP)  AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT)"

            Case "TES" 'TRASLADOS ENTRADA SUCURSAL / AGREGADO ORIGEN /CODEMBARQUE
                sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, 
                        DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                        DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA AS MARCA, DOCUMENTOS.TOTALCOSTO, 
                        DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, 
                        DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, 
                        DOCUMENTOS.CODCLIENTE, DOCUMENTOS.CODEMBARQUE AS DOCREF, CODCAJA
                       FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                       WHERE (DOCUMENTOS.FECHA = @DP)  AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT)"

            Case "COR"
                sql = "SELECT EMPNIT, 'CORTE' AS CODDOC,CORRELATIVO, FECHA, 'SN' AS NIT, 'SN' AS NOMCLIENTE, 'SN' AS DIRCLIENTE, 'SN' AS MARCA, TOTALCOSTO, TOTALVENTA AS TOTALPRECIO, TOTALTARJETA,CONCAT(HORA,':',MINUTO) AS HORAMINUTO, 'CON' AS CONCRE, 'O' AS ST, ID, 0 AS CODCLIENTE,'SN' AS DOCREF, CODCAJA
                        FROM CORTES
                        WHERE (FECHA = @DP) AND (EMPNIT = @EMPNIT)"

            Case "FNC"
                sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                                            DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA AS MARCA, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, DOCUMENTOS.CODCLIENTE,
                                           FEL_UUDI AS DOCREF, CODCAJA
                                            FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                             WHERE (DOCUMENTOS.FECHA = @DP)  AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT)"

            Case Else
                sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                                            DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA AS MARCA, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, DOCUMENTOS.CODCLIENTE,
                                            CONCAT(DOCUMENTOS.SERIEFAC,'-',DOCUMENTOS.NOFAC) AS DOCREF, CODCAJA
                                            FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                             WHERE (DOCUMENTOS.FECHA = @DP)  AND (TIPODOCUMENTOS.TIPODOC = @TIPODOC) AND (DOCUMENTOS.EMPNIT = @EMPNIT)"

        End Select

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                If tipodoc <> "ORT" Then
                    cmd.Parameters.AddWithValue("@TIPODOC", Me.cmbTipoDocumento.SelectedValue.ToString)
                End If
                cmd.Parameters.AddWithValue("@DP", Date.Parse(Me.txtDatePickInicial.Value))
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception
                MsgBox(ex.ToString)
                tbl = Nothing
            End Try
        End Using

        Return tbl

    End Function


    Private Sub cmbTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDocumento.SelectedIndexChanged
        Try
            GlobalTipoDoc = Me.cmbTipoDocumento.SelectedValue.ToString

            Me.GridListados.DataSource = Nothing
            Me.GridListados.DataSource = tblDocumentos(Me.cmbTipoDocumento.SelectedValue.ToString)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtDatePickInicial_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtDatePickInicial.ValueChanged

        Try
            GlobalTipoDoc = Me.cmbTipoDocumento.SelectedValue.ToString

            Me.GridListados.DataSource = Nothing
            Me.GridListados.DataSource = tblDocumentos(Me.cmbTipoDocumento.SelectedValue.ToString)

        Catch ex As Exception

        End Try

    End Sub

    Dim drw As DataRow
    Private Sub GridViewListados_FocusedRowChanged(sender As Object, e As XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewListados.FocusedRowChanged
        Try

            drw = Nothing
            drw = Me.GridViewListados.GetFocusedDataRow

            Call CargarDatos(drw)

        Catch ex As Exception

        End Try
    End Sub

    Dim SelectedUUDI As String = ""

    Private Sub CargarDatos(ByVal dr As DataRow)

        SelectedFecha = Date.Parse(dr.Item(3))
        SelectedCoddoc = dr.Item(1).ToString
        SelectedCorrelativo = CType(dr.Item(2), Double)
        SelectedStatusDoc = dr.Item(13).ToString
        SelectedNitCliente = dr.Item(4).ToString
        SelectedNomCliente = dr.Item(5).ToString
        SelectedCosto = CType(dr.Item(8), Double)
        SelectedPr = CType(dr.Item(9), Double)
        SelectedUUDI = dr.Item(16).ToString


    End Sub

    Private Sub GridViewListados_DoubleClick(sender As Object, e As EventArgs) Handles GridViewListados.DoubleClick

        Call CargarDatos(drw)
        Me.RadialMenuListados.ShowPopup(MousePosition)

    End Sub

#Region " *** RADIAL MENU *** "

    Dim SelectedStatusDoc As String
    Dim SelectedNitCliente As String
    Dim SelectedNomCliente As String

    '***************************************
    '** BOTON IMPRIMIR *********************
    '***************************************

    Private Sub BarButRadMenListadosImprimir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButRadMenListadosImprimir.ItemClick
        Dim ObjReports As New ClassReports


        Select Case GlobalTipoDoc

            Case "FEF"
                If SelectedUUDI <> "" Then
                    If Confirmacion("¿Desea abrir el documento en linea?", Form1.ParentForm) = True Then
                        Process.Start(GlobalInfileUrl + SelectedUUDI)
                    End If
                    'abre el reporte imprimible FEL
                    Dim fel As New classFEL
                    fel.rptFacturaFEL(SelectedCoddoc, SelectedCorrelativo, 2)

                Else
                    If AbrirReporte_Ticket(SelectedFecha, SelectedCoddoc, SelectedCorrelativo, 2) = True Then
                    Else
                        MsgBox("No se pudo cargar el documento. Error :" & GlobalDesError)
                    End If
                End If


            Case "FAC"
                If AbrirReporte_Ticket(SelectedFecha, SelectedCoddoc, SelectedCorrelativo, 2) = True Then
                Else
                    'Process.Start(GlobalInfileUrl + SelectedUUDI)
                    'abre el reporte imprimible FEL
                    Dim fel As New classFEL
                    fel.rptFacturaFEL(SelectedCoddoc, SelectedCorrelativo, 2)
                End If
            Case "FNC"
                If SelectedUUDI <> "" Then
                    If Confirmacion("¿Desea abrir el documento en linea?", Form1.ParentForm) = True Then
                        Process.Start(GlobalInfileUrl + SelectedUUDI)
                    End If
                    Dim fel As New classFEL
                    If fel.rptDevolucionFEL(SelectedCoddoc, SelectedCorrelativo, 2) = True Then
                    Else
                        MsgBox("No se pudo cargar el formato. Error: " & GlobalDesError)
                    End If
                Else

                End If
            Case "COR"
                Try
                    Call AbrirReporteCuadre(SelectedFecha, SelectedCorrelativo)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            Case "DEV"
                If rptDevolucionVenta(SelectedCoddoc, SelectedCorrelativo) = True Then
                Else
                    MsgBox("No se pudo cargar el formato. Error: " & GlobalDesError)
                End If
            Case "GAS"
                Call AbrirReporte_ValeGasto(SelectedFecha, SelectedCorrelativo)

            Case "TIN"
                Call AbrirReporte_MovInv(SelectedFecha, SelectedCoddoc, SelectedCorrelativo)
            Case "TES"
                Call AbrirReporte_MovInv(SelectedFecha, SelectedCoddoc, SelectedCorrelativo)
            Case "TSS"
                Call AbrirReporte_MovInv(SelectedFecha, SelectedCoddoc, SelectedCorrelativo)

        End Select

    End Sub

    '** BOTON CERTIFICAR ***********************

    Private Sub btnMenuCertificar_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnMenuCertificar.ItemClick

        If SelectedUUDI.Length > 5 Then 'si tiene más de 5 caracteres, es porque ya tiene certificacion

            Call Aviso("AVISO", "Esta factura ya fue Certificada", Me.ParentForm)
            Exit Sub
        End If

        If Confirmacion("¿Está seguro que desea certificar este documento?", Me.ParentForm) = True Then
            Dim objFel As New classFEL
            Select Case Me.cmbTipoDocumento.SelectedValue.ToString
                Case "FEF"
                    Dim f As String = DateTime.Now.ToShortDateString()
                    Dim fel As New classFEL
                    If fel.facturaIVA_Normal(f, SelectedCoddoc, SelectedCorrelativo, SelectedNitCliente, SelectedNomCliente, "", "CIUDAD", "GUATEMALA", "GUATEMALA") = True Then

                        'actualiza los datos FEL del documento
                        GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                        GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                        GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                        GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                        GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                        'actualiza el documento interno con los datos de FEL
                        If fel.updateDocumentoFEL(GlobalEmpNit, SelectedCoddoc, SelectedCorrelativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                            Call Form1.Mensaje("Serie FEL asignada a la factura del sistema")
                        Else
                            Call Form1.Mensaje("No se logró actualizar el correlativo en el documento local")
                        End If

                        'abre la página con la factura
                        Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)

                        Call CargarGrid()
                    Else
                        MsgBox("Error al certificar: " + GlobalDesError)

                    End If

                Case "FEC"
                    Dim f As String = DateTime.Now.ToShortDateString()
                    Dim fvence As Date = Date.Now.AddMonths(2)

                    Dim fel As New classFEL
                    If fel.facturaIVA_Cambiaria(f, SelectedCoddoc, SelectedCorrelativo, SelectedNitCliente, SelectedNomCliente, "", "CIUDAD", "GUATEMALA", "GUATEMALA", fvence, 3) = True Then

                        'actualiza los datos FEL del documento
                        GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                        GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                        GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                        GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                        GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")



                        'actualiza el documento interno con los datos de FEL
                        If fel.updateDocumentoFEL(GlobalEmpNit, SelectedCoddoc, SelectedCorrelativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                            Call Form1.Mensaje("Serie FEL asignada a la factura del sistema")
                        Else
                            Call Form1.Mensaje("No se logró actualizar el correlativo en el documento local")
                        End If

                        'abre la página con la factura
                        Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)
                    Else
                        MsgBox("Error al certificar: " + GlobalDesError)

                    End If

                Case "FNC"

                    Dim f As String = DateTime.Now.ToShortDateString()
                    Dim fel As New classFEL
                    If fel.notacreditoIVA(f, SelectedCoddoc, SelectedCorrelativo, SelectedNitCliente, SelectedNomCliente, "", "CIUDAD", "GUATEMALA", "GUATEMALA", "DEVOLUCION DE MERCADERIA") = True Then

                        'actualiza los datos FEL del documento
                        GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                        GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                        GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                        GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                        GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                        'abre la página con la factura
                        Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)

                        'actualiza el documento interno con los datos de FEL
                        If fel.updateDocumentoFEL(GlobalEmpNit, SelectedCoddoc, SelectedCorrelativo, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                            Call Form1.Mensaje("Serie FEL asignada a la factura del sistema")
                        Else
                            Call Form1.Mensaje("No se logró actualizar el correlativo en el documento local")
                        End If

                        'abre el reporte imprimible FEL
                        'fel.rptFacturaFEL(docto, correl, GlobalInteger)
                    Else
                        MsgBox("Error al certificar: " + GlobalDesError)
                    End If

                Case Else
                    MsgBox("ESTE DOCUMENTO NO ES ELECTRÓNICO")
            End Select

        End If

    End Sub

    Dim sc As New Security.Seguridad("")

    Private Function TokenSN() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strHostConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT TOKEN FROM FSYA_SYNC.dbo.TOKEN_NC WHERE EMPNIT = @EMPNIT AND FECHA = @FECHA AND CODDOC = @CODDOC AND CORRELATIVO = @CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@FECHA", SelectedFecha)
                cmd.Parameters.AddWithValue("@CODDOC", SelectedCoddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", SelectedCorrelativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                MsgBox(ex.ToString + " En consulta de token SYNC.")
                r = True
            End Try
        End Using

        Return r

    End Function

    Dim docNC As String
    Dim corrNC As Integer
    Dim CodVen As Integer

    Private Sub btnToken_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnToken.ItemClick

        If SelectedStatusDoc = "O" Then
            Call TokenSN()
            If TokenSN() = False Then

                Using cn As New SqlConnection(strHostConectionString)
                    Try
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If

                        Dim cmd As New SqlCommand("INSERT INTO FSYA_SYNC.dbo.TOKEN_NC (EMPNIT, FECHA, FECHA_ACT, CODDOC, CORRELATIVO, TOKEN)
                                                VALUES (@EMPNIT, @FECHA, @FECHA_ACT, @CODDOC, @CORRELATIVO, @TOKEN)", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        cmd.Parameters.AddWithValue("@FECHA", SelectedFecha)
                        cmd.Parameters.AddWithValue("@FECHA_ACT", Today.Date)
                        cmd.Parameters.AddWithValue("@CODDOC", SelectedCoddoc)
                        cmd.Parameters.AddWithValue("@CORRELATIVO", SelectedCorrelativo)
                        cmd.Parameters.AddWithValue("@TOKEN", sc.EncryptData(GlobalEmpNit + SelectedFecha.ToString + SelectedCoddoc + SelectedCorrelativo.ToString))
                        cmd.ExecuteNonQuery()

                        MsgBox("Token asignado correctamente, contacte a su supervisor.")


                    Catch ex As Exception
                        MsgBox(ex.ToString + " En insert token.")
                    End Try
                End Using
            Else
                MsgBox("Este token ya fue asignado, contacte a su supervisor.")
            End If
        Else
            MsgBox("Este documento ya tiene nota de credito.")
        End If

    End Sub

    Private Sub btnNC_ItemClick(sender As Object, e As XtraBars.ItemClickEventArgs) Handles btnNC.ItemClick

        If FlyoutDialog.Show(Form1.ParentForm, New UserControlToken) = DialogResult.OK Then

            Call CargarTempFactura(SelectedCoddoc, SelectedCorrelativo)
            Call InsertDocproductos()
            Call InsertDocumentos()
            Call SetD()
            Call CertNC()
            Dim objTipodoc As New ClassTipoDocumentos(GlobalEmpNit)
            objTipodoc.UpdateCorrelativoDoc(docNC, corrNC)
            Call CargarGrid()

        End If

    End Sub

    Private Function CertNC() As Boolean

        Dim r As Boolean

        Call CoddocNC()

        If GlobalSelectedTipoDocumento = "FEL" Then

            Dim objclie As New classClientes(GlobalEmpNit)
            Dim dirclie As String = "CIUDAD" 'objclie.getDireccionCliente(CType(Me.txtCodClie.Text, Integer))

            Dim f As String = DateTime.Now.ToShortDateString()
            Dim fel As New classFEL
            If fel.notacreditoIVA(f, docNC, corrNC, SelectedNitCliente, SelectedNomCliente, "", dirclie, "GUATEMALA", "GUATEMALA", "NC") = True Then

                'actualiza los datos FEL del documento
                GlobalSelectedFEL_UUDI = Strings.Replace(GlobalSelectedFEL_UUDI, " uuid:", "")
                GlobalSelectedFEL_SERIE = Strings.Replace(GlobalSelectedFEL_SERIE, " serie:", "")
                GlobalSelectedFEL_NUMERO = Strings.Replace(GlobalSelectedFEL_NUMERO, " numero:", "")

                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, Chr(34), "") 'reemplaza las comillas dobles
                GlobalSelectedFEL_FECHA = Strings.Replace(GlobalSelectedFEL_FECHA, "fecha:", "")

                'abre la página con la factura
                'Process.Start(GlobalInfileUrl + GlobalSelectedFEL_UUDI)

                'actualiza el documento interno con los datos de FEL
                If fel.updateDocumentoFEL(GlobalEmpNit, docNC, corrNC, GlobalSelectedFEL_UUDI, GlobalSelectedFEL_SERIE, GlobalSelectedFEL_NUMERO, GlobalSelectedFEL_FECHA) = True Then
                    Call Form1.Mensaje("Serie FEL asignada a la factura del sistema")
                Else
                    Call Form1.Mensaje("No se logró actualizar el correlativo en el documento local")
                End If

                'abre el reporte imprimible FEL
                fel.rptDevolucionFEL(docNC, corrNC, 2)

            Else

                'proceso de contingencia
                MsgBox("Lo siento, no pude certificar la Nota de crédito, debe hacerlo manualmente o esperar a que el sistema lo haga automáticamente y usted pueda reimprimirla")

            End If

        Else

            'NOTA CREDITO NORMAL
            If rptDevolucionVenta(docNC, corrNC) = True Then
            End If

        End If

        Return r

    End Function

    Private Function SetD() As Boolean

        Dim r As Boolean


        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("UPDATE DOCUMENTOS SET STATUS = 'D' WHERE EMPNIT = @EMPNIT AND FECHA = @FECHA AND CODDOC = @CODDOC AND CORRELATIVO = @CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@FECHA", SelectedFecha)
                cmd.Parameters.AddWithValue("@CODDOC", SelectedCoddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", SelectedCorrelativo)
                cmd.ExecuteNonQuery()
                r = True

            Catch ex As Exception
                r = False
                MsgBox("error en documentos. Error: " + ex.ToString)
            End Try
        End Using

        Return r

    End Function

    Private Sub CargarTempFactura(ByVal coddoc As String, ByVal correlativo As Double)

        Call CoddocNC()

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

                    Dim cmi As New SqlCommand("INSERT INTO TEMP_VENTAS (EMPNIT,CODDOC,CORRELATIVO,USUARIO,CODPROD,DESPROD,CODMEDIDA,CANTIDAD,EQUIVALE,TOTALUNIDADES, COSTO,PRECIO,TOTALCOSTO,TOTALPRECIO,EXENTO,TOTALBONIF) 
                    VALUES (@EMPNIT,@CODDOC,@CORRELATIVO,@USUARIO,@CODPROD,@DESPROD,@CODMEDIDA,@CANTIDAD,@EQUIVALE,@TOTALUNIDADES,@COSTO,@PRECIO,@TOTALCOSTO,@TOTALPRECIO,@EXENTO,@TOTALBONIF)", cn)
                    cmi.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                    cmi.Parameters.AddWithValue("@CODDOC", docNC)
                    cmi.Parameters.AddWithValue("@CORRELATIVO", corrNC)
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

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using

    End Sub

    Private Function CoddocNC() As Boolean

        Dim r As Boolean

        Select Case GlobalTipoDoc
            Case "FEF"

                Using cn As New SqlConnection(strSqlConectionString)
                    Try
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If

                        Dim cmd As New SqlCommand("SELECT CODDOC, CORRELATIVO FROM TIPODOCUMENTOS WHERE EMPNIT = @EMPNIT AND TIPODOC = 'FNC'", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        Dim dr As SqlDataReader = cmd.ExecuteReader
                        dr.Read()

                        If dr.HasRows Then
                            docNC = dr(0).ToString
                            corrNC = Integer.Parse(dr(1))
                            r = True
                        Else
                            r = False
                        End If

                    Catch ex As Exception
                        MsgBox(ex.ToString + " En consulta de coddoc FEF.")
                        r = True
                    End Try
                End Using

            Case "FAC"

                Using cn As New SqlConnection(strHostConectionString)
                    Try
                        If cn.State <> ConnectionState.Open Then
                            cn.Open()
                        End If

                        Dim cmd As New SqlCommand("SELECT CODDOC, CORRELATIVO FROM FSYA.dbo.TIPODOCUMENTOS WHERE EMPNIT = @EMPNIT AND TIPODOC = 'DEV'", cn)
                        cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                        Dim dr As SqlDataReader = cmd.ExecuteReader
                        dr.Read()

                        If dr.HasRows Then
                            docNC = dr(0).ToString
                            corrNC = Integer.Parse(dr(1))
                            r = True
                        Else
                            r = False
                        End If

                    Catch ex As Exception
                        MsgBox(ex.ToString + " En consulta de coddoc FAC.")
                        r = True
                    End Try
                End Using
        End Select


        Return r

    End Function

    Private Function VendDoc() As Boolean

        Dim r As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT CODVEN FROM FSYA.dbo.DOCUMENTOS WHERE EMPNIT = @EMPNIT AND FECHA = @FECHA AND CODDOC = @CODDOC AND CORRELATIVO = @CORRELATIVO", cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@FECHA", SelectedFecha)
                cmd.Parameters.AddWithValue("@CODDOC", SelectedCoddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", SelectedCorrelativo)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()

                If dr.HasRows Then
                    CodVen = Integer.Parse(dr(0))
                    r = True
                Else
                    r = False
                End If

            Catch ex As Exception
                MsgBox(ex.ToString + " En consulta de CODVEN.")
                r = True
            End Try
        End Using

        Return r

    End Function

    Private Function InsertDocumentos() As Boolean
        Dim r As Boolean
        Call CoddocNC()
        Call VendDoc()

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
                cmd.Parameters.AddWithValue("@ANIO", Today.Year)
                cmd.Parameters.AddWithValue("@MES", Today.Month)
                cmd.Parameters.AddWithValue("@DIA", Today.Day)
                cmd.Parameters.AddWithValue("@FECHA", Today.Date)
                cmd.Parameters.AddWithValue("@HORA", Now.Hour)
                cmd.Parameters.AddWithValue("@MINUTO", Now.Minute)
                cmd.Parameters.AddWithValue("@CORRELATIVO", corrNC)
                cmd.Parameters.AddWithValue("@CODCLIENTE", GlobalCodCliente)
                cmd.Parameters.AddWithValue("@NIT", SelectedNitCliente)
                cmd.Parameters.AddWithValue("@NOMBRE", SelectedNomCliente)
                cmd.Parameters.AddWithValue("@DIRECCION", "CIUDAD")
                cmd.Parameters.AddWithValue("@TOTALCOSTO", SelectedCosto)
                cmd.Parameters.AddWithValue("@TOTALPRECIO", SelectedPr)
                cmd.Parameters.AddWithValue("@TOTALEXENTO", 0)
                cmd.Parameters.AddWithValue("@CODEMBARQUE", GlobalSelectedCodEmbarque)
                cmd.Parameters.AddWithValue("@USUARIO", GlobalNomUsuario)
                cmd.Parameters.AddWithValue("@CODVEN", CodVen)
                cmd.Parameters.AddWithValue("@OBS", "DEVOLUCION DE VENTAS")
                cmd.Parameters.AddWithValue("@DIRENTREGA", "CIUDAD")
                cmd.Parameters.AddWithValue("@FECHAVENCE", Today.Date)
                cmd.Parameters.AddWithValue("@DIASCREDITO", 0)
                cmd.Parameters.AddWithValue("@CODCAJA", 1)
                cmd.Parameters.AddWithValue("@CODDOC", docNC)
                cmd.Parameters.AddWithValue("@SERIEFAC", docNC)
                cmd.Parameters.AddWithValue("@NOFAC", corrNC)
                cmd.Parameters.AddWithValue("@PAGO", 0)
                cmd.Parameters.AddWithValue("@PAGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@RECARGOTARJETA", 0)
                cmd.Parameters.AddWithValue("@CONCRE", "CON")
                cmd.Parameters.AddWithValue("@SALDO", 0)
                cmd.Parameters.AddWithValue("@ABONO", SelectedPr)
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

    Private Function InsertDocproductos() As Boolean

        Dim result As Boolean
        Call CoddocNC()
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
                cmd.Parameters.AddWithValue("@ANIO", Today.Year)
                cmd.Parameters.AddWithValue("@MES", Today.Month)
                cmd.Parameters.AddWithValue("@DIA", Today.Day)
                cmd.Parameters.AddWithValue("@CODDOC", docNC)
                cmd.Parameters.AddWithValue("@CORRELATIVO", corrNC)
                cmd.ExecuteNonQuery()

                result = True

            Catch ex As Exception
                MsgBox("error en docproductos: " + ex.ToString)
                result = False
            End Try


        End Using

        Return result

    End Function

#End Region
End Class
