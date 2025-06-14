Public Class Form2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnsabado.Click
        mostrar.Text = "efectivamente es sabado"
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btnlunes_Click(sender As Object, e As EventArgs) Handles Btnlunes.Click
        mostrar.Text = "efectivamente es lunes"
    End Sub

    Private Sub btnmartes_Click(sender As Object, e As EventArgs) Handles btnmartes.Click
        mostrar.Text = "efectivamente es martes"
    End Sub

    Private Sub Btnmiercoles_Click(sender As Object, e As EventArgs) Handles Btnmiercoles.Click
        mostrar.Text = "efectivamente es miercoles"
    End Sub

    Private Sub Btnjueves_Click(sender As Object, e As EventArgs) Handles Btnjueves.Click
        mostrar.Text = "efectivamente es jueves"
    End Sub

    Private Sub Btnviernes_Click(sender As Object, e As EventArgs) Handles Btnviernes.Click
        mostrar.Text = "efectivamente es viernes"
    End Sub

    Private Sub btndomingo_Click(sender As Object, e As EventArgs) Handles btndomingo.Click
        mostrar.Text = "efectivamente es domiingo"
    End Sub
End Class