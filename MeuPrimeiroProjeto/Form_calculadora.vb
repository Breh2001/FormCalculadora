Imports System.Data.OleDb
'Imports System.Reflection

Public Class Form_calculadora
    Private Const V As String = ""

    'Dim valor1 As Long
    'Dim valor2 As Long

    Dim valorMemoria As Long?
    Dim valorNovo As Long

    Dim Concatena As Boolean
    'Se False -> número não fica ao lado do outro | Se True -> número ao lado do outro

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

        'If Concatena = False Or txtDisplay.Text.Equals("0") Then txtDisplay.Clear()
        If Concatena = False Or txtDisplay.Text.Equals("0") Then txtDisplay.Clear()

        If txtDisplay.Text.Length < 12 Then
            txtDisplay.Text += numero
            Concatena = True
        End If

    End Sub

#Region "Set BackgroundImage botões"

    'Private Sub SetBackGroundImageBtn(sender As Object, nomeEvento As String)

    '    Try

    '        Dim nomeImagem = sender.name.ToString().Substring(3) + nomeEvento
    '        Debug.WriteLine(nomeImagem)
    '        Dim imagem = My.Resources.ResourceManager.GetObject(nomeImagem)
    '        If Not IsNothing(imagem) Then
    '            sender.BackgroundImage = imagem
    '        End If

    '    Catch ex As Exception
    '        Return
    '    End Try

    'End Sub


    'Private Sub btnsOperacoes_MouseLeave(sender As Object, e As EventArgs) Handles btnSoma.MouseLeave, btnMultiplicar.MouseLeave, btnDividir.MouseLeave, btnSubtrair.MouseLeave

    '    SetBackGroundImageBtn(sender, nomeEvento:="MouseLeave")

    'End Sub

    'Private Sub btnsOperacoes_MouseHover(sender As Object, e As EventArgs) Handles btnSoma.MouseHover, btnMultiplicar.MouseHover, btnDividir.MouseHover, btnSubtrair.MouseHover, btnSoma.MouseUp, btnMultiplicar.MouseUp, btnDividir.MouseUp, btnSubtrair.MouseUp

    '    SetBackGroundImageBtn(sender, nomeEvento:="MouseHoverUp")

    'End Sub

    'Private Sub btnsOperacoes_MouseDown(sender As Object, e As EventArgs) Handles btnSoma.MouseDown, btnMultiplicar.MouseDown, btnDividir.MouseDown, btnSubtrair.MouseDown

    '    SetBackGroundImageBtn(sender, nomeEvento:="MouseDown")

    'End Sub

#End Region

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        Calcular("=")

    End Sub

    Private Sub OperacaoMatematica(operador As String)

        If String.IsNullOrEmpty(txtDisplay.Text) Then Return

        valorNovo = txtDisplay.Text

        Calcular(operador, valorNovo)

        'txtDisplay.SelectAll()

        'txtlblExpressao.Text = valorNovo.ToString + operador

    End Sub

    Private Sub Calcular(operador As String, Optional valorNovo As String = "")

        Concatena = False

        txtOperacoes.Text = txtOperacoes.Text + valorNovo + operador

        If IsNothing(valorMemoria) Then
            valorMemoria = valorNovo
        Else

            Select Case operador

                Case "+"

                    valorMemoria += valorNovo

                Case "-"

                    valorMemoria -= valorNovo

                Case "*"

                    valorMemoria *= valorNovo

                Case "/"

                    Try

                        valorMemoria /= valorNovo

                    Catch ex As DivideByZeroException

                        txtOperacoes.Text = ""
                        txtDisplay.Font = New Font("Arial", 12)

                        txtDisplay.Text = "Não é possível dividir por zero"
                        DesabilitarTeclado()
                        Exit Sub

                    End Try

            End Select

        End If

        txtDisplay.Text = valorMemoria

    End Sub

    Private Sub btnSoma_Click(sender As Object, e As EventArgs) Handles btnSoma.Click

        OperacaoMatematica("+")

    End Sub

    Private Sub btnSubtrair_Click(sender As Object, e As EventArgs) Handles btnSubtrair.Click

        OperacaoMatematica("-")

    End Sub

    Private Sub btnMultiplicar_Click(sender As Object, e As EventArgs) Handles btnMultiplicar.Click

        OperacaoMatematica("*")

    End Sub

    Private Sub btnDividir_Click(sender As Object, e As EventArgs) Handles btnDividir.Click

        OperacaoMatematica("/")

    End Sub



    Private Sub Apagar_Click(sender As Object, e As EventArgs) Handles btnApagar.Click

        Dim valorAtual = txtDisplay.Text
        'Substring remove a utilima posição
        'E atualiza a txtDisplay
        txtDisplay.Text = valorAtual.Substring(0, valorAtual.Length() - 1)

    End Sub

    Private Sub txtDisplay_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisplay.KeyPress

        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) OrElse txtDisplay.Text.Length > 12 Then
            e.Handled = True
        End If

    End Sub

    Private Sub HabilitarTeclado()

        pnlTeclado.Enabled = True
        txtDisplay.Enabled = True

    End Sub

    Private Sub DesabilitarTeclado()

        pnlTeclado.Enabled = False
        txtDisplay.Enabled = False

    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click

        txtDisplay.Font = New Font("MS UI Gothic", 27.75)
        txtOperacoes.Text = ""
        txtDisplay.Text = "0"
        valorMemoria = Nothing
        valorNovo = 0
        Concatena = True
        HabilitarTeclado()

    End Sub

    Private Sub Form_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Select Case e.KeyCode
            Case Keys.Add
                btnSoma.PerformClick()
            Case Keys.Subtract
                btnSubtrair.PerformClick()
            Case Keys.Multiply
                btnMultiplicar.PerformClick()
            Case Keys.Divide
                btnDividir.PerformClick()
            Case Keys.Enter
                btnCalcular.PerformClick()
            Case Keys.Back
                btnApagar.PerformClick()
            Case Keys.D1, Keys.NumPad1
                btn1.PerformClick()
            Case Keys.D2, Keys.NumPad2
                btn2.PerformClick()
            Case Keys.D3, Keys.NumPad3
                btn3.PerformClick()
            Case Keys.D4, Keys.NumPad4
                btn4.PerformClick()
            Case Keys.D5, Keys.NumPad5
                btn5.PerformClick()
            Case Keys.D6, Keys.NumPad6
                btn6.PerformClick()
            Case Keys.D7, Keys.NumPad7
                btn7.PerformClick()
            Case Keys.D8, Keys.NumPad8
                btn8.PerformClick()
            Case Keys.D9, Keys.NumPad9
                btn9.PerformClick()
            Case Keys.D0, Keys.NumPad0
                btn0.PerformClick()
        End Select

    End Sub

    Private Sub Form_calculadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Concatena = True

        valorMemoria = Nothing

    End Sub

    '--------------colocar função ao sinal de Mais---------------

    'armazenar o valor já inserido no txtDisplay

    'adicionar o + no txtDisplay

    'armazenar o segundo valor inserido no txtDisplay

    'somar os dois valores

    'apagar o texto do txtDisplay

    'colocar o valor calculado no txtDisplay

End Class