Imports Roslyn

Module vbtest

    Sub test_parser()
        Dim scanner As Scanner = Scanner.FromFile("G:\visualbasic.ts\test\demo_vbproj\demo_vbproj.vbproj")
        scanner.ScanVBFiles()
    End Sub
End Module
