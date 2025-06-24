<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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
        Me.LbCedula = New System.Windows.Forms.Label()
        Me.LbNombreU = New System.Windows.Forms.Label()
        Me.BoxCedula = New System.Windows.Forms.TextBox()
        Me.BoxUser = New System.Windows.Forms.TextBox()
        Me.savePro = New System.Windows.Forms.Button()
        Me.LbContra = New System.Windows.Forms.Label()
        Me.BoxContra = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LbCedula
        '
        Me.LbCedula.AutoSize = True
        Me.LbCedula.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbCedula.Location = New System.Drawing.Point(322, 176)
        Me.LbCedula.Name = "LbCedula"
        Me.LbCedula.Size = New System.Drawing.Size(59, 20)
        Me.LbCedula.TabIndex = 9
        Me.LbCedula.Text = "Cedula"
        '
        'LbNombreU
        '
        Me.LbNombreU.AutoSize = True
        Me.LbNombreU.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbNombreU.Location = New System.Drawing.Point(323, 110)
        Me.LbNombreU.Name = "LbNombreU"
        Me.LbNombreU.Size = New System.Drawing.Size(64, 20)
        Me.LbNombreU.TabIndex = 8
        Me.LbNombreU.Text = "Usuario"
        '
        'BoxCedula
        '
        Me.BoxCedula.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxCedula.Location = New System.Drawing.Point(326, 199)
        Me.BoxCedula.Name = "BoxCedula"
        Me.BoxCedula.Size = New System.Drawing.Size(168, 27)
        Me.BoxCedula.TabIndex = 7
        '
        'BoxUser
        '
        Me.BoxUser.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxUser.Location = New System.Drawing.Point(326, 133)
        Me.BoxUser.Name = "BoxUser"
        Me.BoxUser.Size = New System.Drawing.Size(168, 27)
        Me.BoxUser.TabIndex = 6
        '
        'savePro
        '
        Me.savePro.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.savePro.Location = New System.Drawing.Point(339, 328)
        Me.savePro.Name = "savePro"
        Me.savePro.Size = New System.Drawing.Size(138, 35)
        Me.savePro.TabIndex = 5
        Me.savePro.Text = "Registrar"
        Me.savePro.UseVisualStyleBackColor = True
        '
        'LbContra
        '
        Me.LbContra.AutoSize = True
        Me.LbContra.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbContra.Location = New System.Drawing.Point(322, 246)
        Me.LbContra.Name = "LbContra"
        Me.LbContra.Size = New System.Drawing.Size(91, 20)
        Me.LbContra.TabIndex = 11
        Me.LbContra.Text = "Contraseña"
        '
        'BoxContra
        '
        Me.BoxContra.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BoxContra.Location = New System.Drawing.Point(326, 269)
        Me.BoxContra.Name = "BoxContra"
        Me.BoxContra.Size = New System.Drawing.Size(168, 27)
        Me.BoxContra.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(339, 386)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 35)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Iniciar Sesion"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LbContra)
        Me.Controls.Add(Me.BoxContra)
        Me.Controls.Add(Me.LbCedula)
        Me.Controls.Add(Me.LbNombreU)
        Me.Controls.Add(Me.BoxCedula)
        Me.Controls.Add(Me.BoxUser)
        Me.Controls.Add(Me.savePro)
        Me.Name = "Form3"
        Me.Text = "agregar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LbCedula As Label
    Friend WithEvents LbNombreU As Label
    Friend WithEvents BoxCedula As TextBox
    Friend WithEvents BoxUser As TextBox
    Friend WithEvents savePro As Button
    Friend WithEvents LbContra As Label
    Friend WithEvents BoxContra As TextBox
    Friend WithEvents Button1 As Button
End Class
