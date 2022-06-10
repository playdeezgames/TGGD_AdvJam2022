Friend Class GrocerDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "grocer"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.FooMarT
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(player As PlayerCharacter, builder As StringBuilder)
        builder.AppendLine($"{Name} greets you warmly.")
    End Sub
End Class
