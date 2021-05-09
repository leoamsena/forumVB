Public MustInherit Class Pessoa
    Private FCpf As String
    Private FName As String

    Public MustOverride ReadOnly Property Id



    Public ReadOnly Property Cpf
        Get
            Return FCpf
        End Get
    End Property
    Public ReadOnly Property Name
        Get
            Return FName
        End Get
    End Property
    Public Sub New(CPF As String, Nome As String)
        If CheckCpf(CPF) = True Then
            FCpf = CPF
        Else
            Throw New InvalidCPF()
        End If

        FName = Nome
    End Sub
    Public Sub New(Nome As String)
        FName = Nome
    End Sub
    Private Function CheckCpf(CPF As String) As Boolean
        Try
            CPF = CPF.Replace(".", "")
            CPF = CPF.Replace("-", "")


            If CPF.Length <> 11 Then
                Throw New InvalidCPF("Tamanho")

            End If
            Dim arrCpf = CPF.ToCharArray()
            Dim numFirst As Integer = 0
            Dim numSecond As Integer = 0
            Dim blnIdentic As Boolean = True
            Dim chrLast As Char = arrCpf(0)
            For i As Integer = 0 To 8
                numFirst += Val(arrCpf(i)) * (10 - i)

                numSecond += Val(arrCpf(i)) * (11 - i)
                If chrLast <> arrCpf(i) Then
                    blnIdentic = False
                End If
                chrLast = arrCpf(i)
            Next
            If blnIdentic Then
                Throw New InvalidCPF()
            End If
            numSecond += Val(arrCpf(9)) * 2

            numFirst = 11 - (numFirst Mod 11)
            numFirst = If(numFirst >= 10, 0, numFirst)

            numSecond = 11 - (numSecond Mod 11)
            numSecond = If(numSecond >= 10, 0, numSecond)


            If numFirst <> Val(arrCpf(9)) Then
                Throw New InvalidCPF("Primeiro")
            End If
            If numSecond <> Val(arrCpf(10)) Then
                Throw New InvalidCPF("Segundo")
            End If
            Return True
        Catch ex As InvalidCPF
            Return False
        Catch ex As Exception
            Throw ex
        End Try


    End Function
End Class
