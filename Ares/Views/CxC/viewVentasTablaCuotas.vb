Public Class viewVentasTablaCuotas

    Sub New(_data As DataRow)
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        data = _data
    End Sub

    Dim data As DataRow
    Dim CodCliente As Integer
    Dim coddocFac As String, correlativoFac As Double, nitclieFac As String

    Dim objCxc As New ClassCxc

    Private Sub viewVentasTablaCuotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbTotalFActura.Text = data.Item(6).ToString

        Me.cmbFrecuencia.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.cmbFrecuencia.AutoCompleteSource = AutoCompleteSource.ListItems

        Me.cmbCantidadCuotas.Text = 6

        CodCliente = CType(data.Item(9), Integer)

        coddocFac = data.Item(4).ToString
        correlativoFac = Double.Parse(data.Item(5))
        Me.lbFactura.Text = coddocFac & " - " & data.Item(5).ToString

        nitclieFac = data.Item(0).ToString
        Me.lbNit.Text = nitclieFac

        Me.LbCliente.Text = data.Item(1).ToString

        Me.txtFecha.DateTime = Date.Parse(data.Item(3))

        Me.cmbFrecuencia.SelectedIndex = 0

    End Sub


    Private Sub btnCuotas_Click(sender As Object, e As EventArgs) Handles btnCuotas.Click
        If Me.cmbCantidadCuotas.Text <> "" Then
            Dim tbl As New DSCxc.tblDocCuotasTempDataTable

            Dim totalcuotas As Integer = Integer.Parse(Me.cmbCantidadCuotas.Text)
            Dim saldo As Double = Double.Parse(Strings.Mid(data.Item(7).ToString, 2))
            Dim cuota As Double = saldo / totalcuotas
            Dim fechacuota As Date

            For x = 1 To totalcuotas
                Select Case Me.cmbFrecuencia.Text
                    Case "TRIMESTRAL"
                        fechacuota = Today.Date.AddMonths(x * 3)
                    Case "MENSUAL"
                        fechacuota = Today.Date.AddMonths(x)
                    Case "SEMANAL"
                        fechacuota = Today.Date.AddDays(x * 7)
                    Case "QUINCENAL"
                        fechacuota = Today.Date.AddDays(x * 15)
                    Case "DIARIO"
                        fechacuota = Today.Date.AddDays(x)
                End Select

                tbl.Rows.Add(x, fechacuota, cuota, FormatCurrency(cuota))
            Next

            Me.GridCuotas.DataSource = Nothing
            Me.GridCuotas.DataSource = tbl

        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Confirmacion("¿Está seguro que desea registrar este plan de pagos?", Me.ParentForm) = True Then

            Dim totalcuotas As Integer = Integer.Parse(Me.cmbCantidadCuotas.Text)
            Dim saldo As Double = Double.Parse(Strings.Mid(data.Item(7).ToString, 2))
            Dim cuota As Double = saldo / totalcuotas
            Dim fechacuota As Date

            Dim result As Integer = 0

            For x = 1 To totalcuotas
                Select Case Me.cmbFrecuencia.Text
                    Case "MENSUAL"
                        fechacuota = Today.Date.AddMonths(x)
                    Case "SEMANAL"
                        fechacuota = Today.Date.AddDays(x * 7)
                    Case "QUINCENAL"
                        fechacuota = Today.Date.AddDays(x * 15)
                    Case "DIARIO"
                        fechacuota = Today.Date.AddDays(x)
                End Select

                result = result + objCxc.InsertarTablaCuotas(GlobalEmpNit, CodCliente, nitclieFac, Me.txtFecha.DateTime, coddocFac, correlativoFac, x, cuota, fechacuota)

            Next

            If result = totalcuotas Then
                MsgBox("Cuotas Generadas Exitosamente")
            End If

            Me.btnCancelar.PerformClick()

        End If
    End Sub


End Class
