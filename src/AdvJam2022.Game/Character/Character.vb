﻿Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub

    ReadOnly Property PossibleVerbs As IEnumerable(Of Verb)
        Get
            Return AllVerbs.Where(Function(x) CanDoVerb(x))
        End Get
    End Property

    Function CanDoVerb(verb As Verb) As Boolean
        Return verb.CanCharacterPerform(Me)
    End Function

    Protected Shared Function CreateCharacter(characterType As CharacterType, location As Location) As Character
        Dim result = New Character(CharacterData.Create(characterType, location.Id)) With {
            .Location = location
        }
        Return result
    End Function

    Public ReadOnly Property Statistics As IReadOnlyDictionary(Of StatisticType, Long)
        Get
            Return AllStatistics.ToDictionary(
                Function(x) x,
                Function(x) GetStatistic(x))
        End Get
    End Property

    ReadOnly Property CharacterType As CharacterType
        Get
            Return CType(CharacterData.ReadCharacterType(Id).Value, CharacterType)
        End Get
    End Property

    ReadOnly Property CanMove As Boolean
        Get
            Return Location.Routes.Any
        End Get
    End Property

    Friend Sub Achieve(achievementType As AchievementType)
        CharacterAchievementData.Write(Me.Id, achievementType)
    End Sub

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

    Function HasAchievement(achievement As AchievementType) As Boolean
        Return Achievements.Contains(achievement)
    End Function

    Function CheckAchievement(achievement As AchievementType) As Boolean
        Return achievement.Check(Me)
    End Function

    Function IsMinimum(statisticType As StatisticType) As Boolean
        Return GetStatistic(statisticType) = statisticType.MinimumValue(CharacterType)
    End Function

    Function GetStatistic(statisticType As StatisticType) As Long
        Return If(CharacterStatisticData.Read(Id, statisticType), statisticType.InitialValue(CharacterType))
    End Function

    ReadOnly Property IsDead As Boolean
        Get
            Return IsMinimum(StatisticType.Health)
        End Get
    End Property

    ReadOnly Property Inventory As Inventory
        Get
            Dim inventoryId As Long? = CharacterInventoryData.ReadForCharacter(Id)
            If Not inventoryId.hasValue Then
                inventoryId = InventoryData.Create()
                CharacterInventoryData.Write(Id, inventoryId.Value)
            End If
            Return New Inventory(inventoryId.Value)
        End Get
    End Property
End Class
