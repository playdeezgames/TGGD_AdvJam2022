Public Module World
    Const LocationCount As Integer = 24
    Function Create() As PlayerCharacter
        Dim locations As New List(Of Location) From
            {
                Location.Create(LocationType.Start)
            }
        While locations.LongCount < LocationCount
            locations.Add(Location.Create(LocationType.Generic))
        End While
        For locationIndex = 0 To locations.Count - 1
            Dim firstLocation = locations(locationIndex)
            Dim secondLocation = locations((locationIndex + 1) Mod LocationCount)
            Dim direction = RNG.FromEnumerable(CardinalDirections)
            While firstLocation.HasRoute(direction)
                direction = RNG.FromEnumerable(CardinalDirections)
            End While
            Route.Create(firstLocation, direction, secondLocation, RouteType.Road)
            Route.Create(secondLocation, direction.Opposite, firstLocation, RouteType.Road)
        Next
        Dim player = PlayerCharacter.CreatePlayerCharacter(locations.First)
        Return player
    End Function
End Module
