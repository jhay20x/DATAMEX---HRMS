Imports System.ComponentModel

Public Class DashBoard

    Public Sub PopulateEmployeeNames()
        Dim query = "SELECT CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) AS EmployeeName 
        FROM Employees"

        Prepare(query)
        ExecutePrepare()

        ASEmployeeNamesComboBox.MaxDropDownItems = 5
        ASEmployeeNamesComboBox.DataSource = DataAsTable
        ASEmployeeNamesComboBox.DisplayMember = "EmployeeName"
        ASEmployeeNamesComboBox.SelectedIndex = 0
    End Sub
    Private Sub MenuHide6Button_Click(sender As Object, e As EventArgs) Handles MenuHide6Button.Click
        Try
            If Panel1.AutoSize = True Then
                Panel1.AutoSize = False
            Else
                Panel1.AutoSize = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelLeave.Visible = False
    End Sub

    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        'If PanelLeave.Visible = True Then
        'PanelLeave.Visible = False
        'ElseIf PanelLeave.Visible = False Then
        'PanelLeave.Visible = True
        'End If
        AttendancePNL.Visible = False
        DashboardPNL.Visible = False
        HolidayListPanel.Visible = False
        ProjectsListPanel.Visible = False

        LeavePNL.Visible = True
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        AttendancePNL.Visible = False
        LeavePNL.Visible = False
        HolidayListPanel.Visible = False
        ProjectsListPanel.Visible = False

        DashboardPNL.Visible = True
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        DashboardPNL.Visible = False
        LeavePNL.Visible = False
        HolidayListPanel.Visible = False
        ProjectsListPanel.Visible = False

        AttendancePNL.Visible = True

        Dim query = "SELECT AttDate, CONVERT(varchar, AttendanceRecords.TimeIn, 22) AS TimeIn, CONVERT(varchar, AttendanceRecords.TimeOut, 22) AS TimeOut, TotalHours, Late, OT, Undertime, HalfDay 
        FROM AttendanceRecords
        LEFT OUTER JOIN Employees
        ON AttendanceRecords.EmployeeID = Employees.EmployeeID  
        WHERE CONCAT(Employees.LastName, ', ', Employees.FirstName, ' ', CASE WHEN Employees.MiddleName = 'N/A' THEN '' ELSE Employees.MiddleName END) LIKE @Search"

        Prepare(query)
        AddParam("@Search", "%" & ASEmployeeNamesComboBox.Text & "%")
        ExecutePrepare()

        AttendanceSheetDataGridView.DataSource = DataAsTable
        AttendanceSheetDataGridView.Sort(AttendanceSheetDataGridView.Columns(0), ListSortDirection.Descending)
    End Sub

    Private Sub btnHoliday_Click(sender As Object, e As EventArgs) Handles btnHoliday.Click
        AttendancePNL.Visible = False
        DashboardPNL.Visible = False
        LeavePNL.Visible = False
        ProjectsListPanel.Visible = False

        HolidayListPanel.Visible = True
    End Sub

    Private Sub brnProject_Click(sender As Object, e As EventArgs) Handles brnProject.Click
        AttendancePNL.Visible = False
        DashboardPNL.Visible = False
        LeavePNL.Visible = False
        HolidayListPanel.Visible = False

        ProjectsListPanel.Visible = True
    End Sub

End Class