Public MustInherit Class NpcTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride ReadOnly Property LocationType As LocationType
    MustOverride ReadOnly Property Quantity As Long
    Overridable ReadOnly Property CanAcceptQuest(character As Character) As Boolean
        Get
            Return False
        End Get
    End Property
    MustOverride Sub DoTalk(character As Character, builder As StringBuilder)

    Overridable Sub AcceptQuest(character As Character, builder As StringBuilder)
        builder.AppendLine("Nothing Happens!")
    End Sub

    Overridable ReadOnly Property CanDeliver(character As Character) As Boolean
        Get
            Return False
        End Get
    End Property

    Overridable Sub Deliver(character As Character, builder As StringBuilder)
        builder.AppendLine("Nothing Happens!")
    End Sub

    Overridable Function CanSell(character As Character) As Boolean
        Return False
    End Function

    Overridable Function CanBuyFrom(character As Character) As Boolean
        Return False
    End Function

    Overridable ReadOnly Property Prices() As IReadOnlyDictionary(Of ItemType, Long)
        Get
            Return New Dictionary(Of ItemType, Long)
        End Get
    End Property

    Overridable ReadOnly Property Offers() As IReadOnlyDictionary(Of ItemType, Long)
        Get
            Return New Dictionary(Of ItemType, Long)
        End Get
    End Property

    Overridable ReadOnly Property CanGamble(character As Character) As Boolean
        Get
            Return False
        End Get
    End Property
End Class
Friend Module NpcTypeDescriptorUtility
    Friend ReadOnly NpcTypeDescriptors As IReadOnlyDictionary(Of NpcType, NpcTypeDescriptor) =
        New Dictionary(Of NpcType, NpcTypeDescriptor) From
        {
            {NpcType.BundleSeeker, New BundleSeekerDescriptor},
            {NpcType.DrugDealer, New DrugDealerDescriptor},
            {NpcType.Fishmonger, New FishmongerDescriptor},
            {NpcType.Gambler, New GamblerDescriptor},
            {NpcType.Grocer, New GrocerDescriptor},
            {NpcType.Junkie, New JunkieDescriptor}
        }
End Module
