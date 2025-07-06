Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Form2
    Dim conexion As SqlConnection

    'Funcion buscar <---------------------
    Public Sub BuscarArticulo(lista As Control)

        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()
            Dim cod As String = TextBox4.Text
            Dim cadena As String = "SELECT id, marca, color, serial, descP, nameP, lastnameP FROM articulo WHERE id = @codInt OR marca = @codStr"
            Dim comando As New SqlCommand(cadena, conexion)
            Dim codInt As Integer
            If Integer.TryParse(cod, codInt) Then
                comando.Parameters.AddWithValue("@codInt", codInt)
            Else
                comando.Parameters.AddWithValue("@codInt", -1)
            End If
            comando.Parameters.AddWithValue("@codStr", cod)
            Dim reader As SqlDataReader = comando.ExecuteReader()

            ' Limpiar panel
            lista.Controls.Clear()

            ' Verificar si hay resultados
            If reader.HasRows Then
                ' Contar cuántos artículos hay
                Dim count As Integer = 0
                Dim resultados As New List(Of Object())

                While reader.Read()
                    count += 1
                    ' Guardar los datos para mostrarlos después si es necesario
                    resultados.Add(New Object() {
                        reader("id"),
                        reader("marca"),
                        reader("color"),
                        reader("serial"),
                        reader("nameP"),
                        reader("lastnameP"),
                        reader("descP")
                    })
                End While

                LabelDtaN.Text = count.ToString()
                reader.Close()

                If count > 1 Then

                    Dim yPos As Integer = 10
                    For Each datos In resultados
                        Dim idPr As Integer
                        idPr = $"{datos(0)}"

                        ' Panel contenedor tipo "card"
                        Dim card As New Panel()
                        card.Size = New Size(500, 100)
                        card.Location = New Point(10, yPos)
                        card.BackColor = Color.White
                        card.BorderStyle = BorderStyle.FixedSingle
                        card.Padding = New Padding(10)
                        card.Margin = New Padding(0, 0, 0, 10)

                        ' Icono (puedes personalizarlo o usar un PictureBox con una imagen)
                        Dim icon As New PictureBox()
                        icon.Size = New Size(48, 48)
                        icon.Location = New Point(10, 16)
                        icon.SizeMode = PictureBoxSizeMode.StretchImage
                        icon.Image = My.Resources.imgD ' Asegúrate de tener un recurso de imagen

                        ' Título (marca)
                        Dim labelTitle As New Label()
                        labelTitle.Text = $"{datos(1)}"
                        labelTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                        labelTitle.Location = New Point(70, 10)
                        labelTitle.AutoSize = True

                        ' Subtítulo (color y serial)
                        Dim labelSub As New Label()
                        labelSub.Text = $"Color: {datos(2)}   Serial: {datos(3)}"
                        labelSub.Font = New Font("Segoe UI", 9)
                        labelSub.ForeColor = Color.Gray
                        labelSub.Location = New Point(70, 35)
                        labelSub.AutoSize = True

                        ' ID a la derecha
                        Dim labelID As New Label()
                        labelID.Text = $"ID: {datos(0)}"
                        labelID.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                        labelID.ForeColor = Color.FromArgb(120, 120, 120)
                        labelID.Location = New Point(400, 10)
                        labelID.AutoSize = True

                        ' Botón debajo del ID
                        Dim btnVerPro As New Button()
                        btnVerPro.Text = "Ver"
                        btnVerPro.Name = "VerP"
                        btnVerPro.Size = New Size(60, 25)
                        btnVerPro.Location = New Point(400, 40)
                        btnVerPro.Tag = idPr
                        btnVerPro.BackColor = Color.FromArgb(17, 83, 237)
                        btnVerPro.ForeColor = Color.White
                        btnVerPro.FlatStyle = FlatStyle.Flat
                        AddHandler btnVerPro.Click, Sub(senderBtn, eBtn)
                                                        VerPro(idPr)
                                                    End Sub

                        ' Agregar controles al panel
                        card.Controls.Add(icon)
                        card.Controls.Add(labelTitle)
                        card.Controls.Add(labelSub)
                        card.Controls.Add(labelID)
                        card.Controls.Add(btnVerPro)

                        ' Agregar el panel al contenedor principal
                        lista.Controls.Add(card)

                        yPos += 110 ' Ajusta según el alto de tu panel/card
                    Next
                ElseIf count = 1 Then
                    borrar.Visible = True

                    ' Mostrar el único artículo encontrado
                    Dim yPos As Integer = 10
                    Dim datos = resultados(0)

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

                    labelID.Text = $"{datos(0)}"
                    labelID.Location = New Point(25, yPos)
                    labelID.AutoSize = True

                    labelMarca.Text = $"{datos(1)}"
                    labelMarca.Location = New Point(90, yPos)
                    labelMarca.AutoSize = True

                    labelCl.Text = $"{datos(2)}"
                    labelCl.Location = New Point(160, yPos)
                    labelCl.AutoSize = True

                    labelSr.Text = $"{datos(3)}"
                    labelSr.Location = New Point(240, yPos)
                    labelSr.AutoSize = True

                    labelNP.Text = $"Dueño:{datos(4)}"
                    labelNP.Location = New Point(25, yPos + 25)
                    labelNP.AutoSize = True

                    labelLP.Text = $"{datos(5)}"
                    labelLP.Location = New Point(90, yPos + 25)
                    labelLP.AutoSize = True

                    labelDs.Text = $"Descripcion: {datos(6)}"
                    labelDs.Location = New Point(160, yPos + 25)
                    labelDs.AutoSize = True

                    lista.Controls.Add(labelID)
                    lista.Controls.Add(labelMarca)
                    lista.Controls.Add(labelCl)
                    lista.Controls.Add(labelSr)
                    lista.Controls.Add(labelNP)
                    lista.Controls.Add(labelLP)
                    lista.Controls.Add(labelDs)
                End If


            Else
                borrar.Visible = False
                ' Mostrar mensaje centrado si no se encuentra el artículo
                Dim labelNotFound As New Label()
                labelNotFound.Text = "Artículo no encontrado"
                labelNotFound.Font = New Font("Arial", 12, FontStyle.Bold)
                labelNotFound.AutoSize = True
                labelNotFound.ForeColor = Color.Blue

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

    'funcion del botón ver <---------------------
    Public Sub VerPro(idPrD As Integer)
        TextBox4.Text = idPrD
        borrar.Visible = True

        BuscarArticulo(lista)
    End Sub

    'función recargar <---------------
    Public Sub CargarArticulos(lista As Control)
        borrar.Visible = False
        Dim conexion As SqlConnection = Nothing


        Try
            conexion = New SqlConnection("server=DESKTOP-J71LFTK\SQLEXPRESS; database=base1; integrated security=true")
            conexion.Open()

            Dim cadena As String = "SELECT id, marca, color, serial FROM articulo"
            Dim comando As New SqlCommand(cadena, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()
            Dim count As Integer = 0

            lista.Controls.Clear()
            Dim yPos As Integer = 10

            While reader.Read()
                count += 1
                Dim idPr As Integer
                idPr = reader("id")

                ' Panel contenedor tipo "card"
                Dim card As New Panel()
                card.Size = New Size(500, 100)
                card.Location = New Point(10, yPos)
                card.BackColor = Color.White
                card.BorderStyle = BorderStyle.FixedSingle
                card.Padding = New Padding(10)
                card.Margin = New Padding(0, 0, 0, 10)

                ' Icono (puedes personalizarlo o usar un PictureBox con una imagen)
                Dim icon As New PictureBox()
                icon.Size = New Size(48, 48)
                icon.Location = New Point(10, 16)
                icon.SizeMode = PictureBoxSizeMode.StretchImage
                icon.Image = My.Resources.imgD ' Asegúrate de tener un recurso de imagen

                ' Título (marca)
                Dim labelTitle As New Label()
                labelTitle.Text = $"{reader("marca")}"
                labelTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                labelTitle.Location = New Point(70, 10)
                labelTitle.AutoSize = True

                ' Subtítulo (color y serial)
                Dim labelSub As New Label()
                labelSub.Text = $"Color: {reader("color")}   Serial: {reader("serial")}"
                labelSub.Font = New Font("Segoe UI", 9)
                labelSub.ForeColor = Color.Gray
                labelSub.Location = New Point(70, 35)
                labelSub.AutoSize = True

                ' ID a la derecha
                Dim labelID As New Label()
                labelID.Text = $"ID: {reader("id")}"
                labelID.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                labelID.ForeColor = Color.FromArgb(120, 120, 120)
                labelID.Location = New Point(400, 10)
                labelID.AutoSize = True

                ' Botón debajo del ID
                Dim btnVerPro As New Button()
                btnVerPro.Text = "Ver"
                btnVerPro.Name = "VerP"
                btnVerPro.Size = New Size(60, 25)
                btnVerPro.Location = New Point(400, 40)
                btnVerPro.Tag = idPr
                btnVerPro.BackColor = Color.FromArgb(17, 83, 237)
                btnVerPro.ForeColor = Color.White
                btnVerPro.FlatStyle = FlatStyle.Flat
                AddHandler btnVerPro.Click, Sub(senderBtn, eBtn)
                                                verPro(idPr)
                                            End Sub

                ' Agregar controles al panel
                card.Controls.Add(icon)
                card.Controls.Add(labelTitle)
                card.Controls.Add(labelSub)
                card.Controls.Add(labelID)
                card.Controls.Add(btnVerPro)

                ' Agregar el panel al contenedor principal
                lista.Controls.Add(card)

                yPos += card.Height + 10
            End While

            LabelDtaN.Text = count.ToString()
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

        CargarArticulos(lista)
        Me.Text = "articulos"
    End Sub

    'buscar <--------------------------
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If String.IsNullOrWhiteSpace(TextBox4.Text) Then
            CargarArticulos(lista)
            Exit Sub
        Else
            BuscarArticulo(lista)
        End If

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