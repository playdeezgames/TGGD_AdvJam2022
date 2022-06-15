Public MustInherit Class LocationTypeDescriptor
    MustOverride ReadOnly Property Name As String

    Overridable Function GenerateForage() As IEnumerable(Of ItemType)
        Return New List(Of ItemType)
    End Function

    Overridable Function CanFish(character As Character) As Boolean
        Return False
    End Function

    Overridable Function CanChopWood(character As Character) As Boolean
        Return False
    End Function
End Class
Friend Module LocationTypeDescriptorUtility
    Public ReadOnly LocationTypeDescriptors As IReadOnlyDictionary(Of LocationType, LocationTypeDescriptor) =
        New Dictionary(Of LocationType, LocationTypeDescriptor) From
        {
            {LocationType.Casino, New CasinoDescriptor},
            {LocationType.DarkAlley, New DarkAlleyDescriptor},
            {LocationType.FishingPond, New FishingPondDescriptor},
            {LocationType.Fishmongery, New FishmongeryDescriptor},
            {LocationType.FooMarT, New FooMarTLocationDescriptor},
            {LocationType.Generic, New GenericLocationDescriptor},
            {LocationType.HardwareStore, New HardwareStoreDescriptor},
            {LocationType.Start, New StartLocationDescriptor},
            {LocationType.Wilderness, New WildernessLocationDescriptor}
        }
End Module