﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ver1 = New System.Windows.Forms.Label()
        Me.volver = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(313, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "el resultado es:"
        '
        'ver1
        '
        Me.ver1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ver1.Font = New System.Drawing.Font("Microsoft YaHei UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ver1.Location = New System.Drawing.Point(313, 179)
        Me.ver1.Name = "ver1"
        Me.ver1.Size = New System.Drawing.Size(170, 48)
        Me.ver1.TabIndex = 1
        Me.ver1.Text = "."
        Me.ver1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'volver
        '
        Me.volver.Location = New System.Drawing.Point(364, 276)
        Me.volver.Name = "volver"
        Me.volver.Size = New System.Drawing.Size(75, 23)
        Me.volver.TabIndex = 2
        Me.volver.Text = "volver"
        Me.volver.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.volver)
        Me.Controls.Add(Me.ver1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ver1 As Label
    Friend WithEvents volver As Button
End Class
