Module VerbProcessor
    ReadOnly table As IReadOnlyDictionary(Of Verb, Action(Of PlayerCharacter, StringBuilder)) =
        New Dictionary(Of Verb, Action(Of PlayerCharacter, StringBuilder)) From
        {
            {Verb.AcceptQuest, AddressOf AcceptQuestProcessor.Run},
            {Verb.Deliver, AddressOf DeliverProcessor.Run},
            {Verb.Forage, AddressOf ForageProcessor.Run},
            {Verb.Prices, AddressOf PricesProcessor.Run},
            {Verb.Talk, AddressOf TalkProcessor.Run},
            {Verb.UseItem, AddressOf UseItemProcessor.Run}
        }
    Friend Sub Run(player As PlayerCharacter, verb As Verb, builder As StringBuilder)
        table(verb).Invoke(player, builder)
    End Sub
End Module
