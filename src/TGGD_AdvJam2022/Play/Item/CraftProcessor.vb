Module CraftProcessor
    Friend Sub Run(player As PlayerCharacter)
        Dim done = False
        Dim builder As New StringBuilder
        While Not done
            AnsiConsole.Clear()

            ShowMessagesAndAchievements(player, builder)

            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Craft what?[/]"}
            prompt.AddChoice(NeverMindText)
            Dim recipes = AllRecipes.Where(AddressOf player.CanCraft)
            For Each recipe In recipes
                prompt.AddChoice(recipe.Name)
            Next
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
                Case Else
                    player.Craft(recipes.Single(Function(x) x.Name = answer), builder)
            End Select
        End While
    End Sub
End Module
