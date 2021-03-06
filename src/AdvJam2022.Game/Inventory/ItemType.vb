Imports System.Runtime.CompilerServices

Public Enum ItemType
    None
    WrappedTwinkie
    Twinkie
    PlantFiber
    Stick
    Rock
    Twine
    SharpRock
    StoneKnife
    StickBundle
    ThankYouNote
    ShortStick
    Berry
    Parcel
    CoinBag
    Litter
    StoneSpear
    RawFish
    Axe
    Cheese
    FireWood
    DullAxe
    Firedrill
    Firebow
    RawFishOnAStick
    TwinkieOnAStick
    RoastedFishOnAStick
    RoastedTwinkieOnAStick
    RoastedFish
    RoastedTwinkie
End Enum
Public Module ItemTypeExtensions
    <Extension>
    Function Name(itemType As ItemType) As String
        Return ItemTypeDescriptors(itemType).Name
    End Function
    <Extension>
    Function CanUse(itemType As ItemType) As Boolean
        Return ItemTypeDescriptors(itemType).CanUse
    End Function
    <Extension>
    Sub Use(itemType As ItemType, item As Item, character As Character, builder As StringBuilder)
        ItemTypeDescriptors(itemType).Use(item, character, builder)
    End Sub
    <Extension>
    Function HungerBenefit(itemType As ItemType) As Long
        Return ItemTypeDescriptors(itemType).HungerBenefit
    End Function
    <Extension>
    Function CanFish(itemType As ItemType) As Boolean
        Return ItemTypeDescriptors(itemType).CanFish
    End Function
    <Extension>
    Function CanCook(itemType As ItemType) As Boolean
        Return ItemTypeDescriptors(itemType).CanCook
    End Function
    <Extension>
    Function CookingResult(itemType As ItemType) As ItemType?
        Return ItemTypeDescriptors(itemType).CookingResult
    End Function
End Module