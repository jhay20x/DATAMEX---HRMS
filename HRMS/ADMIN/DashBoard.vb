﻿Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices

Public Class DashBoardForm
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'HRMSDataSet.EmployeesInformation' table. You can move, or remove it, as needed.
        Me.EmployeesInformationTableAdapter.Fill(Me.HRMSDataSet.EmployeesInformation)
        con.Open()
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

    Private Sub DashBoard_Shown(sender As Object, e As EventArgs) Handles Me.EnabledChanged, Me.Load
        Dim TotalEmp As Integer
        Dim WorkingEmp As Integer
        Dim NonWorkingEmp As Integer

        Me.EmployeesInformationTableAdapter.Fill(Me.HRMSDataSet.EmployeesInformation)

        Dim cmd1 As New SqlCommand("SELECT COUNT(*) as tablecount FROM EmployeesInformation;", con)
        Dim cmd2 As New SqlCommand("SELECT COUNT(EmployeeStatus) as workingcount FROM EmployeesInformation WHERE EmployeeStatus LIKE 'Working%';", con)
        Dim cmd3 As New SqlCommand("SELECT COUNT(EmployeeStatus) as nonworkcount FROM EmployeesInformation WHERE EmployeeStatus LIKE 'Non-Working%';", con)

        Dim sdr1 As SqlDataReader = cmd1.ExecuteReader
        Dim sdr2 As SqlDataReader = cmd2.ExecuteReader
        Dim sdr3 As SqlDataReader = cmd3.ExecuteReader

        While sdr1.Read
            TotalEmp = sdr1("tablecount")
        End While

        While sdr2.Read
            WorkingEmp = sdr2("workingcount")
        End While

        While sdr3.Read
            NonWorkingEmp = sdr3("nonworkcount")
        End While

        ELTotalLabel.Text = TotalEmp
        ELWorkingLabel.Text = WorkingEmp
        ELNWorkingLabel.Text = NonWorkingEmp
    End Sub
End Class