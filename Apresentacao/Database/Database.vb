Public Class Database
    Private Const strConn As String = "Provider=SQLOLEDB;workstation id=forumdb.mssql.somee.com;packet size=4096;user id=leoamsena_SQLLogin_1;pwd=oolz1e5slp;data source=forumdb.mssql.somee.com;persist security info=False;initial catalog=forumdb"
    Public Shared ReadOnly Property getConn
        Get
            Return New OleDb.OleDbConnection(strConn)
        End Get
    End Property

    Public Shared Function hash(strToHash As String)
        Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

End Class
