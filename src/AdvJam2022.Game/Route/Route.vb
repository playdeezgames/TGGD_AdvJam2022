Public Class Route
    ReadOnly Property Id As Long
    Sub New(routeId As Long)
        Id = routeId
    End Sub

    Friend Shared Function Create(fromLocation As Location, direction As Direction, toLocation As Location) As Route
        Return New Route(RouteData.Create(fromLocation.Id, direction, toLocation.Id))
    End Function

    ReadOnly Property Direction As Direction
        Get
            Return CType(RouteData.ReadDirection(Id).Value, Direction)
        End Get
    End Property

    ReadOnly Property ToLocation As Location
        Get
            Return New Location(RouteData.ReadToLocation(Id).Value)
        End Get
    End Property
End Class
