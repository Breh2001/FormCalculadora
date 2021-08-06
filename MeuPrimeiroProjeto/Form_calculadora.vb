Imports System.Data.OleDb
Imports System.Reflection

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

    Private Sub SetBackGroundImageBtn(sender As Object, nomeEvento As String)

        Try

            Dim nomeImagem = sender.name.ToString().Substring(3) + nomeEvento
            Debug.WriteLine(nomeImagem)
            Dim imagem = My.Resources.ResourceManager.GetObject(nomeImagem)
            If Not IsNothing(imagem) Then
                sender.BackgroundImage = imagem
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub


    Private Sub btnsOperacoes_MouseLeave(sender As Object, e As EventArgs) Handles btnSoma.MouseLeave, btnMultiplicar.MouseLeave, btnDividir.MouseLeave, btnSubtrair.MouseLeave

        SetBackGroundImageBtn(sender, nomeEvento:="MouseLeave")

    End Sub

    Private Sub btnsOperacoes_MouseHover(sender As Object, e As EventArgs) Handles btnSoma.MouseHover, btnMultiplicar.MouseHover, btnDividir.MouseHover, btnSubtrair.MouseHover, btnSoma.MouseUp, btnMultiplicar.MouseUp, btnDividir.MouseUp, btnSubtrair.MouseUp

        SetBackGroundImageBtn(sender, nomeEvento:="MouseHoverUp")

    End Sub

    Private Sub btnsOperacoes_MouseDown(sender As Object, e As EventArgs) Handles btnSoma.MouseDown, btnMultiplicar.MouseDown, btnDividir.MouseDown, btnSubtrair.MouseDown

        SetBackGroundImageBtn(sender, nomeEvento:="MouseDown")

    End Sub

#End Region

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        valor2 = txtDisplay.Text

        Dim calculaOperador As Long

        Select Case operador
            Case "+"
                calculaOperador = valor1 + valor2
            Case "-"
                calculaOperador = valor1 - valor2
            Case "*"
                calculaOperador = valor1 * valor2
            Case "/"
                If valor2 = 0 Then
                    lblExpressao.Text = ""
                    txtDisplay.Font = New Font("Arial", 12)

                    txtDisplay.Text = "Não é possível dividir por zero"
                    DesabilitarTeclado()
                    Return
                Else
                    calculaOperador = valor1 / valor2
                End If
        End Select

        txtDisplay.Text = calculaOperador

        lblExpressao.Text = valor1.ToString + operador + valor2.ToString + "="

    End Sub

    Private Sub btnSoma_Click(sender As Object, e As EventArgs) Handles btnSoma.Click

        If String.IsNullOrEmpty(txtDisplay.Text) Then Return

        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "+"
        lblExpressao.Text = valor1.ToString + operador

    End Sub

    Private Sub btnSubtrair_Click(sender As Object, e As EventArgs) Handles btnSubtrair.Click

        If String.IsNullOrEmpty(txtDisplay.Text) Then Return

        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "-"
        lblExpressao.Text = valor1.ToString + operador

    End Sub

    Private Sub btnMultiplicar_Click(sender As Object, e As EventArgs) Handles btnMultiplicar.Click

        If String.IsNullOrEmpty(txtDisplay.Text) Then Return

        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "*"
        lblExpressao.Text = valor1.ToString + operador

    End Sub

    Private Sub btnDividir_Click(sender As Object, e As EventArgs) Handles btnDividir.Click

        If String.IsNullOrEmpty(txtDisplay.Text) Then Return

        valor1 = txtDisplay.Text
        txtDisplay.Text = ""
        operador = "/"
        lblExpressao.Text = valor1.ToString + operador

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
        lblExpressao.Text = ""
        txtDisplay.Clear()
        HabilitarTeclado()

    End Sub

    Private Sub Form_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles btnSoma.KeyPress

        Select Case Keys.Enter
            Case Keys.Add
                btnSoma.PerformClick()
            Case 109
                btnSubtrair.PerformClick()
            Case 106
                btnMultiplicar.PerformClick()
            Case 111
                btnDividir.PerformClick()
        End Select

    End Sub

    Private Sub Form_calculadora_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        KeyPreview = True

    End Sub

    '--------------colocar função ao sinal de Mais---------------

    'armazenar o valor já inserido no txtDisplay

    'adicionar o + no txtDisplay

    'armazenar o segundo valor inserido no txtDisplay

    'somar os dois valores

    'apagar o texto do txtDisplay

    'colocar o valor calculado no txtDisplay

End Class