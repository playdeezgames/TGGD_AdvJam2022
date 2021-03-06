Public Module World
    Const LocationCount As Integer = 24
    Const WildernessLocationCount = LocationCount \ 4
    Function Create() As PlayerCharacter
        CreateOverworld()
        CreateFooMarT()
        CreateDarkAlley()
        CreateWilderness()
        CreateCasino()
        CreateFishingPond()
        CreateFishmongery()
        CreateHardwareStore()
        CreateNpcs()
        Return CreatePlayer()
    End Function

    Private Sub CreateHardwareStore()
        Do
            Dim candidate = RNG.FromEnumerable(Location.FindAll(LocationType.Generic))
            If Not candidate.Routes.ContainsKey(Direction.Inward) Then
                Dim destination = Location.Create(LocationType.HardwareStore)
                Route.Create(candidate, Direction.Inward, destination, RouteType.Door)
                Route.Create(destination, Direction.Outward, candidate, RouteType.Door)
                Exit Do
            End If
        Loop
    End Sub

    Private Sub CreateFishmongery()
        Do
            Dim candidate = RNG.FromEnumerable(Location.FindAll(LocationType.Generic))
            If Not candidate.Routes.ContainsKey(Direction.Inward) Then
                Dim destination = Location.Create(LocationType.Fishmongery)
                Route.Create(candidate, Direction.Inward, destination, RouteType.Door)
                Route.Create(destination, Direction.Outward, candidate, RouteType.Door)
                Exit Do
            End If
        Loop
    End Sub

    Private Sub CreateFishingPond()
        Dim done = False
        While Not done
            Dim candidate = RNG.FromEnumerable(Location.FindAll(LocationType.Wilderness))
            Dim directions = CardinalDirections.Where(Function(x) Not candidate.HasRoute(x))
            If directions.Any Then
                Dim direction = RNG.FromEnumerable(directions)
                Dim destination = Location.Create(LocationType.FishingPond)
                Route.Create(candidate, direction, destination, RouteType.Path)
                Route.Create(destination, direction.Opposite, candidate, RouteType.Path)
                done = True
            End If
        End While
    End Sub

    Private Sub CreateCasino()
        Dim done = False
        While Not done
            Dim candidate = RNG.FromEnumerable(Location.FindAll(LocationType.Generic))
            If Not candidate.Routes.ContainsKey(Direction.Inward) Then
                Dim destination = Location.Create(LocationType.Casino)
                Route.Create(candidate, Direction.Inward, destination, RouteType.Door)
                Route.Create(destination, Direction.Outward, candidate, RouteType.Door)
                done = True
            End If
        End While
    End Sub

    Private Sub CreateDarkAlley()
        Dim done = False
        While Not done
            Dim candidate = RNG.FromEnumerable(Location.FindAll(LocationType.Generic))
            Dim directions = CardinalDirections.Where(Function(x) Not candidate.HasRoute(x))
            If directions.Any Then
                Dim direction = RNG.FromEnumerable(directions)
                Dim destination = Location.Create(LocationType.DarkAlley)
                Route.Create(candidate, direction, destination, RouteType.AlleyWay)
                Route.Create(destination, direction.Opposite, candidate, RouteType.AlleyWay)
                done = True
            End If
        End While
    End Sub

    Private Sub CreateNpcs()
        For Each entry In NpcTypeDescriptors
            Dim quantity = entry.Value.Quantity
            While quantity > 0
                Dim candidates = Location.FindAll(entry.Value.LocationType).Where(Function(x) Not x.HasNpc)
                Npc.Create(RNG.FromEnumerable(candidates), entry.Key)
                quantity -= 1
            End While
        Next
    End Sub

    Private Sub CreateWilderness()
        Dim wildernessLocations As New List(Of Location)
        While wildernessLocations.LongCount < WildernessLocationCount
            Dim candidate = RNG.FromEnumerable(Location.FindAll(LocationType.Generic))
            Dim directions = CardinalDirections.Where(Function(x) Not candidate.HasRoute(x))
            If directions.Any Then
                Dim direction = RNG.FromEnumerable(directions)
                Dim destination = Location.Create(LocationType.Wilderness)
                Route.Create(candidate, direction, destination, RouteType.Path)
                Route.Create(destination, direction.Opposite, candidate, RouteType.Path)
                wildernessLocations.Add(destination)
            End If
        End While
    End Sub

    Private Sub CreateFooMarT()
        Dim candidates = Location.FindAll(LocationType.Generic).Where(Function(x) Not x.HasRoute(Direction.Inward))
        Dim outside = RNG.FromEnumerable(candidates)
        Dim inside = Location.Create(LocationType.FooMarT)
        Route.Create(outside, Direction.Inward, inside, RouteType.Door)
        Route.Create(inside, Direction.Outward, outside, RouteType.Door)
    End Sub

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
