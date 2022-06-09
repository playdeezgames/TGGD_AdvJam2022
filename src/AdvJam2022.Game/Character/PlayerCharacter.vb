Public Class PlayerCharacter
    Inherits Character
    Sub New()
        MyBase.New(CharacterData.ReadForCharacterType(CharacterType.Player).Single)
    End Sub

    Public Shared Function CreatePlayerCharacter(location As Location) As PlayerCharacter
        CharacterData.ClearForCharacterType(CharacterType.Player)
        Character.CreateCharacter(CharacterType.Player, location)
        Return New PlayerCharacter()
    End Function
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
            ChangeStatistic(StatisticType.Health, -1)
            Return
        End If
        ChangeStatistic(StatisticType.Hunger, -1)
    End Sub

    Private Sub ChangeStatistic(statisticType As StatisticType, delta As Long)
        SetStatistic(statisticType, GetStatistic(statisticType) + delta)
    End Sub

    Private Sub SetStatistic(statisticType As StatisticType, statisticValue As Long)
        statisticValue = Math.Max(statisticValue, statisticType.MinimumValue(CharacterType))
        CharacterStatisticData.Write(Id, statisticType, statisticValue)
    End Sub
    Public Sub Forage(builder As StringBuilder)
        If Not CanDoVerb(Verb.Forage) Then
            builder.AppendLine("You cannot forage now!")
            Return
        End If
        ApplyEffects(builder)
        Dim items = Location.Forage()
        If Not items.any Then
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
End Class
