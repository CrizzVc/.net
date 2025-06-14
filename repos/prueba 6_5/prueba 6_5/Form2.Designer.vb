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
        Me.sum = New System.Windows.Forms.CheckBox()
        Me.mul = New System.Windows.Forms.CheckBox()
        Me.res = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tb1 = New System.Windows.Forms.TextBox()
        Me.tb2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.enviar = New System.Windows.Forms.Button()
        Me.salir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'sum
        '
        Me.sum.AutoSize = True
        Me.sum.Location = New System.Drawing.Point(27, 30)
        Me.sum.Name = "sum"
        Me.sum.Size = New System.Drawing.Size(53, 17)
        Me.sum.TabIndex = 0
        Me.sum.Text = "Suma"
        Me.sum.UseVisualStyleBackColor = True
        '
        'mul
        '
        Me.mul.AutoSize = True
        Me.mul.Location = New System.Drawing.Point(27, 102)
        Me.mul.Name = "mul"
        Me.mul.Size = New System.Drawing.Size(90, 17)
        Me.mul.TabIndex = 1
        Me.mul.Text = "Multiplicacion"
        Me.mul.UseVisualStyleBackColor = True
        '
        'res
        '
        Me.res.AutoSize = True
        Me.res.Location = New System.Drawing.Point(27, 65)
        Me.res.Name = "res"
        Me.res.Size = New System.Drawing.Size(54, 17)
        Me.res.TabIndex = 2
        Me.res.Text = "Resta"
        Me.res.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GroupBox1.Controls.Add(Me.salir)
        Me.GroupBox1.Controls.Add(Me.enviar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tb2)
        Me.GroupBox1.Controls.Add(Me.tb1)
        Me.GroupBox1.Controls.Add(Me.res)
        Me.GroupBox1.Controls.Add(Me.mul)
        Me.GroupBox1.Controls.Add(Me.sum)
        Me.GroupBox1.Location = New System.Drawing.Point(268, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(261, 286)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "calculater"
        '
        'tb1
        '
        Me.tb1.Location = New System.Drawing.Point(69, 133)
        Me.tb1.Name = "tb1"
        Me.tb1.Size = New System.Drawing.Size(108, 20)
        Me.tb1.TabIndex = 3
        '
        'tb2
        '
        Me.tb2.Location = New System.Drawing.Point(69, 180)
        Me.tb2.Name = "tb2"
        Me.tb2.Size = New System.Drawing.Size(108, 20)
        Me.tb2.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "num1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "num2"
        '
        'enviar
        '
        Me.enviar.Enabled = False
        Me.enviar.Location = New System.Drawing.Point(27, 230)
        Me.enviar.Name = "enviar"
        Me.enviar.Size = New System.Drawing.Size(75, 23)
        Me.enviar.TabIndex = 7
        Me.enviar.Text = "enviar"
        Me.enviar.UseVisualStyleBackColor = True
        '
        'salir
        '
        Me.salir.BackColor = System.Drawing.Color.IndianRed
        Me.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.salir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.salir.Location = New System.Drawing.Point(141, 230)
        Me.salir.Name = "salir"
        Me.salir.Size = New System.Drawing.Size(75, 23)
        Me.salir.TabIndex = 8
        Me.salir.Text = "salir"
        Me.salir.UseVisualStyleBackColor = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents sum As CheckBox
    Friend WithEvents mul As CheckBox
    Friend WithEvents res As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tb2 As TextBox
    Friend WithEvents tb1 As TextBox
    Friend WithEvents enviar As Button
    Friend WithEvents salir As Button
End Class
