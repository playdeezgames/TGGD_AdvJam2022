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
        OkProcessor.Run()
    End Sub
End Module
