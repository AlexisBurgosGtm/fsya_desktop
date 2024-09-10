Public Class viewFechaMarca

    Private Sub viewFechaMarca_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        Dim ObjMarcas As New ClassMarcas
        Dim tblmarc As New DataTable

        tblmarc = ObjMarcas.tblListaMarcas(GlobalEmpNit)

        'MARCAS
        With Me.cmbMarcas
            .DataSource = tblmarc
            .DisplayMember = "DESMARCA"
            .ValueMember = "CODMARCA"
        End With

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        GlobalParamMesInicial = Integer.Parse(Me.cmbMesDocumento.SelectedValue)
        GlobalParamMesFinal = Integer.Parse(Me.cmbMesDocumento2.SelectedValue)
        GlobalParamAnioCurso = Integer.Parse(Me.cmbAnioDocumento.Text)
        GlobalParamMarca = Integer.Parse(Me.cmbMarcas.SelectedValue)
        Me.btnAceptarReal.PerformClick()

    End Sub

End Class
