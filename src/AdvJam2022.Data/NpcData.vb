Public Module NpcData
    Friend Const TableName = "Npcs"
    Friend Const LocationIdColumn = LocationData.LocationIdColumn
    Friend Const NpcTypeColumn = "NpcType"
    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{LocationIdColumn}] INT NOT NULL UNIQUE,
                [{NpcTypeColumn}] INT NOT NULL,
                FOREIGN KEY ([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub
    Public Function ReadNpcType(locationId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(AddressOf Initialize, TableName, NpcTypeColumn, (LocationIdColumn, locationId))
    End Function

    Public Function Exists(locationId As Long) As Boolean
        Return ReadColumnValue(Of Long, Long)(AddressOf Initialize, TableName, LocationIdColumn, (LocationIdColumn, locationId)).HasValue
    End Function
End Module
