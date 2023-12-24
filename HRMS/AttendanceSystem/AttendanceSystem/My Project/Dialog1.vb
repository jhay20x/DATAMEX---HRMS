Imports System.Windows.Forms

Public Class MessageDialog
    Public Message As String

    Private Sub ProgressBarTimer_Tick(sender As Object, e As EventArgs) Handles ProgressBarTimer.Tick
        AutoCloseProgressBar.PerformStep()

        If AutoCloseProgressBar.Value = 1000 Then
            MainForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageLabel.Text = Message
    End Sub
End Class
