Module SaveGameProcessor
    Friend Sub Run()
        Dim filename = AnsiConsole.Ask(Of String)("[olive]Save Game Filename:[/]", String.Empty)
        If Not String.IsNullOrWhiteSpace(filename) Then
            Store.Save(filename)
            AnsiConsole.MarkupLine("[green]Game Saved!!![/]")
            OkProcessor.Run()
        End If
    End Sub
End Module
