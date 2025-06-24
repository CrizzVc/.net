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
        Me.ButtonCerrar = New System.Windows.Forms.Button()
        Me.buttonAgg = New System.Windows.Forms.Button()
        Me.buttonArticulos = New System.Windows.Forms.Button()
        Me.PlPro = New System.Windows.Forms.Panel()
        Me.LabelSerial = New System.Windows.Forms.Label()
        Me.borrar = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Labelid = New System.Windows.Forms.Label()
        Me.LabelColor = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LabelMarca = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.lista = New System.Windows.Forms.Panel()
        Me.PlMas = New System.Windows.Forms.Panel()
        Me.LbNombreProp = New System.Windows.Forms.Label()
        Me.LbProName = New System.Windows.Forms.Label()
        Me.BoxNombre = New System.Windows.Forms.TextBox()
        Me.BoxColor = New System.Windows.Forms.TextBox()
        Me.savePro = New System.Windows.Forms.Button()
        Me.LabelDesc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BoxMarca = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BoxApellido = New System.Windows.Forms.TextBox()
        Me.BoxSerial = New System.Windows.Forms.TextBox()
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
        Me.aside.Controls.Add(Me.ButtonCerrar)
        Me.aside.Controls.Add(Me.buttonAgg)
        Me.aside.Controls.Add(Me.buttonArticulos)
        Me.aside.Dock = System.Windows.Forms.DockStyle.Left
        Me.aside.Location = New System.Drawing.Point(0, 0)
        Me.aside.Name = "aside"
        Me.aside.Size = New System.Drawing.Size(201, 450)
        Me.aside.TabIndex = 19
        '
        'ButtonCerrar
        '
        Me.ButtonCerrar.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCerrar.Location = New System.Drawing.Point(28, 403)
        Me.ButtonCerrar.Name = "ButtonCerrar"
        Me.ButtonCerrar.Size = New System.Drawing.Size(138, 35)
        Me.ButtonCerrar.TabIndex = 23
        Me.ButtonCerrar.Text = "Cerrar Sesion"
        Me.ButtonCerrar.UseVisualStyleBackColor = True
        '
        'buttonAgg
        '
        Me.buttonAgg.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonAgg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.buttonAgg.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonAgg.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonAgg.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.buttonAgg.Location = New System.Drawing.Point(0, 40)
        Me.buttonAgg.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.buttonAgg.Name = "buttonAgg"
        Me.buttonAgg.Size = New System.Drawing.Size(201, 40)
        Me.buttonAgg.TabIndex = 2
        Me.buttonAgg.Text = "Agregar Ariculos"
        Me.buttonAgg.UseVisualStyleBackColor = False
        '
        'buttonArticulos
        '
        Me.buttonArticulos.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.buttonArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttonArticulos.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonArticulos.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.buttonArticulos.Location = New System.Drawing.Point(0, 0)
        Me.buttonArticulos.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.buttonArticulos.Name = "buttonArticulos"
        Me.buttonArticulos.Size = New System.Drawing.Size(201, 40)
        Me.buttonArticulos.TabIndex = 1
        Me.buttonArticulos.Text = "Articulos"
        Me.buttonArticulos.UseVisualStyleBackColor = False
        '
        'PlPro
        '
        Me.PlPro.Controls.Add(Me.LabelSerial)
        Me.PlPro.Controls.Add(Me.borrar)
        Me.PlPro.Controls.Add(Me.Button2)
        Me.PlPro.Controls.Add(Me.Labelid)
        Me.PlPro.Controls.Add(Me.LabelColor)
        Me.PlPro.Controls.Add(Me.Button3)
        Me.PlPro.Controls.Add(Me.LabelMarca)
        Me.PlPro.Controls.Add(Me.TextBox4)
        Me.PlPro.Controls.Add(Me.lista)
        Me.PlPro.Location = New System.Drawing.Point(201, 0)
        Me.PlPro.Name = "PlPro"
        Me.PlPro.Size = New System.Drawing.Size(599, 450)
        Me.PlPro.TabIndex = 20
        '
        'LabelSerial
        '
        Me.LabelSerial.AutoSize = True
        Me.LabelSerial.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSerial.Location = New System.Drawing.Point(238, 46)
        Me.LabelSerial.Name = "LabelSerial"
        Me.LabelSerial.Size = New System.Drawing.Size(47, 19)
        Me.LabelSerial.TabIndex = 30
        Me.LabelSerial.Text = "Serial"
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
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelid.Location = New System.Drawing.Point(24, 46)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(23, 19)
        Me.Labelid.TabIndex = 29
        Me.Labelid.Text = "ID"
        '
        'LabelColor
        '
        Me.LabelColor.AutoSize = True
        Me.LabelColor.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelColor.Location = New System.Drawing.Point(163, 46)
        Me.LabelColor.Name = "LabelColor"
        Me.LabelColor.Size = New System.Drawing.Size(46, 19)
        Me.LabelColor.TabIndex = 27
        Me.LabelColor.Text = "Color"
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
        'LabelMarca
        '
        Me.LabelMarca.AutoSize = True
        Me.LabelMarca.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMarca.Location = New System.Drawing.Point(86, 46)
        Me.LabelMarca.Name = "LabelMarca"
        Me.LabelMarca.Size = New System.Drawing.Size(51, 19)
        Me.LabelMarca.TabIndex = 26
        Me.LabelMarca.Text = "Marca"
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
        'PlMas
        '
        Me.PlMas.Controls.Add(Me.Label3)
        Me.PlMas.Controls.Add(Me.Label4)
        Me.PlMas.Controls.Add(Me.BoxApellido)
        Me.PlMas.Controls.Add(Me.BoxSerial)
        Me.PlMas.Controls.Add(Me.LabelDesc)
        Me.PlMas.Controls.Add(Me.Label2)
        Me.PlMas.Controls.Add(Me.TextBox1)
        Me.PlMas.Controls.Add(Me.BoxMarca)
        Me.PlMas.Controls.Add(Me.LbNombreProp)
        Me.PlMas.Controls.Add(Me.LbProName)
        Me.PlMas.Controls.Add(Me.BoxNombre)
        Me.PlMas.Controls.Add(Me.BoxColor)
        Me.PlMas.Controls.Add(Me.savePro)
        Me.PlMas.Location = New System.Drawing.Point(201, 0)
        Me.PlMas.Name = "PlMas"
        Me.PlMas.Size = New System.Drawing.Size(599, 450)
        Me.PlMas.TabIndex = 30
        Me.PlMas.Visible = False
        '
        'LbNombreProp
        '
        Me.LbNombreProp.AutoSize = True
        Me.LbNombreProp.Location = New System.Drawing.Point(164, 102)
        Me.LbNombreProp.Name = "LbNombreProp"
        Me.LbNombreProp.Size = New System.Drawing.Size(62, 13)
        Me.LbNombreProp.TabIndex = 14
        Me.LbNombreProp.Text = "N Propitario"
        '
        'LbProName
        '
        Me.LbProName.AutoSize = True
        Me.LbProName.Location = New System.Drawing.Point(26, 34)
        Me.LbProName.Name = "LbProName"
        Me.LbProName.Size = New System.Drawing.Size(31, 13)
        Me.LbProName.TabIndex = 13
        Me.LbProName.Text = "Color"
        '
        'BoxNombre
        '
        Me.BoxNombre.Location = New System.Drawing.Point(130, 118)
        Me.BoxNombre.Name = "BoxNombre"
        Me.BoxNombre.Size = New System.Drawing.Size(138, 20)
        Me.BoxNombre.TabIndex = 12
        '
        'BoxColor
        '
        Me.BoxColor.Location = New System.Drawing.Point(29, 52)
        Me.BoxColor.Name = "BoxColor"
        Me.BoxColor.Size = New System.Drawing.Size(138, 20)
        Me.BoxColor.TabIndex = 11
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
        'LabelDesc
        '
        Me.LabelDesc.AutoSize = True
        Me.LabelDesc.Location = New System.Drawing.Point(250, 184)
        Me.LabelDesc.Name = "LabelDesc"
        Me.LabelDesc.Size = New System.Drawing.Size(63, 13)
        Me.LabelDesc.TabIndex = 18
        Me.LabelDesc.Text = "Descripcion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(215, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Marca"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(90, 200)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(390, 127)
        Me.TextBox1.TabIndex = 16
        '
        'BoxMarca
        '
        Me.BoxMarca.Location = New System.Drawing.Point(201, 52)
        Me.BoxMarca.Name = "BoxMarca"
        Me.BoxMarca.Size = New System.Drawing.Size(138, 20)
        Me.BoxMarca.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(327, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "A Propietario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(390, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Serial"
        '
        'BoxApellido
        '
        Me.BoxApellido.Location = New System.Drawing.Point(296, 118)
        Me.BoxApellido.Name = "BoxApellido"
        Me.BoxApellido.Size = New System.Drawing.Size(138, 20)
        Me.BoxApellido.TabIndex = 20
        '
        'BoxSerial
        '
        Me.BoxSerial.Location = New System.Drawing.Point(359, 52)
        Me.BoxSerial.Name = "BoxSerial"
        Me.BoxSerial.Size = New System.Drawing.Size(138, 20)
        Me.BoxSerial.TabIndex = 19
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
    Friend WithEvents buttonAgg As Button
    Friend WithEvents buttonArticulos As Button
    Friend WithEvents PlPro As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Labelid As Label
    Friend WithEvents LabelColor As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents LabelMarca As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents lista As Panel
    Friend WithEvents PlMas As Panel
    Friend WithEvents borrar As Button
    Friend WithEvents LbNombreProp As Label
    Friend WithEvents LbProName As Label
    Friend WithEvents BoxNombre As TextBox
    Friend WithEvents BoxColor As TextBox
    Friend WithEvents savePro As Button
    Friend WithEvents ButtonCerrar As Button
    Friend WithEvents LabelSerial As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BoxApellido As TextBox
    Friend WithEvents BoxSerial As TextBox
    Friend WithEvents LabelDesc As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents BoxMarca As TextBox
End Class
