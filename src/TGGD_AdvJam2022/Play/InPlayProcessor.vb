Imports System.Text

Module InPlayProcessor
    Friend Sub Run(player As PlayerCharacter)
        Dim done = False
        Dim builder As New StringBuilder
        While Not done
            AnsiConsole.Clear()

            ShowMessagesAndAchievements(player, builder)

            If player.IsDead Then
                Dim figlet = New FigletText("Yer dead!") With {.Color = Color.Red}
                AnsiConsole.Write(figlet)
                OkProcessor.Run()
                Exit While
            End If
            DisplayNpc(player.Location)
            DisplayExits(player)
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If player.CanMove Then
                prompt.AddChoice(MoveText)
            End If
            If Not player.Inventory.IsEmpty Then
                prompt.AddChoice(InventoryText)
            End If
            For Each verb In player.PossibleVerbs
                prompt.AddChoice(verb.Name)
            Next
            prompt.AddChoice(StatusText)
            prompt.AddChoice(GameMenuText)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case GameMenuText
                    done = GameMenuProcessor.Run()
                Case StatusText
                    StatusProcessor.Run(player)
                Case MoveText
                    MoveProcessor.Run(player, builder)
                Case InventoryText
                    InventoryProcessor.Run(player)
                Case Else
                    VerbProcessor.Run(player, ParseVerb(answer), builder)
            End Select
        End While
    End Sub

    Friend Sub ShowMessagesAndAchievements(player As PlayerCharacter, builder As StringBuilder)
        DisplayStatus(player, builder.ToString)
        UpdateAchievements(player)
        builder.Clear()
    End Sub

    Private Sub DisplayNpc(location As Location)
        If location.HasNpc Then
            AnsiConsole.MarkupLine($"{location.Npc.Name} is here.")
        End If
    End Sub

    Private Sub UpdateAchievements(player As PlayerCharacter)
        Dim achieved = False
        For Each achievement In AllAchievements
            If Not player.HasAchievement(achievement) Then
                player.CheckAchievement(achievement)
                If player.HasAchievement(achievement) Then
                    achieved = True
                    AnsiConsole.MarkupLine($"[green]You have achieved {achievement.Name}![/]")
                End If
            End If
        Next
        If achieved Then
            SfxPlayer.Play(Sfx.Achievement)
        End If
    End Sub

    Private Sub DisplayExits(player As PlayerCharacter)
        AnsiConsole.MarkupLine($"Yer at {player.Location.Name}")
        If player.CanMove Then
            AnsiConsole.MarkupLine($"Exits: {String.Join(", ", player.Location.Routes.Select(Function(x) x.Value.Name))}")
        End If
    End Sub

    Private Sub DisplayStatus(player As PlayerCharacter, message As String)
        AnsiConsole.MarkupLine(message)
    End Sub
End Module
