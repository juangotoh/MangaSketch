Imports System.Windows.Forms

Public Class ExportOption

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ExportOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ComboBox_dpi.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox_Path.Text.Length > 0 And IO.Directory.Exists(TextBox_Path.Text) Then
            FolderBrowserDialog1.SelectedPath = TextBox_Path.Text
        End If
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            TextBox_Path.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub TextExportCheck_CheckedChanged(sender As Object, e As EventArgs) Handles TextExportCheck.CheckedChanged
        If TextExportCheck.Checked Then
            UseGaijiCheck.Enabled = True
        Else
            UseGaijiCheck.Enabled = False
        End If
    End Sub
End Class
