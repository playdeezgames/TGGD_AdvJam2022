Friend Class BerryDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "berry"
        End Get
    End Property

    Public Overrides ReadOnly Property CanUse As Boolean
        Get
            Return True
        End Get
    End Property
End Class
