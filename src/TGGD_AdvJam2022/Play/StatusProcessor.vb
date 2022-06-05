Module StatusProcessor
    Friend Sub Run(player As PlayerCharacter)
        AnsiConsole.MarkupLine("[aqua]Yer Status:[/]")
        OkProcessor.Run()
    End Sub
End Module
