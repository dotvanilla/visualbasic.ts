Public Class Workspace

    Public ReadOnly Property [Namespace] As String

    Sub New(ns As String)
        [Namespace] = ns
    End Sub

    Public Overrides Function ToString() As String
        Return [Namespace]
    End Function

End Class
