Imports System.IO
Imports System.Net


Module MainProgram

    Sub Main()
        ' Create a request for the URL.   
        Dim request As WebRequest = WebRequest.Create("http://webServerURL/webapi/api/Products/GetAllProducts")
        ' If required by the server, set the credentials.  
        request.Credentials = CredentialCache.DefaultCredentials
        ' Get the response.  
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.  
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.  
        Dim dataStream As Stream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.  
        Dim reader As New StreamReader(dataStream)
        ' Read the content.  
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.  
        Console.WriteLine(responseFromServer)
        ' Clean up the streams and the response.  
        reader.Close()
        response.Close()
    End Sub

End Module
