Imports System.IO
Imports Microsoft.VisualBasic.FileIO

Public Class Form1

    Dim LG_strTmp As String = Path.Combine(Path.GetTempPath(), "CombineMovies.txt")

    ''' <summary>
    ''' コマンドライン設定
    ''' </summary>
    Private Sub I_SetCommandline()
        Dim strTarget As String = "xxxxx.avi"
        If Directory.Exists(txtTargetfolder.Text) = True Then
            Dim di As New DirectoryInfo(txtTargetfolder.Text)
            strTarget = Path.Combine(di.Parent.FullName, di.Name & ".avi")
        End If
        txtCommandline.Text = "-f concat -safe 0 -i """ & LG_strTmp & """ -c copy """ & strTarget & """"
    End Sub

    ''' <summary>
    ''' いける？
    ''' </summary>
    ''' <returns></returns>
    Private Function I_InputCheck() As Boolean
        Dim bRet As Boolean = True
        Dim strMsg As String = ""

        If txtFfmpeg.Text = "" Then
            bRet = False
            strMsg = "ffmpegの場所が指定されていません"
        End If

        If File.Exists(txtFfmpeg.Text) = False Then
            bRet = False
            strMsg = "指定されたffmpeg.exeは存在しません"
        End If

        If txtTargetfolder.Text = "" Then
            bRet = False
            strMsg = "対象フォルダが指定されていません"
        End If

        If Directory.Exists(txtTargetfolder.Text) = False Then
            bRet = False
            strMsg = "対象フォルダが存在しません"
        End If

        If strMsg <> "" Then
            MessageBox.Show(Me.Text, strMsg, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Return bRet
    End Function

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
    ''' Form Closing
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        C_WriteIni(Me.Name, txtFfmpeg.Name, txtFfmpeg.Text)
    End Sub

    ''' <summary>
    ''' ぽいしたい
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) = True Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    ''' <summary>
    ''' ぽいした
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim strFileName As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
        If Directory.Exists(strFileName(0).ToString) = True Then
            txtTargetfolder.Text = strFileName(0).ToString
        End If
    End Sub

    ''' <summary>
    ''' フォルダ選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtTargetfolder_TextChanged(sender As Object, e As EventArgs) Handles txtTargetfolder.TextChanged
        I_SetCommandline()
    End Sub

    ''' <summary>
    ''' ffmpeg選択
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub brnRefFfmpeg_Click(sender As Object, e As EventArgs) Handles brnRefFfmpeg.Click
        Using ofd As New OpenFileDialog()
            ofd.FileName = "ffmpeg.exe"
            ofd.Filter = "ffmpeg|ffmpeg.exe|すべてのファイル(*.*)|*.*"
            ofd.Title = "使用するffmpeg.exeを選択してください"
            ofd.RestoreDirectory = True

            If ofd.ShowDialog() = DialogResult.OK Then
                txtFfmpeg.Text = ofd.FileName
            End If
        End Using
    End Sub

    ''' <summary>
    ''' フォルダ参照
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRefTargetfolder_Click(sender As Object, e As EventArgs) Handles btnRefTargetfolder.Click
        Using fbd As New FolderBrowserDialog
            fbd.Description = "対象フォルダを指定してください。"
            fbd.SelectedPath = SpecialDirectories.MyDocuments
            fbd.ShowNewFolderButton = False

            If fbd.ShowDialog() = DialogResult.OK Then
                txtTargetfolder.Text = fbd.SelectedPath
            End If
        End Using
    End Sub

    ''' <summary>
    ''' 実行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If I_InputCheck() = True Then
            'Temp削除
            If File.Exists(LG_strTmp) = True Then
                File.Delete(LG_strTmp)
            End If

            'リスト作成
            Using sw As New StreamWriter(LG_strTmp)
                Dim strFiles As String() = Directory.GetFiles(txtTargetfolder.Text, "*.avi")
                Array.Sort(strFiles)
                For Each f In strFiles
                    sw.WriteLine("file '" & f & "'")
                Next
                sw.Flush()
            End Using

            '実行
            Dim psi As New ProcessStartInfo
            psi.FileName = txtFfmpeg.Text
            psi.Arguments = txtCommandline.Text
            Process.Start(psi)
        End If
    End Sub

    ''' <summary>
    ''' 終了
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class
