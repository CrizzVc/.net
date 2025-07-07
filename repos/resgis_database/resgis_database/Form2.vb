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
            Dim cadena As String = "SELECT id, marca, color, serial, descP, nameP, lastnameP FROM articulo WHERE id = @codInt OR marca LIKE @codStr"
            Dim comando As New SqlCommand(cadena, conexion)
            Dim codInt As Integer
            If Integer.TryParse(cod, codInt) Then
                comando.Parameters.AddWithValue("@codInt", codInt)
            Else
                comando.Parameters.AddWithValue("@codInt", -1)
            End If
            comando.Parameters.AddWithValue("@codStr", cod & "%")
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
                    Dim datos As Object() = resultados(0)
                    Dim yPos As Integer = 10

                    ' Paleta de colores
                    Dim colorBlue As Color = Color.FromArgb(17, 83, 237)
                    Dim colorLight As Color = Color.FromArgb(242, 244, 247)
                    Dim colorWhite As Color = Color.White
                    Dim colorGray As Color = Color.FromArgb(118, 122, 140)
                    Dim colorGrayLight As Color = Color.FromArgb(219, 225, 232)

                    ' Panel principal (card)
                    Dim card As New Panel()
                    card.Size = New Size(550, 180)
                    card.Location = New Point(10, yPos)
                    card.BackColor = colorWhite
                    card.BorderStyle = BorderStyle.None

                    ' Panel izquierdo (perfil)
                    Dim panelLeft As New Panel()
                    panelLeft.Size = New Size(180, 178)
                    panelLeft.Location = New Point(0, 0)
                    panelLeft.BackColor = colorLight

                    ' Foto (puedes usar un recurso o imagen por defecto)
                    Dim pic As New PictureBox()
                    pic.Size = New Size(64, 64)
                    pic.Location = New Point(58, 15)
                    pic.SizeMode = PictureBoxSizeMode.StretchImage
                    pic.Image = My.Resources.imgD ' Cambia por tu recurso

                    ' Nombre (marca)
                    Dim lblNombre As New Label()
                    lblNombre.Text = $"{datos(1)}"
                    lblNombre.Font = New Font("Segoe UI", 11, FontStyle.Bold)
                    lblNombre.ForeColor = colorBlue
                    lblNombre.Location = New Point(20, 85)
                    lblNombre.AutoSize = True

                    ' Serial (como email)
                    Dim lblSerial As New Label()
                    lblSerial.Text = $"{datos(3)}"
                    lblSerial.Font = New Font("Segoe UI", 9)
                    lblSerial.ForeColor = colorGray
                    lblSerial.Location = New Point(20, 110)
                    lblSerial.AutoSize = True

                    ' ID y Color (como stats)
                    Dim lblID As New Label()
                    lblID.Text = $"ID: {datos(0)}"
                    lblID.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    lblID.ForeColor = colorGray
                    lblID.Location = New Point(20, 135)
                    lblID.AutoSize = True

                    ' Panel derecho (datos)
                    Dim panelRight As New Panel()
                    panelRight.Size = New Size(418, 178)
                    panelRight.Location = New Point(180, 0)
                    panelRight.BackColor = colorWhite

                    ' Dueño
                    Dim lblDueño As New Label()
                    lblDueño.Text = "Dueño:"
                    lblDueño.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    lblDueño.ForeColor = colorGray
                    lblDueño.Location = New Point(20, 30)
                    lblDueño.AutoSize = True

                    Dim lblDueñoValor As New Label()
                    lblDueñoValor.Text = $"{datos(4)} {datos(5)}"
                    lblDueñoValor.Font = New Font("Segoe UI", 9)
                    lblDueñoValor.ForeColor = colorBlue
                    lblDueñoValor.Location = New Point(100, 30)
                    lblDueñoValor.AutoSize = True

                    ' Color debajo del dueño
                    Dim lblColorR As New Label()
                    lblColorR.Text = "Color:"
                    lblColorR.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    lblColorR.ForeColor = colorGray
                    lblColorR.Location = New Point(20, 50)
                    lblColorR.AutoSize = True

                    Dim lblColorValor As New Label()
                    lblColorValor.Text = $"{datos(2)}"
                    lblColorValor.Font = New Font("Segoe UI", 9)
                    lblColorValor.ForeColor = colorGray
                    lblColorValor.Location = New Point(100, 50)
                    lblColorValor.AutoSize = True

                    ' Descripción
                    Dim lblDesc As New Label()
                    lblDesc.Text = "Descripción:"
                    lblDesc.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    lblDesc.ForeColor = colorGray
                    lblDesc.Location = New Point(20, 70)
                    lblDesc.AutoSize = True

                    Dim lblDescValor As New Label()
                    lblDescValor.Text = $"{datos(6)}"
                    lblDescValor.Font = New Font("Segoe UI", 9)
                    lblDescValor.ForeColor = colorGray
                    lblDescValor.Location = New Point(100, 70)
                    lblDescValor.AutoSize = True

                    ' Agregar controles a paneles
                    panelLeft.Controls.Add(pic)
                    panelLeft.Controls.Add(lblNombre)
                    panelLeft.Controls.Add(lblSerial)
                    panelLeft.Controls.Add(lblID)

                    panelRight.Controls.Add(lblDueño)
                    panelRight.Controls.Add(lblDueñoValor)
                    panelRight.Controls.Add(lblColorR)
                    panelRight.Controls.Add(lblColorValor)
                    panelRight.Controls.Add(lblDesc)
                    panelRight.Controls.Add(lblDescValor)

                    card.Controls.Add(panelLeft)
                    card.Controls.Add(panelRight)

                    lista.Controls.Add(card)

                    yPos += 190
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