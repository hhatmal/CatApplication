Imports System.Net
Imports Newtonsoft.Json

Class MainWindow
    Private Class RootObject
        Public breeds As List(Of Integer)
        Public height As Integer
        Public id As String
        Public url As String
        Public width As Integer
    End Class

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim Request As HttpWebRequest = WebRequest.Create("https://api.thecatapi.com/v1/images/search?limit=1")
            Request.Method = "GET"
            Request.Headers.Add("x-api-key", "2c80fe84-a486-468d-b294-97620c55f99f")

            Dim Response As HttpWebResponse = Request.GetResponse
            Dim ResponseStream As System.IO.Stream = Response.GetResponseStream

            Dim StreamReader As New System.IO.StreamReader(ResponseStream)
            Dim Data As String = StreamReader.ReadToEnd
            StreamReader.Close()

            Dim jsonResulttodict = JsonConvert.DeserializeObject(Of List(Of RootObject))(Data)
            Dim url = jsonResulttodict(0).url

            Dim src As Uri = New Uri(url)
            Dim bitmap As BitmapImage = New BitmapImage(src)
            Dim img As Image = New Image()
            Image.Source = bitmap
        Catch ex As Exception
            Debug.Print("Error making API call!")
        End Try
    End Sub

End Class
