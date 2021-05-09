Partial Public Class mdlPost
    Public Sub New(Title As String, Text As String,
                   PDate As DateTime,
                   Funcionario As mdlFuncionario,
                   Optional Id As Integer = 0)
        FPostDate = PDate
        FTitle = Title
        FText = Text
        FUser = Funcionario
        FId = Id
    End Sub
End Class
