Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Microsoft.VisualBasic.ApplicationServices.Development
Imports Microsoft.VisualBasic.ApplicationServices.Development.VisualStudio.vbproj
Imports vbproj = Microsoft.VisualBasic.ApplicationServices.Development.VisualStudio.vbproj.Xml.Project

Public Class Scanner

    ReadOnly vbproj As vbproj
    ReadOnly assembly As AssemblyInfo

    Public ReadOnly Property Workspace As Workspace

    Sub New(vbproj As vbproj)
        Me.vbproj = vbproj
        Me.assembly = vbproj.AssemblyInfo
        Me.Workspace = New Workspace(vbproj.RootNamespace)
    End Sub

    ''' <summary>
    ''' scan all vb source files of current vbproj
    ''' </summary>
    Public Function ScanVBFiles() As Workspace
        For Each file As String In vbproj.EnumerateSourceFiles(skipAssmInfo:=True, fullName:=True)
            Call ScanVBFile(file)
        Next

        Return Workspace
    End Function

    Private Sub ScanVBFile(filepath As String)
        Dim syntax As CompilationUnitSyntax = VisualBasicSyntaxTree _
           .ParseText(filepath.SolveStream) _
           .GetRoot

        For Each obj As StatementSyntax In syntax.Members

        Next
    End Sub

End Class
