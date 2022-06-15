Public Class Character
    ReadOnly Property Id As Long
    Sub New(characterId As Long)
        Id = characterId
    End Sub

    ReadOnly Property PossibleVerbs As IEnumerable(Of Verb)
        Get
            Return AllVerbs.Where(Function(x) CanDoVerb(x))
        End Get
    End Property

    ReadOnly Property CanSell As Boolean
        Get
            Return Location.CanSell(Me)
        End Get
    End Property

    ReadOnly Property CanBuildFire() As Boolean
        Get
            Return Location.CanBuildFire(Me)
        End Get
    End Property

    ReadOnly Property CanChopWood() As Boolean
        Get
            Return Location.CanChopWood(Me)
        End Get
    End Property

    ReadOnly Property CanFish As Boolean
        Get
            Return Location.CanFish(Me)
        End Get
    End Property


    ReadOnly Property CanGamble As Boolean
        Get
            Return Location.CanGamble(Me)
        End Get
    End Property

    Public ReadOnly Property CanBuy() As Boolean
        Get
            Return If(Location.Npc?.CanBuyFrom(Me), False)
        End Get
    End Property

    Friend Function HasItemTypeCount(itemType As ItemType, itemCount As Integer) As Boolean
        Return Inventory.ItemCount(itemType) >= itemCount
    End Function

    Function CanDoVerb(verb As Verb) As Boolean
        Return verb.CanCharacterPerform(Me)
    End Function

    Function GetItem(itemType As ItemType) As Item
        Return Inventory.ItemStacks(ItemType.CoinBag).FirstOrDefault
    End Function

    Protected Shared Function CreateCharacter(characterType As CharacterType, location As Location) As Character
        Dim result = New Character(CharacterData.Create(characterType, location.Id)) With {
            .Location = location
        }
        Return result
    End Function

    Public Sub ChangeHunger(delta As Long)
        Dim anticipatedHunger = GetStatistic(StatisticType.Hunger) + delta
        SetStatistic(StatisticType.Hunger, anticipatedHunger)
        Dim updatedHunger = GetStatistic(StatisticType.Hunger)
        Dim overUnder = If(delta > 0 AndAlso anticipatedHunger > updatedHunger, anticipatedHunger - updatedHunger,
            If(delta < 0 AndAlso anticipatedHunger < updatedHunger, anticipatedHunger - updatedHunger, 0))
        ChangeStatistic(StatisticType.Health, overUnder)
    End Sub

    Public Sub ChangeStatistic(statisticType As StatisticType, delta As Long)
        SetStatistic(statisticType, GetStatistic(statisticType) + delta)
    End Sub

    Private Sub SetStatistic(statisticType As StatisticType, statisticValue As Long)
        statisticValue = Math.Min(Math.Max(statisticValue, statisticType.MinimumValue(CharacterType)), statisticType.MaximumValue(CharacterType))
        CharacterStatisticData.Write(Id, statisticType, statisticValue)
    End Sub

    Public ReadOnly Property Statistics As IReadOnlyDictionary(Of StatisticType, Long)
        Get
            Return AllStatistics.ToDictionary(
                Function(x) x,
                Function(x) GetStatistic(x))
        End Get
    End Property

    Friend Sub SetQuestState(questType As QuestType, questState As QuestState)
        CharacterQuestData.Write(Id, questType, questState)
    End Sub

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
            Dim temp = CharacterAchievementData.Read(Id)
            Return temp.Select(Function(x) CType(x, AchievementType))
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

    ReadOnly Property Score As Long
        Get
            Return Achievements.Sum(Function(x) x.Score)
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

    Public ReadOnly Property UsableItemTypes As IEnumerable(Of ItemType)
        Get
            Return Inventory.ItemStacks.Keys.Where(Function(x) x.CanUse)
        End Get
    End Property

    Public ReadOnly Property CanAcceptQuest As Boolean
        Get
            Return If(Location.Npc?.CanAcceptQuest(Me), False)
        End Get
    End Property

    Public ReadOnly Property CanDeliver As Boolean
        Get
            Return If(Location.Npc?.CanDeliver(Me), False)
        End Get
    End Property

    Friend Function GetQuestState(questType As QuestType) As QuestState
        Return CType(If(CharacterQuestData.Read(Id, questType), 0), QuestState)
    End Function

    Function HasItemType(itemType As ItemType) As Boolean
        Return Inventory.ItemStacks.ContainsKey(itemType)
    End Function
End Class
