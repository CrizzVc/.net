Imports System
Imports System.Net.Security

Module Program
    Sub Main(args As String())

        Dim nota1 As Double
        Dim nota2 As Double
        Dim nota3 As Double
        Dim nota4 As Double
        Dim suma As Double
        Dim resul As Double

        Console.WriteLine("ingrese nota 1")
        nota1 = Console.ReadLine()
        Console.WriteLine("ingrese nota 2")
        nota2 = Console.ReadLine()
        Console.WriteLine("ingrese nota 3")
        nota3 = Console.ReadLine()
        Console.WriteLine("ingrese nota 4")
        nota4 = Console.ReadLine()

        suma = nota1 + nota2 + nota3 + nota4
        resul = suma / 4

        Console.Write("su promedio es: ")
        Console.WriteLine(resul)

        If resul < 6 And resul > 3 Then
            Console.WriteLine("usted perdio la materia")
        ElseIf resul > 6 And resul < 7 Then
            Console.WriteLine("usted apenas paso la materia")
        ElseIf resul = 8 And resul <= 9 Then
            Console.WriteLine("usted ganó la materia")
        ElseIf resul = 10 Then
            Console.WriteLine("usted tiene un desempeño exelente")
        ElseIf resul < 3 Then
            Console.WriteLine("usted venia a ver a las pelaitas")
        End If

        '----------------calculadora--------------------

        'Dim num1 As Integer
        'Dim num2 As Integer
        'Dim oper As Double
        'Dim selec As String

        'Console.WriteLine("elige una operacion")
        'Console.WriteLine("|-|+|/|^|")

        'selec = Console.ReadLine()
        'If selec = " " Then
        '    Console.WriteLine("no se agrego un a operación")
        'End If


        'If selec = "/" Then
        '    Console.WriteLine("ingrese un número")
        '    num1 = Console.ReadLine()
        '    Console.WriteLine("ingrese un segundo número")
        '    num2 = Console.ReadLine()
        '    oper = num1 / num2
        '    Console.WriteLine("el resultado es:")
        '    Console.WriteLine(oper)
        '    Console.ReadKey()

        'ElseIf selec = "-" Then
        '    Console.WriteLine("ingrese un número")
        '    num1 = Console.ReadLine()
        '    Console.WriteLine("ingrese un segundo número")
        '    num2 = Console.ReadLine()
        '    oper = num1 - num2
        '    Console.WriteLine("el resultado es:")
        '    Console.WriteLine(oper)
        '    Console.ReadKey()

        'ElseIf selec = "+" Then
        '    Console.WriteLine("ingrese un número")
        '    num1 = Console.ReadLine()
        '    Console.WriteLine("ingrese un segundo número")
        '    num2 = Console.ReadLine()
        '    oper = num1 + num2
        '    Console.WriteLine("el resultado es:")
        '    Console.WriteLine(oper)
        '    Console.ReadKey()

        'ElseIf selec = "^" Then
        '    Console.WriteLine("ingrese un número")
        '    num1 = Console.ReadLine()
        '    Console.WriteLine("ingrese un segundo número")
        '    num2 = Console.ReadLine()
        '    oper = num1 ^ num2
        '    Console.WriteLine("el resultado es:")
        '    Console.WriteLine(oper)
        '    Console.ReadKey()

        'End If

    End Sub
End Module
