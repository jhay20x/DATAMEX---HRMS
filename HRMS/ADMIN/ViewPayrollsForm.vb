Imports System.Runtime.CompilerServices

Public Class ViewPayrollsForm
    Public isDone As Boolean
    Private Sub ViewPayrollsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ViewPayrollsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isDone Then
            e.Cancel = False
            DashBoardForm.Enabled = True
            DashBoardForm.Show()
        Else
            If MsgBox("Are you sure to leave?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                DashBoardForm.Enabled = True
                DashBoardForm.Show()
            End If
        End If
    End Sub

    Private Sub PayrollBackButton_Click(sender As Object, e As EventArgs) Handles PayrollBackButton.Click
        Me.Close()
    End Sub
End Class