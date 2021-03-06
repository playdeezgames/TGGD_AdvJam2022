Friend Class NorthDirectionDescriptor
    Inherits DirectionDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "North"
        End Get
    End Property

    Public Overrides ReadOnly Property IsCardinal As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property Opposite As Direction
        Get
            Return Direction.South
        End Get
    End Property
End Class
