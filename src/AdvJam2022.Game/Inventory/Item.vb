﻿Public Class Item
    ReadOnly Property Id As Long
    Sub New(itemId As Long)
        Id = itemId
    End Sub
    Shared Function FromId(itemId As Long) As Item
        Return New Item(itemId)
    End Function
End Class
