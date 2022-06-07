Friend Class InwardDirectionDescriptor
    Inherits DirectionDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "In"
        End Get
    End Property

    Public Overrides ReadOnly Property Opposite As Direction
        Get
            Return Direction.Outward
        End Get
    End Property
End Class
