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
End Class
