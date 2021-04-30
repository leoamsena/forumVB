Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objFunc As Pessoa = New Funcionario("137.808.876-06", "Leo", "teste", "opa")
    End Sub
End Class