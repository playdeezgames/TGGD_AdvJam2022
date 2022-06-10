Imports System.Runtime.CompilerServices

Public Enum NpcType
    None
    BundleSeeker
    Grocer
End Enum
Public Module NpcTypeExtensions
    <Extension>
    Function Name(npcType As NpcType) As String
        Return NpcTypeDescriptors(npcType).Name
    End Function
    <Extension>
    Sub DoTalk(npcType As NpcType, player As PlayerCharacter, builder As StringBuilder)
        NpcTypeDescriptors(npcType).DoTalk(player, builder)
    End Sub
End Module
