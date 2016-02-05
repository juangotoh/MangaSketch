Imports System.Windows.Forms

Public Class SaveOrNot

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub Ignore_Button_Click(sender As Object, e As EventArgs) Handles Ignore_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.Close()
    End Sub
    Private Sub SaveOrNot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class
