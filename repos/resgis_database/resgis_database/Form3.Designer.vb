<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.LbProPR = New System.Windows.Forms.Label()
        Me.LbProName = New System.Windows.Forms.Label()
        Me.preciPro = New System.Windows.Forms.TextBox()
        Me.NamePro = New System.Windows.Forms.TextBox()
        Me.savePro = New System.Windows.Forms.Button()
        Me.aside = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.aside.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbProPR
        '
        Me.LbProPR.AutoSize = True
        Me.LbProPR.Location = New System.Drawing.Point(242, 122)
        Me.LbProPR.Name = "LbProPR"
        Me.LbProPR.Size = New System.Drawing.Size(36, 13)
        Me.LbProPR.TabIndex = 9
        Me.LbProPR.Text = "precio"
        '
        'LbProName
        '
        Me.LbProName.AutoSize = True
        Me.LbProName.Location = New System.Drawing.Point(242, 56)
        Me.LbProName.Name = "LbProName"
        Me.LbProName.Size = New System.Drawing.Size(44, 13)
        Me.LbProName.TabIndex = 8
        Me.LbProName.Text = "Nombre"
        '
        'preciPro
        '
        Me.preciPro.Location = New System.Drawing.Point(245, 138)
        Me.preciPro.Name = "preciPro"
        Me.preciPro.Size = New System.Drawing.Size(138, 20)
        Me.preciPro.TabIndex = 7
        '
        'NamePro
        '
        Me.NamePro.Location = New System.Drawing.Point(245, 72)
        Me.NamePro.Name = "NamePro"
        Me.NamePro.Size = New System.Drawing.Size(138, 20)
        Me.NamePro.TabIndex = 6
        '
        'savePro
        '
        Me.savePro.Location = New System.Drawing.Point(650, 403)
        Me.savePro.Name = "savePro"
        Me.savePro.Size = New System.Drawing.Size(138, 35)
        Me.savePro.TabIndex = 5
        Me.savePro.Text = "Guardar"
        Me.savePro.UseVisualStyleBackColor = True
        '
        'aside
        '
        Me.aside.AutoScroll = True
        Me.aside.AutoScrollMinSize = New System.Drawing.Size(200, 0)
        Me.aside.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.aside.Controls.Add(Me.Button6)
        Me.aside.Controls.Add(Me.Button5)
        Me.aside.Controls.Add(Me.Button4)
        Me.aside.Dock = System.Windows.Forms.DockStyle.Left
        Me.aside.Location = New System.Drawing.Point(0, 0)
        Me.aside.Name = "aside"
        Me.aside.Size = New System.Drawing.Size(201, 450)
        Me.aside.TabIndex = 14
        '
        'Button6
        '
        Me.Button6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button6.Location = New System.Drawing.Point(0, 71)
        Me.Button6.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(201, 32)
        Me.Button6.TabIndex = 2
        Me.Button6.Text = "agregar producto"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button5.Location = New System.Drawing.Point(0, 39)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(201, 32)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "productos"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button4.Location = New System.Drawing.Point(0, 0)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(201, 39)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Inicio"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.aside)
        Me.Controls.Add(Me.LbProPR)
        Me.Controls.Add(Me.LbProName)
        Me.Controls.Add(Me.preciPro)
        Me.Controls.Add(Me.NamePro)
        Me.Controls.Add(Me.savePro)
        Me.Name = "Form3"
        Me.Text = "agregar"
        Me.aside.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LbProPR As Label
    Friend WithEvents LbProName As Label
    Friend WithEvents preciPro As TextBox
    Friend WithEvents NamePro As TextBox
    Friend WithEvents savePro As Button
    Friend WithEvents aside As Panel
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
End Class
