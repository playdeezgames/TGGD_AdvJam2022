Friend Class TalkDescriptor
    Inherits VerbDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Talk"
        End Get
    End Property

    Public Overrides Function CanCharacterPeform(character As Character) As Boolean
        Return character.Location.HasNpc
    End Function
End Class
