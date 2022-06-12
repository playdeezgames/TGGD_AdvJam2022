Friend Module BuyProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        If Not player.CanBuy Then
            builder.AppendLine("You cannot buy now!")
            Return
        End If
        Dim npc = player.Location.Npc
        Dim prices = npc.Prices
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]What would you like to buy?[/]"}
        prompt.AddChoice(NeverMindText)
        Dim table As New Dictionary(Of String, ItemType) From
            {
                {NeverMindText, ItemType.None}
            }
        For Each price In prices
            Dim text = $"{price.Key.Name}({price.Value} money)"
            table(text) = price.Key
            prompt.AddChoice(text)
        Next
        player.Buy(table(AnsiConsole.Prompt(prompt)), builder)
    End Sub
End Module
