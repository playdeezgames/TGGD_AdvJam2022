Module StatusProcessor
    Friend Sub Run(player As PlayerCharacter)
        AnsiConsole.MarkupLine("[aqua]Yer Status:[/]")
        ShowAchievements(player)
        OkProcessor.Run()
    End Sub

    Private Sub ShowAchievements(player As PlayerCharacter)
        Dim achievements = player.Achievements
        If Not achievements.Any Then
            AnsiConsole.MarkupLine("[red]No Achievements[/]")
            AnsiConsole.MarkupLine("[red]Score: 0[/]")
            Return
        End If
        Dim score As Long = 0
        AnsiConsole.MarkupLine("[green]Achievements:[/]")
        For Each achievement In achievements
            score += achievement.Score
            AnsiConsole.MarkupLine($"{achievement.Name}({achievement.Score} points)")
        Next
        AnsiConsole.MarkupLine($"[green]Score: {score}[/]")
    End Sub
End Module
