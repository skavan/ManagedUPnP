Imports System.Reflection

Module modUtils
    Public Sub MyDebug(Payload1 As String, PayLoad2 As String)
        Dim stackframe As New Diagnostics.StackFrame(1)
        Dim callingMethod As String = stackframe.GetMethod.Name
        Debug.Print("Sub:" & callingMethod & vbTab & "Payload:" & Payload1 & "|" & PayLoad2)
    End Sub
End Module
