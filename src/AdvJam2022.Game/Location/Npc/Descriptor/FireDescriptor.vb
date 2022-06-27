Friend Class FireDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "a cooking fire"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.None
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 0
        End Get
    End Property

    Public Overrides Sub DoTalk(character As Character, builder As StringBuilder)
        builder.AppendLine($"{Name} is not a good conversationalist (you thought the Axe was dull....)")
    End Sub

    Public Overrides ReadOnly Property CanCook(character As Character) As Boolean
        Get
            Return character.Inventory.Items.Any(Function(x) x.CanCook)
        End Get
    End Property
End Class
