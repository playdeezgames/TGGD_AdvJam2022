Public MustInherit Class NpcTypeDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Friend Module NpcTypeDescriptorUtility
    Friend ReadOnly NpcTypeDescriptors As IReadOnlyDictionary(Of NpcType, NpcTypeDescriptor) =
        New Dictionary(Of NpcType, NpcTypeDescriptor) From
        {
            {NpcType.BundleSeeker, New BundleSeekerDescriptor}
        }
End Module
