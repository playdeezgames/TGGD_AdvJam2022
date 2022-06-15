Module SellProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        If Not player.CanSell Then
            builder.AppendLine("You cannot sell right now.")
            Return
        End If
        Dim npc = player.Location.Npc
        Dim offers = npc.Offers.Where(Function(x) player.HasItemType(x.Key))
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]What would you like to sell?[/]"}
        prompt.AddChoice(NeverMindText)
        Dim table As New Dictionary(Of String, ItemType) From
            {
                {NeverMindText, ItemType.None}
            }
        For Each offer In offers
            Dim text = $"{offer.Key.Name}({offer.Value} money)"
            table(text) = offer.Key
            prompt.AddChoice(text)
        Next
        player.Sell(table(AnsiConsole.Prompt(prompt)), builder)
    End Sub
End Module
