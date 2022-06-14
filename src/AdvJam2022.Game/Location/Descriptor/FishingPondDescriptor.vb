Friend Class FishingPondDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Fishing Pond"
        End Get
    End Property

    Public Overrides Function CanFish(character As Character) As Boolean
        Return character.Inventory.Items.Any(Function(x) x.CanFish)
    End Function
End Class
