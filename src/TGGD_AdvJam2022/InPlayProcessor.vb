Module InPlayProcessor
    Friend Sub Run(player As PlayerCharacter)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            DisplayStatus(player)
            DisplayExits(player)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If player.CanMove Then
                prompt.AddChoice(MoveText)
            End If
            prompt.AddChoice(GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    done = GameMenuProcessor.Run()
                Case MoveText
                    MoveProcessor.Run(player)
            End Select
        End While
    End Sub

    Private Sub DisplayExits(player As PlayerCharacter)
        If player.CanMove Then
            AnsiConsole.MarkupLine($"Exits: {String.Join(", ", player.Location.Routes.Select(Function(x) x.Key.Name))}")
        End If
    End Sub

    Private Sub DisplayStatus(player As PlayerCharacter)
        AnsiConsole.MarkupLine("Yer alive!")
    End Sub
End Module
