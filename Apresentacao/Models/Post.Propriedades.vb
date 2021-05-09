Partial Public Class mdlPost
    Implements HasIdInterface
    Public ReadOnly Property Id As Integer Implements HasIdInterface.Id
        Get
            Return FId
        End Get
    End Property
    Public ReadOnly Property Title
        Get
            Return FTitle
        End Get
    End Property
    Public ReadOnly Property Text
        Get
            Return FText
        End Get
    End Property
    Public ReadOnly Property User
        Get
            Return FUser

        End Get
    End Property
    Public ReadOnly Property PostDate
        Get
            Return FPostDate
        End Get
    End Property


End Class
