Public MustInherit Class NpcTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride ReadOnly Property LocationType As LocationType
    MustOverride ReadOnly Property Quantity As Long
    MustOverride Sub DoTalk(player As PlayerCharacter, builder As StringBuilder)
End Class
Friend Module NpcTypeDescriptorUtility
    Friend ReadOnly NpcTypeDescriptors As IReadOnlyDictionary(Of NpcType, NpcTypeDescriptor) =
        New Dictionary(Of NpcType, NpcTypeDescriptor) From
        {
            {NpcType.BundleSeeker, New BundleSeekerDescriptor},
            {NpcType.Grocer, New GrocerDescriptor}
        }
End Module
