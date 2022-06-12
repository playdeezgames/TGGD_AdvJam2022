Friend Class GrocerDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Oscár"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.FooMarT
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(character As Character, builder As StringBuilder)
        builder.AppendLine($"{Name} greets you warmly.")
        builder.AppendLine($"{Name} tells you that the sign outside used to read 'FOOD MARKET' but over the years, some of the letters have gone missing.")
    End Sub

    Public Overrides Function CanBuyFrom(character As Character) As Boolean
        Return True
    End Function

    Public Overrides ReadOnly Property Prices As IReadOnlyDictionary(Of ItemType, Long)
        Get
            Return New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.WrappedTwinkie, 25}
                }
        End Get
    End Property
End Class
