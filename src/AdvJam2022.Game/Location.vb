Public Class Location
    ReadOnly Property Id As Long
    Sub New(locationId As Long)
        Id = locationId
    End Sub

    Friend Shared Function Create(locationType As LocationType) As Location
        Return New Location(LocationData.Create(locationType))
    End Function
End Class
