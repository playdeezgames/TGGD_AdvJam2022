Module Program
    Sub Splash()
        Console.Title = "A Game in VB.NET About Adventure!"
        AnsiConsole.Clear()
        Dim figlet As New FigletText("A Game in VB.NET About Adventure!") With
            {
                .Alignment = Justify.Center,
                .Color = Color.Aqua
            }
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine("A production of TheGrumpyGameDev")
    End Sub
    Function ConfirmQuit() As Boolean
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[red]Are you sure you want to quit?[/]"}
        prompt.AddChoice(NoText)
        prompt.AddChoice(YesText)
        Return AnsiConsole.Prompt(prompt) = YesText
    End Function
    Sub MainMenu()
        Dim done = False
        While Not done
            Dim mainMenu As New SelectionPrompt(Of String) With {.Title = "Main Menu"}
            mainMenu.AddChoice(NewGameText)
            mainMenu.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(mainMenu)
                Case QuitText
                    done = ConfirmQuit()
            End Select
        End While
    End Sub
    Sub Main(args As String())
        Splash()
        MainMenu()
    End Sub
End Module
