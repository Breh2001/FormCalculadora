Imports System.Data.OleDb

Public Class Form_calculadora
    Private Const V As String = ""
    Dim valor1 As Long
    Dim valor2 As Long
    Dim operador As String

    'Cint () -> converter para inteiro'

    Private Sub AdicionarNumDisplay(numero As String)

        If txtDisplay.Text.Length < 6 Then
            txtDisplay.Text += numero
        End If

    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        AdicionarNumDisplay("1")
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        AdicionarNumDisplay("2")
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        AdicionarNumDisplay("3")
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        AdicionarNumDisplay("4")
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        AdicionarNumDisplay("5")
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        AdicionarNumDisplay("6")
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        AdicionarNumDisplay("7")
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        AdicionarNumDisplay("8")

    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        AdicionarNumDisplay("9")
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        AdicionarNumDisplay("0")
    End Sub

    '-----------------------------------------btnMais-----------------------------------------'
    Private Sub btnMais_MouseHover(sender As Object, e As EventArgs) Handles btnMais.MouseHover
        btnMais.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-soma-64-branco.png")
    End Sub

    Private Sub btnMais_MouseLeave(sender As Object, e As EventArgs) Handles btnMais.MouseLeave
        btnMais.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-soma-64.png")
    End Sub

    Private Sub btnMais_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMais.MouseDown
        btnMais.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-soma-64-dark.png")
    End Sub

    Private Sub btnMais_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMais.MouseUp
        btnMais.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-soma-64-branco.png")
    End Sub

    '-----------------------------------------btnMenos-----------------------------------------'
    Private Sub btnMenos_MouseHover(sender As Object, e As EventArgs) Handles btnMenos.MouseHover
        btnMenos.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-subtração-64-branco.png")
    End Sub

    Private Sub btnMenos_MouseLeave(sender As Object, e As EventArgs) Handles btnMenos.MouseLeave
        btnMenos.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-subtração-64.png")
    End Sub

    Private Sub btnMenos_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMenos.MouseDown
        btnMenos.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-subtração-64-dark.png")
    End Sub

    Private Sub btnMenos_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMenos.MouseUp
        btnMenos.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-subtração-64-branco.png")
    End Sub

    '---------------------------------------btnMultiplicar---------------------------------------'
    Private Sub btnMultiplicar_MouseHover(sender As Object, e As EventArgs) Handles btnMultiplicar.MouseHover
        btnMultiplicar.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-multiplicação-64-branco.png")
    End Sub

    Private Sub btnMultiplicar_MouseLeave(sender As Object, e As EventArgs) Handles btnMultiplicar.MouseLeave
        btnMultiplicar.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-multiplicação-64.png")
    End Sub

    Private Sub btnMultiplicar_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMultiplicar.MouseDown
        btnMultiplicar.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-multiplicação-64-dark.png")
    End Sub

    Private Sub btnMultiplicar_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMultiplicar.MouseUp
        btnMultiplicar.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-multiplicação-64-branco.png")
    End Sub
    '---------------------------------------btnDividir---------------------------------------'
    Private Sub btnDividir_MouseHover(sender As Object, e As EventArgs) Handles btnDividir.MouseHover
        btnDividir.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-dividisão-64-branco.png")
    End Sub

    Private Sub btnDividir_MouseLeave(sender As Object, e As EventArgs) Handles btnDividir.MouseLeave
        btnDividir.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-dividisão-64.png")
    End Sub

    Private Sub btnDividir_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDividir.MouseDown
        btnDividir.BackgroundImage = Image.FromFile("C:\Users\Brenda\Desktop\Icons 8\icons8-dividisão-64-dark.png")
    End Sub

    Private Sub btnDividir_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDividir.MouseUp
        btnDividir.BackgroundImage = My.Resources.icons8_dividisão_64_branco
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        valor2 = txtDisplay.Text

        Dim calculaSoma As Long

        If operador = "+" Then
            calculaSoma = valor1 + valor2
        End If

        If operador = "-" Then
            calculaSoma = valor1 - valor2
        End If

        If operador = "*" Then
            calculaSoma = valor1 * valor2
        End If

        If operador = "/" Then
            calculaSoma = valor1 / valor2
        End If

        txtDisplay.Text = calculaSoma

    End Sub

    Private Sub btnMais_Click(sender As Object, e As EventArgs) Handles btnMais.Click
        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "+"
    End Sub

    Private Sub btnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "-"
    End Sub

    Private Sub btnMultiplicar_Click(sender As Object, e As EventArgs) Handles btnMultiplicar.Click
        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "*"
    End Sub

    Private Sub btnDividir_Click(sender As Object, e As EventArgs) Handles btnDividir.Click
        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "/"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        txtDisplay.Text = ""
    End Sub

    Private Sub txtDisplay_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplay.KeyPress

        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) OrElse txtDisplay.Text.Length > 12 Then
            e.Handled = True
        End If

    End Sub

    '--------------colocar função ao sinal de Mais---------------'

    'armazenar o valor já inserido no txtDisplay'

    'adicionar o + no txtDisplay'

    'armazenar o segundo valor inserido no txtDisplay'

    'somar os dois valores'

    'apagar o texto do txtDisplay'

    'colocar o valor calculado no txtDisplay'

End Class