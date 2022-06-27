﻿Friend Class GamblerDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Willie"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.Casino
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(character As Character, builder As StringBuilder)
        builder.AppendLine($"{Name} greets you.")
    End Sub

    Public Overrides ReadOnly Property CanGamble(character As Character) As Boolean
        Get
            Return character.GetStatistic(StatisticType.Money) > 0
        End Get
    End Property
End Class
