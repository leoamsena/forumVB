Public MustInherit Class Pessoa
    Private FCPF As String
    Private FNome As String

    Public ReadOnly Property getCPF
        Get
            Return FCPF
        End Get
    End Property
    Public ReadOnly Property getNome
        Get
            Return FNome
        End Get
    End Property

    Public Sub New(CPF As String, Nome As String)
        If CheckCPF(CPF) = True Then
            FCPF = CPF
        Else
            Throw New InvalidCPF()
        End If

        FNome = Nome
    End Sub

    Public Sub New(Nome As String)
        FNome = Nome
    End Sub
    Private Function CheckCPF(CPF As String) As Boolean
        Try
            CPF = CPF.Replace(".", "")
            CPF = CPF.Replace("-", "")


            If CPF.Length <> 11 Then
                Throw New InvalidCPF("Tamanho")

            End If
            Dim arrCPF = CPF.ToCharArray()
            Dim numFirst As Integer = 0
            Dim numSecond As Integer = 0
            Dim bolIdentic As Boolean = True
            Dim chrLast As Char = arrCPF(0)
            For i As Integer = 0 To 8
                numFirst += Val(arrCPF(i)) * (10 - i)

                numSecond += Val(arrCPF(i)) * (11 - i)
                If chrLast <> arrCPF(i) Then
                    bolIdentic = False
                End If
                chrLast = arrCPF(i)
            Next
            If bolIdentic Then
                Throw New InvalidCPF()
            End If
            numSecond += Val(arrCPF(9)) * 2

            numFirst = 11 - (numFirst Mod 11)
            numFirst = If(numFirst >= 10, 0, numFirst)

            numSecond = 11 - (numSecond Mod 11)
            numSecond = If(numSecond >= 10, 0, numSecond)


            If numFirst <> Val(arrCPF(9)) Then
                Throw New InvalidCPF("Primeiro")
            End If
            If numSecond <> Val(arrCPF(10)) Then
                Throw New InvalidCPF("Segundo")
            End If
            Return True
        Catch ex As InvalidCPF
            Return False
        Catch ex As Exception

            Return False
        End Try


    End Function



End Class
