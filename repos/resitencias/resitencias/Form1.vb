Public Class Form1
    Dim c1 As String
    Dim c2 As String
    Dim c3 As String
    Dim c4 As String
    Dim c5 As String
    Dim c6 As String

    Dim colors As Array = {"negro", "marron", "rojo", "naranja", "Amarillo", "verde", "azul", "violeta", "gris", "blanco", "oro", "plata"}
    Dim multi As Array = {"x1", "x10", "x100", "x1 k", "x10 k", "x100 k", "x1 m", " x10 m", "x100 M", "x1 g", "x0.1", "x0.1"}
    Dim colors4 As Array = {"marron", "rojo", "verde", "azul", "violeta", "gris", "oro", "plata"}
    Dim tole As Array = {"+- 1%", "+- 2%", "+- 0.5%", "+- 0.25%", "+- 0.1%", "+- 0.05%", "+- 5%", "+- 10%"}
    Dim colors6 As Array = {"marron", "rojo", "naranja", "Amarillo", "azul", "violeta"}
    Dim ppm As Array = {"marron", "rojo", "naranja", "Amarillo", "azul", "violeta"}
    Dim ppmv As Array = {"100ppm", "50ppm", "15ppm", "25ppm", "10 ppm", "5 ppm"}

    'Function colores(a)
    '    Dim texto As String = a.selectindex
    '    c1 = texto.Substring(0, 3)
    '    c2 = texto.Substring(3, 3)
    '    c3 = texto.Substring(6, 3)
    '    a.BackColor = Color.FromArgb(c1, c2, c3)
    'End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cb5.Visible = False
        cb6.Visible = False
        ln2.Visible = False
        ln5.Visible = False
        dt2.Visible = False
        dt5.Visible = False
        resp.Text = cb4.SelectedIndex


        Dim colors As Array = {"negro", "marron", "rojo", "naranja", "Amarillo", "verde", "azul", "violeta", "gris", "blanco", "oro", "plata"}
        Dim multi As Array = {"x1", "x10", "x100", "x1 k", "x10 k", "x100 k", "x1 m", " x10 m", "x100 M", "x1 g", "x0.1", "x0.1"}
        Dim colors4 As Array = {"marron", "rojo", "verde", "azul", "violeta", "gris", "oro", "plata"}
        Dim tole As Array = {"+- 1%", "+- 2%", "+- 0.5%", "+- 0.25%", "+- 0.1%", "+- 0.05%", "+- 5%", "+- 10%"}
        For c = 0 To 9
            cb1.Items.Add(colors(c) & c)
            cb2.Items.Add(colors(c) & c)
        Next
        For c = 0 To 11
            cb3.Items.Add(colors(c) & multi(c))
            cb4.Items.Add(colors4(c) & tole(c))
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cb5.Visible = True
        cb6.Visible = False
        dt2.Visible = True
        ln2.Visible = True
        ln5.Visible = False
        dt5.Visible = False

        Dim colors As Array = {"negro", "marron", "rojo", "naranja", "Amarillo", "verde", "azul", "violeta", "gris", "blanco", "oro", "plata"}
        Dim multi As Array = {"x1", "x10", "x100", "x1 k", "x10 k", "x100 k", "x1 m", " x10 m", "x100 M", "x1 g", "x0.1", "x0.1"}
        Dim colors4 As Array = {"marron", "rojo", "verde", "azul", "violeta", "gris", "oro", "plata"}
        Dim tole As Array = {"+- 1%", "+- 2%", "+- 0.5%", "+- 0.25%", "+- 0.1%", "+- 0.05%", "+- 5%", "+- 10%"}
        For c = 0 To 9
            cb1.Items.Add(colors(c) & c)
            cb2.Items.Add(colors(c) & c)
            cb3.Items.Add(colors(c) & c)
        Next
        For c = 0 To 11

            cb4.Items.Add(colors(c) & multi(c))
            cb5.Items.Add(colors4(c) & tole(c))
        Next
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        cb6.Visible = True
        cb5.Visible = True
        dt2.Visible = True
        ln5.Visible = True
        ln2.Visible = True
        dt5.Visible = True

        Dim colors As Array = {"negro", "marron", "rojo", "naranja", "Amarillo", "verde", "azul", "violeta", "gris", "blanco", "oro", "plata"}
        Dim multi As Array = {"x1", "x10", "x100", "x1 k", "x10 k", "x100 k", "x1 m", " x10 m", "x100 M", "x1 g", "x0.1", "x0.1"}
        Dim colors4 As Array = {"marron", "rojo", "verde", "azul", "violeta", "gris", "oro", "plata"}
        Dim tole As Array = {"+- 1%", "+- 2%", "+- 0.5%", "+- 0.25%", "+- 0.1%", "+- 0.05%", "+- 5%", "+- 10%"}
        Dim colors6 As Array = {"marron", "rojo", "naranja", "Amarillo", "azul", "violeta"}
        Dim ppm As Array = {"marron", "rojo", "naranja", "Amarillo", "azul", "violeta"}
        Dim ppmv As Array = {"100ppm", "50ppm", "15ppm", "25ppm", "10 ppm", "5 ppm"}
        For c = 0 To 9
            cb1.Items.Add(colors(c) & c)
            cb2.Items.Add(colors(c) & c)
            cb3.Items.Add(colors(c) & c)
        Next
        For c = 0 To 11
            cb4.Items.Add(colors(c) & multi(c))
            cb5.Items.Add(colors4(c) & tole(c))
            cb6.Items.Add(ppm(c) & ppmv(c))
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'colores(cb1)
        'colores(cb2)
        'colores(cb3)
        'colores(cb4)
        'colores(cb5)
        'colores(cb6)

        Dim colors As Array = {"negro", "marron", "rojo", "naranja", "Amarillo", "verde", "azul", "violeta", "gris", "blanco", "oro", "plata"}
        Dim multi As Array = {"x1", "x10", "x100", "x1 k", "x10 k", "x100 k", "x1 m", " x10 m", "x100 M", "x1 g", "x0.1", "x0.1"}
        Dim colors4 As Array = {"marron", "rojo", "verde", "azul", "violeta", "gris", "oro", "plata"}
        Dim tole As Array = {"+- 1%", "+- 2%", "+- 0.5%", "+- 0.25%", "+- 0.1%", "+- 0.05%", "+- 5%", "+- 10%"}
        For c = 0 To 9
            cb1.Items.Add(colors(c) & c)
            cb2.Items.Add(colors(c) & c)
        Next
        For c = 0 To 11
            cb3.Items.Add(colors(c) & multi(c))
            cb4.Items.Add(colors4(c) & tole(c))
        Next
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        If cb1.SelectedIndex = -1 Then

        End If
    End Sub
End Class
