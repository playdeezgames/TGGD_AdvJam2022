Friend Class EnablerDescriptor
    Inherits AchievementTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Enabler"
        End Get
    End Property

    Public Overrides ReadOnly Property Score As Long
        Get
            Return -5
        End Get
    End Property

    Public Overrides Function Check(character As Character) As Boolean
        Select Case character.GetQuestState(QuestType.DrugMule)
            Case QuestState.Delivered, QuestState.Completed
                character.Achieve(AchievementType.Enabler)
                Return True
            Case Else
                Return False
        End Select
    End Function
End Class
