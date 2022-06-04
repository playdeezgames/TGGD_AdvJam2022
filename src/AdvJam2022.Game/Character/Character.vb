Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub

    Protected Shared Function CreateCharacter(characterType As CharacterType, location As Location) As Character
        Return New Character(CharacterData.Create(characterType, location.Id))
    End Function

    ReadOnly Property CanMove As Boolean
        Get
            Return Location.Routes.Any
        End Get
    End Property

    Function CanMoveDirection(direction As Direction) As Boolean
        Return Location.Routes.ContainsKey(direction)
    End Function

    Property Location As Location
        Get
            Return New Location(CharacterData.ReadLocation(Id).Value)
        End Get
        Set(value As Location)
            CharacterData.WriteLocation(Id, value.Id)
        End Set
    End Property
End Class
