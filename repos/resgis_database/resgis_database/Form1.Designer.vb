<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.aside = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ButtonIniciar = New System.Windows.Forms.Button()
        Me.LbContra = New System.Windows.Forms.Label()
        Me.BoxContra = New System.Windows.Forms.TextBox()
        Me.LbCedula = New System.Windows.Forms.Label()
        Me.BoxCedula = New System.Windows.Forms.TextBox()
        Me.ButtonRegistrar = New System.Windows.Forms.Button()
        Me.aside.SuspendLayout()
        Me.SuspendLayout()
        '
        'aside
        '
        Me.aside.AutoScroll = True
        Me.aside.AutoScrollMinSize = New System.Drawing.Size(200, 0)
        Me.aside.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.aside.Controls.Add(Me.Button5)
        Me.aside.Dock = System.Windows.Forms.DockStyle.Left
        Me.aside.Location = New System.Drawing.Point(0, 0)
        Me.aside.Name = "aside"
        Me.aside.Size = New System.Drawing.Size(201, 521)
        Me.aside.TabIndex = 13
        '
        'Button5
        '
        Me.Button5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Font = New System.Drawing.Font("Microsoft YaHei UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button5.Location = New System.Drawing.Point(0, 0)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(201, 32)
        Me.Button5.TabIndex = 1
        Me.Button5.Text = "productos"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'ButtonIniciar
        '
        Me.ButtonIniciar.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonIniciar.Location = New System.Drawing.Point(332, 277)
        Me.ButtonIniciar.Name = "ButtonIniciar"
        Me.ButtonIniciar.Size = New System.Drawing.Size(138, 35)
        Me.ButtonIniciar.TabIndex = 21
        Me.ButtonIniciar.Text = "Iniciar Sesion"
        Me.ButtonIniciar.UseVisualStyleBackColor = True
        '
        'LbContra
        '
        Me.LbContra.AutoSize = True
        Me.LbContra.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbContra.Location = New System.Drawing.Point(315, 196)
        Me.LbContra.Name = "LbContra"
        Me.LbContra.Size = New System.Drawing.Size(91, 20)
        Me.LbContra.TabIndex = 20
        Me.LbContra.Text = "Contraseña"
        '
        'BoxContra
        '
        Me.BoxContra.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxContra.Location = New System.Drawing.Point(319, 219)
        Me.BoxContra.Name = "BoxContra"
        Me.BoxContra.Size = New System.Drawing.Size(168, 27)
        Me.BoxContra.TabIndex = 19
        '
        'LbCedula
        '
        Me.LbCedula.AutoSize = True
        Me.LbCedula.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCedula.Location = New System.Drawing.Point(315, 126)
        Me.LbCedula.Name = "LbCedula"
        Me.LbCedula.Size = New System.Drawing.Size(59, 20)
        Me.LbCedula.TabIndex = 18
        Me.LbCedula.Text = "Cedula"
        '
        'BoxCedula
        '
        Me.BoxCedula.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxCedula.Location = New System.Drawing.Point(319, 149)
        Me.BoxCedula.Name = "BoxCedula"
        Me.BoxCedula.Size = New System.Drawing.Size(168, 27)
        Me.BoxCedula.TabIndex = 16
        '
        'ButtonRegistrar
        '
        Me.ButtonRegistrar.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRegistrar.Location = New System.Drawing.Point(332, 333)
        Me.ButtonRegistrar.Name = "ButtonRegistrar"
        Me.ButtonRegistrar.Size = New System.Drawing.Size(138, 35)
        Me.ButtonRegistrar.TabIndex = 22
        Me.ButtonRegistrar.Text = "Registrar"
        Me.ButtonRegistrar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 521)
        Me.Controls.Add(Me.ButtonRegistrar)
        Me.Controls.Add(Me.ButtonIniciar)
        Me.Controls.Add(Me.LbContra)
        Me.Controls.Add(Me.BoxContra)
        Me.Controls.Add(Me.LbCedula)
        Me.Controls.Add(Me.BoxCedula)
        Me.Controls.Add(Me.aside)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.aside.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents aside As Panel
    Friend WithEvents Button5 As Button
    Friend WithEvents ButtonIniciar As Button
    Friend WithEvents LbContra As Label
    Friend WithEvents BoxContra As TextBox
    Friend WithEvents LbCedula As Label
    Friend WithEvents BoxCedula As TextBox
    Friend WithEvents ButtonRegistrar As Button
End Class
