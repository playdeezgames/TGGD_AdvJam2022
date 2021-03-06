Friend Class WestDirectionDescriptor
    Inherits DirectionDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "West"
        End Get
    End Property

    Public Overrides ReadOnly Property IsCardinal As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property Opposite As Direction
        Get
            Return Direction.East
        End Get
    End Property
End Class
