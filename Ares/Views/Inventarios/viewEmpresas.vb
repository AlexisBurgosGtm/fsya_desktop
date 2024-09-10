Public Class viewEmpresas
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub viewEmpresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim objs As New express_sync.classSqlSvrSync(strSqlConectionString, strHostConectionString, Token, StrMyHostConnection)

        With Me.cmbEmpresasHost
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .DataSource = objs.tblEmpresas(GlobalEmpNit)
            .ValueMember = "EMPNIT"
            .DisplayMember = "EMPNOMBRE"
        End With



    End Sub


    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

        If Me.cmbEmpresasHost.SelectedIndex >= 0 Then
            SelectedDescripcion = Me.cmbEmpresasHost.SelectedValue.ToString
            SelectedNomSucursal = Me.cmbEmpresasHost.Text
            Me.btnAceptar.PerformClick()
        Else
            Me.btnCancel.PerformClick()
        End If

    End Sub
End Class
