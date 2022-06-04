Module NewGameProcessor
    Friend Sub Run()
        Store.Reset()
        Dim player = PlayerCharacter.CreatePlayerCharacter()
        InPlayProcessor.Run(player)
        Store.ShutDown()
    End Sub
End Module
