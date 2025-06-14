Imports System.Runtime.ConstrainedExecution

Public Class Form2
    Dim num1 As Integer
    Dim num2 As Integer
    Dim oper As String
    Dim resul As Integer

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles sum.CheckedChanged
        If sum.Checked = True Then
            res.Checked = False
            mul.Checked = False
            enviar.Enabled = True
            oper = "+"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles enviar.Click
        If tb1.Text = "" Or tb2.Text = "" Then
            MsgBox("capos vacios")
        Else

            num1 = Val(tb1.Text)
            num2 = Val(tb2.Text)
            If oper = "+" Then
                resul = num1 + num2
                Form3.ver1.Text = resul
                Form3.Show()
                Me.Hide()
            ElseIf oper = "-" Then
                resul = num1 - num2
                Form4.ver1.Text = resul
                Form4.Show()
                Me.Hide()
            ElseIf oper = "*" Then
                resul = num1 * num2
                Form5.ver1.Text = resul
                Form5.Show()
                Me.Hide()
            End If

        End If


    End Sub

    Private Sub res_CheckedChanged(sender As Object, e As EventArgs) Handles res.CheckedChanged
        If res.Checked = True Then
            sum.Checked = False
            mul.Checked = False
            enviar.Enabled = True
            oper = "-"
        End If
    End Sub

    Private Sub mul_CheckedChanged(sender As Object, e As EventArgs) Handles mul.CheckedChanged
        If mul.Checked = True Then
            sum.Checked = False
            res.Checked = False
            enviar.Enabled = True
            oper = "*"
        End If
    End Sub

    Private Sub salir_Click(sender As Object, e As EventArgs) Handles salir.Click
        Me.Close()
        Form1.Close()
        Form3.Close()
        Form4.Close()
        Form5.Close()
    End Sub
End Class