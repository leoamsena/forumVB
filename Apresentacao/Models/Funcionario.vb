Public NotInheritable Class Funcionario
    Inherits Pessoa
    Private FEmail As String
    Private FPassword As String
    Private FId As Integer
    Public Overrides ReadOnly Property Id
        Get
            Return FId
        End Get
    End Property

    Public ReadOnly Property Email
        Get
            Return FEmail
        End Get
    End Property
    Public ReadOnly Property Password
        Get
            Return FPassword
        End Get
    End Property
    Public Sub New(CPF As String, Nome As String, Email As String, Password As String, Optional Id As Integer = 0)
        MyBase.New(CPF, Nome)
        FEmail = Email
        FPassword = Password
        FId = Id
    End Sub
    Public Sub New(Nome As String)
        MyBase.New(Nome)
    End Sub
    Public Sub New(id As Integer)
        MyBase.New("")
        FId = id
    End Sub
End Class


