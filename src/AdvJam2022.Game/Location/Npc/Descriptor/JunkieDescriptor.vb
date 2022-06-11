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

    Public Overrides Sub DoTalk(player As PlayerCharacter, builder As StringBuilder)
        Select Case player.GetQuestState(QuestType.DrugMule)
            Case QuestState.Delivered, QuestState.Completed
                builder.AppendLine($"{Name} is barely responsive.")
            Case Else
                builder.AppendLine($"{Name} doesn't really want to talk to you, and mostly just twitches and fidgets.")
        End Select
    End Sub
End Class
