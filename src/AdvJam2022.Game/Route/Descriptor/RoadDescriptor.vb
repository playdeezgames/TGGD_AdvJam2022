Friend Class RoadDescriptor
    Inherits RouteTypeDescriptor

    Public Overrides Function Format(direction As Direction) As String
        Return $"Road going {direction.Name}"
    End Function
End Class
