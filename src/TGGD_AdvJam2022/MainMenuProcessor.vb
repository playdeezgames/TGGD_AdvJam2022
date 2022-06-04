Module MainMenuProcessor
    Sub Run()
        Dim done = False
        While Not done
            Dim mainMenu As New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            mainMenu.AddChoice(NewGameText)
            mainMenu.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(mainMenu)
                Case NewGameText
                    NewGameProcessor.Run()
                Case QuitText
                    done = ConfirmQuitProcessor.Run()
            End Select
        End While
    End Sub
End Module
