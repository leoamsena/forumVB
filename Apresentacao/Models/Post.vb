Public Class Post
    Private FPostDate As DateTime
    Private FTitle As String
    Private FText As String
    Private FUsuario As Funcionario
    Private FId As Integer

    Public ReadOnly Property title
        Get
            Return FTitle
        End Get
    End Property

    Public ReadOnly Property text
        Get
            Return FText
        End Get
    End Property

    Public ReadOnly Property usuario
        Get
            Return FUsuario
        End Get
    End Property

    Public ReadOnly Property postDate
        Get
            Return FPostDate
        End Get
    End Property

    Public ReadOnly Property id
        Get
            Return FId
        End Get
    End Property

    Public Sub New(Title As String, Text As String, PDate As DateTime, Funcionario As Funcionario, Optional Id As Integer = 0)
        FPostDate = PDate
        FTitle = Title
        FText = Text
        FUsuario = Funcionario
        FId = Id
    End Sub
End Class
