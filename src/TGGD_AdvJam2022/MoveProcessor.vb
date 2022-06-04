﻿Imports System.Text

Module MoveProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Which Direction?[/]"}
        For Each route In player.Location.Routes
            prompt.AddChoice(route.Value.Direction.Name)
        Next
        prompt.AddChoice(NeverMindText)
        Dim direction = ParseDirection(AnsiConsole.Prompt(prompt))
        If direction = Direction.None Then
            Return
        End If
        player.Move(direction, builder)
    End Sub
End Module
