<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.usa = New System.Windows.Forms.CheckBox()
        Me.japon = New System.Windows.Forms.CheckBox()
        Me.latam = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cambiar = New System.Windows.Forms.Button()
        Me.caja = New System.Windows.Forms.TextBox()
        Me.ver = New System.Windows.Forms.Label()
        Me.ingles = New System.Windows.Forms.CheckBox()
        Me.es = New System.Windows.Forms.CheckBox()
        Me.jap = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'usa
        '
        Me.usa.AutoSize = True
        Me.usa.Location = New System.Drawing.Point(18, 31)
        Me.usa.Name = "usa"
        Me.usa.Size = New System.Drawing.Size(53, 17)
        Me.usa.TabIndex = 0
        Me.usa.Text = "ingles"
        Me.usa.UseVisualStyleBackColor = True
        '
        'japon
        '
        Me.japon.AutoSize = True
        Me.japon.Location = New System.Drawing.Point(18, 111)
        Me.japon.Name = "japon"
        Me.japon.Size = New System.Drawing.Size(63, 17)
        Me.japon.TabIndex = 1
        Me.japon.Text = "japones"
        Me.japon.UseVisualStyleBackColor = True
        '
        'latam
        '
        Me.latam.AutoSize = True
        Me.latam.Location = New System.Drawing.Point(18, 70)
        Me.latam.Name = "latam"
        Me.latam.Size = New System.Drawing.Size(63, 17)
        Me.latam.TabIndex = 2
        Me.latam.Text = "español"
        Me.latam.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.usa)
        Me.GroupBox1.Controls.Add(Me.latam)
        Me.GroupBox1.Controls.Add(Me.japon)
        Me.GroupBox1.Location = New System.Drawing.Point(72, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 149)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "lenguajes"
        Me.GroupBox1.Visible = False
        '
        'cambiar
        '
        Me.cambiar.Enabled = False
        Me.cambiar.Location = New System.Drawing.Point(78, 374)
        Me.cambiar.Name = "cambiar"
        Me.cambiar.Size = New System.Drawing.Size(75, 23)
        Me.cambiar.TabIndex = 4
        Me.cambiar.Text = "cambiar"
        Me.cambiar.UseVisualStyleBackColor = True
        Me.cambiar.Visible = False
        '
        'caja
        '
        Me.caja.Location = New System.Drawing.Point(72, 233)
        Me.caja.Name = "caja"
        Me.caja.Size = New System.Drawing.Size(208, 20)
        Me.caja.TabIndex = 5
        Me.caja.Visible = False
        '
        'ver
        '
        Me.ver.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ver.Location = New System.Drawing.Point(466, 52)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(171, 97)
        Me.ver.TabIndex = 6
        Me.ver.Text = "..."
        Me.ver.Visible = False
        '
        'ingles
        '
        Me.ingles.AutoSize = True
        Me.ingles.Location = New System.Drawing.Point(657, 52)
        Me.ingles.Name = "ingles"
        Me.ingles.Size = New System.Drawing.Size(53, 17)
        Me.ingles.TabIndex = 3
        Me.ingles.Text = "ingles"
        Me.ingles.UseVisualStyleBackColor = True
        Me.ingles.Visible = False
        '
        'es
        '
        Me.es.AutoSize = True
        Me.es.Location = New System.Drawing.Point(657, 91)
        Me.es.Name = "es"
        Me.es.Size = New System.Drawing.Size(63, 17)
        Me.es.TabIndex = 5
        Me.es.Text = "español"
        Me.es.UseVisualStyleBackColor = True
        Me.es.Visible = False
        '
        'jap
        '
        Me.jap.AutoSize = True
        Me.jap.Location = New System.Drawing.Point(657, 132)
        Me.jap.Name = "jap"
        Me.jap.Size = New System.Drawing.Size(63, 17)
        Me.jap.TabIndex = 4
        Me.jap.Text = "japones"
        Me.jap.UseVisualStyleBackColor = True
        Me.jap.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(72, 309)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(41, 17)
        Me.CheckBox1.TabIndex = 7
        Me.CheckBox1.Text = "ver"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(363, 214)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Empezar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ingles)
        Me.Controls.Add(Me.ver)
        Me.Controls.Add(Me.es)
        Me.Controls.Add(Me.jap)
        Me.Controls.Add(Me.caja)
        Me.Controls.Add(Me.cambiar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents usa As CheckBox
    Friend WithEvents japon As CheckBox
    Friend WithEvents latam As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cambiar As Button
    Friend WithEvents caja As TextBox
    Friend WithEvents ver As Label
    Friend WithEvents ingles As CheckBox
    Friend WithEvents es As CheckBox
    Friend WithEvents jap As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Button1 As Button
End Class
