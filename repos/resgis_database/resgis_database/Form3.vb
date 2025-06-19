Imports System.Data.SqlClient

Public Class Form3
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(235, 247, 227)
        aside.BackColor = Color.FromArgb(102, 176, 50)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles savePro.Click
        Dim conexion As SqlConnection
        conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS ; database=base1 ; integrated security = true")
        conexion.Open()
        Dim descri As String = NamePro.Text
        Dim precio As String = preciPro.Text
        Dim cadena As String = "insert into productos(nombre,precio) values ('" & descri & "'," & precio & ")"
        Dim comando As SqlCommand
        comando = New SqlCommand(cadena, conexion)
        comando.ExecuteNonQuery()
        MessageBox.Show("Los datos se guardaron correctamente")
        NamePro.Text = ""
        preciPro.Text = ""

        conexion.Close()
    End Sub
End Class