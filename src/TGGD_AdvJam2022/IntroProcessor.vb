Module IntroProcessor
    Sub Run()
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("Yer a goose handler, and yer prize goose has run away!")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine("If you don't find yer goose and bring it back, you won't be able to win the blue ribbon at the fair.")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine("And if you don't win the blue ribbon... then what is life even about?")
        OkProcessor.Run()
    End Sub
End Module
