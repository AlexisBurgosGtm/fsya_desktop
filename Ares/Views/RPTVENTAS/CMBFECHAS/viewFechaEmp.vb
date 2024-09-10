Public Class viewFechaEmp

    Private Sub viewFechaEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbMesDocumento
            .DataSource = getTblMeses()
            .ValueMember = "CODMES"
            .DisplayMember = "CODMES"
        End With
        With Me.cmbMesDocumento2
            .DataSource = getTblMeses()
            .ValueMember = "CODMES"
            .DisplayMember = "CODMES"
        End With

        Me.cmbMesDocumento.SelectedValue = Integer.Parse(Today.Month)
        Me.cmbMesDocumento2.SelectedValue = Integer.Parse(Today.Month)
        Me.cmbAnioDocumento.Text = Today.Year.ToString

        Call cargarComboMarcas()

    End Sub

    Private Sub cargarComboMarcas()
        Dim ObjMarcas As New ClassEmpleados
        Dim tblEmpleados As New DataTable

        tblEmpleados = ObjMarcas.tblListaEmpleados(GlobalEmpNit)

        'EMPLEADOS
        With Me.cmbEmpleado
            .DataSource = tblEmpleados
            .DisplayMember = "NOMEMP"
            .ValueMember = "CODEMP"
        End With

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        GlobalParamMesInicial = Integer.Parse(Me.cmbMesDocumento.SelectedValue)
        GlobalParamMesFinal = Integer.Parse(Me.cmbMesDocumento2.SelectedValue)
        GlobalParamAnioCurso = Integer.Parse(Me.cmbAnioDocumento.Text)
        GlobalNomEmpleado = Integer.Parse(Me.cmbEmpleado.SelectedValue)
        Me.btnAceptarReal.PerformClick()

    End Sub

End Class