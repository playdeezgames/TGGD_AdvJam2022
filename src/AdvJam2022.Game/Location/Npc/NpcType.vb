Imports System.Runtime.CompilerServices

Public Enum NpcType
    None
    BundleSeeker
    Grocer
    DrugDealer
    Junkie
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
    <Extension>
    Function CanAcceptQuest(npcType As NpcType, character As Character) As Boolean
        Return NpcTypeDescriptors(npcType).CanAcceptQuest(character)
    End Function
    <Extension>
    Sub AcceptQuest(npcType As NpcType, character As Character, builder As StringBuilder)
        NpcTypeDescriptors(npcType).AcceptQuest(character, builder)
    End Sub
End Module
