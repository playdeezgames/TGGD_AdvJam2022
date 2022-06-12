Public MustInherit Class VerbDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride Function CanCharacterPeform(character As Character) As Boolean
End Class
Friend Module VerbDescriptorUtility
    Friend ReadOnly VerbDescriptors As IReadOnlyDictionary(Of Verb, VerbDescriptor) =
        New Dictionary(Of Verb, VerbDescriptor) From
        {
            {Verb.AcceptQuest, New AcceptQuestDescriptor},
            {Verb.Deliver, New DeliverDescriptor},
            {Verb.Forage, New ForageDescriptor},
            {Verb.Prices, New PricesDescriptor},
            {Verb.Talk, New TalkDescriptor},
            {Verb.UseItem, New UseItemDescriptor}
        }
End Module