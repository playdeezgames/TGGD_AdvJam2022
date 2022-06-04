Module MainMenuProcessor
    Sub Run()
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim mainMenu As New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            mainMenu.AddChoice(NewGameText)
            mainMenu.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(mainMenu)
                Case NewGameText
                    NewGameProcessor.Run()
                Case QuitText
                    done = ConfirmProcessor.Run("Are you sure you want to quit?")
            End Select
        End While
    End Sub
End Module
