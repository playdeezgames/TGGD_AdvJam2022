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

    Public Function Create(locationId As Long, npcType As Long) As Long
        Return CreateRecord(AddressOf Initialize, TableName, (LocationIdColumn, locationId), (NpcTypeColumn, npcType))
    End Function

    Public Function ReadNpcType(locationId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(AddressOf Initialize, TableName, NpcTypeColumn, (LocationIdColumn, locationId))
    End Function

    Public Sub Clear(locationId As Long)
        ClearForColumnValue(AddressOf Initialize, TableName, (LocationIdColumn, locationId))
    End Sub

    Public Function Exists(locationId As Long) As Boolean
        Dim temp = ReadColumnValue(Of Long, Long)(AddressOf Initialize, TableName, LocationIdColumn, (LocationIdColumn, locationId))
        Return temp.HasValue
    End Function
End Module
