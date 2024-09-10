Public Class viewFELVentas

    Private Sub viewFELVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.cmbTipoFactura.SelectedIndex = 0
        Call getComboboxes()

    End Sub

    Dim objTipoDoc As New ClassTipoDocumentos(GlobalEmpNit)
    Dim objProd As New ClassProductos

    Private Function getComboboxes()
        Dim r As Boolean

        'COMBO CONTADO CREDITO
        Dim tblConCre As New DataTable
        With tblConCre
            .Columns.Add("C", GetType(String))
            .Columns.Add("D", GetType(String))
        End With

        With tblConCre.Rows
            .Add(New Object() {"CON", "CONTADO"})
            .Add(New Object() {"CRE", "CREDITO"})
        End With

        With Me.cmbConCre
            .DataSource = tblConCre
            .ValueMember = "C"
            .DisplayMember = "D"
            .SelectedIndex = 0
        End With

        'COMBO SERIE FACT

        With Me.cmbCoddoc
            .DataSource = objTipoDoc.tblCoddoc("FEF")
            .ValueMember = "CODDOC"
            .DisplayMember = "CODDOC"
            .SelectedIndex = 0
        End With

        'COMBO TIPO FAC




        'TIPO PROD
        With Me.cmbTipProd
            .DataSource = objProd.tblTipoProd("FELFAC")
            .DisplayMember = "DESC"
            .ValueMember = "TIPO"
            .SelectedIndex = 0
        End With

        'TIPO PRECIO
        With Me.cmbTipoPrecio
            .DataSource = objProd.tblTipoPrecio
            .DisplayMember = "DESC"
            .ValueMember = "TIPO"
            .SelectedIndex = 0
        End With


        Return r

    End Function

End Class
