Module LoadGameProcessor
    Friend Sub Run()
        Dim filename = AnsiConsole.Ask(Of String)("[olive]Filename:[/]", String.Empty)
        If Not String.IsNullOrWhiteSpace(filename) Then
            Store.Load(filename)
            AnsiConsole.MarkupLine("[green]Game Loaded!!![/]")
            OkProcessor.Run()
            InPlayProcessor.Run(New PlayerCharacter)
            Store.ShutDown()
        End If
    End Sub
End Module
