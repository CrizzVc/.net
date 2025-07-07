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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.aside = New System.Windows.Forms.Panel()
        Me.ButtonCerrar = New System.Windows.Forms.Button()
        Me.buttonAgg = New System.Windows.Forms.Button()
        Me.buttonArticulos = New System.Windows.Forms.Button()
        Me.PlPro = New System.Windows.Forms.Panel()
        Me.LabelDtaN = New System.Windows.Forms.Label()
        Me.borrar = New System.Windows.Forms.Button()
        Me.Labelid = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.lista = New System.Windows.Forms.Panel()
        Me.PlMas = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.boxdesc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BoxApellido = New System.Windows.Forms.TextBox()
        Me.BoxSerial = New System.Windows.Forms.TextBox()
        Me.LabelDesc = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BoxMarca = New System.Windows.Forms.TextBox()
        Me.LbNombreProp = New System.Windows.Forms.Label()
        Me.LbProName = New System.Windows.Forms.Label()
        Me.BoxNombre = New System.Windows.Forms.TextBox()
        Me.BoxColor = New System.Windows.Forms.TextBox()
        Me.savePro = New System.Windows.Forms.Button()
        Me.aside.SuspendLayout()
        Me.PlPro.SuspendLayout()
        Me.PlMas.SuspendLayout()
        Me.SuspendLayout()
        '
        'aside
        '
        Me.aside.AutoScroll = True
        Me.aside.AutoScrollMinSize = New System.Drawing.Size(200, 0)
        Me.aside.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.aside.Controls.Add(Me.ButtonCerrar)
        Me.aside.Controls.Add(Me.buttonAgg)
        Me.aside.Controls.Add(Me.buttonArticulos)
        Me.aside.Dock = System.Windows.Forms.DockStyle.Left
        Me.aside.Location = New System.Drawing.Point(0, 0)
        Me.aside.Name = "aside"
        Me.aside.Size = New System.Drawing.Size(201, 519)
        Me.aside.TabIndex = 19
        '
        'ButtonCerrar
        '
        Me.ButtonCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCerrar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCerrar.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.ButtonCerrar.Location = New System.Drawing.Point(0, 484)
        Me.ButtonCerrar.Name = "ButtonCerrar"
        Me.ButtonCerrar.Size = New System.Drawing.Size(201, 35)
        Me.ButtonCerrar.TabIndex = 23
        Me.ButtonCerrar.Text = "Cerrar Sesion"
        Me.ButtonCerrar.UseVisualStyleBackColor = False
        '
        'buttonAgg
        '
        Me.buttonAgg.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonAgg.FlatAppearance.BorderSize = 0
        Me.buttonAgg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.buttonAgg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.buttonAgg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonAgg.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttonAgg.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.buttonAgg.Location = New System.Drawing.Point(0, 40)
        Me.buttonAgg.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.buttonAgg.Name = "buttonAgg"
        Me.buttonAgg.Size = New System.Drawing.Size(201, 40)
        Me.buttonAgg.TabIndex = 2
        Me.buttonAgg.Text = "Agregar Articulos"
        Me.buttonAgg.UseVisualStyleBackColor = False
        '
        'buttonArticulos
        '
        Me.buttonArticulos.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonArticulos.FlatAppearance.BorderSize = 0
        Me.buttonArticulos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.buttonArticulos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.buttonArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
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
        Me.PlPro.AutoScroll = True
        Me.PlPro.BackColor = System.Drawing.Color.White
        Me.PlPro.Controls.Add(Me.LabelDtaN)
        Me.PlPro.Controls.Add(Me.borrar)
        Me.PlPro.Controls.Add(Me.Labelid)
        Me.PlPro.Controls.Add(Me.Button3)
        Me.PlPro.Controls.Add(Me.TextBox4)
        Me.PlPro.Controls.Add(Me.lista)
        Me.PlPro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlPro.Location = New System.Drawing.Point(0, 0)
        Me.PlPro.Name = "PlPro"
        Me.PlPro.Padding = New System.Windows.Forms.Padding(201, 0, 0, 0)
        Me.PlPro.Size = New System.Drawing.Size(809, 519)
        Me.PlPro.TabIndex = 20
        '
        'LabelDtaN
        '
        Me.LabelDtaN.AutoSize = True
        Me.LabelDtaN.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDtaN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.LabelDtaN.Location = New System.Drawing.Point(362, 40)
        Me.LabelDtaN.Name = "LabelDtaN"
        Me.LabelDtaN.Size = New System.Drawing.Size(17, 19)
        Me.LabelDtaN.TabIndex = 30
        Me.LabelDtaN.Text = "6"
        '
        'borrar
        '
        Me.borrar.BackColor = System.Drawing.Color.IndianRed
        Me.borrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.borrar.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.borrar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.borrar.Location = New System.Drawing.Point(713, 474)
        Me.borrar.Name = "borrar"
        Me.borrar.Size = New System.Drawing.Size(84, 33)
        Me.borrar.TabIndex = 22
        Me.borrar.Text = "Borrar"
        Me.borrar.UseVisualStyleBackColor = False
        Me.borrar.Visible = False
        '
        'Labelid
        '
        Me.Labelid.AutoSize = True
        Me.Labelid.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelid.Location = New System.Drawing.Point(218, 40)
        Me.Labelid.Name = "Labelid"
        Me.Labelid.Size = New System.Drawing.Size(138, 19)
        Me.Labelid.TabIndex = 29
        Me.Labelid.Text = "Articulos cargados:"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Button3.Location = New System.Drawing.Point(737, 17)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(48, 23)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "🔍︎"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'TextBox4
        '
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(602, 17)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(138, 23)
        Me.TextBox4.TabIndex = 24
        '
        'lista
        '
        Me.lista.AutoSize = True
        Me.lista.Location = New System.Drawing.Point(222, 74)
        Me.lista.Name = "lista"
        Me.lista.Size = New System.Drawing.Size(479, 433)
        Me.lista.TabIndex = 28
        '
        'PlMas
        '
        Me.PlMas.BackColor = System.Drawing.Color.White
        Me.PlMas.Controls.Add(Me.Label5)
        Me.PlMas.Controls.Add(Me.Label1)
        Me.PlMas.Controls.Add(Me.boxdesc)
        Me.PlMas.Controls.Add(Me.Label3)
        Me.PlMas.Controls.Add(Me.Label4)
        Me.PlMas.Controls.Add(Me.BoxApellido)
        Me.PlMas.Controls.Add(Me.BoxSerial)
        Me.PlMas.Controls.Add(Me.LabelDesc)
        Me.PlMas.Controls.Add(Me.Label2)
        Me.PlMas.Controls.Add(Me.BoxMarca)
        Me.PlMas.Controls.Add(Me.LbNombreProp)
        Me.PlMas.Controls.Add(Me.LbProName)
        Me.PlMas.Controls.Add(Me.BoxNombre)
        Me.PlMas.Controls.Add(Me.BoxColor)
        Me.PlMas.Controls.Add(Me.savePro)
        Me.PlMas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PlMas.Location = New System.Drawing.Point(0, 0)
        Me.PlMas.Name = "PlMas"
        Me.PlMas.Padding = New System.Windows.Forms.Padding(201, 0, 0, 0)
        Me.PlMas.Size = New System.Drawing.Size(809, 519)
        Me.PlMas.TabIndex = 30
        Me.PlMas.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(237, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 19)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Articulo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(237, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 19)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Propietario"
        '
        'boxdesc
        '
        Me.boxdesc.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.boxdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.boxdesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.boxdesc.Location = New System.Drawing.Point(241, 298)
        Me.boxdesc.Multiline = True
        Me.boxdesc.Name = "boxdesc"
        Me.boxdesc.Size = New System.Drawing.Size(536, 127)
        Me.boxdesc.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(435, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Apellido"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(435, 180)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Serial"
        '
        'BoxApellido
        '
        Me.BoxApellido.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BoxApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BoxApellido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxApellido.Location = New System.Drawing.Point(438, 87)
        Me.BoxApellido.Name = "BoxApellido"
        Me.BoxApellido.Size = New System.Drawing.Size(138, 20)
        Me.BoxApellido.TabIndex = 20
        '
        'BoxSerial
        '
        Me.BoxSerial.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BoxSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BoxSerial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxSerial.Location = New System.Drawing.Point(438, 196)
        Me.BoxSerial.Name = "BoxSerial"
        Me.BoxSerial.Size = New System.Drawing.Size(138, 20)
        Me.BoxSerial.TabIndex = 19
        '
        'LabelDesc
        '
        Me.LabelDesc.AutoSize = True
        Me.LabelDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.LabelDesc.Location = New System.Drawing.Point(237, 269)
        Me.LabelDesc.Name = "LabelDesc"
        Me.LabelDesc.Size = New System.Drawing.Size(63, 13)
        Me.LabelDesc.TabIndex = 18
        Me.LabelDesc.Text = "Descripción"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(241, 180)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Marca o Tipo"
        '
        'BoxMarca
        '
        Me.BoxMarca.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BoxMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BoxMarca.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxMarca.Location = New System.Drawing.Point(245, 196)
        Me.BoxMarca.Name = "BoxMarca"
        Me.BoxMarca.Size = New System.Drawing.Size(138, 20)
        Me.BoxMarca.TabIndex = 15
        '
        'LbNombreProp
        '
        Me.LbNombreProp.AutoSize = True
        Me.LbNombreProp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.LbNombreProp.Location = New System.Drawing.Point(241, 71)
        Me.LbNombreProp.Name = "LbNombreProp"
        Me.LbNombreProp.Size = New System.Drawing.Size(44, 13)
        Me.LbNombreProp.TabIndex = 14
        Me.LbNombreProp.Text = "Nombre"
        '
        'LbProName
        '
        Me.LbProName.AutoSize = True
        Me.LbProName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.LbProName.Location = New System.Drawing.Point(636, 178)
        Me.LbProName.Name = "LbProName"
        Me.LbProName.Size = New System.Drawing.Size(31, 13)
        Me.LbProName.TabIndex = 13
        Me.LbProName.Text = "Color"
        '
        'BoxNombre
        '
        Me.BoxNombre.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BoxNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxNombre.Location = New System.Drawing.Point(245, 87)
        Me.BoxNombre.Name = "BoxNombre"
        Me.BoxNombre.Size = New System.Drawing.Size(138, 20)
        Me.BoxNombre.TabIndex = 12
        '
        'BoxColor
        '
        Me.BoxColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.BoxColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BoxColor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(118, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.BoxColor.Location = New System.Drawing.Point(639, 196)
        Me.BoxColor.Name = "BoxColor"
        Me.BoxColor.Size = New System.Drawing.Size(138, 20)
        Me.BoxColor.TabIndex = 11
        '
        'savePro
        '
        Me.savePro.BackColor = System.Drawing.Color.LimeGreen
        Me.savePro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.savePro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.savePro.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.savePro.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.savePro.Location = New System.Drawing.Point(639, 457)
        Me.savePro.Name = "savePro"
        Me.savePro.Size = New System.Drawing.Size(138, 35)
        Me.savePro.TabIndex = 10
        Me.savePro.Text = "Guardar"
        Me.savePro.UseVisualStyleBackColor = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 519)
        Me.Controls.Add(Me.aside)
        Me.Controls.Add(Me.PlPro)
        Me.Controls.Add(Me.PlMas)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
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
    Friend WithEvents Labelid As Label
    Friend WithEvents Button3 As Button
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
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents BoxApellido As TextBox
    Friend WithEvents BoxSerial As TextBox
    Friend WithEvents LabelDesc As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents boxdesc As TextBox
    Friend WithEvents BoxMarca As TextBox
    Friend WithEvents LabelDtaN As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
End Class
