Friend Class CheeseDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "aged brie"
        End Get
    End Property

    Public Overrides ReadOnly Property CanUse As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Sub Use(item As Item, character As Character, builder As StringBuilder)
        character.ChangeHunger(item.HungerBenefit)
        builder.AppendLine($"You use the {item.Name}.")
        builder.AppendLine($"Yer lactose intolerant and suffer {item.HungerBenefit} hunger.")
        item.Destroy()
        SfxPlayer.Play(Sfx.AteCheese)
    End Sub

    Public Overrides ReadOnly Property HungerBenefit As Long
        Get
            Return -10
        End Get
    End Property
End Class
