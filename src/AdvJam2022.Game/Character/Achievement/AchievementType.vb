Imports System.Runtime.CompilerServices

Public Enum AchievementType
    None
    RecoveredGoose
    OverworldExploration
    Enabler
    Cheater
    AteRoastedTwinkie
End Enum
Public Module AchievementTypeExtensions
    <Extension>
    Function Name(achievementType As AchievementType) As String
        Return AchievementTypeDescriptors(achievementType).Name
    End Function
    <Extension>
    Function Score(achievementType As AchievementType) As Long
        Return AchievementTypeDescriptors(achievementType).Score
    End Function
    <Extension>
    Function Check(achievementType As AchievementType, character As Character) As Boolean
        Return AchievementTypeDescriptors(achievementType).Check(character)
    End Function
End Module
