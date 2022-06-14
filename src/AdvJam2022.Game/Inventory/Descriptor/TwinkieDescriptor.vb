Friend Class TwinkieDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Twinkie(R)"
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
        builder.AppendLine($"You satiate {item.HungerBenefit} hunger.")
        item.Destroy()
        SfxPlayer.Play(Sfx.HungerUp)
    End Sub

    Public Overrides ReadOnly Property HungerBenefit As Long
        Get
            Return 30
        End Get
    End Property
End Class
