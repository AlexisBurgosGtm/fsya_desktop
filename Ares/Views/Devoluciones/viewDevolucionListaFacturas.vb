Imports System.Data.SqlClient

Public Class viewDevolucionListaFacturas

    Private Sub viewDevolucionListaFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarMesAnio()
        Call CargarDocumentos()

    End Sub

    Public Sub CargarMesAnio()
        Dim tblmeses As New DataTable
        With tblmeses.Columns
            .Add("CODMES", GetType(Integer))
            .Add("DESMES", GetType(String))
        End With

        With tblmeses.Rows
            .Add(New Object() {1, "ENERO"})
            .Add(New Object() {2, "FEBRERO"})
            .Add(New Object() {3, "MARZO"})
            .Add(New Object() {4, "ABRIL"})
            .Add(New Object() {5, "MAYO"})
            .Add(New Object() {6, "JUNIO"})
            .Add(New Object() {7, "JULIO"})
            .Add(New Object() {8, "AGOSTO"})
            .Add(New Object() {9, "SEPTIEMBRE"})
            .Add(New Object() {10, "OCTUBRE"})
            .Add(New Object() {11, "NOVIEMBRE"})
            .Add(New Object() {12, "DICIEMBRE"})
        End With

        With Me.cmbMes
            .DataSource = tblmeses
            .DisplayMember = "DESMES"
            .ValueMember = "CODMES"
        End With

        Me.cmbAnio.Text = Today.Year.ToString
        Me.cmbMes.SelectedValue = Today.Month

    End Sub 'CARGA EL MES Y AÑO DE PROCESO

    Private Function CargarDocumentos()

        Dim tbl As New DSDOCUMENTOS.tblDocumentosDataTable

        Dim sql As String
        Dim sql2 As String

        sql2 = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                                            DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA AS MARCA, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA,':',DOCUMENTOS.MINUTO) AS HORAMINUTO, DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, DOCUMENTOS.CODCLIENTE,
                                            CONCAT(DOCUMENTOS.SERIEFAC,'-',DOCUMENTOS.NOFAC) AS DOCREF, CODCAJA
                                            FROM DOCUMENTOS LEFT OUTER JOIN TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                                            WHERE (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS='O')"

        If GlobalSelectedTipoDocumento = "FNC" Then
            sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                         DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA, ':', 
                         DOCUMENTOS.MINUTO)  AS HORAMINUTO, DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, DOCUMENTOS.CODCLIENTE, CONCAT(DOCUMENTOS.SERIEFAC, '-', DOCUMENTOS.NOFAC) 
                          AS DOCREF, DOCUMENTOS.CODCAJA, CLIENTES.CODCLIE, DOCUMENTOS.CODEMBARQUE
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         CLIENTES ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        WHERE (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (TIPODOCUMENTOS.TIPODOC IN('FEF','FEC') ) AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS = 'O') "

        Else
            sql = "SELECT DOCUMENTOS.EMPNIT, DOCUMENTOS.CODDOC, DOCUMENTOS.CORRELATIVO, DOCUMENTOS.FECHA, DOCUMENTOS.DOC_NIT AS NIT, DOCUMENTOS.DOC_NOMCLIE AS NOMCLIENTE, 
                         DOCUMENTOS.DOC_DIRCLIE AS DIRCLIENTE, DOCUMENTOS.MARCA, DOCUMENTOS.TOTALCOSTO, DOCUMENTOS.TOTALPRECIO, DOCUMENTOS.TOTALTARJETA, CONCAT(DOCUMENTOS.HORA, ':', 
                         DOCUMENTOS.MINUTO)  AS HORAMINUTO, DOCUMENTOS.CONCRE, DOCUMENTOS.STATUS AS ST, DOCUMENTOS.ID, DOCUMENTOS.CODCLIENTE, CONCAT(DOCUMENTOS.SERIEFAC, '-', DOCUMENTOS.NOFAC) 
                          AS DOCREF, DOCUMENTOS.CODCAJA, CLIENTES.CODCLIE, DOCUMENTOS.CODEMBARQUE
                        FROM DOCUMENTOS LEFT OUTER JOIN
                         CLIENTES ON DOCUMENTOS.EMPNIT = CLIENTES.EMPNIT AND DOCUMENTOS.CODCLIENTE = CLIENTES.CODCLIENTE LEFT OUTER JOIN
                         TIPODOCUMENTOS ON DOCUMENTOS.CODDOC = TIPODOCUMENTOS.CODDOC AND DOCUMENTOS.EMPNIT = TIPODOCUMENTOS.EMPNIT
                        WHERE (DOCUMENTOS.ANIO = @ANIO) AND (DOCUMENTOS.MES = @MES) AND (TIPODOCUMENTOS.TIPODOC = 'FAC') AND (DOCUMENTOS.EMPNIT = @EMPNIT) AND (DOCUMENTOS.STATUS = 'O') "

        End If



        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@EMPNIT", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@ANIO", CType(Me.cmbAnio.Text, Integer))
                cmd.Parameters.AddWithValue("@MES", CType(Me.cmbMes.SelectedValue, Integer))
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)

            Catch ex As Exception

                tbl = Nothing
            End Try
        End Using

        Me.GridControlFacturas.DataSource = Nothing
        Me.GridControlFacturas.DataSource = tbl

    End Function

    Private Sub cmbMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMes.SelectedIndexChanged
        Call CargarDocumentos()
    End Sub

    Private Sub cmbAnio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnio.SelectedIndexChanged
        Call CargarDocumentos()
    End Sub


    Dim drw As DataRow

    Private Sub GridViewFacturas_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewFacturas.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewFacturas.GetFocusedDataRow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridViewFacturas_DoubleClick(sender As Object, e As EventArgs) Handles GridViewFacturas.DoubleClick
        Try
            SelectedCoddoc = drw.Item(1).ToString
            SelectedCorrelativo = Double.Parse(drw.Item(2))
            GlobalSelectedCodEmbarque = drw.Item(19).ToString

            Me.btnAceptarTrue.PerformClick()
        Catch ex As Exception
            Me.SimpleButton1.PerformClick()
        End Try
    End Sub

    Private Sub GridViewFacturas_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewFacturas.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                SelectedCoddoc = drw.Item(1).ToString
                SelectedCorrelativo = Double.Parse(drw.Item(2))
                GlobalSelectedCodEmbarque = drw.Item(19).ToString

                Me.btnAceptarTrue.PerformClick()
            Catch ex As Exception
                Me.SimpleButton1.PerformClick()
            End Try
        End If
    End Sub


End Class
