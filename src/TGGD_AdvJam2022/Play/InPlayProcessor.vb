Imports System.Text

Module InPlayProcessor
    Friend Sub Run(player As PlayerCharacter)
        Dim done = False
        Dim builder As New StringBuilder
        While Not done
            AnsiConsole.Clear()
            DisplayStatus(player, builder.ToString)
            UpdateAchievements(player)
            builder.Clear()
            DisplayExits(player)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If player.CanMove Then
                prompt.AddChoice(MoveText)
            End If
            prompt.AddChoice(StatusText)
            prompt.AddChoice(GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    done = GameMenuProcessor.Run()
                Case StatusText
                    StatusProcessor.Run(player)
                Case MoveText
                    MoveProcessor.Run(player, builder)
            End Select
        End While
    End Sub

    Private Sub UpdateAchievements(player As PlayerCharacter)
        For Each achievement In AllAchievements
            If Not player.HasAchievement(achievement) Then
                player.CheckAchievement(achievement)
                If player.HasAchievement(achievement) Then
                    AnsiConsole.MarkupLine($"[green]You have achieved {achievement.Name}![/]")
                End If
            End If
        Next
    End Sub

    Private Sub DisplayExits(player As PlayerCharacter)
        If player.CanMove Then
            AnsiConsole.MarkupLine($"Exits: {String.Join(", ", player.Location.Routes.Select(Function(x) x.Value.Name))}")
        End If
    End Sub

    Private Sub DisplayStatus(player As PlayerCharacter, message As String)
        AnsiConsole.MarkupLine(message)
    End Sub
End Module
