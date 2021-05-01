Public Class InvalidCPF
    Inherits Exception
    Private FOp As String
    Public Sub New(Optional Op As String = "CPF inválido")
        MyBase.New(Op)
        FOp = Op
    End Sub
    Public ReadOnly Property getOp() As String
        Get
            Return FOp
        End Get
    End Property

End Class
