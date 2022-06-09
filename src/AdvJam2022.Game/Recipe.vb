Public Class Recipe
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
                }),
            New Recipe(
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.Rock, 2}
                },
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.Rock, 1},
                    {ItemType.SharpRock, 1}
                }),
            New Recipe(
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.SharpRock, 1},
                    {ItemType.Twine, 1},
                    {ItemType.Stick, 1}
                },
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.StoneKnife, 1}
                }),
            New Recipe(
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.Twine, 2},
                    {ItemType.Stick, 12}
                },
                New Dictionary(Of ItemType, Long) From
                {
                    {ItemType.StickBundle, 1}
                })
        }
End Module
