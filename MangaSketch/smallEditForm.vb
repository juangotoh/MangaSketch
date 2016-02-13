Public Class smallEditForm
    Dim parent As Page
    Private Sub smallEditForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Select()
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Escape Then
            Hide()
        End If
    End Sub

    Private Sub SmallEdit_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Visible Then TextBox1.Select()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Return) And (Control.ModifierKeys And Keys.Shift) = Keys.Shift Then
            e.Handled = True
            Dim p As Page = parent
            Me.DialogResult = DialogResult.OK
            'p.EndEdit()
            Hide()
            Form1.ImeMode = ImeMode.Alpha
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim p As Page = parent
        Me.DialogResult = DialogResult.OK
        'p.EndEdit()
        Hide()
    End Sub

    Private Sub AddRuby()
        Dim str As String = TextBox1.Text
        Dim st As Integer = TextBox1.SelectionStart
        Dim slen As Integer = TextBox1.SelectionLength
        Dim rb As String = TextBox1.SelectedText
        Dim rt As String
        If rb.Length > 0 Then
            Dim rd As New RubyDialog()
            rd.SetRB(rb)
            If rd.ShowDialog(Me) = DialogResult.OK Then
                rt = rd.TextBox1.Text
                If rt.Length > 0 Then
                    Dim left As String = str.Substring(0, st)
                    Dim right As String = str.Substring(st + slen)
                    TextBox1.Text = left + "｜" + rb + "《" + rt + "》" + right
                End If
            End If
        End If
        TextBox1.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddRuby()
    End Sub
End Class