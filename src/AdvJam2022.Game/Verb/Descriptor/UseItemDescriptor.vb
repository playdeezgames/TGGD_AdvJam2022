Friend Class UseItemDescriptor
    Inherits VerbDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Use Item..."
        End Get
    End Property

    Public Overrides Function CanCharacterPeform(character As Character) As Boolean
        Return character.UsableItemTypes.Any
    End Function
End Class
