Module NewGameProcessor
    Friend Sub Run()
        Store.Reset()
        IntroProcessor.Run()
        Dim player = World.Create()
        InPlayProcessor.Run(player)
        Store.ShutDown()
    End Sub
End Module
