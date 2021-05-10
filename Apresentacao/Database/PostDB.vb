Public Class PostDB
    Inherits Database



    Public Function SearchPosts() As Post()
        Dim objConnection = Conn
        Dim objCommand As OleDb.OleDbCommand = MountCmd("Select p.*,f.Name FROM TB_POST AS p INNER JOIN TB_FUNCIONARIO AS F ON f.id = p.Funcionario_Id ORDER BY Date DESC", objConnection, Nothing)
        Dim objDict As Queue = SearchRecords(objCommand, objConnection)
        Dim arrPost As Post() = Nothing
        Dim numLength As Integer = 0
        If objDict IsNot Nothing Then
            For Each row As Dictionary(Of String, String) In objDict
                numLength += 1
                ReDim Preserve arrPost(numLength - 1)
                arrPost(numLength - 1) = New Post(row.Item("Title"), row.Item("Text"), row.Item("Date"), New Funcionario(row.Item("Funcionario_Id")), row.Item("Id"))
            Next
        End If
        Return arrPost

    End Function

    Public Function SavePost(post As Post) As Boolean
        Dim objConnection = Conn
        Dim objCommand = MountCmd("INSERT INTO TB_POST(Title,Text,Date,Funcionario_Id) VALUES (?,?, ?,? )", objConnection, post.Title, post.Text, post.PostDate, post.User.id)
        Return SaveRecord(objCommand, objConnection)
    End Function

End Class


