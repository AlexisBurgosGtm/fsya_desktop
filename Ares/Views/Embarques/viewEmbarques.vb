Imports System.Data.SqlClient
Imports DevExpress.XtraBars.Docking2010.Customization

Public Class viewEmbarques

    Sub New(ByVal _catalogo As Boolean, ByVal _drw As DataRow)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bolTipoCatalogo = _catalogo
        drw = _drw

    End Sub
    'false = guardar
    'true = editar
    Dim bolTipoCatalogo As Boolean
    Dim drw As DataRow

    Private Sub viewEmbarques_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.txtFecha.DateTime = Today.Date

        Dim objRep As New classRepartidores
        With Me.cmbRepartido
            .DataSource = objRep.tblRepartidoresActivos(GlobalEmpNit)
            .ValueMember = "CODREP"
            .DisplayMember = "DESREP"
        End With

        If bolTipoCatalogo = True Then
            Me.txtCodigo.Enabled = False
            Me.btnGuardar.Text = "EDITAR"
            Me.txtCodigo.Text = drw.Item(0).ToString
            Me.txtDescripcion.Text = drw.Item(1).ToString
            Me.cmbRepartido.SelectedValue = CType(drw.Item(2), Integer)
            Me.txtFecha.DateTime = Date.Parse(drw.Item(4))
        End If

    End Sub



    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.cmbRepartido.SelectedIndex >= 0 Then
        Else
            MsgBox("Seleccione un Repartidor de la Lista. Si la lista está vacía, vaya a Mantenimientos y cree uno.")
            Exit Sub
        End If

        If bolTipoCatalogo = False Then 'guardado

            If Confirmacion("Está seguro que desea CREAR este nuevo Embarque?", Me.ParentForm) = True Then

                Dim objEmb As New classEmbarques
                If objEmb.verifyEmbarque(Me.txtCodigo.Text) = True Then
                    MsgBox("Código de Embarque ya existe, utilice otro por favor")
                Else
                    If objEmb.insertEmbarque(Me.txtCodigo.Text, Me.txtDescripcion.Text, CType(Me.cmbRepartido.SelectedValue, Integer), Me.txtFecha.DateTime) = True Then
                        MsgBox("Embarque creado exitosamente")
                        Me.btnAceptarTrue.PerformClick()
                    Else
                        MsgBox("No se pudo guardar el nuevo Embarque. Error: " & objEmb.DesError.ToString)
                    End If
                End If

            End If

        Else 'editado

            If Confirmacion("Está seguro que desea EDITAR este Embarque?", Me.ParentForm) = True Then

                Dim objEmb As New classEmbarques
                If objEmb.editEmbarque(Me.txtCodigo.Text, Me.txtDescripcion.Text, CType(Me.cmbRepartido.SelectedValue, Integer), Me.txtFecha.DateTime) = True Then
                    MsgBox("Embarque Editado exitosamente")
                    Me.btnAceptarTrue.PerformClick()
                Else
                    MsgBox("No se pudo Editar el Embarque. Error: " & objEmb.DesError.ToString)
                End If

            End If

        End If



    End Sub



    Private Sub txtCodigo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmbRepartido.select()
        End If
    End Sub

    Private Sub cmbRepartido_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbRepartido.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtDescripcion.select()
        End If
    End Sub

    Private Sub txtDescripcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtFecha.select()
        End If
    End Sub

    Private Sub txtFecha_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFecha.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnGuardar.select()
        End If
    End Sub


End Class
