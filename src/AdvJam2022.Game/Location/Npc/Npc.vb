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
End Class
