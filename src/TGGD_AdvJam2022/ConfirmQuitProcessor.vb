Module ConfirmQuitProcessor
    Function Run() As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[red]Are you sure you want to quit?[/]"}
        prompt.AddChoice(NoText)
        prompt.AddChoice(YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function

End Module
