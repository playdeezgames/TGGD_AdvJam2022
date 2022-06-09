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

    ReadOnly Property ItemStacks As IReadOnlyDictionary(Of ItemType, IEnumerable(Of Item))
        Get
            Return Items.GroupBy(Function(x) x.ItemType).ToDictionary(Function(x) x.Key, Function(x) x.AsEnumerable)
        End Get
    End Property

    Public Function CanCraft(recipe As Recipe) As Boolean
        Return recipe.Inputs.All(Function(x) ItemCount(x.Key) >= x.Value)
    End Function

    Private Function ItemCount(itemType As ItemType) As Long
        Dim itemStacks = Me.ItemStacks.Where(Function(x) x.Key = itemType)
        If Not itemStacks.Any Then
            Return 0
        End If
        Return itemStacks.First.Value.LongCount
    End Function
End Class
