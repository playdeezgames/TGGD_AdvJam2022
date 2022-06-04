Imports System.Runtime.CompilerServices

Public Enum Direction
    North
    East
    South
    West
End Enum
Module DirectionExtensions
    <Extension>
    Function Name(direction As Direction) As String
        Return DirectionDescriptors(direction).Name
    End Function
    <Extension>
    Function Opposite(direction As Direction) As Direction
        Return DirectionDescriptors(direction).Opposite
    End Function
End Module
