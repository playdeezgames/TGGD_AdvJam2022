Imports System.Runtime.CompilerServices

Public Enum NpcType
    None
    BundleSeeker
End Enum
Public Module NpcTypeExtensions
    <Extension>
    Function Name(npcType As NpcType) As String
        Return NpcTypeDescriptors(npcType).Name
    End Function
End Module
