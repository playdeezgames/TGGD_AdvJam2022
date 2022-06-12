Friend Class PricesDescriptor
    Inherits VerbDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Prices"
        End Get
    End Property

    Public Overrides Function CanCharacterPeform(character As Character) As Boolean
        Return character.CanBuy
    End Function
End Class
