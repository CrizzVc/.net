Imports System.Data.SqlClient
Imports System.Reflection.Emit

Imports System.Drawing
Imports System.Drawing.Drawing2D



Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(235, 247, 227)
        aside.BackColor = Color.FromArgb(102, 176, 50)
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form3.Show()
        Me.Hide()
    End Sub

End Class


Public Class RoundedButton
    Inherits Button

    Public Property BorderRadius As Integer = 20

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        MyBase.OnPaint(pevent)

        ' Crear figura con esquinas redondeadas
        Dim path As New GraphicsPath()
        Dim rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
        path.AddArc(rect.X, rect.Y, BorderRadius, BorderRadius, 180, 90)
        path.AddArc(rect.Right - BorderRadius, rect.Y, BorderRadius, BorderRadius, 270, 90)
        path.AddArc(rect.Right - BorderRadius, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - BorderRadius, BorderRadius, BorderRadius, 90, 90)
        path.CloseAllFigures()

        ' Aplicar la forma al botón
        Me.Region = New Region(path)

        ' Dibujar borde (opcional)
        Dim pen As New Pen(Me.ForeColor, 2)
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        pevent.Graphics.DrawPath(pen, path)
    End Sub
End Class

