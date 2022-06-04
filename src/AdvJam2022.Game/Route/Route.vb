Public Class Route
    ReadOnly Property Id As Long
    Sub New(routeId As Long)
        Id = routeId
    End Sub

    Friend Shared Function Create(fromLocation As Location, direction As Direction, toLocation As Location) As Route
        Return New Route(RouteData.Create(fromLocation.Id, direction, toLocation.Id))
    End Function
End Class
