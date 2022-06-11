Imports System.Runtime.CompilerServices

Public Enum Verb
    None
    Forage
    Talk
    UseItem
    AcceptQuest
End Enum
Public Module VerbExtensions
    <Extension>
    Function Name(verb As Verb) As String
        Return VerbDescriptors(verb).Name
    End Function
    <Extension>
    Function CanCharacterPerform(verb As Verb, character As Character) As Boolean
        Return VerbDescriptors(verb).CanCharacterPeform(character)
    End Function
    ReadOnly Property AllVerbs As IEnumerable(Of Verb)
        Get
            Return VerbDescriptors.Keys
        End Get
    End Property
    Function ParseVerb(name As String) As Verb
        Return AllVerbs.FirstOrDefault(Function(x) x.Name = name)
    End Function
End Module
