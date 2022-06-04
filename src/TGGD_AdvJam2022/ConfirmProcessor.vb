Module ConfirmProcessor
    Function Run(text As String) As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[red]{text}[/]"}
        prompt.AddChoice(NoText)
        prompt.AddChoice(YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
End Module
