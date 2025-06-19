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
        Me.aside = New System.Windows.Forms.Panel()
        Me.masPro = New System.Windows.Forms.Button()
        Me.product = New System.Windows.Forms.Button()
        Me.PlPro = New System.Windows.Forms.Panel()
        Me.PlMas = New System.Windows.Forms.Panel()
        Me.LbProPR = New System.Windows.Forms.Label()
        Me.LbProName = New System.Windows.Forms.Label()
        Me.preciPro = New System.Windows.Forms.TextBox()
        Me.NamePro = New System.Windows.Forms.TextBox()
        Me.savePro = New System.Windows.Forms.Button()
        Me.borrar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.lista = New System.Windows.Forms.Panel()
        Me.aside.SuspendLayout()
        Me.PlPro.SuspendLayout()
        Me.PlMas.SuspendLayout()
        Me.SuspendLayout()
        '
        'aside
        '
        Me.aside.AutoScroll = True
        Me.aside.AutoScrollMinSize = New System.Drawing.Size(200, 0)
        Me.aside.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.aside.Controls.Add(Me.masPro)
        Me.aside.Controls.Add(Me.product)
        Me.aside.Dock = System.Windows.Forms.DockStyle.Left
        Me.aside.Location = New System.Drawing.Point(0, 0)
        Me.aside.Name = "aside"
        Me.aside.Size = New System.Drawing.Size(201, 450)
        Me.aside.TabIndex = 19
        '
        'masPro
        '
        Me.masPro.Dock = System.Windows.Forms.DockStyle.Top
        Me.masPro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.masPro.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.masPro.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masPro.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.masPro.Location = New System.Drawing.Point(0, 40)
        Me.masPro.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.masPro.Name = "masPro"
        Me.masPro.Size = New System.Drawing.Size(201, 40)
        Me.masPro.TabIndex = 2
        Me.masPro.Text = "agregar producto"
        Me.masPro.UseVisualStyleBackColor = False
        '
        'product
        '
        Me.product.Dock = System.Windows.Forms.DockStyle.Top
        Me.product.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.product.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.product.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.product.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.product.Location = New System.Drawing.Point(0, 0)
        Me.product.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.product.Name = "product"
        Me.product.Size = New System.Drawing.Size(201, 40)
        Me.product.TabIndex = 1
        Me.product.Text = "productos"
        Me.product.UseVisualStyleBackColor = False
        '
        'PlPro
        '
        Me.PlPro.Controls.Add(Me.borrar)
        Me.PlPro.Controls.Add(Me.Button2)
        Me.PlPro.Controls.Add(Me.Label1)
        Me.PlPro.Controls.Add(Me.Label4)
        Me.PlPro.Controls.Add(Me.Button3)
        Me.PlPro.Controls.Add(Me.Label3)
        Me.PlPro.Controls.Add(Me.TextBox4)
        Me.PlPro.Controls.Add(Me.lista)
        Me.PlPro.Location = New System.Drawing.Point(201, 0)
        Me.PlPro.Name = "PlPro"
        Me.PlPro.Size = New System.Drawing.Size(599, 450)
        Me.PlPro.TabIndex = 20
        '
        'PlMas
        '
        Me.PlMas.Controls.Add(Me.LbProPR)
        Me.PlMas.Controls.Add(Me.LbProName)
        Me.PlMas.Controls.Add(Me.preciPro)
        Me.PlMas.Controls.Add(Me.NamePro)
        Me.PlMas.Controls.Add(Me.savePro)
        Me.PlMas.Location = New System.Drawing.Point(201, 0)
        Me.PlMas.Name = "PlMas"
        Me.PlMas.Size = New System.Drawing.Size(599, 450)
        Me.PlMas.TabIndex = 30
        Me.PlMas.Visible = False
        '
        'LbProPR
        '
        Me.LbProPR.AutoSize = True
        Me.LbProPR.Location = New System.Drawing.Point(26, 100)
        Me.LbProPR.Name = "LbProPR"
        Me.LbProPR.Size = New System.Drawing.Size(36, 13)
        Me.LbProPR.TabIndex = 14
        Me.LbProPR.Text = "precio"
        '
        'LbProName
        '
        Me.LbProName.AutoSize = True
        Me.LbProName.Location = New System.Drawing.Point(26, 34)
        Me.LbProName.Name = "LbProName"
        Me.LbProName.Size = New System.Drawing.Size(44, 13)
        Me.LbProName.TabIndex = 13
        Me.LbProName.Text = "Nombre"
        '
        'preciPro
        '
        Me.preciPro.Location = New System.Drawing.Point(29, 116)
        Me.preciPro.Name = "preciPro"
        Me.preciPro.Size = New System.Drawing.Size(138, 20)
        Me.preciPro.TabIndex = 12
        '
        'NamePro
        '
        Me.NamePro.Location = New System.Drawing.Point(29, 50)
        Me.NamePro.Name = "NamePro"
        Me.NamePro.Size = New System.Drawing.Size(138, 20)
        Me.NamePro.TabIndex = 11
        '
        'savePro
        '
        Me.savePro.Location = New System.Drawing.Point(434, 381)
        Me.savePro.Name = "savePro"
        Me.savePro.Size = New System.Drawing.Size(138, 35)
        Me.savePro.TabIndex = 10
        Me.savePro.Text = "Guardar"
        Me.savePro.UseVisualStyleBackColor = True
        '
        'borrar
        '
        Me.borrar.BackColor = System.Drawing.Color.IndianRed
        Me.borrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.borrar.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.borrar.Location = New System.Drawing.Point(511, 400)
        Me.borrar.Name = "borrar"
        Me.borrar.Size = New System.Drawing.Size(84, 33)
        Me.borrar.TabIndex = 22
        Me.borrar.Text = "Borrar"
        Me.borrar.UseVisualStyleBackColor = False
        Me.borrar.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(501, 42)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Recargar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 19)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(175, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 19)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Precio"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(528, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(48, 23)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "🔍︎"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(82, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 19)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Nombre"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(393, 12)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(138, 20)
        Me.TextBox4.TabIndex = 24
        '
        'lista
        '
        Me.lista.Location = New System.Drawing.Point(4, 71)
        Me.lista.Name = "lista"
        Me.lista.Size = New System.Drawing.Size(518, 365)
        Me.lista.TabIndex = 28
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.aside)
        Me.Controls.Add(Me.PlMas)
        Me.Controls.Add(Me.PlPro)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.aside.ResumeLayout(False)
        Me.PlPro.ResumeLayout(False)
        Me.PlPro.PerformLayout()
        Me.PlMas.ResumeLayout(False)
        Me.PlMas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents aside As Panel
    Friend WithEvents masPro As Button
    Friend WithEvents product As Button
    Friend WithEvents PlPro As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents lista As Panel
    Friend WithEvents PlMas As Panel
    Friend WithEvents borrar As Button
    Friend WithEvents LbProPR As Label
    Friend WithEvents LbProName As Label
    Friend WithEvents preciPro As TextBox
    Friend WithEvents NamePro As TextBox
    Friend WithEvents savePro As Button
End Class
