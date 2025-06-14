Public Class Form1

    Dim nm1 As Double
    Dim nm2 As Double
    Dim oper As String
    Dim ver As String
    Dim bool As Boolean
    Dim resul As Double
    Public punt As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ver = nm1 & oper & nm2
        bool = False
        punt = False
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles res.Click
        nm1 = CDbl(pantalla.Text)
        pantalla.Text = "-"
        oper = "-"
        pas.Text = nm1
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)
        bool = False
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles num0.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 0
        Else
            pantalla.Text = pantalla.Text & 0
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles num1.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 1
        Else
            pantalla.Text = pantalla.Text & 1
        End If

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles num2.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 2
        Else
            pantalla.Text = pantalla.Text & 2
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles num5.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 5
        Else
            pantalla.Text = pantalla.Text & 5
        End If
    End Sub

    Private Sub div_Click(sender As Object, e As EventArgs) Handles div.Click
        nm1 = CDbl(pantalla.Text)
        pantalla.Text = "/"
        oper = "/"
        pas.Text = nm1
    End Sub

    Private Sub mul_Click(sender As Object, e As EventArgs) Handles mul.Click
        nm1 = CDbl(pantalla.Text)
        pantalla.Text = "*"
        oper = "*"
        pas.Text = nm1
    End Sub

    Private Sub sum_Click(sender As Object, e As EventArgs) Handles sum.Click
        nm1 = CDbl(pantalla.Text)
        pantalla.Text = "+"
        oper = "+"
        pas.Text = nm1
    End Sub

    Private Sub num4_Click(sender As Object, e As EventArgs) Handles num4.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 4
        Else
            pantalla.Text = pantalla.Text & 4
        End If
    End Sub

    Private Sub num3_Click(sender As Object, e As EventArgs) Handles num3.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 3
        Else
            pantalla.Text = pantalla.Text & 3
        End If
    End Sub

    Private Sub num6_Click(sender As Object, e As EventArgs) Handles num6.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 6
        Else
            pantalla.Text = pantalla.Text & 6
        End If
    End Sub

    Private Sub num7_Click(sender As Object, e As EventArgs) Handles num7.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 7
        Else
            pantalla.Text = pantalla.Text & 7
        End If
    End Sub

    Private Sub num8_Click(sender As Object, e As EventArgs) Handles num8.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 8
        Else
            pantalla.Text = pantalla.Text & 8
        End If
    End Sub

    Private Sub num9_Click(sender As Object, e As EventArgs) Handles num9.Click
        If (pantalla.Text = "0" Or pantalla.Text = "+" Or pantalla.Text = "-" Or pantalla.Text = "/" Or pantalla.Text = "*") Then
            pantalla.Text = 9
        Else
            pantalla.Text = pantalla.Text & 9
        End If
    End Sub

    Private Sub igual_Click(sender As Object, e As EventArgs) Handles igual.Click
        nm2 = CDbl(pantalla.Text)
        If oper = "+" Then
            resul = nm1 + nm2
        ElseIf oper = "-" Then
            resul = nm1 - nm2
        ElseIf oper = "*" Then
            resul = nm1 * nm2
        ElseIf oper = "/" Then
            resul = nm1 / nm2
        End If
        pas.Text = nm1 & oper & nm2
        pantalla.Text = resul
        punt = False
    End Sub

    Private Sub Label2_Click_2(sender As Object, e As EventArgs) Handles del.Click
        pantalla.Text = 0
        nm1 = 0
        nm2 = 0
        resul = 0
        punt = True
    End Sub

    Private Sub tema_CheckedChanged(sender As Object, e As EventArgs) Handles tema.CheckedChanged
        If tema.Checked = True Then
            tema.Text = "light"
            Me.BackColor = Color.White
            pantalla.ForeColor = Color.Black
            num1.BackColor = Color.FromArgb(237, 237, 237)
            num2.BackColor = Color.FromArgb(237, 237, 237)
            num3.BackColor = Color.FromArgb(237, 237, 237)
            num4.BackColor = Color.FromArgb(237, 237, 237)
            num5.BackColor = Color.FromArgb(237, 237, 237)
            num6.BackColor = Color.FromArgb(237, 237, 237)
            num7.BackColor = Color.FromArgb(237, 237, 237)
            num8.BackColor = Color.FromArgb(237, 237, 237)
            num9.BackColor = Color.FromArgb(237, 237, 237)
            num0.BackColor = Color.FromArgb(237, 237, 237)
            pun.BackColor = Color.FromArgb(237, 237, 237)
            bool = False
            num1.ForeColor = Color.Black
            num2.ForeColor = Color.Black
            num3.ForeColor = Color.Black
            num4.ForeColor = Color.Black
            num5.ForeColor = Color.Black
            num6.ForeColor = Color.Black
            num7.ForeColor = Color.Black
            num8.ForeColor = Color.Black
            num9.ForeColor = Color.Black
            num0.ForeColor = Color.Black
            del.ForeColor = Color.Black
            pas.ForeColor = Color.Black
            pun.ForeColor = Color.Black
            igual.ForeColor = Color.Black

        Else
            Me.BackColor = Color.FromArgb(21, 20, 52)
            pantalla.ForeColor = Color.White
            num1.BackColor = Color.FromArgb(48, 44, 76)
            num2.BackColor = Color.FromArgb(48, 44, 76)
            num3.BackColor = Color.FromArgb(48, 44, 76)
            num4.BackColor = Color.FromArgb(48, 44, 76)
            num5.BackColor = Color.FromArgb(48, 44, 76)
            num6.BackColor = Color.FromArgb(48, 44, 76)
            num7.BackColor = Color.FromArgb(48, 44, 76)
            num8.BackColor = Color.FromArgb(48, 44, 76)
            num9.BackColor = Color.FromArgb(48, 44, 76)
            num0.BackColor = Color.FromArgb(48, 44, 76)
            pun.BackColor = Color.FromArgb(48, 44, 76)
            bool = True
            num1.ForeColor = Color.White
            num2.ForeColor = Color.White
            num3.ForeColor = Color.White
            num4.ForeColor = Color.White
            num5.ForeColor = Color.White
            num6.ForeColor = Color.White
            num7.ForeColor = Color.White
            num8.ForeColor = Color.White
            num9.ForeColor = Color.White
            num0.ForeColor = Color.White
            del.ForeColor = Color.White
            pun.ForeColor = Color.White
            pas.ForeColor = Color.LightGray
            igual.ForeColor = Color.White
            tema.Text = "darck"
        End If
    End Sub

    Private Sub pun_Click(sender As Object, e As EventArgs) Handles pun.Click
        If punt = False Then
            pantalla.Text &= "."
            punt = True
        End If
    End Sub

    Private Sub operador_Click(sender As Object, e As EventArgs) Handles sum.Click, res.Click, mul.Click, div.Click, del.Click
        punt = False
    End Sub

End Class
