Public MustInherit Class VerbDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride Function CanCharacterPeform(character As Character) As Boolean
End Class
Friend Module VerbDescriptorUtility
    Friend ReadOnly VerbDescriptors As IReadOnlyDictionary(Of Verb, VerbDescriptor) =
        New Dictionary(Of Verb, VerbDescriptor) From
        {
            {Verb.AcceptQuest, New AcceptQuestDescriptor},
            {Verb.BuildFire, New BuildFireDescriptor},
            {Verb.Buy, New BuyDescriptor},
            {Verb.ChopWood, New ChopWoodDescriptor},
            {Verb.Deliver, New DeliverDescriptor},
            {Verb.Fish, New FishVerbDescriptor},
            {Verb.Forage, New ForageDescriptor},
            {Verb.Gamble, New GambleDescriptor},
            {Verb.Offers, New OffersDescriptor},
            {Verb.Prices, New PricesDescriptor},
            {Verb.Sell, New SellDescriptor},
            {Verb.Talk, New TalkDescriptor},
            {Verb.UseItem, New UseItemDescriptor}
        }
End Module