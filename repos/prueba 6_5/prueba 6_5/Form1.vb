Imports System.Net.Security

Public Class Form1
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles usa.CheckedChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles japon.CheckedChanged

    End Sub

    Private Sub latam_CheckedChanged(sender As Object, e As EventArgs) Handles latam.CheckedChanged

    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cambiar.Click
        'Dim text = ""
        'If usa.Checked = True Then
        '    text = text & "(ingles)"
        'ElseIf japon.Checked = True Then
        '    text = text & "(japon)"
        'ElseIf latam.Checked = True Then
        '    Me.Text = text & "(español)"
        'End If

        'Me.Text = text
        'caja.Text = text

        '-------------
        Dim text = ""

        If usa.Checked = True Then
            text &= "(ingles) "
        End If

        If japon.Checked = True Then
            text &= "(japon) "
        End If

        If latam.Checked = True Then
            text &= "(español) "
        End If

        Me.Text = text.Trim()
        caja.Text = text.Trim()

    End Sub

    Private Sub CheckBox1_CheckedChanged_2(sender As Object, e As EventArgs) Handles ingles.CheckedChanged
        If ingles.Checked = True Then
            ver.Text = "ingles"
            es.Checked = False
            jap.Checked = False
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles es.CheckedChanged
        If es.Checked = True Then
            ver.Text = "español"
            ingles.Checked = False
            jap.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles jap.CheckedChanged
        If jap.Checked = True Then
            ver.Text = "japones"
            es.Checked = False
            ingles.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged_3(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If cambiar.Enabled = False Then
            cambiar.Enabled = True
        Else
            cambiar.Enabled = False
        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class
