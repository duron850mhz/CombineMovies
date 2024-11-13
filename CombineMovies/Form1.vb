Imports System.IO

Public Class Form1

    Dim LG_strTmp As String = Path.Combine(Path.GetTempPath(), "CombineMovies.txt")

    Private Sub I_SetCommandline()
        Dim strTarget As String = "xxxxx.avi"
        If Directory.Exists(txtTargetfolder.Text) = True Then
            Dim di As New DirectoryInfo(txtTargetfolder.Text)
            strTarget = Path.Combine(di.Parent.FullName, di.Name & ".avi")
        End If
        txtCommandline.Text = "-f concat -safe 0 -i " & LG_strTmp & " -c copy " & strTarget
    End Sub

    ''' <summary>
    ''' Form Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFfmpeg.Text = C_ReadIni(Me.Name, txtFfmpeg.Name)
        I_SetCommandline()
    End Sub

    ''' <summary>
    ''' フォルダ選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtTargetfolder_TextChanged(sender As Object, e As EventArgs) Handles txtTargetfolder.TextChanged
        I_SetCommandline()
    End Sub
End Class
