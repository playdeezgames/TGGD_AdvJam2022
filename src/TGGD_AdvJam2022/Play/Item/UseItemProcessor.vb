Module UseItemProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        Dim done = False
        While Not done
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Use What?[/]"}
            prompt.AddChoice(NeverMindText)
            For Each itemType In player.UsableItemTypes
                prompt.AddChoice(itemType.Name)
            Next
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
            End Select
        End While
    End Sub
End Module
