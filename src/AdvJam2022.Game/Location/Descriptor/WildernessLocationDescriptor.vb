Friend Class WildernessLocationDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Wilderness"
        End Get
    End Property

    Private Shared forageTable As IReadOnlyDictionary(Of ItemType, Integer) =
        New Dictionary(Of ItemType, Integer) From
        {
            {ItemType.PlantFiber, 15},
            {ItemType.Stick, 10},
            {ItemType.Rock, 5},
            {ItemType.Berry, 5}
        }

    Public Overrides Function GenerateForage() As IEnumerable(Of ItemType)
        Return New List(Of ItemType) From {RNG.FromGenerator(forageTable)}
    End Function

    Public Overrides Function CanChopWood(character As Character) As Boolean
        Return character.HasItemType(ItemType.Axe)
    End Function

    Public Overrides Function CanBuildFire(character As Character) As Boolean
        Return character.HasItemType(ItemType.Firedrill) AndAlso character.HasItemType(ItemType.PlantFiber) AndAlso character.HasItemTypeCount(ItemType.FireWood, 5)
    End Function
End Class
