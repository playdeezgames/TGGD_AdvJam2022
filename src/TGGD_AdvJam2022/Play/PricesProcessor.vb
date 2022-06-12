Friend Class PricesProcessor
    Friend Shared Sub Run(player As PlayerCharacter, builder As StringBuilder)
        player.GetPriceList(builder)
    End Sub
End Class
