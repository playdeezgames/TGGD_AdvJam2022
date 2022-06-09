﻿Public Class Recipe
    ReadOnly Property Inputs As IReadOnlyDictionary(Of ItemType, Long)
    ReadOnly Property Outputs As IReadOnlyDictionary(Of ItemType, Long)
    ReadOnly Property Name As String
    Sub New(inputs As IReadOnlyDictionary(Of ItemType, Long), outputs As IReadOnlyDictionary(Of ItemType, Long))
        Me.Inputs = inputs
        Me.Outputs = outputs
        Dim builder As New StringBuilder
        builder.AppendJoin(", ", inputs.Select(Function(x) $"{x.Key.Name}(x{x.Value})"))
        builder.Append(" -> ")
        builder.AppendJoin(", ", outputs.Select(Function(x) $"{x.Key.Name}(x{x.Value})"))
        Name = builder.ToString()
    End Sub
End Class
Public Module RecipeUtility
    Public ReadOnly AllRecipes As IReadOnlyList(Of Recipe) =
        New List(Of Recipe) From
        {
            New Recipe(
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.PlantFiber, 2}
                },
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.Twine, 1}
                })
        }
End Module
