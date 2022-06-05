Friend Class RecoveredGooseDescriptor
    Inherits AchievementTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Recovered Lost Goose"
        End Get
    End Property

    Public Overrides ReadOnly Property Score As Long
        Get
            Return 10
        End Get
    End Property
End Class
