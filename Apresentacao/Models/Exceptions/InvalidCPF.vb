Public Class InvalidCPF
    Inherits Exception
    Private FOp As String
    Public Sub New(Optional Op As String = "")
        FOp = Op
    End Sub
    Public ReadOnly Property getOp() As String
        Get
            Return FOp
        End Get
    End Property

End Class
