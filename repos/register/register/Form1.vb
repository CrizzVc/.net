Public Class Form1
    Dim a As Integer
    Dim b As Integer
    Dim c As Integer

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        a = ComboBox1.SelectedIndex
        b = ComboBox2.SelectedIndex
        b = ComboBox3.SelectedIndex
        Me.BackColor = Color.FromArgb(a, b, c)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim f As Integer
        For f = 0 To 255
            ComboBox1.Items.Add(f)
            ComboBox2.Items.Add(f)
            ComboBox3.Items.Add(f)
        Next
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class
