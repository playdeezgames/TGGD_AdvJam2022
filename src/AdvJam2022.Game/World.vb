Public Module World
    Const LocationCount As Long = 24
    Function Create() As PlayerCharacter
        Dim locations As New List(Of Location) From
            {
                Location.Create(LocationType.Start)
            }
        While locations.LongCount < LocationCount
            locations.Add(Location.Create(LocationType.Generic))
        End While
        Dim player = PlayerCharacter.CreatePlayerCharacter(locations.First)
        Return player
    End Function
End Module
