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
            Return InventoryItemData.ReadForInventory(Id).Select(Function(x) New Item(x))
        End Get
    End Property
End Class
