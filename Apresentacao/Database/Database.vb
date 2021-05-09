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
        Dim dataAdapter As New OleDb.OleDbDataAdapter(strSql, STR_CONN)
        Dim dataTable As New DataTable("posts")

        dataAdapter.Fill(dataTable)
        dataAdapter.FillSchema(dataTable, SchemaType.Source)

        For Each row As DataRow In dataTable.Rows
            Dim varTitulo As String = row.Field(Of String)("titulo")
            Dim varTexto As String = row.Field(Of String)("texto")
        Next
    End Sub
    Public Sub readWithDataSetExample2()
        Dim strSql As String = "SELECT * FROM posts"
        Dim dataAdapter As New OleDb.OleDbDataAdapter(strSql, STR_CONN)
        Dim dataSet As New DataSet()

        dataAdapter.Fill(dataSet, "posts")

        strSql = "SELECT * FROM funcionarios"
        dataAdapter = New OleDb.OleDbDataAdapter(strSql, STR_CONN)
        For Each row As DataRow In dataSet.Tables("funcionarios").Rows
            Dim varCpf As String = row.Field(Of String)("CPF")
            Dim varName As String = row.Field(Of String)("nome")
        Next
    End Sub



    ' Select TOP 1 * FROM Funcionarios WHERE email = ? AND password = ?
    ' coon
    ' email@email.com
    ' senha123
    Public Function MountCmd(strSQL As String, connection As OleDb.OleDbConnection,
                             ParamArray params() As String) As OleDb.OleDbCommand
        Dim objCommand As New OleDb.OleDbCommand(strSQL, connection)
        Dim numAux As Integer = 1
        If params IsNot Nothing Then
            For Each param As String In params
                objCommand.Parameters.AddWithValue("@p" & numAux, param)
                numAux += 1
            Next
        End If
        Return objCommand
    End Function

    Public Function SaveRecord(cmd As OleDb.OleDbCommand, connection As OleDb.OleDbConnection) As Boolean
        connection.Open()
        Dim numTablesAffected As Integer
        numTablesAffected = cmd.ExecuteNonQuery()
        connection.Close()
        Return numTablesAffected >= 1
    End Function

    Public Overridable Function SearchRecords(cmd As OleDb.OleDbCommand, conection As OleDb.OleDbConnection) As Queue
        conection.Open()
        Dim objDataReader As OleDb.OleDbDataReader = cmd.ExecuteReader()
        Dim blnDataExists As Boolean = objDataReader.HasRows
        Dim queue As New Queue()
        If blnDataExists Then
            While objDataReader.Read()
                Dim dictionary As New Dictionary(Of String, String)
                Dim varValues(objDataReader.FieldCount) As Object
                objDataReader.GetValues(varValues)
                For i As Integer = 0 To (objDataReader.FieldCount - 1)
                    dictionary.Add(objDataReader.GetName(i), varValues(i).ToString)
                Next
                queue.Enqueue(dictionary)
            End While
        Else
            conection.Close()
            Return Nothing
        End If
        conection.Close()
        Return queue
    End Function
    Public Shared Function GetHash(strToHash As String)
        Dim objMd5 As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)

        bytesToHash = objMd5.ComputeHash(bytesToHash)

        Dim strResult As String = ""

        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

End Class
