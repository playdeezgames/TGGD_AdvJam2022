Public Module CharacterAchievementData
    Friend Const TableName = "CharacterAchievements"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const AchievementTypeColumn = "AchievementType"
    Friend Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}],
                [{AchievementTypeColumn}],
                UNIQUE([{CharacterIdColumn}],[{AchievementTypeColumn}]),
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}])
            );")
    End Sub
    Public Function Read(characterId As Long) As IEnumerable(Of Long)
        Return ReadRecordsWithColumnValue(Of Long, Long)(AddressOf Initialize, TableName, AchievementTypeColumn, (CharacterIdColumn, characterId))
    End Function
End Module
