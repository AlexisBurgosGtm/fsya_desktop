Imports System.Data.SqlClient

Public Class viewInvFisicoConteo

    Dim oInvFis As New classInvFisico(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)

    Sub New(ByVal _coddoc As String, ByVal _correlativo As Double, ByVal _codprod As String, ByVal _desprod As String, ByVal _costo As Double)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lbDesprod.Text = _desprod
        desprod = _desprod
        Me.lbCodprod.Text = _codprod
        codprod = _codprod
        coddoc = _coddoc
        correlativo = _correlativo
        costo = _costo
    End Sub

    Dim coddoc As String, correlativo As Double
    Dim codprod, desprod As String, costo As Double

    Private Sub viewInvFisicoConteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtConteo.Text = "0"
        Me.txtObs.Text = "SN"

        Call getMedidas()

        Me.cmbMedida.select()

    End Sub

    Private Sub getMedidas()

        Dim tbl As New DataTable

        Using cn As New SqlConnection(strSqlConectionString)
            Try
                If cn.State <> ConnectionState.Open Then
                    cn.Open()
                End If

                Dim cmd As New SqlCommand
                With cmd
                    .CommandText = "SELECT CODMEDIDA, EQUIVALE, COSTO, PRECIO FROM PRECIOS WHERE EMPNIT=@E AND CODPROD=@C"
                    .Connection = cn
                    .Parameters.AddWithValue("@E", GlobalEmpNit)
                    .Parameters.AddWithValue("@C", codprod)
                End With
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)


            Catch ex As Exception
                tbl = Nothing
            End Try
        End Using

        With Me.cmbMedida
            .DataSource = tbl
            .DisplayMember = "CODMEDIDA"
            .ValueMember = "EQUIVALE"
        End With

        Me.lbEquivale.Text = Me.cmbMedida.SelectedValue.ToString

    End Sub
    Private Sub txtConteo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConteo.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtObs.select()
        End If
    End Sub

    Private Sub cmbMedida_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbMedida.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtCantidad.select()
        End If
    End Sub

    Private Sub cmbMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedida.SelectedIndexChanged
        Try
            Me.lbEquivale.Text = Me.cmbMedida.SelectedValue.ToString
        Catch ex As Exception
            Me.lbEquivale.Text = "-"
        End Try
    End Sub

    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.txtObs.select()
        End If
    End Sub

    Private Sub txtCantidad_Leave(sender As Object, e As EventArgs) Handles txtCantidad.Leave
        Try
            Dim cant As Double, equiv As Integer
            cant = Double.Parse(Strings.Replace(Me.txtCantidad.Text, ",", ""))
            equiv = CType(Me.lbEquivale.Text, Integer) 'CType(Me.cmbMedida.SelectedValue, Integer)
            Me.txtConteo.Text = (cant * equiv).ToString
        Catch ex As Exception
            MsgBox("Error: " + ex.ToString)
            Me.txtConteo.Text = ""
        End Try
    End Sub

    Private Sub txtObs_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.btnAceptar.select()
        End If
    End Sub

    Private Sub txtConteo_Leave(sender As Object, e As EventArgs) Handles txtConteo.Leave
        If Me.txtConteo.Text <> "" Then
        Else
            Me.txtConteo.Text = "0"
        End If
    End Sub


    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If Me.txtObs.Text <> "" Then
        Else
            Me.txtObs.Text = " "
        End If

        Dim conteo As Double = CType(Me.txtConteo.Text, Double)

        If oInvFis.insertConteo(coddoc, correlativo, codprod, desprod, Me.cmbMedida.Text & "( Eq: " & Me.lbEquivale.Text & ")", conteo, costo, Me.txtObs.Text, Me.cmbMedida.Text) = True Then
            Me.btnAceptarTrue.PerformClick()
        Else
            MsgBox("No se puedo agregar el registro. Error: " & oInvFis.DesError.ToString)
            Me.btnCancelar.PerformClick()
        End If

    End Sub


End Class
