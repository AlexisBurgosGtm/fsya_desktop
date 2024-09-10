Public Class viewOrdenTrabajoTerminar
    Sub New(ByVal _coddoc As String, ByVal _correlativo As Double, ByVal _valor As Double, ByVal _anticipo As Double, ByVal _saldo As Double)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        coddoc = _coddoc
        correlativo = _correlativo
        valor = _valor
        anticipo = _anticipo
        saldo = _saldo
    End Sub

    Dim coddoc As String, correlativo, valor, anticipo, saldo As Double
    Dim objOrdenTrab As New classOrdenTrabajo(GlobalEmpNit)

    Private Sub cmbTecnico_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTecnico.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtDiagnostico.select()
        End If
    End Sub

    Private Sub viewOrdenTrabajoTerminar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbCoddoc.Text = coddoc
        Me.lbCorrelativo.Text = correlativo
        Me.txtValor.Text = valor
        Me.txtAnticipo.Text = anticipo
        Me.txtSaldo.Text = saldo
        Me.txtFechaFinalizado.DateTime = Today.Date

        Call CargarComboboxEmpleado()

        Me.cmbTecnico.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.cmbTecnico.AutoCompleteSource = AutoCompleteSource.ListItems

        Me.cmbTecnico.select()

        AddHandler Me.txtValor.Leave, AddressOf CalcularSaldo

    End Sub
    Private Sub CargarComboboxEmpleado()
        Dim objEmpleados As New ClassEmpleados
        With Me.cmbTecnico
            .DataSource = objEmpleados.tblListaEmpleadosTipo(GlobalEmpNit, 9) '9 es el codigo para tecnicos y mecanicos
            .ValueMember = "CODEMP"
            .DisplayMember = "NOMEMP"
        End With

    End Sub

    Private Sub txtDiagnostico_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDiagnostico.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtValor.select()
        End If
    End Sub

    Private Sub CalcularSaldo()
        Dim valor, abono, saldo As Double
        valor = Double.Parse(Me.txtValor.Text)
        abono = Double.Parse(Me.txtAnticipo.Text)
        saldo = valor - abono
        Me.txtSaldo.Text = saldo

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Confirmacion("¿Está seguro que desea finalizar esta Orden de Trabajo?", Me.ParentForm) = True Then
            If Me.cmbTecnico.SelectedIndex >= 0 Then

                If Me.txtDiagnostico.Text <> "" Then
                Else
                    Me.txtDiagnostico.Text = "SN"
                End If

                If Me.txtValor.Text <> "" Then

                    Call CalcularSaldo()

                    If objOrdenTrab.TerminarOrdenTrabajo(coddoc, correlativo, Me.txtDiagnostico.Text, Double.Parse(Me.txtValor.Text), Me.txtFechaFinalizado.DateTime, CType(Me.cmbTecnico.SelectedValue, Integer)) = True Then
                        Me.btnGuardarAceptar.PerformClick()
                    Else
                        MsgBox("No se logró finalizar la orden de Trabajo. Error: " & GlobalDesError)
                    End If
                Else
                    MsgBox("Escriba el valor final del trabajo realizado")
                End If
            Else
                MsgBox("Seleccione un Técnico/Mecánico de la lista")
            End If
        End If

    End Sub

End Class
