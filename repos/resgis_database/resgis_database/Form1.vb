Imports System.Data.SqlClient
Imports System.Reflection.Emit

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conexion As SqlConnection
        conexion = New SqlConnection("server=YOJADER\SQLEXPRESS ; database=base1 ; integrated security = true")
        conexion.Open()
        Dim descri As String = TextBox1.Text
        Dim precio As String = TextBox2.Text
        Dim cadena As String = "insert into productos(nombre,precio) values ('" & descri & "'," & precio & ")"
        Dim comando As SqlCommand
        comando = New SqlCommand(cadena, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos se guardaron correctamente")
        TextBox1.Text = ""
        TextBox2.Text = ""

        conexion.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion As SqlConnection
        TextBox3.Text = ""
        conexion = New SqlConnection("server=YOJADER\SQLEXPRESS ; database=base1 ; integrated security = true")
        conexion.Open()
        Dim cadena As String = "select id, nombre, precio from productos"
        Dim comando As SqlCommand
        comando = New SqlCommand(cadena, conexion)
        Dim registros As SqlDataReader
        registros = comando.ExecuteReader()
        Do While registros.Read() = True
            TextBox3.AppendText(registros("id"))
            TextBox3.AppendText(" - ")
            TextBox3.AppendText(registros("nombre"))
            TextBox3.AppendText(" - ")
            TextBox3.AppendText("$")
            TextBox3.AppendText(registros("precio"))
            TextBox3.AppendText(vbCrLf)
        Loop
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conexion As SqlConnection
        conexion = New SqlConnection("server=YOJADER\SQLEXPRESS ; database=base1 ; integrated security = true")
        conexion.Open()
        Dim cadena As String = "select id, nombre, precio from productos"
        Dim comando As SqlCommand
        comando = New SqlCommand(cadena, conexion)
        Dim registros As SqlDataReader
        registros = comando.ExecuteReader()
        Do While registros.Read() = True
            TextBox3.AppendText(registros("id"))
            TextBox3.AppendText(" - ")
            TextBox3.AppendText(registros("nombre"))
            TextBox3.AppendText(" - ")
            TextBox3.AppendText("$")
            TextBox3.AppendText(registros("precio"))
            TextBox3.AppendText(vbCrLf)
        Loop
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conexion As SqlConnection
        conexion = New SqlConnection("server=YOJADER\SQLEXPRESS ; database=base1 ; integrated security = true")
        conexion.Open()
        Dim cod As String = TextBox4.Text
        Dim cadena As String = "select nombre, precio from productos where id=" & cod
        Dim comando As SqlCommand
        comando = New SqlCommand(cadena, conexion)
        Dim registro As SqlDataReader
        registro = comando.ExecuteReader()
        Label5.Text = ""
        Label6.Text = ""
        If registro.Read() = True Then
            Label5.Text = registro("nombre")
            Label6.Text = registro("precio")
        Else
            MessageBox.Show("No existe un artículo con el código ingresado")
        End If
        conexion.Close()
    End Sub

End Class
