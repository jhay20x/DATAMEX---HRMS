Imports System.IO

Public Class LeaveRequestViewForm
    Public EmpIdEdit As String
    Public DateFiled As Date
    Public Status As String
    Public isDone As Boolean
    Private Sub LeaveRequestView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LREmpIDLabel.Text = EmpIdEdit
        DisplayInfo()

        If LRStatusLabel.Text = "Under Review" Then
            LRApproveButton.Enabled = True
            LRRejectButton.Enabled = True
        Else
            LRApproveButton.Enabled = False
            LRRejectButton.Enabled = False
        End If
    End Sub

    Private Sub LeaveRequestViewForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If isDone Then
            e.Cancel = False
            DashBoardForm.Enabled = True
            DashBoardForm.DisableButton()
            DashBoardForm.RefreshDetails()
            DashBoardForm.LRRefreshButton.PerformClick()
            DashBoardForm.Show()
        Else
            If MsgBox("Are you sure to leave?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Alert") = MsgBoxResult.No Then
                e.Cancel = True
            Else
                DashBoardForm.Enabled = True
                DashBoardForm.DisableButton()
                DashBoardForm.RefreshDetails()
                DashBoardForm.LRRefreshButton.PerformClick()
                DashBoardForm.Show()
            End If
        End If
    End Sub

    Public Sub DisplayInfo()
        Dim StatusID As Integer
        If Status = "Under Review" Then
            StatusID = 1
        ElseIf Status = "Approved" Then
            StatusID = 2
        Else
            StatusID = 3
        End If

        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' 
        THEN '' ELSE Employees.MiddleName END) AS EmployeeName, LeaveType.Type, LeaveRequest.DateFiled, LeaveRequest.DateFrom,
		LeaveRequest.DateTo, LeaveRequest.Duration, LeaveRequest.Reason, LeaveStatus.Status
        FROM LeaveRequest
        LEFT OUTER JOIN Employees
        ON LeaveRequest.EmployeeID = Employees.EmployeeID
        LEFT OUTER JOIN Department
        ON Employees.DepartmentID = Department.ID
        LEFT OUTER JOIN LeaveType
        ON LeaveRequest.LeaveTypeID = LeaveType.ID
        LEFT OUTER JOIN LeaveStatus
        ON LeaveRequest.StatusID = LeaveStatus.ID
        WHERE LeaveRequest.StatusID = @Status 
        AND LeaveRequest.EmployeeID = @EmpID AND LeaveRequest.DateFiled = @DateFiled"

        Prepare(query)
        AddParam("@Status", StatusID)
        AddParam("@EmpID", EmpIdEdit)
        AddParam("@DateFiled", DateFiled)
        ExecutePrepare()

        Dim row As DataRow = DataAsTable.Rows(0)

        LREmployeeNameLabel.Text = row("EmployeeName")
        LRLeaveTypeLabel.Text = row("Type")
        LRDateFiledLabel.Text = row("DateFiled")
        LRDateFromLabel.Text = row("DateFrom")
        LRDateToLabel.Text = row("DateTo")
        LRDurationLabel.Text = row("Duration")
        LRReasonLabel.Text = row("Reason")
        LRStatusLabel.Text = row("Status")
    End Sub

    Private Sub LRApproveButton_Click(sender As Object, e As EventArgs) Handles LRApproveButton.Click
        If MsgBox("Approve leave request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
            Dim curdate = Date.Today
            Dim query = "UPDATE LeaveRequest SET StatusID = 2, VerdictDate = @VerdictDate WHERE EmployeeID = @EmpID AND DateFiled = @DateFiled"

            Prepare(query)
            AddParam("@EmpID", EmpIdEdit)
            AddParam("@DateFiled", DateFiled)
            AddParam("@VerdictDate", curdate)
            ExecutePrepare()

            MsgBox("Request successfully approved!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            UpdateLeaveBalance()
            isDone = True
            Me.Close()
        End If
    End Sub

    Private Sub LRRejectButton_Click(sender As Object, e As EventArgs) Handles LRRejectButton.Click
        If MsgBox("Reject leave request?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Alert") = MsgBoxResult.Yes Then
            Dim curdate = Date.Today
            Dim query = "UPDATE LeaveRequest SET StatusID = 3, VerdictDate = @VerdictDate WHERE EmployeeID = @EmpID AND DateFiled = @DateFiled"

            Prepare(query)
            AddParam("@EmpID", EmpIdEdit)
            AddParam("@DateFiled", DateFiled)
            AddParam("@VerdictDate", curdate)
            ExecutePrepare()

            MsgBox("Request successfully rejected!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, "Alert")
            isDone = True
            Me.Close()
        End If
    End Sub

    Public Sub UpdateLeaveBalance()
        Dim query = "UPDATE LeaveBalance SET Balance = Balance - 1 WHERE EmployeeID = @EmpID"

        Prepare(query)
        AddParam("@EmpID", EmpIdEdit)
        ExecutePrepare()
    End Sub

    Private Sub LRBackButton_Click(sender As Object, e As EventArgs) Handles LRBackButton.Click
        Me.Close()
    End Sub
End Class