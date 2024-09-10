Public Class viewProductosVencimiento

    Sub New(ByVal _soloVencidos As Boolean)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        boolInicialSoloVencidos = _soloVencidos

    End Sub
    Dim boolInicialSoloVencidos As Boolean

    Dim objProductos As New ClassProductos
    Dim boolCargado As Boolean = False
    Private Sub viewProductosVencimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CargarGridVencimientos(boolInicialSoloVencidos)
        Me.SwitchFiltro.IsOn = boolInicialSoloVencidos
    End Sub
    Private Sub CargarGridVencimientos(ByVal soloVencidos As Boolean)
        Me.GridVencidos.DataSource = Nothing
        If soloVencidos = True Then
            Me.GridVencidos.DataSource = objProductos.tblVencimientoProductosVencidos(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
        Else
            Me.GridVencidos.DataSource = objProductos.tblVencimientoProductos(GlobalEmpNit, GlobalAnioProceso, GlobalMesProceso)
        End If

        boolCargado = True
    End Sub

    Private Sub GridViewVence_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridViewVence.CellValueChanged
        If boolCargado = True Then

            Dim x As Integer
            x = MsgBox("¿Desea actualizar la fecha de vencimiento de este producto?", MsgBoxStyle.OkCancel)
            If x = MsgBoxResult.Ok Then
                Dim codigoprod As String = Me.GridViewVence.GetFocusedDataRow.Item(0).ToString
                Dim fechavence As Date = Date.Parse(Me.GridViewVence.GetFocusedDataRow.Item(4))
                If objProductos.updateFechaVencimiento(GlobalEmpNit, codigoprod, fechavence) = True Then
                    Form1.Mensaje("Fecha actualizada exitosamente...")
                End If

            End If

        End If
    End Sub



    Private Sub SwitchFiltro_Toggled(sender As Object, e As EventArgs) Handles SwitchFiltro.Toggled
        'true vencidos, false todos
        Call CargarGridVencimientos(Me.SwitchFiltro.IsOn)
    End Sub
End Class
