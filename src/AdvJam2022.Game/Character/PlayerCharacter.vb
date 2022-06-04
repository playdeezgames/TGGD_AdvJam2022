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

End Class
