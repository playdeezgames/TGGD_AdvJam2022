﻿Public Class Location
    ReadOnly Property Id As Long
    Sub New(locationId As Long)
        Id = locationId
    End Sub

    ReadOnly Property Name As String
        Get
            Return LocationType.Name
        End Get
    End Property

    ReadOnly Property LocationType As LocationType
        Get
            Return CType(LocationData.ReadLocationType(Id).Value, LocationType)
        End Get
    End Property

    Friend Shared Function Create(locationType As LocationType) As Location
        Return New Location(LocationData.Create(locationType))
    End Function

    Friend Function HasRoute(direction As Direction) As Boolean
        Return RouteData.ReadForFromLocationAndDirection(Id, direction).HasValue
    End Function

    ReadOnly Property Routes As IReadOnlyDictionary(Of Direction, Route)
        Get
            Return RouteData.
                ReadForFromLocation(Id).
                ToDictionary(
                    Function(x) CType(x.Item1, Direction),
                    Function(x) New Route(x.Item2))
        End Get
    End Property

    Friend Function VisitedBy(character As Character) As Boolean
        Return CharacterLocationData.Exists(character.Id, Id)
    End Function

    Friend Shared Function FindAll(locationType As LocationType) As IEnumerable(Of Location)
        Return LocationData.ReadForLocationType(locationType).Select(AddressOf Location.FromId)
    End Function

    Private Shared Function FromId(locationId As Long) As Location
        Return New Location(locationId)
    End Function
End Class
