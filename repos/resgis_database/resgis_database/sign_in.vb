Imports System.Data.SqlClient
Imports System.Reflection.Emit

Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class sign_in
    ' Variables para la conexión a la base de datos
    Dim dataBase As String = "base1"
    Dim serverName As String = "DESKTOP-J71LFTK\SQLEXPRESS"

    ' oculta el form actual y muestra el home
    Private Sub Button5_Click(sender As Object, e As EventArgs)
        home.Show()
        Me.Hide()
    End Sub

    ' Muestra el sign up para registrar un nuevo usuario
    Private Sub ButtonRegistar_Click(sender As Object, e As EventArgs) Handles ButtonRegistrar.Click
        sign_up.Show()
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

            ' verifica si la cedula y la contraseña son válidas
            Dim contraseña As String = BoxContra.Text

            Dim consulta As String = "SELECT COUNT(*) FROM admin WHERE cedula = @cedula AND password = @password"
            Dim comando As New SqlCommand(consulta, conexion)

            comando.Parameters.AddWithValue("@cedula", cedula)
            comando.Parameters.AddWithValue("@password", contraseña)

            Dim resultado As Integer = Convert.ToInt32(comando.ExecuteScalar())

            ' compara el resultado de la consulta y muestra un mensaje según el resultado
            If resultado > 0 Then
                MessageBox.Show("Inicio de sesión exitoso")
                home.Show()
                Me.Hide()
            Else
                MessageBox.Show("Cédula o contraseña incorrectos")
            End If

        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message)
        Finally
            conexion.Close()
        End Try
        ' Limpia los campos de entrada después de iniciar sesión
        BoxCedula.Text = ""
        BoxContra.Text = ""
    End Sub

End Class



