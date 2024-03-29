﻿Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class RJToggleButton
    Inherits CheckBox

    Private OnBackColor = Color.White
    Private OnToggleColor = Color.FromArgb(255, 25, 25, 25)
    Private OffBackColor = Color.Black
    Private OffToggleColor = Color.White

    Public Sub RJToogleButton(sender As Object, e As EventArgs)

        Me.MinimumSize = New Size(35, 20)
        Me.MaximumSize = New Size(35, 20)

    End Sub

    Private Function _MinimumSize() As Size
        Throw New NotImplementedException()
    End Function

    Private Function _MaximumSize() As Size
        Throw New NotImplementedException()
    End Function

    Private Function GetFigurePath() As GraphicsPath

        Dim arcSize As Integer = Me.Height - 1

        Dim leftarc As Rectangle = New Rectangle(0, 0, arcSize, arcSize)
        Dim rightarc As Rectangle = New Rectangle(Me.Width - arcSize - 2, 0, arcSize, arcSize)

        Dim path As GraphicsPath = New GraphicsPath()
        path.StartFigure()
        path.AddArc(leftarc, 90, 180)
        path.AddArc(rightarc, 270, 180)
        path.CloseFigure()

        Return path
    End Function

    'Private OnPaint As Override
    Protected Overrides Sub OnPaint(prevent As PaintEventArgs)

        Dim toggleSize As Integer = Me.Height - 5
        prevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        prevent.Graphics.Clear(Me.Parent.BackColor)

        If Me.Checked Then 'ON

            'Desenhando a Superfície de Controle
            prevent.Graphics.FillPath(New SolidBrush(OnBackColor), GetFigurePath())
            'Desenhando o Toggle
            prevent.Graphics.FillEllipse(New SolidBrush(OnToggleColor), New Rectangle(Me.Width - Me.Height + 1, 2, toggleSize, toggleSize))

        Else 'OFF

            'Desenhando a Superfície de Controle
            prevent.Graphics.FillPath(New SolidBrush(OffBackColor), GetFigurePath())
            'Desenhando o Toggle
            prevent.Graphics.FillEllipse(New SolidBrush(OffToggleColor), New Rectangle(2, 2, toggleSize, toggleSize))

        End If

    End Sub
End Class
