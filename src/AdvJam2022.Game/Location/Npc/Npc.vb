Public Class Npc
    ReadOnly Property Id As Long
    Sub New(npcId As Long)
        Id = npcId
    End Sub
    ReadOnly Property Name As String
        Get
            Return NpcType.Name
        End Get
    End Property
    ReadOnly Property NpcType As NpcType
        Get
            Return CType(NpcData.ReadNpcType(Id).Value, NpcType)
        End Get
    End Property

    Public ReadOnly Property Prices As IReadOnlyDictionary(Of ItemType, Long)
        Get
            Return NpcType.Prices
        End Get
    End Property

    Public ReadOnly Property Offers As IReadOnlyDictionary(Of ItemType, Long)
        Get
            Return NpcType.Offers
        End Get
    End Property

    Friend Function CanSell(character As Character) As Boolean
        Return NpcType.CanSell(character)
    End Function

    Friend Sub Deliver(character As Character, builder As StringBuilder)
        NpcType.Deliver(character, builder)
    End Sub

    Friend Function CanBuyFrom(character As Character) As Boolean
        Return NpcType.CanBuyFrom(character)
    End Function

    Friend Sub Talk(player As PlayerCharacter, builder As StringBuilder)
        NpcType.DoTalk(player, builder)
    End Sub

    Shared Function FromId(npcId As Long) As Npc
        If npcId <> 0 Then
            Return New Npc(npcId)
        End If
        Return Nothing
    End Function

    Friend Shared Function Create(location As Location, npcType As NpcType) As Npc
        Return FromId(NpcData.Create(location.Id, npcType))
    End Function

    Friend Sub Destroy()
        NpcData.Clear(Id)
    End Sub

    Public ReadOnly Property CanAcceptQuest(character As Character) As Boolean
        Get
            Return NpcType.CanAcceptQuest(character)
        End Get
    End Property

    Friend Sub AcceptQuest(character As Character, builder As StringBuilder)
        NpcType.AcceptQuest(character, builder)
    End Sub

    Friend ReadOnly Property CanDeliver(character As Character) As Boolean
        Get
            Return NpcType.CanDeliver(character)
        End Get
    End Property

    Public ReadOnly Property CanGamble(character As Character) As Boolean
        Get
            Return NpcType.CanGamble(character)
        End Get
    End Property
End Class
