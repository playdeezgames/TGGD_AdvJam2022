Friend Class FishmongerDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Seamus the Fishmonger"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.Fishmongery
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(character As Character, builder As StringBuilder)
        builder.AppendLine($"{Name} tells you that he buys raw fish.")
    End Sub

    Public Overrides Function CanSell(character As Character) As Boolean
        Return Offers.Any(Function(x) character.HasItemType(x.Key))
    End Function

    Public Overrides ReadOnly Property Offers As IReadOnlyDictionary(Of ItemType, Long)
        Get
            Return New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.RawFish, 15}
                }
        End Get
    End Property
End Class
