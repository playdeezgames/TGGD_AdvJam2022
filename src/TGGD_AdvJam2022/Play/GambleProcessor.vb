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
        End While
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
