Friend Class CheaterDescriptor
    Inherits AchievementTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "CHEATER!"
        End Get
    End Property

    Public Overrides ReadOnly Property Score As Long
        Get
            Return -1000000
        End Get
    End Property

    Public Overrides Function Check(character As Character) As Boolean
        If character.Score = MaximumScore Then
            character.Achieve(AchievementType.Cheater)
            Return True
        End If
        Return False
    End Function
End Class
