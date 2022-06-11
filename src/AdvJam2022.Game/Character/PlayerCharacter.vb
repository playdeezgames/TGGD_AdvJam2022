Public Class PlayerCharacter
    Inherits Character
    Sub New()
        MyBase.New(CharacterData.ReadForCharacterType(CharacterType.Player).Single)
    End Sub

    Public Sub Deliver(builder As StringBuilder)
        If Not CanDeliver Then
            builder.AppendLine("You don't have anything to deliver here.")
            Return
        End If
        Location.Npc.Deliver(Me, builder)
    End Sub

    Public Sub Talk(builder As StringBuilder)
        If Not Location.HasNpc Then
            builder.AppendLine("You talk to yerself, but find yerself a boring person to talk to.")
            Return
        End If
        Location.Npc.Talk(Me, builder)
    End Sub

    Public Shared Function CreatePlayerCharacter(location As Location) As PlayerCharacter
        CharacterData.ClearForCharacterType(CharacterType.Player)
        Character.CreateCharacter(CharacterType.Player, location)
        Return New PlayerCharacter()
    End Function

    Public Sub UseItem(itemType As ItemType, builder As StringBuilder)
        If Not HasItemType(itemType) Then
            builder.AppendLine($"You don't have any {itemType.Name}!")
            Return
        End If
        Dim item = Inventory.ItemStacks(itemType).First
        item.Use(Me, builder)
    End Sub

    Public Sub Move(direction As Direction, builder As StringBuilder)
        If Not CanMoveDirection(direction) Then
            builder.AppendLine($"You cannot go {direction.Name}.")
            Return
        End If
        Location = Location.Routes(direction).ToLocation
        builder.AppendLine($"You go {direction.Name}.")
        ApplyEffects(builder)
    End Sub

    Public Sub Craft(recipe As Recipe, builder As StringBuilder)
        Inventory.Craft(recipe, builder)
        ApplyEffects(builder)
    End Sub

    Public Function CanCraft(recipe As Recipe) As Boolean
        Return Inventory.CanCraft(recipe)
    End Function

    Private Sub ApplyEffects(builder As StringBuilder)
        ApplyHunger(builder)
    End Sub

    Private Sub ApplyHunger(builder As StringBuilder)
        If IsMinimum(StatisticType.Hunger) Then
            builder.AppendLine("[red]Yer starving![/]")
        End If
        ChangeHunger(-1)
    End Sub

    Public Sub Forage(builder As StringBuilder)
        If Not CanDoVerb(Verb.Forage) Then
            builder.AppendLine("You cannot forage now!")
            Return
        End If
        ApplyEffects(builder)
        Dim items = Location.Forage()
        If Not items.Any Then
            builder.AppendLine("You forage and find nothing!")
            Return
        End If
        builder.Append("You foraged: ")
        builder.AppendJoin(", ", items.Select(Function(x) x.Name))
        builder.AppendLine()
        For Each item In items
            Inventory.Add(item)
        Next
    End Sub

    Public Sub AcceptQuest(builder As StringBuilder)
        If Not CanAcceptQuest Then
            builder.AppendLine("You cannot accept a quest now!")
            Return
        End If
        Location.Npc.AcceptQuest(Me, builder)
    End Sub
End Class
