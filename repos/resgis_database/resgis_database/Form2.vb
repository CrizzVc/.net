Imports System.Data.SqlClient

Public Class Form2
    Dim conexion As SqlConnection
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(235, 247, 227)
        aside.BackColor = Color.FromArgb(102, 176, 50)

        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()

            Dim cadena As String = "SELECT id, nombre, precio FROM productos"
            Dim comando As New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            ' Limpiar el panel primero
            lista.Controls.Clear()

            Dim yPos As Integer = 10
            While reader.Read()
                Dim labelID As New Label()
                Dim labelNAME As New Label()
                Dim labelPR As New Label()

                labelID.Text = $"{reader("id")}"
                labelID.Location = New Point(20, yPos)
                labelID.AutoSize = True

                labelNAME.Text = $"{reader("nombre")}"
                labelNAME.Location = New Point(80, yPos)
                labelNAME.AutoSize = True

                labelPR.Text = $"{reader("precio")}"
                labelPR.Location = New Point(180, yPos)
                labelPR.AutoSize = True

                lista.Controls.Add(labelID)
                lista.Controls.Add(labelNAME)
                lista.Controls.Add(labelPR)
                yPos += 25
            End While

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try
    End Sub

    Private Sub masPro_Click(sender As Object, e As EventArgs) Handles masPro.Click
        PlMas.Visible = True
        PlPro.Visible = False
    End Sub

    Private Sub product_Click(sender As Object, e As EventArgs) Handles product.Click
        PlMas.Visible = False
        PlPro.Visible = True
    End Sub

    'recargar
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        borrar.Visible = False
        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()

            Dim cadena As String = "SELECT id, nombre, precio FROM productos"
            Dim comando As New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            ' Limpiar el panel primero
            lista.Controls.Clear()

            Dim yPos As Integer = 10
            While reader.Read()
                Dim labelID As New Label()
                Dim labelNAME As New Label()
                Dim labelPR As New Label()

                labelID.Text = $"{reader("id")}"
                labelID.Location = New Point(20, yPos)
                labelID.AutoSize = True

                labelNAME.Text = $"{reader("nombre")}"
                labelNAME.Location = New Point(80, yPos)
                labelNAME.AutoSize = True

                labelPR.Text = $"{reader("precio")}"
                labelPR.Location = New Point(180, yPos)
                labelPR.AutoSize = True

                lista.Controls.Add(labelID)
                lista.Controls.Add(labelNAME)
                lista.Controls.Add(labelPR)
                yPos += 25
            End While

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try
    End Sub

    'buscar
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        borrar.Visible = True
        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()
            Dim cod As String = TextBox4.Text
            Dim cadena As String = "select id, nombre, precio from productos where id=" & cod
            Dim comando As SqlCommand
            comando = New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            'If cadena = True Then
            ' Limpiar el panel primero
            lista.Controls.Clear()

            Dim yPos As Integer = 10
            While reader.Read()
                Dim labelID As New Label()
                Dim labelNAME As New Label()
                Dim labelPR As New Label()

                labelID.Text = $"{reader("id")}"
                labelID.Location = New Point(20, yPos)
                labelID.AutoSize = True

                labelNAME.Text = $"{reader("nombre")}"
                labelNAME.Location = New Point(80, yPos)
                labelNAME.AutoSize = True

                labelPR.Text = $"{reader("precio")}"
                labelPR.Location = New Point(180, yPos)
                labelPR.AutoSize = True

                lista.Controls.Add(labelID)
                lista.Controls.Add(labelNAME)
                lista.Controls.Add(labelPR)
                yPos += 25
            End While

            reader.Close()
            'Else
            '    MsgBox("producto no encontrado")
            'End If



        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try
    End Sub

    Private Sub borrar_Click(sender As Object, e As EventArgs) Handles borrar.Click
        conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
        conexion.Open()
        Dim cod As String = TextBox4.Text
        Dim cadena As String = "delete from productos where id=" & cod
        Dim comando As SqlCommand
        comando = New SqlCommand(cadena, conexion)

        Dim cant As Integer
        cant = comando.ExecuteNonQuery()

        If cant = 1 Then
            MessageBox.Show("Se borró el artículo")
        Else
            MessageBox.Show("No existe un artículo con el código ingresado")
        End If
        conexion.Close()
    End Sub

    'agregar
    Private Sub savePro_Click(sender As Object, e As EventArgs) Handles savePro.Click, borrar.Click
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