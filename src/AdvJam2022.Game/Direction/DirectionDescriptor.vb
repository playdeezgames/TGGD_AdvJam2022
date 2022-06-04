Public MustInherit Class DirectionDescriptor
    MustOverride ReadOnly Property Name As String
    Overridable ReadOnly Property IsCardinal As Boolean
        Get
            Return False
        End Get
    End Property
    MustOverride ReadOnly Property Opposite As Direction
End Class
Public Module DirectionDescriptorUtility
    Friend ReadOnly DirectionDescriptors As IReadOnlyDictionary(Of Direction, DirectionDescriptor) = New Dictionary(Of Direction, DirectionDescriptor) From
        {
            {Direction.North, New NorthDirectionDescriptor},
            {Direction.East, New EastDirectionDescriptor},
            {Direction.South, New SouthDirectionDescriptor},
            {Direction.West, New WestDirectionDescriptor}
        }
    Public ReadOnly Property AllDirections As IReadOnlyList(Of Direction)
        Get
            Return DirectionDescriptors.Keys.ToList
        End Get
    End Property
    Public ReadOnly Property CardinalDirections As IReadOnlyList(Of Direction)
        Get
            Return DirectionDescriptors.Where(Function(x) x.Value.IsCardinal).Select(Function(x) x.Key).ToList
        End Get
    End Property
    Public Function ParseDirection(directionName As String) As Direction
        Return AllDirections.SingleOrDefault(Function(x) x.Name = directionName)
    End Function
End Module