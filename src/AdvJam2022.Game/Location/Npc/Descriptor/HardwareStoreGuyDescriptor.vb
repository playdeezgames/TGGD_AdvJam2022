Friend Class HardwareStoreGuyDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Axel the Hardware Guy"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.HardwareStore
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(character As Character, builder As StringBuilder)
        builder.AppendLine($"{Name} invites you to peruse his selection of fine axes and cheese.")
        builder.AppendLine($"{Name} seems very proud of his store.")
    End Sub
End Class
