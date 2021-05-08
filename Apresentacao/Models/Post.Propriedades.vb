Partial Public Class Post
    Implements HasIdInterface
    Public ReadOnly Property id As Integer Implements HasIdInterface.id
        Get
            Return FId
        End Get
    End Property
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


End Class
