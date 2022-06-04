Public Module World
    Function Create() As PlayerCharacter
        Dim startingLocation As Location = Location.Create(LocationType.Start)
        Dim player = PlayerCharacter.CreatePlayerCharacter(startingLocation)
        Return player
    End Function
End Module
