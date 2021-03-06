Friend Class HealthStatisticDescriptor
    Inherits StatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Health"
        End Get
    End Property

    Public Overrides Function InitialValue(characterType As CharacterType) As Long
        Select Case characterType
            Case CharacterType.Player
                Return 100
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function MinimumValue(characterType As CharacterType) As Long
        Return 0
    End Function

    Public Overrides Function MaximumValue(characterType As CharacterType) As Long
        Return InitialValue(characterType)
    End Function
End Class
