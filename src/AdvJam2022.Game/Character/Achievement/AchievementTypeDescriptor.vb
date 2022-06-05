Public MustInherit Class AchievementTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride ReadOnly Property Score As Long
End Class
Public Module AchievementTypeDescriptorUtility
    Friend ReadOnly AchievementTypeDescriptors As IReadOnlyDictionary(Of AchievementType, AchievementTypeDescriptor) =
        New Dictionary(Of AchievementType, AchievementTypeDescriptor) From
        {
            {AchievementType.OverworldExploration, New OverworldExplorationDescriptor},
            {AchievementType.RecoveredGoose, New RecoveredGooseDescriptor}
        }
    Public ReadOnly Property MaximumScore As Long
        Get
            Return AchievementTypeDescriptors.Sum(Function(x) x.Value.Score)
        End Get
    End Property
End Module