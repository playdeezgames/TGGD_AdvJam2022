Friend Class DrugDealerDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Slick"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return Game.LocationType.Generic
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(player As PlayerCharacter, builder As StringBuilder)
        If CanAcceptQuest(player) Then
            builder.AppendLine($"{Name} asks if you want to make some money.")
            Return
        End If
        'TODO: make quest acceptable
        Throw New NotImplementedException
    End Sub
    Public Overrides ReadOnly Property CanAcceptQuest(character As Character) As Boolean
        Get
            Return character.GetQuestState(QuestType.DrugMule) = QuestState.None
        End Get
    End Property
    Public Overrides Sub AcceptQuest(character As Character, builder As StringBuilder)
        If Not CanAcceptQuest(character) Then
            MyBase.AcceptQuest(character, builder)
            Return
        End If
        builder.AppendLine($"{Name} gives you a small package.")
        builder.AppendLine($"{Name} tells you to give this package to {NpcType.Junkie.Name}.")
        builder.AppendLine($"{Name} tells you that you can can find {NpcType.Junkie.Name} in an alley.")
        builder.AppendLine($"{Name} tells you that {NpcType.Junkie.Name} will give you something in return, and you must bring that back to get yer money.")
        character.Inventory.Add(Item.Create(ItemType.Parcel))
        character.SetQuestState(QuestType.DrugMule, QuestState.Accepted)
    End Sub
End Class
