Imports System.Runtime.CompilerServices

Public Enum LocationType
    None
    Start
    Generic
    FooMarT
    Wilderness
    DarkAlley
    Casino
End Enum
Public Module LocationTypeExtensions
    <Extension>
    Function Name(locationType As LocationType) As String
        Return LocationTypeDescriptors(locationType).Name
    End Function
    <Extension>
    Function GenerateForage(locationType As LocationType) As IEnumerable(Of ItemType)
        Return LocationTypeDescriptors(locationType).GenerateForage().Where(Function(x) x <> ItemType.None)
    End Function
End Module
