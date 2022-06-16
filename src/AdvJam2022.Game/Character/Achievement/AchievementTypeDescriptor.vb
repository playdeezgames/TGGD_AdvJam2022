Public MustInherit Class AchievementTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride ReadOnly Property Score As Long
    MustOverride Function Check(character As Character) As Boolean
End Class
Public Module AchievementTypeDescriptorUtility
    Public ReadOnly Property AllAchievements As IEnumerable(Of AchievementType)
        Get
            Return AchievementTypeDescriptors.Keys
        End Get
    End Property
    Friend ReadOnly AchievementTypeDescriptors As IReadOnlyDictionary(Of AchievementType, AchievementTypeDescriptor) =
        New Dictionary(Of AchievementType, AchievementTypeDescriptor) From
        {
            {AchievementType.AteRoastedTwinkie, New AteRoastedTwinkieDescriptor},
            {AchievementType.Cheater, New CheaterDescriptor},
            {AchievementType.Enabler, New EnablerDescriptor},
            {AchievementType.OverworldExploration, New OverworldExplorationDescriptor},
            {AchievementType.RecoveredGoose, New RecoveredGooseDescriptor}
        }
    Public ReadOnly Property MaximumScore As Long
        Get
            Return AchievementTypeDescriptors.Where(Function(x) x.Value.Score > 0).Sum(Function(x) x.Value.Score)
        End Get
    End Property
End Module