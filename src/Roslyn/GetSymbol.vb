Imports System.Runtime.CompilerServices
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Module GetSymbol

    <Extension>
    Friend Function SymbolName(name As IdentifierNameSyntax) As String
        Return FixSpecialKeyName(name.Identifier.ValueText)
    End Function

    <Extension>
    Friend Function SymbolName(name As NameSyntax) As String
        If TypeOf name Is SimpleNameSyntax Then
            Return DirectCast(name, SimpleNameSyntax).SymbolName
        Else
            Throw New NotImplementedException(name.GetType.FullName)
        End If
    End Function

    <Extension>
    Friend Function SymbolName(name As SimpleNameSyntax) As String
        Return FixSpecialKeyName(name.Identifier.ValueText)
    End Function

    <Extension>
    Friend Function SymbolName(name As SyntaxToken) As String
        Return FixSpecialKeyName(name.Text)
    End Function

    <Extension>
    Friend Function SymbolName(x As ModifiedIdentifierSyntax) As String
        Return x.Identifier.SymbolName
    End Function

    <MethodImpl(MethodImplOptions.AggressiveInlining)>
    Private Function FixSpecialKeyName(name As String) As String
        Return Strings.Trim(name).Trim("["c, "]"c, " "c)
    End Function
End Module
