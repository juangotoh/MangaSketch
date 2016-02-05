Imports System.Windows.Forms

Public Class SaveProg

    Public state As DialogResult = DialogResult.None

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        If Form1.ExportWorker.IsBusy Then
            Form1.ExportWorker.CancelAsync()
        End If
        If Form1.SaveWorker.IsBusy Then
            Form1.SaveWorker.CancelAsync()
        End If
        Me.Close()
    End Sub

    Private Sub Progress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DialogResult = DialogResult.None
    End Sub

    Private Sub Progress_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Visible Then
            DialogResult = DialogResult.None
        End If
    End Sub
    Public Sub setMaximun(max As Integer)
        ProgressBar1.Maximum = max
    End Sub
    Public Sub setMinimum(min As Integer)
        ProgressBar1.Minimum = min
    End Sub
    Public Sub setStep(s)
        ProgressBar1.Step = s
    End Sub
    Public Sub performStep()
        ProgressBar1.PerformStep()
    End Sub
    Public Sub SetValue(v As Integer)
        ProgressBar1.Value = v
        Debug.WriteLine(ProgressBar1.Maximum.ToString + "-" + v.ToString)
    End Sub
    Public Sub WaitClose()
        Update()
        System.Threading.Thread.Sleep(1000)
        Me.Close()
    End Sub
End Class
