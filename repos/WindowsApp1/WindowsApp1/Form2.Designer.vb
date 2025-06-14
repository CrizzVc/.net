<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Btnlunes = New System.Windows.Forms.Button()
        Me.btnmartes = New System.Windows.Forms.Button()
        Me.Btnmiercoles = New System.Windows.Forms.Button()
        Me.Btnjueves = New System.Windows.Forms.Button()
        Me.Btnviernes = New System.Windows.Forms.Button()
        Me.btndomingo = New System.Windows.Forms.Button()
        Me.btnsabado = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mostrar = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WindowsApp1.My.Resources.Resources.gato_serio
        Me.PictureBox1.Location = New System.Drawing.Point(552, 239)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(236, 196)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Btnlunes
        '
        Me.Btnlunes.Location = New System.Drawing.Point(34, 26)
        Me.Btnlunes.Name = "Btnlunes"
        Me.Btnlunes.Size = New System.Drawing.Size(75, 34)
        Me.Btnlunes.TabIndex = 1
        Me.Btnlunes.Text = "lunes"
        Me.Btnlunes.UseVisualStyleBackColor = True
        '
        'btnmartes
        '
        Me.btnmartes.Location = New System.Drawing.Point(34, 85)
        Me.btnmartes.Name = "btnmartes"
        Me.btnmartes.Size = New System.Drawing.Size(75, 31)
        Me.btnmartes.TabIndex = 2
        Me.btnmartes.Text = "martes"
        Me.btnmartes.UseVisualStyleBackColor = True
        '
        'Btnmiercoles
        '
        Me.Btnmiercoles.Location = New System.Drawing.Point(34, 150)
        Me.Btnmiercoles.Name = "Btnmiercoles"
        Me.Btnmiercoles.Size = New System.Drawing.Size(75, 33)
        Me.Btnmiercoles.TabIndex = 3
        Me.Btnmiercoles.Text = "miercoles"
        Me.Btnmiercoles.UseVisualStyleBackColor = True
        '
        'Btnjueves
        '
        Me.Btnjueves.Location = New System.Drawing.Point(34, 212)
        Me.Btnjueves.Name = "Btnjueves"
        Me.Btnjueves.Size = New System.Drawing.Size(75, 31)
        Me.Btnjueves.TabIndex = 4
        Me.Btnjueves.Text = "jueves"
        Me.Btnjueves.UseVisualStyleBackColor = True
        '
        'Btnviernes
        '
        Me.Btnviernes.Location = New System.Drawing.Point(34, 276)
        Me.Btnviernes.Name = "Btnviernes"
        Me.Btnviernes.Size = New System.Drawing.Size(75, 31)
        Me.Btnviernes.TabIndex = 5
        Me.Btnviernes.Text = "viernes"
        Me.Btnviernes.UseVisualStyleBackColor = True
        '
        'btndomingo
        '
        Me.btndomingo.Location = New System.Drawing.Point(34, 397)
        Me.btndomingo.Name = "btndomingo"
        Me.btndomingo.Size = New System.Drawing.Size(75, 31)
        Me.btndomingo.TabIndex = 7
        Me.btndomingo.Text = "domingo"
        Me.btndomingo.UseVisualStyleBackColor = True
        '
        'btnsabado
        '
        Me.btnsabado.Location = New System.Drawing.Point(34, 333)
        Me.btnsabado.Name = "btnsabado"
        Me.btnsabado.Size = New System.Drawing.Size(75, 31)
        Me.btnsabado.TabIndex = 6
        Me.btnsabado.Text = "sabado"
        Me.btnsabado.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(306, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 28)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Dias de la semana"
        '
        'mostrar
        '
        Me.mostrar.AutoSize = True
        Me.mostrar.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mostrar.Location = New System.Drawing.Point(379, 210)
        Me.mostrar.Name = "mostrar"
        Me.mostrar.Size = New System.Drawing.Size(24, 28)
        Me.mostrar.TabIndex = 9
        Me.mostrar.Text = "1"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.mostrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btndomingo)
        Me.Controls.Add(Me.btnsabado)
        Me.Controls.Add(Me.Btnviernes)
        Me.Controls.Add(Me.Btnjueves)
        Me.Controls.Add(Me.Btnmiercoles)
        Me.Controls.Add(Me.btnmartes)
        Me.Controls.Add(Me.Btnlunes)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Btnlunes As Button
    Friend WithEvents btnmartes As Button
    Friend WithEvents Btnmiercoles As Button
    Friend WithEvents Btnjueves As Button
    Friend WithEvents Btnviernes As Button
    Friend WithEvents btndomingo As Button
    Friend WithEvents btnsabado As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents mostrar As Label
End Class
