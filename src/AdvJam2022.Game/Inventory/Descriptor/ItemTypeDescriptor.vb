﻿Public MustInherit Class ItemTypeDescriptor
    MustOverride ReadOnly Property Name As String

    Overridable ReadOnly Property CanUse As Boolean
        Get
            Return False
        End Get
    End Property

    Overridable Sub Use(item As Item, character As Character, builder As StringBuilder)
        builder.AppendLine("Nothing happens.")
    End Sub

    Overridable ReadOnly Property HungerBenefit As Long
        Get
            Return 0
        End Get
    End Property
End Class
Public Module ItemTypeDescriptorUtility
    Friend ReadOnly ItemTypeDescriptors As IReadOnlyDictionary(Of ItemType, ItemTypeDescriptor) =
        New Dictionary(Of ItemType, ItemTypeDescriptor) From
        {
            {ItemType.Berry, New BerryDescriptor},
            {ItemType.CoinBag, New CoinBagDescriptor},
            {ItemType.Litter, New LitterDescriptor},
            {ItemType.Parcel, New ParcelDescriptor},
            {ItemType.PlantFiber, New PlantFiberDescriptor},
            {ItemType.Rock, New RockDescriptor},
            {ItemType.SharpRock, New SharpRockDescriptor},
            {ItemType.ShortStick, New ShortStickDescriptor},
            {ItemType.Stick, New StickDescriptor},
            {ItemType.StickBundle, New StickBundleDescriptor},
            {ItemType.StoneKnife, New StoneKnifeDescriptor},
            {ItemType.ThankYouNote, New ThankYouNoteDescriptor},
            {ItemType.Twine, New TwineDescriptor},
            {ItemType.Twinkie, New TwinkieDescriptor},
            {ItemType.WrappedTwinkie, New WrappedTwinkieDescriptor}
        }
    Friend ReadOnly Property AllItemTypes As IEnumerable(Of ItemType)
        Get
            Return ItemTypeDescriptors.Keys
        End Get
    End Property
    Public Function ParseItemType(itemTypeName As String) As ItemType
        Return AllItemTypes.Single(Function(x) x.Name = itemTypeName)
    End Function
End Module