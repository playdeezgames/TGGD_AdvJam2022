Public Module InventoryItemData
    Friend Const TableName = "InventoryItems"
    Friend Const InventoryIdColumn = InventoryData.InventoryIdColumn
    Friend Const ItemIdColumn = ItemData.ItemIdColumn
    Friend Sub Initialize()
        InventoryData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{InventoryIdColumn}] INT NOT NULL,
                [{ItemIdColumn}] INT NOT NULL UNIQUE,
                FOREIGN KEY ([{InventoryIdColumn}]) REFERENCES [{InventoryData.TableName}]([{InventoryData.InventoryIdColumn}]),
                FOREIGN KEY ([{ItemIdColumn}]) REFERENCES [{ItemData.TableName}]([{ItemData.ItemIdColumn}])
            );")
    End Sub

    Public Sub Write(inventoryId As Long, itemId As Long)
        ReplaceRecord(AddressOf Initialize, TableName, (InventoryIdColumn, inventoryId), (ItemIdColumn, itemId))
    End Sub

    Public Function ReadForInventory(inventoryId As Long) As IEnumerable(Of Long)
        Return ReadRecordsWithColumnValue(Of Long, Long)(AddressOf Initialize, TableName, ItemIdColumn, (InventoryIdColumn, inventoryId))
    End Function
End Module
