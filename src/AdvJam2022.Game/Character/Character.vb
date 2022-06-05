﻿Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub

    Protected Shared Function CreateCharacter(characterType As CharacterType, location As Location) As Character
        Dim result = New Character(CharacterData.Create(characterType, location.Id))
        result.Location = location
        Return result
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
            CharacterLocationData.Write(Id, value.Id)
            CharacterData.WriteLocation(Id, value.Id)
        End Set
    End Property

    ReadOnly Property Achievements As IEnumerable(Of AchievementType)
        Get
            Return CharacterAchievementData.Read(Id).Select(Function(x) CType(x, AchievementType))
        End Get
    End Property
End Class
