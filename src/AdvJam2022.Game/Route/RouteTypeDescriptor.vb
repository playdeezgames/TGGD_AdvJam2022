﻿Public MustInherit Class RouteTypeDescriptor
    MustOverride Function Format(direction As Direction) As String
End Class
Friend Module RouteTypeDescriptorUtility
    Friend ReadOnly RouteTypeDescriptors As IReadOnlyDictionary(Of RouteType, RouteTypeDescriptor) =
        New Dictionary(Of RouteType, RouteTypeDescriptor) From
        {
            {RouteType.Road, New RoadDescriptor}
        }
End Module