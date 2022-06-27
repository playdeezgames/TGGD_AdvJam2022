Friend Module OffersProcessor
    Friend Sub Run(player As PlayerCharacter, builder As StringBuilder)
        player.GetOfferList(builder)
    End Sub
End Module
