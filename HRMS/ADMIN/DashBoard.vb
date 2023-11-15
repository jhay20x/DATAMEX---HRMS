Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class DashBoardForm
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HRMSDataSet.Employees' table. You can move, or remove it, as needed.
        'Me.EmployeesTableAdapter.FillBy(Me.HRMSDataSet.Employees)
        RefreshTable()

        PanelAtt.Visible = False
        PanelLeave.Visible = False
        PanelPayroll.Visible = False
        PanelProject.Visible = False
        PanelHoliday.Visible = False
        PanelEmployee.Visible = False
    End Sub

    Private Sub btnAttendance_Click(sender As Object, e As EventArgs) Handles btnAttendance.Click
        If PanelAtt.Visible = False Then
            PanelAtt.Visible = True
            PanelLeave.Visible = False
            PanelPayroll.Visible = False
            PanelProject.Visible = False
            PanelHoliday.Visible = False
            PanelEmployee.Visible = False
        Else
            PanelAtt.Visible = False
        End If
    End Sub

    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        If PanelLeave.Visible = False Then
            PanelLeave.Visible = True
            PanelAtt.Visible = False
            PanelPayroll.Visible = False
            PanelProject.Visible = False
            PanelHoliday.Visible = False
            PanelEmployee.Visible = False
        Else
            PanelLeave.Visible = False
        End If
    End Sub

    Private Sub btnHoliday_Click(sender As Object, e As EventArgs) Handles btnHoliday.Click
        If PanelHoliday.Visible = False Then
            PanelHoliday.Visible = True
            PanelAtt.Visible = False
            PanelLeave.Visible = False
            PanelPayroll.Visible = False
            PanelProject.Visible = False
            PanelEmployee.Visible = False
        Else
            PanelHoliday.Visible = False
        End If
    End Sub

    Private Sub brnProject_Click(sender As Object, e As EventArgs) Handles brnProject.Click
        If PanelProject.Visible = False Then
            PanelProject.Visible = True
            PanelAtt.Visible = False
            PanelLeave.Visible = False
            PanelPayroll.Visible = False
            PanelHoliday.Visible = False
            PanelEmployee.Visible = False
        Else
            PanelProject.Visible = False
        End If
    End Sub

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        If PanelPayroll.Visible = False Then
            PanelPayroll.Visible = True
            PanelAtt.Visible = False
            PanelLeave.Visible = False
            PanelProject.Visible = False
            PanelHoliday.Visible = False
            PanelEmployee.Visible = False
        Else
            PanelPayroll.Visible = False
        End If
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        If PanelEmployee.Visible = False Then
            PanelEmployee.Visible = True
            PanelAtt.Visible = False
            PanelLeave.Visible = False
            PanelPayroll.Visible = False
            PanelProject.Visible = False
            PanelHoliday.Visible = False
        Else
            PanelEmployee.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles MenuHide1Button.Click, MenuHide2Button.Click, MenuHide3Button.Click, MenuHide4Button.Click, MenuHide5Button.Click, MenuHide6Button.Click, MenuHide7Button.Click
        Try
            If Panel1.AutoSize = True Then
                Panel1.AutoSize = False
            Else
                Panel1.AutoSize = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAtt1_Click(sender As Object, e As EventArgs) Handles btnAtt1.Click
        EmployeesSalaryPanel.Visible = False
        EmployeesSalaryPanel.Enabled = False
        HolidayListPanel.Visible = False
        HolidayListPanel.Enabled = False
        LeaveRequestPanel.Visible = False
        LeaveRequestPanel.Enabled = False
        EmployeeAllPanel.Visible = False
        EmployeeAllPanel.Enabled = False
        DashboardPanel.Visible = False
        DashboardPanel.Enabled = False
        AttendanceTodayPanel.Visible = True
        AttendanceTodayPanel.Enabled = True
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        PanelAtt.Visible = False
        PanelLeave.Visible = False
        PanelPayroll.Visible = False
        PanelProject.Visible = False
        PanelHoliday.Visible = False
        PanelEmployee.Visible = False
        EmployeesSalaryPanel.Visible = False
        EmployeesSalaryPanel.Enabled = False
        ProjectsListPanel.Visible = False
        ProjectsListPanel.Enabled = False
        HolidayListPanel.Visible = False
        HolidayListPanel.Enabled = False
        LeaveRequestPanel.Visible = False
        LeaveRequestPanel.Enabled = False
        EmployeeAllPanel.Visible = False
        EmployeeAllPanel.Enabled = False
        AttendanceTodayPanel.Visible = False
        AttendanceTodayPanel.Enabled = False
        DashboardPanel.Visible = True
        DashboardPanel.Enabled = True
    End Sub

    Private Sub btnEm1_Click(sender As Object, e As EventArgs) Handles btnEm1.Click
        EmployeesSalaryPanel.Visible = False
        EmployeesSalaryPanel.Enabled = False
        ProjectsListPanel.Visible = False
        ProjectsListPanel.Enabled = False
        HolidayListPanel.Visible = False
        HolidayListPanel.Enabled = False
        LeaveRequestPanel.Visible = False
        LeaveRequestPanel.Enabled = False
        AttendanceTodayPanel.Visible = False
        AttendanceTodayPanel.Enabled = False
        DashboardPanel.Visible = False
        DashboardPanel.Enabled = False
        EmployeeAllPanel.Visible = True
        EmployeesDataGridView.CurrentCell = Nothing
        EmployeeAllPanel.Enabled = True
    End Sub

    Private Sub btnLev1_Click(sender As Object, e As EventArgs) Handles btnLev1.Click
        EmployeesSalaryPanel.Visible = False
        EmployeesSalaryPanel.Enabled = False
        ProjectsListPanel.Visible = False
        ProjectsListPanel.Enabled = False
        HolidayListPanel.Visible = False
        HolidayListPanel.Enabled = False
        AttendanceTodayPanel.Visible = False
        AttendanceTodayPanel.Enabled = False
        DashboardPanel.Visible = False
        DashboardPanel.Enabled = False
        EmployeeAllPanel.Visible = False
        EmployeeAllPanel.Enabled = False
        LeaveRequestPanel.Visible = True
        LeaveRequestPanel.Enabled = True
    End Sub

    Private Sub btnHol1_Click(sender As Object, e As EventArgs) Handles btnHol1.Click
        EmployeesSalaryPanel.Visible = False
        EmployeesSalaryPanel.Enabled = False
        ProjectsListPanel.Visible = False
        ProjectsListPanel.Enabled = False
        AttendanceTodayPanel.Visible = False
        AttendanceTodayPanel.Enabled = False
        DashboardPanel.Visible = False
        DashboardPanel.Enabled = False
        EmployeeAllPanel.Visible = False
        EmployeeAllPanel.Enabled = False
        LeaveRequestPanel.Visible = False
        LeaveRequestPanel.Enabled = False
        HolidayListPanel.Visible = True
        HolidayListPanel.Enabled = True
    End Sub

    Private Sub btnPro1_Click(sender As Object, e As EventArgs) Handles btnPro1.Click
        EmployeesSalaryPanel.Visible = False
        EmployeesSalaryPanel.Enabled = False
        AttendanceTodayPanel.Visible = False
        AttendanceTodayPanel.Enabled = False
        DashboardPanel.Visible = False
        DashboardPanel.Enabled = False
        EmployeeAllPanel.Visible = False
        EmployeeAllPanel.Enabled = False
        LeaveRequestPanel.Visible = False
        LeaveRequestPanel.Enabled = False
        HolidayListPanel.Visible = False
        HolidayListPanel.Enabled = False
        ProjectsListPanel.Visible = True
        ProjectsListPanel.Enabled = True
    End Sub

    Private Sub btnPay1_Click(sender As Object, e As EventArgs) Handles btnPay1.Click
        AttendanceTodayPanel.Visible = False
        AttendanceTodayPanel.Enabled = False
        DashboardPanel.Visible = False
        DashboardPanel.Enabled = False
        EmployeeAllPanel.Visible = False
        EmployeeAllPanel.Enabled = False
        LeaveRequestPanel.Visible = False
        LeaveRequestPanel.Enabled = False
        HolidayListPanel.Visible = False
        HolidayListPanel.Enabled = False
        ProjectsListPanel.Visible = False
        ProjectsListPanel.Enabled = False
        EmployeesSalaryPanel.Visible = True
        EmployeesSalaryPanel.Enabled = True
    End Sub

    Private Sub EmployeesBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.EmployeesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.HRMSDataSet)

    End Sub

    Private Sub EmployeeListAddButton_Click(sender As Object, e As EventArgs) Handles EmployeeListAddButton.Click
        'Me.Hide()
        Me.Enabled = False
        EmployeeListAddForm.Show(Me)
    End Sub

    Private Sub DashBoard_Shown(sender As Object, e As EventArgs) Handles Me.Load, Me.Activated
        Dim TotalEmp As Integer
        Dim WorkingEmp As Integer
        Dim NonWorkingEmp As Integer

        Dim cmd As New SqlCommand("SELECT StatusID FROM Employees;", Connection)

        If Connection.State = ConnectionState.Open Then
            Connection.Close()
            Connection.Open()
        Else
            Connection.Open()
        End If

        Dim sdr As SqlDataReader = cmd.ExecuteReader

        While sdr.Read
            If sdr("StatusID") = 1 Or sdr("StatusID") = 2 Then
                TotalEmp += 1
            End If
            If sdr("StatusID") = 1 Then
                WorkingEmp += 1
            End If
            If sdr("StatusID") = 2 Then
                NonWorkingEmp += 1
            End If
        End While

        ELTotalLabel.Text = TotalEmp
        ELWorkingLabel.Text = WorkingEmp
        ELNWorkingLabel.Text = NonWorkingEmp

        Try
            'Me.EmployeesTableAdapter.FillBy(Me.HRMSDataSet.Employees)
            RefreshTable()
            Me.EmployeesDataGridView.Sort(Me.EmployeesDataGridView.Columns(5), ListSortDirection.Descending)
            EmployeesDataGridView.CurrentCell = Nothing
            EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
            EmployeeListEditButton.Enabled = False
        Catch ex As Exception

        End Try

        Connection.Close()
    End Sub

    Private Sub EmployeesDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeesDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            EmployeesDataGridView.CurrentCell = Nothing
            EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
            EmployeeListEditButton.Enabled = False

        Else
            Try
                EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit
                EmployeeListEditButton.Enabled = True

                Dim index As Integer

                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = EmployeesDataGridView.Rows(index)

                EmpIdEdit = selectedrow.Cells(1).Value
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub EmployeeListEditButton_Click(sender As Object, e As EventArgs) Handles EmployeeListEditButton.Click
        Me.Enabled = False
        EmployeeListEditForm.Show(Me)
    End Sub

    Private Sub EmployeeListUpdateButton_Click(sender As Object, e As EventArgs) Handles EmployeeListUpdateButton.Click
        'Me.EmployeesTableAdapter.FillBy(Me.HRMSDataSet.Employees)
        RefreshTable()
        EmployeesDataGridView.CurrentCell = Nothing
        EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
        EmployeeListEditButton.Enabled = False
    End Sub

    Private Sub EmployeeNameSearchBoxTextBox_TextChanged(sender As Object, e As EventArgs) Handles EmployeeNameSearchBoxTextBox.TextChanged
        Dim Name As String = EmployeeNameSearchBoxTextBox.Text

        Dim query1 As New SqlDataAdapter("SELECT Employees.ID, Employees.EmployeeID, Employees.LastName, Employees.FirstName, Employees.MiddleName, Status.Status as 'StatusID', Department.Department AS 'DepartmentID',
                Employees.DateHired, Employees.Age, Employees.Address, Employees.SSSNo, Employees.PhilHealthNo, Employees.PagibigNo, Employees.TIN, Employees.ContactNumber, Employees.EmailAddress
                FROM Employees INNER JOIN
                Department ON Employees.DepartmentID = Department.ID INNER JOIN
                Status ON Employees.StatusID = Status.ID
                WHERE FirstName LIKE @Name OR LastName LIKE @Name OR MiddleName LIKE @Name;", Connection)
        query1.SelectCommand.Parameters.AddWithValue("@Name", "%" + Name + "%")

        Dim newdataset As New DataSet

        query1.Fill(newdataset, "Employees")
        EmployeesDataGridView.DataSource = newdataset.Tables("Employees").DefaultView
    End Sub

    Private Sub EmployeeNameSearchBoxTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EmployeeNameSearchBoxTextBox.KeyPress
        If (Asc(e.KeyChar) > 32 And Asc(e.KeyChar) < 44 Or Asc(e.KeyChar) = 47) Then
            e.Handled = True
        ElseIf (Asc(e.KeyChar) > 57 And Asc(e.KeyChar) < 64) Then
            e.Handled = True
        ElseIf (Asc(e.KeyChar) > 90 And Asc(e.KeyChar) < 97) Then
            e.Handled = True
        ElseIf (Asc(e.KeyChar) > 122 And Asc(e.KeyChar) < 128) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Public Sub RefreshTable()
        EmployeesDataGridView.DataSource = Nothing
        EmployeesDataGridView.Refresh()
        Dim str As String = "SELECT Employees.ID, Employees.EmployeeID, Employees.LastName, Employees.FirstName, Employees.MiddleName, Status.Status as 'StatusID', Department.Department AS 'DepartmentID',
                Employees.DateHired, Employees.Age, Employees.Address, Employees.SSSNo, Employees.PhilHealthNo, Employees.PagibigNo, Employees.TIN, Employees.ContactNumber, Employees.EmailAddress
                FROM Employees INNER JOIN
                Department ON Employees.DepartmentID = Department.ID INNER JOIN
                Status ON Employees.StatusID = Status.ID"

        Dim cmd As New SqlCommand(str, Connection)

        Dim da As New SqlDataAdapter(cmd)
        Dim newtable As New DataTable

        da.Fill(newtable)
        EmployeesDataGridView.DataSource = newtable
    End Sub
End Class