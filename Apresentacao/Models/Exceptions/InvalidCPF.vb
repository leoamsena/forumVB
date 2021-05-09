Public Class InvalidCPF
    Inherits Exception
    Private FAbout As String
    Public Sub New(Optional Op As String = "CPF inválido")
        MyBase.New(Op)
        FAbout = Op
    End Sub
    Public ReadOnly Property About As String
        Get
            Return FAbout
        End Get
    End Property

End Class
