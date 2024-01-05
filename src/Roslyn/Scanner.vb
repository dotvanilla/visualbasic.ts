Imports Microsoft.VisualBasic.ApplicationServices.Development
Imports Microsoft.VisualBasic.ApplicationServices.Development.VisualStudio.vbproj
Imports vbproj = Microsoft.VisualBasic.ApplicationServices.Development.VisualStudio.vbproj.Xml.Project

Public Class Scanner

    ReadOnly vbproj As vbproj
    ReadOnly assembly As AssemblyInfo

    Sub New(vbproj As vbproj)
        Me.vbproj = vbproj
        Me.assembly = vbproj.AssemblyInfo
    End Sub


End Class
