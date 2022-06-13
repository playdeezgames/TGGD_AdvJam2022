Imports SPLORR.Game

Friend Module GambleProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        If Not player.CanGamble Then
            builder.AppendLine("You cannot gamble now!")
            Return
        End If
        Dim done = False
        While Not done
            Dim bet = DetermineBet(player)
            If bet = 0 Then
                builder.AppendLine("You decide that is it time to 'foldem'.")
                Exit While
            End If
            PlayRound(player, bet)
            done = Not player.CanGamble
        End While
    End Sub

    Private ReadOnly Generator As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {HeadsText, 1},
            {TailsText, 1}
        }

    Private Sub PlayRound(player As PlayerCharacter, bet As Long)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Heads or Tails?[/]"}
        prompt.AddChoices(HeadsText, TailsText)
        Dim guess = AnsiConsole.Prompt(prompt)
        Dim flip = RNG.FromGenerator(Generator)
        If flip = guess Then
            AnsiConsole.MarkupLine("You win!")
            SfxPlayer.Play(Sfx.GambleWin)
            player.ChangeStatistic(StatisticType.Money, bet)
        Else
            AnsiConsole.MarkupLine("You lose!")
            SfxPlayer.Play(Sfx.GambleLose)
            player.ChangeStatistic(StatisticType.Money, -bet)
        End If
        AnsiConsole.MarkupLine($"You now have {player.GetStatistic(StatisticType.Money)} money.")
        OkProcessor.Run()
    End Sub

    Private Function DetermineBet(player As PlayerCharacter) As Long
        Do
            AnsiConsole.MarkupLine($"You have {player.GetStatistic(StatisticType.Money)} money.")
            Dim answer = AnsiConsole.Ask(Of Long)("[olive]How much do you want to bet?[/]")
            Select Case answer
                Case <= 0
                    Return 0
                Case > player.GetStatistic(StatisticType.Money)
                    AnsiConsole.MarkupLine("[red]You don't have that much![/]")
                Case Else
                    Return answer
            End Select
        Loop
    End Function
End Module
