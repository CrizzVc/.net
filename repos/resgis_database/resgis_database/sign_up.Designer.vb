<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class sign_up
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(sign_up))
        Me.BoxCedula = New System.Windows.Forms.TextBox()
        Me.BoxUser = New System.Windows.Forms.TextBox()
        Me.savePro = New System.Windows.Forms.Button()
        Me.BoxContra = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BoxCedula
        '
        Me.BoxCedula.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxCedula.Location = New System.Drawing.Point(48, 166)
        Me.BoxCedula.Name = "BoxCedula"
        Me.BoxCedula.Size = New System.Drawing.Size(213, 27)
        Me.BoxCedula.TabIndex = 7
        '
        'BoxUser
        '
        Me.BoxUser.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxUser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxUser.Location = New System.Drawing.Point(47, 112)
        Me.BoxUser.Name = "BoxUser"
        Me.BoxUser.Size = New System.Drawing.Size(213, 27)
        Me.BoxUser.TabIndex = 6
        '
        'savePro
        '
        Me.savePro.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.savePro.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.savePro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.savePro.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.savePro.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.savePro.Location = New System.Drawing.Point(47, 270)
        Me.savePro.Name = "savePro"
        Me.savePro.Size = New System.Drawing.Size(212, 35)
        Me.savePro.TabIndex = 5
        Me.savePro.Text = "Registrar"
        Me.savePro.UseVisualStyleBackColor = False
        '
        'BoxContra
        '
        Me.BoxContra.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxContra.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxContra.Location = New System.Drawing.Point(48, 218)
        Me.BoxContra.Name = "BoxContra"
        Me.BoxContra.Size = New System.Drawing.Size(213, 27)
        Me.BoxContra.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(47, 348)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(212, 35)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Iniciar Sesion"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(40, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 42)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Sign Up"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(44, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 19)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Usuario"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(44, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 19)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Cedula"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(44, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 19)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Contraseña"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(142, 316)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 20)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "ó"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.BoxContra)
        Me.Panel1.Controls.Add(Me.BoxCedula)
        Me.Panel1.Controls.Add(Me.BoxUser)
        Me.Panel1.Controls.Add(Me.savePro)
        Me.Panel1.Location = New System.Drawing.Point(34, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(309, 411)
        Me.Panel1.TabIndex = 30
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.resgis_database.My.Resources.Resources.plane
        Me.PictureBox1.Location = New System.Drawing.Point(395, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(405, 527)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 24
        Me.PictureBox1.TabStop = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 527)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form3"
        Me.Text = "Registro"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BoxCedula As TextBox
    Friend WithEvents BoxUser As TextBox
    Friend WithEvents savePro As Button
    Friend WithEvents BoxContra As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel1 As Panel
End Class
