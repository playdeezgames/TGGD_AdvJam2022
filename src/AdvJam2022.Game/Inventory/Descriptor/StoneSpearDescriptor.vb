Friend Class StoneSpearDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "stone spear"
        End Get
    End Property
    Public Overrides ReadOnly Property CanFish As Boolean
        Get
            Return True
        End Get
    End Property
End Class
