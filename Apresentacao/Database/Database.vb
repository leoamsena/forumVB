Public Class Database
    Private Const strConn As String = "Provider=SQLOLEDB;workstation id=forumdb.mssql.somee.com;packet size=4096;user id=leoamsena_SQLLogin_1;pwd=oolz1e5slp;data source=forumdb.mssql.somee.com;persist security info=False;initial catalog=forumdb"
    Public Shared ReadOnly Property getConn
        Get
            Return New OleDb.OleDbConnection(strConn)
        End Get
    End Property



End Class
