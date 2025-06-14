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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cb1 = New System.Windows.Forms.ComboBox()
        Me.cb2 = New System.Windows.Forms.ComboBox()
        Me.cb3 = New System.Windows.Forms.ComboBox()
        Me.cb4 = New System.Windows.Forms.ComboBox()
        Me.cb5 = New System.Windows.Forms.ComboBox()
        Me.cb6 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dt1 = New System.Windows.Forms.Label()
        Me.dt2 = New System.Windows.Forms.Label()
        Me.dt3 = New System.Windows.Forms.Label()
        Me.dt4 = New System.Windows.Forms.Label()
        Me.dt6 = New System.Windows.Forms.Label()
        Me.dt5 = New System.Windows.Forms.Label()
        Me.ln2 = New System.Windows.Forms.Label()
        Me.ln3 = New System.Windows.Forms.Label()
        Me.ln4 = New System.Windows.Forms.Label()
        Me.ln1 = New System.Windows.Forms.Label()
        Me.ln5 = New System.Windows.Forms.Label()
        Me.ln6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.resp = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Resistencia"
        '
        'cb1
        '
        Me.cb1.AutoCompleteCustomSource.AddRange(New String() {"100250200"})
        Me.cb1.FormattingEnabled = True
        Me.cb1.Items.AddRange(New Object() {""})
        Me.cb1.Location = New System.Drawing.Point(29, 112)
        Me.cb1.Name = "cb1"
        Me.cb1.Size = New System.Drawing.Size(237, 21)
        Me.cb1.TabIndex = 1
        '
        'cb2
        '
        Me.cb2.FormattingEnabled = True
        Me.cb2.Location = New System.Drawing.Point(29, 161)
        Me.cb2.Name = "cb2"
        Me.cb2.Size = New System.Drawing.Size(237, 21)
        Me.cb2.TabIndex = 2
        '
        'cb3
        '
        Me.cb3.FormattingEnabled = True
        Me.cb3.Location = New System.Drawing.Point(29, 210)
        Me.cb3.Name = "cb3"
        Me.cb3.Size = New System.Drawing.Size(237, 21)
        Me.cb3.TabIndex = 3
        '
        'cb4
        '
        Me.cb4.FormattingEnabled = True
        Me.cb4.Location = New System.Drawing.Point(29, 264)
        Me.cb4.Name = "cb4"
        Me.cb4.Size = New System.Drawing.Size(237, 21)
        Me.cb4.TabIndex = 4
        '
        'cb5
        '
        Me.cb5.FormattingEnabled = True
        Me.cb5.Location = New System.Drawing.Point(29, 316)
        Me.cb5.Name = "cb5"
        Me.cb5.Size = New System.Drawing.Size(237, 21)
        Me.cb5.TabIndex = 5
        Me.cb5.Visible = False
        '
        'cb6
        '
        Me.cb6.FormattingEnabled = True
        Me.cb6.Location = New System.Drawing.Point(29, 363)
        Me.cb6.Name = "cb6"
        Me.cb6.Size = New System.Drawing.Size(237, 21)
        Me.cb6.TabIndex = 6
        Me.cb6.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(29, 69)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "4"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(110, 69)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "5"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(191, 69)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "6"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = Global.resitencias.My.Resources.Resources.res1
        Me.PictureBox1.Location = New System.Drawing.Point(340, 112)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(420, 118)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'dt1
        '
        Me.dt1.AutoSize = True
        Me.dt1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dt1.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt1.Location = New System.Drawing.Point(392, 292)
        Me.dt1.Name = "dt1"
        Me.dt1.Size = New System.Drawing.Size(18, 21)
        Me.dt1.TabIndex = 11
        Me.dt1.Text = ".."
        '
        'dt2
        '
        Me.dt2.AutoSize = True
        Me.dt2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dt2.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt2.Location = New System.Drawing.Point(495, 292)
        Me.dt2.Name = "dt2"
        Me.dt2.Size = New System.Drawing.Size(18, 21)
        Me.dt2.TabIndex = 12
        Me.dt2.Text = ".."
        Me.dt2.Visible = False
        '
        'dt3
        '
        Me.dt3.AutoSize = True
        Me.dt3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dt3.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt3.Location = New System.Drawing.Point(456, 292)
        Me.dt3.Name = "dt3"
        Me.dt3.Size = New System.Drawing.Size(18, 21)
        Me.dt3.TabIndex = 13
        Me.dt3.Text = ".."
        '
        'dt4
        '
        Me.dt4.AutoSize = True
        Me.dt4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dt4.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt4.Location = New System.Drawing.Point(566, 292)
        Me.dt4.Name = "dt4"
        Me.dt4.Size = New System.Drawing.Size(18, 21)
        Me.dt4.TabIndex = 14
        Me.dt4.Text = ".."
        '
        'dt6
        '
        Me.dt6.AutoSize = True
        Me.dt6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dt6.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt6.Location = New System.Drawing.Point(698, 292)
        Me.dt6.Name = "dt6"
        Me.dt6.Size = New System.Drawing.Size(18, 21)
        Me.dt6.TabIndex = 15
        Me.dt6.Text = ".."
        '
        'dt5
        '
        Me.dt5.AutoSize = True
        Me.dt5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dt5.Font = New System.Drawing.Font("Microsoft YaHei", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dt5.Location = New System.Drawing.Point(629, 292)
        Me.dt5.Name = "dt5"
        Me.dt5.Size = New System.Drawing.Size(18, 21)
        Me.dt5.TabIndex = 16
        Me.dt5.Text = ".."
        Me.dt5.Visible = False
        '
        'ln2
        '
        Me.ln2.Location = New System.Drawing.Point(496, 137)
        Me.ln2.Name = "ln2"
        Me.ln2.Size = New System.Drawing.Size(23, 65)
        Me.ln2.TabIndex = 17
        Me.ln2.Visible = False
        '
        'ln3
        '
        Me.ln3.Location = New System.Drawing.Point(451, 137)
        Me.ln3.Name = "ln3"
        Me.ln3.Size = New System.Drawing.Size(23, 65)
        Me.ln3.TabIndex = 18
        '
        'ln4
        '
        Me.ln4.Location = New System.Drawing.Point(561, 137)
        Me.ln4.Name = "ln4"
        Me.ln4.Size = New System.Drawing.Size(23, 65)
        Me.ln4.TabIndex = 19
        '
        'ln1
        '
        Me.ln1.Location = New System.Drawing.Point(387, 123)
        Me.ln1.Name = "ln1"
        Me.ln1.Size = New System.Drawing.Size(23, 95)
        Me.ln1.TabIndex = 20
        '
        'ln5
        '
        Me.ln5.Location = New System.Drawing.Point(624, 137)
        Me.ln5.Name = "ln5"
        Me.ln5.Size = New System.Drawing.Size(23, 65)
        Me.ln5.TabIndex = 21
        Me.ln5.Visible = False
        '
        'ln6
        '
        Me.ln6.Location = New System.Drawing.Point(693, 123)
        Me.ln6.Name = "ln6"
        Me.ln6.Size = New System.Drawing.Size(23, 94)
        Me.ln6.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(348, 346)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 28)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Su Resistencia es:"
        '
        'resp
        '
        Me.resp.AutoSize = True
        Me.resp.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resp.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.resp.Location = New System.Drawing.Point(559, 346)
        Me.resp.Name = "resp"
        Me.resp.Size = New System.Drawing.Size(68, 28)
        Me.resp.TabIndex = 24
        Me.resp.Text = "ohms"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.resp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ln6)
        Me.Controls.Add(Me.ln5)
        Me.Controls.Add(Me.ln1)
        Me.Controls.Add(Me.ln4)
        Me.Controls.Add(Me.ln3)
        Me.Controls.Add(Me.ln2)
        Me.Controls.Add(Me.dt5)
        Me.Controls.Add(Me.dt6)
        Me.Controls.Add(Me.dt4)
        Me.Controls.Add(Me.dt3)
        Me.Controls.Add(Me.dt2)
        Me.Controls.Add(Me.dt1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cb6)
        Me.Controls.Add(Me.cb5)
        Me.Controls.Add(Me.cb4)
        Me.Controls.Add(Me.cb3)
        Me.Controls.Add(Me.cb2)
        Me.Controls.Add(Me.cb1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cb1 As ComboBox
    Friend WithEvents cb2 As ComboBox
    Friend WithEvents cb3 As ComboBox
    Friend WithEvents cb4 As ComboBox
    Friend WithEvents cb5 As ComboBox
    Friend WithEvents cb6 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dt1 As Label
    Friend WithEvents dt2 As Label
    Friend WithEvents dt3 As Label
    Friend WithEvents dt4 As Label
    Friend WithEvents dt6 As Label
    Friend WithEvents dt5 As Label
    Friend WithEvents ln2 As Label
    Friend WithEvents ln3 As Label
    Friend WithEvents ln4 As Label
    Friend WithEvents ln1 As Label
    Friend WithEvents ln5 As Label
    Friend WithEvents ln6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents resp As Label
End Class
