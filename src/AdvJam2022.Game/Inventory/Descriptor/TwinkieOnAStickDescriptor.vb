Friend Class TwinkieOnAStickDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Twinkie(R) on a stick"
        End Get
    End Property

    Public Overrides ReadOnly Property CanCook As Boolean
        Get
            Return True
        End Get
    End Property
End Class
