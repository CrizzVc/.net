Imports System.Data.SqlClient
Imports System.Reflection.Emit

Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1
    ' Variables para la conexión a la base de datos
    Dim dataBase As String = "base1"
    Dim serverName As String = "DESKTOP-J71LFTK\SQLEXPRESS"

    ' oculta el form actual y muestra el Form2
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub

    ' Muestra el Form3 para registrar un nuevo usuario
    Private Sub ButtonRegistar_Click(sender As Object, e As EventArgs) Handles ButtonRegistrar.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub ButtonIniciar_Click(sender As Object, e As EventArgs) Handles ButtonIniciar.Click
        ' crea una conexión a la base de datos
        Dim conexion As New SqlConnection("server=" & serverName & "; database=" & dataBase & "; integrated security=true")


        Try
            ' Abre la conexión a la base de datos
            conexion.Open()

            ' Verifica si los campos de cédula y contraseña están vacíos
            Dim cedula As Integer
            If Not Integer.TryParse(BoxCedula.Text, cedula) Then
                MessageBox.Show("Por favor ingresa una cédula válida (solo números)")
                Exit Sub
            End If

            Dim contraseña As String = BoxContra.Text

            Dim consulta As String = "SELECT COUNT(*) FROM admin WHERE cedula = @cedula AND password = @password"
            Dim comando As New SqlCommand(consulta, conexion)

            comando.Parameters.AddWithValue("@cedula", cedula)
            comando.Parameters.AddWithValue("@password", contraseña)

            Dim resultado As Integer = Convert.ToInt32(comando.ExecuteScalar())

            If resultado > 0 Then
                MessageBox.Show("Inicio de sesión exitoso")
                Form2.Show()
                Me.Hide()
            Else
                MessageBox.Show("Cédula o contraseña incorrectos")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message)
        Finally
            conexion.Close()
        End Try

        BoxCedula.Text = ""
        BoxContra.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class



