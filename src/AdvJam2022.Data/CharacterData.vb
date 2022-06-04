Public Module CharacterData
    Friend Const TableName = "Characters"
    Friend Const CharacterIdColumn = "CharacterId"
    Friend Const CharacterTypeColumn = "CharacterType"
    Friend Const LocationIdColumn = LocationData.LocationIdColumn

    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{CharacterTypeColumn}] INT NOT NULL,
                [{LocationIdColumn}] INT NOT NULL,
                FOREIGN KEY ([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub

    Public Function ReadLocation(characterId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(AddressOf Initialize, TableName, LocationIdColumn, (CharacterIdColumn, characterId))
    End Function

    Public Sub WriteLocation(characterId As Long, locationId As Long)
        WriteColumnValue(AddressOf Initialize, TableName, (LocationIdColumn, locationId), (CharacterIdColumn, characterId))
    End Sub

    Public Function ReadForCharacterType(characterType As Long) As IEnumerable(Of Long)
        Return ReadRecordsWithColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            CharacterIdColumn,
            (CharacterTypeColumn, characterType))
    End Function

    Public Sub ClearForCharacterType(characterType As Long)
        ClearForColumnValue(AddressOf Initialize, TableName, (CharacterTypeColumn, characterType))
    End Sub

    Function Create(characterType As Long, locationId As Long) As Long
        Return CreateRecord(AddressOf Initialize, TableName, (CharacterTypeColumn, characterType), (LocationIdColumn, locationId))
    End Function
End Module
