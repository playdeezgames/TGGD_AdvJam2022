Imports System

Module Program
    Sub Main(args As String())
        Console.Title = "A Game in VB.NET About Adventure!"
        Dim figlet As New FigletText("A Game in VB.NET About Adventure!") With
            {
                .Alignment = Justify.Center,
                .Color = Color.Aqua
            }
        AnsiConsole.Write(figlet)
        AnsiConsole.WriteLine("A production of TheGrumpyGameDev")

        Dim done = False
        While Not done
            Dim mainMenu As New SelectionPrompt(Of String) With {.Title = ""}
            mainMenu.AddChoice(QuitText)
            Select Case AnsiConsole.Prompt(mainMenu)
                Case QuitText
                    done = True
            End Select
        End While
    End Sub
End Module
