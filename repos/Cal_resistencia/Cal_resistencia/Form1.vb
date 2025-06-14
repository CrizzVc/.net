Imports System.Reflection.Emit

Public Class Form1

    Dim res As Double
    Dim multi As Double
    Dim tole As Double
    Dim v As Integer = 1
    Private Sub CalcularResistencia(v)

        Try

            Dim digito1 As Integer = CInt(D1.Text)
            Dim digito2 As Integer = CInt(D2.Text)
            Dim digito3 As Integer = CInt(D3.Text)
            Dim multiplicador As Double = CDbl(multi)
            Dim tolerancia As Double = CDbl(tole)
            Dim ppm As String = D5.Text

            If v = 1 Then
                Dim valorBase As Integer = digito1 * 10 + digito2
                Dim resistencia As Double = valorBase * multiplicador


                Dim margen As Double = resistencia * (tolerancia / 100)
                Dim minimo As Double = resistencia - margen
                Dim maximo As Double = resistencia + margen


                res1.Text = "Valor: " & resistencia.ToString("N0") & " Ω"
                res2.Text = "Tolerancia: ±" & tolerancia.ToString() & "%"
                res3.Text = "Rango: " & minimo.ToString("N0") & " Ω - " & maximo.ToString("N0") & " Ω"

            ElseIf v = 2 Then
                Dim valorBase As Integer = digito1 * 100 + digito2 * 10 + digito3
                Dim resistencia As Double = valorBase * multiplicador


                Dim margen As Double = resistencia * (tolerancia / 100)
                Dim minimo As Double = resistencia - margen
                Dim maximo As Double = resistencia + margen

                res1.Text = "Valor: " & resistencia.ToString("N0") & " Ω"
                res2.Text = "Tolerancia: ±" & tolerancia.ToString() & "%  |  " & ppm
                res3.Text = "Rango: " & minimo.ToString("N0") & " Ω - " & maximo.ToString("N0") & " Ω"
            End If


        Catch ex As Exception
            MessageBox.Show("Error en el cálculo. Verifica que todos los valores sean numéricos.")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CBX3.Location = New Point(69, 188)
        CBX4.Location = New Point(69, 230)
        CBX5.Visible = False
        CBX6.Visible = False
        CBX5.SelectedIndex = 0
        CBX6.SelectedIndex = 0
        L5.Visible = False
        L3.Text = "Multilicador"
        L4.Text = "Tolerancia"
        L6.Visible = False
        B5.Visible = False
        B6.Visible = False
        D3.Visible = False
        D5.Visible = False
        v = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        CBX5.Location = New Point(69, 188)
        CBX3.Location = New Point(69, 230)
        CBX4.Location = New Point(69, 275)
        CBX5.Visible = True
        CBX6.Visible = False
        CBX6.SelectedIndex = 0
        D3.Visible = True
        D5.Visible = False
        B5.Visible = True
        B6.Visible = False
        L3.Text = "Banda 3"
        L4.Text = "Multilicador"
        L5.Visible = True
        L6.Visible = False
        v = 2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CBX5.Location = New Point(69, 188)
        CBX3.Location = New Point(69, 230)
        CBX4.Location = New Point(69, 275)
        'B4.Location = New Point(630, 135)
        'B6.Location = New Point(679, 125)
        'B6.Location = New Point(679, 125)
        'D5.Location = New Point(679, 236)
        'D6.Location = New Point(620, 236)
        CBX5.Visible = True
        CBX6.Visible = True
        L3.Text = "Banda 3"
        L4.Text = "Multilicador"
        L5.Visible = True
        L6.Visible = True
        B5.Visible = True
        B6.Visible = True
        D3.Visible = True
        D5.Visible = True
        v = 2
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CBX1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX1.SelectedIndexChanged
        Select Case CBX1.SelectedItem.ToString()
            Case 0
                B1.BackColor = Color.FromArgb(250, 250, 250)
                D1.Text = "0"
            Case "Negro0"
                B1.BackColor = Color.FromArgb(2, 2, 2)
                D1.Text = "0"
            Case "Marrón1"
                B1.BackColor = Color.FromArgb(81, 38, 39)
                D1.Text = "1"
            Case "Rojo2"
                B1.BackColor = Color.FromArgb(255, 33, 0)
                D1.Text = "2"
            Case "Naranja3"
                B1.BackColor = Color.FromArgb(216, 115, 71)
                D1.Text = "3"
            Case "Amarillo4"
                B1.BackColor = Color.FromArgb(230, 201, 81)
                D1.Text = "4"
            Case "Verde5"
                B1.BackColor = Color.FromArgb(82, 143, 101)
                D1.Text = "5"
            Case "Azul6"
                B1.BackColor = Color.FromArgb(15, 81, 144)
                D1.Text = "6"
            Case "Violeta7"
                B1.BackColor = Color.FromArgb(105, 103, 206)
                D1.Text = "7"
            Case "Gris8"
                B1.BackColor = Color.FromArgb(125, 125, 125)
                D1.Text = "8"
            Case "Blanco9"
                B1.BackColor = Color.FromArgb(255, 255, 255)
                D1.Text = "9"
        End Select
        CalcularResistencia(v)
    End Sub

    Private Sub CBX2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX2.SelectedIndexChanged
        Select Case CBX2.SelectedItem.ToString()
            Case 0
                B2.BackColor = Color.FromArgb(250, 250, 250)
                D2.Text = "0"
            Case "Negro0"
                B2.BackColor = Color.FromArgb(2, 2, 2)
                D2.Text = "0"
            Case "Marrón1"
                B2.BackColor = Color.FromArgb(81, 38, 39)
                D2.Text = "1"
            Case "Rojo2"
                B2.BackColor = Color.FromArgb(255, 33, 0)
                D2.Text = "2"
            Case "Naranja3"
                B2.BackColor = Color.FromArgb(216, 115, 71)
                D2.Text = "3"
            Case "Amarillo4"
                B2.BackColor = Color.FromArgb(230, 201, 81)
                D2.Text = "4"
            Case "Verde5"
                B2.BackColor = Color.FromArgb(82, 143, 101)
                D2.Text = "5"
            Case "Azul6"
                B2.BackColor = Color.FromArgb(15, 81, 144)
                D2.Text = "6"
            Case "Violeta7"
                B2.BackColor = Color.FromArgb(105, 103, 206)
                D2.Text = "7"
            Case "Gris8"
                B2.BackColor = Color.FromArgb(125, 125, 125)
                D2.Text = "8"
            Case "Blanco9"
                B2.BackColor = Color.FromArgb(255, 255, 255)
                D2.Text = "9"
        End Select
        CalcularResistencia(v)
    End Sub

    Private Sub CBX3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX3.SelectedIndexChanged
        Select Case CBX3.SelectedItem.ToString()
            Case "0"
                B3.BackColor = Color.FromArgb(250, 250, 250)
                D4.Text = "0"
            Case "Negrox1"
                B3.BackColor = Color.FromArgb(2, 2, 2)
                D4.Text = "x1"
                multi = 1
            Case "Marrónx10"
                B3.BackColor = Color.FromArgb(81, 38, 39)
                D4.Text = "x10"
                multi = 10
            Case "Rojox100"
                B3.BackColor = Color.FromArgb(255, 33, 0)
                D4.Text = "x100"
                multi = 100
            Case "Naranjax1 k"
                B3.BackColor = Color.FromArgb(216, 115, 71)
                D4.Text = "x1 k"
                multi = 1000
            Case "Amarillox10 k"
                B3.BackColor = Color.FromArgb(230, 201, 81)
                D4.Text = "x10 k"
                multi = 10000
            Case "Verdex100 k"
                B3.BackColor = Color.FromArgb(82, 143, 101)
                D4.Text = "x100 k"
                multi = 100000
            Case "Azulx1 M"
                B3.BackColor = Color.FromArgb(15, 81, 144)
                D4.Text = "x1 M"
                multi = 1000000
            Case "Violetax10 M"
                B3.BackColor = Color.FromArgb(105, 103, 206)
                D4.Text = "x10 M"
                multi = 10000000
            Case "Grisx100 M"
                B3.BackColor = Color.FromArgb(125, 125, 125)
                D4.Text = "x100 M"
                multi = 100000000
            Case "Blancox 1 G"
                B3.BackColor = Color.FromArgb(255, 255, 255)
                D4.Text = "x1 G"
                multi = 1000000000
            Case "Orox0.1"
                B3.BackColor = Color.FromArgb(192, 131, 39)
                D4.Text = "x0.1"
                multi = 0.1
            Case "Platax0.01"
                B3.BackColor = Color.FromArgb(191, 190, 191)
                D4.Text = "x0.01"
                multi = 0.01
        End Select
        CalcularResistencia(v)
    End Sub

    Private Sub CBX5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX5.SelectedIndexChanged
        Select Case CBX5.SelectedItem.ToString()
            Case 0
                B5.BackColor = Color.FromArgb(250, 250, 250)
                D3.Text = "0"
            Case "Negro0"
                B5.BackColor = Color.FromArgb(2, 2, 2)
                D3.Text = "0"
            Case "Marrón1"
                B5.BackColor = Color.FromArgb(81, 38, 39)
                D3.Text = "1"
            Case "Rojo2"
                B5.BackColor = Color.FromArgb(255, 33, 0)
                D3.Text = "2"
            Case "Naranja3"
                B5.BackColor = Color.FromArgb(216, 115, 71)
                D3.Text = "3"
            Case "Amarillo4"
                B5.BackColor = Color.FromArgb(230, 201, 81)
                D3.Text = "4"
            Case "Verde5"
                B5.BackColor = Color.FromArgb(82, 143, 101)
                D3.Text = "5"
            Case "Azul6"
                B5.BackColor = Color.FromArgb(15, 81, 144)
                D3.Text = "6"
            Case "Violeta7"
                B5.BackColor = Color.FromArgb(105, 103, 206)
                D3.Text = "7"
            Case "Gris8"
                B5.BackColor = Color.FromArgb(125, 125, 125)
                D3.Text = "8"
            Case "Blanco9"
                B5.BackColor = Color.FromArgb(255, 255, 255)
                D3.Text = "9"
        End Select
        CalcularResistencia(v)
    End Sub

    Private Sub CBX6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX6.SelectedIndexChanged
        Select Case CBX6.SelectedItem.ToString()
            Case 0
                B6.BackColor = Color.FromArgb(250, 250, 250)
                D5.Text = "0"
            Case "Marrón100 ppm"
                B6.BackColor = Color.FromArgb(81, 38, 39)
                D5.Text = "100 ppm"
            Case "Rojo50 ppm"
                B6.BackColor = Color.FromArgb(255, 33, 0)
                D5.Text = "50 ppm"
            Case "Naranja15 ppm"
                B6.BackColor = Color.FromArgb(216, 115, 71)
                D5.Text = "15 ppm"
            Case "Amarillo25 ppm"
                B6.BackColor = Color.FromArgb(230, 201, 81)
                D5.Text = "25 ppm"
            Case "Azul10 ppm"
                B6.BackColor = Color.FromArgb(15, 81, 144)
                D5.Text = "10 ppm"
            Case "Violeta5 ppm"
                B6.BackColor = Color.FromArgb(105, 103, 206)
                D5.Text = "5 ppm"
        End Select
        CalcularResistencia(v)
    End Sub

    Private Sub CBX4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBX4.SelectedIndexChanged
        Select Case CBX4.SelectedItem.ToString()
            Case 0
                B4.BackColor = Color.FromArgb(250, 250, 250)
                D6.Text = "0"
            Case "Marron ± 1%"
                B4.BackColor = Color.FromArgb(81, 38, 39)
                D6.Text = "± 1%"
                tole = 1
            Case "Rojo ± 2%"
                B4.BackColor = Color.FromArgb(255, 33, 0)
                D6.Text = "± 2%"
                tole = 2
            Case "Verde ± 0.5%"
                B4.BackColor = Color.FromArgb(82, 143, 101)
                D6.Text = "± 0.5%"
                tole = 0.5
            Case "Azul ± 0.25%"
                B4.BackColor = Color.FromArgb(15, 81, 144)
                D6.Text = "± 0.25%"
                tole = 0.25
            Case "Violeta ± 0.1%"
                B4.BackColor = Color.FromArgb(105, 103, 206)
                D6.Text = "± 0.1%"
                tole = 0.1
            Case "Gris ± 0.05%"
                B4.BackColor = Color.FromArgb(125, 125, 125)
                D6.Text = "± 0.05%"
                tole = 0.05
            Case "Oro ± 5%"
                B4.BackColor = Color.FromArgb(192, 131, 39)
                D6.Text = "± 5%"
                tole = 5
            Case "Plata ± 10%"
                B4.BackColor = Color.FromArgb(191, 190, 191)
                D6.Text = "± 10%"
                tole = 10
        End Select
        CalcularResistencia(v)
    End Sub
End Class
