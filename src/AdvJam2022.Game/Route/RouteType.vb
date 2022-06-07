Imports System.Runtime.CompilerServices

Public Enum RouteType
    None
    Road
    Door
    Path
End Enum
Public Module RouteTypeExtensions
    <Extension>
    Function Format(routeType As RouteType, direction As Direction) As String
        Return RouteTypeDescriptors(routeType).Format(direction)
    End Function
End Module