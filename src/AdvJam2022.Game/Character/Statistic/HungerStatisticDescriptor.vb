﻿Friend Class HungerStatisticDescriptor
    Inherits StatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Hunger"
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
End Class
