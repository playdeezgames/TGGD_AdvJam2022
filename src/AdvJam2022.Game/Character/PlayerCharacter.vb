Public Class PlayerCharacter
    Inherits Character
    Sub New()
        MyBase.New(CharacterData.ReadForCharacterType(CharacterType.Player).Single)
    End Sub

    Public Shared Function CreatePlayerCharacter(location As Location) As PlayerCharacter
        CharacterData.ClearForCharacterType(CharacterType.Player)
        Character.CreateCharacter(CharacterType.Player, location)
        Return New PlayerCharacter()
    End Function
    Public Sub Move(direction As Direction, builder As StringBuilder)
        If Not CanMoveDirection(direction) Then
            builder.AppendLine($"You cannot go {direction.Name}.")
            Return
        End If
        Location = Location.Routes(direction).ToLocation
        builder.AppendLine($"You go {direction.Name}.")
    End Sub

End Class
