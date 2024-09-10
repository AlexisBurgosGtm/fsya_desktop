Public Class viewFechaProv

    Private Sub viewFechaProv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Call cargarComboProveedores()

    End Sub

    Private Sub cargarComboProveedores()
        Dim ObjProveedores As New ClassProveedores
        Dim tblprov As New DataTable

        'blVend = ObjEmpleados.tblListaEmpleados(GlobalEmpNit)
        tblprov = ObjProveedores.tblListaProveedores(GlobalEmpNit)

        'PROVEEDORES
        With Me.cmbProveedor
            .DataSource = tblprov
            .DisplayMember = "EMPRESA"
            .ValueMember = "CODPROV"
        End With
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        GlobalParamMesInicial = Integer.Parse(Me.cmbMesDocumento.SelectedValue)
        GlobalParamMesFinal = Integer.Parse(Me.cmbMesDocumento2.SelectedValue)
        GlobalParamAnioCurso = Integer.Parse(Me.cmbAnioDocumento.Text)
        GlobalParamProveedor = Integer.Parse(Me.cmbProveedor.SelectedValue)
        Me.btnAceptarReal.PerformClick()

    End Sub

End Class
