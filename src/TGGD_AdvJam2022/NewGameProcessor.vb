Module NewGameProcessor
    Friend Sub Run()
        Store.Reset()
        IntroProcessor.Run()
        Dim player = PlayerCharacter.CreatePlayerCharacter()
        InPlayProcessor.Run(player)
        Store.ShutDown()
    End Sub
End Module
