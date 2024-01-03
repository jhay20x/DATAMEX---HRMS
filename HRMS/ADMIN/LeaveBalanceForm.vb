Imports System.Runtime.CompilerServices

Public Class LeaveBalanceForm
    Public EmpID As String
    Public isDone As Boolean
    Private Sub LeaveBalanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayData()
    End Sub

    Public Sub DisplayData()
        Dim query = "SELECT Employees.EmployeeID, CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' 
        THEN '' ELSE Employees.MiddleName END) AS EmployeeName, Department.Department, LeaveBalance.Balance
        FROM LeaveBalance
        LEFT OUTER JOIN Employees
        ON LeaveBalance.EmployeeID = Employees.EmployeeID
        LEFT OUTER JOIN Department
        ON Employees.DepartmentID = Department.ID"

        Prepare(query)
        ExecutePrepare()

        LeaveBalanceDataGridView.DataSource = DataAsTable
        LeaveBalanceDataGridView.CurrentCell = Nothing
        LBSaveButton.Enabled = False
        'Err.Raise(1)
    End Sub

    Private Sub LeaveBalanceForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isDone Then
            e.Cancel = False
            DashBoardForm.Enabled = True
            DashBoardForm.DisableButton()
            DashBoardForm.Show()
        Else
            If MsgBox("Are you sure to leave?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                DashBoardForm.Enabled = True
                DashBoardForm.DisableButton()
                DashBoardForm.Show()
            End If
        End If
    End Sub

    Private Sub LeaveBalanceDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles LeaveBalanceDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            LeaveBalanceDataGridView.CurrentCell = Nothing
            LBSaveButton.Enabled = False
            LBBalanceTextBox.Text = ""

        Else
            Try
                LBSaveButton.Enabled = True

                Dim index As Integer
                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = LeaveBalanceDataGridView.Rows(index)
                EmpID = selectedrow.Cells(0).Value
                LBBalanceTextBox.Text = selectedrow.Cells(3).Value
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub LBSaveButton_Click(sender As Object, e As EventArgs) Handles LBSaveButton.Click
        If LBBalanceTextBox.Text > 15 Or LBBalanceTextBox.Text = "" Then
            MsgBox("Value exceeded. The current limit is 15.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
        Else
            If MsgBox("Are you sure to change the leave balance?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
                Dim query = "UPDATE LeaveBalance SET Balance = @Balance WHERE EmployeeID = @EmpID"

                Prepare(query)
                AddParam("@Balance", LBBalanceTextBox.Text)
                AddParam("@EmpID", EmpID)
                ExecutePrepare()

                LBBalanceTextBox.Text = ""
                LeaveBalanceDataGridView.CurrentCell = Nothing
                DisplayData()
                MsgBox("Leave balance successfully saved.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            End If
        End If
    End Sub

    Private Sub LBBackButton_Click(sender As Object, e As EventArgs) Handles LBBackButton.Click
        Me.Close()
    End Sub
End Class