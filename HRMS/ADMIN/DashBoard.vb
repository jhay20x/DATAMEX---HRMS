Imports System.Runtime.CompilerServices

Public Class DashBoard
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Else
            PanelAtt.Visible = False
        End If
    End Sub

    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        If PanelLeave.Visible = False Then
            PanelLeave.Visible = True
        Else
            PanelLeave.Visible = False
        End If
    End Sub

    Private Sub btnHoliday_Click(sender As Object, e As EventArgs) Handles btnHoliday.Click
        If PanelHoliday.Visible = False Then
            PanelHoliday.Visible = True
        Else
            PanelHoliday.Visible = False
        End If
    End Sub

    Private Sub brnProject_Click(sender As Object, e As EventArgs) Handles brnProject.Click
        If PanelProject.Visible = False Then
            PanelProject.Visible = True
        Else
            PanelProject.Visible = False
        End If
    End Sub

    Private Sub btnPayroll_Click(sender As Object, e As EventArgs) Handles btnPayroll.Click
        If PanelPayroll.Visible = False Then
            PanelPayroll.Visible = True
        Else
            PanelPayroll.Visible = False
        End If
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        If PanelEmployee.Visible = False Then
            PanelEmployee.Visible = True
        Else
            PanelEmployee.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles MenuHide1Button.Click, MenuHide2Button.Click
        Try
            If Panel1.AutoSize = True Then
                Panel1.AutoSize = False
            ElseIf Panel1.AutoSize = False Then
                Panel1.AutoSize = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAtt1_Click(sender As Object, e As EventArgs) Handles btnAtt1.Click
        DashboardPanel.Visible = False
        DashboardPanel.Enabled = False
        AttendanceTodayPanel.Visible = True
        AttendanceTodayPanel.Enabled = True
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        AttendanceTodayPanel.Visible = False
        AttendanceTodayPanel.Enabled = False
        DashboardPanel.Visible = True
        DashboardPanel.Enabled = True
    End Sub
End Class