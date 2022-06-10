Friend Class MoneyStatisticDescriptor
    Inherits StatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Money"
        End Get
    End Property

    Public Overrides Function InitialValue(characterType As CharacterType) As Long
        Return 0
    End Function

    Public Overrides Function MinimumValue(characterType As CharacterType) As Long
        Return 0
    End Function

    Public Overrides Function MaximumValue(characterType As CharacterType) As Long
        Return Long.MaxValue
    End Function
End Class
