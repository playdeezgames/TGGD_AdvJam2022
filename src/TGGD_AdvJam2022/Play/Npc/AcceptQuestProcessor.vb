Friend Class AcceptQuestProcessor
    Friend Shared Sub Run(player As PlayerCharacter, builder As StringBuilder)
        player.AcceptQuest(builder)
    End Sub
End Class
