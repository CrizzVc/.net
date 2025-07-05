Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Form2
    Dim conexion As SqlConnection

    'funsion recargar <---------------
    Public Sub CargarArticulos(lista As Control)
        borrar.Visible = False
        Dim conexion As SqlConnection = Nothing

        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()

            Dim cadena As String = "SELECT id, marca, color, serial FROM articulo"
            Dim comando As New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            ' Limpiar el panel primero
            lista.Controls.Clear()

            Dim yPos As Integer = 10
            While reader.Read()
                Dim labelID As New Label()
                Dim labelMarca As New Label()
                Dim labelCl As New Label()
                Dim labelSr As New Label()

                ' Estilos
                labelID.Font = New Font(labelID.Font.FontFamily, 9)
                labelMarca.Font = New Font(labelMarca.Font.FontFamily, 9)
                labelCl.Font = New Font(labelCl.Font.FontFamily, 9)
                labelSr.Font = New Font(labelSr.Font.FontFamily, 9)

                ' Posiciones y textos
                labelID.Text = $"{reader("id")}"
                labelID.Location = New Point(25, yPos)
                labelID.AutoSize = True

                labelMarca.Text = $"{reader("marca")}"
                labelMarca.Location = New Point(90, yPos)
                labelMarca.AutoSize = True

                labelCl.Text = $"{reader("color")}"
                labelCl.Location = New Point(160, yPos)
                labelCl.AutoSize = True

                labelSr.Text = $"{reader("serial")}"
                labelSr.Location = New Point(240, yPos)
                labelSr.AutoSize = True

                ' Agregar al contenedor
                lista.Controls.Add(labelID)
                lista.Controls.Add(labelMarca)
                lista.Controls.Add(labelCl)
                lista.Controls.Add(labelSr)

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

    'LOAD <-------------------------------------
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()

            Dim cadena As String = "SELECT nombreU FROM admin WHERE id = 1"
            Dim comando As New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            If reader.Read() Then
                Dim nameU As String = reader("nombreU").ToString()
                Me.Text = nameU
            End If

            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conexion IsNot Nothing AndAlso conexion.State = ConnectionState.Open Then
                conexion.Close()
            End If
        End Try

        CargarArticulos(lista)
    End Sub

    Private Sub buttonAgg_Click(sender As Object, e As EventArgs) Handles buttonAgg.Click
        PlMas.Visible = True
        PlPro.Visible = False

        Me.Text = "agregar"
    End Sub

    Private Sub buttonArticulos_Click(sender As Object, e As EventArgs) Handles buttonArticulos.Click
        PlMas.Visible = False
        PlPro.Visible = True

        Me.Text = "articulos"
    End Sub

    'buscar <--------------------------
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            CargarArticulos(lista)
            Exit Sub
        Else
            borrar.Visible = True
        End If

        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()
            Dim cod As String = TextBox4.Text
            Dim cadena As String = "SELECT id, marca, color, serial, descP, nameP, lastnameP FROM articulo where id=" & cod
            Dim comando As New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            ' Limpiar el panel primero
            lista.Controls.Clear()

            ' Verificar si hay resultados
            If reader.HasRows Then
                Dim yPos As Integer = 10
                While reader.Read()
                    Dim labelID As New Label()
                    Dim labelMarca As New Label()
                    Dim labelCl As New Label()
                    Dim labelSr As New Label()
                    Dim labelNP As New Label()
                    Dim labelLP As New Label()
                    Dim labelDs As New Label()

                    ' Estilos
                    labelID.Font = New Font(labelID.Font.FontFamily, 9)
                    labelMarca.Font = New Font(labelMarca.Font.FontFamily, 9)
                    labelCl.Font = New Font(labelCl.Font.FontFamily, 9)
                    labelSr.Font = New Font(labelSr.Font.FontFamily, 9)
                    labelDs.Font = New Font(labelDs.Font.FontFamily, 9)
                    labelNP.Font = New Font(labelNP.Font.FontFamily, 9)
                    labelLP.Font = New Font(labelLP.Font.FontFamily, 9)

                    labelID.Text = $"{reader("id")}"
                    labelID.Location = New Point(25, yPos)
                    labelID.AutoSize = True

                    labelMarca.Text = $"{reader("marca")}"
                    labelMarca.Location = New Point(90, yPos)
                    labelMarca.AutoSize = True

                    labelCl.Text = $"{reader("color")}"
                    labelCl.Location = New Point(160, yPos)
                    labelCl.AutoSize = True

                    labelSr.Text = $"{reader("serial")}"
                    labelSr.Location = New Point(240, yPos)
                    labelSr.AutoSize = True

                    labelNP.Text = $"Dueño:{reader("nameP")}"
                    labelNP.Location = New Point(25, yPos + 25)
                    labelNP.AutoSize = True

                    labelLP.Text = $"{reader("lastnameP")}"
                    labelLP.Location = New Point(90, yPos + 25)
                    labelLP.AutoSize = True

                    labelDs.Text = $"Descripcion: {reader("descP")}"
                    labelDs.Location = New Point(160, yPos + 25)
                    labelDs.AutoSize = True

                    lista.Controls.Add(labelID)
                    lista.Controls.Add(labelMarca)
                    lista.Controls.Add(labelCl)
                    lista.Controls.Add(labelSr)
                    lista.Controls.Add(labelNP)
                    lista.Controls.Add(labelLP)
                    lista.Controls.Add(labelDs)

                    yPos += 50
                End While

            Else
                borrar.Visible = False
                ' Mostrar mensaje centrado si no se encuentra el artículo
                Dim labelNotFound As New Label()
                labelNotFound.Text = "Artículo no encontrado"
                labelNotFound.Font = New Font("Arial", 12, FontStyle.Bold)
                labelNotFound.AutoSize = True
                labelNotFound.ForeColor = Color.Red

                ' Centrar en el contenedor lista
                labelNotFound.Location = New Point((lista.Width - labelNotFound.Width) \ 2, lista.Height \ 2)
                lista.Controls.Add(labelNotFound)
            End If

            reader.Close()
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
        Dim cadena As String = "delete from articulo where id=" & cod
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


    Private Sub savePro_Click(sender As Object, e As EventArgs) Handles savePro.Click
        Try
            Using conexion As New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
                conexion.Open()

                ' Recolectar datos
                Dim color As String = BoxColor.Text
                Dim nameP As String = BoxNombre.Text
                Dim lastnameP As String = BoxApellido.Text
                Dim marca As String = BoxMarca.Text
                Dim serial As String = BoxSerial.Text
                Dim descri As String = boxdesc.Text
                Dim descripcionFinal As String = If(String.IsNullOrWhiteSpace(descri), "Sin descripción", descri)

                ' Consulta con parámetros
                Dim cadena As String = "INSERT INTO articulo (marca, color, serial, descP, nameP, lastnameP) VALUES (@marca, @color, @serial, @descP, @nameP, @lastnameP)"
                Using comando As New SqlCommand(cadena, conexion)
                    comando.Parameters.AddWithValue("@marca", marca)
                    comando.Parameters.AddWithValue("@color", color)
                    comando.Parameters.AddWithValue("@serial", serial)
                    comando.Parameters.AddWithValue("@descP", descripcionFinal)
                    comando.Parameters.AddWithValue("@nameP", nameP)
                    comando.Parameters.AddWithValue("@lastnameP", lastnameP)

                    comando.ExecuteNonQuery()
                End Using

                MessageBox.Show("Los datos se guardaron correctamente")

                ' Limpiar campos
                BoxColor.Text = ""
                BoxNombre.Text = ""
                BoxApellido.Text = ""
                boxdesc.Text = ""
                BoxMarca.Text = ""
                BoxSerial.Text = ""
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al guardar los datos: " & ex.Message)
        End Try
    End Sub


    Private Sub ButtonCerrar_Click(sender As Object, e As EventArgs) Handles ButtonCerrar.Click
        Form1.Show()
        Me.Hide()
    End Sub


End Class