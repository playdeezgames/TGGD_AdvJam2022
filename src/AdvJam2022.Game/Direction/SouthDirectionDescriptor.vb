Friend Class SouthDirectionDescriptor
    Inherits DirectionDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "South"
        End Get
    End Property

    Public Overrides ReadOnly Property IsCardinal As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property Opposite As Direction
        Get
            Return Direction.North
        End Get
    End Property
End Class
