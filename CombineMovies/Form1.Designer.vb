<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblFfmpeg = New Label()
        txtFfmpeg = New TextBox()
        txtCommandline = New TextBox()
        lblCommandline = New Label()
        txtTargetfolder = New TextBox()
        lblTargetfolder = New Label()
        brnRefFfmpeg = New Button()
        btnRefTargetfolder = New Button()
        btnOK = New Button()
        btnCancel = New Button()
        SuspendLayout()
        ' 
        ' lblFfmpeg
        ' 
        lblFfmpeg.AutoSize = True
        lblFfmpeg.Location = New Point(12, 15)
        lblFfmpeg.Name = "lblFfmpeg"
        lblFfmpeg.Size = New Size(99, 15)
        lblFfmpeg.TabIndex = 0
        lblFfmpeg.Text = "ffmpeg.exeの場所"
        ' 
        ' txtFfmpeg
        ' 
        txtFfmpeg.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtFfmpeg.Location = New Point(138, 12)
        txtFfmpeg.Name = "txtFfmpeg"
        txtFfmpeg.Size = New Size(378, 23)
        txtFfmpeg.TabIndex = 1
        ' 
        ' txtCommandline
        ' 
        txtCommandline.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtCommandline.Location = New Point(138, 41)
        txtCommandline.Name = "txtCommandline"
        txtCommandline.Size = New Size(378, 23)
        txtCommandline.TabIndex = 3
        ' 
        ' lblCommandline
        ' 
        lblCommandline.AutoSize = True
        lblCommandline.Location = New Point(12, 44)
        lblCommandline.Name = "lblCommandline"
        lblCommandline.Size = New Size(67, 15)
        lblCommandline.TabIndex = 2
        lblCommandline.Text = "コマンドライン"
        ' 
        ' txtTargetfolder
        ' 
        txtTargetfolder.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtTargetfolder.Location = New Point(138, 70)
        txtTargetfolder.Name = "txtTargetfolder"
        txtTargetfolder.Size = New Size(378, 23)
        txtTargetfolder.TabIndex = 5
        ' 
        ' lblTargetfolder
        ' 
        lblTargetfolder.AutoSize = True
        lblTargetfolder.Location = New Point(12, 73)
        lblTargetfolder.Name = "lblTargetfolder"
        lblTargetfolder.Size = New Size(66, 15)
        lblTargetfolder.TabIndex = 4
        lblTargetfolder.Text = "対象フォルダ"
        ' 
        ' brnRefFfmpeg
        ' 
        brnRefFfmpeg.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        brnRefFfmpeg.Location = New Point(520, 11)
        brnRefFfmpeg.Name = "brnRefFfmpeg"
        brnRefFfmpeg.Size = New Size(25, 23)
        brnRefFfmpeg.TabIndex = 6
        brnRefFfmpeg.Text = "..."
        brnRefFfmpeg.UseVisualStyleBackColor = True
        ' 
        ' btnRefTargetfolder
        ' 
        btnRefTargetfolder.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefTargetfolder.Location = New Point(520, 69)
        btnRefTargetfolder.Name = "btnRefTargetfolder"
        btnRefTargetfolder.Size = New Size(25, 23)
        btnRefTargetfolder.TabIndex = 7
        btnRefTargetfolder.Text = "..."
        btnRefTargetfolder.UseVisualStyleBackColor = True
        ' 
        ' btnOK
        ' 
        btnOK.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnOK.Location = New Point(470, 119)
        btnOK.Name = "btnOK"
        btnOK.Size = New Size(75, 23)
        btnOK.TabIndex = 8
        btnOK.Text = "実行"
        btnOK.UseVisualStyleBackColor = True
        ' 
        ' btnCancel
        ' 
        btnCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnCancel.Location = New Point(12, 119)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(75, 23)
        btnCancel.TabIndex = 9
        btnCancel.Text = "取消"
        btnCancel.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(553, 155)
        Controls.Add(btnCancel)
        Controls.Add(btnOK)
        Controls.Add(btnRefTargetfolder)
        Controls.Add(brnRefFfmpeg)
        Controls.Add(txtTargetfolder)
        Controls.Add(lblTargetfolder)
        Controls.Add(txtCommandline)
        Controls.Add(lblCommandline)
        Controls.Add(txtFfmpeg)
        Controls.Add(lblFfmpeg)
        Name = "Form1"
        Text = "ffmpegを使ってaviファイルを結合するやつ"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblFfmpeg As Label
    Friend WithEvents txtFfmpeg As TextBox
    Friend WithEvents txtCommandline As TextBox
    Friend WithEvents lblCommandline As Label
    Friend WithEvents txtTargetfolder As TextBox
    Friend WithEvents lblTargetfolder As Label
    Friend WithEvents brnRefFfmpeg As Button
    Friend WithEvents btnRefTargetfolder As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button

End Class
