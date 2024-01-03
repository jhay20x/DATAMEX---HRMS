Imports System.Reflection

Public Class LeaveTypeForm
    Public ID As Integer
    Public LeaveTypes As New List(Of String)
    Private Sub LeaveTypeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTypes()
        DisplayData()
        LTSaveButton.Enabled = False
    End Sub

    Public Sub GetTypes()
        Dim query = "SELECT Type FROM LeaveType"

        Prepare(query)
        ExecutePrepare()

        For Each row As DataRow In DataAsTable.Rows
            LeaveTypes.Add(row("Type"))
        Next
    End Sub

    Public Sub DisplayData()
        Dim query = "SELECT * FROM LeaveType"

        Prepare(query)
        ExecutePrepare()

        LeaveTypeDataGridView.DataSource = DataAsTable
        LeaveTypeDataGridView.CurrentCell = Nothing
    End Sub

    Private Sub LeaveTypeForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        DashBoardForm.Enabled = True
        DashBoardForm.Show()
    End Sub

    Private Sub LeaveTypeDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles LeaveTypeDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            LeaveTypeDataGridView.CurrentCell = Nothing
            LTSaveButton.Enabled = False
            LTTypeTextBox.Text = ""
            LTPaymentComboBox.SelectedIndex = -1

        Else
            Try
                LTSaveButton.Enabled = True

                Dim index As Integer
                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = LeaveTypeDataGridView.Rows(index)
                ID = selectedrow.Cells(0).Value
                LTTypeTextBox.Text = selectedrow.Cells(1).Value
                If selectedrow.Cells(2).Value = "Paid" Then
                    LTPaymentComboBox.SelectedIndex = 0
                Else
                    LTPaymentComboBox.SelectedIndex = 1
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub LTBackButton_Click(sender As Object, e As EventArgs) Handles LTBackButton.Click
        Me.Close()
    End Sub

    Private Sub LTSaveButton_Click(sender As Object, e As EventArgs) Handles LTSaveButton.Click
        If LTTypeTextBox.Text = "" Then
            MsgBox("Invalid input. Please try again.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        Else
            If MsgBox("Are you sure to change this leave type?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                Dim query = "UPDATE LeaveType SET Type = @Type, Payment = @Payment WHERE ID = @ID"

                Prepare(query)
                AddParam("@Type", LTTypeTextBox.Text)
                AddParam("@Payment", LTPaymentComboBox.Text)
                AddParam("@ID", ID)
                ExecutePrepare()

                LTTypeTextBox.Text = ""
                LTPaymentComboBox.SelectedIndex = -1
                LTSaveButton.Enabled = False
                LeaveTypeDataGridView.CurrentCell = Nothing
                DisplayData()
                MsgBox("Leave balance successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            End If
        End If
    End Sub

    Private Sub LTAddButton_Click(sender As Object, e As EventArgs) Handles LTAddButton.Click
        Me.Enabled = False
        LeaveTypeAddForm.Show(Me)
    End Sub
End Class