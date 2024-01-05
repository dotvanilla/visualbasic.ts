Imports Microsoft.CodeAnalysis.VisualBasic
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Microsoft.VisualBasic.ApplicationServices.Development
Imports Microsoft.VisualBasic.ApplicationServices.Development.VisualStudio.vbproj
Imports vbproj = Microsoft.VisualBasic.ApplicationServices.Development.VisualStudio.vbproj.Xml.Project

Public Class Scanner

    ReadOnly project As vbproj
    ReadOnly assembly As AssemblyInfo

    Public ReadOnly Property Workspace As Workspace

    Sub New(vbproj As vbproj)
        Me.assembly = vbproj.AssemblyInfo
        Me.project = vbproj
        Me.Workspace = New Workspace(vbproj.RootNamespace)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="filepath">
    ''' the file path to the target vbproj file
    ''' </param>
    ''' <returns></returns>
    Public Shared Function FromFile(filepath As String) As Scanner
        Return New Scanner(vbproj.Load(filepath))
    End Function

    ''' <summary>
    ''' scan all vb source files of current vbproj
    ''' </summary>
    Public Function ScanVBFiles() As Workspace
        For Each file As String In project.EnumerateSourceFiles(skipAssmInfo:=True, fullName:=True)
            Call ScanVBFile(file)
        Next

        Return Workspace
    End Function

    Private Sub ScanVBFile(filepath As String)
        Dim syntax As CompilationUnitSyntax = VisualBasicSyntaxTree _
           .ParseText(filepath.SolveStream) _
           .GetRoot
        Dim context As New FileContext(syntax)

        For Each obj As StatementSyntax In syntax.Members

        Next
    End Sub

End Class
