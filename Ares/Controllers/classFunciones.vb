
Imports Newtonsoft.Json
Imports System.IO
Imports System.Threading.Tasks

Public Class classFunciones

    Public Function fcnCrearLog(ByVal texto As String) As Boolean
        Dim result As Boolean

        Try
            Dim ruta As String = Application.StartupPath + "\ErrorLog.txt"
            Dim escritor As StreamWriter
            escritor = File.AppendText(ruta)
            escritor.WriteLine(texto)
            escritor.Flush()
            escritor.Close()

        Catch ex As Exception

        End Try

        'Form1.Mensaje("Hay problemas con algunos productos, abre el archivo ErrorLog.txt para verificar la lista")
        Return result

    End Function

    Async Function MesageAsync(ByVal msn As String) As Threading.Tasks.Task(Of Boolean)
        Dim f As Boolean = Await Task(Of Boolean).Run(Function() Form1.Mensaje(msn))
    End Function

    Public Function ExportarJson(ByVal tbl As DataTable) As Boolean

        Dim result As Boolean

        Dim dataSet As DataSet = New DataSet("dataSet")
        dataSet.Tables.Add(tbl)

        Dim json As String = JsonConvert.SerializeObject(dataSet, Formatting.Indented)

        'QUITA LOS ESPACIOS DEL TBL
        'json = Strings.Mid(json, 22)
        'json = Strings.Left(json, Strings.Len(json) - 3)

        Dim fic As String = Application.StartupPath + "\EXPORTS\productos.json"

        Try

            Dim sw As New System.IO.StreamWriter(fic, True)
            sw.WriteLine(json)
            sw.Close()

            result = True

        Catch ex As Exception
            result = False
        End Try

        Return result

    End Function


End Class
