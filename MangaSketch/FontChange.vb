Imports System.Windows.Forms

Public Class FontChange

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FontChande_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.buildFontMenu(fromFont)
        Form1.buildFontMenu(toFont)
        fromFont.SelectedIndex = 0
        toFont.SelectedIndex = 0
    End Sub
End Class
