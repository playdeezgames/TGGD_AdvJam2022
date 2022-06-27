Friend Class AteRoastedTwinkieDescriptor
    Inherits AchievementTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Ate Roasted Twinkie(R)"
        End Get
    End Property

    Public Overrides ReadOnly Property Score As Long
        Get
            Return 50
        End Get
    End Property

    Public Overrides Function Check(character As Character) As Boolean
        Return False
    End Function
End Class
