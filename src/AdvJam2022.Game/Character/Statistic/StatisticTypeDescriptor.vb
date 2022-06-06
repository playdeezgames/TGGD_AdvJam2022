Public MustInherit Class StatisticTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride Function InitialValue(characterType As CharacterType) As Long
End Class
Public Module StatisticTypeDescriptorUtility
    ReadOnly Property AllStatistics As IEnumerable(Of StatisticType)
        Get
            Return StatisticTypeDescriptors.Keys
        End Get
    End Property
    Public ReadOnly StatisticTypeDescriptors As IReadOnlyDictionary(Of StatisticType, StatisticTypeDescriptor) =
        New Dictionary(Of StatisticType, StatisticTypeDescriptor) From
        {
            {StatisticType.Health, New HealthStatisticDescriptor},
            {StatisticType.Hunger, New HungerStatisticDescriptor}
        }
End Module
