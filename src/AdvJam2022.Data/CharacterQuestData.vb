Public Module CharacterQuestData
    Friend Const TableName = "CharacterQuests"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const QuestTypeColumn = "QuestType"
    Friend Const QuestStateColumn = "QuestState"
    Friend Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}] INT NOT NULL,
                [{QuestTypeColumn}] INT NOT NULL,
                [{QuestStateColumn}] INT NOT NULL,
                UNIQUE([{CharacterIdColumn}],[{QuestTypeColumn}]),
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}])
            );")
    End Sub
    Public Function Read(characterId As Long, questType As Long) As Long?
        Return ReadColumnValue(Of Long, Long, Long)(AddressOf Initialize, TableName, QuestStateColumn, (CharacterIdColumn, characterId), (QuestTypeColumn, questType))
    End Function

    Public Sub Write(characterId As Long, questType As Long, questState As Long)
        ReplaceRecord(AddressOf Initialize, TableName, (CharacterIdColumn, characterId), (QuestTypeColumn, questType), (QuestStateColumn, questState))
    End Sub
End Module
