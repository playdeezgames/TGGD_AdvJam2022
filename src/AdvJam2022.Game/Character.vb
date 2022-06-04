Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub

    Protected Shared Function CreateCharacter(characterType As CharacterType) As Character
        Return New Character(CharacterData.Create(characterType))
    End Function
End Class
