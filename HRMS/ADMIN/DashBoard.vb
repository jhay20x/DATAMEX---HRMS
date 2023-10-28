Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class DashBoardForm
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HRMSDataSet.EmployeesInformation' table. You can move, or remove it, as needed.
        Me.EmployeesInformationTableAdapter.Fill(Me.HRMSDataSet.EmployeesInformation)

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
        EmployeesInformationDataGridView.CurrentCell = Nothing
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

    Private Sub EmployeesInformationBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles EmployeesInformationBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.EmployeesInformationBindingSource.EndEdit()
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

        Dim cmd As New SqlCommand("SELECT EmployeeStatus FROM EmployeesInformation;", Connection)

        If Connection.State = ConnectionState.Open Then
            Connection.Close()
            Connection.Open()
        Else
            Connection.Open()
        End If

        Dim sdr As SqlDataReader = cmd.ExecuteReader

        While sdr.Read
            If sdr("EmployeeStatus") = "Working" Or sdr("EmployeeStatus") = "Non-Working" Then
                TotalEmp += 1
            End If
            If sdr("EmployeeStatus") = "Working" Then
                WorkingEmp += 1
            End If
            If sdr("EmployeeStatus") = "Non-Working" Then
                NonWorkingEmp += 1
            End If
        End While

        ELTotalLabel.Text = TotalEmp
        ELWorkingLabel.Text = WorkingEmp
        ELNWorkingLabel.Text = NonWorkingEmp

        Try
            Me.EmployeesInformationTableAdapter.Fill(Me.HRMSDataSet.EmployeesInformation)
            Me.EmployeesInformationDataGridView.Sort(Me.EmployeesInformationDataGridView.Columns(6), ListSortDirection.Descending)
            EmployeesInformationDataGridView.CurrentCell = Nothing
            EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
            EmployeeListEditButton.Enabled = False
        Catch ex As Exception

        End Try

        Connection.Close()
    End Sub

    Private Sub EmployeesInformationDataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles EmployeesInformationDataGridView.CellClick
        If My.Computer.Keyboard.ShiftKeyDown Then
            EmployeesInformationDataGridView.CurrentCell = Nothing
            EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
            EmployeeListEditButton.Enabled = False

        Else
            Try
                EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit
                EmployeeListEditButton.Enabled = True

                Dim index As Integer

                index = e.RowIndex

                Dim selectedrow As DataGridViewRow
                selectedrow = EmployeesInformationDataGridView.Rows(index)

                EmpIdEdit = selectedrow.Cells(0).Value
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub EmployeeListEditButton_Click(sender As Object, e As EventArgs) Handles EmployeeListEditButton.Click
        Me.Enabled = False
        EmployeeListEditForm.Show(Me)
    End Sub

    Private Sub EmployeeListUpdateButton_Click(sender As Object, e As EventArgs) Handles EmployeeListUpdateButton.Click
        Me.EmployeesInformationTableAdapter.Fill(Me.HRMSDataSet.EmployeesInformation)
        EmployeesInformationDataGridView.CurrentCell = Nothing
        EmployeeListEditButton.BackgroundImage = HRM1.My.Resources.Resources.edit_disabled
        EmployeeListEditButton.Enabled = False
    End Sub
End Class