Imports System.IO
Imports System.Net
Imports System.Text
Public Class Postclas


    Public Function Selfpost(url As String, postdata As String) As String

        ' Create a request using a URL that can receive a post. 
        Dim request As WebRequest = WebRequest.Create(url)
        ' Set the Method property of the request to POST.
        request.Method = "POST"
        ' Create POST data and convert it to a byte array.


        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postdata)
        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"
        ' Set the ContentLength property of the WebRequest.
        request.ContentLength = byteArray.Length
        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()
        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)
        ' Close the Stream object.
        dataStream.Close()
        ' Get the response.
        Dim response As WebResponse = request.GetResponse()
        ' Display the status.
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()
        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)
        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()
        ' Display the content.
        Console.WriteLine(responseFromServer)
        Console.Read()
        ' Clean up the streams.
        Return responseFromServer
        reader.Close()
        dataStream.Close()
        response.Close()
    End Function
End Class
