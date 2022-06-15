Imports SPLORR.Game

Friend Module BuildFireProcessor
    Private ReadOnly StartFireGenerator As IReadOnlyDictionary(Of Boolean, Integer) = RNG.MakeBooleanGenerator(1, 1)
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        If Not player.CanBuildFire Then
            builder.AppendLine("You cannot build a fire now.")
            Return
        End If
        player.ChangeHunger(-5)
        player.Inventory.ItemStacks(ItemType.PlantFiber).First.Destroy()
        If Not RNG.FromGenerator(StartFireGenerator) Then
            builder.AppendLine("You fail to start the fire.")
            Return
        End If
        Dim items = player.Inventory.ItemStacks(ItemType.FireWood).Take(5)
        For Each item In items
            item.Destroy()
        Next
        Npc.Create(player.Location, NpcType.Fire)
        builder.AppendLine("You start a fire.")
    End Sub
End Module
