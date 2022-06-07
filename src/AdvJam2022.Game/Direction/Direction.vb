Imports System.Runtime.CompilerServices

Public Enum Direction
    None
    North
    East
    South
    West
    Inward
    Outward
End Enum
Public Module DirectionExtensions
    <Extension>
    Public Function Name(direction As Direction) As String
        Return DirectionDescriptors(direction).Name
    End Function
    <Extension>
    Function Opposite(direction As Direction) As Direction
        Return DirectionDescriptors(direction).Opposite
    End Function
End Module
