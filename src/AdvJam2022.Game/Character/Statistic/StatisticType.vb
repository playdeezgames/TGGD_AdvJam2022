Imports System.Runtime.CompilerServices

Public Enum StatisticType
    None
    Hunger
    Health
End Enum
Public Module StatisticTypeExtensions
    <Extension>
    Function Name(statisticType As StatisticType) As String
        Return StatisticTypeDescriptors(statisticType).Name
    End Function
    <Extension>
    Function InitialValue(statisticType As StatisticType, characterType As CharacterType) As Long
        Return StatisticTypeDescriptors(statisticType).InitialValue(characterType)
    End Function
    <Extension>
    Function MinimumValue(statisticType As StatisticType, characterType As CharacterType) As Long
        Return StatisticTypeDescriptors(statisticType).MinimumValue(characterType)
    End Function
End Module
