Module Program
    Sub Main(args As String())
        AddHandler SfxPlayer.PlaySfx, AddressOf SfxHandler.HandleSfx
        SplashProcessor.Run()
        MainMenuProcessor.Run()
    End Sub
End Module
