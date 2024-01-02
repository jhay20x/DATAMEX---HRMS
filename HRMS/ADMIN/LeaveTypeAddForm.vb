Imports System.Runtime.CompilerServices

Public Class LeaveTypeAddForm
    Public LeaveTypes As New List(Of String)
    Public isDone As Boolean
    Private Sub LTSaveButton_Click(sender As Object, e As EventArgs) Handles LTSaveButton.Click
        If LeaveTypes.Contains(LTTypeTextBox.Text) Then
            MsgBox(LTTypeTextBox.Text & " is already on the lists of leave types. Please try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            LTTypeTextBox.Text = ""
            LTTypeTextBox.Select()
        Else
            Dim query = "INSERT INTO LeaveType VALUES (@LeaveType, @Payment)"

            Prepare(query)
            AddParam("@LeaveType", LTTypeTextBox.Text)
            AddParam("@Payment", LTPaymentComboBox.Text)
            ExecutePrepare()

            LTTypeTextBox.Text = ""
            LTPaymentComboBox.SelectedIndex = -1
            GetTypes()
            MsgBox("New leave type has been added.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        End If
    End Sub

    Private Sub LeaveTypeAddForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTypes()
    End Sub

    Public Sub GetTypes()
        Dim query = "SELECT Type FROM LeaveType"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            LeaveTypes.Add(row("Type"))
        Next
    End Sub

    Private Sub LeaveTypeAddForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isDone Then
            e.Cancel = False
            LeaveTypeForm.Enabled = True
            LeaveTypeForm.DisplayData()
            LeaveTypeForm.Show()
        Else
            If MsgBox("Are you sure to leave?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                LeaveTypeForm.Enabled = True
                LeaveTypeForm.DisplayData()
                LeaveTypeForm.Show()
            End If
        End If
    End Sub
End Class