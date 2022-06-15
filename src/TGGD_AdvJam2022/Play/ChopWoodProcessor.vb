Imports SPLORR.Game

Friend Module ChopWoodProcessor
    ReadOnly AxeDullageGenerator As IReadOnlyDictionary(Of Boolean, Integer) =
        New Dictionary(Of Boolean, Integer) From
        {
            {False, 9},
            {True, 1}
        }
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        If Not player.CanChopWood Then
            builder.AppendLine("You cannot chop wood now.")
            Return
        End If
        player.ChangeHunger(-5)
        player.Inventory.Add(Item.Create(ItemType.FireWood))
        builder.AppendLine($"+1 {ItemType.FireWood.Name}")
        If RNG.FromGenerator(AxeDullageGenerator) Then
            builder.AppendLine($"Yer {ItemType.Axe.Name} is now dull.")
            player.Inventory.ItemStacks(ItemType.Axe).First.Destroy()
            player.Inventory.Add(Item.Create(ItemType.DullAxe))
        End If
    End Sub
End Module
