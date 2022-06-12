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

    Public Sub Add(item As Item)
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

    Friend Sub Craft(recipe As Recipe, builder As StringBuilder)
        If CanCraft(recipe) Then
            For Each input In recipe.Inputs
                Dim items = ItemStacks(input.Key).Take(CInt(input.Value))
                For Each item In items
                    builder.AppendLine($"-{item.Name}")
                    item.Destroy()
                Next
            Next
            For Each output In recipe.Outputs
                Dim quantity = output.Value
                While quantity > 0
                    quantity -= 1
                    Dim item = Game.Item.Create(output.Key)
                    Add(item)
                    builder.AppendLine($"+{Item.Name}")
                End While
            Next
        End If
    End Sub

    Private Function ItemCount(itemType As ItemType) As Long
        Dim itemStacks = Me.ItemStacks.Where(Function(x) x.Key = itemType)
        If Not itemStacks.Any Then
            Return 0
        End If
        Return itemStacks.First.Value.LongCount
    End Function
End Class
