Imports System.Data.SqlClient

Public Class Form2
    Dim conexion As SqlConnection
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

                'estilos
                labelID.Font = New Font(labelID.Font.FontFamily, 9)
                labelMarca.Font = New Font(labelMarca.Font.FontFamily, 9)
                labelCl.Font = New Font(labelCl.Font.FontFamily, 9)
                labelSr.Font = New Font(labelSr.Font.FontFamily, 9, FontStyle.Bold)

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

    Private Sub buttonAgg_Click(sender As Object, e As EventArgs) Handles buttonAgg.Click
        PlMas.Visible = True
        PlPro.Visible = False
    End Sub

    Private Sub buttonArticulos_Click(sender As Object, e As EventArgs) Handles buttonArticulos.Click
        PlMas.Visible = False
        PlPro.Visible = True
    End Sub

    'recargar
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        borrar.Visible = False
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

                'estilos
                labelID.Font = New Font(labelID.Font.FontFamily, 9, FontStyle.Bold)
                labelMarca.Font = New Font(labelMarca.Font.FontFamily, 9, FontStyle.Bold)
                labelCl.Font = New Font(labelCl.Font.FontFamily, 9, FontStyle.Bold)
                labelSr.Font = New Font(labelSr.Font.FontFamily, 9, FontStyle.Bold)

                labelID.Location = New Point(25, yPos)
                labelID.AutoSize = True

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

    'buscar
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        borrar.Visible = True
        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()
            Dim cod As String = TextBox4.Text
            Dim cadena As String = "SELECT id, marca, color, serial FROM articulo where id=" & cod
            Dim comando As SqlCommand
            comando = New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            'If cadena = True Then
            ' Limpiar el panel primero
            lista.Controls.Clear()

            Dim yPos As Integer = 10
            While reader.Read()
                Dim labelID As New Label()
                Dim labelMarca As New Label()
                Dim labelCl As New Label()
                Dim labelSr As New Label()

                'estilos
                labelID.Font = New Font(labelID.Font.FontFamily, 9, FontStyle.Bold)
                labelMarca.Font = New Font(labelMarca.Font.FontFamily, 9, FontStyle.Bold)
                labelCl.Font = New Font(labelCl.Font.FontFamily, 9, FontStyle.Bold)
                labelSr.Font = New Font(labelSr.Font.FontFamily, 9, FontStyle.Bold)

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

                lista.Controls.Add(labelID)
                lista.Controls.Add(labelMarca)
                lista.Controls.Add(labelCl)
                lista.Controls.Add(labelSr)

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