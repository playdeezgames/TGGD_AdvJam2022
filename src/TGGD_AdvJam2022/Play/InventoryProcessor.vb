Module InventoryProcessor
    Friend Sub Run(player As PlayerCharacter)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine("Yer Inventory:")
            For Each itemStack In player.Inventory.ItemStacks
                AnsiConsole.MarkupLine($"{itemStack.Key.Name} (x{itemStack.Value.Count})")
            Next
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]What Now?[/]"}
            prompt.AddChoice(NeverMindText)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
            End Select
        End While
    End Sub
End Module
