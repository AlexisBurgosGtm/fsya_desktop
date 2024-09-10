Imports System.Data.SqlClient
Public Class viewEmpresasHost

    Private Sub viewEmpresasHost_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call CargarGrid()

    End Sub


    'SUB PARA CARGAR GRID
    Private Sub CargarGrid()
        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If
                Dim CMD As New SqlCommand("SELECT EMPNIT, EMPNOMBRE, EMPMESPROCESO, TOKEN, TIPOPRECIO
                                           FROM COMMUNITY_EMPRESAS_SYNC", cnh)
                Dim da As New SqlDataAdapter
                da.SelectCommand = CMD
                Dim tbl As New DataTable
                da.Fill(tbl)

                Me.gridHOSTING.DataSource = Nothing
                Me.gridHOSTING.DataSource = tbl


            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using
    End Sub

    'RUTINA PARA EDITAR REGISTRO

    Dim drw As DataRow

    Private Sub GridViewHOSTING_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewHOSTING.FocusedRowChanged
        drw = Nothing
        Try
            drw = Me.GridViewHOSTING.GetFocusedDataRow
            Me.txtCODSUCURSAL.Text = drw.Item(0).ToString
            Me.txtNOMSUCURSAL.Text = drw.Item(1).ToString
            Me.cmBDOMICILIO.Text = drw.Item(2).ToString
            Me.cmBHABILITADA.Text = drw.Item(3).ToString
            Me.cmBCATALOGO.Text = drw.Item(4).ToString
        Catch ex As Exception
        End Try
    End Sub


    Private Sub editarSucursal()
        Using cnh As New SqlConnection(strHostConectionString)
            Try
                If cnh.State <> ConnectionState.Open Then
                    cnh.Open()
                End If
                Dim CMD As New SqlCommand("UPDATE COMMUNITY_EMPRESAS_SYNC
                                           SET EMPNOMBRE = @N, EMPMESPROCESO = @D, TOKEN = @H, TIPOPRECIO = @P
                                           WHERE EMPNIT = @E", cnh)
                CMD.Parameters.AddWithValue("@N", Me.txtNOMSUCURSAL.Text)
                CMD.Parameters.AddWithValue("@D", Me.cmBDOMICILIO.Text)
                CMD.Parameters.AddWithValue("@H", Me.cmBHABILITADA.Text)
                CMD.Parameters.AddWithValue("@E", Me.txtCODSUCURSAL.Text)
                CMD.Parameters.AddWithValue("@P", Me.cmBCATALOGO.Text)
                CMD.ExecuteNonQuery()
                MsgBox("Sucursal Acualizada Exitosamente")
                Call CargarGrid()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Using
    End Sub



    Private Sub btnGUARDAR_Click(sender As Object, e As EventArgs) Handles btnGUARDAR.Click

        If Confirmacion("¿Esta seguro que desea actualizar estos datos?", Form1) = True Then
            Call editarSucursal()
        End If

    End Sub
End Class
