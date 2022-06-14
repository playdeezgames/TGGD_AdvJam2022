Imports SPLORR.Game

Module FishProcessor
    ReadOnly table As IReadOnlyDictionary(Of String, Integer) =
        New Dictionary(Of String, Integer) From
        {
            {ShallowWaterText, 1},
            {DeepWaterText, 1}
        }
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        If Not player.CanFish Then
            builder.AppendLine("You cannot fish right now.")
            Return
        End If
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Where do you want to fish?[/]"}
        prompt.AddChoices(NeverMindText, ShallowWaterText, DeepWaterText)
        Dim gainFishChoice = RNG.FromGenerator(table)
        Dim breakSpearChoice = RNG.FromGenerator(table)
        Dim answer = AnsiConsole.Prompt(prompt)
        If answer = NeverMindText Then
            builder.AppendLine("You decide to try yer luck later.")
            Return
        End If
        Dim somethingHappened = False
        If answer = gainFishChoice Then
            builder.AppendLine("You catch a fish!")
            player.Inventory.Add(Item.Create(ItemType.RawFish))
            somethingHappened = True
            SfxPlayer.Play(Sfx.FishingSuccess)
        End If
        If answer = breakSpearChoice Then
            builder.AppendLine("You break yer spear!")
            player.Inventory.ItemStacks(ItemType.StoneSpear).First.Destroy()
            somethingHappened = True
            SfxPlayer.Play(Sfx.BrokenSpear)
        End If
        If Not somethingHappened Then
            builder.AppendLine("Better luck next time!")
        End If
    End Sub
End Module
