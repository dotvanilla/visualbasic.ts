Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel

''' <summary>
''' the vb source file context
''' </summary>
Public Class FileContext

    ''' <summary>
    ''' the namespace imports
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property [Imports] As IReadOnlyCollection(Of String)
    Public ReadOnly Property [Alias] As IReadOnlyDictionary(Of String, String)
    Public ReadOnly Property Workspace As Workspace

    Sub New(file As CompilationUnitSyntax, workspace As Workspace)
        Dim [imports] As New List(Of String)
        Dim [alias] As New Dictionary(Of String, String)

        For Each line As ImportsStatementSyntax In file.Imports
            For Each ns As ImportsClauseSyntax In line.ImportsClauses
                If TypeOf ns Is SimpleImportsClauseSyntax Then
                    Call [imports].Add(DirectCast(ns, SimpleImportsClauseSyntax).Name.SymbolName)
                Else
                    Throw New NotImplementedException(ns.GetType.FullName)
                End If
            Next
        Next

        Me.Workspace = workspace
        Me.Imports = [imports]
        Me.Alias = [alias]
    End Sub

    ''' <summary>
    ''' create the clr type reference from the source file
    ''' </summary>
    ''' <param name="name"></param>
    ''' <returns></returns>
    Public Overloads Function [GetType](name As String) As CLRType
        Throw New NotImplementedException
    End Function

End Class
