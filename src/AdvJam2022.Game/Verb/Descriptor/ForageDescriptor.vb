Friend Class ForageDescriptor
    Inherits VerbDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Forage"
        End Get
    End Property

    Public Overrides Function CanCharacterPeform(character As Character) As Boolean
        Return character.Location.LocationType = LocationType.Wilderness
    End Function
End Class
