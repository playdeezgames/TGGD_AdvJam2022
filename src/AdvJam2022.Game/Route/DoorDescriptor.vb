Friend Class DoorDescriptor
    Inherits RouteTypeDescriptor

    Public Overrides Function Format(direction As Direction) As String
        Return $"Door going {direction.Name}"
    End Function
End Class
