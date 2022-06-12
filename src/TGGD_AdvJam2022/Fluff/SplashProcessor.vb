Module SplashProcessor
    Sub Run()
        Console.Title = "A Game in VB.NET About Adventure!"
        AnsiConsole.Clear()
        Dim figlet As New FigletText("A Game in VB.NET About Adventure!") With
            {
                .Alignment = Justify.Center,
                .Color = Color.Aqua
            }
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine("A production of TheGrumpyGameDev")
        AnsiConsole.WriteLine("Twinkie(R) is a registered trademark of Hostess Brands, Inc.")
        SfxPlayer.Play(Sfx.Title)
        OkProcessor.Run()
    End Sub
End Module
