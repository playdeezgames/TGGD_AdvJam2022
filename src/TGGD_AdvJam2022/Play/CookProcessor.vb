Friend Module CookProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        If Not player.CanCook Then
            builder.AppendLine("You cannot cook now!")
            Return
        End If
        Dim candidates = player.Inventory.ItemStacks.Keys.Where(Function(x) x.CanCook)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Cook What?[/]"}
        prompt.AddChoice(NeverMindText)
        Dim table = candidates.ToDictionary(Function(x) x.Name, Function(x) x)
        For Each key In table.Keys
            prompt.AddChoice(key)
        Next
        Dim answer = AnsiConsole.Prompt(prompt)
        If answer = NeverMindText Then
            Return
        End If
        Dim originalItemType = table(answer)
        Dim finalItemType = originalItemType.CookingResult.Value
        builder.AppendLine($"You cook {originalItemType.Name} into {finalItemType.Name}.")
        player.Inventory.ItemStacks(originalItemType).First.Destroy()
        player.Inventory.Add(Item.Create(finalItemType))
    End Sub
End Module
