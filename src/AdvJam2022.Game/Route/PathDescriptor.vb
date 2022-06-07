Friend Class PathDescriptor
    Inherits RouteTypeDescriptor

    Public Overrides Function Format(direction As Direction) As String
        Return $"Path going {direction.Name}"
    End Function
End Class
