Imports System.Data.SqlClient

Public Class Form3

    Dim dataBase As String = "base1"
    Dim serverName As String = "DESKTOP-J71LFTK\SQLEXPRESS"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles savePro.Click
        Dim conexion = New SqlConnection("server=" & serverName & "; database=" & dataBase & "; integrated security=true")
        conexion.Open()

        Dim user As String = BoxUser.Text
        Dim cedula As Integer
        If Not Integer.TryParse(BoxCedula.Text, cedula) Then
            MessageBox.Show("La cédula debe ser un número entero.")
            Exit Sub
        End If
        Dim password As String = BoxContra.Text

        Dim cadena As String = "INSERT INTO admin(nombreU, cedula, password) VALUES (@nombreU, @cedula, @password)"
        Dim comando As New SqlCommand(cadena, conexion)

        comando.Parameters.AddWithValue("@nombreU", user)
        comando.Parameters.AddWithValue("@cedula", cedula)
        comando.Parameters.AddWithValue("@password", password)

        Dim validar As Integer = comando.ExecuteNonQuery()

        If validar > 0 Then
            MessageBox.Show("Registro exitoso")
        Else
            MessageBox.Show("Error al registrar")
        End If

        BoxUser.Text = ""
        BoxCedula.Text = ""
        BoxContra.Text = ""

        conexion.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

End Class