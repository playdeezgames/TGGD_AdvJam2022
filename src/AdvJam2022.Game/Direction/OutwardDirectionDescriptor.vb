Friend Class OutwardDirectionDescriptor
    Inherits DirectionDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Out"
        End Get
    End Property

    Public Overrides ReadOnly Property Opposite As Direction
        Get
            Return Direction.Inward
        End Get
    End Property
End Class
