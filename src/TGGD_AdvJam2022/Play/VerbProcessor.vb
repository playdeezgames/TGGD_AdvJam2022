Module VerbProcessor
    ReadOnly table As IReadOnlyDictionary(Of Verb, Action(Of PlayerCharacter, StringBuilder)) =
        New Dictionary(Of Verb, Action(Of PlayerCharacter, StringBuilder)) From
        {
            {Verb.Forage, AddressOf ForageProcessor.Run},
            {Verb.Talk, AddressOf TalkProcessor.Run}
        }
    Friend Sub Run(player As PlayerCharacter, verb As Verb, builder As StringBuilder)
        table(verb).Invoke(player, builder)
    End Sub
End Module
