Imports System.Data.OleDb

Public Class Form_calculadora
    Private Const V As String = ""
    Dim valor1 As Long
    Dim valor2 As Long
    Dim operador As String

    'Cint () -> converter para inteiro

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn0.Click

        'pegar o nome do botao pressionado
        Dim nomeBotaoClicado = sender.name
        'remover o btn do nome do botao para conseguir o numero pressionado
        Dim numeroBotao = nomeBotaoClicado.ToString.Replace("btn", "")
        'chamar a função de adicionar numero no display passando por parametro o numero pressionado
        AdicionarNumDisplay(numeroBotao)

    End Sub

    Private Sub AdicionarNumDisplay(numero As String)

        If txtDisplay.Text.Length < 12 Then
            txtDisplay.Text += numero
        End If

    End Sub

#Region "Set BackgroundImage botões"
    '-----------------------------------------btnMais-----------------------------------------'
    Private Sub btnMais_MouseHover(sender As Object, e As EventArgs) Handles btnMais.MouseHover
        btnMais.BackgroundImage = My.Resources.icons8_soma_64_branco
    End Sub

    Private Sub btnMais_MouseLeave(sender As Object, e As EventArgs) Handles btnMais.MouseLeave
        btnMais.BackgroundImage = My.Resources.icons8_soma_64
    End Sub

    Private Sub btnMais_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMais.MouseDown
        btnMais.BackgroundImage = My.Resources.icons8_soma_64_dark
    End Sub

    Private Sub btnMais_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMais.MouseUp
        btnMais.BackgroundImage = My.Resources.icons8_soma_64_branco
    End Sub

    '-----------------------------------------btnMenos-----------------------------------------'
    Private Sub btnMenos_MouseHover(sender As Object, e As EventArgs) Handles btnMenos.MouseHover
        btnMenos.BackgroundImage = My.Resources.icons8_subtração_64_branco
    End Sub

    Private Sub btnMenos_MouseLeave(sender As Object, e As EventArgs) Handles btnMenos.MouseLeave
        btnMenos.BackgroundImage = My.Resources.icons8_subtração_64
    End Sub

    Private Sub btnMenos_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMenos.MouseDown
        btnMenos.BackgroundImage = My.Resources.icons8_subtração_64_dark
    End Sub

    Private Sub btnMenos_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMenos.MouseUp
        btnMenos.BackgroundImage = My.Resources.icons8_subtração_64_branco
    End Sub

    '---------------------------------------btnMultiplicar---------------------------------------'
    Private Sub btnMultiplicar_MouseHover(sender As Object, e As EventArgs) Handles btnMultiplicar.MouseHover
        btnMultiplicar.BackgroundImage = My.Resources.icons8_multiplicação_64_branco
    End Sub

    Private Sub btnMultiplicar_MouseLeave(sender As Object, e As EventArgs) Handles btnMultiplicar.MouseLeave
        btnMultiplicar.BackgroundImage = My.Resources.icons8_multiplicação_64
    End Sub

    Private Sub btnMultiplicar_MouseDown(sender As Object, e As MouseEventArgs) Handles btnMultiplicar.MouseDown
        btnMultiplicar.BackgroundImage = My.Resources.icons8_multiplicação_64_dark
    End Sub

    Private Sub btnMultiplicar_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMultiplicar.MouseUp
        btnMultiplicar.BackgroundImage = My.Resources.icons8_multiplicação_64_branco
    End Sub
    '---------------------------------------btnDividir---------------------------------------'
    Private Sub btnDividir_MouseHover(sender As Object, e As EventArgs) Handles btnDividir.MouseHover
        btnDividir.BackgroundImage = My.Resources.icons8_dividisão_64_branco
    End Sub

    Private Sub btnDividir_MouseLeave(sender As Object, e As EventArgs) Handles btnDividir.MouseLeave
        btnDividir.BackgroundImage = My.Resources.icons8_dividisão_64
    End Sub

    Private Sub btnDividir_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDividir.MouseDown
        btnDividir.BackgroundImage = My.Resources.icons8_dividisão_64_dark
    End Sub

    Private Sub btnDividir_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDividir.MouseUp
        btnDividir.BackgroundImage = My.Resources.icons8_dividisão_64_branco
    End Sub

#End Region

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        valor2 = txtDisplay.Text

        Dim calculaSoma As Long

        Select Case operador
            Case "+"
                calculaSoma = valor1 + valor2
            Case "-"
                calculaSoma = valor1 - valor2
            Case "*"
                calculaSoma = valor1 * valor2
            Case "/"
                calculaSoma = valor1 / valor2
        End Select

        'If operador = "+" Then
        '    calculaSoma = valor1 + valor2
        'End If

        'If operador = "-" Then
        '    calculaSoma = valor1 - valor2
        'End If

        'If operador = "*" Then
        '    calculaSoma = valor1 * valor2
        'End If

        'If operador = "/" Then
        '    calculaSoma = valor1 / valor2
        'End If

        txtDisplay.Text = calculaSoma

    End Sub

    Private Sub btnMais_Click(sender As Object, e As EventArgs) Handles btnMais.Click

        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "+"
        'lblExpressao.Text = valor1.ToString + operador

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

    '--------------colocar função ao sinal de Mais---------------

    'armazenar o valor já inserido no txtDisplay

    'adicionar o + no txtDisplay

    'armazenar o segundo valor inserido no txtDisplay

    'somar os dois valores

    'apagar o texto do txtDisplay

    'colocar o valor calculado no txtDisplay

End Class