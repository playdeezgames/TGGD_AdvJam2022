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
            {ItemType.Rock, 5}
        }

    Public Overrides Function GenerateForage() As IEnumerable(Of ItemType)
        Return New List(Of ItemType) From {RNG.FromGenerator(forageTable)}
    End Function
End Class
