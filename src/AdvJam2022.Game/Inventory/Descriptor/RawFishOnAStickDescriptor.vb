Friend Class RawFishOnAStickDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "raw fish on a stick"
        End Get
    End Property

    Public Overrides ReadOnly Property CanCook As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides ReadOnly Property CookingResult As ItemType?
        Get
            Return ItemType.RoastedFishOnAStick
        End Get
    End Property
End Class
