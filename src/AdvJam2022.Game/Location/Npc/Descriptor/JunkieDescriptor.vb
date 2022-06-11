Friend Class JunkieDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Jimmy"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.DarkAlley
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(character As Character, builder As StringBuilder)
        Select Case character.GetQuestState(QuestType.DrugMule)
            Case QuestState.Delivered, QuestState.Completed
                builder.AppendLine($"{Name} is barely responsive.")
            Case Else
                builder.AppendLine($"{Name} doesn't really want to talk to you, and mostly just twitches and fidgets.")
        End Select
    End Sub
    Public Overrides ReadOnly Property CanDeliver(character As Character) As Boolean
        Get
            Return character.GetQuestState(QuestType.DrugMule) = QuestState.Accepted AndAlso character.HasItemType(ItemType.Parcel)
        End Get
    End Property
    Public Overrides Sub Deliver(character As Character, builder As StringBuilder)
        If Not CanDeliver(character) Then
            MyBase.Deliver(character, builder)
            Return
        End If
        builder.AppendLine($"{Name} takes the parcel and gives you a small bag of coins.")
        builder.AppendLine($"{Name} opens the parcel and starts eating the contents.")
        builder.AppendLine($"Fairly quickly, the parcel is empty and {Name} is in a stupor.")
        character.Inventory.ItemStacks(ItemType.Parcel).First.Destroy()
        character.Inventory.Add(Item.Create(ItemType.CoinBag))
        character.SetQuestState(QuestType.DrugMule, QuestState.Delivered)
    End Sub
End Class
