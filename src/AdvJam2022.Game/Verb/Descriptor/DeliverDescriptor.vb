Friend Class DeliverDescriptor
    Inherits VerbDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Deliver"
        End Get
    End Property

    Public Overrides Function CanCharacterPeform(character As Character) As Boolean
        Return character.CanDeliver
    End Function
End Class
