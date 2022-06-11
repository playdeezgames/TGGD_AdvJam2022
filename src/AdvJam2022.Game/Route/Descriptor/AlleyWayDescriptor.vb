Friend Class AlleyWayDescriptor
    Inherits RouteTypeDescriptor

    Public Overrides Function Format(direction As Direction) As String
        Return $"Alleyway going {direction.Name}"
    End Function
End Class
