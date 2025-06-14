Public Class Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a As String
        If (nom.Text = "" Or age.SelectedIndex = -1 Or alt.Text = "" Or peso.Text = "") Then
            MsgBox("rellene los campos")

        ElseIf Val(alt.Text) > 100 Or val(peso.Text) < 10 Then
            MsgBox("por favor rectifique")


        Else
            Module1.data1 = nom.Text
            Module1.data2 = age.SelectedIndex
            Module1.data3 = Val(alt.Text)
            Module1.data4 = Val(peso.Text)
            Module1.data5 = imc.Text


            Module1.res = Module1.data4 / (Module1.data3 * Module1.data3)
            imc.Text = Math.Round(Module1.res, 2)

            If res < 18.5 Then
                a = "bajo peso"
                mic.ForeColor = Color.FromArgb(255, 217, 54)
            ElseIf res > 18.5 And res < 24.9 Then
                a = "peso saludable"
                mic.ForeColor = Color.FromArgb(0, 143, 53)
            ElseIf res > 25.0 And res < 29.9 Then
                a = "sobre peso"
                mic.ForeColor = Color.FromArgb(255, 151, 141)
            ElseIf res > 30.0 Then
                a = "obesidad"
                mic.ForeColor = Color.FromArgb(255, 36, 25)
            End If

            fin.Text = "usted se encuentra en:  "
            mic.Text = a

        End If


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles age.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles alt.TextChanged

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles fin.Click

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 120
            age.Items.Add(i)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Form1.Close()
        Me.Close()
    End Sub

    Private Sub nom_TextChanged(sender As Object, e As EventArgs) Handles nom.TextChanged

    End Sub
End Class