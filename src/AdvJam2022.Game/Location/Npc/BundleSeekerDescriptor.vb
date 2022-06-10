﻿Friend Class BundleSeekerDescriptor
    Inherits NpcTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "bundle seeker"
        End Get
    End Property

    Public Overrides ReadOnly Property LocationType As LocationType
        Get
            Return LocationType.Start
        End Get
    End Property

    Public Overrides ReadOnly Property Quantity As Long
        Get
            Return 1
        End Get
    End Property

    Public Overrides Sub DoTalk(player As PlayerCharacter, builder As StringBuilder)
        If Not player.HasItemType(ItemType.StickBundle) Then
            builder.AppendLine($"{Name} says they'd be very appreciative if you'd fetch them a [blue]bundle of sticks[/].")
            builder.AppendLine($"{Name} says you can forage for [blue]sticks[/] and other things off the main road.")
            builder.AppendLine($"{Name} says you can craft a bundle from [blue]sticks[/] and [blue]twine[/], and you can make [blue]twine[/] from [blue]plant fiber[/].")
            Return
        End If
        Dim questItem = player.Inventory.ItemStacks(ItemType.StickBundle).First
        questItem.Destroy()
        player.Inventory.Add(Item.Create(ItemType.ThankYouNote))
        builder.AppendLine($"{Name} gives you a [blue]thank you note[/] in return for the [blue]bundle of sticks[/] and leaves.")
        player.Location.Npc.Destroy()
    End Sub
End Class
