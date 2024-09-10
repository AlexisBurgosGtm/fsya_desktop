Public Class viewCajaEfectivo
    Sub New(ByVal _codcaja As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        codcaja = _codcaja
    End Sub

    Dim codcaja As Integer

    Private Sub viewCajaEfectivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtEfectivoInicial.select()

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Me.txtEfectivoInicial.Text <> "" Then
            If Me.txtEfectivoLimite.Text <> "" Then
            Else
                Me.txtEfectivoLimite.Text = "0"
            End If

            If Confirmacion("¿Está seguro que desea aperturar esta caja?", Me.ParentForm) = True Then
                Dim obC As New classCorteCaja

                Dim inicial As Double = Double.Parse(Me.txtEfectivoInicial.Text)
                Dim limite As Double = Double.Parse(Me.txtEfectivoLimite.Text)

                If obC.abrirCaja(codcaja, inicial, limite) = True Then
                    Call Form1.Mensaje("Caja aperturada exitosamente!!")
                    Me.btnAceptarTrue.PerformClick()
                End If
            End If

        Else
            MsgBox("Escriba el efectivo inicial de la caja")
        End If

    End Sub


End Class
