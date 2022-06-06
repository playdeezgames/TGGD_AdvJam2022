Friend Class OverworldExplorationDescriptor
    Inherits AchievementTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Fully Explored Overworld"
        End Get
    End Property

    Public Overrides ReadOnly Property Score As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Function Check(character As Character) As Boolean
        If Location.FindAll(LocationType.Generic).All(Function(x) x.VisitedBy(character)) Then
            character.Achieve(AchievementType.OverworldExploration)
            Return True
        End If
        Return False
    End Function
End Class
