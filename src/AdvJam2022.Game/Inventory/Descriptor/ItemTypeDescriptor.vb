Public MustInherit Class ItemTypeDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Friend Module ItemTypeDescriptorUtility
    Friend ReadOnly ItemTypeDescriptors As IReadOnlyDictionary(Of ItemType, ItemTypeDescriptor) =
        New Dictionary(Of ItemType, ItemTypeDescriptor) From
        {
            {ItemType.Twinkie, New TwinkieDescriptor},
            {ItemType.WrappedTwinkie, New WrappedTwinkieDescriptor}
        }
End Module