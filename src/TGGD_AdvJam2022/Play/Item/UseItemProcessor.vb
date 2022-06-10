Module UseItemProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        Dim done = False
        While Not done
            ShowMessagesAndAchievements(player, builder)

            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Use What?[/]"}
            prompt.AddChoice(NeverMindText)
            Dim itemTypes = player.UsableItemTypes
            For Each itemType In itemTypes
                prompt.AddChoice(itemType.Name)
            Next
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
                Case Else
                    Dim itemType = ParseItemType(answer)
                    player.UseItem(itemType, builder)
            End Select
        End While
    End Sub
End Module
