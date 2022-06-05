Friend Class OverworldExplorationDescriptor
    Inherits AchievementTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Fully Explored Overworld"
        End Get
    End Property

    Public Overrides ReadOnly Property Score As Long
        Get
            Return 1
        End Get
    End Property
End Class
