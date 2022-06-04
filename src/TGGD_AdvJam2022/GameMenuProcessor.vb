Module GameMenuProcessor
    Friend Function Run() As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Game Menu:[/]"}
        prompt.AddChoice(ResumeGameText)
        prompt.AddChoice(AbandonGameText)
        Select Case AnsiConsole.Prompt(prompt)
            Case AbandonGameText
                Return True
            Case Else
                Return False
        End Select
    End Function
End Module
