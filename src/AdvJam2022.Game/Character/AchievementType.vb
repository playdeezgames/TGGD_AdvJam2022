Imports System.Runtime.CompilerServices

Public Enum AchievementType
    None
    OverworldExploration
End Enum
Public Module AchievementTypeExtensions
    <Extension>
    Function Name(achievementType As AchievementType) As String
        Throw New NotImplementedException
    End Function
    <Extension>
    Function Score(achievementType As AchievementType) As Long
        Throw New NotImplementedException
    End Function
End Module
