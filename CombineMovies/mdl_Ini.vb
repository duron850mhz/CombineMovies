Imports System.IO

Module mdl_Ini
    Private Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (
       ByVal lpApplicationName As String,
       ByVal lpKeyName As String,
       ByVal lpDefault As String,
       ByVal lpReturnedString As System.Text.StringBuilder,
       ByVal nSize As UInt32,
       ByVal lpFileName As String) As UInt32

    Private Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (
        ByVal lpAppName As String,
        ByVal lpKeyName As String,
        ByVal lpString As String,
        ByVal lpFileName As String) As Integer

    ''' <summary>
    ''' ini読み込み
    ''' </summary>
    ''' <param name="strSection"></param>
    ''' <param name="strKeyName"></param>
    ''' <returns></returns>
    Public Function C_ReadIni(ByVal strSection As String,
                                     ByVal strKeyName As String) As String
        Try
            Dim strAppPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim strIniFileName As String = Path.ChangeExtension(strAppPath, "ini")

            Dim strWork As System.Text.StringBuilder = New System.Text.StringBuilder(1024)
            Dim intRet As Integer = GetPrivateProfileString(strSection, strKeyName, "", strWork, strWork.Capacity - 1, strIniFileName)
            If intRet > 0 Then
                Return strWork.ToString
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function


    ''' <summary>
    ''' ini書き込み
    ''' </summary>
    ''' <param name="strSection"></param>
    ''' <param name="strKeyName"></param>
    ''' <param name="strSet"></param>
    ''' <returns></returns>
    Public Function C_WriteIni(ByVal strSection As String,
                                       ByVal strKeyName As String,
                                       ByVal strSet As String) As Boolean
        Try
            Dim strAppPath As String = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim strIniFileName As String = Path.ChangeExtension(strAppPath, "ini")

            Dim intRet As Integer = WritePrivateProfileString(strSection, strKeyName, strSet, strIniFileName)
            If intRet > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Module
