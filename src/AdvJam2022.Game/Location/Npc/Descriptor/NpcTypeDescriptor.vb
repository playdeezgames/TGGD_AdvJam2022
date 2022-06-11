Public MustInherit Class NpcTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride ReadOnly Property LocationType As LocationType
    MustOverride ReadOnly Property Quantity As Long
    Overridable ReadOnly Property CanAcceptQuest(character As Character) As Boolean
        Get
            Return False
        End Get
    End Property
    MustOverride Sub DoTalk(player As PlayerCharacter, builder As StringBuilder)

    Overridable Sub AcceptQuest(character As Character, builder As StringBuilder)
        builder.AppendLine("Nothing Happens!")
    End Sub
End Class
Friend Module NpcTypeDescriptorUtility
    Friend ReadOnly NpcTypeDescriptors As IReadOnlyDictionary(Of NpcType, NpcTypeDescriptor) =
        New Dictionary(Of NpcType, NpcTypeDescriptor) From
        {
            {NpcType.BundleSeeker, New BundleSeekerDescriptor},
            {NpcType.DrugDealer, New DrugDealerDescriptor},
            {NpcType.Grocer, New GrocerDescriptor},
            {NpcType.Junkie, New JunkieDescriptor}
        }
End Module
