﻿Imports System.Runtime.CompilerServices

Public Enum LocationType
    None
    Start
    Generic
    FooMarT
    Wilderness
    DarkAlley
    Casino
    FishingPond
End Enum
Public Module LocationTypeExtensions
    <Extension>
    Function Name(locationType As LocationType) As String
        Return LocationTypeDescriptors(locationType).Name
    End Function
    <Extension>
    Function CanFish(locationType As LocationType, character As Character) As Boolean
        Return LocationTypeDescriptors(locationType).CanFish(character)
    End Function
    <Extension>
    Function GenerateForage(locationType As LocationType) As IEnumerable(Of ItemType)
        Return LocationTypeDescriptors(locationType).GenerateForage().Where(Function(x) x <> ItemType.None)
    End Function
End Module
