﻿Imports System.Data.SqlClient
Imports System.Reflection.Emit

Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Me.Hide()
    End Sub


    Private Sub ButtonRegistar_Click(sender As Object, e As EventArgs) Handles ButtonRegistrar.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub ButtonIniciar_Click(sender As Object, e As EventArgs) Handles ButtonIniciar.Click
        Dim conexion As New SqlConnection("server=DESKTOP-43NQ5GU\SQLEXPRESS; database=DBPrueba; integrated security=true")

        Try
            conexion.Open()

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



