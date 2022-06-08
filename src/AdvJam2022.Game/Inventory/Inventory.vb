Public Class Inventory
    ReadOnly Property Id As Long
    Sub New(inventoryId As Long)
        Id = inventoryId
    End Sub
    ReadOnly Property IsEmpty As Boolean
        Get
            Return Not Items.Any
        End Get
    End Property
    ReadOnly Property Items As IEnumerable(Of Item)
        Get
            Return InventoryItemData.ReadForInventory(Id).Select(AddressOf Item.FromId)
        End Get
    End Property

    Friend Sub Add(item As Item)
        InventoryItemData.Write(Id, item.Id)
    End Sub
End Class
