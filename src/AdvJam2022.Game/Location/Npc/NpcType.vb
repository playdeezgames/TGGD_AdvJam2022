Imports System.Runtime.CompilerServices

Public Enum NpcType
    None
    BundleSeeker
    Grocer
    DrugDealer
    Junkie
    Gambler
    Fishmonger
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
    Function CanSell(npcType As NpcType, character As Character) As Boolean
        Return NpcTypeDescriptors(npcType).CanSell(character)
    End Function
    <Extension>
    Function CanDeliver(npcType As NpcType, character As Character) As Boolean
        Return NpcTypeDescriptors(npcType).CanDeliver(character)
    End Function
    <Extension>
    Sub AcceptQuest(npcType As NpcType, character As Character, builder As StringBuilder)
        NpcTypeDescriptors(npcType).AcceptQuest(character, builder)
    End Sub
    <Extension>
    Sub Deliver(npcType As NpcType, character As Character, builder As StringBuilder)
        NpcTypeDescriptors(npcType).Deliver(character, builder)
    End Sub
    <Extension>
    Function CanBuyFrom(npcType As NpcType, character As Character) As Boolean
        Return NpcTypeDescriptors(npcType).CanBuyFrom(character)
    End Function
    <Extension>
    Function Prices(npcType As NpcType) As IReadOnlyDictionary(Of ItemType, Long)
        Return NpcTypeDescriptors(npcType).Prices
    End Function
    <Extension>
    Function Offers(npcType As NpcType) As IReadOnlyDictionary(Of ItemType, Long)
        Return NpcTypeDescriptors(npcType).Offers
    End Function
    <Extension>
    Function CanGamble(npcType As NpcType, character As Character) As Boolean
        Return NpcTypeDescriptors(npcType).CanGamble(character)
    End Function
End Module
