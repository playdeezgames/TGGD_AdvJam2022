Public Module CharacterStatisticData
    Friend Const TableName = "CharacterStatistics"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const StatisticTypeColumn = "StatisticType"
    Friend Const StatisticValueColumn = "StatisticValue"
    Friend Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}] INT NOT NULL,
                [{StatisticTypeColumn}] INT NOT NULL,
                [{StatisticValueColumn}] INT NOT NULL,
                UNIQUE([{CharacterIdColumn}],[{StatisticTypeColumn}]),
                FOREIGN KEY([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}])
            );")
    End Sub
    Function Read(characterId As Long, statisticType As Long) As Long?
        Return ReadColumnValue(Of Long, Long, Long)(
            AddressOf Initialize,
            TableName,
            StatisticValueColumn,
            (CharacterIdColumn, characterId),
            (StatisticTypeColumn, statisticType))
    End Function
    Function ReadForCharacter(characterId As Long) As IReadOnlyDictionary(Of Long, Long)
        Return ReadRecordsWithColumnValue(Of Long, Long, Long)(
            AddressOf Initialize,
            TableName,
            (StatisticTypeColumn, StatisticValueColumn),
            (CharacterIdColumn, characterId)).
            ToDictionary(Function(x) x.Item1, Function(x) x.Item2)
    End Function

    Public Sub Write(characterId As Long, statisticType As Long, statisticValue As Long)
        ReplaceRecord(AddressOf Initialize, TableName, (CharacterIdColumn, characterId), (StatisticTypeColumn, statisticType), (StatisticValueColumn, statisticValue))
    End Sub
End Module
