Public Class Npc
    ReadOnly Property Id As Long
    Sub New(npcId As Long)
        Id = npcId
    End Sub
    Shared Function FromId(npcId As Long?) As Npc
        If npcId.HasValue Then
            Return New Npc(npcId.Value)
        End If
        Return Nothing
    End Function
End Class
