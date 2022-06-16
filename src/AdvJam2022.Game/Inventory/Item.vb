Public Class Item
    ReadOnly Property Id As Long
    Sub New(itemId As Long)
        Id = itemId
    End Sub
    Shared Function FromId(itemId As Long) As Item
        Return New Item(itemId)
    End Function
    ReadOnly Property Name As String
        Get
            Return ItemType.Name
        End Get
    End Property
    ReadOnly Property ItemType As ItemType
        Get
            Return CType(ItemData.ReadItemType(Id).Value, ItemType)
        End Get
    End Property

    ReadOnly Property CanCook() As Boolean
        Get
            Return ItemType.CanCook
        End Get
    End Property

    ReadOnly Property CanFish As Boolean
        Get
            Return ItemType.CanFish
        End Get
    End Property

    Friend ReadOnly Property HungerBenefit As Long
        Get
            Return ItemType.HungerBenefit
        End Get
    End Property

    Public Shared Function Create(itemType As ItemType) As Item
        Return New Item(ItemData.Create(itemType))
    End Function

    Public Sub Destroy()
        ItemData.Clear(Id)
    End Sub

    Friend Sub Use(character As Character, builder As StringBuilder)
        ItemType.Use(Me, character, builder)
    End Sub
End Class
