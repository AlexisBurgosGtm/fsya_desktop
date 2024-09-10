Imports System.Data.SqlClient

Public Class viewFinalizarEmbarque
    Sub New(ByVal _codembarque As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CodEmbarque = _codembarque

    End Sub

    Dim CodEmbarque As String

    Dim objEmbarques As New classEmbarques

    Private Sub viewFinalizarEmbarque_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call getDatosEmbarque()

        Dim ventas As Double = objEmbarques.getVentasPicking(CodEmbarque)
        Dim devoluciones As Double = objEmbarques.getDevolucionesPicking(CodEmbarque)
        Dim liquidar As Double = ventas - devoluciones
        Dim pedidos As Double = objEmbarques.getPedidosPicking(CodEmbarque)


        Me.lbCodembarque.Text = CodEmbarque
        Me.lbPedidos.Text = pedidos.ToString


        Me.lbTotalVentas.Text = FormatNumber(objEmbarques.getVentasPicking(CodEmbarque), 2)
        Me.lbTotalDevoluciones.Text = FormatNumber(objEmbarques.getDevolucionesPicking(CodEmbarque), 2)


        Me.lbDiferencia.Text = FormatNumber(liquidar, 2)
        Me.lbLiquidar.Text = FormatNumber(liquidar, 2)

        Me.txtFecha.DateTime = Today.Date

        Me.txtDineroReportado.Text = liquidar.ToString
        Me.txtDineroReportado.select()


    End Sub


    Private Sub getDatosEmbarque()
        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand("SELECT  EMBARQUES.FECHA, EMBARQUES.DESCRIPCION, REPARTIDORES.DESREP
                            FROM EMBARQUES LEFT OUTER JOIN
                            REPARTIDORES ON EMBARQUES.CODREP = REPARTIDORES.CODREP AND EMBARQUES.EMPNIT = REPARTIDORES.EMPNIT
                            WHERE (EMBARQUES.EMPNIT = @E) AND (EMBARQUES.CODEMBARQUE = @C)", cn)
                cmd.Parameters.AddWithValue("@E", GlobalEmpNit)
                cmd.Parameters.AddWithValue("@C", CodEmbarque)
                Dim dr As SqlDataReader = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows = True Then
                    Me.txtFechaCreado.DateTime = Date.Parse(dr(0))
                    Me.lbDescripcion.Text = dr(1).ToString
                End If

            Catch ex As Exception


            End Try
        End Using
    End Sub


    Private Sub txtDineroReportado_TextChanged(sender As Object, e As EventArgs) Handles txtDineroReportado.TextChanged

        Dim liquidar As Double = Double.Parse(Me.lbLiquidar.Text)

        Try
            If Me.txtDineroReportado.Text <> "" Then
                Dim reportado As Double = Double.Parse(Me.txtDineroReportado.Text)
                Dim r As Double = reportado - liquidar
                Me.lbDiferenciaLiquidar.Text = FormatNumber(r, 2)

            Else
                Me.txtDineroReportado.Text = "0"
                Me.lbDiferenciaLiquidar.Text = "0"
            End If
        Catch ex As Exception
            Me.txtDineroReportado.Text = "0"
            Me.lbDiferenciaLiquidar.Text = "0"
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Confirmacion("¿Está seguro que desea FINALIZAR este Embarque?", Me.ParentForm) = True Then

            If Me.txtDineroReportado.Text <> "" Then

                If objEmbarques.finalizarEmbarque(Me.lbCodembarque.Text, Me.txtFecha.DateTime, Double.Parse(Me.lbTotalVentas.Text), Double.Parse(Me.lbTotalDevoluciones.Text), Double.Parse(Me.lbLiquidar.Text), Double.Parse(Me.txtDineroReportado.Text)) = True Then
                    MsgBox("Embarque Finalizado Exitosamente!!")
                    Me.btnAceptarTrue.PerformClick()
                Else
                    MsgBox("No se pudo finalizar el embarque. Error: " + objEmbarques.DesError)
                End If

            Else
                MsgBox("Indique el monto reportado")
            End If

        End If

    End Sub

    Private Sub txtDineroReportado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDineroReportado.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardar.select()
        End If
    End Sub



    'If objEmbarques.finalizarEmbarque(drw.Item(0).ToString) = True Then
    'MsgBox("Embarque Finalizado Exitosamente!!")
    'Call cargarGridEmbarques(Me.switchCompletosFinalizados.IsOn, CType(Me.cmbEmbarquesMes.SelectedValue, Integer), CType(Me.cmbEmbarquesAnio.Text, Integer))
    'Else
    'MsgBox("No se pudo finalizar el embarque. Error: " + objEmbarques.DesError)
    'End If

End Class
