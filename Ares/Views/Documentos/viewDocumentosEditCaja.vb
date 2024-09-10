Public Class viewDocumentosEditCaja
    Sub New(ByVal _coddoc As String, ByVal _correlativo As Double)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        coddoc = _coddoc
        correlativo = _correlativo

    End Sub

    Dim coddoc As String, correlativo As Double, codcaja As Integer
    Dim objD As New ClassDocumentos

    Private Sub viewDocumentosEditCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        With Me.cmbCajas
            .DataSource = objD.getTblCajas()
            .DisplayMember = "DESCRIPCION"
            .ValueMember = "CODIGO"
        End With


    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click, SimpleButton1.Click

        If Me.cmbCajas.SelectedIndex >= 0 Then

            If Confirmacion("¿Está seguro que desea Cambiar la Caja de este documento?", Me.ParentForm) = True Then
                codcaja = CType(Me.cmbCajas.SelectedValue, Integer)
                If objD.setCodCaja(coddoc, correlativo, codcaja) = True Then
                    Me.btnAceptarTrue.PerformClick()
                Else
                    MsgBox("Este documento ya ha sido incluído en un corte de caja, no se puede cambiar la caja actual")
                    Me.btnCancelar.PerformClick()
                End If

            End If

        Else
            MsgBox("Seleccione una caja de la lista")
        End If

    End Sub

End Class
