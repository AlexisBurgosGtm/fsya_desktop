Imports System.Data.SqlClient
Imports System.Data
Public Class viewProgramador

    Private Sub viewProgramador_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me.cmbSUCURSALES
            .DataSource = getTblEmpresasHost()
            .ValueMember = "CONEXION"
            .DisplayMember = "NOMBRE"
        End With

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            Try

                If cn.State = ConnectionState.Open Then
                Else
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(Me.txtQuery.Text, cn)
                Dim r As Integer = cmd.ExecuteNonQuery
                MsgBox("rows: " & r.ToString)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Using cn As New SqlConnection(Me.cmbSUCURSALES.SelectedValue.ToString)
            Try


                If cn.State = ConnectionState.Open Then
                Else
                    cn.Open()
                End If

                Dim cmd As New SqlCommand(Me.txtQuery.Text, cn)
                Dim tbl As New DataTable
                Dim da As New SqlDataAdapter
                da.SelectCommand = cmd
                da.Fill(tbl)
                Me.grid.DataSource = Nothing
                Me.grid.DataSource = tbl
                Me.grid.Refresh()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Using
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        'DevExpress.XtraBars.Docking2010.Customization.FlyoutDialog.Show(Me.ParentForm, New viewConfigUpdater)
        Me.txtQuery.Text = "DECLARE @TableName varchar(200)
                            DECLARE TableCursor CURSOR FOR
                            SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_TYPE = 'BASE TABLE'
                            OPEN TableCursor
                            FETCH NEXT FROM TableCursor INTO @TableName
                            WHILE @@FETCH_STATUS = 0
                            BEGIN
                            PRINT 'Reindexando ' + @TableName
                            DBCC DBREINDEX (@TableName)
                            FETCH NEXT FROM TableCursor INTO @TableName
                            END
                            CLOSE TableCursor
                            DEALLOCATE TableCursor"

    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Me.txtQuery.Text = ""
        Me.txtQuery.select()
    End Sub



    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs)


        Dim sql As String = ""
        sql = "ALTER TABLE EMPRESAS ADD REGIMEN VARCHAR(1) NULL;
               ALTER TABLE EMPRESAS ADD IMPUESTO FLOAT NULL;
               ALTER TABLE EMPRESAS ADD NOSUCURSAL VARCHAR(100) NULL;
               ALTER TABLE EMPRESAS ADD MONEDA VARCHAR(1) NULL;
               ALTER TABLE TEMP_VENTAS ADD COSTOUNITARIO FLOAT NULL;
               ALTER TABLE TEMP_VENTAS ADD PRECIOSINIVA FLOAT NULL;
               ALTER TABLE TEMP_VENTAS ADD TOTALPRECIOSINIVA FLOAT NULL;
               ALTER TABLE TEMP_VENTAS ADD TIPOPROD VARCHAR(1) NULL;
               ALTER TABLE DOCUMENTOS ADD TOTALIVA FLOAT NULL;               
               ALTER TABLE DOCUMENTOS ADD TOTALSINIVA FLOAT NULL;
               ALTER TABLE DOCPRODUCTOS ADD COSTOUNITARIO FLOAT NULL;
               ALTER TABLE DOCPRODUCTOS ADD PRECIOSINIVA FLOAT NULL;
               ALTER TABLE DOCPRODUCTOS ADD TOTALPRECIOSINIVA FLOAT NULL;
               ALTER TABLE DOCPRODUCTOS ADD TIPOPROD VARCHAR(1) NULL;       
               "


        Me.txtQuery.Text = sql

    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Me.txtQuery.Text = "DECLARE @SQL VARCHAR(1000)  
                DECLARE @DB sysname

                --Creo un cursor para consultar el nombre de todas las bases de datos, excepto las de sistema
                DECLARE curDB CURSOR FORWARD_ONLY STATIC FOR  
                    SELECT [name]  
                    FROM sys.databases
                    WHERE state = 0 AND Name NOT IN ('master','model','msdb','tempdb')
                    ORDER BY [name] 

                --Abro el cursor y por cada base ejecuto el stored procedure que actualiza las estadísticas
                OPEN curDB  
                FETCH NEXT FROM curDB INTO @DB  
                WHILE @@FETCH_STATUS = 0
                    BEGIN
                        SET @SQL = 'USE [' + @DB +']' + CHAR(13) + 'EXEC sp_updatestats' + CHAR(13)
                        PRINT @SQL
                        EXEC (@SQL)
                        FETCH NEXT FROM curDB INTO @DB  
                    END  

                --Cierro y elimino el cursor
                CLOSE curDB  
                DEALLOCATE curDB"
    End Sub

    Private Sub SimpleButton6_Click_1(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Me.txtQuery.Text = "DBCC SHRINKFILE (2, 1);"
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Me.txtQuery.Text = "declare @empnit varchar(50);
        set @empnit = 'PONER_NIT_ACTUAL_AQUI';
        declare @empnitnuevo varchar(50);
        set @empnitnuevo = 'NUEVO EMPNIT';

        UPDATE BODEGAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE CAJAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE CLASIFICACIONDOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE CLASIFICACIONTRES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE CLASIFICACIONUNO SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE CLIENTES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE CLIENTES_VEHICULOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE CORTES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE DOCPRODUCTOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE DOCUMENTOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE EMPLEADOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE VENDEDORES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE EMPRESAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE INVCIERRES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE INVSALDO SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE MARCAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE MEDIDAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE PRECIOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE PRODUCTOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE PRODUCTOS_FOTOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE PRODUCTOS_RECETAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE PRODUCTOS_PRECIOSCOMPETENCIA SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE PROVEEDORES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE RESTAURANTE_MESAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE TASKS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE REPARTIDORES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE SALDOCLIENTES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE SERIES SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE TEMP_VENTAS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE TIPODOCUMENTOS SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE PRODUCTOS_PRECIOSCOMPETENCIA SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;
        UPDATE DOCUMENTOS_ORDENTRABAJO SET EMPNIT=@empnitnuevo WHERE EMPNIT=@empnit;"


    End Sub

End Class
