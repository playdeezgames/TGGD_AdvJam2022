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
End Enum
Public Module ItemTypeExtensions
    <Extension>
    Function Name(itemType As ItemType) As String
        Return ItemTypeDescriptors(itemType).Name
    End Function
End Module