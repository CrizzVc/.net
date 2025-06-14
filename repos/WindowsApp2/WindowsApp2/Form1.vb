Public Class Form1
    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        MessageBox.Show("Datos guardados!! :D", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub yn_Click(sender As Object, e As EventArgs) Handles yn.Click
        Dim res As DialogResult
        res = MessageBox.Show("usted es negro?", "confirmación", MessageBoxButtons.YesNo)
        If res = DialogResult.Yes Then
            MsgBox("un peruano!! que assskiooo")
            Application.Exit()
        ElseIf res = DialogResult.No Then
            MsgBox("Sos normal wacho")
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("error inesperado!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Private Sub TB1_TextChanged(sender As Object, e As EventArgs) Handles Nm1.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub suma_Click(sender As Object, e As EventArgs) Handles suma.Click
        Dim oper As String
        Dim num1 As Integer
        Dim num2 As Integer
        Dim resul As Integer

        If Nm1.Text = "" Then
            MessageBox.Show("El recuadro esta vacio!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Nm1.Focus()
        ElseIf Nm2.Text = "" Then
            MessageBox.Show("El recuadro esta vacio!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Nm1.Focus()
        Else
            num1 = Nm1.Text
            num2 = Nm2.Text
            resul = num1 + num2
            'MsgBox("su resultado es: " & resul
            res.Text = resul
            res.Font = New Font("Arial", 20, FontStyle.Bold)
            res.BackColor = Color.FromArgb(122, 222, 207)


        End If


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Nm1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nm1.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Nm2_TextChanged(sender As Object, e As EventArgs) Handles Nm2.TextChanged

    End Sub

    Private Sub Nm2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Nm2.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
