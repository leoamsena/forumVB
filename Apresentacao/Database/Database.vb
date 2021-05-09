Public Class Database
    Private Const STR_CONN As String = "Provider=SQLOLEDB;workstation 
        id=forumdb.mssql.somee.com;packet size=4096;user id=leoamsena_SQLLogin_1;
        pwd=oolz1e5slp;data source=forumdb.mssql.somee.com;
        persist security info=False;initial catalog=forumdb"
    Protected Shared ReadOnly Property Conn
        Get
            Return New OleDb.OleDbConnection(STR_CONN)
        End Get
    End Property

    Public Sub readWithDataSetExample()
        Dim strSql As String = "SELECT * FROM posts"
        Dim da As New OleDb.OleDbDataAdapter(strSql, STR_CONN)
        Dim dt As New DataTable("posts")

        da.Fill(dt)
        da.FillSchema(dt, SchemaType.Source)

        For Each row As DataRow In dt.Rows
            Dim titulo As String = row.Field(Of String)("titulo")
            Dim texto As String = row.Field(Of String)("texto")
        Next
    End Sub
    Public Sub readWithDataSetExample2()
        Dim strSql As String = "SELECT * FROM posts"
        Dim da As New OleDb.OleDbDataAdapter(strSql, STR_CONN)
        Dim ds As New DataSet()

        da.Fill(ds, "posts")

        strSql = "SELECT * FROM funcionarios"
        da = New OleDb.OleDbDataAdapter(strSql, STR_CONN)
        For Each row As DataRow In ds.Tables("funcionarios").Rows
            Dim cpf As String = row.Field(Of String)("CPF")
            Dim nome As String = row.Field(Of String)("nome")
        Next
    End Sub



    ' Select TOP 1 * FROM Funcionarios WHERE email = ? AND password = ?
    ' coon
    ' email@email.com
    ' senha123
    Public Function MountCmd(strSQL As String, connection As OleDb.OleDbConnection,
                             ParamArray params() As String) As OleDb.OleDbCommand
        Dim cmd As New OleDb.OleDbCommand(strSQL, connection)
        Dim count As Integer = 1
        If params IsNot Nothing Then
            For Each param As String In params
                cmd.Parameters.AddWithValue("@p" & count, param)
                count += 1
            Next
        End If
        Return cmd
    End Function

    Public Function SaveRecord(cmd As OleDb.OleDbCommand, connection As OleDb.OleDbConnection) As Boolean
        connection.Open()
        Dim icount As Integer
        icount = cmd.ExecuteNonQuery()
        connection.Close()
        Return icount >= 1
    End Function

    Public Overridable Function SearchRecords(cmd As OleDb.OleDbCommand, conection As OleDb.OleDbConnection) As Queue
        conection.Open()
        Dim sqlReader As OleDb.OleDbDataReader = cmd.ExecuteReader()
        Dim exists As Boolean = sqlReader.HasRows
        Dim objReturn As New Queue()
        If exists Then
            While sqlReader.Read()
                Dim objDic As New Dictionary(Of String, String)
                Dim values(sqlReader.FieldCount) As Object
                sqlReader.GetValues(values)
                For i As Integer = 0 To (sqlReader.FieldCount - 1)
                    objDic.Add(sqlReader.GetName(i), values(i).ToString)
                Next
                objReturn.Enqueue(objDic)
            End While
        Else
            conection.Close()
            Return Nothing
        End If
        conection.Close()
        Return objReturn
    End Function
    Public Shared Function GetHash(strToHash As String)
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
