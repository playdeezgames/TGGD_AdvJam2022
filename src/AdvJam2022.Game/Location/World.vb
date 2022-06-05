Public Module World
    Const LocationCount As Integer = 24
    Function Create() As PlayerCharacter
        CreateOverworld()
        Return CreatePlayer()
    End Function

    Private Sub CreateOverworld()
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
            While firstLocation.HasRoute(direction) OrElse secondLocation.HasRoute(direction.Opposite)
                direction = RNG.FromEnumerable(CardinalDirections)
            End While
            Route.Create(firstLocation, direction, secondLocation, RouteType.Road)
            Route.Create(secondLocation, direction.Opposite, firstLocation, RouteType.Road)
        Next
    End Sub

    Private Function CreatePlayer() As PlayerCharacter
        Return PlayerCharacter.CreatePlayerCharacter(Location.FindAll(LocationType.Start).Single)
    End Function
End Module
