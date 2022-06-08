Public MustInherit Class LocationTypeDescriptor
    MustOverride ReadOnly Property Name As String

End Class
Friend Module LocationTypeDescriptorUtility
    Public ReadOnly LocationTypeDescriptors As IReadOnlyDictionary(Of LocationType, LocationTypeDescriptor) =
        New Dictionary(Of LocationType, LocationTypeDescriptor) From
        {
            {LocationType.FooMarT, New FooMarTLocationDescriptor},
            {LocationType.Generic, New GenericLocationDescriptor},
            {LocationType.Start, New StartLocationDescriptor},
            {LocationType.Wilderness, New WildernessLocationDescriptor}
        }
End Module