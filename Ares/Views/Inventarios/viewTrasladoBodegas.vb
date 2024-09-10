Imports System.Data.SqlClient

Public Class viewTrasladoBodegas

    Sub New(ByVal _coddoc As String, ByVal _correlativo As Double, ByVal _bodegasalida As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        coddoc = _coddoc
        correlativo = _correlativo
        bodegasalida = _bodegasalida

    End Sub

    Dim bodegasalida As Integer, coddoc As String, correlativo As Double
    Dim objGen As New ClassGeneral

    Private Sub viewTrasladoBodegas_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'CARGA DEL COMBOBOX
        'Dim qry As String = "SELECT CODBODEGA AS CODIGO, DESBODEGA AS DESCRIPCION FROM BODEGAS WHERE EMPNIT='" & GlobalEmpNit & "' AND CODBODEGA<>" & bodegasalida
        Dim qry As String = "SELECT EMPNIT AS CODIGO, EMPNOMBRE AS DESCRIPCION FROM EMPRESAS WHERE EMPNIT<>'" & GlobalEmpNit & "' ORDER BY EMPNIT;"

        With Me.cmbBodegas
            .DataSource = objGen.getTblQry(qry)
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "CODIGO"
        End With

        Try
            If getCoddocDestino(Me.cmbBodegas.SelectedValue.ToString) = True Then

            End If
        Catch ex As Exception

        End Try

    End Sub

    'documento de destino, se asignan mediante una rutina luego de seleccionar la empresa
    Dim CoddocDestino As String, CorrelativoDestino As Double

    Private Sub cmbBodegas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBodegas.SelectedIndexChanged
        Try
            If getCoddocDestino(Me.cmbBodegas.SelectedValue.ToString) = True Then

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbCoddocDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCoddocDestino.SelectedIndexChanged
        Dim objTipoDoc As New ClassTipoDocumentos(Me.cmbBodegas.SelectedValue.ToString)
        Try
            Me.lbCorrelativoDestino.Text = objTipoDoc.GetCorrelativoDoc(Me.cmbCoddocDestino.SelectedValue.ToString).ToString

        Catch ex As Exception
            Me.lbCorrelativoDestino.Text = "0"
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Dim destEmpnit As String
        Dim destCoddoc As String
        Dim destCorrelativo As Double

        If Me.cmbBodegas.SelectedIndex >= 0 Then
            If Confirmacion("¿Está seguro que desea generar este Traslado en la empresa seleccionada?", Me.ParentForm) = True Then

                destEmpnit = Me.cmbBodegas.SelectedValue.ToString
                destCoddoc = Me.cmbCoddocDestino.SelectedValue.ToString
                destCorrelativo = Double.Parse(Me.lbCorrelativoDestino.Text)

                'obtiene el traslado de la empresa A y lo inserta en la B
                If GetTraslado(GlobalEmpNit, coddoc, correlativo, destEmpnit, destCoddoc, destCorrelativo) = True Then
                    'carga la existencias
                    Dim objDocto As New ClassDocumentos
                    If objDocto.DevolverInvFac(destEmpnit, destCoddoc, destCorrelativo, GlobalAnioProceso, GlobalMesProceso) = True Then
                    Else
                        MsgBox("El inventario no se cargó.. deberá realizar una actualización de inventario para que se cargue.")
                    End If

                    'actualiza el correlativo
                    objDocto.updateCorrelativoDocumento(destEmpnit, destCoddoc, destCorrelativo)



                    MsgBox("Ingreso generado exitosamente")
                    Me.btnAceptarTrue.PerformClick()

                End If

            End If

        Else
            MsgBox("No seleccionó una Empresa válida")
        End If
    End Sub


    Private Function getCoddocDestino(ByVal empnitdestino As String) As Boolean
        Dim r As Boolean

        Dim objTipoDoc As New ClassTipoDocumentos(empnitdestino)
        Try
            With Me.cmbCoddocDestino
                .DataSource = Nothing
                .DataSource = objTipoDoc.tblCoddoc("TIN")
                .ValueMember = "CODDOC"
                .DisplayMember = "DESDOC"
            End With

            Me.lbCorrelativoDestino.Text = objTipoDoc.GetCorrelativoDoc(Me.cmbCoddocDestino.SelectedValue.ToString).ToString

        Catch ex As Exception
            Me.cmbCoddocDestino.DataSource = Nothing
            Me.lbCorrelativoDestino.Text = "0"
        End Try

        Return r
    End Function


    Private Function GetTraslado(ByVal empnit As String,
                                 ByVal coddoc As String,
                                 ByVal correlativo As Double,
                                 ByVal destEmpnit As String,
                                 ByVal destcoddoc As String,
                                 ByVal destcorrelativo As Double) As Boolean

        Dim result As Boolean

        Using cn As New SqlConnection(strSqlConectionString)
            If cn.State <> ConnectionState.Open Then
                cn.Open()
            End If

            Try
                'OBTIENE E INSERTA EL DOCUMENTO DE LA EMPRESA DE ORIGEN
                Dim cmdh As New SqlCommand("SELECT ID, @DESTEMPNIT AS EMPNIT, ANIO, MES, DIA, FECHA, HORA, MINUTO, @DESTCODDOC  AS CODDOC, @DESTCORRELATIVO  AS CORRELATIVO, CODCLIENTE, DOC_NIT, DOC_NOMCLIE, DOC_DIRCLIE, TOTALCOSTO, TOTALPRECIO, CODEMBARQUE, STATUS, USUARIO, 
                                            CONCRE, CORTE, CODDOC AS SERIEFAC, CONCAT(CORRELATIVO,'-') AS NOFAC, CODVEN, NOCORTE, PAGO, VUELTO, MARCA, OBS, DOC_SALDO, DOC_ABONO, OBSMARCA, TOTALDESCUENTO, CODCAJA, TOTALTARJETA, RECARGOTARJETA, CODREP, DIRENTREGA, NOGUIA, VALORENTREGA,TOTALEXENTO
                                        FROM DOCUMENTOS
                                        WHERE (EMPNIT=@EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO)", cn)

                cmdh.Parameters.AddWithValue("@DESTEMPNIT", destEmpnit)
                cmdh.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdh.Parameters.AddWithValue("@DESTCODDOC", destcoddoc)
                cmdh.Parameters.AddWithValue("@DESTCORRELATIVO", destcorrelativo)

                cmdh.Parameters.AddWithValue("@CODDOC", coddoc)
                cmdh.Parameters.AddWithValue("@CORRELATIVO", correlativo)


                Dim drh As SqlDataReader = cmdh.ExecuteReader

                Dim bcCopy As New SqlBulkCopy(strSqlConectionString)

                bcCopy.DestinationTableName = "DOCUMENTOS"
                bcCopy.WriteToServer(drh)
                drh.Close()

                'INSERTA DOCPRODUCTOS
                Dim qr As String = "SELECT ID, @DESTEMPNIT AS EMPNIT, ANIO, MES, DIA, @DESTCODDOC AS CODDOC, @DESTCORRELATIVO AS CORRELATIVO, CODPROD, DESPROD, CODMEDIDA, CANTIDAD, CANTIDADBONIF, EQUIVALE, TOTALUNIDADES, TOTALBONIF, COSTO, PRECIO, TOTALCOSTO, 
                                            TOTALPRECIO, ENTREGADOS_TOTALUNIDADES, ENTREGADOS_TOTALCOSTO, ENTREGADOS_TOTALPRECIO, COSTOANTERIOR, COSTOPROMEDIO, CODBODEGAENTRADA, CODBODEGASALIDA, DESCUENTO, PORCDESCUENTO, NOSERIE, EXENTO
                                        FROM DOCPRODUCTOS
                                        WHERE (EMPNIT = @EMPNIT) AND (CODDOC = @CODDOC) AND (CORRELATIVO = @CORRELATIVO)"

                Dim cmd As New SqlCommand(qr, cn)

                cmd.Parameters.AddWithValue("@DESTEMPNIT", destEmpnit)
                cmd.Parameters.AddWithValue("@DESTCODDOC", destcoddoc)
                cmd.Parameters.AddWithValue("@DESTCORRELATIVO", destcorrelativo)

                cmd.Parameters.AddWithValue("@EMPNIT", empnit)
                cmd.Parameters.AddWithValue("@CODDOC", coddoc)
                cmd.Parameters.AddWithValue("@CORRELATIVO", correlativo)

                Dim drp As SqlDataReader = cmd.ExecuteReader

                Dim bcCopyp As New SqlBulkCopy(strSqlConectionString)

                bcCopyp.DestinationTableName = "DOCPRODUCTOS"
                bcCopyp.WriteToServer(drp)
                drp.Close()

                'ACTUALIZA EL CODEMBARQUE DEL DOCUMENTO PARA DEFINIR EL DESTINO
                Dim cmdup As New SqlCommand("UPATE DOCUMENTOS SET CODEMBARQUE=@CODEMBARQUE 
                                        WHERE (EMPNIT = @EMPNIT) AND 
                                            (CODDOC = @CODDOC) AND 
                                            (CORRELATIVO = @CORRELATIVO)", cn)

                cmdup.Parameters.AddWithValue("@EMPNIT", empnit)
                cmdup.Parameters.AddWithValue("@CODDOC", coddoc)
                cmdup.Parameters.AddWithValue("@CORRELATIVO", correlativo)
                cmdup.Parameters.AddWithValue("@CODEMBARQUE", destEmpnit)
                cmdup.ExecuteNonQuery()

                result = True


            Catch ex As Exception
                GlobalDesError = ex.ToString
                result = False
            End Try
        End Using

        Return result

    End Function


End Class
