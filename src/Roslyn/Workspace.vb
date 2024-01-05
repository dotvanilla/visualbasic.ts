
''' <summary>
''' workspace object for solving the clr type reference
''' </summary>
Public Class Workspace

    ''' <summary>
    ''' the root namespace of current assembly
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property RootNamespace As String

    Sub New(ns As String)
        RootNamespace = ns
    End Sub

    Public Overrides Function ToString() As String
        Return RootNamespace
    End Function

End Class
