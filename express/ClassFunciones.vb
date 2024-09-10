Imports System.IO
Imports System.Web.Script.Serialization


Public NotInheritable Class ClassFunciones
    Sub New()

    End Sub

    Public Function CrearArchivoTexto(ByVal texto As String, ByVal rutaarchivo As String) As Boolean
        'Variables para abrir el archivo en modo de escritura
        Dim strStreamW As Stream
        Dim strStreamWriter As StreamWriter

        Try
            Dim ds As New DataSet

            Dim FilePath As String = rutaarchivo

            'Se abre el archivo y si este no existe se crea
            strStreamW = File.OpenWrite(FilePath)
            strStreamWriter = New StreamWriter(strStreamW,
                          System.Text.Encoding.UTF8)

            'Se traen los datos que necesitamos para el archivo
            'TraerDatosArchivo retorna un dataset pero perfectamente
            'podria ser cualquier otro tipo de objeto
            'Aquí debe llenar el dataset con los datos requeridos
            'ds = Negocios.TraerDatosArchivo()
            'Dim dr As DataRow
            'Dim Nombre As String = ""
            'Dim Apellido As String = ""
            'Dim Email As String = ""
            'For Each dr In ds.Tables(0).Rows
            'Obtenemos los datos del dataset
            'Nombre = CStr(dr("Nombre"))
            'Apellido = CStr(dr("Apellido"))
            'Email = CStr(dr("Email"))
            'Escribimos la línea en el achivo de texto
            'strStreamWriter.WriteLine(Nombre & " " & Apellido & " - " & Email)
            'Next
            strStreamWriter.WriteLine(texto)
            strStreamWriter.Close()

            Return True

        Catch ex As Exception
            strStreamWriter.Close()
            Return False
        End Try
    End Function


    Public Function DatableToJson(ByVal dt As DataTable) As String

        Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
        Dim rows As New List(Of Dictionary(Of String, Object))()
        Dim row As Dictionary(Of String, Object) = Nothing
        For Each dr As DataRow In dt.Rows
            row = New Dictionary(Of String, Object)()
            For Each dc As DataColumn In dt.Columns
                If dc.ColumnName.Trim() = "TAGNAME" Then
                    row.Add(dc.ColumnName.Trim(), dr(dc))
                End If
            Next
            rows.Add(row)
        Next
        Return serializer.Serialize(rows)
    End Function


End Class
