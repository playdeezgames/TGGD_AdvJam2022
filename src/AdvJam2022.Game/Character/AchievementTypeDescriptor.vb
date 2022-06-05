Public MustInherit Class AchievementTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride ReadOnly Property Score As Long
End Class
Friend Module AchievementTypeDescriptorUtility
    Friend ReadOnly AchievementTypeDescriptors As IReadOnlyDictionary(Of AchievementType, AchievementTypeDescriptor) =
        New Dictionary(Of AchievementType, AchievementTypeDescriptor) From
        {
            {AchievementType.OverworldExploration, New OverworldExplorationDescriptor}
        }
End Module